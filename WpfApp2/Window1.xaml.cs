using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
     

        /// <summary>
        /// 路径动画
        /// </summary>
        /// <param name="cvs">画板</param>
        /// <param name="path">路径</param>
        /// <param name="target">动画对象</param>
        /// <param name="duration">时间</param>
        private void AnimationByPath(Canvas cvs, Path path, double targetWidth, int duration = 5)
        {
            #region 创建动画对象
            Rectangle target = new Rectangle();
            target.Width = targetWidth;
            target.Height = targetWidth;
            target.Fill = new SolidColorBrush(Colors.Orange);
            cvs.Children.Add(target);
            Canvas.SetLeft(target, -targetWidth / 2);
            Canvas.SetTop(target, -targetWidth / 2);
            target.RenderTransformOrigin = new Point(0.5, 0.5);
            #endregion

            MatrixTransform matrix = new MatrixTransform();
            TransformGroup groups = new TransformGroup();
            groups.Children.Add(matrix);
            target.RenderTransform = groups;
            string registname = "matrix" + Guid.NewGuid().ToString().Replace("-", "");
            this.RegisterName(registname, matrix);
            MatrixAnimationUsingPath matrixAnimation = new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = PathGeometry.CreateFromGeometry(Geometry.Parse(path.Data.ToString()));
            matrixAnimation.Duration = new Duration(TimeSpan.FromSeconds(duration));
            matrixAnimation.DoesRotateWithTangent = true;//跟随路径旋转
            matrixAnimation.RepeatBehavior = RepeatBehavior.Forever;//循环
            Storyboard story = new Storyboard();
            story.Children.Add(matrixAnimation);
            Storyboard.SetTargetName(matrixAnimation, registname);
            Storyboard.SetTargetProperty(matrixAnimation, new PropertyPath(MatrixTransform.MatrixProperty));

            story.FillBehavior = FillBehavior.Stop;
            story.Begin(target, true);
        }


        /// <summary>
        /// 正向
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnimo_Click(object sender, RoutedEventArgs e)
        {
            AnimationByPath(cvsMain, path1, path1.StrokeThickness, false, 3);
        }
        /// <summary>
        /// 反向
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReback_Click(object sender, RoutedEventArgs e)
        {
            AnimationByPath(cvsMain, path1, path1.StrokeThickness, true, 3);
        }



        /// <summary>
        /// 路径动画
        /// </summary>
        /// <param name="cvs">画板</param>
        /// <param name="path">路径</param>
        /// <param name="targetWidth">动画对象宽高</param>
        /// <param name="isInverse">是否反向</param>
        /// <param name="duration">动画时间</param>
        private void AnimationByPath(Canvas cvs, Path path, double targetWidth, bool isInverse = false, int duration = 5)
        {
            Polygon target = new Polygon();
            target.Points = new PointCollection()
            {
                new Point(0,0),
                new Point(targetWidth/2,0),
                new Point(targetWidth,targetWidth/2),
                new Point(targetWidth/2,targetWidth),
                new Point(0,targetWidth),
                new Point(targetWidth/2,targetWidth/2)
            };

            if (isInverse)//反向
            {
                target.Fill = new SolidColorBrush(Colors.DeepSkyBlue);
            }
            else//正向
            {
                target.Fill = new SolidColorBrush(Colors.Orange);
            }

            cvs.Children.Add(target);
            Canvas.SetLeft(target, -targetWidth / 2);
            Canvas.SetTop(target, -targetWidth / 2);
            target.RenderTransformOrigin = new Point(0.5, 0.5);

            MatrixTransform matrix = new MatrixTransform();
            TransformGroup groups = new TransformGroup();
            groups.Children.Add(matrix);
            target.RenderTransform = groups;
            string registname = "matrix" + Guid.NewGuid().ToString().Replace("-", "");
            this.RegisterName(registname, matrix);
            MatrixAnimationUsingPath matrixAnimation = new MatrixAnimationUsingPath();
            if (!isInverse)//正向
            {
                matrixAnimation.PathGeometry = PathGeometry.CreateFromGeometry(Geometry.Parse(path.Data.ToString()));
            }
            else//反向
            {
                string data = ConvertPathData(path.Data.ToString());
                matrixAnimation.PathGeometry = PathGeometry.CreateFromGeometry(Geometry.Parse(data));
            }
            matrixAnimation.Duration = new Duration(TimeSpan.FromSeconds(duration));
            matrixAnimation.DoesRotateWithTangent = true;//旋转
            matrixAnimation.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard story = new Storyboard();
            story.Children.Add(matrixAnimation);
            Storyboard.SetTargetName(matrixAnimation, registname);
            Storyboard.SetTargetProperty(matrixAnimation, new PropertyPath(MatrixTransform.MatrixProperty));

            story.FillBehavior = FillBehavior.Stop;
            story.Begin(target, true);
        }



        private string ConvertPathData(string data)
        {
            data = data.Replace("M", "");
            Regex regex = new Regex("[a-z]", RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(data);
            //item1 从上一个位置到当前位置开始的字符 (match.Index=原始字符串中发现捕获的子字符串的第一个字符的位置。)
            //item2 当前发现的匹配符号(L C Z M)
            List<Tuple<string, string>> tmps = new List<Tuple<string, string>>();
            int index = 0;
            for (int i = 0; i < mc.Count; i++)
            {
                Match match = mc[i];
                if (match.Index != index)
                {
                    string str = data.Substring(index, match.Index - index);
                    tmps.Add(new Tuple<string, string>(str, match.Value));
                }
                index = match.Index + match.Length;
                if (i + 1 == mc.Count)//last 
                {
                    tmps.Add(new Tuple<string, string>(data.Substring(index), match.Value));
                }
            }
            List<string[]> arrys = new List<string[]>();
            Regex regexnum = new Regex(@"(\-?\d+\.?\d*)", RegexOptions.IgnoreCase);
            for (int i = 0; i < tmps.Count; i++)
            {
                MatchCollection childMcs = regexnum.Matches(tmps[i].Item1);
                if (childMcs.Count % 2 != 0)
                {
                    continue;
                }
                int groups = childMcs.Count / 2;
                var strTmp = new string[groups];
                for (int j = 0; j < groups; j++)
                {
                    string cdatas = childMcs[j * 2] + "," + childMcs[j * 2 + 1];//重组数据
                    strTmp[j] = cdatas;
                }
                arrys.Add(strTmp);
            }

            List<string> result = new List<string>();
            for (int i = arrys.Count - 1; i >= 0; i--)
            {
                string[] clist = arrys[i];
                for (int j = clist.Length - 1; j >= 0; j--)
                {
                    if (j == clist.Length - 2 && i > 0)//对于第二个元素增加 L或者C的标识
                    {
                        var pointWord = tmps[i - 1].Item2;//获取标识
                        result.Add(pointWord + clist[j]);
                    }
                    else
                    {
                        result.Add(clist[j]);
                        if (clist.Length == 1 && i > 0)//说明只有一个元素 ex L44.679973,69.679973
                        {
                            result.Add(tmps[i - 1].Item2);
                        }
                    }
                }
            }
            return "M" + string.Join(" ", result);

        }
    }
}