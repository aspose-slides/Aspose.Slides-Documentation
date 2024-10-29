---
title: カスタムシェイプ
type: docs
weight: 20
url: /ja/python-net/custom-shape/
keywords: "PowerPoint シェイプ, カスタムシェイプ, PowerPoint プレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "Python で PowerPoint プレゼンテーションにカスタムシェイプを追加する"
---

# エディットポイントを使用したシェイプの変更

四角形を考えてみましょう。PowerPoint では、**エディットポイント**を使用して、

* 四角形の角を内側または外側に移動する
* 角またはポイントの曲率を指定する
* 四角形に新しいポイントを追加する
* 四角形上のポイントを操作するなど

本質的に、説明されたタスクを任意のシェイプに対して実行できます。エディットポイントを使用すると、シェイプを変更したり、既存のシェイプから新しいシェイプを作成したりすることができます。

## シェイプ編集のヒント

![overview_image](custom_shape_0.png)

エディットポイントを通じて PowerPoint シェイプを編集し始める前に、シェイプに関する以下のポイントを考慮することをお勧めします。

* シェイプ（またはそのパス）は、閉じた形または開いた形のいずれかです。
* シェイプが閉じているときは、開始点や終了点がありません。シェイプが開いているときは、始まりと終わりがあります。
* すべてのシェイプは、互いに線でつながれた少なくとも 2 つのアンカーポイントで構成されています。
* 線は、直線または曲線のいずれかです。アンカーポイントが線の性質を決定します。
* アンカーポイントは、コーナーポイント、直ポイント、またはスムーズポイントとして存在します：
  * コーナーポイントは、2 つの直線が角度で接合されるポイントです。
  * スムーズポイントは、2 つのハンドルが直線上に存在し、その線のセグメントが滑らかな曲線で接合されるポイントです。この場合、すべてのハンドルはアンカーポイントから等しい距離だけ離れています。
  * 直ポイントは、2 つのハンドルが直線上に存在し、その線のセグメントが滑らかな曲線で接合されるポイントです。この場合、ハンドルはアンカーポイントから等しい距離だけ離れる必要はありません。
* アンカーポイントを移動または編集することで（これにより線の角度が変わります）、シェイプの見た目を変更できます。

エディットポイントを通じて PowerPoint シェイプを編集するには、**Aspose.Slides** は [**GeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスと [**IGeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) インターフェイスを提供します。

* [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスは、[IGeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) オブジェクトのジオメトリパスを表します。
* `IGeometryShape` インスタンスから `GeometryPath` を取得するには、[IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) メソッドを使用できます。
* シェイプに `GeometryPath` を設定するには、次のメソッドを使用できます：*固体シェイプ* のための [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) と *コンポジットシェイプ* のための [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/)。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) の下のメソッドを使用できます。
* [IGeometryPath.Stroke](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) と [IGeometryPath.FillMode](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) プロパティを使用して、ジオメトリパスの外観を設定できます。
* [IGeometryPath.PathData](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/properties/pathdata) プロパティを使用して、`GeometryShape` のジオメトリパスをパスセグメントの配列として取得できます。
* 追加のシェイプジオメトリカスタマイズオプションにアクセスするには、[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) を [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) に変換できます。
* `GeometryPath` と `GraphicsPath` を相互に変換するには、[ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/) クラスから `GeometryPathToGraphicsPath` と `GraphicsPathToGeometryPath` メソッドを使用します。

## **簡単な編集操作**

この Python コードは、次の操作を示します。

**パスの終わりに**線を追加する：

```py
line_to(point)
line_to(x, y)
```

**指定した位置に**線を追加する：

```py    
line_to(point, index)
line_to(x, y, index)
```

**パスの終わりに**3次ベジェ曲線を追加する：

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**指定した位置に**3次ベジェ曲線を追加する：

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**パスの終わりに**2次ベジェ曲線を追加する：

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**指定した位置に**2次ベジェ曲線を追加する：

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**指定されたアークを**パスに追加する：

```py
arc_to(width, height, startAngle, sweepAngle)
```

**パスの現在のフィギュアを**閉じる：

```py
close_figure()
```

**次のポイントの位置を設定する**：

```py
move_to(point)
move_to(x, y)
```

**指定されたインデックスの**パスセグメントを削除する：

```py
remove_at(index)
```

## シェイプにカスタムポイントを追加する
1. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成し、[ShapeType.Rectangle](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) を設定します。
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスのインスタンスを取得します。
3. パス上の 2 つの上のポイントの間に新しいポイントを追加します。
4. パス上の 2 つの下のポイントの間に新しいポイントを追加します。
5. パスをシェイプに適用します。

この Python コードは、シェイプにカスタムポイントを追加する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    geometryPath = shape.get_geometry_paths()[0]

    geometryPath.line_to(100, 50, 1)
    geometryPath.line_to(100, 50, 4)
    shape.set_geometry_path(geometryPath)
```

![example1_image](custom_shape_1.png)

## シェイプからポイントを削除する

1. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成し、[ShapeType.Heart](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) タイプを設定します。
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスのインスタンスを取得します。
3. パスのセグメントを削除します。
4. パスをシェイプに適用します。

この Python コードは、シェイプからポイントを削除する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)
    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## カスタムシェイプを作成する

1. シェイプのポイントを計算します。
2. [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスのインスタンスを作成します。
3. ポイントでパスを埋めます。
4. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成します。
5. パスをシェイプに適用します。

この Python コードは、カスタムシェイプを作成する方法を示しています：

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

starPath = slides.GeometryPath()
starPath.move_to(points[0])

for i in range(len(points)):
    starPath.line_to(points[i])

starPath.close_figure()

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(starPath)
```
![example3_image](custom_shape_3.png)

## コンポジットカスタムシェイプを作成する

1. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成します。
2. [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスの最初のインスタンスを作成します。
3. [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) クラスの 2 番目のインスタンスを作成します。
4. パスをシェイプに適用します。

この Python コードは、コンポジットカスタムシェイプを作成する方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometryPath0 = slides.GeometryPath()
    geometryPath0.move_to(0, 0)
    geometryPath0.line_to(shape.width, 0)
    geometryPath0.line_to(shape.width, shape.height/3)
    geometryPath0.line_to(0, shape.height / 3)
    geometryPath0.close_figure()

    geometryPath1 = slides.GeometryPath()
    geometryPath1.move_to(0, shape.height/3 * 2)
    geometryPath1.line_to(shape.width, shape.height / 3 * 2)
    geometryPath1.line_to(shape.width, shape.height)
    geometryPath1.line_to(0, shape.height)
    geometryPath1.close_figure()

    shape.set_geometry_paths([ geometryPath0, geometryPath1])
```
![example4_image](custom_shape_4.png)

## **カスタムシェイプを作成する（曲がったコーナー付き）**

この Python コードは、内側に曲がったコーナーを持つカスタムシェイプを作成する方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shapeX = 20
shapeY = 20
shapeWidth = 300
shapeHeight = 200

leftTopSize = 50
rightTopSize = 20
rightBottomSize = 40
leftBottomSize = 10

with slides.Presentation() as presentation:
    childShape = presentation.slides[0].shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shapeX, shapeY, shapeWidth, shapeHeight)

    geometryPath = slides.GeometryPath()

    point1 = draw.PointF(leftTopSize, 0)
    point2 = draw.PointF(shapeWidth - rightTopSize, 0)
    point3 = draw.PointF(shapeWidth, shapeHeight - rightBottomSize)
    point4 = draw.PointF(leftBottomSize, shapeHeight)
    point5 = draw.PointF(0, leftTopSize)

    geometryPath.move_to(point1)
    geometryPath.line_to(point2)
    geometryPath.arc_to(rightTopSize, rightTopSize, 180, -90)
    geometryPath.line_to(point3)
    geometryPath.arc_to(rightBottomSize, rightBottomSize, -90, -90)
    geometryPath.line_to(point4)
    geometryPath.arc_to(leftBottomSize, leftBottomSize, 0, -90)
    geometryPath.line_to(point5)
    geometryPath.arc_to(leftTopSize, leftTopSize, 90, -90)

    geometryPath.close_figure()

    childShape.set_geometry_path(geometryPath)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## GeometryPathをGraphicsPath（System.Drawing.Drawing2D）に変換する

1. [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) クラスのインスタンスを作成します。
2. [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) 名前空間の [GrpahicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) クラスのインスタンスを作成します。
3. [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/) を使用して [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) インスタンスを [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) インスタンスに変換します。
4. パスをシェイプに適用します。

この Python コードは、上記のステップの実装を示し、**GeometryPath** から **GraphicsPath** への変換プロセスを実演しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 100)

    originalPath = shape.get_geometry_paths()[0]
    originalPath.fill_mode = slides.PathFillModeType.NONE

    gPath = draw.drawing2d.GraphicsPath()

    gPath.add_string("Text in shape", draw.FontFamily("Arial"), 1, 40, draw.PointF(10, 10), draw.StringFormat.generic_default)

    textPath = slides.util.ShapeUtil.graphics_path_to_geometry_path(gPath)
    textPath.fill_mode = slides.PathFillModeType.NORMAL

    shape.set_geometry_paths([originalPath, textPath])
```
![example5_image](custom_shape_5.png)