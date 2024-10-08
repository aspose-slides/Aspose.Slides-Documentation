---
title: 水印
type: docs
weight: 40
url: /php-java/watermark/
keywords:
- 水印
- 添加水印
- 文字水印
- 图片水印
- PowerPoint
- 演示文稿
- PHP
- Java
- Aspose.Slides for PHP via Java
description: "在 PHP 中向 PowerPoint 演示文稿添加文字和图片水印"
---

## **关于水印**

**水印**是在演示文稿中用于幻灯片或整个演示文稿幻灯片上的文本或图像印记。通常，水印用于表示演示文稿是草稿（例如，“草稿”水印）、包含机密信息（例如，“机密”水印）、指定其所属公司（例如，“公司名称”水印）、识别演示文稿作者等。水印通过指示演示文稿不应被复制来帮助防止版权侵犯。水印在 PowerPoint 和 OpenOffice 演示文稿格式中均可使用。在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) 中，您可以通过多种方式在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计和行为。共同点是，要添加文本水印，您应使用 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 类，而要添加图像水印，则应使用 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 类或用图像填充水印形状。`PictureFrame` 实现了 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类，使您可以使用形状对象的所有灵活设置。由于 `ITextFrame` 不是形状，其设置有限，因此它被包裹在 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 对象中。

水印可以应用于两种方式：单个幻灯片或所有演示文稿幻灯片。幻灯片母版用于将水印应用于所有演示文稿幻灯片——水印被添加到幻灯片母版中，在那里完全设计，并应用于所有幻灯片，而不影响单独幻灯片上修改水印的权限。

水印通常被认为不允许其他用户编辑。为了防止水印（或者说水印的父形状）被编辑，Aspose.Slides 提供了形状锁定功能。可以在普通幻灯片或幻灯片母版上锁定特定形状。当水印形状在幻灯片母版上被锁定时，它将在所有演示文稿幻灯片上被锁定。

您可以为水印设置名称，以便将来如果您想删除它，可以通过名称在幻灯片的形状中找到它。

您可以以任何方式设计水印；但是，水印中通常会有共同的特征，例如居中对齐、旋转、前置等。我们将在下面的示例中考虑如何使用这些特征。

## **文本水印**

### **向幻灯片添加文本水印**

要在 PPT、PPTX 或 ODP 中添加文本水印，您可以首先向幻灯片添加一个形状，然后将文本框添加到该形状中。文本框由 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 类表示。该类型不继承自 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)，而 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 具有广泛的属性集，用于灵活地定位水印。因此，[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 对象被包裹在 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 对象中。要将水印文本添加到形状中，请使用如下所示的 [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) 方法。

```php
$watermarkText = "机密";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="另请参阅" %}} 
- [如何使用 TextFrame 类](/slides/php-java/text-formatting/)
{{% /alert %}}

### **向演示文稿添加文本水印**

如果您想将文本水印添加到整个演示文稿（即一次性添加到所有幻灯片），请将其添加到 [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)。其余逻辑与向单个幻灯片添加水印时相同——创建一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 对象，然后使用 [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) 方法将水印添加到其中。

```php
$watermarkText = "机密";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="另请参阅" %}} 
- [如何使用幻灯片母版](/slides/php-java/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状带有填充和线条颜色。以下代码行使形状透明。

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **为文本水印设置字体**

您可以如下所示更改文本水印的字体。

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **设置水印文本颜色**

要设置水印文本的颜色，可以使用以下代码：

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **居中对齐文本水印**

可以将水印居中对齐到幻灯片，为此，您可以执行如下操作：

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

下图显示了最终效果。

![文本水印](text_watermark.png)

## **图片水印**

### **向演示文稿添加图片水印**

要向演示文稿幻灯片添加图片水印，您可以执行如下操作：

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

## **锁定水印以防编辑**

如果需要防止水印被编辑，请对形状使用 [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) 方法。通过此属性，您可以保护形状不被选中、调整大小、重新定位、与其他元素分组、锁定其文本以防编辑等：

```php
// 锁定水印形状以防修改
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

## **将水印置于最前**

在 Aspose.Slides 中，形状的 Z 顺序可以通过 [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder) 方法设置。为此，您需要从演示文稿幻灯片列表中调用此方法，并将形状引用及其顺序号传递给该方法。这样，可以将形状移到最前面或送到幻灯片的后面。此功能在您需要将水印放在演示文稿前面时尤其有用：

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

## **设置水印旋转**

以下是如何调整水印旋转以使其斜跨幻灯片的代码示例：

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

## **为水印设置名称**

Aspose.Slides 允许您设置形状名称。通过使用形状名称，您可以在将来访问它以进行修改或删除。要设置水印形状的名称，请将其分配给 [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName) 方法：

```php
$watermarkShape->setName("水印");
```

## **移除水印**

要移除水印形状，请使用 [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) 方法在幻灯片形状中找到它。然后，将水印形状传递给 [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove) 方法：

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "水印") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **实时示例**

您可能想查看 **Aspose.Slides 免费** [添加水印](https://products.aspose.app/slides/watermark) 和 [移除水印](https://products.aspose.app/slides/watermark/remove-watermark) 在线工具。

![在线工具以添加和移除水印](online_tools.png)