---
title: Gestionar audio en presentaciones usando Python
linktitle: Marco de audio
type: docs
weight: 10
url: /es/python-java/audio-frame/
keywords:
- audio
- marco de audio
- miniatura
- añadir audio
- propiedades del audio
- opciones de audio
- extraer audio
- Python
- Aspose.Slides
description: "Crear y controlar marcos de audio en Aspose.Slides para Python a través de Java - ejemplos de código para incrustar, recortar, bucle y configurar la reproducción en presentaciones PPT, PPTX y ODP."
---
## **Visión general**

Este artículo explica cómo trabajar con marcos de audio en Aspose.Slides. Muestra cómo añadir audio incrustado a las diapositivas, personalizar la miniatura del marco de audio, configurar opciones de reproducción como volumen, bucle, ocultación, recorte y duraciones de desvanecimiento, y extraer el audio utilizado en las transiciones de la presentación.

## **Crear marcos de audio**

Aspose.Slides for Python a través de Java permite añadir archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como marcos de audio. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
2. Obtenga una referencia a una diapositiva por su índice.
3. Lea el archivo de audio que desea incrustar en la diapositiva.
4. Agregue el marco de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Utilice [setPlayMode](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setPlayMode) y [setVolume](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setVolume) expuestos por el objeto [AudioFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/) .
6. Guarde la presentación modificada.

Este código Python le muestra cómo añadir un marco de audio incrustado a una diapositiva:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)
    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cambiar la miniatura del marco de audio**

Cuando añades un archivo de audio a una presentación, el audio aparece como un marco con una imagen predeterminada estándar (consulta la imagen en la sección inferior). Puedes cambiar la imagen de vista previa del marco de audio por una imagen de tu elección.

Este código Python le muestra cómo cambiar la miniatura o imagen de vista previa de un marco de audio:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cambiar las opciones de reproducción de audio**

Aspose.Slides for Python a través de Java permite cambiar opciones que controlan la reproducción o propiedades del audio. Por ejemplo, puedes ajustar el volumen del audio, hacer que el audio se reproduzca en bucle o incluso ocultar el icono de audio.

El panel **Audio Options** en Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Las **Audio Options** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/) :

- **Start** lista desplegable coincide con el método [setPlayMode](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** coincide con el método [setVolume](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** coincide con el método [setPlayAcrossSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** coincide con el método [setPlayLoopMode](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** coincide con el método [setHideAtShowing](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** coincide con el método [setRewindAudio](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setRewindAudio)

Opciones de **Editing** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/) :

- **Fade In** coincide con el método [setFadeInDuration](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** coincide con el método [setFadeOutDuration](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** coincide con el método [setTrimFromStart](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** el valor equivale a la duración del audio menos el valor establecido por el método [setTrimFromEnd](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setTrimFromEnd)

El **control de volumen** de PowerPoint en el panel de control de audio corresponde al método [setVolumeValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setVolumeValue). Permite cambiar el volumen del audio como porcentaje.

Así es como se cambian las opciones de reproducción de audio:

1. [Create](#create-audio-frames) o obtenga el marco de audio.
2. Establezca nuevos valores para las propiedades del marco de audio que desea ajustar.
3. Guarde el archivo PowerPoint modificado.

Este código Python demuestra una operación en la que se ajustan las opciones de audio:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # Reproducir al hacer clic con bajo volumen, en todas las diapositivas, sin bucle.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Ocultar el marco durante la presentación y rebobinar después de reproducir.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Este ejemplo Python muestra cómo añadir un nuevo marco de audio con audio incrustado, recortarlo y establecer las duraciones de desvanecimiento:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Recortar 1,5 segundos del inicio y 2 segundos del final.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Establecer fade-in a 200 ms y fade-out a 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El siguiente fragmento de código muestra cómo obtener un marco de audio con audio incrustado y establecer su volumen al 85%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Administrar subtítulos de audio**

Aspose.Slides permite añadir subtítulos cerrados a un marco de audio mediante el método [getCaptionTracks](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#getCaptionTracks). Este método devuelve una [CaptionsCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/captionscollection/), que le permite añadir pistas de subtítulos WebVTT, iterar a través de las pistas existentes y eliminarlas cuando sea necesario.

### **Añadir subtítulos de audio**

Utilice el método [getCaptionTracks](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#getCaptionTracks) para adjuntar una o más pistas de subtítulos a un marco de audio. En el siguiente ejemplo, se añade un archivo de audio a una diapositiva y luego se carga una nueva pista de subtítulos desde un archivo `.vtt`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Añadir una nueva pista de subtítulos desde un archivo WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Extraer subtítulos de audio**

Puede iterar a través de las pistas de subtítulos asociadas a un marco de audio y guardarlas como archivos `.vtt`. Cada pista de subtítulos expone sus datos binarios y su identificador único, que pueden usarse al exportar los subtítulos.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Guardar la pista de subtítulos como archivo .vtt.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Eliminar subtítulos de audio**

Para eliminar los subtítulos de un marco de audio, utilice los métodos proporcionados por [CaptionsCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/captionscollection/), como [clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/captionscollection/#remove), o [removeAt](https://reference.aspose.com/slides/es/python-java/aspose.slides/captionscollection/#removeAt). El siguiente ejemplo elimina todas las pistas de subtítulos de un marco de audio.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Extraer audio**

Aspose.Slides for Python a través de Java permite extraer el sonido utilizado en las transiciones de la presentación. Por ejemplo, puede extraer el sonido usado en una diapositiva específica.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargue la presentación que contiene el audio.
2. Obtenga una referencia a la diapositiva correspondiente por su índice.
3. Acceda a las [slideshow transitions](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositiva.
4. Extraiga el sonido como datos de bytes.

Este código en Python le muestra cómo extraer el audio utilizado en una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo reutilizar el mismo recurso de audio en varias diapositivas sin aumentar el tamaño del archivo?**

Sí. Añada el audio una sola vez a la [colección de audio](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getAudios) compartida de la presentación y cree marcos de audio adicionales que hagan referencia a ese recurso existente. Esto evita duplicar los datos multimedia y mantiene el tamaño de la presentación bajo control.

**¿Puedo reemplazar el sonido en un marco de audio existente sin recrear la forma?**

Sí. Para un sonido enlazado, actualice la [link path](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setLinkPathLong) para que apunte al nuevo archivo. Para un sonido incrustado, reemplace el objeto [embedded audio](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/#setEmbeddedAudio) por otro de la [colección de audio](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getAudios) de la presentación. El formato del marco y la mayoría de los ajustes de reproducción permanecen intactos.

**¿El recorte cambia los datos de audio subyacentes almacenados en la presentación?**

No. El recorte solo ajusta los límites de reproducción. Los bytes originales del audio permanecen sin modificar y son accesibles a través del audio incrustado o la colección de audio de la presentación.