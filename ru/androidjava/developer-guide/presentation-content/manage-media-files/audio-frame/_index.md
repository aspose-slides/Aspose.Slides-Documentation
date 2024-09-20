---
title: Аудио Фрейм
type: docs
weight: 10
url: /androidjava/audio-frame/
keywords: "Добавить аудио, Аудио фрейм, Свойства аудио, Извлечь аудио, Java, Aspose.Slides для Android через Java"
description: "Добавить аудио в презентацию PowerPoint на Java"
---

## **Создание Аудио Фрейма**
Aspose.Slides для Android через Java позволяет добавлять аудиофайлы на слайды. Аудиофайлы встроены в слайды в виде аудиофреймов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс.
3. Загрузите поток аудиофайла, который вы хотите вставить в слайд.
4. Добавьте встроенный аудиофрейм (содержащий аудиофайл) на слайд.
5. Установите [РежимВоспроизведения](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) и `Громкость`, предоставленные объектом [IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame).
6. Сохраните изменённую презентацию.

Этот код на Java показывает, как добавить встроенный аудиофрейм на слайд:

```Java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Загружает звуковой файл wav в поток
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Добавляет аудиофрейм
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

## **Изменение Миниатюры Аудио Фрейма**

Когда вы добавляете аудиофайл в презентацию, аудио отображается как фрейм со стандартным изображением (см. изображение в разделе ниже). Вы можете изменить изображение предпросмотра аудиофрейма (установить свое предпочитаемое изображение).

Этот код на Java показывает, как изменить миниатюру или изображение предварительного просмотра аудиофрейма:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавляет аудиофрейм на слайд с заданным положением и размером.
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

    // Устанавливает изображение для аудиофрейма.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // Сохраняет изменённую презентацию на диск
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Изменение Опций Воспроизведения Аудио**

Aspose.Slides для Android через Java позволяет изменять параметры, управляющие воспроизведением аудио или его свойствами. Например, вы можете настроить громкость аудио, установить зацикливание воспроизведения аудио или даже скрыть иконку аудио.

Панель **Опции Аудио** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Опции аудио PowerPoint, которые соответствуют свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame):
- Выпадающий список **Начало** в Опциях Аудио соответствует свойству [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--)
- Громкость **Опции Аудио** соответствует свойству [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--)
- Опция **Воспроизведение через слайды** соответствует свойству [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--)
- Опция **Зациклить до остановки** соответствует свойству [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--)
- Опция **Скрыть во время показа** соответствует свойству [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--)
- Опция **Перемотать после воспроизведения** соответствует свойству [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--)

Вот как вы изменяете опции воспроизведения аудио:

1. [Создайте](#создание- аудио-фрейма) или получите аудиофрейм.
2. Установите новые значения для свойств аудиофрейма, которые вы хотите настроить.
3. Сохраните измененный файл PowerPoint.

Этот код на Java демонстрирует операцию, в которой параметры аудио настраиваются:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Получает фигуру AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Устанавливает режим воспроизведения на клик
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Устанавливает громкость на Низкий
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Устанавливает воспроизведение через слайды
    audioFrame.setPlayAcrossSlides(true);

    // Отключает зацикливание для аудио
    audioFrame.setPlayLoopMode(false);

    // Скрывает AudioFrame во время показа слайдов
    audioFrame.setHideAtShowing(true);

    // Перематывает аудио на начало после воспроизведения
    audioFrame.setRewindAudio(true);

    // Сохраняет файл PowerPoint на диск
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Извлечение Аудио**

Aspose.Slides для Android через Java позволяет извлекать звук, используемый в переходах слайдов. Например, вы можете извлечь звук, используемый в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и загрузите презентацию с переходами слайдов.
2. Доступ к нужному слайду.
3. Получите [переходы слайдов](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) для слайда.
4. Извлеките звук в виде байтовых данных.

Этот код на Java показывает, как извлечь аудио, используемое на слайде:

```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Получает нужный слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Получает эффекты перехода слайдов для слайда
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Извлекает звук в виде массива байтов
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Длина: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```