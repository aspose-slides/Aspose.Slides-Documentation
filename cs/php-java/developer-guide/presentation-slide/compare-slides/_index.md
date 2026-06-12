---
title: Porovnávat snímky prezentace v PHP
linktitle: Porovnat snímky
type: docs
weight: 50
url: /cs/php-java/compare-slides/
keywords:
- porovnat snímky
- porovnání snímků
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Programově porovnávejte prezentace PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java. Rychle identifikujte rozdíly mezi snímky v kódu."
---
## **Úvod**

Aspose.Slides umožňuje porovnávat snímky, rozložení snímků a hlavní snímky pomocí metody `equals`, kterou poskytuje třída `BaseSlide`. Tato metoda vrací `true`, když jsou porovnávané snímky identické ve své struktuře a statickém obsahu.

## **Porovnat dva snímky**

Metoda Equals byla přidána do třídy [BaseSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/BaseSlide). Vrací true pro snímky/rozložení a snímky/hlavní snímky, které jsou identické podle své struktury a statického obsahu.

Dva snímky jsou stejné, pokud jsou shodné všechny tvary, styly, texty, animace a další nastavení atd. Porovnání nebere v úvahu jedinečné identifikátory, např. SlideId, ani dynamický obsah, např. aktuální datum v zástupci data.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **Často kladené otázky**

**Má skutečnost, že je snímek skrytý, vliv na porovnání samotných snímků?**

[Hidden status](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/gethidden/) je vlastnost úrovně prezentace/přehrávání, nikoli vizuální obsah. Rovnost dvou konkrétních snímků je určena jejich strukturou a statickým obsahem; samotná skutečnost, že je snímek skrytý, neznamená, že jsou snímky odlišné.

**Jsou hypertextové odkazy a jejich parametry brány v úvahu?**

Ano. Odkazy jsou součástí statického obsahu snímku. Pokud se liší URL nebo akce hypertextového odkazu, je to obvykle považováno za rozdíl ve statickém obsahu.

**Pokud graf odkazuje na externí soubor Excel, bude obsah tohoto souboru brán v úvahu?**

Ne. Porovnání se provádí na základě samotných snímků. Vnější datové zdroje se obecně při porovnávání nečtou; zohledněno je pouze to, co je přítomno ve struktuře a statickém stavu snímku.