---
title: Управление аудио в презентациях с помощью JavaScript
linktitle: Аудио кадр
type: docs
weight: 10
url: /ru/nodejs-java/audio-frame/
keywords:
- аудио
- аудио кадр
- миниатюра
- добавить аудио
- свойства аудио
- параметры аудио
- извлечь аудио
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте и управляйте аудио-кадрами в Aspose.Slides for Node.js - примеры встраивания, обрезки, зацикливания и настройки воспроизведения в презентациях PPT, PPTX и ODP."
---
## **Создать аудио кадры**

Aspose.Slides for Node.js via Java позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды как аудио кадры.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который необходимо встроить в слайд.
4. Добавьте встроенный аудио кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/AudioPlayModePreset) и `Volume`, доступные через объект [AudioFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/AudioFrame).
6. Сохраните изменённую презентацию.

Этот JavaScript‑код показывает, как добавить встроенный аудио кадр на слайд:

```javascript
// Создаёт экземпляр класса Presentation, представляющего файл презентации
const pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    const sld = pres.getSlides().get_Item(0);
    // Загружает wav‑файл звука в поток
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Добавляет аудио‑кадр
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Устанавливает режим воспроизведения и громкость аудио
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Записывает файл PowerPoint на диск
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Изменить миниатюру аудио кадра**

При добавлении аудиофайла в презентацию он отображается как кадр со стандартным изображением по умолчанию (см. изображение ниже). Вы можете изменить превью‑изображение аудио кадра (установить своё изображение).

Этот JavaScript‑код показывает, как изменить миниатюру или превью‑изображение аудио кадра:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Добавляет аудио‑кадр на слайд с указанными позициями и размерами.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Добавляет изображение в ресурсы презентации.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Устанавливает изображение для аудио‑кадра.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Сохраняет изменённую презентацию на диск
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Изменить параметры воспроизведения аудио**

Aspose.Slides for Node.js via Java позволяет изменять параметры, управляющие воспроизведением аудио или его свойствами. Например, можно отрегулировать громкость, включить циклическое воспроизведение или скрыть значок аудио.

Панель **Audio Options** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Параметры **Audio Options** в PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/):

- **Start** — выпадающий список соответствует методу [AudioFrame.setPlayMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** — соответствует методу [AudioFrame.setVolume](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** — соответствует методу [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** — соответствует методу [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** — соответствует методу [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** — соответствует методу [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#setRewindAudio)

Параметры **Editing** в PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/):

- **Fade In** — соответствует методу [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#setFadeInDuration)
- **Fade Out** — соответствует методу [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration)
- **Trim Audio Start Time** — соответствует методу [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#setTrimFromStart)
- **Trim Audio End Time** — значение равно длительности аудио минус значение, заданное методом [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

Ползунок **Volume** на панели управления аудио в PowerPoint соответствует методу [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Он позволяет менять громкость аудио в процентах.

Как изменить параметры воспроизведения аудио:

1. [Создайте](#create-audio-frame) или получите аудио кадр.
2. Установите новые значения свойств аудио кадра, которые нужно изменить.
3. Сохраните изменённый файл PowerPoint.

Этот JavaScript‑код демонстрирует операцию, в которой изменяются параметры аудио:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Получает форму AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Устанавливает режим воспроизведения на воспроизведение по щелчку
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Устанавливает громкость на низкую
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Устанавливает воспроизведение аудио на всех слайдах
    audioFrame.setPlayAcrossSlides(true);
    // Отключает зацикливание аудио
    audioFrame.setPlayLoopMode(false);
    // Скрывает AudioFrame во время показа слайдов
    audioFrame.setHideAtShowing(true);
    // Перематывает аудио к началу после воспроизведения
    audioFrame.setRewindAudio(true);
    // Сохраняет файл PowerPoint на диск
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Этот JavaScript‑пример показывает, как добавить новый аудио кадр со встроенным аудио, обрезать его и задать длительность затухания:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Устанавливает смещение начала обрезки на 1,5 секунды
    audioFrame.setTrimFromStart(1500);
    // Устанавливает смещение конца обрезки на 2 секунды
    audioFrame.setTrimFromEnd(2000);

    // Устанавливает длительность fade-in 200 мс
    audioFrame.setFadeInDuration(200);
    // Устанавливает длительность fade-out 500 мс
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Следующий пример кода показывает, как получить аудио кадр со встроенным аудио и установить его громкость на 85 %:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Получает форму аудио кадра
    const audioFrame = slide.getShapes().get_Item(0);

    // Устанавливает громкость аудио на 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Управление субтитрами аудио**

Aspose.Slides позволяет добавлять закрытые субтитры к аудио кадру через метод [getCaptionTracks](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Этот метод возвращает объект [CaptionsCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/), который позволяет добавлять треки WebVTT, перебирать существующие треки и удалять их при необходимости.

**Добавить субтитры к аудио**

Используйте метод [getCaptionTracks](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/#getCaptionTracks), чтобы прикрепить один или несколько треков субтитров к аудио кадру. В примере ниже аудиофайл добавляется на слайд, после чего новый трек субтитров загружается из файла `.vtt`.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Добавить новый трек субтитров из файла WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Извлечь субтитры аудио**

Можно пройтись по трекам субтитров, связанным с аудио кадром, и сохранить их как файлы `.vtt`. Каждый трек предоставляет свои бинарные данные и уникальный идентификатор, который можно использовать при экспорте субтитров.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // Сохранить трек субтитров как файл .vtt.
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

**Удалить субтитры аудио**

Чтобы удалить субтитры из аудио кадра, используйте методы, предоставляемые [CaptionsCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/), такие как [clear](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/#remove) или [removeAt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/captionscollection/#removeAt). Пример ниже удаляет все треки субтитров из аудио кадра.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // тип: aspose.slides.AudioFrame

    // Удалить все треки субтитров из аудио кадра.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Извлечь аудио**

Aspose.Slides for Node.js via Java позволяет извлекать звук, используемый в переходах слайд‑шоу. Например, можно извлечь звук, использованный в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на нужный слайд по его индексу.
3. Доступ к [slideshow transitions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) для данного слайда.
4. Извлеките звук в виде байтовых данных.

Этот JavaScript‑код показывает, как извлечь аудио, используемое в слайде:

```javascript
// Создаёт экземпляр класса Presentation, представляющего файл презентации
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Получает нужный слайд
    const slide = pres.getSlides().get_Item(0);
    // Получает эффекты перехода слайд-шоу для слайда
    const transition = slide.getSlideShowTransition();
    // Извлекает звук в массив байтов
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Можно ли использовать один и тот же аудио‑ресурс на нескольких слайдах без увеличения размера файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getaudios/) презентации и создайте дополнительные аудио кадры, ссылающиеся на этот ресурс. Это исключает дублирование медиа‑данных и сохраняет размер презентации под контролем.

**Можно ли заменить звук в существующем аудио кадре без пересоздания формы?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) до нового файла. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) другим из [audio collection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getaudios/) презентации. Форматирование кадра и большинство настроек воспроизведения останутся неизменными.

**Изменяет ли обрезка (trimming) исходные аудио‑данные, хранящиеся в презентации?**

Нет. Обрезка меняет только границы воспроизведения. Исходные байты аудио остаются нетронутыми и доступны через встроенный аудио объект или коллекцию аудио презентации.