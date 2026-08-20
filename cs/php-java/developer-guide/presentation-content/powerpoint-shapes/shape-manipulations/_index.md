---
title: Správa tvarů prezentace v PHP
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/php-java/shape-manipulations/
keywords:
- Tvar PowerPoint
- tvar prezentace
- tvar na snímku
- najít tvar
- klonovat tvar
- odstranit tvar
- skrýt tvar
- změnit pořadí tvaru
- získat interop ID tvaru
- alternativní text tvaru
- formáty rozvržení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnat tvar
- překlopit tvar
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak identifikovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a překlopit tvary prezentace pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides for PHP via Java představuje tvary na snímku jako uspořádanou [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/). Kolekce je zároveň místem, kde najdete a upravujete tvary, i zdrojem jejich pořadí vrstvení: index `0` je nejzadnější tvar, zatímco poslední index je nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar, pak ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Poslední sekce pokrývají formátování na úrovni rozvržení, export do SVG, zarovnání a nastavení překlápění. Každý příklad je nezávislý, takže můžete použít jen operace, které váš pracovní postup vyžaduje.

## **Identifikace a vyhledání tvarů**

Indexy kolekce jsou praktické při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Zvolte identifikátor podle toho, jak je prezentace tvořena a udržována:

- [Name](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getname/) je užitečný pro šablony řízené vývojáři a je snadno kontrolovatelný v panelu Výběr v PowerPointu. Jména lze upravovat a nejsou zaručena jako jedinečná, proto zaveďte pojmenovací konvenci, pokud na nich kód závisí.
- [AlternativeText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getalternativetext/) je užitečný, když popis přístupnosti nebo autorovský tag už tvar identifikuje. Je viditelný pro uživatele, může být lokalizován nebo přepsán pro přístupnost a není zaručen jako jedinečný. Nepřevádějte tiše smysluplný text přístupnosti na klíč v databázi.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getofficeinteropshapeid/) je jen pro čtení, jedinečný v rámci snímku a odpovídá ID tvaru používanému v PowerPoint interopu. Použijte jej při integraci s PowerPointem nebo když během životnosti tvaru potřebujete jednoznačný odkaz. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá své vlastní ID.

Související metoda [Shape::getUniqueId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getuniqueid/) vrací identifikátor v rozsahu prezentace, ale tento identifikátor je určen pro doplňky a může být přidělen znovu. Neměl by být považován za trvalý externí klíč. Pokud je dlouhodobá identita nezbytná, udržujte mapování v aplikacích a ověřujte, že očekávaný tvar stále existuje.

Následující příklad hledá podle jména s přesnou shodou a hlásí interop ID v rozsahu snímku. Když šablona neobsahuje očekávaný tvar, kód nahlásí tento výsledek místo toho, aby pokračoval se špatným objektem.

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

Když je operace specifická pro typ tvaru, zkontrolujte za běhu třídu před použitím typově specifických členů. Tento příklad aktualizuje text a alternativní text pouze pokud je pojmenovaný objekt [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).

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

## **Úprava kolekce tvarů**

Metody přidání, klonování, odebrání a změny pořadí působí na kolekci okamžitě. Pokud operace změní počet nebo pořadí tvarů, nepokračujte s použitím indexů zachycených před touto operací.

### **Klonování tvaru**

[ShapeCollection::addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addclone/) vytvoří nezávislou kopii a připojí ji k cílové kolekci. [ShapeCollection::insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/insertclone/) také vytvoří kopii, ale umístí ji na zadaný index z‑řádu. Přetížení, která přijímají souřadnice, přesunou klon bez změny jeho velikosti; přetížení s šířkou a výškou jej také mohou změnit velikost.

Příklad vytvoří cílový snímek, klonuje označený obdélník do popředí a vloží druhý klon do zadního. Změny v kterémkoli klonu neovlivňují zdrojový tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho názvu a alternativního textu. Při klonování přiřaďte nové logické identifikátory, pokud musí být tyto hodnoty jedinečné. Zdroje použitých složitých tvarů spravuje prezentace, ale klon zůstává novou položkou v kolekci s novou identitou tvaru.

### **Odstranění tvarů**

[ShapeCollection::remove](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/remove/) smaže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shodných položek během indexované iterace procházejte od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným názvem. Čte tvar na aktuálním indexu, ne pevně danou položku kolekce, a zbytečně jej nepřetypovává.

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

Po odstranění se počet tvarů a indexy pozdějších tvarů změní. Odkazy na nedotčené tvary zůstávají spolehlivější než uložené indexy. Zvažte také konektory, animace a další funkce prezentace, které mohou odkazovat na odebraný objekt; odstranění viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrytí tvaru**

Nastavení [Shape::setHidden](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/sethidden/) na `true` ponechá tvar v kolekci, ale zabrání jeho zobrazení v normálním režimu prezentace. Jeho index, formátování a obsah zůstávají kódu k dispozici, takže skrytí je vhodné pro volitelné prvky, které mohou být později obnoveny.

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

Skrytí není smazání ani zabezpečení. Objekt může být stále objeven a odskryt uživatelem nebo kódem a zůstává součástí souboru prezentace.

### **Změna Z‑řádu**

Překrývající se tvary jsou kresleny v pořadí kolekce. [ShapeCollection::reorder](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/reorder/) přesune existující tvar na cílový index bez klonování. Index `0` je zadní; `size() - 1` je přední.

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

Obdélník je vytvořen první a zpočátku leží za elipsou. Přesunutí na poslední index jej umístí dopředu. Dokončete z‑řád po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky kolekce a mohou změnit zamýšlený zásobník.

## **Prohlížení tvarů na rozvrhových snímcích**

Normální snímky, rozvrhové snímky a hlavní snímky mají samostatné kolekce tvarů. Tvar v rozvrhové kolekci není stejný objekt jako podobně umístěný tvar na normálním snímku. Prohlédněte si tvary rozvržení, když potřebujete pochopit nebo změnit formátování poskytnuté rozvržením.

Následující příklad čte [FillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getfillformat/) a [LineFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getlineformat/) každého tvaru v rozvržení, aniž by předpokládal, že každý tvar je `AutoShape`.

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

Úprava rozvržení může ovlivnit více snímků, které jej používají. Před změnou tvaru v rozvržení zjistěte, zda normální snímek dědí objekt nebo obsahuje místní přepsání, a otestujte každý snímek, který toto rozvržení používá.

## **Export tvaru do SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/writeassvg/) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje pouze tvar, ne celé pozadí snímku ani sousední tvary.

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

Udržujte prezentaci otevřenou během renderování. Výstup závisí na formátování tvaru a na zdrojích jako jsou písma a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej uzavřít.

## **Zarovnání tvarů**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideutil/alignshapes/) má přetížení, která zarovnávají buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapesalignmenttype/) určuje okraj, středovou čáru nebo režim rozdělení. Nastavte `alignToSlide` na `true` pro použití okrajů snímku; nastavte na `false` pro zarovnání vybraných tvarů vůči sobě navzájem.

Tento příklad zarovnává tři tvary k hornímu okraji snímku. Vrácené odkazy na tvary jsou před zarovnáním okamžitě převedeny na jejich aktuální indexy.

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

Zarovnání mění pozice, ne z‑řád. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální rozdělení potřebuje dostatek tvarů pro definování rozestupů. Přepočítejte indexy, pokud před voláním metody upravujete kolekci.

## **Překlopení tvaru**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapeframe/) ukládá polohu, velikost, nastavení horizontálního a vertikálního překlopení a rotaci. Její hodnoty `getFlipH` a `getFlipV` používají [NullableBool](https://reference.aspose.com/slides/cs/php-java/aspose.slides/nullablebool/): `True` zapíná překlopení, `False` ho vypíná a `NotDefined` zachovává neupřesněný/defaultní stav.

Vstupní prezentace níže obsahuje jeden neotočený tvar.

![The shape before flipping](shape_to_be_flipped.png)

Příklad zachovává všechny ostatní hodnoty rámce a nahrazuje pouze dvě nastavení překlopení. To je důležité, protože přiřazení nového [Frame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/setframe/) nahrazuje celý rámec.

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

Uložený tvar je zrcadlen horizontálně i vertikálně při zachování polohy, velikosti a rotace.

![The shape after flipping](flipped_shape.png)

## **Často kladené dotazy**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce před použitím indexu již nezmění. Upřednostněte validní konvenci `Name` nebo `AlternativeText` pro tvorbu šablon, nebo `OfficeInteropShapeId` pro práci s interopem v rozsahu snímku.

**Odstraňuje skrytí tvaru jeho pozici v z‑řádu?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, změnit pořadí, upravit nebo znovu zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`addClone` připojí klon na konec kolekce, což je přední část z‑řádu. Použijte `insertClone` pro volbu počátečního indexu nebo `reorder` po přidání všech tvarů.