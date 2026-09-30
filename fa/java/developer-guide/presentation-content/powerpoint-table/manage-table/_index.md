---
title: مدیریت جداول ارائه در جاوا
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/java/manage-table/
keywords:
- افزودن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت ابعاد
- ترازبندی متن
- قالب‌بندی متن
- سبک جدول
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای Java. مثال‌های کد ساده‌ای را کشف کنید تا گردش کار جداول خود را بهبود بخشید."
---
## **معرفی**

جداول در پاورپوینت اطلاعات را به صورت ردیف و ستون سازماندهی می‌کنند و خواندن و مقایسه مقادیر را آسان‌تر می‌سازند.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/)، اینترفیس [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/)، کلاس [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/)، اینترفیس [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) و انواع دیگر را برای ایجاد، به‌روزرسانی و مدیریت جداول در ارائه‌ها فراهم می‌کند.

## **ایجاد جدول از ابتدا**

یک جدول را با تعیین موقعیت، عرض ستون‌ها و ارتفاع ردیف‌ها ایجاد کنید. پس از افزودن آن به اسلاید، می‌توانید مرزهای سلول‌ها را قالب‌بندی کنید، سلول‌ها را ادغام کنید و متن وارد کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از شاخص، مرجع اسلاید را دریافت کنید.
3. آرایه‌ای از عرض ستون‌ها بر حسب پوینت تعریف کنید.
4. آرایه‌ای از ارتفاع ردیف‌ها بر حسب پوینت تعریف کنید.
5. یک شیء [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) را از طریق متد [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) به اسلاید اضافه کنید.
6. برای هر [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) مرزهای بالا، پایین، راست و چپ را قالب‌بندی کنید.
7. دو سلول اول ردیف اول جدول را ادغام کنید.
8. از طریق متد [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) به سلول ادغام‌شده دسترسی پیدا کنید.
9. متن را در سلول ادغام‌شده تنظیم کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر جدولی با سه ستون و پنج ردیف در موقعیت (100, 50) پوینت ایجاد می‌کند. مرزهای قرمز با عرض 5 پوینت را اعمال می‌کند، دو سلول اول ردیف اول را ادغام می‌کند و نتیجه را به عنوان `table.pptx` ذخیره می‌نماید.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شاخص‌های سلول از صفر آغاز می‌شوند و به ترتیب (ستون، ردیف) استفاده می‌شوند. اولین سلول با شاخص (0, 0) مشخص می‌شود.

به عنوان مثال، سلول‌های یک جدول با 4 ستون و 4 ردیف به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این مثال جدول 4 × 4 نشان‌داده‌شده در بالا را با عرض ستون‌ها و ارتفاع ردیف‌ها برابر 70 پوینت و مرزهای سلول قرمز با عرض 5 پوینت ایجاد می‌کند. مختصات‌ها شاخص‌های سلول را نشان می‌دهند؛ مثال سلول‌ها را خالی می‌گذارد و جدول را به عنوان `StandardTables_out.pptx` ذخیره می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دسترسی به جدول موجود**

جداول در مجموعه اشکال یک اسلاید ذخیره می‌شوند. با مرور اشکال جدول را پیدا کنید، سپس از اینترفیس [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) برای خواندن یا به‌روزرسانی سلول‌های آن استفاده کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید حاوی جدول را با شاخص آن دریافت کنید.
3. در میان اشیاء [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) مرور کنید و وقتی جدول یافت شد، متوقف شوید. اگر اسلاید چند جدول داشته باشد، از متد [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) برای شناسایی جدول مورد نیاز استفاده کنید.
4. متن سلول هدف را به‌روزرسانی کنید.
5. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر `UpdateExistingTable.pptx` را باز می‌کند و اولین جدول را در اولین اسلاید پیدا می‌کند. سلول ستون 0، ردیف 1 را به `New` تنظیم می‌کند و نتیجه را به عنوان `table1_out.pptx` ذخیره می‌نماید. ورودی باید حداقل یک اسلاید داشته باشد و اولین جدول آن اسلاید باید حداقل یک ستون و دو ردیف داشته باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

برای تغییر اندازه ردیف در جدول موجود و درک این‌که چرا ارتفاع واقعی می‌تواند از حداقل درخواستی بیشتر باشد، به بخش [Control Row Height](/slides/fa/java/manage-rows-and-columns/#control-row-height) مراجعه کنید.

## **یافتن سلولی که چارچوب متن (Text Frame) را در اختیار دارد**

زمانی که کدی که به طور کلی متن را پردازش می‌کند، یک شیء [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) از یک جدول دریافت می‌کند، از متد [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) برای دریافت [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) مالک استفاده کنید. برای چارچوب متن سلول جدول، متد [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) مالک را برمی‌گرداند و متد [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) مقدار `null` را برمی‌گرداند، هرچند جدول خود یک شکل است.

مختصات سلول از طریق متدهای فقط‑خواندنی [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) و [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) قابل دسترسی است. متد [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) همچنین ناوبری فقط‑خواندنی فراهم می‌کند: مالک را برمی‌گرداند اما مالکیت را تغییر نمی‌دهد. قبل از استفاده، همیشه بررسی کنید که سلول برگردانده‌شده `null` نباشد.

برای یک مثال کامل که مالکین سلول‑جدول و شکل را شناسایی می‌کند، از جمله اشکالی که به گره‌های SmartArt مرتبط هستند، به بخش [Search and Replace Text](/slides/fa/java/search-and-replace-text/) مراجعه کنید.

## **تراز کردن متن در جدول**

می‌توانید تراز عمودی و جهت متن سلول‌های جداگانه جدول را کنترل کنید. مثال این بخش متن را در اولین سلول مرکزی می‌کند و آن را به‌صورت 270 درجه می‌چرخاند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید را با شاخص آن دریافت کنید.
3. یک شیء [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) را به اسلاید اضافه کنید.
4. یک شیء [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) را از جدول دسترسی پیدا کنید.
5. اولین [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) را دسترسی پیدا کنید و متن و رنگ آن را تنظیم کنید.
6. تراز عمودی سلول و جهت متن را با استفاده از متدهای [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) و [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-) تنظیم کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این مثال جدول 4 × 4 با عرض ستون 120 پوینت و ارتفاع ردیف 100 پوینت ایجاد می‌کند. متن سلول (0, 0) را قالب‌بندی می‌کند، مقادیر را به سلول‌های باقی‌مانده ردیف اول اضافه می‌کند و نتیجه را به عنوان `Vertical_Align_Text_out.pptx` ذخیره می‌نماید.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم قالب‌بندی متن در سطح جدول**

از متد [setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) برای اعمال قالب‌بندی متن به تمام سلول‌های یک جدول استفاده کنید. بارگذاری‌های آن می‌توانند قالب‌بندی بخش، پاراگراف و چارچوب متن را بپذیرند، بنابراین می‌توانید این ویژگی‌ها را بدون مرور هر سلول به‌طور جداگانه تنظیم کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید را با شاخص آن دریافت کنید.
3. یک شیء [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) را از اسلاید دسترسی پیدا کنید.
4. اندازه قلم را با استفاده از متد [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) برای متن تنظیم کنید.
5. تراز پاراگراف و حاشیه راست را با متدهای [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) تنظیم کنید.
6. جهت متن را با استفاده از متد [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) تنظیم کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر `table.pptx` را باز می‌کند که باید حداقل یک اسلاید با جدول به عنوان اولین شکل داشته باشد. اندازه قلم را به 25 پوینت تنظیم می‌کند، پاراگراف‌ها را راست‌تراز می‌نماید و حاشیه راست را به 20 پوینت تنظیم می‌کند و متن را عمودی می‌سازد. ارائه قالب‌بندی‌شده به عنوان `result.pptx` ذخیره می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های سبک جدول**

از متد [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) برای خواندن سبک پیش‌فرض جدول و متد [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) برای اختصاص آن استفاده کنید. این مثال [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) را به یک جدول اعمال می‌کند، مقدار پیش‌فرض را چاپ می‌کند و همان پیش‌فرض را به جدول دوم اختصاص می‌دهد. هر دو جدول در `table-style.pptx` ذخیره می‌شوند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **قفل کردن نسبت ابعاد جدول**

نسبت ابعاد یک جدول، نسبت عرض به ارتفاع آن است. از متد [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) برای قفل کردن این نسبت استفاده کنید.

مثال زیر `pres.pptx` را باز می‌کند که باید حداقل یک اسلاید با جدول به عنوان اولین شکل داشته باشد. وضعیت قفل فعلی را چاپ می‌کند، قفل نسبت ابعاد را فعال می‌نماید، وضعیت به‌روزرسانی‌شده (`true`) را چاپ می‌کند و نتیجه را به عنوان `pres-out.pptx` ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم جهت خواندن راست‌به‌چپ (RTL) را برای کل جدول و متن داخل سلول‌های آن فعال کنم؟**

بله. جدول متد [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-) را فراهم می‌کند و پاراگراف‌ها متد [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) را دارند. استفاده همزمان از هر دو، ترتیب RTL صحیح و رندرینگ داخل سلول‌ها را تضمین می‌کند.

**چگونه می‌توانم از جابجا یا تغییر اندازه جدول توسط کاربران در فایل نهایی جلوگیری کنم؟**

از [قفل‌های شکل](/slides/fa/java/applying-protection-to-presentation/) برای غیرفعال کردن جابجایی، تغییر اندازه، انتخاب و غیره استفاده کنید. این قفل‌ها بر روی جداول نیز اعمال می‌شوند.

**آیا افزودن تصویر به عنوان پس‌زمینه داخل سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول پرکنش تصویری ([picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/)) تنظیم کنید؛ تصویر بر اساس حالت انتخاب‌شده (کشیدن یا کاشی) کل فضای سلول را پوشش می‌دهد.