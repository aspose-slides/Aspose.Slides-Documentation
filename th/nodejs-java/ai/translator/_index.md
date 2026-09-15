---
title: เครื่องแปลงานนำเสนอด้วย AI
linktitle: เครื่องแปลด้วย AI
type: docs
weight: 20
url: /th/nodejs-java/ai/translator/
keywords:
- ตัวแปลงานนำเสนอด้วย AI
- ตัวแปลสไลด์ด้วย AI
- คุณลักษณะที่ใช้ AI
- งานนำเสนอหลายภาษา
- สไลด์หลายภาษา
- การแปลงานนำเสนอ
- การแปลสไลด์
- คุณลักษณะที่ขับเคลื่อนด้วย AI
- ความสามารถของ AI
- เอเจนท์ AI
- ไคลเอนต์เว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ Node.js. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นพร้อมคงรูปแบบเดิม—เร็วและเป็นมิตรต่อผู้พัฒนา. ลองดู."
---
## **บทนำ**

Aspose.Slides เป็น API ที่มีประสิทธิภาพสำหรับการจัดการงานนำเสนอ PowerPoint ผ่านโปรแกรม นอกจากการสร้าง แก้ไข และแปลงสไลด์แล้ว ยังมีคุณสมบัติที่ขับเคลื่อนด้วย AI เช่น Presentation Translation API สำหรับเนื้อหาสไลด์หลายภาษา

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้รวมความสามารถ AI ในตัว แต่จะทำการเชื่อมต่อกับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ความสามารถนี้เปิดให้ใช้ผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesaiagent/) เพื่อสื่อสารกับบริการ AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/) ในตัวเพื่อเชื่อมต่อกับ API ของ OpenAI

Aspose.Slides จัดการการสื่อสาร แยกวิเคราะห์การตอบกลับจาก AI และแทรกเนื้อหาที่แปลอย่างฉับไวโดยคงรักษาเค้าโครงและการจัดรูปแบบของสไลด์เดิมไว้

{{% alert color="info" title="หมายเหตุ" %}}
หมายเหตุว่า API ของ OpenAI เป็นบริการที่ต้องเสียค่าใช้จ่าย ดังนั้นคุณต้องสร้างบัญชีและระบุคีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/) ในตัว
{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราแปลงานนำเสนอ PowerPoint ไปเป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/) ในตัวพร้อมกับระบุ [model](https://platform.openai.com/docs/models) ของ OpenAI ที่ต้องการ

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// โหลดงานนำเสนอเพื่อแปล.
let presentation = new aspose.slides.Presentation("sample.pptx");

// สร้างไคลเอนต์ AI ด้วย OpenAIWebClient ระบุโมเดลและคีย์ API ของคุณ.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // เริ่มต้น SlidesAIAgent ด้วยไคลเอนต์ AI.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // แปลงานนำเสนอเป็นภาษาญี่ปุ่น.
    aiAgent.translate(presentation, "japanese");

    // บันทึกงานนำเสนอที่แปลเป็น PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/) จะสร้างและจัดการอินสแตนซ์ของ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ภายในตัวเองโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ด้วยตนเอง — เช่น การกำหนดค่าพร็อกซี่ หรือการใช้ [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) หรือ [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) อื่นสำหรับการจัดการทรัพยากรและประสิทธิภาพที่ดีกว่า — คุณสามารถส่งอินสแตนซ์ `HttpURLConnection` ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/) ได้

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Create and pre-configure an HttpURLConnection instance (e.g., with custom timeouts, proxy settings, etc.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **ตัวอย่าง Azure OpenAI**

คุณสามารถกำหนดค่าตัวแปลภาษาให้ใช้การปรับใช้ Azure OpenAI ของคุณด้วย [OpenAICompatibleWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaicompatiblewebclient/)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

โค้ดตัวอย่างนี้แสดงการแปลงานนำเสนอโดยใช้จุดเชื่อมต่อ Azure OpenAI ของคุณ ให้เปลี่ยนค่าตัวแปรที่เป็นตัวอย่างให้เป็นชื่อการปรับใช้ คีย์ API และ URL ของจุดเชื่อมต่อของคุณ

## **ประโยชน์สำคัญ**

Aspose.Slides Presentation Translation API มอบโซลูชันที่ขับเคลื่อนด้วย AI สำหรับการส่งมอบงานนำเสนอ PowerPoint แบบหลายภาษา ด้วยการทำให้การแปลเป็นอัตโนมัติพร้อมคงเค้าโครงและการออกแบบเดิมไว้ ช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำด้วยมือ ไม่ว่าคุณจะเป็นนักพัฒนา ครูผู้สอน หรือผู้เชี่ยวชาญด้านธุรกิจ API นี้จะทำให้คุณสร้างงานนำเสนอที่น่าสนใจและเป็นภาษาถิ่นสำหรับผู้ชมทั่วโลก — ขยายการเข้าถึงและปรับปรุงการสื่อสารของคุณอย่างมีประสิทธิภาพ