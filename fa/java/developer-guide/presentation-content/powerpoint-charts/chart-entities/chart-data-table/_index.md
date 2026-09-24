---
title: سفارشی‌سازی جداول داده‌های نمودار در ارائه‌ها با استفاده از جاوا
linktitle: جدول داده
type: docs
url: /fa/java/chart-data-table/
keywords:
- داده‌های نمودار
- جدول داده
- ویژگی‌های قلم
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "قلم‌ها، حاشیه‌ها و کلیدهای راهنمای جدول داده‌های نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Java سفارشی کنید."
---
## **مروری کلی**

Aspose.Slides for Java به شما امکان نمایش جدول داده‌های نمودار و سفارشی‌سازی قالب‌بندی متن، حاشیه‌ها و کلیدهای راهنما را می‌دهد. این مقاله توضیح می‌دهد چگونه جدول را فعال کنید، متن آن را قالب‌بندی کنید، هر نوع حاشیه را کنترل کنید و کلیدهای راهنما را نشان یا مخفی کنید. مثال‌ها نمودارهای پیکربندی شده را در فایل‌های PPTX ذخیره می‌کنند.

## **تنظیم ویژگی‌های قلم**

برای نمایش جدول داده‌های یک نمودار، مقدار `true` را به [setDataTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/#setDataTable-boolean-) بدهید. از [getChartDataTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/#getChartDataTable--) برای دسترسی به جدول و پیکربندی قالب‌بندی متن استفاده کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید.  
2. یک نمودار ستونی خوشه‌ای به اسلاید اول اضافه کنید.  
3. جدول داده‌های نمودار را فعال کنید.  
4. با استفاده از [setFontBold](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) متن را بولد کنید و مقدار `20` را به [setFontHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) بدهید تا متن 20 پوینت باشد.  
5. ارائه اصلاح شده را ذخیره کنید.

مثال زیر برای وجود `test.pptx` در پوشه کاری که حداقل یک اسلاید دارد، نیاز دارد. این مثال یک نمودار با داده‌های پیش‌فرض در موقعیت (50, 50) با عرض 600 پوینت و ارتفاع 400 پوینت اضافه می‌کند. فایل `output.pptx` ذخیره‌شده شامل نمودار با جدول داده فعال و تنظیمات قلم مشخص‌شده است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سفارشی‌سازی حاشیه‌های جدول داده‌ها**

جدول را با [IChart.setDataTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#setDataTable-boolean-) فعال کنید و از طریق [IChart.getChartDataTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#getChartDataTable--) به آن دسترسی پیدا کنید. می‌توانید سه نوع حاشیه را به‌صورت مستقل کنترل کنید:

- [setBorderHorizontal](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) حاشیه‌های افقی سلول‌ها را کنترل می‌کند.  
- [setBorderVertical](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) حاشیه‌های عمودی سلول‌ها را کنترل می‌کند.  
- [setBorderOutline](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) حاشیه بیرونی جدول را کنترل می‌کند.

برای نمایش حاشیه‌ها مقدار `true` و برای مخفی‌کردن مقدار `false` به هر متد بدهید. مثال زیر یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند، حاشیه‌های افقی و حاشیه بیرونی را نمایش می‌دهد و حاشیه‌های عمودی را مخفی می‌کند. نیازی به فایل ورودی نیست. موقعیت و اندازه نمودار بر حسب پوینت مشخص شده‌اند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مقایسه زیر از همان داده‌های نمودار و تنظیم کلید راهنما در چهار حالت استفاده می‌کند. با فعال بودن همه حاشیه‌ها شروع می‌شود و در هر حالت یک نوع حاشیه غیرفعال می‌شود. حالت پایین‑چپ تنظیمات حاشیه نمونه را نشان می‌دهد.

![جدول‌های داده‌ ای نمودار با تمام حاشیه‌ها فعال، بدون حاشیه افقی، بدون حاشیه عمودی و بدون حاشیه بیرونی](data-table-borders.png)

## **نمایش یا مخفی‌سازی کلیدهای راهنما**

کلیدهای راهنما نشانگرهای رنگی کوچکی هستند که در سمت نام سری‌ها در جدول داده قرار دارند. این کلیدها به خوانندگان کمک می‌کنند هر ردیف جدول را به سری مربوطه در نمودار ربط دهند. مقدار `true` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) بدهید تا این نشانگرها نمایش داده شوند یا مقدار `false` بدهید تا مخفی شوند.

راهنمای جداگانه نمودار توسط [IChart.setLegend](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#setLegend-boolean-) کنترل می‌شود. این تنظیمات مستقل‌اند: مخفی‌سازی راهنمای جداگانه کلیدهای داخل جدول داده را مخفی نمی‌کند و مخفی‌سازی کلیدهای جدول، راهنمای جداگانه را تحت تأثیر قرار نمی‌دهد.

مثال زیر یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده آن را فعال می‌کند و کلیدهای راهنما را داخل جدول نشان می‌دهد در حالی که راهنمای جداگانه مخفی است. تمام حاشیه‌های جدول به‌وضوح فعال هستند. نیازی به ارائه ورودی نیست. برای مخفی‌سازی فقط کلیدهای جدول، مقدار `false` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) بدهید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مقایسه زیر همان جدول را با کلیدهای راهنما فعال و غیرفعال نشان می‌دهد. همه حاشیه‌ها فعال می‌مانند و راهنمای جداگانه در هر دو حالت مخفی است.

![جدول‌های داده‌ ای نمودار با کلیدهای راهنما در سمت چپ نشان داده‌شده و در سمت راست مخفی‌شده](data-table-legend-keys.png)

## **سوالات متداول**

**آیا می‌توانم کلیدهای راهنما را در جدول داده‌های یک نمودار نشان دهم؟**

بله. مقدار `true` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) بدهید تا کلیدهای راهنما نمایش داده شوند یا مقدار `false` بدهید تا مخفی شوند.

**آیا جدول داده هنگام صادرات ارائه به PDF، HTML یا تصویر حفظ می‌شود؟**

بله. Aspose.Slides هنگام صادرات به [PDF](/slides/fa/java/convert-powerpoint-to-pdf/)، [HTML](/slides/fa/java/convert-powerpoint-to-html/) یا [images](/slides/fa/java/convert-powerpoint-to-png/) نمودار و جدول داده نمایش‌داده‌شده را به‌عنوان بخشی از اسلاید رندر می‌کند.

**آیا می‌توانم با جدول‌های داده در نمودارهای بارگذاری‌شده از یک قالب کار کنم؟**

بله. برای یک نمودار که از یک ارائه یا قالب موجود بارگذاری شده است، از [hasDataTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/#hasDataTable--) و [setDataTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/#setDataTable-boolean-) استفاده کنید تا بررسی یا تغییر دهید که آیا جدول داده نمایش داده می‌شود یا خیر.

**چگونه می‌توانم نمودارهایی که جدول داده آن‌ها فعال است را پیدا کنم؟**

از طریق پیمایش شکل‌ها در هر اسلاید، نمودارها را شناسایی کنید و متد [hasDataTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/#hasDataTable--) آن‌ها را صدا بزنید. مقدار `true` نشان می‌دهد جدول داده فعال است.