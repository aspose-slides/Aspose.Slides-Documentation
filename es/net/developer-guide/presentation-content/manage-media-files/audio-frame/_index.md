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
description: "Cree y controle marcos de audio en Aspose.Slides para .NET: ejemplos en C# para incrustar, recortar, reproducir en bucle y configurar la reproducción en presentaciones PPT, PPTX y ODP."
---

## **Crear marcos de audio**

Aspose.Slides for .NET le permite agregar archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como marcos de audio. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Cargue el flujo del archivo de audio que desea incrustar en la diapositiva.
4. Agregue el marco de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Establezca [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) y `Volume` expuestos por el objeto [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe).
6. Guarde la presentación modificada.

Este código C# le muestra cómo agregar un marco de audio incrustado a una diapositiva:
```c#
 // Instancia una clase de presentación que representa un archivo de presentación
 using (Presentation pres = new Presentation())
 {
     // Obtiene la primera diapositiva
     ISlide sld = pres.Slides[0];
     
     // Carga el archivo de sonido wav en un flujo
     FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

     // Agrega el marco de audio
     IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

     // Establece el modo de reproducción y el volumen del audio
     audioFrame.PlayMode = AudioPlayModePreset.Auto;
     audioFrame.Volume = AudioVolumeMode.Loud;

     // Escribe el archivo PowerPoint en disco
     pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
 }
```


## **Cambiar miniatura del marco de audio**

Al agregar un archivo de audio a una presentación, el audio aparece como un marco con una imagen predeterminada estándar (ver la imagen en la sección a continuación). Cambie la miniatura del marco de audio (establezca su imagen preferida).

Este código C# le muestra cómo cambiar la miniatura o la imagen de vista previa de un marco de audio:
```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Agrega un marco de audio a la diapositiva con una posición y tamaño especificados.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Agrega una imagen a los recursos de la presentación.
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

Aspose.Slides for .NET le permite cambiar opciones que controlan la reproducción o las propiedades de un audio. Por ejemplo, puede ajustar el volumen del audio, configurarlo para que se reproduzca en bucle o incluso ocultar el ícono del audio.

El panel **Audio Options** en Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** que corresponde a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) :

- **Start** menú desplegable coincide con la propiedad [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode)
- **Volume** coincide con la propiedad [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume)
- **Play Across Slides** coincide con la propiedad [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides)
- **Loop until Stopped** coincide con la propiedad [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode)
- **Hide During Show** coincide con la propiedad [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing)
- **Rewind after Playing** coincide con la propiedad [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio)

Opciones de **Editing** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) :

- **Fade In** coincide con la propiedad [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/)
- **Fade Out** coincide con la propiedad [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/)
- **Trim Audio Start Time** coincide con la propiedad [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/)
- **Trim Audio End Time** valor equivale a la duración del audio menos el valor de [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/)

El **Volume controll** de PowerPoint en el panel de control de audio corresponde a la propiedad [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/). Le permite cambiar el volumen del audio como un porcentaje.

Así es como se cambian las opciones de reproducción de audio:

1. [Crear](#create-audio-frame) o obtenga el Audio Frame.
2. Establezca nuevos valores para las propiedades del Audio Frame que desea ajustar.
3. Guarde el archivo PowerPoint modificado.

Este código C# demuestra una operación en la que se ajustan las opciones de un audio:
``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Obtiene la forma AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Establece el modo de reproducción para reproducir al hacer clic
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Establece el volumen a Bajo
    audioFrame.Volume = AudioVolumeMode.Low;

    // Establece que el audio se reproduzca a través de las diapositivas
    audioFrame.PlayAcrossSlides = true;

    // Desactiva el bucle para el audio
    audioFrame.PlayLoopMode = false;

    // Oculta el AudioFrame durante la presentación
    audioFrame.HideAtShowing = true;

    // Retrocede el audio al inicio después de reproducir
    audioFrame.RewindAudio = true;

    // Guarda el archivo PowerPoint en disco
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```


Este ejemplo C# muestra cómo agregar un nuevo marco de audio con audio incrustado, recortarlo y establecer las duraciones de desvanecimiento:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Establece el desplazamiento de inicio del recorte a 1,5 segundos
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


El siguiente fragmento de código muestra cómo obtener un marco de audio con audio incrustado y establecer su volumen al 85%:
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


## **Extraer audio**

Aspose.Slides for .NET le permite extraer el sonido utilizado en transiciones de presentación. Por ejemplo, puede extraer el sonido usado en una diapositiva específica.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargue la presentación que contiene el audio.
2. Obtenga una referencia a la diapositiva correspondiente mediante su índice.
3. Acceda a las transiciones de diapositivas para la diapositiva.
4. Extraiga el sonido en datos de bytes.

Este código C# le muestra cómo extraer el audio usado en una diapositiva:
```c#
string presName = "AudioSlide.pptx";

// Instancia una clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation(presName);

// Accede a la diapositiva
ISlide slide = pres.Slides[0];

// Obtiene los efectos de transición de la presentación para la diapositiva
ISlideShowTransition transition = slide.SlideShowTransition;

//Extrae el sonido en un array de bytes
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```


## **FAQ**

**¿Puedo reutilizar el mismo recurso de audio en varias diapositivas sin inflar el tamaño del archivo?**

Sí. Agregue el audio una sola vez a la [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) compartida de la presentación y cree marcos de audio adicionales que referencien ese recurso existente. Esto evita duplicar los datos multimedia y mantiene el tamaño de la presentación bajo control.

**¿Puedo reemplazar el sonido en un marco de audio existente sin recrear la forma?**

Sí. Para un sonido vinculado, actualice el [link path](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/) para que apunte al nuevo archivo. Para un sonido incrustado, reemplace el objeto [embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/) por otro de la [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) de la presentación. El formato del marco y la mayoría de la configuración de reproducción permanecen intactos.

**¿El recorte cambia los datos de audio subyacentes almacenados en la presentación?**

No. El recorte ajusta solo los límites de reproducción. Los bytes originales del audio permanecen sin modificar y son accesibles a través del audio incrustado o la colección de audio de la presentación.