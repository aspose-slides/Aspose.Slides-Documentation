---
title: Administrar marcos de video en presentaciones usando C++
linktitle: Marco de video
type: docs
weight: 10
url: /es/cpp/video-frame/
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
- C++
- Aspose.Slides
description: "Aprenda a agregar y extraer marcos de video de forma programática en diapositivas de PowerPoint y OpenDocument usando Aspose.Slides para C++. Guía rápida de cómo hacerlo."
---

Un video bien colocado en una presentación puede hacer que tu mensaje sea más convincente y aumentar los niveles de compromiso con tu audiencia. 

PowerPoint te permite agregar videos a una diapositiva en una presentación de dos maneras:

* Agregar o incrustar un video local (almacenado en tu máquina)
* Agregar un video en línea (desde una fuente web como YouTube).

Para permitirte agregar videos (objetos de video) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/), la interfaz [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) y otros tipos relevantes. 

## **Crear un marco de video incrustado**

Si el archivo de video que deseas agregar a tu diapositiva está almacenado localmente, puedes crear un marco de video para incrustar el video en tu presentación. 

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva a través de su índice. 
1. Agregar un objeto [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) y pasar la ruta del archivo de video para incrustar el video en la presentación. 
1. Agregar un objeto [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) para crear un marco para el video.  
1. Guardar la presentación modificada. 

Este código C++ muestra cómo agregar un video almacenado localmente a una presentación:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```


Alternativamente, puedes agregar un video pasando su ruta de archivo directamente al método [AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/):
``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```



## **Crear un marco de video con video de una fuente web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite videos de YouTube en presentaciones. Si el video que deseas usar está disponible en línea (por ejemplo, en YouTube), puedes agregarlo a tu presentación mediante su enlace web. 

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
1. Obtener la referencia de una diapositiva a través de su índice. 
1. Agregar un objeto [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) y pasar el enlace al video.
1. Establecer una miniatura para el marco de video. 
1. Guardar la presentación. 

Este código C++ muestra cómo agregar un video desde la web a una diapositiva en una presentación de PowerPoint:
```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Crea una instancia de un objeto Presentation que representa un archivo de presentación
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Agrega un marco de video 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Establece el modo de reproducción y el volumen del video
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Guarda la presentación en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Extraer video de una diapositiva**

Además de agregar videos a las diapositivas, Aspose.Slides permite extraer videos incrustados en presentaciones.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) para cargar la presentación que contiene el video. 
2. Iterar a través de todos los objetos [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/). 
3. Iterar a través de todos los objetos [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/). 
4. Guardar el video en el disco.

Este código C++ muestra cómo extraer el video de una diapositiva de presentación:
```c++
// La ruta al directorio de documentos.
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```


## **FAQ**

**¿Qué parámetros de reproducción de video se pueden cambiar para un VideoFrame?**

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).

**¿Agregar un video afecta el tamaño del archivo PPTX?**

Sí. Cuando incrustas un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece proporcionalmente al tamaño del archivo. Cuando agregas un video en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el video en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido del video](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) dentro del marco mientras preservas la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) que puedes leer y usar, por ejemplo al guardarlo en el disco.