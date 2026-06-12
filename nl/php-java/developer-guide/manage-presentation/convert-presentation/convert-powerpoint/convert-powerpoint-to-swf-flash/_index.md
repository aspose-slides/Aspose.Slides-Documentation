---
title: PowerPoint-presentaties converteren naar SWF Flash in PHP
linktitle: PowerPoint naar SWF
type: docs
weight: 80
url: /nl/php-java/convert-powerpoint-to-swf-flash/
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
- PHP
- Aspose.Slides
description: "Converteer PowerPoint (PPT/PPTX) naar SWF Flash in PHP met Aspose.Slides. Stap-voor-stap codevoorbeelden, snelle kwaliteitoutput, geen PowerPoint-automatisering."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt converteren naar SWF met behulp van Aspose.Slides. Het laat zien hoe u een presentatie opslaat als een SWF‑bestand met de [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/save/)‑methode en hoe u de export configureert met [SwfOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/swfoptions/), inclusief weergave‑instellingen en notities‑ of commentaar‑indeling.

## **Presentaties converteren naar Flash**

De [save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/save/)‑methode die beschikbaar is in de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse kan worden gebruikt om de volledige presentatie te converteren naar een **SWF**‑document. Het volgende voorbeeld toont hoe u een presentatie converteert naar een **SWF**‑document met behulp van de opties die worden aangeboden door de [SWFOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/swfoptions/)‑klasse. U kunt ook comments opnemen in de gegenereerde SWF met de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notescommentslayoutingoptions/)‑klasse.

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Presentatie opslaan
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik verborgen dia's opnemen in de SWF?**

Ja. Schakel verborgen dia's in met de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/swfoptions/setshowhiddenslides/)‑methode in [SwfOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/swfoptions/). Standaard worden verborgen dia's niet geëxporteerd.

**Hoe kan ik compressie en de uiteindelijke SWF‑grootte regelen?**

Gebruik de [setCompressed](https://reference.aspose.com/slides/nl/php-java/aspose.slides/swfoptions/setcompressed/)‑methode en pas de [adjust JPEG quality](https://reference.aspose.com/slides/nl/php-java/aspose.slides/swfoptions/setjpegquality/) aan om een balans te vinden tussen bestandsgrootte en beeldkwaliteit.

**Waar dient 'setViewerIncluded' voor en wanneer moet ik het uitschakelen?**

[setViewerIncluded](https://reference.aspose.com/slides/nl/php-java/aspose.slides/swfoptions/setviewerincluded/) voegt een ingebedde afspeel‑UI toe (navigatie‑besturingselementen, panelen, zoeken). Schakel het uit als u een eigen speler wilt gebruiken of een lege SWF‑frame zonder UI nodig hebt.

**Wat gebeurt er als een bronlettertype ontbreekt op de exportmachine?**

Aspose.Slides zal het lettertype dat u opgeeft via [setDefaultRegularFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [SwfOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/swfoptions/) vervangen om een ongewenste fallback te voorkomen.