---
title: 在 Java 中为演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/java/watermark/
keywords:
- 水印
- 文本水印
- 图像水印
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
- Java
- Aspose.Slides
description: "在 Java 中管理 PowerPoint 和 OpenDocument 演示文稿的文本和图像水印，以标示草稿、机密信息、版权等。"
---
## **简介**

**水印** 在演示文稿中是用于幻灯片或整个演示文稿的文本或图像标记。通常，水印用于指示演示稿是草稿（例如 “草稿” 水印）、包含机密信息（例如 “机密” 水印）、说明所属公司（例如 “公司名称” 水印）、标识演示作者等。水印通过表明演示文稿不应被复制来帮助防止版权侵权。水印可用于 PowerPoint 和 OpenOffice 演示文稿格式。在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在[**Aspose.Slides**](https://products.aspose.com/slides/zh/java/)，有多种方式可以在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计和行为。共同点是：要添加文本水印，应使用[ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/)接口；要添加图像水印，则使用[PictureFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pictureframe/)类或用图像填充水印形状。`PictureFrame` 实现了[IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/)接口，允许您使用形状对象的所有灵活设置。由于`ITextFrame` 不是形状且其设置受限，它被包装在[IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/)对象中。

水印的应用方式有两种：对单个幻灯片或对所有演示文稿幻灯片。使用幻灯片母版（Slide Master）可以对所有幻灯片应用水印——水印被添加到幻灯片母版，在那里完成全部设计，并应用到所有幻灯片，而不会影响对单个幻灯片水印的修改权限。

水印通常被视为不允许其他用户编辑。为防止水印（或更确切地说其父形状）被编辑，Aspose.Slides 提供了形状锁定功能。可以在普通幻灯片或幻灯片母版上锁定特定形状。当水印形状在幻灯片母版上被锁定时，它将在所有演示文稿幻灯片上被锁定。

您可以为水印设置名称，以便将来想要删除时，可以通过名称在幻灯片的形状集合中找到它。

水印的设计方式可以随意，不过通常水印具备一些共性特征，如居中对齐、旋转、置于前面等。下面的示例将演示如何使用这些特性。

## **文本水印**

### **向幻灯片添加文本水印**

要在 PPT、PPTX 或 ODP 中添加文本水印，首先向幻灯片添加一个形状，然后向该形状添加文本框。文本框由[ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/)接口表示。该类型未继承自[IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/)，后者提供了丰富的属性用于灵活定位水印。因此，[ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/)对象被包装在[IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)对象中。要向形状添加水印文本，请使用下面示例中的[addTextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)方法。

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="另请参阅" %}} 
- [如何使用 TextFrame 类](/slides/zh/java/text-formatting/)
{{% /alert %}}

### **向演示文稿添加文本水印**

如果要一次性向整个演示文稿（即所有幻灯片）添加文本水印，请将其添加到[MasterSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/masterslide/)。其余逻辑与向单个幻灯片添加水印相同——创建一个[IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)对象，然后使用[addTextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)方法将水印添加进去。

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="另请参阅" %}} 
- [如何使用幻灯片母版](/slides/zh/java/slide-master/)
{{% /alert %}}

### **设置水印形状的透明度**

默认情况下，矩形形状带有填充色和线条颜色。下面的代码行将形状设为透明。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **设置文本水印的字体**

您可以按下面示例更改文本水印的字体。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **设置水印文本颜色**

要设置水印文本的颜色，请使用以下代码：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **居中文本水印**

可以将水印居中显示在幻灯片上，示例代码如下：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

下面的图片展示了最终效果。

![文字水印](text_watermark.png)

## **图像水印**

### **向演示文稿添加图像水印**

要向演示文稿幻灯片添加图像水印，可以执行以下操作：

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **锁定水印以防编辑**

如果需要防止水印被编辑，请对形状使用[IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/#getAutoShapeLock--)方法。通过该属性，您可以保护形状不被选中、调整大小、重新定位、与其他元素编组、锁定其文本编辑等：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// 锁定水印形状以防修改
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **将水印置于前面**

在 Aspose.Slides 中，形状的 Z 顺序可以通过[IShapeCollection.reorder](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)方法设置。您需要从演示文稿幻灯片列表调用此方法，并将形状引用及其顺序号传入。这样即可将形状置于前面或发送到幻灯片背后。该功能在需要将水印置于演示文稿前面时尤其有用：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **设置水印旋转角度**

以下代码示例演示了如何调整水印的旋转，使其以对角线方式跨越幻灯片：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **为水印设置名称**

Aspose.Slides 允许您为形状设置名称。通过形状名称，您可以在以后访问该形状进行修改或删除。要为水印形状设置名称，请调用[IAutoShape.setName](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#setName-java.lang.String-)方法：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **删除水印**

要删除水印形状，请使用[IAutoShape.getName](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getName--)方法在幻灯片形状集合中找到它，然后将该形状传入[IShapeCollection.remove](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)方法：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **常见问题**

### 什么是水印，为什么要使用它？

水印是叠加在幻灯片上的文本或图像，用于保护知识产权、提升品牌识别度或防止演示文稿被未授权使用。

### 我可以将水印添加到演示文稿的所有幻灯片吗？

可以，Aspose.Slides 允许您以编程方式向演示文稿的每一张幻灯片添加水印。您可以遍历所有幻灯片并分别应用水印设置。

### 如何调整水印的透明度？

您可以通过修改形状的填充设置（[getFillFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#getFillFormat--)）来调整水印的透明度，从而保证水印柔和且不会分散观众注意力。

### 支持哪些图像格式作为水印？

Aspose.Slides 支持多种图像格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

### 我可以自定义文本水印的字体和样式吗？

可以，您可以选择任意字体、大小和样式，以匹配演示文稿的设计并保持品牌一致性。

### 如何更改水印的位置或方向？

您可以通过编程方式修改形状的坐标、尺寸和旋转属性，从而调整水印的位置和方向。