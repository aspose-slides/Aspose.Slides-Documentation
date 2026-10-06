---
title: เปลี่ยนขนาดและการวางแนวหน้าจดหมายเหตุใน Java
linktitle: ขนาดหน้าจดหมายเหตุ
type: docs
weight: 10
url: /th/java/notes-size/
keywords:
- ขนาดหน้าจดหมายเหตุ
- การวางแนวหน้าจดหมายเหตุ
- โน้ตแนวนอน
- โน้ตแนวตั้ง
- ขนาดแผ่นพับ
- PowerPoint
- การนำเสนอ
- PPT
- PPTX
- Java
- Aspose.Slides
description: "อ่านและเปลี่ยนขนาดหน้าจดหมายเหตุใน Aspose.Slides สำหรับ Java, สลับการวางแนว, ตรวจสอบขนาดที่บันทึก, และส่งออกโน้ตหรือแผ่นพับเป็น PDF และภาพ."
---
## **ภาพรวม**

ใช้ [Presentation.getNotesSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getNotesSize--) เพื่อเข้าถึงการตั้งค่าหน้าจดหมายเหตุของงานพรีเซนเทชัน รายการจะคืนค่าเป็นอ็อบเจ็กต์ [INotesSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/inotessize/) ซึ่งเมธอด [setSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) จะกำหนดขนาดหน้ากระดาษ แม้ว่าจะไม่สามารถแทนที่อ็อบเจ็กต์การตั้งค่าได้โดยตรง แต่คุณสามารถกำหนดขนาดใหม่ผ่านเมธอดนี้ได้

ความกว้างและความสูงระบุเป็น **จุด** โดยมี 72 จุดต่อหนึ่งนิ้ว ตัวอย่างเช่น 900 × 600 จุด เท่ากับ 12.5 × 8⅓ นิ้ว การตั้งค่าเหล่านี้ใช้กับงานพรีเซนเทชันทั้งหมด ไม่ได้ใช้กับโน้ตของสไลด์แต่ละสไลด์

| การตั้งค่า | จุดประสงค์ |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getNotesSize--) | ควบคุมขนาดหน้าจดหมายเหตุและขนาดหน้าที่ใช้สำหรับการส่งออกเป็นแผ่นพับ |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSlideSize--) | ควบคุมขนาดสไลด์ปกติของงานพรีเซนเทชันผ่าน [ISlideSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidesize/) |

การเปลี่ยนแปลงการตั้งค่าใด ๆ หนึ่งไม่ทำให้การตั้งค่าอื่นเปลี่ยนแปลงอัตโนมัติ การเปลี่ยนแปลงการวางแนวของหน้าจดหมายเหตุก็ไม่ได้หมุนสไลด์ปกติเช่นกัน ดู [Slide Size](/slides/th/java/slide-size/) เพื่อปรับขนาดสไลด์ปกติ

ตัวอย่างด้านล่างใช้ไฟล์ `sample.pptx` ที่มีอยู่แล้ว สำหรับตัวอย่างการส่งออก ให้ใช้งานพรีเซนเทชันที่มีอย่างน้อยหนึ่งสไลด์ที่มีโน้ตพูดคุย ตัวอย่างแต่ละอันสามารถทำงานได้โดยอิสระ

## **อ่านขนาดและการวางแนวของหน้าจดหมายเหตุ**

อ่านความกว้างและความสูงแล้วเปรียบเทียบเพื่อระบุการวางแนว: หน้ากว้างกว่าคือแนวนอน, หน้าสูงกว่าคือแนวตั้ง, ขนาดเท่ากันคือหน้าจัตุรัส ตัวอย่างนี้พิมพ์ค่าขนาดจริงเป็นจุด โดยไม่สมมติขนาดกระดาษมาตรฐาน

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
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

## **สลับเป็นแนวนอนโดยไม่เปลี่ยนขนาดกระดาษ**

เพื่อเปลี่ยนเฉพาะการวางแนว ให้สลับค่าความกว้างและความสูงที่มีอยู่ ซึ่งจะรักษาความยาวของทั้งสองด้านรวมถึงขนาดกระดาษที่กำหนดเอง เงื่อนไขด้านล่างป้องกันไม่ให้หน้าที่เป็นแนวนอนแล้วกลับไปเป็นแนวตั้งและจะไม่ทำการเปลี่ยนแปลงกับหน้าจัตุรัส

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับการวางแนวแนวตั้ง ให้ใช้การกำหนดค่าเดียวกันเมื่อ `size.getWidth() > size.getHeight()` อย่าเปลี่ยนเป็นขนาด A4 หรือ Letter เว้นแต่คุณต้องการเปลี่ยนขนาดกระดาษด้วยเช่นกัน

## **กำหนดและตรวจสอบขนาดหน้าจดหมายเหตุที่กำหนดเอง**

กำหนดทั้งสองมิติพร้อมกัน แล้วใช้ [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) เพื่อบันทึกงานพรีเซนเทชัน ตัวอย่างนี้กำหนดหน้าแนวนอนขนาด 900 × 600 จุด บันทึกเป็น PPTX แล้วเปิดไฟล์ที่บันทึกใหม่เพื่อตรวจสอบค่าที่บันทึกไว้ การเปรียบเทียบรับความคลาดเคลื่อน 0.01 จุดสำหรับค่าจุดลอย; ไม่ได้รับประกันความแม่นยำสำหรับทุกรูปแบบไฟล์

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
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

ผลลัพธ์ที่คาดหวังคือ `900.0 x 600.0 points` และ `Size preserved: true` การตรวจสอบงานพรีเซนเทชันที่เปิดใหม่ยืนยันไฟล์ที่บันทึกไว้ ไม่ได้ตรวจสอบเฉพาะการตั้งค่าในหน่วยความจำ

## **ส่งออกโน้ตและแผ่นพับ**

ขนาดหน้ากำหนดพื้นที่ที่ใช้ได้สำหรับเลย์เอาต์โน้ตหรือแผ่นพับ แต่ไม่ได้เปิดใช้งานเลย์เอาต์เหล่านั้นโดยอัตโนมัติ: ต้องกำหนดตัวเลือกการส่งออกด้วยเช่นกัน การส่งออกสไลด์ปกติยังคงใช้ขนาดสไลด์

### **ส่งออกโน้ตเป็น PDF และ PNG**

กำหนด [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/notescommentslayoutingoptions/) ให้กับ [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) เพื่อรวมโน้ตใน PDF ตัวอย่างนี้ยังเรนเดอร์สไลด์แรกที่มีโน้ตเป็น PNG ด้วย [Slide.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) และ [RenderingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/renderingoptions/)

โหมด [BottomTruncated](https://reference.aspose.com/slides/th/java/com.aspose.slides/notespositions/) จะเก็บโน้ตไว้ในหน้าเดียว; โน้ตที่ไม่พอจะถูกตัดออก PDF ใช้หน้าขนาด 900 × 600 จุด ที่สเกลภาพ 1 × 1 ดังที่แสดงด้านล่าง PNG จะมีขนาด 900 × 600 พิกเซล จุดอธิบายเรขาคณิตของหน้า; พิกเซลอธิบายผลลัพธ์แบบราสเตอร์ ซึ่งขนาดก็ขึ้นกับสเกลการเรนเดอร์

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
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

สำหรับการส่งออก PDF ที่มีโน้ตยาว [BottomFull](https://reference.aspose.com/slides/th/java/com.aspose.slides/notespositions/) จะเพิ่มหน้าเพิ่มเติมตามต้องการ อย่าใช้โหมดนั้นกับการเรียกภาพสไลด์เดี่ยวด้านบน เพราะไม่ได้รองรับ หลังจากปรับขนาด ตรวจสอบผลลัพธ์สำหรับโน้ตที่ถูกตัดและการวางตำแหน่งของวัตถุ notes‑master ที่มีอยู่; การเปลี่ยนขนาดหน้าเพียงอย่างเดียวไม่ได้รับประกันว่าทุกเนื้อหาจะพอดี ดู [Convert PowerPoint to PDF with Notes](/slides/th/java/convert-powerpoint-to-pdf-with-notes/) สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการส่งออกโน้ต

### **ส่งออกแผ่นพับเป็น PDF**

ใช้ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/handoutlayoutingoptions/) เพื่อวางภาพย่อหลายสไลด์ในหนึ่งหน้า ตัวอย่างต่อไปกำหนดหน้าขนาด 900 × 600 จุดและใช้ [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/th/java/com.aspose.slides/handouttype/) เพื่อจัดสไลด์สูงสุดสี่สไลด์ต่อหน้า พรีเซ็ตแนวนอนควบคุมลำดับสไลด์; การวางแนวหน้ามาจากความกว้างและความสูงของมัน

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
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

การเปลี่ยนขนาดหน้าจะเปลี่ยนพื้นที่ที่ใช้ได้สำหรับกริดแผ่นพับโดยไม่เปลี่ยนขนาดสไลด์ต้นฉบับ สำหรับภาพแผ่นพับ ให้ใช้ [Presentation.getImages](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) พร้อมเลย์เอาต์แผ่นพับ แทนการเรียกเมธอดภาพสไลด์เดี่ยว ใน Aspose.Slides การเรนเดอร์แผ่นพับระดับงานพรีเซนเทชันใช้ขนาดหน้าจดหมายเหตุ ส่วนการเรียกภาพสไลด์เดี่ยวจะไม่สร้างหน้าแผ่นพับ ดู [Handout Mode](/slides/th/java/convert-powerpoint-in-handout-mode/) สำหรับตัวเลือกเลย์เอาต์

## **ขนาดหน้าในโปรแกรมดู, การส่งออก และการพิมพ์**

รักษาขนาดงานพรีเซนเทชันที่จัดเก็บ, ขนาดหน้าที่ส่งออก, และขนาดกระดาษที่พิมพ์แยกกัน:

- **โปรแกรมดูพรีเซนเทชัน:** ตัวดูสามารถแสดงหรือพิมพ์โน้ตโดยใช้กฎเลย์เอาต์ของตัวเอง หากแอปพลิเคชันอื่นบันทึกไฟล์ ให้เปิดไฟล์ใหม่อีกครั้งและตรวจสอบขนาดอีกครั้ง; การแปลงรูปแบบของแอปนั้นอาจทำให้ค่าปกติ
- **รูปแบบการส่งออก:** ตัวอย่าง PDF ของโน้ตและแผ่นพับด้านบนใช้ขนาดหน้าที่กำหนดไว้แล้ว ภาพราสเตอร์ใช้ขนาดพิกเซลจำนวนเต็มและสเกลการเรนเดอร์ ดังนั้นค่าจุดทศนิยมอาจถูกปัดเศษในผลลัพธ์ภาพ การส่งออกสไลด์ปกติไม่ใช้ขนาดหน้าจดหมายเหตุ
- **ไดรเวอร์เครื่องพิมพ์:** การเลือกกระดาษ, การหมุนอัตโนมัติ, และการตั้งค่าให้พอดีหน้าอาจเปลี่ยนผลลัพธ์ทางกายภาพโดยไม่เปลี่ยนขนาดที่เก็บในงานพรีเซนเทชันหรือ PDF สำหรับขนาดกระดาษเฉพาะ ให้จับคู่การตั้งค่าเครื่องพิมพ์และตรวจสอบตัวอย่างก่อนพิมพ์

## **คำถามที่พบบ่อย**

**ฉันสามารถกำหนดขนาดโน้ตสำหรับสไลด์เดียวได้หรือไม่?**

ขนาดหน้าจดหมายเหตุเป็นการตั้งค่าระดับงานพรีเซนเทชัน สไลด์แต่ละสไลด์อาจมีเนื้อหาโน้ตที่ต่างกัน แต่คุณสมบัตินี้ไม่ได้ให้ขนาดหน้าที่แยกสำหรับแต่ละสไลด์

**ทำไมการเปลี่ยนแนวโน้ตจึงไม่ได้เปลี่ยนสไลด์ของฉัน?**

หน้าจดหมายเหตุและสไลด์ปกติมีขนาดอิสระกัน ใช้การตั้งค่าขนาดสไลด์ปกติเมื่อคุณต้องการปรับขนาดสไลด์เอง

**ทำไมผลลัพธ์ที่บันทึกหรือพิมพ์จึงมีขนาดต่างกัน?**

ให้เปิดงานพรีเซนเทชันที่บันทึกใหม่แล้วเปรียบเทียบขนาดโน้ต หากมีการเปลี่ยนแปลง ให้ตรวจสอบว่าการบันทึกหรือแปลงไฟล์ในแอปพลิเคชันอื่นได้เปลี่ยนการตั้งค่าหน้า หรือไม่ หากไม่เปลี่ยน ให้ตรวจสอบเลย์เอาต์การส่งออก, สเกลภาพ, การตั้งค่าโปรแกรมดู, และการเลือกกระดาษของเครื่องพิมพ์