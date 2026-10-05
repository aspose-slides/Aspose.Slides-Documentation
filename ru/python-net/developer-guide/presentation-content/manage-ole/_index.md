---
title: У管理 OLE в презентациях с использованием Python
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/python-net/manage-ole/
keywords:
- OLE-объект
- Связывание и встраивание объектов
- добавить OLE
- встроить OLE
- добавить объект
- встроить объект
- добавить файл
- встроить файл
- связанный объект
- связанный файл
- изменить OLE
- значок OLE
- заголовок OLE
- извлечь OLE
- извлечь объект
- извлечь файл
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Оптимизируйте управление OLE‑объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides for Python через .NET. Встраивайте, обновляйте и без проблем экспортируйте OLE‑содержимое."
---
## **Введение**

{{% alert color="info" title="Note" %}}

**OLE (Object Linking & Embedding)** – это технология Microsoft, позволяющая связывать или встраивать данные и объекты, созданные в одном приложении, в другое.

{{% /alert %}}

Например, диаграмма, созданная в Microsoft Excel и помещённая на слайд PowerPoint, является OLE‑объектом.

- OLE‑объект может отображаться в виде значка. Двойной щелчок по значку открывает объект в связанном приложении (например, Excel) или предлагает выбрать приложение для открытия или редактирования.
- OLE‑объект может отображать своё содержимое (например, диаграмму). В этом случае PowerPoint активирует встроенный объект, загружает интерфейс диаграммы и позволяет редактировать данные диаграммы непосредственно в PowerPoint.

Aspose.Slides for Python позволяет вставлять OLE‑объекты на слайды в виде OLE‑объектных фреймов ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Добавление OLE‑объектов на слайды**

Если вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд в виде OLE‑объектного фрейма с помощью Aspose.Slides for Python, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Прочитайте файл Excel в массив байтов.
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) на слайд, передав массив байтов и другие детали OLE‑объекта.
1. Сохраните изменённую презентацию как файл PPTX.

В примере ниже диаграмма из файла Excel встраивается в слайд в виде [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Note:** Конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) принимает расширение файла встраиваемого объекта вторым параметром. PowerPoint использует это расширение для определения типа файла и выбора подходящего приложения для открытия OLE‑объекта.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Подготовьте данные для OLE‑объекта.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Добавьте OLE‑объектный фрейм на слайд.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Добавление связанных OLE‑объектов**

Aspose.Slides for Python позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/), который связывается с файлом вместо встраивания его данных.

Следующий пример на Python показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) со ссылкой на файл Excel на слайд:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавьте OLE-объектный фрейм со связанным файлом Excel.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к OLE‑объектам**

Если OLE‑объект уже встроен в слайд, к нему можно получить доступ следующим образом:

1. Загрузите презентацию, содержащую встроенный OLE‑объект, создав экземпляр класса Presentation.
1. Получите ссылку на слайд по его индексу.
1. Доступ к форме OleObjectFrame.
1. После получения фрейма OLE‑объекта выполните необходимые операции с ним.

Пример ниже получает доступ к фрейму OLE‑объекта — встроенной диаграмме Excel — и извлекает данные её файла. В этом примере используется PPTX с единственной формой на первом слайде.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Получить данные встроенного файла.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Получить расширение встроенного файла.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Доступ к свойствам связанного OLE‑объекта**

Aspose.Slides позволяет получать свойства фрейма связанного OLE‑объекта.

Пример на Python ниже проверяет, связан ли OLE‑объект, и если да, получает путь к связанному файлу:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Проверить, связан ли OLE-объект.
        if ole_frame.is_object_link:
            # Вывести полный путь к связанному файлу.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Вывести относительный путь к связанному файлу, если он присутствует.
            # Только презентации .ppt могут содержать относительный путь.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Изменение данных OLE‑объекта**

{{% alert color="info" title="Note" %}}

В этом разделе пример кода ниже использует [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/).

{{% /alert %}}

Если OLE‑объект уже встроен в слайд, его можно получить и изменить данные следующим образом:

1. Загрузите презентацию, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите целевой слайд по его индексу.
1. Доступ к форме [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. После получения фрейма OLE‑объекта выполните необходимые операции с ним.
1. Создайте объект `Workbook` и прочитайте данные OLE.
1. Откройте нужный `Worksheet` и отредактируйте данные.
1. Сохраните обновлённый `Workbook` в поток.
1. Замените данные OLE‑объекта, используя этот поток.

В примере ниже фрейм OLE‑объекта (встроенная диаграмма Excel) открывается, и данные её файла изменяются для обновления диаграммы. В образце используется ранее созданный PPTX с одной формой на первом слайде.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Прочитать данные OLE-объекта как объект Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Изменить данные workbook.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Изменить данные объекта OLE-фрейма.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Встраивание файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Python позволяет встраивать в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы как объекты. При двойном щелчке пользователя по вставленному объекту он автоматически открывается в связанном приложении, либо пользователю предлагается выбрать подходящую программу.

Следующий код на Python демонстрирует, как встроить HTML и ZIP‑файлы в слайд:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка типа файла для встроенных объектов**

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Python позволяет задать тип файла встроенного объекта, что даёт возможность обновить данные фрейма OLE или его расширение файла.

Следующий код на Python показывает, как установить тип файла встроенного OLE‑объекта в `zip`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Изменить тип файла на ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка изображений значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот просмотр видят пользователи до того, как откроют OLE‑объект. Если необходимо использовать конкретное изображение и текст в превью, можно задать изображение значка и заголовок с помощью Aspose.Slides for Python.

Следующий код на Python демонстрирует, как задать изображение значка и заголовок для встроенного объекта:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Добавить изображение в ресурсы презентации.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Установить заголовок и изображение для превью OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Предотвращение изменения размера и перемещения OLE‑объектов**

После добавления связанного OLE‑объекта на слайд PowerPoint может предлагать обновить ссылки при открытии презентации. Выбор «Обновить ссылки» может изменить размер и позицию фрейма OLE‑объекта, поскольку PowerPoint обновляет превью данными из связанного объекта. Чтобы отключить запрос PowerPoint о обновлении данных объекта, установите свойство `update_automatic` класса [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) в `False`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Извлечение встроенных файлов**

Aspose.Slides for Python позволяет извлекать файлы, встроенные в слайды в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), содержащего OLE‑объекты, которые требуется извлечь.
1. Пройдитесь по всем формам в презентации и найдите формы OLEObjectFrame.
1. Получите данные встроенного файла из каждой [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) и запишите их на диск.

Следующий код на Python показывает, как извлечь файлы, встроенные в слайд как OLE‑объекты:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**Будет ли OLE‑содержимое отрисовано при экспорте слайдов в PDF/изображения?**

При рендеринге отображается то, что видно на слайде — значок/заместительное изображение (превью). «Живое» OLE‑содержимое не выполняется во время рендеринга. При необходимости задайте собственное превью‑изображение, чтобы обеспечить ожидаемый вид в экспортированном PDF.

Чтобы также сохранить встроенный файл как вложение PDF, установите [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) в `True`. По умолчанию эта опция отключена. Пример и инструкции по проверке вложения смотрите в [Preserve Embedded OLE Files as PDF Attachments](/slides/ru/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет [shape-level locks](/slides/ru/python-net/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Почему связанный объект Excel «прыгает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Для стабильного внешнего вида следуйте рекомендациям [Working Solution for Worksheet Resizing](/slides/ru/python-net/working-solution-for-worksheet-resizing/) — либо подгоните фрейм под диапазон, либо масштабируйте диапазон до фиксированного фрейма и задайте подходящее заместительное изображение.

**Будут ли относительные пути для связанных OLE‑объектов сохранены в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути присутствуют в старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или встраивание.