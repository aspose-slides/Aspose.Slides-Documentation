---
title: Gestionar marcos de audio en presentaciones con Python
linktitle: Marco de audio
type: docs
weight: 10
url: /es/python-java/audio-frame/
keywords:
- audio
- marco de audio
- miniatura
- añadir audio
- propiedades de audio
- opciones de audio
- extraer audio
- Python
- Aspose.Slides
description: "Incrustar audio en diapositivas, cambiar el ícono de audio, configurar la reproducción, gestionar subtítulos WebVTT y extraer sonidos de transición de diapositivas con Aspose.Slides for Python via Java."
---
## **Descripción general**

Un marco de audio le permite reproducir un sonido en una diapositiva. Con Aspose.Slides for Python via Java, puede incrustar un clip de audio, elegir la imagen que lo representa, ajustar la reproducción y adjuntar subtítulos. También puede recuperar un sonido asignado a una transición de diapositiva.

## **Crear marcos de audio**

Agregue los bytes de `audio.wav` a la colección de audio de la presentación, luego use [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) para incrustar un clip de audio local en la primera diapositiva. Las dos primeras coordenadas posicionan el marco en la diapositiva, y los dos valores siguientes establecen su ancho y alto, todos en puntos. Este ejemplo llama a [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) para iniciar el clip automáticamente y llama a [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) para seleccionar el ajuste de volumen alto.

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

De forma predeterminada, un marco de audio muestra un ícono de altavoz. Para mostrar una miniatura personalizada, agregue una imagen a la presentación con [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) y establézcala en la imagen del marco con [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage). El ejemplo usa un JPEG como miniatura para un clip de audio incrustado.

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

    audio_data = Path("audio.wav").read_bytes()
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

## **Cambiar opciones de reproducción de audio**

Los controles de **Opciones de audio** de PowerPoint determinan cuándo comienza un clip, cuán alto suena y cómo se comporta durante una presentación.

![Controles de Opciones de audio de PowerPoint para un marco de audio](audio_frame_0.png)

| Control de PowerPoint | Aspose.Slides for Python via Java method |
| --- | --- |
| Inicio | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Preajuste de volumen | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Reproducir a través de diapositivas | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Repetir hasta detenerse | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Ocultar durante la presentación | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Rebobinar después de reproducir | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Fundido de entrada | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fundido de salida | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Recortar inicio del audio | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Recortar fin del audio | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Control deslizante de volumen | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

El ejemplo encuentra el primer marco de audio en la primera diapositiva, llama a [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) para iniciar la reproducción con un clic y selecciona el preajuste de volumen bajo. El clip continúa a través de diapositivas con el bucle desactivado. El ícono permanece oculto durante la presentación y el clip se rebobina después de la reproducción.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # Reproducir al hacer clic con bajo volumen, a través de diapositivas, sin bucle.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Ocultar el marco durante la presentación y rebobinar después de reproducir.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

Para un clip de más de 3,5 segundos, este ejemplo omite los primeros 1,5 segundos y los últimos 2 segundos. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) toma la duración a omitir del final del clip. Para obtener el tiempo de final mostrado en PowerPoint, reste ese desplazamiento de la duración total del clip. El clip recortado se desvanece al entrar durante 200 milisegundos y se desvanece al salir durante 500 milisegundos. Los cuatro métodos aceptan valores en milisegundos.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Recortar 1,5 segundos del inicio y 2 segundos del final.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Establecer fundido de entrada a 200 ms y fundido de salida a 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para establecer el volumen de reproducción a un porcentaje específico, use [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). Este ejemplo establece el primer marco de audio en la primera diapositiva al 85 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **Gestionar subtítulos de audio**

Cada marco de audio proporciona acceso a sus pistas de subtítulos mediante [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). Utilice la colección para adjuntar subtítulos WebVTT al clip, exportar pistas existentes o eliminarlas.

### **Agregar subtítulos de audio**

El ejemplo incrusta un clip de audio en la primera diapositiva y usa [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) para adjuntar una pista WebVTT local. El primer argumento proporciona la etiqueta de la pista, y el segundo identifica el archivo que contiene los subtítulos sincronizados.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Añadir una nueva pista de subtítulos desde un archivo WebVTT.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Extraer subtítulos de audio**

Este ejemplo exporta cada pista de subtítulos adjunta a un marco de audio en la primera diapositiva. Escribe los bytes devueltos por [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) en un archivo WebVTT y utiliza el identificador devuelto por [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) como nombre de archivo para que cada pista tenga una salida separada.

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
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Eliminar subtítulos de audio**

Utilice [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) para eliminar una pista individual. El ejemplo usa [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) para eliminar todos los subtítulos del primer marco de audio en la primera diapositiva mientras conserva el clip.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **Buscar una línea en los subtítulos de audio**

Para encontrar una línea en los subtítulos de audio en la primera diapositiva, busque el texto devuelto por [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) en la memoria. En una señal WebVTT de texto plano, la línea de tiempo contiene `-->`, las líneas de subtítulo la siguen, y una línea en blanco finaliza la señal. Este ejemplo imprime la etiqueta de la pista y cada línea de subtítulo que contiene “café”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **Extraer audio**

Una transición de diapositiva puede tener su propio sonido. Para recuperarlo, llame a [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) en la transición de diapositiva. El ejemplo accede a los bytes devueltos por [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) y muestra el número de bytes. Si la primera diapositiva no tiene sonido de transición, muestra un mensaje en su lugar.

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
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo reutilizar el mismo clip de audio en varias diapositivas sin duplicarlo?**

Sí. Agregue el clip una vez a la [colección de audio](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) de la presentación y pase el mismo objeto de audio a [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) para cada diapositiva.

**¿Puedo reemplazar el sonido en un marco de audio existente?**

Sí. Para un sonido vinculado, use [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) para apuntar al archivo de reemplazo. Para un sonido incrustado, seleccione otro clip de la colección de audio de la presentación con [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). Ambos enfoques preservan el marco existente.

**¿El recorte cambia los datos de audio almacenados en la presentación?**

No. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) y [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) establecen los límites de reproducción. Aún puede recuperar el clip completo con [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio).