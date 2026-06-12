---
title: Přidání elips do prezentací v PHP
linktitle: Elipsa
type: docs
weight: 30
url: /cs/php-java/ellipse/
keywords:
- elipsa
- tvar
- přidat elipsu
- vytvořit elipsu
- nakreslit elipsu
- formátovaná elipsa
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se vytvářet, formátovat a manipulovat s elipsovými tvary v Aspose.Slides pro PHP pomocí Java napříč prezentacemi PPT a PPTX — včetně ukázkových kódů."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat elipsové tvary do snímků PowerPointu. Pokrývá vytvoření jednoduché elipsy, vytvoření formátované elipsy a uložení aktualizované prezentace jako souboru PPTX. Také se dotýká souvisejících otázek, jako je práce s polohou a velikostí elipsy, řízení pořadí vrstvení a použití animačních efektů.

## **Vytvoření elipsy**
Chcete-li přidat jednoduchou elipsu na vybraný snímek prezentace, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Ellipse pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addAutoShape), kterou poskytuje objekt [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/).
- Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali elipsu na první snímek

```php
  # Vytvořte instanci třídy Presentation, která představuje PPTX
  $pres = new Presentation();
  try {
    # Získat první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přidat AutoShape typu elipsa
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Zapsat soubor PPTX na disk
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vytvoření formátované elipsy**
Chcete-li přidat lépe formátovanou elipsu na snímek, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Ellipse pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addAutoShape), kterou poskytuje objekt [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/).
- Nastavte typ výplně elipsy na Solid.
- Nastavte barvu elipsy pomocí metody `SolidFillColor::setColor`, kterou poskytuje objekt [FillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/) připojený k objektu [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/).
- Nastavte barvu čar elipsy.
- Nastavte šířku čar elipsy.
- Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali formátovanou elipsu na první snímek prezentace.

```php
  # Vytvořte instanci třídy Presentation, která představuje PPTX
  $pres = new Presentation();
  try {
    # Získat první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přidat AutoShape typu elipsa
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Aplikovat určité formátování na tvar elipsy
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Aplikovat určité formátování na čáru elipsy
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Zapsat soubor PPTX na disk
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Jak mohu nastavit přesnou polohu a velikost elipsy vzhledem k jednotkám snímku?**

Souřadnice a velikosti jsou obvykle uváděny **v bodech**. Pro předvídatelné výsledky založte výpočty na velikosti snímku a před přiřazením hodnot převádějte požadované milimetry nebo palce na body.

**Jak mohu umístit elipsu nad nebo pod jiné objekty (ovládat pořadí vrstvení)?**

Upravte pořadí kreslení objektu tím, že jej přenesete dopředu nebo dozadu. Tím umožníte, aby elipsa překrývala jiné objekty nebo odhalila ty pod ní.

**Jak mohu animovat vzhled nebo zvýraznění elipsy?**

[Apply](/slides/cs/php-java/shape-animation/) vstupní, zvýrazňovací nebo výstupní efekty na tvar a nakonfigurujte spouštěče a časování, abyste určili, kdy a jak se animace přehraje.