---
title: Python でプレゼンテーションの図形をカスタマイズする
linktitle: カスタム図形
type: docs
weight: 20
url: /ja/python-net/custom-shape/
keywords:
- カスタム図形
- 図形の追加
- 図形の作成
- 図形の変更
- 図形ジオメトリ
- ジオメトリパス
- パスのポイント
- ポイントの編集
- ポイントの追加
- ポイントの削除
- 編集操作
- 曲線コーナー
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションで図形を作成およびカスタマイズします：ジオメトリパス、曲線コーナー、合成図形。"
---

## **概要**

正方形を考えてみましょう。PowerPoint で **Edit Points** を使用すると、次のことが可能です。

* 正方形の角を内側または外側に移動する
* 角やポイントの曲率を調整する
* 正方形に新しいポイントを追加する
* ポイントを操作する

これらの操作は任意の図形に適用できます。**Edit Points** を使えば、既存の図形を変更したり、既存の図形から新しい図形を作成したりできます。

## **図形編集のヒント**

!["Edit Points" コマンド](custom_shape_0.png)

PowerPoint の図形を **Edit Points** で編集し始める前に、図形に関する次の点に注意してください。

* 図形（またはそのパス）は **閉じた** ものと **開いた** ものがあります。
* 閉じた図形には開始点や終了点がありません。開いた図形には始点と終点があります。
* すべての図形は、少なくとも 2 つのアンカーポイントが直線セグメントで接続されています。
* セグメントは直線または曲線のいずれかで、アンカーポイントがその性質を決定します。
* アンカーポイントは **コーナー**、**スムーズ**、**ストレート** のいずれかです：
  * **コーナー** ポイントは 2 本の直線セグメントが角度を持って接続する場所です。
  * **スムーズ** ポイントは 2 本のハンドルが同一直線上にあり、隣接セグメントが滑らかな曲線を形成します。両ハンドルはアンカーポイントから同じ距離です。
  * **ストレート** ポイントも 2 本のハンドルが同一直線上にありますが、ハンドルの距離は同じである必要はありません。
* アンカーポイントを移動または編集（セグメントの角度を変える）すると、図形の外観を変更できます。

PowerPoint の図形を編集するには、Aspose.Slides が [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスを提供しています。

* [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスは、[GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) オブジェクトのジオメトリパスを表します。
* [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を取得するには、[GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) メソッドを使用します。
* 図形に [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を設定するには、*単一図形* は [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) を、*合成図形* は [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) を使用します。
* セグメントを追加するには、[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) の各種メソッドを使用します。
* [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) と [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) プロパティでジオメトリパスの外観を制御します。
* [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) プロパティで、図形のジオメトリパスをパスセグメントの配列として取得できます。

## **シンプルな編集操作**

以下のメソッドはシンプルな編集操作に使用します。

**パスの末尾に直線を追加**:

```py
line_to(point)
line_to(x, y)
```

**パス内の指定位置に直線を追加**:

```py
line_to(point, index)
line_to(x, y, index)
```

**パスの末尾に 3 次ベジエ曲線を追加**:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**パス内の指定位置に 3 次ベジエ曲線を追加**:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**パスの末尾に 2 次ベジエ曲線を追加**:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**パス内の指定位置に 2 次ベジエ曲線を追加**:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**パスに円弧を追加**:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**現在の図形を閉じる**:

```py
close_figure()
```

**次のポイントの位置を設定**:

```py
move_to(point)
move_to(x, y)
```

**指定インデックスのパスセグメントを削除**:

```py
remove_at(index)
```

## **図形にカスタムポイントを追加**

ここでは、ポイントのシーケンスを自分で定義してフリーフォーム図形を作成する方法を学びます。順序付きポイントとセグメントタイプ（直線または曲線）を指定し、必要に応じてパスを閉じることで、正確なカスタムグラフィック（多角形、アイコン、吹き出し、ロゴなど）をスライド上に描画できます。

1. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成し、[ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) を設定します。
2. 図形から [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスを取得します。
3. パス上の上部 2 点の間に新しいポイントを挿入します。
4. パス上の下部 2 点の間に新しいポイントを挿入します。
5. 更新したパスを図形に適用します。

以下の Python コードは、図形にカスタムポイントを追加する例です。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![Custom points](custom_shape_1.png)

## **図形からポイントを削除**

カスタム図形に不要なポイントが含まれていると、ジオメトリが複雑になったり描画に支障をきたすことがあります。このセクションでは、図形のパスから特定のポイントを削除し、輪郭をシンプルにしてより正確な結果を得る方法を示します。

1. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成し、[ShapeType.HEART](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) を設定します。
2. 図形から [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスを取得します。
3. パスからセグメントを削除します。
4. 更新したパスを図形に適用します。

以下の Python コードは、図形からポイントを削除する例です。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![Removed points](custom_shape_2.png)

## **カスタム図形を作成**

[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を定義し、直線・円弧・ベジエ曲線で構成して独自のベクター図形を作成します。このセクションでは、ゼロからジオメトリを構築し、スライドに図形を追加する手順を示します。

1. 図形のポイントを計算します。
2. [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスのインスタンスを作成します。
3. パスにポイントを順に追加します。
4. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成します。
5. パスを図形に適用します。

以下の Python コードは、カスタム図形を作成する例です。

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Custom shape](custom_shape_3.png)

## **合成カスタム図形を作成**

合成カスタム図形を作成すると、複数のジオメトリパスを単一の再利用可能な図形としてスライドに配置できます。パスを定義して結合することで、標準図形セットを超える複雑なビジュアルを構築できます。

1. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成します。
2. 最初の [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスを作成します。
3. 2 番目の [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスを作成します。
4. 両方のパスを図形に適用します。

以下の Python コードは、合成カスタム図形を作成する例です。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Composite shape](custom_shape_4.png)

## **曲線コーナー付きカスタム図形を作成**

このセクションでは、ジオメトリパスを使用して滑らかな曲線コーナーを持つカスタム図形を描く方法を示します。直線セグメントと円弧を組み合わせて輪郭を作成し、完成した図形をスライドに追加します。

以下の Python コードは、曲線コーナー付きカスタム図形を作成する例です。

```py
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

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![Curved corners](custom_shape_6.png)

## **図形ジオメトリが閉じているか判定する**

閉じた図形とは、すべての辺が連続して接続され、隙間のない単一の境界を形成しているものです。単純な幾何形状でも複雑なカスタム輪郭でも同様です。次のコード例は、図形ジオメトリが閉じているかどうかをチェックする方法を示します。

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしと輪郭はどうなりますか？**

スタイルは図形に残り、輪郭だけが変更されます。塗りつぶしと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタム図形を正しく回転させるにはどうすればよいですか？**

図形の [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/rotation/) プロパティを使用します。ジオメトリは図形の座標系にバインドされているため、図形とともに回転します。

**カスタム図形を画像に変換して「ロック」できますか？**

はい。対象の [slide](/slides/ja/python-net/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/python-net/create-shape-thumbnails/) 自体をラスタ形式でエクスポートすると、重いジオメトリの後続作業が簡素化されます。