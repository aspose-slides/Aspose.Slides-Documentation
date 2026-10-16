---
title: เพิ่มเส้นแนวโน้มลงในแผนภูมินำเสนอใน Java
linktitle: เส้นแนวโน้ม
type: docs
url: /th/java/trend-line/
keywords:
- แผนภูมิ
- เส้นแนวโน้ม
- เส้นแนวโน้มแบบเอ็กซ์โพเนนเชียล
- เส้นแนวโน้มเชิงเส้น
- เส้นแนวโน้มลอการิทึม
- เส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่
- เส้นแนวโน้มพหุนาม
- เส้นแนวโน้มกำลัง
- เส้นแนวโน้มกำหนดเอง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นแนวโน้มในแผนภูมิ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ Java — คู่มือเชิงปฏิบัติเพื่อดึงดูดผู้ชมของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเพิ่มเส้นแนวโน้มลงในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides แสดงวิธีการสร้างแผนภูมิ, เพิ่มเส้นแนวโน้มให้กับชุดข้อมูลในแผนภูมิ, และทำงานกับประเภทเส้นแนวโน้มหลายประเภท รวมถึงเส้นแนวโน้มแบบเอ็กซ์โพเนนเชียล, เชิงเส้น, ลอการิทึม, ค่าเฉลี่ยเคลื่อนที่, พหุนาม, และกำลัง.

นอกจากนี้ยังอธิบายวิธีการเพิ่มเส้นกำหนดเองลงในแผนภูมิโดยแทรกรูปร่างเส้น และรวมคำถามที่พบบ่อยสั้น ๆ เกี่ยวกับค่าการฉายเส้นแนวโน้มไปข้างหน้าและย้อนกลับ รวมถึงว่ามีการเก็บรักษาเส้นแนวโน้มไว้หรือไม่เมื่อส่งออกไปเป็น PDF หรือ SVG และเมื่อเรนเดอร์แผนภูมิเป็นภาพ

## **เพิ่มเส้นแนวโน้ม**

ใช้ [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) เพื่อเพิ่มเส้นแนวโน้มให้กับชุดข้อมูลในแผนภูมิ โดยเลือกชนิดของเส้นด้วย [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/) ตัวอย่างจะสร้างแผนภูมิคอลัมน์แบบจัดกลุ่มพร้อมข้อมูลเริ่มต้นและเพิ่มเส้นแนวโน้มสองเส้นให้กับแต่ละชุดข้อมูลจำนวนสามชุด

เส้นแนวโน้มแบบเอ็กซ์โพเนนเชียลซ่อนสมการและค่า R-squared ผ่าน [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) และ [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) ส่วนเส้นแนวโน้มเชิงเส้นแสดงเป็นสีแดง

เส้นแนวโน้มลอการิทึมใช้ [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) เพื่อกำหนดป้ายกำกับที่กำหนดเอง

ค่าเฉลี่ยเคลื่อนที่ใช้ [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) เป็นสามจุดข้อมูลและกำหนดชื่อเฉพาะด้วย [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-)

เส้นแนวโน้มพหุนามมี [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) เป็นสามและขยายหนึ่งหมวดต่อไปข้างหน้าผ่าน [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-)

เส้นแนวโน้มกำลังขยายหนึ่งหมวดย้อนกลับผ่าน [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-)

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าจุดตัดของเส้นแนวโน้ม**

ใช้ [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) เพื่อตั้งค่าค่า Y ของเส้นแนวโน้มที่ X = 0 การตั้งค่านี้รองรับสำหรับเส้นแนวโน้มเชิงเส้น, เอ็กซ์โพเนนเชียล, และพหุนาม

ตัวอย่างเช่น โมเดลต้นทุนการผลิตอาจต้องเริ่มต้นที่ต้นทุนคงที่ที่รู้จักคือ 100 แม้ว่าการวัดที่ปริมาณการผลิตที่ไม่เป็นศูนย์จะแสดงค่าพื้นฐานที่ต่างออกไป สำหรับเส้นแนวโน้มเชิงเส้น การกำหนดจุดตัดทำให้สมการ `y = ax + b` มีค่า `b = 100`; ความชันจะถูกปรับให้เหมาะกับข้อมูลภายใต้เงื่อนไขนั้น ไม่ได้เป็นการย้ายเส้นที่ได้ทำการฟิตแล้ว การตั้งค่าการตัดแกนควบคุมตำแหน่งที่แกนของแผนภูมิตัดกัน ไม่ได้ควบคุมสัมประสิทธิ์ของเส้นแนวโน้มที่ฟิตแล้ว

ตัวอย่างต่อไปนี้สร้างแผนภูมิกระจาย (XY) ด้วยปริมาณการผลิตตั้งแต่ 1 ถึง 4 และต้นทุน 170, 200, 230, และ 260 จะบันทึกแผนภูมิด้วยการตั้งค่าจุดตัดอัตโนมัติเริ่มต้น จากนั้นตั้งค่าจ점ตัดเป็น 100 และบันทึกไฟล์ PPTX ครั้งที่สอง ทั้งสองไฟล์แตกต่างกันเฉพาะการตั้งค่าจุดตัด เส้นแนวโน้มจะแสดงสมการและขยายกลับไปที่ X = 0

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ด้วยการคำนวณอัตโนมัติ ข้อมูลเหล่านี้ให้ผลลัพธ์ `y = 30x + 140` การตั้งค่าจุดตัดเป็น 100 จะให้ผลประมาณ `y = 43.33x + 100`: ค่าที่ฟิตที่ศูนย์ตรงกับค่าพื้นฐานที่รู้จัก ในขณะที่เส้นจะไม่ผ่านทุกจุดข้อมูลอีกต่อไป

| จุดตัดอัตโนมัติ | จุดตัดที่กำหนดเป็น 100 |
| --- | --- |
| ![เส้นแนวโน้มเชิงเส้นพร้อมจุดตัดที่คำนวณโดยอัตโนมัติค่า 140](intercept-automatic.png) | ![เส้นแนวโน้มเชิงเส้นพร้อมจุดตัดที่กำหนดค่า 100](intercept-fixed.png) |

ทั้งสองภาพใช้ข้อมูลและสเกลแกนเดียวกัน เส้นแนวโน้มถูกขยายกลับไปที่ X = 0 เพื่อแสดงจุดตัดของพวกมัน

โดยค่าเริ่มต้น [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) จะคืนค่า `Double.NaN` ซึ่งหมายถึงจุดตัดที่ไม่ได้ระบุ ไม่ใช่ศูนย์ จากนั้นจุดตัดจะถูกคำนวณอัตโนมัติจากข้อมูล

## **เพิ่มเส้นกำหนดเอง**

เส้นกำหนดเองเป็นรูปทรงที่วาดเหนือแผนภูมิ ไม่ใช่เส้นแนวโน้มที่คำนวณจากข้อมูลชุดข้อมูล ตัวอย่างนี้ใช้ [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) เพื่อเพิ่มเส้นแนวนอนลงในสไลด์เหนือแผนภูมิ ตำแหน่งของเส้นกำหนดโดยพิกัดของสไลด์หน่วยเป็นพอยต์ ดังนั้นเส้นจะเริ่มที่ขอบซ้ายของแผนภูมิและอยู่กึ่งกลางความสูงของแผนภูมิ ความกว้างของเส้นตรงกับความกว้างของแผนภูมิ [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) ทำให้เส้นมีสีแดงทึบ

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**'forward' กับ 'backward' หมายถึงอะไรสำหรับเส้นแนวโน้ม?**

เป็นความยาวของเส้นแนวโน้มที่ขยายไปข้างหน้า/ย้อนกลับ: สำหรับแผนภูมิกระจาย (XY) — หน่วยตามแกน; สำหรับแผนภูมิที่ไม่ใช่กระจาย — จำนวนหมวด. ยอมรับค่าไม่เป็นลบเท่านั้น

**เส้นแนวโน้มจะถูกเก็บรักษาไว้เมื่อส่งออกงานนำเสนอเป็น PDF หรือ SVG หรือเมื่อเรนเดอร์สไลด์เป็นภาพหรือไม่?**

ใช่ Aspose.Slides แปลงงานนำเสนอเป็น [PDF](/slides/th/java/convert-powerpoint-to-pdf/) หรือ [SVG](/slides/th/java/render-a-slide-as-an-svg-image/) และเรนเดอร์แผนภูมิเป็นภาพ; เส้นแนวโน้มซึ่งเป็นส่วนหนึ่งของแผนภูมิจะถูกเก็บรักษาไว้ในระหว่างการทำงานเหล่านี้ มีเมธอดให้ [ส่งออกภาพของแผนภูมิ](/slides/th/java/create-shape-thumbnails/) ด้วย