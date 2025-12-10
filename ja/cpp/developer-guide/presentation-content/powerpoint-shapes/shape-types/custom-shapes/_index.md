---
title: C++ でプレゼンテーションの図形をカスタマイズ
linktitle: カスタム シェイプ
type: docs
weight: 20
url: /ja/cpp/custom-shape/
keywords:
- カスタム シェイプ
- シェイプ を 追加
- シェイプ を 作成
- シェイプ を 変更
- シェイプ ジオメトリ
- ジオメトリ パス
- パス ポイント
- 編集 ポイント
- ポイント を 追加
- ポイント を 削除
- 編集 操作
- カーブ した 角
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint プレゼンテーション内の図形を作成およびカスタマイズします：ジオメトリ パス、カーブした角、複合図形。"
---

## **編集ポイントを使用して図形を変更する**
正方形を考えてみましょう。PowerPoint では、**編集ポイント**を使用して  

* 正方形の角を内側または外側に移動できる  
* 角やポイントの曲率を指定できる  
* 正方形に新しいポイントを追加できる  
* 正方形上のポイントを操作できる、など  

基本的に、任意の図形に対して上記の操作を行うことができます。編集ポイントを使用すると、既存の図形から形状を変更したり、新しい図形を作成したりできます。

## **図形編集のヒント**

![overview_image](custom_shape_0.png)

編集ポイントで PowerPoint の図形を編集し始める前に、図形に関して次の点を考慮してください。

* 図形（またはそのパス）は閉じている場合と開いている場合があります。  
* 図形が閉じている場合、開始点や終了点がありません。開いている場合は、始点と終点があります。  
* すべての図形は少なくとも 2 つのアンカーポイントで構成され、線で結ばれています。  
* 線は直線または曲線のいずれかです。アンカーポイントが線の性質を決定します。  
* アンカーポイントはコーナーポイント、ストレートポイント、スムーズポイントのいずれかです。  
  * コーナーポイントは、2 本の直線が角度を持って結合する点です。  
  * スムーズポイントは、2 本のハンドルが直線上にあり、線分が滑らかな曲線で結合する点です。この場合、すべてのハンドルはアンカーポイントから同じ距離だけ離れています。  
  * ストレートポイントは、2 本のハンドルが直線上にあり、線分が滑らかな曲線で結合する点です。この場合、ハンドルはアンカーポイントから等距離である必要はありません。  
* アンカーポイントを移動または編集すると（線の角度が変わります）、図形の外観を変更できます。

PowerPoint の図形を編集ポイントで操作するには、**Aspose.Slides** が [**GeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) クラスと [**IGeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path) インターフェイスを提供します。

* [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) のインスタンスは、[IGeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape) オブジェクトのジオメトリパスを表します。  
* `IGeometryShape` インスタンスから `GeometryPath` を取得するには、[IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1) メソッドを使用します。  
* 図形に `GeometryPath` を設定するには、次のメソッドを使用します。*単独の図形* には [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986)、*複合図形* には [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750)。  
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path) 配下のメソッドを使用します。  
* [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) および [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) メソッドでジオメトリパスの外観を設定できます。  
* [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) メソッドを使用すると、`GeometryShape` のジオメトリパスをパスセグメントの配列として取得できます。  
* 追加の図形ジオメトリカスタマイズオプションにアクセスするには、[GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) を [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) に変換します。  
* [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util) クラスの [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) および [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) メソッドを使用して、[GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) と [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) の相互変換が可能です。

## **簡単な編集操作**

この C++ コードは次の操作方法を示します。

**パスの末尾に直線を追加する**  
``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```


**パスの指定位置に直線を追加する**  
``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```


**パスの末尾に 3 次ベジェ曲線を追加する**  
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```


**パスの指定位置に 3 次ベジェ曲線を追加する**  
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```


**パスの末尾に二次ベジェ曲線を追加する**  
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```


**パスの指定位置に二次ベジェ曲線を追加する**  
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```


**パスに円弧を付加する**  
``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```


**パスの現在の図形を閉じる**  
``` cpp
void CloseFigure();
```


**次のポイントの位置を設定する**  
``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```


**指定インデックスのパスセグメントを削除する**  
``` cpp
void RemoveAt(int32_t index);
```


## **図形にカスタムポイントを追加する**
1. [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) クラスのインスタンスを作成し、[ShapeType.Rectangle](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5) タイプを設定します。  
2. 図形から [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) クラスのインスタンスを取得します。  
3. パス上の上部 2 点の間に新しいポイントを追加します。  
4. パス上の下部 2 点の間に新しいポイントを追加します。  
5. パスを図形に適用します。  

この C++ コードはカスタムポイントを図形に追加する方法を示します:  
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

## **図形からポイントを削除する**

1. [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) クラスのインスタンスを作成し、[ShapeType.Heart](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5) タイプを設定します。  
2. 図形から [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) クラスのインスタンスを取得します。  
3. パスのセグメントを削除します。  
4. パスを図形に適用します。  

この C++ コードは図形からポイントを削除する方法を示します:  
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```


![example2_image](custom_shape_2.png)

## **カスタム形状を作成する**

1. 図形のポイントを計算します。  
2. [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) クラスのインスタンスを作成します。  
3. パスにポイントを設定します。  
4. [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) クラスのインスタンスを作成します。  
5. パスを図形に適用します。  

この C++ コードはカスタム形状を作成する方法を示します:  
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

## **複合カスタム形状を作成する**

1. [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) クラスのインスタンスを作成します。  
2. 最初の [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) インスタンスを作成します。  
3. 2 番目の [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) インスタンスを作成します。  
4. パスを図形に適用します。  

この C++ コードは複合カスタム形状を作成する方法を示します:  
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

## **角が丸いカスタム形状を作成する**

この C++ コードは、内側にカーブした角を持つカスタム形状を作成する方法を示します:  
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


## **図形ジオメトリが閉じているか確認する方法**

閉じた図形とは、すべての辺がつながり、隙間なく単一の境界を形成しているものを指します。単純な幾何形状でも、複雑なカスタム輪郭でも同様です。次のコード例は、図形ジオメトリが閉じているかどうかを確認する方法を示します:  
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


## **GeometryPath を GraphicsPath に変換する**

1. [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) クラスのインスタンスを作成します。  
2. [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cpp/namespace/system.drawing.drawing2_d) 名前空間の [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) クラスのインスタンスを作成します。  
3. [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util) を使用して、[GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) インスタンスを [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) インスタンスに変換します。  
4. パスを図形に適用します。  

上記手順を実装したこの C++ コードは、**GeometryPath** から **GraphicsPath** への変換プロセスを示しています:  
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

**ジオメトリを置き換えた後、塗りつぶしと輪郭はどうなりますか？**

スタイルは図形に残り、輪郭だけが変更されます。塗りつぶしと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタム形状を正しく回転させるにはどうすればよいですか？**

図形の [rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) プロパティを使用します。ジオメトリは図形にバインドされているため、図形と一緒に回転します。

**カスタム形状を画像に変換して「ロック」できますか？**

はい。必要な [slide](/slides/ja/cpp/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/cpp/create-shape-thumbnails/) 自体をラスタ形式でエクスポートできます。これにより、重いジオメトリの後続作業が簡素化されます。