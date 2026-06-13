---
title: PHP에서 그룹 프레젠테이션 도형
linktitle: 도형 그룹
type: docs
weight: 40
url: /ko/php-java/group/
keywords:
- 그룹 도형
- 도형 그룹
- 그룹 추가
- 대체 텍스트
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에서 도형을 그룹화하고 그룹 해제하는 방법을 배우세요 — 빠르고 단계별 가이드, 무료 코드 제공."
---
## **개요**

이 문서는 Aspose.Slides에서 그룹 도형을 사용하는 방법을 설명합니다. 슬라이드에 그룹 도형을 추가하고, 그 안에 도형을 배치하며, 업데이트된 프레젠테이션을 저장하는 방법을 보여줍니다. 또한 그룹 내부에 저장된 도형에 액세스하고 해당 도형의 `AlternativeText` 값을 읽는 방법을 시연합니다. 추가로 중첩 그룹, Z-순서, 잠금 옵션과 같은 관련 그룹 도형 기능에 대해서도 간략히 다룹니다.

## **그룹 도형 추가**
Aspose.Slides는 슬라이드에서 그룹 도형을 작업하는 것을 지원합니다. 이 기능은 개발자가 보다 풍부한 프레젠테이션을 구현하도록 돕습니다. Aspose.Slides for PHP via Java는 그룹 도형을 추가하거나 액세스하는 것을 지원합니다. 추가된 그룹 도형에 도형을 넣어 채우거나 그룹 도형의 모든 속성에 접근할 수 있습니다. Aspose.Slides for PHP via Java를 사용하여 슬라이드에 그룹 도형을 추가하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 그룹 도형을 추가합니다.
1. 추가한 그룹 도형에 도형을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예시는 슬라이드에 그룹 도형을 추가합니다.

```php
  # Presentation 클래스 인스턴스 생성
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드 가져오기
    $sld = $pres->getSlides()->get_Item(0);
    # 슬라이드의 도형 컬렉션에 접근
    $slideShapes = $sld->getShapes();
    # 슬라이드에 그룹 도형 추가
    $groupShape = $slideShapes->addGroupShape();
    # 추가된 그룹 도형 안에 도형 추가
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # 그룹 도형 프레임 추가
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # PPTX 파일을 디스크에 저장
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **AltText 속성 액세스**
이 항목에서는 그룹 도형을 추가하고 슬라이드에 있는 그룹 도형의 AltText 속성에 액세스하는 간단한 단계와 코드 예제를 제공합니다. Aspose.Slides for PHP via Java를 사용하여 슬라이드의 그룹 도형에서 AltText에 액세스하려면:

1. PPTX 파일을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드의 도형 컬렉션에 액세스합니다.
1. 그룹 도형에 액세스합니다.
1. [Alternative Text](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getAlternativeText) 속성에 액세스합니다.

아래 예시는 그룹 도형의 대체 텍스트에 액세스합니다.

```php
  # PPTX 파일을 나타내는 Presentation 클래스 인스턴스 생성
  $pres = new Presentation("AltText.pptx");
  try {
    # 첫 번째 슬라이드 가져오기
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # 슬라이드의 도형 컬렉션에 접근
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # 그룹 도형에 접근.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # AltText 속성에 접근
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**중첩 그룹화(그룹 내부에 그룹)가 지원되나요?**

예. [GroupShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/groupshape/)에는 계층 구조 지원을 직접 나타내는 [getParentGroup](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getparentgroup/) 메서드가 있어, 그룹이 다른 그룹의 자식이 될 수 있습니다.

**그룹의 Z-순서를 슬라이드의 다른 객체에 비해 어떻게 제어하나요?**

[GroupShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/groupshape/)의 [getZOrderPosition](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getzorderposition/) 메서드를 사용하여 디스플레이 스택에서의 위치를 확인합니다.

**이동/편집/그룹 해제 방지를 할 수 있나요?**

예. 그룹의 잠금 섹션은 [GroupShapeLock](https://reference.aspose.com/slides/ko/php-java/aspose.slides/groupshape/getgroupshapelock/)을 통해 노출되며, 객체에 대한 작업을 제한할 수 있습니다.