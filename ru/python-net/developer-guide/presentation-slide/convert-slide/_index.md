---
title: Преобразуйте слайды презентаций в изображения на Python
linktitle: Слайд в изображение
type: docs
weight: 41
url: /ru/python-net/convert-slide/
keywords:
- конвертация слайда
- конвертация слайда в изображение
- экспорт слайда как изображение
- сохранение слайда как изображение
- слайд в изображение
- слайд в PNG
- слайд в JPEG
- слайд в bitmap
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как преобразовывать слайды PowerPoint и OpenDocument в различные форматы с помощью Aspose.Slides for Python via .NET. Легко экспортируйте слайды PPTX и ODP в BMP, PNG, JPEG, TIFF и другие форматы с высоким качеством."
---

Aspose.Slides для Python через .NET позволяет вам конвертировать слайды (в презентациях) в изображения. Поддерживаемые форматы изображений: BMP, PNG, JPG (JPEG), GIF и другие.

Чтобы конвертировать слайд в изображение, выполните следующее:

1. Сначала конвертируйте слайд в Bitmap, используя метод [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
2. Затем установите дополнительные параметры для конвертации и конвертируемые объекты слайдов через
   * интерфейс [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) или
   * интерфейс [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/).

## **О Bitmap и других форматах изображений**

В .NET [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) — это объект, который позволяет вам работать с изображениями, определенными по данным пикселей. Вы можете использовать экземпляр этого класса для сохранения изображений в широком диапазоне форматов (BMP, JPG, PNG и т.д.).

{{% alert title="Информация" color="info" %}}

Aspose недавно разработала онлайн конвертер [Text to GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **Конвертирование слайдов в Bitmap и сохранение изображений в PNG**

Этот код на Python показывает, как конвертировать первый слайд презентации в объект bitmap, а затем как сохранить изображение в формате PNG:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Конвертирует первый слайд в объект Bitmap
    with pres.slides[0].get_image() as bmp:
        # Сохраняет изображение в формате PNG
        bmp.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert title="Совет" color="primary" %}}

Вы можете конвертировать слайд в объект bitmap и затем использовать объект прямо где-то. Или вы можете конвертировать слайд в bitmap, а затем сохранить изображение в JPEG или любом другом формате на ваш выбор.

{{% /alert %}}  

## **Конвертирование слайдов в изображения с пользовательскими размерами**

Вам может потребоваться получить изображение определенного размера. Используя перегрузку метода [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/), вы можете конвертировать слайд в изображение с конкретными размерами (длина и ширина).

Этот пример кода демонстрирует предложенную конвертацию, используя метод [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) на Python:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Конвертирует первый слайд в Bitmap с указанным размером
    with pres.slides[0].get_image(draw.Size(1820, 1040)) as bmp:
        # Сохраняет изображение в формате JPEG
        bmp.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Конвертирование слайдов с заметками и комментариями в изображения**

Некоторые слайды содержат заметки и комментарии.

Aspose.Slides предоставляет два интерфейса — [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) и [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/) — которые позволяют вам контролировать рендеринг слайдов презентации в изображения. Оба интерфейса содержат интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/), который позволяет добавлять заметки и комментарии на слайд при конвертации этого слайда в изображение.

{{% alert title="Информация" color="info" %}} 

С помощью интерфейса [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) вы можете указать желаемую позицию для заметок и комментариев в результирующем изображении.

{{% /alert %}} 

Этот код на Python демонстрирует процесс конвертации слайда с заметками и комментариями:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("AddNotesSlideWithNotesStyle_out.pptx") as pres:
    # Создает параметры рендеринга
    options = slides.export.RenderingOptions()
                
    # Устанавливает позицию заметок на странице
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
                
    # Устанавливает позицию комментариев на странице 
    options.notes_comments_layouting.comments_position = slides.export.CommentsPositions.RIGHT

    # Устанавливает ширину области вывода комментариев
    options.notes_comments_layouting.comments_area_width = 500
                
    # Устанавливает цвет области комментариев
    options.notes_comments_layouting.comments_area_color = draw.Color.antique_white
                
    # Конвертирует первый слайд презентации в объект Bitmap
    with pres.slides[0].get_image(options, 2, 2) as bmp:
        # Сохраняет изображение в формате GIF
        bmp.save("Slide_Notes_Comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Замечание" color="warning" %}} 

В процессе конвертации любого слайда в изображение свойство [NotesPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) не может быть установлено в BottomFull (для указания позиции для заметок), потому что текст заметки может быть большим, что означает, что он может не поместиться в установленный размер изображения.

{{% /alert %}} 

## **Конвертирование слайдов в изображения с использованием ITiffOptions**

Интерфейс [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) дает вам больший контроль (в терминах параметров) над результирующим изображением. Используя этот интерфейс, вы можете указать размер, разрешение, цветовую палитру и другие параметры для результирующего изображения.

Этот код на Python демонстрирует процесс конвертации, в котором ITiffOptions используется для вывода черно-белого изображения с разрешением 300dpi и размером 2160 × 2800:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "Comments1.pptx") as pres:
    # Получает слайд по его индексу
    slide = pres.slides[0]

    # Создает объект TiffOptions
    options = slides.export.TiffOptions() 
    options.image_size = draw.Size(2160, 2880)

    # Устанавливает шрифт, используемый в случае, если исходный шрифт не найден
    options.default_regular_font = "Arial Black"

    # Устанавливает позицию заметок на странице 
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    # Устанавливает формат пикселей (черно-белый)
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED

    # Устанавливает разрешение
    options.dpi_x = 300
    options.dpi_y = 300

    # Конвертирует слайд в объект Bitmap
    with slide.get_image(options) as bmp:
        # Сохраняет изображение в формате BMP
        bmp.save("PresentationNotesComments.tiff", slides.ImageFormat.TIFF)
```

## **Конвертирование всех слайдов в изображения**

Aspose.Slides позволяет вам конвертировать все слайды в одной презентации в изображения. По сути, вы можете конвертировать презентацию (в целом) в изображения.

Этот пример кода показывает, как конвертировать все слайды в презентации в изображения на Python:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Рендерит презентацию в массив изображений по слайдам
    for i in range(len(pres.slides)):
        # Указывает настройки для скрытых слайдов (не рендерить скрытые слайды)
        if pres.slides[i].hidden:
            continue

        # Конвертирует слайд в объект Bitmap
        with pres.slides[i].get_image() as bmp:
            # Сохраняет изображение в формате JPEG
            bmp.save("image_{0}.jpeg".format(i), slides.ImageFormat.JPEG)
```