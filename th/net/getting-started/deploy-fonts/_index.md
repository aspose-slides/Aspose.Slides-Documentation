---
title: "ปรับใช้แบบอักษรสำหรับ Aspose.Slides บน Linux และใน Docker"
linktitle: "ปรับใช้แบบอักษร"
type: docs
weight: 145
url: /th/net/deploy-fonts/
keywords:
- ปรับใช้แบบอักษร
- ติดตั้งแบบอักษร
- แบบอักษรใน Docker
- แบบอักษรบน Linux
- แบบอักษรที่หายไป
- การแทนที่แบบอักษร
- แบบอักษรหลักของ Microsoft
- ttf-mscorefonts-installer
- แบบอักษรแบบกำหนดเอง
- แบบอักษรเริ่มต้น
- เซิร์ฟเวอร์
- คอนเทนเนอร์
- การแปลง PDF
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ปรับใช้แบบอักษรสำหรับ Aspose.Slides สำหรับ .NET บนเซิร์ฟเวอร์ Linux และคอนเทนเนอร์ Docker: ตรวจสอบว่ามีการแทนที่แบบอักษรใด, ติดตั้งแพ็กเกจแบบอักษรบน Debian, Ubuntu และ Alpine, เพิ่มไฟล์แบบอักษรของคุณเอง, และตั้งค่าแบบอักษรเริ่มต้น."
---
## **ภาพรวม**

Aspose.Slides วาดข้อความด้วยแบบอักษรที่มีให้เมื่อมันแสดงสไลด์, ตัวอย่างเช่นเมื่อแปลงสไลด์เป็น PDF หรือเป็นรูปภาพ. เครื่อง Windows ปกติจะมีแบบอักษรที่สไลด์ใช้. เซิร์ฟเวอร์และคอนเทนเนอร์ Linux มักมีแบบอักษรน้อยหรือไม่มี, ดังนั้น Aspose.Slides จะวาดข้อความด้วยแบบอักษรทดแทน. แบบอักษรทดแทนมีรูปแบบอักษรและความกว้างที่ต่างกัน, ทำให้บรรทัดอาจหักบรรทัดต่างกันและข้อความอาจล้นรูปทรง, และอักขระที่แบบอักษรทดแทนไม่มีจะไม่ถูกวาดอย่างถูกต้อง. หากไม่มีแบบอักษรติดตั้งเลย, การแปลงจะหยุดด้วยข้อผิดพลาด.

บทความนี้แสดงวิธีตรวจสอบว่า Aspose.Slides แทนที่แบบอักษรใด, วิธีติดตั้งแบบอักษรบน Debian, Ubuntu, และ Alpine Linux, วิธีเพิ่มไฟล์แบบอักษรของคุณเอง, และวิธีกำหนดแบบอักษรที่ใช้เมื่อไม่มีแบบอักษร. ตัวอย่างทำงานใน Docker บนภาพ .NET อย่างเป็นทางการ, เช่นใน [Run Aspose.Slides for .NET in Docker](/slides/th/net/how-to-run-aspose-slides-in-docker/). คำสั่งแพ็กเกจเป็นคำสั่งของ Dockerfile; บนเซิร์ฟเวอร์ Linux ให้เรียกใช้คำสั่งเดียวกันด้วยสิทธิ root.

สำหรับ API ของแบบอักษรเอง, เช่นการฝังแบบอักษรในงานนำเสนอและกฎการสำรองและการแทนที่, ดูที่ [PowerPoint Fonts](/slides/th/net/powerpoint-fonts/).

## **ตรวจสอบว่าแบบอักษรใดถูกแทนที่**

แอปพลิเคชันคอนโซลต่อไปนี้รายงานแบบอักษรที่ Aspose.Slides แทนที่ในสภาพแวดล้อมปัจจุบัน. สร้างโฟลเดอร์ชื่อ *FontCheck* และเพิ่มไฟล์ด้านล่างลงไปในโฟลเดอร์นั้น.

*FontCheck.csproj* อ้างอิง [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), แพ็กเกจสำหรับ Debian และ Ubuntu. มันยังคัดลอกไฟล์ของโฟลเดอร์ *fonts* ตัวเลือกไปยังเอาต์พุตของแอปพลิเคชัน; ส่วน [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) ใช้งานมัน.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* เพิ่มกล่องข้อความหนึ่งกล่องต่อชื่อแบบอักษรลงในสไลด์และกำหนดแบบอักษรผ่านคุณสมบัติ [LatinFont](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/latinfont/). ชื่อแบบอักษรมาจากบรรทัดคำสั่ง; หากไม่มีอาร์กิวเมนต์, แอปพลิเคชันจะตรวจสอบ Calibri, Arial, และ Times New Roman. มันพิมพ์โฟลเดอร์ที่ Aspose.Slides มองหาแบบอักษร ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/getfontfolders/)), แสดงสไลด์เป็น *output/fonts.pdf*, และพิมพ์การแทนที่ที่รายงานโดย [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getsubstitutions/). ขั้นตอนสองขั้นตอนที่เป็นตัวเลือกในตอนต้น, การโหลดโฟลเดอร์ *fonts* และการอ่านตัวแปร `DEFAULT_FONT`, จะอธิบายต่อในบทความนี้.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// แบบอักษรที่จะตรวจสอบ: อาร์กูเมนต์จากบรรทัดคำสั่ง หรือแบบอักษร Office ที่พบบ่อยสามแบบ.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// โหลดไฟล์แบบอักษรจากโฟลเดอร์ fonts ที่อยู่ใกล้แอปพลิเคชัน หากมี.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// ใช้แบบอักษรที่ระบุในตัวแปรสภาพแวดล้อม DEFAULT_FONT หากตั้งค่าไว้ สำหรับข้อความที่ขาดแบบอักษร.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* เก็บผลการสร้างในเครื่องออกจากบริบทการสร้าง:

```text
bin/
obj/
output/
```

*Dockerfile* สร้างแอปพลิเคชันด้วยภาพ .NET SDK และรันบนภาพ .NET runtime. ขั้นตอน runtime ติดตั้ง `libfontconfig1` ซึ่ง Aspose.Slides.NET6.CrossPlatform ต้องการ, และแบบอักษร DejaVu. [Run Aspose.Slides for .NET in Docker](/slides/th/net/how-to-run-aspose-slides-in-docker/) อธิบายแต่ละคำสั่ง.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

สร้างภาพและรันการตรวจสอบ:

```bash
docker build -t font-check .
docker run --rm font-check
```

ภาพมีแบบอักษร DejaVu เท่านั้น, ดังนั้นแบบอักษรทั้งสามจะแทนที่ด้วย DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

เพื่อตรวจสอบแบบอักษรของงานนำเสนอของคุณเอง, ให้ส่งชื่อของมันเป็นอาร์กิวเมนต์, ตัวอย่างเช่น `docker run --rm font-check "Segoe UI" Consolas`. เพื่อคัดลอก *output/fonts.pdf* ออกจากคอนเทนเนอร์, ใช้คำสั่งใน [Copy the Output to Your Machine](/slides/th/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **ติดตั้งแบบอักษรบน Debian และ Ubuntu**

### **แบบอักษรหลักของ Microsoft**

แพ็กเกจ `ttf-mscorefonts-installer` ดาวน์โหลดและติดตั้งแบบอักษรหลักของ Microsoft สำหรับเว็บ, ซึ่งรวมถึง Arial, Times New Roman, Courier New, Verdana, Georgia, และ Trebuchet MS. แบบอักษรเหล่านี้มีลิขสิทธิ์ภายใต้ข้อตกลงผู้ใช้สิ้นสุด (EULA) ของ Microsoft, และแพ็กเกจจะติดตั้งหลังจากยอมรับ EULA เท่านั้น. การสร้าง Docker ไม่สามารถตอบคำถามได้, ดังนั้นตัวติดตั้งจะปฏิเสธ EULA และไม่ได้ติดตั้งแบบอักษรใด ๆ, แม้ว่า `apt-get install` จะรายงานว่าประสบความสำเร็จ. ยอมรับ EULA ด้วย `debconf-set-selections` **ก่อน** ที่แพ็กเกจจะถูกติดตั้ง.

ใน *Dockerfile*, แทนที่คำสั่ง `RUN` ที่ติดตั้งแพ็กเกจในขั้นตอน runtime ด้วย:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

สร้างภาพและรันการตรวจสอบอีกครั้งด้วยสองคำสั่งเดียวกัน. ตอนนี้ Arial และ Times New Roman ถูกติดตั้งแล้ว:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, แบบอักษรเริ่มต้นของงานนำเสนอที่ Aspose.Slides สร้าง, ไม่ได้เป็นหนึ่งในแบบอักษรหลัก, ดังนั้นยังคงถูกแทนที่. ดูที่ [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

บน Debian, แพ็กเกจอยู่ในส่วน `contrib` ของรีโพซิทอรี, ซึ่งภาพ Debian ไม่ได้เปิดใช้; ภาพ .NET 8 และ .NET 9 เริ่มต้นอิงตาม Debian 12. เปิดใช้งาน `contrib` ในคำสั่งเดียวกัน:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

ภาพ .NET 10 ที่อิง Ubuntu มีการเปิดใช้งาน `multiverse` อยู่แล้ว, ซึ่งเป็นส่วนของ Ubuntu ที่มีแพ็กเกจนี้.

### **แพ็กเกจแบบอักษรอื่น ๆ**

Debian และ Ubuntu ยังจัดแพ็กเกจแบบอักษรที่มีลิขสิทธิ์เสรี, ตัวอย่างเช่น:

| แพ็กเกจ | แบบอักษร |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, and Mono, with the same metrics as Arial, Times New Roman, and Courier New |
| `fonts-crosextra-carlito` | Carlito, with the same metrics as Calibri |
| `fonts-crosextra-caladea` | Caladea, with the same metrics as Cambria |

ติดตั้งพวกมันด้วย `apt-get install` ในคำสั่ง `RUN` เดียวกัน. Aspose.Slides.NET6.CrossPlatform จะไม่ใช้นามแฝงแบบอักษรของการกำหนดค่าฟอนต์ Linux: แม้จะติดตั้ง `fonts-liberation` แล้ว, ข้อความใน Arial ยังถูกวาดด้วยแบบอักษรทดแทนทั่วไป, ไม่ได้ใช้ Liberation Sans. เพื่อใช้แบบอักษรที่มีเมตริกเข้ากับแบบอักษรที่ขาด, ตั้งเป็น [default font](#set-a-default-font-for-missing-fonts) หรือเพิ่ม [font substitution rule](/slides/th/net/font-substitution/).

## **เพิ่มไฟล์แบบอักษรของคุณเอง**

แบบอักษรที่การแจกจ่ายไม่ได้จัดแพ็กเกจ, เช่นแบบอักษรขององค์กรของคุณหรือแบบอักษรอื่นที่คุณมีสิทธิ์ใช้บนเซิร์ฟเวอร์, สามารถเพิ่มเป็นไฟล์แบบอักษรได้. วางไฟล์แบบอักษร, ตัวอย่างเช่นไฟล์ *.ttf*, ใส่ในโฟลเดอร์ชื่อ *fonts* ภายในโฟลเดอร์ *FontCheck*. ตัวอย่างด้านล่างใช้ไฟล์ของ Carlito, แบบอักษรที่มีเมตริกเดียวกับ Calibri, ซึ่งคุณสามารถดาวน์โหลดจาก [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **ติดตั้งแบบอักษรในโฟลเดอร์แบบอักษรของระบบ**

Aspose.Slides อ่านแบบอักษรจากโฟลเดอร์ที่พิมพ์บนบรรทัด `Font folders`. เพื่อทำการติดตั้งแบบอักษรของคุณสำหรับทุกแอปพลิเคชันในภาพ, คัดลอกพวกมันไปที่ */usr/local/share/fonts*, โฟลเดอร์สำหรับแบบอักษรที่ติดตั้งในเครื่อง. เพิ่มคำสั่งนี้ในขั้นตอน runtime ของ *Dockerfile*, หลังจากคำสั่ง `RUN` ที่ติดตั้งแพ็กเกจ:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **โหลดแบบอักษรจากโฟลเดอร์แอปพลิเคชัน**

แทนที่จะติดตั้งแบบอักษรในภาพ, คุณสามารถจัดส่งพวกมันพร้อมกับแอปพลิเคชันและโหลดด้วย [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/). แบบอักษรจะมีให้กับ Aspose.Slides เท่านั้น, และจะถูกปรับใช้พร้อมกับแอปพลิเคชัน. *FontCheck* ทำเช่นนี้: *FontCheck.csproj* คัดลอกโฟลเดอร์ *fonts* ไปยังเอาต์พุตของแอปพลิเคชัน, และ *Program.cs* ส่งโฟลเดอร์นั้นไปยัง `LoadExternalFonts` ก่อนสร้างงานนำเสนอ. [Custom Font](/slides/th/net/custom-font/) อธิบายวิธีอื่น ๆ ในการจัดหาแบบอักษร, เช่นการโหลดจากหน่วยความจำ.

สร้างภาพใหม่, จากนั้นตรวจสอบ Calibri และ Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

โฟลเดอร์แอปพลิเคชันตอนนี้ปรากฏในรายการโฟลเดอร์แบบอักษร, และ Carlito จะไม่ถูกแทนที่อีกต่อไป:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **ตั้งค่าแบบอักษรเริ่มต้นสำหรับแบบอักษรที่หายไป**

เมื่อไม่มีแบบอักษร, Aspose.Slides จะใช้แบบอักษรทดแทนที่มันเลือกเอง. เพื่อเลือกเอง, ตั้งค่าคุณสมบัติ [DefaultRegularFont](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/defaultregularfont/) ของ [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/) และส่งตัวเลือกเหล่านั้นไปยังคอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/). *FontCheck* อ่านชื่อแบบอักษรจากตัวแปรสภาพแวดล้อม `DEFAULT_FONT`. เมื่อโหลด Carlito, ใช้มันสำหรับแบบอักษรที่หายไป:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

ตอนนี้ Calibri จะถูกวาดด้วย Carlito, ซึ่งอักขระมีความกว้างเท่ากับของ Calibri, ทำให้ข้อความยังคงรักษาการตัดบรรทัดไว้:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

แบบอักษรเริ่มต้นจะแทนที่ทุกแบบอักษรที่หายไป. เพื่อแมปแบบอักษรแต่ละตัว, ตัวอย่างเช่น Arial ไปที่ Liberation Sans และ Calibri ไปที่ Carlito, ใช้ [font substitution rules](/slides/th/net/font-substitution/). กฎจะเปลี่ยนผลลัพธ์ที่แสดง, แต่ `GetSubstitutions` จะไม่สะท้อนพวกมัน, ดังนั้นให้ตรวจสอบแบบอักษรในไฟล์เอาต์พุตแทน. สำหรับข้อความภาษาเอเชีย, ควรตั้งค่า [DefaultAsianFont](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/defaultasianfont/); ดูที่ [Default Font](/slides/th/net/default-font/).

## **ติดตั้งแบบอักษรบน Alpine Linux**

บน Alpine Linux, ใช้แพ็กเกจ Aspose.Slides.NET; [Run on Alpine Linux](/slides/th/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) ระบุการเปลี่ยนแปลงในโปรเจกต์. ทำการเปลี่ยนแปลงเดียวกันกับ *FontCheck*: แทนที่การอ้างอิงแพ็กเกจ, เพิ่มคำสั่ง `SetSwitch` ไปยัง *Program.cs*, และใช้ขั้นตอน runtime นี้, ซึ่งยังติดตั้งแบบอักษรหลักของ Microsoft:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` ดาวน์โหลดและติดตั้งแบบอักษรหลักของ Microsoft เหมือนแพ็กเกจ Debian และ Ubuntu, และ EULA ของมันจะใช้งานในลักษณะเดียวกัน. `fc-cache` อัปเดตแคชแบบอักษร.

เมื่อใช้ Aspose.Slides.NET บน Linux, ไลบรารีการกำหนดค่าแบบอักษร (fontconfig) จะเลือกแบบอักษรทดแทนสำหรับแบบอักษรที่หายไป, และ `GetSubstitutions` จะไม่รายงาน, ดังนั้น *FontCheck* พิมพ์ `No font substitutions.` เพื่อดูว่าแบบอักษรใดถูกใช้กับชื่อแบบอักษร, ให้สอบถาม fontconfig ในคอนเทนเนอร์:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

เมื่อมีการติดตั้งแบบอักษรหลักของ Microsoft, Arial จะถูกใช้สำหรับ Arial:

```text
Arial.ttf: "Arial" "Regular"
```

หากไม่มี, เมื่อคำสั่ง `RUN` ติดตั้งเฉพาะ `icu-libs libgdiplus font-dejavu`, คำสั่งเดียวกันจะพิมพ์:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **คำถามที่พบบ่อย**

**ทำไมงานนำเสนอถึงดูแตกต่างเมื่อแปลงบนเซิร์ฟเวอร์?**

เซิร์ฟเวอร์ไม่มีแบบอักษรที่งานนำใช้, ดังนั้น Aspose.Slides จะวาดข้อความด้วยแบบอักษรทดแทนที่อักษรมีความกว้างต่างกัน. ให้รัน *FontCheck* พร้อมชื่อแบบอักษรของงานนำเสนอเพื่อดูว่าแบบอักษรใดถูกแทนที่, จากนั้นติดตั้งแบบอักษรเหล่านั้นหรือโหลดจากโฟลเดอร์แอปพลิเคชัน.

**การสร้างได้ติดตั้ง ttf-mscorefonts-installer แล้ว, แต่ Arial ยังคงถูกแทนที่. ทำไม?**

EULA ไม่ได้ถูกยอมรับก่อนที่แพ็กเกจจะถูกติดตั้ง, ทำให้ตัวติดตั้งข้ามแบบอักษร. ให้เพิ่มคำสั่ง `debconf-set-selections` ก่อน `apt-get install`, ตามที่แสดงใน [Microsoft Core Fonts](#microsoft-core-fonts), และสร้างภาพใหม่.

**คอมพิวเตอร์ที่เปิด PDF ต้องการแบบอักษรหรือไม่?**

ไม่. ในตัวอย่างเหล่านี้, PDF จะบรรจุแบบอักษรที่ใช้ในการวาดข้อความ, ดังนั้นจะแสดงผลเดียวกันบนคอมพิวเตอร์ใดก็ได้. แบบอักษรจำเป็นต้องมีเฉพาะที่ที่ Aspose.Slides ทำการเรนเดอร์งานนำเสนอ.