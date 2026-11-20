---
title: 在 Android 上管理簡報中的影片框格
linktitle: 影片框格
type: docs
weight: 10
url: /zh-hant/androidjava/video-frame/
keywords:
- 加入影片
- 建立影片
- 嵌入影片
- 擷取影片
- 取得影片
- 影片框格
- 網路來源
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Android via Java，以程式方式在 PowerPoint 與 OpenDocument 投影片中加入與擷取影片框格。快速教學指南。"
---
## **簡介**

影片可以協助說明概念並吸引觀眾。Aspose.Slides for Android via Java 允許您向投影片新增影片框格、調整播放設定、管理字幕，並擷取嵌入的影片資料。

PowerPoint 支援本機影片和指向線上影片的連結，例如 YouTube 影片。

為了表示影片資料與影片框格，Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) 介面，以及其他相關型別。

## **建立嵌入式影片框格**

如果您要加入投影片的影片檔案儲存在本機，您可以建立影片框格將影片嵌入到簡報中。

此範例將本機影片嵌入現有簡報的第一張投影片，並儲存結果。框格的座標與尺寸以點為單位。由於 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) 在簡報使用期間保持鎖定，資料流會保持開啟直至儲存完成。

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

您也可以直接將本機影片路徑傳遞給 [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-)。此範例將影片嵌入新簡報的第一張投影片。影片必須在簡報儲存之前保持可存取。

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

## **使用來自網路來源的影片建立影片框格**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 在簡報中支援線上影片。您可以建立一個連結至線上影片（例如 YouTube 影片）的影片框格。

此範例將 YouTube 影片連結與縮圖加入第一張投影片。請替換影片識別碼以使用其他影片。[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) 方法請求自動播放。下載縮圖與播放影片皆需要網路存取。簡報檢視器也必須支援線上影片播放。

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

## **全螢幕播放影片**

在培訓簡報中，您可以以全螢幕模式播放軟體示範，讓觀眾看到細節。呼叫 [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) 並傳入 `true` 可在播放期間啟用此行為。

此範例開啟簡報，於第一張投影片找到第一個 [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/)，並啟用全螢幕播放。輸入簡報必須至少包含一張投影片，其第一張投影片上已有影片框格。

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

全螢幕播放會控制影片的顯示方式。與此獨立的是，[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) 決定影片是自動開始還是點擊開始，且 [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 決定是否重複播放。若要選擇開始行為，請將播放模式設定為 [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/)。此範例保留了既有的開始與循環設定。

## **播放後倒帶影片**

在培訓簡報中，將示範影片倒回起點可讓簡報者再次播放。呼叫 [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) 並傳入 `true`，即可在播放結束後將影片返回起點。

此範例開啟簡報，於第一張投影片找到第一個 [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/)，並啟用倒帶。它會停用循環以讓播放結束，並設定播放在點擊時開始。輸入簡報必須至少包含一張投影片，其第一張投影片已有影片框格。

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

倒帶會將影片返回起點而不重新開始。相反地，將 [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 設為 `true` 會自動重複播放。當您希望影片播放結束且保持可重播狀態時，請保持循環停用。[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) 讓簡報者決定何時開始播放。正如範例所示，請在設定循環後再設定播放模式。倒帶與 [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) 的設定互不相干。

## **剪裁影片框格**

使用 [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) 與 [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) 可在播放時略過影片的開頭或結尾部分。兩個值的單位皆為毫秒。剪裁會變更播放設定，但不會修改嵌入的影片資料。

**設定剪裁參數**

此範例將本機影片嵌入，並在播放時略過前 2.5 秒與最後 1 秒。請使用長度超過 3.5 秒的影片，以確保仍有可播放的片段。

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

**讀取剪裁參數**

此範例以毫秒為單位印出第一張投影片上第一個影片框格的剪裁值。簡報必須至少包含一張投影片；若該投影片沒有影片框格，則不會印出任何內容。前述範例會產生 2500 與 1000 的值。

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

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框格的隱藏字幕。字幕以 WebVTT 格式儲存，並透過 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 方法取得。

### **為影片框格新增字幕**

此範例將本機影片嵌入，並加入標示為 English 的 WebVTT 字幕軌。字幕的時間戳記應與影片相符。儲存的簡報同時包含影片與其字幕。

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

[ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) 介面亦提供一個重載，可讓您從資料流新增字幕。

### **從影片框格擷取字幕**

此範例將第一張投影片上所有影片框格的字幕軌保存為個別的 WebVTT 檔案。依序編號可使輸出檔案保持唯一。主控台會報告擷取的軌道數量。簡報必須至少包含一張投影片。

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

每個 [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) 物件皆會公開字幕識別碼、標籤、二進位資料，以及作為 UTF-8 字串的字幕文字。

### **從影片框格移除字幕**

此範例從第一張投影片第一個圖形位置的影片框格移除所有字幕，並儲存結果。它假設投影片與圖形皆存在，且該圖形為影片框格。

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

若您只需要移除單一字幕軌，請使用 [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) 方法，而非 [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--)。

### **搜尋影片字幕**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) 會回傳完整的 WebVTT 軌道，包括其標頭、時間線與字幕文字。您可以在記憶體中搜尋提示，以找到特定口語片段及其時間戳記。例如，投影片 2 上的英語軌道可能包含以下文字。

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

此範例開啟 `captioned_media.pptx`，並使用 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 讀取每張投影片上所有頂層影片框格的軌道。純文字提示的時間線包含 `-->`，且空白行會結束提示。當字幕中以任何大小寫形式出現「café」時，範例會印出投影片編號、軌道標籤、原始時間線與完整字幕。

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

搜尋「café」會在範例軌道中產生一次匹配。搜尋會排除軌道標頭，並在輸出中保留時間設定。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **從投影片擷取影片**

除了向投影片加入影片外，Aspose.Slides 也允許您擷取簡報中嵌入的影片。

此範例將每張投影片中的嵌入影片抽出為單獨的、編號的二進位檔案。因連結影片沒有嵌入資料，會被略過。主控台會印出每支影片的 MIME 類型與總數量。輸出使用通用的 `.bin` 副檔名；必要時可依回報的媒體類型更改副檔名。

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

## **常見問題**

**可以為影片框格變更哪些影片播放參數？**

您可以透過 [playback mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)（自動或點擊）與 [looping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 來控制。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) 物件的方法取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會被寫入文件，簡報大小會隨影片檔案大小等比例增長。若您連結到線上影片並加入縮圖，簡報只會儲存連結與預覽圖像，而非影片資料，因而大小的增加通常較小。

**我可以在不改變影片框格位置與尺寸的情況下，替換現有影片框格中的影片嗎？**

可以。您可以在框格內交換 [video content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-)，同時保留圖形的幾何形狀；這是更新既有版面媒體的常見情境。

**可以判斷嵌入影片的內容類型（MIME）嗎？**

可以。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--)，您可以使用它，例如在儲存至磁碟時。