---
title: Управление BLOB‑ами презентаций в Python через Java для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/python-java/manage-blob/
keywords:
- большой объект
- большой элемент
- большой файл
- добавить BLOB
- экспортировать BLOB
- добавить изображение как BLOB
- уменьшить память
- потребление памяти
- большая презентация
- временный файл
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Управляйте BLOB‑данными в Aspose.Slides для Python через Java, оптимизируя операции с файлами PowerPoint и OpenDocument для эффективной обработки презентаций."
---
## **Обзор**

Aspose.Slides предоставляет обработку на основе BLOB для больших бинарных данных в презентациях, помогая уменьшить потребление памяти при работе с большими изображениями, аудио, видео и файлами презентаций.

В этой статье показано, как использовать обработку на основе BLOB для добавления больших медиафайлов в презентацию, экспорта больших медиафайлов из презентации и более эффективной загрузки больших презентаций. Также объясняется, как можно использовать временные файлы во время обработки и как изменить папку, в которой они хранятся.

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой крупный элемент (фото, презентацию, документ или медиа), сохранённый в бинарном формате.

Aspose.Slides for Python via Java позволяет использовать BLOB‑ы для объектов способом, который уменьшает потребление памяти при работе с большими файлами.

{{% alert color="info" title="Note" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через её поток приводит к копированию содержимого презентации и замедлению загрузки. Поэтому, когда вы планируете загрузить большую презентацию, настоятельно рекомендуется использовать путь к файлу презентации, а не её поток.
{{% /alert %}}

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла в презентацию с помощью BLOB**

[Aspose.Slides](/slides/ru/python-java/) for Python via Java позволяет добавлять большие файлы (в данном случае большой видеофайл) через процесс, использующий BLOB‑ы, чтобы уменьшить потребление памяти.

Этот Python‑код показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Создайте новую презентацию, в которую будет добавлено видео.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Оставьте поток заблокированным, так как мы не планируем обращаться к видеофайлу.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Сохраните презентацию, поддерживая низкое потребление памяти.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Экспорт большого файла из презентации с помощью BLOB**
Aspose.Slides for Python via Java позволяет экспортировать большие файлы (например, аудио‑ или видеофайл) из презентаций через процесс, включающий BLOB‑ы. Например, вам может потребоваться извлечь большой медиафайл из презентации, но вы не хотите загружать его в память компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти.

Этот код на Python демонстрирует описанную операцию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Заблокировать исходный файл вместо загрузки его в память.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Передавать видеоданные через буфер, чтобы поддерживать низкое потребление памяти.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Использовать поток вместо загрузки всего видео в массив байтов.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # При необходимости применить те же шаги к аудиофайлам.
finally:
    presentation.dispose()
```

### **Добавление изображения как BLOB в презентацию**
С помощью методов класса [ImageCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagecollection/) можно добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

Этот Python‑код показывает, как добавить большое изображение через процесс BLOB:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Создайте новую презентацию, в которую будет добавлено изображение.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Оставьте поток заблокированным, так как мы не планируем обращаться к файлу изображения.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Сохраните презентацию, поддерживая низкое потребление памяти.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Память и большие презентации**

Обычно для загрузки большой презентации компьютерам требуется много временной памяти. Всё содержимое презентации загружается в память, а файл, из которого была загружена презентация, прекращает использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл объёмом 1,5 ГБ. Стандартный метод загрузки презентации показан в этом Python‑коде:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Но этот метод потребляет около 1,6 ГБ временной памяти.

### **Загрузка большой презентации как BLOB**

Используя обработку BLOB, можно загрузить большую презентацию, потребляя минимум памяти. Этот Python‑код показывает, как использовать обработку BLOB для загрузки большого файла презентации (large.pptx):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Изменение папки для временных файлов**

При использовании процесса BLOB ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите хранить временные файлы в другой папке, можно изменить настройки хранилища с помощью [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}
При использовании [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) Aspose.Slides не создаёт автоматически папку для хранения временных файлов. Папку необходимо создать вручную.
{{% /alert %}}

### **Освобождение объектов Presentation для освобождения памяти**

При обработке больших презентаций необходимо правильно освобождать объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), чтобы высвободить занимаемую им память. Вызовите [Presentation.dispose](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#dispose) после завершения работы с презентацией, чтобы освободить неуправляемые ресурсы.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...обработать презентацию...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Явно освободить ресурсы.
    presentation.dispose()
```

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и контролируются параметрами BLOB?**

Крупные бинарные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB‑ы. Сам файл презентации также участвует в обработке BLOB при загрузке или сохранении. Эти объекты управляются политиками BLOB, позволяющими контролировать использование памяти и запись во временные файлы при необходимости.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/blobmanagementoptions/). Здесь вы задаёте ограничение памяти для BLOB‑ов, разрешаете или запрещаете использование временных файлов, указываете корневой путь для временных файлов и выбираете поведение блокировки источника.

**Влияют ли настройки BLOB на производительность, и как сбалансировать скорость и память?**

Да. Хранение BLOB‑ов в памяти максимизирует скорость, но увеличивает потребление ОЗУ; снижение лимита памяти переводит большую часть работы во временные файлы, уменьшая ОЗУ, но увеличивая ввод‑вывод. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ru/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory), чтобы найти оптимальный баланс для вашей нагрузки и среды.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, в гигабайтах)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника могут заметно снизить пиковое потребление ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Можно ли использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применяются к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если это разрешено, что сохраняет предсказуемое использование памяти во время обработки.