---
title: จัดการ Audio Frames ในงานนำเสนอโดยใช้ Python
linktitle: เฟรมเสียง
type: docs
weight: 10
url: /th/python-java/audio-frame/
keywords:
- เสียง
- เฟรมเสียง
- ภาพย่อ
- เพิ่มเสียง
- คุณสมบัติเสียง
- ตัวเลือกเสียง
- ดึงเสียง
- Python
- Aspose.Slides
description: "ฝังเสียงในสไลด์, เปลี่ยนไอคอนเสียง, กำหนดค่าการเล่น, จัดการคำบรรยาย WebVTT, และดึงเสียงการเปลี่ยนสไลด์ด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Audio frame ช่วยให้คุณสามารถเล่นเสียงบนสไลด์ได้ ด้วย Aspose.Slides for Python via Java คุณสามารถฝังคลิปเสียง เลือกรูปภาพที่แสดงแทน ปรับการเล่น และแนบคำบรรยายได้ คุณยังสามารถดึงเสียงที่กำหนดให้กับการเปลี่ยนสไลด์ได้อีกด้วย

## **สร้าง Audio Frames**

เพิ่มไบต์จาก `audio.wav` ลงในคอลเลกชันเสียงของงานนำเสนอ แล้วใช้ [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) เพื่อฝังคลิปเสียงท้องถิ่นบนสไลด์แรก พิกัดสองค่าต้นแรกกำหนดตำแหน่งของเฟรมบนสไลด์ และสองค่าถัดมากำหนดความกว้างและความสูง ทั้งหมดเป็นหน่วยจุด ตัวอย่างนี้เรียก [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) เพื่อให้คลิปเริ่มอัตโนมัติและเรียก [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) เพื่อเลือกระดับเสียงล่วงหน้า

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เปลี่ยน Thumbnail ของ Audio Frame**

โดยค่าเริ่มต้น Audio frame จะแสดงไอคอนลำโพง เพื่อแสดงภาพย่อที่กำหนดเอง ให้เพิ่มรูปภาพลงในงานนำเสนอด้วย [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) แล้วตั้งค่าให้กับรูปภาพของเฟรมด้วย [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) ตัวอย่างใช้ไฟล์ JPEG เป็นภาพย่อสำหรับคลิปเสียงที่ฝัง

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เปลี่ยนตัวเลือกการเล่นเสียง**

**Audio Options** ของ PowerPoint ควบคุมว่าเมื่อใดที่คลิปจะเริ่ม เล่นเสียงดังแค่ไหน และทำอย่างไรระหว่างการนำเสนอ

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| ควบคุมของ PowerPoint | วิธีของ Aspose.Slides for Python via Java |
| --- | --- |
| เริ่มต้น | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| ระดับเสียงล่วงหน้า | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| เล่นต่อเนื่องหลายสไลด์ | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| ทำซ้ำจนกว่าจะหยุด | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| ซ่อนในระหว่างการแสดง | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| เลื่อนกลับหลังการเล่น | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| ค่อยๆ ปรากฏ (Fade In) | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| ค่อยๆ จางหาย (Fade Out) | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| ตัดช่วงเริ่มต้นของเสียง | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| ตัดช่วงสิ้นสุดของเสียง | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| ตัวเลื่อนระดับเสียง | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

ตัวอย่างค้นหา audio frame แรกบนสไลด์แรก เรียก [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) เพื่อให้เริ่มเล่นเมื่อคลิก และเลือกระดับเสียงต่ำ ไอคอนจะถูกซ่อนระหว่างการแสดงและคลิปจะย้อนกลับหลังการเล่น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # เล่นเมื่อคลิกที่ระดับเสียงต่ำ, ครอบคลุมหลายสไลด์, ไม่ทำลูป.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # ซ่อนเฟรมระหว่างการแสดงสไลด์และย้อนกลับหลังการเล่น.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

สำหรับคลิปที่ยาวกว่า 3.5 วินาที ตัวอย่างนี้จะข้ามช่วงแรก 1.5 วินาทีและช่วงสุดท้าย 2 วินาที [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) รับค่าระยะเวลาที่ต้องตัดออกจากส่วนท้ายของคลิป เพื่อให้ได้เวลาสิ้นสุดที่แสดงใน PowerPoint ให้ลบค่าที่ตัดออกจากระยะเวลาทั้งหมดของคลิป คลิปที่ถูกตัดจะแสดงการค่อย ๆ ปรากฏใน 200 ms และค่อย ๆ จางหายใน 500 ms วิธีการทั้งสี่รับค่าเป็นมิลลิวินาที

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # ตัด 1.5 วินาทีจากจุดเริ่มต้นและ 2 วินาทีจากจุดสิ้นสุด.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # ตั้งค่า fade-in เป็น 200 มิลลิวินาทีและ fade-out เป็น 500 มิลลิวินาที.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เพื่อกำหนดระดับเสียงเป็นเปอร์เซ็นต์เฉพาะ ให้ใช้ [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) ตัวอย่างนี้ตั้งค่า audio frame แรกบนสไลด์แรกเป็น 85 %

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **จัดการคำบรรยายเสียง**

แต่ละ audio frame ให้เข้าถึงแทร็กคำบรรยายผ่าน [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks) ใช้คอลเลกชันนี้เพื่อแนบคำบรรยาย WebVTT ให้กับคลิป ส่งออกแทร็กที่มีอยู่ หรือเอาออก

### **เพิ่มคำบรรยายเสียง**

ตัวอย่างฝังคลิปเสียงบนสไลด์แรกและใช้ [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) เพื่อแนบแทร็ก WebVTT ท้องถิ่น อาร์กิวเมนต์แรกเป็นป้ายแทร็ก และอาร์กิวเมนต์ที่สองคือไฟล์ที่มีคำบรรยายตามเวลา

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ส่งออกคำบรรยายเสียง**

ตัวอย่างนี้ส่งออกแต่ละแทร็กคำบรรยายที่แนบกับ audio frame บนสไลด์แรก เขียนไบต์ที่ได้จาก [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) ไปยังไฟล์ WebVTT และใช้ตัวระบุจาก [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) เป็นชื่อไฟล์ เพื่อให้แต่ละแทร็กมีไฟล์ผลลัพธ์แยกกัน

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # บันทึกแทร็กคำบรรยายเป็นไฟล์ .vtt
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **ลบคำบรรยายเสียง**

ใช้ [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) เพื่อลบแทร็กเดี่ยว ตัวอย่างใช้ [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) เพื่อลบคำบรรยายทั้งหมดจาก audio frame แรกบนสไลด์แรกโดยคงคลิปไว้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **ค้นบรรทัดในคำบรรยายเสียง**

เพื่อค้นบรรทัดในคำบรรยายเสียงบนสไลด์แรก ให้ค้นข้อความที่ได้จาก [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) ในหน่วยความจำ ใน cue ของ WebVTT ที่เป็นข้อความล้วน บรรทัดเวลา จะมี `-->` ตามด้วยบรรทัดคำบรรยาย และบรรทัดว่างจะเป็นจุดสิ้นสุด cue ตัวอย่างพิมพ์ป้ายแทร็กและแต่ละบรรทัดคำบรรยายที่มี “café”

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **ส่งออก Audio**

การเปลี่ยนสไลด์อาจมีเสียงของตัวเอง เพื่อดึงเสียงนั้น ให้เรียก [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) บนการเปลี่ยนสไลด์ ตัวอย่างเข้าถึงไบต์ที่ได้จาก [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) และพิมพ์จำนวนไบต์ หากสไลด์แรกไม่มีเสียงการเปลี่ยน จะพิมพ์ข้อความแทน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**ฉันสามารถใช้คลิปเสียงเดียวกันหลายสไลด์โดยไม่ต้องทำซ้ำได้หรือไม่?**

ได้. เพิ่มคลิปเพียงครั้งเดียวใน [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) ของงานนำเสนอ แล้วส่งออบเจ็กต์เสียงเดียวกันไปยัง [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) สำหรับแต่ละสไลด์

**ฉันสามารถเปลี่ยนเสียงใน audio frame ที่มีอยู่ได้หรือไม่?**

ได้. สำหรับเสียงที่เชื่อมโยง ให้ใช้ [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) ชี้ไปยังไฟล์ทดแทน หากเป็นเสียงฝัง ให้เลือกคลิปอื่นจากคอลเลกชันเสียงของงานนำเสนอด้วย [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio) ทั้งสองวิธีจะรักษาเฟรมเดิมไว้

**การตัดช่วงทำให้ข้อมูลเสียงในงานนำเสนอเปลี่ยนหรือไม่?**

ไม่. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) และ [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) ตั้งขอบเขตการเล่น คุณยังสามารถดึงคลิปเต็มจาก [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio) ได้อยู่```