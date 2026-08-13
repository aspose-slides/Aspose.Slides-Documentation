---
title: 在 Java 中向簡報加入水印
linktitle: 水印
type: docs
weight: 40
url: /zh-hant/java/watermark/
keywords:
- 水印
- 文字水印
- 圖像水印
- 新增水印
- 變更水印
- 移除水印
- 刪除水印
- 將水印加入 PPT
- 将水印加入 PPTX
- 将水印加入 ODP
- 從 PPT 移除水印
- 從 PPTX 移除水印
- 從 ODP 移除水印
- 從 PPT 刪除水印
- 從 PPTX 刪除水印
- 從 ODP 刪除水印
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Java 中管理 PowerPoint 與 OpenDocument 簡報的文字和圖像水印，以標示草稿、機密資訊、版權等。"
---
## **簡介**

**水印** 在簡報中是用於投影片或整份簡報的文字或圖像印記。通常，水印用來表示簡報是草稿（例如「Draft」水印）、包含機密資訊（例如「Confidential」水印）、標示所屬公司（例如「Company Name」水印）、辨識簡報作者等。水印透過告知簡報不應被複製來防止版權侵害。水印可用於 PowerPoint 與 OpenOffice 簡報格式。在 Aspose.Slides 中，您可以在 PowerPoint PPT、PPTX 與 OpenOffice ODP 檔案格式中加入水印。

在[Aspose.Slides](https://products.aspose.com/slides/zh-hant/java/)，您可以透過多種方式在 PowerPoint 或 OpenOffice 文件中建立水印，並修改其設計與行為。共通點是：要加入文字水印，應使用[ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 介面；要加入圖像水印，則使用[PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/) 類別或以圖像填滿水印形狀。`PictureFrame` 實作[IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 介面，讓您能使用形狀物件的全部彈性設定。因為[ITextFrame]不是形狀且設定受限，它會被包裝成[IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 物件。

水印可以以兩種方式套用：套用於單一投影片或套用於所有投影片。使用投影片母片（Slide Master）可將水印套用至所有投影片——水印會加入投影片母片，在母片上完成全部設計，然後套用至所有投影片，而不會影響個別投影片對水印的編輯權限。

水印通常被視為不允許其他使用者編輯。為了防止水印（或其父形狀）被編輯，Aspose.Slides 提供形狀鎖定功能。特定形狀可以在普通投影片或在投影片母片上被鎖定。當水印形狀在投影片母片上被鎖定時，所有投影片的水印亦會被鎖定。

您可以為水印設定名稱，未來若要刪除水印時，可依名稱在投影片的形狀集合中找到它。

您可以以任何方式設計水印；然而，水印通常具有一些共通特性，如置中對齊、旋轉、前置等。以下範例將說明如何使用這些特性。

## **文字水印**

### **在投影片上新增文字水印**

要在 PPT、PPTX 或 ODP 中新增文字水印，您可以先在投影片上加入形狀，然後在該形狀上新增文字框。文字框由[ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 介面表示。此類型未繼承自[IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/)，而[IShape] 提供了彈性的定位屬性。因此，[ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 物件會被包裝在[IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 物件中。要將水印文字加入形狀，請使用如下的[addTextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 方法。

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="另請參閱" %}} 
- [如何使用 TextFrame 類別](/slides/zh-hant/java/text-formatting/)
{{% /alert %}}

### **在整份簡報中新增文字水印**

如果您想一次為整份簡報（即所有投影片）新增文字水印，請將其加入[MasterSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/masterslide/)。其餘邏輯與在單一投影片上新增水印相同——建立[IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 物件，然後使用[addTextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 方法將文字水印加到該形狀。

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="另請參閱" %}} 
- [如何使用投影片母片](/slides/zh-hant/java/slide-master/)
{{% /alert %}}

### **設定水印形狀透明度**

預設情況下，矩形形狀會設定填充和線條顏色。以下程式碼可將形狀設為透明。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **設定文字水印字型**

您可以如以下範例變更文字水印的字型。

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

### **設定水印文字顏色**

若要設定水印文字顏色，請使用以下程式碼：

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

### **置中文字水印**

您可以將水印置中於投影片，做法如下：

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

下圖顯示最終結果。

![文字水印](text_watermark.png)

## **圖像水印**

### **在簡報中新增圖像水印**

要在簡報投影片上加入圖像水印，您可以執行以下操作：

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

### **鎖定水印以防編輯**

若需防止水印被編輯，請對形狀使用[IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) 方法。透過此屬性，您可以保護形狀免於被選取、調整大小、重新定位、與其他元素群組、鎖定文字編輯等：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// 鎖定水印形狀以防止修改
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **將水印移至最上層**

在 Aspose.Slides 中，可透過[IShapeCollection.reorder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 方法設定形狀的 Z 順序。您需要從簡報的投影片清單呼叫此方法，並傳入形狀參考與其順序編號。如此即可將形狀移至最前或最背，對於需要將水印放在簡報前景的情況特別有用：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **設定水印旋轉角度**

以下程式碼示範如何調整水印的旋轉，使其斜跨投影片：

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

### **為水印設定名稱**

Aspose.Slides 允許您設定形狀名稱。使用名稱之後，未來即可透過名稱存取、修改或刪除該形狀。要為水印形狀設定名稱，請呼叫[IAutoShape.setName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#setName-java.lang.String-) 方法：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **移除水印**

若要刪除水印形狀，先使用[IAutoShape.getName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getName--) 方法在投影片形狀集合中找到它，然後將該形狀傳入[IShapeCollection.remove](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 方法：

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

## **常見問題**

### 什麼是水印，為什麼要使用它？

水印是加在投影片上的文字或圖像覆蓋層，可協助保護智慧財產、提升品牌辨識度，或防止簡報被未經授權使用。

### 能否將水印加入簡報的所有投影片？

可以，Aspose.Slides 允許您以程式方式將水印加入簡報的每一張投影片，您只需遍歷全部投影片並個別套用水印設定即可。

### 如何調整水印的透明度？

您可以透過修改形狀的填充設定（[getFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getFillFormat--)）來調整透明度，使水印不會分散投影片內容的注意力。

### 支援哪些圖像格式作為水印？

Aspose.Slides 支援多種圖像格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

### 我可以自訂文字水印的字型與樣式嗎？

可以，您可自由選擇字型、大小與樣式，以符合簡報設計並維持品牌一致性。

### 如何變更水印的位置或方向？

您可以透過程式修改形狀的座標、大小與旋轉屬性，從而調整水印的位置與方向。