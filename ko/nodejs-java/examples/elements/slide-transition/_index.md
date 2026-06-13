---
title: 슬라이드 전환
type: docs
weight: 110
url: /ko/nodejs-java/examples/elements/slide-transition/
keywords:
- 코드 예제
- 슬라이드 전환
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 슬라이드 전환을 마스터하세요: PPT, PPTX 및 ODP 프레젠테이션 예제와 함께 효과와 지속 시간을 추가, 사용자 정의 및 순서 지정합니다."
---
이 문서는 **Aspose.Slides for Node.js via Java**를 사용하여 슬라이드 전환 효과와 타이밍을 적용하는 방법을 보여줍니다.

## **슬라이드 전환 추가**

첫 번째 슬라이드에 페이드 전환 효과를 적용합니다.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 페이드 전환을 적용합니다.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **슬라이드 전환 읽기**

슬라이드에 현재 할당된 전환 유형을 읽습니다.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 전환 유형에 접근합니다.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **슬라이드 전환 제거**

전환 유형을 `None`으로 설정하여 모든 전환 효과를 제거합니다.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 전환을 None으로 설정하여 제거합니다.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **전환 지속 시간 설정**

슬라이드가 자동으로 진행되기 전에 표시되는 지속 시간을 지정합니다.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // 밀리초 단위.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```