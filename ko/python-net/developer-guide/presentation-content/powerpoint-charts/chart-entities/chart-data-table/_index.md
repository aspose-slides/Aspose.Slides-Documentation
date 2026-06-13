---
title: Python에서 차트 데이터 테이블 맞춤 설정
linktitle: 데이터 테이블
type: docs
url: /ko/python-net/chart-data-table/
keywords:
- 차트 데이터
- 데이터 테이블
- 글꼴 속성
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PPT, PPTX 및 ODP용 차트 데이터 테이블을 Python에서 맞춤 설정하여 프레젠테이션의 효율성과 매력을 높입니다."
---
## **Overview**

이 문서는 Aspose.Slides에서 차트 데이터 테이블을 사용하는 방법을 설명합니다. 차트에 대한 데이터 테이블을 표시하고 굵게 스타일 및 글꼴 높이와 같은 폰트 속성을 설정하여 텍스트 서식을 사용자 지정하는 방법을 보여줍니다. 예제에서는 프레젠테이션을 로드하고, 차트를 추가하고, 차트 데이터 테이블을 활성화하고, 폰트 설정을 적용한 다음, 업데이트된 프레젠테이션을 저장하는 과정을 시연합니다.

또한 차트 데이터 테이블에 범례 키를 표시하는 방법, 내보낼 때 데이터 테이블을 보존하는 방법, 기존 프레젠테이션이나 템플릿에서 로드된 차트를 작업하는 방법, 데이터 테이블이 활성화된 차트를 식별하는 방법 등에 대한 일반적인 질문에 대한 간략한 답변을 포함합니다.

## **차트 데이터 테이블에 대한 폰트 속성 설정**
Aspose.Slides for Python via .NET는 시리즈 색상에서 범주의 색상을 변경하는 기능을 제공합니다.

1. Presentation 클래스 객체를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트 테이블을 설정합니다.
1. 글꼴 높이를 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

아래 샘플 예제가 제공됩니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**차트 데이터 테이블의 값 옆에 작은 범례 키를 표시할 수 있나요?**

예. 데이터 테이블은 [legend keys](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datatable/show_legend_key/)를 지원하며, 이를 켜거나 끌 수 있습니다.

**프레젠테이션을 PDF, HTML 또는 이미지로 내보낼 때 데이터 테이블이 보존되나요?**

예. Aspose.Slides는 차트를 슬라이드의 일부로 렌더링하므로, 내보낸 [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/ko/python-net/convert-powerpoint-to-html/)/[image](/slides/ko/python-net/convert-powerpoint-to-png/)에 차트와 데이터 테이블이 포함됩니다.

**템플릿 파일에서 가져온 차트에 대해 데이터 테이블이 지원되나요?**

예. 기존 프레젠테이션이나 템플릿에서 로드된 차트의 경우, 차트 속성을 사용하여 데이터 테이블이 [is shown](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/has_data_table/)인지 확인하고 변경할 수 있습니다.

**파일 내에서 데이터 테이블이 활성화된 차트를 빠르게 찾으려면 어떻게 해야 하나요?**

각 차트의 데이터 테이블이 [is shown](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/has_data_table/)인지 나타내는 속성을 검사하고 슬라이드를 순회하여 해당 차트를 식별합니다.