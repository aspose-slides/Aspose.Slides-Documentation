---
title: Konvertera PowerPoint-presentationer till SWF Flash i Java
linktitle: PowerPoint till SWF
type: docs
weight: 80
url: /sv/java/convert-powerpoint-to-swf-flash/
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
- Java
- Aspose.Slides
description: "Konvertera PowerPoint (PPT/PPTX) till SWF Flash i Java med Aspose.Slides. Steg‑för‑steg kodexempel, snabb kvalitetsutdata, ingen PowerPoint‑automatisering."
---
## **Översikt**

Denna artikel förklarar hur du konverterar PowerPoint‑presentationer till SWF med hjälp av Aspose.Slides. Den visar hur du sparar en presentation som en SWF‑fil med metoden [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) och hur du konfigurerar exporten med [SwfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/swfoptions/), inklusive visningsinställningar samt layout för anteckningar eller kommentarer.

## **Konvertera presentationer till Flash**

Metoden [save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) som tillhandahålls av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) kan användas för att konvertera hela presentationen till ett **SWF**‑dokument. Följande exempel visar hur du konverterar en presentation till ett **SWF**‑dokument med hjälp av alternativ som tillhandahålls av klassen [**SWFOptions**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SwfOptions). Du kan också inkludera kommentarer i den genererade SWF‑filen med hjälp av klassen [**ISWFOptions**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISwfOptions) och gränssnittet [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INotesCommentsLayoutingOptions).

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Sparar presentation
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag inkludera dolda bilder i SWF?**

Ja. Aktivera dolda bilder med metoden [setShowHiddenSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) i [SwfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/swfoptions/). Som standard exporteras inte dolda bilder.

**Hur kan jag kontrollera komprimering och den slutliga SWF‑storleken?**

Använd metoden [setCompressed](https://reference.aspose.com/slides/sv/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) och [justera JPEG‑kvalitet](https://reference.aspose.com/slides/sv/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) för att balansera filstorlek och bildkvalitet.

**Vad är 'setViewerIncluded' för, och när bör jag inaktivera den?**

[setViewerIncluded](https://reference.aspose.com/slides/sv/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) lägger till ett inbäddat spelarförgränssnitt (navigationskontroller, paneler, sökfunktion). Inaktivera det om du planerar att använda egen spelare eller behöver en tom SWF‑ram utan UI.

**Vad händer om en källfont saknas på exportmaskinen?**

Aspose.Slides kommer att ersätta fonten du anger via [setDefaultRegularFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) i [SwfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/swfoptions/) för att undvika ett oönskat återfall.