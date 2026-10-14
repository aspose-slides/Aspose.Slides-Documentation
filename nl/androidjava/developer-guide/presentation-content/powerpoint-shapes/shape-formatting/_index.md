---
title: PowerPoint-vormen opmaken op Android
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/androidjava/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets effect
- schetsvormlijn
- koppelstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormdoorzichtigheid
- zwart-wit vormweergave
- grijswaarden vormweergave
- vorm roteren
- 3D kantelingseffect
- 3D rotatieeffect
- opmaak resetten
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen op Android kunt opmaken met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Inleiding**

In PowerPoint kun je vormen aan dia’s toevoegen. Omdat vormen uit lijnen bestaan, kun je ze opmaken door hun contouren te wijzigen of er effecten op toe te passen. Daarnaast kun je vormen opmaken door instellingen op te geven die bepalen hoe hun interieurs worden gevuld.

![vorm formatteren PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java biedt interfaces en methoden waarmee je vormen kunt opmaken met dezelfde opties die in PowerPoint beschikbaar zijn.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepast lijnstijltype voor een vorm opgeven. De volgende stappen beschrijven de werkwijze:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [line style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende code laat zien hoe je een rechthoek‑AutoShape kunt opmaken:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een automatische vorm van het type Rechthoek toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Verwijder de vulling van de rechthoekvorm zodat alleen de lijnen zichtbaar zijn.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Pas de opmaak toe op de lijnen van de rechthoek.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Stel de kleur in voor de lijn van de rechthoek.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Sla het PPTX-bestand op schijf.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schetseffect laat een vormlijn eruitzien alsof hij met de hand is getekend. Gebruik [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) om de lijninstellingen te benaderen, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) om de schetseigenschappen te benaderen, en [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) om een waarde uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) te selecteren.

De volgende Java‑code toont hoe je een [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde uitleest en het effect verwijdert met [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Toegang tot het lijnformaat van de vorm en het schetsformaat.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Een schetseffect toepassen.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Het schetseffect uitlezen dat rechtstreeks aan de vorm is toegewezen.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Het schetseffect verwijderen.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

De waarde die wordt geretourneerd door [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) vertegenwoordigt de instelling die rechtstreeks op de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, masterslide of lay‑outsdia, gebruik dan [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/), benader [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/), en lees [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/). De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat de overerving is opgelost:

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

## **Knoop‑stijlen opmaken**

Hier zijn de drie beschikbare koppeltype‑opties:

* Round
* Miter
* Bevel

Standaard gebruikt PowerPoint bij het verbinden van twee lijnen onder een hoek (bijvoorbeeld op een hoek van een vorm) de **Round**‑instelling. Als je echter een vorm met scherpe hoeken tekent, geef je wellicht de voorkeur aan de **Miter**‑optie.

![De koppelstijl in de presentatie](join-style-powerpoint.png)

De volgende Java‑code laat zien hoe drie rechthoeken (zoals weergegeven in de afbeelding hierboven) werden gemaakt met respectievelijk de Miter‑, Bevel‑ en Round‑koppeltype‑instellingen:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg drie automatische vormen van het type Rechthoek toe.
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

    // Sla het PPTX-bestand op schijf.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie waarmee je een continue kleurovergang op een vorm kunt toepassen. Je kunt bijvoorbeeld twee of meer kleuren zo combineren dat de ene geleidelijk in de andere overloopt.

Zo pas je een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) van de vorm in op `Gradient`.
1. Voeg je twee gewenste kleuren met gedefinieerde posities toe via de `add`‑methoden van de gradient‑stop‑collectie die wordt blootgesteld door de [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/) interface.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende Java‑code laat zien hoe je een verloopvulling op een ellipse toepast:

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een automatische vorm van het type Ellips toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Pas een verloopopmaak toe op de ellips.
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

Resultaat:

![De ellipse met verloopvulling](gradient-fill.png)

Als een verloop er in een geëxporteerde afbeelding anders uitziet dan in PowerPoint, zie dan [Choose a Gradient Rendering Style](/slides/nl/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Je kunt een weergavestijl kiezen zonder de in de presentatie opgeslagen verloopvulling te wijzigen.

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie die je toestaat een tweekleuren‑ontwerp—zoals stippen, strepen, kruislings of geruite patronen—op een vorm toe te passen. Je kunt aangepaste kleuren kiezen voor zowel de voor‑ als de achtergrond van het patroon.

Aspose.Slides levert meer dan 45 voorgedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te vergroten. Ook nadat je een voorgedefinieerd patroon hebt gekozen, kun je de exacte kleuren die gebruikt worden specificeren.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) van de vorm in op `Pattern`.
1. Kies een patroonstijl uit de voorgedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) van het patroon in.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende Java‑code laat zien hoe je een patroonvulling op een rechthoek toepast:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een automatische vorm van het type Rechthoek toe.
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

Resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt invoegen—effectief de afbeelding als achtergrond van de vorm gebruikt.

Zo gebruik je Aspose.Slides om een afbeeldingvulling op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) van de vorm in op `Picture`.
1. Stel de modus van de afbeeldingvulling in op `Tile` (of een andere gewenste modus).
1. Maak een [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/)‑object van de afbeelding die je wilt gebruiken.
1. Geef de afbeelding door aan de `ISlidesPicture.setImage`‑methode.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

Stel dat we een bestand “lotus.png” hebben met de volgende afbeelding:

![De lotus‑afbeelding](lotus.png)

De volgende Java‑code laat zien hoe je een vorm vult met de afbeelding:

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een automatische vorm van het type Rechthoek toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Stel het vultype in op Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Stel de modus van de afbeeldingvulling in.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Laad een afbeelding en voeg die toe aan de presentatieresources.
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

Resultaat:

![De vorm met afbeeldingvulling](picture-fill.png)

### **Afbeelding in tegelmodus als textuur**

Wil je een getegelde afbeelding als textuur gebruiken en het tegelgedrag aanpassen, gebruik dan de volgende methoden van de [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) interface en de [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) class:

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Stelt de modus van de afbeeldingvulling in—`Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Bepaalt de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Regelt of de tegel horizontaal, verticaal of beide kanten wordt gespiegeld.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definieert de horizontale schaal van de tegel als een percentage.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definieert de verticale schaal van de tegel als een percentage.

De volgende code‑voorbeeld toont hoe je een rechthoekige vorm met een getegelde afbeeldingvulling toevoegt en de tegelopties configureert:

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Voeg een automatische rechthoekvorm toe.
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

    // Configureer de modus van de afbeeldingvulling en de tegeleigenschappen.
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

Resultaat:

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm vult met één enkele, uniforme kleur. Deze effen achtergrondkleur wordt toegepast zonder verlopen, texturen of patronen.

Om een effen kleurvulling op een vorm toe te passen met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) van de vorm in op `Solid`.
1. Ken je gewenste vulkleur toe aan de vorm.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende Java‑code toont hoe je een effen kleurvulling op een rechthoek in een PowerPoint‑dia toepast:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
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

Resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Doorzichtigheid instellen**

In PowerPoint kun je, wanneer je een effen kleur, verloop, afbeelding of textuurvulling toepast op vormen, ook een doorzichtigheidsniveau instellen om de opaciteit van de vulling te regelen. Een hogere doorzichtigheidswaarde maakt de vorm meer doorschijnend, waardoor de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides laat je de doorzichtigheid instellen door de alfadeelwaarde van de gebruikte vulkleur aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color` om een kleur met doorzichtigheid te definiëren (het `alpha`‑component bepaalt de doorzichtigheid).
1. Sla de presentatie op.

De volgende Java‑code laat zien hoe je een doorzichtige vulkleur op een rechthoek toepast:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een solide rechthoekige automatische vorm toe.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoekige automatische vorm toe boven de solide vorm.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Sla het PPTX-bestand op schijf.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![De doorzichtige vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides laat je vormen roteren in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning of ontwerpeisen.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

De volgende Java‑code rotatie van een vorm met 5 graden demonstreert:

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een automatische vorm van het type Rechthoek toe.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Roteer de vorm met 5 graden.
    shape.setRotation(5);

    // Sla het PPTX-bestand op schijf.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![De vormrotatie](shape-rotation.png)

## **3D‑kantelings‑effecten toevoegen**

Aspose.Slides maakt het mogelijk 3D‑kantelings‑effecten op vormen toe te passen door de eigenschappen van hun [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) te configureren.

Om 3D‑kantelings‑effecten aan een vorm toe te voegen, volg je deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) van de vorm om de kantelingsinstellingen te definiëren.
1. Sla de presentatie op.

De volgende Java‑code toont hoe je 3D‑kantelings‑effecten op een vorm toepast:

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

Resultaat:

![Het 3D‑kantelings‑effect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk 3D‑rotatie‑effecten op vormen toe te passen door de eigenschappen van hun [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
1. Gebruik [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) en [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

De volgende Java‑code demonstreert hoe je 3D‑rotatie‑effecten op een vorm toepast:

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

Resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart‑wit weergave voor vormen regelen**

De methode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) geeft aan hoe een individuele vorm wordt gerenderd wanneer een presentatie in zwart‑wit‑modus wordt bekeken of verwerkt. De methode activeert zelf geen zwart‑wit‑weergave en verandert de vul‑, lijn‑ of andere opmaak van de vorm niet in de normale kleermodus.

Gebruik een waarde uit de klasse [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de render‑applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijstinten, `BlackWhite` gebruikt uitsluitend zwart en wit, `Black` en `White` forceren één enkele kleur, `Color` behoudt de normale kleuring, en `Hidden` laat de vorm weg in de zwart‑wit‑modus. `NotDefined` betekent dat er geen modus op vormniveau is toegewezen.

De volgende Java‑code maakt een gekleurde vorm aan en laat deze grijs verschijnen in de zwart‑wit‑weergavemodus:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Behoud de oranje vulling in kleermodus, maar render de vorm met grijze kleur in zwart-wit modus.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In de normale kleermodus behoudt de rechthoek zijn oranje vulling. In een zwart‑wit‑workflow wordt de rechthoek grijs weergegeven omdat de modus is ingesteld op `Gray`. Zo kun je een volledige‑kleur dia behouden terwijl je een aparte weergave definieert voor afdrukken, preview‑ of andere workflows die de zwart‑wit‑instellingen van de presentatie respecteren.

## **Opmaak resetten**

De volgende Java‑code toont hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) terugzet naar de standaardinstellingen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Reset elke vorm op de dia die een placeholder op de lay-out heeft.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Heeft het vorm‑formatteren invloed op de uiteindelijke grootte van het presentatie‑bestand?**

Alleen minimaal. Ingebedde afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vorm‑parameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en vrijwel geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vulling, lijn en effectinstellingen. Als alle overeenkomstige waarden overeenkomen, behandel je de stijlen als identiek en groepeer je die vormen logisch, wat later beheer van stijlen vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeld‑vormen met de gewenste stijlen op in een sjabloon‑presentatie of een .POTX‑sjabloonbestand. Wanneer je een nieuwe presentatie maakt, open je het sjabloon, kloon je de gestijlde vormen die je nodig hebt, en pas je hun opmaak opnieuw toe waar nodig.