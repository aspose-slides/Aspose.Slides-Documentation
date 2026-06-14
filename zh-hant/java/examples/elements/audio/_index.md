---
title: 音訊
type: docs
weight: 70
url: /zh-hant/java/examples/elements/audio/
keywords:
- 程式碼範例
- 音訊
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 的音訊範例：在 PPT、PPTX 與 ODP 簡報中插入、播放、剪輯及擷取音效，並提供清晰的 Java 程式碼示範。"
---
本文示範如何嵌入音訊框架並使用 **Aspose.Slides for Java** 控制播放。以下範例展示基本的音訊操作。

## **新增音訊框架**

插入一個空的音訊框架，稍後可容納嵌入的音訊資料。

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 建立一個空的音訊框架（音訊將稍後嵌入）。
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **存取音訊框架**

此程式碼會取得投影片上的第一個音訊框架。

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // 存取投影片上的第一個音訊框架。
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

## **移除音訊框架**

刪除先前添加的音訊框架。

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // 移除音訊框架。
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **設定音訊播放**

將音訊框架設定為在投影片出現時自動播放。

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // 投影片出現時自動播放。
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```