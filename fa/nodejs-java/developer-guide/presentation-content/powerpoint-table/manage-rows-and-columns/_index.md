---
title: مدیریت ردیف‌ها و ستون‌ها در جداول PowerPoint با JavaScript
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
description: "مدیریت ردیف‌ها و ستون‌های جدول در PowerPoint با JavaScript و Aspose.Slides برای Node.js از طریق Java و تسریع ویرایش ارائه و به‌روزرسانی داده‌ها."
---
## **مقدمه**

Aspose.Slides for Node.js via Java به شما امکان مدیریت ساختار جدول و قالب‌بندی در ارائه‌های PowerPoint را از طریق کلاس [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) می‌دهد. می‌توانید یک ردیف سرصفحه تعیین کنید، ردیف‌ها و ستون‌ها را کلون یا حذف کنید، و قالب‌بندی متن را بر کل یک ردیف یا ستون اعمال نمایید.

این مقاله این عملیات را با مثال‌های JavaScript توضیح می‌دهد. همچنین نشان می‌دهد چگونه پیش‌تنظیم سبک جدول را دریافت کنید تا بتوانید آن را دوباره استفاده کنید. شاخص‌های ردیف و ستون جدول بر پایه صفر هستند.

## **کنترل ارتفاع ردیف**

از متد [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) برای تنظیم حداقل ارتفاع ردیف به نقطه استفاده کنید. این مقدار یک حد پایین است، نه ارتفاع ثابت. متد [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) ارتفاع واقعی را برمی‌گرداند. ردیف را از طریق [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--) دریافت کنید.

مثال فایل [row-height-input.pptx](row-height-input.pptx) را بارگذاری می‌کند که جدول به عنوان اولین شکل در اسلاید اول قرار دارد. ردیف اول آن در ۷۰ نقطه شروع می‌شود. سلول‌ها از متن Arial با اندازه ۱۸ نقطه، بسته شدن متن و حاشیه ۶ نقطه‌ای بالا و پایین استفاده می‌کنند؛ متن طولانی‌تر در ستون دوم به چند خط می‌پیچد. مثال حداقل را به ۱۰۰ نقطه افزایش می‌دهد، سپس به ۲۰ نقطه کاهش می‌دهد، پس از هر تغییر ارتفاع واقعی را چاپ می‌کند و هر دو نتیجه را ذخیره می‌نماید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

با ارائهٔ ارائه شده، افزایش حداقل فضای بیشتری به ردیف اضافه می‌کند. کاهش آن آن فضای اضافی را حذف می‌کند، اما ارتفاع واقعی بزرگتر از ۲۰ نقطه می‌ماند چون متن و حاشیه‌های سلول به فضای بیشتری نیاز دارند. فقط کاهش حداقل به تنهایی نمی‌تواند ردیف را زیر فضای مورد نیاز محتوا بکشد.

چند عامل بر ارتفاع واقعی تأثیر می‌گذارند:

- **متن و اندازهٔ قلم:** متن طولانی‌تر، شکست‌های خط صریح یا قلم بزرگ‌تر می‌توانند فضای عمودی بیشتری نیاز داشته باشند.
- **پوشش و عرض ستون:** با فعال بودن پوشش، کاهش عرض ستون با متد [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) می‌تواند خطوط بیشتری ایجاد کند. ستون عریض‌تر می‌تواند فضای عمودی مورد نیاز را کاهش دهد.
- **حاشیه‌های سلول:** متدهای [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) و [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) فضای عمودی اضافه می‌کنند. متدهای [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) و [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) عرض در دسترس برای متن را کاهش می‌دهند و می‌توانند باعث پوشش بیشتر شوند.

برای این جدول بدون سلول‌های ادغام‌شده، سلولی که بیشترین فضای عمودی را می‌طلبد، حد پایین محتوا‑محور کل ردیف را تعیین می‌کند. برای کوتاه‌تر کردن ردیف ممکن است نیاز باشد متن را کوتاه کنید، اندازهٔ قلم یا حاشیه‌ها را کاهش دهید، یا ستونی را عریض‌تر کنید.

تصاویر زیر همان جدول را با همان مقیاس نشان می‌دهند. در نتایج نشان داده‌شده، ارتفاع‌های واقعی ۷۰، ١٠٠ و ۵۵.۲ نقطه بودند: ردیف نهایی همچنان بلندتر از حداقل ۲۰ نقطه‌اش باقی ماند. اندازه‌گیری‌های دقیق متن می‌توانند بسته به قلم‌های موجود در محیط شما متفاوت باشند. نتایج ذخیره‌شده را دانلود کنید: [increased minimum](row-height-increased.pptx) و [decreased minimum](row-height-decreased.pptx).

| اصل: حداقل ۷۰ pt، واقعی ۷۰ pt | افزایش یافته: حداقل ۱۰۰ pt، واقعی ۱۰۰ pt | کاهش یافته: حداقل ۲۰ pt، واقعی ۵۵.۲ pt |
| --- | --- | --- |
| ![جدول اصلی با ردیف اول ۷۰ نقطه‌ای.](row-height-before.png) | ![جدول پس از افزایش حداقل ردیف اول به ۱۰۰ نقطه.](row-height-increased.png) | ![جدول پس از کاهش حداقل ردیف اول به ۲۰ نقطه؛ متن بسته‌شده ردیف را بلندتر از حداقل نگه می‌دارد.](row-height-decreased.png) |

## **تنظیم ردیف اول به عنوان سرصفحه**

از متد [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) برای علامت‌گذاری ردیف اول به عنوان سرصفحه استفاده کنید. ظاهر آن بستگی به سبک جدول اعمال‌شده دارد.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) بارگذاری کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. جدول ذخیره‌شده به‌عنوان اولین شکل در اسلاید را دسترسی پیدا کنید.
4. قالب‌بندی سرصفحه را برای ردیف اول فعال کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال به فایل `table.pptx` که جدول به عنوان اولین شکل در اسلاید اول دارد نیاز دارد. قالب‌بندی سرصفحه برای ردیف اول را فعال می‌کند و `First_row_header.pptx` را ذخیره می‌نماید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کلون یک ردیف یا ستون جدول**

ردیف‌ها یا ستون‌ها را کلون کنید تا محتوا و قالب‌بندی آن‌ها را دوباره استفاده کنید. می‌توانید یک کپی را به انتهای جدول اضافه کنید یا در موقعیت خاصی وارد کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) بارگذاری کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. عرض ستون‌ها و ارتفاع ردیف‌ها را تعریف کنید.
4. با متد [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) یک جدول اضافه کنید.
5. ردیف‌های مورد نیاز را کلون کنید.
6. ستون‌های مورد نیاز را کلون کنید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

مثال به فایل `Test.pptx` که حداقل یک اسلاید دارد نیاز دارد. جدولی با سه ستون و پنج ردیف ایجاد می‌کند؛ ابعاد به نقطه تعریف شده‌اند. نسخه‌های ردیف و ستون اول را اضافه می‌کند، سپس نسخه‌های ردیف و ستون دوم را در شاخص ۳ (موقعیت چهارم) وارد می‌کند. جدول نهایی هفت ردیف و پنج ستون دارد. آرگومان `false` کلون شدن به ردیف‌ها یا ستون‌های ادغام‌شدهٔ مجاور را غیرفعال می‌کند؛ این جدول سلول ادغام‌شده‌ای ندارد.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حذف یک ردیف یا ستون از جدول**

ردیف‌ها یا ستون‌هایی که دیگر نیازی به آن‌ها نیست حذف کنید. حذف یک مورد شاخص‌های ردیف‌ها یا ستون‌های بعدی را جابجا می‌کند.

1. یک ارائه با کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. عرض ستون‌ها و ارتفاع ردیف‌ها را تعریف کنید.
4. با متد [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) یک جدول اضافه کنید.
5. ردیف دوم و ستون دوم را حذف کنید.
6. ارائهٔ تغییر یافته را ذخیره کنید.

این مثال جدولی سه در سه ایجاد می‌کند و ردیف و ستون با شاخص ۱ را حذف می‌کند، به‌طوری که جدولی دو در دو در `TestTable_out.pptx` باقی می‌ماند. ابعاد به نقطه هستند. آرگومان `false` حذف ردیف‌ها یا ستون‌های ادغام‌شدهٔ مجاور را غیرفعال می‌کند؛ این جدول سلول ادغام‌شده‌ای ندارد.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **قالب‌بندی متن در سطح ردیف جدول**

قالب‌بندی متن را بر کل یک ردیف اعمال کنید تا سلول‌های آن هماهنگ بمانند. می‌توانید ویژگی‌های قلم، قالب‌بندی پاراگراف و جهت متن را بدون قالب‌بندی هر سلول به‌صورت جداگانه تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) بارگذاری کنید.
2. جدول موجود در اسلاید اول را دسترسی پیدا کنید.
3. برای ردیف اول از متد [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) استفاده کنید.
4. برای ردیف اول از متدهای [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) و [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) استفاده کنید.
5. برای ردیف دوم از متد [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) استفاده کنید.
6. ارائهٔ تغییر یافته را ذخیره کنید.

مثال به فایل `table.pptx` که جدول به عنوان اولین شکل در اسلاید اول دارد و حداقل دو ردیف دارد نیاز دارد. متن ۲۵‑نقطه‌ای، ترازبندی راست و حاشیهٔ پاراگراف راست ۲۰‑نقطه‌ای را به ردیف اول اعمال می‌کند، سپس متن عمودی را در ردیف دوم تنظیم می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **قالب‌بندی متن در سطح ستون جدول**

قالب‌بندی متن را بر کل یک ستون اعمال کنید تا سلول‌های آن هماهنگ بمانند. می‌توانید ویژگی‌های قلم، قالب‌بندی پاراگراف و جهت متن را بدون قالب‌بندی هر سلول به‌صورت جداگانه تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) بارگذاری کنید.
2. جدول موجود در اسلاید اول را دسترسی پیدا کنید.
3. برای ستون اول از متد [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) استفاده کنید.
4. برای ستون اول از متدهای [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) و [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) استفاده کنید.
5. برای ستون دوم از متد [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) استفاده کنید.
6. ارائهٔ تغییر یافته را ذخیره کنید.

مثال به فایل `table.pptx` که جدول به عنوان اولین شکل در اسلاید اول دارد و حداقل دو ستون دارد نیاز دارد. متن ۲۵‑نقطه‌ای، ترازبندی راست و حاشیهٔ پاراگراف راست ۲۰‑نقطه‌ای را به ستون اول اعمال می‌کند، سپس متن عمودی را در ستون دوم تنظیم می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های سبک جدول**

از متد [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) برای دریافت پیش‌تنظیم اعمال‌شده به جدول و استفاده مجدد از آن در جدول دیگر استفاده کنید. این پیش‌تنظیم را شناسایی می‌کند نه بازنویسی‌های قالب‌بندی سلول‌های منفرد.

مثال یک جدول ایجاد می‌کند، پیش‌تنظیم [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) را اعمال می‌کند و پیش‌تنظیم را می‌خواند. مقدار صحیح مربوط به `DarkStyle1` را چاپ می‌کند و جدول را در `table.pptx` ذخیره می‌نماید.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم تم/سبک‌های PowerPoint را به جدولی که قبلاً ساخته شده اعمال کنم؟**

بله. جدول تم اسلاید/چیدمان/مستر را به ارث می‌برد و همچنان می‌توانید پرکننده‌ها، حاشیه‌ها و رنگ‌های متن را در بالای آن تم بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را مانند Excel مرتب کنم؟**

خیر، جداول Aspose.Slides قابلیت مرتب‌سازی یا فیلترهای داخلی ندارند. ابتدا داده‌ها را در حافظه مرتب کنید، سپس ردیف‌های جدول را به ترتیب آن بازپر کنید.

**آیا می‌توانم ستون‌های نواردار (خط‌دار) داشته باشم در حالی که رنگ‌های سفارشی را برای سلول‌های خاص نگه دارم؟**

بله. نوارهای ستون را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی در سطح سلول بر سبک جدول ارجحیت دارد.