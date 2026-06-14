---
title: 使用 JavaScript 在簡報中管理影片框架
linktitle: 影片框架
type: docs
weight: 10
url: /zh-hant/nodejs-java/video-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Node.js（透過 Java）在 PowerPoint 和 OpenDocument 投影片中以程式方式新增與擷取影片框架。快速操作指南。"
---
## **簡介**

在簡報中恰當放置的影片可以使您的訊息更具說服力，並提升觀眾的參與度。

PowerPoint 允許您以兩種方式將影片新增至簡報的投影片中：

* 新增或嵌入本機影片（儲存於您的電腦）
* 新增線上影片（來自諸如 YouTube 等網路來源）。

為了讓您在簡報中加入影片（video 物件），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 類別以及其他相關型別。

## **建立嵌入式影片框架**

如果您要新增至投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation)類別的實例。
1. 透過索引取得投影片的參考。
1. 新增一個 [Video](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/video/) 物件，並傳入影片檔案路徑以將影片嵌入簡報。
1. 新增一個 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 物件，以建立影片的框架。
1. 保存已修改的簡報。

以下 JavaScript 程式碼示範如何將本機儲存的影片新增至簡報：

```javascript
// 實例化 Presentation 類別
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // 載入影片
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // 取得第一張投影片並新增影片框架
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // 將簡報儲存至磁碟
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

或者，您也可以直接將檔案路徑傳遞給 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) 方法以新增影片：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **使用 Web 來源的影片建立影片框架**

Microsoft [PowerPoint 2013 及以後版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)支援在簡報中使用 YouTube 影片。如果您想使用的影片可在線上取得（例如 YouTube），您可以透過其網路連結將其新增至簡報。

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation)類別的實例
1. 透過索引取得投影片的參考。
1. 新增一個 [Video](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/video/) 物件，並傳入影片的連結。
1. 為影片框架設定縮圖。
1. 保存簡報。

以下 JavaScript 程式碼示範如何將線上影片新增至 PowerPoint 簡報的投影片中：

```javascript
// 實例化一個代表簡報檔案的 Presentation 物件
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **管理影片字幕**

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框架的隱藏式字幕。字幕以 WebVTT 格式儲存，並可透過 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) 方法取得。

**新增字幕至影片框架**

若要為影片框架新增字幕：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)類別的實例。
1. 將影片新增至簡報。
1. 在投影片中新增一個 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 物件。
1. 使用 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/) 集合來新增 WebVTT 字幕軌。
1. 保存已修改的簡報。

以下程式碼示範如何為影片框架新增字幕：

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // 從 WebVTT 檔案新增字幕軌道。
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/) 類別也提供了 [addFromStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/#addFromStream) 方法，可讓您從串流加入字幕。

**從影片框架擷取字幕**

若要從影片框架擷取字幕：

1. 載入包含該影片的簡報。
1. 找出目標 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 物件。
1. 遍歷 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/) 集合。
1. 將每條字幕軌保存為 `.vtt` 檔案。

以下程式碼示範如何從影片框架擷取字幕：

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // 將字幕軌道保存為 WebVTT 檔案。
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

每個 [Captions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captions/) 物件都會公開字幕的識別碼、標籤、二進位資料，以及以 UTF-8 字串形式的字幕文字。

**從影片框架移除字幕**

若要從影片框架移除字幕：

1. 載入包含該影片的簡報。
1. 取得目標 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 物件。
1. 從 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/) 集合中移除字幕軌。
1. 保存已修改的簡報。

以下程式碼示範如何從影片框架移除全部字幕：

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // 類型: com.aspose.slides.VideoFrame

    // 從影片框架移除所有字幕。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需移除單一字幕軌，請使用 [remove](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/#removeAt) 方法，而非 [clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/#clear)。

## **從投影片提取影片**

除了將影片新增至投影片之外，Aspose.Slides 也允許您提取嵌入於簡報中的影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation)類別的實例，以載入包含影片的簡報。
2. 遍歷所有 [Slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/)物件。
3. 遍歷所有 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/)物件以尋找 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/)。
4. 將影片保存至磁碟。

以下 JavaScript 程式碼示範如何從簡報投影片中提取影片：

```javascript
// 實例化一個代表簡報檔案的 Presentation 物件
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // 取得檔案副檔名
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**可以變更 VideoFrame 的哪些影片播放參數？**

您可以控制 [playback mode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/setplaymode/)（自動或點擊播放）與 [looping](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/setplayloopmode/)（循環播放）。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 物件的屬性取得。

**新增影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會包含在文件中，導致簡報大小隨檔案大小成比例增長。當您新增線上影片時，僅嵌入連結與縮圖，大小的增加較小。

**我可以在不更改位置與大小的情況下取代既有 VideoFrame 的影片嗎？**

可以。您可以在保留形狀尺寸與位置的情況下，交換框架內的 [video content](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/setembeddedvideo/)；這是更新既有版面媒體的常見情況。

**可以判斷嵌入式影片的內容類型 (MIME) 嗎？**

可以。嵌入式影片具有可讀取的 [content type](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/video/getcontenttype/)，例如在保存至磁碟時可加以使用。