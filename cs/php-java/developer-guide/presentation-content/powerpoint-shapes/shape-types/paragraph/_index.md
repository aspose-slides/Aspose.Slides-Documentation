---
title: Získání ohraničení odstavců z prezentací v PHP
linktitle: Odstavec
type: docs
weight: 60
url: /cs/php-java/paragraph/
keywords:
- ohraničení odstavce
- ohraničení části textu
- souřadnice odstavce
- souřadnice části
- velikost odstavce
- velikost části textu
- textový rámec
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte, jak získat ohraničení odstavců a částí textu v Aspose.Slides pro PHP přes Java pro optimalizaci umístění textu v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců a částí textu v Aspose.Slides. Ukazuje, jak pomocí `getRect()` získat obdélník odstavce v `TextFrame`, jak získat souřadnice odstavce a části uvnitř textového rámce buňky tabulky, a zdůrazňuje důležité podrobnosti, jako jsou jednotky měření, vliv zalamování textu na ohraničení, převod na pixely a hodnoty efektivního formátování odstavců.

## **Získání souřadnic odstavců a částí v TextFrame**
Pomocí Aspose.Slides pro PHP přes Java mohou vývojáři nyní získat obdélníkové souřadnice odstavce v kolekci odstavců TextFrame. Umožňuje také získat [souřadnice části](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#getCoordinates) v kolekci částí odstavce. V tomto tématu ukážeme pomocí příkladu, jak získat obdélníkové souřadnice odstavce spolu s polohou části uvnitř odstavce.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **Získání obdélníkových souřadnic odstavce**
Pomocí metody [**getRect()**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getRect) mohou vývojáři získat obdélník ohraničení odstavce.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Získání velikosti odstavce a části uvnitř textového rámce buňky tabulky**
Pro získání velikosti a souřadnic [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Portion) nebo [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Paragraph) v textovém rámci buňky tabulky můžete použít metody [Portion::getRect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#getRect) a [Paragraph::getRect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getRect).

Tento ukázkový kód demonstruje popsanou operaci:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**V jakých jednotkách jsou vráceny souřadnice odstavce a částí textu?**  
V bodech, kde 1 palec = 72 bodů. Toto platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování slov ohraničení odstavce?**  
Ano. Pokud je v [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) povoleno [wrapping](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/setwraptext/), text se zalamuje, aby se vešel do šířky oblasti, což mění skutečné ohraničení odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrázku?**  
Ano. Převést body na pixely můžete pomocí: pixely = body × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslování/export.

**Jak získám „efektivní“ parametry formátování odstavce, s ohledem na dědičnost stylu?**  
Použijte [effective paragraph formatting data structure](/slides/cs/php-java/shape-effective-properties/); vrátí konečné konsolidované hodnoty pro odsazení, řádkování, zalamování, RTL a další.