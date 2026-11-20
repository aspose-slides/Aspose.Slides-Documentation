---
title: 使用 C++ 管理簡報中的音訊框架
linktitle: 音訊框架
type: docs
weight: 10
url: /zh-hant/cpp/audio-frame/
keywords:
- 音訊
- 音訊框架
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 擷取音訊
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在投影片中嵌入音訊、變更音訊圖示、設定播放、管理 WebVTT 字幕，並擷取投影片過場聲音。"
---
## **概覽**

音訊框架可讓您在投影片上播放聲音。使用 Aspose.Slides for C++，您可以嵌入音訊剪輯、選擇代表它的圖片、調整播放設定，並附加字幕。您也可以取得指派給投影片過場效果的聲音。

## **建立音訊框架**

使用 [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) 將本機音訊剪輯嵌入至第一張投影片。前兩個座標決定框架在投影片上的位置，接下來的兩個值設定其寬度與高度，單位皆為點。此範例呼叫 [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) 以自動開始剪輯，並呼叫 [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) 選取大聲預設值。

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

presentation->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **變更音訊框架縮圖**

預設情況下，音訊框架會顯示揚聲器圖示。若要顯示自訂縮圖，請使用 [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) 將圖片加入簡報，並以 [set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) 設為框架的圖片。此範例使用 JPEG 作為嵌入音訊剪輯的縮圖。

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageStream = File::OpenRead(u"eagle.jpeg");
auto thumbnail = presentation->get_Images()->AddImage(imageStream);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

## **變更音訊播放選項**

PowerPoint 的 **Audio Options** 控制項決定剪輯何時開始、音量大小，以及在投影片放映期間的行為。

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint 控制項 | Aspose.Slides for C++ 方法 |
| --- | --- |
| Start | [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) |
| Volume preset | [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) |
| Play Across Slides | [set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playacrossslides/) |
| Loop until Stopped | [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playloopmode/) |
| Hide During Show | [set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_hideatshowing/) |
| Rewind after Playing | [set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_rewindaudio/) |
| Fade In | [set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeinduration/) |
| Fade Out | [set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeoutduration/) |
| Trim Audio start time | [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) |
| Trim Audio end time | [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) |
| Volume slider | [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) |

此範例在第一張投影片上尋找第一個音訊框架，呼叫 [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) 以在點擊時開始播放，並選取低音量預設值。剪輯會跨投影片持續播放，且不會循環。圖示在放映期間保持隱藏，播放完畢後會倒帶。

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);
    audioFrame->set_Volume(AudioVolumeMode::Low);
    audioFrame->set_PlayAcrossSlides(true);
    audioFrame->set_PlayLoopMode(false);
    audioFrame->set_HideAtShowing(true);
    audioFrame->set_RewindAudio(true);

    presentation->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

對於超過 3.5 秒的剪輯，此範例會略過最前面的 1.5 秒與最後的 2 秒。[set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) 的參數指定要從剪輯結尾省略的持續時間。若要取得 PowerPoint 顯示的結束時間，只需將該偏移量從完整剪輯長度中減去。剪輯的淡入時間為 200 毫秒，淡出時間為 500 毫秒。所有四個設定器皆以毫秒為單位。

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame->set_TrimFromStart(1500);
audioFrame->set_TrimFromEnd(2000);
audioFrame->set_FadeInDuration(200);
audioFrame->set_FadeOutDuration(500);

presentation->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
```

若要將播放音量設定為特定百分比，請使用 [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/)。此範例將第一張投影片上第一個音訊框架的音量設定為 85%。

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_VolumeValue(85);

    presentation->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

## **管理音訊字幕**

每個音訊框架透過 [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_captiontracks/) 暴露其字幕集合。可使用它來附加 WebVTT 字幕、匯出現有軌道，或將其移除。

### **加入音訊字幕**

此範例在第一張投影片嵌入音訊剪輯，並使用 [ICaptionsCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/add/) 附加本機 WebVTT 軌道。第一個參數提供軌道標籤，第二個參數指向包含時間字幕的檔案。

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
```

### **擷取音訊字幕**

此範例匯出第一張投影片上音訊框架所附加的每個字幕軌道。它將 [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_binarydata/) 回傳的位元組寫入 WebVTT 檔案，並以 [get_CaptionId](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_captionid/) 回傳的值作為檔名，使每條軌道都有獨立的輸出。

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto fileName = track->get_CaptionId().ToString() + u".vtt";
        File::WriteAllBytes(fileName, track->get_BinaryData());
    }
}
```

### **移除音訊字幕**

使用 [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/removeat/) 可刪除單一軌道。此範例使用 [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/clear/) 移除第一張投影片上第一個音訊框架的所有字幕，同時保留原始剪輯。

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->get_CaptionTracks()->Clear();

    presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

### **在音訊字幕中尋找行**

要在第一張投影片的音訊字幕中尋找特定行，請對每條軌道呼叫 [get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) 以在記憶體中讀取其 WebVTT 文字。在純文字的 WebVTT cue 中，時間行含有 `-->`，字幕行緊隨其後，空白行則結束該 cue。此範例會列印軌道標籤以及每一行包含「café」的字幕。

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto reader = MakeObject<StringReader>(track->get_DataAsString());
        auto inCue = false;
        for (auto line = reader->ReadLine(); !line.IsNull(); line = reader->ReadLine())
        {
            if (line.get_Length() == 0)
                inCue = false;
            else if (line.Contains(u"-->"))
                inCue = true;
            else if (inCue && line.IndexOf(u"caf\u00e9", StringComparison::OrdinalIgnoreCase) >= 0)
                Console::WriteLine(track->get_Label() + u": " + line);
        }
    }
}
```

## **擷取音訊**

投影片過場效果可以擁有自己的聲音。要取得它，請對過場呼叫 [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_sound/)。此範例使用 [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) 取得音訊位元組，並印出位元組數量。如果第一張投影片沒有過場聲音，則會印出相應訊息。

```cpp
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioSlide.pptx");
auto slide = presentation->get_Slide(0);

auto sound = slide->get_SlideShowTransition()->get_Sound();
if (sound)
{
    auto audioData = sound->get_BinaryData();
    Console::WriteLine(u"Transition sound: {0} bytes.", audioData->get_Length());
}
else
{
    Console::WriteLine(u"The first slide has no transition sound.");
}
```

## **常見問題**

**我可以在多張投影片之間重複使用相同的音訊剪輯而不必重複加入嗎？**

可以。只需將剪輯一次加入簡報的 [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/)，然後在每張投影片呼叫 [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) 時傳入相同的音訊物件。

**我可以取代既有音訊框架中的聲音嗎？**

可以。對於連結的聲音，使用 [set_LinkPathLong](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_linkpathlong/) 並提供替換檔案的路徑。對於嵌入的聲音，將簡報音訊集合中的另一個剪輯傳給 [set_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_embeddedaudio/)。兩種方法都會保留既有框架。

**剪裁會改變簡報中儲存的音訊資料嗎？**

不會。[set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) 與 [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) 只設定播放的起始與結束邊界。您仍然可以透過 [get_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_embeddedaudio/) 取得完整的剪輯。