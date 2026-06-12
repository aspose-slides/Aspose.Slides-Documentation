---
title: PowerPoint-presentaties converteren naar PDF met notities in C++
linktitle: PowerPoint naar PDF met notities
type: docs
weight: 50
url: /nl/cpp/convert-powerpoint-to-pdf-with-notes/
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
- spreker-notities
- PDF met notities
- C++
- Aspose.Slides
description: "Converteer de formaten PPT en PPTX naar PDF met notities met behulp van Aspose.Slides voor C++. Behoud lay-outs en spreker-notities voor professionele presentaties."
---
## **Overzicht**

In dit artikel leert u hoe u PowerPoint‑presentaties kunt omzetten naar PDF‑formaat met spreker­notities met behulp van Aspose.Slides. Deze gids behandelt de noodzakelijke stappen en biedt code‑voorbeelden om deze taak efficiënt uit te voeren. Aan het einde van dit artikel kunt u:

- Het conversieproces implementeren om PowerPoint‑dia’s om te zetten naar PDF‑documenten, terwijl de spreker­notities behouden blijven.
- De uitgaande PDF aanpassen zodat de spreker­notities worden opgenomen en volgens uw wensen worden opgemaakt.

## **PowerPoint omzetten naar PDF met notities**

De `Save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie om te zetten naar een PDF met spreker­notities. Met Aspose.Slides laadt u eenvoudig de presentatie, configureert u de layoutopties met de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑klasse om spreker­notities op te nemen, en slaat u het bestand vervolgens op als PDF. Het volgende code‑fragment laat zien hoe u een voorbeeldpresentatie kunt omzetten naar een PDF in notities‑diaweergave.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configureer PDF‑opties voor het renderen van spreker‑notities.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Render spreker‑notities onder de dia.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Sla de presentatie op als PDF met spreker‑notities.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 

U wilt misschien de Aspose [Online PowerPoint‑naar‑PDF Converter](https://products.aspose.app/slides/nl/conversion). 

{{% /alert %}}