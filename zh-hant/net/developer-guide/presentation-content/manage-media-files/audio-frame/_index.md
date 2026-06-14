---
title: 在 .NET 中管理簡報的音訊框架
linktitle: 音訊框架
type: docs
weight: 10
url: /zh-hant/net/audio-frame/
keywords:
- 音訊
- 音訊框架
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 擷取音訊
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中建立與控制音訊框架——提供 C# 範例，示範嵌入、修剪、迴圈以及在 PPT、PPTX 與 ODP 簡報中設定播放。"
---
## **概觀**

本文說明了如何在 Aspose.Slides 中使用音訊框架。它展示了如何將嵌入式音訊新增至投影片、自訂音訊框架的縮圖、設定播放選項（例如音量、迴圈、隱藏、修剪與淡入淡出時間），以及如何擷取在投影片放映過程中使用的音訊。

## **建立音訊框架**

Aspose.Slides for .NET 允許您將音訊檔案新增至投影片。音訊檔案會以音訊框架的形式嵌入於投影片中。

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)類別的實例。
2. 透過索引取得投影片的參照。
3. 載入您想要嵌入至投影片的音訊檔案資料流。
4. 將嵌入式音訊框架（包含音訊檔案）新增至投影片。
5. 設定由 [IAudioFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe) 物件公開的 [PlayMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioplaymodepreset) 與 `Volume`。
6. 儲存已修改的簡報。

以下 C# 程式碼示範如何將嵌入式音訊框架新增至投影片：

```c#
// 實例化一個代表簡報檔案的 Presentation 類別
using (Presentation pres = new Presentation())
{
    // 取得第一張投影片
    ISlide sld = pres.Slides[0];
    
    // 將 wav 音訊檔載入為資料流
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // 加入音訊框架
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // 設定音訊的播放模式與音量
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // 將 PowerPoint 檔案寫入磁碟
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **變更音訊框架縮圖**

當您將音訊檔案新增至簡報時，音訊會以帶有預設標準圖像的框架顯示（請參見下方圖片）。您可以變更音訊框架的縮圖（設定您偏好的圖像）。

以下 C# 程式碼示範如何變更音訊框架的縮圖或預覽圖像：

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // 在投影片上加入音訊框架，並指定位置和大小。
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // 將影像加入簡報資源。
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // 設定音訊框架的影像。
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
	
	//將已修改的簡報儲存到磁碟
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **變更音訊播放選項**

Aspose.Slides for .NET 允許您變更控制音訊播放或屬性的選項。例如，您可以調整音訊音量、將音訊設定為循環播放，甚至隱藏音訊圖示。

Microsoft PowerPoint 中的 **Audio Options** 面板：

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** 對應 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe) 屬性：

- **Start** 下拉選單對應 [AudioFrame.PlayMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/properties/playmode) 屬性
- **Volume** 對應 [AudioFrame.Volume](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/properties/volume) 屬性
- **Play Across Slides** 對應 [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/properties/playacrossslides) 屬性
- **Loop until Stopped** 對應 [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/properties/playloopmode) 屬性
- **Hide During Show** 對應 [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/properties/hideatshowing) 屬性
- **Rewind after Playing** 對應 [AudioFrame.RewindAudio](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/properties/rewindaudio) 屬性

PowerPoint **Editing** 選項對應 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe) 屬性：

- **Fade In** 對應 [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/fadeinduration/) 屬性
- **Fade Out** 對應 [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/fadeoutduration/) 屬性
- **Trim Audio Start Time** 對應 [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/trimfromstart/) 屬性
- **Trim Audio End Time** 值等於音訊總長度減去 [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/trimfromend/) 屬性的值

PowerPoint 音訊控制面板上的 **Volume controll**（音量控制）對應 [AudioFrame.VolumeValue](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/volumevalue/) 屬性。它允許您以百分比調整音訊音量。

以下說明如何變更音訊播放選項：

1. [Сreate](#create-audio-frame) 或取得音訊框架。
2. 為您想調整的音訊框架屬性設定新值。
3. 儲存已修改的 PowerPoint 檔案。

以下 C# 程式碼示範調整音訊選項的操作：

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // 取得 AudioFrame 形狀
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // 將播放模式設定為點擊時播放
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // 將音量設定為低
    audioFrame.Volume = AudioVolumeMode.Low;

    // 將音訊設定為跨投影片播放
    audioFrame.PlayAcrossSlides = true;

    // 停用音訊的迴圈
    audioFrame.PlayLoopMode = false;

    // 在投影片放映時隱藏 AudioFrame
    audioFrame.HideAtShowing = true;

    // 播放後將音訊倒回至開始位置
    audioFrame.RewindAudio = true;

    // 將 PowerPoint 檔案儲存至磁碟
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

以下 C# 範例展示如何新增帶嵌入式音訊的音訊框架、修剪它，並設定淡入淡出時間：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // 設定修剪開始偏移為 1.5 秒
    audioFrame.TrimFromStart = 1500f;
    // 設定修剪結束偏移為 2 秒
    audioFrame.TrimFromEnd = 2000f;

    // 設定淡入持續時間為 200 毫秒
    audioFrame.FadeInDuration = 200f;
    // 設定淡出持續時間為 500 毫秒
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

以下程式碼範例說明如何取得帶嵌入式音訊的音訊框架，並將其音量設為 85%：

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // 取得音訊框架形狀
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // 設定音訊音量為 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **管理音訊字幕**

Aspose.Slides 允許您透過 [CaptionTracks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iaudioframe/captiontracks/) 屬性為音訊框架新增閉合字幕。此屬性會回傳一個 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icaptionscollection/)，讓您新增 WebVTT 字幕軌、遍歷現有軌道，並在需要時將其移除。

**新增音訊字幕**

使用 [CaptionTracks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iaudioframe/captiontracks/) 屬性將一條或多條字幕軌附加到音訊框架。以下範例先將音訊檔案新增至投影片，接著從 `.vtt` 檔案載入新的字幕軌。

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // 從 WebVTT 檔案新增一條字幕軌道。
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**擷取音訊字幕**

您可以遍歷與音訊框架關聯的字幕軌，並將其儲存為 `.vtt` 檔案。每條字幕軌會公開其二進位資料與唯一識別碼，可於匯出字幕時使用。

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // 將字幕軌道儲存為 .vtt 檔案。
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**移除音訊字幕**

若要從音訊框架移除字幕，可使用 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icaptionscollection/) 提供的方法，例如 [Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icaptionscollection/clear/)、[Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icaptionscollection/remove/)，或 [RemoveAt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icaptionscollection/removeat/)。以下範例會移除音訊框架中的所有字幕軌。

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // 移除音訊框架中的所有字幕軌道。
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **擷取音訊**

Aspose.Slides for .NET 允許您擷取投影片放映過渡時使用的音效。例如，您可以擷取特定投影片所使用的音效。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)類別的實例，並載入包含音訊的簡報。
2. 透過索引取得相關投影片的參照。
3. 存取該投影片的投影片放映過渡設定。
4. 以位元組資料形式擷取音效。

以下 C# 程式碼示範如何擷取投影片中使用的音訊：

```c#
string presName = "AudioSlide.pptx";

// 實例化一個代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation(presName);

// 取得投影片
ISlide slide = pres.Slides[0];

// 取得投影片的投影片放映過渡效果
ISlideShowTransition transition = slide.SlideShowTransition;

//Extracts the sound in byte array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **常見問題**

**我可以在多張投影片重複使用相同的音訊資產而不會增大檔案大小嗎？**

是的。只需將音訊一次加入簡報的共用 [audio collection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/audios/)，然後建立其他參考該現有資產的音訊框架。這樣可避免重複媒體資料，保持簡報大小可控。

**我可以在不重新建立形狀的情況下替換現有音訊框架中的音效嗎？**

是的。對於連結音訊，更新 [link path](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/linkpathlong/) 以指向新檔案。對於嵌入式音訊，將 [embedded audio](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/audioframe/embeddedaudio/) 物件替換為簡報的 [audio collection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/audios/) 中的其他音訊。框架的格式與大多數播放設定將保持不變。

**修剪會改變簡報中儲存的底層音訊資料嗎？**

不會。修剪僅調整播放範圍，原始音訊位元不會被修改，仍可透過嵌入式音訊或簡報的 audio collection 存取。