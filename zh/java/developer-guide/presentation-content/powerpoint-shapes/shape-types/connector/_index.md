---
title: 连接器
type: docs
weight: 10
url: /zh/java/connector/
keywords: "连接形状，连接器，PowerPoint 形状，PowerPoint 演示文稿，Java，Aspose.Slides for Java"
description: "在 Java 中连接 PowerPoint 形状"
---

PowerPoint 连接器是一种特殊的线，它将两个形状连接或链接在一起，并在形状在给定幻灯片上移动或重新定位时保持与形状的附着。

连接器通常与 *连接点*（绿色点）相连，这些点在所有形状上默认存在。当光标靠近它们时，连接点会出现。

*调整点*（橙色点）仅在某些连接器上存在，用于修改连接器的位置和形状。

## **连接器的类型**

在 PowerPoint 中，您可以使用直线、L型（角度）和弯曲连接器。

Aspose.Slides 提供以下连接器：

| 连接器                        | 图片                                                        | 调整点数量 |
| ------------------------------ | ------------------------------------------------------------ | ----------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3           |

## **使用连接器连接形状**

1. 创建一个 `Presentation` 类的实例。
1. 通过索引获取幻灯片的引用。
1. 使用 `Shapes` 对象提供的 `addAutoShape` 方法向幻灯片添加两个 `AutoShape`。
1. 通过定义连接器类型使用 `Shapes` 对象提供的 `addConnector` 方法添加连接器。
1. 使用连接器连接形状。
1. 调用 `reroute` 方法以应用最短连接路径。
1. 保存演示文稿。

以下 Java 代码演示了如何在两个形状（椭圆和矩形）之间添加连接器（弯曲连接器）：

```Java
// 实例化表示 PPTX 文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 访问特定幻灯片的形状集合
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // 添加一个椭圆自动形状
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // 添加一个矩形自动形状
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // 向幻灯片形状集合添加一个连接器形状
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // 使用连接器连接形状
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // 调用 reroute 设置形状之间的自动最短路径
    connector.reroute();
    
    // 保存演示文稿
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="注意"  color="warning"   %}} 

`Connector.reroute` 方法重新路由连接器，并强制其在形状之间选择最短的可能路径。为实现其目标，该方法可能会更改 `setStartShapeConnectionSiteIndex` 和 `setEndShapeConnectionSiteIndex` 点。 

{{% /alert %}} 

## **指定连接点**

如果您希望连接器使用形状上的特定点连接两个形状，您必须以这种方式指定所需的连接点：

1. 创建一个 `Presentation` 类的实例。
1. 通过索引获取幻灯片的引用。
1. 使用 `Shapes` 对象提供的 `addAutoShape` 方法向幻灯片添加两个 `AutoShape`。
1. 通过定义连接器类型使用 `Shapes` 对象提供的 `addConnector` 方法添加连接器。
1. 使用连接器连接形状。
1. 在形状上设置您首选的连接点。 
1. 保存演示文稿。

以下 Java 代码演示了指定所需连接点的操作：

```java
// 实例化表示 PPTX 文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 访问特定幻灯片的形状集合
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // 添加一个椭圆自动形状
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 添加一个矩形自动形状
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // 向幻灯片的形状集合添加一个连接器形状
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // 使用连接器连接形状
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // 设置椭圆形状上的首选连接点索引
    int wantedIndex = 6;

    // 检查首选索引是否小于最大站点索引数量
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // 在椭圆自动形状上设置首选连接点
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // 保存演示文稿
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **调整连接器点**

您可以通过其调整点调整现有连接器。只有具有调整点的连接器才能以这种方式更改。请参阅 **[连接器类型](/slides/zh/java/connector/#types-of-connectors)** 下的表格。

#### **简单情况**

考虑两个形状（A 和 B）之间的连接器穿过第三个形状（C）：

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

为了避免或绕过第三个形状，我们可以通过将其垂直线向左移动来调整连接器，如下所示：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **复杂情况** 

要执行更复杂的调整，您必须考虑这些内容：

* 连接器的可调整点与计算并确定其位置的公式密切相关。因此，对点位置的更改可能会改变连接器的形状。
* 连接器的调整点在数组中以严格的顺序定义。调整点从连接器的起点编号到终点。
* 调整点的值反映了连接器形状宽度/高度的百分比。 
  * 该形状由连接器的起点和终点乘以 1000 限定。 
  * 第一、第二和第三个点分别定义宽度百分比、高度百分比和宽度百分比（再一次）。
* 在计算连接器调整点的坐标时，您必须考虑连接器的旋转及其反射。 **注意**，在 **[连接器类型](/slides/zh/java/connector/#types-of-connectors)** 下显示的所有连接器的旋转角度为 0。

#### **情况 1**

考虑两个文本框对象通过连接器连接在一起的情况：

![connector-shape-complex](connector-shape-complex.png)

```java
// 实例化表示 PPTX 文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    // 添加通过连接器连接在一起的形状
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // 添加连接器
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // 指定连接器的方向
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // 指定连接器的颜色
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // 指定连接器线的厚度
    connector.getLineFormat().setWidth(3);
    
    // 使用连接器将形状连接在一起
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // 获取连接器的调整点
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**调整**

我们可以通过将相应的宽度和高度百分比分别增加 20% 和 200% 来更改连接器的调整点值：

```java
// 更改调整点的值
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

结果：

![connector-adjusted-1](connector-adjusted-1.png)

为了定义一个模型，使我们能够确定连接器各个部分的位置和形状，让我们创建一个形状，对应于连接器的水平组件，位于 connector.getAdjustments().get_Item(0) 点：

```java
// 绘制连接器的垂直部分
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

结果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **情况 2**

在 **情况 1** 中，我们演示了使用基本原则进行简单的连接器调整操作。在正常情况下，您必须考虑连接器的旋转和显示（通过 connector.getRotation()、connector.getFrame().getFlipH() 和 connector.getFrame().getFlipV() 设置）。我们现在将演示此过程。

首先，让我们为幻灯片添加一个新的文本框对象（**To 1**），以连接目的，并创建一个新的（绿色）连接器，将其与我们已创建的对象连接。

```java
// 创建一个新的绑定对象
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// 创建一个新的连接器
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// 使用新创建的连接器连接对象
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// 获取连接器的调整点
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// 更改调整点的值
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

结果：

![connector-adjusted-3](connector-adjusted-3.png)

其次，让我们创建一个形状，对应于通过新连接器的调整点 connector.getAdjustments().get_Item(0) 的水平组件。我们将使用连接器数据中的连接器的 connector.getRotation()、connector.getFrame().getFlipH() 和 connector.getFrame().getFlipV() 的值，并应用流行的坐标转换公式来围绕给定点 x0 进行旋转：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在我们的例子中，物体的旋转角度为 90 度，且连接器以垂直方式显示，因此这是相应的代码：

```java
// 保存连接器坐标
x = connector.getX();
y = connector.getY();
// 在出现时校正连接器坐标
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// 使用调整点值作为坐标
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
// 由于 Sin(90) = 1 和 Cos(90) = 0，因此转换坐标
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// 使用第二个调整点值确定水平组件的宽度
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

结果：

![connector-adjusted-4](connector-adjusted-4.png)

我们演示了涉及简单调整和复杂调整点（具有旋转角度的调整点）的计算。利用所获得的知识，您可以开发自己的模型（或编写代码），以获取 `GraphicsPath` 对象，甚至根据特定幻灯片坐标设置连接器的调整点值。

## **查找连接器线的角度**

1. 创建一个类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问连接器线形状。
1. 使用线宽、高度、形状框高度和形状框宽度计算角度。

以下 Java 代码演示了我们计算连接器线形状角度的操作：

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```