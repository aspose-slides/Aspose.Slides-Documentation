---
title: บันทึกงานนำเสนอบน Android
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/androidjava/save-presentation/
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
- Android
- Java
- Aspose.Slides
description: "บันทึกงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีมบน Android ด้วย Aspose.Slides และกำหนดการส่งออก PPTX พร้อมการรายงานความคืบหน้า."
---
## **ภาพรวม**

หลังจากที่คุณสร้างงานนำเสนอหรือ[เปิดงานนำเสนอที่มีอยู่แล้ว](/slides/th/androidjava/open-presentation/), ใช้เมธอด[Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)เพื่อเขียนผลลัพธ์ Aspose.Slides for Android via Java สามารถบันทึกงานนำเสนอเป็นไฟล์หรือสตรีมในรูปแบบ PowerPoint, OpenDocument, PDF และรูปแบบอื่นๆ ส่วนต่อไปนี้ครอบคลุมการดำเนินการบันทึกมาตรฐานและตัวเลือกที่มีสำหรับผลลัพธ์ PPTX

## **บันทึกงานนำเสนอเป็นไฟล์**

เพื่อบันทึกงานนำเสนอเป็นไฟล์, ให้ส่งพาธเอาต์พุตและค่า[SaveFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/)ไปยังเมธอด[Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ค่าฟอร์แมตกำหนดประเภทของไฟล์ที่ Aspose.Slides สร้าง

ตัวอย่างต่อไปนี้สร้างงานนำเสนอและบันทึกเป็นไฟล์ PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // เพิ่มหรือแก้ไขเนื้อหางานนำเสนอที่นี่.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบต้นฉบับของมัน**

สำหรับตัวอย่างการตรวจจับไฟล์และสตรีม, พฤติกรรมของงานนำเสนอที่สร้างใหม่, และความแตกต่างระหว่างรูปแบบต้นทางและเอาต์พุต, ดู[Determine the Original Presentation Format](/slides/th/androidjava/detect-presentation-source-format/)

ในแอปพลิเคชันประมวลผลเป็นชุด, รูปแบบอินพุตอาจไม่ทราบล่วงหน้า หลังจากโหลดไฟล์ให้อ่านรูปแบบต้นฉบับจากเมธอด[IPresentation.getSourceFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) ส่งค่าที่ได้ของ[SourceFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sourceformat/)ไปยัง[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-)เพื่อรับค่า[SaveFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/)ที่สอดคล้องกัน แล้วใช้[Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)เพื่อเขียนงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างเต็มต่อไปนี้ประมวลผลไฟล์ทุกไฟล์ในไดเรกทอรีอินพุต, อัปเดตชื่อเรื่องของมัน, และบันทึกไปยังไดเรกทอรีเอาต์พุตในรูปแบบที่โหลดมา:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) แมป PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP และ PowerPoint XML ไปยังรูปแบบบันทึกงานนำเสนอที่สอดคล้องกัน มันแมปเฉพาะรูปแบบต้นทางของงานนำเสนอ; ไม่ได้ตั้งใจให้เลือกรูปแบบส่งออกเช่น PDF, HTML, TIFF หรือรูปภาพ การส่งค่าที่ไม่รองรับหรือไม่ถูกต้องของ[SourceFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sourceformat/)จะทำให้เกิด[IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException)

ไฟล์ PPT, PPS, และ POT รุ่นเก่าใช้คอนเทนเนอร์ไบนารีเดียวกัน เมื่อโหลดงานนำเสนอจากสตรีมที่ไม่มีส่วนขยายไฟล์ ไฟล์ PPS หรือ POT อาจถูกระบุเป็น PPT หากต้องการรักษาช่วงย่อยรุ่นเก่าเหล่านี้ไว้ ให้เก็บชื่อไฟล์หรือเมตาดาต้ารูปแบบต้นฉบับแยกต่างหากและใช้เมื่อเลือกชื่อไฟล์และรูปแบบเอาต์พุต

## **บันทึกงานนำเสนอเป็นสตรีม**

เพื่อเขียนงานนำเสนอโดยไม่ต้องอ้างอิงพาธไฟล์สุดท้าย, ให้ส่งสตรีมที่เขียนได้และค่า[SaveFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/)ไปยังเมธอด[Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) วิธีนี้มีประโยชน์เมื่อเอาต์พุตต้องคืนค่าจากเว็บเซอร์วิส, เก็บในฐานข้อมูล, หรือประมวลผลในหน่วยความจำ

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

## **บันทึกงานนำเสนอด้วยประเภทมุมมองที่กำหนดล่วงหน้า**

คุณสามารถระบุมุมมองที่ PowerPoint เปิดงานนำเสนอที่บันทึกไว้ครั้งแรกได้ ใช้เมธอด[ViewProperties.setLastView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/#setLastView-int-)ร่วมกับค่า[ViewType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewtype/)ก่อนบันทึก

ตัวอย่างต่อไปนี้กำหนดให้มุมมอง Slide Master เป็นมุมมองเริ่มต้น:

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

เพื่อสร้างไฟล์ PPTX ที่สอดคล้องกับโปรไฟล์ Strict ของ Office Open XML, สร้างอินสแตนซ์[PptxOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxoptions/)และใช้เมธอด[setConformance](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-)ร่วมกับ[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) จากนั้นส่งอ็อปชันไปยังเมธอด[Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)

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

ไฟล์ ZIP มาตรฐานจำกัดขนาดข้อมูลบีบอัดและไม่บีบอัดของแต่ละรายการ, ขนาดทั้งหมดของไฟล์ ZIP, และจำนวนรายการ เนื่องจากไฟล์ PPTX เป็นไฟล์ ZIP, งานนำเสนอที่มีขนาดใหญ่มากอาจเกินขีดจำกัดเหล่านั้น ส่วนขยาย ZIP64 จึงเพิ่มขีดจำกัดขนาดและจำนวนรายการที่ใช้ได้

ใช้เมธอด[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-)เพื่อควบคุมว่าการเขียนส่วนขยาย ZIP64 จะทำหรือไม่:

- [IfNecessary](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/zip64mode/#IfNecessary) ใช้ ZIP64 เฉพาะเมื่องานนำเสนอเกินขีดจำกัด ZIP มาตรฐาน นี่เป็นโหมดเริ่มต้น
- [Never](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/zip64mode/#Never) ปิดการใช้ส่วนขยาย ZIP64
- [Always](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/zip64mode/#Always) เขียนส่วนขยาย ZIP64 เสมอสำหรับเอาต์พุต

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
หากใช้[Zip64Mode.Never](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/zip64mode/#Never)และงานนำเสนอไม่สามารถอยู่ภายในขีดจำกัด ZIP มาตรฐานการบันทึกจะโยน[PptxException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxexception/)ออกมา
{{% /alert %}}

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

สำหรับผลลัพธ์ PPTX, คุณสามารถปรับสมดุลระหว่างความเร็วในการบันทึกและขนาดไฟล์โดยใช้เมธอด[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) คลาส[CompressionLevel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compressionlevel/) มีค่าต่อไปนี้:

- [None](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compressionlevel/#None) จัดเก็บข้อมูลโดยไม่บีบอัด
- [Level1](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compressionlevel/#Level1) ให้การบีบอัดที่เร็วที่สุดและผลลัพธ์ที่บีบอัดขนาดใหญ่ที่สุด
- [Level2](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compressionlevel/#Level2) ถึง [Level5](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compressionlevel/#Level5) ค่อย ๆ ให้ความสำคัญกับผลลัพธ์ที่เล็กลงมากกว่าความเร็วในการบันทึก
- [Level6](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compressionlevel/#Level6) สมดุลระหว่างความเร็วในการบันทึกและขนาดไฟล์ นี่เป็นระดับค่าเริ่มต้น
- [Level7](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compressionlevel/#Level7) และ [Level8](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compressionlevel/#Level8) ให้ความสำคัญกับผลลัพธ์ที่เล็กลงมากกว่าความเร็วในการบันทึกเพิ่มเติม
- [Level9](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compressionlevel/#Level9) ให้การบีบอัดที่เข้มที่สุดและต้องการเวลาประมวลผลมากที่สุด

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

## **บันทึกงานนำเสนอโดยไม่รีเฟรชภาพย่อ**

เมื่อบันทึกงานนำเสนอเป็น PPTX, เมธอด[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) ควบคุมภาพย่อของเอกสาร:

- `true` สร้างภาพย่อใหม่ในระหว่างการบันทึก นี่เป็นค่าเริ่มต้น
- `false` รักษาภาพย่อที่มีอยู่ หากงานนำเสนอไม่มีภาพย่อ Aspose.Slides จะไม่สร้างขึ้น

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่รีเฟรชภาพย่อของมัน:

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
การปิดการรีเฟรชภาพย่อสามารถลดเวลาที่ใช้ในการบันทึกไฟล์ PPTX ได้
{{% /alert %}}

## **บันทึกการอัปเดตความคืบหน้าเป็นเปอร์เซ็นต์**

เพื่อเฝ้าติดตามการบันทึก, ให้ทำการติดตั้งอินเทอร์เฟซ[IProgressCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprogresscallback/)และส่งอิมพลิเมนต์ไปยังเมธอด[ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) Aspose.Slides จะเรียกเมธอด[IProgressCallback.reporting](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) พร้อมค่าความคืบหน้าในระหว่างการส่งออก

ตัวอย่างต่อไปนี้รายงานความคืบหน้าในการส่งออก PDF ไปยังคอนโซล:

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
Aspose มีเครื่องมือ[PowerPoint Splitter]ฟรีที่สร้างด้วย Aspose.Slides API ซึ่งบันทึกสไลด์ที่เลือกจากงานนำเสนอเป็นไฟล์ PPT หรือ PPTX แยกกัน
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการบันทึกแบบเพิ่มส่วนหรือ “fast save” หรือไม่?**

ไม่ ระบบบันทึกแต่ละครั้งจะเขียนไฟล์เอาต์พุตที่สมบูรณ์ ไม่ได้อัปเดตเฉพาะส่วนที่เปลี่ยนแปลงเท่านั้น

**หลายเธรดสามารถบันทึกอินสแตนซ์ Presentation เดียวกันได้หรือไม่?**

ไม่ อินสแตนซ์[Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) **ไม่ได้เป็น thread‑safe**[/slides/th/androidjava/multithreading/] ให้เข้าถึงและบันทึกแต่ละอินสแตนซ์จากเธรดเดียวเท่านั้น

**ลิงก์และไฟล์ที่เชื่อมโยงภายนอกจะเกิดอะไรขึ้นเมื่อบันทึกงานนำเสนอ?**

[Hyperlinks](/slides/th/androidjava/manage-hyperlinks/) จะคงอยู่ในงานนำเสนอ Aspose.Slides ไม่ทำการคัดลอกไฟล์ที่เชื่อมโยงภายนอก ดังนั้นงานนำเสนอที่บันทึกไว้ต้องยังคงเข้าถึงตำแหน่งนั้นได้

**ฉันสามารถบันทึกเมตาดาต้าเอกสาร เช่น ผู้เขียน, ชื่อเรื่อง, บริษัทและวันสร้างได้หรือไม่?**

ได้ ตั้งคุณสมบัติ[document properties](/slides/th/androidjava/presentation-properties/)ที่ต้องการก่อนบันทึก แล้ว Aspose.Slides จะเขียนลงในไฟล์เอาต์พุต