---
title: Python via Java로 프레젠테이션 도형에서 이미지 추출
linktitle: 도형의 이미지
type: docs
weight: 100
url: /ko/python-java/extracting-images-from-presentation-shapes/
keywords:
- 이미지 추출
- 이미지 가져오기
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 도형에서 이미지를 추출합니다 - 빠르고 코드 친화적인 솔루션."
---
## **개요**

프레젠테이션의 이미지는 여러 형태 유형으로 나타날 수 있습니다: 일반 사진 프레임, 도형에 적용된 사진 채우기, OLE 개체 미리보기 이미지, 비디오 또는 오디오 프레임 썸네일, 줌 이미지, 또는 표, 차트 및 SmartArt 도형 내부에 중첩된 이미지 등. Aspose.Slides는 이러한 이미지를 프레젠테이션 이미지 컬렉션에 저장하며, 이는 [ImageCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagecollection/) 및 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 객체를 통해 노출됩니다.

프레젠테이션에 포함된 모든 이미지 리소스를 내보내기만 하면 된다면 [Presentation.getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages)를 순회하십시오. 이 문서는 다른 작업에 중점을 둡니다: 슬라이드에서 이미지가 사용된 위치를 찾기 위해 도형을 탐색하고, 저장된 파일이 슬라이드 번호, 도형 위치 및 소스 유형(사진 프레임, 채우기 이미지, 미디어 미리보기, OLE 미리보기 또는 줌 이미지)과 같은 유용한 컨텍스트를 유지하도록 합니다.

{{% alert title="Tip" color="success" %}}
[PPImage.getBinaryData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#getBinaryData)를 사용하면 원본 인코딩된 이미지 데이터와 파일 유형을 보존할 수 있습니다. `save`와 함께 [PPImage.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#getImage)를 사용하면 PNG와 같은 특정 형식으로 출력을 정규화할 수 있습니다.
{{% /alert %}}

## **공유 헬퍼 함수**

아래 공유 헬퍼 함수를 예제 스크립트와 같은 폴더에 `image_helpers.py`로 저장하십시오. 예제를 간결하게 유지합니다. `save_original_image`는 원본 임베디드 바이트를 기록하고, MIME 유형에서 안전한 확장자를 선택하며, SHA-256 해시로 중복 이미지 바이너리를 건너뜁니다.

```python
from pathlib import Path
import hashlib
import re

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GroupShape, ImageFormat


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.getBinaryData())
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False
    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.getContentType())
    output_file = Path(output_directory) / f"{file_name_base}.{extension}"
    output_file.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    output_file = Path(output_directory) / f"{file_name_base}.png"
    output_image = image.getImage()
    try:
        output_image.save(str(output_file), ImageFormat.Png)
    finally:
        output_image.dispose()


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.getFillType() != FillType.Picture:
        return None
    return fill_format.getPictureFillFormat().getPicture().getImage()


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    shape_references = []
    for shape_index in range(shapes.size()):
        shape = shapes.get_Item(shape_index)
        shape_name_part = f"{prefix}_shape_{shape_index + 1}"
        shape_references.append((shape, shape_name_part))
        if include_grouped_shapes and isinstance(shape, GroupShape):
            child_shapes = shape.getShapes()
            child_references = enumerate_shapes(child_shapes, shape_name_part, include_grouped_shapes)
            shape_references.extend(child_references)
    return shape_references


def get_extension_from_content_type(content_type):
    if content_type is None or not str(content_type).strip():
        return "bin"
    media_type = str(content_type).split(";")[0].strip().lower()
    extensions = {
        "image/jpeg": "jpg",
        "image/png": "png",
        "image/gif": "gif",
        "image/bmp": "bmp",
        "image/tiff": "tiff",
        "image/x-emf": "emf",
        "image/emf": "emf",
        "image/x-wmf": "wmf",
        "image/wmf": "wmf",
        "image/svg+xml": "svg",
    }
    if media_type in extensions:
        return extensions[media_type]
    if media_type.startswith("image/"):
        return re.sub(r"[^A-Za-z0-9._-]", "_", media_type[len("image/"):])
    return "bin"
```

## **사진 프레임에서 이미지 추출**

독립 객체로 삽입된 사진에 대해 이 방법을 사용하십시오. [PictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/)은 [getPictureFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/#getPicture) 및 [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picture/#getImage)를 통해 사진에 접근할 수 있으며, 이는 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 객체를 반환합니다.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, PictureFrame):
                picture_frame = shape
                image = picture_frame.getPictureFormat().getPicture().getImage()
                save_original_image(image, output_directory, name_part, saved_image_hashes)
finally:
    presentation.dispose()
```

## **사진 채워진 도형에서 이미지 추출**

도형은 사진을 채우기로 사용할 수 있습니다. 먼저 도형의 채우기 유형을 확인하십시오: [FillType.Picture](https://reference.aspose.com/slides/ko/python-java/aspose.slides/filltype/)이 아니면 해당 채우기에서 추출할 사진이 없습니다. 아래 예제는 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 객체를 처리하고, 각 이미지를 [PPImage.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#getImage)를 사용해 PNG로 저장합니다.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, AutoShape):
                auto_shape = shape
                fill_format = auto_shape.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
finally:
    presentation.dispose()
```

## **OLE 개체 프레임에서 미리보기 이미지 추출**

[OleObjectFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/)는 PowerPoint가 슬라이드에서 개체의 미리보기로 사용하는 대체 사진을 가질 수 있습니다. 이 이미지는 [getSubstitutePictureFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/#getPicture) 및 [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picture/#getImage)를 통해 제공됩니다. 이 사진을 추출하면 OLE 패키지 내용이 아니라 미리보기 이미지를 얻습니다.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, OleObjectFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, OleObjectFrame):
                ole_object_frame = shape
                image = ole_object_frame.getSubstitutePictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **비디오 프레임에서 미리보기 이미지 추출**

[VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/)도 [getPictureFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/#getPicture) 및 [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picture/#getImage)를 통해 미리보기 이미지를 저장할 수 있습니다. 이는 슬라이드에 표시되는 포스터 또는 썸네일이며, 비디오 스트림에서 디코딩된 프레임이 아닙니다.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, VideoFrame):
                video_frame = shape
                image = video_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **오디오 프레임에서 미리보기 이미지 추출**

[AudioFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/audioframe/)는 [getPictureFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/#getPicture) 및 [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picture/#getImage)를 통해 썸네일을 저장할 수 있습니다. 이는 슬라이드에 표시되는 오디오 객체의 이미지입니다.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AudioFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, AudioFrame):
                audio_frame = shape
                image = audio_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **줌 개체에서 이미지 추출**

[ZoomFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/zoomframe/) 및 [SectionZoomFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sectionzoomframe/) 도형은 사용자 지정 이미지를 사용할 수 있습니다. 줌 프레임에서 [getZoomImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/zoomobject/#getZoomImage)를 읽어오십시오.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SectionZoomFrame, ZoomFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, ZoomFrame):
                zoom_frame = shape
                image = zoom_frame.getZoomImage()
                if image is not None:
                    file_name_base = name_part + "_zoom"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                    continue
            if isinstance(shape, SectionZoomFrame):
                section_zoom_frame = shape
                image = section_zoom_frame.getZoomImage()
                if image is not None:
                    file_name_base = name_part + "_section_zoom"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                    continue
finally:
    presentation.dispose()
```

## **요약 줌 프레임에서 이미지 추출**

[SummaryZoomFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/summaryzoomframe/)도 도형입니다. 해당 섹션 항목은 각 요약 줌 섹션의 [getZoomImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/zoomobject/#getZoomImage) 메서드를 통해 사용자 지정 이미지를 제공할 수 있습니다.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SummaryZoomFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, SummaryZoomFrame):
                summary_zoom_frame = shape
                section_count = summary_zoom_frame.getSummaryZoomCollection().size()
                for section_index in range(section_count):
                    section = summary_zoom_frame.getSummaryZoomCollection().get_Item(section_index)
                    image = section.getZoomImage()
                    if image is not None:
                        display_index = section_index + 1
                        file_name_base = name_part + "_summary_zoom_" + str(display_index)
                        save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **표 도형에서 이미지 추출**

[Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/)은 도형입니다. 표에 포함된 이미지는 일반적으로 셀의 사진 채우기로 저장됩니다.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, Table):
                table = shape
                row_count = table.getRows().size()
                column_count = table.getColumns().size()
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = table.get_Item(column_index, row_index)
                        fill_format = cell.getCellFormat().getFillFormat()
                        image = get_picture_fill_image(fill_format)
                        if image is not None:
                            display_row = row_index + 1
                            display_column = column_index + 1
                            file_name_base = name_part + "_cell_" + str(display_row) + "_" + str(display_column)
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **차트 도형에서 이미지 추출**

[Chart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/)은 도형입니다. 아래 예제는 차트 영역 사진 채우기에서 이미지를 추출합니다.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, Chart):
                chart = shape
                fill_format = chart.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = name_part + "_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **SmartArt 도형에서 이미지 추출**

[SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 객체는 도형입니다. SmartArt 레이아웃에 따라 이미지는 노드 글머리표 채우기 또는 노드 도형의 채우기 형식에 저장될 수 있습니다.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, SmartArt):
                smart_art = shape
                node_count = smart_art.getAllNodes().size()
                for node_index in range(node_count):
                    node = smart_art.getAllNodes().get_Item(node_index)
                    bullet_fill_format = node.getBulletFillFormat()
                    bullet_image = get_picture_fill_image(bullet_fill_format)
                    if bullet_image is not None:
                        display_node = node_index + 1
                        file_name_base = name_part + "_smartart_node_" + str(display_node) + "_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)
                    node_shape_count = node.getShapes().size()
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.getShapes().get_Item(node_shape_index)
                        fill_format = node_shape.getFillFormat()
                        image = get_picture_fill_image(fill_format)
                        if image is not None:
                            display_node = node_index + 1
                            display_node_shape = node_shape_index + 1
                            file_name_base = name_part + "_smartart_node_" + str(display_node) + "_shape_" + str(display_node_shape)
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **그룹화된 도형 내부 이미지 포함**

그룹화된 도형은 자체 도형 컬렉션을 포함합니다. 공유 `enumerate_shapes` 헬퍼에는 `include_grouped_shapes` 옵션이 있습니다. [GroupShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/groupshape/) 객체 내부의 도형을 검사하려면 이를 `True`로 설정하십시오. 아래 예제는 사진 프레임, 사진 채워진 도형, OLE 개체 미리보기, 비디오 프레임 썸네일 및 오디오 프레임 썸네일에서 이미지를 추출합니다. 표, 차트, SmartArt 및 요약 줌 이미지까지 포함하려면 이전 섹션의 특수 추출 로직을 재사용하면서 동일한 재귀 도형 순회를 유지하십시오.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AudioFrame, AutoShape, OleObjectFrame, PictureFrame, VideoFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, OleObjectFrame):
                ole_object_frame = shape
                image = ole_object_frame.getSubstitutePictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, VideoFrame):
                video_frame = shape
                image = video_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, AudioFrame):
                audio_frame = shape
                image = audio_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, PictureFrame):
                picture_frame = shape
                image = picture_frame.getPictureFormat().getPicture().getImage()
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue
            if isinstance(shape, AutoShape):
                auto_shape = shape
                fill_format = auto_shape.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
finally:
    presentation.dispose()
```

## **경우별 상황 및 실용적인 참고 사항**

- **중복 이미지:** 여러 도형이 동일한 이미지를 참조하거나 바이트가 동일한 별도 이미지를 가질 수 있습니다. 고유 이미지당 하나의 출력 파일만 원한다면 파일을 쓰기 전에 [PPImage.getBinaryData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#getBinaryData)를 해시하십시오.
- **원본 데이터 vs. 변환된 출력:** [PPImage.getBinaryData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#getBinaryData)를 저장하면 임베디드 JPEG, PNG, GIF, SVG, EMF 또는 WMF 데이터를 보존합니다. `save`와 함께 [PPImage.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#getImage)를 사용하면 일관된 출력 형식(PNG 등)으로 변환할 수 있습니다.
- **지원되지 않는 채우기 유형:** 단색, 그라디언트, 패턴 및 무채우기 도형에는 사진 채우기가 포함되지 않습니다. [FillType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/filltype/)을 확인한 뒤 [getPictureFillFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fillformat/#getPictureFillFormat)를 읽으십시오.
- **그룹화된 도형:** 최상위 슬라이드 도형 컬렉션은 그룹을 평탄화하지 않습니다. 그룹화된 콘텐츠가 중요한 경우 [GroupShape.getShapes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/groupshape/#getShapes)를 재귀적으로 검사하십시오.
- **OLE 개체 미리보기:** [OleObjectFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/)는 [getSubstitutePictureFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)를 통해 미리보기 이미지를 제공할 수 있지만, 이는 슬라이드 미리보기일 뿐 OLE 개체 내부에 포함된 파일은 아닙니다.
- **비디오 프레임 썸네일:** [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/)는 [getPictureFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/#getPictureFormat)를 통해 미리보기 이미지를 제공할 수 있습니다. 이는 슬라이드에 표시되는 포스터이며 비디오 스트림에서 추출된 프레임이 아닙니다.
- **오디오 프레임 썸네일:** [AudioFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/audioframe/)는 [getPictureFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/#getPictureFormat)를 통해 아이콘 또는 썸네일을 제공할 수 있지만, 이는 임베디드 오디오 데이터가 아닙니다.
- **줌 이미지:** 슬라이드 줌, 섹션 줌 및 요약 줌 도형은 [getZoomImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/zoomobject/#getZoomImage)를 통해 사용자 지정 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 객체를 사용할 수 있습니다.
- **중첩 도형 모델:** 표, 차트 및 SmartArt 객체는 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/)을 구현하지만, 이미지가 종종 중첩된 셀, 차트 요소 또는 SmartArt 노드 형식 객체에 저장됩니다.
- **잘라내기 또는 변형된 사진:** [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/)에 접근하면 저장된 이미지 리소스를 얻을 수 있지만, 도형이 적용한 자르기, 투명도, 색상 재조정, 회전 또는 기타 시각 효과는 렌더링되지 않습니다.

## **FAQ**

**이미지를 원본 그대로 추출할 수 있나요? (자르기, 효과, 도형 변형 없이)**  

예. [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 객체에 접근하고 [PPImage.getBinaryData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#getBinaryData)를 디스크에 기록하면 프레젠테이션에 저장된 원본 인코딩 이미지가 보존됩니다. 이는 슬라이드에 렌더링되는 방식과는 무관합니다.

**추출된 모든 이미지를 PNG로 내보낼 수 있나요?**  

예. [PPImage.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#getImage)로 이미지 객체를 얻은 뒤 `save`와 함께 [ImageFormat.Png](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imageformat/)을 호출하면 PNG로 변환됩니다. 이 경우 원본 파일 형식이나 벡터 데이터가 보존되지 않을 수 있습니다.

**같은 이미지를 여러 번 저장하지 않으려면 어떻게 해야 하나요?**  

[PPImage.getBinaryData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#getBinaryData)의 해시를 구해 집합에 보관하십시오. 새 이미지의 해시가 이미 존재하면 해당 이미지를 건너뛰거나 기존 출력 파일에 대한 다른 참조만 기록하면 됩니다.

**왜 일부 도형에서는 이미지가 생성되지 않나요?**  

사진 프레임, 사진 채워진 도형, OLE 개체 프레임, 미디어 프레임, 줌 프레임, 표, 차트 및 SmartArt 객체는 이미지를 참조할 수 있습니다. 그러나 일부 도형 유형은 중첩 형식 객체를 통해 이미지를 제공하므로 간단히 [getPictureFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/#getPictureFormat)이나 도형 [getFillFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getFillFormat)만 확인해도 충분하지 않을 수 있습니다.

**비디오 프레임에 표시되는 썸네일을 추출할 수 있나요?**  

예. [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/)에서 [getPictureFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/#getPicture) 및 [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picture/#getImage)를 읽으면 비디오 프레임과 함께 저장된 포스터 이미지가 추출됩니다. 이는 비디오 파일에서 생성된 프레임이 아닙니다.

**프레젠테이션 이미지 컬렉션에서 특정 이미지를 사용하는 도형을 어떻게 확인할 수 있나요?**  

Aspose.Slides는 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/)에서 도형으로의 역링크를 저장하지 않습니다. 순회하면서 이미지 참조를 발견할 때마다 슬라이드 번호, 도형 경로 및 이미지 해시 또는 컬렉션 항목을 기록하여 매핑을 구축하십시오.

**첨부 문서와 같은 OLE 개체 내부에 포함된 이미지를 추출할 수 있나요?**  

[OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)를 사용하면 OLE 개체의 슬라이드 미리보기 이미지를 추출할 수 있습니다. 그러나 이 미리보기는 실제 임베디드 문서 자체가 아니며, 내부 파일에서 이미지를 추출하려면 OLE 데이터를 추출한 뒤 해당 파일 형식에 맞는 도구로 검사해야 합니다.