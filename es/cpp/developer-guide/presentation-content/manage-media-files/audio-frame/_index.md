---
title: Gestionar audio en presentaciones con C++
linktitle: Fotograma de audio
type: docs
weight: 10
url: /es/cpp/audio-frame/
keywords:
- audio
- fotograma de audio
- miniatura
- añadir audio
- propiedades del audio
- opciones de audio
- extraer audio
- C++
- Aspose.Slides
description: "Crear y controlar fotogramas de audio en Aspose.Slides para C++ — ejemplos de código para incrustar, recortar, reproducir en bucle y configurar la reproducción en presentaciones PPT, PPTX y ODP."
---
## **Crear fotogramas de audio**

Aspose.Slides para C++ le permite añadir archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como fotogramas de audio. 

1. Cree una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Cargue el flujo del archivo de audio que desea incrustar en la diapositiva.
4. Añada el fotograma de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Establezca [PlayMode](https://reference.aspose.com/slides/es/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) y `Volume` expuestos por el objeto [IAudioFrame](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_audio_frame).
6. Guarde la presentación modificada.

Este código C++ le muestra cómo añadir un fotograma de audio incrustado a una diapositiva:

``` cpp
// Instancia una clase Presentation que representa un archivo de presentación
auto pres = System::MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Carga el archivo de sonido wav en un flujo
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Añade el fotograma de audio
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Establece el modo de reproducción y el volumen del audio
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Escribe el archivo PowerPoint en disco
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Cambiar la miniatura del fotograma de audio**

Al añadir un archivo de audio a una presentación, el audio se muestra como un fotograma con una imagen predeterminada estándar (ver la imagen en la sección siguiente). Puede cambiar la miniatura del fotograma de audio (establecer la imagen que prefiera).

Este código C++ le muestra cómo cambiar la miniatura o la imagen de vista previa de un fotograma de audio:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Añade un fotograma de audio a la diapositiva con una posición y tamaño especificados.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Añade una imagen a los recursos de la presentación.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Establece la imagen para el fotograma de audio.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Guarda la presentación modificada en disco
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Cambiar opciones de reproducción de audio**

Aspose.Slides para C++ le permite cambiar opciones que controlan la reproducción o propiedades de un audio. Por ejemplo, puede ajustar el volumen del audio, establecer que el audio se reproduzca en bucle, o incluso ocultar el icono de audio.

El panel **Opciones de audio** en Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opciones de **Audio** de PowerPoint que corresponden a los métodos de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/) :

- **Inicio** la lista desplegable coincide con el método [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_playmode/) 
- **Volumen** coincide con el método [AudioFrame::set_Volume](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_volume/) 
- **Reproducir en todas las diapositivas** coincide con el método [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_playacrossslides/) 
- **Repetir hasta detenerse** coincide con el método [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_playloopmode/) 
- **Ocultar durante la presentación** coincide con el método [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_hideatshowing/) 
- **Rebobinar después de reproducir** coincide con el método [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_rewindaudio/) 

Opciones de **Edición** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/) :

- **Desvanecer al iniciar** coincide con el método [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_fadeinduration/) 
- **Desvanecer al terminar** coincide con el método [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_fadeoutduration/) 
- **Recortar tiempo de inicio del audio** coincide con el método [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_trimfromstart/) 
- **Recortar tiempo de fin del audio** el valor equivale a la duración del audio menos el valor del método [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_trimfromend/) 

El **control de volumen** de PowerPoint en el panel de control de audio corresponde al método [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_volumevalue/) . Le permite cambiar el volumen del audio como un porcentaje.

Así es como se cambian las opciones de reproducción del audio:

1. [Crear](#creating-audio-frame) o obtener el fotograma de audio.
2. Establezca nuevos valores para las propiedades del fotograma de audio que desea ajustar.
3. Guarde el archivo PowerPoint modificado.

Este código C++ muestra una operación en la que se ajustan las opciones de un audio:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Obtiene una forma
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Convierte la forma a un fotograma de audio
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Establece el modo de reproducción para reproducir al hacer clic
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Establece el volumen a bajo
audioFrame->set_Volume(AudioVolumeMode::Low);

// Establece que el audio se reproduzca en todas las diapositivas
audioFrame->set_PlayAcrossSlides(true);

// Desactiva el bucle para el audio
audioFrame->set_PlayLoopMode(false);

// Oculta el fotograma de audio durante la presentación
audioFrame->set_HideAtShowing(true);

// Retrocede el audio al inicio después de reproducir
audioFrame->set_RewindAudio(true);

// Guarda el archivo PowerPoint en disco
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Este ejemplo C++ muestra cómo añadir un nuevo fotograma de audio con audio incrustado, recortarlo y establecer las duraciones de desvanecimiento:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

El siguiente fragmento de código muestra cómo obtener un fotograma de audio con audio incrustado y establecer su volumen al 85%:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Obtiene una forma de fotograma de audio
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Establece el volumen del audio al 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Gestionar subtítulos de audio**

Aspose.Slides le permite añadir subtítulos cerrados a un fotograma de audio mediante el método [get_CaptionTracks](https://reference.aspose.com/slides/es/cpp/aspose.slides/iaudioframe/get_captiontracks/) . Este método devuelve una [ICaptionsCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/), que le permite añadir pistas de subtítulos WebVTT, iterar a través de las pistas existentes y eliminarlas cuando sea necesario.

### **Añadir subtítulos de audio**

Utilice el método [get_CaptionTracks](https://reference.aspose.com/slides/es/cpp/aspose.slides/iaudioframe/get_captiontracks/) para adjuntar una o más pistas de subtítulos a un fotograma de audio. En el ejemplo siguiente, se añade un archivo de audio a una diapositiva y, a continuación, se carga una nueva pista de subtítulos desde un archivo `.vtt`.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Extraer subtítulos de audio**

Puede iterar a través de las pistas de subtítulos asociadas a un fotograma de audio y guardarlas como archivos `.vtt`. Cada pista de subtítulos expone sus datos binarios y su identificador único, que pueden usarse al exportar subtítulos.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // Guarda cada pista de subtítulos como un archivo .vtt.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

### **Eliminar subtítulos de audio**

Para eliminar los subtítulos de un fotograma de audio, utilice los métodos proporcionados por [ICaptionsCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/), como [Clear](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/remove/), o [RemoveAt](https://reference.aspose.com/slides/es/cpp/aspose.slides/icaptionscollection/removeat/). El siguiente ejemplo elimina todas las pistas de subtítulos de un fotograma de audio.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Elimina todas las pistas de subtítulos del fotograma de audio.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Extraer audio**

Aspose.Slides le permite extraer el sonido utilizado en las transiciones de la presentación de diapositivas. Por ejemplo, puede extraer el sonido usado en una diapositiva concreta.

1. Cree una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation) y cargue la presentación que contiene el audio.
2. Obtenga la referencia de la diapositiva relevante mediante su índice.
3. Acceda a las transiciones de la presentación para la diapositiva.
4. Extraiga el sonido como datos binarios.

Este código C++ le muestra cómo extraer el audio usado en una diapositiva:

``` cpp
String presName = u"AudioSlide.pptx";

// Instancia una clase Presentation que representa un archivo de presentación
auto pres = System::MakeObject<Presentation>(presName);

// Accede a la diapositiva deseada
auto slide = pres->get_Slides()->idx_get(0);

// Obtiene los efectos de transición de la presentación para la diapositiva
auto transition = slide->get_SlideShowTransition();

// Extrae el sonido en un arreglo de bytes
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**¿Puedo reutilizar el mismo recurso de audio en varias diapositivas sin aumentar el tamaño del archivo?**

Sí. Añada el audio una sola vez a la [colección de audio] compartida de la presentación y cree fotogramas de audio adicionales que referencien ese recurso existente. Así se evita duplicar los datos multimedia y se mantiene el tamaño de la presentación bajo control.

**¿Puedo sustituir el sonido en un fotograma de audio existente sin volver a crear la forma?**

Sí. Para un sonido enlazado, actualice la [ruta del vínculo](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_linkpathlong/) para que apunte al nuevo archivo. Para un sonido incrustado, reemplace el objeto [embedded audio](https://reference.aspose.com/slides/es/cpp/aspose.slides/audioframe/set_embeddedaudio/) por otro de la [colección de audio] de la presentación. El formato del fotograma y la mayoría de los ajustes de reproducción permanecen intactos.

**¿El recorte modifica los datos de audio subyacentes almacenados en la presentación?**

No. El recorte solo ajusta los límites de reproducción. Los bytes originales del audio permanecen sin cambios y accesibles mediante el audio incrustado o la colección de audio de la presentación.