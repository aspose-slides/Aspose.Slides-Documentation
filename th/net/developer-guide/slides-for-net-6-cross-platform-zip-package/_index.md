---
title: Aspose.Slides สำหรับ .NET 6 Cross-Platform (แพ็กเกจ ZIP)
type: docs
weight: 237
url: /th/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
- ข้ามแพลตฟอร์ม
- .NET 6
- GLIBC
- csproj
- เส้นทางเป้าหมาย
- ไลบรารีที่พึ่งพา
- Aspose.Slides.dll
- System.Drawing.Common
- ข้อขัดแย้งชื่อ
- extern alias
- CS0433
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ .NET 6 เพื่อสร้างแอป C# ข้ามแพลตฟอร์มบน Windows, Linux, และ macOS ที่สามารถสร้าง แก้ไข และแปลงไฟล์ PowerPoint PPT, PPTX และ ODP"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการใช้ Aspose.Slides for .NET 6 Cross-Platform จากแพ็กเกจ ZIP รวมถึงวิธีดาวน์โหลดแพ็กเกจ แตกไฟล์จากโฟลเดอร์ `net6.0/crossplatform` เพิ่มการอ้างอิงไปยัง `Aspose.Slides.dll` และกำหนดค่าไฟล์โครงการเพื่อให้ไลบรารีที่ต้องการถูกคัดลอกไปยังไดเรกทอรีผลลัพธ์ของแอปพลิเคชัน

บทความยังอธิบายเนื้อหาของแพ็กเกจข้ามแพลตฟอร์ม ซึ่งรวมถึงแอสเซมบลีหลักของ Aspose.Slides .NET และไลบรารีย่อยระบบกราฟิกเฉพาะแพลตฟอร์มสำหรับ Windows, Linux และ macOS

{{% alert title="Note" color="primary" %}}
Aspose.Slides for .NET 6 Cross-Platform สามารถดาวน์โหลดได้จาก [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) ด้วย
{{% /alert %}}

## **การใช้ Aspose.Slides ข้ามแพลตฟอร์มจากแพ็กเกจ ZIP**

1. ดาวน์โหลดแพ็กเกจ ZIP ของ Aspose.Slides เวอร์ชันล่าสุดจาก [Release Page](https://releases.aspose.com/slides/th/net/)

2. แตกไฟล์จาก *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* แล้ววางไว้ในโฟลเดอร์ที่จะใช้เป็น dependency ในโครงการของคุณ

3. เพิ่มการอ้างอิงไปยัง Aspose.Slides.dll

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   ในตัวอย่างของเรา (ด้านล่าง) ไลบรารีตั้งอยู่ในโฟลเดอร์ของโครงการตามเส้นทางนี้: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. วางไฟล์ที่เหลือ (ไฟล์ที่ Aspose.Slides ต้องพึ่งพา) ไปยังไดเรกทอรีผลลัพธ์โดยเพิ่มคำสั่งในไฟล์ csproj ของโครงการดังนี้

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

5. ให้ใส่ใจกับ `TargetPath`

   โดยค่าเริ่มต้น `<CopyToOutputDirectory>` จะคัดลอกไฟล์พร้อมคงรักษาเส้นทางสัมพัทธ์ไว้ แต่เราต้องการให้ไลบรารีที่พึ่งพาไปยังโฟลเดอร์เดียวกับที่สร้างผลลัพธ์ (ตำแหน่งของ Aspose.Slides.dll)

## **หมายเหตุ**

### **ระบบกราฟิกที่เป็นกรรมสิทธิ์**

Aspose.Slides cross‑platform เป็นชุดของไลบรารี:

| Aspose.Slides.dll                                          | แอสเซมบลี .NET หลักที่รับผิดชอบตรรกะทั้งหมดของ Aspose.Slides |
| ---------------------------------------------------------- | ------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Dependency: การทำงานของระบบกราฟิกสำหรับ Win x64                |
| aspose.slides.drawing.capi_vc14x86.dll                     | Dependency: การทำงานของระบบกราฟิกสำหรับ Win x64                |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Dependency: การทำงานของระบบกราฟิกสำหรับ Linux (x86/x64)        |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Dependency: การทำงานของระบบกราฟิกสำหรับ macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Dependency: การทำงานของระบบกราฟิกสำหรับ macOS ARM64 (AArch64)   |

Aspose.Slides.dll ใช้ไลบรารีที่ระบบที่มันทำงานอยู่ต้องการ ไลบรารีเหล่านี้โดยทั่วไปจะอยู่ในตำแหน่งเดียวกับ Aspose.Slides.dll ในระบบไฟล์ใด ๆ

### **โครงสร้างแพ็กเกจ ZIP**

แพ็กเกจ ZIP มีโครงสร้างโฟลเดอร์ดังต่อไปนี้:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* แต่ละโฟลเดอร์ประกอบด้วยแอสเซมบลีสำหรับเวอร์ชัน .NET ที่สอดคล้องกัน มีสองเวอร์ชันสำหรับ net6.0: default และ crossplatform เวอร์ชันหลังประกอบด้วย Aspose.Slides.dll ข้ามแพลตฟอร์มและ dependencies ทั้งหมด เนื้อหาที่แตกจากโฟลเดอร์นี้สามารถใช้เป็นการเพิ่ม dependency ในโครงการสำหรับการพัฒนาข้ามแพลตฟอร์มและกรณีการใช้ Aspose.Slides อื่น ๆ

## **ดูเพิ่มเติม**

- [System Requirements](/slides/th/net/system-requirements/)