---
title: Управление BLOB в презентациях с помощью Python для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/python-net/manage-blob/
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
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для Python через .NET, оптимизируя операции с файлами PowerPoint и OpenDocument для эффективной работы с презентациями."
---
## **Обзор**

Aspose.Slides обеспечивает обработку больших двоичных данных в презентациях на основе BLOB, что помогает уменьшить потребление памяти при работе с большими изображениями, аудио, видео и файлами презентаций.

В этой статье показано, как использовать обработку на основе BLOB для добавления больших медиафайлов в презентацию, экспорта больших медиафайлов из презентации и более эффективной загрузки больших презентаций. Также объясняется, как использовать временные файлы во время обработки и как изменить папку, в которой они хранятся.

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентацию, документ или медиа), сохранённый в двоичном формате.

Aspose.Slides for Python via .NET позволяет использовать BLOB‑ы для объектов таким образом, чтобы снижать потребление памяти при работе с большими файлами.

## **Использование BLOB для снижения потребления памяти**

### **Добавить большой файл через BLOB в презентацию**

[Aspose.Slides](/slides/ru/python-net/) for .NET позволяет добавлять большие файлы (в данном случае большой видеофайл) через процесс, включающий BLOB, чтобы снизить потребление памяти.

Этот пример на Python показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Создает новую презентацию, в которую будет добавлено видео
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Давайте добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что
        # не планируем обращаться к файлу "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
        # остается низким на протяжении жизненного цикла объекта pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Экспортировать большой файл через BLOB из презентации**

Aspose.Slides for Python via .NET позволяет экспортировать большие файлы (в данном случае аудио‑ или видеофайл) через процесс, включающий BLOB, из презентаций. Например, может потребоваться извлечь большой медиафайл из презентации, не загружая его полностью в память компьютера. При экспорте файла через процесс BLOB потребление памяти остаётся низким.

Этот код на Python демонстрирует описанную операцию:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Сохраним каждое видео в файл. Чтобы предотвратить высокое потребление памяти, нам нужен буфер, который будет использоваться
	# для передачи данных из видеопотока презентации в поток только что созданного видеофайла.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Перебирает видео
    index = 0
    # При необходимости вы можете применить те же шаги к аудиофайлам. 
    for video in pres.videos:
		# Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегали доступа к свойствам
		# таким как video.BinaryData — потому что это свойство возвращает массив байтов, содержащий полное видео, что затем
		# заставляет байты загружаться в память. Мы используем video.GetStream, который возвращает Stream и НЕ
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

### **Добавить изображение как BLOB в презентацию**

С помощью методов класса [**ImageCollection**](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/) можно добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

Этот код на Python показывает, как добавить большое изображение через процесс BLOB:

```py
import aspose.slides as slides

# создает новую презентацию, в которую будет добавлено изображение.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Память и большие презентации**

Обычно для загрузки большой презентации компьютерам требуется много временной памяти. Всё содержимое презентации загружается в память, и файл, из которого была загружена презентация, перестаёт использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный способ загрузки презентации описан в этом коде на Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Но этот метод потребляет около 1,6 ГБ временной памяти.

### **Загрузить большую презентацию как BLOB**

Через процесс, включающий BLOB, можно загрузить большую презентацию, используя небольшое количество памяти. Этот код на Python описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Изменить папку для временных файлов**

При использовании процесса BLOB ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите хранить временные файлы в другой папке, можно изменить настройки хранилища, используя `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
При использовании `temp_files_root_path` Aspose.Slides не создаёт папку для хранения временных файлов автоматически. Папку необходимо создать вручную.
{{% /alert %}}

### **Освободить объекты Presentation для высвобождения памяти**

При обработке больших презентаций убедитесь, что экземпляр [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) правильно освобождается, чтобы освобождать занятые им ресурсы памяти. Рекомендованный способ — использовать контекстный менеджер (`with slides.Presentation(...) as presentation:`), как показано в примерах выше; он автоматически закрывает презентацию и освобождает неуправляемые ресурсы при выходе из блока.

Если вы создаёте презентацию без блока `with`, явно вызовите `presentation.dispose()` после завершения работы с ней и удалите все оставшиеся ссылки, чтобы сборщик мусора Python смог освободить память.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...обработать презентацию...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Явно освободить ресурсы.
presentation.dispose()
```

## **Часто задаваемые вопросы**

**Какие данные в презентации Aspose.Slides обрабатываются как BLOB и контролируются параметрами BLOB?**  
Большие двоичные объекты, такие как изображения, аудио и видео, обрабатываются как BLOB. Сам файл презентации также участвует в обработке BLOB при загрузке или сохранении. Эти объекты управляются политиками BLOB, позволяющими контролировать использование памяти и переключаться на временные файлы при необходимости.

**Где я могу настроить правила обработки BLOB во время загрузки презентации?**  
Используйте [LoadOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/blobmanagementoptions/). Здесь задаётся лимит памяти для BLOB, разрешение или запрет временных файлов, корневая папка для временных файлов и поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как найти баланс между скоростью и памятью?**  
Да. Хранение BLOB в памяти обеспечивает максимальную скорость, но увеличивает потребление ОЗУ; снижение лимита памяти переводит большую часть работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Настройте порог [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/ru/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/), чтобы достичь оптимального баланса для вашего сценария и окружения.

**Помогают ли параметры BLOB при открытии экстремально больших презентаций (например, гигабайтных)?**  
Да. [BlobManagementOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/blobmanagementoptions/) предназначены для подобных сценариев: включение временных файлов и использование блокировки источника могут значительно сократить пиковое использование ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Можно ли использовать политики BLOB при загрузке из потоков вместо файлов на диске?**  
Да. Те же правила применяются к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если это разрешено, позволяя предсказуемо контролировать потребление памяти во время обработки.