---
title: เครื่องสร้างสไลด์หลายภาษาที่ขับเคลื่อนด้วย AI
linktitle: เครื่องสร้างที่ขับเคลื่อนด้วย AI
type: docs
weight: 40
url: /th/nodejs-java/ai/generator/
keywords:
- การนำเสนอหลายภาษา
- สไลด์หลายภาษา
- เครื่องสร้างการนำเสนอด้วย AI
- เครื่องสร้างสไลด์ด้วย AI
- คุณลักษณะที่ขับเคลื่อนด้วย AI
- เอเจนต์ AI
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างสไลด์หลายภาษา จากข้อความด้วย Aspose.Slides สำหรับ Node.js. ใช้แม่แบบของคุณและส่งออกเด็คที่เรียบหรูไปยัง PowerPoint และ OpenDocument. เรียนรู้เพิ่มเติม."
---
## **บทนำ**

Aspose.Slides แนะนำคุณลักษณะใหม่ที่ใช้ AI คือ Presentation Generator ซึ่งช่วยให้นักพัฒนาสามารถสร้างงานนำเสนอ PowerPoint ที่มีโครงสร้างดีโดยอัตโนมัติจากข้อความง่าย ๆ เช่น คำอธิบายหัวข้อ, สรุป, คำคม หรือรายการหัวข้อย่อย

ผู้ใช้สามารถปรับระดับความละเอียดของเนื้อหาและเลือกใช้แม่แบบการนำเสนอแบบกำหนดเองเพื่อกำหนดการออกแบบภาพได้

ในขณะนี้ AI Presentation Generator จัดโครงสร้างเนื้อหาโดยใช้บล็อกข้อความ, รายการหัวข้อย่อย, และตาราง การสร้างรูปภาพยังไม่รองรับ; อย่างไรก็ตาม สามารถเพิ่มรูปภาพได้อย่างง่ายดายภายหลังโดยใช้เครื่องมือของ Aspose.Slides หรือด้วยตนเอง

ผลลัพธ์คือการนำเสนอ PowerPoint ที่สมบูรณ์ซึ่งสามารถใช้ได้ทันทีหรือส่งออกเป็นรูปแบบใดก็ได้ที่ API ของ Aspose.Slides รองรับ แม้ว่าตัวสร้างจะให้ผลลัพธ์คุณภาพสูง แต่บางครั้งอาจต้องมีการแก้ไขเล็กน้อยหลังการสร้างเพื่อให้ตรงกับความต้องการเฉพาะ

## **วิธีการทำงาน**

Aspose.Slides ไม่มีโมเดล AI ที่สร้างมาในตัว; แต่จะเชื่อมต่อกับบริการ AI ภายนอกจากอินเทอร์เน็ต การผสานนี้จัดการโดยคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesaiagent/)

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/) ที่สร้างมาในตัว ซึ่งเชื่อมต่อกับ API ของ OpenAI ได้ Aspose.Slides จัดการการสื่อสารทั้งหมดกับบริการ AI และประมวลผลการตอบกลับของ AI เพื่อสร้างสไลด์ โปรดทราบว่า API ของ OpenAI เป็นบริการแบบชำระเงิน ดังนั้นจึงต้องมีบัญชีและคีย์ API เมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/) ที่สร้างมาในตัว

## **มาเขียนโค้ดกัน**

### **ตัวอย่างที่ 1**

ตัวอย่างนี้แสดงวิธีการสร้างการนำเสนอในหัวข้อ Aspose.Slides ด้วยการใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/) ที่สร้างมาในตัว

```js
// สร้างอินสแตนซ์ของ OpenAIWebClient ซึ่งเป็นการนำไปใช้ในตัวของไคลเอนต์เว็บ OpenAI.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // สร้างอินสแตนซ์ของ SlidesAIAgent ซึ่งให้เข้าถึงคุณลักษณะที่ขับเคลื่อนด้วย AI.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // กำหนดคำสั่งสำหรับการสร้างการนำเสนอ.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // สร้างการนำเสนอด้วยปริมาณเนื้อหาขนาดกลางตามคำสั่ง.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // บันทึกการนำเสนอที่สร้างไว้ลงดิสก์ท้องถิ่นเป็นไฟล์ PowerPoint (.pptx) file.
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **ตัวอย่างที่ 2**

ตัวอย่างต่อไปนี้แสดงการอัปโหลดของเมธอด [generatePresentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation) ในกรณีนี้ จะใช้อินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ที่จัดการภายนอกและ `master presentation` ของผู้ใช้

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/) ที่สร้างมาในตัวจะสร้างและจัดการอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ภายในของตนเองโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ด้วยตนเอง—เช่น เมื่อใช้ [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) หรือ [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) เพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดีขึ้น—คุณสามารถระบุอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/openaiwebclient/)

```js
// ส่ง HttpURLConnection ไปยังคอนสตรัคเตอร์ของ OpenAIWebClient.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // สร้างอินสแตนซ์ของ SlidesAIAgent.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // กำหนดคำสั่งสำหรับการสร้างการนำเสนอ.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // โหลดการนำเสนอหลักจากดิสก์ท้องถิ่นเพื่อใช้เป็นแม่แบบการออกแบบ.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // สร้างการนำเสนอเชิงละเอียดโดยใช้คำสั่งและแม่แบบหลัก.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // บันทึกการนำเสนอที่สร้างเป็น PDF.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **ประโยชน์หลัก**

AI Presentation Generator ใหม่ใน Aspose.Slides มอบวิธีที่เร็วและยืดหยุ่นในการสร้างชุดสไลด์ที่มีโครงสร้างจากข้อความแจ้งสั้น ๆ ที่ง่ายต่อการใช้ รองรับการใช้แม่แบบกำหนดเองและอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ที่จัดการภายนอก ทำให้สามารถผสานเข้ากับแอปพลิเคชันหลากหลายได้อย่างราบรื่น

กรณีการใช้งานทั่วไปรวมถึงการสร้างการนำเสนอการตลาด, สื่อการศึกษา, รายงานให้ลูกค้า, และชุดสไลด์ภายในองค์กร แม้ว่าการสร้างรูปภาพยังไม่รองรับ แต่เครื่องมือนี้ยังมีพื้นฐานที่แข็งแรงสำหรับการอัตโนมัติการสร้างการนำเสนอ และคาดว่าจะมีการปรับปรุงเพิ่มเติมในอนาคต