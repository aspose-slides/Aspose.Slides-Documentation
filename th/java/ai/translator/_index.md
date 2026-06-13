---
title: ตัวแปลงานนำเสนอด้วย AI
linktitle: ตัวแปลด้วย AI
type: docs
weight: 20
url: /th/java/ai/translator/
keywords:
- ตัวแปลงานนำเสนอด้วย AI
- ตัวแปลสไลด์ด้วย AI
- คุณลักษณะขับเคลื่อนด้วย AI
- งานนำเสนอหลายภาษา
- สไลด์หลายภาษา
- การแปลงานนำเสนอ
- การแปลสไลด์
- ฟีเจอร์ที่ขับเคลื่อนด้วย AI
- ความสามารถของ AI
- ตัวแทน AI
- ไคลเอนต์เว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ Java. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นพร้อมคงรูปแบบ—เร็วและเป็นมิตรต่อผู้พัฒนา. ลองใช้ดู."
---
## **บทนำ**

Aspose.Slides เป็น API ที่มีประสิทธิภาพสำหรับการจัดการงานนำเสนอ PowerPoint อย่างอัตโนมัติ นอกจากการสร้าง แก้ไข และแปลงสไลด์แล้ว ยังมีฟีเจอร์ที่ขับเคลื่อนด้วย AI เช่น Presentation Translation API สำหรับเนื้อหาสไลด์หลายภาษา

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้มี AI ในตัว แต่ผสานกับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ความสามารถนี้ถูกเปิดเผยผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesaiagent/) ซึ่งใช้การทำงานของอินเทอร์เฟซ [IAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaiwebclient/) เพื่อสื่อสารกับบริการ AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) ในตัวเพื่อเชื่อมต่อกับ API ของ OpenAI หรือทำการ implement [IAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaiwebclient/) ของคุณเองเพื่อใช้ผู้ให้บริการ AI หรือโมเดลภาษาที่แตกต่าง

Aspose.Slides จัดการการสื่อสาร แยกวิเคราะห์การตอบกลับจาก AI และแทรกเนื้อหาที่แปลอย่างอัจฉริยะโดยคงรูปแบบและการจัดวางสไลด์เดิม

{{% alert color="primary" %}}
โปรดทราบว่า API ของ OpenAI เป็นบริการแบบชำระเงิน ดังนั้นคุณจะต้องสร้างบัญชีและระบุคีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) ในตัว
{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราจะแปลงานนำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) พร้อมระบุโมเดลของ OpenAI [model](https://platform.openai.com/docs/models)

```java
// โหลดงานนำเสนอเพื่อแปล.
Presentation presentation = new Presentation("sample.pptx");

// สร้างไคลเอนต์ AI ด้วย OpenAIWebClient ระบุโมเดลและคีย์ API ของคุณ.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // เริ่มต้น SlidesAIAgent ด้วยไคลเอนต์ AI.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // แปลงานนำเสนอเป็นภาษาญี่ปุ่น.
    aiAgent.translate(presentation, "japanese");

    // บันทึกงานนำเสนอที่แปลเป็น PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) จะสร้างและจัดการอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ภายในของตนเองโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ด้วยตนเอง — โดยส่วนใหญ่เพื่อกำหนดค่าเช่นพร็อกซี หรือใช้ [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) หรือ [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) ที่ต่างออกไปเพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดีกว่า — คุณสามารถส่งอินสแตนซ์ `HttpURLConnection` ของคุณเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/)

```java
// สมมติว่าคุณมีอินสแตนซ์ HttpURLConnection ที่กำหนดค่าไว้ล่วงหน้า (เช่น ตั้งค่าความล่าช้าแบบกำหนดเอง, การตั้งค่าพร็อกซี, เป็นต้น)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **ประโยชน์หลัก**

API การแปลงานนำเสนอของ Aspose.Slides ให้โซลูชันที่ขับเคลื่อนด้วย AI สำหรับการจัดทำงานนำเสนอ PowerPoint หลายภาษา โดยอัตโนมัติการแปลพร้อมคงการจัดวางและการออกแบบเดิม ช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำด้วยมือ ไม่ว่าจะเป็นนักพัฒนา นักการศึกษา หรือผู้เชี่ยวชาญด้านธุรกิจ API นี้ช่วยให้คุณสร้างงานนำเสนอที่ดึงดูดและแปลเฉพาะท้องถิ่นสำหรับผู้ชมทั่วโลก — ขยายขอบเขตการเข้าถึงและปรับปรุงการสื่อสาร