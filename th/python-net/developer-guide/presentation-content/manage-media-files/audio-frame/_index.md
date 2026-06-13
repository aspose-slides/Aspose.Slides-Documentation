---
title: จัดการเสียงในงานนำเสนอด้วย Python
linktitle: เฟรมเสียง
type: docs
weight: 10
url: /th/python-net/audio-frame/
keywords:
- เพิ่มเสียง
- ฝังเสียง
- เฟรมเสียง
- ไฟล์เสียง
- คุณสมบัติของเสียง
- สกัดเสียง
- ดึงเสียง
- เปลี่ยนเสียง
- ตัวเลือกการเล่น
- โหมดการเล่น
- เล่นผ่านหลายสไลด์
- วนซ้ำจนหยุด
- ซ่อนระหว่างการแสดง
- รีเวินด์หลังการเล่น
- ปริมาณเสียง
- ภาพเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่ม, สกัดและจัดการเฟรมเสียงใน PPT, PPTX และ ODP ได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. สำรวจตัวอย่างโค้ดและยกระดับงานนำเสนอของคุณวันนี้."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับเฟรมเสียงใน Aspose.Slides แสดงวิธีเพิ่มเสียงฝังในสไลด์ ปรับแต่งภาพย่อของเฟรมเสียง กำหนดค่าตัวเลือกการเล่นเช่น ปริมาณเสียง การวนซ้ำ การซ่อน การตัดและระยะเวลาเฟด รวมถึงการสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์

## **สร้างเฟรมเสียง**

Aspose.Slides สำหรับ Python ผ่าน .NET ให้คุณเพิ่มไฟล์เสียงลงในสไลด์ ไฟล์เสียงจะถูกฝังในสไลด์เป็นเฟรมเสียง  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. โหลดสตรีมไฟล์เสียงที่คุณต้องการฝังในสไลด์  
4. เพิ่มเฟรมเสียงที่ฝังไว้ (ซึ่งมีไฟล์เสียง) ลงในสไลด์  
5. ตั้งค่า [PlayMode](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioplaymodepreset) และ `Volume` ที่เปิดโดยอ็อบเจกต์ [IAudioFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/)  
6. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Python นี้แสดงวิธีเพิ่มเฟรมเสียงที่ฝังไว้ลงในสไลด์:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์คลาสการนำเสนอที่แทนไฟล์การนำเสนอ
with slides.Presentation() as pres:
    # ดึงสไลด์แรก
    sld = pres.slides[0]

    # โหลดไฟล์เสียง wav ไปเป็นสตรีม
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # เพิ่มเฟรมเสียง
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # ตั้งค่าโหมดการเล่นและระดับเสียงของออดิโอ
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # บันทึกไฟล์ PowerPoint ลงดิสก์
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **เปลี่ยนภาพย่อเฟรมเสียง**

เมื่อคุณเพิ่มไฟล์เสียงเข้าในงานนำเสนอ เสียงจะแสดงเป็นเฟรมพร้อมภาพเริ่มต้นมาตรฐาน (ดูภาพในส่วนด้านล่าง) คุณสามารถเปลี่ยนภาพย่อของเฟรมเสียง (กำหนดภาพที่คุณต้องการ) ได้  

โค้ด Python นี้แสดงวิธีเปลี่ยนภาพย่อหรือภาพแสดงตัวอย่างของเฟรมเสียง:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มเฟรมเสียงไปยังสไลด์ด้วยตำแหน่งและขนาดที่ระบุ.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # ตั้งค่ารูปภาพสำหรับเฟรมเสียง.
        audioFrame.picture_format.picture.image = audioImage
        
        #บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **เปลี่ยนตัวเลือกการเล่นเสียง**

Aspose.Slides สำหรับ Python ผ่าน .NET ให้คุณเปลี่ยนตัวเลือกที่ควบคุมการเล่นหรือคุณสมบัติของเสียง ตัวอย่างเช่น คุณสามารถปรับระดับเสียงของเสียง ตั้งค่าให้เสียงเล่นวนซ้ำ หรือแม้กระทั่งซ่อนไอคอนเสียง  

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** ที่สอดคล้องกับคุณสมบัติของ Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/) :

- **Start** รายการดรอปดาวน์ตรงกับคุณสมบัติ [AudioFrame.play_mode](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/play_mode/) 
- **Volume** ตรงกับคุณสมบัติ [AudioFrame.volume](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/volume/) 
- **Play Across Slides** ตรงกับคุณสมบัติ [AudioFrame.play_across_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/play_across_slides/) 
- **Loop until Stopped** ตรงกับคุณสมบัติ [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/play_loop_mode/) 
- **Hide During Show** ตรงกับคุณสมบัติ [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/hide_at_showing/) 
- **Rewind after Playing** ตรงกับคุณสมบัติ [AudioFrame.rewind_audio](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/rewind_audio/) 

PowerPoint **Editing** options ที่สอดคล้องกับคุณสมบัติของ Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/) :

- **Fade In** ตรงกับคุณสมบัติ [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/fade_in_duration/) 
- **Fade Out** ตรงกับคุณสมบัติ [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/fade_out_duration/) 
- **Trim Audio Start Time** ตรงกับคุณสมบัติ [AudioFrame.trim_from_start](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/trim_from_start/) 
- **Trim Audio End Time** ค่าเท่ากับระยะเวลาของเสียงลบด้วยค่าของคุณสมบัติ [AudioFrame.trim_from_end](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/trim_from_end/) 

The PowerPoint **Volume controll** on the audio control panel corresponds to the [AudioFrame.volume_value](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/volume_value/) property. It lets you change the audio volume as a percentage.

นี่คือวิธีเปลี่ยนตัวเลือกการเล่นเสียง:

1. [สร้าง](#create-audio-frame) หรือรับ Audio Frame  
2. ตั้งค่าค่าใหม่สำหรับคุณสมบัติของ Audio Frame ที่ต้องการปรับ  
3. บันทึกไฟล์ PowerPoint ที่แก้ไขแล้ว  

โค้ด Python นี้แสดงการทำงานที่ปรับตัวเลือกของเสียง:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # ดึงรูปร่าง AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # ตั้งค่าโหมดการเล่นให้เล่นเมื่อคลิก
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # ตั้งค่าปริมาณเสียงเป็นต่ำ
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # ตั้งค่าให้เสียงเล่นผ่านหลายสไลด์
    audioFrame.play_across_slides = True

    # ปิดการวนลูปสำหรับเสียง
    audioFrame.play_loop_mode = False

    # ซ่อน AudioFrame ในระหว่างการแสดงสไลด์
    audioFrame.hide_at_showing = True

    # รีเวินด์เสียงกลับไปเริ่มต้นหลังการเล่น
    audioFrame.rewind_audio = True

    # บันทึกไฟล์ PowerPoint ลงดิสก์
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

โค้ด Python ตัวอย่างนี้แสดงวิธีเพิ่มเฟรมเสียงใหม่พร้อมเสียงฝัง, ตัดส่วนทำให้สั้น, และตั้งค่าระยะเวลาเฟด:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # กำหนดจุดเริ่มต้นการตัดเป็น 1.5 วินาที
    audio_frame.trim_from_start = 1500.0
    # กำหนดจุดสิ้นสุดการตัดเป็น 2 วินาที
    audio_frame.trim_from_end = 2000.0

    # กำหนดระยะเวลาเฟดอินเป็น 200 มิลลิวินาที
    audio_frame.fade_in_duration = 200.0
    # กำหนดระยะเวลาเฟดเอาต์เป็น 500 มิลลิวินาที
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึงเฟรมเสียงที่ฝังไว้และตั้งค่าปริมาณเสียงเป็น 85%:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # ดึงรูปร่างเฟรมเสียง
    audio_frame = pres.slides[0].shapes[0]

    # ตั้งค่าปริมาณเสียงเป็น 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการคำบรรยายเสียง**

Aspose.Slides ให้คุณเพิ่มคำบรรยายแบบปิดสำหรับเฟรมเสียงผ่านคุณสมบัติ [caption_tracks](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/caption_tracks/) คุณสมบัตินี้จะคืนค่า [CaptionsCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/) ซึ่งช่วยให้คุณเพิ่มแทร็กคำบรรยาย WebVTT, วนลูปผ่านแทร็กที่มีอยู่, และลบแทร็กเมื่อจำเป็น  

**เพิ่มคำบรรยายเสียง**

ใช้คุณสมบัติ [caption_tracks](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/caption_tracks/) เพื่อแนบแทร็กคำบรรยายหนึ่งหรือหลายแทร็กให้กับเฟรมเสียง ในตัวอย่างต่อไปนี้ไฟล์เสียงจะถูกเพิ่มลงในสไลด์ จากนั้นแทร็กคำบรรยายใหม่จะถูกโหลดจากไฟล์ `.vtt`

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**สกัดคำบรรยายเสียง**

คุณสามารถวนลูปผ่านแทร็กคำบรรยายที่เชื่อมต่อกับเฟรมเสียงและบันทึกเป็นไฟล์ `.vtt` แต่ละแทร็กคำบรรยายจะเผยข้อมูลไบต์และตัวระบุที่ไม่ซ้ำกัน ซึ่งสามารถใช้เมื่อส่งออกคำบรรยาย

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # บันทึกแทร็กคำบรรยายเป็นไฟล์ .vtt
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**ลบคำบรรยายเสียง**

เพื่อลบคำบรรยายจากเฟรมเสียง ใช้วิธีการที่ให้โดย [CaptionsCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/) เช่น [clear](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/remove/), หรือ [remove_at](https://reference.aspose.com/slides/th/python-net/aspose.slides/captionscollection/remove_at/). ตัวอย่างต่อไปนี้ลบแทร็กคำบรรยายทั้งหมดจากเฟรมเสียง

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # ประเภท: slides.AudioFrame

    # ลบแทร็กคำบรรยายทั้งหมดจากเฟรมเสียง.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **สกัดเสียง**

Aspose.Slides สำหรับ Python ผ่าน .NET ให้คุณสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์ ตัวอย่างเช่น คุณสามารถสกัดเสียงที่ใช้ในสไลด์เฉพาะได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีเสียง  
2. รับอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน  
3. เข้าถึงการเปลี่ยนสไลด์ของสไลด์นั้น  
4. สกัดเสียงเป็นข้อมูลไบต์  

โค้ด Python นี้แสดงวิธีสกัดเสียงที่ใช้ในสไลด์:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # เข้าถึงสไลด์ที่ต้องการ
    slide = pres.slides[0]  

    # ดึงเอฟเฟกต์การเปลี่ยนสไลด์โชว์สำหรับสไลด์
    transition = slide.slide_show_transition

    #สกัดเสียงเป็นอาร์เรย์ไบต์
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ไฟล์เสียงเดียวกันบนหลายสไลด์โดยไม่ทำให้ไฟล์ขนาดใหญ่ขึ้นได้หรือไม่?**

ใช่ เพิ่มเสียงเพียงครั้งเดียวใน [audio collection](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/audios/) ที่ใช้ร่วมกันของงานนำเสนอและสร้างเฟรมเสียงเพิ่มเติมที่อ้างอิงสินทรัพย์ที่มีอยู่แล้ว วิธีนี้จะหลีกเลี่ยงการทำซ้ำข้อมูลสื่อและทำให้ขนาดงานนำเสนออยู่ภายในขอบเขตที่ควบคุมได้  

**ฉันสามารถแทนที่เสียงในเฟรมเสียงที่มีอยู่โดยไม่ต้องสร้างรูปร่างใหม่ได้หรือไม่?**

ใช่ สำหรับเสียงแบบลิงก์ ให้อัปเดต [link path](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/link_path_long/) ให้ชี้ไปยังไฟล์ใหม่ สำหรับเสียงที่ฝังไว้ ให้สลับออบเจกต์ [embedded audio](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/embedded_audio/) กับออบเจกต์อื่นจาก [audio collection](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/audios/) ของงานนำเสนอ รูปแบบของเฟรมและการตั้งค่าการเล่นส่วนใหญ่จะคงเดิม  

**การตัดส่วนทำให้ข้อมูลเสียงต้นฉบับที่จัดเก็บในงานนำเสนอเปลี่ยนหรือไม่?**

ไม่ การตัดส่วนปรับแค่ขอบเขตการเล่นเท่านั้น ไบต์เสียงต้นฉบับจะไม่ถูกเปลี่ยนแปลงและยังคงเข้าถึงได้ผ่านเสียงที่ฝังหรือผ่าน [audio collection] ของงานนำเสนอ