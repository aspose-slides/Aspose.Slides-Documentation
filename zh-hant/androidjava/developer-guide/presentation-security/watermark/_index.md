---
title: 在 Android 上為簡報新增浮水印
linktitle: 浮水印
type: docs
weight: 40
url: /zh-hant/androidjava/watermark/
keywords:
- 浮水印
- 文字浮水印
- 圖片浮水印
- 新增浮水印
- 變更浮水印
- 移除浮水印
- 刪除浮水印
- 新增浮水印至 PPT
- 新增浮水印至 PPTX
- 新增浮水印至 ODP
- 從 PPT 移除浮水印
- 從 PPTX 移除浮水印
- 從 ODP 移除浮水印
- 從 PPT 刪除浮水印
- 從 PPTX 刪除浮水印
- 從 ODP 刪除浮水印
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Java 管理 PowerPoint 與 OpenDocument 簡報中的文字與圖片浮水印，以標示草稿、機密資訊等。"
---
## **簡介**

**浮水印** 在簡報中是用於投影片或整個簡報的文字或圖片標記。通常，浮水印用來表示簡報是草稿（例如「Draft」浮水印）、包含機密資訊（例如「Confidential」浮水印）、屬於某公司（例如「Company Name」浮水印）、標示簡報作者等。浮水印可透過顯示此簡報不應被複製，來防止版權侵害。浮水印同時支援 PowerPoint 與 OpenOffice 簡報格式。於 Aspose.Slides 中，您可以為 PowerPoint PPT、PPTX 與 OpenOffice ODP 檔案格式新增浮水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/android-java/)，有多種方式可以在 PowerPoint 或 OpenOffice 文件中建立浮水印，並調整其設計與行為。共同點在於，若要加入文字浮水印，應使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 介面；若要加入圖片浮水印，則使用 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/) 類別或以影像填充浮水印形狀。`PictureFrame` 實作了 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 介面，讓您能使用形狀物件的所有彈性設定。由於 `ITextFrame` 不是形狀且設定受限，它會被包裝成一個 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 物件。

浮水印的套用方式有兩種：套用於單一投影片或套用於所有投影片。使用投影片母版（Slide Master）可將浮水印套用至所有投影片——浮水印加入母版、於母版上完整設計，然後自動套用至所有投影片，同時不影響個別投影片上浮水印的編輯權限。

浮水印通常被視為其他使用者無法編輯的項目。為防止浮水印（或其父形狀）被編輯，Aspose.Slides 提供形狀鎖定功能。特定形狀可在普通投影片或投影片母版上鎖定。當浮水印形狀在母版上被鎖定時，所有投影片上的該形狀亦會被鎖定。

您可以為浮水印設定名稱，未來若要刪除時，可依名稱在投影片的形狀集合中找到它。

您可以以任何方式設計浮水印；然而浮水印通常具備的共同特徵包括置中對齊、旋轉、前置等。以下範例將說明如何使用這些特性。

## **文字浮水印**

### **在投影片上新增文字浮水印**

要在 PPT、PPTX 或 ODP 中加入文字浮水印，您可以先於投影片新增形狀，然後在該形狀內新增文字框。文字框由 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 介面表示。此類型未繼承自 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/)，因此缺乏彈性定位屬性。為此，會將 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 物件包裝在 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 物件中。要將文字浮水印加入形狀，請使用下列的 [addTextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 方法。

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
- [如何使用 TextFrame 類](/slides/zh-hant/androidjava/text-formatting/)
{{% /alert %}}

### **在整個簡報中新增文字浮水印**

如果想一次為整個簡報（即所有投影片）加入文字浮水印，請將其加入 [MasterSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/masterslide/)。其餘邏輯與在單一投影片上加入浮水印相同——建立一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 物件，然後使用 [addTextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 方法將浮水印加入。

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
- [如何使用投影片母版](/slides/zh-hant/androidjava/slide-master/)
{{% /alert %}}

### **設定浮水印形狀的透明度**

預設情況下，矩形形狀會套用填滿與線條顏色。以下程式碼可將形狀設為透明。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **設定文字浮水印的字型**

您可以如下面範例般變更文字浮水印的字型。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **設定浮水印文字顏色**

若要設定浮水印文字的顏色，請使用以下程式碼：

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **將文字浮水印置中**

您可以將浮水印置中於投影片，做法如下：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

下圖顯示最終結果。

![文字浮水印](text_watermark.png)

## **圖片浮水印**

### **在簡報中新增圖片浮水印**

要在簡報投影片中加入圖片浮水印，您可以執行以下步驟：

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **鎖定浮水印以防編輯**

若需防止浮水印被編輯，可對形狀使用 [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) 方法。透過此屬性，您可以保護形狀不被選取、調整大小、重新定位、與其他元素群組、鎖定文字編輯等：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // 鎖定浮水印形狀以防止修改
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **將浮水印移至最前方**

在 Aspose.Slides 中，可透過 [IShapeCollection.reorder](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 方法設定形狀的 Z 順序。您需要從簡報的投影片列表呼叫此方法，並傳入形狀參考與其順序編號。如此即可將形狀移至最前方或送到投影片背面，特別適用於需要將浮水印置於簡報前景的情況：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **設定浮水印旋轉角度**

以下程式碼示範如何調整浮水印的旋轉，使其以對角線方式分布於投影片上：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **為浮水印設定名稱**

Aspose.Slides 允許您為形狀設定名稱。使用形狀名稱，可在未來存取、修改或刪除該形狀。要為浮水印形狀設定名稱，請呼叫 [IAutoShape.setName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) 方法：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **移除浮水印**

若要移除浮水印形狀，先使用 [IAutoShape.getName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getName--) 方法在投影片形狀中找到它，然後將該形狀傳入 [IShapeCollection.remove](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 方法：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **常見問題**

### 什麼是浮水印，為什麼要使用它？

浮水印是加於投影片上的文字或圖片覆蓋層，可協助保護智慧財產權、提升品牌辨識度，或防止簡報被未授權使用。

### 我可以將浮水印加入簡報的所有投影片嗎？

可以，Aspose.Slides 允許您以程式方式為簡報中的每一張投影片加入浮水印，您可以遍歷所有投影片並個別套用浮水印設定。

### 如何調整浮水印的透明度？

您可以透過修改形狀的填充設定（[getFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getFillFormat--)）來調整浮水印的透明度，確保浮水印不會分散投影片內容的注意力。

### 支援哪些圖片格式作為浮水印？

Aspose.Slides 支援多種圖片格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

### 我可以自訂文字浮水印的字型與樣式嗎？

可以，您可以選擇任意字型、大小與樣式，以符合簡報設計並保持品牌一致性。

### 如何變更浮水印的位置或方向？

您可以透過程式調整形狀的座標、大小與旋轉屬性，從而改變浮水印的位置與方向。