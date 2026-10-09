---
title: 在 Android 上管理簡報中的影片框格
linktitle: 影片框格
type: docs
weight: 10
url: /zh-hant/androidjava/video-frame/
keywords:
- 新增影片
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
description: "學習使用 Aspose.Slides for Android via Java，在 PowerPoint 與 OpenDocument 投影片中以程式方式新增與擷取影片框格。快速使用指南。"
---
## **簡介**

影片可以協助說明概念並吸引觀眾。Aspose.Slides for Android via Java 讓您能將影片框格新增至投影片、調整播放設定、管理字幕，並擷取內嵌影片資料。

PowerPoint 支援本機影片以及指向線上影片（例如 YouTube 影片）的連結。

為了表示影片資料與影片框格，Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) 介面，以及其他相關型別。

## **建立內嵌影片框格**

如果要新增至投影片的影片檔案儲存在本機，您可以建立影片框格將影片內嵌於簡報中。

此範例會將本機影片嵌入現有簡報的第一張投影片，並儲存結果。框格座標與尺寸的單位為點。因為 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) 在簡報使用期間會鎖定串流，所以串流會保持開啟直到儲存完成。

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

您也可以直接將本機影片路徑傳遞給 [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-)。此範例會將影片嵌入新簡報的第一張投影片。影片必須在簡報儲存前保持可存取。

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

## **建立來自網路來源的影片框格**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支援簡報中的線上影片。您可以建立指向線上影片（例如 YouTube 影片）的影片框格。

此範例會在第一張投影片加入 YouTube 影片連結與縮圖。請更換影片識別碼以使用其他影片。[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) 方法會要求自動播放。下載縮圖與播放影片需要網際網路連線，簡報檢視器也必須支援線上影片播放。

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

在培訓簡報中，您可以全螢幕播放軟體示範，讓觀眾清楚看到細節。將 `true` 傳入 [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) 即可在播放期間啟用此行為。

此範例開啟簡報，尋找第一張投影片上的第一個 [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/)，並啟用全螢幕播放。輸入簡報必須至少包含一張投影片，且第一張投影片上已有影片框格。

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

全螢幕播放會決定影片的顯示方式。除此之外，[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) 會控制是否自動或點擊開始播放，而 [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 會控制是否重複播放。若要選擇開始行為，請將播放模式設定為 [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/)。此範例會保留既有的開始與迴圈設定。

## **播放後倒帶影片**

在培訓簡報中，將示範影片倒回起點可讓主持人再次播放。將 `true` 傳入 [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) 即可在播放結束後把影片倒回起點。

此範例開啟簡報，尋找第一張投影片上的第一個 [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/)，並啟用倒帶。它會停用迴圈，使播放可以結束，並將播放設定為點擊開始。輸入簡報必須至少包含一張投影片，且第一張投影片上已有影片框格。

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

倒帶會將影片返回起點而不會重新開始播放。相較之下，將 `true` 傳入 [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 會自動重複播放。當您希望影片結束後保持可重播狀態時，請停用迴圈。[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) 仍可獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) 讓主持人自行決定何時開始播放。請在設定迴圈之後再設定播放模式，如範例所示。倒帶與 [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) 無關。

## **剪輯影片框格**

使用 [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) 與 [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) 可在播放時跳過影片開頭或結尾的部分。兩個參數的單位為毫秒。剪輯會變更播放設定，但不會修改內嵌影片資料。

**設定剪輯參數**

此範例會嵌入本機影片，並在播放時跳過前 2.5 秒與最後 1 秒。請使用長度超過 3.5 秒的影片，以確保仍有可播放的片段。

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

**讀取剪輯參數**

此範例會以毫秒為單位列印第一張投影片上第一個影片框格的剪輯值。簡報必須至少包含一張投影片。若該投影片沒有影片框格，則不會輸出任何內容。前述範例會產生 2500 與 1000 兩個值。

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

Aspose.Slides 允許您在 PowerPoint 簡報的影片框格中管理隱藏字幕。字幕以 WebVTT 格式儲存，並可透過 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 方法取得。

**為影片框格新增字幕**

此範例會嵌入本機影片，並加入標示為 English 的 WebVTT 字幕軌。字幕時間戳必須與影片相符。儲存的簡報會同時包含影片與其字幕。

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

[ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) 介面也提供可從串流新增字幕的多載。

**從影片框格擷取字幕**

此範例會將第一張投影片上所有影片框格的字幕軌儲存為個別的 WebVTT 檔案。使用遞增編號以保持檔案名稱唯一。主控台會報告擷取到的軌道數量。簡報必須至少包含一張投影片。

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

每個 [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) 物件會公開字幕識別碼、標籤、二進位資料，以及 UTF-8 字串形式的字幕文字。

**從影片框格移除字幕**

此範例會移除第一張投影片上第一個形狀位置的影片框格中的所有字幕，並儲存結果。它假設該投影片與形狀均已存在且形狀為影片框格。

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

如果只需要移除單一字幕軌，請改用 [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) 方法，而非 [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--)。

## **從投影片擷取影片**

除了將影片加入投影片外，Aspose.Slides 也允許您從簡報中擷取內嵌影片。

此範例會將每張投影片的內嵌影片擷取為獨立、編號的二進位檔案。連結影片會被略過，因為它們沒有內嵌資料。主控台會列印每個影片的 MIME 類型與總計數量。輸出使用通用的 `.bin` 副檔名；如有需要，請依報告的媒體類型更改副檔名。

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

**可以變更影片框格的哪些播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) 物件的方法控制 [playback mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)（自動或點擊）以及 [looping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)。這些選項皆可使用相關方法設定。

**新增影片會影響 PPTX 檔案大小嗎？**

會。當您內嵌本機影片時，二進位資料會寫入文件，簡報大小會隨影片檔案大小成比例增加。若您連結線上影片並加入縮圖，簡報只會儲存連結與預覽圖像，而非影片本身，通常會減少大小增幅。

**是否能在不變更位置與尺寸的前提下，取代已有影片框格中的影片？**

可以。您可以在框格內部交換 [video content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-)，同時保留形狀的幾何屬性；這是更新既有版面媒體的常見情境。

**能否判斷內嵌影片的內容類型 (MIME)？**

能。內嵌影片具有可讀取的 [content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--)，您可以取得後在儲存至磁碟等情況下使用。