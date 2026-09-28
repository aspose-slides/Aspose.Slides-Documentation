---
title: สร้างการนำเสนอบน Android
linktitle: สร้างการนำเสนอ
type: docs
weight: 10
url: /th/androidjava/create-presentation/
keywords:
- สร้างการนำเสนอ
- การนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างการนำเสนอด้วย Java และ Aspose.Slides สำหรับ Android—สร้างไฟล์ PPT, PPTX และ ODP, ใช้ประโยชน์จากการสนับสนุน OpenDocument และบันทึกไฟล์โดยโปรแกรมเพื่อผลลัพธ์ที่เชื่อถือได้"
---
## **Overview**

บทความนี้แสดงวิธีการสร้างการนำเสนอใน Aspose.Slides for Android ผ่าน Java, เพิ่มกล่องข้อความเข้าไปในสไลด์แรก, และบันทึกผลลัพธ์เป็นไฟล์ในที่จัดเก็บของแอปของคุณ เพื่อเปิดการนำเสนอที่มีอยู่หรือบันทึกเป็นรูปแบบอื่น ดู [Open Presentation](/slides/th/androidjava/open-presentation/) และ [Save Presentation](/slides/th/androidjava/save-presentation/) คำถามที่พบบ่อยสั้น ๆ ที่ส่วนท้ายครอบคลุมคำถามทั่วไปเกี่ยวกับรูปแบบ, แม่แบบ, ขนาดสไลด์, หน่วยวัด, การใช้หน่วยความจำ, การทำงานหลายเธรด, การให้สิทธิใช้งาน, ลายเซ็นดิจิทัล, และการสนับสนุน VBA

ก่อนเริ่มต้นให้เพิ่ม Aspose.Slides ไปยังโครงการ Android ของคุณจาก Maven repository ของ Aspose ดู [Installation](/slides/th/androidjava/install-aspose-slides-for-android-via-java/)

## **Create a PowerPoint Presentation**

เพื่อสร้างการนำเสนอและใส่กล่องข้อความบนสไลด์แรก ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) การนำเสนอใหม่จะมีสไลด์ว่างเปล่าอยู่แล้วหนึ่งสไลด์
1. ดึงสไลด์นั้นจาก [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) โดยใช้ดัชนี 0
1. เพิ่มสี่เหลี่ยมด้วยเมธอด [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) ของ [shape collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) และตั้งค่าข้อความของ [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) ด้วยเมธอด [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-)
1. บันทึกการนำเสนอเป็นไฟล์ PPTX ด้วยเมธอด [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ในรูปแบบ [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/)

โค้ดทำงานภายใน `Activity` ตัวอย่างเช่นในเมธอด `onCreate` ของมัน บันทึกไฟล์ไปยังไดเรกทอรีที่คืนค่าจากเมธอด [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) คือที่เก็บส่วนตัวของแอปซึ่งสามารถเขียนได้โดยไม่ต้องขอสิทธิใด ๆ

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

มุมซ้ายบนของสี่เหลี่ยมอยู่ 50 points จากขอบซ้ายและ 50 points จากขอบบนของสไลด์ และสี่เหลี่ยมมีความกว้าง 400 points สูง 100 points ไฟล์ที่บันทึกมีสไลด์หนึ่งสไลด์ที่มีสี่เหลี่ยมและข้อความนั้น หากไม่มีใบอนุญาต Aspose.Slides จะเพิ่มลายน้ำการประเมินผลในทุกสไลด์ที่บันทึก; ดู [Licensing](/slides/th/androidjava/licensing/)

เพื่อดูไฟล์ ให้เปิด [Device Explorer]ของ Android Studio และค้นหา *hello.pptx* ภายใต้ *data/data/* ในโฟลเดอร์ *files* ของแอปของคุณ ในแอปที่ใช้งานจริง ควรประมวลผลการนำเสนอในเธรดพื้นหลังเพื่อให้ส่วนต่อประสานผู้ใช้ทำงานได้อย่างราบรื่น

## **FAQ**

### What formats can I save a new presentation to?

คุณสามารถบันทึกเป็น [PPTX, PPT, and ODP](/slides/th/androidjava/save-presentation/) และส่งออกเป็น [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/th/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/th/androidjava/convert-powerpoint-to-html/), [SVG](/slides/th/androidjava/render-a-slide-as-an-svg-image/), และ [images](/slides/th/androidjava/convert-powerpoint-to-png/) เป็นต้น

### Can I start from a template (POTX/POTM) and save as a regular PPTX?

ได้ โหลดแม่แบบแล้วบันทึกเป็นรูปแบบที่ต้องการ; POTX/POTM/PPTM และรูปแบบที่คล้ายกัน [are supported](/slides/th/androidjava/supported-file-formats/)

### How do I control slide size/aspect ratio when creating a presentation?

ตั้งค่า [slide size](/slides/th/androidjava/slide-size/) (รวมถึงพรีเซ็ตเช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกวิธีการปรับขนาดเนื้อหา

### In what units are sizes and coordinates measured?

เป็นหน่วย points: 1 นิ้วเท่ากับ 72 units

### How do I handle very large presentations (with many media files) to reduce memory usage?

ใช้ [BLOB management strategies](/slides/th/androidjava/manage-blob/), จำกัดการจัดเก็บในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และควรเลือกเวิร์กฟลว์แบบไฟล์แทนสตรีมในหน่วยความจำเต็มรูปแบบ

### Can I create/save presentations in parallel?

คุณไม่สามารถทำงานกับอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) เดียวจาก [multiple threads](/slides/th/androidjava/multithreading/) ได้ ให้สร้างอินสแตนซ์แยกต่างหากต่อเธรดหรือกระบวนการ

### How do I remove the trial watermark and limitations?

[Apply a license](/slides/th/androidjava/licensing/) ครั้งเดียวต่อกระบวนการ XML ใบอนุญาตต้องไม่ถูกแก้ไข และการตั้งค่าใบอนุญาตควรรองรับการทำงานพร้อมกันหากมีหลายเธรด

### Can I digitally sign the PPTX I create?

ได้ รองรับ [Digital signatures](/slides/th/androidjava/digital-signature-in-powerpoint/) (การเพิ่มและการตรวจสอบ) สำหรับการนำเสนอ

### Are macros (VBA) supported in created presentations?

ได้ คุณสามารถ [create/edit VBA projects](/slides/th/androidjava/presentation-via-vba/) และบันทึกไฟล์ที่มีมาโครเช่น PPTM/PPSM