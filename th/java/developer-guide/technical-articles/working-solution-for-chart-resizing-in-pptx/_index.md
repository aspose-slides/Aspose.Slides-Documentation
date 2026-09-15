---
title: วิธีแก้ไขที่ทำงานได้สำหรับการปรับขนาดแผนภูมิใน PPTX
type: docs
weight: 40
url: /th/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- การปรับขนาดแผนภูมิ
- แผนภูมิ Excel
- อ็อบเจกต์ OLE
- ฝังแผนภูมิ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "แก้ปัญหาการปรับขนาดแผนภูมิที่ไม่คาดคิดใน PPTX เมื่อใช้วัตถุ OLE ของ Excel ที่ฝังไว้ด้วย Aspose.Slides สำหรับ Java เรียนรู้สองวิธีพร้อมโค้ดเพื่อให้ขนาดคงที่"
---
## **ภูมิหลัง**

พบว่าแผนภูมิ Excel ที่ฝังเป็นอ็อบเจกต์ OLE ในงานนำเสนอ PowerPoint ผ่านคอมโพเนนต์ของ Aspose จะถูกปรับขนาดเป็นสเกลที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างทางสายตาที่เห็นได้ชัดในงานนำเสนอระหว่างสภาวะก่อนและหลังการเปิดใช้งานแผนภูมิ ทีมงาน Aspose ได้ตรวจสอบปัญหาอย่างละเอียดและพบวิธีแก้ ปบทความนี้อธิบายสาเหตุของปัญหาและการแก้ไขที่สอดคล้องกัน

ใน[บทความก่อนหน้า](/slides/th/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), เราอธิบายวิธีสร้างแผนภูมิ Excel ด้วย Aspose.Cells for Java และฝังลงในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides for Java เพื่อแก้ไข[ปัญหาการแสดงตัวอย่างอ็อบเจกต์](/slides/th/java/object-preview-issue-when-adding-oleobjectframe/), เราได้กำหนดภาพแผนภูมิให้กับกรอบอ็อบเจกต์ OLE ของแผนภูมิ ในงานนำเสนอผลลัพธ์ เมื่อคุณดับเบิลคลิกที่กรอบอ็อบเจกต์ OLE ที่แสดงภาพแผนภูมิ แผนภูมิ Excel จะถูกเปิดใช้งาน ผู้ใช้ขั้นสุดท้ายสามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการในเวิร์กบุ๊ก Excel ด้านล่างและจากนั้นกลับไปยังสไลด์ที่เกี่ยวข้องโดยคลิกนอกเวิร์กบุ๊กที่เปิดใช้งาน ขนาดของกรอบอ็อบเจกต์ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปยังสไลด์ และปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดเดิมของกรอบอ็อบเจกต์ OLE และเวิร์กบุ๊ก Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจากเวิร์กบุ๊ก Excel มีขนาดหน้าต่างของตนเอง มันพยายามรักษาขนาดเดิมไว้ในการเปิดใช้งานครั้งแรก อย่างไรก็ตามกรอบอ็อบเจกต์ OLE มีขนาดของมันเอง ตามที่ Microsoft ระบุ เมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดและรักษาอัตราส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง ขึ้นอยู่กับความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดหรือตำแหน่งของกรอบอ็อบเจกต์ OLE จะเกิดการปรับขนาด

## **วิธีแก้ที่ทำงานได้**

มีสองสถานการณ์ที่เป็นไปได้สำหรับการสร้างงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides for Java

**Scenario 1:** สร้างงานนำเสนอจากเทมเพลตที่มีอยู่

**Scenario 2:** สร้างงานนำตั้งแต่เริ่มต้น

วิธีแก้ที่เรานำเสนอที่นี่ใช้ได้กับทั้งสองสถานการณ์ พื้นฐานของแนวทางแก้ทั้งหมดเหมือนกัน: **ขนาดหน้าต่างของอ็อบเจกต์ OLE ที่ฝังควรตรงกับกรอบอ็อบเจกต์ OLE ในสไลด์ PowerPoint** เราจะหารือเกี่ยวกับสองแนวทางของวิธีแก้นี้ต่อไป

## **แนวทางแรก**

ในแนวทางนี้ เราจะเรียนรู้วิธีตั้งค่าขนาดหน้าต่างของเวิร์กบุ๊ก Excel ที่ฝังให้ตรงกับขนาดของกรอบอ็อบเจกต์ OLE ในสไลด์ PowerPoint

**Scenario 1**

สมมติว่าเราได้กำหนดเทมเพลตและต้องการสร้างงานนำเสนอจากเทมเพลตนั้น สมมติว่ามีรูปร่างที่ดัชนี 2 ในเทมเพลตที่เราต้องการวางกรอบ OLE ที่มีเวิร์กบุ๊ก Excel ฝังอยู่ ในสถานการณ์นี้ ขนาดของกรอบอ็อบเจกต์ OLE กำหนดไว้ล่วงหน้า – มีขนาดตรงกับรูปร่างที่ดัชนี 2 ในเทมเพลต ทุกอย่างที่เราต้องทำคือ ตั้งค่าขนาดหน้าต่างของเวิร์กบุ๊กให้เท่ากับขนาดของรูปร่างนั้น โค้ดตัวอย่างต่อไปนี้ทำหน้าที่นั้น:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// ตั้งค่าความกว้างหน้าต่างของเวิร์กบุ๊กเป็นนิ้ว (หารด้วย 72 เนื่องจาก PowerPoint ใช้ 72 จุดต่อหนึ่งนิ้ว).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// ตั้งค่าความสูงหน้าต่างของเวิร์กบุ๊กเป็นนิ้ว.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// บันทึกเวิร์กบุ๊กไปยังสตรีมหน่วยความจำ.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// สร้างกรอบอ็อบเจกต์ OLE พร้อมข้อมูล Excel ที่ฝังไว้.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**

สมมติว่าเราต้องการสร้างงานนำเสนอจากศูนย์และใส่กรอบอ็อบเจกต์ OLE ขนาดใดก็ได้พร้อมกับเวิร์กบุ๊ก Excel ที่ฝังไว้ ในโค้ดตัวอย่างต่อไปนี้ เราจะสร้างกรอบอ็อบเจกต์ OLE ที่สูง 4 นิ้วและกว้าง 9.5 นิ้ว ที่ตำแหน่ง x = 0.5 นิ้วและ y = 1 นิ้วบนสไลด์ จากนั้นเราตั้งค่าหน้าต่างเวิร์กบุ๊ก Excel ให้มีขนาดเท่ากัน – สูง 4 นิ้วและกว้าง 9.5 นิ้ว

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// ความสูงที่ต้องการของเรา.
int desiredHeight = 288; // 4 นิ้ว (4 * 72)
 
// ความกว้างที่ต้องการของเรา.
int desiredWidth = 684; // 9.5 นิ้ว (9.5 * 72)
 
// กำหนดขนาดแผนภูมิพร้อมหน้าต่าง.
chart.setSizeWithWindow(true);
 
// ตั้งค่าความกว้างหน้าต่างของเวิร์กบุ๊กเป็นนิ้ว (หารด้วย 72 เนื่องจาก PowerPoint ใช้ 72 จุดต่อหนึ่งนิ้ว).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// ตั้งค่าความสูงหน้าต่างของเวิร์กบุ๊กเป็นนิ้ว.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// บันทึกเวิร์กบุ๊กไปยังสตรีมหน่วยความจำ.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// สร้างกรอบอ็อบเจกต์ OLE พร้อมข้อมูล Excel ที่ฝังไว้.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 นิ้ว (0.5 * 72)
    72,  // y = 1 นิ้ว (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **แนวทางที่สอง**

ในแนวทางนี้ เราจะเรียนรู้วิธีตั้งค่าขนาดของแผนภูมิในเวิร์กบุ๊ก Excel ที่ฝังให้ตรงกับขนาดของกรอบอ็อบเจกต์ OLE ในสไลด์ PowerPoint แนวทางนี้มีประโยชน์เมื่อขนาดของแผนภูมิทราบล่วงหน้าและจะไม่เปลี่ยนแปลง

**Scenario 1**

สมมติว่าเราได้กำหนดเทมเพลตและต้องการสร้างงานนำเสนอจากเทมเพลตนั้น สมมติว่ามีรูปร่างที่ดัชนี 2 ในเทมเพลตที่เราตั้งใจจะวางกรอบ OLE ที่มีเวิร์กบุ๊ก Excel ฝังอยู่ ในสถานการณ์นี้ ขนาดกรอบ OLE ถูกกำหนดไว้ล่วงหน้า – ตรงกับขนาดของรูปร่างที่ดัชนี 2 ในเทมเพลต ทุกอย่างที่เราต้องทำคือ ตั้งค่าขนาดแผนภูมิในเวิร์กบุ๊กให้เท่ากับขนาดของรูปร่างนั้น โค้ดตัวอย่างต่อไปนี้ทำหน้าที่นั้น:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// กำหนดขนาดแผนภูมิโดยไม่ใช้หน้าต่าง.
chart.setSizeWithWindow(false);
 
// กำหนดความกว้างของแผนภูมิเป็นพิกเซล (คูณด้วย 96 เนื่องจาก Excel ใช้ 96 พิกเซลต่อหนึ่งนิ้ว).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// กำหนดความสูงของแผนภูมิเป็นพิกเซล.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// กำหนดขนาดการพิมพ์ของแผนภูมิ.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// บันทึกเวิร์กบุ๊กไปยังสตรีมหน่วยความจำ.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// สร้างกรอบอ็อบเจกต์ OLE พร้อมข้อมูล Excel ที่ฝังไว้.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**

สมมติว่าเราต้องการสร้างงานนำตั้งแต่เริ่มต้นและใส่กรอบอ็อบเจกต์ OLE ขนาดใดก็ได้พร้อมกับเวิร์กบุ๊ก Excel ที่ฝังไว้ ในโค้ดตัวอย่างต่อไปนี้ เราจะสร้างกรอบอ็อบเจกต์ OLE ที่สูง 4 นิ้วและกว้าง 9.5 นิ้วบนสไลด์ที่ตำแหน่ง x = 0.5 นิ้วและ y = 1 นิ้ว เราตั้งค่าขนาดแผนภูมิที่สอดคล้องให้มีขนาดเท่ากัน – สูง 4 นิ้วและกว้าง 9.5 นิ้ว

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// ความสูงที่ต้องการของเรา.
int desiredHeight = 288; // 4 นิ้ว (4 * 72)
 
// ความกว้างที่ต้องการของเรา.
int desiredWidth = 684; // 9.5 นิ้ว (9.5 * 72)
 
// กำหนดขนาดแผนภูมิโดยไม่ใช้หน้าต่าง.
chart.setSizeWithWindow(false);
 
// กำหนดความกว้างของแผนภูมิเป็นพิกเซล (หารด้วย 72 เพื่อให้เป็นนิ้ว, คูณด้วย 96 เนื่องจาก Excel ใช้ 96 พิกเซลต่อหนึ่งนิ้ว).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// กำหนดความสูงของแผนภูมิเป็นพิกเซล.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// บันทึกเวิร์กบุ๊กไปยังสตรีมหน่วยความจำ.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// สร้างกรอบอ็อบเจกต์ OLE พร้อมข้อมูล Excel ที่ฝังไว้.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 นิ้ว (0.5 * 72)
    72,  // y = 1 นิ้ว (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **สรุป**

มีสองแนวทางเพื่อแก้ไขปัญหาการปรับขนาดของแผนภูมิ การเลือกแนวทางขึ้นอยู่กับความต้องการและกรณีการใช้งาน ทั้งสองแนวทางทำงานเช่นเดียวกันไม่ว่าจะสร้างงานนำเสนอจากเทมเพลตหรือจากศูนย์ อีกทั้งไม่มีข้อจำกัดเรื่องขนาดของกรอบอ็อบเจกต์ OLE ในวิธีแก้นี้

## **FAQ**

### ทำไมแผนภูมิ Excel ที่ฝังอยู่ของฉันถึงเปลี่ยนขนาดหลังจากเปิดใช้งานใน PowerPoint?

เกิดจาก Excel พยายามคืนค่าขนาดหน้าต่างเดิมเมื่อเปิดใช้งานครั้งแรก ในขณะที่กรอบอ็อบเจกต์ OLE ใน PowerPoint มีมิตของตนเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วน ซึ่งอาจทำให้เกิดการปรับขนาด

### สามารถป้องกันปัญหาการปรับขนาดนี้ได้ทั้งหมดหรือไม่?

ได้ โดยการทำให้ขนาดหน้าต่างของเวิร์กบุ๊ก Excel หรือขนาดแผนภูมิตรงกับขนาดของกรอบอ็อบเจกต์ OLE ก่อนทำการฝัง คุณสามารถรักษาขนาดของแผนภูมิให้คงที่ได้

### ควรเลือกใช้แนวทางใด ระหว่างการตั้งค่าขนาดหน้าต่างของเวิร์กบุ๊กหรือการตั้งค่าขนาดของแผนภูมิ?

ใช้ **แนวทางที่ 1 (ขนาดหน้าต่าง)** หากคุณต้องการรักษาอัตราส่วนของเวิร์กบุ๊กและอาจอนุญาตให้ปรับขนาดในภายหลัง  
ใช้ **แนวทางที่ 2 (ขนาดแผนภูมิ)** หากขนาดของแผนภูมิคงที่และจะไม่เปลี่ยนแปลงหลังการฝัง

### วิธีการเหล่านี้จะทำงานกับงานนำเสนอที่สร้างจากเทมเพลตและงานนำเสนอใหม่ได้หรือไม่?

ใช้ได้ ทั้งสองแนวทางทำงานเช่นเดียวกันสำหรับงานนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

### มีขนาดจำกัดของกรอบอ็อบเจกต์ OLE หรือไม่?

ไม่มี คุณสามารถตั้งค่ากรอบ OLE ให้มีขนาดใดก็ได้ตราบใดที่ขนาดนั้นสเกลอย่างเหมาะสมกับเวิร์กบุ๊กหรือแผนภูมิ

### สามารถใช้วิธีเหล่านี้กับแผนภูมิที่สร้างในโปรแกรมสเปรดชีตอื่นได้หรือไม่?

ตัวอย่างออกแบบมาสำหรับแผนภูมิ Excel ที่สร้างด้วย Aspose.Cells แต่หลักการสามารถนำไปใช้กับโปรแกรมสเปรดชีตอื่นที่รองรับ OLE และมีตัวเลือกการกำหนดขนาดที่คล้ายกันได้

## **ส่วนที่เกี่ยวข้อง**

- [สร้างแผนภูมิ Excel และฝังเป็นอ็อบเจกต์ OLE ในงานนำเสนอ](/slides/th/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)