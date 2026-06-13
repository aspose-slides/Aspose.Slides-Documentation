---
title: 슬라이드
type: docs
weight: 10
url: /ko/java/examples/elements/slide/
keywords:
- 코드 예제
- 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 슬라이드를 제어합니다: PPT, PPTX 및 ODP 프레젠테이션을 위해 Java로 슬라이드를 생성하고, 복제하고, 순서를 변경하고, 크기를 조정하고, 배경을 설정하며 전환 효과를 적용합니다."
---
이 문서에서는 **Aspose.Slides for Java**를 사용하여 슬라이드 작업을 수행하는 방법을 보여주는 일련의 예제를 제공합니다. `Presentation` 클래스를 사용하여 슬라이드를 추가, 접근, 복제, 순서 변경 및 삭제하는 방법을 배우게 됩니다.

아래 각 예제는 간단한 설명과 Java 코드 스니펫을 포함합니다.

## **슬라이드 추가**

새 슬라이드를 추가하려면 먼저 레이아웃을 선택해야 합니다. 이 예제에서는 `Blank` 레이아웃을 사용하여 프레젠테이션에 빈 슬라이드를 추가합니다.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note:** 각 슬라이드 레이아웃은 전체 디자인 및 플레이스홀더 구조를 정의하는 마스터 슬라이드에서 파생됩니다. 아래 이미지에서는 파워포인트에서 마스터 슬라이드와 해당 레이아웃이 어떻게 구성되는지 보여줍니다.

![마스터와 레이아웃 관계](master-layout-slide.png)

## **인덱스로 슬라이드 접근**

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // 다른 빈 슬라이드 추가.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // 인덱스로 슬라이드 접근.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // 참조에서 슬라이드 인덱스를 가져와 인덱스로 접근.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **슬라이드 복제**

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **슬라이드 순서 변경**

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **슬라이드 삭제**

슬라이드를 삭제하려면 해당 슬라이드를 참조하고 `remove`를 호출하면 됩니다. 이 예제에서는 두 번째 슬라이드를 추가한 후 원본 슬라이드를 삭제하여 새 슬라이드만 남깁니다.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```