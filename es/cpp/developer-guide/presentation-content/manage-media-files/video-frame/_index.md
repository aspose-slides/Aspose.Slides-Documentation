---
title: Gestionar marcos de vídeo en presentaciones usando C++
linktitle: Marco de vídeo
type: docs
weight: 10
url: /es/cpp/video-frame/
keywords:
- añadir vídeo
- crear vídeo
- incrustar vídeo
- extraer vídeo
- recuperar vídeo
- marco de vídeo
- fuente web
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprende a añadir y extraer programáticamente marcos de vídeo en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para C++. Guía práctica y rápida."
---
Un vídeo bien colocado en una presentación puede hacer que tu mensaje sea más atractivo y aumentar los niveles de compromiso con tu audiencia. 

PowerPoint permite añadir vídeos a una diapositiva en una presentación de dos maneras:

* Añadir o incrustar un vídeo local (almacenado en tu equipo)
* Añadir un vídeo en línea (de una fuente web como YouTube).

Para permitirte añadir vídeos (objetos de vídeo) a una presentación, Aspose.Slides ofrece la interfaz [IVideo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideo/), la interfaz [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) y otros tipos relevantes. 

## **Crear un marco de vídeo incrustado**

Si el archivo de vídeo que deseas añadir a tu diapositiva está almacenado localmente, puedes crear un marco de vídeo para incrustar el vídeo en tu presentación. 

1. Crea una instancia de la clase [Presentation ](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Obtén una referencia a la diapositiva mediante su índice. 
1. Añade un objeto [IVideo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideo/) y pasa la ruta del archivo de vídeo para incrustar el vídeo en la presentación. 
1. Añade un objeto [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) para crear un marco para el vídeo.  
1. Guarda la presentación modificada. 

Este código C++ muestra cómo añadir un vídeo almacenado localmente a una presentación:

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

Alternativamente, puedes añadir un vídeo pasando su ruta de archivo directamente al método [AddVideoFrame()](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/addvideoframe/):

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Crear un marco de vídeo con vídeo de una fuente web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite vídeos de YouTube en presentaciones. Si el vídeo que deseas usar está disponible en línea (p. ej., en YouTube), puedes añadirlo a tu presentación mediante su enlace web. 

1. Crea una instancia de la clase [Presentation ](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/)
1. Obtén una referencia a la diapositiva mediante su índice. 
1. Añade un objeto [IVideo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideo/) y pasa el enlace al vídeo.
1. Establece una miniatura para el marco de vídeo. 
1. Guarda la presentación. 

Este código C++ muestra cómo añadir un vídeo desde la web a una diapositiva en una presentación de PowerPoint:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Instancia un objeto Presentation que representa un archivo de presentación
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Añade un marco de vídeo 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Establece el modo de reproducción y el volumen del vídeo
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Guarda la presentación en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Gestionar subtítulos de vídeo**

Aspose.Slides permite gestionar subtítulos cerrados para los marcos de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Añadir subtítulos a un marco de vídeo**

Para añadir subtítulos a un marco de vídeo:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Añade un vídeo a la presentación.
1. Añade un objeto [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) a una diapositiva.
1. Utiliza la [ICaptionsCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/) devuelta por [get_CaptionTracks](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/get_captiontracks/) para añadir una pista de subtítulos WebVTT.
1. Guarda la presentación modificada.

El siguiente código muestra cómo añadir subtítulos a un marco de vídeo:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adds a new captions track from a WebVTT file.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/) también proporciona una sobrecarga que permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de vídeo**

Para extraer subtítulos de un marco de vídeo:

1. Carga la presentación que contiene el vídeo.
1. Encuentra el objeto [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) objetivo.
1. Itera a través de las pistas de subtítulos devueltas por [get_CaptionTracks](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Guarda cada pista de subtítulos en un archivo `.vtt`.

El siguiente código muestra cómo extraer subtítulos de un marco de vídeo:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // Guarda la pista de subtítulos en un archivo WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y los datos del subtítulo como una cadena UTF-8.

**Eliminar subtítulos de un marco de vídeo**

Para eliminar subtítulos de un marco de vídeo:

1. Carga la presentación que contiene el vídeo.
1. Obtén el objeto [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) objetivo.
1. Elimina las pistas de subtítulos de la colección devuelta por [get_CaptionTracks](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Guarda la presentación modificada.

El siguiente código muestra cómo eliminar todos los subtítulos de un marco de vídeo:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Elimina todos los subtítulos del marco de vídeo.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Si necesitas eliminar solo una pista de subtítulos, utiliza los métodos [Remove](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/removeat/) en lugar de [Clear](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/clear/).

## **Extraer vídeo de una diapositiva**

Además de añadir vídeos a las diapositivas, Aspose.Slides permite extraer los vídeos incrustados en las presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) para cargar la presentación que contiene el vídeo. 
2. Recorre todos los objetos [ISlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/) .
3. Recorre todos los objetos [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/videoframe/). 
4. Guarda el vídeo en el disco.

Este código C++ muestra cómo extraer el vídeo de una diapositiva de la presentación:

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

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de vídeo pueden modificarse para un VideoFrame?**

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/es/cpp/aspose.slides/videoframe/set_playmode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/es/cpp/aspose.slides/videoframe/set_playloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/videoframe/).

**¿Afecta la adición de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrustas un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando añades un vídeo en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo sustituir el vídeo en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido de vídeo](https://reference.aspose.com/slides/es/cpp/aspose.slides/videoframe/set_embeddedvideo/) dentro del marco mientras preservas la geometría de la forma; este es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/es/cpp/aspose.slides/video/get_contenttype/) que puedes leer y utilizar, por ejemplo al guardarlo en el disco.