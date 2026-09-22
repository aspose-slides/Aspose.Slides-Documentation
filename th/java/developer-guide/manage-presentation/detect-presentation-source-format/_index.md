---
title: ระบุรูปแบบการนำเสนอเดิมใน Java
linktitle: รูปแบบต้นทาง
type: docs
weight: 35
url: /th/java/detect-presentation-source-format/
keywords:
- รูปแบบต้นทาง
- ตรวจจับรูปแบบการนำเสนอ
- PowerPoint
- OpenDocument
- การนำเสนอ
- PPT
- PPTX
- Java
- Aspose.Slides
description: "อ่านรูปแบบเดิมของการนำเสนอที่โหลดใน Java ด้วย Aspose.Slides for Java, เปรียบเทียบ API การตรวจจับ, และจัดการไฟล์, สตรีม, และรูปแบบรุ่นเก่า."
---
## **ภาพรวม**

หลังจากโหลดการนำเสนอ ให้เรียกเมธอด [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSourceFormat--) เพื่อกำหนดรูปแบบเดิมของมัน เมธอดนี้ยังสามารถเข้าถึงได้ผ่าน [IPresentation.getSourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getSourceFormat--) ใช้เมธอดนี้เมื่อการประมวลผลต่อไปขึ้นอยู่กับรูปแบบที่อินสแตนซ์ปัจจุบันถูกโหลดมา

รูปแบบต้นทางจะแตกต่างจาก [SaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/) ที่เลือกสำหรับไฟล์ผลลัพธ์ การบันทึกเป็นรูปแบบอื่นจะไม่เปลี่ยนรูปแบบต้นทางของอินสแตนซ์ที่มีอยู่

## **อ่านรูปแบบต้นทางของไฟล์**

ตัวอย่างนี้ต้องการไฟล์ `sample.pptx` ที่มีอยู่แล้ว มันโหลดไฟล์และเลือกนโยบายการประมวลผลของแอปพลิเคชันโดยใช้ [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSourceFormat--) แทนที่จะใช้ชื่อไฟล์ เปลี่ยนเส้นทางเข้เพื่อทดสอบรูปแบบอื่น ๆ ตัวอย่างพิมพ์นโยบายที่เลือก; แทนที่ข้อความด้วยตรรกะของแอปพลิเคชันของคุณ

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **ระบุค่าที่รองรับ**

คลาส [SourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/sourceformat/) กำหนดค่าคงที่จำนวนเต็มที่แยกประเภทการนำเสนอด้านล่างนี้ ส่วนต่อท้ายไฟล์ด้านล่างเป็นส่วนต่อท้ายแบบทั่วไป ไม่ใช่การสร้างชื่อไฟล์เดิมใหม่

| ค่า SourceFormat | ส่วนต่อท้าย | รูปแบบ |
| --- | --- | --- |
| `Ppt` | `.ppt` | การนำเสนอ PowerPoint 97–2003 |
| `Pptx` | `.pptx` | การนำเสนอ Office Open XML |
| `Pptm` | `.pptm` | การนำเสนอ Office Open XML ที่เปิดใช้งานแมโคร |
| `Pps` | `.pps` | การสไลด์โชว์ PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | การสไลด์โชว์ Office Open XML |
| `Ppsm` | `.ppsm` | การสไลด์โชว์ Office Open XML ที่เปิดใช้งานแมโคร |
| `Pot` | `.pot` | เทมเพลต PowerPoint 97–2003 |
| `Potx` | `.potx` | เทมเพลต Office Open XML |
| `Potm` | `.potm` | เทมเพลต Office Open XML ที่เปิดใช้งานแมโคร |
| `Odp` | `.odp` | การนำเสนอ OpenDocument |
| `Otp` | `.otp` | เทมเพลตการนำเสนอ OpenDocument |
| `Fodp` | `.fodp` | การนำเสนอ Flat XML ODF |
| `Xml` | `.xml` | การนำเสนอ PowerPoint XML |

## **อ่านรูปแบบต้นทางของสตรีม**

ตัวอย่างนี้ต้องการไฟล์ `sample.pps` ที่มีอยู่แล้ว การอ่านไบต์ของมันเข้าไปในสตรีมหน่วยความจำจำลองการรับข้อมูลโดยไม่มีชื่อไฟล์ เช่น ค่าจากฐานข้อมูลหรืออาร์เรย์ไบต์ที่อัปโหลด ตัวสร้าง [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) รับสตรีมเท่านั้น

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS และ POT ใช้รูปแบบไบนารีพื้นฐานเดียวกัน เมื่อโหลดด้วยเส้นทางไฟล์ ส่วนต่อท้ายไฟล์สามารถช่วยแยกสไลด์โชว์หรือเทมเพลตได้ หากไม่มีชื่อไฟล์ เนื้อหา PPS และ POT รุ่นเก่าอาจถูกรายงานเป็น `SourceFormat.Ppt`; ตัวอย่าง PPS ด้านบนพิมพ์ค่าจำนวนเต็มของ `SourceFormat.Ppt`  

หากแอปพลิเคชันของคุณต้องการเก็บความแตกต่างนี้ ควรเก็บชื่อไฟล์ต้นฉบับหรือเมตาดาต้าย่อยแยกต่างหาก ส่วนต่อท้ายเป็นสัญญาณที่เป็นประโยชน์สำหรับย่อยรุ่นเก่าเหล่านี้ แต่ไม่ควรใช้เป็นเกณฑ์เดียวในการระบุเนื้อหาการนำเสนอใด ๆ

## **เปรียบเทียบการตรวจจับก่อนและหลังการโหลด**

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) และ [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) เมื่อคุณต้องการตรวจสอบไฟล์ก่อนโหลดโมเดลวัตถุการนำเสนอเต็มรูปแบบ ใช้ [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSourceFormat--) เมื่ออินสแตนซ์มีอยู่แล้ว

ตัวอย่างนี้ต้องการ `sample.pptx` และพิมพ์ค่าจำนวนเต็มของ `LoadFormat.Pptx` และ `SourceFormat.Pptx` ตามลำดับ ในการผลิตให้เลือก API ที่เหมาะสมกับขั้นตอนการประมวลผลของคุณ; การนำเสนอที่โหลดแล้วไม่จำเป็นต้องตรวจสอบอีกครั้งเพียงเพื่อรับรูปแบบต้นทาง

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ใช้ค่าคงที่จากคลาสต่างกัน: [LoadFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadformat/) และ [SourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/sourceformat/) อย่ายกเว้นค่าตัวเลขของพวกมันหรือสมมติว่าทุกรูปแบบให้ผลลัพธ์การตรวจจับที่เหมือนกัน PowerPoint XML อาจรายงานเป็น `LoadFormat.Unknown` ก่อนโหลดและ `SourceFormat.Xml` หลังโหลด

## **แยกรูปแบบต้นทางและรูปแบบผลลัพธ์ออกจากกัน**

ตัวอย่างนี้ต้องการ `sample.pptx` และเขียนไฟล์ `converted.odp` มันพิมพ์ค่าจำนวนเต็มของ `SourceFormat.Pptx` ทั้งก่อนและหลังบันทึกอินสแตนซ์เดิม เพียงอินสแตนซ์ใหม่ที่โหลดจากผลลัพธ์ ODP จะรายงาน `Odp`

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

การนำเสนอที่สร้างจากศูนย์ด้วย `new Presentation()` จะรายงาน `SourceFormat.Pptx` เนื่องจากไม่มีไฟล์อินพุต: นี่คือค่าตั้งต้นสำหรับอินสแตนซ์ที่สร้างใหม่ ไม่ได้หมายความว่าไฟล์ PPTX ถูกโหลดไว้ ให้ติดตามว่าแอปของคุณสร้างหรือโหลดอินสแตนซ์อย่างแยกจากกันหากความแตกต่างนั้นสำคัญ

## **แมปรูปแบบต้นทางเป็นส่วนต่อท้าย**

ตัวอย่างต่อไปนี้ต้องการ `sample.pptx` มันแมปค่าของ [SourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/sourceformat/) ที่สนับสนุนทุกค่าในปัจจุบันเป็นส่วนต่อท้ายแบบทั่วไป โดยไม่ต้องวิเคราะห์ชื่อไฟล์อินพุต การสำรองนี้ช่วยหลีกเลี่ยงการกำหนดส่วนต่อท้ายให้กับค่าที่ไม่รู้จักโดยเงียบ

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

การแมปนี้ไม่ทำการแปลงไฟล์หรือกู้คืนย่อยรุ่น PPS/POT ที่สูญหายระหว่างการโหลดสตรีม สำหรับการบันทึกจริง ให้เลือก [SaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/) โดยชัดเจน หรือใช้การแปลงที่แสดงใน [Save Presentations in Their Original Format](/slides/th/java/save-presentation/#save-presentations-in-their-original-format)

## **ตรวจสอบรูปแบบโดยการบันทึกและเปิดใหม่**

ตัวอย่างนี้เป็นแบบอิสระ สร้างการนำเสนอแล้วเขียนไฟล์สามไฟล์ในโฟลเดอร์ทำงาน โดยเขียนทับไฟล์ที่มีชื่อเดียวกันทั้งหมด มันเปิดแต่ละผลลัพธ์ทั้งโดยเส้นทางและผ่านสตรีมหน่วยความจำ สำหรับ PPTX และ ODP ทั้งสองวิธีจะรายงานรูปแบบที่บันทึกไว้ สำหรับ PPS การโหลดโดยเส้นทางจะรายงาน `Pps` ในขณะที่การโหลดไบต์เดียวกันโดยไม่มีชื่อไฟล์จะรายงาน `Ppt`

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

ตารางต่อไปสรุปการระบุรูปแบบต้นทางสำหรับการนำเสนอที่มีส่วนต่อท้ายตรงกัน ชื่อแสดงค่าคงที่; ตัวอย่าง Java พิมพ์ค่าจำนวนเต็มของพวกมัน:

| รูปแบบที่บันทึก | SourceFormat จากเส้นทางไฟล์ | SourceFormat จากสตรีมไม่มีชื่อ |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` ตามลำดับ | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` ตามลำดับ | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` ตามลำดับ | Same as file path |
| ODP, OTP | `Odp`, `Otp` ตามลำดับ | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

เนื้อหา PPS/POT จะถูกระบุเป็น `Ppt` สำหรับสตรีมไม่มีชื่อ ตารางนี้อธิบายการระบุรูปแบบ ไม่ได้หมายถึงการรักษาฟีเจอร์ทุกอย่างของการนำเสนอระหว่างการแปลง

## **คำถามที่พบบ่อย**

**การบันทึกเป็น ODP จะเปลี่ยนรูปแบบต้นทางของการนำเสนอที่โหลดจาก PPTX หรือไม่?**

ไม่ การอินสแตนซ์ที่มีอยู่ยังคงรายงาน `Pptx` อินสแตนซ์ที่โหลดจากไฟล์ ODP ที่บันทึกไว้จะรายงาน `Odp`

**สตรีมสามารถแยกแยะการนำเสนอรุ่นเก่า, สไลด์โชว์และเทมเพลตได้เสมอหรือไม่?**

ไม่ PPT, PPS และ POT ใช้รูปแบบไบนารีเดียวกัน ให้เก็บชื่อไฟล์หรือเมตาดาต้าย่อยแยกต่างหากเมื่อความแตกต่างนั้นจำเป็น

**ควรใช้ API ใดหากการนำเสนอโหลดแล้ว?**

อ่าน [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSourceFormat--) ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) สำหรับการตรวจสอบก่อนการโหลด