---
title: Odstranění snímků z prezentací v PHP
linktitle: Odstranit snímek
type: docs
weight: 30
url: /cs/php-java/remove-slide-from-presentation/
keywords:
- odstranit snímek
- smazat snímek
- odstranit nepoužívaný snímek
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Jednoduše odstraňujte snímky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java. Získejte přehledné příklady kódu a zefektivněte svůj pracovní postup."
---
## **Úvod**

Pokud se snímek (nebo jeho obsah) stane nadbytečným, můžete jej smazat. Aspose.Slides poskytuje třídu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/), která zapouzdřuje [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/), což je úložiště všech snímků v prezentaci. Pomocí ukazatelů (reference nebo index) na známý objekt [Slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/) můžete určit snímek, který chcete odstranit.

## **Odstranit snímek pomocí reference**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek, který chcete odstranit, pomocí jeho ID nebo indexu.
1. Odstraňte odkazovaný snímek z prezentace.
1. Uložte upravenou prezentaci. 

Tento PHP kód ukazuje, jak odstranit snímek pomocí jeho reference:

```php
  # Vytvořte objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("demo.pptx");
  try {
    # Přistoupí k snímku pomocí jeho indexu v kolekci snímků
    $slide = $pres->getSlides()->get_Item(0);
    # Odstraní snímek pomocí jeho reference
    $pres->getSlides()->remove($slide);
    # Uloží upravenou prezentaci
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Odstranit snímek podle indexu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Odstraňte snímek z prezentace pomocí jeho pozice v indexu.
1. Uložte upravenou prezentaci. 

Tento PHP kód ukazuje, jak odstranit snímek pomocí jeho indexu:

```php
  # Vytvoří objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("demo.pptx");
  try {
    # Odstraní snímek pomocí jeho indexu
    $pres->getSlides()->removeAt(0);
    # Uloží upravenou prezentaci
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Odstranit nepoužívané snímky rozložení**

Aspose.Slides poskytuje metodu [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (z třídy [Compress](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/)), která vám umožní smazat nechtěné a nepoužívané snímky rozložení. Tento PHP kód ukazuje, jak odstranit snímek rozložení z prezentace PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Odstranit nepoužívané hlavní snímky**

Aspose.Slides poskytuje metodu [removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (z třídy [Compress](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/)), která vám umožní smazat nechtěné a nepoužívané hlavní snímky. Tento PHP kód ukazuje, jak odstranit hlavní snímek z prezentace PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Co se stane s indexy snímků po smazání snímku?**

Po smazání se [collection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/) přeindexuje: každý následující snímek se posune o jednu pozici doleva, takže předchozí čísla indexů jsou zastaralá. Pokud potřebujete stabilní odkaz, použijte trvalé ID každého snímku místo jeho indexu.

**Je ID snímku odlišné od jeho indexu a mění se, když jsou smazány sousední snímky?**

Ano. Index je pozice snímku a změní se, když jsou snímky přidány nebo odebrány. ID snímku je trvalý identifikátor a nemění se, když jsou ostatní snímky smazány.

**Jak smazání snímku ovlivní sekce snímků?**

Pokud snímek patřil do sekce, tato sekce bude obsahovat o jeden snímek méně. Struktura sekce zůstane zachována; pokud sekce zůstane prázdná, můžete [remove or reorganize sections](/slides/cs/php-java/slide-section/) podle potřeby.

**Co se stane s poznámkami a komentáři připojenými k snímku po jeho smazání?**

[Notes](/slides/cs/php-java/presentation-notes/) a [comments](/slides/cs/php-java/presentation-comments/) jsou svázány s konkrétním snímkem a jsou odstraněny spolu s ním. Obsah na ostatních snímcích zůstane nedotčen.

**Jak se liší mazání snímků od čištění nepoužívaných rozložení/mistrů?**

Mazání odstraňuje konkrétní běžné snímky z prezentace. Čištění nepoužívaných rozložení/mistrů odstraňuje rozložení nebo hlavní snímky, na které se už nikdo neodkazuje, čímž snižuje velikost souboru, aniž by měnilo obsah zbývajících snímků. Tyto akce se doplňují: typicky nejprve smažte, potom vyčistěte.