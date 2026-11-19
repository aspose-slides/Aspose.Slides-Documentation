---
title: ปรับแต่งแผนภูมิ 3 มิติในงานนำเสนอโดยใช้ Java
linktitle: แผนภูมิ 3 มิติ
type: docs
url: /th/java/3d-chart/
keywords:
- แผนภูมิ 3 มิติ
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "สร้างแผนภูมิ 3 มิติในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java ปรับการหมุน, อัตราส่วนความสูง, ความลึกของแผนภูมิ, และระยะห่างระหว่างชุดข้อมูลด้วยตัวอย่าง Java."
---
## **ภาพรวม**

Aspose.Slides for Java ให้คุณปรับแต่งมุมมองของแผนภูมิ 3 มิติผ่านเมธอด [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . บทความนี้สาธิตวิธีปรับการหมุน, อัตราส่วนความสูง, ความลึก, แกนมุมฉาก, และระยะห่างระหว่างชุดข้อมูล, จากนั้นบันทึกงานนำเสนอในรูปแบบ PPTX

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3 มิติ**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) และใช้ [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อเพิ่มแผนภูมิคอลัมน์ 3 มิติแบบ stacked ลงในสไลด์แรกของมัน  ตัวอย่างนี้แทนที่ชุดข้อมูลและหมวดหมู่เริ่มต้นด้วยสองชุดข้อมูลที่มีค่าทั้งหมดสามค่า ใบงานดัชนี `0` ระบุ worksheet ข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อชุดข้อมูล, และคอลัมน์ `0` เก็บป้ายชื่อหมวดหมู่

เมธอด [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) และ [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) ตั้งค่าการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ  [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ขณะเดียวกัน [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) เปิดใช้แกนมุมฉากแทนมุมมองเชิงมุม  งานนำเสนอที่ได้จะมีแผนภูมิที่เติมข้อมูลพร้อมการตั้งค่ามุมมอง 3 มิติเหล่านี้

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

## **ปรับอัตราส่วนความสูงของแผนภูมิ 3 มิติ**

ใช้ [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) เพื่อกำหนดความสูงของแผนภูมิ 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง  สิ่งนี้จะเปลี่ยนอัตราส่วนของฉาก 3 มิติโดยไม่ต้องเปลี่ยนขนาดวัตถุแผนภูมิบนสไลด์

ตัวอย่างต่อไปสร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) ด้วยข้อมูลเริ่มต้น: สามชุดข้อมูลและสี่หมวดหมู่  จะบันทึกงานนำเสนอสามไฟล์โดยตั้งค่าอัตราส่วนความสูงเป็น 50%, 100% และ 200%  ตำแหน่ง, ความกว้างและความสูงของแผนภูมิก็ยังคงคงที่  ข้อมูล, การหมุน, ความลึก, ระยะห่างระหว่างชุดข้อมูล, และการจัดรูปแบบจะเหมือนกันในไฟล์ทั้งสาม; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยน

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

ภาพต่อไปนี้แสดงการตั้งค่าความสูงเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกด้วย Microsoft PowerPoint  เปอร์เซ็นต์ที่น้อยกว่าจะทำให้ฉากแบนลง, ส่วนเปอร์เซ็นต์ที่มากจะทำให้ฉากสูงขึ้นภายในวัตถุแผนภูมิเดียวกัน  PowerPoint อาจปรับช่วงการทำเครื่องหมายแกนและการจัดวางป้ายกำกับเพื่อให้พอกับฉาก

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลลัมน์ 3 มิติที่กำหนดความสูงเป็น 50% ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลลัมน์ 3 มิติที่กำหนดความสูงเป็น 100% ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลลัมน์ 3 มิติที่กำหนดความสูงเป็น 200% ของความกว้าง](height_percent_200.png) |

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | ความสูงของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | ความสูงของวัตถุแผนภูมิบนสไลด์, หน่วยเป็นพอยต์ |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | ความลึกของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | ระยะห่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์ |

การตั้งค่าความสูงมีผลต่อแผนภูมิคอลัมน์และแผนภูมิบาร์ 3 มิติ รวมถึงรูปแบบทรงกระบอก, รูปทรงกรวย, และรูปทรงพีระมิด, รวมถึงแผนภูมิเส้น, พื้นที่, พาย, และพื้นผิว  ตัวอย่างด้านบนใช้ประเภท `Column3D` ที่ตรวจสอบแล้ว  การตั้งค่านี้ไม่เปลี่ยนลักษณะของแผนภูมิ `ClusteredColumn` 2 มิติหรือแผนภูมิ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของคลาส [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)  สำหรับการตั้งค่าลักษณะอื่น ๆ ของแผนภูมิ, ดูที่ [Chart Formatting](/slides/th/java/chart-formatting/)

## **ปรับช่องว่างระหว่างชุดข้อมูล**

ใช้ [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) เพื่อควบคุมระยะห่างระหว่างชุดข้อมูลตามแกนความลึกของแผนภูมิ 3 มิติ, แสดงเป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์  ใช้ค่าตั้งแต่ **0 ถึง 500** (รวม)  `0` จะลบช่องว่าง, ค่าที่มากกว่าจะเพิ่มระยะห่าง  เมื่อความลึกของแผนภูมิมีค่าคงที่, การเพิ่มช่องว่างทำให้มาร์คเกอร์บางลงตามแกนความลึก

เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--)  การตั้งค่านี้ใช้กับทุกชุดข้อมูลในกลุ่มนั้น, ไม่ใช่แค่ชุดข้อมูลที่ใช้เพื่อเข้าถึง  [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) คืนค่าความลึกของช่องว่างและสะท้อนการตั้งค่าของกลุ่มแม่

การตั้งค่านี้มีผลต่อแผนภูมิคอลัมน์และบาร์ 3 มิติ รวมถึงรูปแบบทรงกระบอก, รูปทรงกรวย, และรูปทรงพีระมิด, รวมถึงแผนภูมิเส้นและพื้นที่  ลักษณะจะขึ้นอยู่กับว่าชุดข้อมูลถูกจัดเรียงในแนวลึก, กลุ่ม, หรือซ้อนกัน  สำหรับการเปรียบเทียบที่ชัดเจนของช่องว่างระหว่างชุดข้อมูลที่แยกกัน, ใช้ `ChartType.Column3D` จากคลาส [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | ระยะห่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์ |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | ระยะห่างระหว่างกลุ่มบาร์หรือคอลลัมน์ที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลลัมน์ |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | ความลึกรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างแผนภูมิ |

ตัวอย่างต่อไปนี้ใช้ข้อมูลเริ่มต้นของแผนภูมิ, ซึ่งประกอบด้วยสามชุดข้อมูลและสี่หมวดหมู่  จะบันทึกงานนำเสนอสองไฟล์โดยข้อมูล, การหมุน, ความกว้างช่องว่าง, และความลึกของแผนภูมิเหมือนกัน; มีเพียงความลึกของช่องว่างที่เปลี่ยน

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

ภาพต่อไปนี้แสดงการตั้งค่าความลึกช่องว่างเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกด้วย Microsoft PowerPoint

| ความลึกของช่องว่าง: 0% | ความลึกของช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลลัมน์ 3 มิติที่ไม่มีช่องว่างระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลลัมน์ 3 มิติที่มีช่องว่าง 500% ระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทชุดข้อมูล 3D และรูปแบบบาร์**

ในแผนภูมิโดยรวมแบบกระบอก, ชุดข้อมูลแรกเริ่มด้วยรูปแบบบาร์ทรงกระบอก  ตัวอย่างพิมพ์ค่าจำนวนเต็มที่ส่งกลับโดย [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) และ [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) ก่อนและหลังการเปลี่ยนแปลงแต่ละครั้ง  ตารางต่อไปให้ชื่อค่าคงที่ที่สอดคล้องกัน

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

| การเปลี่ยนแปลงในชุดข้อมูลแรก | ชนิดชุดข้อมูล | รูปแบบบาร์ |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| ตั้งค่าชนิดชุดข้อมูลเป็น `ClusteredCone` | `ClusteredCone` | `Cone` |
| ตั้งค่าแบบบาร์เป็น `Box` | `ClusteredColumn3D` | `Box` |

การตั้งค่าให้รูปแบบเป็น `Box` ยังทำให้ชนิดชุดข้อมูลเปลี่ยนเป็น `ClusteredColumn3D` ด้วย  หากโค้ดของคุณทำการตรวจสอบชนิดชุดข้อมูล, ให้เรียก `series.getType()` หลังจากเปลี่ยนรูปแบบ  ค่าที่เก็บไว้ก่อนการกำหนดจะยังคงเลือกสาขา `ClusteredCone` อยู่

![การเปรียบเทียบ PowerPoint แสดงชุดข้อมูลแรกเป็นกระบอก, กรวย, และคอลลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **FAQ**

**แผนภูมิประเภทใดรองรับโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลลัมน์, รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D, พร้อมกับประเภท 3D ที่เกี่ยวข้องที่เปิดเผยผ่านคลาส [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)  สำหรับรายการที่แม่นยำและอัปเดตล่าสุด, ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) ในเอกสาร API ของเวอร์ชันที่คุณติดตั้ง

**ฉันสามารถรับภาพแรสเตอร์ของแผนภูมิ 3D เพื่อใช้ในรายงานหรือเว็บได้หรือไม่?**

ได้ คุณสามารถส่งออกแผนภูมิเป็นภาพด้วย [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) หรือ [แสดงผลสไลด์ทั้งหมด](/slides/th/java/convert-powerpoint-to-png/) ไปยังรูปแบบเช่น PNG หรือ JPEG  สิ่งนี้มีประโยชน์เมื่อคุณต้องการภาพแรสเตอร์เพื่อแสดงตัวอย่างหรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint

**การสร้างและแสดงผลแผนภูมิ 3D ขนาดใหญ่มีประสิทธิภาพแค่ไหน?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ  เพื่อผลลัพธ์ที่ดีที่สุด, ควรใช้เอฟเฟกต์ 3D อย่างจำกัด, หลีกเลี่ยงการใช้พื้นผิวเท็กซ์เจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อชุดเมื่อทำได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและขนาด) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ