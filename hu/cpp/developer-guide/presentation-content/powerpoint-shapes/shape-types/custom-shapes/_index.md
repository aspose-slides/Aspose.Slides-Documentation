---
title: Prezentációs alakzatok testreszabása C++-ban
linktitle: Egyéni alakzat
type: docs
weight: 20
url: /hu/cpp/custom-shape/
keywords:
- egyéni alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzat geometria
- geometriai útvonal
- útvonal pontok
- szerkesztőpontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- ívelt sarok
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for C++ segítségével: geometriai útvonalak, ívelt sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a prezentáció alakzatait az Aspose.Slides‑ben a forma geometria szerkesztőpontokkal és geometriai útvonalakkal történő módosításával. Ismerteti a [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) és az [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) használatát meglévő alakzatok módosításához, alapvető útvonal‑szerkesztési műveletek végrehajtásához, pontok hozzáadásához vagy eltávolításához, valamint a frissített geometria alakzatra alkalmazásához.

A cikk továbbá bemutatja, hogyan hozhatunk létre egyedi és összetett alakzatokat, hogyan építhetünk görbe sarkú alakzatokat, valamint hogyan ellenőrizhetjük, hogy egy alakzat geometria zárt‑e.

## **Alakzat módosítása szerkesztőpontokkal**

A PowerPointban a **Szerkesztőpontok** segítségével módosíthat egy négyzetet:

* Egy sarkot be‑ vagy kifelé mozgathat.
* Egy pont görbületét állíthatja.
* Új pontokat adhat hozzá.

A szerkesztőpontok szerkesztése lehetővé teszi, hogy megváltoztassa az alakzat körvonalát, vagy egy meglévő alakzatot alapul véve hozzon létre újat.

## **Alakzat‑szerkesztési tippek**

![overview_image](custom_shape_0.png)

PowerPoint‑alakzatok szerkesztésekor tartsa szem előtt a következőket:

* Egy alakzat (vagy annak útvonala) lehet zárt vagy nyitott.
* Egy alakzat útvonala horgonypontokból áll, amelyeket szegmensek kötnek össze.
* Egy szegmens lehet egyenes vagy görbe. A horgonypontok és a szabályozó fogantyúk határozzák meg alakját.
* A horgonypontok lehetnek sarkpontok, egyenes pontok vagy sima pontok:
  * Sarkpont esetén a szomszédos szegmensek szöggel találkoznak.
  * Sima pontnál a két szabályozó fogantyú egy vonalban van, és egyenlő távolságra helyezkedik el a horgonyponttól.
  * Egyenes pontnál a két szabályozó fogantyú egy vonalban van, de eltérő távolságra a horgonyponttól.
* A horgonypontok mozgatása vagy fogantyúik módosítása megváltoztatja az alakzat körvonalát.

A PowerPoint‑alakzatok szerkesztéséhez **Aspose.Slides** a [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) osztályt és az [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) interfészt biztosítja.

* Egy [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) példány az [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) objektum geometriai útvonalát képviseli.
* Az [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) példányból a [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) metódussal kérhető le a [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/).
* Egy alakzat [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) beállításához használhatja a [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) (egypath‑es alakzatok) vagy a [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) (többutas) metódusokat.
* Szegmensek hozzáadásához az [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) alatti metódusok használhatók.
* Az [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) és az [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) metódusokkal állítható be egy geometriai útvonal megjelenése.
* Az [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) metódus visszaadja a [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) geometriai útvonalát szegmens‑tömbként.

## **Egyszerű szerkesztési műveletek**

Az alábbi metódusokkal szerkeszthet egy geometriai útvonalat. Az indexet elfogadó túlterhelések a szegmens tömbjében a megadott nullától‑számozott helyen szúrják be a szegmenst.

| Művelet | Módszer |
| --- | --- |
| Egy egyenes vonal hozzáfűzése vagy beszúrása. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Két vezérlőponttal és egy végponttal rendelkező köb‑Bézier‑görbe hozzáfűzése vagy beszúrása. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Egy vezérlőponton és egy végponton alapuló kvadratikus Bézier‑görbe hozzáfűzése vagy beszúrása. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Elliptikus ív hozzáfűzése a megadott méretekkel és fokban megadott szögekkel. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Az aktuális alakzat lezárása az utolsó pontot az első ponthoz csatlakoztatva. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Az alakzat kezdőpontjának beállítása. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Egy szegmens eltávolítása a nullától‑számozott index alapján. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Egyedi pontok hozzáadása egy alakzathoz**

Ez a példa két pontot szúr be egy téglalapba a [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) segítségével, majd a szerkesztett útvonalat az [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) alkalmazásával állítja be. A koordináták az alakzathoz relatívek: mindkét új pont a középpontban van, 100 ponttól balra és 50 ponttól felül. Az 1‑es és 4‑es szegmens‑indexek a felső és alsó élre helyezik őket, befelé húzva az éleket.

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

## **Pontok eltávolítása egy alakzatból**

Ez a példa a szív alakú körvonalat módosítja a [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) segítségével, amely a nullától‑számozott 2‑es indexű szegmenst távolítja el. A módosított útvonal [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) alkalmazása frissíti az alakzat kontúrját.

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

## **Egyedi alakzat létrehozása**

Ez a példa egy ötágú csillagot épít a [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) segítségével. A 100 és 50 pont közötti váltakozó külső‑ és belső‑sugár határozza meg a csúcsokat és kihúzódásokat; a 72 fokos lépés egyenletesen elosztja az öt csúcsot. Az útvonal a [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) metódussal záródik, majd egy téglalapra az [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) alkalmazásával kerül.

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

## **Összetett egyedi alakzat létrehozása**

Ez a példa két zárt [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) objektumot definiál a forma felső és alsó harmadjához. A két útvonal [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) segítségével való alkalmazása egyetlen összetett alakzatot hoz létre, amelynek középső harmadja rés a kettő között.

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

## **Egyedi alakzat görbe sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) metódussal, hogy egy belső‑görbülő sarkú alakzatot kapjon. Minden sarokméret az ív szélességét és magasságát adja pontban, a -90 fokos ívhossz pedig egy óramutatóval ellentétes negyed‑ellipszist rajzol. A kész útvonalat az [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) alkalmazza, a bemutató pedig PPTX formátumban kerül mentésre.

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

## **Megszerzés, hogy egy alakzat geometria zárt‑e**

Az alábbi segédfüggvény ellenőrzi, hogy minden nem üres geometriai útvonal záró szegmenssel végződik‑e. A [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) kiolvassa, majd az utolsó szegmens [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) értékét összehasonlítja a [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/) típussal. Ha nincs nem üres útvonal, hamis értéket ad vissza. A függvény minden útvonal végleges parancsát ellenőrzi; nem vizsgálja meg a útvonal minden alképét. A példa egy téglalap esetén „True” értéket ír ki.

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

## **Geometriai útvonal‑parancsok vizsgálata**

Töltse le a [contour.pptx](contour.pptx) fájlt, és helyezze a program munkakönyvtárába. Az első dián az első alakzatnak egy egyenes felső él, egy köb‑Bézier‑görbe és egy egyenes záró él van. A [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) metódussal olvashatja ki az útvonalakat. Minden útvonalra a [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) a szegmenseket a rajzolási sorrendben adja vissza. A [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) által visszaadott parancs határozza meg, hogyan kell értelmezni a [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/) által visszaadott értékeket.

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

Az alakzat a dián (200, 100) pontban helyezkedik el. A jelentett pontok az alakzathoz relatívak, a (0, 0) a bal‑felső sarok, az x jobbra, az y lefele növekszik. A záró szegmens az induló pontra tér vissza további koordináták nélkül.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Alakzatelemek kivonása és vizsgálata**

Az [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) metódus segítségével egy meglévő alakzat elemeit – útvonal‑pontokat és pont‑típusokat – vizsgálhatja meg. Az egyes visszaadott [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) objektumokat a [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) típusra konvertálva olvashatók a [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) és a [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) tömbök. Ez a reprezentáció hasznos kontúr‑elemzéshez vagy a geometria egyedi rajzeszközöknek való átadásához.

A példa megnyit egy prezentációt, a első dián kiválasztja az első geometriai alakzatot, majd kiírja annak szegmenseit. Használjon olyan prezentációt, amelynek alakzata egyenes és görbe szegmenseket egyaránt tartalmaz, hogy mindkét típusú kimenetet lássa. A metódus nem keres csoportokon belül.

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
        auto pointType = types[i] & 0x07; // Megtartja a szegmens típusát, a zászlók kizárásával.
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
                i += 2; // Fogyasztja mindkét vezérlőpontot és a végpontot.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

A tömbök index szerint illeszkednek: `points[i]` egy pont, a `types[i]` a pont szerepét írja le. A `0` típus új alakzatot indít, az `1` típus egy vonalat rajzol az előző pontból a jelenlegi pontba. Egy köb‑Bézier szegmens a korábbi végpontból indul, és három egymást követő `3` típusú bejegyzést használ: két irányítópontot, majd az új végpontot. A ciklus ezeket a három bejegyzést egyszerre fogyasztja, és a végpontot vizsgálja a zárás szempontjából.

A pont‑típusok flag‑eket is tartalmaznak. A `0x07` maszkkal meghatározható a szegmens típusa, a `0x80` flag a zárt alútvonal jelzésére szolgál. Például a `129` (`0x81`) egy vonal‑végpont, amely zár egy alútvonalat, a `131` (`0x83`) pedig egy Bézier‑végpont, amely szintén zár. Ha csak a nyers értéket `1`‑gyel vagy `3`‑mal hasonlítjuk, ezek a esetek kimaradnak. Egyéb flag‑ek, például a szaggatottság (`0x10`) vagy a jelölő (`0x20`), nem változtatják az alap szegmens‑típust.

**Koordináták és transzformációk.** A pontok pontban (1/72 hüvelyk) vannak mérve, az X jobbra, a Y lefele növekszik. Egy csoporton kívüli alakzat esetén a kinyert koordináták már tartalmazzák a [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) és [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) által visszaadott pozíciót, valamint a jelenlegi szélességet és magasságot. Például egy nem forgatott `(100, 200)` bal‑felső sarokkal és `120 × 80` mérettel rendelkező téglalap kontúra `(100, 200)`‑től `(220, 280)`‑ig terjed. Ne adja hozzá újra az alakzat pozícióját; vonja ki az X‑et és Y‑t a relatív koordinátákhoz.

A kinyert pontok **nem** alkalmazzák a [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) vagy a vízszintes/függőleges tükrözés által beállított elforgatást. A megjelenített kontúr reprodukálásához ezeket a transzformációkat az alakzat középpontja körül kell elvégezni. Csoportos alakzatok esetén vegye figyelembe a csoport koordináta‑leképezését és a transzformációkat; ne tételezze, hogy a kinyert pontok a végső diára vetült koordináták, és ne alkalmazzon dupla eltolást vagy méretezést, ha már a gyermek keretben megtörtént.

**Vizsgálat vs. szerkesztés.** A kinyert tömbök csak a kontúr leírását adják; módosításuk nem frissíti az eredeti alakzatot. Ezt a megközelítést akkor válassza, ha a pont‑típus tömbökre épülő elemzésre vagy rajzoló kódra van szükség. Ha a geometriai parancsokra van igénye a helyi koordináta‑rendszerben, vagy a geometria szerkesztésére, használja a [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) metódust, majd alkalmazza a módosított útvonalakat a [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) vagy a [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) segítségével.

## **GeometryPath konvertálása GraphicsPath‑re**

Az aktuális Aspose.Slides for C++ nyilvános API nem teszi lehetővé a geometriai útvonalak és grafikus útvonalak közötti konverziót. A kontúr vizsgálatához használja a fenti alakzatelem‑módszert. Az alakzat szerkesztéséhez a geometriai útvonalakat és azok alkalmazását használja.

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria lecserélése után?**

A stílus megmarad az alakzaton; csak a kontúr változik. A kitöltés és a körvonal automatikusan az új geometriára kerülnek alkalmazásra.

**Hogyan forgathatom helyesen az egyedi alakzatot a geometriai adataival együtt?**

Használja az alakzat [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) metódusát; a geometria az alakzattal együtt forgik, mivel az az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatom-e az egyedi alakzatot képpé, hogy „lefagyasszam” az eredményt?**

Igen. Exportálja a kívánt [slide](/slides/hu/cpp/convert-powerpoint-to-png/) területet vagy magát a [shape](/slides/hu/cpp/shape-thumbnails/)‑t raszteres formátumba; ez egyszerűsíti a komplex geometriákkal való további munkát.