---
title: Python을 사용한 프레젠테이션에서 3D 차트 사용자 지정
linktitle: 3D 차트
type: docs
url: /ko/python-net/3d-chart/
keywords:
- 3D 차트
- 회전
- 깊이
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET에서 3-D 차트를 생성하고 사용자 지정하는 방법을 배우세요. PPT, PPTX 및 ODP 파일을 지원하여 오늘 바로 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서에서는 `rotation_3d` 설정인 `rotation_x`, `rotation_y`, `depth_percents`, `right_angle_axes`을 구성하여 Aspose.Slides에서 3D 차트를 사용자 지정하는 방법을 설명합니다. 프레젠테이션을 만들고, 기본 데이터와 함께 3D 차트를 추가하고, 필요한 3D 보기 설정을 적용한 뒤, 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 안내합니다.

## **3D 차트의 RotationX, RotationY 및 DepthPercents 속성 설정**
Aspose.Slides for Python via .NET는 이러한 속성을 설정하기 위한 간단한 API를 제공합니다. 다음 문서는 X, Y 회전 및 **DepthPercents**와 같은 다양한 속성을 설정하는 방법을 안내합니다. 샘플 코드는 앞서 언급한 속성을 적용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에 접근합니다.
3. 기본 데이터가 포함된 차트를 추가합니다.
4. Rotation3D 속성을 설정합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation 클래스의 인스턴스를 생성합니다
with slides.Presentation() as presentation:
            
    # 첫 번째 슬라이드에 접근합니다
    slide = presentation.slides[0]

    # 기본 데이터와 함께 차트를 추가합니다
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # 차트 데이터 시트의 인덱스를 설정합니다
    defaultWorksheetIndex = 0

    # 차트 데이터 워크시트를 가져옵니다
    fact = chart.chart_data.chart_data_workbook

    # 시리즈를 추가합니다
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # 범주를 추가합니다
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Rotation3D 속성을 설정합니다
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # 두 번째 차트 시리즈를 가져옵니다
    series = chart.chart_data.series[1]

    # 이제 시리즈 데이터를 채웁니다
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Overlap 값을 설정합니다
    series.parent_series_group.overlap = 100         

    # 프레젠테이션을 디스크에 저장합니다
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides에서 3D 모드를 지원하는 차트 유형은 무엇입니까?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D, 100% Stacked Column 3D 등 컬럼 차트의 3D 변형과 [ChartType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/charttype/) 열거형을 통해 노출되는 관련 3D 유형을 지원합니다. 정확하고 최신 목록은 설치된 버전의 API 참조에 있는 [ChartType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/charttype/) 멤버를 확인하십시오.

**보고서나 웹을 위해 3D 차트의 래스터 이미지를 얻을 수 있습니까?**

예. 차트를 [chart API](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/get_image/)를 사용해 이미지로 내보내거나 전체 슬라이드를 [render the entire slide](/slides/ko/python-net/convert-powerpoint-to-png/)하여 PNG 또는 JPEG와 같은 형식으로 변환할 수 있습니다. 이는 픽셀 단위로 정확한 미리보기가 필요하거나 PowerPoint 없이 차트를 문서, 대시보드, 웹 페이지 등에 삽입하려는 경우에 유용합니다.

**대용량 3D 차트를 구축하고 렌더링하는 성능은 어떻습니까?**

성능은 데이터 양과 시각적 복잡성에 따라 달라집니다. 최상의 결과를 얻으려면 3D 효과를 최소화하고, 차트 면과 플롯 영역에 무거운 텍스처를 사용하지 않으며, 가능하면 시리즈당 데이터 포인트 수를 제한하고, 대상 디스플레이 또는 인쇄 요구에 맞게 적절한 해상도와 크기로 출력하도록 렌더링하십시오.