---
title: Управление BLOB в презентациях с помощью Python для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/python-net/manage-blob/
keywords:
- крупный объект
- крупный элемент
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
description: "Управляйте данными BLOB в Aspose.Slides для Python через .NET, оптимизируя операции с файлами PowerPoint и OpenDocument для эффективной работы с презентациями."
---

## **Об BLOB**

**BLOB** (**Binary Large Object**) обычно является большим элементом (фотография, презентация, документ или медиа), сохранённым в бинарных форматах.

Aspose.Slides for Python via .NET позволяет использовать BLOB‑ы для объектов таким образом, который снижает потребление памяти при работе с большими файлами.

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/python-net/) for .NET позволяет добавлять большие файлы (в данном случае, большой видеофайл) через процесс, использующий BLOB‑ы, для снижения потребления памяти.

Этот пример на Python показывает, как добавить большой видеофайл через процесс BLOB в презентацию:
```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Создаёт новую презентацию, в которую будет добавлено видео
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Добавим видео в презентацию — мы выбрали режим KeepLocked, потому что
        # не планируем получать доступ к файлу "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Сохраняет презентацию. Пока выводится крупная презентация, потребление памяти
        # остаётся низким на протяжении жизненного цикла объекта pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **Экспорт большого файла через BLOB из презентации**

Aspose.Slides for Python via .NET позволяет экспортировать большие файлы (в данном случае, аудио‑ или видеофайл) через процесс, использующий BLOB‑ы, из презентаций. Например, вам может потребоваться извлечь большой медиа‑файл из презентации, но не загружать его в память компьютера. При экспорте файла через процесс BLOB вы сохраняете низкое потребление памяти.

Этот код на Python демонстрирует описанную операцию:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Сохраним каждое видео в файл. Чтобы предотвратить высокое использование памяти, нам нужен буфер, который будет использован
	# для передачи данных из видеопотока презентации в поток нового создаваемого видеофайла.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Проходит по всем видео
    index = 0
    # При необходимости вы можете применить те же действия к аудиофайлам. 
    for video in pres.videos:
		# Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегаем доступа к свойствам
		# таким как video.BinaryData — потому что это свойство возвращает массив байтов, содержащий полное видео, что затем
		# приводит к загрузке байтов в память. Мы используем video.GetStream, который возвращает Stream и НЕ
		#  требует загрузки всего видео в память.
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

С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) и класса [**ImageCollection** ](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

Этот код на Python показывает, как добавить большое изображение через процесс BLOB:
```py
import aspose.slides as slides

# создаёт новую презентацию, в которую будет добавлено изображение.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```


## **Память и большие презентации**

Обычно для загрузки большой презентации компьютерам требуется большое количество временной памяти. Всё содержимое презентации загружается в память, а файл (из которого была загружена презентация) более не используется.

Рассмотрим большую PowerPoint‑презентацию (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в следующем коде на Python:
```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```


Однако этот метод потребляет около 1,6 ГБ временной памяти.

### **Загрузка большой презентации как BLOB**

С помощью процесса, использующего BLOB, вы можете загрузить большую презентацию, потребляя минимум памяти. Этот код на Python описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):
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

При использовании процесса BLOB ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите хранить временные файлы в другой папке, вы можете изменить настройки хранилища, используя `temp_files_root_path`:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```


{{% alert title="Info" color="info" %}}
При использовании `temp_files_root_path` Aspose.Slides не создает папку для хранения временных файлов автоматически. Вам необходимо создать папку вручную.
{{% /alert %}}

## **Часто задаваемые вопросы**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и управляются параметрами BLOB?**

Крупные бинарные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Также весь файл презентации обрабатывается как BLOB при загрузке или сохранении. Эти объекты управляются политиками BLOB, которые позволяют контролировать использование памяти и при необходимости выгружать данные во временные файлы.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/). Здесь вы задаёете лимит памяти для BLOB, разрешаете или запрещаете создание временных файлов, выбираете корневой путь для временных файлов и определяете поведение блокировки источника.

**Влияют ли настройки BLOB на производительность, и как сбалансировать скорость и память?**

Да. Хранение BLOB в памяти обеспечивает максимальную скорость, но увеличивает потребление ОЗУ; снижение лимита памяти переводит большую часть работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Настройте порог [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/), чтобы достичь оптимального баланса для вашей нагрузки и окружения.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, в гигабайтах)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника могут значительно снизить пиковое использование ОЗУ и стабилизировать обработку очень больших презентаций.

**Могу ли я использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если это разрешено, обеспечивая предсказуемое использование памяти во время обработки.