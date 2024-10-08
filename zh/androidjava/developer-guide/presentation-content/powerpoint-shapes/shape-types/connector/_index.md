---
title: 连接器
type: docs
weight: 10
url: /androidjava/connector/
keywords: "连接形状，连接器，PowerPoint形状，PowerPoint演示文稿，Java，Aspose.Slides for Android via Java"
description: "在Java中连接PowerPoint形状"
---

PowerPoint连接器是一种特殊的线条，用于将两个形状连接或链接在一起，并且即使在移动或重新定位时，也会保持附着在形状上。

连接器通常连接到*连接点*（绿色点），默认情况下所有形状都有连接点。当光标靠近它们时，连接点会出现。

*调整点*（橙色点）仅在某些连接器上存在，用于修改连接器的位置和形状。

## **连接器类型**

在PowerPoint中，您可以使用直线、肘部（角度）和弯曲连接器。

Aspose.Slides提供这些连接器：

| 连接器                          | 图像                                                        | 调整点数量                 |
| ------------------------------ | ------------------------------------------------------------ | ------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                         |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                         |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                         |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                         |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                         |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                         |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                         |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                         |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                         |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                         |

## **使用连接器连接形状**

1. 创建一个[Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
1. 通过索引获取幻灯片的引用。
1. 使用`Shapes`对象提供的`addAutoShape`方法向幻灯片添加两个[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape)。
1. 通过定义连接器类型，使用`Shapes`对象提供的`addConnector`方法添加连接器。
1. 使用连接器连接形状。
1. 调用`reroute`方法以应用最短连接路径。
1. 保存演示文稿。

以下Java代码向您展示了如何在两个形状（一个椭圆和一个矩形）之间添加一个连接器（一个弯曲连接器）：

```Java
// 创建一个表示PPTX文件的演示文稿类实例
Presentation pres = new Presentation();
try {
    // 访问特定幻灯片的形状集合
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // 添加一个椭圆自形状
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // 添加一个矩形自形状
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // 向幻灯片形状集合添加一个连接器形状
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // 使用连接器连接形状
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // 调用reroute以设置形状之间的自动最短路径
    connector.reroute();
    
    // 保存演示文稿
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="注意"  color="warning"   %}} 

`Connector.reroute`方法重新路由连接器，并强制它在形状之间采取尽可能短的路径。为了实现其目标，该方法可能会改变`setStartShapeConnectionSiteIndex`和`setEndShapeConnectionSiteIndex`点。 

{{% /alert %}} 

## **指定连接点**

如果您希望连接器通过特定点链接两个形状，则必须以下列方式指定您首选的连接点：

1. 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
1. 通过索引获取幻灯片的引用。
1. 使用`Shapes`对象提供的`addAutoShape`方法向幻灯片添加两个[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape)。
1. 通过定义连接器类型，使用`Shapes`对象提供的`addConnector`方法添加连接器。
1. 使用连接器连接形状。
1. 在形状上设置您的首选连接点。 
1. 保存演示文稿。

此Java代码演示了指定首选连接点的操作：

```java
// 创建一个表示PPTX文件的演示文稿类实例
Presentation pres = new Presentation();
try {
    // 访问特定幻灯片的形状集合
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // 添加一个椭圆自形状
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 添加一个矩形自形状
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // 向幻灯片的形状集合添加一个连接器形状
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // 使用连接器连接形状
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // 设置椭圆形状上的首选连接点索引
    int wantedIndex = 6;

    // 检查首选索引是否小于最大接点索引计数
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // 在椭圆自形状上设置首选连接点
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // 保存演示文稿
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **调整连接器点**

您可以通过其调整点调整现有连接器。仅具有调整点的连接器可以以这种方式进行更改。请查看**[连接器类型](/slides/androidjava/connector/#types-of-connectors)**下的表格。

#### **简单案例**

考虑一种情况，一个连接器在两个形状（A和B）之间通过第三个形状（C）：

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

为了避免或绕过第三个形状，我们可以通过将其垂直线向左移动来调整连接器：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **复杂案例** 

要执行更复杂的调整，您必须考虑这些因素：

* 连接器的可调点与计算和确定其位置的公式紧密相关。因此，点位置的更改可能会改变连接器的形状。
* 连接器的调整点在数组中以严格顺序定义。调整点从连接器的起点编号到其终点。
* 调整点值反映连接器形状宽度/高度的百分比。 
  * 形状由连接器的起点和终点乘以1000限制。 
  * 第一个点、第二个点和第三个点分别定义宽度的百分比、高度的百分比和宽度的百分比（再次）。
* 在确定连接器的调整点坐标的计算中，您必须考虑连接器的旋转及其反射。 **注意**，在**[连接器类型](/slides/androidjava/connector/#types-of-connectors)**下显示的所有连接器的旋转角度为0。

#### **案例 1**

考虑一个示例，两个文本框对象通过连接器连接在一起：

![connector-shape-complex](connector-shape-complex.png)

```java
// 创建一个表示PPTX文件的演示文稿类实例
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    // 添加将通过连接器连接在一起的形状
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("从");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("到");
    // 添加连接器
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // 指定连接器的方向
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // 指定连接器的颜色
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // 指定连接器线的粗细
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

我们可以通过将相应的宽度和高度百分比增加20%和200%来更改连接器的调整点值：

```java
// 更改调整点的值
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

结果：

![connector-adjusted-1](connector-adjusted-1.png)

为了定义一个允许我们确定连接器各个部分的坐标和形状的模型，让我们创建一个形状，与connector.getAdjustments().get_Item(0)点的连接器的水平分量相对应：

```java
// 绘制连接器的垂直分量
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

结果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **案例 2**

在**案例 1**中，我们通过基本原理演示了简单的连接器调整操作。在正常情况下，您必须考虑连接器的旋转和它的显示（由connector.getRotation()、connector.getFrame().getFlipH()和connector.getFrame().getFlipV()设置）。现在我们将演示这个过程。

首先，让我们向幻灯片添加一个新的文本框对象（**到 1**），以便连接，并创建一个新的（绿色）连接器，将其连接到我们已经创建的对象。

```java
// 创建新的绑定对象
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("到 1");
// 创建新的连接器
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

其次，让我们创建一个形状，与新连接器的调整点connector.getAdjustments().get_Item(0)对应，我们将使用连接器数据中的connector.getRotation()、connector.getFrame().getFlipH()和connector.getFrame().getFlipV()的值，并应用流行的坐标转换公式进行旋转：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在我们的案例中，物体的旋转角度为90度，并且连接器是垂直显示的，因此这是对应的代码：

```java
// 保存连接器坐标
x = connector.getX();
y = connector.getY();
// 在出现情况下纠正连接器坐标
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
// 由于Sin(90) = 1且Cos(90) = 0，转换坐标
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// 使用第二个调整点值确定水平分量的宽度
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

结果：

![connector-adjusted-4](connector-adjusted-4.png)

我们演示了涉及简单调整和复杂调整点（旋转角度的调整点）的计算。利用获得的知识，您可以开发自己的模型（或编写代码）以获得`GraphicsPath`对象，甚至基于特定幻灯片坐标设置连接器的调整点值。

## **查找连接器线的角度**

1. 创建一个类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问连接器线形状。
1. 使用线宽、高度、形状框架高度和形状框架宽度计算角度。

以下Java代码演示了计算连接器线形状的角度的操作：

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