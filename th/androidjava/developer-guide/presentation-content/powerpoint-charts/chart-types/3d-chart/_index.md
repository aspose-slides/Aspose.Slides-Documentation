---
title: ปรับแต่งแผนภูมิ 3 มิติในงานนำเสนอบน Android
linktitle: แผนภูมิ 3 มิติ
type: docs
url: /th/androidjava/3d-chart/
keywords:
- 3D chart
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างแผนภูมิ 3 มิติในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Android via Java. ปรับการหมุน, สัดส่วนความสูง, ความลึกของแผนภูมิ, และช่องว่างระหว่างซีรีส์ด้วยตัวอย่าง Java."
---
## **ภาพรวม**

Aspose.Slides for Android via Java ให้คุณกำหนดมุมมองของแผนภูมิ 3 มิติผ่านเมธอด [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) วิธีการนี้แสดงวิธีปรับการหมุน, สัดส่วนความสูง, ความลึก, แกนมุมฉาก, และช่องว่างระหว่างซีรีส์, จากนั้นบันทึกงานนำเสนอในรูปแบบ PPTX.

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3 มิติ**

ตัวอย่างด้านล่างจะสร้าง [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) และใช้ [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อเพิ่มแผนภูมิคอลัมน์ 3 มิติแบบซ้อนบนสไลด์แรกของมัน. มันแทนที่ซีรีส์และหมวดหมู่เริ่มต้นด้วยสองซีรีส์ที่มีค่าต่าง ๆ แต่ละซีรีส์มีสามค่า. ดัชนี Worksheet `0` ระบุแผ่นงานข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อซีรีส์, และคอลัมน์ `0` เก็บป้ายชื่อหมวดหมู่.

เมธอด [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) และ [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) กำหนดการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ. [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ส่วน [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) เปิดใช้งานแกนมุมฉากแทนมุมมองเชิงลึก. งานนำเสนอที่ได้จะมีแผนภูมิที่เติมข้อมูลพร้อมการตั้งค่ามุมมอง 3 มิติเหล่านี้.

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

## **ใช้การเติมรูปภาพบนพื้นผิวแผนภูมิ 3 มิติ**

แผนภูมิ 3 มิติมีสามพื้นผิวที่คุณสามารถเติมแยกกันได้: [side wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--), [back wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--), และ [floor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--). ตั้งค่า [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) ของพื้นผิวเป็น `Picture` และกำหนดภาพ. ตั้งค่า [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) และ [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) ของพื้นผิวเป็น `Stretch` เพื่อให้ภาพหนึ่งสำเนาครอบคลุมพื้นผิวทั้งหมด.

บันทึก [arrow.png](arrow.png) ไว้ในไดเรกทอรีทำงาน. ตัวอย่างจะหมุนแผนภูมิและเพิ่มค่ามากสุดบนแกนแนวตั้งเพื่อให้พื้นมองเห็นระหว่างคอลัมน์. จากนั้นจะคัดลอกสไลด์สองครั้งและใส่ลูกศรลงบนพื้นผิวที่แตกต่างกันในแต่ละสไลด์. ทั้งสามแผนภูมิจะรักษาข้อมูล, มุมมอง, และพื้นหลังเดียวกัน.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
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

    IPPImage arrow = presentation.getImages().addImage(image);

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

Microsoft PowerPoint แสดงสไลด์สามสไลด์ดังต่อไปนี้.

| ผนังด้านข้าง | ผนังด้านหลัง | พื้น |
| --- | --- | --- |
| ![ลูกศรชี้เข้าสู่แผนภูมิตามผนังด้านข้าง](side-wall.png) | ![ลูกศรชี้ไปทางขวาข้ามผนังด้านหลัง](back-wall.png) | ![ลูกศรชี้ไปทางขวาข้ามพื้นระหว่างคอลัมน์](floor.png) |

## **ปรับสัดส่วนความสูงของแผนภูมิ 3 มิติ**

ใช้ [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) เพื่อตั้งค่าความสูงของแผนภูมิ 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง. สิ่งนี้จะเปลี่ยนสัดส่วนของฉาก 3 มิติโดยไม่ต้องปรับขนาดของออบเจ็กต์แผนภูมิบนสไลด์.

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) ด้วยข้อมูลเริ่มต้น: สามซีรีส์และสี่หมวดหมู่. มันบันทึกงานนำเสนอสามไฟล์พร้อมสัดส่วนความสูง 50%, 100% และ 200%. ตำแหน่ง, ความกว้าง, และความสูงของแผนภูมิคงที่. ข้อมูล, การหมุน, ความลึก, ช่องว่างระหว่างซีรีส์, และการจัดรูปแบบเหมือนกันในทั้งสามไฟล์; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยน.

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

ภาพต่อไปนี้แสดงการตั้งค่าความสูงเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกโดยใช้ Microsoft PowerPoint. เปอร์เซ็นต์ที่น้อยกว่าจะทำให้ฉากแบนลง, ขณะที่เปอร์เซ็นต์ที่มากจะทำให้ฉากสูงขึ้นภายในออบเจ็กต์แผนภูมิเดียวกัน. PowerPoint อาจปรับช่วงการแบ่งติ๊กแกนและการวางป้ายชื่อให้เหมาะกับฉากด้วย.

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ความสูงตั้งเป็น 50% ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ความสูงตั้งเป็น 100% ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ความสูงตั้งเป็น 200% ของความกว้าง](height_percent_200.png) |

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | ความสูงของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | ความสูงของออบเจ็กต์แผนภูมิบนสไลด์, หน่วยเป็นพอยท์ |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | ความลึกของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | ช่องว่างระหว่างซีรีส์ตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของมาร์กเกอร์ |

การตั้งค่าความสูงมีผลต่อแผนภูมิคอลัมน์และแท่ง 3 มิติ รวมถึงรูปแบบทรงกระบอก, รูปโคน, และปิรามิด, รวมถึงแผนภูมิเส้น, พื้นที่, พาย, และพื้นผิว 3 มิติ. การเปรียบเทียบข้างต้นใช้ประเภท `Column3D` ที่ตรวจสอบแล้ว. การตั้งค่านี้ไม่ทำให้ลักษณะของแผนภูมิ 2 มิติ `ClusteredColumn` หรือ `BubbleWith3D` เปลี่ยน; ชื่อเหล่านี้เป็นสมาชิกของคลาส [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). สำหรับการตั้งค่าลักษณะแผนภูมิอื่น ๆ ให้ดูที่ [Chart Formatting](/slides/th/androidjava/chart-formatting/).

## **ปรับช่องว่างระหว่างซีรีส์**

ใช้ [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) เพื่อควบคุมระยะห่างระหว่างซีรีส์ข้อมูลตามแกนความลึกของแผนภูมิ 3 มิติ, แสดงเป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์. ใช้ค่าจาก **0 ถึง 500**, รวม: `0` จะลบช่องว่าง, ขณะที่ค่าที่ใหญ่ขึ้นจะเพิ่มช่องว่าง. เมื่อความลึกของแผนภูมิคงที่, การเพิ่มช่องว่างทำให้มาร์กเกอร์บางลงตามแกนความลึก.

เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--). การตั้งค่านี้ใช้กับทุกซีรีส์ในกลุ่มนั้น, ไม่ใช่แค่ซีรีส์ที่ใช้เข้าถึง. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) จะคืนค่าช่องว่างความลึกและสะท้อนการตั้งค่ากลุ่มพาเรนท์.

การตั้งค่านี้มีผลต่อแผนภูมิคอลัมน์และแท่ง 3 มิติ รวมถึงรูปแบบทรงกระบอก, โคน, และปิรามิด, รวมถึงแผนภูมิเส้นและพื้นที่ 3 มิติ. รูปแบบขึ้นอยู่กับว่าซีรีส์จัดเรียงเป็นความลึก, กลุ่ม, หรือซ้อนกัน. เพื่อเปรียบเทียบช่องว่างระหว่างซีรีส์แยกกันอย่างชัดเจน, ใช้ `ChartType.Column3D` จากคลาส [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

| เมธอด | ผล |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | ช่องว่างระหว่างซีรีส์ตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของมาร์กเกอร์ |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | ช่องว่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างของแท่งหรือคอลัมน์ |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | ความลึกรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างของแผนภูมิ |

ตัวอย่างที่เป็นอิสระต่อไปนี้ใช้ข้อมูลแผนภูมิเริ่มต้น ซึ่งประกอบด้วยสามซีรีส์และสี่หมวดหมู่. มันบันทึกงานนำเสนอสองไฟล์ที่มีข้อมูล, การหมุน, ความกว้างช่องว่าง, และความลึกของแผนภูมิเท่ากัน; มีเพียงความลึกช่องว่างที่เปลี่ยน.

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

ภาพต่อไปนี้แสดงการตั้งค่าความลึกช่องว่างเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกโดยใช้ Microsoft PowerPoint.

| ความลึกช่องว่าง: 0% | ความลึกช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ไม่มีช่องว่างระหว่างซีรีส์ตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3 มิติที่มีช่องว่าง 500% ระหว่างซีรีส์ตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทซีรีส์ 3D และรูปร่างแท่ง**

ในแผนภูมิทรงกระบอกแบบกลุ่ม, ซีรีส์แรกเริ่มด้วยรูปร่างแท่งทรงกระบอก. ตัวอย่างพิมพ์ค่าจำนวนเต็มที่คืนจาก [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) และ [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) ก่อนและหลังการเปลี่ยนแต่ละครั้ง. ตารางแสดงชื่อคอนสแตนต์ที่สอดคล้องกัน.

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

| การเปลี่ยนแปลงในซีรีส์แรก | ประเภทซีรีส์ | รูปร่างแท่ง |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| ตั้งค่าประเภทซีรีส์เป็น `ClusteredCone` | `ClusteredCone` | `Cone` |
| ตั้งรูปร่างแท่งเป็น `Box` | `ClusteredColumn3D` | `Box` |

การตั้งรูปร่างเป็น `Box` ยังทำให้ประเภทซีรีส์เปลี่ยนเป็น `ClusteredColumn3D`. หากโค้ดของคุณทำสาขาตามประเภทซีรีส์, ให้เรียก `series.getType()` หลังจากเปลี่ยนรูปร่าง. ค่าที่เก็บไว้ก่อนการกำหนดค่าจะยังเลือกสาขา `ClusteredCone`.

![การเปรียบเทียบ PowerPoint แสดงซีรีส์แรกเป็นทรงกระบอก, โคน, และคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดที่รองรับโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลัมน์, รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D, พร้อมกับประเภท 3D ที่เกี่ยวข้องที่เปิดเผยผ่านคลาส [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). สำหรับรายการที่แม่นยำและอัปเดต, ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) ในเอกสาร API ของรุ่นที่คุณติดตั้ง.

**สามารถรับภาพราสเตอร์ของแผนภูมิ 3D สำหรับรายงานหรือเว็บได้หรือไม่?**

ใช่. คุณสามารถส่งออกแผนภูมิเป็นภาพด้วย [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) หรือ [render the entire slide](/slides/th/androidjava/convert-powerpoint-to-png/) ไปเป็นรูปแบบเช่น PNG หรือ JPEG. สิ่งนี้มีประโยชน์เมื่อคุณต้องการตัวอย่างรูปแบบราสเตอร์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องการ PowerPoint.

**ประสิทธิภาพของการสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ. เพื่อให้ได้ผลลัพธ์ที่ดีที่สุด, ควรใช้เอฟเฟกต์ 3D อย่างน้อยที่สุด, หลีกเลี่ยงพื้นผิวที่มีเท็กซ์เจอร์หนาบนผนังและพื้นที่วาด, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อเป็นไปได้, และเรนเดอร์เป็นผลลัพธ์ขนาดที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ.