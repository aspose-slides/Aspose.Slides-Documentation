---
title: بهینه‌سازی محاسبات نمودار برای ارائه‌ها در Android
linktitle: محاسبات نمودار
type: docs
weight: 50
url: /fa/androidjava/chart-calculations/
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
  - Android
  - Java
  - Aspose.Slides
description: "محاسبات نمودار، به‌روزرسانی داده‌ها و کنترل دقت را در Aspose.Slides برای Android برای فایل‌های PPT و PPTX درک کنید، همراه با مثال‌های عملی کد Java."
---
## **مروری کلی**

Aspose.Slides APIهایی برای کار با محاسبات نمودار و داده‌های طرح‌بندی در ارائه‌ها فراهم می‌کند. این مقاله نشان می‌دهد چگونه مقادیر واقعی عناصر نمودار، از جمله موقعیت و اندازه حقیقی عناصری که `IActualLayout` را پیاده‌سازی می‌کنند و مقادیر واقعی محورهای نمودار، بازیابی شوند. همچنین توضیح می‌دهد که این مقادیر پس از اعتبارسنجی طرح‌بندی نمودار پر می‌شوند.

علاوه بر این، مقاله نحوه دریافت موقعیت واقعی عناصر والد نمودار و چگونگی مخفی‌سازی اجزای نمودار مانند عنوان، محورها، افسانه و خطوط شبکه را نشان می‌دهد. به‌هم‌پیوند این مثال‌ها به شما کمک می‌کند تا اطلاعات طرح‌بندی نمودار را بررسی کرده و به‌صورت برنامه‌نویسی‌شده قابلیت مشاهده عناصر نمودار را در ارائه‌های PowerPoint کنترل کنید.

## **محاسبه مقادیر واقعی عناصر نمودار**
Aspose.Slides برای Android از طریق Java API ساده‌ای برای دریافت این ویژگی‌ها فراهم می‌کند. ویژگی‌های رابط [IAxis](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAxis) اطلاعاتی درباره موقعیت واقعی عنصر محور نمودار ارائه می‌دهد ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). برای پر شدن ویژگی‌ها با مقادیر واقعی لازم است قبل از آن متد [IChart.validateChartLayout()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChart#validateChartLayout--) را فراخوانی کنید.

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
Aspose.Slides برای Android از طریق Java API ساده‌ای برای دریافت این ویژگی‌ها فراهم می‌کند. ویژگی‌های رابط [IActualLayout](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IActualLayout) اطلاعاتی درباره موقعیت واقعی عنصر والد نمودار ارائه می‌دهد ([IActualLayout.getActualX](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). برای پر شدن ویژگی‌ها با مقادیر واقعی لازم است قبل از آن متد [IChart.validateChartLayout()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChart#validateChartLayout--) را فراخوانی کنید.

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

## **مخفی‌سازی عناصر نمودار**
این موضوع به شما کمک می‌کند تا نحوه مخفی‌سازی اطلاعات در نمودار را درک کنید. با استفاده از Aspose.Slides برای Android از طریق Java می‌توانید **Title**, **Vertical Axis**, **Horizontal Axis** و **Grid Lines** را از نمودار مخفی کنید. مثال کد زیر نشان می‌دهد چگونه از این ویژگی‌ها استفاده شود.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //مخفی‌سازی عنوان نمودار
    chart.setTitle(false);

    ///مخفی‌سازی محور مقادیر
    chart.getAxes().getVerticalAxis().setVisible(false);

    //قابلیت مشاهده محور دسته‌بندی
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //مخفی‌سازی افسانه
    chart.setLegend(false);

    //مخفی‌سازی خطوط شبکه اصلی
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

**آیا کتاب‌های کاری Excel خارجی به عنوان منبع داده کار می‌کنند و این بر محاسبه مجدد چه تاثیری دارد؟**

بله. یک نمودار می‌تواند به یک کتاب‌کار خارجی ارجاع دهد: زمانی که منبع خارجی را وصل یا تازه‌سازی می‌کنید، فرمول‌ها و مقادیر از آن کتاب‌کار استخراج می‌شوند و نمودار به‌روزرسانی‌ها را در حین عملیات باز/ویرایش منعکس می‌کند. این API به شما امکان می‌دهد مسیر [specify the external workbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) را تعیین کرده و داده‌های لینک‌شده را مدیریت کنید.

**آیا می‌توانم خطوط روند را محاسبه و نمایش دهم بدون اینکه خودم رگرسیون را پیاده‌سازی کنم؟**

بله. [Trendlines](/slides/fa/androidjava/trend-line/) (خطی، نمایی و سایر) توسط Aspose.Slides اضافه و به‌روزرسانی می‌شوند؛ پارامترهای آن‌ها به‌صورت خودکار از داده‌های سری بازمحاسبه می‌شود، بنابراین نیازی به پیاده‌سازی محاسبات خودتان ندارید.

**اگر یک ارائه دارای چندین نمودار با لینک‌های خارجی باشد، آیا می‌توانم کنترل کنم که هر نمودار از کدام کتاب‌کار خارجی برای مقادیر محاسبه‌شده استفاده می‌کند؟**

بله. هر نمودار می‌تواند به [external workbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) خود اشاره کند، یا می‌توانید برای هر نمودار به‌صورت مستقل یک کتاب‌کار خارجی ایجاد/جایگزین کنید.