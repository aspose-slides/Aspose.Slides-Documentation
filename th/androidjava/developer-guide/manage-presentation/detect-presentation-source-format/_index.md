---
title: ระบุรูปแบบการนำเสนอดั้งเดิมบน Android
linktitle: รูปแบบต้นทาง
type: docs
weight: 35
url: /th/androidjava/detect-presentation-source-format/
keywords:
- รูปแบบต้นทาง
- ตรวจจับรูปแบบการนำเสนอ
- PowerPoint
- OpenDocument
- การนำเสนอ
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "อ่านรูปแบบดั้งเดิมของการนำเสนอที่โหลดบน Android ด้วย Aspose.Slides สำหรับ Android ผ่าน Java, เปรียบเทียบ API การตรวจจับ, และจัดการไฟล์, สตรีม, และรูปแบบเก่า"
---
## **ภาพรวม**

หลังจากโหลดการนำเสนอ ให้เรียกเมธอด [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSourceFormat--) เพื่อระบุรูปแบบดั้งเดิมของไฟล์ เมธอดนี้ยังสามารถใช้ผ่าน [IPresentation.getSourceFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) ได้เช่นกัน ใช้เมธอดนี้เมื่อการประมวลผลต่อไปอาศัยรูปแบบที่ไฟล์ต้นฉบับถูกโหลดมา

รูปแบบต้นฉบับแตกต่างจาก [SaveFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/) ที่เลือกสำหรับไฟล์ผลลัพธ์ การบันทึกเป็นรูปแบบอื่นจะไม่เปลี่ยนรูปแบบต้นฉบับของอ็อบเจ็กต์ที่มีอยู่แล้ว

ตัวอย่างใช้ Java และเส้นทางไฟล์ บน Android ให้เปลี่ยนเส้นทางตัวอย่างเป็นเส้นทางที่อยู่ในที่เก็บข้อมูลที่แอปเข้าถึงได้ เช่น ไดเร็กทอรีไฟล์ภายในของแอป

## **อ่านรูปแบบต้นฉบับของไฟล์**

ตัวอย่างนี้ต้องมีไฟล์ `sample.pptx` อยู่แล้ว จะโหลดไฟล์และเลือกนโยบายการประมวลผลของแอปโดยใช้ [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSourceFormat--) แทนการอ้างอิงชื่อไฟล์ เปลี่ยนเส้นทางเข้าเพื่อทดสอบรูปแบบอื่น ตัวอย่างจะพิมพ์นโยบายที่เลือก; สามารถแทนข้อความเหล่านี้ด้วยตรรกะของแอปของคุณได้

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

## **รับรู้ค่าที่ได้รับการสนับสนุน**

คลาส [SourceFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sourceformat/) กำหนดค่าคงที่จำนวนเต็มที่แยกความแตกต่างของรูปแบบการนำเสนอด้านล่าง ส่วนขยายต่อไปนี้เป็นส่วนขยายที่เป็นมาตรฐาน ไม่ได้เป็นการสร้างใหม่จากชื่อไฟล์ต้นฉบับ

| ค่า SourceFormat | นามสกุล | รูปแบบ |
| --- | --- | --- |
| `Ppt` | `.ppt` | การนำเสนอ PowerPoint 97–2003 |
| `Pptx` | `.pptx` | การนำเสนอ Office Open XML |
| `Pptm` | `.pptm` | การนำเสนอ Office Open XML ที่เปิดใช้งานมาโคร |
| `Pps` | `.pps` | การแสดงสไลด์ PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | การแสดงสไลด์ Office Open XML |
| `Ppsm` | `.ppsm` | การแสดงสไลด์ Office Open XML ที่เปิดใช้งานมาโคร |
| `Pot` | `.pot` | เทมเพลต PowerPoint 97–2003 |
| `Potx` | `.potx` | เทมเพลต Office Open XML |
| `Potm` | `.potm` | เทมเพลต Office Open XML ที่เปิดใช้งานมาโคร |
| `Odp` | `.odp` | การนำเสนอ OpenDocument |
| `Otp` | `.otp` | เทมเพลตการนำเสนอ OpenDocument |
| `Fodp` | `.fodp` | การนำเสนอ Flat XML ODF |
| `Xml` | `.xml` | การนำเสนอ PowerPoint XML |

## **อ่านรูปแบบต้นฉบับจากสตรีม**

ตัวอย่างนี้ต้องมีไฟล์ `sample.pps` อยู่แล้ว การอ่านไบต์ของไฟล์เข้าสู่สตรีมหน่วยความจำจำลองการรับข้อมูลโดยไม่มีชื่อไฟล์ เช่น ค่าจากฐานข้อมูลหรืออาเรย์ไบต์ที่อัปโหลด ตัวสร้าง [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) จะรับสตรีมเท่านั้น

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

PPT, PPS และ POT ใช้รูปแบบไบนารีพื้นฐานเดียวกัน เมื่อโหลดโดยเส้นทางไฟล์ ส่วนขยายสามารถช่วยแยกความแตกต่างระหว่างการแสดงสไลด์หรือเทมเพลตได้ หากไม่มีชื่อไฟล์ เนื้อหา PPS หรือ POT แบบเก่าอาจถูกรายงานเป็น `SourceFormat.Ppt`; ตัวอย่าง PPS ด้านบนพิมพ์ค่าจำนวนเต็มของ `SourceFormat.Ppt`

หากแอปของคุณต้องการรักษาความแตกต่างไว้ ให้เก็บชื่อไฟล์ต้นฉบับหรือข้อมูลเมตา subtype แยกกัน ส่วนขยายเป็นเคล็ดลับที่มีประโยชน์สำหรับ subtype แบบเก่าเหล่านี้ แต่ไม่ควรใช้เป็นเกณฑ์เดียวในการระบุเนื้อหาการนำเสนอใด ๆ

## **เปรียบเทียบการตรวจจับก่อนและหลังการโหลด**

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) และ [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) เมื่อต้องการตรวจสอบไฟล์ก่อนที่จะโหลดโมเดลอ็อบเจ็กต์การนำเสนอเต็มรูปแบบ ใช้ [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSourceFormat--) เมื่ออ็อบเจ็กต์มีอยู่แล้ว

ตัวอย่างนี้ต้องมี `sample.pptx` และพิมพ์ค่าจำนวนเต็มของ `LoadFormat.Pptx` และ `SourceFormat.Pptx` ตามลำดับ ในสภาพการผลิต ให้เลือก API ที่เหมาะสมกับขั้นตอนการประมวลผลของคุณ; การนำเสนอที่โหลดแล้วไม่จำเป็นต้องตรวจสอบสองครั้งเพียงเพื่อรับรูปแบบต้นฉบับ

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

ผลลัพธ์ใช้ค่าคงที่จากคลาสต่าง ๆ: [LoadFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadformat/) และ [SourceFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sourceformat/) อย่าทำการเปรียบเทียบค่าตัวเลขของพวกมันหรือสมมติว่าทุกรูปแบบมีผลการตรวจจับที่เหมือนกัน PowerPoint XML อาจถูกรายงานเป็น `LoadFormat.Unknown` ก่อนโหลดและเป็น `SourceFormat.Xml` หลังโหลด

## **แยกรูปแบบต้นฉบับและรูปแบบผลลัพธ์ออกจากกัน**

ตัวอย่างนี้ต้องมี `sample.pptx` และจะเขียน `converted.odp` ตัวอย่างจะพิมพ์ค่าจำนวนเต็มของ `SourceFormat.Pptx` ทั้งก่อนและหลังการบันทึกอ็อบเจ็กต์ต้นฉบับ ตัวอ็อบเจ็กต์ใหม่ที่โหลดจากไฟล์ ODP ผลลัพธ์จะรายงานเป็น `Odp`

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

การสร้างการนำเสนอจากศูนย์ด้วย `new Presentation()` จะรายงาน `SourceFormat.Pptx` เนื่องจากไม่มีไฟล์อินพุต: นี่คือค่าตั้งต้นสำหรับอ็อบเจ็กต์ที่สร้างใหม่ ไม่ได้หมายความว่ามีการโหลดไฟล์ PPTX ติดตามว่าการสร้างหรือการโหลดอ็อบเจ็กต์เกิดขึ้นแยกจากกันหากความแตกต่างนั้นมีความสำคัญ

## **แมพรูปแบบต้นฉบับเป็นนามสกุลไฟล์**

ตัวอย่างต่อไปนี้ต้องมี `sample.pptx` จะแมพค่าทั้งหมดของ [SourceFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sourceformat/) ที่สนับสนุนในปัจจุบันเป็นนามสกุลแบบมาตรฐาน โดยไม่ต้องพาร์สชื่อไฟล์อินพุต การแมพสำรองนี้ช่วยหลีกเลี่ยงการกำหนดนามสกุลโดยอัตโนมัติให้กับค่าที่ไม่รู้จัก

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

การแมพนี้ไม่ได้แปลงไฟล์หรือกู้คืน subtype PPS/POT แบบเก่าที่หายไประหว่างการโหลดสตรีม สำหรับการบันทึกจริง ให้เลือก [SaveFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/) อย่างชัดเจน หรือใช้การแปลงที่แสดงใน [Save Presentations in Their Original Format](/slides/th/androidjava/save-presentation/#save-presentations-in-their-original-format)

## **ตรวจสอบรูปแบบโดยการบันทึกและเปิดใหม่**

ตัวอย่างแบบอิสระนี้สร้างการนำเสนอและเขียนไฟล์สามไฟล์ในไดเร็กทอรีทำงาน โดยเขียนทับไฟล์ที่มีชื่อเดียวกัน จะเปิดไฟล์ผลลัพธ์แต่ละไฟล์ทั้งโดยเส้นทางและผ่านสตรีมหน่วยความจำ สำหรับ PPTX และ ODP ทั้งสองวิธีจะรายงานรูปแบบที่บันทึกไว้ สำหรับ PPS การโหลดโดยเส้นทางจะรายงาน `Pps` ส่วนการโหลดไบต์เดียวกันโดยไม่มีชื่อไฟล์จะรายงาน `Ppt`

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

ตารางต่อไปสรุปการระบุรูปแบบต้นฉบับสำหรับการนำเสนอที่มีนามสกุลตรงกัน ชื่อแสดงค่าคงที่; ตัวอย่าง Java พิมพ์ค่าจำนวนเต็มของพวกมัน:

| รูปแบบที่บันทึก | SourceFormat จากเส้นทางไฟล์ | SourceFormat จากสตรีมที่ไม่มีชื่อ |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` ตามลำดับ | เหมือนกับเส้นทางไฟล์ |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` ตามลำดับ | เหมือนกับเส้นทางไฟล์ |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` ตามลำดับ | เหมือนกับเส้นทางไฟล์ |
| ODP, OTP | `Odp`, `Otp` ตามลำดับ | เหมือนกับเส้นทางไฟล์ |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

เนื้อหา PPS/POT จะถูกระบุเป็น `Ppt` สำหรับสตรีมที่ไม่มีชื่อ ตารางนี้อธิบายการระบุรูปแบบ ไม่ได้หมายถึงการรักษาคุณลักษณะทุกอย่างของการนำเสนอระหว่างการแปลง

## **คำถามที่พบบ่อย**

**การบันทึกเป็น ODP จะเปลี่ยนรูปแบบต้นฉบับของการนำเสนอที่โหลดจาก PPTX หรือไม่?**

ไม่ รายการอ็อบเจ็กต์ที่มีอยู่ยังคงรายงาน `Pptx` ส่วนอ็อบเจ็กต์ที่โหลดจากไฟล์ ODP ที่บันทึกแล้วจะรายงาน `Odp`

**สตรีมสามารถแยกความแตกต่างระหว่างการนำเสนอแบบเก่า การแสดงสไลด์ และเทมเพลตได้เสมอหรือไม่?**

ไม่ PPT, PPS และ POT ใช้รูปแบบไบนารีเดียวกัน ให้เก็บชื่อไฟล์หรือข้อมูลเมตา subtype แยกกันเมื่อจำเป็นต้องแยกความแตกต่างเหล่านี้

**ควรใช้ API ใดหากการนำเสนอถูกโหลดแล้ว?**

อ่าน [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSourceFormat--) ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) สำหรับการตรวจสอบก่อนโหลด