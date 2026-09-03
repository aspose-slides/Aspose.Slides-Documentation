---
title: จัดการการเตือนพรีเซนเทชันใน Java
type: docs
weight: 90
url: /th/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- คอลแบ็กการเตือน
- นโยบายการเตือน
- การสูญเสียข้อมูล
- ความเสียหายของแหล่งข้อมูล
- ปัญหาความเข้ากันได้
- การแทนที่ฟอนต์
- ลายเซ็นดิจิทัล
- การโหลดพรีเซนเทชัน
- การแสดงผลพรีเซนเทชัน
- การแปลงพรีเซนเทชัน
- การบันทึกพรีเซนเทชัน
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการรวบรวม จัดประเภท และดำเนินการกับการเตือนขณะโหลด, แสดงผล, แปลงและบันทึกพรีเซนเทชันด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Aspose.Slides สามารถรายงานปัญหาที่สามารถกู้คืนได้ขณะโหลด, แสดงผล, แปลง หรือบันทึกพรีเซนเทชัน ตัวอย่างเช่น บันทึกต้นทางที่เสียหาย, เนื้อหาที่ไม่สามารถรักษาไว้ได้, การแทนที่ฟอนต์, และข้อจำกัดของรูปแบบปลายทาง คอลแบ็กการเตือนช่วยให้แอปพลิเคชันบันทึกสภาวะเหล่านี้และตัดสินใจว่าการดำเนินการปัจจุบันสามารถดำเนินต่อได้หรือไม่

ทำการ Implement อินเทอร์เฟซ [IWarningCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarningcallback/) และตรวจสอบค่าที่ให้โดย [getWarningType](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getWarningType--) และ [getDescription](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getDescription--) ผ่าน [IWarningInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/)。คืนค่า [ReturnAction.Continue](https://reference.aspose.com/slides/th/java/com.aspose.slides/returnaction/#Continue) เพื่อรับการเตือนหรือ [ReturnAction.Abort](https://reference.aspose.com/slides/th/java/com.aspose.slides/returnaction/#Abort) เพื่อหยุดการดำเนินการ

ใช้ [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) สำหรับการเตือนที่เกิดขึ้นขณะเปิดพรีเซนเทชัน การแสดงผลและคลาสตัวเลือกการส่งออกสืบทอดจาก [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), ซึ่งรับการเตือนจากการแสดงสไลด์, การแปลง, และการบันทึก เนื่องจากการเตือนเองไม่ได้ระบุการดำเนินการของแอปพลิเคชัน จึงควรเชื่อมแต่ละอินสแตนซ์ของคอลแบ็กกับขั้นตอนการดำเนินการเมื่อสร้างรายงานรวม

## **การเตือนและข้อยกเว้น**

การเตือนอธิบายสภาวะที่ Aspose.Slides สามารถกู้คืนได้หากคอลแบ็กคืนค่า `ReturnAction.Continue` ข้อยกเว้นหมายถึงการดำเนินการที่ร้องขอไม่สามารถสำเร็จตามปกติ; ข้อยกเว้นจะไม่ถูกแปลงเป็นการเตือนและไม่สามารถจัดการด้วยนโยบายการเตือนได้

การคืนค่า `ReturnAction.Abort` จะขอให้ตัวจัดการการเตือนยุติการดำเนินการปัจจุบันโดยการโยนข้อยกเว้น ข้อยกเว้นสาธารณะขึ้นอยู่กับการดำเนินการและรูปแบบพรีเซนเทชัน ตัวอย่างเช่น การโหลดอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxreadexception/) หรือ [PptReadException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptreadexception/), ในขณะที่การบันทึกหรือการส่งออกอาจทำให้เกิด [PptxException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxexception/). ให้จัดการข้อยกเว้นที่ขอบเขตของการดำเนินการและใช้รายงานการเตือนเพื่อกำหนดว่านโยบายของแอปพลิเคชันเป็นสาเหตุของการยุติหรือไม่ แทนการพึ่งพาชนิดย่อยของข้อยกเว้นหรือข้อความใดข้อความหนึ่ง คอลแบ็กบันทึกการเตือนก่อนคืนค่า `ReturnAction.Abort`, ทำให้เหตุผลยังคงพร้อมใช้งานสำหรับแอปพลิเคชัน

## **ประเภทการเตือน**

คลาส [WarningType](https://reference.aspose.com/slides/th/java/com.aspose.slides/warningtype/) มีค่าคงที่จำนวนเต็มสำหรับหมวดหมู่ต่อไปนี้:

| ประเภทการเตือน | ความหมาย | นโยบายทั่วไป |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/th/java/com.aspose.slides/warningtype/#SourceFileCorruption) | พรีเซนเทชันต้นทางมีความเสียหายที่อาจทำให้เอกสารที่บันทึกในรูปแบบเดิมใช้ไม่ได้ | Abort. |
| [DataLoss](https://reference.aspose.com/slides/th/java/com.aspose.slides/warningtype/#DataLoss) | ข้อความ, แผนภูมิ, รูปภาพ หรือข้อมูลอื่นอาจหายไปหลังการโหลดหรือบันทึก | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/th/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | พรีเซนเทชันอาจสูญเสียการจัดรูปแบบที่สำคัญ | Abort ในโหมดตรวจสอบเข้มงวด; มิฉะนั้นบันทึกและดำเนินต่อ |
| [MinorFormattingLoss](https://reference.aspose.com/slides/th/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | ความแตกต่างในการจัดรูปแบบที่จำกัดอาจเกิดขึ้น | บันทึกเพื่อการวินิจฉัยและดำเนินต่อ |
| [CompatibilityIssue](https://reference.aspose.com/slides/th/java/com.aspose.slides/warningtype/#CompatibilityIssue) | ผลลัพธ์อาจไม่เปิดหรือทำงานถูกต้องในบางแอปพลิเคชันหรือเวอร์ชันเก่า | บันทึกและดำเนินต่อ นอกจากความเข้ากันได้เป็นข้อบังคับ |
| [UnexpectedContent](https://reference.aspose.com/slides/th/java/com.aspose.slides/warningtype/#UnexpectedContent) | แหล่งที่มามีเนื้อหาที่ไม่รองรับหรือไม่รู้จักและผลของมันอาจยังไม่ชัดเจน | บันทึกและดำเนินต่อ หรือถือเป็นข้อผิดพลาดในนโยบายเข้มงวด |

หมวดหมู่ควรเป็นตัวกำหนดการตัดสินใจเรื่องนโยบาย เก็บค่าที่คืนจาก [getDescription](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getDescription--) เพื่อใช้ในการวินิจฉัย, แต่ห้ามพึ่งพาข้อความของมันสำหรับตรรกะของแอปพลิเคชัน เนื่องจากข้อความอาจแตกต่างระหว่างสถานการณ์การเตือนและเวอร์ชันของผลิตภัณฑ์

## **การรวบรวมและจัดประเภทการเตือน**

ตัวอย่างต่อไปนี้ใช้รายงานระดับแอปพลิเคชันเดียวสำหรับกระบวนการทั้งหมด อินสแตนซ์คอลแบ็กแยกต่างหากทำเครื่องหมายการเตือนจากการโหลด, การแสดงผล, การแปลงเป็น PDF, และการบันทึกเป็น PPTX นโยบายจะยุติการทำงานเมื่อพบการเสียหายของต้นทางหรือการสูญเสียข้อมูล, เลือกที่จะยุติเมื่อเกิดการสูญเสียการจัดรูปแบบที่สำคัญ, และดำเนินต่อสำหรับการเตือนอื่น ๆ

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

ส่งค่า `false` ให้ `abortOnMajorFormattingLoss` เมื่อสร้าง `WarningPolicy` หากยอมรับความแตกต่างการจัดรูปแบบที่สำคัญ ปัญหาความเข้ากันได้, การสูญเสียการจัดรูปแบบระดับย่อย, และเนื้อหาที่ไม่คาดคิดยังคงถูกรายงานแม้การดำเนินการจะดำเนินต่อได้ หากแอปพลิเคชันต้องปฏิเสธหมวดหมู่ใดก็ให้ขยาย `WarningPolicy.getAction`

## **สถานการณ์การเตือนทั่วไป**

การเตือนอาจปรากฏในขั้นตอนต่าง ๆ ของกระบวนการทำงาน:

- **ลายเซ็นดิจิทัล:** พรีเซนเทชันที่เซ็นอาจสร้างการเตือนขณะโหลดว่า ลายเซ็นจะสูญหายระหว่างการประมวลผล Aspose.Slides รายงานสภาวะ `DataLoss` ผ่าน [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationsignedwarninginfo/). คอลแบ็กช่วงโหลดทำให้แอปพลิเคชันปฏิเสธไฟล์หรือยอมรับการสูญเสียที่รายงานโดยชัดเจน
- **การแทนที่ฟอนต์:** ฟอนต์ที่ไม่มีอยู่สามารถถูกแทนที่ขณะแสดงสไลด์หรือส่งออก การเตือนการแทนที่ฟอนต์จะรายงานเป็น `DataLoss`, ดังนั้นนโยบายเข้มงวดข้างต้นจะยุติการทำงานแม้แอปพลิเคชันจะถือว่าการแทนที่นั้นยอมรับได้ เพื่อตรวจสอบพฤติกรรมนี้ ให้ใช้พรีเซนเทชันอินพุตที่มีข้อความในฟอนต์ที่รันไทม์ไม่รองรับ คำอธิบายการเตือนจะแสดงการแทนที่; ตั้งค่าฟอนต์ที่ต้องการหรือ [กฎการแทนที่ฟอนต์](/slides/th/java/font-substitution/) ก่อนลองใหม่
- **เนื้อหาที่ไม่รองรับหรือไม่คาดคิด:** ตัวโหลดอาจพบบันทึกหรือฟีเจอร์ของพรีเซนเทชันที่ไม่รู้จัก การเตือนเหล่านี้อาจใช้ `UnexpectedContent` หรือหมวดหมู่ที่รุนแรงกว่าเมื่อข้อมูลหรือการจัดรูปแบบได้รับผลกระทบ
- **ความเข้ากันได้ของรูปแบบ:** การบันทึกเป็นรูปแบบพรีเซนเทชันอื่นอาจละเว้นฟีเจอร์หรือทำให้ผลลัพธ์ทำงานแตกต่างในบางแอปพลิเคชัน ตัวอย่างเช่น การบันทึกพรีเซนเทชันที่มีไกด์วาดแนวนอนหรือแนวตั้งมากกว่าี่แปดรายการไปยัง PPT รุ่นเก่าจะรายงาน `CompatibilityIssue` คอลแบ็กช่วงบันทึกสามารถบันทึกการสูญเสียและดำเนินต่อได้ หรือปฏิเสธหากต้องการเก็บไกด์ทั้งหมด
- **พฤติกรรมการโหลด:** ตัวเลือกการโหลดและพฤติกรรมแบบเก่าสามารถสร้างการเตือนได้ ตัวอย่างเช่น [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) ระบุการใช้พฤติกรรมล็อคพรีเซนเทชันที่ล้าสมัยเป็น `CompatibilityIssue`

การเตือนขึ้นอยู่กับเอกสารต้นทาง, รูปแบบปลายทาง, การดำเนินการ, และเวอร์ชันของ Aspose.Slides อย่าสันนิษฐานว่าทุกไฟล์จะสร้างการเตือนหรือว่าแต่ละสถานการณ์จะสอดคล้องกับเพียงหมวดหมู่เดียวเท่านั้น

## **การจัดการการดำเนินการที่ถูกยกเลิกอย่างปลอดภัย**

เมื่อคอลแบ็กคืนค่า `ReturnAction.Abort` อย่าใช้วัตถุที่โหลดล้มเหลวและอย่าสมมติว่าผลการแสดงหรือบันทึกเสร็จสมบูรณ์ การดำเนินการอาจหยุดหลังจากสร้างไฟล์ผลลัพธ์แต่ก่อนที่จะทำให้เสร็จสมบูรณ์

บันทึกผลลัพธ์ที่ตรวจสอบแล้วไปยังเส้นทางแยกต่างหากเช่น `validated-output.pptx`. แทนที่พรีเซนเทชันที่มีอยู่เฉพาะหลังจากการดำเนินการเสร็จสมบูรณ์, รายงานการเตือนสอดคล้องกับนโยบายของแอปพลิเคชัน, และผลลัพธ์สามารถเปิดและตรวจสอบได้ สิ่งนี้ช่วยหลีกเลี่ยงการเขียนทับไฟล์ต้นทางที่ถูกต้องด้วยผลลัพธ์บางส่วนหรือถูกปฏิเสธ

รายงานการเตือนที่ว่างเปล่าไม่ได้รับประกันว่าฟีเจอร์ทุกอย่างของต้นทางได้รับการรักษาไว้ ให้ทำการตรวจสอบเนื้อหาและภาพเพิ่มเติมตามที่แอปพลิเคชันต้องการ ดูเพิ่มเติมที่ [เปิดพรีเซนเทชัน](/slides/th/java/open-presentation/) และ [บันทึกพรีเซนเทชัน](/slides/th/java/save-presentation/)

## **คำถามที่พบบ่อย**

**คอลแบ็กการเตือนสามารถจัดการข้อผิดพลาดของ Aspose.Slides ทุกอย่างได้หรือไม่?**

ไม่ได้. มันจัดการกับสภาวะที่กู้คืนได้ซึ่งรายงานเป็นการเตือน ข้อยกเว้นที่เกิดขึ้นโดยไม่ได้รับการเรียกคอลแบ็กต้องจัดการโดยแอปพลิเคชันรอบ ๆ การเรียกโหลด, แสดงผล, แปลง, หรือบันทึก

**การคืนค่า `ReturnAction.Continue` รับประกันผลลัพธ์ที่เหมือนกันหรือไม่?**

ไม่ได้. มันเพียงอนุญาตให้ดำเนินการต่อไปได้ สภาวะที่รายงานอาจยังคงทำให้เกิดความแตกต่างของข้อมูล, การจัดรูปแบบ, หรือความเข้ากันได้ ดังนั้นควรตรวจสอบประเภทและคำอธิบายของการเตือนที่รวบรวมไว้

**แอปพลิเคชันจะระบุขั้นตอนการดำเนินการที่ทำให้เกิดการเตือนได้อย่างไร?**

สร้างอินสแตนซ์คอลแบ็กสำหรับแต่ละการดำเนินการและเก็บขั้นตอนที่กำหนดโดยแอปพลิเคชันพร้อมกับค่าที่คืนจาก [getWarningType](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getWarningType--) และ [getDescription](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getDescription--), ตามที่แสดงในตัวอย่าง.