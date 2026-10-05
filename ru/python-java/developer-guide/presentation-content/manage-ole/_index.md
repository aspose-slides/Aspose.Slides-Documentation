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
- Java
- Aspose.Slides
description: "Оптимизируйте управление объектами OLE в PowerPoint и файлах OpenDocument с помощью Aspose.Slides for Python via Java. Встраивайте, обновляйте и экспортируйте содержимое OLE без проблем."
---
## **Введение**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) — это технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении с помощью связывания или встраивания.
{{% /alert %}}

Рассмотрим диаграмму, созданную в MS Excel. Эта диаграмма затем помещается в слайд PowerPoint. Такая диаграмма Excel считается объектом OLE.

- Объект OLE может отображаться в виде значка. В этом случае при двойном щелчке по значку диаграмма открывается в связанном приложении (Excel) или вам предлагается выбрать приложение для открытия или редактирования объекта.
- Объект OLE может отображать свои реальные содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается интерфейс диаграммы, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/python-java/) позволяет вставлять объекты OLE в слайды в виде кадров объектов OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)).

## **Добавить кадры объектов OLE в слайды**

Предполагая, что вы уже создали диаграмму в Microsoft Excel и хотите внедрить её в слайд в виде кадра объекта OLE с помощью Aspose.Slides for Python via Java, вы можете сделать это следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Прочитайте файл Excel как массив байтов.
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) на слайд, содержащий массив байтов и другую информацию об объекте OLE.
5. Запишите изменённую презентацию в файл PPTX.

В примере ниже мы добавили диаграмму из файла Excel на слайд в виде кадра объекта OLE с помощью Aspose.Slides for Python via Java.  
**Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) принимает расширение внедряемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint корректно определять тип файла и выбирать правильное приложение для открытия этого объекта OLE.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Подготовьте данные для объекта OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Добавьте кадр объекта OLE на слайд.
    frame_width = jpime.JFloat(slide_size.getWidth())
    frame_height = jpime.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Добавить связанные кадры объектов OLE**

Aspose.Slides for Python via Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) , содержащий ссылку на файл, вместо встраиваемых данных.

Этот код на Python показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) , содержащий связанный файл Excel, на слайд:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Добавьте кадр объекта OLE со связанным файлом Excel.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Доступ к кадрам объектов OLE**

Если объект OLE уже встроен в слайд, вы можете легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с встроенным объектом OLE, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде только одна форма. Затем мы проверили, что объект является [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). Это был нужный кадр объекта OLE для доступа.
4. После получения доступа к кадру объекта OLE вы можете выполнять любые операции над ним.

В примере ниже получен доступ к кадру объекта OLE (встроенному объекту диаграммы Excel в слайде) и его данным файла.

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

### **Доступ к свойствам связанного кадра объекта OLE**

Aspose.Slides позволяет получать свойства связанных кадров объектов OLE.

Этот код на Python показывает, как проверить, связан ли объект OLE, и затем получить путь к связанному файлу:

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

        # Проверить, связан ли объект OLE.
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

## **Изменить данные объекта OLE**

{{% alert color="info" title="Note" %}}
В этом разделе приведён пример кода, использующий [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Если объект OLE уже встроен в слайд, вы можете легко получить к нему доступ и изменить его данные следующим образом:

1. Загрузите презентацию с встроенным объектом OLE, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Получите форму OLE‑кадра. В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде одна форма. Затем мы проверили, что объект является [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). Это был нужный кадр объекта OLE для доступа.
4. После получения доступа к кадру объекта OLE вы можете выполнять любые операции над ним.
5. Создайте объект [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) и получите доступ к данным OLE.
6. Получите нужный [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) и измените данные.
7. Сохраните обновлённый [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) в поток.
8. Измените данные объекта OLE из потока.

В примере ниже получен доступ к кадру объекта OLE (встроенному объекту диаграммы Excel в слайде), и данные его файла изменяются для обновления данных диаграммы.

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

## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Python via Java позволяет встраивать другие типы файлов в слайды. Например, можно вставлять файлы HTML, PDF и ZIP в виде объектов. Когда пользователь двойным щелчком открывает вставленный объект, он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящую программу для его открытия.

Этот код на Python показывает, как встроить HTML и ZIP в слайд:

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

## **Установить типы файлов для встроенных объектов**

При работе с презентациями может потребоваться заменить старые объекты OLE новыми или заменить неподдерживаемый объект OLE поддерживаемым. Aspose.Slides for Python via Java позволяет задать тип файла для встроенного объекта, что предоставляет возможность обновить данные кадра OLE или его расширение.

Этот код на Python показывает, как установить тип файла для встроенного объекта OLE как `zip`:

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

## **Установить изображения значков и заголовки для встроенных объектов**

После встраивания объекта OLE автоматически добавляется предварительный просмотр в виде значка. Этот предварительный просмотр видят пользователи перед доступом к объекту OLE или его открытием. Если вы хотите использовать определённое изображение и текст в качестве элементов предварительного просмотра, вы можете задать изображение значка и заголовок с помощью Aspose.Slides for Python via Java.

Этот код на Python показывает, как задать изображение значка и заголовок для встроенного объекта:

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

## **Предотвратить изменение размеров и перемещение кадра объекта OLE**

После того как вы добавите связанный объект OLE в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с предложением обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и позицию кадра объекта OLE, поскольку PowerPoint обновляет данные из связанного объекта OLE и обновляет предварительный просмотр. Чтобы отключить запрос PowerPoint об обновлении данных объекта, вызовите метод [setUpdateAutomatic](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) класса [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) с параметром `False`:

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

## **Извлечение встроенных файлов**

Aspose.Slides for Python via Java позволяет извлекать файлы, встроенные в слайды в виде объектов OLE, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) , содержащий объекты OLE, которые вы хотите извлечь.
2. Пройдите по всем формам в презентации и получите доступ к формам [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) .
3. Получите данные встроенных файлов из кадров объектов OLE и запишите их на диск.

Этот код на Python показывает, как извлечь файлы, встроенные в слайд в виде объектов OLE:

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

**Будет ли содержимое OLE отрисовываться при экспорте слайдов в PDF/изображения?**

Отображается то, что видно на слайде — значок/заменяющее изображение (превью). «Живое» содержимое OLE не исполняется во время рендеринга. При необходимости задайте собственное изображение превью, чтобы обеспечить ожидаемый вид в экспортированном PDF.

Чтобы также сохранить встроенный файл как вложение PDF, вызовите [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) с `True`. Эта опция по умолчанию отключена. Пример и инструкции по проверке вложения см. в статье [Preserve Embedded OLE Files as PDF Attachments](/slides/ru/python-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Как можно заблокировать объект OLE на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет [shape-level locks](/slides/ru/python-java/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Чтобы обеспечить стабильный внешний вид, следуйте рекомендациям из [Working Solution for Worksheet Resizing](/slides/ru/python-java/working-solution-for-worksheet-resizing/) — либо подгоните кадр под диапазон, либо масштабируйте диапазон до фиксированного кадра и задайте подходящее заменяющее изображение.

**Сохранятся ли относительные пути для связанных объектов OLE в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути присутствуют в более старом формате PPT. Для переносимости предпочтительно использовать надёжные абсолютные пути/доступные URI или встраивание.