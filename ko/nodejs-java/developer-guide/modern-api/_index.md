---
title: 모던 API로 이미지 처리 향상
linktitle: 모던 API
type: docs
weight: 237
url: /ko/nodejs-java/modern-api/
keywords:
- 모던 API
- 그리기
- 슬라이드 썸네일
- 슬라이드 이미지 변환
- 모양 썸네일
- 모양 이미지 변환
- 프레젠테이션 썸네일
- 프레젠테이션 이미지 변환
- 이미지 추가
- 사진 추가
- Node.js
- JavaScript
- Aspose.Slides
description: "구식 이미지 API를 JavaScript 모던 API로 교체하여 슬라이드 이미지 처리를 현대화하고 PowerPoint 및 OpenDocument 자동화를 원활하게 수행합니다."
---
## **소개**

역사적으로 Aspose Slides는 java.awt에 종속성이 있었으며 공개 API에 다음 클래스를 포함하고 있습니다:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

버전 24.4부터 이 공개 API는 사용 중단(deprecated)으로 선언되었습니다.

이러한 클래스에 대한 종속성을 없애기 위해 이른바 “모던 API”를 추가했습니다. 즉, 사용 중단된 API 대신 사용해야 하는 API이며, 시그니처에 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 종속성이 포함됩니다. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)는 사용 중단으로 선언되었으며 공개 Slides API에서 지원이 제거되었습니다.

현재 버전에서는 java.awt 타입에 의존하는 공개 API를 레거시/사용 중단으로 간주합니다. 새로운 코드 작성 및 기존 이미지 처리 워크플로를 마이그레이션할 때는 모던 API를 사용하십시오.

## **모던 API**

다음 클래스 및 열거형을 공개 API에 추가했습니다:

- [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/) – 래스터 또는 벡터 이미지를 나타냅니다.
- [ImageFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/imageformat/) – 이미지의 파일 형식을 나타냅니다.
- [Images](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/images/) – [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/) 클래스를 인스턴스화하고 작업하기 위한 메서드입니다.

[IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/)은 disposable이며 사용 후 `dispose()` 호출이나 다른 편리한 해제 패턴을 따라야 합니다.

단일 슬라이드 또는 셰이프를 렌더링하려면 `getImage`를 사용하십시오. 여러 프레젠테이션 슬라이드를 렌더링하려면 `getImages`를 사용합니다. 이미지를 로드하려면 [Images](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/images/) 메서드를 사용하고, 프레젠테이션에 추가하려면 [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/)와 함께 `addImage`를, 기존 프레젠테이션 이미지를 업데이트하려면 [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/)와 함께 `replaceImage`를 사용합니다.

새 API를 사용하는 일반적인 시나리오는 다음과 같습니다:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // 디스크에 있는 파일에서 IImage의 disposable 인스턴스를 생성합니다.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // 프레젠테이션의 이미지에 IImage 인스턴스를 추가하여 PowerPoint 이미지를 생성합니다.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 슬라이드 #1에 그림 모양을 추가합니다.
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // 슬라이드 #1을 나타내는 IImage 인스턴스를 가져옵니다.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // 이미지를 디스크에 저장합니다.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **기존 코드를 모던 API로 교체**

일반적으로 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 및 [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html)를 사용하는 호출을 [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/)를 사용하는 새로운 메서드로 교체해야 합니다.

레거시/사용 중단 API:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
모던 API:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **슬라이드 썸네일 가져오기**

레거시/사용 중단 API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "slide1.png");
    imageio.write(slideImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

모던 API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getImage();
    slideImage.save("slide1.png", aspose.slides.ImageFormat.Png);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **셰이프 썸네일 가져오기**

레거시/사용 중단 API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "shape.png");
    imageio.write(shapeImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

모던 API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    shapeImage.save("shape.png");
    shapeImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **프레젠테이션 썸네일 가져오기**

레거시/사용 중단 API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var bitmaps = pres.getThumbnails(new aspose.slides.RenderingOptions(), size);
    for (var index = 0; index < bitmaps.length; index++)
    {
        var thumbnail = bitmaps[index];
        var imageio = java.import("javax.imageio.ImageIO");
        var file = java.newInstanceSync("java.io.File", "slide" + index + ".png");
        imageio.write(thumbnail, "PNG", file);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

모던 API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var images = pres.getImages(new aspose.slides.RenderingOptions(), size);
    try
    {
        for (var index = 0; index < images.length; index++)
        {
            var thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", aspose.slides.ImageFormat.Png);
        }
    }
    finally
    {
        images.forEach(item => {item.dispose();});
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **프레젠테이션에 이미지 추가**

레거시/사용 중단 API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "image.png");
    var bufferedImages = imageio.read(file);
    var ppImage = pres.getImages().addImage(bufferedImages);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

모던 API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var image = aspose.slides.Images.fromFile("image.png");
    var ppImage = pres.getImages().addImage(image);
    image.dispose();

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **사용 중단된 메서드와 모던 API에서의 대체**

### **Presentation**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|----------------|-------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|----------------|-------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|----------------|-------------------|
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
|----------------|-------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|----------------|-------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|----------------|-------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|----------------|-------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|----------------|-------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D 지원 API**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)와 관련된 메서드는 사용 중단으로 선언되었으며 직접적인 모던 API 대체가 없습니다.

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)에 렌더링하는 API 대신 모던 API 이미지 렌더링 메서드를 사용하십시오:

[Slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**[IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/)은(는) [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)에 비해 실질적인 이점이 무엇인가요?**

[IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/)은 래스터와 벡터 이미지를 모두 다룰 수 있게 통합하고, [ImageFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/imageformat/)을 통해 다양한 포맷으로 저장하는 과정을 간소화합니다.

**모던 API가 썸네일 생성 성능에 영향을 미칠까요?**

`getThumbnail`에서 `getImage`로 전환해도 시나리오가 악화되지 않습니다. 새로운 메서드는 옵션 및 크기와 함께 이미지를 생성하는 동일한 기능을 제공하며 렌더링 옵션 지원을 유지합니다. 구체적인 성능 향상 혹은 감소는 시나리오에 따라 다르지만, 기능적으로 대체는 동등합니다.