---
title: Konvertera PowerPoint-presentationer till SWF Flash i PHP
linktitle: PowerPoint till SWF
type: docs
weight: 80
url: /sv/php-java/convert-powerpoint-to-swf-flash/
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
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint (PPT/PPTX) till SWF Flash i PHP med Aspose.Slides. Steg-för-steg kodexempel, snabbt högkvalitativt resultat, ingen PowerPoint-automatisering."
---
## **Översikt**

Denna artikel förklarar hur man konverterar PowerPoint‑presentationer till SWF med Aspose.Slides. Den visar hur man sparar en presentation som en SWF‑fil med metoden [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/save/) och hur man konfigurerar exporten med [SwfOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/swfoptions/), inklusive visningsinställningar samt layout för anteckningar eller kommentarer.

## **Konvertera presentationer till Flash**

Metoden [save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/save/) som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) kan användas för att konvertera hela presentationen till ett **SWF**‑dokument. Följande exempel visar hur man konverterar en presentation till ett **SWF**‑dokument med de alternativ som tillhandahålls av klassen [SWFOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/swfoptions/). Du kan även inkludera kommentarer i den genererade SWF‑filen genom att använda klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notescommentslayoutingoptions/).

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Sparar presentation
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan jag inkludera dolda bilder i SWF‑filen?**

Ja. Aktivera dolda bilder med metoden [setShowHiddenSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/swfoptions/setshowhiddenslides/) i [SwfOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/swfoptions/). Som standard exporteras inte dolda bilder.

**Hur kan jag styra komprimering och den slutgiltiga SWF‑storleken?**

Använd metoden [setCompressed](https://reference.aspose.com/slides/sv/php-java/aspose.slides/swfoptions/setcompressed/) och [justera JPEG‑kvalitet](https://reference.aspose.com/slides/sv/php-java/aspose.slides/swfoptions/setjpegquality/) för att balansera filstorlek och bildkvalitet.

**Vad är 'setViewerIncluded' för, och när bör jag inaktivera den?**

[setViewerIncluded](https://reference.aspose.com/slides/sv/php-java/aspose.slides/swfoptions/setviewerincluded/) lägger till ett inbäddat spelarfönster (navigationskontroller, paneler, sök). Inaktivera den om du planerar att använda din egen spelare eller behöver ett rent SWF‑ram utan UI.

**Vad händer om en källfont saknas på exportmaskinen?**

Aspose.Slides kommer att ersätta den font du anger via [setDefaultRegularFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) i [SwfOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/swfoptions/) för att undvika en oavsiktlig återgång.