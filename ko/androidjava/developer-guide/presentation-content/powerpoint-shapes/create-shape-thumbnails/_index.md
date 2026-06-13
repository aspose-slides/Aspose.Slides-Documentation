---
title: Android에서 프레젠테이션 도형 섬네일 만들기
linktitle: 도형 섬네일
type: docs
weight: 70
url: /ko/androidjava/create-shape-thumbnails/
keywords:
- 도형 섬네일
- 도형 이미지
- 도형 렌더링
- 도형 렌더링
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 슬라이드에서 고품질 도형 섬네일을 생성하고, 프레젠테이션 섬네일을 손쉽게 만들고 내보냅니다."
---
## **소개**

Aspose.Slides for Android via Java는 각 페이지가 슬라이드에 해당하는 프레젠테이션 파일을 만들 때 사용할 수 있습니다. 슬라이드는 Microsoft PowerPoint를 사용하여 프레젠테이션 파일을 열어 볼 수 있습니다. 그러나 개발자는 때때로 도형의 이미지를 별도의 이미지 뷰어에서 확인해야 할 필요가 있습니다. 이러한 경우 Aspose.Slides for Android via Java는 슬라이드 도형의 썸네일 이미지를 생성하는 데 도움을 줍니다.

이 항목에서는 다양한 상황에서 슬라이드 썸네일을 생성하는 방법을 보여줍니다:

- 슬라이드 내부에서 도형 썸네일 생성.
- 사용자 정의 치수로 슬라이드 도형의 썸네일 생성.
- 도형 외관 경계 내에서 도형 썸네일 생성.

## **슬라이드에서 도형 썸네일 생성**
Aspose.Slides for Android via Java를 사용하여 任意의 슬라이드에서 도형 썸네일을 생성하려면 다음을 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스를 사용하여 任意의 슬라이드 참조를 가져옵니다.
3. [Get the shape thumbnail image](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape#getImage--) 를 기본 배율로 참조된 슬라이드에서 가져옵니다.
4. 선호하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 슬라이드에서 도형 썸네일을 생성하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 전체 크기 이미지를 생성합니다
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // 이미지를 PNG 형식으로 디스크에 저장합니다
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **사용자 정의 스케일링 팩터 썸네일 생성**
Aspose.Slides for Android via Java를 사용하여 슬라이드의 도형 썸네일을 생성하려면 다음을 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스를 사용하여 任意의 슬라이드 참조를 가져옵니다.
3. [Get the shape thumbnail image](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) 를 사용자 정의 차원으로 참조된 슬라이드에서 가져옵니다.
4. 선호하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 정의된 스케일링 팩터를 기반으로 도형 썸네일을 생성하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 전체 크기 이미지를 생성합니다
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // 이미지를 PNG 형식으로 디스크에 저장합니다
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **경계 기반 도형 외관 썸네일 만들기**
이 방법을 사용하면 개발자는 도형 외관의 경계 내에서 썸네일을 생성할 수 있습니다. 모든 도형 효과를 고려합니다. 생성된 도형 썸네일은 슬라이드 경계에 제한됩니다. 도형 외관 경계 내에서 슬라이드 도형의 썸네일을 생성하려면 다음을 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스를 사용하여 任意의 슬라이드 참조를 가져옵니다.
3. 도형 경계를 외관으로 하여 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
4. 선호하는 이미지 형식으로 썸네일 이미지를 저장합니다.

위 단계에 기반한 샘플 코드는 다음과 같습니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 전체 크기 이미지를 생성합니다
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // 이미지를 PNG 형식으로 디스크에 저장합니다
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**도형 썸네일을 저장할 때 사용할 수 있는 이미지 형식은 무엇입니까?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imageformat/), 및 기타 형식. 도형은 또한 도형 내용을 SVG로 저장하여 [vector SVG로 내보낼 수 있습니다](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**썸네일을 렌더링할 때 Shape 경계와 Appearance 경계의 차이점은 무엇입니까?**

`Shape`는 도형의 기하학을 사용하고; `Appearance`는 [시각 효과](/slides/ko/androidjava/shape-effect/) (그림자, 글로우 등)을 고려합니다.

**도형이 hidden으로 표시되면 어떻게 되나요? 여전히 썸네일로 렌더링됩니까?**

숨겨진 도형은 모델의 일부로 남아 있으며 렌더링될 수 있습니다; hidden 플래그는 슬라이드쇼 표시에는 영향을 주지만 도형 이미지 생성은 방해하지 않습니다.

**그룹 도형, 차트, SmartArt 및 기타 복잡한 객체가 지원됩니까?**

예. [Shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/)으로 표시되는 모든 객체( [GroupShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/chart/), 및 [SmartArt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/smartart/) 포함)는 썸네일이나 SVG로 저장할 수 있습니다.

**시스템에 설치된 글꼴이 텍스트 도형의 썸네일 품질에 영향을 줍니까?**

예. 원치 않는 대체 및 텍스트 흐름을 피하려면 [필요한 글꼴을 제공](/slides/ko/androidjava/custom-font/)하거나 [글꼴 대체를 구성](/slides/ko/androidjava/font-substitution/)해야 합니다.