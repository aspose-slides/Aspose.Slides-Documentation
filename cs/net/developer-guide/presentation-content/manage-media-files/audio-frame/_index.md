---
title: Spravovat audio rámečky v prezentacích v .NET
linktitle: Audio rámec
type: docs
weight: 10
url: /cs/net/audio-frame/
keywords:
- zvuk
- audio rámec
- náhled
- přidat audio
- vlastnosti audia
- možnosti audia
- extrahovat audio
- .NET
- C#
- Aspose.Slides
description: "Vložte audio do snímků, změňte ikonu audia, nakonfigurujte přehrávání, spravujte titulky WebVTT a extrahujte zvuky přechodů snímků pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Audio rámeček vám umožní přehrát zvuk na snímku. S Aspose.Slides pro .NET můžete vložit zvukový klip, vybrat obrázek, který jej představuje, upravit přehrávání a připojit titulky. Také můžete získat zvuk přiřazený k přechodu snímku.

## **Vytvoření audio rámečků**

Použijte [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) k vložení lokálního audio klipu na první snímek. První dvě souřadnice umístí rámeček na snímek a další dvě hodnoty nastaví jeho šířku a výšku, vše v bodech. Tento příklad nastavuje [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) tak, aby klip startoval automaticky, a [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) na předvolbu hlasité.

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

## **Změna miniatury audio rámce**

Ve výchozím nastavení audio rámec zobrazuje ikonu reproduktoru. Chcete-li zobrazit vlastní miniaturu, přidejte obrázek do prezentace pomocí [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) a přiřaďte jej k vlastnosti [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) rámce. Příklad používá JPEG jako miniaturu pro vložený audio klip.

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

## **Změna možností přehrávání audia**

Ovládací prvky **Audio Options** v PowerPointu určují, kdy klip začne, jak hlasitý je a jak se chová během prezentace.

![Ovládací prvky Audio Options v PowerPointu pro audio rámec](audio_frame_0.png)

| Ovládací prvek PowerPointu | Vlastnost Aspose.Slides |
| --- | --- |
| Start | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Volume preset | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Play Across Slides | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Loop until Stopped | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Hide During Show | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Rewind after Playing | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Fade In | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Fade Out | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Trim Audio start time | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Trim Audio end time | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Volume slider | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

Příklad najde první audio rámec na prvním snímku, nastaví [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) tak, aby přehrávání začalo po kliknutí, a vybere předvolbu nízké hlasitosti. Klip pokračuje napříč snímky s vypnutým opakováním. Ikona zůstane během prezentace skrytá a klip se po přehrání přehraje zpět.

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

Pro klip delší než 3,5 sekundy tento příklad přeskočí první 1,5 sekundy a poslední 2 sekundy. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) měří dobu, kterou je třeba vynechat na konci klipu. Pro získání koncového času zobrazeného v PowerPointu odečtěte tento posun od celkové délky klipu. Ořezaný klip se postupně zesílí během 200 milisekund a zeslábne během 500 milisekund. Všechny čtyři vlastnosti přijímají hodnoty v milisekundách.

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

Pro nastavení hlasitosti přehrávání na konkrétní procento použijte [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). Tento příklad nastaví první audio rámec na prvním snímku na 85 %.

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

## **Správa audio titulků**

Každý audio rámec má kolekci [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/). Použijte ji k připojení WebVTT titulků ke klipu, exportu existujících stop nebo jejich odstranění.

### **Přidání audio titulků**

Příklad vloží audio klip na první snímek a použije [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) k připojení lokální WebVTT stopy. První argument poskytuje štítek stopy a druhý určuje soubor obsahující časované titulky.

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

### **Extrahování audio titulků**

Tento příklad exportuje každou stopu titulků připojenou k audio rámci na prvním snímku. Zapíše [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) stopy do souboru WebVTT a použije její [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) jako název souboru, aby každá stopa měla samostatný výstup.

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

### **Odstranění audio titulků**

Použijte [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) nebo [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) k odstranění jednotlivé stopy. Příklad použije [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) k odebrání všech titulků z prvního audio rámce na prvním snímku při zachování klipu.

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

### **Vyhledání řádku v audio titulcích**

Pro vyhledání řádku v audio titulcích na prvním snímku načtěte každou stopu pomocí [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) v paměti. V čistě textovém cue WebVTT obsahuje časová řádka `-->`, řádky titulků následují a prázdná řádka ukončuje cue. Tento příklad vypíše štítek stopy a každou řádku titulků obsahující „café“.

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

## **Extrahování audia**

Přechod mezi snímky může mít vlastní zvuk. Pro jeho získání přečtěte vlastnost [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) přechodu. Příklad získá [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) zvuku a vypíše jeho velikost v bajtech. Pokud první snímek nemá žádný zvuk přechodu, vypíše místo toho zprávu.

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

## **Často kladené otázky**

**Mohu znovu použít stejný audio klip na více snímcích bez jeho duplikace?**

Ano. Přidejte klip jednou do [audio kolekce](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) prezentace a předávejte stejný audio objekt do [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) pro každý snímek.

**Mohu nahradit zvuk v existujícím audio rámci?**

Ano. Pro propojený zvuk aktualizujte [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) tak, aby ukazoval na náhradní soubor. Pro vložený zvuk přiřaďte jiný klip z audio kolekce prezentace do [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). Obě přístupy zachovají existující rámec.

**Mění ořezávání audio data uložená v prezentaci?**

Ne. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) a [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) nastavují hranice přehrávání. Stále můžete získat celý klip z [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).