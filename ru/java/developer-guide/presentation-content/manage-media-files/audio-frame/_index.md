---
title: Управление аудио в презентациях с использованием Java
linktitle: Аудио‑кадр
type: docs
weight: 10
url: /ru/java/audio-frame/
keywords:
- аудио
- аудио‑кадр
- миниатюра
- добавить аудио
- свойства аудио
- параметры аудио
- извлечь аудио
- Java
- Aspose.Slides
description: "Создавайте и управляйте аудио‑кадрами в Aspose.Slides для Java — примеры кода для внедрения, обрезки, зацикливания и настройки воспроизведения в презентациях PPT, PPTX и ODP."
---

## **Создание аудио‑кадров**

Aspose.Slides for Java позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды как аудио‑кадры. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс.
3. Загрузите поток аудиофайла, который вы хотите встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) и `Volume`, предоставляемые объектом [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame).
6. Сохраните изменённую презентацию.

Этот код на Java демонстрирует, как добавить встроенный аудио‑кадр на слайд:
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


## **Изменение миниатюры аудио‑кадра**

Когда вы добавляете аудиофайл в презентацию, аудио отображается как кадр со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить предварительное изображение аудио‑кадра (установить желаемое изображение).

Этот код на Java демонстрирует, как изменить миниатюру или предварительное изображение аудио‑кадра:
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

    //Сохраняет измененную презентацию на диск
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Изменение параметров воспроизведения аудио**

Aspose.Slides for Java позволяет изменять параметры, управляющие воспроизведением аудио или его свойствами. Например, вы можете отрегулировать громкость аудио, установить воспроизведение в цикле или даже скрыть значок аудио.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) properties:
- **Start** выпадающий список соответствует методу [AudioFrame.setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayMode-int-) 
- **Volume** соответствует методу [AudioFrame.setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolume-int-) 
- **Play Across Slides** соответствует методу [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-) 
- **Loop until Stopped** соответствует методу [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-) 
- **Hide During Show** соответствует методу [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-) 
- **Rewind after Playing** соответствует методу [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-) 

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) properties:
- **Fade In** соответствует методу [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) 
- **Fade Out** соответствует методу [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) 
- **Trim Audio Start Time** соответствует методу [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) 
- **Trim Audio End Time** значение равно длительности аудио минус значение метода [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-) 

Элемент управления **Volume** в панели аудио в PowerPoint соответствует методу [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Он позволяет изменить громкость аудио в процентах.

Так изменяются параметры воспроизведения аудио:
1. [Create](#create-audio-frame) или получите аудио‑кадр.
2. Установите новые значения свойств аудио‑кадра, которые нужно изменить.
3. Сохраните изменённый файл PowerPoint.

Этот код на Java демонстрирует операцию, в которой изменяются параметры аудио:
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Получает форму AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Устанавливает режим воспроизведения «по щелчку»
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


Этот пример на Java показывает, как добавить новый аудио‑кадр со встроенным аудио, обрезать его и установить длительности затухания:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Устанавливает начало обрезки в 1.5 секунды
    audioFrame.setTrimFromStart(1500f);
    // Устанавливает конец обрезки в 2 секунды
    audioFrame.setTrimFromEnd(2000f);

    // Устанавливает длительность плавного появления в 200 мс
    audioFrame.setFadeInDuration(200f);
    // Устанавливает длительность плавного исчезновения в 500 мс
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Следующий пример кода демонстрирует, как получить аудио‑кадр со встроенным аудио и установить его громкость на 85 %:
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

Aspose.Slides for Java позволяет извлекать звук, используемый в анимациях переходов слайдов. Например, вы можете извлечь звук, используемый в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на соответствующий слайд через его индекс.
3. Получите доступ к [slideshow transitions](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) для слайда.
4. Извлеките звук в виде байтовых данных.

Этот код на Java показывает, как извлечь аудио, используемое в слайде:
```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Получает нужный слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Получает эффекты переходов слайд-шоу для слайда
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

Да. Добавьте аудио один раз в общую [audio collection] презентации и создайте дополнительные аудио‑кадры, которые ссылаются на этот существующий ресурс. Это исключает дублирование медиа‑данных и позволяет держать размер презентации под контролем.

**Можно ли заменить звук в существующем аудио‑кадре без пересоздания формы?**

Да. Для связанного звука обновите [link path], указав новый файл. Для встроенного звука замените объект [embedded audio] другим из [audio collection] презентации. Форматирование кадра и большинство настроек воспроизведения сохраняются.

**Изменяет ли обрезка исходные аудио‑данные, хранящиеся в презентации?**

Нет. Обрезка изменяет только границы воспроизведения. Исходные байты аудио остаются нетронутыми и доступны через встроенное аудио или [audio collection] презентации.