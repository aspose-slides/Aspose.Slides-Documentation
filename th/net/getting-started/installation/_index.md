---
title: การติดตั้ง
type: docs
weight: 70
url: /th/net/installation/
keywords:
- ติดตั้ง Aspose.Slides
- ดาวน์โหลด Aspose.Slides
- ใช้ Aspose.Slides
- การติดตั้ง Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ติดตั้ง Aspose.Slides for .NET จาก NuGet บน Windows, Linux, และ macOS: เลือกระหว่างสองแพ็กเกจ, เพิ่มหนึ่งแพ็กเกจด้วย .NET CLI หรือ Visual Studio, และติดตั้งข้อกำหนดล่วงหน้าของ Linux."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีเพิ่ม Aspose.Slides for .NET ลงในโครงการบน Windows, Linux และ macOS. Aspose.Slides แจกจ่ายผ่าน NuGet. คุณสามารถเพิ่มได้ด้วย .NET CLI บนระบบปฏิบัติการใดก็ได้, หรือด้วย NuGet Package Manager หรือ Package Manager Console ใน Visual Studio บน Windows. บทความนี้ยังอธิบายว่าควรเลือก NuGet package ใดจากสองตัวและ Linux ต้องการอะไรเพิ่มเติม.

ก่อนทำการติดตั้ง ให้ตรวจสอบระบบปฏิบัติการที่รองรับ, การนำ .NET ไปใช้, และการพึ่งพาเพิ่มเติมใน [ข้อกำหนดระบบ](/slides/th/net/system-requirements/).

## **เลือกแพ็กเกจ**

Aspose.Slides for .NET มีการเผยแพร่เป็น NuGet packages สองตัว. ทั้งสองให้ namespace และคลาสของ Aspose.Slides เดียวกัน, ดังนั้นโค้ดของคุณจะไม่เปลี่ยนเมื่อสลับระหว่างพวกมัน; เพียงแค่การอ้างอิงแพ็กเกจและข้อกำหนดของแพลตฟอร์มที่แตกต่างกัน.

| แพ็กเกจ | ใช้สำหรับ | ความต้องการเพิ่มเติม |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows และแอปพลิเคชัน .NET Framework | บน Linux และ macOS: ไลบรารี `libgdiplus` และสวิตช์ `System.Drawing.EnableUnixSupport` ที่เปิดใช้งานเมื่อตัวแอปพลิเคชันเริ่มทำงาน |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 หรือรุ่นถัดไปบน Windows, Linux, และ macOS | บน Linux: ไลบรารี `fontconfig` หากยังไม่ได้ติดตั้ง |

หากคุณไม่แน่ใจ ให้ใช้ Aspose.Slides.NET บน Windows และ Aspose.Slides.NET6.CrossPlatform บน Linux และ macOS. บน Alpine Linux และบนระบบ Linux ที่ glibc มีอายุเก่ากว่า 2.23 (x64) หรือ 2.39 (ARM64) ให้ใช้ Aspose.Slides.NET แทน. [ข้อกำหนดระบบ](/slides/th/net/system-requirements/) ระบุแพลตฟอร์มที่รองรับของแต่ละแพ็กเกจ.

## **ติดตั้งด้วย .NET CLI**

ขั้นตอนเหล่านี้ทำงานบน Windows, Linux, และ macOS ด้วย .NET SDK 6 หรือรุ่นถัดไป. สร้างแอปพลิเคชันคอนโซล:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

จากนั้นเพิ่มแพ็กเกจสำหรับแพล็ตฟอร์มของคุณ. เพิ่มเพียงหนึ่งในสองแพ็กเกจลงในโครงการ.

- บน Windows: `dotnet add package Aspose.Slides.NET`
- บน Linux และ macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (บน Linux ให้ติดตั้งสิ่งที่ต้องการล่วงหน้าก่อน; ดู [Linux](#linux))

เพื่อตรวจสอบว่าแพ็กเกจทำงาน, แทนที่เนื้อหาของ *Program.cs* ด้วยตัวอย่างแรกใน [สร้างการนำเสนอ](/slides/th/net/create-presentation/) แล้วรัน `dotnet run`. มันจะบันทึกไฟล์ *hello.pptx* ลงในโฟลเดอร์ของโครงการ.

## **Windows**

### **วิธีที่ 1: ติดตั้งหรืออัปเดต Aspose.Slides จาก NuGet Package Manager**

1. เปิด Microsoft Visual Studio.
2. สร้างแอปคอนโซลหรือเปิดโครงการที่มีอยู่.
3. ใน **Solution Explorer**, คลิกขวาที่โครงการและเลือก **Manage NuGet Packages** (หรือไปที่ **Project** > **Manage NuGet Packages**).
4. ภายใต้ **Browse**, ค้นหา *Aspose.Slides*.
{{% image img="installation_1.png" alt="การติดตั้ง Aspose.Slides จาก NuGet Package Manager - 1" %}}
5. คลิก **Aspose.Slides.NET** แล้วคลิก **Install**.
   * หากคุณได้ติดตั้ง Aspose.Slides แล้วและต้องการอัปเดต, คลิก **Update** แทน.

แพ็กเกจจะถูกดาวน์โหลดและอ้างอิงในโครงการของคุณ.

### **วิธีที่ 2: ติดตั้งหรืออัปเดต Aspose.Slides ผ่าน Package Manager Console**

นี่คือวิธีที่คุณอ้างอิงแพ็กเกจ [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) ผ่าน Package Manager Console:

1. เปิด Microsoft Visual Studio.
2. สร้างแอปคอนโซลหรือเปิดโครงการที่มีอยู่.
3. ไปที่ **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![เปิด Package Manager Console](installation_2.png)
4. รันคำสั่งนี้: `Install-Package Aspose.Slides.NET`
![รันคำสั่ง Install-Package](installation_3.png)
รุ่นล่าสุดจะถูกติดตั้งในโครงการของคุณ.

ข้อความ **Installing Aspose.Slides.NET** ปรากฏที่ด้านล่างของหน้าต่าง.
![ความคืบหน้าในการติดตั้งใน Package Manager Console](installation_4.png)

เมื่อดาวน์โหลดเสร็จ, จะมีข้อความยืนยันปรากฏ. แพ็กเกจนี้จัดจำหน่ายภายใต้ [Aspose EULA](https://about.aspose.com/legal/eula).
![ข้อความยืนยันการติดตั้ง](installation_5.png)

Aspose.Slides ถูกเพิ่มเข้าในโครงการของคุณและอ้างอิงแล้ว.
![Aspose.Slides ถูกอ้างอิงในโครงการ](installation_6.png)

เพื่ออัปเดตแพ็กเกจ, รัน `Update-Package Aspose.Slides.NET` ใน Package Manager Console.

## **Linux**

ใช้ขั้นตอน .NET CLI ด้านบน. เลือกแพ็กเกจและติดตั้งสิ่งที่ต้องการล่วงหน้าด้วยผู้จัดการแพ็กเกจของการแจกแจงของคุณ. บน Debian และ Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: ติดตั้ง `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
```

- **Aspose.Slides.NET**: ติดตั้ง `libgdiplus` และเปิดใช้งานการสนับสนุน Unix สำหรับ System.Drawing ก่อนที่แอปพลิเคชันของคุณจะใช้ Aspose.Slides.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
```

เพิ่มคำสั่งนี้ที่จุดเริ่มต้นของแอปพลิเคชันของคุณ, ก่อนการเรียกใช้ Aspose.Slides ใดๆ. ในไฟล์ *Program.cs* ที่มีคำสั่งระดับบนสุด, วางหลังจากคำสั่ง `using`:
```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

ใช้แพ็กเกจนี้บน Alpine Linux, และบนระบบที่ glibc เก่าเกินไปสำหรับ Aspose.Slides.NET6.CrossPlatform.

ฟอนต์ที่ใช้ในงานนำเสนอของคุณ, หรือฟอนต์ทดแทนที่เหมาะสม, ต้องติดตั้งบนระบบเพื่อให้ข้อความแสดงผลอย่างถูกต้อง. [ข้อกำหนดระบบ](/slides/th/net/system-requirements/) อธิบายแพ็กเกจที่ Aspose.Slides.NET ต้องการบน Alpine Linux, รวมถึงฟอนต์.

## **macOS**

ใช้ขั้นตอน .NET CLI ด้านบนกับแพ็กเกจ **Aspose.Slides.NET6.CrossPlatform**, ซึ่งสนับสนุน Mac ทั้งแบบ Intel (x86_64) และ Apple silicon (ARM64):
```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **คำถามที่พบบ่อย**

**มีเวอร์ชันฟรีหรือข้อจำกัดของรุ่นทดลองไหม?**

ใช่. หากไม่มีใบอนุญาต, Aspose.Slides จะทำงานในโหมดประเมินผล: จะเพิ่มลายน้ำการประเมินผลในทุกสไลด์ที่บันทึกและตัดข้อความที่อ่านจากการนำเสนอ. เพื่อลบข้อจำกัดเหล่านี้, ให้ใช้ใบอนุญาตที่ถูกต้อง [ใบอนุญาต](/slides/th/net/licensing/).