---
title: ปรับแต่งแผนภูมิ 3D ในงานนำเสนอโดยใช้ JavaScript
linktitle: แผนภูมิ 3D
type: docs
url: /th/nodejs-java/3d-chart/
keywords:
- แผนภูมิ 3D
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างแผนภูมิ 3D ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java ปรับการหมุน, อัตราส่วนความสูง, ความลึกของแผนภูมิ, และระยะห่างระหว่างชุดข้อมูลด้วยตัวอย่าง JavaScript."
---
## **ภาพรวม**

Aspose.Slides สำหรับ Node.js ผ่าน Java ให้คุณปรับแต่งมุมมองของแผนภูมิ 3D ผ่านเมธอด [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) นี้ บทความนี้แสดงวิธีการปรับการหมุน, อัตราส่วนความสูง, ความลึก, แกนมุมฉาก, และระยะห่างระหว่างชุดข้อมูล, แล้วบันทึกงานนำเสนอเป็นรูปแบบ PPTX.

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3D**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) และใช้ [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) เพื่อเพิ่มแผนภูมิคอลัมน์ 3D แบบซ้อนบนสไลด์แรกของมัน มันจะแทนที่ชุดข้อมูลและประเภทเริ่มต้นด้วยสองชุดข้อมูลที่แต่ละชุดมีค่าสามค่า ดัชนี Worksheet `0` ระบุ Worksheet ข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อชุดข้อมูล, และคอลัมน์ `0` เก็บป้ายชื่อประเภท.

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) และ [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) ตั้งค่าการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ในขณะที่ [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) เปิดใช้งานแกนมุมฉากแทนมุมมองเชิงลึก. งานนำเสนอที่ได้จะมีแผนภูมิที่เติมข้อมูลพร้อมการตั้งค่ามุมมอง 3D เหล่านี้.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ใช้การเติมรูปภาพบนพื้นผิวแผนภูมิ 3D**

คุณสามารถเติม [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/), และ [floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) ของแผนภูมิ 3D แยกกันได้ ตั้งค่าประเภทการเติมของพื้นผิวโดยใช้ [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) เป็น `Picture` และกำหนดรูปภาพ ตั้งค่า [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) และ [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) ของพื้นผิวเป็น `Stretch` เพื่อให้รูปภาพหนึ่งสำเนาครอบทั่วพื้นผิว.

บันทึกไฟล์ [arrow.png](arrow.png) ลงในไดเรกทอรีทำงาน ตัวอย่างจะหมุนแผนภูมิและเพิ่มค่าสูงสุดบนแกนแนวตั้งเพื่อให้พื้นมองเห็นระหว่างคอลัมน์ จากนั้นทำสำเนา (clone) สไลด์สองครั้งและนำลูกศรไปใช้บนพื้นผิวที่แตกต่างกันในแต่ละสไลด์ ทั้งสามแผนภูมิจะรักษาข้อมูล, มุมมอง, และพื้นหลังเหมือนเดิม.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint แสดงสไลด์ทั้งสามดังต่อไปนี้.

| ผนังด้านข้าง | ผนังด้านหลัง | พื้น |
| --- | --- | --- |
| ![ลูกศรชี้เข้าสู่แผนภูมิตามผนังด้านข้าง](side-wall.png) | ![ลูกศรชี้ไปทางขวาบนผนังด้านหลัง](back-wall.png) | ![ลูกศรชี้ไปทางขวาบนพื้นระหว่างคอลัมน์](floor.png) |

## **ปรับอัตราส่วนความสูงของแผนภูมิ 3D**

ใช้ [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) เพื่อกำหนดความสูงของแผนภูมิ 3D เป็นเปอร์เซ็นต์ของความกว้างของมัน การทำเช่นนี้จะเปลี่ยนอัตราส่วนของฉาก 3D โดยไม่ต้องปรับขนาดวัตถุแผนภูมิบนสไลด์.

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) ด้วยข้อมูลเริ่มต้น: สามชุดข้อมูลและสี่ประเภท มันจะบันทึกงานนำเสนอสามไฟล์โดยมีอัตราส่วนความสูง 50%, 100% และ 200% ตำแหน่ง, ความกว้าง, และความสูงของแผนภูมิก็ยังคงคงที่ ข้อมูล, การหมุน, ความลึก, ระยะห่างระหว่างชุดข้อมูล, และการจัดรูปแบบจะเหมือนกันในทั้งสามไฟล์; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยนแปลง.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

ภาพต่อไปนี้แสดงการตั้งค่าความสูงเดียวกันในตัวอย่าง .NET ที่เทียบเท่า และถูกส่งออกโดยใช้ Microsoft PowerPoint เปอร์เซ็นต์ที่น้อยกว่าจะทำให้ฉากแบนลง, ส่วนเปอร์เซ็นต์ที่มากกว่าจะทำให้ฉากสูงขึ้นภายในวัตถุแผนภูมิเดียวกัน PowerPoint อาจปรับช่วงของเครื่องหมายแกนและตำแหน่งป้ายชื่อเพื่อให้พอดีกับฉาก.

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3D ที่ตั้งค่าความสูงเป็น 50% ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3D ที่ตั้งค่าความสูงเป็น 100% ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3D ที่ตั้งค่าความสูงเป็น 200% ของความกว้าง](height_percent_200.png) |

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | ความสูงของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | ความสูงของวัตถุแผนภูมิบนสไลด์, หน่วยเป็นพอยต์ |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | ความลึกของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | ระยะห่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของเครื่องหมาย |

การตั้งค่าความสูงมีผลต่อแผนภูมิคอลัมน์และแผนภูมิแท่ง 3D รวมถึงรูปแบบทรงกระบอก, รูปกรวย, และรูปพีรามิด, รวมถึงแผนภูมิเส้น 3D, พื้นที่ 3D, พาย 3D, และพื้นผิว 3D การเปรียบเทียบข้างต้นใช้ประเภท `Column3D` ที่ตรวจสอบแล้ว การตั้งค่านี้จะไม่เปลี่ยนลักษณะของแผนภูมิ 2D `ClusteredColumn` หรือ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของคลาส [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) สำหรับการตั้งค่าอื่น ๆ ของลักษณะแผนภูมิ, ดู [Chart Formatting](/slides/th/nodejs-java/chart-formatting/).

## **ปรับระยะห่างระหว่างชุดข้อมูล**

ใช้ [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) เพื่อควบคุมระยะห่างระหว่างชุดข้อมูลตามแกนความลึกของแผนภูมิ 3D โดยแสดงเป็นเปอร์เซ็นต์ของความกว้างของเครื่องหมาย ใช้ค่าตั้งแต่ **0 ถึง 500**, รวม: `0` จะลบระยะห่าง, ค่าที่มากกว่า จะเพิ่มการเว้นช่องว่าง เมื่อความลึกของแผนภูมิคงที่ การเพิ่มระยะห่างจะทำให้เครื่องหมายบางลงตามแกนความลึก.

เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). การตั้งค่านี้ใช้กับทุกชุดข้อมูลในกลุ่มนั้น, ไม่ใช่เพียงชุดที่ใช้เข้าถึงเท่านั้น [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) จะส่งคืนระยะห่างเชิงความลึกและสะท้อนการตั้งค่าของกลุ่มแม่.

การตั้งค่านี้มีผลต่อแผนภูมิคอลัมน์และแท่ง 3D รวมถึงรูปแบบทรงกระบอก, รูปกรวย, และรูปพีรามิดของพวกมัน, รวมถึงแผนภูมิเส้น 3D และแผนภูมิพื้นที่ การแสดงผลขึ้นอยู่กับว่าชุดข้อมูลถูกจัดเรียงเป็นเชิงความลึก, กลุ่ม, หรือซ้อนกันอย่างไร เพื่อเปรียบเทียบระยะห่างระหว่างชุดข้อมูลที่แยกจากกันอย่างชัดเจน, ใช้ `ChartType.Column3D` จากคลาส [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | ระยะห่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของเครื่องหมาย |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | ระยะห่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่อยู่ใกล้เคียง, เป็นเปอร์เซ็นต์ของความกว้างของแท่งหรือคอลัมน์ |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | ความลึกรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างของแผนภูมิ |

ตัวอย่างที่เป็นอิสระต่อไปนี้ใช้ข้อมูลแผนภูมิมาตรฐานซึ่งมีสามชุดข้อมูลและสี่ประเภท มันบันทึกงานนำเสนอสองไฟล์โดยข้อมูล, การหมุน, ความกว้างของช่องว่าง, และความลึกของแผนภูมิเหมือนกัน; มีเพียงความลึกของช่องว่างที่เปลี่ยนแปลง.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

ภาพต่อไปนี้แสดงการตั้งค่าความลึกของช่องว่างเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกโดยใช้ Microsoft PowerPoint.

| ความลึกของช่องว่าง: 0% | ความลึกของช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3D ที่ไม่มีช่องว่างระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3D ที่มีช่องว่าง 500% ระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทชุดข้อมูล 3D และรูปทรงแท่ง**

ในแผนภูมิทรงกระบอกแบบกลุ่ม, ชุดแรกเริ่มต้นด้วยรูปทรงแท่งทรงกระบอก ตัวอย่างพิมพ์ค่าจำนวนเต็มที่ได้จาก [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) และ [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) ก่อนและหลังการเปลี่ยนแต่ละครั้ง ตารางแสดงชื่อค่าคงที่ที่สอดคล้อง.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| การเปลี่ยนในชุดแรก | ประเภทชุดข้อมูล | รูปทรงแท่ง |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| ตั้งค่าประเภทชุดข้อมูลเป็น `ClusteredCone` | `ClusteredCone` | `Cone` |
| ตั้งค่ารูปทรงแท่งเป็น `Box` | `ClusteredColumn3D` | `Box` |

การตั้งค่ารูปทรงเป็น `Box` จะเปลี่ยนประเภทชุดข้อมูลเป็น `ClusteredColumn3D` ด้วย หากโค้ดของคุณมีการแยกสาขาตามประเภทชุดข้อมูล, ควรเรียก `series.getType()` หลังจากเปลี่ยนรูปทรง ค่า ที่เก็บไว้ก่อนการกำหนดจะยังคงเลือกสาขา `ClusteredCone`.

![การเปรียบเทียบ PowerPoint แสดงชุดแรกเป็นทรงกระบอก, รูปกรวย, และคอลลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดสนับสนุนโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลัมน์, เช่น Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D, รวมถึงประเภท 3D ที่เกี่ยวข้องที่เปิดให้ผ่านคลาส [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) สำหรับรายการที่แม่นยำและอัปเดต, ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) ในเอกสารอ้างอิง API ของเวอร์ชันที่คุณติดตั้ง.

**ฉันสามารถรับภาพเรสเตอร์ของแผนภูมิ 3D สำหรับรายงานหรือเว็บได้หรือไม่?**

ได้. คุณสามารถส่งออกแผนภูมิเป็นภาพด้วย [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) หรือ [เรนเดอร์สไลด์ทั้งหมด](/slides/th/nodejs-java/convert-powerpoint-to-png/) ไปเป็นรูปแบบเช่น PNG หรือ JPEG สิ่งนี้มีประโยชน์เมื่อคุณต้องการตัวอย่างเรสเตอร์หรือฝังแผนภูมิในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint.

**ประสิทธิภาพของการสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ สำหรับผลลัพธ์ที่ดีที่สุด, ควรลดเอฟเฟกต์ 3D ให้เหลือน้อยที่สุด, หลีกเลี่ยงพื้นผิวเท็กซ์เจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อชุดข้อมูลเมื่อทำได้, และเรนเดอร์เป็นผลลัพธ์ที่มีขนาดเหมาะสม (ความละเอียดและมิติ) เพื่อตรงกับหน้าจอหรือความต้องการการพิมพ์.