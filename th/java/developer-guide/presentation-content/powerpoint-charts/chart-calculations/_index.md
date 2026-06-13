---
title: เพิ่มประสิทธิภาพการคำนวณแผนภูมิสำหรับการนำเสนอใน Java
linktitle: การคำนวณแผนภูมิ
type: docs
weight: 50
url: /th/java/chart-calculations/
keywords:
- การคำนวณแผนภูมิ
- องค์ประกอบแผนภูมิ
- ตำแหน่งขององค์ประกอบ
- ตำแหน่งจริง
- องค์ประกอบลูก
- องค์ประกอบแม่
- ค่าของแผนภูมิ
- ค่าจริง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ทำความเข้าใจการคำนวณแผนภูมิ การอัปเดตข้อมูล และการควบคุมความแม่นยำใน Aspose.Slides สำหรับ Java สำหรับ PPT และ PPTX พร้อมตัวอย่างโค้ด Java ที่ใช้งานได้จริง."
---
## **ภาพรวม**

Aspose.Slides มี API สำหรับทำงานกับการคำนวณแผนภูมิและข้อมูลการจัดวางในงานนำเสนอ บทความนี้แสดงวิธีดึงค่าจริงขององค์ประกอบแผนภูมิ รวมถึงตำแหน่งและขนาดจริงขององค์ประกอบที่ทำตาม `IActualLayout` และค่าจริงของแกนแผนภูมิ นอกจากนี้ยังอธิบายว่าค่าเหล่านี้จะถูกเติมหลังจากการตรวจสอบการจัดวางแผนภูมิ

นอกจากนี้บทความยังสาธิตวิธีรับตำแหน่งจริงขององค์ประกอบแผนภูมิแม่และวิธีซ่อนส่วนประกอบของแผนภูมิ เช่น ชื่อเรื่อง, แกน, คำอธิบาย, และเส้นกริด ตัวอย่างเหล่านี้ช่วยให้คุณตรวจสอบข้อมูลการจัดวางแผนภูมิและควบคุมการแสดงผลขององค์ประกอบแผนภูมิใน PowerPoint โปรแกรมแบบอัตโนมัติ

## **คำนวณค่าจริงขององค์ประกอบแผนภูมิ**
Aspose.Slides for Java มี API ง่าย ๆ สำหรับดึงคุณสมบัติเหล่านี้ คุณสมบัติของอินเทอร์เฟซ [IAxis](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAxis) ให้ข้อมูลเกี่ยวกับตำแหน่งจริงขององค์ประกอบแกนแผนภูมิ ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)) จำเป็นต้องเรียกเมธอด [IChart.validateChartLayout()](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChart#validateChartLayout--) ก่อนเพื่อเติมคุณสมบัติด้วยค่าจริง

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำนวณตำแหน่งจริงขององค์ประกอบแผนภูมิแม่**
Aspose.Slides for Java มี API ง่าย ๆ สำหรับดึงคุณสมบัติเหล่านี้ คุณสมบัติของอินเทอร์เฟซ [IActualLayout](https://reference.aspose.com/slides/th/java/com.aspose.slides/IActualLayout) ให้ข้อมูลเกี่ยวกับตำแหน่งจริงขององค์ประกอบแผนภูมิแม่ ([IActualLayout.getActualX](https://reference.aspose.com/slides/th/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/th/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/IActualLayout#getActualHeight--)) จำเป็นต้องเรียกเมธอด [IChart.validateChartLayout()](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChart#validateChartLayout--) ก่อนเพื่อเติมคุณสมบัติด้วยค่าจริง

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **ซ่อนองค์ประกอบแผนภูมิ**
หัวข้อนี้ช่วยให้คุณเข้าใจวิธีซ่อนข้อมูลจากแผนภูมิ โดยใช้ Aspose.Slides for Java คุณสามารถซ่อน **Title, Vertical Axis, Horizontal Axis** และ **Grid Lines** จากแผนภูมิ ตัวอย่างโค้ดด้านล่างแสดงวิธีใช้คุณสมบัติเหล่านี้

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //ซ่อนหัวเรื่องแผนภูมิ
    chart.setTitle(false);

    ///ซ่อนแกนค่า
    chart.getAxes().getVerticalAxis().setVisible(false);

    //การแสดงผลแกนประเภท
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //ซ่อนคำอธิบาย
    chart.setLegend(false);

    //ซ่อนเส้นกริดหลัก
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //ตั้งค่าสีเส้นของชุดข้อมูล
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**แหล่งข้อมูลจากไฟล์ Excel ภายนอกทำงานได้หรือไม่ และส่งผลต่อการคำนวณใหม่อย่างไร?**

ใช่ แผนภูมิสามารถอ้างอิงไฟล์เวิร์กบุ๊กภายนอกได้: เมื่อคุณเชื่อมต่อหรือรีเฟรชแหล่งข้อมูลภายนอก สูตรและค่าจะถูกดึงจากเวิร์กบุ๊กนั้น และแผนภูมิจะแสดงผลการอัปเดตระหว่างการเปิดหรือแก้ไข API ให้คุณ [specify the external workbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) โดยระบุพาธและจัดการข้อมูลที่เชื่อมโยง

**ฉันสามารถคำนวณและแสดงเส้นแนวโน้มโดยไม่ต้องเขียนโค้ด regression ของตนเองได้หรือไม่?**

ใช่ [Trendlines](/slides/th/java/trend-line/) (เช่น เส้นตรง, เส้นเอ็กซ์โพเนนเชียล ฯลฯ) จะถูกเพิ่มและอัปเดตโดย Aspose.Slides; พารามิเตอร์ของเส้นแนวโน้มจะคำนวณใหม่จากข้อมูลชุดอย่างอัตโนมัติ ดังนั้นไม่จำเป็นต้องเขียนการคำนวณของคุณเอง

**หากงานนำเสนอมีแผนภูมิมากกว่าหนึ่งแผนพร้อมลิงก์ภายนอก ฉันสามารถควบคุมว่าเวิร์กบุ๊กแต่ละแผนภูมิใช้เพื่อคำนวณค่าได้หรือไม่?**

ใช่ แต่ละแผนภูมิสามารถชี้ไปยัง [external workbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) ของตนเองได้ หรือคุณสามารถสร้าง/แทนที่เวิร์กบุ๊กภายนอกสำหรับแต่ละแผนภูมิโดยแยกกันจากแผนภูมิอื่น ๆ