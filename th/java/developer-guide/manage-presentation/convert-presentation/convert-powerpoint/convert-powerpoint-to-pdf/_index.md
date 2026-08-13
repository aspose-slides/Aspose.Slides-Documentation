---
title: แปลง PPT และ PPTX เป็น PDF ใน Java [รวมคุณลักษณะขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/java/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- แปลงพรีเซนเทชัน
- PowerPoint เป็น PDF
- พรีเซนเทชันเป็น PDF
- PPT เป็น PDF
- แปลง PPT เป็น PDF
- PPTX เป็น PDF
- แปลง PPTX เป็น PDF
- บันทึก PowerPoint เป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่สามารถค้นหาได้ใน Java ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่เร็วและตัวเลือกการแปลงขั้นสูง."
---
## **ภาพรวม**

การแปลงงานพรีเซนเทชัน PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน Java มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่างๆ และการรักษาโครงสร้างและการจัดรูปแบบของพรีเซนเทชันของคุณ คู่มือนี้แสดงวิธีการแปลงพรีเซนเทชันเป็นเอกสาร PDF ใช้ตัวเลือกต่างๆ เพื่อควบคุมคุณภาพของรูปภาพ รวมสไลด์ที่ซ่อนอยู่ ป้องกันไฟล์ PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่ฟอนต์ เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานความสอดคล้องกับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

ด้วย Aspose.Slides คุณสามารถแปลงพรีเซนเทชันในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงพรีเซนเทชันเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) แล้วบันทึกพรีเซนเทชันเป็น PDF ด้วยเมธอด `save` คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เปิดเผยเมธอด `save` ที่มักใช้เพื่อแปลงพรีเซนเทชันเป็น PDF

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java จะใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงพรีเซนเทชันเป็น PDF Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides รองรับการแปลง:

* พรีเซนเทชันทั้งหมดเป็น PDF
* สไลด์ที่ต้องการจากพรีเซนเทชันเป็น PDF

Aspose.Slides ส่งออกพรีเซนเทชันเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับพรีเซนเทชันต้นฉบับอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดแสดงรายการ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint‑to‑PDF มาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงพรีเซนเทชันที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด

โค้ดต่อไปนี้แสดงวิธีแปลงพรีเซนเทชัน (PPT, PPTX, ODP ฯลฯ) เป็น PDF:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // บันทึกพรีเซนเทชันเป็น PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose มีเครื่องมือออนไลน์ฟรี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf) ที่สาธิตกระบวนการแปลงพรีเซนเทชันเป็น PDF คุณสามารถทดสอบด้วยตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides ให้ตัวเลือกที่กำหนดเอง — คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/) — เพื่อปรับแต่ง PDF ที่ได้ ล็อค PDF ด้วยรหัสผ่าน หรือกำหนดวิธีที่กระบวนการแปลงควรดำเนินการ

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกที่กำหนดเอง**

ด้วยตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถระบุการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีการจัดการเมตาฟายล์ ตั้งค่าระดับการบีบอัดสำหรับข้อความ กำหนดค่า DPI สำหรับภาพ ฯลฯ

ตัวอย่างโค้ดด้านล่างแสดงวิธีแปลงพรีเซนเทชัน PowerPoint เป็น PDF พร้อมตัวเลือกกำหนดเองหลายรายการ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// ตั้งค่าคุณภาพสำหรับภาพ JPG.
pdfOptions.setJpegQuality((byte)90);

// ตั้งค่า DPI สำหรับภาพ.
pdfOptions.setSufficientResolution(300);

// ตั้งค่าพฤติกรรมสำหรับเมตาฟายล์.
pdfOptions.setSaveMetafilesAsPng(true);

// ตั้งค่าระดับการบีบอัดข้อความสำหรับเนื้อหาข้อความ.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// กำหนดโหมดความสอดคล้องของ PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // บันทึกพรีเซนเทชันเป็นเอกสาร PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากพรีเซนเทชันมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) จากคลาส [PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้ากระดาษใน PDF ที่ได้

โค้ดนี้แสดงวิธีแปลงพรีเซนเทชัน PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนรวมอยู่:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // เพิ่มสไลด์ที่ซ่อนอยู่.
    pdfOptions.setShowHiddenSlides(true);

    // บันทึกพรีเซนเทชันเป็น PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **แปลง PowerPoint เป็น PDF ที่ป้องกันด้วยรหัสผ่าน**

โค้ดนี้สาธิตวิธีแปลงพรีเซนเทชัน PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่านโดยใช้พารามิเตอร์การป้องกันจากคลาส [PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/) :

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // ตั้งรหัสผ่าน PDF และสิทธิ์การเข้าถึง.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // บันทึกพรีเซนเทชันเป็น PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/) ที่ช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงพรีเซนเทชันเป็น PDF

โค้ดนี้แสดงวิธีตรวจจับการแทนที่ฟอนต์:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument
    Presentation presentation = new Presentation("sample.pptx");

    // ตั้งค่าคอลแบ็กเตือนในตัวเลือก PDF
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // บันทึกพรีเซนเทชันเป็น PDF
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// การนำไปใช้ของคอลแบ็กเตือน
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการรับคอลแบ็กการเตือนสำหรับการแทนที่ฟอนต์ในขั้นตอนการเรนเดอร์ ดูที่ [Getting Warning Callbacks for Fonts Substitution](/slides/th/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ ดูบทความ [Font Substitution](/slides/th/java/font-substitution/)

{{% /alert %}} 

## **แปลงสไลด์ที่เลือกใน PowerPoint เป็น PDF**

โค้ดนี้สาธิตวิธีแปลงเฉพาะสไลด์ที่ต้องการจากพรีเซนเทชัน PowerPoint เป็น PDF:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // ตั้งค่าอาร์เรย์ของหมายเลขสไลด์.
    int[] slides = { 1, 3 };

    // บันทึกพรีเซนเทชันเป็น PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

โค้ดนี้สาธิตวิธีแปลงพรีเซนเทชัน PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่ระบุ:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// สร้างพรีเซนเทชันใหม่ด้วยขนาดสไลด์ที่ปรับแล้ว.
Presentation resizedPresentation = new Presentation();

try {
    // ตั้งค่าขนาดสไลด์แบบกำหนดเอง.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // คัดลอกสไลด์แรกจากพรีเซนเทชันต้นฉบับ.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // ลบสไลด์เปล่าที่พรีเซนเทชันใหม่ถูกสร้างขึ้นมาพร้อม.
    resizedPresentation.getSlides().removeAt(1);

    // บันทึกพรีเซนเทชันที่ปรับขนาดเป็น PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์โน้ต**

โค้ดนี้สาธิตวิธีแปลงพรีเซนเทชัน PowerPoint เป็น PDF ที่รวมโน้ตด้วย:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // กำหนดค่าตัวเลือก PDF พร้อมรูปแบบโน้ต.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกพรีเซนเทชันเป็น PDF พร้อมโน้ต.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **มาตรฐานการเข้าถึงและความสอดคล้องสำหรับ PDF**

Aspose.Slides ช่วยให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ด้วยมาตรฐานความสอดคล้องใดก็ได้ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ดนี้สาธิตกระบวนการแปลง PowerPoint‑to‑PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานความสอดคล้องต่างกัน:

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides รองรับการแปลง PDF ให้เป็นรูปแบบไฟล์ยอดนิยมอื่นๆ คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/th/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/th/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/th/java/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/th/java/conversion/pdf-to-png/) ได้ การแปลง PDF ไปยังรูปแบบพิเศษอื่นๆ เช่น [PDF to SVG](https://products.aspose.com/slides/th/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/java/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/th/java/conversion/pdf-to-xml/) ก็ได้รับการสนับสนุนเช่นกัน

{{% /alert %}}

> **Note:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกที่ซับซ้อน เช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปภาพเดียว ส่วนองค์ประกอบเส้นทางย่อยจะไม่ได้รับการเก็บเป็นเนื้อหาแยกและอาจถูกระบุเป็นอาร์ติแฟกต์; ข้อความแทนที่จะมีเพียงสำหรับรูปภาพเดียวทั้งหมด

## **คำถามที่พบบ่อย**

### ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นชุดได้หรือไม่?

ได้, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและเรียกใช้กระบวนการแปลงแบบโปรแกรม

### สามารถตั้งรหัสผ่านให้กับ PDF ที่แปลงแล้วได้หรือไม่?

แน่นอน ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

### จะรวมสไลด์ที่ซ่อนอยู่ใน PDF อย่างไร?

ใช้เมธอด `setShowHiddenSlides` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

### Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?

ได้, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น `setJpegQuality` และ `setSufficientResolution` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/) เพื่อให้ได้ภาพที่มีคุณภาพสูงใน PDF ของคุณ

### Aspose.Slides รองรับมาตรฐานความสอดคล้อง PDF/A หรือไม่?

ใช่, Aspose.Slides ให้คุณส่งออก PDF ที่สอดคล้องกับ [มาตรฐานต่างๆ](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfcompliance/) รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อตอบสนองความต้องการด้านการเข้าถึงและการเก็บรักษาเอกสาร

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for Java Documentation](/slides/th/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/th/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/th/conversion)