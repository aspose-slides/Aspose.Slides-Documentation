---
title: Python으로 PowerPoint에서 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/python-net/image/
keywords:
- 이미지 추가
- 그림 추가
- 비트맵 추가
- 이미지 교체
- 그림 교체
- 웹에서
- 배경
- PNG 추가
- JPG 추가
- SVG 추가
- EMF 추가
- WMF 추가
- TIFF 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument의 이미지 관리를 간소화하고 성능을 최적화하며 워크플로를 자동화합니다."
---
## **소개**

이미지는 프레젠테이션을 더 매력적이고 흥미롭게 만듭니다. Microsoft PowerPoint에서 파일, 인터넷 또는 기타 소스에서 사진을 슬라이드에 삽입할 수 있습니다. 마찬가지로 Aspose.Slides를 사용하면 여러 가지 방법으로 슬라이드에 이미지를 추가할 수 있습니다.

{{% alert  title="Tip" color="primary" %}}
Aspose는 무료 변환기—[JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 이미지를 빠르게 프레젠테이션으로 만들 수 있습니다.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
프레임 객체로 이미지를 추가하려는 경우—특히 크기 조정이나 효과 적용과 같은 표준 서식 옵션을 사용할 계획이라면—[Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/ko/python-net/picture-frame/)을 참조하십시오.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
이미지 및 프레젠테이션 I/O 작업을 사용하여 이미지 형식을 변환할 수 있습니다. 다음 페이지를 참조하십시오: 이미지를 JPG로 변환하려면 [image to JPG](https://products.aspose.com/slides/ko/python-net/conversion/image-to-jpg/) 를, JPG를 이미지로 변환하려면 [JPG to image](https://products.aspose.com/slides/ko/python-net/conversion/jpg-to-image/) 를, JPG를 PNG로 변환하려면 [JPG to PNG](https://products.aspose.com/slides/ko/python-net/conversion/jpg-to-png/) 를, PNG를 JPG로 변환하려면 [PNG to JPG](https://products.aspose.com/slides/ko/python-net/conversion/png-to-jpg/) 를, PNG를 SVG로 변환하려면 [PNG to SVG](https://products.aspose.com/slides/ko/python-net/conversion/png-to-svg/) 를, 그리고 SVG를 PNG로 변환하려면 [SVG to PNG](https://products.aspose.com/slides/ko/python-net/conversion/svg-to-png/) 를 참조하십시오.
{{% /alert %}}

Aspose.Slides는 JPEG, PNG, BMP, GIF 등과 같은 일반적인 이미지 형식을 지원합니다.

## **로컬에 저장된 이미지를 슬라이드에 추가**

컴퓨터에서 하나 이상의 이미지를 프레젠테이션의 슬라이드에 추가할 수 있습니다. 다음 Python 예제는 이미지를 슬라이드에 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **웹에서 이미지를 슬라이드에 추가**

슬라이드에 추가하려는 이미지가 컴퓨터에 없으면 웹에서 직접 삽입할 수 있습니다.

다음 Python 예제는 URL에서 이미지를 슬라이드에 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 원시 이미지 바이트를 다운로드합니다.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드 마스터에 이미지 추가**

슬라이드 마스터는 모든 하위 슬라이드에 대한 테마, 레이아웃 등 정보를 저장하고 제어하는 최상위 슬라이드입니다. 슬라이드 마스터에 이미지를 추가하면 해당 마스터를 사용하는 모든 슬라이드에 이미지가 표시됩니다.

다음 Python 예제는 슬라이드 마스터에 이미지를 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드 배경으로 이미지 추가**

한 개 이상의 슬라이드 배경으로 사진을 사용할 수 있습니다. 자세한 내용은 *[Setting Images as Backgrounds for Slides](/slides/ko/python-net/presentation-background/#setting-images-as-background-for-slides)* 를 참조하십시오.

## **프레젠테이션에 SVG 추가**

SVG 콘텐츠는 [SvgImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/svgimage/) 클래스를 사용하여 프레젠테이션에 추가할 수 있습니다. 결과 SVG 이미지는 프레젠테이션 이미지 컬렉션에 추가된 후 그림 프레임을 만드는 데 사용할 수 있습니다.

다음 Python 예제는 독립적인 SVG 문자열을 가져옵니다. 이 SVG에서 사용되는 모든 이미지, 스타일 및 기타 리소스는 SVG 콘텐츠에 직접 포함됩니다.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **SVG를 도형 집합으로 변환**

Aspose.Slides는 PowerPoint의 SVG 처리 방식과 유사하게 SVG를 도형 집합으로 변환합니다.

![PowerPoint Popup Menu](img_01_01.png)

이 기능은 첫 번째 인수로 [SvgImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/svgimage/)을 받는 [ShapeCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/) 클래스의 [add_group_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_group_shape/) 메서드 오버로드에 의해 제공됩니다. 

아래 샘플 코드는 SVG 파일을 도형 집합으로 변환하는 방법을 보여줍니다.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # SVG 파일 내용을 읽습니다.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # SvgImage 객체를 생성합니다.
        svg_image = slides.SvgImage(svg_content)

        # 슬라이드 크기를 가져옵니다.
        slide_size = presentation.slide_size.size

        # SVG 이미지를 도형 그룹으로 변환하고 슬라이드 크기에 맞게 스케일합니다.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # 프레젠테이션을 PPTX 형식으로 저장합니다.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드에 EMF 이미지 추가**

Aspose.Slides for Python을 사용하면 향상된 메타파일(EMF) 이미지를 프레젠테이션에 삽입할 수 있습니다.

다음 Python 예제가 이를 보여줍니다:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **이미지 컬렉션의 이미지 교체**

Aspose.Slides를 사용하면 슬라이드 도형에서 사용되는 이미지를 포함하여 프레젠테이션의 이미지 컬렉션에 저장된 이미지를 교체할 수 있습니다. 이 섹션에서는 컬렉션의 이미지를 업데이트하는 여러 접근 방식을 설명합니다. API는 원시 바이트 데이터, [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) 인스턴스, 또는 컬렉션에 이미 존재하는 다른 이미지로 이미지를 교체하는 간단한 메서드를 제공합니다.

다음 단계에 따라 진행하십시오:

1. 이미지를 포함하는 프레젠테이션을 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 사용하여 로드합니다.
1. 파일에서 새 이미지를 로드하여 바이트 배열에 저장합니다.
1. 바이트 배열을 사용하여 대상 이미지를 새 이미지로 교체합니다.
1. 또는 이미지를 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) 객체에 로드한 후 해당 객체로 대상 이미지를 교체합니다.
1. 또는 프레젠테이션 이미지 컬렉션에 이미 존재하는 이미지로 대상 이미지를 교체합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("sample.pptx") as presentation:

    # 첫 번째 방법.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # 두 번째 방법.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # 세 번째 방법.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # 프레젠테이션을 파일에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Aspose의 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 사용하면 텍스트를 쉽게 애니메이션화하고 GIF로 만들 수 있습니다.
{{% /alert %}}

## **FAQ**

**삽입 후 원본 이미지 해상도가 그대로 유지됩니까?**

예. 원본 픽셀은 보존되지만 최종 표시 방식은 슬라이드에서 [picture](/slides/ko/python-net/picture-frame/)가 어떻게 확대/축소되는지와 저장 시 적용되는 압축에 따라 달라집니다.

**수십 개의 슬라이드에서 동일한 로고를 한 번에 교체하는 가장 좋은 방법은 무엇인가요?**

마스터 슬라이드나 레이아웃에 로고를 배치하고 프레젠테이션 이미지 컬렉션에서 교체하면 해당 리소스를 사용하는 모든 요소에 업데이트가 전파됩니다.

**삽입된 SVG를 편집 가능한 도형으로 변환할 수 있나요?**

예. SVG를 도형 그룹으로 변환하면 개별 파트를 표준 도형 속성으로 편집할 수 있게 됩니다.

**한 번에 여러 슬라이드의 배경으로 그림을 설정하려면 어떻게 해야 하나요?**

마스터 슬라이드 또는 해당 레이아웃에서 이미지를 배경으로 지정하십시오([Assign the image as the background](/slides/ko/python-net/presentation-background/)). 해당 마스터/레이아웃을 사용하는 모든 슬라이드가 배경을 상속받습니다.

**많은 그림으로 인해 프레젠테이션 파일이 너무 커지는 것을 어떻게 방지할 수 있나요?**

중복 대신 단일 이미지 리소스를 재사용하고, 적절한 해상도를 선택하며, 저장 시 압축을 적용하고, 반복되는 그래픽은 가능한 경우 마스터에 유지하십시오.