---
title: Záhlaví a zápatí
type: docs
weight: 220
url: /cs/nodejs-java/examples/elements/header-footer/
keywords:
- příklad kódu
- záhlaví
- zápatí
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Ovládejte záhlaví a zápatí snímků pomocí Aspose.Slides pro Node.js: přidejte data, čísla snímků a vlastní text v PPT, PPTX a ODP pomocí JavaScriptových příkladů."
---
Tento článek ukazuje, jak přidat zápatí a aktualizovat zástupné texty data a času pomocí **Aspose.Slides for Node.js via Java**.

## **Přidat zápatí**

Přidejte text do oblasti zápatí snímku a zajistěte, aby byl viditelný.

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

## **Aktualizovat datum a čas**

Upravte zástupný text data a času na snímku.

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