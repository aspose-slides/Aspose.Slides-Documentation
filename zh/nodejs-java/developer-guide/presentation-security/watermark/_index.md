---
title: 水印
type: docs
weight: 40
url: /zh/nodejs-java/watermark/
keywords: "演示文稿中的水印"
description: "使用 Aspose.Slides 在 PowerPoint 中使用水印。向 PPT 演示文稿添加水印或删除水印。插入图片水印或文字水印。"
---

## **关于水印**

**水印** 在演示文稿中是用于幻灯片或整个演示文稿的文字或图像印记。通常，水印用于表明演示文稿是草稿（例如 “Draft” 水印）、包含机密信息（例如 “Confidential” 水印）、指定所属公司（例如 “Company Name” 水印）、标识演示文稿作者等。水印通过指示演示文稿不应被复制来帮助防止版权侵权。水印可用于 PowerPoint 和 OpenOffice 演示文稿格式。在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在[**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/)，有多种方式可以在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计和行为。共同点是，要添加文字水印，应使用[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)类型；要添加图片水印，则使用[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)类或用图像填充水印形状。`PictureFrame` 实现了[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)类型，允许您使用形状对象的所有灵活设置。由于 `TextFrame` 不是形状且其设置受限，它被包装成一个[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)对象。

水印的应用方式有两种：对单个幻灯片或对所有演示文稿幻灯片。使用幻灯片母版（Slide Master）可将水印应用到所有幻灯片——水印被添加到幻灯片母版，在母版中完整设计后，应用到所有幻灯片且不影响单独幻灯片上对水印的修改权限。

水印通常被视为不允许其他用户编辑。为防止水印（或更确切地说其父形状）被编辑，Aspose.Slides 提供了形状锁定功能。特定形状可以在普通幻灯片或幻灯片母版上锁定。当水印形状在幻灯片母版上被锁定时，它将在所有演示文稿幻灯片上被锁定。

您可以为水印设置名称，以便将来想要删除时能够通过名称在幻灯片的形状集合中找到它。

您可以以任何方式设计水印；不过，水印通常具备一些共同特征，如居中对齐、旋转、前置等。下面的示例将展示如何使用这些特性。

## **文字水印**

### **向幻灯片添加文字水印**
要在 PPT、PPTX 或 ODP 中添加文字水印，您可以先向幻灯片添加形状，然后向该形状添加文字框。文字框由[**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame)类型表示。该类型未继承自[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape)，后者拥有用于灵活定位水印的丰富属性。因此，[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame)对象被包装在[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)对象中。要向形状添加水印文字，请使用[**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-)方法并将水印文字作为参数传入：
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="See also" %}} 
- [如何使用](/slides/zh/nodejs-java/slide-master/)[TextFrame](/slides/zh/nodejs-java/adding-and-formatting-text/)
{{% /alert %}}

### **向演示文稿添加文字水印**

如果要向整个演示文稿（即一次性对所有幻灯片）添加文字水印，请将其添加到[**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide)。其余逻辑与向单个幻灯片添加水印相同——创建一个[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)对象，然后使用[**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-)方法将水印添加到该对象：
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="See also" %}} 
- [如何使用](/slides/zh/nodejs-java/slide-master/)[Slide Master](/slides/zh/nodejs-java/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状会带有填充和线条颜色。以下代码行使形状透明：
```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```


### **设置文字水印的字体**

您可以如下面所示更改文字水印的字体：
```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```


### **设置水印文字颜色**

要设置水印文字的颜色，请使用以下代码：
```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```


### **居中文字水印**
可以将水印居中于幻灯片，操作如下：
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

![The text watermark](text_watermark.png)

## **图片水印**

### **向演示文稿添加图片水印**

要向所有演示文稿幻灯片添加图片水印，可执行以下操作：
```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```


### **锁定水印防止编辑**

如果需要防止水印被编辑，请对形状使用[**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--)方法。通过此属性，您可以保护形状不被选中、调整大小、重新定位、与其他元素组合、锁定其文字编辑等：
```javascript
// 锁定水印形状，防止修改
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


{{% alert color="primary" title="See also" %}} 
- [如何锁定形状防止编辑](/slides/zh/nodejs-java/presentation-locking/)
{{% /alert %}}

### **将水印置前**

在 Aspose.Slides 中，可通过[**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-)方法设置形状的 Z 顺序。要做到这一点，需要从演示文稿的幻灯片列表调用此方法，并将形状引用及其顺序号传入。这样即可将形状置前或置后。该功能在需要将水印放置在演示文稿前面时特别有用：
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **设置水印旋转角度**

以下代码示例演示如何调整水印的旋转，使其在幻灯片上呈对角线位置：
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **为水印设置名称**

Aspose.Slides 允许您为形状设置名称。使用形状名称，您可以在将来访问该形状以进行修改或删除。要为水印形状设置名称，请将其分配给[**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--)方法：
```javascript
watermarkShape.setName("watermark");
```


### **删除水印**

要删除水印形状，请使用[AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--)方法在幻灯片形状集合中找到它。然后，将水印形状传入[**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-)方法：
```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **常见问题**

**什么是水印，为什么要使用它？**

水印是覆盖在幻灯片上的文字或图像，用于保护知识产权、提升品牌识别度或防止演示文稿被未授权使用。

**我可以向演示文稿的所有幻灯片添加水印吗？**

可以，Aspose.Slides 允许您向演示文稿的每一张幻灯片添加水印。您可以遍历所有幻灯片并逐个应用水印设置。

**如何调整水印的透明度？**

您可以通过修改形状的[填充设置](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/)来调整水印的透明度，从而使水印保持柔和且不干扰幻灯片内容。

**支持哪些图片格式作为水印？**

Aspose.Slides 支持多种图片格式，例如 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自定义文字水印的字体和样式吗？**

可以，您可以选择任何字体、大小和样式，以匹配演示文稿的设计并保持品牌一致性。

**如何更改水印的位置或方向？**

您可以通过修改形状的坐标、大小和旋转属性来调整水印的位置和方向。