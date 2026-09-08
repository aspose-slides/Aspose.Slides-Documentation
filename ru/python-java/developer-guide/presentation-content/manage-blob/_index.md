---
title: Управление BLOB презентаций в Python через Java для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/python-java/manage-blob/
keywords:
- крупный объект
- крупный элемент
- крупный файл
- добавить BLOB
- экспортировать BLOB
- добавить изображение как BLOB
- сократить память
- потребление памяти
- крупная презентация
- временный файл
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для Python через Java, чтобы оптимизировать операции с файлами PowerPoint и OpenDocument для эффективной обработки презентаций."
---
## **Обзор**

Aspose.Slides предоставляет обработку BLOB для больших двоичных данных в презентациях, что помогает уменьшить потребление памяти при работе с большими изображениями, аудио, видео и файлами презентаций.

В этой статье показано, как использовать обработку на основе BLOB для добавления больших медиафайлов в презентацию, экспорта больших медиа из презентации и более эффективной загрузки больших презентаций. Также объясняется, как можно использовать временные файлы во время обработки и как изменить папку, в которой они хранятся.

## **О BLOB**

**BLOB** (**Binary Large Object**) — обычно крупный объект (фото, презентация, документ или медиа), сохранённый в бинарном формате.

Aspose.Slides for Python via Java позволяет использовать BLOB для объектов таким образом, чтобы снизить потребление памяти при работе с большими файлами.

{{% alert color="info" title="Примечание" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через её поток приведёт к копированию содержимого презентации и замедлению загрузки. Поэтому, когда вы намерены загрузить большую презентацию, настоятельно рекомендуется использовать путь к файлу презентации, а не её поток.
{{% /alert %}}

## **Использовать BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/python-java/) for Python via Java позволяет добавить большие файлы (в данном случае большой видеофайл) через процесс, использующий BLOB, чтобы снизить потребление памяти.

Этот код на Python показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Создать новую презентацию, в которую будет добавлено видео.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
            # Держать поток заблокированным, так как мы не планируем обращаться к файлу видео.
            video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
            presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

            # Сохранить презентацию, поддерживая низкое потребление памяти.
            presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Экспорт большого файла через BLOB из презентации**

Aspose.Slides for Python via Java позволяет экспортировать большие файлы (в данном случае аудио или видеофайл) через процесс, использующий BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиафайл из презентации, но вы не хотите, чтобы файл загружался в память компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти.

Этот код на Python демонстрирует описанную операцию:

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Заблокировать исходный файл вместо загрузки его в память.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Передавать видеоданные через буфер, чтобы снизить потребление памяти.
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
    # При необходимости выполнить те же действия для аудиофайлов.
finally:
    presentation.dispose()
```

### **Добавление изображения как BLOB в презентацию**

С помощью методов класса [ImageCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagecollection/) вы можете добавить большое изображение в виде потока, чтобы оно обрабатывалось как BLOB.

Этот код на Python показывает, как добавить большое изображение через процесс BLOB:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Создать новую презентацию, в которую будет добавлено изображение.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Держать поток заблокированным, так как мы не планируем обращаться к файлу изображения.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Сохранить презентацию, поддерживая низкое потребление памяти.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Память и крупные презентации**

Обычно для загрузки большой презентации компьютерам требуется значительное количество временной памяти. Вся содержимое презентации загружается в память, а файл (из которого была загружена презентация) перестаёт использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в следующем коде на Python:

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

Через процесс, использующий BLOB, вы можете загрузить большую презентацию, используя мало памяти. Этот код на Python описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):

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

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в стандартной папке для временных файлов. Если вы хотите, чтобы временные файлы хранились в другой папке, вы можете изменить настройки хранилища с помощью [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

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

{{% alert color="info" title="Примечание" %}}
При использовании [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) Aspose.Slides не создаёт папку для хранения временных файлов автоматически. Вам необходимо создать папку вручную.
{{% /alert %}}

### **Освобождение объектов Presentation для высвобождения памяти**

При обработке больших презентаций убедитесь, что экземпляр [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) правильно освобождён, чтобы освободить занятое им память. Вызовите [Presentation.dispose](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#dispose) после завершения работы с презентацией, чтобы освободить неуправляемые ресурсы.

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

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и управляются параметрами BLOB?**

Крупные двоичные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Сам файл презентации также включает обработку BLOB при загрузке или сохранении. Эти объекты регулируются политиками BLOB, позволяющими управлять использованием памяти и выгрузкой во временные файлы при необходимости.

**Где настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/) совместно с [BlobManagementOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/blobmanagementoptions/). Здесь можно задать ограничение памяти для BLOB, разрешить или запретить временные файлы, указать корневой путь для временных файлов и выбрать поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как сбалансировать скорость и память?**

Да. Хранение BLOB в памяти максимизирует скорость, но увеличивает потребление ОЗУ; снижение лимита памяти переводит большую часть работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ru/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory), чтобы найти оптимальный баланс для вашей нагрузки и среды.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, гигабайтных)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника могут значительно снизить пиковое использование ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Можно ли использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если это разрешено, позволяя предсказуемо контролировать использование памяти во время обработки.