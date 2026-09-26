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
description: "Formaten PPT en PPTX converteren naar PDF met notities met behulp van Aspose.Slides voor C++. Lay-outs en sprekernotities behouden voor professionele presentaties."
---
## **Overzicht**

In dit artikel leert u hoe u PowerPoint‑presentaties kunt converteren naar PDF‑formaat met sprekersnotities met behulp van Aspose.Slides. Deze gids behandelt de benodigde stappen en biedt code‑voorbeelden om deze taak efficiënt uit te voeren. Aan het einde van dit artikel kunt u:

- Implementeer het conversieproces om PowerPoint‑dia’s om te zetten naar PDF‑documenten met behoud van de sprekersnotities.
- Pas de output‑PDF aan zodat de sprekersnotities worden opgenomen en opgemaakt volgens uw wensen.

Om de afmetingen en oriëntatie van de notitiepagina vóór export in te stellen, zie [Notitiepaginaformaat](/slides/nl/cpp/notes-size/).

## **PowerPoint converteren naar PDF met notities**

De `Save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie te converteren naar een PDF met sprekersnotities. Met Aspose.Slides laadt u eenvoudig de presentatie, configureert u de lay‑outopties met de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑klasse om sprekersnotities op te nemen, en slaat u vervolgens het bestand op als PDF. De onderstaande code‑fragment toont hoe u een voorbeeldpresentatie naar een PDF in Notitie‑diaweergave converteert.

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
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Render sprekernotities onder de dia.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
U wilt misschien de Aspose [Online PowerPoint naar PDF‑conversie](https://products.aspose.app/slides/nl/conversion) bekijken.
{{% /alert %}}