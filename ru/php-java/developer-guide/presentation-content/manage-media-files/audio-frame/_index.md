---
title: Управление аудио в презентациях с использованием PHP
linktitle: Аудио‑кадр
type: docs
weight: 10
url: /ru/php-java/audio-frame/
keywords:
- аудио
- аудио‑кадр
- миниатюра
- добавить аудио
- свойства аудио
- параметры аудио
- извлечение аудио
- PHP
- Aspose.Slides
description: "Создание и управление аудио‑кадрами в Aspose.Slides для PHP — примеры кода для встраивания, обрезки, зацикливания и настройки воспроизведения в презентациях PPT, PPTX и ODP."
---

## **Создание аудио‑кадров**

Aspose.Slides for PHP via Java позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды как аудио‑кадры.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который вы хотите встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) и `Volume`, доступные через объект [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame).
6. Сохраните изменённую презентацию.

Этот PHP‑код демонстрирует, как добавить встроенный аудио‑кадр на слайд:
```php
// Создаёт экземпляр класса Presentation, представляющего файл презентации
$pres = new Presentation();
try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Загружает wav звук в поток
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Добавляет аудио‑кадр
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Устанавливает режим воспроизведения и громкость аудио
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Записывает файл PowerPoint на диск
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


## **Изменение миниатюры аудио‑кадра**

Когда вы добавляете аудиофайл в презентацию, он отображается в виде кадра со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить превью‑изображение аудио‑кадра (установить нужное вам изображение).

Этот PHP‑код демонстрирует, как изменить миниатюру или превью‑изображение аудио‑кадра:
```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Добавляет аудио‑кадр на слайд с указанными позицией и размером.
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
	# Устанавливает изображение для аудио‑кадра.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Сохраняет изменённую презентацию на диск
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```


## **Изменение параметров воспроизведения аудио**

Aspose.Slides for PHP via Java позволяет изменять параметры, управляющие воспроизведением аудио или его свойствами. Например, можно отрегулировать громкость аудио, установить воспроизведение в цикле или даже скрыть значок аудио.

Область **Audio Options** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Опции **Audio Options** в PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) :

- **Start** раскрывающийся список соответствует методу [AudioFrame.setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** соответствует методу [AudioFrame.setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** соответствует методу [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** соответствует методу [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** соответствует методу [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** соответствует методу [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setRewindAudio)

Опции **Editing** в PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) :

- **Fade In** соответствует методу [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** соответствует методу [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** соответствует методу [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** значение равно продолжительности аудио минус значение, установленное методом [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) 

Элемент управления **Volume** на аудио‑панели PowerPoint соответствует методу [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Он позволяет менять громкость аудио в процентах.

Вот как изменить параметры воспроизведения аудио:

1. [Создать](#create-audio-frame) или получить Audio Frame.
2. Установите новые значения свойств Audio Frame, которые вы хотите изменить.
3. Сохраните изменённый файл PowerPoint.

Этот PHP‑код демонстрирует операцию, в которой изменяются параметры аудио:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Получает форму AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Устанавливает режим воспроизведения на воспроизведение по щелчку
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Устанавливает громкость на низкую
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Устанавливает воспроизведение аудио на всех слайдах
    $audioFrame->setPlayAcrossSlides(true);
    # Отключает зацикливание аудио
    $audioFrame->setPlayLoopMode(false);
    # Скрывает AudioFrame во время показа слайдов
    $audioFrame->setHideAtShowing(true);
    # Перематывает аудио к началу после воспроизведения
    $audioFrame->setRewindAudio(true);
    # Сохраняет файл PowerPoint на диск
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


Этот пример PHP показывает, как добавить новый аудио‑кадр со встроенным аудио, обрезать его и установить длительности затухания:
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Устанавливает смещение начала обрезки в 1,5 секунды
    $audioFrame->setTrimFromStart(1500);
    // Устанавливает смещение конца обрезки в 2 секунды
    $audioFrame->setTrimFromEnd(2000);

    // Устанавливает длительность fade-in в 200 мс
    $audioFrame->setFadeInDuration(200);
    // Устанавливает длительность fade-out в 500 мс
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```


Следующий пример кода показывает, как получить аудио‑кадр со встроенным аудио и установить его громкость на 85%:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Получает форму аудио‑кадра
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Устанавливает громкость аудио на 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```


## **Извлечение аудио**

Aspose.Slides for PHP via Java позволяет извлекать звук, используемый в переходах слайд‑шоу. Например, можно извлечь звук, применённый к определённому слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Получите доступ к [slideshow transitions](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--) для слайда.
4. Извлеките звук в виде байтовых данных.

Этот код демонстрирует, как извлечь аудио, используемое в слайде:
```php
# Создаёт экземпляр класса Presentation, представляющего файл презентации
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Получает нужный слайд
	$slide = $pres->getSlides()->get_Item(0);
	# Получает эффекты перехода слайд-шоу для слайда
	$transition = $slide->getSlideShowTransition();
	# Извлекает звук в массив байтов
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


## **FAQ**

**Можно ли повторно использовать один и тот же аудио‑ресурс на нескольких слайдах без увеличения размера файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) презентации и создайте дополнительные аудио‑кадры, которые ссылаются на этот существующий ресурс. Это предотвращает дублирование медиа‑данных и позволяет держать размер презентации под контролем.

**Можно ли заменить звук в существующем аудио‑кадре без воссоздания формы?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/), указывающий на новый файл. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) другим из [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) презентации. Форматирование кадра и большинство настроек воспроизведения сохраняются.

**Изменяет ли обрезка исходные аудио‑данные, хранящиеся в презентации?**

Нет. Обрезка изменяет только границы воспроизведения. Исходные байты аудио остаются нетронутыми и доступны через встроенное аудио или [audio collection] презентации.