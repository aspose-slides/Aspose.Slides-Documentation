---
title: Konvertera PowerPoint-presentationer till SWF Flash i .NET
linktitle: PowerPoint till SWF
type: docs
weight: 80
url: /sv/net/convert-powerpoint-to-swf-flash/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint (PPT/PPTX) till SWF Flash i .NET med Aspose.Slides. Steg‑för‑steg C#-kodexempel, snabb högkvalitativ output, ingen PowerPoint‑automatisering."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar PowerPoint-presentationer till SWF med hjälp av Aspose.Slides. Den visar hur du sparar en presentation som en SWF‑fil med metoden [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) och hur du konfigurerar exporten med [SwfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/swfoptions/), inklusive visningsinställningar samt layout för anteckningar eller kommentarer.

## **Konvertera presentationer till Flash**

Metoden [Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/methods/save/index) som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) kan användas för att konvertera hela presentationen till ett SWF‑dokument. Du kan också inkludera kommentarer i den genererade SWF‑filen genom att använda klassen [SWFOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/swfoptions) och gränssnittet [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/inotescommentslayoutingoptions). Följande exempel visar hur du konverterar en presentation till ett SWF‑dokument med de alternativ som tillhandahålls av klassen SWFOptions.

```c#
// Skapa ett Presentation-objekt som representerar en presentationsfil
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Sparar presentation och notssidor
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **FAQ**

**Kan jag inkludera dolda bilder i SWF‑filen?**

Ja. Aktivera alternativet [ShowHiddenSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.export/swfoptions/showhiddenslides/) i [SwfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/swfoptions/). Som standard exporteras inte dolda bilder.

**Hur kan jag kontrollera komprimeringen och den slutgiltiga SWF‑filens storlek?**

Använd flaggan [Compressed](https://reference.aspose.com/slides/sv/net/aspose.slides.export/swfoptions/compressed/) (aktiverad som standard) och justera [JpegQuality](https://reference.aspose.com/slides/sv/net/aspose.slides.export/swfoptions/jpegquality/) för att balansera filstorlek och bildkvalitet.

**Vad är 'ViewerIncluded' för, och när bör jag inaktivera det?**

[ViewerIncluded](https://reference.aspose.com/slides/sv/net/aspose.slides.export/swfoptions/viewerincluded/) lägger till ett inbäddat spelar‑UI (navigeringskontroller, paneler, sökning). Inaktivera det om du planerar att använda din egen spelare eller behöver en ren SWF‑ram utan UI.

**Vad händer om en källfont saknas på exportmaskinen?**

Aspose.Slides kommer att ersätta fonten du anger via [DefaultRegularFont](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveoptions/defaultregularfont/) i [SwfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveoptions/) för att undvika ett oavsiktligt fallback.