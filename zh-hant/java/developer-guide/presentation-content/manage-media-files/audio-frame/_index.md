---
title: 使用 Java 管理簡報中的音訊框
linktitle: 音訊框
type: docs
weight: 10
url: /zh-hant/java/audio-frame/
keywords:
- 音訊
- 音訊框
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 擷取音訊
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在投影片中嵌入音訊、變更音訊圖示、設定播放方式、管理 WebVTT 字幕，並擷取投影片轉場聲音。"
---
## **概述**

音訊框允許您在投影片上播放聲音。使用 Aspose.Slides for Java，您可以嵌入音訊剪輯、選擇代表它的圖片、調整播放設定，並加入字幕。您也可以擷取指派給投影片轉場的聲音。

## **建立音訊框**

使用[addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-)在第一張投影片上嵌入本機音訊剪輯。前兩個座標定位框在投影片上的位置，接下來的兩個值設定其寬度與高度，單位皆為點。此範例呼叫[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-)以自動開始剪輯，並呼叫[setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-)選擇大聲預設。

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

## **變更音訊框縮圖**

預設情況下，音訊框顯示揚聲器圖示。若要顯示自訂縮圖，請使用[addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-)將圖像新增至簡報，並以[setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-)設定於框的圖片上。此範例使用 JPEG 作為嵌入音訊剪輯的縮圖。

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

## **變更音訊播放選項**

PowerPoint 的 **Audio Options** 控制項決定剪輯何時開始、音量大小以及在投影片播放期間的行為。

![PowerPoint 音訊選項控制項（音訊框）](audio_frame_0.png)

| PowerPoint 控制項 | Aspose.Slides for Java 方法 |
| --- | --- |
| 開始 | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| 音量預設 | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| 跨投影片播放 | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| 持續循環直到停止 | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| 播放時隱藏 | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| 播放後倒帶 | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| 淡入 | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| 淡出 | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| 修剪音訊開始時間 | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| 修剪音訊結束時間 | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| 音量滑桿 | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

此範例在第一張投影片上尋找第一個音訊框，呼叫[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-)以點擊時開始播放，並選擇低音量預設。剪輯在跨投影片播放時保持循環關閉。圖示在播放時保持隱藏，且剪輯在播放完畢後倒帶。

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

對於長於 3.5 秒的剪輯，此範例跳過前 1.5 秒與最後 2 秒。[setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-)接受要從結尾省略的持續時間。若要取得 PowerPoint 中顯示的結束時間，請將該偏移值從完整剪輯長度中減去。修剪後的剪輯在 200 毫秒內淡入，於 500 毫秒內淡出。所有四個方法皆以毫秒為單位。

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

若要將播放音量設定為特定百分比，請使用[setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-)。此範例將第一張投影片上第一個音訊框的音量設為 85%。

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

## **管理音訊字幕**

每個音訊框皆可透過[getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--)存取其字幕軌道。使用此集合可將 WebVTT 字幕附加至剪輯、匯出現有軌道或移除它們。

### **新增音訊字幕**

此範例在第一張投影片嵌入音訊剪輯，並使用[add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-)附加本機 WebVTT 軌道。第一個參數提供軌道標籤，第二個參數指定包含計時字幕的檔案。

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

### **擷取音訊字幕**

此範例匯出第一張投影片上音訊框所附加的每個字幕軌道。它將[getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--)回傳的位元組寫入 WebVTT 檔案，並以[getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--)回傳的識別碼作為檔名，使每條軌道產生獨立的輸出。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            Path output = Paths.get(track.getCaptionId() + ".vtt");
            Files.write(output, track.getBinaryData());
        }
    }
} finally {
    presentation.dispose();
}
```

### **移除音訊字幕**

使用[remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-)或[removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-)刪除單一軌道。此範例使用[clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--)移除第一張投影片上第一個音訊框的所有字幕，同時保留剪輯本身。

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

### **在音訊字幕中尋找行**

要在第一張投影片的音訊字幕中尋找特定行，請在記憶體中搜尋[getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--)回傳的文字。於純文字 WebVTT 提示中，計時行包含 `-->`，字幕行緊隨其後，空白行結束此提示。此範例印出軌道標籤與所有包含「café」的字幕行。

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
            for (String line : captions.split("\\R")) {
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

## **擷取音訊**

投影片轉場可擁有自己的聲音。若要擷取，請在轉場上呼叫[getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--)。此範例存取[getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--)回傳的位元組，並列印位元組數量。如果第一張投影片沒有轉場聲音，則印出相應訊息。

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

## **常見問題**

**我可以在多張投影片間重複使用相同的音訊剪輯而不必複製它嗎？**

可以。將剪輯一次加入簡報的[audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--)，然後在每張投影片使用相同的音訊物件呼叫[addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-)。

**我可以替換既有音訊框中的聲音嗎？**

可以。對於連結音訊，使用[setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-)指向替換檔案。對於嵌入音訊，使用[setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-)從簡報的音訊集合中選取另一段剪輯。兩種方式皆會保留原有框架。

**修剪會改變簡報中儲存的音訊資料嗎？**

不會。[setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-)與[setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-)僅設定播放邊界。仍可透過[getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--)取得完整剪輯。