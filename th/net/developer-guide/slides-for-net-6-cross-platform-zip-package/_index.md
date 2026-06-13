---
title: Aspose.Slides สำหรับ .NET 6 ข้ามแพลตฟอร์ม (แพ็กเกจ ZIP)
type: docs
weight: 237
url: /th/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- ข้ามแพลตฟอร์ม
- .NET 6
- GLIBC
- csproj
- เส้นทางเป้าหมาย
- ไลบรารีที่ขึ้นอยู่
- Aspose.Slides.dll
- System.Drawing.Common
- ข้อขัดแย้งของชื่อ
- นามแฝง extern
- CS0433
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ .NET 6 เพื่อสร้างแอป C# ข้ามแพลตฟอร์มบน Windows, Linux และ macOS ที่สามารถสร้าง, แก้ไข และแปลงไฟล์ PowerPoint PPT, PPTX และ ODP"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการใช้ Aspose.Slides for .NET 6 Cross-Platform จากแพ็กเกจ ZIP โดยอธิบายขั้นตอนการดาวน์โหลดแพ็กเกจ แยกไฟล์จากโฟลเดอร์ `net6.0/crossplatform` เพิ่มการอ้างอิงถึง `Aspose.Slides.dll` และกำหนดค่าไฟล์โครงการเพื่อให้ไลบรารีที่ต้องการขึ้นอยู่กับถูกคัดลอกไปยังไดเรกทอรีผลลัพธ์ของแอปพลิเคชัน

บทความนี้ยังบรรยายเนื้อหาภายในแพ็กเกจข้ามแพลตฟอร์ม ซึ่งรวมถึงแอสเซมบลีหลักของ Aspose.Slides .NET และไลบรารีระบบกราฟิกเฉพาะแพลตฟอร์มสำหรับ Windows, Linux และ macOS

{{% alert title="Note" color="primary" %}}

Aspose.Slides for .NET 6 Cross-Platform ยังมีให้ดาวน์โหลดจาก [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)

{{% /alert %}}

## **การใช้ Aspose.Slides แบบข้ามแพลตฟอร์มจากแพ็กเกจ ZIP**

1. ดาวน์โหลดแพ็กเกจ ZIP ของ Aspose.Slides รุ่นล่าสุดจาก [Release Page](https://releases.aspose.com/slides/th/net/)

2. แยกไฟล์จาก *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* แล้ววางไว้ในโฟลเดอร์ที่จะใช้เป็นการพึ่งพาในโครงการของคุณ

3. เพิ่มการอ้างอิงถึง Aspose.Slides.dll

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   ในตัวอย่างของเรา (ด้านล่าง) ไลบรารีตั้งอยู่ในโฟลเดอร์โครงการตามเส้นทางนี้: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. วางไฟล์ที่เหลือ (ที่ Aspose.Slides ต้องการ) ในไดเรกทอรีผลลัพธ์โดยเพิ่มคำสั่งลงในไฟล์โครงการ csproj ดังนี้

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

5. ให้ความสนใจกับ `TargetPath`

   โดยค่าเริ่มต้น `<CopyToOutputDirectory>` จะคัดลอกไฟล์พร้อมคงที่เส้นทางสัมพันธ์ แต่เราต้องการให้ไลบรารีที่ขึ้นอยู่ไปยังโฟลเดอร์เดียวกับที่สร้างผลลัพธ์ (ตำแหน่งของ Aspose.Slides.dll)

## **หมายเหตุ**

### **ระบบกราฟิกแบบเฉพาะเจ้าของ**

Aspose.Slides ข้ามแพลตฟอร์มเป็นชุดของไลบรารี:

| Aspose.Slides.dll                                          | แอสเซมบลี .NET หลักที่รับผิดชอบตรรกะของ Aspose.Slides ทั้งหมด |
| ---------------------------------------------------------- | -------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | ขึ้นอยู่กับ: การทำงานของระบบกราฟิกสำหรับ Win x64              |
| aspose.slides.drawing.capi_vc14x86.dll                     | ขึ้นอยู่กับ: การทำงานของระบบกราฟิกสำหรับ Win x86              |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | ขึ้นอยู่กับ: การทำงานของระบบกราฟิกสำหรับ Linux (x86/x64)    |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | ขึ้นอยู่กับ: การทำงานของระบบกราฟิกสำหรับ macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | ขึ้นอยู่กับ: การทำงานของระบบกราฟิกสำหรับ macOS ARM64 (AArch64) |

Aspose.Slides.dll ใช้ไลบรารีที่ระบบที่ทำงานอยู่ต้องการ ไลบรารีเหล่านี้มักอยู่ในตำแหน่งเดียวกับ Aspose.Slides.dll บนระบบไฟล์ใด ๆ

### **โครงสร้างของแพ็กเกจ ZIP**

แพ็กเกจ ZIP มีโครงสร้างโฟลเดอร์ดังต่อไปนี้:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* แต่ละโฟลเดอร์มีแอสเซมบลีสำหรับเวอร์ชัน .NET ที่สอดคล้อง มีสองเวอร์ชันสำหรับ net6.0: default และ crossplatform เวอร์ชันหลังมี Aspose.Slides.dll แบบข้ามแพลตฟอร์มและทั้งหมดของการพึ่งพา เนื้อหาได้แยกจากโฟลเดอร์นี้สามารถใช้เป็นการเพิ่มการพึ่งพาในโครงการสำหรับการพัฒนาแบบข้ามแพลตฟอร์มและกรณีการใช้ Aspose.Slides อื่น ๆ

## **ดูเพิ่มเติม**

- [System Requirements](/slides/th/net/system-requirements/)