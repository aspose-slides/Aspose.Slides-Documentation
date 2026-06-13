---
title: การสนับสนุน .NET 6
type: docs
weight: 235
url: /th/net/net6/
keywords:
- การสนับสนุน .NET 6
- โซลูชันคลาวด์
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "กำหนดค่า Aspose.Slides สำหรับ .NET 6 เพื่อสร้าง แก้ไข และแปลงงานนำเสนอ PowerPoint PPT, PPTX และ ODP ในแอปพลิเคชัน C# ที่ทันสมัยและข้ามแพลตฟอร์ม"
---
## **บทนำ**

เริ่มต้นตั้งแต่ [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) การสนับสนุน .NET6 ได้ถูกนำมาใช้ ความพิเศษของการสนับสนุนนี้คือ .NET6 ไม่ได้สนับสนุน System.Drawing.Common บน Linux อีกต่อไป ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) และ Slides ได้ทำการดำเนินการย่อยกราฟิกนี้เองในรูปแบบคอมโพเนนต์ C++  

Aspose.Slides สำหรับ .NET ตอนนี้ทำงานได้โดยไม่ต้องพึ่งพา GDI/libgdiplus บน:
* Windows
* Linux

*MacOS* ยังอยู่ในระหว่างการพัฒนา

## **การใช้ Slides for .NET 6 บน AWS และ Azure**

.NET6 เป็นเวอร์ชันที่แนะนำสำหรับ Aspose.Slides ที่ใช้งานบนคลาวด์ (AWS, Azure หรือโซลูชันคลาวด์อื่น)

ก่อนหน้านี้เมื่อใช้ Aspose.Slides บนโฮสต์ Linux จำเป็นต้องติดตั้ง dependency เพิ่มเติม (libgdiplus) ซึ่งมักไม่สะดวกหรือเป็นไปได้ยาก (เช่นเมื่อใช้ [AWS Lambda](https://aws.amazon.com/lambda)) ด้วย Slides for .NET6 dependency เหล่านั้นไม่จำเป็นต้องใช้อีกต่อไป ทำให้การปรับใช้ง่ายขึ้นมาก

อีกประเด็นหนึ่งคือปัญหาที่เกิดขึ้นเมื่อ Aspose.Slides ถูกใช้บนโซลูชันคลาวด์ที่รันบนโฮสต์ Windows ตัวอย่างเช่น [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) มีข้อจำกัดในการทำงานและทำให้เกิดปัญหาระหว่างการส่งออก PDF (ดู [this](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)) การใช้ Aspose.Slides for .NET6 จะแก้ปัญหานี้ได้

## **การใช้แพ็คเกจ System.Drawing.Common และคลาสของ Slides for .NET 6 (CS0433: The Type Exists in Both Slides and System.Drawing.Common Error)**

บางครั้งทั้ง System.Drawing และ Slides for .NET6 จำเป็นต้องใช้ร่วมกันในโปรเจกต์ (เช่นเมื่อโปรเจกต์ .NET6 ขึ้นกับแพ็คเกจอื่นที่ต่อมาอิงกับ System.Drawing) สิ่งนี้อาจทำให้เกิดข้อผิดพลาดเช่น:

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

ในกรณีนี้คุณสามารถใช้ [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) สำหรับ Aspose.Slides (เวอร์ชันที่ต่ำกว่า 24.8):
1) เลือก assembly ของ Aspose.Slides จาก dependencies ของโปรเจกต์แล้วคลิก **Properties**.  
   ![คุณสมบัติของแพ็คเกจ Aspose Slides](package_properties.png)
2) ตั้งค่า alias (เช่น "Slides").  
   ![การตั้งค่า alias ของ Aspose Slides](set_alias.png)

ตอนนี้ประเภทจาก System.Drawing.Common จะถูกใช้เป็นค่าเริ่มต้น ควรระบุ alias ของ assembly ภายนอกที่จุดที่ต้องการใช้ประเภทของ Aspose.Slides

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

ตัวอย่างเต็ม:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

ตั้งแต่เวอร์ชัน 24.8 API สาธารณะที่ไม่สนับสนุนและอิงกับ System.Drawing ได้ถูกลบออกแล้ว สำหรับตัวอย่างโค้ดด้านบน คุณสามารถดึงรูปสไลด์ได้ดังต่อไปนี้

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
API ใหม่มีรายละเอียดเพิ่มเติมใน [Modern API](/slides/th/net/modern-api/).