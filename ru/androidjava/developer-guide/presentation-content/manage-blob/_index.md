---
title: Управление BLOB‑объектами презентаций на Android для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для Android через Java, упрощая операции с файлами PowerPoint и OpenDocument для эффективной работы с презентациями."
---
## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой крупный элемент (фото, презентацию, документ или медиа), сохранённый в двоичном формате. 

Aspose.Slides for Android via Java позволяет использовать BLOB‑ы для объектов таким способом, который уменьшает потребление памяти при работе с большими файлами.

{{% alert title="Info" color="info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через её поток приводит к копированию содержимого презентации и замедленной загрузке. Поэтому, когда вы планируете загрузить большую презентацию, настоятельно рекомендуется использовать путь к файлу презентации, а не её поток.
{{% /alert %}}

## **Используйте BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/androidjava/) для Java позволяет добавлять большие файлы (в данном случае большой видеофайл) посредством процесса, использующего BLOB‑ы, чтобы снизить потребление памяти.

Этот пример на Java показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Создает новую презентацию, к которой будет добавлено видео
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что мы
        // не планируем обращаться к файлу "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
        // остаётся низким на протяжении жизненного цикла объекта pres 
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
Aspose.Slides for Android via Java позволяет экспортировать большие файлы (например, аудио‑ или видеофайл) из презентаций с помощью процесса, использующего BLOB‑ы. Например, вам может потребоваться извлечь большой медиофайл из презентации, но вы не хотите загружать его в память компьютера. При экспорте файла через процесс BLOB потребление памяти остаётся низким.

Этот код на Java демонстрирует описанную операцию:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Блокирует исходный файл и НЕ загружает его в память
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// создаёт экземпляр Presentation, блокирует файл "hugePresentationWithAudiosAndVideos.pptx" file.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Сохраним каждое видео в файл. Чтобы предотвратить высокое потребление памяти, нам нужен буфер, который будет использоваться
    // для передачи данных из видеопотока презентации в поток только что созданного видеофайла.
    byte[] buffer = new byte[8 * 1024];

    // Перебирает видеоматериалы
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегаем доступа к свойствам
        // таким как video.BinaryData — потому что это свойство возвращает массив байтов, содержащий полное видео, что затем
        // приводит к загрузке байтов в память. Мы используем video.GetStream, который возвращает Stream и НЕ
        //  требует загрузки всего видео в память.
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
        // Потребление памяти останется низким независимо от размера видео или презентации.
    }
    // При необходимости вы можете применить те же шаги к аудиофайлам. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Добавление изображения как BLOB в презентацию**
С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IImageCollection) и класса [**ImageCollection**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ImageCollection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

Этот код на Java показывает, как добавить большое изображение через процесс BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// создает новую презентацию, к которой будет добавлено изображение.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Добавим изображение в презентацию — мы выбираем поведение KeepLocked, потому что
		// НЕ планируем обращаться к файлу "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
		// остается низким на протяжении жизненного цикла объекта pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Память и крупные презентации**

Обычно для загрузки большой презентации компьютерам требуется значительный объём временной памяти. Всё содержимое презентации загружается в память, а файл, из которого была загружена презентация, перестаёт использоваться. 

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный способ загрузки презентации описан в этом Java‑коде:

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

С помощью процесса, использующего BLOB, вы можете загрузить большую презентацию, используя минимум памяти. Этот Java‑код описывает реализацию, где процесс BLOB применяется для загрузки большого файла презентации (large.pptx):

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

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите сохранять временные файлы в другой папке, можно изменить настройки хранилища, используя `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
При использовании `TempFilesRootPath` Aspose.Slides не создаёт папку для временных файлов автоматически. Вам нужно создать её вручную.
{{% /alert %}}

### **Освобождение памяти путем удаления объектов презентации**

При работе с большими презентациями убедитесь, что экземпляр [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) правильно освобожден, чтобы освободить занявшую её память. Вызовите `dispose()` после завершения работы с презентацией, чтобы освободить неуправляемые ресурсы.

```java
Presentation presentation = new Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и управляются параметрами BLOB?**  
Крупные двоичные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. При загрузке или сохранении всей презентации также задействуется обработка BLOB. Эти объекты управляются политиками BLOB, позволяющими контролировать использование памяти и переключаться на временные файлы при необходимости.

**Где можно настроить правила обработки BLOB при загрузке презентации?**  
Используйте [LoadOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/blobmanagementoptions/). Здесь задаётся лимит памяти для BLOB, разрешение или запрет временных файлов, корневой путь для временных файлов и поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как сбалансировать скорость и память?**  
Да. Хранение BLOB в памяти повышает скорость, но увеличивает потребление RAM; снижение лимита памяти переносит часть работы во временные файлы, уменьшая RAM, но увеличивая ввод‑вывод. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-), чтобы найти оптимальный баланс для вашей нагрузки и окружения.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, гигабайтных)?**  
Да. [BlobManagementOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника могут значительно снизить пиковое потребление RAM и стабилизировать обработку очень больших наборов слайдов.

**Можно ли использовать политики BLOB при загрузке из потоков вместо файлов на диске?**  
Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы будут использоваться, если это разрешено, обеспечивая предсказуемое потребление памяти во время обработки.