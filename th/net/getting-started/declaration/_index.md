---
title: ข้อกำหนดระดับความเชื่อถือ
type: docs
weight: 190
url: /th/net/declaration/
keywords:
- ระดับความเชื่อถือ
- การอนุญาตความเชื่อถือเต็มรูปแบบ
- ความเชื่อถือบางส่วน
- ความเชื่อถือระดับปานกลาง
- ความปลอดภัยการเข้าถึงโค้ด
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ระดับความเชื่อถือของ Code Access Security ที่ Aspose.Slides for .NET ต้องการ: ความเชื่อถือเต็มรูปแบบบน .NET Framework และไม่มีการตั้งค่าระดับความเชื่อถือบน .NET 6 และรุ่นต่อไป."
---
## **ภาพรวม**

ระดับความเชื่อถือของ Code Access Security (CAS) มีอยู่เฉพาะใน .NET Framework เท่านั้น บทความนี้อธิบายว่ามันหมายความว่าอย่างไรสำหรับ Aspose.Slides for .NET: ไลบรารีต้องการความเชื่อมั่นเต็มรูปแบบบน .NET Framework และบน .NET 6 และรุ่นต่อมาจะไม่มีระดับความเชื่อถือให้กำหนดค่า

## **.NET Framework**

Aspose.Slides ต้องการความเชื่อมั่นเต็มรูปแบบบน .NET Framework ไม่สามารถทำงานภายใต้ความเชื่อมั่นบางส่วน เช่น แอพพลิเคชัน ASP.NET ที่กำหนดค่าเป็น Medium Trust (`<trust level="Medium" />`): การสร้างวัตถุ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) จะล้มเหลวด้วย `SecurityException`.

Microsoft ไม่ได้มองว่า ASP.NET partial trust เป็นวิธีการแยกแอปพลิเคชันจากกันอีกต่อไปและแนะนำให้รันแอปพลิเคชันใน application pool แยกกันแทน ดูที่ [ASP.NET Partial Trust ไม่ได้รับประกันการแยกแอปพลิเคชัน](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 และรุ่นต่อไป**

Code access security ไม่พร้อมใช้งานบน .NET 6 และรุ่นต่อไป ดังนั้นไม่มีระดับความเชื่อถือให้กำหนด Aspose.Slides จะทำงานด้วยสิทธิ์ของบัญชีที่รันแอปพลิเคชันของคุณ เพื่อตั้งข้อจำกัดว่าระบบสามารถเข้าถึงอะไรได้บ้าง Microsoft แนะนำการใช้ขอบเขตของระบบปฏิบัติการ เช่น บัญชีผู้ใช้ คอนเทนเนอร์ หรือเครื่องเสมือน ดูที่ [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**ฉันสามารถใช้ Aspose.Slides กับผู้ให้บริการโฮสติ้งที่รันแอปพลิเคชัน ASP.NET ใน Medium Trust ได้หรือไม่?**

ไม่สามารถทำได้ใน Medium Trust บน .NET Framework แอปพลิเคชันที่ใช้ Aspose.Slides จะต้องรันด้วยความเชื่อมั่นเต็มรูปแบบ