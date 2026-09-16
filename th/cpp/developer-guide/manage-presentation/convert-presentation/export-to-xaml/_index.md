---
title: ส่งออกงานนำเสนอเป็น XAML ใน C++
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/cpp/export-to-xaml/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- PowerPoint เป็น XAML
- OpenDocument เป็น XAML
- งานนำเสนอเป็น XAML
- PPT เป็น XAML
- PPTX เป็น XAML
- ODP เป็น XAML
- บันทึก PPT เป็น XAML
- บันทึก PPTX เป็น XAML
- บันทึก ODP เป็น XAML
- ส่งออก PPT เป็น XAML
- ส่งออก PPTX เป็น XAML
- ส่งออก ODP เป็น XAML
- C++
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ใน C++ ด้วย Aspose.Slides - โซลูชันที่รวดเร็ว ไม่ต้องใช้ Office และรักษาเค้าโครงของคุณไว้ครบถ้วน."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการส่งออกงานนำเสนอ PowerPoint ไปเป็น XAML ด้วย Aspose.Slides รวมถึงการแนะนำสั้น ๆ เกี่ยวกับ XAML แสดงวิธีบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น และสาธิตวิธีปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความนี้ยังตอบคำถามทั่วไปบางข้อเกี่ยวกับฟอนต์สำรอง, ความเข้ากันได้ของสแตก XAML, และพฤติกรรมการส่งออกสไลด์ที่ซ่อนอยู่

## **เกี่ยวกับ XAML**

XAML คือภาษามาร์กอัปแบบ XML ที่ใช้ในการอธิบายส่วนติดต่อผู้ใช้ในเฟรมเวิร์กต่าง ๆ เช่น WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin.Forms

คุณสามารถทำงานกับไฟล์ XAML ในตัวออกแบบแบบวิชวลหรือเขียนและแก้ไขมาร์กอัปโดยตรงได้

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

ตัวอย่าง C++ ด้านล่างแสดงวิธีการส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

โดยค่าเริ่มต้น สไลด์ที่ส่งออกจะถูกบันทึกในโฟลเดอร์ย่อย `pres` ของไดเรกทอรีทำงานปัจจุบันของโปรเซส ซึ่งได้จาก [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/th/cpp/system.io/directory/getcurrentdirectory/) โฟลเดอร์จะถูกสร้างโดยอัตโนมัติและรูปภาพที่ต้องการก็จะถูกบันทึกไว้ที่นั่นด้วย

ชื่อโฟลเดอร์ผลลัพธ์จะถูกกำหนดจากชื่อไฟล์ต้นทางโดยไม่มีส่วนต่อท้าย สำหรับไฟล์ `pres.pptx` ไฟล์ผลลัพธ์จะมีชื่อว่า `pres/Slide_1.xaml`, `pres/Slide_2.xaml` เป็นต้น แม้ว่าคุณจะระบุพาธแบบเต็มให้กับงานนำเข้า ผลลัพธ์ก็ยังสร้างโฟลเดอร์โดยสัมพันธ์กับไดเรกทอรีทำงานปัจจุบัน แทนที่จะสร้างคู่ข้างกับไฟล์ต้นทาง

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกที่กำหนดเอง**

ใช้อินเทอร์เฟซ [IXamlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/ixamloptions/) เพื่อควบคุมวิธีที่ Aspose.Slides ส่งออกงานนำเสนอเป็น XAML

เพื่อบันทึกผลลัพธ์ไปยังตำแหน่งที่กำหนดเอง ให้ดำเนินการสร้าง [IXamlOutputSaver](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/ixamloutputsaver/) และส่งอ็อบเจกต์ที่คุณสร้างไปยังเมธอด [set_OutputSaver](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) ของ [XamlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/)

เพื่อรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ XAML ให้ส่งค่า `true` ไปยังเมธอด [set_ExportHiddenSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), ดังตัวอย่าง C++ ด้านล่าง:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **จับทั้งหมดของศิลปวัตถุ XAML ที่สร้างขึ้น**

การส่งออก XAML สามารถสร้างเอกสาร XAML สำหรับแต่ละสไลด์ที่ส่งออกพร้อมกับรูปภาพและทรัพยากรสนับสนุนแยกต่างหาก ส่งอ็อบเจกต์ [IXamlOutputSaver](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/ixamloutputsaver/) ที่กำหนดเองไปยัง [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) เพื่อรับศิลปวัตถุเหล่านี้แทนการใช้ตัวบันทึกไฟล์ระบบเริ่มต้น เริ่มการส่งออกด้วยเมธอด overload ของ [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) ที่รับ XAML options โดยเฉพาะ

### **ทำความเข้าใจวงจรการเรียกกลับ (Callback Lifecycle)**

ตัวส่งออกจะเรียก [IXamlOutputSaver::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) แยกกันสำหรับศิลปวัตถุแต่ละรายการ:

- `path` ระบุศิลปวัตถุและอาจรวมไดเรกทอรีสัมพันธ์ไว้ เก็บข้อมูลนี้ไว้เพราะ XAML อาจอ้างอิงทรัพยากรด้วยพาธสัมพันธ์
- `data` มีไบต์ของศิลปวัตถุ รูปภาพและทรัพยากรไบนารีอื่น ๆ ไม่ควรถูกแปลงเป็นข้อความ
- ตัวบันทึกต้องรับผิดชอบในการเก็บหรือทำให้ข้อมูลคงอยู่ก่อนคืนค่า ตัวอย่างจะคัดลอกอาเรย์ไบต์แต่ละอันไปยังหน่วยความจำของแอปพลิเคชัน
- ถือว่าการส่งออกสำเร็จเท่านั้นเมื่อเมธอดบันทึกงานนำเสนอคืนค่าและทุกการเรียกกลับทำงานสำเร็จ อย่าปกปิดข้อผิดพลาดของการจัดเก็บหรือเริ่มการเขียนในแบ็กกราวด์ที่ไม่ได้ตรวจสอบ หากการคงถาวรเกิดขึ้นต่อมาควรรายงานความสำเร็จโดยรวมหลังจากขั้นตอนนั้นสำเร็จด้วย

เมธอด [XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) ยังใช้กับตัวบันทึกที่กำหนดเองเช่นกัน การตั้งค่าเริ่มต้น `false` จะไม่รวมเอกสาร XAML ของสไลด์ที่ซ่อนอยู่ การตั้งค่าเป็น `true` จะรวมสไลด์เหล่านั้นและทรัพยากรที่จำเป็นสำหรับการส่งออก จำนวนทรัพยากรขึ้นอยู่กับงานนำเสนอ; อย่าสมมติว่าจะมีการเรียกกลับหนึ่งครั้งต่อสไลด์หรือเรียงลำดับการเรียกกลับแบบคงที่

### **ส่งออกไปยังหน่วยความจำและตรวจสอบศิลปวัตถุ**

ตัวอย่างเต็มนี้โหลด `pres.pptx`, รวบรวมศิลปวัตถุทั้งหมดใน [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/th/cpp/system.collections.generic/dictionary/), แล้วพิมพ์ชื่อ, ชนิด, และจำนวนไบต์ของแต่ละอัน คงชื่อที่ส่งมาครบถ้วน ชื่อซ้ำจะทำให้การรวบรวมล้มเหลวแทนการเขียนทับโดยเงียบ

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // ถอดรหัสเฉพาะ XAML เท่านั้น และเมื่อจำเป็นต้องตรวจสอบเป็นข้อความเท่านั้น
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

เรียก `InMemoryXamlExample::Run` จากแอปพลิเคชันของคุณ การตรวจสอบส่วนขยายเป็นประโยชน์สำหรับการตรวจสอบ; เก็บศิลปวัตถุทั้งหมดรวมถึงประเภททรัพยากรที่ไม่คุ้นเคย อย่าปลี่ยนแปลงไบต์เมื่อจัดเก็บหรือส่งต่อ ใช้ [Encoding::GetString](https://reference.aspose.com/slides/th/cpp/system.text/encoding/getstring/) พร้อมการเข้ารหัส UTF-8 เฉพาะสำหรับ XAML ที่ต้องการการประมวลผลเป็นข้อความ

### **บรรจุศิลปวัตถุที่รวบรวมไว้ในไฟล์ ZIP**

ตัวอย่างแยกนี้รวบรวมการส่งออก, ตรวจสอบชื่อ, และเขียนไบต์ต้นฉบับลงในไฟล์ ZIP ชื่อไฟล์ ZIP ที่ไม่ซ้ำกันจะแยกงานส่งออกที่ทำพร้อมกัน รายการใน ZIP ใช้สแลชแบบทแยงและคงไดเรกทอรีสัมพันธ์ ชื่อที่ไม่ปลอดภัยหรือชื่อที่ชนกันหลังการทำให้เป็นมาตรฐานจะทำให้แพคเกจทั้งหมดถูกปฏิเสธก่อนการเขียน

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // การบันทึกจะสรุปไดเรกทอรี ZIP; ปิดไฟล์ก่อนรายงานความสำเร็จ.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

เรียก `ZipXamlExample::Run` จากแอปพลิเคชันของคุณ ตัวอย่างใช้ `Aspose::Zip::ZipFile` จากไลบรารีรันไทม์ C++ เพื่อเขียนไฟล์ ZIP หนึ่งไฟล์; ตัวส่งออกเองจะไม่เขียนไฟล์ XAML หรือรูปภาพแยกออกมา สำหรับการจัดเก็บระยะไกล ให้แทนที่ขั้นตอนการเขียน ZIP ด้วยการอัปโหลดอาเรย์ไบต์ที่รวบรวมไว้ ใช้ตัวระบุงานส่งออกบวกกับชื่อศิลปวัตถุสัมพันธ์เต็มเป็นคีย์บลบ, หรือเก็บตัวระบุงาน, ชื่อสัมพันธ์, และข้อมูลไบนารีในแถวฐานข้อมูล เผยแพร่งานหลังจากการอัปโหลดทั้งหมดเสร็จหรือการทำธุรกรรมฐานข้อมูลคอมมิทแล้ว ทำความสะอาดเอาต์พุตบางส่วนหากการคงถาวรล้มเหลว

สำหรับงานนำเสนอขนาดใหญ่ ตัวบันทึกที่กำหนดเองสามารถคงถาวรศิลปวัตถุแต่ละอันโดยตรงไปยังที่เก็บของแอปพลิเคชันเพื่อหลีกเลี่ยงการเก็บสำเนาเพิ่มเติมของการส่งออกทั้งหมดในหน่วยความจำของแอป ตัวส่งออกยังคงรวบรวมศิลปวัตถุทั้งหมดในหน่วยความจำก่อนเรียกตัวบันทึก ให้การเรียกกลับแต่ละครั้งทำงานแบบซิงโครนัสจากมุมมองของตัวส่งออก: คืนค่าเฉพาะหลังจากปลายทางยอมรับไบต์และให้ความล้มเหลวถึงผู้เรียก

### **คงชื่อทรัพยากรและตรวจสอบการอ้างอิง**

- ปรับรูปแบบเครื่องหมายคั่นพาธเมื่อปลายทางต้องการ แต่ให้คงไดเรกทอรีสัมพันธ์ อย่าใช้เฉพาะ [Path::GetFileName](https://reference.aspose.com/slides/th/cpp/system.io/path/getfilename/) ถ้าหากชื่อที่สร้างทั้งหมดเป็นเอกลักษณ์และการอ้างอิงทรัพยากรยังคงถูกต้อง
- ใช้การตรวจสอบชื่อเฉพาะปลายทาง เมื่อเขียนไฟล์แยก ให้ปฏิเสธพาธที่เริ่มต้นด้วยรากและส่วนที่เจาะจงการเดินทาง, แก้ไขปลายทางด้วย [Path::GetFullPath](https://reference.aspose.com/slides/th/cpp/system.io/path/getfullpath/), และตรวจสอบให้แน่ใจว่ายังคงอยู่ภายใต้ไดเรกทอรีส่งออกที่ตั้งใจไว้, รวมเครื่องหมายคั่นไดเรกทอรีในการตรวจสอบ containment ใช้ไดเรกทอรีที่ควบคุมโดยแอปพลิเคชันโดยไม่มีลิงก์สัญลักษณ์ที่อาจเปลี่ยนเส้นทางการเขียน
- ใช้ตัวบันทึกและเนมสเปซการจัดเก็บแยกสำหรับแต่ละงานส่งออก ตรวจจับการชนกันหลังจากทำให้เครื่องหมายคั่นเป็นมาตรฐานและตามกฎการพิจารณาเคสของปลายทาง
- ก่อนการเผยแพร่ ให้พาร์สเอกสาร XAML แต่ละไฟล์เป็น XML และตรวจสอบการอ้างอิงทรัพยากรบนไฟล์ เช่น แอตทริบิวต์ `Source` หรือ `ImageSource` ของรูปภาพ แก้ไข URI สัมพัทธ์แต่ละรายการเทียบกับไดเรกทอรีของศิลปวัตถุ XAML ที่เกี่ยวข้อง, ทำให้ชื่อการจัดเก็บที่ได้เป็นมาตรฐาน, และยืนยันว่าคีย์ในดิกชันนารี, รายการ ZIP, หรือวัตถุที่เก็บนั้นมีอยู่ พิจารณา URI ภายนอกและนิพจน์มาร์กอัป XAML แยกต่างหากจากชื่อไฟล์สัมพันธ์

ตัวอย่างเช่น ถ้า `pres/Slide_1.xaml` อ้างอิง `images/image1.png`, ทรัพยากรที่เก็บต้องมีอยู่ที่ `pres/images/image1.png`. การเก็บแค่ `image1.png` เพียงอย่างเดียวจะทำให้ความสัมพันธ์นี้ขัดแย้ง สำหรับการจัดเก็บในวัตถุ, คงโครงสร้างเดียวกันใต้คีย์งานและทำให้ URL ของทรัพยากรเหล่านั้นเข้าถึงได้สำหรับผู้ใช้ XAML เปิดไฟล์ ZIP ที่เสร็จแล้วเพื่อตรวจสอบชื่อรายการและไบต์ของทรัพยากร, แล้วโหลดสไลด์ตัวอย่างในสภาพแวดล้อม XAML ปลายทางเพื่อยืนยันว่ารูปภาพถูก resolve อย่างถูกต้อง

## **คำถามที่พบบ่อย**

**ทำอย่างไรจึงจะรับประกันฟอนต์ที่คาดเดาได้เมื่อตัวฟอนต์ต้นฉบับไม่มีในเครื่อง?**

ใช้เมธอด [set_DefaultRegularFont](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) ใน [XamlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/) — มันจะทำหน้าที่เป็นฟอนต์สำรองระหว่างการส่งออกเมื่อฟอนต์ต้นฉบับหายไป อย่างไรก็ตาม ไม่ได้รับประกันว่า XAML ที่สร้างจะอ้างอิงฟอนต์สำรองหรือว่าฟอนต์จะมีอยู่ในเครื่องปลายทาง ตรวจสอบให้แน่ใจว่าฟอนต์ที่ XAML อ้างอิงพร้อมใช้งานในสภาพแวดล้อมที่จะแสดงผล

**XAML ที่ส่งออกออกแบบมาสำหรับ WPF เท่านั้นหรือสามารถใช้ได้กับสแตก XAML อื่นได้ด้วยหรือไม่?**

Aspose.Slides ส่งออก XAML ของ WPF ผ่าน API สาธารณะของมัน ความเข้ากันได้กับสแตก XAML อื่น เช่น UWP และ Xamarin.Forms ไม่ได้รับประกัน ควรทดสอบมาร์กอัปที่สร้างในสภาพแวดล้อมเป้าหมายของคุณ

**สไลด์ที่ซ่อนอยู่ได้รับการสนับสนุนหรือไม่, และจะป้องกันไม่ให้ส่งออกโดยค่าเริ่มต้นได้อย่างไร?**

โดยค่าเริ่มต้น สไลด์ที่ซ่อนอยู่จะไม่ถูกรวม คุณสามารถควบคุมพฤติกรรมนี้ได้ผ่านเมธอด [set_ExportHiddenSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) ใน [XamlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/) — ปิดการใช้งานเมธอดนี้หากคุณไม่ต้องการส่งออกสไลด์ที่ซ่อนอยู่