---
title: .NET에서 프레젠테이션에 사각형 추가
linktitle: 사각형
type: docs
weight: 80
url: /ko/net/rectangle/
keywords:
- 사각형 추가
- 사각형 만들기
- 사각형 모양
- 단순 사각형
- 서식 있는 사각형
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 사각형을 추가함으로써 PowerPoint 프레젠테이션을 향상시키고, 프로그래밍으로 도형을 손쉽게 디자인하고 수정하세요."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 사각형 모양을 추가하는 방법을 보여줍니다. 간단한 사각형 만들기, 서식이 지정된 사각형 만들기 및 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 과정을 다룹니다.

또한 실선 채우기 색, 선 색 및 선 두께와 같은 기본 사각형 서식을 적용하는 방법을 확인할 수 있습니다. 추가로, 문서의 FAQ에서는 둥근 모서리, 그림 채우기, 시각 효과, 하이퍼링크, 도형 잠금, 내보내기 옵션 및 효과적인 속성 등 관련 사각형 작업을 안내합니다.

## **간단한 사각형 만들기**
이전 주제와 마찬가지로, 이번에도 도형 추가에 대해 다루며 이번에 논의할 도형은 사각형입니다. 이 주제에서는 개발자가 Aspose.Slides for .NET을 사용하여 슬라이드에 간단하거나 서식이 지정된 사각형을 추가하는 방법을 설명했습니다. 프레젠테이션의 선택된 슬라이드에 간단한 사각형을 추가하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 슬라이드의 인덱스를 사용하여 해당 슬라이드의 참조를 가져옵니다.
3. IShapes 객체가 제공하는 AddAutoShape 메서드를 사용하여 Rectangle 유형의 IAutoShape을 추가합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 간단한 사각형을 추가했습니다.

```c#
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation())
{

    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.Slides[0];

    // 사각형 타입의 자동 도형을 추가합니다
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX 파일을 디스크에 저장합니다
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```

## **서식이 지정된 사각형 만들기**
슬라이드에 서식이 지정된 사각형을 추가하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 슬라이드의 인덱스를 사용하여 해당 슬라이드의 참조를 가져옵니다.
3. IShapes 객체가 제공하는 AddAutoShape 메서드를 사용하여 Rectangle 유형의 IAutoShape을 추가합니다.
4. 사각형의 채우기 유형을 Solid(단색)로 설정합니다.
5. IShape 객체와 연결된 FillFormat 객체가 제공하는 SolidFillColor.Color 속성을 사용하여 사각형의 색상을 설정합니다.
6. 사각형 선의 색상을 설정합니다.
7. 사각형 선의 두께를 설정합니다.
8. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계는 아래 예제에 구현되어 있습니다.

```c#
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation())
{

    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.Slides[0];

    // 사각형 타입의 자동 도형을 추가합니다
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 사각형 도형에 일부 서식을 적용합니다
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // 사각형 선에 일부 서식을 적용합니다
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //PPTX 파일을 디스크에 저장합니다
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**둥근 모서리를 가진 사각형을 어떻게 추가합니까?**

둥근 모서리 [shape type](https://reference.aspose.com/slides/ko/net/aspose.slides/shapetype/)을 사용하고 모양 속성에서 코너 반경을 조정합니다; 기하학적 조정을 통해 코너별로 둥근 처리를 적용할 수도 있습니다.

**이미지(텍스처)로 사각형을 채우려면 어떻게 합니까?**

그림 [fill type](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)을 선택하고 이미지 소스를 제공한 뒤, [stretching/tiling modes](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillmode/)를 구성합니다.

**사각형에 그림자와 글로우를 적용할 수 있나요?**

예. 조정 가능한 매개변수를 가진 [외부/내부 그림자, 글로우 및 부드러운 가장자리](/slides/ko/net/shape-effect/)를 사용할 수 있습니다.

**사각형을 하이퍼링크가 포함된 버튼으로 만들 수 있나요?**

예. 도형 클릭에 [하이퍼링크 할당](/slides/ko/net/manage-hyperlinks/)을 하면 슬라이드, 파일, 웹 주소 또는 이메일로 이동할 수 있습니다.

**사각형이 이동하거나 변경되는 것을 어떻게 보호할 수 있나요?**

[shape locks 사용](/slides/ko/net/applying-protection-to-presentation/): 이동, 크기 조정, 선택 또는 텍스트 편집을 금지하여 레이아웃을 보호할 수 있습니다.

**사각형을 래스터 이미지나 SVG로 변환할 수 있나요?**

예. 지정된 크기/스케일로 이미지를 만들려면 [shape를 렌더링](http://reference.aspose.com/slides/ko/net/aspose.slides/shape/getimage/)할 수 있고, 벡터 용도로 [SVG로 내보내기](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/writeassvg/)도 가능합니다.

**테마와 상속을 고려한 사각형의 실제(효과적인) 속성을 빠르게 확인하려면 어떻게 해야 하나요?**

[shape의 효과적인 속성 사용](/slides/ko/net/shape-effective-properties/): API는 테마 스타일, 레이아웃 및 로컬 설정을 반영한 계산된 값을 반환하여 서식 분석을 간소화합니다.