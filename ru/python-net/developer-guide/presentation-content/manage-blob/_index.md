---
title: Управление BLOB в презентациях с Python для эффективного использования памяти
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
description: "Управляйте данными BLOB в Aspose.Slides для Python через .NET, чтобы оптимизировать операции с файлами PowerPoint и OpenDocument для эффективной работы с презентациями."
---
## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентацию, документ или медиа), сохранённый в бинарных форматах. 

Aspose.Slides for Python via .NET позволяет использовать BLOB для объектов таким образом, чтобы уменьшить потребление памяти при работе с большими файлами. 

## **Использовать BLOB для снижения потребления памяти**

### **Добавить большой файл через BLOB в презентацию**

[Aspose.Slides](/slides/ru/python-net/) for .NET позволяет добавлять большие файлы (в данном случае большой видеофайл) с использованием процесса, включающего BLOB, чтобы снизить потребление памяти.

Этот пример на Python показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Создаёт новую презентацию, в которую будет добавлено видео
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что мы
        # не планируем обращаться к файлу "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
        # остаётся низким на протяжении всего жизненного цикла объекта pres
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **Экспортировать большой файл через BLOB из презентации**
Aspose.Slides for Python via .NET позволяет экспортировать большие файлы (в данном случае аудио или видео файл) с использованием процесса, включающего BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиа‑файл из презентации, но вы не хотите, чтобы файл загружался в память компьютера. При экспорте файла через процесс BLOB потребление памяти остаётся низким. 

Этот код на Python демонстрирует описанную операцию:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Сохраним каждое видео в файл. Чтобы предотвратить высокое потребление памяти, нам нужен буфер, который будет использован
	# для передачи данных из видеопотока презентации в поток нового создаваемого видеофайла.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Перебирает видео
    index = 0
    # При необходимости вы можете применить те же шаги к аудиофайлам. 
    for video in pres.videos:
		# Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегали доступа к свойствам
		# таким как video.BinaryData — потому что это свойство возвращает массив байтов, содержащий полное видео, что затем
		# приводит к загрузке байтов в память. Мы используем video.GetStream, который возвращает Stream и НЕ
		#  не требует загружать всё видео в память.
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
С помощью методов класса [**ImageCollection**](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/) вы можете добавить большое изображение как поток, чтобы оно было обработано как BLOB. 

Этот код на Python показывает, как добавить большое изображение через процесс BLOB:

```py
import aspose.slides as slides

# создаёт новую презентацию, в которой будет добавлено изображение.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Память и большие презентации**

Как правило, для загрузки большой презентации компьютерам требуется много временной памяти. Всё содержимое презентации загружается в память, и файл (из которого была загружена презентация) перестаёт использоваться. 

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл объёмом 1,5 ГБ. Стандартный метод загрузки презентации описан в этом коде на Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Однако этот метод потребляет около 1,6 ГБ временной памяти. 

### **Загрузить большую презентацию как BLOB**

С помощью процесса, включающего BLOB, вы можете загрузить большую презентацию, используя минимум памяти. Этот код на Python описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):

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
При использовании `temp_files_root_path` Aspose.Slides не создаёт автоматически папку для хранения временных файлов. Вам необходимо создать папку вручную. 
{{% /alert %}}

### **Освобождать объекты Presentation для высвобождения памяти**

При обработке больших презентаций убедитесь, что экземпляр `Presentation` корректно освобожден, чтобы высвободить занятая им память. Рекомендуемый способ — использовать менеджер контекста (`with slides.Presentation(...) as presentation:`), как показано в примерах выше; он автоматически закрывает презентацию и освобождает неуправляемые ресурсы при выходе из блока.

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

Большие бинарные объекты, такие как изображения, аудио и видео, обрабатываются как BLOB. При загрузке или сохранении также происходит обработка всего файла презентации с использованием BLOB. Эти объекты управляются политиками BLOB, позволяющими контролировать использование памяти и при необходимости выгружать данные во временные файлы.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/blobmanagementoptions/). Здесь вы задаёте ограничение памяти для BLOB, разрешаете или запрещаете временные файлы, указываете корневой путь для временных файлов и выбираете поведение блокировки источника.

**Влияют ли настройки BLOB на производительность, и как найти баланс между скоростью и потреблением памяти?**

Да. Хранение BLOB в памяти максимизирует скорость, но увеличивает потребление ОЗУ; снижение лимита памяти переводит большую часть работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Настройте порог [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/ru/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/), чтобы достичь нужного баланса для вашей нагрузки и среды.

**Помогают ли настройки BLOB при открытии чрезвычайно больших презентаций (например, гигабайтных)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/blobmanagementoptions/) разработаны для таких сценариев: включение временных файлов и использование блокировки источника может значительно снизить пиковое потребление ОЗУ и стабилизировать процесс обработки очень больших наборов слайдов.

**Могу ли я использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются при разрешении, что обеспечивает предсказуемое использование памяти во время обработки.