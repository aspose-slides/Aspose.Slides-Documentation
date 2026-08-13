---
title: PowerPoint-presentaties converteren naar TIFF met notities in C++
linktitle: PowerPoint naar TIFF met notities
type: docs
weight: 100
url: /nl/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar TIFF
- presentatie naar TIFF
- dia naar TIFF
- PPT naar TIFF
- PPTX naar TIFF
- PPT opslaan als TIFF
- PPTX opslaan als TIFF
- PPT exporteren naar TIFF
- PPTX exporteren naar TIFF
- PowerPoint met notities
- presentatie met notities
- dia met notities
- PPT met notities
- PPTX met notities
- TIFF met notities
- C++
- Aspose.Slides
description: "Converteer PowerPoint-presentaties naar TIFF met notities met behulp van Aspose.Slides voor C++. Leer hoe u dia’s met spreker-notities efficiënt kunt exporteren."
---
## **Inleiding**

Aspose.Slides for C++ biedt een eenvoudige oplossing voor het converteren van PowerPoint‑ en OpenDocument‑presentaties (PPT, PPTX en ODP) met notities naar het TIFF‑formaat. Dit formaat wordt veel gebruikt voor opslag van afbeeldingen van hoge kwaliteit, afdrukken en documentarchivering. Met Aspose.Slides kun je niet alleen volledige presentaties met spreker‑notities exporteren, maar ook miniatuur‑dia’s genereren in de Notities‑dia‑weergave. Het converteerproces is eenvoudig en efficiënt, en maakt gebruik van de `Save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse om de volledige presentatie om te zetten naar een reeks TIFF‑afbeeldingen terwijl de notities en lay‑out behouden blijven.

## **Een presentatie converteren naar TIFF met notities**

Het opslaan van een PowerPoint‑ of OpenDocument‑presentatie naar TIFF met notities met Aspose.Slides for C++ omvat de volgende stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse: laad een PowerPoint‑ of OpenDocument‑bestand.  
2. Configureer de uitvoer‑lay‑outopties: gebruik de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑klasse om op te geven hoe notities en opmerkingen moeten worden weergegeven.  
3. Sla de presentatie op als TIFF: geef de geconfigureerde opties door aan de [Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑methode.

Stel dat we een bestand “speaker_notes.pptx” hebben met de volgende dia:

![De presentatiedia met spreker‑notities](slide_with_notes.png)

De code‑fragment hieronder toont hoe je de presentatie converteert naar een TIFF‑afbeelding in de Notities‑dia‑weergave met de [set_SlidesLayoutOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/)‑methode.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de Presentation-klasse die een presentatiebestand representeert.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Geef de notities onder de dia weer.

// Configureer de TIFF-opties met notitie lay-out.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Sla de presentatie op als TIFF met de spreker-notities.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Het resultaat:

![De TIFF‑afbeelding met spreker‑notities](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Bekijk de gratis Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### Kan ik de positie van het notitiegebied in de resulterende TIFF aanpassen?

Ja. Gebruik de [notes layout settings](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) om te kiezen uit opties zoals `None`, `BottomTruncated` of `BottomFull`, die respectievelijk notities verbergen, ze in één pagina passen of ze laten doorlopen naar extra pagina’s.

### Hoe kan ik de grootte van een TIFF‑bestand met notities verkleinen zonder zichtbaar kwaliteitsverlies?

Kies een [efficient compression](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (bijv. `LZW` of `RLE`), stel een redelijke DPI in en gebruik, indien acceptabel, een lager [pixel format](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (zoals 8 bpp of 1 bpp voor monochroom). Het iets verkleinen van de [image dimensions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_imagesize/) kan ook helpen zonder de leesbaarheid merkbaar te schaden.

### Heeft het lettertype in de notities invloed op het resultaat als de oorspronkelijke lettertypen ontbreken op het systeem?

Ja. Ontbrekende lettertypen activeren [substitution](/slides/nl/cpp/font-selection-sequence/), wat de tekstmetriek en weergave kan veranderen. Om dit te voorkomen, [supply the required fonts](/slides/nl/cpp/custom-font/) of stel een standaard [fallback font](/slides/nl/cpp/fallback-font/) in zodat de beoogde lettertypen worden gebruikt.