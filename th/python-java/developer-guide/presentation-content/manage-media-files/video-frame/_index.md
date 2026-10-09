---
title: จัดการกรอบวิดีโอในงานนำเสนอด้วย Python
linktitle: กรอบวิดีโอ
type: docs
weight: 10
url: /th/python-java/video-frame/
keywords:
- เพิ่มวิดีโอ
- สร้างวิดีโอ
- ฝังวิดีโอ
- ดึงวิดีโอ
- ดึงคืนวิดีโอ
- กรอบวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและดึงกรอบวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมด้วย Aspose.Slides สำหรับ Python ผ่าน Java. คู่มือวิธีทำอย่างรวดเร็ว."
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้ Aspose.Slides สำหรับ Python ผ่าน Java ให้คุณเพิ่มกรอบวิดีโอลงในสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และดึงข้อมูลวิดีโอที่ฝังไว้

PowerPoint รองรับวิดีโอในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

เพื่อแทนข้อมูลวิดีโอและกรอบวิดีโอ Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) , คลาส [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ

## **สร้างกรอบวิดีโอฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ถูกเก็บไว้ในเครื่อง คุณสามารถสร้างกรอบวิดีโอเพื่อฝังวิดีโอลงในงานนำเสนอของคุณ

ตัวอย่างนี้ฝังวิดีโอในเครื่องบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของกรอบเป็นหน่วยจุด Python อ่านไบต์ของวิดีโอจากดิสก์ และ JPype แปลงเป็นอาเรย์ไบต์ของ Java ก่อนเพิ่มวิดีโอลงในงานนำเสนอ

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

คุณสามารถส่งพาธวิดีโอในเครื่องโดยตรงไปยัง [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) ตัวอย่างนี้ฝังวิดีโอบนสไลด์แรกของงานนำเสนอใหม่ วิดีโอจะต้องยังคงเข้าถึงได้จนกว่างานนำเสนอจะถูกบันทึก

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สร้างกรอบวิดีโอพร้อมวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างกรอบวิดีโอที่เชื่อมโยงกับวิดีโอออนไลน์ เช่น วิดีโอ YouTube

ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และรูปย่อไปยังสไลด์แรก แทนที่ตัวระบุวิดีโอเพื่อใช้วิดีโออื่น ๆ วิธีการ [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) ขอให้เล่นอัตโนมัติ การดาวน์โหลดรูปย่อและการเล่นวิดีโอต้องการการเชื่อมต่ออินเทอร์เน็ต ตัวแสดงผลงานนำเสนอจะต้องรองรับการเล่นวิดีโอออนไลน์ด้วย

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เล่นวิดีโอในโหมดเต็มจอ**

ในการนำเสนอฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มจอเพื่อให้ผู้ชมมองเห็นรายละเอียดได้ เรียกใช้ [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) พร้อม `True` เพื่อเปิดใช้งานพฤติกรรมนี้ขณะเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) ตัวแรกบนสไลด์แรกและเปิดใช้งานการเล่นเต็มจอ งานนำเข้าจะต้องมีอย่างน้อยหนึ่งสไลด์ที่มีกรอบวิดีโออยู่บนสไลด์แรก

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การเล่นเต็มจอควบคุมวิธีการแสดงวิดีโอ อย่างอิสระ [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) ควบคุมว่าจะเริ่มอัตโนมัติหรือคลิก และ [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) ควบคุมว่าจะวนซ้ำหรือไม่ เพื่อเลือกพฤติกรรมเริ่มต้น ตั้งค่าโหมดการเล่นเป็น [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) ตัวอย่างจะคงค่าการเริ่มและการวนซ้ำเดิม

## **ถอยวิดีโอกลับหลังการเล่น**

ในการนำเสนอฝึกอบรม การนำวิดีโอสาธิตกลับไปต้นทำให้พร้อมสำหรับผู้บรรยายที่จะเล่นอีกครั้ง เรียกใช้ [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) พร้อม `True` เพื่อคืนวิดีโอไปต้นหลังการเล่นเสร็จ

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) ตัวแรกบนสไลด์แรกและเปิดใช้งานการถอยกลับ ปิดการวนซ้ำเพื่อให้การเล่นจบและตั้งให้เริ่มเมื่อคลิก งานนำเข้าจะต้องมีอย่างน้อยหนึ่งสไลด์ที่มีกรอบวิดีโออยู่บนสไลด์แรก

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การถอยกลับคืนวิดีโอไปต้นโดยไม่เริ่มใหม่ ตรงกันข้าม การเรียก [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) พร้อม `True` จะทำให้วนซ้ำอัตโนมัติ ปิดการวนซ้ำเมื่อคุณต้องการให้วิดีจบและพร้อมเล่นใหม่ [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) ควบคุมการเริ่มอัตโนมัติหรือคลิก ตัวอย่างนี้ใช้ [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) เพื่อให้ผู้บรรยายควบคุมเมื่อเริ่มเล่น ตั้งค่าโหมดการเล่นหลังจากตั้งค่าการวนซ้ำตามตัวอย่าง การถอยกลับทำงานแยกจาก [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode)

## **ตัดกรอบวิดีโอ**

ใช้ [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) และ [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) เพื่อตัดส่วนเริ่มหรือส่วนท้ายของวิดีโอขณะเล่น ทั้งสองค่ามีหน่วยเป็นมิลลิวินาที การตัดเปลี่ยนการตั้งค่าเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังอยู่

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายขณะเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้เหลือส่วนที่เล่นได้

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**อ่านค่าการตัด**

ตัวอย่างนี้พิมพ์ค่าการตัดของกรอบวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีกรอบวิดีโอจะไม่มีการพิมพ์ ตัวอย่างก่อนหน้านี้ให้ค่า 2500 และ 1000

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

Aspose.Slides ให้คุณจัดการคำบรรยายแบบปิดสำหรับกรอบวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกจัดเก็บในรูปแบบ WebVTT และเข้าถึงได้ผ่านเมธอด [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks)

**เพิ่มคำบรรยายให้กรอบวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทร็กคำบรรยาย WebVTT ชื่อ English เวลาตราบคำบรรยายต้องตรงกับวิดีโอ งานนำเสนอที่บันทึกจะมีทั้งวิดีโอและคำบรรยายรวมอยู่

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

คลาส [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) ยังมีโอเวอร์โหลดที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้

**ดึงคำบรรยายจากกรอบวิดีโอ**

ตัวอย่างนี้บันทึกแทร็กคำบรรยายทั้งหมดจากกรอบวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกไฟล์ ตัวเลขลำดับทำให้ไฟล์ผลลัพธ์ไม่ซ้ำกัน คอนโซลรายงานจำนวนแทร็กที่ดึง งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์

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

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

แต่ละอ็อบเจกต์ [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) แสดงตัวระบุคำบรรยาย ป้ายชื่อ ข้อมูลไบต์ และข้อความคำบรรยายเป็นสตริง UTF-8

**ลบคำบรรยายจากกรอบวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากกรอบวิดีโอที่ตำแหน่งรูปร่างแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่าสไลด์และรูปร่างมีอยู่และรูปร่างเป็นกรอบวิดีโอ

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # ลบคำบรรยายทั้งหมดจากกรอบวิดีโอ.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

หากต้องการลบแทร็กคำบรรยายเพียงหนึ่งแทร็ก ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) แทน [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear)

## **ดึงวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอลงในสไลด์แล้ว Aspose.Slides ยังให้คุณดึงวิดีโอที่ฝังอยู่ในงานนำเสนอได้

ตัวอย่างนี้ดึงวิดีโอที่ฝังจากทุกสไลด์เป็นไฟล์ไบต์แยกตามหมายเลข วิดีโอที่ลิงก์จะถูกข้ามเพราะไม่มีข้อมูลฝัง คอนโซลจะแสดงประเภท MIME ของแต่ละวิดีโอและจำนวนทั้งหมด ผลลัพธ์ใช้ส่วนขยาย `.bin` ทั่วไป เปลี่ยนเป็นสกุลที่ตรงกับประเภทสื่อที่รายงานเมื่อจำเป็น

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **FAQ**

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนแปลงได้สำหรับกรอบวิดีโอ?**

คุณสามารถควบคุม [โหมดการเล่น](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (อัตโนมัติหรือคลิก) และ [การทำซ้ำ](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านเมธอดของอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/)

**การเพิ่มวิดีโอทำให้ไฟล์ PPTX มีขนาดเพิ่มขึ้นหรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบต์จะถูกรวมในเอกสาร ดังนั้นขนาดงานนำเสนอจะเพิ่มตามขนาดไฟล์ เมื่อคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มรูปย่อ งานนำเสนอจะเก็บลิงก์และภาพตัวอย่างแทนข้อมูลวิดีโอ ทำให้การเพิ่มขนาดมักจะน้อยกว่า

**ฉันสามารถแทนที่วิดีโอในกรอบวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ใช่ คุณสามารถสลับ [เนื้อหาวิดีโอ](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) ภายในกรอบขณะคงรูปทรงของรูปร่างไว้ นี่เป็นกรณีทั่วไปสำหรับอัพเดทสื่อในเลเอาต์ที่มีอยู่

**สามารถตรวจสอบประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังได้หรือไม่?**

ใช่ วิดีโอที่ฝังมี [ประเภทเนื้อหา](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) ที่คุณสามารถอ่านและใช้ได้ เช่น เมื่อต้องการบันทึกลงดิสก์