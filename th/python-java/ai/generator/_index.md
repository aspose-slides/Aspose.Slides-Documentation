---
title: ตัวสร้างสไลด์หลายภาษาแบบขับเคลื่อนด้วย AI
linktitle: ตัวสร้างแบบขับเคลื่อนด้วย AI
type: docs
weight: 40
url: /th/python-java/ai/generator/
keywords:
- การนำเสนอหลายภาษา
- สไลด์หลายภาษา
- ตัวสร้างการนำเสนอ AI
- ตัวสร้างสไลด์ AI
- แม่แบบการนำเสนอ
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "สร้างการนำเสนอหลายภาษาจากข้อความด้วย Aspose.Slides สำหรับ Python ผ่าน Java. เลือกรายละเอียดเนื้อหา, ใช้แม่แบบ, และส่งออกเป็น PowerPoint หรือ PDF."
---
## **บทนำ**

AI Presentation Generator ใน Aspose.Slides สำหรับ Python ผ่าน Java สร้างงานนำเสนอจากคำอธิบายหัวข้อ, สรุป, คำคัตตอน หรือรายการหัวข้อย่อย ระบุภาษาที่ต้องการในพรอมต์ของคุณ, เลือกปริมาณเนื้อหา, และในกรณีที่ต้องการสามารถระบุแม่แบบงานนำเสนอเพื่อกำหนดเค้าโครงและการออกแบบได้

ตัวสร้างจัดโครงสร้างเนื้อหาโดยใช้บล็อกข้อความ, รายการหัวข้อย่อย, และตาราง ไม่สร้างรูปภาพ; คุณสามารถเพิ่มรูปภาพในงานนำเสนอที่สร้างขึ้นภายหลัง ตรวจสอบเนื้อหาและเค้าโครงที่สร้างขึ้นก่อนแชร์งานนำเสนอ

## **วิธีการทำงาน**

[SlidesAIAgent](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesaiagent/) ใช้ไคลเอนต์ AI เพื่อติดต่อกับโมเดลภายนอก ตัวอย่างด้านล่างใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/python-java/aspose.slides/openaiwebclient/) ที่สร้างมาในตัว Aspose.Slides ประมวลผลการตอบของโมเดลและสร้างงานนำเสนอที่คุณสามารถแก้ไขหรือส่งออกได้

ใช้ [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesaiagent/#generatePresentation) พร้อมคำอธิบายข้อความและค่า [PresentationContentAmountType](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationcontentamounttype/) overload ที่มีอาร์กิวเมนต์ที่สามยอมรับงานนำเสนอเพื่อใช้เป็นแม่แบบการออกแบบ

## **ข้อกำหนดเบื้องต้น**

ทำตาม [Installation](/slides/th/python-java/installation/) เพื่อกำหนดค่าของ Python, Java, JPype, และ Aspose.Slides ตั้งตัวแปรสภาพแวดล้อม `OPENAI_API_KEY` และ `OPENAI_MODEL` ก่อนรันตัวอย่าง เลือกโมเดลที่รองรับโดยไคลเอนต์ที่สร้างมาในตัวและพร้อมใช้งานกับบัญชี API ของคุณ

{{% alert color="info" title="Note" %}}
บริการ AI ต้องการการเชื่อมต่ออินเทอร์เน็ตและการเข้าถึง API แยกต่างหาก พรอมต์จะถูกส่งไปยังบริการที่กำหนดค่าและค่าใช้จ่ายการใช้งานจะคิดแยกจากใบอนุญาต Aspose.Slides ของคุณ.
{{% /alert %}}

แต่ละตัวอย่างจะเริ่ม JVM ก็ต่อเมื่อยังไม่ได้รันและปล่อยให้ใช้งานได้ต่อสำหรับการดำเนินการต่อไป ดู [JVM lifecycle guidance](/slides/th/python-java/limitations-and-api-differences/#import-the-library) เมื่อต้องปรับโค้ดสำหรับโน้ตบุ๊ก.

## **สร้างงานนำเสนอจากข้อความ**

ตัวอย่างนี้สร้างงานนำเสนอภาษาอังกฤษโดยมีปริมาณเนื้อหาแบบ [Medium](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationcontentamounttype/#Medium) และบันทึกเป็นไฟล์ PowerPoint.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **สร้างงานนำเสนอโดยใช้แม่แบบ**

วางไฟล์ `masterPresentation.pptx` ไว้ในไดเรกทอรีทำงาน ตัวอย่างนี้โหลดไฟล์ดังกล่าวด้วย [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/), สร้างงานนำเสนอภาษา Spanish ด้วยเนื้อหาแบบ [Detailed](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationcontentamounttype/#Detailed) และส่งออกเป็น PDF ทั้งแม่แบบและงานนำเสนอที่สร้างจะถูกปล่อยออก แม้กระทั่งหากการสร้างหรือการบันทึกล้มเหลว.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

หากต้องการกำหนดค่าพร็อกซีหรือเวลาหมดของการเชื่อมต่อ ดู [Configure the HTTP Connection](/slides/th/python-java/ai/translator/#configure-the-http-connection) คุณสามารถส่งผ่านไคลเอนต์ที่ได้ให้กับตัวสร้างได้เช่นกัน.

## **ประโยชน์สำคัญ**

การสร้างสามารถลดงานร่างเบื้องต้นสำหรับเอกสารการฝึกอบรม, ภาพรวมของผลิตภัณฑ์, รายงานลูกค้า, และงานนำเสนอภายในได้ พรอมต์ควบคุมหัวข้อและภาษา ส่วนแม่แบบช่วยให้คุณนำการออกแบบงานนำเสนอที่มีอยู่แล้วกลับมาใช้ใหม่ได้.

## **คำถามที่พบบ่อย**

**ฉันจะควบคุมความยาวของงานนำเสนอที่สร้างอย่างไร?**

เลือก [Brief](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationcontentamounttype/#Medium), หรือ [Detailed](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationcontentamounttype/#Detailed) การตั้งค่าเหล่านี้ส่งผลต่อจำนวนสไลด์และรายละเอียดในแต่ละสไลด์; ไม่ได้กำหนดจำนวนสไลด์ที่แน่นอน.

**ฉันสามารถสร้างสไลด์ในภาษาอื่นได้หรือไม่?**

ได้. ระบุภาษาที่ต้องการในคำอธิบายข้อความ ผลลัพธ์จะขึ้นอยู่กับความสามารถด้านภาษาของโมเดลที่เลือก.

**ฉันสามารถรักษาเวอร์ชันที่แก้ไขได้เมื่อส่งออกเป็น PDF หรือไม่?**

ได้. ก่อนทำลายงานนำเสนอที่สร้าง, ให้บันทึกเป็น PPTX ด้วยวิธีที่ใช้ในตัวอย่างแรก.