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
- уменьшить потребление памяти
- потребление памяти
- большая презентация
- временный файл
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для Java, чтобы упростить операции с файлами PowerPoint и OpenDocument и обеспечить эффективную обработку презентаций."
---

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой крупный элемент (фотография, презентация, документ или медиа), сохраняемый в бинарных форматах. 

Aspose.Slides for Java позволяет использовать BLOB для объектов таким образом, что снижается потребление памяти при работе с большими файлами. 

{{% alert title="Info" color="info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через поток приводит к копированию содержимого презентации и замедлению загрузки. Поэтому, когда вы планируете загружать большую презентацию, настоятельно рекомендуется использовать путь к файлу презентации, а не её поток.
{{% /alert %}}

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/java/) for Java позволяет добавлять большие файлы (в данном случае большой видеофайл) через процесс, использующий BLOB, чтобы снизить потребление памяти. 

Этот пример на Java показывает, как добавить большой видеофайл через процесс BLOB в презентацию:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Создает новую презентацию, в которую будет добавлено видео
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Добавим видео в презентацию - мы выбрали поведение KeepLocked, потому что мы
        // не намерены обращаться к файлу "veryLargeVideo.avi".
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
Aspose.Slides for Java позволяет экспортировать большие файлы (в данном случае аудио‑ или видеофайл) через процесс, использующий BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиафайл из презентации, но не загружать его в память компьютера. При экспорте файла через процесс BLOB потребление памяти остаётся низким. 

Этот код на Java демонстрирует описанную операцию:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Блокирует исходный файл и НЕ загружает его в память
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// создаёт экземпляр Presentation и блокирует файл "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Сохраним каждый видеофайл. Чтобы предотвратить высокое потребление памяти, нам нужен буфер, который будет использоваться
    // для передачи данных из видеопотока презентации в поток нового видеофайла.
    byte[] buffer = new byte[8 * 1024];

    // Перебирает видеофайлы
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегаем доступа к свойствам
        // таким как video.BinaryData, потому что это свойство возвращает массив байтов, содержащий полное видео, что затем
        // приводит к загрузке байтов в память. Мы используем video.GetStream, который возвращает Stream и НЕ
        //  требует загружать всё видео в память.
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
    // При необходимости можно применить те же шаги к аудиофайлам. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **Добавление изображения как BLOB в презентацию**
С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) и класса [**ImageCollection** ](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection) вы можете добавить большое изображение в виде потока, чтобы оно обрабатывалось как BLOB. 

Этот код на Java показывает, как добавить большое изображение через процесс BLOB:
```java
String pathToLargeImage = "large_image.jpg";

// создаёт новую презентацию, в которую будет добавлено изображение.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Добавим изображение в презентацию – мы выбираем поведение KeepLocked, потому что мы
		// НЕ планируем обращаться к файлу "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
		// остаётся низким в течение жизненного цикла объекта pres
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

Обычно для загрузки большой презентации компьютерам требуется много временной памяти. Всё содержимое презентации загружается в память, и файл (из которого была загружена презентация) перестаёт использоваться. 

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в этом Java‑коде:
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

С помощью процесса, использующего BLOB, можно загрузить большую презентацию, потребляя минимум памяти. Этот Java‑код описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):
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

При использовании процесса BLOB ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите хранить временные файлы в другой папке, можно изменить настройки хранилища, используя `TempFilesRootPath`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
При использовании `TempFilesRootPath` Aspose.Slides не создаёт папку для хранения временных файлов автоматически. Папку необходимо создать вручную. 
{{% /alert %}}

## **FAQ**

**Какие данные в презентации Aspose.Slides обрабатываются как BLOB и управляются параметрами BLOB?**

Крупные бинарные объекты, такие как изображения, аудио и видео, обрабатываются как BLOB. Сам файл презентации также включает обработку BLOB при загрузке или сохранении. Эти объекты управляются политиками BLOB, которые позволяют контролировать использование памяти и запись во временные файлы при необходимости.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) совместно с [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/). Здесь вы задаёте ограничение памяти для BLOB, разрешаете или запрещаете временные файлы, выбираете корневой путь для временных файлов и определяете поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как найти баланс между скоростью и памятью?**

Да. Хранение BLOB в памяти максимизирует скорость, но увеличивает потребление ОЗУ; снижение ограничения памяти переводит часть работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-), чтобы подобрать оптимальный баланс для вашей нагрузки и окружения.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, в гигабайтах)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника могут значительно снизить пиковое потребление ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Могу ли я использовать политики BLOB при загрузке из потоков, а не из файлов на диске?**

Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если это разрешено, обеспечивая предсказуемое использование памяти во время обработки.