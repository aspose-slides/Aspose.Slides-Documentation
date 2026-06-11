---
title: Konvertera PowerPoint-presentationer till SWF Flash i C++
linktitle: PowerPoint till SWF
type: docs
weight: 80
url: /sv/cpp/convert-powerpoint-to-swf-flash/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till SWF
- presentation till SWF
- bild till SWF
- PPT till SWF
- PPTX till SWF
- PowerPoint till Flash
- presentation till Flash
- bild till Flash
- PPT till Flash
- PPTX till Flash
- spara PPT som SWF
- spara PPTX som SWF
- exportera PPT till SWF
- exportera PPTX till SWF
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Konvertera PowerPoint (PPT/PPTX) till SWF Flash i C++ med Aspose.Slides. Steg‑för‑steg kodexempel, snabb högkvalitativ output, utan PowerPoint‑automatisering."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar PowerPoint-presentationer till SWF med hjälp av Aspose.Slides. Den visar hur du sparar en presentation som en SWF‑fil med metoden [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) och hur du konfigurerar exporten med [SwfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/swfoptions/), inklusive visningsinställningar samt layout för anteckningar eller kommentarer.

## **Konvertera presentationer till Flash**

Metoden [Save](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) kan användas för att konvertera hela presentationen till ett SWF‑dokument. Du kan också inkludera kommentarer i den genererade SWF‑filen genom att använda klassen [SWFOptions](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.swf_options) och klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notescommentslayoutingoptions/). Följande exempel visar hur du konverterar en presentation till ett SWF‑dokument med de alternativ som tillhandahålls av klassen SWFOptions.

``` cpp
// Sökvägen till dokumentkatalogen.
    System::String dataDir = GetDataPath();

    // Instansiera ett Presentation-objekt som representerar en presentationsfil
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Sparar presentation och notssidor
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **Vanliga frågor**

**Kan jag inkludera dolda bilder i SWF‑filen?**

Ja. Använd metoden [set_ShowHiddenSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) i [SwfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/swfoptions/). Som standard exporteras inte dolda bilder.

**Hur kan jag kontrollera komprimering och den slutgiltiga SWF‑storleken?**

Använd metoden [set_Compressed](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/swfoptions/set_compressed/) och justera [JPEG quality](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/swfoptions/set_jpegquality/) för att balansera filstorlek och bildkvalitet.

**Vad är 'set_ViewerIncluded' för, och när ska jag använda den?**

[set_ViewerIncluded](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) lägger till ett inbäddat spelar‑UI (navigationskontroller, paneler, sök). Inaktivera det om du planerar att använda din egen spelare eller behöver en ren SWF‑ram utan UI.

**Vad händer om en källteckensnitt saknas på exportmaskinen?**

Aspose.Slides kommer att ersätta teckensnittet du anger via [set_DefaultRegularFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) i [SwfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/swfoptions/) för att undvika en oavsiktlig reserv.