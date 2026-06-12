---
title: "PowerPoint-presentaties converteren naar SWF Flash in .NET"
linktitle: "PowerPoint naar SWF"
type: docs
weight: 80
url: /nl/net/convert-powerpoint-to-swf-flash/
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
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint (PPT/PPTX) naar SWF Flash in .NET met Aspose.Slides. Stapsgewijze C#-codevoorbeelden, snelle kwaliteit output, geen PowerPoint-automatisering."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties naar SWF kunt converteren met behulp van Aspose.Slides. Het laat zien hoe u een presentatie kunt opslaan als een SWF‑bestand met de [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/)‑methode en hoe u de export kunt configureren met [SwfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/swfoptions/), inclusief weergave‑instellingen en notities‑ of opmerkingen‑indeling.

## **Presentaties converteren naar Flash**

De [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/methods/save/index)‑methode die wordt aangeboden door de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse kan worden gebruikt om de volledige presentatie om te zetten naar een SWF‑document. U kunt ook opmerkingen opnemen in de gegenereerde SWF door de [SWFOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/swfoptions)‑klasse en de [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/inotescommentslayoutingoptions)‑interface te gebruiken. Het volgende voorbeeld laat zien hoe u een presentatie kunt converteren naar een SWF‑document met de opties die door de SWFOptions‑klasse worden geleverd.

```c#
// Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Presentatie en notitie-pagina's opslaan
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **Veelgestelde vragen**

**Kan ik verborgen dia's opnemen in de SWF?**

Ja. Schakel de [ShowHiddenSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.export/swfoptions/showhiddenslides/)‑optie in bij [SwfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/swfoptions/). Standaard worden verborgen dia's niet geëxporteerd.

**Hoe kan ik compressie en de uiteindelijke SWF‑grootte beheersen?**

Gebruik de [Compressed](https://reference.aspose.com/slides/nl/net/aspose.slides.export/swfoptions/compressed/)‑vlag (standaard ingeschakeld) en pas [JpegQuality](https://reference.aspose.com/slides/nl/net/aspose.slides.export/swfoptions/jpegquality/) aan om een evenwicht te vinden tussen bestandsgrootte en beeldkwaliteit.

**Waar dient 'ViewerIncluded' voor en wanneer moet ik het uitschakelen?**

[ViewerIncluded](https://reference.aspose.com/slides/nl/net/aspose.slides.export/swfoptions/viewerincluded/) voegt een ingebedde afspeel‑UI toe (navigatie‑besturingen, panelen, zoeken). Schakel het uit als u uw eigen afspeler wilt gebruiken of een minimale SWF‑frame zonder UI nodig heeft.

**Wat gebeurt er als een bronlettertype ontbreekt op de exportmachine?**

Aspose.Slides zal het lettertype vervangen dat u opgeeft via [DefaultRegularFont](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveoptions/defaultregularfont/) in [SwfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveoptions/) om een ongewenste fallback te voorkomen.