---
title: Java에서 프레젠테이션 도형 썸네일 만들기
linktitle: 도형 썸네일
type: docs
weight: 70
url: /ko/java/create-shape-thumbnails/
keywords:
- 도형 썸네일
- 도형 이미지
- 도형 렌더링
- 도형 렌더링
- 시각적 경계
- 도형 경계
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 슬라이드에서 고품질 도형 썸네일을 생성하고, 프레젠테이션 썸네일을 손쉽게 만들고 내보냅니다."
---
## **소개**

Aspose.Slides for Java는 각 페이지가 슬라이드에 해당하는 프레젠테이션 파일을 생성하는 데 사용할 수 있습니다. 슬라이드는 Microsoft PowerPoint를 사용해 프레젠테이션 파일을 열어 확인할 수 있습니다. 그러나 개발자는 때때로 도형 이미지를 이미지 뷰어에서 별도로 보고 싶어 합니다. 이러한 경우 Aspose.Slides for Java는 슬라이드 도형의 썸네일 이미지를 생성하도록 도와줍니다.

이 문서에서는 슬라이드 썸네일을 다양한 방법으로 생성하는 방법을 설명합니다.

- 슬라이드 내 도형 썸네일 생성
- 사용자 정의 크기로 슬라이드 도형 썸네일 생성
- 도형 외관의 경계 내에서 썸네일 생성

## **슬라이드에서 도형 썸네일 생성**
Aspose.Slides for Java를 사용하여 任意 슬라이드에서 도형 썸네일을 생성하려면 다음을 수행합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용해 任意 슬라이드에 대한 참조를 가져옵니다.
1. [기본 스케일로 참조된 슬라이드의 도형 썸네일 이미지를 가져옵니다](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getImage--) .
1. 원하는 이미지 형식으로 썸네일을 저장합니다.

다음 샘플 코드는 슬라이드에서 도형 썸네일을 생성하는 방법을 보여줍니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 전체 크기의 이미지를 생성합니다
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
Aspose.Slides for Java를 사용하여 슬라이드 도형 썸네일을 생성하려면 다음을 수행합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용해 任意 슬라이드에 대한 참조를 가져옵니다.
1. [사용자 정의 차원으로 참조된 슬라이드의 도형 썸네일 이미지를 가져옵니다](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getImage-int-float-float-) .
1. 원하는 이미지 형식으로 썸네일을 저장합니다.

다음 샘플 코드는 정의된 스케일링 팩터를 기반으로 도형 썸네일을 생성하는 방법을 보여줍니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 전체 크기의 이미지를 생성합니다
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

## **경계 기반 도형 외관 썸네일 생성**
이 방법은 개발자가 도형 외관의 경계 내에서 썸네일을 생성할 수 있도록 합니다. 모든 도형 효과를 고려합니다. 생성된 도형 썸네일은 슬라이드 경계에 제한됩니다. 외관 경계 내에서 슬라이드 도형의 썸네일을 생성하려면 다음을 수행합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용해 任意 슬라이드에 대한 참조를 가져옵니다.
1. 도형 경계를 외관으로 사용하여 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일을 저장합니다.

다음 샘플 코드는 위 단계에 기반합니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 전체 크기의 이미지를 생성합니다
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

[IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/)의 프레임 속성—`getX()`, `getY()`, `getWidth()`, `getHeight()` 메서드—는 프레젠테이션 모델에 저장된 사각형을 설명합니다. 실제로 렌더링되는 내용은 해당 프레임을 벗어나거나 다른 축 정렬 사각형을 차지할 수 있습니다. 회전, 윤곽선, 화살표 머리, 텍스트 레이아웃 및 넘침, 생성된 SmartArt 기하학 및 기타 렌더링 효과가 차지하는 영역을 모두 변경할 수 있습니다.

이미지를 생성하지 않고 차지하는 영역을 계산하려면 [Shape.getVisualBounds](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getVisualBounds--) 를 사용하십시오. 이 메서드는 슬라이드 좌표계의 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 를 반환합니다. 반환된 사각형은 슬라이드에 클리핑되지 않으므로 내용이 슬라이드 원점을 넘어설 경우 좌표가 음수가 될 수 있습니다.

[Shape.getVisualBounds](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getVisualBounds--) 은 현재 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) 인터페이스에 선언되어 있지 않습니다. 따라서 슬라이드의 도형 컬렉션에서 가져온 도형을 인터페이스 값으로 유지하고 메서드를 호출할 때만 형변환하십시오.

다음 예제는 프레임 경계와 시각적 경계를 가져와 비교합니다.

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

동일한 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 을 사용해 인접 도형을 왼쪽, 오른쪽, 위쪽 또는 아래쪽 가장자리에 정렬하거나, 생성된 레이아웃에 충분한 공간을 예약하거나, 허용된 영역 밖의 내용을 감지할 수 있습니다. 시각적 경계는 특히 SmartArt, 텍스트 상자, 화살표, 그림, 회전된 도형 및 그룹 도형에서 저장된 프레임이 전체 렌더링 결과를 나타내지 않을 때 유용합니다.

레이아웃이나 검증을 위해 좌표가 필요하고 비트맵이 필요하지 않은 경우 [Shape.getVisualBounds](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getVisualBounds--) 를 사용하십시오. 도형을 렌더링해야 할 경우 [IShape.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getImage--) 를 사용하십시오. [ShapeThumbnailBounds](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shapethumbnailbounds/) 를 사용하면 `ShapeThumbnailBounds.Shape` 가 윤곽선 설정을 포함한 도형 경계에서 이미지를 크기 조정하고, `ShapeThumbnailBounds.Appearance` 는 도형의 외관에서 크기 조정하고 결과를 슬라이드 경계에 제한합니다. 반면 [Shape.getVisualBounds](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getVisualBounds--) 는 계산된 사각형만 반환하고 슬라이드에 클리핑하지 않습니다.

## **FAQ**

**도형 썸네일을 저장할 때 사용할 수 있는 이미지 형식은 무엇입니까?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imageformat/), 등. 또한 도형의 내용을 SVG 로 저장하여 [벡터 SVG 로 내보낼 수 있습니다](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) .

**썸네일을 렌더링할 때 Shape 경계와 Appearance 경계의 차이점은 무엇입니까?**

`Shape` 는 도형의 기하학을 사용하고, `Appearance` 는 [시각 효과](/slides/ko/java/shape-effect/) (그림자, 광선 등)을 고려합니다.

**도형이 숨김으로 표시된 경우 어떻게 됩니까? 썸네일에도 적용됩니까?**

숨김 도형은 모델의 일부로 남아 있으며 렌더링될 수 있습니다. 숨김 플래그는 슬라이드쇼 표시에만 영향을 미치며 도형 이미지 생성은 방해하지 않습니다.

**그룹 도형, 차트, SmartArt 및 기타 복합 객체를 지원합니까?**

예. [Shape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/) 로 표현되는 모든 객체(예: [GroupShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/java/com.aspose.slides/chart/), [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/smartart/)) 은 썸네일이나 SVG 로 저장할 수 있습니다.

**시스템에 설치된 글꼴이 텍스트 도형 썸네일 품질에 영향을 줍니까?**

예. 원하지 않는 폰트 대체와 텍스트 재배치를 피하려면 [필요한 글꼴을 제공](/slides/ko/java/custom-font/)하거나 [글꼴 대체를 구성](/slides/ko/java/font-substitution/)해야 합니다.