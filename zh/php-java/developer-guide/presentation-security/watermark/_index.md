---
title: 在 PHP 中向演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/php-java/watermark/
keywords:
- 水印
- 文字水印
- 图片水印
- 添加水印
- 更改水印
- 移除水印
- 删除水印
- 向 PPT 添加水印
- 向 PPTX 添加水印
- 向 ODP 添加水印
- 从 PPT 移除水印
- 从 PPTX 移除水印
- 从 ODP 移除水印
- 从 PPT 删除水印
- 从 PPTX 删除水印
- 从 ODP 删除水印
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中管理 PowerPoint 和 OpenDocument 演示文稿的文字和图片水印，以标示草稿、机密信息、版权等内容。"
---

## **关于水印**

**水印** 是在幻灯片或整个演示文稿中使用的文字或图片标记。通常，水印用于指示演示文稿是草稿（例如 “Draft” 水印）、包含机密信息（例如 “Confidential” 水印）、所属公司（例如 “Company Name” 水印）、标识作者等。水印通过表明演示文稿不应被复制来帮助防止版权侵权。水印既适用于 PowerPoint 也适用于 OpenOffice 演示文稿格式。 在 Aspose.Slides 中，你可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/php-java/)，创建 PowerPoint 或 OpenOffice 文档的水印并修改其设计和行为有多种方式。 通用的做法是：添加文字水印时使用 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 类，添加图片水印时使用 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 类或将图片填充到水印形状中。`PictureFrame` 实现了 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类，因而可以使用形状对象的所有灵活设置。由于 `ITextFrame` 不是形状且设置受限，它被包装为一个 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 对象。

水印的应用方式有两种：对单个幻灯片或对所有幻灯片。 使用幻灯片母版（Slide Master）可以对所有幻灯片应用水印——水印添加到幻灯片母版，在母版上完成全部设计并自动应用到所有幻灯片，同时不影响对单个幻灯片上水印的修改权限。

水印通常被视为不允许其他用户编辑。 为防止水印（或更准确地说其父形状）被编辑，Aspose.Slides 提供了形状锁定功能。 可以在普通幻灯片或幻灯片母版上锁定特定形状。 当水印形状在幻灯片母版上被锁定时，它将在所有幻灯片上保持锁定。

你可以为水印设置名称，这样将来需要删除时可以通过名称在幻灯片的形状集合中找到它。

水印的设计方式多种多样，但通常具有居中对齐、旋转、前置等共性特征。 以下示例将展示如何实现这些效果。

## **文字水印**

### **向幻灯片添加文字水印**

要在 PPT、PPTX 或 ODP 中添加文字水印，首先向幻灯片添加一个形状，然后在该形状中添加文字框。文字框由 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 类表示。该类型未继承自 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)，后者拥有丰富的属性用于灵活定位水印。因此，[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 对象被包装在一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 对象中。使用以下方式的 [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) 方法即可向形状添加水印文字。
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="另请参阅" %}} 
- [如何使用 TextFrame 类](/slides/zh/php-java/text-formatting/)
{{% /alert %}}

### **向整个演示文稿添加文字水印**

如果想一次性为整个演示文稿（即所有幻灯片）添加文字水印，请将其添加到 [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)。 其余逻辑与向单个幻灯片添加水印相同——创建一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 对象，然后使用 [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) 方法将水印添加进去。
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="另请参阅" %}} 
- [如何使用幻灯片母版](/slides/zh/php-java/slide-master/)
{{% /alert %}}

### **设置水印形状的透明度**

默认情况下，矩形形状带有填充和线条颜色。 以下代码行将形状设为透明。
```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```


### **为文字水印设置字体**

可以按以下方式更改文字水印的字体。
```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```


### **设置水印文字颜色**

要设置水印文字的颜色，使用如下代码：
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


### **居中文本水印**

可以将水印居中显示，示例代码如下：
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


下图展示了最终效果。

![The text watermark](text_watermark.png)

## **图片水印**

### **向演示文稿添加图片水印**

向演示文稿幻灯片添加图片水印，可按如下步骤操作：
```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```


### **锁定水印防止编辑**

如果需要防止水印被编辑，可对形状使用 [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) 方法。 通过该属性可以阻止形状被选中、调整大小、重新定位、与其他元素组合、锁定其文字编辑等操作：
```php
// 锁定水印形状以防止修改
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```


### **将水印置于最前层**

在 Aspose.Slides 中，可以通过 [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder) 方法设置形状的 Z 顺序。 需要在演示文稿的幻灯片列表上调用该方法，并将形状引用及其顺序号传入，从而实现将形状置于前层或后层。 该功能在需要将水印放在演示文稿前面时特别有用：
```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```


### **设置水印旋转角度**

以下代码示例演示如何调整水印的旋转，使其以对角线方式跨越幻灯片：
```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```


### **为水印设置名称**

Aspose.Slides 允许为形状设置名称。 使用形状名称可以在将来访问、修改或删除该形状。 为水印形状设置名称，可调用 [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName) 方法：
```php
$watermarkShape->setName("watermark");
```


### **删除水印**

要删除水印形状，先使用 [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) 方法在幻灯片形状集合中找到它，然后将该形状传入 [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove) 方法：
```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```


## **常见问题**

**什么是水印，为什么要使用它？**

水印是在幻灯片上覆盖的文字或图片，用于保护知识产权、提升品牌识别度或防止演示文稿被未经授权使用。

**我可以为演示文稿的所有幻灯片添加水印吗？**

可以，Aspose.Slides 允许通过编程方式为演示文稿的每一张幻灯片添加水印。 你可以遍历所有幻灯片并分别应用水印设置。

**如何调整水印的透明度？**

可以通过修改形状的填充设置（[getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getfillformat/)）来调整水印的透明度，从而使水印保持柔和，不干扰幻灯片内容。

**支持哪些图片格式作为水印？**

Aspose.Slides 支持多种图片格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自定义文字水印的字体和样式吗？**

可以，你可以选择任意字体、字号和样式，以匹配演示文稿的设计并保持品牌一致性。

**如何更改水印的位置或方向？**

可以通过编程方式修改形状的坐标、尺寸和旋转属性来调整水印的位置和方向。