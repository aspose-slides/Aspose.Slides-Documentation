---
title: 在 JavaScript 中比較簡報投影片
linktitle: 比較投影片
type: docs
weight: 50
url: /zh-hant/nodejs-java/compare-slides/
keywords:
- 比較投影片
- 投影片比較
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 透過 Java 程式化比較 PowerPoint 與 OpenDocument 簡報。快速在程式碼中辨識投影片差異。"
---
## **概覽**

Aspose.Slides 允許您使用 `BaseSlide` 類別提供的 `equals` 方法比較投影片、版面投影片以及母片投影片。當比較的投影片在結構與靜態內容上完全相同時，該方法會回傳 `true`。

## **比較兩張投影片**

`equals` 方法已新增至 [BaseSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/BaseSlide) 類別與 [BaseSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/BaseSlide) 類別。它會對具有相同結構與靜態內容的投影片/版面以及投影片/母片回傳 true。

兩張投影片相等的條件是所有形狀、樣式、文字、動畫以及其他設定等皆相同。比較不會考慮唯一識別碼值，例如 SlideId，亦不會考慮動態內容，例如日期佔位符中的當前日期值。

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **常見問題**

**隱藏投影片是否會影響投影片本身的比較？**

[Hidden status](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/gethidden/) 是簡報/播放層級的屬性，非視覺內容。兩張特定投影片的相等性由其結構與靜態內容決定；僅因投影片被隱藏並不會使投影片不同。

**是否會考慮超連結及其參數？**

會。連結屬於投影片的靜態內容。若 URL 或超連結動作不同，通常會被視為靜態內容的差異。

**如果圖表引用了外部 Excel 檔案，會將該檔案的內容納入比較嗎？**

不會。比較是基於投影片本身執行。外部資料來源通常不會在比較時讀取；僅考慮投影片結構與靜態狀態中存在的內容。