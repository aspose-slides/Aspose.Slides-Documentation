---
title: เพิ่มเส้นแนวโน้มให้กับแผนภูมิการนำเสนอใน Android
linktitle: เส้นแนวโน้ม
type: docs
url: /th/androidjava/trend-line/
keywords:
- แผนภูมิ
- เส้นแนวโน้ม
- เส้นแนวโน้มแบบเอ็กซ์โพเนนเชียล
- เส้นแนวโน้มเชิงเส้น
- เส้นแนวโน้มลอการิทึม
- เส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่
- เส้นแนวโน้มพหุนาม
- เส้นแนวโน้มพาวเวอร์
- เส้นแนวโน้มกำหนดเอง
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นแนวโน้มในแผนภูมิ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ Android ผ่าน Java — คู่มือที่ใช้งานได้จริงเพื่อดึงดูดผู้ชมของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเพิ่มเส้นแนวโน้มลงในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides ซึ่งจะแสดงวิธีสร้างแผนภูมิ, การเพิ่มเส้นแนวโน้มให้กับชุดข้อมูลของแผนภูมิ, และการทำงานกับประเภทเส้นแนวโน้มหลายประเภท รวมถึงเอ็กซ์โพเนนเชียล, เชิงเส้น, ลอการิทึม, ค่าเฉลี่ยเคลื่อนที่, พหุนาม, และพาวเวอร์

นอกจากนี้ยังอธิบายวิธีการเพิ่มเส้นกำหนดเองลงในแผนภูมิโดยการแทรกรูปทรงเส้น และรวม FAQ สั้นเกี่ยวกับค่าการฉายเส้นแนวโน้มไปข้างหน้าและถอยหลังและว่าการส่งออกเส้นแนวโน้มจะถูกเก็บไว้หรือไม่เมื่อส่งออกเป็น PDF หรือ SVG หรือเมื่อเรนเดอร์แผนภูมิเป็นภาพ

## **เพิ่มเส้นแนวโน้ม**

ใช้ [ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) เพื่อเพิ่มเส้นแนวโน้มให้กับชุดข้อมูลของแผนภูมิ โดยเลือกประเภทด้วย [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/) ตัวอย่างสร้างแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลเริ่มต้นและเพิ่มเส้นแนวโน้มสองเส้นให้กับแต่ละชุดข้อมูลจำนวนสามชุด

เส้นแนวโน้มเชิงเอ็กซ์โพเนนเชียลซ่อนสมการและค่า R-squared ด้วย [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) และ [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) ในขณะที่เส้นแนวโน้มเชิงเส้นเป็นสีแดง เส้นแนวโน้มลอการิทึมใช้ [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) สำหรับป้ายกำกับแบบกำหนดเอง ค่าเฉลี่ยเคลื่อนที่ใช้ [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) ที่สามจุดข้อมูลและใช้ [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) ที่กำหนดเอง

เส้นแนวโน้มพหุนามมี [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) ที่สามและขยายหนึ่งหมวดหมู่ไปข้างหน้าด้วย [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-). เส้นแนวโน้มพาวเวอร์ขยายหนึ่งหมวดหมู่ย้อนกลับด้วย [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
## **ตั้งค่าตัดของเส้นแนวโน้ม**

ใช้ [setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) เพื่อกำหนดค่าของ Y ของเส้นแนวโน้มที่ X = 0 การตั้งค่านี้รองรับสำหรับเส้นแนวโน้มเชิงเส้น, เชิงเอ็กซ์โพเนนเชียล และพหุนาม

ตัวอย่างเช่น โมเดลต้นทุนการผลิตอาจต้องเริ่มต้นที่ต้นทุนคงที่ที่รู้จักคือ 100 แม้ว่าเมื่อวัดที่ปริมาณการผลิตไม่เป็นศูนย์จะบ่งชี้ฐานข้อมูลที่ต่างออกไป สำหรับเส้นแนวโน้มเชิงเส้น การกำหนดค่าตัดทำให้สมการ `y = ax + b` มี `b = 100`; ความชันจะถูกฟิตกับข้อมูลภายใต้เงื่อนไขนั้น ซึ่งไม่ใช่การย้ายเส้นที่ฟิตแล้ว การตั้งค่าการตัดแกนควบคุมตำแหน่งที่แกนของแผนภูมิกัน ไม่ใช่ค่าสัมประสิทธิ์ของเส้นแนวโน้มที่ฟิต

ตัวอย่างต่อไปนี้สร้างแผนภูมิแบบกระจาย (XY) พร้อมปริมาณการผลิตตั้งแต่ 1 ถึง 4 และต้นทุน 170, 200, 230, และ 260 ซึ่งบันทึกแผนภูมิด้วยค่าตัดอัตโนมัติเริ่มต้น, ตั้งค่าตัดเป็น 100, และบันทึกเป็น PPTX ที่สอง ไฟล์ทั้งสองแตกต่างกันเฉพาะค่าตัด เส้นแนวโน้มจะแสดงสมการและขยายกลับไปที่ X = 0

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

ด้วยการคำนวณอัตโนมัติ ข้อมูลเหล่านี้ให้ผลลัพธ์ `y = 30x + 140` การตั้งค่าตัดเป็น 100 แทนจะให้ผลประมาณ `y = 43.33x + 100`: ค่าที่ฟิตที่ศูนย์ตรงกับฐานข้อมูลที่รู้จัก แต่เส้นจะไม่ผ่านทุกจุดข้อมูลอีกต่อไป

| ค่าตัดอัตโนมัติ | ค่าตัดคงที่ 100 |
| --- | --- |
| ![เส้นแนวโน้มเชิงเส้นที่คำนวณค่าตัดอัตโนมัติ 140](intercept-automatic.png) | ![เส้นแนวโน้มเชิงเส้นที่มีค่าตัดคงที่ 100](intercept-fixed.png) |

ภาพทั้งสองใช้ข้อมูลและสเกลแกนเดียวกัน เส้นแนวโน้มจะถูกขยายกลับไปที่ X = 0 เพื่อแสดงค่าตัดของมัน

โดยค่าเริ่มต้น [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) จะคืนค่า `Double.NaN` ซึ่งหมายถึงค่าตัดที่ไม่ได้ระบุ แทนที่จะเป็นศูนย์ จากนั้นค่าตัดจะถูกคำนวณอัตโนมัติจากข้อมูล

## **เพิ่มเส้นกำหนดเอง**

เส้นกำหนดเองเป็นรูปทรงที่วาดบนแผนภูมิแทนที่จะเป็นเส้นแนวโน้มที่คำนวณจากข้อมูลชุด ตัวอย่างนี้ใช้ [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) เพื่อเพิ่มเส้นแนวนอนลงในสไลด์เหนือแผนภูมิ ตำแหน่งของเส้นระบุในพิกัดของสไลด์ หน่วยเป็นจุด ดังนั้นจึงเริ่มที่ขอบซ้ายของแผนภูมิและอยู่ครึ่งหนึ่งของความสูงแผนภูมิ ความกว้างของเส้นเท่ากับความกว้างของแผนภูมิ [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) ให้เส้นเป็นสีแดงทึบ

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

**'forward' และ 'backward' หมายถึงอะไรสำหรับเส้นแนวโน้ม?**

พวกมันคือความยาวของเส้นแนวโน้มที่ฉายไปข้างหน้า/ถอยหลัง: สำหรับแผนภูมิแบบกระจาย (XY) — เป็นหน่วยแกน; สำหรับแผนภูมิที่ไม่ใช่แบบกระจาย — เป็นจำนวนหมวดหมู่ จ่ามากค่าต้องเป็นจำนวนที่ไม่เป็นลบเท่านั้น

**เส้นแนวโน้มจะถูกเก็บไว้เมื่อต้องส่งออกการนำเสนอเป็น PDF หรือ SVG หรือเมื่อเรนเดอร์สไลด์เป็นภาพหรือไม่?**

ใช่ Aspose.Slides จะแปลงการนำเสนอเป็น [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/) หรือ [SVG](/slides/th/androidjava/render-a-slide-as-an-svg-image/) และเรนเดอร์แผนภูมิเป็นภาพ; เส้นแนวโน้มในฐานะส่วนหนึ่งของแผนภูมิจึงถูกเก็บไว้ระหว่างการทำงานเหล่านี้ นอกจากนี้ยังมีเมธอดให้ [ส่งออกภาพของแผนภูมิ](/slides/th/androidjava/create-shape-thumbnails/) ด้วย