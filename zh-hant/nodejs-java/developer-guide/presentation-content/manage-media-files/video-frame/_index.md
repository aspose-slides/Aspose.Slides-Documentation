---
title: 在簡報中使用 Node.js 管理影片框
linktitle: 影片框
type: docs
weight: 10
url: /zh-hant/nodejs-java/video-frame/
keywords:
- 新增影片
- 建立影片
- 嵌入影片
- 提取影片
- 取得影片
- 影片框
- 網路來源
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Node.js via Java，在 PowerPoint 與 OpenDocument 幻燈片中以程式方式新增與提取影片框。快速上手指南。"
---
## **簡介**

影片可以說明概念並吸引觀眾。Aspose.Slides for Node.js via Java 讓您可以將影片框新增至投影片、調整播放設定、管理字幕，並提取內嵌影片資料。

PowerPoint 支援本機影片與線上影片的連結，例如 YouTube 影片。

為了表示影片資料和影片框，Aspose.Slides 提供 [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) 類別，以及其他相關型別。

## **建立嵌入式影片框**

如果您要新增至投影片的影片檔案儲存在本機，您可以建立影片框以將影片嵌入至簡報中。

此範例在現有簡報的第一張投影片上嵌入本機影片，並儲存結果。框的座標與尺寸以點為單位。由於 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) 會在簡報使用時保持鎖定，因此資料流會持續開啟，直到儲存完成。

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

您也可以直接將本機影片路徑傳遞給 [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/)。此範例在新簡報的第一張投影片上嵌入影片。影片必須保持可存取，直至簡報儲存完成。

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

## **建立來自網路來源的影片框**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支援在簡報中使用線上影片。您可以建立指向線上影片（例如 YouTube 影片）的影片框。

此範例在第一張投影片上加入 YouTube 影片連結與縮圖。將影片識別碼替換，即可使用其他影片。[setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) 方法請求自動播放。下載縮圖與播放影片皆需要網際網路連線。簡報檢視器亦必須支援線上影片播放。

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

## **在全螢幕模式播放影片**

在教學簡報中，您可以在全螢幕模式下播放軟體示範，讓觀眾看到細節。於播放期間呼叫 [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) 並傳入 `true` 以啟用此行為。

此範例開啟簡報，於第一張投影片上尋找第一個 [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)，並啟用全螢幕播放。輸入的簡報必須至少有一張投影片，且第一張投影片上已有影片框。

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

全螢幕播放控制影片的顯示方式。而 [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) 決定是否自動或點擊後開始播放，[setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) 則決定是否重複播放。若要選擇開始行為，請將播放模式設定為 [VideoPlayModePreset.Auto 或 VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/)。此範例保留了既有的開始與迴圈設定。

## **在播放後倒回影片**

在教學簡報中，將示範影片倒回開頭可讓演講者再次播放。於播放結束後呼叫 [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) 並傳入 `true`，即可將影片返回起點。

此範例開啟簡報，於第一張投影片上尋找第一個 [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)，並啟用倒回。它會停用迴圈以讓播放結束，並設定為點擊後開始播放。輸入的簡報必須至少有一張投影片，且第一張投影片上已有影片框。

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

倒回會將影片返回起點且不會再次啟動播放。相反地，傳入 `true` 給 [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) 會自動重複播放。當您希望影片播放結束並保持可重新播放時，請停用迴圈。 [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) 獨立控制自動或點擊啟動；本範例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/)，讓演講者自行決定何時開始播放。正如範例所示，先設定迴圈後再設定播放模式。倒回功能與 [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) 無關。

## **修剪影片框**

使用 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) 與 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) 可在播放時略過影片開頭或結尾的一部分。兩個數值皆以毫秒為單位。修剪會變更播放設定，卻不會修改內嵌的影片資料。

**設定修剪參數**

此範例嵌入本機影片，於播放時跳過前 2.5 秒與最後 1 秒。請使用長度超過 3.5 秒的影片，以保留可播放的段落。

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

**讀取修剪設定**

此範例以毫秒為單位印出第一張投影片上第一個影片框的修剪數值。簡報必須至少包含一張投影片。若該投影片沒有影片框，則不會印出任何內容。前述範例會產生 2500 與 1000 兩個值。

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

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框的隱蔽字幕。字幕以 WebVTT 格式儲存，並可透過 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) 方法取得。

### **為影片框新增字幕**

此範例嵌入本機影片，並新增標示為 English 的 WebVTT 字幕軌。字幕的時間戳記應與影片相符。儲存的簡報同時包含影片與其字幕。

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

[CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) 類別也提供 [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) 方法，以從串流加入字幕。

### **從影片框提取字幕**

此範例將第一張投影片上所有影片框的字幕軌儲存為個別的 WebVTT 檔案。以連續編號區分輸出檔案。主控台會報告已提取的軌道數量。簡報必須至少包含一張投影片。

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

每個 [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) 物件會顯示字幕的識別碼、標籤、二進位資料，以及作為 UTF-8 字串的字幕文字。

### **從影片框移除字幕**

此範例移除第一張投影片上第一個圖形位置之影片框的全部字幕，並儲存結果。它假設投影片與圖形皆存在，且該圖形為影片框。

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

若只需要移除單一字幕軌，請使用 [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) 方法，而非 [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear)。

### **搜尋影片字幕**

[Captions.getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) 方法會回傳整個 WebVTT 軌道，包括標頭、時間線與字幕文字。您可以在記憶體中搜尋字幕文字，以找出特定片語與其時間戳記。例如，投影片 2 上的英文軌道可能包含以下提示：

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

此範例開啟 `captioned_media.pptx`，並使用 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) 讀取每張投影片上所有頂層影片框的字幕軌。在純文字提示中，時間線包含 `-->`，空白行結束提示。對於包含「café」(不分大小寫) 的每個字幕，範例會印出投影片編號、軌道標籤、原始時間線及完整字幕。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("captioned_media.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const shapes = slide.getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                continue;
            }

            const tracks = shape.getCaptionTracks();
            for (let trackIndex = 0; trackIndex < tracks.getCount(); trackIndex++) {
                const track = tracks.get_Item(trackIndex);
                const lines = track.getDataAsString().split(/\r\n|\n|\r/);
                for (let i = 0; i < lines.length; i++) {
                    const timing = lines[i];
                    if (!timing.includes("-->")) {
                        continue;
                    }
                    const start = i + 1;
                    i = start;
                    while (i < lines.length && lines[i] !== "") {
                        i++;
                    }
                    const caption = lines.slice(start, i).join("\n");
                    if (caption.toLowerCase().includes("café")) {
                        console.log(`Slide ${slide.getSlideNumber()} | ${track.getLabel()} | ${timing}`);
                        console.log(caption);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

搜尋「café」在範例軌道中找到一個符合。搜尋會略過軌道標頭，並在輸出中保留時間設定與換行。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **從投影片提取影片**

除了將影片加入投影片外，Aspose.Slides 也允許您提取簡報中內嵌的影片。

此範例將每張投影片內的內嵌影片提取為分別編號的二進位檔案。連結的影片會被略過，因為它們沒有內嵌資料。主控台會印出每個影片的 MIME 類型以及總計數。輸出使用通用的 `.bin` 副檔名；必要時可改為符合回報的媒體類型。

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

## **FAQ**

**可以為影片框變更哪些影片播放參數？**

您可以控制[播放模式](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/)（自動或點擊）、以及[迴圈](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/)。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) 物件的方法取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會。若您嵌入本機影片，二進位資料會寫入文件，使簡報大小按影片檔案大小成比例增加。若您連結線上影片並加入縮圖，簡報僅儲存連結與預覽圖像，而非影片資料，因此大小增幅通常較小。

**我可以在不變更位置與尺寸的情況下，替換現有影片框中的影片嗎？**

可以。您可以在保持形狀幾何不變的情況下，交換框內的[影片內容](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/)；這是更新既有版面中媒體的常見情境。

**能否取得內嵌影片的內容類型 (MIME)？**

可以。內嵌影片具有[內容類型](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/)，您可以讀取並使用，例如將其儲存至磁碟時。