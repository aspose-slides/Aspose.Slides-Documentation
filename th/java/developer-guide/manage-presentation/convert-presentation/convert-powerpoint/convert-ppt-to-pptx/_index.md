---
title: แปลง PPT เป็น PPTX ใน Java
linktitle: PPT ไป PPTX
type: docs
weight: 20
url: /th/java/convert-ppt-to-pptx/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- PPT ไป PPTX
- บันทึก PPT เป็น PPTX
- ส่งออก PPT เป็น PPTX
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT รุ่นเก่าเป็น PPTX ใน Java ด้วย Aspose.Slides รวมตัวอย่าง Java สำหรับการแปลงไฟล์เดี่ยวและแบบชุด การจัดการข้อผิดพลาด และหมายเหตุเกี่ยวกับความแม่นยำ"
---
## **ภาพรวม**

PPT คือรูปแบบไฟล์ไบนารีดั้งเดิมของ PowerPoint ในขณะที่ PPTX เป็นรูปแบบ Open XML ที่ใหม่กว่า Aspose.Slides for Java สามารถโหลดไฟล์ PPT และบันทึกเป็น PPTX โดยไม่ต้องใช้ Microsoft PowerPoint บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือไดเรกทอรีของไฟล์และอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) แล้วเรียกใช้ [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) พร้อมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/#Pptx) บล็อก `finally` จะทำการกำจัดการนำเสนอและปล่อยทรัพยากรของมันออก

```java
// โหลดงานนำเสนอ PPT รุ่นเก่า.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // บันทึกงานนำเสนอในรูปแบบ PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ส่วนขยายไฟล์ไม่ได้เลือกรูปแบบการส่งออกด้วยตนเอง; อาร์กิวเมนต์ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/#Pptx) ทำหน้าที่นั้น หากต้องการเก็บไฟล์ PPT ต้นฉบับไว้ ให้ทำให้เส้นทางอินพุตและเอาต์พุตต่างกัน

## **แปลงหลายไฟล์ PPT**

ตัวอย่างต่อไปนี้จะแปลงไฟล์ `.ppt` ทุกไฟล์ในไดเรกทอรีหนึ่งแต่ละไฟล์จะถูกประมวลผลแยกกัน ดังนั้นการแปลงที่ล้มเหลวหนึ่งไฟล์จะไม่หยุดการทำงานของชุดอื่น

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

สำหรับงานในระดับการผลิต ควรบันทึกข้อยกเว้นเต็มรูปแบบ ตัดสินใจว่าจะให้อัปเดตไฟล์เอาต์พุตที่มีอยู่หรือไม่ และเขียนชื่อไฟล์ที่ล้มเหลวลงในคิวเพื่อพยายามใหม่หรือรีวิว ไฟล์เสีย, ไฟล์ที่ป้องกันด้วยรหัสผ่านที่เปิดโดยไม่ได้ใส่รหัสที่ต้องการ, เส้นทางที่เข้าถึงไม่ได้, และเนื้อหาที่ไม่รองรับทั้งหมดอาจทำให้การแปลงล้มเหลว ดูที่ [Password-Protected Presentations](/java/password-protected-presentation/) สำหรับการโหลดไฟล์ที่เข้ารหัส

## **ความแม่นยำและคุณลักษณะดั้งเดิม**

โดยทั่วไปการแปลงจะคงสไลด์, มาสเตอร์, เลเอาต์, ข้อความ, รูปร่าง, ภาพ, ตาราง และแผนภูมิไว้ แต่ PPT และ PPTX ไม่ได้แสดงคุณลักษณะทุกอย่างในแบบเดียวกันอย่างสมบูรณ์ คุณลักษณะดั้งเดิมที่ไม่มีเทียบเท่าใน PPTX หรือไม่รองรับโดยไลบรารีอาจถูกทำให้เป็นมาตรฐาน, ละเว้น, หรือแสดงในรูปแบบที่ต่างออกไป

ให้ตรวจสอบไฟล์ที่แปลงแล้วเมื่อมีการใช้แอนิเมชัน, การเปลี่ยนภาพ, วัตถุ OLE ฝังหรือเชื่อมโยง, คอนโทรล ActiveX, สื่อฝัง, ฟอนต์ที่ไม่ทั่วไป, หรือแมโคร VBA ไฟล์ PPTX ธรรมดาไม่ใช่รูปแบบที่เปิดใช้แมโครได้ ดังนั้นให้ใช้กระบวนการทำงานที่รองรับแมโครเมื่อต้องการให้ VBA ยังใช้งานได้ นอกจากนี้ควรตรวจสอบว่าฟอนต์ที่จำเป็นและทรัพยากรภายนอกมีอยู่ในสภาพแวดล้อมที่นำเสนอแปลงจะถูกเปิดหรือเรนเดอร์

สำหรับเอกสารสำคัญ ควรเปิดไฟล์ PPTX ที่สร้างขึ้นโดยโปรแกรมและตรวจสอบจำนวนสไลด์หลักและเนื้อหา จากนั้นเปรียบเทียบลักษณะการแสดงผลและพฤติกรรมสไลด์โชว์ในโปรแกรมที่ตั้งใจใช้ อย่านับการเรียกใช้ [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่สำเร็จเป็นหลักฐานว่าแต่ละคุณลักษณะดั้งเดิมมีการแทนที่ใน PPTX อย่างแม่นยำ

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอต้องการแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน, แลกเปลี่ยนกับระบบที่ทำงานกับแพคเกจ Open XML, หรือเก็บในรูปแบบที่ตรวจสอบและกู้คืนได้ง่ายกว่ารูปแบบไบนารีเก่า ควรเก็บไฟล์ PPT ดั้งเดิมไว้เป็นสำเนาเพื่อการสำรองหรือย้อนกลับจนกว่าการแปลงจะผ่านการตรวจสอบความแม่นยำของคุณ

หากต้องการ PDF, HTML, รูปภาพ, XPS หรือรูปแบบเอาต์พุตอื่น ให้ใช้คำแนะนำเฉพาะรูปแบบใน [Convert Presentations to Multiple Formats](/java/convert-presentation/) แทนการสันนิษฐานว่าปลายทางทั้งหมดจะคงคุณลักษณะ PowerPoint ที่แก้ไขได้

## **ตัวแปลงออนไลน์**

สำหรับไฟล์ที่ต้องการแปลงเป็นครั้งคราวหรือการเปรียบเทียบอย่างรวดเร็ว สามารถใช้ [online PPT to PPTX converter](https://products.aspose.app/slides/th/conversion/ppt-to-pptx) ได้ สำหรับการแปลงที่ต้องทำซ้ำ, การประมวลผลเป็นชุด, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน ควรใช้ Java API

## **บทความที่เกี่ยวข้อง**

- [PPT กับ PPTX](/java/ppt-vs-pptx/)
- [บันทึกการนำเสนอใน Java](/java/save-presentation/)
- [รูปแบบไฟล์ที่รองรับ](/java/supported-file-formats/)
- [เปิดการนำเสนอใน Java](/java/open-presentation/)

## **FAQ**

**ฉันสามารถแปลง PPT เป็น PPTX ได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint ไหม?**

ใช่ Aspose.Slides for Java สามารถโหลดและบันทึกไฟล์การนำเสนอได้โดยไม่ต้องใช้ Microsoft PowerPoint

**การแปลงจาก PPT ไปเป็น PPTX จะคงเนื้อหาทั้งหมดอย่างแม่นยำหรือไม่?**

การแปลงจะคงเนื้อหาการนำเสนอทั่วไปไว้ แต่ความแม่นยำอย่างสมบูรณ์ไม่รับประกันสำหรับทุกคุณลักษณะดั้งเดิมหรือคุณลักษณะที่ไม่รองรับ ควรตรวจสอบไฟล์ที่สร้างเมื่อมีแมโคร, วัตถุ OLE หรือ ActiveX, สื่อ, แอนิเมชันพิเศษ, หรือฟอนต์ที่ไม่ทั่วไป

**ฉันสามารถแปลงไฟล์ PPT ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่ หากคุณใส่รหัสผ่านที่ถูกต้องเมื่อโหลดไฟล์ รหัสผ่านที่หายไปหรือไม่ถูกต้องจะทำให้การโหลดล้มเหลว

**ควรลบไฟล์ PPT หลังจากแปลงหรือไม่?**

ให้เก็บไฟล์ต้นฉบับไว้จนกว่าคุณจะตรวจสอบ PPTX ในโปรแกรมดูและกระบวนการทำงานที่สำคัญสำหรับคุณ วิธีนี้เป็นสำเนาสำรองหากคุณลักษณะดั้งเดิมแปลงออกมาแตกต่างกัน