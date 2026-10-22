---
title: .NET でプレゼンテーション形状をカスタマイズ
linktitle: カスタム形状
type: docs
weight: 20
url: /ja/net/custom-shape/
keywords:
- カスタム形状
- 形状の追加
- 形状の作成
- 形状の変更
- 形状ジオメトリ
- ジオメトリパス
- パスポイント
- 編集ポイント
- ポイントの追加
- ポイントの削除
- 編集操作
- 曲線コーナー
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションの形状を作成およびカスタマイズする: ジオメトリパス、曲線コーナー、複合形状。"
---
## **概要**

この記事では、編集ポイントとジオメトリ パスを使用して形状ジオメトリを編集することで、Aspose.Slides のプレゼンテーション形状をカスタマイズする方法を説明します。**[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)** と **[IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/)** を使用して既存の形状を変更し、基本的なパス編集操作を実行し、ポイントを追加または削除し、更新されたジオメトリを形状に適用する方法を示します。

また、カスタムおよび複合形状の作成、曲線コーナー付き形状の構築、形状ジオメトリが閉じているかどうかの判定、そして追加のジオメトリ カスタマイズ シナリオのために **[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)** と **[GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)** のレガシー変換の使用方法も示します。

## **編集ポイントを使用して形状を変更する**

PowerPoint では、**Edit Points** を使用して四角形を変更できます：

* 角を内側または外側に移動する。
* 点での曲率を調整する。
* 新しいポイントを追加する。

編集ポイントを使うことで、形状の輪郭を変更したり、既存の形状を新しい形状の基礎として使用したりできます。

## **形状編集のヒント**

![overview_image](custom_shape_0.png)

PowerPoint 形状を編集するときは、次の概念を念頭に置いてください：

* 形状（またはそのパス）は閉じている場合と開いている場合があります。
* 形状のパスは、セグメントで接続されたアンカーポイントで構成されます。
* セグメントは直線または曲線にすることができます。アンカーポイントと制御ハンドルがその形状を決定します。
* アンカーポイントは、コーナーポイント、ストレートポイント、スムーズポイントのいずれかです：
  * コーナーポイントでは、隣接するセグメントが角度で接続できます。
  * スムーズポイントでは、2 つの制御ハンドルが揃っており、アンカーポイントから同じ距離にあります。
  * ストレートポイントでは、2 つの制御ハンドルが揃っていますが、アンカーポイントからの距離は異なる場合があります。
* アンカーポイントを移動したりハンドルを調整したりすると、形状の輪郭が変わります。

PowerPoint 形状を編集ポイントで編集するには、**Aspose.Slides** が **[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)** クラスと **[IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/)** インターフェイスを提供します。

* **[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)** インスタンスは、**[IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/)** オブジェクトのジオメトリ パスを表します。
* **[IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/)** メソッドを使用して、**[IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/)** インスタンスから **[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)** を取得できます。
* 形状に **[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)** を設定するには、単一パスの形状の場合は **[IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)**、複数パスの形状の場合は **[IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)** を使用します。
* セグメントを追加するには、**[IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/)** 配下のメソッドを使用できます。
* **[IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/)** と **[IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/)** プロパティを使用して、ジオメトリ パスの外観を設定できます。
* **[IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/)** プロパティを使用して、**[GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/)** のジオメトリ パスをパス セグメントの配列として取得できます。
* 以下の変換メソッドをサポートするレガシー バージョンでは、**[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)** を **[GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)** に変換できます。
* **[GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/)** と **[GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/)** メソッド（**[ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)** クラス）を使用して、**[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)** と **[GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)** の間で変換します。

## **シンプルな編集操作**

ジオメトリ パスを編集するには、以下のメソッドを使用します。インデックスを受け取るオーバーロードは、パスのセグメント配列内のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入する。 | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| 2 つの制御点と終点を持つ 3 次ベジェ曲線を追加または挿入する。 | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| 1 つの制御点と終点を持つ 2 次ベジェ曲線を追加または挿入する。 | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| 指定された寸法と角度（度）で楕円弧を追加する。 | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| 終点を開始点に接続して現在の図形を閉じる。 | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| 図形の開始点を設定する。 | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| ゼロベースのインデックスでセグメントを削除する。 | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **形状にカスタムポイントを追加する**

この例は、**[GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/)** を使用して矩形形状に 2 つのポイントを挿入し、**[IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)** で編集されたパスを適用します。座標は形状ローカルです：新しいポイントは両方とも中心にあり、左から 100 ポイント、上から 50 ポイントの位置です。セグメント インデックス 1 と 4 はそれぞれ上辺と下辺に配置され、これらの辺を内側に引き込みます。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **形状からポイントを削除する**

この例は、**[GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/)** を使用してゼロベース インデックス 2 のセグメントを削除し、ハート形アウトラインを変更します。**[IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)** で修正されたパスを適用すると、形状の輪郭が更新されます。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **カスタム形状を作成する**

この例は、**[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)** を使用して五芒星を構築します。外半径 100 ポイント、内半径 50 ポイントを交互に配置して先端と凹部を定義し、72 度のステップで 5 つの先端を均等に配置します。パスは **[GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/)** で閉じられ、**[IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)** を使用して矩形形状に適用し、元のアウトラインを置き換えます。

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **複合カスタム形状を作成する**

この例は、形状の上部と下部の 3 分の 1 を表す 2 つの閉じた **[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)** オブジェクトを定義します。**[IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)** で両方のパスを適用すると、中央の 3 分の 1 に隙間がある単一の複合形状が作成されます。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **曲線コーナー付きカスタム形状を作成する**

この例は、直線セグメントと **[GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/)** を組み合わせて、内側に曲がったコーナーを持つ形状を作成します。各コーナー サイズは弧の幅と高さ（ポイント）を設定し、-90 度のスイープで反時計回りの 1/4 楕円を描きます。完成したパスは **[IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)** で適用され、プレゼンテーションは PPTX 形式で保存されます。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **形状ジオメトリが閉じているか確認する**

以下のヘルパーは、すべての非空ジオメトリ パスが閉じるセグメントで終わっているかどうかをチェックします。**[IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/)** を読み取り、最終セグメントの **[IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/)** を **[PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/)** と比較します。非空パスがない場合は false を返します。このチェックは各パスの最終コマンドを対象とし、パス内のすべてのサブフィギュアを調べるわけではありません。例は矩形に対して `True` を出力します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **形状要素の抽出と検査**

**[IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/)** を使用して、既存の形状をパス点とポイント種別を含む要素として検査します。返される各 **[IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/)** を **[ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/)** にキャストして、**[PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/)** と **[PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/)** 配列を読み取ります。この表現は輪郭解析やジオメトリをカスタム描画ツールに渡す際に便利です。

例ではプレゼンテーションを開き、最初のスライド上に直接ある最初のジオメトリ形状を見つけて、そのパス セグメントを出力します。直線と曲線セグメントの両方を含む形状があるプレゼンテーションを使用すると、両方の出力が確認できます。グループ内は検索しません。

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // Keep the segment type, excluding flags.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

配列はインデックスで対応しています：`points[i]` は点、`types[i]` はその役割を示します。タイプ `0` は図形の開始、タイプ `1` は前の点から現在の点への直線を描きます。3 次ベジェ セグメントは前の終点から開始し、連続するタイプ `3` のエントリ 3 つ（2 つの制御点と新しい終点）を使用します。ループはこれら 3 つをまとめて消費し、終点が閉じているかをチェックします。

ポイント種別にはフラグも含まれます。`0x07` でセグメント種別を判別し、`0x80` を別途テストして閉じたサブパスを検出します。例として `129`（`0x81`）はサブパスを閉じる直線終点、`131`（`0x83`）はサブパスを閉じるベジェ終点を意味します。生の値を `1` や `3` のみと比較するとこれらのケースを見逃します。ダッシュ（`0x10`）やマーカー（`0x20`）などの他のフラグは基本セグメント種別を変更しません。

**座標と変換。** 点はポイント（1/72 インチ）で測定され、X は右方向に、Y は下方向に増加します。グループ化されていない形状の場合、抽出された座標はすでに **[X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/)** と **[Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/)** の位置を含み、現在の幅と高さを反映しています。例として、未回転の矩形が `(100, 200)` にありサイズが `120 × 80` の場合、輪郭境界は `(100, 200)`–`(220, 280)` です。形状の位置を再度加算しないでください。未回転フレームに対する相対座標を得るには X と Y を減算します。

抽出された点は形状の **[Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/)** や水平・垂直フリップは適用されません。表示されている輪郭を再現するには、形状の中心を基点にこれらの変換を適用してください。グループ化された形状の場合、グループ座標のマッピングと変換も考慮してください。抽出された点が最終的なスライド座標であると仮定したり、子フレームですでに反映されている変換を二度適用したりしないでください。

**検査 vs. 編集。** 抽出された配列は輪郭を記述しますが、変更しても元の形状は更新されません。ポイント/種別配列が必要な解析や描画コードの場合にこのアプローチを選択してください。形状のローカル座標系でジオメトリ コマンドが必要な場合、またはジオメトリを編集したい場合は **[GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/)** を使用し、編集したパスは **[SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)** または **[SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)** で適用します。

## **GeometryPath を GraphicsPath に変換する (System.Drawing.Drawing2D)**

以下の例は、**[ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/)** をサポートするレガシー Aspose.Slides for .NET アセンブリ（例：バージョン 25.10）と、`System.Drawing.Common` がインストールされた Windows 環境が必要です。変換メソッドは **[version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/)** で削除されました。

この例は、矩形のアウトラインとジオメトリに変換されたテキストを組み合わせます。アウトラインの **[IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/)** は塗りつぶしを無効に設定されています。**[GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)** はテキストのアウトラインを保持し、**[ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/)** がそれを塗りつぶしジオメトリ パスに変換します。**[IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)** で両方のパスを適用すると、矩形とテキストを含む単一の形状が生成されます。逆方向への変換には **[ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/)** を使用します。

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![example5_image](custom_shape_5.png)

## **よくある質問**

**ジオメトリを置き換えた後、塗りと輪郭はどうなりますか？**

スタイルは形状に残り、輪郭だけが変更されます。塗りと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタム形状を正しく回転させるにはどうすればよいですか？**

形状の **[Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/)** プロパティを使用します。ジオメトリは形状にバインドされているため、形状と一緒に回転します。

**カスタム形状を画像に変換して結果を「固定」できますか？**

はい。必要な **[slide](/slides/ja/net/convert-powerpoint-to-png/)** 領域または **[shape](/slides/ja/net/create-shape-thumbnails/)** 自体をラスタ形式でエクスポートすると、複雑なジオメトリの後続作業が簡素化されます。