---
title: PowerPoint alakzatok formázása PHP-ben
linktitle: Alakzatformázás
type: docs
weight: 20
url: /hu/php-java/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- csatlakozási stílus formázása
- színátmenetes kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- egységes színű kitöltés
- alakzat átlátszóság
- alakzat forgatása
- 3D rézsút hatás
- 3D forgatás hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat PHP-ben az Aspose.Slides használatával — állítson be kitöltési, vonal- és effektusstílusokat PPT, PPTX és ODP fájlokhoz precízen és teljes ellenőrzéssel."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a vonalak körvonalának módosításával vagy effektusok alkalmazásával. Emellett megadhat beállításokat, amelyek szabályozzák, hogyan töltik ki a belsejüket.

![alakzat formázása PowerPointban](format-shape-powerpoint.png)

Az Aspose.Slides for PHP via Java osztályokat és metódusokat biztosít, amelyekkel ugyanazokkal a lehetőségekkel formázhatja az alakzatokat, mint a PowerPointban.

## **Vonalkörvonalak formázása**

Az Aspose.Slides használatával egy alakzatra megadhat egy egyéni vonalstílust. Az alábbi lépések mutatják a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára a sorszáma alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linestyle/)‑ját.
1. Állítsa be a vonalvastagságot.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linedashstyle/)‑ját.
1. Állítsa be az alakzat vonalszínt.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi PHP‑kód bemutatja, hogyan formázhat egy `AutoShape` téglalapot:

```php
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjon hozzá egy automatikus alakzatot Rectangle típusúként.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Állítsa be a téglalap alakzat kitöltőszínét.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Alkalmazza a formázást a téglalap vonalaira.
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

![A formázott vonalak a prezentációban](formatted-lines.png)

## **Csatlakozási stílusok formázása**

A három csatlakozási típus lehetősége:

* Kerek
* Vágott
* Ferde

Alapértelmezés szerint, amikor a PowerPoint két vonalat szöggel illeszt össze (például egy alakzat sarkán), a **Kerek** beállítást használja. Ha azonban hegyes szögekkel rendelkező alakzatot rajzol, a **Vágott** opció lehet előnyösebb.

![A csatlakozási stílus a prezentációban](join-style-powerpoint.png)

Az alábbi PHP‑kód bemutatja, hogyan hozták létre a három téglalapot (az előző képen látható) a Vágott, Ferde és Kerek csatlakozási típus beállításokkal:

```php
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjon hozzá három automatikus alakzatot Rectangle típusúként.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Állítsa be a kitöltőszínt minden téglalap alakzatra.
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

    // Állítsa be minden téglalap vonalának színét.
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

A PowerPointban a Színátmenetes kitöltés egy formázási lehetőség, amely folyamatos színkeverést alkalmaz egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan elhalványul a másikba.

A színátmenetes kitöltés alkalmazásához Aspose.Slides‑el:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára a sorszáma alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Gradient`‑re.
1. Adja hozzá a két kedvenc színét a pozícióval együtt a [GradientFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/gradientformat/) osztály által biztosított gradient stop gyűjtemény `add` metódusaival.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi PHP‑kód bemutatja, hogyan alkalmazzon színátmenetes kitöltést egy ellipszisen:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy automatikus alakzatot Ellipse típusúként.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Alkalmazza a színátmenetes formázást az ellipszisre.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Beállítja a színátmenet irányát.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Két színátmenetállomást ad hozzá.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Mentse a PPTX fájlt a lemezre.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Ellipszis színátmenetes kitöltéssel](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy formázási lehetőség, amely két színű mintát (például pöttyök, csíkok, keresztminták vagy négyzethálók) alkalmaz egy alakzatra. A minta előtér és háttér színét egyénileg is megadhatja.

Az Aspose.Slides több mint 45 előre definiált mintastílust kínál, amelyeket alakzatokra alkalmazhat a prezentációk vizuális vonzerejének növelése érdekében. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket.

A minta kitöltés alkalmazásához Aspose.Slides‑el:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára a sorszáma alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Pattern`‑re.
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/php-java/aspose.slides/patternformat/#getBackColor)‑ját.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/php-java/aspose.slides/patternformat/#getForeColor)‑ját.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi PHP‑kód bemutatja, hogyan alkalmazzon minta kitöltést egy téglalapra:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusúként.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Beállítja a kitöltés típusát Pattern-re.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Beállítja a minta stílusát.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Beállítja a minta háttér- és előtérszínét.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Mentse a PPTX fájlt a lemezre.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés egy formázási lehetőség, amely lehetővé teszi egy kép beillesztését egy alakzatba – lényegében a képet az alakzat háttérként használva.

A kép kitöltés alkalmazásához Aspose.Slides‑el:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára a sorszáma alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Picture`‑re.
1. Állítsa be a kép kitöltés módját `Tile`‑re (vagy másik kívánt módra).
1. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot a használni kívánt képből.
1. Adja át a képet a `SlidesPicture.setImage` metódusnak.
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy „lotus.png” nevű fájlunk a következő képpel:

![A lotus kép](lotus.png)

Az alábbi PHP‑kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusúként.
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

    // Mentse a PPTX fájlt a lemezre.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Kép csempézése textúraként**

Ha csempézett képet szeretne textúraként beállítani, és testre szabni a csempézés viselkedését, a [PictureFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/) osztály következő metódusait használhatja:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Beállítja a kép kitöltés módját – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileAlignment): Meghatározza a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileFlip): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkét irányban legyen-e tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Beállítja a csempe vízszintes eltolását (pontban) az alakzat origójától.
- [setTileOffsetY](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Beállítja a csempe függőleges eltolását (pontban) az alakzat origójától.
- [setTileScaleX](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileScaleX): Meghatározza a csempe vízszintes skáláját százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#setTileScaleY): Meghatározza a csempe függőleges skáláját százalékban.

Az alábbi kódrészlet megmutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett kép kitöltéssel, és hogyan konfigurálja a csempe beállításait:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy téglalap automatikus alakzatot.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Beállítja az alakzat kitöltésének típusát Picture-re.
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

    // Mentse a PPTX fájlt a lemezre.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A csempe beállítások](tile-options.png)

## **Egyetlen színű kitöltés**

A PowerPointban az Egyetlen színű kitöltés egy formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez a sima háttérszín nincs semmilyen színátmenettel, textúrával vagy mintával ellátva.

Az egyetlen színű kitöltés alkalmazásához Aspose.Slides‑el kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára a sorszáma alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Solid`‑ra.
1. Adja meg a kívánt kitöltőszínt az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi PHP‑kód bemutatja, hogyan alkalmazzon egyetlen színű kitöltést egy téglalapra egy PowerPoint dián:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusúként.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Beállítja a kitöltés típusát Solid-re.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Beállítja a kitöltőszínt.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Mentse a PPTX fájlt a lemezre.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az alakzat egyetlen színű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

PowerPointban, ha egyetlen színt, színátmenetet, képet vagy textúrát alkalmaz kitöltésként az alakzatokra, beállíthat átlátszósági szintet is, amely szabályozza a kitöltés átlátszóságát. Minél nagyobb az átlátszóság, annál áttetszőbb az alakzat, és a háttér vagy az alatta lévő elemek részben láthatóak lesznek.

Az Aspose.Slides lehetővé teszi az átlátszósági szint beállítását a kitöltés színének alfa értékének módosításával. Így teheti meg:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára a sorszáma alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Solid`‑ra.
1. Használja a `Color`‑t egy átlátszósággal rendelkező szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

Az alábbi PHP‑kód bemutatja, hogyan alkalmazzon átlátszó kitöltőszínt egy téglalapra:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy szilárd téglalap automatikus alakzatot.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Hozzáad egy áttetsző téglalap automatikus alakzatot a szilárd alakzat fölé.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Mentse a PPTX fájlt a lemezre.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet, ha vizuális elemeket specifikus igazítási vagy tervezési igényekkel szeretne elhelyezni.

Alakzat forgatásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára a sorszáma alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

Az alábbi PHP‑kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:

```php
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation();
try {
    // Lekéri az első diát.
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusúként.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Elforgatja az alakzatot 5 fokkal.
    $shape->setRotation(5);

    // Mentse a PPTX fájlt a lemezre.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D rézsút hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D rézsút hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D rézsút hatások hozzáadásához egy alakzathoz kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára a sorszáma alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/)‑ját a rézsút beállítások meghatározásához.
1. Mentse a prezentációt.

Az alábbi PHP‑kód megmutatja, hogyan alkalmazzon 3D rézsút hatásokat egy alakzatra:

```php
// Létrehozza a Presentation osztály egy példányát.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Hozzáad egy alakzatot a diára.
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

![3D rézsút hatás](3D-bevel-effect.png)

## **3D forgatás hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatás hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D forgatás alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára a sorszáma alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
1. Használja a [setCameraType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/camera/#setCameraType) és a [setLightType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/lightrig/#setLightType) metódusokat a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

Az alábbi PHP‑kód bemutatja, hogyan alkalmazzon 3D forgatás hatásokat egy alakzatra:

```php
// Létrehozza a Presentation osztály egy példányát.
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

![3D forgatás hatás](3D-rotation-effect.png)

## **Formázás visszaállítása**

Az alábbi Java‑kód bemutatja, hogyan állítsa vissza egy dia formázását, és hogyan hozza vissza az összes alakzat (helyőrzőkkel) pozícióját, méretét és formázását a [LayoutSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/) alapértelmezett beállításaiba:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Visszaállítja a dián lévő minden alakzatot, amelynek elrendezésen helyőrzője van.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**A formaformázás befolyásolja a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a legtöbb helyet, míg a forma paraméterek – színek, effektusok, színátmenetek – metaadatként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan lehet felismerni egy dián azonos formázású alakzatokat, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effekt beállítások. Ha minden megfelelő érték megegyezik, tekintse őket azonos stílusúnak, és logikusan csoportosítsa őket, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek-e egy egyedi forma stíluskészletet egy külön fájlba, hogy más prezentációkban is felhasználjam?**

Igen. Tárolja a kívánt stílusokkal ellátott minta alakzatokat egy sablon‑diakönyvtárban vagy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza újra a formázásukat a kívánt helyeken.