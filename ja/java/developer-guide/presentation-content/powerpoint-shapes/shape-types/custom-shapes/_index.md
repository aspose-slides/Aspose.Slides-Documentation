---
title: Javaでプレゼンテーションのシェイプをカスタマイズ
linktitle: カスタムシェイプ
type: docs
weight: 20
url: /ja/java/custom-shape/
keywords:
- カスタムシェイプ
- シェイプを追加
- シェイプを作成
- シェイプを変更
- シェイプジオメトリ
- ジオメトリパス
- パスポイント
- 編集ポイント
- ポイントを追加
- ポイントを削除
- 編集操作
- 曲線コーナー
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java用 Aspose.Slides で PowerPoint プレゼンテーションのシェイプを作成・カスタマイズ: ジオメトリパス、曲線コーナー、複合シェイプ。"
---

# 編集ポイントを使用してシェイプを変更する

正方形を考えてみましょう。PowerPoint で **編集ポイント** を使用すると、次のことができます

* 正方形の角を内側または外側に動かす
* 角または点の曲率を指定する
* 正方形に新しい点を追加する
* 正方形上の点を操作するなど

本質的に、これらの操作は任意のシェイプに対して実行できます。編集ポイントを使用すると、シェイプを変更したり、既存のシェイプから新しいシェイプを作成したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

編集ポイントを使用して PowerPoint のシェイプを編集し始める前に、シェイプに関して以下の点を考慮するとよいでしょう：

* シェイプ（またはそのパス）は閉じている場合と開いている場合があります。
* シェイプが閉じている場合、開始点や終了点がありません。シェイプが開いている場合、開始点と終了点があります。
* すべてのシェイプは、少なくとも 2 つのアンカーポイントが線でつながれた構造です。
* 線は直線または曲線のいずれかです。アンカーポイントが線の性質を決定します。
* アンカーポイントは、コーナーポイント、ストレートポイント、スムーズポイントとして存在します：
  * コーナーポイントは、2 本の直線が角度を持って結合する点です。
  * スムーズポイントは、2 本のハンドルが同一直線上にあり、線分が滑らかな曲線で結合する点です。この場合、すべてのハンドルはアンカーポイントから等距離に分離しています。
  * ストレートポイントは、2 本のハンドルが同一直線上にあり、線分が滑らかな曲線で結合する点です。この場合、ハンドルはアンカーポイントから等距離である必要はありません。
* アンカーポイントを移動または編集（線の角度が変わります）することで、シェイプの見た目を変更できます。

編集ポイントを使用して PowerPoint のシェイプを編集するには、**Aspose.Slides** が [**GeometryPath**](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) クラスと [**IGeometryPath**](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath) インターフェイスを提供します。

* A [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) インスタンスは、[IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape) オブジェクトのジオメトリパスを表します。
* `IGeometryShape` インスタンスから `GeometryPath` を取得するには、[IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#getGeometryPaths--) メソッドを使用できます。
* シェイプの `GeometryPath` を設定するには、次のメソッドを使用できます：*ソリッド シェイプ* 用には [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-)、*コンポジット シェイプ* 用には [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-)。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath) のメソッドを使用できます。
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) と [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#setFillMode-byte-) メソッドを使用して、ジオメトリパスの外観を設定できます。
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#getPathData--) メソッドを使用して、`GeometryShape` のジオメトリパスをパスセグメントの配列として取得できます。
* 追加のシェイプジオメトリカスタマイズオプションにアクセスするには、[GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) を [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) に変換できます。
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) と [graphicsPathToGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) メソッド（[ShapeUtil](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil) クラスから）を使用して、[GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) と [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) を相互に変換できます。

## **シンプルな編集操作**

この Java コードは次の方法を示します

**線を追加** パスの末尾に
``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```

**線を追加** パスの指定位置に:
``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```

**3次ベジェ曲線を追加** パスの末尾に:
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**3次ベジェ曲線を追加** パスの指定位置に:
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```

**2次ベジェ曲線を追加** パスの末尾に:
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```

**2次ベジェ曲線を追加** パスの指定位置に:
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```

**指定された円弧を追加** パスへ:
``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**現在の図形を閉じる** パス:
``` java
public void closeFigure();
```

**次の点の位置を設定**:
``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```

**指定インデックスのパスセグメントを削除**:
``` java
public void removeAt(int index);
```


## **シェイプにカスタムポイントを追加**

1. [GeometryShape] クラスのインスタンスを作成し、[ShapeType.Rectangle] タイプを設定します。
2. シェイプから [GeometryPath] クラスのインスタンスを取得します。
3. パス上の上部 2 点の間に新しい点を追加します。
4. パス上の下部 2 点の間に新しい点を追加します。
5. パスをシェイプに適用します。

この Java コードはシェイプにカスタムポイントを追加する方法を示します：
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

## **シェイプからポイントを削除**

1. [GeometryShape] クラスのインスタンスを作成し、[ShapeType.Heart] タイプを設定します。 
2. シェイプから [GeometryPath] クラスのインスタンスを取得します。
3. パスのセグメントを削除します。
4. パスをシェイプに適用します。

この Java コードはシェイプからポイントを削除する方法を示します：
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

##  **カスタムシェイプを作成**

1. シェイプのポイントを計算します。
2. [GeometryPath] クラスのインスタンスを作成します。 
3. ポイントでパスを埋めます。
4. [GeometryShape] クラスのインスタンスを作成します。 
5. パスをシェイプに適用します。

この Java はカスタムシェイプを作成する方法を示します：
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


## **複合カスタムシェイプを作成**

1. [GeometryShape] クラスのインスタンスを作成します。
2. 最初の [GeometryPath] クラスのインスタンスを作成します。
3. 二番目の [GeometryPath] クラスのインスタンスを作成します。
4. パスをシェイプに適用します。

この Java コードは、複合カスタムシェイプを作成する方法を示します：
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

## **曲線コーナー付きカスタムシェイプを作成**

この Java コードは、内向きの曲線コーナーを持つカスタムシェイプを作成する方法を示します；
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


## **シェイプジオメトリが閉じているか確認**

閉じたシェイプは、すべての辺が接続され、隙間のない単一の境界を形成したものとして定義されます。このようなシェイプは、単純な幾何形状または複雑なカスタム輪郭のいずれかです。次のコード例は、シェイプジオメトリが閉じているかどうかをチェックする方法を示します：
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


## **GeometryPath を java.awt.Shape に変換**

1. [GeometryShape] クラスのインスタンスを作成します。
2. [java.awt.Shape] クラスのインスタンスを作成します。
3. [ShapeUtil](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil) を使用して、[java.awt.Shape] インスタンスを [GeometryPath] インスタンスに変換します。
4. パスをシェイプに適用します。

この Java コードは、上記手順の実装であり、**GeometryPath** から **GraphicsPath** への変換プロセスを示します：
``` java
Presentation pres = new Presentation();
try {
    // 新しいシェイプを作成
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // シェイプのジオメトリパスを取得
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

    // 新しいジオメトリパスと元のジオメトリパスの組み合わせをシェイプに設定
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしとアウトラインはどうなりますか？**

スタイルはシェイプに残り、輪郭だけが変更されます。塗りつぶしとアウトラインは自動的に新しいジオメトリに適用されます。

**ジオメトリと共にカスタムシェイプを正しく回転させるにはどうすればよいですか？**

[setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) メソッドを使用します。ジオメトリはシェイプにバインドされているため、シェイプと共に回転します。

**カスタムシェイプを画像に変換して結果を「固定」できますか？**

はい。必要な [slide](/slides/ja/java/convert-powerpoint-to-png/) エリアまたは [shape](/slides/ja/java/create-shape-thumbnails/) 自体をラスタ形式でエクスポートできます。これにより、重いジオメトリの作業が容易になります。