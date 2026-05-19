---
title: Управление BLOB в презентациях на JavaScript для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте данными BLOB в JavaScript с помощью Aspose.Slides для Node.js, упрощая операции с файлами PowerPoint и OpenDocument для эффективной обработки презентаций."
---
## **Обзор**

Aspose.Slides предоставляет обработку на основе BLOB для больших двоичных данных в презентациях, что помогает снизить потребление памяти при работе с крупными изображениями, аудио, видео и файлами презентаций.

В этой статье показано, как использовать обработку на основе BLOB для добавления больших медиафайлов в презентацию, экспорта больших медиафайлов из презентации и более эффективной загрузки крупных презентаций. Также объясняется, как использовать временные файлы во время обработки и как изменить папку, в которой они хранятся.

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентацию, документ или медиа), сохранённый в двоичном формате.

Aspose.Slides for Node.js via Java позволяет использовать BLOB‑объекты таким образом, чтобы снизить потребление памяти при работе с большими файлами.

{{% alert title="Info" color="info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через её поток приводит к копированию содержимого презентации и вызывает медленную загрузку. Поэтому, когда вы планируете загружать большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не её поток.
{{% /alert %}}

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/nodejs-java/) for Node.js via Java позволяет добавлять большие файлы (в данном случае большой видеофайл) через процесс, использующий BLOB, чтобы снизить потребление памяти.

Этот JavaScript показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Создаёт новую презентацию, в которую будет добавлено видео
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что мы
        // не планируем обращаться к файлу "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
        // остается низким на протяжении всего жизненного цикла объекта pres
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Экспорт большого файла через BLOB из презентации**

Aspose.Slides for Node.js via Java позволяет экспортировать большие файлы (в данном случае аудио‑ или видеофайл) через процесс, использующий BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиафайл из презентации, но вы не хотите загружать файл в память компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти.

Этот код на JavaScript демонстрирует описанную операцию:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Locks the source file and does NOT load it into memory
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
    // to transfer the data from the presentation's video stream to a stream for a newly created video file.
    var buffer = new byte[8 * 1024];
    // Iterates through the videos
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
        // like video.BinaryData - because this property returns a byte array containing a full video, which then
        // causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
        // require us to load the whole video into the memory.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
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
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Добавление изображения как BLOB в презентацию**

С помощью методов класса [**ImageCollection**](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ImageCollection) и [**ImageCollection**](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ImageCollection) вы можете добавить большое изображение как поток, чтобы оно рассматривалось как BLOB.

Этот JavaScript код показывает, как добавить большой изображение через процесс BLOB:

```javascript
var pathToLargeImage = "large_image.jpg";
// создает новую презентацию, в которую будет добавлено изображение.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Добавим изображение в презентацию - мы выбираем поведение KeepLocked, потому что мы
        // НЕ планируем обращаться к файлу "largeImage.png" file.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
        // остаётся низким на протяжении всего жизненного цикла объекта pres
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Память и большие презентации**

Обычно для загрузки большой презентации компьютерам требуется много временной памяти. Всё содержимое презентации загружается в память, а файл (из которого была загружена презентация) перестаёт использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в этом JavaScript‑коде:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Но этот метод потребляет около 1,6 ГБ временной памяти.

### **Загрузка большой презентации как BLOB**

Через процесс, использующий BLOB, вы можете загрузить большую презентацию, потребляя минимум памяти. Этот JavaScript‑код описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Изменение папки для временных файлов**

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите хранить временные файлы в другой папке, можно изменить настройки хранилища, используя `setTempFilesRootPath`:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
При использовании `setTempFilesRootPath` Aspose.Slides не создаёт папку для хранения временных файлов автоматически. Папку нужно создать вручную.
{{% /alert %}}

### **Освобождение объектов презентации для освобождения памяти**

При обработке больших презентаций убедитесь, что экземпляр [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) корректно освобождён, чтобы освободить занявшую её память. Вызовите `dispose()` после завершения работы с презентацией, чтобы освободить неуправляемые ресурсы.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и контролируются параметрами BLOB?**

Большие двоичные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. При загрузке или сохранении всей презентации также применяется обработка BLOB. Эти объекты управляются политиками BLOB, позволяющими контролировать использование памяти и при необходимости выгружать данные во временные файлы.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/blobmanagementoptions/). Там задаётся ограничение памяти для BLOB, разрешение или запрет временных файлов, корневой путь для временных файлов и поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как сбалансировать скорость и память?**

Да. Хранение BLOB в памяти повышает скорость, но увеличивает потребление ОЗУ; снижение лимита памяти переводит часть работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) для нахождения оптимального баланса под вашу нагрузку и окружение.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, гигабайтных)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/blobmanagementoptions/) разработаны для таких сценариев: включение временных файлов и использование блокировки источника могут существенно снизить пиковое потребление ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Могу ли я использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а при разрешённом использовании временных файлов память будет предсказуемо расходоваться во время обработки.