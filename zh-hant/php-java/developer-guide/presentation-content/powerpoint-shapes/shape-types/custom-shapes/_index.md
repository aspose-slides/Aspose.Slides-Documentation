---
title: 在 PHP 中自訂簡報形狀
linktitle: 自訂形狀
type: docs
weight: 20
url: /zh-hant/php-java/custom-shape/
keywords:
- 自訂形狀
- 新增形狀
- 建立形狀
- 變更形狀
- 形狀幾何
- 幾何路徑
- 路徑點
- 編輯點
- 新增點
- 移除點
- 編輯操作
- 曲線角
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "利用 Aspose.Slides for PHP（透過 Java）在 PowerPoint 簡報中建立與自訂形狀：幾何路徑、曲線角、複合形狀。"
---
## **概述**

本文說明如何透過編輯點與幾何路徑編輯形狀幾何，來自訂 Aspose.Slides 簡報中的圖形外觀。示範如何使用 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 變更既有圖形、執行基本路徑編輯操作、加入或移除點，並將更新後的幾何套用回圖形。

亦示範如何建立自訂與複合圖形、建構帶曲線角的圖形、判斷圖形幾何是否封閉、檢查圖形元素，以及將 Java AWT 文字輪廓轉換為幾何路徑。

## **使用編輯點變更圖形**

在 PowerPoint 中，您可以使用 **Edit Points** 來修改方形：

* 向內或向外移動角落。
* 調整點的曲率。
* 新增點。

編輯點可讓您修改圖形輪廓，或以既有圖形為基礎建立新圖形。

## **圖形編輯技巧**

![overview_image](custom_shape_0.png)

編輯 PowerPoint 圖形時，請留意以下概念：

* 圖形（或其路徑）可以是封閉或開放的。
* 圖形的路徑由錨點與其間的線段組成。
* 線段可以是直線或曲線。錨點與控制手柄決定其形狀。
* 錨點分為角點、直點或平滑點：
  * 在角點，相鄰線段可在角度處相會。
  * 在平滑點，兩個控制手柄共線且與錨點距離相等。
  * 在直點，兩個控制手柄共線但距離可不同。
* 移動錨點或調整其手柄會改變圖形輪廓。

欲透過編輯點編輯 PowerPoint 圖形，**Aspose.Slides** 提供 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 類別。

* [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 實例代表 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) 物件的幾何路徑。
* 若要從 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) 取得 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)，可使用 [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) 方法。
* 若要為圖形設定 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)，可使用以下方法：單一路徑圖形使用 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath)，多路徑圖形使用 [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths)。
* 若要新增線段，可使用 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 下的相關方法。
* 使用 [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) 與 [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) 方法，可設定幾何路徑的外觀。
* 透過 [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) 方法，可取得 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) 的幾何路徑陣列。
* 若要存取額外的圖形幾何自訂選項，可透過 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 的 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 讀取，並在 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 上重播其線段。

## **簡單編輯操作**

使用下列方法編輯幾何路徑。接受索引的多載會在路徑的線段陣列中於該零基位置插入線段。

| 操作 | 方法 |
| --- | --- |
| 追加或插入直線。 | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| 追加或插入具有兩個控制點與終點的三次貝茲曲線。 | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 追加或插入具有一個控制點與終點的二次貝茲曲線。 | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 依指定的尺寸與角度（以度為單位）追加橢圓弧。 | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| 透過將端點連回起點關閉目前圖形。 | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| 設定圖形的起始點。 | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| 依零基索引移除線段。 | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **為圖形新增自訂點**

此範例使用 [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) 將兩個點插入矩形，然後以 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 套用編輯後的路徑。座標是相對於圖形的：兩個新點皆位於中心，左側距離 100 點、上方距離 50 點。線段索引 1 與 4 將它們分別放在上、下邊緣，將該邊緣向內拉。

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

## **從圖形移除點**

此範例透過 [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) 移除零基索引 2 的線段，變更心形輪廓。使用 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 套用修改後的路徑，即可更新圖形輪廓。

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

## **建立自訂圖形**

此範例使用 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 建立五角星。外、內半徑交替為 100 與 50 點，定義星尖與凹陷；72 度的步距均勻分佈五個星尖。路徑以 [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) 閉合，並以 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 套用至矩形，取代其原有輪廓。

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

## **建立複合自訂圖形**

此範例為圖形的上、下三分之一各定義一個封閉的 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 物件。使用 [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) 同時套用兩條路徑，即可產生中間三分之一留白的單一複合圖形。

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

## **建立帶曲線角的自訂圖形**

此範例結合直線段與 [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) 建立內彎曲角的圖形。每個角的大小設定弧線的寬度與高度（單位為點），-90 度的掃描角繪製逆時針四分之一橢圓。完成的路徑以 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 套用，簡報最後儲存為 PPTX 格式。

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

## **判斷圖形幾何是否封閉**

以下輔助程式會檢查每個非空幾何路徑是否以關閉線段結尾。它讀取 [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) 並比較最後線段的 [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) 是否等於 [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/)。若沒有非空路徑則回傳 false。此檢查每條路徑的最後指令，並不會檢查路徑內的每個子圖形。範例對矩形會印出 `true`。

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

## **檢查幾何路徑指令**

下載 [contour.pptx](contour.pptx) 並放置於應用程式的工作目錄。第一張投影片的第一個圖形具有直線上緣、三次貝茲曲線以及直線閉合邊。使用 [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) 讀取圖形的路徑，並以 [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) 依繪製順序讀取每條路徑的線段。對於每個線段， [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) 會辨識指令並決定如何解讀 [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData) 回傳的值。

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

圖形位於投影片座標 (200, 100) 點。回報的座標是相對於圖形的，本機座標系的左上角為 (0, 0)，X 向右遞增，Y 向下遞增。閉合線段會回到起始點，且不會有額外座標。

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **擷取並檢查圖形元素**

使用 [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) 可將現有圖形檢視為包含路徑點與點類型的元素。對每個回傳的 [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) 使用 [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) 與 [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) 方法取得點陣列與類型陣列。此表示方式對於輪廓分析或將幾何傳遞給自訂繪圖工具非常有用。

範例開啟 input.pptx，於第一張投影片直接找到第一個幾何圖形，並印出其路徑線段。請使用含有直線與曲線線段的投影片以看到兩種輸出。此方法不會搜尋群組內部。

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
                $pointType = $types[$i] & 0x07; // 保留線段類型，排除旗標。
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // 同時消耗兩個控制點與終點。
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

陣列以索引對應：`$points[$i]` 為一個點，`$types[$i]` 描述其角色。類型 `0` 表示開始圖形，類型 `1` 表示從前一點畫直線至目前點。三次貝茲線段從前一端點開始，接著使用連續三個類型 `3` 條目：兩個控制點加上新端點。迴圈會一次處理這三條目，並檢查端點是否閉合。

點類型亦包含旗標。以 `0x07` 取得線段類型，以 `0x80` 判斷是否為閉合子路徑。例如 `129` (`0x81`) 表示閉合的直線端點，`131` (`0x83`) 表示閉合的貝茲端點。PHP/Java Bridge 會將位元組陣列以二進位字串回傳；使用 `"C*"` 進行 unpack 可取得無號位元組值。遮罩可保留預期的位元值。僅以 `1` 或 `3` 比較原始值會遺漏這些情形。其他旗標，如虛線 (`0x10`) 與標記 (`0x20`)，不會改變基礎線段類型。

**座標與轉換。** 點的單位為點 (1/72 吋)，X 向右遞增，Y 向下遞增。對於未群組的圖形，擷取的座標已包括由 [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) 與 [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) 回傳的位置，並反映其目前的寬度與高度。例如，未旋轉的矩形位於 `(100, 200)`，尺寸 `120 × 80`，其輪廓範圍為 `(100, 200)`–`(220, 280)`。請勿再次加上圖形的位置。若要取得相對於未旋轉框架的座標，請減去其 X 與 Y。

擷取的點不會套用由 [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) 回傳的旋轉角度，亦不會考慮水平或垂直翻轉。若要重現顯示的輪廓，需以圖形中心為基礎套用這些變換。對於群組圖形，還需考慮群組座標映射與轉換；請勿假設擷取的點已是最終投影片座標，亦不要在已反映於子圖形框架的情況下再次平移或縮放。

**檢查 vs. 編輯。** 擷取的陣列僅描述輪廓，直接變更陣列不會更新原圖形。當分析或繪圖程式需要點/類型陣列時，可採用此方式。若需要在圖形的本機座標系中取得幾何指令或編輯其幾何，請使用 [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths)。編輯後的路徑可透過 [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 或 [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) 套用。

## **將 Java AWT Shape 轉換為 GeometryPath**

此範例將矩形輪廓與文字輪廓結合。使用 [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) 方法關閉矩形的填色。透過 [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) 產生文字輪廓的 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)。其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 會提供移動、直線、二次、三次與閉合線段，範例將其重播至 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)。

範例使用 Java 浮點數陣列，使 PHP/Java Bridge 能保留迭代器寫入的座標。文字使用 40 點的 Arial 字型。輪廓在水平上偏移 20 點，且以視覺上方 10 點低於圖形上緣為基準定位。文字路徑被填色，而原始矩形僅保留輪廓。最後以 [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) 同時套用兩條路徑，產生包含矩形與文字的單一圖形。

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

## **常見問答**

**取代幾何後，填色與描邊會發生什麼變化？**

樣式仍保留在圖形上，只有輪廓會改變。填色與描邊會自動套用至新幾何。

**如何在旋轉自訂圖形時，同步旋轉其幾何？**

使用圖形的 [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) 方法；幾何會因與圖形座標系綁定而一起旋轉。

**我可以將自訂圖形轉換為影像以「鎖定」結果嗎？**

可以。將所需的 [slide](/slides/zh-hant/php-java/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/php-java/create-shape-thumbnails/) 本身匯出為點陣圖格式，這樣可簡化後續對複雜幾何的處理。