---
title: Управление аудио в презентациях с помощью JavaScript
linktitle: Аудио‑кадр
type: docs
weight: 10
url: /ru/nodejs-java/audio-frame/
keywords:
- аудио
- аудио‑кадр
- миниатюра
- добавить аудио
- свойства аудио
- параметры аудио
- извлечение аудио
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте и управляйте аудио‑кадрами в Aspose.Slides for Node.js — примеры JavaScript для встраивания, обрезки, зацикливания и настройки воспроизведения в презентациях PPT, PPTX и ODP."
---

## **Создание аудио‑кадров**

Aspose.Slides for Node.js via Java позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды в виде аудио‑кадров.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который хотите встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioPlayModePreset) и `Volume`, доступные через объект [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame).
6. Сохраните изменённую презентацию.

Этот JavaScript‑код показывает, как добавить встроенный аудио‑кадр на слайд:
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


## **Изменение миниатюры аудио‑кадра**

При добавлении аудиофайла в презентацию он отображается как кадр со стандартным изображением по умолчанию (см. изображение ниже). Вы можете изменить превью‑изображение аудио‑кадра (установить своё изображение).

Этот JavaScript‑код показывает, как изменить миниатюру или превью‑изображение аудио‑кадра:
```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Добавляет аудио‑кадр на слайд с заданными позицией и размером.
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


## **Изменение параметров воспроизведения аудио**

Aspose.Slides for Node.js via Java позволяет менять параметры, управляющие воспроизведением аудио или его свойствами. Например, можно отрегулировать громкость, установить непрерывное воспроизведение в цикле или скрыть значок аудио.

Панель **Audio Options** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Параметры PowerPoint **Audio Options**, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/):
- **Start** выпадающий список соответствует методу [AudioFrame.setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** соответствует методу [AudioFrame.setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** соответствует методу [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** соответствует методу [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** соответствует методу [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** соответствует методу [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio)

Параметры PowerPoint **Editing**, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/):

- **Fade In** соответствует методу [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** соответствует методу [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** соответствует методу [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** — значение равно длительности аудио минус значение, задаваемое методом [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

PowerPoint **Контроль громкости** на аудио‑панели управления соответствует методу [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Он позволяет изменять громкость аудио в процентах.

Вот как изменить параметры воспроизведения аудио:

1. [Создать](#create-audio-frame) или получить Audio Frame.
2. Установите новые значения свойств Audio Frame, которые хотите изменить.
3. Сохраните изменённый файл PowerPoint.

Этот JavaScript‑код демонстрирует операцию, в которой регулируются параметры аудио:
```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Получает форму AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Устанавливает режим воспроизведения по клику
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


Этот пример JavaScript показывает, как добавить новый аудио‑кадр с вложенным аудио, обрезать его и задать длительности затухания:
```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Устанавливает смещение начала обрезки в 1,5 секунды
    audioFrame.setTrimFromStart(1500);
    // Устанавливает смещение конца обрезки в 2 секунды
    audioFrame.setTrimFromEnd(2000);

    // Устанавливает длительность плавного появления в 200 мс
    audioFrame.setFadeInDuration(200);
    // Устанавливает длительность плавного затухания в 500 мс
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Следующий пример кода показывает, как получить аудио‑кадр с вложенным аудио и установить его громкость на 85 %:
```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Получает форму аудио‑кадра
    const audioFrame = slide.getShapes().get_Item(0);

    // Устанавливает громкость аудио на 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


## **Извлечение аудио**

Aspose.Slides for Node.js via Java позволяет извлекать звук, используемый в переходах слайд‑шоу. Например, можно извлечь звук, использованный в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на нужный слайд по его индексу.
3. Доступ к [slideshow transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) для этого слайда.
4. Извлеките звук в виде байтовых данных.

Этот JavaScript‑код показывает, как извлечь аудио, использованное в слайде:
```javascript
// Создаёт экземпляр класса Presentation, представляющего файл презентации
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Доступ к нужному слайду
    const slide = pres.getSlides().get_Item(0);
    // Получает эффекты перехода слайд‑шоу для слайда
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

**Могу ли я использовать один и тот же аудио‑ресурс на нескольких слайдах без увеличения размера файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/) презентации и создайте дополнительные аудио‑кадры, которые ссылаются на уже существующий ресурс. Это предотвращает дублирование медиа‑данных и держит размер презентации под контролем.

**Можно ли заменить звук в существующем аудио‑кадре без пересоздания формы?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) чтобы он указывал на новый файл. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) другим из [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/) презентации. Форматирование кадра и большинство настроек воспроизведения сохранятся.

**Изменит ли обрезка подлежащие аудио‑данные, хранящиеся в презентации?**

Нет. Обрезка изменяет только границы воспроизведения. Исходные байты аудио остаются нетронутыми и доступны через встроенное аудио или коллекцию аудио презентации.