---
title: Modern API를 사용한 이미지 처리 향상
linktitle: Modern API
type: docs
weight: 237
url: /ko/androidjava/modern-api/
keywords:
- android.graphics
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
- Android
- Java
- Aspose.Slides
description: "구식 이미지 API를 Java Modern API로 교체하여 슬라이드 이미지 처리를 현대화하고 PowerPoint 및 OpenDocument 자동화를 원활하게 제공합니다."
---
## **소개**

역사적으로 Aspose Slides는 android.graphics에 종속성이 있으며 공개 API에 다음 클래스들이 포함되어 있습니다:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

버전 24.4부터 이 공개 API는 사용 중단(deprecated)으로 선언되었습니다.

이러한 클래스에 대한 종속성을 없애기 위해, 소위 “Modern API”(현대 API)를 추가했습니다. 즉, 사용 중단된 API 대신 사용해야 하는 API이며, 해당 서명에는 [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)에 대한 종속성이 포함됩니다. [Canvas](https://developer.android.com/reference/android/graphics/Canvas)는 사용 중단으로 선언되었으며 공개 Slides API에서 지원이 제거되었습니다.

현재 버전에서는 android.graphics 타입에 의존하는 공개 API를 레거시/사용 중단으로 간주합니다. 새로운 코드와 기존 이미지 처리 워크플로를 마이그레이션할 때 Modern API를 사용하십시오.

## **현대 API**

공개 API에 다음 클래스 및 열거형을 추가했습니다:

- [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/) - 래스터 또는 벡터 이미지를 나타냅니다.
- [ImageFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imageformat/) - 이미지의 파일 형식을 나타냅니다.
- [Images](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/) 인터페이스를 인스턴스화하고 작업하기 위한 메서드들.

참고로 [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/)는 disposable이며 사용 후 `dispose()` 호출이나 기타 편리한 정리 패턴을 따라야 합니다.

`getImage`를 사용하여 단일 슬라이드 또는 도형을 렌더링합니다. 여러 프레젠테이션 슬라이드를 렌더링하려면 `getImages`를 사용합니다. 이미지를 로드하려면 [Images] 메서드를 사용하고, 프레젠테이션에 추가하려면 [IImage]와 함께 `addImage`를, 기존 프레젠테이션 이미지를 업데이트하려면 [IImage]와 함께 `replaceImage`를 사용합니다.

새 API를 사용하는 일반적인 시나리오는 다음과 같습니다:

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
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // 이미지를 디스크에 저장합니다.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **구식 코드를 Modern API로 교체**

일반적으로 [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)을 사용하는 호출을 [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/)를 사용하는 새로운 메서드로 교체해야 합니다.

레거시/사용 중단 API:
``` java
Presentation pres = new Presentation();
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail(new Size(1920, 1080));
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("image.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
Modern API:
``` java
Presentation pres = new Presentation();
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        slideImage.save("image.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **슬라이드 썸네일 가져오기**

레거시/사용 중단 API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("slide1.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
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
    Bitmap shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("shape.png");
        shapeImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
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
    Bitmap[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Size(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        android.graphics.Bitmap thumbnail = bitmaps[index];
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream("slide" + index + ".png");
            thumbnail.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } finally {
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
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
    IImage[] images = pres.getImages(new RenderingOptions(), new Size(1980, 1028));
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

### **프레젠테이션에 이미지 추가하기**

레거시/사용 중단 API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    File file = new File("image.png");
    Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
    ppImage = pres.getImages().addImage(bitmap);

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

## **사용 중단된 메서드와 Modern API에서의 대체**

### **프레젠테이션**
| 메서드 서명 | 대체 메서드 서명 |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **도형**
| 메서드 서명 | 대체 메서드 서명 |
|------|------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **슬라이드**
| 메서드 서명 | 대체 메서드 서명 |
|------|------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement |

### **출력**
| 메서드 서명 | 대체 메서드 서명 |
|------|------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| 메서드 서명 | 대체 메서드 서명 |
|------|------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| 메서드 서명 | 대체 메서드 서명 |
|------|------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| 메서드 서명 | 대체 메서드 서명 |
|------|------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| 메서드 서명 | 대체 메서드 서명 |
|------|------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Canvas 지원 API**

[Canvas](https://developer.android.com/reference/android/graphics/Canvas)와 관련된 메서드는 사용 중단으로 선언되었으며 직접적인 Modern API 대체가 없습니다.

[Canvas](https://developer.android.com/reference/android/graphics/Canvas)에 렌더링하는 API 대신 Modern API 이미지 렌더링 메서드를 사용하십시오:

[Slide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**android.graphics.Canvas가 제거된 이유는?**

[Canvas](https://developer.android.com/reference/android/graphics/Canvas)에 대한 지원은 렌더링과 이미지 작업을 통합하고, 플랫폼 종속성을 없애며, [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/)를 사용한 크로스 플랫폼 접근 방식으로 전환하기 위해 공개 API에서 사용 중단되었습니다. [Canvas](https://developer.android.com/reference/android/graphics/Canvas) 대신 `getImage` 또는 `getImages`를 사용하십시오.

**[IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/)는 [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)보다 실질적인 이점이 무엇인가요?**

[IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/)는 래스터와 벡터 이미지를 모두 통합하여 작업을 단순화하고, [ImageFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imageformat/)을 통해 다양한 포맷으로 저장을 간편하게 합니다.

**Modern API가 썸네일 생성 성능에 영향을 미칩니까?**

`getThumbnail`을 `getImage`로 전환해도 시나리오가 악화되지 않습니다. 새로운 메서드는 옵션과 크기를 지정하여 이미지를 생성하는 동일한 기능을 제공하며 렌더링 옵션을 그대로 지원합니다. 구체적인 성능 향상 또는 감소는 상황에 따라 다르지만 기능적으로 대체는 동등합니다.