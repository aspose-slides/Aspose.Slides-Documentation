---
title: OLE 객체
type: docs
weight: 210
url: /ko/python-net/examples/elements/ole-object/
keywords:
- OLE 객체
- OLE 객체 추가
- OLE 객체 접근
- OLE 객체 제거
- OLE 객체 업데이트
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 OLE 객체를 작업합니다: 삽입하거나 업데이트된 파일을 포함하고, 아이콘이나 링크를 설정하고, 내용을 추출하며, PPT, PPTX 및 ODP에 대한 동작을 제어합니다."
---
OLE 객체로 파일을 삽입하고 해당 데이터를 **Aspose.Slides for Python via .NET**을 사용하여 업데이트하는 방법을 보여줍니다.

## **OLE 객체 추가**

프레젠테이션에 PDF 파일을 삽입합니다.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 삽입할 PDF 데이터를 로드합니다.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # 슬라이드에 OLE 객체 프레임을 추가합니다.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE 객체 접근**

슬라이드에서 첫 번째 OLE 객체 프레임을 가져옵니다.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # 슬라이드에서 첫 번째 OLE 객체 프레임을 가져옵니다.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **OLE 객체 제거**

슬라이드에서 삽입된 OLE 객체를 삭제합니다.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 OleObjectFrame 객체라고 가정합니다.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE 객체 데이터 업데이트**

기존 OLE 객체에 삽입된 데이터를 교체합니다.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 OleObjectFrame 객체라고 가정합니다.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # 새로운 임베디드 데이터로 OLE 객체를 업데이트합니다.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```