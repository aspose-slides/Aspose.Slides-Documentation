---
title: จัดการเสียงในงานนำเสนอด้วย Java
linktitle: เฟรมเสียง
type: docs
weight: 10
url: /th/java/audio-frame/
keywords:
- เสียง
- เฟรมเสียง
- ภาพย่อ
- เพิ่มเสียง
- คุณสมบัติของเสียง
- ตัวเลือกเสียง
- สกัดเสียง
- Java
- Aspose.Slides
description: "สร้างและควบคุมเฟรมเสียงใน Aspose.Slides for Java—ตัวอย่างโค้ดสำหรับฝัง, ตัด, ทำวนซ้ำ, และกำหนดค่าการเล่นในงานนำเสนอประเภท PPT, PPTX, และ ODP"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับเฟรมเสียงใน Aspose.Slides ซึ่งจะแสดงวิธีเพิ่มเสียงฝังในสไลด์ ปรับแต่งภาพย่อของเฟรมเสียง กำหนดค่าตัวเลือกการเล่น เช่น ระดับเสียง การวนซ้ำ การซ่อน การตัดส่วน และระยะเวลาเฟด รวมทั้งสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์

## **สร้างเฟรมเสียง**

Aspose.Slides for Java อนุญาตให้คุณเพิ่มไฟล์เสียงในสไลด์ ไฟล์เสียงจะถูกฝังในสไลด์เป็นเฟรมเสียง  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. โหลดสตรีมไฟล์เสียงที่คุณต้องการฝังในสไลด์  
4. เพิ่มเฟรมเสียงที่ฝัง (ซึ่งประกอบด้วยไฟล์เสียง) เข้าในสไลด์  
5. ตั้งค่า [PlayMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/AudioPlayModePreset) และ `Volume` ที่เปิดเผยโดยวัตถุ [IAudioFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAudioFrame)  
6. บันทึกการนำเสนอที่แก้ไขแล้ว  

โค้ด Java นี้แสดงวิธีเพิ่มเฟรมเสียงฝังลงในสไลด์:

```java
// สร้างอินสแทนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ
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

## **เปลี่ยนภาพย่อของเฟรมเสียง**

เมื่อคุณเพิ่มไฟล์เสียงลงในการนำเสนอ เสียงจะแสดงเป็นเฟรมพร้อมภาพเริ่มต้นมาตรฐาน (ดูภาพในส่วนด้านล่าง) คุณสามารถเปลี่ยนภาพตัวอย่างของเฟรมเสียง (ตั้งค่าภาพที่คุณต้องการ)  

โค้ด Java นี้แสดงวิธีเปลี่ยนภาพย่อหรือภาพตัวอย่างของเฟรมเสียง:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มเฟรมเสียงลงในสไลด์โดยระบุตำแหน่งและขนาดที่กำหนด.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // เพิ่มรูปภาพไปยังทรัพยากรของการนำเสนอ.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // ตั้งค่ารูปภาพสำหรับเฟรมเสียง.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //บันทึกการนำเสนอที่แก้ไขแล้วลงดิสก์
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **เปลี่ยนตัวเลือกการเล่นเสียง**

Aspose.Slides for Java อนุญาตให้คุณเปลี่ยนตัวเลือกที่ควบคุมการเล่นหรือคุณสมบัติของเสียง เช่น สามารถปรับระดับเสียงของเสียง ตั้งค่าให้เสียงเล่นวนซ้ำ หรือแม้แต่ซ่อนไอคอนเสียง  

แผง **Audio Options** ใน Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** ที่สอดคล้องกับคุณสมบัติของ Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/AudioFrame) มีดังนี้:

- **Start** รายการดรอป‑ดาวน์ ตรงกับเมธอด [AudioFrame.setPlayMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/audioframe/#setPlayMode-int-)  
- **Volume** ตรงกับเมธอด [AudioFrame.setVolume](https://reference.aspose.com/slides/th/java/com.aspose.slides/audioframe/#setVolume-int-)  
- **Play Across Slides** ตรงกับเมธอด [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)  
- **Loop until Stopped** ตรงกับเมธอด [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)  
- **Hide During Show** ตรงกับเมธอด [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/th/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)  
- **Rewind after Playing** ตรงกับเมธอด [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/th/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)  

ตัวเลือก **Editing** ของ PowerPoint ที่สอดคล้องกับคุณสมบัติของ Aspose.Slides [AudioFrame] มีดังนี้:

- **Fade In** ตรงกับเมธอด [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/th/java/com.aspose.slides/audioframe/#setFadeInDuration-float-)  
- **Fade Out** ตรงกับเมธอด [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/th/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-)  
- **Trim Audio Start Time** ตรงกับเมธอด [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/th/java/com.aspose.slides/audioframe/#setTrimFromStart-float-)  
- **Trim Audio End Time** มีค่าเท่ากับระยะเวลาของเสียงลบค่าที่ตั้งในเมธอด [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/th/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)  

ตัวควบคุม **Volume controll** บนแผงควบคุมเสียงของ PowerPoint สอดคล้องกับเมธอด [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/audioframe/#setVolumeValue-float-) ซึ่งทำให้คุณเปลี่ยนระดับเสียงเป็นเปอร์เซ็นต์  

วิธีการเปลี่ยนตัวเลือกการเล่นเสียงมีดังนี้:

1. [Сreate](#create-audio-frame) หรือดึง Audio Frame  
2. ตั้งค่าคุณสมบัติของ Audio Frame ที่ต้องการปรับเป็นค่ใหม่  
3. บันทึกไฟล์ PowerPoint ที่แก้ไขแล้ว  

โค้ด Java นี้แสดงการดำเนินการที่ปรับตัวเลือกของเสียง:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // ดึงรูปแบบ AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // ตั้งค่าโหมดการเล่นให้เล่นเมื่อคลิก
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // ตั้งระดับเสียงเป็นต่ำ
    audioFrame.setVolume(AudioVolumeMode.Low);

    // ตั้งค่าให้เสียงเล่นต่อเนื่องข้ามสไลด์
    audioFrame.setPlayAcrossSlides(true);

    // ปิดการวนซ้ำสำหรับเสียง
    audioFrame.setPlayLoopMode(false);

    // ซ่อน AudioFrame ระหว่างการนำเสนอ
    audioFrame.setHideAtShowing(true);

    // รีวินด์เสียงกลับไปเริ่มต้นหลังการเล่น
    audioFrame.setRewindAudio(true);

    // บันทึกไฟล์ PowerPoint ลงดิสก์
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่าง Java นี้แสดงวิธีเพิ่มเฟรมเสียงใหม่พร้อมเสียงฝัง, ตัดส่วน, และตั้งค่าระยะเวลาเฟด:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // ตั้งค่าออฟเซ็ตการตัดเริ่มต้นเป็น 1.5 วินาที
    // ตั้งค่าออฟเซ็ตการตัดสุดท้ายเป็น 2 วินาที
    // ตั้งค่าระยะเวลา fade‑in เป็น 200 มิลลิวินาที
    // ตั้งค่าระยะเวลา fade‑out เป็น 500 มิลลิวินาที

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีดึงเฟรมเสียงที่มีเสียงฝังและตั้งค่าระดับเสียงเป็น 85%:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // ดึงรูปร่างของ audio frame
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // ตั้งค่าระดับเสียงของ audio เป็น 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **จัดการคำบรรยายเสียง**

Aspose.Slides อนุญาตให้คุณเพิ่มคำบรรยายปิด (closed captions) ให้กับเฟรมเสียงผ่านเมธอด [getCaptionTracks](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) . เมธอดนี้จะคืนค่าเป็น [ICaptionsCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/) ซึ่งให้คุณเพิ่มแทร็กคำบรรยาย WebVTT, วนซ้ำผ่านแทร็กที่มีอยู่, และลบเมื่อจำเป็น  

**เพิ่มคำบรรยายเสียง**

ใช้เมธอด [getCaptionTracks](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) เพื่อแนบแทร็กคำบรรยายหนึ่งหรือหลายแทร็กให้กับเฟรมเสียง ในตัวอย่างต่อไปนี้ จะเพิ่มไฟล์เสียงลงในสไลด์ แล้วโหลดแทร็กคำบรรยายใหม่จากไฟล์ `.vtt`.

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

คุณสามารถวนซ้ำผ่านแทร็กคำบรรยายที่เชื่อมโยงกับเฟรมเสียงและบันทึกเป็นไฟล์ `.vtt` แต่ละแทร็กคำบรรยายจะเปิดเผยข้อมูลไบนารีและตัวระบุที่ไม่ซ้ำกัน ซึ่งสามารถใช้เมื่อนำออกคำบรรยาย

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // บันทึกแทร็กคำบรรยายเป็นไฟล์ .vtt
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**ลบคำบรรยายเสียง**

เพื่อทำการลบคำบรรยายจากเฟรมเสียง ใช้วิธีการที่ให้โดย [ICaptionsCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/) เช่น [clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), หรือ [removeAt](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/#removeAt-int-). ตัวอย่างต่อไปนี้จะลบแทร็กคำบรรยายทั้งหมดจากเฟรมเสียง.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // ลบแทร็กคำบรรยายทั้งหมดจากเฟรมเสียง.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สกัดเสียง**

Aspose.Slides for Java อนุญาตให้คุณสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์ ตัวอย่างเช่น คุณสามารถสกัดเสียงที่ใช้ในสไลด์เฉพาะ  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) และโหลดการนำเสนอที่มีเสียงอยู่  
2. ดึงอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน  
3. เข้าถึง [slideshow transitions](https://reference.aspose.com/slides/th/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) ของสไลด์  
4. สกัดเสียงเป็นข้อมูลไบต์  

โค้ด Java นี้แสดงวิธีสกัดเสียงที่ใช้ในสไลด์:

```java
// สร้างอินสแทนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // เข้าถึงสไลด์ที่ต้องการ
    ISlide slide = pres.getSlides().get_Item(0);
    
    // ดึงเอฟเฟ็กต์การเปลี่ยนสไลด์โชว์สำหรับสไลด์นี้
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //สกัดเสียงในอาร์เรย์ไบต์
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ฉันสามารถใช้ทรัพยากรเสียงเดียวกันบนหลายสไลด์โดยไม่ทำให้ไฟล์ขนาดใหญ่ขึ้นได้หรือไม่?**  

ได้. เพิ่มเสียงครั้งเดียวใน [audio collection] ที่ใช้ร่วมกันของการนำเสนอและสร้างเฟรมเสียงเพิ่มเติมที่อ้างอิงทรัพยากรนั้น ซึ่งช่วยหลีกเลี่ยงการทำสำเนาข้อมูลสื่อและทำให้ขนาดการนำเสนออยู่ในระดับที่ควบคุมได้  

**ฉันสามารถแทนที่เสียงในเฟรมเสียงที่มีอยู่โดยไม่ต้องสร้างรูปร่างใหม่ได้หรือไม่?**  

ได้. สำหรับเสียงที่เชื่อมโยง ให้อัปเดต [link path] ให้ชี้ไปที่ไฟล์ใหม่ สำหรับเสียงที่ฝัง ให้สลับวัตถุ [embedded audio] ด้วยวัตถุอื่นจาก [audio collection] ของการนำเสนอ การจัดรูปแบบของเฟรมและการตั้งค่าการเล่นส่วนใหญ่จะคงเดิม  

**การตัดส่วน (trimming) จะทำให้ข้อมูลเสียงพื้นฐานที่เก็บไว้ในการนำเปลี่ยนแปลงหรือไม่?**  

ไม่. การตัดส่วนจะปรับเฉพาะขอบเขตการเล่นเท่านั้น ไบต์เสียงต้นฉบับจะยังคงไม่ถูกแก้ไขและสามารถเข้าถึงได้ผ่านเสียงฝังหรือ [audio collection] ของการนำเสนอ