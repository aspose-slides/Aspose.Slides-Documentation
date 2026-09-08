---
title: Управление OLE в презентациях с помощью Python
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/python-java/manage-ole/
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
- значок OLE
- заголовок OLE
- извлечь OLE
- извлечь объект
- извлечь файл
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Оптимизируйте управление OLE‑объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides для Python через Java. Внедряйте, обновляйте и экспортируйте OLE‑контент без проблем."
---
## **Введение**

{{% alert color="info" title="Примечание" %}}

OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении через связь или внедрение.

{{% /alert %}}

Рассмотрим диаграмму, созданную в MS Excel. Эта диаграмма помещается в слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом.

- OLE‑объект может отображаться в виде значка. В этом случае двойной щелчок по значку открывает диаграмму в связанном приложении (Excel) или запрашивает выбор приложения для открытия или редактирования.
- OLE‑объект может отображать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменить данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/ru/python-java/) позволяет вставлять OLE‑объекты на слайды в виде OLE‑рамок ([OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/)).

## **Добавление OLE‑рамок объектов на слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите внедрить её в слайд как OLE‑рамку с помощью Aspose.Slides for Python via Java. Сделать это можно так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Прочитайте файл Excel как массив байтов.
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/) на слайд, передав массив байтов и другую информацию об OLE‑объекте.
5. Запишите изменённую презентацию в файл PPTX.

В примере ниже мы добавили диаграмму из файла Excel на слайд как OLE‑рамку с помощью Aspose.Slides for Python via Java.  
**Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleembeddeddatainfo/) принимает расширение внедряемого объекта вторым параметром. Это расширение позволяет PowerPoint правильно интерпретировать тип файла и выбрать нужное приложение для открытия OLE‑объекта.

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

    # Добавьте OLE‑рамку объекта на слайд.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Добавление связанных OLE‑рамок объектов**

Aspose.Slides for Python via Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/) без внедрения данных, только со ссылкой на файл.

Этот код Python демонстрирует, как добавить [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/) со связанным файлом Excel на слайд:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Добавьте OLE‑рамку объекта со связанным файлом Excel.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Доступ к OLE‑рамкам объектов**

Если OLE‑объект уже внедрён в слайд, вы можете легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/).  
   В нашем примере мы использовали ранее созданный PPTX, содержащий единственную форму на первом слайде. Затем мы проверили, что объект является [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/). Это была требуемая OLE‑рамка объекта.
4. После получения доступа к OLE‑рамке вы можете выполнить любую операцию с ней.

В примере ниже доступ к OLE‑рамке объекта (внедрённый в слайд объект диаграммы Excel) и её файловым данным осуществляется программой.

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

        # Получить данные встроенного файла.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Получить расширение встроенного файла.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Доступ к свойствам связанной OLE‑рамки объекта**

Aspose.Slides позволяет получать свойства связанной OLE‑рамки объекта.

Этот код Python показывает, как проверить, связан ли OLE‑объект, и затем получить путь к связанному файлу:

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

            # Вывести относительный путь к связанному файлу, если он присутствует.
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

Если OLE‑объект уже внедрён в слайд, вы можете легко получить к нему доступ и изменить его данные следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Получите форму OLE‑рамки объекта.  
   В нашем примере мы использовали ранее созданный PPTX, содержащий одну форму на первом слайде. Затем мы проверили, что объект является [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/). Это была требуемая OLE‑рамка объекта.
4. После получения доступа к OLE‑рамке вы можете выполнить любую операцию с ней.
5. Создайте объект [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) и получите доступ к OLE‑данным.
6. Получите нужный [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) и измените данные.
7. Сохраните обновлённый [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) в поток.
8. Замените данные OLE‑объекта из потока.

В примере ниже OLE‑рамка объекта (внедрённый в слайд объект диаграммы Excel) доступна, и её файловые данные изменяются для обновления данных диаграммы.

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

        # Изменить данные объекта OLE‑рамки.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Внедрение других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Python via Java позволяет внедрять в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы как объекты. При двойном щелчке пользователя по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящее приложение.

Этот код Python демонстрирует, как внедрить HTML и ZIP в слайд:

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

## **Задание типа файлов для внедрённых объектов**

При работе с презентациями может потребоваться заменить старый OLE‑объект новым или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Python via Java позволяет задать тип файла для внедрённого объекта, что даёт возможность обновлять данные OLE‑рамки или её расширение.

Этот код Python показывает, как установить тип файла для внедрённого OLE‑объекта в `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

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

## **Задание изображений‑значков и заголовков для внедрённых объектов**

После внедрения OLE‑объекта автоматически добавляется предварительный просмотр в виде изображения‑значка. Этот просмотр видят пользователи до доступа к объекту. Если нужно использовать определённое изображение и текст в предварительном просмотре, вы можете задать изображение‑значок и заголовок с помощью Aspose.Slides for Python via Java.

Этот код Python показывает, как задать изображение‑значок и заголовок для внедрённого объекта:

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

    # Установить заголовок и изображение для превью OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Предотвращение изменения размера и перемещения OLE‑рамки объекта**

После добавления связанного OLE‑объекта на слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с предложением обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и положение OLE‑рамки, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и обновляет превью. Чтобы PowerPoint не предлагал обновлять данные объекта, установите метод [setUpdateAutomatic](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) класса [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/) в `False`:

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

## **Извлечение внедрённых файлов**

Aspose.Slides for Python via Java позволяет извлекать файлы, внедрённые в слайды как OLE‑объекты, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) — презентацию, содержащую OLE‑объекты, которые нужно извлечь.
2. Пройдитесь по всем формам в презентации и получите формы [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/).
3. Получите данные внедрённых файлов из OLE‑рамок и запишите их на диск.

Этот код Python демонстрирует, как извлечь файлы, внедрённые в слайд как OLE‑объекты:

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

**Будут ли OLE‑содержимое отображаться при экспорте слайдов в PDF/изображения?**

Отображается то, что видно на слайде — значок/заменяющее изображение (превью). «Живое» OLE‑содержимое не исполняется во время рендеринга. При необходимости задайте собственное превью‑изображение, чтобы обеспечить ожидаемый вид в экспортированном PDF.

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет [блокировки на уровне формы](/slides/ru/python-java/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Чтобы обеспечить стабильный внешний вид, следуйте рекомендациям из [Working Solution for Worksheet Resizing](/slides/ru/python-java/working-solution-for-worksheet-resizing/) — либо подгоните рамку под диапазон, либо масштабируйте диапазон до фиксированной рамки и задайте соответствующее заменяющее изображение.

**Сохраняются ли относительные пути для связанных OLE‑объектов в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути присутствуют в старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или внедрение.