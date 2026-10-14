---
title: PowerPoint-vormen opmaken in C++
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/cpp/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schetseffect
- schets vormlijn
- samenvoegstijl opmaken
- gradiëntvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart-wit weergave van vormen
- grijswaarden weergave van vormen
- vorm roteren
- 3D afschuineffect
- 3D rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen kunt opmaken in C++ met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Inleiding**

In PowerPoint kun je vormen aan dia's toevoegen. Aangezien vormen bestaan uit lijnen, kun je ze opmaken door de omtrek te wijzigen of effecten toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ biedt interfaces en methoden waarmee je vormen kunt opmaken met dezelfde opties die beschikbaar zijn in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm opgeven. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse aan.
1. Krijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [lijnstijl](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX-bestand.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een AutoShape van het type Rechthoek toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Stel de vulkleur voor de rechthoekvorm in.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Pas opmaak toe op de lijnen van de rechthoek.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Stel de kleur in voor de lijn van de rechthoek.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Sla het PPTX‑bestand op naar schijf.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets-effecten toepassen op vormlijnen**

Een schets-effect laat een vormlijn er handgetekend uitzien. Gebruik [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) om toegang te krijgen tot de lijninstellingen, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) om toegang te krijgen tot de schetsinstellingen, en [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) om een waarde uit de [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) enumeratie te selecteren.

De volgende C++‑code toont hoe je een [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde leest, en het effect verwijdert met [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

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

De waarde die wordt geretourneerd door [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) vertegenwoordigt de instelling die direct aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, masterslide of lay‑outsdia, gebruik dan [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), krijg toegang tot [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), en lees [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat erfenis is opgelost:

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

## **Samenvoegstijlen opmaken**

Dit zijn de drie opties voor het type verbinding:

* Round
* Miter
* Bevel

Standaard, wanneer PowerPoint twee lijnen op een hoek (bijvoorbeeld bij een hoek van een vorm) samenvoegt, gebruikt het de instelling **Round**. Als je echter een vorm met scherpe hoeken tekent, kun je de voorkeur geven aan de **Miter** optie.

![De samenvoegstijl in de presentatie](join-style-powerpoint.png)

De volgende C++‑code toont hoe drie rechthoeken (zoals te zien op de afbeelding hierboven) zijn gemaakt met de Miter-, Bevel‑ en Round‑instellingen voor het type verbinding:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg drie auto shapes van het type Rechthoek toe.
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

// Stel de samenvoegstijl in.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Voeg tekst toe aan elke rechthoek.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Sla het PPTX‑bestand op naar schijf.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gradiëntvulling**

In PowerPoint is Gradiëntvulling een opmaakoptie waarmee je een continue kleurverloop op een vorm kunt toepassen. Bijvoorbeeld kun je twee of meer kleuren gebruiken waarbij de ene geleidelijk in de andere vervaagt.

Met Aspose.Slides kun je een gradiëntvulling toepassen op een vorm:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse aan.
1. Krijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) van de vorm in op `Gradient`.
1. Voeg je twee gewenste kleuren met gedefinieerde posities toe via de `Add`‑methoden van de gradiënt‑stop‑collectie die wordt blootgesteld door de [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/) interface.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een auto shape van het type Ellipse toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Pas gradiëntopmaak toe op de ellipse.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Stel de richting van het gradiënt in.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Voeg twee gradiëntstops toe.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Sla het PPTX‑bestand op naar schijf.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De ellips met gradiëntvulling](gradient-fill.png)

Als een gradiënt er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, zie [Kies een gradiënt‑renderingsstijl](/slides/nl/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Je kunt een renderingsstijl selecteren zonder de opgeslagen gradiëntvulling in de presentatie te wijzigen.

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, kruisselekes of controlepatronen—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voorgrond en achtergrond van het patroon.

Aspose.Slides levert meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te verbeteren. Zelfs nadat je een vooraf gedefinieerd patroon hebt geselecteerd, kun je nog steeds de exacte kleuren specificeren die het moet gebruiken.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse aan.
1. Krijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) van de vorm in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een auto shape van het type Rechthoek toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Stel het vultype in op Patroon.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Stel de patroonstijl in.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Stel de achtergrond- en voorgrondkleuren van het patroon in.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Sla het PPTX‑bestand op naar schijf.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt invoegen—effectief de afbeelding als achtergrond van de vorm gebruiken.

Zo gebruik je Aspose.Slides om een afbeelding te gebruiken als vulling voor een vorm:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse aan.
1. Krijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) van de vorm in op `Picture`.
1. Stel de afbeeldingsvullingmodus in op `Tile` (of een andere gewenste modus).
1. Maak een [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) object van de afbeelding die je wilt gebruiken.
1. Geef de afbeelding door aan de methode `ISlidesPicture.set_Image`.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

![De lotusafbeelding](lotus.png)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een auto shape van het type Rechthoek toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Stel het vultype in op Afbeelding.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Stel de afbeeldingsvullingsmodus in.
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

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding in tegelpatroon gebruiken als textuur**

Als je een getegelde afbeelding wilt instellen als textuur en het tegelgedrag wilt aanpassen, kun je de volgende methoden van de [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) interface en de [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) klasse gebruiken:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Stelt de afbeeldingsvullingsmodus in—ofwel `Tile` of `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Bepaalt de uitlijning van de tegels binnen de vorm.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Regelt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definieert de horizontale schaal van de tegel als een percentage.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definieert de verticale schaal van de tegel als een percentage.

De volgende code‑voorbeeld laat zien hoe je een rechthoekvorm met een getegelde afbeeldingsvulling kunt toevoegen en tegelopties kunt configureren:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto firstSlide = presentation->get_Slide(0);

// Voeg een rechthoekige auto shape toe.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Stel het vultype van de vorm in op Afbeelding.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Laad de afbeelding en voeg deze toe aan de presentatieresources.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Ken de afbeelding toe aan de vorm.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Configureer de afbeeldingsvullingsmodus en tegel‑eigenschappen.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Sla het PPTX‑bestand op naar schijf.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm vult met één uniforme kleur. Deze eenvoudige achtergrondkleur wordt toegepast zonder kleurverlopen, texturen of patronen.

Om een effen kleurvulling toe te passen op een vorm met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse aan.
1. Krijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) van de vorm in op `Solid`.
1. Wijs je gewenste vulkleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een auto shape van het type Rechthoek toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Stel het vultype in op Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Stel de vulkleur in.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Save the PPTX file to disk.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je bij een effen kleur, gradiënt, afbeelding of textuurvulling van vormen ook een transparantieniveau instellen om de dekking van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, waardoor de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides stelt je in staat het transparantieniveau in te stellen door de alfa‑waarde in de gebruikte kleur voor de vulling aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse aan.
1. Krijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color` om een kleur met transparantie te definiëren (de `alpha`‑component regelt de transparantie).
1. Sla de presentatie op.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een solide rechthoekige auto shape toe.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Voeg een transparante rechthoekige auto shape toe boven de solide vorm.
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

Aspose.Slides maakt het mogelijk om vormen in PowerPoint‑presentaties te roteren. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning of ontwerpbehoeften.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse aan.
1. Krijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Haal de eerste dia op.
auto slide = presentation->get_Slide(0);

// Voeg een auto shape van het type Rechthoek toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Roteer de vorm met 5 graden.
shape->set_Rotation(5);

// Sla het PPTX-bestand op naar schijf.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De rotatie van de vorm](shape-rotation.png)

## **3D-afschuineffecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑afschuineffecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑afschuineffecten toe te voegen aan een vorm, volg je deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse.
1. Krijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) van de vorm om afschuinstellingen te definiëren.
1. Sla de presentatie op.

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

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

![Het 3D-afschuineffect](3D-bevel-effect.png)

## **3D-rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑rotatie‑effecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑rotatie toe te passen op een vorm:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse.
1. Krijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Gebruik [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) en [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

![Het 3D-rotatie‑effect](3D-rotation-effect.png)

## **Zwart‑wit weergave voor vormen beheren**

De methode [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) specificeert hoe een individuele vorm wordt gerenderd wanneer een presentatie wordt bekeken of verwerkt in zwart‑wit‑modus. Het activeert niet zelf een zwart‑wit‑weergave en verandert de vul‑, lijn‑ of andere opmaak van de vorm niet in de normale kleermodus.

Gebruik een waarde uit de enumeratie [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de render‑applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijze kleuring, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` forceren één kleur, `Color` behoudt de normale kleuren, en `Hidden` laat de vorm weg in zwart‑wit‑modus. `NotDefined` betekent dat er geen modus op vormniveau is toegewezen.

De volgende C++‑code maakt een gekleurde vorm aan en laat deze grijs verschijnen in de zwart‑wit‑weergavemodus:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// Behoud de oranje vulling in kleurmodus, maar render de vorm met grijze kleur in zwart-wit modus.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

In de normale kleermodus behoudt de rechthoek zijn oranje vulling. In een zwart‑wit‑workflow wordt deze grijs weergegeven omdat de modus is ingesteld op `Gray`. Hierdoor kun je een volledige‑kleur dia behouden terwijl je een aparte weergave definieert voor afdrukken, previewen of andere workflows die de zwart‑wit‑weergave‑instellingen van de presentatie respecteren.

## **Opmaak resetten**

De volgende C++‑code laat zien hoe je de opmaak van een dia kunt resetten en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // Reset elke vorm op de dia die een placeholder op de lay-out heeft.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Heeft de opmaak van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingebedde afbeeldingen en media nemen het grootste deel van de ruimte in, terwijl vormparameters zoals kleuren, effecten en kleurverlopen als metadata worden opgeslagen en nauwelijks extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vul, lijn en effectinstellingen. Als alle overeenkomstige waarden gelijk zijn, behandel je hun stijlen als identiek en groepeer je die vormen logisch, wat later stijlbeheer vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Bewaar voorbeeldvormen met de gewenste stijlen in een sjabloondia‑set of een .POTX‑sjabloonbestand. Wanneer je een nieuwe presentatie maakt, open je het sjabloon, kloon je de gewenste gestylede vormen, en pas je hun opmaak opnieuw toe waar nodig.