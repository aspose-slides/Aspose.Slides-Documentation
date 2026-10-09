---
title: Správa video rámečků v prezentacích pomocí Javy
linktitle: Video rámeček
type: docs
weight: 10
url: /cs/java/video-frame/
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
- Java
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video rámečky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro Javu. Rychlý návod."
---
## **Úvod**

Videa mohou pomoci vysvětlit nápady a zaujmout publikum. Aspose.Slides pro Java vám umožňuje přidávat video rámečky do snímků, upravovat nastavení přehrávání, spravovat titulky a extrahovat vložená video data.

PowerPoint podporuje lokální videa i odkazy na online videa, například videa na YouTube.

Pro reprezentaci video dat a video rámečků Aspose.Slides poskytuje rozhraní [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) rozhraní [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) a další relevantní typy.

## **Vytvoření vloženého video rámečku**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video rámeček pro vložení videa do vaší prezentace.

Tento příklad vloží lokální video na první snímek existující prezentace a uloží výsledek. Souřadnice a rozměry rámečku jsou v bodech. Stream zůstává otevřený až do dokončení ukládání, protože [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) jej udržuje uzamčený, dokud ho prezentace používá.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Můžete také předat cestu k lokálnímu videu přímo metodě [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Tento příklad vloží video na první snímek nové prezentace. Video musí zůstat přístupné až do uložení prezentace.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vytvoření video rámečku s videem z webového zdroje**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit video rámeček, který odkazuje na online video, například video z YouTube.

Tento příklad přidá odkaz na YouTube video a náhledový obrázek na první snímek. Nahraďte identifikátor videa, chcete-li použít jiné video. Metoda [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) požaduje automatické přehrávání. Stažení náhledového obrázku a přehrání videa vyžadují připojení k internetu. Prohlížeč prezentací také musí podporovat přehrávání online videí.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přehrát video v režimu celá obrazovka**

V tréninkové prezentaci můžete přehrát ukázku softwaru v režimu celé obrazovky, aby publikum vidělo detaily. Zavolejte [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) s `true`, abyste během přehrávání tuto funkci aktivovali.

Tento příklad otevře prezentaci, najde první [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) na první snímku a povolí přehrávání v režimu celé obrazovky. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video rámečkem na první snímku.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Přehrávání v režimu celé obrazovky určuje, jak je video zobrazeno. Samostatně [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) řídí, zda se spustí automaticky nebo po kliknutí, a [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) řídí, zda se opakuje. Pro výběr chování při spuštění nastavte režim přehrávání na [VideoPlayModePreset.Auto nebo VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). Příklad zachovává existující nastavení spuštění a smyčky.

## **Přetočit video po přehrání**

V tréninkové prezentaci vrácení demonstračního videa na začátek připraví video k opětovnému přehrání. Zavolejte [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) s `true`, aby se video po skončení přehrávání vrátilo na začátek.

Tento příklad otevře prezentaci, najde první [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) na první snímku a povolí přetáčení. Zakáže opakování, aby se přehrávání mohlo dokončit, a nastaví přehrávání na spuštění po kliknutí. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video rámečkem na první snímku.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Přetáčení vrací video na začátek, aniž by jej znovu spustilo. Naopak volání [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) s `true` automaticky opakuje přehrávání. Ponechte opakování zakázáno, když chcete, aby se video dokončilo a zůstalo připravené k opětovnému přehrání. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) samostatně řídí automatické nebo klikací spuštění; tento příklad používá [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/), takže prezentující ovládá, kdy se přehrávání spustí. Nastavte režim přehrávání po nastavení smyčky, jak je ukázáno v příkladu. Přetáčení funguje nezávisle na [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Oříznout video rámeček**

Použijte [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) a [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-), abyste během přehrávání přeskočili část začátku nebo konce videa. Obě hodnoty jsou v milisekundách. Ořezávání mění nastavení přehrávání, aniž by měnilo vložená video data.

**Nastavit nastavení ořezu**

Tento příklad vloží lokální video a během přehrávání přeskočí první 2,5 sekundy a poslední sekundu. Použijte video delší než 3,5 sekundy, aby zůstala přehratelná část.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Načíst nastavení ořezu**

Tento příklad vytiskne hodnoty ořezu prvního video rámečku na první snímku v milisekundách. Prezentace musí obsahovat alespoň jeden snímek. Pokud tento snímek nemá video rámeček, nic se nevytiskne. Předchozí příklad produkuje hodnoty 2500 a 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Spravovat video titulky**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video rámečky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou zpřístupněny prostřednictvím metody [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Přidat titulky do video rámečku**

Tento příklad vloží lokální video a přidá WebVTT stopu titulků označenou English. Časové razítka titulků by měla odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rozhraní [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) také poskytuje přetížení, které umožňuje přidávat titulky ze streamu.

**Extrahovat titulky z video rámečku**

Tento příklad uloží všechny stopy titulků z video rámečků na první snímek jako samostatné WebVTT soubory. Postupná číslování udržuje výstupní soubory odlišné. Konzole vypíše počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden snímek.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Každý objekt [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) poskytuje identifikátor titulku, popisek, binární data a text titulu jako řetězec UTF-8.

**Odstranit titulky z video rámečku**

Tento příklad odstraní všechny titulky z video rámečku na první pozici objektu na první snímku a uloží výsledek. Předpokládá existenci snímku a objektu a že objekt je video rámeček.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pokud potřebujete odstranit jen jednu stopu titulků, použijte metody [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) nebo [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-), místo [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

## **Extrahovat video ze snímku**

Kromě přidávání videí do snímků umožňuje Aspose.Slides extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa ze všech snímků do samostatných číslovaných binárních souborů. Propojená videa jsou přeskočena, protože nemají vložená data. Konzole vypíše MIME typ každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; v případě potřeby ji změňte tak, aby odpovídala hlášenému typu média.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Které parametry přehrávání videa lze změnit u video rámečku?**

Můžete řídit [režim přehrávání](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automaticky nebo po kliknutí) a [opakování](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Tyto možnosti jsou k dispozici prostřednictvím metod objektu [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když odkazujete na online video a přidáte náhledový obrázek, prezentace uloží pouze odkaz a obrázek náhledu místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím video rámečku, aniž bych změnil jeho pozici a velikost?**

Ano. Můžete vyměnit [video obsah](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) v rámci rámečku při zachování geometrie objektu; to je běžný scénář pro aktualizaci média v existujícím rozvržení.

**Lze zjistit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) , který můžete přečíst a použít, například při ukládání na disk.