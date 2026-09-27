---
title: การติดตั้ง
type: docs
weight: 70
url: /th/nodejs-net/installation/
keywords:
- ดาวน์โหลด Aspose.Slides
- ติดตั้ง Aspose.Slides
- การติดตั้ง Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "ติดตั้ง Aspose.Slides for Node.js via .NET จาก npm บน Windows หรือ Linux: ข้อกำหนดเบื้องต้น, การ override edge-js, การกู้คืน NuGet ครั้งเดียว, และโปรแกรมแรกที่สร้างงานนำเสนอ."
---
## **ภาพรวม**

Aspose.Slides for Node.js via .NET คือแพ็กเกจ npm `aspose.slides.via.net`. มันทำงานโดยเรียกใช้ไลบรารี Aspose.Slides .NET ภายใน Node.js ผ่านทาง [edge-js](https://github.com/agracio/edge-js) bridge, ดังนั้นการติดตั้งที่ทำงานได้ต้องมีทั้ง Node.js และ .NET

บทความนี้จะนำคุณจากเครื่องที่สะอาดไปสู่โปรแกรมแรกที่สร้างงานนำเสนอ มีทั้งหมดสี่ขั้นตอน: สร้างโปรเจ็กต์ด้วยการ override edge-js, ติดตั้งแพ็กเกจจาก npm, กู้คืนการขึ้นอยู่ของ .NET ของแพ็กเกจเพียงครั้งเดียว, และเรียกสคริปต์ของคุณจากโฟลเดอร์โปรเจ็กต์

## **ข้อกำหนดเบื้องต้น**

- **Node.js 22 หรือ 24 LTS**, เวอร์ชัน x64, จาก [nodejs.org](https://nodejs.org/en/download)
- **.NET SDK 8 หรือใหม่กว่า**, จาก [dotnet.microsoft.com](https://dotnet.microsoft.com/download) . Runtime ของ .NET เพียงอย่างเดียวไม่เพียงพอ: ขั้นตอนการกู้คืนด้านล่างต้องใช้ SDK, และบริดจ์ก็ต้องใช้เมื่อสคริปต์ของคุณทำงาน ตรวจสอบ SDK ที่ติดตั้งโดยรัน `dotnet --list-sdks`
- **บน Linux เท่านั้น**:
  - เครื่องมือการสร้าง `python3`, `make` และ `g++`, เนื่องจาก npm ทำการคอมไพล์ edge-js ระหว่างการติดตั้งบน Linux
  - ไลบรารี fontconfig, ซึ่งไลบรารีการวาดภาพแบบดิบของ Aspose.Slides ต้องโหลด

  บน Debian ชื่อแพ็กเกจคือ `python3`, `make`, `g++` และ `libfontconfig1`

ขั้นตอนในบทความนี้ได้ทดสอบบนแพลตฟอร์มต่อไปนี้:

| แพลตฟอร์ม | ผลลัพธ์ |
|---|---|
| Windows x64 พร้อม Node.js 22 หรือ 24 | ทำงานได้ ทดสอบกับ Microsoft Visual C++ Redistributable ที่ติดตั้งแล้ว |
| Linux x64 พร้อม Node.js 22 หรือ 24, ที่ระบบ OpenSSL มาจากสายการปล่อยเดียวกับ OpenSSL ที่รวมอยู่ใน Node.js, เช่น Debian 13 | ทำงานได้ |
| Linux ที่เวอร์ชัน OpenSSL สองเวอร์ชันต่างกัน, เช่น Debian 12 | Node.js เกิดการหยุดทำงานด้วย segmentation fault เมื่อสร้างงานนำเสนอ |
| macOS | ยังไม่ตรวจสอบ |

บน Linux ให้เปรียบเทียบเวอร์ชันทั้งสองก่อนเริ่มต้น คำสั่งแรกจะแสดงเวอร์ชัน OpenSSL ที่รวมอยู่ใน Node.js; คำสั่งที่สองจะแสดงเวอร์ชันของระบบ ใช้ระบบที่ตัวเลขหลักหลักและรองเริ่มต้นเดียวกัน, เช่น `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

ถ้าไม่พบคำสั่ง `openssl`, ให้ติดตั้งแพ็กเกจ `openssl` ก่อน

## **สร้างโปรเจ็กต์**

สร้างโฟลเดอร์สำหรับโปรเจ็กต์ของคุณ, เริ่มต้นมัน, และเพิ่มการ override ที่บอก npm ให้ติดตั้งรุ่น edge-js ที่ต้องการ:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

แพ็กเกจต้องการรุ่น edge-js เก่าที่ไบนารี Windows สร้างไว้หยุดที่ Node.js 20, ดังนั้นหากไม่มีการ override สคริปต์แรกบน Windows จะหยุดด้วยข้อความ "The edge module has not been pre-compiled for node.js version". คำสั่งจะเขียนการ override ไปที่ส่วน `overrides` ของ `package.json`; ให้เพิ่มก่อนติดตั้งแพ็กเกจ

## **ติดตั้งแพ็กเกจ**

ติดตั้ง Aspose.Slides for Node.js via .NET จาก npm:

```sh
npm install aspose.slides.via.net
```

ระหว่างการติดตั้ง, แพ็กเกจจะคัดลอกไลบรารีการวาดภาพแบบดิบของมัน (ไฟล์ที่มีชื่อ `aspose.slides.drawing.capi`) ไปยังโฟลเดอร์โปรเจ็กต์, อยู่ข้างๆ `package.json`

แพ็กเกจนี้ยังเผยแพร่เป็นไฟล์ ZIP ที่ [releases.aspose.com](https://releases.aspose.com/slides/th/nodejs-net/) บทความนี้ครอบคลุมการติดตั้งจาก npm เท่านั้น

## **กู้คืนการขึ้นอยู่ของ .NET**

แพ็กเกจมีแอสเซ็มบลี Aspose.Slides .NET, แต่ไม่มี 20 แพ็กเกจ NuGet ที่แอสเซ็มบลีเหล่านั้นต้องพึ่งพา ขณะรัน .NET จะค้นหาในแคช NuGet: `%USERPROFILE%\.nuget\packages` บน Windows, `~/.nuget/packages` บน Linux, หรือโฟลเดอร์ที่กำหนดโดยตัวแปรสภาพแวดล้อม `NUGET_PACKAGES`. หากไม่มี, สคริปต์แรกจะหยุดด้วยข้อความ "assembly specified in the dependencies manifest was not found"

เพื่อเติมแคช, สร้างโฟลเดอร์ชื่อ `deps` ในโฟลเดอร์โปรเจ็กต์และบันทึกไฟล์ต่อไปนี้ลงในนั้นเป็น `deps.csproj`. แต่ละรายการ `PackageDownload` จะดาวน์โหลดแพ็กเกจหนึ่งเวอร์ชันที่ระบุในวงเล็บ; ไม่มีการคอมไพล์ใดๆ

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

จากนั้นกู้คืนจากโฟลเดอร์โปรเจ็กต์:

```sh
dotnet restore deps/deps.csproj
```

คุณต้องทำขั้นตอนนี้เพียงครั้งเดียวต่อเครื่อง, ไม่ใช่ต่อโปรเจ็กต์: แพ็กเกจจะคงอยู่ในแคช NuGet, และโปรเจ็กต์ต่อไปบนเครื่องเดียวกันจะใช้มัน หลังจากกู้คืนแล้วคุณสามารถลบโฟลเดอร์ `deps` ได้

## **เรียกใช้โปรแกรมแรก**

สร้างไฟล์ชื่อ `hello.js` ในโฟลเดอร์โปรเจ็กต์ด้วยโค้ดต่อไปนี้. มันจะสร้างงานนำเสนอ, เพิ่มสี่เหลี่ยมที่มีข้อความ "Hello, World!" ไปยังสไลด์แรก, และบันทึกผลเป็น `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// งานนำเสนอใหม่มีสไลด์ว่างหนึ่งสไลด์.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // ตำแหน่งและขนาดใช้หน่วยจุด (1/72 นิ้ว): x, y, ความกว้าง, ความสูง.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // ปล่อยวัตถุ .NET ที่สนับสนุนงานนำเสนอ.
    presentation.dispose();
}
```

รันจากโฟลเดอร์โปรเจ็กต์:

```sh
node hello.js
```

สคริปต์จะแสดง `Saved hello.pptx`. เปิด `hello.pptx` เพื่อดูสไลด์หนึ่งที่มีสี่เหลี่ยมเติมสีพร้อมข้อความ. หากไม่มีใบอนุญาต, Aspose.Slides จะเพิ่มลายน้ำประเมิน; ดู [Evaluate Aspose.Slides](/slides/th/nodejs-net/evaluate-aspose-slides/) และ [Licensing](/slides/th/nodejs-net/licensing/)

{{% alert color="info" title="Note" %}}
รันสคริปต์ของคุณจากโฟลเดอร์โปรเจ็กต์, โฟลเดอร์ที่มี `package.json`. เส้นทางแบบสัมพันธ์เช่น `hello.pptx` จะอ้างอิงจากโฟลเดอร์ปัจจุบัน, และบนบางเครื่องสคริปต์ที่เริ่มจากโฟลเดอร์อื่นอาจไม่สามารถสร้างงานนำเสนอได้
{{% /alert %}}

JavaScript API สะท้อน Aspose.Slides for .NET: คลาสคงชื่อ .NET, คุณสมบัติและเมธอดใช้ camelCase (`Slides` กลายเป็น `slides`, `AddAutoShape` กลายเป็น `addAutoShape`), และรายการคอล렉ชันอ่านด้วย `get(index)`. ไม่มีเอกสารอ้างอิง API แยกสำหรับแพ็กเกจนี้, ดังนั้นให้ใช้ [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/th/net/) เพื่อดูรายละเอียดคลาสและสมาชิก, เช่น [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) และ [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/shapecollection/addautoshape/)

## **คำถามที่พบบ่อย**

**"The edge module has not been pre-compiled for node.js version" หมายถึงอะไร?**

npm ติดตั้งรุ่น edge-js เก่าที่แพ็กเกจร้องขอ. ให้เพิ่มการ override จาก [สร้างโปรเจ็กต์](#create-a-project) แล้วรัน `npm install` อีกครั้ง

**"assembly specified in the dependencies manifest was not found" หมายถึงอะไร?**

การขึ้นอยู่ของ .NET ไม่อยู่ในแคช NuGet. การทำงานเดียวกันยังรายงาน "edge.initializeClrFunc is not a function". ทำตามขั้นตอน [กู้คืนการขึ้นอยู่ของ .NET](#restore-the-net-dependencies) ครั้งหนึ่ง, แล้วรันสคริปต์ของคุณอีกครั้ง

**"The edge native module is not available" หมายถึงอะไรบน Linux?**

edge-js ไม่ได้ถูกคอมไพล์ระหว่าง `npm install`, ตัวอย่างเช่นเพราะไม่มี `python3`, `make` หรือ `g++`. npm ไม่รายงานเป็นข้อผิดพลาด. ติดตั้งเครื่องมือสร้าง, แล้วรัน `npm rebuild edge-js` ในโฟลเดอร์โปรเจ็กต์

**ทำไมการสร้างงานนำเสนอจึงล้มเหลวด้วยข้อความ "Error" ว่าง?**

บน Linux ตรวจสอบว่าได้ติดตั้งไลบรารี fontconfig (`libfontconfig1` บน Debian) แล้ว; หากไม่มี, ไลบรารีการวาดภาพแบบดิบไม่สามารถโหลดได้. บนระบบใดก็ตรวจสอบว่าคุณรันสคริปต์จากโฟลเดอร์โปรเจ็กต์

**ทำไม Node.js ถึงหยุดทำงานด้วย segmentation fault บน Linux?**

ระบบ OpenSSL และ OpenSSL ที่รวมอยู่ใน Node.js มาจากสายการปล่อยที่ต่างกัน. เปรียบเทียบตามที่แสดงใน [ข้อกำหนดเบื้องต้น](#prerequisites) และใช้ดิสโทรหรือบิลด์ Node.js ที่เวอร์ชันตรงกัน

**ฉันต้องทำการกู้คืน NuGet ซ้ำสำหรับทุกโปรเจ็กต์หรือไม่?**

ไม่จำเป็น. การกู้คืนเติมแคช NuGet สำหรับบัญชีผู้ใช้ของคุณ, และทุกโปรเจ็กต์บนเครื่องนั้นใช้แคชเดียวกัน