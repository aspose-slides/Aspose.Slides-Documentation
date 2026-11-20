---
title: Hangkeretek kezelése prezentációkban .NET-ben
linktitle: Hangkeret
type: docs
weight: 10
url: /hu/net/audio-frame/
keywords:
- hang
- hangkeret
- bélyegkép
- hang hozzáadása
- hang tulajdonságok
- hang opciók
- hang kinyerése
- .NET
- C#
- Aspose.Slides
description: "Hang beágyazása diákba, a hang ikonjának módosítása, lejátszás beállítása, WebVTT feliratok kezelése, és diaváltási hangok kinyerése az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Egy hangkeret lehetővé teszi, hogy hangot játsszunk le egy dián. Az Aspose.Slides for .NET segítségével beágyazhat egy helyi hangklipet, kiválaszthatja a képét, amely azt ábrázolja, szabályozhatja a lejátszást, és feliratokat csatolhat. Emellett lekérdezheti a diaváltáshoz rendelt hangot is.

## **Hangkeretek létrehozása**

Használja az [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) függvényt egy helyi hangklip beágyazásához az első dián. Az első két koordináta pozícionálja a keretet a dián, a következő két érték állítja be a szélességét és magasságát, mind pontban. Ez a példa a [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) értékét állítja be úgy, hogy a klip automatikusan induljon, és a [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) értékét a hangos előre beállítottra.

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

## **A hangkeret bélyegképének módosítása**

Alapértelmezés szerint egy hangkeret egy hangszóró ikont jelenít meg. Egy egyedi bélyegkép megjelenítéséhez adjon hozzá egy képet a prezentációhoz az [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) metódussal, és rendelje hozzá a keret [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) tulajdonságához. A példa egy JPEG-et használ bélyegképként egy beágyazott hangkliphez.

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

## **Hang lejátszási beállítások módosítása**

A PowerPoint **Audio Options** vezérlői határozzák meg, mikor indul a klip, milyen hangos, és hogyan viselkedik a diavetítés során.

![PowerPoint hangopciók vezérlői egy hangkerethez](audio_frame_0.png)

| PowerPoint vezérlő | Aspose.Slides tulajdonság |
| --- | --- |
| Indítás | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Hangerő előre beállított | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Lejátszás diákon át | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Ismétlés leállításig | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Elrejtés előadás alatt | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Visszatekerés lejátszás után | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Beolvasztás | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Kifelé olvasztás | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Hang vágása kezdőidő | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Hang vágása végidő | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Hangerő csúszka | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

A példa megtalálja az első hangkeretet az első dián, a [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) értékét kattintásra indított lejátszásra állítja, és a alacsony hangerő előre beállítottat választja. A klip a diákon át folytatódik, a hurkolás le van tiltva. Az ikon rejtve marad a bemutató során, és a klip lejátszás után visszatekerődik.

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

3,5 másodpercnél hosszabb klip esetén ez a példa kihagyja az első 1,5 másodpercet és az utolsó 2 másodpercet. A [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) a klip végéről elhagyandó időt méri. A PowerPointban látható végidőhöz vonja le ezt az eltolást a teljes klip hosszából. A levágott klip 200 ms alatt olvaszt be, majd 500 ms alatt olvaszt ki. Mind a négy tulajdonság értéke ezredmásodpercben van megadva.

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

A lejátszási hangerő konkrét százalékra állításához használja a [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) beállítást. Ez a példa az első hangkeret hangerőértékét 85 %-ra állítja az első dián.

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

## **Hangfeliratok kezelése**

Minden hangkeret rendelkezik egy [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/) gyűjteménnyel. Ezzel WebVTT feliratokat csatolhat a kliphez, exportálhat meglévő sávokat, vagy eltávolíthatja azokat.

### **Hangfeliratok hozzáadása**

A példa egy hangklipet ágyaz be az első diára, és a [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) metódussal helyi WebVTT sávot csatol. Az első argumentum a sáv címkéjét adja meg, a második pedig a feliratokat tartalmazó fájlt határozza meg.

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

### **Hangfeliratok kinyerése**

Ez a példa exportálja az első dián lévő hangkerethez csatolt minden feliratsávot. A sáv [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) értékét egy WebVTT fájlba írja, és a [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) értékét használja fájlnévként, így minden sáv külön kimenettel rendelkezik.

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

### **Hangfeliratok eltávolítása**

Használja a [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) vagy a [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) metódust egyedi sáv törléséhez. A példa a [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) metódust alkalmazza, hogy az első dián lévő első hangkeret összes feliratát eltávolítsa, miközben a klip érintetlen marad.

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

### **Sor keresése a hangfeliratok között**

Az első dián lévő hangfeliratokban egy sor kereséséhez olvassa be minden sáv [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) értékét memóriába. Egy egyszerű szöveges WebVTT cue‑ban a idővonal tartalmazza a `-->` jelet, azt követik a feliratsorok, és egy üres sor zárja a cue‑t. Ez a példa kiírja a sáv címkéjét és minden olyan feliratsort, amely a „café” szót tartalmazza.

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

## **Hang exportálása**

Egy diaváltásnak saját hangja lehet. Ennek lekérdezéséhez olvassa el a váltás [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) tulajdonságát. A példa a hang [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) értékét kiírja bájtokban. Ha az első dián nincs váltáshang, akkor egy üzenetet jelenít meg helyette.

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

## **GYIK**

**Ugyanazt a hangklipet többször is használhatom több dián anélkül, hogy duplikálnám?**

Igen. Adja hozzá a klipet egyszer a prezentáció [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) gyűjteményéhez, és minden dián ugyanazt az audio objektumot adja át az [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) hívásnak.

**Lecserélhetem a hangot egy már létező hangkeretben?**

Igen. Egy hivatkozott hang esetén állítsa be a [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) értékét a helyettesítő fájlra. Egy beágyazott hang esetén egy másik klipet rendelj a prezentáció audio gyűjteményéből a [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) tulajdonsághoz. Mindkét megközelítés megőrzi a meglévő keretet.

**A levágás megváltoztatja a prezentációban tárolt hangadatot?**

Nem. A [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) és a [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) csak a lejátszási határokat állítja be. A teljes klip továbbra is lekérdezhető a [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) segítségével.