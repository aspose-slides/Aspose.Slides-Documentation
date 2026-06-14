---
title: 新增浮水印到 Android 簡報
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
- 將浮水印新增至 PPT
- 將浮水印新增至 PPTX
- 將浮水印新增至 ODP
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

**浮水印** 在簡報中是一種文字或圖片印記，可用於單張投影片或整個簡報的所有投影片。通常，浮水印用來表示簡報仍在草稿階段（例如「Draft」浮水印）、含有機密資訊（例如「Confidential」浮水印）、屬於哪家公司（例如「Company Name」浮水印）、標示簡報作者等。浮水印有助於防止版權侵害，告知不應複製簡報。浮水印同時支援 PowerPoint 與 OpenOffice 簡報格式。於 Aspose.Slides 中，您可以為 PowerPoint PPT、PPTX 與 OpenOffice ODP 檔案格式新增浮水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/android-java/)，有多種方式可在 PowerPoint 或 OpenOffice 文件中建立浮水印並修改其設計與行為。共通點是，若要加入文字浮水印，應使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 介面；若要加入圖片浮水印，則使用 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/) 類別或以圖片填滿浮水印形狀。`PictureFrame` 實作了 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 介面，讓您能運用形狀物件的全部彈性設定。由於 `ITextFrame` 不是形狀且其設定受限，它會被包裝成一個 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 物件。

浮水印的套用方式有兩種：套用於單一投影片或套用於所有簡報投影片。使用投影片母片（Slide Master）可將浮水印套用至所有投影片——浮水印被加入至投影片母片，在那裡完成完整設計，並應用於所有投影片，且不會影響各投影片對浮水印的修改權限。

浮水印通常被視為不允許其他使用者編輯。為了防止浮水印（或其父形狀）被編輯，Aspose.Slides 提供形狀鎖定功能。可在普通投影片或投影片母片上鎖定特定形狀。當浮水印形狀在投影片母片上被鎖定時，所有投影片的浮水印皆會被鎖定。

您可以為浮水印設定名稱，未來若要刪除它，只要依名稱在投影片的形狀集合中尋找即可。

浮水印的設計方式多樣，但通常具備置中、旋轉、前置等共通特性。以下範例將說明如何在實作中使用這些特性。

## **文字浮水印**

### **將文字浮水印新增至投影片**

若要在 PPT、PPTX 或 ODP 中加入文字浮水印，您可以先在投影片上新增一個形狀，然後在此形狀上加入文字框。文字框由 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 介面表示。此類型未繼承自 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/)，因此無法直接使用定位相關的屬性。為此，[ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 物件會被包裝在 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 物件中。使用下列程式碼的 [addTextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 方法即可將浮水印文字加入形狀。

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="另請參閱" %}} 
- [How to Use the TextFrame Class](/slides/zh-hant/androidjava/text-formatting/)
{{% /alert %}}

### **將文字浮水印新增至整個簡報**

若要一次為整個簡報（即所有投影片）加入文字浮水印，請將其加入至 [MasterSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/masterslide/)。其餘邏輯與在單一投影片上新增浮水印相同——建立一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 物件，然後使用 [addTextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 方法加入浮水印文字。

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="另請參閱" %}} 
- [How to Use the Slide Master](/slides/zh-hant/androidjava/slide-master/)
{{% /alert %}}

### **設定浮水印形狀的透明度**

預設情況下，矩形形狀會套用填充與線條顏色。以下程式碼可將形狀設為透明。

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **設定文字浮水印的字型**

您可以如以下範例變更文字浮水印的字型。

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **設定浮水印文字的顏色**

若要設定浮水印文字的顏色，請使用以下程式碼：

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **置中文字浮水印**

您可以將浮水印置中於投影片，方式如下：

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

以下圖片顯示最終結果。

![The text watermark](text_watermark.png)

## **圖片浮水印**

### **將圖片浮水印新增至簡報**

若要在簡報投影片中加入圖片浮水印，請執行以下步驟：

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **鎖定浮水印以防編輯**

若需防止浮水印被編輯，可對形狀使用 [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) 方法。透過此屬性，您可以保護形狀不被選取、調整大小、重新定位、與其他元素群組、鎖定文字編輯等：

```java
// 鎖定浮水印形狀以防修改
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **將浮水印移到最前端**

在 Aspose.Slides 中，可透過 [IShapeCollection.reorder](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 方法設定形狀的 Z 序。您需要從簡報的投影片清單呼叫此方法，並傳入形狀參考與其順序號碼。如此即可將形狀移至最前或最背，特別適用於需要將浮水印置於簡報前端的情況：

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **設定浮水印的旋轉角度**

以下程式碼示範如何調整浮水印的旋轉，使其斜向跨越投影片：

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **為浮水印設定名稱**

Aspose.Slides 允許您為形狀設定名稱。使用形狀名稱，可在未來存取、修改或刪除該形狀。要為浮水印形狀設定名稱，請呼叫 [IAutoShape.setName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) 方法：

```java
watermarkShape.setName("watermark");
```

### **移除浮水印**

若要移除浮水印形狀，先使用 [IAutoShape.getName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getName--) 方法於投影片形狀中找到它，然後將該形狀傳入 [IShapeCollection.remove](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 方法：

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **常見問題**

**什麼是浮水印，為什麼要使用？**

浮水印是加在投影片上的文字或圖片覆蓋層，可協助保護智慧財產、提升品牌識別度，或防止未經授權使用簡報。

**我可以將浮水印加到簡報的所有投影片嗎？**

可以，Aspose.Slides 允許程式化地為簡報中的每一張投影片加入浮水印，您只需遍歷所有投影片並個別套用設定。

**如何調整浮水印的透明度？**

可透過修改形狀的填充設定（[getFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getFillFormat--)）來調整透明度，使浮水印不會搶走投影片內容的注意力。

**支援哪些圖片格式作為浮水印？**

Aspose.Slides 支援多種圖片格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自訂文字浮水印的字型與樣式嗎？**

可以，您可以選擇任意字型、大小與樣式，以符合簡報設計與品牌一致性。

**如何變更浮水印的位置或方向？**

可程式化地透過修改形狀的座標、大小與旋轉屬性，調整浮水印的定位與方向。