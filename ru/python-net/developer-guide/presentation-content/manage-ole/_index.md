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
- название OLE
- извлечь OLE
- извлечь объект
- извлечь файл
- PowerPoint 
- презентация
- Python
- Aspose.Slides
description: "Оптимизируйте управление OLE объектами в PowerPoint и OpenDocument файлах с помощью Aspose.Slides for Python через .NET. Внедряйте, обновляйте и экспортируйте OLE содержимое без усилий."
---

## **Обзор**

{{% alert title="Информация" color="info" %}}

**OLE (Object Linking & Embedding)** — это технология Microsoft, позволяющая связывать или внедрять данные и объекты, созданные в одном приложении, в другое.

{{% /alert %}}

Например, диаграмма, созданная в Microsoft Excel и размещённая на слайде PowerPoint, является OLE объектом.

- OLE объект может отображаться в виде иконки. Двойной щелчок по иконке открывает объект в связанном приложении (например, Excel) или предлагает выбрать приложение для открытия или редактирования.
- OLE объект может отображать своё содержимое (например, диаграмму). В этом случае PowerPoint активирует внедрённый объект, загружает интерфейс диаграммы и позволяет редактировать данные диаграммы непосредственно в PowerPoint.

Aspose.Slides for Python позволяет вставлять OLE объекты на слайды в виде OLE объектных кадров ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Добавление OLE объектов на слайды**

Если вы уже создали диаграмму в Microsoft Excel и хотите внедрить её в слайд как OLE объектный кадр с помощью Aspose.Slides for Python, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Прочитайте файл Excel в массив байтов.
1. Добавьте OleObjectFrame на слайд, передав массив байтов и другие детали OLE объекта.
1. Сохраните изменённую презентацию в файл PPTX.

В приведённом ниже примере диаграмма из файла Excel внедряется в слайд как [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Примечание:** Конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) принимает расширение файла внедряемого объекта как второй параметр. PowerPoint использует это расширение для определения типа файла и выбора соответствующего приложения для открытия OLE объекта.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Подготовьте данные для OLE объекта.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Добавьте OLE объектный кадр на слайд.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Добавление связанных OLE объектов**

Aspose.Slides for Python позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/), который ссылается на файл вместо внедрения его данных.

Следующий пример на Python показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) со связанным файлом Excel на слайде:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавьте OLE объектный кадр со связанным файлом Excel.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к OLE объектам**

Если OLE объект уже внедрён в слайд, вы можете получить к нему доступ следующим образом:

1. Загрузите презентацию, содержащую внедрённый OLE объект, создав экземпляр класса Presentation.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к фигуре OleObjectFrame.
1. После получения OLE объектного кадра выполните необходимые операции.

Пример ниже получает доступ к OLE объектному кадру — внедрённой диаграмме Excel — и извлекает данные файла. В этом примере используется PPTX, содержащий одну фигуру на первом слайде.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Получите данные внедрённого файла.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Получите расширение внедрённого файла.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Доступ к свойствам связанных OLE объектов**

Aspose.Slides позволяет получать свойства связанного OLE объектного кадра.

Пример на Python ниже проверяет, связан ли OLE объект, и при наличии выводит путь к связанному файлу:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Проверьте, связан ли OLE объект.
        if ole_frame.is_object_link:
            # Выведите полный путь к связанному файлу.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Выведите относительный путь к связанному файлу, если он присутствует.
            # Только презентации .ppt могут содержать относительный путь.
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
1. Получите доступ к фигуре OleObjectFrame.
1. После получения OLE объектного кадра выполните необходимые операции.
1. Создайте объект `Workbook` и прочитайте данные OLE.
1. Откройте нужный `Worksheet` и отредактируйте данные.
1. Сохраните обновлённый `Workbook` в поток.
1. Замените данные OLE объекта, используя этот поток.

В примере ниже OLE объектный кадр (внедрённая диаграмма Excel) получает доступ, и его данные файла изменяются для обновления диаграммы. Пример использует ранее созданный PPTX, содержащий одну фигуру на первом слайде.

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
            # Прочитайте данные OLE объекта как объект Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Измените данные workbook.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Измените данные объекта OLE кадра.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Встраивание файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Python позволяет встраивать в слайды другие типы файлов. Например, вы можете вставлять HTML, PDF и ZIP файлы как объекты. При двойном щелчке по вставленному объекту он автоматически открывается в соответствующем приложении, либо пользователю предлагается выбрать подходящую программу.

Этот код на Python демонстрирует, как встраивать HTML и ZIP файлы в слайд:

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

При работе с презентациями вам может потребоваться заменить старые OLE объекты новыми или заменить не поддерживаемый OLE объект поддерживаемым. Aspose.Slides for Python позволяет задать тип файла внедрённого объекта, что даёт возможность обновлять данные OLE кадра или его расширение.

Этот код на Python показывает, как задать тип внедрённого OLE объекта как `zip`:

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

После внедрения OLE объекта автоматически добавляется превью в виде иконки. Это превью видят пользователи, пока они не откроют OLE объект. Если вы хотите использовать конкретное изображение и текст в превью, можно задать изображение и название иконки с помощью Aspose.Slides for Python.

Этот код на Python демонстрирует, как задать изображение и название иконки для внедрённого объекта:

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

## **Предотвращение изменения размера и положения OLE объектных кадров**

После добавления связанного OLE объекта на слайд PowerPoint может предлагать обновить ссылки при открытии презентации. Выбор «Обновить ссылки» может изменить размер и положение OLE объектного кадра, поскольку PowerPoint обновляет превью данными из связанного объекта. Чтобы отключить запрос PowerPoint об обновлении данных объекта, установите свойство `update_automatic` класса [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) в `False`:

```py
ole_frame.update_automatic = False
```

## **Извлечение встроенных файлов**

Aspose.Slides for Python позволяет извлекать файлы, встроенные в слайды как OLE объекты, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) содержащий OLE объекты, которые нужно извлечь.
1. Переберите все фигуры в презентации и найдите фигуры типа OLEObjectFrame.
1. Получите данные встроенного файла из каждого [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) и запишите их на диск.

Пример кода на Python, показывающий, как извлечь файлы, встроенные в слайд как OLE объекты:

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

**Будет ли OLE содержимое отрисовано при экспорте слайдов в PDF/изображения?**

То, что видно на слайде, будет отрисовано — иконка/замещающее изображение (превью). «Живое» OLE содержимое не исполняется во время рендеринга. При необходимости задайте собственное превью‑изображение, чтобы обеспечить ожидаемый внешний вид в экспортированном PDF.

**Как заблокировать OLE объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте фигуру: Aspose.Slides предоставляет [блокировки на уровне фигуры](/slides/ru/python-net/applying-protection-to-presentation/). Это не шифрование, но эффективно препятствует случайным изменениям и перемещениям.

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Для стабильного внешнего вида следуйте рекомендациям из [Рабочего решения для изменения размеров листа](/slides/ru/python-net/working-solution-for-worksheet-resizing/) — либо подгоните кадр под диапазон, либо масштабируйте диапазон к фиксированному кадру и задайте подходящее замещающее изображение.

**Сохранятся ли относительные пути для связанных OLE объектов в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — только полный путь. Относительные пути присутствуют только в старом формате PPT. Для переносимости предпочтительно использовать надёжные абсолютные пути/доступные URI или внедрение.