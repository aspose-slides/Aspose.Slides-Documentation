---
title: 使用 JavaScript 在簡報中管理影片框格
linktitle: 影片框格
type: docs
weight: 10
url: /zh-hant/nodejs-java/video-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "學習如何以程式方式使用 Aspose.Slides for Node.js（透過 Java）在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框格。快速上手指南。"
---
## **簡介**

在簡報中恰當地放置影片可以使您的訊息更具說服力，並提升觀眾的參與度。 

PowerPoint 允許您以兩種方式在簡報的投影片中加入影片：

* 新增或嵌入本機影片（儲存在您的電腦上）
* 新增線上影片（來自諸如 YouTube 等網站來源）。

為了讓您能在簡報中加入影片（video 物件），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 類別以及其他相關型別。

## **建立嵌入式影片框格**

如果您想加入投影片的影片檔案儲存在本機，您可以建立影片框格，將影片嵌入簡報中。 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入 [Video](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/video/) 物件，並傳入影片檔案路徑以將影片嵌入簡報。  
4. 加入 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 物件，以建立影片的框格。  
5. 儲存已修改的簡報。 

以下 JavaScript 程式碼示範如何將本機儲存的影片加入簡報：

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // 載入影片
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // 取得第一張投影片並新增影片框格
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // 將簡報保存至磁碟
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

或者，您也可以直接將檔案路徑傳入 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) 方法來新增影片：

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

## **使用網路來源影片建立影片框格**

Microsoft [PowerPoint 2013 及更新版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支援在簡報中使用 YouTube 影片。如果您要使用的影片可在網路上取得（例如 YouTube），您可以透過其網址將其加入簡報。 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入 [Video](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/video/) 物件，並傳入影片的連結。  
4. 為影片框格設定縮圖。  
5. 儲存簡報。 

以下 JavaScript 程式碼示範如何將網路影片加入 PowerPoint 簡報的投影片中：

```javascript
// 建立代表簡報檔案的 Presentation 物件
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

## **裁切影片框格**

Aspose.Slides 允許您透過 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/settrimfromstart/) 與 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/settrimfromend/) 設定 trim-from-start 與 trim-from-end 值，以控制影片的播放區段。兩個值以毫秒為單位，分別定義從影片開頭與結尾跳過的時間長度。這些設定會變更簡報中的影片播放行為；不會裁剪或以其他方式修改嵌入的影片二進位資料。

**設定裁切參數**

建立影片框格並設定其裁切參數：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。  
2. 在簡報中加入 [Video](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/video/) 物件。  
3. 在投影片中加入 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 物件。  
4. 透過 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/settrimfromstart/) 與 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/settrimfromend/) 設定 trim-from-start 與 trim-from-end 值。  
5. 儲存已修改的簡報。

以下程式碼範例在播放嵌入式影片時，跳過前 2.5 秒與最後 1 秒：

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**讀取裁切參數**

若要檢視現有的裁切參數，請載入簡報、於第一張投影片的圖形中找到 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 物件，並透過 [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) 與 [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/gettrimfromend/) 讀取其值。

以下程式碼範例尋找第一張投影片上的第一個影片框格，並以毫秒為單位回報其裁切參數：

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **管理影片字幕**

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框格的隱蔽字幕 (closed captions)。字幕以 WebVTT 格式儲存，並可透過 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) 方法取得。

**將字幕加入影片框格**

將字幕加入影片框格的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。  
2. 在簡報中加入影片。  
3. 加入 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 物件至投影片。  
4. 使用 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/) 集合加入 WebVTT 字幕軌道。  
5. 儲存已修改的簡報。

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // 從 WebVTT 檔案新增一個字幕軌道。
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/) 類別亦提供 [addFromStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/#addFromStream) 方法，讓您從串流加入字幕。

**從影片框格擷取字幕**

從影片框格擷取字幕的步驟：

1. 載入包含該影片的簡報。  
2. 找到目標 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 物件。  
3. 迭代 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/) 集合。  
4. 將每個字幕軌道儲存為 `.vtt` 檔案。

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
                // 將字幕軌道儲存為 WebVTT 檔案。
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

每個 [Captions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captions/) 物件都會公開字幕識別碼、標籤、二進位資料，以及以 UTF-8 字串表示的字幕文字。

**從影片框格移除字幕**

從影片框格移除字幕的步驟：

1. 載入包含該影片的簡報。  
2. 取得目標 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 物件。  
3. 從 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/) 集合移除字幕軌道。  
4. 儲存已修改的簡報。

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // 類型: com.aspose.slides.VideoFrame

    // 從影片框格中移除所有字幕。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需要移除單一字幕軌道，請使用 [remove](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/#removeAt) 方法，而非 [clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/#clear)。

## **從投影片擷取影片**

除了將影片加入投影片之外，Aspose.Slides 也允許您擷取嵌入於簡報中的影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例，以載入包含影片的簡報。  
2. 迭代所有 [Slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/) 物件。  
3. 迭代所有 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 物件以找到 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/)。  
4. 將影片儲存至磁碟。

以下 JavaScript 程式碼示範如何從簡報投影片上擷取影片：

```javascript
// 建立代表簡報檔案的 Presentation 物件
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

**可以變更 VideoFrame 哪些影片播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 物件的屬性控制[播放模式](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/setplaymode/)（自動或點擊）以及[循環播放](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/setplayloopmode/)。

**加入影片會影響 PPTX 檔案大小嗎？**

會的。當您嵌入本機影片時，二進位資料會寫入文件中，因此簡報大小會隨檔案大小等比例增加。加入線上影片時，僅嵌入連結與縮圖，大小增幅較小。

**我可以在不變更位置與尺寸的情況下，取代現有 VideoFrame 中的影片嗎？**

可以。您可以在保留形狀幾何的前提下，替換框格內的[影片內容](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/setembeddedvideo/)，這是更新既有版面媒體的常見情境。

**可以判斷嵌入影片的內容類型（MIME）嗎？**

可以。嵌入的影片具有可讀取的[內容類型](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/video/getcontenttype/)，您可將其用於例如儲存至磁碟等情況。