---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนกลับใน Aspose.Slides for Java 14.8.0
linktitle: Aspose.Slides for Java 14.8.0
type: docs
weight: 70
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- การโยกย้าย
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการแบบดั้งเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดข้อผิดพลาดใน Aspose.Slides for Java เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="info" %}} 
หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ และอื่น ๆ ที่ [เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) ทั้งหมด, ข้อจำกัดใหม่ใด ๆ และ [การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) อื่น ๆ ที่แนะนำใน API Aspose.Slides for Java 14.8.0
{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **เพิ่ม Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() และเมธอด setOverlap(byte)**
Aspose.Slides.Charts.IChartSeries.getOverlap() จะคืนค่าการทับของแท่งและคอลัมน์ในแผนภูมิ 2 มิติ (ในช่วงจาก -100 ถึง 100).  
เมธอดนี้ไม่ใช่เพียงสำหรับซีรีส์เฉพาะแต่สำหรับทุกซีรีส์ในกลุ่มซีรีส์แม่ - นี่คือการฉายคุณสมบัติของกลุ่มที่เหมาะสม.  

- ใช้เมธอด IChartSeries.getParentSeriesGroup() เพื่อเข้าถึงกลุ่มซีรีส์แม่.  
- ใช้เมธอด IChartSeriesGroup.getOverlap() และ setOverlap(byte) เพื่อจัดการค่าดังกล่าว.  

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **เพิ่มค่า Enum ShapeThumbnailBounds.Appearance**
เมธอดนี้สำหรับการสร้างรูปย่อของรูปทรงช่วยให้นักพัฒนาสามารถสร้างรูปย่อของรูปทรงภายในขอบเขตของลักษณะที่ปรากฏของมันได้ โดยคำนึงถึงเอฟเฟ็กต์ของรูปทรงทั้งหมด. รูปย่อที่สร้างจะถูกจำกัดโดยขอบเขตของสไลด์.  

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **เพิ่มคลาส VbaProject และอินเทอร์เฟซ IVbaProject, แก้ไขเมธอด Presentation.getVbaProject() และ setVbaProject(VbaProject)**
ฟีเจอร์ใหม่นี้ทำให้นักพัฒนาสามารถสร้างและแก้ไขโครงการ VBA ในการนำเสนอได้.  

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// สร้าง VBA Project ใหม่

pres.setVbaProject(new VbaProject());

// เพิ่มโมดูลเปล่าลงใน VBA Project

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// ตั้งค่าโค้ดต้นฉบับของโมดูล

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// สร้างการอ้างอิงถึง <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// สร้างการอ้างอิงถึง Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// เพิ่มการอ้างอิงลงใน VBA Project

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);

```