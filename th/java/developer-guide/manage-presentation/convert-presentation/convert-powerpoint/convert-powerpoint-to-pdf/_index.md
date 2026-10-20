---
title: แปลง PPT และ PPTX เป็น PDF ใน Java [รวมคุณลักษณะขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/java/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- PowerPoint เป็น PDF
- การนำเสนอเป็น PDF
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
description: "แปลง PowerPoint PPT/PPTX เป็น PDF ที่มีคุณภาพสูง สามารถค้นหาได้ใน Java ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง."
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ด้วย Java มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษาเค้าโครงและการจัดรูปแบบของงานนำเสนอ ไฟล์นี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงสไลด์ที่ซ่อนไว้ การปกป้อง PDF ด้วยรหัสผ่าน การตรวจจับการแทนที่แบบอักษร การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานการปฏิบัติตามในเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงการนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ไปยังคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) จากนั้นบันทึกการนำเสนอเป็น PDF โดยใช้เมธอด [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) คลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) เปิดเผยเมธอด [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่โดยทั่วไปใช้เพื่อแปลงการนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java ใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงการนำเสนอเป็น PDF Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าที่มีรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides แก้ไขหรือถอดข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้
{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* การนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากการนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ไฟล์ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์จะถูกแสดงผลอย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดหัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงการนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดการนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าเริ่มต้นในการส่งออก

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
Aspose มีตัวแปลงออนไลน์ฟรี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่สาธิตกระบวนการแปลงการนำเสนอเป็น PDF คุณสามารถทดลองใช้ตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides มีตัวเลือกแบบกำหนดเอง—คุณสมบัติต่าง ๆ ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)—ซึ่งช่วยให้คุณปรับแต่ง PDF ที่ได้ ล็อก PDF ด้วยรหัสผ่าน หรือกำหนดวิธีการทำงานของกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีจัดการเมต้าไฟล์ ตั้งค่าระดับการบีบอัดข้อความ กำหนด DPI สำหรับภาพ ฯลฯ

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

### **เลือกการบีบอัดภาพอัตโนมัติ**

เมื่อการนำเสนอมีภาพถ่ายหรือสกรีนช็อตจำนวนมาก การลดขนาด PDF ที่ส่งออกจะทำให้ส่งอีเมลหรือดาวน์โหลดได้ง่ายขึ้น เรียกใช้เมธอด [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) ด้วย `true` เพื่อให้ระบบเลือกอัลกอริทึมการบีบอัดที่เหมาะสมที่สุดสำหรับแต่ละภาพระหว่างการส่งออก PDF

ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีอยู่ เปิดใช้งานการเลือกการบีบอัดภาพอัตโนมัติ และบันทึกเป็นเอกสาร PDF การตั้งค่าอื่น ๆ ของการส่งออก PDF จะคงเป็นค่าเริ่มต้น

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

ตัวเลือกนี้เลือกอัลกอริทึมการบีบอัดสำหรับแต่ละภาพ การลดค่าที่ส่งไปยังเมธอด [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) จะลดคุณภาพภาพ JPEG ส่วนการลดค่าที่ส่งไปยังเมธอด [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) จะทำให้ภาพถูกลดความละเอียด ซึ่งอาจทำให้รายละเอียดลดลง การเปิดใช้งานการเลือกการบีบอัดอัตโนมัติเองไม่ทำให้ค่าทั้งสองนี้ลดลง

การเลือกอัลกอริทึมการบีบอัดภาพต้องใช้เวลาและหน่วยความจำเพิ่มเติม การลดขนาดขึ้นอยู่กับภาพและการตั้งค่าการส่งออกของการนำเสนอ; การลดขนาดคงที่ไม่ได้รับประกันสำหรับทุกการนำเสนอ

### **คงไฟล์ OLE ฝังเป็นไฟล์แนบ PDF**

หากการนำเสนอมีเวิร์กบุ๊ก Excel ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF สามารถเข้าถึงข้อมูลของเวิร์กบุ๊กนั้นได้พร้อมกับดูสไลด์ เรียกเมธอด [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) ด้วย `true` เพื่อคงไฟล์ OLE ที่ฝังเป็นไฟล์แนบใน PDF ที่ได้

ค่าปริยายคือ `false`: ภาพตัวอย่างหรือไอคอนของวัตถุ OLE จะแสดงบนหน้า PDF แต่ไฟล์ที่ฝังอยู่จะไม่ถูกแนบ การตั้งค่าเป็น `true` จะเพิ่มข้อมูลไฟล์เพิ่มเติม ตัวอย่างยังคงแสดงเป็นภาพตัวอย่าง ส่วนไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ที่ฝังแยกออกมาได้ วัตถุ OLE จะไม่กลายเป็นแผ่นงาน Excel ที่โต้ตอบได้บนหน้า PDF

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

1. เปิด PDF ที่ส่งออกในโปรแกรมดูไฟล์ที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมและค้นหาเวิร์กบุ๊กที่ฝังอยู่
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมรองรับ การแสดงตัวอย่างบนหน้า PDF เป็นส่วนแยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A มีข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A-1 ห้ามมีไฟล์ฝังอยู่, PDF/A-2 อนุญาตให้มีไฟล์แนบ PDF/A เท่านั้น, และ PDF/A-3 อนุญาตไฟล์ประเภทอื่น ๆ รวมถึงเวิร์กบุ๊ก Excel สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ได้เป็นข้อจำกัดเฉพาะของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออก PDF/A
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากการนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) จากคลาส [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้ากระดาษใน PDF ที่ได้

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

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงอนุญาตให้พิมพ์รวมถึงการพิมพ์คุณภาพสูง

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

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) ซึ่งช่วยให้คุณตรวจจับการแทนที่แบบอักษรในระหว่างกระบวนการแปลงการนำเสนอเป็น PDF

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
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่แบบอักษร ดูบทความ [การแทนที่แบบอักษร](/slides/th/java/font-substitution/)
{{% /alert %}} 

### **จัดการแบบอักษรที่ไม่มีแบบหนาเฉพาะ**

การนำเสนออาจกำหนดการทำตัวหนาให้กับข้อความแม้ว่าแบบอักษรนั้นจะไม่มีรูปแบบหนาเฉพาะ การทำตัวหนาอาจเกิดจากการทำตัวหนาสังเคราะห์ซึ่งทำให้ glyph ปกติหนาขึ้น เมื่อข้อความแบบหนาดูหนักเกินไปหรือดูแตกต่างจากที่ต้องการใน PDF ให้ลองเรียกเมธอด [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) ด้วย `true` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิทแมพในระหว่างการส่งออก PDF และอาจทำให้แสดงผลดีขึ้นสำหรับแบบอักษรบางประเภท ค่าเริ่มต้นคือ `false`

ตัวอย่างการนำเสนอมีสองกล่องข้อความ: หนึ่งเป็นข้อความปกติและอีกหนึ่งเป็นข้อความหนาที่ใช้แบบอักษรเดียวกันซึ่งไม่มีรูปแบบหนาเฉพาะ ตัวอย่างต่อไปนี้โหลดการนำเสนอ เปิดใช้งานการเรซอร์ไลซ์สไตล์แบบอักษรที่ไม่รองรับ และส่งออกเป็น PDF:

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

ตัวอย่างต่อไปนี้แสดงผลลัพธ์ที่ปิดใช้งานและเปิดใช้งาน ในตัวอย่างนี้ข้อความหนามีเส้นที่หนากว่าตอนที่ปิดใช้งาน เมื่อเปิดใช้งานเส้นจะบางลง; ข้อความปกติไม่มีการเปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนเลือกการตั้งค่าสำหรับการนำเสนอของคุณ

| ตัวเลือกปิดใช้งาน (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิดใช้งาน (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

ในตัวอย่างนี้การเปิดใช้งานตัวเลือกทำให้ข้อความหนาแปลงเป็นบิทแมพเท่านั้น: ไม่สามารถเลือก คัดลอก หรือค้นหาเป็นข้อความได้หากไม่มี OCR และขอบจะดูนุ่มขึ้นเมื่อซูม 800% ข้อความปกติยังคงค้นหาได้ เมื่อปิดใช้งานตัวเลือก ทั้งสองสตริงยังคงเป็นข้อความ

ตัวเลือกนี้เรซอร์ไลซ์ข้อความที่ถูกกำหนดเป็นตัวหนาเมื่อแบบอักษรไม่มีรูปแบบหนาเฉพาะ การ [การแทนที่แบบอักษร](/slides/th/java/font-substitution/) จะเลือกแบบอักษรอื่นเมื่อแบบอักษรต้นฉบับไม่มีอยู่

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากการนำเสนอเป็น PDF หมายเลขสไลด์ในอาร์เรย์นี้เริ่มจาก 1 และการนำเข้าต้องมีอย่างน้อยสามสไลด์

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

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากการนำเสนอไปยังการนำเสนอใหม่โดยกำหนดขนาดสไลด์เป็น 612 × 792 จุด (8.5 × 11 นิ้ว) แล้วปรับสเกลเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF

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

    // ลบสไลด์เปล่าที่สร้างขึ้นพร้อมการนำเสนอใหม่
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์หมายเหตุ**

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF โดยวางบันทึกนักพูดของแต่ละสไลด์ใต้สไลด์ ใช้งานการนำเสนอที่มีบันทึกนักพูดเพื่อดูผลลัพธ์

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

Aspose.Slides อนุญาตให้คุณใช้ขั้นตอนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ด้วยมาตรฐานการปฏิบัติตามใดก็ได้ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

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
Aspose.Slides สนับสนุนการดำเนินการแปลง PDF ซึ่งช่วยให้คุณแปลงไฟล์ PDF ไปยังรูปแบบไฟล์ที่ได้รับความนิยม คุณสามารถทำการแปลง [PDF เป็น HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF เป็น image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF เป็น JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), และ [PDF เป็น PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) การแปลง PDF ไปยังรูปแบบเฉพาะอื่น ๆ เช่น [PDF เป็น SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF เป็น TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), และ [PDF เป็น XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) ก็ได้รับการสนับสนุนเช่นกัน
{{% /alert %}}

> **Note:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปทรงเดียว ส่วนองค์ประกอบเส้นทางแยกจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายว่าเป็น artefact; ข้อความแทนที่จะให้เฉพาะรูปทรงทั้งหมดเท่านั้น

## **FAQ**

**สามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นชุดได้หรือไม่?**

ได้, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX จำนวนหลายไฟล์เป็น PDF คุณสามารถวนลูปผ่านไฟล์ของคุณและใช้ขั้นตอนการแปลงโปรแกรมได้

**สามารถปกป้อง PDF ที่แปลงแล้วด้วยรหัสผ่านได้หรือไม่?**

ได้ ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) เพื่อกำหนดรหัสผ่านและกำหนดการอนุญาตการเข้าถึงในระหว่างกระบวนการแปลง

**ทำอย่างไรให้สไลด์ที่ซ่อนอยู่รวมอยู่ใน PDF?**

เรียกเมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ด้วย `true` ในคลาส [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) และ [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) ในคลาส [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับ [various standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามข้อกำหนดด้านการเข้าถึงและการเก็บรักษา

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides สำหรับ Java](/slides/th/java/)
- [อ้างอิง API Aspose.Slides สำหรับ Java](https://reference.aspose.com/slides/java/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)