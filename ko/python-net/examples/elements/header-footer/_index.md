---
title: 헤더푸터
type: docs
weight: 220
url: /ko/python-net/examples/elements/header-footer/
keywords:
- 헤더 푸터
- 헤더 푸터 추가
- 헤더 푸터 업데이트
- 날짜 및 시간 설정
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 헤더와 푸터를 제어합니다: 날짜/시간, 슬라이드 번호, 푸터 텍스트를 추가하거나 편집하고, PPT, PPTX 및 ODP에서 플레이스홀더를 표시하거나 숨깁니다."
---
**Aspose.Slides for Python via .NET**를 사용하여 바닥글을 추가하고 날짜 및 시간 플레이스홀더를 업데이트하는 방법을 보여줍니다.

## **바닥글 추가**

슬라이드의 바닥글 영역에 텍스트를 추가하고 표시되도록 합니다.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **날짜 및 시간 업데이트**

슬라이드의 날짜 및 시간 플레이스홀더를 수정합니다.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```