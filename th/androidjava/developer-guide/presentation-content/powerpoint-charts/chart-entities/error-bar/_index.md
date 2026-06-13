---
title: ปรับแต่งแท่งข้อผิดพลาดในแผนภูมิการนำเสนอบน Android
linktitle: แท่งข้อผิดพลาด
type: docs
url: /th/androidjava/error-bar/
keywords:
- แท่งข้อผิดพลาด
- ค่าที่กำหนดเอง
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและปรับแต่งแท่งข้อผิดพลาดในแผนภูมิด้วย Aspose.Slides สำหรับ Android ผ่าน Java—เพิ่มประสิทธิภาพการแสดงผลข้อมูลในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแท่งข้อผิดพลาดในแผนภูมินำเสนอโดยใช้ Aspose.Slides โดยแสดงวิธีเพิ่มแท่งข้อผิดพลาดให้กับชุดข้อมูลแผนภูมิ, กำหนดการตั้งค่าแท่งข้อผิดพลาด X และ Y, และใช้ประเภทค่าต่าง ๆ เช่น ค่าตายตัว, เปอร์เซ็นต์, และค่าที่กำหนดเอง  

นอกจากนี้ยังสาธิตวิธีกำหนดค่าตัวแท่งข้อผิดพลาดที่กำหนดเองสำหรับแต่ละจุดข้อมูลในชุดข้อมูลโดยใช้คอลเลกชันจุดข้อมูลที่สอดคล้องกัน อีกทั้งบทความยังมีหมายเหตุสั้น ๆ เกี่ยวกับพฤติกรรมของแท่งข้อผิดพลาดระหว่างการส่งออก, ความเข้ากันได้กับตัวทำเครื่องหมายและป้ายกำกับข้อมูล, และตำแหน่งที่สามารถค้นหาคลาสอ้างอิง API และ enum ที่เกี่ยวข้องได้

## **เพิ่มแท่งข้อผิดพลาด**
Aspose.Slides for Android via Java มี API อย่างง่ายสำหรับการจัดการค่าของแท่งข้อผิดพลาด ตัวอย่างโค้ดนี้ใช้เมื่อใช้ประเภทค่าที่กำหนดเอง เพื่อระบุค่า ให้ใช้คุณสมบัติ **ErrorBarCustomValues** ของจุดข้อมูลเฉพาะในคอลเลกชัน [**DataPoints**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartSeriesCollection) ของชุดข้อมูล:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. เพิ่มชาร์ตแบบบับเบิลบนสไลด์ที่ต้องการ  
3. เข้าถึงชุดข้อมูลชาร์ตแรกและตั้งค่ารูปแบบแท่งข้อผิดพลาด X  
4. เข้าถึงชุดข้อมูลชาร์ตแรกและตั้งค่ารูปแบบแท่งข้อผิดพลาด Y  
5. ตั้งค่าค่าและรูปแบบของแท่ง  
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // สร้างชาร์ตแบบบับเบิล
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // เพิ่มแท่งข้อผิดพลาดและตั้งค่ารูปแบบของมัน
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

## **เพิ่มค่าตัวแท่งข้อผิดพลาดที่กำหนดเอง**
Aspose.Slides for Android via Java มี API อย่างง่ายสำหรับการจัดการค่าตัวแท่งข้อผิดพลาดที่กำหนดเอง ตัวอย่างโค้ดนี้ใช้เมื่อคุณสมบัติ [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) มีค่าเป็น **Custom** เพื่อระบุค่า ให้ใช้คุณสมบัติ **ErrorBarCustomValues** ของจุดข้อมูลเฉพาะในคอลเลกชัน [**DataPoints**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartSeriesCollection) ของชุดข้อมูล:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. เพิ่มชาร์ตแบบบับเบิลบนสไลด์ที่ต้องการ  
3. เข้าถึงชุดข้อมูลชาร์ตแรกและตั้งค่ารูปแบบแท่งข้อผิดพลาด X  
4. เข้าถึงชุดข้อมูลชาร์ตแรกและตั้งค่ารูปแบบแท่งข้อผิดพลาด Y  
5. เข้าถึงจุดข้อมูลบุคคลิกของชุดข้อมูลแผนภูมิและกำหนดค่าตัวแท่งข้อผิดพลาดสำหรับจุดข้อมูลแต่ละจุด  
6. ตั้งค่าค่าและรูปแบบของแท่ง  
7. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // สร้างชาร์ตแบบบับเบิล
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // เพิ่มแท่งข้อผิดพลาดที่กำหนดเองและตั้งค่ารูปแบบของมัน
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // เข้าถึงจุดข้อมูลของชุดชาร์ตและตั้งค่าค่าแท่งข้อผิดพลาดสำหรับ
    // จุดแต่ละจุด
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // ตั้งค่าแท่งข้อผิดพลาดสำหรับจุดของชุดชาร์ต
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

**เกิดอะไรขึ้นกับแท่งข้อผิดพลาดเมื่อส่งออกการนำเสนอเป็น PDF หรือรูปภาพ?**  

พวกมันจะถูกเรนเดอร์เป็นส่วนหนึ่งของแผนภูมิและคงอยู่ระหว่างการแปลงพร้อมกับการจัดรูปแบบแผนภูมิที่เหลือ assuming a compatible version or renderer.

**สามารถรวมแท่งข้อผิดพลาดกับตัวทำเครื่องหมายและป้ายกำกับข้อมูลได้หรือไม่?**  

ได้ แท่งข้อผิดพลาดเป็นอิลิเมนท์แยกต่างหากและเข้ากันได้กับตัวทำเครื่องหมายและป้ายกำกับข้อมูล; หากอิลิเมนท์ทับกันอาจต้องปรับการจัดรูปแบบ

**จะหา 목록ของคุณสมบัติและคลาสสำหรับทำงานกับแท่งข้อผิดพลาดใน API ได้ที่ใด?**  

ในเอกสารอ้างอิง API: คลาส [ErrorBarsFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/errorbarsformat/) และคลาสที่เกี่ยวข้อง [ErrorBarType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/errorbartype/) และ [ErrorBarValueType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/errorbarvaluetype/).