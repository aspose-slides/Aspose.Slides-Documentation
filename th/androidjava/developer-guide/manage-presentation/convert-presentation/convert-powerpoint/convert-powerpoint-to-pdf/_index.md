---
title: แปลง PPT และ PPTX เป็น PDF บน Android [รวมฟีเจอร์ขั้นสูง]
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
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่ค้นหาได้ใน Java ด้วย Aspose.Slides for Android พร้อมตัวอย่างโค้ดที่เร็วและตัวเลือกการแปลงขั้นสูง."
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF บน Android มีข้อได้เปรียบหลายอย่าง รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษาเค้าโครงและการจัดรูปแบบของงานนำเสนอ คำแนะนำนี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพรูปภาพ รวมสไลด์ที่ซ่อนอยู่ ป้องกันไฟล์ PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่แบบอักษร เลือกสไลด์เฉพาะเพื่อแปลง และใช้มาตรฐานการปฏิบัติตามเพื่อสร้างเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

ด้วย Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้กับคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) จากนั้นบันทึกงานนำเสนอเป็น PDF ด้วยวิธีการ [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) คลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) มีเมธอด [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่มักใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}

Aspose.Slides for Android via Java ใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides จะใส่ค่าในฟิลด์ Application เป็น "*Aspose.Slides*" และฟิลด์ PDF Producer เป็นรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์ที่ระบุจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์ต่าง ๆ จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดสัญลักษณ์หัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint‑to‑PDF มาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดและคุณภาพสูงสุด

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

Aspose มีเครื่องมือออนไลน์ฟรี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยเครื่องมือนี้เพื่อดูการทำงานจริงตามที่อธิบายในที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกแบบกำหนดเอง—คุณสมบัติต่าง ๆ ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—ที่ให้คุณปรับแต่ง PDF ที่สร้างขึ้น ล็อก PDF ด้วยรหัสผ่าน หรือกำหนดวิธีการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกที่กำหนดเอง**

ด้วยตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีจัดการ metafile ตั้งค่าระดับการบีบอัดข้อความ กำหนด DPI สำหรับภาพ เป็นต้น

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 พร้อมคุณภาพ JPEG ที่ 90 ความละเอียดภาพที่ 300 DPI เมตาไฟล์บันทึกเป็น PNG และการบีบอัดข้อความแบบ Flate

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

### **คงรักษาไฟล์ OLE ที่ฝังอยู่เป็นไฟล์แนบใน PDF**

หากงานนำเสนอมีเวิร์กบุ๊ค Excel ที่ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF เข้าถึงข้อมูลในเวิร์กบุ๊คพร้อมดูสไลด์ได้ เรียกเมธอด [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) ด้วยค่า `true` เพื่อคงไฟล์ OLE ที่ฝังไว้เป็นไฟล์แนบใน PDF ที่สร้าง

ค่าเริ่มต้นคือ `false`: รูปภาพหรือไอคอนตัวอย่างของวัตถุ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังอยู่จะไม่รวมเป็นไฟล์แนบ การตั้งค่าเป็น `true` จะเพิ่มไฟล์ข้อมูลลงด้วย ตัวอย่างจะยังคงเป็นเพียงภาพตัวอย่าง ส่วนไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ฝังแยกต่างหากได้ วัตถุ OLE จะไม่ได้กลายเป็นแผ่นงาน Excel ที่โต้ตอบได้บนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ค Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ค

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

1. เปิด PDF ที่ส่งออกในโปรแกรมดูที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมดูและค้นหาเวิร์กบุ๊คที่ฝังอยู่
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมดูอนุญาต การแสดงตัวอย่างบนหน้า PDF จะเป็นแยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}

มาตรฐาน PDF/A มีข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A‑1 ไม่อนุญาตให้ฝังไฟล์, PDF/A‑2 อนุญาตเฉพาะไฟล์แนบ PDF/A, PDF/A‑3 อนุญาตประเภทไฟล์อื่น ๆ รวมถึงเวิร์กบุ๊ค Excel สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ได้เป็นข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออก PDF/A

{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) จากคลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนไว้เป็นหน้าใน PDF ที่สร้าง

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

### **แปลง PowerPoint เป็น PDF ที่ป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงอนุญาตให้พิมพ์ รวมถึงการพิมพ์คุณภาพสูง

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

### **ตรวจจับการแทนที่แบบอักษร**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) ที่ทำให้คุณสามารถตรวจจับการแทนที่แบบอักษรระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่แบบอักษรไปยังคอนโซล คำเตือนจะปรากฏเฉพาะเมื่อแบบอักษรที่ไม่มีอยู่ถูกแทนที่ระหว่างการส่งออก

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

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่แบบอักษร ดูบทความ [Font Substitution](/slides/th/androidjava/font-substitution/)

{{% /alert %}} 

### **จัดการแบบอักษรที่ไม่มีรูปแบบ Bold แยก**

งานนำเสนออาจใช้การจัดรูปแบบตัวหนาแม้ว่าแบบอักษรนั้นจะไม่มีรูปแบบ Bold แยก ตัวอักษรจะถูกทำให้ดูหนาโดยการทำให้ glyphs ปกติหนาขึ้น หากข้อความนั้นดูหนักเกินไปหรือแตกต่างจากที่ต้องการใน PDF ให้ลองเรียกเมธอด [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) ด้วยค่า `true` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิตแมพระหว่างการส่งออก PDF และอาจทำให้ลักษณะของฟอนต์บางอย่างดีขึ้น ค่าเริ่มต้นคือ `false`

งานนำเสนอตัวอย่างมีสองกล่องข้อความ: หนึ่งมีข้อความปกติและอีกหนึ่งมีการจัดรูปแบบตัวหนาใช้แบบอักษรเดียวกันที่ไม่มีรูปแบบ Bold แยก ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เปิดใช้งานการเรขลักษณ์ของรูปแบบฟอนต์ที่ไม่รองรับ และส่งออกเป็น PDF:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

ภาพตัวอย่างต่อไปนี้แสดงผลลัพธ์ที่ปิดและเปิดตัวเลือก ในตัวอย่างนี้ข้อความตัวหนามีเส้นหนาขึ้นเมื่อปิดตัวเลือก เมื่อเปิดตัวเลือก เส้นจะบางลง; ข้อความปกติไม่ได้เปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนตัดสินใจเลือกการตั้งค่าสำหรับงานนำเสนอของคุณ

| ตัวเลือกปิด (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดใช้งานตัวเลือกทำให้ข้อความตัวหนาเท่านั้นกลายเป็นบิตแมพ: ไม่สามารถเลือก, คัดลอก หรือค้นหาเป็นข้อความได้โดยไม่มี OCR และขอบของข้อความจะดูนุ่มขึ้นที่การซูม 800% ข้อความปกติยังคงสามารถค้นหาได้ ส่วนตัวเลือกปิดทั้งสองสตริงจะยังคงเป็นข้อความ

ตัวเลือกนี้ทำให้ข้อความที่จัดรูปแบบเป็นตัวหนาเมื่อแบบอักษรไม่มีรูปแบบ Bold แยกถูกเรขลักษณ์เป็นบิตแมพ การ [Font substitution](/slides/th/androidjava/font-substitution/) จะเลือกแบบอักษรอื่นเมื่อแบบอักษรเดิมไม่พร้อมใช้งาน

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF หมายเลขสไลด์ในอาร์เรย์นี้เริ่มจาก 1 และงานนำเข้าต้องมีอย่างน้อยสามสไลด์

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

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์แบบกำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเสนอไปยังงานนำเสนอใหม่ที่มีขนาดสไลด์ 612 × 792 จุด (8.5 × 11 นิ้ว) ปรับสเกลเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF

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

    // ลบสไลด์ว่างที่สร้างขึ้นโดยงานนำเสนอใหม่
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยใส่โน๊ตของผู้พูดใต้สไลด์แต่ละหน้า ใช้งานนำเสนอที่มีโน๊ตผู้พูดเพื่อดูผลลัพธ์

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

## **การเข้าถึงและมาตรฐานการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint ไปเป็น PDF ด้วยมาตรฐานการปฏิบัติตามใด ๆ ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ดนี้สาธิตกระบวนการแปลง PowerPoint‑to‑PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:

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

Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบไฟล์ยอดนิยม คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) นอกจากนี้ยังรองรับการแปลง PDF ไปยังรูปแบบเฉพาะเช่น [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)

{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA Aspose.Slides จะถือกราฟิกที่ซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรว่าเป็นรูปภาพเดียว ไม่ได้เก็บส่วนของเส้นทางเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็นสิ่งประดิษฐ์; ข้อความแทน (alternative text) จะจัดให้เฉพาะภาพทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF แบบกลุ่มได้หรือไม่?**

ได้, Aspose.Slides รองรับการแปลงเป็นกลุ่มของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและดำเนินการแปลงโดยอัตโนมัติ

**สามารถตั้งรหัสผ่านให้กับ PDF ที่แปลงแล้วได้หรือไม่?**

ได้. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**ทำอย่างไรจึงจะรวมสไลด์ที่ซ่อนอยู่ใน PDF?**

เรียกเมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ด้วยค่า `true` ในคลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่สร้าง

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) และ [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) ในคลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) เพื่อให้แน่ใจว่าภาพใน PDF ของคุณมีคุณภาพสูง

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับ [มาตรฐานต่าง ๆ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตอบสนองต่อความต้องการด้านการเข้าถึงและการเก็บรักษา

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for Android via Java Documentation](/slides/th/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)