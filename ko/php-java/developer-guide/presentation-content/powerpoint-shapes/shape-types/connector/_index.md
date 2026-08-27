---
title: 프레젠테이션에서 PHP를 사용하여 연결선 관리
linktitle: 연결선
type: docs
weight: 10
url: /ko/php-java/connector/
keywords:
- 연결선
- 연결선 유형
- 연결점
- 연결선 라인
- 연결선 각도
- 연결 사이트
- 조정점
- 도형 연결
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 연결선을 직선, 굽힘 및 곡선으로 추가, 부착, 재경로 지정, 조정 및 검사하는 방법을 배웁니다."
---
## **개요**

연결선은 두 도형 중 하나가 이동해도 두 도형에 계속 부착될 수 있는 선입니다. 끝은 PowerPoint에서 초록색 점으로 표시되는 연결 사이트에 부착됩니다. 일부 굽힘 및 곡선 연결선은 주황색 점으로 표시되는 조정 포인트를 노출하여 개별 연결선 세그먼트의 위치를 제어합니다.

Aspose.Slides는 연결선을 [Connector](https://reference.aspose.com/slides/ko/php-java/aspose.slides/connector/) 클래스로 나타냅니다. 연결선을 만들고, 끝을 도형에 부착하고, 연결 사이트를 선택하고, 경로를 다시 지정하며, 조정 포인트가 있는 연결선의 기하학을 수정할 수 있습니다.

## **연결선 유형**

[ShapeType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapetype/) 클래스에는 직선, 굽힘 및 곡선 연결선 프리셋이 포함되어 있습니다. 다음 표는 사용 가능한 연결선 기하학과 각 프리셋이 정의하는 조정 포인트 수를 보여줍니다.

| 연결선 | 이미지 | 조정 포인트 수 |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) |  1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

조정 포인트의 수와 의미는 선택한 연결선 프리셋에 포함됩니다. 두 개의 다른 연결선 유형이 동일한 컬렉션 레이아웃을 노출한다는 가정을 하지 마세요.

## **두 도형 연결**

[ShapeCollection::addConnector](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addconnector/)을 사용해 연결선을 추가하고, [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/connector/setstartshapeconnectedto/)와 [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/connector/setendshapeconnectedto/)를 사용해 양쪽 끝을 부착합니다. 양쪽 끝이 모두 부착된 후에는 [Connector::reroute](https://reference.aspose.com/slides/ko/php-java/aspose.slides/connector/reroute/)가 도형 사이의 짧은 경로를 선택합니다.

다음 예제는 타원과 사각형을 굽힘 연결선으로 연결합니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    $connector->reroute();

    $presentation->save("connected-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="경고" %}}
`reroute`를 호출하면 [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) 및 [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/) 값이 변경될 수 있습니다. 해당 사이트가 고정되어야 하는 경우 다시 경로를 지정한 뒤에 특정 연결 사이트를 할당하세요.
{{% /alert %}}

## **연결 지점 선택**

연결 가능한 각 도형은 [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getconnectionsitecount/)를 통해 사이트 수를 보고합니다. 연결선 끝에 할당하기 전에 선호하는 0 기반 사이트 인덱스를 검증하세요; 사이트 수는 도형 기하학에 따라 다릅니다.

다음 예제는 해당 사이트가 존재할 때 타원의 특정 사이트에 연결선을 부착합니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);

    $preferredSiteIndex = 2;
    $connectionSiteCount = java_values($ellipse->getConnectionSiteCount());
    if ($preferredSiteIndex < $connectionSiteCount) {
        $connector->setStartShapeConnectionSiteIndex($preferredSiteIndex);
    } else {
        echo "The ellipse has only " . $connectionSiteCount . " connection sites." . PHP_EOL;
    }

    $presentation->save("specific-connection-site.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **연결선 포인트 조정**

조정 포인트가 있는 연결선은 [GeometryShape::getAdjustments](https://reference.aspose.com/slides/ko/php-java/aspose.slides/geometryshape/#getadjustments)를 통해 노출됩니다. 각 [AdjustValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/adjustvalue/)를 검사하고, [AdjustValue::getType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/adjustvalue/#gettype) 값을 확인한 뒤에 [AdjustValue::setRawValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/adjustvalue/setrawvalue/)로 값을 변경하세요. 프리셋 도형 조정에 대한 일반 규칙은 [Shape Manipulation](/slides/ko/php-java/shape-manipulations/)에 설명되어 있습니다.

조정 포인트의 수, 순서, 의미 및 유효값 범위는 연결선 프리셋에 따라 달라집니다. 조정 유형은 읽기 전용이며, 조정 값은 쓰기 가능합니다. 동일한 의미 유형이 여러 개 있을 때 추가 식별을 제공하는 읽기 전용 [AdjustValue::getName](https://reference.aspose.com/slides/ko/php-java/aspose.slides/adjustvalue/getname/) 메서드를 활용하세요.

### **장애물 우회**

다음 레이아웃에서 두 도형 사이의 `BentConnector5` 연결선이 세 번째 도형을 통과합니다:

![connector-obstruction](connector-obstruction.png)

이 코드는 방해받는 연결선을 생성합니다:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $presentation->save("connector-obstruction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

수직 굽힘을 이동하면 경로가 변경되어 연결선이 장애물을 우회합니다:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

컬렉션 인덱스 `1`이 항상 수직 굽힘을 나타낸다고 가정하는 대신, 이 예제는 `ConnectorBendPositionY`를 검색하고 예상 의미 유형이 존재할 때만 값을 변경합니다:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentName = java_values($adjustment->getName());
        $adjustmentType = java_values($adjustment->getType());
        $rawValue = java_values($adjustment->getRawValue());
        echo $adjustmentName . ": " . $adjustmentType . ", raw value = " . $rawValue . PHP_EOL;
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
            break;
        }
    }

    if ($verticalBend === null) {
        echo "The connector does not expose a vertical bend adjustment." . PHP_EOL;
    } else {
        $verticalBend->setRawValue(60000);
        $presentation->save("connector-obstruction-fixed.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

`BentConnector5`에는 `ConnectorBendPositionX` 조정이 두 개, `ConnectorBendPositionY` 조정이 하나 있습니다. 필요한 유형이 여러 번 나타나는 경우 `getName`과 해당 프리셋의 알려진 기하학을 검사한 뒤에 선택하세요. 조정이 `ShapeAdjustmentType::Custom`을 보고한다면 해당 의미와 범위는 프리셋 전용이며 계약이 명확해질 때까지 변경하지 마세요.

## **조정 값과 연결선 기하학 연관**

굽힘 연결선의 경우, 조정 값을 사용해 개별 세그먼트 위치를 추정할 수 있습니다. 이러한 계산은 연결선 프리셋마다 다릅니다:

- `BentConnector4`는 일반적으로 `ConnectorBendPositionX`와 `ConnectorBendPositionY` 조정 하나씩을 노출합니다.
- 이러한 굽힘 위치에 대해 `getRawValue`가 반환하는 값을 `100000`으로 나누면 아래 예제에서 사용되는 연결선 프레임 너비 또는 높이의 비율이 됩니다.
- 연결선 프레임은 회전되거나 뒤집힐 수 있으므로 프레임 좌표를 슬라이드 좌표와 비교하기 전에 변환해야 합니다.

다음 예제는 먼저 `getType`을 사용해 조정을 식별합니다. 컬렉션 인덱스를 휴대용 식별자로 사용하지 않습니다.

### **회전되지 않은 연결선**

초기 레이아웃에는 `BentConnector4`로 연결된 두 텍스트 도형이 포함됩니다:

![connector-shape-complex](connector-shape-complex.png)

이 예제는 연결선을 검사하고 수평 및 수직 굽힘 조정을 가져옵니다:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $targetShape->getTextFrame()->setText("To");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        echo $adjustment->getName() . ": " . $adjustment->getType() . ", raw value = " . $adjustment->getRawValue() . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

두 굽힘을 모두 변경하려면 각 예상 유형을 찾아 두 값을 모두 찾은 후에 수정하세요:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);
        $presentation->save("connector-adjusted.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

그 결과 수평 및 수직 세그먼트가 이동한 연결선이 표시됩니다:

![connector-adjusted-1](connector-adjusted-1.png)

의미 유형이 알려지면 값을 연결선 프레임 좌표로 변환할 수 있습니다. 이 예제는 두 굽힘 조정이 제어하는 수직 세그먼트 위에 얇은 사각형을 그립니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $x = $connectorX + $connectorWidth * $horizontalBendValue / 100000;
        $y = $connectorY;
        $height = $connectorHeight * $verticalBendValue / 100000;
        $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 1, $height);
        $presentation->save("connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

가이드 도형은 계산된 세그먼트를 표시합니다:

![connector-adjusted-2](connector-adjusted-2.png)

### **회전 또는 뒤집힌 연결선**

동일한 연결선 기하학이 수직으로 배치될 때, [Shape::getFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapeframe/getfliph/), [ShapeFrame::getFlipV](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapeframe/getflipv/) 값이 연결선 프레임 좌표에서 슬라이드 좌표로의 변환에 영향을 줍니다.

이 예제는 수직으로 배치된 연결선을 생성하고 조정합니다:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $targetShape->getTextFrame()->setText("To 1");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(102, 205, 170));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 20000);
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 200000);
        }
    }

    $presentation->save("vertical-connector-adjusted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

조정된 연결선이 도형 사이에 수직으로 표시됩니다:

![connector-adjusted-3](connector-adjusted-3.png)

임의의 회전 각도 `alpha`에 대해 연결선 프레임 점 `(x, y)`를 프레임 중심 `(x0, y0)` 주위로 회전하면:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`
`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

다음 코드는 이 예제에서 사용된 90도 방향을 처리하고 해당 연결선 세그먼트 위에 빨간색 가이드를 그립니다:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);

        $frame = $connector->getFrame();
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $flipH = java_values($frame->getFlipH()) == NullableBool::True;
        $flipV = java_values($frame->getFlipV()) == NullableBool::True;
        $centerX = java_values($frame->getCenterX());
        $centerY = java_values($frame->getCenterY());

        $x = $connectorX;
        $y = $connectorY;
        if ($flipH) {
            $x += $connectorWidth;
        }
        if ($flipV) {
            $y += $connectorHeight;
        }

        $x += $connectorWidth * $horizontalBendValue / 100000;
        $rotatedX = $centerX - $y + $centerY;
        $rotatedY = $x - $centerX + $centerY;
        $segmentWidth = $connectorHeight * $verticalBendValue / 100000;
        $guide = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $rotatedX, $rotatedY, $segmentWidth, 1);
        $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));

        $presentation->save("rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

좌표 변환 후 빨간 가이드는 계산된 세그먼트를 표시합니다:

![connector-adjusted-4](connector-adjusted-4.png)

이 공식들은 예제에 사용된 프리셋을 설명할 뿐, 보편적인 연결선 모델을 정의하지 않습니다. 다른 프리셋에 동일한 계산을 적용하기 전에 조정 유형, 프레임 방향 및 값 범위를 반드시 검증하세요.

## **연결선 방향 각도 찾기**

직선 연결선의 방향은 너비와 높이에서 계산할 수 있으며, 수평 및 수직 뒤집기가 적용됩니다. 다음 예제는 슬라이드 좌표계에서 양의 수평 축을 기준으로 시계 방향 각도를 보고합니다:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);

    $frame = $connector->getFrame();
    $flipH = java_values($frame->getFlipH()) == NullableBool::True;
    $flipV = java_values($frame->getFlipV()) == NullableBool::True;
    $width = java_values($connector->getWidth());
    $height = java_values($connector->getHeight());
    $deltaX = $width * ($flipH ? -1 : 1);
    $deltaY = $height * ($flipV ? -1 : 1);
    $angle = atan2($deltaY, $deltaX) * 180.0 / pi();

    if ($angle < 0) {
        $angle += 360;
    }

    printf("Connector direction: %.2f degrees%s", $angle, PHP_EOL);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**연결선이 도형에 부착될 수 있는지 어떻게 확인할 수 있나요?**

도형의 [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getconnectionsitecount/) 값을 확인하세요. 양수이면 도형이 연결 사이트를 공개한다는 의미입니다. 연결선 끝에 할당하기 전에 선택한 사이트 인덱스를 검증하세요.

**컬렉션 인덱스로 연결선 조정을 식별할 수 있나요?**

인덱스는 알려진 연결선 프리셋 및 컬렉션 레이아웃에 대해서만 의미가 있습니다. 값을 수정하기 전에 [AdjustValue::getType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/adjustvalue/#gettype)을 확인하고, 동일한 의미 유형이 여러 번 나타날 경우 추가 정보로 [AdjustValue::getName](https://reference.aspose.com/slides/ko/php-java/aspose.slides/adjustvalue/getname/)을 활용하세요.

**연결된 도형이 삭제되면 어떻게 되나요?**

해당 연결선 끝이 분리됩니다. 연결선은 슬라이드에 남아 있으며, 삭제하거나 자유 선으로 배치하거나 다른 도형에 다시 부착할 수 있습니다.

**슬라이드를 복사할 때 연결선 바인딩이 유지되나요?**

연결된 도형과 함께 슬라이드를 복사하면 바인딩이 일반적으로 유지됩니다. 연결선만 복사하고 대상 도형 중 하나가 없을 경우, 해당 끝을 다시 부착해야 합니다.