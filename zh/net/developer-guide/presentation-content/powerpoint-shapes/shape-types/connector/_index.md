---
title: 连接器
type: docs
weight: 10
url: /zh/net/connector/
keywords: "连接形状, 连接器, PowerPoint 形状, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中连接 PowerPoint 形状"
---

PowerPoint 连接器是一种特殊的线，连接或链接两个形状，并在移动或重新定位时仍然附着在形状上。 

连接器通常连接到*连接点*（绿色点），默认情况下所有形状上都有连接点。当光标靠近它们时，连接点会出现。

*调整点*（橙色点）仅存在于某些连接器上，用于修改连接器的位置和形状。

## **连接器的类型**

在 PowerPoint 中，您可以使用直线、肘形（角形）和弯曲连接器。 

Aspose.Slides 提供了以下连接器：

| 连接器                         | 图像                                                         | 调整点数量                  |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **使用连接器连接形状**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 使用 `Shapes` 对象的 `AddAutoShape` 方法向幻灯片中添加两个 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)。
1. 使用 `Shapes` 对象的 `AddConnector` 方法添加一个连接器，同时定义连接器类型。
1. 使用连接器连接形状。 
1. 调用 `Reroute` 方法以应用最短连接路径。
1. 保存演示文稿。 

以下 C# 代码展示了如何在两个形状（一个椭圆与一个矩形）之间添加一个连接器（一个弯曲的连接器）：

```c#
// 实例化表示 PPTX 文件的演示文稿类
using (Presentation input = new Presentation())
{                
    // 访问特定幻灯片的形状集合
    IShapeCollection shapes = input.Slides[0].Shapes;

    // 添加一个椭圆自定义图形
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 添加一个矩形自定义图形
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // 向幻灯片形状集合中添加连接器形状
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // 使用连接器连接形状
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // 调用 reroute 设置形状之间的自动最短路径
    connector.Reroute();

    // 保存演示文稿
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="注意"  color="warning"   %}} 

`Connector.Reroute` 方法重新路由连接器并强制它在形状之间采取尽可能短的路径。为了达到其目的，该方法可能会更改 `StartShapeConnectionSiteIndex` 和 `EndShapeConnectionSiteIndex` 点。 

{{% /alert %}} 

## **指定连接点**
如果希望连接器使用形状上的特定点连接两个形状，您必须以以下方式指定所选的连接点：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 使用 `Shapes` 对象的 `AddAutoShape` 方法向幻灯片中添加两个 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)。
1. 使用 `Shapes` 对象的 `AddConnector` 方法添加一个连接器，同时定义连接器类型。
1. 使用连接器连接形状。 
1. 在形状上设置所选的连接点。 
1. 保存演示文稿。

此 C# 代码演示了指定首选连接点的操作：

```c#
// 实例化表示 PPTX 文件的演示文稿类
using (Presentation presentation = new Presentation())
{
    // 访问特定幻灯片的形状集合
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // 向幻灯片的形状集合中添加连接器形状
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // 添加一个椭圆自定义图形
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 添加一个矩形自定义图形
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // 使用连接器连接形状
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // 在椭圆形状上设置首选的连接点索引
    uint wantedIndex = 6;

    // 检查所选的索引是否小于最大连接点索引计数
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // 在椭圆自定义图形上设置首选连接点
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // 保存演示文稿
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **调整连接器点**

您可以通过其调整点来调整现有连接器。只有具有调整点的连接器才能以这种方式更改。请参见**[连接器类型](/slides/zh/net/connector/#types-of-connectors)** 下的表格。

#### **简单案例**

考虑一个情况，其中两个形状（A 和 B）之间的连接器通过第三个形状（C）：

![connector-obstruction](connector-obstruction.png)

代码：

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

为了避免或绕过第三个形状，我们可以通过将连接器的垂直线向左移动来调整连接器：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **复杂案例** 

要执行更复杂的调整，您需要考虑以下事项：

* 连接器的可调整点与计算其位置的公式强烈相关。因此，调整点的位置可能会改变连接器的形状。
* 连接器的调整点在数组中按严格顺序定义。调整点从连接器的起点到其终点编号。
* 调整点值反映连接器形状的宽度/高度的百分比。
  * 形状由连接器的起点和终点的乘积大小乘以 1000 限定。 
  * 第一、第二和第三个点分别定义来自宽度的百分比、来自高度的百分比和来自宽度的百分比（再次）。
* 在确定连接器的调整点坐标时，您需要考虑连接器的旋转和反射。**注意**，在 **[连接器类型](/slides/zh/net/connector/#types-of-connectors)** 下显示的所有连接器的旋转角度为 0。

#### **案例 1**

考虑一个情况，其中两个文本框对象通过连接器连接在一起：

![connector-shape-complex](connector-shape-complex.png)

代码：

```c#
// 实例化表示 PPTX 文件的演示文稿类
Presentation pres = new Presentation();
// 获取演示文稿中的第一张幻灯片
ISlide sld = pres.Slides[0];
// 添加将通过连接器连接的形状
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// 添加连接器
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// 指定连接器的方向
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// 指定连接器的颜色
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// 指定连接器线条的厚度
connector.LineFormat.Width = 3;

// 使用连接器将形状连接在一起
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// 获取连接器的调整点
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**调整**

我们可以通过将连接器的调整点值分别增加 20% 和 200% 来更改连接器的调整点：

```c#
// 更改调整点的值
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

结果：

![connector-adjusted-1](connector-adjusted-1.png)

为了定义一个模型，以允许我们确定连接器各个部分的坐标和形状，让我们创建一个形状，与连接器.Adjustments[0] 点对应的连接器的水平组件：

```c#
// 绘制连接器的垂直组件

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

结果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **案例 2**

在**案例 1**中，我们演示了使用基本原则进行简单连接器调整操作。在正常情况下，您需要考虑连接器的旋转和显示（由 connector.Rotation、connector.Frame.FlipH 和 connector.Frame.FlipV 设置）。我们将现在演示该过程。

首先，添加一个新的文本框对象（**To 1**）到幻灯片（用于连接目的），并创建一个新的（绿色）连接器，将其连接到我们已经创建的对象。

```c#
// 创建新的绑定对象
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// 创建新的连接器
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// 使用新创建的连接器连接对象
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// 获取连接器的调整点
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// 更改调整点的值 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

结果：

![connector-adjusted-3](connector-adjusted-3.png)

接下来，创建一个形状，作为通过新连接器的调整点 connector.Adjustments[0] 的水平方向组成部分。我们将使用连接器数据中的值 connector.Rotation、connector.Frame.FlipH 和 connector.Frame.FlipV，并应用流行的坐标转换公式，以便绕给定点 x0 旋转：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在我们的例子中，物体的旋转角度是 90 度，连接器垂直显示，因此代码如下：

```c#
// 保存连接器坐标
x = connector.X;
y = connector.Y;
// 在连接器出现的情况下校正连接器坐标
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// 将调整点值作为坐标
x += connector.Width * adjValue_0.RawValue / 100000;
// 转换坐标，因为 Sin(90) = 1 和 Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// 使用第二个调整点值确定水平组件的宽度
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

结果：

![connector-adjusted-4](connector-adjusted-4.png)

我们演示了涉及简单调整和复杂调整点（带有旋转角度的调整点）的计算。利用所获得的知识，您可以开发自己的模型（或编写代码）以获取 `GraphicsPath` 对象，甚至根据特定幻灯片坐标设置连接器的调整点值。

## **查找连接器线的角度**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问连接器线形状。 
1. 使用线宽、高度、形状框高度和形状框宽度计算角度。

以下 C# 代码演示了我们计算连接器线形状角度的操作：

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```