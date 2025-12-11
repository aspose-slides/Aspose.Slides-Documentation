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
description: "Управляйте BLOB‑данными в Aspose.Slides для Android через Java, чтобы упростить операции с файлами PowerPoint и OpenDocument и обеспечить эффективную работу с презентациями."
---

## **Об BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентацию, документ или медиа), сохраняемый в бинарных форматах. 

Aspose.Slides for Android via Java позволяет использовать BLOBs для объектов таким образом, чтобы уменьшить потребление памяти при работе с большими файлами.

{{% alert title="Info" color="info" %}}
Чтобы обойти определённые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через её поток приведёт к копированию содержимого презентации и замедлению загрузки. Поэтому, когда вы планируете загружать большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не её поток.
{{% /alert %}}

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/androidjava/) for Java позволяет добавлять большие файлы (в данном случае большой видеофайл) через процесс, использующий BLOBs, чтобы снизить потребление памяти.

Этот пример на Java показывает, как добавить большой видеофайл через процесс BLOB в презентацию:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Создает новую презентацию, к которой будет добавлено видео
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что мы
        // не планируем обращаться к файлу "veryLargeVideo.avi" file.
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

Aspose.Slides for Android via Java позволяет экспортировать большие файлы (в данном случае аудио‑ или видеофайл) через процесс, использующий BLOBs, из презентаций. Например, вам может потребоваться извлечь большой медиа‑файл из презентации, но не хочется загружать его в память компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти.

Этот код на Java демонстрирует описанную операцию:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Блокирует исходный файл и НЕ загружает его в память
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// создаёт экземпляр Presentation, блокируя файл "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Сохраним каждое видео в файл. Чтобы предотвратить высокое потребление памяти, нам нужен буфер, который будет использоваться
    // для передачи данных из видеопотока презентации в поток нового видеофайла.
    byte[] buffer = new byte[8 * 1024];

    // Итерируется по видеоматериалам
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегали доступа к свойствам
        // таким как video.BinaryData — потому что это свойство возвращает массив байтов, содержащий полное видео, что затем
        // заставляет загружать байты в память. Мы используем video.GetStream, который возвращает Stream и НЕ
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

С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) и класса [**ImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

Этот код на Java показывает, как добавить большое изображение через процесс BLOB:
```java
String pathToLargeImage = "large_image.jpg";

// создает новую презентацию, к которой будет добавлено изображение.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Добавим изображение в презентацию — мы выбираем поведение KeepLocked, потому что
		//  НЕ планируем обращаться к файлу "largeImage.png" file.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
		//  остается низким на протяжении жизненного цикла объекта pres
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

Рассмотрим большую PowerPoint‑презентацию (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в этом коде на Java:
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

Через процесс, использующий BLOB, можно загрузить большую презентацию, используя минимум памяти. Этот код на Java описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):
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

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите хранить временные файлы в другой папке, вы можете изменить настройки хранилища, используя `TempFilesRootPath`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
При использовании `TempFilesRootPath` Aspose.Slides не создаёт папку для хранения временных файлов автоматически. Вам необходимо создать папку вручную. 
{{% /alert %}}

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и управляются параметрами BLOB?**  
Большие бинарные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Также вся презентация участвует в обработке BLOB при загрузке или сохранении. Эти объекты контролируются политиками BLOB, позволяющими управлять использованием памяти и переключаться на временные файлы при необходимости.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**  
Используйте [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/). Здесь задаётся лимит памяти для BLOB, разрешение или запрет временных файлов, путь к корневой папке временных файлов и поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как сбалансировать скорость и память?**  
Да. Хранение BLOB в памяти обеспечивает максимальную скорость, но увеличивает потребление ОЗУ; снижение лимита памяти переключает большую часть работы на временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) для нахождения оптимального баланса под ваши нагрузки и окружение.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, гигабайтных)?**  
Да. [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника могут значительно снизить пик потребления RAM и стабилизировать обработку очень больших наборов слайдов.

**Можно ли использовать политики BLOB при загрузке из потоков, а не из файлов на диске?**  
Да. Те же правила применяются к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а при разрешении временных файлов они будут использоваться, обеспечивая предсказуемое использование памяти во время обработки.