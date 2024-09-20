---
title: Управление BLOB
type: docs
weight: 10
url: /androidjava/manage-blob/
description: Управление BLOB в презентации PowerPoint с использованием Java. Используйте BLOB для уменьшения потребления памяти в презентации PowerPoint с использованием Java. Добавьте большой файл через BLOB в презентацию PowerPoint с использованием Java. Экспортируйте большой файл через BLOB из презентации PowerPoint с использованием Java. Загрузите большую презентацию PowerPoint как BLOB с использованием Java.
---

## **О BLOB**

**BLOB** (**Binary Large Object**) - это обычно большой элемент (фото, презентация, документ или медиа), сохраненный в бинарном формате.

Aspose.Slides для Android через Java позволяет вам использовать BLOB для объектов таким образом, который уменьшает потребление памяти при работе с большими файлами.

{{% alert title="Информация" color="info" %}}

Чтобы обойти определенные ограничения при взаимодействии с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через ее поток приведет к копированию содержимого презентации и вызовет медленную загрузку. Поэтому, когда вы намерены загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не его поток.

{{% /alert %}}

## **Используйте BLOB для уменьшения потребления памяти**

### **Добавить большой файл через BLOB в презентацию**

[Aspose.Slides](/slides/androidjava/) для Java позволяет вам добавлять большие файлы (в данном случае, большой видеофайл) через процесс, связанный с BLOB, чтобы уменьшить потребление памяти.

Этот пример на Java показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Создает новую презентацию, в которую будет добавлено видео
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Давайте добавим видео в презентацию - мы выбрали поведение KeepLocked, потому что мы
        // не собираемся получать доступ к файлу "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Сохраняет презентацию. Пока большая презентация выводится, потребление памяти
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
Aspose.Slides для Android через Java позволяет вам экспортировать большие файлы (в данном случае, аудиофайл или видеофайл) через процесс, связанный с BLOB, из презентаций. Например, вам может понадобиться извлечь большой медиап файл из презентации, но вы не хотите, чтобы файл загружался в память вашего компьютера. Экспортируя файл через процесс BLOB, вы сможете сохранить низкое потребление памяти.

Этот код на Java демонстрирует описанную операцию:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Блокирует исходный файл и НЕ загружает его в память
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// создаем экземпляр презентации, блокируем файл "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Давайте сохраним каждое видео в файл. Чтобы предотвратить высокое потребление памяти, нам нужен буфер,
    // который будет использован для передачи данных из видеопотока презентации в поток для только что созданного видеофайла.
    byte[] buffer = new byte[8 * 1024];

    // Итерируем по видео
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Открывает видеопоток презентации. Пожалуйста, обратите внимание, что мы намеренно избегали доступа к свойствам
        // таким как video.BinaryData - потому что это свойство возвращает массив байт, содержащий полное видео, что затем
        // вызывает загрузку байтов в память. Мы используем video.GetStream, который вернет Stream - и НЕ
        // требует от нас загружать все видео в память.
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
    // При необходимости, вы можете применить те же шаги для аудиофайлов. 
} catch (IOException e) {
} finally {
    pres.dispose();
}

```

### **Добавить изображение как BLOB в презентацию**
С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) и класса [**ImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection) вы можете добавить большое изображение в виде потока, чтобы оно рассматривалось как BLOB.

Этот код на Java показывает, как добавить большое изображение через процесс BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// создает новую презентацию, в которую будет добавлено изображение.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Давайте добавим изображение в презентацию - мы выбираем поведение KeepLocked, потому что мы
		// НЕ намерены получать доступ к файлу "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Сохраняет презентацию. Пока большая презентация выводится, потребление памяти
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

## **Память и большие презентации**

Обычно для загрузки большой презентации компьютеры требуют много временной памяти. Все содержимое презентации загружается в память, и файл (из которого была загружена презентация) перестает использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл объемом 1,5 ГБ. Стандартный метод загрузки презентации описан в этом коде на Java:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Но этот метод потребляет около 1.6 ГБ временной памяти.

### **Загрузка большой презентации как BLOB**

С помощью процесса, связанного с BLOB, вы можете загрузить большую презентацию, используя при этом мало памяти. Этот код на Java описывает реализацию, в которой процесс BLOB используется для загрузки большого файла презентации (large.pptx):

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

### **Изменить папку для временных файлов**

Когда используется процесс BLOB, ваш компьютер создает временные файлы в папке по умолчанию для временных файлов. Если вы хотите, чтобы временные файлы хранились в другой папке, вы можете изменить настройки для хранения, используя `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Информация" color="info" %}}

Когда вы используете `TempFilesRootPath`, Aspose.Slides не создает автоматически папку для хранения временных файлов. Вы должны создать папку вручную.

{{% /alert %}}