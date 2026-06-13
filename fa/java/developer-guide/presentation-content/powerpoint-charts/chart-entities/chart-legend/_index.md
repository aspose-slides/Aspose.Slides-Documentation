---
title: سفارشی‌سازی افسانه‌های نمودار در ارائه‌ها با استفاده از Java
linktitle: افسانه نمودار
type: docs
url: /fa/java/chart-legend/
keywords:
- افسانه نمودار
- موقعیت افسانه
- اندازه قلم
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "افسانه‌های نمودار را با Aspose.Slides برای Java سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی مخصوص افسانه بهینه کنید."
---
## **مرور کلی**

Aspose.Slides گزینه‌هایی برای سفارشی‌سازی افسانه‌های نمودار در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه یک افسانه را موقعیت و اندازه‌گذاری کنید، اندازه قلم را برای کل افسانه تنظیم کنید و قالب‌بندی را برای یک ورودی افسانهٔ منفرد اعمال کنید.

همچنین رفتارهای مرتبطی در بخش سؤالات متداول پوشش داده می‌شود، از جمله استفاده از حالت بدون پوشش (non‑overlay) تا ناحیه نمودار برای افسانه جای باز کند، امکان بسته‌بندی یا استفاده از شکست خط برای برچسب‌های طولانی افسانه، و اجازهٔ ارث‌بری قالب افسانه از تم ارائه زمانی که تنظیمات صریح متن و پرکننده اعمال نشده باشند.

## **موقعیت افسانه**

برای تنظیم ویژگی‌های افسانه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
- مرجع اسلاید را دریافت کنید.
- افزودن یک نمودار به اسلاید.
- تنظیم ویژگی‌های افسانه.
- نوشتن ارائه به‌عنوان فایل PPTX.

در مثال زیر، موقعیت و اندازه افسانهٔ نمودار را تنظیم کرده‌ایم.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // مرجع اسلاید را دریافت کنید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // یک نمودار ستونی خوشه‌ای به اسلاید اضافه کنید
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // تنظیم ویژگی‌های افسانه
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // ارائه را بر روی دیسک ذخیره کنید
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم اندازه قلم افسانه**

Aspose.Slides for Java به توسعه‌دهندگان اجازه می‌دهد اندازه قلم افسانه را تنظیم کنند. لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
- نمودار پیش‌فرض را ایجاد کنید.
- اندازه قلم را تنظیم کنید.
- مقدار حداقل محور را تنظیم کنید.
- مقدار حداکثر محور را تنظیم کنید.
- ارائه را بر روی دیسک بنویسید.

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

## **تنظیم اندازه قلم افسانهٔ منفرد**

Aspose.Slides for Java به توسعه‌دهندگان اجازه می‌دهد اندازه قلم ورودی‌های منفرد افسانه را تنظیم کنند. لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
- نمودار پیش‌فرض را ایجاد کنید.
- به ورودی افسانه دسترسی پیدا کنید.
- اندازه قلم را تنظیم کنید.
- مقدار حداقل محور را تنظیم کنید.
- مقدار حداکثر محور را تنظیم کنید.
- ارائه را بر روی دیسک بنویسید.

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

**آیا می‌توانم افسانه را طوری فعال کنم که نمودار به‌صورت خودکار برای آن فضایی اختصاص دهد به‌جای اینکه روی هم قرار گیرد؟**

بله. از حالت بدون پوشش ([setOverlay(false)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/legend/#setOverlay-boolean-)) استفاده کنید؛ در این صورت ناحیه نمودار کوچک می‌شود تا جایی برای افسانه ایجاد شود.

**آیا می‌توانم برچسب‌های افسانه چند خطی داشته باشم؟**

بله. برچسب‌های طولانی به‌صورت خودکار بسته‌بندی می‌شوند وقتی فضا کافی نیست؛ شکست‌های خطی اجباری نیز از طریق کاراکترهای newline در نام سری پشتیبانی می‌شود.

**چگونه می‌توانم افسانه را برای پیروی از طرح رنگی تم ارائه تنظیم کنم؟**

رنگ‌ها/پرکننده‌ها/قلم‌های صریح را برای افسانه یا متن آن تنظیم نکنید. در این صورت آن‌ها از تم ارث می‌برند و هنگام تغییر طراحی به‌درستی به‌روز می‌شوند.