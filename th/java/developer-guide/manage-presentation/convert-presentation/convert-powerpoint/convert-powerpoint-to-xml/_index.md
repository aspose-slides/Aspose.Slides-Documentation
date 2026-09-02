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
- PowerPoint XML Presentation
- SaveFormat.Xml
- บันทึกงานนำเสนอเป็น XML
- ส่งออกงานนำเสนอเป็น XML
- สตรีม XML
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีม PowerPoint XML ใน Java ด้วย Aspose.Slides for Java."
---
## **ภาพรวม**

Aspose.Slides for Java สามารถแปลงงานนำเสนอ PowerPoint ไปเป็นรูปแบบ PowerPoint XML Presentation ได้ การส่งออกเป็น XML มีประโยชน์เมื่อคุณต้องการตัวแทนในรูปแบบข้อความเพื่อการตรวจสอบโครงสร้างของงานนำเสนอ การแก้ไขปัญหาเอกสารที่สร้างขึ้น การเปรียบเทียบผลลัพธ์ในการทดสอบอัตโนมัติ หรือการรวมเข้ากับกระบวนการทำงานที่ใช้ XML แทนแพ็กเกจงานนำเสนอ

ใช้เมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) กับค่า `Xml` จากคลาส [SaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/) คุณสามารถเขียนผลลัพธ์โดยตรงไปยังไฟล์หรือสตรีมได้

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` สร้าง PowerPoint XML Presentation ไม่ได้ทำการแยกส่วน Office Open XML แต่ละส่วนที่เก็บอยู่ภายในแพ็กเกจ PPTX หากคุณต้องการส่วนของแพ็กเกจ PPTX อย่างแม่นยำ เช่น `ppt/presentation.xml` หรือไฟล์ XML ของสไลด์แต่ละไฟล์ ให้ตรวจสอบแพ็กเกจ PPTX เอง
{{% /alert %}}

## **แปลงงานนำเสนอเป็นไฟล์ XML**

โหลดงานนำแหล่งด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) แล้วส่งพาธออกและ `SaveFormat.Xml` ให้กับ [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) แหล่งที่มาสามารถเป็นรูปแบบงานนำเสนอใดก็ได้ที่รองรับการโหลด เช่น PPT, PPTX หรือ ODP

ตัวอย่างต่อไปนี้แปลงงานนำเสนอ PPTX เป็นไฟล์ XML:

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

ใช้การ overload แบบสตรีมของ [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) เมื่อ XML ต้องอยู่ในหน่วยความจำหรือส่งต่อไปยังส่วนประกอบอื่น เช่น เว็บเซอร์วิส ผู้ให้บริการจัดเก็บข้อมูล หรือ pipeline การประมวลผล XML ตัวอย่างต่อไปนี้เขียนผลลัพธ์ไปยัง [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) และรับ XML ที่ได้เป็นอาร์เรย์ของไบต์:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // ส่ง xmlData ไปยังส่วนประกอบถัดไปในกระบวนการทำงาน.
} finally {
    presentation.dispose();
}
```

## **เปรียบเทียบ XML กับรูปแบบงานนำเสนอและการส่งออก**

เลือกรูปแบบการส่งออกตามวิธีการที่ผลลัพธ์จะถูกใช้:

| รูปแบบ | ผลลัพธ์ | การใช้งานทั่วไป |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | การตรวจสอบโครงสร้าง, การแก้ไขปัญหา, การเปรียบเทียบผลลัพธ์ที่สร้างขึ้น, และการรวมระบบแบบ XML |
| PPT (`.ppt`) | ไฟล์งานนำเสนอแบบไบนารีเก่า | ความเข้ากันได้กับกระบวนการทำงาน PowerPoint รุ่นเก่า |
| PPTX (`.pptx`) | แพ็กเกจ Office Open XML ที่มีหลายส่วน | การแก้ไข PowerPoint ปกติและการแลกเปลี่ยนงานนำเสนอ |
| PDF หรือ TIFF | หน้าแบบ Fixed-layout หรือภาพหลายหน้า | การดู, การพิมพ์, และการจัดเก็บ |
| PNG, JPEG หรือ SVG | การเรนเดอร์สไลด์แต่ละสไลด์ | รูปภาพย่อย, ตัวอย่าง, และสินทรัพย์ภาพ |
| HTML หรือ HTML5 | ผลลัพธ์งานนำเสนอสำหรับเว็บ | การดูในเบราว์เซอร์และการเผยแพร่บนเว็บ |

ต่างจาก PPT และ PPTX, การส่งออกเป็น XML มีจุดประสงค์หลักเพื่อการตรวจสอบและกระบวนการทำงานที่มุ่งข้อมูล อย่างต่างจาก PDF, TIFF, HTML, และรูปแบบภาพสไลด์, XML แสดงข้อมูลงานนำเสนอแทนการเรนเดอร์สไลด์เป็นหน้า หรือสินทรัพย์ภาพ ตาราง [supported file formats](/slides/th/java/supported-file-formats/) ระบุ PowerPoint XML Presentation เป็นรูปแบบที่บันทึกได้เท่านั้น ดังนั้นไม่ควรใช้เมื่อต้องการให้กระบวนการทำงานโหลดไฟล์ที่ส่งออกกลับไปยัง Aspose.Slides เพื่อทำการแก้ไขต่อ

## **FAQ**

**`SaveFormat.Xml` เหมือนกับการบันทึกไฟล์ PPTX หรือไม่?**  
ไม่. PPTX คือแพ็กเกจที่ประกอบด้วยหลายส่วนของ Office Open XML ในขณะที่ `SaveFormat.Xml` สร้างไฟล์ PowerPoint XML Presentation

**ฉันสามารถบันทึกผลลัพธ์ XML โดยไม่สร้างไฟล์บนดิสก์ได้หรือไม่?**  
ได้. ส่งสตรีมที่เขียนได้ให้กับ [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). ตัวอย่างเช่น ใช้ [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) สำหรับการประมวลผลในหน่วยความจำ

**Aspose.Slides สามารถโหลดไฟล์ XML ที่ส่งออกได้อีกหรือไม่?**  
ไม่. ปัจจุบัน PowerPoint XML Presentation รองรับการบันทึกเท่านั้น ไม่รองรับการโหลด ใช้ PPTX หรือรูปแบบงานนำเสนอที่รองรับอื่นเมื่อจำเป็นต้องทำการแก้ไขแบบรอบกลับ

**การแปลงเป็น XML ทำการเรนเดอร์สไลด์แต่ละสไลด์เป็นหน้า หรือภาพหรือไม่?**  
ไม่. การแปลงเป็น XML จะเขียนข้อมูลงานนำเสนอที่มีโครงสร้าง ใช้ PDF หรือ TIFF สำหรับผลลัพธ์แบบหน้า หรือใช้ PNG, JPEG และ SVG สำหรับภาพสไลด์แต่ละสไลด์