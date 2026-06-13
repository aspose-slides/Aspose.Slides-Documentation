---
title: 슬라이드 전환
type: docs
weight: 110
url: /ko/java/examples/elements/slide-transition/
keywords:
- 코드 예제
- 슬라이드 전환
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 슬라이드 전환을 마스터하세요: PPT, PPTX 및 ODP 프레젠테이션을 위한 Java 예제를 사용해 효과와 지속 시간을 추가, 사용자 지정 및 순서화합니다."
---
이 문서는 **Aspose.Slides for Java**를 사용한 슬라이드 전환 효과와 타이밍 적용을 보여줍니다.

## **슬라이드 전환 추가**

첫 번째 슬라이드에 페이드 전환 효과를 적용합니다.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 페이드 전환을 적용합니다.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **슬라이드 전환 접근**

슬라이드에 현재 할당된 전환 유형을 읽습니다.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // 전환 유형에 접근합니다.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **슬라이드 전환 제거**

전환 유형을 `None`으로 설정하여 모든 전환 효과를 제거합니다.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // 전환을 None으로 설정하여 제거합니다.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **전환 지속 시간 설정**

슬라이드가 자동으로 넘어가기 전에 표시되는 시간을 지정합니다.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // 밀리초 단위.
    } finally {
        presentation.dispose();
    }
}
```