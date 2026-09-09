---
title: จัดการเฟรมวิดีโอในงานนำเสนอด้วย Python
linktitle: เฟรมวิดีโอ
type: docs
weight: 10
url: /th/python-java/video-frame/
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
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและดึงเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างโปรแกรมมิ่งด้วย Aspose.Slides สำหรับ Python ผ่าน Java. คำแนะนำวิธีทำอย่างรวดเร็ว."
---
## **บทนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณได้

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอในเครื่อง (จัดเก็บบนเครื่องของคุณ)
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube).

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วัตถุวิดีโอ) ลงในงานนำเสนอได้ Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/th/python-java/aspose.slides/video/) , คลาส [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) และประเภทที่เกี่ยวข้องอื่นๆ

## **สร้างเฟรมวิดีโอแบบฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์จัดเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอในงานนำเสนอของคุณได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/python-java/aspose.slides/video/) และส่งข้อมูลไฟล์วิดีโอเพื่อฝังวิดีโอในงานนำเสนอ
1. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) เพื่อสร้างเฟรมสำหรับวิดีโอ
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Python นี้แสดงวิธีเพิ่มวิดีโอที่จัดเก็บไว้ในเครื่องลงในงานนำเสนอ:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หรือคุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์โดยตรงไปยังเมธอด [addVideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addVideoFrame):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **สร้างเฟรมวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) รองรับวิดีโอ YouTube ในงานนำเสนอ หากวิดีโอที่คุณต้องการใช้มีออนไลน์ (เช่นบน YouTube) คุณสามารถเพิ่มลงในงานนำเสนอผ่านลิงก์เว็บของมันได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) และส่งลิงก์ไปยังวิดีโอ
1. ตั้งค่าภาพย่อสำหรับเฟรมวิดีโอ
1. บันทึกงานนำเสนอ

โค้ด Python นี้แสดงวิธีเพิ่มวิดีโอจากเว็บลงในสไลด์ของงานนำเสนอ PowerPoint:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # โหลดภาพย่อ.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตัดเฟรมวิดีโอ**

Aspose.Slides อนุญาตให้คุณควบคุมส่วนของวิดีโอที่เล่นโดยตั้งค่าการตัดจากเริ่มและจากท้ายผ่าน [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setTrimFromStart) และ [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setTrimFromEnd) ค่าทั้งสองระบุเป็นมิลลิวินาทีและกำหนดระยะเวลาที่ข้ามจากจุดเริ่มต้นและสิ้นสุดของวิดีโอตามลำดับ การตั้งค่านี้เปลี่ยนการตั้งค่าการเล่นวิดีโอในงานนำเสนอ; ไม่ได้ตัดหรือแก้ไขข้อมูลไบนารีของวิดีโอที่ฝังไว้

**ตั้งค่าการตัด**

เพื่อสร้างเฟรมวิดีโอและตั้งค่าการตัด:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) .
1. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/python-java/aspose.slides/video/) ลงในงานนำเสนอ
1. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) ลงในสไลด์
1. ตั้งค่าการตัดจากเริ่มและจากท้ายผ่าน [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setTrimFromStart) และ [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setTrimFromEnd)
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดตัวอย่างต่อไปนี้ข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายของวิดีโอที่ฝังไว้ระหว่างการเล่น:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**อ่านการตั้งค่าการตัด**

เพื่อดูการตั้งค่าการตัดที่มีอยู่ ให้โหลดงานนำเสนอ ค้นหาอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) ภายในรูปร่างบนสไลด์แรก แล้วอ่านค่าผ่าน [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#getTrimFromStart) และ [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#getTrimFromEnd)

โค้ดตัวอย่างต่อไปนี้ค้นหาเฟรมวิดีโอแรกบนสไลด์แรกและรายงานการตั้งค่าการตัดเป็นมิลลิวินาที:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides อนุญาตให้คุณจัดการคำบรรยายแบบปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกจัดเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านเมธอด [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#getCaptionTracks)

**เพิ่มคำบรรยายให้กับเฟรมวิดีโอ**

เพื่อเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) .
1. เพิ่มวิดีโอลงในงานนำเสนอ
1. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) ลงในสไลด์
1. ใช้ [CaptionsCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/) ที่ได้จาก [getCaptionTracks](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#getCaptionTracks) เพื่อเพิ่มแทร็กคำบรรยาย WebVTT
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดต่อไปนี้แสดงวิธีเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

คลาส [CaptionsCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/) ยังมีโอเวอร์โหลดที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้

**ดึงคำบรรยายจากเฟรมวิดีโอ**

เพื่อดึงคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโออยู่
1. ค้นหาอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) ที่ต้องการ
1. วนรอบผ่านแทร็กคำบรรยายใน [CaptionsCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/)
1. บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ `.vtt`

โค้ดต่อไปนี้แสดงวิธีดึงคำบรรยายจากเฟรมวิดีโอ:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpipe.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # บันทึกแทร็กคำบรรยายเป็นไฟล์ WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

อ็อบเจ็กต์ [Captions](https://reference.aspose.com/slides/th/python-java/aspose.slides/captions/) แต่ละตัวเปิดเผยตัวบ่งชี้คำบรรยาย, ป้าย, ข้อมูลไบนารี, และข้อความคำบรรยายเป็นสตริง UTF-8

**ลบคำบรรยายจากเฟรมวิดีโอ**

เพื่อทำการลบคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโออยู่
1. รับอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) ที่ต้องการ
1. ลบแทร็กคำบรรยายจาก [CaptionsCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/)
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดต่อไปนี้แสดงวิธีลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

หากต้องการลบแทร็กคำบรรยายเพียงหนึ่งรายการให้ใช้เมธอด [remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/#removeAt) แทน [clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/#clear)

## **ดึงวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอลงในสไลด์แล้ว Aspose.Slides ยังอนุญาตให้คุณดึงวิดีโอที่ฝังอยู่ในงานนำเสนอได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เพื่อโหลดงานนำเสนอที่มีวิดีโอ
2. วนรอบผ่านอ็อบเจ็กต์ [Slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/) ทั้งหมด
3. วนรอบผ่านอ็อบเจ็กต์ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/)
4. บันทึกวิดีโอไปยังดิสก์

โค้ด Python นี้แสดงวิธีดึงวิดีโอจากสไลด์ของงานนำเสนอ:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนแปลงได้สำหรับ VideoFrame?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setPlayMode) (อัตโนมัติหรือคลิก) และ [looping](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setPlayLoopMode) ตัวเลือกเหล่านี้พร้อมใช้งานผ่านคุณสมบัติของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/)

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกรวมอยู่ในเอกสาร ดังนั้นขนาดงานนำเสนอจะเพิ่มตามขนาดไฟล์ของวิดีโอ เมื่อคุณเพิ่มวิดีโอออนไลน์ ลิงก์และภาพย่อจะถูกฝังไว้ ทำให้การเพิ่มขนาดเล็กกว่า

**ฉันสามารถแทนที่วิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ใช่ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setEmbeddedVideo) ภายในเฟรมโดยยังคงรักษาเรขาคณิตของรูปร่างไว้; นี่เป็นสถานการณ์ทั่วไปสำหรับอัปเดตสื่อในเลเอาต์ที่มีอยู่

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอดังกล่าวได้หรือไม่?**

ใช่ วิดีโอที่ฝังไว้มี [content type](https://reference.aspose.com/slides/th/python-java/aspose.slides/video/#getContentType) ที่คุณสามารถอ่านและใช้ได้ ตัวอย่างเช่นเมื่อบันทึกลงดิสก์