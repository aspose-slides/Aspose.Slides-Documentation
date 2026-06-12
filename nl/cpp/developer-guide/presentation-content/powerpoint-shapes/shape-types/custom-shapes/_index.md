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
- geometrisch pad
- padpunten
- bewerkingspunten
- punt toevoegen
- punt verwijderen
- bewerkingsoperatie
- gebogen hoek
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Vormen maken en aanpassen in PowerPoint-presentaties met Aspose.Slides voor C++: geometrische paden, gebogen hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe u presentaties‑vormen in Aspose.Slides kunt aanpassen door de vormgeometrie te bewerken via bewerkingspunten en geometrische paden. Het toont hoe u met `GeometryPath` en `IGeometryPath` bestaande vormen kunt wijzigen, basisbewerkingsbeweringen kunt uitvoeren, punten kunt toevoegen of verwijderen, en de bijgewerkte geometrie terug kunt toepassen op een vorm.

## **Een Vorm Wijzigen Met Bewerkingspunten**
Stel een vierkant voor. In PowerPoint, met **bewerkingspunten**, kunt u

* de hoek van het vierkant naar binnen of buiten verplaatsen
* de kromming van een hoek of punt specificeren
* nieuwe punten aan het vierkant toevoegen
* punten op het vierkant manipuleren, enz.

In principe kunt u de beschreven handelingen op elke vorm uitvoeren. Met bewerkingspunten kunt u een vorm wijzigen of een nieuwe vorm maken op basis van een bestaande vorm.

## **Tips Voor Het Bewerken Van Vormen**

![overview_image](custom_shape_0.png)

Voordat u PowerPoint‑vormen gaat bewerken via bewerkingspunten, wilt u misschien de volgende punten over vormen in overweging nemen:

* Een vorm (of het pad ervan) kan gesloten of open zijn.
* Wanneer een vorm gesloten is, heeft deze geen begin‑ of eindpunt.
* Wanneer een vorm open is, heeft deze een begin‑ en eindpunt.
* Alle vormen bestaan uit ten minste 2 ankerpunten die met elkaar verbonden zijn door lijnen.
* Een lijn is recht of gebogen. Ankerpunten bepalen de aard van de lijn.
* Ankerpunten bestaan als hoekpunten, rechte punten of gladde punten:
  * Een hoekpunt is een punt waar twee rechte lijnen onder een hoek samenkomen.
  * Een glad punt is een punt waar twee handvatten zich op een rechte lijn bevinden en de lijnsegmenten in een vloeiende curve samenkomen. In dit geval staan alle handvatten op gelijke afstand van het ankerpunt.
  * Een recht punt is een punt waar twee handvatten zich op een rechte lijn bevinden en die lijnsegmenten in een vloeiende curve samenkomen. In dit geval hoeven de handvatten niet op gelijke afstand van het ankerpunt te staan.
* Door ankerpunten te verplaatsen of te bewerken (wat de hoek van de lijnen verandert), kunt u het uiterlijk van een vorm wijzigen.

Om PowerPoint‑vormen via bewerkingspunten te bewerken, biedt **Aspose.Slides** de klasse [**GeometryPath**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_path) en de interface [**IGeometryPath**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_geometry_path).

* Een [GeometryPath](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_path)‑instantie vertegenwoordigt een geometrisch pad van het [IGeometryShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_geometry_shape)‑object.
* Om de `GeometryPath` op te halen van de `IGeometryShape`‑instantie, kunt u de methode [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1) gebruiken.
* Om de `GeometryPath` voor een vorm in te stellen, kunt u deze methoden gebruiken: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) voor *solid shapes* en [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) voor *composite shapes*.
* Om segmenten toe te voegen, kunt u de methoden onder [IGeometryPath](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_geometry_path) gebruiken.
* Met de methoden [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) en [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) kunt u het uiterlijk van een geometrisch pad instellen.
* Met de methode [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) kunt u het geometrische pad van een `GeometryShape` ophalen als een array van padsegmenten.
* Om extra opties voor het aanpassen van vormgeometrie te benaderen, kunt u [GeometryPath](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_path) omzetten naar [GraphicsPath](https://reference.aspose.com/slides/nl/cpp/class/system.drawing.drawing2_d.graphics_path).
* Gebruik de methoden [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) en [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (van de [ShapeUtil](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.util.shape_util)‑klasse) om [GeometryPath](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_path) om te zetten naar [GraphicsPath](https://reference.aspose.com/slides/nl/cpp/class/system.drawing.drawing2_d.graphics_path) en terug.

## **Eenvoudige Bewerkingstaken**

Deze C++‑code laat zien hoe u

**Voeg een lijn toe** aan het einde van een pad

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Voeg een lijn toe** op een opgegeven positie in een pad:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Voeg een kubieke Bézier‑curve toe** aan het einde van een pad:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Voeg een kubieke Bézier‑curve toe** op de opgegeven positie in een pad:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Voeg een kwadratische Bézier‑curve toe** aan het einde van een pad:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Voeg een kwadratische Bézier‑curve toe** op een opgegeven positie in een pad:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Voeg een opgegeven boog toe** aan een pad:

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Sluit de huidige figuur** van een pad:

``` cpp
void CloseFigure();
```
**Stel de positie in voor het volgende punt**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Verwijder het padsegment** op een opgegeven index:

``` cpp
void RemoveAt(int32_t index);
```
## **Aangepaste Punten Aan Een Vorm Toevoegen**
1. Maak een instantie van de klasse [GeometryShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_shape) aan en stel het type [ShapeType.Rectangle](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5) in.
2. Haal een instantie van de klasse [GeometryPath](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_path) op van de vorm.
3. Voeg een nieuw punt toe tussen de twee bovenste punten op het pad.
4. Voeg een nieuw punt toe tussen de twee onderste punten op het pad.
5. Pas het pad toe op de vorm.

Deze C++‑code laat zien hoe u aangepaste punten aan een vorm kunt toevoegen:

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

## **Punten Van Een Vorm Verwijderen**

1. Maak een instantie van de klasse [GeometryShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_shape) aan en stel het type [ShapeType.Heart](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5) in.
2. Haal een instantie van de klasse [GeometryPath](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_path) op van de vorm.
3. Verwijder het segment van het pad.
4. Pas het pad toe op de vorm.

Deze C++‑code laat zien hoe u punten uit een vorm kunt verwijderen:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Aangepaste Vorm Maken**

1. Bereken de punten voor de vorm.
2. Maak een instantie van de klasse [GeometryPath](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_path) aan.
3. Vul het pad met de punten.
4. Maak een instantie van de klasse [GeometryShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_shape) aan.
5. Pas het pad toe op de vorm.

Deze C++‑code laat zien hoe u een aangepaste vorm kunt maken:

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


## **Een Samengestelde Aangepaste Vorm Maken**

  1. Maak een instantie van de klasse [GeometryShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_shape) aan.
  2. Maak een eerste instantie van de klasse [GeometryPath](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_path) aan.
  3. Maak een tweede instantie van de klasse [GeometryPath](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_path) aan.
  4. Pas de paden toe op de vorm.

Deze C++‑code laat zien hoe u een samengestelde aangepaste vorm kunt maken:

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

## **Een Aangepaste Vorm Met Gebogen Hoeken Maken**

Deze C++‑code laat zien hoe u een aangepaste vorm met gebogen hoeken (naar binnen) kunt maken;

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

## **Controleren Of Een Vormgeometrie Gesloten Is**

Een gesloten vorm wordt gedefinieerd als een vorm waarbij al haar zijden met elkaar verbonden zijn, waardoor er één enkele rand ontstaat zonder gaten. Zo’n vorm kan een eenvoudige geometrische vorm zijn of een complexe aangepaste omtrek. De volgende code‑voorbeeld toont hoe u kunt controleren of een vormgeometrie gesloten is:

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

## **GeometryPath Omzetten Naar GraphicsPath** 

1. Maak een instantie van de klasse [GeometryShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_shape) aan.
2. Maak een instantie van de klasse [GraphicsPath](https://reference.aspose.com/slides/nl/cpp/class/system.drawing.drawing2_d.graphics_path) van de namespace [System.Drawing.Drawing2D](https://reference.aspose.com/slides/nl/cpp/namespace/system.drawing.drawing2_d) aan.
3. Converteer de [GraphicsPath](https://reference.aspose.com/slides/nl/cpp/class/system.drawing.drawing2_d.graphics_path)‑instantie naar de [GeometryPath](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.geometry_path)‑instantie met behulp van [ShapeUtil](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.util.shape_util).
4. Pas de paden toe op de vorm.

Deze C++‑code—een implementatie van de bovenstaande stappen—demonstrtert het conversieproces van **GeometryPath** naar **GraphicsPath**:

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

**Wat gebeurt er met de opvulling en de omtrek nadat de geometrie is vervangen?**

De stijl blijft behouden bij de vorm; alleen de contour wordt gewijzigd. De opvulling en omtrek worden automatisch toegepast op de nieuwe geometrie.

**Hoe roteer ik een aangepaste vorm correct samen met haar geometrie?**

Gebruik de [rotation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/set_rotation/)‑eigenschap van de vorm; de geometrie roteert mee met de vorm omdat deze gebonden is aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm converteren naar een afbeelding om het resultaat 'vast te zetten'?**

Ja. Exporteer het benodigde [slide](/slides/nl/cpp/convert-powerpoint-to-png/)‑gebied of de [shape](/slides/nl/cpp/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verder werk met zware geometrieën.