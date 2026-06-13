---
title: จัดการเสียงในงานนำเสนอโดยใช้ PHP
linktitle: เฟรมเสียง
type: docs
weight: 10
url: /th/php-java/audio-frame/
keywords:
- เสียง
- เฟรมเสียง
- รูปภาพย่อ
- เพิ่มเสียง
- คุณสมบัติของเสียง
- ตัวเลือกเสียง
- สกัดเสียง
- PHP
- Aspose.Slides
description: "สร้างและควบคุมเฟรมเสียงใน Aspose.Slides สำหรับ PHP—ตัวอย่างโค้ดสำหรับฝัง, ตัด, เล่นวนซ้ำ, และกำหนดการเล่นในงานนำเสนอรูปแบบ PPT, PPTX, และ ODP."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับ audio frames ใน Aspose.Slides แสดงวิธีเพิ่ม audio ที่ฝังไว้ในสไลด์ ปรับแต่ง thumbnail ของ audio frame ตั้งค่าตัวเลือกการเล่น เช่น volume, looping, hiding, trimming และระยะเวลา fade รวมถึงการสกัด audio ที่ใช้ในการเปลี่ยนสไลด์โชว์

## **สร้าง Audio Frames**

Aspose.Slides for PHP via Java อนุญาตให้คุณเพิ่มไฟล์เสียงลงในสไลด์ ไฟล์เสียงจะถูกฝังในสไลด์เป็น audio frames

1. สร้างออบเจ็กต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. โหลดสตรีมไฟล์เสียงที่คุณต้องการฝังในสไลด์
4. เพิ่ม audio frame ที่ฝังไว้ (ซึ่งบรรจุไฟล์เสียง) ลงในสไลด์
5. ตั้งค่า [PlayMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/AudioPlayModePreset) และ `Volume` ที่เปิดเผยโดยอ็อบเจ็กต์ [AudioFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/)
6. บันทึก presentation ที่แก้ไขแล้ว

โค้ด PHP นี้แสดงวิธีเพิ่ม audio frame ที่ฝังไว้ลงในสไลด์:

```php
// สร้างออบเจ็กต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
$pres = new Presentation();
try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # โหลดไฟล์เสียง wav ไปสตรีม
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # เพิ่ม Audio Frame
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # ตั้งค่า Play Mode และ Volume ของ Audio
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # เขียนไฟล์ PowerPoint ไปยังดิสก์
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **เปลี่ยน Thumbnail ของ Audio Frame**

เมื่อคุณเพิ่มไฟล์เสียงลงใน presentation audio จะปรากฏเป็นกรอบพร้อมรูปภาพเริ่มต้นมาตรฐาน (ดูรูปในส่วนต่อไปนี้) คุณสามารถเปลี่ยนรูปภาพตัวอย่างของ audio frame (กำหนดรูปภาพที่ต้องการ)

โค้ด PHP นี้แสดงวิธีเปลี่ยน thumbnail หรือรูปภาพตัวอย่างของ audio frame:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# เพิ่ม audio frame ไปยังสไลด์โดยกำหนดตำแหน่งและขนาดที่ระบุ.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# เพิ่มรูปภาพไปยังแหล่งข้อมูลของ presentation.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# ตั้งค่าภาพสำหรับ audio frame.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# บันทึก presentation ที่แก้ไขแล้วลงดิสก์
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **เปลี่ยนตัวเลือกการเล่น Audio**

Aspose.Slides for PHP via Java อนุญาตให้คุณเปลี่ยนตัวเลือกที่ควบคุมการเล่นหรือคุณสมบัติต่าง ๆ ของ audio เช่น ปรับ volume ตั้งค่าให้ audio เล่นวนซ้ำ หรือแม้แต่ซ่อนไอคอน audio

แผง **Audio Options** ใน Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** ที่สอดคล้องกับคุณสมบัติของ Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/) :

- รายการดรอปดาวน์ **Start** ตรงกับเมธอด [AudioFrame::setPlayMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** ตรงกับเมธอด [AudioFrame::setVolume](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** ตรงกับเมธอด [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** ตรงกับเมธอด [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** ตรงกับเมธอด [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** ตรงกับเมธอด [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#setRewindAudio)

PowerPoint **Editing** options ที่สอดคล้องกับคุณสมบัติของ Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/) :

- **Fade In** ตรงกับเมธอด [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** ตรงกับเมธอด [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** ตรงกับเมธอด [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** มีค่าเท่ากับความยาวของ audio ลบค่าที่กำหนดโดยเมธอด [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#setTrimFromEnd)

ควบคุม **Volume** บนแผงควบคุม audio ของ PowerPoint สอดคล้องกับเมธอด [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#setVolumeValue) ซึ่งให้คุณเปลี่ยนระดับเสียงเป็นเปอร์เซ็นต์

วิธีการเปลี่ยนตัวเลือกการเล่น Audio:

1. [Сreate](#create-audio-frame) หรือรับ Audio Frame
2. ตั้งค่าค่าใหม่สำหรับคุณสมบัติของ Audio Frame ที่ต้องการปรับ
3. บันทึกไฟล์ PowerPoint ที่แก้ไขแล้ว

โค้ด PHP นี้สาธิตการปรับตัวเลือกของ audio:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # ดึงรูปทรง AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # ตั้งค่า Play mode ให้เล่นเมื่อคลิก
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # ตั้งค่า volume เป็น Low
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # ตั้งค่าให้เสียงเล่นต่อเนื่องผ่านหลายสไลด์
    $audioFrame->setPlayAcrossSlides(true);
    # ปิดการวนซ้ำของเสียง
    $audioFrame->setPlayLoopMode(false);
    # ซ่อน AudioFrame ระหว่างการแสดงสไลด์
    $audioFrame->setHideAtShowing(true);
    # รีวันเสียงกลับไปเริ่มต้นหลังการเล่น
    $audioFrame->setRewindAudio(true);
    # บันทึกไฟล์ PowerPoint ลงดิสก์
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

ตัวอย่าง PHP นี้แสดงวิธีเพิ่ม audio frame ใหม่พร้อม audio ฝังไว้ ตัดเวลาและกำหนดระยะเวลา fade:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // ตั้งค่าการตัดส่วนเริ่มต้นที่ 1.5 วินาที
    $audioFrame->setTrimFromStart(1500);
    // ตั้งค่าการตัดส่วนสิ้นสุดที่ 2 วินาที
    $audioFrame->setTrimFromEnd(2000);

    // ตั้งค่าความยาว fade-in ที่ 200 มิลลิวินาที
    $audioFrame->setFadeInDuration(200);
    // ตั้งค่าความยาว fade-out ที่ 500 มิลลิวินาที
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึง audio frame ที่ฝัง audio และตั้งค่า volume เป็น 85%:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // ดึงรูปทรง audio frame
    $audioFrame = $slide->getShapes()->get_Item(0);

    // ตั้งค่า volume ของ audio เป็น 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **จัดการ Audio Captions**

Aspose.Slides อนุญาตให้คุณเพิ่ม closed captions ให้กับ audio frame ผ่านเมธอด [getCaptionTracks](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#getCaptionTracks) เมธอดนี้คืนค่าเป็น [CaptionsCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/) ซึ่งให้คุณเพิ่ม WebVTT caption tracks, วนลูปผ่าน tracks ที่มีอยู่, และลบออกเมื่อจำเป็น

**Add Audio Captions**

ใช้เมธอด [getCaptionTracks](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/#getCaptionTracks) เพื่อต่อ caption tracks หนึ่งหรือหลายรายการกับ audio frame ตัวอย่างต่อไปนี้จะเพิ่มไฟล์เสียงลงในสไลด์ แล้วโหลด caption track ใหม่จากไฟล์ `.vtt`

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Extract Audio Captions**

คุณสามารถวนลูปผ่าน caption tracks ที่เชื่อมโยงกับ audio frame และบันทึกเป็นไฟล์ `.vtt` แต่ละ caption track จะเปิดเผยข้อมูลไบนารีและรหัสประจำตัวที่สามารถใช้เมื่อต้องการส่งออก captions

```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ .vtt.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Remove Audio Captions**

เพื่อลบ captions จาก audio frame ใช้วิธีการของ [CaptionsCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/) เช่น [clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/th/php-java/aspose.slides/captionscollection/#removeAt) ตัวอย่างต่อไปนี้ลบ caption tracks ทั้งหมดจาก audio frame

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // ประเภท: AudioFrame

    // ลบแทร็กคำบรรยายทั้งหมดจาก audio frame.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **สกัด Audio**

Aspose.Slides for PHP via Java อนุญาตให้คุณสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์ ตัวอย่างเช่น คุณสามารถสกัดเสียงที่ใช้ในสไลด์เฉพาะได้

1. สร้างออบเจ็กต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) และโหลด presentation ที่มี audio
2. รับอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เข้าถึง [slideshow transitions](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์
4. สกัดเสียงเป็นข้อมูลไบต์

โค้ดนี้แสดงวิธีสกัด audio ที่ใช้ในสไลด์:

```php
# สร้างออบเจ็กต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# เข้าถึงสไลด์ที่ต้องการ
	$slide = $pres->getSlides()->get_Item(0);
	# ดึงเอฟเฟกต์การเปลี่ยนสไลด์โชว์สำหรับสไลด์นี้
	$transition = $slide->getSlideShowTransition();
	# สกัดเสียงเป็นอาเรย์ไบต์
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถนำ audio asset เดิมมาใช้ซ้ำในหลายสไลด์โดยไม่ทำให้ไฟล์ขนาดใหญ่ขึ้นได้หรือไม่?**

ใช่ คุณสามารถเพิ่ม audio เพียงครั้งเดียวใน [audio collection](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getaudios/) ที่ใช้ร่วมกันของ presentation แล้วสร้าง audio frame เพิ่มเติมที่อ้างอิงไปยัง asset นั้น ซึ่งจะช่วยหลีกเลี่ยงการทำซ้ำข้อมูลสื่อและทำให้ขนาดของ presentation อยู่ในระดับที่ควบคุมได้

**ฉันสามารถแทนที่เสียงใน audio frame ที่มีอยู่โดยไม่ต้องสร้าง shape ใหม่ได้หรือไม่?**

ใช่ สำหรับเสียงที่เชื่อมโยง (linked) ให้อัปเดต [link path](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/setlinkpathlong/) ให้ชี้ไปยังไฟล์ใหม่ สำหรับเสียงที่ฝังไว้ (embedded) ให้สลับอ็อบเจ็กต์ [embedded audio](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/setembeddedaudio/) ด้วยออบเจ็กต์อื่นจาก [audio collection](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getaudios/) ของ presentation การจัดรูปแบบของกรอบและการตั้งค่าการเล่นส่วนใหญ่จะคงเดิม

**การตัด (trimming) ทำให้ข้อมูล audio ดั้งเดิมที่เก็บใน presentation เปลี่ยนแปลงหรือไม่?**

ไม่ การตัดเพียงปรับขอบเขตการเล่นเท่านั้น ไบต์ของ audio ดั้งเดิมจะไม่ถูกแก้ไขและยังคงสามารถเข้าถึงได้ผ่าน audio ที่ฝังไว้หรือ audio collection ของ presentation