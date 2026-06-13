---
title: 차트
type: docs
weight: 60
url: /ko/python-net/examples/elements/chart/
keywords:
- 차트
- 차트 추가
- 차트 액세스
- 차트 제거
- 차트 업데이트
- 코드 예제
- 파워포인트
- 오픈도큐멘트
- 프레젠테이션
- 파이썬
- Aspose.Slides
description: "Python에서 Aspose.Slides를 사용하여 차트를 만들고 사용자 정의합니다: 데이터 추가, 시리즈 및 축과 레이블 서식 지정, 유형 변경, 그리고 내보내기—PPT, PPTX 및 ODP와 호환됩니다."
---
**Aspose.Slides for Python via .NET**를 사용하여 다양한 차트 유형을 추가, 액세스, 제거 및 업데이트하는 예제입니다. 아래 스니펫은 기본 차트 작업을 보여줍니다.

## **차트 추가**

이 메서드는 첫 번째 슬라이드에 간단한 영역 차트를 추가합니다.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 첫 번째 슬라이드에 간단한 컬럼 차트를 추가합니다.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **차트 액세스**

다음 코드는 shape 컬렉션에서 차트를 가져옵니다.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # 슬라이드에서 첫 번째 차트에 액세스합니다.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **차트 제거**

다음 코드는 슬라이드에서 차트를 제거합니다.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 shape이 차트라고 가정합니다.
        chart = slide.shapes[0]

        # 차트를 제거합니다.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **차트 데이터 업데이트**

제목과 같은 차트 속성을 변경할 수 있습니다.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 shape이 차트라고 가정합니다.
        chart = slide.shapes[0]

        # 차트 제목을 변경합니다.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```