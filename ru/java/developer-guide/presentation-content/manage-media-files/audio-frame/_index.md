---
title: Управление аудио в презентациях с помощью Java
linktitle: Аудио кадр
type: docs
weight: 10
url: /ru/java/audio-frame/
keywords:
- аудио
- аудио кадр
- миниатюра
- добавить аудио
- свойства аудио
- параметры аудио
- извлечь аудио
- Java
- Aspose.Slides
description: "Создавайте и управляйте аудио кадрами в Aspose.Slides for Java — примеры кода для внедрения, обрезки, зацикливания и настройки воспроизведения в презентациях PPT, PPTX и ODP."
---
## **Создание аудио кадров**

Aspose.Slides for Java позволяет добавлять аудиофайлы на слайды. Аудиофайлы внедряются в слайды в виде аудио кадров. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который вы хотите внедрить в слайд.
4. Добавьте внедрённый аудио кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/AudioPlayModePreset) и `Volume`, доступные через объект [IAudioFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAudioFrame).
6. Сохраните изменённую презентацию.

Этот пример кода на Java показывает, как добавить внедрённый аудио кадр на слайд:

```java
// Создаёт экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Загружает wav звуковой файл в поток
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Добавляет аудио кадр
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Устанавливает режим воспроизведения и громкость аудио
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Записывает файл PowerPoint на диск
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Изменение миниатюры аудио кадра**

Когда вы добавляете аудиофайл в презентацию, он отображается в виде кадра со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить изображение предпросмотра аудио кадра (установить желаемое изображение).

Этот пример кода на Java показывает, как изменить миниатюру или изображение предпросмотра аудио кадра:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавляет аудио кадр на слайд с указанными позицией и размером.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Добавляет изображение в ресурсы презентации.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Устанавливает изображение для аудио кадра.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Сохраняет изменённую презентацию на диск
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Изменение параметров воспроизведения аудио**

Aspose.Slides for Java позволяет изменять параметры, управляющие воспроизведением аудио или его свойствами. Например, можно регулировать громкость аудио, установить воспроизведение в цикле или даже скрыть значок аудио.

Область **Audio Options** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Параметры **Audio Options** в PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/AudioFrame) свойства:

- **Start** выпадающий список соответствует методу [AudioFrame.setPlayMode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/audioframe/#setPlayMode-int-).
- **Volume** соответствует методу [AudioFrame.setVolume](https://reference.aspose.com/slides/ru/java/com.aspose.slides/audioframe/#setVolume-int-).
- **Play Across Slides** соответствует методу [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-).
- **Loop until Stopped** соответствует методу [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-).
- **Hide During Show** соответствует методу [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-).
- **Rewind after Playing** соответствует методу [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/ru/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-).

Параметры **Editing** в PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/AudioFrame) свойства:

- **Fade In** соответствует методу [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/ru/java/com.aspose.slides/audioframe/#setFadeInDuration-float-).
- **Fade Out** соответствует методу [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/ru/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-).
- **Trim Audio Start Time** соответствует методу [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/ru/java/com.aspose.slides/audioframe/#setTrimFromStart-float-).
- **Trim Audio End Time** значение равно длительности аудио минус значение метода [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/ru/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-).

Элемент управления **Volume** в PowerPoint на панели аудио соответствует методу [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Он позволяет изменять громкость аудио в процентах.

Вот как изменить параметры воспроизведения аудио:

1. [Создайте](#create-audio-frame) или получите аудио кадр.
2. Установите новые значения свойств аудио кадра, которые нужно изменить.
3. Сохраните изменённый файл PowerPoint.

Этот пример кода на Java демонстрирует операцию, в которой изменяются параметры аудио:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Получает форму AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Устанавливает режим воспроизведения на клик
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Устанавливает громкость на Low
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Устанавливает воспроизведение аудио на всех слайдах
    audioFrame.setPlayAcrossSlides(true);

    // Отключает зацикливание аудио
    audioFrame.setPlayLoopMode(false);

    // Скрывает AudioFrame во время показа слайдов
    audioFrame.setHideAtShowing(true);

    // Перематывает аудио к началу после воспроизведения
    audioFrame.setRewindAudio(true);

    // Сохраняет файл PowerPoint на диск
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Этот пример кода на Java показывает, как добавить новый аудио кадр с внедрённым аудио, обрезать его и задать продолжительность плавного появления и исчезновения:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Устанавливает начало обрезки на 1,5 секунды
    audioFrame.setTrimFromStart(1500f);
    // Устанавливает конец обрезки на 2 секунды
    audioFrame.setTrimFromEnd(2000f);

    // Устанавливает длительность плавного появления (fade-in) 200 мс
    audioFrame.setFadeInDuration(200f);
    // Устанавливает длительность плавного исчезновения (fade-out) 500 мс
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Следующий образец кода показывает, как получить аудио кадр с внедрённым аудио и установить его громкость на 85%:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Получает форму аудио кадра
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Устанавливает громкость аудио на 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Управление субтитрами аудио**

Aspose.Slides позволяет добавлять закрытые субтитры к аудио кадру с помощью метода [getCaptionTracks](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Этот метод возвращает объект [ICaptionsCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptionscollection/), который позволяет добавлять дорожки субтитров WebVTT, перебрать существующие дорожки и при необходимости удалять их.

**Добавить субтитры к аудио**

Используйте метод [getCaptionTracks](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) чтобы присоединить одну или несколько дорожек субтитров к аудио кадру. В следующем примере аудиофайл добавляется на слайд, затем новая дорожка субтитров загружается из файла `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Добавить новую дорожку субтитров из файла WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Извлечь субтитры аудио**

Можно перебрать дорожки субтитров, связанные с аудио кадром, и сохранить их как файлы `.vtt`. Каждая дорожка субтитров предоставляет свои бинарные данные и уникальный идентификатор, который можно использовать при экспорте субтитров.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Сохранить дорожку субтитров как файл .vtt.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Удалить субтитры аудио**

Чтобы удалить субтитры из аудио кадра, используйте методы, предоставляемые [ICaptionsCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptionscollection/), такие как [clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), или [removeAt](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptionscollection/#removeAt-int-). В следующем примере удаляются все дорожки субтитров из аудио кадра.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Удалить все дорожки субтитров из аудио кадра.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Извлечение аудио**

Aspose.Slides for Java позволяет извлекать звук, используемый в переходах слайд-шоу. Например, можно извлечь звук, применяемый в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Получите доступ к [slideshow transitions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) для слайда.
4. Извлеките звук в виде байтовых данных.

Этот пример кода на Java показывает, как извлечь звук, используемый в слайде:

```java
// Создаёт экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Получает нужный слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Получает эффекты перехода слайд-шоу для слайда
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Извлекает звук в массив байтов
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Могу ли я использовать один и тот же аудиофайл на нескольких слайдах без увеличения размера файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getAudios--) презентации и создайте дополнительные аудио кадры, которые ссылаются на этот существующий ресурс. Это избавляет от дублирования медиа данных и держит размер презентации под контролем.

**Могу ли я заменить звук в существующем аудио кадре без пересоздания формы?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) чтобы он указывал на новый файл. Для внедрённого звука замените объект [embedded audio](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) другим из [audio collection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getAudios--) презентации. Форматирование кадра и большинство настроек воспроизведения сохраняются.

**Изменяет ли обрезка фактические аудио данные, хранящиеся в презентации?**

Нет. Обрезка изменяет только границы воспроизведения. Исходные аудио байты остаются нетронутыми и доступны через внедрённый аудио объект или [audio collection] презентации.