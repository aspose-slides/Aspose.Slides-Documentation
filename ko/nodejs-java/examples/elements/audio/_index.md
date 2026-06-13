---
title: 오디오
type: docs
weight: 70
url: /ko/nodejs-java/examples/elements/audio/
keywords:
- 코드 예제
- 오디오
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js 오디오 예제를 확인하세요: PPT, PPTX 및 ODP 프레젠테이션에서 사운드를 삽입, 재생, 잘라내기 및 추출하는 방법을 명확한 JavaScript 코드와 함께 제공합니다."
---
이 문서는 **Aspose.Slides for Node.js via Java**를 사용하여 오디오 프레임을 삽입하고 재생을 제어하는 방법을 보여줍니다. 다음 예제에서는 기본 오디오 작업을 시연합니다.

## **Add an Audio Frame**
아래 코드 예제는 프레젠테이션 슬라이드에 오디오 프레임을 추가합니다.

```js
function addAudio() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let audioData = java.newInstanceSync(
            "java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));

        let audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioData);

        presentation.save("audio.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access an Audio Frame**
이 코드는 슬라이드에서 첫 번째 오디오 프레임을 가져옵니다.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 슬라이드에서 첫 번째 오디오 프레임에 접근합니다.
        let firstAudio = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAudioFrame")) {
                firstAudio = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove an Audio Frame**
이전에 추가된 오디오 프레임을 삭제합니다.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 도형이 오디오 프레임이라고 가정합니다.
        let audioFrame = slide.getShapes().get_Item(0);

        // 오디오 프레임을 제거합니다.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Audio Playback**
슬라이드가 표시될 때 오디오 프레임이 자동으로 재생되도록 설정합니다.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 도형이 오디오 프레임이라고 가정합니다.
        let audioFrame = slide.getShapes().get_Item(0);

        // 슬라이드가 표시될 때 자동으로 재생합니다.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```