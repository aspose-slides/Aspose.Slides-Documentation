---
title: "จัดการ Audio Frame ในงานนำเสนอโดยใช้ Java"
linktitle: "เฟรมเสียง"
type: docs
weight: 10
url: /th/java/audio-frame/
keywords:
- เสียง
- เฟรมเสียง
- รูปย่อ
- เพิ่มเสียง
- คุณสมบัติเสียง
- ตัวเลือกเสียง
- แยกเสียง
- Java
- Aspose.Slides
description: "ฝังเสียงในสไลด์ เปลี่ยนไอคอนเสียง กำหนดค่าการเล่น จัดการคำบรรยาย WebVTT และแยกเสียงการเปลี่ยนสไลด์ด้วย Aspose.Slides for Java."
---
## **ภาพรวม**

Audio frame ทำให้คุณสามารถเล่นเสียงบนสไลด์ได้ ด้วย Aspose.Slides for Java คุณสามารถฝังคลิปเสียง เลือกภาพที่แสดงถึงมัน ปรับการเล่น และแนบคำบรรยาย คุณยังสามารถดึงเสียงที่กำหนดให้กับการเปลี่ยนสไลด์ได้

## **สร้าง Audio Frame**

ใช้ [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) เพื่ฝังคลิปเสียงในเครื่องบนสไลด์แรก พิกัดสองค่าแรกกำหนดตำแหน่งของเฟรมบนสไลด์ และสองค่าถัดไปกำหนดความกว้างและความสูงทั้งหมดเป็นหน่วย point ตัวอย่างนี้เรียก [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) เพื่อเริ่มคลิปโดยอัตโนมัติและเรียก [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) เพื่อเลือกพรีเซ็ตระดับเสียงสูง

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

## **เปลี่ยน Thumbnail ของ Audio Frame**

โดยค่าเริ่มต้น Audio Frame จะแสดงไอคอนลำโพง เพื่อแสดง Thumbnail ที่กำหนดเอง ให้เพิ่มรูปภาพลงในงานนำเสนอด้วย [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) แล้วตั้งค่าให้กับรูปของเฟรมด้วย [setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). ตัวอย่างนี้ใช้ไฟล์ JPEG เป็น Thumbnail สำหรับคลิปเสียงที่ฝัง

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

## **เปลี่ยนตัวเลือกการเล่น Audio**

PowerPoint’s **Audio Options** controls determine when a clip starts, how loud it sounds, and how it behaves during a slide show.

![การควบคุม Audio Options ของ PowerPoint สำหรับ Audio Frame](audio_frame_0.png)

| การควบคุม PowerPoint | วิธีการของ Aspose.Slides for Java |
| --- | --- |
| เริ่ม | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| พรีเซ็ตระดับเสียง | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| เล่นตลอดสไลด์ | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| เล่นวนจนหยุด | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| ซ่อนระหว่างการแสดง | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| รีไวด์หลังการเล่น | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| ค่อยๆ ปรากฏ | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| ค่อยๆ หาย | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| ตัดเวลาเริ่มต้นของ Audio | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| ตัดเวลาเริ่มสุดของ Audio | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| ตัวปรับระดับเสียง | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

ตัวอย่างนี้ค้นหา Audio Frame ตัวแรกบนสไลด์แรก เรียก [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) เพื่อเริ่มการเล่นเมื่อคลิก และเลือกพรีเซ็ตระดับเสียงต่ำ คลิปจะดำเนินต่อไปตลอดสไลด์โดยปิดการวนลูป ไอคอนจะถูกซ่อนระหว่างการแสดง และคลิปจะรีไวด์หลังการเล่น

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

สำหรับคลิปที่ยาวกว่า 3.5 วินาที ตัวอย่างนี้ข้าม 1.5 วินาทีแรกและ 2 วินาทีสุดท้าย [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) รับระยะเวลาที่ต้องตัดออกจากส่วนท้ายของคลิป เพื่อหาค่าเวลาสิ้นสุดที่แสดงใน PowerPoint ให้ลบค่าต่างจากระยะเวลาคลิปเต็ม คลิปที่ถูกตัดจะค่อยปรากฏในช่วง 200 มิลลิวินาทีและค่อยหายใน 500 มิลลิวินาที วิธีทั้งหมดสี่วิธีรับค่าเป็นมิลลิวินาที

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

เพื่อกำหนดระดับเสียงการเล่นเป็นเปอร์เซ็นต์เฉพาะ ให้ใช้ [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-). ตัวอย่างนี้ตั้งค่าเสียงของ Audio Frame ตัวแรกบนสไลด์แรกเป็น 85%

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

## **จัดการคำบรรยาย Audio**

Audio Frame แต่ละตัวให้เข้าถึงแทร็กคำบรรยายผ่าน [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). ใช้คอลเลกชันนี้เพื่อแนบคำบรรยาย WebVTT ให้กับคลิป ส่งออกแทร็กที่มีอยู่ หรือเอาออก

### **เพิ่มคำบรรยาย Audio**

ตัวอย่างนี้ฝังคลิปเสียงบนสไลด์แรกและใช้ [add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) เพื่แนบแทรกคำบรรยาย WebVTT ในเครื่อง อาร์กิวเมนต์แรกเป็นป้ายแทร็กและอาร์กิวเมนต์ที่สองระบุไฟล์ที่มีคำบรรยายตามเวลา

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

### **แยกคำบรรยาย Audio**

ตัวอย่างนี้ส่งออกแต่ละแทรกคำบรรยายที่แนบกับ Audio Frame บนสไลด์แรก มันเขียนไบต์ที่ได้จาก [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--) ไปยังไฟล์ WebVTT และใช้ตัวระบุที่ได้จาก [getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--) เป็นชื่อไฟล์เพื่อให้แต่ละแทร็กมีผลลัพธ์แยกกัน

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

### **ลบคำบรรยาย Audio**

ใช้ [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) หรือ [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) เพื่อลบแทรกเดี่ยว ตัวอย่างนี้ใช้ [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--) เพื่อลบคำบรรยายทั้งหมดจาก Audio Frame ตัวแรกบนสไลด์แรกโดยยังคงเก็บคลิปไว้

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

### **ค้นหาบรรทัดในคำบรรยาย Audio**

เพื่อค้นหาบรรทัดในคำบรรยาย Audio บนสไลด์แรก ให้ค้นหาข้อความที่ได้จาก [getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) ในหน่วยความจำ ในคิว WebVTT แบบข้อความธรรมดา บรรทัดเวลาจะมี `-->` ตามด้วยบรรทัดคำบรรยายและบรรทัดว่างจะสิ้นสุดคิว ตัวอย่างนี้พิมพ์ป้ายแทร็กและแต่ละบรรทัดคำบรรยายที่มีคำว่า “café”

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

## **แยก Audio**

การเปลี่ยนสไลด์อาจมีเสียงของตนเอง เพื่อดึงออกให้เรียก [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--) บนการเปลี่ยนสไลด์ ตัวอย่างนี้เข้าถึงไบต์ที่ได้จาก [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) แล้วพิมพ์จำนวนไบต์ หากสไลด์แรกไม่มีเสียงการเปลี่ยน มันจะแสดงข้อความแทน

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

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้คลิปเสียงเดียวกันในหลายสไลด์โดยไม่ต้องทำซ้ำได้หรือไม่?**  
ได้. เพิ่มคลิปเพียงครั้งเดียวใน [คอลเลกชันเสียง](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) ของงานนำเสนอและส่งออบเจกต์เสียงเดียวกันให้กับ [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) สำหรับแต่ละสไลด์

**ฉันสามารถแทนที่เสียงใน Audio Frame ที่มีอยู่ได้หรือไม่?**  
ได้. สำหรับเสียงที่เชื่อมโยง ให้ใช้ [setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) เพื่อชี้ไปยังไฟล์ทดแทน ส่วนสำหรับเสียงที่ฝัง ให้เลือกคลิปอื่นจากคอลเลกชันเสียงของงานนำเสนอด้วย [setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). ทั้งสองวิธีจะคงไว้ซึ่งเฟรมที่มีอยู่

**การตัดส่วนทำให้ข้อมูลเสียงที่เก็บในงานนำเสนอเปลี่ยนหรือไม่?**  
ไม่. [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) และ [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) กำหนดขอบเขตการเล่น คุณยังสามารถดึงคลิปเต็มจาก [getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--) ได้