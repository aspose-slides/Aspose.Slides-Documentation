---
title: Správa tvarů prezentace v PHP
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/php-java/shape-manipulations/
keywords:
- tvar PowerPoint
- tvar prezentace
- tvar na snímku
- nalezení tvaru
- klonování tvaru
- odstranění tvaru
- skrytí tvaru
- změna pořadí tvaru
- získání Interop ID tvaru
- alternativní text tvaru
- formáty rozvržení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnání tvaru
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se vytvářet, upravovat a optimalizovat tvary v Aspose.Slides pro PHP přes Java a vytvářet výkonné prezentace PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tvary v prezentacích pomocí Aspose.Slides. Ukazuje, jak najít tvar na snímku, klonovat jej, odstranit jej, skrýt jej, změnit jeho pořadí, získat jeho Interop ID tvaru a nastavit alternativní text pro identifikaci a další zpracování.

Také popisuje, jak přistupovat k formátům rozvržení pro tvary, vykreslit tvar jako SVG, zarovnat tvary na snímku a použít vlastnosti překlopení pro horizontální a vertikální zrcadlení. Navíc článek obsahuje stručné FAQ o kombinaci tvarů, pořadí vrstvení a uzamčení tvaru.

## **Najít tvar na snímku**
Tento odstavec popisuje jednoduchou techniku, která vývojářům usnadní nalezení konkrétního tvaru na snímku bez použití jeho interního Id. Je důležité vědět, že soubory PowerPoint Presentation nemají žádný způsob, jak identifikovat tvary na snímku, kromě interního jedinečného Id. Vývojářům se často těžko hledá tvar podle tohoto interního jedinečného Id. Všechny tvary přidané na snímky mají nějaký alternativní text. Doporučujeme vývojářům použít alternativní text pro nalezení konkrétního tvaru. Můžete použít MS PowerPoint k definování alternativního textu pro objekty, které v budoucnu plánujete měnit.

Po nastavení alternativního textu požadovaného tvaru můžete otevřít tuto prezentaci pomocí Aspose.Slides for PHP via Java a iterovat přes všechny tvary na snímku. Během každé iterace můžete zkontrolovat alternativní text tvaru a tvar s odpovídajícím alternativním textem bude požadovaný tvar. Pro lepší předvedení této techniky jsme vytvořili metodu [findShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) , která provede hledání konkrétního tvaru na snímku a vrátí tento tvar.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Alternativní text tvaru, který má být nalezen
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Klonovat tvar**
Pro klonování tvaru na snímku pomocí Aspose.Slides for PHP via Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přistupte ke kolekci tvarů zdrojového snímku.
1. Přidejte nový snímek do prezentace.
1. Klonujte tvary z kolekce tvarů zdrojového snímku do nového snímku.
1. Uložte upravenou prezentaci jako soubor PPTX.

Níže uvedený příklad přidává skupinový tvar na snímek.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Zapište soubor PPTX na disk
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Odstranit tvar**
Aspose.Slides for PHP via Java umožňuje vývojářům odstranit libovolný tvar. Pro odstranění tvaru z libovolného snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Přistupte k prvnímu snímku.
1. Najděte tvar s konkrétním AlternativeText.
1. Odstraňte tvar.
1. Uložte soubor na disk.

```php
  # Vytvořte objekt Presentation
  $pres = new Presentation();
  try {
    # Získejte první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přidejte automatický tvar typu obdélník
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Uložte prezentaci na disk
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Skrýt tvar**
Aspose.Slides for PHP via Java umožňuje vývojářům skrýt libovolný tvar. Pro skrytí tvaru z libovolného snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Přistupte k prvnímu snímku.
1. Najděte tvar s konkrétním AlternativeText.
1. Skryjte tvar.
1. Uložte soubor na disk.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Získejte první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přidejte automatický tvar typu obdélník
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Uložte prezentaci na disk
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Změnit pořadí tvarů**
Aspose.Slides for PHP via Java umožňuje vývojářům změnit pořadí tvarů. Přeskupení tvaru určuje, který tvar je vpředu a který vzadu. Pro změnu pořadí tvarů na libovolném snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Přistupte k prvnímu snímku.
1. Přidejte tvar.
1. Přidejte text do textového rámce tvaru.
1. Přidejte další tvar se stejnými souřadnicemi.
1. Přeskupte tvary.
1. Uložte soubor na disk.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Získat Interop ID tvaru**
Aspose.Slides for PHP via Java umožňuje vývojářům získat jedinečný identifikátor tvaru v rozsahu snímku, na rozdíl od metody [getUniqueId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getuniqueid/), která umožňuje získat jedinečný identifikátor v rámci celé prezentace. Metoda [getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getofficeinteropshapeid/) byla přidána do třídy [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/). Hodnota vrácená metodou [getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getofficeinteropshapeid/) odpovídá hodnotě Id objektu Microsoft.Office.Interop.PowerPoint.Shape. Níže je uveden ukázkový kód.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Získání jedinečného identifikátoru tvaru v rozsahu snímku
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavit alternativní text pro tvar**
Aspose.Slides for PHP via Java umožňuje vývojářům nastavit AlternateText libovolného tvaru.
Tvary v prezentaci lze rozlišovat pomocí `Alternative Text` nebo metody [Shape Name](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/setname/).
Metody [setAlternativeText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/setalternativetext/) a [getAlternativeText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getalternativetext/) lze číst i zapisovat pomocí Aspose.Slides i Microsoft PowerPoint.
Pomocí této metody můžete označit tvar a provádět různé operace, jako je odstranění tvaru,
skrytí tvaru nebo změna pořadí tvarů na snímku.
Pro nastavení AlternateText tvaru postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Přistupte k prvnímu snímku.
1. Přidejte libovolný tvar na snímek.
1. Proveďte požadovanou práci s nově přidaným tvarem.
1. Projděte tvary a najděte požadovaný tvar.
1. Nastavte AlternativeText.
1. Uložte soubor na disk.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Získejte první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přidejte automatický tvar typu obdélník
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Uložte prezentaci na disk
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přístup k formátům rozvržení pro tvar**
Aspose.Slides for PHP via Java poskytuje jednoduché API pro přístup k formátům rozvržení pro tvar. Tento článek demonstruje, jak můžete přistupovat k formátům rozvržení.

Níže je uveden ukázkový kód.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vykreslit tvar jako SVG**
Nyní Aspose.Slides for PHP via Java podporuje vykreslení tvaru jako SVG. Metoda [writeAsSvg](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/writeassvg/) (a její přetížení) byla přidána do třídy [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/). Tato metoda umožňuje uložit obsah tvaru jako soubor SVG. Níže uvedený úryvek kódu ukazuje, jak exportovat tvar snímku do souboru SVG.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zarovnat tvar**
Aspose.Slides umožňuje zarovnávat tvary buď relativně k okrajům snímku, nebo relativně k sobě navzájem. K tomuto účelu byla přidána přetížená metoda [SlidesUtil::alignShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideutil/alignshapes/). Výčtová hodnota [ShapesAlignmentType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapesalignmenttype/) definuje možné možnosti zarovnání.

**Příklad 1**

Zdrojový kód níže zarovnává tvary s indexy 1,2 a 4 podél horního okraje snímku.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Příklad 2**

Níže uvedený příklad ukazuje, jak zarovnat celou kolekci tvarů relativně k nejspodnějšímu tvaru v kolekci.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vlastnosti překlopení**

V Aspose.Slides třída [ShapeFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapeframe/) poskytuje kontrolu nad horizontálním a vertikálním zrcadlením tvarů prostřednictvím svých vlastností `flipH` a `flipV`. Obě vlastnosti jsou typu [NullableBool](https://reference.aspose.com/slides/cs/php-java/aspose.slides/nullablebool/), což umožňuje hodnoty `True` (překlopit), `False` (nepřeklopit) nebo `NotDefined` (použít výchozí chování). Tyto hodnoty jsou přístupné z [Frame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getFrame) tvaru.

Pro úpravu nastavení překlopení se vytvoří nová instance [ShapeFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapeframe/) s aktuální pozicí a velikostí tvaru, požadovanými hodnotami pro `flipH` a `flipV` a úhlem otáčení. Přiřazením této instance k [Frame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getFrame) tvaru a uložením prezentace se aplikují zrcadlové transformace a zapíší se do výstupního souboru.

Předpokládejme, že máme soubor sample.pptx, ve kterém první snímek obsahuje jediný tvar s výchozím nastavením překlopení, jak je znázorněno níže.

![Tvar, který se má překlopit](shape_to_be_flipped.png)

Následující ukázkový kód získá aktuální vlastnosti překlopení tvaru a překlopí jej horizontálně i vertikálně.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Získání vlastnosti horizontálního překlopení tvaru.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Získání vlastnosti vertikálního překlopení tvaru.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Překlopit horizontálně.
    $flipV = NullableBool::True; // Překlopit horizontálně.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Překlopený tvar](flipped_shape.png)

## **FAQ**

**Mohu kombinovat tvary (sjednocení/průnik/odečtení) na snímku jako v desktopovém editoru?**

Neexistuje vestavěné API pro boolovské operace. Můžete to aproximovat vytvořením požadovaného obrysu sami – např. vypočítat výslednou geometrii (pomocí [GeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometrypath/)) a vytvořit nový tvar s tímto obrysem, případně odstranit původní tvary.

**Jak mohu ovládat pořadí vrstvení (z‑order), aby tvar zůstával vždy „nahoru“?**

Změňte pořadí vložení/přesunu v kolekci [shapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/#getShapes) snímku. Pro předvídatelné výsledky nastavte z‑order po všech ostatních úpravách snímku.

**Mohu „uzamknout“ tvar, aby jej uživatelé v PowerPointu nemohli upravovat?**

Ano. Nastavte ochranné příznaky na úrovni tvaru (např. uzamknutí výběru, přesunu, změny velikosti, úprav textu). V případě potřeby můžete omezit i na úrovni masteru nebo rozvržení. Upozorňujeme, že jde o ochranu na úrovni UI, nikoli o bezpečnostní prvek; pro silnější ochranu kombinujte s omezeními na úrovni souboru, jako jsou [doporučení pro pouze‑čtení nebo hesla](/slides/cs/php-java/password-protected-presentation/).