---
title: "Оптимизация управления изображениями в презентациях с помощью Python"
linktitle: "Управление изображениями"
type: docs
weight: 10
url: /ru/python-net/image/
keywords:
- "добавить изображение"
- "добавить картинку"
- "заменить изображение"
- "коллекция изображений"
- "рамка изображения"
- "связанное изображение"
- "фон"
- "добавить PNG"
- "добавить JPG"
- "добавить SVG"
- "SVG в фигуры"
- "внешние ресурсы SVG"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Python"
- "Aspose.Slides"
description: "Узнайте, как добавлять, повторно использовать, связывать, заменять и управлять растровыми и SVG-изображениями в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET."
---
## **Введение**

Aspose.Slides for Python via .NET предоставляет несколько способов работы с изображениями, и каждый из них служит различной цели. Вы можете хранить изображение в презентации, отображать его в рамке изображения, использовать его в качестве фона слайда, ссылаться на внешнее изображение, заменять общий ресурс изображения или преобразовывать SVG‑содержимое в редактируемые фигуры.

В этой статье рассматриваются ресурсы изображений и их использование в презентации. О кадрировании, прозрачности, эффектах, растягивании и другом форматировании, применяемом к отдельной рамке изображения, см. [Рамка изображения](/slides/ru/python-net/picture-frame/).

## **Понимание модели изображений**

- [коллекция изображений презентации](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/) хранит ресурсы изображений, используемые в презентации. Используйте [ImageCollection.add_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/add_image/) для добавления данных изображения и получения ресурса [IPPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ippimage/).
- [рамка изображения](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ipictureframe/) — это фигура, отображающая изображение на слайде, макете или образце. Используйте [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_picture_frame/) чтобы разместить ресурс изображения на слайде.
- Фон слайда использует изображение как часть заливки слайда, а не как форму. Поэтому он не ведет себя как рамка изображения.
- [IPPImage.replace_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ippimage/replace_image/) заменяет ресурс изображения. Если несколько элементов презентации используют этот ресурс, они все используют замену.
- Преобразование SVG в фигуры создаёт редактируемые фигуры слайда. После преобразования содержимое больше не управляется как один ресурс изображения.

Типичный рабочий процесс выглядит так: добавить данные изображения в коллекцию изображений, получить [IPPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ippimage/), а затем использовать этот ресурс в одной или нескольких рамках изображения или заливках.

## **Добавить встроенное изображение**

Чтобы вставить локальное изображение, считайте файл, добавьте его данные в коллекцию изображений и создайте рамку изображения, использующую возвращённый `IPPImage`.

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Изображение, добавленное таким способом, встраивается в презентацию, поэтому полученный файл не зависит от наличия исходного файла изображения.

### **Добавить изображение из интернета**

Когда изображение доступно по HTTP или HTTPS, загрузите его байты, добавьте их в коллекцию изображений презентации и используйте возвращённый ресурс изображения так же, как локальное изображение.

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

В длительно работающих приложениях по возможности переиспользуйте HTTP‑клиент или пул соединений, а не создавайте новое соединение для каждого запроса. Также проверяйте удалённые URL, размеры ответов и типы содержимого, если источник ненадёжный.

## **Повторное использование изображений на разных слайдах**

Если одно и то же изображение требуется несколько раз, добавьте его в презентацию один раз и переиспользуйте полученный [IPPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ippimage/) при создании дополнительных рамок изображения. Это избавляет от многократной загрузки одних и тех же исходных данных и явно показывает связь между общим ресурсом изображения и его использованиями.

Для графики, которая должна автоматически отображаться на многих слайдах, например логотип компании, рассмотрите возможность размещения рамки изображения на [шаблоне слайда](/slides/ru/python-net/slide-master/) или макете вместо добавления эквивалентной фигуры на каждый слайд.

## **Использовать изображение в качестве фона слайда**

Фоновое изображение назначается заливке слайда; оно не добавляется как фигура рамки изображения. Это полезно, когда изображение должно покрывать фон слайда и не должно обрабатываться как обычный объект слайда.

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

Для дополнительных вариантов фона, включая фон шаблона и макета, см. [Фон презентации](/slides/ru/python-net/presentation-background/).

## **Встроенные и связанные изображения**

Встроенные и связанные изображения имеют разные компромиссы в портативности и размере файла:

- **Встроенное изображение:** данные изображения хранятся внутри презентации. Презентация автономна, но размер файла включает данные изображения.
- **Связанное изображение:** презентация сохраняет путь или URL к внешнему изображению. Это может уменьшить размер презентации, но внешний ресурс должен оставаться доступным при открытии или рендеринге презентации.

Связанное изображение можно создать, присвоив внешний путь или URL через [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/ru/python-net/aspose.slides/islidespicture/link_path_long/) вместо встраивания данных изображения.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Используйте связанные изображения только тогда, когда среда развертывания может надёжно обращаться к внешнему ресурсу. Для презентаций, которым необходимо работать офлайн или перемещаться между системами, встроенные изображения обычно безопаснее.

## **Работа с SVG‑изображениями**

SVG — векторный формат, поэтому он полезен для иконок, диаграмм и другой графики, которую нужно масштабировать без потери детализации, характерной для растровых изображений. Aspose.Slides поддерживает SVG как ресурс изображения и как источник редактируемых фигур слайда.

### **Добавить SVG как изображение**

Создайте [SvgImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/svgimage/), добавьте его в коллекцию изображений и поместите полученный ресурс изображения в рамку изображения.

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **Преобразовать SVG в редактируемые фигуры**

Aspose.Slides может преобразовать SVG в группу редактируемых фигур слайда, аналогично соответствующей команде PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Используйте перегрузку [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_group_shape/), которая принимает [ISvgImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/isvgimage/), для выполнения преобразования.

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Используйте преобразование SVG в фигуры, когда отдельные векторные элементы нужно редактировать как фигуры PowerPoint. Если SVG требуется только отобразить, проще оставить его как изображение, что избавляет от создания множества отдельных фигур.

## **Заменить существующий ресурс изображения**

Используйте [IPPImage.replace_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ippimage/replace_image/) когда требуется заменить существующий ресурс изображения. Это особенно полезно для общих графических элементов, например логотипов.

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Если несколько рамок изображений, фонов, шаблонов или макетов используют один и тот же ресурс изображения, замена этого ресурса обновит все его использования. Если нужно изменить только одну рамку, назначьте ей другое изображение вместо замены общего ресурса.

`replace_image` также предоставляет перегрузки, принимающие [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) или другой [IPPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ippimage/).

## **Практические рекомендации по управлению изображениями**

### **Контроль размера презентации**

Большие растровые изображения могут сделать презентацию избыточно большой. Используйте исходные изображения с размерами, соответствующими предполагаемому размеру отображения, переиспользуйте общие ресурсы изображений, где это возможно, и избегайте встраивания повторяющихся копий одного и того же графика в полном разрешении.

Для растровых изображений, которые уже размещены в рамках, [PictureFillFormat.compress_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/compress_image/) может уменьшить данные изображения в соответствии с выбранным разрешением и настройками кадрирования. Это обработка рамки изображения, а не управление коллекцией изображений, поэтому смотрите [Рамка изображения](/slides/ru/python-net/picture-frame/) для связанных операций форматирования.

### **Выбор между встроенным и связанным контентом**

Встраивание делает презентацию портативной, поскольку все необходимые данные изображений идут вместе с файлом. Связывание может уменьшить размер файла, но вводит внешнюю зависимость. Используйте ссылки только тогда, когда такая зависимость приемлема и стабильна.

### **Повторное использование общего брендинга**

Для повторяющихся логотипов, водяных знаков или декоративных графических элементов используйте один ресурс изображения и переиспользуйте его. Если графика относится к дизайну презентации, а не к содержимому слайдов, разместите её на шаблоне или макете, чтобы она наследовалась нужными слайдами.

### **Сделать SVG‑ресурсы портативными**

Самодостаточный SVG легче перемещать и рендерить последовательно, чем SVG, зависящий от внешних файлов или сетевых ресурсов. По возможности встраивайте необходимые ресурсы перед импортом SVG. Преобразовывайте SVG в фигуры только тогда, когда отдельные векторные элементы требуется редактировать.

### **Использовать современный кроссплатформенный API изображений**

Для нового кода Python via .NET используйте API Aspose.Slides [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) и [Images](https://reference.aspose.com/slides/ru/python-net/aspose.slides/images/) вместо устаревших `aspose.pydrawing.Image` или `aspose.pydrawing.Bitmap`. См. [Modern API](/slides/ru/python-net/modern-api/) для рекомендаций по миграции.

WMF и EMF требуют особого рассмотрения. Когда эти форматы передаются через [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/), [ImageCollection.add_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/add_image/) преобразует метафайл в растровое представление PNG перед вставкой. Если важно сохранять данные метафайла, используйте перегрузку [ImageCollection.add_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/add_image/) основанную на потоке. Генерация содержимого EMF из электронных таблиц или других продуктов — отдельный процесс интеграции и выходит за рамки этой статьи.

## **FAQ**

**В чём разница между коллекцией изображений и рамкой изображения?**

Коллекция изображений хранит переиспользуемые ресурсы изображений. Рамка изображения — это фигура слайда, отображающая один из этих ресурсов и предоставляющая специфическое форматирование изображения, такое как кадрирование и эффекты.

**Как лучше всего заменить один и тот же логотип везде?**

Если логотип уже используется как один ресурс изображения, замените этот ресурс с помощью [IPPImage.replace_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ippimage/replace_image/). Для брендинга на уровне всей презентации размещение логотипа на шаблоне или макете также может сократить дублирование содержимого слайдов.

**Почему связанное изображение исчезает на другом компьютере?**

Связанное изображение зависит от внешнего файла или URL. Если ресурс недоступен с другого компьютера, связанное изображение может быть недоступным. Встраивайте изображение, когда презентация должна быть автономной.

**Можно ли отредактировать вставленный SVG как фигуры PowerPoint?**

Да. Преобразуйте SVG с помощью [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_group_shape/); полученная группа содержит редактируемые фигуры слайда, а не одно SVG‑изображение.

**Как можно уменьшить размер презентаций с большим количеством изображений?**

Повторно используйте общие ресурсы изображений, избегайте избыточно больших растровых источников, при необходимости сжимайте подходящие растрированные изображения, размещайте повторяющийся брендинг на шаблонах или макетах и используйте связанные изображения только тогда, когда внешняя зависимость приемлема.