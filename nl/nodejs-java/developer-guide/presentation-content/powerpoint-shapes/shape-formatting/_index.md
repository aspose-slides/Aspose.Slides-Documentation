---
title: Vorm PowerPoint-vormen opmaken in JavaScript
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/nodejs-java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets‑effect
- schetsvormlijn
- aansluitingsstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart‑wit weergave van vormen
- grijstinten weergave van vormen
- vorm roteren
- 3D‑schuineffect
- 3D‑rotatie‑effect
- opmaak resetten
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint-vormen opmaken in JavaScript met Aspose.Slides—stel vullingen, lijnen en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Inleiding**

In PowerPoint kun je vormen toevoegen aan dia's. Omdat vormen bestaan uit lijnen, kun je ze opmaken door de contouren te wijzigen of effecten toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![vorm-opmaak-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java biedt klassen en methoden waarmee je vormen kunt opmaken met dezelfde opties als beschikbaar in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm opgeven. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse aan.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [line style](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende code toont hoe je een rechthoekige `AutoShape` kunt opmaken:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantie van de Presentation-klasse maken die een presentatie-bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // De eerste dia ophalen.
    let slide = presentation.getSlides().get_Item(0);

    // Een AutoShape van het type Rechthoek toevoegen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // De vulling van de rechthoekvorm verwijderen.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Opmaak toepassen op de lijnen van de rechthoek.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // De kleur instellen voor de lijn van de rechthoek.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Het PPTX-bestand opslaan op schijf.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect laat een vormlijn er handgetekend uitzien. Gebruik [Shape.getLineFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) om de lijninstellingen te benaderen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/lineformat/) om de schetsinstellingen te benaderen, en [SketchFormat.setSketchType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sketchformat/) om een waarde uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/linesketchtype/) te selecteren.

De volgende JavaScript‑code laat zien hoe je een [LineSketchType.Curved](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde uitleest, en het effect verwijdert met [LineSketchType.None](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Toegang tot het lijnformaat van de vorm en het schetsformaat.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Een schets-effect toepassen.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Het schets-effect lezen dat rechtstreeks aan de vorm is toegewezen.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Het schets-effect verwijderen.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

De waarde die wordt geretourneerd door [SketchFormat.getSketchType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sketchformat/) vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegekend. Als de lijnopmaak kan worden geërfd van een thema, master‑dia of lay‑dia, gebruik dan [LineFormat.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/lineformat/), roep `getSketchFormat` aan op het teruggegeven object en roep vervolgens zijn `getSketchType`‑methode aan. De effectieve waarde geeft de opmaak weer die daadwerkelijk wordt toegepast nadat de overerving is opgelost:

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

## **Aansluitingsstijlen opmaken**

Dit zijn de drie opties voor het type aansluiting:

* Rond
* Verstek
* Afgeschuind

Standaard, wanneer PowerPoint twee lijnen onder een hoek (bijvoorbeeld bij een hoek van een vorm) verbindt, gebruikt het de instelling **Rond**. Als je echter een vorm met scherpe hoeken tekent, kun je de **Verstek**‑optie verkiezen.

![De aansluitingsstijl in de presentatie](join-style-powerpoint.png)

De volgende JavaScript‑code toont hoe drie rechthoeken (zoals weergegeven in de afbeelding hierboven) zijn gemaakt met de Verstek‑, Afgeschuind‑ en Rond‑aansluitingsinstellingen:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantie van de Presentation-klasse maken die een presentatie-bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // De eerste dia ophalen.
    let slide = presentation.getSlides().get_Item(0);

    // Drie auto-shapes van het type Rechthoek toevoegen.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // De vulkleur voor elke rechthoekvorm instellen.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // De lijndikte instellen.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // De kleur voor de lijn van elke rechthoek instellen.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // De aansluitingsstijl instellen.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Tekst aan elke rechthoek toevoegen.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Het PPTX-bestand opslaan op schijf.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verloopvulling**

In PowerPoint is Gradient Fill een opmaakoptie waarmee je een continue kleurverloop op een vorm kunt toepassen. Je kunt bijvoorbeeld twee of meer kleuren toepassen zodat de ene geleidelijk in de andere overloopt.

Zo pas je een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) van de vorm in op `Gradient`.
1. Voeg je twee gewenste kleuren met gedefinieerde posities toe via de `add`‑methoden van de gradient‑stop‑collectie die wordt blootgesteld door de [GradientFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/gradientformat/) klasse.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantie van de Presentation-klasse maken die een presentatiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // De eerste dia ophalen.
    let slide = presentation.getSlides().get_Item(0);

    // Een auto‑vorm van het type Ellips toevoegen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Een verloopopmaak toepassen op de ellips.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // De richting van het verloop instellen.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Twee verloopstops toevoegen.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Het PPTX‑bestand opslaan op schijf.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De ellips met verloopvulling](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Pattern Fill een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, kruislings of geruite patronen—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te verbeteren. Zelfs na het selecteren van een vooraf gedefinieerd patroon kun je de exacte kleuren die het moet gebruiken nog steeds specificeren.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) van de vorm in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/patternformat/#getBackColor--) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/patternformat/#getForeColor--) van het patroon in.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // De eerste dia ophalen.
    let slide = presentation.getSlides().get_Item(0);

    // Een auto‑vorm van het type Rechthoek toevoegen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Het vultype instellen op Patroon.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // De patroonstijl instellen.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // De achtergrond‑ en voorgrondkleuren van het patroon instellen.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Het PPTX‑bestand opslaan op schijf.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Picture Fill een opmaakoptie waarmee je een afbeelding in een vorm kunt invoegen—effectief de afbeelding als achtergrond van de vorm gebruiken.

Zo gebruik je Aspose.Slides om een afbeelding als vulling toe te passen op een vorm:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) van de vorm in op `Picture`.
1. Stel de modus voor afbeeldingvulling in op `Tile` (of een andere gewenste modus).
1. Maak een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/)‑object aan van de afbeelding die je wilt gebruiken.
1. Geef de afbeelding door aan de `ISlidesPicture.setImage`‑methode.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

![De lotusafbeelding](lotus.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // De eerste dia ophalen.
    let slide = presentation.getSlides().get_Item(0);

    // Een auto‑vorm van het type Rechthoek toevoegen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Het vultype instellen op Afbeelding.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // De afbeeldingsvulmodus instellen.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Een afbeelding laden en toevoegen aan de presentatieresources.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // De afbeelding instellen.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Het PPTX‑bestand opslaan op schijf.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De vorm met afbeeldingvulling](picture-fill.png)

### **Afbeelding als tegeltextuur**

Als je een getegelde afbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kun je de volgende methoden van de [PictureFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/) klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Stelt de modus voor afbeeldingvulling in—ofwel `Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Specificeert de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Bepaalt of de tegel horizontaal, verticaal of beide kanten wordt gespiegeld.
- [setTileOffsetX](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definieert de horizontale schaal van de tegel als een percentage.
- [setTileScaleY](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definieert de verticale schaal van de tegel als een percentage.

De volgende code‑voorbeeld toont hoe je een rechthoekige vorm toevoegt met een getegelde afbeeldingvulling en de tegelopties configureert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // De eerste dia ophalen.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Een rechthoekige auto‑vorm toevoegen.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Het vultype van de vorm instellen op Afbeelding.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // De afbeelding laden en toevoegen aan de presentatieresources.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // De afbeelding aan de vorm toewijzen.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // De afbeeldingsvulmodus en tegel‑eigenschappen configureren.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Het PPTX‑bestand opslaan op schijf.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De tegelopties](tile-options.png)

## **Vulling met effen kleur**

In PowerPoint is Solid Color Fill een opmaakoptie die een vorm vult met één enkele, egale kleur. Deze effen achtergrondkleur wordt toegepast zonder enige verlopen, texturen of patronen.

Om een effenkleurvulling toe te passen op een vorm met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) van de vorm in op `Solid`.
1. Wijs je gewenste vulkleur toe aan de vorm.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // De eerste dia ophalen.
    let slide = presentation.getSlides().get_Item(0);

    // Een auto‑vorm van het type Rechthoek toevoegen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Het vultype instellen op Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // De vulkleur instellen.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Het PPTX‑bestand opslaan op schijf.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je bij het toepassen van een effen kleur, verloop, afbeelding of textuur op vormen ook een transparantieniveau instellen om de dekkingsgraad van de vulling te bepalen. Een hogere transparantiewaarde maakt de vorm doorzichtiger, zodat de achtergrond of onderliggende objecten gedeeltelijk zichtbaar zijn.

Aspose.Slides laat je het transparantieniveau instellen door de alfa‑waarde van de gebruikte vulkleur aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color` om een kleur met transparantie te definiëren (de `alpha`‑component bepaalt de transparantie).
1. Sla de presentatie op.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // De eerste dia ophalen.
    let slide = presentation.getSlides().get_Item(0);

    // Een solide rechthoekige auto-vorm toevoegen.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Een doorzichtige rechthoekige auto-vorm boven de solide vorm toevoegen.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Het PPTX-bestand opslaan op schijf.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides maakt het mogelijk om vormen te roteren in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijnings‑ of ontwerpeisen.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // De eerste dia ophalen.
    let slide = presentation.getSlides().get_Item(0);

    // Een auto‑vorm van het type Rechthoek toevoegen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // De vorm 5 graden roteren.
    shape.setRotation(5);

    // Het PPTX‑bestand opslaan op schijf.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![De vormrotatie](shape-rotation.png)

## **3D‑schuineffecten toevoegen**

Aspose.Slides stelt je in staat om 3D‑schuineffecten toe te passen op vormen door de eigenschappen van hun [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/) te configureren.

Om 3D‑schuineffecten toe te voegen aan een vorm, volg je deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/) van de vorm om de schuine instellingen te definiëren.
1. Sla de presentatie op.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Een instantie van de Presentation-klasse aanmaken.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Een vorm aan de dia toevoegen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // De ThreeDFormat-eigenschappen van de vorm instellen.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // De presentatie opslaan als een PPTX‑bestand.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Het 3D‑schuineffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑rotatie‑effecten toe te passen op vormen door de eigenschappen van hun [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/) te configureren.

Om 3D‑rotatie toe te passen op een vorm:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Gebruik [setCameraType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/camera/#setCameraType) en [setLightType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/lightrig/#setLightType) om de 3D‑rotatie te definiëren.
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

    // Sla de presentatie op als een PPTX‑bestand.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart-wit weergave voor vormen beheren**

De methode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) specificeert hoe een individuele vorm wordt weergegeven wanneer een presentatie wordt bekeken of verwerkt in zwart‑wit‑modus. Het schakelt de zwart‑wit‑weergave niet zelf in en verandert de vulling, lijn of andere opmaak van de vorm niet in de normale kleermodus.

Gebruik een waarde uit de enumeratie [BlackWhiteMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/blackwhitemode/) om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de weergave‑applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijze kleur, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` dwingen één kleur, `Color` behoudt de normale kleur, en `Hidden` laat de vorm weg in zwart‑wit‑modus. `NotDefined` betekent dat er geen vorm‑specifieke modus is toegewezen.

De volgende JavaScript‑code maakt een gekleurde vorm en laat deze grijs verschijnen in de zwart‑wit‑weergavemodus:

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

In de normale kleermodus behoudt de rechthoek zijn oranje vulling. In een zwart‑wit‑weergave‑workflow gebruikt hij grijze kleur omdat de modus is ingesteld op `Gray`. Hiermee kun je een dia in volledige kleur behouden terwijl je een andere weergave definieert voor afdrukken, voorvertonen of andere workflows die de zwart‑wit‑instellingen van de presentatie respecteren.

## **Opmaak herstellen**

De volgende JavaScript‑code toont hoe je de opmaak van een dia kunt herstellen en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Reset elke vorm op de dia die een placeholder op de lay-out heeft.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Heeft vormopmaak invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingesloten afbeeldingen en media nemen het grootste deel van de bestandsruimte in beslag, terwijl vorm‑parameters zoals kleuren, effecten en verlopen als metagegevens worden opgeslagen en praktisch geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vulling, lijn en effectinstellingen. Als alle overeenkomstige waarden gelijk zijn, beschouw je de stijlen als identiek en groepeer je die vormen logisch, wat later beheer van stijlen vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Bewaar voorbeeldvormen met de gewenste stijlen in een sjabloondeck of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie open je het sjabloon, kloon je de gewenste gestylede vormen en pas je hun opmaak opnieuw toe waar nodig.