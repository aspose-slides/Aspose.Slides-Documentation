---
title: Python에서 프레젠테이션 슬라이드를 이미지로 변환하기
linktitle: 슬라이드 이미지 변환
type: docs
weight: 41
url: /ko/python-net/convert-slide/
keywords:
- 슬라이드 변환
- 슬라이드 내보내기
- 슬라이드 이미지 변환
- 슬라이드 이미지 저장
- 슬라이드 EMF 변환
- 슬라이드 PNG 변환
- 슬라이드 JPEG 변환
- 슬라이드 비트맵 변환
- 슬라이드 TIFF 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 PPT, PPTX 및 ODP 프레젠테이션의 슬라이드를 PNG, JPEG, GIF, TIFF, EMF 및 기타 이미지 형식으로 변환합니다."
---
## **소개**

Aspose.Slides for Python via .NET는 PowerPoint 및 OpenDocument 프레젠테이션에서 개별 슬라이드를 PNG, JPEG, GIF, TIFF 및 기타 이미지 형식으로 렌더링할 수 있습니다.

슬라이드를 이미지로 변환하려면 다음 단계에 따르세요:

1. 프레젠테이션을 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스로 로드합니다.
2. 렌더링하려는 슬라이드를 선택합니다.
3. 필요한 경우 [RenderingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/renderingoptions/) 또는 [TiffOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/) 클래스로 렌더링을 구성합니다.
4. [Slide.get_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/) 메서드를 호출합니다. 이 메서드는 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) 객체를 반환합니다.
5. [IImage.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/save/) 메서드를 호출하고 [ImageFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imageformat/) 값을 지정하여 출력 형식을 정합니다.

## **슬라이드를 PNG 이미지로 변환하기**

가장 간단한 변환은 기본 렌더링 설정을 사용합니다. 결과인 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) 객체는 메모리에서 처리하거나 파일로 저장할 수 있습니다.

다음 Python 예제는 첫 번째 슬라이드를 렌더링하고 PNG 이미지로 저장합니다:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **맞춤 크기로 슬라이드를 이미지로 변환하기**

[Slide.get_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) 오버로드를 사용하여 [Size](https://reference.aspose.com/slides/ko/python-net/aspose.pydrawing/size/) 값을 받아 정확한 픽셀 크기로 슬라이드를 렌더링합니다.

다음 예제는 1820 × 1040 JPEG 이미지를 생성합니다:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **노트와 주석이 포함된 슬라이드를 이미지로 변환하기**

기본적으로 슬라이드 이미지는 노트나 주석을 포함하지 않습니다. [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notescommentslayoutingoptions/) 객체를 [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) 속성에 할당하여 노트와 주석이 표시되는 위치를 제어합니다.

다음 예제는 잘린 노트를 슬라이드 아래에, 주석을 오른쪽에 배치합니다:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
슬라이드에서 이미지로 변환할 때는 [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) 속성을 [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notespositions/) 으로 설정하지 마세요. 노트는 고정 이미지 크기보다 더 많은 텍스트를 포함할 수 있습니다. 대신 [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notespositions/) 를 사용하세요.
{{% /alert %}}

## **TIFF 옵션을 사용하여 슬라이드를 이미지로 변환하기**

[TiffOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/) 클래스를 사용하면 렌더링된 TIFF 이미지의 크기, 해상도 및 기타 속성을 제어할 수 있습니다.

다음 예제는 첫 번째 슬라이드를 300 DPI에서 2160 × 2880 TIFF 이미지로 렌더링합니다:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **모든 슬라이드를 이미지로 변환하기**

슬라이드 컬렉션을 반복하여 전체 프레젠테이션을 일련의 이미지로 변환합니다. 별도로 건너뛰지 않는 한 숨겨진 슬라이드도 포함됩니다.

다음 예제는 모든 슬라이드를 가로·세로 배율 2인 JPEG 이미지로 렌더링합니다:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **향상 메타파일 출력 만들기**

Enhanced Metafile (EMF)은 벡터 기반 그래픽을 Microsoft Office 또는 Windows 메타파일을 지원하는 다른 Windows 응용 프로그램과 교환해야 할 때 유용합니다. 픽셀 기반 이미지와 달리 EMF는 선명도 손실 없이 확대·축소할 수 있는 벡터 그리기 작업을 보존합니다. 그러나 EMF는 주로 Windows 메타파일을 지원하는 응용 프로그램을 위한 호환성 형식이며, 보편적인 교환 형식은 아닙니다. 또한 비트맵 이미지 및 일부 효과와 같은 복잡한 슬라이드 콘텐츠는 벡터 메타파일 컨테이너 내부에 래스터화된 요소로 저장될 수 있습니다.

### **슬라이드를 EMF로 내보내기**

[Slide.write_as_emf](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/write_as_emf/) 메서드는 [Slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/)을 EMF 형식으로 대상 스트림에 씁니다. 다음 예제는 프레젠테이션을 로드하고, 첫 번째 슬라이드를 선택한 뒤 EMF 파일 스트림에 씁니다:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

호출자는 [Slide.write_as_emf](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/write_as_emf/)에 전달된 스트림을 소유하며 이를 닫아야 합니다. Aspose.Slides는 스트림의 현재 위치에서 쓰고 스트림을 열어 둡니다.

### **SVG 이미지를 EMF로 변환하고 프레젠테이션에 추가하기**

[SvgImage.write_as_emf](https://reference.aspose.com/slides/ko/python-net/aspose.slides/svgimage/write_as_emf/)을 사용하여 SVG 콘텐츠를 EMF로 변환합니다. 결과 바이트는 [ImageCollection.add_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/add_image/)을 통해 프레젠테이션에 추가하고 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_picture_frame/)으로 슬라이드에 배치할 수 있습니다.

다음 예제는 SVG 마크업으로부터 [SvgImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/svgimage/)을 생성하고, 메모리 내 EMF로 변환한 뒤 첫 번째 슬라이드에 메타파일을 삽입하고 프레젠테이션을 저장합니다:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/ko/python-net/aspose.slides/svgimage/write_as_emf/)은 대상 스트림에 대한 소유권을 갖지 않습니다. 쓰기 후 스트림 위치는 생성된 데이터 끝에 있습니다. 위와 같이 `getvalue`를 호출하여 현재 스트림 위치와 관계없이 전체 버퍼를 가져오세요. 데이터가 읽힐 때까지 스트림을 열어 두고, 이후에 닫습니다.

EMF 생성은 Aspose.Slides for Python via .NET이 지원하는 운영 체제에서 사용할 수 있지만, 폰트나 네이티브 그래픽 종속성이 없을 경우 플랫폼마다 렌더링 결과가 다를 수 있습니다. 소스 콘텐츠에 사용된 폰트를 설치하거나 적절한 대체 폰트를 구성하고, Aspose.Slides의 [platform requirements](/slides/ko/python-net/system-requirements/)를 따른 뒤 대상 EMF 사용 애플리케이션에서 결과를 검증하세요. Linux 및 macOS 응용 프로그램은 Windows 메타파일을 표시·편집하는 지원이 제한적이거나 일관되지 않을 수 있습니다.

## **컬러 이모지 렌더링**

{{% alert title="Note" color="info" %}}
프레젠테이션 슬라이드를 이미지로 변환할 때 색상 이모지를 올바르게 렌더링하려면 프레젠테이션에 사용된 이모지 폰트가 변환을 수행하는 시스템에 설치되어 있어야 합니다. 예를 들어 프레젠테이션이 **Segoe UI Emoji**를 사용하고 이 폰트가 없으면 이모지가 단색으로 표시될 수 있습니다.
{{% /alert %}}

## **FAQ**

**Aspose.Slides는 애니메이션이 포함된 슬라이드 렌더링을 지원하나요?**

아니요. [Slide.get_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/) 메서드는 슬라이드의 정적인 이미지를 렌더링하며 애니메이션을 내보내지 않습니다.

**숨겨진 슬라이드를 이미지로 내보낼 수 있나요?**

예. 숨겨진 슬라이드도 일반 슬라이드처럼 렌더링할 수 있습니다. 위 예제와 같이 처리 루프에 포함하면 됩니다.

**슬라이드 이미지에 그림자 및 기타 효과가 보존되나요?**

예. Aspose.Slides는 그림자, 투명도 및 기타 지원되는 그래픽 효과를 슬라이드 이미지에 렌더링합니다.