---
title: Tăng cường xử lý ảnh với Modern API
linktitle: Modern API
type: docs
weight: 237
url: /vi/java/modern-api/
keywords:
- API hiện đại
- vẽ
- hình thu nhỏ slide
- slide sang ảnh
- hình thu nhỏ hình dạng
- hình dạng sang ảnh
- hình thu nhỏ bản trình bày
- bản trình bày sang ảnh
- thêm ảnh
- thêm hình
- Java
- Aspose.Slides
description: "Hiện đại hoá quá trình xử lý hình ảnh slide bằng cách thay thế các API hình ảnh đã lỗi thời bằng Java Modern API để tự động hoá PowerPoint và OpenDocument một cách liền mạch."
---
## **Giới thiệu**

Trong lịch sử, Aspose Slides có phụ thuộc vào java.awt và trong API công cộng có các lớp sau đây từ đó:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Kể từ phiên bản 24.4, API công cộng này được khai báo là lỗi thời.

Để loại bỏ phụ thuộc vào các lớp này, chúng tôi đã thêm cái gọi là “Modern API” - tức là API nên được sử dụng thay cho API lỗi thời, các chữ ký của nó chứa phụ thuộc vào [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) được khai báo là lỗi thời và hỗ trợ của nó đã bị loại bỏ khỏi API công cộng của Slides.

Trong các phiên bản hiện tại, coi API công cộng phụ thuộc vào các kiểu java.awt là lối cũ/lỗi thời. Sử dụng Modern API cho mã mới và khi di chuyển các quy trình xử lý ảnh hiện có.

## **Modern API**

Đã thêm các lớp và enum sau vào API công cộng:

- [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) - đại diện cho hình ảnh raster hoặc vector.
- [ImageFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imageformat/) - đại diện cho định dạng tệp của hình ảnh.
- [Images](https://reference.aspose.com/slides/vi/java/com.aspose.slides/images/) - các phương thức để khởi tạo và làm việc với giao diện [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/).

Lưu ý rằng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) có thể giải phóng và việc sử dụng nó nên được theo sau bởi lời gọi `dispose()` hoặc một mẫu giải phóng tiện lợi khác.

Sử dụng `getImage` để render một slide hoặc shape duy nhất. Sử dụng `getImages` để render nhiều slide của bản trình bày. Sử dụng các phương thức của [Images](https://reference.aspose.com/slides/vi/java/com.aspose.slides/images/) để tải hình ảnh, `addImage` với [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) để thêm chúng vào bản trình bày, và `replaceImage` với [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) để cập nhật hình ảnh trong bản trình bày hiện có.

Một kịch bản điển hình khi sử dụng API mới có thể trông như sau:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // khởi tạo một thể hiện có thể giải phóng của IImage từ tệp trên ổ đĩa.
    IImage image = Images.fromFile("image.png");
    try {
        // tạo một hình ảnh PowerPoint bằng cách thêm một thể hiện IImage vào hình ảnh của bản trình bày.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // thêm một picture shape trên slide #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // lấy một thể hiện của IImage đại diện cho slide #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // lưu hình ảnh vào ổ đĩa.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay thế mã cũ bằng Modern API**

Nhìn chung, bạn sẽ cần thay thế các gọi hàm sử dụng [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) và ImageIO bằng các phương thức mới sử dụng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/).

API cũ/lỗi thời:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
API mới:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Lấy hình thu nhỏ slide**

API cũ/lỗi thời:

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

API mới:

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

### **Lấy hình thu nhỏ shape**

API cũ/lỗi thời:

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

API mới:

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

### **Lấy hình thu nhỏ bản trình bày**

API cũ/lỗi thời:

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

API mới:

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

### **Thêm ảnh vào bản trình bày**

API cũ/lỗi thời:

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

API mới:

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

## **Phương thức lỗi thời và thay thế trong Modern API**

### **Presentation**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
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
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Hỗ trợ API cho Graphics2D**

Các phương thức có [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) được khai báo là lỗi thời và không có bản thay thế Modern API trực tiếp.

Sử dụng các phương thức render hình ảnh của Modern API thay vì API render tới [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Câu hỏi thường gặp**

**Tại sao [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) bị loại bỏ?**

Hỗ trợ cho [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) bị lỗi thời trong API công cộng để thống nhất việc render và xử lý ảnh, loại bỏ các phụ thuộc đặc thù nền tảng, và chuyển sang cách tiếp cận đa nền tảng với [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/). Sử dụng `getImage` hoặc `getImages` thay vì render tới [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Lợi ích thực tiễn của [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) so với [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) là gì?**

[IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) hợp nhất việc làm việc với cả ảnh raster và vector và đơn giản hoá việc lưu sang nhiều định dạng khác nhau qua [ImageFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imageformat/).

**Modern API có ảnh hưởng đến hiệu năng tạo hình thu nhỏ không?**

Chuyển từ `getThumbnail` sang `getImage` không làm giảm hiệu năng: các phương thức mới cung cấp cùng khả năng tạo ảnh với các tùy chọn và kích thước, đồng thời vẫn hỗ trợ các tùy chọn render. Lợi ích hoặc giảm hiệu năng cụ thể phụ thuộc vào kịch bản, nhưng về chức năng các thay thế là tương đương.