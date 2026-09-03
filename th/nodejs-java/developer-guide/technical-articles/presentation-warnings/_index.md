---
title: จัดการคำเตือนการนำเสนอใน Node.js
type: docs
weight: 90
url: /th/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback คำเตือน
- นโยบายคำเตือน
- การสูญเสียข้อมูล
- ความเสียหายของแหล่งข้อมูล
- ปัญหาความเข้ากันได้
- การทดแทนฟอนท์
- ลายเซ็นดิจิทัล
- การโหลดงานนำเสนอ
- การเรนเดอร์งานนำเสนอ
- การแปลงงานนำเสนอ
- การบันทึกงานนำเสนอ
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "เรียนรู้วิธีการรวบรวม แยกประเภท และจัดการกับคำเตือนขณะโหลด เรนเดอร์ แปลง และบันทึกงานนำเสนอด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides สามารถรายงานปัญหาที่สามารถกู้คืนได้ในขณะที่ทำการโหลด, เรนเดอร์, แปลง หรือบันทึกงานนำเสนอ ตัวอย่าง ได้แก่ บันทึกแหล่งที่เสียหาย, เนื้อหาที่ไม่สามารถเก็บรักษาได้, การทดแทนฟอนท์, และข้อจำกัดของรูปแบบเป้าหมาย คอลแบ็กการเตือนช่วยให้แอปพลิเคชันบันทึกเงื่อนไขเหล่านี้และตัดสินใจว่าการดำเนินการปัจจุบันควรดำเนินต่อหรือไม่

ใช้ `java.newProxy` เพื่อทำการนำเข้าระบบอินเทอร์เฟซ Java [IWarningCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarningcallback/) ใน JavaScript และตรวจสอบค่า [getWarningType](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getWarningType--) และ [getDescription](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getDescription--) ที่ส่งมาผ่าน [IWarningInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/). คืนค่า [ReturnAction.Continue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/returnaction/#Continue) เพื่อยอมรับการเตือนหรือ [ReturnAction.Abort](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/returnaction/#Abort) เพื่อหยุดการดำเนินการ

ใช้ [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) สำหรับคำเตือนที่เกิดขึ้นขณะเปิดงานนำเสนอ คลาสตัวเลือกการเรนเดอร์และการส่งออกสืบทอดจาก [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), ซึ่งรับคำเตือนจากการเรนเดอร์สไลด์, การแปลง, และการบันทึก เนื่องจากคำเตือนเองไม่ได้ระบุการทำงานของแอปพลิเคชัน จึงเชื่อมโยงแต่ละอินสแตนซ์ของ callback กับขั้นตอนการทำงานเมื่อคุณสร้างรายงานรวม

## **คำเตือนและข้อยกเว้น**

คำเตือนอธิบายสภาวะที่ Aspose.Slides สามารถกู้คืนได้หาก callback คืนค่า `ReturnAction.Continue` ข้อยกเว้นหมายถึงการดำเนินการที่ร้องขอไม่สามารถเสร็จสิ้นตามปกติ; ข้อยกเว้นจะไม่ถูกแปลงเป็นคำเตือนและไม่สามารถจัดการโดยนโยบายการเตือนได้

การคืนค่า `ReturnAction.Abort` จะให้ตัวกระจายคำเตือนหยุดการดำเนินการปัจจุบันโดยการโยงข้อยกเว้น ข้อยกเว้นสาธารณะจะแตกต่างตามการดำเนินการและรูปแบบงานนำเสนอ ตัวอย่างเช่น การโหลดอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxreadexception/) หรือ [PptReadException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptreadexception/), ขณะที่การบันทึกหรือการส่งออกอาจทำให้เกิด [PptxException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxexception/). จับข้อผิดพลาดจาก Java bridge ที่ขอบเขตของการดำเนินการและใช้รายงานคำเตือนเพื่อตัดสินใจว่านโยบายแอปพลิเคชันเป็นสาเหตุของการหยุดหรือไม่ แทนที่จะพึ่งพาประเภทข้อยกเว้นหรือข้อความเดียว คอลแบ็กบันทึกคำเตือนก่อนคืนค่า `ReturnAction.Abort`, ทำให้เหตุผลยังคงพร้อมสำหรับแอปพลิเคชัน

## **ประเภทคำเตือน**

คลาส [WarningType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/warningtype/) ให้ค่าคงที่จำนวนเต็มสำหรับประเภทต่อไปนี้:

| ประเภทคำเตือน | ความหมาย | นโยบายทั่วไป |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | งานนำเสนอแหล่งที่มีความเสียหายที่อาจทำให้เอกสารที่บันทึกในรูปแบบเดิมไม่สามารถใช้งานได้. | ยกเลิก. |
| [DataLoss](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/warningtype/#DataLoss) | ข้อความ, แผนภูมิ, รูปภาพ หรือข้อมูลอื่นอาจหายไปหลังจากการโหลดหรือบันทึก. | ยกเลิก. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | งานนำเสนออาจสูญเสียการจัดรูปแบบที่สำคัญ. | ยกเลิกในโหมดตรวจสอบที่เข้มงวด; มิฉะนั้นบันทึกและดำเนินต่อ. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | อาจเกิดความแตกต่างในการจัดรูปแบบที่จำกัด. | บันทึกเพื่อการวินิจฉัยและดำเนินต่อ. |
| [CompatibilityIssue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | ผลลัพธ์อาจไม่เปิดหรือทำงานอย่างถูกต้องในบางแอปพลิเคชันหรือเวอร์ชันเก่า. | บันทึกและดำเนินต่อเว้นแต่ความเข้ากันได้เป็นสิ่งจำเป็น. |
| [UnexpectedContent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | แหล่งที่มามีเนื้อหาที่ไม่รองรับหรือไม่รู้จักซึ่งผลกระทบอาจยังไม่ทราบ. | บันทึกและดำเนินต่อ, หรือถือเป็นข้อผิดพลาดในนโยบายที่เข้มงวด. |

ประเภทควรเป็นตัวกำหนดการตัดสินใจนโยบาย เก็บค่าที่คืนจาก [getDescription](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getDescription--) เพื่อการวินิจฉัย, แต่ไม่ควรพึ่งพาคำอธิบายนี้ในตรรกะของแอปพลิเคชันเนื่องจากข้อความอาจแตกต่างระหว่างสถานการณ์คำเตือนและรุ่นผลิตภัณฑ์

## **รวบรวมและจัดประเภทคำเตือน**

ตัวอย่าง JavaScript ต่อไปนี้ใช้รายงานระดับแอปพลิเคชันหนึ่งชุดสำหรับสายการประมวลผลทั้งหมด อินสแตนซ์ callback แยกกันทำเครื่องหมายคำเตือนจากการโหลด, การเรนเดอร์, การแปลงเป็น PDF, และการบันทึกเป็น PPTX นโยบายจะยกเลิกเมื่อพบความเสียหายของแหล่งข้อมูลหรือการสูญเสียข้อมูล, ตัวเลือกจะยกเลิกเมื่อเกิดการสูญเสียการจัดรูปแบบที่สำคัญ, และดำเนินต่อสำหรับคำเตือนอื่น ๆ

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

ส่งค่า `false` สำหรับ `abortOnMajorFormattingLoss` เมื่อตั้งค่า `WarningPolicy` หากยอมรับความแตกต่างการจัดรูปแบบที่สำคัญ ปัญหาความเข้ากันได้, การสูญเสียการจัดรูปแบบระดับย่อย, และเนื้อหาที่ไม่คาดคิดยังคงถูกเก็บในรายงานแม้การดำเนินการจะดำเนินต่อต่อไป ขยาย `WarningPolicy.getAction` หากแอปพลิเคชันต้องปฏิเสธหนึ่งในประเภทเหล่านี้

## **สถานการณ์คำเตือนทั่วไป**

คำเตือนสามารถปรากฏได้ในขั้นตอนต่าง ๆ ของกระบวนการทำงาน:

- **ลายเซ็นดิจิทัล:** งานนำเสนอที่ลงลายเซ็นอาจสร้างคำเตือนขณะโหลดว่าลายเซ็นจะหายไประหว่างการประมวลผล Aspose.Slides รายงานสภาวะ `DataLoss` นี้ผ่าน [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationsignedwarninginfo/). คอลแบ็กช่วงการโหลดทำให้แอปพลิเคชันปฏิเสธไฟล์หรือยอมรับการสูญเสียที่รายงานไว้โดยชัดเจน
- **การทดแทนฟอนท์:** ฟอนท์ที่ไม่มีอาจถูกแทนที่ในขณะที่สไลด์กำลังเรนเดอร์หรือส่งออก คำเตือนการทดแทนฟอนท์จะรายงานเป็น `DataLoss` ดังนั้นนโยบายเข้มงวดด้านบนจะยกเลิกแม้ว่าผู้ใช้จะถือว่าการเปลี่ยนฟอนท์นั้นรับได้ตามสายตา เพื่อตรวจสอบพฤติกรรมนี้ ให้ใช้งานนำเข้าที่มีข้อความในฟอนท์ที่ไม่พร้อมใช้งานใน runtime รายละเอียดคำเตือนจะแสดงการทดแทน; กำหนดฟอนท์ที่ต้องการหรือ [font substitution rules](/slides/th/nodejs-java/font-substitution/) ก่อนลองใหม่
- **เนื้อหาไม่รองรับหรือไม่คาดคิด:** ตัวโหลดอาจเจอบันทึกหรือฟีเจอร์ของงานนำเสนอที่ไม่รู้จัก คำเตือนเช่นนี้อาจใช้ `UnexpectedContent` หรือใช้ประเภทที่รุนแรงกว่าเมื่อพบว่าข้อมูลหรือการจัดรูปแบบได้รับผลกระทบ
- **ความเข้ากันได้ของรูปแบบ:** การบันทึกเป็นรูปแบบงานนำเสนออื่นอาจละเว้นฟีเจอร์หรือทำให้ผลลัพธ์ทำงานแตกต่างในบางแอปพลิเคชัน ตัวอย่างเช่นการบันทึกงานนำเสนอที่มีไกด์การวาดมากกว่าสแปดแนวนอนหรือสแปดแนวตั้งไปยัง PPT รุ่นเก่าจะรายงาน `CompatibilityIssue` คอลแบ็กช่วงการบันทึกสามารถบันทึกการสูญเสียและดำเนินต่อ, หรือปฏิเสธหากต้องการเก็บไกด์ทั้งหมด
- **พฤติกรรมการโหลด:** ตัวเลือกการโหลดและพฤติกรรมเก่าสามารถสร้างคำเตือนได้เช่นกัน ตัวอย่างเช่น [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) ระบุการใช้พฤติกรรมการล็อกงานนำเสนอที่ล้าสมัยว่าเป็น `CompatibilityIssue`

คำเตือนขึ้นอยู่กับเอกสารต้นทาง, รูปแบบเป้าหมาย, การดำเนินการ, และเวอร์ชันของ Aspose.Slides ไม่ควรสมมติว่าทุกไฟล์จะสร้างคำเตือนหรือว่าฉากใดจะตรงกับเพียงประเภทเดียวเสมอ

## **จัดการการดำเนินการที่ถูกยกเลิกอย่างปลอดภัย**

เมื่อคอลแบ็กคืนค่า `ReturnAction.Abort` อย่าใช้วัตถุที่โหลดล้มเหลวและอย่ assuming ว่าผลลัพธ์การเรนเดอร์หรือการบันทึกสมบูรณ์ การดำเนินการอาจสิ้นสุดหลังจากสร้างไฟล์ผลลัพธ์แล้วแต่ก่อนที่ไฟล์จะเสร็จสมบูรณ์

บันทึกผลลัพธ์ที่ตรวจสอบแล้วลงในพาธแยกต่างหากเช่น `validated-output.pptx` แทนที่งานนำเสนอที่มีอยู่เฉพาะหลังจากการดำเนินการสำเร็จสมบูรณ์, รายงานคำเตือนสอดคล้องกับนโยบายแอปพลิเคชัน, และผลลัพธ์สามารถเปิดและตรวจสอบได้ วิธีนี้หลีกเลี่ยงการเขียนทับไฟล์ต้นทางที่ถูกต้องด้วยผลลัพธ์ครึ่งส่วนหรือถูกปฏิเสธ

รายงานคำเตือนว่างเปล่าไม่ใช่การรับประกันว่าฟีเจอร์ทุกอย่างของแหล่งข้อมูลได้ถูกเก็บรักษาไว้ ให้ทำการตรวจสอบเนื้อหาและภาพเพิ่มเติมตามที่แอปพลิเคชันต้องการ ดูเพิ่มเติมที่ [Open Presentations](/slides/th/nodejs-java/open-presentation/) และ [Save Presentations](/slides/th/nodejs-java/save-presentation/)

## **คำถามที่พบบ่อย**

**คอลแบ็กการเตือนสามารถจัดการกับข้อผิดพลาดทุกอย่างของ Aspose.Slides ได้หรือไม่?**

ไม่. คอลแบ็กจัดการกับสภาวะที่กู้คืนได้ที่รายงานเป็นคำเตือน ข้อยกเว้นที่เกิดแยกจากคอลแบ็กต้องถูกจัดการโดยแอปพลิเคชันรอบการเรียกโหลด, เรนเดอร์, แปลง หรือบันทึก

**การคืนค่า `ReturnAction.Continue` ให้ผลลัพธ์ที่เหมือนเดิมแน่นอนหรือไม่?**

ไม่. การคืนค่านี้เพียงทำให้กระบวนการดำเนินต่อไปได้เท่านั้น สภาวะที่รายงานอาจยังทำให้เกิดความแตกต่างของข้อมูล, การจัดรูปแบบ, หรือความเข้ากันได้ ดังนั้นควรตรวจสอบประเภทและรายละเอียดของคำเตือนที่รวบรวมไว้

**แอปพลิเคชันจะระบุการดำเนินการที่สร้างคำเตือนได้อย่างไร?**

สร้างอินสแตนซ์คอลแบ็กสำหรับแต่ละการดำเนินการและเก็บขั้นตอนที่กำหนดโดยแอปพลิเคชันพร้อมกับค่าที่คืนจาก [getWarningType](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getWarningType--) และ [getDescription](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getDescription--), ตามตัวอย่างที่แสดง.