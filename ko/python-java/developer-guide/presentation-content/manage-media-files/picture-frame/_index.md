---
title: Python을 사용한 프레젠테이션에서 그림 프레임 관리
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/python-java/picture-frame/
keywords:
- 그림 프레임
- 그림 프레임 추가
- 그림 프레임 만들기
- 삽입 이미지
- 연결 이미지
- 이미지 추출
- 래스터 이미지
- SVG 이미지
- 이미지 자르기
- 잘린 영역 삭제
- 이미지 압축
- StretchOffset
- 그림 프레임 서식
- 상대 스케일
- 이미지 효과
- 종횡비
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 프레젠테이션에서 그림 프레임을 생성, 서식 지정, 연결, 자르기, 추출 및 압축합니다."
---
## **개요**

그림 프레임은 이미지를 표시하는 슬라이드 도형입니다. Aspose.Slides에서는 이미지 리소스와 이를 표시하는 도형이 별개의 객체입니다. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)은 [ImageCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagecollection/)을 통해 임베디드 이미지 리소스를 소유하고, [PictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/)은 이미지의 위치, 크기, 선 서식, 회전, 자르기, 그림 효과 및 기타 프레임 수준 설정을 제어합니다.

같은 이미지를 여러 번 표시해야 할 때 이 분리는 유용합니다. 이미지를 프레젠테이션에 한 번 추가하고 반환된 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/)를 보관한 뒤 그림 프레임을 만들 때 해당 이미지 리소스를 사용합니다.

그림 프레임은 PNG 또는 JPEG와 같은 래스터 이미지와 SVG와 같은 벡터 이미지를 포함할 수 있습니다. 또한 프레젠테이션에 이미지 바이트를 저장하지 않고 연결된 이미지를 참조하도록 할 수도 있습니다. 선택에 따라 휴대성, 파일 크기, 추출 및 내보내기 동작이 달라지므로 서식 지정이나 최적화를 적용하기 전에 이미지가 어떻게 저장될지 결정하는 것이 좋습니다.

## **삽입된 이미지 추가 및 서식 지정**

삽입된 이미지의 경우 이미지 데이터를 프레젠테이션에 추가하고 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addPictureFrame)으로 그림 프레임을 생성합니다. 이미지는 프레젠테이션 패키지의 일부가 되므로 프레젠테이션을 다른 컴퓨터로 이동해도 자체 포함된 상태를 유지합니다.

다음 예제는 JPEG 이미지를 추가하고 이미지의 기본 차원으로 프레임을 만든 뒤 선 서식과 회전을 적용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

그림 프레임은 표시되는 기하학을 제어합니다. 프레임 크기를 변경해도 임베디드 이미지 리소스에 저장된 원본 픽셀 차원은 변경되지 않습니다. 이 구분은 나중에 이미지를 자르거나 압축할 때 중요해집니다.

## **상대 크기 사용**

[PictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/)은 [setRelativeScaleWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth)와 [setRelativeScaleHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight)을 통해 프레임의 상대 너비와 높이 스케일을 노출합니다. 값 `1.0`은 원본 그림 크기의 100%에 해당합니다. 상대 스케일은 최종 차원을 수동으로 계산하지 않고 원본 이미지 크기와의 비례 관계를 유지해야 하는 워크플로에 유용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

상대 스케일은 프레임의 스케일 설정을 변경하지만, 임베디드 이미지를 다시 샘플링하거나 압축하지는 않습니다.

## **삽입된 이미지 및 연결된 이미지**

삽입된 그림은 이미지 데이터를 프레젠테이션 내부에 저장하므로 휴대성과 예측 가능한 렌더링을 위한 가장 안전한 선택입니다. 연결된 그림은 이미지 데이터를 임베드하는 대신 [Picture.setLinkPathLong](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picture/#setLinkPathLong) 메서드를 통해 외부 위치를 저장합니다.

연결된 이미지는 PPTX에 저장되는 이미지 데이터 양을 줄일 수 있지만 외부 종속성을 도입합니다. 연결된 파일은 프레젠테이션을 열거나 렌더링하는 애플리케이션이 접근할 수 있어야 합니다. 경로가 변경되거나 파일이 이동되거나 리소스를 사용할 수 없게 되면 연결된 그림이 예상대로 표시되지 않을 수 있습니다. 이메일 전송, 보관 또는 격리된 환경에서 렌더링해야 하는 프레젠테이션의 경우 일반적으로 삽입된 이미지가 더 신뢰할 수 있습니다.

### **연결된 이미지 추가**

다음 예제는 그림 프레임을 만들고 로컬 이미지 파일을 가리키도록 설정합니다. 이 예제는 이미지 연결만 다루며, 비디오 연결은 별도의 미디어 워크플로이며 의도적으로 여기에는 포함되지 않았습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

외부 파일 관리가 의도된 경우에만 링크를 사용하십시오. 압축을 대체하기 위해 링크를 사용하는 것은 피해야 합니다. 깨진 이미지 종속성을 가진 작은 PPTX는 일반적으로 더 큰 자체 포함 프레젠테이션보다 활용도가 낮습니다.

## **그림 프레임에서 이미지 추출**

기존 프레젠테이션에서 이미지를 추출하기 전에 해당 도형이 실제로 [PictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/)인지, 그리고 임베디드 이미지를 포함하고 있는지 확인하십시오. 연결된 그림 프레임은 동일한 방식으로 추출할 수 있는 이미지 바이트를 포함하지 않을 수 있습니다.

### **래스터 이미지 추출**

최신 이미지 API는 래스터 이미지를 직접 처리하며 이전 Java 이미지 래퍼가 필요하지 않습니다. 다음 예제는 슬라이드에서 첫 번째 임베디드 래스터 그림을 찾아 PNG로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

래스터 이미지를 저장하면 추출된 이미지를 요청된 출력 형식으로 변환합니다. 프레젠테이션에 저장된 인코딩된 바이트가 필요하면 이미지 리소스의 이진 데이터를 사용하십시오.

### **SVG 이미지 추출**

SVG 그림의 경우 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/)이 [SvgImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgimage/) 객체를 노출합니다. 이를 통해 먼저 래스터화하지 않고 SVG 데이터를 직접 가져올 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

SVG 내용을 SVG 그대로 유지하면 프레젠테이션 내부에 벡터 소스가 보존됩니다. PNG 또는 JPEG와 같은 래스터 내보내기는 해당 벡터 컨텐츠를 픽셀로 렌더링합니다. PDF 또는 SVG 슬라이드 내보내기도 렌더링 작업이므로, 내보낸 그래픽을 원본 임베디드 SVG와 바이트 단위로 동일하게 취급해서는 안 됩니다. 원본 벡터 리소스가 필요할 때는 임베디드 [SvgImage.getSvgData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgimage/#getSvgData) 데이터를 사용하십시오.

## **이미지 자르기**

자르기는 프레임 내부에서 이미지의 어느 부분이 보이는지를 변경합니다. [PictureFillFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/)의 자르기 값은 원본 이미지 차원의 백분율이며, 초기에는 숨겨진 픽셀을 삭제하지 않고 보이는 영역만 변경합니다.

다음 예제는 그림 프레임을 안전하게 찾아 자르기 값을 적용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

숨겨진 이미지 데이터가 여전히 존재하기 때문에 원본 픽셀을 잃지 않고 나중에 자르기를 변경할 수 있습니다. 파일 크기가 더 중요하고 되돌리기가 필요 없을 경우 다음 섹션에 설명된 대로 잘린 영역을 물리적으로 제거할 수 있습니다.

## **잘린 이미지 데이터 제거**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 메서드는 현재 자르기 사각형 외부의 이미지 데이터를 제거하고 결과 이미지 리소스를 반환합니다. 이는 파일 크기를 줄일 수 있지만 파괴적인 최적화이며, 프레젠테이션을 저장한 뒤에는 제거된 픽셀을 복원할 수 없습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이 메서드는 프레젠테이션에 새로운 이미지 리소스를 추가할 수 있습니다. 원본 이미지가 다른 그림 프레임에서도 사용 중이라면 해당 프레임은 기존 리소스를 계속 사용해야 하므로 잘린 영역을 삭제해도 전체 이미지 수가 반드시 감소하는 것은 아닙니다. WMF 또는 EMF 컨텐츠를 이 메서드로 자를 경우 결과가 PNG로 래스터화됩니다.

## **래스터 이미지 압축**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/#compressImage) 메서드는 그림이 표시되는 크기에 비례하여 래스터 이미지 해상도를 낮춥니다. 같은 작업으로 잘린 영역을 제거할 수도 있습니다. 이미지가 크기가 조정되었거나 잘렸을 경우 `True`를, 변경이 필요 없을 경우 `False`를 반환합니다.

표준 목표 해상도가 충분한 경우 미리 정의된 [PicturesCompression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturescompression/) 값을 사용하십시오:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

특정 목표가 필요한 경우 미리 정의된 값 대신 양의 DPI 값을 직접 전달할 수 있습니다.

압축은 래스터 이미지에만 적용됩니다. SVG 및 메타파일 컨텐츠는 이 래스터 압축 워크플로로 감소되지 않습니다. 또한 낮은 해상도와 삭제된 잘린 영역은 최적화된 프레젠테이션에서 복구할 수 없다는 점을 기억하십시오. 전역적으로 가장 낮은 DPI를 적용하기보다 실제로 볼 또는 내보낼 최대 크기를 기준으로 목표 해상도를 선택하십시오.

## **이미지 변환 효과 관리**

밝기, 대비, 색상 변환, 블러, 알파 효과, 순차 체인, 검사, 제거 및 왕복 검증을 포함한 전체 워크플로는 [Image Transform Effects](/slides/ko/python-java/image-transform-effects/)를 참고하십시오.

## **그림 프레임 기하학 잠금**

[PictureFrameLock](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframelock/) 설정은 그림 프레임에 대해 어떤 편집 작업이 비활성화될지 제어합니다. 예를 들어 [setAspectRatioLocked](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) 은 크기 조정 시 형태의 비율을 유지합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

잠금은 그림 프레임 도형에 적용됩니다. 소스 이미지를 재샘플링하거나 영구적으로 동일한 종횡비로 변경하도록 강제하지는 않습니다.

## **StretchOffset 값 조정**

그림 채우기 모드가 stretch인 경우, [PictureFillFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/)의 stretch‑offset 값은 그림 프레임 경계 상자에 대한 채우기 사각형을 정의합니다. 양의 백분율은 가장자리에서 안쪽으로 삽입을 만들고, 음의 백분율은 바깥쪽으로 확장을 만듭니다.

이는 자르기와 다릅니다. 자르기 값은 원본 이미지의 어느 부분이 보이는지를 선택하고, stretch offset은 보이는 그림 채우기가 늘어나는 사각형을 변경합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

채우기 배치를 위해서는 stretch offset을 사용하고, 원본 이미지 가장자리를 숨기는 것이 목적이라면 자르기 속성을 사용하십시오.

## **스토리지, 파일 크기 및 내보내기 고려 사항**

이미지 저장과 그림 프레임 서식을 별도로 취급할 때 주요 트레이드오프를 관리하기가 더 쉽습니다:

- **삽입된 이미지**는 프레젠테이션을 자체 포함하게 만들며 공유 및 서버‑사이드 렌더링에 가장 신뢰할 수 있습니다. 하지만 큰 래스터 이미지는 PPTX 크기와 메모리 사용량을 증가시킵니다.
- **연결된 이미지**는 패키지 크기를 줄일 수 있지만, 프레젠테이션이 저장된 경로나 위치에 외부 파일이 계속 존재해야 합니다.
- **자르기**는 처음에 비파괴적입니다. 숨겨진 픽셀은 잘린 영역을 명시적으로 삭제하거나 압축 중에 제거하기 전까지는 임베디드된 상태로 남아 있습니다.
- **압축**은 과도한 래스터 이미지의 파일 크기를 크게 줄일 수 있지만, 원본 해상도를 포기합니다. 슬라이드에 표시될 최종 크기가 정해진 이후에 적용해야 합니다.
- **SVG 이미지**는 벡터 보존이 중요할 때 SVG 그대로 유지해야 합니다. 벡터 리소스 자체가 필요하면 임베디드 SVG를 직접 추출하십시오. 래스터 슬라이드 내보내기는 항상 렌더링된 슬라이드를 픽셀로 변환합니다.
- **반복되는 이미지**는 가능한 경우 동일한 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 리소스를 재사용하고, 파일에 동일한 이미지를 여러 번 로드하지 않도록 합니다.

대규모 프레젠테이션의 경우 이미지 최적화는 선택적으로 수행할 때 가장 효과적입니다. 로고와 다이어그램은 벡터 콘텐츠로 유지하고, 사진은 실제 표시 크기에 따라 압축하며, 나중에 편집이 필요하지 않을 경우에만 잘린 픽셀을 제거하고, 외부 링크는 의존성 관리가 배포 설계의 일부가 아닌 한 피하십시오.

## **FAQ**

**그림 프레임과 이미지 리소스의 차이점은 무엇입니까?**

[PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/)는 프레젠테이션에 연결된 이미지 리소스를 나타냅니다. [PictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/)은 슬라이드에 배치된 도형으로, 이미지와 프레임 수준의 기하학 및 서식(크기, 회전, 자르기 값, 효과, 잠금 등)을 저장합니다.

**이미지를 삽입해야 하나요, 아니면 연결해야 하나요?**

프레젠테이션을 휴대 가능하게 하거나 보관·외부 리소스 없이 렌더링해야 할 경우 이미지를 삽입하십시오. 이미지 파일을 PPTX 외부에 두고 외부 위치를 안정적으로 유지할 수 있는 경우에만 연결을 사용하십시오.

**크롭이 PPTX 파일 크기를 줄입니까?**

단독으로는 줄어들지 않습니다. 일반적인 크롭 설정은 원본 이미지의 일부를 숨기지만 기본 픽셀은 유지합니다. 픽셀을 영구적으로 제거하려면 [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 를 사용하거나 잘린 영역을 포함한 이미지 압축을 수행하십시오.

**압축 후 이미지 품질을 복원할 수 있습니까?**

불가능합니다. 압축은 저장된 래스터 해상도를 낮추고, 잘린 영역을 제거하면 이미지 데이터가 사라집니다. 향후 고해상도 편집이 필요할 경우 원본 이미지를 프레젠테이션 외부에 보관하십시오.

**SVG 이미지는 어떻게 처리해야 합니까?**

벡터 정확도가 중요하면 SVG 내용을 SVG 그대로 유지하십시오. 임베디드 [SvgImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgimage/)를 직접 추출할 수 있습니다. 슬라이드를 PNG나 JPEG와 같은 래스터 형식으로 내보내면 SVG가 픽셀로 raster화됩니다.

**기존 슬라이드를 읽을 때 안전하지 않은 캐스트를 어떻게 피할 수 있습니까?**

도형 유형을 확인한 뒤 그림 프레임 전용 멤버를 사용하십시오. `[shape] instanceof PictureFrame` 와 같은 `isinstance` 검사를 수행하면 잘못된 캐스트를 방지하고 그림 프레임이 포함되지 않은 슬라이드를 안전하게 처리할 수 있습니다.