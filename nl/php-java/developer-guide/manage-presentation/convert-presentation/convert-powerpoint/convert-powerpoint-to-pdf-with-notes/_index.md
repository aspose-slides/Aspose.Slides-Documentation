---
title: PowerPoint-presentaties converteren naar PDF met notities in PHP
linktitle: PowerPoint naar PDF met notities
type: docs
weight: 50
url: /nl/php-java/convert-powerpoint-to-pdf-with-notes/
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
- PHP
- Aspose.Slides
description: "Converteer de formaten PPT en PPTX naar PDF met notities met behulp van Aspose.Slides voor PHP via Java. Behoud lay-outs en sprekernotities voor professionele presentaties."
---
## **Overzicht**

In dit artikel leert u hoe u PowerPoint‑presentaties kunt omzetten naar PDF‑formaat met sprekernotities met behulp van Aspose.Slides. Deze gids behandelt de noodzakelijke stappen en levert code‑voorbeelden om deze taak efficiënt uit te voeren. Aan het einde van dit artikel kunt u:

- Het conversieproces implementeren om PowerPoint‑dia's om te zetten naar PDF‑documenten, waarbij de sprekernotities behouden blijven.
- De gegenereerde PDF aanpassen zodat de sprekernotities zijn opgenomen en opgemaakt volgens uw wensen.

## **PowerPoint omzetten naar PDF met sprekernotities**

De `save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie om te zetten naar een PDF met sprekernotities. Met Aspose.Slides laadt u eenvoudig de presentatie, configureert u de layout‑opties met behulp van de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notescommentslayoutingoptions/)‑klasse om sprekernotities op te nemen, en slaat u het bestand vervolgens op als PDF. De volgende code‑fragment toont hoe u een voorbeeldpresentatie omzet naar een PDF in de notities‑diaweergave.

```php
$presentation = new Presentation("sample.pptx");

// Configureer PDF-opties voor het weergeven van sprekernotities.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Render sprekernotities onder de dia.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Sla de presentatie op als PDF met sprekernotities.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 
U kunt ook de Aspose [Online PowerPoint naar PDF Converter](https://products.aspose.app/slides/nl/conversion) uitproberen. 
{{% /alert %}}