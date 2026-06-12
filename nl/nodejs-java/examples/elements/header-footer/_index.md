---
title: Koptekst Voettekst
type: docs
weight: 220
url: /nl/nodejs-java/examples/elements/header-footer/
keywords:
- code voorbeeld
- koptekst
- voettekst
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer slide-kopteksten en voetteksten met Aspose.Slides voor Node.js: voeg datums, slide-nummers en aangepaste tekst toe in PPT, PPTX en ODP met JavaScript-voorbeelden."
---
Dit artikel laat zien hoe u voetteksten kunt toevoegen en datum‑ en tijd‑plaatsaanduidingen kunt bijwerken met **Aspose.Slides for Node.js via Java**.

## **Voettekst toevoegen**

Voeg tekst toe aan het voettekstgebied van een dia en maak deze zichtbaar.

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

## **Datum en tijd bijwerken**

Wijzig de datum‑ en tijd‑plaatsaanduiding op een dia.

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