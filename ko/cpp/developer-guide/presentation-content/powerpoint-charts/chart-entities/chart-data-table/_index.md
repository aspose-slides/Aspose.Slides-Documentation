---
title: 프레젠테이션에서 C++를 사용한 차트 데이터 테이블 사용자 지정
linktitle: 데이터 테이블
type: docs
url: /ko/cpp/chart-data-table/
keywords:
- 차트 데이터
- 데이터 테이블
- 글꼴 속성
- 파워포인트
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PPT 및 PPTX 차트 데이터 테이블을 사용자 지정하여 효율성과 매력을 높입니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 데이터 테이블을 사용하는 방법을 설명합니다. 차트에 대한 데이터 테이블을 표시하고 굵게 스타일 및 글꼴 높이와 같은 글꼴 속성을 설정하여 텍스트 서식을 사용자 지정하는 방법을 보여줍니다. 예제에서는 프레젠테이션을 로드하고, 차트를 추가하고, 차트 데이터 테이블을 활성화하며, 글꼴 설정을 적용하고, 업데이트된 프레젠테이션을 저장하는 과정을 시연합니다.

## **차트 데이터 테이블에 대한 글꼴 속성 설정**
Aspose.Slides for C++는 차트 데이터 테이블의 글꼴 속성을 변경할 수 있습니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스 객체를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트 테이블을 설정합니다.
1. 글꼴 높이를 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

아래에 샘플 예제가 제공됩니다. 

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **자주 묻는 질문**

**차트 데이터 테이블의 값 옆에 작은 범례 키를 표시할 수 있나요?**

예. 데이터 테이블은 [legend keys](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/datatable/set_showlegendkey/)를 지원하며, 이를 켜거나 끌 수 있습니다.

**프레젠테이션을 PDF, HTML 또는 이미지로 내보낼 때 데이터 테이블이 유지됩니까?**

예. Aspose.Slides는 차트를 슬라이드의 일부로 렌더링하므로, 내보낸 [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/ko/cpp/convert-powerpoint-to-html/)/[image](/slides/ko/cpp/convert-powerpoint-to-png/)에 차트와 데이터 테이블이 포함됩니다.

**템플릿 파일에서 가져온 차트에 대해 데이터 테이블을 지원합니까?**

예. 기존 프레젠테이션이나 템플릿에서 로드된 모든 차트에 대해 차트 속성을 사용하여 데이터 테이블이 [표시되는지](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/chart/set_hasdatatable/) 확인하고 변경할 수 있습니다.

**파일 내 어떤 차트에 데이터 테이블이 활성화되어 있는지 빠르게 찾는 방법은?**

각 차트의 데이터 테이블이 [표시되는지](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/chart/get_hasdatatable/) 나타내는 속성을 확인하고 슬라이드를 순회하여 해당 차트를 식별하면 됩니다.