---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในการนำเสนอด้วย C++
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
- แบบอักษร SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ปรับกระบวนการจัดการรูปภาพใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++ เพื่อเพิ่มประสิทธิภาพการทำงานและอัตโนมัติขั้นตอนการทำงานของคุณ."
---
## **บทนำ**

ภาพทำให้การนำเสนอมีความน่าสนใจและดูเป็นภาพลักษณ์ที่ดียิ่งขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพลงในสไลด์จากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ เช่นเดียวกับ Aspose.Slides ที่อนุญาตให้คุณเพิ่มรูปภาพลงในสไลด์ของการนำเสนอได้หลายวิธี. 

{{% alert title="Tip" color="primary" %}} 

Aspose มีตัวแปลงฟรี—[JPEG เป็น PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG เป็น PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้คุณสร้างการนำเสนอจากภาพได้อย่างรวดเร็ว. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

หากคุณต้องการเพิ่มภาพเป็นกรอบรูป—โดยเฉพาะอย่างยิ่งหากคุณตั้งใจจะปรับขนาด ใส่เอฟเฟ็กต์ หรือใช้ตัวเลือกการจัดรูปแบบมาตรฐานอื่น ๆ—ดูที่ [กรอบรูป](/slides/th/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

คุณสามารถแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง ดูหน้าต่อไปนี้: แปลง [ภาพเป็น JPG](https://products.aspose.com/slides/th/cpp/conversion/image-to-jpg/), [JPG เป็นภาพ](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-image/), [JPG เป็น PNG](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-png/), [PNG เป็น JPG](https://products.aspose.com/slides/th/cpp/conversion/png-to-jpg/), [PNG เป็น SVG](https://products.aspose.com/slides/th/cpp/conversion/png-to-svg/), และ [SVG เป็น PNG](https://products.aspose.com/slides/th/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides รองรับรูปภาพในรูปแบบยอดนิยมเช่น JPEG, PNG, BMP, GIF และอื่น ๆ. 

## **เพิ่มรูปภาพที่จัดเก็บในเครื่องลงสไลด์**

คุณสามารถเพิ่มรูปภาพหนึ่งหรือหลายรูปที่จัดเก็บในคอมพิวเตอร์ของคุณลงในสไลด์การนำเสนอ ตัวอย่างโค้ด C++ ด้านล่างแสดงวิธีการเพิ่มรูปภาพลงสไลด์:

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



## **เพิ่มรูปภาพจากเว็บลงสไลด์**

หากรูปภาพที่คุณต้องการเพิ่มลงสไลด์ไม่ได้จัดเก็บในคอมพิวเตอร์ของคุณ คุณสามารถเพิ่มโดยตรงจากเว็บได้. 

ตัวอย่างโค้ด C++ ด้านล่างแสดงวิธีการเพิ่มรูปภาพจากเว็บลงสไลด์:

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

## **เพิ่มรูปภาพลงใน Slide Master**

Slide Master จะเก็บและควบคุมข้อมูลเช่นธีมและเลย์เอาต์สำหรับสไลด์ที่ใช้มัน เมื่อคุณเพิ่มรูปภาพลงใน Slide Master รูปภาพจะปรากฏบนทุกสไลด์ที่ใช้ Master นั้น. 

ตัวอย่างโค้ด C++ ด้านล่างแสดงวิธีการเพิ่มรูปภาพลงใน Slide Master:

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

## **เพิ่มรูปภาพเป็นพื้นหลังสไลด์**

คุณสามารถใช้รูปภาพเป็นพื้นหลังสำหรับสไลด์หนึ่งหรือหลายสไลด์ รายละเอียดเพิ่มเติมดูที่ *[ตั้งค่ารูปภาพเป็นพื้นหลังสำหรับสไลด์](/slides/th/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **เพิ่ม SVG ลงในการนำเสนอ**

เนื้อหา SVG สามารถเพิ่มลงในการนำเสนอโดยใช้คลาส [SvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/svgimage/) class. วัตถุ [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/) ที่ได้สามารถเพิ่มลงในคอลเลกชันทุกรูปภาพของการนำเสนอและใช้สร้างกรอบรูปได้. 

ตัวอย่าง C++ ด้านล่างนำเข้า SVG string ที่เป็นอิสระทั้งหมด ภาพ, สไตล์, และทรัพยากรอื่น ๆ ที่ใช้ใน SVG นี้จะถูฝังโดยตรงในเนื้อหา SVG:

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

## **นำเข้าเนื้อหา SVG พร้อมทรัพยากรภายนอก**

ไฟล์ SVG ที่ส่งออกจากเครื่องมือออกแบบ, ตัวแก้ไขแผนภาพ, ระบบไอคอน, และ pipeline ของเว็บอาจอ้างอิงถึงทรัพยากรที่เก็บนอกเอกสาร SVG ตัวอย่างเช่น SVG อาจมีลิงก์รูปภาพเช่น `images/photo.png`, ค่า CSS `url(...)`, หรือ URL ของฟอนต์. 

เพื่อทำการนำเข้าเนื้อหา SVG ดังกล่าว ให้สร้างการนำเข้า [IExternalResourceResolver](https://reference.aspose.com/slides/th/cpp/aspose.slides.import/iexternalresourceresolver/) และส่งพร้อมกับ base URI ไปยังคอนสตรักเตอร์ `SvgImage` ที่เหมาะสม Base URI จะระบุตำแหน่งของเอกสาร SVG และใช้ในการแก้ลิงก์แบบ relative. 

อินเตอร์เฟซ [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/) ให้เข้าถึงข้อมูลของ SVG ที่นำเข้า:

- `get_SvgContent()` คืนค่า markup ของ SVG ในรูปแบบสตริง
- `get_SvgData()` คืนค่าเนื้อหา SVG ในรูปแบบอาเรย์ของไบต์
- `get_BaseUri()` คืนค่า base URI ที่ใช้สำหรับลิงก์แบบ relative
- `get_ExternalResourceResolver()` คืนค่า resolver ที่กำหนดให้กับภาพ SVG

### **สร้างตัวแก้ไขทรัพยากรภายนอก**

Resolver มีสองเมธอด:

- [ResolveUri](https://reference.aspose.com/slides/th/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) รวม base URI กับลิงก์ทรัพยากรแบบ relative และคืนค่า URI สมบูรณ์ คืนค่าสตริง null เมื่อไม่สามารถแก้ลิงก์หรือไม่ได้รับอนุญาต
- [GetEntity](https://reference.aspose.com/slides/th/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) คืนค่า stream ที่อ่านได้สำหรับ URI ของทรัพยากรสมบูรณ์ คืนค่า `nullptr` เมื่อทรัพยากรหาย, ถูกบล็อก, หรือไม่พร้อมใช้งาน สามารถคืนค่า fallback stream ได้หากเหมาะสม

ตัวอย่าง resolver ด้านล่างโหลดทรัพยากรที่เชื่อมต่อเฉพาะจากไดเรกทอรีท้องถิ่นที่อนุญาต ทรัพยากรเครือข่ายและเส้นทางนอกไดเรกทอรีที่อนุญาตจะถูกบล็อก ภาพ fallback ทางเลือกจะถูกคืนสำหรับลิงก์รูปภาพที่ไม่ได้แก้ได้:

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

        // Resolver นี้ตั้งใจให้รับเฉพาะไฟล์ในเครื่องเท่านั้น.
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

        // ใช้ fallback เฉพาะสำหรับทรัพยากรภาพ. การคืน stream ของภาพ
        // สำหรับฟอนต์หรือสไตล์ชีตที่หายไปจะไม่ถูกต้อง.
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

### **แก้ไขลิงก์ทรัพยากรขณะนำเข้า SVG**

สมมติว่า `assets/diagram.svg` มีการอ้างอิงแบบ relative เช่น:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

ตัวอย่าง C++ ด้านล่างส่ง URI ของไฟล์ SVG เป็น base URI และให้ resolver แบบกำหนดเอง Resolver จะเปลี่ยนลิงก์รูปภาพแบบ relative ให้เป็น URI สมบูรณ์และคืน stream ที่มีทรัพยากรที่เชื่อมต่อในขณะ Aspose.Slides ประมวลผล SVG:

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

// URI ฐานแสดงตำแหน่งของเอกสาร SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage เปิดเผยเนื้อหาต้นฉบับ, ข้อมูลไบต์, URI ฐาน, และตัวแก้ไข.
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

คลาส `SvgImage` ยังมี overloads ที่รับข้อมูล SVG ในรูปแบบอาเรย์ไบต์หรือ stream พร้อมกับ external resource resolver และ base URI.

{{% alert title="Important" color="warning" %}}

Resolver จะทำให้ทรัพยากรภายนอกพร้อมใช้งานขณะ Aspose.Slides ประมวลผลและเรนเดอร์ SVG แต่ไม่แก้ไข markup ของ SVG ดั้งเดิมหรือฝังทรัพยากรที่แก้ไขโดยอัตโนมัติ

เมื่อ `ISvgImage` ถูกเพิ่มลงในคอลเลกชันทุกรูปภาพของการนำเสนอ ไฟล์ PPTX สามารถมีทั้งการแสดงผล SVG ดั้งเดิมและภาพ raster fallback ทรัพยากรที่เชื่อมต่ออาจปรากฏในภาพ fallback ที่สร้างขึ้นโดยที่ลิงก์แบบ relative เช่น `images/photo.png` ยังคงเดิมใน SVG ที่เก็บไว้ แอปพลิเคชันที่เรนเดอร์ SVG ดั้งเดิมอาจละเว้นเนื้อหาที่เชื่อมต่อเมื่อทรัพยากรภายนอกเดิมไม่พร้อมใช้งาน

{{% /alert %}}

### **สร้างภาพ SVG แบบพกพา**

เพื่อสร้างภาพ SVG ที่ไม่ขึ้นกับไฟล์ภายนอก ให้ทำให้ SVG เป็นอิสระก่อนสร้าง `SvgImage` ตัวอย่างเช่น แทนที่ URL ของรูปภาพที่เชื่อมต่อด้วย URI แบบ `data:` ที่มีข้อมูลรูปภาพ:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

หลังจากฝังทรัพยากรที่ต้องการทั้งหมดในเนื้อหา SVG แล้ว สร้าง `SvgImage` เพิ่มลงในคอลเลกชันทุกรูปภาพของการนำเสนอ และแทรกลงในกรอบรูปตามตัวอย่างก่อนหน้า.

### **จัดการทรัพยากรที่หายหรือถูกบล็อก**

คืนค่าสตริง null จาก `ResolveUri` เมื่อ URI ของทรัพยากรไม่ถูกต้อง, ถูกห้าม, หรือไม่สามารถแก้ได้ คืนค่า `nullptr` จาก `GetEntity` เมื่อไม่สามารถอ่านทรัพยากรได้ Aspose.Slides จะดำเนินการประมวลผล SVG ต่อไปโดยไม่มีทรัพยากรนั้นเมื่อเป็นไปได้

สามารถคืน fallback stream สำหรับทรัพยากรที่หายไปได้ แต่เนื้อหาต้องสอดคล้องกับประเภทของทรัพยากรที่ขอ ตัวอย่างเช่น คืน stream ของรูปภาพเฉพาะเมื่อรูปภาพหาย ไม่ใช่สำหรับฟอนต์หรือ stylesheet

{{% alert title="Security" color="warning" %}}

ห้ามแก้ไขเส้นทางไฟล์ใด ๆ หรือ URL เครือข่ายที่ไม่มีข้อจำกัดจากไฟล์ SVG ที่ไม่น่าเชื่อถือ จำกัด scheme, ไดเรกทอรี, และโฮสต์ที่อนุญาต สำหรับทรัพยากรเครือข่าย ควรกำหนดเวลาเชื่อมต่อ, ขนาดการตอบรับสูงสุด, และการตรวจสอบความถูกต้องของเนื้อหา

{{% /alert %}}

## **แปลง SVG เป็นชุดของรูปร่าง**
Aspose.Slides สามารถแปลง SVG เป็นชุดของรูปร่างได้เช่นเดียวกับฟังก์ชันที่สอดคล้องใน PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ให้โดย overload ของเมธอด [AddGroupShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/) ของอินเตอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/) ที่รับอ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/) เป็นอาร์กิวเมนต์แรก

ตัวอย่างโค้ด C++ ด้านล่างแสดงวิธีใช้เมธอดนี้เพื่อแปลงไฟล์ SVG เป็นชุดของรูปร่าง:

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

// สร้างอ็อบเจกต์ SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// รับขนาดสไลด์
auto slideSize = presentation->get_SlideSize()->get_Size();

// แปลงภาพ SVG เป็นกลุ่มของรูปร่างและปรับขนาดให้พอดีกับสไลด์
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// บันทึกการนำเสนอในรูปแบบ PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **เพิ่มรูปภาพเป็น EMF ลงในสไลด์**
Aspose.Slides for C++ อนุญาตให้คุณสร้างภาพ EMF จากแผ่นงาน Excel ด้วย Aspose.Cells และเพิ่มลงในสไลด์การนำเสนอ

ตัวอย่างโค้ด C++ ด้านล่างแสดงวิธีทำเช่นนี้:

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

// Aspose.Cells สำหรับ C++ ต้องเริ่มต้นก่อนที่จะใช้ประเภทใด ๆ ของมัน.
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
    // Aspose.Cells คืนหน้าที่เรนเดอร์เป็นบัฟเฟอร์ ซึ่ง Aspose.Slides จะเพิ่มเป็นภาพ.
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
Aspose.Slides ให้คุณแทนที่รูปภาพที่เก็บอยู่ใน Image Collection ของการนำเสนอ รวมถึงรูปภาพที่ใช้ในรูปร่างของสไลด์ ส่วนนี้อธิบายหลายวิธีในการอัปเดตรูปภาพในคอลเลกชัน คุณสามารถแทนที่รูปภาพโดยใช้ข้อมูลไบต์ดิบ, ตัวอย่าง [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) หรือรูปภาพอื่นที่มีอยู่ในคอลเลกชันแล้ว

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์การนำเสนอที่มีรูปภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
2. โหลดรูปภาพใหม่จากไฟล์เป็นอาเรย์ไบต์ 
3. แทนที่รูปภาพเป้าหมายด้วยรูปภาพใหม่โดยใช้ อาเรย์ไบต์ 
4. ในวิธีที่สอง โหลดรูปภาพลงในอ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) และแทนที่รูปภาพเป้าหมายด้วยอ็อบเจกต์นั้น 
5. ในวิธีที่สาม แทนที่รูปภาพเป้าหมายด้วยรูปภาพที่มีอยู่แล้วใน Image Collection ของการนำเสนอ 
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

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

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์การนำเสนอ.
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

// บันทึกการนำเสนอไปยังไฟล์.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

ด้วยตัวแปลงฟรี [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ของ Aspose คุณสามารถทำแอนิเมชันข้อความและสร้าง GIF จากข้อความได้อย่างง่ายดาย. 

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความละเอียดของรูปภาพดั้งเดิมยังคงเหมือนเดิมหลังการแทรกหรือไม่?**

ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่ลักษณะสุดท้ายขึ้นอยู่กับว่าภาพ [รูปภาพ](/slides/th/cpp/picture-frame/) ถูกปรับขนาดบนสไลด์อย่างไรและการบีบอัดใด ๆ ที่ใช้เมื่อบันทึก. 

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันบนหลายสิบสไลด์พร้อมกันคืออะไร?**

วางโลโก้บน master slide หรือ layout และแทนที่ใน Image Collection ของการนำเสนอ การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น. 

**สามารถแปลง SVG ที่แทรกเข้ามาให้เป็นรูปร่างที่แก้ไขได้หรือไม่?**

ใช่ คุณสามารถแปลง SVG เป็นกลุ่มของรูปร่าง ซึ่งแต่ละส่วนจะสามารถแก้ไขได้ด้วยคุณสมบัติมาตรฐานของรูปร่าง. 

**ฉันจะตั้งรูปภาพเป็นพื้นหลังสำหรับหลายสไลด์พร้อมกันได้อย่างไร?**

[กำหนดรูปภาพเป็นพื้นหลัง](/slides/th/cpp/presentation-background/) บน master slide หรือ layout ที่เกี่ยวข้อง—สไลด์ใด ๆ ที่ใช้ master/layout นั้นจะสืบทอดพื้นหลัง. 

**ฉันจะป้องกันไม่ให้การนำเสนอมีขนาดใหญ่เกินไปเนื่องจากรูปภาพจำนวนมากได้อย่างไร?**

ใช้ทรัพยากรรูปภาพเดียวซ้ำแทนการทำซ้ำ เลือกความละเอียดที่เหมาะสม ใช้การบีบอัดเมื่อบันทึก และเก็บกราฟิกที่ซ้ำกันบน master เมื่อจำเป็น.