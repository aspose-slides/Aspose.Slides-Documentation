---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในการนำเสนอโดยใช้ C++
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/cpp/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มภาพ
- เพิ่มบิตแมพ
- แทนที่รูปภาพ
- แทนที่ภาพ
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- ทรัพยากร SVG ภายนอก
- ตัวแก้ไข SVG
- ภาพ SVG ที่เชื่อมโยง
- ฟอนต์ SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ทำให้การจัดการรูปภาพใน PowerPoint และ OpenDocument ง่ายขึ้นด้วย Aspose.Slides สำหรับ C++ โดยเพิ่มประสิทธิภาพการทำงานและอัตโนมัติขั้นตอนของคุณ."
---
## **บทนำ**

รูปภาพทำให้การนำเสนอมีความน่าสนใจและดึงดูดสายตามากขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพลงในสไลด์จากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ ได้เช่นกัน อีกทั้ง Aspose.Slides ยังอนุญาตให้คุณเพิ่มรูปภาพลงในสไลด์นำเสนอได้หลายวิธี  

{{% alert title="เคล็ดลับ" color="info" %}} 

Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้คุณสร้างการนำเสนอจากรูปภาพได้อย่างรวดเร็ว  

{{% /alert %}}  

{{% alert title="ข้อมูล" color="info" %}}

หากต้องการเพิ่มรูปภาพเป็นกรอบรูป—โดยเฉพาะอย่างยิ่งถ้าต้องการปรับขนาด ใส่เอฟเฟกต์ หรือใช้ตัวเลือกการจัดรูปแบบมาตรฐานอื่น ๆ—ดูที่ [Picture Frame](/slides/th/cpp/picture-frame/)  

{{% /alert %}}  

{{% alert title="หมายเหตุ" color="warning" %}}

คุณสามารถแปลงรูปภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้ ดูหน้าเหล่านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/cpp/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/th/cpp/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/th/cpp/conversion/png-to-svg/), และ [SVG to PNG](https://products.aspose.com/slides/th/cpp/conversion/svg-to-png/)  

{{% /alert %}}

Aspose.Slides รองรับรูปภาพในรูปแบบยอดนิยม เช่น JPEG, PNG, BMP, GIF และอื่น ๆ  

## **เพิ่มรูปภาพที่จัดเก็บไว้ในเครื่องไปยังสไลด์**

คุณสามารถเพิ่มรูปภาพหนึ่งหรือหลายภาพที่จัดเก็บไว้ในคอมพิวเตอร์ของคุณลงในสไลด์การนำเสนอ ตัวอย่างโค้ด C++ ด้านล่างแสดงวิธีเพิ่มรูปภาพลงในสไลด์  

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **เพิ่มรูปภาพจากเว็บไปยังสไลด์**

หากรูปภาพที่ต้องการเพิ่มไม่มีอยู่ในเครื่องคุณ สามารถเพิ่มโดยตรงจากเว็บได้  

ตัวอย่างโค้ด C++ ด้านล่างแสดงวิธีเพิ่มรูปภาพจากเว็บลงในสไลด์  

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **เพิ่มรูปภาพไปยัง Slide Masters**

Slide master เก็บและควบคุมข้อมูลเช่น ธีมและเลย์เอาต์สำหรับสไลด์ที่ใช้มัน เมื่อคุณเพิ่มรูปภาพไปยัง slide master รูปภาพนั้นจะปรากฏบนทุกสไลด์ที่อ้างอิง master นี้  

ตัวอย่างโค้ด C++ ด้านล่างแสดงวิธีเพิ่มรูปภาพไปยัง slide master  

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **เพิ่มรูปภาพเป็นพื้นหลังของสไลด์**

คุณสามารถใช้รูปภาพเป็นพื้นหลังสำหรับหนึ่งหรือหลายสไลด์ ดูรายละเอียดได้ที่ *[Setting Images as Backgrounds for Slides](/slides/th/cpp/presentation-background/#setting-images-as-background-for-slides)*  

## **เพิ่ม SVG ไปยังการนำเสนอ**

สามารถเพิ่มเนื้อหา SVG ลงในการนำเสนอโดยใช้คลาส [SvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/svgimage/) วัตถุ [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/) ที่ได้จะถูกเพิ่มไปยังคอลเลกชันรูปภาพของการนำเสนอและใช้สร้างกรอบรูป  

ตัวอย่าง C++ ด้านล่างนำเข้า SVG string ที่รวมทุกอย่างไว้ในตัวเอง ทั้งภาพ สไตล์และทรัพยากรอื่น ๆ จะฝังอยู่ในเนื้อหา SVG  

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **นำเข้าเนื้อหา SVG ที่มีทรัพยากรภายนอก**

ไฟล์ SVG ที่ส่งออกจากเครื่องมือออกแบบ โปรแกรมวาดแผนภาพ หรือระบบไอคอนอาจอ้างอิงทรัพยากรที่อยู่นอกเอกสาร SVG เช่น ลิงก์รูปภาพ `images/photo.png` ค่าที่อยู่ CSS `url(...)` หรือ URL ของฟอนต์  

เพื่อทำการนำเข้าเนื้อหาแบบนี้ ให้สร้างการ 구현ของ [IExternalResourceResolver](https://reference.aspose.com/slides/th/cpp/aspose.slides.import/iexternalresourceresolver/) แล้วส่งพร้อมกับ Base URI ไปยังคอนสตรักเตอร์ `SvgImage` ที่เหมาะสม Base URI ระบุตำแหน่งของเอกสาร SVG เพื่อใช้แก้ลิงก์แบบ relative  

อินเทอร์เฟซ [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/) ให้เข้าถึงข้อมูลเกี่ยวกับ SVG ที่นำเข้า:

- `get_SvgContent()` คืนค่า markup ของ SVG เป็นสตริง
- `get_SvgData()` คืนค่าเนื้อหา SVG เป็นอาเรย์ของไบท์
- `get_BaseUri()` คืนค่า Base URI ที่ใช้สำหรับลิงก์แบบ relative
- `get_ExternalResourceResolver()` คืนค่า resolver ที่กำหนดให้กับรูปภาพ SVG  

### **สร้าง External Resource Resolver**

Resolver มีสองเมธอด:

- [ResolveUri](https://reference.aspose.com/slides/th/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) รวม Base URI และลิงก์ทรัพยากรแบบ relative แล้วคืนค่า URI แบบ absolute คืนสตริง null เมื่อไม่สามารถแก้ได้หรือไม่อนุญาต
- [GetEntity](https://reference.aspose.com/slides/th/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) คืน stream ที่อ่านได้สำหรับ URI ของทรัพยากรแบบ absolute คืน `nullptr` เมื่อทรัพยากรหาย ปิดกั้น หรือไม่สามารถเข้าถึงได้ สามารถคืน stream สำรองได้เมื่อเหมาะสม  

ตัวอย่าง resolver ด้านล่างโหลดทรัพยากรที่ลิงก์มาเฉพาะจากไดเรกทอรีภายในที่อนุญาต เท่านั้น ทรัพยากรเครือข่ายและเส้นทางภายนอกไดเรกทอรีที่อนุญาตจะถูกบล็อก และจะคืนรูปภาพสำรองสำหรับลิงก์รูปภาพที่ไม่สามารถแก้ได้  

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // ตัวแก้ไขนี้อนุญาตให้ใช้ไฟล์ในเครื่องเท่านั้น.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // ใช้ fallback เฉพาะสำหรับทรัพยากรรูปภาพเท่านั้น การคืนสตรีมรูปภาพ
        // สำหรับฟอนต์หรือสไตล์ชีทที่หายไปจะไม่ถูกต้อง.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **แก้ไขลิงก์ทรัพยากรระหว่างการนำเข้า SVG**

สมมติว่า `assets/diagram.svg` มีการอ้างอิงแบบ relative เช่น:  

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

ตัวอย่าง C++ ด้านล่างส่ง URI ของไฟล์ SVG เป็น Base URI และจัดหาตัว resolver แบบกำหนดเอง Resolver จะเปลี่ยนลิงก์รูปภาพแบบ relative ให้เป็น URI แบบ absolute แล้วคืน stream ที่มีทรัพยากรที่ลิงก์ไว้ในขณะที่ Aspose.Slides ประมวลผล SVG  

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// URI ฐานบ่งบอกตำแหน่งของเอกสาร SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage เปิดเผยเนื้อหาต้นฉบับ, ข้อมูลไบนารี, URI ฐาน, และตัวแก้ไข.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

คลาส `SvgImage` ยังมี overload ที่รับข้อมูล SVG เป็นอาเรย์ของไบท์หรือ stream พร้อมกับ external resource resolver และ Base URI  

{{% alert title="สำคัญ" color="warning" %}}

Resource resolver ทำให้ทรัพยากรภายนอกพร้อมใช้งานขณะ Aspose.Slides ประมวลผลและเรนเดอร์ SVG แต่ไม่แก้ไข markup ของ SVG ดั้งเดิมหรือฝังทรัพยากรที่แก้ไขไว้โดยอัตโนมัติ  

เมื่อ `ISvgImage` ถูกเพิ่มไปยังคอลเลกชันรูปภาพของการนำเสนอ ไฟล์ PPTX อาจมีทั้งการแสดงผล SVG ดั้งเดิมและ raster fallback image ทรัพยากรที่ลิงก์อาจปรากฏใน fallback image ส่วนลิงก์แบบ relative เช่น `images/photo.png` จะยังคงอยู่ใน SVG ที่เก็บไว้ แอปพลิเคชันที่เรนเดอร์ SVG แบบดั้งเดิมอาจละเว้นเนื้อหาที่ลิงก์เมื่อทรัพยากรภายนอกต้นฉบับไม่มีให้ใช้  

{{% /alert %}}

### **สร้างรูปภาพ SVG แบบพกพา**

เพื่อสร้างรูปภาพ SVG ที่ไม่พึ่งพาไฟล์ภายนอก ให้ทำให้ SVG เป็น self‑contained ก่อนสร้าง `SvgImage` ตัวอย่างเช่น แทนที่ URL ของรูปภาพที่ลิงก์ด้วย URI แบบ `data:` ที่มีข้อมูลภาพอยู่ในตัวเอง  

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

หลังจากฝังทรัพยากรทั้งหมดลงในเนื้อหา SVG แล้ว ให้สร้าง `SvgImage` เพิ่มไปยังคอลเลกชันรูปภาพของการนำเสนอ และแทรกลงในกรอบรูปตามตัวอย่างก่อนหน้า  

### **จัดการกับทรัพยากรที่หายหรือถูกบล็อก**

คืนสตริง null จาก `ResolveUri` เมื่อ URI ของทรัพยากรไม่ถูกต้อง ห้าม หรือไม่สามารถแก้ได้ คืน `nullptr` จาก `GetEntity` เมื่อไม่สามารถอ่านทรัพยากรได้ Aspose.Slides จะดำเนินการต่อโดยไม่มีทรัพยากรนั้นเมื่อตามที่เป็นไปได้  

สามารถคืน stream สำรองสำหรับทรัพยากรที่หายได้ แต่เนื้อหาจะต้องสอดคล้องกับประเภทของทรัพยากรที่ร้องขอ เช่น คืน stream ของภาพเท่านั้นสำหรับภาพที่หาย ไม่ใช่สำหรับฟอนต์หรือ stylesheet  

{{% alert title="ความปลอดภัย" color="warning" %}}

ห้ามแก้ไข path ของไฟล์ใด ๆ หรือ URL ของเครือข่ายโดยไม่มีการตรวจสอบจากไฟล์ SVG ที่ไม่เชื่อถือ จำกัดสกีม, ไดเรกทอรีและโฮสต์ที่อนุญาต สำหรับทรัพยากรเครือข่ายให้ตั้งค่า timeout, ขีดจำกัดขนาดการตอบกลับ และตรวจสอบเนื้อหา  

{{% /alert %}}

## **แปลง SVG เป็นชุดของ Shape**
Aspose.Slides สามารถแปลง SVG เป็นชุดของ shape ได้เช่นเดียวกับฟีเจอร์ใน PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

ฟีเจอร์นี้ให้โดย overload ของเมธอด [AddGroupShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/) ของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/) ที่รับอ็อบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/) เป็นอาร์กิวเมนต์แรก  

ตัวอย่างโค้ด C++ ด้านล่างแสดงวิธีใช้เมธอดนี้เพื่อแปลงไฟล์ SVG เป็นชุดของ shape  

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// ชื่อไฟล์ SVG ต้นฉบับ
auto svgFileName = System::String(u"sample.svg");

// ชื่อไฟล์การนำเสนอผลลัพธ์
auto outPptxPath = System::String(u"presentation.pptx");

// สร้างการนำเสนอใหม่
auto presentation = System::MakeObject<Presentation>();

// อ่านเนื้อหาไฟล์ SVG
auto svgContent = File::ReadAllText(svgFileName);

// สร้างอ็อบเจ็กต์ SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// รับขนาดสไลด์
auto slideSize = presentation->get_SlideSize()->get_Size();

// แปลงภาพ SVG เป็นกลุ่มของ shape และปรับสเกลให้พอกับขนาดสไลด์
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// บันทึกการนำเสนอในรูปแบบ PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **เพิ่มรูปภาพเป็น EMF ไปยังสไลด์**
Aspose.Slides สำหรับ C++ รองรับการสร้างภาพ EMF จากแผ่นงาน Excel ด้วย Aspose.Cells แล้วเพิ่มลงในสไลด์การนำเสนอ  

ตัวอย่างโค้ด C++ ด้านล่างแสดงวิธีทำ  

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells สำหรับ C++ ต้องเริ่มต้นก่อนใช้ประเภทใด ๆ ของมัน.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Render the worksheet as EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells ส่งคืนหน้าที่เรนเดอร์เป็นบัฟเฟอร์ ซึ่ง Aspose.Slides จะเพิ่มเป็นรูปภาพ.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **แทนที่รูปภาพใน Image Collection**

Aspose.Slides ให้คุณแทนที่รูปภาพที่เก็บในคอลเลกชันของการนำเสนอ รวมถึงรูปภาพที่ใช้โดย shape ของสไลด์ ส่วนนี้อธิบายวิธีอัปเดตรูปภาพในคอลเลกชันหลายวิธี คุณสามารถแทนที่รูปภาพโดยใช้ข้อมูลไบท์ดิบ, อินสแตนซ์ของ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) หรือรูปภาพอื่นที่มีอยู่แล้วในคอลเลกชัน  

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์การนำเสนอที่มีรูปภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
1. โหลดรูปภาพใหม่จากไฟล์เข้าสู่อาเรย์ไบท์
1. แทนที่รูปภาพเป้าหมายด้วยรูปภาพใหม่โดยใช้อาเรย์ไบท์
1. วิธีที่สอง โหลดรูปภาพเข้าสู่อ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) แล้วแทนที่รูปภาพเป้าหมายด้วยอ็อบเจ็กต์นั้น
1. วิธีที่สาม แทนที่รูปภาพเป้าหมายด้วยรูปภาพที่มีอยู่แล้วในคอลเลกชันของการนำเสนอ
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// วิธีแรก.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// วิธีที่สอง.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// วิธีที่สาม.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// บันทึกการนำเสนอลงไฟล์.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="ข้อมูล" color="info" %}}

ด้วยตัวแปลงฟรีของ Aspose [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) คุณสามารถทำให้ข้อความเคลื่อนไหวและสร้าง GIF จากข้อความได้อย่างง่ายดาย  

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความละเอียดของรูปภาพต้นฉบับจะคงเดิมหลังจากแทรกหรือไม่?**  

ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่ลักษณะสุดท้ายขึ้นอยู่กับการสเกลของ [picture](/slides/th/cpp/picture-frame/) บนสไลด์และการบีบอัดเมื่อตีค่าบันทึก  

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันบนหลายสิบสไลด์พร้อมกันคืออะไร?**  

วางโลโก้บน master slide หรือ layout แล้วแทนที่ในคอลเลกชันรูปภาพของการนำเสนอ—การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น  

**สามารถแปลง SVG ที่แทรกแล้วเป็น shape ที่แก้ไขได้หรือไม่?**  

ได้ คุณสามารถแปลง SVG เป็นกลุ่มของ shape แล้วส่วนย่อยต่าง ๆ จะสามารถแก้ไขได้ด้วยคุณสมบัติของ shape ปกติ  

**จะตั้งรูปภาพเป็นพื้นหลังของหลายสไลด์พร้อมกันอย่างไร?**  

[Assign the image as the background](/slides/th/cpp/presentation-background/) บน master slide หรือ layout ที่เกี่ยวข้อง—สไลด์ใดที่ใช้ master/layout นั้นจะสืบทอดพื้นหลังเดียวกัน  

**ทำอย่างไรเพื่อป้องกันไม่ให้การนำเสนอใหญ่เกินไปจากรูปภาพจำนวนมาก?**  

ใช้รูปภาพเดียวหลายครั้งแทนการทำซ้ำ เลือกความละเอียดที่เหมาะสม ใช้การบีบอัดเมื่อตีค่า และเก็บกราฟิกที่ซ้ำซ้อนไว้บน master หากเหมาะสม  