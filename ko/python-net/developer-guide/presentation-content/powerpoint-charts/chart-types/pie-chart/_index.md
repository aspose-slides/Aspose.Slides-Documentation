---
title: Python으로 프레젠테이션의 파이 차트 맞춤 설정
linktitle: 파이 차트
type: docs
url: /ko/python-net/pie-chart/
keywords:
- 파이 차트
- 차트 관리
- 차트 맞춤 설정
- 차트 옵션
- 차트 설정
- 플롯 옵션
- 슬라이스 색상
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python과 Aspose.Slides를 사용해 파이 차트를 만들고 맞춤 설정하는 방법을 배우고, PowerPoint와 OpenDocument로 내보내어 몇 초 만에 데이터 스토리텔링을 강화하세요."
---
## **개요**

이 문서는 Aspose.Slides에서 파이 차트를 사용하는 방법을 설명합니다. 파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션을 구성하는 방법과 표준 파이 차트에 대한 자동 슬라이스 색상을 활성화하는 방법을 보여줍니다.

예제는 슬라이드에 차트를 추가하고, 시리즈와 레이블 설정을 조정하고, 기본 차트 데이터를 사용자 정의 범주와 값으로 교체하고, 업데이트된 프레젠테이션을 저장하는 등 실용적인 차트 사용자 정의 단계에 중점을 둡니다.

## **파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션**
Aspose.Slides for Python via .NET이 이제 파이 오브 파이 또는 바 오브 파이 차트에 대한 보조 플롯 옵션을 지원합니다. 이 섹션에서는 Aspose.Slides를 사용하여 이러한 옵션을 지정하는 방법을 예제로 보여줍니다. 속성을 지정하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스 객체를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트의 보조 플롯 옵션을 지정합니다.
1. 프레젠테이션을 디스크에 씁니다.

아래 예제에서는 파이 오브 파이 차트의 다양한 속성을 설정했습니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation 클래스의 인스턴스를 생성합니다
with slides.Presentation() as presentation:
    # 슬라이드에 차트 추가
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # 다양한 속성 설정
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # 프레젠테이션을 디스크에 저장
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```




## **자동 파이 차트 슬라이스 색상 설정**
Aspose.Slides for Python via .NET은 자동 파이 차트 슬라이스 색상을 설정하기 위한 간단한 API를 제공합니다. 샘플 코드는 앞서 언급한 속성을 적용합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 기본 데이터로 차트를 추가합니다.
1. 차트 제목을 설정합니다.
1. 첫 번째 시리즈를 값 표시로 설정합니다.
1. 차트 데이터 시트의 인덱스를 설정합니다.
1. 차트 데이터 워크시트를 가져옵니다.
1. 기본 생성된 시리즈와 범주를 삭제합니다.
1. 새로운 범주를 추가합니다.
1. 새로운 시리즈를 추가합니다.

수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation() as presentation:
	# 첫 번째 슬라이드에 접근합니다
	slide = presentation.slides[0]

	# 기본 데이터로 차트를 추가합니다
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# 차트 제목 설정
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# 첫 번째 시리즈를 값 표시로 설정합니다
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# 차트 데이터 시트의 인덱스를 설정합니다
	defaultWorksheetIndex = 0

	# 차트 데이터 워크시트를 가져옵니다
	fact = chart.chart_data.chart_data_workbook

	# 기본 생성된 시리즈와 범주를 삭제합니다
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# 새 범주 추가
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# 새 시리즈 추가
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# 이제 시리즈 데이터 채우기
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**'Pie of Pie'와 'Bar of Pie' 변형이 지원되나요?**

네, 라이브러리는 'Pie of Pie'와 'Bar of Pie' 유형을 포함한 파이 차트에 대한 보조 플롯을 [지원](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/charttype/)합니다.

**차트만 이미지(예: PNG)로 내보낼 수 있나요?**

네, 전체 프레젠테이션 없이 차트 자체를 이미지(예: PNG)로 [내보낼 수](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/get_image/) 있습니다.