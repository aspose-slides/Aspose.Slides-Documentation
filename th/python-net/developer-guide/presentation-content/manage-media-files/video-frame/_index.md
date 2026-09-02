---
title: เพิ่มวิดีโอไปยังงานนำเสนอใน Python
linktitle: เฟรมวิดีโอ
type: docs
weight: 10
url: /th/python-net/video-frame/
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
description: "เรียนรู้วิธีการเพิ่มและดึงเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างอัตโนมัติโดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET คู่มือวิธีทำอย่างรวดเร็ว"
---
## **บทนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณ

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอในเครื่อง (จัดเก็บบนเครื่องของคุณ)
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube).

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วิดีโออ็อบเจ็กต์) ลงในงานนำเสนอ Aspose.Slides ให้คลาส [Video](https://reference.aspose.com/slides/th/python-net/aspose.slides/video/) คลาส [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) และประเภทที่เกี่ยวข้องอื่นๆ

## **สร้างเฟรมวิดีโอฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ของคุณถูกเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอนั้นในงานนำเสนอของคุณได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน.
1. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/python-net/aspose.slides/video/) และส่งพาธของไฟล์วิดีโอเพื่อฝังวิดีโอกับงานนำเสนอ.
1. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) เพื่อสร้างเฟรมสำหรับวิดีโอ.  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Python นี้แสดงวิธีเพิ่มวิดีโอที่เก็บไว้ในเครื่องลงในงานนำเสนอ:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # รับสไลด์แรกและเพิ่มเฟรมวิดีโอ
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # บันทึกงานนำเสนอลงดิสก์
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

หรือคุณสามารถเพิ่มวิดีโอโดยส่งพาธของไฟล์โดยตรงให้กับเมธอด `add_video_frame(x, y, width, height, fname)` :

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **สร้างเฟรมวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

เวอร์ชันใหม่ของ Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) รองรับวิดีโอออนไลน์ในงานนำเสนอ หากวิดีโอที่คุณต้องการใช้มีให้บริการออนไลน์ (เช่นบน YouTube) คุณสามารถเพิ่มลงในงานนำเสนอของคุณผ่านลิงก์เว็บของมันได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
1. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/python-net/aspose.slides/video/) และส่งลิงก์ของวิดีโอ.
1. กำหนดภาพย่อสำหรับเฟรมวิดีโอ. 
1. บันทึกงานนำเสนอ. 

โค้ด Python นี้แสดงวิธีเพิ่มวิดีโอจากเว็บไปยังสไลด์ในงานนำเสนอ PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # เพิ่ม videoFrame
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # โหลด thumbnail
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตัดส่วนเฟรมวิดีโอ**

Aspose.Slides ให้คุณควบคุมส่วนที่เล่นของวิดีโอโดยการกำหนดค่า trim-from-start และ trim-from-end ผ่าน [VideoFrame.trim_from_start](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/trim_from_start/) และ [VideoFrame.trim_from_end](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/trim_from_end/). ทั้งสองค่าจะระบุเป็นมิลลิวินาทีและกำหนดระยะเวลาที่จะข้ามจากจุดเริ่มต้นและจุดสิ้นสุดของวิดีโอตามลำดับ การตั้งค่านี้จะเปลี่ยนการตั้งค่าการเล่นวิดีโอในงานนำเสนอ; แต่ไม่ได้ตัดหรือแก้ไขข้อมูลไบนารีของวิดีโอที่ฝังอยู่

**ตั้งค่าการตัด**

เพื่อสร้างเฟรมวิดีโอและตั้งค่าการตัดของมัน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
1. เพิ่มอ็อบเจ็กต์ [Video](https://reference.aspose.com/slides/th/python-net/aspose.slides/video/) ลงในงานนำเสนอ.
1. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) ลงในสไลด์.
1. ตั้งค่าตัวแปร trim-from-start และ trim-from-end ผ่าน [VideoFrame.trim_from_start](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/trim_from_start/) และ [VideoFrame.trim_from_end](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/trim_from_end/).
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างโค้ดต่อไปนี้จะข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายของวิดีโอที่ฝังไว้ระหว่างการเล่น:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**อ่านการตั้งค่าการตัด**

เพื่อตรวจสอบการตั้งค่าการตัดที่มีอยู่ ให้โหลดงานนำเสนอ ค้นหาอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) parmi รูปร่างบนสไลด์แรก และอ่านค่าผ่าน [VideoFrame.trim_from_start](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/trim_from_start/) และ [VideoFrame.trim_from_end](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/trim_from_end/).

ตัวอย่างโค้ดต่อไปนี้จะค้นหาเฟรมวิดีโอแรกบนสไลด์แรกและแสดงการตั้งค่าการตัดเป็นมิลลิวินาที:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายถูกเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านคุณสมบัติ [VideoFrame.caption_tracks](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/caption_tracks/).

**เพิ่มคำบรรยายให้กับเฟรมวิดีโอ**

เพื่อเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
1. เพิ่มวิดีโอลงในงานนำเสนอ.
1. เพิ่มอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) ลงในสไลด์.
1. ใช้ [CaptionsCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/) ที่คืนมาจาก [caption_tracks](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/caption_tracks/) เพื่อเพิ่มแทร็คคำบรรยาย WebVTT.
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ดต่อไปนี้แสดงวิธีเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

คลาส [CaptionsCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้ด้วย

**ดึงคำบรรยายจากเฟรมวิดีโอ**

เพื่อดึงคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ
1. ค้นหาอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) เป้าหมาย
1. วนลูปผ่านคอลเลกชัน [caption_tracks](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/caption_tracks/)
1. บันทึกแต่ละแทร็คคำบรรยายเป็นไฟล์ `.vtt`.

โค้ดต่อไปนี้แสดงวิธีดึงคำบรรยายจากเฟรมวิดีโอ:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # บันทึกแทร็กคำบรรยายเป็นไฟล์ WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

แต่ละอ็อบเจ็กต์ [Captions](https://reference.aspose.com/slides/th/python-net/aspose.slides/captions/) จะเผยให้เห็นตัวระบุคำบรรยาย, ป้ายกำกับ, ข้อมูลไบนารี, และข้อความคำบรรยายในรูปแบบสตริง UTF-8

**ลบคำบรรยายจากเฟรมวิดีโอ**

เพื่อทำการลบคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ
1. รับอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) เป้าหมาย
1. ลบแทร็คคำบรรยายจาก [CaptionsCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/)
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ดต่อไปนี้แสดงวิธีลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

หากคุณต้องการลบเฉพาะแทร็คคำบรรยายหนึ่งเท่านั้น ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/remove/) หรือ [remove_at](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/remove_at/) แทนการใช้ [clear](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/clear/) 

## **ดึงวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอลงในสไลด์แล้ว Aspose.Slides ยังอนุญาตให้คุณดึงวิดีโอที่ฝังอยู่ในงานนำเสนอ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพื่อโหลดงานนำเสนอที่มีวิดีโอ
2. วนลูปผ่านออบเจ็กต์ [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) ทั้งหมด
3. วนลูปผ่านออบเจ็กต์ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/)
4. บันทึกวิดีโอลงดิสก์

โค้ด Python นี้แสดงวิธีดึงวิดีโอจากสไลด์ของงานนำเสนอ:

```python
import aspose.slides as slides

# สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดที่สามารถเปลี่ยนแปลงได้สำหรับ VideoFrame?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/play_mode/) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/play_loop_mode/). ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านคุณสมบัติของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/)

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX ไหม?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกรวมไว้ในเอกสาร ทำให้ขนาดของงานนำเสนอเพิ่มขึ้นตามขนาดของไฟล์ เมื่อคุณเพิ่มวิดีโอออนไลน์ จะฝังลิงก์และภาพย่อเท่านั้น ทำให้การเพิ่มขนาดเล็กกว่า

**ฉันสามารถแทนที่วิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ใช่ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/embedded_video/) ภายในเฟรมในขณะที่รักษาเรขาคณิตของรูปร่างไว้; นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังไว้ได้หรือไม่?**

ใช่ วิดีโอที่ฝังไว้มี [content type](https://reference.aspose.com/slides/th/python-net/aspose.slides/video/content_type/) ที่คุณสามารถอ่านและใช้ได้ เช่น เมื่อบันทึกลงดิสก์