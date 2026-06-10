---
title: Alakzatok testreszabása PowerPoint prezentációkban C++-ban
linktitle: Egyedi alakzat
type: docs
weight: 20
url: /hu/cpp/custom-shape/
keywords:
- egyedi alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzat geometriája
- geometriai útvonal
- útvonal pontok
- szerkesztési pontok
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

Ez a cikk bemutatja, hogyan lehet testreszabni a megjelenítési alakzatokat az Aspose.Slides-ban úgy, hogy a forma geometriáját szerkesztési pontokkal és geometriai útvonalakkal módosítjuk. Megmutatja, hogyan kell a `GeometryPath` és az `IGeometryPath` segítségével meglévő alakzatokat módosítani, alapvető útvonal‑szerkesztési műveleteket végezni, pontokat hozzáadni vagy eltávolítani, és a frissített geometriát visszaalkalmazni egy alakzatra.

## **Alakzat módosítása szerkesztési pontokkal**
Tekintsünk egy négyzetet. A PowerPointban a **szerkesztési pontok** használatával a következőket tehetjük:

* a négyzet sarkát befelé vagy kifelé mozgathatjuk
* megadhatjuk egy sarok vagy pont görbületét
* új pontokat adhatunk a négyzethez
* a négyzet pontjait manipulálhatjuk, stb.

Lényegében a leírt feladatokat bármely alakzatra elvégezhetjük. A szerkesztési pontok segítségével módosíthatunk egy alakzatot, vagy létrehozhatunk egy új alakzatot egy meglévőből.

## **Alakzat szerkesztési tippek**

![overview_image](custom_shape_0.png)

Mielőtt elkezdené szerkeszteni a PowerPoint‑alakzatokat szerkesztési pontokkal, vegye figyelembe a következőket az alakzatokról:

* Egy alakzat (vagy annak útvonala) lehet lezárt vagy nyitott.
* Ha egy alakzat lezárt, nincs kezdő‑ vagy végpontja. Ha nyitott, van kezdő‑ és végpontja. 
* Minden alakzat legalább 2 horgonypontból áll, amelyeket vonalak kötnek össze.
* Egy vonal lehet egyenes vagy ívelt. A horgonypontok határozzák meg a vonal típusát. 
* A horgonypontok létezhetnek sarokpontként, egyenespontként vagy sima pontként:
  * Egy sarokpont az a pont, ahol 2 egyenes vonal egy szögnél találkozik. 
  * Egy sima pont az a pont, ahol 2 fogantyú egy egyenes vonalban helyezkedik el, és a vonal szegmensei sima görbével csatlakoznak. Ebben az esetben minden fogantyú egyenlő távolságra van a horgonyponttól. 
  * Egy egyenespont az a pont, ahol 2 fogantyú egy egyenes vonalban helyezkedik el, de a vonal szegmensei nem feltétlenül egyenlő távolságra csatlakoznak a horgonyponttól. 
* A horgonypontok mozgatásával vagy szerkesztésével (amely megváltoztatja a vonalak szögét) megváltoztathatja az alakzat megjelenését. 

A PowerPoint‑alakzatok szerkesztéséhez szerkesztési pontokkal az **Aspose.Slides** a [**GeometryPath**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_path) osztályt és a [**IGeometryPath**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_geometry_path) interfészt biztosítja.

* Egy [GeometryPath](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_path) példány a [IGeometryShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_geometry_shape) objektum geometriai útvonalát képviseli. 
* A `GeometryPath` lekéréséhez a `IGeometryShape` példányból használja a [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1) metódust. 
* Egy alakzat `GeometryPath`‑jének beállításához használja a következő metódusokat: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) *szilárd alakzatok* esetén és [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) *összetett alakzatok* esetén.
* Szegmensek hozzáadásához használja a [IGeometryPath](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_geometry_path) alatti metódusokat. 
* A [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) és [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) metódusokkal állíthatja be a geometriai útvonal megjelenését.
* A [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) metódus segítségével a `GeometryShape` útvonalát egy útvonal‑szegmensekből álló tömbként kérheti le. 
* További alakzat‑geometria testreszabási lehetőségekhez konvertálhatja a [GeometryPath](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_path) objektumot egy [GraphicsPath](https://reference.aspose.com/slides/hu/cpp/class/system.drawing.drawing2_d.graphics_path) típusúra.
* Használja a [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) és a [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) metódusokat (a [ShapeUtil](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.util.shape_util) osztályból) a [GeometryPath](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_path) és a [GraphicsPath](https://reference.aspose.com/slides/hu/cpp/class/system.drawing.drawing2_d.graphics_path) közötti átalakításhoz mindkét irányban. 

## **Egyszerű szerkesztési műveletek**

Ez a C++ kód megmutatja, hogyan lehet

**Vonal hozzáadása** az útvonal végéhez

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Vonal hozzáadása** egy meghatározott pozícióban az útvonalon:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Köbös Bézier‑görbe hozzáadása** az útvonal végéhez:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Köbös Bézier‑görbe hozzáadása** a megadott pozíción az útvonalon:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Másodfokú Bézier‑görbe hozzáadása** az útvonal végéhez:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Másodfokú Bézier‑görbe hozzáadása** egy meghatározott pozícióban az útvonalon:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Megadott ív hozzáfűzése** az útvonalhoz:

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Az aktuális alakzat lezárása** az útvonalon:

``` cpp
void CloseFigure();
```
**A következő pont pozíciójának beállítása**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Az útvonal‑szegmens eltávolítása** egy adott indexnél:

``` cpp
void RemoveAt(int32_t index);
```
## **Egyedi pontok hozzáadása egy alakzathoz**
1. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_shape) osztályból, és állítsa be a [ShapeType.Rectangle](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5) típust.
2. Szerezzen egy példányt a [GeometryPath](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_path) osztályból az alakzatról.
3. Adjon hozzá egy új pontot a két felső pont között az útvonalon.
4. Adjon hozzá egy új pontot a két alsó pont között az útvonalon.
5. Alkalmazza az útvonalat az alakzatra.

Ez a C++ kód megmutatja, hogyan adhat hozzá egyedi pontokat egy alakzathoz:

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

## **Pontok eltávolítása egy alakzatról**

1. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_shape) osztályból, és állítsa be a [ShapeType.Heart](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5) típust. 
2. Szerezzen egy példányt a [GeometryPath](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_path) osztályból az alakzatról.
3. Távolítsa el a szegmenst az útvonalból.
4. Alkalmazza az útvonalat az alakzatra.

Ez a C++ kód megmutatja, hogyan távolíthat el pontokat egy alakzatról:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Egyedi alakzat létrehozása**

1. Számolja ki az alakzat pontjait.
2. Hozzon létre egy példányt a [GeometryPath](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_path) osztályból. 
3. Töltse fel az útvonalat a pontokkal.
4. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_shape) osztályból. 
5. Alkalmazza az útvonalat az alakzatra.

Ez a C++ kód megmutatja, hogyan hozhat létre egy egyedi alakzatot:

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


## **Összetett egyedi alakzat létrehozása**

1. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_shape) osztályból.
2. Hozzon létre egy első példányt a [GeometryPath](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_path) osztályból.
3. Hozzon létre egy második példányt a [GeometryPath](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_path) osztályból.
4. Alkalmazza az útvonalakat az alakzatra.

Ez a C++ kód megmutatja, hogyan hozhat létre egy összetett egyedi alakzatot:

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

## **Egyedi alakzat létrehozása ívelt sarkokkal**

Ez a C++ kód megmutatja, hogyan hozhat létre egy egyedi alakzatot ívelt sarkokkal (befelé):

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

## **Megállapítás, hogy egy alakzat geometriája zárt-e**

A zárt alakzat olyan, amelynek minden oldala összekapcsolódik, egyetlen határvonalat alkotva hézagok nélkül. Egy ilyen alakzat lehet egyszerű geometriai forma vagy összetett egyedi körvonal. Az alábbi kódrészlet bemutatja, hogyan ellenőrizheti, hogy egy alakzat geometriája zárt-e:

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

## **GeometryPath konvertálása GraphicsPath-re** 

1. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_shape) osztályból.
2. Hozzon létre egy példányt a [GraphicsPath](https://reference.aspose.com/slides/hu/cpp/class/system.drawing.drawing2_d.graphics_path) osztályból a [System.Drawing.Drawing2D](https://reference.aspose.com/slides/hu/cpp/namespace/system.drawing.drawing2_d) névtérben.
3. Konvertálja a [GraphicsPath](https://reference.aspose.com/slides/hu/cpp/class/system.drawing.drawing2_d.graphics_path) példányt a [GeometryPath](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.geometry_path) példányra a [ShapeUtil](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.util.shape_util) segítségével.
4. Alkalmazza az útvonalakat az alakzatra.

Ez a C++ kód – a fenti lépések megvalósítása – demonstrálja a **GeometryPath**‑t **GraphicsPath**‑re történő konvertálási folyamatot:

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

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria cseréje után?**

A stílus megmarad az alakzattal; csak a kontúr változik. A kitöltés és a körvonal automatikusan az új geometriára kerül alkalmazásra.

**Hogyan lehet helyesen elforgatni egy egyedi alakzatot a geometriájával együtt?**

Használja az alakzat [rotation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/set_rotation/) tulajdonságát; a geometria az alakzattal együtt forog, mivel a saját koordináta‑rendszeréhez van kötve.

**Átalakítható-e egy egyedi alakzat képpé a "lezáráshoz"?**

Igen. Exportálja a szükséges [slide](/slides/hu/cpp/convert-powerpoint-to-png/) területet vagy magát a [shape](/slides/hu/cpp/create-shape-thumbnails/) elemet raszteres formátumba; ez leegyszerűsíti a nehéz geometriákkal való további munkát.