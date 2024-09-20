---
title: Современный API
type: docs
weight: 237
url: /python-java/modern-api/
keywords: "Кроссплатформенный современный API"
description: "Современный API"
---

## Введение

Исторически Aspose Slides имеет зависимость от java.awt и в публичном API содержит следующие классы оттуда:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Начиная с версии 24.4, этот публичный API объявлен устаревшим.

Чтобы избавиться от зависимостей на эти классы, мы добавили так называемый "Современный API" — т.е. API, который следует использовать вместо устаревшего, чьи сигнатуры содержат зависимости от BufferedImage. Graphics2D объявлен устаревшим, и его поддержка удаляется из публичного API Slides.

Удаление устаревшего публичного API с зависимостями от System.Drawing будет выполнено в выпуске 24.8.

## Современный API

В публичный API добавлены следующие классы и перечисления:

- IImage - представляет растровое или векторное изображение.
- ImageFormat - представляет файловый формат изображения.
- Images - методы для создания экземпляров и работы с интерфейсом IImage.

Обратите внимание, что IImage является допустимым для вызова (он реализует интерфейс IDisposable и его использование должно быть обернуто в using или завершающее другим удобным способом).

Типичный сценарий использования нового API может выглядеть следующим образом:

``` python
from asposeslides.api import Presentation, SaveFormat, Images, ShapeType, ImageFormat
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension

pres = Presentation();

# создаем экземпляр IImage из файла на диске.
image = Images.fromFile("image.png");

# создаем PowerPoint изображение, добавляя экземпляр IImage в изображения презентации.
ppImage = pres.getImages().addImage(image);
image.dispose();

# добавляем форму изображения на слайд #1
pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

# получаем экземпляр IImage, представляющий слайд #1.
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));

# сохраняем изображение на диске.
slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
slideImage.dispose();

pres.dispose();
```

## Замена старого кода на Современный API

В общем, вам нужно будет заменить вызов старого метода, используя ImageIO, на новый.

Старый:
``` python
image_format = "PNG"
buffImage = pres.getSlides().get_Item(0).getThumbnail(Dimension(1920, 1080))
ImageIO.write(buffImage, image_format, File("image.png"))
```
Новый:
``` python
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));
slideImage.save("image.png", ImageFormat.Png);
```

### Получение миниатюры слайда

Код, использующий устаревший API:

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

Современный API:

``` python
from asposeslides.api import Presentation, ImageFormat

pres = Presentation("pres.pptx");

slideImage = pres.getSlides().get_Item(0).getImage();
slideImage.save("slide1.png", ImageFormat.Png);
slideImage.dispose();

pres.dispose();
```

### Получение миниатюры формы

Код, использующий устаревший API:

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

Современный API:

``` python
from asposeslides.api import Presentation, ImageFormat

pres = Presentation("pres.pptx");

shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
shapeImage.save("shape.png", ImageFormat.Png);
shapeImage.dispose();

pres.dispose();
```

### Получение миниатюры презентации

Код, использующий устаревший API:

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

Современный API:

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

### Добавление изображения в презентацию

Код, использующий устаревший API:

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

Современный API:

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

## Методы, которые будут удалены и их замена в Современном API

### Презентация
| Сигнатура метода                                | Сигнатура заменяющего метода                             |
|------------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### Форма
| Сигнатура метода                                                      | Сигнатура заменяющего метода                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                            | public final IImage getImage()                                   |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### Слайд
| Сигнатура метода                                                      | Сигнатура заменяющего метода                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                            | public final IImage getImage()                                       |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY)           |
| public final BufferedImage getThumbnail(IRenderingOptions options)   | public final IImage getImage(IRenderingOptions options)              |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options)       | public final IImage getImage(ITiffOptions options)                  |
| public final BufferedImage getThumbnail(Dimension imageSize)       | public final IImage getImage(Dimension imageSize)                   |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Будет удалено полностью                                          |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Будет удалено полностью                                       |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Будет удалено полностью                                       |

### Выход
| Сигнатура метода                                                | Сигнатура заменяющего метода                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image)    |

### Коллекция изображений
| Сигнатура метода                          | Сигнатура заменяющего метода               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| Сигнатура метода                     | Сигнатура заменяющего метода   |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### Формат шаблона
| Сигнатура метода                                          | Сигнатура заменяющего метода                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)   | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) |public final IImage getTile(Color background, Color foreground) |

### Эффективные данные формата шаблона
| Сигнатура метода                                          | Сигнатура заменяющего метода                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## Поддержка API для Graphics2D будет прекращена

Методы с [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) объявлены устаревшими, и их поддержка будет удалена из публичного API.

Часть API, которая использует его, будет удалена:

[Слайд](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)