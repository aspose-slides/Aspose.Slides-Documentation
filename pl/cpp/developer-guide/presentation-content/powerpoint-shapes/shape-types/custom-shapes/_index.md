---
title: Dostosuj kształty prezentacji w C++
linktitle: Niestandardowy kształt
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
- punkty edycji
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

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides, edytując geometrię kształtu za pomocą punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z `GeometryPath` i `IGeometryPath`, aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżki, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię do kształtu.

## **Zmienianie kształtu przy użyciu punktów edycji**
Weźmy pod uwagę kwadrat. W PowerPoint, używając **punktów edycji**, możesz  

* przesunąć róg kwadratu do wewnątrz lub na zewnątrz  
* określić krzywiznę rogu lub punktu  
* dodać nowe punkty do kwadratu  
* manipulować punktami kwadratu itp.  

W zasadzie możesz wykonywać opisane zadania na dowolnym kształcie. Korzystając z punktów edycji, możesz zmienić istniejący kształt lub utworzyć nowy kształt na jego podstawie. 

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Zanim zaczniesz edytować kształty PowerPointa przy pomocy punktów edycji, rozważ następujące kwestie związane z kształtami:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.  
* Gdy kształt jest zamknięty, nie ma punktu początkowego ani końcowego. Gdy jest otwarty, ma początek i koniec.  
* Wszystkie kształty składają się co najmniej z 2 punktów kotwiczących połączonych liniami.  
* Linia może być prosta lub krzywa. Punkty kotwiczące określają charakter linii.  
* Punkty kotwiczące występują jako punkty narożne, proste lub gładkie:  
  * Punkt narożny to punkt, w którym 2 proste linie łączą się pod kątem.  
  * Punkt gładki to punkt, w którym 2 uchwyty leżą w jednej linii, a odcinki linii łączą się w płynne łuki. W tym przypadku wszystkie uchwyty są oddalone od punktu kotwiczącego o tę samą odległość.  
  * Punkt prosty to punkt, w którym 2 uchwyty leżą w jednej linii, a odcinki linii łączą się w łuk, ale uchwyty nie muszą być oddalone od punktu kotwiczącego o równą odległość.  
* Przesuwając lub edytując punkty kotwiczące (co zmienia kąt linii), możesz zmienić wygląd kształtu.  

Aby edytować kształty PowerPointa przy pomocy punktów edycji, **Aspose.Slides** udostępnia klasę [**GeometryPath**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_path) oraz interfejs [**IGeometryPath**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_geometry_path).

* Instancja [GeometryPath](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_path) reprezentuje ścieżkę geometryczną obiektu [IGeometryShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_geometry_shape).  
* Aby pobrać `GeometryPath` z instancji `IGeometryShape`, użyj metody [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1).  
* Aby ustawić `GeometryPath` dla kształtu, użyj metod: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) dla *kształtów jednorodnych* oraz [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) dla *kształtów złożonych*.  
* Aby dodać segmenty, użyj metod dostępnych w [IGeometryPath](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_geometry_path).  
* Korzystając z metod [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) i [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7), możesz ustawić wygląd ścieżki geometrycznej.  
* Metoda [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) umożliwia pobranie danych ścieżki geometrycznej `GeometryShape` jako tablicy segmentów ścieżki.  
* Aby uzyskać dodatkowe opcje dostosowywania geometrii kształtu, możesz przekonwertować [GeometryPath](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_path) na [GraphicsPath](https://reference.aspose.com/slides/pl/cpp/class/system.drawing.drawing2_d.graphics_path).  
* Użyj metod [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) i [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (z klasy [ShapeUtil](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.util.shape_util)) do konwersji [GeometryPath](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_path) na [GraphicsPath](https://reference.aspose.com/slides/pl/cpp/class/system.drawing.drawing2_d.graphics_path) i z powrotem.  

## **Proste operacje edycyjne**

Ten kod C++ pokazuje, jak  

**Dodać linię** na koniec ścieżki  

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Dodać linię** w określonej pozycji na ścieżce:  

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Dodać krzywą Beziera trzeciego stopnia** na koniec ścieżki:  

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Dodać krzywą Beziera trzeciego stopnia** w określonej pozycji na ścieżce:  

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Dodać krzywą Beziera drugiego stopnia** na koniec ścieżki:  

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Dodać krzywą Beziera drugiego stopnia** w określonej pozycji na ścieżce:  

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Dołączyć dany łuk** do ścieżki:  

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Zamknąć bieżącą figurę** ścieżki:  

``` cpp
void CloseFigure();
```
**Ustawić pozycję dla następnego punktu**:  

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Usunąć segment ścieżki** o podanym indeksie:  

``` cpp
void RemoveAt(int32_t index);
```
## **Dodawanie własnych punktów do kształtu**
1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_shape) i ustaw typ [ShapeType.Rectangle](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_path) z kształtu.  
3. Dodaj nowy punkt pomiędzy dwoma górnymi punktami ścieżki.  
4. Dodaj nowy punkt pomiędzy dwoma dolnymi punktami ścieżki.  
5. Zastosuj ścieżkę do kształtu.  

Ten kod C++ pokazuje, jak dodać własne punkty do kształtu:  

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Usuwanie punktów z kształtu**

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_shape) i ustaw typ [ShapeType.Heart](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_path) z kształtu.  
3. Usuń segment ścieżki.  
4. Zastosuj ścieżkę do kształtu.  

Ten kod C++ pokazuje, jak usunąć punkty z kształtu:  

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Tworzenie własnego kształtu**

1. Oblicz punkty dla kształtu.  
2. Utwórz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_path).  
3. Wypełnij ścieżkę punktami.  
4. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_shape).  
5. Zastosuj ścieżkę do kształtu.  

Ten kod C++ pokazuje, jak stworzyć własny kształt:  

``` cpp
SharedPtr<List<PointF>> points = System::MakeObject<List<PointF>>();

float R = 100.0f, r = 50.0f;
int32_t step = 72;

for (int32_t angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math::PI / 180.f);
    double x = outerRadius * Math::Cos(radians);
    double y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + step / 2) / 180.0;
    x = innerRadiusr * Math::Cos(radians);
    y = innerRadiusr * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

SharedPtr<GeometryPath> starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (int32_t i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, R * 2, R * 2));

shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)


## **Tworzenie złożonego własnego kształtu**

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_shape).  
2. Utwórz pierwszą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_path).  
3. Utwórz drugą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_path).  
4. Zastosuj ścieżki do kształtu.  

Ten kod C++ pokazuje, jak stworzyć złożony własny kształt:  

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath0 = System::MakeObject<GeometryPath>();
geometryPath0->MoveTo(0.0f, 0.0f);
geometryPath0->LineTo(shape->get_Width(), 0.0f);
geometryPath0->LineTo(shape->get_Width(), shape->get_Height() / 3);
geometryPath0->LineTo(0.0f, shape->get_Height() / 3);
geometryPath0->CloseFigure();

SharedPtr<IGeometryPath> geometryPath1 = System::MakeObject<GeometryPath>();
geometryPath1->MoveTo(0.0f, shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height());
geometryPath1->LineTo(0.0f, shape->get_Height());
geometryPath1->CloseFigure();

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ geometryPath0, geometryPath1 }));
```
![example4_image](custom_shape_4.png)

## **Tworzenie własnego kształtu z zaokrąglonymi narożnikami**

Ten kod C++ pokazuje, jak stworzyć własny kształt z wklęsłymi narożnikami;  

```cpp
float shapeX = 20.f;
float shapeY = 20.f;
float shapeWidth = 300.f;
float shapeHeight = 200.f;

float leftTopSize = 50.f;
float rightTopSize = 20.f;
float rightBottomSize = 40.f;
float leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();

auto childShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto geometryPath = System::MakeObject<GeometryPath>();

PointF point1(leftTopSize, 0.0f);
PointF point2(shapeWidth - rightTopSize, 0.0f);
PointF point3(shapeWidth, shapeHeight - rightBottomSize);
PointF point4(leftBottomSize, shapeHeight);
PointF point5(0.0f, leftTopSize);

geometryPath->MoveTo(point1);
geometryPath->LineTo(point2);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(point3);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(point4);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(point5);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);

geometryPath->CloseFigure();

childShape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Sprawdzanie, czy geometria kształtu jest zamknięta**

Zamknięty kształt definiuje się jako taki, którego wszystkie boki łączą się, tworząc jedną granicę bez przerw. Może to być prosta figura geometryczna lub złożony własny obrys. Poniższy przykład kodu pokazuje, jak sprawdzić, czy geometria kształtu jest zamknięta:  

```cpp
bool IsGeometryClosed(SharedPtr<IGeometryShape> geometryShape)
{
    bool isClosed = false;

    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto dataLength = geometryPath->get_PathData()->get_Length();
        if (dataLength == 0)
            continue;

        auto lastSegment = geometryPath->get_PathData()[dataLength - 1];
        isClosed = lastSegment->get_PathCommand() == PathCommandType::Close;

        if (!isClosed)
            return false;
    }

    return isClosed;
}
```

## **Konwersja GeometryPath do GraphicsPath** 

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_shape).  
2. Utwórz instancję klasy [GraphicsPath](https://reference.aspose.com/slides/pl/cpp/class/system.drawing.drawing2_d.graphics_path) z przestrzeni nazw [System.Drawing.Drawing2D](https://reference.aspose.com/slides/pl/cpp/namespace/system.drawing.drawing2_d).  
3. Przekonwertuj instancję [GraphicsPath](https://reference.aspose.com/slides/pl/cpp/class/system.drawing.drawing2_d.graphics_path) na instancję [GeometryPath](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.geometry_path) przy użyciu klasy [ShapeUtil](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.util.shape_util).  
4. Zastosuj ścieżki do kształtu.  

Ten kod C++ — implementacja powyższych kroków — demonstruje proces konwersji **GeometryPath** na **GraphicsPath**:  

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Text in shape", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co stanie się z wypełnieniem i obrysem po zamianie geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się jedynie kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak prawidłowo obrócić własny kształt razem z jego geometrią?**

Użyj właściwości [rotation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/set_rotation/) kształtu; geometria obraca się razem z nim, ponieważ jest powiązana z własnym układem współrzędnych kształtu.

**Czy mogę skonwertować własny kształt na obraz, aby „zablokować” wynik?**

Tak. Wyeksportuj wybrany [slide](/slides/pl/cpp/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/cpp/create-shape-thumbnails/) do formatu rastrowego; upraszcza to dalszą pracę z złożonymi geometriami.