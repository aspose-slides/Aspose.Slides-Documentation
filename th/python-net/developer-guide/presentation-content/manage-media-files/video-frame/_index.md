---
title: จัดการกรอบวิดีโอในการนำเสนอด้วย Python
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
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและสกัดกรอบวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างอัตโนมัติด้วย Aspose.Slides สำหรับ Python via .NET. คู่มือวิธีทำอย่างรวดเร็ว."
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้ Aspose.Slides สำหรับ Python via .NET ให้คุณเพิ่มกรอบวิดีโอไปยังสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และสกัดข้อมูลวิดีโอที่ฝังอยู่

PowerPoint รองรับวิดีโอแบบโลคัลและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอจาก YouTube

เพื่อเป็นตัวแทนข้อมูลวิดีโอและกรอบวิดีโอ Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) คลาส [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) และประเภทอื่น ๆ ที่เกี่ยวข้อง

## **สร้างกรอบวิดีโอที่ฝังไว้**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ของคุณถูกเก็บไว้ในเครื่อง คุณสามารถสร้างกรอบวิดีโอเพื่อฝังวิดีโอลงในการนำเสนอของคุณ

ตัวอย่างนี้ฝังวิดีโอแบบโลคัลบนสไลด์แรกของการนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของกรอบจะเป็นหน่วยจุด สตรีมจะเปิดอยู่จนกว่าการบันทึกจะเสร็จสิ้น เพราะ [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) จะล็อกสตรีมขณะการนำเสนอใช้มัน

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

คุณยังสามารถส่งเส้นทางวิดีโอแบบโลคัลโดยตรงไปยัง [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). ตัวอย่างนี้ฝังวิดีโอลงบนสไลด์แรกของการนำเสนอใหม่ วิดีโอจะต้องสามารถเข้าถึงได้จนกว่าการนำเสนอจะถูกบันทึก

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **สร้างกรอบวิดีโอที่ใช้วิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในการนำเสนอ คุณสามารถสร้างกรอบวิดีโอที่ลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอจาก YouTube

ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และรูปย่อยลงบนสไลด์แรก แทนที่ตัวระบุวิดีโอเพื่อใช้วิดีโออื่น การตั้งค่า [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) ขอให้เล่นอัตโนมัติ การดาวน์โหลดรูปย่อยและการเล่นวิดีโอต้องใช้การเชื่อมต่ออินเทอร์เน็ต ตัวแสดงผลการนำเสนอจะต้องรองรับการเล่นวิดีโอออนไลน์ด้วย

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **เล่นวิดีโอในโหมดเต็มหน้าจอ**

ในงานนำเสนอการฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มหน้าจอเพื่อให้ผู้ชมเห็นรายละเอียดได้ ตั้งค่า [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) เป็น `True` เพื่อเปิดใช้งานพฤติกรรมนี้ระหว่างการเล่น

ตัวอย่างนี้เปิดการนำเสนอ ค้นหา [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) ตัวแรกบนสไลด์แรกและเปิดการเล่นแบบเต็มหน้าจอ การนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีกรอบวิดีโออยู่บนสไลด์แรก

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

การเล่นแบบเต็มหน้าจอควบคุมวิธีการแสดงวิดีโอ อย่างอิสระ [โหมดการเล่น](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) ควบคุมว่าจะเริ่มอัตโนมัติหรือเมื่อคลิก และ [การวนซ้ำ](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) ควบคุมว่าจะทำซ้ำหรือไม่ เพื่อเลือกพฤติกรรมการเริ่มต้น ให้ตั้งค่าโหมดการเล่นเป็น [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). ตัวอย่างนี้คงค่าการเริ่มและการวนซ้ำเดิมไว้

## **รีวินด์วิดีโอหลังการเล่น**

ในงานนำเสนอการฝึกอบรม การคืนวิดีโอสาธิตไปยังจุดเริ่มต้นทำให้พร้อมสำหรับผู้บรรยายที่จะเล่นอีกครั้ง ตั้งค่า [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) เป็น `True` เพื่อคืนวิดีโอไปยังจุดเริ่มต้นหลังการเล่นเสร็จ

ตัวอย่างนี้เปิดการนำเสนอ ค้นหา [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) ตัวแรกบนสไลด์แรกและเปิดการรีวินด์ มันปิดการวนซ้ำเพื่อให้การเล่นทำงานจนจบและตั้งค่าการเล่นให้เริ่มเมื่อคลิก การนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีกรอบวิดีโออยู่บนสไลด์แรก

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

การรีวินด์จะคืนวิดีโอไปยังจุดเริ่มต้นโดยไม่เริ่มต้นใหม่ ในทางตรงกันข้าม การเปิดใช้งาน [การวนซ้ำ](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) จะทำให้การเล่นวนซ้ำอัตโนมัติ ปิดการวนซ้ำเมื่อคุณต้องการให้วิดีโอเล่นจนจบและพร้อมที่จะเล่นใหม่ [โหมดการเล่น](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) ควบคุมการเริ่มแบบอัตโนมัติหรือเมื่อคลิก ตัวอย่างนี้ใช้ [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) เพื่อให้ผู้บรรยายควบคุมเวลาการเริ่มเล่น ตั้งค่าโหมดการเล่นหลังจากตั้งค่าการวนซ้ำตามที่แสดงในตัวอย่าง การรีวินด์ทำงานอิสระจาก [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **ตัดแต่งกรอบวิดีโอ**

ใช้ [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) และ [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) เพื่อข้ามส่วนต้นหรือส่วนท้ายของวิดีโอในระหว่างการเล่น ทั้งสองค่ามีหน่วยเป็นมิลลิวินาที การตัดทำการเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังอยู่

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอแบบโลคัลและข้าม 2.5 วินาทีแรกและวินาทีสุดท้ายในการเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้เหลือส่วนที่สามารถเล่นได้

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**อ่านค่าการตัด**

ตัวอย่างนี้พิมพ์ค่าการตัดของกรอบวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที การนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีกรอบวิดีโอ จะไม่แสดงอะไร ตัวอย่างก่อนหน้าผลลัพธ์เป็นค่า 2500 และ 1000

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides ช่วยให้คุณจัดการคำบรรยายปิดสำหรับกรอบวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และเปิดให้เข้าถึงผ่านคุณสมบัติ [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/)

### **เพิ่มคำบรรยายให้กับกรอบวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอแบบโลคัลและเพิ่มแทร็คคำบรรยาย WebVTT ที่มีป้ายว่า English. ไทม์สแตมป์ของคำบรรยายควรตรงกับวิดีโอ การนำเสนอที่บันทึกจะรวมทั้งวิดีโอและคำบรรยาย

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

คลาส [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีม

### **สกัดคำบรรยายจากกรอบวิดีโอ**

ตัวอย่างนี้บันทึกแทร็คคำบรรยายทั้งหมดจากกรอบวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกกัน ตัวเลขต่อเนื่องทำให้ไฟล์ผลลัพธ์แยกจากกัน คอนโซลรายงานจำนวนแทร็คที่สกัดออก การนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

แต่ละอ็อบเจกต์ [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) เปิดเผยตัวระบุคำบรรยาย ป้าย ช้อมูลไบนารี และข้อความคำบรรยายในรูปแบบสตริง UTF-8

### **ลบคำบรรยายจากกรอบวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากกรอบวิดีโาตำแหน่งรูปร่างแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างเป็นกรอบวิดีโอ

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

หากคุณต้องการลบเพียงแทร็คคำบรรยายเดียว ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) หรือ [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) แทน [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/)

### **ค้นหาคำบรรยายวิดีโอ**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) คืนค่าแทร็ค WebVTT ทั้งหมด รวมถึงส่วนหัว บรรทัดเวลา และข้อความคำบรรยาย ตัวอย่างเช่น แทร็ค English บนสไลด์ที่ 2 อาจมีคิวนี้:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

ตัวอย่างนี้เปิดไฟล์ `captioned_media.pptx` และอ่าน [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) ของแต่ละกรอบวิดีโอระดับบนบนทุกสไลด์ สำหรับแต่ละคิวข้อความธรรมดา มันค้นหาบรรทัดเวลาที่มี `-->` และรวบรวมบรรทัดคำบรรยายจนถึงบรรทัดว่างถัดไปหรือจบแทร็ค มันค้นหาข้อความคำบรรยายสำหรับคำ “café” โดยไม่คำนึงถึงตัวพิมพ์ใหญ่และพิมพ์หมายเลขสไลด์ ป้ายแทร็ค บรรทัดเวลาต้นฉบับ และคำบรรยายเต็มสำหรับแต่ละการจับคู่

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
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
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

แทร็คตัวอย่างให้ผลลัพธ์หนึ่งการจับคู่ “Café” ในหัวข้ออยู่นอกข้อความคำบรรยาย และผลลัพธ์คงการตั้งค่าเวลาและทั้งสองบรรทัดของคำบรรยาย

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **สกัดวิดีโอจากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอลงสไลด์แล้ว Aspose.Slides ยังให้คุณสกัดวิดีโอที่ฝังอยู่ในงานนำเสนอ

ตัวอย่างนี้สกัดวิดีโอที่ฝังอยู่จากทุกสไลด์เป็นไฟล์ไบนารีแยกตามหมายเลข วิดีโอที่ลิงก์จะถูกข้ามเนื่องจากไม่มีข้อมูลฝัง คอนโซลพิมพ์ประเภท MIME ของแต่ละวิดีโอและจำนวนทั้งหมด ผลลัพธ์ใช้ส่วนขยาย `.bin` ทั่วไป; เปลี่ยนตามชนิดสื่อตามที่รายงานเมื่อจำเป็น

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนแปลงได้สำหรับกรอบวิดีโอ?**

คุณสามารถควบคุม [โหมดการเล่น](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (อัตโนมัติหรือเมื่อคลิก) และ [การวนซ้ำ](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) ได้ ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านคุณสมบัติของอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอแบบโลคัล ข้อมูลไบนารีจะถูกรวมอยู่ในเอกสาร ดังนั้นขนาดการนำเสนอจะเพิ่มตามขนาดไฟล์ เมื่อคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มรูปย่อย การนำเสนอจะเก็บลิงก์และภาพแสดงตัวอย่างแทนข้อมูลวิดีโอ ดังนั้นการเพิ่มขนาดจึงมักจะน้อยกว่า

**ฉันสามารถแทนที่วิดีโอในกรอบวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ใช่ คุณสามารถสลับ [เนื้อหาวิดีโอ](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) ภายในกรอบขณะที่คงรูปทรงของรูปร่างไว้; นี่เป็นกรณีที่พบบ่อยสำหรับการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังไว้ได้หรือไม่?**

ใช่ วิดีโอที่ฝังไว้มี [ประเภทเนื้อหา](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) ที่คุณสามารถอ่านและนำไปใช้ได้ เช่นเมื่อต้องการบันทึกลงดิสก์