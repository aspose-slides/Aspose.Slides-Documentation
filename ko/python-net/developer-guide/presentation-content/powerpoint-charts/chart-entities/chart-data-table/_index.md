---
title: Python에서 프레젠테이션의 차트 데이터 테이블 사용자 지정
linktitle: 데이터 테이블
type: docs
url: /ko/python-net/chart-data-table/
keywords:
- 차트 데이터
- 데이터 테이블
- 폰트 속성
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션의 차트 데이터 테이블 폰트, 테두리 및 범례 키를 사용자 지정합니다."
---
## **개요**

Aspose.Slides for Python via .NET를 사용하면 차트의 데이터 테이블을 표시하고 텍스트 서식, 테두리 및 범례 키를 사용자 지정할 수 있습니다. 이 문서에서는 테이블을 활성화하고 텍스트를 서식 지정하며 각 유형의 테두리를 제어하고 범례 키를 표시하거나 숨기는 방법을 설명합니다. 예제는 구성된 차트를 PPTX 파일로 저장합니다.

## **폰트 속성 설정**

차트의 데이터 테이블을 표시하려면 [has_data_table](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/has_data_table/)을 `True`로 설정합니다. 테이블에 접근하고 텍스트 서식을 구성하려면 [chart_data_table](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/chart_data_table/)을 사용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 로드합니다.  
1. 첫 번째 슬라이드에 클러스터형 세로 막대 차트를 추가합니다.  
1. 차트의 데이터 테이블을 활성화합니다.  
1. [font_bold](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseportionformat/font_bold/)으로 굵은 텍스트를 적용하고, [font_height](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseportionformat/font_height/)를 `20`으로 설정하여 20포인트 텍스트를 지정합니다.  
1. 수정된 프레젠테이션을 저장합니다.

다음 예제는 작업 디렉터리에 최소 하나의 슬라이드가 포함된 `test.pptx`가 있어야 합니다. 위치 (50, 50)에 기본 데이터가 있는 차트를 추가하고, 너비 600포인트, 높이 400포인트로 설정합니다. 저장된 `output.pptx`에는 데이터 테이블이 활성화되고 지정된 폰트 설정이 적용된 차트가 포함됩니다.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **데이터 테이블 테두리 사용자 지정**

[Chart.has_data_table](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/has_data_table/)으로 테이블을 활성화하고, [Chart.chart_data_table](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/chart_data_table/)을 통해 접근합니다. 세 종류의 테두리를 각각 독립적으로 제어할 수 있습니다.

- [has_border_horizontal](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datatable/has_border_horizontal/)은 가로 셀 테두리를 제어합니다.  
- [has_border_vertical](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datatable/has_border_vertical/)은 세로 셀 테두리를 제어합니다.  
- [has_border_outline](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datatable/has_border_outline/)은 테이블 외곽 테두리를 제어합니다.

각 속성을 `True`로 설정하면 해당 테두리가 표시되고, `False`로 설정하면 숨겨집니다. 다음 예제는 기본 데이터가 있는 클러스터형 세로 막대 차트를 생성하고, 가로 테두리와 외곽 테두리를 표시하며, 세로 테두리를 숨깁니다. 입력 파일이 필요 없으며 차트 위치와 크기는 포인트 단위로 지정됩니다.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

아래 비교는 동일한 차트 데이터와 범례 키 설정을 네 가지 경우에 적용한 것입니다. 모든 테두리를 활성화한 상태에서 각 변형은 하나의 테두리 속성만 비활성화합니다. 좌하단 변형이 예제와 동일한 테두리 설정을 가집니다.

![전체 테두리가 활성화된, 수평 테두리가 없는, 수직 테두리가 없는, 외곽 테두리가 없는 차트 데이터 테이블](data-table-borders.png)

## **범례 키 표시 또는 숨기기**

범례 키는 데이터 테이블의 시리즈 이름 옆에 표시되는 작은 색상 표시기이며, 각 테이블 행을 차트 시리즈와 연결하는 데 도움이 됩니다. [show_legend_key](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datatable/show_legend_key/)을 `True`로 설정하면 표시하고, `False`로 설정하면 숨깁니다.

차트의 별도 범례는 [Chart.has_legend](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/has_legend/)으로 제어합니다. 이 설정은 독립적이며, 별도 범례를 숨겨도 데이터 테이블 내부의 키는 영향을 받지 않고, 테이블 키를 숨겨도 별도 범례는 여전히 표시됩니다.

다음 예제는 기본 데이터가 있는 차트를 만들고, 데이터 테이블을 활성화한 뒤 테이블 내에서 범례 키를 표시하고 별도 범례를 숨깁니다. 모든 테이블 테두리는 명시적으로 활성화됩니다. 입력 프레젠테이션이 필요 없으며, 테이블 키만 숨기려면 `data_table.show_legend_key`를 `False`로 변경하면 됩니다.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

아래 비교는 범례 키가 표시된 테이블과 숨겨진 테이블을 같은 차트에 적용한 모습입니다. 모든 테두리는 그대로 유지되며, 별도 차트 범례는 두 경우 모두 숨겨집니다.

![범례 키가 왼쪽에 표시되고 오른쪽에 숨겨진 차트 데이터 테이블](data-table-legend-keys.png)

## **자주 묻는 질문**

**차트 데이터 테이블에 범례 키를 표시할 수 있나요?**

예. [show_legend_key](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datatable/show_legend_key/)을 `True`로 설정하면 범례 키가 표시되고, `False`로 설정하면 숨겨집니다.

**프레젠테이션을 PDF, HTML 또는 이미지로 내보낼 때 데이터 테이블이 유지되나요?**

예. Aspose.Slides는 차트와 표시된 데이터 테이블을 슬라이드의 일부로 렌더링하므로 [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/ko/python-net/convert-powerpoint-to-html/), [이미지](/slides/ko/python-net/convert-powerpoint-to-png/)로 내보낼 때도 유지됩니다.

**템플릿에서 로드한 차트의 데이터 테이블을 사용할 수 있나요?**

예. 기존 프레젠테이션이나 템플릿에서 로드한 차트에 대해 [has_data_table](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/has_data_table/)을 사용하여 데이터 테이블이 표시되는지 확인하거나 변경할 수 있습니다.

**데이터 테이블이 활성화된 차트를 어떻게 찾나요?**

각 슬라이드의 도형을 순회하면서 차트를 식별하고, 해당 차트의 [has_data_table](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/has_data_table/) 속성을 확인합니다. 값이 `True`이면 데이터 테이블이 활성화된 것입니다.