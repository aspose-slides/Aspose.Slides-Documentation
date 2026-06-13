---
title: Python에서 프레젠테이션 도형의 이미지 추출
linktitle: 도형의 이미지
type: docs
weight: 90
url: /ko/python-net/extracting-images-from-presentation-shapes/
keywords:
- 이미지 추출
- 이미지 가져오기
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 도형에서 이미지를 추출합니다 - 빠르고 코드 친화적인 솔루션."
---
## **개요**

프레젠테이션의 이미지들은 여러 형태 유형으로 나타날 수 있습니다: 일반 사진 프레임, 도형에 적용된 사진 채우기, OLE 개체 미리보기 이미지, 비디오 또는 오디오 프레임 썸네일, 줌 이미지, 혹은 표, 차트 및 SmartArt 도형 안에 중첩된 이미지 등입니다. Aspose.Slides는 이러한 이미지들을 프레젠테이션 이미지 컬렉션에 저장하며, 이는 [ImageCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/) 및 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/) 객체를 통해 노출됩니다.

프레젠테이션에 포함된 모든 이미지 리소스를 내보내기만 하면 된다면 `presentation.images`를 반복하면 됩니다. 이 문서는 다른 작업에 초점을 맞춥니다: 슬라이드에서 이미지가 사용된 위치를 찾기 위해 도형을 탐색하여 저장된 파일에 슬라이드 번호, 도형 위치 및 원본 유형(사진 프레임, 채우기 이미지, 미디어 미리보기, OLE 미리보기 또는 줌 이미지)과 같은 유용한 컨텍스트를 유지할 수 있도록 합니다.

{{% alert title="Tip" color="primary" %}}
`binary_data` 속성을 사용하면 원본 인코딩된 이미지 데이터와 파일 형식을 유지할 수 있습니다. PNG와 같은 특정 형식으로 출력을 정규화하려면 `save`와 함께 `image` 속성을 사용하십시오.
{{% /alert %}}

## **공유 헬퍼 메서드**

아래 헬퍼 메서드는 예제를 간결하게 유지합니다. `save_original_image`는 원본 임베드된 바이트를 기록하고, MIME 유형에서 안전한 확장자를 선택하며, SHA-256 해시를 사용해 중복 이미지 바이너리를 건너뜁니다.

```py
import hashlib
import re
from pathlib import Path

import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.smartart as smartart


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.binary_data)
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False

    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.content_type)
    file_name = f"{file_name_base}.{extension}"
    output_path = Path(output_directory) / file_name
    output_path.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    file_name = f"{file_name_base}.png"
    output_path = Path(output_directory) / file_name
    image.image.save(str(output_path), slides.ImageFormat.PNG)


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.fill_type != slides.FillType.PICTURE:
        return None

    return fill_format.picture_fill_format.picture.image


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    for shape_index, shape in enumerate(shapes, start=1):
        shape_name_part = f"{prefix}_shape_{shape_index}"
        yield shape, shape_name_part

        if include_grouped_shapes and isinstance(shape, slides.GroupShape):
            yield from enumerate_shapes(
                shape.shapes,
                shape_name_part,
                include_grouped_shapes)


def get_extension_from_content_type(content_type):
    if not content_type:
        return "bin"

    media_type = content_type.split(";")[0].strip().lower()
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
        extension = media_type[len("image/"):]
        return make_safe_file_name_part(extension)

    return "bin"


def make_safe_file_name_part(value):
    return re.sub(r'[<>:"/\\|?*]', "_", value)
```

## **그림 프레임에서 이미지 추출**

독립 객체로 삽입된 그림에 이 접근 방식을 사용하십시오. [PictureFrame]은 그림을 `picture_format.picture.image`에 저장하며, 이는 [PPImage] 객체를 반환합니다.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **그림으로 채워진 도형에서 이미지 추출**

도형은 그림을 채우기로 사용할 수 있습니다. 먼저 도형의 채우기 유형을 확인하십시오: [FillType.PICTURE]가 아니면 해당 채우기에서 추출할 그림이 없습니다. 아래 예제는 [AutoShape] 객체를 처리하고, [PPImage]의 `image` 속성을 사용해 각 이미지를 PNG로 저장합니다.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
```

## **OLE 개체 프레임에서 미리보기 이미지 추출**

[OleObjectFrame]은 PowerPoint가 슬라이드에서 개체의 미리보기로 사용하는 대체 그림을 가질 수 있습니다. 이 이미지는 `substitute_picture_format.picture.image`를 통해 얻을 수 있습니다. 이 그림을 추출하면 임베드된 OLE 패키지 내용이 아니라 미리보기 이미지가 제공됩니다.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **비디오 프레임에서 미리보기 이미지 추출**

[VideoFrame]도 `picture_format.picture.image`에 미리보기 이미지를 저장할 수 있습니다. 이는 슬라이드에 표시되는 포스터 또는 썸네일이며, 비디오 스트림에서 디코딩된 프레임이 아닙니다.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **오디오 프레임에서 미리보기 이미지 추출**

[AudioFrame]은 `picture_format.picture.image`에 썸네일을 저장할 수 있습니다. 이는 슬라이드에 표시되는 오디오 개체의 이미지입니다.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **줌 개체에서 이미지 추출**

[ZoomFrame] 및 [SectionZoomFrame] 도형은 사용자 지정 이미지를 사용할 수 있습니다. 줌 프레임에서 `zoom_image`를 읽으십시오.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.ZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue

            if isinstance(shape, slides.SectionZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_section_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue
```

## **요약 줌 프레임에서 이미지 추출**

[SummaryZoomFrame]도 도형입니다. 해당 섹션 항목들은 사용자 지정 이미지를 사용할 수 있으며, 각 요약 줌 섹션의 `zoom_image` 속성을 통해 노출됩니다.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.SummaryZoomFrame):
                section_count = len(shape.summary_zoom_collection)
                for section_index in range(section_count):
                    section = shape.summary_zoom_collection[section_index]
                    if section.zoom_image is not None:
                        display_index = section_index + 1
                        file_name_base = f"{name_part}_summary_zoom_{display_index}"
                        save_original_image(section.zoom_image, output_directory, file_name_base, saved_image_hashes)
```

## **표 도형에서 이미지 추출**

[Table]은 도형입니다. 표에 있는 이미지는 일반적으로 표 셀의 그림 채우기로 저장됩니다.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.Table):
                row_count = len(shape.rows)
                column_count = len(shape.columns)
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = shape.rows[row_index][column_index]
                        image = get_picture_fill_image(cell.cell_format.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_cell_{row_index + 1}_{column_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **차트 도형에서 이미지 추출**

[Chart]은 도형입니다. 아래 예제는 차트 영역 그림 채우기에서 이미지를 추출합니다.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, charts.Chart):
                fill_format = shape.fill_format
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = f"{name_part}_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **SmartArt 도형에서 이미지 추출**

[SmartArt] 객체는 도형입니다. SmartArt 레이아웃에 따라 이미지는 노드 글머리표 채우기 또는 노드 도형의 채우기 형식에 저장될 수 있습니다.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, smartart.SmartArt):
                node_count = len(shape.all_nodes)
                for node_index in range(node_count):
                    node = shape.all_nodes[node_index]
                    bullet_image = get_picture_fill_image(node.bullet_fill_format)
                    if bullet_image is not None:
                        file_name_base = f"{name_part}_smartart_node_{node_index + 1}_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)

                    node_shape_count = len(node.shapes)
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.shapes[node_shape_index]
                        image = get_picture_fill_image(node_shape.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_smartart_node_{node_index + 1}_shape_{node_shape_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **그룹화된 도형 내부 이미지 포함**

그룹화된 도형은 자체 도형 컬렉션을 포함합니다. 공유된 `enumerate_shapes` 헬퍼에는 `include_grouped_shapes` 옵션이 있습니다. [GroupShape] 객체 내부의 도형을 검사하려면 이를 `True`로 설정하십시오. 아래 예제는 그림 프레임, 그림으로 채워진 도형, OLE 개체 미리보기, 비디오 프레임 썸네일 및 오디오 프레임 썸네일에서 이미지를 추출합니다. 표, 차트, SmartArt 및 요약 줌 이미지도 포함하려면 이전 섹션의 특수 추출 로직을 재사용하면서 동일한 재귀 도형 순회를 유지하십시오.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue

            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **예외 상황 및 실용적인 주의사항**

- **중복 이미지:** 여러 도형이 동일한 이미지를 참조하거나 바이트가 동일한 별개의 이미지를 가질 수 있습니다. 고유 이미지당 하나의 출력 파일을 원한다면 파일을 쓰기 전에 [PPImage]의 `binary_data` 속성을 해시하십시오.
- **원본 데이터 vs. 변환된 출력:** [PPImage]의 `binary_data` 속성을 저장하면 임베드된 JPEG, PNG, GIF, SVG, EMF 또는 WMF 데이터가 보존됩니다. `save`를 통해 `image` 속성을 저장하면 일관된 출력 형식이 필요할 때 유용합니다.
- **지원되지 않는 채우기 유형:** 단색, 그라디언트, 패턴 및 무채움 도형은 그림 채우기를 포함하지 않습니다. `picture_fill_format`을 읽기 전에 [FillType]을 확인하십시오.
- **그룹화된 도형:** 최상위 슬라이드 도형 컬렉션은 그룹을 평탄화하지 않습니다. 그룹화된 콘텐츠가 중요할 경우 [GroupShape.shapes]를 재귀적으로 검사하십시오.
- **OLE 개체 미리보기:** [OleObjectFrame]은 `substitute_picture_format`을 통해 미리보기 이미지를 제공할 수 있지만, 해당 이미지는 슬라이드 미리보기일 뿐이며 OLE 개체 내부에 임베드된 파일은 아닙니다.
- **비디오 프레임 썸네일:** [VideoFrame]은 `picture_format`을 통해 미리보기 이미지를 제공할 수 있지만, 그 이미지는 슬라이드에 표시되는 포스터일 뿐이며 비디오 스트림에서 추출된 것이 아닙니다.
- **오디오 프레임 썸네일:** [AudioFrame]은 `picture_format`을 통해 아이콘이나 썸네일을 제공할 수 있지만, 이는 임베드된 오디오 데이터가 아닙니다.
- **줌 이미지:** 슬라이드 줌, 섹션 줌 및 요약 줌 도형은 `image`를 통해 사용자 지정 [PPImage] 객체를 사용할 수 있습니다.
- **중첩 도형 모델:** 표, 차트 및 SmartArt 객체는 [Shape]을 구현하지만, 해당 이미지들은 종종 중첩된 표 셀, 차트 요소 또는 SmartArt 노드 서식 객체에 저장됩니다.
- **잘라내기 또는 변환된 그림:** [PPImage]에 접근하면 저장된 이미지 리소스를 얻을 수 있지만, 도형에 적용된 자르기, 투명도, 색상 재조정, 회전 또는 기타 시각 효과는 렌더링되지 않습니다.

## **FAQ**

**이미지를 자르기, 효과, 도형 변환 없이 원본 그대로 추출할 수 있나요?**

네. [PPImage] 객체에 접근하여 `binary_data` 속성을 디스크에 기록하십시오. 이렇게 하면 프레젠테이션에 저장된 원본 인코딩 이미지가 보존되며, 슬라이드에서 이미지가 렌더링되는 방식은 반영되지 않습니다.

**추출한 모든 이미지를 PNG로 내보낼 수 있나요?**

네. [PPImage]의 `image` 속성을 사용해 이미지 객체를 얻은 뒤, [ImageFormat.PNG]와 함께 `save`를 호출하십시오. 이는 출력이 변환되며 원본 파일 형식이나 벡터 데이터가 보존되지 않을 수 있습니다.

**같은 이미지를 여러 번 저장하는 것을 방지하려면 어떻게 해야 하나요?**

[PPImage]의 `binary_data` 속성 해시를 사용하고 해시를 집합에 보관하십시오. 새로운 이미지의 해시가 이미 존재한다면 해당 이미지를 건너뛰거나 기존 출력 파일에 대한 또 다른 참조를 기록하십시오.

**왜 일부 도형에서는 이미지가 생성되지 않나요?**

그림 프레임, 그림으로 채워진 도형, OLE 개체 프레임, 미디어 프레임, 줌 프레임, 표, 차트 및 SmartArt 객체는 이미지를 참조할 수 있습니다. 일부 도형 유형은 중첩된 서식 객체를 통해 이미지를 노출하므로 단순히 `picture_format` 또는 도형 `fill_format`을 확인하는 것만으로는 충분하지 않을 때가 있습니다.

**비디오 프레임에 표시되는 썸네일을 추출할 수 있나요?**

네. [VideoFrame]을 사용하고 `picture_format.picture.image`를 읽으십시오. 이는 비디오 프레임에 저장된 포스터 이미지를 추출하며, 비디오 파일에서 생성된 프레임이 아닙니다.

**프레젠테이션 이미지 컬렉션의 특정 이미지가 어떤 도형에서 사용되는지 어떻게 알 수 있나요?**

Aspose.Slides는 [PPImage]에서 도형으로의 역링크를 저장하지 않습니다. 탐색 중에 매핑을 구축하십시오: 이미지 참조를 찾을 때마다 슬라이드 번호, 도형 경로 및 이미지 해시 또는 컬렉션 항목을 기록하십시오.

**OLE 개체 내부에 포함된 이미지(예: 첨부 문서)를 추출할 수 있나요?**

[OleObjectFrame]의 `substitute_picture_format` 속성을 통해 OLE 개체의 슬라이드 미리보기를 추출할 수 있습니다. 그러나 해당 미리보기는 임베드된 문서 자체가 아닙니다. 임베드된 파일 내부의 이미지를 추출하려면 OLE 데이터를 추출한 뒤 해당 파일 유형에 맞는 도구로 검사하십시오.