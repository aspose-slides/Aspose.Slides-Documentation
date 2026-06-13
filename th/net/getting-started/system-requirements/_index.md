---
title: "ข้อกำหนดระบบ"
type: docs
weight: 60
url: /th/net/system-requirements/
keywords:
- "ข้อกำหนดระบบ"
- "ระบบปฏิบัติการ"
- "การติดตั้ง"
- "การพึ่งพา"
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- "งานนำเสนอ"
- .NET
- C#
- Aspose.Slides
description: "ค้นพบข้อกำหนดระบบของ Aspose.Slides for .NET. รับรองการสนับสนุน PowerPoint และ OpenDocument อย่างไม่มีรอยต่อบน Windows, Linux และ macOS."
---
## **บทนำ**

Aspose.Slides for .NET ไม่ต้องการให้ติดตั้ง Microsoft PowerPoint เนื่องจาก Aspose.Slides เป็นเอนจินการสร้างเอกสาร Microsoft PowerPoint การแปลง การจัดหน้าและการเรนเดอร์ที่เป็นอิสระ

## **ระบบปฏิบัติการที่รองรับ**

Aspose.Slides for .NET รองรับระบบปฏิบัติการ 32‑บิตหรือ 64‑บิตใด ๆ ที่มีการติดตั้ง .NET หรือ Mono framework รวมถึง (แต่ไม่จำกัดเพียง):

### **Windows**

- Microsoft Windows 2000 Server (x64, x86)
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, และอื่น ๆ)

### **Mac**

- Mac OS X

## **Framework ที่รองรับ**

Aspose.Slides for .NET รองรับ .NET และ Mono framework:

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

- การสนับสนุน MONO ในแพลตฟอร์ม MAC และ Linux

## **สภาพแวดล้อมการพัฒนา**

Aspose.Slides for .NET สามารถใช้พัฒนาแอปพลิเคชันในสภาพแวดล้อมการพัฒนาใด ๆ ที่มุ่งเป้าหมายไปที่แพลตฟอร์ม .NET แต่สภาพแวดล้อมเหล่านี้ได้รับการสนับสนุนโดยเฉพาะ:

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

ปัจจุบันมีบิลด์หลักของ Aspose.Slides สองรุ่น — Aspose.Slides.NET และ Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

นี่คือเวอร์ชันหลักของผลิตภัณฑ์ ใช้เอนจินกราฟิกมาตรฐานของ .NET
- บนแพลตฟอร์มที่ไม่ใช่ Windows คุณอาจต้องติดตั้งไลบรารี `libgdiplus` และการขึ้นต่อของมัน
- ก่อนเวอร์ชัน Aspose.Slides 25.3 สำหรับแพลตฟอร์มที่ไม่ใช่ Windows จำเป็นต้องใช้ DLL .NET Standard 2.0 จากแพ็คเกจ ZIP ของ Aspose.Slides
- ตั้งแต่เวอร์ชัน Aspose.Slides 25.3 สามารถใช้แพ็คเกจ NuGet ได้โดยตรงแม้บนระบบที่ไม่ใช่ Windows
- เมื่อทำงานบนระบบที่ไม่ใช่ Windows แอปพลิเคชันของคุณต้องรวมบรรทัดต่อไปนี้ที่การเริ่มต้น:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **ตั้งแต่เวอร์ชัน 25.3 คุณสามารถใช้แพ็คเกจนี้บนแพลตฟอร์มที่รองรับ .NET เช่น Linux aarch64 (ARM64).**

#### **แพ็คเกจเพิ่มเติมสำหรับ Linux Alpine**

เมื่อรัน Aspose.Slides for .NET ในคอนเทนเนอร์ Alpine Linux การติดตั้ง `libgdiplus` เพียงอย่างเดียวอาจไม่เพียงพอ คอนเทนเนอร์ Alpine มักไม่มีฟอนต์โดยค่าเริ่มต้น หากไม่มีฟอนต์ การทำเรนเดอร์หรือการแปลงอาจล้มเหลวด้วยข้อผิดพลาดที่คล้ายกับ:
```text
System.ArgumentException: Font '?' cannot be found
```
เพื่อใช้ Aspose.Slides บน Alpine ให้ติดตั้ง `libgdiplus` พร้อมกับอย่างน้อยหนึ่งแพ็คเกจฟอนต์

**ตัวเลือก 1: ฟอนต์ DejaVu**

ตัวเลือกที่แนะนำคือการติดตั้งแพ็คเกจ ttf-dejavu:
```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

แพ็คเกจ `ttf-dejavu` จะติดตั้งการขึ้นต่อที่เกี่ยวกับฟอนต์ที่จำเป็นโดยอัตโนมัติ เช่น `fontconfig`, `encodings`, `mkfontscale` และ `mkfontdir` ไม่จำเป็นต้องติดตั้งแพ็คเกจฟอนต์เพิ่มเติมสำหรับกรณีส่วนใหญ่

**ตัวเลือก 2: Microsoft Core Fonts**

หากงานนำเสนอของคุณใช้ฟอนต์ของ Microsoft เช่น Arial, Times New Roman, Courier New หรือ Verdana ให้ติดตั้ง Microsoft Core Fonts แทน:
```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

ใช้ตัวเลือกนี้เฉพาะเมื่องานนำเสนอที่กำลังประมวลผลต้องการฟอนต์ของ Microsoft เท่านั้น สำหรับสถานการณ์ส่วนใหญ่ การติดตั้ง `ttf-dejavu` จะง่ายกว่าและเชื่อถือได้มากขึ้น

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

นี่คือเวอร์ชันของ Aspose.Slides ที่ใช้เอนจินกราฟิกข้ามแพลตฟอร์มที่กำหนดโดยทีม Aspose.Slides บนแพลตฟอร์มที่ไม่ใช่ Windows อาจจำเป็นต้องใช้ไลบรารี `fontconfig`

**แพลตฟอร์มที่รองรับ**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**แพลตฟอร์มที่ไม่รองรับ**
- *Windows 11 ARM* (ARM64) — *ไม่อยู่ในขั้นตอนการพิจารณาในขณะนี้*

{{%  alert  title="Notes"  color="primary"  %}}  
สำหรับ Linux x64 จำเป็นต้องมี GLIBC 2.23+; สำหรับ Linux ARM64 จำเป็นต้องมี GLIBC 2.39+ ระบบเช่น CentOS 7 (GLIBC 2.14) ไม่ได้รับการสนับสนุน หากต้องการรัน Aspose.Slides บน CentOS 7 หรือระบบที่ไม่เข้ากันอื่น ๆ (เช่น Alpine) โปรดใช้แพ็คเกจมาตรฐาน: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**ฉันต้องการ Microsoft PowerPoint ติดตั้งเพื่อการแปลงและเรนเดอร์หรือไม่?**

ไม่จำเป็นต้องมี PowerPoint; Aspose.Slides เป็นเอนจินแบบสแตนด์อโลนสำหรับ [การสร้าง](/slides/th/net/create-presentation/), การแก้ไข, [การแปลง](/slides/th/net/convert-presentation/), และ [การเรนเดอร์](/slides/th/net/convert-powerpoint-to-png/) งานนำเสนอ

**ต้องการฟอนต์ใดสำหรับการเรนเดอร์ที่ถูกต้อง?**

ฟอนต์ที่ใช้ในงานนำเสนอหรือฟอนต์ทดแทนที่เหมาะสมต้องมีอยู่ในระบบปฏิบัติการ บน Linux และ macOS ให้ติดตั้งแพ็คเกจฟอนต์ทั่วไปเพื่อให้การเรนเดอร์สอดคล้องกัน

สำหรับคอนเทนเนอร์ Alpine Linux ให้ติดตั้งอย่างน้อยหนึ่งแพ็คเกจฟอนต์เพิ่มเติมนอกเหนือจาก `libgdiplus` การตั้งค่าขั้นต่ำที่แนะนำคือ `libgdiplus` พร้อมกับ `ttf-dejavu` หากต้องการฟอนต์ของ Microsoft เช่น Arial, Times New Roman, Courier New หรือ Verdana ให้ใช้ `msttcorefonts-installer` ร่วมกับ `fontconfig`

**ทำไมฟอนต์ที่กำหนดเองถึงแสดงเป็นแบบสำรองหรือข้อความหายบน Linux?**

หากไฟล์ฟอนต์มีรายการตารางชื่อที่ไม่สอดคล้องหรือเสียหาย สแตกการจับคู่ฟอนต์ของ Linux (FreeType/fontconfig) อาจเลือกบันทึกที่ไม่ถูกต้อง ทำให้ฟอนต์ไม่สามารถระบุได้ การใช้เวอร์ชันฟอนต์ที่แก้ไขตารางชื่อหรือการติดตั้งฟอนต์แทนที่สอดคล้องจะแก้ไขปัญหานี้