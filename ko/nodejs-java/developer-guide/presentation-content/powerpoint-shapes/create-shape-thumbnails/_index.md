---
title: JavaScript로 프레젠테이션 형태 썸네일 생성
linktitle: 형태 썸네일
type: docs
weight: 70
url: /ko/nodejs-java/create-shape-thumbnails/
keywords:
- 형태 썸네일
- 형태 이미지
- 형태 렌더링
- 형태 렌더링
- 시각적 경계
- 형태 경계
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 PowerPoint 슬라이드에서 고품질 형태 썸네일을 생성하고, 프레젠테이션 썸네일을 쉽게 만들고 내보낼 수 있습니다."
---
## **소개**

Aspose.Slides는 각 페이지가 슬라이드인 프레젠테이션 파일을 만드는 데 사용됩니다. 이러한 슬라이드는 Microsoft PowerPoint로 프레젠테이션 파일을 열어 볼 수 있습니다. 하지만 때때로 개발자는 형태의 이미지를 이미지 뷰어에서 별도로 보고 싶을 수 있습니다. 이러한 경우 Aspose.Slides는 슬라이드 형태의 썸네일 이미지를 생성하도록 도와줍니다. 이 기능의 사용 방법은 이 문서에 설명되어 있습니다.

이 문서에서는 다양한 방법으로 슬라이드 썸네일을 생성하는 방법을 설명합니다:

- 슬라이드 내부에서 형태 썸네일 생성.
- 사용자 정의 차원으로 슬라이드 형태에 대한 형태 썸네일 생성.
- 형태 외관의 경계 내에서 형태 썸네일 생성.

## **슬라이드에서 형태 썸네일 생성**

Java를 통해 Aspose.Slides for Node.js를 사용하여任意의 슬라이드에서 형태 썸네일을 생성하려면 다음과 같이 하세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. 기본 축척으로 참조된 슬라이드의 [Get the shape thumbnail image](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getImage--)를 가져옵니다.
4. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 슬라이드에서 형태 썸네일을 생성하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
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

## **사용자 정의 스케일링 팩터로 형태 썸네일 생성**

Java를 통해 Aspose.Slides for Node.js를 사용하여 슬라이드의 형태 썸네일을 생성하려면 다음과 같이 하세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. 사용자 정의 차원으로 참조된 슬라이드의 [Get the shape thumbnail image](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getImage-int-float-float-)를 가져옵니다.
4. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 정의된 스케일링 팩터에 따라 형태 썸네일을 생성하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 전체 배율 이미지 생성
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
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

## **경계 내 형태 썸네일 생성**

이 방법은 개발자가 형태 외관의 경계 내에서 썸네일을 생성하도록 허용합니다. 모든 형태 효과를 고려합니다. 생성된 형태 썸네일은 슬라이드 경계에 의해 제한됩니다. 외관 경계 내에서 슬라이드 형태의 썸네일을 생성하려면 다음과 같이 하세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. 외관으로서 형태 경계를 사용하여 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
4. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 위 단계에 기반합니다:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 전체 배율 이미지 생성
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
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

## **형태의 실제 시각적 경계 가져오기**

[Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/)의 프레임 속성—`getX()`, `getY()`, `getWidth()`, `getHeight()` 메서드—는 프레젠테이션 모델에 저장된 사각형을 설명합니다. 실제로 렌더링되는 내용은 해당 프레임을 넘어설 수 있거나 다른 축에 정렬된 사각형을 차지할 수 있습니다. 회전, 외곽선, 화살촉, 텍스트 레이아웃 및 오버플로, 생성된 SmartArt 기하학 및 기타 렌더링 효과가 모두 차지 영역을 변경할 수 있습니다.

이미지를 만들지 않고 차지 영역을 계산하려면 [Shape.getVisualBounds](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getVisualBounds--)를 사용하십시오. 이 메서드는 슬라이드 좌표계의 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 객체를 반환합니다. 반환된 사각형은 슬라이드에 클리핑되지 않으므로 내용이 슬라이드 원점을 넘어설 경우 좌표가 음수가 될 수 있습니다.

다음 예제는 프레임과 시각적 경계를 가져와 비교합니다:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

동일한 사각형을 사용하여 인접 형태를 왼쪽, 오른쪽, 위쪽 또는 아래쪽 가장자리에 맞출 수 있고, 생성된 레이아웃에서 충분한 공간을 예약하거나 허용된 영역 밖의 내용을 감지할 수 있습니다. 시각적 경계는 저장된 프레임이 전체 렌더링 결과를 나타내지 않을 수 있는 SmartArt, 텍스트 상자, 화살표, 그림, 회전된 형태 및 그룹 형태에 특히 유용합니다.

레이아웃이나 검증을 위해 좌표가 필요하고 비트맵이 필요하지 않을 때는 [Shape.getVisualBounds](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getVisualBounds--)를 사용하십시오. 형태를 렌더링해야 할 경우에는 [Shape.getImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getImage--)를 사용하십시오. [ShapeThumbnailBounds](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapethumbnailbounds/)를 사용하면 `ShapeThumbnailBounds.Shape`는 외곽선 설정을 포함하여 형태 경계에서 이미지를 크기 조정하고, `ShapeThumbnailBounds.Appearance`는 형태의 외관에서 크기 조정하며 결과를 슬라이드 경계에 제한합니다. 반면에 [Shape.getVisualBounds](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getVisualBounds--)는 계산된 사각형만 반환하고 슬라이드에 클리핑하지 않습니다.

## **FAQ**

**형태 썸네일을 저장할 때 사용할 수 있는 이미지 형식에는 무엇이 있나요?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/imageformat/), 등. 또한 형태의 내용을 SVG로 저장하여 [벡터 SVG로 내보낼 수](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/writeassvg/) 있습니다.

**썸네일을 렌더링할 때 Shape 경계와 Appearance 경계의 차이는 무엇인가요?**

`Shape`는 형태의 기하학을 사용하고, `Appearance`는 [시각 효과](/slides/ko/nodejs-java/shape-effect/) (그림자, 광채 등)를 고려합니다.

**형태가 숨김으로 표시된 경우 어떻게 되나요? 여전히 썸네일로 렌더링되나요?**

숨김 형태는 모델의 일부로 남아 있으며 렌더링될 수 있습니다. 숨김 플래그는 슬라이드쇼 표시에만 영향을 미치며 형태 이미지 생성을 방해하지 않습니다.

**그룹 형태, 차트, SmartArt 및 기타 복잡한 객체가 지원되나요?**

예. [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/)로 표시되는 모든 객체(예: [GroupShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/), [SmartArt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartart/))는 썸네일이나 SVG로 저장할 수 있습니다.

**시스템에 설치된 폰트가 텍스트 형태 썸네일 품질에 영향을 미치나요?**

예. 원하지 않는 폰트 대체 및 텍스트 재배치를 방지하려면 [필요한 폰트를 제공](/slides/ko/nodejs-java/custom-font/)하거나 [폰트 대체를 구성](/slides/ko/nodejs-java/font-substitution/)해야 합니다.