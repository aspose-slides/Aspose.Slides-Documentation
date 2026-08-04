---
title: Header Footer
type: docs
weight: 220
url: /nodejs-java/examples/elements/header-footer/
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
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Make the placeholder visible first - setting the text on a hidden
        // footer has no effect.
        slide.getHeaderFooterManager().setFooterVisibility(true);
        slide.getHeaderFooterManager().setFooterText("My footer");

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Update Date and Time**

Modify the date and time placeholder on a slide.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Make the placeholder visible first - setting the text on a hidden
        // date and time placeholder has no effect.
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```
