---
title: C++ でプレゼンテーション シェイプをカスタマイズ
linktitle: カスタム シェイプ
type: docs
weight: 20
url: /ja/cpp/custom-shape/
keywords:
- カスタム シェイプ
- シェイプの追加
- シェイプの作成
- シェイプの変更
- シェイプ ジオメトリ
- ジオメトリ パス
- パス ポイント
- 編集ポイント
- ポイントの追加
- ポイントの削除
- 編集操作
- 曲線コーナー
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint プレゼンテーション内のシェイプを作成・カスタマイズします。ジオメトリ パス、曲線コーナー、合成シェイプが含まれます。"
---
## **概要**

この記事では、編集ポイントとジオメトリ パスを使用してシェイプのジオメトリを編集することで、Aspose.Slides のプレゼンテーション シェイプをカスタマイズする方法を説明します。[GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) と [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) を使用して既存のシェイプを変更し、基本的なパス編集操作を実行し、ポイントを追加または削除し、更新されたジオメトリをシェイプに適用する方法を示します。

また、カスタムおよび合成シェイプの作成、角が丸いシェイプの構築、シェイプ ジオメトリが閉じているかどうかの判定方法もデモします。

## **編集ポイントでシェイプを変更する**

PowerPoint では **Edit Points** を使用して正方形を変更できます。

* 角を内側または外側に移動する。
* ポイントの曲率を調整する。
* 新しいポイントを追加する。

編集ポイントを使用すると、シェイプの輪郭を変更したり、既存のシェイプを新しいシェイプのベースとして使用したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

PowerPoint シェイプを編集する際は、以下の概念を覚えておいてください。

* シェイプ（またはそのパス）は閉じている場合と開いている場合があります。
* シェイプのパスは、セグメントで接続されたアンカーポイントで構成されます。
* セグメントは直線または曲線にできます。アンカーポイントと制御ハンドルが形状を決定します。
* アンカーポイントはコーナーポイント、ストレートポイント、スムーズポイントのいずれかです。
  * コーナーポイントでは、隣接するセグメントが角度を持って接続します。
  * スムーズポイントでは、2 つの制御ハンドルが揃っており、アンカーポイントから同距離です。
  * ストレートポイントでは、2 つの制御ハンドルが揃っていますが、距離は異なる場合があります。
* アンカーポイントを移動したりハンドルを調整したりすると、シェイプの輪郭が変わります。

PowerPoint シェイプを編集ポイントで操作するために、**Aspose.Slides** は [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) クラスと [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) インターフェイスを提供します。

* [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) のインスタンスは、[IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) オブジェクトのジオメトリ パスを表します。
* [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) から [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) を取得するには、[IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) メソッドを使用します。
* シェイプに [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) を設定するには、単一パス用に [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) を、複数パス用に [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) を使用します。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) の下にあるメソッドを使用します。
* [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) および [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) メソッドを使用して、ジオメトリ パスの外観を設定できます。
* [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) メソッドを使用すると、[GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) のジオメトリ パスをパス セグメントの配列として取得できます。

## **簡単な編集操作**

以下のメソッドを使用してジオメトリ パスを編集します。インデックスを受け取るオーバーロードは、パスのセグメント配列のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入する。 | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| 2 つの制御ポイントと終点を持つ 3 次ベジエ曲線を追加または挿入する。 | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| 1 つの制御ポイントと終点を持つ 2 次ベジエ曲線を追加または挿入する。 | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| 指定されたサイズと角度（度単位）の楕円弧を追加する。 | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| 終点を開始点に接続して現在の図形を閉じる。 | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| 図形の開始点を設定する。 | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| ゼロベースインデックスでセグメントを削除する。 | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **シェイプにカスタムポイントを追加する**

この例では、[GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) を使用して矩形シェイプに 2 つのポイントを挿入し、[IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) で編集したパスを適用します。座標はシェイプに対してローカルです。新しいポイントは両方ともシェイプの中心にあり、左端から 100 ポイント、上端から 50 ポイントの位置です。セグメント インデックス 1 と 4 がそれぞれ上辺と下辺に配置され、これらの辺を内側に引っ張ります。

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

## **シェイプからポイントを削除する**

この例では、[GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) を使ってゼロベースインデックス 2 のセグメントを削除し、ハート形の輪郭を変更します。変更したパスを [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) で適用すると、シェイプの輪郭が更新されます。

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

## **カスタム シェイプを作成する**

この例では、[GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) を使用して 5 本のポイントからなる星形を構築します。外側半径 100 ポイント、内側半径 50 ポイントを交互に設定し、72 度のステップで 5 本の先端を均等に配置します。パスは [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) で閉じられ、[IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) を使用して矩形シェイプに適用し、元の輪郭を置き換えます。

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

## **合成カスタム シェイプを作成する**

この例では、シェイプの上部 1/3 と下部 1/3 用に 2 つの閉じた [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) オブジェクトを定義します。両方のパスを [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) で適用すると、中央の 1/3 に隙間がある単一の合成シェイプが作成されます。

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

## **曲線コーナー付きカスタム シェイプを作成する**

この例では、直線セグメントと [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) を組み合わせて、内側に曲がったコーナーを持つシェイプを作成します。各コーナーサイズはアークの幅と高さ（ポイント）を設定し、-90 度のスイープで反時計回りの 1/4 楕円を描きます。完成したパスは [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) で適用し、プレゼンテーションを PPTX 形式で保存します。

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

## **シェイプ ジオメトリが閉じているかどうかを確認する**

以下のヘルパーは、すべての非空ジオメトリ パスが閉じるセグメントで終わっているかどうかをチェックします。[IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) を読み取り、最終セグメントの [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) と [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/) を比較します。非空パスがない場合は false を返します。このロジックは各パスの最終コマンドだけを確認し、パス内のすべてのサブフィギュアは検査しません。例では矩形に対して `True` が出力されます。

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

## **ジオメトリ パス コマンドの調査**

[contour.pptx](contour.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置します。最初のスライドの最初のシェイプは、直線の上辺、3 次ベジエ曲線、そして直線の閉じた下辺を持ちます。[GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) を使用してパスを取得します。各パスについて、[get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) は描画順のセグメントを返します。[get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) が返すコマンドに基づき、[get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/) が返す値の解釈方法が決まります。

```cpp
#include <DOM/IGeometryPath.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IPathSegment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/PathCommandType.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"contour.pptx");

auto shape = ExplicitCast<IGeometryShape>(presentation->get_Slide(0)->get_Shape(0));
auto paths = shape->GetGeometryPaths();

for (auto i = 0; i < paths->get_Length(); ++i)
{
    auto segments = paths->idx_get(i)->get_PathData();
    for (auto j = 0; j < segments->get_Length(); ++j)
    {
        auto segment = segments->idx_get(j);
        auto command = segment->get_PathCommand();
        auto data = segment->get_SegmentData();
        String detail;
        switch (command)
        {
            case PathCommandType::MoveTo:
            case PathCommandType::LineTo:
                detail = String::Format(u"destination=({0}, {1})", data->idx_get(0), data->idx_get(1));
                break;
            case PathCommandType::CubicBezierTo:
                detail = String::Format(u"control1=({0}, {1}) control2=({2}, {3}) end=({4}, {5})", data);
                break;
            case PathCommandType::Close:
                detail = u"no coordinates";
                break;
            default:
            {
                auto values = MakeArray<String>(data->get_Length());
                for (auto k = 0; k < data->get_Length(); ++k)
                {
                    values->idx_set(k, String::Format(u"{0}", data->idx_get(k)));
                }
                detail = String::Format(u"raw=[{0}]", String::Join(u", ", values));
                break;
            }
        }
        Console::WriteLine(u"Path {0}, segment {1}: {2} {3}", i, j, Enum<PathCommandType>::GetName(command), detail);
    }
}
```

シェイプはスライド上の (200, 100) ポイントに配置されています。報告されたポイントはシェイプに対してローカルで、(0, 0) が左上隅、X が右方向に増加、Y が下方向に増加します。閉じるセグメントは追加座標なしで開始点に戻ります。

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **シェイプ要素の抽出と調査**

[IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) を使用して、シェイプをパスポイントとポイント種別を含む要素として調査できます。返された各 [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) を [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) にキャストし、[get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) と [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) が返す配列を読み取ります。この表現は輪郭解析やカスタム描画ツールへのジオメトリの受け渡しに便利です。

例ではプレゼンテーションを開き、最初のスライド上に直接ある最初のジオメトリ シェイプを見つけてそのパス セグメントを出力します。直線と曲線の両方を含むシェイプがあるプレゼンテーションを使用すると、両方の出力が確認できます。グループ内は検索しません。

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
        auto pointType = types[i] & 0x07; // フラグを除外してセグメントタイプを保持します。
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
                i += 2; // Consume both control points and the endpoint.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

配列はインデックスで対応します: `points[i]` は点、`types[i]` はその役割を示します。タイプ `0` は図形の開始、タイプ `1` は前の点から現在の点への直線を表します。3 次ベジエ セグメントは前の終点から始まり、連続するタイプ `3` エントリ 3 個（2 つの制御点と新しい終点）で構成されます。ループはこれら 3 エントリをまとめて処理し、終点が閉じているかを確認します。

ポイント種別にはフラグも含まれます。`0x07` マスクでセグメント種別を特定し、`0x80` を別途テストして閉じたサブパスかどうかを判定します。例として `129` (`0x81`) は閉じる線分の終点、`131` (`0x83`) は閉じるベジエ終点を意味します。単に `1` や `3` と比較するとこれらのケースを見逃します。ダッシュ (`0x10`) やマーカー (`0x20`) などの他のフラグは基本セグメント種別を変更しません。

**座標と変換**  
ポイントはポイント単位 (1/72 インチ) で測定され、X は右方向、Y は下方向に増加します。単一シェイプの場合、抽出された座標はすでに [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) と [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) が返す位置と幅・高さを含んでいます。たとえば、`(100, 200)` に左上がありサイズが `120 × 80` の回転なし矩形の輪郭は `(100, 200)`–`(220, 280)` です。シェイプの位置を再度加算しないでください。未回転フレームに対する相対座標を得るには X と Y を減算します。

抽出されたポイントは [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) による回転や水平・垂直フリップは適用されません。表示される輪郭を再現するには、シェイプの中心を基準にそれらの変換を適用してください。グループ化されたシェイプの場合は、グループ座標マッピングと変換も考慮し、抽出されたポイントが最終的なスライド座標になると想定せず、子フレームにすでに反映されている平行移動やスケールを二重に適用しないようにしてください。

**調査と編集の違い**  
抽出された配列は輪郭を記述したものです。配列を変更しても元のシェイプは更新されません。ポイント/種別配列が必要な分析や描画コードの場合にこのアプローチを選択してください。シェイプのローカル座標系でジオメトリ コマンドが必要な場合やジオメトリを編集したい場合は、[GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) を使用し、編集したパスは [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) または [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) で適用します。

## **GeometryPath を GraphicsPath に変換する**

現在の Aspose.Slides for C++ のパブリック API では、ジオメトリ パスとグラフィックス パスの相互変換は公開されていません。輪郭を調べるには上記のシェイプ要素を使用し、シェイプを編集するにはジオメトリ パスを使用して更新されたパスをシェイプに適用してください。

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしと輪郭はどうなりますか？**

スタイルはシェイプに残り、輪郭だけが変更されます。塗りつぶしと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタム シェイプを正しく回転させるにはどうすればよいですか？**

シェイプの [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) メソッドを使用してください。ジオメトリはシェイプの座標系にバインドされているため、シェイプと一緒に回転します。

**カスタム シェイプを画像に変換して「ロック」できますか？**

はい。必要な [slide](/slides/ja/cpp/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/cpp/shape-thumbnails/) 自体をラスタ形式でエクスポートすれば、複雑なジオメトリの後続作業が容易になります。