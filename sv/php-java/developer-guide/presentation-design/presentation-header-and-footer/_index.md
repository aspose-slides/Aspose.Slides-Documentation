---
title: Hantera presentationens rubriker och sidfötter i PHP
linktitle: Rubrik och sidfot
type: docs
weight: 140
url: /sv/php-java/presentation-header-and-footer/
keywords:
- rubrik
- rubriktext
- sidfot
- sidfottext
- ange rubrik
- ange sidfot
- handout
- noteringar
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Använd Aspose.Slides för PHP via Java för att lägga till och anpassa rubriker och sidfötter i PowerPoint- och OpenDocument-presentationer för ett professionellt utseende."
---
## **Översikt**

Aspose.Slides låter dig hantera rubrik‑ och sidfotsinställningar i PowerPoint‑presentationer. Rubriker och sidfötter hanteras på presentations‑masternivå, och API‑et tillhandahåller metoder för att ange sidfotstext, ändra sidfotens synlighet och uppdatera rubriktext på master‑noteringsbilder.

Du kan också hantera rubriker och sidfötter för handout‑ och noteringsbilder. Detta inkluderar att ändra synlighet och text för rubrik‑, sidfot‑, bildnummer‑ och datum‑/tids‑platshållare för noterings‑master, alla underordnade noteringsbilder eller en enskild noteringsbild.

## **Hantera rubriker och sidfötter i en presentation**

Noteringar för en viss bild kan tas bort som visas i exemplet nedan:

```php
  # Ladda presentation
  $pres = new Presentation("headerTest.pptx");
  try {
    # Ställ in sidfot
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Åtkomst och uppdatera rubrik
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Spara presentation
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Hantera rubriker och sidfötter på handout- och noteringsbilder**
Aspose.Slides för PHP via Java stöder rubrik och sidfot i handout- och noteringsbilder. Följ stegen nedan:

- Läs in en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller en video.
- Ändra rubrik- och sidfotinställningar för noteringsmaster och alla noteringsbilder.
- Ställ in master‑noteringsbilden och alla underordnade sidfot‑platshållare som synliga.
- Ställ in master‑noteringsbilden och alla underordnade datum‑ och tids‑platshållare som synliga.
- Ändra rubrik- och sidfotinställningar endast för den första noteringsbilden.
- Ställ in noteringsbildens rubrik‑platshållare som synlig.
- Ange text för noteringsbildens rubrik‑platshållare.
- Ange text för noteringsbildens datum‑tid‑platshållare.
- Skriv den modifierade presentationsfilen.

Kodexempel tillhandahålls i exemplet nedan.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Ändra rubrik- och sidfotinställningar för noterings-master och alla noteringsbilder
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// gör master‑noteringsbilden och alla underordnade sidfot‑platshållare synliga

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// gör master‑noteringsbilden och alla underordnade rubrik‑platshållare synliga

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// gör master‑noteringsbilden och alla underordnade bildnummer‑platshållare synliga

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// gör master‑noteringsbilden och alla underordnade datum‑ och tids‑platshållare synliga

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// sätt text på master‑noteringsbilden och alla underordnade rubrik‑platshållare

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// sätt text på master‑noteringsbilden och alla underordnade sidfot‑platshållare

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// sätt text på master‑noteringsbilden och alla underordnade datum‑ och tids‑platshållare

    }
    # Ändra rubrik- och sidfotinställningar endast för den första noteringsbilden
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// gör denna noteringsbildens rubrik‑platshållare synlig

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// gör denna noteringsbildens sidfot‑platshållare synlig

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// gör denna noteringsbildens bildnummer‑platshållare synlig

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// gör denna noteringsbildens datum‑tid‑platshållare synlig

      $headerFooterManager->setHeaderText("New header text");// sätt text på noteringsbildens rubrik‑platshållare

      $headerFooterManager->setFooterText("New footer text");// sätt text på noteringsbildens sidfot‑platshållare

      $headerFooterManager->setDateTimeText("New date and time text");// sätt text på noteringsbildens datum‑tid‑platshållare

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Kan jag lägga till en "rubrik" på vanliga bilder?**

I PowerPoint finns "Rubrik" bara för noteringar och handout; på vanliga bilder är de stödjade elementen sidfot, datum/tid och bildnummer. I Aspose.Slides gäller samma begränsningar: rubrik endast för Noteringar/Handout, och på bilder—Sidfot/DateTime/SlideNumber.

**Vad händer om layouten inte innehåller ett sidfotområde—kan jag "slå på" dess synlighet?**

Ja. Kontrollera synligheten via rubrik-/sidfot‑hanteraren och aktivera den vid behov. Dessa API‑indikatorer och metoder är utformade för fall då platshållaren saknas eller är dold.

**Hur får jag bildnumret att börja från ett annat värde än 1?**

Ange presentationens [first slide number](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/setfirstslidenumber/); därefter beräknas all numrering om. Till exempel kan du börja på 0 eller 10, och dölja numret på titelläs bilden.

**Vad händer med rubriker/sidfötter när du exporterar till PDF/bilder/HTML?**

De renderas som vanliga textelement i presentationen. Det vill säga, om elementen är synliga på bilder/noteringssidor, kommer de också att visas i det exporterade formatet tillsammans med övrigt innehåll.