---
title: 프레젠테이션에서 Python을 사용한 차트 데이터 마커 관리
linktitle: 데이터 마커
type: docs
url: /ko/python-net/chart-data-marker/
keywords:
- 차트
- 데이터 포인트
- 마커
- 마커 옵션
- 마커 크기
- 채우기 유형
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides에서 차트 데이터 마커를 사용자 정의하는 방법을 배우고, 명확한 코드 예제로 PPT, PPTX 및 ODP 형식 전반에 걸쳐 프레젠테이션 효과를 향상시킵니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 데이터 마커를 사용하는 방법을 설명합니다. 차트를 생성하고, 시리즈와 해당 데이터 포인트에 접근하며, 데이터 포인트 수준에서 마커에 그림 채우기를 적용하고, 마커 크기를 조정하고, 업데이트된 프레젠테이션을 저장하는 과정을 보여줍니다. 또한 표준 마커 모양은 `MarkerStyleType` 열거형을 통해 사용할 수 있으며, 차트를 래스터 형식이나 SVG로 내보낼 때 마커 모양이 유지된다는 점을 언급합니다.

## **차트 마커 옵션 설정**
마커는 특정 시리즈의 차트 데이터 포인트에 설정할 수 있습니다. 차트 마커 옵션을 설정하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 그림을 설정합니다.
- 첫 번째 차트 시리즈를 가져옵니다.
- 새 데이터 포인트를 추가합니다.
- 프레젠테이션을 디스크에 저장합니다.

아래 예시에서는 데이터 포인트 수준에서 차트 마커 옵션을 설정했습니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation 클래스의 인스턴스를 생성합니다
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # 기본 차트를 생성합니다
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # 기본 차트 데이터 워크시트 인덱스를 가져옵니다
    defaultWorksheetIndex = 0

    # 차트 데이터 워크시트를 가져옵니다
    fact = chart.chart_data.chart_data_workbook

    # 데모 시리즈를 삭제합니다
    chart.chart_data.series.clear()

    # 새 시리즈를 추가합니다
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # 그림을 설정합니다
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # 그림을 설정합니다
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # 첫 번째 차트 시리즈를 가져옵니다
    series = chart.chart_data.series[0]

    # 새 데이터 포인트 (1:3)를 추가합니다
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # 차트 시리즈 마커를 변경합니다
    series.marker.size = 15

    # 프레젠테이션을 디스크에 저장합니다
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**기본 제공되는 마커 형태는 무엇인가요?**

표준 형태(원, 사각형, 다이아몬드, 삼각형 등)가 제공되며, 목록은 [MarkerStyleType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/markerstyletype/) 열거형으로 정의됩니다. 비표준 형태가 필요한 경우 그림 채우기가 적용된 마커를 사용하여 사용자 정의 비주얼을 에뮬레이트할 수 있습니다.

**차트를 이미지나 SVG로 내보낼 때 마커가 유지되나요?**

예. 차트를 [raster formats](/slides/ko/python-net/convert-powerpoint-to-png/) 로 렌더링하거나 [shapes as SVG](/slides/ko/python-net/render-a-slide-as-an-svg-image/) 로 저장할 때 마커는 크기, 채우기 및 외곽선 설정을 포함한 외관을 유지합니다.