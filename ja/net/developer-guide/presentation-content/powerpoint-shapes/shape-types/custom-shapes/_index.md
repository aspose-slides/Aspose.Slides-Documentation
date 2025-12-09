---
title: PowerPoint プレゼンテーションのシェイプを .NET でカスタマイズ
linktitle: カスタムシェイプ
type: docs
weight: 20
url: /ja/net/custom-shape/
keywords:
- カスタムシェイプ
- シェイプの追加
- シェイプの作成
- シェイプの変更
- シェイプジオメトリ
- ジオメトリパス
- パスのポイント
- 編集ポイント
- ポイントの追加
- ポイントの削除
- 編集操作
- 曲線コーナー
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーション内のシェイプを作成およびカスタマイズします：ジオメトリパス、曲線コーナー、複合シェイプ。"
---

## **編集ポイントを使用してシェイプを変更する**

正方形を考えてみてください。PowerPoint では、**編集ポイント**を使用して、以下が可能です

* 正方形の角を内側または外側に移動する
* 角や点の曲率を指定する
* 正方形に新しい点を追加する
* 正方形上の点を操作するなど

本質的に、これらの操作は任意のシェイプで実行できます。編集ポイントを使うことで、シェイプを変更したり、既存のシェイプから新しいシェイプを作成したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

編集ポイントで PowerPoint のシェイプを編集する前に、シェイプに関して以下の点を考慮するとよいでしょう：

* シェイプ（またはそのパス）は閉じている場合と開いている場合があります。
* すべてのシェイプは、少なくとも 2 つのアンカーポイントが線でつながれた構成です。
* 線は直線または曲線のいずれかです。アンカーポイントが線の性質を決定します。
* アンカーポイントはコーナーポイント、ストレートポイント、スムーズポイントとして存在します：
  * コーナーポイントは、2 本の直線が角度を持って結合する点です。
  * スムーズポイントは、2 本のハンドルが一直線上にあり、線分が滑らかな曲線で接続する点です。この場合、すべてのハンドルはアンカーポイントから等距離に配置されます。
  * ストレートポイントは、2 本のハンドルが一直線上にあり、線分が滑らかな曲線で接続する点です。この場合、ハンドルはアンカーポイントから等距離である必要はありません。
* アンカーポイントを移動または編集（線の角度を変える）することで、シェイプの外観を変更できます。

編集ポイントで PowerPoint のシェイプを編集するには、**Aspose.Slides** が [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) クラスと [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) インターフェイスを提供します。

* [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) インスタンスは、[IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape) オブジェクトのジオメトリパスを表します。
* `IGeometryShape` インスタンスから `GeometryPath` を取得するには、[IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths) メソッドを使用できます。
* シェイプに `GeometryPath` を設定するには、以下のメソッドを使用します：ソリッドシェイプの場合は [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath)、コンポジットシェイプの場合は [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths)。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) の下にあるメソッドを使用できます。
* [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) と [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode) プロパティを使用して、ジオメトリパスの外観を設定できます。
* [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata) プロパティを使用して、`GeometryShape` のジオメトリパスをパスセグメントの配列として取得できます。
* 追加のシェイプジオメトリカスタマイズオプションにアクセスするには、[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) を [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) に変換できます。
* [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) と [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) メソッド（[ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil) クラスから）を使用して、[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) と [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) を相互に変換できます。

## **シンプルな編集操作**

この C# コードは、以下の方法を示しています

**ラインを追加**してパスの末尾に配置する  
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```

**ラインを追加**してパスの指定位置に配置する：  
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```

**3 次ベジェ曲線を追加**してパスの末尾に配置する：  
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**3 次ベジェ曲線を追加**してパスの指定位置に配置する：  
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```

**2 次ベジェ曲線を追加**してパスの末尾に配置する：  
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```

**2 次ベジェ曲線を追加**してパスの指定位置に配置する：  
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```

**指定した円弧を追加**してパスに付加する：  
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**現在の図形を閉じる**パスの図形を閉じる：  
``` csharp
void CloseFigure();
```

**次のポイントの位置を設定**する：  
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```

**指定インデックスのパスセグメントを削除**する：  
``` csharp
void RemoveAt(int index);
```


## **シェイプにカスタムポイントを追加**

1. [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) クラスのインスタンスを作成し、[ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype) タイプを設定します。
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) クラスのインスタンスを取得します。
3. パス上の上部2点間に新しいポイントを追加します。
4. パス上の下部2点間に新しいポイントを追加します。
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

## **シェイプからポイントを削除**

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

## **カスタムシェイプを作成**

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

## **複合カスタムシェイプを作成**

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

## **曲線コーナー付きカスタムシェイプを作成**

この C# コードは、内向きの曲線コーナーを持つカスタムシェイプを作成する方法を示しています；  
```c#
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


## **シェイプジオメトリが閉じているか確認する**

閉じたシェイプは、すべての辺が接続され、隙間なく単一の境界を形成している形状として定義されます。シェイプは単純な幾何形状でも、複雑なカスタムアウトラインでもかまいません。以下のコード例は、シェイプジオメトリが閉じているかどうかを確認する方法を示しています：  
```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```


## **GeometryPath を GraphicsPath に変換 (System.Drawing.Drawing2D)**

1. [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) クラスのインスタンスを作成します。
2. [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) 名前空間の [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) クラスのインスタンスを作成します。
3. [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil) を使用して、[GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) インスタンスを [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) インスタンスに変換します。
4. パスをシェイプに適用します。

この C# コードは、上記手順の実装で、**GeometryPath** から **GraphicsPath** への変換プロセスを示しています：  
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```


![example5_image](custom_shape_5.png)

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしとアウトラインはどうなりますか？**  
スタイルはシェイプに残り、輪郭だけが変わります。塗りつぶしとアウトラインは新しいジオメトリに自動的に適用されます。

**ジオメトリを含むカスタムシェイプを正しく回転させるには？**  
シェイプの[rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/)プロパティを使用します。ジオメトリはシェイプに結び付いているため、シェイプとともに回転します。

**結果を「固定」するためにカスタムシェイプを画像に変換できますか？**  
はい。必要な[slide](/slides/ja/net/convert-powerpoint-to-png/)エリアまたは[shape](/slides/ja/net/create-shape-thumbnails/)自体をラスタ形式でエクスポートしてください。これにより、重いジオメトリの後続作業が容易になります。