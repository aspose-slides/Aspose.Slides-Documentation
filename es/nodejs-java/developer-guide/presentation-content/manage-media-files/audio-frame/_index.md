---
title: Gestionar audio en presentaciones usando JavaScript
linktitle: Marco de audio
type: docs
weight: 10
url: /es/nodejs-java/audio-frame/
keywords:
- audio
- marco de audio
- miniatura
- añadir audio
- propiedades de audio
- opciones de audio
- extraer audio
- Node.js
- JavaScript
- Aspose.Slides
description: "Cree y controle marcos de audio en Aspose.Slides para Node.js—ejemplos para incrustar, recortar, reproducir en bucle y configurar la reproducción en presentaciones PPT, PPTX y ODP."
---
## **Crear marcos de audio**

Aspose.Slides para Node.js a través de Java permite añadir archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como marcos de audio.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Cargue el flujo del archivo de audio que desea incrustar en la diapositiva.
4. Añada el marco de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Establezca [PlayMode](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/AudioPlayModePreset) y `Volume` expuestos por el objeto [AudioFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/AudioFrame).
6. Guarde la presentación modificada.

Este código JavaScript le muestra cómo añadir un marco de audio incrustado a una diapositiva:

```javascript
// Instancia una clase Presentation que representa un archivo de presentación
const pres = new aspose.slides.Presentation();
try {
    // Obtiene la primera diapositiva
    const sld = pres.getSlides().get_Item(0);
    // Carga el archivo de sonido wav en un stream
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Añade el marco de audio
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Establece el modo de reproducción y el volumen del audio
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Escribe el archivo PowerPoint en disco
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Cambiar miniatura del marco de audio**

Al añadir un archivo de audio a una presentación, el audio aparece como un marco con una imagen predeterminada estándar (véase la imagen en la sección siguiente). Puede cambiar la imagen de vista previa del marco de audio (establezca su imagen preferida).

Este código JavaScript le muestra cómo cambiar la miniatura o imagen de vista previa de un marco de audio:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Añade un marco de audio a la diapositiva con una posición y tamaño especificados.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Añade una imagen a los recursos de la presentación.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Establece la imagen para el marco de audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Guarda la presentación modificada en disco
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Cambiar opciones de reproducción de audio**

Aspose.Slides para Node.js a través de Java permite cambiar opciones que controlan la reproducción o propiedades de un audio. Por ejemplo, puede ajustar el volumen del audio, establecer que el audio se reproduzca en bucle o incluso ocultar el icono de audio.

El panel **Opciones de audio** en Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opciones de audio de PowerPoint que corresponden a las propiedades de [AudioFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/) de Aspose.Slides:
- **Start** la lista desplegable coincide con el método [AudioFrame.setPlayMode](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** coincide con el método [AudioFrame.setVolume](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** coincide con el método [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** coincide con el método [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** coincide con el método [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** coincide con el método [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#setRewindAudio)


Opciones de **Edición** de PowerPoint que corresponden a las propiedades de [AudioFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/) de Aspose.Slides:

- **Fade In** coincide con el método [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** coincide con el método [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** coincide con el método [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** el valor equivale a la duración del audio menos el valor del método [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

El **control de volumen** de PowerPoint en el panel de control de audio corresponde al método [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Permite cambiar el volumen del audio como porcentaje.

Así es como se cambian las opciones de reproducción de audio:

1. [Crear](#create-audio-frame) o obtenga el marco de audio.
2. Establezca nuevos valores para las propiedades del marco de audio que desea ajustar.
3. Guarde el archivo PowerPoint modificado.

Este código JavaScript demuestra una operación en la que se ajustan las opciones de un audio:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Obtiene la forma AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Establece el modo de reproducción a reproducir al hacer clic
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Establece el volumen a bajo
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Configura el audio para reproducirse a través de diapositivas
    audioFrame.setPlayAcrossSlides(true);
    // Desactiva el bucle para el audio
    audioFrame.setPlayLoopMode(false);
    // Oculta el AudioFrame durante la presentación
    audioFrame.setHideAtShowing(true);
    // Rebobina el audio al inicio después de reproducir
    audioFrame.setRewindAudio(true);
    // Guarda el archivo PowerPoint en disco
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Este ejemplo JavaScript muestra cómo añadir un nuevo marco de audio con audio incrustado, recortarlo y establecer las duraciones de fundido:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Establece el desplazamiento de inicio del recorte a 1,5 segundos
    audioFrame.setTrimFromStart(1500);
    // Establece el desplazamiento de fin del recorte a 2 segundos
    audioFrame.setTrimFromEnd(2000);

    // Establece la duración del fundido de entrada a 200 ms
    audioFrame.setFadeInDuration(200);
    // Establece la duración del fundido de salida a 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

El siguiente fragmento de código muestra cómo obtener un marco de audio con audio incrustado y establecer su volumen al 85%:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Obtiene una forma de marco de audio
    const audioFrame = slide.getShapes().get_Item(0);

    // Establece el volumen de audio al 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Gestionar subtítulos de audio**

Aspose.Slides permite añadir subtítulos cerrados a un marco de audio mediante el método [getCaptionTracks](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Este método devuelve una [CaptionsCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/), que permite añadir pistas de subtítulos WebVTT, iterar sobre las pistas existentes y eliminarlas cuando sea necesario.

**Añadir subtítulos de audio**

Utilice el método [getCaptionTracks](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) para adjuntar una o más pistas de subtítulos a un marco de audio. En el siguiente ejemplo, se añade un archivo de audio a una diapositiva y luego se carga una nueva pista de subtítulos desde un archivo `.vtt`.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Añade una nueva pista de subtítulos desde un archivo WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Extraer subtítulos de audio**

Puede iterar a través de las pistas de subtítulos asociadas a un marco de audio y guardarlas como archivos `.vtt`. Cada pista de subtítulos expone sus datos binarios y su identificador único, que pueden usarse al exportar los subtítulos.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // Guarda la pista de subtítulos como un archivo .vtt.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Eliminar subtítulos de audio**

Para eliminar subtítulos de un marco de audio, utilice los métodos proporcionados por [CaptionsCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/), como [clear](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/#removeAt). El siguiente ejemplo elimina todas las pistas de subtítulos de un marco de audio.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // tipo: aspose.slides.AudioFrame

    // Elimina todas las pistas de subtítulos del marco de audio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extraer audio**

Aspose.Slides para Node.js a través de Java permite extraer el sonido utilizado en las transiciones de la presentación. Por ejemplo, puede extraer el sonido usado en una diapositiva concreta.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) y cargue la presentación que contiene el audio.
2. Obtenga la referencia de la diapositiva pertinente mediante su índice.
3. Acceda a las [transiciones de presentación](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) de la diapositiva.
4. Extraiga el sonido en datos de bytes.

Este código en JavaScript le muestra cómo extraer el audio usado en una diapositiva:

```javascript
// Instancia una clase Presentation que representa un archivo de presentación
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Accede a la diapositiva deseada
    const slide = pres.getSlides().get_Item(0);
    // Obtiene los efectos de transición de la presentación para la diapositiva
    const transition = slide.getSlideShowTransition();
    // Extrae el sonido en un array de bytes
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Preguntas frecuentes**

**¿Puedo reutilizar el mismo recurso de audio en varias diapositivas sin inflar el tamaño del archivo?**

Sí. Añada el audio una vez a la [colección de audio compartida](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getaudios/) de la presentación y cree marcos de audio adicionales que hagan referencia a ese recurso existente. Así se evita duplicar los datos multimedia y se mantiene el tamaño de la presentación bajo control.

**¿Puedo reemplazar el sonido en un marco de audio existente sin recrear la forma?**

Sí. Para un sonido enlazado, actualice la [ruta del enlace](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) para que apunte al nuevo archivo. Para un sonido incrustado, sustituya el objeto [embedded audio](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) por otro de la [colección de audio](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getaudios/) de la presentación. El formato del marco y la mayoría de los ajustes de reproducción permanecen intactos.

**¿El recorte modifica los datos de audio subyacentes almacenados en la presentación?**

No. El recorte solo ajusta los límites de reproducción. Los bytes originales del audio permanecen sin cambios y siguen accesibles a través del audio incrustado o de la colección de audio de la presentación.