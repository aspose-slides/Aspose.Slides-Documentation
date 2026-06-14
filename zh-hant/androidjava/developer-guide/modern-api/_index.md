---
title: 使用現代 API 強化影像處理
linktitle: 現代 API
type: docs
weight: 237
url: /zh-hant/androidjava/modern-api/
keywords:
- android.graphics
- 現代 API
- 繪圖
- 投影片縮圖
- 投影片轉圖像
- 圖形縮圖
- 圖形轉圖像
- 簡報縮圖
- 簡報轉圖像
- 加入圖像
- 加入圖片
- Android
- Java
- Aspose.Slides
description: "透過 Java 現代 API 取代已棄用的影像 API，實現無縫的 PowerPoint 與 OpenDocument 自動化，讓投影片影像處理更現代化。"
---
## **介紹**

歷史上，Aspose Slides 依賴於 android.graphics，並在公開 API 中使用了以下類別：
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

自 24.4 版起，這些公開 API 已標示為已棄用。

為了移除對這些類別的依賴，我們新增了所謂的「現代 API」—即應取代已棄用 API 的新 API，其簽名不再依賴於 [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)。[Canvas](https://developer.android.com/reference/android/graphics/Canvas) 已宣告棄用，且在公開 Slides API 中已移除其支援。

在目前的版本中，將依賴 android.graphics 型別的公開 API 視為傳統/已棄用。新程式碼以及遷移現有影像處理工作流程時，請使用現代 API。

## **現代 API**

在公開 API 中新增了以下類別與列舉：

- [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) - 代表點陣圖或向量圖像。
- [ImageFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imageformat/) - 代表圖像的檔案格式。
- [Images](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/images/) - 用於建立與操作 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 介面的相關方法。

請注意 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 為可釋放物件，使用後應呼叫 `dispose()` 或其他便利的釋放模式。

使用 `getImage` 來渲染單一投影片或圖形。使用 `getImages` 來渲染多張投影片。使用 [Images](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/images/) 方法載入圖像，使用 `addImage` 搭配 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 將其加入投影片，使用 `replaceImage` 搭配 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 更新既有投影片圖像。

使用新 API 的典型情境如下：

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // 從磁碟上的檔案實例化可釋放的 IImage 實例。
    IImage image = Images.fromFile("image.png");
    try {
        // 透過將 IImage 實例加入簡報的 images 以建立 PowerPoint 圖像。
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 在投影片 #1 上加入圖片形狀
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // 取得代表投影片 #1 的 IImage 實例。
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // 將圖像儲存至磁碟。
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **以現代 API 取代舊代碼**

一般而言，您需要將使用 [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) 的呼叫改為使用 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 的新方法。

舊版/已棄用 API:
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
現代 API:
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

### **取得投影片縮圖**

舊版/已棄用 API:

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

現代 API:

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

### **取得圖形縮圖**

舊版/已棄用 API:

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

現代 API:

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

### **取得簡報縮圖**

舊版/已棄用 API:

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

現代 API:

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

### **在簡報中加入圖片**

舊版/已棄用 API:

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

現代 API:

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

## **已棄用方法及其在現代 API 中的替代方案**

### **Presentation**
| 方法簽名 | 替代方法簽名 |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| 方法簽名 | 替代方法簽名 |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| 方法簽名 | 替代方法簽名 |
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
| 方法簽名 | 替代方法簽名 |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| 方法簽名 | 替代方法簽名 |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| 方法簽名 | 替代方法簽名 |
|--------------------------------------|-----------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| 方法簽名 | 替代方法簽名 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| 方法簽名 | 替代方法簽名 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Canvas 的 API 支援**

所有使用 [Canvas](https://developer.android.com/reference/android/graphics/Canvas) 的方法皆已標示為已棄用，且沒有直接的現代 API 替代。

請改用現代 API 的影像渲染方法，而非渲染至 [Canvas](https://developer.android.com/reference/android/graphics/Canvas)：

[Slide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **常見問題**

**為什麼移除 android.graphics.Canvas？**

 public API 中的 [Canvas](https://developer.android.com/reference/android/graphics/Canvas) 已被棄用，目的是統一渲染與圖像的處理，消除平台特定的依賴，並以跨平台的 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 取代。請改用 `getImage` 或 `getImages`，而非渲染至 [Canvas](https://developer.android.com/reference/android/graphics/Canvas)。

**[IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 相較於 [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) 有何實務好處？**

[IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 能同時處理點陣圖與向量圖，並透過 [ImageFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imageformat/) 簡化多種格式的儲存。

**現代 API 會影響產生縮圖的效能嗎？**

從 `getThumbnail` 轉換為 `getImage` 不會降低效能；新方法提供相同的選項與尺寸控制，同時保留渲染選項的支援。具體的效能提升或下降取決於使用情境，但在功能上替代是等價的。