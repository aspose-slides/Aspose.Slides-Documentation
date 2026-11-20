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
- ดึงข้อมูลวิดีโอ
- เฟรมวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและดึงเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java คู่มือวิธีทำอย่างรวดเร็ว"
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้ Aspose.Slides for Python via Java ช่วยให้คุณเพิ่มเฟรมวิดีโอลงในสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และดึงข้อมูลวิดีโอที่ฝังไว้

PowerPoint รองรับวิดีโอที่อยู่บนเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

เพื่อเป็นตัวแทนข้อมูลวิดีโอและเฟรมวิดีโอ Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) , คลาส [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ

## **สร้างเฟรมวิดีโอฝังไว้**

หากไฟล์วิดีโอที่ต้องการเพิ่มลงในสไลด์ของคุณเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอในงานนำเสนอของคุณได้

ตัวอย่างนี้ฝังวิดีโอที่อยู่ในเครื่องลงบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของเฟรมใช้หน่วยจุด Python อ่านไบต์ของวิดีโอจากดิสก์ และ JPype แปลงให้เป็นอาเรย์ไบต์ของ Java ก่อนเพิ่มวิดีโอลงในงานนำเสนอ

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

คุณยังสามารถส่งเส้นทางวิดีโอในเครื่องโดยตรงไปยัง [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) ตัวอย่างนี้ฝังวิดีโอลงบนสไลด์แรกของงานนำเสนอใหม่ วิดีโอต้องสามารถเข้าถึงได้จนกว่าจะบันทึกงานนำเสนอ

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

## **สร้างเฟรมวิดีโอพร้อมวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างเฟรมวิดีโอที่ลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

ตัวอย่างนี้เพิ่มลิงก์และรูปย่อของวิดีโอ YouTube ลงบนสไลด์แรก แทนที่ตัวระบุวิดีโอเพื่อใช้วิดีโออื่น วิธี [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) ร้องขอให้เล่นอัตโนมัติ การดาวน์โหลดรูปย่อและการเล่นวิดีโอต้องใช้การเชื่อมต่ออินเทอร์เน็ต ตัวแสดงผลงานนำเสนอจะต้องรองรับการเล่นวิดีโอออนไลน์ด้วย

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

## **เล่นวิดีโอในโหมดเต็มหน้าจอ**

ในงานฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มหน้าจอเพื่อให้ผู้ชมเห็นรายละเอียดได้ เรียกใช้ [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) พร้อมค่า `True` เพื่อเปิดใช้งานพฤติกรรมนี้ระหว่างการเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) ตัวแรกบนสไลด์แรก และเปิดการเล่นแบบเต็มหน้าจอ งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก

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

การเล่นแบบเต็มหน้าจอควบคุมวิธีการแสดงวิดีโอ อย่างอิสระ [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) ควบคุมว่าจะเริ่มอัตโนมัติหรือเมื่อคลิก และ [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) ควบคุมว่าจะวนซ้ำหรือไม่ เพื่อเลือกพฤติกรรมการเริ่ม ให้ตั้งค่าโหมดการเล่นเป็น [VideoPlayModePreset.Auto หรือ VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) ตัวอย่างนี้คงค่าการเริ่มและการวนซ้ำเดิม

## **ย้อนกลับวิดีหลังเล่นเสร็จ**

ในงานฝึกอบรม การคืนวิดีโอสาธิตกลับไปยังจุดเริ่มต้นทำให้พร้อมให้ผู้นำเสนอเล่นอีกครั้ง เรียกใช้ [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) พร้อมค่า `True` เพื่อคืนวิดีโอไปยังจุดเริ่มต้นหลังการเล่นเสร็จ

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) ตัวแรกบนสไลด์แรก และเปิดการย้อนกลับ มันปิดการวนซ้ำเพื่อให้การเล่นจบลงและตั้งให้เริ่มเมื่อคลิก งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโอบนสไลด์แรก

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

การย้อนกลับจะคืนวิดีโอไปยังจุดเริ่มต้นโดยไม่เริ่มเล่นใหม่ ในทางกลับกัน การเรียก [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) ด้วยค่า `True` จะทำให้การเล่นวนซ้ำอัตโนมัติ ปิดการวนซ้ำเมื่อคุณต้องการให้วิดีโอจบลงและพร้อมเล่นอีกครั้ง [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) ควบคุมการเริ่มอัตโนมัติหรือเมื่อคลิก ตัวอย่างนี้ใช้ [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) เพื่อให้ผู้นำเสนอกำหนดเวลาเริ่มเล่น ตั้งค่าโหมดการเล่นหลังจากตั้งค่าการวนซ้ำตามที่แสดงในตัวอย่าง การย้อนกลับทำงานอิสระจาก [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode)

## **ตัดเฟรมวิดีโอ**

ใช้ [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) และ [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) เพื่อตัดส่วนเริ่มต้นหรือส่วนท้ายของวิดีโอระหว่างการเล่น ทั้งสองค่ามีหน่วยเป็นมิลลิวินาที การตัดเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังไว้

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายระหว่างการเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้เหลือส่วนที่เล่นได้

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

ตัวอย่างนี้พิมพ์ค่าการตัดของเฟรมวิดีโอตัวแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีเฟรมวิดีโอจะไม่มีอะไรพิมพ์ ตัวอย่างก่อนหน้านี้ให้ค่า 2500 และ 1000

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

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านเมธอด [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks)

### **เพิ่มคำบรรยายให้เฟรมวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทร็กคำบรรยาย WebVTT ชื่อ English ค่าตำแหน่งเวลาในคำบรรยายควรตรงกับวิดีโอ งานนำเสนอที่บันทึกแล้วจะมีทั้งวิดีโอและคำบรรยาย

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

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

คลาส [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้

### **ดึงคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้บันทึกแทร็กคำบรรยายทั้งหมดจากเฟรมวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกไฟล์ ตัวเลขต่อเนื่องทำให้ไฟล์ผลลัพธ์แยกจากกัน คอนโซลรายงานจำนวนแทร็กที่ดึงออก งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์

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

แต่ละวัตถุ [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) เปิดเผยตัวระบุคำบรรยาย, ป้ายชื่อ, ข้อมูลไบต์, และข้อความคำบรรยายเป็นสตริง UTF‑8

### **ลบคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอที่ตำแหน่งรูปร่างแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างนั้นเป็นเฟรมวิดีโอ

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

หากต้องการลบแทร็กคำบรรยายเพียงหนึ่งแทร็ก ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) หรือ [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) แทนการใช้ [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear)

### **ค้นหาคำบรรยายวิดีโอ**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) คืนค่าแทร็ก WebVTT ทั้งหมดรวมถึงส่วนหัว เส้นเวล และข้อความคำบรรยาย คุณสามารถค้นหาคำบรรยายในหน่วยความจำเพื่อหาเฟรสและตำแหน่งเวลา ตัวอย่างเช่น แทร็กภาษาอังกฤษบนสไลด์ 2 อาจมีข้อความต่อไปนี้

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

ตัวอย่างนี้เปิด `captioned_media.pptx` และใช้ [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) เพื่ออ่านแทร็กของแต่ละเฟรมวิดีโอระดับบนบนทุกสไลด์ ใน cue แบบข้อความธรรมดา เส้นเวลาจะมี `-->` และบรรทัดว่างจะปิด cue สำหรับแต่ละคำบรรยายที่มี “café” ไม่ว่าจะเป็นตัวพิมพ์ใหญ่หรือตัวพิมพ์เล็ก ตัวอย่างจะแสดงหมายเลขสไลด์ ป้ายแทร็ก เส้นเวลาต้นฉบับ และคำบรรยายเต็ม

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

การค้นหา “café” ให้ผลลัพธ์หนึ่งรายการสำหรับแทร็กตัวอย่าง การค้นหาจะไม่รวมส่วนหัวของแทร็กและจะคงการตั้งค่าเวลาและการขึ้นบรรทัดในผลลัพธ์

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **ดึงวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอลงสไลด์แล้ว Aspose.Slides ยังให้คุณดึงวิดีโอที่ฝังอยู่ในงานนำเสนอได้

ตัวอย่างนี้ดึงวิดีโอที่ฝังไว้จากทุกสไลด์เป็นไฟล์ไบต์แยกตามเลขลำดับ วิดีโอที่ลิงก์ไว้จะถูกข้ามเนื่องจากไม่มีข้อมูลฝัง คอนโซลจะแสดง MIME type ของแต่ละวิดีโอและจำนวนรวม ผลลัพธ์ใช้ส่วนขยายไฟล์ทั่วไป `.bin` ; หากต้องการสามารถเปลี่ยนเป็นส่วนขยายที่สอดคล้องกับสื่อที่ระบุได้

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

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนได้สำหรับเฟรมวิดีโอ?**

คุณสามารถควบคุม [โหมดการเล่น](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (อัตโนมัติหรือเมื่อคลิก) และ [การวนซ้ำ](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านเมธอดของวัตถุ [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/)

**การเพิ่มวิดีโอทำให้ไฟล์ PPTX มีขนาดใหญ่ขึ้นหรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่องข้อมูลไบต์จะถูกรวมอยู่ในเอกสาร ดังนั้นขนาดงานนำเสนอจะเพิ่มตามขนาดไฟล์ เมื่อคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มรูปย่อ งานนำเสนอจะเก็บลิงก์และภาพตัวอย่างแทนข้อมูลวิดีโอ ดังนั้นขนาดที่เพิ่มมักจะน้อยกว่า

**ฉันสามารถแทนที่วิดีโอในเฟรมวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ได้ คุณสามารถสลับ [เนื้อหาวิดีโอ](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) ภายในเฟรมขณะที่คงรูปทรงของรูปร่างไว้ ซึ่งเป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลเอาต์ที่มีอยู่

**สามารถตรวจสอบประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังไว้ได้หรือไม่?**

ได้ วิดีโอที่ฝังไว้มี [ประเภทเนื้อหา](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) ที่คุณสามารถอ่านและใช้ได้ ตัวอย่างเช่น เมื่อต้องการบันทึกลงดิสก์