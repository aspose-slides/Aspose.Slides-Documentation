---
title: Prezentáció alakzatainak kezelése PHP-ben
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/php-java/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentáció alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat-azonosító lekérése
- alakzat alternatív szöveg
- alakzat elrendezés formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan azonosíthatja, klónozhatja, eltávolíthatja, elrejtheti, átrendezheti, exportálhatja, igazíthatja és tükrözheti a prezentáció alakzatokat az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java a dián lévő alakzatokat egy rendezett [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/)‑ként ábrázolja. A gyűjtemény egyszerre a hely, ahol az alakzatokat megtalálhatja és módosíthatja, valamint a rétegezési sorrendük forrása: a `0` index a leghátsó alakzat, míg az utolsó index a legelületesebb alakzat.

Ez a cikk ezen modell alapján készült. Először bemutatja, hogyan azonosítsunk egy alakzatot megbízhatóan, majd megmutatja, hogyan klónozzunk, távolítsunk el, rejtsünk el és rendezzünk át alakzatokat. Az utolsó szakaszok a layout‑szintű formázást, SVG‑exportálást, igazítást és tükrözési beállításokat fedik le. Minden példa független, így csak azokat a műveleteket használhatja, amelyekre a munkafolyamata szükséget igényel.

## **Alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a prezentáció szerkesztési és karbantartási módja alapján:

- A [Name](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getname/) hasznos fejlesztői vezérelt sablonokhoz, és könnyen ellenőrizhető a PowerPoint **Selection Pane**‑jében. A neveket szerkeszthető, és nem garantált a egyediség, ezért alakítsa ki a név-konvenciót, ha a kód ezekre támaszkodik.
- Az [AlternativeText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getalternativetext/) akkor hasznos, ha egy hozzáférhetőségi leírás vagy a szerző által megadott címke már azonosítja az alakzatot. Látható a felhasználók számára, lokalizálható vagy átírható a hozzáférhetőség érdekében, és nem garantált az egyediség. Ne használja csendben jelentős hozzáférhetőségi szöveget adatbáziskulcsként.
- Az [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getofficeinteropshapeid/) egy csak‑olvasásra szánt azonosító, amely egy dián belül egyedi, és megfelel a PowerPoint interop által használt alakzat‑azonosítónak. Használja, ha PowerPoint‑integrációval dolgozik, vagy ha egyértelmű hivatkozásra van szükség egy alakzat életciklusa során. A klónozott vagy újra‑létrehozott alakzat másik alakzat, és saját azonosítót kap.

A kapcsolódó [Shape::getUniqueId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getuniqueid/) metódus prezentáció‑szintű azonosítót ad vissza, de ezt a kiegészítők használják, és újra‑hozzárendelhető. Nem tekinthető állandó külső kulcsnak. Ha hosszú távú azonosításra van szükség, tartsa a leképezést az alkalmazás adatában, és ellenőrizze, hogy a várt alakzat még létezik‑e.

Az alábbi példa név szerint keres pontos összehasonlítással, és a diára korlátozott interop‑azonosítót adja vissza. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelzi, ahelyett, hogy a helytelen objektummal folytatná a feldolgozást.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Amikor egy művelet alakzat‑típusra specifikus, ellenőrizze a futás‑idejű osztályt, mielőtt típus‑specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a megnevezett objektum egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Az alakzatgyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és átrendezés módszerei azonnal a gyűjteményen hatnak. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon az előtte rögzített indexekre.

### **Alakzat klónozása**

A [ShapeCollection::addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addclone/) egy független másolatot hoz létre, és a célgynémához fűzi. A [ShapeCollection::insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/insertclone/) szintén másolatot készít, de a megadott z‑rend indexre helyezi. A koordinátákat fogadó túlterhelések a méretet változtatás nélkül mozdítják; a szélesség‑ és magasság‑paraméteres túlterhelések átméretezhetik is.

A példa létrehoz egy cél‑diát, klónoz egy címkével ellátott téglalapot az előre, és a második klónt a háttérbe szúrja be. Az egyes klónok módosítása nem befolyásolja a forrás‑alakzatot.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A klónozás másolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szöveget is. Adjon új logikai azonosítókat a klónnak, ha ezeknek egyedinek kell lenniük. A komplex alakzatok által használt erőforrásokat a prezentáció kezeli, de a klón egy új gyűjteményelem, új alakzat‑azonosítóval.

### **Alakzatok eltávolítása**

A [ShapeCollection::remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/remove/) egy konkrét alakzat‑objektumot töröl a gyűjteményéből. Több egyező eltávolításakor index‑alapú iteráció közben járjon visszafelé, hogy a maradó indexek érvényben maradjanak.

Ez a példa minden megadott nevű alakzatot eltávolít. Az aktuális indexnél lévő alakzatot olvassa, nem egy fix gyűjteményelemet, és nem kényszeríti a felesleges átkonvertálást.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Eltávolítás után az alakzatszám és a későbbi alakzatok indexei megváltoznak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak a mentett indexeknél. Vegye figyelembe a connector‑okat, animációkat és egyéb prezentációs elemeket, amelyek az eltávolított objektumra hivatkozhatnak; egy látható alakzat eltávolítása több, mint a dia megjelenését módosíthatja.

### **Alakzat elrejtése**

A [Shape::setHidden](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/sethidden/) `true`‑ra állítása megtartja az alakzatot a gyűjmentében, de megakadályozza, hogy a normál diavetítésben megjelenjen. Az indexe, formázása és tartalma továbbra is elérhető a kódban, így az elrejtés alkalmas opcionális elemekhez, amelyeket később visszaállíthat.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az elrejtés nem törlés vagy biztonsági funkció. Az objektum továbbra is felfedezhető és visszakapcsolható felhasználó vagy kód által, és a prezentáció fájl részét képezi.

### **Z‑rend módosítása**

Az átfedő alakzatok a gyűjtemény sorrendjében kerülnek kirajzolásra. A [ShapeCollection::reorder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/reorder/) egy már létező alakzatot a kívánt indexre helyez anélkül, hogy klónozná. A `0` index a hátul, a `size() - 1` az elöl.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A téglalap először jön létre, és kezdetben az ellipsz mögött helyezkedik el. A végső indexre mozgatásával előre kerül. Z‑rendet csak minden kapcsolódó alakzat hozzáadása vagy klónozása után állítsa be, mivel ezek a műveletek új elemeket szúrnak be vagy fűznek hozzá, és megváltoztathatják a kívánt rétegsorrendet.

## **Alakzatok vizsgálata elrendezési diákon**

A normál diák, elrendezési diák és master diák külön alakzatgyűjteményekkel rendelkeznek. Egy elrendezési gyűjteménybeli alakzat nem ugyanaz az objektum, mint egy ugyanúgy elhelyezkedő alakzat egy normál dián. Vizsgálja meg az elrendezési alakzatokat, ha a layout által biztosított formázás megértésére vagy módosítására van szükség.

Az alábbi példa minden elrendezési alakzat [FillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getfillformat/) és [LineFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getlineformat/) értékét kiolvassa, anélkül, hogy feltételezné, hogy minden alakzat `AutoShape`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Egy layout szerkesztése több, azt használó diára is hatással lehet. Mielőtt módosítana egy elrendezési alakzatot, határozza meg, hogy egy normál dia örökli‑e az objektumot vagy helyi felülbírálást tartalmaz‑e, és tesztelje az összes olyan diát, amely ezt az elrendezést alkalmazza.

## **Alakzat exportálása SVG‑be**

A [Shape::writeAsSvg](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/writeassvg/) egy alakzat renderelt tartalmát írja ki egy stream‑be. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia háttérjét vagy a szomszédos alakzatokat.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Tartsa nyitva a prezentációt a renderelés közben. A kimenet az alakzat formázásától, valamint a betűkészletektől és képektől függő erőforrásoktól függ. Ha az egész kompozícióra van szükség, exportálja a diát, nem egyetlen alakzatot. A hívó birtokolja a stream‑et, és köteles azt lezárni.

## **Alakzatok igazítása**

A [SlideUtil::alignShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideutil/alignshapes/) túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjteményindexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapesalignmenttype/) meghatározza az él, középvonal vagy elosztási módot. Állítsa az `alignToSlide`‑t `true`‑ra a dia széleinek használatához; `false` esetén a kiválasztott alakzatok egymáshoz viszonyított igazítására.

Ez a példa három alakzatot a dia felső éléhez igazít. A visszakapott alakzat‑referenciákat közvetlenül az igazítás előtt az aktuális indexeikre konvertálja.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az igazítás pozíciót változtat, nem a z‑rendet. Relatív igazítás általában legalább két alakzatot igényel, míg a vízszintes vagy függőleges elosztáshoz elegendő alakzatra van szükség a távolság meghatározásához. Ha a metódus hívása előtt módosítja a gyűjteményt, számolja újra az indexeket.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, vízszintes és függőleges tükrözés beállításait, valamint a forgást. A `getFlipH` és `getFlipV` értékek [NullableBool](https://reference.aspose.com/slides/hu/php-java/aspose.slides/nullablebool/)‑ot használnak: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig a nem meghatározott/alapértelmezett állapotot őrzi meg.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![The shape before flipping](shape_to_be_flipped.png)

A példa minden más keretértéket megtart, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/setframe/) hozzárendelése a teljes keretet felülírja.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A mentett alakzat vízszintesen és függőlegesen tükröződik, miközben megtartja a pozíciót, méretet és forgást.

![The shape after flipping](flipped_shape.png)

## **GYIK**

**Használjak gyűjtemény‑indexet alakzat‑azonosítóként?**

Csak rövid életű feldolgozás esetén, amikor a gyűjtemény nem változik az index használata előtt. Előnyben részesítsen egy validált `Name` vagy `AlternativeText` konvenciót a szerkesztett sablonokhoz, vagy `OfficeInteropShapeId`‑t a dia‑szintű interop munkához.

**Az alakzat elrejtése eltávolítja‑e a z‑rendből?**

Nem. A rejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik elé?**

Az `addClone` a klónt a gyűjtemény végére fűzi, ami a z‑rend előre lépését jelenti. Használja az `insertClone`‑t a kezdeti index kiválasztásához, vagy a `reorder`‑t, miután az összes alakzat hozzá lett adva.