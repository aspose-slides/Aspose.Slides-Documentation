---
title: แปลง PPT เป็น PPTX บน Android
linktitle: PPT เป็น PPTX
type: docs
weight: 20
url: /th/androidjava/convert-ppt-to-pptx/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- PPT เป็น PPTX
- บันทึก PPT เป็น PPTX
- ส่งออก PPT ไปเป็น PPTX
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT รุ่นเก่าเป็น PPTX บน Android ด้วย Aspose.Slides. รวมตัวอย่าง Java สำหรับการแปลงไฟล์เดี่ยวและแบบชุด, การจัดการข้อผิดพลาด, และหมายเหตุความแม่นยำ."
---
## **ภาพรวม**

PPT คือรูปแบบไบนารี PowerPoint รุ่นเก่า ในขณะที่ PPTX คือรูปแบบ Open XML เวอร์ชันใหม่ Aspose.Slides for Android ผ่าน Java สามารถโหลดไฟล์ PPT และบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint บทความนี้แสดงวิธีแปลงไฟล์หนึ่งไฟล์หรือไดเรกทอรีของไฟล์และอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) จากนั้นเรียก [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) พร้อมพารามิเตอร์ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/#Pptx) บล็อก `finally` จะทำการปล่อย Presentation และคืนทรัพยากรของมัน

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

นามสกุลไฟล์ไม่ได้เลือกรูปแบบผลลัพธ์โดยอัตโนมัติ; อาร์กิวเมนต์ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/#Pptx) ทำหน้าที่นั้น หากต้องการเก็บไฟล์ PPT ดั้งเดิมไว้ให้ใช้เส้นทางอินพุตและเอาต์พุตที่ต่างกัน

## **แปลงไฟล์ PPT หลายไฟล์**

ตัวอย่างต่อไปนี้จะแปลงไฟล์ `.ppt` ทุกไฟล์ในไดเรกทอรีหนึ่ง โดยแต่ละไฟล์จะถูกประมวลผลอย่างอิสระ ดังนั้นการแปลงที่ล้มเหลวหนึ่งไฟล์จะไม่ทำให้ชุดการแปลงทั้งหมดหยุดทำงาน

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

สำหรับงานในระดับการผลิต ควรบันทึกข้อยกเว้นทั้งหมด, ตัดสินใจว่าจะเขียนทับไฟล์ผลลัพธ์ที่มีอยู่หรือไม่, และบันทึกชื่อไฟล์ที่ล้มเหลวลงในคิว retry หรือ review ไฟล์ที่เสียหาย, ไฟล์ที่มีการป้องกันด้วยรหัสผ่านแต่เปิดโดยไม่มีรหัสที่ถูกต้อง, เส้นทางที่ไม่สามารถเข้าถึงได้, และเนื้อหาที่ไม่รองรับทั้งหมดสามารถทำให้การแปลงล้มเหลวได้ ดูที่ [Password-Protected Presentations](/androidjava/password-protected-presentation/) เพื่อโหลดไฟล์ที่เข้ารหัส

## **ความแม่นยำและฟีเจอร์รุ่นเก่า**

การแปลงโดยทั่วไปจะคงสไลด์, มาสเตอร์, เลเอาต์, ข้อความ, รูปร่าง, รูปภาพ, ตาราง และแผนภูมิไว้ อย่างไรก็ตาม PPT และ PPTX ไม่ได้แสดงคุณลักษณะทั้งหมดในลักษณะเดียวกัน ฟีเจอร์รุ่นเก่าที่ไม่มีเทียบเท่าใน PPTX หรือที่ไลบรารีไม่รองรับอาจถูกทำให้เป็นมาตรฐาน, ถูกละเลย หรือแสดงต่างออกไป

ให้ตรวจสอบไฟล์ที่แปลงเมื่อมีแอนิเมชัน, การเปลี่ยนฉาก, วัตถุ OLE ที่ฝังหรือลิงก์, คอนโทรล ActiveX, สื่อที่ฝัง, ฟอนต์ที่ไม่ทั่วไป, หรือแมโคร VBA ไฟล์ PPTX ปกติไม่รองรับแมโคร ดังนั้นควรใช้กระบวนการทำงานที่รองรับแมโครเมื่อจำเป็นต้องใช้ VBA อย่าลืมตรวจสอบว่าฟอนต์ที่ต้องการและทรัพยากรภายนอกมีอยู่ในสภาพแวดล้อมที่ไฟล์นำเสนอที่แปลงแล้วจะถูกเปิดหรือแสดงผล

สำหรับเอกสารสำคัญ ให้เปิดไฟล์ PPTX ที่สร้างขึ้นใหม่โดยโปรแกรมและตรวจสอบจำนวนสไลด์และเนื้อหาที่สำคัญ จากนั้นเปรียบเทียบลักษณะการแสดงผลและพฤติกรรมสไลด์โชว์ในโปรแกรมผู้ชมที่ต้องการ อย่าใช้การเรียก [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่สำเร็จเป็นหลักฐานว่าฟีเจอร์รุ่นเก่าทุกอย่างมีการแสดงผลใน PPTX อย่างแม่นยำ

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขใน PowerPoint เวอร์ชันปัจจุบัน, แลกเปลี่ยนกับระบบที่ทำงานกับแพ็คเกจ Open XML, หรือเก็บเป็นรูปแบบที่ตรวจสอบและกู้คืนได้ง่ายกว่าบินารี PPT รุ่นเก่า ให้เก็บไฟล์ PPT ดั้งเดิมเป็นสำเนาสำรองหรือสำเนาเพื่อการกู้คืนจนกว่าการแปลงจะผ่านการตรวจสอบความแม่นยำของคุณ

หากต้องการ PDF, HTML, รูปภาพ, XPS หรือรูปแบบผลลัพธ์อื่น ให้ใช้คำแนะนำเฉพาะรูปแบบที่อยู่ใน [Convert Presentations to Multiple Formats](/slides/th/androidjava/convert-presentation/) แทนการสมมติว่าทุกเป้าหมายจะคงฟีเจอร์ PowerPoint ที่แก้ไขได้

## **เครื่องแปลงออนไลน์**

สำหรับไฟล์ที่ใช้เป็นครั้งคราวหรือการเปรียบเทียบอย่างรวดเร็ว คุณสามารถใช้ [online PPT to PPTX converter](https://products.aspose.app/slides/th/conversion/ppt-to-pptx) ได้ สำหรับการแปลงที่ทำซ้ำได้, การประมวลผลเป็นชุด, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน ให้ใช้ Android ผ่าน Java API

## **บทความที่เกี่ยวข้อง**

- [PPT vs PPTX](/slides/th/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/slides/th/androidjava/save-presentation/)
- [Supported File Formats](/slides/th/androidjava/supported-file-formats/)
- [Open Presentations on Android](/slides/th/androidjava/open-presentation/)

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลง PPT เป็น PPTX ได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ใช่ Aspose.Slides for Android ผ่าน Java สามารถโหลดและบันทึกไฟล์นำเสนอได้โดยไม่ต้องใช้ Microsoft PowerPoint

**การแปลงจาก PPT เป็น PPTX จะคงเนื้อหาทั้งหมดอย่างแม่นยำหรือไม่?**

มันคงเนื้อหาการนำเสนอทั่วไปไว้ แต่ความแม่นยำเต็มที่ไม่รับประกันสำหรับฟีเจอร์รุ่นเก่าหรือที่ไม่รองรับทั้งหมด ตรวจสอบไฟล์ที่สร้างเมื่อมีแมโคร, วัตถุ OLE หรือ ActiveX, สื่อ, แอนิเมชันพิเศษ หรือฟอนต์ที่ไม่ทั่วไป

**ฉันสามารถแปลงไฟล์ PPT ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่ หากคุณให้รหัสผ่านที่ถูกต้องเมื่อโหลดไฟล์ การไม่มีหรือรหัสผ่านไม่ถูกต้องจะทำให้การโหลดล้มเหลว

**ควรลบไฟล์ PPT หลังจากการแปลงหรือไม่?**

ให้เก็บไฟล์ต้นฉบับไว้จนกว่าคุณจะตรวจสอบ PPTX ในโปรแกรมผู้ชมและกระบวนการทำงานที่สำคัญสำหรับคุณ ซึ่งจะเป็นสำเนาสำรองหากฟีเจอร์รุ่นเก่าถูกแปลงต่างออกไป