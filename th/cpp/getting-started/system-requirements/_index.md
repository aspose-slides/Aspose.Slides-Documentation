---
title: ความต้องการระบบ
type: docs
weight: 80
url: /th/cpp/system-requirements/
keywords:
- ความต้องการระบบ
- ระบบปฏิบัติการ
- การติดตั้ง
- การพึ่งพา
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบความต้องการระบบของ Aspose.Slides for C++ เพื่อรับรองการสนับสนุน PowerPoint และ OpenDocument อย่างราบรื่นบน Windows, Linux, และ macOS."
---
## **บทนำ**

Aspose.Slides ไม่จำเป็นต้องติดตั้ง Microsoft PowerPoint เนื่องจาก Aspose.Slides เป็นเอนจินอิสระสำหรับการสร้างเอกสาร Microsoft PowerPoint, การแปลง, การจัดหน้า, และการเรนเดอร์

## **ระบบปฏิบัติการที่รองรับ**
Aspose.Slides for C++ เป็นไลบรารีเนทีฟสำหรับ C++  Aspose.Slides for C++ รองรับระบบปฏิบัติการและแพลตฟอร์ม 64‑bit และ 32‑bit ต่อไปนี้

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- OS Ubuntu 16.04 หรือใหม่กว่า
- CentOS 8 หรือใหม่กว่า
- Fedora 24 หรือใหม่กว่า
- และ Linux x86_64 อื่น ๆ ที่ใช้ glibc 2.23 หรือใหม่กว่า

### **macOS**
- macOS Monterey 12.1 หรือใหม่กว่า

## **สภาพแวดล้อมการพัฒนา**
คุณสามารถใช้ Aspose.Slides for C++ ในการพัฒนาแอปพลิเคชันสำหรับ Windows, Linux หรือ macOS

### **Windows**
- Microsoft Visual Studio 2017 หรือใหม่กว่า
- CMake 3.18 หรือใหม่กว่า

### **Linux**
- Clang 3.9 หรือใหม่กว่า
- GCC 6.1 หรือใหม่กว่า
- CMake 3.18 หรือใหม่กว่า

### **macOS**
- Xcode 13.4 หรือใหม่กว่า

## **FAQ**

**ฉันต้องติดตั้ง Microsoft PowerPoint เพื่อทำการแปลงและเรนเดอร์หรือไม่?**

ไม่จำเป็น PowerPoint ไม่ต้องการ; Aspose.Slides เป็นเอนจินแบบสแตนด์อโลนสำหรับ [creating](/slides/th/cpp/create-presentation/), การแก้ไข, [converting](/slides/th/cpp/convert-presentation/), และ [rendering](/slides/th/cpp/convert-powerpoint-to-png/) พรีเซนเทชัน

**ต้องการแบบอักษรใดบ้างเพื่อให้การเรนเดอร์ถูกต้อง?**

ในการใช้งานจริง แบบอักษรที่ใช้ในพรีเซนเทชันหรือ [substitutes](/slides/th/cpp/font-substitution/) ที่เหมาะสมต้องพร้อมใช้งาน เพื่อให้การเรนเดอร์สอดคล้องกันบน Linux/macOS ควรติดตั้งแพคเกจแบบอักษรทั่วไป

**ทำไมแบบอักษรที่กำหนดเองจึงแสดงเป็นฟอลแบ็กหรือข้อความหายไปบน Linux?**

หากไฟล์แบบอักษรมีรายการ name‑table ที่ไม่สอดคล้องหรือเสียหาย สแตกการจับคู่แบบอักษรของ Linux (FreeType/fontconfig) อาจเลือกบันทึกที่ไม่ถูกต้อง ทำให้แบบอักษรไม่สามารถระบุได้ การใช้เวอร์ชันแบบอักษรที่แก้ไข name‑table ให้ถูกต้องหรือการติดตั้งแบบอักษรแทนที่ที่สอดคล้องจะช่วยแก้ปัญหาได้