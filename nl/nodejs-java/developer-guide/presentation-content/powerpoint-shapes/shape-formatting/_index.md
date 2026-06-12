---
title: PowerPoint-vormen opmaken in JavaScript
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/nodejs-java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- aansluitingstype opmaken
- gradientvulling
- patroonvulling
- afbeeldingvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- vorm roteren
- 3d schuineffect
- 3d rotatie‑effect
- opmaak resetten
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint‑vormen opmaken in JavaScript met Aspose.Slides—stel vullingen, lijnen en effectstijlen in voor PPT‑, PPTX‑ en ODP‑bestanden met nauwkeurigheid en volledige controle."
---
## **Introductie**

In PowerPoint kun je vormen toevoegen aan dia’s. Omdat vormen bestaan uit lijnen, kun je ze opmaken door de contouren te wijzigen of er effecten op toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe de binnenkant wordt gevuld.

![vorm-opmaken-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java biedt klassen en methoden waarmee je vormen kunt opmaken met dezelfde opties die in PowerPoint beschikbaar zijn.

## **Contouren opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm opgeven. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [line style](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende code laat zien hoe je een rechthoek‑`AutoShape` kunt opmaken:

```js
// Maak een instantie van de Presentation-klasse die een presentatiedocument vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-shape van het type Rectangle toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Stel de vulkleur in voor de rechthoek-shape.
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

![De opgemaakte contouren in de presentatie](formatted-lines.png)

## **Aansluitstijlen opmaken**

Hier zijn de drie opties voor het type aansluiting:

* Round
* Miter
* Bevel

Standaard, wanneer PowerPoint twee lijnen onder een hoek (bijvoorbeeld bij een hoek van een vorm) verbindt, wordt de instelling **Round** gebruikt. Als je echter een vorm met scherpe hoeken tekent, kun je de optie **Miter** verkiezen.

![De aansluitingstype‑stijl in de presentatie](join-style-powerpoint.png)

De volgende JavaScript‑code toont hoe drie rechthoeken (zoals te zien op de afbeelding hierboven) werden gemaakt met respectievelijk de Miter‑, Bevel‑ en Round‑instellingen:

```js
// Instantieer de Presentation-klasse die een presentatiedocument vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg drie auto‑shapes van het type Rectangle toe.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Stel de vulkleur in voor elke rechthoek‑shape.
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

    // Stel het aansluittype in.
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

## **Gradientvulling**

In PowerPoint is Gradient Fill een opmaakoptie waarmee je een vloeiende overgang van kleuren op een vorm kunt toepassen. Je kunt bijvoorbeeld twee of meer kleuren zo combineren dat de ene geleidelijk in de andere overloopt.

Zo pas je een gradientvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) in op `Gradient`.
1. Voeg je twee gewenste kleuren met gedefinieerde posities toe via de `add`‑methoden van de gradient‑stop‑collectie die beschikbaar is via de [GradientFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/gradientformat/)‑klasse.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende JavaScript‑code laat zien hoe je een gradientvulling toepast op een ellips:

```js
// Instantieer de Presentation-klasse die een presentatiedocument vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto‑shape van het type Ellipse toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Pas gradientopmaak toe op de ellips.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Stel de richting van de gradient in.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Voeg twee gradientstops toe.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Sla het PPTX‑bestand op schijf.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De ellips met gradientvulling](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Pattern Fill een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, dwarsstrepen of geruite patronen—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor zowel de voorgrond als de achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om je presentaties visueel aantrekkelijker te maken. Zelfs nadat je een vooraf gedefinieerd patroon hebt gekozen, kun je nog steeds de exacte kleuren opgeven die moeten worden gebruikt.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/patternformat/#getBackColor--) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/patternformat/#getForeColor--) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende JavaScript‑code toont hoe je een patroonvulling toepast op een rechthoek:

```js
// Instantieer de Presentation-klasse die een presentatiedocument vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto‑shape van het type Rectangle toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Stel de patroonstijl in.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Stel de achtergrond‑ en voorgrondkleur van het patroon in.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Sla het PPTX‑bestand op schijf.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Picture Fill een opmaakoptie waarmee je een afbeelding in een vorm kunt invoegen—de afbeelding wordt daardoor de achtergrond van de vorm.

Zo gebruik je Aspose.Slides om een afbeeldingvulling op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) in op `Picture`.
1. Stel de picture‑fill‑modus in op `Tile` (of een andere gewenste modus).
1. Maak een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/)‑object aan van de afbeelding die je wilt gebruiken.
1. Geef de afbeelding door aan de `ISlidesPicture.setImage`‑methode.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Stel, we hebben een bestand “lotus.png” met de volgende afbeelding:

![De lotus‑afbeelding](lotus.png)

De volgende JavaScript‑code laat zien hoe je een vorm vult met de afbeelding:

```js
// Instantieer de Presentation-klasse die een presentatiedocument vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto‑shape van het type Rectangle toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Stel het vultype in op Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Stel de picture‑fill‑modus in.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Laad een afbeelding en voeg deze toe aan de presentatie‑resources.
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

Het resultaat:

![De vorm met afbeeldingvulling](picture-fill.png)

### **Afbeelding als tegel gebruiken**

Als je een getegelde afbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kun je de volgende methoden van de [PictureFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/)‑klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Stelt de picture‑fill‑modus in—`Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Bepaalt de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Bepaalt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.
- [setTileOffsetX](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definieert de horizontale schaal van de tegel als percentage.
- [setTileScaleY](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definieert de verticale schaal van de tegel als percentage.

De volgende code‑voorbeeld toont hoe je een rechthoek‑vorm met een getegelde afbeeldingvulling toevoegt en tegelopties configureert:

```js
// Instantieer de Presentation‑klasse die een presentatiedocument vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Voeg een rechthoek‑auto‑shape toe.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Stel het vultype van de shape in op Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Laad de afbeelding en voeg deze toe aan de presentatie‑resources.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Wijs de afbeelding toe aan de shape.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configureer de picture‑fill‑modus en de tegel‑eigenschappen.
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

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Solid Color Fill een opmaakoptie die een vorm vult met één enkele, uniforme kleur. Deze egale achtergrondkleur wordt toegepast zonder gradaties, texturen of patronen.

Om een effen kleurvulling op een vorm toe te passen met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) in op `Solid`.
1. Wijs je gewenste vulkleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende JavaScript‑code laat zien hoe je een effen kleurvulling toepast op een rechthoek in een PowerPoint‑dia:

```js
// Instantieer de Presentation‑klasse die een presentatiedocument vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto‑shape van het type Rectangle toe.
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

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, wanneer je een effen kleur, gradient, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de dekking van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm doorzichtiger, zodat de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides stelt je in staat het transparantieniveau in te stellen door de alfa‑waarde van de gebruikte vulkleur aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color` om een kleur met transparantie te definiëren (de `alpha`‑component regelt de transparantie).
1. Sla de presentatie op.

De volgende JavaScript‑code toont hoe je een transparante vulkleur toepast op een rechthoek:

```js
// Instantieer de Presentation‑klasse die een presentatiedocument vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een solide rechthoek‑auto‑shape toe.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoek‑auto‑shape toe boven de solide shape.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Sla het PPTX‑bestand op schijf.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides stelt je in staat vormen te roteren in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning‑ of ontwerpeisen.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

De volgende JavaScript‑code laat zien hoe je een vorm met 5 graden roteert:

```js
// Instantieer de Presentation-klasse die een presentatiedocument vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op.
    let slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-shape van het type Rectangle toe.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Roteer de shape met 5 graden.
    shape.setRotation(5);

    // Sla het PPTX-bestand op schijf.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De rotatie van de vorm](shape-rotation.png)

## **3D‑Schuineffecten toevoegen**

Aspose.Slides maakt het mogelijk 3D‑schuineffecten op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑schuineffecten aan een vorm toe te voegen, volg je deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Configureer het [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/) van de vorm om schuine instellingen te definiëren.
1. Sla de presentatie op.

De volgende JavaScript‑code laat zien hoe je 3D‑schuineffecten op een vorm toepast:

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

    // Stel de ThreeDFormat‑eigenschappen van de vorm in.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Sla de presentatie op als een PPTX‑bestand.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![Het 3D‑schuineffect](3D-bevel-effect.png)

## **3D‑Rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk 3D‑rotatie‑effecten op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) toe aan de dia.
1. Gebruik [setCameraType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/camera/#setCameraType) en [setLightType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/lightrig/#setLightType) om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

De volgende JavaScript‑code toont hoe je 3D‑rotatie‑effecten op een vorm toepast:

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

    // Sla de presentatie op als een PPTX‑bestand.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Opmaak resetten**

De volgende Java‑code laat zien hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/) terugzet naar de standaardinstellingen:

```js
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

**Heeft het opmaken van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingesloten afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vorm‑parameters zoals kleuren, effecten en gradients als metadata worden opgeslagen en praktisch geen extra ruimte kosten.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vulling, lijn en effectinstellingen. Als alle overeenkomstige waarden gelijk zijn, beschouw je de stijlen als identiek en groepeer je die vormen logisch, wat later beheer van stijlen vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand om ze in andere presentaties te hergebruiken?**

Ja. Bewaar voorbeeld‑vormen met de gewenste stijlen in een sjabloon‑presentatie of een .POTX‑bestand. Wanneer je een nieuwe presentatie maakt, open je het sjabloon, kloon je de benodigde gestileerde vormen en pas je hun opmaak opnieuw toe waar nodig.