---
title: 使用現代 API 強化影像處理
linktitle: 現代 API
type: docs
weight: 237
url: /zh-hant/java/modern-api/
keywords:
- 現代 API
- 繪圖
- 投影片縮圖
- 投影片轉影像
- 形狀縮圖
- 形狀轉影像
- 簡報縮圖
- 簡報轉影像
- 新增影像
- 新增圖片
- Java
- Aspose.Slides
description: "透過使用 Java 現代 API 取代已棄用的影像 API，讓投影片影像處理現代化，以實現無縫的 PowerPoint 與 OpenDocument 自動化。"
---
## **簡介**

從歷史上看，Aspose Slides 依賴於 `java.awt`，並在公共 API 中包含了以下來自該套件的類別：
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

自 24.4 版起，此公共 API 已標示為已棄用。

為了去除對這些類別的依賴，我們加入了所謂的「現代 API」——即應取代已棄用 API 使用的 API，其簽名不再依賴於 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)。[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 已被宣告為已棄用，且其支援已從公共 Slides API 中移除。

在目前的版本中，將依賴於 `java.awt` 類型的公共 API 視為傳統/已棄用。對於新程式碼以及遷移現有影像處理工作流程時，請使用現代 API。

## **現代 API**

在公共 API 中加入了以下類別與列舉：

- [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) ─ 代表點陣或向量影像。
- [ImageFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imageformat/) ─ 代表影像的檔案格式。
- [Images](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/images/) ─ 用於實例化與操作 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 介面的各種方法。

請注意，[IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 需要釋放，使用後應呼叫 `dispose()` 或採用其他便利的釋放模式。

使用 `getImage` 來渲染單一投影片或形狀。使用 `getImages` 來渲染多張投影片。使用 [Images](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/images/) 方法載入影像、使用 `addImage` 搭配 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 將影像加入投影片，並使用 `replaceImage` 搭配 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 更新現有投影片的影像。

以下是一個典型的使用新 API 的情境：

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // 從磁碟上的檔案實例化一個可釋放的 IImage 實例。
    IImage image = Images.fromFile("image.png");
    try {
        // 透過將 IImage 實例加入簡報的影像集合，建立 PowerPoint 影像。
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 在第 1 張投影片上新增圖片形狀
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // 取得代表第 1 張投影片的 IImage 實例。
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // 將影像儲存至磁碟。
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **以現代 API 取代舊程式碼**

一般而言，您需要將使用 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 與 ImageIO 的呼叫，改為使用搭配 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 的新方法。

傳統/已棄用 API：
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
現代 API：
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **取得投影片縮圖**

傳統/已棄用 API：

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

現代 API：

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

### **取得形狀縮圖**

傳統/已棄用 API：

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

現代 API：

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

傳統/已棄用 API：

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

現代 API：

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

### **將圖片加入簡報**

傳統/已棄用 API：

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

現代 API：

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

## **已棄用方法及其在現代 API 的取代方案**

### **Presentation**
| 方法簽章 | 取代方法簽章 |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| 方法簽章 | 取代方法簽章 |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| 方法簽章 | 取代方法簽章 |
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
| 方法簽章 | 取代方法簽章 |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| 方法簽章 | 取代方法簽章 |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| 方法簽章 | 取代方法簽章 |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| 方法簽章 | 取代方法簽章 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| 方法簽章 | 取代方法簽章 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D 的 API 支援**

所有包含 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的方法均已標示為已棄用，且沒有直接的現代 API 取代方案。

請改用現代 API 的影像渲染方法，取代渲染至 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的 API：

[Slide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **常見問答**

**為什麼會棄用 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)？**

在公共 API 中棄用對 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的支援，是為了統一渲染與影像的操作、消除對平台特定依賴，並以跨平台的 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 方式取代。請改用 `getImage` 或 `getImages`，而非渲染至 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)。

**[IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 相較於 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 有何實際好處？**

[IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 統一了點陣與向量影像的處理，並透過 [ImageFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imageformat/) 簡化了多種格式的儲存。

**現代 API 會影響產生縮圖的效能嗎？**

將 `getThumbnail` 換成 `getImage` 不會降低效能：新方法在產生具備選項與尺寸的影像時提供相同功能，且仍保留渲染選項的支援。具體的效能增減取決於使用情境，但功能上兩者是等價的。