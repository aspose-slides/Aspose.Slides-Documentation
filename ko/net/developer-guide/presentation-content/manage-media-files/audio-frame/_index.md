---
title: .NET에서 프레젠테이션의 오디오 프레임 관리
linktitle: 오디오 프레임
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
description: "Aspose.Slides for .NET에서 오디오 프레임을 생성하고 제어합니다—C# 예제를 통해 삽입, 트리밍, 반복 및 PPT, PPTX, ODP 프레젠테이션 전반에 걸친 재생 구성을 수행합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 오디오 프레임을 사용하는 방법을 설명합니다. 슬라이드에 임베드된 오디오를 추가하고, 오디오 프레임 썸네일을 사용자 지정하며, 볼륨, 반복, 숨김, 트리밍 및 페이드 지속 시간과 같은 재생 옵션을 구성하고, 슬라이드 쇼 전환에 사용된 오디오를 추출하는 방법을 보여줍니다.

## **오디오 프레임 만들기**

Aspose.Slides for .NET을 사용하면 슬라이드에 오디오 파일을 추가할 수 있습니다. 오디오 파일은 오디오 프레임으로 슬라이드에 임베드됩니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. 슬라이드에 임베드하려는 오디오 파일 스트림을 로드합니다.  
4. 임베드된 오디오 프레임(오디오 파일 포함)을 슬라이드에 추가합니다.  
5. [IAudioFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe) 객체가 노출하는 `PlayMode`와 `Volume`을 설정합니다.  
6. 수정된 프레젠테이션을 저장합니다.

다음 C# 코드는 슬라이드에 임베드된 오디오 프레임을 추가하는 방법을 보여줍니다.

```c#
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.Slides[0];
    
    // wav 사운드 파일을 스트림으로 로드합니다
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // 오디오 프레임을 추가합니다
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // 오디오의 재생 모드와 볼륨을 설정합니다
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // PowerPoint 파일을 디스크에 저장합니다
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **오디오 프레임 썸네일 변경**

프레젠테이션에 오디오 파일을 추가하면 기본 이미지가 적용된 프레임으로 표시됩니다(아래 섹션의 이미지 참조). 오디오 프레임의 썸네일을 원하는 이미지로 바꿀 수 있습니다.

다음 C# 코드는 오디오 프레임의 썸네일 또는 미리보기 이미지를 변경하는 방법을 보여줍니다.

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // 지정된 위치와 크기로 슬라이드에 오디오 프레임을 추가합니다.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // 프레젠테이션 리소스에 이미지를 추가합니다.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // 오디오 프레임의 이미지를 설정합니다.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	// 수정된 프레젠테이션을 디스크에 저장합니다
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **오디오 재생 옵션 변경**

Aspose.Slides for .NET을 사용하면 오디오의 재생 방식이나 속성을 제어하는 옵션을 변경할 수 있습니다. 예를 들어 오디오 볼륨을 조절하고, 반복 재생을 설정하거나, 오디오 아이콘을 숨길 수 있습니다.

Microsoft PowerPoint의 **오디오 옵션** 창:

![example1_image](audio_frame_0.png)

PowerPoint **오디오 옵션**이 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe) 속성과 대응되는 관계:

- **Start** 드롭다운 메뉴는 [AudioFrame.PlayMode](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe/properties/playmode) 속성과 일치합니다.  
- **Volume**은 [AudioFrame.Volume](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe/properties/volume) 속성과 일치합니다.  
- **Play Across Slides**는 [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe/properties/playacrossslides) 속성과 일치합니다.  
- **Loop until Stopped**는 [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe/properties/playloopmode) 속성과 일치합니다.  
- **Hide During Show**는 [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe/properties/hideatshowing) 속성과 일치합니다.  
- **Rewind after Playing**는 [AudioFrame.RewindAudio](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe/properties/rewindaudio) 속성과 일치합니다.  

PowerPoint **편집** 옵션이 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe) 속성과 대응되는 관계:

- **Fade In**은 [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe/fadeinduration/) 속성과 일치합니다.  
- **Fade Out**은 [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe/fadeoutduration/) 속성과 일치합니다.  
- **Trim Audio Start Time**은 [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe/trimfromstart/) 속성과 일치합니다.  
- **Trim Audio End Time** 값은 오디오 전체 길이에서 [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe/trimfromend/) 속성 값을 뺀 값과 같습니다.  

오디오 컨트롤 패널의 **볼륨 컨트롤**은 [AudioFrame.VolumeValue](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe/volumevalue/) 속성과 대응되며, 백분율로 오디오 볼륨을 조정할 수 있습니다.

오디오 재생 옵션을 변경하는 방법:

1. [Create](#create-audio-frame) 혹은 기존 오디오 프레임을 가져옵니다.  
2. 변경하려는 오디오 프레임 속성에 새 값을 설정합니다.  
3. 수정된 PowerPoint 파일을 저장합니다.  

다음 C# 코드는 오디오 옵션을 조정하는 작업을 보여줍니다.

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // AudioFrame 모양을 가져옵니다
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // 재생 모드를 클릭 시 재생하도록 설정합니다
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // 볼륨을 Low(낮게)로 설정합니다
    audioFrame.Volume = AudioVolumeMode.Low;

    // 오디오를 슬라이드 전체에 걸쳐 재생하도록 설정합니다
    audioFrame.PlayAcrossSlides = true;

    // 오디오의 반복을 비활성화합니다
    audioFrame.PlayLoopMode = false;

    // 슬라이드 쇼 중에 AudioFrame을 숨깁니다
    audioFrame.HideAtShowing = true;

    // 재생 후 오디오를 시작으로 되감습니다
    audioFrame.RewindAudio = true;

    // PowerPoint 파일을 디스크에 저장합니다
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

다음 C# 예제는 임베드된 오디오가 포함된 새 오디오 프레임을 추가하고, 트리밍 및 페이드 지속 시간을 설정하는 방법을 보여줍니다.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // 트리밍 시작 오프셋을 1.5초로 설정합니다
    audioFrame.TrimFromStart = 1500f;
    // 트리밍 종료 오프셋을 2초로 설정합니다
    audioFrame.TrimFromEnd = 2000f;

    // 페이드 인 지속 시간을 200ms로 설정합니다
    audioFrame.FadeInDuration = 200f;
    // 페이드 아웃 지속 시간을 500ms로 설정합니다
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

다음 코드 샘플은 임베드된 오디오가 포함된 오디오 프레임을 가져와 볼륨을 85%로 설정하는 방법을 보여줍니다.

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // 오디오 프레임 모양을 가져옵니다
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // 오디오 볼륨을 85%로 설정합니다
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **오디오 캡션 관리**

Aspose.Slides를 사용하면 [CaptionTracks](https://reference.aspose.com/slides/ko/net/aspose.slides/iaudioframe/captiontracks/) 속성을 통해 오디오 프레임에 폐쇄 캡션을 추가할 수 있습니다. 이 속성은 [ICaptionsCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/icaptionscollection/)을 반환하며, WebVTT 캡션 트랙을 추가하고, 기존 트랙을 열거하며, 필요 시 제거할 수 있습니다.

**오디오 캡션 추가**

[CaptionTracks](https://reference.aspose.com/slides/ko/net/aspose.slides/iaudioframe/captiontracks/) 속성을 사용하여 하나 이상의 캡션 트랙을 오디오 프레임에 연결합니다. 아래 예제에서는 슬라이드에 오디오 파일을 추가한 뒤, `.vtt` 파일에서 새로운 캡션 트랙을 로드합니다.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // WebVTT 파일에서 새로운 캡션 트랙을 추가합니다.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**오디오 캡션 추출**

오디오 프레임에 연결된 캡션 트랙을 순회하면서 `.vtt` 파일로 저장할 수 있습니다. 각 캡션 트랙은 바이너리 데이터와 고유 식별자를 제공하며, 캡션을 내보낼 때 사용할 수 있습니다.

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
                // 캡션 트랙을 .vtt 파일로 저장합니다.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**오디오 캡션 제거**

오디오 프레임에서 캡션을 제거하려면 [ICaptionsCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/icaptionscollection/)에서 제공하는 메서드([Clear](https://reference.aspose.com/slides/ko/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/ko/net/aspose.slides/icaptionscollection/remove/), [RemoveAt](https://reference.aspose.com/slides/ko/net/aspose.slides/icaptionscollection/removeat/))를 사용합니다. 다음 예제는 오디오 프레임에서 모든 캡션 트랙을 제거합니다.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // 오디오 프레임에서 모든 캡션 트랙을 제거합니다.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **오디오 추출**
Aspose.Slides for .NET을 사용하면 슬라이드 쇼 전환에 사용된 사운드를 추출할 수 있습니다. 예를 들어 특정 슬라이드에 사용된 사운드를 추출할 수 있습니다.

1. 오디오가 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 인스턴스를 생성합니다.  
2. 인덱스를 통해 해당 슬라이드의 참조를 가져옵니다.  
3. 슬라이드의 슬라이드쇼 전환을 액세스합니다.  
4. 사운드를 바이트 데이터로 추출합니다.  

다음 C# 코드는 슬라이드에 사용된 오디오를 추출하는 방법을 보여줍니다.

```c#
string presName = "AudioSlide.pptx";

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation(presName);

// Accesses the slide
ISlide slide = pres.Slides[0];

// Gets the slideshow transition effects for the slide
ISlideShowTransition transition = slide.SlideShowTransition;

//Extracts the sound in byte array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**여러 슬라이드에서 동일한 오디오 리소스를 재사용하면서 파일 크기가 증가하지 않나요?**

예. 프레젠테이션의 공유 [audio collection](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/audios/)에 오디오를 한 번 추가하고, 해당 자산을 참조하는 추가 오디오 프레임을 생성하면 미디어 데이터가 중복되지 않아 프레젠테이션 크기를 제어할 수 있습니다.

**기존 오디오 프레임의 모양을 다시 만들지 않고 사운드를 교체할 수 있나요?**

예. 링크된 사운드인 경우 [link path](https://reference.aspose.com/slides/ko/net/aspose.slides/audioframe/linkpathlong/)를 새 파일을 가리키도록 업데이트합니다. 임베드된 사운드인 경우 프레젠테이션의 [audio collection](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/audios/)에 있는 다른 임베드 오디오 객체로 교체하면 됩니다. 프레임 서식과 대부분의 재생 설정은 그대로 유지됩니다.

**트리밍이 프레젠테이션에 저장된 기존 오디오 데이터 자체를 변경하나요?**

아니요. 트리밍은 재생 구간만 조정할 뿐이며, 원본 오디오 바이트는 변경되지 않고 임베드된 오디오나 프레젠테이션의 오디오 컬렉션을 통해 그대로 접근할 수 있습니다.