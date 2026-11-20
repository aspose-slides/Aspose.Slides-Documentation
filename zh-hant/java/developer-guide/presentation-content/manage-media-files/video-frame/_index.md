---
title: 使用 Java 管理簡報中的影片框架
linktitle: 影片框架
type: docs
weight: 10
url: /zh-hant/java/video-frame/
keywords:
- 新增影片
- 建立影片
- 嵌入影片
- 擷取影片
- 取得影片
- 影片框架
- 網路來源
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "學習使用 Aspose.Slides for Java 在 PowerPoint 與 OpenDocument 投影片中以程式方式新增與擷取影片框架。快速上手指南。"
---
## **簡介**

影片可以協助說明概念並吸引觀眾。Aspose.Slides for Java 讓您能將影片框架加入投影片、調整播放設定、管理字幕，並擷取嵌入的影片資料。

PowerPoint 支援本機影片以及指向線上影片的連結，例如 YouTube 影片。

為了表示影片資料與影片框架，Aspose.Slides 提供 [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) 介面以及其他相關類型。

## **建立嵌入式影片框架**

如果您想加入投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

此範例在現有簡報的第一張投影片上嵌入本機影片，並儲存結果。框架的座標與尺寸以點為單位。因為 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) 在簡報使用時會鎖定串流，故串流會保持開啟直到儲存完成。

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

您也可以直接將本機影片路徑傳遞給 [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-)。此範例在新簡報的第一張投影片上嵌入影片。影片必須在簡報儲存前保持可存取。

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

## **建立來自網路來源的影片框架**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支援在簡報中嵌入線上影片。您可以建立指向線上影片（例如 YouTube 影片）的影片框架。

此範例在第一張投影片加入 YouTube 影片連結與縮圖。請替換影片識別碼以使用其他影片。[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) 方法會要求自動播放。下載縮圖與播放影片皆需網際網路連線。簡報檢視器也必須支援線上影片播放。

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

## **在全螢幕模式播放影片**

在訓練簡報中，您可以在全螢幕模式下播放軟體示範，讓觀眾看到細節。於播放期間呼叫 [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) 並傳入 `true` 以啟用此行為。

此範例開啟簡報、於第一張投影片找到第一個 [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/)，並啟用全螢幕播放。輸入的簡報必須至少在第一張投影片包含一個現有的影片框架。

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

全螢幕播放會控制影片的顯示方式。獨立地，[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) 控制影片是自動播放還是點擊播放，而 [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 控制是否重複播放。若要選擇起始行為，將播放模式設定為 [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/)。此範例保留了現有的起始與迴圈設定。

## **播放後倒帶影片**

在訓練簡報中，將示範影片倒回開頭可讓簡報者再次播放。於播放結束後呼叫 [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) 並傳入 `true`，即可將影片返回開頭。

此範例開啟簡報、於第一張投影片找到第一個 [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/)，並啟用倒帶。它會停用迴圈以讓播放結束，並將播放設定為點擊開始。輸入的簡報必須至少在第一張投影片包含一個現有的影片框架。

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

倒帶會將影片返回開頭而不會再次啟動。相反地，將 [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 設為 `true` 會自動重複播放。當您希望影片播放結束且保持可重新播放時，請停用迴圈。[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) 讓簡報者自行控制何時開始播放。請如範例所示，在設定迴圈之後再設定播放模式。倒帶的運作與 [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) 無關。

## **裁剪影片框架**

使用 [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) 與 [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) 可以在播放時略過影片的開頭或結尾部分。兩個值皆以毫秒為單位。裁剪會變更播放設定，但不會修改嵌入的影片資料。

**設定裁剪參數**

此範例嵌入本機影片，於播放時略過前 2.5 秒與最後 1 秒。請使用長度超過 3.5 秒的影片，以保留可播放的片段。

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

**讀取裁剪設定**

此範例以毫秒為單位打印第一張投影片上第一個影片框架的裁剪值。簡報必須至少包含一張投影片。若該投影片沒有影片框架，則不會輸出任何內容。前述範例會產生 2500 與 1000 的值。

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

## **管理影片字幕**

Aspose.Slides 讓您能管理 PowerPoint 簡報中影片框架的隱閉字幕。字幕以 WebVTT 格式儲存，並可透過 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) 方法取得。

### **為影片框架新增字幕**

此範例嵌入本機影片，並新增一條標記為 English 的 WebVTT 字幕軌。字幕時間戳記應與影片相符。儲存的簡報同時包含影片與其字幕。

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

[ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) 介面亦提供一個重載，可讓您從串流新增字幕。

### **從影片框架擷取字幕**

此範例將第一張投影片上所有影片框架的字幕軌儲存為個別的 WebVTT 檔案。使用順序編號以區分輸出檔案。主控台會報告擷取的軌道數量。簡報必須至少包含一張投影片。

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

每個 [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) 物件會揭露字幕識別碼、標籤、二進位資料，以及以 UTF-8 字串表示的字幕文字。

### **從影片框架移除字幕**

此範例移除第一張投影片上第一個形狀位置之影片框架的所有字幕，並儲存結果。它假設投影片與形狀皆存在且該形狀為影片框架。

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

如果您只需移除單一字幕軌，請使用 [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) 方法，而非 [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

### **搜尋影片字幕**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) 會回傳完整的 WebVTT 軌道，包含標頭、時間線與字幕文字。您可以在記憶體中搜尋 cue，以找到口語片段及其時間戳記。例如，投影片 2 上的英文軌道可能包含以下文字。

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

此範例開啟 `captioned_media.pptx`，並使用 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) 讀取每張投影片上每個頂層影片框架的軌道。在純文字 cue 中，時間線包含 `-->`，空白行則結束 cue。若字幕中以任何大小寫出現 “café”，範例會打印投影片編號、軌道標籤、原始時間線與完整字幕。

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

搜尋 “café” 會在樣本軌道中產生一筆匹配。搜尋會排除軌道標頭，並在輸出中保留時間設定。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **從投影片擷取影片**

除了向投影片加入影片外，Aspose.Slides 也允許擷取嵌入簡報中的影片。

此範例將每張投影片的嵌入影片擷取為獨立且編號的二進位檔案。連結影片會被略過，因為它們沒有嵌入資料。主控台會列印每支影片的 MIME 類型以及總計數量。輸出使用通用的 `.bin` 副檔名；如有需要可依回報的媒體類型更改副檔名。

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

## **常見問題**

**可以變更影片框架的哪些播放參數？**

您可以透過 [playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-)（自動或點擊）以及 [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 來控制。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) 物件的方法取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會的。當您嵌入本機影片時，二進位資料會寫入文件，簡報大小會隨檔案大小成比例增長。當您連結線上影片並加入縮圖時，簡報僅儲存連結與預覽影像，而非影片資料，因而大小增幅通常較小。

**我可以在不更改位置與大小的情況下取代現有影片框架中的影片嗎？**

可以。您可以在框架內交換 [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) 同時保留形狀的幾何尺寸；這是更新既有版面中媒體的常見情況。

**能否判斷嵌入影片的內容類型 (MIME)？**

可以。嵌入的影片具有 [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--)，您可以讀取並使用，例如儲存至磁碟時。