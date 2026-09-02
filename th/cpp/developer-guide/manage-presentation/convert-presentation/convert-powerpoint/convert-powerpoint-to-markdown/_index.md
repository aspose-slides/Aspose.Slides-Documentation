---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown ใน C++
linktitle: PowerPoint ไปยัง Markdown
type: docs
weight: 140
url: /th/cpp/convert-powerpoint-to-markdown/
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
- การส่งออกรูปภาพ Markdown
- ลิงก์รูปภาพ CDN
- PowerPoint
- งานนำเสนอ
- Markdown
- C++
- Aspose.Slides
description: "แปลงงานนำเสนอ PPT และ PPTX เป็น Markdown ใน C++ และควบคุมตำแหน่งที่บันทึกและอ้างอิงรูปภาพ bitmap, metafile และ SVG ที่ส่งออก"
---
## **ภาพรวม**

Aspose.Slides for C++ สามารถแปลงงานนำเสนอ PPT และ PPTX เป็น Markdown เพื่อใช้ในเอกสาร, เว็บไซต์แบบ static, การย้ายเนื้อหา, และกระบวนการควบคุมเวอร์ชัน คุณสามารถเลือกรูปแบบ Markdown, ควบคุมการแสดงผลเนื้อหาในสไลด์, และกำหนดว่ารูปภาพที่ส่งออกจะถูกจัดเก็บที่ใดและ Markdown ที่สร้างขึ้นจะอ้างอิงรูปภาพอย่างไร

โดยค่าเริ่มต้น การส่งออก Markdown จะใช้รูปแบบข้อความเท่านั้น เพื่อส่งออกเนื้อหาภาพ ให้ตั้งค่าเมธอด [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) เป็นค่า `Sequential` หรือ `Visual` จาก enumeration [MarkdownExportType](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/markdownexporttype/) `Sequential` จะเรนเดอร์รายการสไลด์แยกกันและตามลำดับ ในขณะที่ `Visual` จะเก็บรายการที่จัดกลุ่มไว้ด้วยกันเพื่อรักษาความสัมพันธ์เชิงภาพ ค่า `TextOnly` จะไม่สร้างทรัพยากรรูปภาพ ดังนั้นเหตุการณ์การบันทึกรูปภาพจะไม่ถูกเรียกในโหมดนั้น

## **แปลงงานนำเสนอเป็น Markdown**

โหลดไฟล์ต้นทางด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) แล้วเรียกเมธอด [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) โดยใช้ค่า `Md` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/)

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **เลือกรูปแบบ Markdown**

เมธอด [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) ควบคุมสเปค Markdown ที่ใช้สำหรับผลลัพธ์ enumeration [Flavor](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/flavor/) มีค่า CommonMark, GitHub Flavored Markdown และรูปแบบอื่นที่สนับสนุน

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น CommonMark:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **ส่งออกรูปภาพโดยใช้พฤติกรรมการบันทึกแบบโลคัลเริ่มต้น**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/markdownsaveoptions/) มีเมธอดสองอย่างสำหรับกำหนดการบันทึกรูปภาพแบบโลคัล:
- [set_BasePath](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) ระบุไดเรกทอรีฐานสำหรับเอกสาร Markdown และทรัพยากรของมัน.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) ระบุโฟลเดอร์ย่อยสำหรับรูปภาพ ค่าเริ่มต้นคือ `Images`.

ตัวอย่างต่อไปนี้เรนเดอร์เนื้อหาภาพ, เขียนรูปภาพไปที่ `output/assets`, และสร้างการอ้างอิงรูปภาพแบบ relative ในเอกสาร Markdown:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

พฤติกรรมนี้ยังทำหน้าที่เป็น fallback เมื่อผู้จัดการบันทึกรูปภาพแบบกำหนดเองคืนค่า `false`.

## **ปรับแต่งการบันทึกรูปภาพและลิงก์ Markdown**

ใช้เหตุการณ์ `MarkdownSaveOptions::ImageSaving` สำหรับทรัพยากร bitmap และ metafile ที่ไม่ใช่ SVG ที่ส่งออกระหว่างการส่งออก Markdown ตัว delegate [MarkdownImageSavingHandler](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) จะได้รับอ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/), [ImageFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/imageformat/), และลิงก์ Markdown ที่สร้างขึ้นเป็นพารามิเตอร์ `System::String&`. บันทึกหรืออัปโหลดรูปภาพด้วยฟอร์แมตที่ให้มา และแทนที่ `link` ด้วยการอ้างอิงที่ต้องแสดงในผลลัพธ์ Markdown.

ทรัพยากรที่ส่งออกในรูปแบบ SVG จะได้รับการจัดการแยกต่างหาก สมัครรับเหตุการณ์ `MarkdownSaveOptions::SvgImageSaving` ซึ่ง delegate [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) จะได้รับอ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/) และพารามิเตอร์ `System::String& link`. SVG ไม่มีอาร์กิวเมนต์ `ImageFormat`; ให้เขียนหรืออัปโหลดข้อมูล XML ของมันโดยใช้เมธอด [ISvgImage::get_SvgData](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/get_svgdata/) แทน ขึ้นอยู่กับโหมดการส่งออกและการจัดกลุ่มเชิงภาพ SVG ในงานนำเสนออาจถูก rasterize หรือรวมกับเนื้อหาอื่น; ทรัพยากรที่ไม่เป็น SVG ที่ได้จะถูกส่งต่อไปยัง `ImageSaving`. สมัครรับเหตุการณ์ทั้งสองเมื่อทรัพยากรภาพทั้งหมดที่ส่งออกต้องการการประมวลผลแบบกำหนดเอง.

ค่าการคืนของ handler จะกำหนดว่าใครประมวลผลรูปภาพ:
- คืนค่า `true` เมื่อ handler ได้บันทึก, อัปโหลด, แปลง, หรือประมวลผลรูปภาพและกำหนดค่าที่ถูกต้องให้กับ `link`. Aspose.Slides จะเขียนค่านั้นไปยังเอกสาร Markdown และไม่ทำการบันทึกโลคัลตามค่าเริ่มต้น.
- คืนค่า `false` เพื่อให้ Aspose.Slides บันทึกรูปภาพในเครื่องและสร้างลิงก์ตาม [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) และ [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Handler ที่คืนค่า `true` จะรับผิดชอบต่อรูปภาพ หากคืนค่า `true` โดยไม่ได้กำหนดลิงก์ที่ถูกต้องและไม่ว่างเปล่า การส่งออกจะล้มเหลวด้วย `InvalidOperationException`.
{{% /alert %}}

### **บันทึกรูปภาพไปยังไดเรกทอรีต้นทาง CDN และใช้ URL ภายนอก**

ตัวอย่างต่อไปนี้ถือว่า `cdn-origin/presentations/quarterly-report` เป็นไดเรกทอรีต้นทาง CDN ที่ถูกเมานท์หรือซิงโครไนซ์ แต่ละ handler จะสกัดชื่อไฟล์ที่สร้าง, บันทึกรูปภาพไปยังไดเรกทอรีที่กำหนดเองนั้น, และแทนที่การอ้างอิงโลคัลที่สร้างด้วย URL CDN สาธารณะ ตัวอย่างไม่ได้ทำการอัปโหลดผ่านเครือข่าย: URL จะมีค่าใช้ได้หลังจากไดเรกทอรีถูกเมานท์เป็นต้นทาง CDN หรือไฟล์ถูกเผยแพร่ไปยัง CDN สำหรับการจัดเก็บแบบอ็อบเจ็กต์ ให้แทนที่การเขียนไฟล์ระบบด้วยการอัปโหลดผ่าน SDK ของ storage และกำหนดค่า `link` หลังจากอัปโหลดสำเร็จเท่านั้น.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Handler สำหรับ bitmap จะคืนค่า `false` อย่างตั้งใจสำหรับรูปภาพที่มีขนาดน้อยกว่า 128 × 128 พิกเซล ดังนั้น Aspose.Slides จะบันทึกรูปภาพเหล่านั้นไปที่ `output/fallback-images` โดยใช้พฤติกรรมเริ่มต้น รายการ bitmap และ metafile ที่ใหญ่กว่า รวมถึงทรัพยากร SVG จะถูกจัดการด้วยโค้ดกำหนดเอง ตัวอย่างเช่น การอ้างอิงโลคัลที่สร้างเช่น `fallback-images/image1.png` จะกลายเป็น `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handler จะใช้เส้นทางของระบบปฏิบัติการเฉพาะเมื่อเขียนไฟล์; ลิงก์ที่เขียนใน Markdown ใช้เครื่องหมายทับหน้า (`/`) และชื่อไฟล์ที่ escape ตาม URL. ใช้กฎเดียวกันเมื่อสร้างลิงก์ relative: ใช้ `/` ไม่ใช่เครื่องหมายแยกไดเรกทอรีของแพลตฟอร์ม.

## **คำถามที่พบบ่อย**

**Handler หนึ่งสามารถประมวลผลทั้งภาพ raster และ SVG ได้หรือไม่?**

ไม่. ใช้ `MarkdownSaveOptions::ImageSaving` สำหรับทรัพยากร bitmap และ metafile ที่ถูกส่งออก และใช้ `MarkdownSaveOptions::SvgImageSaving` สำหรับทรัพยากรที่ส่งออกเป็น SVG ตัวแรกจะให้อ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) และ [ImageFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/imageformat/); ตัวที่สองจะให้อ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/) ที่สามารถอ่านข้อมูล SVG ด้วย [ISvgImage::get_SvgData](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/get_svgdata/). SVG ต้นฉบับที่ถูก rasterize ระหว่างการส่งออกจะถูกประมวลผลโดย `ImageSaving` แทน.

**เกิดอะไรขึ้นเมื่อ handler การบันทึกรูปภาพคืนค่า `false`?**

Aspose.Slides จะใช้พฤติกรรมการบันทึกโลคัลเริ่มต้นของมัน ตำแหน่งรูปภาพและการอ้างอิงที่สร้างขึ้นจะถูกควบคุมโดย [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) และ [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Handler สามารถให้ URL โดยไม่บันทึกรูปภาพในเครื่องได้หรือไม่?**

ได้. Handler สามารถอัปโหลดรูปภาพไปยังที่เก็บอ็อบเจ็กต์หรือส่งต่อให้บริการอื่น, กำหนด URL ที่ได้ให้กับ `link`, และคืนค่า `true`. Handler ต้องทำการประมวลผลเสร็จเรียบร้อยเอง; การคืนค่า `true` จะป้องกันการบันทึกโลคัลตามค่าเริ่มต้น.

**ทำไมการส่งออก Markdown ถึงโยน `InvalidOperationException` จาก handler?**

ข้อยกเว้นนี้เกิดขึ้นเมื่อ handler คืนค่า `true` แต่ไม่ได้ให้ลิงก์ที่ถูกต้อง ให้กำหนดเส้นทาง relative หรือ URL ภายนอกที่ควรเขียนลงใน Markdown ก่อนคืนค่า `true`.

**ควรใช้เครื่องหมายแยกพาธแบบใดสำหรับลิงก์รูปภาพ?**

ควรใช้เครื่องหมายทับหน้า (`/`) ในลิงก์ Markdown และ URL. ใช้ `Path::Combine` เฉพาะสำหรับเส้นทางของระบบไฟล์, จากนั้นสร้างหรือทำให้การอ้างอิง Markdown เป็นรูปแบบปกติแยกต่างหาก.

**ลิงก์ไฮเปอร์เท็กซ์จะถูกเก็บไว้ในการส่งออก Markdown หรือไม่?**

ใช่. ข้อความ [hyperlinks](/slides/th/cpp/manage-hyperlinks/) จะถูกเก็บเป็นลิงก์ Markdown มาตรฐาน ส่วนสไลด์ [transitions](/slides/th/cpp/slide-transition/) และ [animations](/slides/th/cpp/powerpoint-animation/) จะไม่ถูกแปลง.

**งานนำเสนอสามารถแปลงเป็น Markdown อย่างขนานได้หรือไม่?**

คุณสามารถประมวลผลไฟล์งานนำเสนอหลายไฟล์พร้อมกันได้ แต่ไม่ควรแชร์อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เดียวกันระหว่างเธรด. ปฏิบัติตาม [multithreading guidelines](/slides/th/cpp/multithreading/) และใช้อินสแตนซ์แยกสำหรับแต่ละไฟล์.