---
title: Улучшите обработку изображений с помощью современного API в Python
linktitle: Современный API
type: docs
weight: 237
url: /ru/python-java/modern-api/
keywords:
- современный API
- рисование
- миниатюра слайда
- слайд в изображение
- миниатюра фигуры
- фигура в изображение
- миниатюра презентации
- презентация в изображения
- добавить изображение
- добавить картинку
- Python
- Java
- Aspose.Slides
description: "Модернизируйте обработку изображений в Python через Java: рендерьте слайды и фигуры, добавляйте изображения и переходите от устаревших вызовов обработки изображений к современному API Aspose.Slides."
---
## **Introduction**

Aspose.Slides for Python via Java получает доступ к библиотеке Java через JPype. Его устаревший API обработки изображений использовал [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) и [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) из `java.awt`.

Библиотека Java объявила эти API устаревшими, начиная с версии 24.4. Современный API использует [IImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/) для загрузки, рендеринга и сохранения изображений. Используйте его в новом коде Python и при миграции существующих процессов обработки изображений.

{{% alert color="info" title="Note" %}}

Нижеприведённые старые имена методов служат лишь справочными при миграции. Они больше недоступны в текущих версиях. Выполняемые примеры используют Современный API.

Это изменение не устраняет полностью типы `java.awt`: перегрузки, принимающие размер изображения и цвет узора, по‑прежнему принимают [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) и [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

{{% /alert %}}

## **Modern API**

Основные типы для обработки изображений:

- [IImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/) — представляет растровое или векторное изображение.
- [ImageFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imageformat/) — предоставляет константы форматов файлов изображений.
- [Images](https://reference.aspose.com/slides/ru/python-java/aspose.slides/images/) — создаёт изображения, например с помощью [Images.fromFile](https://reference.aspose.com/slides/ru/python-java/aspose.slides/images/#fromFile).

Используйте [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage) или [Shape.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage) для рендеринга отдельного слайда или фигуры. Для рендеринга нескольких слайдов применяйте [Presentation.getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages) с параметрами рендеринга. Перегрузка без аргументов возвращает коллекцию изображений презентации.

Загрузите изображение с помощью [Images.fromFile](https://reference.aspose.com/slides/ru/python-java/aspose.slides/images/#fromFile), добавьте его через [ImageCollection.addImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagecollection/#addImage) или замените существующее изображение в презентации с помощью [PPImage.replaceImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/#replaceImage). Оба метода работы с коллекцией изображений принимают [IImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/).

Освобождайте каждое загруженное или отрендеренное изображение, вызывая его метод `dispose` в блоке `finally`. Презентацию освобождайте с помощью [Presentation.dispose](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#dispose).

### **Prepare the Python Environment**

Установите пакеты, как описано в [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` до запуска JVM, затем импортирует API после запуска JVM. Примеры оставляют JVM работающей, чтобы её можно было переиспользовать. Смотрите раздел [Limitations and API Differences](/slides/ru/python-java/limitations-and-api-differences/#import-the-library) для рекомендаций по жизни ноутбука и JVM.

Примеры, открывающие `pres.pptx`, требуют наличия презентации в рабочем каталоге. Примеры, загружающие `image.png`, требуют существующего файла изображения.

### **Load a Picture and Render a Slide**

Этот пример добавляет картинку на первый слайд и сохраняет слайд как изображение JPEG. [IImage.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/#save) записывает отрендеренное изображение в указанном формате.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Replacing Old Code with Modern API**

Замените устаревшие вызовы миниатюр методами, возвращающими [IImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/), затем сохраняйте результат с помощью [IImage.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/#save). Это устраняет необходимость передавать отрендеренные изображения в [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Render a Slide at a Specified Size**

Замените устаревший вызов `slide.getThumbnail(image_size)` на [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage), используя тот же размер изображения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Getting a Slide Thumbnail**

Замените устаревший вызов `slide.getThumbnail()` на [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage) без аргументов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Getting a Shape Thumbnail**

Замените устаревший вызов `shape.getThumbnail()` на [Shape.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage). Убедитесь, что слайд содержит фигуру, прежде чем обращаться к ней.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Getting a Presentation Thumbnail**

Замените устаревший вызов `presentation.getThumbnails(options, image_size)` на [Presentation.getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages). Используйте [RenderingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/renderingoptions/) для настройки рендеринга.

Итерируйте возвращённый массив напрямую с помощью `enumerate` в Python. Освобождайте каждое полученное изображение в блоке `finally`, чтобы ошибка сохранения не оставила неосвобождённые изображения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Adding a Picture to a Presentation**

Замените загрузку через [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) на [Images.fromFile](https://reference.aspose.com/slides/ru/python-java/aspose.slides/images/#fromFile), затем передайте полученное изображение в [ImageCollection.addImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagecollection/#addImage). Добавьте картинку на слайд и сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Deprecated Methods and Their Replacement in Modern API**

Таблицы используют нотацию вызовов Python. Имена в столбце устаревшего API указывают удалённые методы; используйте ссылки на заменяющие методы. Современные методы рендеринга изображений возвращают объекты [IImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/) вместо Java‑буферизованных изображений.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages) возвращает массив отрендеренных изображений при вызове с параметрами рендеринга.

| Legacy call | Modern replacement |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages) с `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages) с `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages) с `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages) с `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages) с `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages) с `options, image_size` |

Здесь `slides` — это Java‑массив `int[]` с нумерацией слайдов, начинающейся с 1; создать его можно так: `jpype.JArray(jpype.JInt)([1, 3])` для выбора слайдов 1 и 3. `image_size` — это [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| Legacy call | Modern replacement |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage) без аргументов |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage) с `bounds, scale_x, scale_y` |

### **Slide**

| Legacy call | Modern replacement |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage) без аргументов |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage) с `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage) с `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage) с `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage) с `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage) с `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage) с `image_size` |
| `slide.renderToGraphics(options, graphics)` | Нет прямой замены; рендерьте в изображение |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | Нет прямой замены; рендерьте в изображение |
| `slide.renderToGraphics(options, graphics, image_size)` | Нет прямой замены; рендерьте в изображение |

Здесь `options` — это [RenderingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/renderingoptions/), а `tiff_options` — [TiffOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tiffoptions/).

### **Output**

| Legacy call | Modern replacement |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/output/#add) с `path, image`, где `image` — [IImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Legacy call | Modern replacement |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagecollection/#addImage) с объектом [IImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/) |

### **PPImage**

| Legacy call | Modern replacement |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/#getImage) |

Для замены содержимого существующего изображения презентации используйте [PPImage.replaceImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/#replaceImage) с объектом [IImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Legacy call | Modern replacement |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/ru/python-java/aspose.slides/patternformat/#getTile) с `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/ru/python-java/aspose.slides/patternformat/#getTile) с `background, foreground` |

Аргументы цвета по‑прежнему являются объектами Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

### **PatternFormatEffectiveData**

Для эффективных данных узора, возвращаемых Java‑API через JPype, метод‑заменитель сохраняет имя `getTileIImage`.

| Legacy call | Modern replacement |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, возвращает [IImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/) |

## **API Support for Graphics2D**

Устаревшие перегрузки `renderToGraphics` рисовали в переданный контекст [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html). Современный API не имеет прямой замены, рисующей в этот контекст.

Используйте [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage) для рендеринга отдельного слайда или [Presentation.getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages) для рендеринга нескольких слайдов, затем сохраняйте полученные изображения с помощью [IImage.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/#save). Приложения, комбинировавшие рендеринг слайдов с пользовательским рисованием на Java, должны адаптировать шаг композитинга.

## **FAQ**

**Why was the old Java imaging API replaced?**

Modern API переносит загрузку, рендеринг и сохранение изображений в [IImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/iimage/). Это предоставляет единый абстрактный тип изображения вместо раскрытия Java‑буферизованных изображений или графического контекста Java.

**Do I still need Java and JPype?**

Да. Aspose.Slides for Python via Java по‑прежнему работает на JVM. Modern API меняет только вызовы обработки изображений, а не требования к среде выполнения. См. [System Requirements](/slides/ru/python-java/system-requirements/).

**How do I release images in Python?**

Вызывайте `dispose` для каждого изображения, которое загружаете или рендерите, в блоке `finally`. Если рендерите несколько слайдов, освобождайте каждое изображение из полученного массива. Презентацию освобождайте отдельно с помощью [Presentation.dispose](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#dispose).

**Does switching to the Modern API guarantee faster thumbnail generation?**

Ускорения производительности не гарантированы. Замены поддерживают параметры рендеринга, масштабирование и размеры изображений; измеряйте производительность на своих презентациях и настройках вывода.

**Why does the image getter sometimes return a collection?**

[Presentation.getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages) без аргументов возвращает встроенные изображения презентации. Ее перегрузки с параметрами рендеринга возвращают отрендеренные изображения слайдов.