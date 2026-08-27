---
title: Prezentációs alakzatok kezelése PHP-ben
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/php-java/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szöveg
- alakzat igazítási pont
- előre definiált alakzat igazítás
- alakzat geometria
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-re
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan azonosíthat, módosíthat, klónozhat, eltávolíthat, elrejthet, átrendezhet, exportálhat, igazíthat és tükrözhet prezentációs alakzatokat az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java a dia alakjait egy rendezett [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/)ként ábrázolja. A gyűjtemény egyaránt a hely, ahol alakzatokat kereshet és módosíthat, valamint az azok rétegezési sorrendjének forrása: a `0` index a leghátsó alakzat, míg az utolsó index a legelöl lévő alakzat.

Ez a cikk ebben a modellben dolgozik. Először bemutatja, hogyan azonosítsunk megbízhatóan egy alakzatot és módosítsuk az előre beállított alakzatigazítási pontokat, majd megmutatja, hogyan klónozzunk, távolítsunk el, rejtsünk el és rendezzünk át alakzatokat. Az utolsó szakaszok a diaterv szintű formázást, SVG exportot, igazítást és tükrözési beállításokat fedik le. Minden példa önálló, így csak a munkafolyamatának megfelelő műveleteket használhatja.

## **Az alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a bemutató szerkesztési és karbantartási módja alapján:

- [Name](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getname/) hasznos fejlesztő által vezérelt sablonoknál, és könnyen megtekinthető a PowerPoint Kijelölés paneljén. A neveket módosíthatja, de nem garantált, hogy egyediek, ezért alakíts ki nevesítési konvenciót, ha a kód rájuk támaszkodik.
- [AlternativeText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getalternativetext/) akkor hasznos, ha egy hozzáférhetőségi leírás vagy szerző által megadott címke már azonosítja az alakzatot. Látható a felhasználók számára, lokalizálható vagy átírható a hozzáférhetőség érdekében, és nem garantált, hogy egyedi. Ne használja csendben a jelentős hozzáférhetőségi szöveget adatbáziskulcsként.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getofficeinteropshapeid/) egy csak olvasható azonosító, amely egy dián belül egyedi, és a PowerPoint interop által használt alakzat-azonosítónak felel meg. Használja, ha PowerPointtal integrál, vagy ha egyértelmű hivatkozásra van szükség egy alakzat teljes élettartama alatt. Egy klónozott vagy újból létrehozott alakzat másik alakzat, és saját ID-t kap.

A kapcsolódó [Shape::getUniqueId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getuniqueid/) metódus prezentációs hatókörű azonosítót ad vissza, de ez az azonosító kiegészítőknek szól, és újra hozzárendelhető. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú identitásra van szükség, tárolja a leképezést az alkalmazás adataiban, és ellenőrizze, hogy a várt alakzat továbbra is létezik‑e.

Az alábbi példa nevével pontos összehasonlítás alapján keres, és a diára vonatkozó interop ID‑t jelenti. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelzi a további helytelen objektum használata helyett.

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

Amikor egy művelet alakzat‑típusra specifikus, ellenőrizze a futási osztályt, mielőtt típus‑specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a megnevezett objektum egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/).

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

## **Az előre definiált alakzatigazítások azonosítása és módosítása**

Az előre definiált geometriai alakzatok olyan igazítási pontokat fedhetnek fel, amelyek a sarokméretet, nyíl arányokat vagy ívhözszögeket vezérlik. Ezek elérhetők a csak‑olvasható [GeometryShape::getAdjustments](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometryshape/#getAdjustments) gyűjteményen keresztül. Maga a gyűjtemény az alakzattól származik, de minden [AdjustValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/adjustvalue/) tartalmaz egy módosítható értéket.

Ne csak a fix gyűjtemény‑indexre támaszkodjon. Iteráljon a igazításokon, és vizsgálja meg a csak‑olvasható [AdjustValue::getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/adjustvalue/#getType) metódust, amelynek a [ShapeAdjustmentType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapeadjustmenttype/) értéke leírja, mit szabályoz az igazítás. A csak‑olvasható [AdjustValue::getName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/adjustvalue/getname/) metódus további azonosító információt ad, és különösen hasznos, ha egy előre definiált több azonos szemantikai típusú igazítást tartalmaz.

Használja a megfelelő érték‑metódust az igazítás jelentésének megfelelően:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | A lekerekített sarkok mérete | [setRawValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | A nyíl farok vastagsága | `setRawValue` |
| `ArrowheadLength` | A nyílcsúcs hossza | `setRawValue` |
| `ArrowheadWidth` | A nyílcsúcs szélessége | `setRawValue` |
| `StartAngle` | A kördiagram vagy ív kezdő szöge | [setAngleValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | A kördiagram vagy ív záró szöge | `setAngleValue` |

A `getType` és a `getName` csak‑olvasható információt ad. A `getRawValue` és a `setRawValue` egy egész számot használ a preset natív geometriai egységeiben, míg a `getAngleValue` és a `setAngleValue` fokban megadott szöget kezel. A szám, sorrend, jelentés és az igazítások érvényes tartománya a [GeometryShape::getShapeType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometryshape/#getShapeType) által meghatározott preset‑től függ. Egy presethez érvényes érték egy másik presetnél érvénytelen vagy más hatást eredményezhet.

Amikor a `getType` `ShapeAdjustmentType::Custom` értéket ad, az API nem ismeri fel a szabványos szemantikai jelentést. Vizsgálja meg a `getName`‑et, a preset típusát és a meglévő értéket, és csak akkor változtassa meg az igazítást, ha a várt jelentés és tartomány ismert. Még a felismert típusok esetén is ellenőrizze, hogy ugyanaz a típus többször előfordul‑e, mielőtt értéket választana. A [Connector](/slides/hu/php-java/connector/) cikk mutatja ezt a helyzetet a csatlakozó görbületi igazításoknál.

Az alábbi teljes példa alap és módosított változatokat hoz létre három preset alakzatról. Iterál minden igazításon, jelenti a nevét és típusát, a `setRawValue`‑val méret‑kapcsolt értékeket változtat, a `setAngleValue`‑val szögeket módosít, és elmenti az eredményt. A bal oszlop az alap geometriai adatokat tartja; a jobb oszlop a módosított lekerekített téglalapot, a négyszögű nyilat és a kördiagramot mutatja.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjunk fejléceket az alapértelmezett és a módosított alakzatoszlopokhoz.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A szemantikai típus ellenőrzése a változtatás előtt egyértelművé teszi a kód szándékát, és megakadályozza, hogy egy adott gyűjtemény‑indexnek különböző jelentése legyen különböző preset alakzatoknál.

## **Az alakzatgyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és átrendezés metódusai azonnal a gyűjteményen dolgoznak. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon a művelet előtt rögzített indexekre.

### **Alakzat klónozása**

[ShapeCollection::addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addclone/) egy független másolatot hoz létre, és a célgyűjtemény végére fűzi. [ShapeCollection::insertClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/insertclone/) szintén másolatot készít, de egy megadott z‑rendi indexnél helyezi el. A koordinátákat elfogadó túlterhelések a klónt áthelyezik méretváltoztatás nélkül; a szélességet és magasságot megadók átméretezhetik is.

A példa egy cél‑diát hoz létre, egy címkézett téglalapot klónoz elölre, és egy második klónt szúr be hátulra. Bármely klón módosítása nem érinti a forrás‑alakzatot.

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

A klónozás másolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szövegét is. Adjunk új logikai azonosítókat a klónnak, ha ezeknek az értékeknek egyedinek kell lenniük. A komplex alakzatok által használt erőforrásokat a bemutató kezeli, de a klón egy új gyűjtemény‑elem, új alakzat‑identitással.

### **Alakzatok eltávolítása**

[ShapeCollection::remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/remove/) egy adott alakzat‑objektumot töröl a gyűjteményéből. Több egyező elem eltávolításakor, indexelt iteráció közben, haladjon a vég felől, hogy minden maradt index érvényes maradjon.

Ez a példa minden megnevezett nevű alakzatot eltávolít. Az aktuális indexen lévő alakzatot olvassa, nem egy rögzített gyűjtemény‑elemet, és nem kényszeríti feleslegesen az alakzat típusát.

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

Eltávolítás után az alakzatszám és a későbbi alakzatok indexei megváltoznak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a mentett indexek. Figyelembe kell venni a csatlakozókat, animációkat és egyéb bemutató‑elemeket, amelyek a eltávolított objektumra hivatkozhatnak; egy látható alakzat eltávolítása több mint csak a dia kinézetét változtathatja meg.

### **Alakzat elrejtése**

A [Shape::setHidden](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/sethidden/) `true`‑ra állítása megtartja az alakzatot a gyűjteményben, de megakadályozza, hogy a normál diavetítésben megjelenjen. Indexe, formázása és tartalma továbbra is elérhető a kódban, így a rejtés alkalmas opcionális elemekre, amelyeket később vissza lehet állítani.

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

A rejtés nem törlés vagy biztonság. Az objektum továbbra is felfedezhető és feloldható felhasználó vagy kód által, és része marad a bemutató fájlnak.

### **Z‑rend módosítása**

Átfedő alakzatok a gyűjtemény sorrendjében kerülnek festésre. [ShapeCollection::reorder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/reorder/) egy már meglévő alakzatot egy cél‑indexre helyez anélkül, hogy klónozná. A `0` index a hátul, a `size() - 1` az elöl.

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

A téglalap először jön létre, és kezdetben az ellipsz mögött van. A végső indexre mozgatása előre helyezi. Z‑rendet a kapcsolódó alakzatok hozzáadása vagy klónozása után véglegesítse, mivel ezek a műveletek új gyűjtemény‑elemeket illesztenek be és módosíthatják a kívánt rétegsorrendet.

## **Az elrendezési diákon lévő alakzatok vizsgálata**

A normál diák, elrendezési diák és mester‑diák külön alakzatgyűjteménnyel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonlóan elhelyezett alakzat egy normál dián. Vizsgálja meg az elrendezési alakzatokat, ha a formázást kell megértenie vagy módosítania, amelyet egy elrendezés biztosít.

Az alábbi példa minden elrendezési alakzat [FillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getfillformat/) és [LineFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getlineformat/) tulajdonságát olvassa, anélkül, hogy azt feltételezné, hogy minden alakzat egy `AutoShape`.

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

Egy elrendezés szerkesztése több, azt használó diára hatással lehet. Mielőtt elrendezési alakzatot módosítana, határozza meg, hogy egy normál dia örökli‑e az objektumot vagy helyi felülírást tartalmaz‑e, és tesztelje az összes diát, amely ezt az elrendezést használja.

## **Alakzat exportálása SVG‑be**

[Shape::writeAsSvg](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/writeassvg/) egy alakzat renderelt tartalmát írja egy stream‑be. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia háttér vagy a szomszédos alakzatok.

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

Tartsa nyitva a bemutatót a renderelés közben. A kimenet az alakzat formázásától, valamint a betűtípusok és képek stb. erőforrásoktól függ. Ha az egész kompozícióra van szükség, exportálja a diát, ne csak egyetlen alakzatot. A hívó birtokolja a stream‑et, és köteles azt lezárni.

## **Alakzatok igazítása**

A [SlideUtil::alignShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideutil/alignshapes/) túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjtemény‑indexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapesalignmenttype/) meghatározza a szélt, középső vonalat vagy elosztási módot. Az `alignToSlide` értéke `true` esetén a dia széleihez igazít, `false` esetén a kiválasztott alakzatok egymáshoz viszonyított igazítására használja.

Ez a példa három alakzatot a dia felső széléhez igazít. A visszatérő alakzat‑referenciákat az igazítás előtt az aktuális indexeikre konvertálja.

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

Az igazítás a pozíciót, nem a z‑rendet változtatja. Relatív igazításhoz általában legalább két alakzat szükséges, míg a vízszintes vagy függőleges elosztáshoz elegendő alakzat kell, hogy meghatározza a távolságot. Ha a metódus hívása előtt módosítja a gyűjteményt, számolja újra az indexeket.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, vízszintes és függőleges tükrözési beállításokat, valamint a forgatást. A `getFlipH` és `getFlipV` értékek a [NullableBool](https://reference.aspose.com/slides/hu/php-java/aspose.slides/nullablebool/) típusúak: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig megőrzi a nem meghatározott/alapértelmezett állapotot.

Az alábbi bemutató bemenet egy nem tükrözött alakzatot tartalmaz.

![The shape before flipping](shape_to_be_flipped.png)

A példa minden egyéb keretértéket változatlanul hagy, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/setframe/) hozzárendelése a teljes keretet felülírja.

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

A mentett alakzat vízszintesen és függőlegesen tükröződik, miközben megtartja a pozícióját, méretét és forgását.

![The shape after flipping](flipped_shape.png)

## **GYIK**

**Használjak gyűjtemény‑indexet alakzat‑azonosítóként?**

Csak rövid élettartamú feldolgozásnál, amikor a gyűjtemény nem változik az index használata előtt. A szerkesztett sablonoknál részesítse előnyben a `Name` vagy `AlternativeText` konvenciót, a diára vonatkozó interop munkához pedig az `OfficeInteropShapeId`‑t.

**Eltávolítja-e a rejtett alakzat a z‑rendet?**

Nem. A rejtett alakzat a gyűjteményben marad ugyanazzal az indexszel. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az `addClone` a klónt a gyűjtemény végére fűzi, ami a z‑rend eleje. Használja az `insertClone`‑t a kezdeti index megadásához, vagy a `reorder`‑t minden alakzat hozzáadása után.

**Használhatok fix indexet egy preset alakzatigazítás azonosításához?**

Csak akkor, ha a pontos presetet és a gyűjtemény‑elrendezést előzetesen ellenőrizte. Inkább iteráljon a `GeometryShape::getAdjustments`‑en, és ellenőrizze az `AdjustValue::getType`‑ot; ha ugyanaz a szemantikai típus többször jelenik meg, használja az `AdjustValue::getName`‑t további információként.