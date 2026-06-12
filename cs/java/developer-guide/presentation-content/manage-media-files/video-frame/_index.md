---
title: Správa video rámců v prezentacích pomocí Javy
linktitle: Video rámec
type: docs
weight: 10
url: /cs/java/video-frame/
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
- Java
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video rámečky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro Javu. Rychlý návod krok za krokem."
---
## **Úvod**

Dobře umístěné video v prezentaci může učinit vaše sdělení přesvědčivějším a zvýšit úroveň zapojení publika. 

PowerPoint vám umožňuje přidávat videa na snímek v prezentaci dvěma způsoby:

* Přidat nebo vložit lokální video (uložené ve vašem počítači)
* Přidat online video (z webového zdroje, jako je YouTube).

Aby vám umožnilo přidávat videa (video objekty) do prezentace, Aspose.Slides poskytuje rozhraní [IVideo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivideo/), rozhraní [IVideoFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivideoframe/) a další související typy. 

## **Vytvoření vložených video rámců**

Pokud je video soubor, který chcete přidat na svůj snímek, uložen lokálně, můžete vytvořit video rámec pro vložení videa do vaší prezentace. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho indexu. 
1. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivideo/) a předávejte cestu k video souboru pro vložení videa do prezentace. 
1. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivideoframe/) pro vytvoření rámce pro video.  
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

Alternativně můžete přidat video předáním cesty k souboru přímo metodě [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Vytvoření video rámců s videem z webových zdrojů**

Microsoft [PowerPoint 2013 a novější](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) podporuje videa z YouTube v prezentacích. Pokud je video, které chcete použít, dostupné online (např. na YouTube), můžete jej přidat do prezentace prostřednictvím jeho webového odkazu. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation)
1. Získejte referenci na snímek pomocí jeho indexu. 
1. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivideo/) a předávejte odkaz na video.
1. Nastavte náhled pro video rámec. 
1. Uložte prezentaci. 

Tento Java kód ukazuje, jak přidat video z webu na snímek v PowerPoint prezentaci:

```java
// Instancuje objekt Presentation, který představuje soubor prezentace
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

## **Správa titulků videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video rámce v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou přístupné prostřednictvím metody [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivideoframe/#getCaptionTracks--). 

**Přidat titulky do video rámce**

Jak přidat titulky do video rámce:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) .
2. Přidejte video do prezentace.
3. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivideoframe/) na snímek.
4. Použijte [ICaptionsCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptionscollection/) vrácenou metodou [getCaptionTracks](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) k přidání WebVTT titulkové stopy.
5. Uložte upravenou prezentaci.

Následující kód ukazuje, jak přidat titulky do video rámce:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
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

Rozhraní [ICaptionsCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptionscollection/) také poskytuje přetížení, které umožňuje přidat titulky ze streamu.

**Extrahovat titulky z video rámce**

Jak extrahovat titulky z video rámce:

1. Načtěte prezentaci, která obsahuje video.
2. Najděte cílový objekt [IVideoFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivideoframe/).
3. Iterujte přes titulkové stopy v [ICaptionsCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptionscollection/).
4. Uložte každou titulkovou stopu do souboru `.vtt`.

Následující kód ukazuje, jak extrahovat titulky z video rámce:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Uloží stopu titulků do souboru WebVTT.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Každý objekt [ICaptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptions/) poskytuje identifikátor titulku, štítek, binární data a text titulku jako řetězec UTF-8.

**Odstranit titulky z video rámce**

Jak odstranit titulky z video rámce:

1. Načtěte prezentaci, která obsahuje video.
2. Získejte cílový objekt [IVideoFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivideoframe/).
3. Odstraňte titulkové stopy z [ICaptionsCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptionscollection/).
4. Uložte upravenou prezentaci.

Následující kód ukazuje, jak odstranit všechny titulky z video rámce:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Odstraní všechny titulky z video rámce.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pokud potřebujete odstranit pouze jednu titulkovou stopu, použijte metody [remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) nebo [removeAt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptionscollection/#removeAt-int-) místo [clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptionscollection/#clear--).

## **Extrahovat video ze snímků**

Kromě přidávání videí do snímků vám Aspose.Slides umožňuje extrahovat videa vložená v prezentacích.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) pro načtení prezentace obsahující video. 
2. Iterujte přes všechny objekty [ISlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/).
3. Iterujte přes všechny objekty [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/) pro nalezení [VideoFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/videoframe/). 
4. Uložte video na disk.

Tento Java kód ukazuje, jak extrahovat video ze snímku prezentace:

```java
// Instancuje objekt Presentation, který představuje soubor prezentace 
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

## **Časté dotazy**

**Které parametry přehrávání videa lze změnit pro VideoFrame?**

Můžete ovládat [režim přehrávání](https://reference.aspose.com/slides/cs/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automaticky nebo po kliknutí) a [opakování](https://reference.aspose.com/slides/cs/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Tyto možnosti jsou dostupné prostřednictvím vlastností objektu [VideoFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/videoframe/).

**Zvyšuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta do dokumentu, takže se velikost prezentace zvětší úměrně velikosti souboru. Když přidáte online video, vloží se odkaz a náhled, takže nárůst velikosti je menší.

**Mohu nahradit video ve stávajícím VideoFrame, aniž bych změnil jeho pozici a velikost?**

Ano. Můžete vyměnit [video obsah](https://reference.aspose.com/slides/cs/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) v rámci, přičemž zachováte geometrii tvaru; to je běžný scénář pro aktualizaci médií v existujícím rozložení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/video/#getContentType--) , který můžete přečíst a použít, například při ukládání na disk.