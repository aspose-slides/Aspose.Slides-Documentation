---
title: จัดการเสียงในงานนำเสนอบน Android
linktitle: เฟรมเสียง
type: docs
weight: 10
url: /th/androidjava/audio-frame/
keywords:
- เสียง
- เฟรมเสียง
- รูปย่อ
- เพิ่มเสียง
- คุณสมบัติเสียง
- ตัวเลือกเสียง
- สกัดเสียง
- Android
- Java
- Aspose.Slides
description: "สร้างและควบคุมเฟรมเสียงใน Aspose.Slides สำหรับ Android—ตัวอย่าง Java เพื่อฝัง, ตัด, วนลูป, และกำหนดค่าการเล่นในงานนำเสนอแบบ PPT, PPTX และ ODP"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับเฟรมเสียงใน Aspose.Slides แสดงวิธีเพิ่มเสียงฝังลงในสไลด์ ปรับแต่งรูปย่อของเฟรมเสียง กำหนดค่าตัวเลือกการเล่นเช่น ระดับเสียง การวนซ้ำ การซ่อน การตัด และระยะเวลาการจางหาย และสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์

## **สร้างเฟรมเสียง**
Aspose.Slides for Android ผ่าน Java ช่วยให้คุณเพิ่มไฟล์เสียงลงในสไลด์ ไฟล์เสียงจะถูกฝังในสไลด์เป็นเฟรมเสียง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. โหลดสตรีมไฟล์เสียงที่คุณต้องการฝังในสไลด์
4. เพิ่มเฟรมเสียงฝัง (ซึ่งประกอบด้วยไฟล์เสียง) ไปยังสไลด์
5. ตั้งค่า [PlayMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AudioPlayModePreset) และ `Volume` ที่เปิดให้ใช้โดยอ็อบเจกต์ [IAudioFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAudioFrame)
6. บันทึกงานนำเสนอที่ถูกแก้ไข

โค้ด Java นี้แสดงวิธีเพิ่มเฟรมเสียงฝังลงในสไลด์:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // โหลดไฟล์เสียง wav ไปยังสตรีม
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // เพิ่มเฟรมเสียง
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // ตั้งค่าโหมดการเล่นและระดับเสียงของเสียง
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // เขียนไฟล์ PowerPoint ลงดิสก์
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **เปลี่ยนรูปย่อของเฟรมเสียง**

เมื่อคุณเพิ่มไฟล์เสียงลงในงานนำเสนอ เสียงจะแสดงเป็นเฟรมพร้อมรูปภาพค่าเริ่มต้นมาตรฐาน (ดูรูปในส่วนด้านล่าง) คุณสามารถเปลี่ยนรูปภาพตัวอย่างของเฟรมเสียง (ตั้งค่าภาพที่คุณต้องการ)

โค้ด Java นี้แสดงวิธีเปลี่ยนรูปย่อหรือรูปภาพตัวอย่างของเฟรมเสียง:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มเฟรมเสียงไปยังสไลด์ด้วยตำแหน่งและขนาดที่ระบุ
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // ตั้งค่ารูปภาพสำหรับเฟรมเสียง
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // บันทึกงานนำเสนอที่แก้ไขลงดิสก์
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **เปลี่ยนตัวเลือกการเล่นเสียง**

Aspose.Slides for Android ผ่าน Java ให้คุณเปลี่ยนตัวเลือกที่ควบคุมการเล่นหรือคุณสมบัติของเสียง ตัวอย่างเช่น คุณสามารถปรับระดับเสียงของเสียง ตั้งค่าให้เสียงเล่นวนซ้ำ หรือแม้กระทั่งซ่อนไอคอนเสียง

แผง **Audio Options**ใน Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options**ของ PowerPointที่สอดคล้องกับคุณสมบัติของ Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AudioFrame) :

- **Start** รายการดรอปดาวน์ตรงกับคุณสมบัติ [AudioFrame.PlayMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volume** ตรงกับคุณสมบัติ [AudioFrame.Volume](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Play Across Slides** ตรงกับคุณสมบัติ [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loop until Stopped** ตรงกับคุณสมบัติ [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Hide During Show** ตรงกับคุณสมบัติ [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Rewind after Playing** ตรงกับคุณสมบัติ [AudioFrame.RewindAudio](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

ตัวเลือก **Editing** ของ PowerPointที่สอดคล้องกับคุณสมบัติของ Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/audioframe/) :

- **Fade In** ตรงกับคุณสมบัติ [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Fade Out** ตรงกับคุณสมบัติ [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trim Audio Start Time** ตรงกับคุณสมบัติ [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Trim Audio End Time** มีค่าเท่ากับระยะเวลาของเสียงลบด้วยค่าของ [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

ตัวควบคุม **Volume**ของ PowerPointบนแผงควบคุมเสียงสอดคล้องกับคุณสมบัติ [AudioFrame.VolumeValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) ซึ่งช่วยให้คุณเปลี่ยนระดับเสียงเป็นเปอร์เซ็นต์

วิธีเปลี่ยนตัวเลือกการเล่นเสียงคือ:

1. [Сreate](#create-audio-frame) หรือรับ Audio Frame
2. ตั้งค่าค่าใหม่สำหรับคุณสมบัติของ Audio Frame ที่คุณต้องการปรับ
3. บันทึกไฟล์ PowerPoint ที่ถูกแก้ไข

โค้ด Java นี้สาธิบการดำเนินการที่ปรับตัวเลือกของเสียง:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // รับรูปร่าง AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // ตั้งค่าโหมดการเล่นให้เล่นเมื่อคลิก
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // ตั้งค่าระดับเสียงเป็น Low
    audioFrame.setVolume(AudioVolumeMode.Low);

    // ตั้งค่าให้เสียงเล่นต่อเนื่องหลายสไลด์
    audioFrame.setPlayAcrossSlides(true);

    // ปิดการวนลูปสำหรับเสียง
    audioFrame.setPlayLoopMode(false);

    // ซ่อน AudioFrame ระหว่างการแสดงสไลด์
    audioFrame.setHideAtShowing(true);

    // รีวายด์เสียงกลับไปเริ่มต้นหลังการเล่น
    audioFrame.setRewindAudio(true);

    // บันทึกไฟล์ PowerPoint ลงดิสก์
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่าง Java นี้แสดงวิธีเพิ่มเฟรมเสียงใหม่พร้อมเสียงฝัง, ตัดส่วนและตั้งค่าระยะเวลาการจาง:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // ตั้งค่าจุดเริ่มต้นการตัดเป็น 1.5 วินาที
    audioFrame.setTrimFromStart(1500f);
    // ตั้งค่าจุดสิ้นสุดการตัดเป็น 2 วินาที
    audioFrame.setTrimFromEnd(2000f);

    // ตั้งค่าระยะเวลาการค่อย‑ค่อยปรากฏ (fade‑in) เป็น 200 มิลลิวินาที
    audioFrame.setFadeInDuration(200f);
    // ตั้งค่าระยะเวลาการค่อย‑ค่อยหายไป (fade‑out) เป็น 500 มิลลิวินาที
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีดึงเฟรมเสียงที่มีเสียงฝังและตั้งระดับเสียงเป็น 85%:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // รับรูปร่างเฟรมเสียง
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // ตั้งค่าระดับเสียงเป็น 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **จัดการคำบรรยายเสียง**

Aspose.Slides ให้คุณเพิ่มคำบรรยายปิด (closed captions) ให้กับเฟรมเสียงผ่านเมธอด [getCaptionTracks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) เมธอดนี้จะคืนค่าเป็น [ICaptionsCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/) ซึ่งทำให้คุณสามารถเพิ่มแทร็กคำบรรยาย WebVTT, วนผ่านแทร็กที่มีอยู่, และลบได้เมื่อจำเป็น

**เพิ่มคำบรรยายเสียง**

ใช้เมธอด [getCaptionTracks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) เพื่อแนบแทร็กคำบรรยายหนึ่งหรือหลายแทร็กให้กับเฟรมเสียง ในตัวอย่างต่อไปนี้ ไฟล์เสียงจะถูกเพิ่มลงในสไลด์ และจากนั้นโหลดแทร็กคำบรรยายใหม่จากไฟล์ `.vtt`

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**สกัดคำบรรยายเสียง**

คุณสามารถวนผ่านแทร็กคำบรรยายที่เชื่อมกับเฟรมเสียงและบันทึกเป็นไฟล์ `.vtt`แต่ละแทร็กคำบรรยายจะเปิดเผยข้อมูลไบนารีและตัวระบุที่ไม่ซ้ำกัน ซึ่งสามารถใช้เมื่อนำออกคำบรรยาย

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // บันทึกแทร็กคำบรรยายเป็นไฟล์ .vtt.
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

**ลบคำบรรยายเสียง**

เพื่อทำการลบคำบรรยายออกจากเฟรมเสียง ให้ใช้เมธอดที่ [ICaptionsCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/) มีให้ เช่น [clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), หรือ [removeAt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-). ตัวอย่างต่อไปนี้ลบแทร็กคำบรรยายทั้งหมดจากเฟรมเสียง

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // ลบแทร็กคำบรรยายทั้งหมดออกจากเฟรมเสียง.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สกัดเสียง**

Aspose.Slides for Android ผ่าน Java ช่วยให้คุณสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์ ตัวอย่างเช่น คุณสามารถสกัดเสียงที่ใช้ในสไลด์เฉพาะ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) และโหลดงานนำเสนอที่มีเสียงอยู่
2. รับอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เข้าถึง [slideshow transitions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) ของสไลด์
4. สกัดเสียงเป็นข้อมูลไบต์

โค้ด Java นี้แสดงวิธีสกัดเสียงที่ใช้ในสไลด์:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // เข้าถึงสไลด์ที่ต้องการ
    ISlide slide = pres.getSlides().get_Item(0);
    
    // รับเอฟเฟกต์การเปลี่ยนสไลด์โชว์สำหรับสไลด์
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //สกัดเสียงเป็นอาเรย์ไบต์
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ไฟล์เสียงเดียวกันซ้ำในหลายสไลด์โดยไม่ทำให้ขนาดไฟล์เพิ่มขึ้นได้หรือไม่?**

ใช่. เพิ่มเสียงหนึ่งครั้งในงานนำเสนอ [audio collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getAudios--) ที่ใช้ร่วมกันและสร้างเฟรมเสียงเพิ่มเติมที่อ้างอิงถึงแหล่งเสียงที่มีอยู่ นี้จะป้องกันการทำสำเนาข้อมูลสื่อและทำให้ขนาดของงานนำเสนออยู่ในระดับที่สามารถควบคุมได้

**ฉันสามารถเปลี่ยนเสียงในเฟรมเสียงที่มีอยู่โดยไม่ต้องสร้างรูปร่างใหม่ได้หรือไม่?**

ใช่. สำหรับเสียงที่เป็นลิงก์ ให้อัปเดต [link path](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) ให้ชี้ไปยังไฟล์ใหม่ สำหรับเสียงฝัง ให้สลับอ็อบเจกต์ [embedded audio](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) กับอ็อบเจกต์อื่นจาก [audio collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getAudios--) ของงานนำเสนอ การจัดรูปแบบของเฟรมและการตั้งค่าการเล่นส่วนใหญ่ยังคงอยู่เหมือนเดิม

**การตัดส่วนเปลี่ยนแปลงข้อมูลเสียงพื้นฐานที่จัดเก็บในงานนำเสนอหรือไม่?**

ไม่. การตัดส่วนจะปรับเฉพาะขอบเขตการเล่นเท่านั้น ไบต์ของเสียงต้นฉบับจะไม่ถูกเปลี่ยนแปลงและยังสามารถเข้าถึงได้ผ่านเสียงฝังหรือ [audio collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getAudios--) ของงานนำเสนอ