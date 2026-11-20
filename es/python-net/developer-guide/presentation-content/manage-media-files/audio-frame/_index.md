---
title: Gestionar marcos de audio en presentaciones con Python
linktitle: Marco de audio
type: docs
weight: 10
url: /es/python-net/audio-frame/
keywords:
- audio
- marco de audio
- miniatura
- añadir audio
- propiedades de audio
- opciones de audio
- extraer audio
- WebVTT
- Python
- Aspose.Slides
description: "Incruste audio en las diapositivas, cambie el ícono de audio, configure la reproducción, gestione subtítulos WebVTT y extraiga los sonidos de transición de diapositivas con Aspose.Slides para Python a través de .NET."
---
## **Visión general**

Un marco de audio le permite reproducir un sonido en una diapositiva. Con Aspose.Slides for Python via .NET, puede incrustar un clip de audio, elegir la imagen que lo representa, ajustar la reproducción y adjuntar subtítulos. También puede obtener un sonido asignado a una transición de diapositiva.

## **Crear marcos de audio**

Utilice [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) para incrustar un clip de audio local en la primera diapositiva. Las dos primeras coordenadas posicionan el marco en la diapositiva, y los dos valores siguientes establecen su ancho y alto, todo en puntos. Este ejemplo establece [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) para iniciar el clip automáticamente y [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) al ajuste de volumen alto.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar la miniatura del marco de audio**

Por defecto, un marco de audio muestra un icono de altavoz. Para mostrar una miniatura personalizada, añada una imagen a la presentación con [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) y asígnela a la propiedad [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) del marco. El ejemplo utiliza un JPEG como miniatura para un clip de audio incrustado.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar opciones de reproducción de audio**

Los controles de **Opciones de audio** de PowerPoint determinan cuándo comienza un clip, cuán fuerte suena y cómo se comporta durante una presentación.

![Controles de Opciones de audio de PowerPoint para un marco de audio](audio_frame_0.png)

| Control de PowerPoint | Propiedad de Aspose.Slides |
| --- | --- |
| Inicio | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Ajuste de volumen | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Reproducción en todas las diapositivas | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Repetir hasta detenerse | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Ocultar durante la presentación | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Retroceder después de reproducir | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Desvanecerse al iniciar | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Desvanecerse al finalizar | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Recortar tiempo de inicio del audio | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Recortar tiempo de final del audio | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Control deslizante de volumen | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

El ejemplo busca el primer marco de audio en la primera diapositiva, establece [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) para iniciar la reproducción al hacer clic, y selecciona el ajuste de volumen bajo. El clip continúa a través de las diapositivas con la repetición desactivada. El icono permanece oculto durante la presentación, y el clip retrocede después de la reproducción.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Para un clip de más de 3,5 segundos, este ejemplo omite los primeros 1,5 segundos y los últimos 2 segundos. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) mide la duración a omitir del final del clip. Para obtener el tiempo de final mostrado en PowerPoint, reste ese desplazamiento de la duración total del clip. El clip recortado se desvanece al iniciar durante 200 milisegundos y se desvanece al finalizar durante 500 milisegundos. Las cuatro propiedades toman valores en milisegundos.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Para establecer el volumen de reproducción a un porcentaje específico, utilice [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). Este ejemplo establece el primer marco de audio en la primera diapositiva al 85 %.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestionar subtítulos de audio**

Cada marco de audio tiene una colección [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/). Úsela para adjuntar subtítulos WebVTT al clip, exportar pistas existentes o eliminarlas.

### **Agregar subtítulos de audio**

El ejemplo incrusta un clip de audio en la primera diapositiva y utiliza [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) para adjuntar una pista WebVTT local. El primer argumento proporciona la etiqueta de la pista, y el segundo identifica el archivo que contiene los subtítulos sincronizados.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Extraer subtítulos de audio**

Este ejemplo exporta cada pista de subtítulos adjunta a un marco de audio en la primera diapositiva. Escribe los [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) de la pista en un archivo WebVTT y utiliza su [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) como nombre de archivo para que cada pista tenga una salida separada.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **Eliminar subtítulos de audio**

Utilice [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) o [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) para eliminar una pista individual. El ejemplo usa [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) para eliminar todos los subtítulos del primer marco de audio en la primera diapositiva, conservando el clip.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Buscar una línea en subtítulos de audio**

Para encontrar una línea en los subtítulos de audio de la primera diapositiva, lea el [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) de cada pista en memoria. En una señal WebVTT de texto plano, la línea de tiempo contiene `-->`, las líneas de subtítulo la siguen y una línea en blanco finaliza la señal. Este ejemplo imprime la etiqueta de la pista y cada línea de subtítulo que contiene “café”.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **Extraer audio**

Una transición de diapositiva puede tener su propio sonido. Para recuperarlo, lea la propiedad [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) de la transición. El ejemplo accede a los [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) del sonido y muestra su tamaño en bytes. Si la primera diapositiva no tiene sonido de transición, muestra un mensaje en su lugar.

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **Preguntas frecuentes**

**¿Puedo reutilizar el mismo clip de audio en varias diapositivas sin duplicarlo?**

Sí. Añada el clip una vez a la [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) de la presentación y pase el mismo objeto de audio a [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) para cada diapositiva.

**¿Puedo reemplazar el sonido en un marco de audio existente?**

Sí. Para un sonido vinculado, actualice [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) para que apunte al archivo de sustitución. Para un sonido incrustado, asigne otro clip de la colección de audio de la presentación a [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/). Ambos enfoques conservan el marco existente.

**¿El recorte modifica los datos de audio almacenados en la presentación?**

No. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) y [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) establecen los límites de reproducción. Todavía puede obtener el clip completo mediante [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/).