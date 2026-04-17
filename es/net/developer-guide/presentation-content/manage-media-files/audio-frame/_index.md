---
title: Gestionar marcos de audio en presentaciones en .NET
linktitle: Marco de audio
type: docs
weight: 10
url: /es/net/audio-frame/
keywords:
- audio
- marco de audio
- miniatura
- agregar audio
- propiedades de audio
- opciones de audio
- extraer audio
- .NET
- C#
- Aspose.Slides
description: "Crear y controlar marcos de audio en Aspose.Slides para .NET—ejemplos en C# para incrustar, recortar, reproducir en bucle y configurar la reproducción en presentaciones PPT, PPTX y ODP."
---
## **Crear marcos de audio**

Aspose.Slides for .NET permite agregar archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como marcos de audio. 

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Obtenga una referencia a una diapositiva a través de su índice.
3. Cargue la transmisión del archivo de audio que desea incrustar en la diapositiva.
4. Agregue el marco de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Establezca [PlayMode](https://reference.aspose.com/slides/es/net/aspose.slides/audioplaymodepreset) y `Volume` expuestos por el objeto [IAudioFrame](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe).
6. Guarde la presentación modificada.

Este código C# muestra cómo agregar un marco de audio incrustado a una diapositiva:

```c#
// Instancia una clase de presentación que representa un archivo de presentación
using (Presentation pres = new Presentation())
{
    // Obtiene la primera diapositiva
    ISlide sld = pres.Slides[0];
    
    // Carga el archivo de sonido wav en un flujo
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Añade el marco de audio
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Establece el modo de reproducción y el volumen del audio
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Escribe el archivo PowerPoint en disco
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Cambiar la miniatura del marco de audio**

Al agregar un archivo de audio a una presentación, el audio aparece como un marco con una imagen predeterminada estándar (ver la imagen en la sección siguiente). Puede cambiar la miniatura del marco de audio (establecer la imagen que prefiera).

Este código C# muestra cómo cambiar la miniatura o la imagen de vista previa de un marco de audio:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Añade un marco de audio a la diapositiva con una posición y tamaño especificados.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Añade una imagen a los recursos de la presentación.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Establece la imagen para el marco de audio.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
    //Guarda la presentación modificada en disco
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Cambiar opciones de reproducción de audio**

Aspose.Slides for .NET permite cambiar opciones que controlan la reproducción o las propiedades de un audio. Por ejemplo, puede ajustar el volumen, establecer la reproducción en bucle o incluso ocultar el icono de audio.

El panel **Opciones de audio** en Microsoft PowerPoint:

![ejemplo1_imagen](audio_frame_0.png)

Las **Opciones de audio** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe) :

- **Inicio** corresponde a la propiedad [AudioFrame.PlayMode](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/properties/playmode)  
- **Volumen** corresponde a la propiedad [AudioFrame.Volume](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/properties/volume)  
- **Reproducir a través de diapositivas** corresponde a la propiedad [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/properties/playacrossslides)  
- **Repetir hasta detenerse** corresponde a la propiedad [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/properties/playloopmode)  
- **Ocultar durante la presentación** corresponde a la propiedad [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/properties/hideatshowing)  
- **Rebobinar después de reproducir** corresponde a la propiedad [AudioFrame.RewindAudio](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/properties/rewindaudio)  

Las opciones de **Edición** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe) :

- **Desvanecer entrada** corresponde a la propiedad [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/fadeinduration/)  
- **Desvanecer salida** corresponde a la propiedad [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/fadeoutduration/)  
- **Recortar tiempo de inicio del audio** corresponde a la propiedad [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/trimfromstart/)  
- **Recortar tiempo de fin del audio** el valor equivale a la duración del audio menos el valor de la propiedad [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/trimfromend/)  

El **control de volumen** de PowerPoint en el panel de control de audio corresponde a la propiedad [AudioFrame.VolumeValue](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/volumevalue/). Permite cambiar el volumen del audio como porcentaje.

Así es como se cambian las opciones de reproducción de audio:

1. [Сreate](#create-audio-frame) o obtenga el marco de audio.  
2. Establezca nuevos valores para las propiedades del marco de audio que desea ajustar.  
3. Guarde el archivo de PowerPoint modificado.

Este código C# demuestra una operación en la que se ajustan las opciones de un audio:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Obtiene la forma AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Establece el modo de reproducción a reproducir al hacer clic
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Establece el volumen a Bajo
    audioFrame.Volume = AudioVolumeMode.Low;

    // Configura el audio para reproducirse a través de diapositivas
    audioFrame.PlayAcrossSlides = true;

    // Desactiva el bucle para el audio
    audioFrame.PlayLoopMode = false;

    // Oculta el AudioFrame durante la presentación
    audioFrame.HideAtShowing = true;

    // Rebobina el audio al inicio después de reproducir
    audioFrame.RewindAudio = true;

    // Guarda el archivo PowerPoint en disco
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Este ejemplo C# muestra cómo agregar un nuevo marco de audio con audio incrustado, recortarlo y establecer duraciones de desvanecimiento:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Establece el desplazamiento de inicio del recorte a 1.5 segundos
    audioFrame.TrimFromStart = 1500f;
    // Establece el desplazamiento de fin del recorte a 2 segundos
    audioFrame.TrimFromEnd = 2000f;

    // Establece la duración del fundido de entrada a 200 ms
    audioFrame.FadeInDuration = 200f;
    // Establece la duración del fundido de salida a 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

El siguiente fragmento de código muestra cómo recuperar un marco de audio incrustado y establecer su volumen al 85 %:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Obtiene una forma de marco de audio
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Establece el volumen del audio al 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Administrar subtítulos de audio**

Aspose.Slides permite agregar subtítulos cerrados a un marco de audio mediante la propiedad [CaptionTracks](https://reference.aspose.com/slides/es/net/aspose.slides/iaudioframe/captiontracks/). Esta propiedad devuelve una [ICaptionsCollection](https://reference.aspose.com/slides/es/net/aspose.slides/icaptionscollection/), que permite agregar pistas de subtítulos WebVTT, iterar sobre las existentes y eliminarlas cuando sea necesario.

**Agregar subtítulos de audio**

Utilice la propiedad [CaptionTracks](https://reference.aspose.com/slides/es/net/aspose.slides/iaudioframe/captiontracks/) para adjuntar una o más pistas de subtítulos a un marco de audio. En el siguiente ejemplo, se agrega un archivo de audio a una diapositiva y luego se carga una nueva pista de subtítulos desde un archivo `.vtt`.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Añade una nueva pista de subtítulos desde un archivo WebVTT.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Extraer subtítulos de audio**

Puede iterar a través de las pistas de subtítulos asociadas a un marco de audio y guardarlas como archivos `.vtt`. Cada pista de subtítulos expone sus datos binarios y su identificador único, que pueden usarse al exportar los subtítulos.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // Guarda la pista de subtítulos como un archivo .vtt.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Eliminar subtítulos de audio**

Para eliminar los subtítulos de un marco de audio, use los métodos proporcionados por [ICaptionsCollection](https://reference.aspose.com/slides/es/net/aspose.slides/icaptionscollection/), como [Clear](https://reference.aspose.com/slides/es/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/es/net/aspose.slides/icaptionscollection/remove/), o [RemoveAt](https://reference.aspose.com/slides/es/net/aspose.slides/icaptionscollection/removeat/). El siguiente ejemplo elimina todas las pistas de subtítulos de un marco de audio.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Elimina todas las pistas de subtítulos del marco de audio.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Extraer audio**
Aspose.Slides for .NET permite extraer el sonido usado en las transiciones de la presentación. Por ejemplo, puede extraer el sonido usado en una diapositiva específica.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) y cargue la presentación que contiene el audio.  
2. Obtenga la referencia de la diapositiva correspondiente a través de su índice.  
3. Acceda a las transiciones de la presentación para esa diapositiva.  
4. Extraiga el sonido en datos de bytes.

Este código C# muestra cómo extraer el audio usado en una diapositiva:

```c#
string presName = "AudioSlide.pptx";

// Instancia una clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation(presName);

// Accede a la diapositiva
ISlide slide = pres.Slides[0];

// Obtiene los efectos de transición de la presentación para la diapositiva
ISlideShowTransition transition = slide.SlideShowTransition;

// Extrae el sonido en un array de bytes
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **Preguntas frecuentes**

**¿Puedo reutilizar el mismo recurso de audio en varias diapositivas sin inflar el tamaño del archivo?**

Sí. Añada el audio una única vez a la [colección de audio compartida](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/audios/) de la presentación y cree marcos de audio adicionales que referencien ese recurso existente. Así se evita duplicar los datos multimedia y se mantiene bajo control el tamaño de la presentación.

**¿Puedo reemplazar el sonido en un marco de audio existente sin recrear la forma?**

Sí. Para un sonido enlazado, actualice la [ruta del enlace](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/linkpathlong/) para que apunte al nuevo archivo. Para un sonido incrustado, reemplace el objeto [audio incrustado](https://reference.aspose.com/slides/es/net/aspose.slides/audioframe/embeddedaudio/) por otro de la [colección de audio](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/audios/) de la presentación. El formato del marco y la mayoría de los ajustes de reproducción permanecen intactos.

**¿El recorte cambia los datos de audio subyacentes almacenados en la presentación?**

No. El recorte solo ajusta los límites de reproducción. Los bytes originales del audio permanecen sin modificar y son accesibles a través del audio incrustado o de la colección de audio de la presentación.