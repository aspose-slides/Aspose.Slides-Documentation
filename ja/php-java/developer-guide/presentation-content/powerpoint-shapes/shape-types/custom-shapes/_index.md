---
title: PHPでプレゼンテーションシェイプをカスタマイズする
linktitle: カスタムシェイプ
type: docs
weight: 20
url: /ja/php-java/custom-shape/
keywords:
- カスタムシェイプ
- シェイプの追加
- シェイプの作成
- シェイプの変更
- シェイプジオメトリ
- ジオメトリパス
- パスポイント
- 編集ポイント
- ポイントの追加
- ポイントの削除
- 編集操作
- 曲線コーナー
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用し、PowerPoint プレゼンテーションのシェイプを作成およびカスタマイズします：ジオメトリパス、曲線コーナー、複合シェイプ。"
---
## **概要**

本記事では、編集ポイントとジオメトリ パスを使用してシェイプのジオメトリを編集することで、Aspose.Slides のプレゼンテーション シェイプをカスタマイズする方法を説明します。[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) を使用して既存のシェイプを変更したり、基本的なパス編集操作を実行したり、ポイントを追加または削除したり、更新されたジオメトリをシェイプに適用したりする方法を示します。

また、カスタムおよび複合シェイプの作成、角が丸いシェイプの構築、シェイプ ジオメトリが閉じているかの判定、シェイプ要素の検査、Java AWT のテキスト輪郭をジオメトリ パスに変換する方法もデモします。

## **編集ポイントでシェイプを変更する**

PowerPoint では **編集ポイント** を使用して四角形を変更できます。

* 角を内側または外側に移動する。
* ポイントの曲率を調整する。
* 新しいポイントを追加する。

編集ポイントを使用すると、シェイプの輪郭を変更したり、既存のシェイプを新しいシェイプのベースとして使用したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

PowerPoint のシェイプを編集するときは、次の概念を覚えておいてください。

* シェイプ（またはそのパス）は閉じている場合と開いている場合があります。
* シェイプのパスはセグメントで接続されたアンカーポイントで構成されます。
* セグメントは直線または曲線にできます。アンカーポイントと制御ハンドルが形状を決定します。
* アンカーポイントはコーナー ポイント、ストレート ポイント、スムーズ ポイントのいずれかです：
  * コーナー ポイントでは、隣接するセグメントが角度を持って接続できます。
  * スムーズ ポイントでは、2 つの制御ハンドルが整列し、アンカーポイントから等距離です。
  * ストレート ポイントでは、2 つの制御ハンドルが整列していますが、距離は異なる場合があります。
* アンカーポイントを移動したりハンドルを調整したりすると、シェイプの輪郭が変わります。

編集ポイントを使用して PowerPoint のシェイプを編集するには、**Aspose.Slides** が提供する [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) クラスを使用します。

* [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) インスタンスは、[GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) オブジェクトのジオメトリ パスを表します。
* [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) を取得するには、[GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) メソッドを使用します。
* シェイプに [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) を設定するには、単一パス用に [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath)、複数パス用に [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) を使用します。
* セグメントを追加するには、[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) の各種メソッドを使用します。
* [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) と [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) を使用して、ジオメトリ パスの外観を設定できます。
* [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) メソッドで、[GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) のジオメトリ パスをパス セグメントの配列として取得できます。
* 追加のシェイプ ジオメトリ カスタマイズ オプションにアクセスするには、[java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) をその [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) で読み取り、セグメントを [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) に再現します。

## **簡単な編集操作**

以下のメソッドでジオメトリ パスを編集します。インデックスを受け取るオーバーロードは、パスのセグメント配列のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入する。 | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| 2 つの制御点と終点を持つ 3 次ベジエ曲線を追加または挿入する。 | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 1 つの制御点と終点を持つ 2 次ベジエ曲線を追加または挿入する。 | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 指定された寸法と角度（度）で楕円弧を追加する。 | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| 終点を開始点に接続して現在の図形を閉じる。 | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| 図形の開始点を設定する。 | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| ゼロベース インデックスでセグメントを削除する。 | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **シェイプにカスタム ポイントを追加する**

この例は、[GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) を使用して矩形シェイプに 2 つのポイントを挿入し、[GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) で編集済みパスを適用します。座標はシェイプ内ローカルで、両方の新しいポイントは左端から 100 ポイント、上端から 50 ポイントの位置にあります。セグメント インデックス 1 と 4 がそれぞれ上辺と下辺に配置され、これらの辺を内側に引っ張ります。

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

## **シェイプからポイントを削除する**

この例は、[GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) を使用してゼロベース インデックス 2 のセグメントを削除し、ハート形の輪郭を変更します。[GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) で変更したパスを適用すると、シェイツの輪郭が更新されます。

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

## **カスタム シェイプを作成する**

この例は、[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) を使用して五角星を構築します。外側半径 100、内側半径 50 の交互の半径で先端と凹みを定義し、72 度のステップで 5 つの先端を均等に配置します。パスは [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) で閉じられ、[GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) を使用して矩形シェイプに適用し、元の輪郭を置き換えます。

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

## **複合カスタム シェイプを作成する**

この例は、シェイプの上部 1/3 と下部 1/3 用に 2 つの閉じた [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) オブジェクトを定義します。[GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) で両方のパスを適用すると、中央 1/3 に隙間のある単一の複合シェイプが作成されます。

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

## **角が丸いカスタム シェイプを作成する**

この例は、[GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) を組み合わせて、内側に曲がった角を持つシェイプを作成します。各コーナー サイズはアークの幅と高さ（ポイント）を設定し、-90 度のスイープで反時計回りの 1/4 楕円を描きます。完成したパスは [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) で適用され、プレゼンテーションは PPTX 形式で保存されます。

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

## **シェイプ ジオメトリが閉じているか確認する**

以下のヘルパーは、すべての非空ジオメトリ パスが閉じるセグメントで終わるかどうかをチェックします。[GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) を読み取り、最終セグメントの [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) を [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) と比較します。非空パスがない場合は false を返します。このチェックは各パスの最終コマンドのみを対象とし、パス内のすべてのサブフィギュアは検査しません。例では矩形に対して `true` を出力します。

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

## **ジオメトリ パス コマンドを検査する**

[contour.pptx](contour.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置します。1 枚目のスライドの最初のシェイプは、上辺が直線、続いて 3 次ベジエ曲線、最後に直線で閉じる辺があります。[getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) でシェイプのパスを取得し、[getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) で各パスのセグメントを描画順に取得します。各セグメントについて、[getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) がコマンドを判別し、[getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData) が返す値の解釈方法を決定します。

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;

$presentation = new Presentation("contour.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    foreach ($shape->getGeometryPaths() as $pathIndex => $path) {
        foreach ($path->getPathData() as $segmentIndex => $segment) {
            $command = java_values($segment->getPathCommand());
            $data = java_values($segment->getSegmentData());
            switch ($command) {
                case PathCommandType::MoveTo:
                case PathCommandType::LineTo:
                    $name = $command === PathCommandType::MoveTo ? "MoveTo" : "LineTo";
                    $detail = sprintf("destination=(%s, %s)", ...$data);
                    break;
                case PathCommandType::CubicBezierTo:
                    $name = "CubicBezierTo";
                    $detail = sprintf("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", ...$data);
                    break;
                case PathCommandType::Close:
                    $name = "Close";
                    $detail = "no coordinates";
                    break;
                default:
                    $name = "Command " . $command;
                    $detail = "raw=" . json_encode($data);
            }
            printf("Path %d, segment %d: %s %s\n", $pathIndex, $segmentIndex, $name, $detail);
        }
    }
} finally {
    $presentation->dispose();
}
```

シェイプはスライド上で (200, 100) ポイントに配置されます。報告される座標はシェイプ内ローカルで、左上隅が (0, 0)、X が右方向、Y が下方向に増加します。閉じるセグメントは追加座標なしで開始点に戻ります。

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **シェイプ要素を抽出して検査する**

[GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) を使用して、シェイプをパスポイントとポイント種別を含む要素として検査します。返される各 [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) で、[getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) と [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) を呼び出して配列を取得します。この表現は輪郭解析やカスタム描画ツールへのジオメトリ受け渡しに便利です。

例では input.pptx を開き、1 枚目のスライド上に直接ある最初のジオメトリ シェイプを取得してパス セグメントを出力します。直線と曲線の両方を含むシェイプがあるプレゼンテーションで実行すると、両方の出力が確認できます。グループ内は検索しません。

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
                $pointType = $types[$i] & 0x07; // セグメントタイプを保持し、フラグは除外します。
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Consume both control points and the endpoint.
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

配列はインデックスで対応します：`$points[$i]` がポイント、`$types[$i]` がその種別です。種別 `0` は図形の開始、種別 `1` は前のポイントから現在のポイントへの直線を表します。3 次ベジエ セグメントは前の終点から始まり、連続した種別 `3` エントリ 3 つ（2 つの制御点と新しい終点）で表されます。ループはこれら 3 エントリをまとめて消費し、終点が閉じているかをチェックします。

ポイント種別にはフラグも含まれます。`0x07` でセグメント種別を識別し、`0x80` を別途テストして閉じたサブパスを検出します。例として `129`（`0x81`）は閉じたサブパスの直線終点、`131`（`0x83`）は閉じたベジエ終点を意味します。PHP/Java Bridge はバイト配列をバイナリ文字列として返すため、`"C*"` でアンパックすると符号なしバイト値が得られます。マスク処理でビット値が保持されます。`1` や `3` だけと比較するとこれらのケースを見落とします。ダッシュ（`0x10`）やマーカー（`0x20`）などのその他フラグは基礎セグメント種別を変更しません。

**座標と変換。** ポイントはポイント単位（1/72 インチ）で測定され、X は右方向、Y は下方向に増加します。グループ化されていないシェイプの場合、抽出された座標はすでに [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) と [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) による位置を含んでおり、現在の幅と高さを反映しています。例として、左上が `(100, 200)`、サイズが `120 × 80` の回転なし矩形は輪郭境界が `(100, 200)`–`(220, 280)` となります。位置を再度加算しないでください。X と Y を減算すれば、回転前のフレームに対する相対座標が得られます。

抽出されたポイントはシェイプの回転（[getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation)）や水平・垂直フリップを適用していません。表示されている輪郭を再現するには、シェイプ中心を基点にこれらの変換を適用してください。グループ化されたシェイプの場合は、グループ座標マッピングと変換も考慮し、抽出ポイントが最終的なスライド座標であると仮定したり、子フレームで既に反映されている平行移動やスケールを二重に適用したりしないでください。

**検査と編集の違い。** 抽出された配列は輪郭を記述するだけで、変更しても元のシェイプは更新されません。ポイント/種別配列が分析や描画コードで必要なときにこの方法を選びます。ジオメトリ コマンドをローカル座標系で取得したりジオメトリを編集したい場合は、[getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) を使用してください。編集したパスは [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) または [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) で適用します。

## **Java AWT Shape を GeometryPath に変換する**

この例は、矩形の輪郭とテキスト輪郭を組み合わせてジオメトリに変換します。輪郭の [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) メソッドで塗りつぶしを無効にします。[GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) が [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) にテキスト輪郭を作成し、その [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) が move、line、quadratic、cubic、close のセグメントを供給します。例はそれらを [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) に再現します。

例では Java の float 配列を使用し、PHP/Java Bridge がイテレータによって書き込まれた座標を保持します。テキストは 40 ポイントの Arial フォントです。輪郭は水平方向に 20 ポイントオフセットし、視覚的な上部がシェイプ上端から 10 ポイント下になるよう配置します。テキストパスは塗りつぶされ、元の矩形は輪郭のままです。両方のパスを [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) で適用すると、矩形とテキストを含む単一シェイプが生成されます。

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

スタイルはシェイプに残り、輪郭だけが変更されます。塗りつぶしと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタム シェイプを正しく回転させる方法は？**

シェイプの [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) メソッドを使用してください。ジオメトリはシェイプの座標系にバインドされているため、シェイプとともに回転します。

**カスタム シェイプを画像に変換して「固定」できますか？**

はい。必要な [slide](/slides/ja/php-java/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/php-java/create-shape-thumbnails/) 全体をラスタ形式でエクスポートすれば、複雑なジオメトリの後続作業が簡素化されます。