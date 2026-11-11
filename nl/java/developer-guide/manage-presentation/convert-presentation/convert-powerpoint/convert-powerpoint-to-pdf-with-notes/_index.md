---
title: PowerPoint-presentaties converteren naar PDF met notities in Java
linktitle: PowerPoint naar PDF met notities
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
description: "Converteer PPT- en PPTX-formaten naar PDF met notities met behulp van Aspose.Slides voor Java. Bewaar lay-outs en sprekernotities voor professionele presentaties."
---
## **Overzicht**

In dit artikel leert u hoe u PowerPoint‑presentaties kunt converteren naar PDF‑formaat met spreker­notities met behulp van Aspose.Slides. Deze gids behandelt de benodigde stappen en biedt code‑voorbeelden om deze taak efficiënt uit te voeren. Aan het einde van dit artikel kunt u:

- Het conversieproces implementeren om PowerPoint‑dia's om te zetten in PDF‑documenten met behoud van de spreker­notities.
- De uitgevoerde PDF aanpassen zodat de spreker­notities worden opgenomen en geformatteerd volgens uw eisen.

Om de afmetingen en uitlijning van de notitiepagina vóór export in te stellen, zie [Notes Page Size](/slides/nl/java/notes-size/).

## **PowerPoint naar PDF converteren met notities**

De `save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie te converteren naar een PDF met spreker­notities. Met Aspose.Slides laadt u eenvoudig de presentatie, configureert u de lay‑outopties met behulp van de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notescommentslayoutingoptions/)‑klasse om spreker­notities op te nemen, en slaat u het bestand vervolgens op als PDF. De volgende code‑fragment toont hoe u een voorbeeldpresentatie naar een PDF in Notities‑dia‑weergave converteert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Configureren van PDF-opties voor het weergeven van sprekernotities.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Render sprekernotities onder de dia.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Sla de presentatie op als PDF met sprekernotities.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
U wilt misschien de Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/nl/conversion) bekijken.
{{% /alert %}}