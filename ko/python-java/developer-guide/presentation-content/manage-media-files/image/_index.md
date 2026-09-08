---
title: Python을 사용한 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/python-java/image/
keywords:
- 이미지 추가
- 그림 추가
- 이미지 교체
- 이미지 컬렉션
- 그림 프레임
- 연결된 이미지
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 래스터 및 SVG 이미지를 추가, 재사용, 연결, 교체 및 관리하는 방법을 배웁니다."
---
## **소개**

Aspose.Slides for Python via Java는 이미지와 작업할 수 있는 여러 방법을 제공하며, 각각은 다른 용도로 사용됩니다. 프레젠테이션에 이미지를 저장하고, 그림 프레임에 표시하고, 슬라이드 배경으로 사용하고, 외부 이미지에 링크하고, 공유 이미지 리소스를 교체하거나, SVG 내용을 편집 가능한 도형으로 변환할 수 있습니다.

이 문서는 이미지 리소스와 프레젠테이션 전반에 걸친 사용 방법에 중점을 둡니다. 개별 그림 프레임에 적용되는 자르기, 투명도, 효과, 스트레칭 및 기타 서식에 대해서는 [Picture Frame](/slides/ko/python-java/picture-frame/)를 참조하세요.

## **이미지 모델 이해하기**

다음 API 개념은 서로 밀접하게 연관되어 있지만 교환 가능하지는 않습니다:

- The [프레젠테이션 이미지 컬렉션](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagecollection/)은 프레젠테이션에서 사용하는 이미지 리소스를 저장합니다. 이미지 데이터를 추가하고 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 리소스를 얻으려면 [ImageCollection.addImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagecollection/#addImage)를 사용합니다.
- A [그림 프레임](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/)은 슬라이드, 레이아웃 또는 마스터에 이미지를 표시하는 도형입니다. 슬라이드에 이미지 리소스를 배치하려면 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addPictureFrame)를 사용합니다.
- 슬라이드 배경은 도형이 아니라 슬라이드 채우기의 일부로 이미지를 사용합니다. 따라서 그림 프레임처럼 동작하지 않습니다.
- [PPImage.replaceImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#replaceImage)는 이미지 리소스를 교체합니다. 여러 프레젠테이션 요소가 해당 리소스를 사용하고 있다면 모두 교체된 이미지가 적용됩니다.
- SVG를 도형으로 변환하면 편집 가능한 슬라이드 도형이 생성됩니다. 변환 후에는 내용이 하나의 그림 리소스로 관리되지 않습니다.

일반적인 작업 흐름은 다음과 같습니다: 이미지 컬렉션에 이미지 데이터를 추가하고, [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/)를 받아서 하나 이상의 그림 프레임이나 채우기에 사용합니다.

## **임베디드 이미지 추가하기**

로컬 이미지를 삽입하려면 파일을 로드하고, 이미지 컬렉션에 추가한 뒤, 반환된 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/)을 사용하는 그림 프레임을 만들면 됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이렇게 추가된 이미지는 프레젠테이션에 임베드되므로, 결과 파일은 원본 이미지 파일이 남아 있지 않아도 됩니다.

### **웹에서 이미지 추가하기**

이미지가 HTTP 또는 HTTPS를 통해 제공되는 경우, 바이트를 다운로드하고 프레젠테이션 이미지 컬렉션에 추가한 뒤, 로컬 이미지와 동일한 방법으로 반환된 이미지 리소스를 사용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

장시간 실행되는 애플리케이션에서는 불필요한 네트워크 인프라를 반복적으로 생성하기보다 애플리케이션에 적합한 HTTP 클라이언트 또는 연결 관리 전략을 재사용하세요. 또한 신뢰할 수 없는 소스일 경우 원격 URL, 응답 크기 및 콘텐츠 유형을 검증하세요.

## **슬라이드 간 이미지 재사용**

동일한 이미지를 여러 번 사용해야 하는 경우, 프레젠테이션에 한 번만 추가하고 추가 그림 프레임을 만들 때 반환된 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/)을 재사용합니다. 이렇게 하면 동일한 소스 데이터를 반복적으로 로드하지 않아도 되고, 공유 이미지 리소스와 사용 위치 간의 관계가 명시적입니다.

많은 슬라이드에 자동으로 표시되어야 하는 그래픽(예: 회사 로고)의 경우, 각각의 슬라이드에 동일한 도형을 추가하기보다 [슬라이드 마스터](/slides/ko/python-java/slide-master/) 또는 레이아웃에 그림 프레임을 배치하는 것을 고려하세요.

## **이미지를 슬라이드 배경으로 사용하기**

배경 이미지는 슬라이드 채우기에 할당되며, 그림 프레임 도형으로 추가되지 않습니다. 이는 그림이 슬라이드 배경을 완전히 덮어야 하고 일반 슬라이드 객체처럼 조작되지 않아야 할 때 유용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

마스터 및 레이아웃 배경을 포함한 추가 배경 옵션은 [Presentation Background](/slides/ko/python-java/presentation-background/)를 참고하세요.

## **임베디드 이미지와 연결된 이미지**

임베디드 이미지와 연결된 이미지는 휴대성 및 파일 크기 측면에서 서로 다른 절충점을 가집니다:

- **임베디드 이미지:** 이미지 데이터가 프레젠테이션 내부에 저장됩니다. 프레젠테이션이 독립형이 되지만 파일 크기에 이미지 데이터가 포함됩니다.
- **연결된 이미지:** 프레젠테이션이 외부 이미지에 대한 경로나 URL을 저장합니다. 이렇게 하면 프레젠테이션 크기를 줄일 수 있지만, 외부 리소스가 열거나 렌더링될 때 접근 가능해야 합니다.

외부 경로나 URL을 할당하여 [Picture.setLinkPathLong](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picture/#setLinkPathLong)으로 연결된 그림을 만들 수 있으며, 이미지 데이터를 임베드하지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

외부 리소스에 안정적으로 접근할 수 있는 배포 환경에서만 연결된 이미지를 사용하세요. 오프라인에서 작동하거나 시스템 간에 이동해야 하는 프레젠테이션의 경우 일반적으로 임베디드 이미지가 더 안전합니다.

## **SVG 이미지 작업하기**

SVG는 벡터 형식이므로 아이콘, 다이어그램 및 래스터 이미지와 달리 디테일 손실 없이 확장이 필요한 그래픽에 유용합니다. Aspose.Slides는 SVG를 이미지 리소스로서뿐만 아니라 편집 가능한 슬라이드 도형의 소스로도 지원합니다.

### **SVG를 이미지로 추가하기**

[SvgImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgimage/)를 생성하고 이미지 컬렉션에 추가한 뒤, 결과 이미지 리소스를 그림 프레임에 배치합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **외부 리소스를 포함하는 SVG 파일**

SVG는 외부 이미지, 스타일시트 또는 글꼴을 참조할 수 있습니다. 이러한 경우, [SvgImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgimage/)는 [ExternalResourceResolver](https://reference.aspose.com/slides/ko/python-java/aspose.slides/externalresourceresolver/)와 기본 URI를 인수로 받는 생성자를 제공합니다. 이 리졸버는 상대 URI를 허용된 절대 URI로 매핑하고 요청된 리소스에 대한 스트림을 반환합니다.

리졸버는 SVG를 처리하는 동안 외부 리소스를 사용할 수 있게 하지만, SVG 자체를 자체 포함 문서로 재작성하지는 않습니다. SVG를 휴대 가능하게 유지해야 한다면, 예를 들어 `data:` URI를 사용하여 연결된 이미지를 SVG에 임베드하세요.

신뢰할 수 없는 소스에서 SVG 파일을 가져오는 경우, 리졸버가 접근할 수 있는 스킴, 파일 위치 및 호스트를 제한하세요. 네트워크 리졸버는 타임아웃, 응답 크기 제한 및 콘텐츠 검증도 적용해야 합니다.

### **SVG를 편집 가능한 도형으로 변환하기**

Aspose.Slides는 SVG를 편집 가능한 슬라이드 도형 그룹으로 변환할 수 있으며, 이는 PowerPoint의 해당 명령과 유사합니다.

![PowerPoint 팝업 메뉴](img_01_01.png)

[ShapeCollection.addGroupShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addGroupShape) 오버로드를 사용하고, 매개변수로 [SvgImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgimage/)를 전달하여 변환을 수행합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

SVG를 도형으로 변환하는 것은 개별 벡터 요소를 PowerPoint 도형으로 편집해야 할 때 사용합니다. SVG를 단순히 표시만 하면 이미지로 유지하는 것이 더 간단하고 많은 개별 도형을 만드는 복잡성을 피할 수 있습니다.

## **기존 이미지 리소스 교체하기**

기존 이미지 리소스를 교체하려면 [PPImage.replaceImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#replaceImage)를 사용합니다. 이는 로고와 같은 공유 그래픽을 교체할 때 특히 유용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

여러 그림 프레임, 배경, 마스터 또는 레이아웃이 동일한 이미지 리소스를 사용하고 있다면, 해당 리소스를 교체하면 모든 사용 위치가 업데이트됩니다. 하나의 그림 프레임만 변경하려면 공유 리소스를 교체하는 대신 해당 프레임에 다른 이미지를 할당하세요.

[PPImage.replaceImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#replaceImage)는 바이트 배열이나 다른 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/)을 매개변수로 받는 오버로드도 제공합니다.

## **실용적인 이미지 관리 가이드**

### **프레젠테이션 크기 제어**

큰 래스터 이미지는 프레젠테이션을 불필요하게 크게 만들 수 있습니다. 의도된 표시 크기에 적합한 차원의 원본 이미지를 사용하고, 가능한 경우 공유 이미지 리소스를 재사용하며, 동일한 고해상도 그래픽을 반복적으로 임베드하지 않도록 하세요.

이미 그림 프레임에 이미 배치된 래스터 이미지의 경우, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/#compressImage)를 사용하여 선택된 해상도와 자르기 설정에 따라 이미지 데이터를 압축할 수 있습니다. 이는 이미지 컬렉션 관리가 아니라 그림 프레임 처리이므로 관련 서식 작업은 [Picture Frame](/slides/ko/python-java/picture-frame/)을 참고하세요.

### **임베디드와 연결 콘텐츠 선택하기**

임베드하면 모든 이미지 데이터가 파일에 포함되어 프레젠테이션이 휴대 가능해집니다. 연결은 파일 크기를 줄일 수 있지만 외부 종속성을 도입합니다. 해당 종속성이 수용 가능하고 안정적일 때만 연결을 사용하세요.

### **공유 브랜딩 재사용하기**

반복되는 로고, 워터마크 또는 장식 그래픽은 하나의 이미지 리소스를 사용하고 재사용하십시오. 그래픽이 슬라이드 콘텐츠가 아니라 프레젠테이션 디자인에 속한다면 마스터 또는 레이아웃에 배치하여 해당 슬라이드가 자동으로 상속하도록 하세요.

### **SVG 리소스 휴대 가능하게 유지하기**

자체 포함 SVG는 외부 파일이나 네트워크 리소스에 의존하는 SVG보다 이동 및 렌더링이 더 쉽습니다. 가능하면 SVG를 가져오기 전에 필요한 리소스를 임베드하세요. 개별 벡터 요소를 편집해야 할 때만 SVG를 도형으로 변환하세요.

### **현대적인 크로스플랫폼 이미지 API 사용하기**

새 Python via Java 코드에서는 `java.awt.image.BufferedImage` 기반 레거시 공개 API 대신 Aspose.Slides 크로스플랫폼 이미지 객체와 [Images](https://reference.aspose.com/slides/ko/python-java/aspose.slides/images/) API를 사용하세요. 마이그레이션 안내는 [Modern API](/slides/ko/python-java/modern-api/)를 참고하세요.

WMF 및 EMF는 특별한 고려가 필요합니다. 이러한 형식을 크로스플랫폼 이미지 객체를 통해 전달하면, [ImageCollection.addImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagecollection/#addImage)가 메타파일을 래스터 PNG 표현으로 변환한 뒤 삽입합니다. 메타파일 데이터를 보존해야 하는 경우, 스트림 기반 [ImageCollection.addImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagecollection/#addImage) 오버로드를 사용하세요. 스프레드시트 등 다른 제품에서 EMF 콘텐츠를 생성하는 것은 별도의 통합 워크플로이며 본 문서 범위에 포함되지 않습니다.

## **FAQ**

**이미지 컬렉션과 그림 프레임의 차이점은 무엇인가요?**

이미지 컬렉션은 재사용 가능한 이미지 리소스를 저장합니다. 그림 프레임은 이러한 리소스 중 하나를 표시하고 자르기 및 효과와 같은 그림 전용 서식을 제공하는 슬라이드 도형입니다.

**같은 로고를 모든 위치에서 교체하려면 가장 좋은 방법은?**

로고가 하나의 이미지 리소스로 이미 공유되어 있다면 [PPImage.replaceImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#replaceImage)로 해당 리소스를 교체하세요. 프레젠테이션 전체 브랜딩을 위해서는 마스터 또는 레이아웃에 로고를 배치하면 중복된 슬라이드 콘텐츠도 줄일 수 있습니다.

**연결된 이미지가 다른 컴퓨터에서 사라지는 이유는?**

연결된 그림은 외부 파일 또는 URL에 의존합니다. 해당 리소스에 다른 컴퓨터에서 접근할 수 없으면 연결된 이미지가 표시되지 않을 수 있습니다. 프레젠테이션이 독립형이어야 한다면 이미지를 임베드하세요.

**삽입된 SVG를 PowerPoint 도형으로 편집할 수 있나요?**

네. [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addGroupShape)으로 SVG를 변환하면, 결과 그룹은 하나의 SVG 그림이 아니라 편집 가능한 슬라이드 도형을 포함합니다.

**많은 이미지를 포함한 프레젠테이션을 작게 유지하려면 어떻게 해야 하나요?**

공유 이미지 리소스를 재사용하고, 불필요하게 큰 래스터 소스를 피하며, 적절한 경우 래스터 이미지를 압축하고, 반복되는 브랜딩은 마스터나 레이아웃에 두며, 외부 종속성이 허용될 때만 연결된 이미지를 사용하세요.