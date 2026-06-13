---
title: จัดการตารางงานนำเสนอใน Java
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/java/manage-table/
keywords:
- เพิ่มตาราง
- สร้างตาราง
- เข้าถึงตาราง
- อัตราส่วน
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- รูปแบบตาราง
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Java ค้นหาตัวอย่างโค้ดง่าย ๆ เพื่อทำให้กระบวนการทำงานกับตารางของคุณราบรื่นขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพสำหรับการแสดงและถ่ายทอดข้อมูล ข้อมูลที่อยู่ในตารางของเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) นั้นเข้าใจง่ายและตรงไปตรงมา

Aspose.Slides ให้บริการคลาส [Table](https://reference.aspose.com/slides/th/java/com.aspose.slides/Table) อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) คลาส [Cell](https://reference.aspose.com/slides/th/java/com.aspose.slides/cell/) อินเทอร์เฟซ [ICell](https://reference.aspose.com/slides/th/java/com.aspose.slides/icell/) และชนิดอื่น ๆ เพื่อให้คุณสร้าง, อัปเดต, และจัดการตารางในงานนำเสนอทุกรูปแบบ

## **สร้างตารางจากศูนย์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. กำหนดอาร์เรย์ของ `columnWidth`  
4. กำหนดอาร์เรย์ของ `rowHeight`  
5. เพิ่มอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) ไปยังสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-)  
6. วนผ่านแต่ละ [ICell](https://reference.aspose.com/slides/th/java/com.aspose.slides/icell/) เพื่อกำหนดรูปแบบขอบบน, ขอบล่าง, ขอบขวา, และขอบซ้าย  
7. รวมเซลล์สองเซลล์แรกของแถวแรกของตาราง  
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) ของ [ICell](https://reference.aspose.com/slides/th/java/com.aspose.slides/icell/)  
9. เพิ่มข้อความบางส่วนไปยัง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/)  
10. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java นี้แสดงวิธีสร้างตารางในงานนำเสนอ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // เพิ่มรูปร่างตารางไปยังสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // รวมเซลล์ 1 และ 2 ของแถว 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // เพิ่มข้อความบางส่วนลงในเซลล์ที่รวมกัน
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การกำหนดลำดับในตารางมาตรฐาน**

ในตารางมาตรฐาน การกำหนดลำดับของเซลล์เป็นแบบศูนย์เริ่มต้น (zero‑based) เซลล์แรกของตารางจะถูกระบุเป็น 0,0 (คอลัมน์ 0, แถว 0)

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกนับลำดับดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

โค้ด Java นี้แสดงวิธีระบุลำดับของเซลล์ในตาราง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางไปยังสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การเข้าถึงตารางที่มีอยู่**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. ดึงอ้างอิงสไลด์ที่มีตารางผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) แล้วตั้งค่าเป็น null  
4. วนผ่านอ็อบเจกต์ทั้งหมดของ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) จนกว่าจะพบตาราง  

   ถ้าคุณสงสัยว่าสไลด์ที่กำลังทำงานอยู่มีเพียงตารางเดียว คุณสามารถตรวจสอบทุก shape ที่สไลด์มีได้ เมื่อพบ shape ที่ระบุเป็นตาราง คุณสามารถทำการ cast ให้เป็นอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/java/com.aspose.slides/Table) แต่หากสไลด์มีหลายตาราง คุณควรค้นหาตารางที่ต้องการผ่านเมธอด [setAlternativeText(String value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-)  

5. ใช้อ็อบเจกต์ [ITable] เพื่อทำงานกับตาราง ตัวอย่างด้านล่างเป็นการเพิ่มแถวใหม่ลงในตาราง  
6. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java นี้แสดงวิธีเข้าถึงและทำงานกับตารางที่มีอยู่:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดค่า null ให้ TableEx
    ITable tbl = null;

    // วนลูปผ่าน shapes และตั้งค่าอ้างอิงไปยังตารางที่พบ
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // ตั้งค่าข้อความสำหรับคอลัมน์แรกของแถวที่สอง
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดแนวข้อความในตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) ไปยังสไลด์  
4. เข้าถึงอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) จากตาราง  
5. เข้าถึง [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) ของ [ITextFrame]  
6. จัดแนวข้อความในแนวตั้ง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java นี้แสดงวิธีจัดแนวข้อความในตาราง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // เพิ่มรูปร่างตารางไปยังสไลด์
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // เข้าถึง text frame
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // สร้างอ็อบเจกต์ Paragraph สำหรับ text frame
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // สร้างอ็อบเจกต์ Portion สำหรับ paragraph
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // จัดแนวข้อความในแนวตั้ง
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **กำหนดการจัดรูปแบบข้อความระดับตาราง**

1. สร้างอินสแตนซ์ของ คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงอ็อบเจกต์ [ITable] จากสไลด์  
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับข้อความ  
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-)  
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java นี้แสดงวิธีใช้ตัวเลือกการจัดรูปแบบที่คุณต้องการกับข้อความในตาราง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // สมมติว่า shape แรกบนสไลด์แรกเป็นตาราง
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // ตั้งค่าความสูงของฟอนท์ในเซลล์ตาราง
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // ตั้งค่าการจัดแนวข้อความและระยะขอบขวาของเซลล์ตารางในคำสั่งเดียว
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // ตั้งค่าประเภทการจัดแนวข้อความในแนวตั้งของเซลล์ตาราง
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **รับคุณสมบัติสไตล์ของตาราง**

Aspose.Slides ให้คุณดึงคุณสมบัติสไตล์ของตารางเพื่อใช้รายละเอียดเหล่านั้นกับตารางอื่นหรือในที่อื่น โค้ด Java นี้แสดงวิธีดึงคุณสมบัติสไตล์จากสไตล์ตารางที่กำหนดล่วงหน้า:

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

## **ล็อกอัตราส่วนของตาราง**

อัตราส่วนของรูปทรงเรขาคณิตคืออัตราส่วนของขนาดในมิติที่ต่างกัน Aspose.Slides มีคุณสมบัติ [**setAspectRatioLocked**](https://reference.aspose.com/slides/th/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) เพื่อให้คุณล็อกการตั้งค่าอัตราส่วนสำหรับตารางและรูปทรงอื่น ๆ  

โค้ด Java นี้แสดงวิธีล็อกอัตราส่วนของตาราง:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // สลับ

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเปิดใช้งานการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ได้หรือไม่?**  

ใช่ ตารางมีเมธอด [setRightToLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/table/#setRightToLeft-boolean-) และย่อหน้ามี [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) การใช้ทั้งสองจะทำให้ลำดับ RTL ถูกต้องและแสดงผลภายในเซลล์ได้อย่างเหมาะสม  

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือเปลี่ยนขนาดของตารางในไฟล์สุดท้ายได้อย่างไร?**  

ใช้ [shape locks](/slides/th/java/applying-protection-to-presentation/) เพื่อปิดการย้าย, การปรับขนาด, การเลือก ฯลฯ ซึ่งล็อกเหล่านี้ใช้กับตารางด้วยเช่นกัน  

**การแทรกรูปภาพเป็นพื้นหลังภายในเซลล์รองรับหรือไม่?**  

ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/java/com.aspose.slides/picturefillformat/) สำหรับเซลล์; ภาพจะครอบบริเวณเซลล์ตามโหมดที่เลือก (ขยายหรือเรียงต่อกัน)  