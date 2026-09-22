---
title: บันทึกงานนำเสนอใน Java
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/java/save-presentation/
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
- รีเฟรชภาพย่อ
- บันทึกความคืบหน้า
- Java
- Aspose.Slides
description: "บันทึกงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีมใน Java ด้วย Aspose.Slides และกำหนดการส่งออก PPTX รวมถึงการรายงานความคืบหน้า."
---
## **ภาพรวม**

หลังจากที่คุณสร้างงานนำเสนอหรือ[เปิดงานนำเสนอที่มีอยู่แล้ว](/slides/th/java/open-presentation/), ให้ใช้เมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) เพื่อบันทึกผลลัพธ์ Aspose.Slides for Java สามารถบันทึกงานนำเสนอเป็นไฟล์หรือสตรีมในรูปแบบ PowerPoint, OpenDocument, PDF และรูปแบบอื่น ๆ ส่วนต่อไปนี้ครอบคลุมการบันทึกมาตรฐานและตัวเลือกที่มีสำหรับการส่งออกเป็น PPTX

## **บันทึกงานนำเสนอเป็นไฟล์**

เพื่อบันทึกงานนำเสนอเป็นไฟล์ ให้ส่งเส้นทางออกและค่าของ [SaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/) ไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ค่าฟอร์แมตนี้กำหนดประเภทของไฟล์ที่ Aspose.Slides สร้าง

ตัวอย่างต่อไปนี้สร้างงานนำเสนอและบันทึกเป็นไฟล์ PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // เพิ่มหรือแก้ไขเนื้อหาของงานนำเสนอที่นี่.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบดั้งเดิมของมัน**

สำหรับตัวอย่างการตรวจจับไฟล์และสตรีม, พฤติกรรมของงานนำเสนอที่สร้างใหม่, และความแตกต่างระหว่างรูปแบบต้นฉบับและรูปแบบผลลัพธ์ ดูที่[กำหนดรูปแบบงานนำเสนอดั้งเดิม](/slides/th/java/detect-presentation-source-format/)

ในแอปพลิเคชันการประมวลผลแบบแบทช์ รูปแบบอินพุตอาจไม่ทราบล่วงหน้า หลังจากโหลดไฟล์ ให้อ่านรูปแบบดั้งเดิมจากเมธอด [IPresentation.getSourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getSourceFormat--) ส่งค่าของ [SourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/sourceformat/) ที่ได้ไปยังเมธอด [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideutil/#toSaveFormat-int-) เพื่อรับค่า [SaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/) ที่สอดคล้องกัน แล้วใช้ [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) เพื่อบันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างเต็มต่อไปนี้จะประมวลผลทุกไฟล์ในไดเรกทอรีอินพุต, ปรับปรุงชื่อเรื่อง, และบันทึกลงในไดเรกทอรีเอาต์พุตในรูปแบบที่โหลดมาจาก:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideutil/#toSaveFormat-int-) ทำการแมพ PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP และ PowerPoint XML ไปยังรูปแบบการบันทึกงานนำเสนอที่สอดคล้องกัน มันแมพเฉพาะรูปแบบต้นทางของงานนำเสนอเท่านั้น; ไม่ได้ตั้งใจให้เลือกรูปแบบการส่งออกเช่น PDF, HTML, TIFF หรือรูปภาพ การส่งค่าของ [SourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/sourceformat/) ที่ไม่รองรับหรือไม่ถูกต้องจะทำให้เกิด [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)

ไฟล์ PPT, PPS, และ POT แบบดั้งเดิมใช้คอนเทนเนอร์ไบนารีเดียวกัน เมื่อโหลดงานนำเสนอจากสตรีมโดยไม่มีส่วนขยายไฟล์ PPS หรือ POT อาจถูกระบุว่าเป็น PPT หากต้องการรักษาชนิดย่อยเหล่านี้ไว้ ให้เก็บชื่อไฟล์เดิมหรือเมตาดาตรูปแบบแยกต่างหากและใช้เมื่อตั้งชื่อไฟล์และรูปแบบเอาต์พุต

## **บันทึกงานนำเสนอเป็นสตรีม**

เพื่อบันทึกงานนำเสนอโดยไม่พึ่งพาเส้นทางไฟล์สุดท้าย ให้ส่งสตรีมที่เขียนได้และค่าของ [SaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/) ไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) วิธีนี้เป็นประโยชน์เมื่อเอาต์พุตต้องส่งกลับจากเว็บเซอร์วิส, เก็บในฐานข้อมูล, หรือประมวลผลในหน่วยความจำ

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอใหม่ไปยังสตรีมไฟล์:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอพร้อมประเภทมุมมองที่กำหนดล่วงหน้า**

คุณสามารถระบุมุมมองที่ PowerPoint จะเปิดงานนำเสนอที่บันทึกไว้โดยอัตโนมัติได้ ใช้เมธอด [ViewProperties.setLastView](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewproperties/#setLastView-int-) พร้อมค่าของ [ViewType](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewtype/) ก่อนบันทึก

ตัวอย่างต่อไปนี้ตั้งค่ามุมมอง Slide Master เป็นมุมมองเริ่มต้น:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

เพื่อสร้างไฟล์ PPTX ที่สอดคล้องกับโปรไฟล์ Strict ของ Office Open XML ให้สร้างอินสแตนซ์ของ [PptxOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxoptions/) และใช้เมธอด [setConformance](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxoptions/#setConformance-int-) กับค่า [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) จากนั้นส่งตัวเลือกไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ ZIP มาตรฐานจำกัดขนาดบีบอัดและขนาดไม่บีบอัดของแต่ละรายการ, ขนาดรวมของไฟล์ ZIP, และจำนวนรายการ เนื่องจากไฟล์ PPTX เป็นไฟล์ ZIP งานนำเสนอขนาดใหญ่สามารถเกินขีดจำกัดเหล่านี้ได้ ส่วนขยาย ZIP64 จะเพิ่มขีดจำกัดขนาดและจำนวนรายการที่ใช้ได้

ใช้เมธอด [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) เพื่อควบคุมว่าควรให้ Aspose.Slides เขียนส่วนขยาย ZIP64 หรือไม่:

- [IfNecessary](https://reference.aspose.com/slides/th/java/com.aspose.slides/zip64mode/#IfNecessary) ใช้ ZIP64 เฉพาะเมื่องานนำเสนอเกินขีดจำกัด ZIP มาตรฐาน นี่เป็นโหมดเริ่มต้น
- [Never](https://reference.aspose.com/slides/th/java/com.aspose.slides/zip64mode/#Never) ปิดใช้งานส่วนขยาย ZIP64
- [Always](https://reference.aspose.com/slides/th/java/com.aspose.slides/zip64mode/#Always) เขียนส่วนขยาย ZIP64 เสมอ

ตัวอย่างต่อไปนี้เปิดใช้งานส่วนขยาย ZIP64 เสมอสำหรับงานนำเสนอเอาต์พุต:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
หากใช้ [Zip64Mode.Never](https://reference.aspose.com/slides/th/java/com.aspose.slides/zip64mode/#Never) และงานนำเสนอไม่สามารถพอดีกับขีดจำกัด ZIP มาตรฐาน การดำเนินการบันทึกจะโยนข้อยกเว้น [PptxException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

สำหรับการส่งออกเป็น PPTX คุณสามารถปรับสมดุลระหว่างความเร็วในการบันทึกและขนาดไฟล์ได้โดยใช้เมธอด [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) คลาส [CompressionLevel](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/) มีค่าดังนี้:

- [None](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#None) เก็บข้อมูลโดยไม่มีการบีบอัด
- [Level1](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level1) ให้การบีบอัดที่เร็วที่สุดและผลลัพธ์ที่บีบอัดใหญ่ที่สุด
- [Level2](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level2) ถึง [Level5](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level5) ให้ผลลัพธ์ที่เล็กลงเรื่อย ๆ แทนความเร็วในการบันทึก
- [Level6](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level6) สมดุลระหว่างความเร็วการบันทึกและขนาดไฟล์ นี่เป็นระดับเริ่มต้น
- [Level7](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level7) และ [Level8](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level8) ให้ผลลัพธ์ที่เล็กลงต่อไปแทนความเร็ว
- [Level9](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level9) ให้การบีบอัดสูงสุดและต้องการเวลาในการประมวลผลมากที่สุด

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่มีการบีบอัด:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

ตัวอย่างต่อไปนี้ใช้ระดับการบีบอัดสูงสุด:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำโดยไม่รีเฟรชภาพย่อ**

เมื่อบันทึกงานนำเสนอเป็น PPTX เมธอด [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) ควบคุมภาพย่อของเอกสาร:

- `true` สร้างภาพย่อใหม่ในระหว่างการบันทึก นี่เป็นค่าเริ่มต้น
- `false` รักษาภาพย่อที่มีอยู่ หากงานนำเสนอไม่มีภาพย่อ Aspose.Slides จะไม่สร้าง

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่รีเฟรชภาพย่อ:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
การปิดการรีเฟรชภาพย่อสามารถลดเวลาที่ต้องใช้ในการบันทึกไฟล์ PPTX
{{% /alert %}}

## **บันทึกอัพเดตความคืบหน้าเป็นเปอร์เซ็นต์**

เพื่อเฝ้าติดตามการบันทึก ให้ดำเนินการสร้างอินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/) และส่งอิมพลีเมนต์ไปยังเมธอด [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) Aspose.Slides จะเรียกเมธอด [IProgressCallback.reporting](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/#reporting-double-) พร้อมค่าความคืบหน้าในระหว่างการส่งออก

ตัวอย่างต่อไปนี้รายงานความคืบหน้าการส่งออกเป็น PDF ไปยังคอนโซล:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose มีให้บริการฟรี [PowerPoint Splitter](https://products.aspose.app/slides/th/splitter) ที่สร้างด้วย Aspose.Slides API มันบันทึกสไลด์ที่เลือกจากงานนำเสนอเป็นไฟล์ PPT หรือ PPTX แยกกัน
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการบันทึกแบบเพิ่มส่วนหรือ “บันทึกเร็ว” หรือไม่?**

ไม่. แต่ละการบันทึกจะเขียนไฟล์เอาต์พุตเต็มรูปแบบแทนที่จะอัปเดตเฉพาะส่วนที่เปลี่ยนแปลง

**หลายเธรดสามารถบันทึกอินสแตนซ์ Presentationเดียวกันได้หรือไม่?**

ไม่. อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) [ไม่ได้เป็น thread‑safe](/slides/th/java/multithreading/) ให้เข้าถึงและบันทึกแต่ละอินสแตนซ์จากเธรดเดียวเท่านั้น

**จะเกิดอะไรขึ้นกับไฮเปอร์ลิงก์และไฟล์ที่ลิงก์ภายนอกเมื่อฉันบันทึกงานนำเสนอ?**

[Hyperlinks](/slides/th/java/manage-hyperlinks/) จะยังคงอยู่ในงานนำเสนอ Aspose.Slides ไม่คัดลอกไฟล์ที่ลิงก์ภายนอก ดังนั้นงานนำเสนอที่บันทึกจึงต้องสามารถเข้าถึงตำแหน่งไฟล์เหล่านั้นได้

**ฉันสามารถบันทึกเมตาดาต้าเอกสารเช่น ผู้เขียน, ชื่อเรื่อง, บริษัท และวันที่สร้างได้หรือไม่?**

ได้. ตั้งค่าคุณสมบัติของเอกสารที่เหมาะสม [/slides/th/java/presentation-properties/] ก่อนบันทึก และ Aspose.Slides จะเขียนค่าต่าง ๆ เหล่านั้นลงในไฟล์เอาต์พุต