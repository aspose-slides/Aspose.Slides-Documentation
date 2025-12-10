---
title: Управление BLOB презентаций в Java для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/java/manage-blob/
keywords:
- большой объект
- большой элемент
- большой файл
- добавить BLOB
- экспортировать BLOB
- добавить изображение как BLOB
- сократить память
- потребление памяти
- большая презентация
- временный файл
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для Java, чтобы оптимизировать операции с файлами PowerPoint и OpenDocument для эффективной работы с презентациями."
---

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентацию, документ или медиа), сохранённый в бинарных форматах.  

Aspose.Slides for Java позволяет использовать BLOB‑ы для объектов таким образом, чтобы уменьшить потребление памяти при работе с большими файлами.  

{{% alert title="Info" color="info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока.  
Загрузка большой презентации через её поток приводит к копированию содержимого презентации и замедлению загрузки.  
Поэтому, когда вы планируете загружать большую презентацию, настоятельно рекомендуется использовать путь к файлу презентации, а не её поток.  
{{% /alert %}}

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/java/) for Java позволяет добавлять большие файлы (в данном случае, большой видеофайл) с помощью процесса, включающего BLOB‑ы, чтобы снизить потребление памяти.  

Этот пример Java показывает, как добавить большой видеофайл через процесс BLOB в презентацию:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

    // Создает новую презентацию, в которую будет добавлено видео
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что мы
        // не планируем обращаться к файлу "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
        // остается низким на протяжении всего жизненного цикла объекта pres 
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

Aspose.Slides for Java позволяет экспортировать большие файлы (в данном случае, аудио или видеофайл) с помощью процесса, включающего BLOB‑ы, из презентаций. Например, вам может понадобиться извлечь большой медиа‑файл из презентации, но не загружать его в память компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти.  

Этот код на Java демонстрирует описанную операцию:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Блокирует исходный файл и НЕ загружает его в память
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// создаёт экземпляр Presentation, блокирует файл "hugePresentationWithAudiosAndVideos.pptx" file.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Сохраним каждое видео в файл. Чтобы избежать высокого использования памяти, нам нужен буфер, который будет использован
    // для переноса данных из видеопотока презентации в поток нового создаваемого видеофайла.
    byte[] buffer = new byte[8 * 1024];

    // Перебирает все видеоролики
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
    // При необходимости вы можете применить те же шаги для аудиофайлов. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **Добавление изображения как BLOB в презентацию**

С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) и класса [**ImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection) можно добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.  

Этот код на Java показывает, как добавить большое изображение через процесс BLOB:
```java
String pathToLargeImage = "large_image.jpg";

// создает новую презентацию, в которую будет добавлено изображение.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Добавим изображение в презентацию — мы выбираем поведение KeepLocked, потому что мы
		// НЕ планируем обращаться к файлу "largeImage.png" file.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
		// остается низким на протяжении жизненного цикла объекта pres.
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

Обычно для загрузки большой презентации компьютерам требуется значительный объём временной памяти. Всё содержимое презентации загружается в память, и файл, из которого была загружена презентация, перестаёт использоваться.  

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в этом коде на Java:
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


Однако этот метод потребляет около 1,6 ГБ временной памяти.  

### **Загрузка большой презентации как BLOB**

Через процесс, включающий BLOB, вы можете загрузить большую презентацию, используя мало памяти. Этот код на Java описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):
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

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите хранить временные файлы в другой папке, можете изменить настройки хранилища, используя `TempFilesRootPath`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
При использовании `TempFilesRootPath` Aspose.Slides не создаёт автоматически папку для хранения временных файлов. Вам необходимо создать папку вручную.  
{{% /alert %}}

## **FAQ**

**Какие данные в презентации Aspose.Slides обрабатываются как BLOB и контролируются параметрами BLOB?**  

Большие бинарные объекты, такие как изображения, аудио и видео, обрабатываются как BLOB. Сам файл презентации также участвует в обработке BLOB при загрузке или сохранении. Эти объекты регулируются политиками BLOB, позволяющими управлять использованием памяти и записью во временные файлы при необходимости.  

**Где я могу настроить правила обработки BLOB при загрузке презентации?**  

Используйте [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) с [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/). Здесь задаётся лимит памяти для BLOB, разрешается или запрещается создание временных файлов, выбирается корневая папка для временных файлов и задаётся поведение блокировки источника.  

**Влияют ли настройки BLOB на производительность и как сбалансировать скорость и память?**  

Да. Хранение BLOB в памяти максимизирует скорость, но увеличивает потребление ОЗУ; снижение лимита памяти переносит большую часть работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) для достижения оптимального баланса под вашу нагрузку и окружение.  

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, гигабайтных)?**  

Да. [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) разработаны для таких сценариев: включение временных файлов и использование блокировки источника могут значительно сократить пиковое использование ОЗУ и стабилизировать обработку очень больших наборов слайдов.  

**Могу ли я использовать политики BLOB при загрузке из потоков вместо файлов на диске?**  

Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если они разрешены, что позволяет предсказуемо контролировать потребление памяти во время обработки.