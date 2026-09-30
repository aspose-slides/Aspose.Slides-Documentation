---
title: سفارشی‌سازی راهنمای نمودارها در ارائه‌ها با استفاده از جاوا
linktitle: راهنمای نمودار
type: docs
url: /fa/java/chart-legend/
keywords:
- راهنمای نمودار
- موقعیت راهنما
- اندازه قلم
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "راهنمای نمودارها را با Aspose.Slides برای جاوا سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی متناسب راهنما بهینه کنید."
---
## **نمای کلی**

Aspose.Slides for Java گزینه‌هایی برای سفارشی‌سازی راهنمای نمودارها در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه موقعیت و اندازهٔ یک راهنما را تعیین کنید، اندازهٔ قلم را برای کل راهنما تنظیم کنید، یک ورودی راهنمای منفرد را قالب‌بندی کنید، و ورودی‌های انتخابی را پنهان یا بازیابی کنید.

سؤالات متداول رفتارهای مرتبط را شامل می‌شود، از جمله رزرو فضا برای راهنما، نمایش برچسب‌های چندخطی، و ارث‌بری قالب‌بندی از تم ارائه.

## **موقعیت‌گذاری راهنما**

از متدهای [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-)، [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-)، [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-)، و [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) راهنما برای مشخص کردن موقعیت و اندازهٔ آن به عنوان کسرهای ابعاد نمودار استفاده کنید.

این مثال یک ارائه ایجاد می‌کند و یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض به اسلاید اول اضافه می‌‎کند. تقسیم مقادیر آفست و ابعاد دلخواه راهنما بر عرض و ارتفاع نمودار، آنها را به مقادیر نسبی تبدیل می‌کند: راهنما ۵۰ نقطه از گوشهٔ بالا‑چپ نمودار فاصله دارد و به اندازهٔ ۱۰۰ در ۱۰۰ نقطه تنظیم شده است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // موقعیت و اندازهٔ راهنما را نسبت به نمودار بیان می‌کند.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم اندازه فونت راهنما**

از [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) راهنما برای دسترسی به قالب‌بندی متن آن استفاده کنید و با [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) اندازهٔ قلم را بر حسب نقطه تنظیم کنید.

این مثال یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند و متن راهنما را به ۲۰ نقطه تنظیم می‌‎کند. همچنین مرزهای خودکار محور عمودی را غیرفعال کرده و محدودهٔ آن را از ‎‑۵ تا ۱۰ تنظیم می‌‎کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم اندازه فونت ورودی راهنمای منفرد**

از مجموعهٔ بازگشتی توسط متد [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) راهنما برای دسترسی به قالب‌بندی یک ورودی خاص استفاده کنید. ایندکس‌های ورودی صفر‑پایه‌اند، بنابراین ایندکس `1` به ورودی دوم اشاره دارد.

این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند که داده‌های پیش‌فرض آن شامل حداقل دو سری است. ورودی دوم راهنما را با قلم بولد، ایتالیک و متن آبی ۲۰‑نقطه‌ای قالب‌بندی می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پنهان کردن ورودی‌های راهنمای منفرد**

برای حذف یک سری کمکی از راهنما در حالی که داده‌های آن قابل مشاهده می‌مانند، [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) را با مقدار `true` از طریق [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) صدا بزنید. این کار تنها ورودی انتخابی راهنما را پنهان می‌کند؛ سری یا نقاط دادهٔ آن حذف نمی‌شود. در مقابل، صدا زدن [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) با مقدار `false` کل راهنما را مخفی می‌کند.

مثال زیر یک نمودار ستونی خوشه‌ای با چندین سری با داده‌های پیش‌فرض ایجاد می‌کند. ورودی راهنمای سری دوم (ایندکس `1`) را پنهان می‌کند و ارائه را ذخیره می‌‎کند. سپس با صدا زدن [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) با مقدار `false` ورودی را بازیابی می‌کند و یک نسخهٔ دوم ذخیره می‌‎نماید. ستون‌ها در هر دو فایل قابل مشاهده می‌مانند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // ورودی همان را بدون تغییر داده‌های نمودار بازیابی کنید.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مقایسهٔ زیر همان نمودار را نشان می‌دهد که در یک حالت تمام ورودی‌های راهنما قابل مشاهده‌اند و در حالت دیگر ورودی دوم مخفی است. ستون‌های سری دوم تغییر نمی‌کند.

![مقایسه یک نمودار با تمام ورودی‌های راهنما قابل مشاهده و با مخفی شدن‌سری ۲ از راهنما؛ تمام ستون‌ها قابل مشاهده باقی می‌مانند.](hide-legend-entry.png)

در نمودارهای ستونی، ستونی و خطی، ورودی‌های راهنما به شناسایی سری‌ها می‌پردازند. برای نمودارهای دایره‌ای، آنها به نقاط دادهٔ منفرد (قطعات) اشاره می‌کنند، بنابراین به جای آن از [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) روی قطعهٔ انتخابی استفاده کنید. این روش نقطه‌داده‌ای برای نوع نمودارهای `Pie`، `Pie3D`، `ExplodedPie`، `ExplodedPie3D`، `PieOfPie` و `BarOfPie` مستند شده است. فرض نکنید که برای نمودارهای دونات نیز اعمال می‌شود؛ این نوع نمودارها در لیست مذکور گنجانده نشده‌اند.

## **سوالات متداول**

**آیا می‌توانم به جای پوشاندن، برای راهنما فضای جداگانه‌ای اختصاص دهم؟**

بله. با صدا زدن [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) با مقدار `false` برای رزرو فضای راهنما به جای اجازهٔ همپوشانی آن با ناحیهٔ نمودار.

**آیا می‌توانم برچسب‌های راهنما را به صورت چند خطی داشته باشم؟**

بله. برچسب‌های طولانی زمانی که عرض موجود کافی نباشد می‌توانند به خط بعدی منتقل شوند. همچنین می‌توانید از کاراکترهای خط جدید در نام‌های سری برای درخواست شکست خط استفاده کنید.

**چگونه می‌توانم راهنما را طوری تنظیم کنم که از طرح رنگی تم ارائه پیروی کند؟**

رنگ‌ها، پرکننده‌ها و قلم‌های راهنما را تنظیم نکنید تا بتواند قالب‌بندی تم را به ارث ببرد. قالب‌بندی صریح تنظیمات تم مربوطه را نادیده می‌گیرد.