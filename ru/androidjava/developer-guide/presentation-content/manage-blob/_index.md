---
title: Управление BLOB‑объектами презентаций на Android для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для Android через Java, чтобы оптимизировать работу с файлами PowerPoint и OpenDocument и обеспечить эффективную обработку презентаций."
---

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентацию, документ или мультимедиа), сохраняемый в бинарных форматах. 

Aspose.Slides for Android via Java позволяет использовать BLOBы для объектов таким образом, что снижается потребление памяти при работе с большими файлами.

{{% alert title="Info" color="info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через поток приведёт к копированию содержимого презентации и замедлению загрузки. Поэтому, когда вы планируете загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не её поток.
{{% /alert %}}

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/androidjava/) для Java позволяет добавлять большие файлы (в данном случае большой видеофайл) с помощью процесса, включающего BLOBы, чтобы снизить потребление памяти.

Этот пример на Java показывает, как добавить большой видеофайл через процесс BLOB в презентацию:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Создает новую презентацию, к которой будет добавлено видео
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что мы
        //не планируем обращаться к файлу "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
        // остается низким на протяжении жизненного цикла объекта pres
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **Экспорт большого файла через BLOB из презентации**

Aspose.Slides for Android via Java позволяет экспортировать большие файлы (в данном случае аудио или видео) с помощью процесса, включающего BLOBы, из презентаций. Например, вам может потребоваться извлечь большой медиа‑файл из презентации, но не загружать файл в память компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти.

Этот код на Java демонстрирует описанную операцию:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Locks the source file and does NOT load it into memory
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
    // to transfer the data from the presentation's video stream to a stream for a newly created video file.
    byte[] buffer = new byte[8 * 1024];

    // Iterates through the videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
        // like video.BinaryData - because this property returns a byte array containing a full video, which then
        // causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
        //  require us to load the whole video into the memory.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Memory consumption will remain low regardless of the size of the video or presentation.
    }
    // If necessary, you can apply the same steps for audio files. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **Добавление изображения как BLOB в презентацию**

С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) и класса [**ImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

Этот код на Java показывает, как добавить большое изображение через процесс BLOB:
```java
String pathToLargeImage = "large_image.jpg";

// создает новую презентацию, в которую будет добавлено изображение.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Добавим изображение в презентацию — мы выбираем поведение KeepLocked, потому что мы
		// НЕ планируем обращаться к файлу "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
		// остается низким в течение жизненного цикла объекта pres.
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


## **Память и большие презентации**

Как правило, для загрузки большой презентации компьютерам требуется много временной памяти. Всё содержимое презентации загружается в память, и файл (из которого была загружена презентация) перестаёт использоваться. 

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в этом коде на Java:
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


Но этот метод потребляет около 1,6 ГБ временной памяти. 

### **Загрузка большой презентации как BLOB**

С помощью процесса, включающего BLOB, вы можете загрузить большую презентацию, используя минимум памяти. Этот код на Java описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Изменение папки для временных файлов**

Когда используется процесс BLOB, ваш компьютер создает временные файлы в папке по умолчанию для временных файлов. Если вы хотите хранить временные файлы в другой папке, вы можете изменить настройки хранилища, используя `TempFilesRootPath`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
При использовании `TempFilesRootPath` Aspose.Slides не создаёт папку для хранения временных файлов автоматически. Вам необходимо создать эту папку вручную. 
{{% /alert %}}

## **FAQ**

**Какие данные в презентации Aspose.Slides обрабатываются как BLOB и контролируются параметрами BLOB?**

Крупные бинарные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Весь файл презентации также обрабатывается как BLOB при загрузке или сохранении. Эти объекты регулируются политиками BLOB, позволяющими управлять использованием памяти и выгрузкой во временные файлы при необходимости.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/). Здесь вы задаёте ограничение памяти для BLOB, разрешаете или запрещаете временные файлы, выбираете корневой путь для временных файлов и определяете поведение блокировки источника.

**Влияют ли настройки BLOB на производительность, и как сбалансировать скорость и память?**

Да. Хранение BLOB в памяти повышает скорость, но увеличивает потребление RAM; снижение ограничения памяти переводит больше работы во временные файлы, уменьшая использование RAM ценой дополнительного ввода‑вывода. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-), чтобы достичь оптимального баланса для вашей нагрузки и окружения.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, гигабайтных)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/) разработаны для таких сценариев: включение временных файлов и использование блокировки источника могут значительно снизить пиковое использование RAM и стабилизировать обработку очень больших наборов слайдов.

**Можно ли использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а при разрешении используются временные файлы, что делает использование памяти предсказуемым во время обработки.