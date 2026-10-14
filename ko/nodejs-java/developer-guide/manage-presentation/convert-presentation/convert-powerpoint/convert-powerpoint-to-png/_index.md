---
title: JavaScript에서 PowerPoint 슬라이드를 PNG로 변환
linktitle: PowerPoint를 PNG로 변환
type: docs
weight: 30
url: /ko/nodejs-java/convert-powerpoint-to-png/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 PNG로 변환
- 프레젠테이션을 PNG로 변환
- 슬라이드를 PNG로 변환
- PPT를 PNG로 변환
- PPTX를 PNG로 변환
- PPT를 PNG로 저장
- PPTX를 PNG로 저장
- PPT를 PNG로 내보내기
- PPTX를 PNG로 내보내기
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 JavaScript에서 PowerPoint 프레젠테이션을 고품질 PNG 이미지로 빠르게 변환하고, 정확하고 자동화된 결과를 보장합니다."
---
## **개요**

이 문서는 Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션 슬라이드를 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX, ODP와 같은 형식의 프레젠테이션을 로드하고, 각 슬라이드를 렌더링한 뒤 별개의 PNG 이미지로 저장할 수 있습니다.

아래 예제에서는 기본 비율로 렌더링, 비율 확대, 픽셀 단위 출력 크기 지정, 그리고 그라디언트 렌더링 스타일 선택 방법을 보여줍니다.

## **PowerPoint를 PNG로 변환**

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드하고 [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) 컬렉션을 통해 슬라이드에 접근합니다. 예제에서는 매 슬라이드를 파라미터 없이 [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) 로 렌더링하여 썸네일을 생성합니다. 그런 다음 [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) 와 [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) 을 사용해 각 렌더링된 슬라이드를 PNG 이미지로 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
파라미터가 없는 [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) 오버로드는 0.2 비율로 렌더링합니다. 예를 들어, 720 × 540 포인트 크기의 슬라이드는 144 × 108 픽셀 썸네일을 생성합니다. 출력 크기를 제어하려면 아래와 같이 비율 인자 또는 명시적인 이미지 크기를 사용하는 오버로드를 활용하세요.
{{% /alert %}}

## **맞춤 비율로 PowerPoint를 PNG로 변환**

[Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage)에 가로 및 세로 비율 인자를 전달하여 렌더링 크기를 제어합니다. 이 예제에서는 두 인자가 모두 2이므로 720 × 540 포인트 슬라이드가 1440 × 1080 픽셀 이미지로 변환됩니다. 동일한 비율을 사용하면 슬라이드의 종횡비가 유지됩니다. 각 이미지는 [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) 로 PNG 형식으로 저장됩니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **맞춤 크기로 PowerPoint를 PNG로 변환**

픽셀 단위 출력 크기를 지정하려면 비율 인자 대신 크기를 [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) 에 전달합니다. 이 예제에서는 모든 슬라이드를 960 × 720 픽셀로 렌더링하고 [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) 로 저장합니다. 슬라이드의 종횡비에 맞는 크기를 선택하여 이미지가 늘어나지 않도록 하세요.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **그라디언트 렌더링 스타일 선택**

슬라이드에 그라디언트 채우기가 포함되어 있지만, 내보낸 PNG에서 전환이 PowerPoint에서 보는 것보다 더 밝거나 다르게 보이는 경우가 있습니다. 이때 [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/)가 상속하는 [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) 메서드를 사용해 그라디언트 렌더링 방식을 선택할 수 있습니다.

[gradient-styles.pptx](gradient-styles.pptx)를 다운로드하여 애플리케이션 작업 디렉터리에 배치합니다. 첫 번째 슬라이드에는 위쪽에 시안‑오렌지, 아래쪽에 파랑‑노랑 두 개의 선형 그라디언트가 포함되어 있습니다. 각 그라디언트는 0%와 100%에 두 개의 정지점을 갖습니다.

다음 예제는 이 프레젠테이션을 로드하고 [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) 로 두 모드 모두에서 동일한 첫 번째 슬라이드를 렌더링합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

아래 이미지는 동일한 슬라이드에서 두 그라디언트를 각각 렌더링한 결과를 보여줍니다.

| Default | PowerPointUI |
| --- | --- |
| ![기본 스타일로 렌더링한 시안‑오렌지 및 파랑‑노랑 그라디언트](gradient-Default.png) | ![PowerPointUI 스타일로 렌더링한 동일한 그라디언트](gradient-PowerPointUI.png) |

이 예제에서 `Default`는 중간 색상이 더 밝게 나타나고, `PowerPointUI`는 더 어둡게 나타납니다. 차이는 그라디언트의 색상 및 정지점에 따라 달라집니다.

표준 Aspose.Slides 출력이 요구 사항에 부합한다면 `Default`를 선택하고, PowerPoint와 외观을 맞추는 것이 우선이라면 `PowerPointUI`를 사용해 보세요. 두 출력 모두를 비교해 보고 원하는 결과에 가장 가까운 방식을 선택하십시오. 어느 한쪽이 보편적으로 더 우수하다고 말할 수 없습니다.

## **FAQ**

**특정 도형(예: 차트 또는 그림)을 전체 슬라이드가 아니라 개별적으로 내보내려면 어떻게 해야 하나요?**

Aspose.Slides는 [개별 도형에 대한 썸네일 생성](/slides/ko/nodejs-java/create-shape-thumbnails/)을 지원하므로 도형을 PNG 이미지로 렌더링할 수 있습니다.

**서버에서 병렬 변환이 지원되나요?**

예. 각 스레드 또는 프로세스마다 별도의 프레젠테이션 인스턴스를 사용하세요. [스레드 간에 하나의 인스턴스를 공유하지 말 것](/slides/ko/nodejs-java/multithreading/)이 권장됩니다.

**PNG로 내보낼 때 평가판 제한은 무엇인가요?**

평가판 모드에서는 출력 이미지에 워터마크가 추가되고, 라이선스를 적용하기 전까지 [다른 제한](/slides/ko/nodejs-java/licensing/)이 적용됩니다.