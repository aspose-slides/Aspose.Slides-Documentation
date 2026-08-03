---
title: 使用 C++ 管理簡報中的影片框格
linktitle: 影片框格
type: docs
weight: 10
url: /zh-hant/cpp/video-frame/
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
- C++
- Aspose.Slides
description: "學習使用 Aspose.Slides for C++ 在 PowerPoint 與 OpenDocument 投影片中以程式方式新增與擷取影片框格。快速操作指南。"
---
## **簡介**

在簡報中恰當放置影片能使您的訊息更具說服力，並提升觀眾的參與度。

PowerPoint 允許您以兩種方式將影片添加至簡報的投影片中：

* 新增或嵌入本機影片（儲存在您的電腦上）
* 新增線上影片（來自諸如 YouTube 的網路來源）。

為了讓您能將影片（影片物件）新增至簡報，Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 介面以及其他相關類型。

## **建立嵌入式影片框格**

如果您要加入至投影片的影片檔案儲存在本機，您可以建立影片框格將影片嵌入簡報中。

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得投影片的參照。
3. 新增 [IVideo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideo/) 物件，並傳入影片檔案路徑，以將影片嵌入簡報。
4. 新增 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 物件，以建立影片的框格。  
5. 儲存已修改的簡報。

以下 C++ 程式碼示範如何將本機儲存的影片加入簡報：

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

或者，您也可以直接將檔案路徑傳遞給 [AddVideoFrame()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addvideoframe/) 方法來加入影片：

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **使用網路來源影片建立影片框格**

較新版的 Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支援在簡報中使用線上影片。若您要使用的影片可於線上取得（例如 YouTube），即可透過其網路連結將其加入簡報。

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例
2. 透過索引取得投影片的參照。 
3. 新增 [IVideo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideo/) 物件，並傳入影片的連結。
4. 為影片框格設定縮圖。 
5. 儲存簡報。 

以下 C++ 程式碼示範如何從網路將影片加入 PowerPoint 簡報的投影片中：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// 建立一個代表簡報檔案的 Presentation 物件
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 新增影片框格 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// 設定影片的播放模式與音量
vf->set_PlayMode(VideoPlayModePreset::Auto);

//將簡報儲存至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **裁剪影片框格**

Aspose.Slides 允許您透過 [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/set_trimfromstart/) 與 [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/set_trimfromend/) 設定 trim‑from‑start 與 trim‑from‑end 的數值，來控制影片的播放區段。兩個值皆以毫秒為單位，分別表示要從影片開頭與結尾略過的時間長度。此設定會變更簡報中的影片播放行為，並不會裁切或修改嵌入影片的二進位資料。

**設定裁剪**

若要建立影片框格並設定其裁剪參數：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 在簡報中新增 [IVideo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideo/) 物件。
3. 在投影片中新增 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 物件。
4. 透過 [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/set_trimfromstart/) 與 [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/set_trimfromend/) 設定 trim‑from‑start 與 trim‑from‑end 的數值。
5. 儲存已修改的簡報。

以下程式碼示例會在播放時跳過嵌入影片的前 2.5 秒與最後 1 秒：

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**讀取裁剪設定**

若要檢視現有的裁剪設定，載入簡報、於第一張投影片的形狀中找出 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 物件，並透過 [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/get_trimfromstart/) 與 [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/get_trimfromend/) 讀取數值。

以下程式碼示例會找出第一張投影片上的第一個影片框格，並以毫秒為單位回報其裁剪設定：

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **管理影片字幕**

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框格的隱匿字幕。字幕以 WebVTT 格式儲存，並可透過 [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/get_captiontracks/) 方法取得。

**為影片框格新增字幕**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 將影片加入簡報。
3. 在投影片中新增 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 物件。
4. 使用由 [get_CaptionTracks](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/get_captiontracks/) 回傳的 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/) 來新增 WebVTT 字幕軌道。
5. 儲存已修改的簡報。

以下程式碼示範如何為影片框格新增字幕：

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// 新增來自 WebVTT 檔案的字幕軌道。
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/) 介面亦提供可從串流新增字幕的多載方法。

**從影片框格擷取字幕**

1. 載入包含該影片的簡報。
2. 找到目標 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 物件。
3. 遍歷由 [get_CaptionTracks](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/get_captiontracks/) 回傳的字幕軌道。
4. 將每條字幕軌道儲存為 `.vtt` 檔案。

以下程式碼示範如何從影片框格擷取字幕：

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
            // 將字幕軌道保存到 WebVTT 檔案。
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

每個 [ICaptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptions/) 物件會公開字幕識別碼、標籤、二進位資料，以及以 UTF-8 字串呈現的字幕內容。

**從影片框格移除字幕**

1. 載入包含該影片的簡報。
2. 取得目標 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 物件。
3. 從 [get_CaptionTracks](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/get_captiontracks/) 回傳的集合中移除字幕軌道。
4. 儲存已修改的簡報。

以下程式碼示範如何移除影片框格中的所有字幕：

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// 移除影片框格的所有字幕。
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

若只需要移除單一字幕軌道，請使用 [Remove](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/removeat/) 方法，而非 [Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/clear/)。

## **從投影片中擷取影片**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例以載入包含影片的簡報。 
2. 遍歷所有的 [ISlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/) 物件。
3. 遍歷所有的 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 物件以找出 [VideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/videoframe/)。 
4. 將影片儲存至磁碟。

以下 C++ 程式碼示範如何從簡報投影片中擷取影片：

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

**可以對 VideoFrame 更改哪些影片播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/videoframe/) 物件的屬性控制 [播放模式](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/videoframe/set_playmode/)（自動或點擊）以及 [迴圈播放](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/videoframe/set_playloopmode/)。這些選項皆可從 VideoFrame 物件取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會。若您嵌入本機影片，影片的二進位資料會被納入文件中，簡報大小會隨影片檔案大小等比例增加。若您加入線上影片，則僅嵌入連結與縮圖，檔案大小的增幅較小。

**我能在不改變位置與大小的情況下，取代既有 VideoFrame 中的影片嗎？**

可以。您可以在保留形狀幾何資訊的前提下，使用 [set_EmbeddedVideo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/videoframe/set_embeddedvideo/) 替換框格內的影片內容，這在更新既有版面配置中的媒體時相當常見。

**能否判定嵌入影片的內容類型（MIME）？**

可以。嵌入影片具有可讀取的 [content type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/video/get_contenttype/)，您可依此資訊在儲存至磁碟時加以使用。