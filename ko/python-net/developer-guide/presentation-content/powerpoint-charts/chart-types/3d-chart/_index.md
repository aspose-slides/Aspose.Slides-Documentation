---
title: Python을 사용한 프레젠테이션의 3D 차트 사용자 지정
linktitle: 3D 차트
type: docs
url: /ko/python-net/3d-chart/
keywords:
- 3D 차트
- 회전
- 깊이
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션에 3D 차트를 생성합니다. 회전, 높이 비율, 차트 깊이 및 시리즈 간 간격을 Python 예제로 조정합니다."
---
## **개요**

Aspose.Slides for Python via .NET를 사용하면 [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) 속성을 통해 3D 차트의 보기를 사용자 지정할 수 있습니다. 이 문서에서는 회전, 높이 비율, 깊이, 직각 축 및 시리즈 간 간격을 조정한 후 프레젠테이션을 PPTX 형식으로 저장하는 방법을 보여줍니다.

## **3D 차트의 회전 및 깊이 설정**

아래 예제는 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)을 생성하고 [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/)를 사용하여 첫 번째 슬라이드에 누적 3D 컬럼 차트를 추가합니다. 기본 시리즈와 범주를 각각 세 개의 값을 가진 두 개의 시리즈로 교체합니다. 워크시트 인덱스 `0`은 차트의 첫 번째 데이터 워크시트를 지정하고, 행 `0`은 시리즈 이름을, 열 `0`은 범주 레이블을 포함합니다.

[rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) 및 [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) 속성은 차트의 회전을 각각 40도와 270도로 설정합니다. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/)는 차트의 깊이를 폭의 150%로 설정하고, [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/)는 원근감 대신 직각 축을 활성화합니다. 결과 프레젠테이션에는 이러한 3D 보기 설정이 적용된 차트가 포함됩니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **3D 차트 표면에 그림 채우기 적용**

3D 차트의 [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/), [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/)를 각각 독립적으로 채울 수 있습니다. 표면의 [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)을 `PICTURE`로 설정하고 이미지를 할당합니다. 이미지 한 장을 표면 전체에 맞추려면 [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/)와 표면의 [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/)을 모두 `STRETCH`로 설정합니다.

[arrow.png](arrow.png)을 작업 디렉터리에 저장합니다. 예제는 차트를 회전하고 수직 축의 최대값을 높여 바닥이 컬럼 사이에 보이도록 합니다. 슬라이드를 두 번 복제한 다음 각 슬라이드의 다른 표면에 화살표를 적용합니다. 세 차트 모두 동일한 데이터, 시점 및 배경을 공유합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint는 다음과 같이 세 슬라이드를 표시합니다.

| 측면 벽 | 뒷면 벽 | 바닥 |
| --- | --- | --- |
| ![측면 벽을 따라 차트 안으로 향하는 화살표](side-wall.png) | ![뒷면 벽을 가로질러 오른쪽을 가리키는 화살표](back-wall.png) | ![컬럼 사이 바닥을 가로질러 오른쪽을 가리키는 화살표](floor.png) |

## **3D 차트의 높이 비율 조정**

[Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/)를 사용하여 3D 차트의 높이를 폭에 대한 백분율로 설정합니다. 이는 슬라이드의 차트 개체 크기를 변경하지 않고 3D 장면의 비율을 조정합니다.

다음 예제는 기본 데이터(시리즈 3개와 범주 4개)를 사용하여 [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 차트를 생성합니다. 높이 비율이 50%, 100%, 200%인 세 개의 프레젠테이션을 저장합니다. 차트의 위치, 폭 및 높이는 고정된 상태입니다. 데이터, 회전, 깊이, 시리즈 간 간격 및 서식은 세 파일 모두 동일하며, 높이 비율만 변경됩니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

다음 이미지는 Microsoft PowerPoint를 사용하여 생성된 프레젠테이션에서 내보낸 것입니다. 작은 비율은 더 평평한 장면을, 큰 비율은 동일한 차트 개체 내에서 더 높은 장면을 만듭니다. PowerPoint는 장면에 맞게 축 눈금 간격 및 레이블 배치를 조정할 수도 있습니다.

| 높이: 50% | 높이: 100% | 높이: 200% |
| --- | --- | --- |
| ![폭의 50%로 높이가 설정된 3D 컬럼 차트](height_percent_50.png) | ![폭의 100%로 높이가 설정된 3D 컬럼 차트](height_percent_100.png) | ![폭의 200%로 높이가 설정된 3D 컬럼 차트](height_percent_200.png) |

이러한 속성은 차트의 다양한 측면을 제어합니다:

| 속성 | 효과 |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | 3D 장면의 높이를 폭에 대한 백분율로 나타낸 값. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | 슬라이드에서 차트 개체의 높이(포인트 단위). |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | 3D 장면의 깊이를 폭에 대한 백분율로 나타낸 값. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | 깊이 축을 따라 시리즈 간 간격을 마커 폭의 백분율로 나타낸 값. |

높이 설정은 원통, 원뿔, 피라미드 변형을 포함한 3D 컬럼 및 막대 차트와 3D 선, 영역, 파이, 표면 차트에 영향을 줍니다. 위 비교는 검증된 `COLUMN_3D` 유형을 사용했습니다. 이 설정은 2D `CLUSTERED_COLUMN` 차트나 `BUBBLE_WITH_3D` 차트의 모양을 변경하지 않으며, 이러한 이름은 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 열거형의 멤버입니다. 다른 차트 모양 설정은 [Chart Formatting](/slides/ko/python-net/chart-formatting/)을 참조하십시오.

## **시리즈 간 간격 조정**

[ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/)를 사용하여 3D 차트의 깊이 축을 따라 데이터 시리즈 간 거리를 마커 폭의 백분율로 제어합니다. **0~500**(포함) 값을 사용할 수 있으며, `0`은 간격을 제거하고 큰 값일수록 간격이 증가합니다. 차트 깊이가 고정된 상태에서 간격을 늘리면 깊이 축을 따라 마커가 더 얇아집니다.

[ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/)을 통해 그룹에 접근합니다. 이 설정은 해당 그룹의 모든 시리즈에 적용되며, 접근에 사용된 시리즈에만 적용되는 것이 아닙니다. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/)는 읽기 전용이며 상위 그룹 설정을 반영합니다.

이 설정은 원통, 원뿔, 피라미드 변형을 포함한 3D 컬럼 및 막대 차트와 3D 선, 영역 차트에 영향을 줍니다. 모양은 시리즈가 깊이별, 군집형, 누적형으로 배열되었는지에 따라 달라집니다. 별도 시리즈 간 간격을 명확히 비교하려면 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 열거형의 `ChartType.COLUMN_3D`를 사용하십시오.

이러한 속성은 차트의 다양한 측면을 제어합니다:

| 속성 | 효과 |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | 깊이 축을 따라 시리즈 간 간격을 마커 폭의 백분율로 나타낸 값. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | 인접한 막대 또는 컬럼 군집 간 간격을 막대 또는 컬럼 폭의 백분율로 나타낸 값. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | 차트 전체 깊이를 차트 폭의 백분율로 나타낸 값. |

다음 자체 포함 예제는 기본 차트 데이터(시리즈 3개와 범주 4개)를 사용합니다. 데이터, 회전, 간격 폭 및 차트 깊이가 동일한 두 개의 프레젠테이션을 저장하며, 간격 깊이만 변경됩니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

다음 이미지는 Microsoft PowerPoint를 사용하여 생성된 프레젠테이션에서 내보낸 것입니다.

| 간격 깊이: 0% | 간격 깊이: 500% |
| --- | --- |
| ![깊이 축을 따라 시리즈 간 간격이 없는 3D 컬럼 차트](gap_depth_0.png) | ![깊이 축을 따라 시리즈 간 500% 간격이 있는 3D 컬럼 차트](gap_depth_500.png) |

## **3D 시리즈 유형 및 막대 모양 변경**

군집형 원통 차트에서 첫 번째 시리즈는 원통형 막대로 시작합니다. 예제는 각 변경 전후에 [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) 및 [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/)을 읽습니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| 첫 번째 시리즈에 대한 변경 | `type` | `bar_3d_shape` |
| --- | --- | --- |
| 차트 생성 | `CLUSTERED_CYLINDER` | `CYLINDER` |
| `type`을 `CLUSTERED_CONE`으로 설정 | `CLUSTERED_CONE` | `CONE` |
| `bar_3d_shape`을 `BOX`으로 설정 | `CLUSTERED_COLUMN_3D` | `BOX` |

`BOX`로 모양을 설정하면 시리즈 유형도 `CLUSTERED_COLUMN_3D`로 변경됩니다. 코드에서 시리즈 유형에 따라 분기한다면, 모양을 변경한 후에 `series.type`을 읽으세요. 할당 전에 캐시된 값은 여전히 `CLUSTERED_CONE` 분기를 선택합니다.

![PowerPoint 비교 이미지로 첫 번째 시리즈가 왼쪽에서 오른쪽으로 원통, 원뿔, 직사각형 컬럼으로 표시됨](series-shapes.png)

## **FAQ**

**Aspose.Slides에서 3D 모드를 지원하는 차트 유형은 무엇입니까?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D, 100% Stacked Column 3D 등 컬럼 차트의 3D 변형과 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 열거형을 통해 노출되는 관련 3D 유형을 지원합니다. 정확하고 최신 목록은 설치된 버전의 API 참조에서 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 멤버를 확인하세요.

**보고서나 웹용 3D 차트의 래스터 이미지를 얻을 수 있나요?**

예. 차트를 [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/)로 이미지로 내보내거나 [render the entire slide](/slides/ko/python-net/convert-powerpoint-to-png/)를 사용해 PNG 또는 JPEG와 같은 형식으로 변환할 수 있습니다. 이는 래스터 미리보기가 필요하거나 PowerPoint 없이 차트를 문서, 대시보드, 웹 페이지 등에 삽입하려는 경우에 유용합니다.

**대용량 3D 차트를 구축하고 렌더링하는 성능은 어떻습니까?**

성능은 데이터 양과 시각적 복잡성에 따라 달라집니다. 최상의 결과를 위해 3D 효과를 최소화하고, 벽과 플롯 영역에 무거운 텍스처를 사용하지 않으며, 가능한 경우 시리즈당 데이터 포인트 수를 제한하고, 대상 디스플레이 또는 인쇄 요구에 맞게 적절한 해상도와 크기의 출력으로 렌더링하십시오.