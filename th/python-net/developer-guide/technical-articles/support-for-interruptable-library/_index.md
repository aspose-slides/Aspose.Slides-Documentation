---
title: ขัดจังหวะการดำเนินการนำเสนอที่ใช้เวลานานใน Python
linktitle: ขัดจังหวะการดำเนินการนำเสนอ
type: docs
weight: 150
url: /th/python-net/support-for-interruptable-library/
keywords:
- การดำเนินการที่ขัดจังหวะได้
- โทเค็นการขัดจังหวะ
- ยกเลิกการส่งออก PDF
- PowerPoint
- Python
- Aspose.Slides
description: "เรียนรู้วิธียกเลิกการแปลงงานนำเสนอใน Python และคืนรายการสไลด์ที่เสร็จสิ้นการส่งออกก่อนการยกเลิก."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET รองรับการยกเลิกแบบร่วมมือระหว่างการดำเนินการที่ใช้เวลานาน เช่น การโหลด การบันทึก และการเรนเดอร์งานนำเสนอ เมื่อคุณส่งออกสไลด์แต่ละสไลด์ คุณยังสามารถตรวจสอบการยกเลิกระหว่างสไลด์และส่งคืนหมายเลขของสไลด์ที่เสร็จสิ้นการส่งออก

## **ยกเลิกการแปลงงานนำเสนอ**

สร้าง [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), กำหนด [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) ให้กับ [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/), แล้วส่งตัวเลือกไปยัง [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). โทเค็นนี้จะใช้กับงานนำเสนอตลอดอายุการทำงานของมัน เพื่อขอการยกเลิกจากแอปพลิเคชันของคุณ ให้เรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

ตัวอย่างจะแปลง `sample.pptx` เป็น `sample.pdf`. [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) จะเรียก `source.interrupt` หลังจาก 20 วินาที การเริ่มต้นตัวจับเวลา ก่อนเปิดไฟล์ทำให้หมดเวลานี้ใช้กับการโหลดและการบันทึกด้วย แอปพลิเคชันที่มีปุ่ม Cancel สามารถเรียกเมธอดเดียวกันจากตัวจัดการเหตุการณ์ของมันได้.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

การตรวจสอบอย่างชัดเจนหลังจากการโหลดจะข้ามการส่งออกหากเวลาจำกัดได้หมดแล้ว หากการโหลดหรือการบันทึกพบคำขอ การยกเลิกจะส่งข้อยกเว้นกลับไปยังผู้เรียก การบันทึกอาจเสร็จก่อนที่มันจะตรวจพบคำขอ ซึ่งในกรณีนั้น PDF จะสมบูรณ์

## **หยุดก่อนประมวลผลสไลด์ถัดไป**

ตรวจสอบ [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) ก่อนการส่งออกแต่ละครั้ง [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ยอมรับรายการหมายเลขสไลด์ที่เริ่มจาก 1 เพิ่มหมายเลขลงในรายการที่เสร็จแล้วเฉพาะหลังจาก PDF ของสไลด์นั้นถูกบันทึกสำเร็จ

ใช้ไฟล์ชื่อ `sample.pptx` ที่มีอย่างน้อยสองสไลด์ เพื่อทำให้ผลลัพธ์ทำซ้ำได้ ตัวอย่างขอการยกเลิกทันทีที่สไลด์ 1 เสร็จสมบูรณ์ ในแอปพลิเคชัน คำขออาจมาจากเธรดอื่นในขณะที่สไลด์กำลังถูกบันทึก

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

ตัวอย่างเขียน `slide-1.pdf` และพิมพ์ `Starting slide 1` ตามด้วย `Completed: [1]` การทำซ้ำครั้งต่อไปเห็นคำขอก่อนเริ่มสไลด์ 2 หากการยกเลิกขัดจังหวะการบันทึก ตัวจัดการข้อยกเว้นจะคืนหมายเลขที่บันทึกโดยการทำซ้ำก่อนหน้า ข้อผิดพลาดการส่งออกอื่น ๆ จะถึงผู้เรียก

หากผู้เรียกควรจัดการการยกเลิกเป็นข้อยกเว้น ให้แทนที่การตรวจสอบและ `break` ที่ส่วนบนของลูปด้วย [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). นอกจากนี้ให้ลบ `try`/`except` รอบการบันทึกด้วย ด้วยอินพุตเดียวกัน สไลด์ 1 จะถูกบันทึกและการทำซ้ำครั้งที่สองจะโยงข้อยกเว้นการยกเลิกก่อนเริ่มสไลด์ 2

## **คำถามที่พบบ่อย**

**คำขอยกเลิกจะมีผลเมื่อใด?**

การดำเนินการที่สามารถหยุดได้ตรวจสอบโทเค็นของมันเป็นระยะ ๆ จะหยุดเมื่อพบคำขอ การดำเนินการที่เสร็จแล้วจะเก็บผลลัพธ์ไว้

**แตกต่างระหว่าง source กับ token คืออะไร?**

source ให้แอปพลิเคชันของคุณขอการยกเลิก token ให้ทั้งงานนำเสนอและโค้ดของคุณตรวจสอบคำขอนั้น

**หลายการทำงานสามารถใช้ source เดียวกันได้หรือไม่?**

ได้ การเรียก `interrupt` จะขอการยกเลิกสำหรับทุกการดำเนินการที่ใช้โทเค็นจาก source นั้น ให้แต่ละการดำเนินการมี source ของตนเองหากต้องการยกเลิกแยกกัน