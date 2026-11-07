---
title: Gestionar fotogramas de video en presentaciones en .NET
linktitle: Fotograma de video
type: docs
weight: 10
url: /es/net/video-frame/
keywords:
- agregar video
- crear video
- incrustar video
- extraer video
- recuperar video
- fotograma de video
- fuente web
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a añadir y extraer fotogramas de video de forma programática en diapositivas de PowerPoint y OpenDocument usando Aspose.Slides para .NET. Guía rápida paso a paso."
---
## **Introducción**

Los videos pueden ayudar a explicar ideas y atraer a la audiencia. Aspose.Slides for .NET le permite agregar fotogramas de video a las diapositivas, ajustar la configuración de reproducción, gestionar subtítulos y extraer datos de video incrustados.

PowerPoint admite videos locales y enlaces a videos en línea, como videos de YouTube.

Para representar datos de video y fotogramas de video, Aspose.Slides proporciona la [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) interfaz, la [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) interfaz y otros tipos relevantes.

## **Crear un fotograma de video incrustado**

Si el archivo de video que desea agregar a su diapositiva está almacenado localmente, puede crear un fotograma de video para incrustar el video en su presentación.

Este ejemplo incrusta un video local en la primera diapositiva de una presentación existente y guarda el resultado. Las coordenadas y dimensiones del fotograma están en puntos. El flujo permanece abierto hasta que finaliza el guardado porque [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) lo mantiene bloqueado mientras la presentación lo utiliza.

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

También puede pasar una ruta de video local directamente a [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Este ejemplo incrusta el video en la primera diapositiva de una presentación nueva. El video debe permanecer accesible hasta que la presentación se guarde.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Establecer el volumen del video con precisión**

En Aspose.Slides for .NET 26.11 o posterior, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) establece un porcentaje de punto flotante del 0 al 100. Úselo cuando los ajustes predefinidos de [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) son demasiado gruesos. Por ejemplo, `75.5f` solicita un volumen del 75.5 %.

Este ejemplo requiere [Aspose.Slides for .NET](/slides/es/net/installation/) 26.11 o posterior y un `video.mp4` local. Incrusta el video, inicializa la reproducción explícitamente, guarda la presentación y lee de nuevo el porcentaje almacenado.

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

Valide la entrada usted mismo; no confíe en que el setter rechace valores fuera del rango documentado. Los ajustes predefinidos Bajo, Medio y Alto corresponden a 20, 50 y 80 en la versión 26.11. Establecer un ajuste predefinido puede reemplazar un porcentaje anterior, por lo que asigne el porcentaje al final cuando necesite un valor exacto. Use [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) para la configuración explícita de silencio; un cero numérico y el enum predefinido no son estados intercambiables.

Establezca explícitamente [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) al configurar también un video vinculado, y mantenga su archivo multimedia disponible para el espectador. Guardar y volver a abrir verifica la configuración almacenada; la reproducción real y el volumen dependen del reproductor de la presentación y de sus ajustes de audio.

## **Crear un fotograma de video con video de una fuente web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admite videos en línea en las presentaciones. Puede crear un fotograma de video que enlace a un video en línea, como un video de YouTube.

Este ejemplo agrega un enlace y una miniatura de video de YouTube a la primera diapositiva. Reemplace el identificador del video para usar otro video. La configuración [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) solicita reproducción automática. Descargar la miniatura y reproducir el video requieren acceso a Internet. El visor de la presentación también debe admitir la reproducción de video en línea.

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

## **Reproducir un video en modo pantalla completa**

En una presentación de capacitación, puede reproducir una demostración de software en modo pantalla completa para que la audiencia vea los detalles. Establezca [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) en `true` para habilitar este comportamiento durante la reproducción.

Este ejemplo abre una presentación, busca el primer [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) en la primera diapositiva y habilita la reproducción en pantalla completa. La presentación de entrada debe contener al menos una diapositiva con un fotograma de video existente en la primera diapositiva.

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

La reproducción en pantalla completa controla cómo se muestra el video. De forma independiente, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controla si se inicia automáticamente o al hacer clic, y [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) controla si se repite. Para elegir el comportamiento de inicio, establezca el modo de reproducción a [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). El ejemplo conserva los ajustes de inicio y bucle existentes.

## **Retroceder un video después de la reproducción**

En una presentación de capacitación, devolver un video de demostración a su comienzo lo deja listo para que el presentador lo reproduzca de nuevo. Establezca [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) en `true` para devolver el video al principio después de que la reproducción finalice.

Este ejemplo abre una presentación, busca el primer [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) en la primera diapositiva y habilita el rebobinado. Desactiva el bucle para que la reproducción pueda terminar y configura la reproducción para iniciar al hacer clic. La presentación de entrada debe contener al menos una diapositiva con un fotograma de video existente en la primera diapositiva.

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

El rebobinado devuelve el video a su comienzo sin iniciarlo de nuevo. En contraste, habilitar [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) repite la reproducción automáticamente. Mantenga el bucle desactivado cuando quiera que el video termine y quede listo para reproducirse de nuevo. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controla de forma independiente el inicio automático o al hacer clic; este ejemplo usa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) para que el presentador controle cuándo comienza la reproducción. Establezca el modo de reproducción después del ajuste de bucle, como se muestra en el ejemplo. El rebobinado funciona de forma independiente de [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Recortar un fotograma de video**

Utilice [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) y [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) para omitir parte del inicio o final de un video durante la reproducción. Ambos valores están en milisegundos. Recortar cambia la configuración de reproducción sin modificar los datos del video incrustado.

**Establecer ajustes de recorte**

Este ejemplo incrusta un video local y omite los primeros 2,5 segundos y el último segundo durante la reproducción. Use un video de más de 3,5 segundos para que quede un segmento reproducible.

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

**Leer ajustes de recorte**

Este ejemplo muestra los valores de recorte del primer fotograma de video en la primera diapositiva en milisegundos. La presentación debe contener al menos una diapositiva. Si esa diapositiva no tiene fotograma de video, no se muestra nada. El ejemplo anterior produce valores de 2500 y 1000.

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

## **Gestionar subtítulos de video**

Aspose.Slides le permite gestionar subtítulos cerrados para los fotogramas de video en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante la propiedad [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**Agregar subtítulos a un fotograma de video**

Este ejemplo incrusta un video local y agrega una pista de subtítulos WebVTT etiquetada como English. Las marcas de tiempo de los subtítulos deben coincidir con el video. La presentación guardada incluye tanto el video como sus subtítulos.

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

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) también proporciona una sobrecarga que le permite agregar subtítulos desde un flujo.

**Extraer subtítulos de un fotograma de video**

Este ejemplo guarda todas las pistas de subtítulos de los fotogramas de video en la primera diapositiva como archivos WebVTT separados. Los números secuenciales mantienen los archivos de salida distintos. La consola informa el número de pistas extraídas. La presentación debe contener al menos una diapositiva.

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

**Eliminar subtítulos de un fotograma de video**

Este ejemplo elimina todos los subtítulos del fotograma de video en la posición de la primera forma de la primera diapositiva y guarda el resultado. Se asume que la diapositiva y la forma existen y que la forma es un fotograma de video.

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

## **Extraer video de una diapositiva**

Además de agregar videos a las diapositivas, Aspose.Slides permite extraer videos incrustados en presentaciones.

Este ejemplo extrae los videos incrustados de cada diapositiva en archivos binarios separados y numerados. Los videos vinculados se omiten porque no tienen datos incrustados. La consola muestra el tipo MIME de cada video y el recuento total. La salida usa la extensión genérica `.bin`; cámbiela para que coincida con el tipo de medio informado cuando sea necesario.

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

**¿Qué parámetros de reproducción de video se pueden cambiar para un fotograma de video?**

Puede controlar el [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automático o al hacer clic) y el [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**¿Afecta la adición de un video al tamaño del archivo PPTX?**

Sí. Cuando incrusta un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece proporcionalmente al tamaño del archivo. Cuando enlaza a un video en línea y agrega una miniatura, la presentación almacena el enlace y la imagen de vista previa en lugar de los datos del video, por lo que el aumento de tamaño suele ser menor.

**¿Puedo reemplazar el video en un fotograma de video existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) dentro del fotograma manteniendo la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) que puede leer y usar, por ejemplo al guardarlo en disco.