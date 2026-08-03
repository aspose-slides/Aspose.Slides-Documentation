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
description: "學會使用 Aspose.Slides for Java 在 PowerPoint 與 OpenDocument 投影片中以程式方式新增與擷取影片框架。快速操作指南。"
---
## **簡介**

在簡報中恰當放置的影片可以使您的訊息更具說服力，並提升觀眾的參與度。

PowerPoint 允許您以兩種方式將影片加入簡報投影片中：

* 新增或嵌入本機影片（儲存在您的電腦上）
* 新增線上影片（來自例如 YouTube 等網站來源）。

為了讓您能在簡報中加入影片（video 物件），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/) 介面以及其他相關類型。

## **建立嵌入式影片框架**

如果您想加入投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的執行個體。
1. 透過索引取得投影片的參考。
1. 加入一個 [IVideo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideo/) 物件，並傳遞影片檔案路徑以將影片嵌入簡報。
1. 加入一個 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/) 物件，以為影片建立框架。  
1. 儲存已修改的簡報。

以下 Java 程式碼示範如何將本機儲存的影片加入簡報：

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation("pres.pptx");
try {
    // 載入影片
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // 取得第一張投影片並加入影片框架
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // 將簡報儲存至磁碟
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

或者，您也可以直接將檔案路徑傳遞給 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) 方法：

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **建立來自網路來源的影片框架**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支援在簡報中使用 YouTube 影片。如果您要使用的影片可於線上取得（例如 YouTube），可透過其網路連結將其加入簡報。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的執行個體
1. 透過索引取得投影片的參考。
1. 加入一個 [IVideo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideo/) 物件，並傳遞影片的連結。
1. 為影片框架設定縮圖。
1. 儲存簡報。

以下 Java 程式碼示範如何將線上影片加入 PowerPoint 投影片：

```java
// 實例化一個代表簡報檔案的 Presentation 物件
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
    // 新增影片框架
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // 載入縮圖
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

## **剪裁影片框架**

Aspose.Slides 允許您透過 [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) 與 [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) 設定剪裁起始與結束值，以控制播放哪一段影片。這兩個值以毫秒為單位，分別定義從影片開頭與結尾跳過的時間長度。此設定會變更簡報中的影片播放行為；不會切割或修改嵌入的影片二進位資料。

**設定剪裁參數**

建立影片框架並設定剪裁參數的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的執行個體。
1. 加入一個 [IVideo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideo/) 物件至簡報。
1. 加入一個 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/) 物件至投影片。
1. 透過 [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) 與 [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) 設定剪裁起始與結束值。
1. 儲存已修改的簡報。

以下程式碼示範在播放期間跳過前 2.5 秒與最後 1 秒的嵌入影片：

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

**讀取剪裁參數**

若要檢查現有的剪裁設定，請載入簡報、在第一張投影片的圖形中找到 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/) 物件，並透過 [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) 與 [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--) 讀取值。

以下程式碼示範在第一張投影片上找到第一個影片框架並以毫秒回報其剪裁設定：

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

## **管理影片字幕**

Aspose.Slides 允許您在 PowerPoint 簡報的影片框架中管理隱藏式字幕。字幕以 WebVTT 格式儲存，並可透過 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) 方法取得。

**將字幕加入影片框架**

將字幕加入影片框架的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的執行個體。
1. 將影片加入簡報。
1. 加入一個 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/) 物件至投影片。
1. 使用由 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) 回傳的 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/) 新增 WebVTT 字幕軌道。
1. 儲存已修改的簡報。

以下程式碼示範如何將字幕加入影片框架：

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // 從 WebVTT 檔案新增字幕軌道。
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/) 介面亦提供允許從串流新增字幕的重載方法。

**從影片框架擷取字幕**

從影片框架擷取字幕的步驟：

1. 載入包含影片的簡報。
1. 找到目標的 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/) 物件。
1. 迭代 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/) 中的字幕軌道。
1. 將每個字幕軌道儲存為 `.vtt` 檔案。

以下程式碼示範如何從影片框架擷取字幕：

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // 將字幕軌道儲存為 WebVTT 檔案。
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

每個 [ICaptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptions/) 物件會公開字幕識別碼、標籤、二進位資料以及以 UTF-8 字串呈現的字幕文字。

**從影片框架移除字幕**

移除影片框架字幕的步驟：

1. 載入包含影片的簡報。
1. 取得目標的 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/) 物件。
1. 從 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/) 中移除字幕軌道。
1. 儲存已修改的簡報。

以下程式碼示範如何移除影片框架中的所有字幕：

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // 從影片框架中移除所有字幕。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需要移除單一字幕軌道，請改用 [remove](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/#removeAt-int-) 方法，而非 [clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/#clear--)。

## **從投影片中擷取影片**

除了將影片加入投影片之外，Aspose.Slides 也允許您擷取簡報中嵌入的影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的執行個體以載入含有影片的簡報。 
2. 迭代所有 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/) 物件。
3. 迭代所有 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 物件以尋找 [VideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/videoframe/)。 
4. 將影片儲存至磁碟。

以下 Java 程式碼示範如何擷取簡報投影片上的影片：

```java
// 實例化一個代表簡報檔案的 Presentation 物件 
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

                // 取得檔案副檔名
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

## **FAQ**

**可以變更 VideoFrame 的哪些影片播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/videoframe/) 物件的屬性控制 [playback mode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/videoframe/#setPlayMode-int-)（自動或點擊）以及 [looping](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)。這些選項皆可於 VideoFrame 物件取得。

**新增影片會影響 PPTX 檔案大小嗎？**

會的。當您嵌入本機影片時，二進位資料會被納入文件中，簡報大小會與檔案大小成正比增長。當您加入線上影片時，僅嵌入連結與縮圖，檔案大小的增加較小。

**我可以在不變更位置和尺寸的情況下替換現有 VideoFrame 中的影片嗎？**

可以。您可以在保留圖形幾何形狀的前提下，使用 [setEmbeddedVideo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) 交換框架內的影片內容；這在更新已有佈局的媒體時相當常見。

**可以判斷嵌入影片的內容類型（MIME）嗎？**

可以。嵌入的影片具有可透過 [getContentType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/video/#getContentType--) 讀取的內容類型，您可將其用於例如儲存至磁碟等情境。