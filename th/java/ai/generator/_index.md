---
title: เครื่องสร้างสไลด์หลายภาษาที่ใช้ AI
linktitle: เครื่องสร้างที่ใช้ AI
type: docs
weight: 40
url: /th/java/ai/generator/
keywords:
- การนำเสนอหลายภาษา
- สไลด์หลายภาษา
- ตัวสร้างการนำเสนอด้วย AI
- ตัวสร้างสไลด์ด้วย AI
- คุณสมบัติที่ขับด้วย AI
- ตัวแทน AI
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างสไลด์หลายภาษาจากข้อความด้วย Aspose.Slides สำหรับ Java ใช้เทมเพลตของคุณและส่งออกงานที่เรียบหรูเป็น PowerPoint และ OpenDocument เรียนรู้เพิ่มเติม."
---
## **คำนำ**

Aspose.Slides แนะนำคุณลักษณะใหม่ที่ใช้ AI คือ Presentation Generator ซึ่งทำให้ผู้พัฒนาสามารถสร้างงานนำเสนอ PowerPoint ที่มีโครงสร้างดีโดยอัตโนมัติจากข้อความง่าย ๆ เช่น คำอธิบายหัวข้อ, สรุป, คำคม หรือรายการหัวข้อย่อย.

ผู้ใช้สามารถปรับระดับความละเอียดของเนื้อหาและเลือกใช้เทมเพลตงานนำเสนอแบบกำหนดเองเพื่อกำหนดการออกแบบภาพได้ตามต้องการ.

ในขณะนี้ AI Presentation Generator จัดโครงสร้างเนื้อหาโดยใช้บล็อกข้อความ, รายการแบบหัวข้อย่อย, และตาราง การสร้างภาพยังไม่รองรับ; อย่างไรก็ตาม สามารถเพิ่มภาพได้อย่างง่ายดายหลังจากนั้นด้วยเครื่องมือของ Aspose.Slides หรือด้วยตนเอง.

ผลลัพธ์คือไฟล์ PowerPoint ที่ครบถ้วนซึ่งสามารถใช้ได้เลยหรือส่งออกเป็นรูปแบบใด ๆ ที่รองรับโดย Aspose.Slides API แม้ว่าเครื่องมื่อนี้จะสร้างผลลัพธ์คุณภาพสูง แต่บางครั้งอาจต้องมีการแก้ไขขั้นสุดท้ายเล็กน้อยเพื่อให้ตรงกับความต้องการเฉพาะ.

## **วิธีทำงาน**

Aspose.Slides ไม่ได้รวมโมเดล AI ในตัว; แต่จะเชื่อมต่อกับบริการ AI ภายนอกผ่านอินเทอร์เน็ต การบูรณาการนี้ดำเนินการโดยคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesaiagent/) ซึ่งใช้การนำไปใช้ของอินเทอร์เฟซ [IAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaiwebclient/) เพื่อสื่อสารกับโมเดล AI.

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) ที่รวมมาในตัว ซึ่งเชื่อมต่อกับ API ของ OpenAI, หรือให้การนำไปใช้แบบกำหนดเองของ [IAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaiwebclient/) เพื่อทำงานกับผู้ให้บริการ AI หรือโมเดลภาษาอื่น ๆ Aspose.Slides จะจัดการการสื่อสารทั้งหมดกับบริการ AI และประมวลผลการตอบกลับของ AI เพื่อสร้างสไลด์ โปรดทราบว่า OpenAI API เป็นบริการที่ต้องชำระเงิน ดังนั้นจึงต้องมีบัญชีและคีย์ API เมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) ที่รวมมาในตัว.

## **มาลองเขียนโค้ด**

### **ตัวอย่างที่ 1**

ตัวอย่างนี้แสดงวิธีการสร้างงานนำเสนอเกี่ยวกับหัวข้อ Aspose.Slides โดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) ที่รวมมาในตัว.

```java
// สร้างอินสแตนซ์ของ OpenAIWebClient ซึ่งเป็นการนำไปใช้ในตัวของไคลเอนต์เว็บ OpenAI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // สร้างอินสแตนซ์ของ SlidesAIAgent ที่ให้การเข้าถึงคุณลักษณะที่ขับด้วย AI.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // กำหนดคำสั่งสำหรับการสร้างงานนำเสนอ.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // สร้างงานนำเสนอโดยมีจำนวนเนื้อหาปานกลางตามคำสั่ง.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // บันทึกงานนำเสนอที่สร้างลงดิสก์ท้องถิ่นเป็นไฟล์ PowerPoint (.pptx).
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **ตัวอย่างที่ 2**

ตัวอย่างต่อไปนี้แสดงการโอเวอร์โหลดของเมธอด [generatePresentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-) ในกรณีนี้จะใช้อินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ที่จัดการจากภายนอกพร้อมกับ `master presentation` ของผู้ใช้

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) ที่รวมมาในตัวจะสร้างและจัดการอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ภายในของตนเองโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ด้วยตนเอง—เช่น เมื่อใช้ [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) หรือ [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) เพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดีขึ้น—คุณสามารถส่งอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/).

```java
// ส่ง HttpURLConnection ไปยังคอนสตรัคเตอร์ของ OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // สร้างอินสแตนซ์ของ SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // กำหนดคำสั่งสำหรับการสร้างงานนำเสนอ.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // โหลดงานนำเสนอหลักจากดิสก์ท้องถิ่นเพื่อใช้เป็นเทมเพลตการออกแบบ.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // สร้างงานนำเสนอโดยละเอียดโดยใช้คำสั่งและเทมเพลตหลัก.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // บันทึกงานนำเสนอที่สร้างเป็น PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **ข้อดีหลัก**

AI Presentation Generator ใหม่ใน Aspose.Slides ให้วิธีที่รวดเร็วและยืดหยุ่นในการสร้างชุดสไลด์ที่มีโครงสร้างจากข้อความสั้น ๆ ที่ง่าย รองรับเทมเพลตแบบกำหนดเองและอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ที่จัดการจากภายนอก ทำให้สามารถผสานรวมกับแอปพลิเคชันหลากหลายได้อย่างไร้รอยต่อ.

กรณีการใช้งานทั่วไปรวมถึงการสร้างงานนำเสนอทางการตลาด, วัสดุการศึกษา, รายงานลูกค้า, และชุดสไลด์ภายใน แม้การสร้างภาพยังไม่รองรับ แต่เครื่องมือนี้มีพื้นฐานที่แข็งแกร่งสำหรับการอัตโนมัติการสร้างงานนำเสนอ และคาดว่าจะมีการปรับปรุงเพิ่มเติมในอนาคต.