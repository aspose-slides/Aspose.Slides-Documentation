---
title: ข้อกำหนดระบบ
type: docs
weight: 60
url: /th/net/system-requirements/
keywords:
- ข้อกำหนดระบบ
- ระบบปฏิบัติการ
- การติดตั้ง
- การพึ่งพา
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบข้อกำหนดระบบของ Aspose.Slides for .NET. รับประกันการสนับสนุน PowerPoint และ OpenDocument อย่างราบรื่นบน Windows, Linux และ macOS."
---
## **บทนำ**

Aspose.Slides for .NET ไม่จำเป็นต้องติดตั้ง Microsoft PowerPoint เนื่องจาก Aspose.Slides เป็นเอนจินอิสระสำหรับการสร้างเอกสาร Microsoft PowerPoint, การแปลง, การจัดหน้า, และการเรนเดอร์

## **ระบบปฏิบัติการที่สนับสนุน**

Aspose.Slides for .NET รองรับระบบปฏิบัติการ 32‑bit หรือ 64‑bit ใด ๆ ที่มี .NET หรือ Mono framework ติดตั้งอยู่ รวมถึง (แต่ไม่จำกัดเพียง)

### **Windows**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, และอื่นๆ)

### **Mac**

- Mac OS X

## **เฟรมเวิร์กที่สนับสนุน**

Aspose.Slides for .NET สนับสนุนเฟรมเวิร์ก .NET และ Mono:

### **.NET Frameworks**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop support (COM, C++, VBScript)

### **Mono Framework**

- MONO Support in MAC and Linux platforms

## **สภาพแวดล้อมการพัฒนา**

Aspose.Slides for .NET สามารถใช้พัฒนาแอปพลิเคชันในสภาพแวดล้อมการพัฒนาที่เป้าหมายคือแพลตฟอร์ม .NET แต่สภาพแวดล้อมต่อไปนี้ได้รับการสนับสนุนโดยเฉพาะ:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **บิลด์หลักของ Aspose.Slides**

ปัจจุบันมีบิลด์หลักสองรุ่นของ Aspose.Slides — Aspose.Slides.NET และ Aspose.Slides.NET6.CrossPlatform

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

นี่เป็นเวอร์ชันหลักของผลิตภัณฑ์ ใช้เอนจินกราฟิกมาตรฐานของ .NET  
- ในแพลตฟอร์มที่ไม่ใช่ Windows คุณอาจต้องติดตั้งไลบรารี `libgdiplus` พร้อมกับ dependencies ของมัน  
- ก่อนเวอร์ชัน Aspose.Slides 25.3 สำหรับแพลตฟอร์มที่ไม่ใช่ Windows จำเป็นต้องใช้ DLL .NET Standard 2.0 จากแพ็กเกจ ZIP ของ Aspose.Slides  
- ตั้งแต่เวอร์ชัน Aspose.Slides 25.3 สามารถใช้แพ็กเกจ NuGet ได้โดยตรงแม้บนระบบที่ไม่ใช่ Windows  
- เมื่อทำงานบนระบบที่ไม่ใช่ Windows แอปพลิเคชันของคุณต้องใส่บรรทัดต่อไปนี้ที่ขั้นตอนเริ่มต้น:  
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```  
- **ตั้งแต่เวอร์ชัน 25.3 คุณสามารถใช้แพ็กเกจนี้บนแพลตฟอร์มที่รองรับ .NET เช่น Linux aarch64 (ARM64)**  

#### **แพ็กเกจเพิ่มเติมสำหรับ Linux Alpine**

เมื่อรัน Aspose.Slides for .NET ในคอนเทนเนอร์ Alpine Linux การติดตั้ง `libgdiplus` เพียงอย่างเดียวอาจไม่เพียงพอ คอนเทนเนอร์ Alpine มักไม่มีฟอนต์ติดตั้งมาดีฟอลต์ หากไม่มีฟอนต์ การเรนเดอร์หรือการแปลงอาจล้มเหลวด้วยข้อผิดพลาดคล้ายกับ:

```text
System.ArgumentException: Font '?' cannot be found
```

เพื่อใช้ Aspose.Slides บน Alpine ให้ติดตั้ง `libgdiplus` ร่วมกับอย่างน้อยหนึ่งแพ็กเกจฟอนต์

**ตัวเลือก 1: ฟอนต์ DejaVu**

แนะนำให้ติดตั้งแพ็กเกจ ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

แพ็กเกจ `ttf-dejavu` จะติดตั้ง dependencies ที่เกี่ยวข้องกับฟอนต์โดยอัตโนมัติ เช่น `fontconfig`, `encodings`, `mkfontscale`, และ `mkfontdir` ไม่จำเป็นต้องติดตั้งแพ็กเกจฟอนต์เพิ่มเติมสำหรับกรณีส่วนใหญ่

**ตัวเลือก 2: ฟอนต์ Microsoft Core**

หากงานพรีเซนเทชันของคุณใช้ฟอนต์ของ Microsoft เช่น Arial, Times New Roman, Courier New, หรือ Verdana ให้ติดตั้ง Microsoft Core Fonts แทน:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

ใช้ตัวเลือกนี้เฉพาะเมื่อพรีเซนเทชันที่ต้องประมวลผลต้องการฟอนต์ของ Microsoft สำหรับสถานการณ์ส่วนใหญ่ การติดตั้ง `ttf-dejavu` จะง่ายกว่าและเชื่อถือได้กว่า

**ความต้องการเพิ่มเติมสำหรับการทำงานระดับสากล**

เพื่อเปิดใช้งานการสนับสนุนระดับสากลอย่างถูกต้องบน Alpine ให้ติดตั้งแพ็กเกจ `icu-libs` และปิดโหมด invariant:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

นี่เป็นเวอร์ชันของ Aspose.Slides ที่ใช้เอนจินกราฟิกแบบข้ามแพลตฟอร์มที่พัฒนาขึ้นโดยทีม Aspose.Slides  
บนแพลตฟอร์มที่ไม่ใช่ Windows อาจต้องใช้ไลบรารี `fontconfig`

**แพลตฟอร์มที่รองรับ**  
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)  
- *macOS*: x86_64, ARM64 (aarch64)

**แพลตฟอร์มที่ไม่รองรับ**  
- *Windows 11 ARM* (ARM64) — *ไม่อยู่ในการพิจารณาในขณะนี้*

{{%  alert  title="หมายเหตุ"  color="info"  %}}  
สำหรับ Linux x64 จำเป็นต้องมี GLIBC 2.23+; สำหรับ Linux ARM64 จำเป็นต้องมี GLIBC 2.39+ ระบบเช่น CentOS 7 (GLIBC 2.14) ไม่ได้รับการสนับสนุน หากคุณต้องการรัน Aspose.Slides บน CentOS 7 หรือระบบที่ไม่เข้ากันอื่น ๆ (เช่น Alpine) โปรดใช้แพ็กเกจมาตรฐาน: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET)  
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ฉันต้องติดตั้ง Microsoft PowerPoint เพื่อทำการแปลงและเรนเดอร์หรือไม่?

ไม่จำเป็น PowerPoint ไม่ต้องการ; Aspose.Slides เป็นเอนจินสแตนด์อโลนสำหรับการ[สร้าง](/slides/th/net/create-presentation/), การแก้ไข, การ[แปลง](/slides/th/net/convert-presentation/), และการ[เรนเดอร์](/slides/th/net/convert-powerpoint-to-png/) พรีเซนเทชัน

### ต้องการฟอนต์อะไรเพื่อการเรนเดอร์ที่ถูกต้อง?

ฟอนต์ที่ใช้ในพรีเซนเทชันหรือฟอนต์ทดแทนที่เหมาะสมต้องมีอยู่ในระบบปฏิบัติการบน Linux และ macOS ควรติดตั้งแพ็กเกจฟอนต์ทั่วไปเพื่อให้การเรนเดอร์สอดคล้องกัน  

สำหรับคอนเทนเนอร์ Alpine Linux ให้ติดตั้งอย่างน้อยหนึ่งแพ็กเกจฟอนต์ร่วมกับ `libgdiplus` การตั้งค่าน้อยที่สุดที่แนะนำคือ `libgdiplus` พร้อม `ttf-dejavu` หากต้องการฟอนต์ของ Microsoft เช่น Arial, Times New Roman, Courier New หรือ Verdana ให้ติดตั้ง `msttcorefonts-installer` พร้อมกับ `fontconfig`

### ทำไมฟอนต์ที่กำหนดเองถึงแสดงเป็นฟอนต์สำรองหรือข้อความหายบน Linux?

หากไฟล์ฟอนต์มีรายการ name‑table ที่ไม่สอดคล้องหรือเสียหาย สแตกการจับคู่ฟอนต์ของ Linux (FreeType/fontconfig) อาจเลือกบันทึกที่ไม่ถูกต้อง ส่งผลให้ฟอนต์ไม่สามารถแก้ไขได้ การใช้เวอร์ชันฟอนต์ที่มีการแก้ไข name‑table หรือการติดตั้งฟอนต์ทดแทนที่สอดคล้องจะช่วยแก้ปัญหาได้