---
title: PowerPoint‑vormen opmaken in PHP
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/php-java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets‑effect
- schets vormlijn
- aansluitstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart‑wit weergave van vorm
- grijswaarden weergave van vorm
- vorm roteren
- 3D‑bisel‑effect
- 3D‑rotatie‑effect
- opmaak resetten
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u PowerPoint‑vormen kunt opmaken in PHP met Aspose.Slides—stel vullings‑, lijn‑ en effectstijlen in voor PPT‑ en PPTX‑bestanden met precisie en volledige controle."
---
## **Introductie**

Formateer vormen in PowerPoint door hun contouren, vullingen en effecten aan te passen. Aspose.Slides for PHP via Java stelt u in staat deze instellingen programmeermatig te beheren, inclusief transparantie, rotatie en 3D‑formattering.

![Vormopmaakopties in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java biedt klassen en methoden die u in staat stellen vormen op te maken met dezelfde opties die beschikbaar zijn in PowerPoint.

## **Lijnen opmaken**

Gebruik [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) om de contour van een vorm te controleren. Dit voorbeeld maakt een niet‑ingevuld rechthoek met een blauwe, gestreepte contour. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) selecteert een dikke‑dunne samengestelde lijn, terwijl [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) de breedte op 7 punten zet en [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) het stippatroon selecteert.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

### **Aangepaste lijnstippatronen instellen**

Gebruik [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) wanneer vooraf gedefinieerde lijnstijlen niet de gewenste stipp‑lengte en tussenruimtes bieden, bijvoorbeeld voor merkmaden of technische diagrammen. Het toewijzen van een patroon wijzigt automatisch de lijnstippstijl naar [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

Array‑items wisselen af tussen stipp‑ en tussenruimtelengtes, beginnend met een stipp. Elke waarde is een veelvoud van de lijndikte: `[4, 2]` bij een breedte van 3 punten produceert een 12‑punt stipp gevolgd door een 6‑punt gat. Gebruik paren van eindige, niet‑negatieve waarden om volledige stipp‑en‑gatsegmenten te definiëren. Het voorbeeld gebruikt positieve waarden om elke stipp en elk gat zichtbaar te houden.

Dit voorbeeld maakt vijf blauwe lijnen met dezelfde lengte en platte uiteinden. De eerste drie vergelijken patronen bij een breedte van 3 punten. De vierde herhaalt het eerste patroon met dubbel de breedte, waardoor zowel de stipp‑ als de gatlengtes verdubbelen. De vijfde schakelt van een aangepast patroon naar een doorgetrokken lijn.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // Zet de laatste lijn terug naar een doorgetrokken stijl.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Om in plaats daarvan terug te keren naar een vooraf gedefinieerde gestreepte stijl, geef [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) door aan [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). De geselecteerde stijl bepaalt het uiterlijk van de lijn.

Het resultaat in PowerPoint, van boven naar beneden: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; en **Solid, 3 pt**.

![Drie aangepaste stippatronen, een bredere lijn die het eerste patroon gebruikt, en een doorgetrokken lijn in PowerPoint](custom-dash-patterns.png)

### **Lijneindpunten instellen**

Gebruik [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) om de uiteinden van een open lijn in te stellen. De [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) klasse biedt drie expliciete eindstijlen:

- `Flat`: De lijn stopt bij het eindpunt.
- `Round`: Een halve cirkelvormige eindpunt strekt zich half de lijndikte buiten het eindpunt uit.
- `Square`: Een vierkant eindpunt strekt zich half de lijndikte buiten het eindpunt uit.

De klasse bevat ook `NotDefined`, wat betekent dat er geen eindstijl expliciet is toegewezen.

Eindstijlen verschillen van pijlpunten, die symbolen aan lijnuiteinden toevoegen, en van verbindingen, die hoeken tussen lijnsegmenten regelen. Dit voorbeeld schakelt pijlpunten uit via [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) en [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) zodat alleen de cap‑vormen worden vergeleken.

Het volgende voorbeeld maakt drie verder identieke horizontale lijnen, 20 punten breed. Van boven naar beneden gebruiken ze platte, ronde en vierkante eindpunten. Hun eindpunten hebben dezelfde horizontale coördinaten; de ronde en vierkante eindpunten strekken zich 10 punten buiten elk eindpunt uit.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat in PowerPoint, van boven naar beneden: **Flat**, **Round**, en **Square**.

![Platte, ronde en vierkante eindpunten op identieke dikke lijnen in PowerPoint](line-caps.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect maakt een vormlijn handgetekend. Gebruik [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) om de lijninstellingen te benaderen, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) om de schetsinstellingen te benaderen, en [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) om een waarde uit de [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) klasse te selecteren.

De volgende PHP‑code toont hoe een [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) effect toe te passen, de expliciet toegewezen waarde uit te lezen, en het effect te verwijderen met [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

De waarde die wordt geretourneerd door [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) vertegenwoordigt de instelling die direct aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, master‑dia of lay‑dia, gebruik dan [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective), benader de geretourneerde object‑methode `getSketchFormat`, en lees de `getSketchType`‑waarde. De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat de overerving is opgelost. Dit voorbeeld vereist een bestaande presentatie met minimaal één vorm op de eerste dia en geeft beide waarden weer:

```php
use aspose\slides\Presentation;

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

## **Aansluit‑stijlen formatteren**

Hier zijn de drie opties voor aansluittype:

* Round
* Miter
* Bevel

De aansluitstijl bepaalt hoe twee contoursegmenten bij een hoek samenkomen. Gebruik **Round** voor afgeronde hoeken, **Miter** voor scherpe hoeken, of **Bevel** voor afgevlakte hoeken.

![De aansluitstijl in de presentatie](join-style-powerpoint.png)

Dit voorbeeld maakt drie zwarte rechthoeken met blauwe contouren van 15 punten breed. Het zet [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) naar respectievelijk de miter‑, bevel‑ en round‑waarden van [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) om te vergelijken hoe de hoeken worden getekend.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Miter‑verbindingen beperken bij scherpe hoeken**

Gebruik [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) met [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) ingesteld op [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) om te beperken hoe ver een scherpe hoek mag uitsteken.

De limiet is een verhouding van de afstand tussen de binnen‑ en buitenhoeken van de verbinding ten opzichte van de lijndikte. Een waarde van `8` staat een miter‑lengte toe tot acht keer de lijndikte; het is geen maat in punten. Als de hoek de limiet zou overschrijden, gebruikt PowerPoint een afgevlakte verbinding op die hoek. Een grotere limiet maakt scherpere punten mogelijk. De instelling beïnvloedt alleen miter‑verbindingen en heeft geen zichtbaar effect wanneer de hoek binnen beide limieten blijft.

Dit voorbeeld maakt twee identieke, niet‑ingevulde driehoeken met contouren van 20 punten breed. De linker driehoek gebruikt een limiet van `2`, de rechter een limiet van `8`. Elke driehoek is 80 punten breed en 160 punten hoog, waardoor de bovenhoek een miter‑lengte‑tot‑lijndikte‑verhouding van ongeveer `4.12` heeft. Daardoor vlakt PowerPoint de linker top af en behoudt de rechter top.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat in PowerPoint: **Miter limit 2** links en **miter limit 8** rechts.

![Een afgevlakte top met miter‑limiet 2 en een puntige top met miter‑limiet 8 in PowerPoint](miter-limits.png)

## **Verloop‑vulling**

Een verloop‑vulling mengt kleuren over een vorm. Dit voorbeeld vult een ellips met een lineair verloop onder een hoek van 45 graden van rood naar paars met behulp van [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). De [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) methode plaatst de kleurenstops op 0 en 1, het begin en einde van het verloop. Het wissen van de bestaande stops zorgt ervoor dat alleen deze twee kleuren worden gebruikt.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De ellips met verloopvulling](gradient-fill.png)

Als een verloop er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, zie [Choose a Gradient Rendering Style](/slides/nl/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). U kunt een weergavestijl selecteren zonder de verloopvulling in de presentatie te wijzigen.

### **Hoek van lineair verloop instellen**

Gebruik [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) om de oriëntatie van een [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) vulling te regelen. De hoek wordt gemeten in graden en neemt met de klok mee toe: `0` loopt van links naar rechts, `90` van boven naar beneden, `180` van rechts naar links, en `270` van onder naar boven. Gedeeltelijke hoeken worden ondersteund. Hoeken buiten `[0, 360)` worden genormaliseerd naar één omwenteling; bijvoorbeeld `-45` wordt `315` en `360` wordt `0`.

Dit voorbeeld maakt zes rechthoeken met identieke rode, groene en blauwe stops op posities `0`, `0.5` en `1`. Schalen is uitgeschakeld zodat de hoek onafhankelijk van de verhoudingen van de rechthoeken vergeleken kan worden. De hoeken, van links naar rechts, zijn `0`, `45` en `90` in de eerste rij, en `135`, `180` en `270` in de tweede rij.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat in PowerPoint:

![Lineaire verlopen op 0, 45 en 90 graden in de bovenste rij, en 135, 180 en 270 graden in de onderste rij](linear-gradient-angles.png)

### **Lineair verloop schalen met de vorm**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) accepteert een [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) waarde. Zet deze expliciet op `False` om de geometrische verloop‑hoek te behouden wanneer de verhoudingen van de vorm veranderen, of op `True` om het verloop te schalen met de breedte en hoogte van de vorm. Met schalen ingeschakeld kan de zichtbare hoek afwijken van de toegewezen hoek bij een niet‑vierkante vorm.

Het volgende voorbeeld gebruikt een hoek van `45` graden en dezelfde kleurenstops als de hoeksvergelijking. De linkerkolom gebruikt `False`; de rechterkolom gebruikt `True`. Elke kolom bevat een brede rechthoek boven een hoge rechthoek. Beide beginnen met dezelfde brede afmetingen; het aanpassen van de breedte en hoogte van de tweede rechthoek toont hoe de vulling reageert op grootteverandering zonder de verloopinstellingen te wijzigen.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat in PowerPoint, met schalen uitgeschakeld links en ingeschakeld rechts:

![Brede en hoge rechthoeken met een 45‑graden verloop, vergelijking LinearGradientScaled False links met True rechts](linear-gradient-scaling.png)

Met schalen uitgeschakeld behouden de diagonale kleurbanden dezelfde oriëntatie in beide rechthoeken. Met schalen ingeschakeld strekken de banden zich uit met de verhoudingen van de vorm. Dit helpt een sjabloon‑verloop te reproduceren bij het aanpassen van een vorm naar een andere grootte. Op een vierkant verandert het inschakelen van schalen de 45‑graden verloop‑uitstraling niet.

Zowel de hoek‑ als de schaala​instellingen gelden voor lineaire verlopen. Ze regelen geen [GradientShape::Radial of GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) vullingen.

### **Hoek combineren met verlooprichting**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) selecteert een verloopstijl uit de [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/) klasse; het is geen vervanging voor een numerieke hoek. Voor een lineair verloop kunnen de hoekstijlen het gebied wijzigen waarover de kleuren worden verdeeld zonder de hoek die via [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) is toegewezen, te veranderen. Houd de richting ongewijzigd bij het vergelijken van hoeken of schalen.

Het volgende voorbeeld past dezelfde instellingen toe in omgekeerde volgorde. De twee rechthoeken zien er identiek uit: de richting vóór of na de hoek toewijzen verandert het resultaat niet.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Patroonvulling**

Een patroonvulling brengt een tweekleurig ontwerp aan, zoals stippen, strepen of geruite patronen. Dit voorbeeld gebruikt [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) om een rasterpatroon te selecteren. [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) levert de lichtgrijze achtergrond, en [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) levert de gele patroonkleur.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

Een afbeeldingvulling gebruikt een afbeelding binnen een vorm. Dit voorbeeld vereist een lokale afbeelding en gebruikt [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) om deze in de afbeeldingscollectie van de presentatie te laden. Het instellen van [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) op de tegelmodus herhaalt de afbeelding binnen de rechthoek. De gebruikte bronafbeelding staat hieronder:

![De lotusafbeelding](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De vorm met afbeeldingvulling](picture-fill.png)

### **Afbeelding tegel als textuur**

Als u een getegelde afbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kunt u de volgende methoden van de [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Stelt de beeldvullingsmodus in — of `Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Specificeert de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Bepaalt of de tegel horizontaal, verticaal of beide keren wordt gedraaid.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Stelt de horizontale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Stelt de verticale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definieert de horizontale schaal van de tegel als percentage.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definieert de verticale schaal van de tegel als percentage.

Dit voorbeeld vereist een lokale afbeelding en configureert [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) om deze te herhalen op 50 % van de originele grootte. Offsets van −32 punten verplaatsen de tegels horizontaal en verticaal; uitlijning rechtsonder en draaien in beide richtingen bepalen hoe de herhaalde textuur wordt gerangschikt.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

Een effen vulling geeft een vorm één enkele, uniforme kleur. Dit voorbeeld zet [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) op de effen vullingsmodus en kent geel toe via [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), waarna de rechthoek in een presentatie wordt opgeslagen.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Achtergrond van de dia gebruiken als vormvulling**

Gebruik [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) wanneer een vorm moet overeenkomen met de dia‑achtergrond, bijvoorbeeld in een sjabloon. Stel eerst [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) in op [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) om eventuele expliciete vulling te verwijderen. Met deze combinatie gebruikt de vorm de dia‑achtergrond in plaats van zijn stijl‑vulling. Het alleen inschakelen van de vlag verwijdert geen bestaande expliciete vulling.

Dit verschilt van [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/): een achtergrondvulling dekt objecten achter de vorm met het overeenkomstige gebied van de dia‑achtergrond, terwijl geen vulling die objecten zichtbaar laat. Een verloop blijft uitgelijnd met de dia in plaats van binnen elke vorm opnieuw te beginnen.

Het volgende voorbeeld maakt een master‑achtergrond die door de dia wordt geërfd en plaatst een magenta band achter drie rechthoeken. De linkse rechthoek gebruikt de achtergrond, de middelste rechthoek heeft geen vulling, en de rechtrechthoek schakelt van achtergrond‑vulling naar een expliciete oranje vulling.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // Erf de gradient van de master.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // Voeg dit object eerst toe zodat het achter de rechthoeken verschijnt.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // Schakel achtergrondvulling uit voordat een expliciete vulling wordt toegepast.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat, van links naar rechts: **background fill**, **no fill**, en **explicit fill**. De magenta band wordt verborgen door de linker‑ en rechterrechthoeken maar blijft zichtbaar via de middelste rechthoek.

![Achtergrondvulling, geen vulling en expliciete oranje vulling over een magenta band](background-fill.png)

Hetzelfde gedrag geldt voor een achtergrond die direct op de dia wordt gedefinieerd of van een lay‑dia wordt geërfd. De vorm gebruikt de uiteindelijk bepaalde dia‑achtergrond; het voorbeeld laat zowel de dia‑ als de lay‑achtergronden ongedefinieerd zodat de master deze levert.

## **Transparantie instellen**

Voor een effen vulling controleert de alfa‑component van de kleur de dekking: 0 is volledig transparant en 255 volledig ondoorzichtig. Dit voorbeeld gebruikt een alfa‑waarde van 128 voor een gele rechthoek, waardoor deze ongeveer 50 % transparant is zodat de onderliggende rechthoek zichtbaar blijft. De kleur wordt toegewezen via [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Gebruik [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) om een vorm in het dia‑vlak te roteren. De hoek wordt gemeten in graden; dit voorbeeld draait een rechthoek 5 graden met de klok mee en slaat de presentatie op.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D‑bisel‑effecten toevoegen**

Gebruik [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) om een vorm diepte en gefaseerde randen te geven. Dit voorbeeld creëert een groene ellips met een oranje contour, zet [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) op 4 punten, en past een cirkelvormig boven‑bisel toe met een breedte en hoogte van 6 punten via [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). Een front‑facing orthografische camera en drie‑punt verlichting maken het bisel zichtbaar.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![Het 3D‑bisel‑effect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Een vorm‑3D‑weergave wordt bestuurd door de camera‑instellingen. Dit voorbeeld gebruikt [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) met breedte‑graad, lengte‑graad en revolutie‑hoeken van respectievelijk 40, 35 en 20 graden. Het selecteert een isometrische camera via [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) en een evenwichtige verlichting via [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), waarna de opgemaakte rechthoek wordt opgeslagen.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart-wit weergave voor vormen beheren**

De methode [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) bepaalt hoe een individuele vorm wordt weergegeven wanneer een presentatie wordt bekeken of verwerkt in zwart‑wit‑modus. Het schakelt niet zelf zwart‑wit‑weergave in en wijzigt de vulling, lijn of andere opmaak van de vorm niet in de normale kleuren‑modus.

Gebruik een waarde uit de [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) klasse om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de weergave‑applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijze kleuring, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` dwingen één kleur, `Color` behoudt normale kleuring, en `Hidden` laat de vorm weg in zwart‑wit‑modus. `NotDefined` betekent dat er geen vorm‑specifieke modus is toegewezen.

Dit voorbeeld maakt een oranje rechthoek en zet [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) op grijs. De opgeslagen vorm behoudt zijn oranje vulling voor normale kleurweergave en vraagt grijze kleuring aan toepassingen die zwart‑wit‑weergave respecteren:

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
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

In de normale kleuren‑modus behoudt de rechthoek zijn oranje vulling. In een zwart‑wit‑workflow gebruikt hij grijze kleuring omdat de modus is ingesteld op `Gray`. Hiermee kunt u een volledig‑kleur dia behouden en toch een andere weergave definiëren voor afdrukken, voorbeeldweergave of andere workflows die de zwart‑wit‑weergaveinstellingen van de presentatie respecteren.

## **Opmaak resetten**

Gebruik [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) om de positie, grootte en opmaak van dia‑plaatsvervangers te herstellen vanuit de bijbehorende lay‑plaatsvervangers. Dit voorbeeld vereist een bestaande presentatie met lay‑gekoppelde plaatsvervangers en reset elke dia voordat deze wordt opgeslagen. Vormen zonder bijbehorende lay‑plaatsvervangers worden niet gereset.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Heeft vormopmaak invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Kleuren, lijnstijlen en effectinstellingen voegen over het algemeen weinig data toe vergeleken met ingesloten afbeeldingen en media. Afbeeldingsvullingen kunnen de bestandsgrootte vergroten omdat hun afbeeldingen in de presentatie worden opgeslagen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm — vulling, lijn en effectinstellingen. Als alle overeenkomstige waarden overeenkomen, beschouw dan hun stijlen als identiek en groepeer die vormen logisch, wat later stijlenbeheer vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloon‑diapresentatie of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie opent u het sjabloon, kloont u de benodigde gestileerde vormen, en past u hun opmaak toe waar nodig.