---
title: 使用 Java 管理簡報中的影片框格
linktitle: 影片框格
type: docs
weight: 10
url: /zh-hant/java/video-frame/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 程式化地在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框格。快速入門指南。"
---
## **簡介**

在簡報中恰當放置影片可以讓您的訊息更具說服力，並提升觀眾的參與度。

PowerPoint 提供兩種方式在投影片中加入影片：

* 新增或嵌入本機影片（儲存在您的電腦上）
* 新增線上影片（來自 YouTube 等網路來源）

為了讓您能在簡報中加入影片（影片物件），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/) 介面以及其他相關型別。

## **建立嵌入式影片框格**

如果您要加入的影片檔案儲存在本機，可建立影片框格將影片嵌入簡報。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片參考。  
3. 新增 [IVideo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideo/) 物件，並傳入影片檔案路徑以將影片嵌入簡報。  
4. 新增 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/) 物件以建立影片框格。  
5. 儲存已修改的簡報。

以下 Java 程式碼示範如何將本機影片加入簡報：

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("pres.pptx");
try {
    // 載入影片
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // 取得第一張投影片並新增影片框格
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // 將簡報儲存至磁碟
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

或者，您也可以直接將檔案路徑傳給 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) 方法：

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **使用網路來源影片建立影片框格**

Microsoft [PowerPoint 2013 及更新版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支援在簡報中使用 YouTube 影片。如果您要使用的影片在網路上可取得（例如 YouTube），即可透過其網址將影片加入簡報。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片參考。  
3. 新增 [IVideo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideo/) 物件，並傳入影片連結。  
4. 為影片框格設定縮圖。  
5. 儲存簡報。

以下 Java 程式碼示範如何從網路將影片加入 PowerPoint 投影片：

```java
// 實例化一個代表簡報檔的 Presentation 物件 
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
    // 新增影片框格
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

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框格的隱藏式字幕。字幕以 WebVTT 格式儲存，並可透過 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) 方法取得。

**為影片框格新增字幕**

將字幕新增至影片框格的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。  
2. 在簡報中加入影片。  
3. 在投影片上新增 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/) 物件。  
4. 使用由 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) 回傳的 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/) 來新增 WebVTT 字幕軌。  
5. 儲存已修改的簡報。

以下程式碼示範如何為影片框格新增字幕：

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // 新增一條來自 WebVTT 檔案的字幕軌道。
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/) 介面也提供一個覆寫，可讓您從串流加入字幕。

**從影片框格擷取字幕**

擷取影片框格字幕的步驟：

1. 載入包含影片的簡報。  
2. 找到目標的 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/) 物件。  
3. 迭代 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/) 中的字幕軌。  
4. 將每條字幕軌存成 `.vtt` 檔案。

以下程式碼示範如何從影片框格擷取字幕：

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

每個 [ICaptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptions/) 物件會公開字幕識別碼、標籤、二進位資料，以及 UTF-8 字串形式的字幕文字。

**從影片框格移除字幕**

移除影片框格字幕的步驟：

1. 載入包含影片的簡報。  
2. 取得目標的 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivideoframe/) 物件。  
3. 從 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/) 中移除字幕軌。  
4. 儲存已修改的簡報。

以下程式碼示範如何一次移除影片框格的所有字幕：

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // 移除影片框格中的所有字幕。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若只需移除單一字幕軌，可使用 [remove](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/#removeAt-int-) 方法，而非 [clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/#clear--)。

## **從投影片中擷取影片**

除新增影片外，Aspose.Slides 亦支援從簡報中擷取嵌入的影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例，以載入包含影片的簡報。  
2. 迭代所有 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/) 物件。  
3. 於每張投影片中迭代所有 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 物件，尋找 [VideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/videoframe/)。  
4. 將影片存至磁碟。

以下 Java 程式碼示範如何從簡報投影片擷取影片：

```java
// 實例化一個代表簡報檔的 Presentation 物件 
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

## **常見問題集**

**可以變更 VideoFrame 的哪些播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/videoframe/) 物件的屬性控制 [播放模式](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/videoframe/#setPlayMode-int-)（自動或點擊）以及 [循環播放](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)。

**加入影片會影響 PPTX 檔案大小嗎？**

會。若嵌入本機影片，影片的二進位資料會寫入文件，簡報大小會隨檔案大小成比例增長。若加入線上影片，僅嵌入連結與縮圖，大小增幅較小。

**能否在不改變位置和尺寸的前提下，替換既有 VideoFrame 中的影片？**

可以。您可以在保持形狀幾何的前提下，以 [setEmbeddedVideo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) 交換框格內的影片內容，這在更新既有版面配置的媒體時相當常見。

**能否判斷嵌入影片的內容類型 (MIME)？**

可以。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/video/#getContentType--)，您可在儲存至磁碟或其他用途時使用它。