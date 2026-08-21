---
title: การดำเนินการนำเสนอแบบ Low-Code ใน Java
linktitle: API Low-Code
type: docs
weight: 50
url: /th/java/low-code-presentation-operations/
keywords:
- API การนำเสนอ Low-Code
- แปลงการนำเสนอ
- รวมการนำเสนอ
- วนสไลด์
- วนรูปทรง
- วนข้อความ
- รวบรวมรูปทรง
- บีบอัดการนำเสนอ
- ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้
- ลบเลเอาต์สไลด์ที่ไม่ได้ใช้
- บีบอัดฟอนต์ฝัง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides low-code API ใน Java เพื่อแปลงและรวมการนำเสนอ, วนรอบเนื้อหา, รวบรวมรูปทรง, และลดขนาดการนำเสนอ."
---
## **ภาพรวม**

แพ็คเกจ [com.aspose.slides](https://reference.aspose.com/slides/th/java/com.aspose.slides/) มีคลาสช่วยเหลือแบบสแตติกสำหรับการดำเนินการนำเสนอทั่วไป ตัวช่วยเหลือนี้หุ้มกระบวนการทำงานของโมเดลวัตถุที่ใช้บ่อยในเมธอดที่เน้นเฉพาะ จึงทำให้คุณสามารถแปลงหรือรวมไฟล์ ประมวลผลองค์ประกอบการนำเสนอ รวบรวมรูปร่าง และลบเนื้อหา未ใช้ได้ด้วยโค้ดที่สั้นลง

Low-code helpers มีประโยชน์ที่สุดเมื่อการดำเนินการใช้กับไฟล์หรือการนำเสนอทั้งหมดและเวิร์กโฟลว์เริ่มต้นตรงกับความต้องการของคุณ ใช้ [Aspose.Slides object model](https://reference.aspose.com/slides/th/java/com.aspose.slides/) อย่างเต็มรูปแบบเมื่อคุณต้องการการควบคุมละเอียดระดับสไลด์ มาสเตอร์ เลเอาต์ รูปร่าง การตั้งค่าการส่งออก หรือความสัมพันธ์ระหว่างองค์ประกอบการนำเสนอ

ตารางต่อไปนี้สรุปตัวช่วยที่มีให้:

| ตัวช่วย | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/java/com.aspose.slides/convert/) | แปลงการนำเสนอเป็นรูปแบบอื่นโดยใช้การเรียกแบบไฟล์ต่อไฟล์โดยตรง |
| [Merger](https://reference.aspose.com/slides/th/java/com.aspose.slides/merger/) | รวมไฟล์การนำเสนอทั้งหมดที่มีรูปแบบเดียวกัน |
| [ForEach](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/) | เรียกใช้การดำเนินการสำหรับแต่ละสไลด์ รูปร่าง ย่อหน้า หรือส่วนของข้อความ |
| [Collect](https://reference.aspose.com/slides/th/java/com.aspose.slides/collect/) | ดึงรูปร่างจากการนำเสนอทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์ซ้ำ |
| [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/) | ลบมาสเตอร์และเลเอาต์ที่ไม่ได้ใช้และลดข้อมูลฟอนต์ฝังอยู่ |

## **แปลงการนำเสนอ**

ใช้ [Convert.autoByExtension](https://reference.aspose.com/slides/th/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) เมื่อส่วนต่อท้ายไฟล์ผลลัพธ์เพียงพอที่จะเลือกรูปแบบการส่งออก เมธอดนี้จะเปิดการนำเสนอต้นฉบับ กำหนดรูปแบบที่ต้องการจากเส้นทางผลลัพธ์ และเขียนผลลัพธ์ออกมา

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

คลาส [Convert](https://reference.aspose.com/slides/th/java/com.aspose.slides/convert/) ยังมีเมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG และ TIFF ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการตรวจสอบหรือแก้ไขการนำเสนอก่อนการส่งออกหรือกำหนดค่าตัวเลือกการส่งออกที่ตัวช่วยไม่ได้เปิดเผย ดูที่ [แปลงการนำเสนอ](/java/convert-presentation/) สำหรับเวิร์กโฟลว์และตัวเลือกตามรูปแบบเฉพาะ

## **รวมการนำเสนอ**

ใช้ [Merger.process](https://reference.aspose.com/slides/th/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) เพื่อรวมไฟล์การนำเสนอทั้งหมดด้วยการเรียกครั้งเดียว การนำเข้า ต้องอยู่ในรูปแบบไฟล์เดียวกัน

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

ตัวช่วยนี้เหมาะเมื่อสไลด์ทั้งหมดต้องถูกต่อท้ายเป็นผลลัพธ์เดียวโดยไม่ต้องเลือกหรือทำแมปแต่ละสไลด์แยกส่วน ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการรวมสไลด์ที่เลือกใช้มาสเตอร์หรือเลเอาต์เป้าหมาย รักษาเซคชันอย่างชัดเจน หรือปรับขนาดสไลด์ที่ต่างกัน ดูที่ [รวมการนำเสนอ](/java/merge-presentation/) สำหรับสถานการณ์เหล่านี้

## **วนซ้ำผ่านองค์ประกอบการนำเสนอ**

คลาส [ForEach](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/) เรียกคอลแบ็คสำหรับแต่ละประเภทขององค์ประกอบการนำเสนอที่ร้องขอ มันช่วยหลีกเลี่ยงการวนลูปคอลเลกชันซ้อนกันและสะดวกสำหรับการตรวจสอบหรือการเปลี่ยนแปลงรูปแบบทั่วทั้งการนำเสนอ

ตัวอย่างต่อไปนี้ใช้ [ForEach.slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), และ [ForEach.portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) เพื่อตรวจสอบองค์ประกอบที่เกี่ยวข้อง:

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

โดยค่าเริ่มต้น การเดินทางทั่วทั้งหมดของรูปร่างและข้อความจะรวมสไลด์ปกติ, มาสเตอร์, และเลเอาต์ การโอเวอร์โหลดที่มีพารามิเตอร์ `includeNotes` ยังสามารถประมวลผลสไลด์บันทึกได้ ใช้ลูปคอลเลกชันโดยตรงเมื่อลำดับการเดินทาง, การออกก่อนเวลา, การกรองก่อนเรียกคอลแบ็ค, หรือการควบคุมพาเรนท์-ชิลด์อย่างละเอียดเป็นสิ่งสำคัญ

## **รวบรวมรูปทรง**

ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) เมื่อคุณต้องการคอลเลกชันของรูปร่างทั้งหมดในการนำเสนอ แทนการใช้คอลแบ็คสำหรับแต่ละรูปร่าง วิธีนี้มีประโยชน์เมื่อชุดเดียวกันต้องถูกกรอง นับ หรือประมวลผลหลายครั้ง

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

ใช้ [ForEach.shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) แทนเมื่อสามารถจัดการแต่ละรูปร่างทันทีและไม่ต้องการเก็บผลคอลเลกชันไว้

## **บีบอัดเนื้อหาการนำเสนอ**

คลาส [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ได้ใช้และลดข้อมูลฟอนต์ฝังอยู่:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) ลบเลเอาต์สไลด์ที่ไม่มีสไลด์ปกติอ้างอิง
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

ลบเลเอาต์ที่ไม่ได้ใช้ก่อนมาสเตอร์ที่ไม่ได้ใช้ เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังการทำความสะอาดเลเอาต์ถูกลบด้วย บันทึกการนำเสนอที่ปรับแต่งแล้วเป็นไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์, เลเอาต์, หรือข้อมูลฟอนต์ฝังเต็มภายหลัง สำหรับรายละเอียดเพิ่มเติม ดูที่ [มาสเตอร์สไลด์](/java/slide-master/) และ [ฟอนต์ฝัง](/java/embedded-font/)

## **FAQ**

**ฉันควรใช้ Low-code API แทนโมเดลวัตถุเต็มเมื่อใด?**

ใช้ตัวช่วย Low-code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือการนำเสนอทั้งหมดและไม่ต้องการการควบคุมละเอียดระดับองค์ประกอบแต่ละส่วน ใช้โมเดลวัตถุเต็มเมื่อคุณต้องการเลือกสไลด์เฉพาะ ควบคุมความสัมพันธ์ระหว่างมาสเตอร์และเลเอาต์ ตรวจสอบสถานะระหว่างการประมวลผล หรือกำหนดพฤติกรรมที่ตัวช่วยไม่ได้เปิดเผย

**Merger สามารถรวมการนำเสนอในรูปแบบไฟล์ที่แตกต่างกันได้หรือไม่?**

ไม่ได้. [Merger.process](https://reference.aspose.com/slides/th/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) ต้องการการนำเข้าที่มีรูปแบบไฟล์เดียวกัน แปลงไฟล์อินพุตเป็นรูปแบบทั่วไปก่อน เช่น ใช้ [Convert.autoByExtension](https://reference.aspose.com/slides/th/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) แล้วจึงรวมไฟล์ที่แปลงแล้ว

**ForEach ประมวลผลมาสเตอร์, เลเอาต์, และสไลด์บันทึกหรือไม่?**

[ForEach.slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) ทำการวนผ่านสไลด์การนำเสนอปกติ [ForEach.shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), และ [ForEach.portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) รวมสไลด์ปกติ, มาสเตอร์, และเลเอาต์โดยค่าเริ่มต้น ใช้โอเวอร์โหลดที่ตั้งค่า `includeNotes` เป็น `true` เพื่อรวมสไลด์บันทึก

**ความแตกต่างระหว่าง ForEach.shape กับ Collect.shapes คืออะไร?**

ใช้ [ForEach.shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) เพื่อประมวลผลแต่ละรูปร่างทันทีผ่านคอลแบ็ค ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) เมื่อคุณต้องการผลลัพธ์ที่เป็นอิมาษาแบบวนซ้ำซึ่งสามารถเก็บไว้ กรอง นับ หรือเดินทางหลายครั้งได้

**Compress ทำให้ไฟล์การนำเสนอลดขนาดเสมอหรือไม่?**

ไม่จำเป็น ผลลัพธ์ขึ้นกับว่าการนำเสนอมีเลเอาต์หรือมาสเตอร์ที่ไม่ได้ใช้ หรือฟอนต์ฝังที่มีอักขระไม่ใช้หรือไม่ หากไม่มีสิ่งเหล่านี้ การดำเนินการ [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/) อาจไม่ทำให้ขนาดไฟล์ลดลง

**การเปลี่ยนแปลงโดย ForEach หรือ Compress จะบันทึกโดยอัตโนมัติหรือไม่?**

ไม่ ตัวช่วยเหลือนี้ทำงานบนอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ที่โหลดในหน่วยความจำ หลังจากแก้ไของค์ประกอบในคอลแบ็คของ [ForEach](https://reference.aspose.com/slides/th/java/com.aspose.slides/foreach/) หรือเรียกใช้ [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/) ให้เรียก [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) เพื่อบันทึกผลลัพธ์

## **บทความที่เกี่ยวข้อง**

- [แปลงการนำเสนอ](/java/convert-presentation/)
- [รวมการนำเสนอ](/java/merge-presentation/)
- [มาสเตอร์สไลด์](/java/slide-master/)
- [จัดการกล่องข้อความ](/java/manage-textbox/)
- [ฟอนต์ฝัง](/java/embedded-font/)