---
title: 在 JavaScript 中管理簡報頁首與頁尾
linktitle: 頁首與頁尾
type: docs
weight: 140
url: /zh-hant/nodejs-java/presentation-header-and-footer/
keywords:
- 頁首
- 頁首文字
- 頁尾
- 頁尾文字
- 設定頁首
- 設定頁尾
- 講義
- 備註
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 與 Aspose.Slides for Node.js 在 PowerPoint 與 OpenDocument 簡報中新增與自訂頁首與頁尾，打造專業外觀。"
---
## **概觀**

Aspose.Slides 允許您在 PowerPoint 簡報中管理頁首與頁尾設定。頁首與頁尾在簡報主體層級進行處理，API 提供設定頁尾文字、變更頁尾可見性以及在主備註投影片上更新頁首文字的方法。

您也可以管理講義與備註投影片的頁首與頁尾。這包括變更備註主體、所有子備註投影片或單一備註投影片的頁首、頁尾、投影片編號與日期時間佔位符的可見性與文字。

## **在簡報中管理頁首與頁尾**
以下範例示範了可移除特定投影片的備註：

```javascript
// 載入簡報
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // 設定頁尾
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // 存取並更新頁首
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // 儲存簡報
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **在講義與備註投影片中管理頁首與頁尾**
Aspose.Slides for Node.js via Java 支援在講義與備註投影片中設定頁首與頁尾。請依照以下步驟操作：

- 載入包含影片的[簡報](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation)。
- 變更備註主體與所有備註投影片的頁首與頁尾設定。
- 將主備註投影片及所有子投影片的頁尾佔位符設為可見。
- 將主備註投影片及所有子投影片的日期時間佔位符設為可見。
- 僅變更第一張備註投影片的頁首與頁尾設定。
- 將備註投影片的頁首佔位符設為可見。
- 設定備註投影片頁首佔位符的文字。
- 設定備註投影片日期時間佔位符的文字。
- 寫入已修改的簡報檔案。

Code Snippet provided in below Example.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // 變更備註主體及所有備註投影片的頁首與頁尾設定
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// 使主備註投影片與所有子頁尾佔位符可見
        headerFooterManager.setFooterAndChildFootersVisibility(true);// 使主備註投影片與所有子頁首佔位符可見
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// 使主備註投影片與所有子投影片編號佔位符可見
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// 使主備註投影片與所有子日期時間佔位符可見
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// 設定文字至主備註投影片與所有子頁首佔位符
        headerFooterManager.setFooterAndChildFootersText("Footer text");// 設定文字至主備註投影片與所有子頁尾佔位符
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// 設定文字至主備註投影片與所有子日期時間佔位符
    }
    // 僅變更第一張備註投影片的頁首與頁尾設定
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// 使此備註投影片的頁首佔位符可見
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// 使此備註投影片的頁尾佔位符可見
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// 使此備註投影片的投影片編號佔位符可見
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// 使此備註投影片的日期時間佔位符可見
        headerFooterManager.setHeaderText("New header text");// 設定文字至備註投影片的頁首佔位符
        headerFooterManager.setFooterText("New footer text");// 設定文字至備註投影片的頁尾佔位符
        headerFooterManager.setDateTimeText("New date and time text");// 設定文字至備註投影片的日期時間佔位符
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以在一般投影片加入「頁首」嗎？**

在 PowerPoint 中，「頁首」僅存在於備註與講義；在一般投影片上，支援的元素只有頁尾、日期/時間以及投影片編號。Aspose.Slides 亦遵循相同限制：頁首僅適用於備註/講義，而投影片僅支援頁尾、日期時間及投影片編號。

**如果版面配置沒有頁尾區域，我可以「開啟」其可見性嗎？**

可以。透過頁首/頁尾管理器檢查可見性，必要時將其啟用。這些 API 指標與方法專為佔位符缺失或被隱藏的情況設計。

**如何讓投影片編號從非 1 的數值開始？**

設定簡報的[首張投影片編號](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/setfirstslidenumber/)；之後所有編號會重新計算。例如，您可以從 0 或 10 開始，並在標題投影片上隱藏編號。

**匯出為 PDF/圖片/HTML 時，頁首/頁尾會發生什麼情況？**

它們會被渲染為簡報的普通文字元素。也就是說，只要在投影片或備註頁面上可見，這些元素亦會隨同其餘內容一起出現在輸出格式中。