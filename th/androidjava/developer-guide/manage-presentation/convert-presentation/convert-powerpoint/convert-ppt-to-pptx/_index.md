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
- ส่งออก PPT เป็น PPTX
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT เก่าเป็น PPTX บน Android ด้วย Aspose.Slides. รวมตัวอย่าง Java สำหรับการแปลงไฟล์เดี่ยวและแบบแบช, การจัดการข้อผิดพลาด, และบันทึกความแม่นยำ."
---
## **ภาพรวม**

PPT เป็นรูปแบบ PowerPoint แบบไบนารีเก่าในขณะที่ PPTX เป็นรูปแบบ Open XML ที่ใหม่กว่า Aspose.Slides สำหรับ Android ผ่าน Java สามารถโหลดไฟล์ PPT และบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือหลายไฟล์ในไดเรกทอรีและอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นทางด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วเรียก [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/#Pptx) บล็อก `finally` จะทำการกำจัดการนำเสนอและปล่อยทรัพยากรของมัน

```java
// โหลดการนำเสนอ PPT แบบเก่า.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // บันทึกการนำเสนอเป็นรูปแบบ PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

นามสกุลไฟล์ไม่กำหนดรูปแบบเอาต์พุตด้วยตนเอง; อาร์กิวเมนต์ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/#Pptx) ทำหน้าที่นั้น ใช้เส้นทางอินพุตและเอาต์พุตที่ต่างกันหากต้องการเก็บไฟล์ PPT ดั้งเดิมไว้

## **แปลงหลายไฟล์ PPT**

ตัวอย่างต่อไปนี้จะแปลงไฟล์ `.ppt` ทุกไฟล์ในไดเรกทอรีหนึ่ง แต่ละไฟล์จะถูกประมวลผลแยกกัน ดังนั้นการแปลงที่ล้มเหลวหนึ่งไฟล์จะไม่ทำให้แบชที่เหลือติดขัด

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

สำหรับการใช้งานระดับการผลิต ควรบันทึกข้อยกเว้นทั้งหมด, ตัดสินใจว่าจะแทนที่ไฟล์เอาต์พุตที่มีอยู่หรือไม่, และเขียนชื่อไฟล์ที่ล้มเหลวไปยังคิวสำหรับลองใหม่หรือรีวิว ไฟล์เสีย, ไฟล์ที่มีการป้องกันด้วยรหัสผ่านแต่เปิดโดยไม่มีรหัสที่ต้องการ, เส้นทางที่เข้าถึงไม่ได้, และเนื้อหาที่ไม่รองรับทั้งหมดอาจทำให้การแปลงล้มเหลว ดูที่ [การนำเสนอที่ป้องกันด้วยรหัสผ่าน](/androidjava/password-protected-presentation/) สำหรับการโหลดไฟล์ที่เข้ารหัส

## **ความแม่นยำและคุณลักษณะเก่า**

การแปลงโดยทั่วไปจะคงสไลด์, มาสเตอร์, เลย์เอาต์, ข้อความ, รูปร่าง, ภาพ, ตาราง, และแผนภูมิไว้ อย่างไรก็ตาม PPT และ PPTX ไม่ได้แสดงคุณลักษณะทั้งหมดในลักษณะเดียวกันอย่างครบถ้วน คุณลักษณะเก่าที่ไม่มีเทียบเท่าใน PPTX หรือที่ไลบรารีไม่สนับสนุนอาจถูกทำให้เป็นมาตรฐาน, ลบออก, หรือแสดงแตกต่างกัน

ตรวจสอบไฟล์ที่แปลงแล้วเมื่อมีแอนิเมชัน, การเปลี่ยนฉาก, วัตถุ OLE ฝังหรือเชื่อมโยง, ควบคุม ActiveX, สื่อฝัง, ฟอนต์ที่ไม่ทั่วไป, หรือมาโคร VBA ไฟล์ PPTX ปกติไม่ใช่รูปแบบที่รองรับมาโคร ดังนั้นควรใช้กระบวนการทำงานที่รองรับมาโครเมื่อจำเป็นต้องใช้ VBA พร้อมกันนี้ให้ตรวจสอบว่าฟอนต์ที่ต้องการและทรัพยากรภายนอกมีอยู่ในสภาพแวดล้อมที่การนำเสนอที่แปลงจะถูกเปิดหรือเรนเดอร์

สำหรับเอกสารสำคัญ ควรเปิดไฟล์ PPTX ที่สร้างขึ้นใหม่ด้วยโค้ดและตรวจสอบจำนวนสไลด์และเนื้อหาที่สำคัญ จากนั้นเปรียบเทียบรูปลักษณ์และพฤติกรรมของการแสดงสไลด์ในตัวดูที่ต้องการ อย่ามองว่าการเรียก [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่สำเร็จเป็นหลักฐานว่าทุกคุณลักษณะเก่ามีการแสดงผลใน PPTX อย่างแม่นยำ

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน, แลกเปลี่ยนกับระบบที่ทำงานกับแพ็กเกจ Open XML, หรือเก็บในรูปแบบที่ตรวจสอบและกู้คืนได้ง่ายกว่าการใช้ไฟล์ไบนารี PPT เก่า เก็บไฟล์ PPT ดั้งเดิมเป็นสำเนาเพื่อการจัดเก็บหรือการคืนค่าเป็นสำรองจนกว่าการแปลงจะผ่านการตรวจสอบความแม่นยำของคุณ

หากต้องการ PDF, HTML, รูปภาพ, XPS หรือรูปแบบเอาต์พุตอื่นแทน ให้ใช้คำแนะนำตามรูปแบบใน [แปลงการนำเสนอเป็นหลายรูปแบบ](/androidjava/convert-presentation/) แทนที่จะสันนิษฐานว่าปลายทางทั้งหมดจะคงคุณลักษณะ PowerPoint ที่แก้ไขได้

## **ตัวแปลงออนไลน์**

สำหรับไฟล์เป็นครั้งคราวหรือการเปรียบเทียบอย่างเร็ว คุณสามารถใช้ [online PPT to PPTX converter](https://products.aspose.app/slides/th/conversion/ppt-to-pptx) สำหรับการแปลงที่ทำซ้ำ, การประมวลผลแบบแบช, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน ให้ใช้ Android via Java API

## **บทความที่เกี่ยวข้อง**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [บันทึกการนำเสนอบน Android](/androidjava/save-presentation/)
- [รูปแบบไฟล์ที่รองรับ](/androidjava/supported-file-formats/)
- [เปิดการนำเสนอบน Android](/androidjava/open-presentation/)

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลง PPT เป็น PPTX ได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ใช่. Aspose.Slides สำหรับ Android ผ่าน Java สามารถโหลดและบันทึกไฟล์การนำเสนอได้โดยไม่ต้องอาศัย Microsoft PowerPoint.

**การแปลงจาก PPT ไปเป็น PPTX จะคงเนื้อหาทั้งหมดอย่างครบถ้วนหรือไม่?**

การแปลงจะคงเนื้อหาการนำเสนอทั่วไปไว้ แต่ความแม่นยำแบบเต็มรูปแบบไม่รับประกันสำหรับคุณลักษณะเก่าหรือคุณลักษณะที่ไม่รองรับทั้งหมด ควรตรวจสอบไฟล์ที่สร้างขึ้นเมื่อมีมาโคร, วัตถุ OLE หรือ ActiveX, สื่อ, แอนิเมชันพิเศษ, หรือฟอนต์ที่ไม่ทั่วไป

**ฉันสามารถแปลงไฟล์ PPT ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้, หากคุณระบุรหัสผ่านที่ถูกต้องขณะโหลดไฟล์ รหัสผ่านที่หายไปหรือไม่ถูกต้องจะทำให้การโหลดล้มเหลว

**ฉันควรลบไฟล์ PPT หลังจากการแปลงหรือไม่?**

เก็บไฟล์ต้นฉบับไว้จนกว่าคุณจะตรวจสอบ PPTX ผ่านตัวดูและกระบวนการทำงานที่สำคัญสำหรับคุณ การทำเช่นนี้จะให้สำเนาสำรองหากคุณลักษณะเก่าถูกแปลงแตกต่างกัน