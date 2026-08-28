---
title: 在 JavaScript 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- 新增文字
- 新增段落
- 管理文字
- 管理段落
- 管理項目符號
- 段落縮排
- 懸掛縮排
- 段落項目符號
- 編號清單
- 項目符號清單
- 段落屬性
- 匯入 HTML
- 文字轉 HTML
- 段落轉 HTML
- 段落轉影像
- 文字轉影像
- 匯出段落
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 在 JavaScript 中建立與格式化段落、文字片段、項目符號、編號清單、縮排、HTML 內容以及段落影像。"
---
## **概述**

Aspose.Slides for Node.js via Java 將文字表示為文字框、段落和文字片段的層次結構：

* [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 表示形狀中的文字容器，並提供對其段落集合的存取。
* [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 表示文字框中的一個段落，並提供對其文字片段與段落層級格式設定的存取。
* [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 表示段落內的一個文字執行。每個文字片段都可以擁有自己的文字與字元層級格式設定。

因此，一個段落可以透過多個文字片段包含不同字型、顏色、大小及其他格式設定的文字。

## **建立與格式化段落**

### **建立含多個文字片段的段落**

以下步驟會建立一個文字框，內含三個段落，每個段落都有三個文字片段：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得目標投影片。
3. 在投影片上新增矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 取得圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。
5. 使用預設段落，並向文字框再新增兩個 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 物件。
6. 為每個段落新增足夠的 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 物件，使其包含三個文字片段。預設段落已包含一個空的文字片段。
7. 設定每個文字片段的文字內容。
8. 透過 [Portion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/getportionformat/) 套用字元層級的格式設定。
9. 儲存已修改的簡報。

以下 JavaScript 範例實作上述步驟：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **建立項目符號與編號清單**

### **建立項目符號或編號清單**

項目符號與編號可讓相關項目更易於掃描。於 Aspose.Slides 中，清單設定是透過 [BulletFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bulletformat/) 定義的。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得目標投影片。
3. 在選取的投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 取得圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。
5. 從文字框中移除預設段落。
6. 為符號項目建立一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/)。
7. 使用 [BulletFormat.setType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bulletformat/settype/) 設為 [BulletType.Symbol](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bullettype/) 並指定項目符號字元。
8. 設定段落文字、縮排、項目符號顏色與項目符號高度。
9. 將段落加入文字框。
10. 建立第二個段落，並使用 [BulletFormat.setType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bulletformat/settype/) 設為 [BulletType.Numbered](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bullettype/)。
11. 設定編號項目的樣式，並將段落加入文字框。
12. 儲存簡報。

以下 JavaScript 範例建立符號項目與編號項目：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **使用圖片項目符號**

圖片項目符號可讓您使用自訂影像取代符號或編號。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得目標投影片。
3. 新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 並取得其 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。
4. 從文字框中移除預設段落。
5. 載入項目符號影像，並以 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 加入簡報的影像集合。
6. 建立一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 並設定其文字。
7. 使用 [BulletFormat.setType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bulletformat/settype/) 設為 [BulletType.Picture](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bullettype/)。
8. 透過 [BulletFormat.getPicture](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bulletformat/getpicture/) 指定影像，並設定項目符號高度。
9. 將段落加入文字框。
10. 儲存已修改的簡報。

以下 JavaScript 範例建立圖片項目符號：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **建立多層次清單**

將 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setdepth/) 設為不同值，可將段落放置於清單的不同層級。最高層的深度為 `0`。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 並取得一張投影片。
2. 新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 並清除其文字框中的預設段落。
3. 建立四個段落，並設定其項目符號符號。
4. 將它們的 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setdepth/) 分別設為 `0`、`1`、`2`、`3`。
5. 將段落加入文字框並儲存簡報。

以下 JavaScript 範例建立四層的項目符號清單：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **自訂編號清單起始值**

使用 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 可設定編號段落的起始數字。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)，並在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
2. 清除圖形文字框中的預設段落。
3. 建立三個編號段落。
4. 分別將 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 設為 `2`、`3`、`7`。
5. 將段落加入文字框並儲存簡報。

以下 JavaScript 範例為每個段落指定自訂起始編號：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制段落版面與結尾屬性**

### **設定首行縮排**

使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setindent/) 可控制段落的首行縮排。此方法僅移動第一行相對於段落左邊界的距離，正值會將首行向右移動，其他行則保持與段落正文對齊。

若需移動整段文字，請使用 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)；若只需移動首行，則使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setindent/)。

以下範例建立多個段落，並套用不同的 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setindent/) 值，以示範首行縮排對段落版面的影響。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 取得圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 並移除預設段落。
5. 建立多個段落，並為它們設定不同的 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setindent/) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

以下程式碼示範如何設定段落縮排：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落的首行縮排](first_line_indent.png)

### **設定懸掛縮排**

懸掛縮排是指第一行位於其餘行左側的段落版面。於 Aspose.Slides 中，可使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setindent/)，傳入負值即可將第一行向左移動。

實務上，[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 定義段落正文的左側位置，而 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setindent/) 定義第一行相對於該邊界的位置。要產生懸掛縮排，請對 `setMarginLeft` 傳入正值，對 `setIndent` 傳入負值。

此格式設定常用於書目、參考文獻、詞彙表條目等需要讓換行後的文字對齊於段落正文而非首行第一個字元的情況。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 取得圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 並移除預設段落。
5. 為每個段落呼叫 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 並傳入正值。
6. 使用負值呼叫 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setindent/) 以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

以下程式碼示範如何為段落設定懸掛縮排：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落的懸掛縮排](hanging_indent.png)

### **設定段落結尾執行屬性**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) 控制段落結尾標記的格式。以下範例為第二個段落的結尾標記指派字型大小與拉丁字型：

1. 建立或載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)，並取得一張投影片。
2. 新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)，並清除其預設段落。
3. 建立兩個段落，並為它們加入文字片段。
4. 為第二個段落的結尾標記建立一個 [PortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/)。
5. 使用 [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) 與 [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) 設定屬性。
6. 透過 [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) 套用格式，並儲存簡報。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **匯入與匯出段落內容**

### **將 HTML 文字匯入段落**

使用 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) 可將 HTML 標記轉換為文字框中的段落與文字片段。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 取得一張投影片並新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
3. 取得圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 並清除預設段落。
4. 定義或讀取來源 HTML 字串。
5. 將 HTML 字串傳遞給 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/)。
6. 儲存已修改的簡報。

以下 JavaScript 範例將 HTML 匯入文字框：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **將段落文字匯出為 HTML**

使用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) 可將選取的段落範圍匯出為 HTML。

1. 建立或載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例。
2. 取得投影片並找到包含文字的 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
3. 取得圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。
4. 呼叫 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) 並提供起始段落索引與要匯出的段落數量。
5. 將回傳的 HTML 字串寫入檔案。

以下自主式 JavaScript 範例建立文字圖形並匯出全部段落：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **將段落渲染為影像**

[Paragraph.getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/#getImage) 直接渲染單一段落，並回傳一個 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/)。可使用 [IImage.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/#save) 將結果存成檔案。無需渲染所在圖形或手動裁切位圖。

若段落在其父集合中找不到、沒有有效的渲染範圍，或無法渲染，[Paragraph.getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/#getImage) 會回傳 `null`。請在儲存前檢查結果，並在使用完畢後釋放影像。

#### **以預設比例渲染段落**

以下文字方塊包含三個段落：

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下範例在預設比例下，於普通文字圖形中渲染第二個段落，並以 PNG 格式儲存回傳的影像。`finally` 區塊可確保影像正確釋放。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

結果：

![段落圖像](paragraph_to_image_output.png)

#### **在表格儲存格中以縮放比例渲染段落**

使用接受 `scaleX` 與 `scaleY` 參數的 [Paragraph.getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/#getImage) 變形版，可設定水平與垂直的縮放因子。以下範例建立一個表格，於第一個儲存格中將段落寬度與高度各放大兩倍，並將結果儲存為 PNG 影像。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

縮放因子 `1` 代表該軸保持預設像素大小。例如，水平與垂直皆設定為 `2`，則產生的影像寬高約為預設的兩倍，像素數量約為四倍。較大的因子通常可在放大或高解析度輸出時產生較銳利的文字，但同時會增加記憶體使用與檔案大小。因子小於 `1` 會產生較小且細節較少的影像。使用相等的因子可保留段落的長寬比；不同的水平與垂直因子會分別拉伸輸出。

若需包含圖形的填色、邊框或其他視覺資訊，仍可使用 [Shape.getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getImage) 來渲染整個圖形。若僅需段落圖像，則使用 [Paragraph.getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/#getImage)。

## **常見問題集**

**能否完全停用文字框內的換行？**

可以。將 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/setwraptext/) 設為關閉，即可停用換行，使文字不在文字框邊緣換行。

**如何取得特定段落在投影片上的精確邊界？**

使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/getrect/) 取得段落的外接矩形。[Portion.getRect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/#getRect) 可取得單一文字片段的邊界。

**段落對齊方式（左、右、置中或兩端對齊）在哪裡設定？**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setalignment/) 為段落層級設定，套用於整個段落，與個別文字片段的格式無關。

**能否為段落的部分文字設定校對語言？**

可以。對個別文字片段使用 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) 設定，即可在同一段落內包含多種語言的文字。