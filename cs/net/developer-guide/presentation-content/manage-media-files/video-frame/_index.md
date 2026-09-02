---
title: Spravovat video snímky v prezentacích v .NET
linktitle: Video snímek
type: docs
weight: 10
url: /cs/net/video-frame/
keywords:
- přidat video
- vytvořit video
- vložit video
- extrahovat video
- získat video
- video snímek
- webový zdroj
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video snímky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro .NET. Rychlý návod."
---
## **Úvod**

Dobře umístěné video v prezentaci může učinit vaši zprávu přesvědčivější a zvýšit úroveň zapojení publika.

PowerPoint vám umožňuje přidávat videa do snímku v prezentaci dvěma způsoby:

* Přidat nebo vložit místní video (uložené ve vašem počítači)
* Přidat online video (z webového zdroje, například YouTube).

Aby vám umožnil přidávat videa (video objekty) do prezentace, Aspose.Slides poskytuje rozhraní [IVideo](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideo/) , rozhraní [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) a další související typy. 

## **Vytvořit vložený snímek videa**

Pokud je video soubor, který chcete přidat na svůj snímek, uložen lokálně, můžete vytvořit snímek videa a vložit video do vaší prezentace. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
1. Získejte referenci na snímek pomocí jeho indexu. 
1. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideo/) a předávejte cestu k video souboru, aby se video vložilo do prezentace. 
1. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) a vytvořte snímek pro video.  
1. Uložte upravenou prezentaci. 

Tento C# kód ukazuje, jak přidat lokálně uložené video do prezentace:

```c#
// Vytvoří instanci třídy Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Načte video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Získá první snímek a přidá video snímek
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Uloží prezentaci na disk
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternativně můžete video přidat předáním jeho cesty k souboru přímo metodě [AddVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addvideoframe/) :

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Vytvořit snímek videa s videem z webového zdroje**
Novější verze Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporují online videa v prezentacích. Pokud je video, které chcete použít, dostupné online (např. na YouTube), můžete jej do prezentace přidat pomocí jeho webového odkazu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
1. Získejte referenci na snímek pomocí jeho indexu. 
1. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideo/) a předávejte odkaz na video.
1. Nastavte miniaturu pro snímek videa. 
1. Uložte prezentaci. 

Tento C# kód ukazuje, jak přidat video z webu na snímek v PowerPoint prezentaci:

```c#
public static void Run()
{
    // Vytvoří objekt Presentation, který představuje soubor prezentace 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Přidá VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Načte miniaturu
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Oříznout snímek videa**

Aspose.Slides vám umožňuje řídit, která část videa se přehrává, nastavením hodnot trim-from-start a trim-from-end pomocí [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/trimfromstart/) a [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/trimfromend/). Obě hodnoty jsou zadány v milisekundách a definují, kolik času se přeskočí od začátku a konce videa. Tato nastavení mění nastavení přehrávání videa v prezentaci; neprovádějí řezání ani jinou úpravu vložených binárních dat videa.

**Nastavit nastavení ořezu**

Pro vytvoření snímku videa a nastavení jeho ořezu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) .
1. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideo/) do prezentace.
1. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) na snímek.
1. Nastavte hodnoty trim-from-start a trim-from-end pomocí [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/trimfromstart/) a [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/trimfromend/) .
1. Uložte upravenou prezentaci.

Následující ukázka kódu přeskočí první 2,5 sekundy a poslední sekundu vloženého videa během přehrávání:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Přečíst nastavení ořezu**

Pro zjištění existujících nastavení ořezu načtěte prezentaci, najděte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) mezi tvary na prvním snímku a přečtěte hodnoty pomocí [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/trimfromstart/) a [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/trimfromend/) .

Následující ukázka kódu najde první snímek videa na prvním snímku a vypíše jeho nastavení ořezu v milisekundách:

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Spravovat titulky videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro snímky videa v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou přístupné prostřednictvím vlastnosti [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/captiontracks/) .

**Přidat titulky do snímku videa**

Pro přidání titulků do snímku videa:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) .
1. Přidejte video do prezentace.
1. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) na snímek.
1. Použijte kolekci [CaptionTracks](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/captiontracks/) k přidání WebVTT stopy titulků.
1. Uložte upravenou prezentaci.

Následující kód ukazuje, jak přidat titulky do snímku videa:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Přidá novou stopu titulků ze souboru WebVTT.
    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Rozhraní [ICaptionsCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/icaptionscollection/) také poskytuje přetížení, které umožňuje přidat titulky ze streamu.

**Extrahovat titulky ze snímku videa**

Pro extrahování titulků ze snímku videa:

1. Načtěte prezentaci, která obsahuje video.
1. Najděte cílový objekt [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) .
1. Procházejte kolekci [CaptionTracks](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/captiontracks/) .
1. Uložte každou stopu titulků do souboru `.vtt` .

Následující kód ukazuje, jak extrahovat titulky ze snímku videa:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // Uloží stopu titulků do souboru WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Každý objekt [ICaptions](https://reference.aspose.com/slides/cs/net/aspose.slides/icaptions/) vystavuje identifikátor titulků, popisek, binární data a text titulků jako řetězec UTF-8.

**Odstranit titulky ze snímku videa**

Pro odstranění titulků ze snímku videa:

1. Načtěte prezentaci, která obsahuje video.
1. Získejte cílový objekt [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) .
1. Odstraňte stopy titulků z kolekce [CaptionTracks](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/captiontracks/) .
1. Uložte upravenou prezentaci.

Následující kód ukazuje, jak odstranit všechny titulky ze snímku videa:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Odebere všechny titulky ze snímku videa.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Pokud potřebujete odstranit jen jednu stopu titulků, použijte metody [Remove](https://reference.aspose.com/slides/cs/net/aspose.slides/captionscollection/remove/) nebo [RemoveAt](https://reference.aspose.com/slides/cs/net/aspose.slides/captionscollection/removeat/) místo [Clear](https://reference.aspose.com/slides/cs/net/aspose.slides/captionscollection/clear/) .

## **Extrahovat video ze snímku**
Kromě přidávání videí do snímků Aspose.Slides umožňuje extrahovat videa vložená v prezentacích.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) pro načtení prezentace obsahující video. 
2. Procházejte všechny objekty [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide) .
3. Procházejte všechny objekty [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape) a najděte [VideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/videoframe) . 
4. Uložte video na disk.

Tento C# kód ukazuje, jak extrahovat video na snímku prezentace:

```c#
// Vytvoří objekt Presentation, který představuje soubor prezentace 
Presentation presentation = new Presentation("Video.pptx");

// Prochází snímky
foreach (ISlide slide in presentation.Slides)
{
    // Prochází tvary
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Uloží video na disk, jakmile je nalezen VideoFrame obsahující video
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **FAQ**

**Které parametry přehrávání videa lze změnit pro VideoFrame?**

Můžete ovládat [playback mode](https://reference.aspose.com/slides/cs/net/aspose.slides/videoframe/playmode/) (automatické nebo po kliknutí) a [looping](https://reference.aspose.com/slides/cs/net/aspose.slides/videoframe/playloopmode/). Tyto možnosti jsou k dispozici prostřednictvím vlastností objektu [VideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/videoframe/) .

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte místní video, binární data jsou zahrnuta v dokumentu, takže se velikost prezentace zvětší úměrně velikosti souboru. Když přidáte online video, jsou vloženy odkaz a miniatura, takže nárůst velikosti je menší.

**Mohu nahradit video v existujícím VideoFrame, aniž bych změnil jeho pozici a velikost?**

Ano. Můžete vyměnit [video content](https://reference.aspose.com/slides/cs/net/aspose.slides/videoframe/embeddedvideo/) v rámci snímku a přitom zachovat geometrii tvaru; jedná se o běžný scénář pro aktualizaci médií v existujícím rozvržení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [content type](https://reference.aspose.com/slides/cs/net/aspose.slides/video/contenttype/) , který můžete přečíst a použít, například při ukládání na disk.