---
title: Aangepaste presentatievormen in C++
linktitle: Aangepaste vorm
type: docs
weight: 20
url: /nl/cpp/custom-shape/
keywords:
- aangepaste vorm
- vorm toevoegen
- vorm maken
- vorm wijzigen
- vormgeometrie
- geometriepad
- padpunten
- bewerkpunten
- punt toevoegen
- punt verwijderen
- bewerkingsoperatie
- afgeronde hoek
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Vormen maken en aanpassen in PowerPoint-presentaties met Aspose.Slides voor C++: geometrie-paden, afgeronde hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe je presentaties vormen kunt aanpassen in Aspose.Slides door de vormgeometrie te bewerken via bewerkpunten en geometrie‑paden. Het toont hoe je met [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) en [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) bestaande vormen kunt wijzigen, basisbewerkingsbewerkingen kunt uitvoeren, punten kunt toevoegen of verwijderen, en de bijgewerkte geometrie terug kunt toepassen op een vorm.

Het laat ook zien hoe je aangepaste en samengestelde vormen kunt maken, vormen met afgeronde hoeken kunt bouwen, en kunt bepalen of een vormgeometrie gesloten is.

## **Een Vorm Wijzigen met Bewerkpunten**

In PowerPoint kun je **Bewerkpunten** gebruiken om een vierkant aan te passen:

* Een hoek naar binnen of buiten verplaatsen.
* De kromming op een punt aanpassen.
* Nieuwe punten toevoegen.

Bewerkpunten laten je de omtrek van een vorm wijzigen of een bestaande vorm als basis gebruiken voor een nieuwe.

## **Tips voor Vormbewerking**

![overview_image](custom_shape_0.png)

Houd bij het bewerken van PowerPoint‑vormen rekening met de volgende concepten:

* Een vorm (of het pad ervan) kan gesloten of open zijn.
* Het pad van een vorm bestaat uit ankerpunten die door segmenten met elkaar verbonden zijn.
* Een segment kan recht of gebogen zijn. Ankerpunten en controlehandgrepen bepalen de vorm ervan.
* Ankerpunten bestaan als hoekpunten, rechte punten of gladde punten:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een glad punt zijn de twee controlehandgrepen uitgelijnd en even ver van het ankerpunt verwijderd.
  * Bij een recht punt zijn de twee controlehandgrepen uitgelijnd maar kunnen ze verschillende afstanden tot het ankerpunt hebben.
* Het verplaatsen van ankerpunten of het aanpassen van hun handgrepen verandert de omtrek van de vorm.

Om PowerPoint‑vormen te bewerken via bewerkpunten, biedt **Aspose.Slides** de klasse [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) en de interface [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Een [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)‑instantie staat voor een geometrie‑pad van het object [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Om het [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) op te halen van de [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/)-instantie, kun je de methode [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) gebruiken.
* Om het [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) voor een vorm in te stellen, kun je deze methoden gebruiken: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) voor vormen met één enkel pad en [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) voor vormen met meerdere paden.
* Om segmenten toe te voegen, kun je de methoden onder [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) gebruiken.
* Met de methoden [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) en [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) kun je het uiterlijk van een geometrie‑pad instellen.
* Met de methode [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) kun je het geometrie‑pad van een [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) ophalen als een reeks padsegmenten.

## **Eenvoudige Bewerkingstaken**

Gebruik de volgende methoden om een geometrie‑pad te bewerken. Overloads die een index accepteren, voegen een segment in op die nul‑gebaseerde positie in de segment‑array van het pad.

| Operatie | Methode |
| --- | --- |
| Een rechte lijn toevoegen of invoegen. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Een kubieke Bézier‑curve met twee controlepunten en een eindpunt toevoegen of invoegen. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Een kwadratische Bézier‑curve met één controlepunt en een eindpunt toevoegen of invoegen. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Een elliptische boog met de opgegeven afmetingen en hoeken in graden toevoegen. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| De huidige figuur sluiten door het eindpunt te verbinden met het startpunt. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Het startpunt van een figuur instellen. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Een segment verwijderen op een nul‑gebaseerde index. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Aangepaste Punten Aan Een Vorm Toevoegen**

Dit voorbeeld voegt twee punten in een rechthoekige vorm in met [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) en past het bewerkte pad toe met [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). De coördinaten zijn lokaal t.o.v. de vorm: beide nieuwe punten staan in het midden, 100 punten vanaf de linkerkant en 50 punten vanaf de bovenkant. Segmentindices 1 en 4 plaatsen ze respectievelijk op de boven‑ en onderrand, waardoor die randen naar binnen worden getrokken.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Punten Van Een Vorm Verwijderen**

Dit voorbeeld wijzigt de omtrek van een hartvorm door het segment op nul‑gebaseerde index 2 te verwijderen met [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Het toepassen van het aangepaste pad met [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) werkt de contour van de vorm bij.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Een Aangepaste Vorm Maken**

Dit voorbeeld bouwt een ster met vijf punten met behulp van [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Afwisselend buiten‑ en binnenstraal van 100 en 50 punten bepalen de punten en inkepingen; een stap van 72 graden verdeelt de vijf punten gelijkmatig. Het pad wordt gesloten met [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) en toegepast op een rechthoekige vorm met [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), waardoor de omtrek wordt vervangen.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **Een Samengestelde Aangepaste Vorm Maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)‑objecten voor respectievelijk het boven‑ en onderste derde deel van een vorm. Het toepassen van beide paden met [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) creëert één samengestelde vorm met een opening over het middelste derde deel.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(0.0f, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **Een Aangepaste Vorm Met Afgeronde Hoeken Maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) om een vorm met naar binnen gebogen hoeken te creëren. Elke hoekgrootte stelt de breedte en hoogte van de boog in punten in, en de -90‑graden sweep tekent een tegen‑de‑klok kwart‑ellips. Het voltooide pad wordt toegepast met [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), en de presentatie wordt opgeslagen in PPTX‑formaat.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Controleren Of Een Vormgeometrie Gesloten Is**

De volgende helper controleert of elke niet‑lege geometrie‑pad eindigt met een sluitsegment. Hij leest [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) en vergelijkt de laatste segment‑[IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) met [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Hij retourneert false wanneer er geen niet‑lege paden zijn. Deze controle kijkt naar het laatste commando van elk pad; hij inspecteert niet elk sub‑figuur binnen een pad. Het voorbeeld geeft `True` weer voor een rechthoek.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **Vorm‑Elementen Extracten en Inspecteren**

Gebruik [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) om een bestaande vorm te inspecteren als elementen die padpunten en punt‑typen bevatten. Cast elk geretourneerd [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) naar [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) om de arrays te lezen die worden geretourneerd door [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) en [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Deze representatie is nuttig voor contouranalyse of voor het doorgeven van geometrie aan aangepaste teken‑tools.

Het voorbeeld opent een presentatie, vindt de eerste geometrie‑vorm direct op de eerste dia, en drukt de padsegmenten ervan af. Gebruik een presentatie met een vorm die zowel rechte als gebogen segmenten bevat om beide soorten output te zien. Het zoekt niet binnen groepen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // Houd het segmenttype bij, exclusief vlaggen.
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // Verbruik beide controlepunten en het eindpunt.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

De arrays corresponderen per index: `points[i]` is een punt en `types[i]` beschrijft de rol ervan. Type `0` start een figuur, en type `1` trekt een lijn van het vorige punt naar het huidige punt. Een kubisch Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus verwerkt deze drie items samen en controleert het eindpunt op sluiting.

Punt‑typen bevatten ook vlaggen. Masker met `0x07` om het segmenttype te identificeren, en test `0x80` afzonderlijk om een gesloten subpad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijn‑eindpunt dat een subpad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat er één sluit. Alleen vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals dash (`0x10`) en marker (`0x20`), wijzigen het basisegmenttype niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), waarbij X naar rechts toeneemt en Y naar beneden. Voor een niet‑gegroepeerde vorm bevatten de geëxtraheerde coördinaten reeds de positie die wordt geretourneerd door [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) en [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) en weerspiegelen ze de huidige breedte en hoogte. Bijvoorbeeld, een ongeroteerde rechthoek op `(100, 200)` met grootte `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de vorm niet nogmaals toe. Trek X en Y af om coördinaten te verkrijgen relatief ten opzichte van het ongeroteerde frame.

De geëxtraheerde punten houden geen rekening met de rotatie die is ingesteld via [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) of horizontale en verticale flips. Om de weergegeven contour te reproduceren, pas die transformaties toe rond het middelpunt van de vorm. Voor gegroepeerde vormen moet je ook de groeps‑coördinatenmapping en transformaties in acht nemen; ga er niet van uit dat de geëxtraheerde punten de definitieve weergave‑dia‑coördinaten zijn of voer een translatie of schaal twee keer uit als deze al is verwerkt in het kind‑frame.

**Inspectie versus bewerking.** Geëxtraheerde arrays beschrijven de contour; ze wijzigen de oorspronkelijke vorm niet. Kies deze aanpak wanneer jouw analyse‑ of teken‑code punt‑/type‑arrays nodig heeft. Gebruik [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) wanneer je geometrie‑commando’s in het lokale coördinatensysteem van de vorm nodig hebt of wanneer je de geometrie wilt bewerken. Pas bewerkte paden toe via [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) of [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **GeometryPath Converteren naar GraphicsPath**

De huidige publieke API van Aspose.Slides voor C++ biedt geen conversies tussen geometrie‑paden en graphics‑paden. Om een contour te inspecteren, gebruik je vorm‑elementen zoals hierboven beschreven. Om een vorm te bewerken, gebruik je geometrie‑paden en pas je de bijgewerkte paden toe op de vorm.

## **FAQ**

**Wat gebeurt er met de vulling en omtrek nadat de geometrie is vervangen?**

De stijl blijft bij de vorm; alleen de contour verandert. De vulling en omtrek worden automatisch toegepast op de nieuwe geometrie.

**Hoe roteer ik een aangepaste vorm correct samen met zijn geometrie?**

Gebruik de [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/)‑methode van de vorm; de geometrie roteert mee omdat ze gebonden is aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm converteren naar een afbeelding om het resultaat vast te leggen?**

Ja. Exporteer het benodigde [slide](/slides/nl/cpp/convert-powerpoint-to-png/)‑gebied of de [shape](/slides/nl/cpp/shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verder werk met complexe geometrieën.