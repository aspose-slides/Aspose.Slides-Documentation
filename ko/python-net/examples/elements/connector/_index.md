---
title: 커넥터
type: docs
weight: 190
url: /ko/python-net/examples/elements/connector/
keywords:
- 커넥터
- 커넥터 추가
- 커넥터 접근
- 커넥터 제거
- 도형 재연결
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python에서 Aspose.Slides를 사용하여 커넥터를 그리고 제어합니다: 커넥터를 추가하고, 경로를 지정하고, 재경로 지정하고, 연결 지점, 화살표 및 스타일을 설정하여 PPT, PPTX 및 ODP의 도형을 연결합니다."
---
**Aspose.Slides for Python via .NET**를 사용하여 도형을 커넥터로 연결하고 대상을 변경하는 방법을 보여줍니다.

## **커넥터 추가**

슬라이드의 두 지점 사이에 커넥터 모양을 삽입합니다.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 구부러진 커넥터 모양을 추가합니다.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **커넥터 접근**

슬라이드에 추가된 첫 번째 커넥터 모양을 검색합니다.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # 슬라이드에서 첫 번째 커넥터에 접근합니다.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **커넥터 제거**

슬라이드에서 커넥터를 삭제합니다.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 모양이 커넥터라고 가정합니다.
        connector = slide.shapes[0]

        # 커넥터를 제거합니다.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **도형 재연결**

시작 및 종료 대상을 지정하여 커넥터를 두 도형에 연결합니다.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 사각형 모양을 추가합니다.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # 두 번째 사각형 모양을 추가합니다.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # 구부러진 커넥터 모양을 추가합니다.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # 커넥터 시작을 첫 번째 모양에 연결합니다.
        connector.start_shape_connected_to = shape1
        # 커넥터 끝을 두 번째 모양에 연결합니다.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```