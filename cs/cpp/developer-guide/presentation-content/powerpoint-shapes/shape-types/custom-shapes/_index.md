---
title: Přizpůsobení tvarů prezentace v C++
linktitle: Vlastní tvar
type: docs
weight: 20
url: /cs/cpp/custom-shape/
keywords:
- vlastní tvar
- přidat tvar
- vytvořit tvar
- změnit tvar
- geometrie tvaru
- geometrická cesta
- body cesty
- upravit body
- přidat bod
- odstranit bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vytvořte a přizpůsobte tvary v prezentacích PowerPoint pomocí Aspose.Slides pro C++: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary v prezentaci v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) a [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/), aby bylo možné upravit existující tvary, provádět základní operace úpravy cesty, přidávat nebo odstraňovat body a použít aktualizovanou geometrii zpět na tvar.

Také demonstruje, jak vytvářet vlastní a složené tvary, stavět tvary s zakřivenými rohy a zjistit, zda je geometrie tvaru uzavřená.

## **Změna tvaru pomocí editačních bodů**

V PowerPointu můžete použít **Edit Points** k úpravě čtverce:

* Přesunout roh dovnitř nebo ven.
* Upravit zakřivení v bodě.
* Přidat nové body.

Úprava bodů vám umožňuje měnit obrys tvaru nebo použít existující tvar jako základ pro nový.

## **Tipy pro úpravu tvarů**

![overview_image](custom_shape_0.png)

Při úpravě tvarů v PowerPointu mějte na paměti následující pojmy:

* Tvar (nebo jeho cesta) může být buď uzavřená, nebo otevřená.
* Cesta tvaru se skládá z kotevních bodů spojených segmenty.
* Segment může být přímý nebo zakřivený. Kotevní body a řídicí úchyty určují jeho tvar.
* Kotevní body existují jako rohové body, přímé body nebo hladké body:
  * U rohového bodu mohou sousední segmenty setkat pod úhlem.
  * U hladkého bodu jsou dva řídicí úchyty zarovnané a stejně vzdálené od kotevního bodu.
  * U přímého bodu jsou dva řídicí úchyty zarovnané, ale mohou mít různé vzdálenosti od kotevního bodu.
* Přesunutí kotevních bodů nebo úprava jejich úchytů mění obrys tvaru.

Pro úpravu tvarů v PowerPointu pomocí editačních bodů poskytuje **Aspose.Slides** třídu [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) a rozhraní [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Instance [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) představuje geometrickou cestu objektu [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Pro získání [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) z instance [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) můžete použít metodu [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Pro nastavení [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) pro tvar můžete použít tyto metody: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) pro tvary s jednou cestou a [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) pro tvary s více cestami.
* Pro přidání segmentů můžete použít metody pod [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* Použitím metod [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) a [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) můžete nastavit vzhled geometrické cesty.
* Pomocí metody [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) můžete získat geometrickou cestu [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) jako pole segmentů cesty.

## **Jednoduché operace úpravy**

Použijte následující metody k úpravě geometrické cesty. Přetížení, která přijímají index, vloží segment na nulově založenou pozici v poli segmentů cesty.

| Operace | Metoda |
| --- | --- |
| Přidat nebo vložit přímou čáru. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Přidat nebo vložit kubickou Bézierovu křivku se dvěma řídicími body a koncovým bodem. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Přidat nebo vložit kvadratickou Bézierovu křivku s jedním řídicím bodem a koncovým bodem. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Přidat eliptický oblouk se zadanými rozměry a úhly ve stupních. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Uzavřít aktuální obrazec spojením jeho koncového bodu se startovacím bodem. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Nastavit počáteční bod obrazce. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Odstranit segment na nulově založeném indexu. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Přidání vlastních bodů do tvaru**

V tomto příkladu jsou pomocí [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) vloženy dva body do obdélníkového tvaru a upravená cesta je použita pomocí [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Souřadnice jsou lokální k tvaru: oba nové body jsou ve středu, 100 bodů od levého okraje a 50 bodů od horního. Indexy segmentů 1 a 4 je umístí na horní a spodní hranu, čímž tyto hrany stáhnou dovnitř.

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

## **Odstranění bodů z tvaru**

V tomto příkladu se mění obrys ve tvaru srdce odstraněním segmentu na nulově založeném indexu 2 pomocí [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Použití upravené cesty s [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) aktualizuje konturu tvaru.

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

## **Vytvoření vlastního tvaru**

V tomto příkladu se pomocí [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) vytvoří pěticípá hvězda. Střídavé vnější a vnitřní poloměry 100 a 50 bodů definují špičky a výřezy; krok 72 stupňů rovnoměrně rozmístí pět špiček. Cesta je uzavřena pomocí [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) a aplikována na obdélníkový tvar pomocí [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), čímž nahradí jeho obrys.

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

## **Vytvoření složeného vlastního tvaru**

V tomto příkladu jsou definovány dva uzavřené objekty [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) pro horní a spodní třetinu tvaru. Použití obou cest s [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) vytvoří jeden složený tvar s mezerou napříč jeho střední třetinou.

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

## **Vytvoření vlastního tvaru se zakřivenými rohy**

V tomto příkladu se kombinují přímé segmenty s [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) k vytvoření tvaru se zakřivenými rohy dovnitř. Každá velikost rohu určuje šířku a výšku oblouku v bodech a -90° oblouk kreslí proti směru hodinových ručiček čtvrtinu elipsy. Dokončená cesta je aplikována pomocí [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) a prezentace je uložena ve formátu PPTX.

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

## **Zjistit, zda je geometrie tvaru uzavřená**

Následující pomocná funkce kontroluje, zda každá neprázdná geometrická cesta končí uzavíracím segmentem. Načítá [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) a porovnává poslední segmentův [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) s [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Vrací false, pokud neexistují neprázdné cesty. Kontroluje poslední příkaz každé cesty; neprozkoumává každou podobrazec v cestě. Příklad vypíše `True` pro obdélník.

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

## **Prozkoumání příkazů geometrické cesty**

Stáhněte [contour.pptx](contour.pptx) a umístěte jej do pracovního adresáře aplikace. První tvar na první snímku má rovný horní okraj, kubickou Bézierovu křivku a rovný uzavírací okraj. Použijte [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) k načtení jeho cest. Pro každou cestu [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) vrací segmenty v pořadí kreslení. Příkaz vrácený [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) určuje, jak interpretovat hodnoty vrácené [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/).

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

Tvar leží na (200, 100) bodech na snímku. Uvedené body jsou lokální k tvaru, s (0, 0) v jeho levém horním rohu, x se zvyšuje doprava a y dolů. Uzavírací segment se vrací na počáteční bod bez dalších souřadnic.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![Tvar PowerPointu s rovným horním okrajem, zakřiveným okrajem od pravého horního ke levému dolnímu a rovným levým okrajem](contour.png)

## **Extrahování a prozkoumání prvků tvaru**

Použijte [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) k prozkoumání existujícího tvaru jako prvků obsahujících body cesty a typy bodů. Přetypujte každý vrácený [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) na [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) pro načtení polí vrácených [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) a [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Toto zastoupení je užitečné pro analýzu kontur nebo předání geometrie do vlastních nástrojů kreslení.

Příklad otevře prezentaci, najde první geometrický tvar přímo na první snímku a vypíše jeho segmenty cesty. Použijte prezentaci obsahující tvar s přímými a zakřivenými segmenty, abyste viděli oba typy výstupu. Neprohledává skupiny.

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
        auto pointType = types[i] & 0x07; // Zachovat typ segmentu, vyjmout příznaky.
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
                i += 2; // Spotřebovat oba řídicí body a koncový bod.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Pole odpovídají podle indexu: `points[i]` je bod a `types[i]` popisuje jeho roli. Typ `0` zahajuje obrazec a typ `1` kreslí čáru od předchozího bodu k aktuálnímu bodu. Kubický Bézier segment začíná na předchozím koncovém bodu a používá tři po sobě jdoucí položky typu `3`: dva řídicí body následované novým koncovým bodem. Smyčka spotřebuje tyto tři položky najednou a kontroluje koncový bod, zda uzavírá.

Typy bodů také obsahují příznaky. Maskujte s `0x07` pro identifikaci typu segmentu a testujte `0x80` samostatně pro detekci uzavřené podcesty. Například `129` (`0x81`) znamená koncový bod čáry, který uzavírá podcestu, a `131` (`0x83`) znamená koncový bod Bézieru, který uzavírá podcestu. Porovnání surové hodnoty pouze s `1` nebo `3` by tyto případy přehlédlo. Další příznaky, jako čerpace (`0x10`) a značkovač (`0x20`), nemění základní typ segmentu.

**Souřadnice a transformace.** Body jsou měřeny v bodech (1/72 palce), přičemž X roste doprava a Y dolů. Pro nezkupený tvar již extrahované souřadnice zahrnují pozici vrácenou metodami [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) a [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) a odrážejí jeho aktuální šířku a výšku. Například neotočený obdélník v `(100, 200)` s rozměry `120 × 80` má hranice kontury `(100, 200)`–`(220, 280)`. Nepřičítejte pozici tvaru znovu. Odečtěte jeho X a Y, abyste získali souřadnice relativní k jeho neotočenému rámci.

Extrahované body neaplikují rotaci nastavenou pomocí [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) ani horizontální a vertikální převrácení. Pro reprodukci zobrazované kontury aplikujte tyto transformace kolem středu tvaru. Pro seskupené tvary také zohledněte mapování souřadnic skupiny a transformace; nepředpokládejte, že extrahované body jsou konečné vykreslené souřadnice snímku, ani nepřidávejte posunutí nebo měřítko dvakrát, pokud již bylo zahrnuto v rámci podřízeného prvku.

**Prohlížení versus úprava.** Extrahovaná pole popisují konturu; jejich změna neaktualizuje původní tvar. Zvolte tento přístup, když vaše analýzy nebo kreslicí kódy potřebují pole bodů/typů. Použijte [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) když potřebujete geometrické příkazy v lokálním souřadnicovém systému tvaru nebo chcete upravit jeho geometrii. Použijte upravené cesty přes [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) nebo [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Převod GeometryPath na GraphicsPath**

Aktuální veřejné API Aspose.Slides pro C++ neumožňuje konverze mezi geometrickými cestami a grafickými cestami. Pro prozkoumání kontury použijte prvky tvaru, jak je popsáno výše. Pro úpravu tvaru použijte geometrické cesty a aplikujte aktualizované cesty na tvar.

## **FAQ**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstává u tvaru; mění se pouze kontura. Výplň a obrys jsou automaticky použity na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte metodu [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) tvaru; geometrie se otáčí spolu s tvarem, protože je svázána s jeho vlastním souřadnicovým systémem.

**Mohu převést vlastní tvar na obrázek, aby byl výsledek „uzamčen“?**

Ano. Exportujte požadovanou oblast [slide](/slides/cs/cpp/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/cpp/shape-thumbnails/) do rastrového formátu; to zjednoduší další práci s komplexními geometriemi.