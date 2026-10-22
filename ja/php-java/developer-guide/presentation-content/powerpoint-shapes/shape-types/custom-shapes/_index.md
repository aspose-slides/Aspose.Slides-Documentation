---
title: PHP でプレゼンテーションの形状をカスタマイズする
linktitle: カスタム形状
type: docs
weight: 20
url: /ja/php-java/custom-shape/
keywords:
- カスタム形状
- 形状を追加
- 形状を作成
- 形状を変更
- 形状ジオメトリ
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
description: "Java 経由で PHP 用 Aspose.Slides を使用して PowerPoint プレゼンテーション内の形状を作成およびカスタマイズします：ジオメトリパス、曲線コーナー、複合形状。"
---
## **概要**

この記事では、編集ポイントとジオメトリパスを使用して形状ジオメトリを編集することで、Aspose.Slides のプレゼンテーション形状をカスタマイズする方法を説明します。[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) を使用して既存の形状を変更し、基本的なパス編集操作を実行し、ポイントを追加または削除し、更新されたジオメトリを形状に適用する方法を示します。

また、カスタムおよび複合形状の作成、角が丸い形状の構築、形状ジオメトリが閉じているかの判定、形状要素の検査、Java AWT テキスト輪郭をジオメトリパスに変換する方法もデモンストレーションします。

## **編集ポイントで形状を変更する**

PowerPoint では、**編集ポイント** を使用して四角形を変更できます。

* 角を内側または外側に移動する。
* ポイントの曲率を調整する。
* 新しいポイントを追加する。

編集ポイントを使用すると、形状の輪郭を変更したり、既存の形状を新しい形状の基礎として使用したりできます。

## **形状編集のヒント**

![overview_image](custom_shape_0.png)

PowerPoint の形状を編集する際に覚えておくべき概念は次のとおりです。

* 形状（またはそのパス）は閉じている場合と開いている場合があります。
* 形状のパスは、セグメントで接続されたアンカーポイントで構成されます。
* セグメントは直線または曲線になり得ます。アンカーポイントと制御ハンドルがその形状を決定します。
* アンカーポイントはコーナー点、直線点、スムーズ点のいずれかです。
  * コーナー点では、隣接するセグメントが角度を持って交差します。
  * スムーズ点では、2 つの制御ハンドルが一直線上にあり、アンカーポイントから等距離です。
  * 直線点では、2 つの制御ハンドルが一直線上にありますが、アンカーポイントからの距離は異なる場合があります。
* アンカーポイントを移動したりハンドルを調整したりすると、形状の輪郭が変わります。

PowerPoint の形状を編集ポイントで操作するには、**Aspose.Slides** が提供する [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) クラスを使用します。

* [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) インスタンスは、[GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) オブジェクトのジオメトリパスを表します。
* [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) を取得するには、[GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) メソッドを使用します。
* 形状に [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) を設定するには、単一パスの場合は [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath)、複数パスの場合は [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) を使用します。
* セグメントを追加するには、[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) の各種メソッドを使用します。
* [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) および [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) メソッドを使用して、ジオメトリパスの外観を設定できます。
* [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) メソッドを使用すると、[GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) のジオメトリパスをパスセグメントの配列として取得できます。
* 追加の形状ジオメトリカスタマイズオプションにアクセスするには、[java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) をその [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) で読み取り、セグメントを [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) に再現します。

## **単純な編集操作**

ジオメトリパスを編集するには以下のメソッドを使用します。インデックスを受け取るオーバーロードは、パスのセグメント配列内のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入する。 | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| 2 つの制御点と終了点を持つ 3 次ベジエ曲線を追加または挿入する。 | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 1 つの制御点と終了点を持つ 2 次ベジエ曲線を追加または挿入する。 | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 指定した寸法と角度（度）で楕円弧を追加する。 | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| 終了点を開始点に接続して現在の図形を閉じる。 | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| 図形の開始点を設定する。 | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| ゼロベースインデックスでセグメントを削除する。 | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **形状にカスタムポイントを追加する**

この例は、[GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) を使用して矩形形状に 2 つのポイントを挿入し、編集されたパスを [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) で適用します。座標は形状ローカルです。新しいポイントは両方とも形状の中心にあり、左端から 100 ポイント、上端から 50 ポイントの位置です。セグメントインデックス 1 と 4 はそれぞれ上辺と下辺に配置され、これらの辺を内側に引き寄せます。

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **形状からポイントを削除する**

この例は、[GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) を使用してゼロベースインデックス 2 のセグメントを削除し、ハート形の輪郭を変更します。修正されたパスを [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) で適用すると、形状の輪郭が更新されます。

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **カスタム形状を作成する**

この例は、[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) を使用して五角星を構築します。外側半径 100 ポイント、内側半径 50 ポイントを交互に設定し、72 度のステップで 5 つの先端を均等に配置します。パスは [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) で閉じられ、[GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) を使用して矩形形状に適用され、元の輪郭が置き換えられます。

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **複合カスタム形状を作成する**

この例は、形状の上部 1/3 と下部 1/3 用に 2 つの閉じた [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) オブジェクトを定義します。両方のパスを [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) で適用すると、中央の 1/3 に隙間がある単一の複合形状が作成されます。

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **角が丸いカスタム形状を作成する**

この例は、直線セグメントと [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) を組み合わせて、内側に曲がった角を持つ形状を作成します。各コーナーのサイズはアークの幅と高さ（ポイント）を設定し、-90 度のスイープで反時計回りの 1/4 楕円を描きます。完成したパスは [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) で適用され、プレゼンテーションは PPTX 形式で保存されます。

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **形状ジオメトリが閉じているかどうかを確認する**

以下のヘルパーは、すべての非空ジオメトリパスが閉じるセグメントで終わっているかをチェックします。[GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) を読み取り、最終セグメントの [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) を [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) と比較します。非空パスがない場合は false を返します。このチェックは各パスの最終コマンドのみを対象とし、パス内のすべてのサブフィギュアは検査しません。例では矩形に対して `true` を出力します。

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **形状要素を抽出して検査する**

[GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) を使用して、パスポイントとポイントタイプを含む要素として既存の形状を検査できます。返された各 [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) を使用し、[getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) と [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) メソッドでポイント配列とタイプ配列を取得します。この表現は輪郭分析やカスタム描画ツールへのジオメトリ渡しに便利です。

例では input.pptx を開き、最初のスライド上の最初のジオメトリ形状を直接取得し、そのパスセグメントを出力します。直線と曲線セグメントの両方を持つ形状が含まれるプレゼンテーションを使用すると、両方の出力が確認できます。グループ内は検索されません。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // フラグを除いたセグメントタイプを保持します。
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // 制御点と終点の両方を消費します。
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

配列はインデックスで対応しています：`$points[$i]` がポイント、`$types[$i]` がその役割を示します。タイプ `0` は図形の開始、タイプ `1` は前のポイントから現在のポイントへの直線を表します。3 次ベジエセグメントは前の終点から開始し、連続するタイプ `3` のエントリ 3 つ（2 つの制御点と新しい終点）で構成されます。この 3 エントリは一括で消費され、終点が閉じているかどうかがチェックされます。

ポイントタイプにはフラグも含まれます。`0x07` でセグメントタイプを特定し、`0x80` を別途テストして閉じたサブパスを検出します。例として `129`（`0x81`）はサブパスを閉じる線の終点、`131`（`0x83`）はサブパスを閉じるベジエの終点を意味します。PHP/Java ブリッジはバイト配列をバイナリ文字列として返すため、"C*" でアンパックすると符号なしバイト値が得られます。マスク処理により意図したビット値が保持されます。`1` または `3` のみで生の値を比較するとこれらのケースが見逃されます。ダッシュ（`0x10`）やマーカー（`0x20`）などの他のフラグは基本セグメントタイプを変更しません。

**座標と変換。** ポイントはポイント単位（1/72 インチ）で測定され、X は右方向に、Y は下方向に増加します。単独の形状の場合、抽出された座標はすでに [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) と [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) が返す位置を含み、現在の幅と高さを反映しています。例として、左上が `(100,200)`、サイズが `120 × 80` の回転していない矩形の輪郭は `(100,200)`–`(220,280)` です。形状の位置を二度加算しないでください。未回転フレームに対しては X と Y を減算してローカル座標を取得します。

抽出されたポイントは [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) による回転や水平・垂直反転を考慮していません。表示上の輪郭を再現するには、これらの変換を形状の中心を基点に適用してください。グループ化された形状の場合は、グループ座標マッピングと変換も考慮し、抽出ポイントが最終的なスライド座標であると仮定したり、子フレームですでに反映されている平行移動やスケールを二度適用したりしないでください。

**検査と編集の違い。** 抽出された配列は輪郭を記述したものであり、変更しても元の形状は更新されません。ポイント/タイプ配列が分析や描画コードに必要なときにこの方法を選択し、形状のローカル座標系でジオメトリコマンドが必要な場合やジオメトリを編集したい場合は [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) を使用してください。編集したパスは [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) または [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) で適用します。

## **Java AWT Shape を GeometryPath に変換する**

この例は、矩形の輪郭にテキストをジオメトリに変換したものを組み合わせます。輪郭の [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) メソッドで塗りつぶしを無効にします。[GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) がテキスト輪郭を [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) に作成します。その [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) が move、line、quadratic、cubic、close の各セグメントを提供し、例ではそれらを [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) に再生します。

例では Java の float 配列を使用し、PHP/Java ブリッジがイテレータが書き出した座標を保持します。テキストは 40 ポイントの Arial フォントです。輪郭は水平に 20 ポイントオフセットし、視覚的な上端が形状の上端から 10 ポイント下に配置されます。テキストパスは塗りつぶされ、元の矩形は輪郭のままです。両方のパスを [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) で適用すると、矩形とテキストを含む単一の形状が生成されます。

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしと輪郭はどうなりますか？**

スタイルは形状に残り、輪郭だけが変更されます。塗りつぶしと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタム形状を正しく回転させるにはどうすればよいですか？**

形状の [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) メソッドを使用します。ジオメトリは形状の座標系にバインドされているため、形状とともに回転します。

**カスタム形状を画像に変換して結果を「ロック」できますか？**

はい。必要な [slide](/slides/ja/php-java/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/php-java/create-shape-thumbnails/) 自体をラスタ形式へエクスポートすれば、複雑なジオメトリの後続作業が容易になります。