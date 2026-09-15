---
title: ตัวแปลงานนำเสนอที่ขับเคลื่อนด้วย AI
linktitle: ตัวแปลที่ขับเคลื่อนด้วย AI
type: docs
weight: 20
url: /th/python-net/ai/translator/
keywords:
- ตัวแปลงานนำเสนอ AI
- ตัวแปลสไลด์ AI
- ฟีเจอร์ที่ขับเคลื่อนด้วย AI
- งานนำเสนอหลายภาษา
- สไลด์หลายภาษา
- การแปลงานนำเสนอ
- การแปลสไลด์
- ฟีเจอร์ที่ขับเคลื่อนด้วย AI
- ศักยภาพ AI
- เอเจนต์ AI
- ไคลเอนต์เว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ Python. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นโดยคงเค้าโครงไว้—รวดเร็วและเป็นมิตรต่อผู้พัฒนา. ทดลองใช้งาน."
---
## **บทนำ**

Aspose.Slides คือ API ที่ทรงพลังสำหรับการจัดการงานนำเสนอ PowerPoint อย่างอัตโนมัติ นอกจากการสร้าง แก้ไข และแปลงสไลด์แล้ว ยังมีฟีเจอร์ที่ขับเคลื่อนด้วย AI เช่น [Presentation Translation API](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/) สำหรับเนื้อหาสไลด์หลายภาษา

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้รวมความสามารถ AI ในตัว แต่จะทำการเชื่อมต่อกับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ฟังก์ชันนี้เปิดให้ใช้ผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/slidesaiagent/) ซึ่งใช้คลาสย่อยของ [IAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/iaiwebclient/) เพื่อสื่อสารกับบริการ AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/openaiwebclient/) ที่มาพร้อมในตัวเพื่อเชื่อมต่อกับ API ของ OpenAI หรือทำการเขียน [IAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/iaiwebclient/) ของคุณเองเพื่อใช้ผู้ให้บริการ AI หรือโมเดลภาษาที่แตกต่างกัน

Aspose.Slides จัดการการสื่อสาร วิเคราะห์การตอบกลับจาก AI และแทรกเนื้อหาที่แปลอย่างชาญฉลาดโดยคงไว้ซึ่งเค้าโครงและรูปแบบของสไลด์เดิม

{{% alert color="info" %}}

โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องชำระเงิน ดังนั้นคุณจะต้องสร้างบัญชีและระบุคีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/openaiwebclient/)

{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราแปลงานนำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/openaiwebclient/) ที่มาพร้อมในตัวพร้อมกับโมเดล OpenAI ที่ระบุ

```py
import aspose.slides as slides

# โหลดงานนำเสนอเพื่อแปล.
with slides.Presentation("sample.pptx") as presentation:

    # สร้างไคลเอนต์ AI ด้วย OpenAIWebClient โดยระบุโมเดลและคีย์ API ของคุณ.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # เริ่มต้น SlidesAIAgent ด้วยไคลเอนต์ AI.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # แปลงานนำเสนอเป็นภาษาญี่ปุ่น.
        ai_agent.translate(presentation, "japanese")

        # บันทึกงานนำเสนอที่แปลเป็นไฟล์ PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Azure OpenAI Example**

ตั้งแต่เวอร์ชัน **26.7.0** Aspose.Slides สำหรับ Python ผ่าน .NET รองรับผู้ให้บริการที่เข้ากันได้กับ OpenAI รวมถึง Azure OpenAI คุณสามารถกำหนดค่าตัวแปลเพื่อใช้การปรับใช้ Azure ของคุณเองด้วย [OpenAICompatibleWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/openaicompatiblewebclient/)

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

โค้ดส่วนนี้แสดงวิธีการแปลงานนำเสนอโดยใช้ Azure OpenAI endpoint ของคุณ ให้แทนค่าตัวแปรที่เป็นตำแหน่งจัดเก็บด้วยชื่อการปรับใช้ คีย์ API และ URL ของ endpoint ของคุณ

## **ประโยชน์สำคัญ**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/) ให้โซลูชันที่ใช้ AI สำหรับการนำเสนอ PowerPoint หลายภาษา โดยอัตโนมัติการแปลพร้อมคงเค้าโครงและการออกแบบ ช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับการทำมือ ไม่ว่าคุณจะเป็นนักพัฒนา ผู้สอน หรือผู้เชี่ยวชาญด้านธุรกิจ API นี้ช่วยให้คุณสร้างงานนำเสนอที่น่าสนใจและท้องถิ่นสำหรับผู้ชมทั่วโลก — ขยายขอบเขตการเข้าถึงและปรับปรุงการสื่อสาร.