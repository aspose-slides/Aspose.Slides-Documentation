---
title: แปลง PPT และ PPTX เป็น PDF บน Android [รวมคุณสมบัติเพิ่มเติม]
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
description: "แปลง PowerPoint PPT/PPTX เป็น PDF ที่มีคุณภาพสูงและสามารถค้นหาได้ใน Java ด้วย Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF บน Android มีประโยชน์หลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่างๆ และการรักษาเค้าโครงและรูปแบบของงานนำเสนอของคุณ คู่มือนี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่างๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการใส่สไลด์ที่ซ่อนอยู่ การตั้งรหัสผ่านให้ไฟล์ PDF ตรวจจับการแทนที่ฟอนต์ เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานการปฏิบัติตามกับเอกสารที่ส่งออก

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอากิวเมนต์ให้คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด `save` คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เปิดเผยเมธอด `save` ที่มักใช้สำหรับแปลงงานนำเสนอเป็น PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java ใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF, Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าที่มีรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาออกข้อมูลนี้จากเอกสารผลลัพธ์ได้.

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:
* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง รายการและแอตทริบิวต์ต่างๆ จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:
* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดสัญลักษณ์
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // บันทึกงานนำเสนอเป็น PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose มีตัวแปลงออนไลน์ฟรี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides ให้ตัวเลือกแบบกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/)—ที่ทำให้คุณสามารถปรับแต่ง PDF ที่ได้ ล็อก PDF ด้วยรหัสผ่าน หรือกำหนดวิธีการทำงานของกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีการจัดการเมตาฟายล์ ตั้งระดับการบีบอัดสำหรับข้อความ ตั้งค่า DPI สำหรับภาพ ฯลฯ

```java
// สร้างอินสแตนซ์ของคลาส PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// ตั้งค่าคุณภาพสำหรับภาพ JPG.
pdfOptions.setJpegQuality((byte)90);

// ตั้งค่า DPI สำหรับภาพ.
pdfOptions.setSufficientResolution(300);

/// ตั้งค่าพฤติกรรมสำหรับเมตาไฟล์.
pdfOptions.setSaveMetafilesAsPng(true);

// ตั้งค่าระดับการบีบอัดข้อความสำหรับเนื้อหาข้อความ.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// กำหนดโหมดการปฏิบัติตาม PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // บันทึกงานนำเสนอเป็นเอกสาร PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) จากคลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/) เพื่อใส่สไลด์ที่ซ่อนอยู่เป็นหน้าใน PDF ที่ได้

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument
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

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่านโดยใช้พารามิเตอร์การป้องกันจากคลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/) :

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument
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
public static void main(String[] args) {
    // สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument
    Presentation presentation = new Presentation("sample.pptx");

    // ตั้งค่า warning callback ในตัวเลือก PDF
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // บันทึกงานนำเสนอเป็น PDF
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// การทำงานของ warning callback
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

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ โปรดดูบทความ [Font Substitution](/slides/th/androidjava/font-substitution/)

{{% /alert %}} 

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

โค้ดนี้แสดงวิธีแปลงเฉพาะสไลด์ที่เลือกจากงานนำเสนอ PowerPoint เป็น PDF:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument
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
float slideWidth = 612;
float slideHeight = 792;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument
Presentation presentation = new Presentation("SelectedSlides.pptx");

// สร้างงานนำเสนอใหม่ด้วยขนาดสไลด์ที่ปรับแล้ว
Presentation resizedPresentation = new Presentation();

try {
    // ตั้งค่าขนาดสไลด์ที่กำหนดเอง.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // คัดลอกสไลด์แรกจากงานนำเสนอเดิม.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // บันทึกงานนำเสนอที่ปรับขนาดเป็น PDF พร้อมบันทึกข้อความ.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกข้อความ**

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ที่รวมบันทึกข้อความไว้ด้วย:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // กำหนดค่าตัวเลือก PDF ด้วยการจัดวางบันทึกข้อความ.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกข้อความ.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานการปฏิบัติตามเหล่านี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**  

โค้ดนี้แสดงกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:

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

Aspose.Slides รองรับการแปลง PDF ให้เป็นรูปแบบไฟล์ยอดนิยมต่างๆ คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/th/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/th/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/th/java/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/th/java/conversion/pdf-to-png/) ได้ นอกจากนี้ยังรองรับการแปลง PDF ไปยังรูปแบบเฉพาะอื่นๆ เช่น [PDF to SVG](https://products.aspose.com/slides/th/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/java/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/th/java/conversion/pdf-to-xml/) อีกด้วย

{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกที่ซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปเดียว รายการเส้นทางย่อยจะไม่ได้รับการเก็บเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็นศิลปวัตถุ; ข้อความอธิบายจะให้เฉพาะสำหรับรูปทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นชุดได้หรือไม่?**  
ใช่, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปผ่านไฟล์ของคุณและดำเนินการแปลงโดยอัตโนมัติ

**สามารถตั้งรหัสผ่านให้ PDF ที่แปลงแล้วได้หรือไม่?**  
แน่นอน ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงในระหว่างกระบวนการแปลง

**ฉันจะใส่สไลด์ที่ซ่อนอยู่ใน PDF ได้อย่างไร?**  
ใช้เมธอด `setShowHiddenSlides` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**  
ได้, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น `setJpegQuality` และ `setSufficientResolution` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**  
ใช่, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับมาตรฐานต่างๆ รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามข้อกำหนดด้านการเข้าถึงและการเก็บรักษา

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides สำหรับ Android ผ่าน Java](/slides/th/androidjava/)
- [อ้างอิง API Aspose.Slides สำหรับ Android ผ่าน Java](https://reference.aspose.com/slides/th/androidjava/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/th/conversion)