---
title: カスタムシェイプ
type: docs
weight: 20
url: /php-java/custom-shape/
keywords: "PowerPoint シェイプ, カスタムシェイプ, PowerPoint プレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPoint プレゼンテーションにカスタムシェイプを追加"
---

# 編集ポイントを使用してシェイプを変更する
四角形を考えてみてください。PowerPoint では、**編集ポイント**を使用して、 

* 四角形の角を内側または外側に移動できます
* 角またはポイントの曲率を指定できます
* 四角形に新しいポイントを追加できます
* 四角形のポイントを操作できます、など。 

本質的に、記述されたタスクを任意のシェイプに対して実行できます。編集ポイントを使用して、既存のシェイプからシェイプを変更したり、新しいシェイプを作成したりできます。 

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

編集ポイントを介して PowerPoint シェイプの編集を開始する前に、シェイプに関して考慮すべきポイントがあります：

* シェイプ（またはそのパス）は、閉じた形または開いた形のいずれかです。
* シェイプが閉じている場合、開始点または終了点はありません。シェイプが開いている場合、始まりと終わりがあります。
* すべてのシェイプは、少なくとも 2 つのアンカーポイントから構成され、互いに線で結ばれています。
* 線は直線または曲線のいずれかです。アンカーポイントが線の性質を決定します。
* アンカーポイントは角ポイント、直線ポイント、またはスムーズポイントとして存在します：
  * 角ポイントは、2 つの直線が角度で接続するポイントです。
  * スムーズポイントは、2 つのハンドルが直線上に存在し、線のセグメントが滑らかな曲線で接続されるポイントです。この場合、すべてのハンドルはアンカーポイントから等距離に分離されています。
  * 直線ポイントは、2 つのハンドルが直線上に存在し、その線の線分が滑らかな曲線で接続されるポイントです。この場合、ハンドルはアンカーポイントから等距離に分離される必要はありません。
* アンカーポイントを移動したり編集したりすることで（これにより線の角度が変わります）、シェイプの見た目を変更できます。 

PowerPoint シェイプを編集ポイントを介して編集するために、**Aspose.Slides** は [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) クラスと [**IGeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath) インターフェースを提供します。

* [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) インスタンスは [IGeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape) オブジェクトの幾何学的パスを表します。
* `IGeometryShape` インスタンスから`GeometryPath`を取得するには、[IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#getGeometryPaths--) メソッドを使用できます。
* シェイプの `GeometryPath` を設定するには、次のメソッドを使用できます：*solid shapes* 用の [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) と *composite shapes* 用の [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-)。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath) のメソッドを使用できます。
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setStroke-boolean-) および [IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setFillMode-byte-) メソッドを使用して、幾何学的パスの外観を設定できます。
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#getPathData--) メソッドを使用して、`GeometryShape` の幾何学的パスをパスセグメントの配列として取得できます。
* 追加のシェイプ幾何学カスタマイズオプションにアクセスするには、[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) を [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) に変換できます。
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) と [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) メソッド（[ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil) クラスから）を使用して、[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) を [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) に相互変換できます。

## **簡単な編集操作**

この PHP コードは、以下を示しています。

**パスの終わりに**ラインを追加：

```php

```
**指定された位置に**ラインを追加：

```php

```
**パスの終わりに**立方体ベジエ曲線を追加：

```php

```
**指定された位置に**立方体ベジエ曲線を追加：

```php

```
**パスの終わりに**二次ベジエ曲線を追加：

```php

```
**指定された位置に**二次ベジエ曲線を追加：

```php

```
**与えられた円弧を**パスに追加：

```php

```
**現在の図形を**パスで閉じる：

```php

```
**次のポイントの位置を**設定：

```php

```
**指定されたインデックスの**パスセグメントを削除：

```php

```

## **シェイプにカスタムポイントを追加**
1. [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) クラスのインスタンスを作成し、[ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType) タイプを設定します。
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) クラスのインスタンスを取得します。
3. パス上の2つの上部ポイントの間に新しいポイントを追加します。
4. パス上の2つの下部ポイントの間に新しいポイントを追加します。
5. パスをシェイプに適用します。

この PHP コードは、シェイプにカスタムポイントを追加する方法を示しています。

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example1_image](custom_shape_1.png)

##  シェイプからポイントを削除

1. [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) クラスのインスタンスを作成し、[ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType) タイプを設定します。
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) クラスのインスタンスを取得します。
3. パスのセグメントを削除します。
4. パスをシェイプに適用します。

この PHP コードは、シェイプからポイントを削除する方法を示しています。

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example2_image](custom_shape_2.png)

##  **カスタムシェイプを作成**

1. シェイプのポイントを計算します。
2. [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) クラスのインスタンスを作成します。
3. ポイントでパスを塗りつぶします。
4. [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) クラスのインスタンスを作成します。
5. パスをシェイプに適用します。

この Java は、カスタムシェイプを作成する方法を示しています。

```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example3_image](custom_shape_3.png)


## **複合カスタムシェイプを作成**

1. [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) クラスのインスタンスを作成します。
2. [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) クラスの最初のインスタンスを作成します。
3. 第二の [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) クラスのインスタンスを作成します。
4. パスをシェイプに適用します。

この PHP コードは、複合カスタムシェイプを作成する方法を示しています。

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example4_image](custom_shape_4.png)

## **曲がった角を持つカスタムシェイプを作成**

この PHP コードは、内側に曲がった角を持つカスタムシェイプを作成する方法を示しています。

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GeometryPathをjava.awt.Shapeに変換**

1. [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) クラスのインスタンスを作成します。
2. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) クラスのインスタンスを作成します。
3. [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil) を使って、[java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) インスタンスを [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) インスタンスに変換します。
4. パスをシェイプに適用します。

この PHP コードは、上記の手順の実装であり、**GeometryPath** から **GraphicsPath** への変換プロセスを示しています。

```php
  $pres = new Presentation();
  try {
    # 新しいシェイプを作成
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # シェイプの幾何学的パスを取得
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # テキストを持つ新しいグラフィックスパスを作成
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "シェイプ内のテキスト";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # グラフィックスパスを幾何学パスに変換
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # 新しい幾何学パスとオリジナルの幾何学パスをシェイプに設定
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)