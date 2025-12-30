---
title: 使用 PHP 管理演示文稿中的连接线
linktitle: 连接线
type: docs
weight: 10
url: /zh/php-java/connector/
keywords:
- 连接线
- 连接线类型
- 连接点
- 连接线
- 连接角度
- 连接形状
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "赋能 PHP 应用在 PowerPoint 幻灯片中绘制、连接并自动路由线条 —— 完全控制直线、拐角和曲线连接线。"
---

PowerPoint 连接线是一种特殊的线条，用于将两个形状连接或链接在一起，即使在幻灯片上移动或重新定位形状时也会保持附着。

连接线通常连接到 *连接点*（绿色点），这些点默认存在于所有形状上。当光标靠近时会显示连接点。

*调整点*（橙色点）仅存在于某些连接线上，用于修改连接线的位置和形状。

## **Types of Connectors**

在 PowerPoint 中，您可以使用直线、拐角（有角度）和曲线连接线。

Aspose.Slides 提供以下连接线：

| Connector | Image | Number of adjustment points |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **Connect Shapes Using Connectors**

1. 创建 [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
1. 通过索引获取幻灯片引用。  
1. 使用 `Shapes` 对象的 `addAutoShape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)。  
1. 通过定义连接线类型，使用 `Shapes` 对象的 `addConnector` 方法添加连接线。  
1. 使用该连接线将形状连接起来。  
1. 调用 `reroute` 方法以采用最短的连接路径。  
1. 保存演示文稿。  

以下 PHP 代码演示了如何在两个形状（椭圆和矩形）之间添加一个弯曲连接线：
```php
// 实例化表示 PPTX 文件的演示文稿类
  $pres = new Presentation();
  try {
    # 访问特定幻灯片的形状集合
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # 添加椭圆自动形状
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # 添加矩形自动形状
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # 向幻灯片形状集合中添加连接线形状
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # 使用连接线连接形状
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # 调用 reroute 方法，为形状之间设置自动最短路径
    $connector->reroute();
    # 保存演示文稿
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

`Connector.reroute` 方法会重新路由连接线，使其在形状之间走最短路径。为实现此目的，方法可能会更改 `setStartShapeConnectionSiteIndex` 和 `setEndShapeConnectionSiteIndex` 坐标。 

{{% /alert %}} 

## **Specify a Connection Dot**

如果希望连接线使用形状上的特定点进行链接，需要按以下方式指定首选的连接点：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
1. 通过索引获取幻灯片引用。  
1. 使用 `Shapes` 对象的 `addAutoShape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)。  
1. 通过定义连接线类型，使用 `Shapes` 对象的 `addConnector` 方法添加连接线。  
1. 使用该连接线将形状连接起来。  
1. 在形状上设置首选的连接点。  
1. 保存演示文稿。  

以下 PHP 代码演示了如何指定首选的连接点：
```php
  # 实例化表示 PPTX 文件的演示文稿类
  $pres = new Presentation();
  try {
    # 访问特定幻灯片的形状集合
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # 添加椭圆自动形状
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # 添加矩形自动形状
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # 向幻灯片的形状集合中添加连接线形状
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # 使用连接线连接形状
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # 为椭圆形状设置首选连接点索引
    $wantedIndex = 6;
    # 检查首选索引是否小于最大站点索引计数
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # 为椭圆自动形状设置首选连接点
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


## **Adjust a Connector Point**

您可以通过调整点对已有的连接线进行微调。仅带有调整点的连接线才可以这样操作。请参见 **[Types of connectors.](/slides/zh/php-java/connector/#types-of-connectors)** 表格。

### **Simple Case**

考虑一种情况：连接线在两个形状 (A 和 B) 之间经过第三个形状 (C)：

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


为了绕过第三个形状，可以将连接线的垂直线向左移动：

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```


### **Complex Cases** 

进行更复杂的调整时，需要考虑以下因素：

* 连接线的可调点与用于计算其位置的公式紧密关联，修改点的位置可能会改变连接线的形状。  
* 连接线的调整点在数组中按严格顺序定义，编号从起点到终点依次递增。  
* 调整点的数值反映了连接线形状宽度/高度的百分比。  
  * 形状的边界由连接线的起点和终点乘以 1000 确定。  
  * 第一点、第二点、第三点分别表示宽度的百分比、高度的百分比以及再次的宽度百分比。  
* 在计算连接线调整点坐标时，需要考虑连接线的旋转和翻转。**注意**，在 **[Types of connectors](/slides/zh/php-java/connector/#types-of-connectors)** 中展示的所有连接线的旋转角度均为 0。

#### **Case 1**

考虑两个文本框对象通过连接线相连的情况：

![connector-shape-complex](connector-shape-complex.png)
```php
  # 实例化表示 PPTX 文件的演示文稿类
  $pres = new Presentation();
  try {
    # 获取演示文稿中的第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加将通过连接线连接在一起的形状
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # 添加一个连接线
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # 指定连接线的方向
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # 指定连接线的颜色
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 指定连接线的粗细
    $connector->getLineFormat()->setWidth(3);
    # 使用连接线将形状链接在一起
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # 获取连接线的调整点
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


**Adjustment**

我们可以通过将对应的宽度和高度百分比分别增加 20% 和 200% 来更改连接线的调整点数值：
```php
  # 更改调整点的值
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```


结果：

![connector-adjusted-1](connector-adjusted-1.png)

为了构建一个模型以确定连接线各部分的坐标和形状，我们创建一个对应于 `connector.getAdjustments().get_Item(0)` 点的水平分量的形状：
```php
  # 绘制连接线的垂直分量
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```


结果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **Case 2**

在 **Case 1** 中，我们演示了使用基本原理进行简单的连接线调整。实际情况中，需要考虑连接线的旋转以及其显示方式（由 `connector.getRotation()`、`connector.getFrame().getFlipH()` 和 `connector.getFrame().getFlipV()` 设置）。下面演示整个过程。

首先，在幻灯片上添加一个新的文本框对象（**To 1**），用于连接，然后创建一个新的（绿色）连接线将其与已创建的对象相连。
```php
  # 创建一个新的绑定对象
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
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

接着，创建一个形状对应于通过新连接线的调整点 `connector.getAdjustments().get_Item(0)` 的水平分量。我们使用 `connector.getRotation()`、`connector.getFrame().getFlipH()`、`connector.getFrame().getFlipV()` 的数值，并应用围绕给定点 x0 旋转的坐标转换公式：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在本例中，对象的旋转角度为 90 度，且连接线垂直显示，下面是相应的代码：
```php
  # 保存连接器坐标
  $x = $connector->getX();
  $y = $connector->getY();
  # 在出现时校正连接器坐标
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # 将调整点值作为坐标
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # 转换坐标，因为 Sin(90) = 1 且 Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # 使用第二个调整点值确定水平分量的宽度
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```


结果：

![connector-adjusted-4](connector-adjusted-4.png)

我们演示了涉及简单调整和带旋转角度的复杂调整点的计算。掌握这些知识后，您可以自行构建模型（或编写代码）以获取 `GraphicsPath` 对象，甚至根据特定幻灯片坐标设置连接线的调整点数值。

## **Find the Angle of Connector Lines**

1. 创建类的实例。  
1. 通过索引获取幻灯片引用。  
1. 访问连接线形状。  
1. 使用线的宽度、高度、形状框的宽度和高度计算角度。  

以下 PHP 代码演示了如何计算连接线形状的角度：
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


## **FAQ**

**如何判断连接线是否可以“粘贴”到特定形状上？**

检查形状是否公开了 [connection sites](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getconnectionsitecount/)。如果没有或计数为零，则不支持粘贴；此时应使用自由端点并手动定位。建议在附加之前先检查站点计数。

**如果删除了已连接的形状之一，连接线会怎样？**

它的两端将被分离，连接线会以普通线的形式保留在幻灯片上，起点/终点为自由状态。您可以删除它，或重新分配连接并在需要时调用 [reroute](https://reference.aspose.com/slides/php-java/aspose.slides/connector/reroute/)。  

**复制幻灯片到另一份演示文稿时，连接线的绑定会被保留吗？**

通常会保留，前提是目标形状也被一起复制。如果在未复制连接形状的情况下插入幻灯片，连接线的两端会变为自由端，需要重新附加。