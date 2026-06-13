---
title: JavaScript에서 프레젠테이션 슬라이드 마스터 관리
linktitle: 슬라이드 마스터
type: docs
weight: 70
url: /ko/nodejs-java/slide-master/
keywords:
- 슬라이드 마스터
- 마스터 슬라이드
- PPT 마스터 슬라이드
- 다중 마스터 슬라이드
- 마스터 슬라이드 비교
- 배경
- 플레이스홀더
- 마스터 슬라이드 복제
- 마스터 슬라이드 복사
- 마스터 슬라이드 중복
- 사용되지 않는 마스터 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java에서 슬라이드 마스터를 관리합니다: PowerPoint 및 OpenDocument 프레젠테이션에서 마스터 슬라이드를 접근, 편집, 복제, 비교 및 제거합니다."
---
## **개요**

A **slide master**는 그룹 슬라이드에 대한 공유 디자인 설정을 정의합니다. 여기에는 일반 도형, 로고, 배경, 텍스트 스타일, 테마 설정 및 바닥글 설정이 포함될 수 있습니다. PowerPoint에서 슬라이드 마스터를 편집하는 것이 프레젠테이션을 일관되게 유지하고 모든 슬라이드에 동일한 서식을 반복 적용하지 않는 일반적인 방법입니다.

Aspose.Slides for Node.js via Java도 동일한 모델을 지원합니다. 프레젠테이션에는 하나 이상의 마스터 슬라이드가 포함될 수 있으며, 각 마스터 슬라이드에는 여러 레이아웃 슬라이드가 포함될 수 있습니다. 일반 슬라이드는 보통 마스터 슬라이드를 직접 참조하지 않습니다. 대신 일반 슬라이드는 레이아웃 슬라이드를 사용하고, 그 레이아웃 슬라이드는 마스터 슬라이드에 속합니다.

계층 구조는 다음과 같습니다:

1. **Slide master** - 공유 디자인 및 테마를 정의합니다.
1. **Layout slide** - 플레이스홀더와 레이아웃 수준 서식의 특정 배치를 정의합니다.
1. **Normal slide** - 실제 프레젠테이션 콘텐츠를 포함하고 하나의 레이아웃 슬라이드를 사용합니다.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Aspose.Slides에서 슬라이드 마스터는 [MasterSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterslide/) 클래스로 표현됩니다. 프레젠테이션의 모든 마스터 슬라이드는 `Presentation.getMasters()` 컬렉션을 통해 접근할 수 있습니다.

{{% alert color="info" title="상속" %}}
여러 수준에서 동일한 속성이 정의된 경우, 더 구체적인 수준이 우선합니다. 예를 들어 마스터 슬라이드와 레이아웃 슬라이드 모두 배경을 정의한 경우, 해당 레이아웃을 기반으로 한 슬라이드는 레이아웃 배경을 사용합니다. 레이아웃 슬라이드에 대한 자세한 내용은 [슬라이드 레이아웃 적용 또는 변경](/nodejs-java/slide-layout/)을 참조하세요.
{{% /alert %}}

## **슬라이드 마스터 액세스**

PowerPoint에서 **View** > **Slide Master**를 통해 슬라이드 마스터 보기를 열 수 있습니다.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Aspose.Slides에서는 `getMasters()` 컬렉션을 사용하여 마스터 슬라이드에 접근합니다:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

또한 일반 슬라이드의 레이아웃을 통해 사용 중인 마스터 슬라이드를 가져올 수 있습니다:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **슬라이드 마스터에 포함된 내용**

마스터 슬라이드는 슬라이드와 유사한 객체입니다. [BaseSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseslide/)으로부터 공통 슬라이드 동작을 상속받아 일반 슬라이드와 레이아웃 슬라이드에서 사용되는 많은 슬라이드 속성을 제공합니다. 마스터 전용 멤버는 [MasterSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterslide/) API 페이지에 나열되어 있습니다.

주로 사용되는 마스터 슬라이드 멤버는 다음과 같습니다:

| 멤버 | 목적 |
| --- | --- |
| `getBackground()` | 마스터 수준 슬라이드 배경을 설정합니다. |
| `getShapes()` | 로고, 그림 프레임, 공유 텍스트와 같이 마스터에 배치된 도형을 저장합니다. |
| `getLayoutSlides()` | 마스터에 속하는 레이아웃 슬라이드를 저장합니다. |
| `getThemeManager()` | 마스터 테마 API에 접근할 수 있습니다. |
| `getHeaderFooterManager()` | 마스터와 그 하위 레이아웃의 머리글, 바닥글, 날짜 및 슬라이드 번호를 제어합니다. |
| `getDependingSlides()` | 레이아웃을 통해 마스터에 의존하는 일반 슬라이드를 반환합니다. |

## **슬라이드 마스터에 이미지 추가**

마스터 슬라이드에 이미지를 추가하면 해당 마스터의 레이아웃을 사용하는 모든 슬라이드에 표시됩니다. 로고, 워터마크, 장식 밴드 등 반복되는 시각 요소에 유용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 로고를 추가합니다:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

그림 프레임에 대한 자세한 내용은 [그림 프레임](/nodejs-java/picture-frame/)을 참조하세요.

## **플레이스홀더 작업**

플레이스홀더는 일반적으로 레이아웃 슬라이드에 정의됩니다. 마스터 슬라이드는 레이아웃이 상속받는 공유 스타일과 테마를 제공하고, 각 레이아웃은 사용 가능한 플레이스홀더와 그 위치를 결정합니다.

PowerPoint에서는 슬라이드 마스터 보기에서 플레이스홀더 명령을 사용할 수 있습니다.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Aspose.Slides에서 새 플레이스홀더를 추가하려면 마스터에 속한 레이아웃 슬라이드와 작업합니다:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이미 마스터 슬라이드에 존재하는 플레이스홀더 도형도 서식 지정할 수 있습니다. 다음 예제는 제목 플레이스홀더를 찾아 선형 그라디언트 채우기를 적용합니다:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![일반 슬라이드에 상속된 서식이 적용된 제목 플레이스홀더](slide-master_8.png)

플레이스홀더 및 텍스트 서식 옵션에 대해서는 [플레이스홀더에 프롬프트 텍스트 설정](/nodejs-java/manage-placeholder/)과 [텍스트 서식](/nodejs-java/text-formatting/)을 참고하세요.

## **슬라이드 마스터 배경 변경**

마스터 배경은 레이아웃 및 해당 배경을 재정의하지 않은 슬라이드에 상속됩니다. 다음 예제는 첫 번째 마스터 슬라이드에 단색 배경 색을 설정합니다:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

관련 내용은 [프레젠테이션 배경](/nodejs-java/presentation-background/) 및 [프레젠테이션 테마](/nodejs-java/presentation-theme/)를 참조하세요.

## **슬라이드 마스터를 다른 프레젠테이션에 복제**

`MasterSlideCollection.addClone`을 사용하여 마스터 슬라이드를 다른 프레젠테이션에 복사합니다. 복제된 마스터는 대상 프레젠테이션의 레이아웃 및 슬라이드에서 사용할 수 있습니다.

```javascript
let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

마스터와 함께 일반 슬라이드도 복제해야 하는 경우는 [슬라이드 복제](/nodejs-java/clone-slides/)를 참고하세요.

## **다중 슬라이드 마스터 추가**

프레젠테이션에는 여러 개의 마스터 슬라이드를 포함할 수 있습니다. 이는 섹션마다 다른 브랜딩, 페이지 구조 또는 테마 설정이 필요할 때 유용합니다.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

다음 예제는 기본 마스터를 복제하고, 복제본에 다른 배경을 적용한 뒤, 해당 복제 마스터 아래에 레이아웃을 만들고, 그 레이아웃을 기반으로 새 슬라이드를 추가합니다:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **슬라이드 마스터 비교**

마스터 슬라이드는 [BaseSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseslide/)에서 상속받은 `equals` 메서드를 사용해 비교할 수 있습니다. 비교는 구조와 정적 콘텐츠(도형, 텍스트, 서식, 애니메이션 및 기타 슬라이드 설정)를 검사합니다. 슬라이드 ID와 같은 고유 식별자나 현재 날짜와 같은 동적 플레이스홀더 값은 비교하지 않습니다.

```javascript
let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

자세한 내용은 [프레젠테이션 슬라이드 비교](/nodejs-java/compare-slides/)를 확인하세요.

## **슬라이드 마스터 보기를 기본 보기로 설정**

[ViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/)의 `setLastView` 메서드를 사용하여 PowerPoint가 처음 열 때 표시할 보기를 제어합니다. 다음 예제는 프레젠테이션을 슬라이드 마스터 보기로 엽니다:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

다른 보기 설정에 대해서는 [프레젠테이션 저장](/nodejs-java/save-presentation/)을 참고하세요.

## **사용되지 않는 마스터 슬라이드 제거**

프레젠테이션에 더 이상 일반 슬라이드에서 사용되지 않는 마스터 슬라이드가 포함될 수 있습니다. 사용되지 않는 마스터를 제거하면 파일 크기를 줄이고 템플릿 관리가 간소화됩니다.

`removeUnused`를 사용하여 `getMasters()` 컬렉션에서 사용되지 않는 마스터를 제거합니다:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

또는 저코드 `Compress.removeUnusedMasterSlides` 메서드를 사용할 수도 있습니다:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**슬라이드 마스터와 레이아웃 슬라이드의 차이점은 무엇인가요?**

슬라이드 마스터는 테마, 배경, 공통 도형 및 텍스트 스타일과 같은 공유 디자인 설정을 정의합니다. 레이아웃 슬라이드는 마스터에 속하며 플레이스홀더의 특정 배치를 정의합니다. 일반 슬라이드는 레이아웃 슬라이드를 사용하므로 레이아웃과 마스터 양쪽으로부터 상속받습니다.

**하나의 프레젠테이션에 여러 슬라이드 마스터를 포함할 수 있나요?**

예. 프레젠테이션에 여러 슬라이드 마스터를 포함할 수 있습니다. 섹션마다 다른 시각 체계나 브랜딩이 필요할 때 다중 마스터를 사용하십시오.

**플레이스홀더는 마스터 슬라이드에 추가해야 하나요, 레이아웃 슬라이드에 추가해야 하나요?**

대부분의 경우 레이아웃 슬라이드에 플레이스홀더를 추가합니다. 공유 시각 요소와 공통 서식은 마스터 슬라이드에 두고, 실제 콘텐츠 플레이스홀더는 일반 슬라이드가 사용할 레이아웃에 배치합니다.

**사용 중인 마스터 슬라이드를 삭제할 수 있나요?**

아니요. 종속 슬라이드가 있는 마스터 슬라이드는 직접 삭제하면 안전하지 않습니다. 먼저 해당 슬라이드를 다른 마스터의 레이아웃으로 이동하거나, 사용되지 않은 마스터만 제거하는 정리 방법을 사용하세요.