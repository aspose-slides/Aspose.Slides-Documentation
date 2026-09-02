---
title: แปลงงานนำเสนอ PowerPoint เป็น XML บน Android
linktitle: PowerPoint เป็น XML
type: docs
weight: 145
url: /th/androidjava/convert-powerpoint-to-xml/
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
- Android
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีม PowerPoint XML บน Android ด้วย Aspose.Slides."
---
## **Overview**

Aspose.Slides for Android via Java สามารถแปลงงานนำเสนอ PowerPoint ไปเป็นรูปแบบ PowerPoint XML Presentation ได้. ผลลัพธ์ XML มีประโยชน์เมื่อคุณต้องการตัวแทนข้อความสำหรับการตรวจสอบโครงสร้างงานนำเสนอ, การแก้ไขปัญหาเอกสารที่สร้าง, การเปรียบเทียบผลลัพธ์ในการทดสอบอัตโนมัติ, หรือการรวมเข้ากับกระบวนการทำงานที่ใช้ XML แทนแพ็คเกจงานนำเสนอ.

ใช้เมธ็อด [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) กับ [SaveFormat.Xml](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/#Xml). คุณสามารถเขียนผลลัพธ์โดยตรงไปยังไฟล์หรือสตรีมได้.

{{% alert color="info" title="หมายเหตุ" %}}

`SaveFormat.Xml` creates a PowerPoint XML Presentation. It does not extract the individual Office Open XML parts stored inside a PPTX package. If you need the exact PPTX package parts, such as `ppt/presentation.xml` or individual slide XML files, inspect the PPTX package itself.

{{% /alert %}}

## **แปลงงานนำเสนอเป็นไฟล์ XML**

โหลดงานนำเสนอต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วส่งพาธผลลัพธ์และ [SaveFormat.Xml](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/#Xml) ไปยัง [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). แหล่งที่มาสามารถเป็นรูปแบบงานนำเสนอใดก็ได้ที่รองรับการโหลด, เช่น PPT, PPTX หรือ ODP.

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

ใช้เมธ็อด overload ของ [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) เมื่อ XML ต้องคงอยู่ในหน่วยความจำหรือส่งต่อไปยังส่วนประกอบอื่น, เช่น เว็บเซอร์วิส, ผู้ให้บริการจัดเก็บ, หรือท่อประมวลผล XML. ตัวอย่างต่อไปนี้เขียนผลลัพธ์ไปยัง [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) และรับ XML ที่สร้างเป็นอาร์เรย์ไบต์:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // ส่ง xmlData ไปยังส่วนประกอบต่อไปในกระบวนการทำงาน.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **เปรียบเทียบ XML กับรูปแบบงานนำเสนอและการส่งออก**

เลือกรูปแบบผลลัพธ์ตามวิธีการที่จะนำไปใช้:

| รูปแบบ | ผลลัพธ์ | การใช้ทั่วไป |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | ตรวจสอบโครงสร้าง, แก้ไขปัญหา, เปรียบเทียบผลลัพธ์ที่สร้าง, และการรวมแบบ XML |
| PPT (`.ppt`) | ไฟล์งานนำเสนอแบบไบนารีเก่า | ความเข้ากันได้กับกระบวนการทำงาน PowerPoint รุ่นเก่า |
| PPTX (`.pptx`) | แพ็คเกจ Office Open XML ที่มีหลายส่วน | การแก้ไข PowerPoint ปกติและการแลกเปลี่ยนงานนำเสนอ |
| PDF or TIFF | หน้าแบบจัดรูปแบบคงที่หรือภาพหลายหน้า | การดู, การพิมพ์, และการเก็บถาวร |
| PNG, JPEG, or SVG | การแสดงผลของสไลด์เดี่ยว | ภาพย่อ, ตัวอย่างและทรัพยากรภาพ |
| HTML or HTML5 | ผลลัพธ์งานนำเสนอแบบเว็บ | การดูในเบราว์เซอร์และการเผยแพร่บนเว็บ |

ต่างจาก PPT และ PPTX, ผลลัพธ์ XML มีจุดประสงค์หลักเพื่อการตรวจสอบและกระบวนการทำงานเชิงข้อมูล. ต่างจาก PDF, TIFF, HTML และรูปแบบภาพสไลด์, มันแสดงข้อมูลงานนำเสนอแทนการเรนเดอร์สไลด์เป็นหน้า หรือทรัพยากรภาพ. ตาราง [supported file formats](/slides/th/androidjava/supported-file-formats/) ระบุว่า PowerPoint XML Presentation เป็นรูปแบบที่บันทึกได้เท่านั้น, จึงไม่ควรใช้เมื่อกระบวนการทำงานต้องโหลดไฟล์ที่ส่งออกกลับเข้าสู่ Aspose.Slides เพื่อการแก้ไขต่อ.

## **FAQ**

**`SaveFormat.Xml` คือการบันทึกไฟล์ PPTX หรือไม่?**  
ไม่. PPTX เป็นแพ็คเกจที่ประกอบด้วยหลายส่วนของ Office Open XML, ส่วน `SaveFormat.Xml` สร้างไฟล์ PowerPoint XML Presentation เท่านั้น.

**ฉันสามารถบันทึกผลลัพธ์ XML โดยไม่สร้างไฟล์บนดิสก์ได้หรือไม่?**  
ได้. ส่งสตรีมที่เขียนได้ไปยัง [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). ตัวอย่างเช่น ใช้ [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) สำหรับการประมวลผลในหน่วยความจำ.

**Aspose.Slides สามารถโหลดไฟล์ XML ที่ส่งออกนี้อีกครั้งได้หรือไม่?**  
ไม่ได้. PowerPoint XML Presentation ปัจจุบันรองรับการบันทึกเท่านั้น, ไม่รองรับการโหลด. ใช้ PPTX หรือรูปแบบงานนำเสนอที่รองรับอื่นเมื่อจำเป็นต้องแก้ไขแบบรอบ.

**การแปลงเป็น XML จะเรนเดอร์แต่ละสไลด์เป็นหน้า หรือภาพหรือไม่?**  
ไม่. การแปลงเป็น XML จะเขียนข้อมูลงานนำเสนอในรูปแบบโครงสร้าง. ใช้ PDF หรือ TIFF เพื่อผลลัพธ์เป็นหน้า, หรือ PNG, JPEG, และ SVG สำหรับภาพสไลด์เดี่ยว.