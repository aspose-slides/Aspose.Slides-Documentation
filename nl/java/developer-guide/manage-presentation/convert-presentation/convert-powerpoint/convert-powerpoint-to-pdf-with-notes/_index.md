---
title: Convert PowerPoint Presentaties naar PDF met Notities in Java
linktitle: PowerPoint naar PDF met Notities
type: docs
weight: 50
url: /nl/java/convert-powerpoint-to-pdf-with-notes/
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
- Java
- Aspose.Slides
description: Converteer de formaten PPT en PPTX naar PDF met notities met behulp van Aspose.Slides voor Java. Behoud lay‑outs en sprekernotities voor professionele presentaties.
---
## **Overzicht**

In dit artikel leert u hoe u PowerPoint‑presentaties kunt converteren naar PDF‑formaat met spreker notities met behulp van Aspose.Slides. Deze gids behandelt de nodige stappen en biedt codevoorbeelden om u te helpen deze taak efficiënt uit te voeren. Aan het einde van dit artikel kunt u:

- Implementeer het conversieproces om PowerPoint‑dia’s te transformeren naar PDF‑documenten terwijl u de spreker notities behoudt.
- Pas de uitvoer‑PDF aan om ervoor te zorgen dat de spreker notities worden opgenomen en geformatteerd volgens uw wensen.

## **PowerPoint converteren naar PDF met notities**

De `save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie te converteren naar een PDF met spreker notities. Met Aspose.Slides laadt u eenvoudig de presentatie, configureert u de lay‑outopties met behulp van de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notescommentslayoutingoptions/)‑klasse om spreker notities op te nemen, en slaat u vervolgens het bestand op als PDF. Het onderstaande code‑fragment laat zien hoe een voorbeeldpresentatie wordt geconverteerd naar een PDF in de Notities‑Dia‑weergave.

```java
Presentation presentation = new Presentation("sample.pptx");

// Configureer PDF-opties voor het renderen van sprekernotities.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Render sprekernotities onder de dia.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Sla de presentatie op als PDF met sprekernotities.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
U wilt misschien de Aspose [Online PowerPoint naar PDF Converter](https://products.aspose.app/slides/nl/conversion) bekijken. 
{{% /alert %}}