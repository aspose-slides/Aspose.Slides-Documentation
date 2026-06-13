---
title: PHP를 사용한 프레젠테이션의 3D 효과 생성
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
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 돌출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for PHP via Java는 도형과 텍스트에 대해 PowerPoint 스타일의 3D 서식을 만들고, 편집하고, 보존하며 렌더링할 수 있습니다. 이 문서에서는 회전, 돌출, 베벨, 조명, 재질, 그라디언트 또는 이미지 채우기, 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="primary" %}}
이 문서는 PowerPoint 도형과 텍스트에 적용되는 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 방법은 다루지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

[Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 클래스와 해당 [Shape::getThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getThreeDFormat--) 메서드를 사용하여 도형에 3D 서식을 적용합니다. 이 메서드는 해당 도형의 3D 장면을 제어하는 [ThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/)을 반환합니다.

텍스트의 경우 [TextFrameFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/) 클래스와 해당 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/#getThreeDFormat--) 메서드를 사용합니다. 이것은 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 설정은 다음과 같습니다.

| 메서드 또는 설정 | 제어 내용 | 사용 시점 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getCamera--) | 시점, 기본 카메라 유형, 회전, 확대/축소 및 원근감 | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 프리셋과 일치시킬 때 |
| [getLightRig](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getLightRig--) | 조명 프리셋, 방향 및 조명 회전 | 3D 표면의 하이라이트와 그림자 표시 방식을 변경할 때 |
| [setMaterial](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setMaterial-byte-) | 평면, 무광, 플라스틱, 금속 등 표면 재질 | 동일한 기하학을 더 평평하게, 부드럽게, 광택 있게 또는 금속처럼 보이게 할 때 |
| [setExtrusionHeight](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | 앞면에서 뒤쪽으로 도형이 연장되는 거리 | 평면 도형을 눈에 보이는 두께가 있는 3D 객체로 전환할 때 |
| [getExtrusionColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getExtrusionColor--) | 돌출된 측면의 색상 | 깊이를 시각화하거나 측면 색을 앞면 채우기와 일치시킬 때 |
| [setDepth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setDepth-double-) | PowerPoint 3D 서식에서 사용하는 추가 깊이 | 도형이나 텍스트에 깊이를 미세 조정할 때, 특히 베벨 및 재질 설정과 함께 사용 |
| [getBevelTop](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getBevelTop--) 및 [getBevelBottom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getBevelBottom--) | 앞면 및 뒷면의 올려진 또는 둥근 가장자리 | 날카로운 평면 대신 부드럽거나 몰딩된 가장자리를 추가할 때 |
| [getContourColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getContourColor--) 및 [setContourWidth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setContourWidth-double-) | 3D 객체 주변의 외곽선 | 렌더링된 출력에서 객체 경계를 강조할 때 |

## **3D 도형 만들기**

도형을 설득력 있게 3D로 보이게 하려면 일반적으로 네 가지 종류의 설정이 필요합니다.

- 카메라 설정 – 기본 정면 뷰가 돌출을 숨길 수 있기 때문입니다.
- 조명 설정 – 조명이 면과 측면을 읽기 쉽게 만들기 때문입니다.
- 재질 설정 – 표면이 빛을 어떻게 반사하는지에 영향을 주기 때문입니다.
- 돌출 또는 깊이 설정 – 평면 도형에 두께가 필요하기 때문입니다.

다음 예제는 사각형을 만들고, 앞면에 텍스트를 추가하고, 3D 서식을 적용한 뒤 프레젠테이션을 PPTX로 저장하고 슬라이드를 PNG 이미지로 렌더링합니다.

```php
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

렌더링된 슬라이드 이미지에서는 사각형이 두꺼운 3D 블록으로 표시됩니다:

![앞면에 흰색 3D 텍스트가 있는 파란색 3D 사각형 렌더링 이미지](img_01_01.png)

## **카메라로 도형 회전하기**

PowerPoint에서 3D 회전은 3‑D 회전 창에서 설정합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전과 동일합니다.

![X, Y, Z 회전 값이 강조 표시된 PowerPoint 3‑D 회전 창](img_02_01.png)

Aspose.Slides에서는 [ThreeDFormat::getCamera](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getCamera--)을 통해 카메라 유형과 회전을 설정합니다:

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

카메라는 사용자가 객체를 보는 방식을 변경해야 할 때 사용합니다. 슬라이드의 2D 도형 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점을 변경합니다.

## **돌출 및 깊이 추가**

돌출은 앞면 뒤로 도형을 연장해 두께가 있게 만듭니다. PowerPoint에서는 깊이 제어가 보이는 두께를 설정하고, 색상 제어가 측면의 색을 설정합니다.

![돌출 색상 및 돌출 높이 속성에 매핑된 PowerPoint 깊이 제어](img_02_02.png)

두께는 [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-)으로, 측면 색은 [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#getExtrusionColor--)으로 설정합니다:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

PowerPoint의 깊이 값을 직접 다루거나 깊이를 베벨, 재질, 텍스트 효과와 결합해야 할 때는 [ThreeDFormat::setDepth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/#setDepth-double-)를 사용합니다. 많은 도형 시나리오에서는 `setExtrusionHeight`가 눈에 보이는 돌출을 직접 표현하므로 더 명확합니다.

## **3D 효과와 함께 그라디언트 또는 사진 채우기 사용**

3D 서식은 도형 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 사진 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 돌출 설정을 사용할 수 있습니다.

다음 예제는 도형에 그라디언트 채우기를 적용하고 측면에 어두운 돌출 색을 지정합니다:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

렌더링된 결과는 앞면에 그라디언트를 유지하고 돌출은 별도로 렌더링됩니다:

![파란색‑주황색 그라디언트 채우기와 주황색 돌출이 적용된 3D 사각형 렌더링 이미지](img_02_03.png)

사진 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기에 할당합니다:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

사진은 앞면에 렌더링되고, 돌출은 3D 측면 표면으로 렌더링됩니다:

![앞면에 사진 채우기와 주황색 돌출이 적용된 3D 사각형 렌더링 이미지](img_02_04.png)

## **텍스트에 3D 서식 적용**

도형 3D 서식은 도형 본문에 영향을 미치고, 텍스트 3D 서식은 텍스트 프레임에 영향을 미칩니다. 이는 글자 자체에 돌출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 패턴 채우기가 적용된 텍스트를 만들고 WordArt 변환을 적용한 뒤 [TextFrameFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/)에 3D 설정을 구성합니다:

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

텍스트는 곡선 형태의 돌출된 3D 문자로 렌더링됩니다:

![아치형 WordArt 변환, 주황색 패턴 채우기 및 어두운 돌출이 적용된 3D 텍스트 렌더링 이미지](img_02_05.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 2D 결과로 래스터화되거나 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/php-java/convert-powerpoint-to-png/)로 렌더링하거나, [PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/php-java/convert-powerpoint-to-html/)로 내보내거나, [비디오 변환](/slides/ko/php-java/convert-powerpoint-to-video/)을 위한 프레임을 생성할 때 적용됩니다.

다음 사항을 기억하세요:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 내보낸 후에는 사용자가 객체를 회전할 수 없습니다.
- 최종 모습은 카메라, 라이트 릭, 재질, 돌출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 포맷 값이 필요하면 [effective shape properties](/slides/ko/php-java/shape-effective-properties/)를 참조하십시오.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정이 아니라 렌더링된 이미지로 저장됩니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 도형과 텍스트에 대한 PowerPoint 3D 효과를 만들고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 사용자가 회전할 수 있는 인터랙티브 3D 장면으로 만들지는 않습니다. PPTX에서는 형식이 지원하는 경우 3D 서식이 PowerPoint에서 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이는 무엇인가요?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 일반 PowerPoint 도형이나 텍스트에 적용되는 회전, 돌출, 베벨, 조명, 재질 등의 서식입니다. 이 문서는 3D 효과에 대해 다룹니다.

**보이는 3D 도형을 만들기 위해 필요한 설정은 무엇인가요?**

최소한 카메라 회전과 돌출 또는 깊이를 설정해야 합니다. 실제로는 조명 릭과 재질도 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예. 도형 본문에는 [Shape::getThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getThreeDFormat--)을, 텍스트에는 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/#getThreeDFormat--)을 사용하십시오.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 표시되나요?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환을 위한 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 결과물에는 렌더링된 모습이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있나요?**

예. 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽으려면 [Shape Effective Properties](/slides/ko/php-java/shape-effective-properties/)에 설명된 유효 서식 API를 사용하십시오.