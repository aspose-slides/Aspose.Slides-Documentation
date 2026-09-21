---
title: เปลี่ยนขนาดและทิศทางหน้าบันทึกบน Android
linktitle: ขนาดหน้าบันทึก
type: docs
weight: 10
url: /th/androidjava/notes-size/
keywords:
- ขนาดหน้าบันทึก
- ทิศทางหน้าบันทึก
- บันทึกแนวนอน
- บันทึกแนวตั้ง
- ขนาดเอกสารแจก
- PowerPoint
- การนำเสนอ
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "อ่านและเปลี่ยนขนาดหน้าบันทึกใน Aspose.Slides สำหรับ Android ผ่าน Java, สลับทิศทาง, ตรวจสอบขนาดที่บันทึกไว้, และส่งออกบันทึกหรือเอกสารแจกเป็น PDF และภาพ."
---
## **ภาพรวม**

ใช้ [Presentation.getNotesSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getNotesSize--) เพื่อเข้าถึงการตั้งค่าหน้าบันทึกของการนำเสนอ มันจะคืนค่าอ็อบเจ็กต์ [INotesSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/inotessize/) ที่เมธอด [setSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) กำหนดขนาดหน้า แม้ว่าอ็อบเจ็กต์การตั้งค่าเองจะไม่สามารถแทนที่ได้ คุณสามารถกำหนดขนาดใหม่ผ่านเมธอดนี้

ความกว้างและความสูงระบุเป็น **points** โดยมี 72 points ต่อหนึ่งนิ้ว ตัวอย่างเช่น 900 × 600 points เท่ากับ 12.5 × 8⅓ นิ้ว การตั้งค่าเหล่านี้ใช้กับการนำเสนอ ไม่ได้ใช้กับบันทึกของสไลด์แต่ละสไลด์

| Setting | Purpose |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getNotesSize--) | ควบคุมขนาดหน้าบันทึกและขนาดหน้าที่ใช้สำหรับการส่งออกเอกสารแจก |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlideSize--) | ควบคุมขนาดสไลด์การนำเสนอปกติผ่าน [ISlideSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidesize/) |

การเปลี่ยนการตั้งค่าใด ๆ ไม่ได้ทำให้การตั้งค่าอื่นเปลี่ยนโดยอัตโนมัติ การเปลี่ยนทิศทางหน้าบันทึกก็ไม่ได้หมุนสไลด์ปกติ ดู [Slide Size](/slides/th/androidjava/slide-size/) เพื่อปรับขนาดสไลด์ปกติ

ตัวอย่างด้านล่างใช้ไฟล์ `sample.pptx` ที่มีอยู่แล้ว สำหรับตัวอย่างการส่งออก ให้ใช้การนำเสนอที่มีอย่างน้อยหนึ่งสไลด์ที่มีบันทึกพูด ผู้ทำตัวอย่างแต่ละอันสามารถเรียกใช้ได้อย่างอิสระ

## **อ่านขนาดและทิศทางของหน้าบันทึก**

อ่านความกว้างและความสูงแล้วเปรียบเทียบเพื่อกำหนดทิศทาง: หน้าที่กว้างกว่าเป็นแนวนอน, หน้าที่สูงกว่าเป็นแนวตั้ง, และขนาดเท่ากันเป็นหน้าสี่เหลี่ยมจัตุรัส ตัวอย่างนี้พิมพ์ขนาดจริงเป็น points โดยไม่สมมติขนาดกระดาษมาตรฐาน

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **สลับเป็นแนวนอนไม่เปลี่ยนขนาดกระดาษ**

เพื่อเปลี่ยนเฉพาะทิศทาง ให้สลับความกว้างและความสูงที่มีอยู่ วิธีนี้ทำให้ความยาวของทั้งสองด้านคงเดิมรวมถึงขนาดกระดาษที่กำหนดเอง เงื่อนไขด้านล่างป้องกันไม่ให้หน้าที่เป็นแนวนอยู่แล้วถูกสลับกลับเป็นแนวตั้งและทำให้หน้าสี่เหลี่ยมจัตุรัสคงเดิม

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับทิศทางแนวตั้ง ให้ใช้การกำหนดค่าเดียวกันเมื่อ `size.getWidth() > size.getHeight()` อย่าแทนค่าขนาด A4 หรือ Letter หากคุณไม่ได้ต้องการเปลี่ยนขนาดกระดาษ

## **กำหนดและตรวจสอบขนาดหน้าบันทึกกำหนดเอง**

กำหนดขนาดทั้งสองพร้อมกัน แล้วใช้ [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) เพื่อบันทึกการนำเสนอ ตัวอย่างนี้ตั้งค่าหน้าแนวนอน 900 × 600 points บันทึกเป็น PPTX และเปิดไฟล์ที่บันทึกอีกครั้งเพื่อเช็คค่าที่บันทึกไว้ การเปรียบเทียบอนุญาตความคลาดเคลื่อน 0.01 point สำหรับค่าทศนิยม; แต่ไม่รับประกันความแม่นยำสำหรับทุกรูปแบบไฟล์

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ที่คาดหวังคือ `900.0 x 600.0 points` และ `Size preserved: true` การตรวจสอบการนำเสนอที่เปิดใหม่จะยืนยันไฟล์ที่บันทึกไว้ ไม่ใช่แค่การตั้งค่าในหน่วยความจำ

## **ส่งออกบันทึกและเอกสารแจก**

ขนาดหน้ากำหนดพื้นที่ที่ใช้ได้สำหรับการจัดวางบันทึกหรือเอกสารแจก แต่ไม่ได้ทำให้การจัดวางเหล่านั้นทำงานโดยอัตโนมัติ: ต้องกำหนดตัวเลือกการส่งออกด้วย การส่งอออกสไลด์ปกติยังคงใช้ขนาดสไลด์

### **ส่งออกบันทึกเป็น PDF และ PNG**

กำหนด [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notescommentslayoutingoptions/) ให้กับ [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) เพื่อรวมบันทึกใน PDF ตัวอย่างนี้ยังเรนเดอร์สไลด์แรกที่มีบันทึกเป็น PNG โดยใช้ [Slide.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) และ [RenderingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/renderingoptions/)

โหมด [BottomTruncated](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notespositions/) เก็บบันทึกไว้ในหนึ่งหน้า; บันทึกที่ไม่พอดีสามารถตัดออกได้ PDF ใช้หน้าขนาด 900 × 600 points ที่สเกลภาพ 1 × 1 ที่ใช้ด้านล่าง PNG จะเป็น 900 × 600 พิกเซล Points บรรยายรูปทรงของหน้า; พิกเซลบรรยายผลลัพธ์แบบแรสเตอร์ ซึ่งขนาดขึ้นอยู่กับสเกลการเรนเดอร์

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

สำหรับการส่งออก PDF ที่มีบันทึกยาว, [BottomFull](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notespositions/) อนุญาตให้เพิ่มหน้าได้ตามต้องการ อย่าใช้โหมดนั้นกับการเรียกภาพสไลด์เดียวด้านบน ซึ่งไม่รองรับ หลังจากปรับขนาด ตรวจสอบผลลัพธ์ว่ามีบันทึกถูกตัดหรือไม่และตำแหน่งของวัตถุ notes-master ที่มีอยู่; การเปลี่ยนขนาดหน้าเพียงอย่างเดียวไม่ควรถือเป็นการรับประกันว่าเนื้อหาทั้งหมดจะพอดี ดู [Convert PowerPoint to PDF with Notes](/slides/th/androidjava/convert-powerpoint-to-pdf-with-notes/) เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับการส่งออกบันทึก

### **ส่งออกเอกสารแจกเป็น PDF**

ใช้ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/handoutlayoutingoptions/) เพื่อทำให้มีภาพย่อของหลายสไลด์ในหนึ่งหน้า ตัวอย่างต่อไปตั้งค่าหน้า 900 × 600 points และใช้ [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/handouttype/) เพื่อจัดสไลด์สูงสุดสี่สไลด์ต่อหน้า การตั้งค่า�แนวนอนควบคุมลำดับสไลด์; ทิศทางหน้ามาจากความกว้างและความสูง

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

การเปลี่ยนขนาดหน้าเปลี่ยนพื้นที่ที่ใช้สำหรับตารางเอกสารแจกโดยไม่เปลี่ยนขนาดของสไลด์ต้นฉบับ สำหรับภาพเอกสารแจก ให้ใช้ [Presentation.getImages](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) กับการจัดเลย์เอาต์เอกสารแจก แทนการใช้เมธอดภาพของสไลด์แต่ละอัน ใน Aspose.Slides การเรนเดอร์เอกสารแจกระดับการนำเสนอใช้ขนาดหน้าบันทึก ส่วนการเรียกภาพสไลด์เดี่ยวไม่สร้างหน้าจัดเอกสารแจก ดู [Handout Mode](/slides/th/androidjava/convert-powerpoint-in-handout-mode/) สำหรับตัวเลือกการจัดวาง

## **ขนาดหน้าในโปรแกรมดู, การส่งออกและการพิมพ์**

แยกแยะขนาดการนำเสนอที่เก็บไว้, ขนาดหน้าที่ส่งออก, และขนาดกระดาษที่พิมพ์

- **Presentation viewers:** ตัวดูอาจแสดงหรือพิมพ์บันทึกโดยใช้กฎการจัดวางของตนเอง หากแอปพลิเคชันอื่นบันทึกไฟล์ ให้เปิดใหม่และตรวจสอบขนาดอีกครั้ง; การแปลงรูปแบบของแอปนั้นอาจทำให้มาตรฐาน
- **Export formats:** ตัวอย่าง PDF ของบันทึกและเอกสารแจกด้านบนใช้ขนาดหน้าที่กำหนดไว้ ภาพแรสเตอร์ใช้ขนาดพิกเซลจำนวนเต็มและสเกลการเรนเดอร์ ทำให้ค่าจุดส่วนเกินอาจถูกปัดเป็นจำนวนเต็มในผลลัพธ์ภาพ การส่งออกสไลด์ปกติไม่ใช้ขนาดหน้าบันทึก
- **Printer drivers:** การเลือกกระดาษ, การหมุนอัตโนมัติ, และการตั้งค่าให้พอดีหน้า สามารถเปลี่ยนผลลัพธ์จริงโดยไม่เปลี่ยนขนาดที่เก็บในการนำเสนอหรือ PDF สำหรับขนาดกระดาษที่กำหนด ให้ตั้งค่าตรงกับเครื่องพิมพ์และตรวจสอบการแสดงตัวอย่างก่อนพิมพ์

## **FAQ**

**ฉันสามารถตั้งขนาดบันทึกสำหรับสไลด์เดียวเท่านั้นได้หรือไม่?**

ขนาดหน้าบันทึกเป็นการตั้งค่าระดับการนำเสนอ สไลด์แต่ละสไลด์อาจมีเนื้อหาบันทึกที่ต่างกัน แต่คุณสมบัตินี้ไม่ได้ให้ขนาดหน้าที่แยกต่างหากสำหรับแต่ละสไลด์

**ทำไมการเปลี่ยนทิศทางบันทึกไม่ทำให้สไลด์ของฉันเปลี่ยน?**

หน้าบันทึกและสไลด์ปกติมีมิติที่อิสระกัน ใช้การตั้งค่าขนาดสไลด์ปกติเมื่อคุณต้องการปรับขนาดสไลด์เอง

**ทำไมผลลัพธ์ที่บันทึกหรือพิมพ์ของฉันจึงมีขนาดที่แตกต่าง?**

ให้เปิดการนำเสนอที่บันทึกใหม่อีกครั้งและเปรียบเทียบขนาดหน้าบันทึก หากมีการเปลี่ยนแปลง ให้ตรวจสอบว่าการบันทึกหรือแปลงไฟล์ในแอปพลิเคชันอื่นทำให้การตั้งค่าหน้าเปลี่ยนหรือไม่ หากไม่ได้เปลี่ยน ให้ตรวจสอบการจัดวางการส่งออก, สเกลภาพ, การตั้งค่าตัวดู, และการเลือกกระดาษของเครื่องพิมพ์