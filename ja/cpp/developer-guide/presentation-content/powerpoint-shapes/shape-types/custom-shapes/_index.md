---
title: カスタムシェイプ
type: docs
weight: 20
url: /cpp/custom-shape/
keywords: "PowerPoint シェイプ, カスタム シェイプ, PowerPoint プレゼンテーション, C++, Aspose.Slides for C++"
description: "C++ で PowerPoint プレゼンテーションにカスタムシェイプを追加"
---

# エディットポイントを使用してシェイプを変更する
正方形を考えてみましょう。PowerPoint では、**エディットポイント**を使用して、 

* 正方形の角を内側または外側に移動する
* 角またはポイントの曲率を指定する
* 正方形に新しいポイントを追加する
* 正方形のポイントを操作するなど

基本的に、説明したタスクを任意のシェイプに対して実行できます。エディットポイントを使用することで、シェイプを変更したり、既存のシェイプから新しいシェイプを作成したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

エディットポイントを介して PowerPoint シェイプの編集を開始する前に、シェイプに関する次のポイントを考慮すると良いでしょう：

* シェイプ（またはそのパス）は、閉じた状態または開いた状態のいずれかです。
* シェイプが閉じている場合、開始点または終了点がありません。シェイプが開いている場合、開始点と終了点があります。
* すべてのシェイプは、互いに線でリンクされた少なくとも 2 つのアンカーポイントで構成されています。
* 線は直線または曲線です。アンカーポイントは線の性質を決定します。
* アンカーポイントは角ポイント、直線ポイント、またはスムーズポイントとして存在します：
  * 角ポイントは、2 本の直線が角度で接続されるポイントです。
  * スムーズポイントは、2 本のハンドルが直線上に存在し、線のセグメントがスムーズな曲線で接続されるポイントです。この場合、すべてのハンドルはアンカーポイントから等距離に配置されます。
  * 直線ポイントは、2 本のハンドルが直線上に存在し、その線のセグメントがスムーズな曲線で接続されるポイントです。この場合、ハンドルはアンカーポイントから等距離である必要はありません。
* アンカーポイントを移動または編集することで（これにより線の角度が変わります）、シェイプの見た目を変更できます。

エディットポイントを通じて PowerPoint シェイプを編集するために、**Aspose.Slides** は [**GeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) クラスと [**IGeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path) インターフェイスを提供しています。

* [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) インスタンスは、[IGeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape) オブジェクトのジオメトリパスを表します。
* `IGeometryShape` インスタンスから `GeometryPath` を取得するには、[IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1) メソッドを使用できます。
* シェイプの `GeometryPath` を設定するには、*ソリッドシェイプ* 用の [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) メソッドと、*コンポジットシェイプ* 用の [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) メソッドを使用できます。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path) の下のメソッドを使用できます。
* [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) と [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) メソッドを使用して、ジオメトリパスの外観を設定できます。
* [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) メソッドを使用して、`GeometryShape` のジオメトリパスをパスセグメントの配列として取得できます。
* 追加のシェイプジオメトリカスタマイズオプションにアクセスするには、[GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) を [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) に変換できます。
* [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) および [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) メソッド（[ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util) クラスから）を使用して [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) を [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) に相互に変換できます。

## **シンプルな編集操作**

この C++ コードは、次の操作を行う方法を示しています。

**パスの末尾に線を追加する**

```cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**パスの指定された位置に線を追加する：**

```cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**パスの末尾にキュービックベジエ曲線を追加する：**

```cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**指定された位置にキュービックベジエ曲線を追加する：**

```cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**パスの末尾に二次ベジエ曲線を追加する：**

```cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**指定された位置に二次ベジエ曲線を追加する：**

```cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**指定された弧をパスに追加する：**

```cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**現在の図形を閉じる：**

```cpp
void CloseFigure();
```
**次のポイントの位置を設定する：**

```cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**指定されたインデックスのパスセグメントを削除する：**

```cpp
void RemoveAt(int32_t index);
```
## **シェイプにカスタムポイントを追加する**
1. [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) クラスのインスタンスを作成し、[ShapeType.Rectangle](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5) タイプを設定します。
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) クラスのインスタンスを取得します。
3. パスの2つの上部ポイントの間に新しいポイントを追加します。
4. パスの2つの下部ポイントの間に新しいポイントを追加します。
5. パスをシェイプに適用します。

この C++ コードは、シェイプにカスタムポイントを追加する方法を示しています：

```cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

##  シェイプからポイントを削除する

1. [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) クラスのインスタンスを作成し、[ShapeType.Heart](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5) タイプを設定します。 
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) クラスのインスタンスを取得します。
3. パスのセグメントを削除します。
4. パスをシェイプに適用します。

この C++ コードは、シェイプからポイントを削除する方法を示しています：

```cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

##  **カスタムシェイプを作成する**

1. シェイプのポイントを計算します。
2. [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) クラスのインスタンスを作成します。 
3. ポイントでパスを埋めます。
4. [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) クラスのインスタンスを作成します。 
5. パスをシェイプに適用します。

この C++ コードは、カスタムシェイプを作成する方法を示しています：

```cpp
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


## **コンポジットカスタムシェイプを作成する**

1. [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) クラスのインスタンスを作成します。
2. [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) クラスの最初のインスタンスを作成します。
3. [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) クラスの2番目のインスタンスを作成します。
4. パスをシェイプに適用します。

この C++ コードは、コンポジットカスタムシェイプを作成する方法を示しています：

```cpp
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

## **角が丸いカスタムシェイプを作成する**

この C++ コードは、角が内向きのカスタムシェイプを作成する方法を示します：

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

## **GeometryPath を GraphicsPath に変換する** 

1. [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) クラスのインスタンスを作成します。
2. [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cpp/namespace/system.drawing.drawing2_d) 名前空間の [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) クラスのインスタンスを作成します。
3. [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) インスタンスを [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) インスタンスに変換します。 [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util) を使用します。
4. パスをシェイプに適用します。

この C++ コードは、上記の手順の実装であり、**GeometryPath** から **GraphicsPath** への変換プロセスを示しています：

```cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"テキストを形に", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```
![example5_image](custom_shape_5.png)