---
title: 使用 Modern API 增强图像处理
linktitle: Modern API
type: docs
weight: 237
url: /zh/androidjava/modern-api/
keywords:
- android.graphics
- 现代 API
- 绘图
- 幻灯片缩略图
- 幻灯片转图像
- 形状缩略图
- 形状转图像
- 演示文稿缩略图
- 演示文稿转图像
- 添加图像
- 添加图片
- Android
- Java
- Aspose.Slides
description: "通过使用 Java Modern API 替换已弃用的成像 API，实现幻灯片图像处理的现代化，以实现无缝的 PowerPoint 和 OpenDocument 自动化。"
---
## **介绍**

历史上，Aspose Slides 依赖于 android.graphics，并在公共 API 中提供了以下来自该库的类：
- [画布](https://developer.android.com/reference/android/graphics/Canvas)
- [位图](https://developer.android.com/reference/android/graphics/Bitmap)

从 24.4 版起，此公共 API 已被标记为已弃用。

为了摆脱对这些类的依赖，我们添加了所谓的“Modern API”——即应取代已弃用 API 的 API，其签名包含对 [位图](https://developer.android.com/reference/android/graphics/Bitmap) 的依赖。[画布](https://developer.android.com/reference/android/graphics/Canvas) 已被标记为已弃用，并且在公共 Slides API 中已移除其支持。

在当前版本中，请将依赖于 android.graphics 类型的公共 API 视为传统/已弃用。对新代码以及迁移现有图像处理工作流时，请使用 Modern API。

## **Modern API**

向公共 API 添加了以下类和枚举：

- [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) - 表示光栅或矢量图像。
- [ImageFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imageformat/) - 表示图像的文件格式。
- [Images](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/images/) - 用于实例化和操作 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 接口的方法。

请注意，[IImage] 是可释放的，使用后应调用 `dispose()` 或其他便捷的释放模式。

使用 `getImage` 渲染单个幻灯片或形状。使用 `getImages` 渲染多个幻灯片。使用 [Images](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/images/) 方法加载图像，使用 `addImage` 搭配 [IImage] 将图像添加到演示文稿，使用 `replaceImage` 搭配 [IImage] 更新演示文稿中的已有图像。

典型的使用新 API 的场景可能如下所示：

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // 实例化一个可释放的 IImage 实例，来源于磁盘上的文件。
    IImage image = Images.fromFile("image.png");
    try {
        // 通过将 IImage 实例添加到演示文稿的图像集合来创建 PowerPoint 图像。
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 在第 1 张幻灯片上添加图片形状
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // 获取表示第 1 张幻灯片的 IImage 实例。
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // 将图像保存到磁盘。
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **用 Modern API 替换旧代码**

一般来说，您需要将使用 [位图](https://developer.android.com/reference/android/graphics/Bitmap) 的调用替换为使用 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 的新方法。

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

### **获取幻灯片缩略图**

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

### **获取形状缩略图**

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

### **获取演示文稿缩略图**

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

### **向演示文稿添加图片**

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

## **已弃用方法及其在 Modern API 中的替代方案**

### **Presentation**
| 方法签名 | 替换方法签名 |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| 方法签名 | 替换方法签名 |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| 方法签名 | 替换方法签名 |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
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

### **Output**
| 方法签名 | 替换方法签名 |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| 方法签名 | 替换方法签名 |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| 方法签名 | 替换方法签名 |
|--------------------------------------|-----------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| 方法签名 | 替换方法签名 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| 方法签名 | 替换方法签名 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Canvas 的 API 支持**

使用 [Canvas](https://developer.android.com/reference/android/graphics/Canvas) 的方法已被标记为已弃用，且没有直接的 Modern API 替代。

请使用 Modern API 的图像渲染方法取代渲染到 [Canvas](https://developer.android.com/reference/android/graphics/Canvas) 的 API：

[Slide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**为什么弃用了 android.graphics.Canvas？**

公共 API 中对 [Canvas](https://developer.android.com/reference/android/graphics/Canvas) 的支持已被弃用，以统一渲染和图像的工作方式，消除对平台特定依赖的绑定，并转向使用跨平台的 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 的方式。请使用 `getImage` 或 `getImages` 代替渲染到 [Canvas](https://developer.android.com/reference/android/graphics/Canvas)。

**[IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 相比 [位图](https://developer.android.com/reference/android/graphics/Bitmap) 有什么实际好处？**

[IImage] 统一了对光栅图像和矢量图像的操作，并通过 [ImageFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imageformat/) 简化了保存为多种格式的过程。

**Modern API 会影响生成缩略图的性能吗？**

从 `getThumbnail` 切换到 `getImage` 并不会导致性能下降：新方法在提供相同选项和尺寸的图像生成功能的同时，仍然保留对渲染选项的支持。具体的提升或下降取决于使用场景，但在功能上两者是等价的。