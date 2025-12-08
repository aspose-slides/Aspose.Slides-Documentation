---
title: Видеокадр
type: docs
weight: 10
url: /ru/nodejs-java/video-frame/
keywords: "Добавить видео, создать видеокадр, извлечь видео, презентация PowerPoint, Java, Aspose.Slides для Node.js через Java"
description: "Добавить видеокадр в презентацию PowerPoint на JavaScript"
---

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости вашей аудитории. 

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы добавить видео (объекты видео) в презентацию, Aspose.Slides предоставляет класс [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/), класс [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) и другие соответствующие типы.

## **Создание встроенного видеокадра**

Если файл видео, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в вашу презентацию. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) и передайте путь к файлу видео, чтобы встроить его в презентацию.
1. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) для создания кадра видео.
1. Сохраните изменённую презентацию. 

Этот код JavaScript показывает, как добавить локально хранимое видео в презентацию:
```javascript
// Создает экземпляр класса Presentation
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


В качестве альтернативы вы можете добавить видео, передав путь к его файлу напрямую в метод [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-):
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) и передайте ссылку на видео.
1. Установите миниатюру для видеокадра. 
1. Сохраните презентацию. 

Этот код JavaScript показывает, как добавить видео из интернета на слайд в презентации PowerPoint:
```javascript
// Создает объект Presentation, представляющий файл презентации
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


## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) для загрузки презентации, содержащей видео.
2. Пройдитесь по всем объектам [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/).
3. Пройдитесь по всем объектам [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) в поисках [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).
4. Сохраните видео на диск.

Этот код JavaScript показывает, как извлечь видео со слайда презентации:
```javascript
// Создает объект Presentation, представляющий файл презентации
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

**Какие параметры воспроизведения видео можно изменить у VideoFrame?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (автоматически или по щелчку) и [повторением](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео двоичные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При добавлении онлайн‑видео встраивается ссылка и миниатюра, поэтому увеличение размера меньше.

**Могу ли я заменить видео в существующем VideoFrame, не меняя его положение и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) внутри кадра, сохранив геометрию формы; это типичный сценарий обновления медиа в существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/), который можно прочитать и использовать, например при сохранении на диск.