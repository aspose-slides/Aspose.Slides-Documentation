---
title: Gestionar marcos de audio en presentaciones usando PHP
linktitle: Marco de audio
type: docs
weight: 10
url: /es/php-java/audio-frame/
keywords:
- audio
- marco de audio
- miniatura
- agregar audio
- propiedades de audio
- opciones de audio
- extraer audio
- PHP
- Aspose.Slides
description: "Incruste audio en diapositivas, cambie el ícono de audio, configure la reproducción, gestione subtítulos WebVTT y extraiga sonidos de transición de diapositivas con Aspose.Slides for PHP via Java."
---
## **Visión general**

Un marco de audio le permite reproducir un sonido en una diapositiva. Con Aspose.Slides for PHP via Java, puede incrustar un clip de audio, elegir la imagen que lo representa, ajustar la reproducción y adjuntar subtítulos. También puede recuperar un sonido asignado a una transición de diapositiva.

## **Crear marcos de audio**

Utilice [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) para incrustar un clip de audio local en la primera diapositiva. Las dos primeras coordenadas posicionan el marco en la diapositiva, y los dos valores siguientes establecen su ancho y alto, todos en puntos. Este ejemplo llama a [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) para iniciar el clip automáticamente y llama a [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) para seleccionar el ajuste de volumen alto.

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

## **Cambiar la miniatura del marco de audio**

Por defecto, un marco de audio muestra un ícono de altavoz. Para mostrar una miniatura personalizada, añada una imagen a la presentación con [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) y establézcala en la imagen del marco con [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/). El ejemplo utiliza un JPEG como miniatura para un clip de audio incrustado.

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

## **Cambiar opciones de reproducción de audio**

Los controles de **Audio Options** de PowerPoint determinan cuándo comienza un clip, cuán alto suena y cómo se comporta durante una presentación.

![Controles de Audio Options de PowerPoint para un marco de audio](audio_frame_0.png)

| Control de PowerPoint | Método de Aspose.Slides for PHP via Java |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Volume preset | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Play Across Slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Loop until Stopped | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Hide During Show | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Rewind after Playing | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Trim Audio start time | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Trim Audio end time | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Volume slider | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

El ejemplo encuentra el primer marco de audio en la primera diapositiva, llama a [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) para iniciar la reproducción al hacer clic y selecciona el ajuste de volumen bajo. El clip continúa a través de las diapositivas con el bucle desactivado. El ícono permanece oculto durante la presentación y el clip rebobina después de la reproducción.

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

Para un clip de más de 3,5 segundos, este ejemplo omite los primeros 1,5 segundos y los últimos 2 segundos. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) recibe la duración a omitir del final del clip. Para obtener el tiempo final que muestra PowerPoint, reste ese desplazamiento de la duración total del clip. El clip recortado se desvanece al entrar durante 200 milisegundos y al salir durante 500 milisegundos. Los cuatro métodos aceptan valores en milisegundos.

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

Para establecer el volumen de reproducción a un porcentaje específico, utilice [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Este ejemplo establece el primer marco de audio en la primera diapositiva al 85 %.

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

## **Administrar subtítulos de audio**

Cada marco de audio proporciona acceso a sus pistas de subtítulos mediante [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks). Utilice la colección para adjuntar subtítulos WebVTT al clip, exportar pistas existentes o eliminarlas.

### **Agregar subtítulos de audio**

El ejemplo incrusta un clip de audio en la primera diapositiva y utiliza [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) para adjuntar una pista WebVTT local. El primer argumento proporciona la etiqueta de la pista, y el segundo identifica el archivo que contiene los subtítulos con tiempo.

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

### **Extraer subtítulos de audio**

Este ejemplo exporta cada pista de subtítulos adjunta a un marco de audio en la primera diapositiva. Escribe los bytes devueltos por [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) a un archivo WebVTT y utiliza el identificador devuelto por [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) como nombre de archivo para que cada pista tenga una salida separada.

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

### **Eliminar subtítulos de audio**

Utilice [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) para eliminar una pista individual. El ejemplo usa [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) para eliminar todos los subtítulos del primer marco de audio en la primera diapositiva manteniendo el clip.

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

### **Buscar una línea en los subtítulos de audio**

Para encontrar una línea en los subtítulos de audio en la primera diapositiva, busque el texto devuelto por [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) en memoria. En una señal WebVTT de texto plano, la línea de tiempo contiene `-->`, las líneas de subtítulo la siguen, y una línea en blanco finaliza la señal. Este ejemplo imprime la etiqueta de la pista y cada línea de subtítulo que contiene “café”.

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

## **Extraer audio**

Una transición de diapositiva puede tener su propio sonido. Para recuperarlo, llame a [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) en la transición de diapositiva. El ejemplo accede a los bytes devueltos por [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) e imprime el número de bytes. Si la primera diapositiva no tiene sonido de transición, imprime un mensaje en su lugar.

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

**¿Puedo reutilizar el mismo clip de audio en varias diapositivas sin duplicarlo?**

Sí. Añada el clip una vez a la [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) de la presentación y pase el mismo objeto de audio a [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) para cada diapositiva.

**¿Puedo reemplazar el sonido en un marco de audio existente?**

Sí. Para un sonido enlazado, use [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) para apuntar al archivo de reemplazo. Para un sonido incrustado, seleccione otro clip de la audio collection de la presentación con [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/). Ambos enfoques preservan el marco existente.

**¿El recorte cambia los datos de audio almacenados en la presentación?**

No. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) y [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) establecen los límites de reproducción. Todavía puede recuperar el clip completo mediante [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/).