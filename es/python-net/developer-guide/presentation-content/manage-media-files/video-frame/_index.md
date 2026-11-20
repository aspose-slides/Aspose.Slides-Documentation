---
title: Gestionar fotogramas de vídeo en presentaciones en Python
linktitle: Fotograma de vídeo
type: docs
weight: 10
url: /es/python-net/video-frame/
keywords:
- añadir vídeo
- crear vídeo
- incrustar vídeo
- extraer vídeo
- recuperar vídeo
- fotograma de vídeo
- fuente web
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a agregar y extraer fotogramas de vídeo de forma programática en diapositivas de PowerPoint y OpenDocument usando Aspose.Slides for Python a través de .NET. Guía rápida de pasos."
---
## **Introducción**

Los vídeos pueden ayudar a explicar ideas y a atraer a la audiencia. Aspose.Slides for Python a través de .NET le permite agregar fotogramas de vídeo a las diapositivas, ajustar la configuración de reproducción, gestionar subtítulos y extraer datos de vídeo incrustados.

PowerPoint admite vídeos locales y enlaces a vídeos en línea, como los de YouTube.

Para representar los datos de vídeo y los fotogramas de vídeo, Aspose.Slides proporciona la clase [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/), la clase [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) y otros tipos relevantes.

## **Crear un fotograma de vídeo incrustado**

Si el archivo de vídeo que desea añadir a su diapositiva está almacenado localmente, puede crear un fotograma de vídeo para incrustar el vídeo en su presentación.

Este ejemplo incrusta un vídeo local en la primera diapositiva de una presentación existente y guarda el resultado. Las coordenadas y dimensiones del fotograma están en puntos. El flujo permanece abierto hasta que finaliza el guardado porque [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) lo mantiene bloqueado mientras la presentación lo utiliza.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

También puede pasar una ruta de vídeo local directamente a [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Este ejemplo incrusta el vídeo en la primera diapositiva de una presentación nueva. El vídeo debe permanecer accesible hasta que la presentación se guarde.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Crear un fotograma de vídeo con vídeo de una fuente web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admite vídeos en línea en las presentaciones. Puede crear un fotograma de vídeo que enlaza a un vídeo en línea, como un vídeo de YouTube.

Este ejemplo agrega un enlace de vídeo de YouTube y su miniatura a la primera diapositiva. Reemplace el identificador del vídeo para usar otro vídeo. La configuración [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) solicita reproducción automática. Descargar la miniatura y reproducir el vídeo requieren acceso a Internet. El visor de presentaciones también debe admitir la reproducción de vídeo en línea.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **Reproducir un vídeo en modo pantalla completa**

En una presentación de capacitación, puede reproducir una demostración de software en modo pantalla completa para que la audiencia pueda ver los detalles. Establezca [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) a `True` para habilitar este comportamiento durante la reproducción.

Este ejemplo abre una presentación, encuentra el primer [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) en la primera diapositiva y habilita la reproducción en pantalla completa. La presentación de entrada debe contener al menos una diapositiva con un fotograma de vídeo existente en la primera diapositiva.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

La reproducción en pantalla completa controla cómo se muestra el vídeo. De forma independiente, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) controla si se inicia automáticamente o al hacer clic, y [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) controla si se repite. Para elegir el comportamiento de inicio, establezca el modo de reproducción a [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). El ejemplo conserva la configuración de inicio y bucle existentes.

## **Retroceder un vídeo después de la reproducción**

En una presentación de capacitación, devolver un vídeo de demostración a su comienzo lo deja listo para que el presentador lo reproduzca de nuevo. Establezca [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) a `True` para devolver el vídeo al inicio después de que finalice la reproducción.

Este ejemplo abre una presentación, encuentra el primer [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) en la primera diapositiva y habilita el retroceso. Desactiva el bucle para que la reproducción pueda terminar y establece la reproducción para que comience al hacer clic. La presentación de entrada debe contener al menos una diapositiva con un fotograma de vídeo existente en la primera diapositiva.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

El retroceso devuelve el vídeo a su comienzo sin iniciarlo de nuevo. En cambio, habilitar [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) repite la reproducción automáticamente. Mantenga el bucle desactivado cuando quiera que el vídeo termine y esté listo para reproducirse nuevamente. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) controla de forma independiente el inicio automático o al hacer clic; este ejemplo usa [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) para que el presentador controle cuándo comienza la reproducción. Establezca el modo de reproducción después de la configuración del bucle, como se muestra en el ejemplo. El retroceso funciona de forma independiente de [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Recortar un fotograma de vídeo**

Utilice [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) y [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) para omitir una parte del inicio o del final de un vídeo durante la reproducción. Ambos valores están en milisegundos. Recortar cambia la configuración de reproducción sin modificar los datos de vídeo incrustados.

**Establecer la configuración de recorte**

Este ejemplo incrusta un vídeo local y omite los primeros 2,5 segundos y el último segundo durante la reproducción. Utilice un vídeo de más de 3,5 segundos para que quede un segmento reproducible.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Leer la configuración de recorte**

Este ejemplo imprime los valores de recorte del primer fotograma de vídeo en la primera diapositiva en milisegundos. La presentación debe contener al menos una diapositiva. Si esa diapositiva no tiene fotograma de vídeo, no se imprimirá nada. El ejemplo anterior produce valores de 2500 y 1000.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **Gestionar subtítulos de vídeo**

Aspose.Slides le permite gestionar subtítulos cerrados para los fotogramas de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante la propiedad [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

### **Añadir subtítulos a un fotograma de vídeo**

Este ejemplo incrusta un vídeo local y añade una pista de subtítulos WebVTT etiquetada como English. Las marcas de tiempo de los subtítulos deben coincidir con el vídeo. La presentación guardada incluye tanto el vídeo como sus subtítulos.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

La clase [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) también proporciona una sobrecarga que permite añadir subtítulos desde un flujo.

### **Extraer subtítulos de un fotograma de vídeo**

Este ejemplo guarda todas las pistas de subtítulos de los fotogramas de vídeo en la primera diapositiva como archivos WebVTT separados. Los números secuenciales mantienen los archivos de salida distintos. La consola informa del número de pistas extraídas. La presentación debe contener al menos una diapositiva.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

Cada objeto [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF-8.

### **Eliminar subtítulos de un fotograma de vídeo**

Este ejemplo elimina todos los subtítulos del fotograma de vídeo en la primera posición de forma de la primera diapositiva y guarda el resultado. Se asume que la diapositiva y la forma existen y que la forma es un fotograma de vídeo.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Si necesita eliminar solo una pista de subtítulos, use los métodos [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) o [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) en lugar de [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

### **Buscar subtítulos de vídeo**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) devuelve toda la pista WebVTT, incluyendo su encabezado, líneas de tiempo y texto del subtítulo. Por ejemplo, una pista en inglés en la diapositiva 2 podría contener este cue:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Este ejemplo abre `captioned_media.pptx` y lee los [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) de cada fotograma de vídeo de nivel superior en cada diapositiva. Para cada cue de texto plano, busca la línea de tiempo que contiene `-->` y recopila las líneas de subtítulo hasta la siguiente línea en blanco o el final de la pista. Busca en el texto del subtítulo la palabra “café” sin distinguir mayúsculas y minúsculas e imprime el número de diapositiva, la etiqueta de la pista, la línea de tiempo original y el subtítulo completo para cada coincidencia.

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue

                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)

                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

La pista de muestra produce una coincidencia. “Café” en el encabezado está fuera del texto del subtítulo, y la salida conserva la configuración de tiempo y ambas líneas de subtítulo.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extraer vídeo de una diapositiva**

Además de agregar vídeos a las diapositivas, Aspose.Slides le permite extraer los vídeos incrustados en las presentaciones.

Este ejemplo extrae los vídeos incrustados de cada diapositiva en archivos binarios numerados y separados. Los vídeos vinculados se omiten porque no tienen datos incrustados. La consola imprime el tipo MIME de cada vídeo y el recuento total. La salida usa la extensión genérica `.bin`; cámbiela para que coincida con el tipo de medio informado cuando sea necesario.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de vídeo pueden cambiarse para un fotograma de vídeo?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**¿Afecta la adición de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrusta un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando enlaza a un vídeo en línea y agrega una miniatura, la presentación almacena el enlace y la imagen de vista previa en lugar de los datos del vídeo, por lo que el aumento de tamaño suele ser menor.

**¿Puedo reemplazar el vídeo en un fotograma de vídeo existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido de vídeo](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) dentro del fotograma manteniendo la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) que puede leer y usar, por ejemplo al guardarlo en disco.