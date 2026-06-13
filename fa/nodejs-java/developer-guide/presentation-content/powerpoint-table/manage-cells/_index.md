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
description: "مدیریت سلول‌های جدول در PowerPoint با Aspose.Slides برای Node.js. دسترسی، اصلاح و استایل‌دار کردن سلول‌ها را به سرعت برای خودکارسازی روان اسلایدها فراگیرید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد سلول‌های جدول را در ارائه‌های PowerPoint دسترسی داشته باشید و آن‌ها را اصلاح کنید. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ادغام‌شده را شناسایی کنید، حاشیه‌های سلول را حذف کنید، با شماره‌گذاری سلول‌ها پس از ادغام یا تقسیم سلول‌ها کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و تصویر داخل یک سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

## **شناسایی سلول جدول ادغام‌شده**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. جدول را از اولین اسلاید دریافت کنید.  
3. از ردیف‌ها و ستون‌های جدول عبور کنید تا سلول‌های ادغام‌شده را پیدا کنید.  
4. هنگامی که سلول‌های ادغام‌شده یافت شدند، پیام چاپ کنید.

این کد JavaScript نشان می‌دهد چگونه سلول‌های جدول ادغام‌شده در یک ارائه شناسایی شوند:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// با فرض اینکه Slide#0.Shape#0 یک جدول است
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حذف حاشیه سلول‌های جدول**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک آرایه از ستون‌ها با عرض تعریف کنید.  
4. یک آرایه از ردیف‌ها با ارتفاع تعریف کنید.  
5. یک جدول را به اسلاید اضافه کنید با استفاده از متد [addTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) .  
6. از هر سلول عبور کنید تا حاشیه‌های بالا، پایین، راست و چپ را پاک کنید.  
7. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه حاشیه‌های سلول‌های جدول حذف شوند:

```javascript
// نمونه سازی کلاس Presentation که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // تعریف ستون‌ها با عرض و ردیف‌ها با ارتفاع
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // افزودن شکل جدول به اسلاید
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // تنظیم فرمت حاشیه برای هر سلول
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // نوشتن فایل PPTX بر روی دیسک
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **شماره‌گذاری در سلول‌های ادغام‌شده**
اگر دو جفت سلول (1, 1) × (2, 1) و (1, 2) × (2, 2) را ادغام کنیم، جدول حاصل شماره‌گذاری می‌شود. این کد JavaScript فرآیند را نشان می‌دهد:

```javascript
// نمونه سازی کلاس Presentation که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // تعریف ستون‌ها با عرض و ردیف‌ها با ارتفاع
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // افزودن شکل جدول به اسلاید
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // تنظیم فرمت حاشیه برای هر سلول
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // ادغام سلول‌ها (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // ادغام سلول‌ها (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

سپس سلول‌ها را بیشتر ادغام می‌کنیم با ادغام (1, 1) و (1, 2). نتیجه جدول حاوی یک سلول بزرگ ادغام‌شده در مرکز آن است:

```javascript
// نمونه سازی کلاس Presentation که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // تعریف ستون‌ها با عرض و ردیف‌ها با ارتفاع
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // افزودن شکل جدول به اسلاید
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // تنظیم فرمت حاشیه برای هر سلول
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // ادغام سلول‌ها (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // ادغام سلول‌ها (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // ادغام سلول‌ها (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // نوشتن فایل PPTX بر روی دیسک
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **شماره‌گذاری در سلول تقسیم‌شده**
در مثال‌های قبلی، زمانی که سلول‌های جدول ادغام شدند، سیستم شماره‌گذاری در سایر سلول‌ها تغییر نکرد.  

این بار یک جدول معمولی (جدولی بدون سلول‌های ادغام‌شده) می‌گیریم و سپس سعی می‌کنیم سلول (1,1) را تقسیم کنیم تا جدول ویژه‌ای به دست آوریم. ممکن است به شماره‌گذاری این جدول توجه کنید که ممکن است عجیب به نظر برسد. اما این همان روشی است که Microsoft PowerPoint سلول‌های جدول را شماره‌گذاری می‌کند و Aspose.Slides نیز به همان شکل عمل می‌کند.  

این کد JavaScript فرآیندی که توضیح دادیم را نشان می‌دهد:

```javascript
// نمونه سازی کلاس Presentation که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // تعریف ستون‌ها با عرض و ردیف‌ها با ارتفاع
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // افزودن شکل جدول به اسلاید
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // تنظیم فرمت حاشیه برای هر سلول
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // ادغام سلول‌ها (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // ادغام سلول‌ها (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // تقسیم سلول (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // نوشتن فایل PPTX بر روی دیسک
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تغییر رنگ پس‌زمینه سلول جدول**

این کد JavaScript نشان می‌دهد چگونه رنگ پس‌زمینه یک سلول جدول تغییر یابد:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // ایجاد یک جدول جدید
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // تنظیم رنگ پس‌زمینه برای یک سلول
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **افزودن تصویر داخل سلول جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک آرایه از ستون‌ها با عرض تعریف کنید.  
4. یک آرایه از ردیف‌ها با ارتفاع تعریف کنید.  
5. یک جدول را به اسلاید اضافه کنید با استفاده از متد [addTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) .  
6. یک شیء `Images` ایجاد کنید تا فایل تصویر را نگه دارد.  
7. تصویر `IImage` را به شیء `PPImage` اضافه کنید.  
8. `FillFormat` سلول جدول را به `Picture` تنظیم کنید.  
9. تصویر را به اولین سلول جدول اضافه کنید.  
10. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه هنگام ایجاد جدول، تصویر را داخل یک سلول جدول قرار دهید:

```javascript
// نمونه سازی کلاس Presentation که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اولین اسلاید
    var islide = pres.getSlides().get_Item(0);
    // تعریف ستون‌ها با عرض و ردیف‌ها با ارتفاع
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // افزودن شکل جدول به اسلاید
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // ایجاد یک شیء PPImage با استفاده از فایل تصویر
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // افزودن تصویر به اولین سلول جدول
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // ذخیره فایل PPTX بر روی دیسک
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پرسش‌های متداول**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای هر سمت یک سلول تنظیم کنم؟**  
بله. حاشیه‌های [top](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellformat/getborderright/) دارای ویژگی‌های جداگانه هستند، بنابراین ضخامت و سبک هر سمت می‌تواند متفاوت باشد. این به‌طور منطقی از کنترل حاشیه به‌ازای هر سمت برای یک سلول که در مقاله نشان داده شد، ناشی می‌شود.

**اگر پس از تنظیم تصویر به‌عنوان پس‌زمینه سلول، اندازه ستون/ردیف را تغییر دهم چه اتفاقی برای تصویر می‌افتد؟**  
رفتار بستگی به [fill mode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillmode/) دارد (کشیده‑شده/کاشی). در حالت کشیدنی، تصویر با سلول جدید سازگار می‌شود؛ در حالت کاشی، کاشی‌ها دوباره محاسبه می‌شوند. مقاله به حالت‌های نمایش تصویر در یک سلول اشاره دارد.

**آیا می‌توانم یک پیوند فراگیری به تمام محتوای یک سلول اختصاص دهم؟**  
[Hyperlinks](/slides/fa/nodejs-java/manage-hyperlinks/) در سطح متن (بخش) داخل چارچوب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول تنظیم کنم؟**  
بله. چارچوب متن یک سلول از [portions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—خانواده قلم، سبک، اندازه و رنگ—پشتیبانی می‌کند.