---
title: PowerPoint-vormen op Android opmaken
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/androidjava/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schetseffect
- schets vormlijn
- koppelstijl opmaken
- verloopvulling
- patroontevulling
- afbeeldingsvulling
- textuurvulling
- effenkleurige vulling
- vormtransparantie
- zwart-wit vormweergave
- grijstint vormweergave
- vorm roteren
- 3D-inkepelingseffect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe je PowerPoint-vormen op Android kunt opmaken met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Inleiding**

In PowerPoint kun je vormen aan dia's toevoegen. Omdat vormen bestaan uit lijnen, kun je ze opmaken door de contouren te wijzigen of effecten toe te passen. Daarnaast kun je vormen opmaken door instellingen op te geven die bepalen hoe hun binnenkant wordt gevuld.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java biedt interfaces en methoden waarmee je vormen kunt opmaken met dezelfde opties als in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm opgeven. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse aan.  
1. Haal een referentie naar een dia op basis van de index.  
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.  
1. Stel de [line style](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/linestyle/) van de vorm in.  
1. Stel de lijndikte in.  
1. Stel de [dash style](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/linedashstyle/) van de lijn in.  
1. Stel de lijnkleur voor de vorm in.  
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende code toont hoe je een rechthoekige `AutoShape` kunt opmaken:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto shape van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Verwijder de vulling van de rechthoekvorm zodat alleen de lijnen zichtbaar zijn.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Pas opmaak toe op de lijnen van de rechthoek.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Stel de kleur in voor de lijn van de rechthoek.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Sla het PPTX-bestand op disk.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets-effecten toepassen op vormlijnen**

Een schets‑effect maakt een vormlijn handgetekend. Gebruik [IShape.getLineFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) om de lijninstellingen te benaderen, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilineformat/) om de schetsinstellingen te benaderen, en [ISketchFormat.setSketchType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isketchformat/) om een waarde uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/linesketchtype/) te selecteren.

De volgende Java‑code laat zien hoe je het [LineSketchType.Curved](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde uitleest, en het effect verwijdert met [LineSketchType.None](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Toegang tot de lijnopmaak van de vorm en zijn schetsformaat.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Een schetseffect toepassen.
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

De waarde die wordt geretourneerd door [ISketchFormat.getSketchType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isketchformat/) vertegenwoordigt de instelling die direct aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, master‑dia of layout‑dia, gebruik dan [ILineFormat.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilineformat/), benader [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilineformateffectivedata/), en lees [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isketchformateffectivedata/). De effectieve waarde geeft de opmaak weer die daadwerkelijk wordt toegepast nadat erfenis is opgehelderd:

```java
import com.aspose.slides.*;

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

## **Koppelstijlen opmaken**

Hier zijn de drie opties voor het type verbinding:

* Round  
* Miter  
* Bevel  

Standaard, wanneer PowerPoint twee lijnen onder een hoek (bijvoorbeeld op een hoek van een vorm) verbindt, wordt de **Round**‑instelling gebruikt. Als je echter een vorm met scherpe hoeken tekent, kun je de **Miter**‑optie verkiezen.

![De koppelstijl in de presentatie](join-style-powerpoint.png)

De volgende Java‑code laat zien hoe drie rechthoeken (zoals in de afbeelding hierboven) werden gemaakt met de Miter‑, Bevel‑ en Round‑koppeltype‑instellingen:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg drie auto shapes van het type Rectangle toe.
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

    // Stel de koppelstijl in.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Voeg tekst toe aan elke rechthoek.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Sla het PPTX-bestand op op schijf.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie waarmee je een continue kleurovergang op een vorm kunt toepassen. Bijvoorbeeld, je kunt twee of meer kleuren toepassen zodat de ene geleidelijk in de andere overvloeit.

Zo pas je een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse aan.  
1. Haal een referentie naar een dia op basis van de index.  
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.  
1. Stel de [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) van de vorm in op `Gradient`.  
1. Voeg je twee voorkeurskleuren met gedefinieerde posities toe via de `add`‑methoden van de gradient‑stop‑collectie die wordt aangeboden door de [IGradientFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/igradientformat/) interface.  
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Java‑code toont hoe je een verloopvulling toepast op een ellips:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto shape van het type Ellipse toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Pas gradientopmaak toe op de ellips.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Stel de richting van de gradient in.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Voeg twee gradientstops toe.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Sla het PPTX-bestand op op schijf.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De ellips met verloopvulling](gradient-fill.png)

## **Patroontevulling**

In PowerPoint is Patroontevulling een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, kruispatronen of geruite patronen—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te verhogen. Zelfs nadat je een vooraf gedefinieerd patroon hebt gekozen, kun je de exacte kleuren die worden gebruikt nog steeds specificeren.

Zo pas je een patroontevulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse aan.  
1. Haal een referentie naar een dia op basis van de index.  
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.  
1. Stel de [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) van de vorm in op `Pattern`.  
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.  
1. Stel de [Background Color](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/patternformat/#getBackColor--) van het patroon in.  
1. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/patternformat/#getForeColor--) van het patroon in.  
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Java‑code toont hoe je een patroonvulling toepast op een rechthoek:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto shape van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Stel de patroonstijl in.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Stel de patroonachtergrond- en voorgrondkleuren in.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Sla het PPTX-bestand op op schijf.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De rechthoek met patroontevulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt invoegen—de afbeelding fungeert dan als achtergrond van de vorm.

Zo gebruik je Aspose.Slides om een afbeeldingsvulling toe te passen op een vorm:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse aan.  
1. Haal een referentie naar een dia op basis van de index.  
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.  
1. Stel de [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) van de vorm in op `Picture`.  
1. Stel de afbeeldingsvullingsmodus in op `Tile` (of een andere gewenste modus).  
1. Creëer een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) object van de afbeelding die je wilt gebruiken.  
1. Geef de afbeelding door aan de `ISlidesPicture.setImage`‑methode.  
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Stel dat we een bestand “lotus.png” hebben met de volgende afbeelding:

![De lotus‑afbeelding](lotus.png)

De volgende Java‑code toont hoe je een vorm vult met de afbeelding:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto shape van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Stel het vultype in op Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Stel de afbeeldingsvullingsmodus in.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Laad een afbeelding en voeg deze toe aan de presentatiebronnen.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Stel de afbeelding in.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Sla het PPTX-bestand op op schijf.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding in tegelvorm als textuur**

Wil je een getegelde afbeelding als textuur instellen en het tegelgedrag aanpassen, dan kun je de volgende methoden van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/) interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/picturefillformat/) klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Stelt de afbeeldingsvullingsmodus in—`Tile` of `Stretch`.  
- [setTileAlignment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Bepaalt de uitlijning van de tegels binnen de vorm.  
- [setTileFlip](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Regelt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.  
- [setTileOffsetX](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Stelt de horizontale offset van de tegel (in punten) vanaf de oorsprong van de vorm in.  
- [setTileOffsetY](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Stelt de verticale offset van de tegel (in punten) vanaf de oorsprong van de vorm in.  
- [setTileScaleX](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definieert de horizontale schaal van de tegel als een percentage.  
- [setTileScaleY](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definieert de verticale schaal van de tegel als een percentage.

De volgende code laat zien hoe je een rechthoekvorm toevoegt met een getegelde afbeeldingsvulling en de tegelopties configureert:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Voeg een rechthoekige auto shape toe.
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

    // Configureer de afbeeldingsvullingsmodus en tegel‑eigenschappen.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Sla het PPTX-bestand op op schijf.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Effenkleurige vulling**

In PowerPoint is Effenkleurige vulling een opmaakoptie die een vorm vult met één enkele, uniforme kleur. Deze egale achtergrondkleur wordt toegepast zonder verloop, textuur of patroon.

Om een egale kleurvulling toe te passen op een vorm met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse aan.  
1. Haal een referentie naar een dia op basis van de index.  
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.  
1. Stel de [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) van de vorm in op `Solid`.  
1. Wijs de gewenste vulkleur toe aan de vorm.  
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Java‑code toont hoe je een egale kleurvulling toepast op een rechthoek in een PowerPoint‑dia:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto shape van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Stel de vulkleur in.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Sla het PPTX-bestand op op schijf.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De vorm met egale kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, wanneer je een egale kleur, verloop, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de dekking van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, waardoor de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides stelt je in staat de transparantiewaarde aan te passen door de alfa‑component van de gebruikte vulkleur te wijzigen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse aan.  
1. Haal een referentie naar een dia op basis van de index.  
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.  
1. Stel de [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Solid`.  
1. Gebruik `Color` om een kleur met transparantie te definiëren (de `alpha`‑component regelt de transparantie).  
1. Sla de presentatie op.

De volgende Java‑code toont hoe je een transparante vulkleur toepast op een rechthoek:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een solide rechthoekige auto shape toe.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoekige auto shape toe boven de solide vorm.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Sla het PPTX-bestand op op schijf.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides maakt het mogelijk om vormen te roteren in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning of ontwerpvereisten.

Volg deze stappen om een vorm op een dia te roteren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse aan.  
1. Haal een referentie naar een dia op basis van de index.  
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.  
1. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.  
1. Sla de presentatie op.

De volgende Java‑code toont hoe je een vorm met 5 graden draait:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto shape van het type Rectangle toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Roteer de vorm met 5 graden.
    shape.setRotation(5);

    // Sla het PPTX-bestand op op schijf.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D-inkepelingseffecten toevoegen**

Aspose.Slides laat je 3D‑inkepelingseffecten toepassen op vormen door de eigenschappen van hun [ThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/threedformat/) te configureren.

Volg deze stappen om 3D‑inkepelingseffecten aan een vorm toe te voegen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.  
1. Haal een referentie naar een dia op basis van de index.  
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.  
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/threedformat/) van de vorm om de inkepelingsinstellingen te definiëren.  
1. Sla de presentatie op.

De volgende Java‑code laat zien hoe je 3D‑inkepelingseffecten op een vorm toepast:

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

    // Stel de ThreeDFormat‑eigenschappen van de vorm in.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Sla de presentatie op als een PPTX‑bestand.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![Het 3D‑inkepelingseffect](3D-bevel-effect.png)

## **3D-rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑rotatie‑effecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/threedformat/) te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.  
1. Haal een referentie naar een dia op basis van de index.  
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.  
1. Gebruik [setCameraType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icamera/#setCameraType-int-) en [setLightType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) om de 3D‑rotatie te definiëren.  
1. Sla de presentatie op.

De volgende Java‑code toont hoe je 3D‑rotatie‑effecten op een vorm toepast:

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

## **Zwart-wit weergave van vormen beheren**

De methode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) bepaalt hoe een individuele vorm wordt weergegeven wanneer een presentatie in zwart‑wit‑modus wordt bekeken of verwerkt. De methode activeert niet zelf een zwart‑wit‑weergave en verandert de vul‑, lijn‑ of andere opmaak van de vorm niet in de normale kleurmodus.

Gebruik een waarde uit de klasse [BlackWhiteMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/blackwhitemode/) om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de weergave‑applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijstinten, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` forceren één kleur, `Color` behoudt de normale kleur, en `Hidden` laat de vorm weg in zwart‑wit‑modus. `NotDefined` betekent dat er geen vorm‑specifieke modus is toegewezen.

De volgende Java‑code maakt een gekleurde vorm en laat deze grijs verschijnen in zwart‑wit‑weergavemodus:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Behoud de oranje vulling in kleermodus, maar geef de vorm weer met grijze kleur in zwart-wit modus.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In de normale kleurmodus behoudt het rechthoekje zijn oranje vulling. In een zwart‑wit‑werkomgeving wordt een grijstint gebruikt omdat de modus op `Gray` staat. Zo kun je een volledige‑kleur dia behouden terwijl je een aparte weergave definieert voor afdrukken, voorvertoningen of andere werkwijzen die rekening houden met de zwart‑wit‑instellingen van de presentatie.

## **Opmaak resetten**

De volgende Java‑code toont hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

```java
import com.aspose.slides.*;

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

**Heeft de opmaak van een vorm invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingesloten afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en praktisch geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak­eigenschappen van elke vorm—vull‑, lijn‑ en effectinstellingen. Als alle overeenkomstige waarden gelijk zijn, beschouw je hun stijlen als identiek en groepeer je de vormen logisch, wat later het beheer van stijlen vereenvoudigt.

**Kan ik een verzameling aangepaste vormstijlen opslaan in een afzonderlijk bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een templateslidedek of een .POTX‑templatesbestand. Wanneer je een nieuwe presentatie maakt, open je de template, kloon je de gestylede vormen die je nodig hebt, en pas je hun opmaak toe waar nodig.