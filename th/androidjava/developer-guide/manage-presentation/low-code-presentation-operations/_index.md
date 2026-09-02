---
title: การดำเนินการการนำเสนอแบบ Low-Code บน Android
linktitle: API Low-Code
type: docs
weight: 50
url: /th/androidjava/low-code-presentation-operations/
keywords:
- API การนำเสนอแบบ low-code
- แปลงการนำเสนอ
- ผสานการนำเสนอ
- วนลูปสไลด์
- วนลูปรูปทรง
- วนลูปข้อความ
- รวบรวมรูปทรง
- บีบอัดการนำเสนอ
- ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้
- ลบเลย์เอาต์สไลด์ที่ไม่ได้ใช้
- บีบอัดฟอนท์ที่ฝังไว้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ใช้ API low-code ของ Aspose.Slides บน Android เพื่อแปลงและผสานการนำเสนอ, วนลูปผ่านเนื้อหา, รวบรวมรูปทรง, และลดขนาดการนำเสนอ."
---
## **ภาพรวม**

แพคเกจ [com.aspose.slides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/) ให้คลาสตช่วยเหลือแบบสแตติกสำหรับการทำงานทั่วไปกับการนำเสนอ ตัวช่วยเหล่านี้ห่อหุ้มกระบวนการทำงานของอ็อบเจ็กต์โมเดลที่ใช้บ่อยในเมธอดที่มุ่งเน้น ทำให้คุณสามารถแปลงหรือผสานไฟล์, ประมวลผลองค์ประกอบของการนำเสนอ, รวบรวมรูปทรง, และลบเนื้อหาที่ไม่ได้ใช้ได้ด้วยโค้ดที่สั้นลง

ตัวช่วยแบบ low‑code มีประโยชน์ที่สุดเมื่อการดำเนินการใช้กับไฟล์หรือการนำเสนอทั้งหมดและกระบวนการทำงานเริ่มต้นตรงกับความต้องการของคุณ ใช้ [Aspose.Slides object model](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/) แบบเต็มเมื่อคุณต้องการการควบคุมละเอียดต่อสไลด์, มาสเตอร์, เลย์เอาต์, รูปทรง, การตั้งค่าการส่งออก, หรือความสัมพันธ์ระหว่างองค์ประกอบของการนำเสนอ

ตารางต่อไปสรุปตัวช่วยที่มีให้:

| ตัวช่วย | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/convert/) | การแปลงการนำเสนอเป็นรูปแบบอื่นด้วยการเรียกไฟล์‑ต่อ‑ไฟล์โดยตรง |
| [Merger](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/merger/) | การรวมไฟล์การนำเสนอเต็มรูปแบบที่มีรูปแบบเดียวกัน |
| [ForEach](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/) | การดำเนินการต่อสไลด์, รูปทรง, ย่อหน้า หรือส่วนของข้อความแต่ละรายการ |
| [Collect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/collect/) | การดึงรูปทรงจากการนำเสนอทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์ซ้ำ |
| [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/) | การลบมาสเตอร์และเลย์เอาต์ที่ไม่ได้ใช้และลดข้อมูลฟอนท์ที่ฝังไว้ |

## **แปลงการนำเสนอ**

ใช้ [Convert.autoByExtension](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) เมื่อส่วนขยายไฟล์ผลลัพธ์เพียงพอที่จะเลือกรูปแบบการส่งออก เมธอดจะเปิดการนำเสนอแหล่งที่มา, กำหนดรูปแบบที่ต้องการจากเส้นทางผลลัพธ์, และเขียนผลลัพธ์ออกมา

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

คลาส [Convert](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/convert/) ยังมีเมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG, และ TIFF ใช้โมเดลอ็อบเจ็กต์เต็มเมื่อคุณต้องการตรวจสอบหรือแก้ไขการนำเสนอก่อนส่งออกหรือกำหนดค่าตัวเลือกการส่งออกที่ตัวช่วยไม่ได้เปิดเผย ดู [Convert Presentation](/androidjava/convert-presentation/) สำหรับกระบวนการทำงานและตัวเลือกตามรูปแบบ

## **ผสานการนำเสนอ**

ใช้ [Merger.process](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) เพื่อรวมไฟล์การนำเสนอเต็มรูปแบบด้วยการเรียกครั้งเดียว การนำเสนอที่นำเข้าต้องมีรูปแบบไฟล์เดียวกัน

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

ตัวช่วยนี้เหมาะเมื่อสไลด์ทั้งหมดควรต่อเนื่องเป็นผลลัพธ์เดียวโดยไม่ต้องเลือกหรือแมปแต่ละสไลด์เอง ใช้โมเดลอ็อบเจ็กต์เต็มเมื่อคุณต้องการผสานสไลด์ที่เลือก, ใส่มาสเตอร์หรือเลย์เอาต์ปลายทาง, รักษาส่วนเฉพาะอย่างชัดเจน, หรือจัดการขนาดสไลด์ที่แตกต่างกัน ดู [Merge Presentations](/androidjava/merge-presentation/) สำหรับสถานการณ์เหล่านั้น

## **วนลูปผ่านองค์ประกอบการนำเสนอ**

คลาส [ForEach](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/) เรียกคอลแบ็กสำหรับองค์ประกอบการนำเสนอแต่ละประเภทที่ร้องขอ ช่วยหลีกเลี่ยงการทำลูปคอลเลกชันซ้อนกันและสะดวกสำหรับการตรวจสอบหรือการเปลี่ยนแปลงรูปแบบทั่วทั้งการนำเสนอ

ตัวอย่างต่อไปใช้ [ForEach.slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), และ [ForEach.portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) เพื่อตรวจสอบองค์ประกอบที่สอดคล้องกัน:

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

โดยค่าเริ่มต้น การเดินทางทั่วการนำเสนอสำหรับรูปทรงและข้อความจะรวมสไลด์ปกติ, มาสเตอร์, และเลย์เอาต์ การโอเวอร์โหลดที่มีพารามิเตอร์ `includeNotes` ยังสามารถประมวลผลสไลด์โน้ตได้ ใช้ลูปคอลเลกชันโดยตรงเมื่อการเรียงลำดับการเดินทาง, การออกก่อนเวลา, การกรองก่อนเรียกคอลแบ็ก, หรือการควบคุมพาเรนท์‑เชิลด์อย่างละเอียดมีความสำคัญ

## **รวบรวมรูปทรง**

ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) เมื่อคุณต้องการคอลเลกชันของรูปทรงทั้งหมดในการนำเสนอแทนการใช้คอลแบ็กสำหรับแต่ละรูปทรง สิ่งนี้มีประโยชน์เมื่อชุดเดียวกันต้องถูกกรอง, นับ, หรือประมวลผลหลายครั้ง

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

ใช้ [ForEach.shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) แทนเมื่อรูปทรงแต่ละอันสามารถจัดการได้ทันทีและคุณไม่จำเป็นต้องเก็บผลลัพธ์ที่รวบรวมไว้

## **บีบอัดเนื้อหาในการนำเสนอ**

คลาส [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ได้ใช้และลดข้อมูลฟอนท์ที่ฝังไว้:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) ลบเลย์เอาต์สไลด์ที่ไม่มีสไลด์ปกติอ้างอิง
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) ลบมาสเตอร์สไลด์ที่ไม่ถูกใช้แล้ว
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) ลบอักขระที่ไม่ได้ใช้จากฟอนท์ที่ฝังไว้

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

ให้ลบเลย์เอาต์ที่ไม่ได้ใช้ก่อนมาสเตอร์ที่ไม่ได้ใช้ เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังจากทำความสะอาดเลย์เอาต์ก็สามารถลบได้ด้วย จัดเก็บการนำเสนอที่ปรับแต่งแล้วลงไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์, เลย์เอาต์, หรือข้อมูลฟอนท์ที่ฝังไว้ทั้งหมดในภายหลัง ดูรายละเอียดเพิ่มเติมที่ [Slide Master](/androidjava/slide-master/) และ [Embedded Font](/androidjava/embedded-font/)

## **คำถามที่พบบ่อย**

**ควรใช้ API low‑code แทนโมเดลอ็อบเจ็กต์เต็มเมื่อไหร่?**

ใช้ตัวช่วย low‑code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือการนำเสนอทั้งหมดและไม่ต้องการการควบคุมละเอียดต่อแต่ละองค์ประกอบ ใช้โมเดลอ็อบเจ็กต์เต็มเมื่อคุณต้องการเลือกสไลด์เฉพาะ, ควบคุมความสัมพันธ์ของมาสเตอร์และเลย์เอาต์, ตรวจสอบสถานะกลาง, หรือกำหนดพฤติกรรมที่ตัวช่วยไม่ได้เปิดเผย

**Merger สามารถผสานการนำเสนอที่มีรูปแบบไฟล์ต่างกันได้หรือไม่?**

ไม่ได้ ตัวช่วย [Merger.process](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) ต้องการไฟล์การนำเข้าที่มีรูปแบบเดียวกัน ก่อนนั้นควรแปลงไฟล์อินพุตเป็นรูปแบบเดียวกันก่อน เช่นใช้ [Convert.autoByExtension](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) แล้วจึงผสานไฟล์ที่แปลงแล้ว

**ForEach ประมวลผลสไลด์มาสเตอร์, เลย์เอาต์, และโน้ตหรือไม่?**

[ForEach.slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) จะวนลูปผ่านสไลด์การนำเสนอปกติ ส่วนการดำเนินการทั่วการนำเสนอของ [ForEach.shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), และ [ForEach.portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) จะรวมสไลด์ปกติ, มาสเตอร์, และเลย์เอาต์โดยค่าเริ่มต้น ใช้โอเวอร์โหลดที่ตั้งค่า `includeNotes` เป็น `true` เพื่อรวมสไลด์โน้ต

**ความแตกต่างระหว่าง ForEach.shape กับ Collect.shapes คืออะไร?**

ใช้ [ForEach.shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) เพื่อประมวลผลแต่ละรูปทรงทันทีผ่านคอลแบ็ก ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) เมื่อคุณต้องการผลลัพธ์ที่เป็นอิเทอเรเบิลซึ่งสามารถเก็บไว้, กรอง, นับ, หรือเดินทางหลายครั้งได้

**Compress ทำให้ไฟล์การนำเสนอลดขนาดเสมอหรือไม่?**

ไม่จำเป็น ผลลัพธ์ขึ้นอยู่กับว่าการนำเสนอมีเลย์เอาต์ที่ไม่ได้ใช้, มาสเตอร์ที่ไม่ได้ใช้, หรือฟอนท์ที่ฝังไว้ที่มีอักขระที่ไม่ได้ใช้หรือไม่ หากไม่มีสิ่งเหล่านี้ การดำเนินการ [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/) อาจไม่ลดขนาดไฟล์

**การเปลี่ยนแปลงโดย ForEach หรือ Compress จะบันทึกโดยอัตโนมัติหรือไม่?**

ไม่ ตัวช่วยเหล่านี้ทำงานบนอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ที่โหลดอยู่ในหน่วยความจำ หลังจากแก้ไของค์ประกอบในคอลแบ็กของ [ForEach](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/foreach/) หรือรัน [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/) ให้เรียก [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) เพื่อเขียนผลลัพธ์

## **บทความที่เกี่ยวข้อง**

- [Convert Presentation](/androidjava/convert-presentation/)
- [Merge Presentations](/androidjava/merge-presentation/)
- [Slide Master](/androidjava/slide-master/)
- [Manage Text Box](/androidjava/manage-textbox/)
- [Embedded Font](/androidjava/embedded-font/)