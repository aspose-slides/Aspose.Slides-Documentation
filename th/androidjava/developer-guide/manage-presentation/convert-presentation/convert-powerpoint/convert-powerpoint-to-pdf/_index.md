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
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงและค้นหาได้ใน Java ด้วย Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ดที่เร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF บน Android มีข้อได้เปรียบหลายประการรวมถึงความเข้ากันได้กับอุปกรณ์หลายประเภทและการคงรูปแบบการจัดวางและการจัดรูปแบบของงานนำเสนอของคุณ คำแนะนำนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงสไลด์ที่ซ่อนอยู่ ป้องกัน PDF ด้วยรหัสผ่าน ตรวจจับการทดแทนแบบอักษร เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานความสอดคล้องกับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

ด้วย Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้คลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF ด้วยวิธีการ [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) คลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) เปิดเผยวิธีการ [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่โดยทั่วไปใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}

Aspose.Slides for Android via Java จะใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าที่อยู่ในรูปแบบ "*Aspose.Slides v XX.XX*" **Note** ว่าไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์ต่าง ๆ จะถูกเรนเดอร์อย่างแม่นยำในระหว่างการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปทรง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดสัญลักษณ์หัวข้อย่อย
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint‑to‑PDF มาตรฐานใช้ตัวเลือกเริ่มต้นในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดที่ระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าเริ่มต้นของการส่งออก

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

Aspose มีตัวแปลงออนไลน์ฟรี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยเครื่องมือนี้เพื่อดูการดำเนินการจริงตามที่อธิบายไว้ที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides มีตัวเลือกที่กำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—ที่ทำให้คุณสามารถปรับแต่ง PDF ที่ได้ ล็อก PDF ด้วยรหัสผ่าน หรือระบุวิธีการทำงานของกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF พร้อมตัวเลือกกำหนดเอง**

โดยใช้ตัวเลือกการแปลงที่กำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีจัดการ metafile ตั้งค่าระดับการบีบอัดข้อความ กำหนด DPI สำหรับภาพ และอื่น ๆ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 พร้อมคุณภาพ JPEG ที่ 90 ความละเอียดภาพที่ 300 DPI เก็บ metafile เป็น PNG และการบีบอัดข้อความแบบ Flate

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

เมื่องานนำเสนอมีรูปถ่ายหรือสกรีนช็อตจำนวนมาก การลดขนาดของ PDF ที่ส่งออกอาจทำให้อีเมลหรือการดาวน์โหลดง่ายขึ้น เรียกใช้ [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) ด้วย `true` เพื่อให้ระบบเลือกอัลกอริธึมบีบอัดที่เหมาะสมที่สุดสำหรับแต่ละภาพโดยอัตโนมัติระหว่างการส่งออก PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีอยู่แล้ว เปิดใช้งานการเลือกการบีบอัดภาพอัตโนมัติ และบันทึกเป็นเอกสาร PDF การตั้งค่าอื่น ๆ ของการส่งออก PDF จะคงค่าเริ่มต้นเดิม

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

ตัวเลือกนี้เลือกอัลกอริธึมบีบอัดแต่ละภาพ การลดค่าที่ส่งให้กับ [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) จะลดคุณภาพภาพ JPEG ในขณะที่การลดค่าที่ส่งให้กับ [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) จะทำให้ภาพถูกลดความละเอียดลง ซึ่งอาจลดรายละเอียดลง การเปิดใช้งานการเลือกบีบอัดอัตโนมัติเองไม่ทำให้การตั้งค่าเหล่านี้ต่ำลง

การเลือกอัลกอริธึมบีบอัดภาพต้องใช้เวลาและหน่วยความจำเพิ่ม จำนวนการลดขนาดขึ้นอยู่กับภาพในงานนำเสนอและการตั้งค่าการส่งออก; ไม่ได้รับประกันว่าจะลดได้คงที่สำหรับทุกงานนำเสนอ

### **รักษาไฟล์ OLE ที่ฝังเป็นไฟล์แนบ PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF สามารถเข้าถึงข้อมูลของเวิร์กบุ๊กและดูสไลด์ได้ เรียกใช้ [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) ด้วย `true` เพื่อรักษาไฟล์ OLE ที่ฝังเป็นไฟล์แนบใน PDF ที่ได้

ค่าตั้งต้นคือ `false`: ภาพพรีวิวหรือไอคอนของวัตถุ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังจะไม่รวมเป็นไฟล์แนบ การตั้งค่าเป็น `true` จะเพิ่มข้อมูลไฟล์ด้วย พรีวิวยังคงเป็นภาพแสดงผล ส่วนไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ที่ฝังแยกออกมาได้ วัตถุ OLE จะไม่กลายเป็นแผ่นงาน Excel แบบโต้ตอบบนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

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

1. เปิด PDF ที่ส่งออกในโปรแกรมแสดงผลที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมและค้นหาเวิร์กบุ๊กที่ฝังอยู่
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมอนุญาต พรีวิวบนหน้า PDF จะอยู่แยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}

มาตรฐาน PDF/A มีข้อจำกัดต่อไฟล์แนบ: PDF/A‑1 ห้ามฝังไฟล์, PDF/A‑2 อนุญาตให้มีไฟล์แนบ PDF/A เท่านั้น, และ PDF/A‑3 อนุญาตไฟล์ประเภทอื่นรวมถึงเวิร์กบุ๊ก Excel นี่เป็นข้อกำหนดของมาตรฐาน ไม่ได้เป็นข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าความสอดคล้อง PDF เริ่มต้นและไม่ได้สาธิตการส่งออก PDF/A

{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) จากคลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนไว้เป็นหน้าใน PDF ที่ได้

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

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใส่รหัสผ่าน `password` เพื่อเปิดใช้งาน การอนุญาตการเข้าถึงให้พิมพ์ได้ รวมถึงการพิมพ์คุณภาพสูง

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

### **ตรวจจับการทดแทนแบบอักษร**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) ทำให้คุณตรวจจับการทดแทนแบบอักษรระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการทดแทนแบบอักษรไปยังคอนโซล คำเตือนจะปรากฏก็ต่อเมื่อมีการทดแทนแบบอักษรที่ไม่มีในระบบระหว่างการส่งออก

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

ข้อมูลเพิ่มเติมเกี่ยวกับการทดแทนแบบอักษร ดูบทความ [Font Substitution](/slides/th/androidjava/font-substitution/)

{{% /alert %}} 

### **จัดการแบบอักษรที่ไม่มีรูปแบบตัวหนาแยกออก**

งานนำเสนออาจใช้การจัดรูปแบบตัวหนาแม้ว่าแบบอักษรนั้นจะไม่มีรูปแบบตัวหนาแยกออก ตัวอักษรยังคงแสดงเป็นตัวหนาผ่านการทำตัวหนาสังเคราะห์ ซึ่งทำให้ glyph ปกติหนากว่า เมื่อข้อความนั้นดูหนักเกินไปหรือแตกต่างจากที่ต้องการใน PDF ให้ลองเรียก [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) ด้วย `true` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิตแมประหว่างการส่งออก PDF และอาจทำให้แสดงผลดีขึ้นสำหรับแบบอักษรบางชนิด ค่าเริ่มต้นคือ `false`

งานนำเสนอตัวอย่างมีสองกล่องข้อความ: กล่องหนึ่งมีข้อความปกติและอีกกล่องหนึ่งมีการจัดรูปแบบตัวหนากับแบบอักษรเดียวกันที่ไม่มีรูปแบบตัวหนาแยกออก ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เปิดใช้งานการเรซิเคิลแบบอักษรที่ไม่ได้สนับสนุนตัวหนาและส่งออกเป็น PDF:

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

ตัวอย่างภาพต่อไปนี้แสดงผลลัพธ์ที่ปิดและเปิดใช้งาน ในตัวอย่างนี้ข้อความตัวหนามีเส้นหนากว่าที่ปิดตัวเลือก เมื่อเปิดใช้งานเส้นจะบางลง; ข้อความปกติไม่เปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนตัดสินใจตั้งค่าสำหรับงานนำเสนอของคุณ

| ตัวเลือกปิด (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

ในตัวอย่างนี้การเปิดใช้งานตัวเลือกจะทำให้ข้อความตัวหนาเดียวถูกแปลงเป็นบิตแมป: ไม่สามารถเลือก, คัดลอก หรือค้นหาเป็นข้อความโดยไม่มี OCR และขอบของข้อความจะดูนุ่มขึ้นที่การขยาย 800 % ข้อความปกติยังคงสามารถค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองสตริงยังคงเป็นข้อความ

ตัวเลือกนี้ทำให้ข้อความที่จัดรูปแบบเป็นตัวหนาเมื่อแบบอักษรไม่มีรูปแบบตัวหนาแยกออกเป็นบิตแมป [Font substitution](/slides/th/androidjava/font-substitution/) จะเลือกแบบอักษรอื่นเมื่อแบบอักษรต้นฉบับไม่พร้อมใช้งาน

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF ตัวเลขสไลด์ในอาเรย์นี้เริ่มจาก 1 และงานนำเสนออินพุตต้องมีอย่างน้อยสามสไลด์

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

    // ลบสไลด์ว่างที่สร้างพร้อมกับงานนำเสนอใหม่
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองโน๊ตสไลด์**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางโน๊ตผู้พูดของแต่ละสไลด์ไว้ด้านล่างสไลด์ ใช้งานนำเสนอที่มีโน๊ตผู้พูดเพื่อดูผลลัพธ์

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

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานความสอดคล้องใดก็ได้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ดนี้แสดงกระบวนการแปลง PowerPoint‑to‑PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานความสอดคล้องต่าง ๆ:

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

Aspose.Slides รองรับการดำเนินการแปลง PDF ทำให้คุณสามารถแปลงไฟล์ PDF ไปเป็นรูปแบบไฟล์ยอดนิยมอื่น ๆ ได้ คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) การแปลง PDF ไปเป็นรูปแบบเฉพาะอื่น ๆ เช่น [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) ก็ได้รับการสนับสนุนเช่นกัน

{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะจัดการกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปทรงเดียว ส่วนประกอบเส้นทางย่อยจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็น artifact; ข้อความแทนที่ให้ไว้เฉพาะสำหรับรูปทรงทั้งหมดเท่านั้น

## **FAQ**

**สามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นชุดได้หรือไม่?**

ได้, Aspose.Slides รองรับการแปลงหลายไฟล์ PPT หรือ PPTX เป็น PDF แบบเป็นชุด คุณสามารถวนซ้ำไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยอัตโนมัติ

**สามารถตั้งรหัสผ่านให้กับ PDF ที่แปลงแล้วได้หรือไม่?**

ได้. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) เพื่อกำหนดรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**ทำอย่างไรจึงจะรวมสไลด์ที่ซ่อนอยู่ใน PDF?**

เรียก [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ด้วย `true` ในคลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) และ [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) ในคลาส [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานความสอดคล้อง PDF/A หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับ [various standards](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามข้อกำหนดด้านการเข้าถึงและการเก็บรักษา

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for Android via Java Documentation](/slides/th/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)