---
title: จัดการส่วนหัวและส่วนท้ายของงานนำเสนอด้วย Python
linktitle: ส่วนหัวและส่วนท้าย
type: docs
weight: 140
url: /th/python-net/presentation-header-and-footer/
keywords:
- ส่วนหัว
- ข้อความส่วนหัว
- ส่วนท้าย
- ข้อความส่วนท้าย
- ตั้งส่วนหัว
- ตั้งส่วนท้าย
- เอกสารประกอบ
- โน้ต
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อเพิ่มและปรับแต่งส่วนหัวและส่วนท้ายในงานนำเสนอ PowerPoint และ OpenDocument ให้ดูเป็นมืออาชีพ"
---
## **ภาพรวม**

Aspose.Slides for Python ช่วยให้คุณควบคุมตัวยึดส่วนหัวและส่วนท้ายในทั่วทั้งงานนำเสนอได้อย่างแม่นยำ ส่วนข้อความส่วนท้าย วันที่/เวลา และหมายเลขสไลด์บนสไลด์จะถูกจัดการจากระดับมาสเตอร์และสามารถนำไปใช้ทั่วทั้งงานหรือปรับตามสไลด์แต่ละสไลด์ได้ ส่วนหัวรองรับในโน้ตและเอกสารประกอบที่พิมพ์ออกได้ ซึ่งคุณสามารถเปิด/ปิดการมองเห็นและตั้งค่าขข้อความสำหรับส่วนหัว ส่วนท้าย วันที่/เวลา และหมายเลขหน้าได้ผ่านตัวจัดการส่วนหัวและส่วนท้ายบนสไลด์โน้ตมาสเตอร์หรือสไลด์โน้ตแต่ละหน้า บทความนี้สรุปรูปแบบสำคัญในการอัปเดตตัวยึดเหล่านี้และกระจายการเปลี่ยนแปลงอย่างสม่ำเสมอตลอดเด็คของคุณ

## **จัดการข้อความส่วนหัวและส่วนท้าย**

ในส่วนนี้ คุณจะได้เรียนรู้วิธีจัดการเนื้อหาส่วนหัวและส่วนท้ายในงานนำเสนอ—เปิดหรือแก้ไขส่วนท้าย วันที่และเวลา และหมายเลขสไลด์ เราจะสรุปขอบเขตการนำการตั้งค่าเหล่านี้ไปใช้ (ทั้งงานนำเสนอทั้งหมด สไลด์แต่ละสไลด์ และมุมมองโน้ต/เอกสารประกอบ) และแสดงวิธีใช้ Aspose.Slides API เพื่ออัปเดตอย่างรวดเร็วและสม่ำเสมอ

ตัวอย่างโค้ดด้านล่างจะเปิดงานนำเสนอ เปิดและตั้งค่าข้อความส่วนท้าย อัปเดตข้อความส่วนหัวบนสไลด์โน้ตมาสเตอร์ และบันทึกไฟล์

```py
import aspose.slides as slides

# ฟังก์ชันเพื่อกำหนดข้อความส่วนหัว.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# โหลดงานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:
    # ตั้งส่วนท้าย.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # เข้าถึงและอัปเดตส่วนหัว.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # บันทึกงานนำเสนอ.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการส่วนหัวและส่วนท้ายบนสไลด์โน้ต**

ในส่วนนี้ คุณจะได้เรียนรู้วิธีจัดการส่วนหัวและส่วนท้ายโดยเฉพาะสำหรับสไลด์โน้ตใน Aspose.Slides เราจะอธิบายการเปิดใช้งานตัวยึดที่เกี่ยวข้อง การตั้งค่าข้อความสำหรับส่วนท้าย วันที่/เวลา และหมายเลขหน้า รวมถึงการนำการเปลี่ยนแปลงเหล่านี้ไปใช้โดยสม่ำเสมอในมาสเตอร์โน้ตและหน้โน้ตแต่ละหน้า

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์งานนำเสนอ
1. รับสไลด์โน้ตมาสเตอร์และ [header & footer manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslideheaderfootermanager/)
1. บนสไลด์โน้ตมาสเตอร์ เปิดการแสดงผลของ Header, Footer, Slide number, และ Date-time สำหรับมาสเตอร์และสไลด์โน้ตลูกทั้งหมด
1. บนสไลด์โน้ตมาสเตอร์ ตั้งค่าข้อความสำหรับ Header, Footer, และ Date-time สำหรับมาสเตอร์และสไลด์โน้ตลูกทั้งหมด
1. รับสไลด์โน้ตสำหรับสไลด์แรกของงานนำเสนอและ [header & footer manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/notesslideheaderfootermanager/)
1. สำหรับสไลด์โน้ตแรกนี้เท่านั้น ให้แน่ใจว่าการแสดง Header, Footer, Slide number, และ Date-time เปิดอยู่ (เปิดส่วนที่ปิดอยู่ทั้งหมด)
1. สำหรับสไลด์โน้ตแรกนี้เท่านั้น ตั้งค่าข้อความสำหรับ Header, Footer, และ Date-time
1. บันทึกงานนำเสนอเป็นรูปแบบ PPTX

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # ทำให้สไลด์โน้ตมาสเตอร์และตัวยึดส่วนหัว ส่วนท้าย หมายเลขสไลด์ และวันที่/เวลาของลูกทั้งหมดปรากฏ.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # ตั้งข้อความบนสไลด์โน้ตมาสเตอร์และตัวยึดส่วนหัว ส่วนท้าย และวันที่/เวลาของลูกทั้งหมด.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # เปลี่ยนการตั้งค่าส่วนหัว ส่วนท้าย หมายเลขสไลด์ และวันที่/เวลาเฉพาะสไลด์โน้ตแรกเท่านั้น.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # ตรวจสอบให้แน่ใจว่าตัวยึดส่วนหัว ส่วนท้าย หมายเลขสไลด์ และวันที่/เวลาปรากฏ.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # ตั้งข้อความบนตัวยึดส่วนหัว ส่วนท้าย และวันที่/เวลาของสไลด์โน้ต.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # บันทึกงานนำเสนอ.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่ม “header” ให้กับสไลด์ทั่วไปได้หรือไม่?**

ใน PowerPoint “Header” มีเฉพาะสำหรับโน้ตและเอกสารประกอบที่พิมพ์ออก; ในสไลด์ทั่วไป มีเพียงส่วนท้าย วันที่/เวลา และหมายเลขสไลด์ที่สนับสนุนเท่านั้น ใน Aspose.Slides มีข้อจำกัดเช่นเดียวกัน: header มีเฉพาะในโน้ต/เอกสารประกอบ, ส่วนในสไลด์มีแค่ Footer/DateTime/SlideNumber

**ถ้าการจัดรูปแบบไม่มีพื้นที่ส่วนท้าย—ฉันสามารถ “เปิด” การมองเห็นได้หรือไม่?**

ได้. ตรวจสอบการมองเห็นผ่านตัวจัดการส่วนหัว/ส่วนท้ายและเปิดใช้งานหากจำเป็น ตัวชี้วัดและเมธอดของ API นี้ออกแบบมาสำหรับกรณีที่ตัวยึดหายไปหรือถูกซ่อนไว้

**ฉันจะทำให้หมายเลขสไลด์เริ่มจากค่าที่ไม่ใช่ 1 ได้อย่างไร?**

ตั้งค่า [first slide number](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/first_slide_number/) ของงานนำเสนอ; จากนั้นหมายเลขทั้งหมดจะถูกคำนวณใหม่ ตัวอย่างเช่น คุณสามารถเริ่มที่ 0 หรือ 10 และซ่อนหมายเลขบนสไลด์หัวเรื่อง

**เกิดอะไรขึ้นกับส่วนหัว/ส่วนท้ายเมื่อส่งออกเป็น PDF/ภาพ/HTML?**

พวกมันจะถูกเรนเดอร์เป็นองค์ประกอบข้อความทั่วไปของงานนำเสนอ กล่าวคือ หากองค์ประกอบเหล่านั้นมองเห็นได้บนสไลด์หรือหน้าโน้ต จะปรากฏในรูปแบบผลลัพธ์พร้อมกับเนื้อหาอื่น ๆ ด้วย