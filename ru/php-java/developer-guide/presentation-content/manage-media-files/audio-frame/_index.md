---
title: Аудио Фрейм
type: docs
weight: 10
url: /ru/php-java/audio-frame/
keywords: "Добавить аудио, Аудио фрейм, Свойства аудио, Извлечь аудио, Java, Aspose.Slides для PHP через Java"
description: "Добавить аудио в презентацию PowerPoint"
---

## **Создание Аудио Фрейма**
Aspose.Slides для PHP через Java позволяет вам добавлять аудиофайлы в слайды. Аудиофайлы встраиваются в слайды как аудио фреймы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который вы хотите встроить в слайд.
4. Добавьте встроенный аудио фрейм (содержащий аудиофайл) в слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) и `Volume`, предоставленные объектом [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame).
6. Сохраните измененную презентацию.

Этот код на PHP показывает, как добавить встроенный аудио фрейм в слайд:

```php
// Инициализация класса Presentation, представляющего файл презентации
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Загружает wav аудиофайл в поток
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Добавляет Аудио Фрейм
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Устанавливает Режим Воспроизведения и Громкость Аудио
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Записывает файл PowerPoint на диск
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Изменение Миниатюры Аудио Фрейма**

Когда вы добавляете аудиофайл в презентацию, аудио отображается как фрейм со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить изображение предпросмотра аудио фрейма (установите свое предпочтительное изображение).

Этот код на PHP показывает, как изменить миниатюру или изображение предпросмотра аудио фрейма:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Добавляет аудио фрейм на слайд с заданной позицией и размером.
    $audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    $audioStream->close();
    # Добавляет изображение в ресурсы презентации.
    $picture;
    $image = Images->fromFile("eagle.jpeg");
    try {
      $picture = $presentation->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Устанавливает изображение для аудио фрейма.
    $audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

    # Сохраняет измененную презентацию на диск
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Изменение Опций Воспроизведения Аудио**

Aspose.Slides для PHP через Java позволяет вам изменять опции, которые контролируют воспроизведение или свойства аудио. Например, вы можете отрегулировать громкость аудио, установить аудио на зацикленное воспроизведение или даже скрыть иконку аудио.

Панель **Опции Аудио** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Опции Аудио PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame):
- Выпадающий список **Начало** опций Аудио соответствует свойству [AudioFrame.PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayMode--) 
- Опция **Громкость** Аудио соответствует свойству [AudioFrame.Volume](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getVolume--)
- Опция **Воспроизводить на слайдах** соответствует свойству [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayAcrossSlides--)
- Опция **Зациклить до остановки** соответствует свойству [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayLoopMode--)
- Опция **Скрыть во время показа** соответствует свойству [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getHideAtShowing--)
- Опция **Перемотать после воспроизведения** соответствует свойству [AudioFrame.RewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getRewindAudio--)

Вот как вы можете изменить Опции Воспроизведения Аудио:

1. [Создайте](#create-audio-frame) или получите Аудио Фрейм.
2. Установите новые значения для свойств Аудио Фрейма, которые вы хотите изменить.
3. Сохраните измененный файл PowerPoint.

Этот код на PHP демонстрирует операцию, в которой настройки аудио изменяются:

```php
  $pres = new Presentation("AudioFrameEmbed_out.pptx");
  try {
    # Получает аудио фрейм
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Устанавливает режим воспроизведения на клик
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Устанавливает громкость на Низкую
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Устанавливает воспроизведение аудио на всех слайдах
    $audioFrame->setPlayAcrossSlides(true);
    # Отключает зацикливание аудио
    $audioFrame->setPlayLoopMode(false);
    # Скрывает аудио фрейм во время показа слайдов
    $audioFrame->setHideAtShowing(true);
    # Перематывает аудио в начало после воспроизведения
    $audioFrame->setRewindAudio(true);
    # Сохраняет файл PowerPoint на диск
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Извлечение Аудио**

Aspose.Slides для PHP через Java позволяет вам извлекать звук, используемый в переходах слайдов. Например, вы можете извлечь звук, использованный в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию с переходами слайдов.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите доступ к [переходам слайдов](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--) для слайда.
4. Извлеките звук в виде байтовых данных.

Этот код показывает, как извлечь аудио, использованное в слайде:

```php
  # Инициализация класса Presentation, представляющего файл презентации
  $pres = new Presentation("AudioSlide.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Получает нужный слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Получает эффекты перехода слайдов для слайда
    $transition = $slide->getSlideShowTransition();
    # Извлекает звук в байтовом массиве
    $audio = $transition->getSound()->getBinaryData();
    echo("Длина: " . $Array->getLength($audio));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```