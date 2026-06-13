---
title: بهینه‌سازی محاسبه‌های نمودار برای ارائه‌ها در جاوا
linktitle: محاسبات نمودار
type: docs
weight: 50
url: /fa/java/chart-calculations/
keywords:
- محاسبات نمودار
- عناصر نمودار
- موقعیت عنصر
- موقعیت واقعی
- عنصر فرزند
- عنصر والد
- مقادیر نمودار
- مقدار واقعی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "محاسبات نمودار، به‌روزرسانی داده‌ها و کنترل دقت را در Aspose.Slides برای جاوا برای PPT و PPTX درک کنید، همراه با مثال‌های عملی کد جاوا."
---
## **نمای کلی**

Aspose.Slides APIهایی را برای کار با محاسبات نمودار و داده‌های چیدمان در ارائه‌ها فراهم می‌کند. این مقاله نشان می‌دهد چگونه مقادیر واقعی عناصر نمودار را بازیابی کنید، از جمله موقعیت و اندازه واقعی عناصری که `IActualLayout` را پیاده‌سازی می‌کنند و مقادیر واقعی محورهای نمودار. همچنین توضیح می‌دهد که این مقادیر پس از اعتبارسنجی چیدمان نمودار پر می‌شوند.

علاوه بر این، مقاله چگونگی دریافت موقعیت واقعی عناصر والد نمودار و نحوه پنهان کردن مؤلفه‌های نمودار مانند عنوان، محورها، افسانه و خطوط شبکه را نشان می‌دهد. این مثال‌ها به شما کمک می‌کند تا اطلاعات چیدمان نمودار را بررسی کنید و قابلیت نمایش عناصر نمودار را به‌صورت برنامه‌نویسی در ارائه‌های PowerPoint کنترل کنید.

## **محاسبه مقادیر واقعی عناصر نمودار**
Aspose.Slides for Java یک API ساده برای دریافت این ویژگی‌ها فراهم می‌کند. ویژگی‌های رابط [IAxis](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAxis) اطلاعاتی در مورد موقعیت واقعی عنصر محور نمودار ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAxis#getActualMaxValue--)، [IAxis.getActualMinValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAxis#getActualMinValue--)، [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAxis#getActualMajorUnit--)، [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAxis#getActualMinorUnit--)، [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAxis#getActualMajorUnitScale--)، [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)) ارائه می‌دهند. پیش از پر کردن ویژگی‌ها با مقادیر واقعی، لازم است متد [IChart.validateChartLayout()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChart#validateChartLayout--) را فراخوانی کنید.

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

## **محاسبه موقعیت واقعی عناصر والد نمودار**
Aspose.Slides for Java یک API ساده برای دریافت این ویژگی‌ها فراهم می‌کند. ویژگی‌های رابط [IActualLayout](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IActualLayout) اطلاعاتی در مورد موقعیت واقعی عنصر والد نمودار ([IActualLayout.getActualX](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IActualLayout#getActualX--)، [IActualLayout.getActualY](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IActualLayout#getActualY--)، [IActualLayout.getActualWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IActualLayout#getActualWidth--)، [IActualLayout.getActualHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IActualLayout#getActualHeight--)) ارائه می‌دهند. پیش از پر کردن ویژگی‌ها با مقادیر واقعی، لازم است متد [IChart.validateChartLayout()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChart#validateChartLayout--) را فراخوانی کنید.

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

## **پنهان کردن عناصر نمودار**
این بخش به شما کمک می‌کند تا بفهمید چگونه می‌توان اطلاعاتی را از نمودار مخفی کرد. با استفاده از Aspose.Slides for Java می‌توانید **عنوان، محور عمودی، محور افقی** و **خطوط شبکه** را از نمودار مخفی کنید. مثال کد زیر نشان می‌دهد چگونه از این ویژگی‌ها استفاده کنید.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //مخفی کردن عنوان نمودار
    chart.setTitle(false);

    ///مخفی کردن محور مقادیر
    chart.getAxes().getVerticalAxis().setVisible(false);

    //قابلیت نمایش محور دسته
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //مخفی کردن افسانه
    chart.setLegend(false);

    //مخفی کردن خطوط شبکه اصلی
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

    //تنظیم رنگ خط سری
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**آیا کتاب‌کارهای خارجی اکسل می‌توانند به‌عنوان منبع داده استفاده شوند و این بر محاسبه مجدد چه تأثیری دارد؟**

بله. یک نمودار می‌تواند به یک کتاب‌کار خارجی ارجاع دهد: هنگام اتصال یا تازه‌سازی منبع خارجی، فرمول‌ها و مقادیر از آن کتاب‌کار گرفته می‌شود و نمودار در حین عملیات باز/ویرایش به‌روزرسانی‌ها را منعکس می‌کند. API امکان [specify the external workbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) مسیر را به شما می‌دهد و می‌توانید داده‌های لینک‌شده را مدیریت کنید.

**آیا می‌توانم خطوط روند را محاسبه و نمایش دهم بدون اینکه خودم رگرسیون را پیاده‌سازی کنم؟**

بله. [Trendlines](/slides/fa/java/trend-line/) (خطی، نمایی و دیگر انواع) توسط Aspose.Slides اضافه و به‌روز می‌شوند؛ پارامترهای آن‌ها به‌صورت خودکار از داده‌های سری محاسبه می‌شوند، بنابراین نیازی به پیاده‌سازی محاسبه‌های خودتان ندارید.

**اگر یک ارائه دارای چندین نمودار با پیوندهای خارجی باشد، آیا می‌توانم کنترل کنم که هر نمودار از کدام کتاب‌کار برای مقادیر محاسبه‌شده استفاده کند؟**

بله. هر نمودار می‌تواند به [external workbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) اختصاصی خود اشاره کند، یا می‌توانید برای هر نمودار به‌صورت مستقل یک کتاب‌کار خارجی ایجاد یا جایگزین کنید.