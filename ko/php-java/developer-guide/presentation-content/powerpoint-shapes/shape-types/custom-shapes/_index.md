---
title: PHP에서 프레젠테이션 형상 맞춤
linktitle: 사용자 지정 형상
type: docs
weight: 20
url: /ko/php-java/custom-shape/
keywords: 
- 사용자 지정 형상
- 형상 추가
- 형상 만들기
- 형상 변경
- 형상 기하학
- 기하 경로
- 경로 포인트
- 편집 포인트
- 포인트 추가
- 포인트 제거
- 편집 작업
- 곡선 모서리
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides로 PowerPoint 프레젠테이션에서 형상을 만들고 맞춤 설정합니다: 기하 경로, 곡선 모서리, 복합 형상."
---
## **개요**

이 기사에서는 편집 포인트와 기하 경로를 통해 형상 기하학을 편집하여 Aspose.Slides에서 프레젠테이션 형상을 사용자 지정하는 방법을 설명합니다. 기존 형상을 수정하고, 기본 경로 편집 작업을 수행하며, 포인트를 추가하거나 제거하고, 업데이트된 기하학을 형상에 적용하기 위해 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)를 사용하는 방법을 보여줍니다.

또한 사용자 지정 및 복합 형상을 만드는 방법, 곡선 모서리가 있는 형상을 구축하는 방법, 형상 기하학이 닫혀 있는지 확인하는 방법, 형상 요소를 검사하는 방법, Java AWT 텍스트 윤곽선을 기하 경로로 변환하는 방법을 시연합니다.

## **편집 포인트로 형상 변경**

PowerPoint에서 **편집 포인트**를 사용하여 사각형을 수정할 수 있습니다.

* 모서리를 안쪽이나 바깥쪽으로 이동합니다.
* 포인트에서 곡률을 조정합니다.
* 새 포인트를 추가합니다.

편집 포인트를 사용하면 형상의 외곽선을 변경하거나 기존 형상을 새로운 형상의 기반으로 사용할 수 있습니다.

## **형상 편집 팁**

![overview_image](custom_shape_0.png)

PowerPoint 형상을 편집할 때 다음 개념을 기억하세요.

* 형상(또는 그 경로)은 닫혀 있거나 열려 있을 수 있습니다.
* 형상의 경로는 세그먼트로 연결된 앵커 포인트로 구성됩니다.
* 세그먼트는 직선이거나 곡선일 수 있으며, 앵커 포인트와 컨트롤 핸들이 형태를 결정합니다.
* 앵커 포인트는 코너 포인트, 직선 포인트, 부드러운 포인트 중 하나입니다.
  * 코너 포인트에서는 인접 세그먼트가 각도로 만날 수 있습니다.
  * 부드러운 포인트에서는 두 컨트롤 핸들이 정렬되고 앵커 포인트와 같은 거리에 있습니다.
  * 직선 포인트에서는 두 컨트롤 핸들이 정렬되지만 거리 차이가 있을 수 있습니다.
* 앵커 포인트를 이동하거나 핸들을 조정하면 형상의 외곽선이 바뀝니다.

편집 포인트를 통해 PowerPoint 형상을 편집하려면 **Aspose.Slides**에서 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 클래스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 인스턴스는 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) 객체의 기하 경로를 나타냅니다.
* [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) 인스턴스에서 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)를 가져오려면 [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) 메서드를 사용합니다.
* 형상에 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)를 설정하려면 단일 경로 형상에는 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), 다중 경로 형상에는 [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) 메서드를 사용합니다.
* 세그먼트를 추가하려면 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 아래의 메서드를 사용할 수 있습니다.
* [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) 및 [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) 메서드를 사용하여 기하 경로의 외관을 설정할 수 있습니다.
* [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) 메서드를 사용하면 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/)의 기하 경로를 세그먼트 배열로 가져올 수 있습니다.
* 추가 형상 기하 맞춤 옵션에 접근하려면 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 을 그 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 로 읽고, 해당 세그먼트를 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)에 재생합니다.

## **기본 편집 작업**

다음 메서드를 사용하여 기하 경로를 편집합니다. 인덱스를 받는 오버로드는 경로 세그먼트 배열의 해당 0 기반 위치에 세그먼트를 삽입합니다.

| 작업 | 메서드 |
| --- | --- |
| 직선을 추가하거나 삽입합니다. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| 두 개의 컨트롤 포인트와 끝점이 있는 3차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 하나의 컨트롤 포인트와 끝점이 있는 2차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 지정된 크기와 각도(도)로 타원 호를 추가합니다. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| 현재 도형을 시작점에 연결하여 현재 피규어를 닫습니다. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| 피규어의 시작점을 설정합니다. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| 0 기반 인덱스에서 세그먼트를 제거합니다. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **형상에 사용자 지정 포인트 추가**

이 예제는 [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo)를 사용하여 직사각형 형상에 두 개의 포인트를 삽입하고, [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath)으로 편집된 경로를 적용합니다. 좌표는 형상에 상대적이며, 두 새 포인트는 왼쪽에서 100포인트, 위에서 50포인트 떨어진 중앙에 있습니다. 세그먼트 인덱스 1과 4는 각각 상단과 하단 가장자리에 배치되어 해당 가장자를 안쪽으로 당깁니다.

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

## **형상에서 포인트 제거**

이 예제는 [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt)으로 0 기반 인덱스 2에 있는 세그먼트를 제거하여 하트 모양 윤곽을 변경합니다. 수정된 경로를 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath)으로 적용하면 형상의 컨투어가 업데이트됩니다.

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

## **사용자 지정 형상 만들기**

이 예제는 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)를 사용하여 5각 별을 구축합니다. 외부와 내부 반경을 각각 100포인트와 50포인트로 번갈아 지정하여 팁과 함몰을 정의하고, 72도 간격으로 다섯 팁을 고르게 배치합니다. 경로는 [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure)으로 닫힌 뒤, [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath)으로 직사각형 형상에 적용되어 기존 외곽을 교체합니다.

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

## **복합 사용자 지정 형상 만들기**

이 예제는 형상의 상·하 삼분면에 대해 두 개의 닫힌 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 객체를 정의합니다. 두 경로를 [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths)으로 적용하면 가운데 삼분면에 간격이 있는 단일 복합 형상이 생성됩니다.

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

## **곡선 모서리가 있는 사용자 지정 형상 만들기**

이 예제는 직선 세그먼트와 [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo)를 결합하여 내부가 굽은 모서리를 가진 형상을 생성합니다. 각 모서리 크기는 호의 너비와 높이를 포인트 단위로 설정하고, -90도 스윕은 반시계 방향 4분원 타원을 그립니다. 완성된 경로는 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath)으로 적용되고, 프레젠테이션은 PPTX 형식으로 저장됩니다.

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

## **형상 기하학이 닫혀 있는지 확인하기**

다음 도우미는 모든 비어 있지 않은 기하 경로가 닫는 세그먼트로 끝나는지 검사합니다. [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData)를 읽고 최종 세그먼트의 [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand)를 [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/)와 비교합니다. 비어 있지 않은 경로가 없을 경우 false를 반환합니다. 이 로직은 각 경로의 최종 명령만 확인하며, 경로 내 모든 하위 피규어를 검사하지는 않습니다. 예제는 사각형에 대해 `true`를 출력합니다.

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

## **기하 경로 명령 검사**

[contour.pptx](contour.pptx)를 다운로드하고 애플리케이션 작업 디렉터리에 넣으세요. 첫 번째 슬라이드의 첫 번째 형상은 직선 상단 가장자리, 3차 베지어 곡선, 직선 닫는 가장자를 가지고 있습니다. [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths)으로 형상의 경로를 읽고, [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData)로 각 경로의 세그먼트를 그리기 순서대로 읽습니다. 각 세그먼트에 대해 [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand)으로 명령을 식별하고, [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData)에서 반환된 값을 어떻게 해석할지 결정합니다.

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

형상의 위치는 슬라이드에서 (200, 100) 포인트이며, 보고된 좌표는 형상에 로컬입니다. (0, 0)은 형상의 왼쪽 위 모서리이며, x는 오른쪽으로, y는 아래쪽으로 증가합니다. 닫는 세그먼트는 추가 좌표 없이 시작점으로 돌아갑니다.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **형상 요소 추출 및 검사**

[GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) 메서드를 사용하여 기존 형상을 경로 포인트와 포인트 유형을 포함하는 요소로 검사합니다. 반환된 각 [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/)을 사용해 [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints)와 [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) 메서드로 포인트 및 유형 배열을 가져옵니다. 이 표현은 컨투어 분석이나 기하학을 사용자 지정 그리기 도구에 전달할 때 유용합니다.

예제는 input.pptx를 열어 첫 번째 슬라이드에 직접 있는 첫 번째 기하 형상을 찾아 그 경로 세그먼트를 출력합니다. 직선과 곡선 세그먼트를 모두 포함한 형상이 있는 프레젠테이션을 사용하면 두 종류의 출력 모두 확인할 수 있습니다. 그룹 내부는 검색하지 않습니다.

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
                $pointType = $types[$i] & 0x07; // 세그먼트 유형을 유지하고 플래그는 제외합니다.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // 두 개의 제어점과 끝점을 모두 사용합니다.
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

배열은 인덱스로 대응됩니다: `$points[$i]`는 포인트이며 `$types[$i]`는 그 역할을 설명합니다. 유형 `0`은 피규어 시작을, 유형 `1`은 이전 포인트에서 현재 포인트까지 선을 그리는 것을 의미합니다. 3차 베지어 세그먼트는 이전 끝점에서 시작하고 연속된 유형 `3` 세 개(두 컨트롤 포인트와 새로운 끝점)를 사용합니다. 루프는 이 세 엔트리를 함께 소비하고 끝점이 닫혔는지 확인합니다.

포인트 유형에는 플래그도 포함됩니다. `0x07` 마스크를 사용해 세그먼트 유형을 식별하고, `0x80`을 별도로 테스트해 닫힌 서브패스를 감지합니다. 예를 들어 `129`(`0x81`)은 서브패스를 닫는 선 끝점이며, `131`(`0x83`)은 닫힌 베지어 끝점을 의미합니다. PHP/Java Bridge는 바이트 배열을 바이너리 문자열로 반환하므로 `"C*"`로 언팩하면 부호 없는 바이트 값을 얻을 수 있습니다. 마스킹을 하면 의도된 비트 값이 유지됩니다. 원시값을 `1` 또는 `3`만으로 비교하면 이러한 경우를 놓치게 됩니다. 대시(`0x10`)와 마커(`0x20`) 같은 다른 플래그는 기본 세그먼트 유형을 변경하지 않습니다.

**좌표 및 변환** 포인트는 포인트(1/72 인치) 단위이며, X는 오른쪽으로, Y는 아래쪽으로 증가합니다. 그룹에 속하지 않은 형상의 경우 추출된 좌표에는 이미 [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX)와 [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY)에서 반환된 위치가 포함되어 있으며 현재 너비와 높이를 반영합니다. 예를 들어 `(100, 200)` 위치에 크기 `120 × 80`인 회전되지 않은 직사각형은 컨투어 경계가 `(100, 200)`–`(220, 280)`입니다. 위치를 다시 추가하지 마세요. X와 Y를 빼서 회전되지 않은 프레임에 대한 좌표를 얻습니다.

추출된 포인트는 [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation)으로 반환되는 형상의 회전이나 수평·수직 플립을 적용하지 않습니다. 표시된 컨투어를 재현하려면 형상 중심을 기준으로 이러한 변환을 적용하세요. 그룹형상의 경우 그룹 좌표 매핑 및 변환도 고려해야 하며, 추출된 포인트가 최종 슬라이드 좌표가 아니므로 번역이나 스케일을 두 번 적용하지 않도록 합니다.

**검사와 편집의 차이** 추출된 배열은 컨투어를 설명하며, 이를 변경해도 원본 형상이 업데이트되지 않습니다. 분석이나 그리기 코드가 포인트/유형 배열을 필요로 할 때 이 접근 방식을 사용하세요. 형상의 로컬 좌표계에서 기하 명령이 필요하거나 기하를 편집하려면 [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths)를 사용하고, 편집된 경로는 [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 또는 [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths)로 적용하세요.

## **Java AWT Shape를 GeometryPath로 변환**

이 예제는 직사각형 외곽과 텍스트를 기하로 변환하여 결합합니다. 외곽선의 [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) 메서드로 채우기를 비활성화합니다. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html)가 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)에서 텍스트 윤곽을 생성합니다. 해당 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)는 이동, 선, 2차, 3차 및 닫기 세그먼트를 제공하며, 예제는 이를 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)에 재생합니다.

예제는 Java float 배열을 사용해 PHP/Java Bridge가 이터레이터가 기록한 좌표를 그대로 유지하도록 합니다. 텍스트는 40포인트 Arial 폰트를 사용합니다. 외곽선은 수평으로 20포인트 이동하고, 시각적 상단이 형상 상단 가장자리 아래 10포인트에 배치됩니다. 텍스트 경로는 채워지고, 원래 직사각형은 외곽선만 남습니다. 두 경로를 [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths)으로 적용하면 직사각형과 텍스트를 포함하는 단일 형상이 생성됩니다.

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

**기하를 교체한 뒤 채우기와 외곽선은 어떻게 되나요?**

스타일은 형상에 그대로 남으며, 컨투어만 변경됩니다. 채우기와 외곽선은 새 기하에 자동으로 적용됩니다.

**기하와 함께 사용자 지정 형상을 올바르게 회전하려면 어떻게 해야 하나요?**

형상의 [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) 메서드를 사용하세요. 기하가 형상 자체 좌표계에 바인딩되어 있으므로 형상을 회전하면 기하도 함께 회전합니다.

**사용자 지정 형상을 이미지로 변환해 결과를 “잠그” 수 있나요?**

예. 필요한 [slide](/slides/ko/php-java/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/php-java/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하 작업을 간소화할 수 있습니다.