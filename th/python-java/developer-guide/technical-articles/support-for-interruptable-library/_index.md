---
title: ขัดจังหวะการทำงานของพรีเซนเทชันที่ใช้เวลานานใน Python
linktitle: ขัดจังหวะการทำงานของพรีเซนเทชัน
type: docs
weight: 120
url: /th/python-java/support-for-interruptable-library/
keywords:
- การดำเนินการที่สามารถขัดจังหวะได้
- โทเคนการขัดจังหวะ
- โทเคนการยกเลิก
- งานที่ใช้เวลานาน
- ขัดจังหวะงาน
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธียกเลิกการทำงานของพรีเซนเทชันที่ใช้เวลานานใน Aspose.Slides for Python via Java และคืนผลลัพธ์บางส่วนเมื่อส่งออกสไลด์ในลูป."
---
## **ภาพรวม**

Aspose.Slides for Python via Java สามารถขัดจังหวะการทำงานที่ใช้เวลานาน เช่น การโหลด การบันทึก และการเรนเดอร์พรีเซนเทชัน แอปพลิเคชันของคุณสามารถใช้ token การขัดจังหวะเดียวกันเพื่อหยุดลูปก่อนที่จะเริ่มประมวลผลสไลด์ถัดไป

## **ขัดจังหวะการทำงานของพรีเซนเทชัน**

สร้าง [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), รับ token ของมันด้วย [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken), แล้วส่ง token ให้กับ [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). ส่ง load options ไปยัง [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). เพื่อขอการยกเลิก ให้เรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) บน source การทำงานที่สามารถขัดจังหวะได้จะหยุดเมื่อพบคำขอ ใช้ `jpype.JClass` เพื่อตรวจจับข้อยกเว้น Java `com.aspose.slides.exceptions.OperationCanceledException` ใน Python.

ตัวอย่างจะแปลง `sample.pptx` เป็น `sample.ppt` บนเธรดพื้นหลัง เธรดที่เรียกจะรอสูงสุด 10 วินาทีเพื่อให้การแปลงเสร็จสิ้น หากการแปลงยังทำงานอยู่ จะขอการยกเลิกและรอให้ worker สิ้นสุด

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **เชื่อมต่อการหมดเวลาของ Python กับ Aspose.Slides**

เพื่อกำหนดเวลาจำกัดสำหรับการทำงานของพรีเซนเทชัน ให้ใช้ [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) เพื่อเรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) เมื่อเวลาหมด ตัวอย่างกำหนดเวลา 20 วินาทีเพื่อโหลด `sample.pptx` และส่งออกเป็น `sample.pdf` หากการส่งออกเสร็จเร็วก่อน แอปพลิเคชันจะยกเลิกคำขอที่กำหนดไว้

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **หยุดก่อนประมวลผลสไลด์ถัดไป**

ใช้ [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) เดียวกันสำหรับพรีเซนเทชันและลูปที่ส่งออกสไลด์ของมัน ตรวจสอบ [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) ก่อนการส่งออกแต่ละครั้ง หากผู้เรียกสามารถใช้ผลลัพธ์บางส่วนได้ ให้คืนหมายเลขสไลด์สำหรับการส่งออกที่สำเร็จเรียบร้อย

ใช้พรีเซนเทชันชื่อ `sample.pptx` ที่มีอย่างน้อยสองสไลด์ [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) overload ที่รับ Java `int[]` ใช้หมายเลขสไลด์เริ่มต้นที่ 1 ใช้ `jpype.JArray(jpype.JInt)` เพื่อสร้างอาร์เรย์นั้นใน Python ตัวอย่างบันทึกแต่ละสไลด์เป็น PDF แยกไฟล์และขอการยกเลิกทันทีหลังจากบันทึกการส่งออกแรกที่สำเร็จ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

ตัวอย่างเขียน `slide-1.pdf` และพิมพ์ `Starting slide 1` ตามด้วย `Completed: [1]` ลูปสังเกตคำขอก่อนเริ่มสไลด์ 2 หากการยกเลิกเกิดขึ้นระหว่างการบันทึก ลูปจะออกก่อนบันทึกสไลด์นั้นเป็นสำเร็จ

หากผู้เรียกต้องการจัดการการยกเลิก ให้แทนที่การตรวจสอบและ `break` ที่ส่วนบนของลูปด้วย `token.throwIfInterruptionRequested()` ลบ `try`/`except` รอบการบันทึกเพื่อให้การยกเลิกระหว่างการส่งออกถึงผู้เรียกด้วย ตัวอย่างเดียวกันจะพิมพ์เฉพาะ `Starting slide 1` และเขียน `slide-1.pdf` ที่จุดเริ่มต้นของการทำซ้ำครั้งที่สอง [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) จะโยน `com.aspose.slides.exceptions.OperationCanceledException` ก่อนการส่งออกถัดไปเริ่มต้น ข้อยกเว้นจะส่งต่อไปยังผู้เรียกก่อนฟังก์ชันจะคืนค่ารายการ

## **คำถามที่พบบ่อย**

**เมื่อใดควรขอยกเลิก?**

ให้ขอยกเลิกเมื่อการทำงานเกินเวลาที่กำหนดหรือเมื่อแอปพลิเคชันของคุณไม่ต้องการผลลัพธ์อีกต่อไป

**ความแตกต่างระหว่าง [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) กับ [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Source จะทำให้แอปพลิเคชันของคุณขอยกเลิก Token จะทำให้ Aspose.Slides และแอปพลิเคชันของคุณตรวจสอบคำขอเหล่านั้น

**ฉันสามารถยกเลิกการทำงานจากตัวจับเวลา Python ได้หรือไม่?**

ได้. กำหนดให้เรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) บน source ที่เชื่อมกับพรีเซนเทชัน

**ฉันสามารถขัดจังหวะการทำงานใดได้บ้าง?**

คุณสามารถขัดจังหวะการโหลด การบันทึก และการเรนเดอร์ได้ ส่ง token ให้กับ [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ผ่าน [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) พรีเซนเทชันจะสังเกตการยกเลิกในขั้นตอนต่อไป เช่น การบันทึกเป็น PDF

**การทำงานหยุดทันทีหรือไม่?**

การยกเลิกเป็นการทำงานร่วมกัน การทำงานจะตรวจสอบ token เป็นระยะและหยุดเมื่อพบคำขอ

**เกิดอะไรขึ้นหากฉันเรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) หลังจากการทำงานเสร็จแล้ว?**

การทำงานที่เสร็จสิ้นจะคงผลลัพธ์ไว้

**หลายการทำงานสามารถใช้ [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) ร่วมกันได้หรือไม่?**

ได้. การเรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) จะขอยกเลิกสำหรับทุกการทำงานที่ใช้ token จาก source นั้น ใช้ source แยกสำหรับแต่ละการทำงานที่ต้องการยกเลิกอย่างอิสระ