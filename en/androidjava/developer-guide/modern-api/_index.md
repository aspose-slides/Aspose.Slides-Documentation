---
title: Enhance Image Processing with the Modern API
linktitle: Modern API
type: docs
weight: 237
url: /androidjava/modern-api/
keywords:
- android.graphics
- modern API
- drawing
- slide thumbnail
- slide to image
- shape thumbnail
- shape to image
- presentation thumbnail
- presentation to images
- add image
- add picture
- Android
- Java
- Aspose.Slides
description: "Modernize slide image processing by replacing deprecated imaging APIs with the Java Modern API for seamless PowerPoint and OpenDocument automation."
---

## **Introduction**

Historically, Aspose Slides has a dependency on android.graphics and has in the public API the following classes from there:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

As of version 24.4, this public API is declared deprecated.

In order to get rid of dependencies on these classes, we added the so-called "Modern API" - i.e. the API that should be used instead of the deprecated one, whose signatures contain dependencies on [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). [Canvas](https://developer.android.com/reference/android/graphics/Canvas) is declared deprecated and its support is removed from the public Slides API.

In current versions, treat the public API that depends on android.graphics types as legacy/deprecated. Use the Modern API for new code and when migrating existing image-processing workflows.

## **Modern API**

Added the following classes and enums to the public API:

- [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) - represents the raster or vector image.
- [ImageFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/) - represents the file format of the image.
- [Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/) - methods to instantiate and work with the [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) interface.

Please note that [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) is disposable and its use should be followed by a `dispose()` call or another convenient disposal pattern.

Use `getImage` to render a single slide or shape. Use `getImages` to render several presentation slides. Use [Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/) methods to load images, `addImage` with [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) to add them to a presentation, and `replaceImage` with [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) to update an existing presentation image.

A typical scenario of using the new API may look as follows:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // instantiate a disposable instance of IImage from the file on the disk.
    IImage image = Images.fromFile("image.png");
    try {
        // create a PowerPoint image by adding an instance of IImage to the presentation's images.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // add a picture shape on the slide #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // get an instance of the IImage representing slide #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // save the image on the disk.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Replacing Old Code with Modern API**

In general, you will need to replace calls that use [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) with the new methods that use [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/).

Legacy/deprecated API:
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

### **Getting a Slide Thumbnail**

Legacy/deprecated API:

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

### **Getting a Shape Thumbnail**

Legacy/deprecated API:

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

### **Getting a Presentation Thumbnail**

Legacy/deprecated API:

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

### **Adding a Picture to a Presentation**

Legacy/deprecated API:

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

## **Deprecated Methods and Their Replacement in Modern API**

### **Presentation**
| Method Signature                               | Replacement Method Signature                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Method Signature                                                      | Replacement Method Signature                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Method Signature                                                      | Replacement Method Signature                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement  |

### **Output**
| Method Signature                                                | Replacement Method Signature                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Method Signature                          | Replacement Method Signature               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Method Signature                     | Replacement Method Signature   |
|--------------------------------------|-----------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Method Signature                                          | Replacement Method Signature                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor)   | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Method Signature                                          | Replacement Method Signature                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |


## **API Support for Canvas**

Methods with [Canvas](https://developer.android.com/reference/android/graphics/Canvas) are declared deprecated and have no direct Modern API replacement.

Use the Modern API image-rendering methods instead of the API that renders to [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**Why was android.graphics.Canvas dropped?**

Support for [Canvas](https://developer.android.com/reference/android/graphics/Canvas) is deprecated in the public API to unify work with rendering and images, eliminate ties to platform-specific dependencies, and switch to a cross-platform approach with [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/). Use `getImage` or `getImages` instead of rendering to [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**What is the practical benefit of [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) compared to [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)?**

[IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) unifies working with both raster and vector images and simplifies saving to various formats via [ImageFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/).

**Will the Modern API affect the performance of generating thumbnails?**

Switching from `getThumbnail` to `getImage` does not worsen scenarios: the new methods provide the same capabilities for producing images with options and sizes, while retaining support for rendering options. The specific gain or drop depends on the scenario, but functionally the replacements are equivalent.
