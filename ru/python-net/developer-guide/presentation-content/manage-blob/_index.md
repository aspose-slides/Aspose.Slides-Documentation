---
title: Управление BLOB в презентациях с помощью Python для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/python-net/manage-blob/
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
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides for Python via .NET для упрощения операций с файлами PowerPoint и OpenDocument и эффективной обработки презентаций."
---

## **О BLOB**

**BLOB** (**Binary Large Object**, «Большой двоичный объект») обычно представляет собой большой элемент (фото, презентацию, документ или мультимедиа), сохраняемый в двоичных форматах. 

Aspose.Slides for Python via .NET позволяет использовать BLOB‑ы для объектов таким образом, чтобы уменьшить потребление памяти при работе с большими файлами. 

## **Используйте BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/python-net/) for .NET позволяет добавить большие файлы (в данном случае большой видео‑файл) через процесс, использующий BLOB, чтобы снизить потребление памяти.

Этот пример на Python показывает, как добавить большой видео‑файл через процесс BLOB в презентацию:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Создаём новую презентацию, в которую будет добавлено видео
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Добавим видео в презентацию — выбираем поведение KeepLocked, потому что
        # не планируем обращаться к файлу "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Сохраняем презентацию. Несмотря на то, что получаем большую презентацию,
        # потребление памяти остаётся низким в течение всего жизненного цикла объекта pres
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Экспорт большого файла через BLOB из презентации**
Aspose.Slides for Python via .NET позволяет экспортировать большие файлы (в данном случае аудио‑ или видео‑файл) через процесс, использующий BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиа‑файл из презентации, но не загружать его полностью в память компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти. 

Этот пример на Python демонстрирует описанную операцию:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Сохраняем каждое видео в отдельный файл. Чтобы избежать высокого потребления памяти,
	# нам нужен буфер, который будет использоваться для передачи данных из видеопотока презентации
	# в поток нового видео‑файла.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Проходим по всем видео
    index = 0
    # При необходимости те же шаги можно выполнить для аудио‑файлов.
    for video in pres.videos:
		# Открываем видеопоток презентации. Обратите внимание, что мы сознательно избегаем
		# доступа к свойствам вроде video.BinaryData, поскольку это свойство возвращает массив байт,
		# содержащий всё видео, что приводит к загрузке его в память. Мы используем video.GetStream,
		# который возвращает Stream и НЕ требует загрузки всего видео в память.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Добавление изображения как BLOB в презентацию**
С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) и класса [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) можно добавить большое изображение как поток, чтобы оно рассматривалось как BLOB. 

Этот пример на Python показывает, как добавить большое изображение через процесс BLOB:

```py
import aspose.slides as slides

# Создаём новую презентацию, в которую будет добавлено изображение.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Память и крупные презентации**

Обычно для загрузки крупной презентации компьютерам требуется значительный объём временной памяти. Всё содержимое презентации загружается в память, и файл, из которого была загружена презентация, перестаёт использоваться. 

Рассмотрим большую PowerPoint‑презентацию (large.pptx), содержащую 1,5 ГБ видео‑файл. Стандартный способ загрузки презентации показан в следующем коде на Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Но этот метод потребляет около 1,6 ГБ временной памяти. 

### **Загрузка большой презентации как BLOB**

Через процесс, использующий BLOB, можно загрузить большую презентацию, используя минимум памяти. Этот код на Python описывает реализацию, где процесс BLOB применяется для загрузки большого файла презентации (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Изменение папки для временных файлов**

При использовании процесса BLOB ваш компьютер создаёт временные файлы в папке по умолчанию. Если вы хотите, чтобы временные файлы хранились в другой папке, измените настройки хранилища с помощью `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
При использовании `temp_files_root_path` Aspose.Slides не создаёт папку для временных файлов автоматически. Вам необходимо создать папку вручную. 
{{% /alert %}}

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и управляются параметрами BLOB?**

Большие двоичные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Сам файл презентации также участвует в обработке BLOB при загрузке или сохранении. Эти объекты регулируются политиками BLOB, позволяющими управлять использованием памяти и записью во временные файлы при необходимости.

**Где настроить правила обработки BLOB во время загрузки презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/). Здесь задаётся ограничение памяти для BLOB, разрешение/запрет временных файлов, корневой путь для временных файлов и поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как сбалансировать скорость и память?**

Да. Хранение BLOB в памяти повышает скорость, но увеличивает потребление ОЗУ; снижение лимита памяти перекладывает работу на временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Настройте порог [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) для достижения оптимального баланса под вашу нагрузку и окружение.

**Помогают ли настройки BLOB при открытии чрезвычайно больших презентаций (гигабайтные файлы)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) созданы для таких сценариев: включение временных файлов и использование блокировки источника могут заметно снизить пиковое потребление ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Можно ли применять политики BLOB при загрузке из потоков, а не из файлов на диске?**

Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются при разрешении, что позволяет предсказуемо контролировать потребление памяти во время обработки.