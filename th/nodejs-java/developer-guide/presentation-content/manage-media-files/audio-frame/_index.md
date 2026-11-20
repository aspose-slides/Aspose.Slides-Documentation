---
title: จัดการเฟรมเสียงในงานนำเสนอโดยใช้ JavaScript
linktitle: เฟรมเสียง
type: docs
weight: 10
url: /th/nodejs-java/audio-frame/
keywords:
- เสียง
- เฟรมเสียง
- ภาพย่อ
- เพิ่มเสียง
- คุณสมบัติเสียง
- ตัวเลือกเสียง
- สกัดเสียง
- Node.js
- JavaScript
- Aspose.Slides
description: "ฝังเสียงในสไลด์, เปลี่ยนไอคอนเสียง, กำหนดค่าการเล่น, จัดการคำบรรยาย WebVTT, และสกัดเสียงการเปลี่ยนสไลด์ด้วย Aspose.Slides for Node.js ผ่าน Java."
---
## **ภาพรวม**

Audio frame ช่วยให้คุณสามารถเล่นเสียงบนสไลด์ได้ ด้วย Aspose.Slides for Node.js ผ่าน Java คุณสามารถฝังคลิปเสียง เลือกรูปภาพที่แสดงถึงคลิป ปรับการเล่น และแนบคำบรรยาย คุณยังสามารถดึงเสียงที่กำหนดให้กับการเปลี่ยนสไลด์ได้ด้วย

## **สร้าง Audio Frames**

ใช้ [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) เพื่อฝังคลิปเสียงในเครื่องบนสไลด์แรก พิกัดสองค่าตำแหน่งแรกกำหนดตำแหน่งของเฟรมบนสไลด์ และสองค่าถัดไปกำหนดความกว้างและความสูงทั้งหมดเป็นหน่วยจุด ตัวอย่างนี้เรียก [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) เพื่อให้คลิปเริ่มเล่นโดยอัตโนมัติและเรียก [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) เพื่อเลือกค่าความดังแบบเต็ม

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

## **เปลี่ยนรูปย่อของ Audio Frame**

โดยค่าเริ่มต้น Audio Frame จะแสดงไอคอนลำโพง เพื่อแสดงรูปย่อที่กำหนดเอง ให้เพิ่มรูปภาพลงในงานนำเสนอด้วย [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) และตั้งค่าให้กับรูปในเฟรมด้วย [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) ตัวอย่างใช้ `eagle.jpeg` เป็นรูปย่อสำหรับคลิปเสียงที่ฝังไว้

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

## **เปลี่ยนตัวเลือกการเล่นเสียง**

PowerPoint’s **Audio Options** คอนโทรลกำหนดว่าเมื่อไหร่คลิปจะเริ่ม, ความดังเสียงเป็นเท่าไหร่, และพฤติกรรมระหว่างการแสดงสไลด์

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| คอนโทรล PowerPoint | Aspose.Slides for Node.js via Java method |
| --- | --- |
| เริ่ม | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| พรีเซ็ตความดัง | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| เล่นต่อเนื่องข้ามสไลด์ | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| วนซ้ำจนหยุด | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| ซ่อนในระหว่างการแสดง | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| ย้อนกลับหลังการเล่น | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| ค่อยๆ เพิ่มความดัง | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| ค่อยๆ ลดความดัง | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| ตัดเวลาเริ่มต้นของเสียง | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| ตัดเวลาเนื้อสุดของเสียง | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| แถบเลื่อนความดัง | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

ตัวอย่างค้นหา Audio Frame แรกบนสไลด์แรก เรียก [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) เพื่อเริ่มเล่นเมื่อคลิกและเลือกพรีเซ็ตความดังต่ำ คลิปจะต่อเนื่องข้ามสไลด์โดยปิดการวนซ้ำ ไอคอนจะถูกซ่อนในระหว่างการแสดงและคลิปจะย้อนกลับหลังการเล่น

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

สำหรับคลิปที่ยาวกว่า 3.5 วินาที ตัวอย่างนี้จะข้าม 1.5 วินาทีแรกและ 2 วินาทีสุดท้าย [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) ใช้ระยะเวลาที่ต้องตัดออกจากส่วนท้ายของคลิป เพื่อให้ได้เวลาสิ้นสุดที่แสดงใน PowerPoint ให้ลบออฟเซ็ตนั้นจากระยะเวลาคลิปทั้งหมด คลิปที่ตัดจะค่อยๆ เพิ่มความดังภายใน 200 มิลลิวินาทีและค่อยๆ ลดความดังภายใน 500 มิลลิวินาที ทั้งสี่เมธอดรับค่าหน่วยเป็นมิลลิวินาที

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

เพื่อกำหนดระดับเสียงการเล่นเป็นเปอร์เซ็นต์ที่ต้องการ ให้ใช้ [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) ตัวอย่างนี้ตั้งค่า Audio Frame แรกบนสไลด์แรกเป็น 85%

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

## **จัดการคำบรรยายเสียง**

แต่ละ Audio Frame ให้การเข้าถึงแทร็กคำบรรยายผ่าน [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) ใช้คอลเลกชันเพื่อแนบคำบรรยาย WebVTT ให้กับคลิป ส่งออกแทร็กที่มีอยู่หรือกำจัดออก

### **เพิ่มคำบรรยายเสียง**

ตัวอย่างฝังคลิปเสียงบนสไลด์แรกและใช้ [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) เพื่อแนบแทร็ก WebVTT ในเครื่อง อาร์กิวเมนต์แรกให้ชื่อแทร็กและอาร์กิวเมนต์ที่สองระบุไฟล์ที่มีคำบรรยายตามเวลา

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

### **สกัดคำบรรยายเสียง**

ตัวอย่างนี้ส่งออกแต่ละแทร็กคำบรรยายที่แนบกับ Audio Frame บนสไลด์แรก มันเขียนไบต์ที่ [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) คืนค่าไปยังไฟล์ WebVTT และใช้ตัวระบุที่ [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) คืนค่าเป็นชื่อไฟล์ เพื่อให้แต่ละแทร็กมีไฟล์แยกกัน

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

### **ลบคำบรรยายเสียง**

ใช้ [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) เพื่อลบแทร็กเดียว ตัวอย่างใช้ [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) เพื่อลบคำบรรยายทั้งหมดจาก Audio Frame แรกบนสไลด์แรกโดยยังคงคลิปไว้

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

### **ค้นบรรทัดในคำบรรยายเสียง**

เพื่อค้นหาบรรทัดในคำบรรยายเสียงบนสไลด์แรก ให้ค้นข้อความที่ [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) คืนค่าในหน่วยความจำ ในคิว WebVTT แบบข้อความธรรมดา บรรทัดเวลาที่มี `-->` อยู่ก่อนบรรทัดคำบรรยายและบรรทัดว่างเป็นจุดสิ้นสุดคิว ตัวอย่างนี้พิมพ์ชื่อแทร็กและแต่ละบรรทัดคำบรรยายที่มีคำว่า “café”

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

## **สกัดเสียง**

การเปลี่ยนสไลด์สามารถมีเสียงของตนเองได้ เพื่อดึงเสียงนั้นให้เรียก [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) บนการเปลี่ยนสไลด์ ตัวอย่างเข้าถึงไบต์ที่ [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) คืนค่าและพิมพ์จำนวนไบต์ หากสไลด์แรกไม่มีเสียงการเปลี่ยน จะพิมพ์ข้อความแทน

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

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้คลิปเสียงเดียวกันในหลายสไลด์โดยไม่ต้องทำซ้ำได้หรือไม่?**

ได้. เพิ่มคลิปหนึ่งครั้งใน [คอลเลกชันเสียง](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) แล้วส่งออบเจกต์เสียงเดียวกันไปยัง [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) สำหรับแต่ละสไลด์.

**ฉันสามารถเปลี่ยนเสียงใน Audio Frame ที่มีอยู่ได้หรือไม่?**

ได้. สำหรับเสียงแบบเชื่อมโยง ให้ใช้ [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) เพื่อชี้ไปยังไฟล์แทนที่ สำหรับเสียงแบบฝัง ให้เลือกคลิปอื่นจากคอลเลกชันเสียงของงานนำเสนอด้วย [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio) ทั้งสองวิธีจะคงเฟรมเดิมไว้

**การตัดส่วนทำให้ข้อมูลเสียงที่เก็บในงานนำเสนอเปลี่ยนแปลงหรือไม่?**

ไม่. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) และ [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) กำหนดขอบเขตการเล่น คุณยังสามารถดึงคลิปเต็มจาก [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio) ได้