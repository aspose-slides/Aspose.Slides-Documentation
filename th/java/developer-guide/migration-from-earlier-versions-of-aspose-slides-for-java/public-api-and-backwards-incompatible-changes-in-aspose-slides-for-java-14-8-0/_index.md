---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 14.8.0
linktitle: Aspose.Slides for Java 14.8.0
type: docs
weight: 70
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- วิธีการเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้ไม่เข้ากันใน Aspose.Slides for Java เพื่อย้ายโซลูชั่นการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 
หน้านี้แสดงรายการทั้งหมด [เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) ของคลาส, เมธอด, คุณสมบัติ ฯลฯ, ข้อจำกัดใหม่ใด ๆ และ [การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) ที่แนะนำพร้อมกับ Aspose.Slides for Java 14.8.0 API.
{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **เพิ่มเมธอด Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap(), และ setOverlap(byte) Methods**
Aspose.Slides.Charts.IChartSeries.getOverlap() จะคืนค่าระดับการทับซ้อนของแท่งและคอลัมน์บนแผนภูมิ 2D (ในช่วงจาก -100 ถึง 100).
เมธอดนี้ไม่ใช่สำหรับซีรีส์เฉพาะเท่านั้น แต่สำหรับซีรีส์ทั้งหมดของกลุ่มซีรีส์แม่ – นี้เป็นการฉายคุณสมบัติของกลุ่มที่เหมาะสม.

- ใช้เมธอด IChartSeries.getParentSeriesGroup() เพื่อเข้าถึงกลุ่มซีรีส์แม่.
- ใช้เมธอด IChartSeriesGroup.getOverlap() และ setOverlap(byte) เพื่อจัดการค่าดังกล่าว.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **เพิ่มค่า Enum ShapeThumbnailBounds.Appearance**
วิธีการสร้างรูปย่อของรูปร่างนี้ช่วยให้นักพัฒนาสามารถสร้างรูปย่อของรูปร่างในขอบเขตของการแสดงผลของมันได้ พิจารณาผลกระทบของรูปร่างทั้งหมด รูปย่อที่สร้างขึ้นจะถูกจำกัดโดยขอบเขตของสไลด์.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **เพิ่มคลาส VbaProject และอินเทอร์เฟซ IVbaProject, ปรับเปลี่ยนเมธอด Presentation.getVbaProject() และ setVbaProject(VbaProject)**
ฟีเจอร์ใหม่ช่วยให้นักพัฒนาสามารถสร้างและแก้ไขโครงการ VBA ในงานนำเสนอได้.

``` java

 Presentation pres = new Presentation();

// สร้างโครงการ VBA ใหม่

pres.setVbaProject(new VbaProject());

// เพิ่มโมดูลว่างไปยังโครงการ VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// ตั้งค่าโค้ดต้นฉบับของโมดูล

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// สร้างอ้างอิงไปยัง <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// สร้างอ้างอิงไปยัง Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// เพิ่มอ้างอิงไปยังโครงการ VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```