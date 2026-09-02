---
title: บันทึกการนำเสนอบน Android
linktitle: บันทึกการนำเสนอ
type: docs
weight: 80
url: /th/androidjava/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกการนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- การนำเสนอเป็นไฟล์
- การนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดไว้ล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชภาพย่อ
- บันทึกความคืบหน้า
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีบันทึกการนำเสนอใน Java ด้วย Aspose.Slides สำหรับ Android—ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมคงรูปแบบ, ฟอนต์และเอฟเฟกต์."
---
## **ภาพรวม**

[Open Presentations on Android](/slides/th/androidjava/open-presentation/) อธิบายวิธีการใช้คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เพื่อเปิดการนำเสนอ บทความนี้อธิบายวิธีสร้างและบันทึกการนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) มีเนื้อหาของการนำเสนอ ไม่ว่าคุณจะสร้างการนำเสนอตั้งแต่เริ่มต้นหรือแก้ไขการนำเสนอที่มีอยู่ คุณต้องการบันทึกเมื่อทำเสร็จแล้ว ด้วย Aspose.Slides for Android คุณสามารถบันทึกเป็น **ไฟล์** หรือ **สตรีม** บทความนี้อธิบายวิธีต่าง ๆ ที่จะบันทึกการนำเสนอ

## **บันทึกการนำเสนอเป็นไฟล์**

บันทึกการนำเสนอเป็นไฟล์โดยเรียกเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกการนำเสนอด้วย Aspose.Slides

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ทำงานบางอย่างที่นี่...

    // บันทึกการนำเสนอเป็นไฟล์.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกการนำเสนอเป็นสตรีม**

คุณสามารถบันทึกการนำเสนอเป็นสตรีมได้โดยส่งออพพุตสตรีมไปยังเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) การนำเสนอสามารถเขียนไปยังสตรีมหลายประเภท ในตัวอย่างด้านล่าง เราจะสร้างการนำเสนอใหม่และบันทึกลงสตรีมไฟล์

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // บันทึกการนำเสนอไปยังสตรีม.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **บันทึกการนำเสนอพร้อมประเภทมุมมองที่กำหนดไว้ล่วงหน้า**

Aspose.Slides ให้คุณตั้งค่ามุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดการนำเสนอที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/) ใช้เมธอด [setLastView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) พร้อมค่าจาก enumeration [ViewType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewtype/)

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

## **บันทึกการนำเสนอในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกการนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxoptions/) และตั้งค่าคุณสมบัติคอนฟอร์แมนซ์เมื่อตsaving หากคุณตั้งค่า [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างด้านล่างสร้างการนำเสนอและบันทึกในรูปแบบ Strict Office Open XML

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation();
try {
    // บันทึกการนำเสนอในรูปแบบ Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **บันทึกการนำเสนอในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ Office Open XML เป็นไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดไฟล์ที่ไม่ได้บีบอัดของไฟล์ใด ๆ ขนาดไฟล์ที่บีบอัดของไฟล์ใด ๆ และขนาดรวมของไฟล์อาร์ไคฟ์ รวมถึงจำกัดจำนวนไฟล์ในอาร์ไคฟ์ไม่เกิน 65,535 (2^16‑1) ไฟล์ ส่วนขยายรูปแบบ ZIP64 จะเพิ่มขีดจำกัดเหล่านี้เป็น 2^64

เมธอด [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) ให้คุณเลือกว่าจะใช้ส่วนขยายรูปแบบ ZIP64 เมื่อบันทึกไฟล์ Office Open XML หรือไม่

เมธอดนี้สามารถใช้กับโหมดต่อไปนี้:
- [IfNecessary](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/zip64mode/#IfNecessary) ใช้ส่วนขยายรูปแบบ ZIP64 เฉพาะเมื่อการนำเสนอเกินข้อจำกัดข้างต้น นี่คือโหมดเริ่มต้น
- [Never](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/zip64mode/#Never) ไม่เคยใช้ส่วนขยายรูปแบบ ZIP64
- [Always](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/zip64mode/#Always) ใช้ส่วนขยายรูปแบบ ZIP64 เสมอ

โค้ดต่อไปนี้แสดงวิธีบันทึกการนำเสนอเป็นไฟล์ PPTX พร้อมเปิดใช้งานส่วนขยายรูปแบบ ZIP64:

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
เมื่อคุณบันทึกด้วย [Zip64Mode.Never](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/zip64mode/#Never) ถ้ามีการบันทึกการนำเสนอไม่สำเร็จในรูปแบบ ZIP32 จะเกิด [PptxException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxexception/) ขึ้น
{{% /alert %}}

## **บันทึกการนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

เมื่อทำงานกับการนำเสนอขนาดใหญ่ คุณสามารถปรับระดับการบีบอัดเพื่อสมดุลขนาดไฟล์และระยะเวลาในการประมวลผล ตามความต้องการของคุณ คุณอาจต้องการประมวลผลที่เร็วขึ้นหรือไฟล์ผลลัพธ์ที่เล็กลง

Aspose.Slides มีเมธอด [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) ที่ให้คุณกำหนดระดับการบีบอัดที่ใช้เมื่อบันทึกการนำเสนอในรูปแบบ Office Open XML

ระดับการบีบอัดต่อไปนี้พร้อมใช้งาน:
- **None**: ไม่ใช้การบีบอัด ไฟล์จะถูกจัดเก็บตามต้นฉบับ
- **Level1**: การบีบอัดที่เร็วที่สุดด้วยอัตราการบีบอัดต่ำสุด
- **Level2**: การบีบอัดที่เร็วกว่าโดยอัตราการบีบอัดที่ดีขึ้นเล็กน้อยเมื่อเทียบกับ **Level1**
- **Level3**: ให้การบีบอัดที่ดีกว่า **Level2** โดยมีผลกระทบต่อระยะเวลาการประมวลผลระดับปานกลาง
- **Level4**: ให้การบีบอัดที่ดีกว่า **Level3**
- **Level5**: ให้การบีบอัดที่ดีขึ้นเหนือ **Level4** พร้อมระยะเวลาในการประมวลผลเพิ่มเติม
- **Level6**: การบีบอัดมาตรฐานที่ให้สมดุลที่ดีระหว่างความเร็วในการประมวลผลและขนาดไฟล์ นี่คือ *ระดับการบีบอัดเริ่มต้น*
- **Level7**: ให้การบีบอัดที่ดีกว่า **Level6** โดยการประมวลผลช้าลง
- **Level8**: ให้การบีบอัดที่ดีกว่า **Level7**
- **Level9**: การบีบอัดสูงสุด ให้ขนาดไฟล์ที่เล็กที่สุดแต่ใช้เวลาประมวลผลนานที่สุด

ตัวอย่างต่อไปนี้แสดงวิธีบันทึกการนำเสนอเป็นไฟล์ PPTX *โดยไม่มีการบีบอัด*:

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

ตัวอย่างนี้แสดงวิธีบันทึกการนำเสนอเป็นไฟล์ PPTX พร้อม *การบีบอัดสูงสุด*:

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

## **บันทึกการนำเสนอโดยไม่รีเฟรชภาพย่อ**

เมธอด [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) ควบคุมการสร้างภาพย่อเมื่อบันทึกการนำเสนอเป็น PPTX :
- หากตั้งค่าเป็น `true` ภาพย่อจะถูกรีเฟรชระหว่างการบันทึก นี่คือค่าเริ่มต้น
- หากตั้งค่าเป็น `false` ภาพย่อปัจจุบันจะถูกเก็บไว้ หากการนำเสนอไม่มีภาพย่อจะไม่มีการสร้างภาพย่อ

ในโค้ดด้านล่าง การนำเสนอจะถูกบันทึกเป็น PPTX โดยไม่รีเฟรชภาพย่อ

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
ตัวเลือกนี้ช่วยลดระยะเวลาในการบันทึกการนำเสนอในรูปแบบ PPTX
{{% /alert %}}

## **บันทึกการอัปเดตความคืบหน้าเป็นเปอร์เซ็นต์**

อินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprogresscallback/) ใช้ผ่านเมธอด `setProgressCallback` ที่เปิดให้โดยอินเทอร์เฟซ [ISaveOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isaveoptions/) และคลาสเชิงนามธรรม [SaveOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveoptions/) ให้กำหนดการทำงานของ [IProgressCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprogresscallback/) ด้วย `setProgressCallback` เพื่อรับการอัปเดตความคืบหน้าในการบันทึกเป็นเปอร์เซ็นต์

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้ `IProgressCallback`

```java
import com.aspose.slides.*;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // ใช้ค่าเปอร์เซ็นต์ความคืบที่นี่.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose ได้พัฒนาแอป [PowerPoint Splitter ฟรี](https://products.aspose.app/slides/th/splitter) โดยใช้ API ของตนเอง แอปนี้ช่วยให้คุณแยกการนำเสนอเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รองรับการ “บันทึกเร็ว” (บันทึกแบบเพิ่มส่วน) เพื่อบันทึกเฉพาะการเปลี่ยนแปลงหรือไม่?**

ไม่ใช่ การบันทึกจะสร้างไฟล์เป้าหมายเต็มทุกครั้ง; การบันทึกแบบ “บันทึกเร็ว” แบบเพิ่มส่วนไม่รองรับ

**การบันทึกอินสแตนซ์ Presentation เดียวกันจากหลายเธรดเป็นการทำแบบ thread‑safe หรือไม่?**

ไม่ใช่ อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) **ไม่เป็น thread‑safe**; ควรบันทึกจากเธรดเดียว

**จะเกิดอะไรขึ้นกับไฮเปอร์ลิงก์และไฟล์ที่ลิงก์ภายนอกเมื่อบันทึก?**

[Hyperlinks](/slides/th/androidjava/manage-hyperlinks/) จะถูกเก็บไว้ตามเดิม ไฟล์ที่ลิงก์จากภายนอก (เช่น วิดีโอที่อ้างอิงด้วยพาธสัมพันธ์) จะไม่ถูกคัดลอกอัตโนมัติ — ควรทำให้พาธที่อ้างอิงสามารถเข้าถึงได้

**ฉันสามารถตั้งค่า/บันทึกข้อมูลเมตาดาต้าเอกสาร (ผู้เขียน, ชื่อเรื่อง, บริษัท, วันที่) ได้หรือไม่?**

ใช่ คุณสมบัติเอกสารมาตรฐาน [document properties](/slides/th/androidjava/presentation-properties/) รองรับและจะถูกเขียนลงในไฟล์เมื่อบันทึก