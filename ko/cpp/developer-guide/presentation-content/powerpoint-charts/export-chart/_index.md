---
title: C++에서 프레젠테이션 차트 내보내기
linktitle: 차트 내보내기
type: docs
weight: 90
url: /ko/cpp/export-chart/
keywords:
- 차트
- 차트 이미지 변환
- 이미지 형태 차트
- 차트 이미지 추출
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 프레젠테이션 차트를 내보내는 방법을 배우고, PPT 및 PPTX 형식을 지원하며, 모든 워크플로에 보고서를 효율적으로 통합할 수 있습니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션의 차트를 이미지로 내보낼 수 있습니다. 이 문서에서는 차트에서 이미지를 가져와 저장하는 방법을 보여주며, PowerPoint 프레젠테이션 외부에서 차트 시각 자료를 재사용해야 할 때 유용합니다.

## **차트 이미지 가져오기**
Aspose.Slides for C++는 특정 차트의 이미지를 추출하는 기능을 제공합니다. 아래 예제가 제공됩니다.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **자주 묻는 질문**

**차트를 래스터 이미지가 아니라 벡터(SVG) 형식으로 내보낼 수 있나요?**

예. 차트는 도형이며, 해당 내용을 SVG로 저장하려면 [shape-to-SVG 저장 메서드](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/writeassvg/)를 사용할 수 있습니다.

**내보낸 차트의 정확한 픽셀 크기를 어떻게 설정할 수 있나요?**

크기 또는 배율을 지정할 수 있는 이미지 렌더링 오버로드를 사용하십시오—라이브러리는 지정된 치수/배율로 객체를 렌더링하는 것을 지원합니다.

**내보낸 후 라벨 및 범례의 글꼴이 올바르게 표시되지 않으면 어떻게 해야 하나요?**

[필요한 글꼴을 로드](/slides/ko/cpp/custom-font/)하고 [FontsLoader](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/)를 사용하면 차트 렌더링 시 메트릭과 텍스트 모양이 보존됩니다.

**내보내기가 PowerPoint 테마, 스타일 및 효과를 유지하나요?**

예. Aspose.Slides의 렌더러는 프레젠테이션의 형식(테마, 스타일, 채우기, 효과)을 따르므로 차트의 모양이 유지됩니다.

**차트 이미지를 넘어선 사용 가능한 렌더링/내보내기 기능은 어디서 확인할 수 있나요?**

출력 대상([PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/ko/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/ko/cpp/convert-powerpoint-to-xps/), [HTML](/slides/ko/cpp/convert-powerpoint-to-html/) 등) 및 관련 렌더링 옵션에 대해서는 [API](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/)/[문서](/slides/ko/cpp/convert-powerpoint/)의 내보내기 섹션을 참조하십시오.