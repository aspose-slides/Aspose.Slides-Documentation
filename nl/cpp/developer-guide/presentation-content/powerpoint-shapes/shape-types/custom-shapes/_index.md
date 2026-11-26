---
title: Presentatievormen aanpassen in C++
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
- bewerkingspunten
- punt toevoegen
- punt verwijderen
- bewerkingsoperatie
- afgeronde hoek
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Maak en pas vormen aan in PowerPoint‑presentaties met Aspose.Slides voor C++: geometriepaden, afgeronde hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatieshapes in Aspose.Slides kunt aanpassen door de vormgeometrie te bewerken via bewerkingspunten en geometriepaden. Het toont hoe u kunt werken met [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) en [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) om bestaande shapes te wijzigen, basisbewerkingsbewerkingen uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie weer op een shape toe te passen.

Het demonstreert ook hoe u aangepaste en samengestelde shapes kunt maken, shapes met afgeronde hoeken kunt bouwen, en kunt bepalen of een vormgeometrie gesloten is.

## **Een shape wijzigen met bewerkingspunten**

In PowerPoint kunt u **Bewerkingspunten** gebruiken om een vierkant aan te passen:

* Verplaats een hoek naar binnen of naar buiten.
* Pas de kromming bij een punt aan.
* Voeg nieuwe punten toe.

Door punten te bewerken kunt u de omtrek van een shape wijzigen of een bestaande shape als basis voor een nieuwe gebruiken.

## **Tips voor shape bewerken**

![overview_image](custom_shape_0.png)

Houd bij het bewerken van PowerPoint-shapes de volgende concepten in gedachten:

* Een shape (of zijn pad) kan gesloten of open zijn.
* Het pad van een shape bestaat uit ankerpunten die verbonden zijn door segmenten.
* Een segment kan recht of gebogen zijn. Ankerpunten en controlehandvatten bepalen de vorm.
* Ankerpunten bestaan als hoekpunten, rechte punten of vloeiende punten:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een vloeiend punt zijn de twee controlehandvatten uitgelijnd en even ver van het ankerpunt.
  * Bij een recht punt zijn de twee controlehandvatten uitgelijnd, maar kunnen ze verschillende afstanden van het ankerpunt hebben.
* Het verplaatsen van ankerpunten of het aanpassen van hun handvatten wijzigt de omtrek van de shape.

Om PowerPoint-shapes te bewerken via bewerkingspunten, biedt **Aspose.Slides** de klasse [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) en de interface [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Een [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) instantie vertegenwoordigt een geometriepad van het [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) object.
* Om de [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) op te halen van de [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) instantie, kunt u de methode [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) gebruiken.
* Om de [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) voor een shape in te stellen, kunt u deze methoden gebruiken: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) voor shapes met één pad en [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) voor shapes met meerdere paden.
* Om segmenten toe te voegen, kunt u de methoden onder [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) gebruiken.
* Met de methoden [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) en [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) kunt u het uiterlijk van een geometriepad instellen.
* Met de methode [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) kunt u het geometriepad van een [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) ophalen als een array van padh segmenten.

## **Eenvoudige bewerkingsbewerkingen**

Gebruik de volgende methoden om een geometriepad te bewerken. Overloads die een index accepteren voegen een segment in op die nulgebaseerde positie in de segmentarray van het pad.

| Bewerkingen | Method |
| --- | --- |
| Voeg een rechte lijn toe of voeg deze in. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Voeg een kubieke Bézier-curve toe of voeg deze in met twee controlepunten en een eindpunt. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Voeg een kwadratische Bézier-curve toe of voeg deze in met één controlepunt en een eindpunt. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Voeg een elliptische boog toe met de opgegeven afmetingen en hoeken in graden. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Sluit de huidige figuur door het eindpunt te verbinden met het startpunt. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Stel het startpunt van een figuur in. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Verwijder een segment op een nulgebaseerde index. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Aangepaste punten toevoegen aan een shape**

Dit voorbeeld voegt twee punten toe aan een rechthoekige shape met behulp van [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) en past het bewerkte pad toe met [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). De coördinaten zijn lokaal relatief aan de shape: beide nieuwe punten zitten in het midden, 100 punten van de linkerkant en 50 punten van de bovenkant. Segmentindexen 1 en 4 plaatsen ze op respectievelijk de boven- en onderrand, waardoor die randen naar binnen worden getrokken.

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

## **Punten verwijderen van een shape**

Dit voorbeeld wijzigt een hartvormige omtrek door het segment op nulgebaseerde index 2 te verwijderen met [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Het toepassen van het gewijzigde pad met [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) werkt de contour van de shape bij.

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

## **Een aangepaste shape maken**

Dit voorbeeld maakt een vijfpuntige ster met [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Afwisselend uiterste en binnenste stralen van respectievelijk 100 en 50 punten definiëren de punten en inkepingen; een stap van 72 graden verdeelt de vijf punten gelijkmatig. Het pad wordt gesloten met [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) en toegepast op een rechthoekige shape met [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), waarmee de omtrek wordt vervangen.

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

## **Een samengestelde aangepaste shape maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)‑objecten voor het bovenste en onderste derde deel van een shape. Het toepassen van beide paden met [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) creëert een enkele samengestelde shape met een opening over het middelste derde deel.

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
bottomPath->MoveTo(shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **Een aangepaste shape met afgeronde hoeken maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) om een shape te maken met naar binnen gebogen hoeken. Elk hoekformaat stelt de breedte en hoogte van de boog in punten in, en de -90‑graden sweep tekent een tegen de klok in kwart‑ellips. Het voltooide pad wordt toegepast met [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), en de presentatie wordt opgeslagen in PPTX‑indeling.

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

## **Controleren of een shape‑geometrie gesloten is**

De volgende helper controleert of elk niet‑lege geometriepad eindigt met een sluitsegment. Het leest [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) en vergelijkt het laatste segment‑[IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) met [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Het geeft false terug wanneer er geen niet‑lege paden zijn. Dit controleert het laatste commando van elk pad; het inspecteert niet elke subfiguur binnen een pad. Het voorbeeld drukt `True` af voor een rechthoek.

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

## **Geometriepadcommando's inspecteren**

Download [contour.pptx](contour.pptx) en plaats het in de werkmap van de applicatie. De eerste shape op de eerste dia heeft een rechte bovenrand, een kubieke Bézier‑curve en een rechte sluitrand. Gebruik [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) om de paden te lezen. Voor elk pad geeft [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) de segmenten in tekenvolgorde terug. Het commando dat wordt geretourneerd door [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) bepaalt hoe de waarden van [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/) geïnterpreteerd moeten worden.

```cpp
#include <DOM/IGeometryPath.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IPathSegment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/PathCommandType.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"contour.pptx");

auto shape = ExplicitCast<IGeometryShape>(presentation->get_Slide(0)->get_Shape(0));
auto paths = shape->GetGeometryPaths();

for (auto i = 0; i < paths->get_Length(); ++i)
{
    auto segments = paths->idx_get(i)->get_PathData();
    for (auto j = 0; j < segments->get_Length(); ++j)
    {
        auto segment = segments->idx_get(j);
        auto command = segment->get_PathCommand();
        auto data = segment->get_SegmentData();
        String detail;
        switch (command)
        {
            case PathCommandType::MoveTo:
            case PathCommandType::LineTo:
                detail = String::Format(u"destination=({0}, {1})", data->idx_get(0), data->idx_get(1));
                break;
            case PathCommandType::CubicBezierTo:
                detail = String::Format(u"control1=({0}, {1}) control2=({2}, {3}) end=({4}, {5})", data);
                break;
            case PathCommandType::Close:
                detail = u"no coordinates";
                break;
            default:
            {
                auto values = MakeArray<String>(data->get_Length());
                for (auto k = 0; k < data->get_Length(); ++k)
                {
                    values->idx_set(k, String::Format(u"{0}", data->idx_get(k)));
                }
                detail = String::Format(u"raw=[{0}]", String::Join(u", ", values));
                break;
            }
        }
        Console::WriteLine(u"Path {0}, segment {1}: {2} {3}", i, j, Enum<PathCommandType>::GetName(command), detail);
    }
}
```

De shape bevindt zich op (200, 100) punten op de dia. De gerapporteerde punten zijn lokaal ten opzichte van de shape, met (0, 0) in de linkerbovenhoek, x stijgt naar rechts en y stijgt naar beneden. Het sluitsegment keert terug naar het startpunt zonder extra coördinaten.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint-shape met een rechte bovenrand, een gebogen rand van rechtsboven naar linksonder, en een rechte linkerrand](contour.png)

## **Shape‑elementen extraheren en inspecteren**

Gebruik [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) om een bestaande shape te inspecteren als elementen die padenpunten en punt‑types bevatten. Cast elk geretourneerd [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) naar [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) om de arrays die worden geretourneerd door [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) en [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) te lezen. Deze weergave is nuttig voor contouranalyse of voor het doorgeven van geometrie aan aangepaste tekenhulpmiddelen.

Het voorbeeld opent een presentatie, vindt de eerste geometrie‑shape direct op de eerste dia, en drukt zijn padh segmenten af. Gebruik een presentatie met een shape met rechte en gebogen segmenten om beide soorten output te zien. Het zoekt niet binnen groepen.

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
        auto pointType = types[i] & 0x07; // Behoud het segmenttype, exclusief vlaggen.
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
                i += 2; // Gebruik beide controlepunten en het eindpunt.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

De arrays corresponderen per index: `points[i]` is een punt en `types[i]` beschrijft zijn rol. Type `0` start een figuur, en type `1` tekent een lijn van het vorige punt naar het huidige punt. Een kubisch Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus verwerkt deze drie items samen en controleert of het eindpunt gesloten is.

De punt‑types bevatten ook vlaggen. Masker met `0x07` om het segmenttype te identificeren, en test `0x80` apart om een gesloten subpad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijn‑eindpunt dat een subpad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat een subpad sluit. Alleen vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals streep (`0x10`) en marker (`0x20`), wijzigen het basissegmenttype niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), met X die naar rechts toeneemt en Y die naar beneden toeneemt. Voor een niet‑gegroepeerde shape bevatten de geëxtraheerde coördinaten al de positie die wordt geretourneerd door [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) en [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) en weerspiegelen de huidige breedte en hoogte. Bijvoorbeeld, een niet‑gedraaide rechthoek op `(100, 200)` met afmeting `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de shape niet opnieuw toe. Trek zijn X en Y af om coördinaten te krijgen relatief aan het niet‑gedraaide frame.

De geëxtraheerde punten passen de rotatie die via [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) is ingesteld of horizontale en verticale spiegelingen niet toe. Om de weergegeven contour te reproduceren, pas die transformaties toe rond het midden van de shape. Voor gegroepeerde shapes moet u ook rekening houden met de coördinatenmapping en transformaties van de groep; ga er niet van uit dat de geëxtraheerde punten de definitieve weergegeven dia‑coördinaten zijn of pas een translatie of schaal twee keer toe als deze al in het frame van het kind is verwerkt.

**Inspectie versus bewerking.** Geëxtraheerde arrays beschrijven de contour; wijzigen ervan werkt de oorspronkelijke shape niet bij. Kies deze benadering wanneer uw analyse‑ of tekencode punt‑/type‑arrays nodig heeft. Gebruik [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) wanneer u geometrie‑commando’s nodig heeft in het lokale coördinatensysteem van de shape of wanneer u de geometrie wilt bewerken. Pas bewerkte paden toe via [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) of [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) .

## **GeometryPath converteren naar GraphicsPath**

De huidige publieke API van Aspose.Slides voor C++ biedt geen conversies tussen geometriepaden en graphics‑paden. Gebruik shape‑elementen zoals hierboven beschreven om een contour te inspecteren. Gebruik geometriepaden om een shape te bewerken en pas de bijgewerkte paden toe op de shape.

## **FAQ**

**Wat gebeurt er met de opvulling en de omtrek nadat de geometrie is vervangen?**

De stijl blijft behouden bij de shape; alleen de contour verandert. De opvulling en omtrek worden automatisch op de nieuwe geometrie toegepast.

**Hoe roteer ik een aangepaste shape correct samen met zijn geometrie?**

Gebruik de [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/)‑methode van de shape; de geometrie roteert mee met de shape omdat deze gebonden is aan het eigen coördinatensysteem van de shape.

**Kan ik een aangepaste shape converteren naar een afbeelding om het resultaat 'vast te leggen'?**

Ja. Exporteer het gewenste [slide](/slides/nl/cpp/convert-powerpoint-to-png/)‑gebied of de [shape](/slides/nl/cpp/shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verder werken met complexe geometrieën.