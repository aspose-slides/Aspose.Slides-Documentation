---
title: 在 Android 上管理演示文稿中的音频帧
linktitle: 音频帧
type: docs
weight: 10
url: /zh/androidjava/audio-frame/
keywords:
- 音频
- 音频帧
- 缩略图
- 添加音频
- 音频属性
- 音频选项
- 提取音频
- Android
- Java
- Aspose.Slides
description: "在幻灯片中嵌入音频、更改音频图标、配置播放、管理 WebVTT 字幕，并使用 Aspose.Slides for Android via Java 提取幻灯片切换声音。"
---
## **概述**

音频帧允许您在幻灯片上播放声音。使用 Aspose.Slides for Android via Java，您可以嵌入音频剪辑，选择表示它的图片，调整播放，并附加字幕。您还可以检索分配给幻灯片切换的声音。

## **创建音频帧**

使用[addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-)将本地音频剪辑嵌入第一张幻灯片。前两个坐标确定帧在幻灯片上的位置，接下来的两个值设置其宽度和高度，单位为点。此示例调用[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-)自动开始播放剪辑，并调用[setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-)选择响亮的预设。

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

## **更改音频帧缩略图**

默认情况下，音频帧显示扬声器图标。要显示自定义缩略图，请使用[addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-)将图像添加到演示文稿中，然后使用[setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-)将其设置为帧的图片。示例使用 JPEG 作为嵌入音频剪辑的缩略图。

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

## **更改音频播放选项**

PowerPoint 的 **音频选项** 控件决定剪辑何时启动、音量大小以及在幻灯片放映期间的行为。

![PowerPoint 音频选项控件（用于音频帧）](audio_frame_0.png)

| PowerPoint 控件 | Aspose.Slides for Android via Java 方法 |
| --- | --- |
| 开始 | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| 音量预设 | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| 跨幻灯片播放 | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| 循环直到停止 | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| 演示期间隐藏 | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| 播放后倒回 | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| 淡入 | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| 淡出 | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| 修剪音频开始时间 | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| 修剪音频结束时间 | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| 音量滑块 | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

示例在第一张幻灯片上查找第一个音频帧，调用[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-)在点击时开始播放，并选择低音量预设。该剪辑在跨幻灯片播放时循环被禁用。图标在放映期间保持隐藏，剪辑在播放后会倒回。

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

对于时长超过 3.5 秒的剪辑，此示例跳过前 1.5 秒和后 2 秒。[setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) 用于指定要从剪辑末尾省略的时长。要获取 PowerPoint 中显示的结束时间，需要将该偏移量从完整剪辑时长中减去。裁剪后的剪辑淡入 200 毫秒，淡出 500 毫秒。所有四个方法的参数均以毫秒为单位。

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

要将播放音量设置为特定百分比，请使用[setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-)。此示例将第一张幻灯片上的第一个音频帧音量设为 85%。

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

## **管理音频字幕**

每个音频帧通过[getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--)提供对其字幕轨道的访问。使用该集合可将 WebVTT 字幕附加到剪辑、导出现有轨道或将其移除。

### **添加音频字幕**

示例在第一张幻灯片上嵌入音频剪辑，并使用[add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-)附加本地 WebVTT 轨道。第一个参数提供轨道标签，第二个参数指定包含时间字幕的文件。

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

### **提取音频字幕**

此示例导出附加在第一张幻灯片音频帧上的每个字幕轨道。它将[getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--)返回的字节写入 WebVTT 文件，并使用[getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--)返回的标识符作为文件名，以便每个轨道拥有单独的输出。

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

### **移除音频字幕**

使用[remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-)或[removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-)删除单个轨道。示例使用[clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--)从第一张幻灯片的第一个音频帧中移除所有字幕，同时保留剪辑。

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

### **在音频字幕中查找行**

要在第一张幻灯片的音频字幕中查找某行，请在内存中搜索[getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--)返回的文本。在纯文本 WebVTT 提示中，时间行包含 `-->`，字幕行随后出现，空行结束提示。此示例打印轨道标签以及包含 “café” 的每一行字幕。

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

## **提取音频**

幻灯片切换可以拥有自己的声音。要检索它，请在幻灯片切换上调用[getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--)。示例访问[getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--)返回的字节并打印字节数。如果第一张幻灯片没有切换声音，则会打印相应提示信息。

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

## **常见问题**

**我可以在多张幻灯片中重复使用同一个音频剪辑而不进行复制吗？**

可以。将剪辑一次添加到演示文稿的[audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--)中，然后在每张幻灯片上将相同的音频对象传递给[addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-)。

**我可以替换现有音频帧中的声音吗？**

可以。对于链接的声音，使用[setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-)指向替换文件。对于嵌入的声音，使用[setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-)从演示文稿的音频集合中选择另一段剪辑。两种方法都保留现有帧。

**裁剪会改变演示文稿中存储的音频数据吗？**

不会。[setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-)和[setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-)只设置播放边界。您仍然可以通过[getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--)获取完整的剪辑。