---
title: ปรับแต่งแถบความคลาดเคลื่อนในแผนภูมิการนำเสนอด้วย JavaScript
linktitle: แถบความคลาดเคลื่อน
type: docs
url: /th/nodejs-java/error-bar/
keywords:
- แถบความคลาดเคลื่อน
- ค่าที่กำหนดเอง
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและปรับแต่งแถบความคลาดเคลื่อนในแผนภูมิด้วย JavaScript และ Aspose.Slides สำหรับ Node.js via Java—เพิ่มประสิทธิภาพการแสดงผลข้อมูลในงานนำเสนอ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแถบความคลาดเคลื่อนในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides มันแสดงวิธีการเพิ่มแถบความคลาดเคลื่อนให้กับชุดข้อมูลในแผนภูมิ, กำหนดการตั้งค่าแถบความคลาดเคลื่อน X และ Y, และใช้ประเภทค่าต่าง ๆ เช่น ค่าคงที่, ร้อยละ, และค่าที่กำหนดเอง

นอกจากนี้ยังสาธิตวิธีการกำหนดค่าแถบความคลาดเคลื่อนแบบกำหนดเองสำหรับจุดข้อมูลแต่ละจุดในชุดข้อมูลโดยใช้คอลเลกชันจุดข้อมูลที่สอดคล้องกัน อีกทั้งบทความยังรวมบันทึกสั้น ๆ เกี่ยวกับพฤติกรรมของแถบความคลาดเคลื่อนระหว่างการส่งออก, ความเข้ากันได้กับเครื่องหมายและป้ายข้อมูล, และที่ตั้งของคลาสและ enum ในเอกสารอ้างอิง API ที่เกี่ยวข้อง

## **เพิ่มแถบความคลาดเคลื่อน**

Aspose.Slides for Node.js via Java ให้ API ง่าย ๆ สำหรับจัดการค่าของแถบความคลาดเคลื่อน ตัวอย่างโค้ดนี้ใช้เมื่อใช้ประเภทค่าที่กำหนดเอง เพื่อระบุค่า ให้ใช้คุณสมบัติ **ErrorBarCustomValues** ของจุดข้อมูลเฉพาะในคอลเลกชัน [DataPoints](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartSeriesCollection) ของชุดข้อมูล:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. เพิ่มแผนภูมิบับเบิลบนสไลด์ที่ต้องการ
1. เข้าถึงชุดข้อมูลแผนภูม แรกและตั้งค่ารูปแบบของแถบความคลาดเคลื่อน X
1. เข้าถึงชุดข้อมูลแผนภูม แรกและตั้งค่ารูปแบบของแถบความคลาดเคลื่อน Y
1. ตั้งค่าค่าและรูปแบบของแถบ
1. เขียนการนำเสนอที่แก้ไขแล้วลงในไฟล์ PPTX

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // สร้างแผนภูมิบับเบิล
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // เพิ่มแถบความคลาดเคลื่อนและตั้งค่ารูปแบบ
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // บันทึกการนำเสนอ
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เพิ่มค่ารายการแถบความคลาดเคลื่อนแบบกำหนดเอง**

Aspose.Slides for Node.js via Java ให้ API ง่าย ๆ สำหรับจัดการค่าของแถบความคลาดเคลื่อนแบบกำหนดเอง ตัวอย่างโค้ดนี้ใช้เมื่อคุณสมบัติ [ErrorBarsFormat.ValueType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) มีค่าเท่ากับ **Custom** เพื่อระบุค่า ให้ใช้คุณสมบัติ **ErrorBarCustomValues** ของจุดข้อมูลเฉพาะในคอลเลกชัน [DataPoints](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartSeriesCollection) ของชุดข้อมูล:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. เพิ่มแผนภูมิบับเบิลบนสไลด์ที่ต้องการ
1. เข้าถึงชุดข้อมูลแผนภูม แรกและตั้งค่ารูปแบบของแถบความคลาดเคลื่อน X
1. เข้าถึงชุดข้อมูลแผนภูม แรกและตั้งค่ารูปแบบของแถบความคลาดเคลื่อน Y
1. เข้าถึงจุดข้อมูลแต่ละจุดของชุดข้อมูลแผนภูมิและตั้งค่า Error Bar สำหรับจุดข้อมูลแต่ละจุด
1. ตั้งค่าค่าและรูปแบบของแถบ
1. เขียนการนำเสนอที่แก้ไขแล้วลงในไฟล์ PPTX

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // สร้างแผนภูมิบับเบิล
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // เพิ่มแถบความคลาดเคลื่อนแบบกำหนดเองและตั้งค่ารูปแบบ
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // เข้าถึงจุดข้อมูลของชุดแผนภูมิและตั้งค่าแถบความคลาดเคลื่อนสำหรับ
    // จุดข้อมูลเดี่ยว
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // ตั้งค่าแถบความคลาดเคลื่อนสำหรับจุดข้อมูลชุดแผนภูมิ
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // บันทึกการนำเสนอ
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**เกิดอะไรขึ้นกับแถบความคลาดเคลื่อนเมื่อส่งออกการนำเสนอเป็น PDF หรือรูปภาพ?**

แถบความคลาดเคลื่อนจะถูกแสดงเป็นส่วนหนึ่งของแผนภูมิและจะยังคงอยู่ระหว่างการแปลงพร้อมกับการจัดรูปแบบของแผนภูมิทั้งหมด หากใช้เวอร์ชันหรือเรนเดอร์ที่เข้ากันได้

**แถบความคลาดเคลื่อนสามารถรวมกับเครื่องหมายและป้ายข้อมูลได้หรือไม่?**

ได้. แถบความคลาดเคลื่อนเป็นองค์ประกอบแยกจากกันและเข้ากันได้กับเครื่องหมายและป้ายข้อมูล; หากองค์ประกอบทับกันอาจต้องปรับการจัดรูปแบบ

**ฉันจะค้นหารายการของคุณสมบัติและ enum สำหรับการทำงานกับแถบความคลาดเคลื่อนใน API ได้ที่ไหน?**

ในเอกสารอ้างอิง API: คลาส [ErrorBarsFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/errorbarsformat/) และ enum ที่เกี่ยวข้อง [ErrorBarType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/errorbartype/) และ [ErrorBarValueType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/errorbarvaluetype/)