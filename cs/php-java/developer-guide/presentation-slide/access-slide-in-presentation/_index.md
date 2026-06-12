---
title: Přístup k snímkům prezentace v PHP
linktitle: Přístup ke snímku
type: docs
weight: 20
url: /cs/php-java/access-slide-in-presentation/
keywords:
- přístup ke snímku
- index snímku
- ID snímku
- pozice snímku
- změna pozice
- vlastnosti snímku
- číslo snímku
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak přistupovat k snímkům a spravovat je v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java. Zvýšte produktivitu pomocí ukázkových kódů."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přistupovat k snímkům v prezentaci a spravovat je. Ukazuje, jak získat snímky podle jejich nulového indexu ze sbírky snímků a jak získat snímek podle jeho jedinečného ID pomocí metody `getSlideById`.

Dozvíte se také, jak změnit pozici snímku pomocí metody `setSlideNumber` a jak nastavit počáteční číslo snímku pro prezentaci pomocí metody `setFirstSlideNumber`. Příklady demonstrují načtení prezentace, získání odkazů na snímky, aktualizaci pořadí nebo číslování snímků a uložení upravené prezentace.

## **Přístup ke snímku podle indexu**

Všechny snímky v prezentaci jsou uspořádány číselně podle pozice snímku počínaje 0. První snímek je přístupný přes index 0; druhý snímek přes index 1; atd.

Třída Presentation, která představuje soubor prezentace, vystavuje všechny snímky jako sbírku [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/) (sbírku objektů [Slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/)). Tento PHP kód ukazuje, jak přistoupit k snímku podle jeho indexu:

```php
  # Vytvoří objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("demo.pptx");
  try {
    # Přistupuje k snímku pomocí jeho indexu
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **Přístup ke snímku podle ID**

Každý snímek v prezentaci má přiřazené jedinečné ID. Pomocí metody [getSlideById](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSlideById-long-) (kterou poskytuje třída [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/)) můžete cílit na toto ID. Tento PHP kód ukazuje, jak zadat platné ID snímku a získat tento snímek pomocí metody [getSlideById](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSlideById-long-):

```php
  # Vytvoří objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("demo.pptx");
  try {
    # Získá ID snímku
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Přistupuje k snímku pomocí jeho ID
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **Změna pozice snímku**

Aspose.Slides umožňuje změnit pozici snímku. Například můžete určit, že první snímek se stane druhým snímkem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek (jehož pozici chcete změnit) pomocí jeho indexu
1. Nastavte novou pozici snímku pomocí metody [setSlideNumber](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#setSlideNumber).
1. Uložte upravenou prezentaci.

Tento PHP kód demonstruje operaci, při níž se snímek na pozici 1 přesune na pozici 2:

```php
  # Vytvoří objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("Presentation.pptx");
  try {
    # Získá snímek, jehož pozice bude změněna
    $sld = $pres->getSlides()->get_Item(0);
    # Nastaví novou pozici snímku
    $sld->setSlideNumber(2);
    # Uloží upravenou prezentaci
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

První snímek se stal druhým; druhý snímek se stal prvním. Když změníte pozici snímku, ostatní snímky jsou automaticky upraveny.

## **Nastavení čísla snímku**

Pomocí metody [setFirstSlideNumber](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (kterou poskytuje třída [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/)) můžete určit nové číslo pro první snímek v prezentaci. Tato operace způsobí přepočet čísel ostatních snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte číslo snímku.
1. Nastavte číslo snímku.
1. Uložte upravenou prezentaci.

Tento PHP kód demonstruje operaci, při níž je první číslo snímku nastaveno na 10:

```php
  # Vytvoří objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Získá číslo snímku
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Nastaví číslo snímku
    $pres->setFirstSlideNumber(10);
    # Uloží upravenou prezentaci
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Pokud chcete přeskočit první snímek, můžete číslování zahájit od druhého snímku (a skrýt číslování pro první snímek) tímto způsobem:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Nastaví číslo pro první snímek prezentace
    $presentation->setFirstSlideNumber(0);
    # Zobrazí čísla snímků pro všechny snímky
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # Skryje číslo snímku u prvního snímku
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Uloží upravenou prezentaci
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Odpovídá číslo snímku, které uživatel vidí, nulovému indexu ve sbírce?**

Číslo zobrazené na snímku může začínat libovolnou hodnotou (např. 10) a nemusí odpovídat indexu; vztah je řízen nastavením [first slide number](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/setfirstslidenumber/) prezentace.

**Mají skryté snímky vliv na indexování?**

Ano. Skrytý snímek zůstává ve sbírce a je započítán do indexování; „skrytý“ se vztahuje k zobrazení, ne k jeho pozici ve sbírce.

**Mění se index snímku, když jsou přidány nebo odebrány jiné snímky?**

Ano. Indexy vždy odrážejí aktuální pořadí ve sbírce snímků a jsou přepočítány při vložení, smazání nebo přesunu snímků.