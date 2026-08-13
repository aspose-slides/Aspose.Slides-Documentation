---
title: เครื่องแปลงานนำเสนอด้วย AI
linktitle: เครื่องแปลด้วย AI
type: docs
weight: 20
url: /th/net/ai/translator/
keywords:
- เครื่องแปลงานนำเสนอด้วย AI
- เครื่องแปลสไลด์ด้วย AI
- ฟีเจอร์ขับเคลื่อนด้วย AI
- งานนำเสนอหลายภาษา
- สไลด์หลายภาษา
- การแปลงานนำเสนอ
- การแปลสไลด์
- ฟีเจอร์ที่ขับเคลื่อนโดย AI
- ความสามารถของ AI
- เอเจนต์ AI
- ไคลเอนด์เว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ .NET. ทำให้ PPT, PPTX และ ODP มีการแปลภาษาในขณะคงรูปแบบเดิม—รวดเร็วและเป็นมิตรต่อผู้พัฒนา. ลองใช้งาน."
---
## **บทนำ**

Aspose.Slides เป็น API ที่มีประสิทธิภาพสำหรับการจัดการงานนำเสนอ PowerPoint ด้วยโปรแกรม ไม่ว่าจะเป็นการสร้าง แก้ไข และแปลงสไลด์ อีกทั้งยังมอบคุณลักษณะขับเคลื่อนด้วย AI เช่น [API การแปลงานนำเสนอ](https://reference.aspose.com/slides/th/net/aspose.slides.ai/) สำหรับเนื้อหาสไลด์หลายภาษา

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้รวมความสามารถ AI ภายในตัวเอง แต่ทำการเชื่อมต่อกับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ฟังก์ชันนี้เปิดให้ใช้ผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/net/aspose.slides.ai/slidesaiagent) ซึ่งใช้การทำงานของอินเทอร์เฟซ [IAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/iaiwebclient/) เพื่อสื่อสารกับบริการ AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) ที่มีให้ในตัวเพื่อเชื่อมต่อกับ API ของ OpenAI หรือสร้างการทำงานของ [IAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/iaiwebclient/) ของคุณเองเพื่อใช้ผู้ให้บริการ AI หรือโมเดลภาษาอื่น

Aspose.Slides จะจัดการการสื่อสาร วิเคราะห์ผลตอบกลับจาก AI และแทรกเนื้อหาที่แปลอย่างชาญฉลาดโดยคงรูปแบบและการจัดหน้าต้นฉบับของสไลด์ไว้

{{% alert color="info" %}}

โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องชำระเงิน ดังนั้นคุณจะต้องสร้างบัญชีและระบุคีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/)

{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราจะแปลงานนำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) ที่มีในตัวพร้อมระบุ [โมเดล](https://platform.openai.com/docs/models) ของ OpenAI ที่ต้องการ

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// โหลดงานนำเสนอเพื่อแปล.
using var presentation = new Presentation("sample.pptx");

// สร้างไคลเอนต์ AI ด้วย OpenAIWebClient พร้อมระบุโมเดลและคีย์ API ของคุณ.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// เริ่มต้น SlidesAIAgent ด้วยไคลเอนต์ AI.
var aiAgent = new SlidesAIAgent(aiWebClient);

// แปลงานนำเสนอเป็นภาษาญี่ปุ่น.
await aiAgent.TranslateAsync(presentation, "japanese");

// บันทึกงานนำเสนอที่แปลเป็น PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) จะสร้างและจัดการอินสแตนซ์ของ [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ภายในตัวเองโดยอัตโนมัติ รวมถึงการจัดช่วงอายุและการยกเลิกการใช้ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) เอง — เช่น เมื่อใช้ [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) เพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดียิ่งขึ้น — คุณสามารถส่งอินสแตนซ์ `HttpClient` ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/)

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// ใช้ HttpClient ที่คุณจัดการด้วยตนเอง - ตัวอย่างเช่น ที่สร้างโดย IHttpClientFactory
// ฉีดผ่านการฉีดพึ่งพา (dependency injection).
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides มักถูกใช้ในสภาพแวดล้อมที่ทำงานแบบซิงโครนัส เพื่อรองรับความต้องการนี้ คลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/net/aspose.slides.ai/slidesaiagent/) มีทั้งเมธอดแบบซิงโครนัสและอะซิงโครนัส ให้คุณเลือกวิธีที่เหมาะกับกระบวนการทำงานของแอปพลิเคชันของคุณได้

## **ประโยชน์หลัก**

[API การแปลงานนำเสนอ](https://reference.aspose.com/slides/th/net/aspose.slides.ai/) ของ Aspose.Slides เสนอวิธีแก้ปัญหาที่ใช้ AI เพื่อส่งมอบงานนำเสนอ PowerPoint หลายภาษา ด้วยการทำแปลอัตโนมัติพร้อมคงรูปแบบและการออกแบบเดิมไว้ ช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำงานด้วยมือ ไม่ว่าคุณจะเป็นนักพัฒนา ผู้สอน หรือมืออาชีพด้านธุรกิจ API นี้ช่วยให้คุณสร้างงานนำเสนอที่ดึงดูดและปรับให้เป็นท้องถิ่นสำหรับผู้ชมทั่วโลก — ขยายขอบเขตการเข้าถึงและปรับปรุงการสื่อสารของคุณ.