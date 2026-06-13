---
title: .NET에서 프레젠테이션 도형 썸네일 생성
linktitle: 도형 썸네일
type: docs
weight: 70
url: /ko/net/create-shape-thumbnails/
keywords:
- 도형 썸네일
- 도형 이미지
- 도형 렌더링
- 도형 렌더링
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 슬라이드에서 고품질 도형 썸네일을 생성하고, 프레젠테이션 썸네일을 쉽게 만들고 내보낼 수 있습니다."
---
## **소개**

Aspose.Slides for .NET은 각 페이지가 슬라이드인 프레젠테이션 파일을 만드는 데 사용됩니다. 이러한 슬라이드는 Microsoft PowerPoint를 사용해 프레젠테이션 파일을 열어 볼 수 있습니다. 하지만 때때로 개발자는 이미지 뷰어에서 도형의 이미지를 별도로 확인해야 할 수 있습니다. 이러한 경우 Aspose.Slides for .NET은 슬라이드 도형의 썸네일 이미지를 생성하도록 도와줍니다. 이 기능을 사용하는 방법은 이 문서에 설명되어 있습니다.

이 문서에서는 다양한 방법으로 슬라이드 썸네일을 생성하는 방법을 설명합니다:

- 슬라이드 내부에서 도형 썸네일 생성.
- 사용자 정의 차원으로 슬라이드 도형의 썸네일 생성.
- 도형 외관 경계 내에서 도형 썸네일 생성.

## **슬라이드에서 도형 썸네일 생성**
Aspose.Slides for .NET을 사용하여 임의의 슬라이드에서 도형 썸네일을 생성하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스를 사용하여 임의의 슬라이드에 대한 참조를 가져옵니다.
3. 기본 스케일로 참조된 슬라이드의 도형 썸네일 이미지를 가져옵니다.
4. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

아래 예제는 도형 썸네일을 생성합니다.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **사용자 정의 스케일링 팩터 썸네일 생성**
Aspose.Slides for .NET을 사용하여 임의의 슬라이드 도형의 썸네일을 생성하려면:

1. `Presentation` 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스를 사용하여 임의의 슬라이드에 대한 참조를 가져옵니다.
3. 도형 경계가 포함된 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
4. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

아래 예제는 사용자 정의 스케일링 팩터를 사용하여 썸네일을 생성합니다.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // X와 Y 축에 대한 스케일링.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **경계 기반 도형 외관 썸네일 생성**
이 방법은 개발자가 도형 외관의 경계 내에서 썸네일을 생성하도록 허용합니다. 모든 도형 효과를 고려합니다. 생성된 도형 썸네일은 슬라이드 경계에 제한됩니다. 외관 경계 내에서 임의의 슬라이드 도형 썸네일을 생성하려면 아래 샘플 코드를 사용합니다:

1. `Presentation` 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스를 사용하여 임의의 슬라이드에 대한 참조를 가져옵니다.
3. 외관으로서 도형 경계를 사용하여 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
4. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

아래 예제는 사용자 정의 스케일링 팩터를 사용하여 썸네일을 생성합니다.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // X와 Y 축에 대한 스케일링.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**도형 썸네일을 저장할 때 사용할 수 있는 이미지 형식은 무엇입니까?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/net/aspose.slides/imageformat/), 등. 도형은 또한 도형 내용을 SVG로 저장하여 [벡터 SVG로 내보낼 수 있습니다](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/writeassvg/) .

**썸네일을 렌더링할 때 Shape 경계와 Appearance 경계의 차이점은 무엇입니까?**

`Shape`는 도형의 기하학을 사용하고, `Appearance`는 [시각 효과](/slides/ko/net/shape-effect/) (그림자, 흐림 등)을 고려합니다.

**도형이 숨김으로 표시되면 어떻게 됩니까? 썸네일에 여전히 렌더링됩니까?**

숨김 도형은 모델의 일부로 남아 있으며 렌더링될 수 있습니다; 숨김 플래그는 슬라이드 쇼 표시에는 영향을 주지만 도형 이미지를 생성하는 것을 방지하지는 않습니다.

**그룹 도형, 차트, SmartArt 및 기타 복합 객체가 지원됩니까?**

예. [Shape](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/)으로 표현되는 모든 객체(예: [GroupShape](https://reference.aspose.com/slides/ko/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chart/), [SmartArt](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/smartart/))는 썸네일이나 SVG로 저장할 수 있습니다.

**시스템에 설치된 글꼴이 텍스트 도형 썸네일 품질에 영향을 줍니까?**

예. 원하지 않는 대체 및 텍스트 재배치를 방지하려면 [필요한 글꼴을 제공해야 합니다](/slides/ko/net/custom-font/) (또는 [글꼴 대체를 구성해야 합니다](/slides/ko/net/font-substitution/)).