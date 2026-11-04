---
title: "PHP에서 PowerPoint 도형 서식 지정"
linktitle: "도형 서식"
type: docs
weight: 20
url: /ko/php-java/shape-formatting/
keywords:
- 도형 서식
- 선 서식
- 스케치 효과
- 스케치 도형 선
- 조인 스타일 서식
- 그라디언트 채우기
- 패턴 채우기
- 사진 채우기
- 텍스처 채우기
- 단색 채우기
- 도형 투명도
- 흑백 도형 렌더링
- 그레이스케일 도형 렌더링
- 도형 회전
- 3d 베벨 효과
- 3d 회전 효과
- 서식 초기화
- PowerPoint
- 프리젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 PowerPoint 도형을 서식 지정하는 방법을 배우세요—PPT 및 PPTX 파일의 채우기, 선 및 효과 스타일을 정밀하고 완전하게 제어합니다."
---
## **소개**

PowerPoint에서 도형의 윤곽선, 채우기 및 효과를 조정하여 도형을 형식화합니다. Aspose.Slides for PHP via Java를 사용하면 투명도, 회전 및 3D 형식화를 포함한 이러한 설정을 프로그래밍 방식으로 제어할 수 있습니다.

![PowerPoint에서 도형 서식 옵션](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java는 PowerPoint에서 제공되는 동일한 옵션을 사용하여 도형을 형식화할 수 있는 클래스와 메서드를 제공합니다.

## **선 서식**

[Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) 를 사용하여 도형의 윤곽선을 제어합니다. 이 예제는 파란색 점선 윤곽선을 가진 채워지지 않은 사각형을 만듭니다. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) 은 굵고 얇은 복합 선을 선택하고, [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) 은 너비를 7포인트로 설정하며, [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) 은 대시 패턴을 선택합니다.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![프레젠테이션에서 서식이 지정된 선](formatted-lines.png)

### **맞춤 선 대시 패턴 설정**

미리 정의된 선 스타일이 필요한 대시 길이와 간격을 제공하지 않을 때, 예를 들어 브랜드 윤곽선이나 기술 다이어그램에 사용하려면 [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) 을 사용합니다. 패턴을 지정하면 선 대시 스타일이 자동으로 [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) 으로 변경됩니다.

배열 항목은 대시와 간격 길이가 교대로 나타나며 대시부터 시작합니다. 각 값은 선 너비의 배수입니다: 너비가 3포인트일 때 `[4, 2]` 는 12포인트 대시 뒤에 6포인트 간격을 만듭니다. 완전한 대시‑간격 구간을 정의하려면 유한하고 음수가 아닌 값 쌍을 사용합니다. 예제에서는 모든 대시와 간격이 보이도록 양의 값을 사용했습니다.

이 예제는 동일한 길이와 플랫 캡을 가진 파란색 선 5개를 만듭니다. 처음 세 개는 너비 3포인트에서 패턴을 비교합니다. 네 번째는 첫 번째 패턴을 두 배 너비로 반복하여 대시와 간격 길이를 두 배로 늘립니다. 마지막은 맞춤 패턴에서 실선으로 전환합니다.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // 마지막 선을 실선 스타일로 설정합니다.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

미리 정의된 점선 스타일로 돌아가려면 [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) 을 [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) 에 전달하십시오. 선택된 스타일이 선의 외관을 제어합니다.

PowerPoint에서 위에서 아래 순서로 표시되는 결과: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; 그리고 **Solid, 3 pt**.

![맞춤 대시 패턴 3개, 첫 번째 패턴을 사용한 더 넓은 선, 및 PowerPoint의 실선](custom-dash-patterns.png)

### **선 캡 설정**

[LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) 를 사용하여 열린 선의 끝을 설정합니다. [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) 클래스는 세 가지 명시적 캡 스타일을 제공합니다:

- `Flat`: 스트로크가 끝점에서 멈춥니다.
- `Round`: 반원형 캡이 선 너비의 절반만큼 끝점을 넘어 확장됩니다.
- `Square`: 정사각형 캡이 선 너비의 절반만큼 끝점을 넘어 확장됩니다.

클래스에는 `NotDefined` 도 포함되어 있으며, 이는 캡 스타일이 명시적으로 지정되지 않았음을 의미합니다.

캡은 선 끝에 기호를 추가하는 화살표와, 선 세그먼트 사이의 모서리를 제어하는 조인과는 다릅니다. 이 예제는 [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) 와 [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) 을 사용해 화살표를 비활성화하고 캡 모양만 비교합니다.

다음 예제는 너비 20포인트인 동일한 수평 선 세 개를 생성합니다. 위에서 아래 순서대로 플랫, 라운드, 스퀘어 캡을 사용합니다. 끝점의 가로 좌표는 동일하지만 라운드와 스퀘어 캡은 각 끝점에서 10포인트씩 확장됩니다.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint에서 위에서 아래 순서대로 표시되는 결과: **Flat**, **Round**, **Square**.

![PowerPoint에서 동일한 두꺼운 선에 대한 플랫, 라운드 및 스퀘어 캡](line-caps.png)

## **도형 선에 스케치 효과 적용**

스케치 효과는 도형 선을 손으로 그린 것처럼 보이게 합니다. [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) 로 선 설정에 접근하고, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) 로 스케치 설정에 접근한 다음, [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) 로 [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) 클래스에서 값을 선택합니다.

다음 PHP 코드는 [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) 효과를 적용하고, 명시적으로 지정된 값을 읽으며, [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) 으로 효과를 제거하는 방법을 보여줍니다.

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

[SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) 이 반환하는 값은 도형에 직접 할당된 설정을 나타냅니다. 선 서식이 테마, 마스터 슬라이드 또는 레이아웃 슬라이드에서 상속될 수 있는 경우, [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective) 를 사용하고 반환된 객체의 `getSketchFormat` 메서드에 접근한 뒤 `getSketchType` 값을 읽습니다. 유효 값은 상속이 해결된 후 실제로 적용되는 서식을 반영합니다. 이 예제는 첫 번째 슬라이드에 최소 하나의 도형이 있는 기존 프레젠테이션을 요구하며 두 값을 모두 출력합니다:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $lineFormat = $shape->getLineFormat();
    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **조인 스타일 서식**

다음은 세 가지 조인 유형 옵션입니다:

* Round
* Miter
* Bevel

조인 스타일은 모서리에서 두 윤곽선 세그먼트가 만나는 방식을 제어합니다. 둥근 모서리에는 **Round**, 뾰족한 모서리에는 **Miter**, 평평한 모서리에는 **Bevel** 을 사용합니다.

![프레젠테이션의 조인 스타일](join-style-powerpoint.png)

이 예제는 파란색 윤곽선이 15포인트인 검은색 사각형 세 개를 만듭니다. 각각 [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) 를 [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) 의 miter, bevel, round 값으로 설정하여 모서리가 어떻게 그려지는지 비교합니다.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **뾰족한 모서리에서 Miter 조인 제한**

[LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) 를 [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) 로 설정한 상태에서 [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) 를 사용하면 뾰족한 모서리가 얼마나 멀리까지 뻗을 수 있는지를 제한합니다.

제한은 조인의 내부와 외부 모서리 사이 거리와 선 너비의 비율입니다. 예를 들어 값 `8` 은 선 너비의 최대 8배까지 miter 길이를 허용합니다; 이는 포인트 단위 측정이 아닙니다. 모서리가 제한을 초과하면 PowerPoint는 해당 모서리에서 베벨 조인을 사용합니다. 더 큰 제한은 더 뾰족한 점을 허용합니다. 이 설정은 miter 조인에만 영향을 미치며, 모서리가 두 제한 모두 내에 있을 때는 눈에 보이는 변화가 없습니다.

이 예제는 윤곽선이 20포인트인 동일한 무채색 삼각형 두 개를 만듭니다. 왼쪽 삼각형은 제한 `2` 를, 오른쪽은 `8` 을 사용합니다. 각 삼각형은 너비 80포인트, 높이 160포인트이며, 상단 모서리의 miter‑length‑to‑line‑width 비율은 약 `4.12` 입니다. 따라서 PowerPoint는 왼쪽 꼭짓점을 베벨 처리하고 오른쪽 꼭짓점은 유지합니다.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint에서의 결과: 왼쪽은 **Miter limit 2**, 오른쪽은 **miter limit 8**.

![PowerPoint에서 Miter limit 2가 적용된 베벨 꼭짓점과 Miter limit 8이 적용된 뾰족한 꼭짓점](miter-limits.png)

## **그라디언트 채우기**

그라디언트 채우기는 도형 전체에 색상을 혼합합니다. 이 예제는 [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) 을 사용하여 빨간색에서 보라색으로 45도 각도의 선형 그라디언트로 타원을 채웁니다. [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) 메서드는 그라디언트 시작점(0)과 끝점(1)에 색상 정지를 배치합니다. 기존 정지를 삭제하면 이 두 색상만 사용됩니다.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![그라디언트 채우기가 적용된 타원](gradient-fill.png)

내보낸 이미지에서 그라디언트가 PowerPoint와 다르게 보이는 경우, [Choose a Gradient Rendering Style](/slides/ko/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) 를 참조하십시오. 프레젠테이션에 저장된 그라디언트 채우기를 변경하지 않고 렌더링 스타일만 선택할 수 있습니다.

### **선형 그라디언트 각도 설정**

[GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) 을 사용하여 [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) 채우기의 방향을 제어합니다. 각도는 도 단위이며 시계 방향으로 증가합니다: `0` 은 왼쪽에서 오른쪽, `90` 은 위에서 아래, `180` 은 오른쪽에서 왼쪽, `270` 은 아래에서 위로 흐릅니다. 소수 각도도 지원됩니다. `[0, 360)` 범위를 벗어나는 유한 각도는 한 바퀴로 정규화됩니다; 예를 들어 `-45` 는 `315` 로, `360` 은 `0` 으로 변환됩니다.

이 예제는 동일한 빨강, 초록, 파랑 정지를 위치 `0`, `0.5`, `1` 에 두고 여섯 개의 사각형을 만듭니다. 각도 비교가 사각형 비율과 무관하도록 스케일링을 비활성화했습니다. 각도는 왼쪽에서 오른쪽으로 첫 번째 행에 `0`, `45`, `90`, 두 번째 행에 `135`, `180`, `270` 순입니다.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint에서의 결과:

![위 행에 0, 45, 90도, 아래 행에 135, 180, 270도 선형 그라디언트](linear-gradient-angles.png)

### **도형에 선형 그라디언트 스케일 적용**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) 은 [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) 값을 받습니다. `False` 로 명시하면 도형 비율이 변해도 기하학적 그라디언트 각도가 유지되고, `True` 로 설정하면 도형의 너비와 높이에 따라 그라디언트가 스케일됩니다. 스케일링이 활성화되면 비정사각형 도형에서 보이는 각도가 할당된 각도와 달라질 수 있습니다.

다음 예제는 `45`도 각도와 앞서와 동일한 색상 정지를 사용합니다. 왼쪽 열은 `False`, 오른쪽 열은 `True` 로 설정합니다. 각 열에는 넓은 사각형 위에 높은 사각형이 있습니다. 두 번째 사각형의 너비와 높이를 변경하면 색상 채우기가 리사이징에 어떻게 반응하는지 확인할 수 있습니다.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint에서의 결과: 왼쪽은 스케일링 비활성화, 오른쪽은 스케일링 활성화:

![왼쪽은 LinearGradientScaled False, 오른쪽은 True인 45도 그라디언트가 적용된 넓은 사각형과 높은 사각형](linear-gradient-scaling.png)

스케일링이 비활성화되면 두 사각형 모두 대각선 색 밴드 방향이 동일하게 유지됩니다. 스케일링이 활성화되면 밴드가 도형 비율에 맞게 늘어납니다. 이는 다른 크기로 도형을 조정할 때 템플릿의 그라디언트를 재현하는 데 도움이 됩니다. 정사각형에서는 스케일링을 활성화해도 `45`도 그라디언트의 외관이 변하지 않습니다.

각도와 스케일 설정은 모두 선형 그라디언트에만 적용되며, [GradientShape::Radial] 또는 [GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) 채우기에는 영향을 주지 않습니다.

### **각도와 그라디언트 방향 결합**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) 은 [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/) 클래스에서 그라디언트 스타일을 선택하며, 숫자 각도의 대체가 아닙니다. 선형 그라디언트의 경우, 코너 스타일이 색상이 배분되는 영역을 바꿀 수 있지만 [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) 로 할당된 각도는 변하지 않습니다. 각도 또는 스케일을 비교할 때 방향은 변경하지 마십시오.

다음 예제는 같은 설정을 순서를 바꿔 적용합니다. 두 사각형은 동일하게 보이며, 방향을 각도 전에 적용하든 후에 적용하든 결과가 바뀌지 않습니다.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **패턴 채우기**

패턴 채우기는 점, 줄무늬, 체크 등 두 색상의 디자인을 적용합니다. 이 예제는 [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) 로 격자 패턴을 선택하고, [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) 로 연회색 배경을, [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) 로 노란색 패턴 색을 지정합니다.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![패턴 채우기가 적용된 사각형](pattern-fill.png)

## **그림 채우기**

그림 채우기는 도형 내부에 이미지를 사용합니다. 이 예제는 로컬 이미지를 필요로 하며, [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) 로 프레젠테이션의 이미지 컬렉션에 로드합니다. [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) 를 타일 모드로 설정하면 이미지가 사각형 내부에 반복됩니다. 사용된 원본 이미지는 아래에 표시됩니다:

![연꽃 사진](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![그림 채우기가 적용된 도형](picture-fill.png)

### **텍스처로 타일 그림 사용**

타일 그림을 텍스처로 설정하고 타일링 동작을 사용자 정의하려면 [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) 클래스의 다음 메서드를 사용할 수 있습니다:

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): 그림 채우기 모드를 `Tile` 또는 `Stretch` 로 설정합니다.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): 도형 내 타일 정렬을 지정합니다.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): 타일을 수평, 수직 또는 모두 뒤집을지 제어합니다.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): 도형 원점으로부터 타일의 가로 오프셋(포인트)을 설정합니다.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): 도형 원점으로부터 타일의 세로 오프셋(포인트)을 설정합니다.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): 타일의 가로 스케일을 백분율로 정의합니다.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): 타일의 세로 스케일을 백분율로 정의합니다.

이 예제는 로컬 이미지를 필요로 하며, 원본 크기의 50% 로 반복하도록 [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) 을 구성합니다. `-32` 포인트 오프셋으로 타일을 가로·세로로 이동하고, 오른쪽 아래 정렬 및 양방향 플립으로 반복 텍스처 배치를 결정합니다.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![타일 옵션](tile-options.png)

## **단색 채우기**

단색 채우기는 도형에 단일, 균일한 색을 적용합니다. 이 예제는 [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) 을 단색 채우기 모드로 설정하고, [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) 로 노란색을 할당한 뒤 사각형을 프레젠테이션에 저장합니다.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![단색 채우기가 적용된 도형](solid-color-fill.png)

## **슬라이드 배경을 도형 채우기로 사용**

슬라이드 배경과 일치하도록 도형을 만들고 싶을 때, 예를 들어 프레젠테이션 템플릿에서, [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) 을 사용합니다. 먼저 [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) 을 [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 로 설정하여 명시적 채우기를 제거합니다. 이렇게 하면 도형은 스타일 채우기 대신 슬라이드 배경을 사용합니다. 플래그만 활성화해도 기존 명시적 채우기는 제거되지 않습니다.

이는 [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 와는 다릅니다. 배경 채우기는 도형 뒤의 객체를 슬라이드 배경 영역으로 가려주지만, NoFill 은 해당 객체를 표시합니다. 그라디언트는 도형 내부에서 다시 시작하는 것이 아니라 슬라이드와 정렬됩니다.

다음 예제는 슬라이드가 상속받는 마스터 배경을 만들고, 세 개의 사각형 뒤에 마젠타 밴드를 배치합니다. 왼쪽 사각형은 배경을 사용하고, 가운데 사각형은 채우기가 없으며, 오른쪽 사각형은 배경 채우기에서 명시적 주황색 채우기로 전환합니다.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // 마스터에서 그라디언트를 상속합니다.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // 이 객체를 먼저 추가하면 사각형 뒤에 나타납니다.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // 명시적 채우기를 적용하기 전에 배경 채우기를 비활성화합니다.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과 (왼쪽→오른쪽): **배경 채우기**, **채우기 없음**, **명시적 채우기**. 마젠타 밴드는 왼쪽과 오른쪽 사각형 뒤에 가려지지만 가운데 사각형을 통해서는 보입니다.

![마젠타 밴드 위에 배경 채우기, 채우기 없음, 명시적 주황색 채우기](background-fill.png)

동일한 동작은 슬라이드에 직접 정의된 배경이나 레이아웃에서 상속된 배경에도 적용됩니다. 도형은 슬라이드의 해결된 배경을 사용합니다; 예제는 슬라이드와 레이아웃 배경을 모두 정의하지 않아 마스터가 제공하도록 합니다.

## **투명도 설정**

단색 채우기의 경우 색상의 알파 구성 요소가 불투명도를 제어합니다: 0은 완전 투명, 255는 완전 불투명합니다. 이 예제는 알파 값 128을 사용하여 노란색 사각형을 약 50% 투명하게 만들어 아래쪽 사각형이 보이도록 합니다. 색상은 [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) 로 할당됩니다.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![투명한 도형](shape-transparency.png)

## **도형 회전**

[Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) 을 사용하여 슬라이드 평면에서 도형을 회전시킵니다. 각도는 도 단위이며, 이 예제는 사각형을 시계 방향으로 5도 회전하고 프레젠테이션을 저장합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![도형 회전](shape-rotation.png)

## **3D 베벨 효과 추가**

[Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) 을 사용하여 도형에 깊이와 베벨 가장자리를 추가합니다. 이 예제는 녹색 타원을 주황색 윤곽선과 함께 만들고, [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) 를 4포인트로 설정하며, [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) 을 통해 너비와 높이가 6포인트인 원형 상단 베벨을 적용합니다. 앞면 직교 카메라와 삼점 조명이 베벨을 보이게 합니다.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![3D 베벨 효과](3D-bevel-effect.png)

## **3D 회전 효과 추가**

도형의 3D 뷰는 카메라 설정으로 제어됩니다. 이 예제는 [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) 에 위도, 경도, 회전 각도를 각각 40°, 35°, 20° 로 적용합니다. [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) 로 등각 카메라를 선택하고, [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) 로 균형 조명을 선택한 뒤 서식이 적용된 사각형을 저장합니다.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![3D 회전 효과](3D-rotation-effect.png)

## **도형의 흑백 렌더링 제어**

[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) 메서드는 프레젠테이션을 흑백 모드로 보거나 처리할 때 개별 도형이 어떻게 렌더링되는지 지정합니다. 이 메서드만으로 흑백 표시가 활성화되지는 않으며, 일반 색상 모드에서 도형의 채우기, 선 또는 기타 서식을 변경하지도 않습니다.

[BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) 클래스의 값을 사용하여 원하는 동작을 선택합니다. 예를 들어 `Automatic` 은 렌더링 애플리케이션이 변환 방식을 선택하도록 하고, `Gray` 와 `LightGray` 는 회색 색조를 사용하며, `BlackWhite` 은 검정·흰색만 사용하고, `Black` 과 `White` 는 단일 색을 강제하고, `Color` 는 일반 색상을 유지하며, `Hidden` 은 흑백 모드에서 도형을 생략합니다. `NotDefined` 는 도형 수준 모드가 지정되지 않았음을 의미합니다.

이 예제는 주황색 사각형을 만들고 [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) 을 `Gray` 로 설정합니다. 저장된 도형은 일반 색상 표시에서는 주황색 채우기를 유지하고, 흑백 표시를 지원하는 애플리케이션에서는 회색 색조를 요청합니다:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

일반 색상 모드에서는 사각형이 주황색 채우기를 유지합니다. 흑백 표시 워크플로에서는 모드가 `Gray` 로 설정되었기 때문에 회색 색조를 사용합니다. 이를 통해 전체 색상 슬라이드를 유지하면서 인쇄, 미리 보기 또는 흑백 표시 설정을 따르는 다른 워크플로에 대해 별도 외관을 정의할 수 있습니다.

## **서식 초기화**

[Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) 을 사용하면 레이아웃 자리 표시자와 연결된 슬라이드 자리 표시자의 위치, 크기 및 서식을 복원합니다. 이 예제는 레이아웃에 연결된 자리 표시자가 있는 기존 프레젠테이션이 필요하며, 저장하기 전에 모든 슬라이드를 초기화합니다. 해당 레이아웃 자리 표시자가 없는 도형은 초기화되지 않습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**도형 서식이 최종 프레젠테이션 파일 크기에 영향을 줍니까?**

색상, 선 스타일 및 효과 설정은 일반적으로 삽입된 이미지와 미디어에 비해 데이터가 거의 추가되지 않습니다. 그림 채우기는 이미지가 프레젠테이션에 저장되기 때문에 파일 크기를 증가시킬 수 있습니다.

**동일한 서식을 공유하는 슬라이드의 도형을 어떻게 감지하여 그룹화할 수 있습니까?**

각 도형의 핵심 서식 속성(채우기, 선, 효과 설정)을 비교하십시오. 모든 해당 값이 일치하면 스타일이 동일하다고 판단하고 논리적으로 해당 도형을 그룹화하면 이후 스타일 관리가 간소화됩니다.

**맞춤 도형 스타일을 별도 파일에 저장하여 다른 프레젠테이션에서 재사용할 수 있습니까?**

예. 원하는 스타일이 적용된 샘플 도형을 템플릿 슬라이드 세트 또는 .POTX 템플릿 파일에 저장합니다. 새 프레젠테이션을 만들 때 템플릿을 열고 필요한 스타일 도형을 복제한 뒤 필요한 곳에 서식을 다시 적용합니다.