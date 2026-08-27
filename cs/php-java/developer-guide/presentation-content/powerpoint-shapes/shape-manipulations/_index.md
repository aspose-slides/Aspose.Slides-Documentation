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
- najít tvar
- klonovat tvar
- odstranit tvar
- skrýt tvar
- změnit pořadí tvaru
- získat interop ID tvaru
- alternativní text tvaru
- bod úpravy tvaru
- přednastavená úprava tvaru
- geometrie tvaru
- formáty rozvržení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnat tvar
- převrátit tvar
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak identifikovat, upravovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a převracet tvary prezentace pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides for PHP via Java představuje tvary na snímku jako uspořádanou [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/). Kolekce je jak místem, kde najdete a upravujete tvary, tak i zdrojem jejich pořadí vrstvení: index `0` je nejzadnější tvar, zatímco poslední index je nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar a upravit přednastavené body úpravy tvaru, poté ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Závěrečné sekce se zabývají formátováním na úrovni rozvržení, exportem do SVG, zarovnáním a nastavením převrácení. Každý příklad je nezávislý, takže můžete použít jen operace, které váš pracovní postup vyžaduje.

## **Identifikace a vyhledání tvarů**

Indexy kolekce jsou praktické při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Zvolte identifikátor podle toho, jak je prezentace vytvářena a udržována:

- **[Name]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getname/) je užitečné pro šablony ovládané vývojářem a snadno se kontroluje v panelu výběru PowerPointu. Jména lze editovat a není zaručeno, že jsou jedinečná, takže zavést konvenci pojmenování, pokud kód na nich závisí.
- **[AlternativeText]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getalternativetext/) je užitečné, když již popis přístupnosti nebo autorovo označení identifikuje tvar. Je viditelné uživatelům, může být lokalizováno nebo přeformulováno pro přístupnost a není zaručeno, že je jedinečné. Neměňte tiše smysluplný text přístupnosti na klíč databáze.
- **[OfficeInteropShapeId]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getofficeinteropshapeid/) je jen pro čtení, jedinečný v rámci snímku a odpovídá ID tvaru používanému interoperabilitou PowerPointu. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz během životnosti tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá vlastní ID.

Související metoda **[Shape::getUniqueId]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getuniqueid/) vrací identifikátor s rozsahem prezentace, ale je určena pro doplňky a může být přeřazena. Neměla by být považována za trvalý externí klíč. Pokud je dlouhodobá identita podstatná, uložte mapování v datech aplikace a ověřte, že očekávaný tvar stále existuje.

Následující příklad hledá podle názvu s přesnou shodou a hlásí interopní ID v rámci snímku. Když šablona neobsahuje očekávaný tvar, kód nahlásí tento výsledek místo pokračování se špatným objektem.

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

Když je operace specifická pro typ tvaru, zkontrolujte runtime třídu před použitím členů specifických pro typ. Tento příklad aktualizuje text a alternativní text pouze pokud je pojmenovaný objekt **[AutoShape]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).

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

## **Identifikace a úprava přednastavených úprav tvaru**

Tvary s přednastavenou geometrií mohou odhalovat body úpravy, které řídí například velikost rohu, proporce šipek nebo úhly oblouků. Přistupujte k nim přes kolekci jen pro čtení **[GeometryShape::getAdjustments]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometryshape/#getAdjustments). Samotná kolekce je poskytována tvarem, ale každý **[AdjustValue]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/adjustvalue/) obsahuje hodnotu, kterou lze změnit.

Nespoléhejte se jen na pevný index kolekce. Projděte úpravy a zkontrolujte jen pro čtení metodu **[AdjustValue::getType]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/adjustvalue/#getType), jejíž hodnota **[ShapeAdjustmentType]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapeadjustmenttype/) popisuje, co úprava řídí. Metoda jen pro čtení **[AdjustValue::getName]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/adjustvalue/getname/) poskytuje další identifikační informace a je zvláště užitečná, když přednastavení obsahuje více úprav se stejným sémantickým typem.

Použijte metodu hodnoty, která odpovídá významu úpravy:

| Typ úpravy | Účel | Hodnota ke změně |
|---|---|---|
| `CornerSize` | Velikost zaoblených rohů | [setRawValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Tloušťka šípové ocasu | `setRawValue` |
| `ArrowheadLength` | Délka šípové hlavy | `setRawValue` |
| `ArrowheadWidth` | Šířka šípové hlavy | `setRawValue` |
| `StartAngle` | Počáteční úhel koláče nebo oblouku | [setAngleValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Koncový úhel koláče nebo oblouku | `setAngleValue` |

`getType` a `getName` vrací jen pro čtení informace. `getRawValue` a `setRawValue` pracují s celým číslem v nativních jednotkách geometrie přednastavení, zatímco `getAngleValue` a `setAngleValue` pracují s úhlem ve stupních. Počet, pořadí, význam a platný rozsah úprav závisí na přednastaveném **[GeometryShape::getShapeType]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometryshape/#getShapeType). Hodnota platná pro jedno přednastavení může být neplatná nebo mít jiný efekt pro jiné.

Když `getType` vrátí **ShapeAdjustmentType::Custom**, API nerozpozná standardní sémantický význam. Prohlédněte `getName`, typ přednastavení a existující hodnotu a ponechte úpravu beze změny, pokud neznáte očekávaný význam a rozsah. I pro rozpoznané typy zkontrolujte, zda se stejný typ vyskytuje vícekrát, než vyberete hodnotu. Článek **[Connector]**(/slides/cs/php-java/connector/) ukazuje tuto situaci u úprav ohybu konektoru.

Následující kompletní příklad vytváří výchozí a upravené verze tří přednastavených tvarů. Prochází každou úpravu, hlásí její název a typ, mění hodnoty související s velikostí pomocí `setRawValue`, mění úhly pomocí `setAngleValue` a ukládá výsledek. Levý sloupec zachovává výchozí geometrii; pravý sloupec ukazuje upravený zaoblený obdélník, čtyřcestnou šipku a výseč.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte záhlaví pro sloupce s výchozí a upravenou geometrií tvaru.
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

Kontrola sémantického typu před změnou hodnoty činí kód explicitním ohledně jeho záměru a zabraňuje předpokladu, že konkrétní index kolekce má stejný význam napříč různými přednastavenými tvary.

## **Úprava kolekce tvarů**

Metody pro přidání, klonování, odstraňování a změnu pořadí působí na kolekci okamžitě. Pokud operace změní počet nebo pořadí tvarů, nepoužívejte indexy zachycené před touto operací.

### **Klonování tvaru**

**[ShapeCollection::addClone]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addclone/) vytvoří nezávislou kopii a připojí ji k cílové kolekci. **[ShapeCollection::insertClone]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/insertclone/) také vytvoří kopii, ale umístí ji na zadaný index z‑řazení. Přetížení, která přijímají souřadnice, přesunou klon bez změny velikosti; přetížení s šířkou a výškou jej mohou také změnit velikost.

Příklad vytvoří cílový snímek, klonuje označený obdélník dopředu a vloží druhý klon dozadu. Změny v kterémkoli klonu neovlivní zdrojový tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho názvu a alternativního textu. Při nutnosti jedinečnosti přiřaďte novým logickým identifikátorům klonu. Zdroje používané komplexními tvary jsou spravovány prezentací, ale klon zůstává novou položkou kolekce s novou identitou tvaru.

### **Odstranění tvarů**

**[ShapeCollection::remove]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/remove/) smaže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během indexované iterace procházejte od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným názvem. Čte tvar na aktuálním indexu, ne pevnou položku kolekce, a zbytečně neprovádí přetypování.

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

Po odstranění se počet tvarů a indexy následujících tvarů změní. Odkazy na nedotčené tvary zůstávají spolehlivější než uložené indexy. Zvažte také konektory, animace a další funkce prezentace, které mohou odkazovat na odstraněný objekt; odstranění viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrytí tvaru**

Nastavení **[Shape::setHidden]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/sethidden/) na `true` ponechá tvar v kolekci, ale zabrání jeho zobrazení v normálním režimu prezentace. Jeho index, formátování a obsah zůstávají k dispozici kódu, takže skrytí je vhodné pro volitelné prvky, které mohou být později obnoveny.

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

### **Změna Z‑řazení**

Překrývající se tvary se vykreslují v pořadí kolekce. **[ShapeCollection::reorder]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/reorder/) přesune existující tvar na cílový index bez jeho klonování. Index `0` je zadní; `size() - 1` je přední.

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

Obdélník je vytvořen první a zpočátku leží za elipsou. Přesunutí na poslední index jej postaví dopředu. Dokončete Z‑řazení po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky kolekce a mohou změnit zamýšlený zásobník.

## **Prozkoumání tvarů na rozvrhových snímcích**

Normální snímky, rozvrhové snímky a hlavní snímky mají samostatné kolekce tvarů. Tvar v kolekci rozvrhu není stejný objekt jako podobně umístěný tvar na normálním snímku. Prozkoumejte tvary rozvrhu, když potřebujete pochopit nebo změnit formátování poskytnuté rozvrhem.

Následující příklad čte pro každý tvar rozvrhu **[FillFormat]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getfillformat/) a **[LineFormat]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getlineformat/) aniž by předpokládal, že každý tvar je `AutoShape`.

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

Úprava rozvrhu může ovlivnit více snímků, které jej používají. Před změnou tvaru v rozvrhu zjistěte, zda normální snímek dědí objekt nebo obsahuje místní přepsání, a otestujte každý snímek, který tento rozvrh používá.

## **Export tvaru do SVG**

**[Shape::writeAsSvg]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/writeassvg/) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje pouze tvar, nikoli celé pozadí snímku nebo sousední tvary.

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

Udržujte prezentaci otevřenou během renderování. Výstup závisí na formátování tvaru a na zdrojích, jako jsou písma a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej zavřít.

## **Zarovnání tvarů**

Přetížení **[SlideUtil::alignShapes]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideutil/alignshapes/) zarovnává buď všechny tvary, nebo vybrané indexy kolekce. **[ShapesAlignmentType]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapesalignmenttype/) specifikuje okraj, středovou čáru nebo režim distribuce. Nastavte `alignToSlide` na `true`, chcete‑li použít okraje snímku; nastavte na `false`, chcete‑li zarovnat vybrané tvary vůči sobě navzájem.

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

Zarovnání mění pozice, nikoli Z‑řazení. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální distribuce potřebuje dostatek tvarů k určení mezery. Přepočítejte indexy, pokud před voláním metody upravujete kolekci.

## **Otočení tvaru**

Třída **[ShapeFrame]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapeframe/) ukládá pozici, velikost, nastavení horizontálního a vertikálního převrácení a rotaci. Její hodnoty `getFlipH` a `getFlipV` používají **[NullableBool]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/nullablebool/): `True` povolí převrácení, `False` jej zakáže a `NotDefined` zachová nedefinovaný/defaultní stav.

Vstupní prezentace níže obsahuje jeden netransformovaný tvar.

![Tvar před otočením](shape_to_be_flipped.png)

Příklad zachovává všechny ostatní hodnoty rámce a nahrazuje jen dvě nastavení převrácení. To je důležité, protože přiřazení nového **[Frame]**(https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/setframe/) nahrazuje celý rámec.

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

Uložený tvar je zrcadlen horizontálně i vertikálně při zachování pozice, velikosti a rotace.

![Tvar po otočení](flipped_shape.png)

## **FAQ**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce před použitím indexu nezmění. Upřednostněte ověřenou konvenci `Name` nebo `AlternativeText` pro šablony, nebo `OfficeInteropShapeId` pro práci s interopem na úrovni snímku.

**Odstraňuje skrytí tvaru jeho pozici v Z‑řazení?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, změnit pořadí, upravit nebo znovu zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`addClone` přidá klon na konec kolekce, což je přední část Z‑řazení. Použijte `insertClone` pro výběr počátečního indexu nebo `reorder` po přidání všech tvarů.

**Mohu použít pevný index pro identifikaci přednastavené úpravy tvaru?**

Pouze po ověření přesného přednastavení a rozložení kolekce. Upřednostněte iteraci přes `GeometryShape::getAdjustments` a kontrolu `AdjustValue::getType`; použijte `AdjustValue::getName` jako doplňující informaci, když se stejný sémantický typ objeví vícekrát.