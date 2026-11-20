---
title: JavaScript를 사용한 프레젠테이션에서 오디오 프레임 관리
linktitle: 오디오 프레임
type: docs
weight: 10
url: /ko/nodejs-java/audio-frame/
keywords:
- 오디오
- 오디오 프레임
- 썸네일
- 오디오 추가
- 오디오 속성
- 오디오 옵션
- 오디오 추출
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 슬라이드에 오디오를 삽입하고, 오디오 아이콘을 변경하며, 재생을 구성하고, WebVTT 캡션을 관리하며, 슬라이드 전환 사운드를 추출합니다."
---
## **개요**

오디오 프레임을 사용하면 슬라이드에서 사운드를 재생할 수 있습니다. Aspose.Slides for Node.js via Java를 사용하면 오디오 클립을 삽입하고, 이를 나타내는 이미지를 선택하며, 재생을 조정하고 캡션을 붙일 수 있습니다. 또한 슬라이드 전환에 지정된 사운드를 가져올 수도 있습니다.

## **오디오 프레임 만들기**

첫 번째 슬라이드에 로컬 오디오 클립을 삽입하려면 [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded)를 사용합니다. 처음 두 좌표는 프레임을 슬라이드에 배치하고, 다음 두 값은 너비와 높이를 포인트 단위로 설정합니다. 이 예제는 클립을 자동으로 시작하도록 [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode)를 호출하고, 큰 사운드 사전 설정을 선택하도록 [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume)를 호출합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
        audioFrame.setPlayMode(slides.AudioPlayModePreset.Auto);
        audioFrame.setVolume(slides.AudioVolumeMode.Loud);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameEmbed_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **오디오 프레임 썸네일 변경**

기본적으로 오디오 프레임은 스피커 아이콘을 표시합니다. 사용자 지정 썸네일을 표시하려면 [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage)를 사용하여 프레젠테이션에 이미지를 추가하고, [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage)로 프레임의 그림에 설정합니다. 예제에서는 `eagle.jpeg`를 삽입된 오디오 클립의 썸네일로 사용합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        const imageStream = java.newInstanceSync("java.io.FileInputStream", "eagle.jpeg");
        try {
            const thumbnail = presentation.getImages().addImage(imageStream);
            audioFrame.getPictureFormat().getPicture().setImage(thumbnail);
        } finally {
            imageStream.close();
        }
    } finally {
        audioStream.close();
    }
    presentation.save("example_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **오디오 재생 옵션 변경**

PowerPoint의 **오디오 옵션** 컨트롤은 클립이 언제 시작되는지, 사운드가 얼마나 크게 재생되는지, 슬라이드 쇼 중에 어떻게 동작하는지를 결정합니다.

![오디오 프레임에 대한 PowerPoint 오디오 옵션 컨트롤](audio_frame_0.png)

| PowerPoint 제어 | Aspose.Slides for Node.js via Java 메서드 |
| --- | --- |
| 시작 | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| 볼륨 사전 설정 | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| 슬라이드 전체 재생 | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| 중지될 때까지 반복 | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| 쇼 중에 숨기기 | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| 재생 후 되감기 | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| 페이드 인 | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| 페이드 아웃 | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| 오디오 시작 시간 자르기 | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| 오디오 끝 시간 자르기 | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| 볼륨 슬라이더 | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

이 예제는 첫 번째 슬라이드에서 첫 번째 오디오 프레임을 찾고, 클릭 시 재생을 시작하도록 [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode)를 호출하며, 낮은 볼륨 사전 설정을 선택합니다. 클립은 루프가 비활성화된 상태에서 슬라이드 전체에 걸쳐 재생됩니다. 아이콘은 쇼 중에 숨겨지고, 재생 후 클립이 되감깁니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setPlayMode(slides.AudioPlayModePreset.OnClick);
        audioFrame.setVolume(slides.AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

길이가 3.5초를 초과하는 클립에 대해, 이 예제는 처음 1.5초와 마지막 2초를 건너뜁니다. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)는 클립 끝에서 생략할 기간을 지정합니다. PowerPoint에 표시된 종료 시간을 얻으려면 전체 클립 길이에서 해당 오프셋을 빼면 됩니다. 트리밍된 클립은 200밀리초 동안 페이드 인하고 500밀리초 동안 페이드 아웃합니다. 네 가지 메서드 모두 밀리초 단위 값을 사용합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
        audioFrame.setTrimFromStart(1500);
        audioFrame.setTrimFromEnd(2000);
        audioFrame.setFadeInDuration(200);
        audioFrame.setFadeOutDuration(500);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameTrimFade_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

재생 볼륨을 특정 퍼센트로 설정하려면 [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue)를 사용합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 오디오 프레임을 85%로 설정합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setVolumeValue(85);
        presentation.save("AudioFrameValue_out.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **오디오 캡션 관리**

각 오디오 프레임은 [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks)를 통해 캡션 트랙에 접근할 수 있습니다. 콜렉션을 사용하여 WebVTT 캡션을 클립에 첨부하고, 기존 트랙을 내보내거나 삭제할 수 있습니다.

### **오디오 캡션 추가**

예제는 첫 번째 슬라이드에 오디오 클립을 삽입하고, [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add)를 사용하여 로컬 WebVTT 트랙을 첨부합니다. 첫 번째 인자는 트랙 레이블을 제공하고, 두 번째는 타임캡션이 포함된 파일을 지정합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
        audioFrame.getCaptionTracks().add("English", "track.vtt");
    } finally {
        audioStream.close();
    }
    presentation.save("audio_with_captions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **오디오 캡션 추출**

이 예제는 첫 번째 슬라이드의 오디오 프레임에 첨부된 각 캡션 트랙을 내보냅니다. [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData)으로 반환된 바이트를 WebVTT 파일에 기록하고, [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId)으로 반환된 식별자를 파일 이름으로 사용하여 각 트랙이 별도의 출력 파일을 갖도록 합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("node:fs");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            const fileName = track.getCaptionId() + ".vtt";
            const bytes = track.getBinaryData();
            const data = Buffer.from(bytes);
            fs.writeFileSync(fileName, data);
        }
    }
} finally {
    presentation.dispose();
}
```

### **오디오 캡션 제거**

[remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) 또는 [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt)를 사용하여 개별 트랙을 삭제할 수 있습니다. 예제는 [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear)를 사용하여 첫 번째 슬라이드의 첫 번째 오디오 프레임에서 모든 캡션을 제거하면서 클립은 유지합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **오디오 캡션에서 라인 찾기**

첫 번째 슬라이드의 오디오 캡션에서 라인을 찾으려면 메모리상의 [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString)으로 반환된 텍스트를 검색합니다. 일반 텍스트 WebVTT 큐에서는 타이밍 라인에 `-->`가 포함되고, 그 뒤에 캡션 라인이 이어지며, 빈 줄이 큐의 끝을 나타냅니다. 이 예제는 트랙 레이블과 “café”가 포함된 각 캡션 라인을 출력합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            let inCue = false;
            const captions = track.getDataAsString();
            for (const line of captions.split(/\r\n|\n|\r/)) {
                if (line === "") {
                    inCue = false;
                } else if (line.includes("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase().includes("café")) {
                    console.log(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **오디오 추출**

슬라이드 전환에는 자체 사운드가 있을 수 있습니다. 이를 가져오려면 슬라이드 전환에서 [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound)를 호출합니다. 예제는 [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData)로 반환된 바이트에 접근하고 바이트 수를 출력합니다. 첫 번째 슬라이드에 전환 사운드가 없으면 대신 메시지를 출력합니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AudioSlide.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const sound = slide.getSlideShowTransition().getSound();
    if (sound) {
        const audioData = sound.getBinaryData();
        console.log("Transition sound: " + audioData.length + " bytes.");
    } else {
        console.log("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **자주 묻는 질문**

**같은 오디오 클립을 여러 슬라이드에서 중복 없이 재사용할 수 있나요?**

예. 프레젠테이션의 [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios)에 클립을 한 번 추가하고, 각 슬라이드에 대해 동일한 오디오 객체를 [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded)에 전달하면 됩니다.

**기존 오디오 프레임의 사운드를 교체할 수 있나요?**

예. 링크된 사운드인 경우 [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong)를 사용하여 교체 파일을 지정합니다. 삽입된 사운드인 경우 프레젠테이션의 오디오 컬렉션에서 다른 클립을 선택하여 [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio)으로 설정합니다. 두 방법 모두 기존 프레임을 유지합니다.

**트리밍이 프레젠테이션에 저장된 오디오 데이터를 변경합니까?**

아니요. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart)와 [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)는 재생 경계를 설정합니다. 여전히 [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio)으로 전체 클립을 가져올 수 있습니다.