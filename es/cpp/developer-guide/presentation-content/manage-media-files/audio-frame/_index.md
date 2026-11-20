---
title: Gestionar marcos de audio en presentaciones usando C++
linktitle: Marco de audio
type: docs
weight: 10
url: /es/cpp/audio-frame/
keywords:
- audio
- marco de audio
- miniatura
- añadir audio
- propiedades de audio
- opciones de audio
- extraer audio
- C++
- Aspose.Slides
description: "Incruste audio en diapositivas, cambie el ícono de audio, configure la reproducción, administre subtítulos WebVTT y extraiga los sonidos de las transiciones de diapositiva con Aspose.Slides para C++."
---
## **Visión general**

Un marco de audio le permite reproducir un sonido en una diapositiva. Con Aspose.Slides for C++, puede incrustar un clip de audio, elegir la imagen que lo representa, ajustar la reproducción y adjuntar subtítulos. También puede recuperar un sonido asignado a una transición de diapositiva.

## **Crear marcos de audio**

Utilice [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) para incrustar un clip de audio local en la primera diapositiva. Las dos primeras coordenadas posicionan el marco en la diapositiva, y los dos siguientes valores establecen su ancho y alto, todo en puntos. Este ejemplo llama a [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) para iniciar el clip automáticamente y llama a [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) para seleccionar el ajuste de volumen alto.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

presentation->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Cambiar la miniatura del marco de audio**

De forma predeterminada, un marco de audio muestra un icono de altavoz. Para mostrar una miniatura personalizada, añada una imagen a la presentación con [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) y establézcalo como la imagen del marco con [set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/). El ejemplo utiliza un JPEG como miniatura para un clip de audio incrustado.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageStream = File::OpenRead(u"eagle.jpeg");
auto thumbnail = presentation->get_Images()->AddImage(imageStream);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

## **Cambiar opciones de reproducción de audio**

Los controles de **Opciones de audio** de PowerPoint determinan cuándo comienza un clip, cuán fuerte suena y cómo se comporta durante una presentación.

![Controles de Opciones de audio de PowerPoint para un marco de audio](audio_frame_0.png)

| Control de PowerPoint | Método Aspose.Slides for C++ |
| --- | --- |
| Iniciar | [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) |
| Preset de volumen | [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) |
| Reproducir en todas las diapositivas | [set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playacrossslides/) |
| Repetir hasta detenerse | [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playloopmode/) |
| Ocultar durante la presentación | [set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_hideatshowing/) |
| Retroceder después de reproducir | [set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_rewindaudio/) |
| Desvanecer entrada | [set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeinduration/) |
| Desvanecer salida | [set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeoutduration/) |
| Recortar tiempo de inicio del audio | [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) |
| Recortar tiempo de fin del audio | [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) |
| Control deslizante de volumen | [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) |

El ejemplo encuentra el primer marco de audio en la primera diapositiva, llama a [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) para iniciar la reproducción con un clic, y selecciona el preset de volumen bajo. El clip continúa a través de las diapositivas con la repetición desactivada. El icono permanece oculto durante la presentación, y el clip retrocede después de la reproducción.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);
    audioFrame->set_Volume(AudioVolumeMode::Low);
    audioFrame->set_PlayAcrossSlides(true);
    audioFrame->set_PlayLoopMode(false);
    audioFrame->set_HideAtShowing(true);
    audioFrame->set_RewindAudio(true);

    presentation->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

Para un clip de más de 3,5 segundos, este ejemplo omite los primeros 1,5 segundos y los últimos 2 segundos. El argumento de [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) especifica la duración a omitir del final del clip. Para obtener el tiempo de finalización que muestra PowerPoint, reste ese desplazamiento de la duración total del clip. El clip recortado se desvanece al entrar en 200 milisegundos y al salir en 500 milisegundos. Los cuatro establecedores aceptan valores en milisegundos.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame->set_TrimFromStart(1500);
audioFrame->set_TrimFromEnd(2000);
audioFrame->set_FadeInDuration(200);
audioFrame->set_FadeOutDuration(500);

presentation->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
```

Para establecer el volumen de reproducción a un porcentaje específico, utilice [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/). Este ejemplo asigna al primer marco de audio en la primera diapositiva un 85 %.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_VolumeValue(85);

    presentation->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

## **Gestionar subtítulos de audio**

Cada marco de audio expone su colección de subtítulos a través de [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_captiontracks/). Utilícelo para adjuntar subtítulos WebVTT al clip, exportar pistas existentes o eliminarlas.

### **Añadir subtítulos de audio**

El ejemplo incrusta un clip de audio en la primera diapositiva y utiliza [ICaptionsCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/add/) para adjuntar una pista WebVTT local. El primer argumento proporciona la etiqueta de la pista, y el segundo identifica el archivo que contiene los subtítulos cronometrados.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
```

### **Extraer subtítulos de audio**

Este ejemplo exporta cada pista de subtítulo adjunta a un marco de audio en la primera diapositiva. Escribe los bytes devueltos por [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_binarydata/) a un archivo WebVTT y utiliza el valor devuelto por [get_CaptionId](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_captionid/) como nombre de archivo para que cada pista tenga una salida separada.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto fileName = track->get_CaptionId().ToString() + u".vtt";
        File::WriteAllBytes(fileName, track->get_BinaryData());
    }
}
```

### **Eliminar subtítulos de audio**

Utilice [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/removeat/) para eliminar una pista individual. El ejemplo utiliza [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/clear/) para eliminar todos los subtítulos del primer marco de audio en la primera diapositiva mientras preserva el clip.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->get_CaptionTracks()->Clear();

    presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

### **Buscar una línea en los subtítulos de audio**

Para encontrar una línea en los subtítulos de audio de la primera diapositiva, llame a [get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) en cada pista para leer su texto WebVTT en memoria. En una señal WebVTT de texto plano, la línea de temporización contiene `-->`, las líneas de subtítulo la siguen, y una línea en blanco finaliza la señal. Este ejemplo muestra la etiqueta de la pista y cada línea de subtítulo que contiene “café”.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto reader = MakeObject<StringReader>(track->get_DataAsString());
        auto inCue = false;
        for (auto line = reader->ReadLine(); !line.IsNull(); line = reader->ReadLine())
        {
            if (line.get_Length() == 0)
                inCue = false;
            else if (line.Contains(u"-->"))
                inCue = true;
            else if (inCue && line.IndexOf(u"caf\u00e9", StringComparison::OrdinalIgnoreCase) >= 0)
                Console::WriteLine(track->get_Label() + u": " + line);
        }
    }
}
```

## **Extraer audio**

Una transición de diapositiva puede tener su propio sonido. Para recuperarlo, llame a [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_sound/) en la transición. El ejemplo recupera los bytes de audio con [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) y muestra el número de bytes. Si la primera diapositiva no tiene sonido de transición, muestra un mensaje en su lugar.

```cpp
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioSlide.pptx");
auto slide = presentation->get_Slide(0);

auto sound = slide->get_SlideShowTransition()->get_Sound();
if (sound)
{
    auto audioData = sound->get_BinaryData();
    Console::WriteLine(u"Transition sound: {0} bytes.", audioData->get_Length());
}
else
{
    Console::WriteLine(u"The first slide has no transition sound.");
}
```

## **Preguntas frecuentes**

**¿Puedo reutilizar el mismo clip de audio en varias diapositivas sin duplicarlo?**

Sí. Añada el clip una vez a la [colección de audio](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) de la presentación y pase el mismo objeto de audio a [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) para cada diapositiva.

**¿Puedo reemplazar el sonido en un marco de audio existente?**

Sí. Para un sonido enlazado, llame a [set_LinkPathLong](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_linkpathlong/) con la ruta al archivo de reemplazo. Para un sonido incrustado, pase otro clip de la colección de audio de la presentación a [set_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_embeddedaudio/). Ambos enfoques conservan el marco existente.

**¿El recorte modifica los datos de audio almacenados en la presentación?**

No. [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) y [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) establecen los límites de reproducción. Todavía puede recuperar el clip completo mediante [get_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_embeddedaudio/).