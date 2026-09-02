---
title: Hantera presentationsformer i PHP
linktitle: Formmanipulering
type: docs
weight: 40
url: /sv/php-java/shape-manipulations/
keywords:
- PowerPoint-form
- presentationsform
- form på bild
- hitta form
- klona form
- ta bort form
- dölj form
- ändra formordning
- hämta interop-form-ID
- formens alternativa text
- formjusteringspunkt
- förinställd formjustering
- formgeometri
- formatlayoutformat
- form som SVG
- form till SVG
- justera form
- vänd form
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du identifierar, justerar, klonar, tar bort, döljer, omordnar, exporterar, placerar och vänder presentationsformer med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides för PHP via Java representerar formerna på en bild som en ordnad [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/). Samlingen är både platsen där du hittar och ändrar former samt källan till deras staplingsordning: index `0` är den längst bak, medan det sista indexet är den längst fram.

Denna artikel följer den modellen. Den förklarar först hur man på ett pålitligt sätt identifierar en form och ändrar förinställda justeringspunkter, och visar sedan hur man klonar, tar bort, döljer och omordnar former. De sista avsnitten behandlar layoutnivåformat, SVG‑export, justering och vändinställningar. Varje exempel är fristående, så du kan använda bara de operationer ditt arbetsflöde kräver.

## **Identifiera och Hitta Former**

Samlingsindex är praktiska när du bearbetar en känd fil, men de är inte stabila identifierare. Att lägga till, ta bort eller omordna en form kan ändra dess index. Välj en identifierare utifrån hur presentationen authoras och underhålls:

- [Namn](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getname/) är användbart för utvecklarkontrollerade mallar och är lätt att inspektera i PowerPoints urvalspanel. Namn kan redigeras och är inte garanterade att vara unika, så etablera en namnkod om kod beror på dem.
- [AlternativeText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getalternativetext/) är användbart när en tillgänglighetsbeskrivning eller en författartagg redan identifierar formen. Det är synligt för användare, kan lokalanpassas eller skrivas om för tillgänglighet, och är inte garanterat att vara unikt. Återanvänd inte tyst meningsfull tillgänglighetstext som en databaskey.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getofficeinteropshapeid/) är en skrivskyddad identifierare som är unik inom en bild och motsvarar shape‑ID som används av PowerPoint‑interop. Använd den när du integrerar med PowerPoint eller när du behöver en entydig referens under en forms livstid. En klonad eller återställd form är en annan form och får sitt eget ID.

Den relaterade metoden [Shape::getUniqueId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getuniqueid/) returnerar en identifierare med presentationsomfattning, men den är avsedd för tillägg och kan omfördelas. Den bör inte betraktas som en permanent extern nyckel. Om långsiktig identitet är väsentlig, håll mappningen i applikationsdata och validera att den förväntade formen fortfarande finns.

Följande exempel söker efter namn med en exakt jämförelse och rapporterar bild‑scopad interop‑ID. När mallen inte innehåller den förväntade formen rapporterar koden det resultatet istället för att fortsätta med fel objekt.

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

När en operation är specifik för en formtyp, kontrollera runtime‑klassen innan du använder typ‑specifika medlemmar. Detta exempel uppdaterar text och alternativ text endast om det namngivna objektet är en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/).

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

## **Identifiera och Ändra Förinställda Formjusteringar**

Förinställda geometriska former kan exponera justeringspunkter som styr funktioner såsom hörnstorlek, pilproportioner eller bågvinklar. Åtkomst sker via den skrivskyddade samlingen [GeometryShape::getAdjustments](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometryshape/#getAdjustments). Själva samlingen tillhandahålls av formen, men varje [AdjustValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/adjustvalue/) innehåller ett värde som kan ändras.

Förlita dig inte bara på ett fast samlingsindex. Iterera genom justeringarna och inspektera den skrivskyddade metoden [AdjustValue::getType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/adjustvalue/#getType), vars värde av typen [ShapeAdjustmentType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapeadjustmenttype/) beskriver vad justeringen styr. Den skrivskyddade metoden [AdjustValue::getName](https://reference.aspose.com/slides/sv/php-java/aspose.slides/adjustvalue/getname/) ger ytterligare identifieringsinformation och är särskilt användbar när en förinställning innehåller mer än en justering med samma semantiska typ.

Använd den värdemetod som matchar justeringens innebörd:

| Justeringstyp | Syfte | Värde att ändra |
|---|---|---|
| `CornerSize` | Storlek på avrundade hörn | [setRawValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Tjocklek på en pilsvans | `setRawValue` |
| `ArrowheadLength` | Längd på en pilspets | `setRawValue` |
| `ArrowheadWidth` | Bredd på en pilspets | `setRawValue` |
| `StartAngle` | Startvinkel för en paj eller båge | [setAngleValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Slutvinkel för en paj eller båge | `setAngleValue` |

`getType` och `getName` returnerar skrivskyddad information. `getRawValue` och `setRawValue` arbetar med ett heltal i förinställningens inhemska geometrienheter, medan `getAngleValue` och `setAngleValue` arbetar med en vinkel i grader. Antalet, ordningen, innebörden och giltigt intervall för justeringar beror på förinställningens [GeometryShape::getShapeType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometryshape/#getShapeType). Ett värde som är giltigt för en förinställning kan vara ogiltigt eller ha en annan effekt för en annan.

När `getType` returnerar `ShapeAdjustmentType::Custom` känner API:t inte igen en standardsemantisk betydelse. Inspektera `getName`, förinställningstypen och det befintliga värdet, och lämna justeringen oförändrad om den förväntade betydelsen och intervallet inte är känt. Även för igenkända typer, kontrollera om samma typ förekommer mer än en gång innan du väljer ett värde. Artikeln [Connector](/slides/sv/php-java/connector/) visar detta scenario med böjningsjusteringar för anslutningar.

Följande kompletta exempel skapar standard‑ och modifierade versioner av tre förinställda former. Det itererar genom varje justering, rapporterar dess namn och typ, ändrar storleksrelaterade värden via `setRawValue`, ändrar vinklar via `setAngleValue` och sparar resultatet. Den vänstra kolumnen behåller standardgeometrin; den högra visar den justerade avrundade rektangeln, fyrvägs‑pilen och pajen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Lägg till rubriker för standard- och justerade formkolumner.
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

Att kontrollera den semantiska typen innan ett värde ändras gör koden explicit om sin avsikt och undviker antagandet att ett visst samlingsindex har samma betydelse för olika förinställda former.

## **Ändra Formsamlingen**

Tillaggs‑, klon‑, borttagnings‑ och omordningsmetoderna verkar på samlingen omedelbart. Om en operation förändrar antalet eller ordningen av former, fortsätt inte att förlita dig på index som fångats före den operationen.

### **Klona en Form**

[ShapeCollection::addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addclone/) skapar en oberoende kopia och lägger till den i slutet av mål‑samlingen. [ShapeCollection::insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/insertclone/) skapar också en kopia men placerar den på ett angivet z‑order‑index. Överlagringarna som accepterar koordinater flyttar klonen utan att ändra dess storlek; överlagringarna med bredd och höjd kan även ändra storleken.

Exemplet skapar en målbilder, klonar en märkt rektangel till fronten och infogar en andra klon längst bak. Ändringar i någon av klonerna ändrar inte källformen.

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

Kloning kopierar formens innehåll och formatering, inklusive namn och alternativ text. Tilldela nya logiska identifierare till klonen när dessa värden måste vara unika. Resurser som används av komplexa former hanteras av presentationen, men en klon förblir ett nytt samlingsobjekt med en ny formidentitet.

### **Ta Bort Former**

[ShapeCollection::remove](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/remove/) tar bort ett specifikt formobjekt från dess samling. När du tar bort flera matchningar under indexerad iteration, gå bakifrån så att varje återstående index förblir giltigt.

Detta exempel tar bort varje form med ett angivet namn. Det läser formen på det aktuella indexet, inte ett fast samlingsobjekt, och kastar inte formen i onödan.

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

Efter borttagning förändras antalet former och indexen för senare former. Referenser till opåverkade former förblir mer pålitliga än sparade index. Tänk också på anslutningar, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan ändra mer än bara bildens utseende.

### **Dölja en Form**

Att sätta [Shape::setHidden](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/sethidden/) till `true` behåller formen i samlingen men hindrar den från att visas i normal bildspelsvisning. Dess index, formatering och innehåll förblir tillgängliga för kod, så dölja är lämpligt för valfria element som kan återställas senare.

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

Döljning är inte radering eller säkerhet. Objektet kan fortfarande upptäckas och göras synligt igen av en användare eller av kod, och det förblir en del av presentationsfilen.

### **Ändra Z‑Order**

Överlappande former ritas i samlingsordning. [ShapeCollection::reorder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/reorder/) flyttar en befintlig form till ett mål‑index utan att klona den. Index `0` är bakgrunden; `size() - 1` är framfronten.

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

Rektangeln skapas först och sitter initialt bakom ellipsen. Att flytta den till sista indexet placerar den framför. Slutför z‑order efter att alla relaterade former har lagts till eller klonats, eftersom dessa operationer lägger till eller inför nya samlingsobjekt och kan ändra den avsedda stapeln.

## **Inspektera Former på Layout‑bilder**

Normala bilder, layout‑bilder och master‑bilder har separata form‑samlingar. En form i en layout‑samling är inte samma objekt som en liknande placerad form på en normal bild. Inspektera layoutformer när du behöver förstå eller ändra formatering som levereras av en layout.

Följande exempel läser varje layoutforms [FillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getfillformat/) och [LineFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getlineformat/) utan att anta att varje form är en `AutoShape`.

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

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layout‑form, avgör om en normal bild ärver objektet eller har en lokal överskrivning, och testa varje bild som använder den layouten.

## **Exportera en Form till SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/writeassvg/) skriver en enskild forms renderade innehåll till en ström. Resultatet innehåller bara formen, inte hela bildbakgrunden eller närliggande former.

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

Håll presentationen öppen under rendering. Utdata beror på formens formatering samt resurser som teckensnitt och bilder. Om du behöver hela kompositionen, exportera bilden istället för en enskild form. Anroparen äger strömmen och måste stänga den.

## **Justera Former**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideutil/alignshapes/) har överlagringar som antingen justerar alla former eller utvalda samlingsindex. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapesalignmenttype/) specificerar kanten, mittlinjen eller distributionsläget. Sätt `alignToSlide` till `true` för att använda bildens kanter; sätt den till `false` för att justera de valda formerna relativt varandra.

Detta exempel justerar tre former till bildens överkant. De returnerade formreferenserna konverteras till deras aktuella index omedelbart före justering.

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

Justering ändrar positioner, inte z‑order. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning kräver tillräckligt många former för att definiera avståndet. Räkna om index om du ändrar samlingen innan du anropar metoden.

## **Vända en Form**

Klassen [ShapeFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapeframe/) lagrar position, storlek, horisontella och vertikala vändinställningar samt rotation. Dess `getFlipH`‑ och `getFlipV`‑värden använder [NullableBool](https://reference.aspose.com/slides/sv/php-java/aspose.slides/nullablebool/): `True` aktiverar vändning, `False` inaktiverar den, och `NotDefined` behåller det odefinierade/standardtillståndet.

Den inmatade presentationen nedan innehåller en icke‑vänd form.

![Formen före vändning](shape_to_be_flipped.png)

Exemplet behåller alla andra ramvärden och ersätter endast de två vändinställningarna. Detta är viktigt eftersom en ny [Frame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/setframe/) ersätter hela ramen.

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

Den sparade formen är speglad horisontellt och vertikalt samtidigt som position, storlek och rotation behålls.

![Formen efter vändning](flipped_shape.png)

## **FAQ**

**Bör jag använda ett samlingsindex som formidentifierare?**

Endast för kortlivad bearbetning när samlingen inte kommer att ändras innan indexet används. Föredra en validerad `Name`‑ eller `AlternativeText`‑konvention för authorade mallar, eller `OfficeInteropShapeId` för interop‑arbete med bild‑scope.

**Tar dölja en form bort den från z‑order?**

Nej. En dold form förblir i samlingen på samma index. Den kan hittas, omordnas, redigeras eller göras synlig igen.

**Varför hamnade en klonad form framför en annan form?**

`addClone` lägger till klonen i slutet av samlingen, vilket är fronten i z‑order. Använd `insertClone` för att välja startindex eller `reorder` efter att alla former har lagts till.

**Kan jag använda ett fast index för att identifiera en förinställd formjustering?**

Endast efter att ha validerat exakt förinställning och samlingslayout. Föredra att iterera genom `GeometryShape::getAdjustments` och kontrollera `AdjustValue::getType`; använd `AdjustValue::getName` som ytterligare information när samma semantiska typ förekommer mer än en gång.