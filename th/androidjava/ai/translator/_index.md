---
title: ตัวแปลการนำเสนอด้วย AI
linktitle: ตัวแปลด้วย AI
type: docs
weight: 20
url: /th/androidjava/ai/translator/
keywords:
- ตัวแปลการนำเสนอด้วย AI
- ตัวแปลสไลด์ด้วย AI
- ฟีเจอร์ขับเคลื่อนด้วย AI
- การนำเสนอหลายภาษา
- สไลด์หลายภาษา
- การแปลการนำเสนอ
- การแปลสไลด์
- ฟีเจอร์ที่ขับเคลื่อนด้วย AI
- ความสามารถของ AI
- ตัวแทน AI
- ไคลเอนต์เว็บ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นโดยคงรูปแบบเดิม—เร็วและเป็นมิตรต่อผู้พัฒนา. ลองใช้งาน."
---
## **บทนำ**

Aspose.Slides เป็น API ที่ทรงพลังสำหรับการจัดการการนำเสนอ PowerPoint อย่างโปรแกรมมิ่ง นอกจากนี้ยังสามารถสร้าง แก้ไข และแปลงสไลด์ได้ อีกทั้งยังมีคุณสมบัติขับเคลื่อนด้วย AI เช่น Presentation Translation API สำหรับเนื้อหาสไลด์หลายภาษา.

## **วิธีการทำงาน**

Aspose.Slides ไม่มีความสามารถ AI ที่มาพร้อมในตัว แต่รวมเข้ากับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ฟังก์ชันนี้เปิดให้เข้าถึงผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidesaiagent/) ซึ่งใช้การใช้งานของอินเทอร์เฟซ [IAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaiwebclient/) เพื่อสื่อสารกับบริการ AI.

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/) ที่มีในตัวเพื่อเชื่อมต่อกับ API ของ OpenAI หรือทำการติดตั้ง [IAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaiwebclient/) ของคุณเองเพื่อใช้ผู้ให้บริการ AI หรือโมเดลภาษาที่แตกต่างกัน.

Aspose.Slides จัดการการสื่อสาร แยกวิเคราะห์คำตอบจาก AI และแทรกเนื้อหาที่แปลอย่างชาญฉลาดโดยคงรูปแบบและการจัดวางสไลด์เดิมไว้.

{{% alert color="primary" %}}
โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องชำระเงิน ดังนั้นคุณจะต้องสร้างบัญชีและระบุคีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/) ที่มีในตัว.
{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราแปลการนำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/) ที่มีในตัวพร้อมกับกำหนด [model](https://platform.openai.com/docs/models) ของ OpenAI ที่ต้องการ.

```java
// โหลดการนำเสนอเพื่อแปล.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // เริ่มต้น SlidesAIAgent ด้วยไคลเอนต์ AI.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // แปลการนำเสนอเป็นภาษาญี่ปุ่น.
    aiAgent.translate(presentation, "japanese");

    // บันทึกการนำเสนอที่แปลเป็น PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/) ที่มีในตัวจะสร้างและจัดการอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ภายในของมันเองโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ด้วยตนเอง — เพื่อกำหนดค่าที่จำเป็นเช่นพร็อกซี่ หรือใช้ [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) หรือ [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) ที่แตกต่างเพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดียิ่งขึ้น — คุณสามารถให้อินสแตนซ์ `HttpURLConnection` ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/).

```java
// สมมติว่าคุณมีอินสแตนซ์ HttpURLConnection ที่กำหนดค่าล่วงหน้า (เช่น มีการตั้งค่า timeout แบบกำหนดเอง, การตั้งค่าพร็อกซี่ ฯลฯ)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **ประโยชน์หลัก**

Aspose.Slides Presentation Translation API มอบโซลูชันที่ขับเคลื่อนด้วย AI สำหรับการส่งมอบการนำเสนอ PowerPoint หลายภาษา โดยอัตโนมัติการแปลพร้อมคงการจัดวางและการออกแบบไว้ ทำให้ประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำงานแบบมือ เมื่อคุณเป็นนักพัฒนา ผู้สอน หรือผู้เชี่ยวชาญด้านธุรกิจ API นี้ทำให้คุณสร้างการนำเสนอที่ดึงดูดและปรับให้เข้ากับท้องถิ่นสำหรับผู้ชมทั่วโลก — ขยายการเข้าถึงและพัฒนาการสื่อสาร.