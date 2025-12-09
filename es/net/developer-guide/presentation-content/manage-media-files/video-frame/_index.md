---
title: Administrar marcos de video en presentaciones en .NET
linktitle: Marco de video
type: docs
weight: 10
url: /es/net/video-frame/
keywords:
- agregar video
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
description: "Aprende a agregar y extraer marcos de video de forma programática en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para .NET. Guía rápida paso a paso."
---

Un video bien colocado en una presentación puede hacer que su mensaje sea más atractivo y aumentar los niveles de participación de su audiencia. 

PowerPoint le permite agregar videos a una diapositiva en una presentación de dos maneras:

* Agregar o incrustar un video local (almacenado en su equipo)
* Agregar un video en línea (desde una fuente web como YouTube).

Para permitirle agregar videos (objetos de video) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/), la interfaz [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) y otros tipos relevantes. 

## **Crear marco de video incrustado**

Si el archivo de video que desea agregar a su diapositiva está almacenado localmente, puede crear un marco de video para incrustar el video en su presentación. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenga una referencia a una diapositiva mediante su índice. 
3. Agregue un objeto [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) y pase la ruta del archivo de video para incrustar el video en la presentación. 
4. Agregue un objeto [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) para crear un marco para el video.  
5. Guarde la presentación modificada. 

Este código C# le muestra cómo agregar un video almacenado localmente a una presentación:
```c#
// Instancia la clase Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Carga el video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Obtiene la primera diapositiva y agrega un videoframe
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Guarda la presentación en disco
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```

Alternativamente, puede agregar un video pasando su ruta de archivo directamente al método [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/):
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Crear marco de video con video de fuente web**
Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admiten videos de YouTube en presentaciones. Si el video que desea usar está disponible en línea (p. ej., en YouTube), puede agregarlo a su presentación a través de su enlace web. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. Obtenga una referencia a una diapositiva mediante su índice. 
3. Agregue un objeto [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) y pase el enlace al video.
4. Establezca una miniatura para el marco de video. 
5. Guarde la presentación. 

Este código C# le muestra cómo agregar un video desde la web a una diapositiva en una presentación de PowerPoint:
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
    // Agrega un VideoFrame
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


## **Extraer video de la diapositiva**
Además de agregar videos a diapositivas, Aspose.Slides le permite extraer videos incrustados en presentaciones.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) para cargar la presentación que contiene el video. 
2. Itere a través de todos los objetos [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) para encontrar un [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe). 
4. Guarde el video en el disco.

Este código C# le muestra cómo extraer el video de una diapositiva de presentación:
```c#
// Instancia un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation("Video.pptx");

// Itera sobre las diapositivas
foreach (ISlide slide in presentation.Slides)
{
    // Itera sobre las formas
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Guarda el video en disco una vez que se encuentra un VideoFrame que contiene el video
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

**¿Qué parámetros de reproducción de video se pueden cambiar para un VideoFrame?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**¿Agregar un video afecta el tamaño del archivo PPTX?**

Sí. Cuando incrusta un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación aumenta en proporción al tamaño del archivo. Cuando agrega un video en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el video en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido de video](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) dentro del marco manteniendo la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) que puede leer y usar, por ejemplo al guardarlo en el disco.