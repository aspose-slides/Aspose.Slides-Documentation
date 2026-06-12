---
title: PowerPoint-presentaties converteren naar PDF met notities in JavaScript
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
- sprekernotities
- PDF met notities
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer de formaten PPT en PPTX naar PDF met notities in JavaScript met Aspose.Slides voor Node.js. Behoud lay-outs en sprekernotities voor professionele presentaties."
---
## **Overzicht**

In dit artikel leert u hoe u PowerPoint‑presentaties kunt omzetten naar PDF‑formaat met spreker­notities met behulp van Aspose.Slides. Deze gids behandelt de benodigde stappen en biedt code‑voorbeelden om deze taak efficiënt uit te voeren. Aan het einde van dit artikel kunt u:

- Het conversieproces implementeren om PowerPoint‑dia's om te zetten naar PDF‑documenten terwijl de spreker­notities behouden blijven.
- De gegenereerde PDF aanpassen zodat de spreker­notities worden opgenomen en opgemaakt volgens uw vereisten.

## **PowerPoint converteren naar PDF met notities**

De `save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie om te zetten naar een PDF met spreker­notities. Met Aspose.Slides laadt u eenvoudig de presentatie, configureert u de lay‑outopties met de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notescommentslayoutingoptions/)‑klasse om spreker­notities op te nemen, en slaat u vervolgens het bestand op als PDF. Het volgende code‑fragment toont hoe u een voorbeeldpresentatie kunt omzetten naar een PDF in de Notities‑dia‑weergave.

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// Configureer PDF-opties voor het renderen van spreker-notities.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Render spreker-notities onder de dia.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Sla de presentatie op als PDF met spreker-notities.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 

U wilt wellicht de Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/nl/conversion) bekijken. 

{{% /alert %}}