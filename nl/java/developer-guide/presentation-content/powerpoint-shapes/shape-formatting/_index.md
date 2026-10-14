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
- aansluitstijl opmaken
- gradiëntvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- enkele kleurvulling
- vormtransparantie
- zwart-wit weergave van vormen
- grijswaarde weergave van vormen
- vorm roteren
- 3D-afschuindeffect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen kunt opmaken in Java met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Introductie**

In PowerPoint kun je vormen aan dia's toevoegen. Aangezien vormen bestaan uit lijnen, kun je ze opmaken door de omtreklijnen aan te passen of er effecten op toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides voor Java biedt interfaces en methoden die je in staat stellen vormen te formatteren met dezelfde opties die in PowerPoint beschikbaar zijn.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm opgeven. De volgende stappen geven de procedure weer:

1. Maak een instantie van de class [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [line style](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende code toont hoe je een rechthoek `AutoShape` kunt opmaken:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
        // Haal de eerste dia op.
        ISlide slide = presentation.getSlides().get_Item(0);

        // Voeg een autoshape van het type Rechthoek toe.
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

Een schetseffect laat een vormlijn eruitzien alsof deze met de hand is getekend. Gebruik [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) om de lijninstellingen te benaderen, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) om de schetinstellingen te benaderen, en [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) om een waarde uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) te selecteren.

De volgende Java‑code laat zien hoe je een [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) effect toepast, de expliciet toegewezen waarde uitleest, en het effect verwijdert met [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Toegang tot het lijnformaat van de vorm en het schetsformaat.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Pas een schetseffect toe.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Lees het schetseffect dat direct aan de vorm is toegewezen.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Verwijder het schetseffect.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

De waarde die wordt geretourneerd door [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) vertegenwoordigt de instelling die direct aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, meester‑dia of lay‑outdia, gebruik dan [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/), haal [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/) op, en lees [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/). De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat erfenis is opgelost:

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

Hier zijn de drie opties voor aansluittype:

* Rond
* Miter
* Afgeschuind

Standaard, wanneer PowerPoint twee lijnen onder een hoek (bijvoorbeeld bij de hoek van een vorm) verbindt, gebruikt het de **Rond**‑instelling. Als je echter een vorm met scherpe hoeken tekent, kun je de **Miter**‑optie verkiezen.

![De aansluitstijl in de presentatie](join-style-powerpoint.png)

De volgende Java‑code toont hoe drie rechthoeken (zoals in de afbeelding hierboven) werden gemaakt met de Miter‑, Bevel‑ en Rond‑aansluittype‑instellingen:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg drie autoshapes van het type Rechthoek toe.
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

## **Gradiëntvulling**

In PowerPoint is Gradiëntvulling een opmaakoptie waarmee je een doorlopende kleurverloop op een vorm kunt toepassen. Je kunt bijvoorbeeld twee of meer kleuren toepassen zodat de ene geleidelijk in de andere overvloeit.

Zo pas je een gradiëntvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de class [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) van de vorm in op `Gradient`.
1. Voeg je twee gewenste kleuren met gedefinieerde posities toe met behulp van de `add`‑methoden van de gradient‑stop‑collectie die via de interface [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/) wordt blootgesteld.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een autosvorm van het type Ellipse toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Pas een gradiëntopmaak toe op de ellips.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Stel de richting van de gradiënt in.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Voeg twee gradiëntstops toe.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De ellips met gradiëntvulling](gradient-fill.png)

Als een gradiënt er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, raadpleeg dan [Choose a Gradient Rendering Style](/slides/nl/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Je kunt een weergavestijl kiezen zonder de in de presentatie opgeslagen gradiëntvulling te wijzigen.

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, kruishatching of damborden—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te vergroten. Ook na het kiezen van een vooraf gedefinieerd patroon kun je nog steeds de exacte kleuren opgeven die het moet gebruiken.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de class [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) van de vorm in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een autosvorm van het type Rechthoek toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Patroon.
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

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt invoegen—effectief de afbeelding als achtergrond van de vorm gebruiken.

Zo gebruik je Aspose.Slides om een afbeeldingsvulling toe te passen op een vorm:

1. Maak een instantie van de class [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) van de vorm in op `Picture`.
1. Stel de afbeeldingsvullingsmodus in op `Tile` (of een andere gewenste modus).
1. Maak een [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)‑object aan van de afbeelding die je wilt gebruiken.
1. Geef de afbeelding door aan de methode `ISlidesPicture.setImage`.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

![De lotusafbeelding](lotus.png)

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een autosvorm van het type Rechthoek toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Stel het vultype in op Afbeelding.
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

### **Afbeelding in tegelvorm als textuur**

Als je een tegelafbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kun je de volgende methoden van de interface [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) en de klasse [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Stelt de afbeeldingsvullingsmodus in—ofwel `Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Specificeert de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Bepaalt of de tegel horizontaal, verticaal of beide keer wordt gespiegeld.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Stelt de horizontale offset van de tegel (in punten) vanaf de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Stelt de verticale offset van de tegel (in punten) vanaf de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definieert de horizontale schaal van de tegel als percentage.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definieert de verticale schaal van de tegel als percentage.

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Voeg een rechthoekige autosvorm toe.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Stel het vultype van de vorm in op Afbeelding.
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

    // Sla het PPTX-bestand op naar schijf.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Enkele kleurvulling**

In PowerPoint is Enkele kleurvulling een opmaakoptie die een vorm vult met één enkele, egale kleur. Deze eenvoudige achtergrondkleur wordt toegepast zonder gradiënten, texturen of patronen.

Om een enkele kleurvulling toe te passen op een vorm met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de class [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) van de vorm in op `Solid`.
1. Wijs je gewenste vulkleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een autosvorm van het type Rechthoek toe.
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

![De vorm met enkele kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, wanneer je een enkele kleur, gradiënt, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de ondoorzichtigheid van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, waardoor de achtergrond of onderliggende objecten deels zichtbaar worden.

Aspose.Slides laat je het transparantieniveau instellen door de alfabeta‑waarde in de gebruikte vullingskleur aan te passen. Zo doe je dat:

1. Maak een instantie van de class [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color` om een kleur met transparantie te definiëren (de `alpha`‑component regelt de transparantie).
1. Sla de presentatie op.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een solide rechthoek autosvorm toe.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoek autosvorm toe boven de solide vorm.
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

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides maakt het mogelijk om vormen te roteren in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning of ontwerpbehoeften.

1. Maak een instantie van de class [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een autosvorm van het type Rechthoek toe.
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

## **3D-afgeschuindeffecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑afgeschuindeffecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/)‑eigenschappen te configureren.

1. Maak een instantie van de class [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) van de vorm om afschuinstellingen te definiëren.
1. Sla de presentatie op.

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

![Het 3D‑afgeschuindeffect](3D-bevel-effect.png)

## **3D-rotatie-effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑rotatie‑effecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/)‑eigenschappen te configureren.

1. Maak een instantie van de class [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) toe aan de dia.
1. Gebruik [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) en [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

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

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart‑wit weergave voor vormen regelen**

De methode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) specificeert hoe een individuele vorm wordt weergegeven wanneer een presentatie wordt bekeken of verwerkt in zwart‑wit‑modus. Het schakelt niet automatisch zwart‑wit‑weergave in en wijzigt de vulling, lijn of andere opmaak van de vorm niet in de normale kleurenmodus.

Gebruik een waarde uit de [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) klasse om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de renderende applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijze kleuring, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` dwingen één enkele kleur, `Color` behoudt de normale kleuring, en `Hidden` laat de vorm weg in zwart‑wit‑modus. `NotDefined` betekent dat er geen modus op vormniveau is toegewezen.

De volgende Java‑code maakt een gekleurde vorm en laat deze grijs verschijnen in de zwart‑wit‑weergavemodus:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Houd de oranje vulling in kleurmodus, maar geef de vorm weer met grijze kleur in zwart-wit modus.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In normale kleurmodus behoudt de rechthoek zijn oranje vulling. In een zwart‑wit‑weergave‑workflow gebruikt hij grijze kleuring omdat de modus is ingesteld op `Gray`. Hiermee kun je een volledig‑kleur slide behouden terwijl je een aparte weergave definieert voor afdrukken, voorvertonen of andere workflows die de zwart‑wit‑weergave‑instellingen van de presentatie respecteren.

## **Opmaak resetten**

De volgende Java‑code laat zien hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Reset elke vorm op de dia die een placeholder heeft in de lay-out.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Heeft het opmaken van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingevoegde afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en gradiënten als metadata worden opgeslagen en praktisch geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vul‑, lijn‑ en effectinstellingen. Als alle overeenkomstige waarden gelijk zijn, beschouw je hun stijlen als identiek en groepeer je die vormen logisch, wat later stijlbeheer vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand om later in andere presentaties te hergebruiken?**

Ja. Bewaar voorbeeldvormen met de gewenste stijlen in een templateslideshow of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie open je het sjabloon, kloon je de gestileerde vormen die je nodig hebt, en pas je hun opmaak opnieuw toe waar nodig.