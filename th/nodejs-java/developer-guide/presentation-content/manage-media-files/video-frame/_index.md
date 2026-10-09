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
- สกัดวิดีโอ
- ดึงวิดีโอ
- เฟรมวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและสกัดเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมโดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java คู่มือวิธีทำที่รวดเร็ว"
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้ Aspose.Slides สำหรับ Node.js ผ่าน Java ให้คุณเพิ่มเฟรมวิดีโอลงในสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และสกัดข้อมูลวิดีโอที่ฝังอยู่  

PowerPoint รองรับวิดีโอที่อยู่ในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอจาก YouTube  

เพื่อแสดงข้อมูลวิดีโอและเฟรมวิดีโอ Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) , คลาส [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) และประเภทอื่น ๆ ที่เกี่ยวข้อง  

## **สร้างเฟรมวิดีโอที่ฝังไว้**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์อยู่ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอในงานนำเสนอของคุณได้  

ตัวอย่างนี้ฝังวิดีโอในเครื่องบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของเฟรมใช้หน่วยจุด สตรีมจะเปิดค้างไว้จนกว่าจะบันทึกเสร็จ เพราะ [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) ทำให้มันล็อกไว้ขณะงานนำเสนอใช้งาน  

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

คุณยังสามารถส่งเส้นทางวิดีโอในเครื่องโดยตรงไปยังเมธอด [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). ตัวอย่างนี้ฝังวิดีโอบนสไลด์แรกของงานนำเสนอใหม่ วิดีโอจะต้องยังคงเข้าถึงได้จนกว่าจะบันทึกงานนำเสนอ  

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

## **สร้างเฟรมวิดีโอจากแหล่งวิดีโอบนเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างเฟรมวิดีโอที่ลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอจาก YouTube  

ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และรูปย่อไปยังสไลด์แรก แทนที่ตัวระบุวิดีโอเพื่อใช้วิดีโออื่น ๆ เมธอด [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) เรียกร้องให้เล่นอัตโนมัติ การดาวน์โหลดรูปย่อและการเล่นวิดีโอต้องการการเชื่อมต่ออินเทอร์เน็ต ตัวแสดงงานนำเสนอจะต้องสนับสนุนการเล่นวิดีโอออนไลน์ด้วย  

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

## **เล่นวิดีโอในโหมดเต็มจอ**

ในการนำเสนอการฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มจอเพื่อให้ผู้ชมมองเห็นรายละเอียด เรียกเมธอด [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) ด้วยค่า `true` เพื่อเปิดการทำงานนี้ระหว่างการเล่น  

ตัวอย่างนี้เปิดงานนำเสนอค้นหา [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) แรกบนสไลด์แรกและเปิดการเล่นแบบเต็มจอ งานนำเข้าจะต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก  

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

การเล่นแบบเต็มจอควบคุมวิธีการแสดงวิดีโอ อย่างอิสระเมธอด [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) ควบคุมว่าจะแสดงอัตโนมัติหรือเมื่อคลิก และเมธอด [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) ควบคุมว่าจะแสดงซ้ำหรือไม่ เพื่อเลือกพฤติกรรมการเริ่ม ให้ตั้งโหมดการเล่นเป็น [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). ตัวอย่างนี้รักษาการตั้งค่าเริ่มต้นและการวนซ้ำเดิมไว้  

## **ย้อนกลับวิดีโหลังจากเล่น**

ในการนำเสนอการฝึกอบรม การนำวิดีโอสาธิตกลับไปที่จุดเริ่มต้นทำให้พร้อมให้ผู้นำเสนอเล่นอีกครั้ง เรียกเมธอด [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) ด้วยค่า `true` เพื่อคืนวิดีโอไปที่จุดเริ่มต้นหลังจากการเล่นเสร็จ  

ตัวอย่างนี้เปิดงานนำเสนอค้นหา [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) แรกบนสไลด์แรกและเปิดการย้อนกลับ ปิดการวนซ้ำเพื่อให้การเล่นเสร็จสิ้นและตั้งให้เริ่มเล่นเมื่อคลิก งานนำเข้าจะต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก  

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

การย้อนกลับจะคืนวิดีโอไปที่จุดเริ่มต้นโดยไม่เริ่มเล่นใหม่ ในทางกลับกันการเรียก [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) ด้วยค่า `true` จะทำให้การเล่นวนซ้ำอัตโนมัติ ปิดการวนซ้ำเมื่อต้องการให้วิดีโอเล่นจนจบและพร้อมเล่นใหม่ [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) ควบคุมการเริ่มอัตโนมัติหรือเมื่อคลิกแยกกัน; ตัวอย่างนี้ใช้ [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) เพื่อให้ผู้นำเสนอควบคุมเวลาที่เริ่มเล่น ตั้งค่าโหมดการเล่นหลังจากตั้งค่าการวนซ้ำตามที่แสดงในตัวอย่าง การย้อนกลับทำงานแยกจาก [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/)  

## **ตัดส่วนของเฟรมวิดีโอ**

ใช้เมธอด [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) และ [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) เพื่อตัดส่วนต้นหรือส่วนท้ายของวิดีโอระหว่างการเล่น ค่าเป็นมิลลิวินาที การตัดเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังอยู่  

**ตั้งค่าการตัด**  

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายระหว่างการเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้เหลือส่วนที่สามารถเล่นได้  

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

**อ่านค่าการตัด**  

ตัวอย่างนี้พิมพ์ค่าการตัดของเฟรมวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีเฟรมวิดีโอจะไม่มีการพิมพ์ ตัวอย่างก่อนหน้าสร้างค่าเป็น 2500 และ 1000  

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

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายถูกจัดเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านเมธอด [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks)  

**เพิ่มคำบรรยายให้กับเฟรมวิดีโอ**  

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทร็กคำบรรยาย WebVTT ที่มีป้ายชื่อ English ค่าตำแหน่งเวลาในคำบรรยายควรตรงกับวิดีโอ งานนำเสนอที่บันทึกจะรวมวิดีโอและคำบรรยายไว้ด้วยกัน  

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

**สกัดคำบรรยายจากเฟรมวิดีโอ**  

ตัวอย่างนี้บันทึกแทร็กคำบรรยายทั้งหมดจากเฟรมวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกกัน ใช้ตัวเลขต่อเนื่องเพื่อแยกไฟล์ผลลัพธ์ คอนโซลจะแสดงจำนวนแทร็กที่สกัด งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์  

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

แต่ละอ็อบเจ็กต์ [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) เปิดเผยตัวระบุคำบรรยาย ป้ายชื่อ ข้อมูลไบนารี และข้อความคำบรรยายในรูปแบบสตริง UTF-8  

**ลบคำบรรยายจากเฟรมวิดีโอ**  

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอที่ตำแหน่งรูปร่างแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่าสไลด์และรูปร่างมีอยู่และรูปร่างนั้นเป็นเฟรมวิดีโอ  

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

หากต้องการลบแทร็กคำบรรยายเพียงหนึ่งแทร็ก ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) แทนการใช้ [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear)  

## **สกัดวิดีโอจากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอลงสไลด์ Aspose.Slides ยังอนุญาตให้สกัดวิดีโอที่ฝังอยู่ในงานนำเสนอ  

ตัวอย่างนี้สกัดวิดีโอที่ฝังอยู่จากทุกสไลด์เป็นไฟล์ไบนารีแยกตามลำดับเลข วิดีโอที่ลิงก์จะถูกข้ามเพราะไม่มีข้อมูลฝัง คอนโซลจะแสดงประเภท MIME ของแต่ละวิดีโอและจำนวนทั้งหมด ผลลัพธ์ใช้ส่วนขยาย `.bin` ทั่วไป; สามารถเปลี่ยนเป็นส่วนขยายที่ตรงกับประเภทสื่อที่รายงานได้เมื่อจำเป็น  

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

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดที่สามารถเปลี่ยนแปลงสำหรับเฟรมวิดีโอได้?**  

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) ตัวเลือกเหล่านี้สามารถใช้ได้ผ่านเมธอดของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)  

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**  

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกบรรจุในเอกสารทำให้ขนาดงานนำเสนอเพิ่มขึ้นตามขนาดไฟล์ เมื่อคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มรูปย่อ งานนำเสนอจะเก็บลิงก์และภาพตัวอย่างแทนข้อมูลวิดีโอ ดังนั้นการเพิ่มขนาดจะมักจะน้อยกว่า  

**ฉันสามารถแทนที่วิดีโอในเฟรมวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**  

ได้ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) ภายในเฟรมโดยคงรูปทรงของรูปร่างไว้ นี่เป็นกรณีทั่วไปสำหรับการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่  

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังอยู่ได้หรือไม่?**  

ได้ วิดีโอที่ฝังอยู่มี [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) ที่คุณสามารถอ่านและใช้ได้ เช่น เมื่อต้องการบันทึกลงดิสก์