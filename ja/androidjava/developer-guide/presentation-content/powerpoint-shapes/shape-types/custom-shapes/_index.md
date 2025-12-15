---
title: Android でプレゼンテーションの形状をカスタマイズ
linktitle: カスタム形状
type: docs
weight: 20
url: /ja/androidjava/custom-shape/
keywords:
- カスタム形状
- 形状の追加
- 形状の作成
- 形状の変更
- 形状ジオメトリ
- ジオメトリパス
- パス点
- 編集ポイント
- ポイントの追加
- ポイントの削除
- 編集操作
- 曲線コーナー
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides で PowerPoint プレゼンテーションの形状を作成・カスタマイズ: ジオメトリパス、曲線コーナー、複合形状。"
---

## **編集ポイントを使用して形状を変更する**
正方形を考えてみましょう。PowerPoint では **編集ポイント** を使用して

* 正方形の角を内側または外側に移動できる
* 角やポイントの曲率を指定できる
* 正方形に新しいポイントを追加できる
* 正方形上のポイントを操作できる、など

基本的に、任意の形状に対して上記の操作を行うことができます。編集ポイントを使用すると、形状を変更したり、既存の形状から新しい形状を作成したりできます。

## **形状編集のヒント**

![overview_image](custom_shape_0.png)

編集ポイントで PowerPoint の形状を編集し始める前に、形状に関して次の点を考慮してください。

* 形状（またはそのパス）は閉じているか開いているかのどちらかです。
* 形状が閉じている場合、開始点や終了点がありません。開いている場合は開始点と終了点があります。
* すべての形状は、少なくとも 2 つのアンカーポイントが線でつながって構成されます。
* 線は直線または曲線のいずれかです。アンカーポイントが線の性質を決定します。
* アンカーポイントはコーナーポイント、ストレートポイント、スムーズポイントのいずれかです:
  * コーナーポイントは、2 本の直線が角度を持って結合する点です。
  * スムーズポイントは、2 本のハンドルが一直線上にあり、線分が滑らかな曲線でつながる点です。この場合、すべてのハンドルはアンカーポイントから同じ距離だけ離れています。
  * ストレートポイントは、2 本のハンドルが一直線上にあり、線分が滑らかな曲線でつながる点です。この場合、ハンドルはアンカーポイントから等距離である必要はありません。
* アンカーポイントを移動または編集（線の角度が変わります）すると、形状の見た目を変更できます。

編集ポイントで PowerPoint の形状を編集するには、**Aspose.Slides** が [**GeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) クラスと [**IGeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath) インターフェイスを提供します。

* [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) インスタンスは、[IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape) オブジェクトのジオメトリパスを表します。
* `IGeometryShape` インスタンスから `GeometryPath` を取得するには、[IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) メソッドを使用します。
* 形状に `GeometryPath` を設定するには、*実体形状* 用に [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-)、*複合形状* 用に [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) を使用します。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath) にあるメソッドを使用します。
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) と [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) メソッドを使用して、ジオメトリパスの外観を設定できます。
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#getPathData--) メソッドで、`GeometryShape` のジオメトリパスをパスセグメントの配列として取得できます。
* 追加の形状ジオメトリ カスタマイズ オプションにアクセスするには、[GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) を [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) に変換します。
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) と [graphicsPathToGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) メソッド（[ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil) クラス）を使用して、[GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) と [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) を相互変換できます。

## **簡単な編集操作**

この Java コードは次の操作方法を示します

**パスの末尾に直線を追加する**
``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```

**パスの指定位置に直線を追加する:**
``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```

**パスの末尾に 3 次ベジェ曲線を追加する:**
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**パスの指定位置に 3 次ベジェ曲線を追加する:**
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```

**パスの末尾に 2 次ベジェ曲線を追加する:**
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```

**パスの指定位置に 2 次ベジェ曲線を追加する:**
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```

**パスに円弧を追加する:**
``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**パスの現在の図形を閉じる:**
``` java
public void closeFigure();
```

**次のポイントの位置を設定する:**
``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```

**指定インデックスのパスセグメントを削除する:**
``` java
public void removeAt(int index);
```


## **形状にカスタムポイントを追加する**
1. [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) クラスのインスタンスを作成し、[ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType) タイプを設定します。
2. 形状から [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) クラスのインスタンスを取得します。
3. パス上の上部 2 点の間に新しいポイントを追加します。
4. パス上の下部 2 点の間に新しいポイントを追加します。
5. パスを形状に適用します。

この Java コードは形状にカスタムポイントを追加する方法を示します:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```

![example1_image](custom_shape_1.png)

## **形状からポイントを削除する**

1. [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) クラスのインスタンスを作成し、[ShapeType.Heart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType) タイプを設定します。
2. 形状から [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) クラスのインスタンスを取得します。
3. パスのセグメントを削除します。
4. パスを形状に適用します。

この Java コードは形状からポイントを削除する方法を示します:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```

![example2_image](custom_shape_2.png)

## **カスタム形状を作成する**

1. 形状のポイントを計算します。
2. [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) クラスのインスタンスを作成します。
3. パスにポイントを設定します。
4. [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) クラスのインスタンスを作成します。
5. パスを形状に適用します。

この Java はカスタム形状を作成する方法を示します:
``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}
```

![example3_image](custom_shape_3.png)


## **複合カスタム形状を作成する**

  1. [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) クラスのインスタンスを作成します。
  2. 最初の [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) クラスのインスタンスを作成します。
  3. 2 番目の [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) クラスのインスタンスを作成します。
  4. パスを形状に適用します。

この Java コードは複合カスタム形状の作成方法を示します:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```

![example4_image](custom_shape_4.png)

## **曲線コーナー付きカスタム形状を作成する**

この Java コードは曲線コーナー（内側）付きのカスタム形状を作成する方法を示します:
```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.closeFigure();

    childShape.setGeometryPath(geometryPath);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```


## **形状ジオメトリが閉じているか確認する**

閉じた形状は、すべての側面が接続され、隙間のない単一の境界を形成するものとして定義されます。その形状は単純な幾何形状でも、複雑なカスタム輪郭でもかまいません。以下のコード例は、形状ジオメトリが閉じているかどうかを確認する方法を示します:
```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```


## **GeometryPath を java.awt.Shape に変換する** 

1. [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) クラスのインスタンスを作成します。
2. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) クラスのインスタンスを作成します。
3. [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil) を使用して、[java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) インスタンスを [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) インスタンスに変換します。
4. パスを形状に適用します。

この Java コードは、上記手順の実装例で、**GeometryPath** から **GraphicsPath** への変換プロセスを示しています:
``` java
Presentation pres = new Presentation();
try {
    // 新しい形状を作成
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // 形状のジオメトリパスを取得
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // テキスト付きの新しいグラフィックパスを作成
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // グラフィックパスをジオメトリパスに変換
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // 新しいジオメトリパスと元のジオメトリパスの組み合わせを形状に設定
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしと輪郭はどうなりますか？**

スタイルは形状に残り、輪郭だけが変更されます。塗りつぶしと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタム形状を正しく回転させるにはどうすればよいですか？**

形状の [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) メソッドを使用します。ジオメトリは形状にバインドされているため、形状とともに回転します。

**カスタム形状を画像に変換して「ロック」できますか？**

はい。必要な [slide](/slides/ja/androidjava/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/androidjava/create-shape-thumbnails/) 自体をラスタ形式でエクスポートすると、重いジオメトリの後続作業が簡素化されます。