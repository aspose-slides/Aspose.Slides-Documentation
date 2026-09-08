---
title: จัดการเฟรมวิดีโอในงานนำเสนอโดยใช้ Python
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
description: "เรียนรู้วิธีเพิ่มและดึงเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างโปรแกรมมิ่งโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java คู่มือการทำอย่างรวดเร็ว"
---
## **บทนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมของผู้ฟังได้

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอในเครื่อง (เก็บไว้บนเครื่องของคุณ)
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube)

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วัตถุวิดีโอ) ไปยังงานนำเสนอได้ Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/th/python-java/aspose.slides/video/) , คลาส [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) และประเภทที่เกี่ยวข้องอื่นๆ

## **Create Embedded Video Frames**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มในสไลด์จัดเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอในงานนำเสนอของคุณได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) .
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/python-java/aspose.slides/video/) และส่งข้อมูลไฟล์วิดีโอเพื่อฝังวิดีโอเข้าไปในงานนำเสนอ
4. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) เพื่อสร้างเฟรมสำหรับวิดีโอ
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Python นี้แสดงวิธีการเพิ่มวิดีโอที่จัดเก็บในเครื่องลงในงานนำเสนอ:

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

หรือคุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์ของมันโดยตรงไปยังเมธอด [addVideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addVideoFrame) :

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

## **Create Video Frames with Video from Web Sources**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) รองรับวิดีโอ YouTube ในงานนำเสนอ หากวิดีโอที่คุณต้องการใช้มีให้ใช้งานออนไลน์ (เช่นบน YouTube) คุณสามารถเพิ่มลงในงานนำเสนอผ่านลิงก์เว็บของมันได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) และส่งลิงก์วิดีโอให้
4. ตั้งค่าแสดงตัวอย่าง (thumbnail) สำหรับเฟรมวิดีโอ
5. บันทึกงานนำเสนอ

โค้ด Python นี้แสดงวิธีการเพิ่มวิดีโอจากเว็บลงในสไลด์ของงานนำเสนอ PowerPoint:

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

    # โหลดภาพย่อย.
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

## **Trim a Video Frame**

Aspose.Slides อนุญาตให้คุณควบคุมส่วนที่เล่นของวิดีโอโดยการตั้งค่า trim‑from‑start และ trim‑from‑end ผ่าน [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setTrimFromStart) และ [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setTrimFromEnd) ค่าทั้งสองระบุเป็นมิลลิวินาทีและกำหนดระยะเวลาที่ข้ามจากจุดเริ่มต้นและจุดสิ้นสุดของวิดีโอตามลำดับ การตั้งค่านี้จะเปลี่ยนการตั้งค่าการเล่นวิดีโอในงานนำเสนอ; ไม่ได้ตัดหรือแก้ไขข้อมูลไบนารีของวิดีโอที่ฝัง

**Set Trim Settings**

เพื่อสร้างเฟรมวิดีโอและตั้งค่าการตัด:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) .
2. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/python-java/aspose.slides/video/) ไปยังงานนำเสนอ
3. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) ไปยังสไลด์
4. ตั้งค่า trim‑from‑start และ trim‑from‑end ผ่าน [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setTrimFromStart) และ [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setTrimFromEnd)
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างโค้ดต่อไปนี้จะข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายของวิดีโอที่ฝังอยู่ระหว่างการเล่น:

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

**Read Trim Settings**

เพื่อสอบสอบค่าการตัดที่มีอยู่ ให้โหลดงานนำเข้า ค้นหาอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) ในรูปร่างของสไลด์แรก แล้วอ่านค่าผ่าน [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#getTrimFromStart) และ [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#getTrimFromEnd)

ตัวอย่างโค้ดต่อไปนี้จะค้นหาเฟรมวิดีโอแรกบนสไลด์แรกและรายงานค่าการตัดเป็นมิลลิวินาที:

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

## **Manage Video Captions**

Aspose.Slides อนุญาตให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และเปิดให้เข้าถึงผ่านเมธอด [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#getCaptionTracks)

**Add Captions to a Video Frame**

เพื่อเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) .
2. เพิ่มวิดีโอไปยังงานนำเสนอ
3. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) ไปยังสไลด์
4. ใช้ [CaptionsCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/) ที่คืนค่าจาก [getCaptionTracks](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#getCaptionTracks) เพื่อเพิ่มแทร็กคำบรรยาย WebVTT
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

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

คลาส [CaptionsCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้

**Extract Captions from a Video Frame**

เพื่อดึงคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ
2. ค้นหาอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) ที่ต้องการ
3. วนผ่านแทร็กคำบรรยายใน [CaptionsCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/)
4. บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ `.vtt`

โค้ดต่อไปนี้แสดงวิธีดึงคำบรรยายจากเฟรมวิดีโอ:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # บันทึกแทร็กคำบรรยายไปยังไฟล์ WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

แต่ละอ็อบเจ็กต์ [Captions](https://reference.aspose.com/slides/th/python-java/aspose.slides/captions/) จะเปิดเผยตัวระบุคำบรรยาย, ป้ายชื่อ, ข้อมูลไบนารี, และข้อความคำบรรยายในรูปแบบสตริง UTF-8

**Remove Captions from a Video Frame**

เพื่อทำการลบคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ
2. รับอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) ที่ต้องการ
3. ลบแทร็กคำบรรยายจาก [CaptionsCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/)
4. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดต่อไปนี้แสดงวิธีลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # ลบคำบรรยายทั้งหมดออกจากเฟรมวิดีโอ.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

หากคุณต้องการลบเฉพาะแทร็กคำบรรยายเดียว ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/#removeAt) แทน [clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/captionscollection/#clear)

## **Extract Video from Slides**

นอกจากการเพิ่มวิดีโอลงในสไลด์แล้ว Aspose.Slides ยังอนุญาตให้คุณดึงวิดีโอที่ฝังอยู่ในงานนำเสนอได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เพื่อโหลดงานนำเสนอที่มีวิดีโอ
2. วนผ่านอ็อบเจ็กต์ [Slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/) ทั้งหมด
3. วนผ่านอ็อบเจ็กต์ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/)
4. บันทึกวิดีโอลงดิสก์

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

## **FAQ**

**พารามิเตอร์การเล่นวิดีโอที่สามารถเปลี่ยนแปลงสำหรับ VideoFrame มีอะไรบ้าง?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setPlayMode) (อัตโนมัติหรือคลิก) และ [looping](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setPlayLoopMode) ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านคุณสมบัติของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/)

**การเพิ่มวิดีโอกับขนาดไฟล์ PPTX มีผลหรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกรวมอยู่ในเอกสาร ทำให้ขนาดงานนำเสนอเพิ่มตามขนาดไฟล์ของวิดีโอ เมื่อคุณเพิ่มวิดีโอออนไลน์ เพียงแค่ฝังลิงก์และรูปภาพตัวอย่าง ขนาดที่เพิ่มจึงน้อยกว่า

**ฉันสามารถเปลี่ยนวิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ใช่ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/#setEmbeddedVideo) ภายในเฟรมโดยคงรูปทรงของ shape ไว้ นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเค้าโครงที่มีอยู่

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังได้หรือไม่?**

ใช่ วิดีโอที่ฝังอยู่มี [content type](https://reference.aspose.com/slides/th/python-java/aspose.slides/video/#getContentType) ที่คุณสามารถอ่านและใช้ได้ ตัวอย่างเช่นเมื่อต้องการบันทึกลงดิสก์