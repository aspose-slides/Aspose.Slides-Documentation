---
title: จัดการแถวและคอลัมน์ในตาราง PowerPoint ด้วย Java
linktitle: แถวและคอลัมน์
type: docs
weight: 20
url: /th/java/manage-rows-and-columns/
keywords:
- แถวตาราง
- คอลัมน์ตาราง
- แถวแรก
- หัวตาราง
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
- Java
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย Aspose.Slides for Java และเร่งการแก้ไขงานนำเสนอและการอัปเดตข้อมูล."
---
## **บทนำ**

Aspose.Slides for Java ช่วยให้คุณจัดการโครงสร้างและการจัดรูปแบบตารางในงานนำเสนอ PowerPoint ผ่านคลาส [ตาราง](https://reference.aspose.com/slides/java/com.aspose.slides/table/) และอินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) คุณสามารถกำหนดแถวหัวเรื่อง, คัดลอกหรือลบแถวและคอลัมน์, และใช้การจัดรูปแบบข้อความกับแถวหรือคอลัมน์ทั้งหมดได้

บทความนี้อธิบายการดำเนินการเหล่านี้ด้วยตัวอย่าง Java นอกจากนี้ยังแสดงวิธีดึงค่าตั้งล่วงหน้าของสไตล์ตารางเพื่อให้คุณสามารถใช้งานซ้ำได้ ดัชนีแถวและคอลัมน์ของตารางเริ่มนับจากศูนย์

## **ควบคุมความสูงของแถว**

ใช้ [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) เพื่อตั้งค่าความสูงขั้นต่ำของแถวเป็นหน่วยจุด เป็นค่าต่ำสุด ไม่ใช่ความสูงคงที่ [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) จะคืนค่าความสูงจริง เข้าถึงแถวผ่าน [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--).

ตัวอย่างโหลดไฟล์ [row-height-input.pptx](row-height-input.pptx) ซึ่งมีตารางเป็นรูปร่างแรกบนสไลด์แรก แถวแรกเริ่มที่ 70 จุด เซลล์ใช้ข้อความ Arial ขนาด 18 จุด, มีการตัดบรรทัด, และระยะขอบบนและล่าง 6 จุด; ข้อความที่ยาวในคอลัมน์ที่สองตัดบรรทัดหลายบรรทัด ตัวอย่างเพิ่มค่าขั้นต่ำเป็น 100 จุด แล้วลดลงเหลือ 20 จุด พิมพ์ความสูงจริงหลังการเปลี่ยนแปลงแต่ละครั้ง และบันทึกผลลัพธ์ทั้งสอง

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

ด้วยงานนำเสนอที่ให้มา การเพิ่มค่าขั้นต่ำจะเพิ่มพื้นที่ให้กับแถว การลดค่าขั้นต่ำจะลบพื้นที่ส่วนเกินนั้นออก แต่ความสูงจริงยังคงมากกว่า 20 จุดเพราะข้อความและระยะขอบของเซลล์ต้องการพื้นที่มากกว่านั้น การลดค่าขั้นต่ำอย่างเดียวไม่สามารถบังคับให้แถวต่ำกว่าพื้นที่ที่เนื้อหาต้องการได้

หลายปัจจัยส่งผลต่อความสูงจริง:

- **ข้อความและขนาดฟอนต์:** ข้อความที่ยาว, การแทรกการขึ้นบรรทัดใหม่โดยเจตนา, หรือฟอนต์ที่ใหญ่กว่า สามารถต้องการพื้นที่แนวตั้งมากขึ้น
- **การตัดบรรทัดและความกว้างของคอลัมน์:** เมื่อเปิดการตัดบรรทัด, การลดความกว้างของคอลัมน์ด้วย [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) จะทำให้เกิดบรรทัดเพิ่มขึ้น คอลัมน์ที่กว้างขึ้นสามารถลดพื้นที่ที่ต้องการในแนวตั้ง
- **ระยะขอบของเซลล์:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) และ [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) เพิ่มพื้นที่แนวตั้ง [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) และ [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) ลดความกว้างที่ใช้สำหรับข้อความและอาจทำให้เกิดการตัดบรรทัดเพิ่มเติม

สำหรับตารางนี้ไม่มีการรวมเซลล์ เซลล์ที่ต้องการพื้นที่แนวตั้งมากที่สุดจะกำหนดขอบเขตล่างของแถวทั้งหมด หากต้องการทำให้แถวสั้นลง คุณอาจต้องทำให้ข้อความสั้นลง, ลดขนาดฟอนต์หรือระยะขอบ, หรือทำให้คอลัมน์กว้างขึ้น

ภาพด้านล่างแสดงตารางเดียวกันในสเกลเดียวกัน ในผลลัพธ์ที่แสดง ความสูงจริงคือ 70, 100 และ 55.2 จุด: แถวสุดท้ายยังคงสูงกว่าค่าขั้นต่ำ 20 จุด การวัดข้อความที่แม่นยำอาจแตกต่างกันตามฟอนต์ที่มีในสภาพแวดล้อมของคุณ ดาวน์โหลดผลลัพธ์ที่บันทึกไว้: [เพิ่มขั้นต่ำ](row-height-increased.pptx) และ [ลดขั้นต่ำ](row-height-decreased.pptx)

| ต้นฉบับ: ขั้นต่ำ 70 pt, จริง 70 pt | เพิ่ม: ขั้นต่ำ 100 pt, จริง 100 pt | ลด: ขั้นต่ำ 20 pt, ความสูงจริง 55.2 pt |
| --- | --- | --- |
| ![ตารางต้นฉบับที่มีแถวแรกขนาด 70 จุด.](row-height-before.png) | ![ตารางหลังจากเพิ่มค่าขั้นต่ำของแถวแรกเป็น 100 จุด.](row-height-increased.png) | ![ตารางหลังจากลดค่าขั้นต่ำของแถวแรกเป็น 20 จุด; ข้อความตัดบรรทัดทำให้แถวสูงกว่าขั้นต่ำ.](row-height-decreased.png) |

## **ตั้งค่าแถวแรกเป็นหัวเรื่อง**

ใช้เมธอด [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) เพื่อทำเครื่องหมายแถวแรกสำหรับการจัดรูปแบบหัวเรื่อง การแสดงผลขึ้นกับสไตล์ตารางที่ใช้กับตาราง

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. เข้าถึงตารางที่เก็บเป็นรูปร่างแรกบนสไลด์
4. เปิดการจัดรูปแบบหัวเรื่องสำหรับแถวแรกของมัน
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรก จะเปิดการจัดรูปแบบหัวเรื่องสำหรับแถวแรกและบันทึกเป็น `First_row_header.pptx`

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

คัดลอกแถวหรือคอลัมน์เพื่อใช้เนื้อหาและการจัดรูปแบบซ้ำ คุณสามารถต่อท้ายสำเนาที่ส่วนท้ายของตารางหรือแทรกในตำแหน่งเฉพาะ

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. กำหนดความกว้างของคอลัมน์และความสูงของแถว
4. เพิ่มตารางด้วยเมธอด [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---)
5. คัดลอกแถวที่ต้องการ
6. คัดลอกคอลัมน์ที่ต้องการ
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `Test.pptx` ที่มีอย่างน้อยหนึ่งสไลด์ จะสร้างตารางที่มีสามคอลัมน์และห้าแถว โดยกำหนดขนาดเป็นหน่วยจุด จะต่อท้ายสำเนาแถวแรกและคอลัมน์แรก จากนั้นแทรกสำเนาแถวที่สองและคอลัมน์ที่สองที่ตำแหน่งดัชนี 3 (ตำแหน่งที่สี่) ตารางผลลัพธ์จะมีเจ็ดแถวและห้าคอลัมน์ อาร์กิวเมนต์ `false` ปิดการคัดลอกเข้าแถวหรือคอลัมน์ที่รวมอยู่ติดกัน; ตารางนี้ไม่มีเซลล์ที่รวมกัน

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

## **ลบแถวหรือคอลัมน์จากตาราง**

ลบแถวหรือคอลัมน์ที่ไม่จำเป็นอีกต่อไปในตาราง การลบรายการจะทำให้ดัชนีของแถวหรือคอลัมน์ที่ตามมาถูกปรับเปลี่ยน

1. สร้างงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. กำหนดความกว้างของคอลัมน์และความสูงของแถว
4. เพิ่มตารางด้วยเมธอด [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---)
5. ลบแถวที่สองและคอลัมน์ที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างนี้สร้างตาราง 3x3 และลบแถวและคอลัมน์ที่ดัชนี 1 ทำให้เหลือตาราง 2x2 ในไฟล์ `TestTable_out.pptx` ขนาดเป็นหน่วยจุด อาร์กิวเมนต์ `false` ปิดการลบแถวหรือคอลัมน์ที่รวมอยู่ติดกัน; ตารางนี้ไม่มีเซลล์ที่รวมกัน

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

## **ตั้งค่าการจัดรูปแบบข้อความระดับแถวของตาราง**

ใช้การจัดรูปแบบข้อความกับแถวทั้งหมดเพื่อให้เซลล์ทั้งหมดสอดคล้อง คุณสามารถตั้งค่าคุณสมบัติดีไซน์ฟอนต์, การจัดรูปแบบย่อหน้า, และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)
2. เข้าถึงตารางบนสไลด์แรก
3. ใช้เมธอด [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับแถวแรก
4. ใช้เมธอด [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) สำหรับแถวแรก
5. ใช้เมธอด [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) สำหรับแถวที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรกและมีอย่างน้อยสองแถว จะใช้ข้อความขนาด 25 จุด, จัดชิดขวา, และตั้งระยะขอบย่อหน้าขวา 20 จุดสำหรับแถวแรก จากนั้นตั้งข้อความแนวตั้งในแถวที่สอง

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

## **ตั้งค่าการจัดรูปแบบข้อความระดับคอลัมน์ของตาราง**

ใช้การจัดรูปแบบข้อความกับคอลัมน์ทั้งหมดเพื่อให้เซลล์ทั้งหมดสอดคล้อง คุณสามารถตั้งค่าคุณสมบัติดีไซน์ฟอนต์, การจัดรูปแบบย่อหน้า, และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)
2. เข้าถึงตารางบนสไลด์แรก
3. ใช้เมธอด [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับคอลัมน์แรก
4. ใช้เมธอด [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) สำหรับคอลัมน์แรก
5. ใช้เมธอด [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) สำหรับคอลัมน์ที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรกและมีอย่างน้อยสองคอลัมน์ จะใช้ข้อความขนาด 25 จุด, จัดชิดขวา, และตั้งระยะขอบย่อหน้าขวา 20 จุดสำหรับคอลัมน์แรก จากนั้นตั้งข้อความแนวตั้งในคอลัมน์ที่สอง

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

## **รับคุณสมบัติสไตล์ตาราง**

ใช้เมธอด [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) เพื่อดึงค่าตั้งล่วงหน้าที่ใช้กับตารางและนำไปใช้กับตารางอื่น วิธีนี้จะระบุค่าตั้งล่วงหน้าแทนการเขียนทับการจัดรูปแบบเซลล์แต่ละรายการ

ตัวอย่างสร้างตาราง, ใช้ [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1), แล้วอ่านค่าตั้งล่วงกลับมา พิมพ์ค่าตัวเลขที่สอดคล้องกับ `DarkStyle1` และบันทึกตารางในไฟล์ `table.pptx`

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

ได้ ตารางจะสืบทอดธีมของสไลด์/เลย์เอาต์/มาสเตอร์ และคุณยังคงสามารถเขียนทับสีเติม, เส้นขอบ, และสีข้อความเหนือธีมนั้นได้

**ฉันสามารถจัดเรียงแถวของตารางแบบใน Excel ได้หรือไม่?**

ไม่ได้ ตารางของ Aspose.Slides ไม่มีการจัดเรียงหรือฟิลเตอร์ในตัว ให้จัดเรียงข้อมูลในหน่วยความจำก่อนแล้วค่อยเติมแถวตารางตามลำดับที่ต้องการ

**ฉันสามารถทำคอลัมน์แบบมีแถบสีสลับพร้อมการกำหนดสีกำหนดเองให้กับเซลล์เฉพาะได้หรือไม่?**

ได้ เปิดการใช้งานคอลัมน์แบบมีแถบสีสลับ แล้วเขียนทับเซลล์เฉพาะด้วยการจัดรูปแบบท้องถิ่น; การจัดรูปแบบระดับเซลล์จะมีลำดับความสำคัญสูงกว่าสไตล์ตาราง