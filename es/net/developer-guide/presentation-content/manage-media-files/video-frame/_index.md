---
title: Administrar marcos de video en presentaciones en .NET
linktitle: Marco de video
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
- fuente web
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprende a añadir y extraer programáticamente marcos de video en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para .NET. Guía práctica rápida."
---
## **Introducción**

Un video bien colocado en una presentación puede hacer que tu mensaje sea más atractivo y aumentar los niveles de participación de tu audiencia. 

PowerPoint te permite añadir videos a una diapositiva de una presentación de dos maneras:

* Añadir o incrustar un video local (almacenado en tu equipo)
* Añadir un video en línea (desde una fuente web como YouTube).

Para permitirte añadir videos (objetos de video) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/es/net/aspose.slides/ivideo/) , la interfaz [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) y otros tipos relevantes. 

## **Crear un marco de video incrustado**

Si el archivo de video que deseas añadir a tu diapositiva está almacenado localmente, puedes crear un marco de video para incrustar el video en tu presentación. 

1. Crear una instancia de la clase [Presentation ](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) .
1. Obtener la referencia de una diapositiva mediante su índice. 
1. Añadir un objeto [IVideo](https://reference.aspose.com/slides/es/net/aspose.slides/ivideo/) y proporcionar la ruta del archivo de video para incrustar el video en la presentación. 
1. Añadir un objeto [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) para crear un marco para el video.  
1. Guardar la presentación modificada. 

Este código C# muestra cómo añadir un video almacenado localmente a una presentación:

```c#
// Instancia la clase Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Carga el video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Obtiene la primera diapositiva y añade un marco de video
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Guarda la presentación en disco
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternativamente, puedes añadir un video pasando su ruta de archivo directamente al método [AddVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Crear un marco de video con video de una fuente web**
Las versiones más recientes de Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admiten videos en línea en presentaciones. Si el video que deseas usar está disponible en línea (p. ej. en YouTube), puedes añadirlo a tu presentación mediante su enlace web.

1. Crear una instancia de la clase [Presentation ](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) 
1. Obtener la referencia de una diapositiva mediante su índice. 
1. Añadir un objeto [IVideo](https://reference.aspose.com/slides/es/net/aspose.slides/ivideo/) y proporcionar el enlace al video.
1. Establecer una miniatura para el marco de video. 
1. Guardar la presentación. 

Este código C# muestra cómo añadir un video desde la web a una diapositiva en una presentación de PowerPoint:

```c#
public static void Run()
{
    // Instancia un objeto Presentation que representa un archivo de presentación 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Añade un VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Carga la miniatura
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Recortar un marco de video**

Aspose.Slides permite controlar qué parte de un video se reproduce estableciendo los valores trim-from-start y trim-from-end mediante [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/trimfromstart/) y [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/trimfromend/). Ambos valores se especifican en milisegundos y definen cuánto tiempo se omite al principio y al final del video, respectivamente. Estas configuraciones cambian los ajustes de reproducción del video en la presentación; no recortan ni modifican de otra forma los datos binarios del video incrustado.

**Establecer configuraciones de recorte**

Para crear un marco de video y establecer sus configuraciones de recorte:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) .
1. Añadir un objeto [IVideo](https://reference.aspose.com/slides/es/net/aspose.slides/ivideo/) a la presentación.
1. Añadir un objeto [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) a una diapositiva.
1. Establecer los valores trim-from-start y trim-from-end mediante [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/trimfromstart/) y [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/trimfromend/) .
1. Guardar la presentación modificada.

El siguiente ejemplo de código omite los primeros 2,5 segundos y el último segundo de un video incrustado durante la reproducción:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Leer configuraciones de recorte**

Para inspeccionar las configuraciones de recorte existentes, carga una presentación, busca un objeto [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) entre las formas de la primera diapositiva y lee los valores mediante [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/trimfromstart/) y [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/trimfromend/) .

El siguiente ejemplo de código encuentra el primer marco de video en la primera diapositiva y muestra sus configuraciones de recorte en milisegundos:

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Gestionar subtítulos de video**

Aspose.Slides permite gestionar subtítulos cerrados para los marcos de video en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen a través de la propiedad [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/captiontracks/) .

**Añadir subtítulos a un marco de video**

Para añadir subtítulos a un marco de video:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) .
1. Añadir un video a la presentación.
1. Añadir un objeto [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) a una diapositiva.
1. Utilizar la colección [CaptionTracks](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/captiontracks/) para añadir una pista de subtítulos WebVTT.
1. Guardar la presentación modificada.

El siguiente código muestra cómo añadir subtítulos a un marco de video:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Añade una nueva pista de subtítulos desde un archivo WebVTT.
    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/es/net/aspose.slides/icaptionscollection/) también proporciona una sobrecarga que permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de video**

1. Cargar la presentación que contiene el video.
1. Encontrar el objeto [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) objetivo.
1. Iterar a través de la colección [CaptionTracks](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/captiontracks/) .
1. Guardar cada pista de subtítulos en un archivo `.vtt` .

El siguiente código muestra cómo extraer subtítulos de un marco de video:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // Guarda la pista de subtítulos en un archivo WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/es/net/aspose.slides/icaptions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF-8.

**Eliminar subtítulos de un marco de video**

1. Cargar la presentación que contiene el video.
1. Obtener el objeto [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) objetivo.
1. Eliminar las pistas de subtítulos de la colección [CaptionTracks](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/captiontracks/) .
1. Guardar la presentación modificada.

El siguiente código muestra cómo eliminar todos los subtítulos de un marco de video:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Elimina todos los subtítulos del marco de video.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Si necesitas eliminar solo una pista de subtítulos, utiliza los métodos [Remove](https://reference.aspose.com/slides/es/net/aspose.slides/captionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/es/net/aspose.slides/captionscollection/removeat/) en lugar de [Clear](https://reference.aspose.com/slides/es/net/aspose.slides/captionscollection/clear/) .

## **Extraer video de una diapositiva**
Además de añadir videos a las diapositivas, Aspose.Slides permite extraer videos incrustados en presentaciones.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) para cargar la presentación que contiene el video. 
2. Iterar a través de todos los objetos [ISlide](https://reference.aspose.com/slides/es/net/aspose.slides/islide) .
3. Iterar a través de todos los objetos [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/videoframe) . 
4. Guardar el video en el disco.

Este código C# muestra cómo extraer el video de una diapositiva de una presentación:

```c#
// Instancia un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation("Video.pptx");

// Itera a través de las diapositivas
foreach (ISlide slide in presentation.Slides)
{
    // Itera a través de las formas
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Guarda el video en disco una vez se encuentra un VideoFrame que contiene el video
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de video se pueden cambiar para un VideoFrame?**

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/es/net/aspose.slides/videoframe/playmode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/es/net/aspose.slides/videoframe/playloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/videoframe/) .

**¿Afecta la adición de un video al tamaño del archivo PPTX?**

Sí. Cuando incrustas un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece proporcionalmente al tamaño del archivo. Cuando añades un video en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el video en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido del video](https://reference.aspose.com/slides/es/net/aspose.slides/videoframe/embeddedvideo/) dentro del marco manteniendo la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/es/net/aspose.slides/video/contenttype/) que puedes leer y usar, por ejemplo al guardarlo en el disco.