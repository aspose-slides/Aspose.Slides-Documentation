---
title: Gestionar marcos de vídeo en presentaciones con C++
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
description: "Aprenda a añadir y extraer programáticamente marcos de vídeo en diapositivas de PowerPoint y OpenDocument usando Aspose.Slides para C++. Guía rápida paso a paso."
---
## **Introducción**

Los vídeos pueden ayudar a explicar ideas y a captar la atención del público. Aspose.Slides for C++ permite añadir marcos de vídeo a las diapositivas, ajustar la configuración de reproducción, gestionar subtítulos y extraer datos de vídeo incrustados.

PowerPoint admite vídeos locales y enlaces a vídeos en línea, como los de YouTube.

Para representar datos de vídeo y marcos de vídeo, Aspose.Slides ofrece la interfaz [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/), la interfaz [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) y otros tipos relevantes.

## **Crear un marco de vídeo incrustado**

Si el archivo de vídeo que desea añadir a su diapositiva está almacenado localmente, puede crear un marco de vídeo para incrustar el vídeo en su presentación.

Este ejemplo incrusta un vídeo local en la primera diapositiva de una presentación existente y guarda el resultado. Las coordenadas y dimensiones del marco están en puntos. El flujo permanece abierto hasta que finaliza el guardado porque [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) lo mantiene bloqueado mientras la presentación lo utiliza.

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

También puede pasar la ruta de un vídeo local directamente a [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). Este ejemplo incrusta el vídeo en la primera diapositiva de una nueva presentación. El vídeo debe seguir accesible hasta que se guarde la presentación.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Crear un marco de vídeo con vídeo de una fuente web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admite vídeos en línea en las presentaciones. Puede crear un marco de vídeo que enlaza a un vídeo en línea, como un vídeo de YouTube.

Este ejemplo añade un enlace y una miniatura de un vídeo de YouTube a la primera diapositiva. Reemplace el identificador del vídeo para usar otro vídeo. El método [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) solicita la reproducción automática. Descargar la miniatura y reproducir el vídeo requiere acceso a Internet. El visor de la presentación también debe admitir la reproducción de vídeo en línea.

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Reproducir un vídeo en modo pantalla completa**

En una presentación de entrenamiento, puede reproducir una demostración de software en modo pantalla completa para que el público vea los detalles. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) acepta `true` para habilitar este comportamiento durante la reproducción.

Este ejemplo abre una presentación, busca el primer [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) en la primera diapositiva y habilita la reproducción en pantalla completa. La presentación de entrada debe contener al menos una diapositiva con un marco de vídeo existente en la primera diapositiva.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La reproducción en pantalla completa controla cómo se muestra el vídeo. De forma independiente, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) controla si comienza automáticamente o al hacer clic, y [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) controla si se repite. Para elegir el comportamiento de inicio, establezca el modo de reproducción en [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). El ejemplo conserva la configuración de inicio y bucle existentes.

## **Retroceder un vídeo después de la reproducción**

En una presentación de entrenamiento, devolver un vídeo de demostración a su comienzo lo deja listo para que el presentador lo reproduzca de nuevo.

Llame a [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) con `true` para devolver el vídeo al principio después de que finalice la reproducción.

Este ejemplo abre una presentación, busca el primer [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) en la primera diapositiva y habilita el retroceso. Desactiva el bucle para que la reproducción pueda terminar y establece la reproducción para que inicie al hacer clic. La presentación de entrada debe contener al menos una diapositiva con un marco de vídeo existente en la primera diapositiva.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El retroceso devuelve el vídeo a su comienzo sin iniciarlo de nuevo. En contraste, habilitar [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) repite la reproducción automáticamente. Mantenga el bucle desactivado cuando quiera que el vídeo termine y quede listo para reproducirse nuevamente. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) controla de forma independiente el inicio automático o al hacer clic; este ejemplo usa [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) para que el presentador decida cuándo empieza la reproducción. Establezca el modo de reproducción después de la configuración del bucle, como se muestra en el ejemplo. El retroceso funciona de forma independiente de [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Recortar un marco de vídeo**

Utilice [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) y [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) para omitir parte del inicio o del final de un vídeo durante la reproducción. Ambos valores están en milisegundos. Recortar modifica la configuración de reproducción sin alterar los datos de vídeo incrustados.

**Establecer la configuración de recorte**

Este ejemplo incrusta un vídeo local y omite los primeros 2,5 segundos y el último segundo durante la reproducción. Utilice un vídeo de más de 3,5 segundos para que quede un segmento reproducible.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Leer la configuración de recorte**

Este ejemplo muestra los valores de recorte del primer marco de vídeo en la primera diapositiva, expresados en milisegundos. La presentación debe contener al menos una diapositiva. Si esa diapositiva no tiene un marco de vídeo, no se muestra nada. El ejemplo anterior produce los valores 2500 y 1000.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **Gestionar subtítulos de vídeo**

Aspose.Slides permite gestionar subtítulos cerrados para los marcos de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen a través del método [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Agregar subtítulos a un marco de vídeo**

Este ejemplo incrusta un vídeo local y añade una pista de subtítulos WebVTT etiquetada como English. Las marcas de tiempo de los subtítulos deben coincidir con el vídeo. La presentación guardada incluye tanto el vídeo como sus subtítulos.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La interfaz [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) también ofrece una sobrecarga que permite agregar subtítulos desde un flujo.

**Extraer subtítulos de un marco de vídeo**

Este ejemplo guarda todas las pistas de subtítulos de los marcos de vídeo en la primera diapositiva como archivos WebVTT separados. Los números secuenciales mantienen los archivos de salida distintos. La consola informa del número de pistas extraídas. La presentación debe contener al menos una diapositiva.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como cadena UTF‑8.

**Eliminar subtítulos de un marco de vídeo**

Este ejemplo elimina todos los subtítulos del marco de vídeo que ocupa la primera posición de forma en la primera diapositiva y guarda el resultado. Se asume que la diapositiva y la forma existen y que la forma es un marco de vídeo.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Si necesita eliminar solo una pista de subtítulos, use los métodos [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) en lugar de [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/).

## **Extraer vídeo de una diapositiva**

Además de añadir vídeos a las diapositivas, Aspose.Slides permite extraer los vídeos incrustados en las presentaciones.

Este ejemplo extrae los vídeos incrustados de cada diapositiva en archivos binarios numerados por separado. Los vídeos vinculados se omiten porque no contienen datos incrustados. La consola muestra el tipo MIME de cada vídeo y el recuento total. La salida utiliza la extensión genérica `.bin`; cámbiela para que coincida con el tipo de medio informado cuando sea necesario.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **FAQ**

**¿Qué parámetros de reproducción de vídeo pueden modificarse en un marco de vídeo?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Estas opciones están disponibles a través de los métodos del objeto [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).

**¿Afecta la incorporación de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrusta un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece proporcionalmente al tamaño del archivo. Cuando enlaza a un vídeo en línea y añade una miniatura, la presentación almacena el enlace y la imagen previa en lugar de los datos del vídeo, por lo que el aumento de tamaño suele ser menor.

**¿Puedo sustituir el vídeo en un marco de vídeo existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido del vídeo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) dentro del marco manteniendo la geometría de la forma; es un escenario frecuente para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) que puede leer y utilizar, por ejemplo, al guardarlo en disco.