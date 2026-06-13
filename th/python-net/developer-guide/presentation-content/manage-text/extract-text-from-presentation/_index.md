---
title: การดึงข้อความขั้นสูงจากการนำเสนอใน Python
linktitle: ดึงข้อความ
type: docs
weight: 90
url: /th/python-net/extract-text-from-presentation/
keywords:
- ดึงข้อความ
- ดึงข้อความจากสไลด์
- ดึงข้อความจากการนำเสนอ
- ดึงข้อความจาก PowerPoint
- ดึงข้อความจาก OpenDocument
- ดึงข้อความจาก PPT
- ดึงข้อความจาก PPTX
- ดึงข้อความจาก ODP
- เรียกคืนข้อความ
- เรียกคืนข้อความจากสไลด์
- เรียกคืนข้อความจากการนำเสนอ
- เรียกคืนข้อความจาก PowerPoint
- เรียกคืนข้อความจาก OpenDocument
- เเรียกคืนข้อความจาก PPT
- เรียกคืนข้อความจาก PPTX
- เรียกคืนข้อความจาก ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ดึงข้อความจากการนำเสนอ PowerPoint และ OpenDocument อย่างรวดเร็วโดยใช้ Aspose.Slides for Python ผ่าน .NET. ปฏิบัติตามคำแนะนำแบบทีละขั้นตอนของเราเพื่อประหยัดเวลา."
---
## **ภาพรวม**

การดึงข้อความจากการนำเสนอเป็นงานที่พบบ่อยแต่มีความสำคัญสำหรับนักพัฒนาที่ทำงานกับเนื้อหาสไลด์ ไม่ว่าคุณจะจัดการไฟล์ Microsoft PowerPoint ในรูปแบบ PPT หรือ PPTX หรือการนำเสนอ OpenDocument (ODP) การเข้าถึงและดึงข้อมูลข้อความอาจเป็นสิ่งจำเป็นสำหรับการวิเคราะห์, การทำอัตโนมัติ, การทำดัชนี, หรือการย้ายเนื้อหา

บทความนี้ให้คำแนะนำอย่างครบถ้วนเกี่ยวกับวิธีการดึงข้อความจากรูปแบบการนำเสนอหลายแบบอย่างมีประสิทธิภาพ รวมถึง PPT, PPTX, และ ODP โดยใช้ Aspose.Slides for Python via .NET คุณจะได้เรียนรู้วิธีวนลูปผ่านองค์ประกอบของการนำเสนอเพื่อดึงข้อความที่ต้องการอย่างแม่นยำ

## **ดึงข้อความจากสไลด์**

Aspose.Slides for Python via .NET ให้บริการ namespace [aspose.slides.util](https://reference.aspose.com/slides/th/python-net/aspose.slides.util/) ซึ่งรวมคลาส [SlideUtil](https://reference.aspose.com/slides/th/python-net/aspose.slides.util/slideutil/) คลาสนี้เปิดเผยเมธอด static ที่มีการ overload หลายแบบสำหรับการดึงข้อความทั้งหมดจากการนำเสนอหรือสไลด์ เพื่อดึงข้อความจากสไลด์ในการนำเสนอ ให้ใช้เมธอด [get_all_text_boxes](https://reference.aspose.com/slides/th/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) เมธอดนี้รับอ็อบเจกต์ประเภท [BaseSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/) เป็นพารามิเตอร์ เมื่อทำงาน เมธอดจะสแกนสไลด์ทั้งหมดเพื่อค้นหาข้อความและคืนค่าเป็นอาเรย์ของอ็อบเจกต์ประเภท [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) พร้อมรักษาการจัดรูปแบบของข้อความ

โค้ดตัวอย่างต่อไปนี้ดึงข้อความทั้งหมดจากสไลด์แรกของการนำเสนอ:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **ดึงข้อความจากการนำเสนอ**

เพื่อสแกนข้อความจากการนำเสนอทั้งหมด ให้ใช้เมธอด static [get_all_text_frames](https://reference.aspose.com/slides/th/python-net/aspose.slides.util/slideutil/get_all_text_frames/) ของคลาส [SlideUtil](https://reference.aspose.com/slides/th/python-net/aspose.slides.util/slideutil/) เมธอดนี้รับพารามิเตอร์สองค่า:

1. อ็อบเจกต์ประเภท [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ที่แทนการนำเสนอ PowerPoint หรือ OpenDocument ที่ต้องการดึงข้อความ
2. ค่า `Boolean` ที่ระบุว่าควรรวมสไลด์แม่ (master slides) ในการสแกนข้อความจากการนำเสนอหรือไม่

เมธอดจะคืนค่าเป็นอาเรย์ของอ็อบเจกต์ประเภท [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ซึ่งรวมข้อมูลการจัดรูปแบบของข้อความด้วย โค้ดด้านล่างสแกนข้อความและรายละเอียดการจัดรูปแบบจากการนำเสนอ รวมถึงสไลด์แม่ด้วย

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **การดึงข้อความแบบแบ่งประเภทและเร็ว**

คลาส [PresentationFactory](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/) ยังมีเมธอดสำหรับดึงข้อความทั้งหมดจากการนำเสนอ:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

อาร์กิวเมนต์ enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/th/python-net/aspose.slides/textextractionarrangingmode/) ระบุโหมดการจัดระเบียบผลลัพธ์การดึงข้อความและสามารถตั้งเป็นค่าต่อไปนี้:
- `UNARRANGED` - ข้อความดิบโดยไม่คำนึงถึงตำแหน่งบนสไลด์
- `ARRANGED` - ข้อความจัดเรียงตามลำดับเดียวกับบนสไลด์

โหมด `UNARRANGED` สามารถใช้เมื่อความเร็วเป็นสิ่งสำคัญ; มันเร็วกว่าโหมด `ARRANGED`

[PresentationText](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationtext/) แทนข้อความดิบที่ดึงจากการนำเสนอ property `slides_text` จะคืนค่าเป็นอาเรย์ของอ็อบเจกต์ข้อความสไลด์ แต่ละอ็อบเจกต์แทนข้อความบนสไลด์ที่สอดคล้องและมีคุณสมบัติดังนี้:

- `text` - ข้อความในรูปทรงของสไลด์
- `master_text` - ข้อความในรูปทรงของสไลด์แม่ที่เกี่ยวข้องกับสไลด์นี้
- `layout_text` - ข้อความในรูปทรงของสไลด์เค้าโครงที่เกี่ยวข้องกับสไลด์นี้
- `notes_text` - ข้อความในรูปทรงของสไลด์โน้ตที่เกี่ยวข้องกับสไลด์นี้
- `comments_text` - ข้อความในความคิดเห็นที่เกี่ยวข้องกับสไลด์นี้

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **คำถามที่พบบ่อย**

**Aspose.Slides ประมวลผลการนำเสนอขนาดใหญ่ระหว่างการดึงข้อความได้เร็วแค่ไหน?**

Aspose.Slides ได้รับการปรับให้ทำงานด้วยประสิทธิภาพสูงและสามารถประมวลผลแม้ [การนำเสนอขนาดใหญ่](/slides/th/python-net/open-presentation/) ทำให้เหมาะสำหรับสถานการณ์การประมวลผลแบบเรียลไทม์หรือแบบจำนวนมาก

**Aspose.Slides สามารถดึงข้อความจากตารางและแผนภูมิในการนำเสนอได้หรือไม่?**

ได้ Aspose.Slides สามารถดึงข้อความจากหลายองค์ประกอบของสไลด์ รวมถึงตารางและวัตถุที่เกี่ยวข้องกับแผนภูมิ ทำให้คุณสามารถเข้าถึงและวิเคราะห์เนื้อหาข้อความในโครงสร้างการนำเสนอทั่วไปได้

**ฉันต้องมีใบอนุญาตพิเศษของ Aspose.Slides เพื่อดึงข้อความจากการนำเสนอหรือไม่?**

คุณสามารถดึงข้อความได้ด้วยเวอร์ชันทดลองฟรีของ Aspose.Slides แม้จะมี [ข้อจำกัดบางประการ](/slides/th/python-net/licensing/) เช่น การประมวลผลจำนวนสไลด์ที่จำกัด เพื่อการใช้งานโดยไม่มีข้อจำกัดและเพื่อจัดการกับการนำเสนอที่ใหญ่ขึ้น แนะนำให้ซื้อใบอนุญาตเต็มรูปแบบ.