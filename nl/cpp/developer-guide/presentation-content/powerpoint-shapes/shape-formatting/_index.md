---
title: Vormopmaak van PowerPoint‑vormen in C++
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/cpp/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets‑effect
- schetsvormlijn
- samenvoegingsstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart‑wit vormrendering
- grijswaarden vormrendering
- vorm roteren
- 3D‑afschuinings‑effect
- 3D‑rotatie‑effect
- opmaak resetten
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u PowerPoint‑vormen kunt opmaken in C++ met Aspose.Slides — stel vullings-, lijn‑ en effectstijlen in voor PPT‑ en PPTX‑bestanden met precisie en volledige controle."
---
## **Inleiding**

Formatteer vormen in PowerPoint door hun lijnen, vullingen en effecten aan te passen. Aspose.Slides for C++ stelt je in staat deze instellingen programmatically te beheersen, inclusief transparantie, rotatie en 3D‑opmaak.

![Vormopmaakopties in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for C++ biedt interfaces en methoden die je in staat stellen vormen op te maken met dezelfde opties die in PowerPoint beschikbaar zijn.

## **Lijnen opmaken**

Gebruik [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) om de omtrek van een vorm te regelen. Dit voorbeeld maakt een niet‑gevulde rechthoek met een blauwe, gestreepte omtrek. [ILineFormat::set_Style](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_style/) selecteert een dik‑dun samengestelde lijn, terwijl [ILineFormat::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) de breedte op 7 punten zet en [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) het streeppatroon kiest.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

### **Aangepaste lijnstreeppatronen instellen**

Gebruik [ILineFormat::set_CustomDashPattern](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_customdashpattern/) wanneer vooraf gedefinieerde lijnstijlen niet de gewenste streep‑ en tussenruimtelengtes bieden, bijvoorbeeld voor merk‑omtrekken of technische diagrammen. Het toewijzen van een patroon wijzigt automatisch de streepstijl naar [LineDashStyle::Custom](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/).

Array‑items wisselen af tussen streep‑ en tussenruimtelengtes, beginnend met een streep. Elke waarde is een veelvoud van de lijnbreedte: `{ 4, 2 }` bij een breedte van 3 pt levert een 12‑pt streep gevolgd door een 6‑pt tussenruimte op. Gebruik paren van eindige, niet‑negatieve waarden om volledige streep‑en‑tussensegmenten te definiëren. Het voorbeeld gebruikt positieve waarden zodat elke streep en tussenruimte zichtbaar blijft.

Dit voorbeeld maakt vijf blauwe lijnen met dezelfde lengte en platte caps. De eerste drie vergelijken patronen bij een breedte van 3 pt. De vierde herhaalt het eerste patroon met dubbele breedte, waardoor zowel de streep‑ als de tussenlengtes verdubbelen. De vijfde schakelt van een aangepast patroon naar een effen lijn.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(600, 300, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto patterns = std::array<ArrayPtr<float>, 5>{
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 1, 2 }),
    MakeArray<float>({ 6, 2, 1, 2 }),
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 4, 2 })
};

for (auto i = 0; i < patterns.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 50, 50 + i * 50, 500, 0);
    line->get_LineFormat()->set_Width(i == 3 ? 6 : 3);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_CapStyle(LineCapStyle::Flat);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_CustomDashPattern(patterns[i]);
}

// Return the last line to a solid style.
slide->get_Shape(4)->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);

presentation->Save(u"custom_dash_patterns.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Om in plaats daarvan terug te keren naar een vooraf gedefinieerde gestreepte stijl, geef je [LineDashStyle::Dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) door aan [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/). De geselecteerde stijl bepaalt het uiterlijk van de lijn.

Het resultaat in PowerPoint, van boven naar beneden: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; en **Solid, 3 pt**.

![Drie aangepaste streeppatronen, een dikkere lijn met het eerste patroon, en een effen lijn in PowerPoint](custom-dash-patterns.png)


### **Lijncaps instellen**

Gebruik [ILineFormat::set_CapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_capstyle/) om de uiteinden van een open lijn in te stellen. De [LineCapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linecapstyle/)‑enumeratie biedt drie expliciete cap‑stijlen:

- `Flat`: De lijn stopt bij het eindpunt.
- `Round`: Een halve cirkelvormige cap strekt zich half de lijnbreedte voorbij het eindpunt uit.
- `Square`: Een vierkante cap strekt zich half de lijnbreedte voorbij het eindpunt uit.

De enumeratie bevat ook `NotDefined`, wat betekent dat er geen cap‑stijl expliciet is toegewezen.

Caps verschillen van pijlpunten, die symbolen aan het uiteinde van een lijn toevoegen, en van joins, die hoeken tussen lijnsegmenten regelen. Dit voorbeeld schakelt pijlpunten uit via [ILineFormat::set_BeginArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_beginarrowheadstyle/) en [ILineFormat::set_EndArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_endarrowheadstyle/) zodat alleen de cap‑vormen worden vergeleken.

Het volgende voorbeeld maakt drie verder identieke horizontale lijnen van 20 pt breed. Van boven naar beneden gebruiken ze platte, ronde en vierkante caps. Hun eindpunten hebben dezelfde horizontale coördinaten; de ronde en vierkante caps steken 10 pt voorbij elk eindpunt uit.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 240, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto capStyles = std::array<LineCapStyle, 3>{ LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square };

for (auto i = 0; i < capStyles.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 100, 50 + i * 70, 300, 0);
    line->get_LineFormat()->set_Width(20);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);
    line->get_LineFormat()->set_CapStyle(capStyles[i]);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
}

presentation->Save(u"line_caps.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat in PowerPoint, van boven naar beneden: **Flat**, **Round**, en **Square**.

![Platte, ronde en vierkante caps op identieke dikke lijnen in PowerPoint](line-caps.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect laat een vormlijn eruitzien alsof deze met de hand is getekend. Gebruik [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) om de lijninstellingen te benaderen, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) om de schetsinstellingen te benaderen, en [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) om een waarde uit de [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/)‑enumeratie te selecteren.

De volgende C++‑code toont hoe je een [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde uitleest, en het effect verwijdert met [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();
sketchFormat->set_SketchType(LineSketchType::Curved);
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

De waarde die wordt geretourneerd door [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) vertegenwoordigt de instelling die direct aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, master‑dia of layout‑dia, gebruik dan [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), benader [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), en lees [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat overerving is opgelost. Dit voorbeeld vereist een bestaande presentatie met ten minste één vorm op de eerste dia en print beide waarden:

```cpp
#include <DOM/ILineFormat.h>
#include <DOM/ILineFormatEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISketchFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

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

## **Samenvoegingsstijlen opmaken**

Hier zijn de drie opties voor het type verbinding:

* Round
* Miter
* Bevel

De samenvoegingsstijl bepaalt hoe twee omtreksegmenten elkaar ontmoeten op een hoek. Gebruik **Round** voor afgeronde hoeken, **Miter** voor scherpe hoeken, of **Bevel** voor afgeplatte hoeken.

![De samenvoegingsstijl in de presentatie](join-style-powerpoint.png)

Dit voorbeeld maakt drie zwarte rechthoeken met blauwe omtrekken van 15 pt breed. Het stelt [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) in op respectievelijk de miter‑, bevel‑ en round‑waarden van [LineJoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) om te vergelijken hoe de hoeken worden getekend.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto miterShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto bevelShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto roundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

miterShape->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
bevelShape->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
roundShape->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

miterShape->get_LineFormat()->set_Width(15);
bevelShape->get_LineFormat()->set_Width(15);
roundShape->get_LineFormat()->set_Width(15);

miterShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
bevelShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
roundShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

miterShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
bevelShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
roundShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

miterShape->get_TextFrame()->set_Text(u"Miter Join Style");
bevelShape->get_TextFrame()->set_Text(u"Bevel Join Style");
roundShape->get_TextFrame()->set_Text(u"Round Join Style");

presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Miter‑verbindingen beperken bij scherpe hoeken**

Gebruik [ILineFormat::set_MiterLimit](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_miterlimit/) in combinatie met [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) ingesteld op [LineJoinStyle::Miter](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) om te beperken hoe ver een scherpe hoek mag uitsteken.

De limiet is de verhouding tussen de afstand van de binnen‑ en buitenhoek van de join en de lijnbreedte. Een waarde van `8` staat een miter‑lengte toe tot acht keer de lijnbreedte; het is geen meting in punten. Als de hoek de limiet zou overschrijden, gebruikt PowerPoint een afgeplatte join op die hoek. Een grotere limiet maakt scherpere punten mogelijk. De instelling beïnvloedt alleen miter‑joins, en wijzigen heeft geen waarneembaar effect wanneer de hoek binnen beide limieten blijft.

Dit voorbeeld maakt twee identieke, niet‑gevulde driehoeken met omtrekken van 20 pt breed. De linker driehoek gebruikt een limiet van `2`, de rechter een limiet van `8`. Elke driehoek is 80 pt breed en 160 pt hoog, waardoor de bovenste hoek een miter‑lengte‑tot‑lijnbreedte‑verhouding van ongeveer `4.12` heeft. Daardoor vlakt PowerPoint de linker top af en behoudt het rechter punt.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 320, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto miterLimits = std::array<float, 2>{ 2.0f, 8.0f };

for (auto i = 0; i < miterLimits.size(); i++)
{
    auto triangle = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 90 + i * 240, 110, 80, 160);
    triangle->get_FillFormat()->set_FillType(FillType::NoFill);
    triangle->get_LineFormat()->set_Width(20);
    triangle->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    triangle->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    triangle->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
    triangle->get_LineFormat()->set_MiterLimit(miterLimits[i]);
}

presentation->Save(u"miter_limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat in PowerPoint: **Miter limit 2** aan de linkerkant en **miter limit 8** aan de rechterkant.

![Een afgeplatte top met miter‑limiet 2 en een puntige top met miter‑limiet 8 in PowerPoint](miter-limits.png)

## **Verloopvulling**

Een verloopvulling mengt kleuren over een vorm. Dit voorbeeld vult een ellips met een lineair verloop onder een hoek van 45 graden van rood naar paars via [IFillFormat::get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_gradientformat/). De [IGradientStopCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/igradientstopcollection/add/)‑methode plaatst de kleurstops op 0 en 1, het begin en het einde van het verloop. Het wissen van de bestaande stops zorgt ervoor dat alleen deze twee kleuren worden gebruikt.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);
shape->get_FillFormat()->get_GradientFormat()->set_LinearGradientAngle(45);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Clear();
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De ellips met verloopvulling](gradient-fill.png)

Als een verloop er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, zie dan [Choose a Gradient Rendering Style](/slides/nl/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Je kunt een renderingsstijl selecteren zonder de in de presentatie opgeslagen verloopvulling te wijzigen.

### **Lineaire verloophoek instellen**

Gebruik [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) om de richting van een [GradientShape::Linear](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/)‑vulling te bepalen. De hoek wordt gemeten in graden en neemt met de klok mee toe: `0` loopt van links naar rechts, `90` van boven naar beneden, `180` van rechts naar links, en `270` van onder naar boven. Fractionele hoeken worden ondersteund. Eindige hoeken buiten `[0, 360)` worden genormaliseerd tot één omwenteling; bijvoorbeeld, `-45` wordt `315` en `360` wordt `0`.

Dit voorbeeld maakt zes rechthoeken met identieke rode, groene en blauwe stops op posities `0`, `0.5` en `1`. Schalen is uitgeschakeld zodat de hoek onafhankelijk van de verhoudingen van de rechthoeken kan worden vergeleken. De hoeken, van links naar rechts, zijn `0`, `45` en `90` in de eerste rij, en `135`, `180` en `270` in de tweede rij.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto angles = std::array<float, 6>{ 0, 45, 90, 135, 180, 270 };

for (auto i = 0; i < angles.size(); i++)
{
    auto x = 30 + (i % 3) * 230;
    auto y = 30 + (i / 3) * 190;

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 200, 150);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::False);
    gradient->set_LinearGradientAngle(angles[i]);
}

presentation->Save(u"linear_gradient_angles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat in PowerPoint:

![Lineaire verlopen op 0, 45 en 90 graden in de bovenste rij, en 135, 180 en 270 graden in de onderste rij](linear-gradient-angles.png)

### **Lineair verloop schalen met de vorm**

[IGradientFormat::set_LinearGradientScaled](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientscaled/) accepteert een [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/). Stel deze expliciet in op `False` om de geometrische verloophoek te behouden wanneer de verhoudingen van de vorm veranderen, of op `True` om het verloop te schalen met de breedte en hoogte van de vorm. Met schalen ingeschakeld kan de zichtbare hoek afwijken van de toegewezen hoek op een niet‑vierkante vorm.

Het volgende voorbeeld gebruikt een hoek van `45` graden en dezelfde kleurstops als de hoekvergelijking. De linkerkolom gebruikt `False`; de rechterkolom gebruikt `True`. Elke kolom bevat een brede rechthoek boven een hoge rechthoek. Beide starten met dezelfde brede afmetingen; het wijzigen van de breedte en hoogte van de tweede rechthoek toont hoe de vulling reageert op grootte‑aanpassing zonder de verloopinstellingen te veranderen.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 460, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto scalingOptions = std::array<NullableBool, 2>{ NullableBool::False, NullableBool::True };

for (auto column = 0; column < scalingOptions.size(); column++)
{
    for (auto row = 0; row < 2; row++)
    {
        auto x = 30 + column * 360;
        auto y = row == 0 ? 30 : 150;

        auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 300, 90);
        shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
        shape->get_FillFormat()->set_FillType(FillType::Gradient);

        auto gradient = shape->get_FillFormat()->get_GradientFormat();
        gradient->set_GradientShape(GradientShape::Linear);
        gradient->get_GradientStops()->Clear();
        gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
        gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
        gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
        gradient->set_LinearGradientAngle(45);
        gradient->set_LinearGradientScaled(scalingOptions[column]);

        if (row == 1)
        {
            shape->set_Width(90);
            shape->set_Height(280);
        }
    }
}

presentation->Save(u"linear_gradient_scaling.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat in PowerPoint, met schalen uitgeschakeld aan de linkerkant en ingeschakeld aan de rechterkant:

![Brede en hoge rechthoeken met een 45‑graden verloop, vergelijking LinearGradientScaled False links met True rechts](linear-gradient-scaling.png)

Met schalen uitgeschakeld behouden de diagonale kleurbanden dezelfde oriëntatie in beide rechthoeken. Met schalen ingeschakeld rekken de banden zich uit volgens de verhoudingen van de vorm. Dit helpt om een sjabloon‑verloop te reproduceren bij het aanpassen van een vorm naar een andere grootte. Op een vierkant verandert het inschakelen van schalen de weergave van dit `45`‑graden verloop niet.

Zowel de hoek‑ als de schalingsinstellingen gelden voor lineaire verlopen. Ze regelen niet [GradientShape::Radial of GradientShape::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/)‑vullingen.

### **Hoek combineren met verlooprichting**

[IGradientFormat::set_GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_gradientdirection/) selecteert een verloopstijl uit de [GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/gradientdirection/)‑enumeratie; het is geen vervanging voor een numerieke hoek. Voor een lineair verloop kunnen de hoekstijlen het gebied waarin kleuren worden verdeeld wijzigen zonder de hoek die met [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) is toegewezen te veranderen. Houd de richting ongewijzigd bij het vergelijken van hoeken of schalen.

Het volgende voorbeeld past dezelfde instellingen toe in omgekeerde volgorde. De twee rechthoeken hebben hetzelfde uiterlijk: eerst de richting instellen en daarna de hoek (of omgekeerd) verandert het resultaat niet.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
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

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30 + i * 140, 320, 100);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::True);

    if (i == 0)
    {
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
        gradient->set_LinearGradientAngle(30);
    }
    else
    {
        gradient->set_LinearGradientAngle(30);
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
    }
}

presentation->Save(u"linear_gradient_direction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Patroonvulling**

Een patroonvulling brengt een twee‑kleurig ontwerp aan, zoals stippen, strepen of geruite patronen. Dit voorbeeld gebruikt [IPatternFormat::set_PatternStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/set_patternstyle/) om een rasterschema te selecteren. [IPatternFormat::get_BackColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) levert de lichtgrijze achtergrond, en [IPatternFormat::get_ForeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) levert de gele patroonkleur.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Pattern);
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

Een afbeeldingsvulling gebruikt een afbeelding binnen een vorm. Dit voorbeeld vereist een lokale afbeelding en laadt deze via [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) in de afbeeldingscollectie van de presentatie. Het instellen van [IPictureFillFormat::set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) op de tegelmodus (Tile) herhaalt de afbeelding binnen de rechthoek. De gebruikte bronafbeelding staat hieronder:

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
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

auto image = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(image);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(presentationImage);

presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
image->Dispose();
presentation->Dispose();
```

Het resultaat:

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding als tegel gebruiken**

Als je een getegelde afbeelding wilt instellen als textuur en het tegel‑gedrag wilt aanpassen, kun je de volgende methoden van de [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/)‑interface en de [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/)‑klasse gebruiken:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Stelt de afbeeldingvullingsmodus in – `Tile` of `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Bepaalt de uitlijning van de tegels binnen de vorm.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Regelt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Stelt de horizontale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Stelt de verticale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definieert de horizontale schaal van de tegel als een percentage.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definieert de verticale schaal van de tegel als een percentage.

Dit voorbeeld vereist een lokale afbeelding en configureert [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) om deze te herhalen op 50 % van de oorspronkelijke grootte. Offsets van −32 pt verschuiven de tegels horizontaal en verticaal; uitlijning rechtsonder en spiegelen in beide richtingen bepalen hoe de herhaalde textuur wordt gerangschikt.

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
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);

auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
shape->get_FillFormat()->set_FillType(FillType::Picture);

auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);

auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

presentation->Save(u"tile.pptx", SaveFormat::Pptx);
sourceImage->Dispose();
presentation->Dispose();
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Vulling met effen kleur**

Een effen vulling geeft een vorm één enkele, uniforme kleur. Dit voorbeeld stelt [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) in op de modus voor effen vulling en kent geel toe via [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/), waarna de rechthoek in een presentatie wordt opgeslagen.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Gebruik de dia‑achtergrond als vulling voor een vorm**

Gebruik [IAutoShape::set_UseBackgroundFill](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/set_usebackgroundfill/) wanneer een vorm moet overeenkomen met de dia‑achtergrond, bijvoorbeeld in een presentatiesjabloon. Stel eerst [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) in op [FillType::NotDefined](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) om eventuele expliciete vulling te verwijderen. Met deze combinatie gebruikt de vorm de dia‑achtergrond in plaats van zijn eigen vulling. Alleen de vlag inschakelen verwijdert niet een reeds bestaande expliciete vulling.

Dit verschilt van [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/): een achtergrondvulling bedekt objecten achter de vorm met het overeenkomstige gebied van de dia‑achtergrond, terwijl geen vulling die objecten zichtbaar laat. Een verloop blijft uitgelijnd met de dia in plaats van opnieuw te starten binnen elke vorm.

Het volgende voorbeeld maakt een master‑achtergrond die door de dia wordt geërfd en plaatst een magentabanier achter drie rechthoeken. De linkse rechthoek gebruikt de achtergrond, de middelste heeft geen vulling, en de rechtse schakelt van achtergrondvulling naar een expliciete oranje vulling.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

// Erf het verloop van de master.
slide->get_Background()->set_Type(BackgroundType::NotDefined);
slide->get_LayoutSlide()->get_Background()->set_Type(BackgroundType::NotDefined);
auto background = slide->get_LayoutSlide()->get_MasterSlide()->get_Background();
background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Gradient);
auto gradient = background->get_FillFormat()->get_GradientFormat();
gradient->set_GradientShape(GradientShape::Linear);
gradient->set_LinearGradientAngle(0);
gradient->get_GradientStops()->Clear();
gradient->get_GradientStops()->Add(0, Color::get_DarkBlue());
gradient->get_GradientStops()->Add(1, Color::get_LightSkyBlue());

// Voeg dit object eerst toe zodat het achter de rechthoeken verschijnt.
auto band = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Magenta());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto backgroundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
backgroundShape->get_FillFormat()->set_FillType(FillType::NotDefined);
backgroundShape->set_UseBackgroundFill(true);

auto noFillShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
noFillShape->get_FillFormat()->set_FillType(FillType::NoFill);

auto explicitShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
explicitShape->get_FillFormat()->set_FillType(FillType::NotDefined);
explicitShape->set_UseBackgroundFill(true);

// Schakel achtergrondvulling uit voordat een expliciete vulling wordt toegepast.
explicitShape->set_UseBackgroundFill(false);
explicitShape->get_FillFormat()->set_FillType(FillType::Solid);
explicitShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

presentation->Save(u"background_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat, van links naar rechts: **achtergrondvulling**, **geen vulling**, en **expliciete vulling**. Het magentabanier wordt verborgen door de linker‑ en rechter‑rechthoeken maar blijft zichtbaar door de middelste rechthoek.

![Achtergrondvulling, geen vulling en expliciete oranje vulling over een magentabanier](background-fill.png)

Hetzelfde gedrag geldt voor een achtergrond die direct op de dia is gedefinieerd of van een layout is geërfd. De vorm gebruikt de uiteindelijk bepaalde dia‑achtergrond; het voorbeeld laat zowel de dia‑ als layout‑achtergronden ongedefinieerd zodat de master ze levert.

## **Transparantie instellen**

Voor een effen vulling bepaalt het alfa‑component van de kleur de doorzichtigheid: 0 is volledig transparant en 255 volledig ondoorzichtig. Dit voorbeeld gebruikt een alfa‑waarde van 128 voor een gele rechthoek, waardoor deze ongeveer 50 % transparant is zodat de onderliggende rechthoek zichtbaar blijft. De kleur wordt toegewezen via [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/).

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const int alpha = 128;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, Color::get_Yellow()));

presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Gebruik [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) om een vorm in het dia‑vlak te roteren. De hoek wordt gemeten in graden; dit voorbeeld roteert een rechthoek 5 graden met de klok mee en slaat de presentatie op.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->set_Rotation(5);

presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D‑afschuinings‑effecten toevoegen**

Gebruik [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) om een vorm diepte en afgewerkte randen te geven. Dit voorbeeld maakt een groene ellips met een oranje omtrek, stelt [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) in op 4 pt, en past een ronde boven‑afschuining toe met een breedte en hoogte van 6 pt via [IThreeDFormat::get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/). Een front‑gerichte orthografische camera en drie‑punt verlichting maken de afschuining zichtbaar.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);
shape->get_ThreeDFormat()->set_Depth(4);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![Het 3D‑afschuiningseffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Het 3D‑beeld van een vorm wordt geregeld door de camera‑instellingen. Dit voorbeeld gebruikt [ICamera::SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) met breedte‑, lengte‑ en rotatiehoeken van respectievelijk 40, 35 en 20 graden. Het selecteert een isometrische camera via [ICamera::set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) en een uitgebalanceerde verlichting via [ILightRig::set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/), waarna de opgemaakte rechthoek wordt opgeslagen.

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
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
autoShape->get_TextFrame()->set_Text(u"Hello, Aspose!");
autoShape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
autoShape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
autoShape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart‑wit weergave van vormen beheren**

De methode [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) specificeert hoe een individuele vorm wordt gerenderd wanneer een presentatie in zwart‑wit modus wordt bekeken of verwerkt. Het activeert niet zelf een zwart‑wit weergave en verandert de vulling, lijn of andere opmaak van de vorm niet in de normale kleurmodus.

Gebruik een waarde uit de [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/)‑enumeratie om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de rendering‑applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijze tinten, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` forceren één kleur, `Color` behoudt de normale kleuren, en `Hidden` laat de vorm weg in zwart‑wit modus. `NotDefined` betekent dat er geen modus op vormniveau is toegewezen.

Dit voorbeeld maakt een oranje rechthoek en stelt [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) in op grijs. De opgeslagen vorm behoudt zijn oranje vulling voor normale kleurweergave en vraagt grijze weergave aan applicaties die zwart‑wit weergave-instellingen respecteren:

```cpp
#include <DOM/BlackWhiteMode.h>
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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

In de normale kleurmodus behoudt de rechthoek zijn oranje vulling. In een zwart‑wit workflow wordt grijze weergave gebruikt omdat de modus op `Gray` staat. Zo kun je een volledig‑kleur dia behouden terwijl je een aparte weergave definieert voor afdrukken, voorvertoningen of andere workflows die de zwart‑wit weergave‑instellingen van de presentatie respecteren.

## **Opmaak resetten**

Gebruik [ISlide::Reset](https://reference.aspose.com/slides/cpp/aspose.slides/islide/reset/) om de positie, grootte en opmaak van dia‑placeholders te herstellen vanuit de overeenkomstige layout‑placeholders. Dit voorbeeld vereist een bestaande presentatie met layout‑gekoppelde placeholders en reset elke dia vóór het opslaan. Vormen zonder overeenkomstige layout‑placeholders worden niet gereset.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Heeft vormopmaak invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Kleuren, lijnstijlen en effect‑instellingen voegen over het algemeen weinig data toe in vergelijking met ingesloten afbeeldingen en media. Afbeeldingsvullingen kunnen de bestandsgrootte vergroten omdat hun afbeeldingen in de presentatie worden opgeslagen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm – vulling, lijn en effect‑instellingen. Als alle overeenkomstige waarden overeenkomen, beschouw hun stijlen dan als identiek en groepeer die vormen logisch, wat later stijlbeheer vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloon‑presentatie of een .POTX‑sjabloonbestand. Wanneer je een nieuwe presentatie maakt, open je de sjabloon, kloont de gestileerde vormen die je nodig hebt, en pas je hun opmaak toe waar nodig.