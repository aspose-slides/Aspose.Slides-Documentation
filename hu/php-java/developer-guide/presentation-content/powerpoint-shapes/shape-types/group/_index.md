---
title: Csoportos prezentációs alakzatok PHP-ben
linktitle: Alakzatcsoport
type: docs
weight: 40
url: /hu/php-java/group/
keywords:
- csoport alakzat
- alakzat csoport
- csoport hozzáadása
- alternatív szöveg
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Tanulja meg, hogyan csoportosíthat és felbonthat alakzatokat a PowerPoint prezentációkban az Aspose.Slides for PHP via Java segítségével — gyors, lépésről lépésre útmutató ingyenes kóddal."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan dolgozhatunk csoport alakzatokkal az Aspose.Slides-ban. Bemutatja, hogyan lehet egy csoport alakzatot hozzáadni egy diára, elhelyezni benne alakzatokat, és elmenteni a frissített prezentációt. Továbbá bemutatja, hogyan lehet elérni a csoportban tárolt alakzatokat, és beolvasni azok `AlternativeText` értékeit. Emellett a cikk röviden tárgyalja a csoport‑alakzatra vonatkozó kapcsolódó funkciókat, például a beágyazott csoportokat, a Z‑sorrendet és a zárolási beállításokat.

## **Csoport alakzat hozzáadása**
Az Aspose.Slides támogatja a csoport alakzatok kezelését a diákon. Ez a funkció segít a fejlesztőknek gazdagabb prezentációkat létrehozni. Az Aspose.Slides for PHP via Java támogatja a csoport alakzatok hozzáadását vagy elérését. Lehetséges alakzatokat hozzáadni egy már hozzáadott csoport alakzathoz, hogy feltöltsük azt, vagy elérni a csoport alakzat bármely tulajdonságát. A csoport alakzat diára való hozzáadásához az Aspose.Slides for PHP via Java segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
1. Szerezze be egy dia hivatkozását az Index használatával
1. Adjon hozzá egy csoport alakzatot a diához.
1. Adja hozzá az alakzatokat a hozzáadott csoport alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példa egy csoport alakzatot ad hozzá egy diához.

```php
  # Presentation osztály példányosítása
  $pres = new Presentation();
  try {
    # Az első dia lekérése
    $sld = $pres->getSlides()->get_Item(0);
    # A diák alakzatgyűjteményének elérése
    $slideShapes = $sld->getShapes();
    # Egy csoport alakzat hozzáadása a diához
    $groupShape = $slideShapes->addGroupShape();
    # Alakzatok hozzáadása a hozzáadott csoport alakzathoz
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Csoport alakzat keretének hozzáadása
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # A PPTX fájl írása a lemezre
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Az AltText tulajdonság elérése**
Ez a téma egyszerű lépéseket mutat be, kódrészletekkel együtt, a csoport alakzat hozzáadásához és a csoport alakzatok AltText tulajdonságának eléréséhez a diákon. Az AltText eléréséhez egy csoport alakzaton egy dián az Aspose.Slides for PHP via Java segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból, amely egy PPTX fájlt képvisel.
1. Szerezze be egy dia hivatkozását az Index használatával.
1. Érje el a diák alakzatgyűjteményét.
1. Érje el a csoport alakzatot.
1. Érje el a [Alternative Text](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getAlternativeText) tulajdonságot.

Az alábbi példa a csoport alakzat alternatív szövegét éri el.

```php
  # A PPTX fájlt képviselő Presentation osztály példányosítása
  $pres = new Presentation("AltText.pptx");
  try {
    # Az első dia lekérése
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # A diák alakzatgyűjteményének elérése
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # A csoport alakzat elérése.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Az AltText tulajdonság elérése
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

## **GYIK**

**Támogatott a beágyazott csoportosítás (csoport egy csoporton belül)?**

Igen. A [GroupShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/groupshape/) rendelkezik egy [getParentGroup](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getparentgroup/) metódussal, amely közvetlenül jelzi a hierarchia támogatását (egy csoport egy másik csoport gyermeke lehet).

**Hogyan szabályozhatom a csoport Z‑sorrendjét a diához tartozó egyéb objektumokhoz képest?**

Használja a [GroupShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/groupshape/) [getZOrderPosition](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getzorderposition/) metódusát a pozíciójának megtekintéséhez a megjelenítési veremben.

**Megakadályozhatom a mozgatást/szerkesztést/csoport felbontását?**

Igen. A csoport zárolási szekciója a [GroupShapeLock](https://reference.aspose.com/slides/hu/php-java/aspose.slides/groupshape/getgroupshapelock/) segítségével érhető el, amely lehetővé teszi a műveletek korlátozását az objektumon.