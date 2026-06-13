---
title: 그림
type: docs
weight: 50
url: /ko/python-net/examples/elements/picture/
keywords:
- 그림
- 그림 프레임
- 그림 추가
- 그림 접근
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 그림을 처리합니다: 삽입, 교체, 자르기, 압축, 투명도 및 효과 조정, 도형 채우기, 그리고 PPT, PPTX 및 ODP로 내보내기."
---
메모리 내 이미지에서 그림을 삽입하고 액세스하는 방법을 **Aspose.Slides for Python via .NET**을 사용하여 보여줍니다. 아래 예제에서는 메모리에서 이미지를 생성하고 슬라이드에 배치한 다음 가져옵니다.

## **그림 추가**

이 코드는 파일에서 이미지를 로드하고 첫 번째 슬라이드에 그림 프레임으로 삽입합니다.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 파일에서 이미지를 로드합니다.
        with open("image.png", "rb") as image_stream:
            # 이미지를 프레젠테이션 리소스에 추가합니다.
            image = presentation.images.add_image(image_stream)

        # 첫 번째 슬라이드에 이미지를 표시하는 그림 프레임을 삽입합니다.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **그림 액세스**

이 예제는 슬라이드에 그림 프레임이 포함되어 있는지 확인한 다음 찾은 첫 번째 프레임에 접근합니다.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # 슬라이드에서 첫 번째 그림 프레임에 접근합니다.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```