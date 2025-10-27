---
title: Pythonでプレゼンテーションの図形をカスタマイズする
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションで図形を作成・カスタマイズします：ジオメトリパス、曲線コーナー、複合図形。"
---

## **概要**

正方形を考えてみましょう。PowerPoint で **Edit Points** を使用すると、次のことができます：

* 正方形の隅を内側または外側に移動する、  
* 隅やポイントの曲率を調整する、  
* 正方形に新しいポイントを追加する、  
* ポイントを操作する。

これらの操作は任意の図形に適用できます。**Edit Points** を使用すると、図形を変更したり、既存の図形から新しい図形を作成したりできます。

## **図形編集のヒント**

!["Edit Points" コマンド](custom_shape_0.png)

**Edit Points** を使用して PowerPoint の図形を編集する前に、図形に関する以下の注意点を確認してください：

* 図形（またはそのパス）は **closed**（閉じている）か **open**（開いている）にすることができます。  
* 閉じた図形には開始点や終了点がありません。開いた図形は開始点と終了点があります。  
* すべての図形は、直線セグメントで接続された少なくとも 2 つのアンカーポイントを持ちます。  
* セグメントは直線か曲線のいずれかで、アンカーポイントがセグメントの性質を決定します。  
* アンカーポイントは **corner**（コーナー）、**smooth**（スムーズ）、**straight**（ストレート）のいずれかです：  
  * **corner** ポイントは、2 本の直線セグメントが角度で交わる場所です。  
  * **smooth** ポイントは、2 本のハンドルが同一直線上にあり、隣接するセグメントが滑らかな曲線を形成します。この場合、2 つのハンドルはアンカーポイントから同じ距離にあります。  
  * **straight** ポイントも 2 本の同一直線上のハンドルを持ち、隣接するセグメントが滑らかな曲線を形成します。ただし、この場合ハンドルはアンカーポイントから同じ距離である必要はありません。  
* アンカーポイントを移動または編集して（セグメントの角度を変更し）図形の外観を変えることができます。

PowerPoint の図形を編集するには、Aspose.Slides が [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスを提供しています。

* [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) のインスタンスは、[GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) オブジェクトのジオメトリパスを表します。  
* [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) のインスタンスから [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を取得するには、[GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) メソッドを使用します。  
* 図形に [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を設定するには、*solid shapes* には [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) を、*composite shapes* には [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) を使用します。  
* セグメントを追加するには、[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) のメソッドを使用します。  
* [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) と [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) プロパティを使用して、ジオメトリパスの外観を制御します。  
* [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) プロパティを使用して、図形のジオメトリパスをパスセグメントの配列として取得します。

## **シンプルな編集操作**

以下のメソッドはシンプルな編集操作に使用します。

**パスの末尾に直線を追加**：

```py
line_to(point)
line_to(x, y)
```

**指定した位置に直線を追加**：

```py    
line_to(point, index)
line_to(x, y, index)
```

**パスの末尾に3次ベジェ曲線を追加**：

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**パスの指定位置に3次ベジェ曲線を追加**：

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**パスの末尾に2次ベジェ曲線を追加**：

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**パスの指定位置に2次ベジェ曲線を追加**：

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**パスに円弧を追加**：

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**パスの現在の図形を閉じる**：

```py
close_figure()
```

**次のポイントの位置を設定**：

```py
move_to(point)
move_to(x, y)
```

**指定したインデックスのパスセグメントを削除**：

```py
remove_at(index)
```

## **図形にカスタムポイントを追加**

ここでは、独自のポイントシーケンスを追加してフリーフォーム図形を定義する方法を学びます。順序付けられたポイントとセグメントタイプ（直線または曲線）を指定し、必要に応じてパスを閉じることで、スライド上に正確なカスタムグラフィック（多角形、アイコン、吹き出し、ロゴなど）を直接描画できます。

1. [GeometryShape] クラスのインスタンスを作成し、[ShapeType.RECTANGLE] を設定します。  
2. 図形から [GeometryPath] インスタンスを取得します。  
3. パス上の上部2点の間に新しいポイントを挿入します。  
4. パス上の下部2点の間に新しいポイントを挿入します。  
5. 更新されたパスを図形に適用します。

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

##  **図形からポイントを削除**

カスタム図形には、ジオメトリが複雑になったり描画に影響を与える不要なポイントが含まれることがあります。このセクションでは、図形のパスから特定のポイントを削除して輪郭をシンプルにし、よりクリーンで正確な結果を得る方法を示します。

1. [GeometryShape] クラスのインスタンスを作成し、[ShapeType.HEART] タイプを設定します。  
2. 図形から [GeometryPath] インスタンスを取得します。  
3. パスからセグメントを削除します。  
4. 更新されたパスを図形に適用します。

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

![ポイント削除](custom_shape_2.png)

##  **カスタム図形を作成**

[GeometryPath] を定義し、直線、円弧、ベジェ曲線で構成することで、オリジナルのベクター図形を作成します。このセクションでは、スクラッチからカスタムジオメトリを構築し、スライドに図形として追加する方法を示します。

1. 図形のポイントを計算します。  
2. [GeometryPath] クラスのインスタンスを作成します。  
3. パスにポイントを追加します。  
4. [GeometryShape] クラスのインスタンスを作成します。  
5. パスを図形に適用します。

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

![カスタム図形](custom_shape_3.png)

## **複合カスタム図形を作成**

複合カスタム図形を作成すると、複数のジオメトリパスを 1 つの再利用可能な図形に結合できます。これらのパスを定義・統合して、標準の図形セットを超える複雑なビジュアルを構築します。

1. [GeometryShape] クラスのインスタンスを作成します。  
2. [GeometryPath] クラスの最初のインスタンスを作成します。  
3. [GeometryPath] クラスの2番目のインスタンスを作成します。  
4. 両方のパスを図形に適用します。

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

![複合図形](custom_shape_4.png)

## **曲線コーナー付きカスタム図形を作成**

このセクションでは、ジオメトリパスを使用して滑らかな曲線コーナーを持つカスタム図形を描画する方法を示します。直線セグメントと円弧を組み合わせて輪郭を作成し、完成した図形をスライドに追加します。

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

## **図形のジオメトリが閉じているかどうかを判断する**

閉じた図形とは、すべての辺がつながり、隙間のない単一の境界を形成している形状を指します。このような図形は、単純な幾何形状でも複雑なカスタム輪郭でも構いません。以下のコード例は、図形のジオメトリが閉じているかどうかを確認する方法を示します。

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

## **よくある質問**

**ジオメトリを置き換えた後、塗りつぶしと輪郭はどうなりますか？**  
スタイルは図形に残り、輪郭だけが変わります。塗りつぶしと輪郭は自動的に新しいジオメトリに適用されます。

**ジオメトリとともにカスタム図形を正しく回転させるにはどうすればよいですか？**  
図形の [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/rotation/) プロパティを使用します。ジオメトリは図形にバインドされているため、図形とともに回転します。

**カスタム図形を画像に変換して結果を「ロック」できますか？**  
はい。対象のスライド領域または図形自体をラスタ形式にエクスポートすれば、重たいジオメトリの後続作業が簡素化されます。