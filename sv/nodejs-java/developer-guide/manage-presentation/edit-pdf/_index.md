---
title: Redigera PDF-dokument i JavaScript
linktitle: Redigera PDF
type: docs
weight: 65
url: /sv/nodejs-java/edit-pdf/
keywords:
- redigera PDF
- ersätt PDF-text
- PDF till PPTX
- PPTX till PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "Redigera PDF-dokument i JavaScript genom att importera dem till Aspose.Slides, ersätta text och spara den modifierade presentationen tillbaka till PDF."
---
## **Översikt**

Aspose.Slides for Node.js via Java låter dig redigera PDF‑innehåll genom att importera dess sidor som slides, ändra presentationen och exportera den tillbaka till PDF. Den här artikeln visar ett enkelt textutbyte. Presentationen finns kvar i minnet, så att spara en mellanliggande PPTX‑fil är valfritt.

## **Ersätt text i en PDF**

Använd [addFromPdf](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/#addFromPdf) för att importera sidorna, [replaceText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#replaceText) för att uppdatera texten och [save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) för att exportera resultatet.

Följande exempel förutsätter att `input.pdf` innehåller ordet "Draft" som redigerbar text efter import. Det ersätter det ordet med "Final" och skriver `edited.pdf`. Att rensa den första sliden innan import förhindrar en extra tom sida i resultatet. Sökningen matchar hela ord med samma skiftläge; `null` betyder att ingen resultat‑callback behövs.

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

För fler alternativ, se [Search and Replace Text](/slides/sv/nodejs-java/search-and-replace-text/) och [Convert PowerPoint to PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Textutbyte fungerar på importerad text, inte på text i skannade bilder. Konverteringen kan påverka layout och formatering, så granska resultatet, särskilt när den ersatta texten är längre än originalet.
{{% /alert %}}

## **FAQ**

**Behöver jag spara en PPTX‑fil innan jag exporterar PDF‑filen?**

Nej. Du kan redigera och exportera samma presentation i minnet. Spara en PPTX‑kopia endast om du också vill fortsätta redigera den i PowerPoint; se [Save Presentations](/slides/sv/nodejs-java/save-presentation/).

**Varför kan viss text förbli oförändrad?**

Exemplet matchar hela ordet "Draft" med exakt skiftläge. Text som importeras som en bild eller som är uppdelad i separata textramar kommer inte nödvändigtvis att matcha sökningen. Kontrollera det importerade innehållet och justera sökningen för ditt dokument.