---
title: เพิ่มประสิทธิภาพการคำนวณแผนภูมิสำหรับงานนำเสนอบน Android
linktitle: การคำนวณแผนภูมิ
type: docs
weight: 50
url: /th/androidjava/chart-calculations/
keywords:
- การคำนวณแผนภูมิ
- องค์ประกอบแผนภูมิ
- ตำแหน่งขององค์ประกอบ
- ตำแหน่งจริง
- องค์ประกอบลูก
- องค์ประกอบพาเรนต์
- ค่าของแผนภูมิ
- ค่าจริง
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ทำความเข้าใจการคำนวณแผนภูมิ การอัปเดตข้อมูล และการควบคุมความแม่นยำใน Aspose.Slides สำหรับ Android สำหรับไฟล์ PPT และ PPTX พร้อมตัวอย่างโค้ด Java เชิงปฏิบัติ"
---
## **ภาพรวม**

Aspose.Slides ให้ API สำหรับทำงานกับการคำนวณแผนภูมิและข้อมูลการจัดเลย์เอาต์ในงานนำเสนอ บทความนี้แสดงวิธีดึงค่าจริงขององค์ประกอบแผนภูมิ รวมถึงตำแหน่งและขนาดที่แท้จริงขององค์ประกอบที่ทำการทำงานตาม `IActualLayout` และค่าจริงของแกนแผนภูมิ นอกจากนี้ยังอธิบายว่าค่าเหล่านี้จะถูกกำหนดหลังจากการตรวจสอบการจัดเลย์เอาต์ของแผนภูมิ

นอกจากนี้บทความยังสาธิตวิธีการรับตำแหน่งจริงขององค์ประกอบแผนภูมิระดับพาเรนต์และวิธีการซ่อนส่วนประกอบของแผนภูมิ เช่น ชื่อเรื่อง, แกน, คำอธิบาย, และเส้นกริด ตัวอย่างเหล่านี้ช่วยให้คุณตรวจสอบข้อมูลการจัดเลย์เอาต์ของแผนภูมิและควบคุมการมองเห็นขององค์ประกอบแผนภูมิในงานนำเสนอ PowerPoint อย่างโปรแกรมมิ่ง

## **คำนวณค่าจริงขององค์ประกอบแผนภูมิ**
Aspose.Slides for Android via Java มี API ง่ายสำหรับการดึงคุณสมบัติเหล่านี้ คุณสมบัติของอินเทอร์เฟซ [IAxis](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAxis) ให้ข้อมูลเกี่ยวกับตำแหน่งจริงขององค์ประกอบแกนแผนภูมิ ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAxis#getActualMaxValue--),[IAxis.getActualMinValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAxis#getActualMinValue--),[IAxis.getActualMajorUnit](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--),[IAxis.getActualMinorUnit](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--),[IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--),[IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)) จำเป็นต้องเรียกเมธอด [IChart.validateChartLayout()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChart#validateChartLayout--) ก่อนเพื่อเติมคุณสมบัติด้วยค่าจริง

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

## **คำนวณตำแหน่งจริงขององค์ประกอบแผนภูมิระดับพาเรนต์**
Aspose.Slides for Android via Java มี API ง่ายสำหรับการดึงคุณสมบัติเหล่านี้ คุณสมบัติของอินเทอร์เฟซ [IActualLayout](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IActualLayout) ให้ข้อมูลเกี่ยวกับตำแหน่งจริงขององค์ประกอบแผนภูมิระดับพาเรนต์ ([IActualLayout.getActualX](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IActualLayout#getActualX--),[IActualLayout.getActualY](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IActualLayout#getActualY--),[IActualLayout.getActualWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IActualLayout#getActualWidth--),[IActualLayout.getActualHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)) จำเป็นต้องเรียกเมธอด [IChart.validateChartLayout()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChart#validateChartLayout--) ก่อนเพื่อเติมคุณสมบัตด้วยค่าจริง

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
หัวข้อนี้ช่วยให้คุณเข้าใจวิธีซ่อนข้อมูลจากแผนภูมิ โดยใช้ Aspose.Slides for Android via Java คุณสามารถซ่อน **Title, Vertical Axis, Horizontal Axis** และ **Grid Lines** จากแผนภูมิ ตัวอย่างโค้ดด้านล่างแสดงวิธีการใช้คุณสมบัติเหล่านี้

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //ซ่อนชื่อแผนภูมิ
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

    //ตั้งค่าสีเส้นชุดข้อมูล
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != NULL) pres.dispose();
}
```

## **FAQ**

**Do external Excel workbooks work as a data source, and how does that affect recalculation?**

ใช่ แผนภูมิสามารถอ้างอิงเวิร์กบุ๊กภายนอกได้: เมื่อคุณเชื่อมต่อหรือรีเฟรชแหล่งข้อมูลภายนอก สูตรและค่าจะถูกดึงจากเวิร์กบุ๊กนั้นและแผนภูมิจะแสดงการอัปเดตระหว่างการเปิดหรือแก้ไข API ให้คุณ [specify the external workbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) เส้นทางและจัดการข้อมูลที่เชื่อมโยง

**Can I compute and display trendlines without implementing regression myself?**

ใช่ [Trendlines](/slides/th/androidjava/trend-line/) (เชิงเส้น, เอ็กซ์โพเนนเชียล, และอื่นๆ) จะถูกเพิ่มและอัปเดตโดย Aspose.Slides; พารามิเตอร์ของพวกมันจะถูกคำนวณใหม่จากข้อมูลซีรีส์โดยอัตโนมัติ ดังนั้นคุณไม่ต้องทำการคำนวณของคุณเอง

**If a presentation has multiple charts with external links, can I control which workbook each chart uses for computed values?**

ใช่ แผนภูมิแต่ละรายการสามารถชี้ไปยัง [external workbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) ของตนเอง หรือคุณสามารถสร้าง/แทนที่เวิร์กบุ๊กภายนอกสำหรับแต่ละแผนภูมิโดยอิสระจากแผนภูมิอื่น