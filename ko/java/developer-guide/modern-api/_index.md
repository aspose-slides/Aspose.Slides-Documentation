---
title: 현대 API로 이미지 처리 강화
linktitle: 현대 API
type: docs
weight: 237
url: /ko/java/modern-api/
keywords:
- 현대 API
- 그리기
- 슬라이드 썸네일
- 슬라이드 이미지 변환
- 도형 썸네일
- 도형 이미지 변환
- 프레젠테이션 썸네일
- 프레젠테이션 이미지 변환
- 이미지 추가
- 그림 추가
- Java
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 자동화를 위한 Java 현대 API로 사용 중단된 이미지 API를 교체하여 슬라이드 이미지 처리를 현대화합니다."
---
## **소개**

역사적으로 Aspose Slides는 java.awt에 의존했고 공개 API에 다음 클래스들을 포함하고 있었습니다:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

버전 24.4부터 이 공개 API는 사용 중단(deprecated)으로 선언되었습니다.

이 클래스들에 대한 의존성을 없애기 위해, 우리는 이른바 “Modern API”를 추가했습니다. 즉, 사용 중단된 API 대신에 사용해야 하는 API이며, 해당 시그니처는 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)에 대한 의존성을 포함합니다. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)는 사용 중단으로 선언되었으며 Slides 공개 API에서 지원이 제거되었습니다.

현재 버전에서는 java.awt 형식에 의존하는 공개 API를 레거시/사용 중단으로 취급합니다. 새 코드를 작성하거나 기존 이미지 처리 워크플로를 마이그레이션할 때는 Modern API를 사용하십시오.

## **Modern API**

다음 클래스와 열거형을 공개 API에 추가했습니다:

- [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/) – 래스터 또는 벡터 이미지를 나타냅니다.
- [ImageFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imageformat/) – 이미지의 파일 형식을 나타냅니다.
- [Images](https://reference.aspose.com/slides/ko/java/com.aspose.slides/images/) – [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/) 인터페이스를 인스턴스화하고 작업하기 위한 메서드들.

[IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/)는 disposable이며 사용 후 `dispose()` 호출이나 다른 편리한 해제 패턴을 사용해야 합니다.

단일 슬라이드 또는 도형을 렌더링하려면 `getImage`를 사용하고, 여러 프레젠테이션 슬라이드를 렌더링하려면 `getImages`를 사용하십시오. 이미지를 로드하려면 [Images](https://reference.aspose.com/slides/ko/java/com.aspose.slides/images/) 메서드를 사용하고, 프레젠테이션에 이미지를 추가하려면 `addImage`와 [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/)를, 기존 프레젠테이션 이미지를 업데이트하려면 `replaceImage`와 [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/)를 사용합니다.

새 API 사용의 전형적인 시나리오는 다음과 같습니다:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // 디스크에 있는 파일에서 IImage의 disposable 인스턴스를 생성합니다.
    IImage image = Images.fromFile("image.png");
    try {
        // IImage 인스턴스를 프레젠테이션 이미지에 추가하여 PowerPoint 이미지를 생성합니다.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 슬라이드 #1에 그림 도형을 추가합니다.
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // 슬라이드 #1을 나타내는 IImage 인스턴스를 가져옵니다.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // 디스크에 이미지를 저장합니다.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modern API로 기존 코드 교체**

일반적으로 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)와 ImageIO를 사용하는 호출을 [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/)를 사용하는 새로운 메서드로 교체해야 합니다.

레거시/사용 중단 API:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
Modern API:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **슬라이드 썸네일 가져오기**

레거시/사용 중단 API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail();
    try {
        ImageIO.write(slideImage, "PNG", new File("slide1.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage();
    try {
        slideImage.save("slide1.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **도형 썸네일 가져오기**

레거시/사용 중단 API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    try {
        ImageIO.write(shapeImage, "PNG", new File("shape.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    try {
        shapeImage.save("shape.png");
    } finally {
        if (shapeImage != null) shapeImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **프레젠테이션 썸네일 가져오기**

레거시/사용 중단 API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Dimension(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        try 
        {
            BufferedImage thumbnail = bitmaps[index];
            ImageIO.write(thumbnail, "PNG", new File("slide" + index + ".png"));
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Dimension(1980, 1028));
    try
    {
        for (int index = 0; index < images.length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", ImageFormat.Png);
        }
    }
    finally
    {
        for (IImage image : images)
        {
            image.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **프레젠테이션에 그림 추가하기**

레거시/사용 중단 API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    try {
        BufferedImage bufferedImages = ImageIO.read(new File("image.png"));
        ppImage = pres.getImages().addImage(bufferedImages);
    } catch (IOException e) {
        e.printStackTrace();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    IImage image = Images.fromFile("image.png");
    try {
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **사용 중단된 메서드와 Modern API 대체 메서드**

### **Presentation**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|---|---|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|---|---|
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
|---|---|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|---|---|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|---|---|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|---|---|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|---|---|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D에 대한 API 지원**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)와 관련된 메서드는 사용 중단으로 선언되었으며 직접적인 Modern API 대체가 없습니다.

Modern API 이미지 렌더링 메서드를 사용하고 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)로 렌더링하는 API 대신에 다음을 사용하십시오:

[Slide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**왜 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)를 제외했나요?**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)에 대한 지원이 공개 API에서 사용 중단된 이유는 렌더링 및 이미지 작업을 통합하고 플랫폼 특정 의존성을 제거하며 [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/)를 통한 크로스플랫폼 접근 방식으로 전환하기 위함입니다. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 대신 `getImage` 또는 `getImages`를 사용하십시오.

**[IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/)가 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)보다 실용적인 장점은 무엇인가요?**

[IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/)는 래스터와 벡터 이미지를 모두 다룰 수 있게 통합하고, [ImageFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imageformat/)을 통해 다양한 형식으로 저장하는 과정을 단순화합니다.

**Modern API가 썸네일 생성 성능에 영향을 미치나요?**

`getThumbnail`에서 `getImage`로 전환해도 시나리오가 악화되지 않습니다. 새로운 메서드는 옵션과 크기를 지정해 이미지를 생성할 수 있는 동일한 기능을 제공하며 렌더링 옵션도 지원합니다. 구체적인 성능 차이는 상황에 따라 다르지만 기능적으로 대체는 동등합니다.