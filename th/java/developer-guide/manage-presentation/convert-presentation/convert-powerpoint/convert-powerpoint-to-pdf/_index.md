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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่สามารถค้นหาได้ใน Java ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน Java มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษาโครงสร้างและการจัดรูปแบบของงานนำเสนอของคุณ คู่มือนี้จะแสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพภาพ รวมถึงสไลด์ที่ซ่อนอยู่ ป้องกัน PDF ด้วยรหัสผ่าน ตรวจจับการทดแทนฟอนต์ เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานความสอดคล้องกับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

ใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ไปยังคลาส[Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)แล้วบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด`save` คลาส[Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)เปิดเผยเมธอด`save`ที่โดยทั่วไปใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java ใส่ข้อมูล API และหมายเลขเวอร์ชันของตนลงในเอกสารผลลัพธ์ ตัวอย่างเช่นเมื่อต้องแปลงงานนำเสนอเป็น PDF Aspose.Slides จะใส่ค่าฟิลด์ Application เป็น "*Aspose.Slides*" และฟิลด์ PDF Producer เป็นค่าที่มีรูปแบบ "*Aspose.Slides v XX.XX*" **Note** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนแปลงหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* ภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ลิงก์ที่อยู่ภายใน
* ส่วนหัวและส่วนท้าย
* จุดสัญลักษณ์
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด

โค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอ (PPT, PPTX, ODP ฯลฯ) เป็น PDF：

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PowerPoint หรือ OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // บันทึกงานนำเสนอเป็น PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose มีเครื่องมือออนไลน์ฟรี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf) ที่สาธิตกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบกับตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides มีตัวเลือกที่กำหนดเอง—คุณสมบัติภายในคลาส[PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/)—ที่ให้คุณปรับแต่ง PDF ที่ได้ ตั้งรหัสผ่านให้กับ PDF หรือกำหนดวิธีการที่กระบวนการแปลงควรทำงาน

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกที่กำหนดเอง**

โดยใช้ตัวเลือกการแปลงที่กำหนดเอง คุณสามารถระบุการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ กำหนดวิธีการจัดการเมทาฟายล์ ตั้งค่าระดับการบีบอัดสำหรับข้อความ กำหนด DPI สำหรับภาพ ฯลฯ

ตัวอย่างโค้ดด้านล่างแสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมตัวเลือกที่กำหนดเองหลายรายการ

```java
// สร้างอินสแตนซ์ของคลาส PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// ตั้งค่าคุณภาพสำหรับภาพ JPG.
pdfOptions.setJpegQuality((byte)90);

// ตั้งค่า DPI สำหรับภาพ.
pdfOptions.setSufficientResolution(300);

// ตั้งค่าพฤติกรรมสำหรับเมทาฟายล์.
pdfOptions.setSaveMetafilesAsPng(true);

// ตั้งค่าระดับการบีบอัดข้อความสำหรับเนื้อหาข้อความ.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// กำหนดโหมดความสอดคล้องของ PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // บันทึกงานนำเสนอเป็นเอกสาร PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด[setShowHiddenSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)จากคลาส[PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/)เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าต่าง PDF ที่ได้

โค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่รวมอยู่ด้วย：

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PowerPoint หรือ OpenDocument file.
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

### **แปลง PowerPoint เป็น PDF ที่ป้องกันด้วยรหัสผ่าน**

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint ให้เป็น PDF ที่ป้องกันด้วยรหัสผ่านโดยใช้พารามิเตอร์การป้องกันจากคลาส[PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/)：

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PowerPoint หรือ OpenDocument file.
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

### **ตรวจจับการทดแทนฟอนต์**

Aspose.Slides มีเมธอด[setWarningCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)ภายใต้คลาส[PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/)ซึ่งทำให้คุณสามารถตรวจจับการทดแทนฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF ได้

โค้ดต่อไปนี้แสดงวิธีตรวจจับการทดแทนฟอนต์：

```java
public static void main(String[] args) {
    // สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PowerPoint หรือ OpenDocument file.
    Presentation presentation = new Presentation("sample.pptx");

    // ตั้งค่า callback สำหรับคำเตือนในตัวเลือก PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // บันทึกงานนำเสนอเป็น PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// การทำงานของ callback สำหรับคำเตือน.
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

{{%  alert color="primary"  %}} 

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการรับคอลแบ็กสำหรับการทดแทนฟอนต์ระหว่างการเรนเดอร์ โปรดดู[Getting Warning Callbacks for Fonts Substitution](/slides/th/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทดแทนฟอนต์ ดูบทความ[Font Substitution](/slides/th/java/font-substitution/)

{{% /alert %}} 

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

โค้ดนี้แสดงวิธีแปลงสไลด์เฉพาะจากงานนำเสนอ PowerPoint เป็น PDF：

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PowerPoint หรือ OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // ตั้งค่าอาเรย์ของหมายเลขสไลด์.
    int[] slides = { 1, 3 };

    // บันทึกงานนำเสนอเป็น PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF พร้อมขนาดสไลด์ที่กำหนดเอง**

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่ระบุ：

```java
float slideWidth = 612;
float slideHeight = 792;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
Presentation resizedPresentation = new Presentation();

try {
    // ตั้งค่าขนาดสไลด์ที่กำหนดเอง.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // คัดลอกสไลด์แรกจากงานนำเสนอเดิม.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // บันทึกงานนำเสนอที่ปรับขนาดแล้วเป็น PDF พร้อมโน้ต.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์โน้ต**

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ที่รวมโน้ตด้วย：

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // กำหนดค่าตัวเลือก PDF ด้วยการจัดเลย์เอาต์โน้ต.
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

## **การเข้าถึงและมาตรฐานความสอดคล้องสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานความสอดคล้องใด ๆ ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ดนี้แสดงกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานความสอดคล้องที่ต่างกัน：

```java
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

Aspose.Slides รองรับการแปลง PDF โดยอนุญาตให้คุณแปลงไฟล์ PDF ไปเป็นรูปแบบไฟล์ที่นิยมต่าง ๆ คุณสามารถทำการแปลง[PDF to HTML](https://products.aspose.com/slides/th/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/th/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/th/java/conversion/pdf-to-jpg/), และ[PDF to PNG](https://products.aspose.com/slides/th/java/conversion/pdf-to-png/)ได้ การแปลง PDF ไปเป็นรูปแบบเฉพาะเช่น[PDF to SVG](https://products.aspose.com/slides/th/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/java/conversion/pdf-to-tiff/), และ[PDF to XML](https://products.aspose.com/slides/th/java/conversion/pdf-to-xml/)ก็ได้รับการสนับสนุนเช่นกัน

{{% /alert %}}

> **Note:** เมื่อส่งออกเป็น PDF/UA Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปหนึ่งเดียว ส่วนประกอบของเส้นทางแยกจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกกำหนดเป็น artifacts; ข้อความแทนที่จะให้ไว้เฉพาะกับรูปทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นกลุ่มได้หรือไม่?**

ได้, Aspose.Slides รองรับการแปลงเป็นกลุ่มของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนซ้ำไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยโปรแกรมได้

**สามารถตั้งรหัสผ่านให้กับ PDF ที่แปลงแล้วได้หรือไม่?**

แน่นอน ใช้คลาส[PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/)เพื่อกำหนดรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**ทำอย่างไรจึงจะรวมสไลด์ที่ซ่อนอยู่ใน PDF?**

ใช้เมธอด`setShowHiddenSlides`ในคลาส[PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/)เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพได้โดยใช้เมธอดเช่น`setJpegQuality`และ`setSufficientResolution`ในคลาส[PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/)เพื่อให้แน่ใจว่าภาพใน PDF มีคุณภาพสูง

**Aspose.Slides รองรับมาตรฐาน PDF/A หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับ[มาตรฐานต่าง ๆ](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfcompliance/)รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามข้อกำหนดด้านการเข้าถึงและการเก็บรักษา

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for Java Documentation](/slides/th/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/th/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/th/conversion)