---
title: Audio Frame - Insertar y extraer audio en PowerPoint usando C#
linktitle: Audio Frame
type: docs
weight: 10
url: /es/net/audio-frame/
keywords: "imagen en miniatura de audio, Añadir audio, Marco de audio, Propiedades de audio, Extraer audio, C#, Csharp, Aspose.Slides para .NET"
description: "Añadir audio a la presentación de PowerPoint en C# o .NET"
---

## **Crear marco de audio**
Aspose.Slides para .NET te permite añadir archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como marcos de audio.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Carga el flujo del archivo de audio que deseas incrustar en la diapositiva.
4. Añade el marco de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Establece el [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) y el `Volume` expuestos por el objeto [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe).
6. Guarda la presentación modificada.

Este código C# te muestra cómo añadir un marco de audio incrustado a una diapositiva:

```c#
// Instancia una clase de presentación que representa un archivo de presentación
using (Presentation pres = new Presentation())
{
    // Obtiene la primera diapositiva
    ISlide sld = pres.Slides[0];
    
    // Carga el archivo de sonido wav en el flujo
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Añade el marco de audio
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Establece el modo de reproducción y el volumen del audio
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Escribe el archivo de PowerPoint en el disco
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Cambiar la miniatura del marco de audio**

Cuando añades un archivo de audio a una presentación, el audio aparece como un marco con una imagen estándar por defecto (ve la imagen en la sección a continuación). Puedes cambiar la miniatura del marco de audio (establece tu imagen preferida).

Este código C# te muestra cómo cambiar la miniatura o la imagen de vista previa de un marco de audio:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Añade un marco de audio a la diapositiva con una posición y tamaño especificados.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Añade una imagen a los recursos de presentación.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Establece la imagen para el marco de audio.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	// Guarda la presentación modificada en el disco
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Cambiar opciones de reproducción de audio**

Aspose.Slides para .NET te permite cambiar opciones que controlan la reproducción o propiedades de un audio. Por ejemplo, puedes ajustar el volumen de un audio, establecer la reproducción en bucle o incluso ocultar el icono del audio.

El panel de **Opciones de audio** en Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opciones de audio de PowerPoint que corresponden a las propiedades de [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe):

- El menú desplegable de opciones de audio **Inicio** coincide con la propiedad [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) 
- Las opciones de audio **Volumen** coinciden con la propiedad [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) 
- Las opciones de audio **Reproducir entre diapositivas** coinciden con la propiedad [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) 
- Las opciones de audio **Repetir hasta detener** coinciden con la propiedad [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) 
- Las opciones de audio **Ocultar durante la presentación** coinciden con la propiedad [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) 
- Las opciones de audio **Rebobinar después de reproducir** coinciden con la propiedad [AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) 

Así es como cambias las opciones de reproducción de audio:

1. [Crear](#create-audio-frame) o obtener el marco de audio.
2. Establece nuevos valores para las propiedades del marco de audio que deseas ajustar.
3. Guarda el archivo de PowerPoint modificado.

Este código C# demuestra una operación en la que se ajustan las opciones de un audio:

```csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Obtiene la forma AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Establece el modo de reproducción para que se reproduzca al hacer clic
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Establece el volumen en bajo
    audioFrame.Volume = AudioVolumeMode.Low;

    // Establece el audio para reproducirse entre diapositivas
    audioFrame.PlayAcrossSlides = true;

    // Desactiva el bucle para el audio
    audioFrame.PlayLoopMode = false;

    // Oculta el AudioFrame durante la presentación de diapositivas
    audioFrame.HideAtShowing = true;

    // Rebobina el audio al inicio después de reproducir
    audioFrame.RewindAudio = true;

    // Guarda el archivo de PowerPoint en el disco
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

## **Extraer audio**
Aspose.Slides para .NET te permite extraer el sonido utilizado en las transiciones de la presentación. Por ejemplo, puedes extraer el sonido utilizado en una diapositiva específica.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y carga la presentación que contiene el audio.
2. Obtén la referencia de la diapositiva relevante a través de su índice.
3. Accede a las transiciones de presentación para la diapositiva.
4. Extrae el sonido en datos de bytes.

Este código C# te muestra cómo extraer el audio utilizado en una diapositiva:

```c#
string presName = "AudioSlide.pptx";

// Instancia una clase de presentación que representa un archivo de presentación
Presentation pres = new Presentation(presName);

// Accede a la diapositiva
ISlide slide = pres.Slides[0];

// Obtiene los efectos de transición de presentación para la diapositiva
ISlideShowTransition transition = slide.SlideShowTransition;

// Extrae el sonido en un arreglo de bytes
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Longitud: " + audio.Length);
```