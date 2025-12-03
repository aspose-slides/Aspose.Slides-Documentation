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
- agregar audio
- propiedades de audio
- opciones de audio
- extraer audio
- Java
- Aspose.Slides
description: "Crear y controlar marcos de audio en Aspose.Slides para Java—ejemplos de código para incrustar, recortar, reproducir en bucle y configurar la reproducción en presentaciones PPT, PPTX y ODP."
---

## **Crear marcos de audio**

Aspose.Slides for Java le permite agregar archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como marcos de audio. 

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) clase.
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Cargue el flujo del archivo de audio que desea incrustar en la diapositiva.
4. Añada el marco de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Establezca [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) y `Volume` expuestos por el objeto [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame).
6. Guarde la presentación modificada.

Este código Java le muestra cómo agregar un marco de audio incrustado a una diapositiva:
```java
// Instancia una clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Carga el archivo de sonido wav a un flujo
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Añade el marco de audio
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Establece el modo de reproducción y el volumen del audio
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Escribe el archivo PowerPoint en disco
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Cambiar la miniatura del marco de audio**

Cuando agrega un archivo de audio a una presentación, el audio aparece como un marco con una imagen predeterminada estándar (vea la imagen en la sección a continuación). Cambie la imagen de vista previa del marco de audio (establezca su imagen preferida).

Este código Java le muestra cómo cambiar la miniatura o la imagen de vista previa de un marco de audio:
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

    // Sets the image for the audio frame.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Guarda la presentación modificada en disco
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Cambiar las opciones de reproducción de audio**

Aspose.Slides for Java le permite cambiar opciones que controlan la reproducción o las propiedades de un audio. Por ejemplo, puede ajustar el volumen de un audio, configurar el audio para que se reproduzca en bucle o incluso ocultar el ícono de audio.

El panel **Audio Options** en Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opciones de **Audio** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame):

- **Start** lista desplegable coincide con el método [AudioFrame.setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayMode-int-)
- **Volume** coincide con el método [AudioFrame.setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolume-int-)
- **Play Across Slides** coincide con el método [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)
- **Loop until Stopped** coincide con el método [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)
- **Hide During Show** coincide con el método [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)
- **Rewind after Playing** coincide con el método [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)

Opciones de **Edición** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame):

- **Fade In** coincide con el método [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeInDuration-float-)
- **Fade Out** coincide con el método [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-)
- **Trim Audio Start Time** coincide con el método [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromStart-float-)
- **Trim Audio End Time** el valor equivale a la duración del audio menos el valor del método [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)

El control de **Volumen** de PowerPoint en el panel de control de audio corresponde al método [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Le permite cambiar el volumen del audio como un porcentaje.

Así es como cambia las opciones de reproducción de audio:

1. [Crear](#create-audio-frame) o obtenga el Marco de audio.
2. Establezca nuevos valores para las propiedades del Marco de audio que desea ajustar.
3. Guarde el archivo de PowerPoint modificado.

Este código Java muestra una operación en la que se ajustan las opciones de un audio:
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Obtiene la forma AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Establece el modo de reproducción para reproducir al hacer clic
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Establece el volumen a Bajo
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Establece que el audio se reproduzca a través de diapositivas
    audioFrame.setPlayAcrossSlides(true);

    // Desactiva el bucle para el audio
    audioFrame.setPlayLoopMode(false);

    // Oculta el AudioFrame durante la presentación
    audioFrame.setHideAtShowing(true);

    // Retrocede el audio al inicio después de reproducir
    audioFrame.setRewindAudio(true);

    // Guarda el archivo PowerPoint en disco
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Este ejemplo Java muestra cómo agregar un nuevo marco de audio con audio incrustado, recortarlo y establecer las duraciones de fundido:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Establece el desplazamiento inicial del recorte a 1,5 segundos
    audioFrame.setTrimFromStart(1500f);
    // Establece el desplazamiento final del recorte a 2 segundos
    audioFrame.setTrimFromEnd(2000f);

    // Establece la duración de fundido de entrada a 200 ms
    audioFrame.setFadeInDuration(200f);
    // Establece la duración de fundido de salida a 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


El siguiente fragmento de código muestra cómo obtener un marco de audio con audio incrustado y establecer su volumen al 85%:
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


## **Extraer audio**

Aspose.Slides for Java le permite extraer el sonido utilizado en las transiciones de la presentación de diapositivas. Por ejemplo, puede extraer el sonido usado en una diapositiva específica.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) y cargue la presentación que contiene el audio.
2. Obtenga la referencia de la diapositiva correspondiente mediante su índice.
3. Acceda a las [transiciones de presentación](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) de la diapositiva.
4. Extraiga el sonido en datos de bytes.

Este código en Java le muestra cómo extraer el audio usado en una diapositiva:
```java
// Instancia una clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Accede a la diapositiva deseada
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Obtiene los efectos de transición de la presentación para la diapositiva
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Extrae el sonido en una matriz de bytes
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Puedo reutilizar el mismo recurso de audio en varias diapositivas sin inflar el tamaño del archivo?**

Sí. Agregue el audio una sola vez a la [colección de audio](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) compartida de la presentación y cree marcos de audio adicionales que referencien ese recurso existente. Esto evita duplicar los datos multimedia y mantiene el tamaño de la presentación bajo control.

**¿Puedo reemplazar el sonido en un marco de audio existente sin recrear la forma?**

Sí. Para un sonido vinculado, actualice la [ruta del vínculo](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) para que apunte al nuevo archivo. Para un sonido incrustado, reemplace el objeto [audio incrustado](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) con otro de la [colección de audio](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) de la presentación. El formato del marco y la mayoría de la configuración de reproducción permanecen intactos.

**¿El recorte cambia los datos de audio subyacentes almacenados en la presentación?**

No. El recorte solo ajusta los límites de reproducción. Los bytes originales del audio permanecen sin cambios y son accesibles a través del audio incrustado o la colección de audio de la presentación.