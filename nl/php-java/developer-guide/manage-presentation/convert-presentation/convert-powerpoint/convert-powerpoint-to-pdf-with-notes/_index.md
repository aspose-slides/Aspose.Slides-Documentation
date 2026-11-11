---
title: Converteer PowerPoint-presentaties naar PDF met notities in PHP
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
description: "Converteer formaten PPT en PPTX naar PDF met notities met Aspose.Slides voor PHP via Java. Behoud lay-outs en sprekernotities voor professionele presentaties."
---
## **Overzicht**

In dit artikel leert u hoe u PowerPoint‑presentaties kunt omzetten naar PDF‑formaat met spreker­notities met behulp van Aspose.Slides. Deze gids behandelt de benodigde stappen en biedt code‑voorbeelden om deze taak efficiënt uit te voeren. Aan het eind van dit artikel kunt u:

- Het conversieproces implementeren om PowerPoint‑dia’s om te zetten naar PDF‑documenten terwijl de spreker­notities behouden blijven.
- De uitvoer‑PDF aanpassen zodat de spreker­notities worden opgenomen en opgemaakt volgens uw eisen.

Om de afmetingen en oriëntatie van de notitie‑pagina in te stellen vóór export, zie [Notes Page Size](/slides/nl/php-java/notes-size/).

## **PowerPoint converteren naar PDF met notities**

De `save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie om te zetten naar een PDF met spreker­notities. Met Aspose.Slides laadt u simpelweg de presentatie, configureert u de lay‑outopties met de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notescommentslayoutingoptions/)‑klasse om spreker­notities op te nemen, en slaat u vervolgens het bestand op als PDF. De volgende code‑fragment laat zien hoe u een voorbeeldpresentatie naar een PDF kunt omzetten in de weergave Notities‑dia.

```php
$presentation = new Presentation("sample.pptx");

// Configureer PDF-opties voor het renderen van sprekernotities.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Render sprekernotities onder de dia.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Sla de presentatie op als PDF met sprekernotities.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}

U wilt misschien de Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/nl/conversion) bekijken.

{{% /alert %}}