---
title: .NET에서 프레젠테이션 차트 내보내기
linktitle: 차트 내보내기
type: docs
weight: 90
url: /ko/net/export-chart/
keywords:
- 차트
- 차트를 이미지로
- 이미지 형태의 차트
- 차트 이미지 추출
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PPT 및 PPTX 형식을 지원하는 프레젠테이션 차트를 내보내는 방법을 배우고, 모든 워크플로우에 보고서를 효율적으로 통합하십시오."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션에서 차트를 이미지로 내보낼 수 있습니다. 이 문서는 차트에서 이미지를 얻고 저장하는 방법을 보여 주며, PowerPoint 프레젠테이션 외부에서 차트 시각 자료를 재사용해야 할 때 유용합니다.

기본 이미지 내보내기 워크플로우 외에도, 이 문서는 차트 내용을 SVG로 저장, 렌더링 옵션을 통한 출력 크기 제어, 레이블 및 범례 모양을 유지하기 위한 글꼴 로드, 렌더링 중 테마, 스타일, 채우기 및 효과와 같은 원본 프레젠테이션 서식 유지와 같은 일반적인 내보내기 관련 질문에도 답합니다.

## **차트 이미지 가져오기**
Aspose.Slides for .NET은 특정 차트의 이미지를 추출하는 기능을 제공합니다. 아래 샘플 예제가 제공됩니다.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**차트를 래스터 이미지가 아닌 벡터(SVG)로 내보낼 수 있나요?**

예. 차트는 도형이며, 해당 내용은 [shape-to-SVG saving method](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/writeassvg/)를 사용하여 SVG로 저장할 수 있습니다.

**내보낸 차트의 정확한 픽셀 크기를 어떻게 설정합니까?**

크기 또는 배율을 지정할 수 있는 이미지‑렌더링 오버로드를 사용하십시오—라이브러리는 지정된 차원/배율로 객체를 렌더링하는 것을 지원합니다.

**내보낸 후 레이블과 범례의 글꼴이 잘못 표시되면 어떻게 해야 하나요?**

[필요한 글꼴을 로드](/slides/ko/net/custom-font/)하고 [FontsLoader](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/)를 통해 차트 렌더링이 메트릭과 텍스트 모양을 보존하도록 하십시오.

**내보내기가 PowerPoint 테마, 스타일 및 효과를 유지합니까?**

예. Aspose.Slides의 렌더러는 프레젠테이션의 서식(테마, 스타일, 채우기, 효과)을 따르므로 차트의 모양이 보존됩니다.

**차트 이미지 외에 사용할 수 있는 렌더링/내보내기 기능은 어디서 확인할 수 있나요?**

출력 대상([PDF](/slides/ko/net/convert-powerpoint-to-pdf/), [SVG](/slides/ko/net/render-a-slide-as-an-svg-image/), [XPS](/slides/ko/net/convert-powerpoint-to-xps/), [HTML](/slides/ko/net/convert-powerpoint-to-html/), 등) 및 관련 렌더링 옵션에 대한 자세한 내용은 [API](https://reference.aspose.com/slides/ko/net/aspose.slides.export/)/[documentation](/slides/ko/net/convert-powerpoint/)의 내보내기 섹션을 확인하십시오.