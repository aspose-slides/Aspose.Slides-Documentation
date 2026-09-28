---
title: ข้อกำหนดระบบ
type: docs
weight: 60
url: /th/net/system-requirements/
keywords:
- ข้อกำหนดระบบ
- แพลตฟอร์มที่รองรับ
- เฟรมเวิร์กเป้าหมาย
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบว่าต้องการอะไรบ้างสำหรับ Aspose.Slides for .NET ก่อนที่จะติดตั้ง: เฟรมเวิร์กที่แต่ละแพ็คเกจ NuGet ตั้งเป้า, ระบบปฏิบัติการและโปรเซสเซอร์ที่รองรับ, และไลบรารีและฟอนต์ที่ Linux ต้องการ."
---
## **บทนำ**

Aspose.Slides for .NET เป็นไลบรารีแบบสแตนด์อโลน: ไม่จำเป็นต้องมี Microsoft PowerPoint หรือ Microsoft Office. ไลบรารีนี้เผยแพร่เป็นแพ็คเกจ NuGet สองชุด, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) และ [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). ทั้งสองให้เนมสเปซและคลาส Aspose.Slides เดียวกัน; ความแตกต่างอยู่ที่เฟรมเวิร์กที่รองรับและวิธีการวาดสไลด์, ซึ่งกำหนดว่ามันทำงานที่ไหนและต้องการอะไรบ้าง.

บทความนี้ระบุเวอร์ชัน .NET และแพลตฟอร์มที่แต่ละแพ็คเกจรองรับ รวมถึงไลบรารีระบบและฟอนต์ที่ Linux ต้องการ, และสรุปด้วยโปรแกรมสั้นที่ตรวจสอบการตั้งค่าของคุณ. เพื่อเพิ่มแพ็คเกจไปยังโปรเจกต์, ดู [การติดตั้ง](/slides/th/net/installation/).

## **เวอร์ชัน .NET ที่รองรับ**

แต่ละแพ็คเกจมีการสร้าง Aspose.Slides หนึ่งรุ่นต่อเป้าหมายเฟรมเวิร์ก, และ NuGet จะเลือกรุ่นที่ตรงกับเฟรมเวิร์กเป้าหมายของโปรเจกต์คุณ.

| แพ็คเกจ | เฟรมเวิร์กเป้าหมายในแพ็คเกจ | โปรเจกต์ของคุณสามารถเลือกเป้าหมาย |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 หรือใหม่กว่า; .NET 6 หรือใหม่กว่า, รวมถึง .NET 8, .NET 9, และ .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 หรือใหม่กว่า, รวมถึง .NET 8, .NET 9, และ .NET 10 |

การสร้าง `netstandard2.0` ทำให้ไลบรารีคลาส .NET Standard 2.0 สามารถอ้างอิง Aspose.Slides.NET. แอปพลิเคชันที่ใช้ไลบรารีดังกล่าวจะรันรุ่นที่ตรงกับเฟรมเวิร์กของแอปเอง: ตัวอย่างเช่น แอป .NET 8 จะรันรุ่น `net6.0`.

## **ระบบปฏิบัติการและสถาปัตยกรรมที่รองรับ**

**Aspose.Slides.NET** มีโค้ดที่ไม่ขึ้นกับสถาปัตยกรรม (AnyCPU) ดังนั้นมันทำงานบนสถาปัตยกรรมของ runtime .NET ที่โหลดมัน. มันวาดสไลด์ผ่านไลบรารี System.Drawing.Common ของ Microsoft, ซึ่ง Microsoft รองรับ [เฉพาะบน Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). บน Linux, Aspose.Slides.NET จึงต้องการไลบรารี `libgdiplus` และสวิตช์เริ่มต้น, ที่อธิบายในส่วน [Linux](#linux). มันทำงานบนดิสทริบิวชัน Linux ที่มี `libgdiplus`, เช่น Debian, Ubuntu, และ Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** วาดสไลด์ด้วยเอนจินกราฟิกของตนเอง. เอนจินเป็นไลบรารีเนทีฟที่แพ็คเกจบรรจุไว้ในรุ่นต่อแพลตฟอร์ม, ดังนั้นแพ็คเกจทำงานได้เฉพาะบนแพลตฟอร์มเหล่านี้:

| ระบบปฏิบัติการ | สถาปัตยกรรม | หมายเหตุ |
|---|---|---|
| Windows | x86, x64 | Windows บน ARM64 ไม่รองรับ |
| Linux | x64, ARM64 | ต้องการ glibc 2.23 หรือใหม่กว่าบน x64 และ glibc 2.39 หรือใหม่กว่าบน ARM64 |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform ไม่ทำงานบน Alpine Linux หรือดิสทริบิวชันอื่นที่ใช้ musl แทน glibc, หรือบนดิสทริบิวชันที่มี glibc เก่าเช่น CentOS 7. ให้ใช้ Aspose.Slides.NET บนระบบเหล่านั้น.

บน Windows, ไลบรารีเนทีฟของ Aspose.Slides.NET6.CrossPlatform ใช้ Microsoft Visual C++ runtime (*MSVCP140.dll* และ *VCRUNTIME140.dll*, พร้อม *VCRUNTIME140_1.dll* บน x64). หากไฟล์เหล่านี้หายบนเครื่องเป้าหมาย, ให้ติดตั้ง [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

ทั้งสองแพ็คเกจต้องการไลบรารีระบบเพิ่มเติมบน Linux. หากไม่มี, ตัวอย่างแรกใน [สร้างงานนำเสนอ](/slides/th/net/create-presentation/) จะล้มเหลวด้วยข้อยกเว้นแทนการบันทึกไฟล์. คำสั่งด้านล่างใช้กับ Debian และ Ubuntu; บนดิสทริบิวชันเหล่านี้แต่ละไลบรารียังติดตั้งฟอนต์ DejaVu (`fonts-dejavu-core`) ด้วย, ทำให้ข้อความแสดงผลโดยไม่ต้องติดตั้งฟอนต์เพิ่มเติม.

### **Aspose.Slides.NET6.CrossPlatform**

ไลบรารี Linux ของแพ็คเกจต้องการไลบรารี `fontconfig`:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

หากไม่มี, การสร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) จะล้มเหลวด้วย `TypeInitializationException` ที่มี `DllNotFoundException` ระบุว่าไม่สามารถเปิด `libfontconfig.so.1`.

อิมเมจฐานที่มีขนาดเล็กอาจไม่มี `fontconfig` ด้วย. ตัวอย่างเช่นอิมเมจฐาน AWS Lambda สำหรับ .NET 8 ไม่มี `fontconfig` หรือฟอนต์ใดๆ. ในอิมเมจคอนเทนเนอร์ที่สร้างจากอิมเมจนี้, รัน `dnf install -y fontconfig`, ซึ่งยังติดตั้งฟอนต์ Noto Sans ด้วย.

### **Aspose.Slides.NET**

แพ็คเกจต้องการสองอย่างบน Linux:

1. ไลบรารี `libgdiplus`:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. สวิตช์ `System.Drawing.EnableUnixSupport`, เปิดใช้ที่จุดเริ่มต้นของแอปพลิเคชันก่อนเรียก Aspose.Slides ใดๆ. ใน *Program.cs* ที่ใช้ top‑level statements, ให้ใส่หลังคำสั่ง `using`:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

หากไม่มี `libgdiplus`, การบันทึกงานนำเสนอจะล้มเหลวด้วย `TypeInitializationException` ที่มี `DllNotFoundException` ระบุว่าไม่สามารถโหลด `libgdiplus`. หากไม่มีสวิตช์, ข้อยกเว้นภายในจะเป็น `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
สวิตช์ทำงานเฉพาะกับ System.Drawing.Common 6, เวอร์ชันที่ Aspose.Slides.NET พึ่งพา. Microsoft ได้ลบออกใน System.Drawing.Common 7. หากโปรเจกต์ของคุณอ้างอิง System.Drawing.Common 7 หรือใหม่กว่า, ไม่ว่าติดตั้ง `libgdiplus` แล้วหรือเปิดสวิตช์, Aspose.Slides.NET จะล้มเหลวบน Linux ด้วย `PlatformNotSupportedException`. ในกรณีนั้นให้ใช้ Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

บน Alpine Linux ให้ใช้ Aspose.Slides.NET พร้อมสวิตช์ที่อธิบายข้างต้น. อิมเมจ Alpine ปกติมักไม่มีฟอนต์, และ `libgdiplus` เพียงอย่างเดียวก็ไม่ติดตั้งฟอนต์, ดังนั้นให้ติดตั้ง `libgdiplus` พร้อมกับอย่างน้อยหนึ่งแพ็คเกจฟอนต์. หากไม่มีฟอนต์, การบันทึกงานนำเสนอจะล้มเหลวด้วยข้อผิดพลาดนี้:

```text
System.ArgumentException: Font '?' cannot be found.
```

**ตัวเลือก 1: ฟอนต์ DejaVu**

แนะนำให้ใช้แพ็คเกจ `ttf-dejavu`:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

บน Alpine รุ่นปัจจุบัน, `ttf-dejavu` จะติดตั้งแพ็คเกจ `font-dejavu`, ซึ่งยังรวม `fontconfig` และเครื่องมือฟอนต์ที่จำเป็น.

**ตัวเลือก 2: ฟอนต์พื้นฐานของ Microsoft**

หากงานนำเสนอของคุณใช้ฟอนต์ Microsoft เช่น Arial, Times New Roman, Courier New, หรือ Verdana, ให้ติดตั้งฟอนต์พื้นฐานของ Microsoft แทน. ขั้นตอน `update-ms-fonts` จะดาวน์โหลดฟอนต์ระหว่างการสร้างอิมเมจ, ดังนั้นการสร้างต้องมีการเชื่อมต่ออินเทอร์เน็ต:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **รองรับการทำงานระดับสากล (Globalization)**

ทั้งสองแพ็คเกจต้องการการสนับสนุนการทำงานระดับสากลของ .NET, ซึ่ง .NET บน Linux ให้บริการผ่านไลบรารี ICU. ใน [โหมด globalization‑invariant](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization), การสร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) จะล้มเหลวด้วย `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

บางอิมเมจคอนเทนเนอร์เปิดโหมดนี้โดยอัตโนมัติ. ตัวอย่างเช่นอิมเมจ runtime ของ .NET สำหรับ Alpine Linux (`runtime-deps`, `runtime`, และ `aspnet`) จะตั้งค่า `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` และไม่ได้รวม ICU. หากสร้างอิมเมจจากอิมเมจเหล่านี้, ให้ติดตั้ง ICU และปิดโหมดดังกล่าว:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

เช่นเดียวกัน, ตรวจสอบให้แน่ใจว่าไฟล์โปรเจกต์ของคุณไม่ได้ตั้งค่า `InvariantGlobalization` เป็น `true`.

## **ตรวจสอบการตั้งค่าของคุณ**

เพื่อยืนยันว่าแพ็คเกจและข้อกำหนดทั้งหมดพร้อมใช้งาน, รันโปรแกรมที่บันทึกงานนำเสนอและเรนเดอร์สไลด์เป็นภาพ. การบันทึกและการเรนเดอร์ใช้ไลบรารีกราฟิกและฟอนต์, ซึ่งเป็นสิ่งที่ข้อกำหนด Linux มีให้.

สร้างแอปพลิเคชันคอนโซลและเพิ่มแพ็คเกจตามที่อธิบายใน [การติดตั้ง](/slides/th/net/installation/), แทนที่เนื้อหาใน *Program.cs* ด้วยโค้ดด้านล่าง, แล้วรัน `dotnet run`. หากใช้ Aspose.Slides.NET บน Linux, ให้เพิ่มบรรทัดสวิตช์ `System.Drawing.EnableUnixSupport` ตามที่แสดงในส่วน [Linux](#linux) หลังคำสั่ง `using`. โปรแกรมใช้ top‑level statements และการประกาศ `using`, ซึ่งต้องการ C# 9 หรือใหม่กว่า. โปรเจกต์ที่เป้าหมายเป็น .NET 6 หรือใหม่กว่าจะใช้เวอร์ชัน C# ที่ใหม่โดยค่าเริ่มต้น; หากเป็นโปรเจกต์ที่เป้าหมายเป็น .NET Framework, ให้เพิ่ม `<LangVersion>latest</LangVersion>` ใต้ `PropertyGroup` ในไฟล์โปรเจกต์.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

โปรแกรมจะเพิ่มสี่เหลี่ยมพร้อมข้อความไปยังสไลด์แรกและบันทึกงานนำเสนอเป็นไฟล์ *hello.pptx* ด้วยเมธอด [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). จากนั้นจะเรนเดอร์สไลด์ด้วย [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) และบันทึกผลเป็น *hello.png* ด้วย [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) ในรูปแบบ [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). ค่า scale 1 จะเรนเดอร์หนึ่งพิกเซลต่อจุด, ดังนั้นสไลด์ขนาด 720 × 540 จุดจะเป็นภาพ 720 × 540 พิกเซล, โดยข้อความปรากฏภายในสี่เหลี่ยม. หากไม่มีใบอนุญาต, ทั้งสองไฟล์จะมีลายน้ำการประเมิน; ดู [การให้ลิขสิทธิ์](/slides/th/net/licensing/). หากขาดข้อกำหนดใด, โปรแกรมจะหยุดด้วยข้อยกเว้นหนึ่งในที่อธิบายในส่วน [Linux](#linux).

## **เครื่องมือสำหรับการพัฒนา**

คุณสามารถสร้างแอปพลิเคชันที่ใช้ Aspose.Slides ด้วยเครื่องมือใดก็ได้ที่สนับสนุนเฟรมเวิร์กเป้าหมายของโปรเจกต์: .NET SDK และ CLI `dotnet` บน Windows, Linux, และ macOS, หรือ Visual Studio บน Windows. ส่วน [การติดตั้ง](/slides/th/net/installation/) อธิบายรายละเอียดทั้งสองแบบ.

## **FAQ**

**จำเป็นต้องติดตั้ง Microsoft PowerPoint เพื่อทำการแปลงและเรนเดอร์หรือไม่?**

ไม่, ไม่จำเป็นต้องมี PowerPoint. Aspose.Slides เป็นเอนจินสแตนด์อโลนสำหรับ [การสร้าง](/slides/th/net/create-presentation/), การแก้ไข, [การแปลง](/slides/th/net/convert-presentation/), และ [การเรนเดอร์](/slides/th/net/convert-powerpoint-to-png/) งานนำเสนอ.

**ควรใช้แพ็คเกจใด?**

ใช้ Aspose.Slides.NET บน Windows และ Aspose.Slides.NET6.CrossPlatform บน Linux และ macOS. บน Alpine Linux, บนระบบ Linux ที่มี glibc เก่ากว่าที่ระบุข้างต้น, และในโปรเจกต์ที่เป้าหมายเป็น .NET Framework, ให้ใช้ Aspose.Slides.NET. เพิ่มเพียงหนึ่งในสองแพ็คเกจต่อโปรเจกต์.

**ต้องการฟอนต์อะไรสำหรับการเรนเดอร์ที่ถูกต้อง?**

ฟอนต์ที่ใช้ในงานนำเสนอ, หรือฟอนต์สำรองที่เหมาะสม, ต้องติดตั้งในระบบปฏิบัติการ. บน Linux และ macOS, ให้ติดตั้งแพ็คเกจฟอนต์ที่งานนำเสนอของคุณต้องการเพื่อให้การเรนเดอร์สอดคล้อง. บน Alpine Linux, ให้ติดตั้งอย่างน้อยหนึ่งแพ็คเกจฟอนต์นอกจาก `libgdiplus`, ตามที่อธิบายในส่วน [Alpine Linux](#alpine-linux).

**ทำไมฟอนต์ที่กำหนดเองจึงแสดงเป็นฟอนต์สำรองหรือข้อความหายบน Linux?**

หากไฟล์ฟอนต์มีบันทึกชื่อในตารางชื่อที่ไม่สอดคล้องหรือเสียหาย, ระบบจับคู่ฟอนต์ของ Linux (FreeType/fontconfig) อาจเลือกบันทึกที่ไม่ถูกต้อง, ทำให้ฟอนต์ไม่สามารถresolveได้. การใช้เวอร์ชันฟอนต์ที่แก้ไขบันทึกชื่อหรือการติดตั้งฟอนต์สำรองที่สอดคล้องจะแก้ปัญหา.