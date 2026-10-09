---
title: จัดการเฟรมวิดีโอในงานนำเสนอโดยใช้ PHP
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
description: "เรียนรู้วิธีเพิ่มและสกัดเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างโปรแกรมโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java อย่างรวดเร็วในคู่มือวิธีทำ"
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้ Aspose.Slides สำหรับ PHP ผ่าน Java ช่วยให้คุณสามารถเพิ่มเฟรมวิดีโอลงในสไลด์ ปรับการตั้งค่าการเล่นจัดการคำบรรยาย และสกัดข้อมูลวิดีโอที่ฝังไว้

PowerPoint รองรับวิดีโอที่อยู่ในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

เพื่อแสดงข้อมูลวิดีโอและเฟรมวิดีโอ Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) คลาส [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ

## **สร้างเฟรมวิดีโอที่ฝังอยู่**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มในสไลด์จัดเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอนั้นในงานนำเสนอของคุณได้

ตัวอย่างนี้ฝังวิดีโอในเครื่องบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของเฟรมใช้หน่วยจุด สตรีมจะเปิดอยู่จนกว่าการบันทึกจะเสร็จสิ้น เพราะ [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) ทำให้ล็อกไว้ในขณะที่งานนำเสนอใช้งาน

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

คุณยังสามารถส่งพาธวิดีโอในเครื่องโดยตรงไปยัง [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame) ตัวอย่างนี้ฝังวิดีโอบนสไลด์แรกของงานนำเสนอใหม่ วิดีโอจะต้องยังสามารถเข้าถึงได้จนกว่าจะบันทึกงานนำเสนอ

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **สร้างเฟรมวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างเฟรมวิดีโอที่ลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และรูปย่อบนสไลด์แรก แทนที่ตัวระบุวิดีโอเพื่อใช้วิดีโออื่น [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) ทำให้เล่นอัตโนมัติ การดาวน์โหลดรูปย่อและการเล่นวิดีโอต้องการการเชื่อมต่ออินเทอร์เน็ต ตัวดูงานนำเสนอจะต้องรองรับการเล่นวิดีโอออนไลน์ด้วย

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **เล่นวิดีโอในโหมดเต็มหน้าจอ**

ในงานนำเสนอการฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มหน้าจอเพื่อให้ผู้ชมเห็นรายละเอียด เรียก [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) พร้อมค่า `true` เพื่อเปิดใช้งานพฤติกรรมนี้ระหว่างการเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) แรกบนสไลด์แรกและเปิดใช้งานการเล่นเต็มหน้าจอ งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การเล่นเต็มหน้าจอกำหนดวิธีการแสดงวิดีโอ โดยแยกกัน [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) กำหนดว่าจะเริ่มอัตโนมัติหรือเมื่อคลิก และ [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) กำหนดว่าจะวนซ้ำหรือไม่ เพื่อเลือกพฤติกรรมการเริ่มต้น ให้ตั้งโหมดการเล่นเป็น [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) ตัวอย่างนี้รักษาการตั้งค่าเริ่มต้นและการวนซ้ำที่มีอยู่

## **รีเวิร์ดวิดีโอหลังการเล่น**

ในงานนำเสนอการฝึกอบรม การนำวิดีโอสาธิตกลับไปที่จุดเริ่มทำให้พร้อมสำหรับผู้บรรยายที่จะเล่นอีกครั้ง เรียก [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) พร้อมค่า `true` เพื่อให้วิดีือกลับไปที่จุดเริ่มต้นหลังจากการเล่นเสร็จ

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) แรกบนสไลด์แรกและเปิดใช้งานการรีเวิร์ด ปิดการวนซ้ำเพื่อให้การเล่นจบลงและตั้งให้เริ่มเมื่อคลิก งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การรีเวิร์ดจะคืนวิดีโอไปที่จุดเริ่มต้นโดยไม่เริ่มใหม่ ในทางตรงกันข้าม การเรียก [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) พร้อมค่า `true` จะทำให้การเล่นวนซ้ำโดยอัตโนมัติ ให้ปิดการวนซ้ำเมื่อคุณต้องการให้วิดีโอจบและพร้อมสำหรับการเล่นใหม่ [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) ควบคุมการเริ่มอัตโนมัติหรือเมื่อคลิกโดยอิสระ ตัวอย่างนี้ใช้ [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) เพื่อให้ผู้บรรยายควบคุมเวลาที่การเล่นเริ่ม ตั้งโหมดการเล่นหลังจากตั้งค่าการวนซ้ำ ตามที่แสดงในตัวอย่าง การรีเวิร์ดทำงานแยกจาก [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **ตัดเฟรมวิดีโอ**

ใช้ [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) และ [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) เพื่อข้ามส่วนต้นหรือส่วนท้ายของวิดีโอระหว่างการเล่น ค่าเป็นมิลลิวินาที การตัดเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังอยู่

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายระหว่างการเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้เหลือส่วนที่เล่นได้

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**อ่านการตั้งค่าการตัด**

ตัวอย่างนี้พิมพ์ค่าการตัดของเฟรมวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีเฟรมวิดีโอ จะไม่มีการพิมพ์ ตัวอย่างก่อนหน้านี้ให้ค่าที่ 2500 และ 1000

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านเมธอด [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks)

**เพิ่มคำบรรยายให้เฟรมวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทรกคำบรรยาย WebVTT ที่มีป้ายกำกับเป็น English เวลาตัวบรรยายควรตรงกับวิดีโอ งานนำเสนอที่บันทึกจะรวมทั้งวิดีโอและคำบรรยาย

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

คลาส [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) ยังมีโอเวอร์โหลดที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้

**สกัดคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้บันทึกแทรกคำบรรยายทั้งหมดจากเฟรมวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกกัน ตัวเลขลำดับทำให้ไฟล์ผลลัพธ์แตกต่างกัน คอนโซลจะรายงานจำนวนแทรกที่สกัดได้ งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

แต่ละอ็อบเจ็กต์ [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) แสดงตัวระบุคำบรรยาย ป้ายกำกับ ข้อมูลไบนารี และข้อความคำบรรยายในรูปแบบสตริง UTF-8

**ลบคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอตำแหน่งรูปร่างแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างเป็นเฟรมวิดีโอ

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หากต้องการลบแค่แทรกคำบรรยายเดียว ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) แทนการใช้ [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear)

## **สกัดวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอลงสไลด์แล้ว Aspose.Slides ยังให้คุณสกัดวิดีโอที่ฝังอยู่ในงานนำเสนอ

ตัวอย่างนี้สกัดวิดีโอที่ฝังจากทุกสไลด์เป็นไฟล์ไบนารีแยกตามหมายเลข วิดีโอที่ลิงก์จะถูกข้ามเพราะไม่มีข้อมูลฝัง คอนโซลพิมพ์ประเภท MIME ของแต่ละวิดีโอและจำนวนทั้งหมด ผลลัพธ์ใช้ส่วนขยาย `.bin` ทั่วไป; ให้เปลี่ยนเป็นส่วนขยายที่ตรงกับประเภทสื่อที่รายงานเมื่อจำเป็น

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดที่สามารถเปลี่ยนได้สำหรับเฟรมวิดีโอ?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) ตัวเลือกเหล่านี้พร้อมให้ใช้ผ่านเมธอดของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกรวมอยู่ในเอกสาร ทำให้ขนาดงานนำเสนอเพิ่มตามขนาดไฟล์ เมื่อคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มรูปย่อ งานนำเสนอจะเก็บลิงก์และภาพตัวอย่างแทนข้อมูลวิดีโอ ดังนั้นการเพิ่มขนาดมักจะน้อยกว่า

**ฉันสามารถแทนที่วิดีโอในเฟรมวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ได้ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) ภายในเฟรมโดยยังคงรักษาเรขาคณิตของรูปร่างไว้ นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเค้าโครงที่มีอยู่

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังได้หรือไม่?**

ได้ วิดีโอที่ฝังมี [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) ที่คุณสามารถอ่านและใช้ได้ เช่นเมื่อต้องการบันทึกลงดิสก์