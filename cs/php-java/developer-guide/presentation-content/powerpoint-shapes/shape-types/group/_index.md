---
title: Skupinové tvary prezentace v PHP
linktitle: Skupina tvarů
type: docs
weight: 40
url: /cs/php-java/group/
keywords:
- skupinový tvar
- skupina tvarů
- přidat skupinu
- alternativní text
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se seskupovat a rozdělovat tvary v PowerPoint prezentacích pomocí Aspose.Slides pro PHP via Java — rychlý, krok po kroku návod s volným kódem."
---
## **Overview**

Tento článek vysvětluje, jak pracovat se skupinovými tvary v Aspose.Slides. Ukazuje, jak přidat skupinový tvar do snímku, umístit do něj tvary a uložit aktualizovanou prezentaci. Také demonstruje, jak přistupovat k tvarům uloženým ve skupině a číst jejich hodnoty `AlternativeText`. Navíc článek stručně pokrývá související možnosti skupinových tvarů, jako jsou vnořené skupiny, z-order a možnosti zamykání.

## **Přidání skupinového tvaru**
Aspose.Slides podporuje práci se skupinovými tvary na snímcích. Tato funkce pomáhá vývojářům vytvářet bohatší prezentace. Aspose.Slides for PHP via Java podporuje přidávání a přístup ke skupinovým tvarům. Je možné přidávat tvary do přidaného skupinového tvaru, aby byl naplněn, nebo přistupovat k jakékoli jeho vlastnosti. Chcete-li přidat skupinový tvar do snímku pomocí Aspose.Slides for PHP via Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho Indexu.
1. Přidejte skupinový tvar do snímku.
1. Přidejte tvary do přidaného skupinového tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Níže uvedený příklad přidává skupinový tvar do snímku.

```php
  # Instancujte třídu Presentation
  $pres = new Presentation();
  try {
    # Získejte první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přístup ke kolekci tvarů snímků
    $slideShapes = $sld->getShapes();
    # Přidání skupinového tvaru do snímku
    $groupShape = $slideShapes->addGroupShape();
    # Přidání tvarů do přidaného skupinového tvaru
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Přidání rámce skupinového tvaru
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Zápis souboru PPTX na disk
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přístup k vlastnosti AltText**
Toto téma ukazuje jednoduché kroky, včetně ukázek kódu, pro přidání skupinového tvaru a přístup k vlastnosti AltText skupinových tvarů na snímcích. Chcete-li získat AltText skupinového tvaru ve snímku pomocí Aspose.Slides for PHP via Java:

1. Instancujte třídu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation), která představuje soubor PPTX.
1. Získejte referenci na snímek pomocí jeho Indexu.
1. Přistupte ke sbírce tvarů snímků.
1. Přistupte ke skupinovému tvaru.
1. Přistupte k vlastnosti [Alternative Text](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getAlternativeText).

Níže uvedený příklad získává alternativní text skupinového tvaru.

```php
  # Instancujte třídu Presentation, která představuje soubor PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Získejte první snímek
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Přístup ke kolekci tvarů snímků
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Přístup ke skupinovému tvaru.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Přístup k vlastnosti AltText
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Je podporováno vnořené seskupování (skupina uvnitř skupiny)?**

Ano. [GroupShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/groupshape/) má metodu [getParentGroup](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getparentgroup/), která přímo naznačuje podporu hierarchie (skupina může být podřízena jiné skupině).

**Jak mohu řídit z-order skupiny vzhledem k ostatním objektům na snímku?**

Použijte metodu [getZOrderPosition](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getzorderposition/) třídy [GroupShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/groupshape/), abyste prozkoumali její pozici v zásobníku zobrazení.

**Mohu zabránit přesunu/úpravám/rozbalení skupiny?**

Ano. Sekce zamykání skupiny je zpřístupněna přes [GroupShapeLock](https://reference.aspose.com/slides/cs/php-java/aspose.slides/groupshape/getgroupshapelock/), která vám umožňuje omezit operace s objektem.