---
title: เครื่องแปลการนำเสนอด้วย AI
linktitle: เครื่องแปลด้วย AI
type: docs
weight: 20
url: /th/python-java/ai/translator/
keywords:
- เครื่องแปลการนำเสนอด้วย AI
- เครื่องแปลสไลด์ด้วย AI
- การนำเสนอหลายภาษา
- การแปลการนำเสนอ
- การแปลสไลด์
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "แปลการนำเสนอด้วย AI โดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java. แปลข้อความสไลด์และบันทึกการนำเสนอที่แปลเป็น PowerPoint หรือ PDF."
---
## **บทนำ**

Aspose.Slides for Python via Java มี API การแปลงานนำเสนอด้วย AI สำหรับการแปลเนื้อหาสไลด์เป็นภาษาต่าง ๆ แปลงานนำเสนอที่มีอยู่เป็นภาษาที่กำหนด จากนั้นบันทึกเวอร์ชันที่แปลแล้วในรูปแบบที่ผู้ชมของคุณต้องการ

## **วิธีการทำงาน**

[SlidesAIAgent](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesaiagent/) สื่อสารกับบริการ AI ภายนอกผ่าน AI client ตัวอย่างใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/python-java/aspose.slides/openaiwebclient/) ที่มีให้ในตัว

[SlidesAIAgent.translate](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesaiagent/#translate) จะอัปเดตงานนำเสนอที่ส่งให้ Aspose.Slides จะประมวลผลการตอบกลับของ AI และแทนที่ข้อความในสไลด์ในขณะเดียวกันคงการจัดวางและรูปแบบเดิมไว้ ตรวจสอบผลลัพธ์: ข้อความที่แปลอาจยาวกว่าต้นฉบับและอาจต้องปรับการจัดวาง

## **ข้อกำหนดล่วงหน้า**

ทำตาม [การติดตั้ง](/slides/th/python-java/installation/) เพื่อกำหนดค่าห้องสมุดและสภาพแวดล้อม ตั้งค่าตัวแปรสภาพแวดล้อม `OPENAI_API_KEY` และ `OPENAI_MODEL` ก่อนเรียกใช้ตัวอย่าง เลือกรุ่นที่รองรับโดย client ในตัวและที่บัญชี API ของคุณใช้งานได้

{{% alert color="info" title="หมายเหตุ" %}}
การแปลต้องใช้การเชื่อมต่ออินเทอร์เน็ตและจะส่งข้อความงานนำเสนอไปยังบริการ AI ที่กำหนด การเข้าถึง API และค่าใช้จ่ายการใช้งานเป็นเรื่องแยกจากใบอนุญาต Aspose.Slides ของคุณ
{{% /alert %}}

ตัวอย่างจะใช้ JVM ที่กำลังทำงานอยู่หรือจะเริ่มใหม่หากจำเป็น ดูที่ [JVM lifecycle guidance](/slides/th/python-java/limitations-and-api-differences/#import-the-library) สำหรับการใช้งานใน notebook

## **แปลงานนำเสนอ**

วางไฟล์ `sample.pptx` ในไดเรกทอรีทำงาน ตัวอย่างนี้โหลดไฟล์ด้วย [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/), แปลข้อความเป็นภาษาญี่ปุ่นและบันทึกผลเป็น PDF แม้การดำเนินการใดล้มเหลวก็จะปล่อยงานนำเสนอและปิด AI client อย่างปลอดภัย

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **กำหนดการเชื่อมต่อ HTTP**

ตามค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/python-java/aspose.slides/openaiwebclient/) จัดการการเชื่อมต่อ HTTP ภายในเอง ตัวสร้างสี่อาร์กิวเมนต์ยังรับ `HttpURLConnection` ของ Java ที่จัดการโดยภายนอกได้ ใช้การโอเวอร์โหลดนี้เมื่อคุณต้องกำหนดพร็อกซีหรือตั้งค่าการหมดเวลาเชื่อมต่อ

ตัวอย่างต่อไปนี้สร้างพร็อกซี HTTP ของ Java ด้วย [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) และเปิดการเชื่อมต่อผ่าน [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)) แทนที่ `proxy.example.com` และพอร์ตด้วยค่าพร็อกซีของคุณ การเชื่อมต่อจะถูกส่งต่อโดยตรงผ่าน JPype; ไม่สามารถใช้เซสชัน HTTP ของ Python แทนที่ได้

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **ประโยชน์หลัก**

การแปลอัตโนมัติช่วยเตรียมวัสดุการฝึกอบรมหลายภาษา, งานนำเสนอผลิตภัณฑ์, และรายงานลูกค้าในขณะเดียวกันใช้การออกแบบสไลด์เดิมได้บันทึกงานนำเสนอที่แก้ไขได้สำหรับการทบทวนต่อไปหรือส่งออกเป็น PDF เพื่อแจกจ่าย

## **คำถามที่พบบ่อย**

**การแปลสร้างออบเจ็กต์งานนำเสนอแยกต่างหากหรือไม่?**

ไม่. [SlidesAIAgent.translate](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesaiagent/#translate) จะปรับเปลี่ยนงานนำเสนอที่ส่งเข้าไป ให้บันทึกเป็นชื่อไฟล์ใหม่เพื่อเก็บไฟล์ต้นฉบับไว้ไม่เปลี่ยนแปลง

**ฉันระบุภาษาปลายทางอย่างไร?**

ส่งชื่อภาษา เช่น `"Japanese"` หรือ `"Spanish"` เป็นอาร์กิวเมนต์ที่สอง คุณภาพการแปลและการรองรับภาษาขึ้นอยู่กับรุ่นที่เลือก

**ฉันสามารถแปลโดยไม่ใช้พร็อกซีได้หรือไม่?**

ได้. ใช้ตัวสร้าง client สามอาร์กิวเมนต์ที่แสดงในตัวอย่างแรก ตัวอย่างการเชื่อมต่อแบบกำหนดเองจำเป็นเฉพาะเมื่อแอปพลิเคชันของคุณต้องการตั้งค่าการเชื่อมต่อโดยเจาะจง