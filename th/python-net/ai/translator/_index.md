---
title: เครื่องแปลการนำเสนอด้วย AI
linktitle: ตัวแปลด้วย AI
type: docs
weight: 20
url: /th/python-net/ai/translator/
keywords:
- เครื่องแปลการนำเสนอด้วย AI
- เครื่องแปลสไลด์ด้วย AI
- คุณลักษณะขับเคลื่อนด้วย AI
- การนำเสนอบหลายภาษา
- สไลด์หลายภาษา
- การแปลการนำเสนอ
- การแปลสไลด์
- คุณลักษณะขับเคลื่อนด้วย AI
- ความสามารถของ AI
- เอเจนต์ AI
- ไคลเอนต์เว็บ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ Python. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นโดยคงการจัดวางไว้ — รวดเร็วและเป็นมิตรต่อผู้พัฒนา. ลองใช้เลย."
---
## **บทนำ**

Aspose.Slides เป็น API ที่ทรงพลังสำหรับการจัดการการนำเสนอ PowerPoint อย่างโปรแกรมมิ่ง นอกจากการสร้าง, แก้ไข, และแปลงสไลด์แล้ว ยังมีคุณลักษณะขับเคลื่อนด้วย AI เช่น [Presentation Translation API](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/) สำหรับเนื้อหาสไลด์หลายภาษา.

## **วิธีทำงาน**

Aspose.Slides ไม่ได้รวมความสามารถ AI ในตัว แต่ผสานกับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ฟังก์ชันนี้เปิดให้ใช้งานผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/slidesaiagent/) ซึ่งใช้ซับคลาสของ [IAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/iaiwebclient/) เพื่อสื่อสารกับบริการ AI.

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/openaiwebclient/) ที่มีมาในตัวเพื่อเชื่อมต่อกับ API ของ OpenAI หรือสร้างการใช้งานของคุณเองของ [IAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/iaiwebclient/) เพื่อใช้ผู้ให้บริการ AI หรือโมเดลภาษาที่แตกต่าง

Aspose.Slides จัดการการสื่อสาร, วิเคราะห์การตอบกลับจาก AI, และแทรกเนื้อหาที่แปลอย่างฉลาดโดยคงรูปแบบและการจัดวางสไลด์ต้นฉบับไว้

{{% alert color="primary" %}}
โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องชำระเงิน ดังนั้นคุณจะต้องสร้างบัญชีและให้คีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/openaiwebclient/) ที่มีมาในตัว
{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราแปลการนำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/openaiwebclient/) ที่มีมาในตัวพร้อมโมเดล OpenAI ที่กำหนด

```py
# โหลดการนำเสนอเพื่อแปล.
with slides.Presentation("sample.pptx") as presentation:

    # สร้างไคลเอนต์ AI ด้วย OpenAIWebClient โดยระบุโมเดลและคีย์ API ของคุณ.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # เริ่มต้น SlidesAIAgent ด้วยไคลเอนต์ AI.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # แปลการนำเสนอเป็นภาษาญี่ปุ่น.
        ai_agent.translate(presentation, "japanese")

        # บันทึกการนำเสนอที่แปลเป็นไฟล์ PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

## **ประโยชน์หลัก**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/th/python-net/aspose.slides.ai/) มีโซลูชันขับเคลื่อนด้วย AI สำหรับการจัดทำการนำเสนอ PowerPoint หลายภาษา โดยการทำการแปลโดยอัตโนมัติพร้อมคงรูปแบบและการออกแบบไว้ ช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำด้วยมือ ไม่ว่าคุณจะเป็นนักพัฒนา, นักการศึกษา, หรือมืออาชีพด้านธุรกิจ API นี้ทำให้คุณสามารถสร้างการนำเสนอที่มีความดึงดูดและท้องถิ่นสำหรับผู้ชมทั่วโลก — ขยายการเข้าถึงและปรับปรุงการสื่อสาร.