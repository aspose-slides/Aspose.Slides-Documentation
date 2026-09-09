---
title: Управление OLE в презентациях с использованием Python
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/python-java/manage-ole/
keywords:
- OLE объект
- Связывание и внедрение объектов
- добавление OLE
- внедрение OLE
- добавление объекта
- внедрение объекта
- добавление файла
- внедрение файла
- связанный объект
- связанный файл
- изменение OLE
- значок OLE
- заголовок OLE
- извлечение OLE
- извлечение объекта
- извлечение файла
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Оптимизируйте управление OLE-объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides for Python via Java. Внедряйте, обновляйте и экспортируйте OLE-контент без проблем."
---
## **Введение**

{{% alert color="info" title="Примечание" %}}

OLE (Object Linking & Embedding) — это технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении с помощью связывания или внедрения.

{{% /alert %}}

Рассмотрим диаграмму, созданную в MS Excel. Эта диаграмма помещается в слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом.

- OLE‑объект может отображаться как значок. В этом случае при двойном щелчке значка диаграмма открывается в связанном приложении (Excel) или запрашивается выбор приложения для открытия/редактирования объекта.
- OLE‑объект может показывать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменить данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/ru/python-java/) позволяет вставлять OLE‑объекты в слайды в виде OLE‑кадров объектов ([OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/)).

## **Добавление OLE‑кадров объектов на слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите внедрить её в слайд как OLE‑кадр объекта с помощью Aspose.Slides for Python via Java. Это делается так:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Прочитайте файл Excel в виде массива байтов.
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/) на слайд, передав массив байтов и другую информацию об OLE‑объекте.
5. Запишите изменённую презентацию в файл PPTX.

В примере ниже мы добавили диаграмму из файла Excel на слайд как OLE‑кадр объекта с помощью Aspose.Slides for Python via Java.  
**Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleembeddeddatainfo/) принимает расширение внедряемого объекта вторым параметром. Это расширение позволяет PowerPoint правильно определить тип файла и выбрать нужное приложение для открытия этого OLE‑объекта.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Подготовьте данные для OLE‑объекта.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Добавьте OLE‑кадр объекта на слайд.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Добавление связанных OLE‑кадров объектов**

Aspose.Slides for Python via Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/) с ссылкой на файл вместо внедрённых данных.

Этот Python‑код показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/) со связанным файлом Excel на слайд:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Добавьте OLE‑кадр объекта со связанным файлом Excel.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Доступ к OLE‑кадрам объектов**

Если OLE‑объект уже внедрён в слайд, его можно легко найти или получить доступ следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав объект класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/).  
   В нашем примере использовался ранее созданный PPTX, содержащий единственную форму на первом слайде. Затем мы проверили, что объект является [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/). Это и был нужный OLE‑кадр объекта.
4. После получения доступа к OLE‑кадру вы можете выполнять любые операции с ним.

В примере ниже демонстрируется доступ к OLE‑кадру объекта (внедрённый объект диаграммы Excel) и его файловым данным.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Получить данные внедрённого файла.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Получить расширение внедрённого файла.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Доступ к свойствам связанных OLE‑кадров объектов**

Aspose.Slides позволяет получать свойства связанных OLE‑кадров объектов.

Этот Python‑код показывает, как проверить, связан ли OLE‑объект, и затем получить путь к связанному файлу:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Проверить, связан ли OLE‑объект.
        if ole_frame.isObjectLink():
            # Вывести полный путь к связанному файлу.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Вывести относительный путь к связанному файлу, если он есть.
            # Только презентации PPT могут содержать относительный путь.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Изменение данных OLE‑объекта**

{{% alert color="info" title="Примечание" %}}

В этом разделе пример кода использует [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).

{{% /alert %}}

Если OLE‑объект уже внедрён в слайд, его можно легко получить и изменить его данные следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав объект класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Получите форму OLE‑кадра объекта.  
   В нашем примере использовался ранее созданный PPTX, содержащий одну форму на первом слайде. Затем мы проверили, что объект является [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/). Это и был нужный OLE‑кадр объекта.
4. После получения доступа к OLE‑кадру вы можете выполнять любые операции с ним.
5. Создайте объект [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) и получите доступ к OLE‑данным.
6. Получите нужный [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) и измените данные.
7. Сохраните обновлённый [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) в поток.
8. Измените данные OLE‑объекта из потока.

В примере ниже OLE‑кадр объекта (внедрённый объект диаграммы Excel) доступен, и его файловые данные изменяются для обновления данных диаграммы.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # Прочитать данные OLE‑объекта как объект Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Изменить данные рабочей книги.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Изменить данные объекта OLE‑кадра.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Внедрение других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Python via Java позволяет внедрять в слайды и другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользователя вставленный объект автоматически открывается в соответствующей программе, либо пользователь получает запрос выбрать подходящую программу для открытия.

Этот Python‑код показывает, как внедрить HTML и ZIP в слайд:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка типов файлов для внедренных объектов**

При работе с презентациями может потребоваться заменить старый OLE‑объект новым или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Python via Java позволяет задать тип файла для внедрённого объекта, что даёт возможность обновлять данные OLE‑кадра или его расширение.

Этот Python‑код показывает, как установить тип файла для внедрённого OLE‑объекта как `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Изменить тип файла на ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка изображений значков и заголовков для внедренных объектов**

После внедрения OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот просмотр виден пользователям до доступа к объекту. Если требуется использовать определённое изображение и текст в качестве элементов предварительного просмотра, можно задать изображение значка и заголовок с помощью Aspose.Slides for Python via Java.

Этот Python‑код показывает, как задать изображение значка и заголовок для внедрённого объекта:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Добавить изображение в ресурсы презентации.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Установить заголовок и изображение для предварительного просмотра OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Предотвращение изменения размеров и перемещения OLE‑кадра объектов**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с запросом обновления ссылок. Нажатие кнопки «Update Links» может изменить размер и положение OLE‑кадра, так как PowerPoint обновляет данные из связанного OLE‑объекта и перестраивает предварительный просмотр. Чтобы предотвратить запрос PowerPoint об обновлении данных объекта, установите метод [setUpdateAutomatic](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) класса [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/) в значение `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Извлечение внедренных файлов**

Aspose.Slides for Python via Java позволяет извлекать файлы, внедрённые в слайды в виде OLE‑объектов, следующим способом:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), содержащий OLE‑объекты, которые нужно извлечь.
2. Пройдитесь по всем формам в презентации и получите формы [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/).
3. Извлеките данные внедрённых файлов из OLE‑кадров и запишите их на диск.

Этот Python‑код показывает, как извлечь файлы, внедрённые в слайд в виде OLE‑объектов:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**Будет ли OLE‑содержание отображаться при экспорте слайдов в PDF/изображения?**

Отображается то, что видно на слайде — значок/заменяющее изображение (превью). «Живое» OLE‑содержание не выполняется во время рендеринга. При необходимости задайте собственное изображение превью, чтобы гарантировать ожидаемый вид в экспортированном PDF.

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет [блокировки на уровне формы](/slides/ru/python-java/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещение.

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Для стабильного отображения следуйте рекомендациям из [Working Solution for Worksheet Resizing](/slides/ru/python-java/working-solution-for-worksheet-resizing/) — либо подгоните кадр под диапазон, либо масштабируйте диапазон до фиксированного кадра и задайте подходящее заменяющее изображение.

**Сохранятся ли относительные пути для связанных OLE‑объектов в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути встречаются в более старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или внедрение.