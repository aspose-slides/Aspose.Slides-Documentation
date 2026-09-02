---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown ใน .NET
linktitle: PowerPoint เป็น Markdown
type: docs
weight: 140
url: /th/net/convert-powerpoint-to-markdown/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น MD
- งานนำเสนอเป็น MD
- สไลด์เป็น MD
- PPT เป็น MD
- PPTX เป็น MD
- บันทึก PowerPoint เป็น Markdown
- บันทึกงานนำเสนอเป็น Markdown
- บันทึกสไลด์เป็น Markdown
- บันทึก PPT เป็น MD
- บันทึก PPTX เป็น MD
- ส่งออก PPT เป็น MD
- ส่งออก PPTX เป็น MD
- การส่งออกภาพ Markdown
- ลิงก์ภาพ CDN
- PowerPoint
- งานนำเสนอ
- Markdown
- .NET
- C#
- Aspose.Slides
description: "แปลงงานนำเสนอ PPT และ PPTX เป็น Markdown ใน .NET และควบคุมตำแหน่งการบันทึกและการอ้างอิงของภาพ bitmap, metafile และ SVG ที่ส่งออก"
---
## **ภาพรวม**

Aspose.Slides for .NET สามารถแปลงงานนำเสนอ PPT และ PPTX เป็น Markdown เพื่อใช้ในงานเอกสาร, เว็บไซต์แบบ static, การย้ายเนื้อหา, และกระบวนการควบคุมเวอร์ชันต่าง ๆ คุณสามารถเลือกรูปแบบ Markdown, ควบคุมวิธีการเรนเดอร์เนื้อหาสไลด์, และกำหนดตำแหน่งที่จัดเก็บภาพที่ส่งออกพร้อมกับวิธีที่ Markdown ที่สร้างขึ้นอ้างอิงถึงภาพเหล่านั้นได้

โดยค่าเริ่มต้น การส่งออก Markdown จะใช้ผลลัพธ์แบบข้อความเท่านั้น หากต้องการส่งออกเนื้อหาภาพ ให้ตั้งค่าคุณสมบัติ [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/exporttype/) เป็นค่า `Sequential` หรือ `Visual` จาก enumeration [MarkdownExportType](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownexporttype/) ค่า `Sequential` จะเรนเดอร์รายการสไลด์แยกออกมาและเรียงตามลำดับ ในขณะที่ `Visual` จะเก็บรายการที่จัดกลุ่มไว้ด้วยกันเพื่อรักษาความสัมพันธ์เชิงภาพ ค่า `TextOnly` จะไม่สร้างทรัพยากรภาพ ดังนั้นเหตุการณ์การบันทึกภาพจะไม่ถูกเรียกใช้ในโหมดนั้น

## **แปลงงานนำเสนอเป็น Markdown**

โหลดไฟล์ต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วเรียกใช้เมธอด [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) พร้อมค่าที่เป็น `Md` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **เลือกรูปแบบ Markdown**

คุณสมบัติ [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/flavor/) ควบคุมสเปค Markdown ที่ใช้สำหรับผลลัพธ์ Enumeration [Flavor](https://reference.aspose.com/slides/th/net/aspose.slides.export/flavor/) มีค่า CommonMark, GitHub Flavored Markdown และรูปแบบที่สนับสนุนอื่น ๆ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **ส่งออกภาพโดยใช้พฤติกรรมการบันทึกลงในเครื่องแบบค่าเริ่มต้น**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/) มีคุณสมบัติสองอย่างสำหรับภาพที่บันทึกในเครื่อง:

- [BasePath](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/basepath/) ระบุไดเรกทอรีฐานสำหรับเอกสาร Markdown และทรัพยากรของมัน
- [ImagesSaveFolderName](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) ระบุโฟลเดอร์ย่อยสำหรับภาพ ค่าเริ่มต้นคือ `Images`

ตัวอย่างต่อไปนี้เรนเดอร์เนื้อหาภาพ, เขียนภาพไปยัง `output/assets`, และสร้างการอ้างอิงภาพแบบ relative ในเอกสาร Markdown:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

พฤติกรรมนี้ยังทำหน้าที่เป็น fallback เมื่อตัวจัดการการบันทึกภาพแบบกำหนดเองส่งค่ากลับเป็น `false`

## **ปรับแต่งการบันทึกภาพและลิงก์ Markdown**

ใช้เหตุการณ์ [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/imagesaving/) สำหรับทรัพยากร bitmap และ metafile ที่ไม่ใช่ SVG ที่ถูกสร้างขึ้นระหว่างการส่งออก Markdown ตัวแทน [MarkdownImageSavingHandler](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) จะรับอ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/), [ImageFormat](https://reference.aspose.com/slides/th/net/aspose.slides/imageformat/), และลิงก์ Markdown ที่สร้างเป็นพารามิเตอร์ `ref string` ให้บันทึกหรืออัปโหลดภาพด้วยฟอร์แมตที่ระบุ แล้วแทนที่ `link` ด้วยอ้างอิงที่ต้องการปรากฏในผลลัพธ์ Markdown

ทรัพยากรที่ส่งออกในรูปแบบ SVG จะจัดการแยกต่างหาก ให้สมัครใช้งานเหตุการณ์ [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) ซึ่งตัวแทน [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) จะรับอ็อบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/) และพารามิเตอร์ `ref string link` SVG ไม่มีอาร์กิวเมนต์ `ImageFormat`; ให้เขียนหรืออัปโหลดข้อมูล XML จากคุณสมบัติ [ISvgImage.SvgData](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/svgdata/) แทน ขึ้นอยู่กับโหมดการส่งออกและการจัดกลุ่มเชิงภาพ SVG ในงานนำเสนอต้นทางอาจถูกแปลงเป็น raster หรือผสานกับเนื้อหาอื่น; ทรัพยากรที่ไม่ใช่ SVG ที่ได้จะแปรส่งต่อไปยัง `ImageSaving` สมัครใช้งานทั้งสองเหตุการณ์เมื่อทุกทรัพยากรภาพที่ส่งออกต้องการการประมวลผลแบบกำหนดเอง

ค่าที่ตัวจัดการส่งกลับจะกำหนดว่าใครเป็นผู้ประมวลผลภาพ:

- คืนค่า `true` หลังจากที่ตัวจัดการได้บันทึก, อัปโหลด, แปลง, หรือประมวลผลภาพใด ๆ แล้วกำหนดค่าที่ถูกต้องให้กับ `link` Aspose.Slides จะเขียนค่านั้นลงในเอกสาร Markdown และไม่ทำการบันทึกลงในเครื่องตามค่าเริ่มต้น
- คืนค่า `false` เพื่อให้ Aspose.Slides บันทึกภาพลงในเครื่องและสร้างลิงก์ตาม [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/basepath/) และ [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/)

{{% alert color="warning" title="Important" %}}
ตัวจัดการที่คืนค่า `true` จะรับผิดชอบต่อภาพ หากคืนค่า `true` โดยไม่ได้กำหนดลิงก์ที่มีค่าและไม่เป็นค่าว่าง การส่งออกจะล้มเหลวด้วย `InvalidOperationException`
{{% /alert %}}

### **บันทึกภาพไปยังไดเรกทอรีต้นทางของ CDN และใช้ URL ภายนอก**

ตัวอย่างต่อไปนี้ถือว่า `cdn-origin/presentations/quarterly-report` เป็นไดเรกทอรีต้นทางของ CDN ที่ถูกเมานท์หรือซิงค์ ตัวจัดการแต่ละตัวจะสกัดชื่อไฟล์ที่สร้างขึ้น, บันทึกภาพไปยังไดเรกทอรีที่กำหนดเองนั้น, และแทนที่การอ้างอิงแบบ local ที่สร้างขึ้นด้วย URL สาธารณะของ CDN ตัวอย่างไม่ได้ทำการอัปโหลดผ่านเครือข่าย: URL จะมีผลใช้ได้ก็ต่อเมื่อไดเรกทอรีถูกเมานท์เป็นต้นทาง CDN หรือไฟล์ถูกเผยแพร่ไปยัง CDN สำหรับการจัดเก็บแบบ object ให้เปลี่ยนการเขียนไฟล์ระบบเป็นการอัปโหลดด้วย SDK ของ storage แล้วกำหนด `link` หลังจากอัปโหลดสำเร็จ

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

ตัวจัดการ bitmap จะคืนค่า `false` อย่างเจตนาเมื่อภาพมีขนาดเล็กกว่า 128 × 128 พิกเซล ดังนั้น Aspose.Slides จะบันทึกภาพเหล่านั้นลงใน `output/fallback-images` ตามพฤติกรรมค่าเริ่มต้น ภาพ bitmap และ metafile ขนาดใหญ่ รวมถึงทรัพยากร SVG จะถูกจัดการโดยโค้ดกำหนดเอง ตัวอย่างเช่น การอ้างอิง local ที่สร้างขึ้นเช่น `fallback-images/image1.png` จะกลายเป็น `https://cdn.example.com/presentations/quarterly-report/image1.png` ตัวจัดการจะใช้เส้นทางของระบบปฏิบัติการเฉพาะเมื่อเขียนไฟล์; ลิงก์ที่เขียนลงใน Markdown จะใช้เครื่องหมายท แบ่งหน้า (forward slash) และชื่อไฟล์ที่ถูก Escape ตาม URL ให้ใช้กฎเดียวกันเมื่อสร้างลิงก์แบบ relative: ใช้ `/` ไม่ใช่ตัวคั่นไดเรกทอรีของแพลตฟอร์ม

## **คำถามที่พบบ่อย**

**สามารถใช้ตัวจัดการเดียวประมวลผลทั้งภาพ raster และภาพ SVG ได้หรือไม่?**

ไม่ได้ ใช้ [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/imagesaving/) สำหรับทรัพยากร bitmap และ metafile ที่ถูกส่งออกและใช้ [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) สำหรับทรัพยากรที่เป็น SVG ตัวแรกจะให้อ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) และ [ImageFormat](https://reference.aspose.com/slides/th/net/aspose.slides/imageformat/) ส่วนตัวหลังจะให้อ็อบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/) ที่ข้อมูล SVG สามารถอ่านได้จาก [ISvgImage.SvgData](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/svgdata/) SVG ที่ถูก rasterize ระหว่างการส่งออกจะถูกประมวลผลโดย `ImageSaving` แทน

**เกิดอะไรขึ้นเมื่อตัวจัดการการบันทึกภาพคืนค่า `false`?**

Aspose.Slides จะใช้พฤติกรรมการบันทึกลงในเครื่องตามค่าเริ่มต้น ตำแหน่งของภาพและลิงก์ที่สร้างจะถูกควบคุมโดย [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/basepath/) และ [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/th/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/)

**ตัวจัดการสามารถให้ URL โดยไม่บันทึกภาพลงในเครื่องได้หรือไม่?**

ได้ ตัวจัดการสามารถอัปโหลดภาพไปยัง object storage หรือส่งต่อไปยังบริการอื่น แล้วกำหนด URL ที่ได้ให้กับ `link` และคืนค่า `true` ตัวจัดการต้องทำการประมวลผลทั้งหมดเอง; การคืนค่า `true` จะป้องกันการบันทึกลงในเครื่องตามค่าเริ่มต้น

**ทำไมการส่งออก Markdown ถึงโยน `InvalidOperationException` จากตัวจัดการ?**

ข้อผิดพลาดนี้เกิดเมื่อตัวจัดการคืนค่า `true` แต่ไม่ได้ให้ลิงก์ที่ถูกต้อง ให้กำหนดเส้นทาง relative หรือ URL ภายนอกที่ต้องการเขียนลงใน Markdown ก่อนคืนค่า `true`

**ลิงก์ภาพควรใช้ตัวคั่นเส้นทางแบบไหน?**

ใช้เครื่องหมายท (forward slash) ในลิงก์ Markdown และ URL ใช้ `Path.Combine` เฉพาะสำหรับเส้นทางของระบบไฟล์ แล้วสร้างหรือทำให้ normalized การอ้างอิง Markdown แยกต่างหาก

**ลิงก์ไฮเปอร์ลิงก์จะถูกเก็บไว้ระหว่างการส่งออก Markdown หรือไม่?**

ใช่ ข้อความ [hyperlinks](/slides/th/net/manage-hyperlinks/) จะถูกเก็บเป็นลิงก์ Markdown ปกติ สไลด์ [transitions](/slides/th/net/slide-transition/) และ [animations](/slides/th/net/powerpoint-animation/) จะไม่ได้ถูกแปลง

**สามารถแปลงงานนำเสนอเป็น Markdown ได้แบบขนานหรือไม่?**

คุณสามารถประมวลผลไฟล์งานนำเสนอหลายไฟล์พร้อมกันได้ แต่ห้ามใช้อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เดียวกันระหว่างเธรด ให้ปฏิบัติตาม [multithreading guidelines](/slides/th/net/multithreading/) และสร้างอินสแตนซ์แยกสำหรับแต่ละไฟล์