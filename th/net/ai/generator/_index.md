---
title: เครื่องสร้างสไลด์หลายภาษาโดยใช้ AI
linktitle: เครื่องสร้างโดย AI
type: docs
weight: 40
url: /th/net/ai/generator/
keywords:
- การนำเสนอหลายภาษา
- สไลด์หลายภาษา
- เครื่องสร้างการนำเสนอด้วย AI
- เครื่องสร้างสไลด์ด้วย AI
- ฟีเจอร์ที่ใช้ AI
- เอเจนท์ AI
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างสไลด์หลายภาษาจากข้อความด้วย Aspose.Slides สำหรับ .NET. ใช้เทมเพลตของคุณและส่งออกชุดสไลด์ที่เรียบหรูไปยัง PowerPoint และ OpenDocument. เรียนรู้เพิ่มเติม."
---
## **บทนำ**

Aspose.Slides แนะนำคุณลักษณะใหม่ที่ใช้ AI ชื่อ Presentation Generator ซึ่งช่วยให้นักพัฒนาสร้างงานนำเสนอ PowerPoint ที่มีโครงสร้างดีโดยอัตโนมัติจากข้อความง่าย ๆ เช่น คำอธิบายหัวข้อ สรุป คำพูดอ้างอิง หรือรายการหัวข้อย่อย

ผู้ใช้สามารถปรับระดับความละเอียดของเนื้อหาและเลือกใช้เทมเพลตการนำเสนอแบบกำหนดเองเพื่อกำหนดการออกแบบภาพได้

ปัจจุบัน AI Presentation Generator จัดโครงสร้างเนื้อหาโดยใช้บล็อกข้อความ รายการหัวข้อย่อย และตาราง การสร้างภาพยังไม่รองรับ; อย่างไรก็ตาม สามารถเพิ่มภาพได้ง่ายภายหลังโดยใช้เครื่องมือของ Aspose.Slides หรือทำด้วยตนเอง

ผลลัพธ์คือไฟล์ PowerPoint ที่สมบูรณ์ซึ่งสามารถใช้ได้ทันทีหรือส่งออกเป็นรูปแบบใดก็ได้ที่รองรับโดย Aspose.Slides API แม้ว่าตัวสร้างจะให้ผลลัพธ์คุณภาพสูง แต่บางครั้งอาจต้องแก้ไขเล็กน้อยหลังการสร้างเพื่อให้ตรงตามความต้องการเฉพาะ

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้มีโมเดล AI ภายใน; แต่ทำการรวมกับบริการ AI ภายนอกผ่านอินเทอร์เน็ต การรวมนี้จัดการโดยคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/net/aspose.slides.ai/slidesaiagent/) ซึ่งใช้การทำงานของอินเทอร์เฟซ [IAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/iaiwebclient/) เพื่อสื่อสารกับโมเดล AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) ที่มีมาให้ ซึ่งเชื่อมต่อกับ API ของ OpenAI หรือให้การทำงานของ [IAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/iaiwebclient/) ตามที่คุณกำหนดเพื่อทำงานกับผู้ให้บริการ AI หรือโมเดลภาษาอื่น Aspose.Slides จัดการการสื่อสารทั้งหมดกับบริการ AI และประมวลผลการตอบกลับของ AI เพื่อสร้างสไลด์ หมายเหตุว่า API ของ OpenAI เป็นบริการแบบชำระเงิน ดังนั้นต้องมีบัญชีและคีย์ API เมื่อต้องการใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/)

## **มาลองเขียนโค้ด**

### **ตัวอย่าง 1**

ตัวอย่างนี้แสดงวิธีการสร้างงานนำเสนอในหัวข้อ Aspose.Slides โดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) ที่มีมาให้

```csharp
// สร้างอินสแตนซ์ของ OpenAIWebClient ซึ่งเป็นการใช้งาน implementation แบบ built-in ของเว็บไคลเอนต์ OpenAI
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// สร้างอินสแตนซ์ของ SlidesAIAgent ซึ่งให้การเข้าถึงฟีเจอร์ที่ใช้ AI
var aiAgent = new SlidesAIAgent(aiWebClient);

// กำหนดคำสั่งสำหรับการสร้างงานนำเสนอ
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// สร้างงานนำเสนอด้วยปริมาณเนื้อหาระดับกลางตามคำสั่ง
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// บันทึกงานนำเสนอที่สร้างไว้ลงดิสก์ท้องถิ่นเป็นไฟล์ PowerPoint (.pptx)
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **ตัวอย่าง 2**

ตัวอย่างต่อไปนี้แสดงการอัปโหลดของเมธอด [GeneratePresentation](https://reference.aspose.com/slides/th/net/aspose.slides.ai/slidesaiagent/generatepresentation/) ในกรณีนี้จะใช้อินสแตนซ์ [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ที่จัดการจากภายนอกและ `master presentation` ของผู้ใช้

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) ที่มาพร้อมกับไลบรารีจะสร้างและจัดการอินสแตนซ์ [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ภายในของตนเองโดยอัตโนมัติ หากคุณต้องการจัดการ [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ด้วยตนเอง—for example, when using an [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) เพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดีขึ้น—คุณสามารถส่งอินสแตนซ์ [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/)

```csharp
// สร้างอินสแตนซ์ HttpClient ที่จัดการจากภายนอก.
using var httpClient = new HttpClient();

// ส่ง HttpClient ไปยังคอนสตรัคเตอร์ของ OpenAIWebClient.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// สร้างอินสแตนซ์ของ SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// กำหนดคำสั่งสำหรับการสร้างงานนำเสนอ.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// โหลด master presentation จากดิสก์ท้องถิ่นเพื่อใช้เป็นเทมเพลตการออกแบบ.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// สร้างงานนำเสนอแบบละเอียดโดยใช้คำสั่งและเทมเพลต master.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// บันทึกงานนำเสนอที่สร้างเป็นไฟล์ PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

ควรทราบว่าลูกค้าหลายรายใช้ Aspose.Slides ในบริบทแบบ synchronous เพื่อรองรับความต้องการนี้ คลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/net/aspose.slides.ai/slidesaiagent/) ให้เมธอดทั้งแบบ synchronous และ asynchronous ทำให้คุณเลือกวิธีที่เหมาะกับกระบวนการทำงานของแอปพลิเคชันได้

## **ประโยชน์หลัก**

AI Presentation Generator ใหม่ใน Aspose.Slides ให้วิธีที่รวดเร็วและยืดหยุ่นในการสร้างชุดสไลด์ที่มีโครงสร้างจากคำสั่งข้อความแบบง่าย ด้วยการสนับสนุนเทมเพลตแบบกำหนดเอง อินสแตนซ์ [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ที่จัดการจากภายนอก และกระบวนการทั้งแบบ synchronous และ asynchronous จึงสามารถผสานเข้ากับแอปพลิเคชันหลากหลายประเภทได้อย่างราบรื่น

กรณีการใช้งานทั่วไปรวมถึงการสร้างงานนำเสนอการตลาด วัสดุการศึกษา รายงานลูกค้า และชุดสไลด์ภายในองค์กร แม้ว่าการสร้างภาพยังไม่รองรับในขณะนี้ เครื่องมือนี้ก็ให้พื้นฐานที่แข็งแกร่งสำหรับการอัตโนมัติการสร้างงานนำเสนอ พร้อมคาดว่าจะมีการพัฒนาเพิ่มเติมในอนาคต