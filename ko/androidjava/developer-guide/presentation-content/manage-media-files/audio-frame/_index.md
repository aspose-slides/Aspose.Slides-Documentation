---
title: Android에서 프레젠테이션 오디오 관리
linktitle: 오디오 프레임
type: docs
weight: 10
url: /ko/androidjava/audio-frame/
keywords:
- 오디오
- 오디오 프레임
- 썸네일
- 오디오 추가
- 오디오 속성
- 오디오 옵션
- 오디오 추출
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android에서 오디오 프레임을 만들고 제어합니다—삽입, 트리밍, 루프 및 PPT, PPTX, ODP 프레젠테이션 전반에 걸친 재생 구성 예제(Java)."
---
## **개요**

이 문서에서는 Aspose.Slides에서 오디오 프레임을 사용하는 방법을 설명합니다. 삽입된 오디오를 슬라이드에 추가하고, 오디오 프레임 썸네일을 사용자 지정하며, 볼륨, 루프, 숨기기, 트리밍 및 페이드 지속 시간과 같은 재생 옵션을 구성하고, 슬라이드 쇼 전환에 사용되는 오디오를 추출하는 방법을 보여줍니다.

## **오디오 프레임 만들기**
Aspose.Slides for Android via Java를 사용하면 오디오 파일을 슬라이드에 추가할 수 있습니다. 오디오 파일은 오디오 프레임으로 슬라이드에 삽입됩니다.

1. 프레젠테이션 클래스([Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation))의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 삽입하려는 오디오 파일 스트림을 로드합니다.
4. 삽입된 오디오 파일을 포함하는 오디오 프레임을 슬라이드에 추가합니다.
5. [PlayMode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AudioPlayModePreset)와 [IAudioFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IAudioFrame) 객체가 제공하는 `Volume`을 설정합니다.
6. 수정된 프레젠테이션을 저장합니다.

다음 Java 코드는 슬라이드에 삽입된 오디오 프레임을 추가하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);

    // wav 사운드 파일을 스트림으로 로드합니다
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // 오디오 프레임을 추가합니다
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // 오디오의 재생 모드와 볼륨을 설정합니다
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // PowerPoint 파일을 디스크에 저장합니다
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **오디오 프레임 썸네일 변경**

프레젠테이션에 오디오 파일을 추가하면 오디오가 기본 표준 이미지가 있는 프레임으로 표시됩니다(아래 섹션의 이미지 참조). 오디오 프레임의 미리보기 이미지를 변경하여 원하는 이미지를 설정할 수 있습니다.

다음 Java 코드는 오디오 프레임의 썸네일 또는 미리보기 이미지를 변경하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 슬라이드에 지정된 위치와 크기로 오디오 프레임을 추가합니다.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // 프레젠테이션 리소스에 이미지를 추가합니다.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 오디오 프레임의 이미지를 설정합니다.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //수정된 프레젠테이션을 디스크에 저장합니다.
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **오디오 재생 옵션 변경**

Aspose.Slides for Android via Java를 사용하면 오디오 재생 또는 속성을 제어하는 옵션을 변경할 수 있습니다. 예를 들어, 오디오의 볼륨을 조정하고, 오디오를 루프 재생하도록 설정하거나, 오디오 아이콘을 숨길 수도 있습니다.

Microsoft PowerPoint의 **Audio Options** 창:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**는 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AudioFrame) 속성과 대응됩니다:

- **Start** 드롭다운 목록은 [AudioFrame.PlayMode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 속성과 일치합니다
- **Volume**은 [AudioFrame.Volume](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AudioFrame#getVolume--) 속성과 일치합니다
- **Play Across Slides**는 [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 속성과 일치합니다
- **Loop until Stopped**는 [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 속성과 일치합니다
- **Hide During Show**는 [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 속성과 일치합니다
- **Rewind after Playing**은 [AudioFrame.RewindAudio](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 속성과 일치합니다

PowerPoint **Editing** 옵션은 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/audioframe/) 속성과 대응됩니다:

- **Fade In**은 [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 속성과 일치합니다
- **Fade Out**은 [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 속성과 일치합니다
- **Trim Audio Start Time**은 [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 속성과 일치합니다
- **Trim Audio End Time** 값은 오디오 전체 길이에서 [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 속성 값만큼 뺀 값과 같습니다

PowerPoint 오디오 제어 패널의 **Volume controll**은 [AudioFrame.VolumeValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) 속성과 대응됩니다. 이를 통해 오디오 볼륨을 백분율로 변경할 수 있습니다.

오디오 재생 옵션을 변경하는 방법은 다음과 같습니다:

1. [Create](#create-audio-frame) 또는 오디오 프레임을 가져옵니다.
2. 조정하려는 오디오 프레임 속성에 대한 새 값을 설정합니다.
3. 수정된 PowerPoint 파일을 저장합니다.

다음 Java 코드는 오디오 옵션을 조정하는 작업을 보여줍니다:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame 모양을 가져옵니다
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 클릭 시 재생하도록 재생 모드를 설정합니다
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // 볼륨을 Low(낮음)으로 설정합니다
    audioFrame.setVolume(AudioVolumeMode.Low);

    // 오디오를 슬라이드 전반에 걸쳐 재생하도록 설정합니다
    audioFrame.setPlayAcrossSlides(true);

    // 오디오에 대한 루프를 비활성화합니다
    audioFrame.setPlayLoopMode(false);

    // 슬라이드 쇼 중에 AudioFrame을 숨깁니다
    audioFrame.setHideAtShowing(true);

    // 재생 후 오디오를 시작 위치로 되감습니다
    audioFrame.setRewindAudio(true);

    // PowerPoint 파일을 디스크에 저장합니다
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

다음 Java 예제는 삽입된 오디오가 있는 새 오디오 프레임을 추가하고, 트리밍하며, 페이드 지속 시간을 설정하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // 트리밍 시작 오프셋을 1.5초로 설정합니다
    // 트리밍 종료 오프셋을 2초로 설정합니다
    // 페이드 인 지속 시간을 200ms로 설정합니다
    // 페이드 아웃 지속 시간을 500ms로 설정합니다

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

다음 코드 샘플은 삽입된 오디오가 있는 오디오 프레임을 가져와 볼륨을 85%로 설정하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // 오디오 프레임 모양을 가져옵니다
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // 오디오 볼륨을 85%로 설정합니다
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **오디오 캡션 관리**

Aspose.Slides를 사용하면 [getCaptionTracks](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) 메서드를 통해 오디오 프레임에 폐쇄 캡션을 추가할 수 있습니다. 이 메서드는 [ICaptionsCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icaptionscollection/)을 반환하며, 이를 사용하여 WebVTT 캡션 트랙을 추가하고, 기존 트랙을 반복하며, 필요에 따라 제거할 수 있습니다.

**오디오 캡션 추가**

[getCaptionTracks](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) 메서드를 사용하여 하나 이상의 캡션 트랙을 오디오 프레임에 연결합니다. 다음 예제에서는 슬라이드에 오디오 파일을 추가한 후, 새 캡션 트랙을 `.vtt` 파일에서 로드합니다.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // WebVTT 파일에서 새 캡션 트랙을 추가합니다.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**오디오 캡션 추출**

오디오 프레임에 연결된 캡션 트랙을 반복하여 `.vtt` 파일로 저장할 수 있습니다. 각 캡션 트랙은 이진 데이터와 고유 식별자를 제공하며, 캡션을 내보낼 때 사용할 수 있습니다.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // 캡션 트랙을 .vtt 파일로 저장합니다.
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**오디오 캡션 제거**

오디오 프레임에서 캡션을 제거하려면 [ICaptionsCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icaptionscollection/)에서 제공하는 메서드인 [clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), [removeAt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) 등을 사용합니다. 다음 예제는 오디오 프레임에서 모든 캡션 트랙을 제거합니다.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // 오디오 프레임에서 모든 캡션 트랙을 제거합니다.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **오디오 추출**

Aspose.Slides for Android via Java를 사용하면 슬라이드 쇼 전환에 사용된 사운드를 추출할 수 있습니다. 예를 들어, 특정 슬라이드에 사용된 사운드를 추출할 수 있습니다.

1. 오디오가 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 해당 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 대한 [slideshow transitions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--)에 접근합니다.
4. 바이트 데이터로 사운드를 추출합니다.

다음 Java 코드는 슬라이드에 사용된 오디오를 추출하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 원하는 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 슬라이드에 대한 슬라이드쇼 전환 효과를 가져옵니다
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //사운드를 바이트 배열로 추출합니다
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**여러 슬라이드에서 동일한 오디오 자산을 파일 크기 증가 없이 재사용할 수 있나요?**

예. 오디오를 프레젠테이션의 공유 [audio collection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getAudios--)에 한 번만 추가하고, 해당 기존 자산을 참조하는 추가 오디오 프레임을 생성합니다. 이렇게 하면 미디어 데이터 복제를 방지하고 프레젠테이션 크기를 관리할 수 있습니다.

**기존 오디오 프레임의 사운드를 모양을 다시 만들지 않고 교체할 수 있나요?**

예. 연결된 사운드의 경우, [link path](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-)를 새 파일을 가리키도록 업데이트합니다. 삽입된 사운드의 경우, 프레젠테이션의 [audio collection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getAudios--)에 있는 다른 [embedded audio](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) 객체와 교체합니다. 프레임의 형식 및 대부분의 재생 설정은 그대로 유지됩니다.

**트리밍이 프레젠테이션에 저장된 기본 오디오 데이터를 변경하나요?**

아니요. 트리밍은 재생 경계만 조정합니다. 원본 오디오 바이트는 변경되지 않으며, 삽입된 오디오 또는 프레젠테이션의 오디오 컬렉션을 통해 계속 액세스할 수 있습니다.