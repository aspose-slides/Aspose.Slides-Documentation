---
title: 使用現代 API 加強影像處理
linktitle: 現代 API
type: docs
weight: 237
url: /zh-hant/nodejs-java/modern-api/
keywords:
- 現代 API
- 繪圖
- 投影片縮圖
- 投影片轉圖像
- 形狀縮圖
- 形狀轉圖像
- 簡報縮圖
- 簡報轉圖像
- 新增圖像
- 新增圖片
- Node.js
- JavaScript
- Aspose.Slides
description: "透過使用 JavaScript 現代 API 取代已過時的影像 API，現代化投影片影像處理，以實現無縫的 PowerPoint 與 OpenDocument 自動化。"
---
## **簡介**

在歷史上，Aspose Slides 依賴 java.awt，並在公共 API 中包含以下來自該套件的類別：
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

自 24.4 版起，此公共 API 已宣告為過時。

為了移除對這些類別的依賴，我們新增了所謂的「現代化 API」——即應取代過時 API 使用的 API，其簽章仍會包含對 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 的依賴。[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 已被宣告為過時，且其支援已從公共 Slides API 中移除。

在目前版本中，將依賴 java.awt 型別的公共 API 視為遺留/過時。對於新程式碼以及遷移現有影像處理工作流程時，請使用現代化 API。

## **現代化 API**

已在公共 API 中新增以下類別與列舉：

- [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) - 代表點陣或向量圖像。
- [ImageFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imageformat/) - 代表圖像的檔案格式。
- [Images](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/images/) - 用於實例化與操作 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 類別的方法。

請注意，[IImage] 為可釋放資源，使用後應呼叫 `dispose()` 或採用其他方便的釋放模式。

使用 `getImage` 來渲染單一投影片或形狀。使用 `getImages` 來渲染多張投影片。使用 [Images](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/images/) 方法載入圖像，使用 `addImage` 搭配 [IImage] 將圖像加入投影片，並使用 `replaceImage` 搭配 [IImage] 來更新現有投影片圖像。

一個典型的使用新 API 的情境可能如下：

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // 從磁碟上的檔案實例化一個可釋放的 IImage。
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // 透過將 IImage 實例加入簡報的 images 以建立 PowerPoint 圖像。
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 在第 1 張投影片上新增圖片形狀
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // 取得代表第 1 張投影片的 IImage 實例。
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // 將圖像儲存至磁碟。
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **以現代化 API 取代舊代碼**

一般而言，您需要將使用 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 與 [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) 的呼叫，改為使用 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 的新方法。

Legacy/deprecated API:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
Modern API:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **取得投影片縮圖**

Legacy/deprecated API:

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

Modern API:

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

### **取得形狀縮圖**

Legacy/deprecated API:

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

Modern API:

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

### **取得簡報縮圖**

Legacy/deprecated API:

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

Modern API:

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

### **將圖片加入簡報**

Legacy/deprecated API:

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

Modern API:

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

## **已過時方法及其在現代化 API 中的取代方案**

### **Presentation**
| 方法簽章 | 取代方法簽章 |
|---|---|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| 方法簽章 | 取代方法簽章 |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| 方法簽章 | 取代方法簽章 |
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
| 方法簽章 | 取代方法簽章 |
|---|---|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| 方法簽章 | 取代方法簽章 |
|---|---|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| 方法簽章 | 取代方法簽章 |
|---|---|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| 方法簽章 | 取代方法簽章 |
|---|---|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| 方法簽章 | 取代方法簽章 |
|---|---|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D 的 API 支援**

使用 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的方法已宣告為過時，且沒有直接的現代化 API 取代。

請改用現代化 API 的影像渲染方法，取代渲染至 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的 API：

[Slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **常見問題**

**相較於 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)，[IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 的實際好處是什麼？**

[IImage] 統一了點陣與向量圖像的操作，並可透過 [ImageFormat] 輕鬆儲存為各種格式，簡化了圖像處理流程。

**現代化 API 會影響產生縮圖的效能嗎？**

從 `getThumbnail` 轉換為 `getImage` 不會使效能變差：新方法提供相同的選項與尺寸產生圖像功能，同時保留渲染選項的支援。具體的效能增減取決於使用情境，但在功能上兩者是等價的。