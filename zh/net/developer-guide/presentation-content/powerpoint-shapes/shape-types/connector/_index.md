---
title: 连接器
type: docs
weight: 10
url: /zh/net/connector/
keywords: "连接形状, 连接线, PowerPoint 形状, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中连接 PowerPoint 形状"
---

PowerPoint 连接线是一种特殊的线条，用于连接或链接两个形状，并且即使在幻灯片上移动或重新定位形状时仍保持附着。

连接线通常连接到 *连接点*（绿色点），这些点默认存在于所有形状上。当光标靠近时会显示连接点。

*调整点*（橙色点）仅在某些连接线上存在，用于修改连接线的位置和形状。

## **连接线类型**

在 PowerPoint 中，您可以使用直线、弯角（折线）和曲线连接线。

Aspose.Slides 提供以下连接线：

| 连接线                        | 图片                                                             | 调整点数量 |
| ------------------------------ | --------------------------------------------------------------- | ---------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)       | 0          |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0          |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)   | 0          |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)     | 1          |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)     | 2          |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)     | 3          |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0          |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1          |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2          |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3          |

## **使用连接线连接形状**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 使用 `Shapes` 对象公开的 `AddAutoShape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)。
1. 通过 `Shapes` 对象公开的 `AddConnector` 方法并指定连接线类型来添加连接线。
1. 使用该连接线将形状连接起来。
1. 调用 `Reroute` 方法以应用最短连接路径。
1. 保存演示文稿。

以下 C# 代码演示了如何在两个形状（椭圆和矩形）之间添加一个弯折连接线：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation input = new Presentation())
{                
    // 访问特定幻灯片的形状集合
    IShapeCollection shapes = input.Slides[0].Shapes;

    // 添加一个椭圆自动形状
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 添加一个矩形自动形状
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // 向幻灯片的形状集合添加一个连接线形状
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // 使用连接线连接形状
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // 调用 Reroute 方法以在形状之间设置自动最短路径
    connector.Reroute();

    // 保存演示文稿
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.Reroute` 方法会重新路由连接线并强制其在形状之间走最短路径。为实现此目的，方法可能会更改 `StartShapeConnectionSiteIndex` 和 `EndShapeConnectionSiteIndex` 点。 
{{% /alert %}} 

## **指定连接点**

如果希望连接线使用形状上的特定点进行链接，需要按以下方式指定首选连接点：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 使用 `Shapes` 对象公开的 `AddAutoShape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)。
1. 通过 `Shapes` 对象公开的 `AddConnector` 方法并指定连接线类型来添加连接线。
1. 使用该连接线将形状连接起来。
1. 在形状上设置首选的连接点。
1. 保存演示文稿。

以下 C# 代码演示了指定首选连接点的操作：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
    // 访问特定幻灯片的形状集合
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // 向幻灯片的形状集合添加连接线形状
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // 添加椭圆自动形状
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 添加矩形自动形状
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // 使用连接线连接形状
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // 设置椭圆形状的首选连接点索引
    uint wantedIndex = 6;

    // 检查首选索引是否小于最大站点索引计数
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // 在椭圆自动形状上设置首选连接点
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // 保存演示文稿
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```


## **调整连接线点**

您可以通过调整点来修改已有的连接线。只有带有调整点的连接线才可以以此方式更改。请参阅 **[连接线类型](/slides/zh/net/connector/#types-of-connectors)** 表下的说明。

#### **简单案例**

考虑一种情况：连接两个形状（A 和 B）的连接线经过第三个形状（C）：

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


为避免或绕过第三个形状，我们可以将连接线的垂直线向左移动进行调整：

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```


### **复杂案例** 

进行更复杂的调整时，需要考虑以下因素：

* 连接线的可调点与计算其位置的公式紧密关联。因此，点位置的改变可能会影响连接线的形状。
* 连接线的调整点在数组中按严格顺序定义。调整点按从起点到终点的顺序编号。
* 调整点的数值表示连接线形状宽度/高度的百分比。  
  * 形状由连接线的起点和终点乘以 1000 限定。  
  * 第一点、第二点、第三点分别对应宽度百分比、高度百分比以及再次的宽度百分比。
* 在计算连接线调整点坐标时，需要考虑连接线的旋转和反射。**注意**，在 **[连接线类型](/slides/zh/net/connector/#types-of-connectors)** 中显示的所有连接线的旋转角度均为 0。

#### **案例 1**

考虑两个文本框对象通过连接线链接的情况：

![connector-shape-complex](connector-shape-complex.png)

代码：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
// 获取演示文稿中的第一页幻灯片
ISlide sld = pres.Slides[0];
// 添加将在连接线中连接在一起的形状
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// 添加一个连接线
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// 指定连接线的方向
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// 指定连接线的颜色
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// 指定连接线的粗细
connector.LineFormat.Width = 3;

// 使用连接线将形状链接在一起
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// 获取连接线的调整点
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```


**调整**

我们可以将连接线的调整点数值的宽度和高度百分比分别增加 20% 和 200%：

```c#
// 更改调整点的值
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


结果：

![connector-adjusted-1](connector-adjusted-1.png)

为了定义一个模型，以便我们确定连接线各部分的坐标和形状，创建一个对应于连接线在 `connector.Adjustments[0]` 点处水平分量的形状：

```c#
// 绘制连接线的垂直组件

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


结果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我们演示了使用基本原理进行简单连接线调整的操作。实际情况下，需要考虑连接线的旋转和显示方式（由 `connector.Rotation`、`connector.Frame.FlipH` 和 `connector.Frame.FlipV` 设置）。下面演示该过程。

首先，向幻灯片添加一个新的文本框对象（**To 1**）以供连接，并创建一个新的（绿色）连接线，将其连接到已创建的对象上。
```c#
// 创建一个新的绑定对象
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// 创建一个新的连接线
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// 使用新创建的连接线连接对象
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// 获取连接线的调整点
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// 更改调整点的值
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


结果：

![connector-adjusted-3](connector-adjusted-3.png)

其次，创建一个形状对应于通过新连接线的调整点 `connector.Adjustments[0]` 的水平分量。我们将使用连接线数据中的 `connector.Rotation`、`connector.Frame.FlipH`、`connector.Frame.FlipV` 值，并应用围绕给定点 x0 的旋转坐标转换公式：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在本例中，对象的旋转角度为 90 度，连接线垂直显示，代码如下：
```c#
// 保存连接线坐标
x = connector.X;
y = connector.Y;
// 在出现时校正连接线坐标
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
//  将坐标转换，因为 Sin(90) = 1 且 Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// 使用第二个调整点值确定水平分量的宽度
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```


结果：

![connector-adjusted-4](connector-adjusted-4.png)

我们演示了涉及简单调整和带旋转角度的复杂调整点的计算。掌握这些知识后，您可以创建自己的模型（或编写代码），以获取 `GraphicsPath` 对象，甚至根据特定幻灯片坐标设置连接线的调整点数值。

## **查找连接线角度**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问连接线形状。
1. 使用线条的宽度、高度、形状框的高度和宽度计算角度。

以下 C# 代码演示了计算连接线角度的操作：
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


## **常见问题**

**如何判断连接线是否可以“粘贴”到特定形状上？**

检查该形状是否公开了 [connection sites](https://reference.aspose.com/slides/net/aspose.slides/shape/connectionsitecount/)。如果没有或计数为零，则无法粘贴；此时请使用自由端点并手动定位。建议在附加前检查站点计数。

**如果删除了已连接的形状之一，连接线会怎样？**

其两端会被分离；连接线仍保留在幻灯片上，作为普通的自由起止线。您可以删除它，或重新分配连接并在需要时使用 [reroute](https://reference.aspose.com/slides/net/aspose.slides/connector/reroute/)。

**在将幻灯片复制到另一个演示文稿时，连接线的绑定会保留吗？**

通常会保留，前提是目标形状也被复制。如果幻灯片在没有连接形状的情况下插入到其他文件中，两端会变为自由端，需要重新连接。