---
title: "Aspose.Slides for .NET 6 Cross‑Platform (แพ็คเกจ ZIP)"
type: docs
weight: 237
url: /th/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
  - "ข้ามแพลตฟอร์ม"
  - ".NET 6"
  - "GLIBC"
  - "csproj"
  - "เส้นทางเป้าหมาย"
  - "ไลบรารีที่ขึ้นต่อ"
  - "Aspose.Slides.dll"
  - "System.Drawing.Common"
  - "ข้อขัดแย้งชื่อ"
  - "นามแฝงภายนอก"
  - "CS0433"
  - "PowerPoint"
  - "OpenDocument"
  - "งานนำเสนอ"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: "ใช้ Aspose.Slides for .NET 6 เพื่อสร้างแอป C# แบบข้ามแพลตฟอร์มบน Windows, Linux และ macOS ที่สามารถสร้าง แก้ไข และแปลงไฟล์ PowerPoint PPT, PPTX และ ODP ได้"
---
## **Overview**

บทความนี้อธิบายวิธีการใช้ Aspose.Slides for .NET 6 Cross‑Platform จากแพ็กเกจ ZIP โดยอธิบายวิธีดาวน์โหลดแพ็กเกจ การแตกไฟล์จากโฟลเดอร์ `net6.0/crossplatform` การเพิ่มอ้างอิงไปยัง `Aspose.Slides.dll` และการกำหนดค่าไฟล์โครงการเพื่อให้ไลบรารีที่ต้องการขึ้นต่อถูกคัดลอกไปยังไดเรกทอรีเอาต์พุตของแอปพลิเคชัน

บทความยังอธิบายเนื้อหาของแพ็กเกจ cross‑platform รวมถึงแอสเซมบลีหลักของ Aspose.Slides .NET และไลบรารีระบบกราฟิกเฉพาะแพลตฟอร์มสำหรับ Windows, Linux และ macOS

{{% alert title="Note" color="info" %}}
Aspose.Slides for .NET 6 Cross‑Platform ยังมีให้ดาวน์โหลดจาก [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) อีกด้วย
{{% /alert %}}

## **Using the Cross‑Platform Aspose.Slides from a ZIP Package**

1. ดาวน์โหลดแพ็กเกจ ZIP ของ Aspose.Slides รุ่นล่าสุดจาก [Release Page](https://releases.aspose.com/slides/th/net/)

2. แตกไฟล์จาก *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* แล้วใส่ไว้ในโฟลเดอร์ที่จะใช้เป็นการอ้างอิงในโครงการของคุณ

3. เพิ่มอ้างอิงไปยัง Aspose.Slides.dll

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   ในตัวอย่างของเรา (ด้านล่าง) ไลบรารีอยู่ในโฟลเดอร์โครงการตามเส้นทางนี้: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. ใส่ไฟล์ที่เหลือ (ที่ Aspose.Slides ต้องการ) ลงในไดเรกทอรีเอาต์พุตโดยเพิ่มคำสั่งลงในไฟล์ csproj ของโครงการดังนี้

```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. ให้ใส่ใจที่ `TargetPath`

   โดยค่าเริ่มต้น `<CopyToOutputDirectory>` จะคัดลอกไฟล์พร้อมคงรักษาโครงสร้างเส้นทางสัมพัทธ์ไว้ แต่เราต้องการให้ไลบรารีที่ขึ้นต่อไปยังโฟลเดอร์เดียวกับที่สร้างเอาต์พุต (ตำแหน่งของ Aspose.Slides.dll)

## **Notes**

### **Proprietary Graphics Subsystem**

Aspose.Slides cross‑platform คือชุดของไลบรารี:

| Aspose.Slides.dll                                          | Assembly .NET หลักที่รับผิดชอบตรรกะทั้งหมดของ Aspose.Slides |
| ---------------------------------------------------------- | ------------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | การพึ่งพา: การดำเนินการระบบกราฟิกสำหรับ Windows x64 |
| aspose.slides.drawing.capi_vc14x86.dll                     | การพึ่งพา: การดำเนินการระบบกราฟิกสำหรับ Windows x86 |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | การพึ่งพา: การดำเนินการระบบกราฟิกสำหรับ Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | การพึ่งพา: การดำเนินการระบบกราฟิกสำหรับ macOS AMD64 (x86‑64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | การพึ่งพา: การดำเนินการระบบกราฟิกสำหรับ macOS ARM64 (AArch64) |

Aspose.Slides.dll ใช้ไลบรารีที่ระบบที่กำลังทำงานต้องการ ไลบรารีเหล่านี้มักอยู่ในตำแหน่งเดียวกับ Aspose.Slides.dll ในระบบไฟล์ใด ๆ

### **ZIP Package Structure**

แพ็กเกจ ZIP มีโครงสร้างโฟลเดอร์ดังต่อไปนี้:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* โฟลเดอร์แต่ละโฟลเดอร์มีแอสเซมบลีสำหรับเวอร์ชัน .NET ที่สอดคล้องกัน มีสองเวอร์ชันสำหรับ net6.0: default และ crossplatform เวอร์ชันหลังมี Aspose.Slides.dll แบบข้ามแพลตฟอร์มและไลบรารีที่ขึ้นต่อทั้งหมด เนื้อหาที่แตกไฟล์ในโฟลเดอร์นี้สามารถใช้เป็นการเพิ่มการอ้างอิงในโครงการสำหรับการพัฒนาแบบข้ามแพลตฟอร์มและการใช้ Aspose.Slides ในกรณีอื่น ๆ

## **See Also**

- [System Requirements](/slides/th/net/system-requirements/)