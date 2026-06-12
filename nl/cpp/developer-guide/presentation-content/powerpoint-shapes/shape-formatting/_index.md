---
title: Opmaak van PowerPoint-vormen in C++
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/cpp/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- koppelingsstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- vorm roteren
- 3D-schuineffect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen kunt opmaken in C++ met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Introductie**

In PowerPoint kun je vormen toevoegen aan dia's. Omdat vormen bestaan uit lijnen, kun je ze opmaken door de contouren te wijzigen of effecten toe te passen. Daarnaast kun je vormen opmaken door instellingen op te geven die bepalen hoe hun binnenkant wordt gevuld.

![vorm opmaken PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for C++ biedt interfaces en methoden waarmee je vormen kunt opmaken met dezelfde opties die beschikbaar zijn in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepast lijnstijlopmaak voor een vorm opgeven. De volgende stappen beschrijven de werkwijze:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [line style](https://reference.aspose.com/slides/nl/cpp/aspose.slides/linestyle/) van de vorm in.
5. Stel de lijndikte in.
6. Stel de [dash style](https://reference.aspose.com/slides/nl/cpp/aspose.slides/linedashstyle/) van de lijn in.
7. Stel de lijnekleur voor de vorm in.
8. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende code laat zien hoe je een rechthoekige `AutoShape` kunt opmaken:

```cpp
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een auto-vorm van het type Rectangle toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Stel de vulkleur in voor de rechthoekvorm.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Pas opmaak toe op de lijnen van de rechthoek.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Stel de kleur in voor de lijn van de rechthoek.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Sla het PPTX-bestand op naar schijf.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Knoopstijlen opmaken**

Hier zijn de drie opties voor het type verbinding:

* Rond
* Versneden
* Afgeschuind

Standaard gebruikt PowerPoint bij het verbinden van twee lijnen onder een hoek (zoals bij een hoek van een vorm) de instelling **Round**. Als je echter een vorm met scherpe hoeken tekent, kun je de optie **Miter** verkiezen.

![De koppelingsstijl in de presentatie](join-style-powerpoint.png)

De volgende C++‑code laat zien hoe drie rechthoeken (zoals in de afbeelding hierboven) zijn gemaakt met de Miter‑, Bevel‑ en Round‑instellingen voor het type verbinding:

```cpp
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg drie auto-vormen van het type Rectangle toe.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Stel de vulkleur in voor elke rechthoekvorm.
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

// Stel de koppelingsstijl in.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Voeg tekst toe aan elke rechthoek.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Sla het PPTX-bestand op naar schijf.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Verloopvulling**

In PowerPoint is Gradient Fill (verloopvulling) een opmaakoptie waarmee je een continue kleurverloop op een vorm kunt toepassen. Bijvoorbeeld kun je twee of meer kleuren gebruiken zodat de ene geleidelijk in de andere vervaagt.

Zo pas je een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) van de vorm in op `Gradient`.
5. Voeg je twee gewenste kleuren met gedefinieerde posities toe met behulp van de `Add`‑methoden van de gradient‑stop‑collectie die beschikbaar is via de [IGradientFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igradientformat/)-interface.
6. Sla de aangepaste presentatie op als een PPTX‑bestand.

```cpp
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een auto-vorm van het type Ellipse toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Pas verloopopmaak toe op de ellips.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Stel de richting van het verloop in.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Voeg twee verloopstops toe.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Sla het PPTX-bestand op naar schijf.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De ellips met verloopvulling](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Pattern Fill (patroonvulling) een opmaakoptie waarmee je een tweekleurenontwerp—zoals stippen, strepen, kruisstrepen of geruite patronen—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voorgrond en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkelijkheid van je presentaties te verbeteren. Ook nadat je een vooraf gedefinieerd patroon hebt geselecteerd, kun je nog steeds de exacte kleuren opgeven die het moet gebruiken.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) van de vorm in op `Pattern`.
5. Kies een patroonstijl uit de vooraf gedefinieerde opties.
6. Stel de [Background Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipatternformat/get_backcolor/) van het patroon in.
7. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipatternformat/get_forecolor/) van het patroon in.
8. Sla de aangepaste presentatie op als een PPTX‑bestand.

```cpp
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een auto-vorm van het type Rectangle toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Stel het vultype in op Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Stel de patroonstijl in.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Stel de achtergrond- en voorgrondkleuren van het patroon in.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Sla het PPTX-bestand op naar schijf.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Picture Fill (afbeeldingsvulling) een opmaakoptie waarmee je een afbeelding in een vorm kunt plaatsen—effectief gebruik je de afbeelding als achtergrond van de vorm.

Zo gebruik je Aspose.Slides om een afbeeldingvulling toe te passen op een vorm:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) van de vorm in op `Picture`.
5. Stel de afbeeldingvullingsmodus in op `Tile` (of een andere gewenste modus).
6. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)-object van de afbeelding die je wilt gebruiken.
7. Geef de afbeelding door aan de `ISlidesPicture.set_Image`‑methode.
8. Sla de aangepaste presentatie op als een PPTX‑bestand.

Stel dat we een bestand "lotus.png" hebben met de volgende afbeelding:

![De lotusafbeelding](lotus.png)

```cpp
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een auto-vorm van het type Rectangle toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Stel het vultype in op Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Stel de afbeeldingvullingsmodus in.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Laad een afbeelding en voeg deze toe aan de presentatieresources.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Stel de afbeelding in.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Sla het PPTX-bestand op naar schijf.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De vorm met afbeeldingvulling](picture-fill.png)

### **Afbeelding tegel als textuur**

Als je een getegelde afbeelding wilt instellen als textuur en het tegelgedrag wilt aanpassen, kun je de volgende methoden van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/) interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/picturefillformat/) klasse gebruiken:

- [set_PictureFillMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Stelt de afbeeldingvullingsmodus in — `Tile` of `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Geeft de uitlijning van de tegels binnen de vorm op.
- [set_TileFlip](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Bepaalt of de tegel horizontaal, verticaal of beide keren wordt gedraaid.
- [set_TileOffsetX](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [set_TileOffsetY](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [set_TileScaleX](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definieert de horizontale schaal van de tegel als percentage.
- [set_TileScaleY](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definieert de verticale schaal van de tegel als percentage.

```cpp
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto firstSlide = presentation->get_Slide(0);

// Voeg een rechthoekige auto-vorm toe.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Stel het vultype van de vorm in op Picture.
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

// Sla het PPTX-bestand op naar schijf.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Solid Color Fill (effen kleurvulling) een opmaakoptie die een vorm vult met één enkele, egale kleur. Deze effen achtergrondkleur wordt toegepast zonder verlopen, texturen of patronen.

Zo pas je een effen kleurvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) van de vorm in op `Solid`.
5. Wijs de gewenste vullingskleur toe aan de vorm.
6. Sla de aangepaste presentatie op als een PPTX‑bestand.

```cpp
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een auto-vorm van het type Rectangle toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Stel het vultype in op Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Stel de vulkleur in.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Sla het PPTX-bestand op naar schijf.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, wanneer je een effen kleur, verloop, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de doorzichtigheid van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, zodat de achtergrond of onderliggende objecten gedeeltelijk zichtbaar blijven.

Aspose.Slides laat je het transparantieniveau instellen door de alfa‑waarde van de kleur die voor de vulling wordt gebruikt aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) in op `Solid`.
5. Gebruik `Color` om een kleur met transparantie te definiëren (de `alpha`‑component bepaalt de transparantie).
6. Sla de presentatie op.

```cpp
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een solide rechthoekige auto-vorm toe.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Voeg een transparante rechthoekige auto-vorm toe boven de solide vorm.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Sla het PPTX-bestand op naar schijf.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides stelt je in staat om vormen te roteren in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning of ontwerpvereisten.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
5. Sla de presentatie op.

```cpp
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een auto-vorm van het type Rectangle toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Roteer de vorm met 5 graden.
shape->set_Rotation(5);

// Sla het PPTX-bestand op naar schijf.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D‑schuineffecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑schuineffecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/threedformat/)-eigenschappen te configureren.

Om 3D‑schuineffecten aan een vorm toe te voegen, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/threedformat/) van de vorm om de schuine‑instellingen te definiëren.
5. Sla de presentatie op.

```cpp
// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Voeg een vorm toe aan de dia.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Stel de ThreeDFormat-eigenschappen van de vorm in.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Sla de presentatie op als een PPTX-bestand.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![Het 3D‑schuineffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑rotatie‑effecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/threedformat/)-eigenschappen te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Gebruik de [set_CameraType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icamera/set_cameratype/) en [set_LightType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilightrig/set_lighttype/) om de 3D‑rotatie te definiëren.
5. Sla de presentatie op.

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

De volgende C++‑code laat zien hoe je de opmaak van een dia kunt resetten en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/layoutslide/) kunt terugzetten naar de standaardinstellingen:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Reset elke vorm op de dia die een placeholder op de lay-out heeft.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Heeft het opmaken van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen marginaal. Ingesloten afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en vrijwel geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die dezelfde opmaak hebben, zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm — vulling, lijn en effectinstellingen. Als al deze waarden overeenkomen, beschouw je de stijlen als identiek en kun je die vormen logisch groeperen, wat later stijlbeheer vereenvoudigt.

**Kan ik een reeks aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloondia‑set of in een .POTX‑sjabloonbestand. Wanneer je een nieuwe presentatie maakt, open je het sjabloon, kloont je de benodigde gestylede vormen en pas je hun opmaak toe waar nodig.