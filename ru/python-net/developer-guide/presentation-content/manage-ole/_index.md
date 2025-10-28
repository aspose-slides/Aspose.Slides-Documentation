---
title: Управление OLE в презентациях с помощью Python
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/python-net/manage-ole/
keywords:
- OLE объект
- Связывание и внедрение объектов
- добавить OLE
- внедрить OLE
- добавить объект
- внедрить объект
- добавить файл
- внедрить файл
- связанный объект
- связанный файл
- изменить OLE
- иконка OLE
- заголовок OLE
- извлечь OLE
- извлечь объект
- извлечь файл
- PowerPoint 
- презентация
- Python
- Aspose.Slides
description: "Оптимизируйте управление OLE объектами в файлах PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Внедряйте, обновляйте и экспортируйте OLE контент без проблем."
---

## **Обзор**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** — технология Microsoft, позволяющая связывать или внедрять данные и объекты, созданные в одном приложении, в другое.

{{% /alert %}}

Например, диаграмма, созданная в Microsoft Excel и размещённая на слайде PowerPoint, представляет собой OLE объект.

- OLE объект может отображаться в виде иконки. Двойной клик по иконке открывает объект в связанном приложении (например, Excel) или предлагает выбрать приложение для открытия/редактирования.
- OLE объект может показывать своё содержимое (например, диаграмму). В этом случае PowerPoint активирует внедрённый объект, загружает интерфейс диаграммы и позволяет редактировать данные диаграммы внутри PowerPoint.

Aspose.Slides for Python позволяет вставлять OLE объекты на слайды в виде кадров OLE объектов ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Добавление OLE объектов на слайды**

Если вы уже создали диаграмму в Microsoft Excel и хотите внедрить её на слайд в виде кадра OLE объекта с помощью Aspose.Slides for Python, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Прочитайте файл Excel в массив байтов.
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) на слайд, передав массив байтов и другие детали OLE объекта.
1. Сохраните изменённую презентацию в файл PPTX.

В примере ниже диаграмма из файла Excel внедряется в слайд как [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Примечание:** Конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) принимает расширение файла внедряемого объекта вторым параметром. PowerPoint использует это расширение для определения типа файла и выбора соответствующего приложения для открытия OLE объекта.

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

### **Добавление связанных OLE объектов**

Aspose.Slides for Python позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/), который ссылается на файл вместо внедрения его данных.

Следующий пример на Python показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) со ссылкой на файл Excel на слайде:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an OLE object frame with a linked Excel file.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к OLE объектам**

Если OLE объект уже внедрён в слайд, вы можете получить к нему доступ следующим образом:

1. Загрузите презентацию, содержащую внедрённый OLE объект, создав экземпляр класса Presentation.
1. Получите ссылку на слайд по его индексу.
1. Доступ к форме OleObjectFrame.
1. После получения кадра OLE объекта выполните необходимые операции.

Ниже показан пример доступа к кадру OLE объекта — внедрённой диаграмме Excel — и получения данных файла. В этом примере используется PPTX с одной формой на первом слайде.

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

### **Доступ к свойствам связанных OLE объектов**

Aspose.Slides позволяет получать свойства кадра связанного OLE объекта.

Пример на Python ниже проверяет, связан ли OLE объект, и, если да, выводит путь к связанному файлу:

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

## **Изменение данных OLE объекта**

{{% alert color="primary" %}}

В этом разделе пример кода использует [Aspose.Cells for Python via .NET](/cells/python-net/).

{{% /alert %}}

Если OLE объект уже внедрён в слайд, вы можете получить к нему доступ и изменить его данные следующим образом:

1. Загрузите презентацию, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите целевой слайд по его индексу.
1. Доступ к форме [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. После получения кадра OLE объекта выполните требуемые операции.
1. Создайте объект `Workbook` и прочитайте OLE данные.
1. Откройте нужный `Worksheet` и отредактируйте данные.
1. Сохраните обновлённый `Workbook` в поток.
1. Замените данные OLE объекта с помощью этого потока.

В примере ниже кадр OLE объекта (внедрённая диаграмма Excel) доступен, и его данные файла изменяются для обновления диаграммы. Пример использует ранее созданный PPTX с одной формой на первом слайде.

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

## **Внедрение файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Python позволяет внедрять в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP файлы как объекты. При двойном щелчке по вставленному объекту он автоматически открывается в связанном приложении, либо пользователю предлагается выбрать подходящую программу.

Пример кода на Python, показывающий, как внедрить HTML и ZIP файлы в слайд:

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

## **Установка типов файлов для внедрённых объектов**

При работе с презентациями может потребоваться заменить старый OLE объект новым или заменить неподдерживаемый OLE объект поддерживаемым. Aspose.Slides for Python позволяет задать тип файла внедрённого объекта, позволяя обновить данные кадра OLE или его расширение файла.

Пример кода на Python, показывающий, как установить тип внедрённого OLE объекта в `zip`:

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

## **Установка изображений и заголовков иконок для внедрённых объектов**

После внедрения OLE объекта автоматически добавляется предварительный просмотр в виде иконки. Этот просмотр виден пользователям до того, как они откроют OLE объект. Если вы хотите использовать определённое изображение и текст в превью, можно задать изображение и заголовок иконки с помощью Aspose.Slides for Python.

Пример кода на Python, показывающий, как задать изображение и заголовок иконки для внедрённого объекта:

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

## **Предотвращение изменения размеров и положения кадра OLE объекта**

После добавления связанного OLE объекта на слайд PowerPoint может предлагать обновить ссылки при открытии презентации. Выбор «Update Links» может изменить размер и положение кадра OLE объекта, так как PowerPoint обновляет превью данными из связанного объекта. Чтобы избежать запроса обновления данных объекта, установите свойство `update_automatic` класса [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) в `False`:

```py
ole_frame.update_automatic = False
```

## **Извлечение внедрённых файлов**

Aspose.Slides for Python позволяет извлекать файлы, внедрённые в слайды как OLE объекты, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), содержащего OLE объекты, которые нужно извлечь.
1. Пройдитесь по всем формам в презентации и найдите формы OLEObjectFrame.
1. Получите данные внедрённого файла из каждого [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) и запишите их на диск.

Ниже приведён пример кода на Python, показывающий, как извлечь файлы, внедрённые в слайд как OLE объекты:

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

**Будет ли OLE содержимое отображено при экспорте слайдов в PDF/изображения?**

То, что видно на слайде, будет отрисовано — иконка/замещающее изображение (превью). «Живое» OLE содержимое не выполняется во время отрисовки. При необходимости задайте собственное превью‑изображение, чтобы обеспечить ожидаемый вид в экспортированном PDF.

**Как заблокировать OLE объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет [блокировки на уровне формы](/slides/ru/python-net/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Для стабильного внешнего вида следуйте рекомендациям [Working Solution for Worksheet Resizing](/slides/ru/python-net/working-solution-for-worksheet-resizing/) — либо подгоните кадр под диапазон, либо масштабируйте диапазон до фиксированного кадра и задайте подходящее замещающее изображение.

**Будут ли сохранены относительные пути для связанных OLE объектов в формате PPTX?**

В PPTX информация о «relative path» недоступна — только полный путь. Относительные пути присутствуют только в старом формате PPT. Для портативности предпочтительно использовать надёжные абсолютные пути/доступные URI или внедрение.