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
description: "Naučte se programově přidávat a extrahovat video rámy v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro Android v jazyce Java. Rychlý návod jak na to."
---
## **Úvod**

Dobře umístěné video v prezentaci může učinit vaši zprávu přesvědčivější a zvýšit úroveň zapojení publika.

PowerPoint vám umožňuje přidávat videa do snímku v prezentaci dvěma způsoby:

* Přidat nebo vložit lokální video (uložené ve vašem počítači)
* Přidat online video (z webového zdroje, např. YouTube).

Aspose.Slides poskytuje rozhraní [IVideo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideo/), rozhraní [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/) a další relevantní typy, aby bylo možné přidávat videa (video objekty) do prezentace.

## **Vytvoření vloženého video rámce**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video rámec pro vložení videa do prezentace.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideo/) a předávejte cestu k video souboru pro vložení videa do prezentace.
1. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/) pro vytvoření rámce videa.
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

Alternativně můžete přidat video předáním cesty k souboru přímo metodě [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Vytvoření video rámce s videem z webového zdroje**

Novější verze Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporují online videa v prezentacích. Pokud je video, které chcete použít, dostupné online (např. na YouTube), můžete jej přidat do prezentace pomocí jeho webového odkazu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Získejte odkaz na snímek podle jeho indexu.
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

## **Ořezání video rámce**

Aspose.Slides vám umožňuje řídit, která část videa se přehrává, nastavením hodnot trim-from-start a trim-from-end pomocí [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) a [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Obě hodnoty jsou zadány v milisekundách a určují, kolik času se přeskočí od začátku a konce videa. Tato nastavení mění nastavení přehrávání videa v prezentaci; nevyříznou ani jinak nemění binární data vloženého videa.

**Nastavení ořezu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideo/) do prezentace.
1. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/) na snímek.
1. Nastavte hodnoty trim-from-start a trim-from-end pomocí [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) a [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Uložte upravenou prezentaci.

Následující příklad kódu přeskočí první 2,5 sekundy a poslední sekundu vloženého videa během přehrávání:

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Čtení nastavení ořezu**

Pro kontrolu existujících nastavení ořezu načtěte prezentaci, najděte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/) mezi tvary na prvním snímku a přečtěte hodnoty pomocí [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) a [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

Následující příklad kódu najde první video rámec na prvním snímku a vypíše jeho nastavení ořezu v milisekundách:

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Správa titulků videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video rámy v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou dostupné přes metodu [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Přidání titulků do video rámce**

Pro přidání titulků do video rámce:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Přidejte video do prezentace.
1. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/) na snímek.
1. Použijte kolekci [ICaptionsCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/) vrácenou metodou [getCaptionTracks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) pro přidání WebVTT stopy titulků.
1. Uložte upravenou prezentaci.

Následující kód ukazuje, jak přidat titulky do video rámce:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Přidá novou stopu titulků z WebVTT souboru.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rozhraní [ICaptionsCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/) také poskytuje přetížení, které umožňuje přidat titulky ze streamu.

**Extrahování titulků z video rámce**

Pro extrahování titulků z video rámce:

1. Načtěte prezentaci, která obsahuje video.
1. Najděte cílový objekt [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/).
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

Každý objekt [ICaptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptions/) vystavuje identifikátor titulků, štítek, binární data a data titulků jako řetězec UTF-8.

**Odstranění titulků z video rámce**

Pro odstranění titulků z video rámce:

1. Načtěte prezentaci, která obsahuje video.
1. Získejte cílový objekt [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/).
1. Odstraňte titulkové stopy z kolekce vrácené metodou [getCaptionTracks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
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

Pokud potřebujete odstranit pouze jednu titulkovou stopu, použijte metodu [remove](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) nebo [removeAt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) místo [clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/#clear--).

## **Extrahování videa ze snímku**

Kromě přidávání videí do snímků umožňuje Aspose.Slides také extrahovat videa vložená v prezentacích.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) pro načtení prezentace obsahující video.
2. Projděte všechny objekty [ISlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/).
3. Projděte všechny objekty [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) a najděte [VideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/videoframe/).
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

## **Často kladené otázky**

**Které parametry přehrávání videa lze změnit u VideoFrame?**

Můžete řídit [režim přehrávání](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automaticky nebo při kliknutí) a [opakování](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Tyto možnosti jsou dostupné přes vlastnosti objektu [VideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/videoframe/).

**Zvyšuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když přidáte online video, vloží se odkaz a miniatura, takže nárůst velikosti je menší.

**Mohu nahradit video v existujícím VideoFrame, aniž bych změnil jeho polohu a velikost?**

Ano. Můžete vyměnit [video obsah](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) v rámci zachovávaje geometrii tvaru; jedná se o běžný scénář aktualizace médií v existujícím rozvržení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/video/#getContentType--) který můžete přečíst a použít, například při ukládání na disk.