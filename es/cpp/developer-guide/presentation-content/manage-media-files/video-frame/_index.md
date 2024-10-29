---
title: Marco de Video
type: docs
weight: 10
url: /es/cpp/video-frame/
keywords: "Agregar video, crear marco de video, extraer video, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Agregar marco de video a la presentación de PowerPoint en C++"

---

Un video bien colocado en una presentación puede hacer que tu mensaje sea más convincente y aumentar los niveles de participación de tu audiencia.

PowerPoint te permite agregar videos a una diapositiva en una presentación de dos maneras:

* Agregar o incrustar un video local (almacenado en tu máquina)
* Agregar un video en línea (de una fuente web como YouTube).

Para permitir que agregues videos (objetos de video) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/), la interfaz [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) y otros tipos relevantes.

## **Crear Marco de Video incrustado**

Si el archivo de video que deseas agregar a tu diapositiva está almacenado localmente, puedes crear un marco de video para incrustar el video en tu presentación.

1. Crea una instancia de la clase [Presentation ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un objeto [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) y pasa la ruta del archivo de video para incrustar el video con la presentación.
1. Agrega un objeto [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) para crear un marco para el video.
1. Guarda la presentación modificada.

Este código C++ te muestra cómo agregar un video almacenado localmente a una presentación:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Carga el video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Obtiene la primera diapositiva y agrega un videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Guarda la presentación en el disco
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

Alternativamente, puedes agregar un video pasando su ruta de archivo directamente al método [AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) :

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Crear Marco de Video con Video de Fuente Web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite videos de YouTube en presentaciones. Si el video que deseas usar está disponible en línea (por ejemplo, en YouTube), puedes agregarlo a tu presentación a través de su enlace web.

1. Crea una instancia de la clase [Presentation ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un objeto [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) y pasa el enlace al video.
1. Establece una miniatura para el marco de video.
1. Guarda la presentación.

Este código C++ te muestra cómo agregar un video de la web a una diapositiva en una presentación de PowerPoint:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Instancia un objeto Presentation que representa un archivo de presentación
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Agrega un Marco de Video
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Establece el Modo de Reproducción y el Volumen del Video
vf->set_PlayMode(VideoPlayModePreset::Auto);

// Guarda la presentación en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Extraer Video de la Diapositiva**

Además de agregar videos a las diapositivas, Aspose.Slides te permite extraer videos incrustados en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) para cargar la presentación que contiene el video.
2. Itera a través de todos los objetos [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/).
3. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).
4. Guarda el video en el disco.

Este código C++ te muestra cómo extraer el video de una diapositiva de presentación:

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