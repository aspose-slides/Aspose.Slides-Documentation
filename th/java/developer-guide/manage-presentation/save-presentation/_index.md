---
title: บันทึกงานนำเสนอใน Java
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/java/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกงานนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- งานนำเสนอเป็นไฟล์
- งานนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดไว้ล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชภาพย่อ
- บันทึกความคืบหน้า
- Java
- Aspose.Slides
description: "ค้นพบวิธีบันทึกงานนำเสนอใน Java ด้วย Aspose.Slides - ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมคงรูปแบบ ฟอนต์และเอฟเฟกต์"
---
## **ภาพรวม**

[Open Presentations in Java](/slides/th/java/open-presentation/) แสดงวิธีใช้คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เพื่อเปิดงานนำเสนอ บทความนี้อธิบายวิธีสร้างและบันทึกงานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เก็บเนื้อหาของงานนำเสนอ ไม่ว่าคุณจะสร้างงานนำเสนอจากเริ่มต้นหรือแก้ไขงานที่มีอยู่ คุณก็ต้องการบันทึกเมื่อทำเสร็จแล้ว ด้วย Aspose.Slides for Java คุณสามารถบันทึกเป็น **ไฟล์** หรือ **สตรีม** บทความนี้อธิบายวิธีต่างๆ ในการบันทึกงานนำเสนอ

## **บันทึกงานนำเสนอลงไฟล์**

บันทึกงานนำเสนอเป็นไฟล์โดยเรียกเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ส่งชื่อไฟล์และรูปแบบการบันทึกให้เมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอด้วย Aspose.Slides

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ทำงานบางอย่างที่นี่...

    // บันทึกงานนำเสนอเป็นไฟล์.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอลงสตรีม**

คุณสามารถบันทึกงานนำเสนอเป็นสตรีมได้โดยส่งสตรีมเอาต์พุตให้เมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) งานนำเสนอสามารถเขียนไปยังสตรีมประเภทต่างๆ ในตัวอย่างด้านล่าง เราจะสร้างงานนำเสนอใหม่และบันทึกลงสตรีมไฟล์

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // บันทึกงานนำเสนอไปยังสตรีม.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอพร้อมมุมมองที่กำหนดไว้ล่วงหน้า**

Aspose.Slides ให้คุณกำหนดมุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดงานนำเสนอที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewproperties/) ใช้เมธอด [setLastView](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewproperties/#setLastView-int-) พร้อมค่าจาก enumeration [ViewType](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewtype/)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกงานนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxoptions/) และตั้งค่าคุณสมบัติ conformance ขณะบันทึก หากตั้งค่าเป็น [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างด้านล่างสร้างงานนำเสนอและบันทึกในรูปแบบ Strict Office Open XML

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ด้วยโหมด Zip64**

ไฟล์ Office Open XML เป็นไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดไฟล์ที่ไม่ได้บีบอัด, ขนาดไฟล์ที่บีบอัด, และขนาดรวมของอาร์ไคฟ์ รวมถึงจำกัดจำนวนไฟล์สูงสุดที่ 65 535 (2^16‑1) ไฟล์ ส่วนขยายฟอร์แมต ZIP64 จะยกขีดจำกัดเหล่านี้เป็น 2^64

เมธอด [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) ให้คุณเลือกว่าจะใช้ส่วนขยายรูปแบบ ZIP64 เมื่อบันทึกไฟล์ Office Open XML หรือไม่

เมธอดนี้สามารถใช้ได้กับโหมดต่อไปนี้:

- [IfNecessary](https://reference.aspose.com/slides/th/java/com.aspose.slides/zip64mode/#IfNecessary) ใช้ส่วนขยาย ZIP64 เฉพาะเมื่อขนาดงานนำเสนอเกินขีดจำกัดข้างต้น ซึ่งเป็นโหมดเริ่มต้น
- [Never](https://reference.aspose.com/slides/th/java/com.aspose.slides/zip64mode/#Never) ไม่ใช้ส่วนขยาย ZIP64 เลย
- [Always](https://reference.aspose.com/slides/th/java/com.aspose.slides/zip64mode/#Always) ใช้ส่วนขยาย ZIP64 เสมอ

ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX พร้อมเปิดใช้งานส่วนขยายรูปแบบ ZIP64

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
เมื่อบันทึกด้วย [Zip64Mode.Never](https://reference.aspose.com/slides/th/java/com.aspose.slides/zip64mode/#Never) จะเกิดข้อยกเว้น [PptxException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxexception/) หากไม่สามารถบันทึกงานนำเสนอในรูปแบบ ZIP32 ได้
{{% /alert %}}

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

เมื่อต้องจัดการกับงานนำเสนอขนาดใหญ่ คุณสามารถปรับระดับการบีบอัดเพื่อสมดุลระหว่างขนาดไฟล์และเวลาในการประมวลผล ตามความต้องการของคุณอาจเลือกประมวลผลเร็วหรือไฟล์ขนาดเล็กกว่า

Aspose.Slides มีเมธอด [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) ที่ให้คุณระบุระดับการบีบอัดเมื่อบันทึกงานนำเสนอในรูปแบบ Office Open XML

ระดับการบีบอัดที่มีให้เลือกมีดังนี้:

- [**None**](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#None): ไม่บีบอัดไฟล์ ใส่ไฟล์ไว้ตามเดิม
- [**Level1**](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level1): การบีบอัดที่เร็วที่สุดและอัตราการบีบอัดต่ำที่สุด
- [**Level2**](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level2): การบีบอัดเร็วกว่าโดยให้สัดส่วนบีบอัดดีกว่า **Level1**
- [**Level3**](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level3): ให้การบีบอัดดีกว่า **Level2** พร้อมผลกระทบปานกลางต่อเวลาในการประมวลผล
- [**Level4**](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level4): ให้การบีบอัดดีกว่า **Level3**
- [**Level5**](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level5): ให้การบีบอัดดีกว่า **Level4** เพิ่มเวลาการประมวลผล
- [**Level6**](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level6): การบีบอัดมาตรฐานที่สมดุลระหว่างความเร็วและขนาดไฟล์ นี่คือ *ระดับการบีบอัดเริ่มต้น*
- [**Level7**](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level7): ให้การบีบอัดดีกว่า **Level6** แต่ช้ากว่า
- [**Level8**](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level8): ให้การบีบอัดดีกว่า **Level7**
- [**Level9**](https://reference.aspose.com/slides/th/java/com.aspose.slides/compressionlevel/#Level9): การบีบอัดสูงสุด ให้ไฟล์ที่เล็กที่สุดแต่ต้องใช้เวลาประมวลผลนานที่สุด

ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX *โดยไม่มีการบีบอัด*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

ตัวอย่างนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX พร้อม *การบีบอัดสูงสุด*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอโดยไม่รีเฟรชภาพย่อ**

เมธอด [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) ควบคุมการสร้างภาพย่อเมื่อต้องบันทึกงานนำเสนอเป็น PPTX:

- ถ้าตั้งค่าเป็น `true` ภาพย่อจะถูกรีเฟรชขณะแบบบันทึก (ค่าเริ่มต้น)
- ถ้าตั้งค่าเป็น `false` ภาพย่อปัจจุบันจะถูกเก็บไว้ หากงานนำเสนอไม่มีภาพย่อ จะไม่มีการสร้างภาพใหม่

ในโค้ดด้านล่าง งานนำเสนอจะถูกบันทึกเป็น PPTX โดยไม่รีเฟรชภาพย่อ

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
ตัวเลือกนี้ช่วยลดเวลาที่ใช้ในการบันทึกงานนำเสนอในรูปแบบ PPTX
{{% /alert %}}

## **บันทึกความคืบหน้าเป็นเปอร์เซ็นต์**

อินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/) ใช้ผ่านเมธอด `setProgressCallback` ที่เปิดให้โดยอินเทอร์เฟซ [ISaveOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/isaveoptions/) และคลาสนามธรรม [SaveOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveoptions/) ให้คุณกำหนดการทำงานของ [IProgressCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/) ด้วย `setProgressCallback` เพื่อรับการอัปเดตความคืบหน้าในการบันทึกเป็นเปอร์เซ็นต์

โค้ดสแนปต่อไปนี้แสดงวิธีใช้ `IProgressCallback`

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // ใช้ค่าร้อยละของความคืบหน้าในที่นี้.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose ได้พัฒนาแอป [free PowerPoint Splitter app](https://products.aspose.app/slides/th/splitter) โดยใช้ API ของตนเอง แอปนี้ช่วยให้คุณแยกงานนำเสนอออกเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **FAQ**

**รองรับ “การบันทึกเร็ว” (incremental save) ที่บันทึกเฉพาะการเปลี่ยนแปลงหรือไม่?**

ไม่รองรับ การบันทึกจะสร้างไฟล์เป้าหมายเต็มทุกครั้ง; “การบันทึกเร็ว” แบบ incremental ไม่ได้สนับสนุน

**การบันทึกอินสแตนซ์ Presentation เดียวจากหลายเธรดปลอดภัยหรือไม่?**

ไม่ปลอดภัย อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ไม่เป็น thread‑safe [/slides/th/java/multithreading/]; ควรบันทึกจากเธรดเดียวเท่านั้น

**ลิงก์ไฮเปอร์ลิงก์และไฟล์ที่เชื่อมโยงภายนอกจะเป็นอย่างไรเมื่อบันทึก?**

[Hyperlinks](/slides/th/java/manage-hyperlinks/) จะถูกเก็บไว้ ไฟล์ที่เชื่อมโยงภายนอก (เช่น วิดีโอที่อ้างอิงด้วยเส้นทางสัมพันธ์) จะไม่ถูกคัดลอกโดยอัตโนมัติ – ต้องแน่ใจว่าเส้นทางที่อ้างอิงยังคงเข้าถึงได้

**สามารถตั้งค่า/บันทึกข้อมูลเมตาดาต้าเอกสาร (Author, Title, Company, Date) ได้หรือไม่?**

ได้ รองรับ [document properties](/slides/th/java/presentation-properties/) มาตรฐานและจะถูกเขียนลงไฟล์เมื่อบันทึก