---
title: Управление OLE в презентациях с помощью Python
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/python-net/manage-ole/
keywords:
- OLE-объект
- Связывание и вложение объектов
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
description: "Оптимизируйте управление OLE-объектами в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Встраивайте, обновляйте и экспортируйте OLE‑контент без проблем."
---

## **Обзор**

{{% alert title="Информация" color="info" %}}

**OLE (Object Linking & Embedding)** — технология Microsoft, позволяющая связывать или встраивать данные и объекты, созданные в одном приложении, в другое.

{{% /alert %}}

Например, диаграмма, созданная в Microsoft Excel и размещённая на слайде PowerPoint, является OLE‑объектом.

- OLE‑объект может отображаться в виде значка. Двойной щелчок по значку открывает объект в соответствующем приложении (например, Excel) или предлагает выбрать приложение для открытия/редактирования.
- OLE‑объект может отображать своё содержимое (например, диаграмму). В этом случае PowerPoint активирует встроенный объект, загружает интерфейс диаграммы и позволяет редактировать данные диаграммы непосредственно в PowerPoint.

Aspose.Slides for Python позволяет вставлять OLE‑объекты в слайды как кадры OLE‑объектов ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Добавление OLE‑объектов на слайды**

Если вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд как кадр OLE‑объекта с помощью Aspose.Slides for Python, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Прочитайте файл Excel в массив байтов.
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) на слайд, передав массив байтов и другие сведения об OLE‑объекте.
1. Сохраните изменённую презентацию в файл PPTX.

В примере ниже диаграмма из файла Excel встраивается в слайд как [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Примечание:** Конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) принимает расширение файла встраиваемого объекта в качестве второго параметра. PowerPoint использует это расширение для определения типа файла и выбора соответствующего приложения для открытия OLE‑объекта.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Prepare the data for the OLE object.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Add an OLE object frame to the slide.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Добавление связанных OLE‑объектов**

Aspose.Slides for Python позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/), который будет ссылаться на файл вместо встраивания его данных.

Следующий пример на Python показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/), связанный с файлом Excel на слайде:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an OLE object frame with a linked Excel file.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к OLE‑объектам**

Если OLE‑объект уже встроен в слайд, к нему можно получить доступ следующим образом:

1. Загрузите презентацию, содержащую встроенный OLE‑объект, создав экземпляр класса Presentation.
1. Получите ссылку на слайд по его индексу.
1. Доступ к объекту OleObjectFrame.
1. После получения кадра OLE‑объекта выполните необходимые операции.

В примере ниже происходит доступ к кадру OLE‑объекта — встроенной диаграмме Excel — и извлекаются его данные файла. В примере используется PPTX с единственным объектом на первом слайде.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Get the embedded file data.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Get the extension of the embedded file.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Доступ к свойствам связанных OLE‑объектов**

Aspose.Slides позволяет получить свойства кадра связанного OLE‑объекта.

Пример на Python проверяет, является ли OLE‑объект связанным, и при этом получает путь к связанному файлу:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Check whether the OLE object is linked.
        if ole_frame.is_object_link:
            # Print the full path to the linked file.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Print the relative path to the linked file, if present.
            # Only .ppt presentations can contain a relative path.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Изменение данных OLE‑объекта**

{{% alert color="primary" %}}

В этом разделе пример кода использует [Aspose.Cells for Python via .NET](/cells/python-net/).

{{% /alert %}}

Если OLE‑объект уже встроен в слайд, его можно получить и изменить следующим образом:

1. Загрузите презентацию, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите целевой слайд по индексу.
1. Доступ к объекту [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. После получения кадра OLE‑объекта выполните необходимые операции.
1. Создайте объект `Workbook` и прочитайте OLE‑данные.
1. Откройте нужный `Worksheet` и отредактируйте данные.
1. Сохраните обновлённый `Workbook` в поток.
1. Замените данные OLE‑объекта, используя этот поток.

В примере ниже кадр OLE‑объекта (встроенная диаграмма Excel) открывается, и его данные файла изменяются для обновления диаграммы. В примере используется ранее созданный PPTX с одним объектом на первом слайде.

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
            # Read the OLE object data as a Workbook object.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Modify the workbook data.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Change the OLE frame object data.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Встраивание файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Python позволяет встраивать в слайды и другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользователем вставленного объекта он открывается автоматически в соответствующем приложении, либо пользователю предлагается выбрать подходящую программу.

Этот код на Python демонстрирует встраивание HTML и ZIP‑файлов в слайд:

```py
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

## **Установка типа файлов для встроенных объектов**

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Python позволяет задать тип файла встроенного объекта, что позволяет обновить данные кадра OLE либо его расширение файла.

Пример кода на Python, который задаёт тип файла встроенного OLE‑объекта как `zip`:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Change the file type to ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка изображений значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот просмотр видят пользователи перед тем, как открыть OLE‑объект. Если требуется использовать определённое изображение и текст в превью, можно задать изображение значка и заголовок с помощью Aspose.Slides for Python.

Пример кода на Python, который задаёт изображение значка и заголовок для встроенного объекта:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Add an image to the presentation resources.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Set a title and the image for the OLE preview.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Предотвращение изменения размеров и положения кадров OLE‑объектов**

После добавления связанного OLE‑объекта в слайд PowerPoint может предложить обновить ссылки при открытии презентации. Выбор «Update Links» может изменить размер и положение кадра OLE‑объекта, поскольку PowerPoint обновляет превью данными из связанного объекта. Чтобы отключить запрос PowerPoint о обновлении данных объекта, установите свойство `update_automatic` класса [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) в значение `False`:

```py
ole_frame.update_automatic = False
```

## **Извлечение встроенных файлов**

Aspose.Slides for Python позволяет извлекать файлы, встроенные в слайды в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), содержащий нужные OLE‑объекты.
1. Пройдитесь по всем объектам (shapes) презентации и найдите объекты типа OLEObjectFrame.
1. Получите данные встроенного файла из каждого [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) и запишите их на диск.

Пример кода на Python, который извлекает файлы, встроенные в слайд как OLE‑объекты:

```py
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

**Будет ли содержимое OLE отображено при экспорте слайдов в PDF/изображения?**

Отображается то, что видно на слайде — значок/замещающее изображение (превью). «Живое» содержимое OLE не исполняется во время рендеринга. При необходимости задайте собственное превью‑изображение, чтобы обеспечить ожидаемый вид в экспортированном PDF.

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет [блокировки на уровне формы](/slides/ru/python-net/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные правки и перемещения.

**Почему связанный объект Excel «перескакивает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Для стабильного вида следуйте рекомендациям из [Working Solution for Worksheet Resizing](/slides/ru/python-net/working-solution-for-worksheet-resizing/) — либо подгоняйте кадр под диапазон, либо масштабируйте диапазон к фиксированному кадру и задайте подходящее замещающее изображение.

**Сохраняются ли относительные пути для связанных OLE‑объектов в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути присутствуют в более старом формате PPT. Для переносимости рекомендуется использовать надёжные абсолютные пути/доступные URI или встраивание.