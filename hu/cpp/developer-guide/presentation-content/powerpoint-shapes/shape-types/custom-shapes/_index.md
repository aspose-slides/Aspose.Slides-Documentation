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
- geometriai út
- út pontok
- szerkesztési pontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- ívelt sarok
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for C++ segítségével: geometriai utak, ívelt sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet testreszabni a prezentáció alakzatokat az Aspose.Slides-ban, az alakzatgeometria szerkesztésével szerkesztési pontok és geometriai utak segítségével. Bemutatja, hogyan kell használni a [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) és a [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) elemeket a meglévő alakzatok módosításához, alapvető út szerkesztési műveletek végrehajtásához, pontok hozzáadásához vagy eltávolításához, és a frissített geometria visszaalkalmazásához egy alakzatra.

Emellett bemutatja, hogyan lehet egyéni és összetett alakzatokat létrehozni, ívelt sarkokkal rendelkező alakzatokat építeni, valamint meghatározni, hogy egy alakzat geometria zárt‑e.

## **Alakzat módosítása szerkesztési pontokkal**

PowerPointban a **Edit Points** segítségével módosíthat egy négyzetet:

* Egy sarkot befelé vagy kifelé mozgathat.
* Egy pont görbületét állíthatja.
* Új pontokat adhat hozzá.

A szerkesztési pontok használata lehetővé teszi az alakzat körvonalának módosítását vagy egy meglévő alakzat alapul vételét egy újhoz.

## **Alakzat szerkesztési tippek**

![overview_image](custom_shape_0.png)

PowerPoint alakzatok szerkesztésekor tartsa szem előtt a következő fogalmakat:

* Egy alakzat (vagy annak útja) lehet zárt vagy nyitott.
* Az alakzat útja horgonypontokból áll, amelyeket szegmensek kötnek össze.
* Egy szegmens lehet egyenes vagy íves. A horgonypontok és a vezérlőkarok határozzák meg alakját.
* A horgonypontok lehetnek sarokpontok, egyenes pontok vagy sima pontok:
  * Sarokpont esetén a szomszédos szegmensek szöggel találkozhatnak.
  * Sima pont esetén a két vezérlőkar egyvonalú és egyenlő távolságra van a horgonyponttól.
  * Egyenes pont esetén a két vezérlőkar egyvonalú, de eltérő távolságra lehet a horgonyponttól.
* A horgonypontok mozgatása vagy a karjaik állítása megváltoztatja az alakzat körvonalát.

A PowerPoint alakzatok szerkesztéséhez **Aspose.Slides** a [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) osztályt és az [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) interfészt biztosítja.

* A [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) példány egy [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) objektum geometriai útját képviseli.
* A [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) példányból a [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) metódussal kérhető le a [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/).
* Egy alakzat [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) beállításához használhatja a [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) metódust egyetlen út esetén, illetve a [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) metódust több út esetén.
* Szegmensek hozzáadásához használhatja az [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) alatti metódusokat.
* Az [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) és az [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) metódusokkal beállíthatja egy geometriai út megjelenését.
* Az [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) metódussal lekérhető egy [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) geometriai útja szegmens tömbként.

## **Egyszerű szerkesztési műveletek**

Használja az alábbi metódusokat egy geometriai út szerkesztéséhez. Az indexet elfogadó túlterhelések egy szegmenst szúrnak be a nullától indexelt pozícióba a szegmens tömbben.

| Művelet | Metódus |
| --- | --- |
| Egyenes vonal hozzáfűzése vagy beszúrása. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Két vezérlőponttal és egy végponttal rendelkező köb‑Bézier‑görbe hozzáfűzése vagy beszúrása. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Egy vezérlőponttal és egy végponttal rendelkező kvadratikus Bézier‑görbe hozzáfűzése vagy beszúrása. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Ellipszis ív hozzáfűzése a megadott méretekkel és fokban kifejezett szögekkel. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Az aktuális alakzat lezárása az végpont és a kezdőpont összekötésével. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Alakzat kezdőpontjának beállítása. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Szegmens eltávolítása a nullától indexelt pozícióban. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Egyéni pontok hozzáadása egy alakzathoz**

Ez a példa két pontot szúr be egy téglalap alakzatba a [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) segítségével, majd a módosított úttal a [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) alkalmazza azt. A koordináták az alakzathoz relatívak: mindkét új pont a középpontjában helyezkedik el, 100 pont nyugatra és 50 pont felfelé a bal felső saroktól. Az 1‑es és 4‑es szegmensindexek a felső és alsó szélén helyezik el őket, behúzva ezeket a széleket.

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

## **Pontok eltávolítása egy alakzatról**

Ez a példa egy szív alakú körvonalat módosít azzal, hogy a 2‑es (nullától indexelt) szegmenst eltávolítja a [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) segítségével. A módosított út alkalmazása a [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) metódussal frissíti az alakzat kontúrját.

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

## **Egyéni alakzat létrehozása**

Ez a példa egy ötszögletű csillagot épít a [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) segítségével. A 100‑es és 50‑es pont méretű külső‑ és belső‑sugár váltakozása adja meg a csúcsokat és a bemetszéseket; a 72 fokos lépés egyenlően osztja el az öt csúcsot. Az út a [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) segítségével záródik, majd a [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) alkalmazásával egy téglalap alakzatra kerül, felülírva annak körvonalát.

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

## **Összetett egyéni alakzat létrehozása**

Ez a példa két zárt [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) objektumot definiál az alakzat felső és alsó harmadához. Mindkét út [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) segítségével való alkalmazása egyetlen összetett alakzatot hoz létre, melynek középső harmadában rés található.

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

## **Egyéni alakzat ívelt sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) segítségével, hogy egy befelé ívelt sarkokkal rendelkező alakzatot hozzon létre. Minden sarokméret beállítja az ív szélességét és magasságát pontban, a -90 fokos ív pedig egy óramutatóval ellentétes negyed‑ellipszist rajzol. A kész út a [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) segítségével kerül alkalmazásra, és a bemutató PPTX formátumban mentésre kerül.

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

## **Megállapítás, hogy egy alakzat geometria zárt‑e**

Az alábbi segédfüggvény ellenőrzi, hogy minden nem üres geometriai út záró szegmenssel végződik‑e. A [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) adatot olvassa, és a végső szegmens [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) értékét a [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/) típusúval hasonlítja össze. Hamis értéket ad vissza, ha nincs nem üres út. Ez a függvény az egyes utak végső parancsát ellenőrzi; nem vizsgálja meg az út minden részalakját. A példa `True` értéket ír ki egy téglalap esetén.

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

## **Alakzatelemek kinyerése és vizsgálata**

Használja a [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) metódust egy meglévő alakzat elemeinek vizsgálatához, melyek útpontokat és ponttípusokat tartalmazó elemekként jelennek meg. A visszaadott [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) minden példányát alakítsa [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) típusra, hogy elérhesse a [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) és a [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) tömböket. Ez a reprezentáció hasznos kontúr‑elemzéshez vagy a geometria egyedi rajzolóeszközöknek való átadásához.

A példa megnyit egy bemutatót, megtalálja az első geometriai alakzatot az első dián, és kiírja annak út szegmenseit. Használjon egy olyan bemutatót, amelynek alakzata egyenes és íves szegmenseket is tartalmaz, hogy mindkét kimenetet lássa. A csoporton belüli keresést a példa nem végzi.

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
        auto pointType = types[i] & 0x07; // Tartsa meg a szegmens típust, a flag-eket kihagyva.
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
                i += 2; // Consume both control points and the endpoint.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

A tömbök index szerint egyeznek: `points[i]` egy pont, a `types[i]` pedig annak szerepét írja le. Az `0` típusú bejegyzés egy új figura kezdetét jelzi, az `1` típusú egy vonalat a korábbi pontból a jelenlegibe. Egy köb‑Bézier szegmens a korábbi végpontból indul, és három egymást követő `3` típusú bejegyzést használ: két vezérlőpontot, majd az új végpontot. A ciklus ezeket a három bejegyzést egyszerre fogyasztja, és a végpont zártságát ellenőrzi.

A ponttípusok flag‑eket is tartalmazhatnak. Maszkáljon a `0x07` értékkel a szegmens típus azonosításához, és külön ellenőrizze a `0x80`‑at a zárt alútrész felismeréséhez. Például a `129` (`0x81`) egy olyan vonal‑végpont, amely zárja az alútrészt, míg a `131` (`0x83`) egy Bézier‑végpont, amely szintén zár. Ha csak a nyers értéket hasonlítja `1`‑hez vagy `3`‑as értékhez, ezeket a helyzeteket figyelmen kívül hagyja. Más flag‑ek, például a szaggatottság (`0x10`) vagy a marker (`0x20`), nem változtatják meg az alap szegmens típusát.

**Koordináták és transzformációk.** A pontok pontban vannak megadva (1/72 hüvelyk), az X jobbra, a Y lefelé növekszik. Nem csoportosított alakzat esetén a kinyert koordináták már tartalmazzák a [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) és [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) által visszaadott pozíciót, és tükrözik az aktuális szélességet és magasságot. Például egy forgatás nélküli téglalap `(100, 200)`‑nél, `120 × 80` mérettel, a kontúr határa `(100, 200)`–`(220, 280)`. Ne adja hozzá újra az alakzat pozícióját; vonja ki az X‑et és Y‑t a nem forgatott kerethez viszonyított koordinátákhoz.

A kinyert pontok nem veszik figyelembe a [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) vagy a vízszintes és függőleges tükrözések által beállított forgatást. A megjelenített kontúr reprodukálásához ezeket a transzformációkat az alakzat középpontja körül alkalmazza. Csoportosított alakzatoknál számítson a csoportkoordináta-leképezésre és a transzformációkra is; ne feltételezze, hogy a kinyert pontok már a végleges diakép koordinátái, és ne alkalmazzon egy további eltolást vagy méretezést, ha már a gyermek keretben szerepelnek.

**Vizsgálat vs. szerkesztés.** A kinyert tömbök a kontúrt írják le; ezek módosítása nem frissíti az eredeti alakzatot. Válassza ezt a megközelítést, ha a pont‑típus tömbökre van szüksége elemzéshez vagy saját rajzolókódhoz. Használja a [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) metódust, ha a geometriai parancsokra van szüksége az alakzat helyi koordináta‑rendszerében, vagy ha a geometria szerkesztése a cél. A szerkesztett utak alkalmazásához használja a [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) vagy a [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) metódusokat.

## **GeometryPath átalakítása GraphicsPath‑re**

Az aktuális Aspose.Slides for C++ nyilvános API nem teszi közzé a geometriai utak és a graphics path‑ok közötti átalakításokat. Kontúrok vizsgálatához használja a fenti módon kinyert alakzatelemeket. Alakzat szerkesztéséhez használjon geometriai utakat, és alkalmazza a frissített utakat az alakzatra.

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria cseréje után?**

A stílus megmarad az alakzaton; csak a kontúr változik. A kitöltés és a körvonal automatikusan alkalmazásra kerül az új geometriára.

**Hogyan forgassam helyesen az egyéni alakzatot a geometriai adatokkal együtt?**

Használja az alakzat [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) metódusát; a geometria a shape‑hez kapcsolódó koordináta‑rendszer miatt együtt forgik.

**Átalakíthatom-e az egyéni alakzatot képpé a „lezáráshoz”?**

Igen. Exportálja a szükséges [diát](/slides/hu/cpp/convert-powerpoint-to-png/) vagy a [alakzatot](/slides/hu/cpp/shape-thumbnails/) magát raszter formátumba; ez egyszerűsíti a komplex geometriákkal való további munkát.