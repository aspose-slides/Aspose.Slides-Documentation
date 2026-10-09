---
title: 使用 Node.js 管理簡報中的影片框架
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
description: "了解如何使用 Aspose.Slides for Node.js via Java，程式化地在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框架。快速上手指南。"
---
## **簡介**

影片可以協助說明概念並吸引觀眾。Aspose.Slides for Node.js via Java 讓您能在投影片中加入影片框架、調整播放設定、管理字幕，並擷取嵌入的影片資料。

PowerPoint 支援本機影片以及連結至線上影片（例如 YouTube 影片）。

為了表示影片資料與影片框架，Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) 類別以及其他相關型別。

## **建立嵌入式影片框架**

如果要加入至投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

此範例將本機影片嵌入現有簡報的第一張投影片，並儲存結果。框架的座標與尺寸以點為單位。因為 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) 在簡報使用時保持鎖定，資料流會在儲存完成前保持開啟。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

您也可以直接將本機影片路徑傳遞給 [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/)。此範例將影片嵌入新簡報的第一張投影片。影片必須在簡報儲存之前保持可存取。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **建立來自網路來源的影片框架**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支援在簡報中使用線上影片。您可以建立連結至線上影片（例如 YouTube 影片）的影片框架。

此範例在第一張投影片加入 YouTube 影片連結與縮圖。將影片識別碼替換為其他影片即可使用。[setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) 方法請求自動播放。下載縮圖與播放影片均需網際網路連線。簡報檢視器亦必須支援線上影片播放。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **全螢幕模式播放影片**

在培訓簡報中，您可以全螢幕播放軟體示範，讓觀眾看到細節。將 `true` 傳入 [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) 即可在播放期間啟用此行為。

此範例開啟簡報，於第一張投影片找到第一個 [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)，並啟用全螢幕播放。輸入的簡報必須至少在第一張投影片上含有一個現有的影片框架。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

全螢幕播放控制影片的顯示方式。除此之外，[setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) 控制是否自動或點擊開始播放，且 [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) 控制是否重複播放。若要選擇開始行為，將播放模式設為 [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/)。此範例保留了既有的開始與迴圈設定。

## **播放後倒帶影片**

在培訓簡報中，將示範影片倒回開頭可讓簡報者再次播放。將 `true` 傳入 [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) 即可在播放結束後將影片倒回開頭。

此範例開啟簡報，於第一張投影片找到第一個 [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)，並啟用倒帶。它會停用迴圈，使播放能結束，並設定點擊開始播放。輸入的簡報必須至少在第一張投影片上含有一個現有的影片框架。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

倒帶會把影片返回開頭而不會再次自動開始。相較之下，將 [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) 設為 `true` 會自動重複播放。若希望影片播放完畢後保持可重新播放的狀態，請停用迴圈。[setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) 讓簡報者自行決定何時開始播放。請先設定迴圈，再設定播放模式，如範例所示。倒帶與 [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) 的設定互不影響。

## **裁剪影片框架**

使用 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) 與 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) 可在播放時跳過影片開頭或結尾的部分。兩個值皆以毫秒為單位。裁剪僅會變更播放設定，不會改變嵌入的影片資料。

**設定裁剪參數**

此範例嵌入本機影片，於播放時跳過前 2.5 秒與最後 1 秒。請使用長度超過 3.5 秒的影片，以確保仍留下可播放的片段。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**讀取裁剪參數**

此範例列印第一張投影片上第一個影片框架的裁剪值（毫秒）。簡報必須至少包含一張投影片；若該投影片沒有影片框架，則不會列印任何內容。前一個範例的輸出值為 2500 與 1000。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **管理影片字幕**

Aspose.Slides 允許您在 PowerPoint 簡報的影片框架中管理關閉式字幕。字幕以 WebVTT 格式儲存，並可透過 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) 方法取得。

**為影片框架新增字幕**

此範例嵌入本機影片，並加入一條標示為 English 的 WebVTT 字幕軌道。字幕的時間戳記應與影片相符。儲存的簡報會同時包含影片與其字幕。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) 類別亦提供 [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) 方法，以從資料流新增字幕。

**從影片框架擷取字幕**

此範例將第一張投影片上所有影片框架的字幕軌道另存為個別的 WebVTT 檔案。使用連續編號以保持輸出檔案的唯一性。主控台會報告擷取的軌道數量。簡報必須至少包含一張投影片。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

每個 [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) 物件會公開字幕識別碼、標籤、二進位資料以及以 UTF-8 字串呈現的字幕文字。

**從影片框架移除字幕**

此範例移除第一張投影片上第一個形狀位置的影片框架的所有字幕，並儲存結果。它假設投影片與形狀均已存在，且該形狀為影片框架。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需要移除單一字幕軌道，請使用 [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) 方法取代 [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear)。

## **從投影片擷取影片**

除了將影片加入投影片之外，Aspose.Slides 亦允許您擷取簡報中嵌入的影片。

此範例將每張投影片的嵌入影片擷取為單獨的編號二進位檔案。連結影片會被略過，因為它們不含嵌入資料。主控台會列印每支影片的 MIME 類型與總計數量。輸出使用通用的 `.bin` 副檔名；如有需要，可依報告的媒體類型自行更改副檔名。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**可以變更影片框架的哪些播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) 物件的方法控制 [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/)（自動或點擊）以及 [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/)。

**加入影片會影響 PPTX 檔案大小嗎？**

會的。若嵌入本機影片，二進位資料會併入文件，簡報大小會隨影片檔案大小成比例增加。若連結至線上影片並加入縮圖，簡報只儲存連結與預覽圖像，大小增幅通常較小。

**我可以在不變更位置和尺寸的情況下，更換現有影片框架中的影片嗎？**

可以。您可以在保持形狀幾何的前提下，使用 [setEmbeddedVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) 交換框架內的影片內容，這是更新現有版面媒體的常見情境。

**可以判斷嵌入影片的內容類型（MIME）嗎？**

可以。嵌入影片具有可透過 [getContentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) 讀取的內容類型，您可將其用於例如儲存至磁碟等用途。