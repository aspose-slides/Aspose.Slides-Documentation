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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่ค้นหาได้ใน Java ด้วย Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF บน Android มีประโยชน์หลายประการ รวมถึงความเข้ากันได้ข้ามอุปกรณ์ต่าง ๆ และการคงรักษาเค้าโครงและการจัดรูปแบบของงานนำเสนอ คำแนะนำนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการใส่สไลด์ที่ซ่อนไว้ ป้องกัน PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่ฟอนต์ เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานการปฏิบัติตามสำหรับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด `save` คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) มีเมธอด `save` ที่ใช้ทั่วไปสำหรับการแปลงงานนำเสนอเป็น PDF

{{%  alert title="หมายเหตุ"  color="warning"   %}} 

Aspose.Slides for Android via Java จะใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อนำเสนอถูกแปลงเป็น PDF Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลเหล่านี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปทรง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดสัญลักษณ์
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint‑to‑PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides พยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดที่ระดับคุณภาพสูงสุด

ตัวอย่างโค้ดด้านล่างแสดงวิธีแปลงงานนำเสนอ (PPT, PPTX, ODP ฯลฯ) เป็น PDF:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint หรือ OpenDocument
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // บันทึกงานนำเสนอเป็น PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose มีเครื่องมือแปลงออนไลน์ฟรี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยเครื่องมือนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกกำหนดเอง—คุณสมบัติต่าง ๆ ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/)—ที่ช่วยให้คุณปรับแต่ง PDF ที่ได้ ป้องกัน PDF ด้วยรหัสผ่าน หรือระบุวิธีที่กระบวนการแปลงควรทำงาน

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเอง**

ด้วยตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีจัดการเมตาไฟล์ ตั้งระดับการบีบอัดสำหรับข้อความ กำหนด DPI สำหรับภาพ ฯลฯ

ตัวอย่างโค้ดด้านล่างแสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมตัวเลือกกำหนดเองหลายรายการ:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// ตั้งค่าคุณภาพสำหรับภาพ JPG.
pdfOptions.setJpegQuality((byte)90);

// ตั้งค่า DPI สำหรับภาพ.
pdfOptions.setSufficientResolution(300);

/// ตั้งค่าพฤติกรรมสำหรับเมตาฟไล์.
pdfOptions.setSaveMetafilesAsPng(true);

// ตั้งค่าระดับการบีบอัดข้อความสำหรับเนื้อหาข้อความ.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// กำหนดโหมดการปฏิบัติตามมาตรฐาน PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // บันทึกงานนำเสนอเป็นเอกสาร PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อน**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ของคลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนไว้เป็นหน้าใน PDF ที่ได้

โค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนรวมอยู่:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // เพิ่มสไลด์ที่ซ่อนอยู่.
    pdfOptions.setShowHiddenSlides(true);

    // บันทึกงานนำเสนอเป็น PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ที่ป้องกันด้วยรหัสผ่านโดยใช้พารามิเตอร์การป้องกันจากคลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/):

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // ตั้งรหัสผ่าน PDF และสิทธิ์การเข้าถึง.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // บันทึกงานนำเสนอเป็น PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/) ที่ช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

โค้ดนี้แสดงวิธีตรวจจับการแทนที่ฟอนต์:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint หรือ OpenDocument file.
    Presentation presentation = new Presentation("sample.pptx");

    // ตั้งค่า warning callback ในตัวเลือก PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // บันทึกงานนำเสนอเป็น PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// การทำงานของ warning callback.
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

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ โปรดดูบทความ [Font Substitution](/slides/th/androidjava/font-substitution/)

{{% /alert %}} 

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

โค้ดนี้แสดงวิธีแปลงเฉพาะสไลด์ที่กำหนดจากงานนำเสนอ PowerPoint เป็น PDF:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // ตั้งค่าชุดของหมายเลขสไลด์.
    int[] slides = { 1, 3 };

    // บันทึกงานนำเสนอเป็น PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่ระบุ:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// สร้างงานนำเสนอใหม่พร้อมขนาดสไลด์ที่ปรับแล้ว.
Presentation resizedPresentation = new Presentation();

try {
    // ตั้งค่าขนาดสไลด์ที่กำหนดเอง.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // คัดลอกสไลด์แรกจากงานนำเสนอเดิม.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // ลบสไลด์เปล่าที่งานนำเสนอใหม่ถูกสร้างมาพร้อม.
    resizedPresentation.getSlides().removeAt(1);

    // บันทึกงานนำเสนอที่ปรับขนาดเป็น PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ที่รวมบันทึกย่อ:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // กำหนดค่าตัวเลือก PDF ด้วยการจัดวางโน้ต.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกงานนำเสนอเป็น PDF พร้อมโน้ต.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides ให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ตามมาตรฐานการปฏิบัติตามใด ๆ ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ดนี้แสดงกระบวนการแปลง PowerPoint‑to‑PDF ที่ผลิต PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามต่าง ๆ:

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

{{% alert title="หมายเหตุ" color="warning" %}} 

Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบไฟล์ยอดนิยมอื่น ๆ คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/th/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/th/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/th/java/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/th/java/conversion/pdf-to-png/) ได้ อีกทั้งยังสนับสนุนการแปลง PDF ไปยังรูปแบบพิเศษเช่น [PDF to SVG](https://products.aspose.com/slides/th/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/java/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/th/java/conversion/pdf-to-xml/) ด้วย

{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกที่ซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปเดียว ส่วนองค์ประกอบเส้นทางย่อยจะไม่ถูกเก็บแยกเป็นเนื้อหาและอาจถูกมาร์คเป็น artefact; ข้อความแทนที่ (alternative text) จะมีเฉพาะสำหรับรูปทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

### สามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นชุดได้หรือไม่?

ได้, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยอัตโนมัติได้

### สามารถป้องกัน PDF ที่แปลงแล้วด้วยรหัสผ่านได้หรือไม่?

แน่นอน ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงในกระบวนการแปลง

### จะใส่สไลด์ที่ซ่อนไว้ใน PDF อย่างไร?

ใช้เมธอด `setShowHiddenSlides` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนไว้ใน PDF ที่ได้

### Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?

ได้, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น `setJpegQuality` และ `setSufficientResolution` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

### Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?

ได้, Aspose.Slides ให้คุณส่งออก PDF ที่สอดคล้องกับมาตรฐานต่าง ๆ ได้แก่ PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงกับข้อกำหนดการเข้าถึงและการเก็บรักษา

## **ทรัพยากรเพิ่มเติม**

- [Aspose.Slides for Android via Java Documentation](/slides/th/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/th/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/th/conversion)