---
title: แปลง PPT และ PPTX เป็น PDF บน Android [รวมคุณสมบัติขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/androidjava/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- PowerPoint เป็น PDF
- งานนำเสนอเป็น PDF
- PPT เป็น PDF
- แปลง PPT เป็น PDF
- PPTX เป็น PDF
- แปลง PPTX เป็น PDF
- บันทึก PowerPoint เป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- ไฟล์แนบ
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่สามารถค้นหาได้ใน Java ด้วย Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF บน Android มีประโยชน์หลายอย่าง รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษาเค้าโครงและรูปแบบของงานนำเสนอ คำแนะนำนี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการรวมสไลด์ที่ซ่อนอยู่ การตั้งรหัสผ่านให้ไฟล์ PDF การตรวจจับการแทนที่ฟอนต์ การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานการปฏิบัติตามในเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้นำชื่อไฟล์เป็นอาร์กิวเมนต์ไปยังคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) จากนั้นบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) คลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) เปิดเผยเมธอด [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ซึ่งมักใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java จะใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides จะใส่ค่าในฟิลด์ Application เป็น "*Aspose.Slides*" และฟิลด์ PDF Producer เป็นค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถบอกให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้
{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์ต่าง ๆ จะถูกแปลงอย่างแม่นยำ รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปทรง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดสัญลักษณ์
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ระบุเป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดที่ระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF ด้วยการตั้งค่าการส่งออกค่าเริ่มต้น

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose มีตัวแปลงออนไลน์ฟรี [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่สาธิตกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดลองใช้ตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายที่นี่
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มอบตัวเลือกกำหนดเอง—properties ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—ที่ให้คุณปรับแต่ง PDF ผลลัพธ์ ล็อค PDF ด้วยรหัสผ่าน หรือกำหนดวิธีการทำงานของกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเอง**

โดยใช้ตัวเลือกการแปลงกำหนดเอง คุณสามารถระบุการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ กำหนดวิธีการจัดการ metafile ตั้งค่าระดับการบีบอัดสำหรับข้อความ กำหนด DPI สำหรับภาพ ฯลฯ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 พร้อมคุณภาพ JPEG ที่ 90 ความละเอียดภาพที่ 300 DPI การบันทึก metafile เป็น PNG และการบีบอัดข้อความแบบ Flate

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **เก็บไฟล์ OLE ที่ฝังไว้เป็นไฟล์แนบ PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ที่ฝังอยู่ คุณอาจต้องให้ผู้รับ PDF เข้าถึงข้อมูลของเวิร์กบุ๊กพร้อมกับดูสไลด์ได้ เรียกเมธอด [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) ด้วยค่า `true` เพื่อเก็บไฟล์ OLE ที่ฝังไว้เป็นไฟล์แนบใน PDF ผลลัพธ์

ค่าดีฟอลต์คือ `false`: ภาพตัวอย่างหรือไอคอนของวัตถุ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังไว้จะไม่ถูกแนบ การตั้งค่าเป็น `true` จะรวมข้อมูลไฟล์ด้วย ภาพตัวอย่างยังคงเป็นการแสดงผลแบบภาพเท่านั้น; ไฟล์แนจทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ที่ฝังแยกต่างหากได้ วัตถุ OLE จะไม่กลายเป็นแผ่นงาน Excel ที่โต้ตอบได้บนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

เพื่อตรวจสอบผลลัพธ์:

1. เปิด PDF ที่ส่งออกในโปรแกรมที่สนับสนุนไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมและค้นหาเวิร์กบุ๊กที่ฝังไว้
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมอนุญาต ตัวอย่างบนหน้า PDF จะเป็นแยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A กำหนดข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A-1 ห้ามมีไฟล์ฝังอยู่, PDF/A-2 อนุญาตเฉพาะไฟล์แนบ PDF/A, และ PDF/A-3 อนุญาตไฟล์ประเภทอื่นรวมถึงเวิร์กบุ๊ก Excel สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ใช่ข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออกเป็น PDF/A
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) จากคลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่เป็นหน้าต่าง PDF ผลลัพธ์

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF พร้อมรวมสไลด์ที่ซ่อนอยู่ทั้งหมด

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **แปลง PowerPoint เป็น PDF ที่มีการตั้งรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การกำหนดสิทธิ์การเข้าถึงอนุญาตให้พิมพ์ รวมถึงพิมพ์คุณภาพสูง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) ที่ช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่ฟอนต์ลงคอนโซล คำเตือนจะปรากฏเฉพาะเมื่อฟอนต์ที่ไม่มีในระบบถูกแทนที่ระหว่างการส่งออก

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ โปรดดูบทความ [Font Substitution](/slides/th/androidjava/font-substitution/)
{{% /alert %}} 

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF ตัวเลขสไลด์ในอาเรย์นี้เริ่มจาก 1 และงานนำเข้าต้องมีอย่างน้อยสามสไลด์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF พร้อมขนาดสไลด์กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเสนอไปยังงานนำเสนอใหม่ที่มีขนาดสไลด์ 612 × 792 จุด (8.5 × 11 นิ้ว) ปรับขนาดเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // ลบสไลด์ว่างที่สร้างขึ้นในงานนำเสนอใหม่.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางบันทึกย่อของผู้พูดใต้สไลด์แต่ละสไลด์ ใช้งานนำเสนอที่มีบันทึกย่อของผู้พูดเพื่อดูผลลัพธ์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides ให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ด้วยมาตรฐานการปฏิบัติตามเหล่านี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ดต่อไปนี้สาธิตกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามต่าง ๆ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบไฟล์ที่นิยม คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) รวมถึงการแปลง PDF ไปยังรูปแบบเฉพาะอื่น ๆ เช่น [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) ด้วย
{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, ชาร์ต, และสูตรเป็นรูปเดียว ไม่ได้เก็บส่วนประกอบเส้นทางแยกเป็นเนื้อหาแยก และอาจถูกจัดเป็น artefacts; ข้อความแทนที่ (alternative text) จะถูกให้เฉพาะรูปทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF พร้อมกันได้หรือไม่?**

ได้, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยอัตโนมัติ

**สามารถตั้งรหัสผ่านให้ PDF ที่แปลงแล้วได้หรือไม่?**

ได้ ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**จะรวมสไลด์ที่ซ่อนอยู่ใน PDF อย่างไร?**

เรียกเมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ด้วยค่า `true` ในคลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ผลลัพธ์

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้ คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) และ [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) ในคลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) เพื่อรับประกันภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐาน PDF/A หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับ [มาตรฐานต่าง ๆ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามความต้องการด้านการเข้าถึงและการจัดเก็บระยะยาว

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for Android via Java Documentation](/slides/th/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)