---
title: Marco de video
type: docs
weight: 10
url: /es/net/video-frame/
keywords: "Agregar video, crear marco de video, extraer video, presentación PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar marco de video a una presentación PowerPoint en C# o .NET"
---

Un video bien colocado en una presentación puede hacer que tu mensaje sea más atractivo y aumentar los niveles de participación de la audiencia. 

PowerPoint permite agregar videos a una diapositiva en una presentación de dos maneras:

* Agregar o incrustar un video local (almacenado en tu equipo)
* Agregar un video en línea (de una fuente web como YouTube).

Para permitirte agregar videos (objetos de video) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) , la interfaz [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) , y otros tipos relevantes. 

## **Crear marco de video incrustado**

Si el archivo de video que deseas agregar a tu diapositiva está almacenado localmente, puedes crear un marco de video para incrustar el video en tu presentación. 

1. Crea una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. Obtén la referencia de una diapositiva mediante su índice. 
1. Agrega un objeto [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) y pasa la ruta del archivo de video para incrustar el video en la presentación. 
1. Agrega un objeto [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) para crear un marco para el video.  
1. Guarda la presentación modificada. 

Este código C# muestra cómo agregar un video almacenado localmente a una presentación:
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

Alternativamente, puedes agregar un video pasando su ruta de archivo directamente al método [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/):
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```



## **Crear marco de video con video de fuente web**
Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite videos de YouTube en presentaciones. Si el video que deseas usar está disponible en línea (p. ej., en YouTube), puedes agregarlo a tu presentación mediante su enlace web. 

1. Crea una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class
1. Obtén la referencia de una diapositiva mediante su índice. 
1. Agrega un objeto [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) y pasa el enlace al video.
1. Establece una miniatura para el marco de video. 
1. Guarda la presentación. 

Este código C# muestra cómo agregar un video desde la web a una diapositiva en una presentación PowerPoint:
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
Además de agregar videos a las diapositivas, Aspose.Slides permite extraer videos incrustados en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) para cargar la presentación que contiene el video. 
2. Itera a través de todos los objetos [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) para encontrar un [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe). 
4. Guarda el video en el disco.

Este código C# muestra cómo extraer el video de una diapositiva de presentación:
```c#
 // Instancia un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation("Video.pptx");

// Itera a través de las diapositivas
foreach (ISlide slide in presentation.Slides)
{
    // Itera a través de las formas
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


## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de video se pueden cambiar para un VideoFrame?**

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**¿Agregar un video afecta el tamaño del archivo PPTX?**

Sí. Cuando incrustas un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece proporcionalmente al tamaño del archivo. Cuando agregas un video en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el video en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido del video](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) dentro del marco mientras preservas la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) que puedes leer y usar, por ejemplo al guardarlo en el disco.