---
title: จัดการแถวและคอลัมน์ในตาราง PowerPoint บน Android
linktitle: แถวและคอลัมน์
type: docs
weight: 20
url: /th/androidjava/manage-rows-and-columns/
keywords:
- แถวตาราง
- คอลัมน์ตาราง
- แถวแรก
- ส่วนหัวของตาราง
- คัดลอกแถว
- คัดลอกคอลัมน์
- คัดลอกแถว
- คัดลอกคอลัมน์
- ลบแถว
- ลบคอลัมน์
- การจัดรูปแบบข้อความของแถว
- การจัดรูปแบบข้อความของคอลัมน์
- สไตล์ตาราง
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java และเร่งการแก้ไขงานนำเสนอและการอัปเดตข้อมูล."
---
## **บทนำ**

เพื่อให้คุณสามารถจัดการแถวและคอลัมน์ของตารางในงานนำเสนอ PowerPoint ได้, Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/table/) อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) และประเภทอื่น ๆ อีกมากมาย

## **ตั้งแถวแรกเป็นส่วนหัว**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วโหลดงานนำเสนอ
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. สร้างอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) แล้วกำหนดค่าเป็น null
4. วนลูปผ่านอ็อบเจ็กต์ทั้งหมดของ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) เพื่อค้นหาตารางที่ต้องการ
5. ตั้งค่าแถวแรกของตารางเป็นส่วนหัวของตาราง

โค้ด Java นี้แสดงวิธีตั้งค่าแถวแรกของตารางเป็นส่วนหัว:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เริ่มต้น TableEx ที่เป็น null
    ITable tbl = null;

    // วนลูปผ่านรูปร่างทั้งหมดและตั้งค่าอ้างอิงไปยังตาราง
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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วโหลดงานนำเสนอ
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. กำหนดอาเรย์ของ `columnWidth`
4. กำหนดอาเรย์ของ `rowHeight`
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) ลงในสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---)
6. คัดลอกแถวของตาราง
7. คัดลอกคอลัมน์ของตาราง
8. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้แสดงวิธีคัดลอกแถวหรือคอลัมน์ของตาราง PowerPoint:

```java
 // สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // เพิ่มรูปร่างตารางลงสไลด์
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // เพิ่มข้อความบางส่วนลงในแถว 1 เซลล์ 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // เพิ่มข้อความบางส่วนลงในแถว 1 เซลล์ 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // คัดลอกแถว 1 ที่ตำแหน่งสุดท้ายของตาราง
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // เพิ่มข้อความบางส่วนลงในแถว 2 เซลล์ 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // เพิ่มข้อความบางส่วนลงในแถว 2 เซลล์ 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // คัดลอกแถว 2 เป็นแถวที่ 4 ของตาราง
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // คัดลอกคอลัมน์แรกที่ตำแหน่งสุดท้าย
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // คัดลอกคอลัมน์ที่ 2 ที่ตำแหน่งคอลัมน์ที่ 4
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบแถวหรือคอลัมน์ออกจากตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วโหลดงานนำเสนอ
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. กำหนดอาเรย์ของ `columnWidth`
4. กำหนดอาเรย์ของ `rowHeight`
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) ลงในสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---)
6. ลบแถวของตาราง
7. ลบคอลัมน์ของตาราง
8. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้แสดงวิธีลบแถวหรือคอลัมน์ออกจากตาราง:

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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วโหลดงานนำเสนอ
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) ที่เกี่ยวข้องจากสไลด์
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) ของเซลล์ในแถวแรก
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) ของเซลล์ในแถวแรก
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) ของเซลล์ในแถวที่สอง
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้แสดงการดำเนินการ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // ตั้งค่าสูงของฟอนต์ในเซลล์ของแถวแรก
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // ตั้งค่าการจัดแนวข้อความและระยะขอบด้านขวาของเซลล์ในแถวแรก
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // ตั้งค่าชนิดข้อความแนวตั้งของเซลล์ในแถวที่สอง
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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วโหลดงานนำเสนอ
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) ที่เกี่ยวข้องจากสไลด์
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) ของเซลล์ในคอลัมน์แรก
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) ของเซลล์ในคอลัมน์แรก
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) ของเซลล์ในคอลัมน์ที่สอง
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้แสดงการดำเนินการ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // ตั้งค่าสูงของฟอนต์ในเซลล์ของคอลัมน์แรก
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // ตั้งค่าการจัดแนวข้อความและระยะขอบด้านขวาของเซลล์ในคอลัมน์แรกในคำสั่งเดียว
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // ตั้งค่าชนิดข้อความแนวตั้งของเซลล์ในคอลัมน์ที่สอง
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **รับคุณสมบัติรูปแบบของตาราง**

Aspose.Slides ให้คุณดึงคุณสมบัติรูปแบบของตารางเพื่อที่คุณจะนำรายละเอียดเหล่านั้นไปใช้กับตารางอื่นหรือที่อื่น โค้ด Java นี้แสดงวิธีรับคุณสมบัติรูปแบบจากสไตล์ตารางที่กำหนดไว้ล่วงหน้า:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // เปลี่ยนธีมสไตล์พรีเซ็ตเริ่มต้น
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมหรือสไตล์ของ PowerPoint กับตารางที่สร้างแล้วได้หรือไม่?**

ได้ ตารางสืบทอดธีมของสไลด์/เลเอาต์/มาสเตอร์ และคุณยังสามารถกำหนดค่าสีเติม, สีขอบ, และสีข้อความทับบนธีมนั้นได้

**ฉันสามารถเรียงลำดับแถวของตารางเหมือนใน Excel ได้หรือไม่?**

ไม่ได้ ตารางของ Aspose.Slides ไม่มีการจัดเรียงหรือฟิลเตอร์ในตัว ให้จัดเรียงข้อมูลในหน่วยความจำก่อน แล้วค่อยเติมแถวตารางตามลำดับนั้นใหม่

**ฉันสามารถตั้งค่าคอลัมน์เป็นแถบสีสลับพร้อมคงสีที่กำหนดเองในเซลล์บางเซลล์ได้หรือไม่?**

ได้ เปิดใช้งานคอลัมน์เป็นแถบสีสลับ แล้วกำหนดสีเฉพาะเซลล์ด้วยการจัดรูปแบบระดับเซลล์; การจัดรูปแบบระดับเซลล์จะมีลำดับความสำคัญเหนือสไตล์ของตาราง