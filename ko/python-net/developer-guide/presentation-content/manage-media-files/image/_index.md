---
title: Python으로 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/python-net/image/
keywords:
- 이미지 추가
- 그림 추가
- 이미지 교체
- 이미지 컬렉션
- 그림 프레임
- 링크된 이미지
- 배경
- PNG 추가
- JPG 추가
- SVG 추가
- SVG를 도형으로 변환
- 외부 SVG 리소스
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 래스터와 SVG 이미지를 추가, 재사용, 링크, 교체 및 관리하는 방법을 배웁니다."
---
## **소개**

Aspose.Slides for Python via .NET는 이미지와 작업하는 다양한 방법을 제공하며, 각 방법은 다른 용도를 가집니다. 이미지를 프레젠테이션에 저장하거나, 그림 프레임에 표시하거나, 슬라이드 배경으로 사용하거나, 외부 이미지에 링크를 걸거나, 공유 이미지 리소스를 교체하거나, SVG 콘텐츠를 편집 가능한 도형으로 변환할 수 있습니다.

이 문서는 이미지 리소스와 프레젠테이션 전체에서 사용되는 방식을 중점적으로 다룹니다. 개별 그림 프레임에 적용되는 자르기, 투명도, 효과, 스트레칭 및 기타 서식에 대한 내용은 [그림 프레임](/slides/ko/python-net/picture-frame/)을 참고하십시오.

## **이미지 모델 이해하기**

다음 API 개념은 밀접하게 관련되어 있지만 동일하게 사용할 수는 없습니다.

- [프레젠테이션 이미지 컬렉션](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/)은 프레젠테이션에서 사용되는 이미지 리소스를 저장합니다. 이미지 데이터를 추가하고 [IPPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ippimage/) 리소스를 얻으려면 [ImageCollection.add_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/add_image/)를 사용합니다.
- [그림 프레임](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ipictureframe/)은 슬라이드, 레이아웃 또는 마스터에 이미지를 표시하는 도형입니다. 슬라이드에 이미지 리소스를 배치하려면 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_picture_frame/)를 사용합니다.
- 슬라이드 배경은 도형이 아니라 슬라이드 채우기의 일부로 이미지를 사용합니다. 따라서 그림 프레임과 같은 동작을 하지 않습니다.
- [IPPImage.replace_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ippimage/replace_image/)은 이미지 리소스를 교체합니다. 여러 프레젠테이션 요소가 해당 리소스를 사용하고 있다면 모두 교체된 이미지를 사용하게 됩니다.
- SVG를 도형으로 변환하면 편집 가능한 슬라이드 도형이 생성됩니다. 변환 후에는 콘텐츠가 하나의 그림 리소스로 관리되지 않습니다.

일반적인 작업 흐름은 다음과 같습니다: 이미지 컬렉션에 이미지 데이터를 추가하고, [IPPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ippimage/)를 받은 다음, 해당 리소스를 하나 이상의 그림 프레임이나 채우기에 사용합니다.

## **임베드된 이미지 추가하기**

로컬 이미지를 삽입하려면 파일을 읽고, 데이터를 이미지 컬렉션에 추가한 다음, 반환된 `IPPImage`를 사용하는 그림 프레임을 생성합니다.

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

이 방법으로 추가된 이미지는 프레젠테이션에 임베드되므로, 결과 파일은 원본 이미지 파일이 존재하지 않아도 작동합니다.

### **웹에서 이미지 추가하기**

이미지가 HTTP 또는 HTTPS를 통해 제공되는 경우, 바이트를 다운로드하여 프레젠테이션 이미지 컬렉션에 추가하고, 반환된 이미지 리소스를 로컬 이미지와 동일한 방식으로 사용합니다.

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

오래 실행되는 애플리케이션에서는 각 요청마다 새 연결을 만들기보다는 적절히 HTTP 클라이언트 또는 연결 풀을 재사용하십시오. 또한 신뢰할 수 없는 소스인 경우 원격 URL, 응답 크기 및 콘텐츠 유형을 검증해야 합니다.

## **슬라이드 간 이미지 재사용하기**

같은 이미지를 여러 번 사용해야 할 경우, 프레젠테이션에 한 번만 추가하고 추가 그림 프레임을 만들 때 반환된 [IPPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ippimage/)를 재사용하십시오. 이렇게 하면 동일한 소스 데이터를 반복해서 로드하는 것을 방지하고, 공유 이미지 리소스와 사용 위치 간의 관계가 명확해집니다.

많은 슬라이드에 자동으로 표시되어야 하는 그래픽(예: 회사 로고)의 경우, 각 슬라이드에 동일한 도형을 추가하기보다 [슬라이드 마스터](/slides/ko/python-net/slide-master/) 또는 레이아웃에 그림 프레임을 배치하는 것이 좋습니다.

## **이미지를 슬라이드 배경으로 사용하기**

배경 이미지는 슬라이드 채우기에 할당되며, 그림 프레임 도형으로 추가되지 않습니다. 이는 그림이 슬라이드 전체 배경을 가리고 일반 슬라이드 객체처럼 조작되지 않아야 할 때 유용합니다.

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

마스터 및 레이아웃 배경을 포함한 추가 배경 옵션은 [프레젠테이션 배경](/slides/ko/python-net/presentation-background/)을 참고하십시오.

## **임베드 이미지와 링크된 이미지**

임베드 이미지와 링크된 이미지는 휴대성 및 파일 크기 측면에서 서로 다른 트레이드오프를 가집니다.

- **임베드 이미지:** 이미지 데이터가 프레젠테이션 내부에 저장됩니다. 프레젠테이션이 자체 포함되지만 파일 크기에 이미지 데이터가 포함됩니다.
- **링크된 이미지:** 프레젠테이션이 외부 이미지에 대한 경로나 URL을 저장합니다. 이렇게 하면 프레젠테이션 크기를 줄일 수 있지만, 열거나 렌더링할 때 외부 리소스에 접근할 수 있어야 합니다.

외부 경로나 URL을 지정하려면 [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/ko/python-net/aspose.slides/islidespicture/link_path_long/)을 사용하여 이미지를 임베드하지 않고 링크된 그림을 만들 수 있습니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

외부 리소스에 신뢰할 수 있게 접근할 수 있는 환경에서만 링크된 이미지를 사용하십시오. 오프라인에서 작업하거나 시스템 간에 이동해야 하는 프레젠테이션의 경우, 임베드된 이미지가 일반적으로 더 안전합니다.

## **SVG 이미지 작업하기**

SVG는 벡터 형식이므로 아이콘, 다이어그램 및 기타 그래픽을 래스터 이미지와 달리 디테일 손실 없이 확장할 수 있어 유용합니다. Aspose.Slides는 SVG를 이미지 리소스로서 및 편집 가능한 슬라이드 도형의 소스로서 모두 지원합니다.

### **SVG를 이미지로 추가하기**

[SvgImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/svgimage/)를 만든 뒤 이미지 컬렉션에 추가하고, 결과 이미지 리소스를 그림 프레임에 배치합니다.

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **SVG를 편집 가능한 도형으로 변환하기**

Aspose.Slides는 SVG를 편집 가능한 슬라이드 도형 그룹으로 변환할 수 있으며, 이는 PowerPoint의 해당 명령과 유사합니다.

![PowerPoint Popup Menu](img_01_01.png)

[ISvgImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/isvgimage/)을 매개변수로 받는 [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_group_shape/) 오버로드를 사용하면 변환을 수행합니다.

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

SVG를 개별 벡터 요소별로 PowerPoint 도형으로 편집해야 할 때 SVG‑to‑shapes 변환을 사용하십시오. SVG를 단순히 표시만 하면 된다면 이미지로 유지하는 것이 더 간단하고 많은 별도 도형을 만드는 복잡성을 피할 수 있습니다.

## **기존 이미지 리소스 교체하기**

[IPPImage.replace_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ippimage/replace_image/)는 기존 이미지 리소스를 교체하고자 할 때 사용합니다. 로고와 같은 공유 그래픽을 교체할 때 특히 유용합니다.

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

여러 그림 프레임, 배경, 마스터 또는 레이아웃이 동일한 이미지 리소스를 사용하고 있다면, 해당 리소스를 교체하면 모든 사용 위치가 업데이트됩니다. 특정 그림 프레임만 변경하고 싶다면 공유 리소스를 교체하기보다 해당 프레임에 다른 이미지를 할당하십시오.

`replace_image`는 또한 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) 또는 다른 [IPPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ippimage/)을 매개변수로 받는 오버로드를 제공합니다.

## **실용적인 이미지 관리 지침**

### **프레젠테이션 크기 관리**

대용량 래스터 이미지는 프레젠테이션을 불필요하게 크게 만들 수 있습니다. 표시될 크기에 적합한 해상도의 원본 이미지를 사용하고, 가능하면 공유 이미지 리소스를 재사용하며, 동일한 고해상도 그래픽을 반복 임베드하지 않도록 하십시오.

이미 그림 프레임에 이미 배치된 래스터 사진의 경우, [PictureFillFormat.compress_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/compress_image/)을 사용하면 선택된 해상도와 자르기 설정에 따라 이미지 데이터를 압축할 수 있습니다. 이는 이미지 컬렉션 관리가 아니라 그림 프레임 처리이므로 관련 서식 작업은 [그림 프레임](/slides/ko/python-net/picture-frame/)을 참고하십시오.

### **임베드 vs. 링크 콘텐츠 선택**

임베드는 모든 이미지 데이터를 파일에 포함시켜 프레젠테이션을 휴대 가능하게 합니다. 링크는 파일 크기를 줄일 수 있지만 외부 종속성을 초래합니다. 외부 종속성이 허용되고 안정적일 때만 링크를 사용하십시오.

### **공유 브랜딩 재사용**

반복되는 로고, 워터마크 또는 장식 그래픽은 하나의 이미지 리소스로 관리하고 재사용하십시오. 그래픽이 슬라이드 내용보다 프레젠테이션 디자인에 속한다면 마스터나 레이아웃에 배치하여 해당 슬라이드에서 자동으로 상속되도록 합니다.

### **SVG 리소스 휴대성 유지**

외부 파일이나 네트워크 리소스에 의존하지 않는 자체 포함 SVG가 이동 및 일관된 렌더링에 더 유리합니다. 가능하면 SVG를 가져오기 전에 필요한 리소스를 임베드하고, 개별 벡터 요소를 편집해야 할 때만 SVG를 도형으로 변환하십시오.

### **현대 크로스플랫폼 이미지 API 사용**

새로운 Python via .NET 코드를 작성할 때는 더 이상 사용되지 않는 `aspose.pydrawing.Image` 또는 `aspose.pydrawing.Bitmap` 이미지 API 대신 Aspose.Slides [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) 및 [Images](https://reference.aspose.com/slides/ko/python-net/aspose.slides/images/) API를 사용하십시오. 마이그레이션 가이드는 [Modern API](/slides/ko/python-net/modern-api/)를 참고하십시오.

WMF 및 EMF는 특별한 고려가 필요합니다. 이러한 형식을 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/)를 통해 전달하면, [ImageCollection.add_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/add_image/)가 메타파일을 삽입 전에 래스터 PNG 형태로 변환합니다. 메타파일 데이터를 보존해야 하는 경우, 스트림 기반 [ImageCollection.add_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/add_image/) 오버로드를 사용하십시오. 스프레드시트 등에서 EMF 콘텐츠를 생성하는 것은 별도의 통합 워크플로이며 이 문서의 범위를 벗어납니다.

## **FAQ**

**이미지 컬렉션과 그림 프레임의 차이점은 무엇인가요?**

이미지 컬렉션은 재사용 가능한 이미지 리소스를 저장합니다. 그림 프레임은 그 리소스 중 하나를 표시하는 슬라이드 도형이며, 자르기 및 효과와 같은 그림 전용 서식을 제공합니다.

**같은 로고를 모든 위치에서 교체하려면 가장 좋은 방법은?**

로고가 이미 하나의 이미지 리소스로 공유되고 있다면, [IPPImage.replace_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ippimage/replace_image/)를 사용해 해당 리소스를 교체하십시오. 프레젠테이션 전체 브랜딩을 위해서는 마스터나 레이아웃에 로고를 배치하면 중복된 슬라이드 내용을 줄일 수 있습니다.

**링크된 이미지가 다른 컴퓨터에서 사라지는 이유는?**

링크된 그림은 외부 파일이나 URL에 의존합니다. 해당 리소스에 다른 컴퓨터에서 접근할 수 없으면 링크된 이미지가 표시되지 않습니다. 프레젠테이션이 자체 포함되어야 한다면 이미지를 임베드하십시오.

**삽입된 SVG를 PowerPoint 도형으로 편집할 수 있나요?**

예. [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_group_shape/)을 사용해 SVG를 변환하면 결과 그룹에 편집 가능한 슬라이드 도형이 포함됩니다. 하나의 SVG 그림이 아니라 개별 도형으로 편집할 수 있게 됩니다.

**많은 이미지를 포함한 프레젠테이션을 어떻게 작게 유지할 수 있나요?**

공유 이미지 리소스를 재사용하고, 불필요하게 큰 래스터 소스를 피하며, 적절할 때 래스터 사진을 압축하고, 반복되는 브랜딩은 마스터나 레이아웃에 두고, 외부 종속성이 허용될 경우에만 링크된 이미지를 사용하십시오.