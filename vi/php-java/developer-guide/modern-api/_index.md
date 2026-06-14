---
title: Nâng cao xử lý hình ảnh với Modern API
linktitle: API hiện đại
type: docs
weight: 237
url: /vi/php-java/modern-api/
keywords:
- API hiện đại
- vẽ
- ảnh thu nhỏ slide
- slide sang hình ảnh
- ảnh thu nhỏ hình dạng
- hình dạng sang hình ảnh
- ảnh thu nhỏ bản trình chiếu
- bản trình chiếu sang hình ảnh
- thêm hình ảnh
- thêm ảnh
- PHP
- Aspose.Slides
description: "Hiện đại hoá xử lý hình ảnh slide bằng cách thay thế các API imaging đã lỗi thời bằng PHP Modern API để tự động hóa PowerPoint và OpenDocument một cách liền mạch."
---
## **Giới thiệu**

Trong lịch sử, Aspose Slides có phụ thuộc vào java.awt và trong API công khai có các lớp sau từ đó:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Kể từ phiên bản 24.4, API công khai này được đánh dấu là đã lỗi thời.

Để loại bỏ phụ thuộc vào các lớp này, chúng tôi đã thêm cái được gọi là “Modern API” - tức là API nên được sử dụng thay cho API đã lỗi thời, các chữ ký của nó không còn phụ thuộc vào [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) được đánh dấu là đã lỗi thời và hỗ trợ của nó đã được loại bỏ khỏi API công khai của Slides.

Trong các phiên bản hiện tại, coi API công khai phụ thuộc vào các kiểu java.awt là kế thừa/đã lỗi thời. Sử dụng Modern API cho mã mới và khi di chuyển các quy trình xử lý ảnh hiện có.

## **Modern API**

Đã thêm các lớp và enum sau vào API công khai:

- [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) - đại diện cho hình ảnh raster hoặc vector.
- [ImageFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imageformat/) - đại diện cho định dạng tệp của hình ảnh.
- [Images](https://reference.aspose.com/slides/vi/php-java/aspose.slides/images/) - các phương thức để khởi tạo và làm việc với lớp [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/).

Lưu ý rằng [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) là có thể giải phóng (nên được giải phóng sau khi sử dụng).

Sử dụng `getImage` để vẽ một slide hoặc hình dạng duy nhất. Sử dụng `getImages` để vẽ nhiều slide của bản trình chiếu. Sử dụng các phương thức của [Images](https://reference.aspose.com/slides/vi/php-java/aspose.slides/images/) để tải hình ảnh, `addImage` với [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) để thêm chúng vào bản trình chiếu, và `replaceImage` với [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) để cập nhật một hình ảnh trong bản trình chiếu hiện có.

Một kịch bản điển hình khi sử dụng API mới có thể như sau:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# khởi tạo một thể hiện có thể giải phóng của IImage từ tệp trên đĩa.
$image = Images::fromFile("image.png");

# tạo một hình ảnh PowerPoint bằng cách thêm một thể hiện IImage vào các hình ảnh của bản trình chiếu.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# thêm một hình dạng ảnh trên slide #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# lấy một thể hiện IImage đại diện cho slide #1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# lưu hình ảnh trên đĩa.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Thay thế mã cũ bằng Modern API**

Nói chung, bạn sẽ cần thay thế các lời gọi sử dụng [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) và [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) bằng các phương thức mới sử dụng [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/).

Legacy/deprecated API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
Modern API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **Lấy ảnh thu nhỏ của Slide**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **Lấy ảnh thu nhỏ của Hình dạng**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **Lấy ảnh thu nhỏ của Bản trình chiếu**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$bitmaps = $pres->getThumbnails($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($bitmaps)); $i++)
{
    $thumbnail = $bitmaps[$i];
    $imageio = new Java("javax.imageio.ImageIO");
    $javafile = new Java("java.io.File", "slide" . $i . ".png");
    $imageio->write($thumbnail, "PNG", $javafile);
}

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```

### **Thêm ảnh vào Bản trình chiếu**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;


$pres = new Presentation();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");

$bufferedImages = $imageio->read($javafile);
$ppImage = $pres->getImages()->addImage($bufferedImages);

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\Images;
use aspose\slides\ShapeType;


$pres = new Presentation();

$image = Images::fromFile("image.png");
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

## **Các phương thức đã lỗi thời và thay thế của chúng trong Modern API**

### **Presentation**
| Chữ ký phương thức                               | Chữ ký phương thức thay thế                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Chữ ký phương thức                                                      | Chữ ký phương thức thay thế                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                                        | public final IImage getImage()                                                           |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Chữ ký phương thức                                                      | Chữ ký phương thức thay thế                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement  |

### **Output**
| Chữ ký phương thức                                                | Chữ ký phương thức thay thế                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Chữ ký phương thức                          | Chữ ký phương thức thay thế               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Chữ ký phương thức                     | Chữ ký phương thức thay thế   |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Chữ ký phương thức                                          | Chữ ký phương thức thay thế                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)   | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Chữ ký phương thức                                          | Chữ ký phương thức thay thế                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## **Hỗ trợ API cho Graphics2D**

Các phương thức có [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) được đánh dấu là đã lỗi thời và không có thay thế trực tiếp trong Modern API.

Sử dụng các phương thức vẽ hình ảnh của Modern API thay vì API vẽ lên [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Câu hỏi thường gặp**

**Tại sao [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) bị loại bỏ?**

Hỗ trợ cho [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) đã được đánh dấu là đã lỗi thời trong API công khai để thống nhất việc làm việc với việc render và hình ảnh, loại bỏ các ràng buộc phụ thuộc vào nền tảng cụ thể, và chuyển sang cách tiếp cận đa nền tảng với [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/). Sử dụng `getImage` hoặc `getImages` thay vì render tới [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Lợi ích thực tế của [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) so với [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) là gì?**

[IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) hợp nhất việc làm việc với cả hình ảnh raster và vector và đơn giản hoá việc lưu dưới các định dạng khác nhau thông qua [ImageFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imageformat/).

**Modern API có ảnh hưởng đến hiệu năng tạo ảnh thu nhỏ không?**

Chuyển từ `getThumbnail` sang `getImage` không làm giảm hiệu năng trong các kịch bản: các phương thức mới cung cấp cùng khả năng tạo hình ảnh với các tùy chọn và kích thước, đồng thời vẫn hỗ trợ các tùy chọn render. Lợi ích hoặc giảm hiệu năng cụ thể phụ thuộc vào trường hợp, nhưng về chức năng các thay thế là tương đương.