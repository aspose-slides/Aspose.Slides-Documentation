---
title: Modern API로 이미지 처리 강화
linktitle: 모던 API
type: docs
weight: 280
url: /ko/python-net/modern-api/
keywords:
- 모던 API
- 그리기
- 슬라이드 썸네일
- 슬라이드 이미지 변환
- 도형 썸네일
- 도형 이미지 변환
- 프레젠테이션 썸네일
- 프레젠테이션 이미지 변환
- 이미지 추가
- 그림 추가
- Python
- Aspose.Slides
description: "PowerPoint와 OpenDocument 자동화를 원활하게 수행하기 위해, 사용 중단된 이미지 API를 Python Modern API로 교체하여 슬라이드 이미지 처리를 현대화합니다."
---
## **소개**

Aspose.Slides for Python 공개 API는 현재 다음 `aspose.pydrawing` 유형에 의존합니다:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

버전 24.4부터 이 공개 API는 [변경 사항](https://releases.aspose.com/slides/ko/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) 때문에 **사용 중단됨**입니다.

`aspose.pydrawing`을 공개 API에서 제거하기 위해 **Modern API**를 도입했습니다. `aspose.pydrawing.Image`와 `aspose.pydrawing.Bitmap`을 사용하는 메서드는 사용 중단되었으며 Modern API 동등 메서드로 교체해야 합니다. `aspose.pydrawing.Graphics`를 사용하는 메서드는 사용 중단되었으며 직접적인 Modern API 대체가 없습니다.

현재 버전에서는 `aspose.pydrawing`에 의존하는 공개 API를 레거시/사용 중단으로 간주하고, 새 코드를 작성하거나 기존 이미지 처리 워크플로를 마이그레이션할 때 Modern API를 사용하십시오.

## **Modern API**

다음 클래스와 열거형이 공개 API에 추가되었습니다:

- [aspose.slides.IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) - 래스터 또는 벡터 이미지를 나타냅니다.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imageformat/) - 이미지 파일 형식을 나타냅니다.
- [aspose.slides.Images](https://reference.aspose.com/slides/ko/python-net/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/)을 만들고 작업하는 메서드를 제공합니다.

단일 슬라이드나 도형을 렌더링하려면 `get_image`를 사용하십시오. 여러 프레젠테이션 슬라이드를 렌더링하려면 `get_images`를 사용하십시오. 이미지를 로드하려면 [Images](https://reference.aspose.com/slides/ko/python-net/aspose.slides/images/) 메서드를 사용하고, 프레젠테이션에 추가하려면 `add_image`와 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/)를, 기존 프레젠테이션 이미지를 업데이트하려면 `replace_image`와 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/)를 사용하십시오.

새 API의 전형적인 사용 시나리오는 다음과 같습니다:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **구식 코드를 Modern API로 교체**

새 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) 클래스는 `aspose.pydrawing.Image`와 `aspose.pydrawing.Bitmap` 클래스의 별도 API를 반영합니다. 대부분의 경우 `aspose.pydrawing`을 사용하는 메서드 호출을 Modern API 동등 메서드로 교체하면 됩니다.

### **슬라이드 썸네일 가져오기**

**사용 중단된 API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **도형 썸네일 가져오기**

**사용 중단된 API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **프레젠테이션 썸네일 가져오기**

**사용 중단된 API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Modern API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **프레젠테이션에 그림 추가**

**사용 중단된 API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **제거될 메서드 및 속성 및 해당 Modern 대체 항목**

### **Presentation 클래스**

|메서드 서명|대체 메서드 서명|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Modern API 대체 없음|
|save(fname, format, options, response, show_inline)|Modern API 대체 없음|
|print()|Modern API 대체 없음|
|print(printer_settings)|Modern API 대체 없음|
|print(printer_name)|Modern API 대체 없음|
|print(printer_settings, pres_name)|Modern API 대체 없음|

### **Slide 클래스**

|메서드 서명|대체 메서드 서명|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Modern API 대체 없음|
|render_to_graphics(options, graphics, scale_x, scale_y)|Modern API 대체 없음|
|render_to_graphics(options, graphics, rendering_size)|Modern API 대체 없음|

### **Shape 클래스**

|메서드 서명|대체 메서드 서명|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection 클래스**

|메서드 서명|대체 메서드 서명|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage 클래스**

|메서드/속성 서명|대체 메서드/속성 서명|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory 클래스**

|메서드 서명|대체 메서드 서명|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat 클래스**

|메서드 서명|대체 메서드 서명|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData 클래스**

|메서드 서명|대체 메서드 서명|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output 클래스**

|메서드 서명|대체 메서드 서명|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **aspose.pydrawing.Graphics에 대한 API 지원**

`aspose.pydrawing.Graphics`를 사용하는 메서드는 사용 중단되었으며 직접적인 Modern API 대체가 없습니다.

`aspose.pydrawing.Graphics`에 렌더링하는 API 대신 Modern API 이미지 렌더링 메서드를 사용하십시오:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **자주 묻는 질문**

**왜 `aspose.pydrawing.Graphics`가 제외되었나요?**

`aspose.pydrawing.Graphics`에 대한 지원은 렌더링과 이미지 작업을 통합하고 플랫폼 별 종속성을 없애며 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/)을 사용한 크로스 플랫폼 접근 방식으로 전환하기 위해 공개 API에서 사용 중단되었습니다. `aspose.pydrawing.Graphics`에 렌더링하는 대신 `get_image` 또는 `get_images`를 사용하십시오.

**[IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/)가 `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`에 비해 실용적인 장점은 무엇인가요?**

[IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/)는 래스터와 벡터 이미지를 모두 다루는 작업을 통합하고, [ImageFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imageformat/)을 통해 다양한 형식으로 저장을 간소화하며, pydrawing에 대한 의존성을 줄이고 환경 간 코드 휴대성을 높여줍니다.

**Modern API가 썸네일 생성 성능에 영향을 미칠까요?**

`get_thumbnail`을 `get_image`로 전환해도 시나리오가 악화되지 않습니다. 새로운 메서드는 옵션 및 크기와 함께 이미지를 생성하는 동일한 기능을 제공하며, 렌더링 옵션 지원도 유지합니다. 구체적인 이득이나 감소는 시나리오에 따라 다르지만 기능적으로는 동일합니다.