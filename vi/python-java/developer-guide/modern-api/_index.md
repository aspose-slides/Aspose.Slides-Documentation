---
title: API Hiện đại
type: docs
weight: 237
url: /vi/python-java/modern-api/
keywords: "CrossPlatform API Hiện đại"
description: "API Hiện đại"
---
## Giới thiệu

Trong lịch sử, Aspose Slides phụ thuộc vào java.awt và trong API công cộng có các lớp sau từ đó:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Kể từ phiên bản 24.4, API công cộng này được khai báo là đã lỗi thời.

Để loại bỏ các phụ thuộc vào các lớp này, chúng tôi đã thêm cái gọi là “Modern API” – tức là API nên được sử dụng thay cho API đã lỗi thời, các chữ ký của nó không còn phụ thuộc vào BufferedImage. Graphics2D được khai báo là đã lỗi thời và hỗ trợ của nó đã bị loại bỏ khỏi API Slides công cộng.

Việc loại bỏ API công cộng đã lỗi thời có phụ thuộc vào System.Drawing sẽ xuất hiện trong bản phát hành 24.8.

## API hiện đại

Đã thêm các lớp và enum sau vào API công cộng:

- IImage – đại diện cho ảnh raster hoặc vector.
- ImageFormat – đại diện cho định dạng tệp của ảnh.
- Images – các phương thức để tạo và làm việc với giao diện IImage.

Lưu ý rằng IImage là đối tượng có thể giải phóng (nó triển khai giao diện IDisposable và việc sử dụng nó nên được bao bọc trong using hoặc giải phóng theo cách thuận tiện khác).

Một kịch bản điển hình khi sử dụng API mới có thể trông như sau:

``` python
from asposeslides.api import Presentation, SaveFormat, Images, ShapeType, ImageFormat
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension

pres = Presentation();

# khởi tạo một thể hiện có thể giải phóng của IImage từ tệp trên đĩa.
image = Images.fromFile("image.png");

# tạo một hình ảnh PowerPoint bằng cách thêm một thể hiện của IImage vào các hình ảnh của bản trình bày.
ppImage = pres.getImages().addImage(image);
image.dispose();

# thêm một hình dạng hình ảnh vào slide số 1
pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

# lấy một thể hiện của IImage đại diện cho slide số 1.
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));

# lưu hình ảnh vào đĩa.
slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
slideImage.dispose();

pres.dispose();
```

## Thay thế mã cũ bằng API hiện đại

Nói chung, bạn sẽ cần thay thế lời gọi tới phương thức cũ sử dụng ImageIO bằng phương thức mới.

Old:
``` python
image_format = "PNG"
buffImage = pres.getSlides().get_Item(0).getThumbnail(Dimension(1920, 1080))
ImageIO.write(buffImage, image_format, File("image.png"))
```
New:
``` python
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));
slideImage.save("image.png", ImageFormat.Png);
```

### Lấy hình thu nhỏ của slide

Mã sử dụng API đã lỗi thời:

``` python
from asposeslides.api import Presentation
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension


pres = Presentation("pres.pptx");

slideImage = pres.getSlides().get_Item(0).getThumbnail();
image_format = "PNG"
ImageIO.write(slideImage, image_format, File("slide1.png"))

pres.dispose();
```

API hiện đại:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

slideImage = pres.getSlides().get_Item(0).getImage();
slideImage.save("slide1.png", ImageFormat.Png);
slideImage.dispose();

pres.dispose();
```

### Lấy hình thu nhỏ của shape

Mã sử dụng API đã lỗi thời:

``` python
from asposeslides.api import Presentation
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension


pres = Presentation("pres.pptx");

shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
image_format = "PNG"
ImageIO.write(shapeImage, image_format, File("shape.png"))

pres.dispose();
```

API hiện đại:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
shapeImage.save("shape.png", ImageFormat.Png);
shapeImage.dispose();

pres.dispose();
```

### Lấy hình thu nhỏ của presentation

Mã sử dụng API đã lỗi thời:

``` python
from asposeslides.api import Presentation, RenderingOptions
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension


pres = Presentation("pres.pptx");

image_format = "PNG"
rendering_options = RenderingOptions();
bitmaps = pres.getThumbnails(rendering_options, Dimension(1980, 1028));

for index in range(bitmaps.length):
    thumbnail = bitmaps[index];
    ImageIO.write(thumbnail, "PNG", File("slide" + str(index) + ".png"));
    
pres.dispose();
```

API hiện đại:

``` python
from asposeslides.api import Presentation, RenderingOptions, ImageFormat
from java.awt import Dimension


pres = Presentation("pres.pptx");

rendering_options = RenderingOptions();
images = pres.getImages(rendering_options, Dimension(1980, 1028));

for index in range(images.length):
    thumbnail = images[index];
    thumbnail.save("slide" + str(index) + ".png", ImageFormat.Png);
    thumbnail.dispose();

pres.dispose();
```

### Thêm hình ảnh vào presentation

Mã sử dụng API đã lỗi thời:

``` python
from asposeslides.api import Presentation, ShapeType
from javax.imageio import ImageIO
from java.io import File


pres = Presentation();

bufferedImages = ImageIO.read(File("image.png"));
ppImage = pres.getImages().addImage(bufferedImages);

pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

pres.dispose();
```

API hiện đại:

``` python
from asposeslides.api import Presentation, ShapeType, Images
from java.awt import Dimension


pres = Presentation();

image = Images.fromFile("image.png");
ppImage = pres.getImages().addImage(image);
image.dispose();

pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

pres.dispose();
```

## Các phương thức sẽ bị loại bỏ và thay thế trong API hiện đại

### Presentation
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### Shape
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### Slide
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Will be deleted completely |

### Output
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### ImageCollection
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### PatternFormat
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### PatternFormatEffectiveData
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|-----------------------------------------------|---------------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## Hỗ trợ API cho Graphics2D sẽ ngừng

Các phương thức có [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) được khai báo là đã lỗi thời và hỗ trợ của chúng sẽ bị loại bỏ khỏi API công cộng.

Phần API sử dụng nó sẽ bị loại bỏ:

[Slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)