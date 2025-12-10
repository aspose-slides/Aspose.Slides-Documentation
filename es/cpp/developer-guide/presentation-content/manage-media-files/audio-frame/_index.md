---
title: Administrar audio en presentaciones usando C++
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
description: "Crear y controlar marcos de audio en Aspose.Slides para C++ — ejemplos de código para incrustar, recortar, reproducir en bucle y configurar la reproducción en presentaciones PPT, PPTX y ODP."
---

## **Crear fotogramas de audio**

Aspose.Slides for C++ permite agregar archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como fotogramas de audio. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Cargue el flujo del archivo de audio que desea incrustar en la diapositiva.
4. Añada el fotograma de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Establezca [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) y `Volume` expuestos por el objeto [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame).
6. Guarde la presentación modificada.

Este código C++ le muestra cómo añadir un fotograma de audio incrustado a una diapositiva:
```cpp
// Instancia una clase Presentation que representa un archivo de presentación
auto pres = System::MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Carga el archivo de sonido wav en un flujo
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Añade el marco de audio
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Establece el modo de reproducción y el volumen del audio
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Escribe el archivo PowerPoint en disco
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```


## **Cambiar la miniatura del fotograma de audio**

Cuando agrega un archivo de audio a una presentación, el audio aparece como un fotograma con una imagen predeterminada estándar (ver la imagen en la sección siguiente). Puede cambiar la miniatura del fotograma de audio (establecer su imagen preferida).

Este código C++ le muestra cómo cambiar la miniatura o imagen de vista previa de un fotograma de audio:
```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Agrega un fotograma de audio a la diapositiva con una posición y tamaño especificados.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Agrega una imagen a los recursos de la presentación.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Establece la imagen para el fotograma de audio.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Guarda la presentación modificada en disco
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Cambiar opciones de reproducción de audio**

Aspose.Slides for C++ permite cambiar las opciones que controlan la reproducción o propiedades de un audio. Por ejemplo, puede ajustar el volumen del audio, configurarlo para que se reproduzca en bucle o incluso ocultar el ícono de audio.

El panel **Audio Options** en Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Las **Audio Options** de PowerPoint que corresponden a los métodos de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/) :

- **Start** lista desplegable coincide con el método [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playmode/) 
- **Volume** coincide con el método [AudioFrame::set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volume/) 
- **Play Across Slides** coincide con el método [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playacrossslides/) 
- **Loop until Stopped** coincide con el método [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playloopmode/) 
- **Hide During Show** coincide con el método [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_hideatshowing/) 
- **Rewind after Playing** coincide con el método [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_rewindaudio/) 

Opciones de **Editing** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/) :

- **Fade In** coincide con el método [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeinduration/) 
- **Fade Out** coincide con el método [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeoutduration/) 
- **Trim Audio Start Time** coincide con el método [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromstart/) 
- **Trim Audio End Time** el valor es igual a la duración del audio menos el valor del método [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromend/) 

El **Volume controll** de PowerPoint en el panel de control de audio corresponde al método [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volumevalue/). Permite cambiar el volumen del audio como porcentaje.

Así es como se cambian las opciones de reproducción de audio:

1. [Crear](#creating-audio-frame) o obtenga el fotograma de audio.
2. Establezca nuevos valores para las propiedades del fotograma de audio que desea ajustar.
3. Guarde el archivo PowerPoint modificado.

Este código C++ muestra una operación en la que se ajustan las opciones de un audio:
```cpp
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Obtener una forma
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Convierte la forma a un AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Establece el modo de reproducción a reproducir al hacer clic
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Establece el volumen a bajo
audioFrame->set_Volume(AudioVolumeMode::Low);

// Establece el audio para reproducirse a través de diapositivas
audioFrame->set_PlayAcrossSlides(true);

// Desactiva el bucle para el audio
audioFrame->set_PlayLoopMode(false);

// Oculta el AudioFrame durante la presentación
audioFrame->set_HideAtShowing(true);

// Retrocede el audio al inicio después de reproducir
audioFrame->set_RewindAudio(true);

// Guarda el archivo PowerPoint en disco
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```


Este ejemplo C++ muestra cómo añadir un nuevo fotograma de audio con audio incrustado, recortarlo y establecer las duraciones de fundido:
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


El siguiente ejemplo de código muestra cómo obtener un fotograma de audio con audio incrustado y establecer su volumen al 85%:
```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Obtiene una forma de fotograma de audio
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Establece el volumen del audio al 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


## **Extraer audio**

Aspose.Slides permite extraer el sonido utilizado en las transiciones de la presentación. Por ejemplo, puede extraer el sonido usado en una diapositiva específica.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) y cargue la presentación que contiene el audio.
2. Obtenga la referencia de la diapositiva correspondiente mediante su índice.
3. Acceda a las transiciones de diapositivas para esa diapositiva.
4. Extraiga el sonido en datos de bytes.

Este código C++ le muestra cómo extraer el audio usado en una diapositiva:
``` cpp
String presName = u"AudioSlide.pptx";

// Instancia una clase Presentation que representa un archivo de presentación
auto pres = System::MakeObject<Presentation>(presName);

// Accede a la diapositiva deseada
auto slide = pres->get_Slides()->idx_get(0);

// Obtiene los efectos de transición de diapositiva para la diapositiva
auto transition = slide->get_SlideShowTransition();

// Extrae el sonido en un arreglo de bytes
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```


## **FAQ**

**¿Puedo reutilizar el mismo recurso de audio en varias diapositivas sin inflar el tamaño del archivo?**

Sí. Añada el audio una sola vez a la presentación → [colección de audio](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) compartida y cree fotogramas de audio adicionales que referencien ese recurso existente. Esto evita duplicar los datos multimedia y mantiene el tamaño de la presentación bajo control.

**¿Puedo reemplazar el sonido en un fotograma de audio existente sin recrear la forma?**

Sí. Para un sonido enlazado, actualice la [ruta del enlace](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_linkpathlong/) para que apunte al nuevo archivo. Para un sonido incrustado, reemplace el objeto [audio incrustado](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_embeddedaudio/) por otro de la [colección de audio](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) de la presentación. El formato del fotograma y la mayoría de los ajustes de reproducción permanecen intactos.

**¿El recorte modifica los datos de audio subyacentes almacenados en la presentación?**

No. El recorte solo ajusta los límites de reproducción. Los bytes originales del audio permanecen sin cambios y son accesibles a través del audio incrustado o la colección de audio de la presentación.