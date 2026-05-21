---
title: Управление BLOB презентаций в Java для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/java/manage-blob/
keywords:
- крупный объект
- крупный элемент
- крупный файл
- добавить BLOB
- экспортировать BLOB
- добавить изображение как BLOB
- снизить память
- потребление памяти
- крупная презентация
- временный файл
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для Java, оптимизируя операции с файлами PowerPoint и OpenDocument для эффективной обработки презентаций."
---
## **Обзор**

Aspose.Slides предоставляет обработку BLOB‑основу для больших двоичных данных в презентациях, помогая снизить потребление памяти при работе с большими изображениями, аудио, видео и файлами презентаций.

В этой статье показано, как использовать обработку на основе BLOB для добавления больших медиафайлов в презентацию, экспорта больших медиа из презентации и более эффективной загрузки больших презентаций. Также объясняется, как временные файлы могут использоваться во время обработки и как изменить папку, в которой они хранятся.

## **О BLOB**

**BLOB** (**Binary Large Object**, двоичный крупный объект) обычно представляет собой крупный элемент (фото, презентацию, документ или медиа), сохраняемый в бинарных форматах.  

Aspose.Slides для Java позволяет использовать BLOB для объектов таким образом, чтобы уменьшить расход памяти при работе с большими файлами.

{{% alert title="Info" color="info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через её поток приводит к копированию содержимого презентации и вызывает медленную загрузку. Поэтому, когда вы планируете загрузить большую презентацию, настоятельно рекомендуем использовать путь к файлу презентации, а не её поток.
{{% /alert %}}

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/java/) для Java позволяет добавлять большие файлы (в данном случае большой видеофайл) через процесс, включающий BLOB, чтобы снизить потребление памяти.

Этот пример Java показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Создает новую презентацию, к которой будет добавлено видео
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что не
        // собираемся обращаться к файлу "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
        // остаётся низким в течение жизненного цикла объекта pres
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

Aspose.Slides для Java позволяет экспортировать большие файлы (в данном случае аудио‑ или видеофайл) через процесс, включающий BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиафайл из презентации, но вы не хотите, чтобы файл загружался в память компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти.

Этот код на Java демонстрирует описанную операцию:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Блокирует исходный файл и НЕ загружает его в память
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// создаёт экземпляр Presentation и блокирует файл "hugePresentationWithAudiosAndVideos.pptx" файл.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Сохраним каждый видеофайл. Чтобы предотвратить высокое потребление памяти, нам нужен буфер, который будет использован
    // для передачи данных из видеопотока презентации в поток только что созданного видеофайла.
    byte[] buffer = new byte[8 * 1024];

    // Перебирает видеофайлы
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегали доступа к свойствам
        // таким как video.BinaryData - потому что это свойство возвращает массив байтов, содержащий полное видео, что
        // приводит к загрузке байтов в память. Мы используем video.GetStream, который возвращает Stream - и НЕ
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
    // При необходимости можно выполнить те же действия для аудиофайлов. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Добавление изображения как BLOB в презентацию**

С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IImageCollection) и класса [**ImageCollection** ](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ImageCollection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.  

Этот код Java показывает, как добавить большое изображение через процесс BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// создает новую презентацию, к которой будет добавлено изображение.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Добавим изображение в презентацию — мы выбираем поведение KeepLocked, потому что
		// НЕ собираемся обращаться к файлу "largeImage.png" файл.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
		// остается низким в течение жизненного цикла объекта pres
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

Обычно для загрузки большой презентации компьютерам требуется большое количество временной памяти. Весь контент презентации загружается в память, и файл (из которого была загружена презентация) перестаёт использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в этом коде Java:

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

Через процесс, включающий BLOB, вы можете загрузить большую презентацию, используя минимум памяти. Этот код Java описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):

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

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите хранить временные файлы в другой папке, можно изменить настройки хранилища, используя `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
При использовании `TempFilesRootPath` Aspose.Slides не создаёт папку для хранения временных файлов автоматически. Вы должны создать папку вручную.
{{% /alert %}}

### **Освобождение объектов презентации для высвобождения памяти**

При обработке крупных презентаций убедитесь, что экземпляр [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) правильно освобождается, чтобы память, которую он занимал, была высвобождена. Вызовите `dispose()` после завершения работы с презентацией, чтобы освободить неуправляемые ресурсы.

```java
Presentation presentation = new Presentation("large.pptx");

// ...обработать презентацию...
presentation.save("large.pdf", SaveFormat.Pdf);

// Явно освобождаем ресурсы.
presentation.dispose();
```

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и управляются параметрами BLOB?**  
Крупные двоичные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Сам файл презентации также участвует в обработке BLOB при загрузке или сохранении. Эти объекты управляются политиками BLOB, позволяющими контролировать использование памяти и переключаться на временные файлы при необходимости.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**  
Используйте [LoadOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/blobmanagementoptions/). Здесь задаётся ограничение объёма BLOB в памяти, разрешение или запрет временных файлов, корневой путь для временных файлов и поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как сбалансировать скорость и память?**  
Да. Хранение BLOB в памяти максимизирует скорость, но увеличивает расход ОЗУ; снижение лимита памяти переводит большую часть работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ru/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-), чтобы найти оптимальный баланс для вашей нагрузки и среды.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, гигабайты)?**  
Да. [BlobManagementOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/blobmanagementoptions/) созданы для таких сценариев: включение временных файлов и использование блокировки источника могут значительно снизить пиковое потребление ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Могу ли я использовать политики BLOB при загрузке из потоков вместо файлов на диске?**  
Да. Те же правила применяются к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, когда это разрешено, обеспечивая предсказуемое использование памяти во время обработки.