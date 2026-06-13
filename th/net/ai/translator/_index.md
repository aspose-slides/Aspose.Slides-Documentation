---
title: ตัวแปลการนำเสนอที่ขับเคลื่อนด้วย AI
linktitle: ตัวแปลที่ขับเคลื่อนด้วย AI
type: docs
weight: 20
url: /th/net/ai/translator/
keywords:
- ตัวแปลการนำเสนอด้วย AI
- ตัวแปลสไลด์ด้วย AI
- ฟีเจอร์ที่ขับเคลื่อนด้วย AI
- การนำเสนอหลายภาษา
- สไลด์หลายภาษา
- การแปลการนำเสนอ
- การแปลสไลด์
- ฟีเจอร์ขับเคลื่อนด้วย AI
- ความสามารถของ AI
- เอเจนท์ AI
- ไคลเอนท์เว็บ
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ .NET. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นขณะคงเค้าโครงไว้—เร็วและเป็นมิตรต่อผู้พัฒนา. ลองใช้งานได้เลย."
---
## **บทนำ**

Aspose.Slides เป็น API ที่ทรงพลังสำหรับการจัดการงานนำเสนอ PowerPoint อย่างเป็นโปรแกรม นอกจากการสร้าง, แก้ไข, และแปลงสไลด์แล้ว ยังมีฟีเจอร์ที่ขับเคลื่อนด้วย AI เช่น [Presentation Translation API](https://reference.aspose.com/slides/th/net/aspose.slides.ai/) สำหรับเนื้อหาสไลด์หลายภาษา

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้มีความสามารถ AI ภายในตัว แต่รวมเข้ากับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ฟังก์ชันนี้เปิดให้ใช้ผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/net/aspose.slides.ai/slidesaiagent) ซึ่งใช้การนำเข้า (implementation) ของอินเทอร์เฟซ [IAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/iaiwebclient/) เพื่อสื่อสารกับบริการ AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) ที่มาพร้อมเพื่อเชื่อมต่อกับ API ของ OpenAI หรือคุณสามารถสร้างการนำเข้า (implement) ของ [IAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/iaiwebclient/) ของคุณเองเพื่อใช้ผู้ให้บริการ AI หรือโมเดลภาษาที่แตกต่าง

Aspose.Slides จัดการการสื่อสาร, แยกวิเคราะห์การตอบกลับจาก AI, และใส่เนื้อหาที่แปลอย่างฉลาดโดยคงรูปแบบและการจัดวางสไลด์เดิมไว้

{{% alert color="primary" %}}
โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องชำระเงิน ดังนั้นคุณต้องสร้างบัญชีและใส่คีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/)
{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราแปลงานนำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) ที่มาพร้อมกับโมเดล OpenAI ที่ระบุไว้

```csharp
// โหลดงานนำเสนอเพื่อแปล.
using var presentation = new Presentation("sample.pptx");

// สร้างไคลเอนต์ AI ด้วย OpenAIWebClient, ระบุโมเดลและคีย์ API ของคุณ.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// เริ่มต้น SlidesAIAgent ด้วยไคลเอนต์ AI.
var aiAgent = new SlidesAIAgent(aiWebClient);

// แปลงานนำเสนอเป็นภาษาญี่ปุ่น.
await aiAgent.TranslateAsync(presentation, "japanese");

// บันทึกงานนำเสนอที่แปลเป็น PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

โดยค่าเริ่มต้น, [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) ที่มาพร้อมสร้างและจัดการอินสแตนซ์ [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ภายในของมันเอง, ดูแลวงจรชีวิตและการทำลายโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ด้วยตนเอง - เช่น เมื่อใช้ [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) เพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดีกว่า - คุณสามารถให้อินสแตนซ์ `HttpClient` ของคุณเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) ได้

```csharp
// สมมติว่าคุณมีอินสแตนซ์ของ IHttpClientFactory (เช่น ถูกฉีดเข้ามาผ่านการฉีดพึ่งพา).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides มักถูกใช้ในสภาพแวดล้อมแบบประสานกัน (synchronous) เพื่อสนับสนุนสิ่งนี้ คลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/net/aspose.slides.ai/slidesaiagent/) มีเมธอดทั้งแบบประสานและแบบอะซิงโครนัส ให้คุณเลือกวิธีที่เหมาะกับกระบวนการทำงานของแอปพลิเคชันของคุณ

## **ประโยชน์หลัก**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/th/net/aspose.slides.ai/) เสนอวิธีแก้ปัญหาที่ขับเคลื่อนด้วย AI สำหรับการส่งมอบงานนำเสนอ PowerPoint หลายภาษา ด้วยการทำแปลอัตโนมัติพร้อมคงรูปแบบและการออกแบบ มันช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำงานด้วยมือ ไม่ว่าคุณจะเป็นนักพัฒนา, นักการศึกษา, หรือผู้เชี่ยวชาญด้านธุรกิจ API นี้ทำให้คุณสร้างงานนำเสนอที่น่าสนใจและปรับให้เป็นท้องถิ่นสำหรับผู้ชมทั่วโลก - ขยายขอบเขตการเข้าถึงและปรับปรุงการสื่อสาร.