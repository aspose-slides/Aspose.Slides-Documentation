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
- sprekernotities
- PDF met notities
- C++
- Aspose.Slides
description: "Converteer de formaten PPT en PPTX naar PDF met notities met behulp van Aspose.Slides voor C++. Behoud lay-outs en sprekernotities voor professionele presentaties."
---
## **Overzicht**

In dit artikel leert u hoe u PowerPoint‑presentaties kunt converteren naar PDF‑formaat met sprekersnotities met behulp van Aspose.Slides. Deze gids behandelt de benodigde stappen en biedt code‑voorbeelden om deze taak efficiënt uit te voeren. Aan het einde van dit artikel kunt u:

- Het conversieproces implementeren om PowerPoint‑dia's om te zetten naar PDF‑documenten, waarbij de sprekersnotities behouden blijven.
- De uitvoer‑PDF aanpassen zodat de sprekersnotities worden opgenomen en opgemaakt volgens uw vereisten.

## **PowerPoint naar PDF converteren met notities**

De `Save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie te converteren naar een PDF met sprekersnotities. Met Aspose.Slides laadt u eenvoudig de presentatie, configureert u de lay‑outopties met behulp van de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑klasse om sprekersnotities op te nemen, en slaat u het bestand vervolgens op als PDF. Het volgende codefragment toont hoe u een voorbeeldpresentatie kunt converteren naar een PDF in de Notities‑diaweergave.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Render sprekersnotities onder de dia.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
U wilt misschien de Aspose [Online PowerPoint naar PDF Converter](https://products.aspose.app/slides/nl/conversion) bekijken. 
{{% /alert %}}