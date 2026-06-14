---
title: Cải thiện Xử lý Hình ảnh với Modern API
linktitle: API Hiện đại
type: docs
weight: 237
url: /vi/androidjava/modern-api/
keywords:
- android.graphics
- API hiện đại
- vẽ
- ảnh thu nhỏ slide
- slide thành ảnh
- ảnh thu nhỏ shape
- shape thành ảnh
- ảnh thu nhỏ bản trình bày
- bản trình bày thành ảnh
- thêm ảnh
- thêm hình
- Android
- Java
- Aspose.Slides
description: "Hiện đại hoá quy trình xử lý hình ảnh slide bằng cách thay thế các API hình ảnh đã lỗi thời bằng Java Modern API để tự động hoá PowerPoint và OpenDocument một cách liền mạch."
---
## **Giới thiệu**

Lịch sử, Aspose Slides phụ thuộc vào android.graphics và trong API công cộng có các lớp sau từ đó:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

Từ phiên bản 24.4, API công cộng này được đánh dấu là không còn dùng nữa.

Để loại bỏ phụ thuộc vào các lớp này, chúng tôi đã thêm “Modern API” – tức là API nên được sử dụng thay cho API đã lỗi thời, các chữ ký của nó không còn phụ thuộc vào [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). [Canvas](https://developer.android.com/reference/android/graphics/Canvas) được đánh dấu không còn dùng và hỗ trợ của nó đã được loại bỏ khỏi API Slides công cộng.

Trong các phiên bản hiện tại, hãy coi API công cộng phụ thuộc vào các kiểu android.graphics là lạc hậu/không dùng nữa. Sử dụng Modern API cho mã mới và khi di chuyển các quy trình xử lý ảnh hiện có.

## **Modern API**

Thêm các lớp và enum sau vào API công cộng:

- [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) - đại diện cho ảnh raster hoặc vector.
- [ImageFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imageformat/) - đại diện cho định dạng tệp ảnh.
- [Images](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/images/) - các phương thức để tạo thể hiện và làm việc với giao diện [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/).

Lưu ý rằng [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) có thể được giải phóng và việc sử dụng nó nên được kết thúc bằng lời gọi `dispose()` hoặc mẫu giải phóng tiện lợi khác.

Sử dụng `getImage` để render một slide hoặc shape duy nhất. Sử dụng `getImages` để render nhiều slide của bản trình bày. Sử dụng các phương thức của [Images](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/images/) để tải ảnh, `addImage` với [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) để thêm chúng vào bản trình bày, và `replaceImage` với [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) để cập nhật ảnh trong bản trình bày hiện có.

Một kịch bản điển hình khi sử dụng API mới có thể trông như sau:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // tạo một thể hiện có thể giải phóng của IImage từ tệp trên ổ đĩa.
    IImage image = Images.fromFile("image.png");
    try {
        // tạo một ảnh PowerPoint bằng cách thêm một thể hiện của IImage vào bộ sưu tập ảnh của bản trình bày.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // thêm một hình dạng ảnh vào slide số 1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // lấy một thể hiện của IImage đại diện cho slide số 1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // lưu ảnh vào ổ đĩa.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay thế mã cũ bằng Modern API**

Nói chung, bạn sẽ cần thay thế các lời gọi sử dụng [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) bằng các phương thức mới sử dụng [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/).

API lạc hậu/không dùng nữa:
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

### **Lấy Thumbnail của Slide**

API lạc hậu/không dùng nữa:

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

### **Lấy Thumbnail của Shape**

API lạc hậu/không dùng nữa:

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

### **Lấy Thumbnail của Presentation**

API lạc hậu/không dùng nữa:

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

### **Thêm Ảnh vào Presentation**

API lạc hậu/không dùng nữa:

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

## **Các phương thức đã lỗi thời và thay thế trong Modern API**

### **Presentation**
| Method Signature | Replacement Method Signature |
|---|---|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Method Signature | Replacement Method Signature |
|---|---|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Method Signature | Replacement Method Signature |
|---|---|
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
| Method Signature | Replacement Method Signature |
|---|---|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Method Signature | Replacement Method Signature |
|---|---|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Method Signature | Replacement Method Signature |
|---|---|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Method Signature | Replacement Method Signature |
|---|---|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Method Signature | Replacement Method Signature |
|---|---|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Hỗ trợ API cho Canvas**

Các phương thức có [Canvas](https://developer.android.com/reference/android/graphics/Canvas) được đánh dấu không còn dùng và không có bản thay thế Modern API trực tiếp.

Sử dụng các phương thức render ảnh của Modern API thay vì API render tới [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **Câu hỏi thường gặp**

**Tại sao android.graphics.Canvas bị loại bỏ?**

Hỗ trợ [Canvas](https://developer.android.com/reference/android/graphics/Canvas) đã bị đánh dấu không còn dùng trong API công cộng để thống nhất việc render và ảnh, loại bỏ các phụ thuộc vào nền tảng cụ thể, và chuyển sang cách tiếp cận đa nền tảng với [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/). Sử dụng `getImage` hoặc `getImages` thay vì render tới [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**Lợi ích thực tế của [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) so với [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) là gì?**

[IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) thống nhất việc làm việc với cả ảnh raster và vector và đơn giản hoá việc lưu sang các định dạng khác nhau qua [ImageFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imageformat/).

**Modern API có ảnh hưởng đến hiệu năng tạo thumbnail không?**

Chuyển từ `getThumbnail` sang `getImage` không làm giảm hiệu năng: các phương thức mới cung cấp cùng khả năng tạo ảnh với các tùy chọn và kích thước, đồng thời vẫn hỗ trợ các tùy chọn render. Lợi nhuận hoặc giảm hiệu năng cụ thể phụ thuộc vào kịch bản, nhưng về chức năng các thay thế là tương đương.