---
title: ایجاد نمودارهای Excel و جاسازی آن‌ها در ارائه‌ها به عنوان اشیاء OLE
type: docs
weight: 30
url: /fa/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- نمودار Excel
- جاسازی نمودار
- شیء OLE
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یک نمودار Excel را با Aspose.Cells for Node.js از طریق Java ایجاد کنید و دفتر کار را در یک ارائه PowerPoint با Aspose.Slides جاسازی کنید، به‌همراه پیش‌نمایش نمودار."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه یک نمودار ستونی Excel را با Aspose.Cells for Node.js از طریق Java ایجاد کرده و دفتر کاری آن را در یک ارائه PowerPoint با Aspose.Slides for Node.js از طریق Java جاسازی کنیم. دفتر کار جاسازی‌شده شامل داده‌های منبع و نمودار است. یک پیش‌نمایش PNG جداگانه نمودار را بر روی اسلاید قبل از فعال شدن شی OLE نمایش می‌دهد.

نتیجه یک شیء Excel جاسازی‌شده است، نه یک نمودار بومی PowerPoint. ویرایش دفتر کار از طریق OLE نیاز به یک برنامه دسکتاپ دارد که از فعال‌سازی OLE پشتیبانی کند و نصب Excel سازگار داشته باشد.

## **پیش‌نیازها**

پکیج‌های Node.js `aspose.cells`، `aspose.slides.via.java` و `java` را نصب کنید. مثال‌ها را به‌عنوان دو اسکریپت CommonJS در فرآیندهای جداگانه Node.js اجرا کنید: ابتدا `create-chart.js`، سپس `embed-chart.js`، در همان پوشه کاری. هر دو بسته Aspose در زمان بارگذاری پل Java را مقداردهی می‌کنند، بنابراین این مثال‌ها را در فرآیندهای جداگانه نگه می‌دارند. برای تولید ارائه با این کتابخانه‌ها نیازی به Microsoft Office نیست.

هیچ دفتر کار یا تصویری از پیش موجود نیازی نیست. اسکریپت اول `ChartWorkbook.xlsx` و `ChartPreview.png` را ایجاد می‌کند؛ اسکریپت دوم این فایل‌ها را می‌خواند و `OutputChart.pptx` را در پوشه کاری فعلی می‌نویسد. هنگام اجرای خارج از حالت ارزیابی، برای هر دو محصول لایسنس اعمال کنید.

## **نحوه کار جاسازی**

1. یک دفتر کار با یک ورق داده و یک ورق نمودار ایجاد کنید.
1. ورق نمودار را فعال کنید تا دفتر کار بر روی نمودار باز شود.
1. محدوده نمایش OLE دفتر کار را تنظیم کنید و نمودار را به PNG رندر کنید.
1. دفتر کار را به صورت XLSX ذخیره کنید و بایت‌های آن را در یک اسلاید در یک فرآیند Node.js جداگانه جاسازی کنید.
1. PNG را به‌عنوان پیش‌نمایش شیء OLE اختصاص دهید و ارائه را به صورت PPTX ذخیره کنید.

محدوده نمایش دفتر کار و قاب اسلاید نقش‌های متفاوتی دارند. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) اندیس‌های ردیف/ستون آغاز/پایان را به‌صورت صفرمبنای دریافت می‌کند. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) به‌جای آن ردیف بالا، ستون چپ، ردیف پایین و ستون راست را می‌گیرد. مثال از اندیس ردیف 55 و اندیس ستون 25 به‌عنوان مرزهای پایین‑راست استفاده می‌کند؛ این مقادیر انتخاب طرح‌بندی هستند، نه تعداد ردیف‌ها یا ستون‌های داده.

قاب اسلاید از واحد نقطه استفاده می‌کند. مثال این قاب را در داخل اسلاید می‌چیند و وسط‌چین می‌کند در حالی که نسبت عرض‑به‑ارتفاع PNG را حفظ می‌کند، نه اینکه پیش‌نمایش را برای پر کردن اسلاید کشیده کند.

## **ایجاد و جاسازی نمودار**

اسکریپت اول را به نام `create-chart.js` ذخیره کنید. این اسکریپت `DataSheet` را با چهار ردیف و پنج ستون مقدار پر می‌کند. هر ردیف تبدیل به یک سری نمودار می‌شود. `ChartSheet` قبل از ذخیره دفتر کار به عنوان ورق فعال انتخاب می‌شود.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // پیشنمایش نمودار را رندر کنید و دفتر کار قابل ویرایش را به‌صورت جداگانه سریالایز کنید.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// تمام کارهای همزمان تکمیل شد؛ فرآیند پل جاوا را متوقف کنید.
process.exit(0);
```

اسکریپت زیر را به نام `embed-chart.js` ذخیره کنید. پس از آنکه `create-chart.js` هر دو فایل ورودی را ایجاد کرد، آن را اجرا کنید. این اسکریپت قاب OLE را وسط‌چین می‌کند و نسبت عرض‑به‑ارتفاع تصویر پیش‌نمایش را حفظ می‌کند.

اسکریپت دوم دفتر کار ذخیره‌شده را جاسازی می‌کند و از PNG به‌عنوان پیش‌نمایش استفاده می‌نماید. دفتر کار صراحتاً به‌صورت XLSX ذخیره می‌شود که با پسوند `xlsx` که به [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/) پاس داده می‌شود، مطابقت دارد. PNG مستقیماً از بایت‌هایش بارگذاری می‌شود بدون تبدیل به bitmap میانی. پل Java برای داده‌های تصویر و دفتر کار به آرایه‌های بایت Java و برای مختصات قاب اسلاید به مقادیر float Java نیاز دارد. اختصاص آن از طریق [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) جایگزین پیش‌فرض OLE می‌شود.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // پیش‌نمایش را در داخل اسلاید بدون تغییر نسبت عرض‑به‑ارتفاع آن قرار دهید.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// تمام کارهای همزمان تکمیل شد؛ فرآیند پل جاوا را متوقف کنید.
process.exit(0);
```

## **نتیجهٔ مورد انتظار**

`OutputChart.pptx` شامل یک اسلاید با یک دفتر کار Excel جاسازی‌شده و یک پیش‌نمایش نمودار است. دفتر کار شامل داده‌های اصلی و یک نمودار ستونی با چهار سری است. پیش‌نمایش در وسط اسلاید قرار گرفته و نسبت‌های خود را حفظ کرده است.

![نمودار ستونی Excel که به‌عنوان پیش‌نمایش یک دفتر کار جاسازی‌شده نمایش داده می‌شود](excel-chart-ole-preview.png)

در یک محیط دسکتاپ PowerPoint سازگار که Excel در دسترس باشد، به‌دوبار کلیک روی شیء برای فعال‌سازی و ویرایش دفتر کار جاسازی‌شده. فعال‌سازی و ویرایش بسته به پشتیبانی OLE برنامه میزبان و تنظیمات امنیتی آن است.

## **سؤالات متداول**

**چرا نیاز به تصویر پیش‌نمایش است؟**

دفتر کار جاسازی‌شده و پیش‌نمایش اسلاید آن محتوای جداگانه‌ای هستند. یک تصویر نمودار ارائه دهید تا اسلاید به‌جای جای‌دار پیش‌فرض «EMBEDDED OLE OBJECT» نمودار را نشان دهد. به [مشکل پیش‌نمایش شیء هنگام افزودن OleObjectFrame](/slides/fa/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) مراجعه کنید.

**آیا پیش‌نمایش به‌صورت خودکار هنگام تغییر دفتر کار در کد به‌روزرسانی می‌شود؟**

پیش‌نمایش را به‌عنوان یک تصویر ثابت در نظر بگیرید. هنگام به‌روزرسانی داده‌های دفتر کار به‌صورت برنامه‌نویسی، تصویر نمودار را دوباره تولید کنید و هم پیش‌نمایش و هم داده‌های دفتر کار جاسازی‌شده را جایگزین کنید.

**آیا می‌توان به‌جای XLSX از XLS استفاده کرد؟**

بله. دفتر کار را در قالب XLS ذخیره کنید و از `xls` به‌عنوان پسوند داده جاسازی‌شده استفاده کنید. پسوند باید با قالب واقعی دفتر کار مطابقت داشته باشد؛ تغییر فقط پسوند داده را تبدیل نمی‌کند.

**چرا ممکن است شیء پس از فعال‌سازی اندازه‌اش تغییر کند؟**

برنامه میزبان می‌تواند ارائهٔ شیء OLE را هنگام فعال‌سازی دفتر کار به‌روز کند. محدوده نمایش OLE دفتر کار و ابعاد قاب اسلاید هر دو مهم هستند. به [راه‌حل کاری برای تغییر اندازهٔ نمودار در PPTX](/slides/fa/java/working-solution-for-chart-resizing-in-pptx/) مراجعه کنید.

## **بخش‌های مرتبط**

- [راه‌حل کاری برای تغییر اندازهٔ نمودار در PPTX](/slides/fa/java/working-solution-for-chart-resizing-in-pptx/)
- [مشکل پیش‌نمایش شیء هنگام افزودن OleObjectFrame](/slides/fa/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)