---
title: ปรับแต่งแผนภูมิ 3 มิติในพรีเซนเทชันบน Android
linktitle: แผนภูมิ 3 มิติ
type: docs
url: /th/androidjava/3d-chart/
keywords:
- แผนภูมิ 3 มิติ
- การหมุน
- ความลึก
- PowerPoint
- พรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "สร้างแผนภูมิ 3 มิติในพรีเซนเทชัน PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. ปรับการหมุน, สัดส่วนความสูง, ความลึกของแผนภูมิ, และช่องว่างระหว่างซีรีส์ด้วยตัวอย่าง Java."
---
## **ภาพรวม**

Aspose.Slides for Android via Java ให้คุณปรับแต่งมุมมองของแผนภูมิ 3 มิติผ่านเมธอด [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) วิธีการนี้จะแสดงวิธีการปรับการหมุน, สัดส่วนความสูง, ความลึก, แกนมุมฉาก, และช่องว่างระหว่างซีรีส์, จากนั้นบันทึกพรีเซนเทชันเป็นรูปแบบ PPTX

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3 มิติ**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) และใช้ [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อเพิ่มแผนภูมิคอลัมน์ 3 มิติแบบ stacked ลงในสไลด์แรกของมัน — มันแทนที่ซีรีส์และหมวดหมู่เริ่มต้นด้วยสองซีรีส์ที่มีค่าทั้งชุดละสามค่า ดัชนี worksheet `0` ระบุ worksheet ข้อมูลแรกของแผนภูมิ — แถว `0` เก็บชื่อซีรีส์และคอลัมน์ `0` เก็บป้ายชื่อหมวดหมู่

เมธอด [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) และ [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) ตั้งค่าการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ — เมธอด [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) กำหนดความลึกเป็น 150 % ของความกว้าง, ในขณะที่ [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) เปิดใช้งานแกนมุมฉากแทนมุมมองเชิงมิติ. การตั้งค่าเหล่านี้ทำให้การนำเสนอที่ได้ประกอบด้วยแผนภูมิที่เติมข้อมูลแล้วพร้อมการมองเห็น 3 มิติที่กำหนด

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ปรับสัดส่วนความสูงของแผนภูมิ 3 มิติ**

ใช้ [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) เพื่อตั้งค่าความสูงของแผนภูมิ 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง วิธีนี้เปลี่ยนสัดส่วนของฉาก 3 มิติโดยไม่ต้องปรับขนาดวัตถุแผนภูมิบนสไลด์

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) ด้วยข้อมูลเริ่มต้น: สามซีรีส์และสี่หมวดหมู่. มันบันทึกพรีเซนเทชันสามไฟล์พร้อมสัดส่วนความสูง 50 %, 100 % และ 200 %. ตำแหน่ง, ความกว้าง, และความสูงของแผนภูมิก็ยังคงคงที่. ข้อมูล, การหมุน, ความลึก, ช่องว่างของซีรีส์, และการจัดรูปแบบทั้งหมดเหมือนกันในทั้งสามไฟล์; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยนไป

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

ภาพต่อไปนี้แสดงการตั้งค่าสัดส่วนความสูงเดียวกันในตัวอย่าง .NET ที่เทียบได้และถูกส่งออกโดย Microsoft PowerPoint. ค่าที่น้อยกว่าจะทำให้ฉากแบนลง, ขณะที่ค่าที่มากจะทำให้ฉากสูงขึ้นภายในวัตถุแผนภูมิเดียวกัน. PowerPoint อาจปรับช่วงติ๊กแกนและตำแหน่งป้ายฉลากให้พอดีกับฉากด้วย

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ความสูงตั้งเป็น 50 เปอร์เซ็นต์ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ความสูงตั้งเป็น 100 เปอร์เซ็นต์ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ความสูงตั้งเป็น 200 เปอร์เซ็นต์ของความกว้าง](height_percent_200.png) |

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | ความสูงของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | ความสูงของวัตถุแผนภูมิบนสไลด์, หน่วยจุด |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | ความลึกของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | ช่องว่างระหว่างซีรีส์ตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์ |

การตั้งค่าสูงต่ำนี้ส่งผลต่อแผนภูมิคอลัมน์และบาร์ 3 มิติ รวมถึงรูปแบบทรงกระบอก, รูปมุม, และรูปพีระมิด, รวมถึงแผนภูมิ 3 มิติแบบเส้น, พื้นที่, พาย, และพื้นผิว. การเปรียบเทียบด้านบนใช้ประเภท `Column3D` ที่ได้รับการตรวจสอบแล้ว. การตั้งค่านี้ไม่ได้เปลี่ยนลักษณะของแผนภูมิ 2 มิติ `ClusteredColumn` หรือแผนภูมิ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของคลาส [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). สำหรับการตั้งค่าอื่น ๆ ของลักษณะแผนภูมิ, ดู [Chart Formatting](/slides/th/androidjava/chart-formatting/)

## **ปรับช่องว่างระหว่างซีรีส์**

ใช้ [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) เพื่อควบคุมระยะห่างระหว่างซีรีส์ข้อมูลตามแกนความลึกของแผนภูมิ 3 มิติ, แสดงเป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์. ใช้ค่าตั้งแต่ **0 ถึง 500**, รวม: `0` ลบช่องว่างออก, ค่ามากกว่าจะเพิ่มช่องว่าง. เมื่อความลึกของแผนภูมิคงที่, การเพิ่มช่องว่างจะทำให้มาร์คเกอร์บางลงตามแกนความลึก

เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--). การตั้งค่านี้ใช้กับทุกซีรีส์ในกลุ่มนั้น, ไม่ได้ใช้แค่ซีรีส์ที่ใช้ในการเข้าถึง. เมธอด [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) คืนค่าช่องว่างความลึกและสะท้อนการตั้งค่าของกลุ่มพาเรนท์

การตั้งค่านี้ส่งผลต่อแผนภูมิคอลัมน์และบาร์ 3 มิติ, รวมถึงรูปแบบกระบอก, รูปสcones, และรูปพีระมิด, รวมถึงแผนภูมิ 3 มิติแบบเส้นและพื้นที่. ลักษณะการแสดงผลขึ้นอยู่กับว่าซีรีส์จัดเรียงตามความลึก, เป็นกลุ่ม, หรือเป็นซ้อนกัน. เพื่อเปรียบเทียบช่องว่างระหว่างซีรีส์แยกกันอย่างชัดเจน, ใช้ `ChartType.Column3D` จากคลาส [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/)

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | ช่องว่างระหว่างซีรีส์ตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์ |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | ช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | ความลึกรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างแผนภูมิ |

ตัวอย่างต่อไปนี้ใช้ข้อมูลแผนภูมิเริ่มต้นที่มีสามซีรีส์และสี่หมวดหมู่. มันบันทึกพรีเซนเทชันสองไฟล์ที่มีข้อมูล, การหมุน, ความกว้างช่องว่าง, และความลึกของแผนภูมิเท่ากัน; มีเพียงช่องว่างความลึกที่เปลี่ยน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

ภาพต่อไปนี้แสดงการตั้งค่าช่องว่างความลึกเดียวกันในตัวอย่าง .NET ที่เทียบได้และถูกส่งออกโดย Microsoft PowerPoint.

| ช่องว่างความลึก: 0% | ช่องว่างความลึก: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ไม่มีช่องว่างระหว่างซีรีส์ตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3 มิติที่มีช่องว่าง 500 เปอร์เซ็นต์ระหว่างซีรีส์ตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทซีรีส์ 3 มิติและรูปร่างบาร์**

ในแผนภูมิโบล cylinder แบบจัดกลุ่ม, ซีรีส์แรกเริ่มต้นด้วยรูปร่างบาร์ทรงกระบอก. ตัวอย่างพิมพ์ค่าเต็มจำนวนที่คืนจาก [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) และ [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) ก่อนและหลังการเปลี่ยนแต่ละครั้ง. ตารางให้ชื่อคอนสแตนท์ที่สอดคล้องกัน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| การเปลี่ยนแปลงที่ซีรีส์แรก | ประเภทซีรีส์ | รูปร่างบาร์ |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| ตั้งค่าประเภทซีรีส์เป็น `ClusteredCone` | `ClusteredCone` | `Cone` |
| ตั้งค่ารูปร่างบาร์เป็น `Box` | `ClusteredColumn3D` | `Box` |

การตั้งค่ารูปร่างเป็น `Box` จะเปลี่ยนประเภทซีรีส์เป็น `ClusteredColumn3D` ด้วย. หากโค้ดของคุณใช้เงื่อนไขตามประเภทซีรีส์, ให้เรียก `series.getType()` หลังจากเปลี่ยนรูปร่าง. ค่าที่เก็บไว้ก่อนการกำหนดจะยังคงส่งผลให้เลือกเงื่อนไข `ClusteredCone` อยู่

![การเปรียบเทียบ PowerPoint แสดงซีรีส์แรกเป็น cylinder, cone, และคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดบ้างที่สนับสนุนโหมด 3 มิติใน Aspose.Slides?**

Aspose.Slides สนับสนุนรูปแบบ 3 มิติของแผนภูมิคอลัมน์, รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100 % Stacked Column 3D, พร้อมประเภท 3 มิติที่เกี่ยวข้องที่เปิดให้เข้าถึงผ่านคลาส [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). สำหรับรายการที่ถูกต้องและเป็นปัจจุบัน, โปรดตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) ในอ้างอิง API ของรุ่นที่คุณติดตั้ง

**ฉันสามารถรับภาพแรสเตอร์ของแผนภูมิ 3 มิติเพื่อใช้ในรายงานหรือเว็บได้หรือไม่?**

ได้. คุณสามารถส่งออกแผนภูมิเพื่อเป็นภาพด้วย [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) หรือ [เรนเดอร์สไลด์ทั้งหมด](/slides/th/androidjava/convert-powerpoint-to-png/) ไปเป็นรูปแบบเช่น PNG หรือ JPEG. วิธีนี้เป็นประโยชน์เมื่อคุณต้องการตัวอย่างแรสเตอร์หรือฝังแผนภูมิในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องพึ่ง Microsoft PowerPoint

**ประสิทธิภาพของการสร้างและเรนเดอร์แผนภูมิ 3 มิติขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ. เพื่อให้ได้ผลลัพธ์ที่ดีที่สุด, ควรลดเอฟเฟ็กต์ 3 มิติให้เหลือน้อยที่สุด, หลีกเลี่ยงพื้นผิวที่มีลายรายละเอียดหนักบนผนังและพื้นที่กราฟ, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อเป็นไปได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ