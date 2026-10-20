---
title: راه‌حل عملی برای تغییر اندازه نمودار در PPTX
type: docs
weight: 40
url: /fa/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغییر اندازه نمودار
- نمودار اکسل
- شیء OLE
- جاسازی نمودار
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "رفع تغییر اندازه ناخواسته نمودار در PPTX هنگام استفاده از اشیاء OLE اکسل جاسازی‌شده با Aspose.Slides برای Node.js از طریق Java. تنظیم ابعاد ثابت نمودار برای حفظ سازگاری اندازه‌های نمودار و فریم OLE."
---
## **نمای کلی**

نمودارهای اکسل که به‌عنوان شیء OLE در ارائه‌های PowerPoint با استفاده از اجزای Aspose جاسازی می‌شوند، ممکن است پس از اولین فعال‌سازی اندازه خود را تغییر دهند. این می‌تواند تفاوت قابل‌توجهی در ظاهر نمودار قبل و بعد از فعال‌سازی ایجاد کند. این مقاله توضیح می‌دهد چرا تغییر اندازه رخ می‌دهد و نشان می‌دهد چگونه با تطبیق ابعاد ثابت نمودار با فریم OLE از آن جلوگیری کنیم.

در [ایجاد نمودارهای اکسل و جاسازی آن‌ها به‌عنوان شیء OLE در ارائه‌ها](/slides/fa/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، نحوه ایجاد یک نمودار اکسل با Aspose.Cells برای Node.js از طریق Java و جاسازی آن در یک ارائه PowerPoint با استفاده از Aspose.Slides برای Node.js از طریق Java را توضیح دادیم. برای رفع [مسأله پیش‌نمایش شیء](/slides/fa/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)، تصویر نمودار را به فریم شیء OLE نمودار اختصاص دادیم. در ارائه خروجی، زمانی که فریم شیء OLE که تصویر نمودار را نمایش می‌دهد را دو بار کلیک می‌کنید، نمودار اکسل فعال می‌شود. کاربران می‌توانند کتاب‌کار اکسل جاسازی‌شده را ویرایش کنند و سپس با کلیک خارج از کتاب‌کار فعال، به اسلاید بازگردند. اندازه فریم شیء OLE هنگام بازگشت کاربر به اسلاید تغییر می‌کند و عامل تغییر اندازه بسته به اندازه‌های اولیه هر دو فریم شیء OLE و کتاب‌کار اکسل جاسازی‌شده متفاوت است.

## **دلیل تغییر اندازه**

کتاب‌کار اکسل جاسازی‌شده ابعاد پنجره خود را دارد که اکسل سعی می‌کند هنگام اولین فعال‌سازی شیء آن را حفظ کند. فریم OLE روی اسلاید ابعاد جداگانه‌ای دارد. وقتی کتاب‌کار اکسل فعال می‌شود، اکسل و PowerPoint برای حفظ نسبت‌ها اندازه شیء را مورد مذاکره قرار می‌دهند که بخشی از فرآیند جاسازی است. اختلاف بین پنجره کتاب‌کار و فریم OLE می‌تواند منجر به تغییر اندازه شیء شود.

## **راه‌حل عملی**

اندازۀ نمودار را با فریم OLE روی اسلاید هماهنگ کنید و ابعاد نمودار را مستقل از پنجره کتاب‌کار نگه دارید. این راه‌حل برای یک ارائه جدید یا یک قالب موجود کار می‌کند.

این مثال به Aspose.Cells برای Node.js از طریق Java و Aspose.Slides برای Node.js از طریق Java نیاز دارد. بسته‌های Node.js `aspose.cells`، `aspose.slides.via.java` و `java` را نصب کنید. دو اسکریپت CommonJS زیر را در فرآیندهای جداگانه Node.js اجرا کنید و از همان پوشه کاری استفاده کنید، زیرا هر دو بسته Aspose هنگام بارگذاری پل Java را مقداردهی می‌کنند. این مثال یک نمودار ستونی ساده بر روی یک برگه نمودار فعال ایجاد می‌کند و کتاب‌کار را در قالب XLS جاسازی می‌کند. هیچ تصویر پیش‌نمایش نموداری اختصاص داده نمی‌شود؛ نمودار زمانی که شیء OLE در PowerPoint فعال می‌شود، نمایان می‌شود.

این مثال یک ارائه جدید با فریم OLE به اندازه 9.5 × 4 اینچ ایجاد می‌کند که 0.5 اینچ از لبه چپ و 1 اینچ از بالا قرار دارد. مختصات و ابعاد اسلاید بر حسب پوینت (72 پوینت در هر اینچ) هستند. برای یک ارائه موجود، به [استفاده از قالب](#use-a-template) مراجعه کنید.

## **تنظیم اندازه ثابت نمودار**

مقدار [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) را روی false تنظیم کنید تا ابعاد نمودار مستقل از پنجره کتاب‌کار باشد. ابعاد را از طریق [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) با استفاده از [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) و [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight) تنظیم کنید و پوینت‌ها را با 96 پیکسل در هر اینچ به پیکسل تبدیل کنید: فریمی با اندازه 684 × 288 پوینت معادل نموداری با اندازه 912 × 384 پیکسل است. [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) را روی مقدار CUSTOM از `PrintSizeType` تنظیم کنید. مثال کتاب‌کار را با [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) جاسازی می‌کند و ارائه‌ای با فریم OLE به اندازه 9.5 × 4 اینچ ذخیره می‌کند.

این اسکریپت اول را به‌عنوان `create-fixed-chart.js` ذخیره کنید. این اسکریپت فایلی به نام `chart-fixed-size.xls` ایجاد می‌کند که شامل نموداری با اندازه 912 × 384 پیکسل است و با فریم 684 × 288 پوینت استفاده‌شده توسط اسکریپت دوم هماهنگ است. نیازی به کتاب‌کار ورودی نیست.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // با ابعاد فریم OLE در پوینت (هر اینچ 72 پوینت) مطابقت دهید.
    const width = 684; // 9.5 اینچ.
    const height = 288; // 4 اینچ.

    chart.setSizeWithWindow(false);
    // تبدیل پوینت‌ها به پیکسل‌های نمودار با استفاده از 96 پیکسل در هر اینچ.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// تمام کارهای همزمان تکمیل شد؛ فرآیند پل جاوا را متوقف کنید.
process.exit(0);
```

اسکریپت دوم را به‌عنوان `embed-fixed-chart.js` ذخیره کنید و پس از اجرای `create-fixed-chart.js` آن را اجرا کنید. این اسکریپت کتاب‌کار XLS تولید شده را می‌خواند و `chart-fixed-size.pptx` را ذخیره می‌کند. پل Java برای داده‌های کتاب‌کار به یک آرایه بایت جاوا صریح و برای مختصات و ابعاد فریم به مقادیر float جاوا نیاز دارد. پسوند `xls` با فرمت ذخیره‌شده کتاب‌کار مطابقت دارد.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // مختصات و ابعاد اسلاید بر حسب پوینت است (هر اینچ 72 پوینت).
    const width = 684; // 9.5 اینچ.
    const height = 288; // 4 اینچ.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// تمام کارهای همزمان تمام شد؛ فرآیند پل جاوا را متوقف کنید.
process.exit(0);
```

## **استفاده از قالب**

منطق اندازه‌گیری برای یک ارائه موجود نیز یکسان است. برای تطبیق مثال:

1. به جای ایجاد یک ارائه خالی، ارائه قالب را بارگذاری کنید.
1. اطمینان حاصل کنید که اسلاید اول حداقل سه شکل دارد، سپس شکل با ایندکس 2 را به‌عنوان جای‌نگهدار استفاده کنید.
1. عرض و ارتفاع فریم را از آن شکل بگیرید به‌جای استفاده از مقادیر ثابت 684 و 288. همین ابعاد را در اسکریپت ایجاد کتاب‌کار استفاده کنید، محاسبات اندازه‌گیری را بدون تغییر نگه‌دارید و قبل از جاسازی کتاب‌کار XLS را بازسازی کنید.
1. فریم OLE را در موقعیت جای‌نگهدار اضافه کنید به‌جای مختصات ثابت 36 و 72.
1. قبل از ذخیرهٔ ارائه، جای‌نگهدار را حذف کنید.

## **سوالات متداول**

**چرا نمودار اکسل جاسازی‌شده من پس از فعال‌سازی در PowerPoint اندازه‌اش را تغییر می‌دهد؟**

این رخ می‌دهد زیرا اکسل سعی می‌کند هنگام اولین فعال‌سازی اندازهٔ اصلی پنجره را بازگرداند، در حالی که فریم شیء OLE در PowerPoint ابعاد مخصوص به خود را دارد. PowerPoint و اکسل برای حفظ نسبت عرض به ارتفاع اندازه را مورد مذاکره قرار می‌دهند که می‌تواند منجر به تغییر اندازه شود.

**چگونه می‌توانم اندازه‌های نمودار و فریم OLE را سازگار نگه دارم؟**

ابعاد ثابت نمودار را تنظیم کنید تا با فریم OLE مطابقت داشته باشد و قبل از جاسازی کتاب‌کار از اندازه چاپ سفارشی نمودار استفاده کنید. مثال بالا تنظیمات مورد نیاز و تبدیل واحدها را نشان می‌دهد.

**آیا مطابقت دادن اندازهٔ پنجره کتاب‌کار کافی است؟**

تنها مطابقت دادن اندازهٔ پنجره کتاب‌کار به‌طور قابل‌اطمینانی مانع تغییر اندازه فریم OLE پس از فعال‌سازی نمی‌شود. همان‌طور که در مثال نشان داده شده، از ابعاد ثابت نمودار استفاده کنید.

**آیا این راه‌حل برای ارائه‌های مبتنی بر قالب و ارائه‌های جدید کار می‌کند؟**

بله. برای یک قالب، از ابعاد و موقعیت جای‌نگهدار استفاده کنید. برای یک ارائه جدید، مستقیماً ابعاد و موقعیت فریم را مشخص کنید.

**آیا می‌توانم از این مثال با نمودارهای ایجادشده در برنامه‌های صفحه‌گسترده دیگر استفاده کنم؟**

این مثال از کتاب‌کار اکسل ایجادشده با Aspose.Cells استفاده می‌کند. رفتار فعال‌سازی برای برنامه‌های صفحه‌گسترده دیگر نشان داده نشده است.

## **بخش‌های مرتبط**

- [ایجاد نمودارهای اکسل و جاسازی آن‌ها به‌عنوان شیء OLE در ارائه‌ها](/slides/fa/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)