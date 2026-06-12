---
title: PowerPoint‑presentaties naar SWF‑Flash converteren in C++
linktitle: PowerPoint naar SWF
type: docs
weight: 80
url: /nl/cpp/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar SWF
- presentatie naar SWF
- dia naar SWF
- PPT naar SWF
- PPTX naar SWF
- PowerPoint naar Flash
- presentatie naar Flash
- dia naar Flash
- PPT naar Flash
- PPTX naar Flash
- PPT opslaan als SWF
- PPTX opslaan als SWF
- PPT exporteren naar SWF
- PPTX exporteren naar SWF
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) naar SWF Flash converteren in C++ met Aspose.Slides. Stap‑voor‑stap codevoorbeelden, snelle kwaliteit output, geen PowerPoint‑automatisering."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint-presentaties kunt converteren naar SWF met Aspose.Slides. Het laat zien hoe u een presentatie kunt opslaan als een SWF-bestand met de [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/) methode en hoe u de export kunt configureren met [SwfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/swfoptions/), inclusief weergave-instellingen en de layout van notities of opmerkingen.

## **Presentaties converteren naar Flash**

De [Save](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) methode van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse kan worden gebruikt om de volledige presentatie te converteren naar een SWF-document. U kunt ook opmerkingen opnemen in de gegenereerde SWF door de [SWFOptions](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.swf_options)‑klasse en de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑klasse te gebruiken. Het volgende voorbeeld laat zien hoe u een presentatie kunt omzetten naar een SWF-document met de opties die door de [SWFOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/swfoptions/)‑klasse worden aangeboden.

``` cpp
// Het pad naar de documentenmap.
    System::String dataDir = GetDataPath();

    // Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Presentatie en notitiepagina's opslaan
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **FAQ**

**Kan ik verborgen dia's opnemen in de SWF?**

Ja. Gebruik de [set_ShowHiddenSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) methode in [SwfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/swfoptions/). Standaard worden verborgen dia's niet geëxporteerd.

**Hoe kan ik compressie en de uiteindelijke SWF-grootte controleren?**

Gebruik de [set_Compressed](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/swfoptions/set_compressed/) methode en pas de [JPEG quality](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/swfoptions/set_jpegquality/) aan om een balans te vinden tussen bestandsgrootte en afbeeldingskwaliteit.

**Waar is 'set_ViewerIncluded' voor en wanneer moet ik het gebruiken?**

[set_ViewerIncluded](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) voegt een ingebedde speler-UI toe (navigatie-bedieningen, panelen, zoeken). Schakel het uit als u uw eigen speler wilt gebruiken of een lege SWF-frame zonder UI nodig heeft.

**Wat gebeurt er als een bronlettertype ontbreekt op de exportmachine?**

Aspose.Slides vervangt het lettertype dat u opgeeft via [set_DefaultRegularFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [SwfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/swfoptions/) om een ongewenste fallback te voorkomen.