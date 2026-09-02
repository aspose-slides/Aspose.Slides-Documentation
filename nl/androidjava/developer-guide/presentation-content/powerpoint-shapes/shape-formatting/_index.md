---
title: Opmaak PowerPoint‑vormen op Android
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/androidjava/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets effect
- schets lijn van vorm
- aansluitstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- transparantie van vorm
- vorm roteren
- 3D‑schuineffect
- 3D‑rotatie‑effect
- opmaak resetten
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint‑vormen op Android kunt opmaken met Aspose.Slides—stelt vullings-, lijn- en effectstijlen in voor PPT‑, PPTX‑ en ODP‑bestanden met precisie en volledige controle."
---
## **Introductie**

In PowerPoint kun je vormen toevoegen aan dia's. Omdat vormen bestaan uit lijnen, kun je de opmaak aanpassen door de omtrek te wijzigen of er effecten op toe te passen. Bovendien kun je de vulling van de vormen opmaken door instellingen te specificeren die bepalen hoe de binnenkant wordt gevuld.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java biedt interfaces en methoden waarmee je vormen kunt opmaken met dezelfde opties als in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm specificeren. De volgende stappen beschrijven de werkwijze:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [line style](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende code toont hoe je een rechthoekige `AutoShape` kunt opmaken:

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haalt de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voegt een auto-vorm van het type Rechthoek toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Stelt de vulkleur in voor de rechthoek-vorm.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Past de opmaak toe op de lijnen van de rechthoek.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Stelt de kleur in voor de lijn van de rechthoek.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Slaat het PPTX-bestand op naar schijf.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The formatted lines in the presentation](formatted-lines.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect zorgt ervoor dat een vormlijn er handgetekend uitziet. Gebruik [IShape.getLineFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) om toegang te krijgen tot de lijninstellingen, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilineformat/) voor de schetsinstellingen en [ISketchFormat.setSketchType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isketchformat/) om een waarde uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/linesketchtype/) te selecteren.

De volgende Java‑code laat zien hoe je een [LineSketchType.Curved](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde uitleest en het effect verwijdert met [LineSketchType.None](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Toegang tot de lijnopmaak van de vorm en de schets‑opmaak.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Pas een schets‑effect toe.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Lees het schets‑effect dat rechtstreeks aan de vorm is toegewezen.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Verwijder het schets‑effect.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

De waarde die wordt geretourneerd door [ISketchFormat.getSketchType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isketchformat/) vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, master‑dia of lay‑dia, gebruik dan [ILineFormat.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilineformat/), krijg toegang tot [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilineformateffectivedata/), en lees [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isketchformateffectivedata/). De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat de overerving is verwerkt:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Aansluitstijlen opmaken**

Hier zijn de drie opties voor het type aansluiting:

* Rond
* Miter
* Schuin

Standaard gebruikt PowerPoint de **Rond**‑instelling wanneer twee lijnen onder een hoek (bijvoorbeeld op de hoek van een vorm) worden samengevoegd. Als je echter een vorm met scherpe hoeken tekent, kun je de **Miter**‑optie verkiezen.

![The join style in the presentation](join-style-powerpoint.png)

De volgende Java‑code toont hoe drie rechthoeken (zoals weergegeven op de afbeelding hierboven) werden gemaakt met de Miter‑, Schuin‑ en Rond‑aansluittypes:

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg drie auto-vormen van het type Rechthoek toe.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Stel de vulkleur in voor elke rechthoek-vorm.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Stel de lijndikte in.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Stel de kleur in voor de lijn van elke rechthoek.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Stel de aansluitstijl in.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Voeg tekst toe aan elke rechthoek.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie waarmee je een continue mengeling van kleuren op een vorm kunt toepassen. Je kunt bijvoorbeeld twee of meer kleuren gebruiken zodat de ene geleidelijk in de andere overloopt.

Zo pas je een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Gradient`.
1. Voeg je twee gewenste kleuren toe met gedefinieerde posities via de `add`‑methoden van de gradient‑stop‑collectie die wordt blootgesteld door de [IGradientFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/igradientformat/)‑interface.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Java‑code demonstreert hoe je een verloopvulling op een ellips toepast:

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-vorm van het type Ellips toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Pas een verloop‑opmaak toe op de ellips.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Stel de richting van het verloop in.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Voeg twee verloop‑stops toe.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The ellipse with gradient fill](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, schuin kruislijnen of ruiten—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voorgrond en de achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te verhogen. Zelfs nadat je een vooraf gedefinieerd patroon hebt gekozen, kun je de exacte kleuren specificeren die moeten worden gebruikt.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/patternformat/#getBackColor--) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/patternformat/#getForeColor--) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Java‑code demonstreert hoe je een patroonvulling op een rechthoek toepast:

```java
// Instantieer de Presentation-klasse die een presentatie‑bestand voorstelt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto‑vorm van het type Rechthoek toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Patroon.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Stel de patroonstijl in.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Stel de achtergrond‑ en voorgrondkleuren van het patroon in.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Sla het PPTX‑bestand op naar schijf.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The rectangle with pattern fill](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt invoegen—de afbeelding fungeert dan als achtergrond van de vorm.

Zo gebruik je Aspose.Slides om een afbeeldingvulling op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Picture`.
1. Stel de afbeeldingsvullingsmodus in op `Tile` (of een andere gewenste modus).
1. Maak een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/)‑object aan van de afbeelding die je wilt gebruiken.
1. Geef de afbeelding door aan de `ISlidesPicture.setImage`‑methode.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Stel dat we een bestand “lotus.png” hebben met de volgende afbeelding:

![The lotus picture](lotus.png)

De volgende Java‑code laat zien hoe je een vorm vult met de afbeelding:

```java
// Instantieer de Presentation-klasse die een presentatie‑bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto‑vorm van het type Rechthoek toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Stel het vultype in op Afbeelding.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Stel de afbeeldingsvullingsmodus in.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Laad een afbeelding en voeg deze toe aan de presentatie‑bronnen.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Stel de afbeelding in.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Sla het PPTX‑bestand op naar schijf.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The shape with picture fill](picture-fill.png)

### **Afbeelding in tegelpatroon als textuur**

Wil je een getegelde afbeelding als textuur instellen en het tegelgedrag aanpassen, gebruik dan de volgende methoden van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/)‑interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/picturefillformat/)‑klasse:

- [setPictureFillMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Stelt de afbeeldingsvullingsmodus in—`Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Bepaalt de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Regelt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.
- [setTileOffsetX](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definieert de horizontale schaal van de tegel als een percentage.
- [setTileScaleY](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definieert de verticale schaal van de tegel als een percentage.

De volgende codevoorbeelden tonen hoe je een rechthoekige vorm met een getegelde afbeeldingvulling toevoegt en de tegelopties configureert:

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Voeg een auto-vorm van het type Rechthoek toe.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Stel het vultype van de vorm in op Afbeelding.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Laad de afbeelding en voeg deze toe aan de presentatie-bronnen.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Ken de afbeelding toe aan de vorm.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configureer de afbeeldingsvullingsmodus en tegel-eigenschappen.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The tile options](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm vult met één enkele, uniforme kleur. Deze eenvoudige achtergrondkleur wordt toegepast zonder verloop, textuur of patroon.

Om een effen kleurvulling op een vorm toe te passen met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Solid`.
1. Wijs je gewenste vulkleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Java‑code laat zien hoe je een effen kleurvulling op een rechthoek in een PowerPoint‑dia toepast:

```java
// Instantieer de Presentation-klasse die een presentatie‑bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto‑vorm van het type Rechthoek toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Stel de vulkleur in.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Sla het PPTX‑bestand op naar schijf.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The shape with solid color fill](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, naast een effen kleur, een verloop, afbeelding of textuur vulling, ook een transparantieniveau instellen om de doorzichtigheid van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm doorzichtiger, zodat de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides stelt je in staat de transparantiewaarde aan te passen door de alfa‑component van de gebruikte vulkleur te wijzigen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color` om een kleur met transparantie te definiëren (de `alpha`‑component regelt de transparantie).
1. Sla de presentatie op.

De volgende Java‑code demonstreert hoe je een transparante vulkleur op een rechthoek toepast:

```java
// Instantieer de Presentation-klasse die een presentatie‑bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een solide rechthoekige auto‑vorm toe.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoekige auto‑vorm toe boven de solide vorm.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Sla het PPTX‑bestand op naar schijf.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The transparent shape](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides maakt het mogelijk om vormen in PowerPoint‑presentaties te roteren. Dit is handig bij het positioneren van visuele elementen met specifieke uitlijning‑ of ontwerpeisen.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

De volgende Java‑code toont hoe je een vorm 5 graden roteert:

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-vorm van het type Rechthoek toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Roteer de vorm met 5 graden.
    shape.setRotation(5);

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The shape rotation](shape-rotation.png)

## **3D‑schuineffecten toevoegen**

Aspose.Slides stelt je in staat om 3D‑schuineffecten op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑schuineffecten aan een vorm toe te voegen, volg je deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Configureer de vorm‑[ThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/threedformat/) om de schuineinstellingen te definiëren.
1. Sla de presentatie op.

De volgende Java‑code laat zien hoe je 3D‑schuineffecten op een vorm toepast:

```java
// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een vorm toe aan de dia.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Stel de ThreeDFormat-eigenschappen van de vorm in.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Sla de presentatie op als een PPTX-bestand.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑rotatie‑effecten op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Gebruik [setCameraType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icamera/#setCameraType-int-) en [setLightType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

De volgende Java‑code demonstreert hoe je 3D‑rotatie‑effecten op een vorm toepast:

```java
// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Sla de presentatie op als een PPTX-bestand.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The 3D rotation effect](3D-rotation-effect.png)

## **Opmaak resetten**

De volgende Java‑code toont hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/layoutslide/) terugzet naar de standaardinstellingen:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Reset elke vorm op de dia die een placeholder op de layout heeft.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Heeft de opmaak van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingesloten afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en vrijwel geen extra ruimte kosten.

**Hoe kan ik vormen op een dia detecteren die dezelfde opmaak hebben zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vulling, lijn en effectinstellingen. Als alle overeenkomstige waarden gelijk zijn, beschouw je hun stijlen als identiek en kun je die vormen logisch groeperen, wat later het stijlbeheer vereenvoudigt.

**Kan ik een reeks aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloondia‑set of een .POTX‑sjabloonbestand. Wanneer je een nieuwe presentatie maakt, open je de sjabloon, kloon je de benodigde gestylede vormen en pas je hun opmaak toe waar nodig.