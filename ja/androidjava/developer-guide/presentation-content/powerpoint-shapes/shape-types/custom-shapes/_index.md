---
title: カスタムシェイプ
type: docs
weight: 20
url: /androidjava/custom-shape/
keywords: "PowerPoint シェイプ, カスタムシェイプ, PowerPoint プレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "Java で PowerPoint プレゼンテーションにカスタムシェイプを追加する"
---

# 編集ポイントを使ってシェイプを変更する
正方形を考えてみましょう。PowerPoint では、**編集ポイント**を使用して 

* 正方形の角を内側または外側に移動できます
* 角またはポイントの曲率を指定できます
* 正方形に新しいポイントを追加できます
* 正方形のポイントを操作できます など 

基本的に、記載された作業はどのシェイプにも実行できます。編集ポイントを使用すると、シェイプを変更したり、既存のシェイプから新しいシェイプを作成したりできます。 

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

編集ポイントを介して PowerPoint シェイプの編集を開始する前に、シェイプに関して考慮すべき点は次のとおりです：

* シェイプ（またはそのパス）は、閉じた状態か開いた状態のいずれかになります。
* シェイプが閉じている場合、開始点または終了点がありません。シェイプが開いている場合、始まりと終わりがあります。 
* すべてのシェイプは、少なくとも 2 つのアンカーポイントで構成され、それらは線で接続されています。
* 線は直線または曲線のいずれかです。アンカーポイントは線の性質を決定します。 
* アンカーポイントには、角ポイント、直線ポイント、またはスムースポイントがあります：
  * 角ポイントとは、2 つの直線が角度で交わるポイントです。 
  * スムースポイントとは、2 つのハンドルが一直線上にあり、線のセグメントがスムースカーブで結合するポイントです。この場合、すべてのハンドルはアンカーポイントから等距離で離れています。 
  * 直線ポイントとは、2 つのハンドルが一直線上にあり、その線のセグメントがスムースカーブで結合するポイントです。この場合、ハンドルはアンカーポイントから等距離で離れている必要はありません。 
* アンカーポイントを移動または編集すると（これは線の角度を変更します）、シェイプの見た目を変更できます。 

編集ポイントを介して PowerPoint のシェイプを編集するために、**Aspose.Slides** は [**GeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) クラスと [**IGeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath) インターフェイスを提供します。

* [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) インスタンスは [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape) オブジェクトのジオメトリパスを表します。
* `IGeometryShape` インスタンスから `GeometryPath` を取得するには、[IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) メソッドを使用できます。
* シェイプの `GeometryPath` を設定するには、*固体シェイプ* に対しては [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) メソッドを、*複合シェイプ* に対しては [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) メソッドを使用できます。
* セグメントを追加するには [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath) の下のメソッドを使用できます。
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) と [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) メソッドを使用することで、ジオメトリパスの外観を設定できます。
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#getPathData--) メソッドを使用して、`GeometryShape` のジオメトリパスをパスセグメントの配列として取得できます。
* 追加のシェイプジオメトリカスタマイズオプションにアクセスするには、[GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) を [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) に変換できます。
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) および [graphicsPathToGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) メソッド（[ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil) クラスから）を使用して、[GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) を [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) に相互変換できます。

## **シンプルな編集操作**

この Java コードは、あなたがどのようにして

**パスの終わりに**ラインを追加するかを示します

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**指定された位置の**パスにラインを追加します：

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**パスの終わりに**キュービックベジェ曲線を追加します：

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**指定された位置の**パスにキュービックベジェ曲線を追加します：

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**パスの終わりに**二次ベジェ曲線を追加します：

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**指定された位置の**パスに二次ベジェ曲線を追加します：

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**指定されたアークを**パスに追加します：

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**現在のフィギュアを**パスで閉じます：

``` java
public void closeFigure();
```
**次のポイントの位置を設定します**：

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**指定されたインデックスの**パスセグメントを削除します：

``` java
public void removeAt(int index);
```

## **シェイプにカスタムポイントを追加する**
1. [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) クラスのインスタンスを作成し、[ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType) タイプを設定します。
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) クラスのインスタンスを取得します。
3. パスの上部の 2 つのポイントの間に新しいポイントを追加します。
4. パスの下部の 2 つのポイントの間に新しいポイントを追加します。
5. パスをシェイプに適用します。

この Java コードは、シェイプにカスタムポイントを追加する方法を示しています：

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

##  シェイプからポイントを削除する

1. [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) クラスのインスタンスを作成し、[ShapeType.Heart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType) タイプを設定します。
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) クラスのインスタンスを取得します。
3. パスのセグメントを削除します。
4. パスをシェイプに適用します。

この Java コードは、シェイプからポイントを削除する方法を示しています：

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

##  **カスタムシェイプを作成する**

1. シェイプのポイントを計算します。
2. [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) クラスのインスタンスを作成します。
3. ポイントでパスを塗りつぶします。
4. [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) クラスのインスタンスを作成します。
5. パスをシェイプに適用します。

この Java コードは、カスタムシェイプを作成する方法を示しています：

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


## **複合カスタムシェイプを作成する**

  1. [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) クラスのインスタンスを作成します。
  2. [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) クラスの最初のインスタンスを作成します。
  3. [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) クラスの 2 番目のインスタンスを作成します。
  4. パスをシェイプに適用します。

この Java コードは、複合カスタムシェイプを作成する方法を示しています：

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

## **曲がった角を持つカスタムシェイプを作成する**

この Java コードは、内側に曲がった角を持つカスタムシェイプを作成する方法を示しています；

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

## **GeometryPath を java.awt.Shape に変換する** 

1. [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) クラスのインスタンスを作成します。
2. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) クラスのインスタンスを作成します。
3. [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil) を使用して、[java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) インスタンスを [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) インスタンスに変換します。
4. パスをシェイプに適用します。

この Java コードは、上記のステップの実装であり、**GeometryPath** から **GraphicsPath** への変換プロセスを示しています：

``` java
Presentation pres = new Presentation();
try {
    // 新しいシェイプを作成
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // シェイプのジオメトリパスを取得する
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // テキスト付きの新しいグラフィックスパスを作成
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "シェイプ内のテキスト";
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

    // グラフィックスパスをジオメトリパスに変換
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // 新しいジオメトリパスと元のジオメトリパスの組み合わせをシェイプに設定
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)