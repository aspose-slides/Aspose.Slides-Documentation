---
title: Modern API로 이미지 처리 향상
linktitle: Modern API
type: docs
weight: 237
url: /ko/php-java/modern-api/
keywords:
- Modern API
- 그리기
- 슬라이드 썸네일
- 슬라이드 이미지 변환
- 도형 썸네일
- 도형 이미지 변환
- 프레젠테이션 썸네일
- 프레젠테이션 이미지 변환
- 이미지 추가
- 그림 추가
- PHP
- Aspose.Slides
description: "구식 이미지 API를 대체하고 PHP Modern API를 사용하여 PowerPoint 및 OpenDocument 자동화를 원활하게 구현함으로써 슬라이드 이미지 처리를 현대화합니다."
---
## **소개**

역사적으로 Aspose Slides는 java.awt에 종속성이 있으며, 공개 API에 다음 클래스들을 포함하고 있습니다:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

버전 24.4부터 이 공개 API는 사용 중단(deprecated)으로 선언되었습니다.

이러한 클래스에 대한 종속성을 없애기 위해 이른바 “Modern API”를 추가했습니다. 즉, 사용 중단된 API 대신 사용할 API이며, 서명에 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 종속성이 포함됩니다. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)는 사용 중단으로 선언되었으며 공개 Slides API에서 지원이 제거되었습니다.

현재 버전에서는 java.awt 유형에 의존하는 공개 API를 레거시/사용 중단으로 취급하십시오. 새로운 코드 및 기존 이미지 처리 워크플로를 마이그레이션할 때는 Modern API를 사용하십시오.

## **모던 API**

공개 API에 다음 클래스와 열거형을 추가했습니다:

- [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/) – 래스터 이미지 또는 벡터 이미지를 나타냅니다.
- [ImageFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imageformat/) – 이미지의 파일 형식을 나타냅니다.
- [Images](https://reference.aspose.com/slides/ko/php-java/aspose.slides/images/) – [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/) 클래스를 인스턴스화하고 작업하는 메서드들입니다.

[IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/)는 disposable이며 사용 후 반드시 해제해야 합니다.

단일 슬라이드 또는 도형을 렌더링하려면 `getImage`를 사용하십시오. 여러 프레젠테이션 슬라이드를 렌더링하려면 `getImages`를 사용하십시오. 이미지를 로드하려면 [Images](https://reference.aspose.com/slides/ko/php-java/aspose.slides/images/) 메서드를 사용하고, 프레젠테이션에 추가하려면 `addImage`와 [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/)를, 기존 프레젠테이션 이미지를 업데이트하려면 `replaceImage`와 [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/)를 사용하십시오.

새 API 사용의 전형적인 시나리오는 다음과 같습니다:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# 파일에서 IImage의 disposable 인스턴스를 생성합니다.
$image = Images::fromFile("image.png");

# IImage 인스턴스를 프레젠테이션 이미지에 추가하여 PowerPoint 이미지를 생성합니다.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# 슬라이드 #1에 그림 도형을 추가합니다
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# 슬라이드 #1을 나타내는 IImage 인스턴스를 가져옵니다.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# 이미지를 디스크에 저장합니다.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **레거시 코드를 Modern API로 교체**

일반적으로 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 및 [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html)를 사용하는 호출을 [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/)를 사용하는 새로운 메서드로 교체해야 합니다.

Legacy/deprecated API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
Modern API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **슬라이드 썸네일 가져오기**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **도형 썸네일 가져오기**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **프레젠테이션 썸네일 가져오기**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$bitmaps = $pres->getThumbnails($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($bitmaps)); $i++)
{
    $thumbnail = $bitmaps[$i];
    $imageio = new Java("javax.imageio.ImageIO");
    $javafile = new Java("java.io.File", "slide" . $i . ".png");
    $imageio->write($thumbnail, "PNG", $javafile);
}

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```

### **프레젠테이션에 그림 추가**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;


$pres = new Presentation();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");

$bufferedImages = $imageio->read($javafile);
$ppImage = $pres->getImages()->addImage($bufferedImages);

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\Images;
use aspose\slides\ShapeType;


$pres = new Presentation();

$image = Images::fromFile("image.png");
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

## **사용 중단된 메서드와 모던 API에서의 대체**

### **Presentation**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

### **Output**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D에 대한 API 지원**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)와 관련된 메서드는 사용 중단으로 선언되었으며 직접적인 Modern API 대체가 없습니다.

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)로 렌더링하는 API 대신 Modern API 이미지 렌더링 메서드를 사용하십시오:

[Slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**왜 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)가 제외되었나요?**

공개 API에서 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)에 대한 지원을 사용 중단하여 렌더링 및 이미지 작업을 통합하고, 플랫폼 특정 종속성을 없애며, [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/)를 통한 크로스 플랫폼 접근 방식으로 전환합니다. `getImage` 또는 `getImages`를 사용하고 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)로의 렌더링은 사용하지 마십시오.

**[IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/)가 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)보다 실질적인 이점은 무엇인가요?**

[IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/)는 래스터와 벡터 이미지를 모두 통합적으로 처리하며, [ImageFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imageformat/)을 통해 다양한 포맷으로 저장을 단순화합니다.

**Modern API가 썸네일 생성 성능에 영향을 미칠까요?**

`getThumbnail`에서 `getImage`로 전환한다고 해서 성능이 악화되지는 않습니다. 새로운 메서드는 옵션 및 크기별 이미지 생성 기능을 동일하게 제공하며 렌더링 옵션 지원도 유지합니다. 구체적인 성능 변화는 시나리오에 따라 다르지만 기능적으로는 동일합니다.