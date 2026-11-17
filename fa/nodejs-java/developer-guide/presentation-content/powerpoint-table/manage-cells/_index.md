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
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت سلول‌های جدول PowerPoint در JavaScript: شناسایی سلول‌های ترکیب‌شده، حذف حاشیه‌ها، تقسیم سلول‌ها، و تنظیم رنگ پس‌زمینه و تصاویر با Aspose.Slides برای Node.js از طریق Java."
---
## **نمای کلی**

Aspose.Slides به شما امکان دسترسی و اصلاح سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ترکیب‌شده را شناسایی کنید، مرزهای سلول را حذف کنید، پس از ترکیب یا تقسیم سلول‌ها با شماره‌گذاری سلول کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و یک تصویر را داخل یک سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه‌ی اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

Aspose.Slides از ایندکس‌های صفر‑پایه برای دسترسی به سلول‌های جدول به ترتیب `(column, row)` استفاده می‌کند.

## **شناسایی یک سلول جدول ترکیب‌شده**

مثال یک ارائه موجود را باز می‌کند و اولین شکل روی اولین اسلاید را به‌عنوان جدول دسترسی می‌یابد. فرض می‌شود اسلاید و شکل وجود دارند و شکل یک جدول است. سپس بر تمام ردیف‌ها و ستون‌ها پیمایش می‌کند و از [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) برای شناسایی سلول‌های در نواحی ترکیب‌شده استفاده می‌کند. برای هر تطابق، مختصات سلول را به ترتیب `row;column` چاپ می‌کند، [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)، [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)، و مختصات شروع ناحیه، [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) و [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) را نمایش می‌دهد.

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

مثال یک [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد می‌کند و یک جدول را به اولین اسلاید آن با [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) اضافه می‌نماید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول بر حسب پوینت مشخص می‌شوند. این مثال تمام چارچوب حاشیه سلول را به [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

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

## **افزودن حاشیه‌های مورب به سلول**

از [getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/) برای رسم خطی از گوشه بالا‑چپ به پایین‑راست و از [getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/) برای رسم خطی از گوشه پایین‑چپ به بالا‑راست استفاده کنید. یک خط مورب می‌تواند سربرگ گوشه‌ای باشد؛ هر دو خط مورب می‌توانند یک X را برای نشان‌دادن سلول غیرقابل‌استفاده تشکیل دهند.

هر مورب یک [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) است. در [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) آن، از [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) برای انتخاب [FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) استفاده کنید و رنگ را از طریق [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) انتخاب کنید. با [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) عرض خط را بر حسب پوینت تنظیم کنید.

این مثال سه سلول در یک ردیف ایجاد می‌کند: یک مورب نزولی قرمز، یک مورب صعودی آبی، و هر دو مورب. حاشیه‌های بالا، پایین، چپ و راست سلول دست نخورده می‌مانند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

یک مورب یک ویژگی قالب‌بندی است، نه تقسیم سلول. هر سلول یک فریم متن واحد دارد که از طریق [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/) دسترسی می‌شود؛ نواحی هر دو طرف یک مورب نمی‌تواند به‌صورت مستقل ویرایش شود.

![سه سلول جدول که یک خط مورب قرمز از بالا‑چپ به پایین‑راست، یک خط مورب آبی از پایین‑چپ به بالا‑راست، و هر دو مورب تشکیل یک X را نشان می‌دهند.](diagonal-cell-borders.png)

*از چپ به راست: مورب نزولی (قرمز، ۳ پوینت)، مورب صعودی (آبی، ۵ پوینت) و هر دو مورب.*

## **ادغام سلول‌های جدول**

از [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) برای ترکیب یک بازه مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشه بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی کنترل می‌کند که آیا ادغام می‌تواند شامل سلول‌های خارج از بازه مشخص شده باشد؛ `false` ادغام را در همان بازه نگه می‌دارد.

این مثال جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰ پوینت ایجاد می‌کند، سپس چهار سلول مرکزی از `(1, 1)` تا `(2, 2)` را ادغام می‌کند. سلول حاصل دو ستون و دو ردیف را در بر می‌گیرد، در حالی که شبکهٔ زیرین جدول چهار ستون و چهار ردیف را حفظ می‌کند. برای دسترسی به محتوای یا قالب‌بندی سلول ترکیب‌شده، از موقعیت بالا‑چپ آن استفاده کنید: `table.get_Item(1, 1)` در این مثال. سایر موقعیت‌های در بازه ترکیب‌شده همچنان بخشی از شبکه جدول باقی می‌مانند، بنابراین ایندکس‌های سلول‌های خارج از بازه تغییر نمی‌کند.

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

ادغام سلول‌ها در مثال قبلی ساختار شبکه جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون شبکه جدید ایجاد کند و ایندکس‌های ستون سلول‌های سمت راست آن را تغییر دهد. Aspose.Slides مدل شبکه جدول PowerPoint را دنبال می‌کند.

این مثال جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰ پوینت ایجاد می‌کند و بر روی سلول `(1, 1)` از [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) صدا می‌زند. نصف عرض ۷۰ پوینت سلول به‌عنوان مقدار برای ایجاد دو سلول با عرض برابر استفاده می‌شود.

پس از این تقسیم، دو نیمه به صورت `table.get_Item(1, 1)` و `table.get_Item(2, 1)` قابل دسترسی هستند. شبکه جدول اکنون پنج ستون دارد: سلول‌های اصلی در ستون‌های ۲ و ۳ به ستون‌های ۳ و ۴ منتقل می‌شوند. ایندکس‌های ردیف بدون تغییر می‌مانند. هنگام دسترسی به سلول‌ها پس از تقسیم، از این ایندکس‌های به‌روز شده استفاده کنید.

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

<!-- visual-explanation:manage-cells:start -->
[![یک سلول ۷۰ پوینت که ادغام نشده به دو سلول ۳۵ پوینت تقسیم می‌شود، ستون پنجم شبکه را اضافه می‌کند و ایندکس‌ها را به سمت راست جابه‌جا می‌کند.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*تقسیم عرض بر سلول (1, 1) تأثیر می‌گذارد و از ایندکس‌های صفر‑پایه (ستون، ردیف) استفاده می‌کند. سایر ردیف‌ها یک سلول دارند که هر دو موقعیت ستون جدید را پوشش می‌دهد.*
<!-- visual-explanation:manage-cells:end -->

### **تقسیم سلول‌های ترکیب‌شده بر اساس ردیف یا ستون**

برای آماده‌سازی سلول‌های قالب ترکیب‌شده برای پرکردن داده‌ها، از [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) برای تقسیم بر اساس مرز ردیف موجود، یا [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) برای تقسیم بر اساس مرز ستون استفاده کنید.

آرگومان `index` ردیف‌ها را در قسمت بالایی یا ستون‌ها را در قسمت چپ تقسیم می‌شمارید؛ این مقدار نسبت به ناحیه ترکیب‌شده است:

- تقسیم ردیف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- تقسیم ستون: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

مثال انتظار دارد ارائه‌ای داشته باشد که جدول به‌عنوان اولین شکل در اولین اسلاید باشد، با ترکیب عمودی `(1, 2)` و `(1, 3)`. از موقعیت پایین شروع می‌کند و از [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) و [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) برای یافتن مبدأ استفاده می‌کند و هر دو بازه را بررسی می‌کند. سپس `splitByRowSpan(1)` ردیف‌های ۲ و ۳ را برای نام محصولات جدا می‌کند. برای ترکیب افقی دو ستونی، به‌جای آن از `splitByColSpan(1)` استفاده کنید.

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

        // سلول‌های حاصل پس از تقسیم را از جدول بازیابی کنید.
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

شبکه جدول و ایندکس‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را با مختصاتشان بازیابی کنید؛ در اینجا هر دو بازه Span برابر ۱ دارند و [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) `false` چاپ می‌کند. نواحی بزرگ‌تر می‌توانند پس از یک تقسیم همچنان جزئی ترکیب‌شده باقی بمانند.

متن اصلی و قالب‌بندی آن در سلول بالایی (یا چپ) باقی می‌ماند؛ سلول جدید خالی است اما قالب‌بندی سلول مانند پر، حاشیه‌ها و حاشیه داخلی را به ارث می‌برد. پس از تقسیم، سلول‌ها را پر کنید و هر قالب‌بندی متنی مورد نیاز را صریحاً تنظیم کنید.

ارائه ذخیره‌شده سلول‌های جداگانه «محصول A» و «محصول B» را با حفظ قالب‌بندی سلول قالب نشان می‌دهد. برای جزئیات به [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) مراجعه کنید.

### **تقسیم یک سلول با ارتفاع مشخص**

[splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/) ارتفاع بخش بالایی را بر حسب پوینت می‌گیرد. [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) تعداد ردیف‌های موجود در بخش بالایی را می‌گیرد. برای مرکز کردن یک سلول ۴۰ پوینت در ستون راست، ۴۰ را از ارتفاع واقعی سلول کم کنید و فضای باقی‌مانده را به‌صورت مساوی بالای و پایین آن تقسیم کنید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اولین تقسیم یک ردیف شبکه اضافه می‌کند و ۹۰ پوینت پایین را در سلول `(1, 1)` می‌گذارد. تقسیم دوم آن سلول را به یک سلول میانی ۴۰ پوینت و یک سلول پایینی ۵۰ پوینت تبدیل می‌کند. ستون راست اکنون سه سلول با ارتفاع‌های ۵۰، ۴۰ و ۵۰ پوینت از بالا به پایین دارد. سلول چپ تمام سه ردیف را پوشش می‌دهد و ارتفاع اصلی ۱۴۰ پوینت خود را حفظ می‌کند.

![سلول چپ تمام ارتفاع جدول را در کنار سه سلول با «Middle» در مرکز پوشش می‌دهد.](split-by-height.png)

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال جدول با ستون‌های ۱۵۰ پوینت و ردیف‌های ۵۰ پوینت ایجاد می‌کند. از [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) برای انتخاب پر کردن جامد استفاده می‌کند و رنگ بازگردانده‌شده توسط [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) را برای سلول `(2, 3)` که در ستون سوم و ردیف چهارم است، به قرمز تنظیم می‌کند.

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

تصویر ورودی را قبل از اجرای این مثال در پوشه کاری قرار دهید. تصویر را با [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) بارگیری می‌کند و با [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) به مجموعه تصویرهای ارائه اضافه می‌نماید. سپس تصویر را به پر کردن تصویری سلول `(0, 0)`، اولین سلول جدول، اختصاص می‌دهد.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) تصویر را برای پر کردن سلول کش می‌کند که ممکن است نسبت تصویر را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها بر حسب پوینت است. تصویر بارگیری‌شده پس از افزودن به ارائه در یک بلوک `finally` آزاد می‌شود.

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

## **FAQ**

**آیا می‌توانم ضخامت و سبک خطوط مختلف برای طرف‌های مختلف یک سلول تنظیم کنم؟**

بله. حاشیه‌های [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) دارای ویژگی‌های جداگانه هستند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد.

**چه اتفاقی برای تصویر می‌افتد اگر پس از تنظیم یک تصویر به عنوان پس‌زمینه سلول، اندازه ستون/ردیف را تغییر دهم؟**

رفتار بستگی به [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile) دارد. در حالت کشش، تصویر با سلول جدید سازگار می‌شود؛ در حالت کاشی، کاشی‌ها بازمحاسبه می‌شوند.

**آیا می‌توانم یک پیوند فراگیر به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/nodejs-java/manage-hyperlinks/) در سطح متن (قسمت) داخل فریم متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک قسمت یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی را در یک سلول واحد تنظیم کنم؟**

بله. فریم متن یک سلول از [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل پشتیبانی می‌کند—خانوادهٔ قلم، سبک، اندازه و رنگ.