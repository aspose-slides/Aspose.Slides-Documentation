---
title: Управление аудио в презентациях на Android
linktitle: Аудио‑кадр
type: docs
weight: 10
url: /ru/androidjava/audio-frame/
keywords:
- аудио
- аудио‑кадр
- миниатюра
- добавить аудио
- свойства аудио
- параметры аудио
- извлечь аудио
- Android
- Java
- Aspose.Slides
description: "Создавайте и управляйте аудио‑кадрами в Aspose.Slides для Android — примеры на Java для встраивания, обрезки, зацикливания и настройки воспроизведения в презентациях PPT, PPTX и ODP."
---
## **Создание аудио‑кадров**
Aspose.Slides for Android via Java позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды как аудио‑кадры.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который необходимо встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержит аудиофайл) на слайд.
5. Задайте [PlayMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/AudioPlayModePreset) и `Volume`, доступные через объект [IAudioFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IAudioFrame).
6. Сохраните изменённую презентацию.

Этот код на Java демонстрирует, как добавить встроенный аудио‑кадр на слайд:

```java
// Создаёт объект класса Presentation, представляющий файл презентации
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Загружает WAV‑файл звука в поток
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Добавляет аудио‑кадр
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

## **Изменение миниатюры аудио‑кадра**

При добавлении аудиофайла в презентацию он отображается как кадр со стандартным изображением по умолчанию (см. изображение ниже). Вы можете изменить изображение‑превью аудио‑кадра (установить собственное изображение).

Этот код на Java показывает, как изменить миниатюру (превью) аудио‑кадра:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавляет аудио‑кадр на слайд с указанными позицией и размером.
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

    // Устанавливает изображение для аудио‑кадра.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // Сохраняет изменённую презентацию на диск
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Изменение параметров воспроизведения аудио**

Aspose.Slides for Android via Java позволяет менять параметры, контролирующие воспроизведение аудио или его свойства. Например, можно отрегулировать громкость, установить воспроизведение в цикле или скрыть значок аудио.

Область **Audio Options** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Параметры **Audio Options** в PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/AudioFrame):

- Выпадающий список **Start** соответствует свойству [AudioFrame.PlayMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volume** соответствует свойству [AudioFrame.Volume](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Play Across Slides** соответствует свойству [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loop until Stopped** соответствует свойству [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Hide During Show** соответствует свойству [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Rewind after Playing** соответствует свойству [AudioFrame.RewindAudio](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

Параметры **Editing** в PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/audioframe/):

- **Fade In** соответствует свойству [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Fade Out** соответствует свойству [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trim Audio Start Time** соответствует свойству [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Trim Audio End Time** — значение равно длительности аудио минус значение свойства [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

Элемент управления громкостью **Volume controll** на панели управления аудио в PowerPoint соответствует свойству [AudioFrame.VolumeValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) и позволяет изменять громкость в процентах.

Как изменить параметры воспроизведения аудио:

1. [Create](#create-audio-frame) или получите аудио‑кадр.
2. Установите новые значения нужных свойств аудио‑кадра.
3. Сохраните изменённый файл PowerPoint.

Этот код на Java демонстрирует изменение параметров аудио:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Получает объект формы AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Устанавливает режим воспроизведения на воспроизведение по щелчку
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Устанавливает громкость на низкую
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Устанавливает воспроизведение аудио через все слайды
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

Пример на Java, показывающий, как добавить новый аудио‑кадр со встроенным аудио, обрезать его и задать длительности затухания:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Устанавливает начальное смещение обрезки в 1,5 секунды
    audioFrame.setTrimFromStart(1500f);
    // Устанавливает конечное смещение обрезки в 2 секунды
    audioFrame.setTrimFromEnd(2000f);

    // Устанавливает длительность затухания при включении 200 мс
    audioFrame.setFadeInDuration(200f);
    // Устанавливает длительность затухания при выключении 500 мс
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Следующий фрагмент кода показывает, как получить аудио‑кадр со встроенным аудио и установить его громкость — 85 %:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Получает форму аудио‑кадра
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Устанавливает громкость аудио на 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Работа с субтитрами аудио**

Aspose.Slides позволяет добавлять закрытые субтитры к аудио‑кадру через метод [getCaptionTracks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Этот метод возвращает [ICaptionsCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icaptionscollection/), позволяющую добавлять дорожки WebVTT, перебрать существующие дорожки и удалять их при необходимости.

**Добавление субтитров к аудио**

Используйте метод [getCaptionTracks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) для присоединения одной или нескольких дорожек субтитров к аудио‑кадру. В примере ниже аудиофайл добавляется на слайд, после чего новая дорожка субтитров загружается из файла `.vtt`.

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

**Извлечение субтитров из аудио**

Можно перебрать дорожки субтитров, связанные с аудио‑кадром, и сохранить их как файлы `.vtt`. Каждая дорожка предоставляет доступ к своим бинарным данным и уникальному идентификатору, которые могут использоваться при экспорте субтитров.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Сохранить дорожку субтитров в файл .vtt.
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**Удаление субтитров из аудио**

Для удаления субтитров из аудио‑кадра используйте методы из [ICaptionsCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icaptionscollection/), такие как [clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), или [removeAt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-). В примере ниже удаляются все дорожки субтитров из аудио‑кадра.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Удалить все дорожки субтитров из аудио‑кадра.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Извлечение аудио**

Aspose.Slides for Android via Java позволяет извлекать звук, используемый в переходах слайд‑шоу. Например, можно извлечь звук, использованный в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на нужный слайд по его индексу.
3. Обратитесь к [slideshow transitions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) данного слайда.
4. Извлеките звук в виде массивов байтов.

Этот код на Java показывает, как извлечь аудио, использованное в слайде:

```java
// Создаёт объект класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Обращается к нужному слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Получает эффекты перехода слайд‑шоу для слайда
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Извлекает звук в массив байтов
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Можно ли использовать один и тот же аудиофайл на нескольких слайдах без увеличения размера файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getAudios--) презентации и создайте дополнительные аудио‑кадры, которые ссылаются на уже существующий ресурс. Это избегает дублирования медиа‑данных и сохраняет размер презентации под контролем.

**Можно ли заменить звук в существующем аудио‑кадре без пересоздания формы?**

Да. Для связанного звука измените [link path](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) на новый файл. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) другим из [audio collection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getAudios--) презентации. Форматирование кадра и большинство настроек воспроизведения сохранятся.

**Изменяет ли обрезка (trimming) сами аудиоданные, хранящиеся в презентации?**

Нет. Обрезка изменяет только границы воспроизведения. Исходные аудиобайты остаются нетронутыми и доступны через встроенное аудио или общую аудио‑коллекцию презентации.