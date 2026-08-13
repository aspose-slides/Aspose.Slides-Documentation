---
title: PowerPoint-presentaties naar PDF converteren met notities op Android
linktitle: PowerPoint naar PDF met notities
type: docs
weight: 50
url: /nl/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Converteer de formaten PPT en PPTX naar PDF met notities met behulp van Aspose.Slides voor Android via Java. Behoud de lay-out en sprekernotities voor professionele presentaties."
---
## **Overzicht**

In dit artikel leert u hoe u PowerPoint‑presentaties kunt converteren naar PDF‑formaat met spreker­notities met behulp van Aspose.Slides. Deze gids behandelt de benodigde stappen en bevat codevoorbeelden om deze taak efficiënt uit te voeren. Aan het einde van dit artikel kunt u:

- Het conversieproces implementeren om PowerPoint‑dia's om te zetten naar PDF‑documenten waarbij de spreker­notities behouden blijven.
- De uitvoer‑PDF aanpassen zodat de spreker­notities worden opgenomen en geformatteerd volgens uw wensen.

## **PowerPoint naar PDF converteren met notities**

De `save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie te converteren naar een PDF met spreker­notities. Met Aspose.Slides laadt u eenvoudig de presentatie, configureert u de lay‑outopties met behulp van de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notescommentslayoutingoptions/)‑klasse om spreker­notities op te nemen, en slaat u het bestand vervolgens op als PDF. Het onderstaande code‑fragment toont hoe u een voorbeeldpresentatie converteert naar een PDF in notities‑diaweergave.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Configureer PDF-opties voor het weergeven van sprekernotities.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Render sprekernotities onder de dia.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Sla de presentatie op als PDF met sprekernotities.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 
U wilt misschien de Aspose [Online PowerPoint naar PDF Converter](https://products.aspose.app/slides/nl/conversion) bekijken. 
{{% /alert %}}