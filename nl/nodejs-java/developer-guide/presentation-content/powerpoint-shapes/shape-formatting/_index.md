---
title: Vormopmaak van PowerPoint-vormen in JavaScript
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/nodejs-java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets-effect
- schetsvormlijn
- samenvoegstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- vorm draaien
- 3D-schuine rand-effect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Opmaak van PowerPoint-vormen in JavaScript met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Introductie**

In PowerPoint kun je vormen aan dia’s toevoegen. Omdat vormen uit lijnen bestaan, kun je ze opmaken door de omtrek te wijzigen of er effecten op toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe de binnenkant wordt gevuld.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java biedt klassen en methoden waarmee je vormen kunt opmaken met dezelfde opties die beschikbaar zijn in PowerPoint.

## **Lijnen Opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm specificeren. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van zijn index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [line style](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende code laat zien hoe je een rechthoek‑`AutoShape` kunt opmaken:

```js
// Maak een instantie van de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-shape van het type Rechthoek toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Stel de vulkleur in voor de rechthoekvorm.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Pas opmaak toe op de lijnen van de rechthoek.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Stel de kleur in voor de lijn van de rechthoek.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The formatted lines in the presentation](formatted-lines.png)

## **Schets‑effecten Toepassen op Vormlijnen**

Een schets‑effect maakt een vormlijn eruit laten zien alsof deze met de hand is getekend. Gebruik [Shape.getLineFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) om de lijninstellingen te benaderen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/lineformat/) om de schetsinstellingen te benaderen, en [SketchFormat.setSketchType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sketchformat/) om een waarde te selecteren uit de [LineSketchType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/linesketchtype/)‑enumeratie.

De volgende JavaScript‑code toont hoe je een [LineSketchType.Curved](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde uitleest, en het effect verwijdert met [LineSketchType.None](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/linesketchtype/):

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Toegang tot de lijnopmaak van de vorm en de schetsopmaak.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Pas een schets‑effect toe.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Lees het schets‑effect dat rechtstreeks aan de vorm is toegewezen.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Verwijder het schets‑effect.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

De waarde die wordt geretourneerd door [SketchFormat.getSketchType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sketchformat/) representeert de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, master‑dia of lay‑dia, gebruik dan [LineFormat.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/lineformat/), roep `getSketchFormat` aan op het geretourneerde object en vervolgens de `getSketchType`‑methode. De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat de overerving is opgelost:

```js
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

## **Samenvoeg‑stijlen Opmaken**

Hier zijn de drie opties voor het type samenvoeging:

* Round  
* Miter  
* Bevel  

Standaard gebruikt PowerPoint bij het samenvoegen van twee lijnen onder een hoek (bijvoorbeeld bij een hoek van een vorm) de instelling **Round**. Als je echter een vorm met scherpe hoeken tekent, geef je misschien de voorkeur aan **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

De volgende JavaScript‑code laat zien hoe drie rechthoeken (zoals weergegeven in de afbeelding hierboven) werden gemaakt met de samenvoeg‑instellingen Miter, Bevel en Round:

```js
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg drie auto-shapes van het type Rechthoek toe.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Stel de vulkleur in voor elke rechthoekvorm.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Stel de lijndikte in.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Stel de kleur in voor de lijn van elke rechthoek.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Stel de samenvoegstijl in.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Voeg tekst toe aan elke rechthoek.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie die je toelaat een continue kleurovergang op een vorm toe te passen. Je kunt bijvoorbeeld twee of meer kleuren zo toepassen dat de ene geleidelijk in de andere overloopt.

Zo pas je een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van zijn index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) van de vorm in op `Gradient`.
1. Voeg je twee gewenste kleuren toe met gedefinieerde posities via de `add`‑methoden van de gradient‑stop‑collectie die wordt blootgelegd door de [GradientFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/gradientformat/)‑klasse.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende JavaScript‑code toont hoe je een verloopvulling toepast op een ellips:

```js
    // Maak een instantie van de Presentation-klasse die een presentiebestand vertegenwoordigt.
    let presentation = new aspose.slides.Presentation();
    try {
        // Haal de eerste dia op.
        let slide = presentation.getSlides().get_Item(0);

        // Voeg een auto-shape van het type Ellipse toe.
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

        // Pas een verloopopmaak toe op de ellips.
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
        shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

        // Stel de richting van het verloop in.
        shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

        // Voeg twee verloopstops toe.
        shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
        shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

        // Sla het PPTX-bestand op naar schijf.
        presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

Het resultaat:

![The ellipse with gradient fill](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, kruislijnen of geruite patronen—op een vorm kunt toepassen. Je kunt zelf kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele uitstraling van je presentaties te verbeteren. Zelfs nadat je een vooraf gedefinieerd patroon hebt gekozen, kun je de exacte kleuren die het moet gebruiken nog steeds specificeren.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van zijn index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) van de vorm in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/patternformat/#getBackColor--) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/patternformat/#getForeColor--) van het patroon in.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende JavaScript‑code laat zien hoe je een patroonvulling toepast op een rechthoek:

```js
// Maak een instantie van de Presentation-klasse die een presentiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-shape van het type Rechthoek toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Patroon.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Stel de patroonstijl in.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Stel de achtergrond- en voorgrondkleuren van het patroon in.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The rectangle with pattern fill](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie die je toelaat een afbeelding in een vorm te plaatsen—de afbeelding fungeert eigenlijk als de achtergrond van de vorm.

Zo gebruik je Aspose.Slides om een afbeelding in een vorm te vullen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van zijn index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) van de vorm in op `Picture`.
1. Stel de afbeeldingsvullingsmodus in op `Tile` (of een andere gewenste modus).
1. Maak een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/)‑object aan vanuit de afbeelding die je wilt gebruiken.
1. Geef de afbeelding door aan de `ISlidesPicture.setImage`‑methode.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

Stel dat we een bestand “lotus.png” hebben met de volgende afbeelding:

![The lotus picture](lotus.png)

De volgende JavaScript‑code laat zien hoe je een vorm vult met de afbeelding:

```js
// Maak een instantie van de Presentation-klasse die een presentiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-shape van het type Rechthoek toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Stel het vultype in op Afbeelding.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Stel de afbeeldingsvullingsmodus in.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Laad een afbeelding en voeg deze toe aan de presentatiebronnen.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Stel de afbeelding in.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The shape with picture fill](picture-fill.png)

### **Afbeelding Tilen als Textuur**

Wil je een getegelde afbeelding als textuur instellen en het tegelgedrag aanpassen, dan kun je de volgende methoden van de [PictureFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/)‑klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Stelt de afbeeldingsvullingsmodus in—`Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Bepaalt de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Bepaalt of de tegel horizontaal, verticaal of beide kanten wordt gespiegeld.
- [setTileOffsetX](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definieert de horizontale schaal van de tegel als percentage.
- [setTileScaleY](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definieert de verticale schaal van de tegel als percentage.

De volgende code‑voorbeeld toont hoe je een rechthoekige vorm toevoegt met een getegelde afbeeldingvulling en de tegelopties configureert:

```js
// Maak een instantie van de Presentation-klasse die een presentiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Voeg een auto-shape van het type Rechthoek toe.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Stel het vultype van de vorm in op Afbeelding.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Laad de afbeelding en voeg deze toe aan de presentatiebronnen.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Wijs de afbeelding toe aan de vorm.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configureer de afbeeldingsvullingsmodus en tegel‑eigenschappen.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Sla het PPTX‑bestand op naar schijf.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The tile options](tile-options.png)

## **Effen Kleur Vulling**

In PowerPoint is Effen Kleur Vulling een opmaakoptie die een vorm vult met één enkele, uniforme kleur. Deze egale achtergrondkleur wordt toegepast zonder verloop, textuur of patroon.

Om een effen kleur vulling op een vorm toe te passen met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van zijn index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) van de vorm in op `Solid`.
1. Wijs je gewenste vulkleur toe aan de vorm.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende JavaScript‑code laat zien hoe je een effen kleur vulling toepast op een rechthoek in een PowerPoint‑dia:

```js
// Maak een instantie van de Presentation-klasse die een presentiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-shape van het type Rechthoek toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Solide.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Stel de vulkleur in.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The shape with solid color fill](solid-color-fill.png)

## **Transparantie Instellen**

In PowerPoint kun je, naast een effen kleur, een verloop-, afbeelding‑ of textuurvulling, ook een transparantieniveau instellen om de doorzichtigheid van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorzichtig, waardoor de achtergrond of onderliggende objecten deels zichtbaar worden.

Aspose.Slides laat je het transparantieniveau instellen door de alfa‑waarde van de gebruikte vulkleur aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van zijn index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color` om een kleur met transparantie te definiëren (de `alpha`‑component bepaalt de transparantie).
1. Sla de presentatie op.

De volgende JavaScript‑code laat zien hoe je een transparante vulkleur toepast op een rechthoek:

```js
// Maak een instantie van de Presentation-klasse die een presentiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een solide rechthoek-auto-shape toe.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoek-auto-shape toe boven de solide vorm.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The transparent shape](shape-transparency.png)

## **Vormen Draaien**

Aspose.Slides stelt je in staat vormen te draaien in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning of ontwerpvereisten.

Om een vorm op een dia te draaien, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van zijn index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

De volgende JavaScript‑code demonstreert hoe je een vorm 5 graden draait:

```js
// Maak een instantie van de Presentation-klasse die een presentiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-shape van het type Rechthoek toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Roteer de vorm met 5 graden.
    shape.setRotation(5);

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The shape rotation](shape-rotation.png)

## **3D‑Schuine Rand‑Effecten Toevoegen**

Aspose.Slides stelt je in staat 3D‑schuine rand‑effecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑schuine rand‑effecten aan een vorm toe te voegen, volg je deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van zijn index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/) van de vorm om de schuine rand‑instellingen te definiëren.
1. Sla de presentatie op.

De volgende JavaScript‑code laat zien hoe je 3D‑schuine rand‑effecten op een vorm toepast:

```js
// Maak een instantie van de Presentation-klasse.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een vorm toe aan de dia.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Stel de ThreeDFormat-eigenschappen van de vorm in.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Sla de presentatie op als een PPTX-bestand.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑Rotatie‑Effecten Toevoegen**

Aspose.Slides stelt je in staat 3D‑rotatie‑effecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van zijn index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Gebruik [setCameraType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/camera/#setCameraType) en [setLightType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/lightrig/#setLightType) om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

De volgende JavaScript‑code demonstreert hoe je 3D‑rotatie‑effecten op een vorm toepast:

```js
// Maak een instantie van de Presentation-klasse.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Sla de presentatie op als een PPTX-bestand.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The 3D rotation effect](3D-rotation-effect.png)

## **Opmaak Resetten**

De volgende Java‑code laat zien hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met plaatshouders op de [LayoutSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Reset elke vorm op de dia die een plaatshouder op de lay-out heeft.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Heeft de opmaak van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen in zeer beperkte mate. Ingevoegde afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en praktisch geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vul-, lijn‑ en effectinstellingen. Als alle overeenkomstige waarden gelijk zijn, beschouw je de stijlen als identiek en groepeer je die vormen logisch, wat later het beheer van stijlen vereenvoudigt.

**Kan ik een reeks aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloondiaset of een .POTX‑sjabloonbestand. Wanneer je een nieuwe presentatie maakt, open je het sjabloon, kloon je de stijlvormen die je nodig hebt, en pas je hun opmaak toe waar nodig.