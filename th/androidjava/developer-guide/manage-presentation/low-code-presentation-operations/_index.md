---
title: การดำเนินการพรีเซนเทชันแบบ Low-Code บน Android
linktitle: API Low-Code
type: docs
weight: 50
url: /th/androidjava/low-code-presentation-operations/
keywords:
- API พรีเซนเทชัน low-code
- แปลงพรีเซนเทชัน
- รวมพรีเซนเทชัน
- วนสไลด์
- วนรูปทรง
- วนข้อความ
- รวบรวมรูปทรง
- บีบอัดพรีเซนเทชัน
- ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้
- ลบเลย์เอาต์สไลด์ที่ไม่ได้ใช้
- บีบอัดฟอนต์ที่ฝังอยู่
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "ใช้ API low-code ของ Aspose.Slides บน Android เพื่อแปลงและรวมพรีเซนเทชัน, วนผ่านเนื้อหา, รวบรวมรูปทรง, และลดขนาดพรีเซนเทชัน."
---
## **ภาพรวม**

แพ็กเกจ [com.aspose.slides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/) มีคลาสตัวช่วยแบบสถิตสำหรับการดำเนินการพรีเซนเทชันทั่วไป ตัวช่วยเหล่านี้บรรจุ workflow ของโมเดลวัตถุที่ใช้บ่อยในเมธอดที่มุ่งเน้น ทำให้คุณสามารถแปลงหรือรวมไฟล์, ประมวลผลองค์ประกอบพรีเซนเทชัน, รวบรวมรูปทรง, และลบเนื้อหาที่ไม่ได้ใช้ด้วยโค้ดที่น้อยลง

ตัวช่วยแบบ low-code จะมีประโยชน์ที่สุดเมื่อการดำเนินการใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและ workflow เริ่มต้นตรงกับความต้องการของคุณ ใช้ [Aspose.Slides object model](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/) เต็มรูปแบบเมื่อคุณต้องการการควบคุมระดับละเอียดบนสไลด์แต่ละสไลด์, มาสเตอร์, เลย์เอาต์, รูปทรง, การตั้งค่าการส่งออก, หรือความสัมพันธ์ระหว่างองค์ประกอบของพรีเซนเทชัน

ตารางต่อไปนี้สรุปตัวช่วยที่พร้อมใช้งาน:

| ตัวช่วย | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/convert/) | การแปลงพรีเซนเทชันเป็นรูปแบบอื่นโดยเรียกโดยตรงจากไฟล์ไปยังไฟล์ |
| [Merger](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/merger/) | การรวมไฟล์พรีเซนเทชันเต็มรูปแบบที่มีรูปแบบเดียวกัน |
| [ForEach](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/) | การทำงานกับแต่ละสไลด์, รูปทรง, ย่อหน้า, หรือส่วนของข้อความ |
| [Collect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/collect/) | การดึงรูปทรงทั้งหมดจากพรีเซนเทชันสำหรับการประมวลผลหรือวิเคราะห์ซ้ำ |
| [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/) | การลบมาสเตอร์และเลย์เอาต์ที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังไว้ |

## **แปลงพรีเซนเทชัน**

ใช้ [Convert.autoByExtension](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) เมื่อส่วนขยายไฟล์ผลลัพธ์เพียงพอที่จะเลือกรูปแบบการส่งออก เมธอดจะเปิดพรีเซนเทชันต้นฉบับ, กำหนดรูปแบบที่ต้องการจากเส้นทางไฟล์ผลลัพธ์, และเขียนผลลัพธ์ออกไป

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

คลาส [Convert](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/convert/) ยังมีเมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG, และ TIFF อีกด้วย ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการตรวจสอบหรือแก้ไขพรีเซนเทชันก่อนการส่งออกหรือกำหนดตัวเลือกการส่งออกที่ตัวช่วยไม่สนับสนุน ดูที่ [Convert Presentation](/slides/th/androidjava/convert-presentation/) สำหรับ workflow และตัวเลือกเฉพาะรูปแบบ

## **รวมพรีเซนเทชัน**

ใช้ [Merger.process](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) เพื่อรวมไฟล์พรีเซนเทชันเต็มรูปแบบด้วยการเรียกครั้งเดียว พรีเซนเทชันอินพุตต้องมีรูปแบบไฟล์เดียวกัน

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

ตัวช่วยนี้เหมาะเมื่อสไลด์ทั้งหมดควรต่อท้ายผลลัพธ์หนึ่งโดยไม่ต้องเลือกหรือแมปใหม่แต่ละสไลด์ ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการรวมสไลด์ที่เลือก, ใช้มาสเตอร์หรือเลย์เอาต์ปลายทาง, เก็บส่วนต่างๆ อย่างชัดเจน, หรือปรับขนาดสไลด์ที่แตกต่างกัน ดูที่ [Merge Presentations](/slides/th/androidjava/merge-presentation/) สำหรับสถานการณ์เหล่านั้น

## **วนซ้ำผ่านองค์ประกอบพรีเซนเทชัน**

คลาส [ForEach](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/) จะเรียก callback สำหรับแต่ละประเภทขององค์ประกอบพรีเซนเทชันที่ร้องขอ ซึ่งช่วยหลีกเลี่ยงลูปการเก็บรวบรวมซ้อนกันและสะดวกสำหรับการตรวจสอบหรือการเปลี่ยนแปลงรูปแบบทั่วพรีเซนเทชัน

ตัวอย่างต่อไปนี้ใช้ [ForEach.slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), และ [ForEach.portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) เพื่อสอบถามองค์ประกอบที่สอดคล้องกัน:

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

โดยค่าเริ่มต้น การไล่รูปทรงและข้อความทั่วพรีเซนเทชันจะรวมสไลด์ปกติ, มาสเตอร์, และเลย์เอาต์ไว้ด้วย พารามิเตอร์ `includeNotes` ในการโอเวอร์โหลดสามารถประมวลผลสไลด์บันทึกย่อได้เช่นกัน ใช้ลูปการเก็บรวบรวมโดยตรงเมื่อลำดับการไหล, การออกก่อนเวลา, การกรองก่อนเรียก callback, หรือการควบคุมความสัมพันธ์พาเรนท์-ชิลด์อย่างละเอียดมีความสำคัญ

## **รวบรวมรูปทรง**

ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) เมื่อคุณต้องการคอลเลกชันของรูปทรงทั้งหมดในพรีเซนเทชันแทนการใช้ callback สำหรับแต่ละรูปทรง ซึ่งมีประโยชน์เมื่อต้องทำการกรอง, นับ, หรือประมวลผลชุดเดียวกันหลายครั้ง

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

ใช้ [ForEach.shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) แทนเมื่อแต่ละรูปทรงสามารถจัดการได้ทันทีและคุณไม่จำเป็นต้องเก็บผลลัพธ์ที่รวบรวมไว้

## **บีบอัดเนื้อหาพรีเซนเทชัน**

คลาส [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังไว้:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) ลบสไลด์เลย์เอาต์ที่ไม่มีสไลด์ปกติอ้างอิง
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) ลบมาสเตอร์สไลด์ที่ไม่ถูกใช้แล้ว
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) ลบอักขระที่ไม่ได้ใช้จากฟอนต์ที่ฝังไว้

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

ให้ลบเลย์เอาต์ที่ไม่ได้ใช้ก่อนมาสเตอร์ที่ไม่ได้ใช้ เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังจากทำความสะอาดเลย์เอาต์ถูกลบด้วย บันทึกพรีเซนเทชันที่ปรับแต่งแล้วเป็นไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์, เลย์เอาต์, หรือข้อมูลฟอนต์ฝังเต็มรูปแบบในภายหลัง ดูรายละเอียดเพิ่มเติมที่ [Slide Master](/slides/th/androidjava/slide-master/) และ [Embedded Font](/slides/th/androidjava/embedded-font/)

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ API low-code แทนโมเดลวัตถุเต็มรูปแบบ?**

ใช้ตัวช่วย low-code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและไม่ต้องการการควบคุมละเอียดบนองค์ประกอบแต่ละตัว ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการเลือกสไลด์เฉพาะ, ควบคุมความสัมพันธ์ของมาสเตอร์และเลย์เอาต์, ตรวจสอบสถานะกลาง, หรือกำหนดพฤติกรรมที่ตัวช่วยไม่เปิดเผย

**Merger สามารถรวมพรีเซนเทชันที่มีรูปแบบไฟล์ต่างกันได้หรือไม่?**

ไม่ได้. [Merger.process](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) ต้องการพรีเซนเทชันอินพุตที่มีรูปแบบเดียวกัน แปลงไฟล์อินพุตเป็นรูปแบบทั่วไปก่อน เช่นโดยใช้ [Convert.autoByExtension](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) แล้วจึงรวมไฟล์ที่แปลงแล้ว

**ForEach ประมวลผลมาสเตอร์, เลย์เอาต์, และสไลด์บันทึกย่อหรือไม่?**

[ForEach.slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) จะวนผ่านสไลด์พรีเซนเทชันปกติ ส่วนการทำงานของ [ForEach.shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), และ [ForEach.portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) จะรวมสไลด์ปกติ, มาสเตอร์, และเลย์เอาต์โดยค่าเริ่มต้น ใช้โอเวอร์โหลดที่มี `includeNotes` เป็น `true` เพื่อรวมสไลด์บันทึกย่อ

**ความแตกต่างระหว่าง ForEach.shape และ Collect.shapes คืออะไร?**

ใช้ [ForEach.shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) เพื่อประมวลผลแต่ละรูปทรงทันทีผ่าน callback ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) เมื่อคุณต้องการผลลัพธ์ที่สามารถเก็บไว้, กรอง, นับ, หรือไล่หลายครั้ง

**Compress จะทำให้ไฟล์พรีเซนเทชันเล็กลงเสมอหรือไม่?**

ไม่จำเป็น ผลลัพธ์ขึ้นอยู่กับว่าพรีเซนเทชันมีเลย์เอาต์ที่ไม่ได้ใช้, มาสเตอร์ที่ไม่ได้ใช้, หรือฟอนต์ฝังที่มีอักขระที่ไม่ได้ใช้หรือไม่ หากไม่มีส่วนเหล่านี้ การทำงานของ [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/) อาจไม่ลดขนาดไฟล์

**การเปลี่ยนแปลงที่ทำโดย ForEach หรือ Compress จะถูกบันทึกอัตโนมัติหรือไม่?**

ไม่ ตัวช่วยเหล่านี้ทำงานบนวัตถุ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ที่โหลดอยู่ในหน่วยความจำ หลังจากแก้ไของค์ประกอบใน callback ของ [ForEach](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/) หรือเรียกใช้ [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/) ให้เรียก [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) เพื่อเขียนผลลัพธ์

## **บทความที่เกี่ยวข้อง**

- [แปลงพรีเซนเทชัน](/slides/th/androidjava/convert-presentation/)
- [รวมพรีเซนเทชัน](/slides/th/androidjava/merge-presentation/)
- [มาสเตอร์สไลด์](/slides/th/androidjava/slide-master/)
- [จัดการกล่องข้อความ](/slides/th/androidjava/manage-textbox/)
- [ฟอนต์ฝัง](/slides/th/androidjava/embedded-font/)