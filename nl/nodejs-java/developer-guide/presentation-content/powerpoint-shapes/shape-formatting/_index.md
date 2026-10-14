---
title: Opmaak van PowerPoint-vormen in JavaScript
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/nodejs-java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets effect
- schets vormlijn
- verbindingstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart-wit vormweergave
- grijswaarde vormweergave
- vorm roteren
- 3D schuineffect
- 3D rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Opmaak van PowerPoint-vormen in JavaScript met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Introductie**

In PowerPoint kun je vormen aan dia’s toevoegen. Omdat vormen uit lijnen bestaan, kun je ze opmaken door hun contouren te wijzigen of er effecten op toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![vorm-opmaak-powerpoint](format-shape-powerpoint.png)

Aspose.Slides voor Node.js via Java biedt klassen en methoden waarmee je vormen kunt opmaken met dezelfde opties die beschikbaar zijn in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm opgeven. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [line style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende code laat zien hoe je een rechthoekige `AutoShape` kunt opmaken:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-vorm van het type Rechthoek toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Verwijder de vulling van de rechthoekige vorm.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Pas opmaak toe op de lijnen van de rechthoek.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Stel de kleur in voor de lijn van de rechthoek.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Sla het PPTX-bestand op schijf.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect laat een vormlijn eruit zien alsof deze met de hand is getekend. Gebruik [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) om de lijninstellingen te benaderen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) om de schetsinstellingen te benaderen, en [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) om een waarde uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) te selecteren.

De volgende JavaScript‑code laat zien hoe je een [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) effect toepast, de expliciet toegewezen waarde leest, en het effect verwijdert met [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Toegang tot de lijnopmaak van de vorm en het schetsformaat.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Schets‑effect toepassen.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Lees het schets‑effect dat direct aan de vorm is toegewezen.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Verwijder het schets‑effect.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

De waarde die wordt geretourneerd door [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) geeft de instelling weer die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, master‑dia of lay‑outdia, gebruik dan [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/), roep `getSketchFormat` aan op het geretourneerde object en roep vervolgens de methode `getSketchType` aan. De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat de overerving is opgehelderd:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Join‑stijlen opmaken**

Dit zijn de drie opties voor het type verbinding:

* Rond
* Scherp
* Afgeschuind

Standaard gebruikt PowerPoint, wanneer het twee lijnen onder een hoek (bijvoorbeeld bij een hoek van een vorm) samenvoegt, de instelling **Rond**. Als je echter een vorm met scherpe hoeken tekent, kun je de **Scherp** optie verkiezen.

![De aansluitstijl in de presentatie](join-style-powerpoint.png)

De volgende JavaScript‑code laat zien hoe drie rechthoeken (zoals weergegeven in de afbeelding hierboven) werden gemaakt met de Miter‑, Bevel‑ en Rond‑instellingen voor het type verbinding:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg drie auto‑vormen van het type Rechthoek toe.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Stel de vulkleur in voor elke rechthoek‑vorm.
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

    // Stel de verbindingstijl in.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Voeg tekst toe aan elke rechthoek.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Sla het PPTX‑bestand op schijf.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie waarmee je een continu kleurverloop op een vorm kunt toepassen. Je kunt bijvoorbeeld twee of meer kleuren toepassen zodat de ene geleidelijk in de andere overloopt.

Zo pas je een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) van de vorm in op `Gradient`.
1. Voeg je twee gewenste kleuren toe met gedefinieerde posities met behulp van de `add`‑methoden van de gradient‑stop‑collectie die wordt blootgesteld door de klasse [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/).
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto‑vorm van het type Ellipse toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Pas een verloop‑opmaak toe op de ellips.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Stel de richting van het verloop in.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Voeg twee verloopstops toe.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Sla het PPTX‑bestand op schijf.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De ellips met verloopvulling](gradient-fill.png)

Als een verloop er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, zie dan [Choose a Gradient Rendering Style](/slides/nl/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Je kunt een weergavestijl kiezen zonder de in de presentatie opgeslagen verloopvulling te wijzigen.

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee je een tweekleurenontwerp—zoals stippen, strepen, kruispatronen of geruite patronen—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te vergroten. Ook na het kiezen van een vooraf gedefinieerd patroon kun je nog steeds de exacte kleuren specificeren die het moet gebruiken.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) van de vorm in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto‑vorm van het type Rechthoek toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Patroon.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Stel de patroonstijl in.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Stel de achtergrond‑ en voorgrondkleuren van het patroon in.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Sla het PPTX‑bestand op schijf.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt invoegen—effectief als achtergrond van de vorm.

Zo gebruik je Aspose.Slides om een afbeeldingsvulling toe te passen op een vorm:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) van de vorm in op `Picture`.
1. Stel de afbeeldingsvulling‑modus in op `Tile` (of een andere gewenste modus).
1. Maak een [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)‑object aan van de afbeelding die je wilt gebruiken.
1. Geef de afbeelding door aan de `ISlidesPicture.setImage`‑methode.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

![De lotus-afbeelding](lotus.png)

De volgende JavaScript‑code laat zien hoe je een vorm vult met de afbeelding:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto‑vorm van het type Rechthoek toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Stel het vultype in op Afbeelding.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Stel de afbeeldingsvullingsmodus in.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Laad een afbeelding en voeg deze toe aan de presentatie‑bronnen.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Stel de afbeelding in.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Sla het PPTX‑bestand op schijf.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding als tegeltekstuur**

Als je een tegelafbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kun je de volgende methoden van de [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Stelt de afbeeldingsvulling‑modus in—`Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Geeft de uitlijning van de tegels binnen de vorm aan.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Bepaalt of de tegel horizontaal, verticaal of beide kanten wordt gespiegeld.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definieert de horizontale schaal van de tegel als percentage.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definieert de verticale schaal van de tegel als percentage.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Voeg een rechthoekige auto vorm toe.
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

    // Sla het PPTX‑bestand op schijf.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm vult met één enkele, uniforme kleur. Deze effen achtergrondkleur wordt toegepast zonder verlopen, texturen of patronen.

Om een effen kleurvulling toe te passen op een vorm met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) van de vorm in op `Solid`.
1. Wijs je gewenste vulkleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieer de Presentation-klasse die een presentatie‑bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto‑vorm van het type Rechthoek toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Stel de vulkleur in.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Sla het PPTX‑bestand op schijf.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, naast een effen kleur, een verloop‑, afbeelding‑ of textuurvulling, een transparantieniveau instellen om de opaciteit van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm doorzichtiger, zodat de achtergrond of onderliggende objecten gedeeltelijk zichtbaar zijn.

Aspose.Slides laat je het transparantieniveau instellen door de alfa‑waarde van de kleur die voor de vulling wordt gebruikt aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color` om een kleur met transparantie te definiëren (de `alpha`‑component regelt de transparantie).
1. Sla de presentatie op.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieer de Presentation-klasse die een presentatie‑bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een solide rechthoekige auto‑vorm toe.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoekige auto‑vorm toe boven de solide vorm.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Sla het PPTX‑bestand op schijf.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides laat je vormen draaien in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning of ontwerpvereisten.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieer de Presentation-klasse die een presentatie‑bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto‑vorm van het type Rechthoek toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Draai de vorm 5 graden.
    shape.setRotation(5);

    // Sla het PPTX‑bestand op schijf.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De vormrotatie](shape-rotation.png)

## **3D‑schuineffecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑schuineffecten op vormen toe te passen door de eigenschappen van hun [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) te configureren.

Om 3D‑schuineffecten aan een vorm toe te voegen, volg je deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) van de vorm om de schuine‑instellingen te definiëren.
1. Sla de presentatie op.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

![Het 3D‑schuineffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑rotatie‑effecten op vormen toe te passen door de eigenschappen van hun [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Gebruik [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) en [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart‑wit weergave voor vormen beheren**

De methode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) bepaalt hoe een individuele vorm wordt gerenderd wanneer een presentatie in zwart‑wit‑modus wordt bekeken of verwerkt. De methode activeert niet zelf een zwart‑wit‑weergave en wijzigt de vul‑, lijn‑ of andere opmaak van de vorm niet in de normale kleermodus.

Gebruik een waarde uit de enumeratie [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de render‑applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijze kleuren, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` forceren één kleur, `Color` behoudt de normale kleuring, en `Hidden` laat de vorm weg in zwart‑wit‑modus. `NotDefined` betekent dat er geen modus op vormniveau is toegewezen.

De volgende JavaScript‑code maakt een gekleurde vorm aan en laat deze grijs verschijnen in de zwart‑wit‑weergavemodus:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // Behoud de oranje vulling in kleermodus, maar render de vorm met grijze kleuring in zwart-wit modus.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Opmaak resetten**

De volgende JavaScript‑code laat zien hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Reset elke vorm op de dia die een placeholder heeft in de lay-out.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Heeft de opmaak van een vorm invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingesloten afbeeldingen en media vormen het grootste gedeelte van de bestandsgrootte, terwijl vormparameters zoals kleuren, effect en verlopen als metadata worden opgeslagen en vrijwel geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vul, lijn en effectinstellingen. Als alle overeenkomstige waarden overeenkomen, beschouw dan hun stijlen als identiek en groepeer die vormen logisch, wat later beheer van stijlen vergemakkelijkt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Bewaar voorbeeldvormen met de gewenste stijlen in een sjabloondia‑deck of een .POTX‑sjabloonbestand. Wanneer je een nieuwe presentatie maakt, open je het sjabloon, kloon je de gestylede vormen die je nodig hebt, en pas je hun opmaak opnieuw toe waar nodig.