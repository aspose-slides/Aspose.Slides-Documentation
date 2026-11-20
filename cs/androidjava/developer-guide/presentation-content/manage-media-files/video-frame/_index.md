---
title: Správa video snímků v prezentacích na Androidu
linktitle: Video snímek
type: docs
weight: 10
url: /cs/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video snímky v PowerPoint a OpenDocument prezentacích pomocí Aspose.Slides pro Android přes Java. Rychlý návod."
---
## **Úvod**

Videa mohou pomoci vysvětlit nápady a zapojit publikum. Aspose.Slides pro Android prostřednictvím Java vám umožňuje přidávat video snímky do prezentací, upravovat nastavení přehrávání, spravovat titulky a extrahovat vložená video data.

PowerPoint podporuje lokální videa i odkazy na online videa, například videa z YouTube.

Pro reprezentaci video dat a video snímků Aspose.Slides poskytuje rozhraní [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/), rozhraní [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) a další relevantní typy.

## **Vytvořit vložený video snímek**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video snímek a vložit video do prezentace.

Tento příklad vloží lokální video na první snímek existující prezentace a uloží výsledek. Souřadnice a rozměry snímku jsou v bodech. Proud zůstává otevřený až do dokončení ukládání, protože [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) jej udržuje zamčený, dokud jej prezentace používá.

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

Můžete také předat cestu k lokálnímu videu přímo metodě [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Tento příklad vloží video na první snímek nové prezentace. Video musí zůstat přístupné, dokud není prezentace uložena.

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

## **Vytvořit video snímek s videem z webového zdroje**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit video snímek, který odkazuje na online video, například video z YouTube.

Tento příklad přidá odkaz na YouTube video a miniaturu na první snímek. Nahraďte identifikátor videa, pokud chcete použít jiné video. Metoda [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) požaduje automatické přehrávání. Stažení miniatury a přehrávání videa vyžadují přístup k internetu. Prohlížeč prezentací také musí podporovat přehrávání online videa.

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

V tréninkové prezentaci můžete přehrát demonstraci softwaru v režimu celé obrazovky, aby publikum vidělo detaily. Zavolejte [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) s hodnotou `true`, abyste během přehrávání povolili toto chování.

Tento příklad otevře prezentaci, najde první [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) na prvním snímku a povolí přehrávání v celé obrazovce. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video snímkem na prvním snímku.

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

Přehrávání v celé obrazovce určuje, jak je video zobrazeno. Samostatně metoda [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) řídí, zda se spustí automaticky nebo po kliknutí, a metoda [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) určuje, zda se opakuje. Pro výběr chování spuštění nastavte režim přehrávání na [VideoPlayModePreset.Auto nebo VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). Příklad zachovává stávající nastavení spuštění a smyčky.

## **Převinout video po přehrání**

V tréninkové prezentaci vrácení ukázkového videa na začátek připraví video pro další přehrání. Zavolejte [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) s hodnotou `true`, aby se video po dokončení přehrávání vrátilo na začátek.

Tento příklad otevře prezentaci, najde první [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) na prvním snímku a povolí převíjení. Zakáže smyčkování, aby přehrávání mohlo skončit, a nastaví přehrávání tak, aby začínalo po kliknutí. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video snímkem na prvním snímku.

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

Převíjení vrátí video na jeho začátek, aniž by se spustilo znovu. Naopak volání [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) s hodnotou `true` způsobí automatické opakování přehrávání. Ponechte smyčkování vypnuté, pokud chcete, aby video skončilo a zůstalo připravené k opětovnému přehrání. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) nezávisle řídí automatické nebo klikací spuštění; tento příklad používá [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/), takže prezentující kontroluje, kdy se přehrávání spustí. Nastavte režim přehrávání po nastavení smyčky, jak je ukázáno v příkladu. Převíjení funguje nezávisle na [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Uřezat video snímek**

Použijte [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) a [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) k přeskočení části začátku nebo konce videa během přehrávání. Obě hodnoty jsou v milisekundách. Ořezávání mění nastavení přehrávání, aniž by měnilo vložená video data.

**Nastavit nastavení ořezu**

Tento příklad vloží lokální video a během přehrávání přeskočí první 2,5 s a poslední sekundu. Použijte video delší než 3,5 s, aby zůstala přehratelná část.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Načíst nastavení ořezu**

Tento příklad vypíše hodnoty ořezu prvního video snímku na prvním snímku v milisekundách. Prezentace musí obsahovat alespoň jeden snímek. Pokud tento snímek neobsahuje video snímek, nic se nevyzvedne. Předchozí příklad produkuje hodnoty 2500 a 1000.

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

## **Spravovat titulky videa**

Aspose.Slides umožňuje spravovat uzavřené titulky pro video snímky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou zpřístupněny prostřednictvím metody [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

### **Přidat titulky do video snímku**

Tento příklad vloží lokální video a přidá stopu titulků WebVTT označenou jako English. Časové značky titulků by měly odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rozhraní [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) také poskytuje přetížení, které umožňuje přidat titulky ze streamu.

### **Extrahovat titulky z video snímku**

Tento příklad uloží všechny stopy titulků z video snímků na prvním snímku jako samostatné soubory WebVTT. Postupně číslované soubory zajišťují, že jsou výstupní soubory odlišné. Konzole hlásí počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden snímek.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Každý objekt [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) vystavuje identifikátor titulků, popisek, binární data a text titulků jako řetězec UTF-8.

### **Odstranit titulky z video snímku**

Tento příklad odstraní všechny titulky z video snímku na první pozici tvaru na prvním snímku a uloží výsledek. Předpokládá, že snímek a tvar existují a že tvar je video snímek.

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

Pokud potřebujete odstranit jen jednu stopu titulků, použijte metody [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) nebo [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) místo [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--).

### **Vyhledat titulky videa**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) vrací kompletní stopu WebVTT, včetně hlavičky, časových řádků a textu titulků. Můžete prohledávat podněty v paměti, abyste našli mluvenou frázi a její časové razítko. Například anglická stopa na snímku 2 může obsahovat následující text.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Příklad otevře `captioned_media.pptx` a použije [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) k načtení stop každého hlavního video snímku na každém snímku. V prostém textovém podnětu časová řádka obsahuje `-->` a prázdný řádek ukončuje podnět. Když titulky obsahují slovo „café“ v libovolném velkém či malém písmenu, příklad vypíše číslo snímku, popisek stopy, původní časovou řádku a celý titul.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;

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
                        StringBuilder caption = new StringBuilder();
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            if (caption.length() > 0) {
                                caption.append('\n');
                            }
                            caption.append(line);
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

Vyhledávání „café“ vrátí jeden výsledek pro ukázkovou stopu. Vyhledávání vylučuje hlavičku stopy a zachovává časové nastavení ve výstupu.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrahovat video ze snímku**

Kromě přidávání videí do snímků Aspose.Slides umožňuje extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa ze všech snímků do samostatných číslovaných binárních souborů. Propojená videa jsou přeskočena, protože neobsahují vložená data. Konzole vypíše MIME typ každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; změňte ji podle skutečného typu média, pokud je to potřeba.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

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
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
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

**Jaké parametry přehrávání videa lze změnit pro video snímek?**

Můžete řídit [režim přehrávání](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatický nebo po kliknutí) a [smyčkování](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Tyto možnosti jsou dostupné přes metody objektu [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).

**Zvyšuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když odkazujete na online video a přidáte miniaturu, prezentace uloží pouze odkaz a náhledový obrázek místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím video snímku bez změny jeho polohy a rozměrů?**

Ano. Můžete vyměnit [video obsah](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) ve snímku při zachování geometrie tvaru; to je častý scénář pro aktualizaci médií v existujícím rozložení.

**Lze zjistit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) , který můžete přečíst a použít, například při ukládání na disk.