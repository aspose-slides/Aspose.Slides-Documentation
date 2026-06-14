---
title: 在 JavaScript 中為簡報加入水印
linktitle: 水印
type: docs
weight: 40
url: /zh-hant/nodejs-java/watermark/
keywords:
- 水印
- 文字水印
- 圖片水印
- 新增水印
- 變更水印
- 移除水印
- 刪除水印
- 將水印加入 PPT
- 將水印加入 PPTX
- 將水印加入 ODP
- 從 PPT 移除水印
- 從 PPTX 移除水印
- 從 ODP 移除水印
- 從 PPT 刪除水印
- 從 PPTX 刪除水印
- 從 ODP 刪除水印
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Node.js 中管理 PowerPoint 與 OpenDocument 簡報的文字與圖片水印，以標示草稿、機密資訊、版權等內容。"
---
## **簡介**

**水印** 在投影片中是用於單一投影片或整個簡報的文字或圖片印記。通常，水印用來表示簡報是草稿（例如「Draft」水印）、含有機密資訊（例如「Confidential」水印）、屬於哪家公司（例如「Company Name」水印）、辨識簡報作者等。水印可透過顯示此簡報不應被複製，來防止版權侵害。水印同時適用於 PowerPoint 與 OpenOffice 簡報格式。於 Aspose.Slides 中，您可以對 PowerPoint PPT、PPTX 與 OpenOffice ODP 檔案格式加入水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/nodejs-java/)，有多種方式可在 PowerPoint 或 OpenOffice 文件中建立水印，並修改其設計與行為。共通點是：若要加入文字水印，請使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 類型；若要加入圖片水印，請使用 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 類別或以圖片填滿水印形狀。`PictureFrame` 繼承自 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 類型，讓您能使用形狀物件的各種彈性設定。因為 `TextFrame` 不是形狀且設定較受限，它會被包裝在一個 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 物件中。

水印的套用方式有兩種：套用於單一投影片或套用於全部投影片。使用投影片母片 (Slide Master) 可將水印套用到所有投影片——水印被加入母片、在母片上完整設計，且會套用至所有投影片，同時不會影響個別投影片對水印的修改權限。

水印通常被視為不允許其他使用者編輯的項目。為防止水印（或更確切說是水印的父形狀）被編輯，Aspose.Slides 提供形狀鎖定功能。您可以在普通投影片或投影片母片上鎖定特定形狀。當水印形狀在母片上被鎖定時，會在所有投影片上保持鎖定狀態。

您可以為水印設定名稱，未來若需刪除時，可依名稱在投影片的形狀集合中找到它。

水印的設計方式多樣，但通常具有共同特徵，例如置中對齊、旋轉、置於最前等。以下範例將說明如何運用這些特性。

## **文字水印**

### **將文字水印加入投影片**
要在 PPT、PPTX 或 ODP 中加入文字水印，您可以先在投影片上加入形狀，然後在該形狀中新增文字框。文字框以 [**TextFrame**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrame) 類型表示。此類型未繼承自 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape)，因此無法直接使用靈活的定位屬性。因此，會將 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrame) 物件包裝在一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape) 物件中。要在形狀上加入水印文字，請使用 [**addTextFrame**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) 方法，將水印文字作為參數傳入：

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="另請參閱" %}} 
- 如何使用 [TextFrame](/slides/zh-hant/nodejs-java/text-formatting/)。
{{% /alert %}}

### **將文字水印加入簡報**
若要一次性將文字水印加入整份簡報（即所有投影片），請將其加入 [**MasterSlide**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/MasterSlide)。其餘邏輯與加入單一投影片的方式相同——先建立一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape) 物件，然後使用 [**addTextFrame**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) 方法將水印加入：

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="另請參閱" %}} 
- [如何使用](/slides/zh-hant/nodejs-java/slide-master/)[投影片母片](/slides/zh-hant/nodejs-java/slide-master/)
{{% /alert %}}

### **設定水印形狀的透明度**
預設情況下，矩形形狀會套用填充色與線條顏色。以下程式碼可將形狀設為透明：

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **設定文字水印的字型**
您可以如以下程式碼變更文字水印的字型：

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **設定水印文字顏色**
要設定水印文字的顏色，請使用下列程式碼：

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **置中文字水印**
若要將水印置中於投影片，可執行以下操作：

```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

下圖顯示最終結果。

![文字水印](text_watermark.png)

## **圖片水印**

### **將圖片水印加入簡報**
若要將圖片水印加入所有投影片，可執行以下操作：

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **鎖定水印以防編輯**
若需防止水印被編輯，可對形狀使用 [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape#getShapeLock--) 方法。透過此屬性，您可以防止形狀被選取、調整大小、重新定位、與其他元素群組、鎖定文字編輯等：

```javascript
// 鎖定水印形狀以防止修改
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **將水印置於最前**
在 Aspose.Slides 中，可透過 [**SlideCollection.reorder**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) 方法設定形狀的 Z 軸順序。您需要從簡報的投影片集合呼叫此方法，並將形狀參考與其排序編號傳入。如此即可將形狀移至最前或最背，對於需要將水印置於簡報前景的情況特別有用：

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **設定水印旋轉角度**
以下程式碼示範如何調整水印的旋轉角度，使其斜向跨過投影片：

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **為水印設定名稱**
Aspose.Slides 允許您為形狀設定名稱。藉由形狀名稱，未來可輕鬆存取以進行修改或刪除。要為水印形狀設定名稱，請呼叫 [**AutoShape.getName**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#getName--) 方法：

```javascript
watermarkShape.setName("watermark");
```

### **移除水印**
若要移除水印形狀，請先使用 [AutoShape.getName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#getName--) 方法在投影片形狀集合中找到它，然後將該形狀傳入 [**ShapeCollection.remove**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) 方法：

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **常見問題**

**什麼是水印，為什麼要使用它？**  
水印是覆蓋於投影片上的文字或圖片，用以保護智慧財產、提升品牌辨識度，或防止未授權使用簡報。

**我可以將水印加入簡報的所有投影片嗎？**  
可以，Aspose.Slides 允許您將水印加入簡報的每一張投影片，您只需遍歷所有投影片並分別套用水印設定。

**如何調整水印的透明度？**  
您可以透過修改形狀的 [填充設定](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getfillformat/) 來調整透明度，使水印不會干擾投影片內容。

**支援哪些圖片格式作為水印？**  
Aspose.Slides 支援多種圖片格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自訂文字水印的字型與樣式嗎？**  
可以，您可以選擇任意字型、大小與樣式，以符合簡報的設計需求並保持品牌一致性。

**如何變更水印的位置或方向？**  
您可以透過調整形狀的座標、尺寸與旋轉屬性，來改變水印的放置位置與方向。