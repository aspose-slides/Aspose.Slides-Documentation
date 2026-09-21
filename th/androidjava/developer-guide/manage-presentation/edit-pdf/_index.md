---
title: แก้ไขเอกสาร PDF บน Android
linktitle: แก้ไข PDF
type: docs
weight: 65
url: /th/androidjava/edit-pdf/
keywords:
- แก้ไข PDF
- แทนที่ข้อความ PDF
- PDF เป็น PPTX
- PPTX เป็น PDF
- Android
- Java
- Aspose.Slides
description: "แก้ไขเอกสาร PDF บน Android ด้วย Java โดยนำเข้าลงใน Aspose.Slides, แทนที่ข้อความ, และบันทึกการนำเสนอที่แก้ไขแล้วกลับเป็น PDF."
---
## **ภาพรวม**

Aspose.Slides for Android via Java ให้คุณแก้ไขเนื้อหา PDF โดยนำเข้าหน้าต่างเป็นสไลด์ ปรับการนำเสนอ และส่งออกกลับเป็น PDF บทความนี้แสดงการแทนที่ข้อความอย่างง่าย การนำเสนออยู่ในหน่วยความจำ ดังนั้นการบันทึกไฟล์ PPTX ชั่วคราวเป็นขั้นเลือกได้

## **แทนที่ข้อความใน PDF**

ใช้ [addFromPdf](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) เพื่อนำเข้าหน้า, [replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) เพื่ออัปเดตข้อความ, และ [save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) เพื่อส่งออกผลลัพธ์

ตัวอย่างต่อไปนี้คาดว่า `input.pdf` มีคำว่า "Draft" เป็นข้อความที่แก้ไขได้หลังการนำเข้า จะเปลี่ยนคำนั้นเป็น "Final" และเขียนไฟล์ `edited.pdf` การลบสไลด์เริ่มต้นก่อนนำเข้าเพื่อป้องกันหน้าว่างเพิ่มในผลลัพธ์ การค้นหาจะตรงกับคำเต็มโดยคำนึงถึงตัวอักษรพิมพ์ใหญ่‑พิมพ์เล็ก; `null` หมายถึงไม่ต้องการคอลแบ็กผลลัพธ์

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

สำหรับตัวเลือกเพิ่มเติม โปรดดู [ค้นหาและแทนที่ข้อความ](/slides/th/androidjava/search-and-replace-text/) และ [แปลง PowerPoint เป็น PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/)

{{% alert color="info" title="หมายเหตุ" %}}
การแทนที่ข้อความทำได้กับข้อความที่นำเข้าแล้ว ไม่ใช่ข้อความในรูปสแกน การแปลงอาจส่งผลต่อการจัดวางและรูปแบบ ดังนั้นควรตรวจสอบผลลัพธ์ โดยเฉพาะเมื่อข้อความที่แทนที่ยาวกว่าข้อความเดิม
{{% /alert %}}

## **คำถามที่พบบ่อย**

**จำเป็นต้องบันทึกไฟล์ PPTX ก่อนส่งออกเป็น PDF หรือไม่?**

ไม่จำเป็น คุณสามารถแก้ไขและส่งออกการนำเสนอเดียวกันในหน่วยความจำได้ หากต้องการแก้ไขต่อใน PowerPoint ให้บันทึกสำเนา PPTX ดูที่ [บันทึกการนำเสนอ](/slides/th/androidjava/save-presentation/)

**ทำไมบางข้อความถึงไม่เปลี่ยนแปลง?**

ตัวอย่างตรงกับคำเต็ม "Draft" อย่างพอดี หากข้อความถูกนำเข้าเป็นรูปภาพหรือแยกเป็นกรอบข้อความหลายกรอบ การค้นหาอาจไม่พบ ตรวจสอบเนื้อหาที่นำเข้าและปรับการค้นหาให้เหมาะกับเอกสารของคุณ