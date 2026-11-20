---
title: Gestionar marcos de vídeo en presentaciones en .NET
linktitle: Marco de vídeo
type: docs
weight: 10
url: /es/net/video-frame/
keywords:
- añadir video
- crear video
- incrustar video
- extraer video
- recuperar video
- marco de video
- origen web
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a añadir y extraer marcos de vídeo de forma programática en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para .NET. Guía rápida paso a paso."
---
## **Introducción**

Los videos pueden ayudar a explicar ideas y captar la atención de la audiencia. Aspose.Slides for .NET le permite añadir marcos de video a diapositivas, ajustar la configuración de reproducción, gestionar subtítulos y extraer datos de video incrustados.

PowerPoint admite videos locales y enlaces a videos en línea, como videos de YouTube.

Para representar datos de video y marcos de video, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/), la interfaz [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) y otros tipos relevantes.

## **Crear un Marco de Video incrustado**

Si el archivo de video que desea añadir a su diapositiva está almacenado localmente, puede crear un marco de video para incrustar el video en su presentación.

Este ejemplo incrusta un video local en la primera diapositiva de una presentación existente y guarda el resultado. Las coordenadas y dimensiones del marco están en puntos. El flujo permanece abierto hasta que se completa el guardado porque [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) lo mantiene bloqueado mientras la presentación lo utiliza.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

También puede pasar una ruta de video local directamente a [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Este ejemplo incrusta el video en la primera diapositiva de una nueva presentación. El video debe permanecer accesible hasta que la presentación se guarde.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Establecer el Volumen del Video con Precisión**

En Aspose.Slides for .NET 26.11 o posterior, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) establece un porcentaje de punto flotante de 0 a 100. Úselo cuando los valores predefinidos de [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) sean demasiado gruesos. Por ejemplo, `75.5f` solicita un volumen del 75,5%.

Este ejemplo requiere [Aspose.Slides for .NET](/slides/es/net/installation/) 26.11 o posterior y un `video.mp4` local. Incrusta el video, inicializa explícitamente la reproducción, guarda la presentación y lee de nuevo el porcentaje almacenado.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

Valide la entrada usted mismo; no confíe en que el setter rechace valores fuera del rango documentado. Los valores predefinidos Bajo, Medio y Alto corresponden a 20, 50 y 80 en la versión 26.11. Establecer un predefinido puede sustituir un porcentaje anterior, por lo que asigne el porcentaje al final cuando necesite un valor exacto. Utilice [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) para la configuración explícita de silencio; un cero numérico y el enum predefinido no son estados intercambiables.

Establezca explícitamente [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) al configurar también un video enlazado, y mantenga su archivo multimedia disponible para el espectador. Guardar y volver a abrir verifica la configuración almacenada; la reproducción real y el nivel de volumen dependen del reproductor de presentaciones y sus ajustes de audio.

## **Crear un Marco de Video con Video de una Fuente Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admite videos en línea en las presentaciones. Puede crear un marco de video que enlace a un video en línea, como un video de YouTube.

Este ejemplo añade un enlace y una miniatura de video de YouTube a la primera diapositiva. Reemplace el identificador del video para usar otro video. La configuración [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) solicita la reproducción automática. Descargar la miniatura y reproducir el video requieren acceso a internet. El visor de presentaciones también debe admitir la reproducción de videos en línea.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Reproducir un Video en Modo Pantalla Completa**

En una presentación de formación, puede reproducir una demostración de software en modo pantalla completa para que la audiencia vea los detalles. Establezca [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) a `true` para habilitar este comportamiento durante la reproducción.

Este ejemplo abre una presentación, encuentra el primer [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) en la primera diapositiva y habilita la reproducción en pantalla completa. La presentación de entrada debe contener al menos una diapositiva con un marco de video existente en la primera diapositiva.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

La reproducción en pantalla completa controla cómo se muestra el video. De forma independiente, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controla si comienza automáticamente o al hacer clic, y [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) controla si se repite. Para elegir el comportamiento de inicio, establezca el modo de reproducción a [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). El ejemplo conserva los ajustes de inicio y bucle existentes.

## **Retroceder un Video Después de la Reproducción**

En una presentación de formación, volver al inicio un video de demostración lo deja listo para que el presentador lo reproduzca de nuevo. Establezca [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) a `true` para devolver el video al principio tras finalizar la reproducción.

Este ejemplo abre una presentación, encuentra el primer [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) en la primera diapositiva y habilita el retroceso. Desactiva el bucle para que la reproducción pueda terminar y establece la reproducción para iniciar al hacer clic. La presentación de entrada debe contener al menos una diapositiva con un marco de video existente en la primera diapositiva.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Retroceder devuelve el video al principio sin iniciarlo de nuevo. En cambio, habilitar [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) repite la reproducción automáticamente. Mantenga el bucle desactivado cuando desee que el video termine y quede listo para reproducirse otra vez. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controla de forma independiente el inicio automático o al hacer clic; este ejemplo usa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) para que el presentador controle cuándo comienza la reproducción. Establezca el modo de reproducción después del ajuste del bucle, como se muestra en el ejemplo. El retroceso funciona de forma independiente de [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Recortar un Marco de Video**

Utilice [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) y [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) para omitir parte del inicio o del final de un video durante la reproducción. Ambos valores se expresan en milisegundos. Recortar modifica la configuración de reproducción sin alterar los datos del video incrustado.

**Establecer los Ajustes de Recorte**

Este ejemplo incrusta un video local y omite los primeros 2,5 segundos y el último segundo durante la reproducción. Utilice un video de más de 3,5 segundos para que quede un segmento reproducible.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Leer los Ajustes de Recorte**

Este ejemplo muestra los valores de recorte del primer marco de video en la primera diapositiva, en milisegundos. La presentación debe contener al menos una diapositiva. Si esa diapositiva no tiene marco de video, no se muestra nada. El ejemplo anterior produce valores de 2500 y 1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Gestionar los Subtítulos de Video**

Aspose.Slides le permite gestionar los subtítulos cerrados para los marcos de video en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante la propiedad [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

### **Añadir Subtítulos a un Marco de Video**

Este ejemplo incrusta un video local y añade una pista de subtítulos WebVTT etiquetada como English. Las marcas de tiempo de los subtítulos deben coincidir con el video. La presentación guardada incluye tanto el video como sus subtítulos.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) también ofrece una sobrecarga que permite añadir subtítulos desde un flujo.

### **Extraer Subtítulos de un Marco de Video**

Este ejemplo guarda todas las pistas de subtítulos de los marcos de video en la primera diapositiva como archivos WebVTT separados. Los números secuenciales mantienen los archivos de salida distintos. La consola informa del número de pistas extraídas. La presentación debe contener al menos una diapositiva.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF-8.

### **Eliminar Subtítulos de un Marco de Video**

Este ejemplo elimina todos los subtítulos del marco de video ubicado en la primera posición de forma de la primera diapositiva y guarda el resultado. Se asume que la diapositiva y la forma existen y que la forma es un marco de video.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Si necesita eliminar solo una pista de subtítulos, use los métodos [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) en lugar de [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

### **Buscar Subtítulos de Video**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) devuelve la pista completa de WebVTT, incluyendo su encabezado, líneas de tiempo y texto del subtítulo. Para encontrar una frase pronunciada y su marca de tiempo, lea las cues en memoria. Por ejemplo, una pista en inglés en la diapositiva 2 podría contener el siguiente texto:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

El ejemplo recorre cada diapositiva y lee las pistas de sus marcos de video de nivel superior mediante [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). En una cue de texto plano, la línea de tiempo contiene `-->` y una línea en blanco finaliza la cue. Cuando el texto del subtítulo contiene “café”, el ejemplo muestra el número de diapositiva, la etiqueta de la pista, la línea de tiempo original y el subtítulo completo.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

Buscar “café” produce una coincidencia para la pista de ejemplo. El encabezado y la configuración de tiempo están fuera del texto de la cue.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extraer Video de una Diapositiva**

Además de añadir videos a diapositivas, Aspose.Slides permite extraer videos incrustados en presentaciones.

Este ejemplo extrae los videos incrustados de cada diapositiva en archivos binarios numerados y separados. Los videos enlazados se omiten porque no poseen datos incrustados. La consola muestra el tipo MIME de cada video y el recuento total. La salida utiliza la extensión genérica `.bin`; cámbiela para que coincida con el tipo de medio informado cuando sea necesario.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de video se pueden modificar en un marco de video?**

Puede controlar el [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automático o al hacer clic) y el [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**¿Añadir un video afecta al tamaño del archivo PPTX?**

Sí. Cuando incrusta un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando enlaza a un video en línea y añade una miniatura, la presentación almacena el enlace y la imagen de vista previa en lugar de los datos del video, de modo que el aumento de tamaño suele ser menor.

**¿Puedo reemplazar el video en un marco de video existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) dentro del marco manteniendo la geometría de la forma; este es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) que puede leer y utilizar, por ejemplo al guardarlo en disco.