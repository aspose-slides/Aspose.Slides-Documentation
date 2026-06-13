---
title: ตัวแปลการนำเสนอด้วย AI
linktitle: ตัวแปลด้วย AI
type: docs
weight: 20
url: /th/nodejs-java/ai/translator/
keywords:
- ตัวแปลการนำเสนอด้วย AI
- ตัวแปลสไลด์ด้วย AI
- คุณลักษณะที่ขับเคลื่อนด้วย AI
- งานนำเสนอหลายภาษา
- สไลด์หลายภาษา
- การแปลการนำเสนอ
- การแปลสไลด์
- คุณลักษณะที่ขับเคลื่อนด้วย AI
- ความสามารถของ AI
- ตัวแทน AI
- ไคลเอ็นต์เว็บ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ Node.js. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นในขณะที่คงรูปแบบเดิม—เร็วและเป็นมิตรต่อผู้พัฒนา. ลองใช้ดู."
---
## **บทนำ**

Aspose.Slides เป็น API ที่ทรงพลังสำหรับการจัดการการนำเสนอ PowerPoint ด้วยโปรแกรมเมชัน นอกจากการสร้าง แก้ไข และแปลงสไลด์แล้ว ยังมีคุณลักษณะที่ขับเคลื่อนด้วย AI เช่น Presentation Translation API สำหรับเนื้อหาสไลด์หลายภาษา

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้รวมความสามารถ AI อยู่ในตัว แต่จะทำการเชื่อมต่อกับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ฟังก์ชันนี้ถูกเปิดเผยผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesaiagent/) เพื่อสื่อสารกับบริการ AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/) ที่มีมาพร้อมเพื่อเชื่อมต่อกับ API ของ OpenAI

Aspose.Slides จะจัดการการสื่อสาร แปลความตอบรับจาก AI และแทรกเนื้อหาที่แปลอย่างฉลาดในขณะที่คงรูปแบบและการจัดหน้าสไลด์เดิมไว้

{{% alert color="primary" %}}
โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องเสียค่าใช้จ่าย ดังนั้นคุณจะต้องสร้างบัญชีและใส่คีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/)
{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราแปลงการนำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/) ที่มีมาพร้อมพร้อมระบุ [model](https://platform.openai.com/docs/models) ของ OpenAI

```js
// โหลดการนำเสนอเพื่อแปล.
let presentation = new aspose.slides.Presentation("sample.pptx");

// สร้างไคลเอ็นต์ AI ด้วย OpenAIWebClient ระบุโมเดลและคีย์ API ของคุณ.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // เริ่มต้น SlidesAIAgent ด้วยไคลเอนต์ AI.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // แปลการนำเสนอเป็นภาษาญี่ปุ่น.
    aiAgent.translate(presentation, "japanese");

    // บันทึกการนำเสนอที่แปลเป็น PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/) จะสร้างและจัดการอินสแตนซ์ของ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ของเองโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ด้วยตนเอง — เช่น เพื่อตั้งค่าพร็อกซี่ หรือใช้ [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) หรือ [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) แบบอื่นเพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดีขึ้น — คุณสามารถส่งอินสแตนซ์ `HttpURLConnection` ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/)

```js
// สมมติว่าคุณมีอินสแตนซ์ HttpURLConnection ที่กำหนดค่าล่วงหน้า (เช่น ตั้งค่า timeout แบบกำหนดเอง การตั้งค่าพร็อกซี่ เป็นต้น)
let urlConnection = yourPreconfiguredConnection;
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **ประโยชน์หลัก**

Aspose.Slides Presentation Translation API มอบโซลูชันที่ใช้ AI เพื่อจัดทำการนำเสนอ PowerPoint หลายภาษาโดยอัตโนมัติ การแปลที่คงรูปร่างและการออกแบบช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเปรียบเทียบกับกระบวนการทำด้วยมือ ไม่ว่าคุณจะเป็นนักพัฒนา ผู้สอน หรือผู้เชี่ยวชาญด้านธุรกิจ API นี้ช่วยให้คุณสร้างการนำเสนอที่ดึงดูดและปรับให้เป็นภาษาท้องถิ่นสำหรับผู้ชมทั่วโลก — เพิ่มขอบเขตการเข้าถึงและพัฒนาการสื่อสารของคุณ