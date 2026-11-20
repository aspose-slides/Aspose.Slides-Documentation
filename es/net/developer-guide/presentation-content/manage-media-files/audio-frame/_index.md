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
- añadir audio
- propiedades de audio
- opciones de audio
- extraer audio
- .NET
- C#
- Aspose.Slides
description: "Incruste audio en diapositivas, cambie el ícono de audio, configure la reproducción, gestione subtítulos WebVTT y extraiga sonidos de transición de diapositivas con Aspose.Slides para .NET."
---
## **Visión general**

Un marco de audio le permite reproducir un sonido en una diapositiva. Con Aspose.Slides para .NET, puede incrustar un clip de audio, elegir la imagen que lo representa, ajustar la reproducción y adjuntar subtítulos. También puede obtener un sonido asignado a una transición de diapositiva.

## **Crear marcos de audio**

Utilice [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) para incrustar un clip de audio local en la primera diapositiva. Las dos primeras coordenadas posicionan el marco en la diapositiva, y los dos valores siguientes establecen su ancho y alto, todos en puntos. Este ejemplo establece [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) para iniciar el clip automáticamente y [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) al preset alto.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **Cambiar la miniatura del marco de audio**

De forma predeterminada, un marco de audio muestra un ícono de altavoz. Para mostrar una miniatura personalizada, añada una imagen a la presentación con [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) y asígnela a la propiedad [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) del marco. El ejemplo utiliza un JPEG como miniatura para un clip de audio incrustado.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **Cambiar opciones de reproducción de audio**

Los controles de **Audio Options** de PowerPoint determinan cuándo comienza un clip, cuán alto suena y cómo se comporta durante una presentación.

![Controles de Audio Options de PowerPoint para un marco de audio](audio_frame_0.png)

| Control de PowerPoint | Propiedad de Aspose.Slides |
| --- | --- |
| Iniciar | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Preset de volumen | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Reproducir en todas las diapositivas | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Repetir hasta detener | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Ocultar durante la presentación | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Retroceder después de reproducir | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Fundido de entrada | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Fundido de salida | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Recortar inicio del audio | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Recortar fin del audio | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Control deslizante de volumen | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

El ejemplo encuentra el primer marco de audio en la primera diapositiva, establece [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) para iniciar la reproducción con un clic, y selecciona el preset de volumen bajo. El clip continúa en todas las diapositivas con la repetición desactivada. El ícono permanece oculto durante la presentación, y el clip retrocede después de la reproducción.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

Para un clip de más de 3,5 segundos, este ejemplo omite los primeros 1,5 segundos y los últimos 2 segundos. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) mide la duración a omitir del final del clip. Para obtener el tiempo final mostrado en PowerPoint, reste ese desplazamiento de la duración completa del clip. El clip recortado se funde de entrada durante 200 milisegundos y se funde de salida durante 500 milisegundos. Las cuatro propiedades aceptan valores en milisegundos.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

Para establecer el volumen de reproducción a un porcentaje específico, utilice [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). Este ejemplo establece el primer marco de audio en la primera diapositiva al 85%.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **Gestionar subtítulos de audio**

Cada marco de audio tiene una colección [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/) . Úsela para adjuntar subtítulos WebVTT al clip, exportar pistas existentes o eliminarlas.

### **Añadir subtítulos de audio**

El ejemplo incrusta un clip de audio en la primera diapositiva y utiliza [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) para adjuntar una pista WebVTT local. El primer argumento proporciona la etiqueta de la pista, y el segundo identifica el archivo que contiene los subtítulos con tiempo.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **Extraer subtítulos de audio**

Este ejemplo exporta cada pista de subtítulos adjunta a un marco de audio en la primera diapositiva. Escribe los [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) de la pista en un archivo WebVTT y utiliza su [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) como nombre de archivo para que cada pista tenga una salida separada.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **Eliminar subtítulos de audio**

Utilice [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) para eliminar una pista individual. El ejemplo utiliza [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) para eliminar todos los subtítulos del primer marco de audio en la primera diapositiva mientras conserva el clip.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **Buscar una línea en los subtítulos de audio**

Para encontrar una línea en los subtítulos de audio de la primera diapositiva, lea en memoria el [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) de cada pista. En una señal WebVTT de texto plano, la línea de tiempo contiene `-->`, las líneas de subtítulo la siguen, y una línea en blanco termina la señal. Este ejemplo muestra la etiqueta de la pista y cada línea de subtítulo que contiene “café”.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **Extraer audio**

Una transición de diapositiva puede tener su propio sonido. Para recuperarlo, lea la propiedad [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) de la transición. El ejemplo accede a los [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) del sonido y muestra su tamaño en bytes. Si la primera diapositiva no tiene sonido de transición, muestra un mensaje en su lugar.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **FAQ**

**¿Puedo reutilizar el mismo clip de audio en varias diapositivas sin duplicarlo?**

Sí. Añada el clip una vez a la [colección de audio](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) de la presentación y pase el mismo objeto de audio a [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) para cada diapositiva.

**¿Puedo reemplazar el sonido en un marco de audio existente?**

Sí. Para un sonido vinculado, actualice [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) para que apunte al archivo de reemplazo. Para un sonido incrustado, asigne otro clip de la colección de audio de la presentación a [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). Ambos enfoques conservan el marco existente.

**¿El recorte modifica los datos de audio almacenados en la presentación?**

No. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) y [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) establecen los límites de reproducción. aún puede obtener el clip completo mediante [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).