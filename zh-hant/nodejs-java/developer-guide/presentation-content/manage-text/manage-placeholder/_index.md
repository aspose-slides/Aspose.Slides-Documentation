---
title: 以 JavaScript 管理簡報佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/nodejs-java/manage-placeholder/
keywords:
- 佔位符
- 文字佔位符
- 圖片佔位符
- 圖表佔位符
- 提示文字
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "輕鬆在 Aspose.Slides for Node.js via Java 中管理佔位符：替換文字、客製化提示文字，並在 PowerPoint 與 OpenDocument 中設定圖片透明度。"
---
## **概觀**

Aspose.Slides 允許您以程式方式管理簡報佔位符。本篇文章說明如何在投影片上尋找佔位符並變更其文字、為佔位符版面設定自訂提示文字，以及調整用作佔位符背景的圖片之透明度。文章亦包含簡短的 FAQ，說明基礎佔位符與投影片本地圖形的差異、如何透過版面或母片套用佔位符變更，並指向頁首與頁尾佔位符的管理。

## **變更佔位符文字**

使用 [Aspose.Slides for Node.js via Java](/slides/zh-hant/nodejs-java/)，您可以在簡報的投影片上尋找並修改佔位符。Aspose.Slides 允許您變更佔位符中的文字。

**先決條件**：您需要一個包含佔位符的簡報。您可以使用標準的 Microsoft PowerPoint 應用程式建立此類簡報。

以下說明如何使用 Aspose.Slides 替換該簡報中佔位符的文字：

1. 實例化 [`Presentation`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別，並將簡報作為參數傳入。
2. 透過索引取得投影片參考。
3. 遍歷圖形以尋找佔位符。
4. 將佔位符圖形型別轉換為 [`AutoShape`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape)，並使用與該 [`AutoShape`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape) 關聯的 [`TextFrame`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrame) 變更文字。
5. 儲存已修改的簡報。

```javascript
// 實例化 Presentation 類別
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // 存取第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 遍歷圖形以尋找佔位符
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // 變更每個佔位符的文字
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // 將簡報儲存至磁碟
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定佔位符提示文字**

標準與預建版面包含像 ***Click to add a title*** 或 ***Click to add a subtitle*** 這樣的佔位符提示文字。使用 Aspose.Slides，您可以將自訂的提示文字插入佔位符版面。

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // 遍歷投影片
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint 顯示 "Click to add title"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // 新增副標題
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定佔位符圖像透明度**

Aspose.Slides 允許您設定文字佔位符背景圖片的透明度。透過調整此框架中圖片的透明度，您可以根據文字與圖片的顏色使文字或圖片更突出。

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **常見問題**

**什麼是基礎佔位符，且它與投影片上的本地圖形有何不同？**

基礎佔位符是版面或母片上原始的圖形，投影片的圖形會從其繼承類型、位置及部分格式。本地圖形則是獨立的；若不存在基礎佔位符，則不會套用繼承。

**如何在不遍歷每一張投影片的情況下，更新整個簡報內的所有標題或說明文字？**

編輯版面或母片上的相應佔位符。基於這些版面/母片的投影片會自動繼承此變更。

**如何控制標準的頁首/頁尾佔位符—日期與時間、投影片編號以及頁尾文字？**

在適當的範圍（普通投影片、版面、母片、備註/講義）使用 HeaderFooter 管理器，以開啟或關閉這些佔位符並設定其內容。