---
title: 在 Java 中為簡報新增浮水印
linktitle: 浮水印
type: docs
weight: 40
url: /zh-hant/java/watermark/
keywords:
- 浮水印
- 文字浮水印
- 圖像浮水印
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
- Java
- Aspose.Slides
description: "在 Java 中管理 PowerPoint 與 OpenDocument 簡報的文字與圖像浮水印，以標示草稿、機密資訊、版權等。"
---
## **簡介**

**浮水印** 在簡報中是用於投影片或整個簡報的文字或圖像印記。通常，浮水印用於表示簡報是草稿（例如「Draft」浮水印）、包含機密資訊（例如「Confidential」浮水印）、指定所屬公司（例如「Company Name」浮水印）、識別簡報作者等。浮水印透過指出簡報不應被複製，協助防止版權侵害。浮水印同時適用於 PowerPoint 與 OpenOffice 簡報格式。在 Aspose.Slides 中，您可以將浮水印新增至 PowerPoint PPT、PPTX 與 OpenOffice ODP 檔案格式。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/java/)，您可以透過多種方式在 PowerPoint 或 OpenOffice 文件中建立浮水印，並修改其設計與行為。共同點是，要加入文字浮水印應使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 介面；要加入圖像浮水印則使用 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/) 類別或以圖像填充浮水印形狀。`PictureFrame` 實作了 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 介面，讓您能使用形狀物件的所有彈性設定。由於 `ITextFrame` 不是形狀且設定受限，會被包裝成一個 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 物件。

有兩種方式套用浮水印：套用於單一投影片或全部投影片。使用投影片母片（Slide Master）可將浮水印套用至全部投影片──浮水印被加入投影片母片，在母片上完整設計，且會套用到所有投影片，而不影響各投影片對浮水印的修改權限。

浮水印通常被視為不允許其他使用者編輯。為防止浮水印（或其父形狀）被編輯，Aspose.Slides 提供形狀鎖定功能。您可以在一般投影片或投影片母片上鎖定特定形狀。當在投影片母片上鎖定浮水印形狀時，它將於所有投影片上皆被鎖定。

您可以為浮水印設定名稱，之後若需刪除時，可依名稱於投影片的形狀集合中找到它。

浮水印的設計方式多樣；然而，浮水印通常具備一些共通特徵，例如置中對齊、旋轉、置前等。以下範例將說明如何運用這些特性。

## **文字浮水印**

### **將文字浮水印加入投影片**

要在 PPT、PPTX 或 ODP 中加入文字浮水印，您可以先在投影片上新增一個形狀，然後為該形狀加入文字框。文字框由 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 介面表示。此類型未繼承自具有廣泛屬性以彈性定位浮水印的 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/)。因此，會將 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 物件包裝在 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 物件中。要將浮水印文字加入形狀，請使用下列的 [addTextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 方法。

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="參考" %}} 
- [如何使用 TextFrame 類別](/slides/zh-hant/java/text-formatting/)
{{% /alert %}}

### **將文字浮水印加入簡報**

若要將文字浮水印加入整份簡報（即一次套用於所有投影片），請將其加入 [MasterSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/masterslide/)。其餘邏輯與將浮水印加入單一投影片相同──建立一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 物件，然後使用 [addTextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 方法將浮水印加入其中。

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="參考" %}} 
- [如何使用投影片母片](/slides/zh-hant/java/slide-master/)
{{% /alert %}}

### **設定浮水印形狀透明度**

預設情況下，矩形形狀具有填充與線條顏色。以下程式碼可使形狀變為透明。

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **設定文字浮水印的字型**

您可以如下面範例所示更改文字浮水印的字型。

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **設定浮水印文字顏色**

若要設定浮水印文字的顏色，請使用以下程式碼：

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **將文字浮水印置中**

您可以將浮水印置於投影片中央，方法如下：

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

下圖顯示最終結果。

![文字浮水印](text_watermark.png)

## **圖像浮水印**

### **將圖像浮水印加入簡報**

要在簡報投影片上加入圖像浮水印，您可以這樣做：

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **防止浮水印被編輯**

若需防止浮水印被編輯，請在形狀上使用 [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) 方法。透過此屬性，您可以防止形狀被選取、調整大小、重新定位、與其他元素群組、鎖定其文字編輯等多種操作：

```java
// 鎖定浮水印形狀，使其無法被修改
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **將浮水印置前**

在 Aspose.Slides 中，可透過 [IShapeCollection.reorder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 方法設定形狀的 Z 軸順序。您需要從簡報投影片清單呼叫此方法，並傳入形狀參考及其排序編號。如此即可將形狀置於前景或送至投影片背面。此功能在需要將浮水印置於簡報前方時特別有用：

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **設定浮水印旋轉**

以下程式碼示例說明如何調整浮水印的旋轉角度，使其以對角方式分佈於投影片上：

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **為浮水印設定名稱**

Aspose.Slides 允許您為形狀設定名稱。利用形狀名稱，您日後可以存取它以進行修改或刪除。若要為浮水印形狀設定名稱，請呼叫 [IAutoShape.setName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#setName-java.lang.String-) 方法：

```java
watermarkShape.setName("watermark");
```

### **移除浮水印**

若要移除浮水印形狀，請使用 [IAutoShape.getName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getName--) 方法在投影片形狀中找到它，然後將該浮水印形狀傳入 [IShapeCollection.remove](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 方法：

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

**什麼是浮水印，為什麼要使用它？**

浮水印是一種加在投影片上的文字或圖像覆蓋層，用以保護智慧財產、提升品牌辨識度，或防止未授權使用簡報。

**我可以將浮水印加入簡報的所有投影片嗎？**

是的，Aspose.Slides 允許您以程式方式為簡報的每一張投影片加入浮水印。您可以遍歷所有投影片，並分別套用浮水印設定。

**如何調整浮水印的透明度？**

您可以透過修改形狀的填充設定（[getFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getFillFormat--)）來調整浮水印的透明度。如此可使浮水印保持淡化，不會分散投影片內容的注意力。

**浮水印支援哪些圖像格式？**

Aspose.Slides 支援多種圖像格式，例如 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自訂文字浮水印的字體與樣式嗎？**

是的，您可選擇任何字體、大小與樣式，以符合簡報設計並保持品牌一致性。

**我要如何變更浮水印的位置或方向？**

您可以透過程式碼修改形狀的座標、大小與旋轉屬性，來調整浮水印的位置或方向。