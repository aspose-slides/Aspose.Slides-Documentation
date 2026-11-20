---
title: Gestionar marcos de audio en presentaciones en Android
linktitle: Marco de audio
type: docs
weight: 10
url: /es/androidjava/audio-frame/
keywords:
- audio
- marco de audio
- miniatura
- añadir audio
- propiedades de audio
- opciones de audio
- extraer audio
- Android
- Java
- Aspose.Slides
description: "Incruste audio en diapositivas, cambie el icono de audio, configure la reproducción, gestione subtítulos WebVTT y extraiga los sonidos de transición de diapositivas con Aspose.Slides para Android vía Java."
---
## **Visión general**

Un marco de audio le permite reproducir un sonido en una diapositiva. Con Aspose.Slides for Android via Java, puede incrustar un clip de audio, elegir la imagen que lo representa, ajustar la reproducción y adjuntar subtítulos. También puede recuperar un sonido asignado a una transición de diapositiva.

## **Crear marcos de audio**

Utilice [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) para incrustar un clip de audio local en la primera diapositiva. Las dos primeras coordenadas posicionan el marco en la diapositiva, y los dos valores siguientes establecen su ancho y alto, todos en puntos. Este ejemplo llama a [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) para iniciar el clip automáticamente y llama a [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) para seleccionar el ajuste de volumen alto.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cambiar la miniatura del marco de audio**

Por defecto, un marco de audio muestra un icono de altavoz. Para mostrar una miniatura personalizada, añada una imagen a la presentación con [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) y establézcala en la imagen del marco con [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). El ejemplo utiliza un JPEG como miniatura para un clip de audio incrustado.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cambiar las opciones de reproducción de audio**

Los controles de **Opciones de audio** de PowerPoint determinan cuándo comienza un clip, cuán alto suena y cómo se comporta durante una presentación.

![Controles de Opciones de audio de PowerPoint para un marco de audio](audio_frame_0.png)

| Control de PowerPoint | Método de Aspose.Slides for Android via Java |
| --- | --- |
| Iniciar | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Ajuste de volumen | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Reproducir a través de diapositivas | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Repetir hasta detenerse | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Ocultar durante la presentación | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Rebobinar después de reproducir | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Fundido de entrada | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Fundido de salida | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Recortar inicio del audio | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Recortar fin del audio | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Control deslizante de volumen | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

El ejemplo encuentra el primer marco de audio en la primera diapositiva, llama a [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) para iniciar la reproducción al hacer clic y selecciona el ajuste de volumen bajo. El clip continúa a través de diapositivas con la repetición desactivada. El icono permanece oculto durante la presentación y el clip se rebobina después de la reproducción.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Para un clip de más de 3,5 segundos, este ejemplo omite los primeros 1,5 segundos y los últimos 2 segundos. [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) recibe la duración a omitir del final del clip. Para obtener el tiempo final mostrado en PowerPoint, reste ese desplazamiento de la duración total del clip. El clip recortado se funde de entrada en 200 milisegundos y se funde de salida en 500 milisegundos. Los cuatro métodos aceptan valores en milisegundos.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para establecer el volumen de reproducción a un porcentaje específico, utilice [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Este ejemplo establece el primer marco de audio en la primera diapositiva al 85 %.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Gestionar subtítulos de audio**

Cada marco de audio proporciona acceso a sus pistas de subtítulos mediante [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Utilice la colección para adjuntar subtítulos WebVTT al clip, exportar pistas existentes o eliminarlas.

### **Agregar subtítulos de audio**

El ejemplo incrusta un clip de audio en la primera diapositiva y utiliza [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) para adjuntar una pista WebVTT local. El primer argumento proporciona la etiqueta de la pista y el segundo identifica el archivo que contiene los subtítulos cronometrados.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Extraer subtítulos de audio**

Este ejemplo exporta cada pista de subtítulos adjunta a un marco de audio en la primera diapositiva. Escribe los bytes devueltos por [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--) en un archivo WebVTT y utiliza el identificador devuelto por [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--) como nombre de archivo para que cada pista tenga una salida separada.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            try (FileOutputStream output = new FileOutputStream(track.getCaptionId() + ".vtt")) {
                output.write(track.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **Eliminar subtítulos de audio**

Utilice [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) para eliminar una pista individual. El ejemplo utiliza [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--) para eliminar todos los subtítulos del primer marco de audio en la primera diapositiva manteniendo el clip.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Buscar una línea en los subtítulos de audio**

Para encontrar una línea en los subtítulos de audio de la primera diapositiva, busque el texto devuelto por [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) en memoria. En una señal WebVTT de texto plano, la línea de tiempo contiene `-->`, las líneas de subtítulo la siguen y una línea en blanco finaliza la señal. Este ejemplo muestra la etiqueta de la pista y cada línea de subtítulo que contiene "café".

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\r\\n|\\r|\\n")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extraer audio**

Una transición de diapositiva puede tener su propio sonido. Para recuperarlo, llame a [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--) en la transición de diapositiva. El ejemplo accede a los bytes devueltos por [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) y muestra el número de bytes. Si la primera diapositiva no tiene sonido de transición, muestra un mensaje en su lugar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo reutilizar el mismo clip de audio en varias diapositivas sin duplicarlo?**

Sí. Añada el clip una vez a la [colección de audio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) de la presentación y pase el mismo objeto de audio a [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) para cada diapositiva.

**¿Puedo reemplazar el sonido en un marco de audio existente?**

Sí. Para un sonido enlazado, utilice [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) para apuntar al archivo de reemplazo. Para un sonido incrustado, seleccione otro clip de la [colección de audio] de la presentación con [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). Ambos enfoques conservan el marco existente.

**¿El recorte modifica los datos de audio almacenados en la presentación?**

No. [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) y [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) establecen los límites de reproducción. aún puede recuperar el clip completo mediante [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).