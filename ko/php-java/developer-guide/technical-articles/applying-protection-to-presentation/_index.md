---
title: PHP에서 도형 잠금으로 프레젠테이션 편집 제한
linktitle: 프레젠테이션 편집 제한
type: docs
weight: 60
url: /ko/php-java/applying-protection-to-presentation/
keywords:
- 편집 방지
- 편집으로부터 보호
- 도형 잠금
- 위치 잠금
- 선택 잠금
- 크기 조정 잠금
- 그룹화 잠금
- PowerPoint
- PPTX
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PPTX 프레젠테이션에서 도형을 잠그고 잠금 해제하는 방법을 배우고, 선택, 이동, 크기 조정 및 그룹화를 제한합니다."
---
## **개요**

자동화된 워크플로의 일부로 PowerPoint (PPTX) 프레젠테이션을 만들고, 업데이트하며 저장하는 것이 Aspose.Slides for PHP via Java의 일반적인 사용 사례입니다. 사용자가 이러한 프레젠테이션을 받을 때, 도형에 대한 변경을 제한하면 의도된 레이아웃과 내용을 보존하는 데 도움이 됩니다.

이 문서에서는 슬라이드에서 도형이 어떻게 구성되는지와 PPTX 프레젠테이션에서 도형 잠금을 적용하고 제거하는 방법을 설명합니다. 이러한 잠금을 사용하면 개별 도형에 대한 특정 편집 작업을 제한할 수 있습니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 객체, 그룹화된 도형, 그림 프레임, 비디오 프레임, 연결선 및 프레젠테이션을 구성하는 데 사용되는 기타 요소와 같은 구성 요소로 구성됩니다. Aspose.Slides for PHP via Java에서는 슬라이드의 각 요소가 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 클래스를 상속하는 객체로 표현됩니다.

다양한 도형 유형은 서로 다른 잠금 옵션을 제공합니다. [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) 클래스는 도형 잠금의 기본 클래스입니다. Aspose.Slides for PHP via Java는 다음 잠금 클래스를 제공합니다:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) 자동 도형을 잠급니다.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) 연결선 도형을 잠급니다.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) 그래픽 객체를 잠급니다.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) 그룹 도형을 잠급니다.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) 그림 프레임을 잠급니다.  

프레젠테이션 전체에 잠금을 적용하려면 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)의 슬라이드를 반복하면서 각 지원되는 도형에 적절한 잠금을 설정합니다.

## **보호 적용 및 제거**

도형 잠금은 도형 선택, 이동 및 크기 조정과 같은 작업을 제한합니다. 전체 프레젠테이션을 편집 불가능하게 만들지는 않습니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for PHP via Java는 슬라이드의 도형을 다루기 위해 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 클래스를 제공합니다.

예제에서는 자동 도형에 대해 `true`와 함께 [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked), [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked)를 호출하고, 그룹 도형, 연결선 및 그림 프레임에 대해 동일한 잠금을 적용합니다. 연결선은 이동을 위해 [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove)를 사용하고; 그룹은 그룹화를 제한하기 위해 [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked)도 사용합니다.

예제에서는 기존 PPTX 프레젠테이션을 로드하고, 각 슬라이드의 도형 컬렉션에 있는 도형을 검사한 후 이러한 제한이 적용된 사본을 저장합니다. 네 가지 처리된 유형 이외의 도형은 변경되지 않은 채로 남겨둡니다. 루프는 그룹 내의 자식 도형을 순회하지 않습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **보호 제거**

도형 잠금을 제거하려면 해당 값을 `false`로 설정합니다. 다음 예제에서는 도형 잠금이 적용된 프레젠테이션을 로드하고 [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/)를 통해 선택, 이동 및 크기 조정 제한을 해제합니다. 또한 `false`를 [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked)에 전달하여 그룹화 제한을 제거하고 프레젠테이션 사본을 저장합니다. 다른 잠금 설정은 변경되지 않은 채로 남습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **결론**

Aspose.Slides for PHP via Java를 사용하면 개별 도형에 대한 특정 편집 작업을 제한하거나 슬라이드 전체에 동일한 제한을 적용할 수 있습니다. 각 도형 유형이 지원하는 잠금을 선택하고, 해당 제한을 제거해야 할 경우 값을 `false`로 설정하십시오.

## **자주 묻는 질문**

**프레젠테이션에서 도형 잠금과 암호 보호를 동시에 결합할 수 있나요?**

예. 도형 잠금은 특정 편집 작업을 제한하고, [암호 보호](/slides/ko/php-java/password-protected-presentation/)는 프레젠테이션을 열거나 수정하는 것을 제한할 수 있습니다. 두 기능을 동일한 파일에서 함께 사용할 수 있습니다.

**특정 슬라이드에만 편집을 제한하고 다른 슬라이드에는 영향을 주지 않을 수 있나요?**

예. 선택한 슬라이드의 도형에만 잠금을 적용하면 됩니다. 이는 다른 슬라이드의 잠금 설정에는 영향을 주지 않습니다.

**그룹 내부의 개별 도형에 잠금을 적용하려면 어떻게 해야 하나요?**

그룹의 [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) 메서드가 반환하는 컬렉션을 반복하면서 각 자식 도형에 적절한 잠금을 적용합니다. 중첩된 그룹이 있는 경우에도 동일하게 반복합니다. 위의 예제들은 슬라이드의 도형 컬렉션만 처리하므로 개별 그룹 구성원에 대한 잠금은 설정되지 않습니다.