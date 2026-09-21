---
title: แก้ไขเอกสาร PDF ใน Java
linktitle: แก้ไข PDF
type: docs
weight: 65
url: /th/java/edit-pdf/
keywords:
- แก้ไข PDF
- แทนที่ข้อความ PDF
- PDF เป็น PPTX
- PPTX เป็น PDF
- Java
- Aspose.Slides
description: "แก้ไขเอกสาร PDF ใน Java โดยการนำเข้ามาใน Aspose.Slides, แทนที่ข้อความ, และบันทึกการนำเสนอที่แก้ไขแล้วกลับเป็น PDF."
---
## **ภาพรวม**

Aspose.Slides for Java ให้คุณแก้ไขเนื้อหา PDF โดยการนำเข้าหน้าต่างเป็นสไลด์, แก้ไขการนำเสนอ, และส่งออกกลับเป็น PDF. บทความนี้แสดงการแทนที่ข้อความอย่างง่าย. การนำเสนออยู่ในหน่วยความจำ, ดังนั้นการบันทึกไฟล์ PPTX ชั่วคราวเป็นสิ่งเลือกได้.

## **แทนที่ข้อความใน PDF**

ใช้ [addFromPdf](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) เพื่อ import หน้า, [replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) เพื่ออัปเดตข้อความ, และ [save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) เพื่อส่งออกผลลัพธ์.

ตัวอย่างต่อไปนี้คาดหวังว่า `input.pdf` มีคำว่า "Draft" เป็นข้อความที่แก้ไขได้หลังการนำเข้า. มันจะแทนที่คำนั้นด้วย "Final" และเขียนเป็น `edited.pdf`. การลบสไลด์แรกก่อนนำเข้าจะป้องกันหน้าว่างเพิ่มในผลลัพธ์. การค้นหาจะตรงกับคำเต็มที่มีตัวอักษรเดียวกัน; `null` หมายถึงไม่จำเป็นต้องมี result callback.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

ดูตัวเลือกเพิ่มเติมได้ที่ [ค้นหาและแทนที่ข้อความ](/slides/th/java/search-and-replace-text/) และ [แปลง PowerPoint เป็น PDF](/slides/th/java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
การแทนที่ข้อความทำงานกับข้อความที่นำเข้า, ไม่ใช่ข้อความภายในภาพสแกน. การแปลงอาจส่งผลต่อการจัดวางและรูปแบบ, ดังนั้นควรตรวจสอบผลลัพธ์, โดยเฉพาะเมื่อข้อความที่แทนที่ยาวกว่าเดิม.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันต้องบันทึกไฟล์ PPTX ก่อนส่งออกเป็น PDF หรือไม่?**

ไม่. คุณสามารถแก้ไขและส่งออกการนำเสนอเดียวกันในหน่วยความจำ. ให้บันทึกสำเนา PPTX เฉพาะเมื่อคุณต้องการแก้ไขต่อใน PowerPoint; ดู [บันทึกการนำเสนอ](/slides/th/java/save-presentation/).

**ทำไมข้อความบางส่วนอาจไม่เปลี่ยนแปลง?**

ตัวอย่างตรงกับคำเต็ม "Draft" ด้วยตัวอักษรตรงกัน. ข้อความที่นำเข้าเป็นภาพหรือแยกเป็นกรอบข้อความหลายส่วนอาจไม่ตรงกับการค้นหา. ตรวจสอบเนื้อหาที่นำเข้าและปรับการค้นหาให้เหมาะกับเอกสารของคุณ.