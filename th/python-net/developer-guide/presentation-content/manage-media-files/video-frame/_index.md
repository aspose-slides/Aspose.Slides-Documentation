---
title: เพิ่มวิดีโอในงานนำเสนอด้วย Python
linktitle: กรอบวิดีโอ
type: docs
weight: 10
url: /th/python-net/video-frame/
keywords:
- เพิ่มวิดีโอ
- สร้างวิดีโอ
- ฝังวิดีโอ
- สกัดวิดีโอ
- ดึงวิดีโอ
- กรอบวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและสกัดกรอบวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมโดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET แนะนำวิธีทำอย่างรวดเร็ว"
---
## **บทนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณ  

PowerPoint ให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอในเครื่อง (เก็บไว้บนคอมพิวเตอร์ของคุณ)  
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube)

เพื่อให้คุณสามารถเพิ่มวิดีโอโค้ด (วัตถุวิดีโอ) ลงในงานนำเสนอ Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/th/python-net/aspose.slides/video/) , [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ

## **สร้าง VideoFrame ที่ฝังวิดีโอ**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์เก็บไว้ในเครื่องคุณสามารถสร้าง VideoFrame เพื่อฝังวิดีโอในงานนำเสนอของคุณได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เพิ่มอ็อบเจกต์ [Video](https://reference.aspose.com/slides/th/python-net/aspose.slides/video/) แล้วส่งพาธไฟล์วิดีโอเพื่อฝังวิดีโอกับงานนำเสนอ  
1. เพิ่มอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) เพื่อสร้างกรอบสำหรับวิดีโอ  
1. บันทึกงานนำเสนอที่ดัดแปลงแล้ว  

โค้ด Python นี้แสดงวิธีเพิ่มวิดีโอที่เก็บไว้ในเครื่องลงในงานนำเสนอ:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # ดึงสไลด์แรกและเพิ่มกรอบวิดีโอ
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # บันทึกงานนำเสนอลงดิสก์
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

หรือคุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์โดยตรงไปยังเมธอด `add_video_frame(x, y, width, height, fname)` :

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **สร้าง VideoFrame ด้วยวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) รองรับวิดีโอจาก YouTube ในงานนำเสนอ หากวิดีโอที่คุณต้องการใช้มีออนไลน์ (เช่นบน YouTube) คุณสามารถเพิ่มลงในงานนำเสนอผ่านลิงก์เว็บของมันได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เพิ่มอ็อบเจกต์ [Video](https://reference.aspose.com/slides/th/python-net/aspose.slides/video/) แล้วส่งลิงก์ไปยังวิดีโอ  
1. ตั้งค่า thumbnail สำหรับ VideoFrame  
1. บันทึกงานนำเสนอ  

โค้ด Python นี้แสดงวิธีเพิ่มวิดีโอจากเว็บลงในสไลด์ของงานนำเสนอ PowerPoint:

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

## **จัดการ Caption ของวิดีโอ**

Aspose.Slides ให้คุณจัดการ closed captions สำหรับ VideoFrame ในงานนำเสนอ PowerPoint Caption จะถูกเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านคุณสมบัติ [VideoFrame.caption_tracks](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/caption_tracks/)

**เพิ่ม Caption ให้กับ VideoFrame**

เพื่อเพิ่ม Caption ให้กับ VideoFrame:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. เพิ่มวิดีโอลงในงานนำเสนอ  
1. เพิ่มอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) ลงในสไลด์  
1. ใช้ [CaptionsCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/) ที่คืนค่าจาก [caption_tracks](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/caption_tracks/) เพื่อเพิ่ม WebVTT caption track  
1. บันทึกงานนำเสนอที่ดัดแปลงแล้ว  

โค้ดต่อไปนี้แสดงวิธีเพิ่ม Caption ให้กับ VideoFrame:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

คลาส [CaptionsCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/) ยังมี overload ที่ให้คุณเพิ่ม Caption จากสตรีมได้ด้วย

**สกัด Caption จาก VideoFrame**

เพื่อสกัด Caption จาก VideoFrame:

1. โหลดงานนำเสนอที่มีวิดีโออยู่  
1. ค้นหาอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) เป้าหมาย  
1. วนลูปผ่านคอลเลกชัน [caption_tracks](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/caption_tracks/)  
1. บันทึกแต่ละ caption track เป็นไฟล์ `.vtt`  

โค้ดต่อไปนี้แสดงวิธีสกัด Caption จาก VideoFrame:

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

แต่ละอ็อบเจกต์ [Captions](https://reference.aspose.com/slides/th/python-net/aspose.slides/captions/) จะเปิดเผยตัวระบุ Caption, ป้ายกำกับ, ข้อมูลไบนารี และข้อความ Caption ในรูปแบบสตริง UTF‑8

**ลบ Caption จาก VideoFrame**

เพื่อเอา Caption ออกจาก VideoFrame:

1. โหลดงานนำเสนอที่มีวิดีโออยู่  
1. รับอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) เป้าหมาย  
1. ลบ caption track จาก [CaptionsCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/)  
1. บันทึกงานนำเสนอที่ดัดแปลงแล้ว  

โค้ดต่อไปนี้แสดงวิธีลบ Caption ทั้งหมดจาก VideoFrame:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # ประเภท: slides.VideoFrame

    # ลบคำบรรยายทั้งหมดออกจากวิดีโอเฟรม.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

หากคุณต้องการลบเพียงหนึ่ง caption track ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/remove/) หรือ [remove_at](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/remove_at/) แทนการใช้ [clear](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/clear/)

## **สกัด Video จากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอลงในสไลด์ Aspose.Slides ยังอนุญาตให้คุณสกัดวิดีโอที่ฝังอยู่ในงานนำเสนอได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพื่อโหลดงานนำเสนอที่มีวิดีโอ  
2. วนลูปผ่านอ็อบเจกต์ [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) ทั้งหมด  
3. วนลูปผ่านอ็อบเจกต์ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/)  
4. บันทึกวิดีโอลงดิสก์  

โค้ด Python นี้แสดงวิธีสกัดวิดีโอจากสไลด์ของงานนำเสนอ:

```python
import aspose.slides as slides

# สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนแปลงได้สำหรับ VideoFrame?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/play_mode/) (อัตโนมัติหรือคลิก) และ [looping](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/play_loop_mode/) ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านคุณสมบัติของอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/)

**การเพิ่มวิดีโอส่งผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกรวมอยู่ในเอกสาร ทำให้ขนาดงานนำเสนอเพิ่มตามขนาดไฟล์ เมื่อคุณเพิ่มวิดีโอออนไลน์ จะฝังลิงก์และ thumbnail เท่านั้น ทำให้การเพิ่มขนาดน้อยกว่า

**ฉันสามารถแทนที่วิดีโอใน VideoFrame ที่มีอยู่ได้โดยไม่เปลี่ยนตำแหน่งและขนาดหรือไม่?**

ใช่ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/embedded_video/) ภายในกรอบได้โดยยังคงรักษาเรขาคณิตของรูปร่างไว้ นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเค้าโครงที่มีอยู่

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังไว้ได้หรือไม่?**

ใช่ วิดีโอที่ฝังไว้มี [content type](https://reference.aspose.com/slides/th/python-net/aspose.slides/video/content_type/) ที่คุณสามารถอ่านและใช้ได้ เช่นเมื่อต้องการบันทึกลงดิสก์