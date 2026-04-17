---
title: Gestionar audio en presentaciones con Java
linktitle: Marco de audio
type: docs
weight: 10
url: /es/java/audio-frame/
keywords:
- audio
- marco de audio
- miniatura
- añadir audio
- propiedades de audio
- opciones de audio
- extraer audio
- Java
- Aspose.Slides
description: "Crear y controlar marcos de audio en Aspose.Slides para Java—ejemplos de código para incrustar, recortar, reproducir en bucle y configurar la reproducción en presentaciones PPT, PPTX y ODP."
---
## **Crear marcos de audio**

Aspose.Slides para Java le permite añadir archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como marcos de audio. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Cargue el flujo del archivo de audio que desea incrustar en la diapositiva.
4. Añada el marco de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Establezca [PlayMode](https://reference.aspose.com/slides/es/java/com.aspose.slides/AudioPlayModePreset) y `Volume` expuestos por el objeto [IAudioFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/IAudioFrame).
6. Guarde la presentación modificada.

Este código Java le muestra cómo añadir un marco de audio incrustado a una diapositiva:

```java
// Instancia una clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Carga el archivo de sonido wav en un flujo
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Añade el marco de audio
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Establece el modo de reproducción y el volumen del audio
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Escribe el archivo PowerPoint en el disco
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Cambiar la miniatura del marco de audio**

Cuando añade un archivo de audio a una presentación, el audio aparece como un marco con una imagen predeterminada estándar (ver la imagen en la sección siguiente). Cambie la imagen de vista previa del marco de audio (establezca la imagen que prefiera).

Este código Java le muestra cómo cambiar la miniatura o imagen de vista previa de un marco de audio:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Añade un marco de audio a la diapositiva con una posición y tamaño especificados.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Añade una imagen a los recursos de la presentación.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Establece la imagen para el marco de audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // Guarda la presentación modificada en el disco
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Cambiar opciones de reproducción de audio**

Aspose.Slides para Java le permite cambiar opciones que controlan la reproducción o propiedades de un audio. Por ejemplo, puede ajustar el volumen, reproducir el audio en bucle o incluso ocultar el icono del audio.

El panel **Audio Options** en Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** que corresponden a las propiedades de [AudioFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/AudioFrame) de Aspose.Slides:

- **Start** la lista desplegable coincide con el método [AudioFrame.setPlayMode](https://reference.aspose.com/slides/es/java/com.aspose.slides/audioframe/#setPlayMode-int-)
- **Volume** coincide con el método [AudioFrame.setVolume](https://reference.aspose.com/slides/es/java/com.aspose.slides/audioframe/#setVolume-int-)
- **Play Across Slides** coincide con el método [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)
- **Loop until Stopped** coincide con el método [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/es/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)
- **Hide During Show** coincide con el método [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/es/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)
- **Rewind after Playing** coincide con el método [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/es/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)

PowerPoint **Editing** options que corresponden a las propiedades de [AudioFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/AudioFrame) de Aspose.Slides:

- **Fade In** coincide con el método [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/es/java/com.aspose.slides/audioframe/#setFadeInDuration-float-)
- **Fade Out** coincide con el método [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/es/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-)
- **Trim Audio Start Time** coincide con el método [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/es/java/com.aspose.slides/audioframe/#setTrimFromStart-float-)
- **Trim Audio End Time** el valor equivale a la duración del audio menos el valor del método [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/es/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)

El **control de volumen** de PowerPoint en el panel de control de audio corresponde al método [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Le permite cambiar el volumen del audio como porcentaje.

Así es como se cambian las opciones de reproducción de audio:

1. [Crear](#create-audio-frame) o obtenga el Marco de audio.
2. Establezca nuevos valores para las propiedades del Marco de audio que desea ajustar.
3. Guarde el archivo PowerPoint modificado.

Este código Java demuestra una operación en la que se ajustan las opciones de un audio:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Obtiene la forma AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Establece el modo de reproducción para reproducir al hacer clic
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Establece el volumen a bajo
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Configura el audio para reproducir a través de las diapositivas
    audioFrame.setPlayAcrossSlides(true);

    // Desactiva el bucle para el audio
    audioFrame.setPlayLoopMode(false);

    // Oculta el AudioFrame durante la presentación
    audioFrame.setHideAtShowing(true);

    // Rebobina el audio al inicio después de reproducir
    audioFrame.setRewindAudio(true);

    // Guarda el archivo PowerPoint en el disco
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Este ejemplo Java muestra cómo añadir un nuevo marco de audio con audio incrustado, recortarlo y establecer las duraciones de fundido:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Establece el desplazamiento de recorte de inicio a 1,5 segundos
    // Establece el desplazamiento de recorte final a 2 segundos
    // Establece la duración del fundido de entrada a 200 ms
    // Establece la duración del fundido de salida a 500 ms

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

El siguiente fragmento de código muestra cómo obtener un marco de audio con audio incrustado y establecer su volumen al 85 %:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Obtiene una forma de marco de audio
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Establece el volumen del audio al 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Gestionar subtítulos de audio**

Aspose.Slides le permite añadir subtítulos cerrados a un marco de audio mediante el método [getCaptionTracks](https://reference.aspose.com/slides/es/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Este método devuelve una [ICaptionsCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/), que le permite añadir pistas de subtítulos WebVTT, iterar por las pistas existentes y eliminarlas cuando sea necesario.

**Añadir subtítulos de audio**

Utilice el método [getCaptionTracks](https://reference.aspose.com/slides/es/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) para adjuntar una o más pistas de subtítulos a un marco de audio. En el siguiente ejemplo, se añade un archivo de audio a una diapositiva y, a continuación, se carga una nueva pista de subtítulos desde un archivo `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Añade una nueva pista de subtítulos desde un archivo WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Extraer subtítulos de audio**

Puede iterar por las pistas de subtítulos asociadas a un marco de audio y guardarlas como archivos `.vtt`. Cada pista de subtítulos expone sus datos binarios y su identificador único, que pueden usarse al exportar los subtítulos.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Guardar la pista de subtítulos como un archivo .vtt.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Eliminar subtítulos de audio**

Para eliminar los subtítulos de un marco de audio, utilice los métodos proporcionados por [ICaptionsCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/), como [clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), o [removeAt](https://reference.aspose.com/slides/es/java/com.aspose.slides/icaptionscollection/#removeAt-int-). El siguiente ejemplo elimina todas las pistas de subtítulos de un marco de audio.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Eliminar todas las pistas de subtítulos del marco de audio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extraer audio**

Aspose.Slides para Java le permite extraer el sonido usado en transiciones de presentación. Por ejemplo, puede extraer el sonido usado en una diapositiva específica.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation) y cargue la presentación que contiene el audio.
2. Obtenga la referencia de la diapositiva pertinente mediante su índice.
3. Acceda a las [slideshow transitions](https://reference.aspose.com/slides/es/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) de la diapositiva.
4. Extraiga el sonido en datos de bytes.

Este código Java le muestra cómo extraer el audio usado en una diapositiva:

```java
// Instancia una clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Accede a la diapositiva deseada
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Obtiene los efectos de transición de la presentación para la diapositiva
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Extrae el sonido en un array de bytes
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**¿Puedo reutilizar el mismo recurso de audio en varias diapositivas sin inflar el tamaño del archivo?**

Sí. Añada el audio una sola vez a la [colección de audio](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getAudios--) compartida de la presentación y cree marcos de audio adicionales que hagan referencia a ese recurso existente. Esto evita la duplicación de datos multimedia y mantiene el tamaño de la presentación bajo control.

**¿Puedo reemplazar el sonido de un marco de audio existente sin recrear la forma?**

Sí. Para un sonido vinculado, actualice la [ruta del enlace](https://reference.aspose.com/slides/es/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) para que apunte al nuevo archivo. Para un sonido incrustado, sustitúya el objeto [embedded audio](https://reference.aspose.com/slides/es/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) por otro de la [colección de audio](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getAudios--) de la presentación. El formato del marco y la mayoría de los ajustes de reproducción permanecen intactos.

**¿El recorte modifica los datos de audio subyacentes almacenados en la presentación?**

No. El recorte solo ajusta los límites de reproducción. Los bytes originales del audio permanecen sin modificar y son accesibles a través del audio incrustado o de la colección de audio de la presentación.