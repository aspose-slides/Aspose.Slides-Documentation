---
title: Header Footer
type: docs
weight: 220
url: /nodejs-java/examples/elements/elements/headerfooter/
keywords:
- code example
- header
- footer
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Control slide headers and footers with Aspose.Slides for Node.js: add dates, slide numbers, and custom text in PPT, PPTX, and ODP with JavaScript examples."
---

This article demonstrates how to add footers and update date and time placeholders using **Aspose.Slides for Node.js via Java**.

## **Add a Footer**

Add text to the footer area of a slide and make it visible.

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

## **Update Date and Time**

Modify the date and time placeholder on a slide.

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
