---
title: Gestionar fotogramas de vídeo en presentaciones en .NET
linktitle: Fotograma de vídeo
type: docs
weight: 10
url: /es/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Aprenda a añadir y extraer fotogramas de vídeo en diapositivas de PowerPoint y OpenDocument usando Aspose.Slides para .NET. Guía rápida paso a paso."
---
Un video bien colocado en una presentación puede hacer que su mensaje sea más atractivo y aumentar los niveles de participación de su audiencia. 

PowerPoint permite agregar videos a una diapositiva en una presentación de dos formas:

* Añadir o incrustar un video local (almacenado en su equipo)
* Añadir un video en línea (desde una fuente web como YouTube). 

Para permitirle agregar videos (objetos de video) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/es/net/aspose.slides/ivideo/) , la interfaz [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) , y otros tipos relevantes. 

## **Crear un fotograma de vídeo incrustado**

Si el archivo de vídeo que desea agregar a su diapositiva está almacenado localmente, puede crear un fotograma de vídeo para incrustar el vídeo en su presentación. 

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) .
1. Obtenga la referencia de una diapositiva mediante su índice. 
1. Agregue un objeto [IVideo](https://reference.aspose.com/slides/es/net/aspose.slides/ivideo/) y pase la ruta del archivo de vídeo para incrustar el vídeo en la presentación. 
1. Agregue un objeto [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) para crear un fotograma para el vídeo.  
1. Guarde la presentación modificada. 

Este código C# le muestra cómo agregar un vídeo almacenado localmente a una presentación:

```c#
    // Instancia la clase Presentation
    using (Presentation pres = new Presentation("pres.pptx"))
    {
        // Carga el vídeo
        using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
        {
            IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
            
            // Obtiene la primera diapositiva y añade un fotograma de vídeo
            pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
            
            // Guarda la presentación en disco
            pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
        }
    }
```
Alternativamente, puede agregar un vídeo pasando directamente su ruta de archivo al método [AddVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addvideoframe/) :

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Crear un fotograma de vídeo con vídeo de una fuente web**
Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite vídeos de YouTube en presentaciones. Si el vídeo que desea usar está disponible en línea (p. ej., en YouTube), puede agregarlo a su presentación mediante su enlace web. 

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) .
1. Obtenga la referencia de una diapositiva mediante su índice. 
1. Agregue un objeto [IVideo](https://reference.aspose.com/slides/es/net/aspose.slides/ivideo/) y pase el enlace al vídeo.
1. Establezca una miniatura para el fotograma de vídeo. 
1. Guarde la presentación. 

Este código C# le muestra cómo agregar un vídeo desde la web a una diapositiva en una presentación de PowerPoint:

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

## **Gestionar subtítulos de vídeo**

Aspose.Slides le permite gestionar subtítulos cerrados para fotogramas de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante la propiedad [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/captiontracks/) .

**Agregar subtítulos a un fotograma de vídeo**

Para agregar subtítulos a un fotograma de vídeo:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) .
1. Agregue un vídeo a la presentación. 
1. Agregue un objeto [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) a una diapositiva. 
1. Utilice la colección [CaptionTracks](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/captiontracks/) para agregar una pista de subtítulos WebVTT. 
1. Guarde la presentación modificada. 

El siguiente código le muestra cómo agregar subtítulos a un fotograma de vídeo:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Añade una nueva pista de subtítulos desde un archivo WebVTT.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/es/net/aspose.slides/icaptionscollection/) también proporciona una sobrecarga que le permite agregar subtítulos desde un flujo.

**Extraer subtítulos de un fotograma de vídeo**

Para extraer subtítulos de un fotograma de vídeo:

1. Cargue la presentación que contiene el vídeo. 
1. Encuentre el objeto [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) objetivo. 
1. Itere a través de la colección [CaptionTracks](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/captiontracks/) . 
1. Guarde cada pista de subtítulos en un archivo `.vtt`. 

El siguiente código le muestra cómo extraer subtítulos de un fotograma de vídeo:

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

**Eliminar subtítulos de un fotograma de vídeo**

Para eliminar subtítulos de un fotograma de vídeo:

1. Cargue la presentación que contiene el vídeo. 
1. Obtenga el objeto [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) objetivo. 
1. Elimine las pistas de subtítulos de la colección [CaptionTracks](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/captiontracks/) . 
1. Guarde la presentación modificada. 

El siguiente código le muestra cómo eliminar todos los subtítulos de un fotograma de vídeo:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Elimina todos los subtítulos del fotograma de vídeo.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Si necesita eliminar solo una pista de subtítulos, utilice los métodos [Remove](https://reference.aspose.com/slides/es/net/aspose.slides/captionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/es/net/aspose.slides/captionscollection/removeat/) en lugar de [Clear](https://reference.aspose.com/slides/es/net/aspose.slides/captionscollection/clear/) .

## **Extraer vídeo de una diapositiva**
Además de agregar vídeos a las diapositivas, Aspose.Slides le permite extraer vídeos incrustados en presentaciones.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) para cargar la presentación que contiene el vídeo. 
2. Itere a través de todos los objetos [ISlide](https://reference.aspose.com/slides/es/net/aspose.slides/islide) . 
3. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/videoframe) . 
4. Guarde el vídeo en disco. 

Este código C# le muestra cómo extraer el vídeo de una diapositiva de una presentación:

```c#
 // Instancia un objeto Presentation que representa un archivo de presentación 
 Presentation presentation = new Presentation("Video.pptx");

// Itera a través de las diapositivas
foreach (ISlide slide in presentation.Slides)
{
    // Itera a través de las formas
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Guarda el vídeo en disco una vez que se encuentra un VideoFrame que contiene el vídeo
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

## **FAQ**

**¿Qué parámetros de reproducción de vídeo se pueden cambiar para un VideoFrame?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/es/net/aspose.slides/videoframe/playmode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/es/net/aspose.slides/videoframe/playloopmode/) . Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/videoframe/) .

**¿Agregar un vídeo afecta al tamaño del archivo PPTX?**

Sí. Cuando incrusta un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece proporcionalmente al tamaño del archivo. Cuando agrega un vídeo en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el vídeo en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido del vídeo](https://reference.aspose.com/slides/es/net/aspose.slides/videoframe/embeddedvideo/) dentro del fotograma manteniendo la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/es/net/aspose.slides/video/contenttype/) que puede leer y utilizar, por ejemplo al guardarlo en disco.