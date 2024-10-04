---
title: Marco de Audio
type: docs
weight: 10
url: /cpp/audio-frame/
keywords: "Agregar audio, Marco de audio, Propiedades de audio, Extraer audio, C++, CPP, Aspose.Slides para C++"
description: "Agregar audio a la presentación de PowerPoint en C++"
---

## **Creando un Marco de Audio**
Aspose.Slides para C++ te permite agregar archivos de audio a las diapositivas. Los archivos de audio se integran en las diapositivas como marcos de audio. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Carga el flujo del archivo de audio que deseas integrar en la diapositiva.
4. Agrega el marco de audio integrado (que contiene el archivo de audio) a la diapositiva.
5. Establece [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) y `Volume` expuestos por el objeto [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame).
6. Guarda la presentación modificada.

Este código C++ te muestra cómo agregar un marco de audio integrado a una diapositiva:

```cpp
// Instancia una clase Presentation que representa un archivo de presentación
auto pres = System::MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Carga el archivo de sonido wav en un flujo
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Agrega el Marco de Audio
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Establece el Modo de Reproducción y el Volumen del Audio
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Escribe el archivo de PowerPoint en el disco
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Cambiar la Miniatura del Marco de Audio**

Cuando agregas un archivo de audio a una presentación, el audio aparece como un marco con una imagen predeterminada estándar (ver la imagen en la sección siguiente). Puedes cambiar la miniatura del marco de audio (configura tu imagen preferida).

Este código C++ te muestra cómo cambiar la miniatura o la imagen de vista previa de un marco de audio:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Agrega un marco de audio a la diapositiva con una posición y tamaño específicos.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Agrega una imagen a los recursos de la presentación.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Establece la imagen para el marco de audio.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
// Guarda la presentación modificada en el disco
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Cambiar las Opciones de Reproducción de Audio**

Aspose.Slides para C++ te permite cambiar opciones que controlan la reproducción o propiedades de un audio. Por ejemplo, puedes ajustar el volumen de un audio, configurar el audio para que se reproduzca en bucle, o incluso ocultar el ícono de audio.

El panel de **Opciones de Audio** en Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Las opciones de Audio de PowerPoint que corresponden a los métodos [AudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame) de Aspose.Slides:
- La lista desplegable de **Inicio** de Opciones de Audio coincide con el método [AudioFrame::get_PlayMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a5379c1a9c1166234d674b32413215a2b) 
- **Volumen** de Opciones de Audio coincide con el método [AudioFrame::get_Volume()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#af06a3176684b6a13326bc8526747d9f3)  
- **Reproducir a través de Diapositivas** coincide con el método [AudioFrame::get_PlayAcrossSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a3c6ffc45b319ce127384fc37e188f7b0)  
- **Repetir hasta detenerse** coincide con el método [AudioFrame::get_PlayLoopMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a99b5b9cc650e93eba813bd8b2371315b)  
- **Ocultar durante la Presentación** coincide con el método [AudioFrame::get_HideAtShowing() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#abd008322e6a3d7d06bed527e329a9082)  
- **Retroceder después de Reproducir** coincide con el método [AudioFrame::get_RewindAudio() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a4900e1df6477db16e8cdd859ad54e637) 

Así es como cambias las opciones de Reproducción de Audio:

1. [Crear](#creating-audio-frame) o obtener el Marco de Audio.
2. Establece nuevos valores para las propiedades del Marco de Audio que deseas ajustar.
3. Guarda el archivo de PowerPoint modificado.

Este código C++ demuestra una operación en la que se ajustan las opciones de un audio:

```cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Obtiene una forma
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Convierte la forma a un marco de AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Establece el modo de Reproducción para reproducir al hacer clic
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Establece el Volumen en Bajo
audioFrame->set_Volume(AudioVolumeMode::Low);

// Establece el audio para reproducir a través de las diapositivas
audioFrame->set_PlayAcrossSlides(true);

// Deshabilita el bucle para el audio
audioFrame->set_PlayLoopMode(false);

// Oculta el AudioFrame durante la presentación
audioFrame->set_HideAtShowing(true);

// Retrocede el audio al inicio después de reproducir
audioFrame->set_RewindAudio(true);

// Guarda el archivo de PowerPoint en el disco
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

## **Extraer Audio**
Aspose.Slides para .NET te permite extraer el sonido utilizado en las transiciones de la presentación. Por ejemplo, puedes extraer el sonido utilizado en una diapositiva específica.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) y carga la presentación que contiene el audio.
2. Obtén la referencia de la diapositiva correspondiente a través de su índice.
3. Accede a las transiciones de la presentación para la diapositiva.
4. Extrae el sonido en datos de bytes.

Este código C++ te muestra cómo extraer el audio usado en una diapositiva:

```cpp
String presName = u"AudioSlide.pptx";

// Instancia una clase Presentation que representa un archivo de presentación
auto pres = System::MakeObject<Presentation>(presName);

// Accede a la diapositiva deseada
auto slide = pres->get_Slides()->idx_get(0);

// Obtiene los efectos de transición de la presentación para la diapositiva
auto transition = slide->get_SlideShowTransition();

// Extrae el sonido en un arreglo de bytes
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Longitud: ") + audio->get_Length());
```