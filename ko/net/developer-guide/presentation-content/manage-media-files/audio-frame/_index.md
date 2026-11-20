---
title: ".NET에서 프레젠테이션의 오디오 프레임 관리"
linktitle: "오디오 프레임"
type: docs
weight: 10
url: /ko/net/audio-frame/
keywords:
- 오디오
- 오디오 프레임
- 썸네일
- 오디오 추가
- 오디오 속성
- 오디오 옵션
- 오디오 추출
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 슬라이드에 오디오를 삽입하고, 오디오 아이콘을 변경하고, 재생을 구성하며, WebVTT 캡션을 관리하고, 슬라이드 전환 사운드를 추출합니다."
---
## **개요**

오디오 프레임을 사용하면 슬라이드에서 사운드를 재생할 수 있습니다. Aspose.Slides for .NET을 사용하면 오디오 클립을 삽입하고, 이를 나타내는 이미지를 선택하며, 재생을 조정하고 캡션을 첨부할 수 있습니다. 또한 슬라이드 전환에 할당된 사운드를 검색할 수도 있습니다.

## **오디오 프레임 만들기**

첫 번째 슬라이드에 로컬 오디오 클립을 삽입하려면 [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/)를 사용합니다. 처음 두 좌표는 프레임을 슬라이드에 배치하고, 다음 두 값은 너비와 높이를 포인트 단위로 설정합니다. 이 예제는 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/)를 자동으로 클립을 시작하도록 설정하고 [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/)을 높은 사전 설정으로 지정합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **오디오 프레임 썸네일 변경**

기본적으로 오디오 프레임은 스피커 아이콘을 표시합니다. 사용자 지정 썸네일을 표시하려면 [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/)를 사용하여 프레젠테이션에 이미지를 추가하고 해당 이미지를 프레임의 [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) 속성에 할당합니다. 이 예제는 JPEG를 임베디드 오디오 클립의 썸네일로 사용합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **오디오 재생 옵션 변경**

PowerPoint의 **Audio Options** 컨트롤은 클립이 언제 시작되는지, 소리가 얼마나 크게 들리는지, 슬라이드 쇼 중에 어떻게 동작하는지를 결정합니다.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint 컨트롤 | Aspose.Slides property |
| --- | --- |
| 시작 | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| 볼륨 사전 설정 | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| 슬라이드 전체 재생 | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| 멈출 때까지 반복 | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| 쇼 중 숨김 | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| 재생 후 되감기 | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| 페이드 인 | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| 페이드 아웃 | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| 오디오 시작 시간 자르기 | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| 오디오 종료 시간 자르기 | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| 볼륨 슬라이더 | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

이 예제는 첫 번째 슬라이드에서 첫 번째 오디오 프레임을 찾아 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/)을 클릭 시 재생 시작하도록 설정하고 낮은 볼륨 사전 설정을 선택합니다. 클립은 루프가 비활성화된 상태로 슬라이드 전체에서 계속 재생됩니다. 아이콘은 쇼 중에 숨겨지고, 클립은 재생 후 되감깁니다.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

길이가 3.5초를 초과하는 클립에 대해 이 예제는 처음 1.5초와 마지막 2초를 건너뜁니다. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/)은 클립 끝에서 생략할 기간을 측정합니다. PowerPoint에 표시되는 종료 시간을 얻으려면 전체 클립 길이에서 해당 오프셋을 빼면 됩니다. 트림된 클립은 200밀리초에 페이드 인하고 500밀리초에 페이드 아웃합니다. 네 가지 속성 모두 밀리초 단위 값을 사용합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

재생 볼륨을 특정 백분율로 설정하려면 [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/)를 사용합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 오디오 프레임을 85%로 설정합니다.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **오디오 캡션 관리**

각 오디오 프레임에는 [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/) 컬렉션이 있습니다. 이를 사용하여 클립에 WebVTT 캡션을 첨부하거나 기존 트랙을 내보내거나 제거할 수 있습니다.

### **오디오 캡션 추가**

이 예제는 첫 번째 슬라이드에 오디오 클립을 삽입하고 [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/)를 사용하여 로컬 WebVTT 트랙을 첨부합니다. 첫 번째 인자는 트랙 라벨을 제공하고, 두 번째 인자는 시간 캡션이 포함된 파일을 지정합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **오디오 캡션 추출**

이 예제는 첫 번째 슬라이드의 오디오 프레임에 연결된 각 캡션 트랙을 내보냅니다. 트랙의 [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/)를 WebVTT 파일로 기록하고, 해당 [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/)를 파일 이름으로 사용하여 각 트랙이 별도의 출력 파일을 갖도록 합니다.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **오디오 캡션 제거**

개별 트랙을 삭제하려면 [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) 또는 [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/)를 사용합니다. 이 예제는 [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/)를 사용하여 클립은 유지하면서 첫 번째 슬라이드의 첫 번째 오디오 프레임에서 모든 캡션을 제거합니다.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **오디오 캡션에서 라인 찾기**

첫 번째 슬라이드의 오디오 캡션에서 라인을 찾으려면 각 트랙의 [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/)을 메모리에서 읽습니다. 일반 텍스트 WebVTT 큐에서는 타이밍 라인에 `-->`가 포함되고, 그 뒤에 캡션 라인이 이어지며, 빈 라인이 큐를 종료합니다. 이 예제는 트랙 라벨과 “café”가 포함된 각 캡션 라인을 출력합니다.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **오디오 추출**

슬라이드 전환에는 자체 사운드가 있을 수 있습니다. 이를 검색하려면 전환의 [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) 속성을 읽습니다. 이 예제는 사운드의 [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/)에 접근하고 바이트 단위 크기를 출력합니다. 첫 번째 슬라이드에 전환 사운드가 없으면 대신 메시지를 출력합니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **FAQ**

**여러 슬라이드에서 동일한 오디오 클립을 복제 없이 재사용할 수 있나요?**

예. 프레젠테이션의 [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/)에 클립을 한 번 추가하고 각 슬라이드에 대해 동일한 오디오 객체를 [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/)에 전달하면 됩니다.

**기존 오디오 프레임의 사운드를 교체할 수 있나요?**

예. 링크된 사운드의 경우, 교체 파일을 가리키도록 [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/)를 업데이트하십시오. 임베디드 사운드의 경우, 프레젠테이션의 오디오 컬렉션에서 다른 클립을 [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/)에 할당하십시오. 두 방법 모두 기존 프레임을 유지합니다.

**트리밍이 프레젠테이션에 저장된 오디오 데이터를 변경합니까?**

아니요. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/)와 [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/)는 재생 경계를 설정합니다. 여전히 [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/)에서 전체 클립을 검색할 수 있습니다.