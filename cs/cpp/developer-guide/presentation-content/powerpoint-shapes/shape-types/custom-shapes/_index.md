---
title: Přizpůsobení tvarů v prezentaci v C++
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
- editační body
- přidat bod
- odstranit bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v PowerPoint prezentacích pomocí Aspose.Slides pro C++: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek popisuje, jak přizpůsobit tvary v prezentacích v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s `GeometryPath` a `IGeometryPath` pro úpravu existujících tvarů, provádění základních operací úpravy cesty, přidávání nebo odstraňování bodů a aplikaci aktualizované geometrie zpět na tvar.

## **Změna tvaru pomocí editačních bodů**
Zvažte čtverec. V PowerPointu můžete pomocí **edit points**:

* posunout roh čtverce dovnitř nebo ven
* zadat zakřivení pro roh nebo bod
* přidat nové body do čtverce
* manipulovat body na čtverci atd.

V podstatě můžete provádět popsané úkoly na jakémkoli tvaru. Pomocí editačních bodů můžete změnit tvar nebo vytvořit nový tvar ze stávajícího.

## **Tipy pro úpravu tvarů**

![overview_image](custom_shape_0.png)

Předtím, než začnete upravovat tvary v PowerPointu pomocí editačních bodů, můžete zvážit následující body o tvarech:

* Tvar (nebo jeho cesta) může být buď uzavřený, nebo otevřený.
* Když je tvar uzavřený, postrádá počáteční nebo koncový bod. Když je tvar otevřený, má začátek a konec.
* Všechny tvary se skládají alespoň ze 2 kotevních bodů spojených čarami
* Čára může být buď přímá, nebo zakřivená. Kotevní body určují charakter čáry.
* Kotevní body se vyskytují jako rohové body, přímé body nebo hladké body:
  * Rohový bod je bod, kde se dvě přímé čáry setkávají pod úhlem.
  * Hladký bod je bod, kde dvě rukojeti leží na přímé linii a úseky čáry se spojují plynulou křivkou. V tomto případě jsou všechny rukojeti od kotevního bodu vzdáleny stejnou vzdáleností.
  * Přímý bod je bod, kde dvě rukojeti leží na přímé linii a úseky čáry se spojují plynulou křivkou. V tomto případě rukojeti nemusí být od kotevního bodu vzdáleny stejně.
* Přesunutím nebo úpravou kotevních bodů (což mění úhel čar) můžete změnit vzhled tvaru.

Pro úpravu tvarů v PowerPointu pomocí editačních bodů **Aspose.Slides** poskytuje třídu [**GeometryPath**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_path) a rozhraní [**IGeometryPath**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_geometry_path).

* Instance třídy [GeometryPath](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_path) představuje geometrickou cestu objektu [IGeometryShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_geometry_shape).
* Pro získání `GeometryPath` z instance `IGeometryShape` můžete použít metodu [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1).
* Pro nastavení `GeometryPath` pro tvar můžete použít tyto metody: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) pro *plné tvary* a [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) pro *složené tvary*.
* Pro přidání segmentů můžete použít metody pod [IGeometryPath](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_geometry_path).
* Pomocí metod [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) a [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) můžete nastavit vzhled geometrické cesty.
* Pomocí metody [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) můžete získat geometrickou cestu `GeometryShape` jako pole segmentů cesty.
* Pro přístup k dalším možnostem přizpůsobení geometrie tvaru můžete převést [GeometryPath](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_path) na [GraphicsPath](https://reference.aspose.com/slides/cs/cpp/class/system.drawing.drawing2_d.graphics_path)
* Použijte metody [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) a [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (ze třídy [ShapeUtil](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.util.shape_util)) pro převod [GeometryPath](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_path) na [GraphicsPath](https://reference.aspose.com/slides/cs/cpp/class/system.drawing.drawing2_d.graphics_path) a zpět.

## **Jednoduché operace úpravy**

Tento C++ kód vám ukazuje jak

**Přidat čáru** na konec cesty

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Přidat čáru** na určenou pozici v cestě:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Přidat kubickou Bézierovu křivku** na konec cesty:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Přidat kubickou Bézierovu křivku** na určenou pozici v cestě:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Přidat kvadratickou Bézierovu křivku** na konec cesty:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Přidat kvadratickou Bézierovu křivku** na určenou pozici v cestě:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Připojit daný oblouk** k cestě:

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Uzavřít aktuální figurku** cesty:

``` cpp
void CloseFigure();
```
**Nastavit pozici pro další bod**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Odstranit segment cesty** na zadaném indexu:

``` cpp
void RemoveAt(int32_t index);
```

## **Přidání vlastních bodů do tvaru**
1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_shape) a nastavte typ [ShapeType.Rectangle](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).
2. Získejte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_path) ze tvaru.
3. Přidejte nový bod mezi dvěma horními body v cestě.
4. Přidejte nový bod mezi dvěma dolními body v cestě.
5. Aplikujte cestu na tvar.

Tento C++ kód vám ukazuje, jak přidat vlastní body do tvaru:

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

## **Odstranění bodů z tvaru**

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_shape) a nastavte typ [ShapeType.Heart](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).
2. Získejte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_path) ze tvaru.
3. Odstraňte segment cesty.
4. Aplikujte cestu na tvar.

Tento C++ kód vám ukazuje, jak odstranit body z tvaru:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Vytvoření vlastního tvaru**

1. Vypočítejte body pro tvar.
2. Vytvořte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_path).
3. Naplněte cestu body.
4. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_shape).
5. Aplikujte cestu na tvar.

Tento C++ kód vám ukazuje, jak vytvořit vlastní tvar:

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


## **Vytvoření složeného vlastního tvaru**

  1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_shape).
  2. Vytvořte první instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_path).
  3. Vytvořte druhou instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_path).
  4. Aplikujte cesty na tvar.

Tento C++ kód vám ukazuje, jak vytvořit složený vlastní tvar:

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

## **Vytvoření vlastního tvaru s zakřivenými rohy**

Tento C++ kód vám ukazuje, jak vytvořit vlastní tvar se zakřivenými rohy (dovnitř);

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

## **Zjistit, zda je geometrie tvaru uzavřená**

Uzavřený tvar je definován jako takový, kde všechny jeho strany jsou propojené, tvorí jednotnou hranici bez mezer. Takový tvar může být jednoduchý geometrický tvar nebo složitý vlastní obrys. Následující ukázkový kód ukazuje, jak zkontrolovat, zda je geometrie tvaru uzavřená:

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

## **Převod GeometryPath na GraphicsPath** 

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_shape).
2. Vytvořte instanci třídy [GraphicsPath](https://reference.aspose.com/slides/cs/cpp/class/system.drawing.drawing2_d.graphics_path) ze jmenného prostoru [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cs/cpp/namespace/system.drawing.drawing2_d).
3. Převěďte instanci [GraphicsPath](https://reference.aspose.com/slides/cs/cpp/class/system.drawing.drawing2_d.graphics_path) na instanci [GeometryPath](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.geometry_path) pomocí [ShapeUtil](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.util.shape_util).
4. Aplikujte cesty na tvar.

Tento C++ kód — implementace výše uvedených kroků — ukazuje proces převodu **GeometryPath** na **GraphicsPath**:

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

## **Často kladené otázky**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstává u tvaru; mění se jen obrys. Výplň a obrys jsou automaticky aplikovány na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte vlastnost [rotation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/set_rotation/) tvaru; geometrie se otáčí spolu s tvarem, protože je svázána s vlastním souřadnicovým systémem tvaru.

**Mohu převést vlastní tvar na obrázek, abych „uzamkl“ výsledek?**

Ano. Exportujte požadovanou oblast [slide](/slides/cs/cpp/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/cpp/create-shape-thumbnails/) do rastrového formátu; to usnadní další práci s rozsáhlými geometriemi.