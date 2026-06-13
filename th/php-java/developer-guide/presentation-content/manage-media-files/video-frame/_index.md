---
title: จัดการเฟรมวิดีโอในงานนำเสนอด้วย PHP
linktitle: เฟรมวิดีโอ
type: docs
weight: 10
url: /th/php-java/video-frame/
keywords:
- เพิ่มวิดีโอ
- สร้างวิดีโอ
- ฝังวิดีโอ
- ดึงวิดีโอ
- ดึงคืนวิดีโอ
- เฟรมวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและดึงเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java. คู่มือวิธีทำอย่างรวดเร็ว."
---
## **บทนำ**

วิดีโอที่วางไว้ในตำแหน่งที่เหมาะสมในการนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณ  

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของการนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอท้องถิ่น (จัดเก็บบนเครื่องของคุณ)  
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube)  

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วัตถุวิดีโอ) ลงในการนำเสนอ Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/th/php-java/aspose.slides/video/) , [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ  

## **สร้างเฟรมวิดีโอแบบฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ของคุณถูกจัดเก็บในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอลงในการนำเสนอของคุณได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มวัตถุ [Video](https://reference.aspose.com/slides/th/php-java/aspose.slides/video/) และส่งพาธไฟล์วิดีโอเพื่อฝังวิดีโอกับการนำเสนอ  
4. เพิ่มวัตถุ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) เพื่อสร้างเฟรมสำหรับวิดีโอ  
5. บันทึกการนำเสนอที่แก้ไขแล้ว  

โค้ด PHP นี้แสดงวิธีเพิ่มวิดีโอที่จัดเก็บในเครื่องลงในการนำเสนอ:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # โหลดวิดีโอ
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # ดึงสไลด์แรกและเพิ่ม videoframe
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # บันทึกการนำเสนอลงดิสก์
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

อีกทางเลือกหนึ่ง คุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์โดยตรงไปยังเมธอด [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addvideoframe/):

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **สร้างเฟรมวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint 2013 และใหม่กว่า](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) รองรับวิดีโอ YouTube ในการนำเสนอ หากวิดีโอที่คุณต้องการใช้มีออนไลน์ (เช่นบน YouTube) คุณสามารถเพิ่มลงในการนำเสนอของคุณผ่านลิงก์เว็บของมัน  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มวัตถุ [Video](https://reference.aspose.com/slides/th/php-java/aspose.slides/video/) และส่งลิงก์ไปยังวิดีโอ  
4. ตั้งค่า thumbnail สำหรับเฟรมวิดีโอ  
5. บันทึกการนำเสนอ  

โค้ด PHP นี้แสดงวิธีเพิ่มวิดีโอจากเว็บลงในสไลด์ของการนำเสนอ PowerPoint:

```php
  # สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides อนุญาตให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในการนำเสนอ PowerPoint คำบรรยายถูกจัดเก็บในรูปแบบ WebVTT และเปิดเผยผ่านเมธอด [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#getCaptionTracks)  

### **เพิ่มคำบรรยายให้กับเฟรมวิดีโอ**

เพื่อเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. เพิ่มวิดีโอลงในการนำเสนอ  
3. เพิ่มวัตถุ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) ลงในสไลด์  
4. ใช้คอล렉ชัน [CaptionsCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/) ที่คืนค่าจาก [getCaptionTracks](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#getCaptionTracks) เพื่อเพิ่มแทร็กคำบรรยาย WebVTT  
5. บันทึกการนำเสนอที่แก้ไขแล้ว  

โค้ดต่อไปนี้แสดงวิธีเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

คลาส [CaptionsCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้  

### **ดึงคำบรรยายจากเฟรมวิดีโอ**

เพื่อดึงคำบรรยายจากเฟรมวิดีโอ:  

1. โหลดการนำเสนอที่มีวิดีโออยู่  
2. ค้นหาอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) ที่ต้องการ  
3. วนลูปผ่านคอล렉ชัน [getCaptionTracks](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#getCaptionTracks)  
4. บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ `.vtt`  

โค้ดต่อไปนี้แสดงวิธีดึงคำบรรยายจากเฟรมวิดีโอ:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // บันทึกแทร็กคำบรรยายเป็นไฟล์ WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

แต่ละวัตถุ [Captions](https://reference.aspose.com/slides/th/php-java/aspose.slides/captions/) จะเปิดเผยรหัสประจำคำบรรยาย, ป้ายชื่อ, ข้อมูลไบนารี, และข้อความคำบรรยายเป็นสตริง UTF-8  

### **ลบคำบรรยายจากเฟรมวิดีโอ**

เพื่อทำการลบคำบรรยายจากเฟรมวิดีโอ:  

1. โหลดการนำเสนอที่มีวิดีโออยู่  
2. รับอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) ที่ต้องการ  
3. ลบแทร็กคำบรรยายจากคอล렉ชัน [getCaptionTracks](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#getCaptionTracks)  
4. บันทึกการนำเสนอที่แก้ไขแล้ว  

โค้ดต่อไปนี้แสดงวิธีลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // ประเภท: VideoFrame

    // ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หากคุณต้องการลบเฉพาะแทร็กคำบรรยายหนึ่งรายการ ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/#removeAt) แทน [clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/#clear)  

## **ดึงวิดีโอจากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอลงในสไลด์แล้ว Aspose.Slides ยังอนุญาตให้คุณดึงวิดีโอที่ฝังอยู่ในการนำเสนอได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) เพื่อโหลดการนำเสนอที่มีวิดีโออยู่  
2. วนลูปผ่านอ็อบเจ็กต์ [Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/) ทั้งหมด  
3. วนลูปผ่านอ็อบเจ็กต์ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/)  
4. บันทึกวิดีโอลงดิสก์  

โค้ด PHP นี้แสดงวิธีดึงวิดีโอจากสไลด์ของการนำเสนอ:

```php
  # สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # รับส่วนขยายไฟล์
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนแปลงได้สำหรับ VideoFrame?**  
คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/setplaymode/) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/setplayloopmode/). ตัวเลือกเหล่านี้สามารถใช้ได้ผ่านคุณสมบัติของวัตถุ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/)  

**การเพิ่มวิดีโอทำให้ขนาดไฟล์ PPTX เพิ่มขึ้นหรือไม่?**  
ใช่ เมื่อคุณฝังวิดีโอท้องถิ่น ไฟล์ข้อมูลไบนารีจะถูกใส่ในเอกสาร ดังนั้นขนาดการนำเสนอจะเพิ่มขึ้นตามขนาดของไฟล์นั้น เมื่อคุณเพิ่มวิดีโอออนไลน์ ลิงก์และภาพย่อจะถูกฝังไว้ ทำให้การเพิ่มขนาดน้อยลง  

**ฉันสามารถแทนที่วิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**  
ใช่ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/setembeddedvideo/) ภายในเฟรมขณะยังคงรักษาเรขาคณิตของรูปร่างไว้; นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเค้าโครงที่มีอยู่  

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังได้หรือไม่?**  
ใช่ วิดีโอที่ฝังไว้มี [content type](https://reference.aspose.com/slides/th/php-java/aspose.slides/video/getcontenttype/) ซึ่งคุณสามารถอ่านและใช้ได้ เช่นเมื่อต้องการบันทึกลงดิสก์