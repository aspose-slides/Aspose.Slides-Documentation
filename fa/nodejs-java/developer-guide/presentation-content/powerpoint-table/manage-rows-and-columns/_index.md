---
title: مدیریت ردیف‌ها و ستون‌ها در جداول PowerPoint با استفاده از JavaScript
linktitle: ردیف‌ها و ستون‌ها
type: docs
weight: 20
url: /fa/nodejs-java/manage-rows-and-columns/
keywords:
- ردیف جدول
- ستون جدول
- ردیف اول
- سرصفحه جدول
- کلون ردیف
- کلون ستون
- کپی ردیف
- کپی ستون
- حذف ردیف
- حذف ستون
- قالب‌بندی متن ردیف
- قالب‌بندی متن ستون
- سبک جدول
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: مدیریت ردیف‌ها و ستون‌های جدول در PowerPoint با JavaScript و Aspose.Slides برای Node.js از طریق Java و تسریع ویرایش ارائه و به‌روزرسانی داده‌ها.
---
## **معرفی**

برای این‌که بتوانید ردیف‌ها و ستون‌های یک جدول را در یک ارائه PowerPoint مدیریت کنید، Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/table/) و انواع دیگر را ارائه می‌دهد.

## **تنظیم ردیف اول به عنوان سرصفحه**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید.
2. از طریق اندیس آن، مرجع یک اسلاید را دریافت کنید. 
3. یک شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) ایجاد کنید و آن را null تنظیم کنید.
4. از میان تمام اشیاء [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) عبور کنید تا جدول مربوطه را پیدا کنید.
5. ردیف اول جدول را به عنوان سرصفحه تنظیم کنید. 

این کد JavaScript نشان می‌دهد که چگونه ردیف اول یک جدول را به عنوان سرصفحه تنظیم کنید:

```javascript
// کلاس Presentation را ایجاد می‌کند
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    var sld = pres.getSlides().get_Item(0);
    // TableEx را به صورت null مقداردهی اولیه می‌کند
    var tbl = null;
    // از میان اشکال عبور می‌کند و مرجع جدول را تنظیم می‌نماید
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // ردیف اول جدول را به عنوان سرصفحه تنظیم می‌کند
            tbl.setFirstRow(true);
        }
    }
    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **کلون کردن ردیف یا ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید،
2. از طریق اندیس آن، مرجع یک اسلاید را دریافت کنید. 
3. `columnWidth` را به صورت آرایه تعریف کنید.
4. `rowHeight` را به صورت آرایه تعریف کنید.
5. یک شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) را به اسلاید اضافه کنید با استفاده از متد [addTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
6. ردیف جدول را کلون کنید.
7. ستون جدول را کلون کنید.
8. ارائه تغییر یافته را ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه ردیف یا ستون یک جدول PowerPoint را کلون کنید:

```javascript
// کلاس Presentation را ایجاد می‌کند
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    var sld = pres.getSlides().get_Item(0);
    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // یک شکل جدول را به اسلاید اضافه می‌کند
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // متنی را به ردیف 1 سلول 1 اضافه می‌کند
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // متنی را به ردیف 1 سلول 2 اضافه می‌کند
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // ردیف 1 را در انتهای جدول کلون می‌کند
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // متنی را به ردیف 2 سلول 1 اضافه می‌کند
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // متنی را به ردیف 2 سلول 2 اضافه می‌کند
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // ردیف 2 را به عنوان ردیف چهارم جدول کلون می‌کند
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // ستون اول را در انتها کلون می‌کند
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // ستون دوم را در ایندکس ستون چهارم کلون می‌کند
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حذف ردیف یا ستون از جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید،
2. از طریق اندیس آن، مرجع یک اسلاید را دریافت کنید. 
3. `columnWidth` را به صورت آرایه تعریف کنید.
4. `rowHeight` را به صورت آرایه تعریف کنید.
5. یک شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) را به اسلاید اضافه کنید با استفاده از متد [addTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
6. ردیف جدول را حذف کنید.
7. ستون جدول را حذف کنید.
8. ارائه تغییر یافته را ذخیره کنید. 

این کد JavaScript نشان می‌دهد که چگونه یک ردیف یا ستون را از جدول حذف کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم قالب‌بندی متن در سطح ردیف جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید،
2. از طریق اندیس آن، مرجع یک اسلاید را دریافت کنید. 
3. شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) مربوطه را از اسلاید دسترسی پیدا کنید.
4. متد [setFontHeight(float value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) را برای سلول‌های ردیف اول تنظیم کنید.
5. متدهای [setAlignment(int value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) را برای سلول‌های ردیف اول تنظیم کنید.
6. متد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) را برای سلول‌های ردیف دوم تنظیم کنید.
7. ارائه تغییر یافته را ذخیره کنید.

این کد JavaScript عملیات را نشان می‌دهد.

```javascript
// یک نمونه از کلاس Presentation را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // فرض می‌کنیم که اولین شکل در اولین اسلاید یک جدول است
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // ارتفاع قلم سلول‌های ردیف اول را تنظیم می‌کند
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // تراز متن و حاشیه راست سلول‌های ردیف اول را تنظیم می‌کند
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // نوع عمودی متن سلول‌های ردیف دوم را تنظیم می‌کند
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم قالب‌بندی متن در سطح ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید،
2. از طریق اندیس آن، مرجع یک اسلاید را دریافت کنید. 
3. شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) مربوطه را از اسلاید دسترسی پیدا کنید.
4. متد [setFontHeight(float value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) را برای سلول‌های ستون اول تنظیم کنید.
5. متدهای [setAlignment(int value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) را برای سلول‌های ستون اول تنظیم کنید.
6. متد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) را برای سلول‌های ستون دوم تنظیم کنید.
7. ارائه تغییر یافته را ذخیره کنید. 

این کد JavaScript عملیات را نشان می‌دهد:

```javascript
// یک نمونه از کلاس Presentation را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // فرض می‌کنیم که اولین شکل در اولین اسلاید یک جدول است
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // ارتفاع قلم سلول‌های ستون اول را تنظیم می‌کند
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // تراز متن و حاشیه راست سلول‌های ستون اول را در یک فراخوانی تنظیم می‌کند
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // نوع عمودی متن سلول‌های ستون دوم را تنظیم می‌کند
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های سبک یک جدول را بازیابی کنید تا بتوانید این جزئیات را برای جدول دیگر یا در مکان دیگری استفاده کنید. این کد JavaScript نشان می‌دهد که چگونه ویژگی‌های سبک را از یک سبک پیش‌فرض جدول دریافت کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// پیش‌فرض سبک پیش‌نشانده را تغییر می‌دهد
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا می‌توانم تم/سبک‌های PowerPoint را به جدولی که از پیش ایجاد شده اعمال کنم؟**

بله. جدول تم اسلاید/طرح/مستر را به ارث می‌برد و شما همچنان می‌توانید پر کردن‌ها، حاشیه‌ها و رنگ‌های متن را بر روی آن تم بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را مانند Excel مرتب کنم؟**

خیر، جداول Aspose.Slides قابلیت مرتب‌سازی یا فیلترهای داخلی ندارند. ابتدا داده‌ها را در حافظه مرتب کنید، سپس ردیف‌های جدول را به ترتیب آن دوباره پر کنید.

**آیا می‌توانم ستون‌های نوار دار (راه‌راه) داشته باشم در حالی که رنگ‌های سفارشی را برای سلول‌های خاص حفظ کنم؟**

بله. ستون‌های نوار دار را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی سطح سلول بر سبک جدول اولویت دارد.