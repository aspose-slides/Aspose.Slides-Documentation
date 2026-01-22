---
title: 在 JavaScript 中向演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/nodejs-java/watermark/
keywords:
- 水印
- 文本水印
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Node.js 中管理 PowerPoint 和 OpenDocument 演示文稿的文本和图片水印，以标示草稿、机密信息、版权等。"
---

## **关于水印**

**水印** 在演示文稿中是用于单张幻灯片或所有幻灯片的文字或图片印记。通常，水印用于表示演示文稿是草稿（例如 “Draft” 水印）、包含机密信息（例如 “Confidential” 水印）、标明所属公司（例如 “Company Name” 水印）、识别演示文稿作者等。水印通过提示演示文稿不应被复制来帮助防止版权侵权。水印同时适用于 PowerPoint 和 OpenOffice 演示文稿格式。在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/) 中，您可以通过多种方式在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计和行为。共通点是要添加文字水印应使用 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 类型，要添加图片水印应使用 [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) 类或将水印形状填充为图片。`PictureFrame` 实现了 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 类型，允许您使用形状对象的所有灵活设置。由于 `TextFrame` 不是形状且其设置受限，它被包装在一个 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 对象中。

水印的应用方式有两种：对单张幻灯片或对所有幻灯片。使用 Slide Master 可将水印应用于所有幻灯片——水印被添加到 Slide Master 中，在那里完成全部设计后自动应用到所有幻灯片，而不影响对单独幻灯片上水印的修改权限。

水印通常被视为不允许其他用户编辑。为防止水印（更准确地说是水印的父形状）被编辑，Aspose.Slides 提供了形状锁定功能。特定形状可以在普通幻灯片或 Slide Master 上锁定。当水印形状在 Slide Master 上被锁定时，它将在所有演示文稿幻灯片上锁定。

您可以为水印设置名称，以便以后需要删除时能够通过名称在幻灯片的形状集合中找到它。

水印的设计方式多种多样，但通常具备居中对齐、旋转、置前等共通特征。以下示例将演示如何在代码中实现这些特性。

## **文本水印**

### **向幻灯片添加文本水印**
要在 PPT、PPTX 或 ODP 中添加文本水印，您可以先向幻灯片添加形状，然后向该形状添加文本框。文本框由 [**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 类型表示。该类型未继承自 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape)，因此缺少用于灵活定位水印的属性集合。因此，您需要将 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 对象包装在一个 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 对象中。向形状添加水印文本时，请使用 [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) 方法并将水印文本作为参数传入：
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="另请参阅" %}} 
- 如何使用 [TextFrame](/slides/zh/nodejs-java/text-formatting/)。
{{% /alert %}}

### **向演示文稿添加文本水印**

如果希望一次性向整个演示文稿（即所有幻灯片）添加文本水印，请将其添加到 [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide)。其余逻辑与向单张幻灯片添加水印相同——创建一个 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 对象，然后使用 [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) 方法将水印添加进去：
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="另请参阅" %}} 
- [如何使用 ](/slides/zh/nodejs-java/slide-master/)[Slide Master](/slides/zh/nodejs-java/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状带有填充色和线条颜色。以下代码将形状设为透明。
```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```


### **设置文本水印的字体**

您可以按下面示例更改文本水印的字体。
```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```


### **设置水印文字颜色**

使用以下代码设置水印文字的颜色：
```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```


### **居中文本水印**
可以将水印居中放置在幻灯片上，代码如下：
```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


下图展示了最终效果。

![文本水印](text_watermark.png)

## **图片水印**

### **向演示文稿添加图片水印**

要向所有幻灯片添加图片水印，可按以下方式操作：
```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```


### **锁定水印防止编辑**

若需要防止水印被编辑，可对该形状使用 [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--) 方法。通过此属性，您可以保护形状不被选中、调整大小、重新定位、与其他元素分组、锁定其文字编辑等：
```javascript
// 锁定水印形状以防修改
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


### **将水印置于前面**

在 Aspose.Slides 中，可通过 [**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) 方法设置形状的 Z 顺序。调用该方法时，需要从演示文稿的幻灯片列表中传入形状引用及其顺序号，从而实现将形状置前或置后的操作。当需要将水印放置在演示文稿的前面时，此功能尤为实用：
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **设置水印旋转角度**

以下代码示例演示如何调整水印的旋转，使其以对角线方式跨越幻灯片：
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **为水印设置名称**

Aspose.Slides 允许您为形状设置名称。使用形状名称，您以后可以通过名称访问并修改或删除该形状。要为水印形状设置名称，请调用 [**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) 方法：
```javascript
watermarkShape.setName("watermark");
```


### **删除水印**

要删除水印形状，请使用 [AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) 方法在幻灯片形状集合中找到它。然后将该形状传入 [**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) 方法即可：
```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **常见问题**

**什么是水印，为什么要使用？**

水印是叠加在幻灯片上的文字或图片，用于保护知识产权、提升品牌识别度或防止演示文稿被未经授权使用。

**我能为演示文稿的所有幻灯片添加水印吗？**

可以，Aspose.Slides 允许您向演示文稿的每一张幻灯片添加水印，您可以遍历所有幻灯片并逐个应用水印设置。

**如何调整水印的透明度？**

您可以通过修改形状的 [填充设置](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) 来调整水印的透明度，从而使水印保持低调且不干扰幻灯片内容。

**支持哪些图片格式作为水印？**

Aspose.Slides 支持多种图片格式，例如 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自定义文本水印的字体和样式吗？**

可以，您可以选择任意字体、大小和样式，以匹配演示文稿的设计并保持品牌一致性。

**如何更改水印的位置或方向？**

您可以通过修改形状的坐标、尺寸和旋转属性来调整水印的位置和方向。