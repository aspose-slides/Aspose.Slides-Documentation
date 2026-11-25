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
description: "Aspose.Slides for PHP via Java를 사용하여 PPTX 프레젠테이션의 도형을 잠그고 해제하는 방법을 배우고, 선택, 이동, 크기 조정 및 그룹화를 제한합니다."
---
## **개요**

Aspose.Slides for PHP via Java의 일반적인 사용 사례는 자동화된 워크플로의 일부로 PowerPoint(PPTX) 프레젠테이션을 생성, 업데이트 및 저장하는 것입니다. 사용자가 이러한 프레젠테이션을 받을 때, 도형에 대한 변경을 제한하면 의도한 레이아웃과 내용을 보존하는 데 도움이 됩니다.

이 문서에서는 슬라이드에서 도형이 어떻게 구성되는지와 PPTX 프레젠테이션에서 도형 잠금을 적용 및 제거하는 방법을 설명합니다. 이러한 잠금을 사용하면 개별 도형에 대한 특정 편집 작업을 제한할 수 있습니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 객체, 그룹화된 도형, 그림 프레임, 비디오 프레임, 연결선 및 프레젠테이션을 구성하는 기타 요소와 같은 구성 요소로 이루어집니다. Aspose.Slides for PHP via Java에서는 슬라이드의 각 요소가 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 클래스를 상속받는 객체로 표현됩니다.

다양한 도형 유형에 따라 잠금 옵션이 다르게 제공됩니다. [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) 클래스는 도형 잠금의 기본 클래스입니다. Aspose.Slides for PHP via Java는 다음과 같은 잠금 클래스를 제공합니다:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) 자동 도형을 잠급니다.
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) 연결선 도형을 잠급니다.
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) 그래픽 객체를 잠급니다.
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) 그룹 도형을 잠급니다.
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) 그림 프레임을 잠급니다.

잠금을 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 전체에 적용하려면 슬라이드를 순회하면서 각 지원되는 도형에 적절한 잠금을 설정합니다.

## **보호 적용 및 제거**

호환되는 프레젠테이션 편집기는 도형 잠금을 사용하여 개별 편집 작업을 제한합니다. 파일 암호화 및 문서 수준 쓰기 보호는 별도의 [presentation protection settings](/slides/ko/php-java/password-protected-presentation/)입니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for PHP via Java는 슬라이드의 도형을 작업하기 위해 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 클래스를 제공합니다.

예제에서는 자동 도형에 대해 `true` 값을 사용하여 [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked), [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked)를 호출하고, 그룹 도형, 연결선 및 그림 프레임에 대해 동등한 잠금을 적용합니다. 연결선은 이동을 위해 [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) 를 사용하고, 그룹은 그룹화를 제한하기 위해 [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) 를 사용합니다.

예제에서는 기존 PPTX 프레젠테이션을 로드하고 각 슬라이드의 도형 컬렉션을 확인한 뒤 이러한 제한이 적용된 사본을 저장합니다. 네 가지 처리 유형에 속하지 않는 도형은 변경되지 않은 채로 남습니다. 루프는 그룹 내부의 자식 도형을 순회하지 않습니다.

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

도형 잠금을 제거하려면 값을 `false` 로 설정합니다. 다음 예제에서는 도형 잠금이 적용된 프레젠테이션을 로드하고 [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), 및 [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/)을 통해 선택, 이동 및 크기 조정 제한을 해제합니다. 또한 [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked)에 `false` 를 전달하여 그룹화 제한을 제거하고 프레젠테이션 사본을 저장합니다. 다른 잠금 설정은 변경되지 않은 채로 남습니다.

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

### **그림 자르기 유지**

작업 디렉터리에 `photo.jpg` 라는 사진을 배치합니다. 예제에서는 왼쪽에서 12%, 오른쪽에서 8%를 자른 뒤 그림 프레임의 잠금에 대해 [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) 를 호출합니다. `true` 를 전달하면 추가 자르기가 제한되고 기존 자르기가 유지됩니다.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx`는 자르기 잠금을 `true` 로 저장합니다. PowerPoint에서 사진이 선택되면 **자르기** 명령이 비활성화됩니다.

### **다이어그램 그룹화 유지**

예제에서는 사각형과 화살표를 그룹화한 뒤 그룹의 잠금에 대해 [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) 를 호출하여 다이어그램 구성 요소가 함께 유지되도록 합니다. 그룹을 이동하거나 구성 요소의 채우기를 변경하는 등의 다른 편집은 여전히 가능합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx`는 그룹 해제 잠금을 `true` 로 저장합니다. PowerPoint에서 전체 다이어그램이 선택되면 **그룹 해제** 명령이 비활성화됩니다.

### **기존 도형 잠금 보고**

템플릿을 검토하려면 열어 각 도형에 대한 잠금 객체를 읽습니다. [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) 메서드는 해당 객체의 모든 플래그가 비활성화된 경우 `true` 를, 하나라도 활성화된 경우 `false` 를 반환합니다. 그룹과 그 자식은 별도의 잠금 객체를 가지므로, 그룹에 잠금이 없더라도 자식을 검사해야 합니다.

이 예제는 자동 도형, 그림 프레임 및 그룹의 이동을 검사합니다. 또한 그림에 대한 자르기와 그룹에 대한 그룹 해제를 검사합니다. 보고서는 인식한 활성화된 플래그를 나열하고 검사하지 않은 도형 유형을 표시합니다.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

`Sample.pptx`의 1번 슬라이드에 그룹 `Layout`이 있으며 그룹 해제가 잠겨 있고, 그 안에 있는 사진 `Photo`는 자르기가 잠겨 있으며, 잠금이 해제된 사각형 `Free`가 있다고 가정합니다. 보고서는 `Free`를 건너뛰고 다음 두 줄을 출력합니다:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

보고서는 저장된 도형 수준 편집 플래그를 읽지만 이를 변경하거나 프레젠테이션을 저장하지 않습니다. 문서 수준 쓰기 보호는 별도 설정이며, 각 플래그의 적용 여부는 편집기에 따라 달라집니다.

### **결론**

Aspose.Slides for PHP via Java를 사용하면 개별 도형에 대한 특정 편집 작업을 제한하거나 슬라이드 전체에 동일한 제한을 적용할 수 있습니다. 각 도형 유형이 지원하는 잠금을 선택하고, 제한을 제거해야 할 경우 값을 `false` 로 설정하십시오.

## **FAQ**

**도형 잠금과 비밀번호 보호를 동일한 프레젠테이션에 결합할 수 있나요?**

예. 도형 잠금은 특정 편집 작업을 제한하고, [비밀번호 보호](/slides/ko/php-java/password-protected-presentation/)은 프레젠테이션 열기 또는 수정을 제한할 수 있습니다. 두 가지를 동일한 파일에서 함께 사용할 수 있습니다.

**특정 슬라이드에만 편집을 제한하고 다른 슬라이드에는 영향을 주지 않을 수 있나요?**

예. 선택한 슬라이드의 도형에만 잠금을 적용하면 됩니다. 이는 다른 슬라이드의 잠금 설정을 변경하지 않습니다.

**그룹 내 개별 도형에 잠금을 적용하려면 어떻게 해야 하나요?**

그룹의 [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) 메서드가 반환하는 컬렉션을 순회하면서 각 자식 도형에 적절한 잠금을 적용합니다. 중첩된 그룹이 있는 경우에도 동일하게 수행하며, 보고서 예제의 순회를 따라갑니다.