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
- รีเฟรชภาพตัวอย่าง
- การบันทึกความคืบหน้า
- Java
- Aspose.Slides
description: "ค้นพบวิธีบันทึกงานนำเสนอใน Java โดยใช้ Aspose.Slides—ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมคงรักษาเค้าโครง, ฟอนต์ และเอฟเฟกต์."
---
## **ภาพรวม**

[Open Presentations in Java](/slides/th/java/open-presentation/) บรรยายวิธีใช้คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เพื่อเปิดงานนำเสนอ บทความนี้อธิบายวิธีสร้างและบันทึกงานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) มีเนื้อหาของงานนำเสนอ ไม่ว่าคุณจะสร้างงานนำตั้งแต่ต้นหรือแก้ไขงานที่มีอยู่แล้ว คุณจะต้องบันทึกเมื่อทำเสร็จ ด้วย Aspose.Slides for Java คุณสามารถบันทึกเป็น **file** หรือ **stream** บทความนี้อธิบายวิธีต่าง ๆ ในการบันทึกงานนำเสนอ

## **บันทึกงานนำเสนอเป็นไฟล์**

บันทึกงานนำเสนอเป็นไฟล์โดยเรียกเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/). ส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอด้วย Aspose.Slides

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ทำงานบางอย่างที่นี่...

    // บันทึกงานนำเสนอเป็นไฟล์
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอเป็นสตรีม**

คุณสามารถบันทึกงานนำเสนอเป็นสตรีมโดยส่ง output stream ไปยังเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/). งานนำเสนอสามารถเขียนไปยังสตรีมหลายประเภท ในตัวอย่างด้านล่าง เราสร้างงานนำเสนอใหม่และบันทึกเป็นไฟล์สตรีม

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // บันทึกงานนำเสนอไปยังสตรีม
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอด้วยมุมมองที่กำหนดไว้ล่วงหน้า**

Aspose.Slides ให้คุณตั้งค่ามุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดงานนำเสนอที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewproperties/). ใช้เมธอด [setLastView](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewproperties/#setLastView-int-) พร้อมค่าจาก enumeration [ViewType](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewtype/)

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

Aspose.Slides ให้คุณบันทึกงานนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxoptions/) แล้วตั้งค่าคุณสมบัติ conformance ขณะบันทึก หากคุณตั้งค่า [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) ไฟล์เอาต์พุตจะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างด้านล่างสร้างงานนำเสนอและบันทึกในรูปแบบ Strict Office Open XML

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ Office Open XML เป็นไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดที่ไม่ได้บีบอัดของไฟล์ใด ๆ, ขนาดที่บีบอัดของไฟล์ใด ๆ, และขนาดรวมของไฟล์สำรอง นอกจากนี้ยังจำกัดจำนวนไฟล์ในอาร์ไคฟ์ไว้ที่ 65 535 (2^16-1) ไฟล์ ส่วนส่วนขยายรูปแบบ ZIP64 จะเพิ่มขีดจำกัดเหล่านี้เป็น 2^64

เมธอด [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) ให้คุณเลือกว่าจะใช้ส่วนขยายรูปแบบ ZIP64 หรือไม่ขณะบันทึกไฟล์ Office Open XML

เมธอดนี้สามารถใช้ร่วมกับโหมดต่อไปนี้:

- [IfNecessary](https://reference.aspose.com/slides/th/java/com.aspose.slides/zip64mode/#IfNecessary) ใช้ส่วนขยายรูปแบบ ZIP64 เฉพาะเมื่อไฟล์นำเสนอเกินขีดจำกัดด้านบน นี่คือโหมดเริ่มต้น
- [Never](https://reference.aspose.com/slides/th/java/com.aspose.slides/zip64mode/#Never) ไม่ใช้ส่วนขยายรูปแบบ ZIP64 เลย
- [Always](https://reference.aspose.com/slides/th/java/com.aspose.slides/zip64mode/#Always) ใช้ส่วนขยายรูปแบบ ZIP64 เสมอ

โค้ดต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็น PPTX พร้อมเปิดใช้งานส่วนขยายรูปแบบ ZIP64:

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
เมื่อคุณบันทึกด้วย [Zip64Mode.Never](https://reference.aspose.com/slides/th/java/com.aspose.slides/zip64mode/#Never) จะเกิด [PptxException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxexception/) หากงานนำเสนอไม่สามารถบันทึกในรูปแบบ ZIP32
{{% /alert %}}

## **บันทึกงานนำเสนอโดยไม่รีเฟรชภาพตัวอย่าง**

เมธอด [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) ควบคุมการสร้างภาพตัวอย่างเมื่อบันทึกงานนำเสนอเป็น PPTX:

- หากตั้งค่าเป็น `true` ภาพตัวอย่างจะถูกรีเฟรชระหว่างการบันทึก นี่คือค่าเริ่มต้น
- หากตั้งค่าเป็น `false` ภาพตัวอย่างปัจจุบันจะถูกเก็บไว้ หากงานนำเสนอไม่มีภาพตัวอย่าง จะไม่สร้างภาพใหม่

ในโค้ดด้านล่าง งานนำเสนอจะถูบันทึกเป็น PPTX โดยไม่รีเฟรชภาพตัวอย่างของมัน

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
ตัวเลือกนี้ช่วยลดเวลาที่ใช้ในการบันทึกงานนำเสนอเป็นรูปแบบ PPTX
{{% /alert %}}

## **บันทึกการอัปเดตความคืบหน้าเป็นเปอร์เซ็นต์**

อินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/) ถูกใช้ผ่านเมธอด `setProgressCallback` ของอินเทอร์เฟซ [ISaveOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/isaveoptions/) และคลาสแบบ abstract [SaveOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveoptions/). กำหนดการทำงานของ [IProgressCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/) ด้วย `setProgressCallback` เพื่อรับการอัปเดตความคืบหน้าในการบันทึกเป็นเปอร์เซ็นต์

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
Aspose ได้พัฒนาแอป [free PowerPoint Splitter app](https://products.aspose.app/slides/th/splitter) ด้วย API ของตัวเอง แอปนี้ช่วยให้คุณแยกงานนำเสนอเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รองรับ “fast save” (การบันทึกแบบเพิ่มส่วน) เพื่อบันทึกเฉพาะการเปลี่ยนแปลงหรือไม่?**

ไม่. การบันทึกจะสร้างไฟล์เป้าหมายเต็มทุกครั้ง; การบันทึกแบบ “fast save” แบบเพิ่มส่วนไม่รองรับ

**การบันทึกอินสแตนซ์ Presentation เดียวจากหลายเธรดปลอดภัยหรือไม่?**

ไม่. อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) [ไม่ได้รองรับการทำงานหลายเธรด](/slides/th/java/multithreading/); ควรบันทึกจากเธรดเดียว

**อะไรจะเกิดขึ้นกับไฮเปอร์ลิงก์และไฟล์ที่เชื่อมโยงจากภายนอกเมื่อบันทึก?**

[Hyperlinks](/slides/th/java/manage-hyperlinks/) จะถูกเก็บไว้ ส่วนไฟล์ที่เชื่อมโยงภายนอก (เช่นวิดีโอโดยใช้เส้นทางสัมพันธ์) จะไม่ถูกคัดลอกโดยอัตโนมัติ—ตรวจสอบให้แน่ใจว่าเส้นทางที่อ้างอิงยังคงสามารถเข้าถึงได้

**ฉันสามารถตั้งค่า/บันทึกข้อมูลเมตาดาต้าเอกสาร (ผู้เขียน, ชื่อเรื่อง, บริษัท, วันที่) ได้หรือไม่?**

ได้. คุณสมบัติเอกสารมาตรฐาน [document properties](/slides/th/java/presentation-properties/) ได้รับการสนับสนุนและจะถูกเขียนลงในไฟล์เมื่อบันทึก