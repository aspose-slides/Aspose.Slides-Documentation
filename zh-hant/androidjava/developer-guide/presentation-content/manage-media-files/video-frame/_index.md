---
title: 在 Android 上管理簡報中的影片框架
linktitle: 影片框架
type: docs
weight: 10
url: /zh-hant/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 於 Java 以程式方式在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框架。快速操作指南。"
---
## **簡介**

在簡報中恰當地放置影片可以讓您的訊息更具說服力，並提升觀眾的參與度。

PowerPoint 允許您以兩種方式將影片加入簡報的投影片中：

* 新增或嵌入本機影片（儲存在您的電腦上）
* 新增線上影片（來自如 YouTube 等網路來源）

為了讓您能在簡報中加入影片（video 物件），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideoframe/) 介面，以及其他相關類型。

## **建立嵌入式影片框架**

如果您要加入投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
1. 透過索引取得投影片的參照。 
1. 新增一個 [IVideo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideo/) 物件，並傳入影片檔案路徑，以將影片嵌入簡報。 
1. 新增一個 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideoframe/) 物件，以為影片建立框架。 
1. 儲存修改後的簡報。 

以下 Java 程式碼示範如何將本機儲存的影片加入簡報：

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("pres.pptx");
try {
    // 載入影片
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // 取得第一張投影片並新增影片框架
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // 將簡報儲存至磁碟
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

或者，您也可以直接將檔案路徑傳給 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) 方法以新增影片：

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **使用來自網路來源的影片建立影片框架**

Microsoft [PowerPoint 2013 及更新版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支援在簡報中使用 YouTube 影片。如果您想使用的影片可於網路上取得（例如 YouTube），您可以透過其網路連結將其加入簡報。

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例
1. 透過索引取得投影片的參照。 
1. 新增一個 [IVideo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideo/) 物件，並傳入影片連結。 
1. 為影片框架設定縮圖。 
1. 儲存簡報。 

以下 Java 程式碼示範如何將網路上的影片加入 PowerPoint 投影片：

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

## **管理影片字幕**

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框架的隱藏式字幕。字幕以 WebVTT 格式儲存，並可透過 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 方法取得。

**將字幕新增至影片框架**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 將影片新增至簡報。
1. 新增一個 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideoframe/) 物件至投影片。
1. 使用由 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 取得的 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icaptionscollection/) 以新增 WebVTT 字幕軌道。
1. 儲存修改後的簡報。

以下程式碼示範如何將字幕新增至影片框架：

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // 從 WebVTT 檔案新增一個字幕軌道。
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icaptionscollection/) 介面亦提供可從串流新增字幕的覆載方法。

**從影片框架擷取字幕**

1. 載入包含影片的簡報。
1. 找到目標 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideoframe/) 物件。
1. 迭代由 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 取得的字幕軌道。
1. 將每個字幕軌道儲存為 `.vtt` 檔案。

以下程式碼示範如何從影片框架擷取字幕：

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // 將字幕軌道儲存為 WebVTT 檔案。
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

每個 [ICaptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icaptions/) 物件會公開字幕識別碼、標籤、二進位資料，以及作為 UTF-8 字串的字幕內容。

**從影片框架移除字幕**

1. 載入包含影片的簡報。
1. 取得目標 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideoframe/) 物件。
1. 從由 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 取得的集合中移除字幕軌道。
1. 儲存修改後的簡報。

以下程式碼示範如何移除影片框架中的所有字幕：

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // 從影片框架中移除所有字幕。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需要移除單一字幕軌道，請使用 [remove](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) 方法，而非 [clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icaptionscollection/#clear--)。

## **從投影片擷取影片**

除了將影片加入投影片外，Aspose.Slides 也允許您擷取嵌入於簡報中的影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例以載入包含影片的簡報。
2. 迭代所有的 [ISlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/) 物件。
3. 迭代所有的 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 物件以找出 [VideoFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/videoframe/)。
4. 將影片儲存至磁碟。

以下 Java 程式碼示範如何從簡報投影片中擷取影片：

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

您可以透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/videoframe/) 物件的屬性控制 [播放模式](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)（自動或點擊）以及 [迴圈播放](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)。

**加入影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會寫入文件，簡報大小會隨檔案大小成比例增長。加入線上影片時，只會嵌入連結與縮圖，大小增幅較小。

**我能在不變更位置與大小的情況下替換現有 VideoFrame 中的影片嗎？**

可以。您可以在保持形狀幾何的前提下，使用 [setEmbeddedVideo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) 交換框架內的影片內容，這是更新現有版面媒體的常見情境。

**能否判斷嵌入式影片的內容類型 (MIME)？**

可以。嵌入式影片具有可讀取的 [content type](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/video/#getContentType--)，您可以在將其儲存至磁碟時使用此資訊。