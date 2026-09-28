---
title: แพคเกจข้ามแพลตฟอร์มสำหรับ .NET 6 และรุ่นถัดไป
linktitle: แพคเกจข้ามแพลตฟอร์ม
type: docs
weight: 235
url: /th/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- ข้ามแพลตฟอร์ม
- การสนับสนุน .NET 6
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้ว่าเมื่อใดควรใช้แพคเกจ Aspose.Slides.NET6.CrossPlatform: ทำไมจึงมีอยู่, แพลตฟอร์มที่ทำงานได้, และสิ่งที่ต้องการบน Linux แทน libgdiplus."
---
## **บทนำ**

Aspose.Slides for .NET เผยแพร่เป็นแพ็คเกจ NuGet สองตัว [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) วาดสไลด์ผ่านไลบรารี System.Drawing.Common ของ Microsoft. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) วาดสไลด์ด้วยเครื่องมือกราฟิกของตนเองแทน. บทความนี้อธิบายเหตุผลที่มีแพ็คเกจที่สอง, ที่ที่ทำงาน, สิ่งที่ต้องการบน Linux, และวิธีที่ทำงานร่วมกับ System.Drawing.Common ในโครงการเดียว.

## **ทำไมต้องมีแพ็คเกจแยกต่างหาก**

ตั้งแต่ .NET 6 เป็นต้นไป Microsoft รองรับ System.Drawing.Common [เฉพาะบน Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). ดังนั้นบน Linux Aspose.Slides.NET จำเป็นต้องใช้สวิตช์ `System.Drawing.EnableUnixSupport` ร่วมกับไลบรารี `libgdiplus` และจะล้มเหลวหากโครงการอ้างอิง System.Drawing.Common เวอร์ชัน 7 หรือสูงกว่า. [System Requirements](/slides/th/net/system-requirements/) อธิบายเงื่อนไขเหล่านี้.

Aspose.Slides.NET6.CrossPlatform ไม่ใช้ System.Drawing.Common หรือ `libgdiplus`. เครื่องมือกราฟิกของมันเป็นไลบรารีเนทีฟที่แพ็คเกจใส่ไว้ในแต่ละการสร้างสำหรับแต่ละแพลตฟอร์มที่รองรับ. ทั้งสองแพ็คเกจให้เนมสเปซและคลาส Aspose.Slides ที่เหมือนกัน, ดังนั้นการสลับจากหนึ่งไปยังอีกอันหนึ่งจะเปลี่ยนเฉพาะการอ้างอิงแพ็คเกจ, ไม่ใช่โค้ดของคุณ.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| กราฟิก | System.Drawing.Common | Native graphics engine included in the package |
| เฟรมเวิร์กเป้าหมาย | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| ความต้องการของ Linux | `libgdiplus` and the `System.Drawing.EnableUnixSupport` switch | `fontconfig` |
| Alpine Linux | Supported | Not supported |

## **แพลตฟอร์มที่รองรับ**

Aspose.Slides.NET6.CrossPlatform ทำงานกับ .NET 6 และรุ่นต่อ ๆ ไปบนแพลตฟอร์มต่อไปนี้:

- **Windows**: x86 และ x64. ไลบรารีเนทีฟใช้ Microsoft Visual C++ runtime; ดู [System Requirements](/slides/th/net/system-requirements/).
- **Linux**: x64 พร้อม glibc 2.23 หรือสูงกว่า, และ ARM64 พร้อม glibc 2.39 หรือสูงกว่า.
- **macOS**: x64 (Intel) และ ARM64 (Apple silicon).

มันไม่ทำงานบน Windows ARM64, บน Alpine Linux หรือดิสโทรอื่นที่สร้างด้วย musl แทน glibc, หรือบนดิสโทรที่ใช้ glibc รุ่นเก่าเช่น CentOS 7. ใช้ Aspose.Slides.NET บนระบบเหล่านั้น.

## **การติดตั้งบน Linux**

บน Linux แพ็คเกจต้องการไลบรารี `fontconfig` แต่ไม่ต้องการ `libgdiplus`. บน Debian และ Ubuntu ให้ติดตั้ง `fontconfig` แล้วเพิ่มแพ็คเกจลงในโครงการของคุณ:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

บน Debian และ Ubuntu, `libfontconfig1` จะติดตั้งฟอนต์ DejaVu ด้วย, ดังนั้นข้อความจะแสดงผลโดยไม่ต้องติดตั้งฟอนต์อื่น. หากไม่มี `fontconfig`, การสร้าง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) จะล้มเหลวด้วย `TypeInitializationException` ที่มี `DllNotFoundException` ระบุว่าไม่สามารถเปิด `libfontconfig.so.1`. [System Requirements](/slides/th/net/system-requirements/) มีโปรแกรมสั้น ๆ เพื่อตรวจสอบการตั้งค่า.

## **โฮสต์คลาวด์และคอนเทนเนอร์**

เนื่องจากไม่ต้องการ `libgdiplus`, Aspose.Slides.NET6.CrossPlatform เป็นแพ็คเกจที่ควรใช้บนโฮสต์ Linux ที่ไม่สามารถติดตั้ง `libgdiplus`. อย่างไรก็ตามยังต้องการ `fontconfig` และฟอนต์, ซึ่งอิมเมจฐานที่มีขนาดขั้นต่ำอาจไม่มี. ตัวอย่างเช่นอิมเมจฐาน AWS Lambda สำหรับ .NET 8 ไม่มีทั้งสองอย่าง. ในอิมเมจคอนเทนเนอร์ที่สร้างจากอิมเมจนั้น, รัน `dnf install -y fontconfig` ซึ่งจะติดตั้งฟอนต์ Noto Sans ด้วย.

สำหรับคู่มือของแพลตฟอร์มคลาวด์เฉพาะ, ดู [Aspose.Slides on Cloud Platforms](/slides/th/net/slides-on-cloud-platforms/).

## **การใช้ System.Drawing.Common ในโครงการเดียวกัน (CS0433)**

โครงการที่ใช้ Aspose.Slides.NET6.CrossPlatform สามารถอ้างอิง System.Drawing.Common ได้เช่นกัน, ไม่ว่าจะโดยตรงหรือผ่านแพ็คเกจอื่น. เวอร์ชันปัจจุบันของ Aspose.Slides ไม่ได้เปิดเผยประเภทสาธารณะใด ๆ ในเนมสเปซ `System`, ดังนั้นไลบรารีทั้งสองจึงไม่ขัดแย้ง, และคุณสามารถนำเข้าเนมสเปซ `Aspose.Slides` และ `System.Drawing` ในไฟล์เดียวกันได้.

หากคอมไพเลอร์รายงานข้อผิดพลาด CS0433 เนื่องจากประเภทเช่น `Image` หรือ `Graphics` มีอยู่ใน Aspose.Slides และ System.Drawing.Common ทั้งสอง, โครงการของคุณอาจใช้ Aspose.Slides รุ่นเก่า. ให้อัปเดตแพ็คเกจเป็นรุ่นล่าสุด. Aspose.Slides ส่งคืนภาพที่เรนเดอร์เป็นอ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) ซึ่งอธิบายใน [Modern API](/slides/th/net/modern-api/).

## **คำถามที่พบบ่อย**

**ฉันต้องเปลี่ยนโค้ดของฉันหรือไม่เมื่อสลับจาก Aspose.Slides.NET ไปยัง Aspose.Slides.NET6.CrossPlatform?**

ไม่. ทั้งสองแพ็คเกจให้เนมสเปซและคลาส Aspose.Slides ที่เหมือนกัน, ดังนั้นคุณเพียงเปลี่ยนการอ้างอิงแพ็คเกจ. Aspose.Slides.NET6.CrossPlatform ไม่ต้องการสวิตช์ `System.Drawing.EnableUnixSupport`. เพิ่มเพียงหนึ่งในสองแพ็คเกจลงในโครงการเท่านั้น.

**ฉันสามารถใช้ Aspose.Slides.NET6.CrossPlatform ในโครงการ .NET Framework ได้หรือไม่?**

ไม่. แพ็คเกจนี้รองรับเฉพาะ .NET 6 และรุ่นต่อ ๆ ไป. สำหรับ .NET Framework 4.6.2 และรุ่นต่อ ๆ ไป ให้ใช้ Aspose.Slides.NET.