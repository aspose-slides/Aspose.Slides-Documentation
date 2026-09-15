---
title: จัดการคำเตือนงานนำเสนอใน Python ผ่าน Java
type: docs
weight: 90
url: /th/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback คำเตือน
- นโยบายคำเตือน
- การสูญเสียข้อมูล
- การเสียหายของแหล่งข้อมูล
- ปัญหาความเข้ากันได้
- การแทนที่ฟอนต์
- ลายเซ็นดิจิทัล
- การโหลดงานนำเสนอ
- การเรนเดอร์งานนำเสนอ
- การแปลงงานนำเสนอ
- การบันทึกงานนำเสนอ
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการรวบรวม จัดประเภท และจัดการกับคำเตือนระหว่างการโหลด การเรนเดอร์ การแปลง และการบันทึกงานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides สามารถรายงานปัญหาที่สามารถกู้คืนได้ในขณะที่ทำการโหลด, เรนเดอร์, แปลง, หรือบันทึกงานนำเสนอ ตัวอย่างได้แก่ ระเบียนต้นทางที่เสียหาย, เนื้อหาที่ไม่สามารถเก็บรักษาได้, การแทนที่ฟอนต์, และข้อจำกัดของรูปแบบเป้าหมาย Callback คำเตือนช่วยให้แอปพลิเคชันทดสอบสภาพเหล่านี้และตัดสินใจว่าปฏิบัติการปัจจุบันสามารถดำเนินต่อได้หรือไม่

ดำเนินการตามอินเทอร์เฟซ `IWarningCallback` ผ่าน `jpype.JProxy` และตรวจสอบค่าที่ส่งมาจาก `IWarningInfo` ได้แก่ `getWarningType` และ `getDescription` คืนค่า [ReturnAction.Continue](https://reference.aspose.com/slides/th/python-java/aspose.slides/returnaction/#Continue) เพื่อยอมรับคำเตือนหรือ [ReturnAction.Abort](https://reference.aspose.com/slides/th/python-java/aspose.slides/returnaction/#Abort) เพื่อหยุดปฏิบัติการ

ใช้ [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setWarningCallback) สำหรับคำเตือนที่เกิดขึ้นขณะเปิดงานนำเสนอ คลาสตัวเลือกการเรนเดอร์และการส่งออกสืบทอดจาก [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveoptions/#setWarningCallback) ซึ่งรับคำเตือนจากการเรนเดอร์สไลด์, การแปลง, และการบันทึก เพราะคำเตือนเองไม่ได้ระบุขั้นตอนของแอปพลิเคชัน จึงควรผูกแต่ละอินสแตนซ์ของ Callback กับขั้นตอนการทำงานเมื่อสร้างรายงานรวม

## **คำเตือนและข้อยกเว้น**

คำเตือนอธิบายสภาพที่ Aspose.Slides สามารถกู้คืนได้หาก Callback คืนค่า `ReturnAction.Continue` ข้อยกเว้นหมายถึงการทำงานที่ร้องขอไม่สามารถสำเร็จได้ตามปกติ; ข้อยกเว้นจะไม่ถูกแปลงเป็นคำเตือนและไม่สามารถจัดการด้วยนโยบายคำเตือน

การคืนค่า `ReturnAction.Abort` จะบอกตัวกระจายคำเตือนให้ยุติการทำงานปัจจุบันโดยการปล่อยข้อยกเว้น ข้อยกเว้นสาธารณะขึ้นอยู่กับการทำงานและรูปแบบของงานนำเสนอ ตัวอย่างเช่น การโหลดอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxreadexception/) หรือ [PptReadException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptreadexception/) ในขณะบันทึกหรือส่งออกอาจทำให้เกิด [PptxException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxexception/) จัดการข้อยกเว้นที่ขอบเขตของการทำงานและใช้รายงานคำเตือนเพื่อพิจารณาว่านโยบายของแอปพลิเคชันเป็นสาเหตุของการยุติหรือไม่ แทนการอิงเพียงประเภทข้อยกเว้นหรือข้อความเดียว Callback จะบันทึกคำเตือนก่อนคืนค่า `ReturnAction.Abort` เพื่อให้เหตุผลยังคงพร้อมสำหรับแอปพลิเคชัน

## **ประเภทของคำเตือน**

คลาส [WarningType](https://reference.aspose.com/slides/th/python-java/aspose.slides/warningtype/) ให้ค่าคงที่จำนวนเต็มสำหรับประเภทต่อไปนี้:

| ประเภทคำเตือน | ความหมาย | นโยบายปกติ |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/th/python-java/aspose.slides/warningtype/#SourceFileCorruption) | งานนำเสนอต้นทางมีการเสียหายที่อาจทำให้ไฟล์ที่บันทึกในรูปแบบเดิมใช้ไม่ได้ | Abort |
| [DataLoss](https://reference.aspose.com/slides/th/python-java/aspose.slides/warningtype/#DataLoss) | ข้อความ, แผนภูมิ, ภาพ หรือข้อมูลอื่นอาจหายไปหลังการโหลดหรือบันทึก | Abort |
| [MajorFormattingLoss](https://reference.aspose.com/slides/th/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | งานนำเสนออาจสูญเสียการจัดรูปแบบสำคัญ | Abort ในโหมดตรวจสอบเข้มงวด; มิฉะนั้นบันทึกและดำเนินต่อ |
| [MinorFormattingLoss](https://reference.aspose.com/slides/th/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | ความแตกต่างในการจัดรูปแบบที่จำกัดอาจเกิดขึ้น | บันทึกเพื่อวินิจฉัยและดำเนินต่อ |
| [CompatibilityIssue](https://reference.aspose.com/slides/th/python-java/aspose.slides/warningtype/#CompatibilityIssue) | ผลลัพธ์อาจไม่เปิดหรือทำงานอย่างถูกต้องในแอปพลิเคชันหรือเวอร์ชันเก่า | บันทึกและดำเนินต่อเว้นแต่ความเข้ากันได้เป็นข้อบังคับ |
| [UnexpectedContent](https://reference.aspose.com/slides/th/python-java/aspose.slides/warningtype/#UnexpectedContent) | แหล่งที่มามีเนื้อหาที่ไม่รองรับหรือไม่รู้จักและผลของมันอาจยังไม่แน่นอน | บันทึกและดำเนินต่อ, หรือถือเป็นข้อผิดพลาดในนโยบายเข้มงวด |

ประเภทควรเป็นตัวกำหนดการตัดสินใจนโยบาย เก็บค่าที่คืนโดย `getDescription` ไว้สำหรับการวินิจฉัย แต่ไม่ควรอิงเนื้อความของข้อความสำหรับตรรกะของแอปพลิเคชันเนื่องจากข้อความอาจแตกต่างระหว่างสถานการณ์คำเตือนและเวอร์ชันของผลิตภัณฑ์

## **รวบรวมและจัดประเภทคำเตือน**

ตัวอย่างต่อไปนี้ใช้รายงานระดับแอปพลิเคชันเดียวสำหรับขั้นตอนการประมวลผลทั้งหมด โดยแต่ละอินสแตนซ์ของ Callback จะทำเครื่องหมายคำเตือนจากการโหลด, เรนเดอร์, การแปลงเป็น PDF, และการบันทึกเป็น PPTX นโยบายจะยกเลิกเมื่อพบการเสียหายของแหล่งหรือการสูญเสียข้อมูล, สามารถยกเลิกเพิ่มเติมเมื่อเกิดการสูญเสียการจัดรูปแบบสำคัญ, และดำเนินต่อสำหรับคำเตือนอื่น ๆ

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

ส่ง `False` ไปยัง `abort_on_major_formatting_loss` เมื่อตั้งค่า `WarningPolicy` หากยอมรับความแตกต่างการจัดรูปแบบสำคัญ ปัญหาความเข้ากันได้, การสูญเสียการจัดรูปแบบเล็กน้อย, และเนื้อหาไม่คาดคิดยังคงถูกบันทึกในรายงานแม้ว่าการทำงานจะดำเนินต่อ อย่าลืมขยาย `WarningPolicy.get_action` หากแอปพลิเคชันต้องปฏิเสธประเภทใดประเภทหนึ่งเหล่านี้

## **สถานการณ์คำเตือนทั่วไป**

คำเตือนอาจปรากฏในขั้นตอนต่าง ๆ ของเวิร์กโฟลว์:

- **ลายเซ็นดิจิทัล:** งานนำเสนอที่มีลายเซ็นอาจสร้างคำเตือนระหว่างการโหลดว่า ลายเซ็นจะหายไประหว่างการประมวลผล Aspose.Slides รายงานสภาวะ `DataLoss` นี้ผ่าน `IPresentationSignedWarningInfo` Callback ระดับการโหลดช่วยให้แอปพลิเคชันปฏิเสธไฟล์หรือยอมรับการสูญเสียที่รายงานไว้โดยชัดเจน
- **การแทนที่ฟอนต์:** ฟอนต์ที่ไม่มีอยู่สามารถถูกแทนที่เมื่อสไลด์ถูกเรนเดอร์หรือส่งออก คำเตือนการแทนที่ฟอนต์จะถูกรายงานเป็น `DataLoss` ดังนั้นนโยบายเข้มงวดข้างต้นจะยกเลิกแม้ว่าแอปพลิเคชันจะมองว่าการแทนที่นั้นรับได้ เพื่อตรวจสอบพฤติกรรมนี้ ให้ใช้งานนำเสนอที่มีข้อความใช้ฟอนต์ที่รันไทม์ไม่มี ฟอนต์ที่แทนที่จะแสดงในคำอธิบายของคำเตือน; ตั้งค่าฟอนต์ที่จำเป็นหรือ [font substitution rules](/slides/th/python-java/font-substitution/) ก่อนลองใหม่
- **เนื้อหาที่ไม่รองรับหรือไม่คาดคิด:** ตัวโหลดอาจเจอระเบียนหรือฟีเจอร์ของงานนำเสนอที่ไม่รู้จัก คำเตือนเหล่านี้อาจใช้ `UnexpectedContent` หรือประเภทที่รุนแรงกว่าเมื่อข้อมูลหรือการจัดรูปแบบถูกกระทบ
- **ความเข้ากันได้ของรูปแบบ:** การบันทึกเป็นรูปแบบงานนำเสนออื่นอาจตัดฟีเจอร์หรือทำให้ผลลัพธ์ทำงานแตกต่างในบางแอป ตัวอย่างเช่น การบันทึกงานนำเสนอที่มีแนวไกด์วาดแนวนอนหรือแนวตั้งมากกว่าแปดเส้นไปยัง PPT เก่าจะรายงาน `CompatibilityIssue` Callback ระดับการบันทึกสามารถบันทึกการสูญเสียแล้วดำเนินต่อ หรือปฏิเสธหากจำเป็นต้องรักษาแนวไกด์ทั้งหมด
- **พฤติกรรมการโหลด:** ตัวเลือกการโหลดและพฤติกรรมแบบเก่าอาจสร้างคำเตือนได้ ตัวอย่างเช่น `IObsoletePresLockingBehaviorWarningInfo` ระบุการใช้พฤติกรรมล็อกงานนำเสนอที่ล้าสมัยเป็น `CompatibilityIssue`

คำเตือนขึ้นอยู่กับเอกสารแหล่ง, รูปแบบเป้าหมาย, การทำงาน, และเวอร์ชันของ Aspose.Slides ไม่ควรสมมติว่าไฟล์ทุกไฟล์จะสร้างคำเตือนหรือว่าฉากทัศน์ใด ๆ จะสอดคล้องกับประเภทเดียวเท่านั้น

## **การจัดการการดำเนินการที่ถูกยกเลิกอย่างปลอดภัย**

เมื่อ Callback คืนค่า `ReturnAction.Abort` อย่าใช้วัตถุที่โหลดไม่สำเร็จและอย่าสันนิษฐานว่าเอาต์พุตของการเรนเดอร์หรือการบันทึกเสร็จสมบูรณ์ การดำเนินการอาจหยุดหลังจากสร้างไฟล์เอาต์พุตแต่ก่อนที่จะเสร็จสมบูรณ์

บันทึกผลลัพธ์ที่ตรวจสอบแล้วไปยังพาธแยกต่างหาก เช่น `validated-output.pptx` แทนที่งานนำเสนอที่มีอยู่เฉพาะหลังจากการดำเนินการสำเร็จตามเงื่อนไข, รายงานคำเตือนสอดคล้องกับนโยบายของแอปพลิเคชัน, และสามารถเปิดตรวจสอบได้ นี้ช่วยหลีกเลี่ยงการเขียนทับไฟล์ต้นทางที่ถูกต้องด้วยผลลัพธ์บางส่วนหรือถูกปฏิเสธ

รายงานคำเตือนที่ว่างเปล่าไม่ได้รับประกันว่าฟีเจอร์ของแหล่งทั้งหมดได้ถูกเก็บรักษาไว้ ให้ทำการตรวจสอบเนื้อหาและภาพเพิ่มเติมตามที่แอปพลิเคชันต้องการ ดูเพิ่มเติมที่ [Open Presentations](/slides/th/python-java/open-presentation/) และ [Save Presentations](/slides/th/python-java/save-presentation/)

## **FAQ**

**Callback คำเตือนสามารถจัดการกับข้อผิดพลาดของ Aspose.Slides ทุกอย่างได้หรือไม่?**

ไม่ได้ มันจัดการกับสภาพที่สามารถกู้คืนได้และรายงานเป็นคำเตือน ข้อยกเว้นที่เกิดขึ้นโดยไม่มี Callback ต้องจัดการโดยแอปพลิเคชันรอบ ๆ การเรียกโหลด, เรนเดอร์, แปลง หรือบันทึก

**การคืนค่า `ReturnAction.Continue` รับประกันผลลัพธ์ที่เหมือนกันหรือไม่?**

ไม่ได้ มันเพียงอนุญาตให้การประมวลผลดำเนินต่อ สภาวะที่รายงานอาจยังทำให้เกิดความแตกต่างด้านข้อมูล, การจัดรูปแบบ, หรือความเข้ากันได้ ดังนั้นให้ตรวจสอบประเภทและรายละเอียดของคำเตือนที่รวบรวมไว้

**แอปพลิเคชันจะระบุตัวการทำงานที่ทำให้เกิดคำเตือนได้อย่างไร?**

สร้างอินสแตนซ์ของ Callback สำหรับแต่ละการทำงานและเก็บขั้นตอนที่กำหนดโดยแอปพลิเคชันพร้อมกับค่าที่คืนโดย `getWarningType` และ `getDescription` ตามที่แสดงในตัวอย่าง