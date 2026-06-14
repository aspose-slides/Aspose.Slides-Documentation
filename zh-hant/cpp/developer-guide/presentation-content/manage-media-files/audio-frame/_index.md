---
title: 使用 C++ 在簡報中管理音訊
linktitle: 音訊框
type: docs
weight: 10
url: /zh-hant/cpp/audio-frame/
keywords:
- 音訊
- 音訊框
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 擷取音訊
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中建立與控制音訊框——提供嵌入、修剪、迴圈及設定 PPT、PPTX 與 ODP 簡報播放的程式碼範例。"
---
## **概觀**

本篇說明如何在 Aspose.Slides 中使用音訊框架。它展示了如何將嵌入式音訊新增至投影片、設定音訊框縮圖、配置播放選項（例如音量、迴圈、隱藏、修剪與淡入淡出時間），以及提取投影片秀過渡時使用的音訊。

## **建立音訊框架**

Aspose.Slides for C++ 允許您將音訊檔案新增至投影片。音訊檔案會以音訊框的形式嵌入於投影片中。

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 載入您想嵌入於投影片的音訊檔案串流。  
4. 將嵌入式音訊框（包含音訊檔案）加入投影片。  
5. 設定由 [IAudioFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_audio_frame) 物件所公開的 [PlayMode](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) 與 `Volume`。  
6. 儲存已修改的簡報。

此 C++ 程式碼示範如何將嵌入式音訊框新增至投影片：

``` cpp
// 實例化一個代表簡報檔案的 Presentation 類別
auto pres = System::MakeObject<Presentation>();

// 取得第一張投影片
auto sld = pres->get_Slides()->idx_get(0);

// 將 wav 音訊檔載入為串流
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// 新增音訊框
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// 設定音訊的播放模式與音量
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// 將 PowerPoint 檔寫入磁碟
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **變更音訊框縮圖**

當您將音訊檔案新增至簡報時，音訊會以帶有預設標準圖像的框顯示（請參見下方圖片）。您可以變更音訊框的縮圖（設定您偏好的圖像）。

此 C++ 程式碼示範如何變更音訊框的縮圖或預覽圖像：

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// 在投影片中新增具有指定位置與大小的音訊框。
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// 將圖像加入簡報資源。
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// 設定音訊框的圖像。 // <-----
        
//將修改過的簡報儲存到磁碟。
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **變更音訊播放選項**

Aspose.Slides for C++ 允許您變更控制音訊播放或屬性的選項。例如，您可以調整音訊音量、設定音訊迴圈播放，甚至隱藏音訊圖示。

PowerPoint **Audio Options**（音訊選項）對應 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/) 方法：

![音訊框範例圖](audio_frame_0.png)

PowerPoint **Audio Options** 對應的 Aspose.Slides 方法：

- **開始** 下拉選單對應 [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_playmode/) 方法  
- **音量** 對應 [AudioFrame::set_Volume](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_volume/) 方法  
- **跨投影片播放** 對應 [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_playacrossslides/) 方法  
- **持續迴圈直至停止** 對應 [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_playloopmode/) 方法  
- **放映時隱藏** 對應 [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_hideatshowing/) 方法  
- **播放結束後倒帶** 對應 [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_rewindaudio/) 方法  

PowerPoint **編輯** 選項對應 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/) 屬性：

- **淡入** 對應 [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_fadeinduration/) 方法  
- **淡出** 對應 [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_fadeoutduration/) 方法  
- **修剪音訊起始時間** 對應 [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_trimfromstart/) 方法  
- **修剪音訊結束時間** 值等於音訊總長度減去 [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_trimfromend/) 方法的值  

PowerPoint 音量控制對應 [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_volumevalue/) 方法，可將音量以百分比方式調整。

以下說明如何變更音訊播放選項：

1. **建立**（[建立](#creating-audio-frame)）或取得音訊框。  
2. 為您想調整的音訊框屬性設定新值。  
3. 儲存已修改的 PowerPoint 檔案。

此 C++ 程式碼示範調整音訊選項的操作：

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// 取得形狀
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// 將形狀轉型為 AudioFrame 形狀
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// 設定播放模式為點擊播放
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// 設定音量為低
audioFrame->set_Volume(AudioVolumeMode::Low);

// 設定音訊跨投影片播放
audioFrame->set_PlayAcrossSlides(true);

// 停用音訊迴圈
audioFrame->set_PlayLoopMode(false);

// 於投影片放映時隱藏 AudioFrame
audioFrame->set_HideAtShowing(true);

// 播放完畢後將音訊倒帶至起始位置
audioFrame->set_RewindAudio(true);

// 將 PowerPoint 檔儲存至磁碟
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

此 C++ 範例示範如何新增帶嵌入音訊的音訊框、修剪它，並設定淡入淡出時間：

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// 設定修剪起始偏移為 1.5 秒
audioFrame->set_TrimFromStart(1500);
// 設定修剪結束偏移為 2 秒
audioFrame->set_TrimFromEnd(2000);

// 設定淡入持續時間為 200 毫秒
audioFrame->set_FadeInDuration(200);
// 設定淡出持續時間為 500 毫秒
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

以下程式碼示例說明如何取得嵌入音訊的音訊框，並將音量設為 85%：

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// 取得音訊框形狀
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// 設定音訊音量為 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **管理音訊字幕**

Aspose.Slides 允許您透過 [get_CaptionTracks](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iaudioframe/get_captiontracks/) 方法為音訊框加入閉合字幕。此方法會回傳一個 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/)，可讓您加入 WebVTT 字幕軌、遍歷現有軌道，並在需要時將其移除。

**新增音訊字幕**

使用 [get_CaptionTracks](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iaudioframe/get_captiontracks/) 方法將一個或多個字幕軌附加至音訊框。在下列範例中，先將音訊檔案加入投影片，然後從 `.vtt` 檔案載入新的字幕軌。

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// 新增來自 WebVTT 檔案的字幕軌道。
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**擷取音訊字幕**

您可以遍歷與音訊框關聯的字幕軌，並將它們儲存為 `.vtt` 檔案。每個字幕軌都會公開其二進位資料與唯一識別碼，供匯出時使用。

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // 將每個字幕軌儲存為 .vtt 檔案。
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**移除音訊字幕**

若要從音訊框移除字幕，請使用 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/) 提供的方法，如 [Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/clear/)、[Remove](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/remove/)、或 [RemoveAt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icaptionscollection/removeat/)。下列範例會移除音訊框中的所有字幕軌。

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// 移除音訊框中的所有字幕軌。
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **擷取音訊**
Aspose.Slides 允許您提取投影片秀過渡時使用的音效。例如，您可以提取特定投影片所使用的音效。

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例並載入包含音訊的簡報。  
2. 透過索引取得相關投影片的參考。  
3. 取得該投影片的投影片秀過渡設定。  
4. 以位元組資料形式提取音效。

此 C++ 程式碼示範如何提取投影片中使用的音訊：

``` cpp
String presName = u"AudioSlide.pptx";

// 實例化一個代表簡報檔案的 Presentation 類別
auto pres = System::MakeObject<Presentation>(presName);

// 取得目標投影片
auto slide = pres->get_Slides()->idx_get(0);

// 取得投影片的投影片秀過渡效果
auto transition = slide->get_SlideShowTransition();

// 將音效提取為位元組陣列
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **常見問題**

**我可以在多個投影片中重複使用相同的音訊資產而不會使檔案大小膨脹嗎？**

可以。將音訊一次加入簡報的共享 [音訊集合](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_audios/)，然後建立額外參考該資產的音訊框。這樣可避免重複儲存媒體資料，保持簡報大小受控。

**我能在不重新建立圖形的情況下更換既有音訊框的音效嗎？**

可以。對於連結式音效，更新 [link path](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_linkpathlong/) 以指向新檔案。對於嵌入式音效，將 [embedded audio](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/audioframe/set_embeddedaudio/) 物件替換為簡報 [音訊集合](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_audios/) 中的其他音訊。框的格式與大部分播放設定將保持不變。

**修剪會改變簡報中儲存的底層音訊資料嗎？**

不會。修剪僅調整播放範圍。原始音訊位元組保持不變，仍可透過嵌入音訊或簡報的音訊集合存取。