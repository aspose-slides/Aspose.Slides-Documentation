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
- หัวเรื่องตาราง
- คัดลอกแถว
- คัดลอกคอลัมน์
- ทำสำเนาแถว
- ทำสำเนาคอลัมน์
- ลบแถว
- ลบคอลัมน์
- รูปแบบข้อความของแถว
- รูปแบบข้อความของคอลัมน์
- สไตล์ตาราง
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java และเร่งกระบวนการแก้ไขงานนำเสนอและการอัปเดตข้อมูล."
---
## **บทนำ**

Aspose.Slides for Android via Java ช่วยให้คุณจัดการโครงสร้างและการจัดรูปแบบตารางในงานนำเสนอ PowerPoint ผ่านคลาส [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) และอินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) คุณสามารถกำหนดแถวหัวเรื่อง, คัดลอกหรือเอาแถวและคอลัมน์ออก, และใช้การจัดรูปแบบข้อความกับแถวหรือคอลัมน์ทั้งหมดได้

บทความนี้อธิบายการดำเนินการเหล่านี้ด้วยตัวอย่าง Java นอกจากนี้ยังแสดงวิธีดึงสไตล์ที่ตั้งล่วงหน้าของตารางเพื่อให้คุณนำกลับมาใช้ใหม่ได้ ดัชนีแถวและคอลัมน์ของตารางเริ่มจากศูนย์

## **ควบคุมความสูงของแถว**

ใช้ [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) เพื่อตั้งความสูงขั้นต่ำของแถวเป็นจุด ซึ่งเป็นค่าล่างสุด ไม่ใช่ความสูงคงที่ [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) จะคืนค่าความสูงจริง การเข้าถึงแถวทำได้ผ่าน [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--)

ตัวอย่างโหลดไฟล์ [row-height-input.pptx](row-height-input.pptx) ซึ่งมีตารางเป็นรูปร่างแรกบนสไลด์แรก แถวแรกเริ่มที่ 70 จุด เซลล์ใช้ข้อความ Arial 18 จุด, มีการตัดบรรทัดอัตโนมัติและระยะขอบบนและล่าง 6 จุด; ข้อความยาวในคอลัมน์ที่สองตัดบรรทัดหลายบรรทัด ตัวอย่างเพิ่มค่าขั้นต่ำเป็น 100 จุด แล้วลดลงเหลือ 20 จุด พิมพ์ความสูงจริงหลังแต่ละครั้งและบันทึกผลลัพธ์ทั้งสอง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ด้วยงานนำเสนอที่ให้มา การเพิ่มค่าขั้นต่ำจะเพิ่มช่องว่างให้กับแถว การลดค่าขั้นต่ำจะลบช่องว่างนั้นออก แต่ความสูงจริงยังคงมากกว่า 20 จุด เนื่องจากข้อความและระยะขอบของเซลล์ต้องการพื้นที่มากกว่านั้น การลดค่าขั้นต่ำเพียงอย่างเดียวไม่สามารถบังคับให้แถวต่ำกว่าพื้นที่ที่เนื้อหาต้องการได้

หลายปัจจัยส่งผลต่อความสูงจริง:

- **ข้อความและขนาดฟอนต์:** ข้อความยาว, การขึ้นบรรทัดใหม่โดยสมัครใจ, หรือฟอนต์ที่ใหญ่กว่าอาจต้องการพื้นที่แนวตั้งเพิ่ม
- **การตัดบรรทัดและความกว้างคอลัมน์:** เมื่อเปิดการตัดบรรทัด, การลดความกว้างคอลัมน์ด้วย [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) จะทำให้เกิดบรรทัดเพิ่มขึ้น คอลัมน์กว้างขึ้นสามารถลดพื้นที่แนวตั้งที่ต้องการ
- **ระยะขอบของเซลล์:** [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) และ [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) เพิ่มช่องว่างแนวตั้ง [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) และ [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) ลดความกว้างที่ใช้สำหรับข้อความและอาจทำให้เกิดการตัดบรรทัดเพิ่มเติม

สำหรับตารางนี้ที่ไม่มีการผสานเซลล์ เซลล์ที่ต้องการพื้นที่แนวตั้งมากที่สุดจะกำหนดขอบเขตล่างโดยเนื้อหา สำหรับทำให้แถวสั้นลง คุณอาจต้องย่อข้อความ, ลดขนาดฟอนต์หรือระยะขอบ, หรือเพิ่มความกว้างของคอลัมน์

รูปภาพด้านล่างแสดงตารางเดียวกันในสเกลเดียวกัน ในผลลัพธ์ที่แสดง ความสูงจริงคือ 70, 100, และ 55.2 จุด: แถวสุดท้ายยังคงสูงกว่าค่าขั้นต่ำ 20 จุด การวัดข้อความอาจแตกต่างตามฟอนต์ที่มีในสภาพแวดล้อมของคุณ ดาวน์โหลดผลลัพธ์ที่บันทึกไว้: [increased minimum](row-height-increased.pptx) และ [decreased minimum](row-height-decreased.pptx)

| ต้นฉบับ: ความสูงขั้นต่ำ 70 pt, ความสูงจริง 70 pt | เพิ่ม: ความสูงขั้นต่ำ 100 pt, ความสูงจริง 100 pt | ลด: ความสูงขั้นต่ำ 20 pt, ความสูงจริง 55.2 pt |
| --- | --- | --- |
| ![ตารางต้นฉบับที่มีแถวแรก 70 จุด.](row-height-before.png) | ![ตารางหลังจากเพิ่มค่าขั้นต่ำของแถวแรกเป็น 100 จุด.](row-height-increased.png) | ![ตารางหลังจากลดค่าขั้นต่ำของแถวแรกเป็น 20 จุด; ข้อความตัดบรรทัดทำให้แถวสูงกว่าค่าขั้นต่ำ.](row-height-decreased.png) |

## **กำหนดแถวแรกเป็นหัวเรื่อง**

ใช้เมธอด [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) เพื่อทำเครื่องหมายแถวแรกสำหรับการจัดรูปแบบหัวเรื่อง การปรากฏของแถวขึ้นอยู่กับสไตล์ตารางที่ใช้กับตาราง

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. เข้าถึงตารางที่เก็บเป็นรูปร่างแรกบนสไลด์
4. เปิดใช้การจัดรูปแบบหัวเรื่องสำหรับแถวแรก
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรก เปิดใช้การจัดรูปแบบหัวเรื่องสำหรับแถวแรกและบันทึกเป็น `First_row_header.pptx`

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คัดลอกแถวหรือคอลัมน์ของตาราง**

คัดลอกแถวหรือคอลัมน์เพื่อใช้ซ้ำเนื้อหาและการจัดรูปแบบ คุณสามารถเพิ่มสำเนาที่ตำแหน่งสุดท้ายของตารางหรือแทรกลงในตำแหน่งที่กำหนด

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. กำหนดความกว้างของคอลัมน์และความสูงของแถว
4. เพิ่มตารางด้วยเมธอด [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---)
5. คัดลอกแถวที่ต้องการ
6. คัดลอกคอลัมน์ที่ต้องการ
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `Test.pptx` ที่มีอย่างน้อยหนึ่งสไลด์ สร้างตารางที่มีสามคอลัมน์และห้าแถว โดยระบุขนาดเป็นจุด เพิ่มสำเนาของแถวแรกและคอลัมน์แรก แล้วแทรกสำเนาของแถวที่สองและคอลัมน์ที่สองที่ตำแหน่งดัชนี 3 (ตำแหน่งที่สี่) ตารางที่ได้จะมีเจ็ดแถวและห้าคอลัมน์ อาร์กิวเมนต์ `false` ปิดการคัดลอกเข้าแถวหรือคอลัมน์ที่ผสานอยู่; ตารางนี้ไม่มีเซลล์ที่ผสาน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ลบแถวหรือคอลัมน์ออกจากตาราง**

ลบแถวหรือคอลัมน์ที่ไม่ต้องการอีกต่อไป การลบรายการจะทำให้ดัชนีของแถวหรือคอลัมน์ที่ตามมาถูกเลื่อน

1. สร้างงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. กำหนดความกว้างของคอลัมน์และความสูงของแถว
4. เพิ่มตารางด้วยเมธอด [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---)
5. ลบแถวที่สองและคอลัมน์ที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างนี้สร้างตาราง 3x3 และลบแถวและคอลัมน์ที่ดัชนี 1 ทำให้เหลือตาราง 2x2 ในไฟล์ `TestTable_out.pptx` ขนาดเป็นจุด อาร์กิวเมนต์ `false` ปิดการลบแถวหรือคอลัมน์ที่ผสานอยู่; ตารางนี้ไม่มีเซลล์ที่ผสาน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **กำหนดการจัดรูปแบบข้อความระดับแถวของตาราง**

ใช้การจัดรูปแบบข้อความกับแถวทั้งหมดเพื่อให้เซลล์ที่อยู่ในแถวนั้นสอดคล้องกัน คุณสามารถตั้งค่าคุณสมบัติฟอนต์, การจัดรูปแบบย่อหน้า, และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงตารางบนสไลด์แรก
3. ใช้เมธอด [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับแถวแรก
4. ใช้เมธอด [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) สำหรับแถวแรก
5. ใช้เมธอด [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) สำหรับแถวที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรกและมีอย่างน้อยสองแถว ใช้ข้อความ 25 จุด, จัดแนวขวา, และระยะขอบย่อหน้าขวา 20 จุดกับแถวแรก แล้วตั้งค่าให้ข้อความเป็นแนวตั้งในแถวที่สอง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **กำหนดการจัดรูปแบบข้อความระดับคอลัมน์ของตาราง**

ใช้การจัดรูปแบบข้อความกับคอลัมน์ทั้งหมดเพื่อให้เซลล์ในคอลัมน์นั้นสอดคล้องกัน คุณสามารถตั้งค่าคุณสมบัติฟอนต์, การจัดรูปแบบย่อหน้า, และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงตารางบนสไลด์แรก
3. ใช้เมธอด [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับคอลัมน์แรก
4. ใช้เมธอด [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) สำหรับคอลัมน์แรก
5. ใช้เมธอด [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) สำหรับคอลัมน์ที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรกและมีอย่างน้อยสองคอลัมน์ ใช้ข้อความ 25 จุด, จัดแนวขวา, และระยะขอบย่อหน้าขวา 20 จุดกับคอลัมน์แรก แล้วตั้งค่าให้ข้อความเป็นแนวตั้งในคอลัมน์ที่สอง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติสไตล์ของตาราง**

ใช้เมธอด [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) เพื่อดึงสไตล์ที่ตั้งล่วงหน้าที่ใช้กับตารางและนำกลับไปใช้กับตารางอื่น วิธีนี้ระบุสไตล์ล่วงหน้าแทนการเขียนทับการจัดรูปแบบของเซลล์เดี่ยว

ตัวอย่างสร้างตาราง, ใช้ [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1) แล้วอ่านค่าสไตล์กลับมา พิมพ์ค่าตัวเลขที่สอดคล้องกับ `DarkStyle1` และบันทึกตารางในไฟล์ `table.pptx`

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมหรือสไตล์ของ PowerPoint กับตารางที่สร้างไว้แล้วได้หรือไม่?**

ใช่. ตารางสืบทอดธีมจากสไลด์/เลเอาต์/มาสเตอร์, และคุณยังสามารถเขียนทับการเติม, เส้นขอบ, และสีข้อความได้เหนือธีมนั้น

**ฉันสามารถเรียงลำดับแถวของตารางแบบใน Excel ได้หรือไม่?**

ไม่ได้, ตารางของ Aspose.Slides ไม่มีการเรียงลำดับหรือฟิลเตอร์ในตัว คุณต้องจัดเรียงข้อมูลในหน่วยความจำก่อน แล้วค่อยใส่แถวตารางตามลำดับนั้นใหม่

**ฉันสามารถทำคอลัมน์ลายขวาง (striped) พร้อมสีที่กำหนดไว้สำหรับเซลล์บางเซลล์ได้หรือไม่?**

ได้. เปิดใช้งานคอลัมน์ลายขวาง, แล้วเขียนทับสีของเซลล์เฉพาะด้วยการจัดรูปแบบระดับเซลล์; การจัดรูปแบบระดับเซลล์จะมีลำดับความสำคัญเหนือสไตล์ของตาราง