---
title: แปลง PPT เป็น PPTX ด้วย Java
linktitle: PPT เป็น PPTX
type: docs
weight: 20
url: /th/java/convert-ppt-to-pptx/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- PPT เป็น PPTX
- บันทึก PPT เป็น PPTX
- ส่งออก PPT เป็น PPTX
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT เก่าเป็น PPTX ด้วย Java และ Aspose.Slides. รวมตัวอย่าง Java สำหรับการแปลงไฟล์เดี่ยวและแบบแบตช์, การจัดการข้อผิดพลาด, และหมายเหตุความแม่นยำ."
---
## **ภาพรวม**

PPT คือรูปแบบไบนารีแบบเก่าของ PowerPoint ในขณะที่ PPTX เป็นรูปแบบ Open XML ที่ใหม่กว่า Aspose.Slides for Java สามารถโหลดไฟล์ PPT และบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือไดเรกทอรีของไฟล์และอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นทางด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) จากนั้นเรียกใช้ [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) พร้อมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/#Pptx) บล็อก `finally` จะทำลายวัตถุ presentation และปล่อยทรัพยากรของมัน

```java
// โหลดการนำเสนอ PPT แบบเก่า.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // บันทึกการนำเสนอในรูปแบบ PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

นามสกุลไฟล์ไม่ได้เลือกรูปแบบผลลัพธ์โดยตรง; อาร์กิวเมนต์ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/#Pptx) ทำหน้าที่นั้น หากต้องการเก็บไฟล์ PPT ดั้งเดิมให้ทำให้เส้นทางอินพุตและเอาต์พุตแตกต่างกัน

## **แปลงไฟล์ PPT หลายไฟล์**

ตัวอย่างต่อไปนี้จะแปลงไฟล์ `.ppt` ทุกไฟล์ในไดเรกทอรีหนึ่ง แต่ละไฟล์จะถูกประมวลผลแยกกัน ดังนั้นการแปลงที่ล้มเหลวหนึ่งไฟล์จะไม่ทำให้ชุดการประมวลผลทั้งหมดหยุดทำงาน

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

สำหรับการทำงานในสภาพการผลิต ควรบันทึกข้อยกเว้นอย่างเต็มที่ กำหนดว่าควรเขียนทับไฟล์ผลลัพธ์ที่มีอยู่หรือไม่ และเขียนชื่อไฟล์ที่ล้มเหลวลงในคิวสำหรับลองใหม่หรือรีวิว ไฟล์ที่เสีย, ไฟล์ที่มีการป้องกันด้วยรหัสผ่านแต่เปิดโดยไม่มีรหัสที่ถูกต้อง, เส้นทางที่เข้าถึงไม่ได้, และเนื้อหาที่ไม่รองรับทั้งหมดสามารถทำให้การแปลงล้มเหลวได้ ดูที่ [Password-Protected Presentations](/slides/th/java/password-protected-presentation/) เพื่อโหลดไฟล์ที่เข้ารหัส

## **ความแม่นยำและฟีเจอร์เดิม**

การแปลงโดยทั่วไปจะรักษาสไลด์, มาสเตอร์, เลเอาท์, ข้อความ, รูปร่าง, รูปภาพ, ตาราง, และแผนภูมิไว้ แต่ PPT และ PPTX ไม่ได้แสดงคุณลักษณะทุกอย่างในรูปแบบที่เหมือนกัน ฟีเจอร์เดิมที่ไม่มีเทียบเท่าใน PPTX หรือที่ไลบรารีไม่รองรับอาจถูกทำให้เป็นมาตรฐาน, ถูกละเว้น, หรือแสดงแตกต่างออกไป

ตรวจสอบไฟล์ที่แปลงแล้วเมื่อมีอนิเมชัน, การเปลี่ยนสไลด์, วัตถุ OLE ที่ฝังหรือเชื่อมโยง, คอนโทรล ActiveX, สื่อที่ฝังอยู่, ฟอนต์ที่ไม่ทั่วไป, หรือมาโคร VBA ไฟล์ PPTX ธรรมดาไม่ใช่รูปแบบที่เปิดใช้งานมาโคร ดังนั้นให้ใช้กระบวนการทำงานที่รองรับมาโครเมื่อจำเป็นต้องใช้ VBA อีกด้วย ตรวจสอบให้แน่ใจว่าฟอนต์ที่ต้องการและทรัพยากรภายนอกมีอยู่ในสภาพแวดล้อมที่นำเสนอที่แปลงแล้วจะถูกเปิดหรือเรนเดอร์

สำหรับเอกสารสำคัญ ให้เปิดไฟล์ PPTX ที่สร้างขึ้นใหม่โดยโปรแกรมและตรวจสอบจำนวนสไลด์และเนื้อหาหลัก แล้วเปรียบเทียบลักษณะการแสดงผลและพฤติกรรมการสไลด์โชว์ในผู้ชมที่ต้องการ อย่าพิจารณาการเรียกใช้ [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่สำเร็จเป็นหลักฐานว่าฟีเจอร์เดิมทุกอย่างมีการแสดงผลเป็น PPTX อย่างแม่นยำ

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน, แลกเปลี่ยนกับระบบที่ทำงานกับแพ็คเกจ Open XML, หรือจัดเก็บในรูปแบบที่ตรวจสอบและกู้คืนได้ง่ายกว่ารูปแบบไบนารี PPT เก่า เก็บไฟล์ PPT ดั้งเดิมเป็นสำเนาเพื่อการเก็บรักษาหรือการย้อนกลับจนกว่าการแปลงจะผ่านการตรวจสอบความแม่นยำของคุณ

หากต้องการ PDF, HTML, รูปภาพ, XPS หรือรูปแบบผลลัพธ์อื่น ๆ ให้ใช้คำแนะนำเฉพาะรูปแบบใน [Convert Presentations to Multiple Formats](/slides/th/java/convert-presentation/) แทนการสันนิษฐานว่าปลายทางทั้งหมดจะรักษาฟีเจอร์ PowerPoint ที่แก้ไขได้

## **ตัวแปลงออนไลน์**

สำหรับไฟล์เป็นครั้งคราวหรือการเปรียบเทียบอย่างเร็ว คุณสามารถใช้ [online PPT to PPTX converter](https://products.aspose.app/slides/th/conversion/ppt-to-pptx) ได้ สำหรับการแปลงที่ทำซ้ำ, การประมวลผลเป็นชุด, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน ให้ใช้ Java API

## **บทความที่เกี่ยวข้อง**

- [PPT vs PPTX](/slides/th/java/ppt-vs-pptx/)
- [Save Presentations in Java](/slides/th/java/save-presentation/)
- [Supported File Formats](/slides/th/java/supported-file-formats/)
- [Open Presentations in Java](/slides/th/java/open-presentation/)

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลง PPT เป็น PPTX ได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ได้เลย Aspose.Slides for Java โหลดและบันทึกไฟล์การนำเสนอได้โดยไม่ต้องใช้ Microsoft PowerPoint

**การแปลงจาก PPT เป็น PPTX จะรักษาเนื้อหาทั้งหมดอย่างแม่นยำหรือไม่?**

มันจะรักษาเนื้อหาการนำเสนอทั่วไปไว้ได้ แต่ความแม่นยำแบบเต็มที่ไม่รับประกันสำหรับทุกฟีเจอร์เดิมหรือฟีเจอร์ที่ไม่รองรับ ตรวจสอบไฟล์ที่สร้างขึ้นเมื่อมีมาโคร, วัตถุ OLE หรือ ActiveX, สื่อ, การเคลื่อนไหวเฉพาะ, หรือฟอนต์ที่ไม่ทั่วไป

**ฉันสามารถแปลงไฟล์ PPT ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้ หากคุณใส่รหัสผ่านที่ถูกต้องเมื่อโหลดไฟล์ การไม่มีรหัสผ่านหรือรหัสผ่านไม่ถูกต้องจะทำให้การโหลดล้มเหลว

**ฉันควรลบไฟล์ PPT หลังการแปลงหรือไม่?**

ให้เก็บไฟล์ต้นฉบับไว้จนกว่าคุณจะตรวจสอบ PPTX ในผู้ชมและกระบวนการทำงานที่สำคัญสำหรับคุณ การทำเช่นนี้จะมีสำเนาสำรองหากฟีเจอร์เดิมแปลงต่างออกไป