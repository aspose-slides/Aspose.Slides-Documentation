---
title: เรียกใช้ Aspose.Slides สำหรับ .NET ใน Docker
linktitle: Docker
type: docs
weight: 140
url: /th/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- คอนเทนเนอร์ Docker
- การสร้างหลายขั้นตอน
- อิมเมจคอนเทนเนอร์
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- ฟอนต์
- การแปลง PDF
- PowerPoint
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "สร้างและรันแอปพลิเคชันคอนโซล Aspose.Slides สำหรับ .NET ใน Docker: Dockerfile แบบหลายขั้นตอนบนอิมเมจ .NET อย่างเป็นทางการ, ไลบรารี Linux และฟอนต์ที่จำเป็น, และวิธีคัดลอกไฟล์ที่สร้างขึ้นไปยังเครื่องของคุณ."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการรัน Aspose.Slides สำหรับ .NET ในคอนเทนเนอร์ Docker คุณจะสร้างแอปพลิเคชันคอนโซลขนาดเล็กที่สร้างพรีเซนเทชันด้วยกล่องข้อความและแปลงเป็น PDF แพ็กเกจด้วย Dockerfile แบบหลายขั้นตอนบนภาพ .NET อย่างเป็นทางการของ Microsoft รันมันและคัดลอกไฟล์ที่สร้างขึ้นไปยังเครื่องของคุณ บทความยังระบุไลบรารี Linux และฟอนต์ที่ Aspose.Slides ต้องการในคอนเทนเนอร์และสิ้นสุดด้วยตัวเลือกสำหรับ Alpine Linux.

คุณต้องการ Docker เพียงอย่างเดียวบนเครื่องของคุณ .NET SDK เป็นส่วนหนึ่งของอิมเมจการสร้าง จึงไม่จำเป็นต้องติดตั้งมัน เพื่อทำการติดตั้ง Docker ดูที่ [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **เลือกแพ็กเกจและอิมเมจฐาน**

อิมเมจคอนเทนเนอร์ .NET 10 เริ่มต้นอิงตาม Ubuntu 24.04 ในอิมเมจเหล่านี้ ใช้แพ็กเกจ [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) ซึ่งต้องการไลบรารี `fontconfig` และอิมเมจรันไทม์ของ .NET ไม่มีไลบรารีนั้นหรือฟอนต์ใด ๆ ดังนั้น Dockerfile ในบทความนี้จึงติดตั้งทั้งสองอย่าง

Aspose.Slides.NET6.CrossPlatform ไม่ทำงานบน Alpine Linux สำหรับอิมเมจที่อิง Alpine ให้ใช้แพ็กเกจ [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) พร้อม `libgdiplus` ตามที่อธิบายใน [Run on Alpine Linux](#run-on-alpine-linux) [Installation](/slides/th/net/installation/) เปรียบเทียบสองแพ็กเกจนี้

## **สร้างโครงการ**

สร้างโฟลเดอร์ชื่อ *HelloSlidesDocker* และเพิ่มไฟล์สามไฟล์ต่อไปนี้ลงในโฟลเดอร์

*HelloSlidesDocker.csproj* อธิบายแอปพลิเคชันคอนโซลสำหรับ .NET 10 เวอร์ชันของอิมเมจคอนเทนเนอร์ที่ใช้ด้านล่างและอ้างอิง Aspose.Slides.NET6.CrossPlatform ตั้งค่าเวอร์ชันแพ็กเกจให้เป็นเวอร์ชันล่าสุดที่แสดงบน [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* สร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) เพิ่มสี่เหลี่ยมผืนผ้าพร้อมข้อความในสไลด์แรก และบันทึกพรีเซนเทชันสองครั้งด้วยเมธอด [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) คือเป็น PPTX และเป็น PDF ไฟล์ทั้งสองจะถูกเก็บไว้ในโฟลเดอร์ *output* ภายใต้ไดเรกทอรีทำงาน แอปพลิเคชันจากนั้นจะแสดงรายการฟอนต์ที่ถูกแทนที่ขณะเรนเดอร์ PDF โดยใช้ [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) เพื่อให้คุณตรวจสอบว่าคอนเทนเนอร์มีฟอนต์ที่พรีเซนเทชันใช้หรือไม่.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* ทำให้โฟลเดอร์ *bin* และ *obj* ของการสร้างในเครื่อง รวมถึงผลลัพธ์การรันก่อนหน้า ไม่ถูกรวมอยู่ในบริบทการสร้าง Docker จึงทำให้อิมเมจถูกสร้างจากไฟล์ต้นฉบับเท่านั้น.

```text
bin/
obj/
output/
```

## **เขียน Dockerfile**

เพิ่มไฟล์ชื่อ *Dockerfile* ไปยังโฟลเดอร์เดียวกัน:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

ไฟล์นี้มีสองขั้นตอน:

- **ขั้นตอนการสร้าง** เริ่มจากอิมเมจ .NET SDK จะคัดลอกไฟล์โครงการและทำการรีสโตร์แพ็กเกจ NuGet ก่อน เพื่อให้ Docker ใช้ชั้นนี้ซ้ำได้ตราบใดที่ไฟล์โครงการไม่เปลี่ยน แล้วคัดลอกซอร์สโค้ดและเผยแพร่แอปพลิเคชันไปยัง */app*.
- **ขั้นตอนการทำงาน** เริ่มจากอิมเมจ .NET runtime ที่มีขนาดเล็กกว่า ซึ่งไม่มี SDK และคัดลอกเฉพาะแอปพลิเคชันที่เผยแพร่มาเท่านั้น มันติดตั้งสองแพ็กเกจ:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform โหลดไลบรารีนี้เมื่อเริ่มต้น หากไม่มีไลบรารีนี้ แอปพลิเคชันจะหยุดทำงานด้วย `DllNotFoundException` ที่ระบุ `libfontconfig.so.1`.
  - `fonts-dejavu-core`: อิมเมจรันไทม์ไม่มีฟอนต์ใด ๆ และ Aspose.Slides ต้องการฟอนต์ติดตั้งอย่างน้อยหนึ่งตัวเพื่อวาดข้อความ; หากไม่มีฟอนต์เลย การแปลงจะหยุดด้วย `InvalidOperationException: Cannot find any fonts installed on the system.` ข้อความในฟอนต์ที่ไม่ได้ติดตั้งจะถูกวาดด้วยฟอนต์แทน ฟอนต์ DejaVu เป็นชุดเล็กที่ทำให้ข้อความแสดงผลได้; หากต้องการแสดงพรีเซนเทชันด้วยฟอนต์ที่ออกแบบไว้ ดูที่ [Deploy Fonts](/slides/th/net/deploy-fonts/).

`--no-install-recommends` และการลบรายการแพ็กเกจทำให้อิมเมจมีขนาดเล็กลง บรรทัดสุดท้ายสร้างโฟลเดอร์ *output* มอบให้ผู้ใช้ `app` ที่ไม่ใช่ root ซึ่งกำหนดโดยอิมเมจ .NET อย่างเป็นทางการ (ID ผู้ใช้อยู่ในตัวแปร `APP_UID`) และรันแอปพลิเคชันในฐานะผู้ใช้นั้น.

สำหรับแอปพลิเคชัน ASP.NET Core ให้เริ่มขั้นตอนรันไทม์จาก `mcr.microsoft.com/dotnet/aspnet:10.0` แทน ซึ่งอิงจากอิมเมจ Ubuntu เดียวกัน จึงต้องใช้แพ็กเกจเดียวกัน.

## **สร้างและรันคอนเทนเนอร์**

เปิดเทอร์มินัลในโฟลเดอร์ *HelloSlidesDocker* สร้างอิมเมจ แล้วรันคอนเทนเนอร์จากมัน:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

การสร้างครั้งแรกจะดาวน์โหลดอิมเมจพื้นฐานและแพ็กเกจ NuGet ทำให้ใช้เวลานานกว่าการสร้างครั้งต่อ ๆ ไป คอนเทนเนอร์รันแอปพลิเคชันและหยุดลง มันพิมพ์:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

บรรทัดแรกแสดงว่าข้อความใช้ฟอนต์ Calibri ซึ่งเป็นฟอนต์เริ่มต้นของพรีเซนเทชันใหม่ และ Calibri ไม่ได้ติดตั้งในอิมเมจ ดังนั้น Aspose.Slides จึงวาดข้อความด้วย DejaVu Sans ข้อความใน PDF เป็นข้อความจริงที่สามารถเลือกได้ด้วยฟอนต์นั้น หากไม่มีลิขสิทธิ์ Aspose.Slides จะเพิ่มลายน้ำการประเมินผลในทุกสไลด์ที่บันทึก; ดูที่ [Licensing](/slides/th/net/licensing/).

## **คัดลอกผลลัพธ์ไปยังเครื่องของคุณ**

ไฟล์อยู่ในโฟลเดอร์ */app/output* ของคอนเทนเนอร์ที่หยุดทำงาน คัดลอกไฟล์เหล่านั้นไปยังโฟลเดอร์ *output* บนเครื่องของคุณ แล้วลบคอนเทนเนอร์:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

คำสั่งสองนี้ทำงานเช่นเดียวกันใน Bash, PowerShell, และ Windows Command Prompt.

บน Linux คุณสามารถเมานท์โฟลเดอร์บนเครื่องของคุณเข้าไปในคอนเทนเนอร์แทนได้ เพื่อให้แอปพลิเคชันเขียนไฟล์ลงในโฟลเดอร์นั้นโดยตรง:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

ออปชัน `--user` รันแอปพลิเคชันด้วย ID ผู้ใช้และกลุ่มของคุณ ทำให้มันสามารถเขียนลงในโฟลเดอร์ที่คุณสร้างและไฟล์เป็นของคุณ `--rm` จะลบคอนเทนเนอร์เมื่อมันหยุดทำงาน.

## **รันบน Alpine Linux**

เพื่อรันแอปพลิเคชันในอิมเมจที่อิง Alpine ให้เปลี่ยนเป็นแพ็กเกจ Aspose.Slides.NET และแก้ไขขั้นตอนรันไทม์ ขั้นตอนการสร้างจะคงเดิม.

1. ใน *HelloSlidesDocker.csproj* ให้แทนที่การอ้างอิงแพ็กเกจ:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. ใน *Program.cs* ให้เพิ่มคำสั่งนี้หลังจากไดเร็กทีฟ `using` ก่อนการเรียก Aspose.Slides ครั้งแรก ซึ่งเปิดใช้งานการสนับสนุน System.Drawing สำหรับ Linux ที่ Aspose.Slides.NET ใช้:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. ใน *Dockerfile* ให้แทนที่ขั้นตอนรันไทม์ (ทั้งหมดตั้งแต่บรรทัด `FROM` ที่สอง) ด้วย:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

Alpine stage ติดตั้งสามแพ็กเกจและเปลี่ยนหนึ่งการตั้งค่า:

- `libgdiplus` คือไลบรารีกราฟิกที่ Aspose.Slides.NET ใช้บน Linux.
- `font-dejavu` ให้ฟอนต์ หากไม่มีฟอนต์ใด การแปลงจะหยุดด้วย `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` และ `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` ให้ข้อมูลวัฒนธรรม .NET images ของ Alpine ทำงานในโหมด globalization-invariant ตามค่าเริ่มต้น และในโหมดนั้น Aspose.Slides จะหยุดด้วย `CultureNotFoundException` สำหรับ `en-US`.

สร้าง รัน และคัดลอกผลลัพธ์ด้วยคำสั่งเดียวกับด้านบน บนอิมเมจนี้ แอปพลิเคชันพิมพ์เฉพาะบรรทัด `Saved` เท่านั้น: ด้วย Aspose.Slides.NET บน Linux, fontconfig จะเลือกรายการแทนที่สำหรับฟอนต์ที่หายไป และ [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) ไม่แสดงรายการนั้น [Deploy Fonts](/slides/th/net/deploy-fonts/) แสดงวิธีตรวจสอบว่าฟอนต์ไหนถูกใช้.

## **คำถามที่พบบ่อย**

**แอปพลิเคชันหยุดทำงานด้วยข้อความ "Unable to load shared library 'libaspose.slides.drawing.capi…'". สิ่งที่ขาดคืออะไร?**

บนอิมเมจ Ubuntu และ Debian ให้ติดตั้งแพ็กเกจ `libfontconfig1`; ข้อความระบุ `libfontconfig.so.1` เป็นไฟล์ที่ไม่สามารถเปิดได้ บน Alpine Linux ข้อความนี้หมายถึงกำลังใช้ Aspose.Slides.NET6.CrossPlatform; ให้สลับเป็น Aspose.Slides.NET ตามที่อธิบายใน [Run on Alpine Linux](#run-on-alpine-linux).

**ทำไมข้อความใน PDF จึงเป็นฟอนต์ที่ต่างจาก PowerPoint?**

ฟอนต์ที่พรีเซนเทชันใช้ไม่ได้ติดตั้งในอิมเมจ ทำให้ Aspose.Slides วาดข้อความด้วยฟอนต์แทน ผลลัพธ์ของแอปพลิเคชันจะแสดงชื่อฟอนต์ที่ถูกแทนที่ [Deploy Fonts](/slides/th/net/deploy-fonts/) อธิบายวิธีการติดตั้งฟอนต์ในอิมเมจหรือโหลดจากโฟลเดอร์แอปพลิเคชัน.

**ฉันต้องการ .NET SDK บนเครื่องของฉันหรือไม่?**

ไม่จำเป็น ขั้นตอนการสร้างคอมไพล์แอปพลิเคชันภายในอิมเมจ SDK คุณจะต้องการ SDK เฉพาะเมื่อต้องการสร้างและรันแอปพลิเคชันนอก Docker; ดูที่ [Installation](/slides/th/net/installation/).