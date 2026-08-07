---
title: Оптимизация управления изображениями в PowerPoint с помощью Python
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/python-net/image/
keywords:
- добавить изображение
- добавить картинку
- добавить битовую карту
- заменить изображение
- заменить картинку
- из интернета
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- добавить EMF
- добавить WMF
- добавить TIFF
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Оптимизируйте управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET, повышая производительность и автоматизируя ваш рабочий процесс."
---
## **Введение**

Изображения делают презентации более увлекательными и интересными. В Microsoft PowerPoint вы можете вставлять картинки из файла, интернета или других источников на слайды. Аналогично, Aspose.Slides позволяет добавлять изображения на слайды несколькими способами.

{{% alert title="Tip" color="primary" %}}
Aspose предоставляет бесплатные конвертеры —[JPEG в PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Если вы хотите добавить изображение как объект рамки — особенно если планируете использовать стандартные параметры форматирования, такие как изменение размера или применение эффектов — см. [Добавление рамок изображений в презентации с помощью Python](https://docs.aspose.com/slides/ru/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Вы можете использовать операции ввода‑вывода изображений и презентаций для конвертации изображений между форматами. См. эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/ru/python-net/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/ru/python-net/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/ru/python-net/conversion/jpg-to-png/); конвертировать [PNG в JPG](https://products.aspose.com/slides/ru/python-net/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/ru/python-net/conversion/png-to-svg/); и конвертировать [SVG в PNG](https://products.aspose.com/slides/ru/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides поддерживает работу с изображениями в популярных форматах, таких как JPEG, PNG, BMP, GIF и другие.

## **Добавление локальных изображений на слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд презентации. Ниже приведён пример на Python, показывающий, как добавить изображение на слайд:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление изображений из интернета на слайды**

Если нужное вам изображение недоступно на компьютере, вы можете вставить его напрямую из интернета.

Ниже приведён пример на Python, показывающий, как добавить изображение по URL на слайд:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Скачать необработанные байты изображения.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление изображений в шаблоны слайдов**

Шаблон слайда — это верхнеуровневый слайд, который хранит и управляет информацией — темой, макетом и т.д. — для всех дочерних слайдов. Когда вы добавляете изображение в шаблон слайда, это изображение появляется на каждом слайде, использующем данный шаблон.

Ниже приведён пример на Python, показывающий, как добавить изображение в шаблон слайда:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление изображений в качестве фона слайдов**

Вы можете использовать картинку в качестве фона для одного или нескольких слайдов. Подробности см. в *[Установке изображений в качестве фона для слайдов](/slides/ru/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентацию**

Контент SVG можно добавить в презентацию с помощью класса [SvgImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/svgimage/). Получившееся SVG‑изображение можно добавить в коллекцию изображений презентации и использовать для создания рамки изображения.

Ниже приведён пример на Python, импортирующий автономную строку SVG. Все изображения, стили и другие ресурсы, используемые этим SVG, встроены непосредственно в содержание SVG.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Конвертация SVG в набор фигур**

Aspose.Slides преобразует SVG в набор фигур аналогично обработке SVG в PowerPoint.

![Меню PowerPoint](img_01_01.png)

Эта функциональность предоставляется перегрузкой метода [add_group_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_group_shape/) класса [ShapeCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/), принимающего в качестве первого аргумента объект [SvgImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/svgimage/).

Ниже показан пример кода, демонстрирующий, как конвертировать файл SVG в набор фигур.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Прочитать содержимое SVG‑файла.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Создать объект SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Получить размер слайда.
        slide_size = presentation.slide_size.size

        # Преобразовать SVG‑изображение в группу фигур и масштабировать её до размеров слайда.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Сохранить презентацию в формате PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление изображений в формате EMF на слайды**

Aspose.Slides для Python позволяет вставлять изображения Enhanced Metafile (EMF) в презентации.

Ниже приведён пример на Python, демонстрирующий эту возможность:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Замена изображений в коллекции изображений**

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации, включая те, которые используются фигурами слайдов. В данном разделе описаны несколько подходов к обновлению изображений в коллекции. API предоставляет простые методы для замены изображения сырыми байтовыми данными, экземпляром [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) или другим изображением, уже существующим в коллекции.

Выполните следующие шаги:

1. Загрузите презентацию, содержащую изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Загрузите новое изображение из файла в массив байтов.
1. Замените целевое изображение новым, используя массив байтов.
1. При желании загрузите изображение в объект [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) и замените целевое изображение этим объектом.
1. Либо замените целевое изображение другим изображением, уже присутствующим в коллекции изображений презентации.
1. Сохраните изменённую презентацию в файл PPTX.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Создать экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation("sample.pptx") as presentation:

    # Первый способ.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # Второй способ.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # Третий способ.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Сохранить презентацию в файл.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
С помощью бесплатного конвертера Aspose — [Text to GIF](https://products.aspose.app/slides/ru/text-to-gif) — вы можете легко анимировать текст и создавать GIF‑изображения из текста.
{{% /alert %}}

## **FAQ**

**Сохраняется ли оригинальное разрешение изображения после вставки?**

Да. Исходные пиксели сохраняются, но конечный вид зависит от того, как [изображение](/slides/ru/python-net/picture-frame/) масштабируется на слайде и какой уровень сжатия применяется при сохранении.

**Как лучше всего заменить один и тот же логотип на десятках слайдов одновременно?**

Разместите логотип на мастере слайда или макете и замените его в коллекции изображений презентации — изменения распространятся на все элементы, использующие данный ресурс.

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**

Да. Вы можете конвертировать SVG в группу фигур, после чего отдельные части становятся редактируемыми с помощью стандартных свойств фигур.

**Как установить картинку в качестве фона для нескольких слайдов сразу?**

[Назначьте изображение как фон](/slides/ru/python-net/presentation-background/) на мастере слайда или соответствующем макете — все слайды, использующие этот мастер/макет, унаследуют фон.

**Как предотвратить слишком большой размер презентации из‑за множества изображений?**

Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте сжатие при сохранении и размещайте часто повторяющуюся графику на мастере, где это уместно.