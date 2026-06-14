---
title: "Nâng cao xử lý hình ảnh với Modern API"
linktitle: "API Hiện đại"
type: docs
weight: 237
url: /vi/nodejs-java/modern-api/
keywords:
- "API hiện đại"
- "vẽ"
- "thu nhỏ slide"
- "slide thành hình ảnh"
- "thu nhỏ shape"
- "shape thành hình ảnh"
- "thu nhỏ bản trình chiếu"
- "bản trình chiếu thành hình ảnh"
- "thêm hình ảnh"
- "thêm ảnh"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Hiện đại hóa quy trình xử lý hình ảnh slide bằng cách thay thế các API xử lý ảnh đã lỗi thời bằng Modern API của JavaScript để tự động hoá PowerPoint và OpenDocument một cách liền mạch."
---
## **Giới thiệu**

Lịch sử, Aspose Slides phụ thuộc vào java.awt và trong API công cộng có các lớp sau từ đó:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Kể từ phiên bản 24.4, API công cộng này được khai báo là lỗi thời.

Để loại bỏ phụ thuộc vào các lớp này, chúng tôi đã thêm cái gọi là “Modern API” – tức là API nên được sử dụng thay cho API đã lỗi thời, các chữ ký của nó không còn phụ thuộc vào [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) được khai báo là lỗi thời và hỗ trợ của nó đã bị loại bỏ khỏi API Slides công cộng.

Trong các phiên bản hiện tại, hãy coi API công cộng phụ thuộc vào các kiểu java.awt là legacy/lỗi thời. Sử dụng Modern API cho mã mới và khi di chuyển các quy trình xử lý ảnh hiện có.

## **Modern API**

Đã thêm các lớp và enum sau vào API công cộng:

- [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) – đại diện cho hình raster hoặc vector.
- [ImageFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imageformat/) – đại diện cho định dạng tệp của hình ảnh.
- [Images](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/images/) – các phương thức để khởi tạo và làm việc với lớp [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/).

Lưu ý rằng [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) có thể được giải phóng và việc sử dụng nó nên được theo sau bởi một lời gọi `dispose()` hoặc một mẫu giải phóng tiện lợi khác.

Sử dụng `getImage` để render một slide hoặc shape đơn. Sử dụng `getImages` để render nhiều slide của bản trình chiếu. Sử dụng các phương thức của [Images](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/images/) để tải hình ảnh, `addImage` cùng [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) để thêm chúng vào bản trình chiếu, và `replaceImage` cùng [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) để cập nhật một hình ảnh hiện có trong bản trình chiếu.

Một kịch bản điển hình khi sử dụng API mới có thể như sau:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // khởi tạo một thể hiện IImage có thể giải phóng từ tệp trên ổ đĩa.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // tạo một hình ảnh PowerPoint bằng cách thêm một thể hiện IImage vào các hình ảnh của bản trình chiếu.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // thêm một shape hình ảnh vào slide số 1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // lấy một thể hiện IImage đại diện cho slide số 1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // lưu hình ảnh vào ổ đĩa.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay thế mã cũ bằng Modern API**

Nói chung, bạn sẽ cần thay thế các lời gọi sử dụng [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) và [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) bằng các phương thức mới sử dụng [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/).

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

### **Lấy thumbnail của Slide**

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

### **Lấy thumbnail của Shape**

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

### **Lấy thumbnail của Presentation**

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

### **Thêm hình ảnh vào Presentation**

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

## **Các phương thức lỗi thời và thay thế trong Modern API**

### **Presentation**
| Chữ ký phương thức | Phương thức thay thế |
|---|---|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Chữ ký phương thức | Phương thức thay thế |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Chữ ký phương thức | Phương thức thay thế |
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
| Chữ ký phương thức | Phương thức thay thế |
|---|---|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Chữ ký phương thức | Phương thức thay thế |
|---|---|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Chữ ký phương thức | Phương thức thay thế |
|---|---|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Chữ ký phương thức | Phương thức thay thế |
|---|---|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Chữ ký phương thức | Phương thức thay thế |
|---|---|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Hỗ trợ API cho Graphics2D**

Các phương thức có [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) được khai báo là lỗi thời và không có thay thế Modern API trực tiếp.

Sử dụng các phương thức render hình ảnh của Modern API thay cho API render tới [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**Lợi ích thực tiễn của [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) so với [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) là gì?**

[IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) hợp nhất việc làm việc với cả hình raster và vector và đơn giản hoá việc lưu sang nhiều định dạng thông qua [ImageFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imageformat/).

**Modern API có ảnh hưởng tới hiệu năng tạo thumbnail không?**

Chuyển từ `getThumbnail` sang `getImage` không làm suy giảm các kịch bản: các phương thức mới cung cấp cùng khả năng tạo hình ảnh với các tùy chọn và kích thước, đồng thời giữ lại hỗ trợ cho các tùy chọn render. Lợi nhuận hay giảm hiệu năng cụ thể phụ thuộc vào kịch bản, nhưng về chức năng các thay thế là tương đương.