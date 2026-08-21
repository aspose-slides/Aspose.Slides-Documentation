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
- vázlat alakzatvonal
- csatlakozási stílus formázása
- színátmenetes kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszósága
- fekete-fehér alakzat megjelenítés
- szürkeárnyalatos alakzat megjelenítés
- alakzat forgatása
- 3D ferde hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan formázhat PowerPoint alakzatokat PHP-ben az Aspose.Slides használatával—állítsa be a kitöltés, vonal és hatás stílusait PPT, PPTX és ODP fájlokhoz precízen és teljes irányítással."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Ezen felül beállítások megadásával szabályozhatja, hogyan töltik ki a belsejüket.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for PHP via Java osztályokat és metódusokat biztosít, amelyekkel a PowerPointban elérhető ugyanazokkal a lehetőségekkel formázhatja az alakzatokat.

## **Vonalak formázása**

Az Aspose.Slides segítségével egy alakzat egyéni vonalstílusát adhatja meg. Az alábbi lépések ismertetik az eljárást:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a sorszám alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linestyle/) attribútumát.
1. Állítsa be a vonal vastagságát.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linedashstyle/) attribútumát.
1. Állítsa be az alakzat vonalszínét.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi PHP kód bemutatja, hogyan formázhat egy téglalap `AutoShape`-t:

```php
// Példányosítja a Presentation osztályt, amely egy prezentáció fájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy Rectangle típusú automatikus alakzatot.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Beállítja a téglalap alakzat kitöltő színét.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Formázza a téglalap vonalait.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Beállítja a téglalap vonalának színét.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The formatted lines in the presentation](formatted-lines.png)

## **Vázlat hatások alkalmazása az alakzat vonalakra**

A vázlat hatás azt a benyomást kelti, mintha kézzel rajzolt vonal lenne. Használja a [Shape.getLineFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) metódust a vonal beállításainak eléréséhez, a [LineFormat.getSketchFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/lineformat/) metódust a vázlat beállításainak eléréséhez, és a [SketchFormat.setSketchType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sketchformat/) metódust a [LineSketchType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linesketchtype/) enumerációból való érték kiválasztásához.

Az alábbi PHP kód megmutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linesketchtype/) hatást, hogyan olvassa ki a kifejezetten beállított értéket, és hogyan távolítsa el a hatást a [LineSketchType.None](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linesketchtype/) használatával:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Hozzáfér az alakzat vonalformátumához és annak vázlatformátumához.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Alkalmaz egy vázlat hatást.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Kiolvassa a alakzatra közvetlenül hozzárendelt vázlat hatást.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Eltávolítja a vázlat hatást.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

A [SketchFormat.getSketchType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sketchformat/) által visszaadott érték az alakzatra közvetlenül hozzárendelt beállítást képviseli. Ha a vonal formázása egy témából, mester- vagy elrendezési diából örökölt, használja a [LineFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/lineformat/) metódust, hívja meg a kapott objektum `getSketchFormat` metódusát, és olvassa ki annak `getSketchType` értékét. A hatékony érték tükrözi azt a formázást, amely ténylegesen alkalmazásra kerül az öröklés feloldása után:

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

A három csatlakozási típus:

* Kerek
* Éles
* Ferde

Alapértelmezés szerint, amikor a PowerPoint két vonalat összekapcsol egy szögben (például egy alakzat sarkán), a **Kerek** beállítást használja. Ha azonban hegyes szögekű alakzatot rajzol, a **Éles** opció lehet előnyösebb.

![The join style in the presentation](join-style-powerpoint.png)

Az alábbi PHP kód bemutatja, hogyan hoztak létre három téglalapot (a fenti képen látható) az Éles, Ferde és Kerek csatlakozási típusokkal:

```php
// Példányosítja a Presentation osztályt, amely egy prezentáció fájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad három Rectangle típusú automatikus alakzatot.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Beállítja minden téglalap alakzat kitöltő színét.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Beállítja a vonalvastagságot.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Beállítja minden téglalap vonalának színét.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Beállítja a csatlakozási stílust.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Szöveget ad minden téglalaphoz.
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

A PowerPointban a Színátmenetes kitöltés egy olyan formázási lehetőség, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan átmegy a másikba.

Így alkalmazhat színátmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a sorszám alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Gradient`-re.
1. Adja hozzá a két kedvenc színét a meghatározott pozíciókkal a [GradientFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/gradientformat/) által biztosított színátmenet‑állomás gyűjtemény `add` metódusaival.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi PHP kód bemutatja, hogyan alkalmazzon színátmenetes kitöltést egy ellipszisre:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy Ellipse típusú automatikus alakzatot.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Alkalmaz színátmenetes formázást az ellipszisre.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Beállítja a színátmenet irányát.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Két színátmeneti állomást ad hozzá.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The ellipse with gradient fill](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy olyan formázási lehetőség, amely lehetővé teszi, hogy két színből álló mintát – például pontokat, csíkokat, keresztelrendezést vagy négyzetrácsot – alkalmazzon egy alakzatra. A minta előtér- és háttérszínéhez egyedi színeket választhat.

Az Aspose.Slides több mint 45 előre definiált mintastílust kínál, amelyeket alakzatokra alkalmazhat a prezentációk megjelenésének fokozásához. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket használni szeretne.

Így alkalmazhat mintát egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a sorszám alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Pattern`-re.
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/php-java/aspose.slides/patternformat/#getBackColor) színét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/php-java/aspose.slides/patternformat/#getForeColor) színét.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi PHP kód bemutatja, hogyan alkalmazzon mintát egy téglalapra:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy Rectangle típusú automatikus alakzatot.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Beállítja a kitöltés típusát Pattern-re.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Beállítja a minta stílusát.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Beállítja a minta háttér- és előtérszínét.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The rectangle with pattern fill](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés egy olyan formázási lehetőség, amellyel egy képet szúrhat be egy alakzatba – gyakorlatilag a képet használja az alakzat háttérként.

Így használhatja az Aspose.Slides‑t kép‑kitöltés alkalmazásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a sorszám alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Picture`-re.
1. Állítsa be a kép kitöltés módját `Tile`-re (vagy a kívánt másik módra).
1. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot a használni kívánt képből.
1. Adja át a képet a `SlidesPicture.setImage` metódusnak.
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy rendelkezünk egy **lotus.png** fájllal a következő képpel:

![The lotus picture](lotus.png)

Az alábbi PHP kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy Rectangle típusú automatikus alakzatot.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Beállítja a kitöltés típusát Picture-re.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Beállítja a kép kitöltés módját.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Betölt egy képet és hozzáadja a prezentáció erőforrásaihoz.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Beállítja a képet.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The shape with picture fill](picture-fill.png)

### **Kép csempézése textúraként**

Ha egy csempézett képet szeretne textúraként beállítani, és testreszabni a csempézés viselkedését, használhatja a [PictureFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/) osztály következő metódusait:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Beállítja a kép kitöltés módját – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileAlignment): Megadja a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileFlip): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre legyen tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kiindulási pontjától.
- [setTileOffsetY](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Beállítja a csempe függőleges eltolását (pontban) az alakzat kiindulási pontjától.
- [setTileScaleX](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileScaleX): Meghatározza a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileScaleY): Meghatározza a csempe függőleges méretezését százalékban.

Az alábbi kódrészlet megmutatja, hogyan adjon egy téglalap alakzatot csempézett kép kitöltéssel, és hogyan konfigurálja a csempe beállításait:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy Rectangle típusú automatikus alakzatot.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Beállítja az alakzat kitöltés típusát Picture-re.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Hozzárendeli a képet az alakzathoz.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Konfigurálja a kép kitöltés módját és a csempézés tulajdonságait.
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

![The tile options](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy olyan formázási lehetőség, amely egyetlen, egyenletes színnel tölti ki az alakzatot. Ez a plain háttérszín gradiensek, textúrák vagy minták nélkül kerül alkalmazásra.

Az egyszínű kitöltés alkalmazásához az Aspose.Slides segítségével kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a sorszám alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Solid`-ra.
1. Rendelje hozzá a kívánt kitöltési színt az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi PHP kód bemutatja, hogyan alkalmazzon egyszínű kitöltést egy téglalapra egy PowerPoint dián:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy Rectangle típusú automatikus alakzatot.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Beállítja a kitöltés típusát Solid-ra.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Beállítja a kitöltés színét.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The shape with solid color fill](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, ha egyszínű, színátmenetes, képes vagy textúrás kitöltést alkalmaz alaprajzokra, beállíthat átlátszósági szintet a kitöltés átlátszatlanságának szabályozásához. A magasabb átlátszósági érték átlátszóbbá teszi az alakzatot, lehetővé téve, hogy a háttér vagy az alatta lévő objektum részben látható legyen.

Az Aspose.Slides lehetővé teszi az átlátszósági szint beállítását a kitöltéshez használt szín alfaértékének módosításával. Így teheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a sorszám alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Solid`-ra.
1. Használja a `Color` osztályt egy átlátszóságot tartalmazó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

Az alábbi PHP kód bemutatja, hogyan alkalmazzon átlátszó kitöltési színt egy téglalapra:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy szilárd téglalap automatikus alakzatot.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Hozzáad egy átlátszó téglalap automatikus alakzatot a szilárd alakzat fölé.
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

![The transparent shape](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet a vizuális elemek bizonyos igazítási vagy tervezési igények szerinti elhelyezésekor.

Alakzat forgatásához a dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a sorszám alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

Az alábbi PHP kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy Rectangle típusú automatikus alakzatot.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Elforgatja az alakzatot 5 fokkal.
    $shape->setRotation(5);

    // Mentse a PPTX fájlt lemezre.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The shape rotation](shape-rotation.png)

## **3D ferde hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D ferde (bevel) hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D ferde hatások hozzáadásához egy alakzatra kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a sorszám alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) tulajdonságait a ferde beállítások meghatározásához.
1. Mentse a prezentációt.

Az alábbi PHP kód megmutatja, hogyan alkalmazzon 3D ferde hatást egy alakzatra:

```php
// Példányosít egy példányt a Presentation osztályból.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy alakzatot a diához.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Beállítja az alakzat ThreeDFormat tulajdonságait.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Mentse a prezentációt PPTX fájlként.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D forgatás alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a sorszám alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Használja a [setCameraType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/camera/#setCameraType) és a [setLightType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/lightrig/#setLightType) metódusokat a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

Az alábbi PHP kód bemutatja, hogyan alkalmazzon 3D forgatási hatást egy alakzatra:

```php
// Létrehoz egy példányt a Presentation osztályból.
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

![The 3D rotation effect](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés vezérlése alakzatokhoz**

A [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#setBlackWhiteMode) metódus meghatározza, hogyan jelenik meg egy adott alakzat, amikor a prezentációt fekete-fehér módban tekintik vagy dolgozzák fel. Nem kapcsol be automatikusan a fekete-fehér megjelenítést, és nem változtatja meg a forma kitöltését, vonalát vagy egyéb formázását normál színmódban.

Használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/blackwhitemode/) osztályból a kívánt viselkedés kiválasztásához. Például az `Automatic` lehetővé teszi, hogy a megjelenítő alkalmazás válassza ki a konverziót, a `Gray` és `LightGray` szürke árnyalatot használ, a `BlackWhite` csak feketét és fehéret, a `Black` és `White` egyetlen színt erőltet, a `Color` megőrzi a normál színezést, a `Hidden` elrejti az alakzatot fekete‑fehér módban, a `NotDefined` pedig azt jelenti, hogy nincs alakzatszintű mód beállítva.

Az alábbi PHP kód egy színes alakzatot hoz létre, és fekete‑fehér megjelenítés esetén szürke színben jeleníti meg:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // Tartsa meg a narancssárga kitöltést színmódban, de a alakzatot szürke színnel jelenítse meg fekete-fehér módban.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Normál színmódban a téglalap megtartja narancssárga kitöltését. Fekete‑fehér megjelenítési munkafolyamat során a `Gray` mód miatt szürke színt kap, így a teljes színű diát megőrizheti, miközben a nyomtatás, előnézet vagy egyéb, a fekete‑fehér beállításokat tiszteletben tartó munkafolyamatokhoz külön megjelenést definiál.

## **Formázás alaphelyzetbe állítása**

Az alábbi Java kód bemutatja, hogyan állíthatja vissza egy dia formázását, és hogyan állíthatja vissza a helyzetet, méretet és a helyőrzőkkel ellátott alakzatok formázását a [LayoutSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/) alapértelmezett beállításaira:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Állítsa vissza a dián lévő minden alakzatot, amelynek helyőrzője van az elrendezésen.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Aforma formázása befolyásolja a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a legtöbb helyet, míg a forma paraméterek, például színek, hatások és színátmenetek metaadatként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan tudok olyan alakzatokat felderíteni egy dián, amelyek azonos formázást használnak, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és hatás beállítások. Ha minden érték egyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa az alakzatokat, ezzel leegyszerűsítve a későbbi stíluskezelést.

**Menthetek egy egyedi forma stíluskészletet egy külön fájlba, hogy más prezentációkban újra felhasználjam?**

Igen. Tároljon minta alakzatokat a kívánt stílusokkal egy sablon diákkönyvtárban vagy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges formázott alakzatokat, és alkalmazza a formázásukat ahol szükséges.