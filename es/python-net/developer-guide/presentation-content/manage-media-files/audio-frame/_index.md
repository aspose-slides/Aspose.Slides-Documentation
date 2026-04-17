---
title: Gestionar audio en presentaciones usando Python
linktitle: Marco de audio
type: docs
weight: 10
url: /es/python-net/audio-frame/
keywords:
- añadir audio
- incrustar audio
- marco de audio
- archivo de audio
- propiedades de audio
- extraer audio
- recuperar audio
- cambiar audio
- opciones de reproducción
- modo de reproducción
- reproducir en todas las diapositivas
- repetir hasta detenerse
- ocultar durante la presentación
- rebobinar después de reproducir
- volumen de audio
- imagen predeterminada
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Añada, extraiga y gestione fácilmente marcos de audio en PPT, PPTX y ODP con Aspose.Slides para Python a través de .NET. Explore ejemplos de código y mejore sus presentaciones hoy."
---
## **Crear marcos de audio**

Aspose.Slides para Python a través de .NET le permite añadir archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como marcos de audio. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Cargue el flujo del archivo de audio que desea incrustar en la diapositiva.
4. Añada el marco de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Establezca [PlayMode](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioplaymodepreset) y `Volume` expuestos por el objeto [IAudioFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/).
6. Guarde la presentación modificada.

Este código Python le muestra cómo añadir un marco de audio incrustado a una diapositiva:

```python
import aspose.slides as slides

# Instanciar una clase de presentación que representa un archivo de presentación
with slides.Presentation() as pres:
    # Obtiene la primera diapositiva
    sld = pres.slides[0]

    # Carga el archivo de sonido wav al flujo
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Añade el marco de audio
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Establece el modo de reproducción y el volumen del audio
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Escribe el archivo PowerPoint en disco
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar la miniatura del marco de audio**

Cuando añade un archivo de audio a una presentación, el audio aparece como un marco con una imagen predeterminada estándar (vea la imagen en la sección siguiente). Puede cambiar la miniatura del marco de audio (establezca la imagen que prefiera).

Este código Python le muestra cómo cambiar la miniatura o la imagen de vista previa de un marco de audio:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Añade un marco de audio a la diapositiva con una posición y tamaño especificados.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Añade una imagen a los recursos de la presentación.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Establece la imagen para el marco de audio.
        audioFrame.picture_format.picture.image = audioImage
        
        #Guarda la presentación modificada en disco
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar opciones de reproducción de audio**

Aspose.Slides para Python a través de .NET le permite cambiar opciones que controlan la reproducción o las propiedades de un audio. Por ejemplo, puede ajustar el volumen del audio, establecer que el audio se reproduzca en bucle o incluso ocultar el icono de audio.

El panel **Audio Options** en Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opciones de **Audio** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/) :

- **Start** lista desplegable coincide con la propiedad [AudioFrame.play_mode](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/play_mode/)
- **Volume** coincide con la propiedad [AudioFrame.volume](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/volume/)
- **Play Across Slides** coincide con la propiedad [AudioFrame.play_across_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/play_across_slides/)
- **Loop until Stopped** coincide con la propiedad [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/play_loop_mode/)
- **Hide During Show** coincide con la propiedad [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/hide_at_showing/)
- **Rewind after Playing** coincide con la propiedad [AudioFrame.rewind_audio](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/rewind_audio/)

Opciones de **Edición** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/) :

- **Fade In** coincide con la propiedad [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/fade_in_duration/)
- **Fade Out** coincide con la propiedad [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/fade_out_duration/)
- **Trim Audio Start Time** coincide con la propiedad [AudioFrame.trim_from_start](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/trim_from_start/)
- **Trim Audio End Time** el valor es igual a la duración del audio menos el valor de la propiedad [AudioFrame.trim_from_end](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/trim_from_end/)

El **control de volumen** de PowerPoint en el panel de control de audio corresponde a la propiedad [AudioFrame.volume_value](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/volume_value/). Le permite cambiar el volumen del audio como un porcentaje.

Así es como se cambian las opciones de reproducción de audio:

1. [Crear](#create-audio-frame) o obtenga el Marco de audio.
2. Establezca nuevos valores para las propiedades del Marco de audio que desea ajustar.
3. Guarde el archivo de PowerPoint modificado.

Este código Python muestra una operación en la que se ajustan las opciones de un audio:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Obtiene la forma AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Establece el modo de reproducción a reproducir al hacer clic
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Establece el volumen a bajo
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Configura el audio para reproducirse en todas las diapositivas
    audioFrame.play_across_slides = True

    # Desactiva el bucle para el audio
    audioFrame.play_loop_mode = False

    # Oculta el AudioFrame durante la presentación
    audioFrame.hide_at_showing = True

    # Rebobina el audio al inicio después de reproducir
    audioFrame.rewind_audio = True

    # Guarda el archivo PowerPoint en disco
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Este ejemplo Python muestra cómo añadir un nuevo marco de audio con audio incrustado, recortarlo y establecer las duraciones de fundido:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Establece el desplazamiento de inicio del recorte a 1.5 segundos
    audio_frame.trim_from_start = 1500.0
    # Establece el desplazamiento final del recorte a 2 segundos
    audio_frame.trim_from_end = 2000.0

    # Establece la duración del fundido de entrada a 200 ms
    audio_frame.fade_in_duration = 200.0
    # Establece la duración del fundido de salida a 500 ms
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

El siguiente fragmento de código muestra cómo obtener un marco de audio con audio incrustado y establecer su volumen al 85%:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Obtiene una forma de marco de audio
    audio_frame = pres.slides[0].shapes[0]

    # Establece el volumen del audio al 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestionar subtítulos de audio**

Aspose.Slides le permite añadir subtítulos cerrados a un marco de audio mediante la propiedad [caption_tracks](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/caption_tracks/). Esta propiedad devuelve una [CaptionsCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/), que le permite añadir pistas de subtítulos WebVTT, iterar sobre las pistas existentes y eliminarlas cuando sea necesario.

**Añadir subtítulos de audio**

Utilice la propiedad [caption_tracks](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/caption_tracks/) para adjuntar una o más pistas de subtítulos a un marco de audio. En el siguiente ejemplo, se añade un archivo de audio a una diapositiva y, a continuación, se carga una nueva pista de subtítulos desde un archivo `.vtt`.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Añade una nueva pista de subtítulos desde un archivo WebVTT.
    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Extraer subtítulos de audio**

Puede iterar a través de las pistas de subtítulos asociadas a un marco de audio y guardarlas como archivos `.vtt`. Cada pista de subtítulos expone sus datos binarios y su identificador único, que pueden usarse al exportar subtítulos.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Guarda la pista de subtítulos como un archivo .vtt.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Eliminar subtítulos de audio**

Para eliminar subtítulos de un marco de audio, utilice los métodos proporcionados por [CaptionsCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/), como [clear](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/remove/), o [remove_at](https://reference.aspose.com/slides/es/python-net/aspose.slides/captionscollection/remove_at/). El siguiente ejemplo elimina todas las pistas de subtítulos de un marco de audio.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # tipo: slides.AudioFrame

    # Elimina todas las pistas de subtítulos del marco de audio.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraer audio**

Aspose.Slides para Python a través de .NET le permite extraer el sonido utilizado en las transiciones de la presentación. Por ejemplo, puede extraer el sonido utilizado en una diapositiva concreta.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y cargue la presentación que contiene el audio.
2. Obtenga la referencia de la diapositiva correspondiente mediante su índice.
3. Acceda a las transiciones de la presentación para la diapositiva.
4. Extraiga el sonido en datos de bytes.

Este código Python le muestra cómo extraer el audio utilizado en una diapositiva:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Accede a la diapositiva deseada
    slide = pres.slides[0]  

    # Obtiene los efectos de transición de la presentación para la diapositiva
    transition = slide.slide_show_transition

    # Extrae el sonido en una matriz de bytes
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **Preguntas frecuentes**

**¿Puedo reutilizar el mismo recurso de audio en varias diapositivas sin inflar el tamaño del archivo?**

Sí. Añada el audio una sola vez a la [colección de audio](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/audios/) compartida de la presentación y cree marcos de audio adicionales que referencien ese recurso existente. Esto evita duplicar los datos multimedia y mantiene el tamaño de la presentación bajo control.

**¿Puedo sustituir el sonido en un marco de audio existente sin volver a crear la forma?**

Sí. Para un sonido vinculado, actualice la [ruta del vínculo](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/link_path_long/) para que apunte al nuevo archivo. Para un sonido incrustado, reemplace el objeto [embedded audio](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/embedded_audio/) por otro de la [colección de audio](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/audios/) de la presentación. El formato del marco y la mayoría de los ajustes de reproducción permanecen intactos.

**¿El recorte modifica los datos de audio subyacentes almacenados en la presentación?**

No. El recorte solo ajusta los límites de reproducción. Los bytes originales del audio permanecen intactos y accesibles a través del audio incrustado o de la colección de audio de la presentación.