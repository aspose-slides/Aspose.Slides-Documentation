---
title: Python을 사용하여 프레젠테이션에서 차트 데이터 마커 관리
linktitle: 데이터 마커
type: docs
url: /ko/python-java/chart-data-marker/
keywords:
- 차트
- 데이터 포인트
- 마커
- 마커 옵션
- 마커 크기
- 채우기 유형
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Java를 통해 Python용 Aspose.Slides에서 차트 데이터 마커를 사용자 정의하는 방법을 배우고, 명확한 Python 코드 예제로 PPT 및 PPTX 형식의 프레젠테이션 효과를 향상시킵니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 데이터 마커를 사용하는 방법을 설명합니다. 차트를 만들고, 시리즈와 해당 데이터 포인트에 접근하고, 데이터 포인트 수준에서 마커에 사진 채우기를 적용하고, 마커 크기를 조정하고, 업데이트된 프레젠테이션을 저장하는 방법을 보여줍니다. 또한 표준 마커 모양은 [MarkerStyleType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/markerstyletype/) 열거형을 통해 사용할 수 있으며, 차트를 래스터 형식이나 SVG로 내보낼 때 마커 모양이 유지된다는 점도 언급합니다.

## **차트 마커 옵션 설정**
마커는 특정 시리즈 내의 차트 데이터 포인트에 설정할 수 있습니다. 차트 마커 옵션을 설정하려면 다음 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 사진을 설정합니다.
- 첫 번째 차트 시리즈에 접근합니다.
- 새 데이터 포인트를 추가합니다.
- 프레젠테이션을 디스크에 씁니다.

다음 예제는 데이터 포인트 수준에서 차트 마커 옵션을 설정합니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# 빈 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.getSlides().get_Item(0)

    # 기본 차트를 생성합니다.
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # 기본 차트 데이터 워크시트 인덱스를 가져옵니다.
    default_worksheet_index = 0

    # 차트 데이터 워크북을 가져옵니다.
    workbook = chart.getChartData().getChartDataWorkbook()

    # 데모 시리즈를 삭제합니다.
    chart.getChartData().getSeries().clear()

    # 새로운 시리즈를 추가합니다.
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # 첫 번째 이미지를 로드합니다.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # 두 번째 이미지를 로드합니다.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # 첫 번째 차트 시리즈에 접근합니다.
    series = chart.getChartData().getSeries().get_Item(0)

    # 데이터 포인트를 추가합니다.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # 차트 시리즈 마커 크기를 변경합니다.
    series.getMarker().setSize(15)

    # 차트가 포함된 프레젠테이션을 저장합니다.
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**기본 제공되는 마커 모양은 무엇입니까?**

표준 모양(원, 정사각형, 다이아몬드, 삼각형 등)이 제공되며, 목록은 [MarkerStyleType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/markerstyletype/) 클래스에 정의되어 있습니다. 비표준 모양이 필요하면 사진 채우기가 적용된 마커를 사용하여 사용자 정의 시각 효과를 구현할 수 있습니다.

**차트를 이미지 또는 SVG로 내보낼 때 마커가 유지됩니까?**

예. 차트를 [래스터 형식](/slides/ko/python-java/convert-powerpoint-to-png/)으로 렌더링하거나 [SVG로 저장](/slides/ko/python-java/render-a-slide-as-an-svg-image/)할 때 마커는 크기, 채우기 및 외곽선 설정을 포함한 외관을 그대로 유지합니다.