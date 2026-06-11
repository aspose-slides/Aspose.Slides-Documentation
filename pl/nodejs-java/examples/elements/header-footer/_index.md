---
title: Nagłówek i stopka
type: docs
weight: 220
url: /pl/nodejs-java/examples/elements/header-footer/
keywords:
- przykład kodu
- nagłówek
- stopka
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Steruj nagłówkami i stopkami slajdów przy użyciu Aspose.Slides for Node.js: dodawaj daty, numery slajdów i własny tekst w formatach PPT, PPTX i ODP przy pomocy przykładów JavaScript."
---
Ten artykuł pokazuje, jak dodać stopki oraz zaktualizować znaczniki daty i godziny przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj stopkę**

Dodaj tekst do obszaru stopki slajdu i spraw, aby był widoczny.

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

## **Zaktualizuj datę i godzinę**

Zmień znacznik daty i godziny na slajdzie.

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