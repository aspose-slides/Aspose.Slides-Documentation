---
title: Создайте средство просмотра презентаций на Python
linktitle: Средство просмотра презентаций
type: docs
weight: 50
url: /ru/python-net/presentation-viewer/
keywords:
- просмотр презентаций
- средство просмотра презентаций
- создать средство просмотра презентаций
- просмотр PPT
- просмотр PPTX
- просмотр ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Узнайте, как создать собственный просмотрщик презентаций на Python с помощью Aspose.Slides. Легко отображайте файлы PowerPoint (PPTX, PPT) и OpenDocument (ODP) без Microsoft PowerPoint или другого офисного программного обеспечения."
---



Aspose.Slides для Python через .NET используется для создания файлов презентаций, включая слайды. Эти слайды можно просматривать, открывая презентации с помощью Microsoft PowerPoint. Но иногда разработчикам также может понадобиться просмотреть слайды в виде изображений в любимом просмотрщике изображений или создать свой собственный просмотрщик презентаций. В таких случаях Aspose.Slides для Python через .NET позволяет экспортировать отдельный слайд в изображение. Эта статья описывает, как это сделать. 
## **Живой пример**
Вы можете попробовать бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/), чтобы увидеть, что вы можете реализовать с помощью API Aspose.Slides:

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **Создание SVG-изображения из слайда**
Чтобы создать SVG-изображение из любого необходимого слайда с помощью Aspose.Slides для Python, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Получите ссылку на необходимый слайд, используя его ID или индекс.
- Получите изображение SVG в потоке памяти.
- Сохраните поток памяти в файл.

```py
import aspose.slides as slides

# Создание экземпляра класса Presentation, представляющего файл презентации
with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    # Доступ к первому слайду
    sld = pres.slides[0]

    # Создание объекта потока памяти
    with open("Aspose_out-1.svg", "wb") as svg_stream:
        # Генерация SVG-изображения слайда и сохранение в потоке памяти
        sld.write_as_svg(svg_stream)
```


## **Генерация SVG с пользовательскими идентификаторами форм**
Aspose.Slides для Python через .NET можно использовать для генерации [SVG ](https://docs.fileformat.com/page-description-language/svg/)из слайда с пользовательским идентификатором формы. Для этого используйте свойство ID из [ISvgShape](https://reference.aspose.com/slides/python-net/aspose.slides.export/isvgshape/), которое представляет собой пользовательский идентификатор форм в сгенерированном SVG. CustomSvgShapeFormattingController можно использовать для установки идентификатора формы.

```py
import aspose.slides as slides

with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    with open("Aspose_out-2.svg", "wb") as svg_stream:
        svgOptions = slides.export.SVGOptions()
        pres.slides[0].write_as_svg(svg_stream, svgOptions)
```


## **Создание миниатюры слайда**
Aspose.Slides для Python через .NET помогает вам создавать миниатюры изображений слайдов. Чтобы создать миниатюру любого необходимого слайда с помощью Aspose.Slides для Python через .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на любой необходимый слайд, используя его ID или индекс.
1. Получите изображение миниатюры ссылочного слайда в заданном масштабе.
1. Сохраните изображение миниатюры в любом желаемом формате изображения.

```py
import aspose.slides as slides

# Создание экземпляра класса Presentation, представляющего файл презентации
with slides.Presentation("pres.pptx") as pres:
    # Доступ к первому слайду
    sld = pres.slides[0]

    # Создание полноразмерного изображения
    with sld.get_image(1, 1) as bmp:
        # Сохранение изображения на диск в формате JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```


## **Создание миниатюры с пользовательскими размерами**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на любой необходимый слайд, используя его ID или индекс.
1. Получите изображение миниатюры ссылочного слайда в заданном масштабе.
1. Сохраните изображение миниатюры в любом желаемом формате изображения.

```py
import aspose.slides as slides

# Создание экземпляра класса Presentation, представляющего файл презентации
with slides.Presentation("pres.pptx") as pres:
    # Доступ к первому слайду
    sld = pres.slides[0]

    # Пользовательские размеры
    desiredX = 1200
    desiredY = 800

    # Получение масштабируемых значений X и Y
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY


    # Создание полноразмерного изображения
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # Сохранение изображения на диск в формате JPEG
        bmp.save("Thumbnail2_out.jpg", slides.ImageFormat.JPEG)
```


## **Создание миниатюры слайда в режиме заметок**
Чтобы создать миниатюру любого необходимого слайда в режиме заметок, используя Aspose.Slides для Python через .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на любой необходимый слайд, используя его ID или индекс.
1. Получите изображение миниатюры ссылочного слайда в заданном масштабе в режиме заметок.
1. Сохраните изображение миниатюры в любом желаемом формате изображения.

Приведенный ниже фрагмент кода создает миниатюру первого слайда презентации в режиме заметок.

```py
import aspose.slides as slides

# Создание экземпляра класса Presentation, представляющего файл презентации
with slides.Presentation("pres.pptx") as pres:
    # Доступ к первому слайду
    sld = pres.slides[0]

    # Пользовательские размеры
    desiredX = 1200
    desiredY = 800

    # Получение масштабируемых значений X и Y
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY

   
    # Создание полноразмерного изображения                
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # Сохранение изображения на диск в формате JPEG
        bmp.save("Notes_tnail_out.jpg", slides.ImageFormat.JPEG)
```