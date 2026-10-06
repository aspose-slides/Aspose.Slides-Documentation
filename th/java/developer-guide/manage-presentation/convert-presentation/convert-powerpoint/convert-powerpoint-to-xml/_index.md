---
title: แปลงงานนำเสนอ PowerPoint เป็น XML ใน Java
linktitle: PowerPoint เป็น XML
type: docs
weight: 145
url: /th/java/convert-powerpoint-to-xml/
keywords:
- แปลง PowerPoint เป็น XML
- แปลงงานนำเสนอเป็น XML
- PPT เป็น XML
- PPTX เป็น XML
- ODP เป็น XML
- งานนำเสนอ PowerPoint XML
- SaveFormat.Xml
- บันทึกงานนำเสนอเป็น XML
- ส่งออกงานนำเสนอเป็น XML
- สตรีม XML
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีม PowerPoint XML ใน Java ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Aspose.Slides for Java สามารถแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PowerPoint XML Presentation ได้ ผลลัพธ์เป็น XML มีประโยชน์เมื่อคุณต้องการตัวแทนแบบข้อความสำหรับตรวจสอบโครงสร้างของงานนำเสนอ การแก้ไขปัญหาเอกสารที่สร้างขึ้น การเปรียบเทียบผลลัพธ์ในการทดสอบอัตโนมัติ หรือการรวมเข้ากับ workflow ที่ใช้ XML แทนแพ็กเกจงานนำเสนอ

ใช้เมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) พร้อมค่าจาก `Xml` ของคลาส [SaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/) คุณสามารถเขียนผลลัพธ์ลงไฟล์โดยตรงหรือไปยังสตรีมได้

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` สร้าง PowerPoint XML Presentation แต่ไม่ได้สกัดส่วน Office Open XML แยกต่างหากที่จัดเก็บภายในแพ็กเกจ PPTX หากคุณต้องการส่วนของแพ็กเกจ PPTX ที่แน่ชัด เช่น `ppt/presentation.xml` หรือไฟล์ XML ของสไลด์แต่ละไฟล์ ให้ตรวจสอบแพ็กเกจ PPTX โดยตรง

{{% /alert %}}

## **แปลงงานนำเสนอเป็นไฟล์ XML**

โหลดงานนำเสนอแหล่งที่มาด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) จากนั้นส่งเส้นทางไฟล์ผลลัพธ์และ `SaveFormat.Xml` ไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) แหล่งที่มาสามารถเป็นรูปแบบงานนำเสนอใด ๆ ที่รองรับการโหลด เช่น PPT, PPTX หรือ ODP

ตัวอย่างต่อไปนี้ทำการแปลงงานนำเสนอ PPTX เป็นไฟล์ XML:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **เขียนผลลัพธ์ XML ไปยังสตรีม**

ใช้ overload ของสตรีมของเมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) เมื่อ XML ต้องคงอยู่ในหน่วยความจำหรือส่งต่อให้กับคอมโพเนนต์อื่น เช่น เว็บเซอร์วิส ผู้ให้บริการที่เก็บข้อมูล หรือพายป์ไลน์การประมวลผล XML ตัวอย่างต่อไปนี้เขียนผลลัพธ์ไปยัง [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) และดึง XML ที่ได้เป็นอาร์เรย์ของไบต์:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // ส่ง xmlData ไปยังคอมโพเนนต์ต่อไปในกระบวนการทำงาน.
} finally {
    presentation.dispose();
}
```

## **เปรียบเทียบ XML กับรูปแบบการนำเสนอและการส่งออก**

เลือกรูปแบบผลลัพธ์ตามวิธีการที่ผลลัพธ์จะถูกใช้:

| รูปแบบ | ผลลัพธ์ | การใช้งานทั่วไป |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | ตรวจสอบโครงสร้าง, แก้ไขปัญหา, เปรียบเทียบผลลัพธ์ที่สร้างขึ้น, และการรวมแบบ XML |
| PPT (`.ppt`) | ไฟล์งานนำเสนอไบนารีแบบเก่า | ความเข้ากันได้กับ workflow PowerPoint รุ่นเก่า |
| PPTX (`.pptx`) | แพ็กเกจ Office Open XML ที่มีหลายส่วน | การแก้ไข PowerPoint ปกติและการแลกเปลี่ยนงานนำเสนอ |
| PDF หรือ TIFF | หน้าแบบเลย์เอาต์คงที่หรือภาพหลายหน้า | การดู, การพิมพ์, และการเก็บถาวร |
| PNG, JPEG หรือ SVG | การแสดงผลของสไลด์เดี่ยวที่เรนเดอร์ | รูปภาพย่อย, ตัวอย่างก่อน, และสินทรัพย์ภาพ |
| HTML หรือ HTML5 | ผลลัพธ์งานนำเสนอแบบเว็บ | การดูในเบราว์เซอร์และการเผยแพร่บนเว็บ |

แตกต่างจาก PPT และ PPTX, ผลลัพธ์ XML มีจุดประสงค์หลักเพื่อการตรวจสอบและ workflow ที่มุ่งเน้นข้อมูล แตกต่างจาก PDF, TIFF, HTML และรูปแบบภาพสไลด์, XML แสดงข้อมูลงานนำเสนอแทนที่จะเรนเดอร์สไลด์เป็นหน้า หรือสินทรัพย์ภาพ ตาราง [supported file formats](/slides/th/java/supported-file-formats/) แสดงรายการรูปแบบทั้งหมดที่ Aspose.Slides สามารถโหลด, นำเข้า, บันทึก หรือเรนเดอร์ได้

## **คำถามที่พบบ่อย**

**`SaveFormat.Xml` เป็นแบบเดียวกับการบันทึกไฟล์ PPTX หรือไม่?**

ไม่. PPTX เป็นแพ็กเกจที่มีหลายส่วนของ Office Open XML, ส่วน `SaveFormat.Xml` สร้างไฟล์ PowerPoint XML Presentation

**ฉันสามารถบันทึกผลลัพธ์ XML ได้โดยไม่สร้างไฟล์บนดิสก์หรือไม่?**

ได้. ส่งสตรีมที่สามารถเขียนได้ไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) ตัวอย่างเช่น ใช้ [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) สำหรับการประมวลผลในหน่วยความจำ

**Aspose.Slides สามารถโหลดไฟล์ XML ที่ส่งออกได้อีกครั้งหรือไม่?**

ได้. ส่งไฟล์ XML หรือสตรีมไปยังคอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) แล้วเมธอด [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSourceFormat--) จะคืนค่า `SourceFormat.Xml` ส่วนเมธอด [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) จะรายงาน `LoadFormat.Unknown` สำหรับรูปแบบนี้ ดังนั้นอย่าใช้ค่านี้ในการตรวจสอบว่าสามารถเปิดไฟล์ XML ได้หรือไม่

**การแปลงเป็น XML จะเรนเดอร์สไลด์แต่ละสไลด์เป็นหน้า หรือภาพหรือไม่?**

ไม่. การแปลงเป็น XML จะเขียนข้อมูลงานนำเสนอที่มีโครงสร้าง ใช้ PDF หรือ TIFF สำหรับผลลัพธ์แบบหน้า, หรือ PNG, JPEG, และ SVG สำหรับภาพสไลด์เดี่ยว.