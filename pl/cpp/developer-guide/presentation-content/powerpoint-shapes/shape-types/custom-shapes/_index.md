---
title: Dostosowywanie kształtów prezentacji w C++
linktitle: Własny kształt
type: docs
weight: 20
url: /pl/cpp/custom-shape/
keywords:
- niestandardowy kształt
- dodaj kształt
- utwórz kształt
- zmień kształt
- geometria kształtu
- ścieżka geometryczna
- punkty ścieżki
- edytuj punkty
- dodaj punkt
- usuń punkt
- operacja edycji
- zaokrąglony narożnik
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++: ścieżki geometryczne, zaokrąglone narożniki, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides, edytując geometrię kształtu przy użyciu punktów edycji i ścieżek geometrycznych. Pokazuje, jak korzystać z [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) i [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) w celu modyfikacji istniejących kształtów, wykonywania podstawowych operacji edycji ścieżki, dodawania lub usuwania punktów oraz zastosowania zaktualizowanej geometrii do kształtu.

Demonstruje również, jak tworzyć własne i złożone kształty, budować kształty z zaokrąglonymi narożnikami oraz określić, czy geometria kształtu jest zamknięta.

## **Zmiana kształtu przy użyciu punktów edycji**

W PowerPoint możesz używać **Punktów edycji**, aby zmodyfikować kwadrat:

* Przesunąć narożnik do wewnątrz lub na zewnątrz.
* Dostosować krzywiznę w danym punkcie.
* Dodać nowe punkty.

Edycja punktów pozwala zmienić kontur kształtu lub użyć istniejącego kształtu jako podstawy nowego.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Podczas edycji kształtów w PowerPoint pamiętaj o następujących pojęciach:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Ścieżka kształtu składa się z punktów kotwiczących połączonych odcinkami.
* Odcinek może być prosty lub krzywy. Kształt określają punkty kotwiczące i uchwyty kontrolne.
* Punkty kotwiczące występują jako punkty narożne, proste lub gładkie:
  * W punkcie narożnym przylegające odcinki mogą spotykać się pod kątem.
  * W punkcie gładkim dwa uchwyty kontrolne są wyrównane i znajdują się w równej odległości od punktu kotwiczącego.
  * W punkcie prostym dwa uchwyty kontrolne są wyrównane, ale mogą mieć różne odległości od punktu kotwiczącego.
* Przemieszczanie punktów kotwiczących lub dostosowywanie ich uchwytów zmienia kontur kształtu.

Aby edytować kształty PowerPoint przy użyciu punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) oraz interfejs [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) z instancji [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), możesz użyć metody [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) dla kształtu, możesz użyć metod: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) dla kształtów z pojedynczą ścieżką oraz [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) dla kształtów z wieloma ścieżkami.
* Aby dodać odcinki, możesz używać metod dostępnych w [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* Korzystając z metod [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) i [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/), możesz ustawić wygląd ścieżki geometrycznej.
* Używając metody [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/), możesz pobrać ścieżkę geometryczną obiektu [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) jako tablicę odcinków ścieżki.

## **Proste operacje edycji**

Użyj poniższych metod, aby edytować ścieżkę geometryczną. Przeciążenia przyjmujące indeks wstawiają odcinek w podanej zerobazowej pozycji w tablicy odcinków ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Dodaj lub wstaw krzywą Béziera trzeciego stopnia z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Dodaj lub wstaw krzywą Béziera kwadratową z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Dodaj łuk eliptyczny o określonych wymiarach i kątach w stopniach. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Ustaw punkt początkowy figury. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Usuń odcinek pod zerobazowym indeksem. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Dodawanie własnych punktów do kształtu**

Ten przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) i stosuje edytowaną ścieżkę za pomocą [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego centrum, 100 punktów od lewej krawędzi i 50 punktów od górnej. Indeksy odcinków 1 i 4 umieszczają je na górnej i dolnej krawędzi, ściągając te krawędzie do środka.

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

## **Usuwanie punktów z kształtu**

Ten przykład modyfikuje obrys serca, usuwając odcinek o zerobazowym indeksie 2 przy użyciu [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Zastosowanie zmodyfikowanej ścieżki za pomocą [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) aktualizuje kontur kształtu.

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

## **Tworzenie własnego kształtu**

Ten przykład buduje pięcioramienną gwiazdę przy użyciu [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Naprzemienne promienie zewnętrzne i wewnętrzne o wartościach 100 i 50 punktów określają wierzchołki i wcięcia; krok 72 stopni równomiernie rozmieszcza pięć wierzchołków. Ścieżka jest zamykana metodą [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) i stosowana do prostokątnego kształtu za pomocą [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), zastępując jego obrys.

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

## **Tworzenie złożonego własnego kształtu**

Ten przykład definiuje dwie zamknięte ścieżki [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) dla górnej i dolnej jednej trzeciej kształtu. Zastosowanie obu ścieżek metodą [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) tworzy jeden złożony kształt z przerwą w środkowej jednej trzeciej.

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

## **Tworzenie własnego kształtu z zaokrąglonymi narożnikami**

Ten przykład łączy proste odcinki z [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/), aby utworzyć kształt z wklęsłymi, zakrzywionymi narożnikami. Rozmiar każdego narożnika określa szerokość i wysokość łuku w punktach, a kąt -90 stopni rysuje przeciwclockwise ćwiartkowy elipsę. Gotowa ścieżka jest stosowana metodą [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), a prezentacja jest zapisywana w formacie PPTX.

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

## **Sprawdzanie, czy geometria kształtu jest zamknięta**

Poniższy pomocniczy kod sprawdza, czy każda niepusta ścieżka geometryczna kończy się odcinkiem zamykającym. Odczytuje [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) i porównuje polecenie ostatniego odcinka [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) z [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Zwraca false, gdy nie ma niepustych ścieżek. Sprawdza on końcowe polecenie każdej ścieżki; nie analizuje wszystkich podfigur w obrębie jednej ścieżki. Przykład wypisuje `True` dla prostokąta.

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

## **Inspekcja poleceń ścieżki geometrycznej**

Pobierz plik [contour.pptx](contour.pptx) i umieść go w katalogu roboczym aplikacji. Pierwszy kształt na pierwszym slajdzie ma prostą górną krawędź, krzywą Béziera trzeciego stopnia oraz prostą krawędź zamykającą. Użyj [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/), aby odczytać jego ścieżki. Dla każdej ścieżki metoda [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) zwraca odcinki w kolejności rysowania. Polecenie zwrócone przez [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) określa, jak interpretować wartości zwrócone przez [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/).

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

Kształt znajduje się w punkcie (200, 100) na slajdzie. Zgłoszone punkty są lokalne względem kształtu, przy (0, 0) w jego lewym górnym rogu, x rośnie w prawo, a y w dół. Odcinek zamykający powraca do punktu początkowego bez dodatkowych współrzędnych.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![Kształt PowerPoint z prostą górną krawędzią, zakrzywioną krawędzią od górnego prawego do dolnego lewego oraz prostą lewą krawędzią](contour.png)

## **Wyodrębnianie i inspekcja elementów kształtu**

Użyj [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/), aby przeanalizować istniejący kształt jako elementy zawierające punkty ścieżki i typy punktów. Rzutuj każdy zwrócony [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) na [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/), aby odczytać tablice zwrócone przez [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) i [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Taka reprezentacja jest przydatna przy analizie konturu lub przekazywaniu geometrii do własnych narzędzi rysujących.

Przykład otwiera prezentację, znajduje pierwszy kształt geometryczny bezpośrednio na pierwszym slajdzie i wypisuje jego odcinki ścieżki. Użyj prezentacji zawierającej kształt z odcinkami prostymi i krzywymi, aby zobaczyć oba rodzaje wyników. Nie przeszukuje on grup.

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
        auto pointType = types[i] & 0x07; // Zachowaj typ odcinka, wykluczając flagi.
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
                i += 2; // Zużyj oba punkty kontrolne i punkt końcowy.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Tablice odpowiadają sobie indeksowo: `points[i]` jest punktem, a `types[i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Odcinek krzywej Béziera trzeciego stopnia zaczyna się w poprzednim punkcie końcowym i wykorzystuje trzy kolejne wpisy typu `3`: dwa punkty kontrolne oraz nowy punkt końcowy. Pętla konsumuje te trzy wpisy razem i sprawdza punkt końcowy pod kątem zamknięcia.

Typy punktów zawierają także flagi. Maskuj wartość `0x07`, aby określić typ odcinka, oraz testuj `0x80` osobno, aby wykryć zamkniętą podścieżkę. Na przykład `129` (`0x81`) oznacza punkt końcowy linii zamykający podścieżkę, a `131` (`0x83`) oznacza punkt końcowy krzywej Béziera zamykający podścieżkę. Porównywanie surowej wartości jedynie z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak kreska (`0x10`) i znacznik (`0x20`), nie zmieniają podstawowego typu odcinka.

**Współrzędne i przekształcenia.** Punkty są mierzone w punktach (1/72 cala), przy czym X rośnie w prawo, a Y w dół. Dla niezagregowanego kształtu wyodrębnione współrzędne już zawierają pozycję zwróconą przez [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) i [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) oraz odzwierciedlają jego aktualną szerokość i wysokość. Na przykład nieobrócony prostokąt w `(100, 200)` o wymiarach `120 × 80` ma granice konturu `(100, 200)`–`(220, 280)`. Nie dodawaj ponownie pozycji kształtu. Odejmij jego X i Y, aby uzyskać współrzędne względem nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają obrotu ustawionego przez [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) ani odbić poziomych i pionowych. Aby odtworzyć wyświetlany kontur, zastosuj te przekształcenia wokół środka kształtu. Dla kształtów zagregowanych uwzględnij także mapowanie współrzędnych grupy i przekształcenia; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi slajdu ani nie stosuj podwójnego przesunięcia lub skalowania, jeśli już zostały uwzględnione w ramce dziecka.

**Inspekcja versus edycja.** Wyodrębnione tablice opisują kontur; zmiana ich nie aktualizuje oryginalnego kształtu. Wybierz to podejście, gdy Twoja analiza lub kod rysujący wymaga tablic punktów/typów. Użyj [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/), gdy potrzebujesz poleceń geometrycznych w lokalnym układzie współrzędnych kształtu lub chcesz edytować jego geometrię. Zastosuj edytowane ścieżki przez [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) lub [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Konwersja GeometryPath na GraphicsPath**

Obecne publiczne API Aspose.Slides dla C++ nie udostępnia konwersji pomiędzy ścieżkami geometrycznymi a ścieżkami graficznymi. Aby przeanalizować kontur, użyj elementów kształtu, jak opisano powyżej. Aby edytować kształt, użyj ścieżek geometrycznych i zastosuj zaktualizowane ścieżki do kształtu.

## **FAQ**

**Co się stanie z wypełnieniem i obrysem po zastąpieniu geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się tylko kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak prawidłowo obrócić własny kształt razem z jego geometrią?**

Użyj metody [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) kształtu; geometria obraca się wraz z kształtem, ponieważ jest związana z jego własnym układem współrzędnych.

**Czy mogę zamienić własny kształt na obraz, aby „zablokować” wynik?**

Tak. Wyeksportuj odpowiedni [slide](/slides/pl/cpp/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/cpp/shape-thumbnails/) do formatu rastrowego; ułatwi to dalszą pracę z złożonymi geometriami.