---
title: 页眉页脚
type: docs
weight: 220
url: /zh/nodejs-java/examples/elements/header-footer/
keywords:
- 代码示例
- 页眉
- 页脚
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 控制幻灯片的页眉和页脚：在 PPT、PPTX 和 ODP 中添加日期、幻灯片编号和自定义文本，提供 JavaScript 示例。"
---
本文演示如何使用 **Aspose.Slides for Node.js via Java** 添加页脚并更新日期和时间占位符。

## **添加页脚**
在幻灯片的页脚区域添加文字并使其可见。

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

## **更新日期和时间**
修改幻灯片上的日期和时间占位符。

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