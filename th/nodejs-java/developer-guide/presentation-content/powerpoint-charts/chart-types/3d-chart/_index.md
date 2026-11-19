---
title: ปรับแต่งแผนภูมิ 3D ในงานนำเสนอด้วย JavaScript
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
description: "สร้างแผนภูมิ 3D ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java ปรับการหมุน, สัดส่วนความสูง, ความลึกของแผนภูมิ, และช่องว่างระหว่างชุดข้อมูลด้วยตัวอย่าง JavaScript"
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java ให้คุณปรับแต่งมุมมองของแผนภูมิ 3D ผ่านเมธอด [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) วิธีการนี้แสดงให้เห็นวิธีการปรับการหมุน, สัดส่วนความสูง, ความลึก, แกนมุมฉาก, และช่องว่างระหว่างชุดข้อมูล, จากนั้นบันทึกงานพรีเซนเทชันเป็นรูปแบบ PPTX

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3D**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) และใช้ [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) เพื่ เพิ่มแผนภูมิคอลัมน์ 3D แบบซ้อนลงในสไลด์แรกของมัน มันแทนที่ชุดข้อมูลและประเภทโดยค่าเริ่มต้นด้วยสองชุดข้อมูลที่แต่ละชุดมีสามค่า Worksheet index `0` ระบุเวิร์กชีตข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อชุดข้อมูล, และคอลัมน์ `0` เก็บป้ายชื่อประเภท

เมธอด [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) และ [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) ตั้งค่าการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ขณะที่ [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) เปิดใช้งานแกนมุมฉากแทนการมุมมองแบบเพอร์สเปคทีฟ งานพรีเซนเทชันที่ได้จะมีแผนภูมิที่เต็มไปด้วยข้อมูลพร้อมการตั้งค่าการมองเห็น 3D เหล่านี้

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

## **ปรับสัดส่วนความสูงของแผนภูมิ 3D**

ใช้ [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) เพื่อกำหนดความสูงของแผนภูมิ 3D เป็นเปอร์เซ็นต์ของความกว้าง วิธีนี้เปลี่ยนสัดส่วนของฉาก 3D โดยไม่ต้องปรับขนาดวัตถุแผนภูมิบนสไลด์

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) ด้วยข้อมูลเริ่มต้น: สามชุดข้อมูลและสี่ประเภท มันบันทึกงานพรีเซนเทชันสามไฟล์โดยสัดส่วนความสูงที่ 50%, 100% และ 200% ความตำแหน่ง, ความกว้างและความสูงของแผนภูมิคงที่ ข้อมูล, การหมุน, ความลึก, ระยะห่างระหว่างชุดข้อมูลและการจัดรูปแบบเหมือนกันในทุกไฟล์; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยน

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

ภาพต่อไปนี้แสดงการตั้งค่าสัดส่วนความสูงเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกโดย Microsoft PowerPoint เปอร์เซ็นต์ที่น้อยกว่าจะทำให้ฉากแบนลง, ส่วนเปอร์เซ็นต์ที่มากขึ้นจะทำให้ฉากสูงขึ้นภายในวัตถุแผนภูมิเดียวกัน PowerPoint อาจปรับช่วงของการทำเครื่องหมายแกนและตำแหน่งป้ายชื่อให้เหมาะกับฉาก

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3D ที่ตั้งค่าความสูงเป็น 50% ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3D ที่ตั้งค่าความสูงเป็น 100% ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3D ที่ตั้งค่าความสูงเป็น 200% ของความกว้าง](height_percent_200.png) |

เมธอดเหล่านี้ควบคุมแง่มุมต่างๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | ความสูงของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | ความสูงของวัตถุแผนภูมิบนสไลด์, หน่วยเป็นพ้อยนต์ |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | ความลึกของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | ช่องว่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์ |

การตั้งค่านี้มีผลต่อแผนภูมิคอลัมน์และแผนภูมิแท่ง 3D รวมถึงรูปแบบทรงกระบอก, รูปทรงกรวย, และรูปทรงพีระมิด, รวมถึงแผนภูมิ 3D แบบเส้น, พื้นที่, พายและพื้นผิว การเปรียบเทียบข้างต้นใช้ประเภท `Column3D` ที่ตรวจสอบแล้ว การตั้งค่านี้ไม่เปลี่ยนลักษณะของแผนภูมิ `ClusteredColumn` 2D หรือแผนภูมิ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของคลาส [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) สำหรับการตั้งค่าลักษณะของแผนภูมิอื่น ๆ ดู [Chart Formatting](/slides/th/nodejs-java/chart-formatting/)

## **ปรับระยะห่างระหว่างชุดข้อมูล**

ใช้ [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) เพื่อควบคุมระยะห่างระหว่างชุดข้อมูลตามแกนความลึกของแผนภูมิ 3D, แสดงเป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์ ใช้ค่า **0 to 500** รวม: `0` ลบช่องว่างออก, ค่าที่มากขึ้นเพิ่มระยะห่าง กับความลึกของแผนภูมิที่คงที่ การเพิ่มช่องว่างทำให้มาร์กเกอร์บางลงตามแกนความลึก

เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) การตั้งค่านี้นำไปใช้กับทุกชุดข้อมูลในกลุ่มนั้น ไม่ใช่เฉพาะชุดที่ใช้เข้าถึงเท่านั้น [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) คืนค่าขั้นความลึกและสะท้อนการตั้งค่าของกลุ่มพาเรนท์

การตั้งค่านี้มีผลต่อแผนภูมิคอลัมน์และแผนภูมิแท่ง 3D รวมถึงรูปแบบทรงกระบอก, รูปทรงกรวย, และรูปทรงพีระมิด, รวมถึงแผนภูมิ 3D แบบเส้นและพื้นที่ ลักษณะการแสดงผลขึ้นอยู่กับว่าชุดข้อมูลถูกจัดเรียงเป็นความลึก, เป็นคลัสเตอร์ หรือเป็นการซ้อนกัน สำหรับการเปรียบเทียบชัดเจนของช่องว่างระหว่างชุดข้อมูลแยกกันให้ใช้ `ChartType.Column3D` จากคลาส [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)

เมธอดเหล่านี้ควบคุมแง่มุมต่างๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | ช่องว่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์ |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | ระยะห่างระหว่างคลัสเตอร์ของแถบหรือคอลัมน์ที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างของแถบหรือคอลัมน์ |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | ความลึกรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างของแผนภูมิ |

ตัวอย่างต่อไปนี้ใช้ข้อมูลแผนภูมิปริยายที่มีสามชุดข้อมูลและสี่ประเภท มันบันทึกงานพรีเซนเทชันสองไฟล์โดยข้อมูล, การหมุน, ความกว้างช่องว่างและความลึกของแผนภูมิเหมือนเดิม; มีเพียงความลึกช่องว่างที่เปลี่ยน

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

ภาพต่อไปนี้แสดงการตั้งค่าระยะห่างช่องว่างเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกโดย Microsoft PowerPoint

| ความลึกช่องว่าง: 0% | ความลึกช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3D ที่ไม่มีช่องว่างระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3D ที่มีช่องว่าง 500% ระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทชุดข้อมูล 3D และรูปทรงของแท่ง**

ในแผนภูมิเชลล์ที่จัดเป็นคลัสเตอร์, ชุดข้อมูลแรกเริ่มต้นด้วยรูปทรงแท่งทรงกระบอก ตัวอย่างพิมพ์ค่าจำนวนเต็มที่คืนมาจาก [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) และ [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) ก่อนและหลังการเปลี่ยนแต่ละครั้ง ตารางให้ชื่อคงที่ที่สอดคล้องกัน

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

| การเปลี่ยนในชุดข้อมูลแรก | ประเภทชุดข้อมูล | รูปทรงแท่ง |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| ตั้งค่าประเภทชุดข้อมูลเป็น `ClusteredCone` | `ClusteredCone` | `Cone` |
| ตั้งค่ารูปทรงแท่งเป็น `Box` | `ClusteredColumn3D` | `Box` |

การตั้งค่ารูปทรงเป็น `Box` ยังทำให้ประเภทชุดข้อมูลเปลี่ยนเป็น `ClusteredColumn3D` หากโค้ดของคุณใช้เงื่อนไขตามประเภทชุดข้อมูล ให้เรียก `series.getType()` หลังจากเปลี่ยนรูปทรง ค่าที่เก็บไว้ก่อนการกำหนดค่าอาจยังเลือกสาขา `ClusteredCone` ได้อยู่

![การเปรียบเทียบ PowerPoint ที่แสดงชุดข้อมูลแรกเป็นรูปทรงทรงกระบอก, รูปทรงกรวย, และคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดสนับสนุนโหมด 3D ใน Aspose.Slides?**

Aspose.Slides สนับสนุนรูปแบบ 3D ของแผนภูมิคอลัมน์ ได้แก่ Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D พร้อมกับประเภท 3D ที่เกี่ยวข้องที่เปิดเผยผ่านคลาส [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) สำหรับรายการที่แม่นยำและอัปเดตล่าสุด ให้ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) ในเอกสารอ้างอิง API ของเวอร์ชันที่ติดตั้ง

**ฉันสามารถรับรูปภาพเรสเตอร์ของแผนภูมิ 3D สำหรับรายงานหรือเว็บได้หรือไม่?**

ได้ คุณสามารถส่งออกแผนภูมิเป็นรูปภาพด้วย [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) หรือ [render the entire slide](/slides/th/nodejs-java/convert-powerpoint-to-png/) ไปเป็นฟอร์แมตเช่น PNG หรือ JPEG ซึ่งมีประโยชน์เมื่อคุณต้องการภาพตัวอย่างเรสเตอร์หรือฝังแผนภูมิในเอกสาร, แดชบอร์ด หรือหน้าเว็บโดยไม่ต้องพึ่งพา PowerPoint

**ประสิทธิภาพการสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ เพื่อให้ได้ผลดีที่สุด ควรลดเอฟเฟกต์ 3D ให้เหลือน้อยที่สุด, หลีกเลี่ยงพื้นผิวหรือพื้นเขตที่มีเท็กซ์เจอร์หนัก, จำกัดจำนวนจุดข้อมูลต่อชุดเมื่อเป็นไปได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ