---
title: راه‌حل عملی برای تغییر اندازه کاربرگ
type: docs
weight: 20
url: /fa/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- کاربرگ
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "رفع تغییر اندازه OLE در کاربرگ‌های اکسل در ارائه‌ها: دو روش برای حفظ سازگاری فریم‌های شی—مقیاس‌گذاری فریم یا صفحه—در قالب‌های PPT و PPTX."
---
{{% alert color="info" title="Note" %}}
کاربرگ‌های اکسل که به‌عنوان اشیای OLE در یک ارائه PowerPoint با استفاده از مؤلفه‌های Aspose جاسازی می‌شوند ممکن است پس از اولین فعال‌سازی به‌طور غیرمنتظره‌ای اندازه خود را تغییر دهند. این رفتار تفاوت بصری قابل‌توجهی بین شی OLE قبل و بعد از فعال‌سازی ایجاد می‌کند. این مقاله مسئله را توضیح می‌دهد و دو روش برای رفع آن بیان می‌کند.
{{% /alert %}}

## **پیش‌زمینه**

در مقاله [Manage OLE](/slides/fa/nodejs-java/manage-ole/)، ما توضیح دادیم چگونه یک فریم OLE را به یک ارائه PowerPoint با استفاده از Aspose.Slides برای Node.js از طریق Java اضافه کنیم. برای رفع [object preview issue](/slides/fa/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)، یک تصویر از ناحیه‌ی انتخاب شده‌ی کاربرگ را به فریم شی OLE اختصاص دادیم. در ارائه خروجی، وقتی فریم شی OLE که تصویر کاربرگ را نمایش می‌دهد را دوبار کلیک می‌کنید، کتاب‌کار اکسل فعال می‌شود. کاربران نهایی می‌توانند هر تغییر دلخواهی را در کتاب‌کار اکسل واقعی انجام دهند و سپس با کلیک خارج از کتاب‌کار فعال به اسلاید بازگردند. اندازه فریم شی OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. عامل تغییر اندازه بسته به اندازه فریم شی OLE و کتاب‌کار اکسل جاسازی‌شده متفاوت خواهد بود.

## **دلیل تغییر اندازه**

از آنجا که کتاب‌کار اکسل اندازهٔ پنجرهٔ خاص خود را دارد، سعی می‌کند اندازهٔ اصلی خود را هنگام اولین فعال‌سازی حفظ کند. از سوی دیگر، فریم شی OLE اندازهٔ خاص خود را دارد. بر اساس مایکروسافت، هنگامی که کتاب‌کار اکسل فعال می‌شود، اکسل و PowerPoint برای اطمینان از حفظ نسبت‌های درست در فرآیند جاسازی، اندازه را مذاکره می‌کنند. تغییر اندازه بر اساس تفاوت‌های بین اندازهٔ پنجرهٔ اکسل و اندازه و موقعیت فریم شی OLE رخ می‌دهد.

## **راه‌حل عملی**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس‌گذاری فریم OLE در ارائه PowerPoint به‌طوری که با ارتفاع و عرض کل ردیف‌ها و ستون‌های انتخاب‌شده مطابقت داشته باشد.
- ثابت نگه داشتن اندازهٔ فریم OLE و مقیاس‌گذاری ردیف‌ها و ستون‌های انتخاب‌شده به‌گونه‌ای که درون آن جای بگیرند.

### **مقیاس‌گذاری اندازهٔ فریم OLE**

این روش اندازهٔ فریم OLE را طوری تنظیم می‌کند که با ارتفاع و عرض کل ردیف‌ها و ستون‌های انتخاب‌شده در کاربرگ اکسل جاسازی‌شده مطابقت داشته باشد.

مثال یک کتاب‌کار اکسل موجود را بارگذاری می‌کند و اولین ۱۰ ردیف و ۱۳ ستون از کاربرگ اول آن را با استفاده از ایندکس‌های صفر‑پایه انتخاب می‌نماید. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) بازهٔ نمایش داده‌شده را تعریف می‌کند. پیش‌نمایش با ۹۶ DPI رندر می‌شود و ابعاد پیکسلی آن با استفاده از ۷۲ پوینت در هر اینچ به پوینت تبدیل می‌گردد. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) کتاب‌کار اصلاح‌شده را در یک فریم با آن ابعاد جاسازی می‌کند. پیش‌نمایش از طریق [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) اختصاص داده می‌شود تا جایگزین متن جای‌نگهدار «EMBEDDED OLE OBJECT» در ارائه ذخیره‌شده شود.

پکیج‌های `aspose.cells`، `aspose.slides.via.java` و `java` را نصب کنید و فایل `sample.xlsx` را در دایرکتوری کاری قرار دهید. برای هر روش، ابتدا اسکریپت آماده‌سازی را اجرا کنید، سپس اسکریپت جاسازی را در یک فرآیند جداگانهٔ Node.js در همان دایرکتوری اجرا کنید. دو پکیج Aspose پل جاوا را به‌صورت جداگانه راه‌اندازی می‌کنند.

این اسکریپت آماده‌سازی را با نام `prepare-frame-scaled.js` ذخیره کنید و با دستور `node prepare-frame-scaled.js` اجرا کنید. این اسکریپت `frame-scaled.xlsx` و `frame-scaled.png` را می‌نویسد.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// تمام کارهای همزمان تکمیل شد؛ فرآیند پل جاوا را متوقف کنید.
process.exit(0);
```

اسکریپت جاسازی را با نام `embed-frame-scaled.js` ذخیره کنید و با دستور `node embed-frame-scaled.js` اجرا کنید. این اسکریپت آن فایل‌ها را می‌خواند و `frame-scaled.pptx` را می‌نویسد.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// تمام کارهای همزمان تکمیل شد؛ فرآیند پل جاوا را متوقف کنید.
process.exit(0);
```

کمک‌کننده پیش‌نمایش [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) را روی بازهٔ انتخاب‌شده تنظیم می‌کند و حاشیه‌ها، سرصفحه‌ها و پاورقی‌ها را حذف می‌نماید. با فعال بودن [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea)، [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) بازه را به‌صورت تصویر PNG رندر می‌کند. این کمک‌کننده تصویر PNG را در فایلی برای استفاده در ارائه ذخیره می‌کند.

### **مقیاس‌گذاری اندازهٔ محدودهٔ سلول**

این روش ارتفاع ردیف‌های انتخاب‌شده و عرض ستون‌های انتخاب‌شده را طوری مقیاس می‌دهد که با یک اندازهٔ سفارشی فریم OLE مطابقت داشته باشد.

مثال یک کتاب‌کار اکسل موجود را بارگذاری می‌کند و اولین ۱۰ ردیف و ۱۳ ستون از کاربرگ اول آن را با ایندکس‌های صفر‑پایه انتخاب می‌نماید. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) بازهٔ نمایش داده‌شده را تعریف می‌کند و کمک‌کننده آن بازه را طوری مقیاس می‌دهد که در فریمی به‌عرض ۴۰۰ پوینت و ارتفاع ۱۰۰ پوینت جا بگیرد. پس از ذخیرهٔ کتاب‌کار اصلاح‌شده در یک فایل، [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) آن را با اندازهٔ مشخص جاسازی می‌کند. پیش‌نمایشی که با ۹۶ DPI رندر شده است از طریق [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) اختصاص داده می‌شود، به‌طوری که ارائه ذخیره‌شده سلول‌های انتخاب‌شده را به‌جای جای‌نگهدار پیش‌فرض نشان می‌دهد.

این اسکریپت آماده‌سازی را با نام `prepare-cells-scaled.js` ذخیره کنید و با دستور `node prepare-cells-scaled.js` اجرا کنید. این اسکریپت `cells-scaled.xlsx` و `cells-scaled.png` را می‌نویسد.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// All synchronous work is complete; stop the Java bridge process.
process.exit(cellsPrepared ? 0 : 1);
```

اسکریپت جاسازی را با نام `embed-cells-scaled.js` ذخیره کنید و با دستور `node embed-cells-scaled.js` اجرا کنید. این اسکریپت آن فایل‌ها را می‌خواند و `cells-scaled.pptx` را می‌نویسد.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// تمام کارهای همزمان تکمیل شد؛ فرآیند پل جاوا را متوقف کنید.
process.exit(0);
```

کمک‌کننده مقیاس‌گذاری نسبت‌های عرض و ارتفاع جداگانه‌ای برای بازهٔ انتخاب‌شده محاسبه می‌کند و عرض نسبی ستون‌ها و ارتفاع نسبی ردیف‌ها را حفظ می‌نماید. قبل از اعمال آن‌ها با [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) و [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch)، ابعاد محاسبه‌شده را از پوینت به اینچ تبدیل می‌کند. بازهٔ انتخاب‌شده باید عرض و ارتفاع غیرصفر داشته باشد.

این کمک‌کننده پیش‌نمایش بازهٔ تغییر‌اندازه‌یافته را با استفاده از [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) رندر می‌کند. این کمک‌کننده [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) را به آن بازه محدود می‌نماید، حاشیه‌ها، سرصفحه‌ها و پاورقی‌ها را حذف می‌کند و تصویر PNG را در فایلی ذخیره می‌کند.

## **نتیجه‌گیری**

{{% alert color="info" title="Note" %}}
دو روش برای رفع مشکل تغییر اندازه کاربرگ وجود دارد. روشی را که بهترین مطابقت را با نیازها و مورد استفادهٔ شما دارد، انتخاب کنید. هر دو روش به‌یک‌نحو کار می‌کنند، چه ارائه‌ها از یک الگو ساخته شده باشند و چه از ابتدا. علاوه بر این، در این راه‌حل هیچ محدودیتی برای اندازهٔ فریم شی OLE وجود ندارد.
{{% /alert %}}

## **سوالات متداول**

**چرا یک کاربرگ اکسل جاسازی‌شده هنگام اولین فعال‌سازی در PowerPoint اندازهٔ خود را تغییر می‌دهد؟**

این به این دلیل است که اکسل سعی می‌کند اندازهٔ پنجرهٔ اصلی خود را هنگام فعال‌سازی حفظ کند، در حالی که فریم شی OLE در PowerPoint ابعاد خاص خود را دارد. PowerPoint و اکسل برای حفظ نسبت طول‑عرض اندازه را مذاکره می‌کنند، که می‌تواند باعث تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به‌ طور کامل جلوگیری کرد؟**

بله. با مقیاس‌گذاری فریم OLE به‌گونه‌ای که با اندازهٔ محدودهٔ سلول‌های اکسل مطابقت داشته باشد یا مقیاس‌گذاری محدودهٔ سلول‌ها برای مناسب شدن با اندازهٔ دلخواه فریم OLE، می‌توانید از تغییر اندازهٔ ناخواسته جلوگیری کنید.

**کدام روش مقیاس‌گذاری را باید استفاده کنم، مقیاس‌گذاری فریم OLE یا مقیاس‌گذاری محدودهٔ سلول؟**

اگر می‌خواهید اندازهٔ اصلی ردیف‌ها و ستون‌های اکسل را حفظ کنید، **مقیاس‌گذاری فریم OLE** را انتخاب کنید. اگر نیاز به اندازهٔ ثابت برای فریم OLE در ارائه دارید، **مقیاس‌گذاری محدودهٔ سلول** را انتخاب کنید.

**آیا این راه‌حل‌ها اگر ارائه من بر پایه یک الگو باشد کار می‌کنند؟**

بله. هر دو راه‌حل برای ارائه‌های ساخته‌شده از الگوها و از ابتدا کار می‌کنند.

**آیا محدودیتی برای اندازهٔ فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟**

خیر. می‌توانید فریم شی OLE را به هر اندازه‌ای بسازید به‌شرطی که مقیاس را به‌درستی تنظیم کنید.

**آیا راهی برای جلوگیری از متن جای‌نگهدار «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**

بله. با گرفتن یک تصویر از محدودهٔ سلول هدف در اکسل و تنظیم آن به‌عنوان تصویر جای‌نگهدار فریم OLE، می‌توانید یک تصویر پیش‌نمایش سفارشی به‌جای جای‌نگهدار پیش‌فرض نمایش دهید.

## **مقالات مرتبط**

[ایجاد نمودار اکسل و جاسازی آن در یک ارائه به‌عنوان شی OLE](/slides/fa/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[به‌روزرسانی خودکار اشیای OLE با استفاده از یک افزودنی MS PowerPoint](/slides/fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)