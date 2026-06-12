---
title: Intestazione Piè di pagina
type: docs
weight: 220
url: /it/nodejs-java/examples/elements/header-footer/
keywords:
- esempio di codice
- intestazione
- piè di pagina
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci le intestazioni e i piè di pagina delle diapositive con Aspose.Slides per Node.js: aggiungi date, numeri di diapositiva e testo personalizzato in PPT, PPTX e ODP con esempi JavaScript."
---
Questo articolo dimostra come aggiungere piè di pagina e aggiornare i segnaposto di data e ora utilizzando **Aspose.Slides for Node.js via Java**.

## **Aggiungi un piè di pagina**
Aggiungi del testo all'area del piè di pagina di una diapositiva e rendilo visibile.

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

## **Aggiorna data e ora**
Modifica il segnaposto di data e ora su una diapositiva.

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