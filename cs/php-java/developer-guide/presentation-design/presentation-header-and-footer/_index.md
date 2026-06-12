---
title: Spravovat záhlaví a zápatí prezentace v PHP
linktitle: Záhlaví a zápatí
type: docs
weight: 140
url: /cs/php-java/presentation-header-and-footer/
keywords:
- záhlaví
- text záhlaví
- zápatí
- text zápatí
- nastavit záhlaví
- nastavit zápatí
- výstřižek
- poznámky
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Použijte Aspose.Slides pro PHP přes Java k přidání a úpravě záhlaví a zápatí v prezentacích PowerPoint a OpenDocument pro profesionální vzhled."
---
## **Přehled**

Aspose.Slides vám umožňuje spravovat nastavení záhlaví a zápatí v prezentacích PowerPoint. Záhlaví a zápatí se zpracovávají na úrovni hlavního režimu prezentace a API poskytuje metody pro nastavení textu zápatí, změnu viditelnosti zápatí a aktualizaci textu záhlaví na hlavních snímcích s poznámkami.

Můžete také spravovat záhlaví a zápatí pro výstřižky a snímky s poznámkami. To zahrnuje změnu viditelnosti a textu zástupných znaků záhlaví, zápatí, čísla snímku a data/času pro hlavní poznámky, všechny podřízené snímky s poznámkami nebo jednotlivý snímek s poznámkami.

## **Spravovat záhlaví a zápatí v prezentaci**

Poznámky některých konkrétních snímků mohou být odstraněny, jak je ukázáno v níže uvedeném příkladu:

```php
  # Načíst prezentaci
  $pres = new Presentation("headerTest.pptx");
  try {
    # Nastavení zápatí
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Přístup a aktualizace záhlaví
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Uložit prezentaci
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Spravovat záhlaví a zápatí na výstřižcích a snímcích s poznámkami**
Aspose.Slides pro PHP přes Java podporuje záhlaví a zápatí na výstřižcích a snímcích s poznámkami. Postupujte podle následujících kroků:

- Načtěte [Prezentaci](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující video.
- Změňte nastavení záhlaví a zápatí pro hlavní poznámky a všechny snímky s poznámkami.
- Nastavte, aby hlavní snímek s poznámkami a všechny podřízené zástupné znaky zápatí byly viditelné.
- Nastavte, aby hlavní snímek s poznámkami a všechny podřízené zástupné znaky data a času byly viditelné.
- Změňte nastavení záhlaví a zápatí pouze pro první snímek s poznámkami.
- Nastavte, aby zástupný znak záhlaví na snímku s poznámkami byl viditelný.
- Nastavte text pro zástupný znak záhlaví na snímku s poznámkami.
- Nastavte text pro zástupný znak data/času na snímku s poznámkami.
- Zapište upravený soubor prezentace.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Změnit nastavení záhlaví a zápatí pro hlavní poznámky a všechny snímky s poznámkami
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// zobrazit hlavní snímek s poznámkami a všechny podřízené zástupné znaky zápatí

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// zobrazit hlavní snímek s poznámkami a všechny podřízené zástupné znaky záhlaví

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// zobrazit hlavní snímek s poznámkami a všechny podřízené zástupné znaky čísla snímku

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// zobrazit hlavní snímek s poznámkami a všechny podřízené zástupné znaky data a času

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// nastavit text pro hlavní snímek s poznámkami a všechny podřízené zástupné znaky záhlaví

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// nastavit text pro hlavní snímek s poznámkami a všechny podřízené zástupné znaky zápatí

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// nastavit text pro hlavní snímek s poznámkami a všechny podřízené zástupné znaky data a času

    }
    # Změnit nastavení záhlaví a zápatí pouze pro první snímek s poznámkami
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// zobrazit zástupný znak záhlaví tohoto snímku s poznámkami

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// zobrazit zástupný znak zápatí tohoto snímku s poznámkami

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// zobrazit zástupný znak čísla snímku tohoto snímku s poznámkami

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// zobrazit zástupný znak data a času tohoto snímku s poznámkami

      $headerFooterManager->setHeaderText("New header text");// nastavit text pro zástupný znak záhlaví snímku s poznámkami

      $headerFooterManager->setFooterText("New footer text");// nastavit text pro zástupný znak zápatí snímku s poznámkami

      $headerFooterManager->setDateTimeText("New date and time text");// nastavit text pro zástupný znak data a času snímku s poznámkami

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Mohu přidat „záhlaví“ do běžných snímků?**

V PowerPointu existuje „záhlaví“ jen pro poznámky a výstřižky; na běžných snímcích jsou podporovány pouze zápatí, datum/čas a číslo snímku. V Aspose.Slides to odpovídá stejným omezením: záhlaví pouze pro poznámky/výstřižky a na snímcích – zápatí/datum‑čas/číslo snímku.

**Co když rozvržení neobsahuje oblast zápatí – mohu jeho viditelnost „zapnout“?**

Ano. Zkontrolujte viditelnost pomocí správce záhlaví/zápatí a povolte ji podle potřeby. Tyto indikátory a metody API jsou navrženy pro případy, kdy je zástupný znak chybějící nebo skrytý.

**Jak nastavit, aby číslo snímku začínalo hodnotou jinou než 1?**

Nastavte [první číslo snímku](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/setfirstslidenumber/) prezentace; poté se celé číslování přepočítá. Například můžete začít od 0 nebo 10 a číslo na úvodním snímku skrýt.

**Co se stane se záhlavím/zápatím při exportu do PDF/obrázků/HTML?**

Jsou vykresleny jako běžné textové prvky prezentace. To znamená, že pokud jsou prvky viditelné na snímcích/stránkách s poznámkami, budou se také objevit ve výstupním formátu spolu se zbytkem obsahu.