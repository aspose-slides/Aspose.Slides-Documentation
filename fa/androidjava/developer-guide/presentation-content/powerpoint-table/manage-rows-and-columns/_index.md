---
title: مدیریت ردیف‌ها و ستون‌ها در جداول PowerPoint برای Android
linktitle: ردیف‌ها و ستون‌ها
type: docs
weight: 20
url: /fa/androidjava/manage-rows-and-columns/
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
- Android
- Java
- Aspose.Slides
description: "مدیریت ردیف‌ها و ستون‌های جدول در PowerPoint با Aspose.Slides برای Android از طریق Java و تسریع ویرایش ارائه و به‌روزرسانی داده‌ها."
---
## **معرفی**

Aspose.Slides for Android via Java به شما امکان مدیریت ساختار جدول و قالب‌بندی در ارائه‌های PowerPoint را از طریق کلاس [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) و رابط [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) می‌دهد. می‌توانید یک ردیف عنوان تعیین کنید، ردیف‌ها و ستون‌ها را کپی یا حذف کنید و قالب‌بندی متن را بر روی یک ردیف یا ستون کامل اعمال کنید.

این مقاله این عملیات را با مثال‌های Java توضیح می‌دهد. همچنین نحوه دریافت پیش‌تنظیم سبک جدول را نشان می‌دهد تا بتوانید آن را مجدداً استفاده کنید. شاخص‌های ردیف و ستون جدول از صفر شروع می‌شوند.

## **کنترل ارتفاع ردیف**

از [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) برای تنظیم حداقل ارتفاع ردیف بر حسب پوینت استفاده کنید. این مقدار یک حد پایین است، نه یک ارتفاع ثابت. [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) ارتفاع واقعی را برمی‌گرداند. ردیف را از طریق [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--) دسترسی پیدا کنید.

مثال فایل [row-height-input.pptx](row-height-input.pptx) را بارگذاری می‌کند که جدولی به عنوان اولین شکل در اولین اسلاید دارد. ردیف اول آن از ۷۰ پوینت شروع می‌شود. سلول‌ها متن Arial ۱۸ پوینت دارند، بسته‌بندی می‌شود و حاشیه‌های بالایی و پایینی ۶ پوینت دارند؛ متن طولانی‌تر در ستون دوم روی چند خط بسته‌بندی می‌شود. مثال حداقل ارتفاع را به ۱۰۰ پوینت افزایش می‌دهد، سپس به ۲۰ پوینت کاهش می‌دهد، ارتفاع واقعی را پس از هر تغییر چاپ می‌کند و هر دو نتیجه را ذخیره می‌کند.

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

با ارائهٔ فراهم‌شده، افزایش حداقل باعث افزودن فضا به ردیف می‌شود. کاهش آن همان فضا را حذف می‌کند، اما ارتفاع واقعی بزرگتر از ۲۰ پوینت می‌ماند زیرا متن و حاشیه‌های سلول به فضای بیشتری نیاز دارند. کاهش فقط حداقل نمی‌تواند ردیف را زیر فضایی که محتوا نیاز دارد بفشارد.

چند عامل بر ارتفاع واقعی تأثیر می‌گذارند:

- **متن و اندازه فونت:** متن طولانی‌تر، شکست خط صریح یا فونت بزرگ‌تر می‌توانند فضای عمودی بیشتری نیاز داشته باشند.
- **بسته‌بندی و عرض ستون:** با فعال بودن بسته‌بندی، کاهش عرض ستون با [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) می‌تواند خطوط بیشتری ایجاد کند. یک ستون وسیع‌تر می‌تواند فضای عمودی مورد نیاز را کاهش دهد.
- **حاشیه‌های سلول:** [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) و [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) فضای عمودی اضافه می‌کند. [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) و [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) عرض موجود برای متن را کاهش می‌دهد و می‌تواند بسته‌بندی بیشتری ایجاد کند.

برای این جدول بدون سلول‌های ادغام‌شده، سلولی که بیشترین فضای عمودی را نیاز دارد، حد پایین مبتنی بر محتوا را برای کل ردیف تعیین می‌کند. برای کوتاه کردن ردیف ممکن است نیاز به کوتاه کردن متن، کاهش اندازه فونت یا حاشیه‌ها، یا عرض بیشتر ستون داشته باشید.

تصاویر زیر همان جدول را در همان مقیاس نشان می‌دهند. در نتایج نشان‌داده‌شده، ارتفاع‌های واقعی ۷۰، ۱۰۰ و ۵۵٫۲ پوینت بود: ردیف نهایی بلندتر از حداقل ۲۰ پوینت باقی ماند. اندازه‌گیری دقیق متن می‌تواند با فونت‌های موجود در محیط شما متفاوت باشد. نتایج ذخیره‌شده را دانلود کنید: [حداقل افزایش یافته](row-height-increased.pptx) و [حداقل کاهش یافته](row-height-decreased.pptx).

| اصلی: حداقل ۷۰ پوینت، واقعی ۷۰ پوینت | افزایش یافته: حداقل ۱۰۰ پوینت، واقعی ۱۰۰ پوینت | کاهش یافته: حداقل ۲۰ پوینت، واقعی ۵۵٫۲ پوینت |
| --- | --- | --- |
| ![جدول اصلی با ردیف اول ۷۰ پوینت](row-height-before.png) | ![جدول پس از افزایش حداقل ردیف اول به ۱۰۰ پوینت](row-height-increased.png) | ![جدول پس از کاهش حداقل ردیف اول به ۲۰ پوینت؛ متن بسته‌بندی‌شده ردیف را بلندتر از حداقل نگه می‌دارد](row-height-decreased.png) |

## **تنظیم ردیف اول به‌عنوان عنوان**

از متد [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) برای علامت‌گذاری ردیف اول به‌عنوان عنوان استفاده کنید. ظاهر آن بسته به سبک جدول اعمال‌شده بر جدول متفاوت است.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) بارگذاری کنید.
2. اسلاید اول را دسترسی پیدا کنید.
3. جدول ذخیره‌شده به‌عنوان اولین شکل در اسلاید را دسترسی پیدا کنید.
4. قالب‌بندی عنوان را برای ردیف اول فعال کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال به فایلی به نام `table.pptx` نیاز دارد که جدول به‌عنوان اولین شکل در اولین اسلاید داشته باشد. این مثال قالب‌بندی عنوان را برای ردیف اول فعال می‌کند و `First_row_header.pptx` را ذخیره می‌کند.

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

## **کپی کردن ردیف یا ستون جدول**

ردیف‌ها یا ستون‌ها را کپی کنید تا محتوا و قالب‌بندی آن‌ها را مجدداً استفاده کنید. می‌توانید یک نسخه را به انتهای جدول اضافه کنید یا در موقعیتی خاص وارد کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) بارگذاری کنید.
2. اسلاید اول را دسترسی پیدا کنید.
3. عرض ستون‌ها و ارتفاع ردیف‌ها را تعریف کنید.
4. با متد [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) جدول اضافه کنید.
5. ردیف‌های مورد نیاز را کپی کنید.
6. ستون‌های مورد نیاز را کپی کنید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

مثال به فایلی به نام `Test.pptx` نیاز دارد که حداقل یک اسلاید داشته باشد. این مثال جدولی با سه ستون و پنج ردیف ایجاد می‌کند، ابعاد را بر حسب پوینت مشخص می‌کند، نسخه‌های ردیف و ستون اول را اضافه می‌کند، سپس نسخه‌های ردیف و ستون دوم را در اندیس ۳ (موقعیت چهارم) وارد می‌کند. جدول نتیجه دارای هفت ردیف و پنج ستون است. آرگومان `false` کپی در ردیف‌ها یا ستون‌های ادغام‌شده مجاور را غیرفعال می‌کند؛ این جدول سلول‌های ادغام‌شده‌ای ندارد.

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

## **حذف ردیف یا ستون از جدول**

ردیف‌ها یا ستون‌هایی که دیگر نیازی به آن‌ها نیست را از جدول حذف کنید. حذف یک مورد، شاخص‌های ردیف‌ها یا ستون‌های پس از آن را جابه‌جا می‌کند.

1. ارائه‌ای با کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید اول را دسترسی پیدا کنید.
3. عرض ستون‌ها و ارتفاع ردیف‌ها را تعریف کنید.
4. با متد [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) جدول اضافه کنید.
5. ردیف دوم و ستون دوم را حذف کنید.
6. ارائهٔ تغییر یافته را ذخیره کنید.

این مثال جدول سه‌در‑سه‌ای ایجاد می‌کند و ردیف و ستون با شاخص ۱ را حذف می‌کند، درنتیجه جدول دو‑در‑دو در `TestTable_out.pptx` باقی می‌ماند. ابعاد بر حسب پوینت هستند. آرگومان `false` حذف ردیف‌ها یا ستون‌های ادغام‌شدهٔ مجاور را غیرفعال می‌کند؛ این جدول سلول‌های ادغام‌شده‌ای ندارد.

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

قالب‌بندی متن را بر روی یک ردیف کامل اعمال کنید تا سلول‌های آن هم‌سان بمانند. می‌توانید خصوصیات فونت، قالب‌بندی پاراگراف و جهت متن را بدون قالب‌بندی هر سلول به‌صورت جداگانه تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) بارگذاری کنید.
2. جدول در اسلاید اول را دسترسی پیدا کنید.
3. برای ردیف اول از [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) استفاده کنید.
4. برای ردیف اول از [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) استفاده کنید.
5. برای ردیف دوم از [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) استفاده کنید.
6. ارائهٔ تغییر یافته را ذخیره کنید.

مثال به فایلی به نام `table.pptx` نیاز دارد که جدول به‌عنوان اولین شکل در اولین اسلاید داشته باشد و حداقل دو ردیف داشته باشد. این مثال متن ۲۵ پوینت، ترازبندی راست و حاشیه پاراگراف راست ۲۰ پوینت را برای ردیف اول اعمال می‌کند، سپس متن عمودی را برای ردیف دوم تنظیم می‌کند.

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

قالب‌بندی متن را بر روی یک ستون کامل اعمال کنید تا سلول‌های آن هم‌سان بمانند. می‌توانید خصوصیات فونت، قالب‌بندی پاراگراف و جهت متن را بدون قالب‌بندی هر سلول به‌صورت جداگانه تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) بارگذاری کنید.
2. جدول در اسلاید اول را دسترسی پیدا کنید.
3. برای ستون اول از [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) استفاده کنید.
4. برای ستون اول از [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) استفاده کنید.
5. برای ستون دوم از [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) استفاده کنید.
6. ارائهٔ تغییر یافته را ذخیره کنید.

مثال به فایلی به نام `table.pptx` نیاز دارد که جدول به‌عنوان اولین شکل در اولین اسلاید داشته باشد و حداقل دو ستون داشته باشد. این مثال متن ۲۵ پوینت، ترازبندی راست و حاشیه پاراگراف راست ۲۰ پوینت را برای ستون اول اعمال می‌کند، سپس متن عمودی را برای ستون دوم تنظیم می‌کند.

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

از متد [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) برای دریافت پیش‌تنظیم اعمال‌شده به یک جدول و استفاده مجدد از آن در جدول دیگر استفاده کنید. این پیش‌تنظیم را شناسایی می‌کند نه بازنویسی‌های قالب‌بندی سلول به‌صورت جداگانه.

مثال یک جدول ایجاد می‌کند، از [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1) استفاده می‌کند و پیش‌تنظیم را می‌خواند. مقدار عددی متناظر با `DarkStyle1` را چاپ می‌کند و جدول را در `table.pptx` ذخیره می‌کند.

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

**آیا می‌توانم تم‌ها/سبک‌های PowerPoint را به جدول قبلاً ایجاد شده اعمال کنم؟**

بله. جدول تم اسلاید/چیدمان/مستر را به ارث می‌برد و همچنان می‌توانید پرکننده‌ها، حاشیه‌ها و رنگ‌های متن را روی آن تم بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را مانند Excel مرتب کنم؟**

خیر، جداول Aspose.Slides قابلیت مرتب‌سازی یا فیلتر داخلی ندارند. ابتدا داده‌ها را در حافظه مرتب کنید، سپس ردیف‌های جدول را به ترتیب آن دوباره پر کنید.

**آیا می‌توانم ستون‌های نوار‌دار (خط‌خط) داشته باشم در حالی که رنگ‌های سفارشی را برای سلول‌های خاص حفظ کنم؟**

بله. نوارهای ستون را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی در سطح سلول بر سبک جدول اولویت دارد.