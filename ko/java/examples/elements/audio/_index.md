---
title: 오디오
type: docs
weight: 70
url: /ko/java/examples/elements/audio/
keywords:
- 코드 예제
- 오디오
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "명확한 Java 코드를 사용하여 PPT, PPTX 및 ODP 프레젠테이션에서 사운드를 삽입, 재생, 트림 및 추출하는 Aspose.Slides for Java 오디오 예제를 확인하세요."
---
이 문서는 **Aspose.Slides for Java**를 사용하여 오디오 프레임을 삽입하고 재생을 제어하는 방법을 보여줍니다. 다음 예제에서는 기본 오디오 작업을 보여줍니다.

## **오디오 프레임 추가**

나중에 삽입된 사운드 데이터를 담을 수 있는 빈 오디오 프레임을 삽입합니다.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 빈 오디오 프레임을 생성합니다 (오디오는 나중에 삽입됩니다).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **오디오 프레임 접근**

이 코드는 슬라이드에서 첫 번째 오디오 프레임을 검색합니다.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // 슬라이드에서 첫 번째 오디오 프레임에 접근합니다.
        IAudioFrame firstAudio = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAudioFrame) {
                firstAudio = (IAudioFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **오디오 프레임 제거**

이전에 추가된 오디오 프레임을 삭제합니다.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // 오디오 프레임을 제거합니다.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **오디오 재생 설정**

슬라이드가 표시될 때 오디오 프레임이 자동으로 재생되도록 구성합니다.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // 슬라이드가 나타날 때 자동으로 재생됩니다.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```