---
title: Vormopmaak van PowerPoint-vormen in Java
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- samenvoegstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- vorm roteren
- 3D-kantelfeffect
- 3D-rotatieeffect
- opmaak resetten
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen in Java kunt opmaken met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Introductie**

In PowerPoint kunt u vormen toevoegen aan dia's. Aangezien vormen bestaan uit lijnen, kunt u ze opmaken door de omlijning te wijzigen of er effecten op toe te passen. Daarnaast kunt u vormen opmaken door instellingen op te geven die bepalen hoe de binnenkant wordt gevuld.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java biedt interfaces en methoden die u in staat stellen vormen te formatteren met dezelfde opties als beschikbaar in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kunt u een aangepast lijnstijl voor een vorm opgeven. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [lijnstijl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/linestyle/) van de vorm in.
5. Stel de lijndikte in.
6. Stel de [streepstijl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/linedashstyle/) van de lijn in.
7. Stel de lijnkleur in voor de vorm.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende code toont hoe u een rechthoek `AutoShape` kunt opmaken:

```java
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een automatische vorm van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Stel de vulkleur in voor de rechthoekvorm.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Pas opmaak toe op de lijnen van de rechthoek.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Stel de kleur in voor de lijn van de rechthoek.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Sla het PPTX‑bestand op schijf.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De geformatteerde lijnen in de presentatie](formatted-lines.png)

## **Samenvoegstijlen opmaken**

Dit zijn de drie opties voor samenvoegtype:

* Rond
* Miter
* Afgeschuind

Standaard, wanneer PowerPoint twee lijnen aan een hoek (bijvoorbeeld bij een hoek van een vorm) samenvoegt, gebruikt het de instelling **Rond**. Als u echter een vorm met scherpe hoeken tekent, geeft u wellicht de voorkeur aan de **Miter**‑optie.

![De samenvoegstijl in de presentatie](join-style-powerpoint.png)

De volgende Java‑code toont hoe drie rechthoeken (zoals weergegeven in de afbeelding hierboven) zijn gemaakt met de Miter‑, Bevel‑ en Round‑instellingen voor het samenvoegtype:

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg drie automatische vormen van het type Rectangle toe.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Stel de vulkleur in voor elke rechthoekvorm.
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

    // Stel de samenvoegstijl in.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Voeg tekst toe aan elke rechthoek.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Sla het PPTX-bestand op schijf.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie waarmee u een continue kleurverloop op een vorm kunt toepassen. U kunt bijvoorbeeld twee of meer kleuren toepassen zodat de ene geleidelijk in de andere overloopt.

Zo past u een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de vorm in op `Gradient`.
5. Voeg uw twee gewenste kleuren toe met gedefinieerde posities via de `add`‑methoden van de gradient‑stop‑collectie die door de [IGradientFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/igradientformat/) interface wordt blootgesteld.
6. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een automatische vorm van het type Ellipse toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Pas een verloop-opmaak toe op de ellips.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Stel de richting van het verloop in.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Voeg twee verloopstops toe.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Sla het PPTX-bestand op schijf.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De ellips met verloopvulling:

![De ellips met verloopvulling](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee u een tweekleurig ontwerp—zoals stippen, strepen, kruisstrepen of ruiten—op een vorm kunt toepassen. U kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die u op vormen kunt toepassen om de visuele aantrekkingskracht van uw presentaties te vergroten. Zelfs na het kiezen van een vooraf gedefinieerd patroon kunt u de exacte kleuren specifiëren die moeten worden gebruikt.

Zo past u een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de vorm in op `Pattern`.
5. Kies een patroonstijl uit de vooraf gedefinieerde opties.
6. Stel de [Background Color](https://reference.aspose.com/slides/nl/java/com.aspose.slides/patternformat/#getBackColor--) van het patroon in.
7. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/java/com.aspose.slides/patternformat/#getForeColor--) van het patroon in.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een automatische vorm van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Stel de patroonstijl in.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Stel de achtergrond- en voorgrondkleuren van het patroon in.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Sla het PPTX-bestand op schijf.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De rechthoek met patroonvulling:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee u een afbeelding in een vorm kunt invoegen—de afbeelding wordt daarmee effectief als achtergrond van de vorm gebruikt.

Zo gebruikt u Aspose.Slides om een afbeeldingvulling toe te passen op een vorm:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de vorm in op `Picture`.
5. Stel de modus voor afbeeldingvulling in op `Tile` (of een andere gewenste modus).
6. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) object aan van de afbeelding die u wilt gebruiken.
7. Geef de afbeelding door aan de `ISlidesPicture.setImage`‑methode.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Stel dat we een bestand "lotus.png" hebben met de volgende afbeelding:

![De lotusafbeelding](lotus.png)

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een automatische vorm van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Stel het vultype in op Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Stel de afbeeldingvullingsmodus in.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Laad een afbeelding en voeg deze toe aan de presentatieresources.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Stel de afbeelding in.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Sla het PPTX-bestand op schijf.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De vorm met afbeeldingvulling:

![De vorm met afbeeldingvulling](picture-fill.png)

### **Afbeelding als tegel gebruiken**

Als u een afbeelding als tegel wilt gebruiken als textuur en het tegelgedrag wilt aanpassen, kunt u de volgende methoden van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/) interface en [PictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/picturefillformat/) klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Stelt de modus voor afbeeldingvulling in—`Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Bepaalt de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Bepaalt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.
- [setTileOffsetX](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definieert de horizontale schaal van de tegel als een percentage.
- [setTileScaleY](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definieert de verticale schaal van de tegel als een percentage.

De volgende code laat zien hoe u een rechthoekvorm met een tegel‑afbeeldingsvulling toevoegt en de tegelopties configureert:

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Voeg een rechthoek-automatische vorm toe.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Stel het vultype van de vorm in op Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Laad de afbeelding en voeg deze toe aan de presentatieresources.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Wijs de afbeelding toe aan de vorm.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configureer de afbeeldingvullingsmodus en tegel-eigenschappen.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Sla het PPTX-bestand op schijf.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De tegelopties:

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm vult met één enkele, egaal gekleurde achtergrond. Deze eenvoudige achtergrondkleur wordt toegepast zonder verlopen, texturen of patronen.

Om een effen kleurvulling toe te passen op een vorm met Aspose.Slides, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de vorm in op `Solid`.
5. Wijs de gewenste vulkleur toe aan de vorm.
6. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een automatische vorm van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Stel de vulkleur in.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Sla het PPTX-bestand op schijf.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De vorm met effen kleurvulling:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kunt u, wanneer u een effen kleur, verloop, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de doorzichtigheid van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, zodat de achtergrond of onderliggende objecten gedeeltelijk zichtbaar blijven.

Aspose.Slides laat u het transparantieniveau instellen door de alfa‑waarde van de kleur die voor de vulling wordt gebruikt aan te passen. Zo doet u dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) in op `Solid`.
5. Gebruik `Color` om een kleur met transparantie te definiëren (de `alpha`‑component bepaalt de transparantie).
6. Sla de presentatie op.

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een solide rechthoek-auto-vorm toe.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een doorzichtige rechthoek-auto-vorm toe bovenop de solide vorm.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Sla het PPTX-bestand op schijf.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De transparante vorm:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Met Aspose.Slides kunt u vormen roteren in PowerPoint‑presentaties. Dit kan nuttig zijn bij het positioneren van visuele elementen met specifieke uitlijnings‑ of ontwerpeisen.

Om een vorm op een dia te roteren, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
5. Sla de presentatie op.

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een automatische vorm van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Roteer de vorm met 5 graden.
    shape.setRotation(5);

    // Sla het PPTX-bestand op schijf.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De rotatie van de vorm:

![De rotatie van de vorm](shape-rotation.png)

## **3D‑kantelfeffecten toevoegen**

Met Aspose.Slides kunt u 3D‑kantelfeffecten op vormen toepassen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑kantelfeffecten toe te voegen aan een vorm, volgt u deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/threedformat/) van de vorm om kantelinstellingen te definiëren.
5. Sla de presentatie op.

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

Het 3D‑kantelfeffect:

![Het 3D‑kantelfeffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Met Aspose.Slides kunt u 3D‑rotatie‑effecten op vormen toepassen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑rotatie toe te passen op een vorm:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Gebruik de [setCameraType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icamera/#setCameraType-int-) en [setLightType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilightrig/#setLightType-int-) om de 3D‑rotatie te definiëren.
5. Sla de presentatie op.

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

Het 3D‑rotatie‑effect:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Opmaak resetten**

De volgende Java‑code laat zien hoe u de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met plaatshouders op de [LayoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/layoutslide/) terugzet naar de standaardinstellingen:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Reset elke vorm op de dia die een plaatshouder op de lay-out heeft.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Heeft het opmaken van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingesloten afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en vrijwel geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben, zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vulling, lijn en effectinstellingen. Als alle overeenkomende waarden gelijk zijn, beschouw dan hun stijlen als identiek en groepeer die vormen logisch, wat later beheer van stijlen vereenvoudigt.

**Kan ik een reeks aangepaste vormstijlen opslaan in een apart bestand om ze later in andere presentaties te hergebruiken?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloon‑presentatie of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie opent u het sjabloon, kloont u de benodigde gestileerde vormen en past u hun opmaak opnieuw toe waar nodig.