---
title: Správa video rámců v prezentacích v .NET
linktitle: Video rámeček
type: docs
weight: 10
url: /cs/net/video-frame/
keywords:
- přidat video
- vytvořit video
- vložit video
- extrahovat video
- získat video
- video rámeček
- webový zdroj
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video rámečky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro .NET. Rychlý průvodce jak na to."
---
## **Úvod**

Dobře umístěné video v prezentaci může učinit vaši zprávu poutavější a zvýšit úroveň zapojení publika.

PowerPoint vám umožňuje přidávat videa do snímku v prezentaci dvěma způsoby:
* Přidat nebo vložit místní video (uložené ve vašem počítači)
* Přidat online video (z webového zdroje, například YouTube).

Aby vám umožnilo přidávat videa (video objekty) do prezentace, Aspose.Slides poskytuje rozhraní [IVideo](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideo/) , rozhraní [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) a další související typy.

## **Vytvoření vloženého video rámce**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video rámec pro vložení videa do vaší prezentace.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideo/) a předávejte cestu k video souboru pro vložení videa do prezentace.
4. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) pro vytvoření rámce pro video.  
5. Uložte upravenou prezentaci.

Tento C# kód ukazuje, jak přidat lokálně uložené video do prezentace:
```c#
 // Vytvoří instanci třídy Presentation
 using (Presentation pres = new Presentation("pres.pptx"))
 {
     // Načte video
     using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
     {
         IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
         
         // Získá první snímek a přidá video rámec
         pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
         
         // Uloží prezentaci na disk
         pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
     }
 }
```
Alternativně můžete přidat video předáním jeho cesty k souboru přímo metodě [AddVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addvideoframe/):
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Vytvoření video rámce s videem z webového zdroje**
Microsoft [PowerPoint 2013 a novější](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) podporuje videa YouTube v prezentacích. Pokud je video, které chcete použít, dostupné online (např. na YouTube), můžete jej přidat do prezentace pomocí jeho webového odkazu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideo/) a předávejte odkaz na video.
4. Nastavte miniaturu pro video rámec.
5. Uložte prezentaci.

Tento C# kód ukazuje, jak přidat video z webu do snímku v PowerPoint prezentaci:
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

## **Správa titulků videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video rámečky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou dostupné přes vlastnost [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/captiontracks/).

**Přidání titulků do video rámce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) .
2. Přidejte video do prezentace.
3. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) do snímku.
4. Použijte kolekci [CaptionTracks](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/captiontracks/) k přidání WebVTT titulkového tracku.
5. Uložte upravenou prezentaci.

Následující kód ukazuje, jak přidat titulky do video rámce:
```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Přidá novou stopu titulků z WebVTT souboru.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Rozhraní [ICaptionsCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/icaptionscollection/) také poskytuje přetížení, které umožňuje přidávat titulky ze streamu.

**Extrahování titulků z video rámce**

1. Načtěte prezentaci, která obsahuje video.
2. Najděte cílový objekt [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/).
3. Procházejte kolekci [CaptionTracks](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/captiontracks/).
4. Uložte každý titulkový track do souboru `.vtt`.

Následující kód ukazuje, jak extrahovat titulky z video rámce:
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

Každý objekt [ICaptions](https://reference.aspose.com/slides/cs/net/aspose.slides/icaptions/) poskytuje identifikátor titulku, štítek, binární data a text titulku jako řetězec UTF‑8.

**Odstranění titulků z video rámce**

1. Načtěte prezentaci, která obsahuje video.
2. Získejte cílový objekt [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/).
3. Odstraňte titulkové tracky z kolekce [CaptionTracks](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/captiontracks/).
4. Uložte upravenou prezentaci.

Následující kód ukazuje, jak odstranit všechny titulky z video rámce:
```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Odstraní všechny titulky z video rámce.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Pokud potřebujete odstranit pouze jeden titulkový track, použijte metody [Remove](https://reference.aspose.com/slides/cs/net/aspose.slides/captionscollection/remove/) nebo [RemoveAt](https://reference.aspose.com/slides/cs/net/aspose.slides/captionscollection/removeat/) místo [Clear](https://reference.aspose.com/slides/cs/net/aspose.slides/captionscollection/clear/).

## **Extrahování videa ze snímku**
Kromě přidávání videí do snímků umožňuje Aspose.Slides extrahovat videa vložená v prezentacích.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) pro načtení prezentace obsahující video.
2. Procházejte všechny objekty [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide).
3. Procházejte všechny objekty [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape) a najděte [VideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/videoframe).
4. Uložte video na disk.

Tento C# kód ukazuje, jak extrahovat video ze snímku prezentace:
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

## **Často kladené otázky**

**Které parametry přehrávání videa lze změnit pro VideoFrame?**

Můžete ovládat [režim přehrávání](https://reference.aspose.com/slides/cs/net/aspose.slides/videoframe/playmode/) (automaticky nebo po kliknutí) a [opakování](https://reference.aspose.com/slides/cs/net/aspose.slides/videoframe/playloopmode/). Tyto možnosti jsou k dispozici prostřednictvím vlastností objektu [VideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/videoframe/).

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta do dokumentu, takže se velikost prezentace zvětšuje úměrně velikosti souboru. Když přidáte online video, je vložen odkaz a miniatura, takže nárůst velikosti je menší.

**Mohu nahradit video v existujícím VideoFrame, aniž bych změnil jeho polohu a velikost?**

Ano. Můžete vyměnit [video content](https://reference.aspose.com/slides/cs/net/aspose.slides/videoframe/embeddedvideo/) v rámci rámce při zachování geometrie tvaru; toto je běžný scénář pro aktualizaci médií v existujícím rozložení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [content type](https://reference.aspose.com/slides/cs/net/aspose.slides/video/contenttype/), který můžete přečíst a použít, například při ukládání na disk.