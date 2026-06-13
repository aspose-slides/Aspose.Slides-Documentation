---
title: Python으로 PowerPoint 이미지 관리 최적화
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
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 via .NET 로 사용하여 PowerPoint 및 OpenDocument의 이미지 관리를 효율화하고, 성능을 최적화하며 작업 흐름을 자동화합니다."
---
## **소개**

이미지는 프레젠테이션을 더 매력적이고 흥미롭게 만들어 줍니다. Microsoft PowerPoint에서는 파일, 인터넷 또는 기타 소스에서 그림을 슬라이드에 삽입할 수 있습니다. 마찬가지로 Aspose.Slides는 여러 방법으로 슬라이드에 이미지를 추가할 수 있게 합니다.

{{% alert  title="Tip" color="primary" %}}
Aspose는 무료 변환기인 [JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt)와 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)를 제공하여 이미지를 빠르게 프레젠테이션으로 만들 수 있게 합니다.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
이미지를 프레임 객체로 추가하고 싶다면—특히 크기 조정이나 효과 적용과 같은 표준 서식 옵션을 사용할 계획이라면—[Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/ko/python-net/picture-frame/)을 확인하십시오.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
이미지와 프레젠테이션 I/O 작업을 사용하여 이미지 형식 간 변환이 가능합니다. 아래 페이지를 확인하십시오: convert [image to JPG](https://products.aspose.com/slides/ko/python-net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/ko/python-net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/ko/python-net/conversion/jpg-to-png/); convert [PNG to JPG](https://products.aspose.com/slides/ko/python-net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/ko/python-net/conversion/png-to-svg/); 그리고 convert [SVG to PNG](https://products.aspose.com/slides/ko/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides는 JPEG, PNG, BMP, GIF 등과 같은 널리 사용되는 형식의 이미지를 지원합니다.

## **로컬에 저장된 이미지 슬라이드에 추가**

컴퓨터에서 하나 이상의 이미지를 프레젠테이션의 슬라이드에 추가할 수 있습니다. 다음 Python 예제는 슬라이드에 이미지를 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **웹에서 이미지 슬라이드에 추가**

슬라이드에 추가하려는 이미지가 컴퓨터에 없을 경우 웹에서 직접 삽입할 수 있습니다.

다음 Python 예제는 URL에서 이미지를 가져와 슬라이드에 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드 마스터에 이미지 추가**

슬라이드 마스터는 모든 하위 슬라이드의 테마, 레이아웃 등 정보를 저장하고 제어하는 최상위 슬라이드입니다. 슬라이드 마스터에 이미지를 추가하면 해당 마스터를 사용하는 모든 슬라이드에 이미지가 표시됩니다.

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

## **이미지를 슬라이드 배경으로 설정**

특정 슬라이드 또는 여러 슬라이드의 배경으로 이미지를 사용하고 싶을 수 있습니다. 자세한 내용은 [Set an Image as the Background for a Slide](https://docs.aspose.com/slides/ko/python-net/presentation-background/#set-image-as-background-for-slide)를 참고하십시오.

## **프레젠테이션에 SVG 추가**

프레젠테이션에 이미지를 삽입하려면 [ShapeCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/) 클래스의 [add_picture_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_picture_frame/) 메서드를 사용할 수 있습니다.

SVG에서 이미지 객체를 만들려면 다음 단계를 따르세요:

1. [SvgImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/svgimage/)를 생성하고 프레젠테이션의 이미지 컬렉션에 추가합니다.
2. [SvgImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/svgimage/)에서 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/) 객체를 생성합니다.
3. [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)를 사용하여 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/) 객체를 생성합니다.

다음 Python 샘플은 이러한 단계로 SVG 이미지를 프레젠테이션에 추가하는 방법을 보여줍니다:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # SVG 파일의 내용을 읽습니다.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # SvgImage 객체를 생성합니다.
        svg_image = slides.SvgImage(svg_content)

        # PPImage 객체를 생성합니다.
        pp_image = presentation.images.add_image(svg_image)

        # 새 PictureFrame을 생성합니다.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # 프레젠테이션을 PPTX 형식으로 저장합니다.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **SVG를 도형 집합으로 변환**

Aspose.Slides는 PowerPoint의 SVG 처리 방식과 유사하게 SVG를 도형 집합으로 변환합니다.

![PowerPoint 팝업 메뉴](img_01_01.png)

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

        # SVG 이미지를 도형 그룹으로 변환하고 슬라이드 크기에 맞게 스케일링합니다.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # 프레젠테이션을 PPTX 형식으로 저장합니다.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드에 EMF 이미지 추가**

Aspose.Slides for Python을 사용하면 향상된 메타파일(EMF) 이미지를 프레젠테이션에 삽입할 수 있습니다.

다음 Python 예제가 이를 보여줍니다:

```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **이미지 컬렉션에서 이미지 교체**

Aspose.Slides는 프레젠테이션의 이미지 컬렉션에 저장된 이미지(슬라이드 도형에서 사용되는 이미지 포함)를 교체할 수 있게 합니다. 이 섹션에서는 컬렉션의 이미지를 업데이트하는 여러 방법을 설명합니다. API는 원시 바이트 데이터, [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) 인스턴스, 또는 컬렉션에 이미 존재하는 다른 이미지를 사용하여 이미지를 교체하는 간단한 메서드를 제공합니다.

다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 사용하여 이미지가 포함된 프레젠테이션을 로드합니다.
2. 파일에서 새 이미지를 읽어 바이트 배열에 로드합니다.
3. 바이트 배열을 사용하여 대상 이미지를 새 이미지로 교체합니다.
4. 또는 이미지를 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) 객체로 로드한 뒤 해당 객체를 사용해 대상 이미지를 교체합니다.
5. 또는 프레젠테이션 이미지 컬렉션에 이미 존재하는 이미지를 사용해 대상 이미지를 교체합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```py
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
Aspose의 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 사용하면 텍스트를 쉽게 애니메이션화하고 GIF를 만들 수 있습니다.
{{% /alert %}}

## **자주 묻는 질문**

**삽입 후 원본 이미지 해상도가 유지됩니까?**

예. 원본 픽셀은 보존되지만 최종 모습은 슬라이드에서 [picture](/slides/ko/python-net/picture-frame/)가 어떻게 스케일링되는지와 저장 시 적용되는 압축에 따라 달라집니다.

**수십 개의 슬라이드에서 동일한 로고를 한 번에 교체하는 가장 좋은 방법은 무엇인가요?**

마스터 슬라이드나 레이아웃에 로고를 배치하고 프레젠테이션의 이미지 컬렉션에서 교체하면 해당 리소스를 사용하는 모든 요소에 업데이트가 전파됩니다.

**삽입된 SVG를 편집 가능한 도형으로 변환할 수 있나요?**

예. SVG를 도형 그룹으로 변환할 수 있으며, 이후 개별 파트는 표준 도형 속성을 사용하여 편집할 수 있게 됩니다.

**여러 슬라이드에 한 번에 이미지를 배경으로 설정하려면 어떻게 해야 하나요?**

마스터 슬라이드나 해당 레이아웃에 이미지를 배경으로 지정하면([Assign the image as the background](/slides/ko/python-net/presentation-background/)) 해당 마스터/레이아웃을 사용하는 모든 슬라이드가 배경을 상속합니다.

**많은 그림 때문에 프레젠테이션 파일 크기가 급격히 커지는 것을 어떻게 방지할 수 있나요?**

중복된 이미지를 피하고 단일 이미지 리소스를 재사용하며, 적절한 해상도를 선택하고, 저장 시 압축을 적용하고, 반복되는 그래픽은 가능한 한 마스터에 보관하세요.