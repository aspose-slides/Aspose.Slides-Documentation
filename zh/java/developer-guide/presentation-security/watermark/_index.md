---
title: 水印
type: docs
weight: 40
url: /java/watermark/
keywords:
- 水印
- 添加水印
- 文本水印
- 图像水印
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides for Java
description: "在Java中向PowerPoint演示文稿添加文本和图像水印"
---

## **关于水印**

**水印**是在演示文稿中使用的文本或图像印章，通常应用于幻灯片或所有演示文稿幻灯片中。通常，水印用于表示该演示文稿是草稿（例如，“草稿”水印）、包含机密信息（例如，“机密”水印）、指定其所属公司（例如，“公司名称”水印）、识别演示文稿作者等。水印有助于防止版权侵权，表明该演示文稿不得复制。水印被用于PowerPoint和OpenOffice演示文稿格式。在Aspose.Slides中，您可以向PowerPoint PPT、PPTX和OpenOffice ODP文件格式添加水印。

在[**Aspose.Slides**](https://products.aspose.com/slides/java/)中，您可以以多种方式在PowerPoint或OpenOffice文档中创建水印并修改其设计和行为。共同点是，添加文本水印时，您应该使用[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)接口，添加图像水印时，使用[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/)类或用图像填充水印形状。`PictureFrame`实现了[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)接口，允许您使用形状对象的所有灵活设置。由于`ITextFrame`不是形状，其设置有限，因此它被包装在[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)对象中。

水印可以通过两种方式应用：应用于单个幻灯片或所有演示文稿幻灯片。使用幻灯片母版将水印应用于所有演示文稿幻灯片——水印添加到幻灯片母版中，在那里完全设计，并应用于所有幻灯片，而不影响对单个幻灯片上水印的修改权限。

水印通常被认为是不可供其他用户编辑的。为了防止水印（或更确切地说水印的父形状）被编辑，Aspose.Slides提供了形状锁定功能。在普通幻灯片或幻灯片母版上可以锁定特定形状。当水印形状在幻灯片母版上被锁定时，它将在所有演示文稿幻灯片上被锁定。

您可以为水印设置一个名称，以便将来如果想要删除它，可以通过名称在幻灯片的形状中找到它。

您可以以任何方式设计水印；然而，水印通常有一些共同特征，例如居中对齐、旋转、前置位置等。我们将在下面的示例中考虑如何使用这些特性。

## **文本水印**

### **向幻灯片添加文本水印**

要在PPT、PPTX或ODP中添加文本水印，您可以首先向幻灯片添加一个形状，然后将文本框添加到该形状中。文本框由[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)接口表示。该类型不继承自[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)，后者有一组广泛的属性，用于灵活定位水印。因此，[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)对象被包装在[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)对象中。要将水印文本添加到形状中，请使用[addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)方法，如下所示。

```java
String watermarkText = "机密";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="另见" %}} 
- [如何使用TextFrame类](/slides/java/text-formatting/)
{{% /alert %}}

### **向演示文稿添加文本水印**

如果您想在整个演示文稿中添加文本水印（即一次添加到所有幻灯片），请将其添加到[MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/)。其余逻辑与向单个幻灯片添加水印的方式相同——创建一个[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)对象，然后使用[addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)方法将水印添加到其中。

```java
String watermarkText = "机密";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="另见" %}} 
- [如何使用幻灯片母版](/slides/java/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状被样式化为填充和线条颜色。以下代码行使形状变得透明。

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **设置文本水印的字体**

您可以更改文本水印的字体，如下所示。

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **设置水印文本颜色**

要设置水印文本的颜色，请使用以下代码：

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **居中文本水印**

可以将水印居中放置在幻灯片上，为此，您可以执行以下操作：

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

下图显示了最终结果。

![文本水印](text_watermark.png)

## **图像水印**

### **向演示文稿添加图像水印**

要向演示文稿幻灯片添加图像水印，您可以执行以下操作：

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

## **锁定水印以防编辑**

如果需要防止水印被编辑，请在形状上使用[IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getAutoShapeLock--)方法。通过此属性，您可以保护形状不被选择、调整大小、重新定位、与其他元素组合、锁定其文本不被编辑等等：

```java
// 锁定水印形状以防修改
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

## **将水印置于前面**

在Aspose.Slides中，形状的Z顺序可以通过[IShapeCollection.reorder](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)方法设置。为此，您需要从演示文稿幻灯片列表中调用此方法，并将形状引用及其顺序号传递给该方法。通过这种方式，可以将形状置于前面或发送到幻灯片的后面。此功能在您需要将水印放置在演示文稿前面时尤为有用：

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

## **设置水印旋转**

以下是如何调整水印旋转，使其在幻灯片上对角放置的代码示例：

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

## **为水印设置名称**

Aspose.Slides允许您设置形状的名称。通过使用形状名称，您将来可以访问它以进行修改或删除。要设置水印形状的名称，将其分配给[IAutoShape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setName-java.lang.String-)方法：

```java
watermarkShape.setName("watermark");
```

## **移除水印**

要移除水印形状，请使用[IAutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getName--)方法在幻灯片形状中找到它。然后，将水印形状传递给[IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)方法：

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **实时示例**

您可能想查看**Aspose.Slides免费**的[添加水印](https://products.aspose.app/slides/watermark)和[移除水印](https://products.aspose.app/slides/watermark/remove-watermark)在线工具。

![添加和移除水印的在线工具](online_tools.png)