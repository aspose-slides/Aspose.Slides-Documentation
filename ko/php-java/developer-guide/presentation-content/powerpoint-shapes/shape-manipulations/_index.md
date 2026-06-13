---
title: PHP에서 프레젠테이션 도형 관리
linktitle: 도형 조작
type: docs
weight: 40
url: /ko/php-java/shape-manipulations/
keywords:
- PowerPoint 도형
- 프레젠테이션 도형
- 슬라이드의 도형
- 도형 찾기
- 도형 복제
- 도형 제거
- 도형 숨기기
- 도형 순서 변경
- Interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 레이아웃 형식
- SVG로 도형
- 도형을 SVG로
- 도형 정렬
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 도형을 만들고, 편집하고, 최적화하는 방법을 배우고 고성능 PowerPoint 프레젠테이션을 제공하십시오."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션에서 도형을 다루는 방법을 설명합니다. 슬라이드에서 도형을 찾고, 복제하고, 제거하고, 숨기고, 순서를 변경하고, Interop 도형 ID를 가져오며, 식별 및 후속 처리를 위해 대체 텍스트를 설정하는 방법을 보여줍니다.

또한 도형의 레이아웃 형식에 접근하는 방법, 도형을 SVG로 렌더링하는 방법, 슬라이드에서 도형을 정렬하는 방법, 수평 및 수직 미러링을 위한 플립 속성을 사용하는 방법을 다룹니다. 추가로 도형 결합, 스택 순서, 도형 잠금에 관한 짧은 FAQ도 포함되어 있습니다.

## **슬라이드에서 도형 찾기**
이 항목에서는 내부 Id를 사용하지 않고 개발자가 특정 도형을 슬라이드에서 쉽게 찾을 수 있는 간단한 기술을 설명합니다. PowerPoint 프레젠테이션 파일은 내부 고유 Id 이외에 슬라이드의 도형을 식별할 방법이 없습니다. 개발자가 내부 고유 Id를 사용해 도형을 찾는 것이 어렵습니다. 슬라이드에 추가된 모든 도형에는 일부 대체 텍스트가 있습니다. 우리는 개발자에게 특정 도형을 찾기 위해 대체 텍스트를 사용할 것을 권장합니다. 향후 변경할 객체에 대한 대체 텍스트를 정의하려면 MS PowerPoint를 사용할 수 있습니다.

원하는 도형의 대체 텍스트를 설정한 후, Aspose.Slides for PHP via Java를 사용해 해당 프레젠테이션을 열고 슬라이드에 추가된 모든 도형을 반복할 수 있습니다. 각 반복에서 도형의 대체 텍스트를 확인하고 일치하는 대체 텍스트를 가진 도형이 필요한 도형이 됩니다. 이 기술을 더 잘 보여주기 위해, 슬라이드에서 특정 도형을 찾고 해당 도형을 반환하는 메서드 [findShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)를 만들었습니다.

```php
  # 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 찾을 도형의 대체 텍스트
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **도형 복제**
Aspose.Slides for PHP via Java를 사용하여 슬라이드에 도형을 복제하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
1. 원본 슬라이드의 도형 컬렉션에 접근합니다.
1. 프레젠테이션에 새 슬라이드를 추가합니다.
1. 원본 슬라이드 도형 컬렉션의 도형을 새 슬라이드에 복제합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제는 슬라이드에 그룹 도형을 추가합니다.

```php
  # Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **도형 제거**
Aspose.Slides for PHP via Java는 개발자가 도형을 제거할 수 있게 합니다. 슬라이드에서 도형을 제거하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 특정 AlternativeText를 가진 도형을 찾습니다.
1. 도형을 제거합니다.
1. 파일을 디스크에 저장합니다.

```php
  # Presentation 객체 생성
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드 가져오기
    $sld = $pres->getSlides()->get_Item(0);
    # 사각형 유형의 자동 도형 추가
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # 프레젠테이션을 디스크에 저장
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **도형 숨기기**
Aspose.Slides for PHP via Java는 개발자가 도형을 숨길 수 있게 합니다. 슬라이드에서 도형을 숨기려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 특정 AlternativeText를 가진 도형을 찾습니다.
1. 도형을 숨깁니다.
1. 파일을 디스크에 저장합니다.

```php
  # PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드 가져오기
    $sld = $pres->getSlides()->get_Item(0);
    # 사각형 유형의 자동 도형 추가
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # 프레젠테이션을 디스크에 저장
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **도형 순서 변경**
Aspose.Slides for PHP via Java는 개발자가 도형의 순서를 재배열할 수 있게 합니다. 도형 순서를 변경하면 어떤 도형이 앞에, 어떤 도형이 뒤에 위치하는지 지정할 수 있습니다. 슬라이드에서 도형 순서를 재배열하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 도형을 추가합니다.
1. 도형의 텍스트 프레임에 텍스트를 추가합니다.
1. 같은 좌표에 또 다른 도형을 추가합니다.
1. 도형들의 순서를 재배열합니다.
1. 파일을 디스크에 저장합니다.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Interop 도형 ID 가져오기**
Aspose.Slides for PHP via Java는 개발자가 슬라이드 범위에서 고유한 도형 식별자를 얻을 수 있게 합니다. 이는 프레젠테이션 범위에서 고유 식별자를 제공하는 [getUniqueId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getuniqueid/) 메서드와 대조됩니다. [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 클래스에 [getOfficeInteropShapeId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getofficeinteropshapeid/) 메서드가 추가되었습니다. [getOfficeInteropShapeId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getofficeinteropshapeid/) 메서드가 반환하는 값은 Microsoft.Office.Interop.PowerPoint.Shape 객체의 Id 값에 해당합니다. 아래에 샘플 코드가 제공됩니다.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 슬라이드 범위에서 고유한 도형 식별자 가져오기
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **도형에 대체 텍스트 설정**
Aspose.Slides for PHP via Java는 개발자가 任意의 도형에 AlternateText를 설정할 수 있게 합니다. 프레젠테이션의 도형은 `Alternative Text` 또는 [Shape Name](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/setname/) 메서드로 구분될 수 있습니다. [setAlternativeText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/setalternativetext/) 및 [getAlternativeText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getalternativetext/) 메서드는 Aspose.Slides와 Microsoft PowerPoint 모두에서 읽고 설정할 수 있습니다. 이 메서드를 사용하면 도형에 태그를 지정하고 도형 제거, 도형 숨기기, 슬라이드에서 도형 순서 재배열과 같은 다양한 작업을 수행할 수 있습니다. 도형의 AlternateText를 설정하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 슬라이드에 任意의 도형을 추가합니다.
1. 새로 추가된 도형으로 작업을 수행합니다.
1. 도형들을 순회하며 원하는 도형을 찾습니다.
1. AlternativeText를 설정합니다.
1. 파일을 디스크에 저장합니다.

```php
  # PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드 가져오기
    $sld = $pres->getSlides()->get_Item(0);
    # 사각형 유형의 자동 도형 추가
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # 프레젠테이션을 디스크에 저장
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **도형 레이아웃 형식 접근**
Aspose.Slides for PHP via Java는 도형의 레이아웃 형식에 접근하기 위한 간단한 API를 제공합니다. 이 문서에서는 레이아웃 형식에 접근하는 방법을 보여줍니다.

아래에 샘플 코드가 제공됩니다.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **도형을 SVG로 렌더링**
이제 Aspose.Slides for PHP via Java는 도형을 SVG로 렌더링하는 기능을 지원합니다. [writeAsSvg](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/writeassvg/) 메서드(및 그 오버로드)가 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 클래스에 추가되었습니다. 이 메서드를 사용하면 도형의 내용을 SVG 파일로 저장할 수 있습니다. 아래 코드 스니펫은 슬라이드의 도형을 SVG 파일로 내보내는 방법을 보여줍니다.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **도형 정렬**
Aspose.Slides는 도형을 슬라이드 여백을 기준으로 또는 서로를 기준으로 정렬할 수 있게 합니다. 이를 위해 오버로드된 메서드 [SlidesUtil::alignShapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slideutil/alignshapes/)가 추가되었습니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapesalignmenttype/) 열거형은 가능한 정렬 옵션을 정의합니다.

**예제 1**

아래 소스 코드는 인덱스 1, 2, 4인 도형을 슬라이드 상단 경계에 맞춰 정렬합니다.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**예제 2**

아래 예제는 컬렉션의 가장 아래에 있는 도형을 기준으로 전체 도형 컬렉션을 정렬하는 방법을 보여줍니다.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **플립 속성**

Aspose.Slides에서 [ShapeFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapeframe/) 클래스는 `flipH` 및 `flipV` 속성을 통해 도형의 수평 및 수직 미러링을 제어합니다. 두 속성 모두 [NullableBool](https://reference.aspose.com/slides/ko/php-java/aspose.slides/nullablebool/) 유형이며, `True`는 플립, `False`는 플립 없음, `NotDefined`는 기본 동작을 사용함을 의미합니다. 이러한 값은 도형의 [Frame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getFrame)에서 접근할 수 있습니다.

플립 설정을 수정하려면 도형의 현재 위치와 크기, 원하는 `flipH` 및 `flipV` 값, 회전 각도를 사용해 새로운 [ShapeFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapeframe/) 인스턴스를 만든 뒤 이를 도형의 [Frame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getFrame)에 할당하고 프레젠테이션을 저장하면 미러 변환이 적용되어 출력 파일에 반영됩니다.

예를 들어, 첫 번째 슬라이드에 기본 플립 설정을 가진 단일 도형이 있는 sample.pptx 파일이 있다고 가정합니다.

![플립될 도형](shape_to_be_flipped.png)

다음 코드 예제는 도형의 현재 플립 속성을 조회하고 수평·수직 모두 플립합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // 도형의 수평 플립 속성을 가져옵니다.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // 도형의 수직 플립 속성을 가져옵니다.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // 수평으로 플립합니다.
    $flipV = NullableBool::True; // 수평으로 플립합니다.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![플립된 도형](flipped_shape.png)

## **FAQ**

**슬라이드에서 데스크톱 편집기와 같이 도형을 결합(합집합/교집합/차집합)할 수 있나요?**

내장된 Boolean 연산 API는 없습니다. 원하는 외곽선을 직접 구성하여(예: [GeometryPath](https://reference.aspose.com/slides/ko/php-java/aspose.slides/geometrypath/)를 사용해 결과 기하학을 계산하고 해당 윤곽으로 새 도형을 만든 뒤 원본을 선택적으로 제거) 근사화할 수 있습니다.

**도형이 항상 “위에” 있도록 스택 순서(z-order)를 어떻게 제어할 수 있나요?**

슬라이드의 [shapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslide/#getShapes) 컬렉션 내 삽입/이동 순서를 변경합니다. 예측 가능한 결과를 위해 모든 다른 슬라이드 수정이 끝난 후 z-order를 최종 지정하십시오.

**PowerPoint에서 사용자가 도형을 편집하지 못하도록 “잠금”할 수 있나요?**

예. 도형 수준 보호 플래그(예: 선택, 이동, 크기 조정, 텍스트 편집 잠금)를 설정합니다. 필요에 따라 마스터나 레이아웃에 제한을 적용할 수도 있습니다. 이는 UI 수준의 보호이며 보안 기능은 아닙니다; 더 강력한 보호가 필요하면 [읽기 전용 권장 사항 또는 비밀번호](/slides/ko/php-java/password-protected-presentation/)와 같은 파일 수준 제한과 결합하십시오.