---
title: ปรับแต่งตารางข้อมูลแผนภูมิในงานนำเสนอโดยใช้ Java
linktitle: ตารางข้อมูล
type: docs
url: /th/java/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติตัวอักษร
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ปรับแต่งฟอนต์, ขอบ, และคีย์ในตารางข้อมูลแผนภูมิของงานพรีเซนเทชัน PowerPoint ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Aspose.Slides for Java ช่วยให้คุณแสดงตารางข้อมูลของแผนภูมิและปรับแต่งรูปแบบข้อความ, ขอบ, และคีย์ในตารางอธิบาย บทความนี้อธิบายวิธีเปิดใช้งานตาราง, จัดรูปแบบข้อความ, ควบคุมแต่ละประเภทของขอบ, และแสดงหรือซ่อนคีย์ในตารางอธิบาย ตัวอย่างจะบันทึกแผนภูมิที่กำหนดค่าไว้ในไฟล์ PPTX

## **ตั้งค่าลักษณะตัวอักษร**

เพื่อแสดงตารางข้อมูลของแผนภูมิ, ส่งค่า `true` ไปยัง [setDataTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/#setDataTable-boolean-). ใช้ [getChartDataTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/#getChartDataTable--) เพื่อเข้าถึงตารางและกำหนดรูปแบบข้อความ

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
1. เพิ่มแผนภูมิคอลัมน์แบบกลุ่มลงในสไลด์แรก
1. เปิดใช้งานตารางข้อมูลของแผนภูมิ
1. เปิดใช้งานข้อความหนาโดยใช้ [setFontBold](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) และส่งค่า `20` ไปยัง [setFontHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) เพื่อกำหนดข้อความขนาด 20 จุด
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต่อไปนี้ต้องการไฟล์ `test.pptx` อยู่ในไดเรกทอรีทำงานและต้องมีอย่างน้อยหนึ่งสไลด์ มันจะเพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นที่ตำแหน่ง (50, 50) โดยมีความกว้าง 600 จุดและความสูง 400 จุด ไฟล์ `output.pptx` ที่บันทึกแล้วจะมีแผนภูมิพร้อมตารางข้อมูลที่เปิดใช้งานและการตั้งค่าฟอนต์ที่กำหนด

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

## **ปรับแต่งขอบตารางข้อมูล**

เปิดใช้งานตารางด้วย [IChart.setDataTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#setDataTable-boolean-) และเข้าถึงผ่าน [IChart.getChartDataTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#getChartDataTable--). คุณสามารถควบคุมขอบสามประเภทได้โดยอิสระ

- [setBorderHorizontal](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) ควบคุมขอบแนวนอนของเซลล์
- [setBorderVertical](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) ควบคุมขอบแนวตั้งของเซลล์
- [setBorderOutline](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) ควบคุมขอบนอกของตาราง

ส่งค่า `true` ไปยังแต่ละเมธอดเพื่อแสดงขอบหรือ `false` เพื่อซ่อนขอบ ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลเริ่มต้น, แสดงขอบแนวนอนและขอบนอก, และซ่อนขอบแนวตั้ง ไม่ต้องการไฟล์อินพุต ตำแหน่งและขนาดของแผนภูมิระบุเป็นจุด

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

การเปรียบเทียบด้านล่างใช้ข้อมูลแผนภูมิและการตั้งค่าคีย์อธิบายเดียวกันในสี่กรณี เริ่มจากเปิดขอบทั้งหมด, แต่ละตัวแปรที่เหลือจะปิดการตั้งค่าขอบเพียงหนึ่งประเภท ตัวแปรที่อยู่ด้านซ้ายล่างจะตรงกับการตั้งค่าขอบในตัวอย่าง

![ตารางข้อมูลแผนภูมิที่เปิดใช้ขอบทั้งหมด, ไม่มีขอบแนวนอน, ไม่มีขอบแนวตั้ง, และไม่มีขอบภายนอก](data-table-borders.png)

## **แสดงหรือซ่อนคีย์อธิบาย**

คีย์อธิบายคือเครื่องหมายสีเล็ก ๆ ที่อยู่ข้างชื่อซีรีส์ในตารางข้อมูล ช่วยผู้อ่านจับคู่แต่ละแถวของตารางกับซีรีส์ของแผนภูมิ ส่งค่า `true` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) เพื่อแสดงเครื่องหมายเหล่านี้หรือ `false` เพื่อซ่อน

ตารางอธิบายแยกต่างหากของแผนภูมิควบคุมโดย [IChart.setLegend](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#setLegend-boolean-). การตั้งค่าเหล่านี้เป็นอิสระ: การซ่อนตารางอธิบายแยกไม่ทำให้คีย์ในตารางข้อมูลหายไป, และการซ่อนคีย์ในตารางก็ไม่ทำให้ตารางอธิบายแยกหายไป

ตัวอย่างต่อไปสร้างแผนภูมิพร้อมข้อมูลเริ่มต้น, เปิดใช้งานตารางข้อมูล, และแสดงคีย์อธิบายภายในขณะซ่อนตารางอธิบายแยก ทั้งหมดของขอบตารางถูกเปิดใช้งานอย่างชัดเจน ไม่จำเป็นต้องมีงานนำเสนออินพุต เพียงเพื่อซ่อนคีย์ของตาราง, ส่งค่า `false` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-)

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

การเปรียบเทียบด้านล่างแสดงตารางเดียวกันที่เปิดและปิดคีย์อธิบาย ขอบทั้งหมดยังคงเปิดอยู่และตารางอธิบายแยกของแผนภูมิติดอยู่ในทั้งสองกรณี

![ตารางข้อมูลแผนภูมิที่แสดงคีย์อธิบายด้านซ้ายและซ่อนคีย์อธิบายด้านขวา](data-table-legend-keys.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์อธิบายในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ได้ ส่งค่า `true` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) เพื่อแสดงคีย์อธิบายหรือ `false` เพื่อซ่อน

**ตารางข้อมูลจะยังคงอยู่เมื่อส่งออกงานนำเสนอเป็น PDF, HTML หรือรูปภาพหรือไม่?**

ได้ Aspose.Slides จะเรนเดอร์แผนภูมิและตารางข้อมูลที่แสดงเป็นส่วนหนึ่งของสไลด์เมื่อส่งออกเป็น [PDF](/slides/th/java/convert-powerpoint-to-pdf/), [HTML](/slides/th/java/convert-powerpoint-to-html/), หรือ [images](/slides/th/java/convert-powerpoint-to-png/)

**ฉันสามารถทำงานกับตารางข้อมูลในแผนภูมิที่โหลดจากเทมเพลตได้หรือไม่?**

ได้ สำหรับแผนภูมิที่โหลดจากงานนำเสนอหรือเทมเพลตที่มีอยู่, ใช้ [hasDataTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/#hasDataTable--) และ [setDataTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/#setDataTable-boolean-) เพื่อตรวจสอบหรือเปลี่ยนแปลงว่าตารางข้อมูลของมันถูกแสดงหรือไม่

**ฉันจะค้นหาแผนภูมิที่เปิดใช้งานตารางข้อมูลได้อย่างไร?**

วนลูปผ่านรูปร่างบนแต่ละสไลด์, ระบุแผนภูมิ, แล้วเรียกเมธอด [hasDataTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/#hasDataTable--) ของมัน ค่า `true` หมายถึงตารางข้อมูลถูกเปิดใช้งาน