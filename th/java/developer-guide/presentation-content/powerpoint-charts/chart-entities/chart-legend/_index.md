---
title: ปรับแต่ง Legend ของแผนภูมิในงานนำเสนอด้วย Java
linktitle: Legend แผนภูมิ
type: docs
url: /th/java/chart-legend/
keywords:
- legend แผนภูมิ
- ตำแหน่ง legend
- ขนาดฟอนต์
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ปรับแต่ง legend ของแผนภูมิด้วย Aspose.Slides สำหรับ Java เพื่อเพิ่มประสิทธิภาพงานนำเสนอ PowerPoint ด้วยการจัดรูปแบบ legend ที่ปรับให้เหมาะสม."
---
## **ภาพรวม**

Aspose.Slides for Java มีตัวเลือกสำหรับการปรับแต่ง legend ของแผนภูมิในงานนำเสนอ PowerPoint บทความนี้แสดงวิธีกำหนดตำแหน่งและขนาดของ legend, ตั้งค่าขนาดฟอนต์สำหรับ legend ทั้งหมด, จัดรูปแบบรายการ legend ทีละรายการ, และซ่อนหรือกู้คืนรายการที่เลือก

FAQ ครอบคลุมพฤติกรรมที่เกี่ยวข้อง รวมถึงการสำรองพื้นที่สำหรับ legend, การแสดงป้ายกำกับหลายบรรทัด, และการสืบทอดการจัดรูปแบบจากธีมของงานนำเสนอ

## **การกำหนดตำแหน่ง Legend**

ใช้เมธอด [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), และ [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) ของ legend เพื่อระบุตำแหน่งและขนาดเป็นส่วนของมิติของแผนภูมิ

ตัวอย่างนี้สร้างงานนำเสนอและเพิ่มแผนภูมิคอลัมน์แบบคลัสเตอร์พร้อมข้อมูลเริ่มต้นบนสไลด์แรก การหารค่า offset และขนาดของ legend ที่ต้องการด้วยความกว้างและความสูงของแผนภูมิจะทำให้ได้ค่าที่เป็นอัตราส่วน: legend จะถูกย้ายออกจากมุมบนซ้ายของแผนภูมิโดยไกล 50 จุดและมีขนาด 100 × 100 จุด

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // แสดงตำแหน่งและขนาดของ legend ที่สัมพันธ์กับแผนภูมิ.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าขนาดฟอนต์ของ Legend**

ใช้เมธอด [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) ของ legend เพื่อเข้าถึงการจัดรูปแบบข้อความและใช้ [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) เพื่อกำหนดขนาดฟอนต์เป็นจุด

ตัวอย่างนี้สร้างแผนภูมิพร้อมข้อมูลเริ่มต้นและตั้งค่าข้อความ legend เป็น 20 จุด นอกจากนี้ยังปิดการกำหนดขอบอัตโนมัติสำหรับแกนแนวตั้งและตั้งค่าช่วงของแกนเป็น -5 ถึง 10

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าขนาดฟอนต์ของรายการ Legend รายการเดียว**

ใช้คอลเลกชันที่คืนค่าจากเมธอด [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) ของ legend เพื่อเข้าถึงการจัดรูปแบบของรายการเฉพาะ ดัชนีของรายการเริ่มจากศูนย์ ดังนั้นดัชนี `1` หมายถึงรายการที่สอง

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบคลัสเตอร์ที่มีข้อมูลเริ่มต้นอย่างน้อยสองซีรีส์ โดยจัดรูปแบบรายการ legend ที่สองให้เป็นตัวหนา ตัวเอียง และข้อความสีฟ้า ขนาด 20 จุด

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ซ่อนรายการ Legend รายการเดียว**

เมื่อต้องการล(series) ช่วยจาก legend แต่ให้ข้อมูลยังคงแสดงอยู่ ให้เรียก [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) ด้วยค่า `true` ผ่าน [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) วิธีนี้จะซ่อนเฉพาะรายการ legend ที่เลือก ไม่ได้ลบซีรีส์หรือจุดข้อมูลออก การเรียก [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) ด้วยค่า `false` จะซ่อน legend ทั้งหมด

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์แบบคลัสเตอร์หลายซีรีส์โดยใช้ข้อมูลเริ่มต้น โดยซ่อนรายการ legend ของซีรีส์ที่สอง (ดัชนี `1`) แล้วบันทึกงานนำเสนอ จากนั้นเรียก [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) ด้วยค่า `false` เพื่อกู้คืนรายการและบันทึกสำเนาที่สอง คอลัมน์ยังคงปรากฏในไฟล์ทั้งสอง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // กู้คืนรายการเดียวกันโดยไม่เปลี่ยนแปลงข้อมูลแผนภูมิ.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเปรียบเทียบด้านล่างแสดงแผนภูมิเดียวกันที่มีรายการ legend ทั้งหมดแสดงและที่ซ่อนรายการที่สอง คอลัมน์ของซีรีส์ที่สองยังคงไม่เปลี่ยนแปลง

![การเปรียบเทียบแผนภูมิที่มีรายการ legend ทั้งหมดแสดงและรายการ Series 2 ซ่อนจาก legend; คอลัมน์ทั้งหมดยังคงแสดงอยู่.](hide-legend-entry.png)

ในแผนภูมิประเภทคอลัมน์, แถบ, และเส้น, รายการ legend ใช้ระบุซีรีส์ สำหรับแผนภูมิวงกลม, รายการ legend ระบุจุดข้อมูล (สไลซ์) แต่ละจุด ดังนั้นให้ใช้ [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) กับสไลซ์ที่เลือก API จะอธิบายเมธอดนี้สำหรับประเภทแผนภูมิ `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, และ `BarOfPie` อย่าสมมติว่าใช้กับแผนภูม doughnut ซึ่งไม่ได้รวมอยู่ในรายการนั้น

## **คำถามที่พบบ่อย**

**Can I make the chart allocate space for the legend instead of overlaying it?**  
ใช่. เรียก [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) ด้วยค่า `false` เพื่อสำรองพื้นที่ให้ legend แทนที่จะให้มันซ้อนทับพื้นที่พล็อต

**Can I make multiline legend labels?**  
ใช่. ป้ายกำกับที่ยาวสามารถตัดบรรทัดอัตโนมัติเมื่อความกว้างไม่พอ คุณยังสามารถใช้อักขระ newline ในชื่อซีรีส์เพื่อขอให้มีการตัดบรรทัด

**How do I make the legend follow the presentation theme's color scheme?**  
ปล่อยให้สี, การเติม, และฟอนต์ของ legend ไม่ตั้งค่าไว้ เพื่อให้สามารถสืบทอดการจัดรูปแบบจากธีม การกำหนดรูปแบบโดยเจตนาจะทับค่าการตั้งค่าของธีมที่สอดคล้องกัน