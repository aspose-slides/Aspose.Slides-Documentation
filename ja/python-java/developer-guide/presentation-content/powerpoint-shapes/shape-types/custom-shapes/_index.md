---
title: Python を介した Java でプレゼンテーションシェイプをカスタマイズする
linktitle: カスタムシェイプ
type: docs
weight: 20
url: /ja/python-java/custom-shape/
keywords:
- カスタムシェイプ
- シェイプを追加
- シェイプを作成
- シェイプを変更
- シェイプジオメトリ
- ジオメトリパス
- パスポイント
- 編集ポイント
- ポイントを追加
- ポイントを削除
- 編集操作
- 曲線コーナー
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python を介した Java で Aspose.Slides を使用して PowerPoint プレゼンテーションのシェイプを作成・カスタマイズします：ジオメトリパス、曲線コーナー、複合シェイプ。"
---
## **概要**

この記事では、編集ポイントとジオメトリパスを使用してシェイプのジオメトリを編集することで、Aspose.Slides のプレゼンテーションシェイプをカスタマイズする方法を説明します。既存のシェイプを変更したり、基本的なパス編集操作を実行したり、ポイントを追加または削除したり、更新されたジオメトリをシェイプに適用したりする方法を、[GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) を使って示します。

また、カスタムおよび複合シェイプの作成、角が丸いシェイプの構築、シェイプジオメトリが閉じているかの判定、シェイプ要素の検査、Java AWT のテキストアウトラインをジオメトリパスに変換する方法もデモンストレーションします。

## **編集ポイントでシェイプを変更する**

PowerPoint では **編集ポイント** を使用して四角形を変更できます。

* 角を内側または外側に移動する。
* ポイントの曲率を調整する。
* 新しいポイントを追加する。

編集ポイントを使用すると、シェイプの輪郭を変更したり、既存のシェイプを新しいシェイプのベースとして使用したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

PowerPoint のシェイプを編集するときは、次の概念を覚えておいてください。

* シェイプ（またはそのパス）は、閉じている場合と開いている場合があります。
* シェイプのパスは、セグメントで接続されたアンカーポイントで構成されます。
* セグメントは直線または曲線のいずれかです。アンカーポイントと制御ハンドルが形状を決定します。
* アンカーポイントは、コーナーポイント、ストレートポイント、スムーズポイントとして存在します：
  * コーナーポイントでは、隣接するセグメントが角度を持って接続できます。
  * スムーズポイントでは、2 つの制御ハンドルが揃っており、アンカーポイントから同じ距離にあります。
  * ストレートポイントでは、2 つの制御ハンドルが揃っていますが、アンカーポイントからの距離は異なる場合があります。
* アンカーポイントを移動したりハンドルを調整したりすると、シェイプの輪郭が変わります。

PowerPoint のシェイプを編集ポイントで操作するために、**Aspose.Slides** は [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) クラスを提供します。

* [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) インスタンスは、[GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) オブジェクトのジオメトリパスを表します。
* [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) を取得するには、[GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) メソッドを使用できます。
* シェイプに [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) を設定するには、単一パスのシェイプの場合は [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)、複数パスのシェイプの場合は [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) を使用します。
* セグメントを追加するには、[GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 以下のメソッドを使用します。
* [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) および [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) メソッドを使用して、ジオメトリパスの外観を設定できます。
* [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) メソッドを使用すると、[GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) のジオメトリパスをパスセグメントの配列として取得できます。
* 追加のシェイプジオメトリカスタマイズオプションにアクセスするには、[java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) をその [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) を通じて読み取り、セグメントを [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) に再現します。

## **基本的な編集操作**

ジオメトリパスを編集するには、以下のメソッドを使用します。インデックスを受け取るオーバーロードは、パスのセグメント配列のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入する。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| 2 つの制御点と終点を持つ立方ベジエ曲線を追加または挿入する。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 1 つの制御点と終点を持つ二次ベジエ曲線を追加または挿入する。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 指定された寸法と角度（度）で楕円弧を追加する。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| 終点を開始点に接続して現在の図形を閉じる。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| 図形の開始点を設定する。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| ゼロベースインデックスでセグメントを削除する。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **シェイプにカスタムポイントを追加する**

この例は、[GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) を使用して矩形シェイプに 2 つのポイントを挿入し、編集されたパスを [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) で適用します。座標はシェイプに対してローカルです。新しいポイントは両方ともシェイプの中心にあり、左から 100 ポイント、上から 50 ポイントの位置です。セグメントインデックス 1 と 4 が上端と下端に配置され、これらのエッジを内側に引っ張ります。

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

## **シェイプからポイントを削除する**

この例は、[GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) を使用してゼロベースインデックス 2 のセグメントを削除し、ハート形の輪郭を変更します。変更されたパスを [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) で適用すると、シェイプの輪郭が更新されます。

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

## **カスタムシェイプを作成する**

この例は、[GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) を使用して五角星を構築します。外側と内側の半径をそれぞれ 100 と 50 ポイントで交互に設定し、72 度のステップで 5 つの先端を均等に配置します。パスは [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) で閉じられ、[GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) を使用して矩形シェイプに適用し、元の輪郭を置き換えます。

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

## **複合カスタムシェイプを作成する**

この例は、シェイプの上部と下部の 3 分の 1 を表す 2 つの閉じた [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) オブジェクトを定義します。両方のパスを [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) で適用すると、中央の 3 分の 1 に隙間がある単一の複合シェイプが作成されます。

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

## **角が丸いカスタムシェイプを作成する**

この例は、直線セグメントと [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) を組み合わせて、内側に曲がった角を持つシェイプを作成します。各コーナーサイズはアークの幅と高さ（ポイント）を設定し、-90 度のスイープで反時計回りの 1/4 楕円を描きます。完成したパスは [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) で適用され、プレゼンテーションは PPTX 形式で保存されます。

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

## **シェイプジオメトリが閉じているか確認する**

以下のヘルパーは、すべての非空ジオメトリパスが閉じるセグメントで終わっているかどうかをチェックします。[GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) を読み取り、最終セグメントの [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) を [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/) と比較します。パスがない場合は `False` を返します。このチェックは各パスの最終コマンドのみを対象とし、パス内のすべてのサブフィギュアは検査しません。例では矩形に対して `True` が出力されます。

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

## **シェイプ要素を抽出して検査する**

[GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) を使用して、パスポイントとポイントタイプを含む要素として既存シェイプを検査します。返された各要素を `jpype.JObject` で [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) にキャストし、[getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) と [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) メソッドでポイントとタイプの配列を取得します。この表現は輪郭解析やカスタム描画ツールへのジオメトリ受け渡しに便利です。

例では input.pptx を開き、最初のスライド上の最初のジオメトリシェイプを取得してそのパスセグメントを出力します。直線と曲線セグメントの両方を含むシェイプがあるプレゼンテーションを使用してください。グループ内の検索は行いません。

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

配列はインデックスで対応します：`points[i]` はポイント、`types[i]` はその役割を示します。タイプ `0` は図形の開始を、タイプ `1` は前のポイントから現在のポイントへの直線を表します。立方ベジエセグメントは前の終点から開始し、3 つの連続したタイプ `3` エントリ（2 つの制御点と新しい終点）で構成されます。ループはこれら 3 エントリをまとめて処理し、終点での閉鎖をチェックします。

ポイントタイプにはフラグも含まれます。`0x07` でセグメント種別をマスクし、`0x80` を別途テストして閉じたサブパスを検出します。たとえば `129`（`0x81`）はサブパスを閉じる直線終点、`131`（`0x83`）はサブパスを閉じるベジエ終点を意味します。Java はこれらのフラグを符号付きバイトで保持するため、マスク処理が必要です。`1` や `3` のみで比較するとこれらのケースを見逃します。ダッシュ（`0x10`）やマーカー（`0x20`）などの他のフラグは基本セグメント種別を変更しません。

**座標と変換。** ポイントはポイント単位（1/72 インチ）で測定され、X は右方向に、Y は下方向に増加します。グループ化されていないシェイプの場合、抽出された座標はすでに [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) と [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) が返す位置を含み、現在の幅と高さを反映しています。たとえば、左上が `(100, 200)`、サイズが `120 × 80` の回転していない矩形は輪郭境界が `(100, 200)`–`(220, 280)` となります。シェイプの位置を二重に加算しないでください。X と Y を減算して、未回転フレームに対する相対座標を取得します。

抽出されたポイントは、[getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) が返す回転や水平・垂直の反転を適用していません。表示されている輪郭を再現するには、シェイプの中心を基点にこれらの変換を適用してください。グループ化されたシェイプの場合は、グループ座標マッピングと変換も考慮し、抽出されたポイントが最終的なスライド座標であると想定したり、子フレームにすでに反映されている平行移動やスケールを二度適用したりしないでください。

**検査と編集の違い。** 抽出された配列は輪郭を記述しますが、配列を変更しても元のシェイプは更新されません。ポイント/タイプ配列が必要な分析や描画コードにこのアプローチを使用してください。シェイプのローカル座標系でジオメトリコマンドが必要な場合やジオメトリを編集したい場合は、[getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) を使用し、編集したパスは [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) または [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) で適用してください。

## **Java AWT シェイプを GeometryPath に変換する**

この例は、矩形の輪郭とテキストをジオメトリに変換して組み合わせます。輪郭の [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) メソッドで塗りつぶしを無効にします。[GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) が [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) にテキストアウトラインを作成し、その [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) が move、line、quadratic、cubic、closing セグメントを供給します。例ではそれらを [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) に再現します。

テキストは 40 ポイントの Arial フォントを使用します。輪郭は水平方向に 20 ポイントオフセットされ、シェイプの上端から 10 ポイント下に配置されます。テキストパスは塗りつぶされ、元の矩形は輪郭のまま残ります。両方のパスを [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) で適用すると、矩形とテキストを含む単一のシェイプが生成されます。

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

    # シェイプのジオメトリパスを取得する。
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # テキスト付きの新しいグラフィックスパスを作成する。
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

    # グラフィックスパスをジオメトリパスに変換する。
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

    # 元のジオメトリパスとテキストパスを一緒に適用する。
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしとアウトラインはどうなりますか？**

スタイルはシェイプに残り、輪郭だけが変更されます。塗りつぶしとアウトラインは新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタムシェイプを正しく回転させるにはどうすればよいですか？**

シェイプの [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) メソッドを使用してください。ジオメトリはシェイプの座標系にバインドされているため、シェイプと共に回転します。

**カスタムシェイプを画像に変換して「ロック」できますか？**

はい。必要な [slide](/slides/ja/python-java/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/python-java/create-shape-thumbnails/) 自体をラスタ形式でエクスポートすれば、複雑なジオメトリの後続作業が容易になります。