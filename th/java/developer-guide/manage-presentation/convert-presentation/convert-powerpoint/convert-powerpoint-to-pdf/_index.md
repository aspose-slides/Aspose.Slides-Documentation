---
title: แปลง PPT และ PPTX เป็น PDF ใน Java [รวมคุณลักษณะขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูง ที่ค้นหาได้ใน Java ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง."
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP เป็นต้น) ไปเป็นรูปแบบ PDF ด้วย Java มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่างๆ และการรักษาเลย์เอาต์และการจัดรูปแบบของงานนำเสนอ ไฟล์นี้แสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่างๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการรวมสไลด์ที่ซ่อนไว้ ป้องกัน PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่ฟอนต์ เลือกสไลด์ที่ต้องการแปลง และใช้มาตรฐานความสอดคล้องกับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

ด้วย Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้กับคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) คลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) มีเมธอด [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่มักใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java จะใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ไฟล์ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปทรง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงค์
* ส่วนหัวและส่วนท้าย
* จุดหัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้มาเป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดและคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF ด้วยการตั้งค่าการส่งออกเริ่มต้น

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

Aspose มีตัวแปลงออนไลน์ฟรี [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบตัวแปลงนี้เพื่อดูการทำงานจริงตามที่อธิบายในที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides มีตัวเลือกกำหนดเอง—คุณสมบัติภายในคลาส [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)—ที่ให้คุณปรับแต่ง PDF ผลลัพธ์ ล็อค PDF ด้วยรหัสผ่าน หรือกำหนดวิธีที่กระบวนการแปลงควรดำเนินการ

### **แปลง PowerPoint เป็น PDF พร้อมตัวเลือกกำหนดเอง**

ด้วยตัวเลือกการแปลงกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับรูปภาพแบบแรสเตอร์ ระบุวิธีจัดการกับเมตาฟายล์ กำหนดระดับการบีบอัดสำหรับข้อความ ตั้งค่า DPI สำหรับรูปภาพ และอื่นๆ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 โดยตั้งค่าคุณภาพ JPEG เป็น 90 ความละเอียดรูปภาพเป็น 300 DPI บันทึกเมตาฟายล์เป็น PNG และใช้การบีบอัดข้อความแบบ Flate

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

### **เก็บไฟล์ OLE ที่ฝังอยู่เป็นไฟล์แนบ PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ฝังอยู่ คุณอาจต้องให้ผู้รับ PDF เข้าถึงข้อมูลของเวิร์กบุ๊กนั้นพร้อมกับดูสไลด์ เรียกเมธอด [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) ด้วยค่า `true` เพื่อเก็บไฟล์ OLE ที่ฝังอยู่เป็นไฟล์แนบใน PDF ผลลัพธ์

ค่าเริ่มต้นคือ `false`: ภาพตัวอย่างหรือไอคอนของอ็อบเจ็กต์ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังอยู่จะไม่ถูกแนบ การตั้งค่าเป็น `true` จะรวมข้อมูลไฟล์ด้วย ภาพตัวอย่างยังคงเป็นการแสดงภาพ ส่วนไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ที่ฝังแยกจาก PDF ได้ อ็อบเจ็กต์ OLE ไม่กลายเป็นเวิร์กชีท Excel ที่โต้ตอบได้บนหน้า PDF

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

เพื่อดูผลลัพธ์:

1. เปิด PDF ที่ส่งออกในโปรแกรมดูที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมและค้นหาเวิร์กบุ๊กที่ฝังอยู่
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมอนุญาต ภาพตัวอย่างบนหน้า PDF แยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}

มาตรฐาน PDF/A มีข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A-1 ไม่อนุญาตไฟล์ฝัง, PDF/A-2 อนุญาตเฉพาะไฟล์แนบ PDF/A, และ PDF/A-3 อนุญาตไฟล์ประเภทอื่นรวมถึงเวิร์กบุ๊ก Excel นี่เป็นข้อกำหนดของมาตรฐาน ไม่ได้เป็นข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออก PDF/A

{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) จากคลาส [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่เป็นหน้าต่าง PDF ผลลัพธ์

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

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) ที่ช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่ฟอนต์ไปที่คอนโซล คำเตือนจะถูกพิมพ์เฉพาะเมื่อฟอนต์ที่ไม่มีอยู่ถูกแทนที่ระหว่างการส่งออก

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

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ โปรดดูบทความ [การแทนที่ฟอนต์](/slides/th/java/font-substitution/)

{{% /alert %}} 

### **จัดการฟอนต์ที่ไม่มีรูปแบบหนาแยกจากกัน**

งานนำเสนออาจใช้การจัดรูปแบบหนาแม้ว่าแบบอักษรนั้นจะไม่มีรูปแบบหนาแยกจากกัน ข้อความยังคงแสดงเป็นตัวหนาด้วยการทำให้หนาแบบสังเคราะห์ ซึ่งทำให้ glyph ปกติเข้ากลางหนักขึ้น หากข้อความนั้นดูหนามากเกินไปหรือแสดงผลต่างจากที่ต้องการใน PDF ให้ลองเรียกเมธอด [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) ด้วยค่า `true` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิตแมปในระหว่างการส่งออก PDF และอาจทำให้การแสดงผลของฟอนต์บางตัวดีขึ้น ค่าตั้งต้นคือ `false`

งานนำเสนอที่ใช้ตัวอย่างมีสองกล่องข้อความ: กล่องหนึ่งมีข้อความปกติ อีกกล่องหนึ่งมีการจัดรูปแบบหนาที่ใช้แบบอักษรเดียวกันซึ่งไม่มีรูปแบบหนาแยกจากกัน ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เปิดการทำ raster ของสไตล์ฟอนต์ที่ไม่รองรับ และส่งออกเป็น PDF:

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

ภาพตัวอย่างต่อไปนี้แสดงผลลัพธ์ที่ปิดและเปิดตัวเลือก ในตัวอย่างนี้ข้อความหนามีเส้นที่หนากว่าเมื่อปิดตัวเลือก และเส้นที่บางลงเมื่อเปิด ตัวหนังสือปกติไม่เปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนตัดสินใจตั้งค่าสำหรับงานนำเสนอของคุณ

| ตัวเลือกปิดการใช้งาน (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิดการใช้งาน (`true`) |
|---|---|
| ![PDF ที่ปิดการทำ raster ฟอนต์สไตล์หนาที่ไม่รองรับ](unsupported-bold-disabled.png) | ![PDF ที่เปิดการทำ raster ฟอนต์สไตล์หนาที่ไม่รองรับ](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดตัวเลือกทำให้ข้อความหนาเป็นบิตแมปเท่านั้น: ไม่สามารถเลือก คัดลอก หรือค้นหาเป็นข้อความได้โดยไม่มี OCR และขอบของข้อความดูอ่อนลงที่การซูม 800% ข้อความปกติยังคงสามารถค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองสตริงจะยังคงเป็นข้อความ

ตัวเลือกนี้ทำการ raster ข้อความที่จัดรูปแบบเป็นหนาเมื่อแบบอักษรไม่มีรูปแบบหนาแยกจากกัน การ [การแทนที่ฟอนต์](/slides/th/java/font-substitution/) จะเลือกแบบอักษรอื่นเมื่อแบบอักษรเดิมไม่พร้อมใช้งาน

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF หมายเลขสไลด์ในอาเรย์นี้เป็นเลขหนึ่งฐานและงานนำเข้าต้องมีอย่างน้อยสามสไลด์

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

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

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

    // ลบสไลด์ว่างที่สร้างขึ้นโดยงานนำเสนอใหม่.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองโน้ตสไลด์**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางบันทึกของผู้พูดใต้สไลด์แต่ละสไลด์ ใช้งานนำเสนอที่มีบันทึกของผู้พูดเพื่อดูผลลัพธ์

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

## **มาตรฐานการเข้าถึงและความสอดคล้องสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ด้วยมาตรฐานความสอดคล้องใดก็ได้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ดนี้สาธิตกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานความสอดคล้องที่แตกต่างกัน:

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

Aspose.Slides รองรับการดำเนินการแปลง PDF รวมถึงการแปลงไฟล์ PDF ไปเป็นรูปแบบไฟล์ยอดนิยม คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) การแปลง PDF ไปเป็นรูปแบบพิเศษอื่นๆ เช่น [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) ก็ได้รับการสนับสนุนเช่นกัน

{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA Aspose.Slides จะจัดการกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปภาพเดียว ส่วนประกอบเส้นทางย่อยจะไม่คงไว้เป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็น artefacts; ข้อความแทนที่ (alternative text) จะให้เฉพาะสำหรับรูปภาพทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นชุดได้หรือไม่?**

ได้, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยโปรแกรม

**สามารถป้องกัน PDF ที่แปลงแล้วด้วยรหัสผ่านได้หรือไม่?**

ได้. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) เพื่อกำหนดรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**ทำอย่างไรจึงจะรวมสไลด์ที่ซ่อนอยู่ใน PDF?**

เรียกเมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ด้วยค่า `true` ในคลาส [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ผลลัพธ์

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) และ [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) ในคลาส [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานความสอดคล้อง PDF/A หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับ [มาตรฐานต่างๆ](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามข้อกำหนดด้านการเข้าถึงและการเก็บรักษา

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides สำหรับ Java](/slides/th/java/)
- [อ้างอิง API ของ Aspose.Slides สำหรับ Java](https://reference.aspose.com/slides/java/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)