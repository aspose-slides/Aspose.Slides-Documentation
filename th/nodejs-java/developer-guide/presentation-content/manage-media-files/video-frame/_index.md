---
title: จัดการเฟรมวิดีโอในงานนำเสนอด้วย JavaScript
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
description: "เรียนรู้วิธีการเพิ่มและดึงเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมโดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java. คู่มือสั้นเร็ว"
---
## **แนะนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณ  

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของการนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอในเครื่อง (เก็บไว้ในเครื่องของคุณ)
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube).

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วัตถุวิดีโอ) ลงในงานนำเสนอ Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/video/), [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) และชนิดที่เกี่ยวข้องอื่น ๆ

## **สร้างเฟรมวิดีโอที่ฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ถูกจัดเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอในงานนำเสนอได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/video/) และส่งพาธไฟล์วิดีโอเพื่อฝังวิดีโอลงในงานนำเสนอ
4. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) เพื่อสร้างเฟรมสำหรับวิดีโอ
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด JavaScript นี้แสดงวิธีเพิ่มวิดีโอที่จัดเก็บในเครื่องลงในงานนำเสนอ:

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

หรือคุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์ของมันโดยตรงไปยังเมธอด [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-):

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

Microsoft [PowerPoint 2013 และรุ่นใหม่กว่า](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) รองรับวิดีโอ YouTube ในการนำเสนอ หากวิดีโอที่คุณต้องการใช้มีออนไลน์ (เช่นบน YouTube) คุณสามารถเพิ่มลงในงานนำเสนอผ่านลิงก์เว็บของมันได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/video/) และส่งลิงก์ของวิดีโอ
4. ตั้งค่า thumbnail สำหรับเฟรมวิดีโอ
5. บันทึกงานนำเสนอ

โค้ด JavaScript นี้แสดงวิธีเพิ่มวิดีโอจากเว็บลงในสไลด์ของการนำเสนอ PowerPoint:

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

## **ตัดเฟรมวิดีโอ**

Aspose.Slides อนุญาตให้คุณควบคุมส่วนที่เล่นของวิดีโิโดยกำหนดค่าตัดจากจุดเริ่มต้นและจุดสิ้นสุดผ่าน [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/settrimfromstart/) และ [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/settrimfromend/). ค่าทั้งสองระบุเป็นมิลลิวินาทีและกำหนดจำนวนเวลาที่ข้ามจากจุดเริ่มและจุดสิ้นสุดของวิดีโอตามลำดับ การตั้งค่านี้เปลี่ยนการตั้งค่าการเล่นวิดีโอในงานนำเสนอ; ไม่ได้ตัดหรือแก้ไขข้อมูลไบนารีของวิดีโอที่ฝังอยู่

**ตั้งค่าการตัด**

เพื่อสร้างเฟรมวิดีโอและตั้งค่าการตัดของมัน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/video/) ลงในงานนำเสนอ
3. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) ลงในสไลด์
4. ตั้งค่าตัดจากจุดเริ่มต้นและจุดสิ้นสุดผ่าน [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/settrimfromstart/) และ [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/settrimfromend/)
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างโค้ดต่อไปนี้จะข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายของวิดีโอที่ฝังอยู่ระหว่างการเล่น:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**อ่านการตั้งค่าการตัด**

เพื่อตรวจสอบการตั้งค่าตัดที่มีอยู่ ให้โหลดงานนำเสนอ ค้นหาอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) parmi รูปทรงบนสไลด์แรก และอ่านค่าผ่าน [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) และ [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/gettrimfromend/)

ตัวอย่างโค้ดต่อไปนี้จะค้นหาเฟรมวิดีโอแรกบนสไลด์แรกและรายงานค่าการตัดของมันเป็นมิลลิวินาที:

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides อนุญาตให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และเปิดเผยผ่านเมธอด [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/#getCaptionTracks)

**เพิ่มคำบรรยายลงในเฟรมวิดีโอ**

เพื่อเพิ่มคำบรรยายลงในเฟรมวิดีโอ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เพิ่มวิดีโอลงในงานนำเสนอ
3. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) ลงในสไลด์
4. ใช้คอลเลกชัน [CaptionsCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/) เพื่อเพิ่มแทร็กคำบรรยาย WebVTT
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดต่อไปนี้แสดงวิธีเพิ่มคำบรรยายลงในเฟรมวิดีโอ:

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

คลาส [CaptionsCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/) ยังมีเมธอด [addFromStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/#addFromStream) ให้คุณเพิ่มคำบรรยายจากสตรีมได้

**ดึงคำบรรยายจากเฟรมวิดีโอ**

1. โหลดงานนำเสนอที่มีวิดีโออยู่
2. ค้นหาอ็อบเจ็กต์ [VideoFrame] เป้าหมาย
3. วนรอบผ่านคอลเลกชัน [CaptionsCollection]
4. บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ `.vtt`

โค้ดต่อไปนี้แสดงวิธีดึงคำบรรยายจากเฟรมวิดีโอ:

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

แต่ละอ็อบเจ็กต์ [Captions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captions/) เปิดเผยรหัสคำบรรยาย, ป้ายกำกับ, ข้อมูลไบนารี และข้อความคำบรรยายเป็นสตริง UTF‑8

**ลบคำบรรยายจากเฟรมวิดีโอ**

1. โหลดงานนำเสนอที่มีวิดีโออยู่
2. รับอ็อบเจ็กต์ [VideoFrame] เป้าหมาย
3. ลบแทร็กคำบรรยายจากคอลเลกชัน [CaptionsCollection]
4. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดต่อไปนี้แสดงวิธีลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // ประเภท: com.aspose.slides.VideoFrame

    // ลบคำบรรยายทั้งหมดออกจากเฟรมวิดีโอ.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากคุณต้องการลบเพียงแทร็กคำบรรยายเดียว ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/#removeAt) แทน [clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/captionscollection/#clear)

## **ดึงวิดีโอจากสไลด์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) เพื่อโหลดงานนำเสนอที่มีวิดีโอ
2. วนรอบผ่านอ็อบเจ็กต์ [Slide] ทั้งหมด
3. วนรอบผ่านอ็อบเจ็กต์ [Shape] ทั้งหมดเพื่อค้นหา [VideoFrame]
4. บันทึกวิดีโอลงดิสก์

โค้ด JavaScript นี้แสดงวิธีดึงวิดีโอจากสไลด์ของงานนำเสนอ:

```javascript
// สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์งานนำเสนอ
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
                // ดึงนามสกุลไฟล์
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

คุณสามารถควบคุม [โหมดการเล่น](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/setplaymode/) (อัตโนมัติหรือเมื่อคลิก) และ [การวนซ้ำ](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/setplayloopmode/) ได้ โดยตัวเลือกเหล่านี้สามารถกำหนดค่าได้ผ่านคุณสมบัติของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/)

**การเพิ่มวิดีโอกระทบขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกรวมไว้ในเอกสาร ดังนั้นขนาดงานนำเสนอจะเพิ่มขึ้นตามขนาดไฟล์ของวิดีโอ เมื่อคุณเพิ่มวิดีโอออนไลน์ เพียงลิงก์และ thumbnail จะถูกฝังไว้ ทำให้การเพิ่มขนาดไฟล์น้อยลง

**ฉันสามารถแทนที่วิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลียนตำแหน่งและขนาดได้หรือไม่?**

ใช่ คุณสามารถสลับ [เนื้อหาวิดีโอ](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) ภายในเฟรมโดยคงรูปทรงของ shape ไว้ ซึ่งเป็นสถานการณ์ทั่วไปสำหรับอัปเดตสื่อในเลย์เอาต์ที่มีอยู่

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังอยู่ได้หรือไม่?**

ใช่ วิดีโอที่ฝังอยู่มี [ประเภทเนื้อหา](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/video/getcontenttype/) ที่คุณสามารถอ่านและนำไปใช้ได้ ตัวอย่างเช่นเมื่อบันทึกลงดิสก์