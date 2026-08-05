---
title: PowerPoint alakzatok formázása PHP-ben
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/php-java/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- alakzat vonal vázlat
- csatlakozási stílus formázása
- színátmenetes kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszóság
- alakzat forgatása
- 3D bevel hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat PHP-ben az Aspose.Slides segítségével – állítsa be a kitöltés, vonal és hatás stílusait PPT, PPTX és ODP fájlokhoz pontosan és teljes kontrollal."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Emellett beállítások megadásával szabályozhatja, hogyan töltik ki az alakzatok belsejét.

![alakzat-formázása PowerPointban](format-shape-powerpoint.png)

Az Aspose.Slides for PHP via Java osztályokat és metódusokat biztosít, amelyekkel a PowerPointban elérhető ugyanazokat a lehetőségeket használhatja az alakzatok formázásához.

## **Vonalak formázása**

Az Aspose.Slides segítségével egy alakzathoz egyedi vonalstílust adhat meg. A következő lépések mutatják a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Kapjon hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linestyle/)‑ját.
1. Állítsa be a vonal vastagságát.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linedashstyle/)‑ját.
1. Állítsa be az alakzat vonalszínét.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi PHP‑kód bemutatja, hogyan formázhat egy „Rectangle” AutoShape‑t:

```php
// Példányosítsa a Presentation osztályt, amely egy prezentáció fájlt képvisel.
$presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjon hozzá egy automatikus alakzatot Rectangle típusú.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Állítsa be a téglalap alakzat kitöltő színét.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Alkalmazzon formázást a téglalap vonalaira.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Állítsa be a téglalap vonalának színét.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A formázott vonalak a bemutatóban](formatted-lines.png)

## **Vázlat hatások alkalmazása az alakzatvonalakra**

A vázlat hatás hand‑drawn (kézzel rajzolt) kinézetet kölcsönöz a vonalnak. Használja a [Shape.getLineFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/)‑t a vonal beállításainak eléréséhez, a [LineFormat.getSketchFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/lineformat/)‑t a vázlat beállításokhoz, és a [SketchFormat.setSketchType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sketchformat/)‑t a [LineSketchType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linesketchtype/) felsorolásból való érték kiválasztásához.

Az alábbi PHP‑kód bemutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linesketchtype/) hatást, hogyan olvassa ki a kifejezetten beállított értéket, és hogyan távolítsa el a hatást a [LineSketchType.None](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linesketchtype/) segítségével:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Érje el az alakzat vonalformátumát és annak vázlatformátumát.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Alkalmazzon egy vázlat hatást.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Olvassa be a alakzatra közvetlenül rendelt vázlat hatást.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Távolítsa el a vázlat hatást.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

A [SketchFormat.getSketchType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sketchformat/) által visszaadott érték közvetlenül az alakzatra beállított értéket jelenti. Ha a vonalformázás egy témából, mester‑diából vagy elrendezési diából öröklődik, használja a [LineFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/lineformat/)‑t, hívja meg a kapott objektum `getSketchFormat` metódusát, és olvassa ki a `getSketchType` értéket. A hatékony érték tükrözi a ténylegesen alkalmazott formázást az öröklődés feloldása után:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Csatlakozási stílusok formázása**

A három csatlakozási típus lehetősége:

* Round
* Miter
* Bevel

Alapértelmezés szerint, amikor a PowerPoint két vonalat szögnél (például egy alakzat sarkán) egyesít, a **Round** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, a **Miter** opció lehet előnyösebb.

![A csatlakozási stílus a bemutatóban](join-style-powerpoint.png)

Az alábbi PHP‑kód bemutatja, hogyan hozhatók létre három téglalap (az előző képen látható módon) a Miter, Bevel és Round csatlakozási beállításokkal:

```php
// Példányosítsa a Presentation osztályt, amely egy prezentáció fájlt képvisel.
$presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjon hozzá három automatikus alakzatot Rectangle típusú.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Állítsa be a kitöltő színt minden téglalap alakzatra.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Állítsa be a vonal vastagságát.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Állítsa be a vonal színét minden téglalaphoz.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Állítsa be a csatlakozási stílust.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Adjon szöveget minden téglalaphoz.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Színátmenetes kitöltés**

A PowerPointban a Gradient Fill (színátmenetes kitöltés) olyan formázási lehetőség, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt úgy adhat meg, hogy az egyik fokozatosan elhalványul a másikba.

Az alábbiakban bemutatjuk, hogyan alkalmazzon színátmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Kapjon hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Gradient`‑ra.
1. Adja hozzá a két kedvenc színét a meghatározott pozíciókkal a [GradientFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/gradientformat/) osztály által biztosított gradient stop gyűjtemény `add` metódusaival.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi PHP‑kód bemutatja, hogyan alkalmazzon színátmenetes kitöltést egy ellipszisre:

```php
// Példányosítsa a Presentation osztályt, amely egy prezentáció fájlt képvisel.
$presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjon hozzá egy automatikus alakzatot Ellipse típusú.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Alkalmazzon színátmenetes formázást az ellipszisre.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Állítsa be a színátmenet irányát.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Adjon hozzá két színátmenet pontot.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az ellipszis színátmenetes kitöltéssel](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Pattern Fill (minta kitöltés) egy olyan formázási lehetőség, amely két színű dizájnt – például pontokat, csíkokat, keresztmintákat vagy négyzeteket – tesz lehetővé egy alakzaton. A minta előtér és háttér színét egyénileg is megadhatja.

Az Aspose.Slides több mint 45 előre definiált minta stílust kínál, amelyeket alakzatokra alkalmazhat a bemutatók vizuális vonzerejének növelése érdekében. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket használni kell.

Az alábbiakban bemutatjuk, hogyan alkalmazzon minta kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Kapjon hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Pattern`‑ra.
1. Válasszon egy minta stílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/php-java/aspose.slides/patternformat/#getBackColor) értékét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/php-java/aspose.slides/patternformat/#getForeColor) értékét.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi PHP‑kód bemutatja, hogyan alkalmazzon minta kitöltést egy téglalapra:

```php
// Példányosítsa a Presentation osztályt, amely egy prezentáció fájlt képvisel.
$presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjon hozzá egy automatikus alakzatot Rectangle típusú.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltési típust Pattern-re.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Állítsa be a minta stílusát.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Állítsa be a minta háttér- és előtérszíneit.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Picture Fill (kép kitöltés) egy formázási lehetőség, amely lehetővé teszi, hogy egy képet ágyazzon be egy alakzatba – a képet gyakorlatilag az alakzat háttérként használja.

Az alábbiakban bemutatjuk, hogyan használja az Aspose.Slides‑t a kép kitöltés alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Kapjon hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Picture`‑ra.
1. Állítsa be a kép kitöltés módját `Tile`‑re (vagy egy másik kívánt módra).
1. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot a felhasználni kívánt képből.
1. Adja át a képet a `SlidesPicture.setImage` metódusnak.
1. Mentse a módosított bemutatót PPTX fájlként.

Tegyük fel, hogy van egy „lotus.png” fájlunk a következő képpel:

![A lotus kép](lotus.png)

Az alábbi PHP‑kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:

```php
// Példányosítsa a Presentation osztályt, amely egy prezentáció fájlt képvisel.
$presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjon hozzá egy automatikus alakzatot Rectangle típusú.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Állítsa be a kitöltési típust Picture-re.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Állítsa be a kép kitöltés módját.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Töltsön be egy képet, és adja hozzá a prezentáció erőforrásaihoz.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Állítsa be a képet.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Kép csempeként textúra**

Ha egy csempézett képet szeretne textúraként beállítani, és testreszabni a csempézés viselkedését, használhatja a [PictureFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/) osztály következő metódusait:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Beállítja a kép kitöltés módját – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileAlignment): Megadja a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileFlip): Meghatározza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőnél fel legyen-e tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kiindulópontjától.
- [setTileOffsetY](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Beállítja a csempe függőleges eltolását (pontban) az alakzat kiindulópontjától.
- [setTileScaleX](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileScaleX): Meghatározza a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileScaleY): Meghatározza a csempe függőleges méretezését százalékban.

Az alábbi kódminta megmutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett kép kitöltéssel, és hogyan konfigurálja a csempe beállításait:

```php
// Példányosítsa a Presentation osztályt, amely egy prezentáció fájlt képvisel.
$presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Adjon hozzá egy téglalap auto alakzatot.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Állítsa be az alakzat kitöltési típusát Picture-re.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Töltse be a képet, és adja hozzá a prezentáció erőforrásaihoz.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Rendelje hozzá a képet az alakzathoz.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Állítsa be a kép kitöltés módját és a csempe tulajdonságait.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A csempe beállítások](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban a Solid Color Fill (egyszínű kitöltés) egy olyan formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez a tiszta háttérszín gradient, textúra vagy minta nélkül kerül alkalmazásra.

Az egyszínű kitöltés alkalmazásához az Aspose.Slides‑sel kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Kapjon hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Solid`‑ra.
1. Rendelje hozzá a kívánt kitöltőszínt az alakzathoz.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi PHP‑kód bemutatja, hogyan alkalmazzon egyszínű kitöltést egy téglalapra egy PowerPoint dián:

```php
    // Példányosítsa a Presentation osztályt, amely egy prezentáció fájlt képvisel.
    $presentation = new Presentation();
    try {
        // Szerezze meg az első diát.
        $slide = $presentation->getSlides()->get_Item(0);

        // Adjon hozzá egy automatikus alakzatot Rectangle típusú.
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

        // Állítsa be a kitöltési típust Solid-re.
        $shape->getFillFormat()->setFillType(FillType::Solid);

        // Állítsa be a kitöltés színét.
        $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

        // Mentse a PPTX fájlt lemezre.
        $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
```

Az eredmény:

![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

PowerPointban, ha egy alakzatra egyszínű, színátmenetes, képes vagy textúrás kitöltést alkalmaz, beállíthat átlátszósági szintet a kitöltés átlátszóságának szabályozásához. Magasabb átlátszósági érték a alakzatot áttetszőbbé teszi, lehetővé téve a háttér vagy az alatta lévő objektumok részleges megjelenését.

Az Aspose.Slides a kitöltéshez használt szín alfa‑értékének módosításával teszi lehetővé az átlátszóság beállítását. Így teheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Kapjon hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Solid`‑ra.
1. Használja a `Color`‑t egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a bemutatót.

Az alábbi PHP‑kód bemutatja, hogyan alkalmazzon átlátszó kitöltőszínt egy téglalapra:

```php
// Példányosítsa a Presentation osztályt, amely egy prezentáció fájlt képvisel.
$presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjon hozzá egy szilárd téglalap auto alakzatot.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Adjon hozzá egy átlátszó téglalap auto alakzatot a szilárd alakzat fölé.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint‑prezentációkban. Ez hasznos lehet a vizuális elemek meghatározott igazítású vagy tervezési igények szerinti elhelyezéséhez.

Az alakzat forgatásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Kapjon hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat forgatás tulajdonságát a kívánt szögre.
1. Mentse a bemutatót.

Az alábbi PHP‑kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:

```php
// Példányosítsa a Presentation osztályt, amely egy prezentáció fájlt képvisel.
$presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjon hozzá egy automatikus alakzatot Rectangle típusú.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Forgassa el a alakzatot 5 fokkal.
    $shape->setRotation(5);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D bevel hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D bevel hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D bevel hatások hozzáadásához egy alakzathoz kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Kapjon hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) beállításait a bevel paraméterek meghatározásához.
1. Mentse a bemutatót.

Az alábbi PHP‑kód mutatja, hogyan alkalmazzon 3D bevel hatásokat egy alakzaton:

```php
// Hozzon létre egy példányt a Presentation osztályból.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjon hozzá egy alakzatot a diához.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Állítsa be az alakzat ThreeDFormat tulajdonságait.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A 3D bevel hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) tulajdonságainak beállításával.

3D forgatás alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Kapjon hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Használja a [setCameraType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/camera/#setCameraType) és a [setLightType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/lightrig/#setLightType) metódusokat a 3D forgatás definiálásához.
1. Mentse a bemutatót.

Az alábbi PHP‑kód bemutatja, hogyan alkalmazzon 3D forgatási hatásokat egy alakzaton:

```php
// Hozzon létre egy példányt a Presentation osztályból.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Mentse a prezentációt PPTX fájlként.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A 3D forgatási hatás](3D-rotation-effect.png)

## **Formázás visszaállítása**

Az alábbi Java‑kód bemutatja, hogyan állítható vissza egy dia formázása, és hogyan lehet az összes helykitöltővel ellátott alakzat helyzetét, méretét és formázását a [LayoutSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/)‑on alapértelmezett beállításokra visszaállítani:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Visszaállítja a dián lévő minden olyan alakzatot, amelynek helykitöltője van az elrendezésben.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**A alakzat formázása befolyásolja a végleges prezentáció fájlméretét?**

Csupán nagyon kevés mértékben. A beágyazott képek és médiafájlok használata teszi ki a fájl legnagyobb részét, míg az olyan alakzatparaméterek, mint színek, hatások és színátmenetek, metaadatként kerülnek tárolásra, és gyakorlatilag nem növelik a méretet.

**Hogyan tudom felismerni egy dián azokat az alakzatokat, amelyek azonos formázással rendelkeznek, hogy csoportosíthassam őket?**

Hasonlítsa össze az egyes alakzatok kulcsfontosságú formázási tulajdonságait – a kitöltés, vonal és effekt beállításait. Ha minden megfelelõ érték egyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa ezeket az alakzatokat, ezzel egyszerűsítve a későbbi stíluskezelést.

**Menthetek egyedi alakzastiákat külön fájlba, hogy más prezentációkban is felhasználhassam őket?**

Igen. Tárolja a kívánt stílusokkal ellátott mintaalakzatokat egy sablon‑diakönyvben vagy egy .POTX sablonfájlban. Új bemutató létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázásukat a kívánt helyeken.