---
title: Marco de Audio
type: docs
weight: 10
url: /es/java/audio-frame/
keywords: "Agregar audio, Marco de audio, Propiedades de audio, Extraer audio, Java, Aspose.Slides para Java"
description: "Agregar audio a la presentación de PowerPoint en Java"
---

## **Crear Marco de Audio**
Aspose.Slides para Java te permite agregar archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como marcos de audio.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Carga el flujo del archivo de audio que deseas incrustar en la diapositiva.
4. Agrega el marco de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Establece [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) y `Volume` expuestos por el objeto [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame).
6. Guarda la presentación modificada.

Este código Java muestra cómo agregar un marco de audio incrustado a una diapositiva:

```Java
// Instancia una clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Carga el archivo de sonido wav al flujo
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Agrega el Marco de Audio
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Establece el Modo de Reproducción y el Volumen del Audio
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Escribe el archivo de PowerPoint en el disco
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Cambiar la Miniatura del Marco de Audio**

Cuando agregas un archivo de audio a una presentación, el audio aparece como un marco con una imagen estándar predeterminada (ver la imagen en la sección siguiente). Puedes cambiar la imagen de vista previa del marco de audio (establecer tu imagen preferida).

Este código Java muestra cómo cambiar la miniatura o imagen de vista previa de un marco de audio:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Agrega un marco de audio a la diapositiva con una posición y tamaño especificados.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Agrega una imagen a los recursos de la presentación.
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

## **Cambiar las Opciones de Reproducción de Audio**

Aspose.Slides para Java te permite cambiar las opciones que controlan la reproducción o propiedades de un audio. Por ejemplo, puedes ajustar el volumen de un audio, configurar el audio para que se reproduzca en un bucle, o incluso ocultar el ícono de audio.

El panel de **Opciones de Audio** en Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Las opciones de audio de PowerPoint que corresponden a las propiedades de [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) de Aspose.Slides:
- La lista desplegable **Inicio** de Opciones de Audio coincide con la propiedad [AudioFrame.PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayMode--) 
- Las Opciones de Audio **Volumen** coinciden con la propiedad [AudioFrame.Volume](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getVolume--)
- Las Opciones de Audio **Reproducir entre Diapositivas** coinciden con la propiedad [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayAcrossSlides--)
- Las Opciones de Audio **Repetir hasta Detenerse** coinciden con la propiedad [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayLoopMode--)
- Las Opciones de Audio **Ocultar Durante la Presentación** coinciden con la propiedad [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getHideAtShowing--)
- Las Opciones de Audio **Rebobinar después de Reproducir** coinciden con la propiedad [AudioFrame.RewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getRewindAudio--)

Así es como cambias las opciones de reproducción de audio:

1. [Crear](#create-audio-frame) o obtener el Marco de Audio.
2. Establece nuevos valores para las propiedades del Marco de Audio que deseas ajustar.
3. Guarda el archivo de PowerPoint modificado.

Este código Java demuestra una operación en la que se ajustan las opciones de un audio:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Obtiene la forma AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Establece el modo de reproducción para que se reproduzca al hacer clic
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Establece el volumen a Bajo
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Establece el audio para reproducir entre diapositivas
    audioFrame.setPlayAcrossSlides(true);

    // Desactiva el bucle para el audio
    audioFrame.setPlayLoopMode(false);

    // Oculta el AudioFrame durante la presentación
    audioFrame.setHideAtShowing(true);

    // Rebobina el audio al inicio después de reproducir
    audioFrame.setRewindAudio(true);

    // Guarda el archivo de PowerPoint en el disco
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extraer Audio**

Aspose.Slides para Java te permite extraer el sonido utilizado en las transiciones de diapositivas. Por ejemplo, puedes extraer el sonido utilizado en una diapositiva específica.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) y carga la presentación con transiciones de diapositivas.
2. Accede a la diapositiva deseada.
3. Accede a las [transiciones de presentación](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) para la diapositiva.
4. Extrae el sonido en datos de bytes.

Este código en Java te muestra cómo extraer el audio utilizado en una diapositiva:

```java
// Instancia una clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Accede a la diapositiva deseada
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Obtiene los efectos de transición de presentación para la diapositiva
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Extrae el sonido en un arreglo de bytes
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Longitud: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```