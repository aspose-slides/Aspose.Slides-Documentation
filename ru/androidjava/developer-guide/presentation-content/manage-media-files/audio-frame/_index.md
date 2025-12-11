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
description: "Создавайте и управляйте аудио‑кадрами в Aspose.Slides для Android—примеры на Java для встраивания, обрезки, зацикливания и настройки воспроизведения в презентациях PPT, PPTX и ODP."
---

## **Создать аудио‑кадры**
Aspose.Slides for Android via Java позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды как аудио‑кадры.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который хотите встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) и `Volume`, доступные через объект [IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame).
6. Сохраните изменённую презентацию.

Этот код на Java показывает, как добавить встроенный аудио‑кадр на слайд:
```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Загружает wav‑файл звука в поток
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


## **Изменить миниатюру аудио‑кадра**

Когда вы добавляете аудиофайл в презентацию, он отображается как кадр со стандартным изображением по умолчанию (см. изображение ниже). Вы можете изменить изображение‑превью аудио‑кадра (установить своё изображение).

Этот код на Java показывает, как изменить миниатюру или изображение‑превью аудио‑кадра:
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


## **Изменить параметры воспроизведения аудио**

Aspose.Slides for Android via Java позволяет менять параметры, контролирующие воспроизведение аудио или его свойства. Например, вы можете отрегулировать громкость, задать бесконечный цикл воспроизведения или скрыть иконку аудио.

Панель **Audio Options** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame) :

- **Start** выпадающий список соответствует свойству [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volume** соответствует свойству [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Play Across Slides** соответствует свойству [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loop until Stopped** соответствует свойству [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Hide During Show** соответствует свойству [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Rewind after Playing** соответствует свойству [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

PowerPoint **Editing** параметры, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/) :

- **Fade In** соответствует свойству [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Fade Out** соответствует свойству [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trim Audio Start Time** соответствует свойству [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Trim Audio End Time** равно длительности аудио минус значение свойства [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

Ползунок **Volume** на панели управления аудио в PowerPoint соответствует свойству [AudioFrame.VolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) . Он позволяет изменить громкость аудио в процентах.

Так меняются параметры воспроизведения аудио:

1. [Создать](#create-audio-frame) или получить Audio Frame.
2. Установите новые значения свойств Audio Frame, которые хотите изменить.
3. Сохраните изменённый файл PowerPoint.

Этот код на Java демонстрирует операцию, в которой настраиваются параметры аудио:
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Получает форму AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Устанавливает режим воспроизведения «по щелчку»
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Устанавливает громкость «низкая»
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Устанавливает воспроизведение аудио на всех слайдах
    audioFrame.setPlayAcrossSlides(true);

    // Отключает зацикливание аудио
    audioFrame.setPlayLoopMode(false);

    // Скрывает AudioFrame во время показа слайдов
    audioFrame.setHideAtShowing(true);

    // Возвращает аудио к началу после воспроизведения
    audioFrame.setRewindAudio(true);

    // Сохраняет файл PowerPoint на диск
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Этот пример на Java показывает, как добавить новый аудио‑кадр со встроенным аудио, обрезать его и задать длительность затухания:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Устанавливает начальное смещение обрезки в 1.5 секунды
    audioFrame.setTrimFromStart(1500f);
    // Устанавливает конечное смещение обрезки в 2 секунды
    audioFrame.setTrimFromEnd(2000f);

    // Устанавливает длительность плавного появления в 200 мс
    audioFrame.setFadeInDuration(200f);
    // Устанавливает длительность плавного затухания в 500 мс
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


В следующем примере показано, как получить аудио‑кадр со встроенным аудио и установить его громкость на 85 %:
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


## **Извлечение аудио**

Aspose.Slides for Android via Java позволяет извлекать звук, использованный в переходах слайд‑шоу. Например, можно извлечь звук, применённый к конкретному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Доступ к [slideshow transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) для слайда.
4. Извлеките звук в виде байтовых данных.

Этот код на Java показывает, как извлечь аудио, использованное в слайде:
```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Получает нужный слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Получает эффекты переходов слайдшоу для слайда
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Извлекает звук в массив байтов
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Можно ли использовать один и тот же аудио‑ресурс на нескольких слайдах без увеличения размера файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) презентации и создайте дополнительные аудио‑кадры, ссылающиеся на уже существующий ресурс. Это исключает дублирование медиа‑данных и позволяет контролировать размер презентации.

**Можно ли заменить звук в существующем аудио‑кадре без пересоздания фигуры?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) до нового файла. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) на другой из [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) презентации. Форматирование кадра и большинство настроек воспроизведения сохранятся.

**Изменяет ли обрезка фактические аудио‑данные, хранящиеся в презентации?**

Нет. Обрезка изменяет только границы воспроизведения. Исходные байты аудио остаются нетронутыми и доступны через встроенное аудио или коллекцию аудио презентации.