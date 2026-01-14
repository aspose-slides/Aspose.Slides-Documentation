---
title: PHPでプレゼンテーションシェイプをカスタマイズ
linktitle: カスタムシェイプ
type: docs
weight: 20
url: /ja/php-java/custom-shape/
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
- PHP
- Aspose.Slides
description: "Java経由でPHP用Aspose.Slidesを使用してPowerPointプレゼンテーション内のシェイプを作成・カスタマイズします：ジオメトリパス、曲線コーナー、複合シェイプ。"
---

## **編集ポイントを使用してシェイプを変更する**
四角形を考えてみましょう。PowerPoint では **編集ポイント** を使用して

* 四角形の角を内側または外側に移動できる
* 角や点の曲率を指定できる
* 四角形に新しい点を追加できる
* 四角形上の点を操作できる、など

基本的に、これらの操作は任意のシェイプで実行できます。編集ポイントを使うことで、シェイプを変更したり、既存のシェイプから新しいシェイプを作成したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

編集ポイントで PowerPoint のシェイプを編集し始める前に、シェイプに関して次の点を確認してください。

* シェイプ（またはそのパス）は閉じているか開いているかのどちらかです。
* シェイプが閉じている場合、開始点や終了点がなく、開いている場合は始点と終点があります。
* すべてのシェイプは少なくとも 2 つのアンカーポイントで構成され、これらは線で結ばれています。
* 線は直線または曲線のいずれかです。アンカーポイントが線の性質を決定します。
* アンカーポイントはコーナーポイント、ストレートポイント、スムーズポイントのいずれかです：
  * コーナーポイントは、2 本の直線が角度を持って結合する点です。
  * スムーズポイントは、2 本のハンドルが一直線上にあり、線のセグメントが滑らかな曲線で結合する点です。この場合、すべてのハンドルはアンカーポイントから等距離に離れています。
  * ストレートポイントは、2 本のハンドルが一直線上にあり、線のセグメントが滑らかな曲線で結合する点です。この場合、ハンドルはアンカーポイントから等距離である必要はありません。
* アンカーポイントを移動または編集（線の角度が変わる）することで、シェイプの外観を変更できます。

編集ポイントで PowerPoint のシェイプを編集するには、**Aspose.Slides** が提供する [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) クラスを使用します。

* [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) インスタンスは、[GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) オブジェクトのジオメトリパスを表します。
* `GeometryShape` インスタンスから `GeometryPath` を取得するには、[GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) メソッドを使用します。
* シェイプに `GeometryPath` を設定するには、*単純シェイプ* 用に [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) を、*複合シェイプ* 用に [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) を使用します。
* セグメントを追加するには、[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 以下のメソッドを使用します。
* [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/setstroke/) と [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/setfillmode/) メソッドで、ジオメトリパスの外観を設定できます。
* [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/getpathdata/) メソッドで、`GeometryShape` のジオメトリパスをパスセグメントの配列として取得できます。
* 追加のシェイプジオメトリ カスタマイズ オプションにアクセスするには、[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) を [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) に変換できます。
* [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil) クラスの [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) と [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) メソッドを使用して、[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) と [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) を相互に変換します。

## **シンプルな編集操作**

この PHP コードは以下を示します

**パスの末尾に直線を追加する**  
```php

```

**パス内の指定位置に直線を追加する**：  
```php

```

**パスの末尾に 3 次ベジェ曲線を追加する**：  
```php

```

**パス内の指定位置に 3 次ベジェ曲線を追加する**：  
```php

```

**パスの末尾に二次ベジェ曲線を追加する**：  
```php

```

**パス内の指定位置に二次ベジェ曲線を追加する**：  
```php

```

**指定した円弧をパスに追加する**：  
```php

```

**現在の図形を閉じる**：  
```php

```

**次の点の位置を設定する**：  
```php

```

**指定インデックスのパスセグメントを削除する**：  
```php

```


## **シェイプにカスタムポイントを追加する**
1. [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) クラスのインスタンスを作成し、[ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType) タイプを設定します。
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) クラスのインスタンスを取得します。
3. パス上の上部 2 点の間に新しい点を追加します。
4. パス上の下部 2 点の間に新しい点を追加します。
5. パスをシェイプに適用します。

この PHP コードはシェイプにカスタムポイントを追加する方法を示します：  
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

## **シェイプからポイントを削除する**

1. [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) クラスのインスタンスを作成し、[ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType) タイプを設定します。
2. シェイプから [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) クラスのインスタンスを取得します。
3. パスのセグメントを削除します。
4. パスをシェイプに適用します。

この PHP コードはシェイプからポイントを削除する方法を示します：  
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

## **カスタムシェイプを作成する**

1. シェイプのポイントを計算します。
2. [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) クラスのインスタンスを作成します。
3. パスにポイントを設定します。
4. [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) クラスのインスタンスを作成します。
5. パスをシェイプに適用します。

この Java コードはカスタムシェイプの作成方法を示します：  
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

## **複合カスタムシェイプを作成する**

1. [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) クラスのインスタンスを作成します。
2. 最初の [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) クラスのインスタンスを作成します。
3. 2 番目の [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) クラスのインスタンスを作成します。
4. パスをシェイプに適用します。

この PHP コードは複合カスタムシェイプを作成する方法を示します：  
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

## **曲線コーナー付きカスタムシェイプを作成する**

この PHP コードは曲線コーナー（内側）付きのカスタムシェイプを作成する方法を示します；  
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


## **シェイプジオメトリが閉じているかどうかを確認する**

閉じたシェイプは、すべての辺が接続され、隙間のない単一の境界を形成しているものと定義されます。こうしたシェイプは単純な幾何形状でも、複雑なカスタム輪郭でも構いません。以下のコード例は、シェイプジオメトリが閉じているかどうかを確認する方法を示しています：  
```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```


## **GeometryPath を java.awt.Shape に変換する**

1. [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) クラスのインスタンスを作成します。
2. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) クラスのインスタンスを作成します。
3. [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil) を使用して、[java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) インスタンスを [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) インスタンスに変換します。
4. パスをシェイプに適用します。

この PHP コードは上記手順の実装例で、**GeometryPath** から **GraphicsPath** への変換プロセスを示しています：  
```php
  $pres = new Presentation();
  try {
    # 新しいシェイプを作成
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # シェイプのジオメトリパスを取得
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # テキスト付きの新しいグラフィックパスを作成
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # グラフィックパスをジオメトリパスに変換
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # シェイプに新しいジオメトリパスと元のジオメトリパスの組み合わせを設定
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example5_image](custom_shape_5.png)

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしと輪郭はどうなりますか？**

スタイルはシェイプに残り、輪郭だけが変更されます。塗りつぶしと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタムシェイプを正しく回転させるには？**

シェイプの [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setrotation/) メソッドを使用します。ジオメトリはシェイプにバインドされている座標系とともに回転します。

**カスタムシェイプを画像に変換して「固定」できますか？**

はい。必要な [slide](/slides/ja/php-java/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/php-java/create-shape-thumbnails/) 自体をラスタ形式でエクスポートすれば、重いジオメトリの後続作業が簡素化されます。