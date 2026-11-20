---
title: Android에서 프레젠테이션의 오디오 프레임 관리
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
- 안드로이드
- Java
- Aspose.Slides
description: "슬라이드에 오디오를 삽입하고, 오디오 아이콘을 변경하며, 재생을 구성하고, WebVTT 캡션을 관리하며, Aspose.Slides for Android via Java를 사용하여 슬라이드 전환 사운드를 추출합니다."
---
## **개요**

오디오 프레임을 사용하면 슬라이드에서 사운드를 재생할 수 있습니다. Aspose.Slides for Android via Java를 사용하면 오디오 클립을 삽입하고, 이를 나타내는 이미지를 선택하고, 재생을 조정하며 캡션을 첨부할 수 있습니다. 또한 슬라이드 전환에 지정된 사운드를 검색할 수도 있습니다.

## **오디오 프레임 만들기**

첫 번째 슬라이드에 로컬 오디오 클립을 삽입하려면 [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-)을(를) 사용합니다. 처음 두 좌표는 프레임을 슬라이드에 배치하고, 다음 두 값은 너비와 높이를 포인트 단위로 설정합니다. 이 예제는 [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-)을 호출하여 클립을 자동으로 시작하고, [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-)을 호출하여 높은 볼륨 사전 설정을 선택합니다.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **오디오 프레임 썸네일 변경**

기본적으로 오디오 프레임은 스피커 아이콘을 표시합니다. 사용자 정의 썸네일을 표시하려면 [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-)를 사용하여 프레젠테이션에 이미지를 추가하고, [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-)를 사용해 프레임의 그림에 설정합니다. 예제에서는 JPEG를 삽입된 오디오 클립의 썸네일로 사용합니다.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **오디오 재생 옵션 변경**

PowerPoint의 **오디오 옵션** 컨트롤은 클립이 언제 시작되는지, 소리 크기가 어떻게 되는지, 슬라이드 쇼 동안 어떻게 동작하는지를 결정합니다.

![오디오 프레임에 대한 PowerPoint 오디오 옵션 컨트롤](audio_frame_0.png)

| PowerPoint 컨트롤 | Aspose.Slides for Android via Java 메서드 |
| --- | --- |
| 시작 | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| 볼륨 사전 설정 | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| 슬라이드 전체 재생 | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| 중지될 때까지 반복 | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| 쇼 중 숨김 | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| 재생 후 되감기 | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| 페이드 인 | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| 페이드 아웃 | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| 오디오 시작 시간 잘라내기 | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| 오디오 종료 시간 잘라내기 | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| 볼륨 슬라이더 | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

예제는 첫 번째 슬라이드의 첫 번째 오디오 프레임을 찾고, 클릭 시 재생을 시작하도록 [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-)을 호출하며 낮은 볼륨 사전 설정을 선택합니다. 루프를 비활성화한 상태에서 클립은 슬라이드 전체에 걸쳐 재생됩니다. 아이콘은 쇼 중에 숨겨지고, 클립은 재생 후 되감깁니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

길이가 3.5초를 초과하는 클립에 대해, 이 예제는 처음 1.5초와 마지막 2초를 건너뜁니다. [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-)은 클립 끝에서 제외할 지속 시간을 지정합니다. PowerPoint에 표시된 종료 시간을 얻으려면 전체 클립 길이에서 해당 오프셋을 빼면 됩니다. 잘린 클립은 200밀리초에 걸쳐 페이드 인되고 500밀리초에 걸쳐 페이드 아웃됩니다. 네 메서드 모두 밀리초 단위 값을 사용합니다.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

재생 볼륨을 특정 퍼센트로 설정하려면 [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-)를 사용합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 오디오 프레임을 85%로 설정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **오디오 캡션 관리**

각 오디오 프레임은 [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks-- )을 통해 캡션 트랙에 접근할 수 있습니다. 컬렉션을 사용해 클립에 WebVTT 캡션을 첨부하거나 기존 트랙을 내보내거나 제거할 수 있습니다.

### **오디오 캡션 추가**

예제는 첫 번째 슬라이드에 오디오 클립을 삽입하고 [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-)를 사용해 로컬 WebVTT 트랙을 첨부합니다. 첫 번째 인자는 트랙 라벨을 제공하고, 두 번째 인자는 타임캡션이 포함된 파일을 지정합니다.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **오디오 캡션 추출**

이 예제는 첫 번째 슬라이드의 오디오 프레임에 첨부된 각 캡션 트랙을 내보냅니다. [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--)가 반환한 바이트를 WebVTT 파일에 기록하고, [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--)가 반환한 식별자를 파일 이름으로 사용하여 각 트랙이 별도의 출력 파일을 갖도록 합니다.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            try (FileOutputStream output = new FileOutputStream(track.getCaptionId() + ".vtt")) {
                output.write(track.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **오디오 캡션 제거**

[remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) 또는 [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-)를 사용해 개별 트랙을 삭제합니다. 예제는 [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--)를 사용해 클립을 유지하면서 첫 번째 슬라이드의 첫 번째 오디오 프레임에서 모든 캡션을 제거합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **오디오 캡션에서 라인 찾기**

첫 번째 슬라이드의 오디오 캡션에서 라인을 찾으려면 메모리에서 [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--)이 반환한 텍스트를 검색합니다. 일반 텍스트 WebVTT 큐에서는 타이밍 라인이 `-->`를 포함하고, 그 뒤에 캡션 라인이 있으며, 빈 라인이 큐를 종료합니다. 이 예제는 트랙 라벨과 “café”가 포함된 각 캡션 라인을 출력합니다.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\r\\n|\\r|\\n")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **오디오 추출**

슬라이드 전환에는 자체 사운드가 있을 수 있습니다. 이를 가져오려면 슬라이드 전환에서 [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--)을 호출합니다. 예제는 [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--)가 반환한 바이트에 접근하고 바이트 수를 출력합니다. 첫 번째 슬라이드에 전환 사운드가 없으면 대신 메시지를 출력합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**여러 슬라이드에서 동일한 오디오 클립을 복제하지 않고 재사용할 수 있나요?**

예. 프레젠테이션의 [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--)에 클립을 한 번 추가하고 각 슬라이드에 대해 동일한 오디오 객체를 [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-)에 전달합니다.

**기존 오디오 프레임의 사운드를 교체할 수 있나요?**

예. 연결된 사운드의 경우, 교체 파일을 지정하려면 [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-)을 사용합니다. 삽입된 사운드의 경우, 프레젠테이션의 오디오 컬렉션에서 다른 클립을 선택하고 [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-)을 사용합니다. 두 방법 모두 기존 프레임을 유지합니다.

**오디오 트리밍이 프레젠테이션에 저장된 오디오 데이터를 변경합니까?**

아니요. [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) 및 [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-)은 재생 범위를 설정합니다. 전체 클립은 여전히 [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--)을 통해 가져올 수 있습니다.