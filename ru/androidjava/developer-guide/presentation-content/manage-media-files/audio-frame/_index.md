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
- опции аудио
- извлечь аудио
- Android
- Java
- Aspose.Slides
description: "Создавайте и управляйте аудио‑кадрами в Aspose.Slides для Android — примеры на Java для встраивания, обрезки, зацикливания и настройки воспроизведения в презентациях PPT, PPTX и ODP."
---

## **Создание аудио‑кадров**
Aspose.Slides for Android via Java позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды в виде аудио‑кадров.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который вы хотите встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) и `Volume`, предоставляемые объектом [IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame).
6. Сохраните изменённую презентацию.

Этот пример кода на Java показывает, как добавить встроенный аудио‑кадр на слайд:
```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Загружает wav звуковой файл в поток
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

Когда вы добавляете аудиофайл в презентацию, он отображается как кадр со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить изображение предварительного просмотра аудио‑кадра (установить желаемое изображение).

Этот пример кода на Java показывает, как изменить миниатюру или изображение предварительного просмотра аудио‑кадра:
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

    //Сохраняет изменённую презентацию на диск
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Изменение параметров воспроизведения аудио**

Aspose.Slides for Android via Java позволяет изменять параметры, контролирующие воспроизведение или свойства аудио. Например, можно регулировать громкость аудио, установить воспроизведение в цикле или даже скрыть значок аудио.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame) properties:
- **Start** выпадающий список соответствует свойству [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) property
- **Volume** соответствует свойству [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--) property
- **Play Across Slides** соответствует свойству [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) property
- **Loop until Stopped** соответствует свойству [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) property
- **Hide During Show** соответствует свойству [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) property
- **Rewind after Playing** соответствует свойству [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) property

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/) properties:
- **Fade In** соответствует свойству [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) property 
- **Fade Out** соответствует свойству [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) property 
- **Trim Audio Start Time** соответствует свойству [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) property 
- **Trim Audio End Time** равно продолжительности аудио за вычетом значения свойства [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) property

The PowerPoint **Volume controll** on the audio control panel corresponds to the [AudioFrame.VolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) property. It lets you change the audio volume as a percentage.

Вот как изменить параметры воспроизведения аудио:
1. [Создать](#create-audio-frame) или получить Audio Frame.
2. Установите новые значения для свойств Audio Frame, которые хотите изменить.
3. Сохраните изменённый файл PowerPoint.

Этот пример кода на Java демонстрирует операцию, в которой изменяются параметры аудио:
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Получает форму AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Устанавливает режим воспроизведения на воспроизведение по клику
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Устанавливает громкость на низкую
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


Этот пример кода на Java показывает, как добавить новый аудио‑кадр со встроенным аудио, обрезать его и установить длительности затухания:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Устанавливает начальное смещение обрезки в 1,5 секунды
    // Устанавливает конечное смещение обрезки в 2 секунды
    // Устанавливает длительность появления (fade-in) 200 мс
    // Устанавливает длительность исчезновения (fade-out) 500 мс

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Следующий пример кода показывает, как получить аудио‑кадр со встроенным аудио и установить его громкость на 85%:
```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Получает форму audio frame
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

Aspose.Slides for Android via Java позволяет извлекать звук, используемый в переходах слайд‑шоу. Например, можно извлечь звук, использованный в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите доступ к [slideshow transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) для слайда.
4. Извлеките звук в виде байтовых данных.

Этот пример кода на Java показывает, как извлечь аудио, использованное в слайде:
```java
// Создаёт объект класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Получает нужный слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Получает эффекты перехода слайд-шоу для слайда
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Извлекает звук в массив байтов
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Могу ли я использовать один и тот же аудио‑ресурс на нескольких слайдах без увеличения размера файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) презентации и создайте дополнительные аудио‑кадры, которые ссылаются на этот существующий ресурс. Это исключает дублирование медиа‑данных и позволяет контролировать размер презентации.

**Могу ли я заменить звук в существующем аудио‑кадре без воссоздания формы?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) так, чтобы он указывал на новый файл. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) другим из [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) презентации. Форматирование кадра и большинство настроек воспроизведения останутся без изменений.

**Изменяет ли обрезка исходные аудио‑данные, хранящиеся в презентации?**

Нет. Обрезка изменяет только границы воспроизведения. Исходные байты аудио остаются нетронутыми и доступны через встроенное аудио или [audio collection] презентации.