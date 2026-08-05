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
description: "Aprenda a añadir y extraer programáticamente marcos de vídeo en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para C++. Guía rápida de cómo hacerlo."
---
## **Introducción**

Un vídeo bien colocado en una presentación puede hacer que su mensaje sea más convincente y aumentar los niveles de compromiso con su audiencia. 

PowerPoint le permite añadir videos a una diapositiva en una presentación de dos maneras:

* Agregar o incrustar un vídeo local (almacenado en su máquina)
* Agregar un vídeo en línea (de una fuente web como YouTube).

Para permitirle añadir vídeos (objetos de vídeo) a una presentación, Aspose.Slides proporciona la interfaz [IVideo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideo/) , la interfaz [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) y otros tipos relevantes. 

## **Crear un marco de vídeo incrustado**

Si el archivo de vídeo que desea añadir a su diapositiva está almacenado localmente, puede crear un marco de vídeo para incrustar el vídeo en su presentación. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Obtenga una referencia a una diapositiva mediante su índice. 
3. Añada un objeto [IVideo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideo/) y pase la ruta del archivo de vídeo para incrustar el vídeo en la presentación. 
4. Añada un objeto [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) para crear un marco para el vídeo.  
5. Guarde la presentación modificada. 

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Carga el vídeo
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Obtiene la primera diapositiva y añade un marco de vídeo
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Guarda la presentación en disco
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

Alternativamente, puede añadir un vídeo pasando directamente su ruta de archivo al método [AddVideoFrame()](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/addvideoframe/).

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Crear un marco de vídeo con vídeo de una fuente web**

Las versiones más recientes de Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admiten vídeos en línea en las presentaciones. Si el vídeo que desea utilizar está disponible en línea (p. ej., en YouTube), puede añadirlo a su presentación mediante su enlace web.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/)
2. Obtenga una referencia a una diapositiva mediante su índice. 
3. Añada un objeto [IVideo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideo/) y pase el enlace al vídeo.
4. Establezca una miniatura para el marco de vídeo. 
5. Guarde la presentación. 

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

## **Recortar un marco de vídeo**

Aspose.Slides le permite controlar qué parte de un vídeo se reproduce estableciendo los valores trim-from-start y trim-from-end mediante [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/set_trimfromstart/) y [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/set_trimfromend/). Ambos valores se especifican en milisegundos y definen cuánto tiempo se omite al inicio y al final del vídeo, respectivamente. Estos ajustes cambian la configuración de reproducción del vídeo en la presentación; no recortan ni modifican de otro modo los datos binarios del vídeo incrustado.

**Establecer ajustes de recorte**

Para crear un marco de vídeo y establecer sus ajustes de recorte:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Añada un objeto [IVideo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideo/) a la presentación.
3. Añada un objeto [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) a una diapositiva.
4. Establezca los valores trim-from-start y trim-from-end mediante [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/set_trimfromstart/) y [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/set_trimfromend/).
5. Guarde la presentación modificada.

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Leer ajustes de recorte**

Para inspeccionar los ajustes de recorte existentes, cargue una presentación, encuentre un objeto [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) entre las formas de la primera diapositiva y lea los valores mediante [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/get_trimfromstart/) y [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/get_trimfromend/).

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **Gestionar subtítulos de vídeo**

Aspose.Slides le permite gestionar subtítulos cerrados para los marcos de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Añadir subtítulos a un marco de vídeo**

Para añadir subtítulos a un marco de vídeo:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Añada un vídeo a la presentación.
3. Añada un objeto [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) a una diapositiva.
4. Utilice la [ICaptionsCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/) devuelta por [get_CaptionTracks](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/get_captiontracks/) para añadir una pista de subtítulos WebVTT.
5. Guarde la presentación modificada.

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Añade una nueva pista de subtítulos desde un archivo WebVTT.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/) también proporciona una sobrecarga que le permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de vídeo**

Para extraer subtítulos de un marco de vídeo:

1. Cargue la presentación que contiene el vídeo.
2. Encuentre el objeto [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) objetivo.
3. Itere a través de las pistas de subtítulos devueltas por [get_CaptionTracks](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/get_captiontracks/).
4. Guarde cada pista de subtítulos en un archivo `.vtt`.

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

1. Cargue la presentación que contiene el vídeo.
2. Obtenga el objeto [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) objetivo.
3. Elimine las pistas de subtítulos de la colección devuelta por [get_CaptionTracks](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/get_captiontracks/).
4. Guarde la presentación modificada.

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Elimina todos los subtítulos del marco de vídeo.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Si necesita eliminar solo una pista de subtítulos, use los métodos [Remove](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/removeat/) en lugar de [Clear](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/clear/).

## **Extraer vídeo de una diapositiva**

Además de añadir vídeos a diapositivas, Aspose.Slides le permite extraer los vídeos incrustados en presentaciones.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) para cargar la presentación que contiene el vídeo. 
2. Itere a través de todos los objetos [ISlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/).
3. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/videoframe/). 
4. Guarde el vídeo en disco.

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

**¿Qué parámetros de reproducción de vídeo se pueden cambiar para un VideoFrame?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/es/cpp/aspose.slides/videoframe/set_playmode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/es/cpp/aspose.slides/videoframe/set_playloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/videoframe/).

**¿Afecta la adición de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrusta un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece proporcionalmente al tamaño del archivo. Cuando añade un vídeo en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el vídeo en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido del vídeo](https://reference.aspose.com/slides/es/cpp/aspose.slides/videoframe/set_embeddedvideo/) dentro del marco manteniendo la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/es/cpp/aspose.slides/video/get_contenttype/) que puede leer y usar, por ejemplo al guardarlo en disco.