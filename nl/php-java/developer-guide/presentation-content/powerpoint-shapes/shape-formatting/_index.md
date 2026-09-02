---
title: PowerPoint-vormen opmaken in PHP
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/php-java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets effect
- schets vormlijn
- koppelstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- vorm roteren
- 3D-afschuiningseffect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen kunt opmaken in PHP met Aspose.Slides—stel vullings-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP‑bestanden met precisie en volledige controle."
---
## **Introductie**

In PowerPoint kunt u vormen aan dia's toevoegen. Aangezien vormen bestaan uit lijnen, kunt u ze opmaken door de omtrek te wijzigen of effecten toe te passen. Bovendien kunt u vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![vorm opmaken in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java biedt klassen en methoden die u in staat stellen vormen op te maken met dezelfde opties die in PowerPoint beschikbaar zijn.

## **Lijnen opmaken**

Met Aspose.Slides kunt u een aangepaste lijnstijl voor een vorm specificeren. De onderstaande stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Verkrijg een verwijzing naar een dia door zijn index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Stel de [lijnstijl](https://reference.aspose.com/slides/nl/php-java/aspose.slides/linestyle/) van de vorm in.
5. Stel de lijndikte in.
6. Stel de [streeppatroon](https://reference.aspose.com/slides/nl/php-java/aspose.slides/linedashstyle/) van de lijn in.
7. Stel de lijnkleur voor de vorm in.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende PHP‑code laat zien hoe u een rechthoekige `AutoShape` kunt opmaken:

```php
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt.
$presentation = new Presentation();
try {
    // Haal de eerste dia op.
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg een auto shape van het type Rechthoek toe.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Stel de vulkleur in voor de rechthoekvorm.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Pas de opmaak toe op de lijnen van de rechthoek.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Stel de kleur in voor de lijn van de rechthoek.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Sla het PPTX-bestand op naar schijf.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schetseffect maakt een vormlijn eruitzien alsof deze met de hand getekend is. Gebruik [Shape.getLineFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) om de lijninstellingen te benaderen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/lineformat/) om de schetseigenschappen te benaderen, en [SketchFormat.setSketchType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sketchformat/) om een waarde uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/linesketchtype/) te selecteren.

De volgende PHP‑code toont hoe u een [LineSketchType.Curved](https://reference.aspose.com/slides/nl/php-java/aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde uitleest, en het effect verwijdert met [LineSketchType.None](https://reference.aspose.com/slides/nl/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Toegang tot het lijnformaat van de vorm en het schetsformaat.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Pas een schetseffect toe.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Lees het schetseffect dat rechtstreeks aan de vorm is toegewezen.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Verwijder het schetseffect.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

De waarde die wordt geretourneerd door [SketchFormat.getSketchType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sketchformat/) vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, masterdia of lay-outdia, gebruik dan [LineFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/lineformat/), benader de `getSketchFormat`‑methode van het geretourneerde object, en lees de `getSketchType`‑waarde. De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat de overerving is opgelost:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Koppelpuntstijlen opmaken**

Dit zijn de drie opties voor koppelpunt‑type:

* Rond
* Scherp
* Afgeschuind

Standaard, wanneer PowerPoint twee lijnen onder een hoek (bijvoorbeeld bij de hoek van een vorm) verbindt, gebruikt het de instelling **Rond**. Als u echter een vorm met scherpe hoeken tekent, geeft u mogelijk de voorkeur aan de **Scherp**‑optie.

![De koppelstijl in de presentatie](join-style-powerpoint.png)

De volgende PHP‑code toont hoe drie rechthoeken (zoals weergegeven in de afbeelding hierboven) zijn gemaakt met de Miter‑, Bevel‑ en Round‑koppeltype‑instellingen:

```php
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt.
$presentation = new Presentation();
try {
    // Haal de eerste dia op.
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg drie auto shapes van het type Rechthoek toe.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Stel de vulkleur in voor elke rechthoekvorm.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Stel de lijndikte in.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Stel de kleur in voor de lijn van elke rechthoek.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Stel de koppelstijl in.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Voeg tekst toe aan elke rechthoek.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Sla het PPTX-bestand op naar schijf.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie waarmee u een geleidelijke kleurverloop op een vorm kunt toepassen. U kunt bijvoorbeeld twee of meer kleuren toepassen zodat de ene langzaam in de andere overloopt.

Zo past u een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) van de vorm in op `Gradient`.
5. Voeg uw twee gewenste kleuren met gedefinieerde posities toe met behulp van de `add`‑methoden van de gradient‑stop‑collectie die beschikbaar is via de [GradientFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/gradientformat/) klasse.
6. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```php
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt.
$presentation = new Presentation();
try {
    // Haal de eerste dia op.
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg een auto shape van het type Ellips toe.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Pas een verloopopmaak toe op de ellips.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Stel de richting van het verloop in.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Voeg twee verloopstops toe.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Sla het PPTX-bestand op naar schijf.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De ellips met verloopvulling](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee u een tweekleurig ontwerp—zoals stippen, strepen, kruispatronen of ruiten—op een vorm kunt toepassen. U kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die u op vormen kunt toepassen om de visuele aantrekkingskracht van uw presentaties te verbeteren. Zelfs nadat u een vooraf gedefinieerd patroon hebt geselecteerd, kunt u de exacte kleuren die het moet gebruiken nog steeds aangeven.

Zo past u een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) van de vorm in op `Pattern`.
5. Kies een patroonstijl uit de vooraf gedefinieerde opties.
6. Stel de [Background Color](https://reference.aspose.com/slides/nl/php-java/aspose.slides/patternformat/#getBackColor) van het patroon in.
7. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/php-java/aspose.slides/patternformat/#getForeColor) van het patroon in.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```php
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt.
$presentation = new Presentation();
try {
    // Haal de eerste dia op.
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg een auto shape van het type Rechthoek toe.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Patroon.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Stel de patroonstijl in.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Stel de achtergrond- en voorgrondkleuren van het patroon in.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Sla het PPTX-bestand op naar schijf.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee u een afbeelding in een vorm kunt invoegen—de afbeelding wordt effectief als achtergrond van de vorm gebruikt.

Zo gebruikt u Aspose.Slides om een afbeeldingvulling op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) van de vorm in op `Picture`.
5. Stel de afbeeldingsvulmodus in op `Tile` (of een andere gewenste modus).
6. Maak een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑object aan van de afbeelding die u wilt gebruiken.
7. Geef de afbeelding door aan de `SlidesPicture.setImage`‑methode.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Stel dat we een bestand "lotus.png" hebben met de volgende afbeelding:

![De lotusafbeelding](lotus.png)

```php
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt.
$presentation = new Presentation();
try {
    // Haal de eerste dia op.
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg een auto shape van het type Rechthoek toe.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Stel het vultype in op Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Stel de picture fill mode in.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Laad een afbeelding en voeg deze toe aan de presentatieresources.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Stel de afbeelding in.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Sla het PPTX-bestand op naar schijf.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding als tegeltextuur**

Als u een getegelde afbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kunt u de volgende methoden van de [PictureFillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/)‑klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Stelt de afbeeldingsvulmodus in—ofwel `Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#setTileAlignment): Bepaalt de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#setTileFlip): Regelt of de tegel horizontaal, verticaal of beide kanten wordt gedraaid.
- [setTileOffsetX](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definieert de horizontale schaal van de tegel als percentage.
- [setTileScaleY](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definieert de verticale schaal van de tegel als percentage.

De volgende codevoorbeelden tonen hoe u een rechthoekige vorm met een getegelde afbeeldingvulling toevoegt en de tegelopties configureert:

```php
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt.
$presentation = new Presentation();
try {
    // Haal de eerste dia op.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Voeg een rechthoekige auto shape toe.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Stel het vultype van de vorm in op Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Laad de afbeelding en voeg deze toe aan de presentatieresources.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Wijs de afbeelding toe aan de vorm.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Configureer de picture fill-modus en tegel‑eigenschappen.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Sla het PPTX‑bestand op naar schijf.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm vult met één eenduidige kleur. Deze eenvoudige achtergrondkleur wordt toegepast zonder verloop, texturen of patronen.

Om een effen kleurvulling op een vorm toe te passen met Aspose.Slides, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) van de vorm in op `Solid`.
5. Wijs uw gewenste vulkleur toe aan de vorm.
6. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```php
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt.
$presentation = new Presentation();
try {
    // Haal de eerste dia op.
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg een auto shape van het type Rechthoek toe.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Stel de vulkleur in.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Sla het PPTX-bestand op naar schijf.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kunt u, wanneer u een effen kleur, verloop, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de dekkingsgraad van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm doorzichtiger, waardoor de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides stelt u in staat het transparantieniveau in te stellen door de alfawaarde van de gebruikte kleur voor de vulling aan te passen. Zo doet u dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) in op `Solid`.
5. Gebruik `Color` om een kleur met transparantie te definiëren (het `alpha`‑component bepaalt de transparantie).
6. Sla de presentatie op.

```php
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt.
$presentation = new Presentation();
try {
    // Haal de eerste dia op.
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg een solide rechthoek auto shape toe.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoek auto shape toe boven de solide vorm.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Sla het PPTX-bestand op naar schijf.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides maakt het mogelijk om vormen in PowerPoint‑presentaties te roteren. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning of ontwerpeisen.

Om een vorm op een dia te roteren, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
5. Sla de presentatie op.

```php
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt.
$presentation = new Presentation();
try {
    // Haal de eerste dia op.
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg een auto shape van het type Rechthoek toe.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Roteer de vorm met 5 graden.
    $shape->setRotation(5);

    // Sla het PPTX-bestand op naar schijf.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De rotering van de vorm](shape-rotation.png)

## **3D‑afschuiningseffecten toevoegen**

Aspose.Slides stelt u in staat 3D‑afschuiningseffecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑afschuiningseffecten aan een vorm toe te voegen, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/) van de vorm om de afschuining in te stellen.
5. Sla de presentatie op.

```php
// Maak een instantie van de Presentation-klasse.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg een vorm toe aan de dia.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Stel de ThreeDFormat-eigenschappen van de vorm in.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Sla de presentatie op als een PPTX‑bestand.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![Het 3D‑afschuiningseffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk 3D‑rotatie‑effecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Gebruik [setCameraType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/camera/#setCameraType) en [setLightType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/lightrig/#setLightType) om de 3D‑rotatie te definiëren.
5. Sla de presentatie op.

```php
// Maak een instantie van de Presentation-klasse.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Sla de presentatie op als een PPTX-bestand.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Opmaak resetten**

De volgende Java‑code toont hoe u de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Reset elke vorm op de dia die een placeholder op de lay-out heeft.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Veelgestelde vragen**

**Heeft het opmaken van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen in beperkte mate. Ingesloten afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en verlopen worden opgeslagen als metadata en praktisch geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen, zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vulling, lijn en effectinstellingen. Als alle bijbehorende waarden overeenkomen, beschouw dan hun stijlen als identiek en groepeer die vormen logisch, wat later het beheer van stijlen vereenvoudigt.

**Kan ik een reeks aangepaste vormstijlen opslaan in een afzonderlijk bestand voor hergebruik in andere presentaties?**

Ja. Bewaar voorbeeldvormen met de gewenste stijlen in een sjabloondoc of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie opent u het sjabloon, kloont u de benodigde vormstijlen en past u hun opmaak toe waar nodig.