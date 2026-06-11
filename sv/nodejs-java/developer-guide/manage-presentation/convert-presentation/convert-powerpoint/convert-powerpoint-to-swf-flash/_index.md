---
title: Konvertera PowerPoint-presentationer till SWF Flash i JavaScript
linktitle: PowerPoint till SWF
type: docs
weight: 80
url: /sv/nodejs-java/convert-powerpoint-to-swf-flash/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PowerPoint (PPT/PPTX) till SWF Flash med Aspose.Slides för Node.js. Steg‑för‑steg kodexempel, snabb kvalitet på resultatet, ingen PowerPoint‑automatisering."
---
## **Översikt**

Den här artikeln förklarar hur man konverterar PowerPoint-presentationer till SWF med hjälp av Aspose.Slides. Den visar hur man sparar en presentation som en SWF-fil med metoden [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) och hur man konfigurerar exporten med [SwfOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/swfoptions/), inklusive visningsinställningar och layout för anteckningar eller kommentarer.

## **Konvertera PPT(X) till SWF**
Metoden [save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) kan användas för att konvertera hela presentationen till ett **SWF**-dokument. Följande exempel visar hur man konverterar en presentation till ett **SWF**-dokument med hjälp av alternativ som tillhandahålls av klassen [**SWFOptions**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SwfOptions). Du kan också inkludera kommentarer i den genererade SWF-filen med [**SWFOptions**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SwfOptions) och klassen [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions).

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Sparar presentation
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Kan jag inkludera dolda bilder i SWF?**

Ja. Använd metoden [setShowHiddenSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) i [SwfOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/swfoptions/). Som standard exporteras inte dolda bilder.

**Hur kan jag styra komprimeringen och den slutliga SWF-storleken?**

Använd metoden [setCompressed](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/swfoptions/setcompressed/) och [setJpegQuality](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/swfoptions/setjpegquality/) för att balansera filstorlek och bildkvalitet.

**Vad är 'setViewerIncluded' för, och när bör jag använda den?**

[setViewerIncluded](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) lägger till ett inbäddat spelarkontroller (navigationskontroller, paneler, sökning). Använd den om du planerar att använda din egen spelare eller behöver en ren SWF-ram utan UI.

**Vad händer om ett källteckensnitt saknas på exportmaskinen?**

Aspose.Slides kommer att ersätta teckensnittet du anger via [setDefaultRegularFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) i [SwfOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/swfoptions/) för att undvika en oavsiktlig återgång.