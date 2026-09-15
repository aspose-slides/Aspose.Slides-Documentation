---
title: ตัวแปลการนำเสนอด้วย AI
linktitle: ตัวแปลด้วย AI
type: docs
weight: 20
url: /th/net/ai/translator/
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
- .NET
- C#
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ .NET. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นขณะคงการจัดวางไว้—เร็วและเป็นมิตรต่อผู้พัฒนา. ลองใช้งาน."
---
## **แนะนำ**

Aspose.Slides เป็น API ที่มีประสิทธิภาพสำหรับการจัดการการนำเสนอ PowerPoint ด้วยโปรแกรม นอกจากการสร้าง, แก้ไขและแปลงสไลด์แล้ว ยังมีคุณลักษณะที่ขับเคลื่อนด้วย AI เช่น [API การแปลงานนำเสนอ](https://reference.aspose.com/slides/th/net/aspose.slides.ai/) สำหรับเนื้อหาสไลด์หลายภาษา

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้รวมความสามารถ AI ในตัว แต่ทำการรวมกับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ฟังก์ชันนี้เปิดเผยผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/net/aspose.slides.ai/slidesaiagent) ซึ่งใช้การทำงานของอินเทอร์เฟซ [IAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/iaiwebclient/) เพื่อสื่อสารกับบริการ AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) ที่มาพร้อมในตัวเพื่อเชื่อมต่อกับ API ของ OpenAI หรือดำเนินการสร้าง [IAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/iaiwebclient/) ของคุณเองเพื่อใช้ผู้ให้บริการ AI หรือโมเดลภาษาที่แตกต่างกัน

Aspose.Slides จัดการการสื่อสาร, วิเคราะห์การตอบกลับจาก AI, และแทรกเนื้อหาที่แปลอย่างฉลาดโดยคงการจัดวางและการฟอร์แมตของสไลด์ต้นฉบับไว้

{{% alert color="info" title="หมายเหตุ" %}}
โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องเสียค่าใช้จ่าย ดังนั้นคุณจะต้องสร้างบัญชีและใส่คีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/)
{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราจะแปลการนำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) ที่มาพร้อมในตัวพร้อมกับ [โมเดล](https://platform.openai.com/docs/models) ของ OpenAI ที่ระบุ

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// โหลดการนำเสนอเพื่อแปล.
using var presentation = new Presentation("sample.pptx");

// สร้างไคลเอ็นต์ AI ด้วย OpenAIWebClient โดยระบุโมเดลและคีย์ API ของคุณ.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// เริ่มต้น SlidesAIAgent ด้วยไคลเอ็นต์ AI.
var aiAgent = new SlidesAIAgent(aiWebClient);

// แปลการนำเสนอเป็นภาษาญี่ปุ่น.
await aiAgent.TranslateAsync(presentation, "japanese");

// บันทึกการนำเสนอที่แปลเป็น PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

ตามค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/) ที่มาพร้อมในตัวจะสร้างและจัดการอินสแตนซ์ [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ภายในของตนเองโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ด้วยตนเอง เช่น เมื่อใช้ [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) เพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดีกว่า คุณสามารถให้ `HttpClient` ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaiwebclient/)

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// ใช้ HttpClient ที่คุณจัดการเอง - ตัวอย่างเช่น ที่สร้างโดย IHttpClientFactory
// ฉีดผ่านการทำ Dependency Injection.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides มักถูกใช้ในสภาพแวดล้อมแบบ synchronous เพื่อสนับสนุนสิ่งนี้ คลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/net/aspose.slides.ai/slidesaiagent/) มีทั้งเมธอด synchronous และ asynchronous ทำให้คุณเลือกวิธีที่เหมาะกับกระบวนการทำงานของแอปพลิเคชันของคุณได้ดีที่สุด

### **ตัวอย่าง Azure OpenAI**

Aspose.Slides สำหรับ .NET รองรับผู้ให้บริการที่เข้ากันได้กับ OpenAI รวมถึง Azure OpenAI คุณสามารถกำหนดค่าแปลภาษาให้ใช้การปรับใช้ Azure ของคุณเองด้วย [OpenAICompatibleWebClient](https://reference.aspose.com/slides/th/net/aspose.slides.ai/openaicompatiblewebclient/)

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

โค้ดตัวอย่างนี้แสดงการแปลการนำเสนอด้วย endpoint ของ Azure OpenAI ของคุณ แทนค่าตัวแทนด้วยชื่อการปรับใช้, คีย์ API และ URL ของ endpoint ของคุณ

## **ประโยชน์หลัก**

Aspose.Slides [API การแปลงานนำเสนอ](https://reference.aspose.com/slides/th/net/aspose.slides.ai/) ให้โซลูชันขับเคลื่อนด้วย AI สำหรับการนำเสนอ PowerPoint หลายภาษา โดยอัตโนมัติการแปลพร้อมคงการจัดวางและการออกแบบไว้ ช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำงานแบบมือ ไม่ว่าคุณจะเป็นนักพัฒนา, ผู้สอน, หรือผู้เชี่ยวชาญด้านธุรกิจ API นี้ช่วยให้คุณสร้างการนำเสนอที่ดึงดูดและปรับให้เป็นท้องถิ่นสำหรับผู้ชมทั่วโลก - ขยายขอบเขตการเข้าถึงและปรับปรุงการสื่อสาร.