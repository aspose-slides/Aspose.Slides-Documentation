---
title: Python에서 PowerPoint 슬라이드를 이미지로 변환하기
linktitle: 슬라이드 이미지 변환
type: docs
weight: 41
url: /ko/python-net/convert-slide/
keywords:
- 슬라이드 변환
- 슬라이드 이미지 변환
- 슬라이드 이미지로 내보내기
- 슬라이드 이미지 저장
- 슬라이드 이미지
- 슬라이드 PNG
- 슬라이드 JPEG
- 슬라이드 비트맵
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 슬라이드를 다양한 형식으로 변환하는 방법을 배웁니다. PPTX와 ODP 슬라이드를 BMP, PNG, JPEG, TIFF 등 고품질 결과로 손쉽게 내보낼 수 있습니다."
---
## **소개**

Aspose.Slides for Python via .NET를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션 슬라이드를 BMP, PNG, JPG(JPEG), GIF 등 다양한 이미지 형식으로 쉽게 변환할 수 있습니다.

슬라이드를 이미지로 변환하려면 다음 단계를 수행하십시오:

1. 원하는 변환 설정을 정의하고 다음 중 하나를 사용하여 내보낼 슬라이드를 선택합니다:
    - [TiffOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/) 클래스, 또는
    - [RenderingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/renderingoptions/) 클래스.
2. [Slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/) 클래스의 `get_image` 메서드를 호출하여 슬라이드 이미지를 생성합니다.

Aspose.Slides for Python via .NET에서 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/)는 픽셀 데이터로 정의된 이미지를 작업할 수 있게 해주는 클래스입니다. 이 클래스를 사용하면 BMP, JPG, PNG 등 다양한 형식으로 이미지를 저장할 수 있습니다.

## **슬라이드를 비트맵으로 변환하고 PNG 형식으로 저장하기**

슬라이드를 비트맵 객체로 변환하여 애플리케이션에서 직접 사용할 수 있습니다. 또는 슬라이드를 비트맵으로 변환한 후 JPEG 등 원하는 형식으로 저장할 수 있습니다.

다음 Python 코드는 프레젠테이션의 첫 번째 슬라이드를 비트맵 객체로 변환한 뒤 PNG 형식으로 저장하는 방법을 보여줍니다:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # 프레젠테이션의 첫 번째 슬라이드를 비트맵으로 변환합니다.
    with presentation.slides[0].get_image() as image:
        # 이미지를 PNG 형식으로 저장합니다.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **사용자 지정 크기로 슬라이드 이미지 변환하기**

특정 크기의 이미지가 필요할 수 있습니다. [get_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) 메서드의 오버로드를 사용하면 원하는 너비와 높이로 슬라이드를 이미지로 변환할 수 있습니다.

다음 샘플 코드는 이를 구현하는 방법을 보여줍니다:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # 지정된 크기로 프레젠테이션의 첫 번째 슬라이드를 비트맵으로 변환합니다.
    with presentation.slides[0].get_image(image_size) as image:
        # 이미지를 JPEG 형식으로 저장합니다.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **노트와 주석이 포함된 슬라이드를 이미지로 변환하기**

일부 슬라이드에는 노트와 주석이 포함될 수 있습니다.

Aspose.Slides는 [TiffOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/)와 [RenderingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/renderingoptions/) 두 클래스를 제공하여 프레젠테이션 슬라이드를 이미지로 렌더링하는 방식을 제어할 수 있습니다. 두 클래스 모두 `slides_layout_options` 속성을 포함하고 있으며, 이를 통해 슬라이드를 이미지로 변환할 때 노트와 주석의 렌더링을 구성할 수 있습니다.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용하면 결과 이미지에서 노트와 주석의 위치를 원하는 대로 지정할 수 있습니다.

다음 Python 코드는 노트와 주석이 포함된 슬라이드를 변환하는 방법을 보여줍니다:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # 노트의 위치를 설정합니다.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # 주석의 위치를 설정합니다.
    notes_comments_options.comments_area_width = 500                                       # 주석 영역의 너비를 설정합니다.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # 주석 영역의 색을 설정합니다.

    # 렌더링 옵션을 생성합니다.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # 프레젠테이션의 첫 번째 슬라이드를 이미지로 변환합니다.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # 이미지를 GIF 형식으로 저장합니다.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 
슬라이드‑이미지 변환 과정에서 `notes_position` 속성을 `BOTTOM_FULL`(노트 위치 지정)으로 설정할 수 없습니다. 이는 노트 텍스트가 너무 길어 지정된 이미지 크기에 맞추기 어려울 수 있기 때문입니다.
{{% /alert %}} 

## **TIFF 옵션을 사용하여 슬라이드 이미지 변환하기**

[TiffOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/) 클래스는 크기, 해상도, 색상 팔레트 등 다양한 매개변수를 지정하여 결과 TIFF 이미지에 대한 제어를 강화합니다.

다음 Python 코드는 TIFF 옵션을 사용하여 300 DPI 해상도와 2160 × 2800 크기의 흑백 이미지를 출력하는 변환 과정을 보여줍니다:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# 프레젠테이션 파일을 로드합니다.
with slides.Presentation("sample.pptx") as presentation:
    # 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # 출력 TIFF 이미지의 설정을 구성합니다.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # 이미지 크기를 설정합니다.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # 픽셀 형식(흑백)을 설정합니다.
    options.dpi_x = 300                                                        # 가로 해상도를 설정합니다.
    options.dpi_y = 300                                                        # 세로 해상도를 설정합니다.

    # 지정된 옵션으로 슬라이드를 이미지로 변환합니다.
    with slide.get_image(options) as image:
        # 이미지를 TIFF 형식으로 저장합니다.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **전체 슬라이드를 이미지로 변환하기**

Aspose.Slides를 사용하면 프레젠테이션의 모든 슬라이드를 이미지로 변환할 수 있으므로 전체 프레젠테이션을 일련의 이미지로 만들 수 있습니다.

다음 샘플 코드는 Python에서 프레젠테이션의 모든 슬라이드를 이미지로 변환하는 방법을 보여줍니다:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # 프레젠테이션을 슬라이드 별로 이미지로 렌더링합니다.
    for i, slide in enumerate(presentation.slides):
        # 숨긴 슬라이드 제어 (숨긴 슬라이드는 렌더링하지 않음).
        if slide.hidden:
            continue

        # 슬라이드를 이미지로 변환합니다.
        with slide.get_image(scale_x, scale_y) as image:
            # 이미지를 JPEG 형식으로 저장합니다.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **FAQ**

**Aspose.Slides에서 애니메이션이 적용된 슬라이드를 렌더링할 수 있나요?**

아니요, `get_image` 메서드는 애니메이션 없이 슬라이드의 정적인 이미지만 저장합니다.

**숨겨진 슬라이드를 이미지로 내보낼 수 있나요?**

네, 숨겨진 슬라이드도 일반 슬라이드와 동일하게 처리할 수 있습니다. 처리 루프에 포함되어 있는지 확인하십시오.

**이미지를 그림자와 효과와 함께 저장할 수 있나요?**

네, Aspose.Slides는 슬라이드를 이미지로 저장할 때 그림자, 투명도 및 기타 그래픽 효과를 렌더링하는 것을 지원합니다.