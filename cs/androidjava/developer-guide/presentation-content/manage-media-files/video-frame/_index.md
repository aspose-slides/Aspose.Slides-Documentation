---
title: Správa video rámců v prezentacích na Androidu
linktitle: Video rámec
type: docs
weight: 10
url: /cs/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video rámy v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro Android v Javě. Rychlý průvodce jak na to."
---
## **Introduction**

Dobře umístěné video v prezentaci může učinit vaši zprávu přesvědčivější a zvýšit míru zapojení publika.

PowerPoint vám umožňuje přidávat videa do snímku v prezentaci dvěma způsoby:

* Přidat nebo vložit lokální video (uložené ve vašem počítači)
* Přidat online video (z webového zdroje, jako je YouTube).

Aby vám umožnil přidávat videa (video objekty) do prezentace, poskytuje Aspose.Slides rozhraní [IVideo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideo/) , rozhraní [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/) a další relevantní typy.

## **Create an Embedded Video Frame**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video rámec pro vložení videa do vaší prezentace.

1. Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation)class.
1. Získejte odkaz na snímek pomocí jeho indexu. 
1. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideo/) a předávejte cestu k video souboru pro vložení videa do prezentace.
1. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/) pro vytvoření rámce pro video.
1. Uložte upravenou prezentaci. 

Tento Java kód ukazuje, jak přidat lokálně uložené video do prezentace:

```java
// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Načte video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Získá první snímek a přidá video rámec
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Uloží prezentaci na disk
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternativně můžete video přidat předáním jeho cesty k souboru přímo metodě [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Create a Video Frame with Video from a Web Source**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) podporuje videa z YouTube v prezentacích. Pokud je video, které chcete použít, dostupné online (např. na YouTube), můžete jej do prezentace přidat pomocí jeho webového odkazu. 

1. Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation)class
1. Získejte odkaz na snímek pomocí jeho indexu. 
1. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideo/) a předávejte odkaz na video.
1. Nastavte miniaturu pro video rámec. 
1. Uložte prezentaci. 

Tento Java kód ukazuje, jak přidat video z webu do snímku v PowerPoint prezentaci:

```java
// Vytvoří objekt Presentation, který představuje soubor prezentace 
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Přidá video rámec
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Načte miniaturu
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Manage Video Captions**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video rámečky v prezentacích PowerPoint. Titulky jsou uloženy ve formátu WebVTT a jsou dostupné prostřednictvím metody [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Add Captions to a Video Frame**

Pro přidání titulků do video rámce:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
1. Přidejte video do prezentace.
1. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/) na snímek.
1. Použijte [ICaptionsCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/) vrácený metodou [getCaptionTracks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) k přidání WebVTT stopy titulků.
1. Uložte upravenou prezentaci.

Následující kód ukazuje, jak přidat titulky do video rámce:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Přidá novou stopu titulků ze souboru WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rozhraní [ICaptionsCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/) také poskytuje přetížení, které vám umožní přidávat titulky ze streamu.

**Extract Captions from a Video Frame**

Pro extrahování titulků z video rámce:

1. Načtěte prezentaci, která obsahuje video.
1. Najděte cílový objekt [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/) .
1. Procházejte titulkové stopy vrácené metodou [getCaptionTracks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Uložte každou titulkovou stopu do souboru `.vtt`.

Následující kód ukazuje, jak extrahovat titulky z video rámce:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Uloží stopu titulků do souboru WebVTT.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Každý [ICaptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptions/) objekt vystavuje identifikátor titulků, štítek, binární data a data titulků jako řetězec UTF-8.

**Remove Captions from a Video Frame**

Pro odstranění titulků z video rámce:

1. Načtěte prezentaci, která obsahuje video.
1. Získejte cílový objekt [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/) .
1. Odstraňte titulkové stopy ze sbírky vrácené metodou [getCaptionTracks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Uložte upravenou prezentaci.

Následující kód ukazuje, jak odstranit všechny titulky z video rámce:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Odstraní všechny titulky z video rámce.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pokud potřebujete odstranit jen jednu stopu titulků, použijte metody [remove](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) nebo [removeAt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) místo [clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/#clear--) .

## **Extract Video from a Slide**

Kromě přidávání videí do snímků umožňuje Aspose.Slides také extrahovat videa vložená v prezentacích.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) pro načtení prezentace obsahující video.
2. Procházejte všechny objekty [ISlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/) .
3. Procházejte všechny objekty [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) a najděte [VideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/videoframe/) .
4. Uložte video na disk.

Tento Java kód ukazuje, jak extrahovat video ze snímku v prezentaci:

```java
// Vytvoří objekt Presentation, který představuje soubor prezentace 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                // Získá příponu souboru
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Which video playback parameters can be changed for a VideoFrame?**

Můžete nastavit [playback mode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automaticky nebo po kliknutí) a [looping](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Tyto možnosti jsou dostupné prostřednictvím vlastností objektu [VideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/videoframe/) .

**Does adding a video affect the PPTX file size?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když přidáte online video, vloží se odkaz a miniatura, takže nárůst velikosti je menší.

**Can I replace the video in an existing VideoFrame without changing its position and size?**

Ano. Můžete vyměnit [video content](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) v rámci zachováním geometrie tvaru; jedná se o běžný scénář pro aktualizaci médií v existujícím rozložení.

**Can the content type (MIME) of an embedded video be determined?**

Ano. Vložené video má [content type](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/video/#getContentType--) , který můžete přečíst a použít, například při ukládání na disk.