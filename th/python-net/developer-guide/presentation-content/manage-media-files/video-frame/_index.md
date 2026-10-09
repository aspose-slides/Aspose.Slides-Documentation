---
title: "จัดการเฟรมวิดีโอในงานนำเสนอด้วย Python"
linktitle: "เฟรมวิดีโอ"
type: docs
weight: 10
url: /th/python-net/video-frame/
keywords:
- "เพิ่มวิดีโอ"
- "สร้างวิดีโอ"
- "ฝังวิดีโอ"
- "ดึงวิดีโอ"
- "เรียกคืนวิดีโอ"
- "เฟรมวิดีโอ"
- "แหล่งเว็บ"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "Python"
- "Aspose.Slides"
description: "เรียนรู้วิธีการเพิ่มและดึงเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument ด้วยโปรแกรมอย่างเป็นระบบโดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET คู่มือวิธีทำอย่างรวดเร็ว."
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้ Aspose.Slides สำหรับ Python ผ่าน .NET ให้คุณเพิ่มเฟรมวิดีโอบนสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และดึงข้อมูลวิดีโอที่ฝังอยู่ออกมา

PowerPoint รองรับวิดีโอในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอจาก YouTube

เพื่อแสดงข้อมูลวิดีโอและเฟรมวิดีโอ Aspose.Slides มีคลาส [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/), [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ

## **สร้างเฟรมวิดีโอแบบฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์จัดเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอในงานนำเสนอของคุณได้

ตัวอย่างนี้ฝังวิดีโอในเครื่องบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของเฟรมเป็นจุด (points) สตรีมจะเปิดอยู่จนกว่าการบันทึกจะเสร็จ เนื่องจาก [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) ทำให้มันล็อกขณะงานนำเสนอใช้งาน
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

คุณยังสามารถส่งเส้นทางวิดีโอในเครื่องโดยตรงไปยัง [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). ตัวอย่างนี้ฝังวิดีโอบนสไลด์แรกของงานนำเสนอใหม่ วิดีโอจะต้องเข้าถึงได้จนกว่าการบันทึกงานนำเสนอจะเสร็จ
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **สร้างเฟรมวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างเฟรมวิดีโอที่ลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอจาก YouTube

ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และรูปย่อลงบนสไลด์แรก แทนที่รหัสวิดีโอเพื่อใช้วิดีโออื่น การตั้งค่า [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) ขอให้เล่นอัตโนมัติ การดาวน์โหลดรูปย่อและการเล่นวิดีโอต้องการการเชื่อมต่ออินเทอร์เน็ต ตัวชมงานนำเสนอจะต้องสนับสนุนการเล่นวิดีโอออนไลน์ด้วย
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

ในงานนำเสนอการฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มหน้าจอเพื่อให้ผู้ชมเห็นรายละเอียด ตั้งค่า [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) เป็น `True` เพื่อเปิดพฤติกรรมนี้ขณะเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) แรกบนสไลด์แรกและเปิดการเล่นเต็มหน้าจอ งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก
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

การเล่นเต็มหน้าจอควบคุมวิธีการแสดงวิดีโอ อย่างแยกกัน [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) ควบคุมว่าจะเริ่มอัตโนมัติหรือเมื่อคลิก และ [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) ควบคุมว่าจะวนซ้ำหรือไม่ เพื่อเลือกพฤติกรรมการเริ่ม ให้ตั้งโหมดการเล่นเป็น [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). ตัวอย่างนี้รักษาการตั้งค่าเริ่มและวนซ้ำเดิมไว้

## **ย้อนวิดีโอหลังจากการเล่น**

ในงานนำเสนอการฝึกอบรม การย้อนวิดีโอสาธิตกลับไปยังจุดเริ่มต้นทำให้พร้อมสำหรับผู้บรรยายเล่นอีกครั้ง ตั้งค่า [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) เป็น `True` เพื่อย้อนวิดีโอไปจุดเริ่มต้นหลังจากการเล่นเสร็จ

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) แรกบนสไลด์แรกและเปิดการย้อนกลับ ปิดการวนซ้ำเพื่อให้การเล่นเสร็จและตั้งให้เริ่มเมื่อคลิก งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโอบนสไลด์แรก
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

การย้อนกลับทำให้วิดีโอย้อนกลับไปจุดเริ่มต้นโดยไม่เริ่มใหม่ ในทางตรงกันข้าม การเปิด [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) จะทำให้การเล่นวนซ้ำอัตโนมัติ ปิดการวนซ้ำเมื่อคุณต้องการให้วิดีโอเล่นจนจบและพร้อมเล่นซ้ำ [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) ควบคุมการเริ่มอัตโนมัติหรือเมื่อคลิกโดยแยกจากกัน; ตัวอย่างนี้ใช้ [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) เพื่อให้ผู้บรรยายกำหนดเวลาเริ่มเล่น ตั้งโหมดการเล่นหลังจากตั้งค่าการวนซ้ำตามที่แสดงในตัวอย่าง การย้อนกลับทำงานแยกจาก [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/)

## **ตัดเฟรมวิดีโอ**

ใช้ [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) และ [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) เพื่อข้ามส่วนต้นหรือส่วนสุดของวิดีโอขณะเล่น ค่าเป็นมิลลิวินาที การตัดแต่งปรับการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังอยู่

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายขณะเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้เหลือส่วนที่สามารถเล่นได้
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

ตัวอย่างนี้พิมพ์ค่าการตัดของเฟรมวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีเฟรมวิดีโอจะไม่มีการพิมพ์ ตัวอย่างก่อนหน้าจะได้ค่า 2500 และ 1000
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

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายถูกจัดเก็บในรูปแบบ WebVTT และเข้าถึงได้ผ่านคุณสมบัติ [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/)

**เพิ่มคำบรรยายให้กับเฟรมวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทรกคำบรรยาย WebVTT ที่ป้าชื่อว่า English เวลาตราประทับของคำบรรยายควรตรงกับวิดีโอ งานนำเสนอที่บันทึกจะมีทั้งวิดีโอและคำบรรยาย
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

คลาส [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) ยังมีการโหลดที่ทำให้คุณเพิ่มคำบรรยายจากสตรีมได้

**ดึงคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้บันทึกแทรกคำบรรยายทั้งหมดจากเฟรมวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกตามเลขลำดับ เพื่อให้ไฟล์ผลลัพธ์ไม่ซ้ำกัน คอนโซลแสดงจำนวนแทรกที่ดึงออก งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์
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

แต่ละอ็อบเจ็กต์ [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) เปิดเผยรหัสคำบรรยาย, ป้ายชื่อ, ข้อมูลไบนารี, และข้อความคำบรรยายเป็นสตริง UTF-8

**ลบคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอที่ตำแหน่งรูปร่างแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างเป็นเฟรมวิดีโอ
```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

หากต้องการลบเฉพาะแทรกคำบรรยายหนึ่งรายการ ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) หรือ [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) แทน [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/)

## **ดึงวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอลงสไลด์แล้ว Aspose.Slides ยังให้คุณดึงวิดีโอที่ฝังอยู่ในงานนำเสนอ

ตัวอย่างนี้ดึงวิดีโอที่ฝังจากทุกสไลด์เป็นไฟล์ไบนารีแยกตามหมายเลข วิดีโอที่ลิงก์จะถูกข้ามเพราะไม่มีข้อมูลฝัง คอนโซลพิมพ์ประเภท MIME ของแต่ละวิดีโอและจำนวนทั้งหมด ผลลัพธ์ใช้ส่วนขยาย `.bin` ทั่วไป; สามารถเปลี่ยนให้ตรงกับสื่อที่รายงานเมื่อจำเป็น
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

**พารามิเตอร์การเล่นวิดีโอที่สามารถเปลี่ยนแปลงสำหรับเฟรมวิดีโอได้มีอะไรบ้าง?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). ตัวเลือกเหล่านี้ใช้ได้ผ่านคุณสมบัติโปรพเพอร์ตี้ของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะรวมอยู่ในเอกสารทำให้ขนาดงานนำเพิ่มตามขนาดไฟล์ เมื่อคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มรูปย่อ งานนำจัดเก็บลิงก์และภาพตัวอย่างแทนข้อมูลวิดีโอ ดังนั้นการเพิ่มขนาดมักจะน้อยกว่า

**ฉันสามารถแทนที่วิดีโอในเฟรมวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ได้ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) ภายในเฟรมโดยคงรูปร่างไว้ นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลเอาต์ที่มีอยู่

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังได้หรือไม่?**

ได้ วิดีโอที่ฝังมี [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) ที่คุณสามารถอ่านและใช้ได้ เช่น เมื่อบันทึกลงดิสก์