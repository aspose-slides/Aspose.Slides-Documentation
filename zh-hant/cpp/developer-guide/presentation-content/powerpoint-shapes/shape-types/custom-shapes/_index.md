---
title: 在 C++ 中自訂簡報形狀
linktitle: 自訂形狀
type: docs
weight: 20
url: /zh-hant/cpp/custom-shape/
keywords:
- 自訂形狀
- 新增形狀
- 建立形狀
- 變更形狀
- 形狀幾何
- 幾何路徑
- 路徑點
- 編輯點
- 新增點
- 移除點
- 編輯操作
- 曲線角
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 簡報中建立與自訂形狀：幾何路徑、曲線角、複合形狀。"
---
## **概述**

本文說明如何透過編輯點和幾何路徑來編輯形狀幾何，以自訂 Aspose.Slides 中的簡報形狀。內容示範如何使用 `GeometryPath` 和 `IGeometryPath` 來修改既有形狀、執行基本路徑編輯操作、加入或移除點，並將更新後的幾何套用回形狀。

## **使用編輯點變更形狀**
以正方形為例。在 PowerPoint 中，使用 **編輯點**，您可以

* 將正方形的角向內或向外移動
* 為角或點指定曲率
* 為正方形加入新點
* 操作正方形上的點等

基本上，這些操作可套用於任何形狀。透過編輯點，您可以變更形狀或從既有形狀建立新形狀。

## **形狀編輯技巧**

![overview_image](custom_shape_0.png)

在開始透過編輯點編輯 PowerPoint 形狀之前，您可能需要了解以下關於形狀的要點：

* 形狀（或其路徑）可以是封閉的，也可以是開放的。
* 封閉的形狀沒有起點或終點。開放的形狀則有起始與結束點。
* 所有形狀至少由 2 個錨點組成，這些錨點以線段相連。
* 線段可以是直線或曲線。錨點決定線段的性質。
* 錨點可分為角點、直點或平滑點：
  * 角點是兩條直線在角度處相交的點。
  * 平滑點是兩個手柄位於同一直線上，且線段以平滑曲線相接的點。此情況下，兩個手柄與錨點之間的距離相等。
  * 直點是兩個手柄位於同一直線上，線段仍以平滑曲線相接的點。此情況下，手柄與錨點的距離不必相等。
* 透過移動或編輯錨點（即改變線條角度），即可改變形狀的外觀。

為了透過編輯點編輯 PowerPoint 形狀，**Aspose.Slides** 提供了 [**GeometryPath**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_path) 類別和 [**IGeometryPath**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_geometry_path) 介面。

* 一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_path) 例項代表 [IGeometryShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_geometry_shape) 物件的幾何路徑。
* 若要從 `IGeometryShape` 例項取得 `GeometryPath`，可使用 [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1) 方法。
* 若要為形狀設定 `GeometryPath`，可使用以下方法：針對*實心形狀*使用 [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986)；針對*複合形狀*使用 [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750)。
* 若要新增線段，可使用 [IGeometryPath](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_geometry_path) 下的相關方法。
* 使用 [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) 與 [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) 方法，可設定幾何路徑的外觀。
* 透過 [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) 方法，可將 `GeometryShape` 的幾何路徑以路徑段陣列形式取得。
* 若需其他形狀幾何自訂選項，可將 [GeometryPath](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_path) 轉換為 [GraphicsPath](https://reference.aspose.com/slides/zh-hant/cpp/class/system.drawing.drawing2_d.graphics_path)。
* 使用 [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) 與 [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) 方法（來自 [ShapeUtil](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.util.shape_util) 類別）即可在 [GeometryPath](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_path) 與 [GraphicsPath](https://reference.aspose.com/slides/zh-hant/cpp/class/system.drawing.drawing2_d.graphics_path) 之間互相轉換。

## **簡易編輯操作**

以下 C++ 程式碼示範如何

**在路徑末端加入直線**

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**在路徑的指定位置加入直線：**

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**在路徑末端加入三次貝茲曲線：**

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**在路徑的指定位置加入三次貝茲曲線：**

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**在路徑末端加入二次貝茲曲線：**

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**在路徑的指定位置加入二次貝茲曲線：**

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**將給定弧線附加至路徑：**

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**關閉路徑目前的圖形：**

``` cpp
void CloseFigure();
```
**設定下一個點的位置：**

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**移除指定索引的路徑段：**

``` cpp
void RemoveAt(int32_t index);
```
## **為形狀新增自訂點**
1. 建立一個 [GeometryShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_shape) 例項，並將 [ShapeType.Rectangle](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5) 設為類型。
2. 從該形狀取得一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_path) 例項。
3. 在路徑的兩個上方點之間加入新點。
4. 在路徑的兩個下方點之間加入新點。
5. 將路徑套用至形狀。

以下 C++ 程式碼示範如何為形狀加入自訂點：

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

## **從形狀移除點**

1. 建立一個 [GeometryShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_shape) 例項，並將 [ShapeType.Heart](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5) 設為類型。
2. 從該形狀取得一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_path) 例項。
3. 移除該路徑的段落。
4. 將路徑套用至形狀。

以下 C++ 程式碼示範如何從形狀移除點：

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **建立自訂形狀**

1. 計算形狀的各個點座標。
2. 建立一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_path) 例項。
3. 使用這些點填充路徑。
4. 建立一個 [GeometryShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_shape) 例項。
5. 將路徑套用至形狀。

以下 C++ 程式碼示範如何建立自訂形狀：

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

## **建立複合自訂形狀**

1. 建立一個 [GeometryShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_shape) 例項。
2. 建立第一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_path) 例項。
3. 建立第二個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_path) 例項。
4. 將這兩條路徑套用至形狀。

以下 C++ 程式碼示範如何建立複合自訂形狀：

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

## **建立具有曲線角的自訂形狀**

以下 C++ 程式碼示範如何建立具有內縮曲線角的自訂形狀：

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

## **判斷形狀幾何是否為封閉**

封閉形狀是指其所有邊皆相連，形成單一無缺口的邊界。此類形狀可以是簡單的幾何圖形，也可以是複雜的自訂輪廓。以下程式碼示範如何檢查形狀幾何是否為封閉：

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

## **將 GeometryPath 轉換為 GraphicsPath**

1. 建立一個 [GeometryShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_shape) 例項。
2. 建立一個屬於 [System.Drawing.Drawing2D](https://reference.aspose.com/slides/zh-hant/cpp/namespace/system.drawing.drawing2_d) 命名空間的 [GraphicsPath](https://reference.aspose.com/slides/zh-hant/cpp/class/system.drawing.drawing2_d.graphics_path) 例項。
3. 使用 [ShapeUtil](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.util.shape_util) 將 [GraphicsPath](https://reference.aspose.com/slides/zh-hant/cpp/class/system.drawing.drawing2_d.graphics_path) 例項轉換回 [GeometryPath](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.geometry_path)。
4. 將路徑套用至形狀。

以下 C++ 程式碼—依照上述步驟實作—展示 **GeometryPath** 轉換為 **GraphicsPath** 的過程：

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

## **常見問題**

**取代幾何後，填充和輪廓會發生什麼變化？**

樣式仍屬於形狀本身，只有輪廓會改變。填充和輪廓會自動套用至新的幾何。

**如何正確旋轉自訂形狀以及其幾何？**

使用形狀的 [rotation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/set_rotation/) 屬性；因為幾何綁定於形狀的座標系統，旋轉形狀時幾何也會同步旋轉。

**我可以將自訂形狀轉換為圖像以「鎖定」結果嗎？**

可以。將所需的 [slide](/slides/zh-hant/cpp/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/cpp/create-shape-thumbnails/) 本身匯出為點陣圖格式，這樣可簡化對複雜幾何的後續處理。