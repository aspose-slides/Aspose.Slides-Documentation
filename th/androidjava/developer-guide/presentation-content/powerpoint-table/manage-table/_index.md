---
title: จัดการตารางการนำเสนอใน Android
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/androidjava/manage-table/
keywords:
- เพิ่มตาราง
- สร้างตาราง
- เข้าถึงตาราง
- อัตราส่วน
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Android. ค้นพบตัวอย่างโค้ด Java อย่างง่ายเพื่อทำให้กระบวนการทำงานกับตารางของคุณเป็นระเบียบขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและถ่ายทอดข้อมูล ข้อมูลในกริดของเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) มีความชัดเจนและเข้าใจง่าย.

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Table) คลาส, อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) อินเทอร์เฟซ, คลาส [Cell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cell/) คลาส, อินเทอร์เฟซ [ICell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icell/) อินเทอร์เฟซ, และชนิดอื่น ๆ เพื่อให้คุณสร้าง, ปรับปรุง, และจัดการตารางในงานนำเสนอทุกประเภท.

## **สร้างตารางจากศูนย์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) .
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. กำหนดอาร์เรย์ของ `columnWidth`.
4. กำหนดอาร์เรย์ของ `rowHeight`.
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) ไปยังสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. วนซ้ำผ่านแต่ละ [ICell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icell/) เพื่อกำหนดรูปแบบให้กับขอบบน, ขอบล่าง, ขอบขวา, และขอบซ้าย.
7. ผสานเซลล์สองเซลล์แรกของแถวแรกของตาราง. 
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) ของ [ICell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icell/).
9. เพิ่มข้อความบางส่วนไปยัง [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/).
10. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Java นี้แสดงให้คุณเห็นวิธีสร้างตารางในงานนำเสนอ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์โดยระบุความกว้างและแถวโดยระบุความสูง
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // กำหนดรูปแบบเส้นขอบสำหรับแต่ละเซลล์
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
    // รวมเซลล์ที่ 1 และ 2 ของแถวที่ 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // เพิ่มข้อความลงในเซลล์ที่รวมแล้ว
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การกำหนดหมายเลขในตารางมาตรฐาน**

ในตารางมาตรฐาน การตั้งหมายเลขของเซลล์เป็นเรื่องตรงไปตรงมาที่เริ่มจากศูนย์ เซลล์แรกในตารางมีดัชนีเป็น 0,0 (คอลัมน์ 0, แถว 0). 

สำหรับตัวอย่าง เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกนับเลขดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

โค้ด Java นี้แสดงให้คุณเห็นวิธีกำหนดหมายเลขสำหรับเซลล์ในตาราง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์โดยระบุความกว้างและแถวโดยระบุความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // กำหนดรูปแบบเส้นขอบสำหรับแต่ละเซลล์
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

## **เข้าถึงตารางที่มีอยู่**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) .
2. รับอ้างอิงสไลด์ที่มีตารางผ่านดัชนีของมัน. 
3. สร้างอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) แล้วตั้งค่าเป็น null.
4. วนซ้ำผ่านอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) ทั้งหมดจนกว่าตารางจะถูกพบ.

   หากคุณสงสัยว่าสไลด์ที่คุณกำลังทำงานอยู่มีเพียงตารางเดียว คุณสามารถตรวจสอบรูปร่างทั้งหมดที่สไลด์มีได้อย่างง่ายดาย เมื่อรูปร่างถูกระบุว่าเป็นตาราง คุณสามารถแปลงประเภทเป็นอ็อบเจ็กต์ [Table](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Table) ได้ แต่หากสไลด์นั้นมีหลายตาราง คุณควรค้นหาตารางที่ต้องการผ่านเมธอด [setAlternativeText(String value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. ใช้อ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) เพื่อทำงานกับตาราง ในตัวอย่างด้านล่าง เราได้เพิ่มแถวใหม่ลงในตาราง.
6. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Java นี้แสดงให้คุณเห็นวิธีเข้าถึงและทำงานกับตารางที่มีอยู่:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดค่าเริ่มต้นให้ TableEx เป็น null
    ITable tbl = null;

    // วนลูปผ่านรูปร่างและตั้งค่าอ้างอิงไปยังตารางที่พบ
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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) .
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) ไปยังสไลด์.
4. เข้าถึงอ็อบเจ็กต์ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) จากตาราง.
5. เข้าถึง [IParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/) ของ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/).
6. จัดแนวข้อความในแนวตั้ง.
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Java นี้แสดงให้คุณเห็นวิธีจัดแนวข้อความในตาราง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // เข้าถึงกรอบข้อความ
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // สร้างอ็อบเจ็กต์ Paragraph สำหรับกรอบข้อความ
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // สร้างอ็อบเจ็กต์ Portion สำหรับย่อหน้า
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

## **กำหนดรูปแบบข้อความในระดับตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) .
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) จากสไลด์.
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับข้อความ.
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

โค้ด Java นี้แสดงให้คุณเห็นวิธีนำตัวเลือกการจัดรูปแบบที่คุณต้องการไปใช้กับข้อความในตาราง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // กำหนดความสูงของตัวอักษรในเซลล์ตาราง
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // กำหนดการจัดแนวข้อความและระยะขอบขวาของเซลล์ตารางในหนึ่งคำสั่ง
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // กำหนดประเภทการวางข้อความในแนวตั้งของเซลล์ตาราง
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **รับคุณสมบัติสไตล์ของตาราง**

Aspose.Slides ให้คุณดึงคุณสมบัติสไตล์ของตารางเพื่อที่คุณสามารถใช้รายละเอียดเหล่านั้นกับตารางอื่นหรือที่อื่นได้ โค้ด Java นี้แสดงให้คุณเห็นวิธีดึงคุณสมบัติสไตล์จากสไตล์ที่กำหนดของตาราง:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // เปลี่ยนธีมสไตล์ preset เริ่มต้น
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ล็อคอัตราส่วนของตาราง**

อัตราส่วนของรูปทรงเรขาคณิตคืออัตราส่วนของขนาดในมิติที่ต่างกัน Aspose.Slides มีคุณสมบัติ [**setAspectRatioLocked**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) เพื่อให้คุณล็อคการตั้งค่าอัตราส่วนสำหรับตารางและรูปทรงอื่น ๆ

โค้ด Java นี้แสดงให้คุณเห็นวิธีล็อคอัตราส่วนสำหรับตาราง:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // สลับค่า

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเปิดใช้งานทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ของมันได้ไหม?**

ได้. ตารางมีเมธอด [setRightToLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) และย่อหน้ามี [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) การใช้ทั้งสองจะทำให้ลำดับ RTL ถูกต้องและการเรนเดอร์ภายในเซลล์เป็นไปอย่างถูกต้อง.

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**

ใช้การล็อกรูปทรงเพื่อปิดการย้าย, ปรับขนาด, การเลือก ฯลฯ การล็อกเหล่านี้ใช้กับตารางด้วยเช่นกัน.

**การแทรกรูภาพภายในเซลล์เป็นพื้นหลังได้รับการสนับสนุนหรือไม่?**

ได้. คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/picturefillformat/) สำหรับเซลล์; ภาพจะครอบคลุมพื้นที่เซลล์ตามโหมดที่เลือก (ขยายหรือเรียงต่อกัน).