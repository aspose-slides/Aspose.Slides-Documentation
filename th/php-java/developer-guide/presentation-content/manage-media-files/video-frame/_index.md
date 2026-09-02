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
- สกัดวิดีโอ
- ดึงวิดีโอ
- เฟรมวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและสกัดเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างอัตโนมัติโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java คำแนะนำสั้นๆ ที่รวดเร็ว"
---
## **บทนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมของผู้ชมได้  

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอในเครื่อง (จัดเก็บบนคอมพิวเตอร์ของคุณ)
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube)

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วิดีโออ็อบเจ็กต์) ลงในงานนำเสนอ Aspose.Slides จัดให้มีคลาส [Video](https://reference.aspose.com/slides/th/php-java/aspose.slides/video/) , คลาส [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ

## **สร้างเฟรมวิดีโอแบบฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์จัดเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอนั้นในงานนำเสนอของคุณได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
1. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/php-java/aspose.slides/video/) แล้วส่งพาธของไฟล์วิดีโอเพื่อฝังวิดีโอเข้ากับงานนำเสนอ  
1. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) เพื่อสร้างเฟรมสำหรับวิดีโอ  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด PHP ตัวนี้แสดงวิธีเพิ่มวิดีโอที่จัดเก็บไว้ในเครื่องลงในงานนำเสนอ:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # โหลดวิดีโอ
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # ดึงสไลด์แรกและเพิ่มเฟรมวิดีโอ
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # บันทึกงานนำเสนอลงดิสก์
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

หรือคุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์โดยตรงไปยังเมธอด [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addvideoframe/) :

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

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) รองรับวิดีโอ YouTube ในงานนำเสนอ หากวิดีโอที่คุณต้องการใช้มีอยู่บนออนไลน์ (เช่นบน YouTube) คุณสามารถเพิ่มลงในงานนำเสนอผ่านลิงก์เว็บของมันได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
1. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/php-java/aspose.slides/video/) แล้วส่งลิงก์ของวิดีโอ  
1. ตั้งค่านามสกุลภาพ (thumbnail) สำหรับเฟรมวิดีโอ  
1. บันทึกงานนำเสนอ  

โค้ด PHP ตัวนี้แสดงวิธีเพิ่มวิดีโอจากเว็บลงในสไลด์ของงานนำเสนอ PowerPoint:

```php
  # สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
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

## **ตัดเฟรมวิดีโอ**

Aspose.Slides อนุญาตให้คุณควบคุมส่วนที่ทำการเล่นของวิดีโอโดยตั้งค่า trim‑from‑start และ trim‑from‑end ผ่านเมธอด [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#setTrimFromStart) และ [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#setTrimFromEnd) ค่าทั้งสองระบุเป็นมิลลิ–วินาทีและกำหนดระยะเวลาที่ข้ามจากจุดเริ่มต้นและจุดสิ้นสุดของวิดีโอตามลำดับ การตั้งค่านี้เปลี่ยนการตั้งค่าการเล่นวิดีโอในงานนำเสนอ; ไม่ได้ตัดหรือแก้ไขข้อมูลไบนารีของวิดีโอที่ฝังอยู่  

**ตั้งค่าการตัด**

เพื่อสร้างเฟรมวิดีโอและตั้งค่าการตัดของมัน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/php-java/aspose.slides/video/) ลงในงานนำเสนอ  
1. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) ลงบนสไลด์  
1. ตั้งค่า trim‑from‑start และ trim‑from‑end ผ่านเมธอด [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#setTrimFromStart) และ [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#setTrimFromEnd)  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่างโค้ดต่อไปนี้ข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายของวิดีโอที่ฝังไว้ระหว่างการเล่น:

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**อ่านการตั้งค่าการตัด**

เพื่ออ่านการตั้งค่าการตัดที่มีอยู่ ให้โหลดงานนำเสนอ ค้นหาอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) ในรูปทรงของสไลด์แรก แล้วอ่านค่าผ่านเมธอด [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#getTrimFromStart) และ [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#getTrimFromEnd)  

โค้ดตัวอย่างต่อไปนี้ค้นหาเฟรมวิดีโอแรกบนสไลด์แรกและรายงานค่าการตัดเป็นมิลลิ–วินาที:

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides อนุญาตให้คุณจัดการคำบรรยายปิด (closed captions) สำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านเมธอด [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#getCaptionTracks)  

**เพิ่มคำบรรยายให้กับเฟรมวิดีโอ**

เพื่อเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. เพิ่มวิดีโอลงในงานนำเสนอ  
1. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) ลงบนสไลด์  
1. ใช้คอลเลกชัน [CaptionsCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/) ที่คืนค่าจากเมธอด [getCaptionTracks](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#getCaptionTracks) เพื่อเพิ่มแทร็กคำบรรยาย WebVTT  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

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

คลาส [CaptionsCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้ด้วย  

**สกัดคำบรรยายจากเฟรมวิดีโอ**

เพื่อสกัดคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโออยู่  
1. ค้นหาอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) ที่ต้องการ  
1. วนลูปผ่านคอลเลกชันที่ได้จาก [getCaptionTracks](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#getCaptionTracks)  
1. บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ `.vtt`  

โค้ดต่อไปนี้แสดงวิธีสกัดคำบรรยายจากเฟรมวิดีโอ:

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

แต่ละอ็อบเจ็กต์ [Captions](https://reference.aspose.com/slides/th/php-java/aspose.slides/captions/) เปิดเผยตัวระบุคำบรรยาย, ป้ายชื่อ, ข้อมูลไบนารีและข้อความคำบรรยายเป็นสตริง UTF‑8  

**ลบคำบรรยายจากเฟรมวิดีโอ**

เพื่อทำการลบคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโออยู่  
1. รับอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) ที่ต้องการ  
1. ลบแทร็กคำบรรยายจากคอลเลกชันที่ได้จาก [getCaptionTracks](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/#getCaptionTracks)  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ดต่อไปนี้แสดงวิธีลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // ประเภท: VideoFrame

    // ลบคำบรรยายทั้งหมดออกจากเฟรมวิดีโอ
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หากต้องการลบแทร็กคำบรรยายเพียงหนึ่งแทร็ก ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/#removeAt) แทนการใช้ [clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/#clear)

## **สกัดวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอเข้าสไลด์แล้ว Aspose.Slides ยังอนุญาตให้คุณสกัดวิดีโอที่ฝังอยู่ในงานนำเสนอได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) เพื่อโหลดงานนำเสนอที่มีวิดีโออยู่  
2. วนลูปผ่านอ็อบเจ็กต์ [Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/) ทั้งหมด  
3. วนลูปผ่านอ็อบเจ็กต์ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/)  
4. บันทึกวิดีโอลงดิสก์  

โค้ด PHP ตัวนี้แสดงวิธีสกัดวิดีโอจากสไลด์ของงานนำเสนอ:

```php
  # สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # รับส่วนขยายของไฟล์
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

## **FAQ**

**พารามิเตอร์การเล่นวิดีโอใดที่สามารถเปลี่ยนแปลงได้สำหรับ VideoFrame?**  

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/setplaymode/) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/setplayloopmode/) ได้ ตัวเลือกเหล่านี้สามารถตั้งค่าผ่านคุณสมบัติของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/)  

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**  

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีของวิดีโอจะถูกรวมอยู่ในเอกสาร ดังนั้นขนาดงานนำเสนอจะเพิ่มตามขนาดไฟล์ของวิดีโอ เมื่อคุณเพิ่มวิดีโอออนไลน์ เพียงแค่ฝังลิงก์และภาพย่อขนาดการเพิ่มจึงน้อยกว่า  

**ฉันสามารถแทนที่วิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**  

ใช่ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/setembeddedvideo/) ภายในเฟรมโดยคงรูปทรงเดิมไว้ ซึ่งเป็นกรณีทั่วไปสำหรับการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่  

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังอยู่ได้หรือไม่?**  

ใช่ วิดีโอที่ฝังอยู่มี [content type](https://reference.aspose.com/slides/th/php-java/aspose.slides/video/getcontenttype/) ที่คุณสามารถอ่านและใช้ได้ ตัวอย่างเช่นเมื่อต้องการบันทึกลงดิสก์  