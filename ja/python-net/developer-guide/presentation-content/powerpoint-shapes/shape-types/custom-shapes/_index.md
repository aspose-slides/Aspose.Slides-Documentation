---
title: Python でプレゼンテーション シェイプをカスタマイズする
linktitle: カスタムシェイプ
type: docs
weight: 20
url: /ja/python-net/custom-shape/
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーションのシェイプを作成およびカスタマイズします：ジオメトリパス、曲線コーナー、複合シェイプ。"
---
## **概要**

この記事では、編集ポイントとジオメトリパスを使用してシェイプジオメトリを編集することで、Aspose.Slides のプレゼンテーションシェイプをカスタマイズする方法を説明します。[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を使用して既存のシェイプを変更し、基本的なパス編集操作を実行し、ポイントを追加または削除し、更新されたジオメトリをシェイプに適用する方法を示します。

また、カスタムシェイプや複合シェイプの作成、角が丸いシェイプの構築、シェイプジオメトリが閉じているかの判定、輪郭解析のためのシェイプ要素の抽出方法も実演します。

## **編集ポイントを使用したシェイプの変更**

PowerPoint では **Edit Points** を使用して正方形を変更できます。

* 角を内側または外側に移動する。
* ポイントの曲率を調整する。
* 新しいポイントを追加する。

編集ポイントを使用すると、シェイプの輪郭を変更したり、既存のシェイプを新しいシェイプの基礎として使用したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

PowerPoint のシェイプを編集する際に覚えておくべき概念は次のとおりです。

* シェイプ（またはそのパス）は、閉じている場合と開いている場合があります。
* シェイプのパスは、セグメントで接続されたアンカーポイントで構成されます。
* セグメントは直線または曲線になり得ます。アンカーポイントと制御ハンドルが形状を決定します。
* アンカーポイントは、コーナーポイント、ストレートポイント、スムーズポイントとして存在します。
  * コーナーポイントでは、隣接するセグメントが角度を持って接続できます。
  * スムーズポイントでは、2 つの制御ハンドルが揃っており、アンカーポイントから同等の距離にあります。
  * ストレートポイントでは、2 つの制御ハンドルが揃っていますが、アンカーポイントからの距離は異なる場合があります。
* アンカーポイントを移動したりハンドルを調整したりすると、シェイプの輪郭が変わります。

編集ポイントを介して PowerPoint シェイプを編集するために、**Aspose.Slides** は [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスを提供します。

* [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスは、[GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) オブジェクトのジオメトリパスを表します。
* [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を取得するには、[GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) メソッドを使用できます。
* シェイプに [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を設定するには、単一パスのシェイプの場合は [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) を、複数パスのシェイプの場合は [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) を使用します。
* セグメントを追加するには、[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 配下のメソッドを使用します。
* [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) および [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) プロパティを使用して、ジオメトリパスの外観を設定できます。
* [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) プロパティを使用すると、[GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) のジオメトリパスをパスセグメントの配列として取得できます。

## **シンプルな編集操作**

以下のメソッドを使用してジオメトリパスを編集します。インデックスを受け取るオーバーロードは、パスのセグメント配列内のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入する。 | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| 2 つの制御点と終点を持つ 3 次ベジエ曲線を追加または挿入する。 | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| 1 つの制御点と終点を持つ 2 次ベジエ曲線を追加または挿入する。 | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| 指定された寸法と角度（度）で楕円弧を追加する。 | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| 終点を開始点に接続して現在の図形を閉じる。 | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| 図形の開始点を設定する。 | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| ゼロベースインデックスでセグメントを削除する。 | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **シェイプにカスタムポイントを追加する**

この例では、[GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) を使用して矩形シェイプに 2 つのポイントを挿入し、編集したパスを [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) で適用します。座標はシェイプローカルです。新しいポイントは両方ともシェイプの中心にあり、左端から 100 ポイント、上端から 50 ポイントの位置です。セグメントインデックス 1 と 4 はそれぞれ上端と下端に配置され、これらのエッジを内側に引っ張ります。

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

この例では、[GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) を使用してゼロベースインデックス 2 のセグメントを削除し、ハート形の輪郭を変更します。変更したパスを [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) で適用すると、シェイプの輪郭が更新されます。

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

## **カスタムシェイプを作成する**

この例では、[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を使用して五角星を構築します。外側と内側の半径をそれぞれ 100 と 50 ポイントに交互に設定し、72 度のステップで 5 本の先端を均等に配置します。パスは [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) で閉じられ、[GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) を使用して矩形シェイプに適用し、元の輪郭を置き換えます。

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

## **複合カスタムシェイプを作成する**

この例では、シェイプの上部と下部の 3 分の 1 を表す 2 つの閉じた [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) オブジェクトを定義します。[GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) で両方のパスを適用すると、中央の 3 分の 1 に隙間がある単一の複合シェイプが作成されます。

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

## **曲線コーナー付きカスタムシェイプを作成する**

この例では、直線セグメントと [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) を組み合わせて、内側に曲がったコーナーを持つシェイプを作成します。各コーナーサイズはアークの幅と高さ（ポイント）を設定し、-90 度のスイープで反時計回りの 1/4 楕円を描きます。完成したパスは [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) で適用され、プレゼンテーションは PPTX 形式で保存されます。

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

## **シェイプジオメトリが閉じているか確認する方法**

以下のヘルパーは、すべての非空ジオメトリパスが閉じるセグメントで終わっているかをチェックします。[GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) を読み取り、最終セグメントの [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) と [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/) を比較します。空のパスがない場合は false を返します。このチェックは各パスの最終コマンドのみを対象とし、パス内のすべてのサブフィギュアは検査しません。例では矩形に対して `True` を出力します。

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

## **ジオメトリパスコマンドの検査**

[contour.pptx](contour.pptx) をダウンロードし、作業ディレクトリに配置します。最初のスライドの最初のシェイプは、上部が直線、次に 3 次ベジエ曲線、最後に直線で閉じるエッジを持ちます。[GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) を使用してパスを取得します。各パスについて、[GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) は描画順にセグメントを列挙します。各セグメントの [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) が、[PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/) の解釈方法を決定します。

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

シェイプはスライド上で (200, 100) ポイントに配置されています。報告された座標はシェイプローカルです。左上隅は (0, 0) で、X は右方向に増加し、Y は下方向に増加します。閉じるセグメントは追加座標なしで開始点に戻ります。

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **シェイプ要素の抽出と検査**

[GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) を使用して、パスポイントとポイントタイプを含む要素として既存シェイプを検査できます。返される各 [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) は、[path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) と [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) 配列を公開します。この表現は輪郭解析やカスタム描画ツールへのジオメトリ提供に便利です。

例ではプレゼンテーションを開き、最初のスライド上の最初のジオメトリシェイプを直接取得し、そのパスセグメントを出力します。直線と曲線セグメントの両方を持つシェイプが含まれるプレゼンテーションを使用すると、両方の出力が確認できます。グループ内は検索しません。

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
                point_type = types[i] & 0x07  # フラグを除いたセグメントタイプを保持します。
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # 制御点と終点の両方を消費します。

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

配列はインデックスで対応します：`points[i]` はポイント、`types[i]` はその役割を示します。タイプ `0` は図形の開始、タイプ `1` は前のポイントから現在のポイントへの直線を表します。3 次ベジエセグメントは前の終点から開始し、3 つの連続したタイプ `3` エントリ（2 つの制御点と新しい終点）を使用します。このループはこれら 3 エントリをまとめて消費し、終点が閉じているかをチェックします。

ポイントタイプにはフラグも含まれます。`0x07` マスクでセグメントタイプを特定し、`0x80` を別途テストして閉じたサブパスを検出します。例として `129` (`0x81`) はサブパスを閉じる線の終点、`131` (`0x83`) はサブパスを閉じるベジエの終点を意味します。単に `1` や `3` と比較するとこれらのケースを見逃します。ダッシュ (`0x10`) やマーカー (`0x20`) などの他のフラグは基本セグメントタイプを変更しません。

**座標と変換。** ポイントはポイント単位（1/72 インチ）で測定され、X は右方向に、Y は下方向に増加します。グループ化されていないシェイプの場合、抽出された座標はすでにシェイプの [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) と [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) 位置を含み、現在の幅と高さを反映しています。たとえば、`(100, 200)` に配置されサイズが `120 × 80` の回転なし矩形は輪郭境界が `(100, 200)`‑`(220, 280)` となります。シェイプの位置を再度加算しないでください。X と Y を減算して、回転なしフレームに対する相対座標を取得します。

抽出されたポイントはシェイプの [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) や水平・垂直フリップを適用していません。表示された輪郭を再現するには、シェイプの中心を基点にこれらの変換を適用してください。グループ化されたシェイプの場合は、グループ座標マッピングと変換も考慮する必要があります。抽出されたポイントが最終的なスライド座標であると仮定したり、既に子フレームに反映されている平行移動やスケールを二度適用しないでください。

**検査と編集の違い。** 抽出された配列は輪郭を記述しますが、変更しても元のシェイプは更新されません。ポイント／タイプ配列が必要な解析や描画コードでこのアプローチを選択してください。シェイプのローカル座標系でジオメトリコマンドが必要な場合やジオメトリを編集したい場合は、[get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) を使用し、編集したパスは [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) または [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) で適用してください。

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしと輪郭はどうなりますか？**

スタイルはシェイプに残り、輪郭だけが変更されます。塗りつぶしと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリと共にカスタムシェイプを正しく回転させるにはどうすればよいですか？**

シェイプの [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) プロパティを使用してください。ジオメトリはシェイプの座標系にバインドされているため、シェイプと共に回転します。

**カスタムシェイプを画像に変換して「結果をロック」できますか？**

はい。必要な [slide](/slides/ja/python-net/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/python-net/create-shape-thumbnails/) 自体をラスタ形式でエクスポートすると、複雑なジオメトリの後続作業が容易になります。