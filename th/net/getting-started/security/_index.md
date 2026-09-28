---
title: ความปลอดภัย
type: docs
weight: 160
url: /th/net/security/
keywords:
- ความปลอดภัย
- การพึ่งพา
- ส่วนประกอบของบุคคลที่สาม
- NuGet
- การสแกนช่องโหว่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "รีวิววิธีที่ Aspose.Slides for .NET ประมวลผลการนำเสนอ, แพคเกจ NuGet ที่มันพึ่งพาในแต่ละกรอบเป้าหมาย, และส่วนประกอบของบุคคลที่สามที่รวมอยู่"
---
## **ความปลอดภัยใน Aspose.Slides**

* Aspose.Slides for .NET ใช้เพื่อจัดการพรีเซนเทชันและแปลงเป็นรูปแบบอื่น ๆ ไม่ได้ทำการรันสคริปต์ในพรีเซนเทชัน Aspose.Slides จะทำการวิเคราะห์โครงสร้างของพรีเซนเทชันและให้โค้ดของผู้ใช้ปลายสุดสามารถจัดการโมเดลวัตถุได้อย่างสะดวก
* Aspose.Slides ทำงานเป็นไลบรารีที่วิเคราะห์และตีความเอกสารโดยไม่ดำเนินการรหัสจากระยะไกล ทุกผลิตภัณฑ์ของ Aspose ทำงานบนเครื่องของคุณ ไม่ได้ส่งข้อมูลใด ๆ ไปยัง Aspose ข้อยกเว้นเดียวคือ [metered license](https://purchase.aspose.com/faqs/licensing/metered): หากคุณใช้จะมีการประมวลผลเฉพาะข้อมูลการใช้งาน API ของคุณ
* ส่วนประกอบของ Aspose ทำงานในบริบทผู้ใช้เดียวกับแอปพลิเคชันปกติ ดังนั้นส่วนประกอบของ Aspose จึงไม่เป็นความเสี่ยงต่อทรัพยากรสำคัญของระบบ นอกจากนี้ เมื่อส่วนประกอบของ Aspose เปิดเอกสาร แมโครจะไม่ถูกรันโดยอัตโนมัติ
* ความเสี่ยงที่มีอยู่โดยธรรมชาติหรือที่เกี่ยวข้องกับชุด Microsoft Office ไม่ได้ใช้กับส่วนประกอบของ Aspose ดังนั้นผลิตภัณฑ์ของ Aspose มีความปลอดภัยสูง

## **การพึ่งพา NuGet**

Aspose.Slides for .NET พึ่งพาแพคเกจที่ Microsoft เผยแพร่บน NuGet การพึ่งพาแตกต่างตามแพคเกจและกรอบเป้าหมาย:

| แพคเกจ | กรอบเป้าหมาย | การพึ่งพา |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

ส่วน **Dependencies** ของหน้า [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) และ [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) บน NuGet แสดงรายการเวอร์ชันขั้นต่ำของแต่ละการพึ่งพาสำหรับแต่ละเวอร์ชัน

เมื่อคุณเพิ่ม Aspose.Slides ไปยังโปรเจกต์ NuGet จะเรียกคืนการพึ่งพาของแพคเกจเหล่านั้นด้วย เพื่อแสดงรายการทุกแพคเกจที่โปรเจกต์ของคุณเรียกคืน รวมถึงการพึ่งพาแบบผ่านขั้นตอน ให้เรียกใช้คำสั่งนี้ในโฟลเดอร์โปรเจกต์:

```bash
dotnet list package --include-transitive
```

เพื่อตรวจสอบชุดแพคเกจเดียวกันกับช่องโหว่ที่ทราบ ให้เรียกใช้:

```bash
dotnet list package --vulnerable --include-transitive
```

สำหรับวิธีอื่น ๆ ในการตรวจสอบความปลอดภัยของแพคเกจ NuGet ดูที่ [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **ส่วนประกอบของบุคคลที่สาม**

Aspose.Slides มีโค้ดจากส่วนประกอบโอเพนซอร์สของบุคคลที่สาม พวกมันเป็นส่วนหนึ่งของผลิตภัณฑ์ ไม่ใช่แพคเกจ NuGet แยกต่างหาก ดังนั้นเครื่องมือที่อ่านการพึ่งพา NuGet อย่างเดียวจะไม่แสดงรายการเหล่านี้ ทั้งสองแพคเกจมีไฟล์ *thirdpartylicenses.Aspose.Slides.for.NET.pdf* ซึ่งรายการส่วนประกอบและใบอนุญาตของพวกมัน:

| ส่วนประกอบ | ใบอนุญาตที่ระบุในประกาศ |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **คำถามที่พบบ่อย**

**ระบบใดที่ใช้ในการตรวจสอบช่องโหว่ในโค้ดของ Aspose?**

เราใช้การวิเคราะห์โค้ดแบบคงที่สำหรับแต่ละรุ่นของ Aspose.Slides เราสามารถให้รายงานความปลอดภัยที่พิสูจน์ว่าโค้ดของ Aspose.Slides ผ่าน OWASP Top 10

**Aspose.Slides ใช้แพคเกจภายนอกหรือไม่?**

ใช่ มันพึ่งพาแพคเกจ NuGet ของ Microsoft ที่ระบุใน [NuGet Dependencies](#nuget-dependencies) และรวมส่วนประกอบของบุคคลที่สามที่ระบุใน [Third-Party Components](#third-party-components) รวมทั้งสองอย่างในการตรวจสอบความปลอดภัยของคุณ และใช้ `dotnet list package --vulnerable --include-transitive` เพื่อตรวจสอบแพคเกจ NuGet ที่โปรเจกต์ของคุณเรียกคืน