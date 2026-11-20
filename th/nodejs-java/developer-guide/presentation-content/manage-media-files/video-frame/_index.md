---
title: จัดการเฟรมวิดีโอในงานนำเสนอโดยใช้ Node.js
linktitle: เฟรมวิดีโอ
type: docs
weight: 10
url: /th/nodejs-java/video-frame/
keywords:
- เพิ่มวิดีโอ
- สร้างวิดีโอ
- ฝังวิดีโอ
- ดึงวิดีโอ
- เรียกคืนวิดีโอ
- เฟรมวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและดึงเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างอัตโนมัติด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java คู่มือวิธีทำอย่างรวดเร็ว"
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้ Aspose.Slides สำหรับ Node.js ผ่าน Java ให้คุณเพิ่มเฟรมวิดีโอในสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และดึงข้อมูลวิดีโอที่ฝังไว้

PowerPoint รองรับวิดีโอในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

เพื่อเป็นตัวแทนข้อมูลวิดีโอและเฟรมวิดีโอ Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) และคลาส [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) รวมถึงประเภทที่เกี่ยวข้องอื่นๆ

## **สร้างเฟรมวิดีโอที่ฝังไว้**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มในสไลด์ถูกเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอในงานนำเสนอของคุณได้

ตัวอย่างนี้ฝังวิดีโอในเครื่องบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของเฟรมเป็นหน่วย point สตรีมจะค้างเปิดจนกว่าการบันทึกจะเสร็จ เนื่องจาก [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) ทำให้มันล็อคขณะที่งานนำใช้

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

คุณยังสามารถส่งพาธวิดีโอในเครื่องโดยตรงไปยัง [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). ตัวอย่างนี้ฝังวิดีโอบนสไลด์แรกของงานนำเสนอใหม่ วิดีโอจะต้องสามารถเข้าถึงได้จนกว่างานนำเสนอจะถูกบันทึก

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สร้างเฟรมวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างเฟรมวิดีโอที่ลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และรูปภาพย่อบนสไลด์แรก แทนที่ตัวระบุวิดีโอเพื่อใช้วิดีโออื่น ๆ วิธีการ [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) ขอให้เล่นอัตโนมัติ การดาวน์โหลดรูปย่อและการเล่นวิดีโอต้องการการเชื่อมต่ออินเทอร์เน็ต โปรแกรมดูงานนำเสนอจะต้องรองรับการเล่นวิดีโอออนไลน์ด้วย

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เล่นวิดีโอในโหมดเต็มหน้าจอ**

ในงานนำเสนอการฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มหน้าจอเพื่อให้ผู้ชมเห็นรายละเอียด เรียก [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) ด้วย `true` เพื่อเปิดใช้งานพฤติกรรมนี้ระหว่างการเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) ตัวแรกบนสไลด์แรก และเปิดการเล่นแบบเต็มหน้าจอ งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเล่นแบบเต็มหน้าจอควบคุมวิธีการแสดงวิดีโอ อย่างอิสระ [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) ควบคุมว่ามันเริ่มอัตโนมัติหรือคลิก, และ [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) ควบคุมว่ามันวนซ้ำหรือไม่ เพื่อเลือกพฤติกรรมการเริ่ม ให้ตั้งโหมดการเล่นเป็น [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). ตัวอย่างนี้รักษาการตั้งค่าเริ่มต้นและการวนซ้ำที่มีอยู่

## **ย้อนวิดีโอหลังการเล่น**

ในงานนำเสนอการฝึกอบรม การนำวิดีโอสาธิตกลับไปยังจุดเริ่มต้นทำให้พร้อมสำหรับผู้บรรยายเล่นอีกครั้ง เรียก [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) ด้วย `true` เพื่อให้วิดีโอกลับไปที่จุดเริ่มต้นหลังการเล่นจบ

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) ตัวแรกบนสไลด์แรก และเปิดการย้อนวิดีโอ ปิดการวนซ้ำเพื่อให้การเล่นจบและตั้งให้เริ่มเมื่อคลิก งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การย้อนกลับทำให้วิดีโอกลับไปที่จุดเริ่มต้นโดยไม่เริ่มใหม่ ในทางกลับกัน การเรียก [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) ด้วย `true` จะทำให้การเล่นวนซ้ำอัตโนมัติ คงการวนซ้ำให้ปิดเมื่อคุณต้องการให้วิดีโอจบและพร้อมเล่นใหม่ [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) ควบคุมการเริ่มอัตโนมัติหรือเมื่อคลิกแยกกัน; ตัวอย่างนี้ใช้ [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) เพื่อให้ผู้บรรยายควบคุมเวลาเริ่มการเล่น ตั้งค่าโหมดการเล่นหลังจากการตั้งค่าการวนซ้ำตามที่แสดงในตัวอย่าง การย้อนกลับทำงานแยกจาก [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/)

## **ตัดเฟรมวิดีโอ**

ใช้ [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) และ [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) เพื่อข้ามส่วนต้นหรือส่วนท้ายของวิดีโอขณะเล่น ค่าทั้งสองเป็นมิลลิวินาที การตัดเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังอยู่

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายขณะเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้เหลือส่วนที่เล่นได้

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**อ่านการตั้งค่าการตัด**

ตัวอย่างนี้พิมพ์ค่าการตัดของเฟรมวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีเฟรมวิดีโอ จะไม่มีการพิมพ์ ค่าในตัวอย่างก่อนหน้านี้คือ 2500 และ 1000

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides อนุญาตให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกจัดเก็บในรูปแบบ WebVTT และเข้าถึงได้ผ่านเมธอด [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks)

### **เพิ่มคำบรรยายให้กับเฟรมวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทร็กคำบรรยาย WebVTT ที่มีชื่อว่า English เวลาตำแหน่งคำบรรยายควรตรงกับวิดีโอ งานนำเสนอที่บันทึกจะมีทั้งวิดีโอและคำบรรยายรวมอยู่ด้วย

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

คลาส [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) ยังมีเมธอด [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) สำหรับเพิ่มคำบรรยายจากสตรีม

### **ดึงคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้บันทึกแทร็กคำบรรยายทั้งหมดจากเฟรมวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกกัน ใช้หมายเลขต่อเนื่องเพื่อให้ไฟล์ผลลัพธ์ไม่ซ้ำกัน คอนโซลรายงานจำนวนแทร็กที่ดึงออก งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

แต่ละอ็อบเจ็กต์ [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) แสดงตัวระบุคำบรรยาย, ป้ายกำกับ, ข้อมูลไบเนอรี, และข้อความคำบรรยายเป็นสตริง UTF-8

### **ลบคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอที่ตำแหน่งรูปทรงแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่าสไลด์และรูปทรงมีอยู่และรูปทรงเป็นเฟรมวิดีโอ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการลบแค่แทร็กคำบรรยายเดียว ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) แทน [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear)

### **ค้นหาคำบรรยายวิดีโอ**

เมธอด [Captions.getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) จะคืนค่าแทร็ก WebVTT ทั้งหมดรวมหัวเรื่อง, บรรทัดเวลา, และข้อความคำบรรยาย คุณสามารถค้นหาข้อความคำบรรยายในหน่วยความจำเพื่อหาวลีและเวลาตำแหน่งของมัน ตัวอย่างเช่น แทร็กภาษาอังกฤษบนสไลด์ 2 อาจมีคิวนี้:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

ตัวอย่างนี้เปิดไฟล์ `captioned_media.pptx` และใช้ [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) เพื่ออ่านแทร็กของแต่ละเฟรมวิดีโอระดับบนบนทุกสไลด์ ในคิวแบบ plain‑text บรรทัดเวลาอาจมี `-->` และบรรทัดว่างจะเป็นจุดสิ้นสุดคิว สำหรับแต่ละคำบรรยายที่มีคำว่า “café” ไม่ว่าตัวอักษรจะเป็นรูปแบบใด ตัวอย่างจะพิมพ์หมายเลขสไลด์, ป้ายแทร็ก, บรรทัดเวลาเดิม, และคำบรรยายเต็มรูป

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("captioned_media.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const shapes = slide.getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                continue;
            }

            const tracks = shape.getCaptionTracks();
            for (let trackIndex = 0; trackIndex < tracks.getCount(); trackIndex++) {
                const track = tracks.get_Item(trackIndex);
                const lines = track.getDataAsString().split(/\r\n|\n|\r/);
                for (let i = 0; i < lines.length; i++) {
                    const timing = lines[i];
                    if (!timing.includes("-->")) {
                        continue;
                    }
                    const start = i + 1;
                    i = start;
                    while (i < lines.length && lines[i] !== "") {
                        i++;
                    }
                    const caption = lines.slice(start, i).join("\n");
                    if (caption.toLowerCase().includes("café")) {
                        console.log(`Slide ${slide.getSlideNumber()} | ${track.getLabel()} | ${timing}`);
                        console.log(caption);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

การค้นหา “café” พบผลลัพธ์หนึ่งในแทร็กตัวอย่าง การค้นหาจะข้ามหัวแทร็กและคงการตั้งค่ากาลเวลาและการขึ้นบรรทัดในผลลัพธ์

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **ดึงวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอไปยังสไลด์แล้ว Aspose.Slides ยังอนุญาตให้คุณดึงวิดีโอที่ฝังอยู่ในงานนำเสนอ

ตัวอย่างนี้ดึงวิดีโอที่ฝังจากทุกสไลด์เป็นไฟล์ไบนารีที่แยกและมีหมายเลข วิดีโอที่ลิงก์จะถูกข้ามเพราะไม่มีข้อมูลที่ฝัง คอนโซลพิมพ์ประเภท MIME ของแต่ละวิดีโอและจำนวนทั้งหมด ผลลัพธ์ใช้ส่วนขยาย `.bin` ทั่วไป; สามารถเปลี่ยนเป็นส่วนขยายที่ตรงกับประเภทสื่อที่รายงานได้หากต้องการ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนแปลงได้สำหรับเฟรมวิดีโอ?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) ตัวเลือกเหล่านี้สามารถใช้ได้ผ่านเมธอดของวัตถุ [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**

มี ผลเมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบเนอรีจะถูกใส่ในเอกสาร ดังนั้นขนาดงานนำเสนอจะเพิ่มตามขนาดไฟล์ เมื่อคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มรูปภาพย่อ งานนำเสนอจะเก็บลิงก์และภาพตัวอย่างแทนข้อมูลวิดีโอ ดังนั้นขนาดอาจะเพิ่มน้อยกว่า

**ฉันสามารถแทนที่วิดีโอในเฟรมวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ทำได้ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) ภายในเฟรมในขณะที่รักษาเรขาคณิตของรูปทรงไว้ ซึ่งเป็นกรณีทั่วไปสำหรับการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังไว้ได้หรือไม่?**

ได้ วิดีโอที่ฝังจะมี [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) ซึ่งคุณสามารถอ่านและใช้ได้ ตัวอย่างเช่นเมื่อต้องการบันทึกลงดิสก์