---
title: ปรับแต่งตารางข้อมูลแผนภูมิในการนำเสนอบน Android
linktitle: ตารางข้อมูล
type: docs
url: /th/androidjava/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติของฟอนต์
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ปรับแต่งฟอนต์, เส้นขอบและคีย์ของตำนานในตารางข้อมูลแผนภูมิของการนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Android via Java ช่วยให้คุณสามารถแสดงตารางข้อมูลของแผนภูมิและปรับแต่งการจัดรูปแบบข้อความ, เส้นขอบ, และคีย์ของตำนานได้ บทความนี้อธิบายวิธีเปิดใช้งานตาราง, จัดรูปแบบข้อความ, ควบคุมแต่ละประเภทของเส้นขอบ, และแสดงหรือซ่อนคีย์ของตำนาน ตัวอย่างจะบันทึกแผนภูมิที่กำหนดค่าไว้ในไฟล์ PPTX

## **ตั้งค่าคุณสมบัติของฟอนต์**

เพื่อแสดงตารางข้อมูลของแผนภูมิ, ส่งค่า `true` ไปยัง [setDataTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/#setDataTable-boolean-). ใช้ [getChartDataTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/#getChartDataTable--) เพื่อเข้าถึงตารางและกำหนดการจัดรูปแบบข้อความ

1. โหลดพรีเซนเทชันโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) .
2. เพิ่มแผนภูมิคอลัมน์แบบกลุ่มบนสไลด์แรก
3. เปิดใช้งานตารางข้อมูลของแผนภูมิ
4. เปิดใช้งานข้อความหนาด้วย [setFontBold](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) และส่งค่า `20` ไปยัง [setFontHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) เพื่อข้อความขนาด 20 จุด
5. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

ตัวอย่างต่อไปนี้ต้องการไฟล์ `test.pptx` ในไดเรกทอรีทำงานที่มีอย่างน้อยหนึ่งสไลด์ โดยเพิ่มแผนภูมิที่มีข้อมูลเริ่มต้นที่ตำแหน่ง (50, 50) ความกว้าง 600 จุด และความสูง 400 จุด ไฟล์ `output.pptx` ที่บันทึกไว้จะมีแผนภูมิพร้อมตารางข้อมูลที่เปิดใช้งานและตั้งค่าฟอนต์ที่กำหนด

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ปรับแต่งเส้นขอบของตารางข้อมูล**

เปิดใช้งานตารางด้วย [IChart.setDataTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) และเข้าถึงผ่าน [IChart.getChartDataTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#getChartDataTable--). คุณสามารถควบคุมเส้นขอบสามประเภทได้อย่างอิสระ

- [setBorderHorizontal](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) ควบคุมเส้นขอบแนวนอนของเซลล์
- [setBorderVertical](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) ควบคุมเส้นขอบแนวตั้งของเซลล์
- [setBorderOutline](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) ควบคุมเส้นขอบรอบนอกของตาราง

ส่งค่า `true` ไปยังแต่ละเมธอดเพื่อแสดงเส้นขอบ หรือ `false` เพื่อซ่อน ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลเริ่มต้น, แสดงเส้นขอบแนวนอนและรอบนอก, และซ่อนเส้นขอบแนวตั้ง ไม่ต้องใช้ไฟล์อินพุตตำแหน่งและขนาดของแผนภูมิระบุเป็นจุด

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเปรียบเทียบด้านล่างใช้ข้อมูลแผนภูมิและการตั้งค่าคีย์ของตำนานเดียวกันในสี่กรณี เริ่มจากเปิดใช้งานเส้นขอบทั้งหมด, แต่ละรูปแบบที่เหลือจะปิดการตั้งค่าเส้นขอบเพียงหนึ่งประเภท รูปแบบมุมซ้ายล่างตรงกับการตั้งค่าเส้นขอบในตัวอย่าง

![ตารางข้อมูลแผนภูมิที่เปิดใช้งานเส้นขอบทั้งหมด, ไม่มีเส้นขอบแนวนอน, ไม่มีเส้นขอบแนวตั้ง, และไม่มีเส้นขอบภายนอก](data-table-borders.png)

## **แสดงหรือซ่อนคีย์ของตำนาน**

คีย์ของตำนานเป็นสัญลักษณ์สีเล็กๆ อยู่ข้างชื่อชุดข้อมูลในตารางข้อมูล ช่วยให้ผู้อ่านจับคู่แต่ละแถวของตารางกับชุดข้อมูลในแผนภูมิ ส่งค่า `true` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) เพื่อแสดงสัญลักษณ์เหล่านี้ หรือ `false` เพื่อซ่อน

ตำนานแยกของแผนภูมิถูกควบคุมโดย [IChart.setLegend](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#setLegend-boolean-). การตั้งค่านี้เป็นอิสระ: การซ่อนตำนานแยกจะไม่ซ่อนคีย์ภายในตารางข้อมูล, และการซ่อนคีย์ของตารางจะไม่ซ่อนตำนานแยก

ตัวอย่างต่อไปนี้สร้างแผนภูมิด้วยข้อมูลเริ่มต้น, เปิดใช้งานตารางข้อมูล, แสดงคีย์ของตำนานภายในตารางขณะซ่อนตำนานแยก ทั้งหมดของเส้นขอบของตารางถูกเปิดใช้งานอย่างชัดเจน ไม่ต้องใช้พรีเซนเทชันอินพุต เพื่อซ่อนคีย์ของตารางเท่านั้น ให้ส่งค่า `false` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเปรียบเทียบด้านล่างแสดงตารางเดียวกันที่เปิดและปิดคีย์ของตำนาน ทั้งเส้นขอบยังคงเปิดอยู่ และตำนานแยกของแผนภูมิถูกซ่อนในทั้งสองกรณี

![ตารางข้อมูลแผนภูมิที่แสดงคีย์ของตำนานทางซ้ายและซ่อนคีย์ทางขวา](data-table-legend-keys.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์ของตำนานในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ได้. ส่งค่า `true` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) เพื่อแสดงคีย์ของตำนาน หรือ `false` เพื่อซ่อน

**ตารางข้อมูลจะถูกคงไว้เมื่อส่งออกพรีเซนเทชันเป็น PDF, HTML หรือรูปภาพหรือไม่?**

ได้. Aspose.Slides จะเรนเดอร์แผนภูมิและตารางข้อมูลที่แสดงเป็นส่วนหนึ่งของสไลด์เมื่อต้องการส่งออกเป็น [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/th/androidjava/convert-powerpoint-to-html/), หรือ [images](/slides/th/androidjava/convert-powerpoint-to-png/)

**ฉันสามารถทำงานกับตารางข้อมูลในแผนภูมิที่โหลดมาจากเทมเพลตได้หรือไม่?**

ได้. สำหรับแผนภูมิที่โหลดจากพรีเซนเทชันหรือเทมเพลตที่มีอยู่, ใช้ [hasDataTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/#hasDataTable--) และ [setDataTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) เพื่อตรวจสอบหรือเปลี่ยนแปลงว่าตารางข้อมูลของแผนภูมิถูกแสดงหรือไม่

**ฉันจะหาแผนภูมิที่เปิดใช้งานตารางข้อมูลได้อย่างไร?**

ทำการวนลูปผ่านรูปร่างในแต่ละสไลด์, ระบุแผนภูมิ, แล้วเรียกเมธอด [hasDataTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/#hasDataTable--) ของพวกมัน ค่า `true` หมายถึงตารางข้อมูลถูกเปิดใช้งาน