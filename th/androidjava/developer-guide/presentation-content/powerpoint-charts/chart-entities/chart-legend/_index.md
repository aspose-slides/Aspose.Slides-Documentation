---
title: ปรับแต่งคำอธิบายกราฟในงานนำเสนอบน Android
linktitle: คำอธิบายกราฟ
type: docs
url: /th/androidjava/chart-legend/
keywords:
- คำอธิบายกราฟ
- ตำแหน่งคำอธิบาย
- ขนาดฟอนต์
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ปรับแต่งคำอธิบายกราฟด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อเพิ่มประสิทธิภาพการนำเสนอ PowerPoint ด้วยการจัดรูปแบบคำอธิบายที่ออกแบบเฉพาะ"
---
## **ภาพรวม**

Aspose.Slides for Android via Java มีตัวเลือกสำหรับการปรับแต่งคำอธิบายภาพกราฟในงานนำเสนอ PowerPoint บทความนี้แสดงวิธีการกำหนดตำแหน่งและขนาดของคำอธิบายภาพ, ตั้งค่าขนาดฟอนต์สำหรับคำอธิบายภาพทั้งหมด, จัดรูปแบบรายการคำอธิบายภาพเดี่ยว, และซ่อนหรือกู้คืนรายการที่เลือก

ส่วนคำถามที่พบบ่อยครอบคลุมพฤติกรรมที่เกี่ยวข้อง รวมถึงการสำรองพื้นที่สำหรับคำอธิบายภาพ, การแสดงป้ายข้อความหลายบรรทัด, และการสืบทอดการจัดรูปแบบจากธีมของการนำเสนอ

## **ตำแหน่งของคำอธิบายภาพ**

ใช้เมธอด [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), และ [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) ของคำอธิบายภาพเพื่อระบุตำแหน่งและขนาดของมันเป็นส่วนของมิติของกราฟ

ตัวอย่างนี้สร้างการนำเสนอและเพิ่มกราฟคอลัมน์แบบกลุ่มพร้อมข้อมูลเริ่มต้นไปยังสไลด์แรก การหารค่าออฟเซ็ตและขนาดของคำอธิบายภาพที่ต้องการด้วยความกว้างและความสูงของกราฟจะแปลงเป็นค่าสัมพัทธ์: คำอธิบายภาพเลื่อนออกจากมุมบนซ้ายของกราฟ 50 พอยท์และมีขนาด 100x100 พอยท์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // แสดงตำแหน่งและขนาดของคำอธิบายภาพโดยสัมพันธ์กับกราฟ.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าขนาดฟอนต์ของคำอธิบายภาพ**

ใช้ [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) ของคำอธิบายภาพเพื่อเข้าถึงการจัดรูปแบบข้อความและใช้ [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) เพื่อตั้งค่าขนาดฟอนต์เป็นพอยท์

ตัวอย่างนี้สร้างกราฟด้วยข้อมูลเริ่มต้นและตั้งค่าข้อความคำอธิบายภาพเป็น 20 พอยท์ นอกจากนี้ยังปิดการกำหนดขอบอัตโนมัติสำหรับแกนตั้งและตั้งค่าช่วงเป็น -5 ถึง 10

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

## **ตั้งค่าขนาดฟอนต์ของรายการคำอธิบายภาพเดี่ยว**

ใช้คอลเลกชันที่คืนค่าจากเมธอด [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) ของคำอธิบายภาพเพื่อเข้าถึงการจัดรูปแบบสำหรับรายการเฉพาะ ดัชนีของรายการเริ่มจากศูนย์ ดังนั้นดัชนี `1` หมายถึงรายการที่สอง

ตัวอย่างนี้สร้างกราฟคอลัมน์แบบกลุ่มที่ข้อมูลเริ่มต้นมีอย่างน้อยสองซีรีส์ และจัดรูปแบบรายการคำอธิบายภาพที่สองด้วยข้อความหนา, ะเอียง, และสีฟ้า 20 พอยท์

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **ซ่อนรายการคำอธิบายภาพเดี่ยว**

เพื่อเอาซีรีส์เสริมออกจากคำอธิบายภาพโดยยังรักษาข้อมูลไว้ ให้เรียก [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) ด้วย `true` ผ่าน [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) วิธีนี้จะซ่อนเฉพาะรายการที่เลือก; ไม่ได้ลบซีรีส์หรือจุดข้อมูลออก การเรียก [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) ด้วย `false` จะซ่อนคำอธิบายภาพทั้งหมดแทน

ตัวอย่างด้านล่างสร้างกราฟคอลัมน์แบบกลุ่มที่มีหลายซีรีส์โดยใช้ข้อมูลเริ่มต้น มันซ่อนรายการคำอธิบายภาพของซีรีส์ที่สอง (ดัชนี `1`) แล้วบันทึกการนำเสนอ จากนั้นกู้คืนรายการโดยเรียก [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) ด้วย `false` และบันทึกเป็นสำเนาที่สอง คอลัมน์ยังคงแสดงในทั้งสองไฟล์

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

    // กู้คืนรายการเดียวกันโดยไม่เปลี่ยนแปลงข้อมูลกราฟ.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเปรียบเทียบด้านล่างแสดงกราฟเดียวกันที่รายการทั้งหมดแสดงและรายการที่สองถูกซ่อน คอลัมน์ของซีรีส์ที่สองยังคงไม่เปลี่ยนแปลง

![การเปรียบเทียบกราฟที่มีรายการคำอธิบายภาพทั้งหมดแสดงและรายการ Series 2 ถูกซ่อนจากคำอธิบายภาพ; คอลัมน์ทั้งหมดยังคงแสดงอยู่.](hide-legend-entry.png)

ในกราฟคอลัมน์, แถบ, และเส้น คำอธิบายภาพระบุซีรีส์ สำหรับกราฟพาย พวกมันระบุจุดข้อมูลเดี่ยว (สไลซ์) ดังนั้นให้ใช้ [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) กับสไลซ์ที่เลือกแทน API เอกสารเมธอดจุดข้อมูลนี้สำหรับประเภทกราฟ `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, และ `BarOfPie` อย่าสันนิษฐานว่ามันใช้ได้กับกราฟโดนัท ซึ่งไม่ได้รวมอยู่ในรายการนั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถให้กราฟสำรองพื้นที่สำหรับคำอธิบายภาพแทนการซ้อนทับได้หรือไม่?**

Yes. Call [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) with `false` to reserve space for the legend instead of allowing it to overlap the plot area.

**ฉันสามารถทำให้ป้ายคำอธิบายภาพหลายบรรทัดได้หรือไม่?**

Yes. Long labels can wrap when the available width is insufficient. You can also use newline characters in series names to request line breaks.

**ฉันจะทำให้คำอธิบายภาพใช้สกีมสีของธีมการนำเสนอได้อย่างไร?**

Leave the legend's colors, fills, and fonts unset so that it can inherit theme formatting. Explicit formatting overrides the corresponding theme settings.