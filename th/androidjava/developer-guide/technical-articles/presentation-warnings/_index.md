---
title: จัดการคำเตือนพรีเซนเทชันบน Android
type: docs
weight: 90
url: /th/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- คำเตือน callback
- นโยบายคำเตือน
- การสูญเสียข้อมูล
- ความเสียหายของแหล่งข้อมูล
- ปัญหาความเข้ากันได้
- การทดแทนฟอนต์
- ลายเซ็นดิจิทัล
- การโหลดพรีเซนเทชัน
- การเรนเดอร์พรีเซนเทชัน
- การแปลงพรีเซนเทชัน
- การบันทึกพรีเซนเทชัน
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการรวบรวม, จำแนกประเภท, และดำเนินการกับคำเตือนขณะโหลด, เรนเดอร์, แปลง, และบันทึกพรีเซนเทชันด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides สามารถรายงานปัญหาที่สามารถกู้คืนได้ขณะโหลด, เรนเดอร์, แปลง หรือบันทึกงานพรีเซนเทชัน ตัวอย่างเช่น เรคคอร์ดต้นฉบับที่เสียหาย, เนื้อหาที่ไม่สามารถเก็บรักษาได้, การทดแทนฟอนต์, และข้อจำกัดของรูปแบบเป้าหมาย การเรียกกลับ (callback) ของคำเตือนช่วยให้แอปพลิเคชันบันทึกสภาวะเหล่านี้และตัดสินใจว่าปฏิบัติการปัจจุบันสามารถดำเนินต่อได้หรือไม่

ทำการ implement อินเทอร์เฟซ [IWarningCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iwarningcallback/) และตรวจสอบค่าที่ให้มาจาก [getWarningType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) และ [getDescription](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) ผ่าน [IWarningInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iwarninginfo/). ส่งคืน [ReturnAction.Continue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/returnaction/#Continue) เพื่อยอมรับคำเตือนหรือ [ReturnAction.Abort](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/returnaction/#Abort) เพื่อหยุดการทำงาน

ใช้ [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) สำหรับคำเตือนที่เกิดขณะเปิดงานพรีเซนเทชัน คลาสตัวเลือกการเรนเดอร์และการส่งออกสืบทอดจาก [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ซึ่งรับคำเตือนจากการเรนเดอร์สไลด์, การแปลง, และการบันทึก เนื่องจากคำเตือนเองไม่ระบุการดำเนินการของแอปพลิเคชัน จึงควรเชื่อมโยงแต่ละอินสแตนซ์ของ callback กับขั้นตอนการทำงานเมื่อสร้างรายงานรวม

## **คำเตือนและข้อยกเว้น**

คำเตือนอธิบายสภาวะที่ Aspose.Slides สามารถกู้คืนได้หาก callback ส่งคืน `ReturnAction.Continue` ข้อยกเว้นหมายถึงการดำเนินการที่ร้องขอไม่สามารถสำเร็จได้ตามปกติ; ข้อยกเว้นจะไม่ถูกแปลงเป็นคำเตือนและไม่สามารถจัดการโดยนโยบายคำเตือน

การส่งคืน `ReturnAction.Abort` จะบอกตัวกระจายคำเตือนให้หยุดการทำงานโดยทำการโยนข้อยกเว้น ข้อยกเว้นสาธารณะขึ้นอยู่กับการดำเนินการและรูปแบบพรีเซนเทชัน ตัวอย่างเช่น การโหลดอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxreadexception/) หรือ [PptReadException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptreadexception/), ส่วนการบันทึกหรือส่งออกอาจทำให้เกิด [PptxException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxexception/). จัดการข้อยกเว้นที่ขอบเขตของการดำเนินการและใช้รายงานคำเตือนเพื่อตรวจสอบว่านโยบายของแอปพลิเคชันเป็นสาเหตุที่ทำให้หยุดหรือไม่ แทนการพึ่งพาเพียงชนิดข้อยกเว้นหรือข้อความเดียว callback จะบันทึกคำเตือนก่อนส่งคืน `ReturnAction.Abort` เพื่อให้เหตุผลยังคงพร้อมให้แอปพลิเคชันใช้งาน

## **ประเภทของคำเตือน**

คลาส [WarningType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/warningtype/) มีค่าคงที่จำนวนเต็มสำหรับประเภทต่อไปนี้:

| ประเภทคำเตือน | ความหมาย | นโยบายทั่วไป |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | พรีเซนเทชันต้นฉบับมีข้อมูลเสียที่อาจทำให้ไฟล์ที่บันทึกในรูปแบบเดิมใช้งานไม่ได้ | Abort. |
| [DataLoss](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/warningtype/#DataLoss) | ข้อความ, แผนภูมิ, รูปภาพ หรือข้อมูลอื่นอาจหายไปหลังการโหลดหรือบันทึก | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | พรีเซนเทชันอาจสูญเสียการจัดรูปแบบสำคัญ | Abort ในโหมดตรวจสอบเข้มงวด; มิฉะนั้นบันทึกและดำเนินต่อ |
| [MinorFormattingLoss](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | อาจมีความแตกต่างในการจัดรูปแบบที่จำกัด | บันทึกเพื่อการวินิจฉัยและดำเนินต่อ |
| [CompatibilityIssue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | ผลลัพธ์อาจไม่เปิดหรือทำงานได้อย่างถูกต้องในแอปพลิเคชันหรือเวอร์ชันเก่า | บันทึกและดำเนินต่อ ยกเว้นกรณีที่ความเข้ากันได้เป็นข้อบังคับ |
| [UnexpectedContent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | แหล่งที่มามีเนื้อหาไม่รองรับหรือไม่รู้จักซึ่งผลกระทบอาจยังไม่ทราบ | บันทึกและดำเนินต่อ หรือจัดเป็นข้อผิดพลาดในนโยบายเข้มงวด |

ประเภทควรเป็นตัวกำหนดการตัดสินใจด้านนโยบาย เก็บค่าที่ส่งคืนจาก [getDescription](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) เพื่อใช้วินิจฉัย, แต่ไม่ควรอ้างอิงถึงคำพูดของมันในการทำงานของแอปพลิเคชัน เนื่องจากข้อความอาจแตกต่างตามสภาวะคำเตือนและเวอร์ชันผลิตภัณฑ์

## **รวบรวมและจัดประเภทคำเตือน**

ตัวอย่างต่อไปนี้ใช้รายงานระดับแอปพลิเคชันเดียวสำหรับไปป์ไลน์การประมวลผลทั้งหมด ตัวอย่าง callback แต่ละอันทำเครื่องหมายคำเตือนจากการโหลด, เรนเดอร์, การแปลงเป็น PDF, และการบันทึกเป็น PPTX นโยบายจะหยุดเมื่อพบการเสียหายของแหล่งหรือการสูญเสียข้อมูล, สามารถหยุดได้เมื่อพบการสูญเสียการจัดรูปแบบสำคัญ, และดำเนินต่อสำหรับคำเตือนอื่น ๆ

วางไฟล์ `input.pptx` ไว้ในไดเรกทอรีที่แอปพลิเคชันสามารถเขียนได้และส่งไดเรกทอรีนั้นไปยัง `PresentationWarningExample.run`. ตัวอย่างจะบันทึกผลลัพธ์ในไดเรกทอรีเดียวกัน รันการประมวลผลพรีเซนเทชันบนเธรดพื้นหลังเพื่อให้ส่วนติดต่อผู้ใช้ Android ทำงานอย่างราบรื่น

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

ส่งค่า `false` ให้กับ `abortOnMajorFormattingLoss` เมื่อสร้าง `WarningPolicy` หากยอมรับความแตกต่างการจัดรูปแบบสำคัญ ประเด็นความเข้ากันได้, การสูญเสียการจัดรูปแบบเล็กน้อย, และเนื้อหาไม่คาดคิดยังคงอยู่ในรายงานแม้การดำเนินการจะดำเนินต่อต่อไป ขยาย `WarningPolicy.getAction` หากแอปพลิเคชันต้องปฏิเสธประเภทใดก็ได้จากเหล่านั้น

## **สถานการณ์คำเตือนทั่วไป**

คำเตือนอาจปรากฏในขั้นตอนต่าง ๆ ของเวิร์กโฟลว์:

- **ลายเซ็นดิจิทัล:** พรีเซนเทชันที่เซ็นจะสร้างคำเตือนขณะโหลดว่าลายเซ็นจะหายไประหว่างการประมวลผล Aspose.Slides รายงานสภาวะ `DataLoss` นี้ผ่าน [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Callback ระดับโหลดทำให้แอปพลิเคชันปฏิเสธไฟล์หรือยอมรับการสูญเสียที่รายงาน
- **การทดแทนฟอนต์:** ฟอนต์ที่ไม่มีอยู่สามารถถูกแทนที่ขณะเรนเดอร์หรือส่งออก คำเตือนการทดแทนฟอนต์จะรายงานเป็น `DataLoss` ดังนั้นนโยบายเข้มงวดด้านบนจะหยุดแม้ว่าแอปจะพิจารณาการแทนที่นั้นเป็นที่ยอมรับเพื่อการแสดงผล เพื่อตรวจสอบพฤติกรรมนี้ ให้ใช้พรีเซนเทชันที่มีข้อความในฟอนต์ที่รันไทม์ไม่มี ฟอนต์ที่ทดแทนจะแสดงในคำอธิบายของคำเตือน; ตั้งค่าฟอนต์ที่ต้องการหรือ [font substitution rules](/slides/th/androidjava/font-substitution/) ก่อนลองใหม่
- **เนื้อหาที่ไม่รองรับหรือไม่คาดคิด:** ตัวโหลดอาจเจอเรคคอร์ดหรือฟีเจอร์ที่ไม่รู้จัก คำเตือนเหล่านี้อาจใช้ `UnexpectedContent` หรือประเภทที่รุนแรงกว่าเมื่อข้อมูลหรือการจัดรูปแบบได้รับผลกระทบ
- **ความเข้ากันได้ของรูปแบบ:** การบันทึกเป็นรูปแบบพรีเซนเทชันอื่นอาจละทิ้งฟีเจอร์หรือทำให้ผลลัพธ์ทำงานต่างกันในบางแอป ตัวอย่างเช่น การบันทึกพรีเซนเทชันที่มีไกด์การวาดแนวนอนหรือแนวตั้งมากกว่าสแปดเส้นไปยัง PPT รุ่นเก่า จะรายงาน `CompatibilityIssue` Callback ระยะบันทึกสามารถบันทึกการสูญเสียและดำเนินต่อ หรือปฏิเสธหากต้องการรักษาไกด์ทั้งหมด
- **พฤติกรรมการโหลด:** ตัวเลือกการโหลดและพฤติกรรมแบบเก่าอาจสร้างคำเตือนได้ ตัวอย่างเช่น [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) ระบุการใช้พฤติกรรมล็อกพรีเซนเทชันที่ล้าสมัยเป็น `CompatibilityIssue`

คำเตือนขึ้นกับเอกสารต้นฉบับ, รูปแบบเป้าหมาย, การดำเนินการ, และเวอร์ชันของ Aspose.Slides อย่าสมมติว่าไฟล์ทุกไฟล์จะสร้างคำเตือนหรือว่าฉากสถานการณ์ใดจะตรงกับประเภทเดียวเท่านั้น

## **จัดการการดำเนินการที่ถูกยกเลิกอย่างปลอดภัย**

เมื่อ callback ส่งคืน `ReturnAction.Abort` อย่าใช้วัตถุที่โหลดไม่สำเร็จและอย่าสมมติว่าผลลัพธ์การเรนเดอร์หรือการบันทึกสมบูรณ์ การดำเนินการอาจหยุดหลังจากสร้างไฟล์ผลลัพธ์แต่ก่อนที่จะเสร็จสมบูรณ์

บันทึกผลลัพธ์ที่ตรวจสอบแล้วไปยังเส้นทางแยกต่างหาก เช่น `validated-output.pptx`. แทนที่พรีเซนเทชันที่มีอยู่เฉพาะหลังจากการดำเนินการเสร็จสมบูรณ์, รายงานคำเตือนสอดคล้องกับนโยบายของแอปพลิเคชัน, และผลลัพธ์สามารถเปิดและตรวจสอบได้ วิธีนี้จะป้องกันการเขียนทับไฟล์ต้นฉบับที่ถูกต้องด้วยผลลัพธ์บางส่วนหรือถูกปฏิเสธ

รายงานคำเตือนที่ว่างเปล่าไม่ได้รับประกันว่าฟีเจอร์ต้นฉบับทั้งหมดถูกเก็บรักษาไว้ ควรดำเนินการตรวจสอบเนื้อหาและภาพเพิ่มเติมตามที่แอปพลิเคชันต้องการ ดูเพิ่มเติมที่ [Open Presentations](/slides/th/androidjava/open-presentation/) และ [Save Presentations](/slides/th/androidjava/save-presentation/)

## **คำถามที่พบบ่อย**

**Callback ของคำเตือนสามารถจัดการข้อผิดพลาดของ Aspose.Slides ทุกอย่างได้หรือไม่?**

ไม่ได้. มันจัดการสภาวะที่กู้คืนได้ที่รายงานเป็นคำเตือน. ข้อยกเว้นที่เกิดโดยไม่ผ่าน callback ต้องจัดการโดยแอปพลิเคชันรอบคำเรียกโหลด, เรนเดอร์, แปลง, หรือบันทึก

**การส่งคืน `ReturnAction.Continue` รับประกันว่าจะได้ผลลัพธ์เดียวกันหรือไม่?**

ไม่. มันเพียงแค่อนุญาตให้ดำเนินการต่อ. สภาวะที่รายงานอาจยังทำให้เกิดความแตกต่างของข้อมูล, การจัดรูปแบบ, หรือความเข้ากันได้ ดังนั้นควรตรวจสอบประเภทและคำอธิบายของคำเตือนที่สะสมไว้

**แอปพลิเคชันจะระบุขั้นตอนการดำเนินการที่ทำให้เกิดคำเตือนได้อย่างไร?**

สร้างอินสแตนซ์ของ callback สำหรับแต่ละการดำเนินการและเก็บขั้นตอนที่กำหนดโดยแอปพลิเคชันพร้อมค่าที่ส่งคืนจาก [getWarningType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) และ [getDescription](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), ตามที่แสดงในตัวอย่าง.