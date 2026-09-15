---
title: การสนับสนุนไลบรารีที่หยุดได้
type: docs
weight: 120
url: /th/python-java/support-for-interruptable-library/
keywords:
- ไลบรารีที่หยุดได้
- โทเคนการขัดขวาง
- โทเคนการยกเลิก
- งานที่ใช้เวลานาน
- งานขัดขวาง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ทำให้งานที่ใช้เวลานานสามารถยกเลิกได้ด้วย Aspose.Slides สำหรับ Python ผ่าน Java. ขัดขวางการเรนเดอร์และการแปลงสำหรับ PowerPoint และ OpenDocument อย่างปลอดภัย พร้อมตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides มีกลไกการประมวลผลที่สามารถขัดขวางได้สำหรับงานพรีเซนเทชั่นที่ใช้เวลานาน เช่น การแปลงข้อมูล, การจัดลำดับข้อมูล, และการเรนเดอร์ กลไกนี้อิงจากคลาส [InterruptionToken](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontoken/) และ [InterruptionTokenSource](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontokensource/)  

[InterruptionToken](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontoken/) สามารถกำหนดให้กับ [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/) และส่งต่อไปยังคอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เมื่อเรียกใช้ [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontokensource/#interrupt) งานที่ใช้เวลานานที่เกี่ยวข้องจะถูกขัดขวาง

## **ไลบรารีที่หยุดได้**

Aspose.Slides for Python via Java มีคลาส [InterruptionToken](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontoken/) และ [InterruptionTokenSource](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontokensource/) ซึ่งช่วยให้คุณสามารถขัดขวางงานที่ใช้เวลานาน เช่น การแปลงข้อมูล, การจัดลำดับข้อมูล, และการเรนเดอร์ได้  

- [InterruptionTokenSource](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontokensource/) คือแหล่งที่มาของโทเคนที่ส่งต่อให้กับ [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setInterruptionToken)  
- เมื่อเรียกใช้ [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setInterruptionToken) และอินสแตนซ์ของ [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/) ถูกส่งต่อไปยังคอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) การเรียกใช้ [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontokensource/#interrupt) จะขัดขวางงานใด ๆ ที่ใช้เวลานานและเชื่อมโยงกับ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) นั้น  

โค้ดตัวอย่างต่อไปนี้แสดงการขัดขวางงานที่กำลังทำงาน:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # ดำเนินการในเธรดแยก
    time.sleep(10)  # หมดเวลา.
    token_source.interrupt()  # หยุดการแปลง.
    conversion_task.result()
```

## **คำถามที่พบบ่อย**

**จุดประสงค์ของไลบรารีขัดขวางของ Aspose.Slides คืออะไร?**  

มันให้กลไกเพื่อขัดขวางการดำเนินการที่ใช้เวลานาน — เช่น การโหลด, การบันทึก, หรือการเรนเดอร์พรีเซนเทชั่น — ก่อนที่การดำเนินการจะเสร็จสมบูรณ์ ซึ่งมีประโยชน์เมื่อเวลาการประมวลผลต้องจำกัดหรือไม่ต้องการงานนั้นอีกต่อไป  

**ความแตกต่างระหว่าง [InterruptionToken](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontoken/) กับ [InterruptionTokenSource](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontokensource/) คืออะไร?**  

- [InterruptionToken](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontoken/) ถูกส่งต่อไปยัง API ของ Aspose.Slides และจะถูกตรวจสอบระหว่างการดำเนินการที่ใช้เวลานาน  
- [InterruptionTokenSource](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontokensource/) ใช้ในโค้ดของคุณเพื่อสร้างโทเคนและกระตุ้นการขัดขวางโดยการเรียก [interrupt](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontokensource/#interrupt)  

**งานใดบ้างที่สามารถขัดขวางได้?**  

งาน Aspose.Slides ใด ๆ ที่รับ [InterruptionToken](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontoken/) — เช่น การโหลดพรีเซนเทชั่นด้วย [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) หรือการบันทึกด้วย [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) — สามารถขัดขวางได้  

**การขัดขวางเกิดขึ้นทันทีหรือไม่?**  

ไม่ การขัดขวางทำงานแบบร่วมมือ: การดำเนินการจะตรวจสอบโทเคนเป็นระยะและจะหยุดเมื่อพบว่าได้เรียก [interrupt](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontokensource/#interrupt) แล้ว  

**จะเกิดอะไรขึ้นหากเรียก [interrupt](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontokensource/#interrupt) หลังจากงานเสร็จแล้ว?**  

ไม่มีผล — การเรียกนี้จะไม่มีผลต่องานที่เสร็จแล้ว  

**สามารถใช้ [InterruptionTokenSource](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontokensource/) เดียวกันสำหรับหลายงานได้หรือไม่?**  

ทำได้ — แต่หลังจากคุณเรียก [interrupt](https://reference.aspose.com/slides/th/python-java/aspose.slides/interruptiontokensource/#interrupt) บนแหล่งนั้น งานทั้งหมดที่ใช้โทเคนจากแหล่งนั้นจะถูกขัดขวาง ใช้แหล่งโทเคนแยกกันเพื่อจัดการงานแต่ละงานอย่างอิสระ  