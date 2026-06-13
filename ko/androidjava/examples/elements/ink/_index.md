---
title: 잉크
type: docs
weight: 180
url: /ko/androidjava/examples/elements/ink/
keywords:
- 코드 예제
- 잉크
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android에서 잉크 작업: 스트로크를 그리기, 가져오기 및 편집, 색상과 두께 조정, Java 예제를 사용하여 PPT, PPTX 및 ODP로 내보내기."
---
이 문서에서는 기존 잉크 도형에 접근하고 이를 제거하는 예제를 **Aspose.Slides for Android via Java**를 사용하여 제공합니다.

> ❗ **Note:** 잉크 도형은 특수 장치에서 사용자의 입력을 나타냅니다. Aspose.Slides는 프로그래밍 방식으로 새로운 잉크 스트로크를 생성할 수 없지만, 기존 잉크를 읽고 수정할 수 있습니다.

## **잉크 접근**

슬라이드에서 첫 번째 잉크 도형의 태그를 읽습니다.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // 필요에 따라 tagName을 사용합니다.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **잉크 제거**

슬라이드에 잉크 도형이 존재한다면 이를 삭제합니다.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```