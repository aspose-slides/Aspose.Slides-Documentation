---
title: Изображение
type: docs
weight: 10
url: /python-net/image/
keywords: "Добавить изображение, Добавить картинку, Презентация PowerPoint, EMF, SVG, Python, Aspose.Slides для Python через .NET"
description: "Добавить изображение на слайд или в презентацию PowerPoint на Python"
---

## **Изображения на слайдах в презентациях**

Изображения делают презентации более увлекательными и интересными. В Microsoft PowerPoint вы можете вставить картинки из файла, интернета или других мест на слайды. Аналогично, Aspose.Slides позволяет добавлять изображения на слайды в ваших презентациях различными процедурами.

{{% alert title="Совет" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры—[JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—которые позволяют людям быстро создавать презентации из изображений. 

{{% /alert %}} 

{{% alert title="Информация" color="info" %}}

Если вы хотите добавить изображение как объект рамки — особенно если вы планируете использовать стандартные параметры форматирования для изменения его размера, добавления эффектов и так далее — смотрите [Рама для изображения](https://docs.aspose.com/slides/python-net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}}

Вы можете манипулировать операциями ввода/вывода, связанными с изображениями и презентациями PowerPoint, чтобы конвертировать изображение из одного формата в другой. См. эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает операции с изображениями в этих популярных форматах: JPEG, PNG, BMP, GIF и других. 

## **Добавление изображений, хранящихся локально, на слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд в презентации. Этот пример кода на Python показывает, как добавить изображение на слайд:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление изображений из веба на слайды**

Если изображение, которое вы хотите добавить на слайд, недоступно на вашем компьютере, вы можете добавить изображение непосредственно из интернета. 

Этот образец кода показывает, как добавить изображение из веба на слайд на Python:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as pres:
    slide = pres.slides[0]
    imageData = base64.b64encode(urllib2.urlopen("[ЗАМЕНИТЕ НА URL]").read())

    image = pres.images.add_image(imageData)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление изображений на мастер-слайды**

Мастер-слайд — это верхний слайд, который хранит и контролирует информацию (тема, раскладка и т. д.) обо всех слайдах под ним. Таким образом, когда вы добавляете изображение на мастер-слайд, это изображение появляется на каждом слайде под этим мастер-слайдом. 

Этот образец кода на Python показывает, как добавить изображение на мастер-слайд:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    masterSlide = slide.layout_slide.master_slide
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
        
    pres.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление изображений в качестве фона слайда**

Вы можете решить использовать картинку в качестве фона для определенного слайда или нескольких слайдов. В этом случае вам необходимо ознакомиться с *[Установкой изображений в качестве фонов для слайдов](https://docs.aspose.com/slides/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**
Вы можете добавить или вставить любое изображение в презентацию, используя метод [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/), который принадлежит интерфейсу [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

Чтобы создать объект изображения на основе SVG-изображения, вы можете сделать это следующим образом:

1. Создайте объект SvgImage, чтобы вставить его в ImageShapeCollection
2. Создайте объект PPImage из ISvgImage
3. Создайте объект PictureFrame, используя интерфейс IPPImage

Этот пример кода показывает, как реализовать вышеописанные шаги для добавления SVG-изображения в презентацию:
```py 
import aspose.slides as slides

# Создание новой презентации
with slides.Presentation() as p:
    # Чтение содержимого файла SVG
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # Создание объекта SvgImage
        svgImage = slides.SvgImage(svgContent)

        # Создание объекта PPImage
        ppImage = p.images.add_image(svgImage)

        # Создание нового PictureFrame 
        p.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, ppImage.width, ppImage.height, ppImage)

        # Сохранение презентации в формате PPTX
        p.save("presentation_with-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Конвертация SVG в набор фигур**
Конвертация SVG в набор фигур в Aspose.Slides аналогична функциональности PowerPoint, используемой для работы с SVG-изображениями:


![Всплывающее меню PowerPoint](img_01_01.png)

Эта функциональность предоставляется одной из перегрузок метода [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/addgroupshape/) интерфейса [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/), которая принимает объект [ISvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/isvgimage/) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для преобразования SVG-файла в набор фигур:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Чтение содержимого файла SVG
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # Создание объекта SvgImage
        svgImage = slides.SvgImage(svgContent)

        # Получение размера слайда
        slide_size = presentation.slide_size.size

        # Преобразование SVG-изображения в группу фигур с масштабированием к размеру слайда
        presentation.slides[0].shapes.add_group_shape(svgImage, 0, 0, slide_size.width, slide_size.height)

        # Сохранение презентации в формате PPTX
        presentation.save("presentation_with_shape_svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление изображений в формате EMF на слайды**
Aspose.Slides для Python через .NET позволяет добавлять изображения в формате EMF. 

Этот пример кода показывает, как выполнить описанную задачу:

```py 
with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("image.emf", "rb") as in_file:
        emfImage = pres.images.add_image(in_file)
        slide_size = pres.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emfImage)
    
    pres.save("pres_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Информация" color="info" %}}

Используя бесплатный конвертер Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif), вы можете легко анимировать текст, создавать GIF из текста и т. д.

{{% /alert %}}