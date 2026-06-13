---
title: سفارشی‌سازی افسانه‌های نمودار در ارائه‌ها با استفاده از JavaScript
linktitle: افسانه نمودار
type: docs
url: /fa/nodejs-java/chart-legend/
keywords:
- افسانه نمودار
- موقعیت افسانه
- اندازه قلم
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "افسانه‌های نمودار را با استفاده از JavaScript و Aspose.Slides برای Node.js سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی ویژهٔ افسانه بهینه‌سازی کنید."
---
## **بررسی اجمالی**

Aspose.Slides گزینه‌هایی برای سفارشی‌سازی افسانه‌های نمودار در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه یک افسانه را موقعیت‌دهی و اندازه‌دهی کرد، اندازهٔ قلم برای کل افسانه را تنظیم کرد، و قالب‌بندی را برای یک ورودی افسانهٔ منفرد اعمال کرد.

همچنین چند رفتار مرتبط در بخش سوالات متداول پوشش داده شده است، از جمله استفاده از حالت غیرپوشانشی تا ناحیهٔ نمودار برای افسانه فضا ایجاد کند، اجازه دادن به برچسب‌های طولانی افسانه برای بسته شدن یا استفاده از خطوط جدید، و اجازه دادن به ارث‌برداری قالب افسانه از تم ارائه زمانی که تنظیمات صریح متن و پرکننده اعمال نشده باشد.

## **موقعیت‌دهی افسانه**

برای تنظیم ویژگی‌های افسانه. لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
- مرجع اسلاید را دریافت کنید.
- افزودن یک نمودار به اسلاید.
- تنظیم ویژگی‌های افسانه.
- نوشتن ارائه به صورت فایل PPTX.

در مثال زیر، ما موقعیت و اندازهٔ افسانهٔ نمودار را تنظیم کرده‌ایم.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    // مرجع اسلاید را دریافت کنید
    var slide = pres.getSlides().get_Item(0);
    // یک نمودار ستونی خوشه‌ای به اسلاید اضافه کنید
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // تنظیم ویژگی‌های افسانه
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // نوشتن ارائه بر روی دیسک
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم اندازهٔ قلم افسانه**

Aspose.Slides for Node.js via Java به توسعه‌دهندگان امکان تنظیم اندازهٔ قلم افسانه را می‌دهد. لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
- نمودار پیش‌فرض را ایجاد کنید.
- اندازهٔ قلم را تنظیم کنید.
- مقدار حداقل محور را تنظیم کنید.
- مقدار حداکثر محور را تنظیم کنید.
- ارائه را روی دیسک بنویسید.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم اندازهٔ قلم افسانهٔ منفرد**

Aspose.Slides for Node.js via Java به توسعه‌دهندگان امکان تنظیم اندازهٔ قلم ورودی‌های منفرد افسانه را می‌دهد. لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
- نمودار پیش‌فرض را ایجاد کنید.
- به ورودی افسانه دسترسی پیدا کنید.
- اندازهٔ قلم را تنظیم کنید.
- مقدار حداقل محور را تنظیم کنید.
- مقدار حداکثر محور را تنظیم کنید.
- ارائه را روی دیسک بنویسید.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا می‌توانم افسانه را فعال کنم تا نمودار به‌طور خودکار برای آن فضا اختصاص دهد به‌جای پوشاندن آن؟**

بله. از حالت غیرپوشانشی ([setOverlay(false)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/legend/setoverlay/)) استفاده کنید؛ در این حالت، ناحیهٔ نمودار برای جا دادن افسانه کوچک می‌شود.

**آیا می‌توانم برچسب‌های افسانه چندخطی ایجاد کنم؟**

بله. برچسب‌های طولانی به‌صورت خودکار زمانی که فضا کافی نباشد بسته می‌شوند؛ شکستن خط اجباری نیز از طریق کاراکترهای خط جدید در نام سری پشتیبانی می‌شود.

**چگونه می‌توانم افسانه را طوری تنظیم کنم که از طرح رنگی تم ارائه پیروی کند؟**

رنگ‌ها/پرکننده‌ها/قلم‌های صریح برای افسانه یا متن آن را تنظیم نکنید. سپس آن‌ها از تم ارث‌برداری می‌کنند و هنگام تغییر طرح به‌درستی به‌روزرسانی می‌شوند.