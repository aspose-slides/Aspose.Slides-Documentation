---
title: 프레젠테이션에서 C++을 사용한 오디오 관리
linktitle: 오디오 프레임
type: docs
weight: 10
url: /ko/cpp/audio-frame/
keywords:
- 오디오
- 오디오 프레임
- 썸네일
- 오디오 추가
- 오디오 속성
- 오디오 옵션
- 오디오 추출
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 오디오 프레임을 만들고 제어합니다—코드 예제는 PPT, PPTX 및 ODP 프레젠테이션에 오디오를 삽입, 트리밍, 반복 및 재생 설정을 구성하는 방법을 보여줍니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 오디오 프레임을 사용하는 방법을 설명합니다. 슬라이드에 삽입된 오디오를 추가하고, 오디오 프레임 섬네일을 사용자 정의하며, 볼륨, 반복, 숨기기, 트리밍 및 페이드 지속시간과 같은 재생 옵션을 구성하고, 슬라이드 쇼 전환에 사용되는 오디오를 추출하는 방법을 보여줍니다.

## **오디오 프레임 만들기**

Aspose.Slides for C++를 사용하면 슬라이드에 오디오 파일을 추가할 수 있습니다. 오디오 파일은 슬라이드에 오디오 프레임으로 삽입됩니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. 슬라이드에 삽입하려는 오디오 파일 스트림을 로드합니다.
4. 삽입된 오디오 프레임(오디오 파일 포함)을 슬라이드에 추가합니다.
5. [IAudioFrame](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_audio_frame) 객체가 제공하는 [PlayMode](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) 및 `Volume`을 설정합니다.
6. 수정된 프레젠테이션을 저장합니다.

다음 C++ 코드는 슬라이드에 삽입된 오디오 프레임을 추가하는 방법을 보여줍니다:

``` cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
auto pres = System::MakeObject<Presentation>();

// 첫 번째 슬라이드를 가져옵니다
auto sld = pres->get_Slides()->idx_get(0);

// wav 사운드 파일을 스트림으로 로드합니다
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// 오디오 프레임을 추가합니다
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// 오디오의 재생 모드와 볼륨을 설정합니다
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// PowerPoint 파일을 디스크에 저장합니다
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **오디오 프레임 썸네일 변경**

프레젠테이션에 오디오 파일을 추가하면 오디오는 기본 표준 이미지가 있는 프레임으로 표시됩니다(아래 섹션의 이미지를 참조하세요). 오디오 프레임의 썸네일을 원하는 이미지로 변경할 수 있습니다.

다음 C++ 코드는 오디오 프레임의 썸네일 또는 미리보기 이미지를 변경하는 방법을 보여줍니다:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// 지정된 위치와 크기로 슬라이드에 오디오 프레임을 추가합니다.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// 프레젠테이션 리소스에 이미지를 추가합니다.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// 오디오 프레임의 이미지를 설정합니다.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//수정된 프레젠테이션을 디스크에 저장합니다.
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **오디오 재생 옵션 변경**

Aspose.Slides for C++를 사용하면 오디오 재생 및 속성을 제어하는 옵션을 변경할 수 있습니다. 예를 들어, 오디오 볼륨을 조정하거나, 오디오를 반복 재생하도록 설정하거나, 오디오 아이콘을 숨길 수 있습니다.

Microsoft PowerPoint의 **Audio Options** 창:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**는 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/) 메서드에 해당합니다:

- **Start** 드롭다운 목록은 [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_playmode/) 메서드와 일치합니다
- **Volume** 은 [AudioFrame::set_Volume](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_volume/) 메서드와 일치합니다
- **Play Across Slides** 은 [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_playacrossslides/) 메서드와 일치합니다
- **Loop until Stopped** 은 [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_playloopmode/) 메서드와 일치합니다
- **Hide During Show** 은 [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_hideatshowing/) 메서드와 일치합니다
- **Rewind after Playing** 은 [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_rewindaudio/) 메서드와 일치합니다

PowerPoint **Editing** 옵션은 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/) 속성에 해당합니다:

- **Fade In** 은 [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_fadeinduration/) 메서드와 일치합니다
- **Fade Out** 은 [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_fadeoutduration/) 메서드와 일치합니다
- **Trim Audio Start Time** 은 [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_trimfromstart/) 메서드와 일치합니다
- **Trim Audio End Time** 값은 오디오 전체 길이에서 [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_trimfromend/) 메서드의 값만큼 뺀 것과 같습니다

PowerPoint 오디오 컨트롤 패널의 **Volume control**은 [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_volumevalue/) 메서드에 해당합니다. 이를 통해 오디오 볼륨을 퍼센트 단위로 변경할 수 있습니다.

오디오 재생 옵션을 변경하는 방법은 다음과 같습니다:

1. [Сreate](#creating-audio-frame) 또는 Audio Frame을 가져옵니다.
2. 조정하려는 Audio Frame 속성에 새 값을 설정합니다.
3. 수정된 PowerPoint 파일을 저장합니다.

다음 C++ 코드는 오디오 옵션을 조정하는 작업을 보여줍니다:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// 모양을 가져옵니다
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// 모양을 AudioFrame 형태로 캐스팅합니다
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// 클릭 시 재생하도록 재생 모드를 설정합니다
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// 볼륨을 낮게 설정합니다
audioFrame->set_Volume(AudioVolumeMode::Low);

// 오디오를 슬라이드 전체에서 재생하도록 설정합니다
audioFrame->set_PlayAcrossSlides(true);

// 오디오의 반복을 비활성화합니다
audioFrame->set_PlayLoopMode(false);

// 슬라이드 쇼 중에 AudioFrame을 숨깁니다
audioFrame->set_HideAtShowing(true);

// 재생 후 오디오를 시작점으로 되감습니다
audioFrame->set_RewindAudio(true);

// PowerPoint 파일을 디스크에 저장합니다
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

다음 C++ 예제는 삽입된 오디오가 있는 새 오디오 프레임을 추가하고, 트리밍하며, 페이드 지속시간을 설정하는 방법을 보여줍니다:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// 트리밍 시작 오프셋을 1.5초로 설정합니다
audioFrame->set_TrimFromStart(1500);
// 트리밍 종료 오프셋을 2초로 설정합니다
audioFrame->set_TrimFromEnd(2000);

// 페이드인 지속시간을 200ms로 설정합니다
audioFrame->set_FadeInDuration(200);
// 페이드아웃 지속시간을 500ms로 설정합니다
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

다음 코드 샘플은 삽입된 오디오가 있는 오디오 프레임을 검색하고 볼륨을 85%로 설정하는 방법을 보여줍니다:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// 오디오 프레임 모양을 가져옵니다
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// 오디오 볼륨을 85%로 설정합니다
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **오디오 캡션 관리**

Aspose.Slides를 사용하면 [get_CaptionTracks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iaudioframe/get_captiontracks/) 메서드를 통해 오디오 프레임에 폐쇄 캡션을 추가할 수 있습니다. 이 메서드는 [ICaptionsCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icaptionscollection/)을 반환하며, 이를 사용해 WebVTT 캡션 트랙을 추가하고, 기존 트랙을 순회하며, 필요에 따라 제거할 수 있습니다.

### **오디오 캡션 추가**

[get_CaptionTracks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iaudioframe/get_captiontracks/) 메서드를 사용하여 오디오 프레임에 하나 이상의 캡션 트랙을 연결합니다. 다음 예제에서는 슬라이드에 오디오 파일을 추가한 후, `.vtt` 파일에서 새로운 캡션 트랙을 로드합니다.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// WebVTT 파일에서 새 캡션 트랙을 추가합니다.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Ppptx);
presentation->Dispose();
```

### **오디오 캡션 추출**

오디오 프레임에 연결된 캡션 트랙을 순회하면서 `.vtt` 파일로 저장할 수 있습니다. 각 캡션 트랙은 바이너리 데이터와 고유 식별자를 제공하며, 캡션을 내보낼 때 사용할 수 있습니다.

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
            // 각 캡션 트랙을 .vtt 파일로 저장합니다.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

### **오디오 캡션 제거**

오디오 프레임에서 캡션을 제거하려면 [ICaptionsCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icaptionscollection/)에서 제공하는 [Clear](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icaptionscollection/remove/), 또는 [RemoveAt](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icaptionscollection/removeat/) 메서드를 사용합니다. 다음 예제는 오디오 프레임의 모든 캡션 트랙을 제거합니다.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// 오디오 프레임에서 모든 캡션 트랙을 제거합니다.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **오디오 추출**

Aspose.Slides를 사용하면 슬라이드 쇼 전환에 사용된 사운드를 추출할 수 있습니다. 예를 들어 특정 슬라이드에서 사용된 사운드를 추출할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성하고 오디오가 포함된 프레젠테이션을 로드합니다.
2. 인덱스를 통해 해당 슬라이드의 참조를 가져옵니다.
3. 슬라이드의 슬라이드쇼 전환에 접근합니다.
4. 사운드를 바이트 데이터로 추출합니다.

```cpp
String presName = u"AudioSlide.pptx";

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
auto pres = System::MakeObject<Presentation>(presName);

// 원하는 슬라이드에 접근합니다
auto slide = pres->get_Slides()->idx_get(0);

// 슬라이드에 대한 슬라이드쇼 전환 효과를 가져옵니다
auto transition = slide->get_SlideShowTransition();

// 사운드를 바이트 배열로 추출합니다
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**여러 슬라이드에서 동일한 오디오 자산을 재사용하면서 파일 크기가 커지는 것을 방지할 수 있나요?**

예. 프레젠테이션의 공유 [audio collection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_audios/)에 오디오를 한 번만 추가하고, 해당 자산을 참조하는 추가 오디오 프레임을 만들면 됩니다. 이렇게 하면 미디어 데이터 복제를 방지하고 프레젠테이션 크기를 관리할 수 있습니다.

**기존 오디오 프레임의 사운드를 모양을 다시 만들지 않고 교체할 수 있나요?**

예. 연결된 사운드의 경우 [link path](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_linkpathlong/)를 새 파일을 가리키도록 업데이트합니다. 삽입된 사운드의 경우 프레젠테이션의 [audio collection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_audios/)에 있는 다른 [embedded audio](https://reference.aspose.com/slides/ko/cpp/aspose.slides/audioframe/set_embeddedaudio/) 객체와 교체합니다. 프레임의 서식 및 대부분의 재생 설정은 그대로 유지됩니다.

**트리밍을 하면 프레젠테이션에 저장된 원본 오디오 데이터가 변경되나요?**

아니요. 트리밍은 재생 범위만 조정하며, 원본 오디오 바이트는 그대로 유지되어 삽입된 오디오나 프레젠테이션의 오디오 컬렉션을 통해 접근할 수 있습니다.