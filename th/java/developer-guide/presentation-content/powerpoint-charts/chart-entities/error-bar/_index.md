---
title: ปรับแต่งแถบข้อผิดพลาดในแผนภูมิการนำเสนอโดยใช้ Java
linktitle: แถบข้อผิดพลาด
type: docs
url: /th/java/error-bar/
keywords:
- แถบข้อผิดพลาด
- ค่าที่กำหนดเอง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและปรับแต่งแถบข้อผิดพลาดในแผนภูมิด้วย Aspose.Slides for Java—ปรับปรุงภาพข้อมูลในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแถบข้อผิดพลาดในแผนภูมิการนำเสนอด้วย Aspose.Slides แสดงวิธีเพิ่มแถบข้อผิดพลาดให้กับซีรีส์ของแผนภูมิ การกำหนดค่าการแสดงผลแถบข้อผิดพลาดแบบ X และ Y รวมถึงการใช้ชนิดค่าต่าง ๆ เช่น ค่าคงที่ เปอร์เซ็นต์ และค่าที่กำหนดเอง

นอกจากนี้ยังสาธิตวิธีกำหนดค่าแถบข้อผิดพลาดแบบกำหนดเองสำหรับจุดข้อมูลแต่ละจุดในซีรีส์โดยใช้คอลเลกชันของจุดข้อมูลที่สอดคล้องกัน พร้อมด้วยหมายเหตุสั้น ๆ เกี่ยวกับพฤติกรรมของแถบข้อผิดพลาดระหว่างการส่งออก ความเข้ากันได้กับเครื่องหมายและป้ายข้อมูล และที่ตั้งของคลาสและ enum ที่เกี่ยวข้องในเอกสารอ้างอิง API

## **เพิ่มแถบข้อผิดพลาด**
Aspose.Slides for Java มี API ที่ง่ายสำหรับการจัดการค่าของแถบข้อผิดพลาด ตัวอย่างโค้ดใช้เมื่อใช้ชนิดค่าที่กำหนดเอง เพื่อระบุค่า ให้ใช้คุณสมบัติ **ErrorBarCustomValues** ของจุดข้อมูลเฉพาะในคอลเลกชัน [**DataPoints**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartSeriesCollection) ของซีรีส์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation).
1. เพิ่มแผนภูมิบับเบิลบนสไลด์ที่ต้องการ.
1. เข้าถึงซีรีส์แผนภูมิตัวแรกและตั้งรูปแบบแถบข้อผิดพลาด X.
1. เข้าถึงซีรีส์แผนภูมิตัวแรกและตั้งรูปแบบแถบข้อผิดพลาด Y.
1. ตั้งค่าค่าและรูปแบบของแถบ.
1. บันทึกการนำเสนอที่ปรับเปลี่ยนแล้วเป็นไฟล์ PPTX.

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // สร้างแผนภูมิบับเบิล
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // เพิ่มแถบข้อผิดพลาดและตั้งค่ารูปแบบของมัน
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // บันทึกการนำเสนอ
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มค่าของแถบข้อผิดพลาดแบบกำหนดเอง**
Aspose.Slides for Java มี API ที่ง่ายสำหรับการจัดการค่าของแถบข้อผิดพลาดแบบกำหนดเอง ตัวอย่างโค้ดใช้เมื่อคุณสมบัติ [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IErrorBarsFormat#getValue--) มีค่าเป็น **Custom** เพื่อระบุค่า ให้ใช้คุณสมบัติ **ErrorBarCustomValues** ของจุดข้อมูลเฉพาะในคอลเลกชัน [**DataPoints**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartSeriesCollection) ของซีรีส์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation).
1. เพิ่มแผนภูมิบับเบิลบนสไลด์ที่ต้องการ.
1. เข้าถึงซีรีส์แผนภูมิตัวแรกและตั้งรูปแบบแถบข้อผิดพลาด X.
1. เข้าถึงซีรีส์แผนภูมาตัวแรกและตั้งรูปแบบแถบข้อผิดพลาด Y.
1. เข้าถึงจุดข้อมูลแต่ละจุดของซีรีส์แผนภูมิและตั้งค่า Error Bar สำหรับจุดข้อมูลแต่ละจุด.
1. ตั้งค่าค่าและรูปแบบของแถบ.
1. บันทึกการนำเสนอที่ปรับเปลี่ยนแล้วเป็นไฟล์ PPTX.

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // สร้างแผนภูมิบับเบิล
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // เพิ่มแถบข้อผิดพลาดแบบกำหนดเองและตั้งค่ารูปแบบของมัน
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // เข้าถึงจุดข้อมูลของซีรีส์แผนภูมิและตั้งค่าแถบข้อผิดพลาดสำหรับ
    // จุดแต่ละจุด
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // ตั้งค่าแถบข้อผิดพลาดสำหรับจุดซีรีส์แผนภูมิ
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // บันทึกการนำเสนอ
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**What happens to error bars when exporting a presentation to PDF or images?**
แถบข้อผิดพลาดจะถูกเรนเดอร์เป็นส่วนหนึ่งของแผนภูมิและจะคงอยู่ระหว่างการแปลงพร้อมกับการจัดรูปแบบแผนภูมิทั้งหมด โดยสมมติมีรุ่นหรือเรนเดอร์ที่รองรับ

**Can error bars be combined with markers and data labels?**
ได้ แถบข้อผิดพลาดเป็นองค์ประกอบแยกจากกันและเข้ากันได้กับเครื่องหมายและป้ายข้อมูล หากองค์ประกอบทับซ้อนกันอาจต้องปรับการจัดรูปแบบ

**Where can I find the list of properties and classes for working with error bars in the API?**
ในเอกสารอ้างอิง API: คลาส [ErrorBarsFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/errorbarsformat/) และคลาสที่เกี่ยวข้อง [ErrorBarType](https://reference.aspose.com/slides/th/java/com.aspose.slides/errorbartype/) กับ [ErrorBarValueType](https://reference.aspose.com/slides/th/java/com.aspose.slides/errorbarvaluetype/).