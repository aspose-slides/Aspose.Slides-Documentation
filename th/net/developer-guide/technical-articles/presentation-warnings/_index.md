---
title: จัดการคำเตือนงานนำเสนอใน .NET
type: docs
weight: 120
url: /th/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- การเรียกกลับคำเตือน
- นโยบายคำเตือน
- การสูญเสียข้อมูล
- ความเสียหายของแหล่งที่มา
- ปัญหาความเข้ากันได้
- การแทนที่ฟอนต์
- ลายเซ็นดิจิทัล
- การโหลดงานนำเสนอ
- การเรนเดอร์งานนำเสนอ
- การแปลงงานนำเสนอ
- การบันทึกงานนำเสนอ
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการรวบรวม แยกประเภท และดำเนินการกับคำเตือนขณะโหลด เรนเดอร์ แปลง และบันทึกงานนำเสนอด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides สามารถรายงานปัญหาที่สามารถกู้คืนได้ขณะโหลด, เรนเดอร์, แปลง, หรือบันทึกงานนำเสนอ ตัวอย่างได้แก่บันทึกแหล่งที่เสียหาย, เนื้อหาที่ไม่สามารถเก็บรักษาได้, การแทนที่ฟอนต์, และข้อจำกัดของรูปแบบเป้าหมาย คำเตือนแบบ callback ช่วยให้แอปพลิเคชันบันทึกเงื่อนไขเหล่านี้และตัดสินใจว่าการดำเนินการปัจจุบันจะดำเนินต่อได้หรือไม่

ใช้งานอินเทอร์เฟซ [IWarningCallback](https://reference.aspose.com/slides/th/net/aspose.slides.warnings/iwarningcallback/) และตรวจสอบคุณสมบัติ [WarningType](https://reference.aspose.com/slides/th/net/aspose.slides.warnings/iwarninginfo/warningtype/) และ [Description](https://reference.aspose.com/slides/th/net/aspose.slides.warnings/iwarninginfo/description/) ที่จัดเตรียมผ่าน [IWarningInfo](https://reference.aspose.com/slides/th/net/aspose.slides.warnings/iwarninginfo/). คืนค่ `ReturnAction.Continue` เพื่อยอมรับคำเตือนหรือ `ReturnAction.Abort` เพื่อหยุดการดำเนินการ

ใช้ [LoadOptions.WarningCallback](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/warningcallback/) สำหรับคำเตือนที่เกิดขณะเปิดงานนำเสนอ คลาสตัวเลือกการเรนเดอร์และส่งออกสืบทอดจาก [SaveOptions.WarningCallback](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveoptions/warningcallback/) ซึ่งรับคำเตือนจากการเรนเดอร์สไลด์, การแปลง, และการบันทึก เนื่องจากคำเตือนเองไม่ระบุการดำเนินการของแอปพลิเคชัน จึงควรเชื่อมแต่ละอินสแตนซ์ callback กับขั้นตอนการดำเนินการเมื่อสร้างรายงานรวม

## **คำเตือนและข้อยกเว้น**

คำเตือนอธิบายเงื่อนไขที่ Aspose.Slides สามารถกู้คืนได้หาก callback คืนค่า `ReturnAction.Continue` ข้อยกเว้นหมายถึงการดำเนินการที่ร้องขอไม่สามารถเสร็จสมบูรณ์ตามปกติ; ข้อยกเว้นจะไม่ถูกแปลงเป็นคำเตือนและไม่สามารถจัดการด้วยนโยบายคำเตือนได้

การคืนค่า `ReturnAction.Abort` จะสั่งให้ตัวกระจายคำเตือนยุติการดำเนินการปัจจุบันโดยการยกข้อยกเว้น ข้อยกเว้นสาธารณะขึ้นอยู่กับการดำเนินการและรูปแบบงานนำเสนอ ตัวอย่างเช่น การโหลดอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxreadexception/) หรือ [PptReadException](https://reference.aspose.com/slides/th/net/aspose.slides/pptreadexception/), ส่วนการบันทึกหรือส่งออกอาจทำให้เกิด [PptxException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxexception/). จัดการข้อยกเว้นที่ขอบเขตของการดำเนินการและใช้รายงานคำเตือนเพื่อตรวจสอบว่านโยบายของแอปพลิเคชันทำให้การหยุดเกิดขึ้นหรือไม่ แทนการพึ่งพาชนิดข้อยกเว้นหรือข้อความเดียว callback จะบันทึกคำเตือนก่อนคืนค่า `ReturnAction.Abort` ทำให้เหตุผลยังคงพร้อมให้แอปพลิเคชันเข้าถึง

## **ประเภทคำเตือน**

การอธิบายแบบ enumeration [WarningType](https://reference.aspose.com/slides/th/net/aspose.slides.warnings/warningtype/) มีประเภทต่อไปนี้:

| ประเภทคำเตือน | ความหมาย | นโยบายทั่วไป |
| --- | --- | --- |
| `SourceFileCorruption` | งานนำเสนอแหล่งที่มามีการเสียหายซึ่งอาจทำให้เอกสารที่บันทึกในรูปแบบเดิมใช้งานไม่ได้ | Abort |
| `DataLoss` | ข้อความ, แผนภูมิ, ภาพ หรือข้อมูลอื่น ๆ อาจหายไปหลังจากโหลดหรือบันทึก | Abort |
| `MajorFormattingLoss` | งานนำเสนออาจสูญเสียรูปแบบสำคัญ | Abort ในโหมดตรวจสอบแบบเคร่งครัด; มิฉะนั้นบันทึกและดำเนินต่อ |
| `MinorFormattingLoss` | ความแตกต่างของรูปแบบที่จำกัดอาจเกิดขึ้น | บันทึกเพื่อวินิจฉัยและดำเนินต่อ |
| `CompatibilityIssue` | ผลลัพธ์อาจไม่เปิดหรือทำงานอย่างถูกต้องในบางแอปพลิเคชันหรือเวอร์ชันเก่า | บันทึกและดำเนินต่อ เว้นแต่ความเข้ากันได้เป็นสิ่งจำเป็น |
| `UnexpectedContent` | แหล่งที่มามีเนื้อหาที่ไม่ได้รับการสนับสนุนหรือไม่รู้จักซึ่งผลกระทบอาจยังไม่ทราบ | บันทึกและดำเนินต่อ หรือจัดเป็นข้อผิดพลาดในนโยบายเคร่งครัด |

ประเภทควบคุมการตัดสินใจเชิงนโยบาย เก็บ `Description` เพื่อใช้วินิจฉัย, แต่ห้ามพึ่งพาข้อความของมันสำหรับตรรกะของแอปพลิเคชัน เนื่องจากข้อความอาจแตกต่างตามสถานการณ์และเวอร์ชันของผลิตภัณฑ์

## **รวบรวมและจัดประเภทคำเตือน**

ตัวอย่างต่อไปนี้ใช้รายงานระดับแอปพลิเคชันเดียวสำหรับสายการประมวลผลทั้งหมด อินสแตนซ์ callback แยกต่างหากทำเครื่องหมายคำเตือนจากการโหลด, เรนเดอร์, แปลงเป็น PDF, และการบันทึกเป็น PPTX นโยบายหยุดเมื่อพบการเสียหายของแหล่งที่มาหรือการสูญเสียข้อมูล, สามารถหยุดเพิ่มเติมเมื่อเกิดการสูญเสียรูปแบบสำคัญ, และดำเนินต่อสำหรับคำเตือนอื่น ๆ

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

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
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

กำหนด `abortOnMajorFormattingLoss` เป็น `false` เมื่อยอมรับความแตกต่างของรูปแบบสำคัญ ปัญหาความเข้ากันได้, การสูญเสียรูปแบบเล็กน้อย, และเนื้อหาที่ไม่คาดคิดยังคงถูกรักษาในรายงานแม้การดำเนินการจะดำเนินต่อได้ หากแอปพลิเคชันต้องปฏิเสธหมวดเหล่านี้เพิ่มเติม ให้ขยาย `WarningPolicy.GetAction`

## **สถานการณ์คำเตือนที่พบบ่อย**

คำเตือนอาจปรากฏในขั้นตอนต่าง ๆ ของกระบวนการทำงาน:

- **ลายเซ็นดิจิทัล:** งานนำเสนอที่ลงลายเซ็นอาจสร้างคำเตือนขณะโหลดว่า ลายเซ็นจะหายไประหว่างการประมวลผล Aspose.Slides รายงานเงื่อนไข `DataLoss` ผ่าน [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/th/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Callback ระดับโหลดช่วยให้แอปพลิเคชันปฏิเสธไฟล์หรือยอมรับการสูญเสียที่รายงานไว้โดยเจตนา
- **การแทนที่ฟอนต์:** ฟอนต์ที่ไม่มีอยู่สามารถถูกแทนที่ขณะเรนเดอร์หรือส่งออก คำเตือนการแทนที่ฟอนต์จะรายงานเป็น `DataLoss` ดังนั้นนโยบายเคร่งครัดข้างต้นจะหยุดแม้ว่าการแทนที่จะดูเหมาะสมเพื่อการแสดงผล เพื่อสังเกตพฤติกรรมนี้ ให้ใช้งานนำเสนอที่มีข้อความในฟอนต์ที่รันไทม์ไม่มี ฟอนต์ที่ถูกแทนที่จะระบุในคำอธิบายคำเตือน; ตั้งค่าฟอนต์ที่ต้องการหรือ [font substitution rules](/slides/th/net/font-substitution/) ก่อนลองใหม่
- **เนื้อหาที่ไม่สนับสนุนหรือไม่คาดคิด:** ตัวโหลดอาจเจอบันทึกหรือคุณลักษณะของงานนำเสนอที่ไม่รู้จัก คำเตือนเหล่านี้อาจใช้ `UnexpectedContent` หรือประเภทที่รุนแรงกว่าเมื่อข้อมูลหรือรูปแบบได้รับผลกระทบ
- **ความเข้ากันได้ของรูปแบบ:** การบันทึกเป็นรูปแบบงานนำเสนออื่นอาจละทิ้งคุณลักษณะหรือทำให้ผลลัพธ์ทำงานแตกต่างในบางแอปพลิเคชัน ตัวอย่างเช่น การบันทึกงานนำเสนอที่มีแนวทางวาดแนวนอนหรือแนวตั้งมากกว่าแปดเส้นลงใน PPT รุ่นเก่า จะรายงาน `CompatibilityIssue` Callback ระดับการบันทึกสามารถบันทึกการสูญเสียและดำเนินต่อ หรือปฏิเสธหากต้องการรักษาแนวทางทั้งหมด
- **พฤติกรรมการโหลด:** ตัวเลือกการโหลดและพฤติกรรมเก่าสามารถสร้างคำเตือนได้ ตัวอย่างเช่น [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/th/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) ระบุการใช้พฤติกรรมการล็อกงานนำเสนอที่ล้าสมัยเป็น `CompatibilityIssue`

คำเตือนขึ้นอยู่กับเอกสารแหล่งที่มา, รูปแบบเป้าหมาย, การดำเนินการ, และเวอร์ชันของ Aspose.Slides อย่าเชื่อว่าทุกไฟล์จะสร้างคำเตือนหรือว่าฉากทุกอย่างจะตรงกับเพียงประเภทเดียว

## **จัดการการดำเนินการที่ถูกยกเลิกอย่างปลอดภัย**

เมื่อ callback คืนค่า `ReturnAction.Abort` อย่าใช้วัตถุที่โหลดไม่สำเร็จและอย่าสมมติว่าการเรนเดอร์หรือผลลัพธ์การบันทึกสมบูรณ์ การดำเนินการอาจหยุดหลังจากสร้างไฟล์ผลลัพธ์แต่ก่อนที่จะเสร็จสมบูรณ์

บันทึกผลลัพธ์ที่ตรวจสอบแล้วในเส้นทางแยก เช่น `validated-output.pptx`. แทนที่งานนำเสนอที่มีอยู่เฉพาะหลังจากการดำเนินการเสร็จสมบูรณ์, รายงานคำเตือนสอดคล้องกับนโยบายแอปพลิเคชัน, และผลลัพธ์สามารถเปิดและตรวจสอบได้ วิธีนี้หลีกเลี่ยงการเขียนทับไฟล์ต้นฉบับที่ถูกต้องด้วยผลลัพธ์บางส่วนหรือถูกปฏิเสธ

รายงานคำเตือนที่ว่างเปล่าไม่รับประกันว่าฟีเจอร์ทุกอย่างของแหล่งที่มาถูกเก็บไว้ ให้ดำเนินการตรวจสอบเนื้อหาและภาพเพิ่มเติมตามที่แอปพลิเคชันต้องการ ดูเพิ่มเติมที่ [Open Presentations](/slides/th/net/open-presentation/) และ [Save Presentations](/slides/th/net/save-presentation/)

## **FAQ**

**Callback คำเตือนสามารถจัดการข้อผิดพลาดของ Aspose.Slides ทุกอย่างได้หรือไม่?**

ไม่. มันจัดการกับเงื่อนไขที่กู้คืนได้ซึ่งรายงานเป็นคำเตือน ข้อยกเว้นที่เกิดขึ้นโดยไม่ผ่าน callback ต้องจัดการโดยแอปพลิเคชันรอบการเรียกโหลด, เรนเดอร์, แปลง, หรือบันทึก

**การคืนค่า `ReturnAction.Continue` รับประกันการผลลัพธ์ที่เหมือนกันหรือไม่?**

ไม่. มันเพียงอนุญาตให้ดำเนินการต่อ เงื่อนไขที่รายงานอาจยังทำให้เกิดความแตกต่างของข้อมูล, รูปแบบ, หรือความเข้ากันได้ ดังนั้นควรตรวจสอบประเภทและคำอธิบายของคำเตือนที่เก็บรวบรวมไว้

**แอปพลิเคชันจะระบุตัวการดำเนินการที่สร้างคำเตือนได้อย่างไร?**

สร้างอินสแตนซ์ callback สำหรับแต่ละการดำเนินการและจัดเก็บขั้นตอนที่กำหนดโดยแอปพลิเคชันร่วมกับ `WarningType` และ `Description` ตามที่แสดงในตัวอย่าง