---
title: Přidání obdélníků do prezentací v PHP
linktitle: Obdélník
type: docs
weight: 80
url: /cs/php-java/rectangle/
keywords:
- přidat obdélník
- vytvořit obdélník
- tvar obdélníku
- jednoduchý obdélník
- formátovaný obdélník
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Zrychlete své PowerPoint prezentace přidáním obdélníků pomocí Aspose.Slides pro PHP přes Java — snadno navrhujte a upravujte tvary programově."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat obdélníkové tvary do snímků PowerPointu. Popisuje vytvoření jednoduchého obdélníku, vytvoření formátovaného obdélníku a uložení aktualizované prezentace jako souboru PPTX. Také uvidíte, jak použít základní formátování obdélníku, například plnou výplň barvou, barvu čáry a šířku čáry. Kromě toho část FAQ článku odkazuje na související úkoly s obdélníky, včetně zaoblených rohů, výplní obrázky, vizuálních efektů, hypertextových odkazů, zamykání tvarů, možností exportu a efektivních vlastností.

## **Přidání obdélníku na snímek**
Chcete-li přidat jednoduchý obdélník na vybraný snímek prezentace, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) typu Rectangle pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addAutoShape) vystavené objektem [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/).
- Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali jednoduchý obdélník na první snímek prezentace.

```php
  # Vytvořte instanci třídy Presentation, která představuje PPTX
  $pres = new Presentation();
  try {
    # Získejte první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přidejte AutoShape typu elipsa
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Uložte soubor PPTX na disk
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přidání formátovaného obdélníku na snímek**
Chcete-li přidat formátovaný obdélník na snímek, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) typu Rectangle pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addAutoShape) vystavené objektem [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/).
- Nastavte [Fill Type](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FillType) obdélníku na Solid.
- Nastavte barvu obdélníku pomocí metody [ColorFormat::setColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/colorformat/#setColor), jak je vystavena objektem [FillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/) spojeným s objektem [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/).
- Nastavte barvu čar obdélníku.
- Nastavte šířku čar obdélníku.
- Zapište upravenou prezentaci jako soubor PPTX.

Výše uvedené kroky jsou implementovány v níže uvedeném příkladu.

```php
  # Vytvořte instanci třídy Presentation, která představuje PPTX
  $pres = new Presentation();
  try {
    # Získejte první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přidejte AutoShape typu elipsy
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Aplikujte nějaké formátování na tvar elipsy
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Aplikujte nějaké formátování na čáru elipsy
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Uložte soubor PPTX na disk
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Jak přidám obdélník s zaoblenými rohy?**

Použijte typ tvaru s zaoblenými rohy [shape type](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapetype/) a upravte poloměr rohu ve vlastnostech tvaru; zaoblení lze také aplikovat na jednotlivé rohy pomocí geometrických úprav.

**Jak vyplním obdélník obrázkem (texturou)?**

Vyberte typ výplně obrázkem [fill type](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/), poskytněte zdroj obrázku a nakonfigurujte [stretching/tiling modes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillmode/).

**Může mít obdélník stín a záři?**

Ano. [Outer/inner shadow, glow, and soft edges](/slides/cs/php-java/shape-effect/) jsou k dispozici s nastavitelnými parametry.

**Mohu převést obdélník na tlačítko s hypertextovým odkazem?**

Ano. [Assign a hyperlink](/slides/cs/php-java/manage-hyperlinks/) na kliknutí tvaru (přechod na snímek, soubor, webovou adresu nebo e‑mail).

**Jak mohu ochránit obdélník před přesunem a změnami?**

Použijte zamykání tvarů: můžete zakázat přesun, změnu velikosti, výběr nebo úpravu textu, aby byl zachován rozvrh.

**Mohu převést obdélník na rastrový obrázek nebo SVG?**

Ano. Můžete [render the shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage) na obrázek se zadanou velikostí/měřítkem nebo [export it as SVG](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/writeassvg/) pro vektorové použití.

**Jak rychle získat skutečné (efektivní) vlastnosti obdélníku s ohledem na téma a dědičnost?**

[Use the shape’s effective properties](/slides/cs/php-java/shape-effective-properties/): API vrací vypočtené hodnoty, které zohledňují styl tématu, rozvržení a místní nastavení, což zjednodušuje analýzu formátování.