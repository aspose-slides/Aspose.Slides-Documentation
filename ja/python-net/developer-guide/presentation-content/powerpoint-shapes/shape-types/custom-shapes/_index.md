---
title: Pythonでプレゼンテーションのシェイプをカスタマイズ
linktitle: カスタムシェイプ
type: docs
weight: 20
url: /ja/python-net/custom-shape/
keywords:
- カスタムシェイプ
- シェイプの追加
- シェイプの作成
- シェイプの変更
- シェイプジオメトリ
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーション内のシェイプを作成およびカスタマイズします：ジオメトリパス、曲線コーナー、複合シェイプ。"
---
## **概要**

このドキュメントでは、編集ポイントとジオメトリパスを使用してシェイプジオメトリを編集することで、Aspose.Slides のプレゼンテーション シェイプをカスタマイズする方法を説明します。既存のシェイプを変更し、基本的なパス編集操作を実行し、ポイントを追加または削除し、更新されたジオメトリをシェイプに適用するために、[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) の使用例を示します。

また、カスタムおよび複合シェイプの作成、曲線コーナー付きシェイプの構築、シェイプジオメトリが閉じているかの判定、輪郭解析用のシェイプ要素の抽出方法も示します。

## **編集ポイントを使用してシェイプを変更する**

PowerPoint では **Edit Points** を使って四角形を変更できます。

* 角を内側または外側に移動する。
* ポイントの曲率を調整する。
* 新しいポイントを追加する。

編集ポイントを使用すると、シェイプの輪郭を変更したり、既存のシェイプを新しいシェイプのベースとして使用したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

PowerPoint のシェイプを編集する際は、以下の概念を念頭に置いてください。

* シェイプ（またはそのパス）は閉じている場合と開いている場合があります。
* シェイプのパスは、アンカーポイントとそれらを結ぶセグメントで構成されます。
* セグメントは直線または曲線になることができ、アンカーポイントとコントロールハンドルが形状を決定します。
* アンカーポイントはコーナーポイント、直線ポイント、スムーズポイントのいずれかです。
  * コーナーポイントでは、隣接するセグメントが角度を持って接続します。
  * スムーズポイントでは、2 つのコントロールハンドルが一直線上にあり、アンカーポイントから同じ距離にあります。
  * 直線ポイントでは、2 つのコントロールハンドルが一直線上にありますが、距離は異なる場合があります。
* アンカーポイントを移動したりハンドルを調整したりすると、シェイプの輪郭が変わります。

PowerPoint のシェイプを編集ポイントで操作するには、**Aspose.Slides** が提供する [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスを使用します。

* [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスは、[GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) オブジェクトのジオメトリ パスを表します。
* [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を取得するには、[GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) メソッドを使用できます。
* シェイプに対して [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を設定するには、単一パスの場合は [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)、複数パスの場合は [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) を使用します。
* セグメントを追加するには、[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) に用意されているメソッドを使用します。
* [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) および [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) プロパティで、ジオメトリ パスの外観を設定できます。
* [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) プロパティを使って、[GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) のジオメトリ パスをパス セグメントの配列として取得できます。

## **シンプルな編集操作**

以下のメソッドを使用してジオメトリ パスを編集します。インデックスを受け取るオーバーロードは、パスのセグメント配列のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入します。 | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| 2 つの制御点と終点を持つ三次ベジェ曲線を追加または挿入します。 | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| 1 つの制御点と終点を持つ二次ベジェ曲線を追加または挿入します。 | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| 指定された寸法と角度（度単位）の楕円弧を追加します。 | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| 終点を開始点に接続して現在の図形を閉じます。 | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| 図形の開始点を設定します。 | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| ゼロベースのインデックスでセグメントを削除します。 | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **シェイプにカスタムポイントを追加する**

この例では、[GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) を使用して矩形シェイプに 2 つのポイントを挿入し、[GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) で編集したパスを適用しています。座標はシェイプローカル座標で、両方の新しいポイントはシェイプの中心にあり、左端から 100 ポイント、上端から 50 ポイントの位置にあります。セグメント インデックス 1 と 4 はそれぞれ上辺と下辺に配置され、これらの辺を内側に引っ張ります。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **シェイプからポイントを削除する**

この例では、[GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) を使用してゼロベース インデックス 2 のセグメントを削除し、ハート形の輪郭を変更しています。[GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) で変更後のパスを適用すると、シェイプの輪郭が更新されます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **カスタムシェイプの作成**

この例では、[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を使って五角星を構築します。外半径 100 ポイント、内半径 50 ポイントを交互に配置し、72 度ごとのステップで 5 つの先端を均等に配置します。パスは [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) で閉じられ、[GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) を使って矩形シェイプに適用し、元の輪郭を置き換えます。

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **複合カスタムシェイプの作成**

この例では、シェイプの上部 1/3 と下部 1/3 用に 2 つの閉じた [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) オブジェクトを定義します。[GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) で両方のパスを適用すると、中央の 1/3 に隙間がある単一の複合シェイプが作成されます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **曲線コーナー付きカスタムシェイプの作成**

この例では、直線セグメントと [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) を組み合わせて、内側に曲がったコーナーを持つシェイプを作成します。各コーナーサイズは弧の幅と高さ（ポイント）を設定し、-90 度のスイープで反時計回りの 1/4 楕円を描きます。完成したパスは [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) で適用され、プレゼンテーションは PPTX 形式で保存されます。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **シェイプジオメトリが閉じているか確認する**

以下のヘルパーは、すべての非空ジオメトリ パスが閉じるセグメントで終わるかどうかをチェックします。[GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) を読み取り、最終セグメントの [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) と [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/) を比較します。非空パスがない場合は false を返します。このチェックは各パスの最終コマンドのみを確認し、パス内のすべてのサブフィギュアを検査するわけではありません。例では矩形に対して `True` が出力されます。

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **シェイプ要素の抽出と検査**

[GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) を使用して、パスポイントとポイントタイプを含む要素として既存シェイプを検査できます。各返された [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) は、その [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) と [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) 配列を公開します。この表現は輪郭解析やカスタム描画ツールへのジオメトリ渡しに便利です。

例ではプレゼンテーションを開き、最初のスライド上の最初のジオメトリ シェイプを取得してそのパス セグメントを出力します。直線と曲線のセグメントを持つシェイプが含まれるプレゼンテーションを使用すると、両方の出力を確認できます。グループ内は検索しません。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # セグメントタイプを保持し、フラグは除外します。
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # コントロールポイントと終点の両方を消費します。

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

配列はインデックスで対応します。`points[i]` は点、`types[i]` はその役割を表します。タイプ `0` は図形の開始、タイプ `1` は前の点から現在の点への直線です。三次ベジェ セグメントは、前の終点から開始し、連続したタイプ `3` のエントリ 3 つ（2 つの制御点と新しい終点）で構成されます。ループはこれら 3 つをまとめて消費し、終点が閉じているかをチェックします。

ポイントタイプにはフラグも含まれます。`0x07` でセグメントタイプを判別し、`0x80` を別途テストして閉じたサブパスかどうかを検出します。例として `129`（`0x81`）は閉じたサブパスの直線終点、`131`（`0x83`）は閉じたベジェ終点を意味します。単に `1` や `3` と比較するとこれらのケースを見逃します。ダッシュ（`0x10`）やマーカー（`0x20`）といった他のフラグは基本セグメントタイプを変更しません。

**座標と変換**。ポイントはポイント単位（1/72 インチ）で測定され、X は右方向、Y は下方向に増加します。グループ化されていないシェイプの場合、抽出された座標はすでにシェイプの [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) と [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) 位置を含み、現在の幅と高さを反映しています。たとえば、左上が `(100, 200)`、サイズが `120 × 80` の未回転矩形は輪郭境界が `(100, 200)`–`(220, 280)` となります。シェイプの位置を再度加算しないでください。未回転フレームに対して相対座標を得るには X と Y を減算します。

抽出されたポイントはシェイプの [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) や水平・垂直フリップは適用されていません。表示されている輪郭を再現するには、シェイプの中心を基点にしてそれらの変換を適用してください。グループ化されたシェイプの場合は、グループ座標マッピングと変換も考慮する必要があります。抽出ポイントが最終的なスライド座標であると仮定したり、子フレームにすでに反映されている変換を二度適用したりしないでください。

**検査と編集の違い**。抽出された配列は輪郭を記述しており、変更しても元のシェイプは更新されません。ポイント/タイプ配列が分析や描画コードで必要な場合にこの手法を選択してください。シェイプのローカル座標系でジオメトリ コマンドが必要、またはジオメトリを編集したい場合は [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) を使用し、編集したパスは [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) または [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) で適用してください。

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしとアウトラインはどうなりますか？**

スタイルはシェイプに残り、輪郭だけが変更されます。塗りつぶしとアウトラインは新しいジオメトリに自動的に適用されます。

**カスタムシェイプをジオメトリとともに正しく回転させるにはどうすればよいですか？**

シェイプの [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) プロパティを使用してください。ジオメトリはシェイプの座標系にバインドされているため、シェイプと一緒に回転します。

**カスタムシェイプを画像に変換して「ロックイン」できますか？**

はい。必要な [slide](/slides/ja/python-net/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/python-net/create-shape-thumbnails/) 自体をラスタ形式でエクスポートすると、複雑なジオメトリの後続作業が簡素化されます。