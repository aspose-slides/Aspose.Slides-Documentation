---
title: PowerPoint‑presentaties converteren naar TIFF met notities in C++
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
description: "PowerPoint‑presentaties converteren naar TIFF met notities met behulp van Aspose.Slides voor C++. Leer hoe u dia's met spreker‑notities efficiënt kunt exporteren."
---
## **Inleiding**

Aspose.Slides for C++ biedt een eenvoudige oplossing voor het converteren van PowerPoint‑ en OpenDocument‑presentaties (PPT, PPTX en ODP) met notities naar het TIFF‑formaat. Dit formaat wordt veel gebruikt voor opslag van hoogwaardige afbeeldingen, afdrukken en documentarchivering. Met Aspose.Slides kunt u niet alleen volledige presentaties met spreker‑notities exporteren, maar ook miniaturen van dia’s genereren in de Notitie‑dia‑weergave. Het conversieproces is eenvoudig en efficiënt en maakt gebruik van de `Save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse om de volledige presentatie om te zetten in een reeks TIFF‑afbeeldingen, waarbij notities en lay‑out behouden blijven.

## **Een presentatie converteren naar TIFF met notities**

Het opslaan van een PowerPoint‑ of OpenDocument‑presentatie naar TIFF met notities met behulp van Aspose.Slides for C++ omvat de volgende stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse: laad een PowerPoint‑ of OpenDocument‑bestand.
2. Stel de opties voor de uitvoer‑lay‑out in: gebruik de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑klasse om op te geven hoe notities en commentaren moeten worden weergegeven.
3. Sla de presentatie op als TIFF: geef de geconfigureerde opties door aan de [Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑methode.

Stel, we hebben een bestand “speaker_notes.pptx” met de volgende dia:

![De presentatiedia met spreker notities](slide_with_notes.png)

De onderstaande code‑fragment toont hoe de presentatie te converteren naar een TIFF‑afbeelding in de Notitie‑dia‑weergave met behulp van de [set_SlidesLayoutOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/)‑methode.

```cpp
// Instantieer de Presentation‑klasse die een presentatie‑bestand voorstelt.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Toon de notities onder de dia.

// Configureer de TIFF‑opties met notitie‑lay‑out.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Sla de presentatie op als TIFF met de spreker‑notities.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Het resultaat:

![De TIFF‑afbeelding met spreker notities](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Bekijk Aspose [Gratis PowerPoint‑naar‑Poster‑converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Veelgestelde vragen**

**Kan ik de positie van het notitie‑gebied in de resulterende TIFF besturen?**

Ja. Gebruik de [notes layout settings](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) om te kiezen uit opties zoals `None`, `BottomTruncated` of `BottomFull`, die respectievelijk notities verbergen, ze in één pagina passen, of toestaan dat ze doorlopen naar extra pagina’s.

**Hoe kan ik de grootte van een TIFF‑bestand met notities verkleinen zonder merkbaar kwaliteitsverlies?**

Kies een [efficient compression](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (bijv. `LZW` of `RLE`), stel een redelijke DPI in en, indien acceptabel, gebruik een lagere [pixel format](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (zoals 8 bpp of 1 bpp voor monochroom). Het iets verkleinen van de [image dimensions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_imagesize/) kan ook helpen zonder duidelijk leesbaarheid te schaden.

**Heeft het lettertype in de notities invloed op het resultaat als de originele lettertypen ontbreken op het systeem?**

Ja. Ontbrekende lettertypen activeren [substitution](/slides/nl/cpp/font-selection-sequence/), wat tekstmetingen en weergave kan wijzigen. Om dit te vermijden, [supply the required fonts](/slides/nl/cpp/custom-font/) of stel een standaard [fallback font](/slides/nl/cpp/fallback-font/) in zodat de bedoelde lettertypen worden gebruikt.