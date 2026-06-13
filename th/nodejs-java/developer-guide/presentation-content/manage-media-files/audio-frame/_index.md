---
title: จัดการเสียงในงานนำเสนอด้วย JavaScript
linktitle: เฟรมเสียง
type: docs
weight: 10
url: /th/nodejs-java/audio-frame/
keywords:
- เสียง
- เฟรมเสียง
- ภาพย่อ
- เพิ่มเสียง
- คุณสมบัติของเสียง
- ตัวเลือกเสียง
- สกัดเสียง
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและควบคุมเฟรมเสียงใน Aspose.Slides สำหรับ Node.js—ตัวอย่างการฝัง, ตัด, วนลูป, และกำหนดค่าการเล่นในงานนำเสนอรูปแบบ PPT, PPTX, และ ODP."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับเฟรมเสียงใน Aspose.Slides ซึ่งแสดงวิธีการเพิ่มไฟล์เสียงฝังลงในสไลด์ ปรับแต่งภาพย่อของเฟรมเสียง ตั้งค่าตัวเลือกการเล่น เช่น ระดับเสียง การวนซ้ำ การซ่อน การตัด และระยะเวลาการจาง และสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์

## **สร้างเฟรมเสียง**

Aspose.Slides for Node.js via Java ทำให้คุณสามารถเพิ่มไฟล์เสียงลงในสไลด์ได้ ไฟล์เสียงจะถูกฝังในสไลด์เป็นเฟรมเสียง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. โหลดสตรีมไฟล์เสียงที่คุณต้องการฝังในสไลด์
4. เพิ่มเฟรมเสียงฝัง (ซึ่งมีไฟล์เสียง) ลงในสไลด์
5. ตั้งค่า [PlayMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AudioPlayModePreset) และ `Volume` ที่เผยโดยอ็อบเจกต์ [AudioFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AudioFrame)
6. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ด JavaScript นี้แสดงวิธีการเพิ่มเฟรมเสียงฝังลงในสไลด์:
```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
const pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    const sld = pres.getSlides().get_Item(0);
    // โหลดไฟล์เสียง wav ไปยังสตรีม
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // เพิ่มเฟรมเสียง
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // ตั้งค่าโหมดการเล่นและระดับเสียงของเสียง
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // บันทึกไฟล์ PowerPoint ลงดิสก์
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เปลี่ยนภาพย่อของเฟรมเสียง**

เมื่อคุณเพิ่มไฟล์เสียงเข้าไปในงานนำเสนอ เสียงจะปรากฏเป็นเฟรมพร้อมภาพเริ่มต้นมาตรฐาน (ดูภาพในส่วนด้านล่าง) คุณสามารถเปลี่ยนภาพตัวอย่างของเฟรมเสียง (ตั้งค่าภาพที่คุณต้องการ)

โค้ด JavaScript นี้แสดงวิธีการเปลี่ยนภาพย่อหรือภาพตัวอย่างของเฟรมเสียง:
```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // เพิ่มเฟรมเสียงลงในสไลด์โดยระบุตำแหน่งและขนาดที่กำหนด.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // เพิ่มรูปภาพลงในทรัพยากรของงานนำเสนอ.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // ตั้งค่ารูปภาพสำหรับเฟรมเสียง.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // บันทึกงานนำเสนอที่แก้ไขลงดิสก์
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **เปลี่ยนตัวเลือกการเล่นเสียง**

Aspose.Slides for Node.js via Java ทำให้คุณสามารถเปลี่ยนตัวเลือกที่ควบคุมการเล่นหรือคุณสมบัติเสียงได้ ตัวอย่างเช่น คุณสามารถปรับระดับเสียงของเสียง ตั้งค่าให้เสียงเล่นวนลูป หรือแม้กระทั่งซ่อนไอคอนเสียง

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** ที่สอดคล้องกับคุณสมบัติของ Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/) properties:
- **Start** รายการดร็อปดาวน์ตรงกับเมธอด [AudioFrame.setPlayMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** ตรงกับเมธอด [AudioFrame.setVolume](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** ตรงกับเมธอด [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** ตรงกับเมธอด [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** ตรงกับเมธอด [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** ตรงกับเมธอด [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#setRewindAudio)

ตัวเลือก **Editing** ของ PowerPoint ที่สอดคล้องกับคุณสมบัติของ Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/) properties:
- **Fade In** ตรงกับเมธอด [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#setFadeInDuration)
- **Fade Out** ตรงกับเมธอด [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration)
- **Trim Audio Start Time** ตรงกับเมธอด [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#setTrimFromStart)
- **Trim Audio End Time** มีค่าเท่ากับความยาวของเสียงลบค่าที่ได้จากเมธอด [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

ส่วนควบคุม **Volume** ของ PowerPoint บนแผงควบคุมเสียงสอดคล้องกับเมธอด [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#setVolumeValue) ซึ่งช่วยให้คุณเปลี่ยนระดับเสียงเป็นเปอร์เซ็นต์

วิธีการเปลี่ยนตัวเลือกการเล่นเสียง:
1. [สร้าง](#create-audio-frame) หรือรับ Audio Frame.
2. ตั้งค่ามาตรฐานใหม่สำหรับคุณสมบัติของ Audio Frame ที่คุณต้องการปรับ
3. บันทึกไฟล์ PowerPoint ที่แก้ไขแล้ว

โค้ด JavaScript นี้สาธิตการดำเนินการที่ปรับตัวเลือกของเสียง:
```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // ดึงรูปร่าง AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // ตั้งค่าโหมดการเล่นให้เล่นเมื่อคลิก
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // ตั้งค่าระดับเสียงเป็นต่ำ
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // ตั้งค่าให้เสียงเล่นต่อเนื่องระหว่างสไลด์
    audioFrame.setPlayAcrossSlides(true);
    // ปิดการวนลูปสำหรับเสียง
    audioFrame.setPlayLoopMode(false);
    // ซ่อน AudioFrame ระหว่างการแสดงสไลด์
    audioFrame.setHideAtShowing(true);
    // ถอยกลับเสียงไปที่จุดเริ่มต้นหลังการเล่น
    audioFrame.setRewindAudio(true);
    // บันทึกไฟล์ PowerPoint ลงดิสก์
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

ตัวอย่าง JavaScript นี้แสดงวิธีการเพิ่มเฟรมเสียงใหม่พร้อมเสียงฝัง, ตัดส่วนเริ่มและสิ้นสุด, และตั้งค่าระยะเวลาจาง:
```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // ตั้งค่าออฟเซ็ตการตัดเริ่มต้นเป็น 1.5 วินาที
    audioFrame.setTrimFromStart(1500);
    // ตั้งค่าออฟเซ็ตการตัดสิ้นสุดเป็น 2 วินาที
    audioFrame.setTrimFromEnd(2000);

    // ตั้งค่าเวลาจางเข้าเป็น 200 มิลลิวินาที
    audioFrame.setFadeInDuration(200);
    // ตั้งค่าเวลาจางออกเป็น 500 มิลลิวินาที
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการดึง Audio Frame ที่มีเสียงฝังและตั้งค่าระดับเสียงเป็น 85%:
```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // ดึงรูปร่าง AudioFrame
    const audioFrame = slide.getShapes().get_Item(0);

    // ตั้งค่าระดับเสียงเป็น 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **จัดการคำบรรยายเสียง**

Aspose.Slides ให้คุณเพิ่มคำบรรยายปิดให้กับ Audio Frame ผ่านเมธอด [getCaptionTracks](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) เมธอดนี้คืนค่า [CaptionsCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/) ซึ่งทำให้คุณสามารถเพิ่มแทร็กคำบรรยาย WebVTT, วนซ้ำผ่านแทร็กที่มีอยู่, และลบออกเมื่อจำเป็น

**เพิ่มคำบรรยายเสียง**

ใช้เมธอด [getCaptionTracks](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) เพื่อแนบแทร็กคำบรรยายหนึ่งหรือหลายแทร็กให้กับ Audio Frame ตัวอย่างต่อไปนี้เพิ่มไฟล์เสียงลงในสไลด์ แล้วโหลดแทร็กคำบรรยายใหม่จากไฟล์ `.vtt`.
```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**สกัดคำบรรยายเสียง**

คุณสามารถวนซ้ำผ่านแทร็กคำบรรยายที่เชื่อมกับ Audio Frame และบันทึกเป็นไฟล์ `.vtt` แต่ละแทร็กคำบรรยายเปิดเผยข้อมูลไบนารีและรหัสประจำตัวที่เป็นเอกลักษณ์ ซึ่งสามารถใช้เมื่อนำคำบรรยายออก
```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // บันทึกแทร็กคำบรรยายเป็นไฟล์ .vtt.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**ลบคำบรรยายเสียง**

เพื่อทำการลบคำบรรยายจาก Audio Frame ให้ใช้เมธอดที่ [CaptionsCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/) มีให้ เช่น [clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/#remove), หรือ [removeAt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/#removeAt). ตัวอย่างต่อไปนี้ลบทุกแทร็กคำบรรยายจาก Audio Frame.
```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // ประเภท: aspose.slides.AudioFrame

    // ลบแทร็กคำบรรยายทั้งหมดจากเฟรมเสียง.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สกัดเสียง**

Aspose.Slides for Node.js via Java ทำให้คุณสามารถสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์ ตัวอย่างเช่น คุณสามารถสกัดเสียงที่ใช้ในสไลด์เฉพาะ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) และโหลดงานนำเสนอที่มีเสียง
2. รับอ้างอิงของสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เข้าถึง [slideshow transitions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) ของสไลด์
4. สกัดเสียงเป็นข้อมูลไบต์

โค้ด JavaScript นี้แสดงวิธีสกัดเสียงที่ใช้ในสไลด์:
```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // เข้าถึงสไลด์ที่ต้องการ
    const slide = pres.getSlides().get_Item(0);
    // ดึงเอฟเฟกต์การเปลี่ยนสไลด์โชว์สำหรับสไลด์
    const transition = slide.getSlideShowTransition();
    // สกัดเสียงเป็นอาเรย์ไบต์
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**ฉันสามารถใช้ไฟล์เสียงเดียวกันซ้ำในหลายสไลด์โดยไม่ทำให้ไฟล์ขนาดใหญ่ขึ้นได้หรือไม่?**

ได้. เพิ่มเสียงหนึ่งครั้งใน [audio collection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getaudios/) ที่ใช้ร่วมของงานนำเสนอและสร้าง Audio Frame เพิ่มเติมที่อ้างอิงสินทรัพย์ที่มีอยู่ วิธีนี้ช่วยหลีกเลี่ยงการทำซ้ำข้อมูลสื่อและทำให้ขนาดงานนำเสนออยู่ภายใต้การควบคุม

**ฉันสามารถแทนที่เสียงใน Audio Frame ที่มีอยู่โดยไม่ต้องสร้างรูปร่างใหม่ได้หรือไม่?**

ได้. สำหรับเสียงที่เป็นลิงก์ ให้อัปเดต [link path](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) ให้ชี้ไปยังไฟล์ใหม่ สำหรับเสียงฝัง ให้สลับอ็อบเจกต์ [embedded audio](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) ด้วยออบเจกต์อื่นจาก [audio collection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getaudios/) ของงานนำเสนอ การฟอร์แมตของเฟรมและการตั้งค่าการเล่นส่วนใหญ่จะคงเดิม

**การตัดส่วนทำให้ข้อมูลเสียงพื้นฐานที่เก็บไว้ในงานนำเสนอเปลี่ยนหรือไม่?**

ไม่. การตัดส่วนปรับเฉพาะขอบเขตการเล่นเท่านั้น ไบต์เสียงต้นฉบับยังคงไม่ถูกแก้ไขและสามารถเข้าถึงได้ผ่านเสียงฝังหรือ [audio collection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getaudios/) ของงานนำเสนอ