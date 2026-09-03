---
title: จัดการคำเตือนการนำเสนอใน C++
type: docs
weight: 70
url: /th/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- คำเตือนคอลแบ็ก
- นโยบายคำเตือน
- การสูญเสียข้อมูล
- ความเสียหายของแหล่ง
- ปัญหาความเข้ากันได้
- การแทนที่ฟอนต์
- ลายเซ็นดิจิทัล
- การโหลดการนำเสนอ
- การเรนเดอร์การนำเสนอ
- การแปลงการนำเสนอ
- การบันทึกการนำเสนอ
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "เรียนรู้วิธีการรวบรวม, จำแนก, และดำเนินการกับคำเตือนระหว่างการโหลด, การเรนเดอร์, การแปลง, และการบันทึกการนำเสนอด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides สามารถรายงานปัญหาที่สามารถกู้คืนได้ในขณะโหลด, แสดงผล, แปลง หรือบันทึกการนำเสนอ ตัวอย่างเช่น บันทึกแหล่งที่เสียหาย, เนื้อหาที่ไม่สามารถเก็บรักษาได้, การแทนที่ฟอนต์, และข้อจำกัดของรูปแบบปลายทาง คอลแบ็กการเตือนให้แอปพลิเคชันบันทึกเงื่อนไขเหล่านี้และตัดสินใจว่าการดำเนินการปัจจุบันสามารถดำเนินต่อได้หรือไม่

ดำเนินการติดตั้งอินเทอร์เฟซ [IWarningCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides.warnings/iwarningcallback/) และตรวจสอบเมธอด [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/th/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) และ [IWarningInfo::get_Description](https://reference.aspose.com/slides/th/cpp/aspose.slides.warnings/iwarninginfo/get_description/) ที่มาจาก [IWarningInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides.warnings/iwarninginfo/). คืนค่า [ReturnAction::Continue](https://reference.aspose.com/slides/th/cpp/aspose.slides.warnings/returnaction/) เพื่อรับการเตือนหรือ `ReturnAction::Abort` เพื่อหยุดการดำเนินการ

ใช้ [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_warningcallback/) สำหรับคำเตือนที่เกิดขึ้นในขณะเปิดการนำเสนอ คลาสตัวเลือกการเรนเดอร์และส่งออกสืบทอดมาจาก [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveoptions/set_warningcallback/), ซึ่งรับคำเตือนจากการเรนเดอร์สไลด์, การแปลง, และการบันทึก เนื่องจากคำเตือนเองไม่ระบุการดำเนินการของแอปพลิเคชัน ให้ผสานแต่ละอินสแตนซ์คอลแบ็กกับขั้นตอนการดำเนินการเมื่อคุณสร้างรายงานรวม

## **คำเตือนและข้อยกเว้น**

คำเตือนอธิบายสภาวะที่ Aspose.Slides สามารถกู้คืนได้หากคอลแบ็กคืนค่า `ReturnAction::Continue` ข้อยกเว้นหมายถึงการดำเนินการที่ร้องขอไม่สามารถสำเร็จตามปกติ; ข้อยกเว้นจะไม่ถูกแปลงเป็นคำเตือนและไม่สามารถจัดการด้วยนโยบายคำเตือนได้

การคืนค่า `ReturnAction::Abort` จะให้ตัวจัดการคำเตือนยุติการดำเนินการปัจจุบันโดยการยกข้อยกเว้น ข้อยยกเว้นสาธารณะจะขึ้นอยู่กับการดำเนินการและรูปแบบการนำเสนอ ตัวอย่างเช่น การโหลดอาจส่งออก [PptxReadException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptxreadexception/) หรือ [PptReadException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptreadexception/), ในขณะที่การบันทึกหรือการส่งออกอาจส่งออก [PptxException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptxexception/). จัดการข้อยกเว้นที่ขอบเขตของการดำเนินการและใช้รายงานคำเตือนเพื่อกำหนดว่านโยบายของแอปพลิเคชันเป็นสาเหตุของการยุติหรือไม่ แทนที่จะพึ่งพาชนิดย่อยของข้อยกเว้นหรือข้อความเดียว คอลแบ็กบันทึกคำเตือนก่อนคืนค่า `ReturnAction::Abort` เพื่อให้เหตุผลยังคงสามารถเข้าถึงได้โดยแอปพลิเคชัน

## **ประเภทของคำเตือน**

การนับจำนวน [WarningType](https://reference.aspose.com/slides/th/cpp/aspose.slides.warnings/warningtype/) ให้รายการประเภทต่อไปนี้:

| ประเภทคำเตือน | ความหมาย | นโยบายทั่วไป |
| --- | --- | --- |
| `SourceFileCorruption` | การนำเสนอแหล่งที่มามีการเสียหายที่อาจทำให้เอกสารที่บันทึกในรูปแบบดั้งเดิมใช้งานไม่ได้. | ยกเลิก. |
| `DataLoss` | ข้อความ, แผนภูมิ, ภาพ, หรือข้อมูลอื่น ๆ อาจหายไปหลังจากการโหลดหรือบันทึก. | ยกเลิก. |
| `MajorFormattingLoss` | การนำเสนออาจสูญเสียการจัดรูปแบบที่สำคัญ. | ยกเลิกในโหมดตรวจสอบที่เข้มงวด; มิฉะนั้นบันทึกและดำเนินการต่อ. |
| `MinorFormattingLoss` | อาจเกิดความแตกต่างในการจัดรูปแบบที่จำกัด. | บันทึกเพื่อวินิจฉัยและดำเนินการต่อ. |
| `CompatibilityIssue` | ผลลัพธ์อาจไม่สามารถเปิดหรือทำงานได้อย่างถูกต้องในบางแอปพลิเคชันหรือเวอร์ชันเก่า. | บันทึกและดำเนินการต่อ เว้นแต่ความเข้ากันได้เป็นสิ่งจำเป็น. |
| `UnexpectedContent` | แหล่งที่มามีเนื้อหาที่ไม่รองรับหรือไม่รู้จักซึ่งผลกระทบอาจยังไม่ทราบ. | บันทึกและดำเนินต่อ, หรือถือเป็นข้อผิดพลาดในนโยบายที่เข้มงวด. |

ประเภทควรเป็นตัวกำหนดการตัดสินใจของนโยบาย เก็บคำอธิบายคำเตือนเพื่อการวินิจฉัย, แต่ไม่ควรอาศัยข้อความนั้นในการดำเนินตรรกะของแอปพลิเคชันเนื่องจากข้อความอาจแตกต่างกันระหว่างสถานการณ์คำเตือนและเวอร์ชันของผลิตภัณฑ์

## **รวบรวมและจำแนกคำเตือน**

ตัวอย่างต่อไปนี้ใช้รายงานระดับแอปพลิเคชันเดียวสำหรับสายการประมวลผลทั้งหมด อินสแตนซ์คอลแบ็กแยกต่างหากทำหน้าที่ติดป้ายคำเตือนจากการโหลด, การเรนเดอร์, การแปลงเป็น PDF, และการบันทึกเป็น PPTX นโยบายจะยกเลิกเมื่อตรวจพบการเสียหายของแหล่งหรือการสูญเสียข้อมูล, สามารถยกเลิกเพิ่มเติมเมื่อตรวจพบการสูญเสียการจัดรูปแบบสำคัญ, และดำเนินต่อสำหรับคำเตือนอื่น ๆ

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

ตั้งค่า `abortOnMajorFormattingLoss` เป็น `false` เมื่อความแตกต่างในการจัดรูปแบบสำคัญเป็นที่ยอมรับได้ ปัญหาความเข้ากันได้, การสูญเสียการจัดรูปแบบระดับย่อย, และเนื้อหาที่ไม่ได้คาดคิดยังคงถูกบันทึกในรายงานแม้ว่าการดำเนินการจะดำเนินต่อ Extend `WarningPolicy::GetAction` หากแอปพลิเคชันต้องปฏิเสธหนึ่งในประเภทเหล่านั้น

## **สถานการณ์คำเตือนทั่วไป**

คำเตือนสามารถปรากฏในขั้นตอนต่าง ๆ ของกระบวนการทำงาน:

- **ลายเซ็นดิจิทัล:** การนำเสนอที่ลงลายเซ็นอาจสร้างคำเตือนในระหว่างการโหลดว่า ลายเซ็นจะสูญหายระหว่างการประมวลผล Aspose.Slides รายงานสถานะ `DataLoss` นี้ผ่าน [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). คอลแบ็กในขั้นตอนโหลดทำให้แอปพลิเคชันสามารถปฏิเสธไฟล์หรือรับการสูญเสียที่รายงานไว้โดยชัดเจน
- **การแทนที่ฟอนต์:** ฟอนต์ที่ไม่มีอยู่สามารถถูกแทนที่ขณะสไลด์ถูกเรนเดอร์หรือส่งออก คำเตือนการแทนที่ฟอนต์ถูกรายงานเป็น `DataLoss` ดังนั้นนโยบายเข้มงวดด้านบนจะยกเลิกแม้ว่าการแทนที่จะเห็นว่าดี ในการสังเกตพฤติกรรมนี้, ใช้การนำเข้าที่มีข้อความในฟอนต์ที่ระบบไม่รองรับ คำอธิบายคำเตือนจะระบุตัวการแทนที่; ตั้งค่าฟอนต์ที่ต้องการหรือ [font substitution rules](/slides/th/cpp/font-substitution/) ก่อนลองใหม่
- **เนื้อหาที่ไม่รองรับหรือไม่คาดคิด:** ตัวโหลดอาจเจอบันทึกหรือฟีเจอร์ของการนำเสนอที่ไม่รู้จัก คำเตือนเหล่านี้อาจใช้ `UnexpectedContent` หรือประเภทที่รุนแรงกว่าเมื่อทราบว่าข้อมูลหรือการจัดรูปแบบได้รับผลกระทบ
- **ความเข้ากันได้ของรูปแบบ:** การบันทึกเป็นรูปแบบการนำเสนออื่นอาจตัดฟีเจอร์หรือทำให้ผลลัพธ์ทำงานแตกต่างในบางแอปพลิเคชัน ตัวอย่างเช่น การบันทึกการนำเสนอที่มีแนวนำภาพวาดแนวนอนหรือแนวตั้งมากกว่าจำนวนแปดใน PPT รุ่นเก่าจะรายงาน `CompatibilityIssue`. คอลแบ็กในขั้นตอนบันทึกสามารถบันทึกการสูญเสียและดำเนินต่อ, หรือปฏิเสธหากจำเป็นต้องเก็บแนวนำทั้งหมด
- **พฤติกรรมการโหลด:** ตัวเลือกการโหลดและพฤติกรรมรุ่นเก่ายังอาจสร้างคำเตือนได้ ตัวอย่างเช่น [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) ระบุการใช้พฤติกรรมการล็อกการนำเสนอที่ล้าสมัยเป็น `CompatibilityIssue`

คำเตือนขึ้นอยู่กับเอกสารแหล่ง, รูปแบบปลายทาง, การดำเนินการ, และเวอร์ชันของ Aspose.Slides อย่าสมมติว่าทุกไฟล์จะสร้างคำเตือนหรือว่าฉากใดฉากหนึ่งจะสอดคล้องกับเพียงหนึ่งประเภท

## **จัดการการดำเนินการที่ถูกยกเลิกอย่างปลอดภัย**

เมื่อคอลแบ็กคืนค่า `ReturnAction::Abort`, อย่าใช้วัตถุที่โหลดไม่สำเร็จและอย่าสมมติว่าการเรนเดอร์หรือผลลัพธ์การบันทึกสมบูรณ์ การดำเนินการอาจหยุดหลังจากสร้างไฟล์ผลลัพธ์แต่ก่อนเสร็จสมบูรณ์

บันทึกผลลัพธ์ที่ตรวจสอบแล้วในเส้นทางแยก เช่น `validated-output.pptx`. แทนที่การนำเสนอที่มีอยู่เฉพาะหลังจากการดำเนินการเสร็จสมบูรณ์, รายงานคำเตือนสอดคล้องกับนโยบายของแอปพลิเคชัน, และผลลัพธ์สามารถเปิดและตรวจสอบได้ วิธีนี้ช่วยหลีกเลี่ยงการทับไฟล์แหล่งที่ถูกต้องด้วยผลลัพธ์บางส่วนหรือถูกปฏิเสธ

รายงานคำเตือนที่ว่างเปล่าไม่ใช่การรับประกันว่าฟีเจอร์ทั้งหมดของแหล่งได้ถูกเก็บไว้ ปรับใช้การตรวจสอบเนื้อหาและการมองเห็นเพิ่มเติมตามที่แอปพลิเคชันต้องการ ดูเพิ่มเติมที่ [Open Presentations](/slides/th/cpp/open-presentation/) และ [Save Presentations](/slides/th/cpp/save-presentation/)

## **คำถามที่พบบ่อย**

**คอลแบ็กคำเตือนสามารถจัดการข้อผิดพลาดของ Aspose.Slides ทุกอย่างได้หรือไม่?**

ไม่. คอลแบ็กจัดการสภาวะที่กู้คืนได้ที่รายงานเป็นคำเตือน ข้อยยกเว้นที่เกิดแยกจากคอลแบ็กต้องถูกจัดการโดยแอปพลิเคชันรอบการเรียกโหลด, เรนเดอร์, แปลง หรือบันทึก

**การคืนค่า `ReturnAction::Continue` จะรับประกันผลลัพธ์ที่เหมือนกันทั้งหมดหรือไม่?**

ไม่. การคืนค่านี้เพียงให้งานดำเนินต่อไป เงื่อนไขที่รายงานอาจยังทำให้เกิดความแตกต่างของข้อมูล, การจัดรูปแบบ, หรือความเข้ากันได้ ดังนั้นต้องตรวจสอบประเภทและคำอธิบายของคำเตือนที่รวบรวมไว้

**แอปพลิเคชันจะระบุตัวการดำเนินการที่สร้างคำเตือนได้อย่างไร?**

สร้างอินสแตนซ์คอลแบ็กสำหรับแต่ละการดำเนินการและเก็บขั้นตอนที่กำหนดโดยแอปพลิเคชันพร้อมกับประเภทและคำอธิบายของคำเตือน ตามที่แสดงในตัวอย่าง