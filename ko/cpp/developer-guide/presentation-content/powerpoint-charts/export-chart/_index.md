---
title: 프리젠테이션 차트를 C++로 내보내기
linktitle: 차트 내보내기
type: docs
weight: 90
url: /ko/cpp/export-chart/
keywords:
- 차트
- 차트를 이미지로
- 차트 이미지
- 차트 이미지 추출
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 프레젠테이션 차트를 내보내는 방법을 배우고, PPT 및 PPTX 형식을 지원하며, 보고서를 모든 워크플로에 원활하게 통합할 수 있습니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션에서 차트를 이미지로 내보낼 수 있습니다. 이 문서에서는 차트에서 이미지를 가져와 저장하는 방법을 보여주며, PowerPoint 프레젠테이션 외부에서 차트 시각 자료를 재사용해야 할 때 유용합니다.

## **차트 이미지 가져오기**
Aspose.Slides for C++는 특정 차트의 이미지를 추출하는 기능을 제공합니다. 아래 샘플 예제가 제공됩니다.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**차트를 래스터 이미지가 아니라 벡터(SVG) 형식으로 내보낼 수 있나요?**

예. 차트는 도형이며, 그 내용은 [shape-to-SVG 저장 방법](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/writeassvg/)을 사용하여 SVG로 저장할 수 있습니다.

**내보낸 차트의 정확한 픽셀 크기를 어떻게 설정할 수 있나요?**

크기 또는 배율을 지정할 수 있는 image-rendering 오버로드를 사용하십시오—이 라이브러리는 지정된 차원/배율로 객체를 렌더링하는 것을 지원합니다.

**내보낸 후 레이블 및 범례의 글꼴이 잘못 표시되면 어떻게 해야 하나요?**

[필요한 글꼴 로드](/slides/ko/cpp/custom-font/)를 통해 [FontsLoader](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/)를 사용하면 차트 렌더링이 메트릭과 텍스트 모양을 유지합니다.

**내보내기가 PowerPoint 테마, 스타일 및 효과를 유지합니까?**

예. Aspose.Slides 렌더러는 프레젠테이션의 서식(테마, 스타일, 채우기, 효과)을 따르므로 차트 모양이 유지됩니다.

**차트 이미지 외에 사용 가능한 렌더링/내보내기 기능은 어디에서 확인할 수 있나요?**

출력 대상([PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/ko/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/ko/cpp/convert-powerpoint-to-xps/), [HTML](/slides/ko/cpp/convert-powerpoint-to-html/) 등)과 관련 렌더링 옵션에 대한 자세한 내용은 [API](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/)/[문서](/slides/ko/cpp/convert-powerpoint/)의 내보내기 섹션을 확인하십시오.