---
title: 파이썬으로 프레젠테이션에 그림 프레임 추가
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/python-net/picture-frame/
keywords:
- 그림 프레임
- 그림 프레임 추가
- 그림 프레임 생성
- 이미지 추가
- 이미지 생성
- 이미지 추출
- 래스터 이미지
- 벡터 이미지
- 이미지 자르기
- 잘린 영역
- StretchOff 속성
- 그림 프레임 서식 지정
- 그림 프레임 속성
- 비례 스케일
- 이미지 효과
- 가로세로 비율
- 이미지 투명도
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 그림 프레임을 추가합니다. 워크플로를 간소화하고 슬라이드 디자인을 향상시킵니다."
---
## **소개**

Aspose.Slides for Python의 그림 프레임을 사용하면 래스터 및 벡터 이미지를 기본 슬라이드 도형으로 배치하고 관리할 수 있습니다. 파일이나 스트림에서 그림을 삽입하고, 정확한 좌표로 위치와 크기를 조정하며, 회전 적용, 투명도 설정 및 다른 도형과 함께 Z 순서를 제어할 수 있습니다. API는 또한 자르기, 가로세로 비율 유지, 테두리 및 효과 설정, 레이아웃을 재구성하지 않고 기본 이미지를 교체하는 기능을 지원합니다. 그림 프레임은 일반 도형처럼 동작하므로 애니메이션, 하이퍼링크 및 대체 텍스트를 추가할 수 있어 시각적으로 풍부하고 접근 가능한 프레젠테이션을 쉽게 만들 수 있습니다.

## **그림 프레임 만들기**

이 섹션에서는 Aspose.Slides for Python으로 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)을 생성해 슬라이드에 이미지를 삽입하는 방법을 보여줍니다. 이미지를 로드하고, 슬라이드에 정확히 배치하며, 크기와 서식을 제어하는 방법을 배웁니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드를 가져옵니다.  
3. 프레젠테이션의 [ImageCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/)에 이미지를 추가해 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)를 생성합니다. 이 이미지는 도형을 채우는 데 사용됩니다.  
4. 프레임의 너비와 높이를 지정합니다.  
5. [add_picture_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_picture_frame/) 메서드를 사용해 해당 크기의 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)을 생성합니다.  
6. 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Python 코드가 그림 프레임을 만드는 예시입니다:

```py
import aspose.slides as slides

# Presentation 클래스를 인스턴스화하여 PPTX 파일을 나타냅니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # 이미지를 프레젠테이션에 추가합니다.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 이미지 크기에 맞는 그림 프레임을 추가합니다.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 프레젠테이션을 PPTX 형식으로 저장합니다.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
그림 프레임을 사용하면 이미지로 프레젠테이션 슬라이드를 빠르게 만들 수 있습니다. 그림 프레임을 Aspose.Slides 저장 옵션과 결합하면 이미지 포맷 변환 시 I/O 작업을 제어할 수 있습니다. 아래 페이지들을 확인해 보세요: {{convert [image to JPG](https://products.aspose.com/slides/ko/python-net/conversion/image-to-jpg/)}}, {{convert [JPG to image](https://products.aspose.com/slides/ko/python-net/conversion/jpg-to-image/)}}, {{convert [JPG to PNG](https://products.aspose.com/slides/ko/python-net/conversion/jpg-to-png/)}}, {{convert [PNG to JPG](https://products.aspose.com/slides/ko/python-net/conversion/png-to-jpg/)}}, {{convert [PNG to SVG](https://products.aspose.com/slides/ko/python-net/conversion/png-to-svg/)}}, {{convert [SVG to PNG](https://products.aspose.com/slides/ko/python-net/conversion/svg-to-png/)}}.
{{% /alert %}}

## **비례 스케일이 적용된 그림 프레임 만들기**

이 섹션에서는 고정 크기로 이미지를 배치한 뒤, 너비와 높이에 대해 서로 다른 백분율 스케일을 적용하는 방법을 보여줍니다. 백분율이 다르면 가로세로 비율이 변경될 수 있습니다. 스케일링은 이미지 원본 크기를 기준으로 수행됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드를 가져옵니다.  
3. 프레젠테이션의 [ImageCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/)에 이미지를 추가해 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)를 생성합니다.  
4. 슬라이드에 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)을 추가합니다.  
5. 그림 프레임의 비례 너비와 높이를 설정합니다.  
6. 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Python 코드가 비례 스케일이 적용된 그림 프레임을 만드는 예시입니다:

```py
import aspose.slides as slides

# Presentation 클래스를 인스턴스화하여 PPTX 파일을 나타냅니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 슬라이드에 그림 프레임을 추가합니다.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # 비례 스케일 너비와 높이를 설정합니다.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # 프레젠테이션을 저장합니다.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **그림 프레임에서 래스터 이미지 추출하기**

[PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/) 객체에서 래스터 이미지를 추출해 PNG, JPG 등 다양한 포맷으로 저장할 수 있습니다. 아래 예제는 문서 “sample.pptx”에서 이미지를 추출해 PNG 포맷으로 저장하는 방법을 보여줍니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **그림 프레임에서 SVG 이미지 추출하기**

프레젠테이션에 SVG 그래픽이 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/) 도형 안에 포함된 경우, Aspose.Slides for Python via .NET을 사용하면 원본 벡터 이미지를 완전한 정밀도로 가져올 수 있습니다. 슬라이드의 도형 컬렉션을 순회하면서 각 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)을 식별하고, 해당 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)가 SVG 콘텐츠를 포함하고 있는지 확인한 뒤, 원본 SVG 포맷으로 디스크나 스트림에 저장합니다.

다음 코드 예제가 그림 프레임에서 SVG 이미지를 추출하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **이미지 투명도 가져오기**

Aspose.Slides는 이미지에 적용된 투명도 효과를 검색할 수 있습니다. 아래 Python 코드가 해당 작업을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
이미지에 적용된 모든 효과는 [aspose.slides.effects](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/)에서 찾을 수 있습니다.
{{% /alert %}}

## **이미지 밝기 및 대비 가져오기**

Aspose.Slides는 이미지에 적용된 밝기와 대비 효과를 검색할 수 있습니다. [Luminance](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/luminance/) 클래스가 해당 이미지 변환 효과를 나타냅니다.

다음 Python 코드가 그림 프레임에서 밝기와 대비 설정을 가져오는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **그림 프레임 서식 지정**

Aspose.Slides는 그림 프레임에 적용할 수 있는 다양한 서식 옵션을 제공합니다. 이러한 옵션을 사용하면 특정 요구 사항에 맞게 그림 프레임을 조정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드를 가져옵니다.  
3. 프레젠테이션의 [ImageCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/)에 이미지를 추가해 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)를 생성합니다. 이 이미지는 도형을 채우는 데 사용됩니다.  
4. 프레임의 너비와 높이를 지정합니다.  
5. 슬라이드의 [add_picture_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_picture_frame/) 메서드를 사용해 해당 크기의 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)을 생성합니다.  
6. 그림 프레임의 선 색을 설정합니다.  
7. 그림 프레임의 선 두께를 설정합니다.  
8. 양수(시계 방향) 또는 음수(시계 반대 방향) 값을 제공해 그림 프레임을 회전합니다.  
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Python 코드가 그림 프레임 서식 지정 과정을 보여줍니다:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 이미지 크기에 맞는 그림 프레임을 추가합니다.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 그림 프레임에 서식을 적용합니다.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # 프레젠테이션을 PPTX 형식으로 저장합니다.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose는 무료 [Collage Maker](https://products.aspose.app/slides/ko/collage)를 제공하며, JPG/JPEG 또는 PNG 이미지를 병합하거나 [포토 그리드 만들기](https://products.aspose.app/slides/ko/collage/photo-grid)를 원할 때 사용할 수 있습니다.
{{% /alert %}}

## **이미지를 링크로 추가하기**

프레젠테이션 파일 크기를 최소화하려면 파일을 직접 삽입하는 대신 이미지 또는 비디오를 링크 형태로 추가할 수 있습니다. 아래 Python 코드는 플레이스홀더에 이미지와 비디오를 삽입하는 예시를 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **이미지 자르기**

이 섹션에서는 이미지 소스 파일을 변경하지 않고 그림 프레임 내에서 보이는 영역을 자르는 방법을 학습합니다. 또한 슬라이드에서 깔끔하고 집중된 구성을 만들기 위해 자르기 여백을 적용하는 기본 방법도 배웁니다.

다음 Python 코드가 슬라이드에서 이미지를 자르는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # 슬라이드에 그림 프레임을 추가합니다.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # 이미지를 자릅니다 (백분율 값).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # 결과를 저장합니다.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **잘린 이미지 영역 삭제하기**

프레임에서 이미지의 잘린 영역을 삭제하려면 [delete_picture_cropped_areas](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 메서드를 사용합니다. 이 메서드는 잘린 이미지를 반환하거나, 자르기가 필요 없을 경우 원본 이미지를 반환합니다.

다음 Python 코드가 해당 작업을 시연합니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 첫 번째 슬라이드에서 PictureFrame을 가져옵니다.
    picture_frame = slides.shape[0]

    # 첫 번째 슬라이드에서 PictureFrame을 가져옵니다.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # 결과를 저장합니다.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
[delete_picture_cropped_areas](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 메서드는 잘린 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다. 해당 이미지가 처리된 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)에만 사용된 경우 프레젠테이션 크기가 감소할 수 있지만, 그렇지 않으면 결과 프레젠테이션의 이미지 수가 증가할 수 있습니다.

자르기 과정에서 이 메서드는 WMF/EMF 메타파일을 래스터 PNG 이미지로 변환합니다.
{{% /alert %}}

## **이미지 압축하기**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/compress_image/) 메서드를 사용해 프레젠테이션의 그림을 압축할 수 있습니다. 이 메서드는 도형 크기와 지정된 해상도를 기반으로 이미지 크기를 줄이며, 필요에 따라 잘린 영역을 삭제할 수 있습니다.

PowerPoint의 **그림 서식 → 그림 압축 → 해상도** 기능과 유사하게 그림의 크기와 해상도를 조정합니다.

다음 Python 예제가 목표 해상도를 지정하고 선택적으로 잘린 영역을 제거해 프레젠테이션의 이미지를 압축하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # 대상 해상도 150 DPI(웹 해상도)로 이미지를 압축하고 잘린 영역을 제거합니다.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # 압축 결과를 확인합니다.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

또는 직접 사용자 지정 DPI 값을 사용하는 방법:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # 이미지를 150 DPI(웹 해상도)로 압축하고 잘린 영역을 제거합니다.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
이 메서드는 도형 크기와 제공된 DPI를 기준으로 이미지를 낮은 해상도로 변환합니다. 잘린 영역도 삭제해 파일 크기를 최적화할 수 있습니다. 이미지가 메타파일(WMF/EMF)이나 SVG인 경우 압축이 적용되지 않으며, JPEG의 경우 해상도에 따라 품질이 약간 감소할 수 있습니다(PowerPoint의 동작과 유사).
{{% /alert %}}

## **가로세로 비율 잠그기**

이미지 크기를 변경한 후에도 이미지가 포함된 도형이 가로세로 비율을 유지하도록 하려면 [aspect_ratio_locked](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) 속성을 `True`로 설정합니다.

다음 Python 코드가 도형의 가로세로 비율을 잠그는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # 크기 조정 시 가로세로 비율을 잠급니다.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
*가로세로 비율 잠금* 설정은 도형 자체의 비율만 보존하며, 내부 이미지의 비율은 영향을 받지 않습니다.
{{% /alert %}}

## **Stretch Offset 속성 사용하기**

[PictureFillFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/) 클래스의 `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right`, `stretch_offset_bottom` 속성을 사용하면 채우기 사각형을 정의할 수 있습니다.

이미지에 스트레칭이 지정되면 소스 사각형이 채우기 사각형에 맞게 스케일됩니다. 채우기 사각형의 각 가장자리는 도형 경계 상자의 해당 가장자리에서 백분율 오프셋으로 정의됩니다. 양수 백분율은 안쪽으로 삽입, 음수 백분율은 밖으로 돌출을 의미합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.  
3. 사각형 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)을 추가합니다.  
4. 도형의 채우기 유형을 설정합니다.  
5. 도형의 그림 채우기 모드를 지정합니다.  
6. 이미지를 로드합니다.  
7. 이미지를 도형에 채우기로 할당합니다.  
8. 도형 경계 상자의 해당 가장자리에서 이미지 오프셋을 지정합니다.  
9. 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Python 코드가 Stretch Offset 속성을 사용하는 방법을 보여줍니다:

```py
import aspose.slides as slides

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # 사각형 AutoShape을 추가합니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # 도형의 채우기 유형을 설정합니다.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 도형의 그림 채우기 모드를 설정합니다.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 이미지를 로드하고 프레젠테이션에 추가합니다.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # 이미지를 도형에 채우기로 할당합니다.
    shape.fill_format.picture_fill_format.picture.image = image

    # 도형 경계 상자의 해당 가장자리에서 이미지 오프셋을 지정합니다.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose는 무료 변환기인 [JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt)와 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)를 제공하여 이미지를 빠르게 프레젠테이션으로 만들 수 있도록 돕습니다.
{{% /alert %}}

## **FAQ**

**PictureFrame에서 지원되는 이미지 포맷을 어떻게 확인할 수 있나요?**

Aspose.Slides는 래스터 이미지(PNG, JPEG, BMP, GIF 등)와 벡터 이미지(예: SVG)를 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)에 할당된 이미지 객체를 통해 모두 지원합니다. 지원되는 포맷 목록은 슬라이드 및 이미지 변환 엔진의 기능과 대체로 겹칩니다.

**수십 개의 대용량 이미지를 추가하면 PPTX 파일 크기와 성능에 어떤 영향을 미치나요?**

대용량 이미지를 임베드하면 파일 크기와 메모리 사용량이 증가합니다. 이미지를 링크 형태로 추가하면 프레젠테이션 크기를 줄일 수 있지만 외부 파일이 계속 접근 가능해야 합니다. Aspose.Slides는 파일 크기를 감소시키기 위해 링크 방식으로 이미지를 추가하는 기능을 제공합니다.

**이미지 개체가 실수로 이동·크기 조정되는 것을 방지하려면 어떻게 해야 하나요?**

[PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)에 대한 [shape locks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/picture_frame_lock/)를 사용합니다(예: 이동 또는 크기 조정 비활성화). 잠금 메커니즘은 별도의 [보호 문서](/slides/ko/python-net/applying-protection-to-presentation/)에 설명되어 있으며, 다양한 도형 유형에 대해 지원됩니다.

**SVG 벡터 정밀도가 PDF/이미지로 내보낼 때 유지되나요?**

Aspose.Slides는 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)에서 SVG를 원본 벡터 그대로 추출할 수 있게 합니다. [PDF로 내보내기](/slides/ko/python-net/convert-powerpoint-to-pdf/) 또는 [래스터 포맷](/slides/ko/python-net/convert-powerpoint-to-png/) 시, 내보내기 설정에 따라 결과가 래스터화될 수 있지만, 원본 SVG가 벡터로 저장된다는 점은 추출 동작을 통해 확인할 수 있습니다.