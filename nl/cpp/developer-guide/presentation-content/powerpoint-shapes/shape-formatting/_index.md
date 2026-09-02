---
title: PowerPoint‑vormen opmaken in C++
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/cpp/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets‑effect
- schets‑vormlijn
- aansluitingstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- vorm roteren
- 3D‑schuineffect
- 3D‑rotatie‑effect
- opmaak herstellen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u PowerPoint‑vormen kunt opmaken in C++ met Aspose.Slides—stel vullings-, lijn‑ en effectstijlen in voor PPT‑, PPTX‑ en ODP‑bestanden met precisie en volledige controle."
---
## **Inleiding**

In PowerPoint kun je vormen aan dia’s toevoegen. Omdat vormen uit lijnen bestaan, kun je hun opmaak aanpassen door de omtrek te wijzigen of er effecten op toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![vorm-opmaken-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ biedt interfaces en methoden waarmee je vormen kunt opmaken met dezelfde opties als in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm aangeven. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal een verwijzing naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [lijnstijl](https://reference.aspose.com/slides/nl/cpp/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [streepte stijl](https://reference.aspose.com/slides/nl/cpp/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende code laat zien hoe je een rechthoekige `AutoShape` kunt opmaken:

```cpp
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een automatische vorm van het type Rechthoek toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Stel de vulkleur in voor de rechthoekige vorm.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Pas opmaak toe op de lijnen van de rechthoek.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Stel de kleur in voor de lijn van de rechthoek.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Sla het PPTX‑bestand op schijf.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect laat een vormlijn handgetekend lijken. Gebruik [IShape::get_LineFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_lineformat/) om toegang te krijgen tot de lijninstellingen, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilineformat/get_sketchformat/) voor de schetstinstellingen, en [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isketchformat/set_sketchtype/) om een waarde uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/linesketchtype/) te selecteren.

De volgende C++‑code toont hoe je een [LineSketchType::Curved](https://reference.aspose.com/slides/nl/cpp/aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde uitleest, en het effect verwijdert met [LineSketchType::None](https://reference.aspose.com/slides/nl/cpp/aspose.slides/linesketchtype/):

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

De waarde die wordt geretourneerd door [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isketchformat/get_sketchtype/) vertegenwoordigt de instelling die direct aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, masterslide of layout‑slide, gebruik dan [ILineFormat::GetEffective](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilineformat/geteffective/), krijg toegang tot [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), en lees [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). De effectieve waarde weerspiegelt de opmaak die werkelijk wordt toegepast nadat overerving is opgelost:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **Aansluitingstijlen opmaken**

Hier zijn de drie opties voor het type aansluiting:

* Rond
* Schuin
* Afschuining

Standaard gebruikt PowerPoint bij het verbinden van twee lijnen onder een hoek (bijvoorbeeld op een hoek van een vorm) de instelling **Rond**. Als je echter een vorm met scherpe hoeken tekent, kun je de **Schuin**‑optie verkiezen.

![De aansluitingstijl in de presentatie](join-style-powerpoint.png)

De volgende C++‑code laat zien hoe drie rechthoeken (zoals in de afbeelding hierboven) werden gemaakt met respectievelijk de aansluitinstellingen Schuin, Afschuining en Rond:

```cpp
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg drie automatische vormen van het type Rechthoek toe.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Stel de vulkleur in voor elke rechthoekige vorm.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Stel de lijndikte in.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Stel de kleur in voor de lijn van elke rechthoek.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Stel de aansluitstijl in.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Voeg tekst toe aan elke rechthoek.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Sla het PPTX‑bestand op schijf.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Verloopopvulling**

In PowerPoint is Verloopopvulling een opmaakoptie waarmee je een continue kleurovergang op een vorm kunt toepassen. Bijvoorbeeld, je kunt twee of meer kleuren gebruiken zodat de ene geleidelijk in de andere vervaagt.

Zo pas je een verloopopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal een verwijzing naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) van de vorm in op `Gradient`.
1. Voeg je twee gewenste kleuren toe met gedefinieerde posities via de `Add`‑methoden van de gradient‑stop‑collectie die wordt blootgesteld door de [IGradientFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igradientformat/)‑interface.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C++‑code laat zien hoe je een verloopopvulling toepast op een ellips:

```cpp
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een automatische vorm van het type Ellips toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Pas een verloopopmaak toe op de ellips.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Stel de richting van het verloop in.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Voeg twee verloopstops toe.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Sla het PPTX‑bestand op schijf.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De ellips met verloopopvulling](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie die je toelaat een tweekleurig ontwerp—zoals stippen, strepen, kruislijnen of schaakpatronen—op een vorm toe te passen. Je kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te verhogen. Zelfs nadat je een vooraf gedefinieerd patroon hebt geselecteerd, kun je nog steeds de exacte kleuren aangeven die het moet gebruiken.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal een verwijzing naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) van de vorm in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipatternformat/get_backcolor/) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipatternformat/get_forecolor/) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C++‑code laat zien hoe je een patroonvulling toepast op een rechthoek:

```cpp
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een automatische vorm van het type Rechthoek toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Stel het vultype in op Patroon.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Stel de patroonstijl in.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Stel de achtergrond‑ en voorgrondkleuren van het patroon in.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Sla het PPTX‑bestand op schijf.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt invoegen—effectief de afbeelding als achtergrond van de vorm gebruiken.

Zo gebruik je Aspose.Slides om een afbeeldingvulling op een vorm toe te passen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal een verwijzing naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) van de vorm in op `Picture`.
1. Stel de afbeeldingsvullingsmodus in op `Tile` (of een andere gewenste modus).
1. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)‑object aan van de afbeelding die je wilt gebruiken.
1. Geef de afbeelding door aan de `ISlidesPicture.set_Image`‑methode.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Stel dat we een bestand “lotus.png” hebben met de volgende afbeelding:

![De lotus‑afbeelding](lotus.png)

De volgende C++‑code laat zien hoe je een vorm met een afbeelding vult:

```cpp
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een automatische vorm van het type Rechthoek toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Stel het vultype in op Afbeelding.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Stel de afbeeldingvullingsmodus in.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Laad een afbeelding en voeg deze toe aan de presentatieresources.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Stel de afbeelding in.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Sla het PPTX‑bestand op schijf.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De vorm met afbeeldingvulling](picture-fill.png)

### **Afbeelding als tegel‑textuur**

Als je een getegelde afbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kun je de volgende methoden van de interface [IPictureFillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/) en van de klasse [PictureFillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/picturefillformat/) gebruiken:

- [set_PictureFillMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Stelt de afbeeldingvullingsmodus in—`Tile` of `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Bepaalt de uitlijning van de tegels binnen de vorm.
- [set_TileFlip](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Regelt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.
- [set_TileOffsetX](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [set_TileOffsetY](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [set_TileScaleX](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definieert de horizontale schaal van de tegel als percentage.
- [set_TileScaleY](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definieert de verticale schaal van de tegel als percentage.

De volgende code‑voorbeeld laat zien hoe je een rechthoekige vorm toevoegt met een getegelde afbeeldingvulling en de tegelopties configureert:

```cpp
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto firstSlide = presentation->get_Slide(0);

// Voeg een automatische rechthoekvorm toe.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Stel het vultype van de vorm in op Afbeelding.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Laad de afbeelding en voeg deze toe aan de presentatieresources.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Wijs de afbeelding toe aan de vorm.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Configureer de afbeeldingvullingsmodus en tegel-eigenschappen.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Sla het PPTX-bestand op schijf.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm vult met één enkele, uniforme kleur. Deze eenvoudige achtergrondkleur wordt toegepast zonder verloop, texturen of patronen.

Om een effen kleurvulling op een vorm toe te passen met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal een verwijzing naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) van de vorm in op `Solid`.
1. Wijs de gewenste vullingskleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C++‑code laat zien hoe je een effen kleurvulling toepast op een rechthoek in een PowerPoint‑dia:

```cpp
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een automatische vorm van het type Rechthoek toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Stel het vultype in op Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Stel de vulkleur in.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Sla het PPTX‑bestand op schijf.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, wanneer je een effen kleur, verloop, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de doorzichtigheid van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, zodat de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides laat je het transparantieniveau bepalen door de alfa‑waarde van de gebruikte vulkleur aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal een verwijzing naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color` om een kleur met transparantie te definiëren (de `alpha`‑component regelt de transparantie).
1. Sla de presentatie op.

De volgende C++‑code laat zien hoe je een transparante vulkleur toepast op een rechthoek:

```cpp
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een effen rechthoek‑auto‑vorm toe.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Voeg een transparante rechthoek‑auto‑vorm toe boven de effen vorm.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Sla het PPTX‑bestand op schijf.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides laat je vormen roteren in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning‑ of ontwerpeisen.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal een verwijzing naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

De volgende C++‑code laat zien hoe je een vorm met 5 graden roteert:

```cpp
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een automatische vorm van het type Rechthoek toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Draai de vorm met 5 graden.
shape->set_Rotation(5);

// Sla het PPTX-bestand op schijf.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D‑schuineffecten toevoegen**

Aspose.Slides maakt het mogelijk 3D‑schuineffecten op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑schuineffecten op een vorm toe te voegen, volg je deze stappen:

1. Instantieer de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal een verwijzing naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/threedformat/) van de vorm om de schuine instellingen te definiëren.
1. Sla de presentatie op.

De volgende C++‑code toont hoe je 3D‑schuineffecten op een vorm toepast:

```cpp
// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Add a shape to the slide.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Set the shape's ThreeDFormat properties.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Save the presentation as a PPTX file.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![Het 3D‑schuineffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk 3D‑rotatie‑effecten op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal een verwijzing naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Gebruik [set_CameraType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icamera/set_cameratype/) en [set_LightType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilightrig/set_lighttype/) om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

De volgende C++‑code laat zien hoe je 3D‑rotatie‑effecten op een vorm toepast:

```cpp
// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Sla de presentatie op als een PPTX-bestand.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Opmaak resetten**

De volgende C++‑code laat zien hoe je de opmaak van een dia kunt resetten en de positie, grootte en opmaak van alle vormen met plaatshouders op de [LayoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/layoutslide/) terugzet naar de standaardinstellingen:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Reset elke vorm op de dia die een plaatshouder op de lay-out heeft.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Heeft de vormopmaak invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingevoegde afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag; vormparameters zoals kleuren, effecten en verlopen worden opgeslagen als metadata en voegen praktisch geen extra grootte toe.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vulling, lijn en effectinstellingen. Als alle overeenkomende waarden gelijk zijn, beschouw je hun stijlen als identiek en groepeer je die vormen logisch, wat later style‑beheer vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloon‑presentatie of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie open je het sjabloon, kloon je de gestileerde vormen die je nodig hebt, en pas je hun opmaak opnieuw toe waar nodig.