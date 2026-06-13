---
title: 레이아웃 슬라이드
type: docs
weight: 20
url: /ko/nodejs-java/examples/elements/layout-slide/
keywords:
- 코드 예제
- 레이아웃 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 마스터 레이아웃 슬라이드: PPT, PPTX 및 ODP 프레젠테이션 예제를 통해 슬라이드 레이아웃, 플레이스홀더 및 마스터를 선택하고 적용하며 사용자 지정합니다."
---
이 문서에서는 Aspose.Slides for Node.js via Java에서 **Layout Slides**를 사용하는 방법을 보여줍니다. 레이아웃 슬라이드는 일반 슬라이드가 상속받는 디자인과 서식을 정의합니다. 레이아웃 슬라이드를 추가, 접근, 복제 및 제거할 수 있으며, 사용되지 않은 레이아웃 슬라이드를 정리하여 프레젠테이션 크기를 줄일 수 있습니다.

## **레이아웃 슬라이드 추가**

재사용 가능한 서식을 정의하기 위해 사용자 지정 레이아웃 슬라이드를 만들 수 있습니다.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // 빈 레이아웃 유형 및 사용자 지정 이름을 사용하여 레이아웃 슬라이드를 생성합니다.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** 레이아웃 슬라이드는 개별 슬라이드의 템플릿 역할을 합니다. 공통 요소를 한 번 정의하면 여러 슬라이드에서 재사용할 수 있습니다.
> 💡 **Note 2:** 레이아웃 슬라이드에 도형이나 텍스트를 추가하면, 해당 레이아웃을 기반으로 하는 모든 슬라이드가 이 공유된 내용을 자동으로 표시합니다.
> 아래 스크린샷은 동일한 레이아웃 슬라이드에서 텍스트 상자를 상속받은 두 개의 슬라이드를 보여줍니다.

![레이아웃 콘텐츠를 상속하는 슬라이드](layout-slide-result.png)

## **레이아웃 슬라이드 접근**

레이아웃 슬라이드는 인덱스 또는 레이아웃 유형(예: `Blank`, `Title`, `SectionHeader` 등)으로 접근할 수 있습니다.

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // 인덱스로 레이아웃 슬라이드에 접근합니다.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // 유형으로 레이아웃 슬라이드에 접근합니다.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **레이아웃 슬라이드 제거**

더 이상 필요하지 않은 경우 특정 레이아웃 슬라이드를 제거할 수 있습니다.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // 유형으로 레이아웃 슬라이드를 가져와 제거합니다.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **사용되지 않은 레이아웃 슬라이드 제거**

프레젠테이션 크기를 줄이기 위해 일반 슬라이드에서 사용되지 않는 레이아웃 슬라이드를 제거할 수 있습니다.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // 자동으로 어떤 슬라이드에서도 참조되지 않은 모든 레이아웃 슬라이드를 제거합니다.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **레이아웃 슬라이드 복제**

`addClone` 메서드를 사용하여 레이아웃 슬라이드를 복제할 수 있습니다.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // 유형으로 기존 레이아웃 슬라이드를 가져옵니다.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // 레이아웃 슬라이드 컬렉션 끝에 레이아웃 슬라이드를 복제합니다.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** 레이아웃 슬라이드는 슬라이드 전반에 걸쳐 일관된 서식을 관리하기 위한 강력한 도구입니다. Aspose.Slides는 레이아웃 슬라이드의 생성, 관리 및 최적화를 완벽하게 제어할 수 있도록 합니다.