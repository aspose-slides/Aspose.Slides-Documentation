---
title: مدیریت سلول‌های جدول در ارائه‌ها با استفاده از JavaScript
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/nodejs-java/manage-cells/
keywords:
- سلول جدول
- ادغام سلول‌ها
- حذف حاشیه
- تقسیم سلول
- تصویر در سلول
- رنگ پس‌زمینه
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت سلول‌های جدول PowerPoint در JavaScript: شناسایی سلول‌های ادغام‌شده، حذف حاشیه‌ها، تقسیم سلول‌ها، و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای Node.js از طریق Java."
---
## **نمای کلی**

Aspose.Slides به شما امکان دسترسی و تغییر سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد که چگونه سلول‌های جدول ادغام‌شده را شناسایی کنید، حاشیه‌های سلول را حذف کنید، با شماره‌گذاری سلول پس از ادغام یا تقسیم سلول‌ها کار کنید، رنگ پس‌زمینه سلول را تغییر دهید و یک تصویر را داخل سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، یک جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه‌ی اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

Aspose.Slides از ایندکس‌های صفر‑پایه برای دسترسی به سلول‌های جدول به ترتیب `(ستون، سطر)` استفاده می‌کند.

## **شناسایی یک سلول جدول ادغام‌شده**

مثال یک ارائه موجود را باز می‌کند و اولین شکل را در اولین اسلاید به صورت جدول دسترسی می‌یابد. فرض می‌کند که اسلاید و شکل وجود دارند و شکل یک جدول است. سپس تمام سطرها و ستون‌ها را پیمایش می‌کند و از [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) برای شناسایی سلول‌های در نواحی ادغام‌شده استفاده می‌کند. برای هر تطابق، مختصات سلول را به ترتیب `row;column`، [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)، [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)، و مختصات شروع ناحیه، [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) و [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) چاپ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **حذف حاشیه‌های سلول جدول**

یک [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید و یک جدول را به اولین اسلاید آن با استفاده از [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) اضافه کنید. عرض ستون‌ها، ارتفاع سطرها و موقعیت جدول به پوینت مشخص می‌شوند. مثال تمام چهار حاشیه سلول را به [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ادغام سلول‌های جدول**

از [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) برای ترکیب یک بازه مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشه بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی تعیین می‌کند که آیا ادغام می‌تواند شامل سلول‌های خارج از بازه مشخص شده باشد یا نه؛ `false` ادغام را درون همان بازه نگه می‌دارد.

مثال یک جدول 4×4 با ستون‌ها و سطرهای 70 پوینت ایجاد می‌کند، سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ادغام می‌نماید. سلول حاصل دو ستون و دو سطر را پوشش می‌دهد، در حالی که شبکه‑ی پایه جدول همچنان چهار ستون و چهار سطر را نگه می‌دارد. برای دسترسی به محتوای یا قالب‌بندی سلول ادغام‌شده، موقعیت بالا‑چپ آن را استفاده کنید: `table.get_Item(1, 1)` در این مثال. سایر موقعیت‌های در بازه ادغام‌شده همچنان جزئی از شبکه جدول باقی می‌مانند، بنابراین ایندکس‌های سلول‌های خارج از بازه تغییر نمی‌کنند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تقسیم سلول‌های جدول**

ادغام سلول‌ها در مثال قبلی شبکه جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون جدید در شبکه ایجاد کند و ایندکس‌های ستون سلول‌های سمت راست آن را تغییر دهد. Aspose.Slides از مدل شبکه جدول PowerPoint پیروی می‌کند.

این مثال یک جدول 4×4 با ستون‌ها و سطرهای 70 پوینت ایجاد می‌کند و بر روی سلول `(1, 1)` متد [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) را فراخوانی می‌کند. نیمی از عرض 70 پوینت سلول برای ایجاد دو سلول با عرض مساوی استفاده می‌شود.

پس از این تقسیم، دو نیم به صورت `table.get_Item(1, 1)` و `table.get_Item(2, 1)` دسترسی پیدا می‌کنند. شبکه جدول اکنون پنج ستون دارد: سلول‌های اصلی در ستون‌های 2 و 3 به ستون‌های 3 و 4 منتقل می‌شوند. ایندکس‌های سطر بدون تغییر باقی می‌مانند. هنگام دسترسی به سلول‌ها پس از تقسیم، از این ایندکس‌های ستون به‌روز شده استفاده کنید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تقسیم سلول‌های ادغام‌شده بر اساس طول سطر یا ستون**

برای آماده‌سازی سلول‌های الگو ادغام‌شده برای پر کردن داده‌ها، از [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) برای تقسیم بر اساس مرز سطر موجود، یا از [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) برای تقسیم بر اساس مرز ستون استفاده کنید.

آرگومان `index` ردیف‌ها را در بخش بالایی یا ستون‌ها را در بخش چپ تقسیم می‌شمارد؛ این مقدار نسبت به ناحیه ادغام‌شده است:

- تقسیم سطر: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).  
- تقسیم ستون: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

مثال انتظار دارد که ارائه حاوی جدولی به عنوان اولین شکل در اولین اسلاید باشد، به طوری که سلول‌های `(1, 2)` و `(1, 3)` به صورت عمودی ادغام شده باشند. از موقعیت پایین شروع می‌کند و با استفاده از [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) و [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) مبدأ را پیدا کرده و هر دو طول را بررسی می‌کند. سپس `splitByRowSpan(1)` ردیف‌های 2 و 3 را برای نام‌های محصول جدا می‌کند. برای ادغام افقی دو ستونی، به جای آن از `splitByColSpan(1)` استفاده کنید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // سلول‌های حاصل‌شده را پس از تقسیم از جدول بازیابی کنید.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

شبکه جدول و ایندکس‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را با استفاده از مختصات آنها بازیابی کنید؛ در اینجا هر دو طول 1 دارند و [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) `false` را چاپ می‌کند. نواحی بزرگ‌تر می‌توانند پس از یک تقسیم به‌صورت جزئی ادغام باقی بمانند.

متن اصلی و قالب‌بندی‌ آن در سلول بالا (یا چپ) باقی می‌ماند؛ سلول جدید خالی است اما قالب‌بندی سلول مانند پرکن، حاشیه‌ها و حاشیه‌های داخلی را به ارث می‌برد. پس از تقسیم، سلول‌ها را پر کنید و هر قالب‌بندی متنی موردنیاز را به‌صورت صریح تنظیم کنید.

اطلاعات ذخیره‌شده ارائه شامل سلول‌های جداگانه «Product A» و «Product B» با حفظ قالب‌بندی سلول قالب است. برای جزئیات به [مرجع API سلول](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) مراجعه کنید.

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال یک جدول با ستون‌های 150 پوینت و سطرهای 50 پوینت ایجاد می‌کند. از [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) برای انتخاب پرکن جامد استفاده می‌کند و رنگ بازگشته از [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) را برای سلول `(2, 3)` (ستون سوم و ردیف چهارم) به رنگ قرمز تنظیم می‌نماید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن تصویر داخل یک سلول جدول**

قبل از اجرای این مثال، تصویر ورودی را در پوشه کاری قرار دهید. تصویر را با استفاده از [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) بارگذاری می‌کند و با [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) به مجموعه تصویرهای ارائه اضافه می‌نماید. سپس تصویر را به پرکن تصویر سلول `(0, 0)` که اولین سلول جدول است، اختصاص می‌دهد.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) تصویر را برای پر کردن سلول کش می‌کند که ممکن است نسبت تصویر را تغییر دهد. عرض ستون‌ها و ارتفاع سطرها بر حسب پوینت است. تصویر بارگذاری‌شده پس از افزودن به ارائه در یک بلوک `finally` آزاد (dispose) می‌شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم ضخامت و سبک خطوط مختلفی برای هر سمت یک سلول تنظیم کنم؟**

بله. حاشیه‌های [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) دارای خصوصیات جداگانه‌ای هستند، بنابراین ضخامت و سبک هر سمت می‌تواند متفاوت باشد.

**اگر پس از تنظیم یک تصویر به‌عنوان پس‌زمینه سلول، اندازه ستون/سطر را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار بستگی به [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) دارد. با کشیدن (stretch)، تصویر با سلول جدید سازگار می‌شود؛ با کاشی‌کاری (tile)، کاشی‌ها مجدداً محاسبه می‌شوند.

**آیا می‌توانم یک لینک به تمام محتوای یک سلول اختصاص دهم؟**

[پیوندها](/slides/fa/nodejs-java/manage-hyperlinks/) در سطح متن (بخش) داخل فریم متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، لینک را به یک بخش یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های مختلفی در یک سلول تنظیم کنم؟**

بله. فریم متن سلول از [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—خانواده فونت، سبک، اندازه و رنگ—پشتیبانی می‌کند.