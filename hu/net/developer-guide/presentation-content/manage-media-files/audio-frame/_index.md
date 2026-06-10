---
title: Audio keretek kezelése prezentációkban .NET-ben
linktitle: Audio keret
type: docs
weight: 10
url: /hu/net/audio-frame/
keywords:
- hang
- hangkeret
- bélyegkép
- hang hozzáadása
- hang tulajdonságok
- hang beállítások
- hang kinyerése
- .NET
- C#
- Aspose.Slides
description: "Audio keretek létrehozása és vezérlése az Aspose.Slides for .NET-ben - C# példák beágyazásra, vágásra, ismétlésre és lejátszás beállítására PPT, PPTX és ODP prezentációkban."
---
## **Áttekintés**

Ez a cikk leírja, hogyan dolgozhat az audio keretekkel az Aspose.Slides‑ban. Bemutatja, hogyan adhat beágyazott hangot a diákhoz, testreszabhatja az audio keret bélyegképét, konfigurálhatja a lejátszási beállításokat, például hangerő, ismétlés, elrejtés, vágás és átfedés időtartamok, valamint hogyan vonhatja ki a diavetítés átmeneteiben használt hangot.

## **Audio keretek létrehozása**

Az Aspose.Slides for .NET lehetővé teszi, hogy hangfájlokat adjon a diákhoz. A hangfájlok audio keretekként vannak beágyazva a diákba.

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Töltse be azt a hangfájl adatfolyamot, amelyet be szeretne ágyazni a diára.  
4. Adja hozzá a beágyazott audio keretet (amely a hangfájlt tartalmazza) a diához.  
5. Állítsa be a [PlayMode](https://reference.aspose.com/slides/hu/net/aspose.slides/audioplaymodepreset) és a `Volume` értékeket, amelyeket az [IAudioFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe) objektum biztosít.  
6. Mentse el a módosított prezentációt.

Ez a C# kód bemutatja, hogyan adhat beágyazott hangkeretet egy diához:

```c#
// Egy prezentációs osztály példányosítása, amely egy prezentációs fájlt képvisel
using (Presentation pres = new Presentation())
{
    // Az első diát kapja
    ISlide sld = pres.Slides[0];
    
    // Betölti a wav hangfájlt adatfolyamként
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Hozzáadja az Audio keretet
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Beállítja a hang lejátszási módját és hangerősségét
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Kiírja a PowerPoint fájlt a lemezre
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Audio keret bélyegképének módosítása**

Amikor egy hangfájlt ad a prezentációhoz, a hang egy keretként jelenik meg egy szabványos alapértelmezett képpel (lásd az alábbi szakaszban lévő képet). Módosíthatja a hangkeret bélyegképét (állítsa be a kívánt képet).

Ez a C# kód bemutatja, hogyan változtathatja meg egy audio keret bélyegképét vagy előnézeti képét:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Hozzáad egy audio keretet a diához megadott pozícióval és mérettel.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Képet ad a prezentáció erőforrásaihoz.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Beállítja a képet az audio kerethez.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----

    //Menti a módosított prezentációt a lemezre
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Audio lejátszási beállítások módosítása**

Az Aspose.Slides for .NET lehetővé teszi, hogy módosítsa az audio lejátszását vagy tulajdonságait szabályozó beállításokat. Például beállíthatja a hangerőt, megadhatja, hogy a hang ismétlődő módon játsszon, vagy akár elrejtheti az audio ikont.

A **Audio Options** panel a Microsoft PowerPoint‑ban:

![example1_image](audio_frame_0.png)

A PowerPoint **Audio Options** ami megfelel az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe) tulajdonságainak:

- A **Start** legördülő menü megfelel az [AudioFrame.PlayMode](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/properties/playmode) tulajdonságnak  
- A **Volume** a [AudioFrame.Volume](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/properties/volume) tulajdonságnak felel meg  
- A **Play Across Slides** a [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/properties/playacrossslides) tulajdonságnak felel meg  
- A **Loop until Stopped** a [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/properties/playloopmode) tulajdonságnak felel meg  
- A **Hide During Show** a [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/properties/hideatshowing) tulajdonságnak felel meg  
- A **Rewind after Playing** a [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/properties/rewindaudio) tulajdonságnak felel meg  

PowerPoint **Editing** opciók amelyek megfelelnek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe) tulajdonságainak:

- A **Fade In** a [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/fadeinduration/) tulajdonságnak felel meg  
- A **Fade Out** a [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/fadeoutduration/) tulajdonságnak felel meg  
- A **Trim Audio Start Time** a [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/trimfromstart/) tulajdonságnak felel meg  
- A **Trim Audio End Time** értéke a hang hosszából csökkentve a [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/trimfromend/) értékét adja  

A PowerPoint **Volume control** a hangvezérlő panelen a [AudioFrame.VolumeValue](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/volumevalue/) tulajdonságnak felel meg. Lehetővé teszi a hangerő százalékos módosítását.

Így módosíthatja az Audio lejátszási beállításokat:

1. [Létrehozás](#create-audio-frame) vagy a Hangkeret lekérése.  
2. Állítson be új értékeket az Audio Frame azon tulajdonságaira, amelyeket módosítani kíván.  
3. Mentse el a módosított PowerPoint fájlt.

Ez a C# kód demonstrálja egy olyan műveletet, amelyben az audio beállításait módosítják:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Lekéri az AudioFrame alakzatot
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Beállítja a lejátszási módot kattintásra
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Beállítja a hangerőt alacsonyra
    audioFrame.Volume = AudioVolumeMode.Low;

    // Beállítja a hangot, hogy a diák között játsszon
    audioFrame.PlayAcrossSlides = true;

    // Letiltja a hang ismétlését
    audioFrame.PlayLoopMode = false;

    // Elrejti az AudioFrame-et a diavetítés során
    audioFrame.HideAtShowing = true;

    // Visszatekeri a hangot a lejátszás után az elejére
    audioFrame.RewindAudio = true;

    // Mentse a PowerPoint fájlt a lemezre
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Ez a C# példa bemutatja, hogyan adhat hozzá új audio keretet beágyazott hanggal, hogyan vágja meg, és hogyan állítja be a fade időtartamokat:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Beállítja a vágás kezdőeltolását 1,5 másodpercre
    audioFrame.TrimFromStart = 1500f;
    // Beállítja a vágás befejező eltoltását 2 másodpercre
    audioFrame.TrimFromEnd = 2000f;

    // Beállítja a fade‑in időtartamot 200 ms-re
    audioFrame.FadeInDuration = 200f;
    // Beállítja a fade‑out időtartamot 500 ms-re
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

Az alábbi kódrészlet mutatja, hogyan kérhet le egy beágyazott hanggal rendelkező audio keretet, és állíthatja be a hangerőt 85 %-ra:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Lekéri az audio keret alakzatát
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Beállítja a hangerőt 85%-ra
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Audio feliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy zárt feliratokat adjon egy audio kerethez a [CaptionTracks](https://reference.aspose.com/slides/hu/net/aspose.slides/iaudioframe/captiontracks/) tulajdonságon keresztül. Ez a tulajdonság egy [ICaptionsCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/icaptionscollection/) objektumot ad vissza, amely lehetővé teszi WebVTT feliratsávok hozzáadását, a meglévő sávok bejárását és szükség esetén azok eltávolítását.

**Audio feliratok hozzáadása**

Használja a [CaptionTracks](https://reference.aspose.com/slides/hu/net/aspose.slides/iaudioframe/captiontracks/) tulajdonságot, hogy egy vagy több feliratsávot csatoljon egy audio kerethez. Az alábbi példában egy hangfájlt adunk a diához, majd egy új feliratsávot töltünk be egy `.vtt` fájlból.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Új feliratsáv hozzáadása egy WebVTT fájlból.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Audio feliratok kinyerése**

Bejárhatja az audio kerethez kapcsolódó feliratsávokat, és mentheti őket `.vtt` fájlokként. Minden feliratsáv kiadja a bináris adatát és egyedi azonosítóját, amely exportáláskor felhasználható.

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
                // Mentse a feliratsávot .vtt fájlként.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Audio feliratok eltávolítása**

Az audio keret feliratai eltávolításához használja az [ICaptionsCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/icaptionscollection/) által biztosított metódusokat, például a [Clear](https://reference.aspose.com/slides/hu/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/hu/net/aspose.slides/icaptionscollection/remove/), vagy a [RemoveAt](https://reference.aspose.com/slides/hu/net/aspose.slides/icaptionscollection/removeat/) metódust. Az alábbi példa minden feliratsávot eltávolít egy audio keretből.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Eltávolítja az összes feliratsávot az audio keretről.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Audio kinyerése**

Az Aspose.Slides for .NET lehetővé teszi, hogy kinyerje a diavetítés átmeneteiben használt hangot. Például kinyerheti egy adott dia hangját.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, és töltse be a hangot tartalmazó prezentációt.  
2. Szerezze meg a megfelelő dia referenciáját az indexe alapján.  
3. Érje el a dia diavetítés‑átmeneteit.  
4. Kinyerje a hangot bájt adatként.

Ez a C# kód megmutatja, hogyan nyerheti ki egy dia által használt hangot:

```c#
string presName = "AudioSlide.pptx";

// Példányosít egy Presentation osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation(presName);

// Eléri a diát
ISlide slide = pres.Slides[0];

// Lekéri a diavetítés átmeneti effektusait a diához
ISlideShowTransition transition = slide.SlideShowTransition;

//Kinyeri a hangot bájt tömbként
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **GYIK**

**Újra felhasználhatom ugyanazt a hangfájlt több dián anélkül, hogy megnövelném a fájlméretet?**

Igen. Adja hozzá a hangot egyszer a prezentáció megosztott [audio collection](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/audios/) gyűjteményéhez, és hozzon létre további audio kereteket, amelyek hivatkoznak erre a meglévő erőforrásra. Ez megakadályozza a médiaadatok duplikálását, és a prezentáció méretét kordában tartja.

**Lecserélhetem egy meglévő audio keret hangját anélkül, hogy újra létrehoznám az alakzatot?**

Igen. Hivatkozott hang esetén módosítsa a [link path](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/linkpathlong/) értékét, hogy az új fájlra mutasson. Beágyazott hang esetén cserélje ki a [embedded audio](https://reference.aspose.com/slides/hu/net/aspose.slides/audioframe/embeddedaudio/) objektumot egy másikra a prezentáció [audio collection](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/audios/) gyűjteményéből. A keret formázása és a legtöbb lejátszási beállítás változatlan marad.

**A vágás módosítja a prezentációban tárolt eredeti audio adatokat?**

Nem. A vágás csak a lejátszási határokat állítja be. Az eredeti audio bájtok érintetlenek maradnak, és elérhetők a beágyazott audio vagy a prezentáció audio gyűjteménye révén.