---
title: PHP에서 프레젠테이션 도형 사용자 지정
linktitle: 사용자 지정 도형
type: docs
weight: 20
url: /ko/php-java/custom-shape/
keywords: 
- 사용자 지정 도형
- 도형 추가
- 도형 생성
- 도형 변경
- 도형 기하
- 기하 경로
- 경로 점
- 편집 점
- 점 추가
- 점 제거
- 편집 작업
- 곡선 모서리
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides로 PowerPoint 프레젠테이션의 도형을 만들고 사용자 지정합니다: 기하 경로, 곡선 모서리, 복합 도형."
---
## **개요**

이 문서에서는 편집 점과 기하 경로를 통해 도형 기하를 편집하여 Aspose.Slides에서 프레젠테이션 도형을 사용자 정의하는 방법을 설명합니다. [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 를 사용하여 기존 도형을 수정하고, 기본 경로 편집 작업을 수행하며, 점을 추가하거나 제거하고, 업데이트된 기하를 도형에 다시 적용하는 방법을 보여줍니다. 또한 사용자 지정 및 복합 도형을 만드는 방법, 곡선 모서리를 가진 도형을 구축하는 방법, 도형 기하가 닫혀 있는지 확인하는 방법, 도형 요소를 검사하는 방법, Java AWT 텍스트 윤곽선을 기하 경로로 변환하는 방법을 시연합니다.

## **편집 점을 사용하여 도형 변경하기**

PowerPoint에서 **Edit Points** 를 사용하여 사각형을 수정할 수 있습니다:

* 코너를 안쪽이나 밖쪽으로 이동합니다.
* 점에서 곡률을 조정합니다.
* 새로운 점을 추가합니다.

편집 점을 사용하면 도형의 외곽선을 수정하거나 기존 도형을 새로운 도형의 기반으로 사용할 수 있습니다.

## **도형 편집 팁**

![overview_image](custom_shape_0.png)

PowerPoint 도형을 편집할 때 다음 개념을 기억하십시오:

* 도형(또는 그 경로)은 닫혀 있거나 열려 있을 수 있습니다.
* 도형의 경로는 세그먼트로 연결된 고정점(anchor points)으로 구성됩니다.
* 세그먼트는 직선일 수도 있고 곡선일 수도 있습니다. 고정점과 제어 핸들이 그 형태를 결정합니다.
* 고정점은 코너 포인트, 직선 포인트, 또는 스무스 포인트로 존재합니다:
  * 코너 포인트에서는 인접한 세그먼트가 각도를 이루며 만날 수 있습니다.
  * 스무스 포인트에서는 두 제어 핸들이 정렬되고 고정점에서 같은 거리에 있습니다.
  * 직선 포인트에서는 두 제어 핸들이 정렬되지만 고정점에서 거리가 다를 수 있습니다.
* 고정점을 이동하거나 핸들을 조정하면 도형의 외곽선이 변경됩니다.

편집 점을 통해 PowerPoint 도형을 편집하려면 **Aspose.Slides** 가 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 클래스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 인스턴스는 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) 객체의 기하 경로를 나타냅니다.
* [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) 인스턴스로부터 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 를 가져오려면 [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) 메서드를 사용할 수 있습니다.
* 도형에 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 을 설정하려면, 단일 경로를 가진 도형은 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 를, 다중 경로를 가진 도형은 [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) 를 사용할 수 있습니다.
* 세그먼트를 추가하려면 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 아래의 메서드를 사용할 수 있습니다.
* [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) 및 [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) 메서드를 사용하여 기하 경로의 외관을 설정할 수 있습니다.
* [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) 메서드를 사용하면 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) 의 기하 경로를 경로 세그먼트 배열로 가져올 수 있습니다.
* 추가적인 도형 기하 맞춤 옵션에 접근하려면, [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 을 해당 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 로 읽고 세그먼트를 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 에 다시 적용할 수 있습니다.

## **간단한 편집 작업**

다음 메서드를 사용하여 기하 경로를 편집할 수 있습니다. 인덱스를 매개변수로 받는 오버로드는 경로 세그먼트 배열의 해당 0 기반 위치에 세그먼트를 삽입합니다.

| 작업 | Method |
| --- | --- |
| 직선 추가 또는 삽입. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| 두 개의 제어점과 끝점이 있는 3차 베지어 곡선 추가 또는 삽입. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 하나의 제어점과 끝점이 있는 2차 베지어 곡선 추가 또는 삽입. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 지정된 치수와 각도(도)로 타원 호 추가. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| 끝점을 시작점에 연결하여 현재 도형을 닫습니다. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| 도형의 시작점을 설정합니다. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| 0 기반 인덱스 위치의 세그먼트를 제거합니다. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **도형에 사용자 지정 점 추가**

이 예제에서는 [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) 를 사용하여 사각형 도형에 두 개의 점을 삽입하고, [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 로 편집된 경로를 적용합니다. 좌표는 도형에 대한 로컬 좌표이며, 두 새로운 점은 도형 중앙에 위치하고 왼쪽에서 100포인트, 위에서 50포인트 떨어져 있습니다. 세그먼트 인덱스 1과 4는 각각 위와 아래 가장자리에 배치되어 해당 가장자리를 안쪽으로 당깁니다.

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

## **도형에서 점 제거**

이 예제에서는 [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) 로 0 기반 인덱스 2에 해당하는 세그먼트를 제거하여 하트 모양 외곽선을 변경합니다. 수정된 경로를 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 로 적용하면 도형의 외곽선이 업데이트됩니다.

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

## **사용자 지정 도형 만들기**

이 예제에서는 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 를 사용하여 다섯 꼭지점 별을 만듭니다. 외부 반경 100포인트와 내부 반경 50포인트를 교대로 사용하여 별끝과 오목 부분을 정의하고, 72도 간격으로 다섯 꼭지점을 균일하게 배치합니다. 경로는 [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) 로 닫히며, [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 를 사용해 사각형 도형에 적용하여 기존 외곽선을 교체합니다.

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

## **복합 사용자 지정 도형 만들기**

이 예제에서는 도형의 상단 및 하단 3분의 1 영역에 대해 두 개의 닫힌 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 객체를 정의합니다. 두 경로를 [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) 로 적용하면 가운데 3분의 1에 틈이 있는 단일 복합 도형이 생성됩니다.

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

## **곡선 모서리가 있는 사용자 지정 도형 만들기**

이 예제는 직선 세그먼트와 [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) 를 결합하여 내부로 굽은 모서리를 가진 도형을 만듭니다. 각 모서리 크기는 호의 너비와 높이를 포인트 단위로 설정하고, -90도 스윕은 반시계 방향 사분원 호를 그립니다. 완성된 경로는 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 로 적용되며, 프레젠테이션은 PPTX 형식으로 저장됩니다.

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

## **도형 기하가 닫혀 있는지 확인하기**

다음 헬퍼는 모든 비어 있지 않은 기하 경로가 닫는 세그먼트로 끝나는지 확인합니다. [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) 를 읽고 최종 세그먼트의 [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) 를 [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) 와 비교합니다. 비어 있지 않은 경로가 없으면 false 를 반환합니다. 이 검사는 각 경로의 최종 명령만 확인하며, 경로 내의 모든 서브피규어를 검사하지는 않습니다. 예제에서는 사각형에 대해 `true` 를 출력합니다.

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

## **도형 요소 추출 및 검사**

[GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) 를 사용하여 기존 도형을 경로 점과 점 유형을 포함하는 요소로 검사합니다. 반환된 각 [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) 를 사용해 [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) 와 [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) 메서드로 점 및 유형 배열을 가져올 수 있습니다. 이 표현은 외곽선 분석이나 기하를 사용자 정의 그리기 도구에 전달할 때 유용합니다.

예제는 input.pptx 를 열어 첫 번째 슬라이드에서 첫 번째 기하 도형을 찾아 그 경로 세그먼트를 출력합니다. 직선 및 곡선 세그먼트를 포함한 도형이 있는 프레젠테이션을 사용하면 두 종류의 출력 모두를 확인할 수 있습니다. 그룹 내부는 검색하지 않습니다.

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
                        $i += 2; // 제어점 두 개와 끝점을 모두 소모합니다.
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

배열은 인덱스로 대응합니다: `$points[$i]` 는 점이며 `$types[$i]` 는 해당 역할을 설명합니다. 타입 `0` 은 도형 시작을 의미하고, 타입 `1` 은 이전 점에서 현재 점까지 선을 그립니다. 3차 베지어 세그먼트는 이전 끝점에서 시작하여 연속된 타입 `3` 항목 세 개(두 제어점과 새로운 끝점)를 사용합니다. 루프는 이 세 항목을 함께 처리하고 끝점이 닫혔는지 확인합니다.

점 유형에는 플래그도 포함됩니다. `0x07` 로 마스크하여 세그먼트 유형을 확인하고, `0x80` 을 별도로 테스트하여 닫힌 서브패스를 감지합니다. 예를 들어 `129`(`0x81`) 은 서브패스를 닫는 선 끝점이며, `131`(`0x83`) 은 서브패스를 닫는 베지어 끝점을 의미합니다. PHP/Java Bridge는 바이트 배열을 이진 문자열로 반환하며, "C*" 로 언팩하면 부호 없는 바이트 값을 얻습니다. 마스킹은 의도된 비트 값을 보존합니다. 원시 값을 `1` 또는 `3` 과만 비교하면 이러한 경우를 놓칠 수 있습니다. 대시(`0x10`)와 마커(`0x20`)와 같은 다른 플래그는 기본 세그먼트 유형을 변경하지 않습니다.

**좌표 및 변환.** 점은 포인트(1/72인치) 단위로 측정되며, X는 오른쪽으로, Y는 아래쪽으로 증가합니다. 그룹화되지 않은 도형의 경우, 추출된 좌표에는 이미 [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) 및 [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) 로 반환되는 위치가 포함되어 현재 너비와 높이를 반영합니다. 예를 들어 회전되지 않은 사각형이 `(100, 200)` 위치에 크기 `120 × 80`이면 외곽 경계는 `(100, 200)`–`(220, 280)` 입니다. 도형의 위치를 다시 추가하지 마세요. X와 Y를 빼서 회전되지 않은 프레임에 대한 상대 좌표를 얻습니다.

추출된 점은 [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) 로 반환되는 도형 회전이나 수평·수직 뒤집기를 적용하지 않습니다. 표시된 외곽선을 재현하려면 도형 중심을 기준으로 이러한 변환을 적용하세요. 그룹화된 도형의 경우, 그룹 좌표 매핑 및 변환도 고려해야 합니다; 추출된 점이 최종 슬라이드 좌표라고 가정하지 말고, 이미 자식 프레임에 반영된 경우 변환을 중복 적용하지 마세요.

**검사와 편집의 차이.** 추출된 배열은 외곽선을 설명하며, 이를 변경해도 원본 도형은 업데이트되지 않습니다. 분석이나 그리기 코드에 점/유형 배열이 필요한 경우 이 방식을 선택하십시오. 도형의 로컬 좌표계에서 기하 명령이 필요하거나 기하를 편집하려면 [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) 를 사용하십시오. 편집된 경로는 [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 혹은 [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) 로 적용합니다.

## **Java AWT Shape를 GeometryPath로 변환**

이 예제는 사각형 외곽선과 기하로 변환된 텍스트를 결합합니다. 외곽선의 [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) 메서드는 채우기를 비활성화합니다. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) 가 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 에 텍스트 윤곽을 만들고, 그 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 는 이동, 선, 2차, 3차 및 닫기 세그먼트를 제공하며, 예제에서는 이를 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 에 다시 적용합니다.

예제는 Java float 배열을 사용하여 PHP/Java Bridge가 이터레이터가 기록한 좌표를 유지하도록 합니다. 텍스트는 40포인트 Arial 글꼴을 사용합니다. 외곽선은 가로로 20포인트씩 오프셋되고, 시각적 상단이 도형 상단 가장자리 아래 10포인트에 배치됩니다. 텍스트 경로는 채워지며, 원래 사각형은 외곽선으로 남습니다. 두 경로를 [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) 로 적용하면 사각형과 텍스트를 포함하는 단일 도형이 생성됩니다.

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

## **자주 묻는 질문**

**기하를 교체한 후 채우기와 외곽선은 어떻게 되나요?**

스타일은 도형에 그대로 유지되며 외곽선만 변경됩니다. 채우기와 외곽선은 새로운 기하에 자동으로 적용됩니다.

**사용자 지정 도형을 기하와 함께 올바르게 회전하려면 어떻게 해야 하나요?**

[setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) 메서드를 사용하십시오; 기하가 도형에 연결되어 있기 때문에 회전하면 기하도 함께 회전합니다.

**결과를 '고정'시키기 위해 사용자 지정 도형을 이미지로 변환할 수 있나요?**

예. 필요한 [slide](/slides/ko/php-java/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/php-java/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하 작업을 더 간단히 할 수 있습니다.