---
title: JavaScript에서 프레젠테이션 도형 썸네일 생성
linktitle: 도형 썸네일
type: docs
weight: 70
url: /ko/nodejs-java/create-shape-thumbnails/
keywords:
- 도형 썸네일
- 도형 이미지
- 도형 렌더링
- 도형 렌더링
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 PowerPoint 슬라이드에서 고품질 도형 썸네일을 생성하고, 프레젠테이션 썸네일을 손쉽게 만들고 내보낼 수 있습니다."
---
## **소개**

Aspose.Slides는 각 페이지가 슬라이드인 프레젠테이션 파일을 만드는 데 사용됩니다. 이러한 슬라이드는 Microsoft PowerPoint로 프레젠테이션 파일을 열어 볼 수 있습니다. 그러나 때때로 개발자는 도형의 이미지를 별도의 이미지 뷰어에서 보고 싶을 수 있습니다. 이러한 경우 Aspose.Slides를 사용하여 슬라이드 도형의 썸네일 이미지를 생성할 수 있습니다. 이 기능을 사용하는 방법은 이 문서에 설명되어 있습니다.
이 문서는 슬라이드 썸네일을 다양한 방법으로 생성하는 방법을 설명합니다:

- 슬라이드 내부의 도형 썸네일 생성
- 사용자 정의 크기로 슬라이드 도형의 썸네일 생성
- 도형 외관의 경계 내에서 썸네일 생성

## **슬라이드에서 도형 썸네일 생성**
Aspose.Slides for Node.js via Java를 사용하여 任意 슬라이드에서 도형 썸네일을 생성하려면 다음을 수행합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스로 任意 슬라이드의 참조를 가져옵니다.
1. [형태 썸네일 이미지 가져오기](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getImage--)를 사용해 기본 배율로 참조된 슬라이드의 썸네일 이미지를 얻습니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 슬라이드에서 도형 썸네일을 생성하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스 인스턴스화
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 전체 배율 이미지 생성
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // 이미지를 PNG 형식으로 디스크에 저장
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **사용자 정의 배율 팩터로 도형 썸네일 생성**
Aspose.Slides for Node.js via Java를 사용하여 슬라이드 도형의 썸네일을 생성하려면 다음을 수행합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스로 任意 슬라이드의 참조를 가져옵니다.
1. [사용자 정의 크기로 형태 썸네일 이미지 가져오기](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getImage-int-float-float-)를 사용해 지정된 배율로 참조된 슬라이드의 썸네일 이미지를 얻습니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 정의된 배율 팩터를 기반으로 도형 썸네일을 생성하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 전체 배율 이미지 생성
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // 이미지를 PNG 형식으로 디스크에 저장합니다
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **경계 기반 도형 썸네일 생성**
이 방법은 개발자가 도형의 외관 경계 내에서 썸네일을 생성하도록 합니다. 모든 도형 효과를 고려하며, 생성된 도형 썸네일은 슬라이드 경계에 제한됩니다. 외관 경계 내에서 슬라이드 도형의 썸네일을 생성하려면 다음을 수행합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스로 任意 슬라이드의 참조를 가져옵니다.
1. 외관을 기준으로 도형 경계를 사용해 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 위 단계에 기반합니다:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 전체 배율 이미지 생성
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // 이미지를 PNG 형식으로 디스크에 저장합니다
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**도형 썸네일을 저장할 때 사용할 수 있는 이미지 형식은 무엇입니까?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/imageformat/), 등. 도형은 [SVG 벡터 형식으로 내보내기](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/writeassvg/)도 가능합니다.

**썸네일을 렌더링할 때 Shape와 Appearance 경계의 차이점은 무엇입니까?**

`Shape`는 도형의 기하학적 형태를 사용하고, `Appearance`는 [시각 효과](/slides/ko/nodejs-java/shape-effect/) (그림자, 글로우 등)를 고려합니다.

**도형이 숨김으로 표시되면 어떻게 됩니까? 썸네일에 여전히 표시됩니까?**

숨김 도형은 모델의 일부로 남아 있으며 렌더링될 수 있습니다. 숨김 플래그는 슬라이드 쇼 표시에는 영향을 주지만 도형 이미지 생성에는 영향을 주지 않습니다.

**그룹 도형, 차트, SmartArt 및 기타 복합 객체가 지원됩니까?**

예. [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/)로 표현되는 모든 객체(예: [GroupShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/), [SmartArt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartart/))는 썸네일 또는 SVG로 저장할 수 있습니다.

**시스템에 설치된 폰트가 텍스트 도형 썸네일 품질에 영향을 줍니까?**

예. 원하지 않는 폰트 대체 및 텍스트 재배치를 방지하려면 [필요한 폰트 제공](/slides/ko/nodejs-java/custom-font/) (또는 [폰트 대체 구성](/slides/ko/nodejs-java/font-substitution/))이 필요합니다.