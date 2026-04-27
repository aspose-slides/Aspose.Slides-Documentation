---
title: Управление видеокадрами в презентациях с помощью JavaScript
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/nodejs-java/video-frame/
keywords:
- добавить видео
- создать видео
- встроить видео
- извлечь видео
- получить видео
- видеокадр
- веб-источник
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument, используя Aspose.Slides для Node.js через Java. Быстрое руководство."
---
Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и увеличить уровень вовлечённости аудитории. 

PowerPoint позволяет добавить видео на слайд презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы добавить видео (видеофайлы) в презентацию, Aspose.Slides предоставляет класс [Video](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/video/), класс [VideoFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/) и другие соответствующие типы.

## **Создание вложенного видеокадра**

Если виде файл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр для встраивания видео в презентацию. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [Video](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/video/) и передайте путь к видеофайлу, чтобы встроить видео в презентацию.
1. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/) для создания кадра видео.
1. Сохраните изменённую презентацию. 

Этот JavaScript‑код показывает, как добавить локальное видео в презентацию:

```javascript
// Создаёт экземпляр класса Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Загружает видео
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Получает первый слайд и добавляет видеокадр
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Сохраняет презентацию на диск
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Альтернативно, вы можете добавить видео, передав его путь непосредственно в метод [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Создание видеокадра с видео из веб‑источника**

Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео YouTube в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию по веб‑ссылке. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [Video](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/video/) и передайте ссылку на видео.
1. Установите миниатюру для видеокадра. 
1. Сохраните презентацию. 

Этот JavaScript‑код показывает, как добавить видео из интернета на слайд PowerPoint‑презентации:

```javascript
// Создаёт объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Добавление субтитров к видеокадру**

Чтобы добавить субтитры к видеокадру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) .
1. Добавьте видео в презентацию.
1. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/) на слайд.
1. Используйте коллекцию [CaptionsCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/) для добавления трека субтитров WebVTT.
1. Сохраните изменённую презентацию.

Следующий код показывает, как добавить субтитры к видеокадру:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Добавляет новую дорожку субтитров из файла WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Класс [CaptionsCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/) также предоставляет метод [addFromStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/#addFromStream), позволяющий добавить субтитры из потока.

**Извлечение субтитров из видеокадра**

Чтобы извлечь субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.
1. Найдите целевой объект [VideoFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/) .
1. Пройдите по коллекции [CaptionsCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/) .
1. Сохраните каждый трек субтитров в файл с расширением `.vtt`.

Следующий код показывает, как извлечь субтитры из видеокадра:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // Сохраняет дорожку субтитров в файл WebVTT.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Каждый объект [Captions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captions/) раскрывает идентификатор субтитров, метку, двоичные данные и текст субтитров в виде UTF‑8 строки.

**Удаление субтитров из видеокадра**

Чтобы удалить субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.
1. Получите целевой объект [VideoFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/) .
1. Удалите треки субтитров из коллекции [CaptionsCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/) .
1. Сохраните изменённую презентацию.

Следующий код показывает, как удалить все субтитры из видеокадра:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // тип: com.aspose.slides.VideoFrame

    // Удаляет все субтитры из видеокадра.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если необходимо удалить только один трек субтитров, используйте методы [remove](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/#remove) или [removeAt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/#removeAt) вместо метода [clear](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/#clear).


## **Извлечение видео со слайда**

Помимо добавления видео в слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation) для загрузки презентации, содержащей видео.
2. Пройдите по всем объектам [Slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/) .
3. Пройдите по всем объектам [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/) в поисках [VideoFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/) .
4. Сохраните видео на диск.

Этот JavaScript‑код показывает, как извлечь видео со слайда презентации:

```javascript
// Создаёт объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // Получает расширение файла
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Какие параметры воспроизведения можно изменить для VideoFrame?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/setplaymode/) (автоматически или по щелчку) и [циклическим воспроизведением](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/) .

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При добавлении онлайн‑видео встраивается ссылка и миниатюра, поэтому рост размера меньше.

**Можно ли заменить видео в существующем VideoFrame, не меняя его позицию и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) внутри кадра, сохранив геометрию фигуры; такой сценарий часто используется для обновления медиа в существующей разметке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/video/getcontenttype/), который можно прочитать и использовать, например, при сохранении его на диск.