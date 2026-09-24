---
title: "سفارشی‌سازی جداول داده‌ای نمودار در ارائه‌ها با استفاده از جاوا اسکریپت"
linktitle: "جدول داده‌ای"
type: docs
url: /fa/nodejs-java/chart-data-table/
keywords:
- "داده‌های نمودار"
- "جدول داده"
- "ویژگی‌های فونت"
- "PowerPoint"
- "ارائه"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "فونت‌ها، حاشیه‌ها و کلیدهای راهنمایی جداول داده‌ای نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Node.js از طریق Java سفارشی کنید."
---
## **بررسی کلی**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد جدول داده‌های یک نمودار را نمایش داده و قالب‌بندی متن، حاشیه‌ها و کلیدهای راهنمایی را سفارشی کنید. این مقاله نحوه فعال کردن جدول، قالب‌بندی متن، کنترل هر نوع حاشیه و نمایش یا مخفی‌سازی کلیدهای راهنمایی را توضیح می‌دهد. مثال‌ها نمودارهای پیکربندی‌شده را در فایل‌های PPTX ذخیره می‌کنند.

## **تنظیم ویژگی‌های فونت**

برای نمایش جدول داده‌های یک نمودار، مقدار `true` را به [setDataTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/setdatatable/) پاس دهید. برای دسترسی به جدول و پیکربندی قالب‌بندی متن از [getChartDataTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/getchartdatatable/) استفاده کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری کنید.  
1. یک نمودار ستونی خوشه‌ای به اولین اسلاید اضافه کنید.  
1. جدول داده‌های نمودار را فعال کنید.  
1. با استفاده از [setFontBold](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setfontbold) متن پررنگ شود و مقدار `20` را به [setFontHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setfontheight) پاس دهید تا متن به اندازه 20 پوینت باشد.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به فایل `input.pptx` در مسیر کاری نیاز دارد که حداقل یک اسلاید داشته باشد. این مثال یک نمودار با داده‌های پیش‌فرض در موقعیت (50, 50) با عرض 600 پوینت و ارتفاع 400 پوینت اضافه می‌کند. فایل `output.pptx` ذخیره‌شده شامل نمودار با جدول داده فعال و تنظیمات فونت مشخص‌شده است.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سفارشی‌سازی حاشیه‌های جدول داده‌ها**

جدول را با [Chart.setDataTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/setdatatable/) فعال کنید و از طریق [Chart.getChartDataTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/getchartdatatable/) به آن دسترسی پیدا کنید. می‌توانید سه نوع حاشیه را به طور مستقل کنترل کنید:

- [setBorderHorizontal](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datatable/setborderhorizontal/) حاشیه‌های افقی سلول‌ها را کنترل می‌کند.  
- [setBorderVertical](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datatable/setbordervertical/) حاشیه‌های عمودی سلول‌ها را کنترل می‌کند.  
- [setBorderOutline](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datatable/setborderoutline/) حاشیهٔ خارجی جدول را کنترل می‌کند.

برای نمایش حاشیه‌ها مقدار `true` را به هر متد پاس دهید یا برای مخفی‌سازی مقدار `false` بدهید. مثال زیر یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند، حاشیه‌های افقی و حاشیهٔ خارجی را نمایش می‌دهد و حاشیه‌های عمودی را مخفی می‌کند. این مثال نیازی به فایل ورودی ندارد. موقعیت و اندازهٔ نمودار به پوینت تعیین شده‌اند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مقایسهٔ زیر از همان داده‌های نمودار و تنظیمات کلید راهنمایی در چهار حالت مختلف استفاده می‌کند. با فعال بودن تمام حاشیه‌ها شروع می‌شود و در هر حالت باقی‌مانده یک نوع حاشیه غیرفعال می‌شود. حالت پایین‑چپ تنظیمات حاشیهٔ مثال را تطبیق می‌دهد.

![نمودارهای داده‌ای جدول با تمام حاشیه‌های فعال، بدون حاشیه افقی، بدون حاشیه عمودی و بدون حاشیه خارجی](data-table-borders.png)

## **نمایش یا مخفی‌سازی کلیدهای راهنمایی**

کلیدهای راهنمایی نشانگرهای رنگی کوچکی هستند که در کنار نام‌سری‌ها در جدول داده قرار می‌گیرند. آنها به خوانندگان کمک می‌کنند تا هر ردیف جدول را با یک سری نمودار مطابقت دهند. برای نمایش این نشانگرها مقدار `true` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datatable/setshowlegendkey/) پاس دهید یا برای مخفی‌سازی مقدار `false` بدهید.

راهنمای جداگانهٔ نمودار توسط [Chart.setLegend](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/setlegend/) کنترل می‌شود. این تنظیمات مستقل‌اند: مخفی‌سازی راهنمای جداگانه کلیدهای داخل جدول داده را مخفی نمی‌کند و مخفی‌سازی کلیدهای جدول راهنمای جداگانه را تحت تأثیر قرار نمی‌دهد.

مثال زیر یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده آن را فعال می‌سازد و کلیدهای راهنمایی را در داخل جدول نمایش می‌دهد در حالی که راهنمای جداگانه مخفی می‌شود. تمام حاشیه‌های جدول به‌صورت صریح فعال هستند. نیازی به ارائهٔ ورودی نیست. برای مخفی‌سازی فقط کلیدهای جدول، مقدار `false` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datatable/setshowlegendkey/) پاس دهید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مقایسهٔ زیر همان جدول را با کلیدهای راهنمایی فعال و غیرفعال نشان می‌دهد. تمام حاشیه‌ها فعال می‌مانند و راهنمای جداگانهٔ نمودار در هر دو حالت مخفی است.

![نمودارهای داده‌ای جدول با کلیدهای راهنمایی نمایش‌داده‌شده در سمت چپ و مخفی‌شده در سمت راست](data-table-legend-keys.png)

## **پرسش‌های متداول**

**آیا می‌توانم کلیدهای راهنمایی را در جدول دادهٔ یک نمودار نشان دهم؟**

بله. مقدار `true` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datatable/setshowlegendkey/) پاس دهید تا کلیدهای راهنمایی نمایش داده شوند یا مقدار `false` برای مخفی‌سازی.

**آیا جدول داده هنگام خروجی گرفتن ارائه به PDF، HTML یا تصویر حفظ می‌شود؟**

بله. Aspose.Slides جدول دادهٔ نمایش‌داده‌شده را به‌عنوان بخشی از اسلاید هنگام خروجی به [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/)، [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/) یا [images](/slides/fa/nodejs-java/convert-powerpoint-to-png/) رندر می‌کند.

**آیا می‌توانم با جدول‌های داده در نمودارهای بارگذاری‌شده از یک الگو کار کنم؟**

بله. برای یک نمودار بارگذاری‌شده از ارائه یا الگوی موجود، از [hasDataTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/hasdatatable/) و [setDataTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/setdatatable/) برای بررسی یا تغییر نمایش جدول داده استفاده کنید.

**چگونه می‌توانم نمودارهایی که جدول دادهٔ آنها فعال است پیدا کنم؟**

از اشکال موجود در هر اسلاید عبور کنید، نمودارها را شناسایی کنید و متد [hasDataTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/hasdatatable/) آنها را فراخوانی کنید. مقدار `true` نشان می‌دهد جدول داده فعال است.