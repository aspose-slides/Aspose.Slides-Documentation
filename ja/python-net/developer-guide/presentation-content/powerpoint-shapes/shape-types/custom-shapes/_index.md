---
title: Python でプレゼンテーションのシェイプをカスタマイズする
linktitle: カスタムシェイプ
type: docs
weight: 20
url: /ja/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/custom-shapes/
keywords: 
- カスタムシェイプ
- シェイプを追加
- シェイプを作成
- シェイプを変更
- シェイプのジオメトリ
- ジオメトリパス
- パスのポイント
- ポイントを編集
- ポイントを追加
- ポイントを削除
- 編集操作
- 曲線コーナー
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のプレゼンテーションでシェイプを作成およびカスタマイズします：ジオメトリパス、曲線コーナー、複合シェイプ。"
---

## **概要**

正方形を考えてみましょう。PowerPoint で **Edit Points** を使用すると、次のことができます：

* 正方形の角を内側または外側に移動する
* 角やポイントの曲率を調整する
* 正方形に新しいポイントを追加する
* ポイントを操作する

これらの操作は任意のシェイプに適用できます。**Edit Points** を使用すると、シェイプを変更したり、既存のシェイプから新しいシェイプを作成したりできます。

## **シェイプ編集のヒント**

!["Edit Points" command](custom_shape_0.png)

PowerPoint のシェイプを **Edit Points** で編集し始める前に、シェイプに関する次の注意点をご確認ください：

* シェイプ（またはそのパス）は **閉じている**（closed）か **開いている**（open）場合があります。
* 閉じたシェイプには開始点や終了点がなく、開いたシェイプには開始点と終了点があります。
* すべてのシェイプは、少なくとも 2 つのアンカーポイントが線分で接続されています。
* セグメントは直線または曲線のいずれかで、アンカーポイントがセグメントの性質を決定します。
* アンカーポイントは **corner**、**smooth**、**straight** のいずれかです：
  * **corner** ポイントは、2 本の直線セグメントが角度で交わる点です。
  * **smooth** ポイントは、2 本のハンドルが同一直線上にあり、隣接するセグメントが滑らかな曲線を形成します。この場合、両ハンドルはアンカーポイントから同じ距離にあります。
  * **straight** ポイントも 2 本の同一直線上のハンドルを持ち、隣接セグメントは滑らかな曲線を形成しますが、ハンドルの距離はアンカーポイントから等しくある必要はありません。
* アンカーポイントを移動または編集（セグメント角度を変更）することで、シェイプの外観を変えることができます。

PowerPoint のシェイプを編集するには、Aspose.Slides が [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスを提供しています。

* [GeometryPath] インスタンスは、[GeometryShape] オブジェクトのジオメトリパスを表します。
* [GeometryShape] インスタンスから [GeometryPath] を取得するには、[GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) メソッドを使用します。
* シェイプに [GeometryPath] を設定するには、*単純シェイプ* には [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) を、*複合シェイプ* には [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) を使用します。
* セグメントを追加するには、[GeometryPath] のメソッドを使用します。
* [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) と [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) プロパティでジオメトリパスの外観を制御します。
* [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) プロパティでシェイプのジオメトリパスをパスセグメントの配列として取得します。

## **シンプルな編集操作**

次のメソッドはシンプルな編集操作に使用します。

**ラインを追加**（パスの末尾に）:

```py
line_to(point)
line_to(x, y)
```

**ラインを追加**（パス内の指定位置）:

```py    
line_to(point, index)
line_to(x, y, index)
```

**キュービックベジエ曲線を追加**（パスの末尾に）:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**キュービックベジエ曲線を追加**（パス内の指定位置）:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**二次ベジエ曲線を追加**（パスの末尾に）:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**二次ベジエ曲線を追加**（パス内の指定位置）:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**円弧を追加**（パスに）:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**現在の図形を閉じる**（パス内）:

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

## **シェイプにカスタムポイントを追加する**

ここでは、独自のポイントシーケンスを追加してフリーフォームシェイプを定義する方法を学びます。順序付けられたポイントとセグメントタイプ（直線または曲線）を指定し、必要に応じてパスを閉じることで、スライド上に多角形、アイコン、吹き出し、ロゴなどの正確なカスタムグラフィックを直接描画できます。

1. **[GeometryShape] クラスのインスタンスを作成し、[ShapeType.RECTANGLE] を設定します。**
2. **シェイプから [GeometryPath] インスタンスを取得します。**
3. **パス上の上部2点の間に新しいポイントを挿入します。**
4. **パス上の下部2点の間に新しいポイントを挿入します。**
5. **更新されたパスをシェイプに適用します。**

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

![カスタムポイント](custom_shape_1.png)

## **シェイプからポイントを削除する**

カスタムシェイプに不要なポイントが含まれていると、ジオメトリが複雑になったり描画結果に影響したりすることがあります。このセクションでは、シェイプのパスから特定のポイントを削除してアウトラインを簡素化し、よりクリーンで正確な結果を得る方法を示します。

1. **[GeometryShape] クラスのインスタンスを作成し、[ShapeType.HEART] タイプを設定します。**
2. **シェイプから [GeometryPath] インスタンスを取得します。**
3. **パスからセグメントを削除します。**
4. **更新されたパスをシェイプに適用します。**

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

![ポイントを削除した画像](custom_shape_2.png)

## **カスタムシェイプを作成する**

線、円弧、ベジエ曲線で構成された [GeometryPath] を定義して、オリジナルのベクターシェイプを作成します。このセクションでは、ゼロからカスタムジオメトリを構築し、スライドにシェイプとして追加する方法を示します。

1. **シェイプのポイントを計算します。**
2. **[GeometryPath] クラスのインスタンスを作成します。**
3. **パスにポイントを設定します。**
4. **[GeometryShape] クラスのインスタンスを作成します。**
5. **パスをシェイプに適用します。**

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

![カスタムシェイプ](custom_shape_3.png)

## **複合カスタムシェイプを作成する**

複合カスタムシェイプを作成すると、複数のジオメトリパスを 1 つの再利用可能なシェイプに結合できます。これらのパスを定義・統合して、標準シェイプセットを超える複雑なビジュアルを構築します。

1. **[GeometryShape] クラスのインスタンスを作成します。**
2. **[GeometryPath] クラスの最初のインスタンスを作成します。**
3. **[GeometryPath] クラスの2番目のインスタンスを作成します。**
4. **両方のパスをシェイプに適用します。**

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

![複合シェイプ](custom_shape_4.png)

## **曲線コーナー付きカスタムシェイプを作成する**

このセクションでは、ジオメトリパスを使用して滑らかな曲線コーナーを持つカスタムシェイプを描画する方法を示します。直線セグメントと円弧を組み合わせてアウトラインを作成し、完成したシェイプをスライドに追加します。

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

![曲線コーナー](custom_shape_6.png)

## **シェイプのジオメトリが閉じているか判定する**

閉じたシェイプとは、すべての辺が連続してつながり、隙間のない単一の境界を形成しているものを指します。このようなシェイプは、単純な幾何形状でも複雑なカスタム輪郭でも構いません。以下のコード例は、シェイプのジオメトリが閉じているかどうかを確認する方法を示します。

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

スタイルはシェイプに残り、輪郭だけが変更されます。塗りつぶしと輪郭は自動的に新しいジオメトリに適用されます。

**ジオメトリとともにカスタムシェイプを正しく回転させるには？**

シェイプの [rotation] プロパティを使用します。ジオメトリはシェイプにバインドされているため、シェイプと一緒に回転します。

**カスタムシェイプを画像に変換して結果を「ロック」できますか？**

はい。必要な [スライド](/slides/ja/python-net/convert-powerpoint-to-png/) の領域または [シェイプ](/slides/ja/python-net/create-shape-thumbnails/) 自体をラスタ形式でエクスポートできます。これにより、重いジオメトリの処理が簡略化されます。