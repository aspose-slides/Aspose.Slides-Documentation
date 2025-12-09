---
title: カスタムシェイプ
type: docs
weight: 20
url: /ja/nodejs-java/custom-shape/
keywords:
- シェイプ
- カスタムシェイプ
- シェイプ作成
- ジオメトリ
- シェイプジオメトリ
- ジオメトリパス
- パスポイント
- 編集ポイント
- PowerPoint
- プレゼンテーション
- JavaScript
- Aspose.Slides for Node.js via Java
description: "JavaScript で PowerPoint プレゼンテーションにカスタムシェイプを追加する"
---

## **編集ポイントを使用してシェイプを変更する**

正方形を考えてみましょう。PowerPoint で **編集ポイント** を使用すると、以下が可能です：

* 正方形の角を内側または外側に移動する
* 角やポイントの曲率を指定する
* 正方形に新しいポイントを追加する
* 正方形上のポイントを操作するなど

本質的に、これらの操作は任意のシェイプで実行できます。編集ポイントを使用すると、シェイプを変更したり、既存のシェイプから新しいシェイプを作成したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

編集ポイントで PowerPoint のシェイプを編集し始める前に、シェイプに関して次の点を考慮するとよいでしょう：

* シェイプ（またはそのパス）は閉じている場合と開いている場合があります。
* シェイプが閉じている場合、開始点や終了点がありません。開いている場合は、開始点と終了点があります。
* すべてのシェイプは、少なくとも 2 つのアンカーポイントが線で結ばれた構成です。
* 線は直線または曲線のいずれかです。アンカーポイントが線の性質を決定します。
* アンカーポイントはコーナーポイント、ストレートポイント、スムーズポイントとして存在します：
  * コーナーポイントは、2 本の直線が角度で結合する点です。
  * スムーズポイントは、2 つのハンドルが直線上にあり、線分が滑らかな曲線でつながる点です。この場合、すべてのハンドルはアンカーポイントから等距離に離れています。
  * ストレートポイントは、2 つのハンドルが直線上にあり、線分が滑らかな曲線でつながる点です。この場合、ハンドルはアンカーポイントから等距離である必要はありません。
* アンカーポイントを移動または編集（線の角度が変わります）することで、シェイプの外観を変更できます。

編集ポイントで PowerPoint のシェイプを編集するには、**Aspose.Slides** は [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) クラスと [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) クラスを提供します。

* 「[GeometryPath]」インスタンスは、[GeometryShape] オブジェクトのジオメトリパスを表します。
* `GeometryShape` インスタンスから `GeometryPath` を取得するには、[GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--) メソッドを使用できます。
* シェイプに `GeometryPath` を設定するには、次のメソッドを使用します：*ソリッド シェイプ* 用の [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) と *コンポジット シェイプ* 用の [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-)。
* セグメントを追加するには、[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) の下にあるメソッドを使用できます。
* [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) と [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) メソッドを使用して、ジオメトリパスの外観を設定できます。
* [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#getPathData--) メソッドを使用して、`GeometryShape` のジオメトリパスをパス セグメントの配列として取得できます。
* 追加のシェイプ ジオメトリ カスタマイズ オプションにアクセスするには、[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) を [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) に変換できます。
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) と [graphicsPathToGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) メソッド（[ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil) クラスから）を使用して、[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) と [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) を相互に変換できます。

## **簡単な編集操作**

この JavaScript コードは次の方法を示します

**直線を追加** パスの末尾に
```javascript
lineTo(point);
lineTo(x, y);
```

**指定位置に直線を追加** パス上の指定位置に:
```javascript
lineTo(point, index);
lineTo(x, y, index);
```

**キュービックベジェ曲線を追加** パスの末尾に:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**指定位置にキュービックベジェ曲線を追加** パス上の指定位置に:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**二次ベジェ曲線を追加** パスの末尾に:
```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```

**指定位置に二次ベジェ曲線を追加** パス上の指定位置に:
```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```

**指定された円弧を追加** パスに:
```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```

**現在の図形を閉じる** パスの:
```javascript
closeFigure();
```

**次のポイントの位置を設定**:
```javascript
moveTo(point);
moveTo(x, y);
```

**指定インデックスのパスセグメントを削除**:
```javascript
removeAt(index);
```


## **シェイプにカスタムポイントを追加**

1. [GeometryShape] クラスのインスタンスを作成し、[ShapeType.Rectangle] タイプを設定します。
2. シェイプから [GeometryPath] クラスのインスタンスを取得します。
3. パス上の上部2点の間に新しいポイントを追加します。
4. パス上の下部2点の間に新しいポイントを追加します。
5. パスをシェイプに適用します。

この JavaScript コードは、シェイプにカスタムポイントを追加する方法を示します。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example1_image](custom_shape_1.png)

## **シェイプからポイントを削除**

1. [GeometryShape] クラスのインスタンスを作成し、[ShapeType.Heart] タイプを設定します。
2. シェイプから [GeometryPath] クラスのインスタンスを取得します。
3. パスのセグメントを削除します。
4. パスをシェイプに適用します。

この JavaScript コードは、シェイプからポイントを削除する方法を示します。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example2_image](custom_shape_2.png)

## **カスタムシェイプを作成**

1. シェイプのポイントを計算します。
2. [GeometryPath] クラスのインスタンスを作成します。
3. ポイントでパスを埋めます。
4. [GeometryShape] クラスのインスタンスを作成します。
5. パスをシェイプに適用します。

この JavaScript は、カスタムシェイプを作成する方法を示します。
```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example3_image](custom_shape_3.png)


## **複合カスタムシェイプを作成**

1. [GeometryShape] クラスのインスタンスを作成します。
2. [GeometryPath] クラスの最初のインスタンスを作成します。
3. [GeometryPath] クラスの2番目のインスタンスを作成します。
4. パスをシェイプに適用します。

この JavaScript コードは、複合カスタムシェイプを作成する方法を示します。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example4_image](custom_shape_4.png)

## **曲線コーナー付きカスタムシェイプを作成**

この JavaScript コードは、曲線コーナー（内側）付きのカスタムシェイプを作成する方法を示します。
```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
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
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シェイプジオメトリが閉じているか判定**

閉じたシェイプは、すべての辺がつながり、隙間のない単一の境界を形成するものとして定義されます。そのようなシェイプは、単純な幾何形状でも複雑なカスタム輪郭でも構いません。次のコード例は、シェイプジオメトリが閉じているかどうかをチェックする方法を示します。
```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```


## **GeometryPath を java.awt.Shape に変換**

1. [GeometryShape] クラスのインスタンスを作成します。
2. [java.awt.Shape] クラスのインスタンスを作成します。
3. [ShapeUtil] を使用して、[java.awt.Shape] インスタンスを [GeometryPath] インスタンスに変換します。
4. パスをシェイプに適用します。

この JavaScript コードは、上記の手順を実装したもので、**GeometryPath** から **GraphicsPath** への変換プロセスを示します。
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 新しいシェイプを作成
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // シェイプのジオメトリパスを取得
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // テキスト付きの新しいグラフィックパスを作成
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // グラフィックパスをジオメトリパスに変換
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // 新しいジオメトリパスと元のジオメトリパスの組み合わせをシェイプに設定
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしと輪郭はどうなりますか？**

スタイルはシェイプに残り、輪郭だけが変わります。塗りつぶしと輪郭は自動的に新しいジオメトリに適用されます。

**ジオメトリとともにカスタムシェイプを正しく回転させるにはどうすればよいですか？**

シェイプの [setRotation] メソッドを使用します。ジオメトリはシェイプの座標系にバインドされているため、シェイプと共に回転します。

**結果を「固定」するためにカスタムシェイプを画像に変換できますか？**

はい。必要な [slide](/slides/ja/nodejs-java/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/nodejs-java/create-shape-thumbnails/) 自体をラスタ形式でエクスポートしてください。これにより、重いジオメトリの後続処理が簡素化されます。