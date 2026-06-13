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
- ประเภทมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชรูปย่อ
- บันทึกความคืบหน้า
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีการบันทึกการนำเสนอใน Java ด้วย Aspose.Slides สำหรับ Android—ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมคงรักษาเลย์เอาต์ ฟอนต์ และเอฟเฟกต์."
---
## **ภาพรวม**

[Open Presentations on Android](/slides/th/androidjava/open-presentation/) อธิบายวิธีการใช้คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เพื่อเปิดงานนำเสนอ บทความนี้อธิบายวิธีการสร้างและบันทึกงานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) มีเนื้อหาของงานนำเสนอ ไม่ว่าคุณจะสร้างงานนำเสนอจากศูนย์หรือแก้ไขงานที่มีอยู่ คุณก็ต้องการบันทึกเมื่อทำเสร็จแล้ว ด้วย Aspose.Slides สำหรับ Android คุณสามารถบันทึกเป็น **ไฟล์** หรือ **สตรีม** บทความนี้อธิบายวิธีต่าง ๆ ในการบันทึกงานนำเสนอ

## **บันทึกงานนำเสนอเป็นไฟล์**

บันทึกงานนำเสนอเป็นไฟล์โดยเรียกเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอด้วย Aspose.Slides

```java
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

## **บันทึกงานนำเสนอเป็นสตรีม**

คุณสามารถบันทึกงานนำเสนอเป็นสตรีมโดยส่งสตรีมผลลัพธ์ไปยังเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) งานนำเสนอสามารถเขียนไปยังสตรีมหลายประเภท ในตัวอย่างด้านล่าง เราสร้างงานนำเสนอใหม่และบันทึกลงสตรีมไฟล์

```java
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

## **บันทึกงานนำเสนอด้วยประเภทมุมมองที่กำหนดล่วงหน้า**

Aspose.Slides ให้คุณตั้งค่ามุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดงานนำเสนอที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/) ใช้เมธอด [setLastView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) พร้อมค่าจาก enumeration [ViewType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewtype/)

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกงานนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxoptions/) และตั้งค่า property conformance ขณะบันทึก หากคุณตั้งค่า [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างด้านล่างสร้างงานนำเสนอและบันทึกในรูปแบบ Strict Office Open XML

```java
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

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ Office Open XML เป็นไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดไฟล์ที่ไม่ได้บีบอัด, ขนาดไฟล์ที่บีบอัด, และขนาดรวมของไฟล์ ZIP ทั้งหมด รวมถึงจำกัดจำนวนไฟล์สูงสุดที่ 65 535 (2^16‑1) ไฟล์ ส่วนขยายรูปแบบ ZIP64 เพิ่มขีดจำกัดเหล่านี้เป็น 2^64

เมธอด [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) ให้คุณเลือกว่าจะใช้ส่วนขยายรูปแบบ ZIP64 เมื่อบันทึกไฟล์ Office Open XML หรือไม่

เมธอดนี้สามารถใช้กับโหมดต่อไปนี้:
- [IfNecessary](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/zip64mode/#IfNecessary) ใช้ส่วนขยาย ZIP64 เท่านั้นเมื่อขนาดงานนำเสนอเกินขีดจำกัดข้างต้น (เป็นค่าเริ่มต้น)
- [Never](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/zip64mode/#Never) ไม่ใช้ส่วนขยาย ZIP64 เลย
- [Always](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/zip64mode/#Always) ใช้ส่วนขยาย ZIP64 เสมอ

ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็น PPTX พร้อมเปิดใช้งานส่วนขยาย ZIP64

```java
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
เมื่อบันทึกด้วย [Zip64Mode.Never](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/zip64mode/#Never) จะเกิดข้อยกเว้น [PptxException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxexception/) หากงานนำเสนอไม่สามารถบันทึกในรูปแบบ ZIP32
{{% /alert %}}

## **บันทึกงานนำโดยไม่รีเฟรชรูปย่อ**

เมธอด [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) ควบคุมการสร้างรูปย่อเมื่อบันทึกงานนำเสนอเป็น PPTX:
- หากตั้งค่าเป็น `true` รูปย่อจะถูกรีเฟรชระหว่างบันทึก (เป็นค่าเริ่มต้น)
- หากตั้งค่าเป็น `false` รูปย่อปัจจุบันจะถูกเก็บไว้ หากงานนำเสนอไม่มีรูปย่อ จะไม่มีการสร้าง

ในโค้ดด้านล่าง งานนำเสนอจะถูกบันทึกเป็น PPTX โดยไม่รีเฟรชรูปย่อ

```java
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

## **บันทึกอัปเดตความคืบหน้าเป็นเปอร์เซ็นต์**

อินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprogresscallback/) ใช้ผ่านเมธอด `setProgressCallback` ที่เปิดให้ใช้โดยอินเทอร์เฟซ [ISaveOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isaveoptions/) และคลาสเชิงนามธรรม [SaveOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveoptions/) กำหนดการทำงานของ [IProgressCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprogresscallback/) ด้วย `setProgressCallback` เพื่อรับอัปเดตความคืบหน้าในการบันทึกเป็นเปอร์เซ็นต์

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้ `IProgressCallback`

```java
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
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // ใช้ค่าร้อยละของความคืบหน้าที่นี่.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose ได้พัฒนาแอป [free PowerPoint Splitter app](https://products.aspose.app/slides/th/splitter) ด้วย API ของตนเอง แอปนี้ช่วยให้คุณแยกงานนำเสนอออกเป็นไฟล์หลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รองรับการบันทึกเร็ว (บันทึกแบบเพิ่มส่วน) ที่เขียนเฉพาะการเปลี่ยนแปลงหรือไม่?**  
ไม่. การบันทึกจะสร้างไฟล์เป้าหมายเต็มรูปแบบทุกครั้ง; การบันทึกเร็วแบบเพิ่มส่วนไม่ได้รับการสนับสนุน

**สามารถบันทึกอินสแตนซ์ Presentation เดียวกันจากหลายเธรดได้อย่างปลอดภัยหรือไม่?**  
ไม่. อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ไม่ได้ออกแบบให้ทำงานแบบหลายเธรด; ควรบันทึกจากเธรดเดียว

**เกิดอะไรขึ้นกับไฮเปอร์ลิงก์และไฟล์ที่ลิงก์ภายนอกเมื่อบันทึก?**  
[Hyperlinks](/slides/th/androidjava/manage-hyperlinks/) จะถูกเก็บไว้ ไฟล์ที่ลิงก์ภายนอก (เช่น วิดีโอที่ใช้เส้นทางสัมพันธ์) จะไม่ถูกคัดลอกอัตโนมัติ — ควรตรวจสอบให้เส้นทางที่อ้างอิงยังคงเข้าถึงได้

**ฉันสามารถตั้งค่า/บันทึกเมทาดาต้าเอกสาร (ผู้เขียน, ชื่อเรื่อง, บริษัท, วันที่) ได้หรือไม่?**  
ได้. คุณสมบัติมาตรฐานของเอกสาร [document properties](/slides/th/androidjava/presentation-properties/) ได้รับการสนับสนุนและจะถูกเขียนลงไฟล์เมื่อบันทึก