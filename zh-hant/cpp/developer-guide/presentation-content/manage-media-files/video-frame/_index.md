---
title: 使用 C++ 管理簡報中的影片框架
linktitle: 影片框架
type: docs
weight: 10
url: /zh-hant/cpp/video-frame/
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
- C++
- Aspose.Slides
description: "學習使用 Aspose.Slides for C++ 程式化地在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框架。快速入門指南。"
---
## **簡介**

在簡報中適當放置影片可以使您的訊息更具說服力，並提升觀眾的參與度。

PowerPoint 允許您以兩種方式將影片加入簡報中的投影片：

* 新增或嵌入本機影片（儲存在您的電腦上）
* 新增線上影片（來自如 YouTube 等網路來源）。

為了讓您能將影片（影片物件）加入簡報，Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 介面以及其他相關類型。

## **建立嵌入式影片框架**

如果您想加入投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的執行個體。  
1. 透過索引取得投影片的參考。  
1. 新增一個 [IVideo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideo/) 物件，並傳入影片檔案路徑，以將影片嵌入簡報。  
1. 新增一個 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 物件，以建立影片的框架。  
1. 儲存已修改的簡報。  

以下 C++ 程式碼示範如何將本機儲存的影片新增至簡報：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

或者，您也可以直接將檔案路徑傳遞給 [AddVideoFrame()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addvideoframe/) 方法來新增影片：

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **建立來自網路來源的影片框架**

Microsoft [PowerPoint 2013 及更新版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支援在簡報中使用 YouTube 影片。如果您想使用的影片在網路上可取得（例如 YouTube），您可以透過其網路連結將其加入簡報。

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的執行個體。  
1. 透過索引取得投影片的參考。  
1. 新增一個 [IVideo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideo/) 物件，並傳入影片的連結。  
1. 為影片框架設定縮圖。  
1. 儲存簡報。  

以下 C++ 程式碼示範如何從網路將影片新增至 PowerPoint 簡報的投影片中：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// 實例化一個代表簡報檔案的 Presentation 物件
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 存取第一張投影片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 新增影片框架 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// 設定影片的播放模式與音量
vf->set_PlayMode(VideoPlayModePreset::Auto);

//儲存簡報至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **管理影片字幕**

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框架的隱藏字幕。字幕以 WebVTT 格式儲存，並可透過 [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/get_captiontracks/) 方法取得。

**為影片框架新增字幕**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的執行個體。  
1. 將影片新增至簡報。  
1. 在投影片上新增一個 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 物件。  
1. 使用由 [get_CaptionTracks](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/get_captiontracks/) 回傳的 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/) 來新增 WebVTT 字幕軌。  
1. 儲存已修改的簡報。  

以下程式碼示範如何為影片框架新增字幕：

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// 從 WebVTT 檔案新增新的字幕軌。
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/) 介面亦提供一個載入串流以新增字幕的多載方法。

**從影片框架提取字幕**

1. 載入包含影片的簡報。  
1. 找到目標的 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 物件。  
1. 迭代由 [get_CaptionTracks](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/get_captiontracks/) 回傳的字幕軌。  
1. 將每條字幕軌儲存為 `.vtt` 檔案。  

以下程式碼示範如何從影片框架提取字幕：

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // 將字幕軌儲存為 WebVTT 檔案。
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

每個 [ICaptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptions/) 物件會公開字幕的識別碼、標籤、二進位資料，以及以 UTF-8 字串形式的字幕內容。

**從影片框架移除字幕**

1. 載入包含影片的簡報。  
1. 取得目標的 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 物件。  
1. 從由 [get_CaptionTracks](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/get_captiontracks/) 回傳的集合中移除字幕軌。  
1. 儲存已修改的簡報。  

以下程式碼示範如何移除影片框架的所有字幕：

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// 移除影片框架中的所有字幕。
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

如果只需要移除單一字幕軌，請使用 [Remove](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/removeat/) 方法，取代 [Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/clear/)。

## **從投影片中擷取影片**

除了向投影片加入影片外，Aspose.Slides 也允許您擷取嵌入於簡報中的影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的執行個體，以載入包含影片的簡報。  
2. 迭代所有 [ISlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/) 物件。  
3. 迭代所有 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 物件，以尋找 [VideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/videoframe/)。  
4. 將影片儲存至磁碟。  

以下 C++ 程式碼示範如何擷取簡報投影片中的影片：

```c++
// 文件目錄的路徑。
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **常見問題**

**可以為 VideoFrame 更改哪些影片播放參數？**  
您可以控制 [playback mode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/videoframe/set_playmode/)（自動或點擊）與 [looping](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/videoframe/set_playloopmode/)。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/videoframe/) 物件的屬性取得。

**加入影片會影響 PPTX 檔案大小嗎？**  
會的。當您嵌入本機影片時，二進位資料會寫入文件，簡報大小會隨檔案大小成比例增長。加入線上影片時，只會嵌入連結與縮圖，尺寸增幅較小。

**我可以在不更改位置和大小的情況下，替換現有 VideoFrame 中的影片嗎？**  
可以。您可以在保留形狀幾何的前提下，交換框架內的 [video content](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/videoframe/set_embeddedvideo/)，這是一種常見的更新既有版面媒體的情境。

**是否能判斷嵌入影片的內容類型（MIME）？**  
可以。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/video/get_contenttype/)，您可在儲存至磁碟等情況下加以使用。