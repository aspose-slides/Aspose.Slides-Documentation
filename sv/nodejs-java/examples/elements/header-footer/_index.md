---
title: Sidhuvud och sidfot
type: docs
weight: 220
url: /sv/nodejs-java/examples/elements/header-footer/
keywords:
- kodexempel
- sidhuvud
- sidfot
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Styr bildsidhuvuden och sidfötter med Aspose.Slides för Node.js: lägg till datum, bildnummer och anpassad text i PPT, PPTX och ODP med JavaScript-exempel."
---
Den här artikeln visar hur man lägger till sidfötter och uppdaterar datum- och tidsplatshållare med **Aspose.Slides for Node.js via Java**.

## **Lägg till en sidfot**

Lägg till text i sidfotområdet på en bild och gör den synlig.

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

## **Uppdatera datum och tid**

Ändra datum- och tidsplatshållaren på en bild.

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