---
title: จัดการเสียงในงานนำเสนอด้วย Python
linktitle: เฟรมเสียง
type: docs
weight: 10
url: /th/python-java/audio-frame/
keywords:
- เสียง
- เฟรมเสียง
- ภาพย่อ
- เพิ่มเสียง
- คุณสมบัติของเสียง
- ตัวเลือกเสียง
- สกัดเสียง
- Python
- Aspose.Slides
description: "สร้างและควบคุมเฟรมเสียงใน Aspose.Slides สำหรับ Python ผ่าน Java—ตัวอย่างโค้ดสำหรับฝัง, ตัด, วนลูป, และกำหนดค่าการเล่นในงานนำเสนอแบบ PPT, PPTX, และ ODP"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับเฟรมเสียงใน Aspose.Slides โดยแสดงวิธีการเพิ่มเสียงที่ฝังไว้ในสไลด์ ปรับแต่งภาพย่อของเฟรมเสียง กำหนดค่าตัวเลือกการเล่นเช่น ระดับเสียง การวนซ้ำ การซ่อน การตัดและระยะเวลาเฟด รวมถึงการสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์

## **สร้างเฟรมเสียง**

Aspose.Slides for Python ผ่าน Java ให้คุณเพิ่มไฟล์เสียงลงในสไลด์ ไฟล์เสียงจะถูกฝังในสไลด์เป็นเฟรมเสียง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. อ่านไฟล์เสียงที่คุณต้องการฝังในสไลด์
4. เพิ่มเฟรมเสียงที่ฝังไว้ (ซึ่งประกอบด้วยไฟล์เสียง) ลงในสไลด์
5. ตั้งค่า [setPlayMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setPlayMode) และ [setVolume](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setVolume) ที่เปิดเผยโดยอ็อบเจ็กต์ [AudioFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/)
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

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

## **เปลี่ยนภาพย่อของเฟรมเสียง**

เมื่อคุณเพิ่มไฟล์เสียงลงในงานนำเสนอ เสียงจะแสดงเป็นเฟรมพร้อมภาพเริ่มต้นมาตรฐาน (ดูภาพในส่วนด้านล่าง) คุณสามารถเปลี่ยนภาพพรีวิวของเฟรมเสียง (ตั้งค่าภาพที่คุณต้องการ)

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
    audio_data = Path("sample2.mp3").read_bytes()
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

Aspose.Slides สำหรับ Python ผ่าน Java ให้คุณเปลี่ยนตัวเลือกที่ควบคุมการเล่นหรือคุณสมบัติของเสียง ตัวอย่างเช่น คุณสามารถปรับระดับเสียงของเสียง ตั้งค่าให้เสียงเล่นวนซ้ำ หรือแม้กระทั่งซ่อนไอคอนเสียง

แผง **Audio Options** ใน Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** ที่สอดคล้องกับคุณสมบัติของ Aspose.Slides [AudioFrame] :

- **เริ่ม** รายการดรอปดาวน์ตรงกับเมธอด [setPlayMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setPlayMode)
- **ระดับเสียง** ตรงกับเมธอด [setVolume](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setVolume)
- **เล่นข้ามสไลด์** ตรงกับเมธอด [setPlayAcrossSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **วนซ้ำจนกว่าจะหยุด** ตรงกับเมธอด [setPlayLoopMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **ซ่อนระหว่างการแสดง** ตรงกับเมธอด [setHideAtShowing](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **ย้อนกลับหลังการเล่น** ตรงกับเมธอด [setRewindAudio](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setRewindAudio)

ตัวเลือก **Editing** ของ PowerPoint ที่สอดคล้องกับคุณสมบัติของ Aspose.Slides [AudioFrame] :

- **ค่อยๆ ปรากฏ** ตรงกับเมธอด [setFadeInDuration](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **ค่อยๆ หาย** ตรงกับเมธอด [setFadeOutDuration](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **ตัดจุดเริ่มต้นเสียง** ตรงกับเมธอด [setTrimFromStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **ตัดจุดสิ้นสุดเสียง** มีค่าเท่ากับระยะเวลาของเสียงลบค่าที่ตั้งในเมธอด [setTrimFromEnd](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setTrimFromEnd)

การควบคุม **Volume** ของ PowerPoint บนแผงควบคุมเสียงสอดคล้องกับเมธอด [setVolumeValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setVolumeValue) ซึ่งทำให้คุณเปลี่ยนระดับเสียงเป็นเปอร์เซ็นต์

วิธีการเปลี่ยนตัวเลือกการเล่นเสียง:

1. [Сreate](#create-audio-frames) หรือรับ Audio Frame
2. กำหนดค่ใหม่ให้กับคุณสมบัติของ Audio Frame ที่คุณต้องการปรับ
3. บันทึกไฟล์ PowerPoint ที่แก้ไขแล้ว

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # เล่นเมื่อคลิกด้วยระดับเสียงต่ำ, ข้ามสไลด์, โดยไม่วนลูป.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # ซ่อนเฟรมระหว่างการแสดงสไลด์และรีวินด์หลังจากเล่น.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

ตัวอย่าง Python นี้แสดงวิธีการเพิ่มเฟรมเสียงใหม่พร้อมเสียงที่ฝังไว้ ตัดส่วนและตั้งค่าเวลาเฟด:

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
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # ตัด 1.5 วินาทีจากจุดเริ่มต้นและ 2 วินาทีจากจุดสิ้นสุด.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # ตั้งค่าเฟดอินเป็น 200 มิลลิวินาทีและเฟดเอาท์เป็น 500 มิลลิวินาที.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึงเฟรมเสียงที่ฝังไว้และตั้งระดับเสียงที่ 85%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **จัดการคำบรรยายเสียง**

Aspose.Slides ให้คุณเพิ่มคำบรรยายแบบปิดให้กับเฟรมเสียงผ่านเมธอด [getCaptionTracks](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#getCaptionTracks) เมธอดนี้จะคืนค่าเป็น [CaptionsCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/) ซึ่งทำให้คุณสามารถเพิ่มแทรกคำบรรยาย WebVTT, วนผ่านแทรกที่มีอยู่, และลบออกเมื่อจำเป็น

**เพิ่มคำบรรยายเสียง**

ใช้เมธอด [getCaptionTracks](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#getCaptionTracks) เพื่อแนบแทรกคำบรรยายหนึ่งหรือหลายแทรกให้กับเฟรมเสียง ในตัวอย่างต่อไปนี้ จะเพิ่มไฟล์เสียงลงในสไลด์ แล้วโหลดแทรกคำบรรยายใหม่จากไฟล์ `.vtt`

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # เพิ่มแทรกแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**สกัดคำบรรยายเสียง**

คุณสามารถวนผ่านแทรกคำบรรยายที่เชื่อมโยงกับเฟรมเสียงและบันทึกเป็นไฟล์ `.vtt` แต่ละแทรกคำบรรยายจะเปิดเผยข้อมูลไบนารีและรหัสประจำตัวที่เป็นเอกลักษณ์ซึ่งสามารถใช้เมื่อนำออกคำบรรยาย

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
                # บันทึกแทร็กคำบรรยายเป็นไฟล์ .vtt.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**ลบคำบรรยายเสียง**

เพื่อทำการลบคำบรรยายออกจากเฟรมเสียง ให้ใช้เมธอดที่ให้โดย [CaptionsCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/) เช่น [clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/#removeAt) ตัวอย่างต่อไปนี้ลบแทรกคำบรรยายทั้งหมดจากเฟรมเสียง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **สกัดเสียง**

Aspose.Slides สำหรับ Python ผ่าน Java ให้คุณสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์ ตัวอย่างเช่น คุณสามารถสกัดเสียงที่ใช้ในสไลด์เฉพาะ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีเสียงอยู่
2. ดึงอ้างอิงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เข้าถึง [slideshow transitions](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์
4. สกัดเสียงเป็นข้อมูลไบต์

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
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**ฉันสามารถใช้ทรัพยากรเสียงเดียวกันบนหลายสไลด์โดยไม่ทำให้ไฟล์ขนาดใหญ่ขึ้นหรือไม่?**

ได้ค่ะ เพิ่มเสียงเพียงครั้งเดียวใน [audio collection](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getAudios) ที่ใช้ร่วมของงานนำเสนอ แล้วสร้างเฟรมเสียงเพิ่มเติมที่อ้างอิงทรัพยากรนั้น วิธีนี้จะหลีกเลี่ยงการทำซ้ำข้อมูลสื่อและทำให้ขนาดของงานนำเสนออยู่ในระดับที่ควบคุมได้

**ฉันสามารถแทนที่เสียงในเฟรมเสียงที่มีอยู่โดยไม่ต้องสร้างรูปทรงใหม่ได้หรือไม่?**

ได้ค่ะ สำหรับเสียงที่เชื่อมโยง ให้อัปเดต [link path](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setLinkPathLong) ให้ชี้ไปยังไฟล์ใหม่ สำหรับเสียงที่ฝังไว้ ให้สลับอ็อบเจ็กต์ [embedded audio](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/#setEmbeddedAudio) ด้วยอ็อบเจ็กต์อื่นจาก [audio collection](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getAudios) ของงานนำเสนอ การจัดรูปแบบของเฟรมและการตั้งค่าการเล่นส่วนใหญ่จะคงเดิม

**การตัดส่วนทำให้ข้อมูลเสียงพื้นฐานที่เก็บในงานนำเสนอเปลี่ยนหรือไม่?**

ไม่ การตัดส่วนเพียงปรับขอบเขตการเล่นเท่านั้น ไบต์เสียงเดิมยังคงไม่ถูกแก้ไขและสามารถเข้าถึงได้ผ่านเสียงที่ฝังไว้หรือ [audio collection](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getAudios) ของงานนำเสนอ