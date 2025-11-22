---
title: Оптимизация управления изображениями в PowerPoint с помощью Python
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/python-net/image/
keywords:
- добавить изображение
- добавить картинку
- добавить bitmap
- заменить изображение
- заменить картинку
- из веба
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- добавить EMF
- добавить WMF
- добавить TIFF
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Оптимизируйте управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET, повышая производительность и автоматизируя ваш рабочий процесс."
---

## **Обзор**

Изображения делают презентации более интересными и захватывающими. В Microsoft PowerPoint вы можете вставлять картинки из файла, интернета или других источников на слайды. Аналогично, Aspose.Slides позволяет добавлять изображения на слайды несколькими способами.

{{% alert  title="Подсказка" color="primary" %}}
Aspose предоставляет бесплатные конвертеры —[JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений.
{{% /alert %}}

{{% alert title="Информация" color="info" %}}
Если вы хотите добавить изображение как объект рамки — especially if you plan to use standard formatting options such as resizing or applying effects — см. [Добавление рамок изображений в презентации с Python](https://docs.aspose.com/slides/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Примечание" color="warning" %}}
Вы можете использовать операции ввода/вывода изображений и презентаций для конвертации изображений между форматами. Смотрите эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); конвертировать [PNG в JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); и конвертировать [SVG в PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides поддерживает работу с изображениями в популярных форматах, таких как JPEG, PNG, BMP, GIF и другие.

## **Добавление локальных изображений на слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд в презентации. Ниже приведён пример на Python, показывающий, как добавить изображение на слайд:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```


## **Добавление изображений из веба на слайды**

Если изображение, которое вы хотите добавить на слайд, недоступно на вашем компьютере, вы можете вставить его напрямую из интернета.

Ниже приведён пример на Python, показывающий, как добавить изображение по URL на слайд:
```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Добавление изображений в мастер‑слайды**

Мастер‑слайд — это слайд верхнего уровня, который хранит и управляет информацией — темой, макетом и т. д. — для всех слайдов ниже. Когда вы добавляете изображение в мастер‑слайд, оно появляется на каждом слайде, использующем этот мастер.

Ниже приведён пример на Python, показывающий, как добавить изображение в мастер‑слайд:
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


## **Установка изображения в качестве фона слайда**

Возможно, вы захотите использовать изображение в качестве фона для конкретного слайда или нескольких слайдов. Подробности см. в статье [Установить изображение в качестве фона слайда](https://docs.aspose.com/slides/python-net/presentation-background/#set-image-as-background-for-slide).

## **Добавление SVG в презентации**

Вы можете вставить любое изображение в презентацию, используя метод [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) класса [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

Чтобы создать объект изображения из SVG, выполните следующие шаги:

1. Создайте [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) и добавьте его в коллекцию изображений презентации.  
2. Создайте объект [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) из [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/).  
3. Создайте объект [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), используя [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).

Ниже приведён пример на Python, показывающий, как добавить SVG‑изображение в презентацию, используя эти шаги:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Прочитать содержимое SVG файла.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # Создать объект SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Создать объект PPImage.
        pp_image = presentation.images.add_image(svg_image)

        # Создать новый PictureFrame.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # Сохранить презентацию в формате PPTX.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```


## **Преобразование SVG в набор фигур**

Aspose.Slides преобразует SVG в набор фигур аналогично тому, как это делает PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Эта функциональность предоставляется перегрузкой метода [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_group_shape/) класса [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/), который принимает [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) в качестве первого аргумента.

Ниже приведён пример кода, показывающий, как преобразовать файл SVG в набор фигур.
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Прочитать содержимое SVG файла.
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

Ниже приведён пример на Python, демонстрирующий это:
```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```


## **Замена изображений в коллекции изображений**

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации, включая те, которые используются фигурами слайдов. В этом разделе описаны несколько подходов к обновлению изображений в коллекции. API предоставляет простые методы замены изображения сырыми байтовыми данными, экземпляром [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) или другим изображением, уже существующим в коллекции.

1. Загрузите презентацию, содержащую изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Загрузите новое изображение из файла в массив байтов.  
3. Замените целевое изображение новым, используя массив байтов.  
4. Либо загрузите изображение в объект [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) и замените целевое изображение этим объектом.  
5. Или замените целевое изображение изображением, уже существующим в коллекции изображений презентации.  
6. Сохраните изменённую презентацию в файл PPTX.
```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Создать экземпляр класса Presentation, который представляет файл презентации.
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


{{% alert title="Информация" color="info" %}}
С помощью бесплатного конвертера [Text to GIF](https://products.aspose.app/slides/text-to-gif) от Aspose вы можете легко анимировать текст и создавать GIF‑файлы из текста.
{{% /alert %}}

## **FAQ**

**Сохраняется ли оригинальное разрешение изображения после вставки?**

Да. Исходные пиксели сохраняются, но окончательный вид зависит от того, как [изображение](/slides/ru/python-net/picture-frame/) масштабируется на слайде и от любой компрессии при сохранении.

**Как лучше всего заменить один и тот же логотип сразу на десятках слайдов?**

Разместите логотип на мастер‑слайде или в макете и замените его в коллекции изображений презентации — изменения распространятся на все элементы, использующие данный ресурс.

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**

Да. Вы можете преобразовать SVG в группу фигур, после чего отдельные части становятся редактируемыми с помощью стандартных свойств фигур.

**Как установить изображение в качестве фона сразу для нескольких слайдов?**

[Назначьте изображение в качестве фона](/slides/ru/python-net/presentation-background/) на мастер‑слайде или соответствующем макете — все слайды, использующие этот мастер/макет, получат фон.

**Как предотвратить рост размера презентации из‑за большого количества изображений?**

Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте компрессию при сохранении и размещайте повторяющиеся графические элементы на мастере, если это уместно.