---
title: ปรับแต่งแผนภูมิ 3D ในงานนำเสนอด้วย Java
linktitle: แผนภูมิ 3D
type: docs
url: /th/java/3d-chart/
keywords:
- แผนภูมิ 3D
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "สร้างแผนภูมิ 3D ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java. ปรับการหมุน, อัตราส่วนความสูง, ความลึกของแผนภูมิ, และระยะห่างระหว่างซีรีส์ด้วยตัวอย่าง Java."
---
## **ภาพรวม**

Aspose.Slides for Java ให้คุณปรับแต่งการมองเห็นของแผนภูมิ 3D ผ่านเมธอด [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) นี้ บทความนี้แสดงวิธีปรับการหมุน, อัตราส่วนความสูง, ความลึก, แกนมุมขวา, และการเว้นระยะระหว่างซีรีส์, จากนั้นบันทึกงานพรีเซนเทชันเป็นรูปแบบ PPTX

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3D**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) และใช้ [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อเพิ่มแผนภูมิคอลัมน์ 3D แบบ stacked ลงในสไลด์แรกของมัน มันแทนที่ซีรีส์และหมวดหมู่เริ่มต้นด้วยสองซีรีส์ที่มีแต่ละซีรีส์มีสามค่า ดัชนีเวิร์กชีท `0` ระบุเวิร์กชีทข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อซีรีส์, และคอลัมน์ `0` เก็บป้ายชื่อหมวดหมู่

เมธอด [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) และ [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) ตั้งค่าการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ในขณะที่ [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) เปิดใช้งานแกนมุมขวาแทนมุมมอง perspective. งานพรีเซนเทชันที่ได้จะมีแผนภูมิที่เติมข้อมูลด้วยการตั้งค่า 3D view นี้

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

## **ปรับใช้การเติมภาพบนพื้นผิวแผนภูมิ 3D**

แผนภูมิ 3D มีสามพื้นผิวที่คุณสามารถเติมแยกกันได้: [ผนังด้านข้าง](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--), [ผนังด้านหลัง](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--), และ [พื้น](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--). ตั้งค่าประเภทการเติมของพื้นผิวโดยใช้ [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) เป็น `Picture` และกำหนดรูปภาพ. ตั้งค่า[โหมดการเติมภาพ](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-)และ[ประเภทภาพ](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-)ของพื้นผิวเป็น `Stretch` เพื่อให้ภาพหนึ่งสำเนาครอบคลุมทั่วพื้นผิว

บันทึก [arrow.png](arrow.png) ในไดเรกทอรีทำงาน ตัวอย่างนี้หมุนแผนภูมิและเพิ่มค่าสูงสุดบนแกนแนวดิ่งเพื่อให้พื้นมองเห็นระหว่างคอลัมน์ จากนั้นทำสำเนาสไลด์สองครั้งและใช้ลูกศรบนพื้นผิวนั้นบนแต่ละสไลด์ ทั้งสามแผนภูมิจะเก็บข้อมูลเดียวกัน, มุมมอง, และพื้นหลัง

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint แสดงสไลด์ทั้งสามดังต่อไปนี้

| ผนังด้านข้าง | ผนังด้านหลัง | พื้น |
| --- | --- | --- |
| ![ลูกศรชี้เข้าสู่แผนภูมิตามผนังด้านข้าง](side-wall.png) | ![ลูกศรชี้ไปทางขวาบนผนังด้านหลัง](back-wall.png) | ![ลูกศรชี้ไปทางขวาบนพื้นระหว่างคอลัมน์](floor.png) |

## **ปรับอัตราส่วนความสูงของแผนภูมิ 3D**

ใช้ [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) เพื่อตั้งค่าความสูงของแผนภูมิ 3D เป็นเปอร์เซ็นต์ของความกว้าง. สิ่งนี้จะเปลี่ยนอัตราส่วนของฉาก 3D โดยไม่ต้องปรับขนาดวัตถุแผนภูมิบนสไลด์

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) ด้วยข้อมูลเริ่มต้น: สามซีรีส์และสี่หมวดหมู่. มันบันทึกงานพรีเซนเทชันสามไฟล์ด้วยอัตราส่วนความสูง 50%, 100%, และ 200%. ตำแหน่ง, ความกว้าง, และความสูงของแผนภูมิก็คงที่. ข้อมูล, การหมุน, ความลึก, การเว้นระยะระหว่างซีรีส์, และการจัดรูปแบบเหมือนกันในไฟล์ทั้งหมด; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยน

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

ภาพต่อไปนี้แสดงการตั้งค่าความสูงเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกโดย Microsoft PowerPoint. เปอร์เซ็นต์ที่น้อยกว่าทำให้ฉากแบนลง, ในขณะที่เปอร์เซ็นต์ที่สูงกว่าจะทำให้ฉากสูงขึ้นภายในวัตถุแผนภูมิเดียวกัน. PowerPoint อาจปรับช่วงติ๊กแกนและการจัดวางป้ายกำกับเพื่อให้พอดีกับฉาก

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3D ที่ตั้งค่าความสูงเป็น 50% ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3D ที่ตั้งค่าความสูงเป็น 100% ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3D ที่ตั้งค่าความสูงเป็น 200% ของความกว้าง](height_percent_200.png) |

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผลลัพธ์ |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | ความสูงของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | ความสูงของวัตถุแผนภูมิบนสไลด์, หน่วยเป็นพ้อยท์ |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | ความลึกของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | ระยะห่างระหว่างซีรีส์ตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของมาร์กเกอร์ |

การตั้งค่าความสูงมีผลต่อแผนภูมิคอลัมน์และแผนภูมิบาร์ 3D รวมถึงรูปแบบไซลINDER, CONE, PYRAMID, รวมถึงแผนภูมิ 3D LINE, AREA, PIE, และ SURFACE. การเปรียบเทียบด้านบนใช้ชนิด `Column3D` ที่ได้รับการยืนยัน. การตั้งค่านี้ไม่เปลี่ยนลักษณะของแผนภูมิ 2D `ClusteredColumn` หรือ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของคลาส [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). สำหรับการตั้งค่าลักษณะอื่นของแผนภูมิ ดูที่ [Chart Formatting](/slides/th/java/chart-formatting/)

## **ปรับช่องว่างระหว่างซีรีส์**

ใช้ [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) เพื่อควบคุมระยะห่างระหว่างซีรีส์ข้อมูลตามแกนความลึกของแผนภูมิ 3D, แสดงเป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์. ใช้ค่าตั้งแต่ **0 ถึง 500**, รวม: `0` จะลบช่องว่าง, ค่าที่มากขึ้นจะเพิ่มช่องว่าง. ด้วยความลึกแผนภูมิที่คงที่, การเพิ่มช่องว่างทำให้มาร์คเกอร์บางลงตามแกนความลึก

เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--). การตั้งค่านี้ใช้กับทุกซีรีส์ในกลุ่มนั้น, ไม่ใช่เพียงซีรีส์ที่ใช้เข้าถึงมัน. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) คืนค่าช่องว่างความลึกและสะท้อนการตั้งค่าของกลุ่มแม่

การตั้งค่านี้มีผลต่อแผนภูมิคอลัมน์และบาร์ 3D รวมถึงรูปแบบไซลINDER, CONE, PYRAMID, รวมถึงแผนภูมิ 3D LINE และ AREA. ลักษณะของแผนภูมิขึ้นอยู่กับว่าซีรีส์ถูกจัดเรียงตามความลึก, clustering หรือ stacked. เพื่อการเปรียบเทียบช่องว่างระหว่างซีรีส์แยกกันอย่างชัดเจน, ใช้ `ChartType.Column3D` จากคลาส [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผลลัพธ์ |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | ระยะห่างระหว่างซีรีส์ตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของมาร์กเกอร์ |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | ระยะห่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างของบาร์หรือคอลัมน์ |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | ความลึกโดยรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างของแผนภูมิ |

ตัวอย่างต่อไปนี้เป็นตัวอย่างที่ทำงานโดยอัตโนมัติใช้ข้อมูลแผนภูมิเริ่มต้นซึ่งมีสามซีรีส์และสี่หมวดหมู่. มันบันทึกงานพรีเซนเทชันสองไฟล์ที่มีข้อมูล, การหมุน, ความกว้างช่องว่าง, และความลึกของแผนภูมิเดียวกัน; มีเพียงความลึกช่องว่างที่เปลี่ยน

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

ภาพต่อไปนี้แสดงการตั้งค่าความลึกช่องว่างเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกโดย Microsoft PowerPoint

| ความลึกช่องว่าง: 0% | ความลึกช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3D ที่ไม่มีช่องว่างระหว่างซีรีส์ตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3D ที่มีช่องว่าง 500% ระหว่างซีรีส์ตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทซีรีส์ 3D และรูปแบบแท่ง**

ในแผนภูมิเซลลูลาร์แบบ clustered, ซีรีส์แรกเริ่มด้วยรูปแบบแท่งเป็น Cylinder. ตัวอย่างพิมพ์ค่าจำนวนเต็มที่คืนจาก [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) และ [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) ก่อนและหลังแต่ละการเปลี่ยน. ตารางให้ชื่อคงที่ที่สอดคล้องกัน

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

| เปลี่ยนในซีรีส์แรก | ประเภทซีรีส์ | รูปแบบแท่ง |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| ตั้งค่าประเภทซีรีส์เป็น `ClusteredCone` | `ClusteredCone` | `Cone` |
| ตั้งค่ารูปแบบแท่งเป็น `Box` | `ClusteredColumn3D` | `Box` |

การตั้งค่ารูปแบบเป็น `Box` ยังทำให้ประเภทซีรีส์เปลี่ยนเป็น `ClusteredColumn3D`. หากโค้ดของคุณมีการสาขาตามประเภทซีรีส์, ให้เรียก `series.getType()` หลังจากเปลี่ยนรูปแบบ. ค่าที่เก็บไว้ก่อนการกำหนดค่าจะยังคงเลือกสาขา `ClusteredCone`

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดบ้างที่รองรับโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลัมน์, รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D, พร้อมกับประเภท 3D ที่เกี่ยวข้องที่เปิดเผยผ่านคลาส [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). สำหรับรายการที่แม่นยำและอัปเดตล่าสุด, ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) ในเอกสาร API ของเวอร์ชันที่คุณติดตั้ง

**สามารถดึงภาพเรสเตอร์ของแผนภูมิ 3D สำหรับรายงานหรือเว็บได้หรือไม่?**

ได้. คุณสามารถส่งออกแผนภูมิเป็นภาพด้วย [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) หรือ [render the entire slide](/slides/th/java/convert-powerpoint-to-png/) ไปเป็นฟอร์แมตเช่น PNG หรือ JPEG. สิ่งนี้มีประโยชน์เมื่อคุณต้องการภาพพรีวิวแบบเรสเตอร์หรือฝังแผนภูมิในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint

**ประสิทธิภาพการสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นกับปริมาณข้อมูลและความซับซ้อนของภาพ. เพื่อผลลัพธ์ที่ดีที่สุด, ควรลดเอฟเฟกต์ 3D ให้เหลือน้อยที่สุด, หลีกเลี่ยงพื้นผนังกระเทือนที่หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อทำได้, และเรนเดอร์ไปยังขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ