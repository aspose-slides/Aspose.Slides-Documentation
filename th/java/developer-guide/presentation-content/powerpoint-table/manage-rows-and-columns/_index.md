---
title: จัดการแถวและคอลัมน์ในตาราง PowerPoint ด้วย Java
linktitle: แถวและคอลัมน์
type: docs
weight: 20
url: /th/java/manage-rows-and-columns/
keywords:
- แถวของตาราง
- คอลัมน์ของตาราง
- แถวแรก
- ส่วนหัวของตาราง
- คัดลอกแถว
- คัดลอกคอลัมน์
- คัดลอกแถว
- คัดลอกคอลัมน์
- ลบแถว
- ลบคอลัมน์
- การจัดรูปแบบข้อความในแถว
- การจัดรูปแบบข้อความในคอลัมน์
- สไตล์ของตาราง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย Aspose.Slides สำหรับ Java และเร่งการแก้ไขการนำเสนอและการอัปเดตข้อมูล."
---
## **บทนำ**

เพื่อให้คุณสามารถจัดการแถวและคอลัมน์ของตารางในงานนำเสนอ PowerPoint, Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/java/com.aspose.slides/table/) , อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) และประเภทอื่น ๆ อีกมากมาย. 

## **ตั้งค่าแถวแรกเป็นส่วนหัว**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และโหลดงานนำเสนอ. 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน. 
3. สร้างอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) แล้วตั้งค่าเป็น null. 
4. วนซ้ำผ่านอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) ทั้งหมดเพื่อค้นหาตารางที่เกี่ยวข้อง. 
5. ตั้งค่าแถวแรกของตารางเป็นส่วนหัวของตาราง. 

โค้ด Java นี้แสดงวิธีตั้งค่าแถวแรกของตารางเป็นส่วนหัว:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดค่าเริ่มต้นให้ TableEx เป็น null
    ITable tbl = null;

    // วนซ้ำผ่านรูปทรงทั้งหมดและตั้งค่าอ้างอิงไปยังตาราง
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //ตั้งค่าแถวแรกของตารางเป็นส่วนหัว
            tbl.setFirstRow(true);
        }
    }
    
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **คัดลอกแถวหรือคอลัมน์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และโหลดงานนำเสนอ, 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน. 
3. กำหนดอาร์เรย์ของ `columnWidth`. 
4. กำหนดอาร์เรย์ของ `rowHeight`. 
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) ไปยังสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. คัดลอกแถวของตาราง. 
7. คัดลอกคอลัมน์ของตาราง. 
8. บันทึกงานนำเสนอที่แก้ไข. 

โค้ด Java นี้แสดงวิธีคัดลอกแถวหรือคอลัมน์ของตาราง PowerPoint:

```java
 // สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // เพิ่มรูปร่างตารางไปยังสไลด์
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // เพิ่มข้อความบางส่วนลงในแถว 1 เซลล์ 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // เพิ่มข้อความบางส่วนลงในแถว 1 เซลล์ 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // ทำสำเนาแถว 1 ที่ตำแหน่งสุดท้ายของตาราง
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // เพิ่มข้อความบางส่วนลงในแถว 2 เซลล์ 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // เพิ่มข้อความบางส่วนลงในแถว 2 เซลล์ 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // ทำสำเนาแถว 2 เป็นแถวที่ 4 ของตาราง
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // ทำสำเนาคอลัมน์แรกที่ตำแหน่งสุดท้าย
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // ทำสำเนาคอลัมน์ที่ 2 ที่ตำแหน่งคอลัมน์ที่ 4
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบแถวหรือคอลัมน์จากตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และโหลดงานนำเสนอ, 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน. 
3. กำหนดอาร์เรย์ของ `columnWidth`. 
4. กำหนดอาร์เรย์ของ `rowHeight`. 
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) ไปยังสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. ลบแถวของตาราง. 
7. ลบคอลัมน์ของตาราง. 
8. บันทึกงานนำเสนอที่แก้ไข. 

โค้ด Java นี้แสดงวิธีลบแถวหรือคอลัมน์จากตาราง:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับแถวของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และโหลดงานนำเสนอ, 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน. 
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) ที่เกี่ยวข้องจากสไลด์. 
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) ของเซลล์แถวแรก. 
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) ของเซลล์แถวแรก. 
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) ของเซลล์แถวที่สอง. 
7. บันทึกงานนำเสนอที่แก้ไข. 

โค้ด Java นี้แสดงการทำงาน:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // ตั้งค่าความสูงของฟอนท์ในเซลล์แถวแรก
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // ตั้งค่าการจัดแนวข้อความและระยะขอบขวาของเซลล์แถวแรก
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // ตั้งค่าชนิดการจัดแนวข้อความแนวตั้งของเซลล์แถวที่สอง
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // บันทึกงานนำเสนอลงดิสก์
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับคอลัมน์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และโหลดงานนำเสนอ, 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน. 
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) ที่เกี่ยวข้องจากสไลด์. 
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) ของเซลล์คอลัมน์แรก. 
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) ของเซลล์คอลัมน์แรก. 
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) ของเซลล์คอลัมน์ที่สอง. 
7. บันทึกงานนำเสนอที่แก้ไข. 

โค้ด Java นี้แสดงการทำงาน: 

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // ตั้งค่าความสูงของฟอนท์ในเซลล์คอลัมน์แรก
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // ตั้งค่าการจัดแนวข้อความและระยะขอบขวาของเซลล์คอลัมน์แรกในหนึ่งคำสั่ง
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // ตั้งค่าชนิดการจัดแนวข้อความแนวตั้งของเซลล์คอลัมน์ที่สอง
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **รับคุณสมบัติสไตล์ของตาราง**

Aspose.Slides ให้คุณดึงคุณสมบัติสไตล์ของตารางเพื่อที่คุณจะได้นำรายละเอียดเหล่านั้นไปใช้กับตารางอื่นหรือที่อื่น โค้ด Java นี้แสดงวิธีรับคุณสมบัติสไตล์จากสไตล์ตารางที่กำหนดไว้ล่วงหน้า:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // เปลี่ยนธีม preset สไตล์เริ่มต้น
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ฉันสามารถใช้ธีม/สไตล์ PowerPoint กับตารางที่สร้างแล้วได้หรือไม่?**

ได้. ตารางสืบทอดธีมของสไลด์/เลย์เอาต์/มาสเตอร์, และคุณยังสามารถกำหนดค่าเติมสี, ขอบ, และสีข้อความให้เหนือธีมได้.

**ฉันสามารถเรียงลำดับแถวของตารางเหมือนใน Excel ได้หรือไม่?**

ไม่ได้, ตารางใน Aspose.Slides ไม่มีฟังก์ชันการเรียงลำดับหรือฟิลเตอร์ในตัว. ควรเรียงลำดับข้อมูลในหน่วยความจำก่อนแล้วค่อยเติมแถวตารางตามลำดับนั้น.

**ฉันสามารถทำคอลัมน์แบบมีลายเส้น (striped) พร้อมสีที่กำหนดเองในเซลล์เฉพาะได้หรือไม่?**

ได้. เปิดใช้งานคอลัมน์แบบมีลายเส้น, แล้วกำหนดรูปแบบเฉพาะให้กับเซลล์ที่ต้องการ; การกำหนดรูปแบบระดับเซลล์จะลำดับความสำคัญเหนือสไตล์ของตาราง.