---
title: เพิ่มประสิทธิภาพการคำนวณแผนภูมิสำหรับการนำเสนอใน JavaScript
linktitle: การคำนวณแผนภูมิ
type: docs
weight: 50
url: /th/nodejs-java/chart-calculations/
keywords:
- การคำนวณแผนภูมิ
- องค์ประกอบแผนภูมิ
- ตำแหน่งขององค์ประกอบ
- ตำแหน่งจริง
- องค์ประกอบย่อย
- องค์ประกอบแม่
- ค่าของแผนภูมิ
- ค่าจริง
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ทำความเข้าใจการคำนวณแผนภูมิ การอัปเดตข้อมูล และการควบคุมความแม่นยำใน Aspose.Slides สำหรับ Node.js สำหรับไฟล์ PPT และ PPTX พร้อมตัวอย่างโค้ด JavaScript ที่ใช้งานได้จริง"
---
## **ภาพรวม**

Aspose.Slides มี API สำหรับทำงานกับการคำนวณแผนภูมิและข้อมูลการจัดวางในงานนำเสนอ. บทความนี้แสดงวิธีการดึงค่าจริงขององค์ประกอบแผนภูมิ รวมถึงตำแหน่งและขนาดจริงขององค์ประกอบและค่าจริงของแกนแผนภูมิ. นอกจากนี้ยังอธิบายว่าค่าเหล่านี้จะถูกเติมเต็มหลังจากทำการตรวจสอบการจัดวางแผนภูมิ.

## **คำนวณค่าจริงขององค์ประกอบแผนภูมิ**

Aspose.Slides สำหรับ Node.js ผ่าน Java มี API ที่ง่ายสำหรับดึงคุณสมบัติเหล่านี้. คุณสมบัติของคลาส [Axis](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Axis) ให้ข้อมูลเกี่ยวกับตำแหน่งจริงขององค์ประกอบแกนแผนภูมิ ([Axis.getActualMaxValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). ควรเรียกเมธอด [Chart.validateChartLayout()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Chart#validateChartLayout--) ก่อนหน้าเพื่อเติมคุณสมบัติกับค่าจริง.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำนวณตำแหน่งจริงขององค์ประกอบแผนภูมิต้นแบบ**

Aspose.Slides สำหรับ Node.js ผ่าน Java มี API ที่ง่ายสำหรับดึงคุณสมบัติเหล่านี้. คุณสมบัติของคลาส `ActualLayout` ให้ข้อมูลเกี่ยวกับตำแหน่งจริงขององค์ประกอบแผนภูมิต้นแบบ `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. ควรเรียกเมธอด [Chart.validateChartLayout()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Chart#validateChartLayout--) ก่อนหน้าเพื่อเติมคุณสมบัติกับค่าจริง.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ซ่อนข้อมูลจากแผนภูมิ**

หัวข้อนี้ช่วยให้คุณเข้าใจวิธีการซ่อนข้อมูลจากแผนภูมิ. โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java คุณสามารถซ่อน **Title, Vertical Axis, Horizontal Axis** และ **Grid Lines** จากแผนภูมิได้. ตัวอย่างโค้ดด้านล่างแสดงวิธีการใช้คุณสมบัติเหล่านี้.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // ซ่อนหัวเรื่องแผนภูมิ
    chart.setTitle(false);
    // /ซ่อนแกนค่า
    chart.getAxes().getVerticalAxis().setVisible(false);
    // การมองเห็นแกนประเภท
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // ซ่อนคำอธิบาย
    chart.setLegend(false);
    // ซ่อนเส้นกริดหลัก
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // กำหนดสีเส้นของชุดข้อมูล
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ไฟล์ Excel ภายนอกสามารถทำหน้าที่เป็นแหล่งข้อมูลได้หรือไม่และส่งผลต่อการคำนวณใหม่อย่างไร?**

ใช่. แผนภูมิสามารถอ้างอิงไฟล์งานภายนอก: เมื่อคุณเชื่อมต่อหรือรีเฟรชแหล่งข้อมูลภายนอก สูตรและค่าจะถูกดึงจากไฟล์นั้น และแผนภูมิจะแสดงการอัปเดตเหล่านี้ระหว่างการเปิดหรือแก้ไข. API ให้คุณ [specify the external workbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) path และจัดการข้อมูลที่เชื่อมโยง.

**ฉันสามารถคำนวณและแสดงเส้นแนวโน้มโดยไม่ต้องทำการถดถอยเองได้หรือไม่?**

ใช่. [Trendlines](/slides/th/nodejs-java/trend-line/) (เชิงเส้น, สูตรเอ็กซ์โพเนนเชียล และอื่น ๆ) จะถูกเพิ่มและอัปเดตโดย Aspose.Slides; พารามิเตอร์ของเส้นแนวโน้มจะถูกคำนวณใหม่จากข้อมูลซีรีส์โดยอัตโนมัติ ดังนั้นคุณไม่จำเป็นต้องเขียนการคำนวณของคุณเอง.

**หากงานนำเสนอมีแผนภูมิหลายรายการที่เชื่อมโยงกับไฟล์ภายนอก ฉันสามารถควบคุมว่าแผนภูมิแต่ละอันใช้ไฟล์งานใดสำหรับค่าที่คำนวณได้หรือไม่?**

ใช่. แต่ละแผนภูมิสามารถชี้ไปยังไฟล์งานภายนอกของตนเองได้ผ่าน [external workbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), หรือคุณสามารถสร้าง/แทนที่ไฟล์งานภายนอกสำหรับแต่ละแผนภูมิได้อย่างอิสระจากแผนภูมิอื่น ๆ.