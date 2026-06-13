---
title: 슬라이드
type: docs
weight: 10
url: /ko/nodejs-java/examples/elements/slide/
keywords:
- 코드 예제
- 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 슬라이드를 제어합니다: 만들기, 복제, 순서 변경, 크기 조정, 배경 설정 및 PPT, PPTX, ODP 프레젠테이션에 전환 효과 적용."
---
이 문서에서는 **Aspose.Slides for Node.js via Java**를 사용하여 슬라이드를 작업하는 방법을 보여주는 일련의 예제를 제공합니다. `Presentation` 클래스를 사용하여 슬라이드를 추가, 액세스, 복제, 순서 변경 및 제거하는 방법을 배울 수 있습니다.

아래 각 예제는 간단한 설명과 JavaScript 코드 스니펫을 포함합니다.

## **슬라이드 추가**

새 슬라이드를 추가하려면 먼저 레이아웃을 선택해야 합니다. 이 예제에서는 `Blank` 레이아웃을 사용하여 프레젠테이션에 빈 슬라이드를 추가합니다.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note:** 각 슬라이드 레이아웃은 마스터 슬라이드에서 파생되며, 마스터 슬라이드는 전체 디자인과 자리 표시자 구조를 정의합니다. 아래 이미지는 PowerPoint에서 마스터 슬라이드와 해당 레이아웃이 어떻게 구성되는지 보여줍니다.

![마스터 및 레이아웃 관계](master-layout-slide.png)

## **인덱스로 슬라이드 액세스**

인덱스를 사용하여 슬라이드에 액세스할 수 있습니다. 이는 슬라이드를 반복하거나 특정 슬라이드를 수정할 때 유용합니다.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // 인덱스로 슬라이드에 접근합니다.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **슬라이드 복제**

이 예제는 기존 슬라이드를 복제하는 방법을 보여줍니다. 복제된 슬라이드는 슬라이드 컬렉션의 끝에 자동으로 추가됩니다.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **슬라이드 순서 변경**

슬라이드를 새 인덱스로 이동시켜 순서를 변경할 수 있습니다. 여기서는 슬라이드를 첫 번째 위치로 이동합니다.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // 두 번째 슬라이드를 첫 번째 위치로 이동하여 슬라이드 순서를 재배열합니다.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **슬라이드 제거**

슬라이드를 제거하려면 해당 슬라이드를 참조하고 `remove`를 호출하면 됩니다. 이 예제에서는 두 번째 슬라이드를 추가한 후 원래 슬라이드를 제거하여 새 슬라이드만 남깁니다.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```