---
title: Java 経由で Python 用プレゼンテーション形状をカスタマイズ
linktitle: カスタム形状
type: docs
weight: 20
url: /ja/python-java/custom-shape/
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
- Python
- Aspose.Slides
description: "Java 経由で Python 用 Aspose.Slides を使用して PowerPoint プレゼンテーションの形状を作成およびカスタマイズします：ジオメトリパス、曲線コーナー、複合形状。"
---
## **概要**

この記事では、編集ポイントとジオメトリパスを使用して形状のジオメトリを編集することで、Aspose.Slides のプレゼンテーション形状をカスタマイズする方法を説明します。既存の形状を変更し、基本的なパス編集操作を実行し、ポイントを追加または削除し、更新されたジオメトリを形状に適用するために [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) の使い方を示します。

また、カスタムおよび複合形状の作成、角が丸い形状の構築、形状ジオメトリが閉じているかの判定、形状要素の検査、Java AWT テキストアウトラインをジオメトリパスに変換する方法も実演します。

## **編集ポイントを使用して形状を変更する**

PowerPoint では、**編集ポイント** を使用して四角形を変更できます。

* 角を内側または外側に移動する。
* ポイントの曲率を調整する。
* 新しいポイントを追加する。

ポイントを編集すると、形状の輪郭を変更したり、既存の形状を新しい形状の基礎として使用したりできます。

## **形状編集のヒント**

![overview_image](custom_shape_0.png)

PowerPoint の形状を編集する際に覚えておくべき概念は次のとおりです。

* 形状（またはそのパス）は閉じている場合と開いている場合があります。
* 形状のパスは、セグメントで接続されたアンカーポイントで構成されます。
* セグメントは直線または曲線になり得ます。アンカーポイントと制御ハンドルが形状を決定します。
* アンカーポイントはコーナー、直線、スムーズのいずれかです：
  * コーナーでは、隣接するセグメントが角度を持って交わります。
  * スムーズでは、2 つの制御ハンドルが揃っており、アンカーポイントから等距離です。
  * 直線ポイントでは、2 つの制御ハンドルが揃っていますが、距離は異なる場合があります。
* アンカーポイントを移動したりハンドルを調整したりすると、形状の輪郭が変わります。

PowerPoint の形状を編集ポイントで操作するために、**Aspose.Slides** は [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) クラスを提供します。

* [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) インスタンスは、[GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) オブジェクトのジオメトリパスを表します。
* [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) を取得するには、[GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) メソッドを使用します。
* 形状に [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) を設定するには、単一パスの場合は [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)、複数パスの場合は [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) を使用します。
* セグメントを追加するには、[GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) の各種メソッドを利用できます。
* [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) および [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) メソッドでジオメトリパスの外観を設定できます。
* [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) メソッドで、[GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) のジオメトリパスをパスセグメントの配列として取得できます。
* 追加の形状ジオメトリ カスタマイズ オプションにアクセスするには、[java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) をその [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) で読み取り、セグメントを [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) に再現します。

## **基本的な編集操作**

ジオメトリパスを編集するには以下のメソッドを使用します。インデックスを受け取るオーバーロードは、パスのセグメント配列のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入する。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| 2 つの制御点と終点を持つ 3 次ベジェ曲線を追加または挿入する。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 1 つの制御点と終点を持つ 2 次ベジェ曲線を追加または挿入する。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 指定した寸法と角度（度）で楕円弧を追加する。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| 終点を開始点に接続して現在の図形を閉じる。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| 図形の開始点を設定する。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| ゼロベースインデックスのセグメントを削除する。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **カスタムポイントを形状に追加する**

この例は、[GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) を使用して長方形に 2 つのポイントを挿入し、[GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) で編集したパスを適用します。座標は形状ローカル座標で、両方の新ポイントは形状の中心にあり、左から 100 ポイント、上から 50 ポイントの位置です。セグメントインデックス 1 と 4 が上端と下端に配置され、これらのエッジを内側に引っ張ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **形状からポイントを削除する**

この例は、[GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) でゼロベースインデックス 2 のセグメントを削除してハート形の輪郭を変更します。[GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) で変更したパスを適用すると、形状の輪郭が更新されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **カスタム形状を作成する**

この例は、[GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) を使用して五角形の星を構築します。外半径 100、内半径 50 の交互の半径が先端と凹みを定義し、72 度のステップで 5 つの先端を均等に配置します。パスは [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) で閉じられ、[GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) で長方形に適用され、元の輪郭が置き換えられます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **複合カスタム形状を作成する**

この例は、形状の上部 1/3 と下部 1/3 用に 2 つの閉じた [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) オブジェクトを定義します。両方のパスを [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) で適用すると、中央の 1/3 に隙間がある単一の複合形状が作成されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **角が丸いカスタム形状を作成する**

この例は、直線セグメントと [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) を組み合わせて、内側に曲がった角を持つ形状を作成します。各角のサイズはアークの幅と高さ（ポイント）を設定し、-90 度のスイープで反時計回りの 1/4 楕円を描きます。完成したパスは [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) で適用され、プレゼンテーションは PPTX 形式で保存されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **形状ジオメトリが閉じているか確認する**

次のヘルパーは、すべての非空ジオメトリパスが閉じるセグメントで終わっているかをチェックします。[GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) を読み取り、最終セグメントの [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) が [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/) と一致するかを比較します。非空パスがない場合は `False` を返します。このチェックは各パスの最終コマンドのみを対象とし、パス内のすべてのサブフィギュアは検査しません。例は矩形に対して `True` を出力します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **ジオメトリパスコマンドを検査する**

[contour.pptx](contour.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置してください。1 枚目のスライドの最初の形状は、直線の上端、3 次ベジェ曲線、直線の閉じた下端で構成されています。[getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) を使用して形状のパスを取得し、[getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) で各パスのセグメントを描画順に取得します。各セグメントについて、[getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) がコマンドを識別し、[getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData) が返す値の解釈方法を決定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

形状はスライド上で (200, 100) ポイントの位置にあります。報告された座標は形状ローカル座標で、左上隅が (0, 0)、X が右方向に増加し、Y が下方向に増加します。閉じるセグメントは追加座標なしで開始点に戻ります。

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **形状要素を抽出して検査する**

[GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) を使用して、既存の形状をパスポイントとポイント種別を含む要素として検査します。返された各要素を `jpype.JObject` で [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) にキャストし、[getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) と [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) メソッドでポイント配列と種別配列を取得します。この表現は輪郭解析やカスタム描画ツールへのジオメトリ渡しに便利です。

例では input.pptx を開き、1 枚目のスライド上の最初のジオメトリ形状を直接取得し、そのパスセグメントを出力します。直線と曲線のセグメントを含む形状があるプレゼンテーションで実行すると、両方の出力が確認できます。グループ内部は検索しません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

配列はインデックスで対応します：`points[i]` がポイント、`types[i]` がその役割を示します。種別 `0` は図形開始、種別 `1` は前のポイントから現在のポイントへの直線を表します。3 次ベジェセグメントは前の終点から開始し、連続した種別 `3` エントリ 3 つ（2 つの制御点と新しい終点）で構成されます。ループはこれら 3 エントリをまとめて処理し、終点が閉じているかをチェックします。

ポイント種別にはフラグも含まれます。`0x07` でセグメント種別を特定し、`0x80` で閉じたサブパスかどうかを別途判定します。例として `129`（`0x81`）は閉じたサブパスの直線終点、`131`（`0x83`）は閉じたベジェ終点を意味します。Java は符号付きバイトでフラグを保持するため、マスク処理でビット値を保持します。単に `1` や `3` と比較するとこれらのケースが見逃されます。ダッシュ（`0x10`）やマーカー（`0x20`）などの他のフラグは基礎セグメント種別を変えません。

**座標と変換**。ポイントはポイント単位（1/72 インチ）で測定され、X は右方向、Y は下方向に増加します。単独形状の場合、抽出した座標はすでに [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) および [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) が返す位置を含み、現在の幅と高さを反映しています。たとえば、未回転の矩形が `(100, 200)` にありサイズが `120 × 80` の場合、輪郭境界は `(100, 200)`–`(220, 280)` です。位置を再度加算しないでください。X と Y を減算して未回転フレーム基準の座標を取得します。

抽出されたポイントは [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) が返す回転や水平・垂直フリップは適用されません。表示された輪郭を再現するには、形状の中心を基準にそれらの変換を適用してください。グループ化された形状の場合は、グループ座標のマッピングと変換も考慮し、抽出されたポイントが最終的なスライド座標であると仮定したり、すでに子フレームに反映されている平行移動やスケールを二度適用しないでください。

**検査と編集の違い**。抽出した配列は輪郭を記述するだけで、変更しても元の形状は更新されません。ポイント/種別配列が必要な分析や描画コードの場合にこの手法を選択し、形状のローカル座標系でジオメトリコマンドが必要な場合やジオメトリを編集したい場合は [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) を使用してください。編集したパスは [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) または [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) を通じて適用します。

## **Java AWT Shape を GeometryPath に変換する**

この例は、矩形の輪郭にテキストをジオメトリに変換して組み合わせます。輪郭の [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) メソッドで塗りつぶしを無効にします。[GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) が [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 上にテキストアウトラインを作成し、[PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) が move、line、quadratic、cubic、close の各セグメントを供給します。例はそれらを [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) に再現します。

テキストは 40 ポイントの Arial フォントを使用します。輪郭は水平方向に 20 ポイントオフセットし、視覚的上端が形状上端から 10 ポイント下に配置されます。テキストパスは塗りつぶされ、元の矩形は輪郭のままです。両方のパスを [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) で適用すると、矩形とテキストを含む単一の形状が生成されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # 形状のジオメトリパスを取得します。
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # テキストで新しいグラフィックパスを作成します。
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # グラフィックパスをジオメトリパスに変換します。
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # テキストパスと元のジオメトリパスを一緒に適用します。
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしと輪郭はどうなりますか？**

スタイルは形状に残り、輪郭だけが変更されます。塗りつぶしと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタム形状を正しく回転させるにはどうすればよいですか？**

形状の [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) メソッドを使用してください。ジオメトリは形状の座標系にバインドされているため、形状と一緒に回転します。

**カスタム形状を画像に変換して「ロック」できますか？**

はい。必要な [slide](/slides/ja/python-java/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/python-java/create-shape-thumbnails/) 自体をラスタ形式でエクスポートすれば、複雑なジオメトリの後続作業が簡素化されます。