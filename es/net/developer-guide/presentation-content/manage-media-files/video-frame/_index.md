---
title: Marco de Video
type: docs
weight: 10
url: /net/video-frame/
keywords: "Agregar video, crear marco de video, extraer video, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar marco de video a una presentación de PowerPoint en C# o .NET"
---

Un video bien colocado en una presentación puede hacer que tu mensaje sea más convincente y aumentar los niveles de compromiso con tu audiencia.

PowerPoint te permite agregar videos a una diapositiva en una presentación de dos maneras:

* Agregar o incrustar un video local (almacenado en tu máquina)
* Agregar un video en línea (de una fuente web como YouTube).

Para permitirte agregar videos (objetos de video) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/), la interfaz [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) y otros tipos relevantes.

## **Crear Marco de Video Incrustado**

Si el archivo de video que deseas agregar a tu diapositiva está almacenado localmente, puedes crear un marco de video para incrustar el video en tu presentación.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén una referencia de la diapositiva a través de su índice.
1. Agrega un objeto [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) y pasa la ruta del archivo de video para incrustar el video con la presentación.
1. Agrega un objeto [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) para crear un marco para el video.
1. Guarda la presentación modificada.

Este código C# te muestra cómo agregar un video almacenado localmente a una presentación:

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
        
        // Guarda la presentación en el disco
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternativamente, puedes agregar un video pasando su ruta de archivo directamente al método [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/):

```csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Crear Marco de Video con Video de una Fuente Web**
Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) soporta videos de YouTube en las presentaciones. Si el video que deseas usar está disponible en línea (por ejemplo, en YouTube), puedes agregarlo a tu presentación a través de su enlace web.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén una referencia de la diapositiva a través de su índice.
1. Agrega un objeto [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) y pasa el enlace al video.
1. Establece una miniatura para el marco de video.
1. Guarda la presentación.

Este código C# te muestra cómo agregar un video de la web a una diapositiva en una presentación de PowerPoint:

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

## **Extraer Video de una Diapositiva**
Además de agregar videos a las diapositivas, Aspose.Slides te permite extraer videos incrustados en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) para cargar la presentación que contiene el video.
2. Itera a través de todos los objetos [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) para encontrar un [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe).
4. Guarda el video en el disco.

Este código C# te muestra cómo extraer el video de una diapositiva de presentación:

```c#
// Instancia un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation("Video.pptx");

// Itera a través de las diapositivas
foreach (ISlide slide in presentation.Slides)
{
    // Itera a través de las formas
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Guarda el video en el disco una vez que se encuentra el VideoFrame que contiene el video
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