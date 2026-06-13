---
title: Python으로 프레젠테이션에 그림 프레임 추가
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/python-net/picture-frame/
keywords:
- 그림 프레임
- 그림 프레임 추가
- 그림 프레임 만들기
- 이미지 추가
- 이미지 만들기
- 이미지 추출
- 래스터 이미지
- 벡터 이미지
- 이미지 자르기
- 잘린 영역
- StretchOff property
- 그림 프레임 서식 지정
- 그림 프레임 속성
- 상대 스케일
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

Aspose.Slides for Python의 그림 프레임을 사용하면 래스터 및 벡터 이미지를 기본 슬라이드 도형처럼 배치하고 관리할 수 있습니다. 파일이나 스트림에서 이미지를 삽입하고, 정확한 좌표로 위치와 크기를 지정하며, 회전 적용, 투명도 설정, 다른 도형과 함께 Z 순서를 제어할 수 있습니다. API는 또한 자르기, 가로세로 비율 유지, 테두리 및 효과 설정, 레이아웃을 다시 구축하지 않고 기본 이미지를 교체하는 기능을 지원합니다. 그림 프레임은 일반 도형처럼 동작하므로 애니메이션, 하이퍼링크, 대체 텍스트를 추가할 수 있어 시각적으로 풍부하고 접근성 높은 프레젠테이션을 손쉽게 만들 수 있습니다.

## **그림 프레임 만들기**

이 섹션에서는 Aspose.Slides for Python을 사용해 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)을 생성하여 슬라이드에 이미지를 삽입하는 방법을 보여줍니다. 이미지를 로드하고 슬라이드에 정확히 배치하며 크기와 서식을 제어하는 방법을 학습합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드를 가져옵니다.  
3. 프레젠테이션의 [ImageCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/)에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)를 생성합니다. 이 이미지는 도형을 채우는 데 사용됩니다.  
4. 프레임의 너비와 높이를 지정합니다.  
5. [add_picture_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_picture_frame/) 메서드를 사용해 해당 크기의 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)을 생성합니다.  
6. 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Python 코드는 그림 프레임을 만드는 방법을 보여줍니다:

```py
import aspose.slides as slides

# PPTX 파일을 나타내기 위해 Presentation 클래스를 인스턴스화합니다.
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

그림 프레임을 사용하면 이미지를 빠르게 프레젠테이션 슬라이드로 만들 수 있습니다. 그림 프레임을 Aspose.Slides 저장 옵션과 결합하면 이미지 형식 변환에 대한 I/O 작업을 제어할 수 있습니다. 다음 페이지를 참고하십시오: [image to JPG](https://products.aspose.com/slides/ko/python-net/conversion/image-to-jpg/) 변환; [JPG to image](https://products.aspose.com/slides/ko/python-net/conversion/jpg-to-image/) 변환; [JPG to PNG](https://products.aspose.com/slides/ko/python-net/conversion/jpg-to-png/) 변환; [PNG to JPG](https://products.aspose.com/slides/ko/python-net/conversion/png-to-jpg/) 변환; [PNG to SVG](https://products.aspose.com/slides/ko/python-net/conversion/png-to-svg/) 변환; [SVG to PNG](https://products.aspose.com/slides/ko/python-net/conversion/svg-to-png/) 변환.

{{% /alert %}}

## **상대 스케일링을 사용한 그림 프레임 만들기**

이 섹션에서는 고정 크기로 이미지를 배치한 다음, 너비와 높이에 각각 별개의 백분율 스케일을 적용하는 방법을 설명합니다. 백분율이 서로 다를 경우 가로세로 비율이 변경될 수 있습니다. 스케일링은 이미지의 원본 치수에 상대적으로 수행됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드를 가져옵니다.  
3. 프레젠테이션의 [ImageCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/)에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)를 생성합니다.  
4. 슬라이드에 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)을 추가합니다.  
5. 그림 프레임의 상대적 너비와 높이를 설정합니다.  
6. 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Python 코드는 상대 스케일링을 사용한 그림 프레임 생성 방법을 보여줍니다:

```py
import aspose.slides as slides

# PPTX 파일을 나타내기 위해 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 슬라이드에 그림 프레임을 추가합니다.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # 상대 스케일 너비와 높이를 설정합니다.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # 프레젠테이션을 저장합니다.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **그림 프레임에서 래스터 이미지 추출**

[PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/) 개체에서 래스터 이미지를 추출해 PNG, JPG 등 다양한 형식으로 저장할 수 있습니다. 아래 코드는 “sample.pptx” 문서에서 이미지를 추출해 PNG 형식으로 저장하는 예시입니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **그림 프레임에서 SVG 이미지 추출**

프레젠테이션에 SVG 그래픽이 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/) 도형 안에 포함된 경우, Aspose.Slides for Python via .NET을 사용하면 원본 벡터 이미지를 완전한 품질로 가져올 수 있습니다. 슬라이드의 도형 컬렉션을 순회하면서 각 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)을 찾아 기본 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)가 SVG 콘텐츠를 보유하고 있는지 확인한 뒤, 해당 이미지를 디스크나 스트림에 SVG 형식으로 저장합니다.

다음 코드 예시는 그림 프레임에서 SVG 이미지를 추출하는 방법을 보여줍니다:

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

Aspose.Slides를 사용하면 이미지에 적용된 투명도 효과를 가져올 수 있습니다. 아래 Python 코드가 그 동작을 시연합니다:

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
이미지에 적용된 모든 효과는 [aspose.slides.effects](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/)에서 확인할 수 있습니다.
{{% /alert %}}

## **그림 프레임 서식 지정**

Aspose.Slides는 그림 프레임에 적용할 수 있는 다양한 서식 옵션을 제공합니다. 이러한 옵션을 사용하면 특정 요구 사항에 맞게 그림 프레임을 조정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드를 가져옵니다.  
3. 프레젠테이션의 [ImageCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/)에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)를 생성합니다. 이 이미지는 도형을 채우는 데 사용됩니다.  
4. 프레임의 너비와 높이를 지정합니다.  
5. 슬라이드의 [add_picture_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_picture_frame/) 메서드를 사용해 해당 크기의 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)을 생성합니다.  
6. 그림 프레임의 선 색상을 설정합니다.  
7. 그림 프레임의 선 두께를 설정합니다.  
8. 양의 값(시계 방향) 또는 음의 값(시계 반대 방향)을 제공해 그림 프레임을 회전시킵니다.  
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Python 코드는 그림 프레임 서식 지정 과정을 보여줍니다:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX 파일을 나타내기 위해 Presentation 클래스를 인스턴스화합니다.
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

Aspose에서는 무료 [Collage Maker](https://products.aspose.app/slides/ko/collage)를 제공하고 있습니다. JPG/JPEG 또는 PNG 이미지를 [병합](https://products.aspose.app/slides/ko/collage/jpg)하거나 [포토 그리드](https://products.aspose.app/slides/ko/collage/photo-grid)를 만들고 싶을 때 이 서비스를 활용하세요.

{{% /alert %}}

## **링크로 이미지 추가**

프레젠테이션 파일 크기를 줄이려면 파일을 직접 포함하는 대신 이미지나 비디오를 링크 형태로 추가할 수 있습니다. 다음 Python 코드는 플레이스홀더에 이미지와 비디오를 삽입하는 방법을 보여줍니다:

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

이 섹션에서는 원본 파일을 변경하지 않고 그림 프레임 내 이미지의 표시 영역을 자르는 방법을 배웁니다. 또한 슬라이드에서 깔끔하고 집중된 구성을 만들기 위해 자르기 여백을 적용하는 기본 방법을 학습합니다.

다음 Python 코드는 슬라이드에서 이미지를 자르는 방법을 보여줍니다:

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

## **잘린 이미지 영역 삭제**

프레임에서 이미지의 잘린 영역을 삭제하려면 [delete_picture_cropped_areas](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 메서드를 사용하세요. 이 메서드는 잘린 이미지를 반환하거나, 자르기가 필요하지 않은 경우 원본 이미지를 반환합니다.

다음 Python 코드는 해당 작업을 시연합니다:

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

[delete_picture_cropped_areas](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 메서드는 잘린 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다. 해당 이미지가 처리된 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)에만 사용된다면 프레젠테이션 크기를 줄일 수 있지만, 그렇지 않은 경우 결과 프레젠테이션의 이미지 수가 늘어날 수 있습니다.

자르기 과정에서 이 메서드는 WMF/EMF 메타파일을 래스터 PNG 이미지로 변환합니다.

{{% /alert %}}

## **이미지 압축**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/compress_image/) 메서드를 사용해 프레젠테이션의 그림을 압축할 수 있습니다. 이 메서드는 도형 크기와 지정된 해상도를 기준으로 이미지 크기를 줄이며, 필요에 따라 잘린 영역을 삭제할 수 있습니다.

PowerPoint의 **Picture Format → Compress Pictures → Resolution** 기능과 유사하게 그림의 크기와 해상도를 조정합니다.

다음 Python 예시는 목표 해상도를 지정하고 선택적으로 잘린 영역을 삭제해 프레젠테이션의 이미지를 압축하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # 이미지 압축을 목표 해상도 150 DPI(웹 해상도)로 수행하고 잘린 영역을 제거합니다.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # 압축 결과를 확인합니다.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

또는 직접 사용자 지정 DPI 값을 사용하는 경우:

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

이 메서드는 도형 크기와 제공된 DPI를 기준으로 이미지를 낮은 해상도로 변환합니다. 잘린 영역도 삭제해 파일 크기를 최적화할 수 있습니다. 이미지가 메타파일(WMF/EMF)이나 SVG인 경우 압축이 적용되지 않습니다. 또한 JPEG의 경우 해상도에 따라 품질이 유지되거나 약간 낮아지며, 이는 PowerPoint가 고해상도 JPEG를 처리하는 방식과 유사합니다.

{{% /alert %}}

## **가로세로 비율 잠그기**

이미지의 차원을 변경한 후에도 이미지를 포함한 도형이 가로세로 비율을 유지하도록 하려면 [aspect_ratio_locked](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) 속성을 `True` 로 설정합니다.

다음 Python 코드는 도형의 가로세로 비율을 잠그는 방법을 보여줍니다:

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

이 *Lock Aspect Ratio* 설정은 도형 자체의 가로세로 비율만 유지하고, 도형 내부 이미지의 가로세로 비율은 영향을 받지 않습니다.

{{% /alert %}}

## **Stretch Offset 속성 사용**

[PictureFillFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/) 클래스의 `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right`, `stretch_offset_bottom` 속성을 사용하면 채우기 사각형을 정의할 수 있습니다.

이미지에 대해 스트레칭이 지정되면 원본 사각형이 채우기 사각형에 맞게 스케일됩니다. 채우기 사각형의 각 가장자리는 도형 경계 상자의 해당 가장자리로부터 백분율 오프셋으로 정의됩니다. 양의 백분율은 안쪽 여백을, 음의 백분율은 바깥쪽 여백을 의미합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.  
3. 사각형 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)을 추가합니다.  
4. 도형의 채우기 유형을 설정합니다.  
5. 도형의 그림 채우기 모드를 설정합니다.  
6. 이미지를 로드합니다.  
7. 이미지를 도형에 채우도록 할당합니다.  
8. 도형 경계 상자의 해당 가장자리로부터 이미지 오프셋을 지정합니다.  
9. 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Python 코드는 Stretch Offset 속성을 사용하는 방법을 시연합니다:

```py
import aspose.slides as slides

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # 사각형 AutoShape를 추가합니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # 도형의 채우기 유형을 설정합니다.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 도형의 그림 채우기 모드를 설정합니다.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 이미지를 로드하고 프레젠테이션에 추가합니다.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # 이미지를 도형에 채우도록 할당합니다.
    shape.fill_format.picture_fill_format.picture.image = image

    # 도형 경계 상자의 해당 가장자리로부터 이미지 오프셋을 지정합니다.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

Aspose는 무료 변환기인 [JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt)와 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)를 제공하여 이미지를 빠르게 프레젠테이션으로 만들 수 있도록 지원합니다.

{{% /alert %}}

## **FAQ**

**PictureFrame에서 지원되는 이미지 형식은 어떻게 확인할 수 있나요?**

Aspose.Slides는 래스터 이미지(PNG, JPEG, BMP, GIF 등)와 벡터 이미지(예: SVG)를 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)에 할당되는 이미지 객체를 통해 모두 지원합니다. 지원되는 형식 목록은 일반적으로 슬라이드 및 이미지 변환 엔진의 기능과 겹칩니다.

**수십 개의 대용량 이미지를 추가하면 PPTX 크기와 성능에 어떤 영향을 미치나요?**

대용량 이미지를 포함하면 파일 크기와 메모리 사용량이 증가합니다. 이미지를 링크 형태로 추가하면 프레젠테이션 크기를 줄일 수 있지만 외부 파일이 계속 접근 가능해야 합니다. Aspose.Slides는 파일 크기를 감소시키기 위해 링크로 이미지를 추가하는 기능을 제공합니다.

**이미지 개체가 실수로 이동/크기 변경되는 것을 방지하려면 어떻게 해야 하나요?**

[PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)에 대해 [shape locks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/picture_frame_lock/)를 사용하세요(예: 이동 또는 크기 조정 비활성화). 잠금 메커니즘은 별도의 [보호 관련 문서](/slides/ko/python-net/applying-protection-to-presentation/)에 설명되어 있으며, 다양한 도형 유형에 대해 지원됩니다.

**SVG 벡터 품질이 PDF/이미지로 내보낼 때 유지되나요?**

Aspose.Slides는 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)에서 원본 벡터 SVG를 추출할 수 있도록 합니다. PDF([exporting to PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/)) 또는 래스터 형식([convert-powerpoint-to-png](/slides/ko/python-net/convert-powerpoint-to-png/))으로 내보낼 때는 내보내기 설정에 따라 래스터화될 수 있지만, 원본 SVG가 벡터로 저장된다는 점은 추출 동작을 통해 확인됩니다.