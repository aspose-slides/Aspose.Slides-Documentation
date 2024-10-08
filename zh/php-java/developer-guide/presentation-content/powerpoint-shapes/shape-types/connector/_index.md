---
title: 连接器
type: docs
weight: 10
url: /zh/php-java/connector/
keywords: "连接形状，连接器，PowerPoint形状，PowerPoint演示文稿，Java，Aspose.Slides for PHP via Java"
description: "连接PowerPoint形状"
---

PowerPoint 连接器是一种特殊的线，它连接或链接两个形状，并在两者移动或重新定位时仍然保持附着在形状上。

连接器通常连接到*连接点*（绿色点），所有形状默认存在连接点。当光标接近时，连接点会出现。

*调整点*（橙色点）仅存在于某些连接器上，用于修改连接器的位置和形状。

## **连接器的类型**

在 PowerPoint 中，可以使用直线、肘部（角度）和曲线连接器。

Aspose.Slides 提供这些连接器：

| 连接器                          | 图像                                                          | 调整点数量                |
| ---------------------------- | ------------------------------------------------------------ | ------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                        |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                        |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                        |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                        |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                        |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                        |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                        |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                        |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                        |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                        |

## **使用连接器连接形状**

1. 创建一个 [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 使用 `Shapes` 对象公开的 `addAutoShape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)。
1. 通过定义连接器类型使用 `Shapes` 对象公开的 `addConnector` 方法添加连接器。
1. 使用连接器连接形状。
1. 调用 `reroute` 方法应用最短连接路径。
1. 保存演示文稿。

以下 PHP 代码显示了如何在两个形状（一个椭圆和一个矩形）之间添加一个连接器（一个弯曲连接器）：

```php
// 实例化一个表示 PPTX 文件的演示类
  $pres = new Presentation();
  try {
    # 访问特定幻灯片的形状集合
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # 添加一个椭圆自形状
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # 添加一个矩形自形状
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # 向幻灯片形状集合添加一个连接器形状
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # 使用连接器连接形状
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # 调用 reroute 设置形状之间的自动最短路径
    $connector->reroute();
    # 保存演示文稿
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="注意"  color="warning"   %}} 

`Connector.reroute` 方法重新规划连接器，并强制其采用形状之间可能的最短路径。为实现其目的，该方法可能会更改 `setStartShapeConnectionSiteIndex` 和 `setEndShapeConnectionSiteIndex` 点。 

{{% /alert %}} 

## **指定连接点**

如果希望连接器通过形状上的特定点链接两个形状，您必须如下指定首选连接点：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 使用 `Shapes` 对象公开的 `addAutoShape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)。
1. 通过定义连接器类型使用 `Shapes` 对象公开的 `addConnector` 方法添加连接器。
1. 使用连接器连接形状。 
1. 设置形状上的首选连接点。 
1. 保存演示文稿。

以下 PHP 代码演示了指定首选连接点的操作：

```php
  # 实例化一个表示 PPTX 文件的演示类
  $pres = new Presentation();
  try {
    # 访问特定幻灯片的形状集合
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # 添加一个椭圆自形状
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # 添加一个矩形自形状
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # 向幻灯片的形状集合添加一个连接器形状
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # 使用连接器连接形状
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # 设置椭圆形状上的首选连接点索引
    $wantedIndex = 6;
    # 检查首选索引是否小于最大位置索引计数
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # 在椭圆自形状上设置首选连接点
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # 保存演示文稿
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **调整连接器点**

您可以通过其调整点调整现有连接器。仅具有调整点的连接器才能以这种方式进行更改。请参阅**[连接器的类型](/slides/zh/php-java/connector/#types-of-connectors)**下的表格。

#### **简单案例**

考虑一个连接器在两个形状（A 和 B）之间，通过第三个形状（C）：

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

为了避免或绕过第三个形状，我们可以通过将其垂直线向左移动来调整连接器：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);
```

### **复杂案例**

要进行更复杂的调整，您必须考虑以下事项：

* 连接器的可调整点与计算和确定其位置的公式密切相关。因此，改变点的位置可能会改变连接器的形状。
* 连接器的调整点在数组中以严格的顺序定义。调整点从连接器的起点编号到终点。
* 调整点值反映连接器形状宽度/高度的百分比。
  * 形状由连接器的起点和终点乘以 1000 限制。
  * 第一个点、第二个点和第三个点分别定义从宽度、从高度和从宽度（再次以百分比计算）。
* 对于确定连接器的调整点坐标的计算，您必须考虑连接器的旋转及其反射。**注意**，在**[连接器的类型](/slides/zh/php-java/connector/#types-of-connectors)**下显示的所有连接器的旋转角度为 0。

#### **案例 1**

考虑一个连接两个文本框对象通过连接器连接的案例：

![connector-shape-complex](connector-shape-complex.png)

```php
  # 实例化一个表示 PPTX 文件的演示类
  $pres = new Presentation();
  try {
    # 获取演示文稿中的第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加将通过连接器连接在一起的形状
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("来自");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("到");
    # 添加连接器
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # 指定连接器的方向
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # 指定连接器的颜色
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 指定连接器线的厚度
    $connector->getLineFormat()->setWidth(3);
    # 使用连接器将形状连接在一起
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # 获取连接器的调整点
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**调整**

我们可以通过将相应的宽度和高度百分比分别增加 20% 和 200% 来更改连接器的调整点值：

```php
  # 更改调整点的值
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

结果：

![connector-adjusted-1](connector-adjusted-1.png)

为了定义一个模型，以便我们确定连接器的各个部分的坐标和形状，让我们创建一个形状，该形状对应于连接器在 `connector.getAdjustments().get_Item(0)` 点的水平组成部分：

```php
  # 绘制连接器的垂直组成部分
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

结果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **案例 2**

在**案例 1**中，我们使用基本原理演示了简单的连接器调整操作。在正常情况下，您必须考虑连接器的旋转及其显示（由 `connector.getRotation()`、`connector.getFrame().getFlipH()` 和 `connector.getFrame().getFlipV()` 设置）。现在我们将演示该过程。

首先，让我们在幻灯片上添加一个新的文本框对象（**到 1**）以便连接，并创建一个新的（绿色）连接器，将其连接到我们已经创建的对象。

```php
  # 创建一个新的绑定对象
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("到 1");
  # 创建一个新的连接器
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # 使用新创建的连接器连接对象
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # 获取连接器的调整点
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # 更改调整点的值
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

结果：

![connector-adjusted-3](connector-adjusted-3.png)

其次，让我们创建一个形状，该形状对应于穿过新连接器的调整点 `connector.getAdjustments().get_Item(0)` 的水平组成部分。我们将使用连接器数据中的 `connector.getRotation()`、`connector.getFrame().getFlipH()` 和 `connector.getFrame().getFlipV()` 的值，并应用流行的坐标转换公式以围绕给定点 x0 旋转：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在我们的情况下，对象的旋转角度为 90 度，连接器显示为垂直，因此这是相应的代码：

```php
  # 保存连接器的坐标
  $x = $connector->getX();
  $y = $connector->getY();
  # 在连接器出现的情况下修正连接器的坐标
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # 将调整点值作为坐标
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # 转换坐标，因为 Sin(90) = 1 和 Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # 使用第二个调整点值确定水平组成部分的宽度
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

结果：

![connector-adjusted-4](connector-adjusted-4.png)

我们演示了涉及简单调整和复杂调整点（具有旋转角度的调整点）的计算。利用获得的知识，您可以开发自己的模型（或编写代码）以获取 `GraphicsPath` 对象，甚至根据特定幻灯片坐标设置连接器的调整点值。

## **查找连接器线的角度**

1. 创建一个类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问连接器线形状。
1. 使用线宽、高度、形状框高度和形状框宽度计算角度。

以下 PHP 代码演示了计算连接器线形状角度的操作：

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```