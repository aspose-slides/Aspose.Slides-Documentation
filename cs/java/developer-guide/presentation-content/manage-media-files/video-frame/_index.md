---
title: Správa video rámečků v prezentacích pomocí Java
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
description: "Naučte se programově přidávat a extrahovat video rámečky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro Java. Rychlý návod krok za krokem."
---
## **Úvod**

Videa mohou pomoci vysvětlit nápady a zapojit publikum. Aspose.Slides pro Java vám umožňuje přidávat video rámečky do snímků, upravovat nastavení přehrávání, spravovat titulky a extrahovat vložená video data.

PowerPoint podporuje místní videa i odkazy na online videa, například videa z YouTube.

Pro reprezentaci video dat a video rámečků poskytuje Aspose.Slides rozhraní [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , rozhraní [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) a další relevantní typy.

## **Vytvoření vloženého video rámečku**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video rámeček pro vložení videa do vaší prezentace.

Tento příklad vloží místní video na první snímek existující prezentace a uloží výsledek. Souřadnice a rozměry rámečku jsou v bodech. Proud zůstává otevřený až do dokončení uložení, protože [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) jej udržuje zamčený, dokud je prezentace používá.

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

Můžete také předat cestu k místnímu videu přímo metodě [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Tento příklad vloží video na první snímek nové prezentace. Video musí zůstat přístupné až do uložení prezentace.

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

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit video rámeček, který odkazuje na online video, například na YouTube video.

Tento příklad přidá odkaz na YouTube video a miniaturu na první snímek. Nahraďte identifikátor videa, pokud chcete použít jiné video. Metoda [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) požaduje automatické přehrávání. Stahování miniatury a přehrávání videa vyžadují přístup k internetu. Prohlížeč prezentací také musí podporovat přehrávání online videí.

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

## **Přehrát video v režimu celé obrazovky**

V tréninkové prezentaci můžete přehrávat ukázku softwaru v režimu celé obrazovky, aby publikum vidělo detaily. Zavolejte [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) s hodnotou `true`, aby se toto chování během přehrávání povolilo.

Tento příklad otevře prezentaci, najde první [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) na první snímku a povolí přehrávání na celou obrazovku. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video rámečkem na prvním snímku.

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

Přehrávání na celou obrazovku určuje, jak se video zobrazuje. Samostatně metoda [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) řídí, zda se spustí automaticky nebo po kliknutí, a [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) určuje, zda se opakuje. Pro výběr chování spuštění nastavte režim přehrávání na [VideoPlayModePreset.Auto nebo VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). Příklad zachovává existující nastavení spuštění a smyčky.

## **Převíjení videa po přehrání**

V tréninkové prezentaci vrácení demonstračního videa na začátek jej připraví pro opětovné přehrání prezentátorem. Zavolejte [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) s hodnotou `true`, aby se video po dokončení přehrávání vrátilo na začátek.

Tento příklad otevře prezentaci, najde první [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) na první snímku a povolí převíjení. Vypne smyčku, aby přehrávání mohlo skončit, a nastaví přehrávání tak, aby se spustilo kliknutím. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video rámečkem na prvním snímku.

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

Převíjení vrátí video na začátek, aniž by ho znovu spustilo. Naopak volání [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) s `true` automaticky opakuje přehrávání. Ponechte smyčku vypnutou, pokud chcete, aby video skončilo a bylo připravené k opětovnému přehrání. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) samostatně řídí automatické nebo kliknutím spouštění; tento příklad používá [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) , takže prezentátor řídí, kdy se přehrávání spustí. Nastavte režim přehrávání po nastavení smyčky, jak je ukázáno v příkladu. Převíjení funguje nezávisle na [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Ořezání video rámečku**

Použijte [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) a [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) , abyste při přehrávání přeskočili část začátku nebo konce videa. Obě hodnoty jsou v milisekundách. Ořezávání mění nastavení přehrávání, aniž by modifikovalo vložená video data.

**Nastavení ořezu**

Tento příklad vloží místní video a při přehrávání přeskočí první 2,5 sekundy a poslední sekundu. Použijte video delší než 3,5 sekundy, aby zůstala přehratelná část.

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

Tento příklad vypíše hodnoty ořezu prvního video rámečku na prvním snímku v milisekundách. Prezentace musí obsahovat alespoň jeden snímek. Pokud tento snímek nemá video rámeček, nic se nevyptí. Předchozí příklad produkuje hodnoty 2500 a 1000.

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

## **Správa titulků videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video rámečky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou zpřístupněny pomocí metody [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

### **Přidání titulků k video rámečku**

Tento příklad vloží místní video a přidá WebVTT stopu titulků označenou English. Časové razítka titulků by měla odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

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

Rozhraní [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) také poskytuje přetížení, které vám umožní přidat titulky ze streamu.

### **Extrahování titulků z video rámečku**

Tento příklad uloží všechny stopy titulků z video rámečků na prvním snímku jako samostatné WebVTT soubory. Sekvenční čísla udržují výstupní soubory odlišné. Konzole vypíše počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden snímek.

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

Každý objekt [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) vystavuje identifikátor titulku, popisek, binární data a text titulku jako řetězec UTF‑8.

### **Odstranění titulků z video rámečku**

Tento příklad odstraní všechny titulky z video rámečku na první pozici tvaru na prvním snímku a uloží výsledek. Předpokládá, že snímek a tvar existují a že tvar je video rámeček.

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

Pokud potřebujete odstranit pouze jednu stopu titulků, použijte metody [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) nebo [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-), místo [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--) .

### **Vyhledávání titulků videa**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) vrací kompletní WebVTT stopu, včetně hlavičky, časových řádků a textu titulků. Můžete prohledávat cue v paměti a najít mluvenou frázi a její časové razítko. Například anglická stopa na snímku 2 může obsahovat následující text.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Příklad otevře `captioned_media.pptx` a použije [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) , aby načetl stopy každého nejvyššího video rámečku na každém snímku. V prostém textovém cue obsahuje časový řádek `-->` a prázdný řádek cue ukončuje. Když titulky obsahují „café“ v libovolném velikosti písmen, příklad vypíše číslo snímku, popisek stopy, původní časový řádek a celý titulek.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;
import java.util.StringJoiner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringJoiner caption = new StringJoiner(System.lineSeparator());
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            caption.add(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Vyhledávání „café“ vrátí jeden výsledek pro vzorovou stopu. Vyhledávání vylučuje hlavičku stopy a zachovává nastavení časování ve výstupu.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrahování videa ze snímku**

Kromě přidávání videí do snímků umožňuje Aspose.Slides také extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa z každého snímku do samostatných číslovaných binárních souborů. Odkazovaná videa jsou přeskočena, protože nemají vložená data. Konzole vypíše MIME typ každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; v případě potřeby ji změňte tak, aby odpovídala hlášenému typu média.

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

## **FAQ**

**Jaké parametry přehrávání videa lze u video rámečku změnit?**

Můžete ovládat [režim přehrávání](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automaticky nebo po kliknutí) a [opakování](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Tyto možnosti jsou dostupné prostřednictvím metod objektu [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) .

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte místní video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když odkazujete na online video a přidáte miniaturu, prezentace uloží odkaz a náhledový obrázek místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím video rámečku, aniž bych měnil jeho polohu a velikost?**

Ano. Můžete vyměnit [video obsah](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) v rámečku při zachování geometrie tvaru; to je běžný scénář pro aktualizaci médií v existujícím rozvržení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) , který můžete přečíst a použít, například při ukládání na disk.