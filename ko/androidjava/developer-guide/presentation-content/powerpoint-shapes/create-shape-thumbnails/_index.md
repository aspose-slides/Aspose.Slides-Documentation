---
title: Android에서 프레젠테이션 도형 썸네일 만들기
linktitle: 도형 썸네일
type: docs
weight: 70
url: /ko/androidjava/create-shape-thumbnails/
keywords:
- 도형 썸네일
- 도형 이미지
- 도형 렌더링
- 도형 렌더링
- 시각적 경계
- 도형 경계
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 슬라이드에서 고품질 도형 썸네일을 생성하고, 프레젠테이션 썸네일을 손쉽게 만들고 내보냅니다."
---
## **소개**

Aspose.Slides for Android via Java를 사용하면 각 페이지가 슬라이드에 해당하는 프레젠테이션 파일을 만들 수 있습니다. 프레젠테이션 파일은 Microsoft PowerPoint로 열어 슬라이드를 확인할 수 있습니다. 그러나 개발자는 때때로 도형 이미지를 별도의 이미지 뷰어에서 확인해야 할 필요가 있습니다. 이러한 경우 Aspose.Slides for Android via Java가 슬라이드 도형의 썸네일 이미지를 생성하도록 도와줍니다.

본 문서에서는 다양한 상황에서 슬라이드 썸네일을 생성하는 방법을 보여줍니다.

- 슬라이드 내 도형 썸네일 생성
- 사용자 정의 크기로 슬라이드 도형 썸네일 생성
- 도형 외형 경계 내부에 도형 썸네일 생성

## **슬라이드에서 도형 썸네일 생성**
Aspose.Slides for Android via Java를 사용하여任意의 슬라이드에서 도형 썸네일을 생성하려면 다음을 수행합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드 ID 또는 인덱스로 任意의 슬라이드에 대한 참조를 가져옵니다.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape#getImage--) 메서드를 사용하여 기본 배율로 참조된 슬라이드의 도형 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

이 샘플 코드는 슬라이드에서 도형 썸네일을 생성하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 전체 배율 이미지 생성
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

## **사용자 정의 배율 팩터 썸네일 생성**
Aspose.Slides for Android via Java를 사용하여 슬라이드 도형 썸네일을 사용자 정의 배율로 생성하려면 다음을 수행합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드 ID 또는 인덱스로 任意의 슬라이드에 대한 참조를 가져옵니다.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) 메서드를 사용하여 사용자 정의 차원으로 참조된 슬라이드의 도형 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

이 샘플 코드는 정의된 배율 팩터를 기반으로 도형 썸네일을 생성하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 전체 배율 이미지 생성
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

## **경계 기반 도형 외형 썸네일 생성**
이 방법은 도형 외형의 경계 안에서 썸네일을 생성하도록 개발자를 지원합니다. 모든 도형 효과를 고려합니다. 생성된 도형 썸네일은 슬라이드 경계에 제한됩니다. 외형 경계 내에서 슬라이드 도형의 썸네일을 생성하려면 다음을 수행합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드 ID 또는 인덱스로 任意의 슬라이드에 대한 참조를 가져옵니다.
1. 도형 경계를 외형으로 사용하여 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

위 단계에 기반한 샘플 코드는 다음과 같습니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 전체 배율 이미지 생성
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

## **도형의 실제 시각적 경계 가져오기**

[IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/)의 프레임 속성—`getX()`, `getY()`, `getWidth()`, `getHeight()` 메서드—는 프레젠테이션 모델에 저장된 사각형을 설명합니다. 실제 렌더링되는 콘텐츠는 해당 프레임을 넘어설 수 있거나 다른 축 정렬 사각형을 차지할 수 있습니다. 회전, 외곽선, 화살표 머리, 텍스트 레이아웃 및 오버플로, 생성된 SmartArt 기하학, 기타 렌더링 효과가 모두 차지하는 영역을 변경할 수 있습니다.

[Shape.getVisualBounds](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/#getVisualBounds--) 메서드를 사용하면 이미지를 생성하지 않고도 차지하는 영역을 계산할 수 있습니다. 이 메서드는 슬라이드 좌표계의 [RectF](https://developer.android.com/reference/android/graphics/RectF)를 반환합니다. 반환된 사각형은 슬라이드에 클리핑되지 않으므로 콘텐츠가 슬라이드 원점을 넘어설 경우 좌표가 음수가 될 수 있습니다.

[Shape.getVisualBounds](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/#getVisualBounds--)은 현재 [IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/) 인터페이스에 선언되어 있지 않습니다. 따라서 슬라이드의 도형 컬렉션에서 가져온 도형을 인터페이스 형식으로 보관하고 메서드를 호출할 때만 캐스팅해야 합니다.

다음 예제는 프레임과 시각적 경계를 가져와 비교합니다:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

동일한 [RectF](https://developer.android.com/reference/android/graphics/RectF)를 사용하여 인접 도형을 왼쪽, 오른쪽, 위쪽 또는 아래쪽 가장자리와 정렬하거나, 생성된 레이아웃에 충분한 여백을 확보하거나, 허용된 영역 밖의 콘텐츠를 감지할 수 있습니다. 시각적 경계는 저장된 프레임이 전체 렌더링 결과를 나타내지 않을 수 있는 SmartArt, 텍스트 상자, 화살표, 이미지, 회전 도형 및 그룹 도형에 특히 유용합니다.

레이아웃이나 검증을 위한 좌표가 필요하고 비트맵이 필요하지 않을 때는 [Shape.getVisualBounds](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/#getVisualBounds--)을 사용하십시오. 도형을 실제로 렌더링해야 할 경우에는 [IShape.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getImage--)을 사용하십시오. [ShapeThumbnailBounds](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shapethumbnailbounds/)에서 `ShapeThumbnailBounds.Shape`는 외곽선 설정을 포함하여 도형 경계에서 이미지를 크기 조정하고, `ShapeThumbnailBounds.Appearance`는 도형의 외형에서 이미지를 크기 조정하며 결과를 슬라이드 경계에 제한합니다. 반면에 [Shape.getVisualBounds](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/#getVisualBounds--)는 계산된 사각형만 반환하고 슬라이드에 클리핑하지 않습니다.

## **FAQ**

**도형 썸네일을 저장할 때 사용할 수 있는 이미지 형식은 무엇인가요?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imageformat/), 및 기타 형식이 지원됩니다. 도형은 [exported as vector SVG](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) 로 저장하여 SVG 벡터로 내보낼 수도 있습니다.

**썸네일을 렌더링할 때 Shape와 Appearance 경계의 차이는 무엇인가요?**

`Shape`는 도형의 기하학을 사용하고, `Appearance`는 [visual effects](/slides/ko/androidjava/shape-effect/) (그림자, 광채 등)을 고려합니다.

**도형이 숨김으로 표시된 경우 어떻게 되나요? 여전히 썸네일로 렌더링됩니까?**

숨김 도형은 모델의 일부로 남아 렌더링할 수 있습니다. 숨김 플래그는 슬라이드 쇼 표시에만 영향을 미치며 도형 이미지 생성은 방해하지 않습니다.

**그룹 도형, 차트, SmartArt 및 기타 복합 객체가 지원되나요?**

예. [Shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/)로 표현되는 모든 객체(예: [GroupShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/chart/), [SmartArt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/smartart/))는 썸네일 또는 SVG로 저장할 수 있습니다.

**시스템에 설치된 글꼴이 텍스트 도형 썸네일 품질에 영향을 미치나요?**

예. 원하지 않는 대체 및 텍스트 재배치를 방지하려면 [필요한 글꼴을 제공](/slides/ko/androidjava/custom-font/)하거나 [글꼴 대체를 구성](/slides/ko/androidjava/font-substitution/)해야 합니다.