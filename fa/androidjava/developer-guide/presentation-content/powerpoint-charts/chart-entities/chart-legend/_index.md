---
title: سفارشی‌سازی لگن‌های نمودار در ارائه‌ها روی Android
linktitle: لگن نمودار
type: docs
url: /fa/androidjava/chart-legend/
keywords:
- لگن نمودار
- موقعیت لگن
- اندازه قلم
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "لگن‌های نمودار را با Aspose.Slides برای Android از طریق Java سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی لگن متناسب بهینه نمایید."
---
## **بررسی کلی**

Aspose.Slides برای Android از طریق Java گزینه‌هایی برای سفارشی‌سازی لگن‌های نمودار در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه موقعیت و اندازه یک لگن را تنظیم کنید، اندازه قلم را برای کل لگن تعیین کنید، یک ورودی لگن منفرد را قالب‌بندی کنید و ورودی‌های انتخابی را مخفی یا بازگردانید.

سوالات متداول شامل رفتارهای مرتبط، از جمله رزرو فضای برای لگن، نمایش برچسب‌های چندخطی، و ارث‌بری قالب‌بندی از قالب ارائه است.

## **موقعیت‌یابی لگن**

از متدهای [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), و [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) لگن استفاده کنید تا موقعیت و اندازه آن را به صورت کسرهایی از ابعاد نمودار مشخص کنید.

این مثال یک ارائه ایجاد می‌کند و یک نمودار ستون خوشه‌ای با داده‌های پیش‌فرض به اولین اسلاید اضافه می‌کند. تقسیم مقادیر جابجایی و ابعاد مطلوب لگن بر عرض و ارتفاع نمودار آنها را به مقادیر نسبی تبدیل می‌کند: لگن ۵۰ پوینت از گوشه بالا‑چپ نمودار جابجا شده و به اندازه ۱۰۰ در ۱۰۰ پوینت تنظیم می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // موقعیت و اندازه لگن را نسبت به نمودار نشان می‌دهد.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم اندازه قلم یک لگن**

از [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) لگن برای دسترسی به قالب‌بندی متن آن استفاده کنید و با [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) اندازه قلم را بر حسب پوینت تنظیم کنید.

این مثال یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند و متن لگن را به ۲۰ پوینت تنظیم می‌کند. همچنین مرزهای خودکار برای محور عمودی را غیرفعال کرده و بازه آن را از -5 تا 10 تنظیم می‌نماید.

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

## **تنظیم اندازه قلم یک ورودی منفرد لگن**

از مجموعه‌ای که توسط متد [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) لگن برگردانده می‌شود برای دسترسی به قالب‌بندی ورودی خاص استفاده کنید. شاخص‌های ورودی صفر‑مبنا هستند، بنابراین شاخص `1` به ورودی دوم اشاره دارد.

این مثال یک نمودار ستون خوشه‌ای ایجاد می‌کند که داده‌های پیش‌فرض آن شامل حداقل دو سری است. ورودی دوم لگن را با متن ضخیم، کج و آبی به اندازه ۲۰ پوینت قالب‌بندی می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **مخفی‌سازی ورودی‌های منفرد لگن**

برای حذف یک سری کمکی از لگن در حالی که داده‌های آن قابل مشاهده باقی می‌مانند، با `true` متد [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) را از طریق [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) فراخوانی کنید. این فقط ورودی منتخب لگن را مخفی می‌کند؛ سری یا نقاط داده آن حذف نمی‌شوند. در عوض، فراخوانی [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) با `false` کل لگن را مخفی می‌سازد.

مثال زیر یک نمودار ستون خوشه‌ای با چندین سری با استفاده از داده‌های پیش‌فرض ایجاد می‌کند. ورودی لگن سری دوم (شاخص `1`) را مخفی می‌کند و ارائه را ذخیره می‌نماید. سپس با فراخوانی [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) با `false` ورودی را بازیابی کرده و یک نسخه دوم ذخیره می‌کند. ستون‌ها در هر دو فایل قابل مشاهده می‌مانند.

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

    // ورودی یکسان را بدون تغییر داده‌های نمودار بازیابی کنید.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مقایسه زیر همان نمودار را نشان می‌دهد که همه ورودی‌ها قابل مشاهده هستند و ورودی دوم مخفی شده است. ستون‌های سری دوم بدون تغییر باقی می‌مانند.

![مقایسه نموداری که تمام ورودی‌های لگن قابل مشاهده هستند و ورودی سری ۲ از لگن مخفی شده است؛ تمام ستون‌ها قابل مشاهده می‌مانند.](hide-legend-entry.png)

در نمودارهای ستون، نوار و خط، ورودی‌های لگن سری‌ها را شناسایی می‌کنند. برای نمودارهای دایره‌ای، آن‌ها نقاط داده منفرد (برش‌ها) را شناسایی می‌کنند، بنابراین به جای آن از [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) بر روی برش انتخابی استفاده کنید. API این متد نقطه‌داده را برای انواع نمودار `Pie`، `Pie3D`، `ExplodedPie`، `ExplodedPie3D`، `PieOfPie` و `BarOfPie` مستند کرده است. فرض نکنید که برای نمودارهای دونات نیز صادق است، زیرا در آن فهرست گنجانده نشده‌اند.

## **سؤالات متداول**

**آیا می‌توانم نمودار را طوری تنظیم کنم که برای لگن فضایی اختصاص دهد به جای پوشاندن آن؟**  
بله. با `false` متد [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) را فراخوانی کنید تا به جای اجازه به هم‌پوشانی با منطقه نمودار، فضای مورد نیاز برای لگن رزرو شود.

**آیا می‌توانم برچسب‌های لگن چندخطی داشته باشم؟**  
بله. برچسب‌های طولانی می‌توانند وقتی عرض موجود کافی نیست به چند خط تقسیم شوند. همچنین می‌توانید از کاراکترهای خط جدید در نام‌های سری برای درخواست شکست خط استفاده کنید.

**چگونه می‌توانم لگن را به طرح رنگی قالب ارائه پیروی کنم؟**  
رنگ‌ها، پرکننده‌ها و قلم‌های لگن را تنظیم نکنید تا بتواند قالب‌بندی قالب را به ارث ببرد. قالب‌بندی صریح تنظیمات مربوط به قالب را نقض می‌کند.