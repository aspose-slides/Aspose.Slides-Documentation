---
title: Управление аудио‑кадрами в презентациях с использованием JavaScript
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
- извлечь аудио
- Node.js
- JavaScript
- Aspose.Slides
description: "Внедрите аудио в слайды, измените значок аудио, настройте воспроизведение, управляйте субтитрами WebVTT и извлеките звуки переходов слайдов с помощью Aspose.Slides for Node.js via Java."
---
## **Обзор**

Аудиофрейм позволяет воспроизводить звук на слайде. С Aspose.Slides for Node.js via Java вы можете внедрить аудиоклип, выбрать изображение, представляющее его, настроить воспроизведение и добавить субтитры. Вы также можете получить звук, назначенный переходу слайда.

## **Создание аудио‑кадров**

Используйте [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded), чтобы внедрить локальный аудиоклип на первый слайд. Первые две координаты задают позицию кадра на слайде, а следующие два значения задают его ширину и высоту, все в пунктах. В этом примере вызывается [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) для автоматического запуска клипа и вызывается [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) для выбора громкой предустановки.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
        audioFrame.setPlayMode(slides.AudioPlayModePreset.Auto);
        audioFrame.setVolume(slides.AudioVolumeMode.Loud);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameEmbed_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Изменение миниатюры аудио‑кадра**

По умолчанию аудио‑кадр отображает значок динамика. Чтобы отобразить пользовательскую миниатюру, добавьте изображение в презентацию с помощью [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) и установите его в качестве картинки кадра с помощью [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage). В примере используется `eagle.jpeg` в качестве миниатюры для встроенного аудио‑клипа.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        const imageStream = java.newInstanceSync("java.io.FileInputStream", "eagle.jpeg");
        try {
            const thumbnail = presentation.getImages().addImage(imageStream);
            audioFrame.getPictureFormat().getPicture().setImage(thumbnail);
        } finally {
            imageStream.close();
        }
    } finally {
        audioStream.close();
    }
    presentation.save("example_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Изменение параметров воспроизведения аудио**

PowerPoint’s **Audio Options** controls determine when a clip starts, how loud it sounds, and how it behaves during a slide show.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Элемент управления PowerPoint | Aspose.Slides for Node.js via Java method |
| --- | --- |
| Запуск | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Предустановка громкости | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Воспроизведение на всех слайдах | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Повтор до остановки | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Скрыть во время показа | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Перемотать после воспроизведения | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Постепенное появление | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Постепенное исчезновение | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Обрезать начало аудио | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Обрезать конец аудио | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Регулятор громкости | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

В примере находится первый аудио‑кадр на первом слайде, вызывается [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) для запуска воспроизведения по щелчку и выбирается предустановка низкой громкости. Клип продолжается на всех слайдах при отключённом повторе. Значок остаётся скрытым во время показа, и клип перематывается после воспроизведения.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setPlayMode(slides.AudioPlayModePreset.OnClick);
        audioFrame.setVolume(slides.AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Для клипа длиннее 3,5 секунды этот пример пропускает первые 1,5 секунды и последние 2 секунды. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) принимает длительность, которую нужно исключить из конца клипа. Чтобы получить конечное время, показанное в PowerPoint, вычтите это смещение из полной длительности клипа. Обрезанный клип плавно появляется за 200 миллисекунд и плавно исчезает за 500 миллисекунд. Все четыре метода принимают значения в миллисекундах.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
        audioFrame.setTrimFromStart(1500);
        audioFrame.setTrimFromEnd(2000);
        audioFrame.setFadeInDuration(200);
        audioFrame.setFadeOutDuration(500);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameTrimFade_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы установить громкость воспроизведения в определённый процент, используйте [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). В этом примере первый аудио‑кадр на первом слайде устанавливается на 85 %.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setVolumeValue(85);
        presentation.save("AudioFrameValue_out.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Управление аудио‑субтитрами**

Каждый аудио‑кадр предоставляет доступ к своим дорожкам субтитров через [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Используйте коллекцию, чтобы прикрепить WebVTT‑субтитры к клипу, экспортировать существующие дорожки или удалить их.

### **Добавить аудио‑субтитры**

В примере внедряется аудио‑клип на первый слайд и используется [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) для прикрепления локальной дорожки WebVTT. Первый аргумент задаёт метку дорожки, а второй указывает файл с тайм‑кодами субтитров.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
        audioFrame.getCaptionTracks().add("English", "track.vtt");
    } finally {
        audioStream.close();
    }
    presentation.save("audio_with_captions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Извлечь аудио‑субтитры**

В этом примере экспортируется каждая дорожка субтитров, прикреплённая к аудио‑кадру на первом слайде. Он записывает байты, возвращённые [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData), в файл WebVTT и использует идентификатор, возвращённый [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId), как имя файла, чтобы каждая дорожка имела отдельный вывод.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("node:fs");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            const fileName = track.getCaptionId() + ".vtt";
            const bytes = track.getBinaryData();
            const data = Buffer.from(bytes);
            fs.writeFileSync(fileName, data);
        }
    }
} finally {
    presentation.dispose();
}
```

### **Удалить аудио‑субтитры**

Используйте [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) или [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) для удаления отдельной дорожки. В примере используется [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) для удаления всех субтитров из первого аудио‑кадра на первом слайде, сохраняя клип.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Найти строку в аудио‑субтитрах**

Чтобы найти строку в аудио‑субтитрах на первом слайде, выполните поиск текста, возвращённого [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString), в памяти. В простом текстовом кью WebVTT строка с таймингом содержит `-->`, за ней следуют строки субтитров, а пустая строка завершает кью. В этом примере выводятся метка дорожки и каждая строка субтитров, содержащая «café».

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            let inCue = false;
            const captions = track.getDataAsString();
            for (const line of captions.split(/\r\n|\n|\r/)) {
                if (line === "") {
                    inCue = false;
                } else if (line.includes("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase().includes("café")) {
                    console.log(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Извлечение аудио**

Переход слайда может иметь собственный звук. Чтобы получить его, вызовите [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) у перехода слайда. В примере обращаются к байтам, возвращённым [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData), и выводится их количество. Если у первого слайда нет звука перехода, вместо этого выводится сообщение.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AudioSlide.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const sound = slide.getSlideShowTransition().getSound();
    if (sound) {
        const audioData = sound.getBinaryData();
        console.log("Transition sound: " + audioData.length + " bytes.");
    } else {
        console.log("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Могу ли я использовать один и тот же аудио‑клип на нескольких слайдах без его дублирования?**

Да. Добавьте клип один раз в [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) презентации и передавайте тот же объект аудио в [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) для каждого слайда.

**Могу ли я заменить звук в существующем аудио‑кадре?**

Да. Для связанного звука используйте [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong), чтобы указать файл‑заменитель. Для встроенного звука выберите другой клип из [audio collection] презентации с помощью [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio). Оба подхода сохраняют существующий кадр.

**Изменяет ли обрезка аудио‑данные, сохранённые в презентации?**

Нет. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) и [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) задают границы воспроизведения. Вы всё ещё можете получить полный клип через [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio).