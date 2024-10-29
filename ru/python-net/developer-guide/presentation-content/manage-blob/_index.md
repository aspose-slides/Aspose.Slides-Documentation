---
title: Управление BLOB
type: docs
weight: 10
url: /ru/python-net/manage-blob/
keywords: "Добавить BLOB, Экспортировать BLOB, Добавить изображение как BLOB, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавить BLOB в презентацию PowerPoint на Python. Экспортировать BLOB. Добавить изображение как BLOB"
---

### **О BLOB**

**BLOB** (**Binary Large Object**) - это обычно большой объект (фото, презентация, документ или медиа), сохраненный в двоичных форматах.

Aspose.Slides для Python через .NET позволяет использовать BLOB для объектов таким образом, чтобы уменьшить потребление памяти при работе с большими файлами.

# **Используйте BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/python-net/) для .NET позволяет добавлять большие файлы (в данном случае - большой видеофайл) через процесс, включающий BLOB, чтобы снизить потребление памяти.

Этот пример на Python показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Создает новую презентацию, в которую будет добавлено видео
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Добавим видео в презентацию - мы выбрали поведение KeepLocked, потому что не собираемся
        # получать доступ к файлу "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Сохраняет презентацию. Хотя большая презентация выводится, потребление памяти
        # остается низким на протяжении всего жизненного цикла объекта pres
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **Экспорт большого файла через BLOB из презентации**
Aspose.Slides для Python через .NET позволяет экспортировать большие файлы (в данном случае - аудиофайл или видеофайл) через процесс, включающий BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиафайл из презентации, но не хотите, чтобы файл загружался в память вашего компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти.

Этот код на Python демонстрирует описанную операцию:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Сохраним каждое видео в файл. Чтобы избежать высокого потребления памяти, нам необходим буфер, который будет
	# использоваться для передачи данных из стрима видео презентации в поток для вновь созданного видеофайла.
    bufferSize = 8 * 1024

	# Итерирует через видео
    index = 0
    # При необходимости вы можете применить те же шаги к аудиофайлам. 
    for video in pres.videos:
		# Открывает поток видео презентации. Обратите внимание, что мы намеренно избегали доступа к свойствам
		# таким как video.BinaryData - потому что это свойство возвращает массив байтов, содержащий полное видео, что затем
		# приводит к загрузке байтов в память. Мы используем video.GetStream, который возвращает Stream - и НЕ
		# требует от нас загрузки всего видео в память.
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
С помощью методов из интерфейса [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) и [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) класса, вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

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

Как правило, для загрузки большой презентации компьютерам требуется много временной памяти. Все содержимое презентации загружается в память, и файл (из которого была загружена презентация) перестает использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), которая содержит видеофайл размером 1.5 ГБ. Стандартный способ загрузки презентации описан в этом коде на Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Но этот метод потребляет около 1.6 ГБ временной памяти.

### **Загрузка большой презентации как BLOB**

С помощью процесса, включающего BLOB, вы можете загрузить большую презентацию, используя при этом немного памяти. Этот код на Python описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

#### **Изменение папки для временных файлов**

При использовании процесса BLOB ваш компьютер создает временные файлы в папке по умолчанию для временных файлов. Если вы хотите, чтобы временные файлы хранились в другой папке, вы можете изменить настройки хранения, используя `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Информация" color="info" %}}

Когда вы используете `temp_files_root_path`, Aspose.Slides не создает автоматически папку для хранения временных файлов. Вы должны создать папку вручную.

{{% /alert %}}