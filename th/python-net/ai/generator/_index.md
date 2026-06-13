---
title: เครื่องสร้างสไลด์หลายภาษาแบบใช้ AI
linktitle: เครื่องสร้างแบบใช้ AI
type: docs
weight: 40
url: /th/python-net/ai/generator/
keywords:
- งานนำเสนอหลายภาษา
- สไลด์หลายภาษา
- เครื่องสร้างงานนำเสนอ AI
- เครื่องสร้างสไลด์ AI
- ฟีเจอร์ที่ขับเคลื่อนด้วย AI
- เอเย่นต์ AI
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "สร้างสไลด์หลายภาษาจากข้อความด้วย Aspose.Slides สำหรับ Python. ใช้เทมเพลตของคุณและส่งออกชุดสไลด์ที่เรียบหรูไปยัง PowerPoint และ OpenDocument. เรียนรู้เพิ่มเติม."
---
## **คำนำ**

Aspose.Slides แนะนำฟีเจอร์ใหม่ที่ขับเคลื่อนด้วย AI ชื่อ Presentation Generator ซึ่งช่วยให้นักพัฒนาสร้างงานนำเสนอ PowerPoint ที่มีโครงสร้างดีอย่างอัตโนมัติจากข้อความง่าย ๆ เช่น คำอธิบายหัวข้อ, สรุป, คำคม, หรือรายการหัวข้อย่อย

ผู้ใช้สามารถปรับระดับความละเอียดของเนื้อหาและเลือกใช้เทมเพลตการนำเสนอแบบกำหนดเองเพื่อกำหนดการออกแบบภาพได้

ในขณะนี้ AI Presentation Generator จัดโครงสร้างเนื้อหาโดยใช้บล็อกข้อความ, รายการหัวข้อย่อย, และตาราง การสร้างภาพยังไม่รองรับ; อย่างไรก็ตามภาพสามารถเพิ่มได้อย่างง่ายดายภายหลังโดยใช้เครื่องมือของ Aspose.Slides หรือเพิ่มด้วยตนเอง

ผลลัพธ์คือไฟล์ PowerPoint ที่สมบูรณ์ซึ่งสามารถใช้ได้ทันทีหรือส่งออกเป็นรูปแบบใดก็ได้ที่รองรับโดย Aspose.Slides API แม้ว่าตัวสร้างจะให้ผลลัพธ์คุณภาพสูง แต่การแก้ไขเล็กน้อยหลังการสร้างอาจจำเป็นเพื่อให้ตรงกับความต้องการเฉพาะ

## **วิธีการทำงาน**

Aspose.Slides ไม่รวมโมเดล AI ในตัว; แทนที่จะเป็นเช่นนั้น มันผสานรวมกับบริการ AI ภายนอกผ่านอินเทอร์เน็ต การผสานนี้จัดการโดยคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/slidesaiagent/) ซึ่งใช้การดำเนินการของคลาส [IAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/iaiwebclient/) เพื่อสื่อสารกับโมเดล AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/openaiwebclient/) ที่มีในตัว ซึ่งเชื่อมต่อกับ API ของ OpenAI, หรือให้การดำเนินการแบบกำหนดเองของ [IAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/iaiwebclient/) เพื่อทำงานกับผู้ให้บริการ AI หรือโมเดลภาษาอื่น ๆ Aspose.Slides จะจัดการการสื่อสารทั้งหมดกับบริการ AI และประมวลผลการตอบกลับของ AI เพื่อสร้างสไลด์ โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องชำระเงิน ดังนั้นจึงต้องมีบัญชีและคีย์ API เมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/openaiwebclient/) ที่มีในตัว

## **มาเขียนโค้ดกัน**

### **ตัวอย่าง 1**

ตัวอย่างนี้แสดงวิธีการสร้างงานนำเสนอในหัวข้อ Aspose.Slides ด้วยการใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/openaiwebclient/) ที่มีในตัว

```py
# สร้างอินสแตนซ์ของ OpenAIWebClient ซึ่งเป็นการนำไปใช้ของไคลเอนท์เว็บ OpenAI ที่มีอยู่แล้ว
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # สร้างอินสแตนซ์ของ SlidesAIAgent ที่ให้การเข้าถึงฟีเจอร์ที่ขับเคลื่อนด้วย AI
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # กำหนดคำสั่งสำหรับการสร้างงานนำเสนอ
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # สร้างงานนำเสนอด้วยปริมาณเนื้อหาปานกลางตามคำสั่ง
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # บันทึกงานนำเสนอที่สร้างไว้ลงดิสก์ในเครื่องเป็นไฟล์ PowerPoint (.pptx)
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **ตัวอย่าง 2**

ตัวอย่างต่อไปนี้แสดงการอัปโหลดของเมธอด [generate_presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation) ในกรณีนี้จะใช้ `master presentation` ของผู้ใช้

```py
# ส่ง HttpClient ไปยังคอนสตรัคเตอร์ของ OpenAIWebClient.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # สร้างอินสแตนซ์ของ SlidesAIAgent.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # กำหนดคำสั่งสำหรับการสร้างงานนำเสนอ.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # โหลดงานนำเสนอหลักจากดิสก์ในเครื่องเพื่อใช้เป็นเทมเพลตการออกแบบ.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # สร้างงานนำเสนออย่างละเอียดโดยใช้คำสั่งและเทมเพลตหลัก.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # บันทึกงานนำเสนอที่สร้างเป็นไฟล์ PDF.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **ประโยชน์หลัก**

AI Presentation Generator ใหม่ใน Aspose.Slides ให้วิธีที่เร็วและยืดหยุ่นในการสร้างชุดสไลด์ที่มีโครงสร้างจากข้อความสั้น ๆ ที่ง่าย ด้วยการรองรับเทมเพลตแบบกำหนดเอง สามารถผสานรวมเข้ากับแอปพลิเคชันหลากหลายได้อย่างไร้รอยต่อ

กรณีการใช้งานทั่วไปรวมถึงการสร้างงานนำเสนอการตลาด, เอกสารการศึกษา, รายงานลูกค้า, และชุดสไลด์ภายใน แม้ว่าการสร้างภาพยังไม่รองรับ เครื่องมือนี้ก็มีพื้นฐานที่แข็งแกร่งสำหรับการอัตโนมัติการสร้างงานนำเสนอ โดยคาดว่าจะมีการพัฒนาเพิ่มเติมในอนาคต