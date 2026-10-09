---
title: Videókeretek kezelése bemutatókban Androidon
linktitle: Videókeret
type: docs
weight: 10
url: /hu/androidjava/video-frame/
keywords:
- videó hozzáadása
- videó létrehozása
- videó beágyazása
- videó kinyerése
- videó lekérése
- videókeret
- webes forrás
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Tanulja meg programozott módon videókeretek hozzáadását és kinyerését PowerPoint és OpenDocument diákban az Aspose.Slides for Android Java használatával. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek az ötletek magyarázatában és a közönség bevonásában. Az Aspose.Slides for Android Java-n keresztül lehetővé teszi, hogy videókereteket adj hozzá diákhoz, módosítsd a lejátszási beállításokat, kezeld a feliratokat, és kinyerd a beágyazott videóadatokat.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube‑videókat.

A videóadatok és videókeretek ábrázolásához az Aspose.Slides biztosítja a [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) interfészt, a [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) interfészt és más kapcsolódó típusokat.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videofájl helyileg van tárolva, létrehozhatsz egy videókeretet a videó a bemutatóba történő beágyazásához.

Ez a példa egy helyi videót ágyaz be egy meglévő bemutató első diájára, és elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A folyam (stream) nyitva marad a mentés befejezéséig, mert a [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a bemutató használja.

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

A helyi videó útvonalát közvetlenül is átadhatod a [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Ez a példa a videót egy új bemutató első diájára ágyazza be. A videónak a mentés befejezéséig elérhetőnek kell maradnia.

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

## **Webes forrásból származó videóval rendelkező videókeret létrehozása**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a bemutatókban. Létrehozhatsz egy videókeretet, amely egy online videóra hivatkozik, például egy YouTube‑videóra.

Ez a példa egy YouTube‑videó hivatkozást és miniatűr képet ad az első diához. Cseréld le a videó azonosítót, ha másik videót szeretnél használni. A [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) metódus automatikus lejátszást kér. A miniatűr letöltése és a videó lejátszása internetkapcsolatot igényel. A bemutató megjelenítőnek szintén támogatnia kell az online videó lejátszását.

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

## **Videó lejátszása teljes képernyő módban**

Egy képzési bemutatóban lejátszhatod a szoftverbemutatót teljes képernyő módban, hogy a közönség lássa a részleteket. Hívd meg a [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) `true` értékkel a viselkedés engedélyezéséhez a lejátszás során.

Ez a példa megnyit egy bemutatót, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti bemutatónak legalább egy diát kell tartalmaznia, amelyen már létezik videókeret az első dián.

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

A teljes képernyős lejátszás szabályozza, hogy a videó hogyan jelenik meg. Függetlenül, a [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) határozza meg, hogy automatikusan vagy kattintásra induljon, a [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) pedig szabályozza, hogy ismétlődjön-e. A kezdési viselkedés kiválasztásához állítsd a lejátszási módot a [VideoPlayModePreset.Auto vagy VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) értékre. A példa megőrzi a meglévő kezdési és ismétlődési beállításokat.

## **Videó visszatekerése lejátszás után**

Egy képzési bemutatóban a demonstrációs videó elejére való visszatérés kész állapotba hozza a felvételt, hogy a prezentáló újra lejátszhassa. Hívd meg a [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) `true` értékkel, hogy a lejátszás befejezése után a videó visszatérjen a kezdethez.

Ez a példa megnyit egy bemutatót, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) az első dián, és engedélyezi a visszatekerést. Letiltja az ismétlést, hogy a lejátszás befejeződhessen, és a lejátszást kattintásra állítja be. A bemeneti bemutatónak legalább egy diát kell tartalmaznia, amelyen már létezik videókeret az első dián.

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

A visszatekerés a videót a kezdetéhez viszi vissza anélkül, hogy újra elindulna. Ezzel szemben a [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) `true` értékkel való meghívása automatikusan ismétli a lejátszást. Tartsd letiltva az ismétlést, ha azt szeretnéd, hogy a videó befejeződjön és készen álljon az újrajátszásra. A [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) függetlenül szabályozza az automatikus vagy kattintásos indítást; ez a példa a [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) értéket használja, így a prezentáló dönti el, mikor indul a lejátszás. Állítsd be a lejátszási módot az ismétlési beállítás után, ahogyan a példában látható. A visszatekerés független a [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) működésétől.

## **Videókeret vágása**

Használd az [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) és [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) metódusokat, hogy a lejátszás során kihagyj egy részt a videó elejéről vagy végéről. Mindkét érték ezredmásodpercben van megadva. A vágás módosítja a lejátszási beállításokat anélkül, hogy a beágyazott videó adatát megváltoztatná.

**Vágási beállítások megadása**

Ez a példa egy helyi videót ágyaz be, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó másodpercet. Használj 3,5 másodpercnél hosszabb videót, hogy lejátszható szegmens maradjon.

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

**Vágási beállítások kiolvasása**

Ez a példa kiírja az első videókeret vágási értékeit az első dián ezredmásodpercben. A bemutatónak legalább egy diát kell tartalmaznia. Ha az adott diához nincs videókeret, semmi sem kerül kiírásra. Az előző példa 2500 és 1000 értékeket állított elő.

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

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint bemutatók videókereteihez zárt feliratokat kezelj. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) metóduson keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

Ez a példa egy helyi videót ágyaz be, és hozzáad egy 'English' feliratsávot WebVTT formátumban. A felirat időbélyegeinek a videóval kell egyezniük. A mentett bemutató tartalmazza a videót és a feliratokat is.

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

Az [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) interfész egy túlterhelést is biztosít, amely lehetővé teszi feliratok hozzáadását egy folyam (stream) segítségével.

**Feliratok kinyerése videókeretből**

Ez a példa az első dián lévő videókeretek összes feliratsávját különálló WebVTT fájlokként menti. A sorozatszámok biztosítják, hogy a kimeneti fájlok egyediek legyenek. A konzol jelzi a kinyert sávok számát. A bemutatónak legalább egy diát kell tartalmaznia.

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

Minden [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) objektum megjeleníti a felirat azonosítóját, címkéjét, bináris adatait, valamint a felirat szövegét UTF‑8 karakterláncként.

**Feliratok eltávolítása videókeretből**

Ez a példa eltávolítja az összes feliratot az első dián az első alakzat pozíciójában lévő videókeretből, majd elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat egy videókeret.

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

Ha csak egy feliratsávot szeretnél eltávolítani, használja a [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) vagy a [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) metódusokat a [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) helyett.

## **Videó kinyerése diákról**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a bemutatóba beágyazott videók kinyerését.

Ez a példa minden diáról kinyeri a beágyazott videókat, és külön‑számozott bináris fájlokba menti őket. A hivatkozott videók kihagyásra kerülnek, mert nincs beágyazott adatuk. A konzol kiírja minden videó MIME‑típusát és a teljes darabszámot. A kimenet a generikus `.bin` kiterjesztést használja; szükség esetén módosítható a jelentett médiatípusnak megfelelően.

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

## **GYIK**

**Milyen videólejátszási paraméterek módosíthatók egy videókeretnél?**

A [lejátszási mód](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatikus vagy kattintásra) és az [ismétlés](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) szabályozható. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) objektum metódusain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájlméretet?**

Igen. Amikor egy helyi videót ágyazol be, a bináris adat a dokumentumba kerül, így a bemutató mérete arányosan nő a fájlmérettel. Ha egy online videóra hivatkozol, és miniatűrt adsz hozzá, a bemutató a hivatkozást és az előnézeti képet tárolja a videó adat helyett, így a méretnövekedés általában kisebb.

**Kicserélhetem a videót egy meglévő videókeretben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A kereten belül kicserélheted a [videótartalmat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) anélkül, hogy megváltoztatnád az alakzat geometriáját; ez gyakori eset a médiák frissítésére egy meglévő elrendezésben.

**Megállapítható a beágyazott videó tartalomtípusa (MIME)?**

Igen. Egy beágyazott videó rendelkezik [tartalomtípussal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--), amelyet kiolvashatsz és felhasználhatsz, például a lemezre mentéskor.