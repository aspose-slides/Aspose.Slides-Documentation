---
title: PHP를 사용하여 프레젠테이션에 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/php-java/3d-presentation/
keywords:
- 3D 파워포인트
- 3D 프레젠테이션
- 3D 회전
- 3D 깊이
- 3D 돌출
- 3D 그라디언트
- 3D 텍스트
- 파워포인트
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 돌출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for PHP via Java는 도형과 텍스트에 대한 PowerPoint 스타일 3D 서식을 생성, 편집, 보존 및 렌더링할 수 있습니다. 이 문서에서는 회전, 돌출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기, 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" title="참고" %}}
이 문서는 PowerPoint 도형과 텍스트에 대한 3D 서식 효과에 대한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함하지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

[Shape::getThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getThreeDFormat--) 메서드를 사용하여 도형에 3D 서식을 적용합니다. 이 메서드는 해당 도형의 3D 장면을 제어하는 [ThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/)을 반환합니다.

텍스트의 경우 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/#getThreeDFormat--) 메서드를 사용합니다. 이는 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 API 멤버는 다음과 같습니다:

| API 멤버 | 제어하는 항목 | 사용 시점 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getCamera--) | 시점, 사전 설정 카메라 유형, 회전, 줌 및 원근. | 객체를 3D 공간에서 회전하거나 PowerPoint 3D 회전 사전 설정에 맞출 때. |
| [getLightRig](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getLightRig--) | 조명 사전 설정, 방향 및 조명 회전. | 3D 표면에서 하이라이트와 그림자가 나타나는 방식을 변경할 때. |
| [getMaterial](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getMaterial--) 및 [setMaterial](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setMaterial-byte-) | 표면 재질, 예: 평면, 매트, 플라스틱 또는 금속. | 동일한 기하학을 더 평평하게, 부드럽게, 광택 있게 또는 금속성으로 보이게 할 때. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getExtrusionHeight--) 및 [setExtrusionHeight](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | 도형이 앞면에서 뒤쪽으로 얼마나 확장되는지. | 평면 도형을 눈에 보이는 두꺼운 3D 객체로 변환할 때. |
| [getExtrusionColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getExtrusionColor--) | 돌출된 측면의 색상. | 깊이를 보이게 하거나 측면 색을 앞면 채우기와 일치시킬 때. |
| [getDepth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getDepth--) 및 [setDepth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setDepth-double-) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 베벨 및 재질 설정과 함께 도형이나 텍스트의 깊이를 미세 조정할 때. |
| [getBevelTop](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getBevelTop--) 및 [getBevelBottom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getBevelBottom--) | 앞면과 뒷면의 돌출되거나 둥근 가장자리. | 날카로운 평면 대신 부드럽거나 몰딩된 가장자리를 추가할 때. |
| [getContourColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getContourColor--) 및 [getContourWidth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getContourWidth--) 및 [setContourWidth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setContourWidth-double-) | 3D 객체 주위의 외곽선. | 렌더링된 출력에서 객체 경계를 강조할 때. |

## **3D 도형 만들기**

도형이 설득력 있게 3D로 보이려면 일반적으로 네 가지 설정이 필요합니다:

- 카메라 설정, 기본 전면 뷰가 돌출을 숨길 수 있기 때문에.
- 조명 설정, 조명이 면과 측면을 읽기 쉽게 만들기 때문에.
- 재질 설정, 표면이 조명 렌더링에 영향을 주기 때문에.
- 돌출 또는 깊이 설정, 평면 도형에 두께가 필요하기 때문에.

다음 예제는 직사각형을 만들고 전면에 텍스트를 추가한 뒤 3D 서식을 적용합니다. 카메라 회전 값은 도이며, 돌출 높이는 100 포인트입니다. 예제는 슬라이드를 PNG 이미지로 기본 크기의 두 배로 렌더링하고 프레젠테이션을 PPTX로 저장합니다.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

렌더링된 슬라이드 이미지는 직사각형을 두꺼운 3D 블록으로 보여줍니다:

![전면에 흰색 3D 텍스트가 있는 파란색 3D 직사각형 렌더링](img_01_01.png)

## **카메라로 도형 회전시키기**

PowerPoint에서는 3‑D 회전 창에서 3D 회전을 구성합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전과 대응합니다.

![X, Y, Z 회전 값이 강조된 PowerPoint 3‑D 회전 창](img_02_01.png)

Aspose.Slides에서는 [ThreeDFormat::getCamera](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getCamera--) 를 통해 카메라에 접근합니다. 이 예제는 직사각형을 만들고 직교 전면 뷰를 선택한 뒤 X, Y, Z 회전을 각각 20°, 30°, 40°로 설정합니다. 파일을 저장하지 않고 메모리 상에 도형을 구성합니다:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

객체를 보는 관점을 변경해야 할 때 카메라를 사용합니다. 이는 슬라이드의 2D 도형 기하학을 변경하지 않으며, 렌더링 시 PowerPoint와 Aspose.Slides가 사용하는 3D 관점을 변경합니다.

## **돌출 및 깊이 추가하기**

돌출은 도형을 앞면 뒤쪽으로 확장시켜 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 가시적인 두께를 설정하고, 색상 제어는 측면 색을 설정합니다.

![돌출 색 및 돌출 높이 속성에 매핑된 PowerPoint 깊이 제어](img_02_02.png)

[ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) 로 두께를 설정하고 [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getExtrusionColor--) 으로 측면 색을 가져옵니다. 이 예제는 직사각형에 100 포인트 돌출을 주고 보라색 측면을 적용한 뒤 카메라를 회전시켜 두께를 확인합니다. 파일을 저장하지 않고 메모리 상에 도형을 구성합니다:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

[ThreeDFormat::setDepth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setDepth-double-) 메서드는 3D 도형의 깊이를 설정합니다. [setExtrusionHeight](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) 메서드는 예제에서처럼 돌출 효과의 높이를 제어합니다.

## **3D 효과와 함께 그라디언트 또는 그림 채우기 사용하기**

3D 서식은 도형 채우기와 독립적입니다. 전면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 돌출 설정을 사용할 수 있습니다.

이 예제는 전면에 파란색‑주황색 그라디언트를 적용하고 150 포인트 돌출에 어두운 주황색을 적용합니다. 그라디언트 정지는 0과 100에서 시작과 끝을 표시합니다. 카메라 회전 값은 도이며, 슬라이드는 기본 크기의 두 배인 PNG 이미지로 렌더링됩니다:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

렌더링된 출력은 전면의 그라디언트를 유지하고 돌출은 별도로 렌더링합니다:

![파란색‑주황색 그라디언트 채우기와 주황색 돌출이 적용된 3D 직사각형 렌더링](img_02_03.png)

그림 채우기를 사용하려면 프레젠테이션에 이미지를 추가하고 도형 채우기에 할당합니다. 이 예제는 작업 디렉터리에 "image.jpg" 파일이 존재한다고 가정합니다. 그림을 직사각형에 맞게 늘이고 150 포인트 돌출을 적용하며 카메라 회전을 도 단위로 설정합니다. 파일을 저장하거나 렌더링하지 않고 메모리 상에 도형을 구성합니다:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

그림은 전면에 렌더링되고, 돌출은 3D 측면 표면으로 렌더링됩니다:

![전면에 사진 채우기와 주황색 돌출이 적용된 3D 직사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용하기**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 글자 자체에 돌출, 재질, 조명 및 카메라 설정이 필요한 WordArt‑같은 효과에 유용합니다.

다음 예제는 주황색‑흰색 격자 패턴 텍스트를 만들고 위로 아치형 변형을 적용한 뒤 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/#getThreeDFormat--) 을 통해 3D 설정을 구성합니다. 돌출 높이와 깊이는 포인트 단위이며, 조명 회전은 도 단위입니다. 도형 채우기와 외곽선을 숨겨 텍스트만 보이게 합니다. 예제는 기본 슬라이드 크기의 두 배인 PNG 이미지로 렌더링하고 프레젠테이션을 PPTX로 저장합니다:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

텍스트는 곡선형으로 돌출된 3D 레터링으로 렌더링됩니다:

![호형 WordArt 변환, 주황색 패턴 채우기 및 어두운 돌출이 적용된 3D 텍스트 렌더링](img_02_05.png)

## **3D 도형 위에 텍스트를 평평하게 유지하기**

텍스트를 읽기 쉽게 유지하면서 도형의 3D 외관을 보존하려면 [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#getTextFrameFormat--) 를 통해 [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) 를 호출합니다. 값이 `true`이면 텍스트가 3D 장면에서 제외됩니다. `false`이면 텍스트가 장면에 참여하여 3D 방향을 따릅니다.

이 설정은 도형의 3D 서식을 제거하지 않습니다: 카메라, 조명, 재질 및 돌출은 [Shape::getThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getThreeDFormat--) 로 계속 구성됩니다. 또한 일반 회전과는 다릅니다. [Shape::setRotation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#setRotation-float-) 은 슬라이드 평면에서 도형을 회전시키고, [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) 은 텍스트의 경계 상자 내에서 사용자 정의 회전을 제어합니다. 텍스트를 3D 장면에서 제외해도 이 각도들은 리셋되지 않습니다.

다음 자체 포함 예제는 텍스트가 있는 파란 직사각형을 만들고 원본 옆에 복제합니다. 두 도형 모두 동일한 3D 서식을 가지며 텍스트 설정만 다릅니다: 왼쪽은 `false`, 오른쪽은 `true`. 카메라 각도는 도이며, 돌출 높이는 40 포인트입니다. 예제는 프레젠테이션을 PPTX로 저장하고 비교 슬라이드를 기본 크기의 두 배인 PNG로 렌더링합니다:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

좌측은 3D 방향을 따르는 텍스트, 우측은 평평하게 유지되는 텍스트가 있는 나란히 배치된 3D 직사각형:

![좌측은 3D 방향을 따르는 텍스트, 우측은 평평하게 유지되는 텍스트가 있는 나란히 배치된 3D 직사각형](keep_text_flat.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 2D 결과로 래스터화되거나 출력에 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/php-java/convert-powerpoint-to-png/) 로 렌더링하거나, [PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/) 로 내보내거나, [HTML](/slides/ko/php-java/convert-powerpoint-to-html/) 로 내보내거나, [비디오 변환](/slides/ko/php-java/convert-powerpoint-to-video/) 을 위해 프레임을 생성할 때 적용됩니다.

주의할 점:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 객체는 내보낸 후 뷰어가 회전할 수 없습니다.
- 최종 모습은 카메라, 라이트 릭, 재질, 돌출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인하려면 [유효한 도형 속성](/slides/ko/php-java/shape-effective-properties/) 을 읽으십시오.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정이 아닌 렌더링된 형태로 제공됩니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 도형과 텍스트에 대한 PowerPoint 3D 효과를 생성하고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 인터랙티브 3D 장면으로 만들어 뷰어가 회전할 수 있게 하지는 않습니다. PPTX에서는 형식이 지원되는 경우 3D 서식이 PowerPoint에서 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이점은 무엇인가요?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 일반 PowerPoint 도형이나 텍스트에 적용되는 회전, 돌출, 베벨, 조명, 재질 등의 서식입니다. 이 문서는 3D 효과에 대해 다룹니다.

**가시적인 3D 도형을 만들기 위해 필요한 설정은 무엇인가요?**

최소한 카메라 회전과 돌출 또는 깊이를 설정해야 합니다. 실무에서는 조명 릭과 재질도 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예. 도형 본문에는 [Shape::getThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getThreeDFormat--)을, 텍스트에는 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/#getThreeDFormat--)을 사용하십시오.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 표시되나요?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환에 사용되는 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 출력에는 렌더링된 외관이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있나요?**

예. 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽으려면 [Shape Effective Properties](/slides/ko/php-java/shape-effective-properties/) 에 설명된 유효한 서식 API를 사용하십시오.