---
title: Python を使用したプレゼンテーションの形状カスタマイズ
linktitle: カスタム形状
type: docs
weight: 20
url: /ja/python-net/custom-shape/
keywords: 
- カスタム形状
- 形状の追加
- 形状の作成
- 形状の変更
- 形状ジオメトリ
- ジオメトリパス
- パスポイント
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションで形状を作成およびカスタマイズします：ジオメトリパス、曲線コーナー、複合形状。"
---

## **概要**

正方形を考えてみましょう。PowerPoint で **Edit Points** を使うと、次のことができます：

* 正方形の角を内側または外側に移動する
* 角やポイントの曲率を調整する
* 正方形に新しいポイントを追加する
* ポイントを操作する

これらの操作は任意の形状に適用できます。**Edit Points** を使用すれば、既存の形状を変更したり、既存の形状から新しい形状を作成したりできます。

## **形状編集のヒント**

!["Edit Points" command](custom_shape_0.png)

PowerPoint の形状を **Edit Points** で編集する前に、形状に関する以下の点に留意してください：

* 形状（またはそのパス）は **閉じている** か **開いている** かのいずれかです。
* 閉じた形状には開始点や終了点がありません。開いた形状には始点と終点があります。
* すべての形状は、線分で接続された少なくとも 2 つのアンカーポイントを持ちます。
* 線分は直線または曲線のいずれかで、アンカーポイントがその性質を決定します。
* アンカーポイントは **コーナー**、**スムーズ**、または **ストレート** に分類されます：
  * **コーナー** ポイントは、2 本の直線セグメントが角度を持って交わる地点です。
  * **スムーズ** ポイントは 2 本のハンドルが共線で、隣接するセグメントが滑らかな曲線を形成します。この場合、両ハンドルはアンカーポイントから同じ距離にあります。
  * **ストレート** ポイントも 2 本の共線ハンドルを持ちますが、ハンドルの距離は同じである必要はありません。
* アンカーポイントを移動または編集して（セグメントの角度を変更して）形状の外観を変えることができます。

PowerPoint の形状を編集するには、Aspose.Slides が提供する [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスを使用します。

* [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスは、[GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) オブジェクトのジオメトリパスを表します。
* [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を取得するには、[GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) メソッドを使用します。
* 形状に [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を設定するには、*単一形状* 用に [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) を、*複合形状* 用に [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) を使用します。
* セグメントを追加するには、[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) のメソッドを使用します。
* ジオメトリパスの外観は、[GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) と [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) プロパティで制御します。
* 形状のジオメトリパスを配列として取得するには、[GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) プロパティを使用します。

## **単純な編集操作**

以下のメソッドは単純な編集操作に使用します。

**パスの末端に直線を追加**：

```py
line_to(point)
line_to(x, y)
```

**パス内の指定位置に直線を追加**：

```py    
line_to(point, index)
line_to(x, y, index)
```

**パスの末端に3次ベジェ曲線を追加**：

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**パス内の指定位置に3次ベジェ曲線を追加**：

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**パスの末端に2次ベジェ曲線を追加**：

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**パス内の指定位置に2次ベジェ曲線を追加**：

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**パスに円弧を付加**：

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**パス内の現在の図形を閉じる**：

```py
close_figure()
```

**次のポイントの位置を設定**：

```py
move_to(point)
move_to(x, y)
```

**指定インデックスのパスセグメントを削除**：

```py
remove_at(index)
```

## **形状にカスタムポイントを追加**

ここでは、ポイントの順序とセグメントタイプ（直線または曲線）を指定し、必要に応じてパスを閉じることで、正確なカスタムグラフィック（多角形、アイコン、吹き出し、ロゴなど）をスライド上に描画する方法を学びます。

1. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成し、[ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) を設定します。
2. 形状から [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスを取得します。
3. パス上部の 2 つのポイント間に新しいポイントを挿入します。
4. パス下部の 2 つのポイント間に新しいポイントを挿入します。
5. 更新したパスを形状に適用します。

以下の Python コードは、形状にカスタムポイントを追加する例です：

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

##  **形状からポイントを削除**

カスタム形状に不要なポイントが含まれていると、ジオメトリが複雑になったり描画結果に影響したりします。このセクションでは、形状のパスから特定のポイントを削除してアウトラインを簡素化し、よりクリーンで正確な結果を得る方法を示します。

1. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成し、[ShapeType.HEART](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) を設定します。
2. 形状から [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスを取得します。
3. パスからセグメントを削除します。
4. 更新したパスを形状に適用します。

以下の Python コードは、形状からポイントを削除する例です：

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

##  **カスタム形状の作成**

[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を定義し、直線・円弧・ベジエ曲線から構成してベクトル形状を作成します。このセクションでは、ゼロからジオメトリを組み立て、スライドに形状として追加する手順を示します。

1. 形状の座標点を計算します。
2. [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスのインスタンスを作成します。
3. パスにポイントを順に配置します。
4. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成します。
5. パスを形状に適用します。

以下の Python コードは、カスタム形状を作成する例です：

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

## **複合カスタム形状の作成**

複合カスタム形状を作成すると、複数のジオメトリパスを 1 つの再利用可能な形状にまとめることができます。パスを定義・統合して、標準の形状セットを超える複雑なビジュアルを構築します。

1. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成します。
2. 最初の [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスを作成します。
3. 2 番目の [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスを作成します。
4. 両方のパスを形状に適用します。

以下の Python コードは、複合カスタム形状を作成する例です：

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

## **曲線コーナー付きカスタム形状の作成**

このセクションでは、ジオメトリパスを使用して滑らかな曲線コーナーを持つカスタム形状を描画する方法を示します。直線セグメントと円弧を組み合わせて輪郭を形成し、完成した形状をスライドに追加します。

以下の Python コードは、曲線コーナー付きカスタム形状を作成する例です：

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

## **形状ジオメトリが閉じているかどうかの判定**

閉じた形状とは、すべての辺が連結して隙間のない単一の境界を形成している形状です。シンプルな幾何形状でも、複雑なカスタムアウトラインでも当てはまります。以下のコード例は、形状ジオメトリが閉じているかどうかをチェックする方法を示します：

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

**ジオメトリを置き換えた後、塗りつぶしや輪郭はどうなりますか？**

スタイルは形状に残り、輪郭だけが変更されます。塗りつぶしと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタム形状を正しく回転させる方法は？**

形状の [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/rotation/) プロパティを使用します。ジオメトリは形状の座標系にバインドされているため、形状と共に回転します。

**カスタム形状を画像に変換して「ロック」できますか？**

はい。必要な [スライド](/slides/ja/python-net/convert-powerpoint-to-png/) 領域または [形状](/slides/ja/python-net/create-shape-thumbnails/) 自体をラスタ形式でエクスポートすれば、重いジオメトリの後続作業が簡素化されます。