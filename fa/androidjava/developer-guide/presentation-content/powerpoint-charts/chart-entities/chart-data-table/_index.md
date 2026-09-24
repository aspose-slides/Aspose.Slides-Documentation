---
title: سفارشی‌سازی جداول داده‌ای نمودار در ارائه‌های اندروید
linktitle: جدول داده
type: docs
url: /fa/androidjava/chart-data-table/
keywords:
- داده‌های نمودار
- جدول داده
- ویژگی‌های قلم
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "سفارشی‌سازی قلم‌های جدول داده‌های نمودار، خطوط مرزی و کلیدهای افسانه در ارائه‌های پاورپوینت با استفاده از Aspose.Slides برای اندروید از طریق جاوا."
---
## **بررسی کلی**

Aspose.Slides برای Android از طریق Java به شما امکان نمایش جدول داده‌های نمودار و سفارشی‌سازی قالب‌بندی متن، خطوط مرزی و کلیدهای افسانه را می‌دهد. این مقاله توضیح می‌دهد چگونه جدول را فعال کنید، متن آن را قالب‌بندی کنید، هر نوع خط مرزی را کنترل کنید و کلیدهای افسانه را نشان یا مخفی کنید. مثال‌ها نمودارهای پیکربندی‌شده را در فایل‌های PPTX ذخیره می‌کنند.

## **تنظیم ویژگی‌های قلم**

برای نمایش جدول داده‌های نمودار، مقدار `true` را به [setDataTable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) بدهید. برای دسترسی به جدول و پیکربندی قالب‌بندی متن آن از [getChartDataTable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/#getChartDataTable--) استفاده کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگذاری کنید.
1. یک نمودار ستونی خوشه‌ای به اسلاید اول اضافه کنید.
1. جدول داده‌های نمودار را فعال کنید.
1. متن پررنگ را با [setFontBold](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) فعال کنید و برای متن 20‑نقطه‌ای مقدار `20` را به [setFontHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) بدهید.
1. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر نیاز به فایل `test.pptx` در پوشه کاری دارد که حداقل شامل یک اسلاید باشد. این مثال یک نمودار با داده‌های پیش‌فرض در موقعیت (50, 50) اضافه می‌کند، با عرض 600 نقطه و ارتفاع 400 نقطه. فایل `output.pptx` ذخیره‌شده شامل نمودار با جدول داده‌های فعال و تنظیمات قلم مشخص‌شده است.

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

## **سفارشی‌سازی خطوط مرزی جدول داده‌ها**

جدول را با [IChart.setDataTable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) فعال کنید و از طریق [IChart.getChartDataTable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#getChartDataTable--) به آن دسترسی پیدا کنید. می‌توانید سه نوع خط مرزی را به‌صورت مستقل کنترل کنید:

- [setBorderHorizontal](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) خطوط افقی سلول‌ها را کنترل می‌کند.
- [setBorderVertical](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) خطوط عمودی سلول‌ها را کنترل می‌کند.
- [setBorderOutline](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) مرز بیرونی جدول را کنترل می‌کند.

مقدار `true` را به هر متد بدهید تا مرزبندی آن نمایش داده شود یا `false` برای مخفی کردن. مثال زیر یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند، خطوط افقی و مرز بیرونی را نمایش می‌دهد و خطوط عمودی را مخفی می‌کند. نیازی به فایل ورودی ندارد. موقعیت و اندازه نمودار بر حسب نقطه مشخص شده‌اند.

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

مقایسه زیر از یک مجموعه داده نموداری و تنظیمات کلید افسانه در تمام چهار حالت استفاده می‌کند. از حالت فعال بودن تمام خطوط مرزی شروع می‌شود، و هر گونه‌گی دیگر تنها یک تنظیم خط مرزی را غیرفعال می‌کند. گونه‌گی پایین‑چپ تنظیمات خطوط مرزی مشابه مثال است.

![جدول‌های داده‌ای نمودار با تمام خطوط مرزی فعال، بدون خطوط افقی، بدون خطوط عمودی، و بدون خط بیرونی](data-table-borders.png)

## **نمایش یا مخفی کردن کلیدهای افسانه**

کلیدهای افسانه نشانگرهای کوچک رنگی در کنار نام سری‌ها در جدول داده‌ها هستند. آنها به خواننده کمک می‌کنند تا هر ردیف جدول را با یک سری نمودار تطبیق دهد. مقدار `true` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) بدهید تا این نشانگرها نمایش داده شوند یا `false` برای مخفی کردن آن‌ها.

افسانه جداگانه نمودار توسط [IChart.setLegend](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) کنترل می‌شود. این تنظیمات مستقل هستند: مخفی کردن افسانه جداگانه کلیدهای داخل جدول داده‌ها را مخفی نمی‌کند و مخفی کردن کلیدهای جدول، افسانه جداگانه را مخفی نمی‌سازد.

مثال زیر یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده‌ها را فعال می‌کند و کلیدهای افسانه را در داخل آن نشان می‌دهد در حالی که افسانه جداگانه مخفی است. تمام خطوط مرزی جدول به‌صورت صریح فعال هستند. نیازی به ارائه ورودی نیست. برای مخفی کردن فقط کلیدهای جدول، مقدار `false` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) بدهید.

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

مقایسه زیر همان جدول را با کلیدهای افسانه فعال و غیرفعال نشان می‌دهد. تمام خطوط مرزی فعال می‌مانند و افسانه جداگانه نمودار در هر دو حالت مخفی است.

![جدول‌های داده‌ای نمودار با کلیدهای افسانه نمایان در سمت چپ و مخفی در سمت راست](data-table-legend-keys.png)

## **سوالات متداول**

**آیا می‌توانم کلیدهای افسانه را در جدول داده‌های نمودار نشان دهم؟**

بله. مقدار `true` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) بدهید تا کلیدهای افسانه نمایش داده شوند یا `false` برای مخفی کردن آن‌ها.

**آیا جدول داده‌ها هنگام خروجی گرفتن ارائه به PDF، HTML یا تصویرها حفظ می‌شود؟**

بله. Aspose.Slides نمودار و جدول داده‌های نمایش داده‌شده را به‌عنوان بخشی از اسلاید هنگام خروجی به [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/)، [HTML](/slides/fa/androidjava/convert-powerpoint-to-html/)، یا [images](/slides/fa/androidjava/convert-powerpoint-to-png/) رندر می‌کند.

**آیا می‌توانم با جدول‌های داده در نمودارهای بارگذاری‌شده از یک قالب کار کنم؟**

بله. برای نموداری که از ارائه یا قالب موجود بارگذاری شده است، از [hasDataTable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/#hasDataTable--) و [setDataTable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/#setDataTable-boolean--) برای بررسی یا تغییر نمایش جدول داده‌ها استفاده کنید.

**چگونه می‌توانم نمودارهایی را پیدا کنم که جدول داده آن‌ها فعال است؟**

در میان اشکال هر اسلاید پیمایش کنید، نمودارها را شناسایی کنید و متد [hasDataTable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/#hasDataTable--) آنها را فراخوانی کنید. مقدار `true` نشان‌دهنده فعال بودن جدول داده است.