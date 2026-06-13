---
title: จัดการเฟรมวิดีโอในงานนำเสนอโดยใช้ JavaScript
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
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและสกัดเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างโปรแกรมเมชันโดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java. คู่มือวิธีทำอย่างรวดเร็ว."
---
## **บทนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณ

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอในเครื่อง (เก็บไว้บนเครื่องของคุณ)
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube)

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วิดีโออ็อบเจ็กต์) ไปยังงานนำเสนอ, Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/video/) , คลาส [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ

## **สร้างเฟรมวิดีโอฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ของคุณถูกเก็บไว้ในเครื่อง, คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอลงในงานนำเสนอของคุณ

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)class.
2. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/video/) และส่งพาธไฟล์วิดีโอเพื่อฝังวิดีโอกับงานนำเสนอ. 
4. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) เพื่อสร้างเฟรมสำหรับวิดีโอ. 
5. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

โค้ด JavaScript นี้แสดงวิธีการเพิ่มวิดีโอที่เก็บไว้ในเครื่องลงในงานนำเสนอ:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // โหลดวิดีโอ
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // ดึงสไลด์แรกและเพิ่มเฟรมวิดีโอ
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

หรืออีกทางหนึ่ง, คุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์ของมันโดยตรงไปยังเมธอด [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **สร้างเฟรมวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) รองรับวิดีโอ YouTube ในงานนำเสนอ หากวิดีโอที่คุณต้องการใช้มีออนไลน์ (เช่นบน YouTube) คุณสามารถเพิ่มมันลงในงานนำเสนอของคุณผ่านลิงก์เว็บของมัน. 

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)class
2. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/video/) และส่งลิงก์ไปยังวิดีโอ. 
4. ตั้งค่า thumbnail สำหรับเฟรมวิดีโอ. 
5. บันทึกงานนำเสนอ. 

โค้ด JavaScript นี้แสดงวิธีการเพิ่มวิดีโอจากเว็บลงในสไลด์ของงานนำเสนอ PowerPoint:

```javascript
// สร้างอ็อบเจ็กต์ Presentation ที่แสดงถึงไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านเมธอด [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) .

**เพิ่มคำบรรยายลงในเฟรมวิดีโอ**

เพื่อเพิ่มคำบรรยายลงในเฟรมวิดีโอ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
2. เพิ่มวิดีโอลงในงานนำเสนอ. 
3. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) ลงในสไลด์. 
4. ใช้คอล렉ชัน [CaptionsCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/) เพื่อเพิ่มแทร็กคำบรรยาย WebVTT. 
5. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

โค้ดต่อไปนี้แสดงวิธีการเพิ่มคำบรรยายลงในเฟรมวิดีโอ:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

คลาส [CaptionsCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/) ยังมีเมธอด [addFromStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/#addFromStream) ที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้.

**สกัดคำบรรยายจากเฟรมวิดีโอ**

เพื่อสกัดคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ. 
2. ค้นหาอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) ที่ต้องการ. 
3. วนรอบผ่านคอล렉ชัน [CaptionsCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/). 
4. บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ `.vtt`. 

โค้ดต่อไปนี้แสดงวิธีสกัดคำบรรยายจากเฟรมวิดีโอ:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // บันทึกแทร็กคำบรรยายเป็นไฟล์ WebVTT.
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

แต่ละอ็อบเจ็กต์ [Captions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captions/) เปิดเผยตัวระบุคำบรรยาย, ป้าย, ข้อมูลไบนารี่, และข้อความคำบรรยายในรูปแบบสตริง UTF-8.

**ลบคำบรรยายจากเฟรมวิดีโอ**

เพื่อลบคำบรรยายนออกจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ. 
2. รับอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) ที่ต้องการ. 
3. ลบแทร็กคำบรรยายจากคอล렉ชัน [CaptionsCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/). 
4. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

โค้ดต่อไปนี้แสดงวิธีการลบคำบรรยายทั้งหมดออกจากเฟรมวิดีโอ:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // ประเภท: com.aspose.slides.VideoFrame

    // ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากคุณต้องการลบเพียงแทร็กคำบรรยายเดียว, ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/#removeAt) แทน [clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/#clear).

## **สกัดวิดีโอจากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอลงสไลด์, Aspose.Slides ยังให้คุณสกัดวิดีโอที่ฝังในงานนำเสนอ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) เพื่อโหลดงานนำเสนอที่มีวิดีโอ. 
2. วนรอบผ่านอ็อบเจ็กต์ [Slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/) ทั้งหมด. 
3. วนรอบผ่านอ็อบเจ็กต์ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/). 
4. บันทึกวิดีโอลงดิสก์. 

โค้ด JavaScript นี้แสดงวิธีสกัดวิดีโอบนสไลด์ของงานนำเสนอ:

```javascript
// สร้างอ็อบเจ็กต์ Presentation ที่แสดงถึงไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // ดึงส่วนขยายของไฟล์
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดที่สามารถเปลี่ยนแปลงได้สำหรับ VideoFrame?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/setplaymode/) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/setplayloopmode/) ได้ ตัวเลือกเหล่านี้สามารถใช้ได้ผ่านคุณสมบัติของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) .

**การเพิ่มวิดีโอส่งผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่. เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกใส่ในเอกสารทำให้ขนาดงานนำเสนอเพิ่มขึ้นตามขนาดไฟล์นั้น เมื่อคุณเพิ่มวิดีโอออนไลน์ จะฝังลิงก์และ thumbnail ไว้ ซึ่งการเพิ่มขนาดจะน้อยกว่า.

**ฉันสามารถแทนที่วิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ได้. คุณสามารถสลับ [video content](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) ภายในเฟรมโดยคงรูปทรงของ shape ไว้; นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลเอาต์ที่มีอยู่.

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังไว้ได้หรือไม่?**

ได้. วิดีโอที่ฝังไว้มี [content type](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/video/getcontenttype/) ที่คุณสามารถอ่านและใช้ได้, ตัวอย่างเช่นเมื่อบันทึกลงดิสก์.