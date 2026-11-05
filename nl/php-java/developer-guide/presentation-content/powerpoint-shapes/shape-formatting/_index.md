---
title: PowerPoint-vormen formatteren in PHP
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/php-java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets-effect
- schetsvormlijn
- verbindingstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart-wit vormweergave
- grijstinten vormweergave
- vorm roteren
- 3D-schuineffect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u PowerPoint‑vormen kunt opmaken in PHP met Aspose.Slides — stel vul-, lijn- en effectstijlen in voor PPT‑ en PPTX‑bestanden met precisie en volledige controle."
---
## **Introductie**

Formateer vormen in PowerPoint door hun randen, opvullingen en effecten aan te passen. Aspose.Slides voor PHP via Java stelt je in staat deze instellingen programmatisch te beheren, inclusief transparantie, rotatie en 3D‑formattering.

![Vormopmaakopties in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides voor PHP via Java biedt klassen en methoden die je in staat stellen vormen te formatteren met dezelfde opties die beschikbaar zijn in PowerPoint.

## **Lijnen opmaken**

Gebruik [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) om de omtrek van een vorm te beheren. Dit voorbeeld maakt een niet‑ingevulde rechthoek met een blauwe, gestippelde omtrek. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) selecteert een dikke‑dunne samengestelde lijn, terwijl [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) de breedte op 7 punten zet en [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) het streeppatroon selecteert.

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

### **Aangepaste lijnstreeppatronen instellen**

Gebruik [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) wanneer vooraf gedefinieerde lijntypen niet de gewenste streep‑ en tussenpooslengtes bieden, bijvoorbeeld voor merkende omtrekken of technische diagrammen. Het toewijzen van een patroon verandert automatisch de lijnstreepstijl naar [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

Array‑items wisselen af tussen streep‑ en tussenpooslengtes, beginnend met een streep. Elke waarde is een veelvoud van de lijndikte: `[4, 2]` bij een breedte van 3 punten levert een streep van 12 punten gevolgd door een tussenruimte van 6 punten op. Gebruik paren van eindige, niet‑negatieve waarden om volledige streep‑en‑tussen‑segmenten te definiëren. Het voorbeeld gebruikt positieve waarden zodat elke streep en tussenruimte zichtbaar blijft.

Dit voorbeeld creëert vijf blauwe lijnen met dezelfde lengte en platte uiteinden. De eerste drie vergelijken patronen bij een breedte van 3 punten. De vierde herhaalt het eerste patroon met dubbele breedte, waardoor zowel de streep‑ als de tussenpooslengtes verdubbelen. De vijfde schakelt van een aangepast patroon naar een doorlopende lijn.

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

    // Zet de laatste lijn terug naar een doorlopende stijl.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Om terug te keren naar een vooraf gedefinieerde gestippelde stijl, geef [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) door aan [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). De geselecteerde stijl bepaalt het uiterlijk van de lijn.

Het resultaat in PowerPoint, van boven naar beneden: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; en **Solid, 3 pt**.

![Drie aangepaste streeppatronen, een bredere lijn met het eerste patroon, en een doorlopende lijn in PowerPoint](custom-dash-patterns.png)

### **Lijnuiteinden instellen**

Gebruik [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) om de uiteinden van een open lijn in te stellen. De [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/)‑klasse biedt drie expliciete kapstijlen:

- `Flat`: De lijn stopt bij het eindpunt.
- `Round`: Een halve cirkelvormige kap strekt zich uit voorbij het eindpunt met een halve lijndikte.
- `Square`: Een vierkante kap strekt zich uit voorbij het eindpunt met een halve lijndikte.

De klasse bevat bovendien `NotDefined`, wat betekent dat er geen kapstijl expliciet is toegewezen.

Uiteinden verschillen van pijlpuntstijlen, die symbolen aan de lijnuiteinden toevoegen, en van verbindingen, die hoeken tussen lijnsegmenten regelen. Dit voorbeeld schakelt pijlpuntstijlen uit via [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) en [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) zodat alleen de kapvormen worden vergeleken.

Het volgende voorbeeld maakt drie verder identieke horizontale lijnen van 20 punten breed. Van boven naar beneden gebruiken ze platte, ronde en vierkante uiteinden. Hun eindpunten hebben dezelfde horizontale coördinaten; de ronde en vierkante uiteinden steken 10 punten buiten elk eindpunt.

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

![Platte, ronde en vierkante uiteinden op identieke dikke lijnen in PowerPoint](line-caps.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect laat een vormlijn handgetekend lijken. Gebruik [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) om de lijninstellingen te benaderen, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) om de schetsinstellingen te benaderen, en [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) om een waarde uit de [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/)‑klasse te selecteren.

De volgende PHP‑code laat zien hoe een [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/)‑effect wordt toegepast, de expliciet toegewezen waarde wordt gelezen, en het effect wordt verwijderd met [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

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

De waarde die wordt geretourneerd door [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, masterdia of lay-outdia, gebruik dan [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective), benader de `getSketchFormat`‑methode van het geretourneerde object en lees de `getSketchType`‑waarde. De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat erfelijkheid is opgelost. Dit voorbeeld vereist een bestaande presentatie met minstens één vorm op de eerste dia en geeft beide waarden weer:

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

## **Knoopstijlen opmaken**

Hier zijn de drie opties voor het type verbinding:

* Rond
* Scherp
* Afgeschuind

De verbindingsstijl bepaalt hoe twee omtreksegmenten bij een hoek samenkomen. Gebruik **Rond** voor afgeronde hoeken, **Scherp** voor scherpe hoeken, of **Afgeschuind** voor afgevlakte hoeken.

![De kruisingstijl in de presentatie](join-style-powerpoint.png)

Dit voorbeeld maakt drie zwarte rechthoeken met blauwe omtrekken van 15 punten breed. Het stelt [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) in op respectievelijk de scherp‑, afgeschuind‑ en ronde waarden van [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) om te vergelijken hoe de hoeken getekend worden.

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

### **Beperk Miter‑verbindingen bij scherpe hoeken**

Gebruik [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) met [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) ingesteld op [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) om te beperken hoe ver een scherpe hoek mag uitsteken.

De limiet is een verhouding tussen de afstand van de binnen‑ en buitenhoek van de verbinding en de lijndikte. Een waarde van `8` staat een schuine lengte toe tot acht keer de lijndikte; het is geen meting in punten. Als de hoek de limiet zou overschrijden, gebruikt PowerPoint een afgevlakte verbinding op die hoek. Een grotere limiet maakt scherpere punten mogelijk. Deze instelling beïnvloedt alleen schuine verbindingen, en wijzigen heeft geen zichtbaar effect wanneer de hoek binnen beide limieten blijft.

Dit voorbeeld maakt twee identieke, niet‑ingevulde driehoeken met omtrekken van 20 punten breed. De linkse driehoek gebruikt een limiet van `2`, de rechtse `8`. Elke driehoek is 80 punten breed en 160 punten hoog, waardoor de bovenste hoek een verhouding heeft van ongeveer `4,12`. Daardoor vlakt PowerPoint de linkse top af en behoudt de rechtse top.

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

## **Verloopvulling**

Een verloopvulling mengt kleuren over een vorm. Dit voorbeeld vult een ellips met een lineair verloop onder een hoek van 45 graden van rood naar paars met behulp van [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). De methode [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) plaatst de kleurstops op 0 en 1, het begin en einde van het verloop. Het wissen van de bestaande stops zorgt ervoor dat alleen deze twee kleuren worden gebruikt.

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

Als een verloop er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, zie dan [Choose a Gradient Rendering Style](/slides/nl/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Je kunt een renderingsstijl selecteren zonder de verloopvulling in de presentatie te wijzigen.

### **De lineaire verloophoek instellen**

Gebruik [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) om de oriëntatie van een [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/)‑vulling te regelen. De hoek wordt gemeten in graden en neemt met de klok mee toe: `0` loopt van links naar rechts, `90` van boven naar beneden, `180` van rechts naar links, en `270` van onder naar boven. Gedeeltelijke hoeken worden ondersteund. Eindige hoeken buiten `[0, 360)` worden genormaliseerd tot één omwenteling; bijvoorbeeld, `-45` wordt `315` en `360` wordt `0`.

Dit voorbeeld maakt zes rechthoeken met identieke rode, groene en blauwe stops op posities `0`, `0.5` en `1`. Schalen is uitgeschakeld zodat de hoek onafhankelijk van de verhoudingen van de rechthoeken kan worden vergeleken. De hoeken, van links naar rechts, zijn `0`, `45` en `90` in de eerste rij, en `135`, `180` en `270` in de tweede rij.

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

### **Een lineair verloop schalen met de vorm**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) accepteert een [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) waarde. Stel deze expliciet in op `False` om de geometrische verloophoek te behouden wanneer de proporties van de vorm veranderen, of op `True` om het verloop te schalen met de breedte en hoogte van de vorm. Met schalen ingeschakeld kan de zichtbare hoek afwijken van de toegewezen hoek bij een niet‑vierkante vorm.

Het volgende voorbeeld gebruikt een hoek van `45` graden en dezelfde kleurstops als de hoeksvergelijking. De linkerkolom gebruikt `False`; de rechterkolom gebruikt `True`. Elke kolom bevat een brede rechthoek boven een hoge rechthoek. Beide beginnen met dezelfde brede afmetingen; het wijzigen van de breedte en hoogte van de tweede rechthoek toont hoe de vulling reageert op het wijzigen van de grootte zonder de verloopinstellingen te veranderen.

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

![Brede en hoge rechthoeken met een 45‑graden verloop, waarbij LinearGradientScaled False links en True rechts wordt vergeleken](linear-gradient-scaling.png)

Met schalen uitgeschakeld blijven de diagonale kleurbanden in beide rechthoeken in dezelfde oriëntatie. Met schalen ingeschakeld rekken de banden zich uit volgens de proporties van de vorm. Dit helpt een sjabloon‑verloop te reproduceren wanneer een vorm naar een andere grootte wordt aangepast. Op een vierkant verandert het uiterlijk van dit `45`‑graden verloop niet wanneer schalen wordt ingeschakeld.

Zowel de hoek‑ als de schaalinstellingen gelden voor lineaire verlopen. Ze regelen geen [GradientShape::Radial of GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/)‑vullingen.

### **De hoek combineren met verlooprichting**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) selecteert een verloopstijl uit de [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/)‑klasse; het is geen vervanging voor een numerieke hoek. Voor een lineair verloop kunnen de hoekstijlen het gebied wijzigen waarover de kleuren worden verdeeld zonder de via [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) toegewezen hoek te wijzigen. Houd de richting ongewijzigd bij het vergelijken van hoeken of schalen.

Het volgende voorbeeld past dezelfde instellingen toe in omgekeerde volgorde. De twee rechthoeken hebben hetzelfde uiterlijk: de richting eerst of na de hoek toewijzen verandert het resultaat niet.

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

Een patroonvulling past een tweekleurig ontwerp toe, zoals stippen, strepen of ruiten. Dit voorbeeld gebruikt [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) om een rasterpatroon te selecteren. [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) levert de lichtgrijze achtergrond, en [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) levert de gele patroonkleur.

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

Een afbeeldingsvulling gebruikt een afbeelding binnen een vorm. Dit voorbeeld vereist een lokale afbeelding en gebruikt [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) om deze te laden in de afbeeldingsverzameling van de presentatie. Het instellen van [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) op de tegelmodus herhaalt de afbeelding binnen de rechthoek. De gebruikte bronafbeelding staat hieronder weergegeven:

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

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding tegelen als textuur**

Wil je een getegelde afbeelding als textuur instellen en het tegelgedrag aanpassen, dan kun je de volgende methoden van de [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/)‑klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Stelt de afbeeldingsvullingsmodus in — of `Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Specificeert de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Beheert of de tegel horizontaal, verticaal of beide keren wordt gedraaid.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Stelt de horizontale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Stelt de verticale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definieert de horizontale schaal van de tegel als een percentage.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definieert de verticale schaal van de tegel als een percentage.

Dit voorbeeld vereist een lokale afbeelding en configureert [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) om deze op 50 % van de oorspronkelijke grootte te herhalen. Offsets van −32 punten verplaatsen de tegels horizontaal en verticaal; uitlijning rechtsonder en draaien in beide richtingen bepalen hoe de herhaalde textuur wordt gerangschikt.

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

Een effen vulling geeft een vorm een enkele, uniforme kleur. Dit voorbeeld stelt [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) in op de effen vullingsmodus en kent geel toe via [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), vervolgens wordt de rechthoek opgeslagen in een presentatie.

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

### **Kleuren kopiëren met behoud van themareferenties**

Gebruik [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) om een kleurdefinitie te kopiëren, inclusief het kleurtype, de themareferentie en transformaties. Dit is nuttig bij het overdragen van een vulkleur tussen vormen die het presentatie‑thema moeten blijven volgen. De methode kopieert alleen de kleur: ze kopieert niet het vultype, de omtrek of andere vormopmaak. Stel het vultype van de bestemming expliciet in met [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType).

Dit voorbeeld maakt drie rechthoeken, van links naar rechts: de bron, een themabewuste kopie en een vaste RGB‑kopie. De bron gebruikt [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) om te verwijzen naar de eerste accentkleur en voegt een tint toe via [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add). De RGB‑kopie gebruikt de effectieve vulkleur van de bron zodat alle drie aanvankelijk identiek lijken. Het aanroepen van [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) stelt een vaste RGB‑waarde in en wist eventuele bestaande kleuropties.

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // Thema-referenties volgen de nieuwe accentkleur; de vaste RGB-waarde niet.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Voor de thema‑wijziging komen alle drie de vullingen overeen:

![Bron, copyFrom‑doel en vaste RGB‑doel met identieke blauwe vullingen](color-copy-before.png)

Na de thema‑wijziging volgen de bron en de themabewuste kopie de nieuwe accentkleur en behouden hun tint. De vaste RGB‑kopie blijft blauw:

![Bron en copyFrom‑doel met oranje vullingen, terwijl de vaste RGB‑doel blauw blijft](color-copy-after.png)

De gekopieerde definitie is onafhankelijk van de bron. Het later wijzigen van de themareferentie van de bron, een andere kleur toewijzen, of transformaties toevoegen of verwijderen, verandert de bestemming niet. Een thema‑wijziging beïnvloedt beide vormen nog steeds omdat elke vorm onafhankelijk naar dezelfde themakleur verwijst.

Opslaan en opnieuw openen van de PPTX behoudt het gekopieerde kleurt type dat wordt geretourneerd door [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType), de themareferentie en de transformatiecollectie die wordt geretourneerd door [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform); het wordt niet omgezet naar RGB.

Bij het kopiëren tussen verschillende themacontexten, zoals presentaties met verschillende accentpaletten, wordt de gekopieerde referentie opgelost ten opzichte van het thema van de bestemming. Dezelfde referentie en transformaties kunnen daardoor een andere zichtbare kleur produceren. Zie [Presentation Theme](/slides/nl/php-java/presentation-theme/) voor meer informatie over het configureren van themakleuren.

## **Gebruik de dia‑achtergrond als vormvulling**

Gebruik [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) wanneer een vorm overeen moet komen met de dia‑achtergrond, bijvoorbeeld in een presentatiesjabloon. Stel het vultype in met [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) eerst in op [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) om eventuele expliciete vulling te verwijderen. Met deze combinatie gebruikt de vorm de dia‑achtergrond in plaats van de stijlvulling. Alleen het inschakelen van de vlag verwijdert geen bestaande expliciete vulling.

Dit verschilt van [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/): een achtergrondvulling dekt objecten achter de vorm met het overeenkomstige gebied van de dia‑achtergrond, terwijl geen vulling die objecten zichtbaar laat. Een verloop blijft uitgelijnd met de dia in plaats van opnieuw te beginnen binnen elke vorm.

Het volgende voorbeeld maakt een master‑achtergrond die door de dia wordt geërfd en plaatst een magenta‑band achter drie rechthoeken. De linkse rechthoek gebruikt de achtergrond, de middelste heeft geen vulling, en de rechtse schakelt van achtergrondvulling naar een expliciete oranje vulling.

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

    // Erf het verloop van de master.
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

Het resultaat, van links naar rechts: **background fill**, **no fill**, en **explicit fill**. De magenta‑band wordt verborgen door de linkse en rechtse rechthoeken maar blijft zichtbaar door de middelste rechthoek.

![Achtergrondvulling, geen vulling, en expliciete oranje vulling over een magenta‑band](background-fill.png)

Hetzelfde gedrag geldt voor een achtergrond die rechtstreeks op de dia is gedefinieerd of geërfd van een lay‑out. De vorm gebruikt de door de dia opgehelderde achtergrond; het voorbeeld laat zowel de dia‑ als de lay‑out‑achtergronden ongedefinieerd zodat de master deze levert.

## **Transparantie instellen**

Voor een effen vulling bepaalt de alfa‑component van de kleur de opaciteit: 0 is volledig transparant en 255 volledig ondoorzichtig. Dit voorbeeld gebruikt een alfa‑waarde van 128 voor een gele rechthoek, waardoor deze ongeveer 50 % transparant is zodat de onderliggende rechthoek zichtbaar blijft. De kleur wordt toegewezen via [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

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

Gebruik [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) om een vorm in het dia‑vlak te roteren. De hoek wordt gemeten in graden; dit voorbeeld roteert een rechthoek 5 graden met de klok mee en slaat de presentatie op.

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

![De rotatie van de vorm](shape-rotation.png)

## **3D‑schuineffecten toevoegen**

Gebruik [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) om een vorm diepte en schuine randen te geven. Dit voorbeeld maakt een groene ellips met een oranje omtrek, stelt [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) in op 4 punten, en past een ronde bovenste schuine rand toe met een breedte en hoogte van 6 punten via [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). Een front‑facing orthografische camera en drie‑punt verlichting maken de schuine rand zichtbaar.

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

![Het 3D‑schuineffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Het 3D‑beeld van een vorm wordt geregeld door de camera‑instellingen. Dit voorbeeld gebruikt [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) met breedte‑graad, lengte‑graad en revolutiegraad van respectievelijk 40, 35 en 20 graden. Het selecteert een isometrische camera via [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) en evenwichtige verlichting via [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), waarna de geformatteerde rechthoek wordt opgeslagen.

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

## **Zwart‑wit weergave voor vormen beheersen**

De [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode)‑methode specificeert hoe een individuele vorm wordt weergegeven wanneer een presentatie in zwart‑wit‑modus wordt bekeken of verwerkt. De methode activeert de zwart‑wit‑weergave niet zelf en wijzigt de vulling, lijn of andere opmaak van de vorm niet in de normale kleurenmodus.

Gebruik een waarde uit de [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/)‑klasse om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de renderingsapplicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijze kleuren, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` forceren een enkele kleur, `Color` behoudt de normale kleuring, en `Hidden` laat de vorm weg in zwart‑wit‑modus. `NotDefined` betekent dat er geen vorm‑specifieke modus is toegewezen.

Dit voorbeeld maakt een oranje rechthoek en stelt [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) in op grijs. De opgeslagen vorm behoudt zijn oranje vulling voor normale weergave en vraagt grijze kleuring aan applicaties die zwart‑wit‑instellingen respecteren:

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

In de normale kleurenmodus behoudt de rechthoek zijn oranje vulling. In een zwart‑wit‑workflow gebruikt hij grijze kleuring omdat de modus is ingesteld op `Gray`. Hiermee kun je een volledig‑kleur dia behouden terwijl je een aparte weergave definieert voor afdrukken, preview of andere workflows die de zwart‑wit‑instellingen van de presentatie respecteren.

## **Opmaak resetten**

Gebruik [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) om de positie, grootte en opmaak van dia‑plaatsaanduidingen te herstellen vanuit de bijbehorende lay‑out‑plaatsaanduidingen. Dit voorbeeld vereist een bestaande presentatie met lay‑out‑gekoppelde plaatsaanduidingen en reset elke dia vóór het opslaan. Vormen zonder overeenkomstige lay‑out‑plaatsaanduidingen worden niet gereset.

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

Kleuren, lijnstijlen en effectinstellingen voegen over het algemeen weinig data toe in vergelijking met ingesloten afbeeldingen en media. Afbeeldingsvullingen kunnen de bestandsgrootte verhogen omdat hun afbeeldingen in de presentatie worden opgeslagen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen, zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm — vul, lijn en effectinstellingen. Als alle overeenkomstige waarden gelijk zijn, behandel dan hun stijlen als identiek en groepeer de vormen logisch, wat later stijlbeheer vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand om te hergebruiken in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloon‑presentatie of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie open je de sjabloon, kloont de benodigde gestylede vormen, en pas je hun opmaak toe waar nodig.