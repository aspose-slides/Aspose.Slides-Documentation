---
title: مدیریت جداول ارائه در اندروید
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/androidjava/manage-table/
keywords:
- اضافه‌کردن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت ابعاد
- هم‌راستایی متن
- قالب‌بندی متن
- سبک جدول
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای Android. مثال‌های ساده کد Java را برای ساده‌سازی جریان کار جداول کشف کنید."
---
## **مقدمه**

جدول‌ها در PowerPoint اطلاعات را به صورت ردیف و ستون سازماندهی می‌کنند و خواندن و مقایسه مقادیر را آسان‌تر می‌سازند.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/)، رابط [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/)، کلاس [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/)، رابط [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) و انواع دیگر را ارائه می‌دهد تا بتوانید جدول‌ها را در ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جدول از ابتدا**

جدولی را با تعیین موقعیت، عرض ستون‌ها و ارتفاع ردیف‌ها ایجاد کنید. پس از اضافه کردن آن به یک اسلاید، می‌توانید حاشیه‌های سلول‌ها را قالب‌بندی کنید، سلول‌ها را ادغام کنید و متن وارد کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید را با استفاده از اندیس آن بدست آورید.
3. آرایه‌ای از عرض ستون‌ها به واحد پوینت تعریف کنید.
4. آرایه‌ای از ارتفاع ردیف‌ها به واحد پوینت تعریف کنید.
5. یک شیء [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) را از طریق متد [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) به اسلاید اضافه کنید.
6. برای هر [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) مرزی بالایی، پایینی، راست و چپ را قالب‌بندی کنید.
7. دو سلول اول ردیف اول جدول را ادغام کنید.
8. با استفاده از متد [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) به سلول ادغام شده دسترسی پیدا کنید.
9. متن را در سلول ادغام شده تنظیم کنید.
10. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر جدولی با سه ستون و پنج ردیف در نقطه‌های (100, 50) می‌سازد. حاشیه‌های قرمز با عرض 5 پوینت اعمال می‌کند، دو سلول اول ردیف اول را ادغام می‌کند و نتیجه را به عنوان `table.pptx` ذخیره می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **شماره‌گذاری در یک جدول استاندارد**

در یک جدول استاندارد، اندیس‌های سلول از صفر آغاز می‌شوند و ترتیب (ستون، ردیف) را استفاده می‌کنند. اولین سلول به صورت (0, 0) شماره‌گذاری می‌شود.

به عنوان مثال، سلول‌های یک جدول با 4 ستون و 4 ردیف به این صورت شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این مثال جدول 4 × 4 نشان داده‌شده در بالا را ایجاد می‌کند، با عرض ستون‌ها و ارتفاع ردیف‌ها برابر با 70 پوینت و حاشیه‌های سلول قرمز با عرض 5 پوینت. مختصات اندیس‌های سلول‌ها را نشان می‌دهد؛ مثال سلول‌ها را خالی رها می‌کند و جدول را به عنوان `StandardTables_out.pptx` ذخیره می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

جداول در مجموعهٔ اشکال یک اسلاید ذخیره می‌شوند. با مرور اشکال، جدول را پیدا کنید، سپس از رابط [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) برای خواندن یا به‌روزرسانی سلول‌های آن استفاده کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید حاوی جدول را با استفاده از اندیس آن بدست آورید.
3. میان اشیاء [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) مرور کنید و زمانی که جدول یافت شد متوقف شوید. اگر اسلاید چند جدول داشته باشد، از متد [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) برای شناسایی جدول مورد نیاز استفاده کنید.
4. متن سلول هدف را به‌روزرسانی کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر `UpdateExistingTable.pptx` را باز می‌کند و اولین جدول را در اسلاید اول می‌یابد. سلول ستون 0، ردیف 1 را به `New` تنظیم می‌کند و نتیجه را به عنوان `table1_out.pptx` ذخیره می‌کند. ورودی باید حداقل یک اسلاید داشته باشد و اولین جدول آن اسلاید باید حداقل یک ستون و دو ردیف داشته باشد.

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

برای تغییر اندازهٔ ردیف در جدول موجود و درک دلیل اینکه ارتفاع واقعی می‌تواند بیش از حداقل درخواست‌شده باشد، به بخش [Control Row Height](/slides/fa/androidjava/manage-rows-and-columns/#control-row-height) مراجعه کنید.

## **یافتن سلولی که چارچوب متن را داراست**

هنگامی که کد عمومی پردازش متن یک شیء [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) را از یک جدول دریافت می‌کند، از متد [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) برای به‌دست آوردن [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) مالک استفاده کنید. برای یک چارچوب متن سلول‑جدول، [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) مالک را برمی‌گرداند و [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) مقدار `null` می‌دهد، حتی اگر جدول خودش یک شکل باشد.

مختصات سلول‌ها از طریق متدهای فقط‑خواندنی [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) و [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) در دسترس هستند. همچنین [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) ناوبری فقط‑خواندنی را فراهم می‌کند: مالک را برمی‌گرداند اما مالکیت را تغییر نمی‌دهد. پیش از استفاده، همیشه بررسی کنید که سلول بازگردانده‌شده `null` نیست.

برای مثال کامل که مالکین سلول‑جدول و اشکال را شناسایی می‌کند، از جمله اشکالی که به گره‌های SmartArt مرتبط هستند، به بخش [Search and Replace Text](/slides/fa/androidjava/search-and-replace-text/) مراجعه کنید.

## **هم‌راستایی متن در جدول**

می‌توانید انکر عمودی و جهت متن سلول‌های فردی جدول را کنترل کنید. مثال این بخش متن را در اولین سلول مرکز می‌کند و آن را به اندازهٔ 270 درجه می‌چرخاند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید را با استفاده از اندیس آن بدست آورید.
3. یک شیء [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) را به اسلاید اضافه کنید.
4. یک شیء [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) را از جدول دسترسی پیدا کنید.
5. اولین [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) را دسترسی داشته و متن و رنگ آن را تنظیم کنید.
6. انکر عمودی سلول و جهت متن را با استفاده از متدهای [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) و [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) تنظیم کنید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

این مثال جدول 4 × 4 با عرض ستون 120 پوینت و ارتفاع ردیف 100 پوینت می‌سازد. متن سلول (0, 0) را قالب‌بندی می‌کند، مقادیر را به سلول‌های باقی‌مانده ردیف اول اضافه می‌کند و نتیجه را به عنوان `Vertical_Align_Text_out.pptx` ذخیره می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

از متد [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) برای اعمال قالب‌بندی متن به تمام سلول‌های یک جدول استفاده کنید. نسخه‌های اضافه‌بار آن می‌توانند قالب‌بندی بخش، پاراگراف و چارچوب متن را بپذیرند، بنابراین می‌توانید این ویژگی‌ها را بدون مرور سلول‌های جداگانه تنظیم کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید را با استفاده از اندیس آن بدست آورید.
3. یک شیء [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) را از اسلاید دسترسی داشته باشید.
4. اندازه قلم را با استفاده از متد [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) برای متن تنظیم کنید.
5. ترازبندی پاراگراف و حاشیهٔ راست را با استفاده از متدهای [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) تنظیم کنید.
6. جهت متن را با استفاده از متد [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) تنظیم کنید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر `table.pptx` را باز می‌کند؛ این فایل باید حداقل یک اسلاید با جدول به عنوان اولین شکل داشته باشد. اندازه قلم را به 25 پوینت تنظیم می‌کند، پاراگراف‌ها را به راست ترازبندی می‌کند با حاشیهٔ راست 20 پوینت و متن را عمودی می‌سازد. ارائهٔ قالب‌بندی‌شده به عنوان `result.pptx` ذخیره می‌شود.

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

از متد [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) برای خواندن سبک پیش تنظیم جدول و از متد [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) برای اختصاص آن استفاده کنید. این مثال [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) را به یک جدول اعمال می‌کند، مقدار پیش تنظیم را چاپ می‌کند و همان پیش تنظیم را به جدول دوم اختصاص می‌دهد. هر دو جدول در `table-style.pptx` ذخیره می‌شوند.

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

نسبت ابعاد یک جدول، نسبت عرض به ارتفاع آن است. از متد [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) برای قفل کردن این نسبت برای یک جدول استفاده کنید.

مثال زیر `pres.pptx` را باز می‌کند؛ این فایل باید حداقل یک اسلاید با جدول به عنوان اولین شکل داشته باشد. وضعیت قفل فعلی را چاپ می‌کند، قفل نسبت ابعاد را فعال می‌سازد، وضعیت به‌روزشده (`true`) را چاپ می‌کند و نتیجه را به عنوان `pres-out.pptx` ذخیره می‌کند.

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

**آیا می‌توانم جهت خواندن راست به چپ (RTL) را برای تمام جدول و متن داخل سلول‌های آن فعال کنم؟**

بله. جدول متد [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) را ارائه می‌دهد و پاراگراف‌ها متد [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) را دارند. استفاده از هر دو اطمینان می‌دهد که ترتیب RTL صحیح است و درون سلول‌ها به درستی رندر می‌شود.

**چگونه می‌توانم از جابه‌جایی یا تغییر اندازهٔ جدول توسط کاربران در فایل نهایی جلوگیری کنم؟**

از [قفل‌های شکل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) استفاده کنید تا جابه‌جایی، تغییر اندازه، انتخاب و غیره را غیرفعال کنید. این قفل‌ها بر روی جدول‌ها نیز اعمال می‌شوند.

**آیا افزودن تصویر به عنوان پس‌زمینه داخل یک سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول پرکنش تصویر ([picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/)) تنظیم کنید؛ تصویر با توجه به حالت انتخابی (کشیده کردن یا کاشی) ناحیهٔ سلول را پوشش می‌دهد.