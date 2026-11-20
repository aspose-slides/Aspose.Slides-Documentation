---
title: Управление аудиофреймами в презентациях с помощью PHP
linktitle: Аудиофрейм
type: docs
weight: 10
url: /ru/php-java/audio-frame/
keywords:
- аудио
- аудиофрейм
- миниатюра
- добавить аудио
- свойства аудио
- параметры аудио
- извлечь аудио
- PHP
- Aspose.Slides
description: "Вставляйте аудио в слайды, меняйте значок аудио, настраивайте воспроизведение, управляйте субтитрами WebVTT и извлекайте звуки переходов слайдов с помощью Aspose.Slides for PHP via Java."
---
## **Обзор**

Аудиофрейм позволяет воспроизводить звук на слайде. С Aspose.Slides for PHP via Java вы можете вставить аудиоклип, выбрать изображение, представляющее его, настроить воспроизведение и добавить субтитры. Вы также можете получить звук, назначенный переходу слайда.

## **Создание аудиофреймов**

Используйте [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) чтобы вставить локальный аудиоклип на первый слайд. Первые две координаты позиционируют фрейм на слайде, а следующие две задают его ширину и высоту, всё в пунктах. В этом примере вызывается [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) для автоматического запуска клипа и вызывается [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) для выбора громкого предустановления.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setPlayMode(AudioPlayModePreset::Auto);
    $audioFrame->setVolume(AudioVolumeMode::Loud);

    $presentation->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Изменить миниатюру аудиофрейма**

По умолчанию аудиофрейм отображает значок динамика. Чтобы отобразить пользовательскую миниатюру, добавьте изображение в презентацию с помощью [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) и установите его в качестве картинки фрейма с помощью [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/). В примере используется JPEG как миниатюра для вложенного аудиоклипа.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }

    $imageStream = new Java("java.io.FileInputStream", "eagle.jpeg");
    try {
        $thumbnail = $presentation->getImages()->addImage($imageStream);
    } finally {
        $imageStream->close();
    }
    $audioFrame->getPictureFormat()->getPicture()->setImage($thumbnail);

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Изменить параметры воспроизведения аудио**

Элементы управления **Audio Options** в PowerPoint определяют, когда начинается клип, насколько громко он звучит и как он ведёт себя во время показа слайдов.

![Элементы управления Audio Options в PowerPoint для аудиофрейма](audio_frame_0.png)

| Элемент управления PowerPoint | Метод Aspose.Slides for PHP via Java |
| --- | --- |
| Запуск | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Предустановка громкости | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Воспроизводить на всех слайдах | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Зацикливание до остановки | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Скрывать во время показа | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Перемотка после воспроизведения | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Появление | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Исчезновение | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Обрезать начало аудио | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Обрезать конец аудио | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Регулятор громкости | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

В примере находится первый аудиофрейм на первом слайде, вызывается [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) для запуска воспроизведения по щелчку и выбирается предустановка низкой громкости. Клип продолжается на всех слайдах при отключённом зацикливании. Значок остаётся скрытым во время показа, и клип перематывается после воспроизведения.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setPlayAcrossSlides(true);
        $audioFrame->setPlayLoopMode(false);
        $audioFrame->setPlayMode(AudioPlayModePreset::OnClick);
        $audioFrame->setVolume(AudioVolumeMode::Low);
        $audioFrame->setHideAtShowing(true);
        $audioFrame->setRewindAudio(true);

        $presentation->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

Для клипа длительностью более 3,5 секунд этот пример пропускает первые 1,5 секунды и последние 2 секунды. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) принимает длительность, которую нужно опустить в конце клипа. Чтобы получить конечное время, отображаемое в PowerPoint, вычтите это смещение из полной длительности клипа. Обрезанный клип появляется за 200 мс и исчезает за 500 мс. Все четыре метода принимают значения в миллисекундах.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setTrimFromStart(1500);
    $audioFrame->setTrimFromEnd(2000);
    $audioFrame->setFadeInDuration(200);
    $audioFrame->setFadeOutDuration(500);

    $presentation->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Чтобы установить громкость воспроизведения в конкретный процент, используйте [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Этот пример задаёт первой аудиофрейму на первом слайде громкость 85 %.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setVolumeValue(85);
        $presentation->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **Управление аудио‑подписями**

Каждый аудиофрейм предоставляет доступ к своим дорожкам подписей через [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks). Используйте коллекцию, чтобы прикрепить WebVTT‑подписи к клипу, экспортировать существующие дорожки или удалить их.

### **Добавить аудио‑подписи**

В примере встраивается аудиоклип на первый слайд и используется [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) для присоединения локальной дорожки WebVTT. Первый аргумент задаёт метку дорожки, второй указывает файл, содержащий синхронные подписи.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Извлечь аудио‑подписи**

В этом примере экспортируется каждая дорожка подписи, прикреплённая к аудиофрейму на первом слайде. Он записывает байты, возвращённые [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData), в файл WebVTT и использует идентификатор, возвращённый [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId), как имя файла, чтобы каждая дорожка имела отдельный вывод.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $fileName = $track->getCaptionId() . ".vtt";
            $audioCaptions = $track->getBinaryData();
            $output = new Java("java.io.FileOutputStream", $fileName);
            try {
                $output->write($audioCaptions);
            } finally {
                $output->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **Удалить аудио‑подписи**

Используйте [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) или [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) для удаления отдельной дорожки. В примере используется [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) для удаления всех подписей с первого аудиофрейма на первом слайде, сохраняя при этом клип.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->getCaptionTracks()->clear();
        $presentation->save("audio_without_captions.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

### **Найти строку в аудио‑подписях**

Чтобы найти строку в аудио‑подписях на первом слайде, выполните поиск текста, возвращённого [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString), в памяти. В простом текстовом сигнале WebVTT строка времени содержит `-->`, за ней следуют строки подписи, а пустая строка завершает сигнал. Этот пример выводит метку дорожки и каждую строку подписи, содержащую «café».

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $inCue = false;
            $captions = (string) $track->getDataAsString();
            foreach (preg_split('/\R/u', $captions) as $line) {
                if ($line === "") {
                    $inCue = false;
                } elseif (strpos($line, "-->") !== false) {
                    $inCue = true;
                } elseif ($inCue && preg_match('/café/iu', $line)) {
                    echo $track->getLabel() . ": " . $line . "\n";
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Извлечение аудио**

Переход слайда может иметь собственный звук. Чтобы получить его, вызовите [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) у перехода слайда. В примере обращаются к байтам, возвращённым [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/), и выводят количество байт. Если у первого слайда нет звука перехода, выводится сообщение вместо этого.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AudioSlide.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $sound = $slide->getSlideShowTransition()->getSound();
    if (java_is_null($sound)) {
        echo "The first slide has no transition sound.\n";
    } else {
        $audioData = $sound->getBinaryData();
        $array = new JavaClass("java.lang.reflect.Array");
        echo "Transition sound: " . $array->getLength($audioData) . " bytes.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Можно ли использовать один и тот же аудиоклип на нескольких слайдах без его дублирования?**

Да. Добавьте клип один раз в [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) презентации и передайте один и тот же объект аудио в [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) для каждого слайда.

**Можно ли заменить звук в существующем аудиофрейме?**

Да. Для связанного звука используйте [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) чтобы указать файл-заменитель. Для вложенного звука выберите другой клип из аудиоколлекции презентации с помощью [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/). Оба подхода сохраняют существующий фрейм.

**Обрезка изменяет аудиоданные, хранящиеся в презентации?**

Нет. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) и [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) задают границы воспроизведения. Полный клип всё ещё можно получить через [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/).