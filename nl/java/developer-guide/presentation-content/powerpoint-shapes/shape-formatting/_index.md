---
title: PowerPoint-vormen opmaken in Java
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets-effect
- schetsvormlijn
- koppelingsstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- egale kleurvulling
- vormtransparantie
- zwart-wit vormweergave
- grijswaarden vormweergave
- vorm roteren
- 3D-bisel-effect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen in Java kunt opmaken met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Introductie**

In PowerPoint kun je vormen aan dia's toevoegen. Omdat vormen bestaan uit lijnen, kun je ze opmaken door de omtrek te wijzigen of effecten toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![indeling-vorm-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java biedt interfaces en methoden die je in staat stellen vormen op te maken met dezelfde opties die beschikbaar zijn in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepast lijnstijl voor een vorm opgeven. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [line style](https://reference.aspose.com/slides/nl/java/com.aspose.slides/linestyle/) van de vorm in.
5. Stel de lijndikte in.
6. Stel de [dash style](https://reference.aspose.com/slides/nl/java/com.aspose.slides/linedashstyle/) van de lijn in.
7. Stel de lijnekleur voor de vorm in.
8. Sla de gewijzigde presentatie op als een PPTX-bestand.

De volgende code laat zien hoe je een rechthoek-`AutoShape` opmaakt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-vorm van het type Rectangle toe.
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

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets-effecten toepassen op vormlijnen**

Een schetseffect laat een vormlijn eruitzien alsof deze met de hand is getekend. Gebruik [IShape.getLineFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) om de lijninstellingen te benaderen, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilineformat/) om de schetstinstellingen te benaderen, en [ISketchFormat.setSketchType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isketchformat/) om een waarde uit de [LineSketchType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/linesketchtype/)‑enumeratie te selecteren.

De volgende Java-code toont hoe je een [LineSketchType.Curved](https://reference.aspose.com/slides/nl/java/com.aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde leest en het effect verwijdert met [LineSketchType.None](https://reference.aspose.com/slides/nl/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Toegang tot het lijnformaat van de vorm en het schetsformaat.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Pas een schetseffect toe.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Lees het schetseffect dat rechtstreeks aan de vorm is toegewezen.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Verwijder het schetseffect.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

De waarde die wordt geretourneerd door [ISketchFormat.getSketchType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isketchformat/) vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, masterdia of lay-outdia, gebruik dan [ILineFormat.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilineformat/), benader [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilineformateffectivedata/), en lees [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isketchformateffectivedata/). De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat de erfenis is opgelost:

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

## **Knoopstijlen opmaken**

Hier zijn de drie opties voor koppelingsstijlen:

- Rond
- Schuin
- Afschuind

Standaard, wanneer PowerPoint twee lijnen onder een hoek verbindt (bijvoorbeeld bij een hoek van een vorm), gebruikt het de **Rond**-instelling. Als je echter een vorm met scherpe hoeken tekent, kun je de **Schuin**-optie verkiezen.

![De koppelingsstijl in de presentatie](join-style-powerpoint.png)

De volgende Java-code laat zien hoe drie rechthoeken (zoals te zien op de afbeelding hierboven) werden gemaakt met de Schuin, Afschuind en Rond koppelingsinstellingen:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg drie auto-vormen van het type Rectangle toe.
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

    // Stel de koppelingsstijl in.
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

In PowerPoint is Verloopvulling een opmaakoptie waarmee je een continue mengeling van kleuren op een vorm kunt toepassen. Je kunt bijvoorbeeld twee of meer kleuren gebruiken zodat de ene geleidelijk overgaat in de andere.

Zo pas je een verloopvulling toe op een vorm met behulp van Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de vorm in op `Gradient`.
5. Voeg je twee gewenste kleuren met gedefinieerde posities toe met behulp van de `add`-methoden van de gradient-stop-collectie die wordt blootgesteld door de [IGradientFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/igradientformat/) interface.
6. Sla de gewijzigde presentatie op als een PPTX-bestand.

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-vorm van het type Ellipse toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Pas een verloopopmaak toe op de ellips.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Stel de richting van het verloop in.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Voeg twee verloopstops toe.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De ellips met verloopvulling](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee je een tweekleurig ontwerp - zoals stippen, strepen, kruissteek of dambord - op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voorgrond en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te verbeteren. Zelfs nadat je een vooraf gedefinieerd patroon hebt gekozen, kun je nog steeds de exacte kleuren opgeven die het moet gebruiken.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de vorm in op `Pattern`.
5. Kies een patroonstijl uit de vooraf gedefinieerde opties.
6. Stel de [Background Color](https://reference.aspose.com/slides/nl/java/com.aspose.slides/patternformat/#getBackColor--) van het patroon in.
7. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/java/com.aspose.slides/patternformat/#getForeColor--) van het patroon in.
8. Sla de gewijzigde presentatie op als een PPTX-bestand.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-vorm van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Stel de patroonstijl in.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Stel de achtergrond- en voorgrondkleuren van het patroon in.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt invoegen - waardoor de afbeelding effectief de achtergrond van de vorm vormt.

Zo gebruik je Aspose.Slides om een afbeeldingsvulling op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de vorm in op `Picture`.
5. Stel de afbeeldingsvullingsmodus in op `Tile` (of een andere gewenste modus).
6. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) object aan van de afbeelding die je wilt gebruiken.
7. Geef de afbeelding door aan de `ISlidesPicture.setImage`-methode.
8. Sla de gewijzigde presentatie op als een PPTX-bestand.

Stel dat we een bestand "lotus.png" hebben met de volgende afbeelding:

![De lotusafbeelding](lotus.png)

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-vorm van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Stel het vultype in op Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Stel de afbeeldingsvullingsmodus in.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Laad een afbeelding en voeg deze toe aan de presentatieresources.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Stel de afbeelding in.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Tegelafbeelding als textuur**

Als je een getegelde afbeelding wilt instellen als textuur en het tegelgedrag wilt aanpassen, kun je de volgende methoden van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/) interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/picturefillformat/) klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Stelt de afbeeldingsvullingsmodus in - `Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Bepaalt de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Bepaalt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.
- [setTileOffsetX](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definieert de horizontale schaal van de tegel als een percentage.
- [setTileScaleY](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definieert de verticale schaal van de tegel als een percentage.

De volgende codevoorbeeld toont hoe je een rechthoekvorm toevoegt met een getegelde afbeeldingsvulling en de tegelopties configureert:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Voeg een auto-rechthoekvorm toe.
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

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm vult met één enkele, egale kleur. Deze eenvoudige achtergrondkleur wordt toegepast zonder verlopen, texturen of patronen.

Om een egale kleurvulling op een vorm toe te passen met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de vorm in op `Solid`.
5. Wijs de gewenste vulkleur toe aan de vorm.
6. Sla de gewijzigde presentatie op als een PPTX-bestand.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-vorm van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Stel de vulkleur in.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De vorm met egale kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, wanneer je een egale kleur, verloop, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de opacity van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm doorzichtiger, waardoor de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides laat je het transparantieniveau instellen door de alfa-waarde van de gebruikte vulkleur aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) in op `Solid`.
5. Gebruik `Color` om een kleur met transparantie te definiëren (de `alpha`-component regelt de transparantie).
6. Sla de presentatie op.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een solide rechthoek auto-vorm toe.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoek auto-vorm toe boven de solide vorm.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De doorzichtige vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides stelt je in staat vormen te roteren in PowerPoint-presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning of ontwerpbehoeften.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Stel de rotatie-eigenschap van de vorm in op de gewenste hoek.
5. Sla de presentatie op.

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-vorm van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Roteer de vorm met 5 graden.
    shape.setRotation(5);

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D-bisel-effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D-bisel-effecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/threedformat/) eigenschappen te configureren.

Om 3D-bisel-effecten aan een vorm toe te voegen, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Configureer de [ThreeDFormat] van de vorm om de biselinstellingen te definiëren.
5. Sla de presentatie op.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Het resultaat:

![Het 3D-bisel-effect](3D-bevel-effect.png)

## **3D-rotatie-effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D-rotatie-effecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/threedformat/) eigenschappen te configureren.

Om 3D-rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan.
2. Haal een referentie naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Gebruik de [setCameraType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icamera/#setCameraType-int-) en [setLightType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilightrig/#setLightType-int-) om de 3D-rotatie te definiëren.
5. Sla de presentatie op.

```java
import com.aspose.slides.*;

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

Het resultaat:

![Het 3D-rotatie-effect](3D-rotation-effect.png)

## **Zwart-wit-weergave van vormen beheren**

De methode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) geeft aan hoe een individuele vorm wordt weergegeven wanneer een presentatie in zwart-wit-modus wordt bekeken of verwerkt. Het activeert de zwart-wit-weergave niet op zichzelf, en het verandert de vul-, lijn- of andere opmaak van de vorm niet in de normale kleurenmodus.

Gebruik een waarde uit de [BlackWhiteMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/blackwhitemode/) klasse om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de weergave-applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijze kleur, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` dwingen één kleur, `Color` behoudt de normale kleur, en `Hidden` laat de vorm weg in de zwart-wit-modus. `NotDefined` betekent dat er geen vorm-specifieke modus is toegewezen.

De volgende Java-code maakt een gekleurde vorm en laat deze grijs verschijnen in de zwart-wit-weergavemodus:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Houd de oranje vulling in kleurmodus, maar geef de vorm weer met grijze kleur in zwart-witmodus.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In de normale kleurenmodus behoudt de rechthoek zijn oranje vulling. In een zwart-wit-weergave-workflow gebruikt hij een grijze kleur omdat zijn modus is ingesteld op `Gray`. Dit stelt je in staat een dia in volledige kleur te behouden terwijl je een aparte weergave definieert voor afdrukken, voorvertonen of andere workflows die de zwart-wit-weergave-instellingen van de presentatie respecteren.

## **Opmaak resetten**

De volgende Java-code toont hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Reset elke vorm op de dia die een placeholder heeft op de lay-out.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Heeft de opmaak van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Enkel minimaal. Ingesloten afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vorm-parameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en vrijwel geen extra ruimte kosten.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak-eigenschappen van elke vorm - vul-, lijn- en effectinstellingen. Als alle bijbehorende waarden overeenkomen, beschouw dan hun stijlen als identiek en groepeer die vormen logisch, wat later het beheer van stijlen vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloon-presentatie of een .POTX-sjabloonbestand. Wanneer je een nieuwe presentatie maakt, open je het sjabloon, kloont je de benodigde gestylede vormen, en pas je hun opmaak opnieuw toe waar nodig.