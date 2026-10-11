---
title: PowerPoint‑presentaties naar PDF converteren met notities in JavaScript
linktitle: PowerPoint naar PDF met notities
type: docs
weight: 50
url: /nl/nodejs-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PDF
- presentatie naar PDF
- dia naar PDF
- PPT naar PDF
- PPTX naar PDF
- presentatie opslaan als PDF
- PPT opslaan als PDF
- PPTX opslaan als PDF
- PPT exporteren naar PDF
- PPTX exporteren naar PDF
- spreker‑notities
- PDF met notities
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer de formaten PPT en PPTX naar PDF met notities in JavaScript met Aspose.Slides voor Node.js. Behoud de lay‑outs en spreker‑notities voor professionele presentaties."
---
## **Overzicht**

In dit artikel leer je hoe je PowerPoint‑presentaties naar PDF‑formaat met spreker‑notities kunt converteren met Aspose.Slides. Deze gids behandelt de benodigde stappen en geeft codevoorbeelden om deze taak efficiënt uit te voeren. Aan het einde van dit artikel kun je:

- Het conversieproces implementeren om PowerPoint‑dia’s om te zetten naar PDF‑documenten terwijl de spreker‑notities behouden blijven.
- De uitvoer‑PDF aanpassen zodat de spreker‑notities zijn opgenomen en opgemaakt volgens jouw eisen.

Om de afmetingen en oriëntatie van de notitiepagina in te stellen vóór export, zie [Notitiepagina grootte](/slides/nl/nodejs-java/notes-size/).

## **PowerPoint naar PDF converteren met notities**

`save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie te converteren naar een PDF met spreker‑notities. Met Aspose.Slides laad je simpelweg de presentatie, configureer je de lay‑outopties met de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notescommentslayoutingoptions/) klasse om spreker‑notities op te nemen, en sla je het bestand vervolgens op als PDF. Het volgende code‑fragment toont hoe je een voorbeeldpresentatie kunt converteren naar een PDF in notities‑diaweergave.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// Configureer PDF-opties voor het renderen van spreker-notities.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Render spreker-notities onder de dia.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Opmerking" %}}
Je kunt de Aspose [Online PowerPoint naar PDF Converter](https://products.aspose.app/slides/nl/conversion) bekijken.
{{% /alert %}}