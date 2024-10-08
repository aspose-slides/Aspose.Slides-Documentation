---
title: 水印
type: docs
weight: 40
url: /zh/androidjava/watermark/
keywords:
- 水印
- 添加水印
- 文本水印
- 图像水印
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides for Android via Java
description: "在 Java 中向 PowerPoint 演示文稿添加文本和图像水印"
---

## **关于水印**

**水印**是在演示文稿中用于单张幻灯片或所有演示文稿幻灯片上的文本或图像印记。通常，水印用于表示该演示文稿是草稿（例如，“草稿”水印）、包含机密信息（例如，“机密”水印）、指定归属公司（例如，“公司名称”水印）、识别演示文稿作者等。水印有助于防止版权侵犯，表明该演示文稿不应被复制。水印在 PowerPoint 和 OpenOffice 演示文稿格式中均有使用。在 Aspose.Slides 中，可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/android-java/) 中，有多种方法可以在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计和行为。共同的方面是，添加文本水印时，应使用 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) 接口，而添加图像水印时，则使用 [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) 类或用图像填充水印形状。`PictureFrame` 实现了 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 接口，允许您使用形状对象的所有灵活设置。由于 `ITextFrame` 不是形状且其设置有限，因此将其包装在 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 对象中。

水印可以应用于两种方式：单张幻灯片或所有演示文稿幻灯片。幻灯片母版用于将水印应用于所有演示文稿幻灯片——水印添加到幻灯片母版中，在那里完全设计，并应用于所有幻灯片，而不影响对单张幻灯片上水印的修改权限。

水印通常被认为不允许其他用户编辑。为了防止水印（或者说水印的父形状）被编辑，Aspose.Slides 提供了形状锁定功能。特定形状可以在普通幻灯片或幻灯片母版上被锁定。当水印形状在幻灯片母版上被锁定时，它将在所有演示文稿幻灯片上被锁定。

您可以为水印设置一个名称，以便将来如果想删除它时，可以通过名称在幻灯片的形状中找到它。

您可以以任何方式设计水印；然而，水印中通常有一些共同特征，例如居中对齐、旋转、前置位置等。我们将在下面的示例中考虑如何使用这些功能。

## **文本水印**

### **向幻灯片添加文本水印**

要在 PPT、PPTX 或 ODP 中添加文本水印，您可以先向幻灯片添加一个形状，然后将文本框添加到此形状中。文本框由 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) 接口表示。此类型不继承自 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)，后者有广泛的属性集，可以灵活定位水印。因此，[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) 对象被包装在 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) 对象中。要向形状添加水印文本，请使用 [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 方法，如下所示。

```java
String watermarkText = "机密";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="另见" %}} 
- [如何使用 TextFrame 类](/slides/zh/androidjava/text-formatting/)
{{% /alert %}}

### **向演示文稿添加文本水印**

如果您想在整个演示文稿中添加文本水印（即一次性添加到所有幻灯片），请将其添加到 [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/)。其余逻辑与添加单张幻灯片的水印相同——创建一个 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) 对象，然后使用 [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 方法向其添加水印。

```java
String watermarkText = "机密";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="另见" %}} 
- [如何使用幻灯片母版](/slides/zh/androidjava/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状带有填充和线条颜色。以下代码行使形状透明。

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **设置文本水印的字体**

您可以按如下所示更改文本水印的字体。

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
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **居中一个文本水印**

可以将水印居中放置在幻灯片上，为此，您可以执行以下操作：

```java
SizeF slideSize = presentation.getSlideSize().getSize();

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

## **锁定水印以防止编辑**

如果需要防止水印被编辑，可以在形状上使用 [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) 方法。通过该属性，您可以保护形状不被选择、调整大小、重新定位、与其他元素组合，锁定其文本不被编辑等等：

```java
// 锁定水印形状以防修改
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

## **将水印置于最上层**

在 Aspose.Slides 中，形状的 Z 顺序可以通过 [IShapeCollection.reorder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 方法设置。为此，您需要从演示文稿幻灯片列表中调用此方法，并将形状引用及其顺序号传递给该方法。这样，就可以将形状置于最上方或发送到幻灯片的最底层。此功能在需要将水印放在演示文稿前面时特别有用：

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

## **设置水印旋转**

以下是如何调整水印旋转的代码示例，使其在幻灯片上呈对角位置：

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

## **为水印设置名称**

Aspose.Slides 允许您设置形状的名称。通过使用形状名称，您可以在将来访问它以进行修改或删除。要设置水印形状的名称，将其分配给 [IAutoShape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) 方法：

```java
watermarkShape.setName("watermark");
```

## **删除水印**

要删除水印形状，请使用 [IAutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getName--) 方法在幻灯片形状中找到它。然后，将水印形状传递到 [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 方法中：

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **一个现场示例**

您可能想查看 **Aspose.Slides 免费** [添加水印](https://products.aspose.app/slides/watermark) 和 [移除水印](https://products.aspose.app/slides/watermark/remove-watermark) 在线工具。

![添加和移除水印的在线工具](online_tools.png)