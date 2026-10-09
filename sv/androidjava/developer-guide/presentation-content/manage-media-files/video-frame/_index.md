---
title: Hantera videoramar i presentationer på Android
linktitle: Videoram
type: docs
weight: 10
url: /sv/androidjava/video-frame/
keywords:
- lägga till video
- skapa video
- bädda in video
- extrahera video
- hämta video
- videoram
- webbkälla
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig att programatiskt lägga till och extrahera videoramar i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Android via Java. Snabb guide för hur man gör."
---
## **Introduktion**

Videor kan hjälpa till att förklara idéer och engagera en publik. Aspose.Slides for Android via Java låter dig lägga till videoramar på bildspel, justera uppspelningsinställningar, hantera undertexter och extrahera inbäddade videodata.

PowerPoint stöder lokala videor och länkar till online‑videor, såsom YouTube‑videor.

För att representera videodata och videoramar tillhandahåller Aspose.Slides gränssnitten [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) och [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) samt andra relevanta typer.

## **Skapa en inbäddad videoram**

Om videofilen du vill lägga till på din bild sparas lokalt kan du skapa en videoram för att bädda in videon i din presentation.

Detta exempel bäddar in en lokal video på den första bilden i en befintlig presentation och sparar resultatet. Ramens koordinater och dimensioner är i punkter. Strömmen förblir öppen tills sparandet är klart eftersom [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) låser den medan presentationen använder den.

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

Du kan också skicka en lokal videoväg direkt till [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Detta exempel bäddar in videon på den första bilden i en ny presentation. Videon måste förbli tillgänglig tills presentationen sparas.

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

## **Skapa en videoram med video från en webbkälla**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) stöder online‑videor i presentationer. Du kan skapa en videoram som länkar till en online‑video, t.ex. en YouTube‑video.

Detta exempel lägger till en YouTube‑videolänk och en miniatyr på den första bilden. Ersätt videoberättaren för att använda en annan video. Metoden [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) begär automatisk uppspelning. Nedladdning av miniatyren och uppspelning av videon kräver internetåtkomst. Presentationsvisaren måste också stödja online‑videouppspelning.

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

## **Spela upp en video i helskärmsläge**

I en träningspresentation kan du spela upp en mjukvarudemonstration i helskärmsläge så publiken kan se detaljerna. Anropa [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) med `true` för att aktivera detta beteende under uppspelning.

Detta exempel öppnar en presentation, hittar den första [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) på den första bilden och aktiverar helskärmsuppspelning. Indatapresentationen måste innehålla minst en bild med en befintlig videoram på den första bilden.

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

Helskärmsuppspelning styr hur videon visas. Oberoende styr [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) om den startar automatiskt eller vid klick, och [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) styr om den upprepas. För att välja startbeteende, sätt uppspelningsläget till [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). Exemplet bevarar de befintliga start‑ och loop‑inställningarna.

## **Spola tillbaka en video efter uppspelning**

I en träningspresentation gör att återföra en demonstrationsvideo till början den redo för presentatören att spela igen. Anropa [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) med `true` för att returnera videon till början efter att uppspelningen är klar.

Detta exempel öppnar en presentation, hittar den första [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) på den första bilden och aktiverar spolning. Det inaktiverar loopning så att uppspelningen kan avslutas och sätter uppspelning att starta vid klick. Indatapresentationen måste innehålla minst en bild med en befintlig videoram på den första bilden.

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

Spolning återför videon till början utan att starta den igen. Däremot upprepar ett anrop av [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) med `true` uppspelning automatiskt. Håll loopning inaktiverad när du vill att videon skall avslutas och vara redo för återuppspelning. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) styr oberoende om uppspelning sker automatiskt eller vid klick; detta exempel använder [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) så presentatören kontrollerar när uppspelning startar. Ställ in uppspelningsläget efter loop‑inställningen, som visas i exemplet. Spolning fungerar oberoende av [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Trimma en videoram**

Använd [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) och [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) för att hoppa över en del av början eller slutet av en video under uppspelning. Båda värdena är i millisekunder. Trimning ändrar uppspelningsinställningarna utan att modifiera den inbäddade videodatan.

**Ställ in triminställningar**

Detta exempel bäddar in en lokal video och hoppar över de första 2,5 sekunderna och den sista sekunden under uppspelning. Använd en video som är längre än 3,5 sekunder så att ett spelbart segment återstår.

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

**Läs triminställningar**

Detta exempel skriver ut trimvärdena för den första videoramen på den första bilden i millisekunder. Presentationen måste innehålla minst en bild. Om den bilden saknar videoram skrivs inget ut. Det föregående exemplet ger värdena 2500 och 1000.

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

## **Hantera videobeskrivningar**

Aspose.Slides låter dig hantera stängda undertexter för videoramar i PowerPoint-presentationer. Undertexterna lagras i WebVTT‑format och exponeras via metoden [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Lägg till undertexter i en videoram**

Detta exempel bäddar in en lokal video och lägger till ett WebVTT‑undertextspår med etiketten English. Undertextens tidsstämplar bör matcha videon. Den sparade presentationen innehåller både videon och dess undertexter.

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

Gränssnittet [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) erbjuder även en överlagring som låter dig lägga till undertexter från en ström.

**Extrahera undertexter från en videoram**

Detta exempel sparar alla undertextspår från videoramar på den första bilden som separata WebVTT‑filer. Sekventiella nummer håller utdatafilerna distinkta. Konsolen rapporterar antalet extraherade spår. Presentationen måste innehålla minst en bild.

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

Varje [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/)‑objekt exponerar undertextens identifierare, etikett, binär data och undertexten som en UTF‑8‑sträng.

**Ta bort undertexter från en videoram**

Detta exempel tar bort alla undertexter från videoramen på den första formens position på den första bilden och sparar resultatet. Det förutsätter att bilden och formen finns samt att formen är en videoram.

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

Om du bara behöver ta bort ett undertextspår, använd metoderna [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) eller [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) istället för [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--).

## **Extrahera video från en bild**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

Detta exempel extraherar inbäddade videor från varje bild till separata, numrerade binära filer. Länkade videor hoppas över eftersom de saknar inbäddad data. Konsolen skriver ut varje videos MIME‑typ och det totala antalet. Utdata använder den generiska filändelsen `.bin`; ändra den för att matcha den rapporterade mediatypen vid behov.

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

## **Vanliga frågor**

**Vilka videouppspelningsparametrar kan ändras för en videoram?**

Du kan kontrollera [uppspelningsläget](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (auto eller vid klick) och [loopning](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Dessa alternativ är tillgängliga via metoderna på objektet [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas den binära datan i dokumentet, så presentationens storlek ökar proportionellt mot filens storlek. När du länkar till en online‑video och lägger till en miniatyr sparar presentationen länken och förhandsbilden i stället för videodata, så storleksökningen är vanligtvis mindre.

**Kan jag byta ut videon i en befintlig videoram utan att ändra dess position och storlek?**

Ja. Du kan byta ut [videoinnehållet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) i ramen medan du behåller formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [innehållstyp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) som du kan läsa och använda, till exempel när du sparar den till disk.