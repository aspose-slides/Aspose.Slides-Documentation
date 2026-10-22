---
title: Dostosuj kształty prezentacji w C++
linktitle: Kształt niestandardowy
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
- zakrzywiony narożnik
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++: ścieżki geometryczne, zakrzywione narożniki, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides poprzez edycję geometrii kształtu przy użyciu punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) i [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/), aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżek, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię do kształtu.

Pokazuje również, jak tworzyć własne i złożone kształty, budować kształty z zakrzywionymi narożnikami oraz określić, czy geometria kształtu jest zamknięta.

## **Zmiana kształtu przy użyciu punktów edycji**

W programie PowerPoint możesz używać **Edit Points**, aby zmodyfikować kwadrat:

* Przesuń róg do wewnątrz lub na zewnątrz.
* Dostosuj krzywiznę w punkcie.
* Dodaj nowe punkty.

Edycja punktów pozwala zmienić kontur kształtu lub użyć istniejącego kształtu jako podstawy do nowego.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Podczas edycji kształtów w PowerPoint, pamiętaj o następujących pojęciach:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Ścieżka kształtu składa się z punktów kotwic połączonych odcinkami.
* Odcinek może być prosty lub zakrzywiony. Punkty kotwic i uchwyty kontrolne określają jego kształt.
* Punkty kotwic występują jako punkty narożne, proste lub płynne:
  * W punkcie narożnym sąsiadujące odcinki mogą łączyć się pod kątem.
  * W punkcie płynnym dwa uchwyty kontrolne są wyrównane i znajdują się w równych odległościach od punktu kotwicy.
  * W punkcie prostym dwa uchwyty kontrolne są wyrównane, ale mogą znajdować się w różnych odległościach od punktu kotwicy.
* Przesuwanie punktów kotwic lub dostosowywanie ich uchwytów zmienia kontur kształtu.

Aby edytować kształty PowerPoint przy użyciu punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) oraz interfejs [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) z instancji [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), możesz użyć metody [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) dla kształtu, możesz użyć następujących metod: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) dla kształtów z jedną ścieżką oraz [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) dla kształtów z wieloma ścieżkami.
* Aby dodać odcinki, możesz użyć metod dostępnych w [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* Korzystając z metod [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) i [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/), możesz ustawić wygląd ścieżki geometrycznej.
* Korzystając z metody [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/), możesz pobrać ścieżkę geometryczną [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) jako tablicę segmentów ścieżki.

## **Proste operacje edycji**

Użyj poniższych metod, aby edytować ścieżkę geometryczną. Przeciążenia przyjmujące indeks wstawiają odcinek na tej zerowo‑indeksowanej pozycji w tablicy odcinków ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Dodaj lub wstaw krzywą Bézier o stopniu sześciennym z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Dodaj lub wstaw kwadratową krzywą Bézier z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Dodaj łuk eliptyczny o określonych wymiarach i kątach w stopniach. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Ustaw punkt początkowy figury. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Usuń odcinek o zerowo‑indeksowanej pozycji. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Dodaj własne punkty do kształtu**

Ten przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) i zastosowuje edytowaną ścieżkę za pomocą [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego centrum, 100 punktów od lewej i 50 punktów od górnej krawędzi. Indeksy odcinków 1 i 4 umieszczają je odpowiednio na górnej i dolnej krawędzi, ściągając te krawędzie do środka.

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

## **Usuń punkty z kształtu**

Ten przykład zmienia kontur w kształcie serca, usuwając odcinek o zerowo‑indeksowanym indeksie 2 za pomocą [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Zastosowanie zmodyfikowanej ścieżki za pomocą [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) aktualizuje obrys kształtu.

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

## **Utwórz własny kształt**

Ten przykład tworzy pięcioramienną gwiazdę przy użyciu [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Naprzemienne zewnętrzne i wewnętrzne promienie wynoszące 100 i 50 punktów definiują szczyty i wcięcia; krok 72 stopni równomiernie rozmieszcza pięć szczytów. Ścieżka jest zamykana metodą [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/), a następnie zastosowana do prostokątnego kształtu przy pomocy [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), zastępując jego kontur.

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

## **Utwórz złożony własny kształt**

Ten przykład definiuje dwie zamknięte obiekty [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) dla górnej i dolnej trzeciej części kształtu. Zastosowanie obu ścieżek przy pomocy [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) tworzy pojedynczy złożony kształt z przerwą w środkowej trzeciej części.

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

## **Utwórz własny kształt z zakrzywionymi narożnikami**

Ten przykład łączy proste odcinki z [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/), aby utworzyć kształt z wklęsłymi zakrzywionymi narożnikami. Rozmiar każdego narożnika określa szerokość i wysokość łuku w punktach, a kąt obrotu -90 stopni rysuje elipsę ćwiartkową w kierunku przeciwnym do ruchu wskazówek zegara. Gotowa ścieżka jest zastosowana przy pomocy [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), a prezentacja zostaje zapisana w formacie PPTX.

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

## **Sprawdź, czy geometria kształtu jest zamknięta**

Poniższy pomocnik sprawdza, czy każda niepusta ścieżka geometryczna kończy się odcinkiem zamykającym. Odczytuje [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) i porównuje polecenie ostatniego odcinka [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) z [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Zwraca wartość false, gdy nie ma niepustych ścieżek. Sprawdza on polecenie końcowe każdej ścieżki; nie analizuje każdej podfigury w ścieżce. Przykład wypisuje `True` dla prostokąta.

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

## **Wyodrębnij i sprawdź elementy kształtu**

Użyj [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/), aby przejrzeć istniejący kształt jako elementy zawierające punkty ścieżki i typy punktów. Rzutuj każdy zwrócony [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) na [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/), aby odczytać tablice zwracane przez [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) i [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Ta reprezentacja jest przydatna do analizy konturu lub przekazywania geometrii do własnych narzędzi rysunkowych.

Przykład otwiera prezentację, znajduje pierwszy kształt geometryczny bezpośrednio na pierwszym slajdzie i wypisuje jego segmenty ścieżki. Użyj prezentacji zawierającej kształt z prostymi i zakrzywionymi odcinkami, aby zobaczyć oba rodzaje wyników. Nie przeszukuje elementów wewnątrz grup.

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
        auto pointType = types[i] & 0x07; // Zachowaj typ segmentu, pomijając flagi.
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
                i += 2; // Zużyj oba punkty kontrolne oraz punkt końcowy.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Tablice odpowiadają sobie po indeksie: `points[i]` jest punktem, a `types[i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Segment Bézier stopnia sześciennego rozpoczyna się w poprzednim punkcie końcowym i wykorzystuje trzy kolejne wpisy typu `3`: dwa punkty kontrolne, po czym następuje nowy punkt końcowy. Pętla konsumuje te trzy wpisy razem i sprawdza punkt końcowy pod kątem zamknięcia.

Typy punktów zawierają także flagi. Maskuj przy użyciu `0x07`, aby zidentyfikować typ segmentu, oraz testuj osobno `0x80`, aby wykryć zamkniętą podścieżkę. Na przykład `129` (`0x81`) oznacza punkt końcowy linii zamykający podścieżkę, a `131` (`0x83`) oznacza punkt końcowy Bézier zamykający podścieżkę. Porównywanie surowej wartości tylko z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak kreska (`0x10`) i znacznik (`0x20`), nie zmieniają podstawowego typu segmentu.

**Współrzędne i przekształcenia.**  
Punkty mierzone są w punktach (1/72 cala), przy czym X rośnie w prawo, a Y w dół. Dla niezgrupowanego kształtu wyodrębnione współrzędne już zawierają pozycję zwróconą przez [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) i [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/), odzwierciedlając jego aktualną szerokość i wysokość. Na przykład, nieobrócony prostokąt o współrzędnych `(100, 200)` i rozmiarze `120 × 80` ma granice konturu `(100, 200)`–`(220, 280)`. Nie dodawaj ponownie pozycji kształtu. Odejmij jego X i Y, aby uzyskać współrzędne względem nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają rotacji ustawionej przez [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) ani odbić poziomych i pionowych. Aby odtworzyć wyświetlany kontur, zastosuj te przekształcenia wokół środka kształtu. Dla kształtów zgrupowanych uwzględnij także mapowanie współrzędnych grupy i przekształcenia; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi renderowanego slajdu ani nie stosuj translacji lub skalowania dwukrotnie, jeśli już jest odzwierciedlone w ramce dziecka.

**Inspekcja vs. edycja.**  
Wyodrębnione tablice opisują kontur; ich modyfikacja nie aktualizuje oryginalnego kształtu. Wybierz to podejście, gdy Twoja analiza lub kod rysujący wymaga tablic punktów/typów. Użyj [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/), gdy potrzebujesz poleceń geometrycznych w lokalnym układzie współrzędnych kształtu lub chcesz edytować jego geometrię. Zastosuj edytowane ścieżki za pomocą [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) lub [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Konwertuj GeometryPath na GraphicsPath**

Obecne publiczne API Aspose.Slides dla C++ nie udostępnia konwersji między ścieżkami geometrycznymi a ścieżkami graficznymi. Aby przeanalizować kontur, użyj elementów kształtu opisanych powyżej. Aby edytować kształt, użyj ścieżek geometrycznych i zastosuj zaktualizowane ścieżki do kształtu.

## **FAQ**

**Co się stanie z wypełnieniem i obrysem po zastąpieniu geometrii?**  
Styl pozostaje przypisany do kształtu; zmienia się tylko kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak poprawnie obrócić własny kształt wraz z jego geometrią?**  
Użyj metody [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) kształtu; geometria obraca się razem z kształtem, ponieważ jest związana z jego własnym układem współrzędnych.

**Czy mogę przekonwertować własny kształt na obraz, aby „zablokować” wynik?**  
Tak. Wyeksportuj wymagany obszar [slide](/slides/pl/cpp/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/cpp/shape-thumbnails/) do formatu rastrowego; ułatwia to dalszą pracę z złożonymi geometriami.