---
title: Správa audio rámců v prezentacích v .NET
linktitle: Audio rámec
type: docs
weight: 10
url: /cs/net/audio-frame/
keywords:
- zvuk
- audio rámec
- náhled
- přidat zvuk
- vlastnosti audia
- možnosti audia
- extrahovat zvuk
- .NET
- C#
- Aspose.Slides
description: "Vytvořte a ovládejte audio rámy v Aspose.Slides pro .NET—příklady v C# pro vkládání, ořezávání, smyčkování a konfiguraci přehrávání v prezentacích PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s audio rámci v Aspose.Slides. Ukazuje, jak přidat vložený zvuk do snímků, přizpůsobit miniaturu audio rámce, nakonfigurovat možnosti přehrávání, jako je hlasitost, smyčkování, skrývání, ořezávání a dobu setrvačnosti, a extrahovat zvuk použité v přechodech prezentace.

## **Vytvoření audio rámců**

Aspose.Slides pro .NET vám umožňuje přidávat audio soubory do snímků. Audio soubory jsou do snímků vloženy jako audio rámy. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Načtěte stream audio souboru, který chcete vložit do snímku.
4. Přidejte vložený audio rám (obsahující audio soubor) do snímku.
5. Nastavte [PlayMode](https://reference.aspose.com/slides/cs/net/aspose.slides/audioplaymodepreset) a `Volume` zveřejněné objektem [IAudioFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe).
6. Uložte upravenou prezentaci.

Tento C# kód vám ukazuje, jak přidat vložený audio rám do snímku:

```c#
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace
using (Presentation pres = new Presentation())
{
    // Získá první snímek
    ISlide sld = pres.Slides[0];
    
    // Načte WAV zvukový soubor do proudu
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Přidá audio rám
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Nastaví režim přehrávání a hlasitost audia
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Zapíše soubor PowerPoint na disk
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Změna miniatury audio rámce**

Když přidáte audio soubor do prezentace, zvuk se zobrazí jako rám s výchozím standardním obrázkem (viz obrázek v následující sekci). Můžete změnit miniaturu audio rámce (nastavit svůj preferovaný obrázek).

Tento C# kód vám ukazuje, jak změnit miniaturu nebo náhledový obrázek audio rámce:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Přidá audio rám do snímku se zadanou polohou a velikostí.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Přidá obrázek do zdrojů prezentace.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Nastaví obrázek pro audio rám.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----

	//Uloží upravenou prezentaci na disk
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Změna možností přehrávání audia**

Aspose.Slides pro .NET vám umožňuje měnit možnosti, které řídí přehrávání nebo vlastnosti audia. Například můžete upravit hlasitost audia, nastavit přehrávání v smyčce nebo dokonce skrýt ikonu audia.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe) properties:
- **Start** rozbalovací nabídka odpovídá vlastnosti [AudioFrame.PlayMode](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/properties/playmode).
- **Volume** odpovídá vlastnosti [AudioFrame.Volume](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/properties/volume).
- **Play Across Slides** odpovídá vlastnosti [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/properties/playacrossslides).
- **Loop until Stopped** odpovídá vlastnosti [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/properties/playloopmode).
- **Hide During Show** odpovídá vlastnosti [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/properties/hideatshowing).
- **Rewind after Playing** odpovídá vlastnosti [AudioFrame.RewindAudio](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/properties/rewindaudio).

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe) properties:
- **Fade In** odpovídá vlastnosti [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/fadeinduration/).
- **Fade Out** odpovídá vlastnosti [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/fadeoutduration/).
- **Trim Audio Start Time** odpovídá vlastnosti [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/trimfromstart/).
- **Trim Audio End Time** hodnota se rovná délce audia minus hodnota [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/trimfromend/).

Ovládací prvek **Volume** v PowerPointu na panelu pro audio odpovídá vlastnosti [AudioFrame.VolumeValue](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/volumevalue/). Umožňuje změnit hlasitost audia v procentech.

Takto měníte možnosti přehrávání audia:
1. [Vytvořte](#create-audio-frame) nebo získejte Audio Frame.
2. Nastavte nové hodnoty vlastností Audio Frame, které chcete upravit.
3. Uložte upravený soubor PowerPoint.

Tento C# kód demonstruje operaci, při níž jsou upraveny možnosti audia:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Získá tvar AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Nastaví režim přehrávání na přehrání po kliknutí
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Nastaví hlasitost na Nízkou
    audioFrame.Volume = AudioVolumeMode.Low;

    // Nastaví audio tak, aby se přehrávalo napříč snímky
    audioFrame.PlayAcrossSlides = true;

    // Zakáže smyčku pro audio
    audioFrame.PlayLoopMode = false;

    // Skryje AudioFrame během prezentace
    audioFrame.HideAtShowing = true;

    // Přetočí audio zpět na start po přehrání
    audioFrame.RewindAudio = true;

    // Uloží soubor PowerPoint na disk
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Tento C# příklad ukazuje, jak přidat nový audio rám s vloženým audiem, oříznout jej a nastavit doby setrvačnosti:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Nastaví počáteční offset ořezu na 1,5 sekundy
    audioFrame.TrimFromStart = 1500f;
    // Nastaví koncový offset ořezu na 2 sekundy
    audioFrame.TrimFromEnd = 2000f;

    // Nastaví dobu fade-in na 200 ms
    audioFrame.FadeInDuration = 200f;
    // Nastaví dobu fade-out na 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

Následující ukázka kódu ukazuje, jak získat audio rám s vloženým audiem a nastavit jeho hlasitost na 85 %:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Získá tvar audio rámu
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Nastaví hlasitost audia na 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Správa titulků audia**

Aspose.Slides vám umožňuje přidávat uzavřené titulky k audio rámu pomocí vlastnosti [CaptionTracks](https://reference.aspose.com/slides/cs/net/aspose.slides/iaudioframe/captiontracks/). Tato vlastnost vrací [ICaptionsCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/icaptionscollection/), která vám umožňuje přidávat WebVTT stopy titulků, procházet existující stopy a odstraňovat je podle potřeby.

**Přidání titulků audia**

Použijte vlastnost [CaptionTracks](https://reference.aspose.com/slides/cs/net/aspose.slides/iaudioframe/captiontracks/) k připojení jedné nebo více stop titulků k audio rámu. V následujícím příkladu je audio soubor přidán do snímku a poté je nová stopa titulků načtena ze souboru `.vtt`.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Přidá novou stopu titulků z WebVTT souboru.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Extrahování titulků audia**

Můžete procházet stopy titulků spojené s audio rámem a uložit je jako soubory `.vtt`. Každá stopa titulků poskytuje svá binární data a jedinečný identifikátor, který lze použít při exportu titulků.

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
                // Uloží stopu titulků jako .vtt soubor.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Odstranění titulků audia**

Chcete-li odstranit titulky z audio rámu, použijte metody poskytované rozhraním [ICaptionsCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/icaptionscollection/), jako jsou [Clear](https://reference.aspose.com/slides/cs/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/cs/net/aspose.slides/icaptionscollection/remove/), nebo [RemoveAt](https://reference.aspose.com/slides/cs/net/aspose.slides/icaptionscollection/removeat/). Následující příklad odstraňuje všechny stopy titulků z audio rámu.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Odstraní všechny stopy titulků z audio rámu.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Extrahování audia**

Aspose.Slides pro .NET vám umožňuje extrahovat zvuk použitý v přechodech prezentace. Například můžete extrahovat zvuk použitý v konkrétním snímku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) a načtěte prezentaci obsahující audio.
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přistupte k přechodům prezentace pro daný snímek.
4. Extrahujte zvuk jako bajtová data.

Tento C# kód vám ukazuje, jak extrahovat audio použité v snímku:

```c#
string presName = "AudioSlide.pptx";

// Vytvoří instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation(presName);

// Získá snímek
ISlide slide = pres.Slides[0];

// Získá přechodové efekty prezentace pro snímek
ISlideShowTransition transition = slide.SlideShowTransition;

//Extrahuje zvuk do pole bajtů
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **Často kladené otázky**

**Mohu opakovaně použít stejný audio soubor na více snímcích, aniž by se zvětšila velikost souboru?**

Ano. Přidejte audio jednou do sdílené [audio collection](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/audios/) prezentace a vytvořte další audio rámy, které odkazují na tento existující soubor. Tím se zabrání duplikaci mediálních dat a velikost prezentace zůstane pod kontrolou.

**Mohu nahradit zvuk v existujícím audio rámu, aniž bych znovu vytvářel tvar?**

Ano. Pro propojený zvuk aktualizujte [link path](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/linkpathlong/) tak, aby ukazoval na nový soubor. Pro vložený zvuk vyměňte objekt [embedded audio](https://reference.aspose.com/slides/cs/net/aspose.slides/audioframe/embeddedaudio/) za jiný z [audio collection](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/audios/) prezentace. Formátování rámu a většina nastavení přehrávání zůstane beze změny.

**Mění ořezávání podkladová audio data uložená v prezentaci?**

Ne. Ořezávání upravuje pouze hranice přehrávání. Původní audio bajty zůstávají nedotčeny a jsou přístupné prostřednictvím vloženého audia nebo audio kolekce prezentace.