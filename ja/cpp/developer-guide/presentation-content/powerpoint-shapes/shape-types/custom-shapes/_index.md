---
title: C++でプレゼンテーションのシェイプをカスタマイズする
linktitle: カスタム シェイプ
type: docs
weight: 20
url: /ja/cpp/custom-shape/
keywords:
- カスタム シェイプ
- シェイプを追加
- シェイプを作成
- シェイプを変更
- シェイプ ジオメトリ
- ジオメトリ パス
- パス ポイント
- 編集ポイント
- ポイントを追加
- ポイントを削除
- 編集操作
- 曲線コーナー
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションのシェイプを作成およびカスタマイズします：ジオメトリ パス、曲線コーナー、合成シェイプ。"
---
## **概要**

このドキュメントでは、編集ポイントとジオメトリ パスを使用してシェイプ ジオメトリを編集し、Aspose.Slides でプレゼンテーション シェイプをカスタマイズする方法を説明します。既存のシェイプを変更したり、基本的なパス編集操作を実行したり、ポイントを追加・削除したり、更新したジオメトリをシェイプに適用する方法として、[GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) と [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) の使用例を示します。

また、カスタム シェイプや合成シェイプの作成、角が丸いシェイプの構築、シェイプ ジオメトリが閉じているかどうかの判定方法も紹介します。

## **Edit Points を使用したシェイプの変更**

PowerPoint では、**Edit Points** を使用して四角形を変更できます。

* 角を内側または外側に移動する。
* ポイントの曲率を調整する。
* 新しいポイントを追加する。

編集ポイントを使用すると、シェイプの輪郭を変更したり、既存のシェイプを新しいシェイプのベースとして使用したりできます。

## **シェイプ編集のヒント**

![概要画像](custom_shape_0.png)

PowerPoint シェイプを編集する際に覚えておくべき概念は次のとおりです。

* シェイプ（またはそのパス）は、閉じている場合と開いている場合があります。
* シェイプのパスは、セグメントで接続されたアンカーポイントで構成されます。
* セグメントは直線または曲線にできます。アンカーポイントと制御ハンドルが形状を決定します。
* アンカーポイントは、コーナーポイント、直線ポイント、スムーズポイントとして存在します。
  * コーナーポイントでは、隣接するセグメントが角度を持って接続できます。
  * スムーズポイントでは、2 つの制御ハンドルが揃っており、アンカーポイントから同じ距離にあります。
  * 直線ポイントでは、2 つの制御ハンドルが揃っていますが、アンカーポイントからの距離は異なる場合があります。
* アンカーポイントを移動したりハンドルを調整したりすると、シェイプの輪郭が変わります。

Edit Points を使用して PowerPoint シェイプを編集するために、**Aspose.Slides** は [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) クラスと [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) インターフェイスを提供します。

* [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) インスタンスは、[IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) オブジェクトのジオメトリ パスを表します。
* [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) を取得するには、[IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) メソッドを使用します。
* シェイプに [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) を設定するには、単一パスのシェイプの場合は [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) を、複数パスのシェイプの場合は [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) を使用します。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) 以下のメソッドを使用します。
* [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) と [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) メソッドを使用して、ジオメトリ パスの外観を設定できます。
* [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) メソッドを使用すると、[GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) のジオメトリ パスをパス セグメントの配列として取得できます。

## **簡単な編集操作**

ジオメトリ パスを編集するには、以下のメソッドを使用します。インデックスを受け取るオーバーロードは、パスのセグメント配列内のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入する。 | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| 2 つの制御点と終点を持つ 3 次ベジエ曲線を追加または挿入する。 | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| 1 つの制御点と終点を持つ二次ベジエ曲線を追加または挿入する。 | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| 指定したサイズと角度（度）で楕円弧を追加する。 | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| 現在の図形を閉じ、終点を開始点に接続する。 | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| 図形の開始点を設定する。 | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| ゼロベースインデックスでセグメントを削除する。 | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **シェイプにカスタムポイントを追加する**

この例では、[GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) を使用して長方形シェイプに 2 つのポイントを挿入し、[IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) で編集したパスを適用します。座標はシェイプのローカル座標で、両方の新しいポイントはシェイプの中心にあり、左端から 100 ポイント、上端から 50 ポイントの位置です。セグメントインデックス 1 と 4 はそれぞれ上辺と下辺に配置され、これらの辺を内側に引っ張ります。

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

![例1画像](custom_shape_1.png)

## **シェイプからポイントを削除する**

この例では、[GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) を使用してゼロベースインデックス 2 のセグメントを削除し、ハート形の輪郭を変更します。[IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) で変更したパスを適用すると、シェイプの輪郭が更新されます。

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
![例2画像](custom_shape_2.png)

## **カスタムシェイプの作成**

この例では、[GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) を使用して5 本のポイントからなる星形を構築します。外側半径 100 ポイント、内側半径 50 ポイントを交互に設定し、72 度の間隔で 5 つの先端を均等に配置します。パスは [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) で閉じられ、[IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) を使用して長方形シェイプに適用し、元の輪郭を置き換えます。

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
![例3画像](custom_shape_3.png)

## **合成カスタムシェイプの作成**

この例では、シェイプの上部 1/3 と下部 1/3 用に 2 つの閉じた [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) オブジェクトを定義します。[IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) を使用して両方のパスを適用すると、中央 1/3 に隙間がある単一の合成シェイプが作成されます。

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
![例4画像](custom_shape_4.png)

## **曲線コーナー付きカスタムシェイプの作成**

この例では、直線セグメントと [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) を組み合わせて、内側に曲がったコーナーを持つシェイプを作成します。各コーナーサイズは弧の幅と高さ（ポイント）を設定し、-90 度のスイープで反時計回りの 1/4 楕円を描きます。完成したパスは [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) で適用され、プレゼンテーションは PPTX 形式で保存されます。

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

## **シェイプ ジオメトリが閉じているか確認する方法**

以下のヘルパーは、すべての非空ジオメトリ パスが閉じるセグメントで終わるかどうかをチェックします。[IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) を読み取り、最終セグメントの [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) が [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/) と等しいかどうかを比較します。パスが空でない場合に false を返します。このロジックは各パスの最終コマンドのみをチェックし、パス内のすべてのサブフィギュアは検査しません。例では矩形に対して `True` が出力されます。

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

## **シェイプ要素の抽出と検査**

[IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) を使用して、パスポイントとポイントタイプを含む要素として既存シェイプを検査できます。返された各 [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) を [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) にキャストし、[get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) と [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) が返す配列を読み取ります。この表現は輪郭解析やカスタム描画ツールへのジオメトリ渡しに便利です。

例ではプレゼンテーションを開き、最初のスライド上の最初のジオメトリ シェイプを取得してそのパスセグメントを出力します。直線と曲線セグメントの両方を含むシェイプがあるプレゼンテーションで実行すると、両方の出力が確認できます。グループ内は検索しません。

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
        auto pointType = types[i] & 0x07; // セグメントタイプを保持し、フラグは除外します。
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
                i += 2; // 制御点と終点の両方を消費します。
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

配列はインデックスで対応しています：`points[i]` はポイント、`types[i]` はその役割を示します。タイプ `0` は図形の開始、タイプ `1` は前のポイントから現在のポイントへの直線を表します。3 次ベジエ セグメントは前の終点から始まり、連続する 3 つのタイプ `3` エントリ（2 つの制御点と新しい終点）で構成されます。ループはこれら 3 エントリをまとめて処理し、終点が閉じているかを確認します。

ポイントタイプにはフラグも含まれます。`0x07` マスクでセグメントタイプを特定し、`0x80` ビットで閉じたサブパスかどうかを判定します。例として `129`（`0x81`）は閉じたサブパスの直線終点、`131`（`0x83`）は閉じたベジエ終点を意味します。生の値を単に `1` や `3` と比較するとこれらのケースを見逃します。ダッシュ（`0x10`）やマーカー（`0x20`）などの他のフラグは基本セグメントタイプを変更しません。

**座標と変換。** ポイントはポイント単位（1/72 インチ）で測定され、X は右方向に、Y は下方向に増加します。グループ化されていないシェイプの場合、抽出された座標はすでに [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) と [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) が返す位置を含み、現在の幅と高さを反映しています。たとえば、左上が `(100, 200)`、サイズが `120 × 80` の回転していない矩形は輪郭境界が `(100, 200)`–`(220, 280)` となります。シェイプの位置を再度加算しないでください。X と Y を減算すれば、回転していないフレーム内の相対座標が得られます。

抽出されたポイントは [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) や水平・垂直フリップで設定された回転を適用していません。表示された輪郭を再現するには、シェイプの中心を基準にこれらの変換を適用してください。グループ化されたシェイプの場合、グループ座標マッピングと変換も考慮する必要があります。抽出されたポイントが最終的なスライド座標であると仮定したり、既に子フレームに反映されている変換を二重に適用したりしないでください。

**検査と編集の違い。** 抽出された配列は輪郭を記述しますが、変更しても元のシェイプは更新されません。ポイント/タイプ配列が必要な分析や描画コードでこの方法を選択してください。シェイプのローカル座標系でジオメトリ コマンドが必要な場合やジオメトリを編集したい場合は、[GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) を使用し、編集したパスは [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) または [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) で適用してください。

## **GeometryPath を GraphicsPath に変換する方法**

現在の Aspose.Slides for C++ のパブリック API では、ジオメトリ パスとグラフィックス パス間の変換は公開されていません。輪郭を検査するには上記のシェイプ要素を使用し、シェイプを編集するにはジオメトリ パスを使用して更新されたパスをシェイプに適用してください。

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしと輪郭はどうなりますか？**

スタイルはシェイプに残り、輪郭だけが変更されます。塗りつぶしと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタムシェイプを正しく回転させる方法は？**

シェイプの [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) メソッドを使用してください。ジオメトリはシェイプの座標系にバインドされているため、シェイプとともに回転します。

**カスタムシェイプを画像に変換して「ロック」することはできますか？**

はい。必要な [slide](/slides/ja/cpp/convert-powerpoint-to-png/) の領域または [shape](/slides/ja/cpp/shape-thumbnails/) 自体をラスタ形式でエクスポートすれば、複雑なジオメトリの後続作業が簡素化されます。