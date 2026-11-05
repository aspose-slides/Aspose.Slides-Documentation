---
title: PowerPoint-vormen opmaken in JavaScript
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/nodejs-java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets-effect
- schetsvormlijn
- koppelingstijl opmaken
- verloop opvulling
- patroonopvulling
- afbeeldingsopvulling
- textuuropvulling
- egale kleuropvulling
- vormtransparantie
- zwart-wit weergave van vormen
- grijstinten weergave van vormen
- vorm roteren
- 3D-schuineffect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen kunt opmaken in JavaScript met Aspose.Slides—stel opvul-, lijn- en effectstijlen in voor PPT- en PPTX-bestanden met precisie en volledige controle."
---
## **Inleiding**

Formatteer vormen in PowerPoint door hun contouren, opvullingen en effecten aan te passen. Aspose.Slides for Node.js via Java stelt u in staat deze instellingen programmatisch te beheren, inclusief transparantie, rotatie en 3D‑opmaak.

![Vormopmaakopties in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java biedt klassen en methoden waarmee u vormen kunt opmaken met dezelfde opties die beschikbaar zijn in PowerPoint.

## **Lijnen opmaken**

Gebruik [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) om de omtrek van een vorm te regelen. Dit voorbeeld maakt een ongevulde rechthoek met een blauwe, gestippelde omtrek. [LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) selecteert een dikke-dunne samengestelde lijn, terwijl [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) de breedte instelt op 7 punten en [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) het stippelpatroon selecteert.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

### **Aangepaste lijnstippelpaden instellen**

Gebruik [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern) wanneer vooraf gedefinieerde lijnstijlen niet de gewenste stippellengtes en tussenruimtes bieden, bijvoorbeeld voor merkgerelateerde omtrekken of technische diagrammen. Het toewijzen van een patroon verandert automatisch de lijnstippelstijl naar [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/).

Array‑items wisselen af tussen stippel- en tussenruimte‑lengtes, beginnend met een stippel. Elke waarde is een veelvoud van de lijndikte: `[4, 2]` bij een breedte van 3 punten produceert een stippel van 12 punten gevolgd door een ruimte van 6 punten. Gebruik paren van eindige, niet‑negatieve waarden om volledige stippel‑en‑ruimte‑segmenten te definiëren. Het voorbeeld gebruikt positieve waarden om elke stippel en ruimte zichtbaar te houden.

Dit voorbeeld maakt vijf blauwe lijnen met dezelfde lengte en platte eindpunten. De eerste drie vergelijken patronen bij een breedte van 3 punten. De vierde herhaalt het eerste patroon met dubbele breedte, waardoor zowel de stippel‑ als tussenruimte‑lengtes verdubbelen. De vijfde schakelt van een aangepast patroon naar een ononderbroken lijn.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];

    for (let i = 0; i < patterns.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setCapStyle(java.newByte(aspose.slides.LineCapStyle.Flat));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        let pattern = java.newArray("float", patterns[i]);
        line.getLineFormat().setCustomDashPattern(pattern);
    }

    // Zet de laatste lijn terug naar een solide stijl.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om in plaats daarvan terug te keren naar een vooraf gedefinieerde gestippelde stijl, geeft u [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) door aan [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle). De geselecteerde stijl bepaalt het uiterlijk van de lijn.

Het resultaat in PowerPoint, van boven naar beneden: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; en **Solid, 3 pt**.

![Drie aangepaste stippelpatronen, een bredere lijn met het eerste patroon, en een ononderbroken lijn in PowerPoint](custom-dash-patterns.png)

### **Lijneinden instellen**

Gebruik [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) om de uiteinden van een open lijn in te stellen. De klasse [LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) biedt drie expliciete eindstijlen:

- `Flat`: De lijn stopt bij het eindpunt.
- `Round`: Een halve cirkeluitsteeksel rekt zich half de lijndikte voorbij het eindpunt uit.
- `Square`: Een vierkant uiteinde rekt zich half de lijndikte voorbij het eindpunt uit.

De klasse bevat ook `NotDefined`, wat betekent dat er geen eindstijl expliciet is toegewezen.

Eindpunten verschillen van pijlpuntjes, die symbolen aan lijnuiteinden toevoegen, en van verbindingen, die de hoeken tussen lijnsegmenten regelen. Dit voorbeeld schakelt pijlpuntjes uit via [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) en [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle) zodat alleen de eindvormen worden vergeleken.

Het volgende voorbeeld maakt drie verder identieke horizontale lijnen, 20 punten breed. Van boven naar beneden gebruiken ze platte, ronde en vierkante eindpunten. Hun uiteinden hebben dezelfde horizontale coördinaten; de ronde en vierkante eindpunten steken 10 punten voorbij elk uiteinde.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let capStyles = [aspose.slides.LineCapStyle.Flat, aspose.slides.LineCapStyle.Round, aspose.slides.LineCapStyle.Square];

    for (let i = 0; i < capStyles.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));
        line.getLineFormat().setCapStyle(java.newByte(capStyles[i]));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
    }

    presentation.save("line_caps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat in PowerPoint, van boven naar beneden: **Flat**, **Round** en **Square**.

![Platte, ronde en vierkante eindpunten op identieke dikke lijnen in PowerPoint](line-caps.png)

## **Schets-effecten toepassen op vormlijnen**

Een schets‑effect geeft een vormlijn een handgetekend uiterlijk. Gebruik [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) om de lijninstellingen te openen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) om de schetseigenschappen te openen, en [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) om een waarde uit de klasse [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) te selecteren.

De volgende JavaScript‑code toont hoe een [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/)‑effect toe te passen, de expliciet toegewezen waarde te lezen, en het effect te verwijderen met [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    let sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

De waarde die wordt geretourneerd door [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) vertegenwoordigt de instelling die direct aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, meester‑dia of lay‑dia, gebruik dan [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective), roep `getSketchFormat` aan op het geretourneerde object en roep vervolgens zijn `getSketchType`‑methode aan. De effectieve waarde geeft de opmaak weer die daadwerkelijk wordt toegepast nadat erfelijkheid is opgelost. Dit voorbeeld vereist een bestaande presentatie met minstens één vorm op de eerste dia en toont beide waarden:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    let lineFormat = shape.getLineFormat();
    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Koppelingsstijlen opmaken**

Hier zijn de drie opties voor koppelingssoorten:

* Round
* Miter
* Bevel

De koppelingsstijl bepaalt hoe twee omtreksegmenten elkaar ontmoeten op een hoek. Gebruik **Round** voor afgeronde hoeken, **Miter** voor scherpe hoeken, of **Bevel** voor afgevlakte hoeken.

![De koppelingsstijl in de presentatie](join-style-powerpoint.png)

Dit voorbeeld maakt drie zwarte rechthoeken met blauwe omlijningen van 15 punten breed. Het gebruikt [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) om respectievelijk de miter-, bevel- en round‑waarden van [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) toe te passen, om te vergelijken hoe de hoeken worden getekend.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let miterShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let bevelShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let roundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    bevelShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    roundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    bevelShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    roundShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    miterShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    bevelShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    roundShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Miter‑koppelingen beperken bij scherpe hoeken**

Gebruik [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) samen met [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) ingesteld op [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) om te beperken hoe ver een scherpe hoek kan uitsteken.

De limiet is een verhouding tussen de afstand tussen de binnen- en buitenhoeken van de koppeling en de lijndikte. Een waarde van `8` staat bijvoorbeeld een miter‑lengte toe tot acht keer de lijndikte; het is geen meting in punten. Als de hoek de limiet zou overschrijden, gebruikt PowerPoint een afgevlakte koppeling op die hoek. Een grotere limiet maakt scherpere punten mogelijk. De instelling beïnvloedt alleen miter‑koppelingen, en een wijziging heeft geen zichtbaar effect wanneer de hoek binnen beide limieten blijft.

Dit voorbeeld maakt twee identieke, ongevulde driehoeken met omlijningen van 20 punten breed. De linker driehoek gebruikt een limiet van `2`, en de rechter `8`. Elke driehoek is 80 punten breed en 160 punten hoog, wat de bovenste hoek een miter‑lengte‑tot‑lijndikte‑ratio geeft van ongeveer `4.12`. Hierdoor gebruikt PowerPoint een bevel op de linkerpunt en behoudt de rechterpunt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let miterLimits = [2, 8];

    for (let i = 0; i < miterLimits.length; i++) {
        let triangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        triangle.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
        triangle.getLineFormat().setMiterLimit(java.newFloat(miterLimits[i]));
    }

    presentation.save("miter_limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat in PowerPoint: **Miter limit 2** links en **miter limit 8** rechts.

![Een afgevlakte top met miter‑limiet 2 en een puntige top met miter‑limiet 8 in PowerPoint](miter-limits.png)

## **Verlopen opvulling**

Een verlopen opvulling mengt kleuren over een vorm. Dit voorbeeld vult een ellips met een lineair verloop onder een hoek van 45 graden van rood naar paars met behulp van [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat). De methode [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) plaatst de kleurstops bij 0 en 1, het begin en einde van het verloop. Het wissen van de bestaande stops zorgt ervoor dat alleen deze twee kleuren worden gebruikt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, aspose.slides.PresetColor.Red);

    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De ellips met verlopen opvulling](gradient-fill.png)

Als een verloop er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, zie dan [Choose a Gradient Rendering Style](/slides/nl/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). U kunt een weergavestijl kiezen zonder de in de presentatie opgeslagen verlopen opvulling te wijzigen.

### **Lineair verloophoek instellen**

Gebruik [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) om de oriëntatie van een [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/)‑opvulling te regelen. De hoek wordt gemeten in graden en neemt met de klok mee toe: `0` loopt van links naar rechts, `90` van boven naar beneden, `180` van rechts naar links, en `270` van onder naar boven. Factionele hoeken worden ondersteund. Eindige hoeken buiten `[0, 360)` worden genormaliseerd naar één omwenteling; bijvoorbeeld `-45` wordt `315` en `360` wordt `0`.

Dit voorbeeld maakt zes rechthoeken met identieke rode, groene en blauwe stops op de posities `0`, `0.5` en `1`. Schalen is uitgeschakeld zodat de hoek onafhankelijk van de verhoudingen van de rechthoeken kan worden vergeleken. De hoeken, van links naar rechts, zijn `0`, `45` en `90` in de eerste rij, en `135`, `180` en `270` in de tweede rij.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let angles = [0, 45, 90, 135, 180, 270];

    for (let i = 0; i < angles.length; i++) {
        let x = 30 + (i % 3) * 230;
        let y = 30 + Math.floor(i / 3) * 190;

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.False));
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat in PowerPoint:

![Lineaire verlopen bij 0, 45 en 90 graden in de bovenste rij, en 135, 180 en 270 graden in de onderste rij](linear-gradient-angles.png)

### **Lineair verloop schalen met de vorm**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) accepteert een [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/)‑waarde. Stel deze expliciet in op `False` om de geometrische verloophoek te behouden terwijl de verhoudingen van de vorm veranderen, of op `True` om het verloop te schalen met de breedte en hoogte van de vorm. Met ingeschakelde schaling kan de zichtbare hoek afwijken van de toegewezen hoek bij een niet‑vierkante vorm.

Het volgende voorbeeld gebruikt een hoek van `45` graden en dezelfde kleurstops als bij de hoekvergelijking. De linker kolom gebruikt `False`; de rechter kolom gebruikt `True`. Elke kolom bevat een brede rechthoek boven een hoge rechthoek. Beide beginnen met dezelfde brede afmetingen; het wijzigen van de breedte en hoogte van de tweede rechthoek toont hoe de opvulling reageert op schalen zonder de verloopinstellingen te wijzigen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let scalingOptions = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.True];

    for (let column = 0; column < scalingOptions.length; column++) {
        for (let row = 0; row < 2; row++) {
            let x = 30 + column * 360;
            let y = row == 0 ? 30 : 150;

            let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

            let gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
            gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
            gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(java.newByte(scalingOptions[column]));

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat in PowerPoint, met schalen uitgeschakeld links en ingeschakeld rechts:

![Brede en hoge rechthoeken met een 45‑graden verloop, met vergelijking LinearGradientScaled False links en True rechts](linear-gradient-scaling.png)

Met uitgeschakelde schaling behouden de diagonale kleurbanden dezelfde oriëntatie in beide rechthoeken. Met ingeschakelde schaling rekken de banden zich uit naar de verhoudingen van de vorm. Dit helpt om het verloop van een sjabloon te reproduceren bij het aanpassen van een vorm naar een andere grootte. Bij een vierkant verandert het uiterlijk van dit `45`‑graden verloop niet wanneer schalen wordt ingeschakeld.

Zowel de hoek‑ als de schaalinstellingen zijn van toepassing op lineaire verlopen. Ze regelen geen [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/)‑opvullingen.

### **Hoek combineren met verlooprichting**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) selecteert een verloopstijl uit de klasse [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/); het is geen vervanging voor een numerieke hoek. Voor een lineair verloop kunnen de hoekstijlen het gebied waarin de kleuren worden verdeeld wijzigen zonder de via [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) toegewezen hoek te wijzigen. Houd de richting onveranderd bij het vergelijken van hoeken of schalen.

Het volgende voorbeeld past dezelfde instellingen toe in omgekeerde volgorde. De twee rechthoeken hebben hetzelfde uiterlijk: de richting toewijzen vóór of na de hoek verandert het resultaat niet.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < 2; i++) {
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.True));

        if (i == 0) {
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Patroonopvulling**

Een patroonopvulling past een twee‑kleurig ontwerp toe, zoals stippen, strepen of geruite blokken. Dit voorbeeld gebruikt [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) om een trellis‑patroon te selecteren. [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) levert de lichtgrijze achtergrond, en [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) levert de gele patroonkleur.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De rechthoek met patroonopvulling](pattern-fill.png)

## **Afbeeldingsopvulling**

Een afbeeldingsopvulling gebruikt een afbeelding binnen een vorm. Dit voorbeeld vereist een lokale afbeelding en gebruikt [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) om deze in de afbeeldingcollectie van de presentatie te laden. Het instellen van [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) op de gegoten modus herhaalt de afbeelding binnen de rechthoek. De hier gebruikte bronafbeelding wordt hieronder getoond:

![De lotusafbeelding](lotus.png)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De vorm met afbeeldingsopvulling](picture-fill.png)

### **Afbeelding als tegeltextuur plaatsen**

Als u een getegelde afbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kunt u de volgende methoden van de klasse [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) gebruiken:

- `[setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Stelt de afbeeldingsopvulmodus in — `Tile` of `Stretch`.
- `[setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Specificeert de uitlijning van de tegels binnen de vorm.
- `[setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Regelt of de tegel horizontaal, verticaal of beide keren wordt gedraaid.
- `[setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Stelt de horizontale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm in.`
- `[setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Stelt de verticale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm in.`
- `[setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definieert de horizontale schaal van de tegel als een percentage.`
- `[setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definieert de verticale schaal van de tegel als een percentage.`

Dit voorbeeld vereist een lokale afbeelding en configureert [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) om deze te herhalen op 50 % van de oorspronkelijke grootte. Offsets van −32 punten verschuiven de tegels horizontaal en verticaal; uitlijning rechtsonder en draaien in beide richtingen bepalen hoe de herhaalde textuur wordt gerangschikt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen kleuropvulling**

Een egale opvulling geeft een vorm één enkele, uniforme kleur. Dit voorbeeld gebruikt [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) om de egale opvulmodus te selecteren en stelt geel in via [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor), waarna de rechthoek in een presentatie wordt opgeslagen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De vorm met egale kleuropvulling](solid-color-fill.png)

### **Kleuren kopiëren met behoud van themaverwijzingen**

Gebruik [ColorFormat.copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#copyFrom) om een kleurdefinitie te kopiëren, inclusief het kleurtype, de themaverwijzing en transformaties. Dit is nuttig bij het overzetten van een opvulkleur tussen vormen die het presentatiethema moeten blijven volgen. De methode kopieert alleen de kleur: hij kopieert niet het opvultype, de omlijning of andere vormopmaak. Stel het opvultype van de bestemmingsvorm expliciet in met [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType).

Dit voorbeeld maakt drie rechthoeken, van links naar rechts: de bron, een themabewuste kopie, en een vaste RGB‑kopie. De bron gebruikt [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setSchemeColor) om te verwijzen naar de eerste accentkleur en voegt een tint toe via [ColorOperationCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/coloroperationcollection/#add). De RGB‑kopie gebruikt de effectieve opvulkleur van de bron zodat alle drie aanvankelijk identiek lijken. Het aanroepen van [ColorFormat.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setColor) stelt een vaste RGB‑waarde in en wist eventuele bestaande kleurtransformaties.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 65, 105, 225));

    let source = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 40, 180, 140);
    let themeCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 240, 40, 180, 140);
    let rgbCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 450, 40, 180, 140);

    for (let shape of [source, themeCopy, rgbCopy]) {
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    let sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(aspose.slides.SchemeColor.Accent1);
    sourceColor.getColorTransform().add(aspose.slides.ColorTransformOperation.Tint, java.newFloat(0.75));

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    let before = slide.getImage(1, 1);
    try {
        before.save("color-copy-before.png", aspose.slides.ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Thema-referenties volgen de nieuwe accentkleur; de vaste RGB-waarde dat niet.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));

    let after = slide.getImage(1, 1);
    try {
        after.save("color-copy-after.png", aspose.slides.ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor de themawijziging komen alle drie de opvullingen overeen:

![Bron, copyFrom‑bestemming en vaste RGB‑bestemming met identieke blauwe opvullingen](color-copy-before.png)

Na de themawijziging volgen de bron en de themabewuste kopie de nieuwe accentkleur en behouden hun tint. De vaste RGB‑kopie blijft blauw:

![Bron en copyFrom‑bestemming met oranje opvullingen, terwijl de vaste RGB‑bestemming blauw blijft](color-copy-after.png)

De gekopieerde definitie is onafhankelijk van de bron. Het later wijzigen van de themaverwijzing van de bron, het toewijzen van een andere kleur, of het toevoegen of verwijderen van zijn transformaties verandert de bestemming niet. Een themawijziging beïnvloedt nog steeds beide vormen omdat elk onafhankelijk naar dezelfde themakleur verwijst.

Opslaan en opnieuw openen van de PPTX behoudt het type van de gekopieerde kleur dat wordt geretourneerd door [ColorFormat.getColorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorType), de themaverwijzing, en de transformatie‑collectie die wordt geretourneerd door [ColorFormat.getColorTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorTransform); het maakt de definitie niet plat naar RGB.

Bij het kopiëren tussen verschillende themacontexten, zoals presentaties met verschillende accentpaletten, wordt de gekopieerde verwijzing opgelost ten opzichte van het thema van de bestemming. Dezelfde verwijzing en transformaties kunnen daardoor een andere zichtbare kleur produceren. Zie [Presentation Theme](/slides/nl/nodejs-java/presentation-theme/) voor meer informatie over het configureren van themakleuren.

## **De dia‑achtergrond als vormopvulling gebruiken**

Gebruik [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill) wanneer een vorm moet overeenkomen met de dia‑achtergrond, bijvoorbeeld in een presentatiesjabloon. Stel het opvultype eerst in op [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) via [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) om alle expliciete opvulling te verwijderen. Met deze combinatie gebruikt de vorm de dia‑achtergrond in plaats van zijn stijl‑opvulling. Het alleen inschakelen van de vlag verwijdert geen bestaande expliciete opvulling.

Dit verschilt van [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/): achtergrondopvulling bedekt objecten achter de vorm met het overeenkomstige gebied van de dia‑achtergrond, terwijl geen opvulling die objecten zichtbaar laat. Een verloop blijft uitgelijnd met de dia in plaats van opnieuw te beginnen binnen elke vorm.

Het volgende voorbeeld maakt een master‑achtergrond die door de dia wordt geërfd en plaatst een magenta‑band achter drie rechthoeken. De linkere rechthoek gebruikt de achtergrond, de middelste rechthoek heeft geen opvulling, en de rechter rechthoek schakelt van achtergrondopvulling naar een expliciete oranje opvulling.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // Het verloop erven van de master.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    slide.getLayoutSlide().getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    let background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    let gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, java.newInstanceSync("java.awt.Color", 0, 0, 139));
    gradient.getGradientStops().add(1, java.newInstanceSync("java.awt.Color", 135, 206, 250));

    // Voeg dit object eerst toe zodat het achter de rechthoeken verschijnt.
    let band = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    band.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    band.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let backgroundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    backgroundShape.setUseBackgroundFill(true);

    let noFillShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let explicitShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    explicitShape.setUseBackgroundFill(true);

    // Schakel achtergrondvulling uit voordat een expliciete vulling wordt toegepast.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat, van links naar rechts: **background fill**, **no fill** en **explicit fill**. De magenta‑band wordt verborgen door de linker en rechter rechthoek, maar blijft zichtbaar door de middelste rechthoek.

![Achtergrondopvulling, geen opvulling en expliciete oranje opvulling over een magenta‑band](background-fill.png)

Hetzelfde gedrag geldt voor een achtergrond die rechtstreeks op de dia is gedefinieerd of geërfd van een lay‑out. De vorm gebruikt de geëvalueerde achtergrond van de dia; het voorbeeld laat zowel de dia‑ als de lay‑out‑achtergronden ongedefinieerd zodat de master deze levert.

## **Transparantie instellen**

Voor een egale opvulling bepaalt de alfa‑component van de kleur de opaciteit: 0 is volledig transparant en 255 volledig ondoorzichtig. Dit voorbeeld gebruikt een alfade waarde van 128 voor een gele rechthoek, waardoor deze ongeveer 50 % transparant is zodat de onderliggende rechthoek zichtbaar blijft. De kleur wordt toegewezen via [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Gebruik [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) om een vorm in het dia‑vlak te roteren. De hoek wordt gemeten in graden; dit voorbeeld roteert een rechthoek 5 graden met de klok mee en slaat de presentatie op.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De rotatie van de vorm](shape-rotation.png)

## **3D‑schuineffecten toevoegen**

Gebruik [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) om een vorm diepte en gegooide randen te geven. Dit voorbeeld maakt een groene ellips met een oranje omlijning, gebruikt [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) om de diepte op 4 punten in te stellen, en past een cirkelvormige bovenste schuine rand toe met een breedte en hoogte van 6 punten via [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop). Een front‑facing orthografische camera en drie‑puntverlichting maken de schuine rand zichtbaar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![Het 3D‑schuineffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

De 3D‑weergave van een vorm wordt geregeld door de cameraparameters. Dit voorbeeld gebruikt [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) met breedtegraad-, lengtegraad- en revolutiehoeken van respectievelijk 40, 35 en 20 graden. Het selecteert een isometrische camera via [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) en uitgebalanceerde belichting via [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType), waarna de opgemaakte rechthoek wordt opgeslagen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart‑wit weergave voor vormen beheren**

De methode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) geeft aan hoe een individuele vorm wordt weergegeven wanneer een presentatie wordt bekeken of verwerkt in zwart‑wit‑modus. Het activeert niet zelf een zwart‑wit‑weergave, en het verandert de opvulling, lijn of andere opmaak van de vorm niet in de normale kleurlus.

Gebruik een waarde uit de klasse [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de weergave‑applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijze kleuring, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` forceren een enkele kleur, `Color` behoudt de normale kleuring, en `Hidden` laat de vorm weg in zwart‑wit‑modus. `NotDefined` betekent dat er geen vorm‑specifieke modus is toegewezen.

Dit voorbeeld maakt een oranje rechthoek en gebruikt [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) om grijze kleuring te selecteren. De opgeslagen vorm behoudt zijn oranje opvulling voor normale kleurweergave en vraagt grijze kleuring aan applicaties die zwart‑wit‑weergave‑instellingen respecteren:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In de normale kleurlus behoudt de rechthoek zijn oranje opvulling. In een zwart‑wit‑workflow gebruikt hij grijze kleuring omdat de modus is ingesteld op `Gray`. Hiermee kunt u een dia met volledige kleur behouden terwijl u een andere weergave definieert voor afdrukken, voorbeeldweergave of andere workflows die de zwart‑wit‑instellingen van de presentatie respecteren.

## **Opmaak resetten**

Gebruik [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) om de positie, grootte en opmaak van dia‑plaatsaanduidingen te herstellen uit de overeenkomstige lay‑plaatsaanduidingen. Dit voorbeeld vereist een bestaande presentatie met lay‑plaatsaanduidingen en reset elke dia vóór het opslaan. Vormen zonder overeenkomstige lay‑plaatsaanduidingen worden niet gereset.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Heeft vormopmaak invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Kleuren, lijnstijlen en effectinstellingen voegen over het algemeen weinig data toe in vergelijking met ingesloten afbeeldingen en media. Afbeeldingsopvullingen kunnen de bestandsgrootte vergroten omdat hun afbeeldingen in de presentatie worden opgeslagen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaakeigenschappen van elke vorm — opvulling, lijn en effectinstellingen. Als alle bijbehorende waarden overeenkomen, beschouw dan hun stijlen als identiek en groepeer die vormen logisch, wat later het beheer van stijlen vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloon‑dia‑set of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie opent u het sjabloon, kloont u de benodigde gestylede vormen, en past u hun opmaak opnieuw toe waar nodig.