---
title: Управление аудио‑фреймами в презентациях на Android
linktitle: Аудио‑фрейм
type: docs
weight: 10
url: /ru/androidjava/audio-frame/
keywords:
- аудио
- аудио‑фрейм
- миниатюра
- добавить аудио
- свойства аудио
- параметры аудио
- извлечение аудио
- Android
- Java
- Aspose.Slides
description: "Встраивание аудио в слайды, изменение значка аудио, настройка воспроизведения, управление субтитрами WebVTT и извлечение звуков переходов слайдов с помощью Aspose.Slides for Android via Java."
---
## **Обзор**

Аудиофрейм позволяет воспроизводить звук на слайде. С помощью Aspose.Slides for Android via Java вы можете встроить аудиоклип, выбрать изображение, представляющее его, настроить воспроизведение и добавить субтитры. Также можно получить звук, назначенный переходу слайда.

## **Создание аудио‑фреймов**

Используйте [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) для встраивания локального аудиоклипа на первый слайд. Первые две координаты задают положение фрейма на слайде, а следующие два значения устанавливают его ширину и высоту, все в пунктах. В этом примере вызывается [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) для автоматического запуска клипа и [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) для выбора громкой предустановки.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Изменение миниатюры аудио‑фрейма**

По умолчанию аудио‑фрейм отображает значок динамика. Чтобы установить пользовательскую миниатюру, добавьте изображение в презентацию с помощью [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) и задайте его для картинки фрейма через [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). В примере используется JPEG как миниатюра для встроенного аудиоклипа.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Изменение параметров воспроизведения аудио**

Элементы управления **Audio Options** в PowerPoint определяют, когда начинается воспроизведение, насколько громко звучит и как клип себя ведёт во время показа.

![Элементы управления аудио‑опциями PowerPoint для аудио‑фрейма](audio_frame_0.png)

| Элемент управления PowerPoint | Метод Aspose.Slides for Android via Java |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Volume preset | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Play Across Slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Loop until Stopped | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Hide During Show | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Rewind after Playing | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Trim Audio start time | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Trim Audio end time | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Volume slider | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

В примере находится первый аудио‑фрейм на первом слайде, вызывается [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) для запуска воспроизведения по щелчку и выбирается низкая предустановка громкости. Клип продолжает воспроизводиться на нескольких слайдах, при этом зацикливание отключено. Значок скрывается во время показа, а после воспроизведения клип возвращается в начальное положение.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Для клипа длительностью более 3,5 секунды этот пример пропускает первые 1,5 секунды и последние 2 секунды. [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) принимает длительность, которую нужно исключить из конца клипа. Чтобы получить конечное время, отображаемое в PowerPoint, вычтите этот сдвиг из полной длительности клипа. Обрезанный клип плавно появляется за 200 мс и плавно исчезает за 500 мс. Все четыре метода принимают значения в миллисекундах.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы установить громкость воспроизведения в процентах, используйте [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-). В этом примере первая аудио‑фрейм на первом слайде получает громкость 85 %.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Управление субтитрами аудио**

Каждый аудио‑фрейм предоставляет доступ к своим дорожкам субтитров через [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Используйте коллекцию, чтобы добавить WebVTT‑субтитры к клипу, экспортировать существующие дорожки или удалить их.

### **Добавление субтитров к аудио**

В примере встраивается аудио‑клип на первый слайд и с помощью [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) добавляется локальная дорожка WebVTT. Первый аргумент задаёт метку дорожки, второй — файл с тайм‑кодами субтитров.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Экспорт субтитров аудио**

Этот пример экспортирует каждую дорожку субтитров, прикреплённую к аудио‑фрейму на первом слайде. Он записывает байты, возвращённые [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--), в файл WebVTT и использует идентификатор, возвращённый [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--), как имя файла, чтобы каждая дорожка имела отдельный вывод.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            try (FileOutputStream output = new FileOutputStream(track.getCaptionId() + ".vtt")) {
                output.write(track.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **Удаление субтитров аудио**

Используйте [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) или [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) для удаления отдельной дорожки. В примере применяется [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--) для удаления всех субтитров из первого аудио‑фрейма на первом слайде при сохранении клипа.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Поиск строки в субтитрах аудио**

Чтобы найти строку в субтитрах аудио на первом слайде, выполните поиск текста, возвращённого [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--), в памяти. В обычном текстовом WebVTT‑cue строка времени содержит `-->`, за ней следуют строки субтитров, а пустая строка завершает cue. Этот пример выводит метку дорожки и каждую строку субтитров, содержащую слово «café».

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\r\\n|\\r|\\n")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Извлечение аудио**

Переход слайда может иметь собственный звук. Чтобы получить его, вызовите [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--) у перехода слайда. Пример получает байты, возвращённые [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--), и выводит их количество. Если у первого слайда нет звука перехода, выводится сообщение.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **Вопросы и ответы**

**Можно ли использовать один и тот же аудио‑клип на нескольких слайдах без дублирования?**

Да. Добавьте клип один раз в [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) презентации и передайте тот же объект аудио в [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) для каждого слайда.

**Можно ли заменить звук в существующем аудио‑фрейме?**

Да. Для связанного звука используйте [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) чтобы указать путь к заменяющему файлу. Для встроенного звука выберите другой клип из [audio collection] презентации с помощью [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). Оба подхода сохраняют существующий фрейм.

**Изменяется ли аудио‑данные в презентации при обрезке?**

Нет. [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) и [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) задают границы воспроизведения. Полный клип всё ещё можно получить через [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).