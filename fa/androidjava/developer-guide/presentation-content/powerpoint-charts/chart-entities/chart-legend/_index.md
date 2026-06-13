---
title: سفارشی‌سازی راهنمای نمودارها در ارائه‌ها در اندروید
linktitle: راهنمای نمودار
type: docs
url: /fa/androidjava/chart-legend/
keywords:
- راهنمای نمودار
- موقعیت راهنما
- اندازه قلم
- PowerPoint
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: راهنمای نمودارها را با Aspose.Slides برای اندروید از طریق جاوا سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی ویژهٔ راهنما بهینه کنید.
---
## **بررسی کلی**

Aspose.Slides گزینه‌هایی برای سفارشی‌سازی راهنمای نمودار در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه موقعیت و اندازه یک راهنما را تنظیم کنید، اندازه قلم را برای کل راهنما تعیین کنید، و قالب‌بندی را برای یک ورودی راهنمای جداگانه اعمال کنید.

همچنین چند رفتار مرتبط در بخش پرسش‌های متداول پوشش داده می‌شود، از جمله استفاده از حالت غیر هم‌پوشانی تا ناحیه‌نمودار برای راهنما جایی فراهم کند، اجازه دادن به برچسب‌های طولانی راهنما برای شکسته شدن یا استفاده از شکست خط، و اجازه دادن به ارث‌بری قالب راهنما از تم ارائه زمانی که تنظیمات صریح متن و پر کردن اعمال نشده باشند.

## **موقعیت‌گذاری راهنما**
In order to set the legend properties. Please follow the steps below:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
- مرجع اسلاید را به‌دست آورید.
- یک نمودار به اسلاید اضافه کنید.
- تنظیم ویژگی‌های راهنما.
- ارائه را به‌عنوان فایل PPTX ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // مرجع اسلاید را دریافت کنید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // یک نمودار ستونی گروهی به اسلاید اضافه کنید
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // تنظیم ویژگی‌های راهنما
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // ارائه را روی دیسک ذخیره کنید
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم اندازه قلم یک راهنما**
The Aspose.Slides for Android via Java lets developers allow to set font size of legend. Please follow the steps below: 

- نمونه‌سازی از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) انجام دهید.
- نمودار پیش‌فرض را ایجاد کنید.
- اندازه قلم را تنظیم کنید.
- حداقل مقدار محور را تنظیم کنید.
- حداکثر مقدار محور را تنظیم کنید.
- ارائه را روی دیسک ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم اندازه قلم یک ورودی راهنمای جداگانه**
The Aspose.Slides for Android via Java lets developers allow to set font size of individual legend entries. Please follow the steps below: 

- نمونه‌سازی از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) انجام دهید.
- نمودار پیش‌فرض را ایجاد کنید.
- به ورودی راهنما دسترسی پیدا کنید.
- اندازه قلم را تنظیم کنید.
- حداقل مقدار محور را تنظیم کنید.
- حداکثر مقدار محور را تنظیم کنید.
- ارائه را روی دیسک ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**آیا می‌توانم راهنما را فعال کنم طوری که نمودار به‌صورت خودکار برای آن فضا اختصاص دهد به‌جای هم‌پوشانی؟**

بله. از حالت غیر هم‌پوشانی استفاده کنید ([setOverlay(false)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); در این حالت ناحیهٔ نمودار کوچک می‌شود تا جا برای راهنما فراهم شود.

**آیا می‌توانم برچسب‌های راهنما چندخطی داشته باشم؟**

بله. برچسب‌های طولانی وقتی فضا کافی نیست به‌صورت خودکار شکسته می‌شوند؛ شکست خط اجباری با استفاده از کاراکترهای newline در نام سری پشتیبانی می‌شود.

**چگونه راهنما را به‌گونه‌ای تنظیم کنم که طرح رنگی تم ارائه را دنبال کند؟**

برای راهنما یا متن آن رنگ/پر/قلم صریح تنظیم نکنید. در این صورت آن‌ها از تم ارث می‌برند و هنگام تغییر طراحی به‌درستی به‌روز می‌شوند.