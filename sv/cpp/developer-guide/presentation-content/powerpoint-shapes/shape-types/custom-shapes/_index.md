---
title: Anpassa presentationsformer i C++
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/cpp/custom-shape/
keywords:
- anpassad form
- lägg till form
- skapa form
- ändra form
- formgeometri
- geometrisk bana
- banpunkter
- redigeringspunkter
- lägg till punkt
- ta bort punkt
- redigeringsoperation
- krökt hörn
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa och anpassa former i PowerPoint-presentationer med Aspose.Slides för C++: geometriska banor, krökta hörn, sammansatta former."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar presentationsformer i Aspose.Slides genom att redigera formgeometri via redigeringspunkter och geometriska banor. Den visar hur du arbetar med `GeometryPath` och `IGeometryPath` för att ändra befintliga former, utföra grundläggande redigeringsoperationer för banor, lägga till eller ta bort punkter och tillämpa uppdaterad geometri på en form.

## **Ändra en form med hjälp av redigeringspunkter**
Tänk på en kvadrat. I PowerPoint, med **redigeringspunkter**, kan du 

* flytta kvadratens hörn inåt eller utåt  
* ange krökning för ett hörn eller en punkt  
* lägga till nya punkter till kvadraten  
* manipulera punkter på kvadraten osv.  

I princip kan du utföra de beskrivna uppgifterna på vilken form som helst. Med redigeringspunkter kan du ändra en form eller skapa en ny form utifrån en befintlig form. 

## **Tips för redigering av former**

![overview_image](custom_shape_0.png)

Innan du börjar redigera PowerPoint‑former via redigeringspunkter kan du fundera på dessa aspekter av former:

* En form (eller dess bana) kan antingen vara sluten eller öppen.  
* När en form är sluten saknar den en start‑ eller slutpunkt. När en form är öppen har den ett början och ett slut.  
* Alla former består av minst två ankarpunkter som är kopplade till varandra med linjer.  
* En linje är antingen rak eller kurvig. Ankarnpunkterna bestämmer linjens natur.  
* Ankarnpunkter finns som hörnpunkter, raka punkter eller jämna punkter:  
  * En hörnpunkt är en punkt där två raka linjer möts i en vinkel.  
  * En jämn punkt är en punkt där två handtag finns på en rak linje och linjesegmenten förenas i en mjuk kurva. I detta fall är alla handtag separerade från ankarnpunkten med lika stort avstånd.  
  * En rak punkt är en punkt där två handtag finns på en rak linje och linjesegmenten förenas i en mjuk kurva. I detta fall behöver handtagen inte vara lika långt från ankarnpunkten.  
* Genom att flytta eller redigera ankarnpunkter (vilket ändrar linjernas vinklar) kan du förändra hur en form ser ut.  

För att redigera PowerPoint‑former via redigeringspunkter tillhandahåller **Aspose.Slides** klassen [**GeometryPath**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_path) och gränssnittet [**IGeometryPath**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_geometry_path).

* En [GeometryPath](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_path)-instans representerar en geometrisk bana för objektet [IGeometryShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_geometry_shape).  
* För att hämta `GeometryPath` från `IGeometryShape`‑instansen kan du använda metoden [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1).  
* För att ange `GeometryPath` för en form kan du använda dessa metoder: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) för *solida former* och [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) för *komposita former*.  
* För att lägga till segment kan du använda metoderna under [IGeometryPath](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_geometry_path).  
* Genom att använda metoderna [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) och [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) kan du ange utseendet för en geometrisk bana.  
* Genom att använda metoden [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) kan du hämta geometribanan för en `GeometryShape` som en array av bansegment.  
* För att komma åt ytterligare anpassningsalternativ för formgeometri kan du konvertera [GeometryPath](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_path) till [GraphicsPath](https://reference.aspose.com/slides/sv/cpp/class/system.drawing.drawing2_d.graphics_path).  
* Använd metoderna [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) och [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (från klassen [ShapeUtil](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.util.shape_util)) för att konvertera [GeometryPath](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_path) till [GraphicsPath](https://reference.aspose.com/slides/sv/cpp/class/system.drawing.drawing2_d.graphics_path) och tillbaka.  

## **Enkla redigeringsoperationer**

Den här C++‑koden visar hur du

**Lägg till en linje** i slutet av en bana

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Lägg till en linje** på en specificerad position i en bana:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Lägg till en kubisk Bezier‑kurva** i slutet av en bana:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Lägg till en kubisk Bezier‑kurva** på den specificerade positionen i en bana:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Lägg till en kvadratisk Bezier‑kurva** i slutet av en bana:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Lägg till en kvadratisk Bezier‑kurva** på en specificerad position i en bana:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Lägg till en given båge** till en bana:

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Stäng den aktuella figuren** i en bana:

``` cpp
void CloseFigure();
```
**Ange positionen för nästa punkt**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Ta bort bansegmentet** vid ett givet index:

``` cpp
void RemoveAt(int32_t index);
```
## **Lägg till anpassade punkter till en form**
1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_shape) och ange typen [ShapeType.Rectangle](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Hämta en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_path) från formen.  
3. Lägg till en ny punkt mellan de två övre punkterna på banan.  
4. Lägg till en ny punkt mellan de två nedre punkterna på banan.  
5. Tillämpa banan på formen.  

Den här C++‑koden visar hur du lägger till anpassade punkter till en form:

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

## **Ta bort punkter från en form**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_shape) och ange typen [ShapeType.Heart](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Hämta en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_path) från formen.  
3. Ta bort segmentet för banan.  
4. Tillämpa banan på formen.  

Den här C++‑koden visar hur du tar bort punkter från en form:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Skapa en anpassad form**

1. Beräkna punkterna för formen.  
2. Skapa en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_path).  
3. Fyll banan med punkterna.  
4. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_shape).  
5. Tillämpa banan på formen.  

Den här C++‑koden visar hur du skapar en anpassad form:

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


## **Skapa en sammansatt anpassad form**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_shape).  
2. Skapa en första instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_path).  
3. Skapa en andra instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_path).  
4. Tillämpa banorna på formen.  

Den här C++‑koden visar hur du skapar en sammansatt anpassad form:

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

## **Skapa en anpassad form med krökta hörn**

Den här C++‑koden visar hur du skapar en anpassad form med krökta hörn (inåtriktade);

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

## **Ta reda på om en formgeometri är sluten**

En sluten form definieras som en där alla sidor är sammankopplade och bildar en enda gräns utan luckor. En sådan form kan vara en enkel geometrisk form eller en komplex anpassad kontur. Följande kodexempel visar hur du kontrollerar om en formgeometri är sluten:

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

## **Konvertera GeometryPath till GraphicsPath** 

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_shape).  
2. Skapa en instans av klassen [GraphicsPath](https://reference.aspose.com/slides/sv/cpp/class/system.drawing.drawing2_d.graphics_path) i namnområdet [System.Drawing.Drawing2D](https://reference.aspose.com/slides/sv/cpp/namespace/system.drawing.drawing2_d).  
3. Konvertera [GraphicsPath](https://reference.aspose.com/slides/sv/cpp/class/system.drawing.drawing2_d.graphics_path)-instansen till [GeometryPath](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.geometry_path)-instansen med hjälp av [ShapeUtil](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.util.shape_util).  
4. Tillämpa banorna på formen.  

Den här C++‑koden—en implementering av stegen ovan—demonstrerar konverteringsprocessen från **GeometryPath** till **GraphicsPath**:

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

## **Vanliga frågor**

**Vad händer med fyllning och kontur efter att geometrin ersatts?**

Stilen förblir på formen; endast konturen ändras. Fyllning och kontur tillämpas automatiskt på den nya geometrin.

**Hur roterar jag korrekt en anpassad form tillsammans med dess geometri?**

Använd formens [rotation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/set_rotation/)‑egenskap; geometrin roterar med formen eftersom den är bunden till formens eget koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att "låsa" resultatet?**

Ja. Exportera det önskade [slide](/slides/sv/cpp/convert-powerpoint-to-png/)-området eller själva [shape](/slides/sv/cpp/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med tunga geometrier.