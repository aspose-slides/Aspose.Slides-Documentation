---
title: การดำเนินการพรีเซนเทชันแบบ Low-Code ใน Java
linktitle: API Low-Code
type: docs
weight: 50
url: /th/java/low-code-presentation-operations/
keywords:
- API การนำเสนอแบบ Low-Code
- แปลงพรีเซนเทชัน
- รวมพรีเซนเทชัน
- วนสไลด์
- วนรูปร่าง
- วนข้อความ
- รวบรวมรูปร่าง
- บีบอัดพรีเซนเทชัน
- ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้
- ลบเลย์เอาต์สไลด์ที่ไม่ได้ใช้
- บีบอัดฟอนต์ฝัง
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides low-code API ใน Java เพื่อแปลงและรวมพรีเซนเทชัน, วนผ่านเนื้อหา, รวบรวมรูปร่าง, และลดขนาดพรีเซนเทชัน."
---
## **ภาพรวม**

แพคเกจ [com.aspose.slides](https://reference.aspose.com/slides/th/java/com.aspose.slides/) ให้คลาสช่วยเหลือแบบสถิตย์สำหรับการดำเนินการพรีเซนเทชันทั่วไป ตัวช่วยเหลือนี้ห่อหุ้มกระบวนการโมเดลวัตถุที่ใช้บ่อยในเมธอดที่เน้นจุดประสงค์ ทำให้คุณสามารถแปลงหรือรวมไฟล์, ประมวลผลองค์ประกอบของพรีเซนเทชัน, รวบรวมรูปร่าง, และลบเนื้อหาที่ไม่ได้ใช้ด้วยโค้ดที่น้อยลง

ตัวช่วยแบบ low‑code มีประโยชน์มากเมื่อการดำเนินการใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและเวิร์กโฟลว์เริ่มต้นตรงกับความต้องการของคุณ ใช้ [Aspose.Slides object model](https://reference.aspose.com/slides/th/java/com.aspose.slides/) เต็มรูปแบบเมื่อคุณต้องการการควบคุมในระดับละเอียดบนสไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, การตั้งค่าการส่งออก, หรือความสัมพันธ์ระหว่างองค์ประกอบของพรีเซนเทชัน

ตารางต่อไปนี้สรุปตัวช่วยที่มีให้:

| ตัวช่วย | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/java/com.aspose.slides/convert/) | แปลงพรีเซนเทชันเป็นรูปแบบอื่นด้วยการเรียกแบบไฟล์ต่อไฟล์โดยตรง |
| [Merger](https://reference.aspose.com/slides/th/java/com.aspose.slides/merger/) | รวมไฟล์พรีเซนเทชันเต็มรูปแบบที่มีรูปแบบเดียวกัน |
| [ForEach](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/) | ดำเนินการต่อแต่ละสไลด์, รูปร่าง, ย่อหน้า หรือส่วนของข้อความ |
| [Collect](https://reference.aspose.com/slides/th/java/com.aspose.slides/collect/) | ดึงรูปร่างจากพรีเซนเทชันทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์ซ้ำ |
| [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/) | ลบมาสเตอร์และเลย์เอาต์ที่ไม่ได้ใช้และลดข้อมูลฟอนต์ฝัง |

## **แปลงพรีเซนเทชัน**

ใช้ [Convert.autoByExtension](https://reference.aspose.com/slides/th/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) เมื่อส่วนขยายไฟล์ผลลัพธ์เพียงพอที่จะเลือกรูปแบบการส่งออก เมธอดจะเปิดพรีเซนเทชันต้นทาง, กำหนดรูปแบบที่ต้องการจากเส้นทางไฟล์ผลลัพธ์, และเขียนผลลัพธ์

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

คลาส [Convert](https://reference.aspose.com/slides/th/java/com.aspose.slides/convert/) ยังมีเมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG, และ TIFF ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการตรวจสอบหรือแก้ไขพรีเซนเทชันก่อนส่งออกหรือกำหนดค่าตัวเลือกการส่งออกที่ตัวช่วยไม่ได้เปิดเผย ดู [Convert Presentation](/slides/th/java/convert-presentation/) สำหรับเวิร์กโฟลว์และตัวเลือกเฉพาะรูปแบบ

## **รวมพรีเซนเทชัน**

ใช้ [Merger.process](https://reference.aspose.com/slides/th/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) เพื่อรวมไฟล์พรีเซนเทชันเต็มรูปแบบด้วยการเรียกครั้งเดียว พรีเซนเทชันต้นเข้าต้องมีรูปแบบไฟล์เดียวกัน

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

ตัวช่วยนี้เหมาะเมื่อต้องการต่อสไลด์ทั้งหมดเป็นผลลัพธ์เดียวโดยไม่ต้องเลือกหรือแม็ปแต่ละสไลด์แยกกัน ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการรวมสไลด์ที่เลือก, ใช้มาสเตอร์หรือเลย์เอาต์ปลายทาง, เก็บส่วนอย่างชัดเจน, หรือปรับขนาดสไลด์ที่แตกต่างกัน ดู [Merge Presentations](/slides/th/java/merge-presentation/) สำหรับกรณีดังกล่าว

## **วนรอบผ่านองค์ประกอบของพรีเซนเทชัน**

คลาส [ForEach](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/) เรียกคอลแบ็กสำหรับแต่ละประเภทขององค์ประกอบพรีเซนเทชันที่ร้องขอ ลดการใช้ลูปคอลเลกชันซ้อนและสะดวกสำหรับการตรวจสอบหรือการเปลี่ยนแปลงรูปแบบทั่วทั้งพรีเซนเทชัน

ตัวอย่างต่อไปนี้ใช้ [ForEach.slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), และ [ForEach.portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) เพื่อตรวจสอบองค์ประกอบที่สอดคล้องกัน:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

ตามค่าเริ่มต้น การเดินผ่านรูปร่างและข้อความทั่วทั้งพรีเซนเทชันจะรวมสไลด์ปกติ, มาสเตอร์, และเลย์เอาต์ การอัปโหลดที่มีพารามิเตอร์ `includeNotes` ยังสามารถประมวลผลสไลด์โน้ตได้ ใช้ลูปคอลเลกชันโดยตรงเมื่อลำดับการเดิน, การออกก่อนเวลา, การกรองก่อนเรียกคอลแบ็ก, หรือการควบคุมพาเรนท์‑ชิลด์อย่างละเอียดเป็นสิ่งสำคัญ

## **รวบรวมรูปร่าง**

ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) เมื่อคุณต้องการคอลเลกชันของรูปร่างทั้งหมดในพรีเซนเทชันแทนคอลแบ็กสำหรับแต่ละรูปร่าง สิ่งนี้มีประโยชน์เมื่อเซ็ตเดียวกันต้องถูกกรอง, นับ, หรือประมวลผลหลายครั้ง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

ใช้ [ForEach.shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) แทนเมื่อสามารถจัดการแต่ละรูปร่างได้ทันทีและไม่ต้องเก็บผลลัพธ์ที่รวบรวมไว้

## **บีบอัดเนื้อหาพรีเซนเทชัน**

คลาส [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ได้ใช้และลดข้อมูลฟอนต์ฝังได้:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) ลบเลย์เอาต์สไลด์ที่ไม่มีสไลด์ปกติอ้างอิง
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้แล้ว
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) ลบอักขระที่ไม่ได้ใช้จากฟอนต์ฝัง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ลบเลย์เอาต์ที่ไม่ได้ใช้ก่อนมาสเตอร์ที่ไม่ได้ใช้ เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังจากทำความสะอาดเลย์เอาต์ก็สามารถลบได้ด้วย บันทึกพรีเซนเทชันที่ปรับแต่งแล้วเป็นไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์, เลย์เอาต์, หรือข้อมูลฟอนต์ฝังทั้งหมดในภายหลัง สำหรับรายละเอียดเพิ่มเติม ดูที่ [Slide Master](/slides/th/java/slide-master/) และ [Embedded Font](/slides/th/java/embedded-font/)

## **คำถามที่พบบ่อย**

**เมื่อใดที่ควรใช้ low‑code API แทนโมเดลวัตถุเต็มรูปแบบ?**

ใช้ตัวช่วยแบบ low‑code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและไม่ต้องการการควบคุมละเอียดบนแต่ละองค์ประกอบ ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการเลือกสไลด์เฉพาะ, ควบคุมความสัมพันธ์ของมาสเตอร์และเลย์เอาต์, ตรวจสอบสถานะกลาง, หรือกำหนดพฤติกรรมที่ตัวช่วยไม่ได้เปิดเผย

**Merger สามารถรวมพรีเซนเทชันที่มีรูปแบบไฟล์ต่างกันได้หรือไม่?**

ไม่ได้ ตัวช่วย [Merger.process](https://reference.aspose.com/slides/th/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) จำเป็นต้องใช้พรีเซนเทชันอินพุตที่มีรูปแบบเดียวกัน ก่อนทำการรวมให้แปลงไฟล์อินพุตเป็นรูปแบบที่ตรงกันก่อน เช่น ด้วย [Convert.autoByExtension](https://reference.aspose.com/slides/th/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), แล้วจึงรวมไฟล์ที่แปลงแล้ว

**ForEach ประมวลผลมาสเตอร์, เลย์เอาต์, และสไลด์โน้ตหรือไม่?**

[ForEach.slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) วนผ่านสไลด์พรีเซนเทชันปกติ การดำเนินการ [ForEach.shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), และ [ForEach.portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) รวมสไลด์ปกติ, มาสเตอร์, และเลย์เอาต์เป็นค่าเริ่มต้น ใช้การอัปโหลดที่มี `includeNotes` เป็น `true` เพื่อรวมสไลด์โน้ตด้วย

**ความแตกต่างระหว่าง ForEach.shape กับ Collect.shapes คืออะไร?**

ใช้ [ForEach.shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) เพื่อประมวลผลแต่ละรูปร่างทันทีผ่านคอลแบ็ก ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) เมื่อคุณต้องการผลลัพธ์ที่สามารถเก็บไว้, กรอง, นับ, หรือเดินหลายครั้งได้

**Compress ทำให้ไฟล์พรีเซนเทชันเล็กลงเสมอหรือไม่?**

ไม่จำเป็น ผลลัพธ์ขึ้นอยู่กับว่าพรีเซนเทชันมีเลย์เอาต์ที่ไม่ได้ใช้, มาสเตอร์ที่ไม่ได้ใช้, หรือฟอนต์ฝังที่มีอักขระที่ไม่ใช้หรือไม่ หากไม่มีองค์ประกอบเหล่านี้ การดำเนินการ [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/) อาจไม่ลดขนาดไฟล์

**การเปลี่ยนแปลงที่ทำโดย ForEach หรือ Compress จะถูกบันทึกโดยอัตโนมัติหรือไม่?**

ไม่ ตัวช่วยเหลือนี้ทำงานกับอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ที่โหลดอยู่ในหน่วยความจำ หลังจากแก้ไของค์ประกอบในคอลแบ็กของ [ForEach](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/) หรือเรียกใช้ [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/), ให้เรียก [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) เพื่อเขียนผลลัพธ์

## **บทความที่เกี่ยวข้อง**

- [แปลงพรีเซนเทชัน](/slides/th/java/convert-presentation/)
- [รวมพรีเซนเทชัน](/slides/th/java/merge-presentation/)
- [Slide Master](/slides/th/java/slide-master/)
- [Manage Text Box](/slides/th/java/manage-textbox/)
- [Embedded Font](/slides/th/java/embedded-font/)