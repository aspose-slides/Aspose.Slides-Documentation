---
title: PDF-documenten bewerken in JavaScript
linktitle: PDF bewerken
type: docs
weight: 65
url: /nl/nodejs-java/edit-pdf/
keywords:
- PDF bewerken
- PDF-tekst vervangen
- PDF naar PPTX
- PPTX naar PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "Bewerk PDF-documenten in JavaScript door ze te importeren in Aspose.Slides, de tekst te vervangen en de gewijzigde presentatie opnieuw op te slaan als PDF."
---
## **Overzicht**

Aspose.Slides for Node.js via Java stelt je in staat om PDF-inhoud te bewerken door de pagina's te importeren als dia's, de presentatie aan te passen en deze terug te exporteren naar PDF. Dit artikel toont een eenvoudige tekstvervanging. De presentatie blijft in het geheugen, dus het opslaan van een tussentijdse PPTX‑file is optioneel.

## **Tekst vervangen in een PDF**

Gebruik [addFromPdf](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addFromPdf) om de pagina's te importeren, [replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#replaceText) om de tekst bij te werken, en [save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) om het resultaat te exporteren.

Het onderstaande voorbeeld gaat ervan uit dat `input.pdf` het woord "Draft" bevat als bewerkbare tekst na import. Het vervangt dat woord door "Final" en schrijft `edited.pdf`. Het leegmaken van de eerste dia vóór import voorkomt een extra lege pagina in de uitvoer. De zoekopdracht zoekt volledige woorden met dezelfde hoofdlettergevoeligheid; `null` betekent dat er geen result‑callback nodig is.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Voor meer opties, zie [Search and Replace Text](/slides/nl/nodejs-java/search-and-replace-text/) en [Convert PowerPoint to PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Tekstvervanging werkt op geïmporteerde tekst, niet op tekst in gescande afbeeldingen. De conversie kan de lay-out en opmaak beïnvloeden, dus controleer de uitvoer, vooral wanneer de vervangende tekst langer is dan het origineel.
{{% /alert %}}

## **FAQ**

**Moet ik een PPTX‑bestand opslaan voordat ik de PDF exporteer?**

Nee. Je kunt dezelfde presentatie in het geheugen bewerken en exporteren. Sla een PPTX‑kopie alleen op als je deze ook verder wilt bewerken in PowerPoint; zie [Save Presentations](/slides/nl/nodejs-java/save-presentation/).

**Waarom blijft sommige tekst onveranderd?**

Het voorbeeld zoekt naar het volledige woord "Draft" met exacte hoofdlettergevoeligheid. Tekst die is geïmporteerd als afbeelding of die over verschillende tekstframes is verdeeld, zal niet noodzakelijkerwijs overeenkomen met de zoekopdracht. Controleer de geïmporteerde inhoud en pas de zoekopdracht aan voor jouw document.