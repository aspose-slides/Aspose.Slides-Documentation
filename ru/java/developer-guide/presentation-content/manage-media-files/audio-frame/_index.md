---
title: Аудио рамка
type: docs
weight: 10
url: /java/audio-frame/
keywords: "Добавить аудио, Аудио рамка, Свойства аудио, Извлечь аудио, Java, Aspose.Slides для Java"
description: "Добавить аудио в презентацию PowerPoint на Java"
---

## **Создание аудио рамки**
Aspose.Slides для Java позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды в виде аудио рамок.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который вы хотите встроить в слайд.
4. Добавьте встроенную аудио рамку (с аудиофайлом) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) и `Volume`, которые предоставляет объект [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame).
6. Сохраните измененную презентацию.

Этот код на Java показывает, как добавить встроенную аудио рамку на слайд:

```Java
// Создает экземпляр класса Presentation, представляющий файл презентации
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Загружает файл звука wav в поток
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Добавляет аудио рамку
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

## **Изменение миниатюры аудио рамки**

Когда вы добавляете аудиофайл в презентацию, аудио отображается как рамка со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить изображение предпросмотра аудиорамы (установить ваше предпочтительное изображение).

Этот код на Java показывает, как изменить миниатюру или изображение предпросмотра аудио рамки:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавляет аудио рамку на слайд с заданным положением и размером.
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

    // Устанавливает изображение для аудио рамки.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // Сохраняет измененную презентацию на диск
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Изменение параметров воспроизведения аудио**

Aspose.Slides для Java позволяет вам изменять параметры, которые управляют воспроизведением аудио или его свойствами. Например, вы можете отрегулировать громкость аудио, установить его для зацикливания или даже скрыть значок аудио.

Панель **Опции аудио** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Опции аудио PowerPoint, которые соответствуют свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame):
- Выпадающий список **Старт** в Опциях аудио соответствует свойству [AudioFrame.PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayMode--)
- **Громкость** параметров аудио соответствует свойству [AudioFrame.Volume](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getVolume--)
- **Воспроизводить на всех слайдах** соответствует свойству [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayAcrossSlides--)
- **Зацикливать до остановки** соответствует свойству [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayLoopMode--)
- **Скрыть во время показа** соответствует свойству [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getHideAtShowing--)
- **Перемотать после воспроизведения** соответствует свойству [AudioFrame.RewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getRewindAudio--)

Вот как вы можете изменить параметры воспроизведения аудио:

1. [Создайте](#create-audio-frame) или получите аудио рамку.
2. Установите новые значения для свойств аудио рамки, которые вы хотите отрегулировать.
3. Сохраните измененный файл PowerPoint.

Этот код на Java демонстрирует операцию, в которой параметры аудио настраиваются:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Получает объект AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Устанавливает режим воспроизведения на воспроизведение по щелчку
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Устанавливает громкость на низкую
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Устанавливает аудио для воспроизведения на всех слайдах
    audioFrame.setPlayAcrossSlides(true);

    // Отключает зацикливание для аудио
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

## **Извлечение аудио**

Aspose.Slides для Java позволяет вам извлекать звук, используемый в переходах слайдов. Например, вы можете извлечь звук, используемый на определенном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) и загрузите презентацию с переходами слайдов.
2. Получите дополнительную ссылку на нужный слайд через его индекс.
3. Получите доступ к [переходам слайдов](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) для слайда.
4. Извлеките звук в байтовых данных.

Этот код на Java показывает, как извлечь аудио, использованное на слайде:

```java
// Создает экземпляр класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Получает нужный слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Получает эффекты перехода слайдов для слайда
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Извлекает звук в массиве байтов
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Длина: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```