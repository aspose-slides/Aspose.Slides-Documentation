---
title: บันทึกงานนำเสนอใน JavaScript
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/nodejs-java/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกงานนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- งานนำเสนอเป็นไฟล์
- งานนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชรูปย่อ
- บันทึกความคืบหน้า
- Node.js
- JavaScript
- Aspose.Slides
description: "บันทึกงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีมใน JavaScript ด้วย Aspose.Slides และกำหนดค่าเอาต์พุต PPTX รวมถึงการรายงานความคืบหน้า."
---
## **ภาพรวม**

หลังจากคุณสร้างงานนำเสนอหรือ[เปิดงานนำเสนอที่มีอยู่](/slides/th/nodejs-java/open-presentation/), ให้ใช้เมธอด [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) เพื่อบันทึกผลลัพธ์ Aspose.Slides สำหรับ Node.js ผ่าน Java สามารถบันทึกงานนำเสนอเป็นไฟล์หรือสตรีมในรูปแบบ PowerPoint, OpenDocument, PDF และรูปแบบอื่นๆ ส่วนต่อไปนี้อธิบายการบันทึกมาตรฐานและตัวเลือกที่มีสำหรับการส่งออกเป็น PPTX

## **บันทึกงานนำเสนอเป็นไฟล์**

เพื่อบันทึกงานนำเสนอเป็นไฟล์ ให้ส่งพาธเอาต์พุตและค่า [SaveFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/) ไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) ค่าของรูปแบบกำหนดประเภทของไฟล์ที่ Aspose.Slides สร้าง

ตัวอย่างต่อไปนี้สร้างงานนำเสนอและบันทึกเป็นไฟล์ PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // เพิ่มหรือแก้ไขเนื้อหาของการนำเสนอที่นี่.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบดั้งเดิมของมัน**

สำหรับตัวอย่างการตรวจจับไฟล์และสตรีม, พฤติกรรมของงานนำเสนอที่สร้างใหม่, และความแตกต่างระหว่างรูปแบบต้นฉบับและรูปแบบผลลัพธ์ ดูที่ [Determine the Original Presentation Format](/slides/th/nodejs-java/detect-presentation-source-format/).

ในแอปพลิเคชันการประมวลผลแบบกลุ่ม, รูปแบบอินพุตอาจไม่รู้ล่วงหน้า หลังจากโหลดไฟล์แล้ว ให้อ่านรูปแบบดั้งเดิมของมันจากเมธอด [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSourceFormat) ส่งค่าของ [SourceFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sourceformat/) ไปยัง [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideutil/#toSaveFormat) เพื่อรับค่า [SaveFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/) ที่สอดคล้องกัน แล้วใช้ [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) เพื่อบันทึกงานนำเสนอที่แก้ไข

ตัวอย่างสมบูรณ์ต่อไปนี้ประมวลผลทุกไฟล์ในไดเรกทอรีอินพุต, ปรับปรุงชื่อเรื่องของมัน, และบันทึกไปยังไดเรกทอรีเอาต์พุตในรูปแบบที่โหลดมา:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

SlideUtil.toSaveFormat จะแมป PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP และ PowerPoint XML ไปยังรูปแบบการบันทึกงานนำเสนอที่สอดคล้องกัน มันแมปเฉพาะรูปแบบแหล่งที่มาของงานนำเสนอ; ไม่ได้ออกแบบให้เลือกรูปแบบการส่งออกเช่น PDF, HTML, TIFF หรือรูปภาพ การส่งค่าของ [SourceFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sourceformat/) ที่ไม่ได้สนับสนุนหรือไม่ถูกต้องจะทำให้เกิดข้อผิดพลาด

ไฟล์ PPT, PPS และ POT รุ่นเก่าใช้คอนเทนเนอร์ไบนารีเดียวกัน เมื่อโหลดงานนำเสนอเช่นนี้จากสตรีมโดยไม่มีส่วนขยายไฟล์, ไฟล์ PPS หรือ POT อาจถูกระบุเป็น PPT หากต้องการรักษาชนิดย่อยเหล่านี้ไว้, ให้เก็บชื่อไฟล์หรือเมตาดาตรูปแบบเดิมไว้แยกต่างหากและใช้เมื่อตั้งชื่อไฟล์และรูปแบบเอาต์พุต

## **บันทึกงานนำเสนอเป็นสตรีม**

เพื่อบันทึกงานนำเสนอโดยไม่ต้องอ้างอิงถึงพาธไฟล์สุดท้าย, ให้ส่งสตรีมที่เขียนได้และค่า [SaveFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/) ไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) วิธีนี้เป็นประโยชน์เมื่อเอาต์พุตต้องส่งกลับจากเว็บเซอร์วิส, เก็บในฐานข้อมูล, หรือประมวลผลในหน่วยความจำ

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอใหม่ไปยังสตรีมไฟล์:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอพร้อมประเภทมุมมองที่กำหนดไว้ล่วงหน้า**

คุณสามารถระบุมุมมองที่ PowerPoint เปิดงานนำเสนอที่บันทึกไว้เป็นค่าเริ่มต้นได้ ใช้เมธอด [ViewProperties.setLastView](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/#setLastView) กับค่า [ViewType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewtype/) ก่อนบันทึก

ตัวอย่างต่อไปนี้กำหนดให้มุมมอง Slide Master เป็นมุมมองเริ่มต้น:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

เพื่อสร้างไฟล์ PPTX ที่สอดคล้องกับโปรไฟล์ Strict ของ Office Open XML ให้สร้างอินสแตนซ์ [PptxOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxoptions/) และใช้เมธอด [setConformance](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxoptions/#setConformance) กับค่า [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) จากนั้นส่งอ็อปชันไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML แบบ Zip64**

ไฟล์ ZIP มาตรฐานจำกัดขนาดข้อมูลที่บีบอัดและไม่ได้บีบอัดของแต่ละรายการ, ขนาดรวมของไฟล์ ZIP, และจำนวนรายการ เนื่องจากไฟล์ PPTX เป็นไฟล์ ZIP, งานนำเสนอที่ใหญ่มากอาจเกินขีดจำกัดเหล่านี้ การขยาย Zip64 จะเพิ่มขีดจำกัดขนาดและจำนวนรายการที่ใช้ได้

ใช้เมธอด [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) เพื่อควบคุมว่า Aspose.Slides จะเขียนส่วนขยาย ZIP64 หรือไม่:

- [IfNecessary](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zip64mode/#IfNecessary) ใช้ ZIP64 เฉพาะเมื่อ งานนำเสนอ เกินขีดจำกัด ZIP มาตรฐาน นี่คือโหมดเริ่มต้น
- [Never](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zip64mode/#Never) ปิดการใช้งานส่วนขยาย ZIP64
- [Always](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zip64mode/#Always) เขียนส่วนขยาย ZIP64 เสมอ

ตัวอย่างต่อไปนี้เปิดใช้งานส่วนขยาย ZIP64 เสมอสำหรับงานนำออก:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
หากใช้ [Zip64Mode.Never](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zip64mode/#Never) และงานนำเสนอไม่สามารถอยู่ในขีดจำกัด ZIP มาตรฐาน การบันทึกจะโยนข้อยกเว้น [PptxException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxexception/) .
{{% /alert %}}

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

สำหรับการส่งออกเป็น PPTX คุณสามารถปรับสมดุลระหว่างความเร็วในการบันทึกและขนาดไฟล์โดยใช้เมธอด [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) คลาส [CompressionLevel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/) มีค่าดังต่อไปนี้:

- [None](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#None) เก็บข้อมูลโดยไม่มีการบีบอัด
- [Level1](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level1) ให้การบีบอัดที่เร็วที่สุดและผลลัพธ์บีบอัดที่ใหญ่ที่สุด
- [Level2](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level2) ถึง [Level5](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level5) มีแนวโน้มให้ผลลัพธ์ที่เล็กลงมากกว่าความเร็วในการบันทึก
- [Level6](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level6) สมดุลระหว่างความเร็วในการบันทึกและขนาดไฟล์ นี่เป็นระดับเริ่มต้น
- [Level7](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level7) และ [Level8](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level8) ย้ำให้ผลลัพธ์ที่เล็กลงมากกว่าความเร็วในการบันทึก
- [Level9](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level9) ให้การบีบอัดที่แรงที่สุดและต้องใช้เวลาประมวลผลมากที่สุด

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่บีบอัด:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

ตัวอย่างต่อไปนี้ใช้ระดับการบีบอัดสูงสุด:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอโดยไม่รีเฟรชรูปย่อ**

เมื่อบันทึกงานนำเสนอเป็น PPTX เมธอด [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ควบคุมรูปย่อของเอกสารดังนี้:

- `true` สร้างรูปย่อใหม่ระหว่างการบันทึก นี่คือค่าเริ่มต้น
- `false` รักษารูปย่อที่มีอยู่ หากงานนำเสนอไม่มีรูปย่อ Aspose.Slides จะไม่สร้าง

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่รีเฟรชรูปย่อ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
การปิดการรีเฟรชรูปย่อสามารถลดเวลาที่ใช้ในการบันทึกไฟล์ PPTX ได้.
{{% /alert %}}

## **อัปเดตความคืบหน้าในการบันทึกเป็นเปอร์เซ็นต์**

เพื่อเฝ้าติดตามการบันทึก ให้ทำการนำเสนออินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/) ด้วยพร็อกซี Java และส่งอิมพลีเมนต์ไปยังเมธอด [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) Aspose.Slides จะเรียกเมธอด [IProgressCallback.reporting](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/#reporting-double-) พร้อมค่าความคืบหน้าในระหว่างการส่งออก

ตัวอย่างต่อไปนี้รายงานความคืบหน้าการส่งออก PDF ไปยังคอนโซล:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose มีบริการ [PowerPoint Splitter](https://products.aspose.app/slides/th/splitter) ฟรีที่สร้างด้วย Aspose.Slides API ซึ่งบันทึกสไลด์ที่เลือกจากงานนำเสนอเป็นไฟล์ PPT หรือ PPTX แยกกัน.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการบันทึกแบบเพิ่มเชิงหรือ “บันทึกเร็ว” หรือไม่?**

ไม่ การบันทึกแต่ละครั้งจะเขียนไฟล์ผลลัพธ์แบบเต็มแทนการอัปเดตเฉพาะส่วนที่เปลี่ยนแปลง

**หลายเธรดสามารถบันทึก Presentation อินสแตนซ์เดียวกันได้หรือไม่?**

ไม่ ตัวอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) [ไม่รองรับการทำงานหลายเธรด](/slides/th/nodejs-java/multithreading/) ควรเข้าถึงและบันทึกแต่ละอินสแตนซ์จากเธรดเดียวเท่านั้น

**ลิงก์และไฟล์ที่เชื่อมโยงภายนอกจะเกิดอะไรขึ้นเมื่อบันทึกงานนำเสนอ?**

[Hyperlinks](/slides/th/nodejs-java/manage-hyperlinks/) ยังคงอยู่ในงานนำเสนอ Aspose.Slides ไม่คัดลอกไฟล์ที่เชื่อมโยงภายนอก ดังนั้นงานนำเสนอที่บันทึกต้องยังคงสามารถเข้าถึงตำแหน่งของไฟล์เหล่านั้นได้

**ฉันสามารถบันทึกเมตาดาต้าเอกสาร เช่น ผู้เขียน, ชื่อเรื่อง, บริษัท และวันที่สร้างได้หรือไม่?**

ได้ ให้ตั้งค่า [document properties](/slides/th/nodejs-java/presentation-properties/) ที่เหมาะสมก่อนบันทึก Aspose.Slides จะเขียนข้อมูลเหล่านั้นลงในไฟล์ผลลัพธ์