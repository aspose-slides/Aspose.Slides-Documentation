---
title: Spravovat video rámečky v prezentacích v .NET
linktitle: Video rámec
type: docs
weight: 10
url: /cs/net/video-frame/
keywords:
- přidat video
- vytvořit video
- vložit video
- extrahovat video
- získat video
- video rámec
- webový zdroj
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video rámečky v slajdech PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Rychlý návod krok za krokem."
---
## **Úvod**

Videa mohou pomoci vysvětlit myšlenky a zapojit publikum. Aspose.Slides pro .NET vám umožňuje přidávat video rámečky do snímků, upravovat nastavení přehrávání, spravovat popisky a extrahovat vložená video data.

PowerPoint podporuje lokální videa i odkazy na online videa, například videa z YouTube.

Pro reprezentaci video dat a video rámců poskytuje Aspose.Slides rozhraní [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) , rozhraní [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) a další relevantní typy.

## **Vytvoření vloženého video rámce**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video rámec pro vložení videa do vaší prezentace.

Tento příklad vloží lokální video na první snímek existující prezentace a uloží výsledek. Souřadnice a rozměry rámce jsou v bodech. Proud zůstává otevřený až do dokončení ukládání, protože [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) jej drží uzamčený, dokud jej prezentace používá.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

Můžete také předat cestu k lokálnímu videu přímo do [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Tento příklad vloží video na první snímek nové prezentace. Video musí být přístupné až do uložení prezentace.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Vytvoření video rámce s videem z webového zdroje**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit video rámec, který odkazuje na online video, například video z YouTube.

Tento příklad přidá odkaz na YouTube video a náhledový obrázek na první snímek. Nahraďte identifikátor videa, abyste použili jiné video. Nastavení [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) požaduje automatické přehrávání. Stažení náhledového obrázku a přehrání videa vyžaduje přístup k internetu. Prohlížeč prezentací musí také podporovat přehrávání online videí.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Přehrát video v režimu celé obrazovky**

V tréninkové prezentaci můžete přehrát ukázku softwaru v režimu celé obrazovky, aby si publikum mohlo prohlédnout detaily. Nastavte [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) na `true`, abyste povolili toto chování během přehrávání.

Tento příklad otevře prezentaci, najde první [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) na prvním snímku a povolí přehrávání v režimu celé obrazovky. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video rámcem na prvním snímku.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

Přehrávání v režimu celé obrazovky řídí, jak je video zobrazováno. Nezávisle na tom [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) určuje, zda se spustí automaticky nebo po kliknutí, a [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) určuje, zda se opakuje. Pro výběr chování při startu nastavte režim přehrávání na [VideoPlayModePreset.Auto nebo VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Příklad zachovává stávající nastavení startu a smyčky.

## **Posun videa zpět po přehrání**

V tréninkové prezentaci vrácení demonstračního videa na začátek připraví video pro další přehrání prezentátorem. Nastavte [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) na `true`, aby se video po dokončení přehrávání vrátilo na začátek.

Tento příklad otevře prezentaci, najde první [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) na prvním snímku a povolí vrácení videa. Vypne smyčku, aby se přehrávání mohlo dokončit, a nastaví přehrávání na start po kliknutí. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video rámcem na prvním snímku.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Vrácení videa (rewind) přemístí video na jeho začátek, aniž by ho znovu spustilo. Naopak, povolením [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) se přehrávání automaticky opakuje. Ponechejte smyčku vypnutou, když chcete, aby video skončilo a bylo připravené k opětovnému přehrání. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) nezávisle řídí automatické nebo kliknutím spouštění; tento příklad používá [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/), takže prezentátor řídí, kdy přehrávání začne. Nastavte režim přehrávání po nastavení smyčky, jak je ukázáno v příkladu. Vrácení funguje nezávisle na [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Ořez video rámce**

Použijte [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) a [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) k přeskočení části začátku nebo konce videa během přehrávání. Obě hodnoty jsou v milisekundách. Ořezávání mění nastavení přehrávání, aniž by upravovalo vložená video data.

**Nastavit ořezová nastavení**

Tento příklad vloží lokální video a během přehrávání přeskočí první 2,5 sekundy a poslední sekundu. Použijte video delší než 3,5 sekundy, aby zůstal přehratelný úsek.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Přečíst ořezová nastavení**

Tento příklad vypíše hodnoty ořezu prvního video rámce na prvním snímku v milisekundách. Prezentace musí obsahovat alespoň jeden snímek. Pokud tento snímek nemá video rámec, nic se nevyptí. Předchozí příklad generuje hodnoty 2500 a 1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Správa titulků videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video rámečky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou zpřístupněny prostřednictvím vlastnosti [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) .

**Přidat titulky do video rámce**

Tento příklad vloží lokální video a přidá WebVTT stopu titulků označenou English. Časové značky titulků by měly odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

Rozhraní [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) také poskytuje přetížení, které vám umožní přidávat titulky ze streamu.

**Extrahovat titulky z video rámce**

Tento příklad uloží všechny stopy titulků z video rámců na prvním snímku jako samostatné WebVTT soubory. Pořadová čísla udržují výstupní soubory odlišné. Konzole vypíše počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden snímek.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Každý objekt [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) zpřístupňuje identifikátor titulků, popisek, binární data a text titulků jako řetězec UTF-8.

**Odstranit titulky z video rámce**

Tento příklad odstraní všechny titulky z video rámce na první pozici tvaru na prvním snímku a uloží výsledek. Předpokládá, že snímek a tvar existují a že tvar je video rámec.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Pokud potřebujete odstranit pouze jednu stopu titulků, použijte metody [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) nebo [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) místo [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/) .

## **Extrahovat video ze snímku**

Kromě přidávání videí do snímků umožňuje Aspose.Slides také extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa ze všech snímků do samostatných, očíslovaných binárních souborů. Odkazovaná videa jsou přeskočena, protože neobsahují vložená data. Konzole vypíše MIME typ každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; při potřebe ji změňte tak, aby odpovídala hlášenému typu média.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **Často kladené otázky**

**Které parametry přehrávání videa lze změnit pro video rámec?**

Můžete ovládat [režim přehrávání](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automaticky nebo po kliknutí) a [opakování](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Tyto možnosti jsou k dispozici prostřednictvím vlastností objektu [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) .

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta do dokumentu, takže se velikost prezentace zvětšuje úměrně velikosti souboru. Když odkážete na online video a přidáte náhledový obrázek, prezentace uloží pouze odkaz a obrázek náhledu místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím video rámci bez změny jeho pozice a velikosti?**

Ano. Můžete vyměnit [video obsah](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) uvnitř rámce při zachování geometrie tvaru; je to běžný scénář pro aktualizaci médií v existujícím rozložení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/), který můžete přečíst a použít, například při ukládání na disk.