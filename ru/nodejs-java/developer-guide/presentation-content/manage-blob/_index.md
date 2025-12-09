---
title: Управление Blob
type: docs
weight: 10
url: /ru/nodejs-java/manage-blob/
description: Управляйте Blob в презентации PowerPoint с помощью JavaScript. Используйте Blob для снижения потребления памяти в презентации PowerPoint с помощью JavaScript. Добавьте большой файл через Blob в презентацию PowerPoint с помощью JavaScript. Экспортируйте большой файл через Blob из презентации PowerPoint с помощью JavaScript. Загрузите большую презентацию PowerPoint как Blob с помощью JavaScript.
---

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой элемент (фото, презентация, документ или медиа), сохранённый в бинарных форматах. 

Aspose.Slides for Node.js via Java позволяет использовать BLOB‑объекты таким образом, чтобы уменьшить потребление памяти при работе с крупными файлами.

{{% alert title="Info" color="info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через её поток приводит к копированию содержимого презентации и замедляет загрузку. Поэтому, когда вы планируете загружать большую презентацию, настоятельно рекомендуется использовать путь к файлу презентации, а не её поток.
{{% /alert %}}

## **Используйте BLOB для снижения потребления памяти**

### **Добавить большой файл через BLOB в презентацию**

[Aspose.Slides](/slides/ru/nodejs-java/) for Node.js via Java позволяет добавлять крупные файлы (в данном случае большой видеофайл) через процесс, использующий BLOB‑объекты, чтобы снизить потребление памяти.

Этот JavaScript показывает, как добавить большой видеофайл через процесс BLOB в презентацию:
```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Создает новую презентацию, к которой будет добавлено видео
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что
        // не планируем обращаться к файлу "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
        // остаётся низким на протяжении жизненного цикла объекта pres.
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


### **Экспортировать большой файл через BLOB из презентации**

Aspose.Slides for Node.js via Java позволяет экспортировать крупные файлы (в данном случае аудио‑ или видеофайл) через процесс, использующий BLOB‑объекты, из презентаций. Например, вам может потребоваться извлечь большой медиа‑файл из презентации, но не загружать его в память компьютера. При экспорте файла через процесс BLOB вы сохраняете низкое потребление памяти.

Этот код на JavaScript демонстрирует описанную операцию:
```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Блокирует исходный файл и НЕ загружает его в память
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// создаёт экземпляр Presentation и блокирует файл "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Сохраним каждое видео в файл. Чтобы предотвратить высокое потребление памяти, нам нужен буфер, который будет использован
    // для передачи данных из видеопотока презентации в поток нового видеофайла.
    var buffer = new byte[8 * 1024];
    // Проходит по всем видео
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегаем доступа к свойствам
        // таким как video.BinaryData — потому что это свойство возвращает массив байтов с полным видео, что затем
        // приводит к загрузке байтов в память. Мы используем video.GetStream, который возвращает Stream и НЕ
        // требует загрузки всего видео в память.
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
        // Потребление памяти останется низким независимо от размера видео или презентации.
    }
    // При необходимости можно выполнить те же шаги для аудиофайлов.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```


### **Добавить изображение как BLOB в презентацию**

С помощью методов класса [**ImageCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) и [**ImageCollection** ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

Этот JavaScript‑код показывает, как добавить большое изображение через процесс BLOB:
```javascript
var pathToLargeImage = "large_image.jpg";
// создает новую презентацию, к которой будет добавлено изображение.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Добавим изображение в презентацию — мы выбираем поведение KeepLocked, потому что
        // НЕ планируем обращаться к файлу "largeImage.png" файл.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
        // остаётся низким в течение жизненного цикла объекта pres.
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


## **Память и крупные презентации**

Обычно для загрузки большой презентации компьютерам требуется большое количество временной памяти. Всё содержимое презентации загружается в память, и файл (из которого была загружена презентация) перестаёт использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл объёмом 1,5 ГБ. Стандартный метод загрузки презентации описан в этом JavaScript‑коде:
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


Однако этот метод потребляет примерно 1,6 ГБ временной памяти.

### **Загрузить большую презентацию как BLOB**

Через процесс, использующий BLOB, вы можете загрузить большую презентацию, используя мало памяти. Этот JavaScript‑код описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):
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


### **Изменить папку для временных файлов**

При использовании процесса BLOB ваш компьютер создает временные файлы в папке по умолчанию для временных файлов. Если вы хотите, чтобы временные файлы хранились в другой папке, вы можете изменить настройки хранилища, используя `setTempFilesRootPath`:
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
При использовании `setTempFilesRootPath` Aspose.Slides не создаёт папку для хранения временных файлов автоматически. Папку необходимо создать вручную.
{{% /alert %}}

## **Часто задаваемые вопросы**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и управляются параметрами BLOB?**

Крупные бинарные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Сам файл презентации также обрабатывается как BLOB при загрузке или сохранении. Эти объекты управляются политиками BLOB, которые позволяют контролировать использование памяти и при необходимости выгружать данные во временные файлы.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/). Здесь задаются ограничения памяти для BLOB, разрешение или запрет временных файлов, путь к корневой папке для временных файлов и поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как сбалансировать скорость и память?**

Да. Хранение BLOB в памяти обеспечивает максимальную скорость, но увеличивает потребление ОЗУ; снижение лимита памяти переносит часть работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) для достижения оптимального баланса под вашу нагрузку и окружение.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, гигабайтных)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/) разработаны для таких сценариев: включение временных файлов и использование блокировки источника может значительно снизить пик потребления ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Можно ли использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются при разрешении, что позволяет предсказуемо контролировать использование памяти во время обработки.