---
title: カスタムシェイプ
type: docs
weight: 20
url: /ja/net/custom-shape/
keywords: 
- シェイプ
- カスタムシェイプ
- シェイプの作成
- 幾何学
- シェイプの幾何学
- 幾何学パス
- パスポイント
- 編集ポイント
- PowerPoint
- プレゼンテーション
- C#
- Aspose.Slides for .NET
description: "C# で PowerPoint プレゼンテーションにカスタムシェイプを追加します"
---

## 編集ポイントを使用してシェイプを変更する

正方形を考えてみましょう。PowerPoint では、**編集ポイント**を使用して

* 正方形のコーナーを内側または外側に移動できます
* コーナーまたはポイントの曲率を指定できます
* 正方形に新しいポイントを追加できます
* 正方形のポイントを操作できます など。

基本的に、記述されたタスクは任意のシェイプに対して実行できます。編集ポイントを使用すると、既存のシェイプからシェイプを変更したり、新しいシェイプを作成したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

PowerPoint のシェイプを編集ポイントを通じて編集する前に、シェイプについて考慮すべき点は次のとおりです。

* シェイプ（またはそのパス）は、閉じたものと開いたものがあります。
* すべてのシェイプは、互いに線でつながれた少なくとも 2 つのアンカーポイントで構成されます。
* 線は直線または曲線のいずれかです。アンカーポイントは線の性質を決定します。
* アンカーポイントはコーナーポイント、直線ポイント、または滑らかなポイントとして存在します：
  * コーナーポイントは、2 本の直線が角度で交わるポイントです。
  * 滑らかなポイントは、2 つのハンドルが直線上にあり、線のセグメントが滑らかな曲線でつながるポイントです。この場合、すべてのハンドルはアンカーポイントから等距離に離れています。
  * 直線ポイントは、2 つのハンドルが直線上にあり、その線のセグメントが滑らかな曲線でつながるポイントです。この場合、ハンドルはアンカーポイントから等距離に離れている必要はありません。
* アンカーポイントを移動または編集することで（線の角度が変更され）、シェイプの見た目を変更できます。

PowerPoint のシェイプを編集ポイントを通じて編集するために、**Aspose.Slides** は [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) クラスと [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) インターフェースを提供します。

* [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) インスタンスは [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape) オブジェクトの幾何学パスを表します。
* `IGeometryShape` インスタンスから `GeometryPath` を取得するには、[IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths) メソッドを使用できます。
* シェイプの `GeometryPath` を設定するには、*実体シェイプ* 用の [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) メソッドと、*複合シェイプ* 用の [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) メソッドを使用できます。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) の下のメソッドを使用できます。
* [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) および [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode) プロパティを使用して、幾何学パスの外観を設定できます。
* [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata) プロパティを使用して、`GeometryShape` の幾何学パスをパスセグメントの配列として取得できます。
* 追加のシェイプ幾何学カスタマイズオプションにアクセスするには、[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) を [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) に変換できます。
* [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) および [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) メソッド（[ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil) クラスから）を使用して、[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) と [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) を相互に変換します。

## **シンプルな編集操作**

この C# コードは、以下の操作を示しています。

**パスの終わりに**ラインを追加する：

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**指定した位置に**ラインを追加する：

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**パスの終わりに**キュービックベジェ曲線を追加する：

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**指定した位置に**キュービックベジェ曲線を追加する：

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**パスの終わりに**二次ベジェ曲線を追加する：

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**指定した位置に**二次ベジェ曲線を追加する：

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**指定された弧を**パスに追加する：

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**パスの現在のフィギュアを**閉じる：

``` csharp
void CloseFigure();
```
**次のポイントの位置を**設定する：

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**指定したインデックスの**パスセグメントを削除する：

``` csharp
void RemoveAt(int index);
```

## **シェイプにカスタムポイントを追加する**

1. [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) クラスのインスタンスを作成し、[ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype) タイプを設定します。
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) クラスのインスタンスを取得します。
3. パス上の2つの上ポイントの間に新しいポイントを追加します。
4. パス上の2つの下ポイントの間に新しいポイントを追加します。
5. パスをシェイプに適用します。

この C# コードは、シェイプにカスタムポイントを追加する方法を示しています：

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![example1_image](custom_shape_1.png)

##  **シェイプからポイントを削除する**

1. [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) クラスのインスタンスを作成し、[ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype) タイプを設定します。
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) クラスのインスタンスを取得します。
3. パスのセグメントを削除します。
4. パスをシェイプに適用します。

この C# コードは、シェイプからポイントを削除する方法を示しています：

``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```
![example2_image](custom_shape_2.png)

##  **カスタムシェイプを作成する**

1. シェイプのポイントを計算します。
2. [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) クラスのインスタンスを作成します。
3. ポイントでパスを埋めます。
4. [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) クラスのインスタンスを作成します。
5. パスをシェイプに適用します。

この C# コードは、カスタムシェイプを作成する方法を示しています：

``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```
![example3_image](custom_shape_3.png)

## **複合カスタムシェイプを作成する**

1. [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) クラスのインスタンスを作成します。
2. [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) クラスの最初のインスタンスを作成します。
3. [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) クラスの2番目のインスタンスを作成します。
4. パスをシェイプに適用します。

この C# コードは、複合カスタムシェイプを作成する方法を示しています：

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```
![example4_image](custom_shape_4.png)

## **角が曲がったカスタムシェイプを作成する**

この C# コードは、角が内向きに曲がったカスタムシェイプを作成する方法を示しています：

```csharp
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **シェイプの幾何学が閉じているかどうかを確認する**

PowerPoint プレゼンテーション内のシェイプが閉じているかどうかを確認することは、スライド上のオブジェクトの正しい表示と編集にとって重要です。閉じたシェイプは、すべての辺が接続されて、隙間のない単一の境界を形成するものとして定義されます。このようなシェイプは、単純な幾何学的形状または複雑なカスタムアウトラインである可能性があります。

シェイプの閉じ具合は、色やグラデーションでの塗りつぶし、エフェクトや変換の適用、他のスライド要素との適切な相互作用を保証するためにさまざまな操作を実行する上で重要です。

シェイプの幾何学が閉じているかどうかを確認するには、次の手順を実行します。
1. シェイプの幾何学にアクセスします。
2. シェイプ内の幾何学パスを列挙します。
    2.1. 次のパスの最終セグメントを取得します。
    2.2. 最終セグメントが `CLOSE` コマンドであるかどうかを確認します。

以下のコード例は、この手順を示しています：

```cs
if (shape is GeometryShape geometryShape)
{
    for (int i = 0; i < geometryShape.GetGeometryPaths().Length; i++)
    {
        IGeometryPath path = geometryShape.GetGeometryPaths()[i];

        if (path.PathData.Length == 0) continue;

        IPathSegment lastSegment = path.PathData[path.PathData.Length - 1];
        bool isClosed = lastSegment.PathCommand == PathCommandType.Close;
        
        Console.WriteLine($"Path {i} is closed: {isClosed}");
    }
}
```

## **GeometryPath を GraphicsPath (System.Drawing.Drawing2D) に変換する**

1. [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) クラスのインスタンスを作成します。
2. [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) 名前空間の [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) クラスのインスタンスを作成します。
3. [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil) を使用して、[GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) インスタンスを [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) インスタンスに変換します。
4. パスをシェイプに適用します。

この C# コードは、上記の手順の実装を示し、**GeometryPath** から **GraphicsPath** への変換プロセスを示します：

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("シェイプ内のテキスト", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```
![example5_image](custom_shape_5.png)