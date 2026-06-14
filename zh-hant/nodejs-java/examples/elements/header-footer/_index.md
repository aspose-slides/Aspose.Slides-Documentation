---
title: 頁眉與頁腳
type: docs
weight: 220
url: /zh-hant/nodejs-java/examples/elements/header-footer/
keywords:
- 程式碼範例
- 頁眉
- 頁腳
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 控制投影片的頁眉與頁腳：在 PPT、PPTX 與 ODP 中加入日期、投影片編號以及自訂文字，並提供 JavaScript 範例。"
---
本文示範如何使用 **Aspose.Slides for Node.js via Java** 新增頁腳並更新日期與時間佔位符。

## **新增頁腳**

在投影片的頁腳區域加入文字並使其可見。

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **更新日期與時間**

在投影片上修改日期與時間佔位符。

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```