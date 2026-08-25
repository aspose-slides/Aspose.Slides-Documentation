---
title: 프레젠테이션에서 Python으로 사진 프레임 관리
linktitle: 사진 프레임
type: docs
weight: 10
url: /ko/python-net/picture-frame/
keywords:
- 사진 프레임
- 사진 프레임 추가
- 사진 프레임 만들기
- 내장 이미지
- 연결 이미지
- 이미지 추출
- 래스터 이미지
- SVG 이미지
- 이미지 자르기
- 잘라낸 영역 삭제
- 이미지 압축
- StretchOffset
- 사진 프레임 서식 지정
- 상대 스케일
- 이미지 효과
- 종횡비
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 프레젠테이션에서 사진 프레임을 만들고, 서식 지정하고, 연결하고, 자르고, 추출하고, 압축합니다."
---
## **개요**

Picture frame 은 이미지를 표시하는 슬라이드 도형입니다. Aspose.Slides에서는 이미지 리소스와 이를 표시하는 도형이 별개의 객체입니다: [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 은 [ImageCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/) 를 통해 포함된 이미지 리소스를 소유하고, [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/) 은 이미지의 위치, 크기, 선 서식, 회전, 자르기, 그림 효과 및 기타 프레임 수준 설정을 제어합니다.

같은 이미지를 여러 번 표시해야 할 때 이 분리는 유용합니다. 이미지를 프레젠테이션에 한 번 추가하고 반환된 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/) 를 유지한 다음, 사진 프레임을 만들 때 해당 이미지 리소스를 사용합니다.

Picture frame 은 PNG 또는 JPEG와 같은 래스터 이미지와 SVG와 같은 벡터 이미지를 모두 포함할 수 있습니다. 또한 프레젠테이션에 이미지 바이트를 저장하는 대신 연결된 이미지를 참조하도록 할 수도 있습니다. 선택은 이동성, 파일 크기, 추출 및 내보내기 동작에 영향을 미치므로, 서식 지정이나 최적화를 적용하기 전에 이미지가 어떻게 저장될지 결정하는 것이 유용합니다.

## **내장 이미지 추가 및 서식 지정**

내장 이미지의 경우 이미지 데이터를 프레젠테이션에 추가하고 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_picture_frame/) 으로 사진 프레임을 만듭니다. 이미지가 프레젠테이션 패키지의 일부가 되므로 프레젠테이션을 다른 컴퓨터로 이동해도 자체 포함됩니다.

다음 예제는 JPEG 이미지를 추가하고, 이미지의 원본 크기로 프레임을 만들며, 선 서식과 회전을 적용합니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Picture frame 은 표시되는 기하학을 제어합니다; 프레임 크기를 변경해도 내장 이미지 리소스에 저장된 원래 픽셀 차원은 변경되지 않습니다. 이 구분은 나중에 이미지를 자르거나 압축할 때 중요해집니다.

## **상대 스케일 사용**

[PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/) 은 프레임에 대한 [relative_scale_width](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/relative_scale_width/) 과 [relative_scale_height](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/relative_scale_height/) 를 노출합니다. 값 `1.0` 은 원본 사진 크기의 100%에 해당합니다. 상대 스케일은 최종 차원을 수동으로 계산하는 대신 원본 이미지 크기와의 관계를 유지해야 할 때 유용합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

상대 스케일은 프레임의 스케일 설정만 변경하며, 내장 이미지를 재샘플링하거나 압축하지는 않습니다.

## **내장 이미지와 연결 이미지**

내장 사진은 이미지 데이터를 프레젠테이션 내부에 저장하므로 이동성과 예측 가능한 렌더링을 위해 가장 안전한 선택입니다. 연결 사진은 이미지 데이터를 동일한 방식으로 포함하는 대신 [Picture](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picture/) 링크 경로를 통해 외부 위치를 저장합니다.

연결 이미지 는 PPTX에 저장되는 이미지 데이터 양을 줄일 수 있지만 외부 의존성을 도입합니다. 연결 파일은 프레젠테이션을 열거나 렌더링하는 애플리케이션에서 접근 가능해야 합니다. 경로가 변경되거나 파일이 이동되거나 리소스를 사용할 수 없게 되면 연결 사진이 예상대로 표시되지 않을 수 있습니다. 이메일로 전송하거나, 보관하거나, 격리된 환경에서 렌더링해야 하는 프레젠테이션의 경우 내장 이미지가 일반적으로 더 신뢰할 수 있습니다.

### **연결 이미지 추가**

다음 예제는 사진 프레임을 만들고 로컬 이미지 파일을 가리키도록 합니다. 이 예제는 이미지 연결만 다루며, 비디오 연결은 별도의 미디어 워크플로이며 의도적으로 혼합되지 않았습니다.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

외부 파일 관리가 의도된 경우에만 링크를 사용하십시오. 압축을 대체하기 위해 사용하지 마십시오: 이미지 종속성이 손상된 작은 PPTX는 일반적으로 더 큰 자체 포함 프레젠테이션보다 덜 유용합니다.

## **사진 프레임에서 이미지 추출**

기존 프레젠테이션에서 이미지를 추출하기 전에 도형이 실제로 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/) 인지와 내장 이미지를 포함하고 있는지 확인하십시오. 연결된 사진 프레임은 동일한 방식으로 추출할 수 있는 이미지 바이트를 포함하지 않을 수 있습니다.

### **래스터 이미지 추출**

최신 이미지 API 는 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) 를 직접 사용합니다. 다음 예제는 슬라이드에서 첫 번째 내장 래스터 사진을 찾아 PNG 로 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

[IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) 를 통해 저장하면 추출된 이미지를 원하는 출력 형식으로 변환합니다. 프레젠테이션에 저장된 인코딩된 바이트가 필요하고 변환된 래스터 파일이 필요하지 않은 경우 [PPImage.binary_data](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/binary_data/) 속성을 사용하십시오.

### **SVG 이미지 추출**

SVG 사진의 경우, [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/) 가 [SvgImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/svgimage/) 객체를 노출합니다. 이를 통해 SVG 데이터를 직접 가져올 수 있으며, 먼저 사진을 래스터화할 필요가 없습니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

SVG 내용을 SVG 로 유지하면 프레젠테이션 내부에 벡터 소스를 보존합니다. PNG 또는 JPEG와 같은 래스터 내보내기는 해당 벡터 내용을 픽셀로 렌더링합니다. PDF 또는 SVG 슬라이드 내보내기도 렌더링 작업이므로, 내보낸 그래픽을 원본 내장 SVG와 바이트 단위로 동일하게 취급하지 말고, 원본 벡터 리소스 자체가 필요할 때는 내장 [SvgImage.svg_data](https://reference.aspose.com/slides/ko/python-net/aspose.slides/svgimage/svg_data/) 를 사용하십시오.

## **이미지 자르기**

자르기는 프레임 내부에서 이미지의 어떤 부분이 보일지를 변경합니다. [PictureFillFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/) 의 자르기 값은 원본 이미지 차원의 백분율입니다. 자르기는 초기 단계에서 숨겨진 픽셀을 내장 이미지에서 삭제하지 않으며, 단지 보이는 영역만 변경합니다.

다음 예제는 사진 프레임을 안전하게 찾아 자르기 값을 적용합니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

숨겨진 이미지 데이터가 여전히 존재하기 때문에, 원본 픽셀을 잃지 않고 나중에 자르기 값을 변경할 수 있습니다. 파일 크기가 더 중요하고 되돌릴 필요가 없을 경우, 다음 섹션에 설명된 대로 자른 영역을 물리적으로 제거할 수 있습니다.

## **잘라낸 이미지 데이터 제거**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 은 현재 자르기 사각형 밖의 이미지 데이터를 제거하고 결과 이미지 리소스를 반환합니다. 이는 파일 크기를 줄일 수 있지만 파괴적인 최적화입니다: 프레젠테이션을 저장한 후에는 제거된 픽셀이 더 이상 복구되지 않아 이후에 복원할 수 없습니다.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

이 메서드는 프레젠테이션에 새 이미지 리소스를 추가할 수 있습니다. 원본 이미지가 다른 사진 프레임에서도 사용되는 경우, 해당 프레임은 기존 리소스를 계속 필요로 하므로 잘라낸 영역을 삭제한다고 해서 전체 이미지 수가 반드시 감소하는 것은 아닙니다. WMF 또는 EMF 콘텐츠를 이 메서드로 자르면 결과가 PNG 로 래스터화됩니다.

## **래스터 이미지 압축**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/compress_image/) 은 사진이 표시되는 크기에 비해 래스터 이미지 해상도를 낮춥니다. 동일한 작업에서 잘라낸 영역을 제거할 수도 있습니다. 메서드는 이미지가 크기 조정 또는 잘라내기된 경우 `True` 를, 변경이 필요하지 않은 경우 `False` 를 반환합니다.

표준 대상 해상도가 충분할 때는 미리 정의된 [PicturesCompression](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/picturescompression/) 값을 사용하십시오:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

특정 목표 해상도가 필요한 경우 열거형 값 대신 양의 DPI 값을 직접 전달할 수 있습니다.

압축은 래스터 이미지에만 적용됩니다. SVG 및 메타파일 콘텐츠는 이 래스터 압축 워크플로로 감소되지 않습니다. 또한 낮은 해상도와 삭제된 잘라낸 영역은 최적화된 프레젠테이션에서 복구할 수 없음을 기억하십시오. 가장 큰 표시 또는 내보내기 크기를 기준으로 목표 해상도를 선택하고, 전역적으로 가장 낮은 DPI 를 적용하는 것은 피하십시오.

## **이미지 변환 효과 관리**

밝기, 대비, 색상 변환, 블러, 알파 효과, 순차 체인, 검사, 제거 및 라운드 트립 검증을 포함하는 전체 워크플로는 [Image Transform Effects](/slides/ko/python-net/image-transform-effects/) 를 참조하십시오.

## **사진 프레임 기하학 잠금**

[PictureFrameLock](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframelock/) 설정은 사진 프레임에 대해 어느 편집 작업이 비활성화되는지를 제어합니다. 예를 들어, [aspect_ratio_locked](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) 속성은 크기 조정 시 도형의 비율을 유지합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

이 잠금은 사진 프레임 도형에 적용됩니다. 원본 이미지를 재샘플링하거나 영구적으로 동일 비율로 변경하도록 강제하지는 않습니다.

## **StretchOffset 값 조정**

사진 채우기 모드가 stretch 인 경우, [PictureFillFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/) 의 stretch‑offset 값은 사진 프레임 경계 상자에 상대적인 채우기 사각형을 정의합니다. 양의 백분율은 가장자리에서 안쪽으로 inset을 만들고, 음의 백분율은 바깥쪽으로 outset을 만듭니다.

이는 자르기와 다릅니다. 자르기 값은 원본 이미지의 어느 부분이 보일지를 선택하고, stretch offset 은 보이는 사진 채우기가 늘어나는 사각형을 변경합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

채우기 위치를 지정할 때는 stretch offset 을 사용하고, 원본 이미지 가장자리를 숨기려면 자르기 속성을 사용하십시오.

## **스토리지, 파일 크기 및 내보내기 고려 사항**

이미지 스토리지와 사진 프레임 서식을 별도로 처리하면 주요 트레이드오프를 관리하기가 더 쉽습니다:

- **내장 이미지** 는 프레젠테이션을 자체 포함하게 하며 공유 및 서버‑사이드 렌더링에 가장 신뢰할 수 있습니다. 그러나 큰 래스터 이미지는 PPTX 크기와 메모리 사용량을 증가시킵니다.
- **연결 이미지** 는 패키지를 작게 유지할 수 있지만, 프레젠테이션은 외부 파일이 저장된 경로나 위치에 계속 접근 가능해야 합니다.
- **자르기** 는 초기에는 비파괴적입니다. 숨겨진 픽셀은 잘라낸 영역을 명시적으로 삭제하거나 압축 중에 제거할 때까지 내장된 상태로 남아 있습니다.
- **압축** 은 과도한 래스터 이미지의 파일 크기를 크게 줄일 수 있지만 원본 해상도를 포기합니다. 슬라이드에 표시될 최종 크기를 알게 된 후에 적용해야 합니다.
- **SVG 이미지** 는 벡터 보존이 중요한 경우 SVG 로 유지해야 합니다. 벡터 리소스 자체가 필요할 때는 내장 SVG 를 직접 추출하십시오. 래스터 슬라이드 내보내기는 항상 렌더링된 슬라이드를 픽셀로 변환합니다.
- **중복 이미지** 는 가능한 경우 기존 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/) 리소스를 재사용하고, 동일 파일을 프레젠테이션 워크플로에 반복적으로 로드하지 않도록 합니다.

대규모 프레젠테이션에서는 이미지 최적화를 선택적으로 수행하는 것이 보통 가장 효과적입니다: 로고와 다이어그램은 벡터 콘텐츠로 유지하고, 사진은 실제 표시 크기에 따라 압축하며, 나중에 편집이 필요하지 않을 경우에만 잘라낸 픽셀을 제거하고, 외부 링크는 의존성 관리가 배포 설계의 일부가 아닌 한 피하십시오.

## **FAQ**

**사진 프레임과 이미지 리소스의 차이점은 무엇인가요?**

[PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/) 은 프레젠테이션에 연결된 이미지 리소스를 나타냅니다. [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/) 은 슬라이드에 있는 도형으로 이미지를 표시하고 크기, 회전, 자르기 값, 효과 및 잠금과 같은 프레임 수준 기하학 및 서식을 저장합니다.

**이미지를 내장할지 연결할지를 어떻게 결정해야 하나요?**

프레젠테이션을 이동 가능하고 보관되며 외부 리소스에 접근하지 않고도 렌더링해야 하는 경우 이미지를 내장하십시오. 외부 파일을 PPTX 밖에 두고 외부 위치를 신뢰성 있게 유지 관리할 수 있는 경우에만 이미지를 연결하십시오.

**자르기가 PPTX 파일 크기를 줄이나요?**

자체적으로는 줄이지 않습니다. 일반적인 자르기 설정은 원본 이미지의 일부를 숨기지만 기본 픽셀은 유지합니다. 픽셀을 영구적으로 삭제하려면 [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 를 사용하거나 잘라낸 영역 제거와 함께 이미지 압축을 수행하십시오.

**압축 후 이미지 품질을 복원할 수 있나요?**

아니요. 압축은 저장된 래스터 해상도를 낮추고, 잘라낸 영역을 제거하면 이미지 데이터가 삭제됩니다. 나중에 고해상도 편집이 필요할 경우 원본 이미지를 프레젠테이션 외부에 보관하십시오.

**SVG 이미지는 어떻게 처리해야 하나요?**

벡터 정확성이 중요한 경우 SVG 내용을 SVG 로 유지하십시오. 내장된 [SvgImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/svgimage/) 를 직접 추출할 수 있습니다. 슬라이드를 PNG 또는 JPEG와 같은 래스터 형식으로 렌더링하면 SVG 가 슬라이드 이미지의 일부로 래스터화됩니다.

**기존 슬라이드를 읽을 때 unsafe cast 를 방지하려면 어떻게 해야 하나요?**

picture‑frame‑specific 멤버를 사용하기 전에 도형 유형을 확인하십시오. `isinstance(shape, slides.PictureFrame)` 을 사용하면 잘못된 캐스트를 피하고 사진 프레임이 없는 슬라이드를 처리할 수 있습니다.