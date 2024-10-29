---
title: カスタムシェイプ
type: docs
weight: 20
url: /ja/java/custom-shape/
keywords: "PowerPoint シェイプ, カスタムシェイプ, PowerPoint プレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaでPowerPointプレゼンテーションにカスタムシェイプを追加する"
---

# エディットポイントを使用してシェイプを変更する
正方形を考えてみましょう。PowerPointでは、**エディットポイント**を使用して

* 正方形の隅を内側または外側に移動する
* 隅やポイントの曲率を指定する
* 正方形に新しいポイントを追加する
* 正方形のポイントを操作する、など

本質的に、任意のシェイプに対して上記の操作を行うことができます。エディットポイントを使用することで、シェイプを変更したり、既存のシェイプから新しいシェイプを作成したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

エディットポイントを通じてPowerPointシェイプの編集を開始する前に、シェイプに関する次のポイントを考慮することができます：

* シェイプ（またはそのパス）は、閉じたものまたは開いたもののいずれかです。
* シェイプが閉じている場合、開始点または終了点がありません。シェイプが開いている場合、開始点と終了点があります。
* すべてのシェイプは、お互いに線で結ばれた少なくとも2つのアンカーポイントで構成されています。
* 線は直線または曲線です。アンカーポイントは線の性質を決定します。
* アンカーポイントは、コーナーポイント、直線ポイント、またはスムーズポイントとして存在します：
  * コーナーポイントは、2つの直線が角度で結合するポイントです。
  * スムーズポイントは、2つのハンドルが直線上にあり、線のセグメントが滑らかな曲線で結合するポイントです。この場合、すべてのハンドルはアンカーポイントから等距離に離れています。
  * 直線ポイントは、2つのハンドルが直線上にあり、その線の線セグメントが滑らかな曲線で結合するポイントです。この場合、ハンドルはアンカーポイントから等距離に離れている必要はありません。
* アンカーポイントを移動または編集すること（これにより線の角度が変わります）で、シェイプの見た目を変更できます。

PowerPointシェイプをエディットポイントを通じて編集するには、**Aspose.Slides**は[**GeometryPath**](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath)クラスと[**IGeometryPath**](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath)インターフェースを提供します。

* [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath)インスタンスは、[IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape)オブジェクトのジオメトリパスを表します。
* `IGeometryShape`インスタンスから`GeometryPath`を取得するには、[IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#getGeometryPaths--)メソッドを使用できます。
* シェイプの`GeometryPath`を設定するには、*固体シェイプ*には[IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-)を、*複合シェイプ*には[IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-)を使用できます。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath)の下のメソッドを使用します。
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#setStroke-boolean-)および[IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#setFillMode-byte-)メソッドを使用して、ジオメトリパスの外観を設定できます。
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#getPathData--)メソッドを使用して、`GeometryShape`のジオメトリパスをパスセグメントの配列として取得できます。
* 追加のシェイプジオメトリカスタマイズオプションにアクセスするには、[GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath)を[java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)に変換できます。
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-)および[graphicsPathToGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-)メソッド（[ShapeUtil](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil)クラスから）を使用して、[GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath)を[java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)に往復変換できます。

## **簡単な編集操作**

このJavaコードは、次の操作を示しています。

**パスの終わりに**ラインを追加する

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**パスの指定した位置に**ラインを追加する：

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**パスの終わりに**三次ベジェ曲線を追加する：

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**パスの指定した位置に**三次ベジェ曲線を追加する：

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**パスの終わりに**二次ベジェ曲線を追加する：

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**パスの指定した位置に**二次ベジェ曲線を追加する：

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**指定されたアークを**パスに追加する：

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**現在の図形を**パスの終わりに閉じる：

``` java
public void closeFigure();
```
**次のポイントの位置を設定する**：

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**指定したインデックスの**パスセグメントを削除する：

``` java
public void removeAt(int index);
```

## **シェイプにカスタムポイントを追加する**
1. [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape)クラスのインスタンスを作成し、[ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType)タイプを設定します。
2. シェイプから[GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath)クラスのインスタンスを取得します。
3. パスの2つの上部ポイントの間に新しいポイントを追加します。
4. パスの2つの下部ポイントの間に新しいポイントを追加します。
5. パスをシェイプに適用します。

このJavaコードは、シェイプにカスタムポイントを追加する方法を示します：

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

1. [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape)クラスのインスタンスを作成し、[ShapeType.Heart](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType)タイプを設定します。
2. シェイプから[GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath)クラスのインスタンスを取得します。
3. パスのセグメントを削除します。
4. パスをシェイプに適用します。

このJavaコードは、シェイプからポイントを削除する方法を示します：

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
2. [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath)クラスのインスタンスを作成します。
3. ポイントを使用してパスを埋めます。
4. [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape)クラスのインスタンスを作成します。
5. パスをシェイプに適用します。

このJavaコードは、カスタムシェイプを作成する方法を示します：

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

1. [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape)クラスのインスタンスを作成します。
2. [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath)クラスの最初のインスタンスを作成します。
3. [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath)クラスの2番目のインスタンスを作成します。
4. パスをシェイプに適用します。

このJavaコードは、複合カスタムシェイプを作成する方法を示します：

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

## **角が丸いカスタムシェイプを作成する**

このJavaコードは、角が丸いカスタムシェイプを作成する方法を示しています（内向き）：

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

## **GeometryPathをjava.awt.Shapeに変換する**

1. [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape)クラスのインスタンスを作成します。
2. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)クラスのインスタンスを作成します。
3. [ShapeUtil](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil)を使用して[java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)インスタンスを[GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath)インスタンスに変換します。
4. パスをシェイプに適用します。

このJavaコードは、上記のステップの実装であり、**GeometryPath**から**GraphicsPath**への変換プロセスを示します：

``` java
Presentation pres = new Presentation();
try {
    // 新しいシェイプを作成
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // シェイプのジオメトリパスを取得
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // テキストを持つ新しいグラフィックスパスを作成
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