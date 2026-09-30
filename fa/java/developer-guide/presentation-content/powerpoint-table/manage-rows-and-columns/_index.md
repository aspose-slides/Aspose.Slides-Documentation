---
title: مدیریت ردیف‌ها و ستون‌ها در جداول پاورپوینت با استفاده از جاوا
linktitle: ردیف‌ها و ستون‌ها
type: docs
weight: 20
url: /fa/java/manage-rows-and-columns/
keywords:
- ردیف جدول
- ستون جدول
- ردیف اول
- سرصفحه جدول
- تکثیر ردیف
- تکثیر ستون
- کپی ردیف
- کپی ستون
- حذف ردیف
- حذف ستون
- قالب‌بندی متن ردیف
- قالب‌بندی متن ستون
- سبک جدول
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "مدیریت ردیف‌ها و ستون‌های جدول در پاورپوینت با Aspose.Slides برای جاوا و سرعت‌بخشیدن به ویرایش ارائه‌ها و به‌روزرسانی داده‌ها."
---
## **مقدمه**

Aspose.Slides for Java به شما امکان می‌دهد ساختار و قالب‌بندی جدول را در ارائه‌های PowerPoint از طریق کلاس [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) و رابط [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) مدیریت کنید. می‌توانید یک ردیف سرصفحه تعیین کنید، ردیف‌ها و ستون‌ها را کپی یا حذف کنید و قالب‌بندی متن را به یک ردیف یا ستون کامل اعمال کنید.

این مقاله این عملیات را با مثال‌های Java توضیح می‌دهد. همچنین نشان می‌دهد چگونه پیش تنظیم سبک جدول را بازیابی کنید تا بتوانید آن را مجدداً استفاده کنید. ایندکس‌های ردیف و ستون جدول از صفر شروع می‌شوند.

## **کنترل ارتفاع ردیف**

از [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) برای تنظیم حداقل ارتفاع ردیف به پوینت استفاده کنید. این مقدار یک حد پایین است، نه ارتفاع ثابت. [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) ارتفاع واقعی را برمی‌گرداند. ردیف را از طریق [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--) دسترسی پیدا کنید.

مثال فایل [row-height-input.pptx](row-height-input.pptx) را بارگذاری می‌کند که یک جدول به عنوان اولین شکل در اولین اسلاید دارد. ردیف اول آن از ۷۰ پوینت آغاز می‌شود. سلول‌ها از متن Arial به اندازه ۱۸ پوینت، بسته شدن خطوط و حاشیهٔ بالا و پایین ۶ پوینت استفاده می‌کنند؛ متن طولانی‌تر در ستون دوم به خطوط متعدد بسته می‌شود. مثال حداقل ارتفاع را به ۱۰۰ پوینت افزایش می‌دهد، سپس به ۲۰ پوینت کاهش می‌دهد، پس از هر تغییر ارتفاع واقعی را چاپ می‌کند و هر دو نتیجه را ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

با ارائهٔ ارائه‌شده، افزایش حداقل فضای بیشتری به ردیف اضافه می‌کند. کاهش آن آن فضا را حذف می‌کند، اما ارتفاع واقعی بزرگ‌تر از ۲۰ پوینت می‌ماند زیرا متن و حاشیه‌های سلول به فضای بیشتری نیاز دارند. کاهش تنها حداقل نمی‌تواند ردیف را زیر فضای مورد نیاز محتوا بکشاند.

چندین عامل بر ارتفاع واقعی تأثیر می‌گذارند:

- **متن و اندازه قلم:** متن طولانی‌تر، شکست‌های صریح خط یا قلم بزرگ‌تر می‌تواند فضای عمودی بیشتری نیاز داشته باشد.
- **بسته شدن خطوط و عرض ستون:** با فعال بودن بسته شدن خطوط، کاهش عرض ستون با [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) می‌تواند خطوط بیشتری ایجاد کند. ستون عریض‌تر می‌تواند فضای عمودی مورد نیاز را کاهش دهد.
- **حاشیه‌های سلول:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) و [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) فضای عمودی اضافه می‌کنند. [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) و [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) عرض موجود برای متن را کاهش می‌دهند و می‌توانند بسته شدن خطوط بیشتری ایجاد کنند.

برای این جدول بدون سلول‌های ادغام‌شده، سلولی که بیشترین فضای عمودی را نیاز دارد، حد پایین محتوا‑محور برای کل ردیف را تعیین می‌کند. برای کوتاه‌تر کردن ردیف ممکن است لازم باشد متن را کوتاه کنید، اندازه قلم یا حاشیه‌ها را کاهش دهید یا ستون را عریض‌تر کنید.

تصاویر زیر همان جدول را در همان مقیاس نشان می‌دهند. در نتایج نشان‌داده‌شده، ارتفاع‌های واقعی ۷۰، ۱۰۰ و ۵۵.۲ پوینت بودند: ردیف نهایی همچنان ارتفاعی بزرگ‌تر از حداقل ۲۰ پوینت داشت. اندازه‌گیری دقیق متن می‌تواند بسته به قلم‌های موجود در محیط شما متفاوت باشد. نتایج ذخیره‌شده را دانلود کنید: [increased minimum](row-height-increased.pptx) و [decreased minimum](row-height-decreased.pptx).

| اصلی: حداقل 70 pt، واقعی 70 pt | افزایش یافته: حداقل 100 pt، واقعی 100 pt | کاهش یافته: حداقل 20 pt، واقعی 55.2 pt |
| --- | --- | --- |
| ![جدول اصلی با ردیف اول 70 پوینت.](row-height-before.png) | ![جدول پس از افزایش حداقل ردیف اول به 100 پوینت.](row-height-increased.png) | ![جدول پس از کاهش حداقل ردیف اول به 20 پوینت؛ متن بسته‌شده ردیف را بزرگ‌تر از حداقل نگه می‌دارد.](row-height-decreased.png) |

## **تنظیم ردیف اول به‌عنوان سرصفحه**

از متد [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) برای علامت‌گذاری ردیف اول جهت قالب‌بندی سرصفحه استفاده کنید. ظاهر آن به سبک جدول اعمال‌شده به جدول وابسته است.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) بارگذاری کنید.
2. به اسلاید اول دسترسی پیدا کنید.
3. جدولی که به‌عنوان اولین شکل در اسلاید ذخیره شده است را دسترسی پیدا کنید.
4. قالب‌بندی سرصفحه را برای ردیف اول آن فعال کنید.
5. ارائه اصلاح‌شده را ذخیره کنید.

مثال به فایل `table.pptx` نیاز دارد که جدول به عنوان اولین شکل در اولین اسلاید دارد. قالب‌بندی سرصفحه را برای ردیف اول فعال می‌کند و `First_row_header.pptx` را ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کپی یک ردیف یا ستون جدول**

ردیف‌ها یا ستون‌ها را کپی کنید تا محتوا و قالب‌بندی آن‌ها را مجدداً استفاده کنید. می‌توانید یک کپی را به انتهای جدول اضافه کنید یا در موقعیتی خاص درج کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) بارگذاری کنید.
2. به اسلاید اول دسترسی پیدا کنید.
3. عرض‌های ستون و ارتفاع‌های ردیف را تعریف کنید.
4. جدول را با متد [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) اضافه کنید.
5. ردیف‌های مورد نیاز را کپی کنید.
6. ستون‌های مورد نیاز را کپی کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

مثال به فایل `Test.pptx` نیاز دارد که حداقل یک اسلاید داشته باشد. جدول با سه ستون و پنج ردیف ایجاد می‌کند، ابعاد را بر حسب پوینت مشخص می‌کند، کپی‌هایی از ردیف و ستون اول اضافه می‌کند، سپس کپی‌های ردیف و ستون دوم را در ایندکس 3 (موقعیت چهارم) درج می‌کند. جدول حاصل هفت ردیف و پنج ستون دارد. آرگومان `false` کپی‌گذاری به ردیف‌ها یا ستون‌های ادغام‌شده مجاور را غیرفعال می‌کند؛ این جدول سلول‌های ادغام‌شده‌ای ندارد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حذف یک ردیف یا ستون از جدول**

ردیف‌ها یا ستون‌هایی را که دیگر مورد نیاز نیستند از جدول حذف کنید. حذف یک مورد شاخص‌های ردیف‌ها یا ستون‌های بعدی را جابه‌جا می‌کند.

1. ارائه‌ای را با کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید اول دسترسی پیدا کنید.
3. عرض‌های ستون و ارتفاع‌های ردیف را تعریف کنید.
4. جدول را با متد [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) اضافه کنید.
5. ردیف دوم و ستون دوم را حذف کنید.
6. ارائه اصلاح‌شده را ذخیره کنید.

این مثال یک جدول سه در سه ایجاد می‌کند و ردیف و ستون ایندکس 1 را حذف می‌کند، به‌طوری که جدول `TestTable_out.pptx` دو در دو می‌شود. ابعاد بر حسب پوینت هستند. آرگومان `false` حذف ردیف‌ها یا ستون‌های ادغام‌شده مجاور را غیرفعال می‌کند؛ این جدول سلول‌های ادغام‌شده‌ای ندارد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم قالب‌بندی متن در سطح ردیف جدول**

قالب‌بندی متن را برای یک ردیف کامل اعمال کنید تا سلول‌های آن یکنواخت بمانند. می‌توانید ویژگی‌های قلم، قالب‌بندی پاراگراف و جهت متن را بدون قالب‌بندی هر سلول به‌صورت جداگانه تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) بارگذاری کنید.
2. جدول موجود در اولین اسلاید را دسترسی پیدا کنید.
3. برای ردیف اول از [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) استفاده کنید.
4. برای ردیف اول از [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) استفاده کنید.
5. برای ردیف دوم از [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) استفاده کنید.
6. ارائه اصلاح‌شده را ذخیره کنید.

مثال به فایل `table.pptx` نیاز دارد که جدول به عنوان اولین شکل در اولین اسلاید دارد و حداقل دو ردیف دارد. متن ۲۵ پوینت، تراز راست و حاشیهٔ پاراگراف راست ۲۰ پوینت را به ردیف اول اعمال می‌کند، سپس متن عمودی را در ردیف دوم تنظیم می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم قالب‌بندی متن در سطح ستون جدول**

قالب‌بندی متن را برای یک ستون کامل اعمال کنید تا سلول‌های آن یکنواخت بمانند. می‌توانید ویژگی‌های قلم، قالب‌بندی پاراگراف و جهت متن را بدون قالب‌بندی هر سلول به‌صورت جداگانه تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) بارگذاری کنید.
2. جدول موجود در اولین اسلاید را دسترسی پیدا کنید.
3. برای ستون اول از [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) استفاده کنید.
4. برای ستون اول از [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) استفاده کنید.
5. برای ستون دوم از [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) استفاده کنید.
6. ارائه اصلاح‌شده را ذخیره کنید.

مثال به فایل `table.pptx` نیاز دارد که جدول به عنوان اولین شکل در اولین اسلاید دارد و حداقل دو ستون دارد. متن ۲۵ پوینت، تراز راست و حاشیهٔ پاراگراف راست ۲۰ پوینت را به ستون اول اعمال می‌کند، سپس متن عمودی را در ستون دوم تنظیم می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های سبک جدول**

از متد [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) برای بازیابی پیش تنظیم اعمال‌شده به جدول و استفاده مجدد از آن در جدول دیگر استفاده کنید. این روش پیش تنظیم را شناسایی می‌کند نه بازنویسی‌های قالب‌بندی سلولی فردی.

مثال یک جدول ایجاد می‌کند، [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1) را اعمال می‌کند و پیش تنظیم را می‌خواند. مقدار عددی متناظر با `DarkStyle1` را چاپ می‌کند و جدول را در `table.pptx` ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم تم/سبک‌های PowerPoint را به جدولی که قبلاً ایجاد شده است اعمال کنم؟**

بله. جدول تم اسلاید/چیدمان/مستر را به ارث می‌برد و همچنان می‌توانید روی آن پرکردن‌ها، حاشیه‌ها و رنگ‌های متن را بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را مانند Excel مرتب کنم؟**

نه، جدول‌های Aspose.Slides قابلیت مرتب‌سازی یا فیلترهای داخلی ندارند. ابتدا داده‌ها را در حافظه مرتب کنید، سپس ردیف‌های جدول را به ترتیب جدید پر کنید.

**آیا می‌توانم ستون‌های نوارگذاری (راه‌راه) داشته باشم در حالی که رنگ‌های سفارشی را برای سلول‌های خاص حفظ کنم؟**

بله. ستون‌های نوارگذاری را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی سطح سلول بر سبک جدول اولویت دارد.