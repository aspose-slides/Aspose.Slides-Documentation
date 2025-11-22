---
title: 连接器
type: docs
weight: 10
url: /zh/nodejs-java/connector/
keywords: "连接形状, 连接线, PowerPoint 形状, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "在 JavaScript 中连接 PowerPoint 形状"
---

PowerPoint 连接线是一种特殊的线条，可将两个形状连接或链接在一起，并且即使在幻灯片上移动或重新定位形状时仍保持附着。

连接线通常连接到 *连接点*（绿色点），该点默认存在于所有形状上。当光标靠近时，连接点会出现。

*调整点*（橙色点），仅在某些连接线上存在，用于修改连接线的位置和形状。

## **连接线类型**

在 PowerPoint 中，您可以使用直线、肘部（折角）和曲线连接线。

Aspose.Slides 提供以下连接线：

| 连接线                       | 图像                                                        | 调整点数量 |
| ---------------------------- | ----------------------------------------------------------- | ---------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0          |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0          |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0          |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1          |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2          |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3          |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0          |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1          |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2          |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3          |

## **使用连接线连接形状**

1. 创建一个 [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 使用 `Shapes` 对象提供的 `addAutoShape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。  
4. 通过定义连接线类型，使用 `Shapes` 对象提供的 `addConnector` 方法添加连接线。  
5. 使用该连接线连接形状。  
6. 调用 `reroute` 方法以应用最短的连接路径。  
7. 保存演示文稿。  

以下 JavaScript 代码演示了如何在两个形状（椭圆和矩形）之间添加连接线（弯曲连接线）：

```javascript
// 实例化表示 PPTX 文件的演示文稿类
var pres = new aspose.slides.Presentation();
try {
    // 访问特定幻灯片的形状集合
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // 添加椭圆自动形状
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // 添加矩形自动形状
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // 向幻灯片形状集合添加连接线形状
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // 使用连接线连接形状
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // 调用 reroute 方法设置形状之间的自动最短路径
    connector.reroute();
    // 保存演示文稿
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` 方法会重新路由连接线，使其在形状之间走最短路径。为实现此目的，方法可能会更改 `setStartShapeConnectionSiteIndex` 和 `setEndShapeConnectionSiteIndex` 点。  
{{% /alert %}} 

## **指定连接点**

如果希望连接线使用形状上的特定点链接两个形状，需要按以下方式指定首选的连接点：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 使用 `Shapes` 对象提供的 `addAutoShape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。  
4. 通过定义连接线类型，使用 `Shapes` 对象提供的 `addConnector` 方法添加连接线。  
5. 使用该连接线连接形状。  
6. 在形状上设置您首选的连接点。  
7. 保存演示文稿。  

以下 JavaScript 代码演示了指定首选连接点的操作：

```javascript
// 实例化表示 PPTX 文件的演示文稿类
var pres = new aspose.slides.Presentation();
try {
    // 访问特定幻灯片的形状集合
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // 添加椭圆自动形状
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // 添加矩形自动形状
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // 向幻灯片的形状集合添加连接线形状
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // 使用连接线连接形状
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // 设置椭圆形状的首选连接点索引
    var wantedIndex = 6;
    // 检查首选索引是否小于最大站点计数
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // 在椭圆自动形状上设置首选连接点
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // 保存演示文稿
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **调整连接线点**

您可以通过其调整点来修改现有连接线。仅具有调整点的连接线可以以此方式进行修改。请参阅 **[连接线类型](/slides/zh/nodejs-java/connector/#types-of-connectors)** 表。

### **简单案例**

考虑一种情况：两个形状（A 和 B）之间的连接线经过第三个形状（C）：

![connector-obstruction](connector-obstruction.png)
```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


为了避免或绕过第三个形状，我们可以通过将其垂直线向左移动来调整连接线：

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **复杂案例** 

要进行更复杂的调整，需要考虑以下因素：

* 连接线的可调点与计算并确定其位置的公式紧密关联。因此，点位置的更改可能会改变连接线的形状。  
* 连接线的调整点在数组中按严格顺序定义。调整点的编号从连接线的起点到终点。  
* 调整点值反映连接线形状宽度/高度的百分比。  
  * 该形状由连接线的起点和终点乘以 1000 所界定。  
  * 第一点、第二点和第三点分别定义宽度的百分比、高度的百分比以及再次的宽度百分比。  
* 在计算决定连接线调整点坐标时，需要考虑连接线的旋转和镜像。**注意**，在 **[连接线类型](/slides/zh/nodejs-java/connector/#types-of-connectors)** 中显示的所有连接线的旋转角度均为 0。  

#### **案例 1**

考虑一种情况：两个文本框对象通过连接线相连：

![connector-shape-complex](connector-shape-complex.png)
```javascript
// 实例化表示 PPTX 文件的演示文稿类
var pres = new aspose.slides.Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加将通过连接器连接在一起的形状
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // 添加一个连接器
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // 指定连接器的方向
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // 指定连接器的颜色
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // 指定连接器线条的粗细
    connector.getLineFormat().setWidth(3);
    // 使用连接器将形状链接在一起
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // 获取连接器的调整点
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**调整**

我们可以通过分别将相应的宽度和高度百分比增加 20% 和 200% 来更改连接线的调整点值：

```javascript
// 更改调整点的值
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


结果如下：

![connector-adjusted-1](connector-adjusted-1.png)

为了定义一个模型，以便我们确定连接线各部分的坐标和形状，让我们创建一个对应于 `connector.getAdjustments().get_Item(0)` 点的水平分量的形状：

```javascript
// 绘制连接器的垂直分量
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```


结果如下：

![connector-adjusted-2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我们使用基本原理演示了简单的连接线调整操作。在常规情况下，需要考虑连接线的旋转及其显示（由 `connector.getRotation()`、`connector.getFrame().getFlipH()` 和 `connector.getFrame().getFlipV()` 设置）。接下来我们将演示该过程。

首先，向幻灯片添加一个新的文本框对象（**To 1**）（用于连接），并创建一个新的（绿色）连接线，将其连接到我们已经创建的对象。

```javascript
// 创建一个新的绑定对象
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// 创建一个新的连接器
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
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


结果如下：

![connector-adjusted-3](connector-adjusted-3.png)

其次，创建一个形状，对应于穿过新连接线的调整点 `connector.getAdjustments().get_Item(0)` 的水平分量。我们将使用 `connector.getRotation()`、`connector.getFrame().getFlipH()` 和 `connector.getFrame().getFlipV()` 的数值，并应用围绕给定点 x0 的常用坐标转换公式：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在我们的案例中，对象的旋转角度为 90 度，且连接线垂直显示，因此对应的代码如下：

```javascript
// 保存连接器坐标
x = connector.getX();
y = connector.getY();
// 在出现时纠正连接器坐标
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// 将调整点值作为坐标
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// 转换坐标，因为 Sin(90)=1 且 Cos(90)=0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// 使用第二个调整点的值确定水平分量的宽度
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


结果如下：

![connector-adjusted-4](connector-adjusted-4.png)

我们演示了涉及简单调整和带有旋转角度的复杂调整点的计算。利用所学知识，您可以构建自己的模型（或编写代码）以获取 `GraphicsPath` 对象，甚至根据特定幻灯片坐标设置连接线的调整点值。

## **查找连接线角度**

1. 创建该类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 访问连接线形状。  
4. 使用线宽、高度、形状框高度和形状框宽度来计算角度。  

以下 JavaScript 代码演示了计算连接线形状角度的操作：

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```


## **常见问题**

**如何判断连接线是否可以“粘贴”到特定形状上？**  
检查形状是否公开了 [connection sites](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getconnectionsitecount/)。如果没有或计数为零，则无法粘贴；此时请使用自由端点并手动定位。在附加之前检查站点计数是明智的做法。

**如果删除已连接的形状之一，会发生什么情况？**  
它的两端将被分离；连接线仍保留在幻灯片上，作为一条普通的自由起止线。您可以删除它，或重新分配连接，并在需要时使用 [reroute](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/reroute/)。

**将幻灯片复制到另一个演示文稿时，连接线的绑定会被保留吗？**  
通常会保留，前提是目标形状也被复制。如果将幻灯片插入到没有连接形状的文件中，连接线的两端会变为自由端，需要重新附加。