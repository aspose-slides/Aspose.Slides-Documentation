---
title: Python에서 최신 API를 사용한 이미지 처리 향상
linktitle: 최신 API
type: docs
weight: 237
url: /ko/python-java/modern-api/
keywords:
- 최신 API
- 그리기
- 슬라이드 썸네일
- 슬라이드를 이미지로
- 도형 썸네일
- 도형을 이미지로
- 프레젠테이션 썸네일
- 프레젠테이션을 이미지로
- 이미지 추가
- 그림 추가
- Python
- Java
- Aspose.Slides
description: "Java를 통해 Python에서 이미지 처리를 현대화하십시오: 슬라이드와 도형을 렌더링하고, 그림을 추가하며, 더 이상 사용되지 않는 이미지 호출을 Aspose.Slides 최신 API로 마이그레이션합니다."
---
## **소개**

Aspose.Slides for Python via Java은 JPype를 통해 Java 라이브러리에 접근합니다. 기존 이미지 처리 API는 `java.awt`의 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)와 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)를 사용했습니다.

Java 라이브러리는 버전 24.4부터 이러한 이미지 API를 사용 중단했습니다. 최신 API는 이미지를 로드, 렌더링 및 저장하기 위해 [IImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/)을 사용합니다. 새로운 Python 코드와 기존 이미지 처리 워크플로를 마이그레이션할 때 이 API를 사용하십시오.

{{% alert color="info" title="Note" %}}
아래의 오래된 메서드 이름은 마이그레이션 참조용이며, 현재 릴리스에서는 더 이상 사용할 수 없습니다. 실행 예제는 최신 API를 사용합니다.
  
이 변경으로 모든 `java.awt` 타입이 사라지는 것은 아닙니다. 이미지 크기와 패턴 색상 오버로드는 여전히 [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html)과 [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html)을 받아들입니다.
{{% /alert %}}

## **최신 API**

주요 이미지 처리 타입은 다음과 같습니다:

- [IImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/) — 래스터 또는 벡터 이미지를 나타냅니다.
- [ImageFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imageformat/) — 이미지 파일 형식 상수를 제공합니다.
- [Images](https://reference.aspose.com/slides/ko/python-java/aspose.slides/images/) — 예를 들어 [Images.fromFile](https://reference.aspose.com/slides/ko/python-java/aspose.slides/images/#fromFile)과 같이 이미지를 생성합니다.

[Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage) 또는 [Shape.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage)를 사용해 단일 슬라이드 또는 도형을 렌더링합니다. 여러 슬라이드를 렌더링하려면 렌더링 옵션과 함께 [Presentation.getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages)를 사용합니다. 인수가 없는 오버로드는 프레젠테이션의 이미지 컬렉션을 반환합니다.

이미지는 [Images.fromFile](https://reference.aspose.com/slides/ko/python-java/aspose.slides/images/#fromFile)으로 로드하고, [ImageCollection.addImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagecollection/#addImage)으로 추가하거나, 기존 프레젠테이션 이미지는 [PPImage.replaceImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#replaceImage)으로 교체합니다. 이미지 컬렉션 작업은 모두 [IImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/)을 받습니다.

로드하거나 렌더링한 각 이미지는 `finally` 블록에서 `dispose` 메서드를 호출해 해제하십시오. 프레젠테이션은 [Presentation.dispose](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#dispose)로 해제합니다.

### **Python 환경 준비**

[Installation](/slides/ko/python-java/installation/)에 설명된 대로 패키지를 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 import하고, JVM이 실행된 후 API를 import합니다. 예제는 JVM을 계속 실행시켜 재사용하도록 설계되었습니다. 노트북 및 JVM 수명 주기에 관한 안내는 [Limitations and API Differences](/slides/ko/python-java/limitations-and-api-differences/#import-the-library)를 참조하십시오.

`pres.pptx`를 여는 예제는 작업 디렉터리에 프레젠테이션 파일이 있어야 합니다. `image.png`를 로드하는 예제는 기존 이미지 파일이 필요합니다.

### **그림 로드 및 슬라이드 렌더링**

이 예제는 첫 번째 슬라이드에 그림을 추가하고 슬라이드를 JPEG 이미지로 저장합니다. [IImage.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/#save)는 지정된 형식으로 렌더링된 이미지를 기록합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **구식 코드 교체하기**

레거시 썸네일 호출을 [IImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/)를 반환하는 메서드로 교체한 뒤, 결과를 [IImage.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/#save)으로 저장합니다. 이렇게 하면 [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-)에 렌더링된 이미지를 전달할 필요가 없어집니다.

### **지정된 크기로 슬라이드 렌더링**

레거시 `slide.getThumbnail(image_size)` 호출을 동일한 이미지 크기를 사용하여 [Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage)으로 교체합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **슬라이드 썸네일 가져오기**

레거시 `slide.getThumbnail()` 호출을 인수 없이 [Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage)으로 교체합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **도형 썸네일 가져오기**

레거시 `shape.getThumbnail()` 호출을 [Shape.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage)으로 교체합니다. 도형에 접근하기 전에 슬라이드에 도형이 존재하는지 확인하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **프레젠테이션 썸네일 가져오기**

레거시 `presentation.getThumbnails(options, image_size)` 호출을 [Presentation.getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages)으로 교체합니다. 렌더링 옵션을 구성하려면 [RenderingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/renderingoptions/)를 사용하십시오.

Python의 `enumerate`를 사용해 반환된 배열을 바로 반복합니다. 저장 실패 시 남은 이미지가 해제되지 않도록 `finally` 블록에서 반환된 모든 이미지를 해제하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **프레젠테이션에 그림 추가**

[ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) 대신 [Images.fromFile](https://reference.aspose.com/slides/ko/python-java/aspose.slides/images/#fromFile)으로 이미지를 로드하고, 결과 이미지를 [ImageCollection.addImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagecollection/#addImage)에 전달합니다. 그림을 슬라이드에 추가하고 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **더 이상 사용되지 않는 메서드와 최신 API에서의 대체**

표는 Python 호출 표기법을 사용합니다. 레거시 열의 이름은 제거된 API를 나타내며, 연결된 대체 메서드를 사용하십시오. 최신 이미지 렌더링 메서드는 Java BufferedImage 대신 [IImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/) 객체를 반환합니다.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages) 호출 시 렌더링 옵션을 지정하면 렌더링된 이미지 배열을 반환합니다.

| 레거시 호출 | 최신 대체 |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages) with `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages) with `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages) with `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages) with `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages) with `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages) with `options, image_size` |

여기서 `slides`는 1부터 시작하는 슬라이드 번호의 Java `int[]`이며, `jpype.JArray(jpype.JInt)([1, 3])`와 같이 생성합니다. `image_size`는 [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html)입니다.

### **Shape**

| 레거시 호출 | 최신 대체 |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage) with no arguments |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage) with `bounds, scale_x, scale_y` |

### **Slide**

| 레거시 호출 | 최신 대체 |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage) with no arguments |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage) with `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage) with `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage) with `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage) with `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage) with `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage) with `image_size` |
| `slide.renderToGraphics(options, graphics)` | 직접적인 대체 없음; 대신 이미지로 렌더링 |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | 직접적인 대체 없음; 대신 이미지로 렌더링 |
| `slide.renderToGraphics(options, graphics, image_size)` | 직접적인 대체 없음; 대신 이미지로 렌더링 |

여기서 `options`는 [RenderingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/renderingoptions/)이며, `tiff_options`는 [TiffOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/)입니다.

### **Output**

| 레거시 호출 | 최신 대체 |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/ko/python-java/aspose.slides/output/#add) with `path, image`, where `image` is [IImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| 레거시 호출 | 최신 대체 |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagecollection/#addImage) with an [IImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/) |

### **PPImage**

| 레거시 호출 | 최신 대체 |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#getImage) |

기존 프레젠테이션 이미지 내용을 교체하려면 [PPImage.replaceImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/#replaceImage)과 [IImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/)를 사용하십시오.

### **PatternFormat**

| 레거시 호출 | 최신 대체 |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/ko/python-java/aspose.slides/patternformat/#getTile) with `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/ko/python-java/aspose.slides/patternformat/#getTile) with `background, foreground` |

색상 인자는 여전히 Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html) 객체를 사용합니다.

### **PatternFormatEffectiveData**

Java API를 JPype를 통해 반환하는 효과적인 패턴 데이터에 대한 대체 메서드는 이름 `getTileIImage`를 유지합니다.

| 레거시 호출 | 최신 대체 |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, returns [IImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/) |

## **Graphics2D에 대한 API 지원**

레거시 `renderToGraphics` 오버로드는 호출자가 제공한 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 컨텍스트에 그렸습니다. 최신 API에는 해당 컨텍스트에 직접 그리는 직접적인 대체가 없습니다.

[Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage)로 슬라이드를 렌더링하거나 [Presentation.getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages)로 여러 슬라이드를 렌더링한 뒤, 반환된 이미지를 [IImage.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/#save)로 저장하십시오. 슬라이드 렌더링과 Java 커스텀 드로잉을 결합했던 애플리케이션은 합성 단계를 재구성해야 합니다.

## **FAQ**

**왜 기존 Java 이미지 API가 교체되었나요?**

최신 API는 이미지 로드, 렌더링 및 저장을 [IImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/iimage/)로 이동시킵니다. 이를 통해 Java BufferedImage나 Java graphics 컨텍스트를 노출하지 않고 공통 이미지 추상화를 제공합니다.

**여전히 Java와 JPype가 필요합니까?**

예. Aspose.Slides for Python via Java는 여전히 JVM에서 실행됩니다. 최신 API는 이미지 처리 호출만 바꾸며 런타임 요구 사항은 변하지 않습니다. 자세한 내용은 [System Requirements](/slides/ko/python-java/system-requirements/)를 참고하십시오.

**Python에서 이미지를 어떻게 해제합니까?**

로드하거나 렌더링한 각 이미지에 대해 `finally` 블록에서 `dispose`를 호출합니다. 여러 슬라이드를 렌더링한 경우 반환된 배열의 모든 이미지도 해제하십시오. 프레젠테이션은 별도로 [Presentation.dispose](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#dispose)로 해제합니다.

**최신 API로 전환하면 썸네일 생성 속도가 빨라집니까?**

성능 향상이 보장되지 않습니다. 교체 메서드는 렌더링 옵션, 스케일 및 이미지 크기를 지원하므로 실제 프레젠테이션 및 출력 설정으로 성능을 측정하십시오.

**이미지 가져오기 메서드가 때때로 컬렉션을 반환하는 이유는?**

인수 없이 [Presentation.getImages](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getImages)를 호출하면 프레젠테이션에 포함된 이미지 컬렉션을 반환합니다. 렌더링 옵션을 포함한 오버로드는 렌더링된 슬라이드 이미지를 반환합니다.